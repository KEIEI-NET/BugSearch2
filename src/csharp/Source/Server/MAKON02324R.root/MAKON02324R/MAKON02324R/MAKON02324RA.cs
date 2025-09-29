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
    /// 仕入データ参照DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入データ参照の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22013 kubo</br>
    /// <br>Date       : 2007.06.06</br>
    /// <br></br>
    /// <br>Update Note: 2007.12.04  980081 山田 明友</br>
    /// <br>           : 流通基幹対応</br>
    /// <br>           : 1.仕入詳細データ削除対応</br>
    /// <br>           : 2.レイアウト変更対応</br>
    /// </remarks>
    [Serializable]
    public class StcDataRefListWorkDB : RemoteDB, IStcDataRefListWorkDB
    {
        /// <summary>
        /// 仕入データ参照DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.06.06</br>
        /// Update Note    : 30290
        ///                : 2008.04.24 得意先・仕入先切り分け
        /// </remarks>
        public StcDataRefListWorkDB()
            :
        base("MAKON02326D", "Broadleaf.Application.Remoting.ParamData.StcDataRefWork", "STOCKSLIPRF") //基底クラスのコンストラクタ
        {
        }

        #region 仕入データ取得処理
        /// <summary>
        /// 仕入伝票情報Listを取得する(論理削除除く)
        /// </summary>
        /// <param name="stcDataRefListWork">検索結果(伝票)</param>
        /// <param name="stcDtlDataRefListWork">検索結果(伝票明細)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierFomal">仕入形式</param>
        /// <param name="supplierSlipNo">仕入伝票番号</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 伝票情報Listを取得する</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.06.06</br>
        /// </remarks>
        // ↓ 2007.12.04 980081 c
        //public int Read(out object stcDataRefListWork, out object stcDtlDataRefListWork, out object stcExDataRefListWork,
        //    string enterpriseCode, int supplierFomal, int supplierSlipNo, int readMode, ConstantManagement.LogicalMode logicalMode)
        public int Read(out object stcDataRefListWork, out object stcDtlDataRefListWork,
            string enterpriseCode, int supplierFomal, int supplierSlipNo, int readMode, ConstantManagement.LogicalMode logicalMode)
        // ↑ 2007.12.04 980081 c
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stcDataRefListWork = null;
            stcDtlDataRefListWork = null;
            // ↓ 2007.12.04 980081 d
            //stcExDataRefListWork = null;
            // ↑ 2007.12.04 980081 d

            try
            {
                // ↓ 2007.12.04 980081 c
                //status = ReadProc(out stcDataRefListWork, out stcDtlDataRefListWork, out stcExDataRefListWork,
                //    enterpriseCode, supplierFomal, supplierSlipNo, readMode, logicalMode);
                status = ReadProc(out stcDataRefListWork, out stcDtlDataRefListWork,
                    enterpriseCode, supplierFomal, supplierSlipNo, readMode, logicalMode);
                // ↑ 2007.12.04 980081 c
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StcDataRefListWorkDB.SearchDepsitOnly Exception=" + ex.Message);
                stcDataRefListWork = null;
                stcDtlDataRefListWork = null;
                // ↓ 2007.12.04 980081 d
                //stcExDataRefListWork = null;
                // ↑ 2007.12.04 980081 d
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの仕入データ参照LISTを全て戻します
        /// </summary>
        /// <param name="stcDataRefListWork">検索結果(伝票)</param>
        /// <param name="stcDtlDataRefListWork">検索結果(伝票明細)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierFomal">仕入形式</param>
        /// <param name="supplierSlipNo">仕入伝票番号</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードの仕入データ参照LISTを全て戻します</br>
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.06.06</br>
        /// </remarks>
        // ↓ 2007.12.04 980081 c
        //public int ReadProc( out object stcDataRefListWork, out object stcDtlDataRefListWork, out object stcExDataRefListWork, 
        //	string enterpriseCode, int supplierFomal, int supplierSlipNo, int readMode, ConstantManagement.LogicalMode logicalMode)
        public int ReadProc(out object stcDataRefListWork, out object stcDtlDataRefListWork,
            string enterpriseCode, int supplierFomal, int supplierSlipNo, int readMode, ConstantManagement.LogicalMode logicalMode)
        // ↑ 2007.12.04 980081 c
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int st1 = status;
            int st2 = status;
            // ↓ 2007.12.04 980081 d
            //int st3 = status;
            // ↑ 2007.12.04 980081 d
            SqlConnection sqlConnection = null;
            SqlEncryptInfo sqlEncryptInfo = null;

            stcDataRefListWork = null;
            stcDtlDataRefListWork = null;
            // ↓ 2007.12.04 980081 d
            //stcExDataRefListWork = null;
            // ↑ 2007.12.04 980081 d

            ArrayList stcDtList = new ArrayList();	//抽出結果(仕入データ)
            ArrayList stcDtlDtList = new ArrayList();  //抽出結果(仕入明細データ)
            // ↓ 2007.12.04 980081 d
            //ArrayList stcExDtList	= new ArrayList();  //抽出結果(仕入詳細データ)
            // ↑ 2007.12.04 980081 d

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //●暗号化部品準備処理
                sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SUPPLIERRF" });
                //暗号化キーOPEN（SQLExceptionの可能性有り）
                sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //仕入データ取得実行部
                st1 = ReadStcDataRefAction(ref stcDtList, ref sqlConnection, enterpriseCode, supplierFomal, supplierSlipNo, logicalMode);
                //仕入明細データ取得実行部
                st2 = ReadStcDtlDataRefAction(ref stcDtlDtList, ref sqlConnection, enterpriseCode, supplierFomal, supplierSlipNo, logicalMode);
                // ↓ 2007.12.04 980081 d
                ////仕入詳細データ取得実行部
                //st3 = ReadStcExDataRefAction(ref stcExDtList, ref sqlConnection, enterpriseCode, supplierFomal, supplierSlipNo, logicalMode);
                // ↑ 2007.12.04 980081 d

                status = st1;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
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
                    //暗号化キークローズ
                    if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            stcDataRefListWork = stcDtList;
            stcDtlDataRefListWork = stcDtlDtList;
            // ↓ 2007.12.04 980081 d
            //stcExDataRefListWork = stcExDtList;
            // ↑ 2007.12.04 980081 d

            return status;
        }
        #endregion

        #region 仕入データ取得処理（実行部）
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="stcDtList">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierFomal">仕入形式</param>
        /// <param name="supplierSlipNo">仕入伝票番号</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int ReadStcDataRefAction(ref ArrayList stcDtList, ref SqlConnection sqlConnection,
            string enterpriseCode, int supplierFomal, int supplierSlipNo, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // 対象テーブル
                // StockSlipRF		STS   仕入データ
                // SECINFOSETRF		SIS,SIS2,SIS3   拠点情報設定マスタ

                StringBuilder SelectDm = new StringBuilder();

                #region Select文作成
                SelectDm.Append("SELECT");

                //仕入データ結果取得
                // ↓ 2007.12.04 980081 c
                #region 旧レイアウト(コメントアウト)
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
                // ↑ 2007.12.04 980081 c
                #endregion

                sqlCommand = new SqlCommand(SelectDm.ToString(), sqlConnection);

                //WHERE文の作成
                // Where文
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, "STS", enterpriseCode, supplierFomal, supplierSlipNo, logicalMode);
                // Sort
                sqlCommand.CommandText += " ORDER BY STS.SUPPLIERSLIPNORF";

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    StcDataRefWork wkStcDataRefResultWork = new StcDataRefWork();

                    // ↓ 2007.12.04 980081 c
                    #region 旧レイアウト(コメントアウト)
                    //在庫車両入出庫管理マスタ結果取得内容格納
                    //wkStcDataRefResultWork.SectionCode				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_SECTIONCODERF"));			// 拠点コード
                    //wkStcDataRefResultWork.StockSectionCd 			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_STOCKSECTIONCDRF"));		// 仕入拠点コード
                    //wkStcDataRefResultWork.StockAddUpSectionCd		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_STOCKADDUPSECTIONCDRF"));	// 仕入計上拠点コード
                    //
                    //wkStcDataRefResultWork.StockSectionNm 			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SIS_SECTIONGUIDENMRF"));		// 仕入拠点名称
                    //wkStcDataRefResultWork.SectionGuideNm			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SIS2_STOCKSECTIONNMRF"));	// 拠点ガイド名称
                    //wkStcDataRefResultWork.StockAddUpSectionNm		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SIS3_STOCKADDUPSECTIONNMRF"));	// 仕入計上拠点名称
                    //
                    //wkStcDataRefResultWork.SupplierFormal			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_SUPPLIERFORMALRF"));		// 仕入形式
                    //wkStcDataRefResultWork.SupplierSlipNo			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_SUPPLIERSLIPNORF"));		// 仕入伝票番号
                    //wkStcDataRefResultWork.PartySaleSlipNum			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_PARTYSALESLIPNUMRF"));		// 相手先伝票番号
                    //wkStcDataRefResultWork.StockAgentCode			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_STOCKAGENTCODERF"));		// 仕入担当者コード
                    //wkStcDataRefResultWork.StockAgentName			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_STOCKAGENTNAMERF"));		// 仕入担当者名称
                    //wkStcDataRefResultWork.CustomerCode				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_CUSTOMERCODERF"));			// 得意先コード
                    //wkStcDataRefResultWork.CustomerName				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_CUSTOMERNAMERF"));			// 得意先名称
                    //wkStcDataRefResultWork.CustomerName2			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_CUSTOMERNAME2RF"));			// 得意先名称2
                    //wkStcDataRefResultWork.PayeeCode				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_PAYEECODERF"));				// 支払先コード
                    //wkStcDataRefResultWork.PayeeName1				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_PAYEENAME1RF"));			// 支払先名称1
                    //wkStcDataRefResultWork.Payeename2				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_PAYEENAME2RF"));			// 支払先名称2
                    //wkStcDataRefResultWork.PaymentDate				= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STS_PAYMENTDATERF"));			// 支払日付
                    //wkStcDataRefResultWork.InputDay					= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_INPUTDAYRF"));				// 入力日
                    //wkStcDataRefResultWork.ArrivalGoodsDay			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_ARRIVALGOODSDAYRF"));		// 入荷日
                    //wkStcDataRefResultWork.StockDate				= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STS_STOCKDATERF"));				// 仕入日
                    //wkStcDataRefResultWork.StockAddUpADate			= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STS_STOCKADDUPADATERF"));		// 仕入計上日付
                    //wkStcDataRefResultWork.SupplierSlipCd			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_SUPPLIERSLIPCDRF"));		// 仕入伝票区分
                    //wkStcDataRefResultWork.AccPayDivCd				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_ACCPAYDIVCDRF"));			// 買掛区分
                    //wkStcDataRefResultWork.DebitNoteDiv				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_DEBITNOTEDIVRF"));			// 赤伝区分
                    //wkStcDataRefResultWork.DebitNLnkSuppSlipNo		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_DEBITNLNKSUPPSLIPNORF"));	// 赤黒連結仕入伝票番号
                    //wkStcDataRefResultWork.StockTotalPrice			= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STS_STOCKTOTALPRICERF"));		// 仕入金額合計
                    //wkStcDataRefResultWork.StockSubttlPrice			= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STS_STOCKSUBTTLPRICERF"));		// 仕入金額小計
                    //wkStcDataRefResultWork.StockTtlPricTaxInc 		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STS_STOCKTTLPRICTAXINCRF"));	// 仕入金額計（税込み）
                    //wkStcDataRefResultWork.StockTtlPricTaxExc 		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STS_STOCKTTLPRICTAXEXCRF"));	// 仕入金額計（税抜き）
                    //wkStcDataRefResultWork.TtlItdedStockTaxFree 	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STS_TTLITDEDSTOCKTAXFREERF"));	// 仕入非課税対象額合計
                    //wkStcDataRefResultWork.StockPriceConsTax		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STS_STOCKPRICECONSTAXRF"));		// 仕入金額消費税額
                    //wkStcDataRefResultWork.SuppCTaxLayCd			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_SUPPCTAXLAYCDRF"));			// 仕入先消費税転嫁方式コード
                    //wkStcDataRefResultWork.SupplierConsTaxRate 		= SqlDataMediator.SqlGetDouble	(myReader, myReader.GetOrdinal("STS_SUPPLIERCONSTAXRATERF"));	// 仕入先消費税税率
                    //wkStcDataRefResultWork.StockFractionProcCd 		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_STOCKFRACTIONPROCCDRF"));	// 仕入端数処理区分
                    //wkStcDataRefResultWork.SuppTtlAmntDspWayCd 		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_SUPPTTLAMNTDSPWAYCDRF"));	// 仕入先総額表示方法区分
                    //wkStcDataRefResultWork.SupplierSlipNote1 		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_SUPPLIERSLIPNOTE1RF"));		// 仕入伝票備考1
                    //wkStcDataRefResultWork.SupplierSlipNote2 		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_SUPPLIERSLIPNOTE2RF"));		// 仕入伝票備考2
                    //wkStcDataRefResultWork.CarrierEpCode 			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_CARRIEREPCODERF"));			// 事業者コード
                    //wkStcDataRefResultWork.CarrierEpName 			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_CARRIEREPNAMERF"));			// 事業者名称
                    //wkStcDataRefResultWork.WarehouseCode 			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_WAREHOUSECODERF"));			// 倉庫コード
                    //wkStcDataRefResultWork.WarehouseName 			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_WAREHOUSENAMERF"));			// 倉庫名称
                    //wkStcDataRefResultWork.StockGoodsCd				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_STOCKGOODSCDRF"));			// 仕入商品区分
                    //wkStcDataRefResultWork.TaxAdjust				= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STS_TAXADJUSTRF"));				// 消費税調整額
                    //wkStcDataRefResultWork.BalanceAdjust			= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STS_BALANCEADJUSTRF"));			// 残高調整額
                    //wkStcDataRefResultWork.TrustAddUpSpCd			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_TRUSTADDUPSPCDRF"));		// 受託計上仕入区分
                    //wkStcDataRefResultWork.RetGoodsReasonDiv		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_RETGOODSREASONDIVRF"));		// 返品理由コード
                    //wkStcDataRefResultWork.RetGoodsReason			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STS_RETGOODSREASONRF"));		// 返品理由
                    //wkStcDataRefResultWork.AcceptAnOrderNo			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_ACCEPTANORDERNORF"));		// 受注番号
                    //wkStcDataRefResultWork.SalesRowNo				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STS_SALESROWNORF"));			// 売上行番号
                    #endregion
                    //仕入データ格納
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
                    // ↑ 2007.12.04 980081 c
                    #endregion

                    stcDtList.Add(wkStcDataRefResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
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

        #region 仕入明細データ取得処理（実行部）
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="stcDtlDtList">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierFomal">仕入形式</param>
        /// <param name="supplierSlipNo">仕入伝票番号</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Status</returns>
        private int ReadStcDtlDataRefAction(ref ArrayList stcDtlDtList, ref SqlConnection sqlConnection,
            string enterpriseCode, int supplierFomal, int supplierSlipNo, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // 対象テーブル
                // StockDetailRF	STD   仕入データ
                // SECINFOSETRF		SIS   拠点情報設定マスタ

                StringBuilder SelectDm = new StringBuilder();

                #region Select文作成
                SelectDm.Append("SELECT");

                //仕入データ結果取得
                // ↓ 2007.12.04 980081 c
                #region 旧レイアウト(コメントアウト)
                //SelectDm.Append( " STD.SECTIONCODERF STD_SECTIONCODE" );						// 拠点コード
                //SelectDm.Append( ", STD.SUPPLIERFORMALRF STD_SUPPLIERFORMAL" );					// 仕入形式
                //SelectDm.Append( ", STD.SUPPLIERSLIPNORF STD_SUPPLIERSLIPNO" );					// 仕入伝票番号
                //SelectDm.Append( ", STD.STOCKROWNORF STD_STOCKROWNO" );							// 仕入行番号
                //SelectDm.Append( ", STD.STOCKAGENTCODERF STD_STOCKAGENTCODE" );					// 仕入担当者コード
                //SelectDm.Append( ", STD.STOCKAGENTNAMERF STD_STOCKAGENTNAME" );					// 仕入担当者名
                //SelectDm.Append( ", STD.CARRIERCODERF STD_CARRIERCODE" );  						// キャリアコード
                //SelectDm.Append( ", STD.CARRIERNAMERF STD_CARRIERNAME" );  						// キャリア名称
                //SelectDm.Append( ", STD.MAKERCODERF STD_MAKERCODE" );  							// メーカーコード
                //SelectDm.Append( ", STD.MAKERNAMERF STD_MAKERNAME" );  							// メーカー名称
                //SelectDm.Append( ", STD.GOODSCODERF STD_GOODSCODE" );  							// 商品コード
                //SelectDm.Append( ", STD.GOODSNAMERF STD_GOODSNAME" );  							// 商品名称
                //SelectDm.Append( ", STD.GOODSKINDCODERF STD_GOODSKINDCODE" );					// 商品属性
                //SelectDm.Append( ", STD.CELLPHONEMODELCODERF STD_CELLPHONEMODELCODE" );			// 機種コード
                //SelectDm.Append( ", STD.CELLPHONEMODELNAMERF STD_CELLPHONEMODELNAME" );			// 機種名称
                //SelectDm.Append( ", STD.SYSTEMATICCOLORCDRF STD_SYSTEMATICCOLORCD" );			// 系統色コード
                //SelectDm.Append( ", STD.SYSTEMATICCOLORNMRF STD_SYSTEMATICCOLORNM" );			// 系統色名称
                //SelectDm.Append( ", STD.LARGEGOODSGANRECODERF STD_LARGEGOODSGANRECODE" );  		// 商品区分グループコード
                //SelectDm.Append( ", STD.LARGEGOODSGANRENAMERF STD_LARGEGOODSGANRENAME" );  		// 商品区分グループ名称
                //SelectDm.Append( ", STD.MEDIUMGOODSGANRECODERF STD_MEDIUMGOODSGANRECODE" );		// 商品区分コード
                //SelectDm.Append( ", STD.MEDIUMGOODSGANRENAMERF STD_MEDIUMGOODSGANRENAME" );		// 商品区分名称
                //SelectDm.Append( ", STD.STOCKCOUNTRF STD_STOCKCOUNT" );							// 仕入数
                //SelectDm.Append( ", STD.STOCKUNITPRICERF STD_STOCKUNITPRICE" );					// 仕入単価
                //SelectDm.Append( ", STD.STOCKUNITTAXPRICERF STD_STOCKUNITTAXPRICE" );			// 仕入単価（税込み）
                //SelectDm.Append( ", STD.STOCKPRICETAXEXCRF STD_STOCKPRICETAXEXC" );  			// 仕入金額（税抜き）
                //SelectDm.Append( ", STD.STOCKPRICETAXINCRF STD_STOCKPRICETAXINC" );  			// 仕入金額（税込み）
                //SelectDm.Append( ", STD.TAXATIONCODERF STD_TAXATIONCODE" );						// 課税区分
                //SelectDm.Append( ", STD.STOCKDTISLIPNOTE1RF STD_STOCKDTISLIPNOTE1" );			// 仕入伝票明細備考1
                //SelectDm.Append( ", STD.CARRIEREPCODERF STD_CARRIEREPCODE" );					// 事業者コード
                //SelectDm.Append( ", STD.CARRIEREPNAMERF STD_CARRIEREPNAME" );					// 事業者名称
                //SelectDm.Append( ", STD.GOODSSETCODERF STD_GOODSSETCODE" );  					// 商品セットコード
                //SelectDm.Append( ", STD.GOODSSETNAMERF STD_GOODSSETNAME" );  					// 商品セット名称
                //SelectDm.Append( ", STD.GOODSSETDIVCDRF STD_GOODSSETDIVCD" );					// セット商品区分
                //SelectDm.Append( ", STD.SETUNITPRICETAXINCRF STD_SETUNITPRICETAXINC" );  		// セット単品単価（税込み）
                //SelectDm.Append( ", STD.SETUNITPRICETAXEXCRF STD_SETUNITPRICETAXEXC" );  		// セット単品単価（税抜き）
                //SelectDm.Append( ", STD.WAREHOUSECODERF STD_WAREHOUSECODE" );					// 倉庫コード
                //SelectDm.Append( ", STD.WAREHOUSENAMERF STD_WAREHOUSENAME" );					// 倉庫名称
                //SelectDm.Append( ", STD.STOCKGOODSCDRF STD_STOCKGOODSCD" );						// 仕入商品区分
                //SelectDm.Append( ", STD.STOCKMNGEXISTCDRF STD_STOCKMNGEXISTCD" );				// 在庫管理有無区分
                //SelectDm.Append( ", STD.PRDNUMMNGDIVRF STD_PRDNUMMNGDIV" );						// 製番管理区分
                //SelectDm.Append( ", STD.TAXADJUSTRF STD_TAXADJUST" );							// 消費税調整額
                //SelectDm.Append( ", STD.BALANCEADJUSTRF STD_BALANCEADJUST" );					// 残高調整額
                //SelectDm.Append( ", STD.ACCEPTANORDERNORF STD_ACCEPTANORDERNO" );				// 受注番号
                //SelectDm.Append( ", STD.SALESROWNORF STD_SALESROWNO" );								// 売上行番号
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
                // ↑ 2007.12.04 980081 c
                #endregion

                sqlCommand = new SqlCommand(SelectDm.ToString(), sqlConnection);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, "STD", enterpriseCode, supplierFomal, supplierSlipNo, logicalMode);
                // Sort
                sqlCommand.CommandText += " ORDER BY STD.SUPPLIERSLIPNORF, STD.STOCKROWNORF";

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    StcDtlDataRefWork wkStcDtlDataRefResultWork = new StcDtlDataRefWork();

                    // ↓ 2007.12.04 980081 c
                    #region 旧レイアウト(コメントアウト)
                    //在庫車両入出庫管理マスタ結果取得内容格納
                    //wkStcDtlDataRefResultWork.SectionCode			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_SECTIONCODE"));	  // 拠点コード
                    //wkStcDtlDataRefResultWork.SectionGuideNm		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SIS_SECTIONGUIDENM"));	  // 拠点ガイド名称
                    //wkStcDtlDataRefResultWork.SupplierFormal		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_SUPPLIERFORMAL"));	  // 仕入形式
                    //wkStcDtlDataRefResultWork.SupplierSlipNo		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_SUPPLIERSLIPNO"));	  // 仕入伝票番号
                    //wkStcDtlDataRefResultWork.StockRowNo			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_STOCKROWNO"));	  // 仕入行番号
                    //wkStcDtlDataRefResultWork.StockAgentCode		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_STOCKAGENTCODE"));	  // 仕入担当者コード
                    //wkStcDtlDataRefResultWork.StockAgentName		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_STOCKAGENTNAME"));	  // 仕入担当者名
                    //wkStcDtlDataRefResultWork.CarrierCode			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_CARRIERCODE"));	  // キャリアコード
                    //wkStcDtlDataRefResultWork.CarrierName			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_CARRIERNAME"));	  // キャリア名称
                    //wkStcDtlDataRefResultWork.MakerCode				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_MAKERCODE"));	  // メーカーコード
                    //wkStcDtlDataRefResultWork.MakerName				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_MAKERNAME"));	  // メーカー名称
                    //wkStcDtlDataRefResultWork.GoodsCode				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_GOODSCODE"));	  // 商品コード
                    //wkStcDtlDataRefResultWork.GoodsName				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_GOODSNAME"));	  // 商品名称
                    //wkStcDtlDataRefResultWork.GoodsKindCode			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_GOODSKINDCODE"));	  // 商品属性
                    //wkStcDtlDataRefResultWork.CellphoneModelCode	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_CELLPHONEMODELCODE"));	  // 機種コード
                    //wkStcDtlDataRefResultWork.CellphoneModelName	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_CELLPHONEMODELNAME"));	  // 機種名称
                    //wkStcDtlDataRefResultWork.SystematicColorCd		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_SYSTEMATICCOLORCD"));	  // 系統色コード
                    //wkStcDtlDataRefResultWork.SystematicColorNm		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_SYSTEMATICCOLORNM"));	  // 系統色名称
                    //wkStcDtlDataRefResultWork.LargeGoodsGanreCode	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_LARGEGOODSGANRECODE"));	  // 商品区分グループコード
                    //wkStcDtlDataRefResultWork.LargeGoodsGanreName	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_LARGEGOODSGANRENAME"));	  // 商品区分グループ名称
                    //wkStcDtlDataRefResultWork.MediumGoodsGanreCode	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_MEDIUMGOODSGANRECODE"));	  // 商品区分コード
                    //wkStcDtlDataRefResultWork.MediumGoodsGanreName	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_MEDIUMGOODSGANRENAME"));	  // 商品区分名称
                    //wkStcDtlDataRefResultWork.StockCount			= SqlDataMediator.SqlGetDouble	(myReader, myReader.GetOrdinal("STD_STOCKCOUNT"));	  // 仕入数
                    //wkStcDtlDataRefResultWork.StockUnitPrice		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STD_STOCKUNITPRICE"));	  // 仕入単価
                    //wkStcDtlDataRefResultWork.StockUnitTaxPrice		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STD_STOCKUNITTAXPRICE"));	  // 仕入単価（税込み）
                    //wkStcDtlDataRefResultWork.StockPriceTaxExc		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STD_STOCKPRICETAXEXC"));	  // 仕入金額（税抜き）
                    //wkStcDtlDataRefResultWork.StockPriceTaxInc		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STD_STOCKPRICETAXINC"));	  // 仕入金額（税込み）
                    //wkStcDtlDataRefResultWork.TaxationCode			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_TAXATIONCODE"));	  // 課税区分
                    //wkStcDtlDataRefResultWork.StockDtiSlipNote1		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_STOCKDTISLIPNOTE1"));	  // 仕入伝票明細備考1
                    //wkStcDtlDataRefResultWork.CarrierEpCode			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_CARRIEREPCODE"));	  // 事業者コード
                    //wkStcDtlDataRefResultWork.CarrierEpName			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_CARRIEREPNAME"));	  // 事業者名称
                    //wkStcDtlDataRefResultWork.GoodsSetCode			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_GOODSSETCODE"));	  // 商品セットコード
                    //wkStcDtlDataRefResultWork.GoodsSetName			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_GOODSSETNAME"));	  // 商品セット名称
                    //wkStcDtlDataRefResultWork.GoodsSetDivCd			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_GOODSSETDIVCD"));	  // セット商品区分
                    //wkStcDtlDataRefResultWork.SetUnitPriceTaxInc	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STD_SETUNITPRICETAXINC"));	  // セット単品単価（税込み）
                    //wkStcDtlDataRefResultWork.SetUnitPriceTaxExc	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STD_SETUNITPRICETAXEXC"));	  // セット単品単価（税抜き）
                    //wkStcDtlDataRefResultWork.WarehouseCode			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_WAREHOUSECODE"));	  // 倉庫コード
                    //wkStcDtlDataRefResultWork.WarehouseName			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("STD_WAREHOUSENAME"));	  // 倉庫名称
                    //wkStcDtlDataRefResultWork.StockGoodsCd			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_STOCKGOODSCD"));	  // 仕入商品区分
                    //wkStcDtlDataRefResultWork.StockMngExistCd		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_STOCKMNGEXISTCD"));	  // 在庫管理有無区分
                    //wkStcDtlDataRefResultWork.PrdNumMngDiv			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_PRDNUMMNGDIV"));	  // 製番管理区分
                    //wkStcDtlDataRefResultWork.TaxAdjust				= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STD_TAXADJUST"));	  // 消費税調整額
                    //wkStcDtlDataRefResultWork.BalanceAdjust			= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("STD_BALANCEADJUST"));	  // 残高調整額
                    //wkStcDtlDataRefResultWork.AcceptAnOrderNo		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_ACCEPTANORDERNO"));	  // 受注番号
                    //wkStcDtlDataRefResultWork.SalesRowNo			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("STD_SALESROWNO"));	  // 売上行番号
                    #endregion
                    //仕入明細データ格納
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
                    // ↑ 2007.12.04 980081 c
                    #endregion

                    stcDtlDtList.Add(wkStcDtlDataRefResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
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

        #region 仕入詳細取得処理（実行部）(削除)
        // ↓ 2007.12.04 980081 d
        ///// <summary>
        ///// 仕入詳細取得処理（実行部）
        ///// </summary>
        ///// <param name="stcExDtList">検索結果ArrayList</param>
        ///// <param name="sqlConnection">SqlConnection</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="supplierFomal">仕入形式</param>
        ///// <param name="supplierSlipNo">仕入伝票番号</param>
        ///// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
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
        //        // 対象テーブル
        //        // StockExplaData  SED   仕入詳細データ
        //        // SECINFOSETRF   SIS   拠点情報設定マスタ
        //
        //        StringBuilder SelectDm = new StringBuilder();
        //
        //        #region Select文作成
        //        SelectDm.Append( "SELECT" );
        //
        //		//仕入データ結果取得
        //		SelectDm.Append( " SED.SECTIONCODERF SED_SECTIONCODE" );		// 拠点コード
        //		SelectDm.Append( ", SED.SUPPLIERFORMALRF SED_SUPPLIERFORMAL" );		// 仕入形式
        //		SelectDm.Append( ", SED.SUPPLIERSLIPNORF SED_SUPPLIERSLIPNO" );		// 仕入伝票番号
        //		SelectDm.Append( ", SED.STOCKROWNORF SED_STOCKROWNO" );		// 仕入行番号
        //		SelectDm.Append( ", SED.STCKSLIPEXPNUMRF SED_STCKSLIPEXPNUM" );		// 仕入詳細番号
        //		SelectDm.Append( ", SED.PRODUCTNUMBER1RF SED_PRODUCTNUMBER1" );		// 製造番号1
        //		SelectDm.Append( ", SED.PRODUCTNUMBER2RF SED_PRODUCTNUMBER2" );		// 製造番号2
        //		SelectDm.Append( ", SED.STOCKTELNO1RF SED_STOCKTELNO1" );		// 商品電話番号1
        //		SelectDm.Append( ", SED.STOCKTELNO2RF SED_STOCKTELNO2" );		// 商品電話番号2
        //		SelectDm.Append( ", SED.STOCKEXPSLIPNOTERF SED_STOCKEXPSLIPNOTE" );		// 仕入伝票詳細備考
        //		SelectDm.Append( ", SED.PRODUCTSTOCKGUIDRF SED_PRODUCTSTOCKGUID" );		// 製番在庫マスタGUID
        //
        //        SelectDm.Append( ", SIS.SECTIONGUIDENMRF SIS_SECTIONGUIDENM" );
        //
        //		SelectDm.Append( " FROM STOCKEXPLADATARF SED" );
        //		SelectDm.Append( " LEFT JOIN SECINFOSETRF SIS ON SIS.ENTERPRISECODERF=SED.ENTERPRISECODERF AND SIS.SECTIONCODERF=SED.SECTIONCODERF" );
        //        #endregion
        //
        //        sqlCommand = new SqlCommand(SelectDm.ToString(), sqlConnection);
        //
        //        //WHERE文の作成
        //        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, "SED", enterpriseCode,  supplierFomal, supplierSlipNo, logicalMode );
        //		// Sort
        //		sqlCommand.CommandText +=" ORDER BY SED.SUPPLIERSLIPNORF, SED.STOCKROWNORF, SED.STCKSLIPEXPNUMRF";
        //
        //        myReader = sqlCommand.ExecuteReader();
        //
        //        while (myReader.Read())
        //        {
        //            #region 抽出結果-値セット
        //            StcExDataRefWork wkStcExDataRefResultWork = new StcExDataRefWork();
        //
        //            // 仕入詳細データ結果取得内容格納
        //			wkStcExDataRefResultWork.SectionCode        = SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SED_SECTIONCODE"));			// 拠点コード
        //			wkStcExDataRefResultWork.SectionGuideNm     = SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SIS_SECTIONGUIDENM"));		// 拠点ガイド名称
        //			wkStcExDataRefResultWork.SupplierFormal     = SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("SED_SUPPLIERFORMAL"));		// 仕入形式
        //			wkStcExDataRefResultWork.SupplierSlipNo     = SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("SED_SUPPLIERSLIPNO"));		// 仕入伝票番号
        //			wkStcExDataRefResultWork.StockRowNo         = SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("SED_STOCKROWNO"));			// 仕入行番号
        //			wkStcExDataRefResultWork.StckSlipExpNum     = SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("SED_STCKSLIPEXPNUM"));		// 仕入詳細番号
        //			wkStcExDataRefResultWork.ProductNumber1     = SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SED_PRODUCTNUMBER1"));		// 製造番号1
        //			wkStcExDataRefResultWork.ProductNumber2     = SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SED_PRODUCTNUMBER2"));		// 製造番号2
        //			wkStcExDataRefResultWork.StockTelNo1        = SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SED_STOCKTELNO1"));			// 商品電話番号1
        //			wkStcExDataRefResultWork.StockTelNo2        = SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SED_STOCKTELNO2"));			// 商品電話番号2
        //			wkStcExDataRefResultWork.StockExpSlipNote   = SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("SED_STOCKEXPSLIPNOTE"));	// 仕入伝票詳細備考
        //			wkStcExDataRefResultWork.ProductStockGuid	= SqlDataMediator.SqlGetGuid	(myReader, myReader.GetOrdinal("SED_PRODUCTSTOCKGUID"));		// 製番在庫マスタGUID
        //            #endregion
        //
        //            stcExDtList.Add(wkStcExDataRefResultWork);
        //
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
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
        // ↑ 2007.12.04 980081 d
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="tableNm">テーブル名称</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierFomal">仕入形式</param>
        /// <param name="supplierSlipNo">仕入伝票番号</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, string tableNm, string enterpriseCode, int supplierFomal, int supplierSlipNo, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            StringBuilder retstring = new StringBuilder();
            retstring.Append(" WHERE");

            // 企業コード
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

            //// 拠点コード
            //retstring.Append( string.Format( " AND {0}.{1}=@SECTIONCODE", tableNm, selectSecID ) );
            //SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            //paraSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);

            // 仕入形式
            retstring.Append(string.Format(" AND {0}.SUPPLIERFORMALRF=@SUPPLIERFORMAL", tableNm));
            SqlParameter paraSupplierFomal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
            paraSupplierFomal.Value = SqlDataMediator.SqlSetInt32(supplierFomal);

            // 仕入伝票番号
            retstring.Append(string.Format(" AND {0}.SUPPLIERSLIPNORF=@SUPPLIERSLIPNO", tableNm));
            SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
            paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(supplierSlipNo);

            #endregion
            return retstring.ToString();
        }
    }
}
