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
// �� 2008.02.12 980081 a
using Broadleaf.Application.Common;
using System.Collections.Generic;
// �� 2008.02.12 980081 a

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �`�[����ݒ�DB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : �`�[����ݒ�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 22027�@���{�@����</br>
	/// <br>Date       : 2005.08.30</br>
    /// <br></br>
    /// <br>Update Note: 980081  �R�c ���F</br>
    /// <br>Date       : 2007.12.19</br>
    /// <br>           : ���ʊ�Ή�</br>
    /// <br>Update Note: 20081  �D�c �E�l</br>
    /// <br>Date       : 2008.05.23</br>
    /// <br>           : �o�l.�m�r�p�ɕύX</br>
    /// <br>Update Note: 22018  ��� ���b</br>
    /// <br>Date       : 2008.05.27</br>
    /// <br>           : PM.NS ���R���[�ɑΉ��B</br>
    /// <br>Update Note: 2009/12/31  ���M</br>
    /// <br>           : PM.NS-5-A�EPM.NS�ێ�˗��C</br>
    /// <br>           : �`�[���l�����A�`�[���l�Q�����A�`�[���l�R������ǉ��Ή�</br>
    /// <br>Update Note: 2010/08/06  caowj</br>
    /// <br>           : PM.NS1012</br>
    /// <br>           : �`�[�������ݐݒ�Ή�</br>
    /// <br>UpdateNote : 2010/08/25  ����</br>
    /// <br>             redmine 13549�̑Ή�</br>
    /// <br>Update Note: 2011/02/16  ���N�n��</br>
    /// <br>             ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
    /// <br>Update Note : 2011/07/19  chenyd</br>
    /// <br>             �E�񓚋敪�ǉ��̑Ή�</br>
    /// </remarks>
	[Serializable]
    public class SlipPrtSetDB : RemoteDB, ISlipPrtSetDB, IGetSyncdataList
	{
		#region constructor
		/// <summary>
		/// �`�[����ݒ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.08.30</br>
		/// </remarks>
		public SlipPrtSetDB() :
			base("SFURI09026D", "Broadleaf.Application.Remoting.ParamData.SlipPrtSetWork", "SLIPPRTSETRF") //���N���X�̃R���X�g���N�^
		{
		}
		#endregion
		
		#region Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓`�[����ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓`�[����ݒ�LIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.08.30</br>
		public int Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			try
			{
				return SearchProc(out retobj,paraobj ,readMode ,logicalMode);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "SlipPrtSetDB.Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)" );
				retobj = new ArrayList();
				return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓`�[����ݒ�LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓`�[����ݒ�LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.08.30</br>
        /// <br></br>
        /// <br>Update Note: 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.19</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// <br>Update Note: 2011/02/16  ���N�n��</br>
        /// <br>             ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        private int SearchProc(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();
			slipPrtSetWork = null;

			retobj = null;

			ArrayList al = new ArrayList();
			try 
			{	
				//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				slipPrtSetWork = paraobj as SlipPrtSetWork;

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                string sqlTxt = string.Empty; // 2008.05.23 add

				SqlCommand sqlCommand;

				//�f�[�^�Ǎ�
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
					(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					(logicalMode == ConstantManagement.LogicalMode.GetData2)||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
                    // 2008.05.23 upd start --------------------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM SLIPPRTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY DATAINPUTSYSTEMRF,SLIPPRTKINDRF,SLIPPRTSETPAPERIDRF  ",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPCOMMENTRF" + Environment.NewLine;
                    sqlTxt += "    ,OUTPUTPGIDRF" + Environment.NewLine;
                    sqlTxt += "    ,OUTPUTPGCLASSIDRF" + Environment.NewLine;
                    sqlTxt += "    ,OUTPUTFORMFILENAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISENAMEPRTCDRF" + Environment.NewLine;
                    sqlTxt += "    ,PRTCIRCULATIONRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPFORMCDRF" + Environment.NewLine;
                    sqlTxt += "    ,OUTCONFIMATIONMSGRF" + Environment.NewLine;
                    sqlTxt += "    ,OPTIONCODERF" + Environment.NewLine;
                    sqlTxt += "    ,TOPMARGINRF" + Environment.NewLine;
                    sqlTxt += "    ,LEFTMARGINRF" + Environment.NewLine;
                    sqlTxt += "    ,RIGHTMARGINRF" + Environment.NewLine;
                    sqlTxt += "    ,BOTTOMMARGINRF" + Environment.NewLine;
                    sqlTxt += "    ,PRTPREVIEWEXISTCODERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTPUTPURPOSERF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID1RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM1RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT1RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID2RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM2RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT2RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID3RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM3RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT3RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID4RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM4RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT4RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID5RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM5RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT5RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID6RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM6RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT6RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID7RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM7RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT7RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID8RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM8RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT8RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID9RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM9RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT9RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID10RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM10RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT10RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPFONTNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPFONTSIZERF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPFONTSTYLERF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED1RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN1RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU1RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED2RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN2RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU2RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED3RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN3RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU3RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED4RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN4RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU4RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED5RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN5RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU5RF" + Environment.NewLine;
                    sqlTxt += "    ,COPYCOUNTRF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME1RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME2RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME3RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME4RF" + Environment.NewLine;
                    sqlTxt += "    ,SPECIALPURPOSE1RF" + Environment.NewLine;
                    sqlTxt += "    ,SPECIALPURPOSE2RF" + Environment.NewLine;
                    sqlTxt += "    ,SPECIALPURPOSE3RF" + Environment.NewLine;
                    sqlTxt += "    ,SPECIALPURPOSE4RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME102RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME103RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME104RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME105RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME202RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME203RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME204RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME205RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME302RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME303RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME304RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME305RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME402RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME403RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME404RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME405RF" + Environment.NewLine;
                    sqlTxt += "    ,NOTE1RF" + Environment.NewLine;
                    sqlTxt += "    ,NOTE2RF" + Environment.NewLine;
                    sqlTxt += "    ,NOTE3RF" + Environment.NewLine;
                    sqlTxt += "    ,QRCODEPRINTDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,TIMEPRINTDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,REISSUEMARKRF" + Environment.NewLine;
                    sqlTxt += "    ,REFCONSTAXDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,REFCONSTAXPRTNMRF" + Environment.NewLine;
                    sqlTxt += "    ,DETAILROWCOUNTRF" + Environment.NewLine;
                    sqlTxt += "    ,HONORIFICTITLERF" + Environment.NewLine;
                    sqlTxt += "    ,CONSTAXPRTCDRF" + Environment.NewLine; // ADD 2008.12.11
                    // --- ADD 2009/12/31 ---------->>>>>
                    sqlTxt += "    ,SLIPNOTECHARCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPNOTE2CHARCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPNOTE3CHARCNTRF" + Environment.NewLine;
                    // --- ADD 2009/12/31 ----------<<<<<
                    sqlTxt += "    ,ENTNMPRTEXPDIVRF" + Environment.NewLine; // ADD 2011/02/16
                    // --- ADD 2011/07/19 ---------->>>>>
                    sqlTxt += "    ,SCMANSMARKPRTDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,NORMALPRTMARKRF" + Environment.NewLine;
                    sqlTxt += "    ,SCMMANUALANSMARKRF" + Environment.NewLine;
                    sqlTxt += "    ,SCMAUTOANSMARKRF" + Environment.NewLine;
                    // --- ADD 2011/07/19 ----------<<<<<
                    sqlTxt += " FROM SLIPPRTSETRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " ORDER BY DATAINPUTSYSTEMRF,SLIPPRTKINDRF,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.23 upd end -----------------------------------------------------------<<
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
                    // 2008.05.23 upd start --------------------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM SLIPPRTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY DATAINPUTSYSTEMRF,SLIPPRTKINDRF,SLIPPRTSETPAPERIDRF ",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPCOMMENTRF" + Environment.NewLine;
                    sqlTxt += "    ,OUTPUTPGIDRF" + Environment.NewLine;
                    sqlTxt += "    ,OUTPUTPGCLASSIDRF" + Environment.NewLine;
                    sqlTxt += "    ,OUTPUTFORMFILENAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISENAMEPRTCDRF" + Environment.NewLine;
                    sqlTxt += "    ,PRTCIRCULATIONRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPFORMCDRF" + Environment.NewLine;
                    sqlTxt += "    ,OUTCONFIMATIONMSGRF" + Environment.NewLine;
                    sqlTxt += "    ,OPTIONCODERF" + Environment.NewLine;
                    sqlTxt += "    ,TOPMARGINRF" + Environment.NewLine;
                    sqlTxt += "    ,LEFTMARGINRF" + Environment.NewLine;
                    sqlTxt += "    ,RIGHTMARGINRF" + Environment.NewLine;
                    sqlTxt += "    ,BOTTOMMARGINRF" + Environment.NewLine;
                    sqlTxt += "    ,PRTPREVIEWEXISTCODERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTPUTPURPOSERF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID1RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM1RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT1RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID2RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM2RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT2RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID3RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM3RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT3RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID4RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM4RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT4RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID5RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM5RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT5RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID6RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM6RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT6RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID7RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM7RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT7RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID8RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM8RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT8RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID9RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM9RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT9RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID10RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM10RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT10RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPFONTNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPFONTSIZERF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPFONTSTYLERF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED1RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN1RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU1RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED2RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN2RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU2RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED3RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN3RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU3RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED4RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN4RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU4RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED5RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN5RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU5RF" + Environment.NewLine;
                    sqlTxt += "    ,COPYCOUNTRF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME1RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME2RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME3RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME4RF" + Environment.NewLine;
                    sqlTxt += "    ,SPECIALPURPOSE1RF" + Environment.NewLine;
                    sqlTxt += "    ,SPECIALPURPOSE2RF" + Environment.NewLine;
                    sqlTxt += "    ,SPECIALPURPOSE3RF" + Environment.NewLine;
                    sqlTxt += "    ,SPECIALPURPOSE4RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME102RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME103RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME104RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME105RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME202RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME203RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME204RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME205RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME302RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME303RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME304RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME305RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME402RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME403RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME404RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME405RF" + Environment.NewLine;
                    sqlTxt += "    ,NOTE1RF" + Environment.NewLine;
                    sqlTxt += "    ,NOTE2RF" + Environment.NewLine;
                    sqlTxt += "    ,NOTE3RF" + Environment.NewLine;
                    sqlTxt += "    ,QRCODEPRINTDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,TIMEPRINTDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,REISSUEMARKRF" + Environment.NewLine;
                    sqlTxt += "    ,REFCONSTAXDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,REFCONSTAXPRTNMRF" + Environment.NewLine;
                    sqlTxt += "    ,DETAILROWCOUNTRF" + Environment.NewLine;
                    sqlTxt += "    ,HONORIFICTITLERF" + Environment.NewLine;
                    sqlTxt += "    ,CONSTAXPRTCDRF" + Environment.NewLine; // ADD 2008.12.11
                    // --- ADD 2009/12/31 ---------->>>>>
                    sqlTxt += "    ,SLIPNOTECHARCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPNOTE2CHARCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPNOTE3CHARCNTRF" + Environment.NewLine;
                    // --- ADD 2009/12/31 ----------<<<<<
                    sqlTxt += "    ,ENTNMPRTEXPDIVRF" + Environment.NewLine; // ADD 2011/02/16
                    // --- ADD 2011/07/19 ---------->>>>>
                    sqlTxt += "    ,SCMANSMARKPRTDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,NORMALPRTMARKRF" + Environment.NewLine;
                    sqlTxt += "    ,SCMMANUALANSMARKRF" + Environment.NewLine;
                    sqlTxt += "    ,SCMAUTOANSMARKRF" + Environment.NewLine;
                    // --- ADD 2011/07/19 ----------<<<<<

                    sqlTxt += " FROM SLIPPRTSETRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " ORDER BY DATAINPUTSYSTEMRF,SLIPPRTKINDRF,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.23 upd end -----------------------------------------------------------<<
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
                    // 2008.05.23 upd start --------------------------------------------------------->>
					//sqlCommand = new SqlCommand("SELECT * FROM SLIPPRTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY DATAINPUTSYSTEMRF,SLIPPRTKINDRF,SLIPPRTSETPAPERIDRF ",sqlConnection);
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPCOMMENTRF" + Environment.NewLine;
                    sqlTxt += "    ,OUTPUTPGIDRF" + Environment.NewLine;
                    sqlTxt += "    ,OUTPUTPGCLASSIDRF" + Environment.NewLine;
                    sqlTxt += "    ,OUTPUTFORMFILENAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISENAMEPRTCDRF" + Environment.NewLine;
                    sqlTxt += "    ,PRTCIRCULATIONRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPFORMCDRF" + Environment.NewLine;
                    sqlTxt += "    ,OUTCONFIMATIONMSGRF" + Environment.NewLine;
                    sqlTxt += "    ,OPTIONCODERF" + Environment.NewLine;
                    sqlTxt += "    ,TOPMARGINRF" + Environment.NewLine;
                    sqlTxt += "    ,LEFTMARGINRF" + Environment.NewLine;
                    sqlTxt += "    ,RIGHTMARGINRF" + Environment.NewLine;
                    sqlTxt += "    ,BOTTOMMARGINRF" + Environment.NewLine;
                    sqlTxt += "    ,PRTPREVIEWEXISTCODERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTPUTPURPOSERF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID1RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM1RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT1RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID2RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM2RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT2RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID3RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM3RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT3RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID4RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM4RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT4RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID5RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM5RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT5RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID6RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM6RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT6RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID7RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM7RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT7RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID8RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM8RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT8RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID9RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM9RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT9RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID10RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM10RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT10RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPFONTNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPFONTSIZERF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPFONTSTYLERF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED1RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN1RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU1RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED2RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN2RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU2RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED3RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN3RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU3RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED4RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN4RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU4RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED5RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN5RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU5RF" + Environment.NewLine;
                    sqlTxt += "    ,COPYCOUNTRF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME1RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME2RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME3RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME4RF" + Environment.NewLine;
                    sqlTxt += "    ,SPECIALPURPOSE1RF" + Environment.NewLine;
                    sqlTxt += "    ,SPECIALPURPOSE2RF" + Environment.NewLine;
                    sqlTxt += "    ,SPECIALPURPOSE3RF" + Environment.NewLine;
                    sqlTxt += "    ,SPECIALPURPOSE4RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME102RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME103RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME104RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME105RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME202RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME203RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME204RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME205RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME302RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME303RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME304RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME305RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME402RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME403RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME404RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME405RF" + Environment.NewLine;
                    sqlTxt += "    ,NOTE1RF" + Environment.NewLine;
                    sqlTxt += "    ,NOTE2RF" + Environment.NewLine;
                    sqlTxt += "    ,NOTE3RF" + Environment.NewLine;
                    sqlTxt += "    ,QRCODEPRINTDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,TIMEPRINTDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,REISSUEMARKRF" + Environment.NewLine;
                    sqlTxt += "    ,REFCONSTAXDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,REFCONSTAXPRTNMRF" + Environment.NewLine;
                    sqlTxt += "    ,DETAILROWCOUNTRF" + Environment.NewLine;
                    sqlTxt += "    ,HONORIFICTITLERF" + Environment.NewLine;
                    sqlTxt += "    ,CONSTAXPRTCDRF" + Environment.NewLine; // ADD 2008.12.11
                    // --- ADD 2009/12/31 ---------->>>>>
                    sqlTxt += "    ,SLIPNOTECHARCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPNOTE2CHARCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPNOTE3CHARCNTRF" + Environment.NewLine;
                    // --- ADD 2009/12/31 ----------<<<<<
                    sqlTxt += "    ,ENTNMPRTEXPDIVRF" + Environment.NewLine; // ADD 2011/02/16
                    // --- ADD 2011/07/19 ---------->>>>>
                    sqlTxt += "    ,SCMANSMARKPRTDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,NORMALPRTMARKRF" + Environment.NewLine;
                    sqlTxt += "    ,SCMMANUALANSMARKRF" + Environment.NewLine;
                    sqlTxt += "    ,SCMAUTOANSMARKRF" + Environment.NewLine;
                    // --- ADD 2011/07/19 ----------<<<<<
                    sqlTxt += " FROM SLIPPRTSETRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += " ORDER BY DATAINPUTSYSTEMRF,SLIPPRTKINDRF,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                    // 2008.05.23 upd end -----------------------------------------------------------<<
                }
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EnterpriseCode);

				myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				while(myReader.Read())
				{
					SlipPrtSetWork wkSlipPrtSetWork = new SlipPrtSetWork();

                    wkSlipPrtSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkSlipPrtSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkSlipPrtSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkSlipPrtSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkSlipPrtSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkSlipPrtSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkSlipPrtSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkSlipPrtSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkSlipPrtSetWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
                    wkSlipPrtSetWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRTKINDRF"));
                    wkSlipPrtSetWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
                    wkSlipPrtSetWork.SlipComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPCOMMENTRF"));
                    wkSlipPrtSetWork.OutputPgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGIDRF"));
                    wkSlipPrtSetWork.OutputPgClassId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGCLASSIDRF"));
                    wkSlipPrtSetWork.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                    wkSlipPrtSetWork.EnterpriseNamePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISENAMEPRTCDRF"));
                    wkSlipPrtSetWork.PrtCirculation = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTCIRCULATIONRF"));
                    wkSlipPrtSetWork.SlipFormCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPFORMCDRF"));
                    wkSlipPrtSetWork.OutConfimationMsg = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTCONFIMATIONMSGRF"));
                    wkSlipPrtSetWork.OptionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OPTIONCODERF"));
                    //wkSlipPrtSetWork.PrinterMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTERMNGNORF")); // 2008.05.23 del
                    wkSlipPrtSetWork.TopMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOPMARGINRF"));
                    wkSlipPrtSetWork.LeftMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LEFTMARGINRF"));
                    wkSlipPrtSetWork.RightMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RIGHTMARGINRF"));
                    wkSlipPrtSetWork.BottomMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BOTTOMMARGINRF"));
                    wkSlipPrtSetWork.PrtPreviewExistCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTPREVIEWEXISTCODERF"));
                    wkSlipPrtSetWork.OutputPurpose = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTPURPOSERF"));
                    wkSlipPrtSetWork.EachSlipTypeColId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID1RF"));
                    wkSlipPrtSetWork.EachSlipTypeColNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM1RF"));
                    wkSlipPrtSetWork.EachSlipTypeColPrt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT1RF"));
                    wkSlipPrtSetWork.EachSlipTypeColId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID2RF"));
                    wkSlipPrtSetWork.EachSlipTypeColNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM2RF"));
                    wkSlipPrtSetWork.EachSlipTypeColPrt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT2RF"));
                    wkSlipPrtSetWork.EachSlipTypeColId3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID3RF"));
                    wkSlipPrtSetWork.EachSlipTypeColNm3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM3RF"));
                    wkSlipPrtSetWork.EachSlipTypeColPrt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT3RF"));
                    wkSlipPrtSetWork.EachSlipTypeColId4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID4RF"));
                    wkSlipPrtSetWork.EachSlipTypeColNm4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM4RF"));
                    wkSlipPrtSetWork.EachSlipTypeColPrt4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT4RF"));
                    wkSlipPrtSetWork.EachSlipTypeColId5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID5RF"));
                    wkSlipPrtSetWork.EachSlipTypeColNm5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM5RF"));
                    wkSlipPrtSetWork.EachSlipTypeColPrt5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT5RF"));
                    wkSlipPrtSetWork.EachSlipTypeColId6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID6RF"));
                    wkSlipPrtSetWork.EachSlipTypeColNm6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM6RF"));
                    wkSlipPrtSetWork.EachSlipTypeColPrt6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT6RF"));
                    wkSlipPrtSetWork.EachSlipTypeColId7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID7RF"));
                    wkSlipPrtSetWork.EachSlipTypeColNm7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM7RF"));
                    wkSlipPrtSetWork.EachSlipTypeColPrt7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT7RF"));
                    wkSlipPrtSetWork.EachSlipTypeColId8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID8RF"));
                    wkSlipPrtSetWork.EachSlipTypeColNm8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM8RF"));
                    wkSlipPrtSetWork.EachSlipTypeColPrt8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT8RF"));
                    wkSlipPrtSetWork.EachSlipTypeColId9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID9RF"));
                    wkSlipPrtSetWork.EachSlipTypeColNm9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM9RF"));
                    wkSlipPrtSetWork.EachSlipTypeColPrt9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT9RF"));
                    wkSlipPrtSetWork.EachSlipTypeColId10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID10RF"));
                    wkSlipPrtSetWork.EachSlipTypeColNm10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM10RF"));
                    wkSlipPrtSetWork.EachSlipTypeColPrt10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT10RF"));
                    wkSlipPrtSetWork.SlipFontName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPFONTNAMERF"));
                    wkSlipPrtSetWork.SlipFontSize = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPFONTSIZERF"));
                    wkSlipPrtSetWork.SlipFontStyle = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPFONTSTYLERF"));
                    wkSlipPrtSetWork.SlipBaseColorRed1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED1RF"));
                    wkSlipPrtSetWork.SlipBaseColorGrn1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN1RF"));
                    wkSlipPrtSetWork.SlipBaseColorBlu1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU1RF"));
                    wkSlipPrtSetWork.SlipBaseColorRed2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED2RF"));
                    wkSlipPrtSetWork.SlipBaseColorGrn2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN2RF"));
                    wkSlipPrtSetWork.SlipBaseColorBlu2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU2RF"));
                    wkSlipPrtSetWork.SlipBaseColorRed3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED3RF"));
                    wkSlipPrtSetWork.SlipBaseColorGrn3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN3RF"));
                    wkSlipPrtSetWork.SlipBaseColorBlu3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU3RF"));
                    wkSlipPrtSetWork.SlipBaseColorRed4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED4RF"));
                    wkSlipPrtSetWork.SlipBaseColorGrn4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN4RF"));
                    wkSlipPrtSetWork.SlipBaseColorBlu4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU4RF"));
                    wkSlipPrtSetWork.SlipBaseColorRed5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED5RF"));
                    wkSlipPrtSetWork.SlipBaseColorGrn5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN5RF"));
                    wkSlipPrtSetWork.SlipBaseColorBlu5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU5RF"));
                    wkSlipPrtSetWork.CopyCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COPYCOUNTRF"));
                    wkSlipPrtSetWork.TitleName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME1RF"));
                    wkSlipPrtSetWork.TitleName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME2RF"));
                    wkSlipPrtSetWork.TitleName3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME3RF"));
                    wkSlipPrtSetWork.TitleName4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME4RF"));
                    wkSlipPrtSetWork.SpecialPurpose1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE1RF"));
                    wkSlipPrtSetWork.SpecialPurpose2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE2RF"));
                    wkSlipPrtSetWork.SpecialPurpose3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE3RF"));
                    wkSlipPrtSetWork.SpecialPurpose4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE4RF"));
                    //2006.12.06 deleted by T-Kidate
                    //wkSlipPrtSetWork.BarCodeCarMngNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BARCODECARMNGNOPRTCDRF"));
                    wkSlipPrtSetWork.TitleName102 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME102RF"));
                    wkSlipPrtSetWork.TitleName103 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME103RF"));
                    wkSlipPrtSetWork.TitleName104 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME104RF"));
                    wkSlipPrtSetWork.TitleName105 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME105RF"));
                    wkSlipPrtSetWork.TitleName202 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME202RF"));
                    wkSlipPrtSetWork.TitleName203 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME203RF"));
                    wkSlipPrtSetWork.TitleName204 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME204RF"));
                    wkSlipPrtSetWork.TitleName205 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME205RF"));
                    wkSlipPrtSetWork.TitleName302 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME302RF"));
                    wkSlipPrtSetWork.TitleName303 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME303RF"));
                    wkSlipPrtSetWork.TitleName304 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME304RF"));
                    wkSlipPrtSetWork.TitleName305 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME305RF"));
                    wkSlipPrtSetWork.TitleName402 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME402RF"));
                    wkSlipPrtSetWork.TitleName403 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME403RF"));
                    wkSlipPrtSetWork.TitleName404 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME404RF"));
                    wkSlipPrtSetWork.TitleName405 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME405RF"));
                    // 2008.05.23 add start ------------------------------------------>>
                    wkSlipPrtSetWork.Note1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
                    wkSlipPrtSetWork.Note2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
                    wkSlipPrtSetWork.Note3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
                    wkSlipPrtSetWork.QRCodePrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("QRCODEPRINTDIVCDRF"));
                    wkSlipPrtSetWork.TimePrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TIMEPRINTDIVCDRF"));
                    wkSlipPrtSetWork.ReissueMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REISSUEMARKRF"));
                    wkSlipPrtSetWork.RefConsTaxDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REFCONSTAXDIVCDRF"));
                    wkSlipPrtSetWork.RefConsTaxPrtNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REFCONSTAXPRTNMRF"));
                    wkSlipPrtSetWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
                    wkSlipPrtSetWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                    wkSlipPrtSetWork.ConsTaxPrtCdRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXPRTCDRF"));// ADD 2008.12.11
                    // --- ADD 2009/12/31 ---------->>>>>
                    wkSlipPrtSetWork.SlipNoteCharCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPNOTECHARCNTRF"));
                    wkSlipPrtSetWork.SlipNote2CharCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPNOTE2CHARCNTRF"));
                    wkSlipPrtSetWork.SlipNote3CharCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPNOTE3CHARCNTRF"));
                    // --- ADD 2009/12/31 ----------<<<<<

                    // 2008.05.23 add end --------------------------------------------<<
                    wkSlipPrtSetWork.EntNmPrtExpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTNMPRTEXPDIVRF"));// ADD 2011/02/16
                    // --- ADD 2011/07/19 ---------->>>>>
                    wkSlipPrtSetWork.SCMAnsMarkPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SCMANSMARKPRTDIVRF"));
                    wkSlipPrtSetWork.NormalPrtMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NORMALPRTMARKRF"));
                    wkSlipPrtSetWork.SCMManualAnsMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SCMMANUALANSMARKRF"));
                    wkSlipPrtSetWork.SCMAutoAnsMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SCMAUTOANSMARKRF"));
                    // --- ADD 2011/07/19 ----------<<<<<

                    //2006.12.06 deleted by T-Kidate
                    //wkSlipPrtSetWork.MainWorkLinePrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINWORKLINEPRTDIVCDRF"));
                    // �� 2007.12.19 980081 d
                    //wkSlipPrtSetWork.ContractNoPrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONTRACTNOPRTDIVCDRF"));
                    //wkSlipPrtSetWork.ContCpNoPrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONTCPNOPRTDIVCDRF"));
                    // �� 2007.12.19 980081 d
					al.Add(wkSlipPrtSetWork);

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
		#endregion

		#region Search(out ArrayList retArray,SlipPrtSetWork slipPrtSetWork, int readMode,ConstantManagement.LogicalMode logicalMode , ref SqlConnection sqlConnection)

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓`�[����ݒ�LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retArray">��������</param>
		/// <param name="slipPrtSetWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓`�[����ݒ�LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.08.30</br>
        /// <br></br>
        /// <br>Update Note: 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.19</br>
        /// <br>           : ���ʊ�Ή�</br>
        public int Search(out ArrayList retArray, SlipPrtSetWork slipPrtSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{
            return this.SearchProc(out retArray, slipPrtSetWork, readMode, logicalMode, ref sqlConnection);
        }
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓`�[����ݒ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retArray">��������</param>
        /// <param name="slipPrtSetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓`�[����ݒ�LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22027�@���{�@����</br>
        /// <br>Date       : 2005.08.30</br>
        /// <br></br>
        /// <br>Update Note: 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.19</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// <br>Update Note: 2011/02/16  ���N�n��</br>
        /// <br>             ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        private int SearchProc(out ArrayList retArray, SlipPrtSetWork slipPrtSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			try
			{
				SqlDataReader myReader = null;
				retArray = null;

				ArrayList al = new ArrayList();
				try 
				{
                    string sqlTxt = string.Empty;  // 2008.05.23 add

					SqlCommand sqlCommand;

					//�f�[�^�Ǎ�
					if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
						(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						(logicalMode == ConstantManagement.LogicalMode.GetData2)||
						(logicalMode == ConstantManagement.LogicalMode.GetData3))
					{
                        // 2008.05.23 upd start ---------------------------------------------------->>
						//sqlCommand = new SqlCommand("SELECT * FROM SLIPPRTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY DATAINPUTSYSTEMRF,SLIPPRTKINDRF,SLIPPRTSETPAPERIDRF  ",sqlConnection);
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPCOMMENTRF" + Environment.NewLine;
                        sqlTxt += "    ,OUTPUTPGIDRF" + Environment.NewLine;
                        sqlTxt += "    ,OUTPUTPGCLASSIDRF" + Environment.NewLine;
                        sqlTxt += "    ,OUTPUTFORMFILENAMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISENAMEPRTCDRF" + Environment.NewLine;
                        sqlTxt += "    ,PRTCIRCULATIONRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPFORMCDRF" + Environment.NewLine;
                        sqlTxt += "    ,OUTCONFIMATIONMSGRF" + Environment.NewLine;
                        sqlTxt += "    ,OPTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,TOPMARGINRF" + Environment.NewLine;
                        sqlTxt += "    ,LEFTMARGINRF" + Environment.NewLine;
                        sqlTxt += "    ,RIGHTMARGINRF" + Environment.NewLine;
                        sqlTxt += "    ,BOTTOMMARGINRF" + Environment.NewLine;
                        sqlTxt += "    ,PRTPREVIEWEXISTCODERF" + Environment.NewLine;
                        sqlTxt += "    ,OUTPUTPURPOSERF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID1RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM1RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT1RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID2RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM2RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT2RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID3RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM3RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT3RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID4RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM4RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT4RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID5RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM5RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT5RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID6RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM6RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT6RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID7RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM7RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT7RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID8RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM8RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT8RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID9RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM9RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT9RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID10RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM10RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT10RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPFONTNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPFONTSIZERF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPFONTSTYLERF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORRED1RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORGRN1RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORBLU1RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORRED2RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORGRN2RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORBLU2RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORRED3RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORGRN3RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORBLU3RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORRED4RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORGRN4RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORBLU4RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORRED5RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORGRN5RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORBLU5RF" + Environment.NewLine;
                        sqlTxt += "    ,COPYCOUNTRF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME1RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME2RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME3RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME4RF" + Environment.NewLine;
                        sqlTxt += "    ,SPECIALPURPOSE1RF" + Environment.NewLine;
                        sqlTxt += "    ,SPECIALPURPOSE2RF" + Environment.NewLine;
                        sqlTxt += "    ,SPECIALPURPOSE3RF" + Environment.NewLine;
                        sqlTxt += "    ,SPECIALPURPOSE4RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME102RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME103RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME104RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME105RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME202RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME203RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME204RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME205RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME302RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME303RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME304RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME305RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME402RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME403RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME404RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME405RF" + Environment.NewLine;
                        sqlTxt += "    ,NOTE1RF" + Environment.NewLine;
                        sqlTxt += "    ,NOTE2RF" + Environment.NewLine;
                        sqlTxt += "    ,NOTE3RF" + Environment.NewLine;
                        sqlTxt += "    ,QRCODEPRINTDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,TIMEPRINTDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,REISSUEMARKRF" + Environment.NewLine;
                        sqlTxt += "    ,REFCONSTAXDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,REFCONSTAXPRTNMRF" + Environment.NewLine;
                        sqlTxt += "    ,DETAILROWCOUNTRF" + Environment.NewLine;
                        sqlTxt += "    ,HONORIFICTITLERF" + Environment.NewLine;
                        sqlTxt += "    ,CONSTAXPRTCDRF" + Environment.NewLine; // ADD 2008.12.11
                        // --- ADD 2009/12/31 ---------->>>>>
                        sqlTxt += "    ,SLIPNOTECHARCNTRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPNOTE2CHARCNTRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPNOTE3CHARCNTRF" + Environment.NewLine;
                        // --- ADD 2009/12/31 ----------<<<<<
                        sqlTxt += "    ,ENTNMPRTEXPDIVRF" + Environment.NewLine; // ADD 2011/02/16
                        // --- ADD 2011/07/19 ---------->>>>>
                        sqlTxt += "    ,SCMANSMARKPRTDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,NORMALPRTMARKRF" + Environment.NewLine;
                        sqlTxt += "    ,SCMMANUALANSMARKRF" + Environment.NewLine;
                        sqlTxt += "    ,SCMAUTOANSMARKRF" + Environment.NewLine;
                        // --- ADD 2011/07/19 ----------<<<<<
                        sqlTxt += " FROM SLIPPRTSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY DATAINPUTSYSTEMRF,SLIPPRTKINDRF,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.23 upd end ------------------------------------------------------<<
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					}
					else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
						(logicalMode == ConstantManagement.LogicalMode.GetData012))
					{
                        // 2008.05.23 upd start ----------------------------------------------------->>
						//sqlCommand = new SqlCommand("SELECT * FROM SLIPPRTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY DATAINPUTSYSTEMRF,SLIPPRTKINDRF,SLIPPRTSETPAPERIDRF ",sqlConnection);
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPCOMMENTRF" + Environment.NewLine;
                        sqlTxt += "    ,OUTPUTPGIDRF" + Environment.NewLine;
                        sqlTxt += "    ,OUTPUTPGCLASSIDRF" + Environment.NewLine;
                        sqlTxt += "    ,OUTPUTFORMFILENAMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISENAMEPRTCDRF" + Environment.NewLine;
                        sqlTxt += "    ,PRTCIRCULATIONRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPFORMCDRF" + Environment.NewLine;
                        sqlTxt += "    ,OUTCONFIMATIONMSGRF" + Environment.NewLine;
                        sqlTxt += "    ,OPTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,TOPMARGINRF" + Environment.NewLine;
                        sqlTxt += "    ,LEFTMARGINRF" + Environment.NewLine;
                        sqlTxt += "    ,RIGHTMARGINRF" + Environment.NewLine;
                        sqlTxt += "    ,BOTTOMMARGINRF" + Environment.NewLine;
                        sqlTxt += "    ,PRTPREVIEWEXISTCODERF" + Environment.NewLine;
                        sqlTxt += "    ,OUTPUTPURPOSERF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID1RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM1RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT1RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID2RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM2RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT2RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID3RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM3RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT3RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID4RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM4RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT4RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID5RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM5RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT5RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID6RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM6RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT6RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID7RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM7RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT7RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID8RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM8RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT8RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID9RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM9RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT9RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID10RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM10RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT10RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPFONTNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPFONTSIZERF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPFONTSTYLERF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORRED1RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORGRN1RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORBLU1RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORRED2RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORGRN2RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORBLU2RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORRED3RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORGRN3RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORBLU3RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORRED4RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORGRN4RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORBLU4RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORRED5RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORGRN5RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORBLU5RF" + Environment.NewLine;
                        sqlTxt += "    ,COPYCOUNTRF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME1RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME2RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME3RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME4RF" + Environment.NewLine;
                        sqlTxt += "    ,SPECIALPURPOSE1RF" + Environment.NewLine;
                        sqlTxt += "    ,SPECIALPURPOSE2RF" + Environment.NewLine;
                        sqlTxt += "    ,SPECIALPURPOSE3RF" + Environment.NewLine;
                        sqlTxt += "    ,SPECIALPURPOSE4RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME102RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME103RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME104RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME105RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME202RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME203RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME204RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME205RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME302RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME303RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME304RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME305RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME402RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME403RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME404RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME405RF" + Environment.NewLine;
                        sqlTxt += "    ,NOTE1RF" + Environment.NewLine;
                        sqlTxt += "    ,NOTE2RF" + Environment.NewLine;
                        sqlTxt += "    ,NOTE3RF" + Environment.NewLine;
                        sqlTxt += "    ,QRCODEPRINTDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,TIMEPRINTDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,REISSUEMARKRF" + Environment.NewLine;
                        sqlTxt += "    ,REFCONSTAXDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,REFCONSTAXPRTNMRF" + Environment.NewLine;
                        sqlTxt += "    ,DETAILROWCOUNTRF" + Environment.NewLine;
                        sqlTxt += "    ,HONORIFICTITLERF" + Environment.NewLine;
                        sqlTxt += "    ,CONSTAXPRTCDRF" + Environment.NewLine; // ADD 2008.12.11
                        // --- ADD 2009/12/31 ---------->>>>>
                        sqlTxt += "    ,SLIPNOTECHARCNTRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPNOTE2CHARCNTRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPNOTE3CHARCNTRF" + Environment.NewLine;
                        // --- ADD 2009/12/31 ----------<<<<<
                        sqlTxt += "    ,ENTNMPRTEXPDIVRF" + Environment.NewLine; // ADD 2011/02/16
                        // --- ADD 2011/07/19 ---------->>>>>
                        sqlTxt += "    ,SCMANSMARKPRTDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,NORMALPRTMARKRF" + Environment.NewLine;
                        sqlTxt += "    ,SCMMANUALANSMARKRF" + Environment.NewLine;
                        sqlTxt += "    ,SCMAUTOANSMARKRF" + Environment.NewLine;
                        // --- ADD 2011/07/19 ----------<<<<<
                        sqlTxt += " FROM SLIPPRTSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY DATAINPUTSYSTEMRF,SLIPPRTKINDRF,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.23 upd end -------------------------------------------------------<<
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					}
					else
					{
                        // 2008.05.23 upd start ------------------------------------------------------>>
						//sqlCommand = new SqlCommand("SELECT * FROM SLIPPRTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY DATAINPUTSYSTEMRF,SLIPPRTKINDRF,SLIPPRTSETPAPERIDRF ",sqlConnection);
                        sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPCOMMENTRF" + Environment.NewLine;
                        sqlTxt += "    ,OUTPUTPGIDRF" + Environment.NewLine;
                        sqlTxt += "    ,OUTPUTPGCLASSIDRF" + Environment.NewLine;
                        sqlTxt += "    ,OUTPUTFORMFILENAMERF" + Environment.NewLine;
                        sqlTxt += "    ,ENTERPRISENAMEPRTCDRF" + Environment.NewLine;
                        sqlTxt += "    ,PRTCIRCULATIONRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPFORMCDRF" + Environment.NewLine;
                        sqlTxt += "    ,OUTCONFIMATIONMSGRF" + Environment.NewLine;
                        sqlTxt += "    ,OPTIONCODERF" + Environment.NewLine;
                        sqlTxt += "    ,TOPMARGINRF" + Environment.NewLine;
                        sqlTxt += "    ,LEFTMARGINRF" + Environment.NewLine;
                        sqlTxt += "    ,RIGHTMARGINRF" + Environment.NewLine;
                        sqlTxt += "    ,BOTTOMMARGINRF" + Environment.NewLine;
                        sqlTxt += "    ,PRTPREVIEWEXISTCODERF" + Environment.NewLine;
                        sqlTxt += "    ,OUTPUTPURPOSERF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID1RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM1RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT1RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID2RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM2RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT2RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID3RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM3RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT3RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID4RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM4RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT4RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID5RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM5RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT5RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID6RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM6RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT6RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID7RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM7RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT7RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID8RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM8RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT8RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID9RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM9RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT9RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLID10RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLNM10RF" + Environment.NewLine;
                        sqlTxt += "    ,EACHSLIPTYPECOLPRT10RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPFONTNAMERF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPFONTSIZERF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPFONTSTYLERF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORRED1RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORGRN1RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORBLU1RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORRED2RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORGRN2RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORBLU2RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORRED3RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORGRN3RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORBLU3RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORRED4RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORGRN4RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORBLU4RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORRED5RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORGRN5RF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPBASECOLORBLU5RF" + Environment.NewLine;
                        sqlTxt += "    ,COPYCOUNTRF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME1RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME2RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME3RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME4RF" + Environment.NewLine;
                        sqlTxt += "    ,SPECIALPURPOSE1RF" + Environment.NewLine;
                        sqlTxt += "    ,SPECIALPURPOSE2RF" + Environment.NewLine;
                        sqlTxt += "    ,SPECIALPURPOSE3RF" + Environment.NewLine;
                        sqlTxt += "    ,SPECIALPURPOSE4RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME102RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME103RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME104RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME105RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME202RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME203RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME204RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME205RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME302RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME303RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME304RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME305RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME402RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME403RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME404RF" + Environment.NewLine;
                        sqlTxt += "    ,TITLENAME405RF" + Environment.NewLine;
                        sqlTxt += "    ,NOTE1RF" + Environment.NewLine;
                        sqlTxt += "    ,NOTE2RF" + Environment.NewLine;
                        sqlTxt += "    ,NOTE3RF" + Environment.NewLine;
                        sqlTxt += "    ,QRCODEPRINTDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,TIMEPRINTDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,REISSUEMARKRF" + Environment.NewLine;
                        sqlTxt += "    ,REFCONSTAXDIVCDRF" + Environment.NewLine;
                        sqlTxt += "    ,REFCONSTAXPRTNMRF" + Environment.NewLine;
                        sqlTxt += "    ,DETAILROWCOUNTRF" + Environment.NewLine;
                        sqlTxt += "    ,HONORIFICTITLERF" + Environment.NewLine;
                        sqlTxt += "    ,CONSTAXPRTCDRF" + Environment.NewLine; // ADD 2008.12.11
                        // --- ADD 2009/12/31 ---------->>>>>
                        sqlTxt += "    ,SLIPNOTECHARCNTRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPNOTE2CHARCNTRF" + Environment.NewLine;
                        sqlTxt += "    ,SLIPNOTE3CHARCNTRF" + Environment.NewLine;
                        // --- ADD 2009/12/31 ----------<<<<<
                        sqlTxt += "    ,ENTNMPRTEXPDIVRF" + Environment.NewLine; // ADD 2011/02/16
                        // --- ADD 2011/07/19 ---------->>>>>
                        sqlTxt += "    ,SCMANSMARKPRTDIVRF" + Environment.NewLine;
                        sqlTxt += "    ,NORMALPRTMARKRF" + Environment.NewLine;
                        sqlTxt += "    ,SCMMANUALANSMARKRF" + Environment.NewLine;
                        sqlTxt += "    ,SCMAUTOANSMARKRF" + Environment.NewLine;
                        // --- ADD 2011/07/19 ----------<<<<<
                        sqlTxt += " FROM SLIPPRTSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " ORDER BY DATAINPUTSYSTEMRF,SLIPPRTKINDRF,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                        // 2008.05.23 upd end --------------------------------------------------------<<
                    }
					SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EnterpriseCode);

					myReader = sqlCommand.ExecuteReader();
					while(myReader.Read())
					{
						SlipPrtSetWork wkSlipPrtSetWork = new SlipPrtSetWork();

                        wkSlipPrtSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkSlipPrtSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkSlipPrtSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        wkSlipPrtSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        wkSlipPrtSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        wkSlipPrtSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        wkSlipPrtSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        wkSlipPrtSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        wkSlipPrtSetWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
                        wkSlipPrtSetWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRTKINDRF"));
                        wkSlipPrtSetWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
                        wkSlipPrtSetWork.SlipComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPCOMMENTRF"));
                        wkSlipPrtSetWork.OutputPgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGIDRF"));
                        wkSlipPrtSetWork.OutputPgClassId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGCLASSIDRF"));
                        wkSlipPrtSetWork.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                        wkSlipPrtSetWork.EnterpriseNamePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISENAMEPRTCDRF"));
                        wkSlipPrtSetWork.PrtCirculation = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTCIRCULATIONRF"));
                        wkSlipPrtSetWork.SlipFormCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPFORMCDRF"));
                        wkSlipPrtSetWork.OutConfimationMsg = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTCONFIMATIONMSGRF"));
                        wkSlipPrtSetWork.OptionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OPTIONCODERF"));
                        //wkSlipPrtSetWork.PrinterMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTERMNGNORF")); // 2008.05.23 del
                        wkSlipPrtSetWork.TopMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOPMARGINRF"));
                        wkSlipPrtSetWork.LeftMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LEFTMARGINRF"));
                        wkSlipPrtSetWork.RightMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RIGHTMARGINRF"));
                        wkSlipPrtSetWork.BottomMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BOTTOMMARGINRF"));
                        wkSlipPrtSetWork.PrtPreviewExistCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTPREVIEWEXISTCODERF"));
                        wkSlipPrtSetWork.OutputPurpose = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTPURPOSERF"));
                        wkSlipPrtSetWork.EachSlipTypeColId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID1RF"));
                        wkSlipPrtSetWork.EachSlipTypeColNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM1RF"));
                        wkSlipPrtSetWork.EachSlipTypeColPrt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT1RF"));
                        wkSlipPrtSetWork.EachSlipTypeColId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID2RF"));
                        wkSlipPrtSetWork.EachSlipTypeColNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM2RF"));
                        wkSlipPrtSetWork.EachSlipTypeColPrt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT2RF"));
                        wkSlipPrtSetWork.EachSlipTypeColId3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID3RF"));
                        wkSlipPrtSetWork.EachSlipTypeColNm3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM3RF"));
                        wkSlipPrtSetWork.EachSlipTypeColPrt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT3RF"));
                        wkSlipPrtSetWork.EachSlipTypeColId4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID4RF"));
                        wkSlipPrtSetWork.EachSlipTypeColNm4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM4RF"));
                        wkSlipPrtSetWork.EachSlipTypeColPrt4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT4RF"));
                        wkSlipPrtSetWork.EachSlipTypeColId5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID5RF"));
                        wkSlipPrtSetWork.EachSlipTypeColNm5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM5RF"));
                        wkSlipPrtSetWork.EachSlipTypeColPrt5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT5RF"));
                        wkSlipPrtSetWork.EachSlipTypeColId6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID6RF"));
                        wkSlipPrtSetWork.EachSlipTypeColNm6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM6RF"));
                        wkSlipPrtSetWork.EachSlipTypeColPrt6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT6RF"));
                        wkSlipPrtSetWork.EachSlipTypeColId7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID7RF"));
                        wkSlipPrtSetWork.EachSlipTypeColNm7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM7RF"));
                        wkSlipPrtSetWork.EachSlipTypeColPrt7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT7RF"));
                        wkSlipPrtSetWork.EachSlipTypeColId8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID8RF"));
                        wkSlipPrtSetWork.EachSlipTypeColNm8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM8RF"));
                        wkSlipPrtSetWork.EachSlipTypeColPrt8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT8RF"));
                        wkSlipPrtSetWork.EachSlipTypeColId9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID9RF"));
                        wkSlipPrtSetWork.EachSlipTypeColNm9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM9RF"));
                        wkSlipPrtSetWork.EachSlipTypeColPrt9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT9RF"));
                        wkSlipPrtSetWork.EachSlipTypeColId10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID10RF"));
                        wkSlipPrtSetWork.EachSlipTypeColNm10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM10RF"));
                        wkSlipPrtSetWork.EachSlipTypeColPrt10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT10RF"));
                        wkSlipPrtSetWork.SlipFontName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPFONTNAMERF"));
                        wkSlipPrtSetWork.SlipFontSize = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPFONTSIZERF"));
                        wkSlipPrtSetWork.SlipFontStyle = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPFONTSTYLERF"));
                        wkSlipPrtSetWork.SlipBaseColorRed1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED1RF"));
                        wkSlipPrtSetWork.SlipBaseColorGrn1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN1RF"));
                        wkSlipPrtSetWork.SlipBaseColorBlu1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU1RF"));
                        wkSlipPrtSetWork.SlipBaseColorRed2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED2RF"));
                        wkSlipPrtSetWork.SlipBaseColorGrn2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN2RF"));
                        wkSlipPrtSetWork.SlipBaseColorBlu2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU2RF"));
                        wkSlipPrtSetWork.SlipBaseColorRed3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED3RF"));
                        wkSlipPrtSetWork.SlipBaseColorGrn3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN3RF"));
                        wkSlipPrtSetWork.SlipBaseColorBlu3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU3RF"));
                        wkSlipPrtSetWork.SlipBaseColorRed4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED4RF"));
                        wkSlipPrtSetWork.SlipBaseColorGrn4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN4RF"));
                        wkSlipPrtSetWork.SlipBaseColorBlu4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU4RF"));
                        wkSlipPrtSetWork.SlipBaseColorRed5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED5RF"));
                        wkSlipPrtSetWork.SlipBaseColorGrn5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN5RF"));
                        wkSlipPrtSetWork.SlipBaseColorBlu5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU5RF"));
                        wkSlipPrtSetWork.CopyCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COPYCOUNTRF"));
                        wkSlipPrtSetWork.TitleName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME1RF"));
                        wkSlipPrtSetWork.TitleName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME2RF"));
                        wkSlipPrtSetWork.TitleName3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME3RF"));
                        wkSlipPrtSetWork.TitleName4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME4RF"));
                        wkSlipPrtSetWork.SpecialPurpose1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE1RF"));
                        wkSlipPrtSetWork.SpecialPurpose2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE2RF"));
                        wkSlipPrtSetWork.SpecialPurpose3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE3RF"));
                        wkSlipPrtSetWork.SpecialPurpose4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE4RF"));
                        //2006.12.06 deleted by T-Kidate
                        //wkSlipPrtSetWork.BarCodeCarMngNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BARCODECARMNGNOPRTCDRF"));
                        wkSlipPrtSetWork.TitleName102 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME102RF"));
                        wkSlipPrtSetWork.TitleName103 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME103RF"));
                        wkSlipPrtSetWork.TitleName104 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME104RF"));
                        wkSlipPrtSetWork.TitleName105 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME105RF"));
                        wkSlipPrtSetWork.TitleName202 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME202RF"));
                        wkSlipPrtSetWork.TitleName203 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME203RF"));
                        wkSlipPrtSetWork.TitleName204 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME204RF"));
                        wkSlipPrtSetWork.TitleName205 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME205RF"));
                        wkSlipPrtSetWork.TitleName302 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME302RF"));
                        wkSlipPrtSetWork.TitleName303 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME303RF"));
                        wkSlipPrtSetWork.TitleName304 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME304RF"));
                        wkSlipPrtSetWork.TitleName305 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME305RF"));
                        wkSlipPrtSetWork.TitleName402 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME402RF"));
                        wkSlipPrtSetWork.TitleName403 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME403RF"));
                        wkSlipPrtSetWork.TitleName404 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME404RF"));
                        wkSlipPrtSetWork.TitleName405 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME405RF"));
                        // 2008.05.23 add start ------------------------------------------>>
                        wkSlipPrtSetWork.Note1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
                        wkSlipPrtSetWork.Note2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
                        wkSlipPrtSetWork.Note3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
                        wkSlipPrtSetWork.QRCodePrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("QRCODEPRINTDIVCDRF"));
                        wkSlipPrtSetWork.TimePrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TIMEPRINTDIVCDRF"));
                        wkSlipPrtSetWork.ReissueMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REISSUEMARKRF"));
                        wkSlipPrtSetWork.RefConsTaxDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REFCONSTAXDIVCDRF"));
                        wkSlipPrtSetWork.RefConsTaxPrtNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REFCONSTAXPRTNMRF"));
                        wkSlipPrtSetWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
                        wkSlipPrtSetWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                        wkSlipPrtSetWork.ConsTaxPrtCdRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXPRTCDRF"));// ADD 2008.12.11
                        // --- ADD 2009/12/31 ---------->>>>>
                        wkSlipPrtSetWork.SlipNoteCharCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPNOTECHARCNTRF"));
                        wkSlipPrtSetWork.SlipNote2CharCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPNOTE2CHARCNTRF"));
                        wkSlipPrtSetWork.SlipNote3CharCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPNOTE3CHARCNTRF"));
                        // --- ADD 2009/12/31 ----------<<<<<
                        // 2008.05.23 add end --------------------------------------------<<
                        wkSlipPrtSetWork.EntNmPrtExpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTNMPRTEXPDIVRF"));// ADD 2011/02/16

                        // --- ADD 2011/07/19 ---------->>>>>
                        wkSlipPrtSetWork.SCMAnsMarkPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SCMANSMARKPRTDIVRF"));
                        wkSlipPrtSetWork.NormalPrtMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NORMALPRTMARKRF"));
                        wkSlipPrtSetWork.SCMManualAnsMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SCMMANUALANSMARKRF"));
                        wkSlipPrtSetWork.SCMAutoAnsMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SCMAUTOANSMARKRF"));
                        // --- ADD 2011/07/19 ----------<<<<<

                        //2006.12.06 deleted by T-Kidate
                        //wkSlipPrtSetWork.MainWorkLinePrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINWORKLINEPRTDIVCDRF"));

                        // �� 2007.12.19 980081 d
                        ////2006.12.06 added by T-Kidate
                        //wkSlipPrtSetWork.ContractNoPrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONTRACTNOPRTDIVCDRF"));
                        //wkSlipPrtSetWork.ContCpNoPrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONTCPNOPRTDIVCDRF"));
                        // �� 2007.12.19 980081 d
                        al.Add(wkSlipPrtSetWork);

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
				catch (SqlException ex) 
				{
					//���N���X�ɗ�O��n���ď������Ă��炤
					status = base.WriteSQLErrorLog(ex);
				}

				if(!myReader.IsClosed)myReader.Close();

				retArray = al;
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "SlipPrtSetDB.Search(out ArrayList retArray,SlipPrtSetWork slipPrtSetWork, int readMode,ConstantManagement.LogicalMode logicalMode , ref SqlConnection sqlConnection)");
				retArray = new ArrayList();
			}

			return status;
		}
		#endregion

		#region Read

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓`�[����ݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">SlipPrtSetWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓`�[����ݒ��߂��܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.08.30</br>
        /// <br></br>
        /// <br>Update Note: 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.19</br>
        /// <br>           : ���ʊ�Ή�</br>
        public int Read(ref byte[] parabyte, int readMode)
		{
            return this.ReadProc(ref parabyte, readMode);
        }
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̓`�[����ݒ��߂��܂�
        /// </summary>
        /// <param name="parabyte">SlipPrtSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓`�[����ݒ��߂��܂�</br>
        /// <br>Programmer : 22027�@���{�@����</br>
        /// <br>Date       : 2005.08.30</br>
        /// <br></br>
        /// <br>Update Note: 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.19</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// <br>Update Note: 2011/02/16  ���N�n��</br>
        /// <br>             ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        private int ReadProc(ref byte[] parabyte, int readMode) 
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			try
			{
				SqlConnection sqlConnection = null;
				SqlDataReader myReader = null;

				SlipPrtSetWork  slipPrtSetWork = new SlipPrtSetWork();

				try 
				{			
					//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
					SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
					string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
					if (connectionText == null || connectionText == "") return status;

					// XML�̓ǂݍ���
					slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SlipPrtSetWork));

					sqlConnection = new SqlConnection(connectionText);
					sqlConnection.Open();

					//Select�R�}���h�̐���
                    // 2008.05.23 upd start -------------------------------------------->>
					//using(SqlCommand sqlCommand = new SqlCommand("SELECT * FROM SLIPPRTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID ", sqlConnection))
                    string sqlTxt = string.Empty;
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPCOMMENTRF" + Environment.NewLine;
                    sqlTxt += "    ,OUTPUTPGIDRF" + Environment.NewLine;
                    sqlTxt += "    ,OUTPUTPGCLASSIDRF" + Environment.NewLine;
                    sqlTxt += "    ,OUTPUTFORMFILENAMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISENAMEPRTCDRF" + Environment.NewLine;
                    sqlTxt += "    ,PRTCIRCULATIONRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPFORMCDRF" + Environment.NewLine;
                    sqlTxt += "    ,OUTCONFIMATIONMSGRF" + Environment.NewLine;
                    sqlTxt += "    ,OPTIONCODERF" + Environment.NewLine;
                    sqlTxt += "    ,TOPMARGINRF" + Environment.NewLine;
                    sqlTxt += "    ,LEFTMARGINRF" + Environment.NewLine;
                    sqlTxt += "    ,RIGHTMARGINRF" + Environment.NewLine;
                    sqlTxt += "    ,BOTTOMMARGINRF" + Environment.NewLine;
                    sqlTxt += "    ,PRTPREVIEWEXISTCODERF" + Environment.NewLine;
                    sqlTxt += "    ,OUTPUTPURPOSERF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID1RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM1RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT1RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID2RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM2RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT2RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID3RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM3RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT3RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID4RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM4RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT4RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID5RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM5RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT5RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID6RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM6RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT6RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID7RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM7RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT7RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID8RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM8RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT8RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID9RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM9RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT9RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLID10RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLNM10RF" + Environment.NewLine;
                    sqlTxt += "    ,EACHSLIPTYPECOLPRT10RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPFONTNAMERF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPFONTSIZERF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPFONTSTYLERF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED1RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN1RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU1RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED2RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN2RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU2RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED3RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN3RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU3RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED4RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN4RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU4RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORRED5RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORGRN5RF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPBASECOLORBLU5RF" + Environment.NewLine;
                    sqlTxt += "    ,COPYCOUNTRF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME1RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME2RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME3RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME4RF" + Environment.NewLine;
                    sqlTxt += "    ,SPECIALPURPOSE1RF" + Environment.NewLine;
                    sqlTxt += "    ,SPECIALPURPOSE2RF" + Environment.NewLine;
                    sqlTxt += "    ,SPECIALPURPOSE3RF" + Environment.NewLine;
                    sqlTxt += "    ,SPECIALPURPOSE4RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME102RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME103RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME104RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME105RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME202RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME203RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME204RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME205RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME302RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME303RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME304RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME305RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME402RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME403RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME404RF" + Environment.NewLine;
                    sqlTxt += "    ,TITLENAME405RF" + Environment.NewLine;
                    sqlTxt += "    ,NOTE1RF" + Environment.NewLine;
                    sqlTxt += "    ,NOTE2RF" + Environment.NewLine;
                    sqlTxt += "    ,NOTE3RF" + Environment.NewLine;
                    sqlTxt += "    ,QRCODEPRINTDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,TIMEPRINTDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,REISSUEMARKRF" + Environment.NewLine;
                    sqlTxt += "    ,REFCONSTAXDIVCDRF" + Environment.NewLine;
                    sqlTxt += "    ,REFCONSTAXPRTNMRF" + Environment.NewLine;
                    sqlTxt += "    ,DETAILROWCOUNTRF" + Environment.NewLine;
                    sqlTxt += "    ,HONORIFICTITLERF" + Environment.NewLine;
                    sqlTxt += "    ,CONSTAXPRTCDRF" + Environment.NewLine; // ADD 2008.12.11
                    // --- ADD 2009/12/31 ---------->>>>>
                    sqlTxt += "    ,SLIPNOTECHARCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPNOTE2CHARCNTRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPNOTE3CHARCNTRF" + Environment.NewLine;
                    // --- ADD 2009/12/31 ----------<<<<<
                    sqlTxt += "    ,ENTNMPRTEXPDIVRF" + Environment.NewLine; // ADD 2011/02/16
                    // --- ADD 2011/07/19 ---------->>>>>
                    sqlTxt += "    ,SCMANSMARKPRTDIVRF" + Environment.NewLine;
                    sqlTxt += "    ,NORMALPRTMARKRF" + Environment.NewLine;
                    sqlTxt += "    ,SCMMANUALANSMARKRF" + Environment.NewLine;
                    sqlTxt += "    ,SCMAUTOANSMARKRF" + Environment.NewLine;
                    // --- ADD 2011/07/19 ----------<<<<<
                    sqlTxt += " FROM SLIPPRTSETRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                    sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                    sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                    using(SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                    // 2008.05.23 upd end ----------------------------------------------<<
                    {
						//Prameter�I�u�W�F�N�g�̍쐬
						SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
						SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
						SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
						SqlParameter findParaSlipPrtSetPaperId = sqlCommand.Parameters.Add("@FINDSLIPPRTSETPAPERID", SqlDbType.NVarChar);

						//Parameter�I�u�W�F�N�g�֒l�ݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EnterpriseCode);
						findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.DataInputSystem);
						findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipPrtKind);
						findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipPrtSetPaperId);

						myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
						if(myReader.Read())
						{
                            slipPrtSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                            slipPrtSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                            slipPrtSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                            slipPrtSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                            slipPrtSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                            slipPrtSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                            slipPrtSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                            slipPrtSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                            slipPrtSetWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
                            slipPrtSetWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRTKINDRF"));
                            slipPrtSetWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
                            slipPrtSetWork.SlipComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPCOMMENTRF"));
                            slipPrtSetWork.OutputPgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGIDRF"));
                            slipPrtSetWork.OutputPgClassId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGCLASSIDRF"));
                            slipPrtSetWork.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                            slipPrtSetWork.EnterpriseNamePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISENAMEPRTCDRF"));
                            slipPrtSetWork.PrtCirculation = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTCIRCULATIONRF"));
                            slipPrtSetWork.SlipFormCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPFORMCDRF"));
                            slipPrtSetWork.OutConfimationMsg = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTCONFIMATIONMSGRF"));
                            slipPrtSetWork.OptionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OPTIONCODERF"));
                            //slipPrtSetWork.PrinterMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTERMNGNORF"));
                            slipPrtSetWork.TopMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOPMARGINRF"));
                            slipPrtSetWork.LeftMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LEFTMARGINRF"));
                            slipPrtSetWork.RightMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RIGHTMARGINRF"));
                            slipPrtSetWork.BottomMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BOTTOMMARGINRF"));
                            slipPrtSetWork.PrtPreviewExistCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTPREVIEWEXISTCODERF"));
                            slipPrtSetWork.OutputPurpose = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTPURPOSERF"));
                            slipPrtSetWork.EachSlipTypeColId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID1RF"));
                            slipPrtSetWork.EachSlipTypeColNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM1RF"));
                            slipPrtSetWork.EachSlipTypeColPrt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT1RF"));
                            slipPrtSetWork.EachSlipTypeColId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID2RF"));
                            slipPrtSetWork.EachSlipTypeColNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM2RF"));
                            slipPrtSetWork.EachSlipTypeColPrt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT2RF"));
                            slipPrtSetWork.EachSlipTypeColId3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID3RF"));
                            slipPrtSetWork.EachSlipTypeColNm3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM3RF"));
                            slipPrtSetWork.EachSlipTypeColPrt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT3RF"));
                            slipPrtSetWork.EachSlipTypeColId4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID4RF"));
                            slipPrtSetWork.EachSlipTypeColNm4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM4RF"));
                            slipPrtSetWork.EachSlipTypeColPrt4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT4RF"));
                            slipPrtSetWork.EachSlipTypeColId5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID5RF"));
                            slipPrtSetWork.EachSlipTypeColNm5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM5RF"));
                            slipPrtSetWork.EachSlipTypeColPrt5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT5RF"));
                            slipPrtSetWork.EachSlipTypeColId6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID6RF"));
                            slipPrtSetWork.EachSlipTypeColNm6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM6RF"));
                            slipPrtSetWork.EachSlipTypeColPrt6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT6RF"));
                            slipPrtSetWork.EachSlipTypeColId7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID7RF"));
                            slipPrtSetWork.EachSlipTypeColNm7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM7RF"));
                            slipPrtSetWork.EachSlipTypeColPrt7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT7RF"));
                            slipPrtSetWork.EachSlipTypeColId8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID8RF"));
                            slipPrtSetWork.EachSlipTypeColNm8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM8RF"));
                            slipPrtSetWork.EachSlipTypeColPrt8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT8RF"));
                            slipPrtSetWork.EachSlipTypeColId9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID9RF"));
                            slipPrtSetWork.EachSlipTypeColNm9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM9RF"));
                            slipPrtSetWork.EachSlipTypeColPrt9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT9RF"));
                            slipPrtSetWork.EachSlipTypeColId10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID10RF"));
                            slipPrtSetWork.EachSlipTypeColNm10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM10RF"));
                            slipPrtSetWork.EachSlipTypeColPrt10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT10RF"));
                            slipPrtSetWork.SlipFontName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPFONTNAMERF"));
                            slipPrtSetWork.SlipFontSize = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPFONTSIZERF"));
                            slipPrtSetWork.SlipFontStyle = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPFONTSTYLERF"));
                            slipPrtSetWork.SlipBaseColorRed1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED1RF"));
                            slipPrtSetWork.SlipBaseColorGrn1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN1RF"));
                            slipPrtSetWork.SlipBaseColorBlu1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU1RF"));
                            slipPrtSetWork.SlipBaseColorRed2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED2RF"));
                            slipPrtSetWork.SlipBaseColorGrn2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN2RF"));
                            slipPrtSetWork.SlipBaseColorBlu2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU2RF"));
                            slipPrtSetWork.SlipBaseColorRed3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED3RF"));
                            slipPrtSetWork.SlipBaseColorGrn3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN3RF"));
                            slipPrtSetWork.SlipBaseColorBlu3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU3RF"));
                            slipPrtSetWork.SlipBaseColorRed4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED4RF"));
                            slipPrtSetWork.SlipBaseColorGrn4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN4RF"));
                            slipPrtSetWork.SlipBaseColorBlu4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU4RF"));
                            slipPrtSetWork.SlipBaseColorRed5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED5RF"));
                            slipPrtSetWork.SlipBaseColorGrn5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN5RF"));
                            slipPrtSetWork.SlipBaseColorBlu5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU5RF"));
                            slipPrtSetWork.CopyCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COPYCOUNTRF"));
                            slipPrtSetWork.TitleName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME1RF"));
                            slipPrtSetWork.TitleName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME2RF"));
                            slipPrtSetWork.TitleName3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME3RF"));
                            slipPrtSetWork.TitleName4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME4RF"));
                            slipPrtSetWork.SpecialPurpose1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE1RF"));
                            slipPrtSetWork.SpecialPurpose2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE2RF"));
                            slipPrtSetWork.SpecialPurpose3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE3RF"));
                            slipPrtSetWork.SpecialPurpose4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE4RF"));
                            //2006.12.06 deleted by T-Kidate
                            //slipPrtSetWork.BarCodeCarMngNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BARCODECARMNGNOPRTCDRF"));
                            slipPrtSetWork.TitleName102 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME102RF"));
                            slipPrtSetWork.TitleName103 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME103RF"));
                            slipPrtSetWork.TitleName104 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME104RF"));
                            slipPrtSetWork.TitleName105 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME105RF"));
                            slipPrtSetWork.TitleName202 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME202RF"));
                            slipPrtSetWork.TitleName203 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME203RF"));
                            slipPrtSetWork.TitleName204 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME204RF"));
                            slipPrtSetWork.TitleName205 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME205RF"));
                            slipPrtSetWork.TitleName302 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME302RF"));
                            slipPrtSetWork.TitleName303 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME303RF"));
                            slipPrtSetWork.TitleName304 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME304RF"));
                            slipPrtSetWork.TitleName305 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME305RF"));
                            slipPrtSetWork.TitleName402 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME402RF"));
                            slipPrtSetWork.TitleName403 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME403RF"));
                            slipPrtSetWork.TitleName404 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME404RF"));
                            slipPrtSetWork.TitleName405 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME405RF"));
                            // 2008.05.23 add start ------------------------------------------------>>
                            slipPrtSetWork.Note1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
                            slipPrtSetWork.Note2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
                            slipPrtSetWork.Note3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
                            slipPrtSetWork.QRCodePrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("QRCODEPRINTDIVCDRF"));
                            slipPrtSetWork.TimePrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TIMEPRINTDIVCDRF"));
                            slipPrtSetWork.ReissueMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REISSUEMARKRF"));
                            slipPrtSetWork.RefConsTaxDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REFCONSTAXDIVCDRF"));
                            slipPrtSetWork.RefConsTaxPrtNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REFCONSTAXPRTNMRF"));
                            slipPrtSetWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
                            slipPrtSetWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                            slipPrtSetWork.ConsTaxPrtCdRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXPRTCDRF"));// ADD 2008.12.11
                            // --- ADD 2009/12/31 ---------->>>>>
                            slipPrtSetWork.SlipNoteCharCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPNOTECHARCNTRF"));
                            slipPrtSetWork.SlipNote2CharCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPNOTE2CHARCNTRF"));
                            slipPrtSetWork.SlipNote3CharCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPNOTE3CHARCNTRF"));
                            // --- ADD 2009/12/31 ----------<<<<<
                            // 2008.05.23 add end --------------------------------------------------<<
                            slipPrtSetWork.EntNmPrtExpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTNMPRTEXPDIVRF")); // ADD 2011/02/16
                            // --- ADD 2011/07/19 ---------->>>>>
                            slipPrtSetWork.SCMAnsMarkPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SCMANSMARKPRTDIVRF"));
                            slipPrtSetWork.NormalPrtMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NORMALPRTMARKRF"));
                            slipPrtSetWork.SCMManualAnsMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SCMMANUALANSMARKRF"));
                            slipPrtSetWork.SCMAutoAnsMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SCMAUTOANSMARKRF"));
                            // --- ADD 2011/07/19 ----------<<<<<

                            //2006.12.06 deleted by T-Kidate
                            //slipPrtSetWork.MainWorkLinePrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINWORKLINEPRTDIVCDRF"));

                            // �� 2007.12.19 980081 d
                            ////2006.12.06 added by T-Kidate
                            //slipPrtSetWork.ContractNoPrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONTRACTNOPRTDIVCDRF"));
                            //slipPrtSetWork.ContCpNoPrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONTCPNOPRTDIVCDRF"));
                            // �� 2007.12.19 980081 d

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
				parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "SlipPrtSetDB.Read" );
			}
			return status;
		}

		#endregion

		#region Write

		/// <summary>
		/// �`�[����ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">SlipPrtSetWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �`�[����ݒ����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.08.30</br>
        /// <br></br>
        /// <br>Update Note: 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.19</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// <br>Update Note: caowj</br>
        /// <br>Date       : 2010.08.06</br>
        /// <br>           : PM.NS1012�Ή�</br>
        /// <br>Update Note: �k���r</br>
        /// <br>Date       : 2010.08.17</br>
        /// <br>           : #12932�Ή�</br>
        /// <br>Note	   : redmine 13549�̑Ή�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2010/08/25</br>
        /// <br>Update Note: 2011/02/16  ���N�n��</br>
        /// <br>             ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 DEL
        //public int Write(ref byte[] parabyte)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 ADD
        private int Write(ref byte[] parabyte, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 ADD
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 ADD
            bool execFromParent = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 ADD

			try
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 DEL
                //SqlConnection sqlConnection = null;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 DEL
                SqlDataReader myReader = null;
                try
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 DEL
                    ////���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    //string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                    //if ( connectionText == null || connectionText == "" ) return status;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 ADD
                    // SqlConnection����
                    if (sqlConnection == null)
                    {
                        //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                        SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                        string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                        if (connectionText == null || connectionText == "") return status;

                        sqlConnection = new SqlConnection(connectionText);
                        sqlConnection.Open();

                        execFromParent = false;
                    }
                    else
                    {
                        execFromParent = true;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 ADD

                    // XML�̓ǂݍ���
                    SlipPrtSetWork slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SlipPrtSetWork));

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 DEL
                    //sqlConnection = new SqlConnection(connectionText);
                    //sqlConnection.Open();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 DEL

                    /* 2006.12.06 modified by T-Kidate
					//Select�R�}���h�̐���
					using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SLIPPRTSETPAPERIDRF FROM SLIPPRTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID ", sqlConnection))
					{
						//Prameter�I�u�W�F�N�g�̍쐬
						SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
						SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
						SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
						SqlParameter findParaSlipPrtSetPaperId = sqlCommand.Parameters.Add("@FINDSLIPPRTSETPAPERID", SqlDbType.NVarChar);

						//Parameter�I�u�W�F�N�g�֒l�ݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EnterpriseCode);
						findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.DataInputSystem);
						findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipPrtKind);
						findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipPrtSetPaperId);

                     */

                    //Select�R�}���h�̐���
                    // �� 2007.12.19 980081 c
                    //using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SLIPPRTSETPAPERIDRF FROM SLIPPRTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM ", sqlConnection))
                    // 2008.05.23 upd start --------------------------------->>
                    //using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SLIPPRTSETPAPERIDRF FROM SLIPPRTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID ", sqlConnection))
                    // �� 2007.12.19 980081 c
                    string sqlTxt = string.Empty;
                    sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                    sqlTxt += " FROM SLIPPRTSETRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                    sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                    sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                    using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                    // 2008.05.23 upd end -----------------------------------<<
                    {
                        // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
                        if (sqlTransaction == null)  // ADD 2010/08/25
                        { // ADD 2010/08/25
                            sqlTransaction = sqlConnection.BeginTransaction();
                        } // ADD 2010/08/25
                        // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 ADD
                        if (sqlTransaction != null)
                        {
                            sqlCommand.Transaction = sqlTransaction;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 ADD

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EnterpriseCode);
                        findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.DataInputSystem);
                        // �� 2007.12.19 980081 a
                        SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                        SqlParameter findParaSlipPrtSetPaperId = sqlCommand.Parameters.Add("@FINDSLIPPRTSETPAPERID", SqlDbType.NVarChar);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipPrtKind);
                        findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipPrtSetPaperId);
                        // �� 2007.12.19 980081 a

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != slipPrtSetWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (slipPrtSetWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (!myReader.IsClosed) myReader.Close();
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 DEL
                                //sqlConnection.Close();
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 ADD
                                if (!execFromParent)
                                {
                                    sqlConnection.Close();
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 ADD
                                return status;
                            }

                            /*2006.12.06 modified by T-Kidate
							sqlCommand.CommandText = "UPDATE SLIPPRTSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM , SLIPPRTKINDRF=@SLIPPRTKIND , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID , SLIPCOMMENTRF=@SLIPCOMMENT , OUTPUTPGIDRF=@OUTPUTPGID , OUTPUTPGCLASSIDRF=@OUTPUTPGCLASSID , OUTPUTFORMFILENAMERF=@OUTPUTFORMFILENAME , ENTERPRISENAMEPRTCDRF=@ENTERPRISENAMEPRTCD , PRTCIRCULATIONRF=@PRTCIRCULATION , SLIPFORMCDRF=@SLIPFORMCD , OUTCONFIMATIONMSGRF=@OUTCONFIMATIONMSG , OPTIONCODERF=@OPTIONCODE , PRINTERMNGNORF=@PRINTERMNGNO , TOPMARGINRF=@TOPMARGIN , LEFTMARGINRF=@LEFTMARGIN , RIGHTMARGINRF=@RIGHTMARGIN , BOTTOMMARGINRF=@BOTTOMMARGIN , PRTPREVIEWEXISTCODERF=@PRTPREVIEWEXISTCODE , OUTPUTPURPOSERF=@OUTPUTPURPOSE , EACHSLIPTYPECOLID1RF=@EACHSLIPTYPECOLID1 , EACHSLIPTYPECOLNM1RF=@EACHSLIPTYPECOLNM1 , EACHSLIPTYPECOLPRT1RF=@EACHSLIPTYPECOLPRT1 , EACHSLIPTYPECOLID2RF=@EACHSLIPTYPECOLID2 , EACHSLIPTYPECOLNM2RF=@EACHSLIPTYPECOLNM2 , EACHSLIPTYPECOLPRT2RF=@EACHSLIPTYPECOLPRT2 , EACHSLIPTYPECOLID3RF=@EACHSLIPTYPECOLID3 , EACHSLIPTYPECOLNM3RF=@EACHSLIPTYPECOLNM3 , EACHSLIPTYPECOLPRT3RF=@EACHSLIPTYPECOLPRT3 , EACHSLIPTYPECOLID4RF=@EACHSLIPTYPECOLID4 , EACHSLIPTYPECOLNM4RF=@EACHSLIPTYPECOLNM4 , EACHSLIPTYPECOLPRT4RF=@EACHSLIPTYPECOLPRT4 , EACHSLIPTYPECOLID5RF=@EACHSLIPTYPECOLID5 , EACHSLIPTYPECOLNM5RF=@EACHSLIPTYPECOLNM5 , EACHSLIPTYPECOLPRT5RF=@EACHSLIPTYPECOLPRT5 , EACHSLIPTYPECOLID6RF=@EACHSLIPTYPECOLID6 , EACHSLIPTYPECOLNM6RF=@EACHSLIPTYPECOLNM6 , EACHSLIPTYPECOLPRT6RF=@EACHSLIPTYPECOLPRT6 , EACHSLIPTYPECOLID7RF=@EACHSLIPTYPECOLID7 , EACHSLIPTYPECOLNM7RF=@EACHSLIPTYPECOLNM7 , EACHSLIPTYPECOLPRT7RF=@EACHSLIPTYPECOLPRT7 , EACHSLIPTYPECOLID8RF=@EACHSLIPTYPECOLID8 , EACHSLIPTYPECOLNM8RF=@EACHSLIPTYPECOLNM8 , EACHSLIPTYPECOLPRT8RF=@EACHSLIPTYPECOLPRT8 , EACHSLIPTYPECOLID9RF=@EACHSLIPTYPECOLID9 , " +
								"EACHSLIPTYPECOLNM9RF=@EACHSLIPTYPECOLNM9 , EACHSLIPTYPECOLPRT9RF=@EACHSLIPTYPECOLPRT9 , EACHSLIPTYPECOLID10RF=@EACHSLIPTYPECOLID10 , EACHSLIPTYPECOLNM10RF=@EACHSLIPTYPECOLNM10 , EACHSLIPTYPECOLPRT10RF=@EACHSLIPTYPECOLPRT10 , SLIPFONTNAMERF=@SLIPFONTNAME , SLIPFONTSIZERF=@SLIPFONTSIZE , SLIPFONTSTYLERF=@SLIPFONTSTYLE , SLIPBASECOLORRED1RF=@SLIPBASECOLORRED1 , SLIPBASECOLORGRN1RF=@SLIPBASECOLORGRN1 , SLIPBASECOLORBLU1RF=@SLIPBASECOLORBLU1 , SLIPBASECOLORRED2RF=@SLIPBASECOLORRED2 , SLIPBASECOLORGRN2RF=@SLIPBASECOLORGRN2 , SLIPBASECOLORBLU2RF=@SLIPBASECOLORBLU2 , SLIPBASECOLORRED3RF=@SLIPBASECOLORRED3 , SLIPBASECOLORGRN3RF=@SLIPBASECOLORGRN3 , SLIPBASECOLORBLU3RF=@SLIPBASECOLORBLU3 , SLIPBASECOLORRED4RF=@SLIPBASECOLORRED4 , SLIPBASECOLORGRN4RF=@SLIPBASECOLORGRN4 , SLIPBASECOLORBLU4RF=@SLIPBASECOLORBLU4 , SLIPBASECOLORRED5RF=@SLIPBASECOLORRED5 , SLIPBASECOLORGRN5RF=@SLIPBASECOLORGRN5 , SLIPBASECOLORBLU5RF=@SLIPBASECOLORBLU5 , CUSTTELNOPRTDIVCDRF=@CUSTTELNOPRTDIVCD , COPYCOUNTRF=@COPYCOUNT , TITLENAME1RF=@TITLENAME1 , TITLENAME2RF=@TITLENAME2 , TITLENAME3RF=@TITLENAME3 , TITLENAME4RF=@TITLENAME4 , SPECIALPURPOSE1RF=@SPECIALPURPOSE1 , SPECIALPURPOSE2RF=@SPECIALPURPOSE2 , SPECIALPURPOSE3RF=@SPECIALPURPOSE3 , SPECIALPURPOSE4RF=@SPECIALPURPOSE4 , BARCODEACPODRNOPRTCDRF=@BARCODEACPODRNOPRTCD , BARCODECUSTCODEPRTCDRF=@BARCODECUSTCODEPRTCD , BARCODECARMNGNOPRTCDRF=@BARCODECARMNGNOPRTCD , TITLENAME102RF=@TITLENAME102 , TITLENAME103RF=@TITLENAME103 , TITLENAME104RF=@TITLENAME104 , TITLENAME105RF=@TITLENAME105 , TITLENAME202RF=@TITLENAME202 , TITLENAME203RF=@TITLENAME203 , TITLENAME204RF=@TITLENAME204 , TITLENAME205RF=@TITLENAME205 , TITLENAME302RF=@TITLENAME302 , TITLENAME303RF=@TITLENAME303 , TITLENAME304RF=@TITLENAME304 , TITLENAME305RF=@TITLENAME305 , TITLENAME402RF=@TITLENAME402 , TITLENAME403RF=@TITLENAME403 , TITLENAME404RF=@TITLENAME404 , TITLENAME405RF=@TITLENAME405 , MAINWORKLINEPRTDIVCDRF=@MAINWORKLINEPRTDIVCD " +
								"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID";
                            */
                            // �� 2007.12.19 980081 c
                            //sqlCommand.CommandText = "UPDATE SLIPPRTSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM , SLIPPRTKINDRF=@SLIPPRTKIND , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID , SLIPCOMMENTRF=@SLIPCOMMENT , OUTPUTPGIDRF=@OUTPUTPGID , OUTPUTPGCLASSIDRF=@OUTPUTPGCLASSID , OUTPUTFORMFILENAMERF=@OUTPUTFORMFILENAME , ENTERPRISENAMEPRTCDRF=@ENTERPRISENAMEPRTCD , PRTCIRCULATIONRF=@PRTCIRCULATION , SLIPFORMCDRF=@SLIPFORMCD , OUTCONFIMATIONMSGRF=@OUTCONFIMATIONMSG , OPTIONCODERF=@OPTIONCODE , PRINTERMNGNORF=@PRINTERMNGNO , TOPMARGINRF=@TOPMARGIN , LEFTMARGINRF=@LEFTMARGIN , RIGHTMARGINRF=@RIGHTMARGIN , BOTTOMMARGINRF=@BOTTOMMARGIN , PRTPREVIEWEXISTCODERF=@PRTPREVIEWEXISTCODE , OUTPUTPURPOSERF=@OUTPUTPURPOSE , EACHSLIPTYPECOLID1RF=@EACHSLIPTYPECOLID1 , EACHSLIPTYPECOLNM1RF=@EACHSLIPTYPECOLNM1 , EACHSLIPTYPECOLPRT1RF=@EACHSLIPTYPECOLPRT1 , EACHSLIPTYPECOLID2RF=@EACHSLIPTYPECOLID2 , EACHSLIPTYPECOLNM2RF=@EACHSLIPTYPECOLNM2 , EACHSLIPTYPECOLPRT2RF=@EACHSLIPTYPECOLPRT2 , EACHSLIPTYPECOLID3RF=@EACHSLIPTYPECOLID3 , EACHSLIPTYPECOLNM3RF=@EACHSLIPTYPECOLNM3 , EACHSLIPTYPECOLPRT3RF=@EACHSLIPTYPECOLPRT3 , EACHSLIPTYPECOLID4RF=@EACHSLIPTYPECOLID4 , EACHSLIPTYPECOLNM4RF=@EACHSLIPTYPECOLNM4 , EACHSLIPTYPECOLPRT4RF=@EACHSLIPTYPECOLPRT4 , EACHSLIPTYPECOLID5RF=@EACHSLIPTYPECOLID5 , EACHSLIPTYPECOLNM5RF=@EACHSLIPTYPECOLNM5 , EACHSLIPTYPECOLPRT5RF=@EACHSLIPTYPECOLPRT5 , EACHSLIPTYPECOLID6RF=@EACHSLIPTYPECOLID6 , EACHSLIPTYPECOLNM6RF=@EACHSLIPTYPECOLNM6 , EACHSLIPTYPECOLPRT6RF=@EACHSLIPTYPECOLPRT6 , EACHSLIPTYPECOLID7RF=@EACHSLIPTYPECOLID7 , EACHSLIPTYPECOLNM7RF=@EACHSLIPTYPECOLNM7 , EACHSLIPTYPECOLPRT7RF=@EACHSLIPTYPECOLPRT7 , EACHSLIPTYPECOLID8RF=@EACHSLIPTYPECOLID8 , EACHSLIPTYPECOLNM8RF=@EACHSLIPTYPECOLNM8 , EACHSLIPTYPECOLPRT8RF=@EACHSLIPTYPECOLPRT8 , EACHSLIPTYPECOLID9RF=@EACHSLIPTYPECOLID9 , " +
                            //    "EACHSLIPTYPECOLNM9RF=@EACHSLIPTYPECOLNM9 , EACHSLIPTYPECOLPRT9RF=@EACHSLIPTYPECOLPRT9 , EACHSLIPTYPECOLID10RF=@EACHSLIPTYPECOLID10 , EACHSLIPTYPECOLNM10RF=@EACHSLIPTYPECOLNM10 , EACHSLIPTYPECOLPRT10RF=@EACHSLIPTYPECOLPRT10 , SLIPFONTNAMERF=@SLIPFONTNAME , SLIPFONTSIZERF=@SLIPFONTSIZE , SLIPFONTSTYLERF=@SLIPFONTSTYLE , SLIPBASECOLORRED1RF=@SLIPBASECOLORRED1 , SLIPBASECOLORGRN1RF=@SLIPBASECOLORGRN1 , SLIPBASECOLORBLU1RF=@SLIPBASECOLORBLU1 , SLIPBASECOLORRED2RF=@SLIPBASECOLORRED2 , SLIPBASECOLORGRN2RF=@SLIPBASECOLORGRN2 , SLIPBASECOLORBLU2RF=@SLIPBASECOLORBLU2 , SLIPBASECOLORRED3RF=@SLIPBASECOLORRED3 , SLIPBASECOLORGRN3RF=@SLIPBASECOLORGRN3 , SLIPBASECOLORBLU3RF=@SLIPBASECOLORBLU3 , SLIPBASECOLORRED4RF=@SLIPBASECOLORRED4 , SLIPBASECOLORGRN4RF=@SLIPBASECOLORGRN4 , SLIPBASECOLORBLU4RF=@SLIPBASECOLORBLU4 , SLIPBASECOLORRED5RF=@SLIPBASECOLORRED5 , SLIPBASECOLORGRN5RF=@SLIPBASECOLORGRN5 , SLIPBASECOLORBLU5RF=@SLIPBASECOLORBLU5 , CUSTTELNOPRTDIVCDRF=@CUSTTELNOPRTDIVCD , COPYCOUNTRF=@COPYCOUNT , TITLENAME1RF=@TITLENAME1 , TITLENAME2RF=@TITLENAME2 , TITLENAME3RF=@TITLENAME3 , TITLENAME4RF=@TITLENAME4 , SPECIALPURPOSE1RF=@SPECIALPURPOSE1 , SPECIALPURPOSE2RF=@SPECIALPURPOSE2 , SPECIALPURPOSE3RF=@SPECIALPURPOSE3 , SPECIALPURPOSE4RF=@SPECIALPURPOSE4 , BARCODEACPODRNOPRTCDRF=@BARCODEACPODRNOPRTCD , BARCODECUSTCODEPRTCDRF=@BARCODECUSTCODEPRTCD , TITLENAME102RF=@TITLENAME102 , TITLENAME103RF=@TITLENAME103 , TITLENAME104RF=@TITLENAME104 , TITLENAME105RF=@TITLENAME105 , TITLENAME202RF=@TITLENAME202 , TITLENAME203RF=@TITLENAME203 , TITLENAME204RF=@TITLENAME204 , TITLENAME205RF=@TITLENAME205 , TITLENAME302RF=@TITLENAME302 , TITLENAME303RF=@TITLENAME303 , TITLENAME304RF=@TITLENAME304 , TITLENAME305RF=@TITLENAME305 , TITLENAME402RF=@TITLENAME402 , TITLENAME403RF=@TITLENAME403 , TITLENAME404RF=@TITLENAME404 , TITLENAME405RF=@TITLENAME405 , CONTRACTNOPRTDIVCDRF=@CONTRACTNOPRTDIVCD , CONTCPNOPRTDIVCDRF=@CONTCPNOPRTDIVCD " +
                            //    "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM ";
                            // 2008.05.23 upd start --------------------------------->>
                            //sqlCommand.CommandText = "UPDATE SLIPPRTSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM , SLIPPRTKINDRF=@SLIPPRTKIND , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID , SLIPCOMMENTRF=@SLIPCOMMENT , OUTPUTPGIDRF=@OUTPUTPGID , OUTPUTPGCLASSIDRF=@OUTPUTPGCLASSID , OUTPUTFORMFILENAMERF=@OUTPUTFORMFILENAME , ENTERPRISENAMEPRTCDRF=@ENTERPRISENAMEPRTCD , PRTCIRCULATIONRF=@PRTCIRCULATION , SLIPFORMCDRF=@SLIPFORMCD , OUTCONFIMATIONMSGRF=@OUTCONFIMATIONMSG , OPTIONCODERF=@OPTIONCODE , PRINTERMNGNORF=@PRINTERMNGNO , TOPMARGINRF=@TOPMARGIN , LEFTMARGINRF=@LEFTMARGIN , RIGHTMARGINRF=@RIGHTMARGIN , BOTTOMMARGINRF=@BOTTOMMARGIN , PRTPREVIEWEXISTCODERF=@PRTPREVIEWEXISTCODE , OUTPUTPURPOSERF=@OUTPUTPURPOSE , EACHSLIPTYPECOLID1RF=@EACHSLIPTYPECOLID1 , EACHSLIPTYPECOLNM1RF=@EACHSLIPTYPECOLNM1 , EACHSLIPTYPECOLPRT1RF=@EACHSLIPTYPECOLPRT1 , EACHSLIPTYPECOLID2RF=@EACHSLIPTYPECOLID2 , EACHSLIPTYPECOLNM2RF=@EACHSLIPTYPECOLNM2 , EACHSLIPTYPECOLPRT2RF=@EACHSLIPTYPECOLPRT2 , EACHSLIPTYPECOLID3RF=@EACHSLIPTYPECOLID3 , EACHSLIPTYPECOLNM3RF=@EACHSLIPTYPECOLNM3 , EACHSLIPTYPECOLPRT3RF=@EACHSLIPTYPECOLPRT3 , EACHSLIPTYPECOLID4RF=@EACHSLIPTYPECOLID4 , EACHSLIPTYPECOLNM4RF=@EACHSLIPTYPECOLNM4 , EACHSLIPTYPECOLPRT4RF=@EACHSLIPTYPECOLPRT4 , EACHSLIPTYPECOLID5RF=@EACHSLIPTYPECOLID5 , EACHSLIPTYPECOLNM5RF=@EACHSLIPTYPECOLNM5 , EACHSLIPTYPECOLPRT5RF=@EACHSLIPTYPECOLPRT5 , EACHSLIPTYPECOLID6RF=@EACHSLIPTYPECOLID6 , EACHSLIPTYPECOLNM6RF=@EACHSLIPTYPECOLNM6 , EACHSLIPTYPECOLPRT6RF=@EACHSLIPTYPECOLPRT6 , EACHSLIPTYPECOLID7RF=@EACHSLIPTYPECOLID7 , EACHSLIPTYPECOLNM7RF=@EACHSLIPTYPECOLNM7 , EACHSLIPTYPECOLPRT7RF=@EACHSLIPTYPECOLPRT7 , EACHSLIPTYPECOLID8RF=@EACHSLIPTYPECOLID8 , EACHSLIPTYPECOLNM8RF=@EACHSLIPTYPECOLNM8 , EACHSLIPTYPECOLPRT8RF=@EACHSLIPTYPECOLPRT8 , EACHSLIPTYPECOLID9RF=@EACHSLIPTYPECOLID9 , " +
                            //    "EACHSLIPTYPECOLNM9RF=@EACHSLIPTYPECOLNM9 , EACHSLIPTYPECOLPRT9RF=@EACHSLIPTYPECOLPRT9 , EACHSLIPTYPECOLID10RF=@EACHSLIPTYPECOLID10 , EACHSLIPTYPECOLNM10RF=@EACHSLIPTYPECOLNM10 , EACHSLIPTYPECOLPRT10RF=@EACHSLIPTYPECOLPRT10 , SLIPFONTNAMERF=@SLIPFONTNAME , SLIPFONTSIZERF=@SLIPFONTSIZE , SLIPFONTSTYLERF=@SLIPFONTSTYLE , SLIPBASECOLORRED1RF=@SLIPBASECOLORRED1 , SLIPBASECOLORGRN1RF=@SLIPBASECOLORGRN1 , SLIPBASECOLORBLU1RF=@SLIPBASECOLORBLU1 , SLIPBASECOLORRED2RF=@SLIPBASECOLORRED2 , SLIPBASECOLORGRN2RF=@SLIPBASECOLORGRN2 , SLIPBASECOLORBLU2RF=@SLIPBASECOLORBLU2 , SLIPBASECOLORRED3RF=@SLIPBASECOLORRED3 , SLIPBASECOLORGRN3RF=@SLIPBASECOLORGRN3 , SLIPBASECOLORBLU3RF=@SLIPBASECOLORBLU3 , SLIPBASECOLORRED4RF=@SLIPBASECOLORRED4 , SLIPBASECOLORGRN4RF=@SLIPBASECOLORGRN4 , SLIPBASECOLORBLU4RF=@SLIPBASECOLORBLU4 , SLIPBASECOLORRED5RF=@SLIPBASECOLORRED5 , SLIPBASECOLORGRN5RF=@SLIPBASECOLORGRN5 , SLIPBASECOLORBLU5RF=@SLIPBASECOLORBLU5 , CUSTTELNOPRTDIVCDRF=@CUSTTELNOPRTDIVCD , COPYCOUNTRF=@COPYCOUNT , TITLENAME1RF=@TITLENAME1 , TITLENAME2RF=@TITLENAME2 , TITLENAME3RF=@TITLENAME3 , TITLENAME4RF=@TITLENAME4 , SPECIALPURPOSE1RF=@SPECIALPURPOSE1 , SPECIALPURPOSE2RF=@SPECIALPURPOSE2 , SPECIALPURPOSE3RF=@SPECIALPURPOSE3 , SPECIALPURPOSE4RF=@SPECIALPURPOSE4 , BARCODEACPODRNOPRTCDRF=@BARCODEACPODRNOPRTCD , BARCODECUSTCODEPRTCDRF=@BARCODECUSTCODEPRTCD , TITLENAME102RF=@TITLENAME102 , TITLENAME103RF=@TITLENAME103 , TITLENAME104RF=@TITLENAME104 , TITLENAME105RF=@TITLENAME105 , TITLENAME202RF=@TITLENAME202 , TITLENAME203RF=@TITLENAME203 , TITLENAME204RF=@TITLENAME204 , TITLENAME205RF=@TITLENAME205 , TITLENAME302RF=@TITLENAME302 , TITLENAME303RF=@TITLENAME303 , TITLENAME304RF=@TITLENAME304 , TITLENAME305RF=@TITLENAME305 , TITLENAME402RF=@TITLENAME402 , TITLENAME403RF=@TITLENAME403 , TITLENAME404RF=@TITLENAME404 , TITLENAME405RF=@TITLENAME405 " +
                            //    "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID ";
                            // �� 2007.12.19 980081 c
                            sqlTxt = string.Empty;
                            sqlTxt += "UPDATE SLIPPRTSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlTxt += " , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += " , SLIPPRTKINDRF=@SLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += " , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID" + Environment.NewLine;
                            sqlTxt += " , SLIPCOMMENTRF=@SLIPCOMMENT" + Environment.NewLine;
                            sqlTxt += " , OUTPUTPGIDRF=@OUTPUTPGID" + Environment.NewLine;
                            sqlTxt += " , OUTPUTPGCLASSIDRF=@OUTPUTPGCLASSID" + Environment.NewLine;
                            sqlTxt += " , OUTPUTFORMFILENAMERF=@OUTPUTFORMFILENAME" + Environment.NewLine;
                            sqlTxt += " , ENTERPRISENAMEPRTCDRF=@ENTERPRISENAMEPRTCD" + Environment.NewLine;
                            sqlTxt += " , PRTCIRCULATIONRF=@PRTCIRCULATION" + Environment.NewLine;
                            sqlTxt += " , SLIPFORMCDRF=@SLIPFORMCD" + Environment.NewLine;
                            sqlTxt += " , OUTCONFIMATIONMSGRF=@OUTCONFIMATIONMSG" + Environment.NewLine;
                            sqlTxt += " , OPTIONCODERF=@OPTIONCODE" + Environment.NewLine;
                            sqlTxt += " , TOPMARGINRF=@TOPMARGIN" + Environment.NewLine;
                            sqlTxt += " , LEFTMARGINRF=@LEFTMARGIN" + Environment.NewLine;
                            sqlTxt += " , RIGHTMARGINRF=@RIGHTMARGIN" + Environment.NewLine;
                            sqlTxt += " , BOTTOMMARGINRF=@BOTTOMMARGIN" + Environment.NewLine;
                            sqlTxt += " , PRTPREVIEWEXISTCODERF=@PRTPREVIEWEXISTCODE" + Environment.NewLine;
                            sqlTxt += " , OUTPUTPURPOSERF=@OUTPUTPURPOSE" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLID1RF=@EACHSLIPTYPECOLID1" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLNM1RF=@EACHSLIPTYPECOLNM1" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLPRT1RF=@EACHSLIPTYPECOLPRT1" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLID2RF=@EACHSLIPTYPECOLID2" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLNM2RF=@EACHSLIPTYPECOLNM2" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLPRT2RF=@EACHSLIPTYPECOLPRT2" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLID3RF=@EACHSLIPTYPECOLID3" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLNM3RF=@EACHSLIPTYPECOLNM3" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLPRT3RF=@EACHSLIPTYPECOLPRT3" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLID4RF=@EACHSLIPTYPECOLID4" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLNM4RF=@EACHSLIPTYPECOLNM4" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLPRT4RF=@EACHSLIPTYPECOLPRT4" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLID5RF=@EACHSLIPTYPECOLID5" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLNM5RF=@EACHSLIPTYPECOLNM5" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLPRT5RF=@EACHSLIPTYPECOLPRT5" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLID6RF=@EACHSLIPTYPECOLID6" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLNM6RF=@EACHSLIPTYPECOLNM6" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLPRT6RF=@EACHSLIPTYPECOLPRT6" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLID7RF=@EACHSLIPTYPECOLID7" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLNM7RF=@EACHSLIPTYPECOLNM7" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLPRT7RF=@EACHSLIPTYPECOLPRT7" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLID8RF=@EACHSLIPTYPECOLID8" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLNM8RF=@EACHSLIPTYPECOLNM8" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLPRT8RF=@EACHSLIPTYPECOLPRT8" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLID9RF=@EACHSLIPTYPECOLID9" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLNM9RF=@EACHSLIPTYPECOLNM9" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLPRT9RF=@EACHSLIPTYPECOLPRT9" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLID10RF=@EACHSLIPTYPECOLID10" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLNM10RF=@EACHSLIPTYPECOLNM10" + Environment.NewLine;
                            sqlTxt += " , EACHSLIPTYPECOLPRT10RF=@EACHSLIPTYPECOLPRT10" + Environment.NewLine;
                            sqlTxt += " , SLIPFONTNAMERF=@SLIPFONTNAME" + Environment.NewLine;
                            sqlTxt += " , SLIPFONTSIZERF=@SLIPFONTSIZE" + Environment.NewLine;
                            sqlTxt += " , SLIPFONTSTYLERF=@SLIPFONTSTYLE" + Environment.NewLine;
                            sqlTxt += " , SLIPBASECOLORRED1RF=@SLIPBASECOLORRED1" + Environment.NewLine;
                            sqlTxt += " , SLIPBASECOLORGRN1RF=@SLIPBASECOLORGRN1" + Environment.NewLine;
                            sqlTxt += " , SLIPBASECOLORBLU1RF=@SLIPBASECOLORBLU1" + Environment.NewLine;
                            sqlTxt += " , SLIPBASECOLORRED2RF=@SLIPBASECOLORRED2" + Environment.NewLine;
                            sqlTxt += " , SLIPBASECOLORGRN2RF=@SLIPBASECOLORGRN2" + Environment.NewLine;
                            sqlTxt += " , SLIPBASECOLORBLU2RF=@SLIPBASECOLORBLU2" + Environment.NewLine;
                            sqlTxt += " , SLIPBASECOLORRED3RF=@SLIPBASECOLORRED3" + Environment.NewLine;
                            sqlTxt += " , SLIPBASECOLORGRN3RF=@SLIPBASECOLORGRN3" + Environment.NewLine;
                            sqlTxt += " , SLIPBASECOLORBLU3RF=@SLIPBASECOLORBLU3" + Environment.NewLine;
                            sqlTxt += " , SLIPBASECOLORRED4RF=@SLIPBASECOLORRED4" + Environment.NewLine;
                            sqlTxt += " , SLIPBASECOLORGRN4RF=@SLIPBASECOLORGRN4" + Environment.NewLine;
                            sqlTxt += " , SLIPBASECOLORBLU4RF=@SLIPBASECOLORBLU4" + Environment.NewLine;
                            sqlTxt += " , SLIPBASECOLORRED5RF=@SLIPBASECOLORRED5" + Environment.NewLine;
                            sqlTxt += " , SLIPBASECOLORGRN5RF=@SLIPBASECOLORGRN5" + Environment.NewLine;
                            sqlTxt += " , SLIPBASECOLORBLU5RF=@SLIPBASECOLORBLU5" + Environment.NewLine;
                            sqlTxt += " , COPYCOUNTRF=@COPYCOUNT" + Environment.NewLine;
                            sqlTxt += " , TITLENAME1RF=@TITLENAME1" + Environment.NewLine;
                            sqlTxt += " , TITLENAME2RF=@TITLENAME2" + Environment.NewLine;
                            sqlTxt += " , TITLENAME3RF=@TITLENAME3" + Environment.NewLine;
                            sqlTxt += " , TITLENAME4RF=@TITLENAME4" + Environment.NewLine;
                            sqlTxt += " , SPECIALPURPOSE1RF=@SPECIALPURPOSE1" + Environment.NewLine;
                            sqlTxt += " , SPECIALPURPOSE2RF=@SPECIALPURPOSE2" + Environment.NewLine;
                            sqlTxt += " , SPECIALPURPOSE3RF=@SPECIALPURPOSE3" + Environment.NewLine;
                            sqlTxt += " , SPECIALPURPOSE4RF=@SPECIALPURPOSE4" + Environment.NewLine;
                            sqlTxt += " , TITLENAME102RF=@TITLENAME102" + Environment.NewLine;
                            sqlTxt += " , TITLENAME103RF=@TITLENAME103" + Environment.NewLine;
                            sqlTxt += " , TITLENAME104RF=@TITLENAME104" + Environment.NewLine;
                            sqlTxt += " , TITLENAME105RF=@TITLENAME105" + Environment.NewLine;
                            sqlTxt += " , TITLENAME202RF=@TITLENAME202" + Environment.NewLine;
                            sqlTxt += " , TITLENAME203RF=@TITLENAME203" + Environment.NewLine;
                            sqlTxt += " , TITLENAME204RF=@TITLENAME204" + Environment.NewLine;
                            sqlTxt += " , TITLENAME205RF=@TITLENAME205" + Environment.NewLine;
                            sqlTxt += " , TITLENAME302RF=@TITLENAME302" + Environment.NewLine;
                            sqlTxt += " , TITLENAME303RF=@TITLENAME303" + Environment.NewLine;
                            sqlTxt += " , TITLENAME304RF=@TITLENAME304" + Environment.NewLine;
                            sqlTxt += " , TITLENAME305RF=@TITLENAME305" + Environment.NewLine;
                            sqlTxt += " , TITLENAME402RF=@TITLENAME402" + Environment.NewLine;
                            sqlTxt += " , TITLENAME403RF=@TITLENAME403" + Environment.NewLine;
                            sqlTxt += " , TITLENAME404RF=@TITLENAME404" + Environment.NewLine;
                            sqlTxt += " , TITLENAME405RF=@TITLENAME405" + Environment.NewLine;
                            sqlTxt += " , NOTE1RF=@NOTE1" + Environment.NewLine;
                            sqlTxt += " , NOTE2RF=@NOTE2" + Environment.NewLine;
                            sqlTxt += " , NOTE3RF=@NOTE3" + Environment.NewLine;
                            sqlTxt += " , QRCODEPRINTDIVCDRF=@QRCODEPRINTDIVCD" + Environment.NewLine;
                            sqlTxt += " , TIMEPRINTDIVCDRF=@TIMEPRINTDIVCD" + Environment.NewLine;
                            sqlTxt += " , REISSUEMARKRF=@REISSUEMARK" + Environment.NewLine;
                            sqlTxt += " , REFCONSTAXDIVCDRF=@REFCONSTAXDIVCD" + Environment.NewLine;
                            sqlTxt += " , REFCONSTAXPRTNMRF=@REFCONSTAXPRTNM" + Environment.NewLine;
                            sqlTxt += " , DETAILROWCOUNTRF=@DETAILROWCOUNT" + Environment.NewLine;
                            sqlTxt += " , HONORIFICTITLERF=@HONORIFICTITLE" + Environment.NewLine;
                            sqlTxt += " , CONSTAXPRTCDRF=@CONSTAXPRTCDRF" + Environment.NewLine; // ADD 2008.12.11
                            // --- ADD 2009/12/31 ---------->>>>>
                            sqlTxt += " , SLIPNOTECHARCNTRF=@SLIPNOTECHARCNTRF" + Environment.NewLine;
                            sqlTxt += " , SLIPNOTE2CHARCNTRF=@SLIPNOTE2CHARCNTRF" + Environment.NewLine;
                            sqlTxt += " , SLIPNOTE3CHARCNTRF=@SLIPNOTE3CHARCNTRF" + Environment.NewLine;
                            // --- ADD 2009/12/31 ----------<<<<<
                            sqlTxt += " , ENTNMPRTEXPDIVRF=@ENTNMPRTEXPDIVRF" + Environment.NewLine; // ADD 2011/02/16
                            // --- ADD 2011/07/19 ---------->>>>>
                            sqlTxt += "    ,SCMANSMARKPRTDIVRF=@SCMANSMARKPRTDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,NORMALPRTMARKRF=@NORMALPRTMARKRF" + Environment.NewLine;
                            sqlTxt += "    ,SCMMANUALANSMARKRF=@SCMMANUALANSMARKRF" + Environment.NewLine;
                            sqlTxt += "    ,SCMAUTOANSMARKRF=@SCMAUTOANSMARKRF" + Environment.NewLine;
                            // --- ADD 2011/07/19 ----------<<<<<
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.23 upd end -----------------------------------<<

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EnterpriseCode);
                            findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.DataInputSystem);
                            //2006.12.06 deleted by T-Kidate
                            //findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipPrtKind);
                            //findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipPrtSetPaperId);
                            // �� 2007.12.19 980081 a
                            findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipPrtKind);
                            findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipPrtSetPaperId);
                            // �� 2007.12.19 980081 a

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)slipPrtSetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (slipPrtSetWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (!myReader.IsClosed) myReader.Close();
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 DEL
                                //sqlConnection.Close();
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 ADD
                                if (!execFromParent)
                                {
                                    sqlConnection.Close();
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 ADD
                                return status;
                            }

                            /*2006.12.08 deleted by T-Kidate
							//�V�K�쐬����SQL���𐶐�
							sqlCommand.CommandText = "INSERT INTO SLIPPRTSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, " +
								"DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SLIPPRTSETPAPERIDRF, SLIPCOMMENTRF, OUTPUTPGIDRF, OUTPUTPGCLASSIDRF, OUTPUTFORMFILENAMERF, ENTERPRISENAMEPRTCDRF, PRTCIRCULATIONRF, SLIPFORMCDRF, OUTCONFIMATIONMSGRF, OPTIONCODERF, PRINTERMNGNORF, TOPMARGINRF, LEFTMARGINRF, RIGHTMARGINRF, BOTTOMMARGINRF, PRTPREVIEWEXISTCODERF, OUTPUTPURPOSERF, EACHSLIPTYPECOLID1RF, EACHSLIPTYPECOLNM1RF, EACHSLIPTYPECOLPRT1RF, EACHSLIPTYPECOLID2RF, EACHSLIPTYPECOLNM2RF, EACHSLIPTYPECOLPRT2RF, EACHSLIPTYPECOLID3RF, EACHSLIPTYPECOLNM3RF, EACHSLIPTYPECOLPRT3RF, EACHSLIPTYPECOLID4RF, EACHSLIPTYPECOLNM4RF, EACHSLIPTYPECOLPRT4RF, EACHSLIPTYPECOLID5RF, EACHSLIPTYPECOLNM5RF, EACHSLIPTYPECOLPRT5RF, EACHSLIPTYPECOLID6RF, EACHSLIPTYPECOLNM6RF, EACHSLIPTYPECOLPRT6RF, EACHSLIPTYPECOLID7RF, EACHSLIPTYPECOLNM7RF, EACHSLIPTYPECOLPRT7RF, EACHSLIPTYPECOLID8RF, EACHSLIPTYPECOLNM8RF, EACHSLIPTYPECOLPRT8RF, EACHSLIPTYPECOLID9RF, EACHSLIPTYPECOLNM9RF, EACHSLIPTYPECOLPRT9RF, EACHSLIPTYPECOLID10RF, EACHSLIPTYPECOLNM10RF, EACHSLIPTYPECOLPRT10RF, SLIPFONTNAMERF, SLIPFONTSIZERF, SLIPFONTSTYLERF, SLIPBASECOLORRED1RF, SLIPBASECOLORGRN1RF, SLIPBASECOLORBLU1RF, SLIPBASECOLORRED2RF, SLIPBASECOLORGRN2RF, SLIPBASECOLORBLU2RF, SLIPBASECOLORRED3RF, SLIPBASECOLORGRN3RF, SLIPBASECOLORBLU3RF, SLIPBASECOLORRED4RF, SLIPBASECOLORGRN4RF, SLIPBASECOLORBLU4RF, SLIPBASECOLORRED5RF, SLIPBASECOLORGRN5RF, SLIPBASECOLORBLU5RF, CUSTTELNOPRTDIVCDRF, COPYCOUNTRF, TITLENAME1RF, TITLENAME2RF, TITLENAME3RF, TITLENAME4RF, SPECIALPURPOSE1RF, SPECIALPURPOSE2RF, SPECIALPURPOSE3RF, SPECIALPURPOSE4RF, BARCODEACPODRNOPRTCDRF, BARCODECUSTCODEPRTCDRF, BARCODECARMNGNOPRTCDRF, TITLENAME102RF, TITLENAME103RF, TITLENAME104RF, TITLENAME105RF, TITLENAME202RF, TITLENAME203RF, TITLENAME204RF, TITLENAME205RF, TITLENAME302RF, TITLENAME303RF, TITLENAME304RF, TITLENAME305RF, TITLENAME402RF, TITLENAME403RF, TITLENAME404RF, TITLENAME405RF, MAINWORKLINEPRTDIVCDRF) " +
								"VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, " +
                                "@DATAINPUTSYSTEM, @SLIPPRTKIND, @SLIPPRTSETPAPERID, @SLIPCOMMENT, @OUTPUTPGID, @OUTPUTPGCLASSID, @OUTPUTFORMFILENAME, @ENTERPRISENAMEPRTCD, @PRTCIRCULATION, @SLIPFORMCD, @OUTCONFIMATIONMSG, @OPTIONCODE, @PRINTERMNGNO, @TOPMARGIN, @LEFTMARGIN, @RIGHTMARGIN, @BOTTOMMARGIN, @PRTPREVIEWEXISTCODE, @OUTPUTPURPOSE, @EACHSLIPTYPECOLID1, @EACHSLIPTYPECOLNM1, @EACHSLIPTYPECOLPRT1, @EACHSLIPTYPECOLID2, @EACHSLIPTYPECOLNM2, @EACHSLIPTYPECOLPRT2, @EACHSLIPTYPECOLID3, @EACHSLIPTYPECOLNM3, @EACHSLIPTYPECOLPRT3, @EACHSLIPTYPECOLID4, @EACHSLIPTYPECOLNM4, @EACHSLIPTYPECOLPRT4, @EACHSLIPTYPECOLID5, @EACHSLIPTYPECOLNM5, @EACHSLIPTYPECOLPRT5, @EACHSLIPTYPECOLID6, @EACHSLIPTYPECOLNM6, @EACHSLIPTYPECOLPRT6, @EACHSLIPTYPECOLID7, @EACHSLIPTYPECOLNM7, @EACHSLIPTYPECOLPRT7, @EACHSLIPTYPECOLID8, @EACHSLIPTYPECOLNM8, @EACHSLIPTYPECOLPRT8, @EACHSLIPTYPECOLID9, @EACHSLIPTYPECOLNM9, @EACHSLIPTYPECOLPRT9, @EACHSLIPTYPECOLID10, @EACHSLIPTYPECOLNM10, @EACHSLIPTYPECOLPRT10, @SLIPFONTNAME, @SLIPFONTSIZE, @SLIPFONTSTYLE, @SLIPBASECOLORRED1, @SLIPBASECOLORGRN1, @SLIPBASECOLORBLU1, @SLIPBASECOLORRED2, @SLIPBASECOLORGRN2, @SLIPBASECOLORBLU2, @SLIPBASECOLORRED3, @SLIPBASECOLORGRN3, @SLIPBASECOLORBLU3, @SLIPBASECOLORRED4, @SLIPBASECOLORGRN4, @SLIPBASECOLORBLU4, @SLIPBASECOLORRED5, @SLIPBASECOLORGRN5, @SLIPBASECOLORBLU5, @CUSTTELNOPRTDIVCD, @COPYCOUNT, @TITLENAME1, @TITLENAME2, @TITLENAME3, @TITLENAME4, @SPECIALPURPOSE1, @SPECIALPURPOSE2, @SPECIALPURPOSE3, @SPECIALPURPOSE4, @BARCODEACPODRNOPRTCD, @BARCODECUSTCODEPRTCD, @BARCODECARMNGNOPRTCDRF, @TITLENAME102, @TITLENAME103, @TITLENAME104, @TITLENAME105, @TITLENAME202, @TITLENAME203, @TITLENAME204, @TITLENAME205, @TITLENAME302, @TITLENAME303, @TITLENAME304, @TITLENAME305, @TITLENAME402, @TITLENAME403, @TITLENAME404, @TITLENAME405, @MAINWORKLINEPRTDIVCDRF)";
                            */

                            //2006.12.08 added by T-Kidate
                            //�V�K�쐬����SQL���𐶐�
                            // �� 2007.12.19 980081 c
                            //sqlCommand.CommandText = "INSERT INTO SLIPPRTSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, " +
                            //    "DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SLIPPRTSETPAPERIDRF, SLIPCOMMENTRF, OUTPUTPGIDRF, OUTPUTPGCLASSIDRF, OUTPUTFORMFILENAMERF, ENTERPRISENAMEPRTCDRF, PRTCIRCULATIONRF, SLIPFORMCDRF, OUTCONFIMATIONMSGRF, OPTIONCODERF, PRINTERMNGNORF, TOPMARGINRF, LEFTMARGINRF, RIGHTMARGINRF, BOTTOMMARGINRF, PRTPREVIEWEXISTCODERF, OUTPUTPURPOSERF, EACHSLIPTYPECOLID1RF, EACHSLIPTYPECOLNM1RF, EACHSLIPTYPECOLPRT1RF, EACHSLIPTYPECOLID2RF, EACHSLIPTYPECOLNM2RF, EACHSLIPTYPECOLPRT2RF, EACHSLIPTYPECOLID3RF, EACHSLIPTYPECOLNM3RF, EACHSLIPTYPECOLPRT3RF, EACHSLIPTYPECOLID4RF, EACHSLIPTYPECOLNM4RF, EACHSLIPTYPECOLPRT4RF, EACHSLIPTYPECOLID5RF, EACHSLIPTYPECOLNM5RF, EACHSLIPTYPECOLPRT5RF, EACHSLIPTYPECOLID6RF, EACHSLIPTYPECOLNM6RF, EACHSLIPTYPECOLPRT6RF, EACHSLIPTYPECOLID7RF, EACHSLIPTYPECOLNM7RF, EACHSLIPTYPECOLPRT7RF, EACHSLIPTYPECOLID8RF, EACHSLIPTYPECOLNM8RF, EACHSLIPTYPECOLPRT8RF, EACHSLIPTYPECOLID9RF, EACHSLIPTYPECOLNM9RF, EACHSLIPTYPECOLPRT9RF, EACHSLIPTYPECOLID10RF, EACHSLIPTYPECOLNM10RF, EACHSLIPTYPECOLPRT10RF, SLIPFONTNAMERF, SLIPFONTSIZERF, SLIPFONTSTYLERF, SLIPBASECOLORRED1RF, SLIPBASECOLORGRN1RF, SLIPBASECOLORBLU1RF, SLIPBASECOLORRED2RF, SLIPBASECOLORGRN2RF, SLIPBASECOLORBLU2RF, SLIPBASECOLORRED3RF, SLIPBASECOLORGRN3RF, SLIPBASECOLORBLU3RF, SLIPBASECOLORRED4RF, SLIPBASECOLORGRN4RF, SLIPBASECOLORBLU4RF, SLIPBASECOLORRED5RF, SLIPBASECOLORGRN5RF, SLIPBASECOLORBLU5RF, CUSTTELNOPRTDIVCDRF, COPYCOUNTRF, TITLENAME1RF, TITLENAME2RF, TITLENAME3RF, TITLENAME4RF, SPECIALPURPOSE1RF, SPECIALPURPOSE2RF, SPECIALPURPOSE3RF, SPECIALPURPOSE4RF, BARCODEACPODRNOPRTCDRF, BARCODECUSTCODEPRTCDRF, TITLENAME102RF, TITLENAME103RF, TITLENAME104RF, TITLENAME105RF, TITLENAME202RF, TITLENAME203RF, TITLENAME204RF, TITLENAME205RF, TITLENAME302RF, TITLENAME303RF, TITLENAME304RF, TITLENAME305RF, TITLENAME402RF, TITLENAME403RF, TITLENAME404RF, TITLENAME405RF, CONTRACTNOPRTDIVCDRF, CONTCPNOPRTDIVCDRF ) " +
                            //    "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, " +
                            //    "@DATAINPUTSYSTEM, @SLIPPRTKIND, @SLIPPRTSETPAPERID, @SLIPCOMMENT, @OUTPUTPGID, @OUTPUTPGCLASSID, @OUTPUTFORMFILENAME, @ENTERPRISENAMEPRTCD, @PRTCIRCULATION, @SLIPFORMCD, @OUTCONFIMATIONMSG, @OPTIONCODE, @PRINTERMNGNO, @TOPMARGIN, @LEFTMARGIN, @RIGHTMARGIN, @BOTTOMMARGIN, @PRTPREVIEWEXISTCODE, @OUTPUTPURPOSE, @EACHSLIPTYPECOLID1, @EACHSLIPTYPECOLNM1, @EACHSLIPTYPECOLPRT1, @EACHSLIPTYPECOLID2, @EACHSLIPTYPECOLNM2, @EACHSLIPTYPECOLPRT2, @EACHSLIPTYPECOLID3, @EACHSLIPTYPECOLNM3, @EACHSLIPTYPECOLPRT3, @EACHSLIPTYPECOLID4, @EACHSLIPTYPECOLNM4, @EACHSLIPTYPECOLPRT4, @EACHSLIPTYPECOLID5, @EACHSLIPTYPECOLNM5, @EACHSLIPTYPECOLPRT5, @EACHSLIPTYPECOLID6, @EACHSLIPTYPECOLNM6, @EACHSLIPTYPECOLPRT6, @EACHSLIPTYPECOLID7, @EACHSLIPTYPECOLNM7, @EACHSLIPTYPECOLPRT7, @EACHSLIPTYPECOLID8, @EACHSLIPTYPECOLNM8, @EACHSLIPTYPECOLPRT8, @EACHSLIPTYPECOLID9, @EACHSLIPTYPECOLNM9, @EACHSLIPTYPECOLPRT9, @EACHSLIPTYPECOLID10, @EACHSLIPTYPECOLNM10, @EACHSLIPTYPECOLPRT10, @SLIPFONTNAME, @SLIPFONTSIZE, @SLIPFONTSTYLE, @SLIPBASECOLORRED1, @SLIPBASECOLORGRN1, @SLIPBASECOLORBLU1, @SLIPBASECOLORRED2, @SLIPBASECOLORGRN2, @SLIPBASECOLORBLU2, @SLIPBASECOLORRED3, @SLIPBASECOLORGRN3, @SLIPBASECOLORBLU3, @SLIPBASECOLORRED4, @SLIPBASECOLORGRN4, @SLIPBASECOLORBLU4, @SLIPBASECOLORRED5, @SLIPBASECOLORGRN5, @SLIPBASECOLORBLU5, @CUSTTELNOPRTDIVCD, @COPYCOUNT, @TITLENAME1, @TITLENAME2, @TITLENAME3, @TITLENAME4, @SPECIALPURPOSE1, @SPECIALPURPOSE2, @SPECIALPURPOSE3, @SPECIALPURPOSE4, @BARCODEACPODRNOPRTCD, @BARCODECUSTCODEPRTCD, @TITLENAME102, @TITLENAME103, @TITLENAME104, @TITLENAME105, @TITLENAME202, @TITLENAME203, @TITLENAME204, @TITLENAME205, @TITLENAME302, @TITLENAME303, @TITLENAME304, @TITLENAME305, @TITLENAME402, @TITLENAME403, @TITLENAME404, @TITLENAME405, @CONTRACTNOPRTDIVCD, @CONTCPNOPRTDIVCD)";
                            // 2008.05.23 upd start ---------------------------------------------------------->>
                            //sqlCommand.CommandText = "INSERT INTO SLIPPRTSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, " +
                            //    "DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SLIPPRTSETPAPERIDRF, SLIPCOMMENTRF, OUTPUTPGIDRF, OUTPUTPGCLASSIDRF, OUTPUTFORMFILENAMERF, ENTERPRISENAMEPRTCDRF, PRTCIRCULATIONRF, SLIPFORMCDRF, OUTCONFIMATIONMSGRF, OPTIONCODERF, PRINTERMNGNORF, TOPMARGINRF, LEFTMARGINRF, RIGHTMARGINRF, BOTTOMMARGINRF, PRTPREVIEWEXISTCODERF, OUTPUTPURPOSERF, EACHSLIPTYPECOLID1RF, EACHSLIPTYPECOLNM1RF, EACHSLIPTYPECOLPRT1RF, EACHSLIPTYPECOLID2RF, EACHSLIPTYPECOLNM2RF, EACHSLIPTYPECOLPRT2RF, EACHSLIPTYPECOLID3RF, EACHSLIPTYPECOLNM3RF, EACHSLIPTYPECOLPRT3RF, EACHSLIPTYPECOLID4RF, EACHSLIPTYPECOLNM4RF, EACHSLIPTYPECOLPRT4RF, EACHSLIPTYPECOLID5RF, EACHSLIPTYPECOLNM5RF, EACHSLIPTYPECOLPRT5RF, EACHSLIPTYPECOLID6RF, EACHSLIPTYPECOLNM6RF, EACHSLIPTYPECOLPRT6RF, EACHSLIPTYPECOLID7RF, EACHSLIPTYPECOLNM7RF, EACHSLIPTYPECOLPRT7RF, EACHSLIPTYPECOLID8RF, EACHSLIPTYPECOLNM8RF, EACHSLIPTYPECOLPRT8RF, EACHSLIPTYPECOLID9RF, EACHSLIPTYPECOLNM9RF, EACHSLIPTYPECOLPRT9RF, EACHSLIPTYPECOLID10RF, EACHSLIPTYPECOLNM10RF, EACHSLIPTYPECOLPRT10RF, SLIPFONTNAMERF, SLIPFONTSIZERF, SLIPFONTSTYLERF, SLIPBASECOLORRED1RF, SLIPBASECOLORGRN1RF, SLIPBASECOLORBLU1RF, SLIPBASECOLORRED2RF, SLIPBASECOLORGRN2RF, SLIPBASECOLORBLU2RF, SLIPBASECOLORRED3RF, SLIPBASECOLORGRN3RF, SLIPBASECOLORBLU3RF, SLIPBASECOLORRED4RF, SLIPBASECOLORGRN4RF, SLIPBASECOLORBLU4RF, SLIPBASECOLORRED5RF, SLIPBASECOLORGRN5RF, SLIPBASECOLORBLU5RF, CUSTTELNOPRTDIVCDRF, COPYCOUNTRF, TITLENAME1RF, TITLENAME2RF, TITLENAME3RF, TITLENAME4RF, SPECIALPURPOSE1RF, SPECIALPURPOSE2RF, SPECIALPURPOSE3RF, SPECIALPURPOSE4RF, BARCODEACPODRNOPRTCDRF, BARCODECUSTCODEPRTCDRF, TITLENAME102RF, TITLENAME103RF, TITLENAME104RF, TITLENAME105RF, TITLENAME202RF, TITLENAME203RF, TITLENAME204RF, TITLENAME205RF, TITLENAME302RF, TITLENAME303RF, TITLENAME304RF, TITLENAME305RF, TITLENAME402RF, TITLENAME403RF, TITLENAME404RF, TITLENAME405RF ) " +
                            //    "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, " +
                            //    "@DATAINPUTSYSTEM, @SLIPPRTKIND, @SLIPPRTSETPAPERID, @SLIPCOMMENT, @OUTPUTPGID, @OUTPUTPGCLASSID, @OUTPUTFORMFILENAME, @ENTERPRISENAMEPRTCD, @PRTCIRCULATION, @SLIPFORMCD, @OUTCONFIMATIONMSG, @OPTIONCODE, @PRINTERMNGNO, @TOPMARGIN, @LEFTMARGIN, @RIGHTMARGIN, @BOTTOMMARGIN, @PRTPREVIEWEXISTCODE, @OUTPUTPURPOSE, @EACHSLIPTYPECOLID1, @EACHSLIPTYPECOLNM1, @EACHSLIPTYPECOLPRT1, @EACHSLIPTYPECOLID2, @EACHSLIPTYPECOLNM2, @EACHSLIPTYPECOLPRT2, @EACHSLIPTYPECOLID3, @EACHSLIPTYPECOLNM3, @EACHSLIPTYPECOLPRT3, @EACHSLIPTYPECOLID4, @EACHSLIPTYPECOLNM4, @EACHSLIPTYPECOLPRT4, @EACHSLIPTYPECOLID5, @EACHSLIPTYPECOLNM5, @EACHSLIPTYPECOLPRT5, @EACHSLIPTYPECOLID6, @EACHSLIPTYPECOLNM6, @EACHSLIPTYPECOLPRT6, @EACHSLIPTYPECOLID7, @EACHSLIPTYPECOLNM7, @EACHSLIPTYPECOLPRT7, @EACHSLIPTYPECOLID8, @EACHSLIPTYPECOLNM8, @EACHSLIPTYPECOLPRT8, @EACHSLIPTYPECOLID9, @EACHSLIPTYPECOLNM9, @EACHSLIPTYPECOLPRT9, @EACHSLIPTYPECOLID10, @EACHSLIPTYPECOLNM10, @EACHSLIPTYPECOLPRT10, @SLIPFONTNAME, @SLIPFONTSIZE, @SLIPFONTSTYLE, @SLIPBASECOLORRED1, @SLIPBASECOLORGRN1, @SLIPBASECOLORBLU1, @SLIPBASECOLORRED2, @SLIPBASECOLORGRN2, @SLIPBASECOLORBLU2, @SLIPBASECOLORRED3, @SLIPBASECOLORGRN3, @SLIPBASECOLORBLU3, @SLIPBASECOLORRED4, @SLIPBASECOLORGRN4, @SLIPBASECOLORBLU4, @SLIPBASECOLORRED5, @SLIPBASECOLORGRN5, @SLIPBASECOLORBLU5, @CUSTTELNOPRTDIVCD, @COPYCOUNT, @TITLENAME1, @TITLENAME2, @TITLENAME3, @TITLENAME4, @SPECIALPURPOSE1, @SPECIALPURPOSE2, @SPECIALPURPOSE3, @SPECIALPURPOSE4, @BARCODEACPODRNOPRTCD, @BARCODECUSTCODEPRTCD, @TITLENAME102, @TITLENAME103, @TITLENAME104, @TITLENAME105, @TITLENAME202, @TITLENAME203, @TITLENAME204, @TITLENAME205, @TITLENAME302, @TITLENAME303, @TITLENAME304, @TITLENAME305, @TITLENAME402, @TITLENAME403, @TITLENAME404, @TITLENAME405)";
                            // �� 2007.12.19 980081 c
                            sqlTxt = string.Empty;
                            sqlTxt += "INSERT INTO SLIPPRTSETRF" + Environment.NewLine;
                            sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPCOMMENTRF" + Environment.NewLine;
                            sqlTxt += "    ,OUTPUTPGIDRF" + Environment.NewLine;
                            sqlTxt += "    ,OUTPUTPGCLASSIDRF" + Environment.NewLine;
                            sqlTxt += "    ,OUTPUTFORMFILENAMERF" + Environment.NewLine;
                            sqlTxt += "    ,ENTERPRISENAMEPRTCDRF" + Environment.NewLine;
                            sqlTxt += "    ,PRTCIRCULATIONRF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPFORMCDRF" + Environment.NewLine;
                            sqlTxt += "    ,OUTCONFIMATIONMSGRF" + Environment.NewLine;
                            sqlTxt += "    ,OPTIONCODERF" + Environment.NewLine;
                            sqlTxt += "    ,TOPMARGINRF" + Environment.NewLine;
                            sqlTxt += "    ,LEFTMARGINRF" + Environment.NewLine;
                            sqlTxt += "    ,RIGHTMARGINRF" + Environment.NewLine;
                            sqlTxt += "    ,BOTTOMMARGINRF" + Environment.NewLine;
                            sqlTxt += "    ,PRTPREVIEWEXISTCODERF" + Environment.NewLine;
                            sqlTxt += "    ,OUTPUTPURPOSERF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLID1RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLNM1RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLPRT1RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLID2RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLNM2RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLPRT2RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLID3RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLNM3RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLPRT3RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLID4RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLNM4RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLPRT4RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLID5RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLNM5RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLPRT5RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLID6RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLNM6RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLPRT6RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLID7RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLNM7RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLPRT7RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLID8RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLNM8RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLPRT8RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLID9RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLNM9RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLPRT9RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLID10RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLNM10RF" + Environment.NewLine;
                            sqlTxt += "    ,EACHSLIPTYPECOLPRT10RF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPFONTNAMERF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPFONTSIZERF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPFONTSTYLERF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPBASECOLORRED1RF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPBASECOLORGRN1RF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPBASECOLORBLU1RF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPBASECOLORRED2RF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPBASECOLORGRN2RF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPBASECOLORBLU2RF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPBASECOLORRED3RF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPBASECOLORGRN3RF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPBASECOLORBLU3RF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPBASECOLORRED4RF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPBASECOLORGRN4RF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPBASECOLORBLU4RF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPBASECOLORRED5RF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPBASECOLORGRN5RF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPBASECOLORBLU5RF" + Environment.NewLine;
                            sqlTxt += "    ,COPYCOUNTRF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME1RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME2RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME3RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME4RF" + Environment.NewLine;
                            sqlTxt += "    ,SPECIALPURPOSE1RF" + Environment.NewLine;
                            sqlTxt += "    ,SPECIALPURPOSE2RF" + Environment.NewLine;
                            sqlTxt += "    ,SPECIALPURPOSE3RF" + Environment.NewLine;
                            sqlTxt += "    ,SPECIALPURPOSE4RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME102RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME103RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME104RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME105RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME202RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME203RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME204RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME205RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME302RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME303RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME304RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME305RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME402RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME403RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME404RF" + Environment.NewLine;
                            sqlTxt += "    ,TITLENAME405RF" + Environment.NewLine;
                            sqlTxt += "    ,NOTE1RF" + Environment.NewLine;
                            sqlTxt += "    ,NOTE2RF" + Environment.NewLine;
                            sqlTxt += "    ,NOTE3RF" + Environment.NewLine;
                            sqlTxt += "    ,QRCODEPRINTDIVCDRF" + Environment.NewLine;
                            sqlTxt += "    ,TIMEPRINTDIVCDRF" + Environment.NewLine;
                            sqlTxt += "    ,REISSUEMARKRF" + Environment.NewLine;
                            sqlTxt += "    ,REFCONSTAXDIVCDRF" + Environment.NewLine;
                            sqlTxt += "    ,REFCONSTAXPRTNMRF" + Environment.NewLine;
                            sqlTxt += "    ,DETAILROWCOUNTRF" + Environment.NewLine;
                            sqlTxt += "    ,HONORIFICTITLERF" + Environment.NewLine;
                            sqlTxt += "    ,CONSTAXPRTCDRF" + Environment.NewLine; // ADD 2008.12.11
                            // --- ADD 2009/12/31 ---------->>>>>
                            sqlTxt += "    ,SLIPNOTECHARCNTRF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPNOTE2CHARCNTRF" + Environment.NewLine;
                            sqlTxt += "    ,SLIPNOTE3CHARCNTRF" + Environment.NewLine;
                            // --- ADD 2009/12/31 ----------<<<<<
                            sqlTxt += "    ,ENTNMPRTEXPDIVRF" + Environment.NewLine; // ADD 2011/02/16
                            // --- ADD 2011/07/19 ---------->>>>>
                            sqlTxt += "    ,SCMANSMARKPRTDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,NORMALPRTMARKRF" + Environment.NewLine;
                            sqlTxt += "    ,SCMMANUALANSMARKRF" + Environment.NewLine;
                            sqlTxt += "    ,SCMAUTOANSMARKRF" + Environment.NewLine;
                            // --- ADD 2011/07/19 ----------<<<<<
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
                            sqlTxt += "    ,@DATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPPRTSETPAPERID" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPCOMMENT" + Environment.NewLine;
                            sqlTxt += "    ,@OUTPUTPGID" + Environment.NewLine;
                            sqlTxt += "    ,@OUTPUTPGCLASSID" + Environment.NewLine;
                            sqlTxt += "    ,@OUTPUTFORMFILENAME" + Environment.NewLine;
                            sqlTxt += "    ,@ENTERPRISENAMEPRTCD" + Environment.NewLine;
                            sqlTxt += "    ,@PRTCIRCULATION" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPFORMCD" + Environment.NewLine;
                            sqlTxt += "    ,@OUTCONFIMATIONMSG" + Environment.NewLine;
                            sqlTxt += "    ,@OPTIONCODE" + Environment.NewLine;
                            sqlTxt += "    ,@TOPMARGIN" + Environment.NewLine;
                            sqlTxt += "    ,@LEFTMARGIN" + Environment.NewLine;
                            sqlTxt += "    ,@RIGHTMARGIN" + Environment.NewLine;
                            sqlTxt += "    ,@BOTTOMMARGIN" + Environment.NewLine;
                            sqlTxt += "    ,@PRTPREVIEWEXISTCODE" + Environment.NewLine;
                            sqlTxt += "    ,@OUTPUTPURPOSE" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLID1" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLNM1" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLPRT1" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLID2" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLNM2" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLPRT2" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLID3" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLNM3" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLPRT3" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLID4" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLNM4" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLPRT4" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLID5" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLNM5" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLPRT5" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLID6" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLNM6" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLPRT6" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLID7" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLNM7" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLPRT7" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLID8" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLNM8" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLPRT8" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLID9" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLNM9" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLPRT9" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLID10" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLNM10" + Environment.NewLine;
                            sqlTxt += "    ,@EACHSLIPTYPECOLPRT10" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPFONTNAME" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPFONTSIZE" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPFONTSTYLE" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPBASECOLORRED1" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPBASECOLORGRN1" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPBASECOLORBLU1" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPBASECOLORRED2" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPBASECOLORGRN2" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPBASECOLORBLU2" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPBASECOLORRED3" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPBASECOLORGRN3" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPBASECOLORBLU3" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPBASECOLORRED4" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPBASECOLORGRN4" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPBASECOLORBLU4" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPBASECOLORRED5" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPBASECOLORGRN5" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPBASECOLORBLU5" + Environment.NewLine;
                            sqlTxt += "    ,@COPYCOUNT" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME1" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME2" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME3" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME4" + Environment.NewLine;
                            sqlTxt += "    ,@SPECIALPURPOSE1" + Environment.NewLine;
                            sqlTxt += "    ,@SPECIALPURPOSE2" + Environment.NewLine;
                            sqlTxt += "    ,@SPECIALPURPOSE3" + Environment.NewLine;
                            sqlTxt += "    ,@SPECIALPURPOSE4" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME102" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME103" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME104" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME105" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME202" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME203" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME204" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME205" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME302" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME303" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME304" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME305" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME402" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME403" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME404" + Environment.NewLine;
                            sqlTxt += "    ,@TITLENAME405" + Environment.NewLine;
                            sqlTxt += "    ,@NOTE1" + Environment.NewLine;
                            sqlTxt += "    ,@NOTE2" + Environment.NewLine;
                            sqlTxt += "    ,@NOTE3" + Environment.NewLine;
                            sqlTxt += "    ,@QRCODEPRINTDIVCD" + Environment.NewLine;
                            sqlTxt += "    ,@TIMEPRINTDIVCD" + Environment.NewLine;
                            sqlTxt += "    ,@REISSUEMARK" + Environment.NewLine;
                            sqlTxt += "    ,@REFCONSTAXDIVCD" + Environment.NewLine;
                            sqlTxt += "    ,@REFCONSTAXPRTNM" + Environment.NewLine;
                            sqlTxt += "    ,@DETAILROWCOUNT" + Environment.NewLine;
                            sqlTxt += "    ,@HONORIFICTITLE" + Environment.NewLine;
                            sqlTxt += "    ,@CONSTAXPRTCDRF" + Environment.NewLine; // ADD 2008.12.11
                            // --- ADD 2009/12/31 ---------->>>>>
                            sqlTxt += "    ,@SLIPNOTECHARCNTRF" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPNOTE2CHARCNTRF" + Environment.NewLine;
                            sqlTxt += "    ,@SLIPNOTE3CHARCNTRF" + Environment.NewLine;
                            // --- ADD 2009/12/31 ----------<<<<<
                            sqlTxt += "    ,@ENTNMPRTEXPDIVRF" + Environment.NewLine; // ADD 2011/02/16
                            // --- ADD 2011/07/19 ---------->>>>>
                            sqlTxt += "    ,@SCMANSMARKPRTDIVRF" + Environment.NewLine;
                            sqlTxt += "    ,@NORMALPRTMARKRF" + Environment.NewLine;
                            sqlTxt += "    ,@SCMMANUALANSMARKRF" + Environment.NewLine;
                            sqlTxt += "    ,@SCMAUTOANSMARKRF" + Environment.NewLine;
                            // --- ADD 2011/07/19 ----------<<<<<
                            sqlTxt += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.23 upd end ------------------------------------------------------------<<

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)slipPrtSetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (!myReader.IsClosed) myReader.Close();

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                        SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@SLIPPRTKIND", SqlDbType.Int);
                        SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);
                        SqlParameter paraSlipComment = sqlCommand.Parameters.Add("@SLIPCOMMENT", SqlDbType.NVarChar);
                        SqlParameter paraOutputPgId = sqlCommand.Parameters.Add("@OUTPUTPGID", SqlDbType.NVarChar);
                        SqlParameter paraOutputPgClassId = sqlCommand.Parameters.Add("@OUTPUTPGCLASSID", SqlDbType.NVarChar);
                        SqlParameter paraOutputFormFileName = sqlCommand.Parameters.Add("@OUTPUTFORMFILENAME", SqlDbType.NVarChar);
                        SqlParameter paraEnterpriseNamePrtCd = sqlCommand.Parameters.Add("@ENTERPRISENAMEPRTCD", SqlDbType.Int);
                        SqlParameter paraPrtCirculation = sqlCommand.Parameters.Add("@PRTCIRCULATION", SqlDbType.Int);
                        SqlParameter paraSlipFormCd = sqlCommand.Parameters.Add("@SLIPFORMCD", SqlDbType.Int);
                        SqlParameter paraOutConfimationMsg = sqlCommand.Parameters.Add("@OUTCONFIMATIONMSG", SqlDbType.NVarChar);
                        SqlParameter paraOptionCode = sqlCommand.Parameters.Add("@OPTIONCODE", SqlDbType.NVarChar);
                        //SqlParameter paraPrinterMngNo = sqlCommand.Parameters.Add("@PRINTERMNGNO", SqlDbType.Int);
                        SqlParameter paraTopMargin = sqlCommand.Parameters.Add("@TOPMARGIN", SqlDbType.Float);
                        SqlParameter paraLeftMargin = sqlCommand.Parameters.Add("@LEFTMARGIN", SqlDbType.Float);
                        SqlParameter paraRightMargin = sqlCommand.Parameters.Add("@RIGHTMARGIN", SqlDbType.Float);
                        SqlParameter paraBottomMargin = sqlCommand.Parameters.Add("@BOTTOMMARGIN", SqlDbType.Float);
                        SqlParameter paraPrtPreviewExistCode = sqlCommand.Parameters.Add("@PRTPREVIEWEXISTCODE", SqlDbType.Int);
                        SqlParameter paraOutputPurpose = sqlCommand.Parameters.Add("@OUTPUTPURPOSE", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId1 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID1", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm1 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM1", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt1 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT1", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId2 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID2", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm2 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM2", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt2 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT2", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId3 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID3", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm3 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM3", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt3 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT3", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId4 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID4", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm4 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM4", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt4 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT4", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId5 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID5", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm5 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM5", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt5 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT5", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId6 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID6", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm6 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM6", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt6 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT6", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId7 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID7", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm7 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM7", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt7 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT7", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId8 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID8", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm8 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM8", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt8 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT8", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId9 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID9", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm9 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM9", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt9 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT9", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId10 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID10", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm10 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM10", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt10 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT10", SqlDbType.Int);
                        SqlParameter paraSlipFontName = sqlCommand.Parameters.Add("@SLIPFONTNAME", SqlDbType.NVarChar);
                        SqlParameter paraSlipFontSize = sqlCommand.Parameters.Add("@SLIPFONTSIZE", SqlDbType.Int);
                        SqlParameter paraSlipFontStyle = sqlCommand.Parameters.Add("@SLIPFONTSTYLE", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorRed1 = sqlCommand.Parameters.Add("@SLIPBASECOLORRED1", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorGrn1 = sqlCommand.Parameters.Add("@SLIPBASECOLORGRN1", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorBlu1 = sqlCommand.Parameters.Add("@SLIPBASECOLORBLU1", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorRed2 = sqlCommand.Parameters.Add("@SLIPBASECOLORRED2", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorGrn2 = sqlCommand.Parameters.Add("@SLIPBASECOLORGRN2", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorBlu2 = sqlCommand.Parameters.Add("@SLIPBASECOLORBLU2", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorRed3 = sqlCommand.Parameters.Add("@SLIPBASECOLORRED3", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorGrn3 = sqlCommand.Parameters.Add("@SLIPBASECOLORGRN3", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorBlu3 = sqlCommand.Parameters.Add("@SLIPBASECOLORBLU3", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorRed4 = sqlCommand.Parameters.Add("@SLIPBASECOLORRED4", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorGrn4 = sqlCommand.Parameters.Add("@SLIPBASECOLORGRN4", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorBlu4 = sqlCommand.Parameters.Add("@SLIPBASECOLORBLU4", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorRed5 = sqlCommand.Parameters.Add("@SLIPBASECOLORRED5", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorGrn5 = sqlCommand.Parameters.Add("@SLIPBASECOLORGRN5", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorBlu5 = sqlCommand.Parameters.Add("@SLIPBASECOLORBLU5", SqlDbType.Int);
                        SqlParameter paraCopyCount = sqlCommand.Parameters.Add("@COPYCOUNT", SqlDbType.Int);
                        SqlParameter paraTitleName1 = sqlCommand.Parameters.Add("@TITLENAME1", SqlDbType.NVarChar);
                        SqlParameter paraTitleName2 = sqlCommand.Parameters.Add("@TITLENAME2", SqlDbType.NVarChar);
                        SqlParameter paraTitleName3 = sqlCommand.Parameters.Add("@TITLENAME3", SqlDbType.NVarChar);
                        SqlParameter paraTitleName4 = sqlCommand.Parameters.Add("@TITLENAME4", SqlDbType.NVarChar);
                        SqlParameter paraSpecialPurpose1 = sqlCommand.Parameters.Add("@SPECIALPURPOSE1", SqlDbType.NVarChar);
                        SqlParameter paraSpecialPurpose2 = sqlCommand.Parameters.Add("@SPECIALPURPOSE2", SqlDbType.NVarChar);
                        SqlParameter paraSpecialPurpose3 = sqlCommand.Parameters.Add("@SPECIALPURPOSE3", SqlDbType.NVarChar);
                        SqlParameter paraSpecialPurpose4 = sqlCommand.Parameters.Add("@SPECIALPURPOSE4", SqlDbType.NVarChar);
                        //2006.12.06 deleted by T-Kidate
                        //SqlParameter paraBarCodeCarMngNoPrtCd = sqlCommand.Parameters.Add("@BARCODECARMNGNOPRTCD", SqlDbType.Int);
                        SqlParameter paraTitleName102 = sqlCommand.Parameters.Add("@TITLENAME102", SqlDbType.NVarChar);
                        SqlParameter paraTitleName103 = sqlCommand.Parameters.Add("@TITLENAME103", SqlDbType.NVarChar);
                        SqlParameter paraTitleName104 = sqlCommand.Parameters.Add("@TITLENAME104", SqlDbType.NVarChar);
                        SqlParameter paraTitleName105 = sqlCommand.Parameters.Add("@TITLENAME105", SqlDbType.NVarChar);
                        SqlParameter paraTitleName202 = sqlCommand.Parameters.Add("@TITLENAME202", SqlDbType.NVarChar);
                        SqlParameter paraTitleName203 = sqlCommand.Parameters.Add("@TITLENAME203", SqlDbType.NVarChar);
                        SqlParameter paraTitleName204 = sqlCommand.Parameters.Add("@TITLENAME204", SqlDbType.NVarChar);
                        SqlParameter paraTitleName205 = sqlCommand.Parameters.Add("@TITLENAME205", SqlDbType.NVarChar);
                        SqlParameter paraTitleName302 = sqlCommand.Parameters.Add("@TITLENAME302", SqlDbType.NVarChar);
                        SqlParameter paraTitleName303 = sqlCommand.Parameters.Add("@TITLENAME303", SqlDbType.NVarChar);
                        SqlParameter paraTitleName304 = sqlCommand.Parameters.Add("@TITLENAME304", SqlDbType.NVarChar);
                        SqlParameter paraTitleName305 = sqlCommand.Parameters.Add("@TITLENAME305", SqlDbType.NVarChar);
                        SqlParameter paraTitleName402 = sqlCommand.Parameters.Add("@TITLENAME402", SqlDbType.NVarChar);
                        SqlParameter paraTitleName403 = sqlCommand.Parameters.Add("@TITLENAME403", SqlDbType.NVarChar);
                        SqlParameter paraTitleName404 = sqlCommand.Parameters.Add("@TITLENAME404", SqlDbType.NVarChar);
                        SqlParameter paraTitleName405 = sqlCommand.Parameters.Add("@TITLENAME405", SqlDbType.NVarChar);
                        // 2008.05.23 add start ------------------------------------->>
                        SqlParameter paraNote1 = sqlCommand.Parameters.Add("@NOTE1", SqlDbType.NVarChar);
                        SqlParameter paraNote2 = sqlCommand.Parameters.Add("@NOTE2", SqlDbType.NVarChar);
                        SqlParameter paraNote3 = sqlCommand.Parameters.Add("@NOTE3", SqlDbType.NVarChar);
                        SqlParameter paraQRCodePrintDivCd = sqlCommand.Parameters.Add("QRCODEPRINTDIVCD", SqlDbType.Int);
                        SqlParameter paraTimePrintDivCd = sqlCommand.Parameters.Add("TIMEPRINTDIVCD", SqlDbType.Int);
                        SqlParameter paraReissueMark = sqlCommand.Parameters.Add("@REISSUEMARK", SqlDbType.NVarChar);
                        SqlParameter paraRefConsTaxDivCd = sqlCommand.Parameters.Add("REFCONSTAXDIVCD", SqlDbType.Int);
                        SqlParameter paraRefConsTaxPrtNm = sqlCommand.Parameters.Add("@REFCONSTAXPRTNM", SqlDbType.NVarChar);
                        SqlParameter paraDetailRowCount = sqlCommand.Parameters.Add("@DETAILROWCOUNT", SqlDbType.Int);
                        SqlParameter paraHonorificTitle = sqlCommand.Parameters.Add("@HONORIFICTITLE", SqlDbType.NVarChar);
                        SqlParameter paraConsTaxPrtCdRF = sqlCommand.Parameters.Add("@CONSTAXPRTCDRF ", SqlDbType.Int); // ADD 2008.12.11
                        // --- ADD 2009/12/31 ---------->>>>>
                        SqlParameter paraSlipNoteCharCnt = sqlCommand.Parameters.Add("@SLIPNOTECHARCNTRF ", SqlDbType.Int);
                        SqlParameter paraSlipNote2CharCnt = sqlCommand.Parameters.Add("@SLIPNOTE2CHARCNTRF ", SqlDbType.Int);
                        SqlParameter paraSlipNote3CharCnt = sqlCommand.Parameters.Add("@SLIPNOTE3CHARCNTRF ", SqlDbType.Int);
                        // --- ADD 2009/12/31 ----------<<<<<
                        // 2008.05.23 add end ---------------------------------------<<
                        SqlParameter paraENTNMPRTEXPDIV = sqlCommand.Parameters.Add("@ENTNMPRTEXPDIVRF ", SqlDbType.Int); // ADD 2011/02/16
                        // --- ADD 2011/07/19 ---------->>>>>
                        SqlParameter paraSCMAnsMarkPrtDiv = sqlCommand.Parameters.Add("@SCMANSMARKPRTDIVRF ", SqlDbType.Int);
                        SqlParameter paraNormalPrtMark = sqlCommand.Parameters.Add("@NORMALPRTMARKRF", SqlDbType.NVarChar);
                        SqlParameter paraSCMManualAnsMark = sqlCommand.Parameters.Add("@SCMMANUALANSMARKRF", SqlDbType.NVarChar);
                        SqlParameter paraSCMAutoAnsMark = sqlCommand.Parameters.Add("@SCMAUTOANSMARKRF", SqlDbType.NVarChar);
                        // --- ADD 2011/07/19 ----------<<<<<

                        //2006.12.06 deleted by T-Kidate
                        //SqlParameter paraMainWorkLinePrtDivCd = sqlCommand.Parameters.Add("@MAINWORKLINEPRTDIVCD", SqlDbType.Int);

                        // �� 2007.12.19 980081 d
                        ////2006.12.08 added by T-Kidate
                        //SqlParameter paraContractNoPrtDivCd = sqlCommand.Parameters.Add("@CONTRACTNOPRTDIVCD", SqlDbType.Int);
                        //SqlParameter paraContCpNoPrtDivCd = sqlCommand.Parameters.Add("@CONTCPNOPRTDIVCD", SqlDbType.Int);
                        // �� 2007.12.19 980081 d

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(slipPrtSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(slipPrtSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(slipPrtSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.LogicalDeleteCode);
                        paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.DataInputSystem);
                        paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipPrtKind);
                        paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipPrtSetPaperId);
                        paraSlipComment.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipComment);
                        paraOutputPgId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.OutputPgId);
                        paraOutputPgClassId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.OutputPgClassId);
                        paraOutputFormFileName.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.OutputFormFileName);
                        paraEnterpriseNamePrtCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EnterpriseNamePrtCd);
                        paraPrtCirculation.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.PrtCirculation);
                        paraSlipFormCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipFormCd);
                        paraOutConfimationMsg.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.OutConfimationMsg);
                        paraOptionCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.OptionCode);
                        //paraPrinterMngNo.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.PrinterMngNo);
                        paraTopMargin.Value = SqlDataMediator.SqlSetDouble(slipPrtSetWork.TopMargin);
                        paraLeftMargin.Value = SqlDataMediator.SqlSetDouble(slipPrtSetWork.LeftMargin);
                        paraRightMargin.Value = SqlDataMediator.SqlSetDouble(slipPrtSetWork.RightMargin);
                        paraBottomMargin.Value = SqlDataMediator.SqlSetDouble(slipPrtSetWork.BottomMargin);
                        paraPrtPreviewExistCode.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.PrtPreviewExistCode);
                        paraOutputPurpose.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.OutputPurpose);
                        paraEachSlipTypeColId1.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId1);
                        paraEachSlipTypeColNm1.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm1);
                        paraEachSlipTypeColPrt1.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt1);
                        paraEachSlipTypeColId2.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId2);
                        paraEachSlipTypeColNm2.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm2);
                        paraEachSlipTypeColPrt2.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt2);
                        paraEachSlipTypeColId3.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId3);
                        paraEachSlipTypeColNm3.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm3);
                        paraEachSlipTypeColPrt3.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt3);
                        paraEachSlipTypeColId4.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId4);
                        paraEachSlipTypeColNm4.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm4);
                        paraEachSlipTypeColPrt4.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt4);
                        paraEachSlipTypeColId5.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId5);
                        paraEachSlipTypeColNm5.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm5);
                        paraEachSlipTypeColPrt5.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt5);
                        paraEachSlipTypeColId6.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId6);
                        paraEachSlipTypeColNm6.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm6);
                        paraEachSlipTypeColPrt6.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt6);
                        paraEachSlipTypeColId7.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId7);
                        paraEachSlipTypeColNm7.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm7);
                        paraEachSlipTypeColPrt7.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt7);
                        paraEachSlipTypeColId8.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId8);
                        paraEachSlipTypeColNm8.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm8);
                        paraEachSlipTypeColPrt8.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt8);
                        paraEachSlipTypeColId9.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId9);
                        paraEachSlipTypeColNm9.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm9);
                        paraEachSlipTypeColPrt9.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt9);
                        paraEachSlipTypeColId10.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId10);
                        paraEachSlipTypeColNm10.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm10);
                        paraEachSlipTypeColPrt10.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt10);
                        paraSlipFontName.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipFontName);
                        paraSlipFontSize.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipFontSize);
                        paraSlipFontStyle.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipFontStyle);
                        paraSlipBaseColorRed1.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorRed1);
                        paraSlipBaseColorGrn1.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorGrn1);
                        paraSlipBaseColorBlu1.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorBlu1);
                        paraSlipBaseColorRed2.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorRed2);
                        paraSlipBaseColorGrn2.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorGrn2);
                        paraSlipBaseColorBlu2.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorBlu2);
                        paraSlipBaseColorRed3.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorRed3);
                        paraSlipBaseColorGrn3.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorGrn3);
                        paraSlipBaseColorBlu3.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorBlu3);
                        paraSlipBaseColorRed4.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorRed4);
                        paraSlipBaseColorGrn4.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorGrn4);
                        paraSlipBaseColorBlu4.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorBlu4);
                        paraSlipBaseColorRed5.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorRed5);
                        paraSlipBaseColorGrn5.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorGrn5);
                        paraSlipBaseColorBlu5.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorBlu5);
                        paraCopyCount.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.CopyCount);
                        paraTitleName1.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName1);
                        paraTitleName2.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName2);
                        paraTitleName3.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName3);
                        paraTitleName4.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName4);
                        paraSpecialPurpose1.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SpecialPurpose1);
                        paraSpecialPurpose2.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SpecialPurpose2);
                        paraSpecialPurpose3.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SpecialPurpose3);
                        paraSpecialPurpose4.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SpecialPurpose4);
                        //2006.12.06 deleted by T-Kidate
                        //paraBarCodeCarMngNoPrtCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.BarCodeCarMngNoPrtCd);
                        paraTitleName102.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName102);
                        paraTitleName103.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName103);
                        paraTitleName104.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName104);
                        paraTitleName105.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName105);
                        paraTitleName202.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName202);
                        paraTitleName203.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName203);
                        paraTitleName204.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName204);
                        paraTitleName205.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName205);
                        paraTitleName302.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName302);
                        paraTitleName303.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName303);
                        paraTitleName304.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName304);
                        paraTitleName305.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName305);
                        paraTitleName402.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName402);
                        paraTitleName403.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName403);
                        paraTitleName404.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName404);
                        paraTitleName405.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName405);
                        // 2008.05.23 add start ------------------------------------------>>
                        paraNote1.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.Note1);
                        paraNote2.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.Note2);
                        paraNote3.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.Note3);
                        paraQRCodePrintDivCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.QRCodePrintDivCd);
                        paraTimePrintDivCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.TimePrintDivCd);
                        paraReissueMark.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.ReissueMark);
                        paraRefConsTaxDivCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.RefConsTaxDivCd);
                        paraRefConsTaxPrtNm.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.RefConsTaxPrtNm);
                        paraDetailRowCount.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.DetailRowCount);
                        paraHonorificTitle.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.HonorificTitle);
                        paraConsTaxPrtCdRF.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.ConsTaxPrtCdRF); // ADD 2008.12.11
                        // --- ADD 2009/12/31 ---------->>>>>
                        paraSlipNoteCharCnt.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipNoteCharCnt);
                        paraSlipNote2CharCnt.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipNote2CharCnt);
                        paraSlipNote3CharCnt.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipNote3CharCnt);
                        // --- ADD 2009/12/31 ----------<<<<<

                        // 2008.05.23 add end --------------------------------------------<<
                        paraENTNMPRTEXPDIV.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EntNmPrtExpDiv); // ADD 2011/02/16

                        // --- ADD 2011/07/19 ---------->>>>>
                        paraSCMAnsMarkPrtDiv.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SCMAnsMarkPrtDiv);
                        paraNormalPrtMark.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.NormalPrtMark);
                        paraSCMManualAnsMark.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SCMManualAnsMark);
                        paraSCMAutoAnsMark.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SCMAutoAnsMark);
                        // --- ADD 2011/07/19 ----------<<<<<

                        //2006.12.06 deleted by T-Kidate
                        //paraMainWorkLinePrtDivCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.MainWorkLinePrtDivCd);

                        // �� 2007.12.19 980081 d
                        ////2006.12.08 added by T-Kidate
                        //paraContractNoPrtDivCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.ContractNoPrtDivCd);
                        //paraContCpNoPrtDivCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.ContCpNoPrtDivCd);
                        // �� 2007.12.19 980081 d

                        sqlCommand.ExecuteNonQuery();

                        // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                        parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);

                        // --- ADD 2010/08/06 -------------------------------------------->>>>>
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                        // �f�[�^�X�V���e�}�X�^�̍��ڂ��X�V����
                        //���Ӑ�}�X�^
                        if (!String.IsNullOrEmpty(slipPrtSetWork.SlipPrtSetPaperId) && (slipPrtSetWork.CustomerCode != 0))
                        {
                            //���Ӑ�}�X�^�Ƀf�[�^���X�V����
                            CustomerDB customerDB = new CustomerDB();
                            ArrayList duplicationItemList;
                            CustomerWork customerWork = new CustomerWork();
                            customerWork.CustomerCode = slipPrtSetWork.CustomerCode;
                            customerWork.EnterpriseCode = slipPrtSetWork.EnterpriseCode;
                            customerWork.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;
                            ArrayList paraCustomList = new ArrayList();

                            paraCustomList.Add(customerWork);

                            object objParaCustomList = paraCustomList as object;

                            customerDB.Search(ConstantManagement.LogicalMode.GetData0, ref objParaCustomList);

                            CustomerWork CustomerWorkSave = new CustomerWork();

                            if (objParaCustomList != null)
                            {
                                ArrayList paraCustomListRlt = objParaCustomList as ArrayList;
                                if (paraCustomListRlt.Count > 0)
                                {
                                    foreach (CustomerWork customerWorkSave in paraCustomListRlt)
                                    {
                                        if (customerWorkSave.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0)
                                        {
                                            status = -1;
                                            return status;
                                        }
                                        //-----UPD 2010/08/17---------->>>>>
                                        //if (slipPrtSetWork.SlipPrtKind == 10)
                                        if (slipPrtSetWork.SlipPrtKind == 140)
                                        //-----UPD 2010/08/17----------<<<<<
                                        {
                                            customerWorkSave.EstimatePrtDiv = 2;
                                        }
                                        else if (slipPrtSetWork.SlipPrtKind == 120)
                                        {
                                            customerWorkSave.AcpOdrrSlipPrtDiv = 2;
                                        }
                                        else if (slipPrtSetWork.SlipPrtKind == 130)
                                        {
                                            customerWorkSave.ShipmSlipPrtDiv = 2;
                                        }
                                        else if (slipPrtSetWork.SlipPrtKind == 160)
                                        {
                                            customerWorkSave.UOESlipPrtDiv = 2;
                                        }
                                        else if (slipPrtSetWork.SlipPrtKind == 30)
                                        {
                                            customerWorkSave.SalesSlipPrtDiv = 2;
                                        }
                                    }
                                    object obj = objParaCustomList as object;

                                    status = customerDB.Write(ref obj, out duplicationItemList);
                                }
                                else
                                {
                                    status = -1;
                                    return status;
                                }
                            }
                            if (status != 0)
                            {
                                return status;
                            }
                        }

                        //�`�[�ݒ�
                        if (slipPrtSetWork.CustomerCode != 0 && slipPrtSetWork.UpdateFlag == 1)
                        {
                            //�`�[�ݒ�f�[�^�X�V����
                            CustSlipMngDB custSlipMngDB = new CustSlipMngDB();
                            CustSlipMngWork custSlipMngWorkPara = new CustSlipMngWork();
                            custSlipMngWorkPara.EnterpriseCode = slipPrtSetWork.EnterpriseCode;
                            custSlipMngWorkPara.DataInputSystem = slipPrtSetWork.DataInputSystem;
                            custSlipMngWorkPara.SlipPrtKind = slipPrtSetWork.SlipPrtKind;
                            custSlipMngWorkPara.CustomerCode = slipPrtSetWork.CustomerCode;

                            object objCSMWork;
                            object obj = custSlipMngWorkPara as object;
                            custSlipMngDB.Search(out objCSMWork, obj, 0, ConstantManagement.LogicalMode.GetDataAll);

                            ArrayList pCSMWorkList = objCSMWork as ArrayList;
                            CustSlipMngWork custSlipMngWork = new CustSlipMngWork();
                            if (pCSMWorkList.Count > 0)
                            {
                                foreach (CustSlipMngWork custSlipMngWorkRlt in pCSMWorkList)
                                {
                                    custSlipMngWorkRlt.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;
                                    custSlipMngWorkRlt.SlipPrtSetPaperId = slipPrtSetWork.SlipPrtSetPaperId;
                                }

                                object objCustSlipMngWorkUpd = pCSMWorkList as object;

                                status = custSlipMngDB.Write(ref objCustSlipMngWorkUpd);
                            }
                            else
                            {
                                custSlipMngWork = custSlipMngWorkPara;
                                custSlipMngWork.SectionCode = "0";
                                custSlipMngWork.SlipPrtSetPaperId = slipPrtSetWork.SlipPrtSetPaperId;

                                object objCustSlipMngWork = custSlipMngWork as object;

                                status = custSlipMngDB.Write(ref objCustSlipMngWork);
                            }
                            if (status != 0)
                            {
                                return status;
                            }
                        }

                        // --- ADD 2010/08/06 ------------------------------------------<<<<<
                    }
                    // --- DEL 2010/08/06 ------------------------------------------>>>>>
                    //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // --- DEL 2010/08/06 ------------------------------------------<<<<<
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }
                // --- ADD 2010/08/06 ------------------------------------------>>>>>
                finally
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        sqlTransaction.Rollback();
                    }
                }
                // --- ADD 2010/08/06 ------------------------------------------<<<<<
				if(myReader.IsClosed == false)myReader.Close();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 DEL
                //sqlConnection.Close();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 ADD
                if ( !execFromParent )
                {
                    sqlConnection.Close();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 ADD
            }
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "SlipPrtSetDB.Write" );
			}

			return status;
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 ADD
        /// <summary>
        /// �������ݏ����i�t�h�����ɒ񋟂���@�\�j
        /// </summary>
        /// <param name="parabyte"></param>
        /// <returns></returns>
        public int Write( ref byte[] parabyte )
        {
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            return Write( ref parabyte, ref sqlConnection, ref sqlTransaction );
        }

        /// <summary>
        /// �ꊇ�������ݏ����i�������[�g�����ɒ񋟂���@�\�j
        /// </summary>
        /// <param name="slipPrtSetList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int Write( List<SlipPrtSetWork> slipPrtSetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int result = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            foreach ( SlipPrtSetWork slipPrtSetWork in slipPrtSetList )
            {
                // XML�֕ϊ����A������̃o�C�i�����j
                Byte[] parabyte = XmlByteSerializer.Serialize( slipPrtSetWork );

                // 1����������
                int status = Write( ref parabyte, ref sqlConnection, ref sqlTransaction );
                if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    result = status;
                    break;
                }
            }

            return result;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 ADD

		#endregion 

		#region LogicalDelete & RevivalLogicalDelete

		/// <summary>
		/// �`�[����ݒ����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">SlipPrtSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �`�[����ݒ����_���폜���܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.08.30</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
			try
			{
				return LogicalDeleteProc(ref parabyte,0);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "SlipPrtSetDB.LogicalDelete" );
				return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
		}

		/// <summary>
		/// �_���폜�`�[����ݒ���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">SlipPrtSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�`�[����ݒ���𕜊����܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.08.30</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
			try
			{
				return LogicalDeleteProc(ref parabyte,1);
			}
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "SlipPrtSetDB.RevivalLogicalDelete");
				return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
		}

		/// <summary>
		/// �`�[����ݒ���̘_���폜�𑀍삵�܂�
		/// </summary>
		/// <param name="parabyte">SlipPrtSetWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �`�[����ݒ���̘_���폜�𑀍삵�܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.08.30</br>
		private int LogicalDeleteProc(ref byte[] parabyte,int procMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

			try		
			{
				//���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				// XML�̓ǂݍ���
				SlipPrtSetWork slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SlipPrtSetWork));

				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

                // 2008.05.23 upd start -------------------------------------------------->>
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SLIPPRTSETPAPERIDRF FROM SLIPPRTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID", sqlConnection))
				string sqlTxt = string.Empty;
                sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                sqlTxt += " FROM SLIPPRTSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                using(SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.23 upd end ----------------------------------------------------<<
                {
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
					SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
					SqlParameter findParaSlipPrtSetPaperId = sqlCommand.Parameters.Add("@FINDSLIPPRTSETPAPERID", SqlDbType.NVarChar);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EnterpriseCode);
					findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.DataInputSystem);
					findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipPrtKind);
					findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipPrtSetPaperId);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
						if (_updateDateTime != slipPrtSetWork.UpdateDateTime)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
							sqlConnection.Close();
							return status;
						}
						//���݂̘_���폜�敪���擾
						logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                        // 2008.05.23 upd start ------------------------------------------------->>
						//sqlCommand.CommandText = "UPDATE SLIPPRTSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID";
                        sqlTxt = string.Empty;
                        sqlTxt += "UPDATE SLIPPRTSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                        sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                        sqlCommand.CommandText = sqlTxt;
                        // 2008.05.23 upd end ---------------------------------------------------<<

                        //KEY�R�}���h���Đݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EnterpriseCode);
						findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.DataInputSystem);
						findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipPrtKind);
						findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipPrtSetPaperId);

						//�X�V�w�b�_����ݒ�
						object obj = (object)this;
						IFileHeader flhd = (IFileHeader)slipPrtSetWork;
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
						else if	(logicalDelCd == 0)	slipPrtSetWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
						else						slipPrtSetWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
					}
					else
					{
						if		(logicalDelCd == 1)	slipPrtSetWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
					paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(slipPrtSetWork.UpdateDateTime);
					paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.UpdEmployeeCode);
					paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.UpdAssemblyId1);
					paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.UpdAssemblyId2);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.LogicalDeleteCode);

					sqlCommand.ExecuteNonQuery();

					// XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
					parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);
				}
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
				
			if(myReader.IsClosed == false)myReader.Close();
			sqlConnection.Close();

			return status;

		}
		#endregion

		#region Delete

		/// <summary>
		/// �`�[����ݒ���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">�`�[����ݒ�I�u�W�F�N�g</param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
		/// <returns></returns>
		/// <br>Note       : �`�[����ݒ���𕨗��폜���܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.08.30</br>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 DEL
        //public int Delete(byte[] parabyte)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 ADD
        private int Delete( byte[] parabyte, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 ADD
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 ADD
            bool execFromParent = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 ADD
            try
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 DEL
                //SqlConnection sqlConnection = null;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 DEL
                SqlDataReader myReader = null;

   				try 
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 DEL
                    ////���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    //string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                    //if ( connectionText == null || connectionText == "" ) return status;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 ADD
                    if ( sqlConnection == null )
                    {
                        //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                        SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                        string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                        if ( connectionText == null || connectionText == "" ) return status;

                        sqlConnection = new SqlConnection( connectionText );
                        sqlConnection.Open();

                        execFromParent = false;
                    }
                    else
                    {
                        execFromParent = true;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 ADD

					SlipPrtSetWork slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SlipPrtSetWork));

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 DEL
                    //sqlConnection = new SqlConnection(connectionText);
                    //sqlConnection.Open();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 DEL

                    // 2008.05.23 upd start----------------------------------------------->>
					//using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SLIPPRTSETPAPERIDRF FROM SLIPPRTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID", sqlConnection))
					string sqlTxt = string.Empty;
                    sqlTxt += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                    sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                    sqlTxt += " FROM SLIPPRTSETRF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                    sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                    sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                    using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                    // 2008.05.23 upd end ------------------------------------------------<<
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 ADD
                        if ( sqlTransaction != null )
                        {
                            sqlCommand.Transaction = sqlTransaction;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 ADD

						//Prameter�I�u�W�F�N�g�̍쐬
						SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
						SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
						SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
						SqlParameter findParaSlipPrtSetPaperId = sqlCommand.Parameters.Add("@FINDSLIPPRTSETPAPERID", SqlDbType.NVarChar);

						//Parameter�I�u�W�F�N�g�֒l�ݒ�
						findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EnterpriseCode);
						findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.DataInputSystem);
						findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipPrtKind);
						findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipPrtSetPaperId);

						myReader = sqlCommand.ExecuteReader();
						if(myReader.Read())
						{
							//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
							DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
							if (_updateDateTime != slipPrtSetWork.UpdateDateTime)
							{
								status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
								sqlCommand.Cancel();
								if(!myReader.IsClosed)myReader.Close();
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 DEL
                                //sqlConnection.Close();
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 ADD
                                if ( !execFromParent )
                                {
                                    sqlConnection.Close();
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 ADD
                                return status;
							}

                            // 2008.05.23 upd start --------------------------------------------->>
							//sqlCommand.CommandText = "DELETE FROM SLIPPRTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID";							
                            sqlTxt = string.Empty;
                            sqlTxt += "DELETE" + Environment.NewLine;
                            sqlTxt += " FROM SLIPPRTSETRF" + Environment.NewLine;
                            sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                            sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                            sqlCommand.CommandText = sqlTxt;
                            // 2008.05.23 upd end -----------------------------------------------<<
                            //KEY�R�}���h���Đݒ�
							findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EnterpriseCode);
							findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.DataInputSystem);
							findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipPrtKind);
							findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipPrtSetPaperId);
						}
						else
						{
							//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
							sqlCommand.Cancel();
							if(!myReader.IsClosed)myReader.Close();
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 DEL
                            //sqlConnection.Close();
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 ADD
                            if ( !execFromParent )
                            {
                                sqlConnection.Close();
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 ADD
                            return status;
						}
						if(!myReader.IsClosed)myReader.Close();

						sqlCommand.ExecuteNonQuery();
					}
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
				catch (SqlException ex) 
				{
					//���N���X�ɗ�O��n���ď������Ă��炤
					status = base.WriteSQLErrorLog(ex);
				}
				
				if(myReader.IsClosed == false)myReader.Close();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 DEL
                //sqlConnection.Close();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 ADD
                if ( !execFromParent )
                {
                    sqlConnection.Close();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 ADD
            }
			catch(Exception ex)
			{
				base.WriteErrorLog( ex , "SlipPrtSetDB.Delete" );
			}
			return status;
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/27 ADD
        /// <summary>
        /// �폜�����i�t�h�����ɒ񋟂���@�\�j
        /// </summary>
        /// <param name="parabyte"></param>
        /// <returns></returns>
        public int Delete( byte[] parabyte )
        {
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            return Delete( parabyte, ref sqlConnection, ref sqlTransaction );
        }
        /// <summary>
        /// �폜�����i�������[�g�ɒ񋟂���@�\�j
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="dataInputSystem"></param>
        /// <param name="slipPrtKind"></param>
        /// <param name="slipPrtSetPaperId"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int Delete( string enterpriseCode, int dataInputSystem, int slipPrtKind, string slipPrtSetPaperId, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            SlipPrtSetWork paraWork = new SlipPrtSetWork();
            paraWork.EnterpriseCode = enterpriseCode;
            paraWork.DataInputSystem = dataInputSystem;
            paraWork.SlipPrtKind = slipPrtKind;
            paraWork.SlipPrtSetPaperId = slipPrtSetPaperId;
            // XML�֕ϊ����A������̃o�C�i�����j
            Byte[] parabyte = XmlByteSerializer.Serialize( paraWork );

            int readMode = 0;   // �����敪������͖��g�p�Ȃ̂Ń[���Œ�
            int status = Read( ref parabyte, readMode );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && paraWork != null )
            {
                return Delete( parabyte, ref sqlConnection, ref sqlTransaction );
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/27 ADD

        #endregion
        // �� 2008.02.12 980081 a
        #region [GetSyncdataList]
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata"></param>
        /// <param name="syncServiceWork"></param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓`�[����ݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.10</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata"></param>
        /// <param name="syncServiceWork"></param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓`�[����ݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.10</br>
        /// <br>Update Note: 2011/02/16  ���N�n��</br>
        /// <br>             ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {            
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            SlipPrtSetWork slipPrtSetWork = null;

            ArrayList al = new ArrayList();
            try
            {
                // 2008.05.23 upd start -------------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM SLIPPRTSETRF ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPCOMMENTRF" + Environment.NewLine;
                sqlTxt += "    ,OUTPUTPGIDRF" + Environment.NewLine;
                sqlTxt += "    ,OUTPUTPGCLASSIDRF" + Environment.NewLine;
                sqlTxt += "    ,OUTPUTFORMFILENAMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISENAMEPRTCDRF" + Environment.NewLine;
                sqlTxt += "    ,PRTCIRCULATIONRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPFORMCDRF" + Environment.NewLine;
                sqlTxt += "    ,OUTCONFIMATIONMSGRF" + Environment.NewLine;
                sqlTxt += "    ,OPTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,TOPMARGINRF" + Environment.NewLine;
                sqlTxt += "    ,LEFTMARGINRF" + Environment.NewLine;
                sqlTxt += "    ,RIGHTMARGINRF" + Environment.NewLine;
                sqlTxt += "    ,BOTTOMMARGINRF" + Environment.NewLine;
                sqlTxt += "    ,PRTPREVIEWEXISTCODERF" + Environment.NewLine;
                sqlTxt += "    ,OUTPUTPURPOSERF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID1RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM1RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT1RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID2RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM2RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT2RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID3RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM3RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT3RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID4RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM4RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT4RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID5RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM5RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT5RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID6RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM6RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT6RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID7RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM7RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT7RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID8RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM8RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT8RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID9RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM9RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT9RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID10RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM10RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT10RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPFONTNAMERF" + Environment.NewLine;
                sqlTxt += "    ,SLIPFONTSIZERF" + Environment.NewLine;
                sqlTxt += "    ,SLIPFONTSTYLERF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORRED1RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORGRN1RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORBLU1RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORRED2RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORGRN2RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORBLU2RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORRED3RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORGRN3RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORBLU3RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORRED4RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORGRN4RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORBLU4RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORRED5RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORGRN5RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORBLU5RF" + Environment.NewLine;
                sqlTxt += "    ,COPYCOUNTRF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME1RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME2RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME3RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME4RF" + Environment.NewLine;
                sqlTxt += "    ,SPECIALPURPOSE1RF" + Environment.NewLine;
                sqlTxt += "    ,SPECIALPURPOSE2RF" + Environment.NewLine;
                sqlTxt += "    ,SPECIALPURPOSE3RF" + Environment.NewLine;
                sqlTxt += "    ,SPECIALPURPOSE4RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME102RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME103RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME104RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME105RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME202RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME203RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME204RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME205RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME302RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME303RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME304RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME305RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME402RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME403RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME404RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME405RF" + Environment.NewLine;
                sqlTxt += "    ,NOTE1RF" + Environment.NewLine;
                sqlTxt += "    ,NOTE2RF" + Environment.NewLine;
                sqlTxt += "    ,NOTE3RF" + Environment.NewLine;
                sqlTxt += "    ,QRCODEPRINTDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,TIMEPRINTDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,REISSUEMARKRF" + Environment.NewLine;
                sqlTxt += "    ,REFCONSTAXDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,REFCONSTAXPRTNMRF" + Environment.NewLine;
                sqlTxt += "    ,DETAILROWCOUNTRF" + Environment.NewLine;
                sqlTxt += "    ,HONORIFICTITLERF" + Environment.NewLine;
                sqlTxt += "    ,CONSTAXPRTCDRF" + Environment.NewLine; // ADD 2008.12.11
                // --- ADD 2009/12/31 ---------->>>>>
                sqlTxt += "    ,SLIPNOTECHARCNTRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPNOTE2CHARCNTRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPNOTE3CHARCNTRF" + Environment.NewLine;
                // --- ADD 2009/12/31 ----------<<<<<
                sqlTxt += "    ,ENTNMPRTEXPDIVRF" + Environment.NewLine; // ADD 2011/02/16
                // --- ADD 2011/07/19 ---------->>>>>
                sqlTxt += "    ,SCMANSMARKPRTDIVRF" + Environment.NewLine;
                sqlTxt += "    ,NORMALPRTMARKRF" + Environment.NewLine;
                sqlTxt += "    ,SCMMANUALANSMARKRF" + Environment.NewLine;
                sqlTxt += "    ,SCMAUTOANSMARKRF" + Environment.NewLine;
                // --- ADD 2011/07/19 ----------<<<<<
                sqlTxt += " FROM SLIPPRTSETRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.23 upd end ----------------------------------<<

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    slipPrtSetWork = new SlipPrtSetWork();
                    slipPrtSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    slipPrtSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    slipPrtSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    slipPrtSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    slipPrtSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    slipPrtSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    slipPrtSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    slipPrtSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    slipPrtSetWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
                    slipPrtSetWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRTKINDRF"));
                    slipPrtSetWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
                    slipPrtSetWork.SlipComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPCOMMENTRF"));
                    slipPrtSetWork.OutputPgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGIDRF"));
                    slipPrtSetWork.OutputPgClassId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGCLASSIDRF"));
                    slipPrtSetWork.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
                    slipPrtSetWork.EnterpriseNamePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISENAMEPRTCDRF"));
                    slipPrtSetWork.PrtCirculation = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTCIRCULATIONRF"));
                    slipPrtSetWork.SlipFormCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPFORMCDRF"));
                    slipPrtSetWork.OutConfimationMsg = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTCONFIMATIONMSGRF"));
                    slipPrtSetWork.OptionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OPTIONCODERF"));
                    //slipPrtSetWork.PrinterMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTERMNGNORF"));
                    slipPrtSetWork.TopMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOPMARGINRF"));
                    slipPrtSetWork.LeftMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LEFTMARGINRF"));
                    slipPrtSetWork.RightMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RIGHTMARGINRF"));
                    slipPrtSetWork.BottomMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BOTTOMMARGINRF"));
                    slipPrtSetWork.PrtPreviewExistCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTPREVIEWEXISTCODERF"));
                    slipPrtSetWork.OutputPurpose = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTPURPOSERF"));
                    slipPrtSetWork.EachSlipTypeColId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID1RF"));
                    slipPrtSetWork.EachSlipTypeColNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM1RF"));
                    slipPrtSetWork.EachSlipTypeColPrt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT1RF"));
                    slipPrtSetWork.EachSlipTypeColId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID2RF"));
                    slipPrtSetWork.EachSlipTypeColNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM2RF"));
                    slipPrtSetWork.EachSlipTypeColPrt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT2RF"));
                    slipPrtSetWork.EachSlipTypeColId3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID3RF"));
                    slipPrtSetWork.EachSlipTypeColNm3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM3RF"));
                    slipPrtSetWork.EachSlipTypeColPrt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT3RF"));
                    slipPrtSetWork.EachSlipTypeColId4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID4RF"));
                    slipPrtSetWork.EachSlipTypeColNm4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM4RF"));
                    slipPrtSetWork.EachSlipTypeColPrt4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT4RF"));
                    slipPrtSetWork.EachSlipTypeColId5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID5RF"));
                    slipPrtSetWork.EachSlipTypeColNm5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM5RF"));
                    slipPrtSetWork.EachSlipTypeColPrt5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT5RF"));
                    slipPrtSetWork.EachSlipTypeColId6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID6RF"));
                    slipPrtSetWork.EachSlipTypeColNm6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM6RF"));
                    slipPrtSetWork.EachSlipTypeColPrt6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT6RF"));
                    slipPrtSetWork.EachSlipTypeColId7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID7RF"));
                    slipPrtSetWork.EachSlipTypeColNm7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM7RF"));
                    slipPrtSetWork.EachSlipTypeColPrt7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT7RF"));
                    slipPrtSetWork.EachSlipTypeColId8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID8RF"));
                    slipPrtSetWork.EachSlipTypeColNm8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM8RF"));
                    slipPrtSetWork.EachSlipTypeColPrt8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT8RF"));
                    slipPrtSetWork.EachSlipTypeColId9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID9RF"));
                    slipPrtSetWork.EachSlipTypeColNm9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM9RF"));
                    slipPrtSetWork.EachSlipTypeColPrt9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT9RF"));
                    slipPrtSetWork.EachSlipTypeColId10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID10RF"));
                    slipPrtSetWork.EachSlipTypeColNm10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM10RF"));
                    slipPrtSetWork.EachSlipTypeColPrt10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT10RF"));
                    slipPrtSetWork.SlipFontName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPFONTNAMERF"));
                    slipPrtSetWork.SlipFontSize = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPFONTSIZERF"));
                    slipPrtSetWork.SlipFontStyle = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPFONTSTYLERF"));
                    slipPrtSetWork.SlipBaseColorRed1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED1RF"));
                    slipPrtSetWork.SlipBaseColorGrn1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN1RF"));
                    slipPrtSetWork.SlipBaseColorBlu1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU1RF"));
                    slipPrtSetWork.SlipBaseColorRed2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED2RF"));
                    slipPrtSetWork.SlipBaseColorGrn2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN2RF"));
                    slipPrtSetWork.SlipBaseColorBlu2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU2RF"));
                    slipPrtSetWork.SlipBaseColorRed3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED3RF"));
                    slipPrtSetWork.SlipBaseColorGrn3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN3RF"));
                    slipPrtSetWork.SlipBaseColorBlu3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU3RF"));
                    slipPrtSetWork.SlipBaseColorRed4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED4RF"));
                    slipPrtSetWork.SlipBaseColorGrn4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN4RF"));
                    slipPrtSetWork.SlipBaseColorBlu4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU4RF"));
                    slipPrtSetWork.SlipBaseColorRed5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED5RF"));
                    slipPrtSetWork.SlipBaseColorGrn5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN5RF"));
                    slipPrtSetWork.SlipBaseColorBlu5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU5RF"));
                    slipPrtSetWork.CopyCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COPYCOUNTRF"));
                    slipPrtSetWork.TitleName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME1RF"));
                    slipPrtSetWork.TitleName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME2RF"));
                    slipPrtSetWork.TitleName3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME3RF"));
                    slipPrtSetWork.TitleName4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME4RF"));
                    slipPrtSetWork.SpecialPurpose1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE1RF"));
                    slipPrtSetWork.SpecialPurpose2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE2RF"));
                    slipPrtSetWork.SpecialPurpose3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE3RF"));
                    slipPrtSetWork.SpecialPurpose4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE4RF"));
                    slipPrtSetWork.TitleName102 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME102RF"));
                    slipPrtSetWork.TitleName103 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME103RF"));
                    slipPrtSetWork.TitleName104 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME104RF"));
                    slipPrtSetWork.TitleName105 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME105RF"));
                    slipPrtSetWork.TitleName202 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME202RF"));
                    slipPrtSetWork.TitleName203 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME203RF"));
                    slipPrtSetWork.TitleName204 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME204RF"));
                    slipPrtSetWork.TitleName205 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME205RF"));
                    slipPrtSetWork.TitleName302 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME302RF"));
                    slipPrtSetWork.TitleName303 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME303RF"));
                    slipPrtSetWork.TitleName304 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME304RF"));
                    slipPrtSetWork.TitleName305 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME305RF"));
                    slipPrtSetWork.TitleName402 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME402RF"));
                    slipPrtSetWork.TitleName403 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME403RF"));
                    slipPrtSetWork.TitleName404 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME404RF"));
                    slipPrtSetWork.TitleName405 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME405RF"));
                    // 2008.05.23 add start ---------------------------------------------------------------->>
                    slipPrtSetWork.Note1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
                    slipPrtSetWork.Note2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
                    slipPrtSetWork.Note3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
                    slipPrtSetWork.QRCodePrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("QRCODEPRINTDIVCDRF"));
                    slipPrtSetWork.TimePrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TIMEPRINTDIVCDRF"));
                    slipPrtSetWork.ReissueMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REISSUEMARKRF"));
                    slipPrtSetWork.RefConsTaxDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REFCONSTAXDIVCDRF"));
                    slipPrtSetWork.RefConsTaxPrtNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REFCONSTAXPRTNMRF"));
                    slipPrtSetWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
                    slipPrtSetWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                    // 2008.05.23 add end ------------------------------------------------------------------<<
                    slipPrtSetWork.ConsTaxPrtCdRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXPRTCDRF")); // ADD 2008.12.11
                    // --- ADD 2009/12/31 ---------->>>>>
                    slipPrtSetWork.SlipNoteCharCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPNOTECHARCNTRF"));
                    slipPrtSetWork.SlipNote2CharCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPNOTE2CHARCNTRF"));
                    slipPrtSetWork.SlipNote3CharCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPNOTE3CHARCNTRF"));
                    // --- ADD 2009/12/31 ----------<<<<<

                    slipPrtSetWork.EntNmPrtExpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTNMPRTEXPDIVRF")); // ADD 2011/02/16
                    // --- ADD 2011/07/19 ---------->>>>>
                    slipPrtSetWork.SCMAnsMarkPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SCMANSMARKPRTDIVRF"));
                    slipPrtSetWork.NormalPrtMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NORMALPRTMARKRF"));
                    slipPrtSetWork.SCMManualAnsMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SCMMANUALANSMARKRF"));
                    slipPrtSetWork.SCMAutoAnsMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SCMAUTOANSMARKRF"));
                    // --- ADD 2011/07/19 ----------<<<<<

                    al.Add(slipPrtSetWork);

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
        /// <param name="syncServiceWork"></param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.10</br>
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
        // �� 2008.02.12 980081 a

	}
}
