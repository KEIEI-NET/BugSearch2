//**********************************************************************//
// System           :   ＰＭ．ＮＳ
// Sub System       :
// Program name     :   自由帳票（在庫移動伝票）　リモートオブジェクト
//                  :   PMZAI08004R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programer        :   22018 鈴木 正臣
// Date             :   2008.09.29
//----------------------------------------------------------------------//
// Update Note      :
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co,. Ltd
//**********************************************************************//
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
	/// 自由帳票（在庫移動伝票）　リモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自由帳票印字位置設定マスタ取得を行うクラスです。</br>
	/// <br>Programmer : 22018　鈴木　正臣</br>
	/// <br>Date       : 2008.06.03</br>
	/// <br>Update Note: 2010/03/31 30531 大矢 睦美</br>
    /// <br>           : 【14813】全体初期値設定の取得処理を追加する</br>
	/// </remarks>
	[Serializable]
    public class FrePStockMoveSlipDB : RemoteDB, IFrePStockMoveSlipDB
	{
		/// <summary>
        /// 自由帳票（在庫移動伝票）　リモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 22018 鈴木　正臣</br>
		/// <br>Date       : 2008.06.03</br>
		/// </remarks>
        public FrePStockMoveSlipDB()
		{
        }

        #region [Search]
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">自由帳票共通抽出パラメータ</param>
        /// <param name="frePStockMoveSlipRetWorkList">抽出結果リスト</param>
        /// <param name="frePMasterList">関連マスタリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note         : 指定された自由帳票検索結果クラスワークLISTを取得します。</br>
        /// <br>Programmer   : 22018 鈴木　正臣</br>
        /// <br>Date         : 2008.06.03</br>
        /// </remarks>
        public int Search( object frePrtCmnExtPrmWork, out object frePStockMoveSlipRetWorkList, out object frePMasterList, out bool msgDiv, out string errMsg )
        {
            return SearchProc( frePrtCmnExtPrmWork, out frePStockMoveSlipRetWorkList, out frePMasterList, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">自由帳票共通抽出パラメータ</param>
        /// <param name="frePStockMoveSlipRetWorkList">抽出結果リスト</param>
        /// <param name="frePMasterList">関連マスタリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int SearchProc( object frePrtCmnExtPrmWork, out object frePStockMoveSlipRetWorkList, out object frePMasterList, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlEncryptInfo sqlEncryptInfo = null;
            msgDiv = false;
            errMsg = string.Empty;
            frePStockMoveSlipRetWorkList = null;
            frePMasterList = null;
            
            // デシリアライズ
            FrePStockMoveSlipParaWork extPrm = (FrePStockMoveSlipParaWork)XmlByteSerializer.Deserialize( (byte[])frePrtCmnExtPrmWork, typeof( FrePStockMoveSlipParaWork ) );

            SqlConnection sqlConnection = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                if ( connectionText == null || connectionText == "" ) return status;

                //SQL文生成
                sqlConnection = new SqlConnection( connectionText );
                sqlConnection.Open();

                //// 暗号化情報設定
                //if ((extPrm.CipherItemsLs != null) && (extPrm.CipherItemsLs.Count > 0))
                //{
                //    sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, extPrm.CipherItemsLs.ToArray());
                //    sqlEncryptInfo.OpenSymKey(ref sqlConnection);
                //}

                // 関連マスタ抽出
                status = SearchSetInfos( extPrm, out frePMasterList, ref sqlConnection );

                // データ抽出
                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    status = SearchProc( extPrm, out frePStockMoveSlipRetWorkList, ref sqlConnection );
                }

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    frePStockMoveSlipRetWorkList = null;
                    frePMasterList = null;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "FrePDailyExtRetDB_Search\n" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票（在庫移動伝票）抽出処理中にタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "FrePDailyExtRetDB_Search\n"+ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                //暗号化キークローズ
                if ( sqlEncryptInfo != null )
                {
                    if ( sqlEncryptInfo.IsOpen )
                    {
                        sqlEncryptInfo.CloseSymKey( ref sqlConnection );
                    }
                }
                if ( sqlConnection != null )
                {
                    sqlConnection.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// データ抽出処理（メイン）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePStockMoveSlipRetWorkList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchProc( FrePStockMoveSlipParaWork extPrm, out object frePStockMoveSlipRetWorkList, ref SqlConnection sqlConnection )
        {
            frePStockMoveSlipRetWorkList = null;

            List<FrePStockMoveSlipWork> slipList = null;
            Dictionary<Int32, List<FrePStockMoveDetailWork>> detailListDic = null;

            // 伝票ヘッダ抽出処理
            int status = SearchProcOfSlip( extPrm, out slipList, sqlConnection );

            // 伝票明細抽出処理
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                status = SearchProcOfDetail( extPrm, out detailListDic, sqlConnection );
            }

            // 返却データ生成
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                CustomSerializeArrayList retList = new CustomSerializeArrayList();
                foreach ( FrePStockMoveSlipWork slipWork in slipList )
                {
                    CustomSerializeArrayList newSlipList = new CustomSerializeArrayList();
                    newSlipList.Add( slipWork );
                    if ( detailListDic.ContainsKey( slipWork.MOVH_STOCKMOVESLIPNORF ) )
                    {
                        newSlipList.Add( detailListDic[slipWork.MOVH_STOCKMOVESLIPNORF] );
                    }
                    retList.Add( newSlipList );
                }
                frePStockMoveSlipRetWorkList = retList;
            }

            return status;
        }

        #endregion

        #region [private メソッド]

        # region [マスタ抽出]
        /// <summary>
        /// 自由帳票（在庫移動伝票）関連マスタ検索処理
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePMasterList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns>ステータス</returns>
        /// <remarks>伝票発行に必要な各種マスタを格納して返します。</remarks>
        private int SearchSetInfos( FrePStockMoveSlipParaWork extPrm, out object frePMasterList, ref SqlConnection sqlConnection )
        {
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            CustomSerializeArrayList slipPrtSetList = new CustomSerializeArrayList();
            int status;

            // 伝票印刷設定 （SFURI09024R.SlipPrtSetDB）
            status = SearchSlipPrtSet( extPrm, ref slipPrtSetList, ref sqlConnection );
            if ( slipPrtSetList != null && slipPrtSetList.Count > 0 )
            {
                retList.Add( slipPrtSetList[0] );
            }
            if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;


            // 自由帳票印字位置設定 (SFANL08124R.FrePrtPSetDB)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                try
                {
                    status = SearchFrePrtPSet( extPrm, (SlipPrtSetWork[])slipPrtSetList[0], ref retList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // 伝票タイプ管理設定 （DCKHN09134R.CustSlipMngDB）
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                try
                {
                    status = SearchCustSlipMng( extPrm, ref retList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                { 
                }
            }
            // 伝票出力先設定 (DCKHN09264R.SlipOutputSetDB)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                try
                {
                    status = SearchSlipOutputSet( extPrm, ref retList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                { 
                }
            }

            // 在庫管理全体設定 (MAZAI09114R.StockMngTtlStDB)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                try
                {
                    status = SearchStockMngTtlSt( extPrm, ref retList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }

            // --- ADD  大矢睦美  2010/03/31 ---------->>>>>
            // 全体初期値設定 (SFCMN09084R.AllDefSetDB)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                try
                {
                    status = SearchAllDefSet(extPrm, ref retList, ref sqlConnection);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // --- ADD  大矢睦美  2010/03/31 ----------<<<<<

            frePMasterList = retList;
            return status;
        }

        /// <summary>
        /// Search 伝票印刷設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        private int SearchSlipPrtSet( FrePStockMoveSlipParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            SlipPrtSetDB slipPrtSetDB = new SlipPrtSetDB();

            // 抽出条件の設定
            SlipPrtSetWork paraWork = new SlipPrtSetWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;

            // 検索
            ArrayList retList;
            int status = slipPrtSetDB.Search( out retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null )
            {
                refRetList.Add( retList.ToArray( typeof( SlipPrtSetWork ) ) );
            }
            return status;
        }
        /// <summary>
        /// Search 伝票タイプ管理設定（旧 得意先マスタ(伝票管理)）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        private int SearchCustSlipMng( FrePStockMoveSlipParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            CustSlipMngDB custSlipMngDB = new CustSlipMngDB();

            CustSlipMngWork paraWork = new CustSlipMngWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;

            // 検索
            ArrayList retList = new ArrayList();
            int status = custSlipMngDB.SearchCustSlipMngProc( out retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null )
            {
                refRetList.Add( retList.ToArray( typeof( CustSlipMngWork ) ) );
            }

            return status;
        }
        /// <summary>
        /// Search 伝票出力先設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        private int SearchSlipOutputSet( FrePStockMoveSlipParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            SlipOutputSetDB slipOutputSetDB = new SlipOutputSetDB();

            // 検索
            ArrayList retList = new ArrayList();
            SearchSlipOutputSetParaWork paraWork = new SearchSlipOutputSetParaWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            paraWork.CashRegisterNo = -1;
            paraWork.DataInputSystem = 0;
            paraWork.SlipPrtKind = -1;
            int status = slipOutputSetDB.SearchSlipOutputSetProc( out retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null )
            {
                refRetList.Add( retList.ToArray( typeof( SlipOutputSetWork ) ) );
            }
            return status;
        }
        /// <summary>
        /// Search 在庫管理全体設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchStockMngTtlSt( FrePStockMoveSlipParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            StockMngTtlStDB stockMngTtlStDB = new StockMngTtlStDB();

            // 検索
            ArrayList retList = new ArrayList();
            StockMngTtlStWork paraWork = new StockMngTtlStWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            int status = stockMngTtlStDB.SearchStockMngTtlStProc( out retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null )
            {
                refRetList.Add( retList.ToArray( typeof( StockMngTtlStWork ) ) );
            }
            return status;
        }

        /// <summary>
        /// Search 自由帳票印字位置設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="slipPrtSetList"></param>
        /// <param name="retList"></param>
        /// <param name="sqlConnection"></param>
        private int SearchFrePrtPSet( FrePStockMoveSlipParaWork extPrm, SlipPrtSetWork[] slipPrtSetList, ref CustomSerializeArrayList retList, ref SqlConnection sqlConnection )
        {
            // 読み込みキーリスト
            List<FrePrtPSetDB.FrePrtPSetReadKey> keyList = new List<FrePrtPSetDB.FrePrtPSetReadKey>();
            foreach ( SlipPrtSetWork slipPrtSetWork in slipPrtSetList )
            {
                keyList.Add( GetFrePrtPSetKey( slipPrtSetWork ) );
            }

            // ユーザーＤＢ検索
            FrePrtPSetDB frePrtPSetDB = new FrePrtPSetDB();
            List<FrePrtPSetWork> frePrtPSetWorkList;
            int status = frePrtPSetDB.SearchFrePrtPSetProc( extPrm.EnterpriseCode, keyList, out frePrtPSetWorkList, ref sqlConnection );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && frePrtPSetWorkList != null )
            {
                retList.Add( frePrtPSetWorkList.ToArray() );
            }
            return status;
        }
        // --- ADD  大矢睦美  2010/03/31 ---------->>>>>
        /// <summary>
        /// Search 全体初期値設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="retList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchAllDefSet(FrePStockMoveSlipParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection)
        {
            AllDefSetDB allDefSetDB = new AllDefSetDB();

            // 検索
            AllDefSetWork paraWork = new AllDefSetWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            ArrayList retList;
            int status = allDefSetDB.Search(out retList, paraWork, ref sqlConnection, ConstantManagement.LogicalMode.GetData0);

            // 取得結果
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null)
            {
                refRetList.Add(retList.ToArray(typeof(AllDefSetWork)));
            }
            return status;
        }
        // --- ADD  大矢睦美  2010/03/31 ----------<<<<<
        /// <summary>
        /// 自由帳票印字位置設定Readキー取得処理
        /// </summary>
        /// <param name="slipPrtSetWork">伝票印字位置設定</param>
        /// <returns>自由帳票印字位置設定Readキー</returns>
        private FrePrtPSetDB.FrePrtPSetReadKey GetFrePrtPSetKey( SlipPrtSetWork slipPrtSetWork )
        {
            FrePrtPSetDB.FrePrtPSetReadKey key = new FrePrtPSetDB.FrePrtPSetReadKey();
            key.OutputFormFileName = slipPrtSetWork.OutputFormFileName;

            if ( slipPrtSetWork.SlipPrtSetPaperId.StartsWith( slipPrtSetWork.OutputFormFileName ) )
            {
                string DerivNoText = slipPrtSetWork.SlipPrtSetPaperId.Substring( slipPrtSetWork.OutputFormFileName.Length, slipPrtSetWork.SlipPrtSetPaperId.Length - slipPrtSetWork.OutputFormFileName.Length );
                try
                {
                    key.UserPrtPprIdDerivNo = Int32.Parse( DerivNoText );
                }
                catch
                {
                    key.UserPrtPprIdDerivNo = 0;
                }
            }

            return key;
        }
        # endregion

        # region [在庫移動データ抽出]
        /// <summary>
        /// 自由帳票日次帳票グループ情報検索処理（メイン部）
        /// </summary>
        /// <param name="extPrm">自由帳票共通抽出条件クラス</param>
        /// <param name="retObj">印字位置設定ワーククラス配列</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 指定された自由帳票印字位置設定検索結果クラスワークLISTを取得します。</br>
        /// <br>Programmer	: 22018 鈴木　正臣</br>
        /// <br>Date		: 2008.06.03</br>
        /// </remarks>
        private int SearchProcOfSlip( FrePStockMoveSlipParaWork extPrm, out List<FrePStockMoveSlipWork> retObj, SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            List<FrePStockMoveSlipWork> frePStockMoveSlipWorkList = new List<FrePStockMoveSlipWork>();
            retObj = null;

            try
            {
                //-------------------------------------------------------------------
                // 対象テーブル
                //   在庫移動データ①  StockMoveRF As MOVH
                //     拠点情報設定マスタ①  SecInfoSetRF As SEC1
                //       自社名称マスタ①  CompanyNmRF As CMP1
                //         画像情報マスタ  ImageInfoRF
                //     拠点情報設定マスタ②  SecInfoSetRF As SEC2
                //       自社名称マスタ②  CompanyNmRF As CMP2
                //     従業員マスタ①  EmployeeRF As EMP1
                //     従業員マスタ②  EmployeeRF As EMP2
                //     従業員マスタ③  EmployeeRF As EMP3
                //     自社情報マスタ  CompanyInfRF
                //     拠点情報設定マスタ0   SecInfoSetRF As SEC0
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand( "SELECT " + this.GetSelectItemsForSlip( extPrm )
                    + Environment.NewLine
                    + " FROM STOCKMOVERF AS MOVH " + Environment.NewLine
                    + LeftJoin( "MOVH", "SECINFOSETRF", "SEC1", new string[] { }, new string[] { "MOVH.BFSECTIONCODERF = SEC1.SECTIONCODERF" } )  // 企業cd,拠点cd
                    + LeftJoin( "SEC1", "COMPANYNMRF", "CMP1", new string[] { }, new string[] { "SEC1.COMPANYNAMECD1RF=CMP1.COMPANYNAMECDRF" } )    // 企業cd,自社名称cd
                    + LeftJoin( "CMP1", "IMAGEINFORF", string.Empty, new string[] { "IMAGEINFOCODERF" }, new string[] { "IMAGEINFORF.IMAGEINFODIVRF='10'" } )    // 企業cd,画像情報cd,区分=10
                    + LeftJoin( "MOVH", "SECINFOSETRF", "SEC2", new string[] { }, new string[] { "MOVH.AFSECTIONCODERF = SEC2.SECTIONCODERF" } )  // 企業cd,拠点cd
                    + LeftJoin( "SEC2", "COMPANYNMRF", "CMP2", new string[] { }, new string[] { "SEC2.COMPANYNAMECD1RF=CMP2.COMPANYNAMECDRF" } )    // 企業cd,自社名称cd
                    + LeftJoin( "MOVH", "EMPLOYEERF", "EMP1", new string[] { }, new string[] { "MOVH.STOCKMVEMPCODERF=EMP1.EMPLOYEECODERF" } )  // 企業cd,従業員cd
                    + LeftJoin( "MOVH", "EMPLOYEERF", "EMP2", new string[] { }, new string[] { "MOVH.SHIPAGENTCDRF=EMP2.EMPLOYEECODERF" } )  // 企業cd,従業員cd
                    + LeftJoin( "MOVH", "EMPLOYEERF", "EMP3", new string[] { }, new string[] { "MOVH.RECEIVEAGENTCDRF=EMP3.EMPLOYEECODERF" } )  // 企業cd,従業員cd
                    + LeftJoin( "MOVH", "COMPANYINFRF", string.Empty, new string[] { }, new string[] { } ) // 企業cd
                    + LeftJoin( "MOVH", "SECINFOSETRF", "SEC0", new string[] { }, new string[] { "MOVH.UPDATESECCDRF = SEC0.SECTIONCODERF" } )  // 企業cd,拠点cd
                    , sqlConnection );

                // WHERE文を生成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, extPrm);
                // OrderBy句を生成
                sqlCommand.CommandText += " ORDER BY STOCKMOVEFORMALRF, STOCKMOVESLIPNORF " + Environment.NewLine;

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    FrePStockMoveSlipWork frePStockMoveSlipWork = new FrePStockMoveSlipWork();

                    # region [データのコピー]
                    frePStockMoveSlipWork.MOVH_STOCKMOVEFORMALRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "STOCKMOVEFORMALRF" ) );
                    frePStockMoveSlipWork.MOVH_STOCKMOVESLIPNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "STOCKMOVESLIPNORF" ) );
                    frePStockMoveSlipWork.MOVH_BFSECTIONCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BFSECTIONCODERF" ) );
                    frePStockMoveSlipWork.MOVH_BFSECTIONGUIDESNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BFSECTIONGUIDESNMRF" ) );
                    frePStockMoveSlipWork.MOVH_BFENTERWAREHCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BFENTERWAREHCODERF" ) );
                    frePStockMoveSlipWork.MOVH_BFENTERWAREHNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BFENTERWAREHNAMERF" ) );
                    frePStockMoveSlipWork.MOVH_AFSECTIONCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "AFSECTIONCODERF" ) );
                    frePStockMoveSlipWork.MOVH_AFSECTIONGUIDESNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "AFSECTIONGUIDESNMRF" ) );
                    frePStockMoveSlipWork.MOVH_AFENTERWAREHCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "AFENTERWAREHCODERF" ) );
                    frePStockMoveSlipWork.MOVH_AFENTERWAREHNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "AFENTERWAREHNAMERF" ) );
                    frePStockMoveSlipWork.MOVH_SHIPMENTSCDLDAYRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SHIPMENTSCDLDAYRF" ) );
                    frePStockMoveSlipWork.MOVH_INPUTDAYRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "INPUTDAYRF" ) );
                    frePStockMoveSlipWork.MOVH_STOCKMVEMPCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STOCKMVEMPCODERF" ) );
                    frePStockMoveSlipWork.MOVH_STOCKMVEMPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STOCKMVEMPNAMERF" ) );
                    frePStockMoveSlipWork.MOVH_SHIPAGENTCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SHIPAGENTCDRF" ) );
                    frePStockMoveSlipWork.MOVH_SHIPAGENTNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SHIPAGENTNMRF" ) );
                    frePStockMoveSlipWork.MOVH_RECEIVEAGENTCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "RECEIVEAGENTCDRF" ) );
                    frePStockMoveSlipWork.MOVH_RECEIVEAGENTNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "RECEIVEAGENTNMRF" ) );
                    frePStockMoveSlipWork.MOVH_OUTLINERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OUTLINERF" ) );
                    frePStockMoveSlipWork.MOVH_WAREHOUSENOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSENOTE1RF" ) );
                    frePStockMoveSlipWork.MOVH_SLIPPRINTFINISHCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SLIPPRINTFINISHCDRF" ) );
                    frePStockMoveSlipWork.SEC1_SECTIONGUIDENMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SEC1SECTIONGUIDENMRF" ) );
                    frePStockMoveSlipWork.SEC1_COMPANYNAMECD1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SEC1COMPANYNAMECD1RF" ) );
                    frePStockMoveSlipWork.SEC2_SECTIONGUIDENMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SEC2SECTIONGUIDENMRF" ) );
                    frePStockMoveSlipWork.SEC2_COMPANYNAMECD1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SEC2COMPANYNAMECD1RF" ) );
                    frePStockMoveSlipWork.COMPANYINFRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYNAME1RF" ) );
                    frePStockMoveSlipWork.COMPANYINFRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYNAME2RF" ) );
                    frePStockMoveSlipWork.COMPANYINFRF_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "POSTNORF" ) );
                    frePStockMoveSlipWork.COMPANYINFRF_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS1RF" ) );
                    frePStockMoveSlipWork.COMPANYINFRF_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS3RF" ) );
                    frePStockMoveSlipWork.COMPANYINFRF_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS4RF" ) );
                    frePStockMoveSlipWork.COMPANYINFRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO1RF" ) );
                    frePStockMoveSlipWork.COMPANYINFRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO2RF" ) );
                    frePStockMoveSlipWork.COMPANYINFRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO3RF" ) );
                    frePStockMoveSlipWork.COMPANYINFRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE1RF" ) );
                    frePStockMoveSlipWork.COMPANYINFRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE2RF" ) );
                    frePStockMoveSlipWork.COMPANYINFRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE3RF" ) );
                    frePStockMoveSlipWork.CMP1_COMPANYPRRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1COMPANYPRRF" ) );
                    frePStockMoveSlipWork.CMP1_COMPANYNAME1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1COMPANYNAME1RF" ) );
                    frePStockMoveSlipWork.CMP1_COMPANYNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1COMPANYNAME2RF" ) );
                    frePStockMoveSlipWork.CMP1_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1POSTNORF" ) );
                    frePStockMoveSlipWork.CMP1_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1ADDRESS1RF" ) );
                    frePStockMoveSlipWork.CMP1_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1ADDRESS3RF" ) );
                    frePStockMoveSlipWork.CMP1_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1ADDRESS4RF" ) );
                    frePStockMoveSlipWork.CMP1_COMPANYTELNO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1COMPANYTELNO1RF" ) );
                    frePStockMoveSlipWork.CMP1_COMPANYTELNO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1COMPANYTELNO2RF" ) );
                    frePStockMoveSlipWork.CMP1_COMPANYTELNO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1COMPANYTELNO3RF" ) );
                    frePStockMoveSlipWork.CMP1_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1COMPANYTELTITLE1RF" ) );
                    frePStockMoveSlipWork.CMP1_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1COMPANYTELTITLE2RF" ) );
                    frePStockMoveSlipWork.CMP1_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1COMPANYTELTITLE3RF" ) );
                    frePStockMoveSlipWork.CMP1_TRANSFERGUIDANCERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1TRANSFERGUIDANCERF" ) );
                    frePStockMoveSlipWork.CMP1_ACCOUNTNOINFO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1ACCOUNTNOINFO1RF" ) );
                    frePStockMoveSlipWork.CMP1_ACCOUNTNOINFO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1ACCOUNTNOINFO2RF" ) );
                    frePStockMoveSlipWork.CMP1_ACCOUNTNOINFO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1ACCOUNTNOINFO3RF" ) );
                    frePStockMoveSlipWork.CMP1_COMPANYSETNOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1COMPANYSETNOTE1RF" ) );
                    frePStockMoveSlipWork.CMP1_COMPANYSETNOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1COMPANYSETNOTE2RF" ) );
                    frePStockMoveSlipWork.CMP1_IMAGEINFODIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CMP1IMAGEINFODIVRF" ) );
                    frePStockMoveSlipWork.CMP1_IMAGEINFOCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CMP1IMAGEINFOCODERF" ) );
                    frePStockMoveSlipWork.CMP1_COMPANYURLRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1COMPANYURLRF" ) );
                    frePStockMoveSlipWork.CMP1_COMPANYPRSENTENCE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1COMPANYPRSENTENCE2RF" ) );
                    frePStockMoveSlipWork.CMP1_IMAGECOMMENTFORPRT1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1IMAGECOMMENTFORPRT1RF" ) );
                    frePStockMoveSlipWork.CMP1_IMAGECOMMENTFORPRT2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP1IMAGECOMMENTFORPRT2RF" ) );
                    frePStockMoveSlipWork.CMP2_COMPANYPRRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2COMPANYPRRF" ) );
                    frePStockMoveSlipWork.CMP2_COMPANYNAME1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2COMPANYNAME1RF" ) );
                    frePStockMoveSlipWork.CMP2_COMPANYNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2COMPANYNAME2RF" ) );
                    frePStockMoveSlipWork.CMP2_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2POSTNORF" ) );
                    frePStockMoveSlipWork.CMP2_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2ADDRESS1RF" ) );
                    frePStockMoveSlipWork.CMP2_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2ADDRESS3RF" ) );
                    frePStockMoveSlipWork.CMP2_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2ADDRESS4RF" ) );
                    frePStockMoveSlipWork.CMP2_COMPANYTELNO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2COMPANYTELNO1RF" ) );
                    frePStockMoveSlipWork.CMP2_COMPANYTELNO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2COMPANYTELNO2RF" ) );
                    frePStockMoveSlipWork.CMP2_COMPANYTELNO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2COMPANYTELNO3RF" ) );
                    frePStockMoveSlipWork.CMP2_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2COMPANYTELTITLE1RF" ) );
                    frePStockMoveSlipWork.CMP2_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2COMPANYTELTITLE2RF" ) );
                    frePStockMoveSlipWork.CMP2_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2COMPANYTELTITLE3RF" ) );
                    frePStockMoveSlipWork.CMP2_TRANSFERGUIDANCERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2TRANSFERGUIDANCERF" ) );
                    frePStockMoveSlipWork.CMP2_ACCOUNTNOINFO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2ACCOUNTNOINFO1RF" ) );
                    frePStockMoveSlipWork.CMP2_ACCOUNTNOINFO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2ACCOUNTNOINFO2RF" ) );
                    frePStockMoveSlipWork.CMP2_ACCOUNTNOINFO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2ACCOUNTNOINFO3RF" ) );
                    frePStockMoveSlipWork.CMP2_COMPANYSETNOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2COMPANYSETNOTE1RF" ) );
                    frePStockMoveSlipWork.CMP2_COMPANYSETNOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2COMPANYSETNOTE2RF" ) );
                    frePStockMoveSlipWork.CMP2_COMPANYURLRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2COMPANYURLRF" ) );
                    frePStockMoveSlipWork.CMP2_COMPANYPRSENTENCE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2COMPANYPRSENTENCE2RF" ) );
                    frePStockMoveSlipWork.CMP2_IMAGECOMMENTFORPRT1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2IMAGECOMMENTFORPRT1RF" ) );
                    frePStockMoveSlipWork.CMP2_IMAGECOMMENTFORPRT2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMP2IMAGECOMMENTFORPRT2RF" ) );
                    frePStockMoveSlipWork.EMP1_KANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EMP1KANARF" ) );
                    frePStockMoveSlipWork.EMP1_SHORTNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EMP1SHORTNAMERF" ) );
                    frePStockMoveSlipWork.EMP2_KANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EMP2KANARF" ) );
                    frePStockMoveSlipWork.EMP2_SHORTNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EMP2SHORTNAMERF" ) );
                    frePStockMoveSlipWork.EMP3_KANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EMP3KANARF" ) );
                    frePStockMoveSlipWork.EMP3_SHORTNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EMP3SHORTNAMERF" ) );
                    frePStockMoveSlipWork.IMAGEINFORF_IMAGEINFODATARF = SqlDataMediator.SqlGetBinaly( myReader, myReader.GetOrdinal( "IMAGEINFODATARF" ) );
                    frePStockMoveSlipWork.MOVH_UPDATESECCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MOVHUPDATESECCDRF" ) );
                    frePStockMoveSlipWork.SEC0_SECTIONGUIDESNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SEC0SECTIONGUIDESNMRF" ) );
                    frePStockMoveSlipWork.SEC0_SECTIONGUIDENMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SEC0SECTIONGUIDENMRF" ) );
                    # endregion

                    frePStockMoveSlipWorkList.Add( frePStockMoveSlipWork );
                }

                if ( frePStockMoveSlipWorkList.Count > 0 ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                retObj = frePStockMoveSlipWorkList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }
            return status;
        }
        # endregion

        # region [在庫移動明細データ抽出]
        /// <summary>
        /// 在庫移動明細データ抽出
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="frePStockMoveSlipRetWorkList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchProcOfDetail( FrePStockMoveSlipParaWork extPrm, out Dictionary<Int32,List<FrePStockMoveDetailWork>> retObj, SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;

            Dictionary<Int32, List<FrePStockMoveDetailWork>> detailListDic = new Dictionary<Int32, List<FrePStockMoveDetailWork>>();
            retObj = null;

            try
            {
                //-------------------------------------------------------------------
                // 対象テーブル
                //   在庫移動データ② StockMoveRF As MOVD
                //     メーカーマスタ MakerURF
                //     商品マスタ GoodsURF As GDS
                //     在庫マスタ① StockRF As STC1
                //     在庫マスタ② StockRF As STC2
                //     仕入先マスタ SupplierRF As SUP
                //     ＢＬコードマスタ BLGoodsCdURF
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand( "SELECT " + this.GetSelectItemsForDetail( extPrm )
                    + Environment.NewLine
                    + " FROM STOCKMOVERF AS MOVD " + Environment.NewLine
                    + LeftJoin( "MOVD", "MAKERURF", string.Empty, new string[] { "GOODSMAKERCDRF" }, new string[] { } )    // 企業cd,ﾒｰｶｰcd
                    + LeftJoin( "MOVD", "GOODSURF", "GDS", new string[] { "GOODSNORF", "GOODSMAKERCDRF" }, new string[] { } )    // 企業cd,商品番号,ﾒｰｶｰcd
                    + LeftJoin( "MOVD", "STOCKRF", "STC1", new string[] { "GOODSNORF", "GOODSMAKERCDRF" }, new string[] { "MOVD.BFENTERWAREHCODERF=STC1.WAREHOUSECODERF" } )    // 企業cd,商品番号,ﾒｰｶｰcd,倉庫cd
                    + LeftJoin( "MOVD", "STOCKRF", "STC2", new string[] { "GOODSNORF", "GOODSMAKERCDRF" }, new string[] { "MOVD.BFENTERWAREHCODERF=STC2.WAREHOUSECODERF" } )    // 企業cd,商品番号,ﾒｰｶｰcd,倉庫cd
                    + LeftJoin( "MOVD", "SUPPLIERRF", "SUP", new string[] { "SUPPLIERCDRF" }, new string[] { } )    // 企業cd,仕入先cd
                    + LeftJoin( "MOVD", "BLGOODSCDURF", string.Empty, new string[] { "BLGOODSCODERF" }, new string[] { } )    // 企業cd,BLcd
                    , sqlConnection );

                // WHERE文を生成
                sqlCommand.CommandText += MakeWhereStringForDetail( ref sqlCommand, extPrm );
                // OrderBy句を生成
                sqlCommand.CommandText += " ORDER BY MOVDSTOCKMOVEFORMALRF, MOVDSTOCKMOVESLIPNORF, MOVDSTOCKMOVEROWNORF " + Environment.NewLine;

                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut( RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide );

                myReader = sqlCommand.ExecuteReader();

                while ( myReader.Read() )
                {
                    FrePStockMoveDetailWork frePStockMoveDetailWork = new FrePStockMoveDetailWork();

                    # region [データのコピー]
                    frePStockMoveDetailWork.MOVD_STOCKMOVEFORMALRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MOVDSTOCKMOVEFORMALRF" ) );
                    frePStockMoveDetailWork.MOVD_STOCKMOVESLIPNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MOVDSTOCKMOVESLIPNORF" ) );
                    frePStockMoveDetailWork.MOVD_STOCKMOVEROWNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MOVDSTOCKMOVEROWNORF" ) );
                    frePStockMoveDetailWork.MOVD_BFSECTIONCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MOVDBFSECTIONCODERF" ) );
                    frePStockMoveDetailWork.MOVD_BFENTERWAREHCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MOVDBFENTERWAREHCODERF" ) );
                    frePStockMoveDetailWork.MOVD_AFSECTIONCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MOVDAFSECTIONCODERF" ) );
                    frePStockMoveDetailWork.MOVD_AFENTERWAREHCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MOVDAFENTERWAREHCODERF" ) );
                    frePStockMoveDetailWork.MOVD_SUPPLIERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MOVDSUPPLIERCDRF" ) );
                    frePStockMoveDetailWork.MOVD_SUPPLIERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MOVDSUPPLIERSNMRF" ) );
                    frePStockMoveDetailWork.MOVD_GOODSMAKERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MOVDGOODSMAKERCDRF" ) );
                    frePStockMoveDetailWork.MOVD_MAKERNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MOVDMAKERNAMERF" ) );
                    frePStockMoveDetailWork.MOVD_GOODSNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MOVDGOODSNORF" ) );
                    frePStockMoveDetailWork.MOVD_GOODSNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MOVDGOODSNAMERF" ) );
                    frePStockMoveDetailWork.MOVD_GOODSNAMEKANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MOVDGOODSNAMEKANARF" ) );
                    frePStockMoveDetailWork.MOVD_STOCKDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MOVDSTOCKDIVRF" ) );
                    frePStockMoveDetailWork.MOVD_STOCKUNITPRICEFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "MOVDSTOCKUNITPRICEFLRF" ) );
                    frePStockMoveDetailWork.MOVD_TAXATIONDIVCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MOVDTAXATIONDIVCDRF" ) );
                    frePStockMoveDetailWork.MOVD_MOVECOUNTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "MOVDMOVECOUNTRF" ) );
                    frePStockMoveDetailWork.MOVD_BFSHELFNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MOVDBFSHELFNORF" ) );
                    frePStockMoveDetailWork.MOVD_AFSHELFNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MOVDAFSHELFNORF" ) );
                    frePStockMoveDetailWork.MOVD_BLGOODSCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MOVDBLGOODSCODERF" ) );
                    frePStockMoveDetailWork.MOVD_BLGOODSFULLNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MOVDBLGOODSFULLNAMERF" ) );
                    frePStockMoveDetailWork.MOVD_LISTPRICEFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "MOVDLISTPRICEFLRF" ) );
                    frePStockMoveDetailWork.MOVD_MOVESTATUSRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MOVDMOVESTATUSRF" ) );
                    frePStockMoveDetailWork.BLGOODSCDURF_BLGOODSHALFNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BLGOODSHALFNAMERF" ) );
                    frePStockMoveDetailWork.MAKERURF_MAKERSHORTNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERSHORTNAMERF" ) );
                    frePStockMoveDetailWork.MAKERURF_MAKERKANANAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERKANANAMERF" ) );
                    frePStockMoveDetailWork.STC1_DUPLICATIONSHELFNO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STC1DUPLICATIONSHELFNO1RF" ) );
                    frePStockMoveDetailWork.STC1_DUPLICATIONSHELFNO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STC1DUPLICATIONSHELFNO2RF" ) );
                    frePStockMoveDetailWork.STC1_PARTSMANAGEMENTDIVIDE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STC1PARTSMANAGEMENTDIVIDE1RF" ) );
                    frePStockMoveDetailWork.STC1_PARTSMANAGEMENTDIVIDE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STC1PARTSMANAGEMENTDIVIDE2RF" ) );
                    frePStockMoveDetailWork.STC1_STOCKNOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STC1STOCKNOTE1RF" ) );
                    frePStockMoveDetailWork.STC1_STOCKNOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STC1STOCKNOTE2RF" ) );
                    frePStockMoveDetailWork.STC1_SHIPMENTPOSCNTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "STC1SHIPMENTPOSCNTRF" ) );
                    frePStockMoveDetailWork.STC2_DUPLICATIONSHELFNO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STC2DUPLICATIONSHELFNO1RF" ) );
                    frePStockMoveDetailWork.STC2_DUPLICATIONSHELFNO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STC2DUPLICATIONSHELFNO2RF" ) );
                    frePStockMoveDetailWork.STC2_PARTSMANAGEMENTDIVIDE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STC2PARTSMANAGEMENTDIVIDE1RF" ) );
                    frePStockMoveDetailWork.STC2_PARTSMANAGEMENTDIVIDE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STC2PARTSMANAGEMENTDIVIDE2RF" ) );
                    frePStockMoveDetailWork.STC2_STOCKNOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STC2STOCKNOTE1RF" ) );
                    frePStockMoveDetailWork.STC2_STOCKNOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STC2STOCKNOTE2RF" ) );
                    frePStockMoveDetailWork.STC2_SHIPMENTPOSCNTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "STC2SHIPMENTPOSCNTRF" ) );
                    frePStockMoveDetailWork.SUP_SUPPLIERNM1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPSUPPLIERNM1RF" ) );
                    frePStockMoveDetailWork.SUP_SUPPLIERNM2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPSUPPLIERNM2RF" ) );
                    frePStockMoveDetailWork.SUP_SUPPHONORIFICTITLERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPSUPPHONORIFICTITLERF" ) );
                    frePStockMoveDetailWork.SUP_SUPPLIERKANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPSUPPLIERKANARF" ) );
                    frePStockMoveDetailWork.SUP_PURECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUPPURECODERF" ) );
                    frePStockMoveDetailWork.SUP_SUPPLIERNOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPSUPPLIERNOTE1RF" ) );
                    frePStockMoveDetailWork.SUP_SUPPLIERNOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPSUPPLIERNOTE2RF" ) );
                    frePStockMoveDetailWork.SUP_SUPPLIERNOTE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPSUPPLIERNOTE3RF" ) );
                    frePStockMoveDetailWork.SUP_SUPPLIERNOTE4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPSUPPLIERNOTE4RF" ) );
                    frePStockMoveDetailWork.GDS_GOODSNAMEKANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GDSGOODSNAMEKANARF" ) );
                    frePStockMoveDetailWork.GDS_JANRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GDSJANRF" ) );
                    frePStockMoveDetailWork.GDS_GOODSRATERANKRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GDSGOODSRATERANKRF" ) );
                    frePStockMoveDetailWork.GDS_GOODSNONONEHYPHENRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GDSGOODSNONONEHYPHENRF" ) );
                    frePStockMoveDetailWork.GDS_GOODSNOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GDSGOODSNOTE1RF" ) );
                    frePStockMoveDetailWork.GDS_GOODSNOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GDSGOODSNOTE2RF" ) );
                    frePStockMoveDetailWork.GDS_GOODSSPECIALNOTERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GDSGOODSSPECIALNOTERF" ) );
                    frePStockMoveDetailWork.MOVD_STOCKMOVEPRICERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "MOVDSTOCKMOVEPRICERF" ) );
                    # endregion

                    // 同一伝票番号のリストが存在しなければ追加
                    if ( !detailListDic.ContainsKey( frePStockMoveDetailWork.MOVD_STOCKMOVESLIPNORF ) )
                    {
                        detailListDic.Add( frePStockMoveDetailWork.MOVD_STOCKMOVESLIPNORF, new List<FrePStockMoveDetailWork>() );
                    }
                    // レコード追加
                    detailListDic[frePStockMoveDetailWork.MOVD_STOCKMOVESLIPNORF].Add( frePStockMoveDetailWork );
                }

                if ( detailListDic.Count > 0 ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                retObj = detailListDic;
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR );
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if ( myReader != null )
                {
                    if ( !myReader.IsClosed )
                        myReader.Close();
                }
            }
            return status;
        }

        # endregion

        # region [自動生成系処理]
        /// <summary>
        /// LeftJoin生成処理
        /// </summary>
        /// <param name="leftTable">左テーブル</param>
        /// <param name="rightTable">右テーブル</param>
        /// <param name="items">一致条件項目リスト</param>
        /// <param name="andMore">追加条件リスト</param>
        /// <returns>LEFT JOIN 文</returns>
        private string LeftJoin( string leftTable, string rightTable, string rightAs, string[] items, string[] andMore )
        {
            StringBuilder sb = new StringBuilder();

            // LEFT JOIN
            if ( rightAs == string.Empty )
            {
                sb.Append( string.Format( "  LEFT JOIN {0} ON ", rightTable ) );
                rightAs = rightTable;
            }
            else
            {
                sb.Append( string.Format( "  LEFT JOIN {0} AS {1} ON ", rightTable, rightAs ) );
            }

            // 企業コードは必須
            sb.Append( string.Format( "{0}.{2}={1}.{2} ", leftTable, rightAs, "ENTERPRISECODERF" ) );

            // その他Joinの条件
            for ( int index = 0; index < items.Length; index++ )
            {
                sb.Append( string.Format( "AND {0}.{2}={1}.{2} ", leftTable, rightAs, items[index] ) );
            }
            // 追加条件
            for ( int index = 0; index < andMore.Length; index++ )
            {
                sb.Append( string.Format( "AND {0} ", andMore[index] ) );
            }

            // 改行
            sb.Append( Environment.NewLine );

            return sb.ToString();
        }
        /// <summary>
        /// 抽出項目名取得処理
        /// </summary>
        /// <param name="extPrm"></param>
        /// <returns></returns>
        private string GetSelectItemsForSlip( FrePStockMoveSlipParaWork extPrm )
        {
            // 注意：同じテーブルを複数回JOINする場合は、Selectに与える項目名称もAsで別名にする。
            // 　　　最終項目は最後にカンマを付けない事。
            StringBuilder sb = new StringBuilder();
            # region [項目名]
            sb.Append( "MOVH.STOCKMOVEFORMALRF, " + Environment.NewLine );
            sb.Append( "MOVH.STOCKMOVESLIPNORF, " + Environment.NewLine );
            sb.Append( "MOVH.BFSECTIONCODERF, " + Environment.NewLine );
            sb.Append( "MOVH.BFSECTIONGUIDESNMRF, " + Environment.NewLine );
            sb.Append( "MOVH.BFENTERWAREHCODERF, " + Environment.NewLine );
            sb.Append( "MOVH.BFENTERWAREHNAMERF, " + Environment.NewLine );
            sb.Append( "MOVH.AFSECTIONCODERF, " + Environment.NewLine );
            sb.Append( "MOVH.AFSECTIONGUIDESNMRF, " + Environment.NewLine );
            sb.Append( "MOVH.AFENTERWAREHCODERF, " + Environment.NewLine );
            sb.Append( "MOVH.AFENTERWAREHNAMERF, " + Environment.NewLine );
            sb.Append( "MOVH.SHIPMENTSCDLDAYRF, " + Environment.NewLine );
            sb.Append( "MOVH.INPUTDAYRF, " + Environment.NewLine );
            sb.Append( "MOVH.STOCKMVEMPCODERF, " + Environment.NewLine );
            sb.Append( "MOVH.STOCKMVEMPNAMERF, " + Environment.NewLine );
            sb.Append( "MOVH.SHIPAGENTCDRF, " + Environment.NewLine );
            sb.Append( "MOVH.SHIPAGENTNMRF, " + Environment.NewLine );
            sb.Append( "MOVH.RECEIVEAGENTCDRF, " + Environment.NewLine );
            sb.Append( "MOVH.RECEIVEAGENTNMRF, " + Environment.NewLine );
            sb.Append( "MOVH.OUTLINERF, " + Environment.NewLine );
            sb.Append( "MOVH.WAREHOUSENOTE1RF, " + Environment.NewLine );
            sb.Append( "MOVH.SLIPPRINTFINISHCDRF, " + Environment.NewLine );
            sb.Append( "SEC1.SECTIONGUIDENMRF AS SEC1SECTIONGUIDENMRF, " + Environment.NewLine );
            sb.Append( "SEC1.COMPANYNAMECD1RF AS SEC1COMPANYNAMECD1RF, " + Environment.NewLine );
            sb.Append( "SEC2.SECTIONGUIDENMRF AS SEC2SECTIONGUIDENMRF, " + Environment.NewLine );
            sb.Append( "SEC2.COMPANYNAMECD1RF AS SEC2COMPANYNAMECD1RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYNAME1RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYNAME2RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.POSTNORF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.ADDRESS1RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.ADDRESS3RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.ADDRESS4RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELNO1RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELNO2RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELNO3RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELTITLE1RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELTITLE2RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELTITLE3RF, " + Environment.NewLine );
            sb.Append( "CMP1.COMPANYPRRF AS CMP1COMPANYPRRF, " + Environment.NewLine );
            sb.Append( "CMP1.COMPANYNAME1RF AS CMP1COMPANYNAME1RF, " + Environment.NewLine );
            sb.Append( "CMP1.COMPANYNAME2RF AS CMP1COMPANYNAME2RF, " + Environment.NewLine );
            sb.Append( "CMP1.POSTNORF AS CMP1POSTNORF, " + Environment.NewLine );
            sb.Append( "CMP1.ADDRESS1RF AS CMP1ADDRESS1RF, " + Environment.NewLine );
            sb.Append( "CMP1.ADDRESS3RF AS CMP1ADDRESS3RF, " + Environment.NewLine );
            sb.Append( "CMP1.ADDRESS4RF AS CMP1ADDRESS4RF, " + Environment.NewLine );
            sb.Append( "CMP1.COMPANYTELNO1RF AS CMP1COMPANYTELNO1RF, " + Environment.NewLine );
            sb.Append( "CMP1.COMPANYTELNO2RF AS CMP1COMPANYTELNO2RF, " + Environment.NewLine );
            sb.Append( "CMP1.COMPANYTELNO3RF AS CMP1COMPANYTELNO3RF, " + Environment.NewLine );
            sb.Append( "CMP1.COMPANYTELTITLE1RF AS CMP1COMPANYTELTITLE1RF, " + Environment.NewLine );
            sb.Append( "CMP1.COMPANYTELTITLE2RF AS CMP1COMPANYTELTITLE2RF, " + Environment.NewLine );
            sb.Append( "CMP1.COMPANYTELTITLE3RF AS CMP1COMPANYTELTITLE3RF, " + Environment.NewLine );
            sb.Append( "CMP1.TRANSFERGUIDANCERF AS CMP1TRANSFERGUIDANCERF, " + Environment.NewLine );
            sb.Append( "CMP1.ACCOUNTNOINFO1RF AS CMP1ACCOUNTNOINFO1RF, " + Environment.NewLine );
            sb.Append( "CMP1.ACCOUNTNOINFO2RF AS CMP1ACCOUNTNOINFO2RF, " + Environment.NewLine );
            sb.Append( "CMP1.ACCOUNTNOINFO3RF AS CMP1ACCOUNTNOINFO3RF, " + Environment.NewLine );
            sb.Append( "CMP1.COMPANYSETNOTE1RF AS CMP1COMPANYSETNOTE1RF, " + Environment.NewLine );
            sb.Append( "CMP1.COMPANYSETNOTE2RF AS CMP1COMPANYSETNOTE2RF, " + Environment.NewLine );
            sb.Append( "CMP1.IMAGEINFODIVRF AS CMP1IMAGEINFODIVRF, " + Environment.NewLine );
            sb.Append( "CMP1.IMAGEINFOCODERF AS CMP1IMAGEINFOCODERF, " + Environment.NewLine );
            sb.Append( "CMP1.COMPANYURLRF AS CMP1COMPANYURLRF, " + Environment.NewLine );
            sb.Append( "CMP1.COMPANYPRSENTENCE2RF AS CMP1COMPANYPRSENTENCE2RF, " + Environment.NewLine );
            sb.Append( "CMP1.IMAGECOMMENTFORPRT1RF AS CMP1IMAGECOMMENTFORPRT1RF, " + Environment.NewLine );
            sb.Append( "CMP1.IMAGECOMMENTFORPRT2RF AS CMP1IMAGECOMMENTFORPRT2RF, " + Environment.NewLine );
            sb.Append( "CMP2.COMPANYPRRF AS CMP2COMPANYPRRF, " + Environment.NewLine );
            sb.Append( "CMP2.COMPANYNAME1RF AS CMP2COMPANYNAME1RF, " + Environment.NewLine );
            sb.Append( "CMP2.COMPANYNAME2RF AS CMP2COMPANYNAME2RF, " + Environment.NewLine );
            sb.Append( "CMP2.POSTNORF AS CMP2POSTNORF, " + Environment.NewLine );
            sb.Append( "CMP2.ADDRESS1RF AS CMP2ADDRESS1RF, " + Environment.NewLine );
            sb.Append( "CMP2.ADDRESS3RF AS CMP2ADDRESS3RF, " + Environment.NewLine );
            sb.Append( "CMP2.ADDRESS4RF AS CMP2ADDRESS4RF, " + Environment.NewLine );
            sb.Append( "CMP2.COMPANYTELNO1RF AS CMP2COMPANYTELNO1RF, " + Environment.NewLine );
            sb.Append( "CMP2.COMPANYTELNO2RF AS CMP2COMPANYTELNO2RF, " + Environment.NewLine );
            sb.Append( "CMP2.COMPANYTELNO3RF AS CMP2COMPANYTELNO3RF, " + Environment.NewLine );
            sb.Append( "CMP2.COMPANYTELTITLE1RF AS CMP2COMPANYTELTITLE1RF, " + Environment.NewLine );
            sb.Append( "CMP2.COMPANYTELTITLE2RF AS CMP2COMPANYTELTITLE2RF, " + Environment.NewLine );
            sb.Append( "CMP2.COMPANYTELTITLE3RF AS CMP2COMPANYTELTITLE3RF, " + Environment.NewLine );
            sb.Append( "CMP2.TRANSFERGUIDANCERF AS CMP2TRANSFERGUIDANCERF, " + Environment.NewLine );
            sb.Append( "CMP2.ACCOUNTNOINFO1RF AS CMP2ACCOUNTNOINFO1RF, " + Environment.NewLine );
            sb.Append( "CMP2.ACCOUNTNOINFO2RF AS CMP2ACCOUNTNOINFO2RF, " + Environment.NewLine );
            sb.Append( "CMP2.ACCOUNTNOINFO3RF AS CMP2ACCOUNTNOINFO3RF, " + Environment.NewLine );
            sb.Append( "CMP2.COMPANYSETNOTE1RF AS CMP2COMPANYSETNOTE1RF, " + Environment.NewLine );
            sb.Append( "CMP2.COMPANYSETNOTE2RF AS CMP2COMPANYSETNOTE2RF, " + Environment.NewLine );
            sb.Append( "CMP2.COMPANYURLRF AS CMP2COMPANYURLRF, " + Environment.NewLine );
            sb.Append( "CMP2.COMPANYPRSENTENCE2RF AS CMP2COMPANYPRSENTENCE2RF, " + Environment.NewLine );
            sb.Append( "CMP2.IMAGECOMMENTFORPRT1RF AS CMP2IMAGECOMMENTFORPRT1RF, " + Environment.NewLine );
            sb.Append( "CMP2.IMAGECOMMENTFORPRT2RF AS CMP2IMAGECOMMENTFORPRT2RF, " + Environment.NewLine );
            sb.Append( "EMP1.KANARF AS EMP1KANARF, " + Environment.NewLine );
            sb.Append( "EMP1.SHORTNAMERF AS EMP1SHORTNAMERF, " + Environment.NewLine );
            sb.Append( "EMP2.KANARF AS EMP2KANARF, " + Environment.NewLine );
            sb.Append( "EMP2.SHORTNAMERF AS EMP2SHORTNAMERF, " + Environment.NewLine );
            sb.Append( "EMP3.KANARF AS EMP3KANARF, " + Environment.NewLine );
            sb.Append( "EMP3.SHORTNAMERF AS EMP3SHORTNAMERF, " + Environment.NewLine );
            sb.Append( "IMAGEINFORF.IMAGEINFODATARF, " + Environment.NewLine );
            sb.Append( "MOVH.UPDATESECCDRF AS MOVHUPDATESECCDRF, " + Environment.NewLine );
            sb.Append( "SEC0.SECTIONGUIDESNMRF AS SEC0SECTIONGUIDESNMRF, " + Environment.NewLine );
            sb.Append( "SEC0.SECTIONGUIDENMRF AS SEC0SECTIONGUIDENMRF" + Environment.NewLine ); // ←最終項目はカンマなし
            # endregion
            return sb.ToString();
        }
        /// <summary>
        /// WHERE文作成処理
        /// </summary>
        /// <param name="sqlCommand">SQLコマンド</param>
        /// <param name="extPrm">自由帳票共通抽出条件クラス</param>
        /// <returns>WHERE文</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, FrePStockMoveSlipParaWork extPrm)
        {
            StringBuilder whereString = new StringBuilder();
            //SFANL08309CA gene = new SFANL08309CA();

            // 企業コードは必須条件
            whereString.Append( " WHERE MOVH.ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine );
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

            // 移動データはフラットなので伝票毎１行目のみを伝票ヘッダとして抽出する
            whereString.Append( " AND MOVH.STOCKMOVEROWNORF=@FINDSTOCKMOVEROWNO " + Environment.NewLine );
            SqlParameter findStockMoveRowNo = sqlCommand.Parameters.Add( "@FINDSTOCKMOVEROWNO", SqlDbType.Int );
            findStockMoveRowNo.Value = 1;

            // 在庫移動形式と伝票番号
            List<SqlParameter> acptList = new List<SqlParameter>();
            List<SqlParameter> slipNumList = new List<SqlParameter>();

            whereString.Append( " AND ( " );
            for ( int index = 0; index < extPrm.FrePStockMoveSlipParaKeyList.Count; index++ )
            {
                if ( index > 0 )
                {
                    whereString.Append( " OR " );
                }

                // WHERE
                whereString.Append( string.Format( "(MOVH.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL{0} AND MOVH.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO{0})", index ) );

                // 在庫移動形式
                SqlParameter paraFormal = sqlCommand.Parameters.Add( string.Format( "@FINDSTOCKMOVEFORMAL{0}", index ), SqlDbType.Int );
                paraFormal.Value = extPrm.FrePStockMoveSlipParaKeyList[index].StockMoveFormal;
                acptList.Add( paraFormal );

                // 伝票番号
                SqlParameter paraSlipNo = sqlCommand.Parameters.Add( string.Format( "@FINDSTOCKMOVESLIPNO{0}", index ), SqlDbType.NChar );
                paraSlipNo.Value = extPrm.FrePStockMoveSlipParaKeyList[index].StockMoveSlipNo;
                slipNumList.Add( paraSlipNo );

                whereString.Append( Environment.NewLine );
            }
            whereString.Append( " ) " + Environment.NewLine );

            return whereString.ToString();
        }
        /// <summary>
        /// 抽出項目取得処理（明細用）
        /// </summary>
        /// <param name="extPrm"></param>
        /// <returns></returns>
        private string GetSelectItemsForDetail( FrePStockMoveSlipParaWork extPrm )
        {
            // 注意：同じテーブルを複数回JOINする場合は、Selectに与える項目名称もAsで別名にする。
            // 　　　最終項目は最後にカンマを付けない事。
            StringBuilder sb = new StringBuilder();
            # region [項目名]
            sb.Append( "MOVD.STOCKMOVEFORMALRF AS MOVDSTOCKMOVEFORMALRF, " + Environment.NewLine );
            sb.Append( "MOVD.STOCKMOVESLIPNORF AS MOVDSTOCKMOVESLIPNORF, " + Environment.NewLine );
            sb.Append( "MOVD.STOCKMOVEROWNORF AS MOVDSTOCKMOVEROWNORF, " + Environment.NewLine );
            sb.Append( "MOVD.BFSECTIONCODERF AS MOVDBFSECTIONCODERF, " + Environment.NewLine );
            sb.Append( "MOVD.BFENTERWAREHCODERF AS MOVDBFENTERWAREHCODERF, " + Environment.NewLine );
            sb.Append( "MOVD.AFSECTIONCODERF AS MOVDAFSECTIONCODERF, " + Environment.NewLine );
            sb.Append( "MOVD.AFENTERWAREHCODERF AS MOVDAFENTERWAREHCODERF, " + Environment.NewLine );
            sb.Append( "MOVD.SUPPLIERCDRF AS MOVDSUPPLIERCDRF, " + Environment.NewLine );
            sb.Append( "MOVD.SUPPLIERSNMRF AS MOVDSUPPLIERSNMRF, " + Environment.NewLine );
            sb.Append( "MOVD.GOODSMAKERCDRF AS MOVDGOODSMAKERCDRF, " + Environment.NewLine );
            sb.Append( "MOVD.MAKERNAMERF AS MOVDMAKERNAMERF, " + Environment.NewLine );
            sb.Append( "MOVD.GOODSNORF AS MOVDGOODSNORF, " + Environment.NewLine );
            sb.Append( "MOVD.GOODSNAMERF AS MOVDGOODSNAMERF, " + Environment.NewLine );
            sb.Append( "MOVD.GOODSNAMEKANARF AS MOVDGOODSNAMEKANARF, " + Environment.NewLine );
            sb.Append( "MOVD.STOCKDIVRF AS MOVDSTOCKDIVRF, " + Environment.NewLine );
            sb.Append( "MOVD.STOCKUNITPRICEFLRF AS MOVDSTOCKUNITPRICEFLRF, " + Environment.NewLine );
            sb.Append( "MOVD.TAXATIONDIVCDRF AS MOVDTAXATIONDIVCDRF, " + Environment.NewLine );
            sb.Append( "MOVD.MOVECOUNTRF AS MOVDMOVECOUNTRF, " + Environment.NewLine );
            sb.Append( "MOVD.BFSHELFNORF AS MOVDBFSHELFNORF, " + Environment.NewLine );
            sb.Append( "MOVD.AFSHELFNORF AS MOVDAFSHELFNORF, " + Environment.NewLine );
            sb.Append( "MOVD.BLGOODSCODERF AS MOVDBLGOODSCODERF, " + Environment.NewLine );
            sb.Append( "MOVD.BLGOODSFULLNAMERF AS MOVDBLGOODSFULLNAMERF, " + Environment.NewLine );
            sb.Append( "MOVD.LISTPRICEFLRF AS MOVDLISTPRICEFLRF, " + Environment.NewLine );
            sb.Append( "MOVD.MOVESTATUSRF AS MOVDMOVESTATUSRF, " + Environment.NewLine );
            sb.Append( "BLGOODSCDURF.BLGOODSHALFNAMERF, " + Environment.NewLine );
            sb.Append( "MAKERURF.MAKERSHORTNAMERF, " + Environment.NewLine );
            sb.Append( "MAKERURF.MAKERKANANAMERF, " + Environment.NewLine );
            sb.Append( "STC1.DUPLICATIONSHELFNO1RF AS STC1DUPLICATIONSHELFNO1RF, " + Environment.NewLine );
            sb.Append( "STC1.DUPLICATIONSHELFNO2RF AS STC1DUPLICATIONSHELFNO2RF, " + Environment.NewLine );
            sb.Append( "STC1.PARTSMANAGEMENTDIVIDE1RF AS STC1PARTSMANAGEMENTDIVIDE1RF, " + Environment.NewLine );
            sb.Append( "STC1.PARTSMANAGEMENTDIVIDE2RF AS STC1PARTSMANAGEMENTDIVIDE2RF, " + Environment.NewLine );
            sb.Append( "STC1.STOCKNOTE1RF AS STC1STOCKNOTE1RF, " + Environment.NewLine );
            sb.Append( "STC1.STOCKNOTE2RF AS STC1STOCKNOTE2RF, " + Environment.NewLine );
            sb.Append( "STC1.SHIPMENTPOSCNTRF AS STC1SHIPMENTPOSCNTRF, " + Environment.NewLine );
            sb.Append( "STC2.DUPLICATIONSHELFNO1RF AS STC2DUPLICATIONSHELFNO1RF, " + Environment.NewLine );
            sb.Append( "STC2.DUPLICATIONSHELFNO2RF AS STC2DUPLICATIONSHELFNO2RF, " + Environment.NewLine );
            sb.Append( "STC2.PARTSMANAGEMENTDIVIDE1RF AS STC2PARTSMANAGEMENTDIVIDE1RF, " + Environment.NewLine );
            sb.Append( "STC2.PARTSMANAGEMENTDIVIDE2RF AS STC2PARTSMANAGEMENTDIVIDE2RF, " + Environment.NewLine );
            sb.Append( "STC2.STOCKNOTE1RF AS STC2STOCKNOTE1RF, " + Environment.NewLine );
            sb.Append( "STC2.STOCKNOTE2RF AS STC2STOCKNOTE2RF, " + Environment.NewLine );
            sb.Append( "STC2.SHIPMENTPOSCNTRF AS STC2SHIPMENTPOSCNTRF, " + Environment.NewLine );
            sb.Append( "SUP.SUPPLIERNM1RF AS SUPSUPPLIERNM1RF, " + Environment.NewLine );
            sb.Append( "SUP.SUPPLIERNM2RF AS SUPSUPPLIERNM2RF, " + Environment.NewLine );
            sb.Append( "SUP.SUPPHONORIFICTITLERF AS SUPSUPPHONORIFICTITLERF, " + Environment.NewLine );
            sb.Append( "SUP.SUPPLIERKANARF AS SUPSUPPLIERKANARF, " + Environment.NewLine );
            sb.Append( "SUP.PURECODERF AS SUPPURECODERF, " + Environment.NewLine );
            sb.Append( "SUP.SUPPLIERNOTE1RF AS SUPSUPPLIERNOTE1RF, " + Environment.NewLine );
            sb.Append( "SUP.SUPPLIERNOTE2RF AS SUPSUPPLIERNOTE2RF, " + Environment.NewLine );
            sb.Append( "SUP.SUPPLIERNOTE3RF AS SUPSUPPLIERNOTE3RF, " + Environment.NewLine );
            sb.Append( "SUP.SUPPLIERNOTE4RF AS SUPSUPPLIERNOTE4RF, " + Environment.NewLine );
            sb.Append( "GDS.GOODSNAMEKANARF AS GDSGOODSNAMEKANARF, " + Environment.NewLine );
            sb.Append( "GDS.JANRF AS GDSJANRF, " + Environment.NewLine );
            sb.Append( "GDS.GOODSRATERANKRF AS GDSGOODSRATERANKRF, " + Environment.NewLine );
            sb.Append( "GDS.GOODSNONONEHYPHENRF AS GDSGOODSNONONEHYPHENRF, " + Environment.NewLine );
            sb.Append( "GDS.GOODSNOTE1RF AS GDSGOODSNOTE1RF, " + Environment.NewLine );
            sb.Append( "GDS.GOODSNOTE2RF AS GDSGOODSNOTE2RF, " + Environment.NewLine );
            sb.Append( "GDS.GOODSSPECIALNOTERF AS GDSGOODSSPECIALNOTERF," + Environment.NewLine );
            sb.Append( "MOVD.STOCKMOVEPRICERF AS MOVDSTOCKMOVEPRICERF" + Environment.NewLine ); // ←最終項目はカンマなし
            # endregion
            return sb.ToString();
        }
        /// <summary>
        /// WHERE分生成処理（明細用）
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="extPrm"></param>
        /// <returns></returns>
        private string MakeWhereStringForDetail( ref SqlCommand sqlCommand, FrePStockMoveSlipParaWork extPrm )
        {
            StringBuilder whereString = new StringBuilder();
            //SFANL08309CA gene = new SFANL08309CA();

            // 企業コードは必須条件
            whereString.Append( " WHERE MOVD.ENTERPRISECODERF=@FINDENTERPRISECODE " );
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

            // 受注ステータスと伝票番号
            List<SqlParameter> acptList = new List<SqlParameter>();
            List<SqlParameter> slipNumList = new List<SqlParameter>();

            whereString.Append( " AND ( " );
            for ( int index = 0; index < extPrm.FrePStockMoveSlipParaKeyList.Count; index++ )
            {
                if ( index > 0 )
                {
                    whereString.Append( " OR " );
                }

                // WHERE
                whereString.Append( string.Format( "(MOVD.STOCKMOVEFORMALRF=@FINDSTOCKMOVEFORMAL{0} AND MOVD.STOCKMOVESLIPNORF=@FINDSTOCKMOVESLIPNO{0})", index ) );

                // 在庫移動形式
                SqlParameter paraFormal = sqlCommand.Parameters.Add( string.Format( "@FINDSTOCKMOVEFORMAL{0}", index ), SqlDbType.Int );
                paraFormal.Value = extPrm.FrePStockMoveSlipParaKeyList[index].StockMoveFormal;
                acptList.Add( paraFormal );

                // 伝票番号
                SqlParameter paraSlipNum = sqlCommand.Parameters.Add( string.Format( "@FINDSTOCKMOVESLIPNO{0}", index ), SqlDbType.NChar );
                paraSlipNum.Value = extPrm.FrePStockMoveSlipParaKeyList[index].StockMoveSlipNo;
                slipNumList.Add( paraSlipNum );

                whereString.Append( Environment.NewLine );
            }
            whereString.Append( " ) " + Environment.NewLine );

            return whereString.ToString();
        }


        # endregion

        #endregion

    }
}