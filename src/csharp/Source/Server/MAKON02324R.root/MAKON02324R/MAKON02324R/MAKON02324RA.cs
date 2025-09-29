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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d���f�[�^�Q��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���f�[�^�Q�Ƃ̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22013 kubo</br>
    /// <br>Date       : 2007.06.06</br>
    /// <br></br>
    /// <br>Update Note: 2007.12.04  980081 �R�c ���F</br>
    /// <br>           : ���ʊ�Ή�</br>
    /// <br>           : 1.�d���ڍ׃f�[�^�폜�Ή�</br>
    /// <br>           : 2.���C�A�E�g�ύX�Ή�</br>
    /// </remarks>
    [Serializable]
    public class StcDataRefListWorkDB : RemoteDB, IStcDataRefListWorkDB
    {
        /// <summary>
        /// �d���f�[�^�Q��DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.06.06</br>
        /// Update Note    : 30290
        ///                : 2008.04.24 ���Ӑ�E�d����؂蕪��
        /// </remarks>
        public StcDataRefListWorkDB()
            :
        base("MAKON02326D", "Broadleaf.Application.Remoting.ParamData.StcDataRefWork", "STOCKSLIPRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region �d���f�[�^�擾����
        /// <summary>
        /// �d���`�[���List���擾����(�_���폜����)
        /// </summary>
        /// <param name="stcDataRefListWork">��������(�`�[)</param>
        /// <param name="stcDtlDataRefListWork">��������(�`�[����)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="supplierFomal">�d���`��</param>
        /// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �`�[���List���擾����</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.06.06</br>
        /// </remarks>
        // �� 2007.12.04 980081 c
        //public int Read(out object stcDataRefListWork, out object stcDtlDataRefListWork, out object stcExDataRefListWork,
        //    string enterpriseCode, int supplierFomal, int supplierSlipNo, int readMode, ConstantManagement.LogicalMode logicalMode)
        public int Read(out object stcDataRefListWork, out object stcDtlDataRefListWork,
            string enterpriseCode, int supplierFomal, int supplierSlipNo, int readMode, ConstantManagement.LogicalMode logicalMode)
        // �� 2007.12.04 980081 c
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stcDataRefListWork = null;
            stcDtlDataRefListWork = null;
            // �� 2007.12.04 980081 d
            //stcExDataRefListWork = null;
            // �� 2007.12.04 980081 d

            try
            {
                // �� 2007.12.04 980081 c
                //status = ReadProc(out stcDataRefListWork, out stcDtlDataRefListWork, out stcExDataRefListWork,
                //    enterpriseCode, supplierFomal, supplierSlipNo, readMode, logicalMode);
                status = ReadProc(out stcDataRefListWork, out stcDtlDataRefListWork,
                    enterpriseCode, supplierFomal, supplierSlipNo, readMode, logicalMode);
                // �� 2007.12.04 980081 c
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StcDataRefListWorkDB.SearchDepsitOnly Exception=" + ex.Message);
                stcDataRefListWork = null;
                stcDtlDataRefListWork = null;
                // �� 2007.12.04 980081 d
                //stcExDataRefListWork = null;
                // �� 2007.12.04 980081 d
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̎d���f�[�^�Q��LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="stcDataRefListWork">��������(�`�[)</param>
        /// <param name="stcDtlDataRefListWork">��������(�`�[����)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="supplierFomal">�d���`��</param>
        /// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎d���f�[�^�Q��LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.06.06</br>
        /// </remarks>
        // �� 2007.12.04 980081 c
        //public int ReadProc( out object stcDataRefListWork, out object stcDtlDataRefListWork, out object stcExDataRefListWork, 
        //	string enterpriseCode, int supplierFomal, int supplierSlipNo, int readMode, ConstantManagement.LogicalMode logicalMode)
        public int ReadProc(out object stcDataRefListWork, out object stcDtlDataRefListWork,
            string enterpriseCode, int supplierFomal, int supplierSlipNo, int readMode, ConstantManagement.LogicalMode logicalMode)
        // �� 2007.12.04 980081 c
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int st1 = status;
            int st2 = status;
            // �� 2007.12.04 980081 d
            //int st3 = status;
            // �� 2007.12.04 980081 d
            SqlConnection sqlConnection = null;
            SqlEncryptInfo sqlEncryptInfo = null;

            stcDataRefListWork = null;
            stcDtlDataRefListWork = null;
            // �� 2007.12.04 980081 d
            //stcExDataRefListWork = null;
            // �� 2007.12.04 980081 d

            ArrayList stcDtList = new ArrayList();	//���o����(�d���f�[�^)
            ArrayList stcDtlDtList = new ArrayList();  //���o����(�d�����׃f�[�^)
            // �� 2007.12.04 980081 d
            //ArrayList stcExDtList	= new ArrayList();  //���o����(�d���ڍ׃f�[�^)
            // �� 2007.12.04 980081 d

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //���Í������i��������
                sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SUPPLIERRF" });
                //�Í����L�[OPEN�iSQLException�̉\���L��j
                sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //�d���f�[�^�擾���s��
                st1 = ReadStcDataRefAction(ref stcDtList, ref sqlConnection, enterpriseCode, supplierFomal, supplierSlipNo, logicalMode);
                //�d�����׃f�[�^�擾���s��
                st2 = ReadStcDtlDataRefAction(ref stcDtlDtList, ref sqlConnection, enterpriseCode, supplierFomal, supplierSlipNo, logicalMode);
                // �� 2007.12.04 980081 d
                ////�d���ڍ׃f�[�^�擾���s��
                //st3 = ReadStcExDataRefAction(ref stcExDtList, ref sqlConnection, enterpriseCode, supplierFomal, supplierSlipNo, logicalMode);
                // �� 2007.12.04 980081 d

                status = st1;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StcDataRefListWorkDB.SearchDepsitAndAllowanceProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    //�Í����L�[�N���[�Y
                    if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            stcDataRefListWork = stcDtList;
            stcDtlDataRefListWork = stcDtlDtList;
            // �� 2007.12.04 980081 d
            //stcExDataRefListWork = stcExDtList;
            // �� 2007.12.04 980081 d

            return status;
        }
        #endregion

        #region �d���f�[�^�擾�����i���s���j
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="stcDtList">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="supplierFomal">�d���`��</param>
        /// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int ReadStcDataRefAction(ref ArrayList stcDtList, ref SqlConnection sqlConnection,
            string enterpriseCode, int supplierFomal, int supplierSlipNo, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // �Ώۃe�[�u��
                // StockSlipRF		STS   �d���f�[�^
                // SECINFOSETRF		SIS,SIS2,SIS3   ���_���ݒ�}�X�^

                StringBuilder SelectDm = new StringBuilder();

                #region Select���쐬
                SelectDm.Append("SELECT");

                //�d���f�[�^���ʎ擾
                // �� 2007.12.04 980081 c
                #region �����C�A�E�g(�R�����g�A�E�g)
                //SelectDm.Append( " STS.SECTIONCODERF STS_SECTIONCODERF" );
                //SelectDm.Append( ", STS.SUPPLIERFORMALRF STS_SUPPLIERFORMALRF" );
                //SelectDm.Append( ", STS.SUPPLIERSLIPNORF STS_SUPPLIERSLIPNORF" );
                //SelectDm.Append( ", STS.PARTYSALESLIPNUMRF STS_PARTYSALESLIPNUMRF" );
                //SelectDm.Append( ", STS.STOCKSECTIONCDRF STS_STOCKSECTIONCDRF" );
                //SelectDm.Append( ", STS.STOCKADDUPSECTIONCDRF STS_STOCKADDUPSECTIONCDRF" );
                //SelectDm.Append( ", STS.STOCKAGENTCODERF STS_STOCKAGENTCODERF" );
                //SelectDm.Append( ", STS.STOCKAGENTNAMERF STS_STOCKAGENTNAMERF" );
                //SelectDm.Append( ", STS.CUSTOMERCODERF STS_CUSTOMERCODERF" );
                //SelectDm.Append( ", STS.CUSTOMERNAMERF STS_CUSTOMERNAMERF" );
                //SelectDm.Append( ", STS.CUSTOMERNAME2RF STS_CUSTOMERNAME2RF" );
                //SelectDm.Append( ", STS.PAYEECODERF STS_PAYEECODERF" );
                //SelectDm.Append( ", STS.PAYEENAME1RF STS_PAYEENAME1RF" );
                //SelectDm.Append( ", STS.PAYEENAME2RF STS_PAYEENAME2RF" );
                //SelectDm.Append( ", STS.PAYMENTDATERF STS_PAYMENTDATERF" );
                //SelectDm.Append( ", STS.INPUTDAYRF STS_INPUTDAYRF" );
                //SelectDm.Append( ", STS.ARRIVALGOODSDAYRF STS_ARRIVALGOODSDAYRF" );
                //SelectDm.Append( ", STS.STOCKDATERF STS_STOCKDATERF" );
                //SelectDm.Append( ", STS.STOCKADDUPADATERF STS_STOCKADDUPADATERF" );
                //SelectDm.Append( ", STS.SUPPLIERSLIPCDRF STS_SUPPLIERSLIPCDRF" );
                //SelectDm.Append( ", STS.ACCPAYDIVCDRF STS_ACCPAYDIVCDRF" );
                //SelectDm.Append( ", STS.DEBITNOTEDIVRF STS_DEBITNOTEDIVRF" );
                //SelectDm.Append( ", STS.DEBITNLNKSUPPSLIPNORF STS_DEBITNLNKSUPPSLIPNORF" );
                //SelectDm.Append( ", STS.STOCKTOTALPRICERF STS_STOCKTOTALPRICERF" );
                //SelectDm.Append( ", STS.STOCKSUBTTLPRICERF STS_STOCKSUBTTLPRICERF" );
                //SelectDm.Append( ", STS.STOCKTTLPRICTAXINCRF STS_STOCKTTLPRICTAXINCRF" );
                //SelectDm.Append( ", STS.STOCKTTLPRICTAXEXCRF STS_STOCKTTLPRICTAXEXCRF" );
                //SelectDm.Append( ", STS.TTLITDEDSTOCKTAXFREERF STS_TTLITDEDSTOCKTAXFREERF" );
                //SelectDm.Append( ", STS.STOCKPRICECONSTAXRF STS_STOCKPRICECONSTAXRF" );
                //SelectDm.Append( ", STS.SUPPCTAXLAYCDRF STS_SUPPCTAXLAYCDRF" );
                //SelectDm.Append( ", STS.SUPPLIERCONSTAXRATERF STS_SUPPLIERCONSTAXRATERF" );
                //SelectDm.Append( ", STS.STOCKFRACTIONPROCCDRF STS_STOCKFRACTIONPROCCDRF" );
                //SelectDm.Append( ", STS.SUPPTTLAMNTDSPWAYCDRF STS_SUPPTTLAMNTDSPWAYCDRF" );
                //SelectDm.Append( ", STS.SUPPLIERSLIPNOTE1RF STS_SUPPLIERSLIPNOTE1RF" );
                //SelectDm.Append( ", STS.SUPPLIERSLIPNOTE2RF STS_SUPPLIERSLIPNOTE2RF" );
                //SelectDm.Append( ", STS.CARRIEREPCODERF STS_CARRIEREPCODERF" );
                //SelectDm.Append( ", STS.CARRIEREPNAMERF STS_CARRIEREPNAMERF" );
                //SelectDm.Append( ", STS.WAREHOUSECODERF STS_WAREHOUSECODERF" );
                //SelectDm.Append( ", STS.WAREHOUSENAMERF STS_WAREHOUSENAMERF" );
                //SelectDm.Append( ", STS.STOCKGOODSCDRF STS_STOCKGOODSCDRF" );
                //SelectDm.Append( ", STS.TAXADJUSTRF STS_TAXADJUSTRF" );
                //SelectDm.Append( ", STS.BALANCEADJUSTRF STS_BALANCEADJUSTRF" );
                //SelectDm.Append( ", STS.TRUSTADDUPSPCDRF STS_TRUSTADDUPSPCDRF" );
                //SelectDm.Append( ", STS.RETGOODSREASONDIVRF STS_RETGOODSREASONDIVRF" );
                //SelectDm.Append( ", STS.RETGOODSREASONRF STS_RETGOODSREASONRF" );
                //SelectDm.Append( ", STS.ACCEPTANORDERNORF STS_ACCEPTANORDERNORF" );
                //SelectDm.Append( ", STS.SALESROWNORF STS_SALESROWNORF" );
                //
                //
                //SelectDm.Append( ", SIS.SECTIONGUIDENMRF SIS_SECTIONGUIDENMRF" );
                //SelectDm.Append( ", SIS2.SECTIONGUIDENMRF SIS2_STOCKSECTIONNMRF" );
                //SelectDm.Append( ", SIS3.SECTIONGUIDENMRF SIS3_STOCKADDUPSECTIONNMRF" );
                //
                //SelectDm.Append( " FROM STOCKSLIPRF STS" );
                //SelectDm.Append( " LEFT JOIN SECINFOSETRF SIS ON SIS.ENTERPRISECODERF=STS.ENTERPRISECODERF AND SIS.SECTIONCODERF=STS.SECTIONCODERF" );
                //SelectDm.Append( " LEFT JOIN SECINFOSETRF SIS2 ON SIS2.ENTERPRISECODERF=STS.ENTERPRISECODERF AND SIS2.SECTIONCODERF=STS.STOCKSECTIONCDRF" );
                //SelectDm.Append( " LEFT JOIN SECINFOSETRF SIS3 ON SIS3.ENTERPRISECODERF=STS.ENTERPRISECODERF AND SIS3.SECTIONCODERF=STS.STOCKADDUPSECTIONCDRF" );
                #endregion
                SelectDm.Append("  STS.SUPPLIERFORMALRF");
                SelectDm.Append(", STS.SUPPLIERSLIPNORF");
                SelectDm.Append(", STS.SECTIONCODERF");
                SelectDm.Append(", STS.SUBSECTIONCODERF");
                SelectDm.Append(", STS.MINSECTIONCODERF");
                SelectDm.Append(", STS.DEBITNOTEDIVRF");
                SelectDm.Append(", STS.DEBITNLNKSUPPSLIPNORF");
                SelectDm.Append(", STS.SUPPLIERSLIPCDRF");
                SelectDm.Append(", STS.STOCKGOODSCDRF");
                SelectDm.Append(", STS.ACCPAYDIVCDRF");
                SelectDm.Append(", STS.TRUSTADDUPSPCDRF");
                SelectDm.Append(", STS.STOCKSECTIONCDRF");
                SelectDm.Append(", STS.STOCKADDUPSECTIONCDRF");
                SelectDm.Append(", STS.INPUTDAYRF");
                SelectDm.Append(", STS.ARRIVALGOODSDAYRF");
                SelectDm.Append(", STS.STOCKDATERF");
                SelectDm.Append(", STS.STOCKADDUPADATERF");
                SelectDm.Append(", STS.DELAYPAYMENTDIVRF");
                SelectDm.Append(", STS.PAYEECODERF");
                SelectDm.Append(", STS.PAYEESNMRF");
                SelectDm.Append(", STS.SUPLLIERCDRF");
                SelectDm.Append(", STS.SUPPLIERNM1RF");
                SelectDm.Append(", STS.SUPPLIERNM2RF");
                SelectDm.Append(", STS.SUPPLIERSNMRF");
                SelectDm.Append(", STS.OUTPUTNAMECODERF");
                SelectDm.Append(", STS.BUSINESSTYPECODERF");
                SelectDm.Append(", STS.BUSINESSTYPENAMERF");
                SelectDm.Append(", STS.SALESAREACODERF");
                SelectDm.Append(", STS.SALESAREANAMERF");
                SelectDm.Append(", STS.STOCKINPUTCODERF");
                SelectDm.Append(", STS.STOCKINPUTNAMERF");
                SelectDm.Append(", STS.STOCKAGENTCODERF");
                SelectDm.Append(", STS.STOCKAGENTNAMERF");
                SelectDm.Append(", STS.SUPPTTLAMNTDSPWAYCDRF");
                SelectDm.Append(", STS.TTLAMNTDISPRATEAPYRF");
                SelectDm.Append(", STS.STOCKTOTALPRICERF");
                SelectDm.Append(", STS.STOCKSUBTTLPRICERF");
                SelectDm.Append(", STS.STOCKTTLPRICTAXINCRF");
                SelectDm.Append(", STS.STOCKTTLPRICTAXEXCRF");
                SelectDm.Append(", STS.STOCKNETPRICERF");
                SelectDm.Append(", STS.STOCKPRICECONSTAXRF");
                SelectDm.Append(", STS.TTLITDEDSTCOUTTAXRF");
                SelectDm.Append(", STS.TTLITDEDSTCINTAXRF");
                SelectDm.Append(", STS.TTLITDEDSTCTAXFREERF");
                SelectDm.Append(", STS.STOCKOUTTAXRF");
                SelectDm.Append(", STS.STCKPRCCONSTAXINCLURF");
                SelectDm.Append(", STS.STCKDISTTLTAXEXCRF");
                SelectDm.Append(", STS.ITDEDSTOCKDISOUTTAXRF");
                SelectDm.Append(", STS.ITDEDSTOCKDISINTAXRF");
                SelectDm.Append(", STS.ITDEDSTOCKDISTAXFRERF");
                SelectDm.Append(", STS.STOCKDISOUTTAXRF");
                SelectDm.Append(", STS.STCKDISTTLTAXINCLURF");
                SelectDm.Append(", STS.TAXADJUSTRF");
                SelectDm.Append(", STS.BALANCEADJUSTRF");
                SelectDm.Append(", STS.SUPPCTAXLAYCDRF");
                SelectDm.Append(", STS.SUPPLIERCONSTAXRATERF");
                SelectDm.Append(", STS.ACCPAYCONSTAXRF");
                SelectDm.Append(", STS.STOCKFRACTIONPROCCDRF");
                SelectDm.Append(", STS.AUTOPAYMENTRF");
                SelectDm.Append(", STS.AUTOPAYSLIPNUMRF");
                SelectDm.Append(", STS.RETGOODSREASONDIVRF");
                SelectDm.Append(", STS.RETGOODSREASONRF");
                SelectDm.Append(", STS.PARTYSALESLIPNUMRF");
                SelectDm.Append(", STS.SUPPLIERSLIPNOTE1RF");
                SelectDm.Append(", STS.SUPPLIERSLIPNOTE2RF");
                SelectDm.Append(", STS.DETAILROWCOUNTRF");
                SelectDm.Append(", STS.EDISENDDATERF");
                SelectDm.Append(", STS.EDITAKEINDATERF");
                SelectDm.Append(", STS.UOEREMARK1RF");
                SelectDm.Append(", STS.UOEREMARK2RF");
                SelectDm.Append(", STS.SLIPPRINTDIVCDRF");
                SelectDm.Append(", STS.SLIPPRINTFINISHCDRF");
                SelectDm.Append(", STS.STOCKSLIPPRINTDATERF");
                SelectDm.Append(", STS.SLIPPRTSETPAPERIDRF");
                SelectDm.Append(", SIS.SECTIONGUIDENMRF SECTIONGUIDENMRF");
                SelectDm.Append(", SIS2.SECTIONGUIDENMRF STOCKSECTIONNMRF");
                SelectDm.Append(", SIS3.SECTIONGUIDENMRF STOCKADDUPSECTIONNMRF");
                SelectDm.Append(", CAST(DECRYPTBYKEY(CUS.NAMERF)  AS NVARCHAR(30)) AS PAYEENAMERF");
                SelectDm.Append(", CAST(DECRYPTBYKEY(CUS.NAME2RF) AS NVARCHAR(30)) AS PAYEENAME2RF");
                SelectDm.Append(" FROM STOCKSLIPHISTRF STS");
                SelectDm.Append(" LEFT JOIN SECINFOSETRF SIS ON SIS.ENTERPRISECODERF=STS.ENTERPRISECODERF AND SIS.SECTIONCODERF=STS.SECTIONCODERF");
                SelectDm.Append(" LEFT JOIN SECINFOSETRF SIS2 ON SIS2.ENTERPRISECODERF=STS.ENTERPRISECODERF AND SIS2.SECTIONCODERF=STS.STOCKSECTIONCDRF");
                SelectDm.Append(" LEFT JOIN SECINFOSETRF SIS3 ON SIS3.ENTERPRISECODERF=STS.ENTERPRISECODERF AND SIS3.SECTIONCODERF=STS.STOCKADDUPSECTIONCDRF");
                SelectDm.Append(" LEFT JOIN SUPPLIERRF   CUS ON CUS.ENTERPRISECODERF=STS.ENTERPRISECODERF AND CUS.SUPPLIERCDRF=STS.PAYEECODERF");
                // �� 2007.12.04 980081 c
                #endregion

                sqlCommand = new SqlCommand(SelectDm.ToString(), sqlConnection);

                //WHERE���̍쐬
                // Where��
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, "STS", enterpriseCode, supplierFomal, supplierSlipNo, logicalMode);
                // Sort
                sqlCommand.CommandText += " ORDER BY STS.SUPPLIERSLIPNORF";

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    StcDataRefWork wkStcDataRefResultWork = new StcDataRefWork();

                    // �� 2007.12.04 980081 c
                    #region �����C�A�E�g(�R�����g�A�E�g)
                    //�݌Ɏԗ����o�ɊǗ��}�X�^���ʎ擾���e�i�[
                    //wkStcDataRefResultWork.SectionCode				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_SECTIONCODERF"));			// ���_�R�[�h
                    //wkStcDataRefResultWork.StockSectionCd 			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_STOCKSECTIONCDRF"));		// �d�����_�R�[�h
                    //wkStcDataRefResultWork.StockAddUpSectionCd		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_STOCKADDUPSECTIONCDRF"));	// �d���v�㋒�_�R�[�h
                    //
                    //wkStcDataRefResultWork.StockSectionNm 			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SIS_SECTIONGUIDENMRF"));		// �d�����_����
                    //wkStcDataRefResultWork.SectionGuideNm			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SIS2_STOCKSECTIONNMRF"));	// ���_�K�C�h����
                    //wkStcDataRefResultWork.StockAddUpSectionNm		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SIS3_STOCKADDUPSECTIONNMRF"));	// �d���v�㋒�_����
                    //
                    //wkStcDataRefResultWork.SupplierFormal			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_SUPPLIERFORMALRF"));		// �d���`��
                    //wkStcDataRefResultWork.SupplierSlipNo			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_SUPPLIERSLIPNORF"));		// �d���`�[�ԍ�
                    //wkStcDataRefResultWork.PartySaleSlipNum			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_PARTYSALESLIPNUMRF"));		// �����`�[�ԍ�
                    //wkStcDataRefResultWork.StockAgentCode			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_STOCKAGENTCODERF"));		// �d���S���҃R�[�h
                    //wkStcDataRefResultWork.StockAgentName			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_STOCKAGENTNAMERF"));		// �d���S���Җ���
                    //wkStcDataRefResultWork.CustomerCode				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_CUSTOMERCODERF"));			// ���Ӑ�R�[�h
                    //wkStcDataRefResultWork.CustomerName				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_CUSTOMERNAMERF"));			// ���Ӑ於��
                    //wkStcDataRefResultWork.CustomerName2			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_CUSTOMERNAME2RF"));			// ���Ӑ於��2
                    //wkStcDataRefResultWork.PayeeCode				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_PAYEECODERF"));				// �x����R�[�h
                    //wkStcDataRefResultWork.PayeeName1				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_PAYEENAME1RF"));			// �x���於��1
                    //wkStcDataRefResultWork.Payeename2				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_PAYEENAME2RF"));			// �x���於��2
                    //wkStcDataRefResultWork.PaymentDate				= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STS_PAYMENTDATERF"));			// �x�����t
                    //wkStcDataRefResultWork.InputDay					= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_INPUTDAYRF"));				// ���͓�
                    //wkStcDataRefResultWork.ArrivalGoodsDay			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_ARRIVALGOODSDAYRF"));		// ���ד�
                    //wkStcDataRefResultWork.StockDate				= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STS_STOCKDATERF"));				// �d����
                    //wkStcDataRefResultWork.StockAddUpADate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STS_STOCKADDUPADATERF"));		// �d���v����t
                    //wkStcDataRefResultWork.SupplierSlipCd			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_SUPPLIERSLIPCDRF"));		// �d���`�[�敪
                    //wkStcDataRefResultWork.AccPayDivCd				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_ACCPAYDIVCDRF"));			// ���|�敪
                    //wkStcDataRefResultWork.DebitNoteDiv				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_DEBITNOTEDIVRF"));			// �ԓ`�敪
                    //wkStcDataRefResultWork.DebitNLnkSuppSlipNo		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_DEBITNLNKSUPPSLIPNORF"));	// �ԍ��A���d���`�[�ԍ�
                    //wkStcDataRefResultWork.StockTotalPrice			= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STS_STOCKTOTALPRICERF"));		// �d�����z���v
                    //wkStcDataRefResultWork.StockSubttlPrice			= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STS_STOCKSUBTTLPRICERF"));		// �d�����z���v
                    //wkStcDataRefResultWork.StockTtlPricTaxInc 		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STS_STOCKTTLPRICTAXINCRF"));	// �d�����z�v�i�ō��݁j
                    //wkStcDataRefResultWork.StockTtlPricTaxExc 		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STS_STOCKTTLPRICTAXEXCRF"));	// �d�����z�v�i�Ŕ����j
                    //wkStcDataRefResultWork.TtlItdedStockTaxFree 	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STS_TTLITDEDSTOCKTAXFREERF"));	// �d����ېőΏۊz���v
                    //wkStcDataRefResultWork.StockPriceConsTax		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STS_STOCKPRICECONSTAXRF"));		// �d�����z����Ŋz
                    //wkStcDataRefResultWork.SuppCTaxLayCd			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_SUPPCTAXLAYCDRF"));			// �d�������œ]�ŕ����R�[�h
                    //wkStcDataRefResultWork.SupplierConsTaxRate 		= SqlDataMediator.SqlGetDouble	(myReader, myReader.GetOrdinal("STS_SUPPLIERCONSTAXRATERF"));	// �d�������Őŗ�
                    //wkStcDataRefResultWork.StockFractionProcCd 		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_STOCKFRACTIONPROCCDRF"));	// �d���[�������敪
                    //wkStcDataRefResultWork.SuppTtlAmntDspWayCd 		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_SUPPTTLAMNTDSPWAYCDRF"));	// �d���摍�z�\�����@�敪
                    //wkStcDataRefResultWork.SupplierSlipNote1 		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_SUPPLIERSLIPNOTE1RF"));		// �d���`�[���l1
                    //wkStcDataRefResultWork.SupplierSlipNote2 		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_SUPPLIERSLIPNOTE2RF"));		// �d���`�[���l2
                    //wkStcDataRefResultWork.CarrierEpCode 			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_CARRIEREPCODERF"));			// ���Ǝ҃R�[�h
                    //wkStcDataRefResultWork.CarrierEpName 			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_CARRIEREPNAMERF"));			// ���ƎҖ���
                    //wkStcDataRefResultWork.WarehouseCode 			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_WAREHOUSECODERF"));			// �q�ɃR�[�h
                    //wkStcDataRefResultWork.WarehouseName 			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_WAREHOUSENAMERF"));			// �q�ɖ���
                    //wkStcDataRefResultWork.StockGoodsCd				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_STOCKGOODSCDRF"));			// �d�����i�敪
                    //wkStcDataRefResultWork.TaxAdjust				= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STS_TAXADJUSTRF"));				// ����Œ����z
                    //wkStcDataRefResultWork.BalanceAdjust			= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STS_BALANCEADJUSTRF"));			// �c�������z
                    //wkStcDataRefResultWork.TrustAddUpSpCd			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_TRUSTADDUPSPCDRF"));		// ����v��d���敪
                    //wkStcDataRefResultWork.RetGoodsReasonDiv		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_RETGOODSREASONDIVRF"));		// �ԕi���R�R�[�h
                    //wkStcDataRefResultWork.RetGoodsReason			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_RETGOODSREASONRF"));		// �ԕi���R
                    //wkStcDataRefResultWork.AcceptAnOrderNo			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_ACCEPTANORDERNORF"));		// �󒍔ԍ�
                    //wkStcDataRefResultWork.SalesRowNo				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_SALESROWNORF"));			// ����s�ԍ�
                    #endregion
                    //�d���f�[�^�i�[
                    wkStcDataRefResultWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                    wkStcDataRefResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    wkStcDataRefResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkStcDataRefResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    wkStcDataRefResultWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    wkStcDataRefResultWork.MinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINSECTIONCODERF"));
                    wkStcDataRefResultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    wkStcDataRefResultWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
                    wkStcDataRefResultWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
                    wkStcDataRefResultWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
                    wkStcDataRefResultWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
                    wkStcDataRefResultWork.TrustAddUpSpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRUSTADDUPSPCDRF"));
                    wkStcDataRefResultWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                    wkStcDataRefResultWork.StockSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONNMRF"));
                    wkStcDataRefResultWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
                    wkStcDataRefResultWork.StockAddUpSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONNMRF"));
                    wkStcDataRefResultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    wkStcDataRefResultWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
                    wkStcDataRefResultWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
                    wkStcDataRefResultWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
                    wkStcDataRefResultWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
                    wkStcDataRefResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    wkStcDataRefResultWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
                    wkStcDataRefResultWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
                    wkStcDataRefResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                    wkStcDataRefResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPLLIERCDRF"));
                    wkStcDataRefResultWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPLLIERNM1RF"));
                    wkStcDataRefResultWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPLLIERNM2RF"));
                    wkStcDataRefResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPLLIERSNMRF"));
                    wkStcDataRefResultWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
                    wkStcDataRefResultWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                    wkStcDataRefResultWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
                    wkStcDataRefResultWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                    wkStcDataRefResultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
                    wkStcDataRefResultWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
                    wkStcDataRefResultWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
                    wkStcDataRefResultWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
                    wkStcDataRefResultWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
                    wkStcDataRefResultWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
                    wkStcDataRefResultWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
                    wkStcDataRefResultWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                    wkStcDataRefResultWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
                    wkStcDataRefResultWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
                    wkStcDataRefResultWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
                    wkStcDataRefResultWork.StockNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKNETPRICERF"));
                    wkStcDataRefResultWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
                    wkStcDataRefResultWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));
                    wkStcDataRefResultWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));
                    wkStcDataRefResultWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
                    wkStcDataRefResultWork.StockOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAXRF"));
                    wkStcDataRefResultWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));
                    wkStcDataRefResultWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));
                    wkStcDataRefResultWork.ItdedStockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISOUTTAXRF"));
                    wkStcDataRefResultWork.ItdedStockDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISINTAXRF"));
                    wkStcDataRefResultWork.ItdedStockDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISTAXFRERF"));
                    wkStcDataRefResultWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));
                    wkStcDataRefResultWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
                    wkStcDataRefResultWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
                    wkStcDataRefResultWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
                    wkStcDataRefResultWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
                    wkStcDataRefResultWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
                    wkStcDataRefResultWork.AccPayConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCPAYCONSTAXRF"));
                    wkStcDataRefResultWork.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKFRACTIONPROCCDRF"));
                    wkStcDataRefResultWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                    wkStcDataRefResultWork.AutoPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYSLIPNUMRF"));
                    wkStcDataRefResultWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                    wkStcDataRefResultWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
                    wkStcDataRefResultWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                    wkStcDataRefResultWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
                    wkStcDataRefResultWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
                    wkStcDataRefResultWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
                    wkStcDataRefResultWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                    wkStcDataRefResultWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                    wkStcDataRefResultWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                    wkStcDataRefResultWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                    wkStcDataRefResultWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
                    wkStcDataRefResultWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
                    wkStcDataRefResultWork.StockSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKSLIPPRINTDATERF"));
                    wkStcDataRefResultWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
                    // �� 2007.12.04 980081 c
                    #endregion

                    stcDtList.Add(wkStcDataRefResultWork);

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
                base.WriteErrorLog(ex, "StcDataRefListWorkDB.ReadStcDataRefAction Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region �d�����׃f�[�^�擾�����i���s���j
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="stcDtlDtList">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="supplierFomal">�d���`��</param>
        /// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Status</returns>
        private int ReadStcDtlDataRefAction(ref ArrayList stcDtlDtList, ref SqlConnection sqlConnection,
            string enterpriseCode, int supplierFomal, int supplierSlipNo, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // �Ώۃe�[�u��
                // StockDetailRF	STD   �d���f�[�^
                // SECINFOSETRF		SIS   ���_���ݒ�}�X�^

                StringBuilder SelectDm = new StringBuilder();

                #region Select���쐬
                SelectDm.Append("SELECT");

                //�d���f�[�^���ʎ擾
                // �� 2007.12.04 980081 c
                #region �����C�A�E�g(�R�����g�A�E�g)
                //SelectDm.Append( " STD.SECTIONCODERF STD_SECTIONCODE" );						// ���_�R�[�h
                //SelectDm.Append( ", STD.SUPPLIERFORMALRF STD_SUPPLIERFORMAL" );					// �d���`��
                //SelectDm.Append( ", STD.SUPPLIERSLIPNORF STD_SUPPLIERSLIPNO" );					// �d���`�[�ԍ�
                //SelectDm.Append( ", STD.STOCKROWNORF STD_STOCKROWNO" );							// �d���s�ԍ�
                //SelectDm.Append( ", STD.STOCKAGENTCODERF STD_STOCKAGENTCODE" );					// �d���S���҃R�[�h
                //SelectDm.Append( ", STD.STOCKAGENTNAMERF STD_STOCKAGENTNAME" );					// �d���S���Җ�
                //SelectDm.Append( ", STD.CARRIERCODERF STD_CARRIERCODE" );  						// �L�����A�R�[�h
                //SelectDm.Append( ", STD.CARRIERNAMERF STD_CARRIERNAME" );  						// �L�����A����
                //SelectDm.Append( ", STD.MAKERCODERF STD_MAKERCODE" );  							// ���[�J�[�R�[�h
                //SelectDm.Append( ", STD.MAKERNAMERF STD_MAKERNAME" );  							// ���[�J�[����
                //SelectDm.Append( ", STD.GOODSCODERF STD_GOODSCODE" );  							// ���i�R�[�h
                //SelectDm.Append( ", STD.GOODSNAMERF STD_GOODSNAME" );  							// ���i����
                //SelectDm.Append( ", STD.GOODSKINDCODERF STD_GOODSKINDCODE" );					// ���i����
                //SelectDm.Append( ", STD.CELLPHONEMODELCODERF STD_CELLPHONEMODELCODE" );			// �@��R�[�h
                //SelectDm.Append( ", STD.CELLPHONEMODELNAMERF STD_CELLPHONEMODELNAME" );			// �@�햼��
                //SelectDm.Append( ", STD.SYSTEMATICCOLORCDRF STD_SYSTEMATICCOLORCD" );			// �n���F�R�[�h
                //SelectDm.Append( ", STD.SYSTEMATICCOLORNMRF STD_SYSTEMATICCOLORNM" );			// �n���F����
                //SelectDm.Append( ", STD.LARGEGOODSGANRECODERF STD_LARGEGOODSGANRECODE" );  		// ���i�敪�O���[�v�R�[�h
                //SelectDm.Append( ", STD.LARGEGOODSGANRENAMERF STD_LARGEGOODSGANRENAME" );  		// ���i�敪�O���[�v����
                //SelectDm.Append( ", STD.MEDIUMGOODSGANRECODERF STD_MEDIUMGOODSGANRECODE" );		// ���i�敪�R�[�h
                //SelectDm.Append( ", STD.MEDIUMGOODSGANRENAMERF STD_MEDIUMGOODSGANRENAME" );		// ���i�敪����
                //SelectDm.Append( ", STD.STOCKCOUNTRF STD_STOCKCOUNT" );							// �d����
                //SelectDm.Append( ", STD.STOCKUNITPRICERF STD_STOCKUNITPRICE" );					// �d���P��
                //SelectDm.Append( ", STD.STOCKUNITTAXPRICERF STD_STOCKUNITTAXPRICE" );			// �d���P���i�ō��݁j
                //SelectDm.Append( ", STD.STOCKPRICETAXEXCRF STD_STOCKPRICETAXEXC" );  			// �d�����z�i�Ŕ����j
                //SelectDm.Append( ", STD.STOCKPRICETAXINCRF STD_STOCKPRICETAXINC" );  			// �d�����z�i�ō��݁j
                //SelectDm.Append( ", STD.TAXATIONCODERF STD_TAXATIONCODE" );						// �ېŋ敪
                //SelectDm.Append( ", STD.STOCKDTISLIPNOTE1RF STD_STOCKDTISLIPNOTE1" );			// �d���`�[���ה��l1
                //SelectDm.Append( ", STD.CARRIEREPCODERF STD_CARRIEREPCODE" );					// ���Ǝ҃R�[�h
                //SelectDm.Append( ", STD.CARRIEREPNAMERF STD_CARRIEREPNAME" );					// ���ƎҖ���
                //SelectDm.Append( ", STD.GOODSSETCODERF STD_GOODSSETCODE" );  					// ���i�Z�b�g�R�[�h
                //SelectDm.Append( ", STD.GOODSSETNAMERF STD_GOODSSETNAME" );  					// ���i�Z�b�g����
                //SelectDm.Append( ", STD.GOODSSETDIVCDRF STD_GOODSSETDIVCD" );					// �Z�b�g���i�敪
                //SelectDm.Append( ", STD.SETUNITPRICETAXINCRF STD_SETUNITPRICETAXINC" );  		// �Z�b�g�P�i�P���i�ō��݁j
                //SelectDm.Append( ", STD.SETUNITPRICETAXEXCRF STD_SETUNITPRICETAXEXC" );  		// �Z�b�g�P�i�P���i�Ŕ����j
                //SelectDm.Append( ", STD.WAREHOUSECODERF STD_WAREHOUSECODE" );					// �q�ɃR�[�h
                //SelectDm.Append( ", STD.WAREHOUSENAMERF STD_WAREHOUSENAME" );					// �q�ɖ���
                //SelectDm.Append( ", STD.STOCKGOODSCDRF STD_STOCKGOODSCD" );						// �d�����i�敪
                //SelectDm.Append( ", STD.STOCKMNGEXISTCDRF STD_STOCKMNGEXISTCD" );				// �݌ɊǗ��L���敪
                //SelectDm.Append( ", STD.PRDNUMMNGDIVRF STD_PRDNUMMNGDIV" );						// ���ԊǗ��敪
                //SelectDm.Append( ", STD.TAXADJUSTRF STD_TAXADJUST" );							// ����Œ����z
                //SelectDm.Append( ", STD.BALANCEADJUSTRF STD_BALANCEADJUST" );					// �c�������z
                //SelectDm.Append( ", STD.ACCEPTANORDERNORF STD_ACCEPTANORDERNO" );				// �󒍔ԍ�
                //SelectDm.Append( ", STD.SALESROWNORF STD_SALESROWNO" );								// ����s�ԍ�
                //
                //SelectDm.Append( ", SIS.SECTIONGUIDENMRF SIS_SECTIONGUIDENM" );
                //
                //SelectDm.Append( " FROM STOCKDETAILRF STD" );
                //SelectDm.Append( " LEFT JOIN SECINFOSETRF SIS ON SIS.ENTERPRISECODERF=STD.ENTERPRISECODERF AND SIS.SECTIONCODERF=STD.SECTIONCODERF" );
                #endregion
                SelectDm.Append("  STD.ACCEPTANORDERNORF");
                SelectDm.Append(", STD.SUPPLIERFORMALRF");
                SelectDm.Append(", STD.SUPPLIERSLIPNORF");
                SelectDm.Append(", STD.STOCKROWNORF");
                SelectDm.Append(", STD.SECTIONCODERF");
                SelectDm.Append(", STD.SUBSECTIONCODERF");
                SelectDm.Append(", STD.MINSECTIONCODERF");
                SelectDm.Append(", STD.COMMONSEQNORF");
                SelectDm.Append(", STD.STOCKSLIPDTLNUMRF");
                SelectDm.Append(", STD.SUPPLIERFORMALSRCRF");
                SelectDm.Append(", STD.STOCKSLIPDTLNUMSRCRF");
                SelectDm.Append(", STD.ACPTANODRSTATUSSYNCRF");
                SelectDm.Append(", STD.SALESSLIPDTLNUMSYNCRF");
                SelectDm.Append(", STD.STOCKSLIPCDDTLRF");
                SelectDm.Append(", STD.STOCKAGENTCODERF");
                SelectDm.Append(", STD.STOCKAGENTNAMERF");
                SelectDm.Append(", STD.STOCKMNGEXISTCDRF");
                SelectDm.Append(", STD.GOODSKINDCODERF");
                SelectDm.Append(", STD.GOODSMAKERCDRF");
                SelectDm.Append(", STD.MAKERNAMERF");
                SelectDm.Append(", STD.GOODSNORF");
                SelectDm.Append(", STD.GOODSNAMERF");
                SelectDm.Append(", STD.LARGEGOODSGANRECODERF");
                SelectDm.Append(", STD.LARGEGOODSGANRENAMERF");
                SelectDm.Append(", STD.MEDIUMGOODSGANRECODERF");
                SelectDm.Append(", STD.MEDIUMGOODSGANRENAMERF");
                SelectDm.Append(", STD.DETAILGOODSGANRECODERF");
                SelectDm.Append(", STD.DETAILGOODSGANRENAMERF");
                SelectDm.Append(", STD.BLGOODSCODERF");
                SelectDm.Append(", STD.BLGOODSFULLNAMERF");
                SelectDm.Append(", STD.ENTERPRISEGANRECODERF");
                SelectDm.Append(", STD.ENTERPRISEGANRENAMERF");
                SelectDm.Append(", STD.WAREHOUSECODERF");
                SelectDm.Append(", STD.WAREHOUSENAMERF");
                SelectDm.Append(", STD.WAREHOUSESHELFNORF");
                SelectDm.Append(", STD.STOCKORDERDIVCDRF");
                SelectDm.Append(", STD.OPENPRICEDIVRF");
                SelectDm.Append(", STD.UNITCODERF");
                SelectDm.Append(", STD.UNITNAMERF");
                SelectDm.Append(", STD.GOODSRATERANKRF");
                SelectDm.Append(", STD.CUSTRATEGRPCODERF");
                SelectDm.Append(", STD.SUPPRATEGRPCODERF");
                SelectDm.Append(", STD.LISTPRICETAXEXCFLRF");
                SelectDm.Append(", STD.LISTPRICETAXINCFLRF");
                SelectDm.Append(", STD.STOCKRATERF");
                SelectDm.Append(", STD.RATESECTSTCKUNPRCRF");
                SelectDm.Append(", STD.RATEDIVSTCKUNPRCRF");
                SelectDm.Append(", STD.UNPRCCALCCDSTCKUNPRCRF");
                SelectDm.Append(", STD.PRICECDSTCKUNPRCRF");
                SelectDm.Append(", STD.STDUNPRCSTCKUNPRCRF");
                SelectDm.Append(", STD.FRACPROCUNITSTCUNPRCRF");
                SelectDm.Append(", STD.FRACPROCSTCKUNPRCRF");
                SelectDm.Append(", STD.STOCKUNITPRICEFLRF");
                SelectDm.Append(", STD.STOCKUNITTAXPRICEFLRF");
                SelectDm.Append(", STD.STOCKUNITCHNGDIVRF");
                SelectDm.Append(", STD.BFSTOCKUNITPRICEFLRF");
                SelectDm.Append(", STD.RATEBLGOODSCODERF");
                SelectDm.Append(", STD.RATEBLGOODSNAMERF");
                SelectDm.Append(", STD.BARGAINCDRF");
                SelectDm.Append(", STD.BARGAINNMRF");
                SelectDm.Append(", STD.STOCKCOUNTRF");
                SelectDm.Append(", STD.STOCKPRICETAXEXCRF");
                SelectDm.Append(", STD.STOCKPRICETAXINCRF");
                SelectDm.Append(", STD.STOCKGOODSCDRF");
                SelectDm.Append(", STD.STOCKPRICECONSTAXRF");
                SelectDm.Append(", STD.TAXADJUSTRF");
                SelectDm.Append(", STD.BALANCEADJUSTRF");
                SelectDm.Append(", STD.TAXATIONCODERF");
                SelectDm.Append(", STD.STOCKDTISLIPNOTE1RF");
                SelectDm.Append(", STD.SALESCUSTOMERCODERF");
                SelectDm.Append(", STD.SALESCUSTOMERNAMERF");
                SelectDm.Append(", STD.ORDERNUMBERRF");
                SelectDm.Append(", STD.SLIPMEMO1RF");
                SelectDm.Append(", STD.SLIPMEMO2RF");
                SelectDm.Append(", STD.SLIPMEMO3RF");
                SelectDm.Append(", STD.SLIPMEMO4RF");
                SelectDm.Append(", STD.SLIPMEMO5RF");
                SelectDm.Append(", STD.SLIPMEMO6RF");
                SelectDm.Append(", STD.INSIDEMEMO1RF");
                SelectDm.Append(", STD.INSIDEMEMO2RF");
                SelectDm.Append(", STD.INSIDEMEMO3RF");
                SelectDm.Append(", STD.INSIDEMEMO4RF");
                SelectDm.Append(", STD.INSIDEMEMO5RF");
                SelectDm.Append(", STD.INSIDEMEMO6RF");
                SelectDm.Append(", STD.STOCKCHECKDIVCADDUPRF");
                SelectDm.Append(", STD.STOCKCHECKDIVDAILYRF");
                SelectDm.Append(", SIS.SECTIONGUIDENMRF SECTIONGUIDENMRF");
                SelectDm.Append(" FROM STOCKSLHISTDTLRF STD");
                SelectDm.Append(" LEFT JOIN SECINFOSETRF SIS ON SIS.ENTERPRISECODERF=STD.ENTERPRISECODERF AND SIS.SECTIONCODERF=STD.SECTIONCODERF");
                // �� 2007.12.04 980081 c
                #endregion

                sqlCommand = new SqlCommand(SelectDm.ToString(), sqlConnection);

                //WHERE���̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, "STD", enterpriseCode, supplierFomal, supplierSlipNo, logicalMode);
                // Sort
                sqlCommand.CommandText += " ORDER BY STD.SUPPLIERSLIPNORF, STD.STOCKROWNORF";

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    StcDtlDataRefWork wkStcDtlDataRefResultWork = new StcDtlDataRefWork();

                    // �� 2007.12.04 980081 c
                    #region �����C�A�E�g(�R�����g�A�E�g)
                    //�݌Ɏԗ����o�ɊǗ��}�X�^���ʎ擾���e�i�[
                    //wkStcDtlDataRefResultWork.SectionCode			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_SECTIONCODE"));	  // ���_�R�[�h
                    //wkStcDtlDataRefResultWork.SectionGuideNm		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SIS_SECTIONGUIDENM"));	  // ���_�K�C�h����
                    //wkStcDtlDataRefResultWork.SupplierFormal		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_SUPPLIERFORMAL"));	  // �d���`��
                    //wkStcDtlDataRefResultWork.SupplierSlipNo		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_SUPPLIERSLIPNO"));	  // �d���`�[�ԍ�
                    //wkStcDtlDataRefResultWork.StockRowNo			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_STOCKROWNO"));	  // �d���s�ԍ�
                    //wkStcDtlDataRefResultWork.StockAgentCode		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_STOCKAGENTCODE"));	  // �d���S���҃R�[�h
                    //wkStcDtlDataRefResultWork.StockAgentName		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_STOCKAGENTNAME"));	  // �d���S���Җ�
                    //wkStcDtlDataRefResultWork.CarrierCode			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_CARRIERCODE"));	  // �L�����A�R�[�h
                    //wkStcDtlDataRefResultWork.CarrierName			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_CARRIERNAME"));	  // �L�����A����
                    //wkStcDtlDataRefResultWork.MakerCode				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_MAKERCODE"));	  // ���[�J�[�R�[�h
                    //wkStcDtlDataRefResultWork.MakerName				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_MAKERNAME"));	  // ���[�J�[����
                    //wkStcDtlDataRefResultWork.GoodsCode				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_GOODSCODE"));	  // ���i�R�[�h
                    //wkStcDtlDataRefResultWork.GoodsName				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_GOODSNAME"));	  // ���i����
                    //wkStcDtlDataRefResultWork.GoodsKindCode			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_GOODSKINDCODE"));	  // ���i����
                    //wkStcDtlDataRefResultWork.CellphoneModelCode	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_CELLPHONEMODELCODE"));	  // �@��R�[�h
                    //wkStcDtlDataRefResultWork.CellphoneModelName	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_CELLPHONEMODELNAME"));	  // �@�햼��
                    //wkStcDtlDataRefResultWork.SystematicColorCd		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_SYSTEMATICCOLORCD"));	  // �n���F�R�[�h
                    //wkStcDtlDataRefResultWork.SystematicColorNm		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_SYSTEMATICCOLORNM"));	  // �n���F����
                    //wkStcDtlDataRefResultWork.LargeGoodsGanreCode	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_LARGEGOODSGANRECODE"));	  // ���i�敪�O���[�v�R�[�h
                    //wkStcDtlDataRefResultWork.LargeGoodsGanreName	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_LARGEGOODSGANRENAME"));	  // ���i�敪�O���[�v����
                    //wkStcDtlDataRefResultWork.MediumGoodsGanreCode	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_MEDIUMGOODSGANRECODE"));	  // ���i�敪�R�[�h
                    //wkStcDtlDataRefResultWork.MediumGoodsGanreName	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_MEDIUMGOODSGANRENAME"));	  // ���i�敪����
                    //wkStcDtlDataRefResultWork.StockCount			= SqlDataMediator.SqlGetDouble	(myReader, myReader.GetOrdinal("STD_STOCKCOUNT"));	  // �d����
                    //wkStcDtlDataRefResultWork.StockUnitPrice		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STD_STOCKUNITPRICE"));	  // �d���P��
                    //wkStcDtlDataRefResultWork.StockUnitTaxPrice		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STD_STOCKUNITTAXPRICE"));	  // �d���P���i�ō��݁j
                    //wkStcDtlDataRefResultWork.StockPriceTaxExc		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STD_STOCKPRICETAXEXC"));	  // �d�����z�i�Ŕ����j
                    //wkStcDtlDataRefResultWork.StockPriceTaxInc		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STD_STOCKPRICETAXINC"));	  // �d�����z�i�ō��݁j
                    //wkStcDtlDataRefResultWork.TaxationCode			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_TAXATIONCODE"));	  // �ېŋ敪
                    //wkStcDtlDataRefResultWork.StockDtiSlipNote1		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_STOCKDTISLIPNOTE1"));	  // �d���`�[���ה��l1
                    //wkStcDtlDataRefResultWork.CarrierEpCode			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_CARRIEREPCODE"));	  // ���Ǝ҃R�[�h
                    //wkStcDtlDataRefResultWork.CarrierEpName			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_CARRIEREPNAME"));	  // ���ƎҖ���
                    //wkStcDtlDataRefResultWork.GoodsSetCode			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_GOODSSETCODE"));	  // ���i�Z�b�g�R�[�h
                    //wkStcDtlDataRefResultWork.GoodsSetName			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_GOODSSETNAME"));	  // ���i�Z�b�g����
                    //wkStcDtlDataRefResultWork.GoodsSetDivCd			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_GOODSSETDIVCD"));	  // �Z�b�g���i�敪
                    //wkStcDtlDataRefResultWork.SetUnitPriceTaxInc	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STD_SETUNITPRICETAXINC"));	  // �Z�b�g�P�i�P���i�ō��݁j
                    //wkStcDtlDataRefResultWork.SetUnitPriceTaxExc	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STD_SETUNITPRICETAXEXC"));	  // �Z�b�g�P�i�P���i�Ŕ����j
                    //wkStcDtlDataRefResultWork.WarehouseCode			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_WAREHOUSECODE"));	  // �q�ɃR�[�h
                    //wkStcDtlDataRefResultWork.WarehouseName			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_WAREHOUSENAME"));	  // �q�ɖ���
                    //wkStcDtlDataRefResultWork.StockGoodsCd			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_STOCKGOODSCD"));	  // �d�����i�敪
                    //wkStcDtlDataRefResultWork.StockMngExistCd		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_STOCKMNGEXISTCD"));	  // �݌ɊǗ��L���敪
                    //wkStcDtlDataRefResultWork.PrdNumMngDiv			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_PRDNUMMNGDIV"));	  // ���ԊǗ��敪
                    //wkStcDtlDataRefResultWork.TaxAdjust				= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STD_TAXADJUST"));	  // ����Œ����z
                    //wkStcDtlDataRefResultWork.BalanceAdjust			= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STD_BALANCEADJUST"));	  // �c�������z
                    //wkStcDtlDataRefResultWork.AcceptAnOrderNo		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_ACCEPTANORDERNO"));	  // �󒍔ԍ�
                    //wkStcDtlDataRefResultWork.SalesRowNo			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_SALESROWNO"));	  // ����s�ԍ�
                    #endregion
                    //�d�����׃f�[�^�i�[
                    wkStcDtlDataRefResultWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                    wkStcDtlDataRefResultWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                    wkStcDtlDataRefResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    wkStcDtlDataRefResultWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
                    wkStcDtlDataRefResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkStcDtlDataRefResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    wkStcDtlDataRefResultWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    wkStcDtlDataRefResultWork.MinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINSECTIONCODERF"));
                    wkStcDtlDataRefResultWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
                    wkStcDtlDataRefResultWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
                    wkStcDtlDataRefResultWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));
                    wkStcDtlDataRefResultWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));
                    wkStcDtlDataRefResultWork.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSYNCRF"));
                    wkStcDtlDataRefResultWork.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSYNCRF"));
                    wkStcDtlDataRefResultWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
                    wkStcDtlDataRefResultWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
                    wkStcDtlDataRefResultWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
                    wkStcDtlDataRefResultWork.StockMngExistCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMNGEXISTCDRF"));
                    wkStcDtlDataRefResultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                    wkStcDtlDataRefResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkStcDtlDataRefResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkStcDtlDataRefResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkStcDtlDataRefResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkStcDtlDataRefResultWork.LargeGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRECODERF"));
                    wkStcDtlDataRefResultWork.LargeGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRENAMERF"));
                    wkStcDtlDataRefResultWork.MediumGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRECODERF"));
                    wkStcDtlDataRefResultWork.MediumGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRENAMERF"));
                    wkStcDtlDataRefResultWork.DetailGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRECODERF"));
                    wkStcDtlDataRefResultWork.DetailGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRENAMERF"));
                    wkStcDtlDataRefResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkStcDtlDataRefResultWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    wkStcDtlDataRefResultWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                    wkStcDtlDataRefResultWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
                    wkStcDtlDataRefResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkStcDtlDataRefResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    wkStcDtlDataRefResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkStcDtlDataRefResultWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
                    wkStcDtlDataRefResultWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    wkStcDtlDataRefResultWork.UnitCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNITCODERF"));
                    wkStcDtlDataRefResultWork.UnitName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UNITNAMERF"));
                    wkStcDtlDataRefResultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                    wkStcDtlDataRefResultWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                    wkStcDtlDataRefResultWork.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPRATEGRPCODERF"));
                    wkStcDtlDataRefResultWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    wkStcDtlDataRefResultWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
                    wkStcDtlDataRefResultWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
                    wkStcDtlDataRefResultWork.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSTCKUNPRCRF"));
                    wkStcDtlDataRefResultWork.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSTCKUNPRCRF"));
                    wkStcDtlDataRefResultWork.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSTCKUNPRCRF"));
                    wkStcDtlDataRefResultWork.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSTCKUNPRCRF"));
                    wkStcDtlDataRefResultWork.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSTCKUNPRCRF"));
                    wkStcDtlDataRefResultWork.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSTCUNPRCRF"));
                    wkStcDtlDataRefResultWork.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSTCKUNPRCRF"));
                    wkStcDtlDataRefResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    wkStcDtlDataRefResultWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
                    wkStcDtlDataRefResultWork.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNITCHNGDIVRF"));
                    wkStcDtlDataRefResultWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
                    wkStcDtlDataRefResultWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
                    wkStcDtlDataRefResultWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));
                    wkStcDtlDataRefResultWork.BargainCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BARGAINCDRF"));
                    wkStcDtlDataRefResultWork.BargainNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BARGAINNMRF"));
                    wkStcDtlDataRefResultWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
                    wkStcDtlDataRefResultWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                    wkStcDtlDataRefResultWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
                    wkStcDtlDataRefResultWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
                    wkStcDtlDataRefResultWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
                    wkStcDtlDataRefResultWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
                    wkStcDtlDataRefResultWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
                    wkStcDtlDataRefResultWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
                    wkStcDtlDataRefResultWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));
                    wkStcDtlDataRefResultWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));
                    wkStcDtlDataRefResultWork.SalesCustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERNAMERF"));
                    wkStcDtlDataRefResultWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
                    wkStcDtlDataRefResultWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
                    wkStcDtlDataRefResultWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
                    wkStcDtlDataRefResultWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
                    wkStcDtlDataRefResultWork.SlipMemo4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO4RF"));
                    wkStcDtlDataRefResultWork.SlipMemo5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO5RF"));
                    wkStcDtlDataRefResultWork.SlipMemo6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO6RF"));
                    wkStcDtlDataRefResultWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
                    wkStcDtlDataRefResultWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
                    wkStcDtlDataRefResultWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
                    wkStcDtlDataRefResultWork.InsideMemo4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO4RF"));
                    wkStcDtlDataRefResultWork.InsideMemo5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO5RF"));
                    wkStcDtlDataRefResultWork.InsideMemo6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO6RF"));
                    wkStcDtlDataRefResultWork.StockCheckDivCAddUp = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKCHECKDIVCADDUPRF"));
                    wkStcDtlDataRefResultWork.StockCheckDivDaily = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKCHECKDIVDAILYRF"));
                    // �� 2007.12.04 980081 c
                    #endregion

                    stcDtlDtList.Add(wkStcDtlDataRefResultWork);

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
                base.WriteErrorLog(ex, "StcDataRefListWorkDB.ReadStcDtlDataRefAction Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region �d���ڍ׎擾�����i���s���j(�폜)
        // �� 2007.12.04 980081 d
        ///// <summary>
        ///// �d���ڍ׎擾�����i���s���j
        ///// </summary>
        ///// <param name="stcExDtList">��������ArrayList</param>
        ///// <param name="sqlConnection">SqlConnection</param>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="supplierFomal">�d���`��</param>
        ///// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <returns>Status</returns>
        //private int ReadStcExDataRefAction(ref ArrayList stcExDtList, ref SqlConnection sqlConnection, 
        //	string enterpriseCode, int supplierFomal, int supplierSlipNo, ConstantManagement.LogicalMode logicalMode)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;
        //
        //    try
        //    {
        //        // �Ώۃe�[�u��
        //        // StockExplaData  SED   �d���ڍ׃f�[�^
        //        // SECINFOSETRF   SIS   ���_���ݒ�}�X�^
        //
        //        StringBuilder SelectDm = new StringBuilder();
        //
        //        #region Select���쐬
        //        SelectDm.Append( "SELECT" );
        //
        //		//�d���f�[�^���ʎ擾
        //		SelectDm.Append( " SED.SECTIONCODERF SED_SECTIONCODE" );		// ���_�R�[�h
        //		SelectDm.Append( ", SED.SUPPLIERFORMALRF SED_SUPPLIERFORMAL" );		// �d���`��
        //		SelectDm.Append( ", SED.SUPPLIERSLIPNORF SED_SUPPLIERSLIPNO" );		// �d���`�[�ԍ�
        //		SelectDm.Append( ", SED.STOCKROWNORF SED_STOCKROWNO" );		// �d���s�ԍ�
        //		SelectDm.Append( ", SED.STCKSLIPEXPNUMRF SED_STCKSLIPEXPNUM" );		// �d���ڍהԍ�
        //		SelectDm.Append( ", SED.PRODUCTNUMBER1RF SED_PRODUCTNUMBER1" );		// �����ԍ�1
        //		SelectDm.Append( ", SED.PRODUCTNUMBER2RF SED_PRODUCTNUMBER2" );		// �����ԍ�2
        //		SelectDm.Append( ", SED.STOCKTELNO1RF SED_STOCKTELNO1" );		// ���i�d�b�ԍ�1
        //		SelectDm.Append( ", SED.STOCKTELNO2RF SED_STOCKTELNO2" );		// ���i�d�b�ԍ�2
        //		SelectDm.Append( ", SED.STOCKEXPSLIPNOTERF SED_STOCKEXPSLIPNOTE" );		// �d���`�[�ڍה��l
        //		SelectDm.Append( ", SED.PRODUCTSTOCKGUIDRF SED_PRODUCTSTOCKGUID" );		// ���ԍ݌Ƀ}�X�^GUID
        //
        //        SelectDm.Append( ", SIS.SECTIONGUIDENMRF SIS_SECTIONGUIDENM" );
        //
        //		SelectDm.Append( " FROM STOCKEXPLADATARF SED" );
        //		SelectDm.Append( " LEFT JOIN SECINFOSETRF SIS ON SIS.ENTERPRISECODERF=SED.ENTERPRISECODERF AND SIS.SECTIONCODERF=SED.SECTIONCODERF" );
        //        #endregion
        //
        //        sqlCommand = new SqlCommand(SelectDm.ToString(), sqlConnection);
        //
        //        //WHERE���̍쐬
        //        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, "SED", enterpriseCode,  supplierFomal, supplierSlipNo, logicalMode );
        //		// Sort
        //		sqlCommand.CommandText +=" ORDER BY SED.SUPPLIERSLIPNORF, SED.STOCKROWNORF, SED.STCKSLIPEXPNUMRF";
        //
        //        myReader = sqlCommand.ExecuteReader();
        //
        //        while (myReader.Read())
        //        {
        //            #region ���o����-�l�Z�b�g
        //            StcExDataRefWork wkStcExDataRefResultWork = new StcExDataRefWork();
        //
        //            // �d���ڍ׃f�[�^���ʎ擾���e�i�[
        //			wkStcExDataRefResultWork.SectionCode        = SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SED_SECTIONCODE"));			// ���_�R�[�h
        //			wkStcExDataRefResultWork.SectionGuideNm     = SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SIS_SECTIONGUIDENM"));		// ���_�K�C�h����
        //			wkStcExDataRefResultWork.SupplierFormal     = SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("SED_SUPPLIERFORMAL"));		// �d���`��
        //			wkStcExDataRefResultWork.SupplierSlipNo     = SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("SED_SUPPLIERSLIPNO"));		// �d���`�[�ԍ�
        //			wkStcExDataRefResultWork.StockRowNo         = SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("SED_STOCKROWNO"));			// �d���s�ԍ�
        //			wkStcExDataRefResultWork.StckSlipExpNum     = SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("SED_STCKSLIPEXPNUM"));		// �d���ڍהԍ�
        //			wkStcExDataRefResultWork.ProductNumber1     = SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SED_PRODUCTNUMBER1"));		// �����ԍ�1
        //			wkStcExDataRefResultWork.ProductNumber2     = SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SED_PRODUCTNUMBER2"));		// �����ԍ�2
        //			wkStcExDataRefResultWork.StockTelNo1        = SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SED_STOCKTELNO1"));			// ���i�d�b�ԍ�1
        //			wkStcExDataRefResultWork.StockTelNo2        = SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SED_STOCKTELNO2"));			// ���i�d�b�ԍ�2
        //			wkStcExDataRefResultWork.StockExpSlipNote   = SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SED_STOCKEXPSLIPNOTE"));	// �d���`�[�ڍה��l
        //			wkStcExDataRefResultWork.ProductStockGuid	= SqlDataMediator.SqlGetGuid	(myReader, myReader.GetOrdinal("SED_PRODUCTSTOCKGUID"));		// ���ԍ݌Ƀ}�X�^GUID
        //            #endregion
        //
        //            stcExDtList.Add(wkStcExDataRefResultWork);
        //
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "StcDataRefListWorkDB.ReadStcExDataRefAction Exception=" + ex.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlCommand != null) sqlCommand.Dispose();
        //        if (!myReader.IsClosed) myReader.Close();
        //    }
        //
        //    return status;
        //}
        // �� 2007.12.04 980081 d
        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="tableNm">�e�[�u������</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="supplierFomal">�d���`��</param>
        /// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, string tableNm, string enterpriseCode, int supplierFomal, int supplierSlipNo, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            StringBuilder retstring = new StringBuilder();
            retstring.Append(" WHERE");

            // ��ƃR�[�h
            retstring.Append(string.Format(" {0}.ENTERPRISECODERF=@ENTERPRISECODE", tableNm));
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring.Append(string.Format(" AND {0}.LOGICALDELETECODERF=@FINDLOGICALDELETECODE", tableNm));
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring.Append(string.Format(" AND {0}.LOGICALDELETECODERF<@FINDLOGICALDELETECODE", tableNm));
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //// ���_�R�[�h
            //retstring.Append( string.Format( " AND {0}.{1}=@SECTIONCODE", tableNm, selectSecID ) );
            //SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            //paraSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);

            // �d���`��
            retstring.Append(string.Format(" AND {0}.SUPPLIERFORMALRF=@SUPPLIERFORMAL", tableNm));
            SqlParameter paraSupplierFomal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
            paraSupplierFomal.Value = SqlDataMediator.SqlSetInt32(supplierFomal);

            // �d���`�[�ԍ�
            retstring.Append(string.Format(" AND {0}.SUPPLIERSLIPNORF=@SUPPLIERSLIPNO", tableNm));
            SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
            paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(supplierSlipNo);

            #endregion
            return retstring.ToString();
        }
    }
}
