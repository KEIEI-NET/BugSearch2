//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE入庫更新DBリモートオブジェクト
//                  :   PMUOE01205R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112　久保田
// Date             :   2008.10.17
//----------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内
// 作 成 日  2009/08/24  修正内容 : E-Parts対応に伴う抽出メソッド追加
//----------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/11/15  修正内容 : 1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応
//                                : 在庫入庫更新の原単価は、回答データの原単価とPMの原単価と異なる場合黄色に変わる機能があるが
//                                : 価格マスタの原価を変えても、色彩は変化しない。
//----------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2013/01/18  修正内容 : 1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応
//----------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 譚洪
// 修 正 日  2020/06/17  修正内容 : PMKOBETSU-4005 ＥＢＥ対策
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common; // ADD 2020/06/18 譚洪 PMKOBETSU-4005

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// UOE入庫更新DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE入庫更新の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21112　久保田</br>
    /// <br>Date       : 2008.10.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Update Note: 2012/11/15 wangf </br>
    /// <br>           : 10801804-00、1月16日配信分、10801804-00、Redmine#31980 PM.NS障害一覧No.829の対応</br>
    /// <br>           : 在庫入庫更新の原単価は、回答データの原単価とPMの原単価と異なる場合黄色に変わる機能があるが</br>
    /// <br>           : 価格マスタの原価を変えても、色彩は変化しない。</br>
	/// <br>Update Note: 2013/01/18 wangf </br>
	/// <br>           : 10801804-00、1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応</br>
    /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2020/06/18</br>
    /// </remarks>
    [Serializable]
    public class UOEStockUpdateDB : RemoteWithAppLockDB, IUOEStockUpdateDB
    {
        # region [使用するリモート]

        # region [売上・仕入制御リモート]
        private IOWriteControlDB _ioWriteCtrDb = null;

        private IOWriteControlDB ioWriteCtrDb
        {
            get
            {
                if (this._ioWriteCtrDb == null)
                {
                    this._ioWriteCtrDb = new IOWriteControlDB();
                }

                return this._ioWriteCtrDb;
            }
        }
        # endregion

        # region [在庫調整データリモート]
        private StockAdjustDB _stcAdjustDb = null;

        private StockAdjustDB stcAdjustDb
        {
            get
            {
                if (this._stcAdjustDb == null)
                {
                    this._stcAdjustDb = new StockAdjustDB();
                }

                return this._stcAdjustDb;
            }
        }
        # endregion

        # endregion

        /// <summary>
        /// UOE入庫更新DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        public UOEStockUpdateDB() : base("PMUOE01207D", "Broadleaf.Application.Remoting.ParamData.UOEStockUpdateWork", "UOESTOCKUPDATERF")
        {

        }

        # region [Search]

        /// <summary>
        /// 仕入伝票データ キー項目
        /// </summary>
        private struct StockSlipKey
        {
            public string EnterpriseCode;
            public int SupplierFormal;
            public int SupplierSlipNo;

            public StockSlipKey(string enterprisecode, int supplierformal, int supplierslipno)
            {
                EnterpriseCode = enterprisecode;
                SupplierFormal = supplierformal;
                SupplierSlipNo = supplierslipno;
            }
        }

        /// <summary>
        /// UOE入庫更新情報のリストを取得します。
        /// </summary>
        /// <param name="uoeStcUpdSearchObj">検索条件となる UOEStockUpdSearchWork を指定します。</param>
        /// <param name="uoeStcUpdDataList">検索結果を格納 CustomSerializeArrayList を指定します。</param>
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 検索条件に合致するUOE発注データ、仕入データ、仕入明細データを検索します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        public int Search(object uoeStcUpdSearchObj, ref object uoeStcUpdDataList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                # region [パラメータチェック]

                UOEStockUpdSearchWork uoeStcUpdSearch = uoeStcUpdSearchObj as UOEStockUpdSearchWork;

                if (uoeStcUpdSearch == null)
                {
                    errmsg += ": uoeStcUpdSearchObj が正しく設定されていません";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                ArrayList uoeStcUpdDataArray = uoeStcUpdDataList as ArrayList;

                if (uoeStcUpdDataArray == null)
                {
                    errmsg += ": uoeStcUpdDataList が正しく設定されていません";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # endregion

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(uoeStcUpdSearch, ref uoeStcUpdDataArray, readMode, logicalMode, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// UOE入庫更新情報のリストを取得します。
        /// </summary>
        /// <param name="uoeStcUpdSearch">検索条件となる UOEStockUpdSearchWork を指定します。</param>
        /// <param name="uoeStcUpdDataList">検索結果を格納 CustomSerializeArrayList を指定します。</param>
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 検索条件に合致するUOE発注データ、仕入データ、仕入明細データを検索します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        public int Search(UOEStockUpdSearchWork uoeStcUpdSearch, ref ArrayList uoeStcUpdDataList, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                # region [パラメータチェック]

                string orgErrmsg = errmsg;

                if (uoeStcUpdSearch == null)
                    errmsg += ": uoeStcUpdSearch が正しく設定されていません";

                if (uoeStcUpdDataList == null)
                    errmsg += ": uoeStcUpdDataList が正しく設定されていません";

                if (sqlConnection == null)
                    errmsg += ": sqlConnection が正しく設定されていません";

                if (orgErrmsg != errmsg)
                {
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # endregion

                status = this.SearchProc(uoeStcUpdSearch, ref uoeStcUpdDataList, readMode, logicalMode, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// UOE入庫更新情報のリストを取得します。
        /// </summary>
        /// <param name="uoeStcUpdSearch">UOE入庫更新情報を格納する ArrayList</param>
        /// <param name="uoeStcUpdDataList">検索条件</param>
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE入庫更新のキー値が一致する、全てのUOE入庫更新情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        /// <br>Update Note: 2012/11/15 wangf </br>
        /// <br>           : 10801804-00、1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応</br>
        /// <br>           : 在庫入庫更新の原単価は、回答データの原単価とPMの原単価と異なる場合黄色に変わる機能があるが</br>
        /// <br>           : 価格マスタの原価を変えても、色彩は変化しない。</br>
		/// <br>Update Note: 2013/01/18 wangf </br>
		/// <br>           : 10801804-00、1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/06/18</br>
        private int SearchProc(UOEStockUpdSearchWork uoeStcUpdSearch, ref ArrayList uoeStcUpdDataList, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList uoeOdrDtlList = new ArrayList();
            ArrayList stcSlpList = new ArrayList();
            ArrayList stcDtlList = new ArrayList();
            
            //List<StockSlipKey> stcSlpKeyList = new List<StockSlipKey>();
            Dictionary<string, StockSlipReadWork> slipReadDic = new Dictionary<string, StockSlipReadWork>(); //仕入データ抽出パラメータ
            Dictionary<string, Guid> dtlGuidDic = new Dictionary<string, Guid>();  //関連明細ファイルＧＵＩＤ格納

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [UOE発注データ]
                # region [SELECT文]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                # region [UOE発注データ]
                sqlText += "  UOEDTL.CREATEDATETIMERF AS UOE_CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UPDATEDATETIMERF AS UOE_UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ENTERPRISECODERF AS UOE_ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.FILEHEADERGUIDRF AS UOE_FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UPDEMPLOYEECODERF AS UOE_UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UPDASSEMBLYID1RF AS UOE_UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UPDASSEMBLYID2RF AS UOE_UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.LOGICALDELETECODERF AS UOE_LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SYSTEMDIVCDRF AS UOE_SYSTEMDIVCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESALESORDERNORF AS UOE_UOESALESORDERNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESALESORDERROWNORF AS UOE_UOESALESORDERROWNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SENDTERMINALNORF AS UOE_SENDTERMINALNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESUPPLIERCDRF AS UOE_UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESUPPLIERNAMERF AS UOE_UOESUPPLIERNAMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.COMMASSEMBLYIDRF AS UOE_COMMASSEMBLYIDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ONLINENORF AS UOE_ONLINENORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ONLINEROWNORF AS UOE_ONLINEROWNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SALESDATERF AS UOE_SALESDATERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.INPUTDAYRF AS UOE_INPUTDAYRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.DATAUPDATEDATETIMERF AS UOE_DATAUPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOEKINDRF AS UOE_UOEKINDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SALESSLIPNUMRF AS UOE_SALESSLIPNUMRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ACPTANODRSTATUSRF AS UOE_ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SALESSLIPDTLNUMRF AS UOE_SALESSLIPDTLNUMRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SECTIONCODERF AS UOE_SECTIONCODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SUBSECTIONCODERF AS UOE_SUBSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.CUSTOMERCODERF AS UOE_CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.CUSTOMERSNMRF AS UOE_CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.CASHREGISTERNORF AS UOE_CASHREGISTERNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.COMMONSEQNORF AS UOE_COMMONSEQNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SUPPLIERFORMALRF AS UOE_SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SUPPLIERSLIPNORF AS UOE_SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.STOCKSLIPDTLNUMRF AS UOE_STOCKSLIPDTLNUMRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOCODERF AS UOE_BOCODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOEDELIGOODSDIVRF AS UOE_UOEDELIGOODSDIVRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.DELIVEREDGOODSDIVNMRF AS UOE_DELIVEREDGOODSDIVNMRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.FOLLOWDELIGOODSDIVRF AS UOE_FOLLOWDELIGOODSDIVRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.FOLLOWDELIGOODSDIVNMRF AS UOE_FOLLOWDELIGOODSDIVNMRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOERESVDSECTIONRF AS UOE_UOERESVDSECTIONRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOERESVDSECTIONNMRF AS UOE_UOERESVDSECTIONNMRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.EMPLOYEECODERF AS UOE_EMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.EMPLOYEENAMERF AS UOE_EMPLOYEENAMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.GOODSMAKERCDRF AS UOE_GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAKERNAMERF AS UOE_MAKERNAMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.GOODSNORF AS UOE_GOODSNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.GOODSNONONEHYPHENRF AS UOE_GOODSNONONEHYPHENRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.GOODSNAMERF AS UOE_GOODSNAMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.WAREHOUSECODERF AS UOE_WAREHOUSECODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.WAREHOUSENAMERF AS UOE_WAREHOUSENAMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.WAREHOUSESHELFNORF AS UOE_WAREHOUSESHELFNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ACCEPTANORDERCNTRF AS UOE_ACCEPTANORDERCNTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.LISTPRICERF AS UOE_LISTPRICERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SALESUNITCOSTRF AS UOE_SALESUNITCOSTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SUPPLIERCDRF AS UOE_SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SUPPLIERSNMRF AS UOE_SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOEREMARK1RF AS UOE_UOEREMARK1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOEREMARK2RF AS UOE_UOEREMARK2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.RECEIVEDATERF AS UOE_RECEIVEDATERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.RECEIVETIMERF AS UOE_RECEIVETIMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ANSWERMAKERCDRF AS UOE_ANSWERMAKERCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ANSWERPARTSNORF AS UOE_ANSWERPARTSNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ANSWERPARTSNAMERF AS UOE_ANSWERPARTSNAMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SUBSTPARTSNORF AS UOE_SUBSTPARTSNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESECTOUTGOODSCNTRF AS UOE_UOESECTOUTGOODSCNTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSHIPMENTCNT1RF AS UOE_BOSHIPMENTCNT1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSHIPMENTCNT2RF AS UOE_BOSHIPMENTCNT2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSHIPMENTCNT3RF AS UOE_BOSHIPMENTCNT3RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAKERFOLLOWCNTRF AS UOE_MAKERFOLLOWCNTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.NONSHIPMENTCNTRF AS UOE_NONSHIPMENTCNTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESECTSTOCKCNTRF AS UOE_UOESECTSTOCKCNTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSTOCKCOUNT1RF AS UOE_BOSTOCKCOUNT1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSTOCKCOUNT2RF AS UOE_BOSTOCKCOUNT2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSTOCKCOUNT3RF AS UOE_BOSTOCKCOUNT3RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESECTIONSLIPNORF AS UOE_UOESECTIONSLIPNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSLIPNO1RF AS UOE_BOSLIPNO1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSLIPNO2RF AS UOE_BOSLIPNO2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSLIPNO3RF AS UOE_BOSLIPNO3RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.EOALWCCOUNTRF AS UOE_EOALWCCOUNTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOMANAGEMENTNORF AS UOE_BOMANAGEMENTNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ANSWERLISTPRICERF AS UOE_ANSWERLISTPRICERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ANSWERSALESUNITCOSTRF AS UOE_ANSWERSALESUNITCOSTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESUBSTMARKRF AS UOE_UOESUBSTMARKRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESTOCKMARKRF AS UOE_UOESTOCKMARKRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.PARTSLAYERCDRF AS UOE_PARTSLAYERCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESHIPSECTCD1RF AS UOE_MAZDAUOESHIPSECTCD1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESHIPSECTCD2RF AS UOE_MAZDAUOESHIPSECTCD2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESHIPSECTCD3RF AS UOE_MAZDAUOESHIPSECTCD3RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESECTCD1RF AS UOE_MAZDAUOESECTCD1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESECTCD2RF AS UOE_MAZDAUOESECTCD2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESECTCD3RF AS UOE_MAZDAUOESECTCD3RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESECTCD4RF AS UOE_MAZDAUOESECTCD4RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESECTCD5RF AS UOE_MAZDAUOESECTCD5RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESECTCD6RF AS UOE_MAZDAUOESECTCD6RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESECTCD7RF AS UOE_MAZDAUOESECTCD7RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT1RF AS UOE_MAZDAUOESTOCKCNT1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT2RF AS UOE_MAZDAUOESTOCKCNT2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT3RF AS UOE_MAZDAUOESTOCKCNT3RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT4RF AS UOE_MAZDAUOESTOCKCNT4RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT5RF AS UOE_MAZDAUOESTOCKCNT5RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT6RF AS UOE_MAZDAUOESTOCKCNT6RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT7RF AS UOE_MAZDAUOESTOCKCNT7RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOEDISTRIBUTIONCDRF AS UOE_UOEDISTRIBUTIONCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOEOTHERCDRF AS UOE_UOEOTHERCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOEHMCDRF AS UOE_UOEHMCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOCOUNTRF AS UOE_BOCOUNTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOEMARKCODERF AS UOE_UOEMARKCODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SOURCESHIPMENTRF AS UOE_SOURCESHIPMENTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ITEMCODERF AS UOE_ITEMCODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOECHECKCODERF AS UOE_UOECHECKCODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.HEADERRORMASSAGERF AS UOE_HEADERRORMASSAGERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.LINEERRORMASSAGERF AS UOE_LINEERRORMASSAGERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.DATASENDCODERF AS UOE_DATASENDCODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.DATARECOVERDIVRF AS UOE_DATARECOVERDIVRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ENTERUPDDIVSECRF AS UOE_ENTERUPDDIVSECRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ENTERUPDDIVBO1RF AS UOE_ENTERUPDDIVBO1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ENTERUPDDIVBO2RF AS UOE_ENTERUPDDIVBO2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ENTERUPDDIVBO3RF AS UOE_ENTERUPDDIVBO3RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ENTERUPDDIVMAKERRF AS UOE_ENTERUPDDIVMAKERRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ENTERUPDDIVEORF AS UOE_ENTERUPDDIVEORF" + Environment.NewLine;
                // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
                sqlText += " ,UNION_GOODSPRICEURF.GOODSPRICEU_SALESUNITCOSTRF AS UOE_GOODSPRICEU_SALESUNITCOSTRF" + Environment.NewLine;
                sqlText += " ,UNION_GOODSPRICEURF.GOODSPRICEU_PRICESTARTDATERF AS UOE_GOODSPRICEU_PRICESTARTDATERF" + Environment.NewLine;
                sqlText += " ,UNION_GOODSPRICEURF.GOODSPRICEU_STOCKRATERF AS UOE_GOODSPRICEU_STOCKRATERF" + Environment.NewLine;
                sqlText += " ,UNION_GOODSPRICEURF.GOODSPRICEU_LISTPRICERF AS UOE_GOODSPRICEU_LISTPRICERF" + Environment.NewLine;

                sqlText += "  ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                sqlText += "  ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                sqlText += "  ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<
                # endregion
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  UOEORDERDTLRF AS UOEDTL" + Environment.NewLine;
                // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
                #region 価格マスタ関連
                sqlText += "LEFT JOIN (" + Environment.NewLine;
                sqlText += "  SELECT" + Environment.NewLine;
                sqlText += "      MAX_GOODSPRICEURF.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "      ,MAX_GOODSPRICEURF.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "      ,MAX_GOODSPRICEURF.GOODSNORF" + Environment.NewLine;
                sqlText += "      ,MAX_GOODSPRICEURF.SALESUNITCOSTRF  AS GOODSPRICEU_SALESUNITCOSTRF" + Environment.NewLine;
                sqlText += "      ,MAX_GOODSPRICEURF.PRICESTARTDATERF AS GOODSPRICEU_PRICESTARTDATERF" + Environment.NewLine;
                sqlText += "      ,MAX_GOODSPRICEURF.STOCKRATERF AS GOODSPRICEU_STOCKRATERF" + Environment.NewLine;
                sqlText += "      ,MAX_GOODSPRICEURF.LISTPRICERF AS GOODSPRICEU_LISTPRICERF" + Environment.NewLine;
                sqlText += "  FROM GOODSPRICEURF AS MAX_GOODSPRICEURF" + Environment.NewLine;
                sqlText += "  WHERE MAX_GOODSPRICEURF.PRICESTARTDATERF IN (" + Environment.NewLine;
                sqlText += "      SELECT TOP 1 PRICESTARTDATERF AS MAX_PRICESTARTDATERF " + Environment.NewLine;
                sqlText += "      FROM GOODSPRICEURF" + Environment.NewLine;
                sqlText += "      WHERE PRICESTARTDATERF <= @PRICESTARTDATERF" + Environment.NewLine;
                sqlText += "      AND LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "      AND MAX_GOODSPRICEURF.GOODSMAKERCDRF = GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "      AND MAX_GOODSPRICEURF.GOODSNORF = GOODSNORF" + Environment.NewLine;
                sqlText += "      ORDER BY PRICESTARTDATERF DESC)" + Environment.NewLine;
                sqlText += "      AND MAX_GOODSPRICEURF.ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                sqlText += "      AND MAX_GOODSPRICEURF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "  ) AS UNION_GOODSPRICEURF" + Environment.NewLine;
                sqlText += "ON UOEDTL.ENTERPRISECODERF = UNION_GOODSPRICEURF.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "AND UOEDTL.GOODSMAKERCDRF = UNION_GOODSPRICEURF.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "AND UOEDTL.GOODSNORF = UNION_GOODSPRICEURF.GOODSNORF" + Environment.NewLine;

                SqlParameter findPriceStartDate = sqlCommand.Parameters.Add("@PRICESTARTDATERF", SqlDbType.Int);
                findPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);
                #endregion

                #region 商品マスタ関連
                sqlText += " LEFT JOIN GOODSURF AS GOODS" + Environment.NewLine;
                sqlText += " ON UOEDTL.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND UOEDTL.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND UOEDTL.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND UOEDTL.LOGICALDELETECODERF=GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                #endregion

                // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<
                # region [WHERE句]
                sqlText += "WHERE" + Environment.NewLine;

                // 企業コード
                sqlText += "  UOEDTL.ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeStcUpdSearch.EnterpriseCode);

                // 処理区分
                if (uoeStcUpdSearch.ProcDiv == 0)
                {
                    // 在庫一括
                    sqlText += "  AND UOEDTL.SYSTEMDIVCDRF = 3" + Environment.NewLine;
                }
                else
                {
                    // 在庫一括以外(手入力・検索)
                    // 2009/02/20 MANTIS 11720>>>>>>>>>>>>>>>>>>>>>>>>
                    // 明治は伝発のデータも受信するので、1:伝発も抽出対象とする。
                    //sqlText += "  AND UOEDTL.SYSTEMDIVCDRF IN (0, 2)" + Environment.NewLine;
                    sqlText += "  AND UOEDTL.SYSTEMDIVCDRF IN (0, 1, 2)" + Environment.NewLine;
                    // 2009/02/20 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }

                // 拠点コード
                sqlText += "  AND UOEDTL.SECTIONCODERF = @SECTIONCODE" + Environment.NewLine;
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString(uoeStcUpdSearch.SectionCode);

                if (string.IsNullOrEmpty(uoeStcUpdSearch.SlipNo))
                {
                    // UOE発注先コードで絞り込み
                    sqlText += "  AND UOEDTL.UOESUPPLIERCDRF = @UOESUPPLIERCD" + Environment.NewLine;

                    SqlParameter findUOESupplierCd = sqlCommand.Parameters.Add("@UOESUPPLIERCD", SqlDbType.Int);
                    findUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeStcUpdSearch.UOESupplierCd);
                }
                else
                {
                    // 納品書番号で絞り込み
                    sqlText += "  AND (UOEDTL.UOESECTIONSLIPNORF = @SLIPNO OR" + Environment.NewLine;
                    sqlText += "       UOEDTL.BOSLIPNO1RF = @SLIPNO OR" + Environment.NewLine;
                    sqlText += "       UOEDTL.BOSLIPNO2RF = @SLIPNO OR" + Environment.NewLine;
                    sqlText += "       UOEDTL.BOSLIPNO3RF = @SLIPNO)" + Environment.NewLine;

                    SqlParameter findSlipNo = sqlCommand.Parameters.Add("@SLIPNO", SqlDbType.NChar);
                    findSlipNo.Value = SqlDataMediator.SqlSetString(uoeStcUpdSearch.SlipNo);
                }
                sqlText += "  AND UOEDTL.DATASENDCODERF = 9" + Environment.NewLine;
                sqlText += "  AND UOEDTL.DATARECOVERDIVRF = 9" + Environment.NewLine;
                sqlText += "  AND (UOEDTL.ENTERUPDDIVSECRF = 0 OR" + Environment.NewLine;
                sqlText += "       UOEDTL.ENTERUPDDIVBO1RF = 0 OR" + Environment.NewLine;
                sqlText += "       UOEDTL.ENTERUPDDIVBO2RF = 0 OR" + Environment.NewLine;
                sqlText += "       UOEDTL.ENTERUPDDIVBO3RF = 0 OR" + Environment.NewLine;
                sqlText += "       UOEDTL.ENTERUPDDIVMAKERRF = 0 OR" + Environment.NewLine;
                sqlText += "       UOEDTL.ENTERUPDDIVEORF = 0)" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;

                // 論理削除区分
                string wkstring = "";
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
                }

                if (wkstring != "")
                {
                    sqlText += wkstring;
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                # endregion
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                // 変換情報呼び出し
                ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

                // 変換情報初期化
                convertDoubleRelease.ReleaseInitLib();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                try
                {
                    myReader = sqlCommand.ExecuteReader();



                    while (myReader.Read())
                    {
                        // 明細関連付けGUIDを作成
                        Guid newDtlRelationGuid = Guid.NewGuid();

                        // UOE発注データの取得
                        UOEOrderDtlWork uoeOdrDtlWrk = new UOEOrderDtlWork();
                        this.CopyToUOEOrderDtlWorkFromReader(ref myReader, ref uoeOdrDtlWrk);
                        // ------------ADD wangf 2013/01/18 FOR Redmine#31980--------->>>>
                        // 原価単価（価格マスタより）
                        uoeOdrDtlWrk.GoodspriceuSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_SALESUNITCOSTRF"));
                        uoeOdrDtlWrk.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_PRICESTARTDATERF"));
                        uoeOdrDtlWrk.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_STOCKRATERF"));
                        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                        //uoeOdrDtlWrk.PriceListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_LISTPRICERF"));
                        convertDoubleRelease.EnterpriseCode = uoeOdrDtlWrk.EnterpriseCode;
                        convertDoubleRelease.GoodsMakerCd = uoeOdrDtlWrk.GoodsMakerCd;
                        convertDoubleRelease.GoodsNo = uoeOdrDtlWrk.GoodsNo;
                        convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_LISTPRICERF"));

                        // 変換処理実行
                        convertDoubleRelease.ReleaseProc();

                        uoeOdrDtlWrk.PriceListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                        uoeOdrDtlWrk.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));            // 商品掛率ランク
                        uoeOdrDtlWrk.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));         // BL商品コード
                        uoeOdrDtlWrk.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));         // 課税区分
                        // ------------ADD wangf 2013/01/18 FOR Redmine#31980---------<<<<
                        uoeOdrDtlWrk.DtlRelationGuid = newDtlRelationGuid;
                        uoeOdrDtlList.Add(uoeOdrDtlWrk);

                        // 仕入データ抽出リスト作成
                        if (!slipReadDic.ContainsKey(CreateKeySlipDic(uoeOdrDtlWrk)))
                        {
                            slipReadDic.Add(CreateKeySlipDic(uoeOdrDtlWrk),CopyToStockSlipReadFromUoeOrderDtl(uoeOdrDtlWrk));
                        }

                        //明細関連ＧＵＩＤ格納リスト
                        if (!dtlGuidDic.ContainsKey(CreateKeyGuidDic(uoeOdrDtlWrk.EnterpriseCode,uoeOdrDtlWrk.SupplierFormal,uoeOdrDtlWrk.StockSlipDtlNum)))
                        {
                            dtlGuidDic.Add(CreateKeyGuidDic(uoeOdrDtlWrk.EnterpriseCode, uoeOdrDtlWrk.SupplierFormal, uoeOdrDtlWrk.StockSlipDtlNum), uoeOdrDtlWrk.DtlRelationGuid);
                        }

                    }
                }
                finally
                {
                    if (myReader != null && !myReader.IsClosed)
                    {
                        myReader.Close();
                        myReader.Dispose();
                    }
                    //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                    // 解放
                    convertDoubleRelease.Dispose();
                    //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                }

                // 仕入データの読込み

                if (slipReadDic.Count > 0)
                {
                    StockSlipDB stockSlipDB = new StockSlipDB();

                    foreach (StockSlipReadWork StcSlipKey in slipReadDic.Values)
                    {
                        // 仕入データのキー項目に未設定の項目が１つでも有れば、無意味な検索を行わない
                        if (string.IsNullOrEmpty(StcSlipKey.EnterpriseCode) ||
                            StcSlipKey.SupplierFormal == 0 ||
                            StcSlipKey.SupplierSlipNo == 0)
                            continue;

                        CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                        CustomSerializeArrayList retList = new CustomSerializeArrayList();
                        
                        paraList.Add(StcSlipKey);

                        stockSlipDB.Read(ref paraList, ref retList, 0 ,ref sqlConnection, ref sqlTransaction);

                        //仕入データセット
                        StockSlipWork stockSlipWork = ListUtils.Find(retList,typeof(StockSlipWork),ListUtils.FindType.Class) as StockSlipWork;
                        stcSlpList.Add(stockSlipWork);

                        //仕入明細データセット
                        ArrayList stockDetailList = ListUtils.Find(retList, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                        foreach (StockDetailWork stockDetailWork in stockDetailList)
                        {
                            if (dtlGuidDic.ContainsKey(CreateKeyGuidDic(stockDetailWork.EnterpriseCode, stockDetailWork.SupplierFormal, stockDetailWork.StockSlipDtlNum)))
                            {
                                //ＵＯＥ発注データの明細関連ＧＵＩＤを仕入明細データにセット
                                stockDetailWork.DtlRelationGuid = (Guid)(dtlGuidDic[CreateKeyGuidDic(stockDetailWork.EnterpriseCode, stockDetailWork.SupplierFormal, stockDetailWork.StockSlipDtlNum)]);
                            }
                        }

                        stcDtlList.AddRange(stockDetailList);

                    }
                }
                # endregion


                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                if (ListUtils.IsEmpty(uoeOdrDtlList))
                {
# if DEBUG
                    errmsg += ": 該当するUOE発注データが有りません.";
                    this.WriteErrorLog(errmsg, status);
# endif
                }
                else if (ListUtils.IsEmpty(stcSlpList))
                {
# if DEBUG
                    errmsg += ": 該当する仕入データが有りません.";
                    this.WriteErrorLog(errmsg, status);
# endif
                }
                else if (ListUtils.IsEmpty(stcDtlList))
                {
# if DEBUG
                    errmsg += ": 該当する仕入明細データが有りません.";
                    this.WriteErrorLog(errmsg, status);
# endif
                }
                else
                {
                    uoeStcUpdDataList.Add(uoeOdrDtlList);
                    uoeStcUpdDataList.Add(stcSlpList);
                    uoeStcUpdDataList.Add(stcDtlList);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = this.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                this.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        private string CreateKeySlipDic(UOEOrderDtlWork work)
        {
            return work.EnterpriseCode + "-" + work.SupplierFormal.ToString() + "-" + work.SupplierSlipNo.ToString();
        }

        private string CreateKeyGuidDic(string enterpriseCode, Int32 supplierFormal, Int64 stockSlipDtlNum)
        {
            return enterpriseCode + "-" + supplierFormal.ToString() + "-" + stockSlipDtlNum.ToString();
        }

        private StockSlipReadWork CopyToStockSlipReadFromUoeOrderDtl(UOEOrderDtlWork uoeOrderDtlWork)
        {
            StockSlipReadWork work = new StockSlipReadWork();
            work.EnterpriseCode = uoeOrderDtlWork.EnterpriseCode;
            work.SupplierFormal = uoeOrderDtlWork.SupplierFormal;
            work.SupplierSlipNo = uoeOrderDtlWork.SupplierSlipNo;

            return work;
        }

        # endregion

        #region[SearchAllPartySlip]
        // -- ADD 2009/08/24 --------------------------------------------------------->>>>>

        /// <summary>
        /// UOE入庫更新情報のリストを取得します。
        /// </summary>
        /// <param name="uoeStcUpdSearchObj">検索条件となる UOEStockUpdSearchWork を指定します。</param>
        /// <param name="uoeStcUpdDataList">検索結果を格納 CustomSerializeArrayList を指定します。</param>
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 検索条件に合致するUOE発注データ、仕入データ、仕入明細データを検索します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        public int SearchAllPartySlip(object uoeStcUpdSearchObj, ref object uoeStcUpdDataList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                # region [パラメータチェック]

                ArrayList uoeStcUpdSearchList = uoeStcUpdSearchObj as ArrayList;
                
                if (uoeStcUpdSearchList == null)
                {
                    errmsg += ": uoeStcUpdSearchObj が正しく設定されていません";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                ArrayList uoeStcUpdDataArray = uoeStcUpdDataList as ArrayList;

                if (uoeStcUpdDataArray == null)
                {
                    errmsg += ": uoeStcUpdDataList が正しく設定されていません";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # endregion

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.SearchAllPartySlip(uoeStcUpdSearchList, ref uoeStcUpdDataArray, readMode, logicalMode, sqlConnection, sqlTransaction);

                uoeStcUpdDataList  = uoeStcUpdDataArray;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// UOE入庫更新情報のリストを取得します。
        /// </summary>
        /// <param name="uoeStcUpdSearchList">検索条件となる UOEStockUpdSearchWorkのArrayList を指定します。</param>
        /// <param name="uoeStcUpdDataList">検索結果を格納 CustomSerializeArrayList を指定します。</param>
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 検索条件に合致するUOE発注データ、仕入データ、仕入明細データを検索します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        public int SearchAllPartySlip(ArrayList uoeStcUpdSearchList, ref ArrayList uoeStcUpdDataList, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                # region [パラメータチェック]

                string orgErrmsg = errmsg;

                if (uoeStcUpdSearchList == null)
                    errmsg += ": uoeStcUpdSearch が正しく設定されていません";

                if (uoeStcUpdDataList == null)
                    errmsg += ": uoeStcUpdDataList が正しく設定されていません";

                if (sqlConnection == null)
                    errmsg += ": sqlConnection が正しく設定されていません";

                if (orgErrmsg != errmsg)
                {
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # endregion

                status = this.SearchAllPartySlipProc(uoeStcUpdSearchList, ref uoeStcUpdDataList, readMode, logicalMode, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// UOE入庫更新情報のリストを取得します。
        /// </summary>
        /// <param name="uoeStcUpdSearchList">検索条件 ArrayList</param>
        /// <param name="uoeStcUpdDataList">抽出結果 ArrayList</param>
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE入庫更新のキー値が一致する、全てのUOE入庫更新情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        private int SearchAllPartySlipProc(ArrayList uoeStcUpdSearchList, ref ArrayList uoeStcUpdDataList, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList uoeOdrDtlList = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                foreach (UOEStockUpdSearchWork uoeStcUpdSearch in uoeStcUpdSearchList)
                {
                    sqlCommand.Parameters.Clear();

                    # region [UOE発注データ]
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UOEDTL.CREATEDATETIMERF AS UOE_CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UPDATEDATETIMERF AS UOE_UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ENTERPRISECODERF AS UOE_ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.FILEHEADERGUIDRF AS UOE_FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UPDEMPLOYEECODERF AS UOE_UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UPDASSEMBLYID1RF AS UOE_UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UPDASSEMBLYID2RF AS UOE_UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.LOGICALDELETECODERF AS UOE_LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SYSTEMDIVCDRF AS UOE_SYSTEMDIVCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESALESORDERNORF AS UOE_UOESALESORDERNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESALESORDERROWNORF AS UOE_UOESALESORDERROWNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SENDTERMINALNORF AS UOE_SENDTERMINALNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESUPPLIERCDRF AS UOE_UOESUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESUPPLIERNAMERF AS UOE_UOESUPPLIERNAMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.COMMASSEMBLYIDRF AS UOE_COMMASSEMBLYIDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ONLINENORF AS UOE_ONLINENORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ONLINEROWNORF AS UOE_ONLINEROWNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SALESDATERF AS UOE_SALESDATERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.INPUTDAYRF AS UOE_INPUTDAYRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.DATAUPDATEDATETIMERF AS UOE_DATAUPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOEKINDRF AS UOE_UOEKINDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SALESSLIPNUMRF AS UOE_SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ACPTANODRSTATUSRF AS UOE_ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SALESSLIPDTLNUMRF AS UOE_SALESSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SECTIONCODERF AS UOE_SECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SUBSECTIONCODERF AS UOE_SUBSECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.CUSTOMERCODERF AS UOE_CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.CUSTOMERSNMRF AS UOE_CUSTOMERSNMRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.CASHREGISTERNORF AS UOE_CASHREGISTERNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.COMMONSEQNORF AS UOE_COMMONSEQNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SUPPLIERFORMALRF AS UOE_SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SUPPLIERSLIPNORF AS UOE_SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.STOCKSLIPDTLNUMRF AS UOE_STOCKSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOCODERF AS UOE_BOCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOEDELIGOODSDIVRF AS UOE_UOEDELIGOODSDIVRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.DELIVEREDGOODSDIVNMRF AS UOE_DELIVEREDGOODSDIVNMRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.FOLLOWDELIGOODSDIVRF AS UOE_FOLLOWDELIGOODSDIVRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.FOLLOWDELIGOODSDIVNMRF AS UOE_FOLLOWDELIGOODSDIVNMRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOERESVDSECTIONRF AS UOE_UOERESVDSECTIONRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOERESVDSECTIONNMRF AS UOE_UOERESVDSECTIONNMRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.EMPLOYEECODERF AS UOE_EMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.EMPLOYEENAMERF AS UOE_EMPLOYEENAMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.GOODSMAKERCDRF AS UOE_GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAKERNAMERF AS UOE_MAKERNAMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.GOODSNORF AS UOE_GOODSNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.GOODSNONONEHYPHENRF AS UOE_GOODSNONONEHYPHENRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.GOODSNAMERF AS UOE_GOODSNAMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.WAREHOUSECODERF AS UOE_WAREHOUSECODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.WAREHOUSENAMERF AS UOE_WAREHOUSENAMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.WAREHOUSESHELFNORF AS UOE_WAREHOUSESHELFNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ACCEPTANORDERCNTRF AS UOE_ACCEPTANORDERCNTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.LISTPRICERF AS UOE_LISTPRICERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SALESUNITCOSTRF AS UOE_SALESUNITCOSTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SUPPLIERCDRF AS UOE_SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SUPPLIERSNMRF AS UOE_SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOEREMARK1RF AS UOE_UOEREMARK1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOEREMARK2RF AS UOE_UOEREMARK2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.RECEIVEDATERF AS UOE_RECEIVEDATERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.RECEIVETIMERF AS UOE_RECEIVETIMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ANSWERMAKERCDRF AS UOE_ANSWERMAKERCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ANSWERPARTSNORF AS UOE_ANSWERPARTSNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ANSWERPARTSNAMERF AS UOE_ANSWERPARTSNAMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SUBSTPARTSNORF AS UOE_SUBSTPARTSNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESECTOUTGOODSCNTRF AS UOE_UOESECTOUTGOODSCNTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSHIPMENTCNT1RF AS UOE_BOSHIPMENTCNT1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSHIPMENTCNT2RF AS UOE_BOSHIPMENTCNT2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSHIPMENTCNT3RF AS UOE_BOSHIPMENTCNT3RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAKERFOLLOWCNTRF AS UOE_MAKERFOLLOWCNTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.NONSHIPMENTCNTRF AS UOE_NONSHIPMENTCNTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESECTSTOCKCNTRF AS UOE_UOESECTSTOCKCNTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSTOCKCOUNT1RF AS UOE_BOSTOCKCOUNT1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSTOCKCOUNT2RF AS UOE_BOSTOCKCOUNT2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSTOCKCOUNT3RF AS UOE_BOSTOCKCOUNT3RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESECTIONSLIPNORF AS UOE_UOESECTIONSLIPNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSLIPNO1RF AS UOE_BOSLIPNO1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSLIPNO2RF AS UOE_BOSLIPNO2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSLIPNO3RF AS UOE_BOSLIPNO3RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.EOALWCCOUNTRF AS UOE_EOALWCCOUNTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOMANAGEMENTNORF AS UOE_BOMANAGEMENTNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ANSWERLISTPRICERF AS UOE_ANSWERLISTPRICERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ANSWERSALESUNITCOSTRF AS UOE_ANSWERSALESUNITCOSTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESUBSTMARKRF AS UOE_UOESUBSTMARKRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESTOCKMARKRF AS UOE_UOESTOCKMARKRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.PARTSLAYERCDRF AS UOE_PARTSLAYERCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESHIPSECTCD1RF AS UOE_MAZDAUOESHIPSECTCD1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESHIPSECTCD2RF AS UOE_MAZDAUOESHIPSECTCD2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESHIPSECTCD3RF AS UOE_MAZDAUOESHIPSECTCD3RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESECTCD1RF AS UOE_MAZDAUOESECTCD1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESECTCD2RF AS UOE_MAZDAUOESECTCD2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESECTCD3RF AS UOE_MAZDAUOESECTCD3RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESECTCD4RF AS UOE_MAZDAUOESECTCD4RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESECTCD5RF AS UOE_MAZDAUOESECTCD5RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESECTCD6RF AS UOE_MAZDAUOESECTCD6RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESECTCD7RF AS UOE_MAZDAUOESECTCD7RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT1RF AS UOE_MAZDAUOESTOCKCNT1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT2RF AS UOE_MAZDAUOESTOCKCNT2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT3RF AS UOE_MAZDAUOESTOCKCNT3RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT4RF AS UOE_MAZDAUOESTOCKCNT4RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT5RF AS UOE_MAZDAUOESTOCKCNT5RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT6RF AS UOE_MAZDAUOESTOCKCNT6RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT7RF AS UOE_MAZDAUOESTOCKCNT7RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOEDISTRIBUTIONCDRF AS UOE_UOEDISTRIBUTIONCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOEOTHERCDRF AS UOE_UOEOTHERCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOEHMCDRF AS UOE_UOEHMCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOCOUNTRF AS UOE_BOCOUNTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOEMARKCODERF AS UOE_UOEMARKCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SOURCESHIPMENTRF AS UOE_SOURCESHIPMENTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ITEMCODERF AS UOE_ITEMCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOECHECKCODERF AS UOE_UOECHECKCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.HEADERRORMASSAGERF AS UOE_HEADERRORMASSAGERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.LINEERRORMASSAGERF AS UOE_LINEERRORMASSAGERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.DATASENDCODERF AS UOE_DATASENDCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.DATARECOVERDIVRF AS UOE_DATARECOVERDIVRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ENTERUPDDIVSECRF AS UOE_ENTERUPDDIVSECRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ENTERUPDDIVBO1RF AS UOE_ENTERUPDDIVBO1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ENTERUPDDIVBO2RF AS UOE_ENTERUPDDIVBO2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ENTERUPDDIVBO3RF AS UOE_ENTERUPDDIVBO3RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ENTERUPDDIVMAKERRF AS UOE_ENTERUPDDIVMAKERRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ENTERUPDDIVEORF AS UOE_ENTERUPDDIVEORF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  UOEORDERDTLRF AS UOEDTL" + Environment.NewLine;
                    # region [WHERE句]
                    sqlText += "WHERE" + Environment.NewLine;

                    // 企業コード
                    sqlText += "  UOEDTL.ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeStcUpdSearch.EnterpriseCode);

                    // 拠点コード
                    sqlText += "  AND UOEDTL.SECTIONCODERF = @SECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = SqlDataMediator.SqlSetString(uoeStcUpdSearch.SectionCode);

                    if (uoeStcUpdSearch.UOESupplierCd != 0)
                    {
                        // UOE発注先コードで絞り込み
                        sqlText += "  AND UOEDTL.UOESUPPLIERCDRF = @UOESUPPLIERCD" + Environment.NewLine;

                        SqlParameter findUOESupplierCd = sqlCommand.Parameters.Add("@UOESUPPLIERCD", SqlDbType.Int);
                        findUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeStcUpdSearch.UOESupplierCd);
                    }

                    // 納品書番号で絞り込み
                    sqlText += "  AND (UOEDTL.UOESECTIONSLIPNORF = @SLIPNO OR" + Environment.NewLine;
                    sqlText += "       UOEDTL.BOSLIPNO1RF = @SLIPNO OR" + Environment.NewLine;
                    sqlText += "       UOEDTL.BOSLIPNO2RF = @SLIPNO OR" + Environment.NewLine;
                    sqlText += "       UOEDTL.BOSLIPNO3RF = @SLIPNO)" + Environment.NewLine;

                    SqlParameter findSlipNo = sqlCommand.Parameters.Add("@SLIPNO", SqlDbType.NChar);
                    findSlipNo.Value = SqlDataMediator.SqlSetString(uoeStcUpdSearch.SlipNo);

                    sqlCommand.CommandText = sqlText;

                    // 論理削除区分
                    string wkstring = "";
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
                    }

                    if (wkstring != "")
                    {
                        sqlText += wkstring;
                        SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif
                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        // UOE発注データの取得
                        UOEOrderDtlWork uoeOdrDtlWrk = new UOEOrderDtlWork();
                        this.CopyToUOEOrderDtlWorkFromReader(ref myReader, ref uoeOdrDtlWrk);

                        uoeOdrDtlList.Add(uoeOdrDtlWrk);

                    }
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }
                # endregion


                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                if (ListUtils.IsEmpty(uoeOdrDtlList))
                {
# if DEBUG
                    errmsg += ": 該当するUOE発注データが有りません.";
                    this.WriteErrorLog(errmsg, status);
# endif
                }
                else
                {

                    uoeStcUpdDataList = uoeOdrDtlList;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = this.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                this.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        // -- ADD 2009/08/24 ---------------------------------------------------------<<<<<

        #endregion

        # region [Write]
        /// <summary>
        /// 仕入データ 又は 在庫調整データの登録を行います。
        /// </summary>
        /// <param name="uoeStockUpdateList">登録対象のデータが格納されている CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入データ 又は 在庫調整データの登録を行います。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        public int Write(ref object uoeStockUpdateList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = uoeStockUpdateList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                #region I/Owriter内部で欠けているので削除
                //// システムロック
                //Dictionary<string, string> dic = new Dictionary<string, string>();
                //string enterpriseCode = string.Empty;
                //ArrayList infoList = new ArrayList();

                //foreach (object item in paraList)
                //{
                //    if (item is ArrayList)
                //    {
                //        object obj = ListUtils.Find((item as ArrayList), typeof(StockDetailWork), ListUtils.FindType.Array);
                        
                //        ArrayList stockDtlList = obj as ArrayList;

                //        if (stockDtlList != null)
                //        {
                //            StockDetailWork stockDtlWork = stockDtlList[0] as StockDetailWork;

                //            foreach (StockDetailWork stDtlWork in stockDtlList)
                //            {
                //                if (dic.ContainsKey(stDtlWork.WarehouseCode) == false)
                //                {
                //                    dic.Add(stDtlWork.WarehouseCode, stDtlWork.WarehouseCode);
                //                }
                //                enterpriseCode = stDtlWork.EnterpriseCode;
                //            }
                //        }
                //    }
                //}

                //ShareCheckInfo info = new ShareCheckInfo();

                //if (dic != null && dic.Count != 0)
                //{
                //    foreach (string wareCd in dic.Keys)
                //    {
                //        info.Keys.Add(enterpriseCode, ShareCheckType.WareHouse, "", wareCd);
                //        infoList.Add(info);
                //    }
                //    int st = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                //    if (st != 0) return st;
                //}
                #endregion

                // write実行
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);

                #region I/Owriter内部で欠けているので削除
                //// システムロック解除
                //if (dic != null && dic.Count != 0)
                //{
                //    foreach (ShareCheckInfo Linfo in infoList)
                //    {
                //        int st = this.ShareCheck(Linfo, LockControl.Release, sqlConnection, sqlTransaction);
                //        if (st != 0) return st;
                //    }
                //}
                #endregion
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 仕入データ 又は 在庫調整データの登録を行います。
        /// </summary>
        /// <param name="uoeStockUpdateList">登録対象のデータが格納されている CustomSerializeArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入データ 又は 在庫調整データの登録を行います。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        public int Write(ref ArrayList uoeStockUpdateList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref uoeStockUpdateList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// UOE入庫更新情報を追加・更新します。
        /// </summary>
        /// <param name="uoeStockUpdateList">追加・更新するUOE入庫更新情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeStockUpdateList に格納されているUOE入庫更新情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        private int WriteProc(ref ArrayList uoeStockUpdateList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // CustomSerializeArrayList
            // │
            // ├IOWriteCtrlOptWork         [売上・仕入制御データ]
            // │
            // ├CustomSerializeArrayList   [代替元品番更新用発注データ群]
            // │├StockSlipWork            [仕入データ(仕入形式=2:発注)]
            // │└ArrayList
            // │  └StockDetailWork        [仕入明細データ(複数)]
            // │
            // ├CustomSerializeArrayList   [発注計上された仕入データ群]
            // │├StockSlipWork            [仕入データ(仕入形式=0:仕入)]
            // │├ArrayList
            // ││└StockDetailWork        [仕入明細データ(複数)]
            // │└ArrayList
            // │  └SlipDetailAddInfoWork  [伝票明細追加情報(複数)]
            // │
            // └CustomSerializeArrayList   [在庫調整データ(1伝票分)]
            //   ├ArrayList
            //   │└StockAdjustWork        [在庫調整データ(必ず1件分)]
            //   └ArrayList
            //     └StockAdjustDtlWork     [在庫調整明細データ(複数)]
            
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            # region [パラメーターチェック]

            if (ListUtils.IsEmpty(uoeStockUpdateList))
            {
                errmsg += "登録パラメーターが不正です.";
                this.WriteErrorLog(errmsg, status);
                return status;
            }

            if (sqlConnection == null)
            {
                errmsg += "データベース接続情報が未設定です.";
                this.WriteErrorLog(errmsg, status);
                return status;
            }

            if (sqlTransaction == null)
            {
                errmsg += "トランザクション情報が未設定です.";
                this.WriteErrorLog(errmsg, status);
                return status;
            }

            # endregion

            # region [発注・仕入・UOE発注データの書込み]

            // 発注・仕入・発注＋仕入とUOE発注の組み合わせを一回で登録する
            // ※UOE発注データを更新する関係上、必ず実行する
            string retMsg = string.Empty;
            string retItemInfo = string.Empty;
            SqlEncryptInfo sqlEncryptInfo = null;

            status = this.ioWriteCtrDb.WriteProc(ref uoeStockUpdateList, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

            # endregion

            # region [2009/02/13 DEL]
            //売仕入制御のリモート内で在庫調整データを作成しているので、下記処理は不要

            # region [在庫調整データの書込み]

            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    // 在庫調整データの書込み
            //    foreach (object item in uoeStockUpdateList)
            //    {
            //        if (item is ArrayList)
            //        {
            //            object obj = ListUtils.Find((item as ArrayList), typeof(StockAdjustWork), ListUtils.FindType.Array);

            //            if (obj != null)
            //            {
            //                // 在庫調整リモートは１伝票ずつしか処理できない為、ここで別のコレクションに分けておく。
            //                obj = item;
            //                status = this.stcAdjustDb.Write(ref obj, out retMsg, ref sqlConnection, ref sqlTransaction);

            //                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //                {
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion

            #endregion [2009/02/13 DEL]

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retMsg = (string.IsNullOrEmpty(retMsg)) ? "─" : retMsg;
                retItemInfo = (string.IsNullOrEmpty(retItemInfo)) ? "─" : retItemInfo;

                errmsg += string.Format(": {0} / {1}", retMsg, retItemInfo);
                this.WriteErrorLog(errmsg, status);
            }

            return status;
        }
        # endregion

        # region [クラス格納処理]

        /// <summary>
        /// クラス格納処理 Reader → UOEOrderDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>UOEOrderDtlWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        private UOEOrderDtlWork CopyToUOEOrderDtlWorkFromReader(ref SqlDataReader myReader)
        {
            UOEOrderDtlWork uoeOdrDtlWrk = new UOEOrderDtlWork();

            this.CopyToUOEOrderDtlWorkFromReader(ref myReader, ref uoeOdrDtlWrk);

            return uoeOdrDtlWrk;
        }

        /// <summary>
        /// クラス格納処理 Reader → UOEOrderDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="uoeOdrDtlWrk">UOEOrderDtlWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        /// <br>Update Note: 2012/11/15 wangf </br>
        /// <br>           : 10801804-00、1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応</br>
        /// <br>           : 在庫入庫更新の原単価は、回答データの原単価とPMの原単価と異なる場合黄色に変わる機能があるが</br>
        /// <br>           : 価格マスタの原価を変えても、色彩は変化しない。</br>
		/// <br>Update Note: 2013/01/18 wangf </br>
		/// <br>           : 10801804-00、1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応</br>
        /// </remarks>
        private void CopyToUOEOrderDtlWorkFromReader(ref SqlDataReader myReader, ref UOEOrderDtlWork uoeOdrDtlWrk)
        {
            if (myReader != null && uoeOdrDtlWrk != null)
            {
                # region クラスへ格納
                uoeOdrDtlWrk.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UOE_CREATEDATETIMERF"));   // 作成日時
                uoeOdrDtlWrk.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UOE_UPDATEDATETIMERF"));   // 更新日時
                uoeOdrDtlWrk.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_ENTERPRISECODERF"));              // 企業コード
                uoeOdrDtlWrk.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("UOE_FILEHEADERGUIDRF"));                // GUID
                uoeOdrDtlWrk.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UPDEMPLOYEECODERF"));            // 更新従業員コード
                uoeOdrDtlWrk.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UPDASSEMBLYID1RF"));              // 更新アセンブリID1
                uoeOdrDtlWrk.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UPDASSEMBLYID2RF"));              // 更新アセンブリID2
                uoeOdrDtlWrk.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_LOGICALDELETECODERF"));         // 論理削除区分
                uoeOdrDtlWrk.SystemDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_SYSTEMDIVCDRF"));                     // システム区分
                uoeOdrDtlWrk.UOESalesOrderNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_UOESALESORDERNORF"));             // UOE発注番号
                uoeOdrDtlWrk.UOESalesOrderRowNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_UOESALESORDERROWNORF"));       // UOE発注行番号
                uoeOdrDtlWrk.SendTerminalNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_SENDTERMINALNORF"));               // 送信端末番号
                uoeOdrDtlWrk.UOESupplierCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_UOESUPPLIERCDRF"));                 // UOE発注先コード
                uoeOdrDtlWrk.UOESupplierName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOESUPPLIERNAMERF"));            // UOE発注先名称
                uoeOdrDtlWrk.CommAssemblyId = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_COMMASSEMBLYIDRF"));              // 通信アセンブリID
                uoeOdrDtlWrk.OnlineNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ONLINENORF"));                           // オンライン番号
                uoeOdrDtlWrk.OnlineRowNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ONLINEROWNORF"));                     // オンライン行番号
                uoeOdrDtlWrk.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("UOE_SALESDATERF"));          // 売上日付
                uoeOdrDtlWrk.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("UOE_INPUTDAYRF"));            // 入力日
                uoeOdrDtlWrk.DataUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UOE_DATAUPDATEDATETIMERF"));       // データ更新日時
                
                uoeOdrDtlWrk.UOEKind = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_UOEKINDRF"));                             // UOE種別
                uoeOdrDtlWrk.SalesSlipNum = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_SALESSLIPNUMRF"));                  // 売上伝票番号
                uoeOdrDtlWrk.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ACPTANODRSTATUSRF"));             // 受注ステータス
                uoeOdrDtlWrk.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("UOE_SALESSLIPDTLNUMRF"));             // 売上明細通番
                uoeOdrDtlWrk.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_SECTIONCODERF"));                    // 拠点コード
                uoeOdrDtlWrk.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_SUBSECTIONCODERF"));               // 部門コード
                uoeOdrDtlWrk.CustomerCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_CUSTOMERCODERF"));                   // 得意先コード
                uoeOdrDtlWrk.CustomerSnm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_CUSTOMERSNMRF"));                    // 得意先略称
                uoeOdrDtlWrk.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_CASHREGISTERNORF"));               // レジ番号
                uoeOdrDtlWrk.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("UOE_COMMONSEQNORF"));                     // 共通通番
                uoeOdrDtlWrk.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_SUPPLIERFORMALRF"));               // 仕入形式
                uoeOdrDtlWrk.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_SUPPLIERSLIPNORF"));               // 仕入伝票番号
                uoeOdrDtlWrk.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("UOE_STOCKSLIPDTLNUMRF"));             // 仕入明細通番
                uoeOdrDtlWrk.BoCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_BOCODERF"));                              // BO区分
                uoeOdrDtlWrk.UOEDeliGoodsDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOE_UOEDELIGOODSDIVRF"));           // UOE納品区分
                uoeOdrDtlWrk.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_DELIVEREDGOODSDIVNMRF"));    // 納品区分名称
                uoeOdrDtlWrk.FollowDeliGoodsDiv = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_FOLLOWDELIGOODSDIVRF"));      // フォロー納品区分
                uoeOdrDtlWrk.FollowDeliGoodsDivNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_FOLLOWDELIGOODSDIVNMRF"));  // フォロー納品区分名称
                uoeOdrDtlWrk.UOEResvdSection = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOERESVDSECTIONRF"));            // UOE指定拠点
                uoeOdrDtlWrk.UOEResvdSectionNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOERESVDSECTIONNMRF"));        // UOE指定拠点名称
                uoeOdrDtlWrk.EmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_EMPLOYEECODERF"));                  // 従業員コード
                uoeOdrDtlWrk.EmployeeName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_EMPLOYEENAMERF"));                  // 従業員名称
                uoeOdrDtlWrk.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_GOODSMAKERCDRF"));                   // 商品メーカーコード
                uoeOdrDtlWrk.MakerName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAKERNAMERF"));                        // メーカー名称
                uoeOdrDtlWrk.GoodsNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_GOODSNORF"));                            // 商品番号
                uoeOdrDtlWrk.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_GOODSNONONEHYPHENRF"));        // ハイフン無商品番号
                uoeOdrDtlWrk.GoodsName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_GOODSNAMERF"));                        // 商品名称
                uoeOdrDtlWrk.WarehouseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_WAREHOUSECODERF"));                // 倉庫コード
                uoeOdrDtlWrk.WarehouseName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_WAREHOUSENAMERF"));                // 倉庫名称
                uoeOdrDtlWrk.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_WAREHOUSESHELFNORF"));          // 倉庫棚番
                uoeOdrDtlWrk.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("UOE_ACCEPTANORDERCNTRF"));          // 受注数量
                uoeOdrDtlWrk.ListPrice = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("UOE_LISTPRICERF"));                        // 定価（浮動）
                uoeOdrDtlWrk.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("UOE_SALESUNITCOSTRF"));                // 原価単価
                uoeOdrDtlWrk.SupplierCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_SUPPLIERCDRF"));                       // 仕入先コード
                uoeOdrDtlWrk.SupplierSnm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_SUPPLIERSNMRF"));                    // 仕入先略称
                uoeOdrDtlWrk.UoeRemark1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOEREMARK1RF"));                      // ＵＯＥリマーク１
                uoeOdrDtlWrk.UoeRemark2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOEREMARK2RF"));                      // ＵＯＥリマーク２
                uoeOdrDtlWrk.ReceiveDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UOE_RECEIVEDATERF"));     // 受信日付
                uoeOdrDtlWrk.ReceiveTime = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_RECEIVETIMERF"));                     // 受信時刻
                uoeOdrDtlWrk.AnswerMakerCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ANSWERMAKERCDRF"));                 // 回答メーカーコード
                uoeOdrDtlWrk.AnswerPartsNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_ANSWERPARTSNORF"));                // 回答品番
                uoeOdrDtlWrk.AnswerPartsName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_ANSWERPARTSNAMERF"));            // 回答品名
                uoeOdrDtlWrk.SubstPartsNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_SUBSTPARTSNORF"));                  // 代替品番
                uoeOdrDtlWrk.UOESectOutGoodsCnt = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_UOESECTOUTGOODSCNTRF"));       // UOE拠点出庫数
                uoeOdrDtlWrk.BOShipmentCnt1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_BOSHIPMENTCNT1RF"));               // BO出庫数1
                uoeOdrDtlWrk.BOShipmentCnt2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_BOSHIPMENTCNT2RF"));               // BO出庫数2
                uoeOdrDtlWrk.BOShipmentCnt3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_BOSHIPMENTCNT3RF"));               // BO出庫数3
                uoeOdrDtlWrk.MakerFollowCnt = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_MAKERFOLLOWCNTRF"));               // メーカーフォロー数
                uoeOdrDtlWrk.NonShipmentCnt = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_NONSHIPMENTCNTRF"));               // 未出庫数
                uoeOdrDtlWrk.UOESectStockCnt = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_UOESECTSTOCKCNTRF"));             // UOE拠点在庫数
                uoeOdrDtlWrk.BOStockCount1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_BOSTOCKCOUNT1RF"));                 // BO在庫数1
                uoeOdrDtlWrk.BOStockCount2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_BOSTOCKCOUNT2RF"));                 // BO在庫数2
                uoeOdrDtlWrk.BOStockCount3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_BOSTOCKCOUNT3RF"));                 // BO在庫数3
                uoeOdrDtlWrk.UOESectionSlipNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOESECTIONSLIPNORF"));          // UOE拠点伝票番号
                uoeOdrDtlWrk.BOSlipNo1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_BOSLIPNO1RF"));                        // BO伝票番号１
                uoeOdrDtlWrk.BOSlipNo2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_BOSLIPNO2RF"));                        // BO伝票番号２
                uoeOdrDtlWrk.BOSlipNo3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_BOSLIPNO3RF"));                        // BO伝票番号３
                uoeOdrDtlWrk.EOAlwcCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_EOALWCCOUNTRF"));                     // EO引当数
                uoeOdrDtlWrk.BOManagementNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_BOMANAGEMENTNORF"));              // BO管理番号
                uoeOdrDtlWrk.AnswerListPrice = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("UOE_ANSWERLISTPRICERF"));            // 回答定価
                uoeOdrDtlWrk.AnswerSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("UOE_ANSWERSALESUNITCOSTRF"));    // 回答原価単価
                uoeOdrDtlWrk.UOESubstMark = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOESUBSTMARKRF"));                  // UOE代替マーク
                uoeOdrDtlWrk.UOEStockMark = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOESTOCKMARKRF"));                  // UOE在庫マーク
                uoeOdrDtlWrk.PartsLayerCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_PARTSLAYERCDRF"));                  // 層別コード
                uoeOdrDtlWrk.MazdaUOEShipSectCd1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESHIPSECTCD1RF"));    // UOE出荷拠点コード１（マツダ）
                uoeOdrDtlWrk.MazdaUOEShipSectCd2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESHIPSECTCD2RF"));    // UOE出荷拠点コード２（マツダ）
                uoeOdrDtlWrk.MazdaUOEShipSectCd3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESHIPSECTCD3RF"));    // UOE出荷拠点コード３（マツダ）
                uoeOdrDtlWrk.MazdaUOESectCd1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESECTCD1RF"));            // UOE拠点コード１（マツダ）
                uoeOdrDtlWrk.MazdaUOESectCd2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESECTCD2RF"));            // UOE拠点コード２（マツダ）
                uoeOdrDtlWrk.MazdaUOESectCd3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESECTCD3RF"));            // UOE拠点コード３（マツダ）
                uoeOdrDtlWrk.MazdaUOESectCd4 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESECTCD4RF"));            // UOE拠点コード４（マツダ）
                uoeOdrDtlWrk.MazdaUOESectCd5 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESECTCD5RF"));            // UOE拠点コード５（マツダ）
                uoeOdrDtlWrk.MazdaUOESectCd6 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESECTCD6RF"));            // UOE拠点コード６（マツダ）
                uoeOdrDtlWrk.MazdaUOESectCd7 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESECTCD7RF"));            // UOE拠点コード７（マツダ）
                uoeOdrDtlWrk.MazdaUOEStockCnt1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_MAZDAUOESTOCKCNT1RF"));         // UOE在庫数１（マツダ）
                uoeOdrDtlWrk.MazdaUOEStockCnt2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_MAZDAUOESTOCKCNT2RF"));         // UOE在庫数２（マツダ）
                uoeOdrDtlWrk.MazdaUOEStockCnt3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_MAZDAUOESTOCKCNT3RF"));         // UOE在庫数３（マツダ）
                uoeOdrDtlWrk.MazdaUOEStockCnt4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_MAZDAUOESTOCKCNT4RF"));         // UOE在庫数４（マツダ）
                uoeOdrDtlWrk.MazdaUOEStockCnt5 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_MAZDAUOESTOCKCNT5RF"));         // UOE在庫数５（マツダ）
                uoeOdrDtlWrk.MazdaUOEStockCnt6 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_MAZDAUOESTOCKCNT6RF"));         // UOE在庫数６（マツダ）
                uoeOdrDtlWrk.MazdaUOEStockCnt7 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_MAZDAUOESTOCKCNT7RF"));         // UOE在庫数７（マツダ）
                uoeOdrDtlWrk.UOEDistributionCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOEDISTRIBUTIONCDRF"));        // UOE卸コード
                uoeOdrDtlWrk.UOEOtherCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOEOTHERCDRF"));                      // UOE他コード
                uoeOdrDtlWrk.UOEHMCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOEHMCDRF"));                            // UOEＨＭコード
                uoeOdrDtlWrk.BOCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_BOCOUNTRF"));                             // ＢＯ数
                uoeOdrDtlWrk.UOEMarkCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOEMARKCODERF"));                    // UOEマークコード
                uoeOdrDtlWrk.SourceShipment = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_SOURCESHIPMENTRF"));              // 出荷元
                uoeOdrDtlWrk.ItemCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_ITEMCODERF"));                          // アイテムコード
                uoeOdrDtlWrk.UOECheckCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOECHECKCODERF"));                  // UOEチェックコード
                uoeOdrDtlWrk.HeadErrorMassage = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_HEADERRORMASSAGERF"));          // ヘッドエラーメッセージ
                uoeOdrDtlWrk.LineErrorMassage = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_LINEERRORMASSAGERF"));          // ラインエラーメッセージ
                uoeOdrDtlWrk.DataSendCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_DATASENDCODERF"));                   // データ送信区分
                uoeOdrDtlWrk.DataRecoverDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_DATARECOVERDIVRF"));               // データ復旧区分
                uoeOdrDtlWrk.EnterUpdDivSec = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ENTERUPDDIVSECRF"));               // 入庫更新区分（拠点）
                uoeOdrDtlWrk.EnterUpdDivBO1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ENTERUPDDIVBO1RF"));               // 入庫更新区分（BO1）
                uoeOdrDtlWrk.EnterUpdDivBO2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ENTERUPDDIVBO2RF"));               // 入庫更新区分（BO2）
                uoeOdrDtlWrk.EnterUpdDivBO3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ENTERUPDDIVBO3RF"));               // 入庫更新区分（BO3）
                uoeOdrDtlWrk.EnterUpdDivMaker = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ENTERUPDDIVMAKERRF"));           // 入庫更新区分（ﾒｰｶｰ）
                uoeOdrDtlWrk.EnterUpdDivEO = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ENTERUPDDIVEORF"));                 // 入庫更新区分（EO）
				// ------------DEL wangf 2013/01/18 FOR Redmine#31980--------->>>>
                //// ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
                //// 原価単価（価格マスタより）
                //uoeOdrDtlWrk.GoodspriceuSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_SALESUNITCOSTRF"));
                //uoeOdrDtlWrk.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_PRICESTARTDATERF"));
                //uoeOdrDtlWrk.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_STOCKRATERF"));
                //uoeOdrDtlWrk.PriceListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_LISTPRICERF"));

                //uoeOdrDtlWrk.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));            // 商品掛率ランク
                //uoeOdrDtlWrk.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));         // BL商品コード
                //uoeOdrDtlWrk.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));         // 課税区分
                //// ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<
				// ------------DEL wangf 2013/01/18 FOR Redmine#31980---------<<<<
                # endregion
            }
        }

        /// <summary>
        /// クラス格納処理 Reader → StockDetailWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockDetailWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        private StockDetailWork CopyToStockDetailWorkFromReader(ref SqlDataReader myReader)
        {
            StockDetailWork stcDtlWrk = new StockDetailWork();

            this.CopyToStockDetailWorkFromReader(ref myReader, ref stcDtlWrk);

            return stcDtlWrk;
        }

        /// <summary>
        /// クラス格納処理 Reader → StockDetailWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="stcDtlWrk">StockDetailWork オブジェクト</param>
        /// <remarks>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        private void CopyToStockDetailWorkFromReader(ref SqlDataReader myReader, ref StockDetailWork stcDtlWrk)
        {
            if (myReader != null && stcDtlWrk != null)
            {
                # region クラスへ格納
                stcDtlWrk.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("STC_CREATEDATETIMERF"));               // 作成日時
                stcDtlWrk.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("STC_UPDATEDATETIMERF"));               // 更新日時
                stcDtlWrk.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_ENTERPRISECODERF"));                          // 企業コード
                stcDtlWrk.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("STC_FILEHEADERGUIDRF"));                            // GUID
                stcDtlWrk.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_UPDEMPLOYEECODERF"));                        // 更新従業員コード
                stcDtlWrk.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_UPDASSEMBLYID1RF"));                          // 更新アセンブリID1
                stcDtlWrk.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_UPDASSEMBLYID2RF"));                          // 更新アセンブリID2
                stcDtlWrk.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_LOGICALDELETECODERF"));                     // 論理削除区分
                stcDtlWrk.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_ACCEPTANORDERNORF"));                         // 受注番号
                stcDtlWrk.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_SUPPLIERFORMALRF"));                           // 仕入形式
                stcDtlWrk.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_SUPPLIERSLIPNORF"));                           // 仕入伝票番号
                stcDtlWrk.StockRowNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_STOCKROWNORF"));                                   // 仕入行番号
                stcDtlWrk.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_SECTIONCODERF"));                                // 拠点コード
                stcDtlWrk.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_SUBSECTIONCODERF"));                           // 部門コード
                stcDtlWrk.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("STC_COMMONSEQNORF"));                                 // 共通通番
                stcDtlWrk.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("STC_STOCKSLIPDTLNUMRF"));                         // 仕入明細通番
                stcDtlWrk.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_SUPPLIERFORMALSRCRF"));                     // 仕入形式（元）
                stcDtlWrk.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("STC_STOCKSLIPDTLNUMSRCRF"));                   // 仕入明細通番（元）
                stcDtlWrk.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_ACPTANODRSTATUSSYNCRF"));                 // 受注ステータス（同時）
                stcDtlWrk.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("STC_SALESSLIPDTLNUMSYNCRF"));                 // 売上明細通番（同時）
                stcDtlWrk.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_STOCKSLIPCDDTLRF"));                           // 仕入伝票区分（明細）
                stcDtlWrk.StockInputCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_STOCKINPUTCODERF"));                          // 仕入入力者コード
                stcDtlWrk.StockInputName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_STOCKINPUTNAMERF"));                          // 仕入入力者名称
                stcDtlWrk.StockAgentCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_STOCKAGENTCODERF"));                          // 仕入担当者コード
                stcDtlWrk.StockAgentName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_STOCKAGENTNAMERF"));                          // 仕入担当者名称
                stcDtlWrk.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_GOODSKINDCODERF"));                             // 商品属性
                stcDtlWrk.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_GOODSMAKERCDRF"));                               // 商品メーカーコード
                stcDtlWrk.MakerName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_MAKERNAMERF"));                                    // メーカー名称
                stcDtlWrk.MakerKanaName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_MAKERKANANAMERF"));                            // メーカーカナ名称
                stcDtlWrk.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_CMPLTMAKERKANANAMERF"));                  // メーカーカナ名称（一式）
                stcDtlWrk.GoodsNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_GOODSNORF"));                                        // 商品番号
                stcDtlWrk.GoodsName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_GOODSNAMERF"));                                    // 商品名称
                stcDtlWrk.GoodsNameKana = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_GOODSNAMEKANARF"));                            // 商品名称カナ
                stcDtlWrk.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_GOODSLGROUPRF"));                                 // 商品大分類コード
                stcDtlWrk.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_GOODSLGROUPNAMERF"));                        // 商品大分類名称
                stcDtlWrk.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_GOODSMGROUPRF"));                                 // 商品中分類コード
                stcDtlWrk.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_GOODSMGROUPNAMERF"));                        // 商品中分類名称
                stcDtlWrk.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_BLGROUPCODERF"));                                 // BLグループコード
                stcDtlWrk.BLGroupName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_BLGROUPNAMERF"));                                // BLグループコード名称
                stcDtlWrk.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_BLGOODSCODERF"));                                 // BL商品コード
                stcDtlWrk.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_BLGOODSFULLNAMERF"));                        // BL商品コード名称（全角）
                stcDtlWrk.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_ENTERPRISEGANRECODERF"));                 // 自社分類コード
                stcDtlWrk.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_ENTERPRISEGANRENAMERF"));                // 自社分類名称
                stcDtlWrk.WarehouseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_WAREHOUSECODERF"));                            // 倉庫コード
                stcDtlWrk.WarehouseName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_WAREHOUSENAMERF"));                            // 倉庫名称
                stcDtlWrk.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_WAREHOUSESHELFNORF"));                      // 倉庫棚番
                stcDtlWrk.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_STOCKORDERDIVCDRF"));                         // 仕入在庫取寄せ区分
                stcDtlWrk.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_OPENPRICEDIVRF"));                               // オープン価格区分
                stcDtlWrk.GoodsRateRank = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_GOODSRATERANKRF"));                            // 商品掛率ランク
                stcDtlWrk.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_CUSTRATEGRPCODERF"));                         // 得意先掛率グループコード
                stcDtlWrk.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_SUPPRATEGRPCODERF"));                         // 仕入先掛率グループコード
                stcDtlWrk.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_LISTPRICETAXEXCFLRF"));                    // 定価（税抜，浮動）
                stcDtlWrk.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_LISTPRICETAXINCFLRF"));                    // 定価（税込，浮動）
                stcDtlWrk.StockRate = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_STOCKRATERF"));                                    // 仕入率
                stcDtlWrk.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_RATESECTSTCKUNPRCRF"));                    // 掛率設定拠点（仕入単価）
                stcDtlWrk.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_RATEDIVSTCKUNPRCRF"));                      // 掛率設定区分（仕入単価）
                stcDtlWrk.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_UNPRCCALCCDSTCKUNPRCRF"));               // 単価算出区分（仕入単価）
                stcDtlWrk.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_PRICECDSTCKUNPRCRF"));                       // 価格区分（仕入単価）
                stcDtlWrk.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_STDUNPRCSTCKUNPRCRF"));                    // 基準単価（仕入単価）
                stcDtlWrk.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_FRACPROCUNITSTCUNPRCRF"));              // 端数処理単位（仕入単価）
                stcDtlWrk.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_FRACPROCSTCKUNPRCRF"));                     // 端数処理（仕入単価）
                stcDtlWrk.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_STOCKUNITPRICEFLRF"));                      // 仕入単価（税抜，浮動）
                stcDtlWrk.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_STOCKUNITTAXPRICEFLRF"));                // 仕入単価（税込，浮動）
                stcDtlWrk.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_STOCKUNITCHNGDIVRF"));                       // 仕入単価変更区分
                stcDtlWrk.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_BFSTOCKUNITPRICEFLRF"));                  // 変更前仕入単価（浮動）
                stcDtlWrk.BfListPrice = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_BFLISTPRICERF"));                                // 変更前定価
                stcDtlWrk.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_RATEBLGOODSCODERF"));                         // BL商品コード（掛率）
                stcDtlWrk.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_RATEBLGOODSNAMERF"));                        // BL商品コード名称（掛率）
                stcDtlWrk.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_RATEGOODSRATEGRPCDRF"));                   // 商品掛率グループコード（掛率）
                stcDtlWrk.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_RATEGOODSRATEGRPNMRF"));                  // 商品掛率グループ名称（掛率）
                stcDtlWrk.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_RATEBLGROUPCODERF"));                         // BLグループコード（掛率）
                stcDtlWrk.RateBLGroupName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_RATEBLGROUPNAMERF"));                        // BLグループ名称（掛率）
                stcDtlWrk.StockCount = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_STOCKCOUNTRF"));                                  // 仕入数
                stcDtlWrk.OrderCnt = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_ORDERCNTRF"));                                      // 発注数量
                stcDtlWrk.OrderAdjustCnt = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_ORDERADJUSTCNTRF"));                          // 発注調整数
                stcDtlWrk.OrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_ORDERREMAINCNTRF"));                          // 発注残数
                stcDtlWrk.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("STC_REMAINCNTUPDDATERF"));        // 残数更新日
                stcDtlWrk.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("STC_STOCKPRICETAXEXCRF"));                       // 仕入金額（税抜き）
                stcDtlWrk.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("STC_STOCKPRICETAXINCRF"));                       // 仕入金額（税込み）
                stcDtlWrk.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_STOCKGOODSCDRF"));                               // 仕入商品区分
                stcDtlWrk.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("STC_STOCKPRICECONSTAXRF"));                     // 仕入金額消費税額
                stcDtlWrk.TaxationCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_TAXATIONCODERF"));                               // 課税区分
                stcDtlWrk.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_STOCKDTISLIPNOTE1RF"));                    // 仕入伝票明細備考1
                stcDtlWrk.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_SALESCUSTOMERCODERF"));                     // 販売先コード
                stcDtlWrk.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_SALESCUSTOMERSNMRF"));                      // 販売先略称
                stcDtlWrk.SlipMemo1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_SLIPMEMO1RF"));                                    // 伝票メモ１
                stcDtlWrk.SlipMemo2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_SLIPMEMO2RF"));                                    // 伝票メモ２
                stcDtlWrk.SlipMemo3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_SLIPMEMO3RF"));                                    // 伝票メモ３
                stcDtlWrk.InsideMemo1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_INSIDEMEMO1RF"));                                // 社内メモ１
                stcDtlWrk.InsideMemo2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_INSIDEMEMO2RF"));                                // 社内メモ２
                stcDtlWrk.InsideMemo3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_INSIDEMEMO3RF"));                                // 社内メモ３
                stcDtlWrk.SupplierCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_SUPPLIERCDRF"));                                   // 仕入先コード
                stcDtlWrk.SupplierSnm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_SUPPLIERSNMRF"));                                // 仕入先略称
                stcDtlWrk.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_ADDRESSEECODERF"));                             // 納品先コード
                stcDtlWrk.AddresseeName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_ADDRESSEENAMERF"));                            // 納品先名称
                stcDtlWrk.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_DIRECTSENDINGCDRF"));                         // 直送区分
                stcDtlWrk.OrderNumber = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_ORDERNUMBERRF"));                                // 発注番号
                stcDtlWrk.WayToOrder = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_WAYTOORDERRF"));                                   // 注文方法
                stcDtlWrk.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("STC_DELIGDSCMPLTDUEDATERF"));  // 納品完了予定日
                stcDtlWrk.ExpectDeliveryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("STC_EXPECTDELIVERYDATERF"));    // 希望納期
                stcDtlWrk.OrderDataCreateDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_ORDERDATACREATEDIVRF"));                   // 発注データ作成区分
                stcDtlWrk.OrderDataCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("STC_ORDERDATACREATEDATERF"));  // 発注データ作成日
                stcDtlWrk.OrderFormIssuedDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_ORDERFORMISSUEDDIVRF"));                   // 発注書発行済区分
                # endregion
            }
        }

        /// <summary>
        /// クラス格納処理 Reader → StockDetailWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockDetailWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        private StockSlipWork CopyToStockSlipWorkFromReader(ref SqlDataReader myReader)
        {
            StockSlipWork stcSlpWrk = new StockSlipWork();

            this.CopyToStockSlipWorkFromReader(ref myReader, ref stcSlpWrk);

            return stcSlpWrk;
        }

        /// <summary>
        /// クラス格納処理 Reader → StockDetailWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="stcSlpWrk">StockDetailWork オブジェクト</param>
        /// <remarks>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        private void CopyToStockSlipWorkFromReader(ref SqlDataReader myReader, ref StockSlipWork stcSlpWrk)
        {
            if (myReader != null && stcSlpWrk != null)
            {
                # region クラスへ格納
                stcSlpWrk.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));             // 作成日時
                stcSlpWrk.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));             // 更新日時
                stcSlpWrk.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                        // 企業コード
                stcSlpWrk.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                          // GUID
                stcSlpWrk.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));                      // 更新従業員コード
                stcSlpWrk.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                        // 更新アセンブリID1
                stcSlpWrk.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                        // 更新アセンブリID2
                stcSlpWrk.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));                   // 論理削除区分
                stcSlpWrk.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));                         // 仕入形式
                stcSlpWrk.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));                         // 仕入伝票番号
                stcSlpWrk.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));                              // 拠点コード
                stcSlpWrk.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));                         // 部門コード
                stcSlpWrk.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));                             // 赤伝区分
                stcSlpWrk.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));               // 赤黒連結仕入伝票番号
                stcSlpWrk.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));                         // 仕入伝票区分
                stcSlpWrk.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));                             // 仕入商品区分
                stcSlpWrk.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));                               // 買掛区分
                stcSlpWrk.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));                        // 仕入拠点コード
                stcSlpWrk.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));              // 仕入計上拠点コード
                stcSlpWrk.StockSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPUPDATECDRF"));                   // 仕入伝票更新区分
                stcSlpWrk.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));                      // 入力日
                stcSlpWrk.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));        // 入荷日
                stcSlpWrk.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));                    // 仕入日
                stcSlpWrk.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));        // 仕入計上日付
                stcSlpWrk.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));                       // 来勘区分
                stcSlpWrk.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));                                   // 支払先コード
                stcSlpWrk.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));                                    // 支払先略称
                stcSlpWrk.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));                                 // 仕入先コード
                stcSlpWrk.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));                              // 仕入先名1
                stcSlpWrk.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));                              // 仕入先名2
                stcSlpWrk.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));                              // 仕入先略称
                stcSlpWrk.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));                     // 業種コード
                stcSlpWrk.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));                    // 業種名称
                stcSlpWrk.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));                           // 販売エリアコード
                stcSlpWrk.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));                          // 販売エリア名称
                stcSlpWrk.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));                        // 仕入入力者コード
                stcSlpWrk.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));                        // 仕入入力者名称
                stcSlpWrk.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));                        // 仕入担当者コード
                stcSlpWrk.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));                        // 仕入担当者名称
                stcSlpWrk.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));               // 仕入先総額表示方法区分
                stcSlpWrk.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));                 // 総額表示掛率適用区分
                stcSlpWrk.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));                       // 仕入金額合計
                stcSlpWrk.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));                     // 仕入金額小計
                stcSlpWrk.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));                 // 仕入金額計（税込み）
                stcSlpWrk.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));                 // 仕入金額計（税抜き）
                stcSlpWrk.StockNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKNETPRICERF"));                           // 仕入正価金額
                stcSlpWrk.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));                   // 仕入金額消費税額
                stcSlpWrk.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));                   // 仕入外税対象額合計
                stcSlpWrk.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));                     // 仕入内税対象額合計
                stcSlpWrk.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));                 // 仕入非課税対象額合計
                stcSlpWrk.StockOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAXRF"));                               // 仕入金額消費税額（外税）
                stcSlpWrk.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));               // 仕入金額消費税額（内税）
                stcSlpWrk.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));                     // 仕入値引金額計（税抜き）
                stcSlpWrk.ItdedStockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISOUTTAXRF"));               // 仕入値引外税対象額合計
                stcSlpWrk.ItdedStockDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISINTAXRF"));                 // 仕入値引内税対象額合計
                stcSlpWrk.ItdedStockDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISTAXFRERF"));               // 仕入値引非課税対象額合計
                stcSlpWrk.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));                         // 仕入値引消費税額（外税）
                stcSlpWrk.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));                 // 仕入値引消費税額（内税）
                stcSlpWrk.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));                                   // 消費税調整額
                stcSlpWrk.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));                           // 残高調整額
                stcSlpWrk.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));                           // 仕入先消費税転嫁方式コード
                stcSlpWrk.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));              // 仕入先消費税税率
                stcSlpWrk.AccPayConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCPAYCONSTAXRF"));                           // 買掛消費税
                stcSlpWrk.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKFRACTIONPROCCDRF"));               // 仕入端数処理区分
                stcSlpWrk.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));                               // 自動支払区分
                stcSlpWrk.AutoPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYSLIPNUMRF"));                         // 自動支払伝票番号
                stcSlpWrk.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));                   // 返品理由コード
                stcSlpWrk.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));                        // 返品理由
                stcSlpWrk.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));                    // 相手先伝票番号
                stcSlpWrk.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));                  // 仕入伝票備考1
                stcSlpWrk.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));                  // 仕入伝票備考2
                stcSlpWrk.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));                         // 明細行数
                stcSlpWrk.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));                // ＥＤＩ送信日
                stcSlpWrk.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));            // ＥＤＩ取込日
                stcSlpWrk.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));                                // ＵＯＥリマーク１
                stcSlpWrk.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));                                // ＵＯＥリマーク２
                stcSlpWrk.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));                         // 伝票発行区分
                stcSlpWrk.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));                   // 伝票発行済区分
                stcSlpWrk.StockSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKSLIPPRINTDATERF"));  // 仕入伝票発行日
                stcSlpWrk.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));                  // 伝票印刷設定用帳票ID
                stcSlpWrk.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));                         // 伝票住所区分
                stcSlpWrk.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));                           // 納品先コード
                stcSlpWrk.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));                          // 納品先名称
                stcSlpWrk.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));                        // 納品先名称2
                stcSlpWrk.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));                      // 納品先郵便番号
                stcSlpWrk.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));                        // 納品先住所1(都道府県市区郡・町村・字)
                stcSlpWrk.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));                        // 納品先住所3(番地)
                stcSlpWrk.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));                        // 納品先住所4(アパート名称)
                stcSlpWrk.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));                        // 納品先電話番号
                stcSlpWrk.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));                        // 納品先FAX番号
                stcSlpWrk.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));                       // 直送区分
                # endregion
            }
        }

        # endregion
    }
}
