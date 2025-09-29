//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコード更新リモートオブジェクト
// プログラム概要   : 商品バーコード更新リモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00  作成担当 : 30757 佐々木貴英
// 作 成 日  2017/09/20   修正内容 : ハンディターミナル二次対応（新規作成）
//----------------------------------------------------------------------------//
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
using System.Collections.Generic;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品バーコード更新リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード更新処理の実データ操作を行うクラスの定義と実装</br>
    /// <br>Programmer : 30757　佐々木　貴英</br>
    /// <br>Date       : 2017/09/20</br>
    /// </remarks>
    [Serializable]
    public class PrmGoodsBarCodeRevnUpdateDB : RemoteDB, IRemoteDB, IPrmGoodsBarCodeRevnUpdateDB
    {
        #region 型宣言

        /// <summary>
        /// 抽出クエリ生成処理デリゲート宣言
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="sqlCommand">抽出クエリ実行用オブジェクト</param>
        /// <param name="queryText">クエリ文字列格納オブジェクト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出クエリの生成及びパラメータの設定を行う処理のデリゲート宣言</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        delegate int CreateQueryDelegate( ref object selectParam, SqlCommand sqlCommand, out string queryText );

        /// <summary>
        /// 抽出結果リスト生成処理デリゲート宣言
        /// </summary>
        /// <param name="myReader">抽出結果データストリーム</param>
        /// <returns>抽出結果リスト</returns>
        /// <remarks>
        /// <br>Note       : 抽出結果リストの生成を行う処理のデリゲート宣言</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        delegate object CreateResultDelegate( SqlDataReader myReader );

        #endregion //型宣言

        #region 定数定義

        #region SQL文字列
        private static readonly string GetPrmPartsInfoListQuery = @"SELECT
             PRMSET.ENTERPRISECODERF
            ,PRMSET.PARTSMAKERCDRF
            ,PRMSET.TBSPARTSCODERF
        FROM 
            dbo.PRMSETTINGURF AS PRMSET WITH (READUNCOMMITTED)
            LEFT JOIN dbo.BLGOODSCDURF AS BLCD WITH (READUNCOMMITTED)
              ON BLCD.ENTERPRISECODERF = PRMSET.ENTERPRISECODERF
                 AND BLCD.BLGOODSCODERF = PRMSET.TBSPARTSCODERF
                 AND BLCD.LOGICALDELETECODERF = 0
        WHERE 
            PRMSET.ENTERPRISECODERF = @FINDENTERPRISECODE
            AND (
                --部品メーカーコード開始
                @FINDMAKERCODEST = 0
                OR PRMSET.PARTSMAKERCDRF >= @FINDMAKERCODEST
            ) AND (
                --部品メーカーコード終了
                @FINDMAKERCODEED = 0
                OR PRMSET.PARTSMAKERCDRF <= @FINDMAKERCODEED
            ) AND (
                --商品中分類コード
                @FINDGOODSMGROUP = 0
                OR ( BLCD.GOODSRATEGRPCODERF IS NOT NULL AND BLCD.GOODSRATEGRPCODERF = @FINDGOODSMGROUP )
            ) AND (
                --BLコード
                @FINDBLGOODSCODE = 0
                OR ( PRMSET.TBSPARTSCODERF IS NOT NULL AND PRMSET.TBSPARTSCODERF = @FINDBLGOODSCODE )
            ) 
        GROUP BY PRMSET.ENTERPRISECODERF,PRMSET.TBSPARTSCODERF,PRMSET.PARTSMAKERCDRF,BLCD.GOODSRATEGRPCODERF
        ORDER BY PRMSET.PARTSMAKERCDRF,PRMSET.TBSPARTSCODERF
        ";

        /// <summary>
        /// 抽出件数取得SELECT句
        /// </summary>
        private static readonly string SelectCountQuery = "SELECT \n    COUNT(*) AS SELECTCOUNT\n";

        /// <summary>
        /// 情報抽出SELECT句
        /// </summary>
        private static readonly string SelectQuery = @"SELECT
             BRCD.CREATEDATETIMERF
            ,BRCD.UPDATEDATETIMERF
            ,BRCD.ENTERPRISECODERF
            ,BRCD.FILEHEADERGUIDRF
            ,BRCD.UPDEMPLOYEECODERF
            ,BRCD.UPDASSEMBLYID1RF
            ,BRCD.UPDASSEMBLYID2RF
            ,BRCD.LOGICALDELETECODERF
            ,BRCD.GOODSMAKERCDRF
            ,BRCD.GOODSNORF
            ,BRCD.GOODSBARCODERF
            ,BRCD.GOODSBARCODEKINDRF
            ,BRCD.CHECKDIGITCODERF
            ,BRCD.OFFERDATERF
            ,BRCD.OFFERDATADIVRF
        ";

        /// <summary>
        /// 抽出件数取得及び情報抽出共通FROM句
        /// </summary>
        private static readonly string FromQuery = @"FROM 
            dbo.GOODSBARCODEREVNRF AS BRCD WITH (READUNCOMMITTED)
            LEFT JOIN dbo.GOODSURF AS GOODS WITH (READUNCOMMITTED)
              ON GOODS.ENTERPRISECODERF = BRCD.ENTERPRISECODERF
                 AND GOODS.GOODSMAKERCDRF = BRCD.GOODSMAKERCDRF
                 AND GOODS.GOODSNORF = BRCD.GOODSNORF
                 AND GOODS.LOGICALDELETECODERF = 0
        ";

        /// <summary>
        /// 抽出件数取得及び情報抽出共通WHERE句
        /// </summary>
        private static readonly string WhereBase = "WHERE \n    BRCD.ENTERPRISECODERF = @FINDENTERPRISECODE";

        /// <summary>
        /// 抽出件数取得及び情報抽出共通WHERE句AND条件開始
        /// </summary>
        private static readonly string WhereAndSymbolStart = "    AND (";

        /// <summary>
        /// WHERE句先頭条件書式
        /// </summary>
        private static readonly string WhereFormatTop = "       (BRCD.GOODSMAKERCDRF = {0} AND GOODS.BLGOODSCODERF = {1})";

        /// <summary>
        /// WHERE句先頭以降条件書式
        /// </summary>
        private static readonly string WhereFormat = "    OR (BRCD.GOODSMAKERCDRF = {0} AND GOODS.BLGOODSCODERF = {1})";

        /// <summary>
        /// 抽出件数取得及び情報抽出共通WHERE句AND条件終了
        /// </summary>
        private static readonly string WhereAndSymbolEnd = "    )";

        /// <summary>
        /// 抽出件数取得及び情報抽出共通ORDER BY句
        /// </summary>
        private static readonly string OrderBySymbol = "ORDER BY BRCD.GOODSMAKERCDRF,BRCD.GOODSNORF";

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）レコード読み込みクエリ生成
        /// </summary>
        private static readonly string ReadQuery = @"SELECT 
             CREATEDATETIMERF
            ,UPDATEDATETIMERF
            ,ENTERPRISECODERF
            ,FILEHEADERGUIDRF
            ,UPDEMPLOYEECODERF
            ,UPDASSEMBLYID1RF
            ,UPDASSEMBLYID2RF
            ,LOGICALDELETECODERF
            ,GOODSMAKERCDRF
            ,GOODSNORF
            ,GOODSBARCODERF
            ,GOODSBARCODEKINDRF
            ,CHECKDIGITCODERF
            ,OFFERDATERF
            ,OFFERDATADIVRF
        FROM 
            GOODSBARCODEREVNRF WITH (READUNCOMMITTED)
        WHERE 
            ENTERPRISECODERF = @FINDENTERPRISECODE
            AND GOODSMAKERCDRF = @FINDMAKERCODE
            AND GOODSNORF = @FINDGOODSNO
        ";

        private static readonly string WriteQuery = @"UPDATE dbo.GOODSBARCODEREVNRF
        SET 
             UPDATEDATETIMERF = @SETUPDATEDATETIME
            ,UPDEMPLOYEECODERF = @SETUPDEMPLOYEECODE
            ,UPDASSEMBLYID1RF = @SETUPDASSEMBLYID1
            ,UPDASSEMBLYID2RF = @SETUPDASSEMBLYID2
            ,GOODSBARCODERF = @SETGOODSBARCODE
            ,GOODSBARCODEKINDRF = @SETGOODSBARCODEKIND
            ,CHECKDIGITCODERF = 0
            ,OFFERDATERF = @SETOFFERDATE
            ,OFFERDATADIVRF = @SETOFFERDATADIV
        WHERE
            ENTERPRISECODERF = @FINDENTERPRISECODE
            AND GOODSMAKERCDRF = @FINDMAKERCODE
            AND GOODSNORF = @FINDGOODSNO
        ";

        private static readonly string InsertQuery = @"INSERT INTO dbo.GOODSBARCODEREVNRF (
             CREATEDATETIMERF
            ,UPDATEDATETIMERF
            ,ENTERPRISECODERF
            ,FILEHEADERGUIDRF
            ,UPDEMPLOYEECODERF
            ,UPDASSEMBLYID1RF
            ,UPDASSEMBLYID2RF
            ,LOGICALDELETECODERF
            ,GOODSMAKERCDRF
            ,GOODSNORF
            ,GOODSBARCODERF
            ,GOODSBARCODEKINDRF
            ,CHECKDIGITCODERF
            ,OFFERDATERF
            ,OFFERDATADIVRF
        ) VALUES (
             @SETCREATEDATETIME
            ,@SETUPDATEDATETIME
            ,@SETENTERPRISECODE
            ,@SETFILEHEADERGUID
            ,@SETUPDEMPLOYEECODE
            ,@SETUPDASSEMBLYID1
            ,@SETUPDASSEMBLYID2
            ,@SETLOGICALDELETECODE
            ,@SETGOODSMAKERCD
            ,@SETGOODSNO
            ,@SETGOODSBARCODE
            ,@SETGOODSBARCODEKIND
            ,@SETCHECKDIGITCODE
            ,@SETOFFERDATE
            ,@SETOFFERDATADIV
        )
        ";
        #endregion //SQL文字列

        /// <summary>
        /// SQL実行時タイムアウト規定値(3600秒)
        /// </summary>
        private const int SqlCommandTimeoutDefault = 3600;

        #region エラーメッセージ

        /// <summary>
        /// エラーメッセージ：優良設定マスタ検索で例外発生
        /// </summary>
        private static readonly string ErrorTextGetPrmPartsInfoListQueryFaild = "優良設定マスタ検索で例外が発生しました。";

        /// <summary>
        /// エラーメッセージ：商品バーコード関連付けマスタ（ユーザーデータ）情報抽出件数取得で例外発生
        /// </summary>
        private static readonly string ErrorTextGetSearchCountFaild = "商品バーコード関連付けマスタ（ユーザーデータ）情報抽出件数取得で例外が発生しました。";

        /// <summary>
        /// エラーメッセージ：商品バーコード関連付けマスタ（ユーザーデータ）情報抽出で例外発生
        /// </summary>
        private static readonly string ErrorTextSearchFaild = "商品バーコード関連付けマスタ（ユーザーデータ）情報抽出処理で例外が発生しました。";

        private static readonly string ErrorTextUpdateGoodsBarcodeRevnProcFaild = "商品バーコード関連付けマスタ（ユーザーデータ）更新処理で例外が発生しました。";

        /// <summary>
        ///  エラーメッセージ：商品バーコード関連付けマスタ（ユーザーデータ）更新パラメータ不正
        /// </summary>
        private static readonly string ErrorTextIlligalParameter = "[Index番号:{0}]の更新パラメータが空かGoodsBarCodeRevnWork型ではありません。";

        /// <summary>
        ///  エラーメッセージ：商品バーコード関連付けマスタ（ユーザーデータ）レコード取得エラー
        /// </summary>
        private static readonly string ErrorTextReadGoodsBarCodeRevnFaild = "[メーカーコード:{0}、商品番号:{1}の 商品バーコード関連付けマスタ（ユーザーデータ）レコード取得に失敗しました";

        /// <summary>
        ///  エラーメッセージ：商品バーコード関連付けマスタ（ユーザーデータ）レコード更新競合
        /// </summary>
        private static readonly string ErrorTextAlrdyUpdate = "[メーカーコード:{0}、商品番号:{1}の 商品バーコード関連付けマスタ（ユーザーデータ）レコードは他の端末で更新されています。";

        /// <summary>
        ///  エラーメッセージ：商品バーコード関連付けマスタ（ユーザーデータ）更新失敗
        /// </summary>
        private static readonly string ErrorTextUpdateProcFaild = "[メーカーコード:{0}、商品番号:{1}の 商品バーコード関連付けマスタ（ユーザーデータ）レコード登録に失敗しました";

        #endregion //エラーメッセージ

        #endregion //定数定義

        #region プライベートフィールド

        /// <summary>
        /// 操作ログ登録リモート
        /// </summary>
        private OprtnHisLogDB OperationLoggingDB = null;

        #endregion プライベートフィールド

        #region コンストラクタ

        /// <summary>
        /// 商品バーコード更新リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品バーコード更新リモートオブジェクトクラスのインスタンスを生成</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// </remarks>
        public PrmGoodsBarCodeRevnUpdateDB()
            :
        base( "PMHND09216D", "Broadleaf.Application.Remoting.ParamData.GoodsBarCodeRevnWork", "GOODSBARCODEREVNRF" )
        {
        }

        #endregion //コンストラクタ

        #region IPrmGoodsBarCodeRevnUpdateDB メンバ

        /// <summary>
        /// 優良設定マスタ検索処理
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="getPrmPartsBrcdParaList">更新対象優良設定リスト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する更新対象優良設定を取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        public int GetPrmPartsInfoList( ref PrmSetUParamForBrcdWork selectParam, out object getPrmPartsBrcdParaList )
        {
            return this.GetPrmPartsInfoListProc( selectParam, out getPrmPartsBrcdParaList );
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）抽出件数取得
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="retCnt">抽出件数</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する商品バーコード関連付けマスタ（ユーザーデータ）を取得した場合の件数を取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        public int GetSearchCount( ref object selectParam, out int retCnt )
        {
            return this.GetSearchCountProc( selectParam, out retCnt );
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）抽出
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="prmPartsBrcdInfoList">抽出結果</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する商品バーコード関連付けマスタ（ユーザーデータ）を取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        public int Search( ref object selectParam, out object prmPartsBrcdInfoList )
        {
            return this.SearchProc( selectParam, out prmPartsBrcdInfoList );
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）更新
        /// </summary>
        /// <param name="updateList">更新リスト</param>
        /// <param name="updateCount">処理件数</param>
        /// <param name="barcodeUpdateKndDiv">バーコード更新区分</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ（ユーザーデータ）テーブルに、更新リストに格納された各要素を登録/更新する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        public int UpdateGoodsBarcodeRevn( ref object updateList, out int updateCount, ref int barcodeUpdateKndDiv )
        {
            return this.UpdateGoodsBarcodeRevnProc( barcodeUpdateKndDiv, updateList, out updateCount );
        }

        /// <summary>
        /// 操作ログ出力
        /// </summary>
        /// <param name="writeParam">ログ出力情報</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 操作ログテーブルにログを出力する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        public int WriteOprtnHisLog( OprtnHisLogWork writeParam )
        {
            return this.WriteOprtnHisLogProc( writeParam );
        }

        #endregion //IPrmGoodsBarCodeRevnUpdateDB メンバ

        #region プライベートメソッド

        /// <summary>
        /// 優良設定マスタ検索処理実体
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="getPrmPartsBrcdParaList">更新対象優良設定リスト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する更新対象優良設定を取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int GetPrmPartsInfoListProc( PrmSetUParamForBrcdWork selectParam, out object getPrmPartsBrcdParaList )
        {
            object resultInfo = null;

            getPrmPartsBrcdParaList = null;

            int status = this.SearchProcBase(
                  (object)selectParam
                , this.CreateGetPrmPartsInfoQuery
                , this.CreateGetPrmPartsInfoResult
                , PrmGoodsBarCodeRevnUpdateDB.ErrorTextGetPrmPartsInfoListQueryFaild
                , out getPrmPartsBrcdParaList
                , out resultInfo );

            try
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList resultList = getPrmPartsBrcdParaList as ArrayList;
                    if (resultList == null || resultList.Count <= 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
            }
            catch (Exception exp)
            {
                base.WriteErrorLog( exp, PrmGoodsBarCodeRevnUpdateDB.ErrorTextGetPrmPartsInfoListQueryFaild );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）抽出件数取得実体
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="retCnt">抽出件数</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する商品バーコード関連付けマスタ（ユーザーデータ）を取得した場合の件数を取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int GetSearchCountProc( object selectParam, out int retCnt )
        {
            object resultCount = null;
            object resultInfo = null;

            retCnt = -1;

            int status = this.SearchProcBase(
                  selectParam
                , this.CreateGetSearchCountQuery
                , this.CreateGetSearchCountResult
                , PrmGoodsBarCodeRevnUpdateDB.ErrorTextGetSearchCountFaild
                , out resultCount
                , out resultInfo );

            try
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    int.TryParse( resultCount.ToString(), out retCnt );
                }
            }
            catch (Exception exp)
            {
                base.WriteErrorLog( exp, PrmGoodsBarCodeRevnUpdateDB.ErrorTextGetSearchCountFaild );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）抽出実体
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="prmPartsBrcdInfoList">抽出結果</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する商品バーコード関連付けマスタ（ユーザーデータ）を取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc( object selectParam, out object prmPartsBrcdInfoList )
        {
            object resultInfo = null;
            prmPartsBrcdInfoList = null;

            int status = this.SearchProcBase(
                  selectParam
                , this.CreateSearchQuery
                , this.CreateSearchResult
                , PrmGoodsBarCodeRevnUpdateDB.ErrorTextSearchFaild
                , out prmPartsBrcdInfoList
                , out resultInfo );

            try
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList resultList = prmPartsBrcdInfoList as ArrayList;
                    if (resultList == null || resultList.Count <= 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
            }
            catch (Exception exp)
            {
                base.WriteErrorLog( exp, PrmGoodsBarCodeRevnUpdateDB.ErrorTextSearchFaild );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）更新実体メイン
        /// </summary>
        /// <param name="barcodeUpdateKndDiv">バーコード更新区分</param>
        /// <param name="updateList">更新リスト</param>
        /// <param name="updateCount">処理件数</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ（ユーザーデータ）テーブルに、更新リストに格納された各要素を登録/更新する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int UpdateGoodsBarcodeRevnProc( int barcodeUpdateKndDiv, object updateList, out int updateCount )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            object resultInfo = null;

            updateCount = -1;

            try
            {
                using (SqlConnection sqlConnection = this.CreateSqlConnection())
                {
                    if (sqlConnection == null)
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_OFFLINE;
                    }
                    sqlConnection.Open();

                    try
                    {
                        using ( SqlTransaction sqlTransaction =  this.CreateTransaction(sqlConnection) )
                        {
                            try
                            {
                                status = this.UpdateProc( barcodeUpdateKndDiv, updateList, sqlConnection, sqlTransaction, out resultInfo, out updateCount );
                            }
                            catch
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                throw;
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
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }

            }
            catch (SqlException sqlExp)
            {
                status = base.WriteSQLErrorLog( sqlExp );
            }
            catch (Exception exp)
            {
                base.WriteErrorLog( exp, PrmGoodsBarCodeRevnUpdateDB.ErrorTextUpdateGoodsBarcodeRevnProcFaild );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (int)status;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）更新実体
        /// </summary>
        /// <param name="barcodeUpdateKndDiv">バーコード更新区分</param>
        /// <param name="updateList">更新リスト</param>
        /// <param name="sqlConnection">商品バーコード関連付けマスタ（ユーザーデータ）更新クエリ実行用オブジェクト</param>
        /// <param name="sqlTransaction">商品バーコード関連付けマスタ（ユーザーデータ）更新クエリ実行用トランザクション</param>
        /// <param name="resultInfo">処理結果追加情報（例外情報等）</param>
        /// <param name="updateCount">処理件数</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ（ユーザーデータ）テーブルに、更新リストに格納された各要素を登録/更新する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int UpdateProc( int barcodeUpdateKndDiv, object updateList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out object resultInfo, out int updateCount )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList targetList = updateList as ArrayList;

            resultInfo = null;
            updateCount = 0;

            if (targetList == null || targetList.Count <= 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                return status;
            }

            try
            {
                for( int index = 0; index < targetList.Count; index++ )
                {
                    GoodsBarCodeRevnWork work = targetList[index] as GoodsBarCodeRevnWork;
                    GoodsBarCodeRevnWork nowRecode = null;
                    if ( work == null )
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        base.WriteErrorLog( string.Format( PrmGoodsBarCodeRevnUpdateDB.ErrorTextIlligalParameter, index ), status );
                        break;
                    }
                    status = this.ReadGoodsBarCodeRevn( ref work, ref sqlConnection, ref sqlTransaction, out nowRecode );

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //商品バーコード関連付けマスタ（ユーザーデータ）レコードにする場合更新
                        status = this.WriteGoodsBarCodeRevn( barcodeUpdateKndDiv, ref work, ref nowRecode, ref sqlConnection, ref sqlTransaction );
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            //処理対象外なのでスキップする。但しエラーとはしない
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            continue;
                        }
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //商品バーコード関連付けマスタ（ユーザーデータ）レコードに存在しない場合新規登録
                        status = this.InsertGoodsBarCodeRevn( ref work, ref sqlConnection, ref sqlTransaction );
                    }
                    else 
                    {
                        base.WriteErrorLog( string.Format(
                              PrmGoodsBarCodeRevnUpdateDB.ErrorTextReadGoodsBarCodeRevnFaild
                            , work.GoodsMakerCd 
                            , work.GoodsNo
                            ), status );
                        break;
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (   status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND
                            && status != (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE )
                        {
                            base.WriteErrorLog( string.Format(
                                  PrmGoodsBarCodeRevnUpdateDB.ErrorTextUpdateProcFaild
                                , work.GoodsMakerCd
                                , work.GoodsNo
                                ), status );
                        }
                        break;
                    }
                    updateCount++;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                throw;
            }

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                updateCount = 0;
            }

            return status;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）レコードの読み込み
        /// </summary>
        /// <param name="target">抽出対象商品バーコード関連付けマスタ（ユーザーデータ）情報</param>
        /// <param name="sqlConnection">クエリ実行用オブジェクト</param>
        /// <param name="sqlTransaction">クエリ実行用トランザクション</param>
        /// <param name="result">読み込み結果</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ（ユーザーデータ）テーブルから１レコード読み込む</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int ReadGoodsBarCodeRevn( ref GoodsBarCodeRevnWork target, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out GoodsBarCodeRevnWork result )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string queryText = string.Empty;

            result = null;

            using (SqlCommand sqlCommand = new SqlCommand( string.Empty, sqlConnection, sqlTransaction ))
            {
                SqlDataReader myReader = null;
                try
                {
                    status = this.CreateReadQuery( ref target, sqlCommand, out queryText );
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    sqlCommand.CommandText = queryText;
                    sqlCommand.CommandTimeout = PrmGoodsBarCodeRevnUpdateDB.SqlCommandTimeoutDefault;

                    // 結果の取得
                    myReader = sqlCommand.ExecuteReader();

                    while ( myReader.Read() )
                    {
                        result = this.CopyToGoodsBarCodeRevnWorkFromDataReader( myReader );
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
                    }

                    if ( result == null )
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                finally
                {
                    if (myReader != null)
                    {
                        myReader.Close();
                        myReader = null;
                    }

                    if (sqlCommand != null)
                        sqlCommand.Cancel();
                }
            }

            return status;
        }

        /// <summary>
        /// 提供データ区分 ユーザー更新
        /// </summary>
        private const int OfferDataDivUserUpdate = 0;

        /// <summary>
        /// 提供データ区分 提供データ
        /// </summary>
        private const int OfferDataDivOfferData = 1;

        /// <summary>
        /// バーコード更新区分　ユーザー更新以外 
        /// </summary>
        private const int BarcodeUpdateKndDivWithoutUserUpdate = 0;

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）レコード更新
        /// </summary>
        /// <param name="barcodeUpdateKndDiv">バーコード更新区分</param>
        /// <param name="targetWork">更新対象商品バーコード関連付けマスタ（ユーザーデータ）情報</param>
        /// <param name="nowWork">比較対象商品バーコード関連付けマスタ（ユーザーデータ）情報</param>
        /// <param name="sqlConnection">クエリ実行用オブジェクト</param>
        /// <param name="sqlTransaction">クエリ実行用トランザクション</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ（ユーザーデータ）テーブルの対象レコードを更新する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int WriteGoodsBarCodeRevn( int barcodeUpdateKndDiv,ref GoodsBarCodeRevnWork targetWork, ref GoodsBarCodeRevnWork nowWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string queryText = string.Empty;

            if (targetWork.UpdateDateTime != nowWork.UpdateDateTime)
            {
                //但し、更新対象の作成日時＝更新日時の場合、新規として生成されたのでチェック対象外
                if (targetWork.UpdateDateTime != targetWork.CreateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    base.WriteErrorLog( string.Format(
                          PrmGoodsBarCodeRevnUpdateDB.ErrorTextAlrdyUpdate
                        , targetWork.GoodsMakerCd
                        , targetWork.GoodsNo
                        ), status );
                    return status;
                }
            }

            // 比較対象の提供データ区分が[0:ユーザー更新]で、かつユーザー更新分以外で処理を行っている場合、処理対象外
            // ※エラーとはしない
            if (nowWork.OfferDataDiv == PrmGoodsBarCodeRevnUpdateDB.OfferDataDivUserUpdate
                && barcodeUpdateKndDiv == PrmGoodsBarCodeRevnUpdateDB.BarcodeUpdateKndDivWithoutUserUpdate)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                return status;
            }

            // 比較対象の提供データ区分が[0:ユーザー更新]の場合、提供データ部を比較し更新対象と同じなら、処理対象外
            // ※エラーとはしない
            if (nowWork.OfferDataDiv == PrmGoodsBarCodeRevnUpdateDB.OfferDataDivOfferData
                && nowWork.OfferDate == targetWork.OfferDate
                && nowWork.GoodsBarCode == targetWork.GoodsBarCode
                && nowWork.GoodsBarCodeKind == targetWork.GoodsBarCodeKind)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                return status;
            }

            //更新ヘッダ情報を設定
            object obj = (object)this;
            IFileHeader flhd = (IFileHeader)targetWork;
            FileHeader fileHeader = new FileHeader( obj );
            fileHeader.SetUpdateHeader( ref flhd, obj );

            using (SqlCommand sqlCommand = new SqlCommand( string.Empty, sqlConnection, sqlTransaction ))
            {
                try
                {
                    status = this.CreateWriteQuery( ref targetWork, sqlCommand, out queryText );
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    sqlCommand.CommandText = queryText;
                    sqlCommand.CommandTimeout = PrmGoodsBarCodeRevnUpdateDB.SqlCommandTimeoutDefault;

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                finally
                {
                    if (sqlCommand != null)
                        sqlCommand.Cancel();
                }
            }

            return status;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）レコード新規登録
        /// </summary>
        /// <param name="targetWork">新規登録対象商品バーコード関連付けマスタ（ユーザーデータ）情報</param>
        /// <param name="sqlConnection">クエリ実行用オブジェクト</param>
        /// <param name="sqlTransaction">クエリ実行用トランザクション</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ（ユーザーデータ）テーブルに新規レコードを登録する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int InsertGoodsBarCodeRevn( ref GoodsBarCodeRevnWork targetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string queryText = string.Empty;

            //更新ヘッダ情報を設定
            object obj = (object)this;
            IFileHeader flhd = (IFileHeader)targetWork;
            FileHeader fileHeader = new FileHeader( obj );
            fileHeader.SetInsertHeader( ref flhd, obj );

            using (SqlCommand sqlCommand = new SqlCommand( string.Empty, sqlConnection, sqlTransaction ))
            {
                try
                {
                    status = this.CreateInserQuery( ref targetWork, sqlCommand, out queryText );
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    sqlCommand.CommandText = queryText;
                    sqlCommand.CommandTimeout = PrmGoodsBarCodeRevnUpdateDB.SqlCommandTimeoutDefault;

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                finally
                {
                    if (sqlCommand != null)
                        sqlCommand.Cancel();
                }
            }

            return status;
        }

        /// <summary>
        /// 操作ログ出力実体
        /// </summary>
        /// <param name="writeParam">ログ出力情報</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 操作ログテーブルにログを出力する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int WriteOprtnHisLogProc( OprtnHisLogWork writeParam )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                if (this.OperationLoggingDB == null)
                    this.OperationLoggingDB = new OprtnHisLogDB();

                object param = (object)writeParam;
                status = this.OperationLoggingDB.Write( ref param );
            }
            catch (SqlException sqlExp)
            {
                status = base.WriteSQLErrorLog( sqlExp );
            }
            catch (Exception exp)
            {
                base.WriteErrorLog( exp, PrmGoodsBarCodeRevnUpdateDB.ErrorTextUpdateGoodsBarcodeRevnProcFaild );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (int)status;
        }

        #region クエリ生成メソッド

        /// <summary>
        /// 優良設定マスタ検索処理用クエリ生成
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="sqlCommand">優良設定マスタ検索クエリ実行用オブジェクト</param>
        /// <param name="queryText">クエリ文字列格納オブジェクト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 優良設定マスタ検索を行うクエリの生成及びパラメータの設定</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int CreateGetPrmPartsInfoQuery( ref object selectParam, SqlCommand sqlCommand, out string queryText )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder queryStrings = new StringBuilder();

            queryText = null;

            //クエリ文字列のセット
            queryStrings.Append( PrmGoodsBarCodeRevnUpdateDB.GetPrmPartsInfoListQuery );

            //パラメータのセット
            PrmSetUParamForBrcdWork paramWork = selectParam as PrmSetUParamForBrcdWork;
            if (paramWork != null)
            {
                //Parameterオブジェクト生成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
                SqlParameter findParaMakerCdST = sqlCommand.Parameters.Add( "@FINDMAKERCODEST", SqlDbType.Int );
                SqlParameter findParaMakerCdED = sqlCommand.Parameters.Add( "@FINDMAKERCODEED", SqlDbType.Int );
                SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add( "@FINDGOODSMGROUP", SqlDbType.Int );
                SqlParameter findParaBlGoodsCd = sqlCommand.Parameters.Add( "@FINDBLGOODSCODE ", SqlDbType.Int );

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( paramWork.EnterpriseCode );
                findParaMakerCdST.Value = SqlDataMediator.SqlSetInt32( paramWork.MakerCdST );
                findParaMakerCdED.Value = SqlDataMediator.SqlSetInt32( paramWork.MakerCdED );
                findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32( paramWork.GoodMGroup );
                findParaBlGoodsCd.Value = SqlDataMediator.SqlSetInt32( paramWork.BLGoodsCode );

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            queryText = queryStrings.ToString();

            return status;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）抽出件数取得クエリ生成
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="sqlCommand">商品バーコード関連付けマスタ（ユーザーデータ）抽出件数クエリ実行用オブジェクト</param>
        /// <param name="queryText">クエリ文字列格納オブジェクト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ（ユーザーデータ）抽出件数取得を行うクエリの生成及びパラメータの設定</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int CreateGetSearchCountQuery( ref object selectParam, SqlCommand sqlCommand, out string queryText )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            StringBuilder queryStrings = new StringBuilder();

            queryText = null;

            //Select句、From句のセット
            queryStrings.Append( PrmGoodsBarCodeRevnUpdateDB.SelectCountQuery );
            queryStrings.Append( PrmGoodsBarCodeRevnUpdateDB.FromQuery );

            //Where句のセット
            this.AddWhereQuery( ref selectParam, sqlCommand, ref queryStrings );

            queryText = queryStrings.ToString();

            return status;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）抽出クエリ生成
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="sqlCommand">商品バーコード関連付けマスタ（ユーザーデータ）抽出クエリ実行用オブジェクト</param>
        /// <param name="queryText">クエリ文字列格納オブジェクト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ（ユーザーデータ）抽出を行うクエリの生成及びパラメータの設定</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int CreateSearchQuery( ref object selectParam, SqlCommand sqlCommand, out string queryText )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            StringBuilder queryStrings = new StringBuilder();

            queryText = null;

            //Select句、From句のセット
            queryStrings.Append( PrmGoodsBarCodeRevnUpdateDB.SelectQuery );
            queryStrings.Append( PrmGoodsBarCodeRevnUpdateDB.FromQuery );

            //Where句のセット
            this.AddWhereQuery( ref selectParam, sqlCommand, ref queryStrings );

            //OrderBy句のセット
            queryStrings.Append( PrmGoodsBarCodeRevnUpdateDB.OrderBySymbol );

            queryText = queryStrings.ToString();

            return status;
        }

        /// <summary>
        /// WHERE句生成
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="sqlCommand">クエリ実行用オブジェクト</param>
        /// <param name="queryText">クエリ文字列格納オブジェクト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ（ユーザーデータ）抽出及び抽出件数取得用クエリ中、WHERE句の生成及びパラメータの設定</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private void AddWhereQuery( ref object selectParam, SqlCommand sqlCommand, ref StringBuilder queryText )
        {
            string whereString = PrmGoodsBarCodeRevnUpdateDB.WhereAndSymbolStart;
            ArrayList paramList = selectParam as ArrayList;

            // パラメータが空の場合、WHERE句を追加しない
            if (paramList == null || paramList.Count <= 0)
            {
                return;
            }

            foreach (object param in paramList)
            {
                GetPrmPartsBrcdParaWork paramWork = null;

                if (param == null || !( param is GetPrmPartsBrcdParaWork ))
                {
                    continue;
                }
                paramWork = param as GetPrmPartsBrcdParaWork;

                if (!string.IsNullOrEmpty( whereString ))
                {
                    //whereStringに文字列が含まれている場合

                    //先頭の条件なのでWHERE句文字列を追加
                    queryText.AppendLine( PrmGoodsBarCodeRevnUpdateDB.WhereBase );
                    //Parameterオブジェクト生成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( paramWork.EnterpriseCode );

                    //WHERE句AND条件開始文字列を追加
                    queryText.AppendLine( whereString );
                    whereString = string.Empty;

                    //先頭の抽出条件を追加
                    queryText.AppendFormat( PrmGoodsBarCodeRevnUpdateDB.WhereFormatTop, paramWork.MakerCode, paramWork.BLGoodsCode );
                    queryText.AppendLine();
                }
                else
                {
                    //whereStringに文字列が含まれていない場合、先頭以降の抽出条件を追加
                    queryText.AppendFormat( PrmGoodsBarCodeRevnUpdateDB.WhereFormat, paramWork.MakerCode, paramWork.BLGoodsCode );
                    queryText.AppendLine();
                }
            }

            //whereStringの文字列が空の場合、WHERE句AND条件が追加されているのでWHERE句AND条件終了文字列を追加
            if (string.IsNullOrEmpty( whereString ))
            {
                queryText.AppendLine( PrmGoodsBarCodeRevnUpdateDB.WhereAndSymbolEnd );
            }
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）レコード読み込みクエリ生成
        /// </summary>
        /// <param name="target">抽出対象商品バーコード関連付けマスタ（ユーザーデータ）情報</param>
        /// <param name="sqlCommand">商品バーコード関連付けマスタ（ユーザーデータ）レコード読み込みクエリ実行用オブジェクト</param>
        /// <param name="queryText">クエリ文字列格納オブジェクト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ（ユーザーデータ）レコード読み込みを行うクエリの生成及びパラメータの設定</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int CreateReadQuery( ref GoodsBarCodeRevnWork target, SqlCommand sqlCommand, out string queryText )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            StringBuilder queryStrings = new StringBuilder();

            queryText = null;

            //クエリ文字列のセット
            queryStrings.Append( PrmGoodsBarCodeRevnUpdateDB.ReadQuery );

            //Parameterオブジェクト生成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            SqlParameter findParaMakerCd = sqlCommand.Parameters.Add( "@FINDMAKERCODE", SqlDbType.Int );
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add( "@FINDGOODSNO", SqlDbType.NChar );
            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( target.EnterpriseCode );
            findParaMakerCd.Value = SqlDataMediator.SqlSetInt32( target.GoodsMakerCd );
            findParaGoodsNo.Value = SqlDataMediator.SqlSetString( target.GoodsNo );

            queryText = queryStrings.ToString();

            return status;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）レコード更新クエリ生成
        /// </summary>
        /// <param name="target">更新対象商品バーコード関連付けマスタ（ユーザーデータ）情報</param>
        /// <param name="sqlCommand">商品バーコード関連付けマスタ（ユーザーデータ）レコード更新クエリ実行用オブジェクト</param>
        /// <param name="queryText">クエリ文字列格納オブジェクト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ（ユーザーデータ）レコード読み込みを行うクエリの生成及びパラメータの設定</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int CreateWriteQuery( ref GoodsBarCodeRevnWork target, SqlCommand sqlCommand, out string queryText )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            StringBuilder queryStrings = new StringBuilder();

            queryText = null;

            //クエリ文字列のセット
            queryStrings.Append( PrmGoodsBarCodeRevnUpdateDB.WriteQuery );

            //Parameterオブジェクト生成
            //Where句
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            SqlParameter findParaMakerCd = sqlCommand.Parameters.Add( "@FINDMAKERCODE", SqlDbType.Int );
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add( "@FINDGOODSNO", SqlDbType.NChar );
            //Set句
            SqlParameter setParaUpdateDateTime = sqlCommand.Parameters.Add( "@SETUPDATEDATETIME", SqlDbType.BigInt );
            SqlParameter setParaUpdEmployeeCode = sqlCommand.Parameters.Add( "@SETUPDEMPLOYEECODE", SqlDbType.NChar );
            SqlParameter setParaUpdAssemblyId1 = sqlCommand.Parameters.Add( "@SETUPDASSEMBLYID1", SqlDbType.NChar );
            SqlParameter setParaUpdAssemblyId2 = sqlCommand.Parameters.Add( "@SETUPDASSEMBLYID2", SqlDbType.NChar );
            SqlParameter setParaGoodsBarCode = sqlCommand.Parameters.Add( "@SETGOODSBARCODE", SqlDbType.NChar );
            SqlParameter setParaGoodsBarCodeKind = sqlCommand.Parameters.Add( "@SETGOODSBARCODEKIND", SqlDbType.Int );
            SqlParameter setParaOfferDate = sqlCommand.Parameters.Add( "@SETOFFERDATE", SqlDbType.Int );
            SqlParameter setParaOfferDataDiv = sqlCommand.Parameters.Add( "@SETOFFERDATADIV", SqlDbType.Int );

            //Parameterオブジェクトへ値設定
            //Where句
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( target.EnterpriseCode );
            findParaMakerCd.Value = SqlDataMediator.SqlSetInt32( target.GoodsMakerCd );
            findParaGoodsNo.Value = SqlDataMediator.SqlSetString( target.GoodsNo );
            //Set句
            setParaUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks( target.UpdateDateTime );
            setParaUpdEmployeeCode.Value = SqlDataMediator.SqlSetString( target.UpdEmployeeCode );
            setParaUpdAssemblyId1.Value = SqlDataMediator.SqlSetString( target.UpdAssemblyId1 );
            setParaUpdAssemblyId2.Value = SqlDataMediator.SqlSetString( target.UpdAssemblyId2 );
            setParaGoodsBarCode.Value = SqlDataMediator.SqlSetString( target.GoodsBarCode );
            setParaGoodsBarCodeKind.Value = SqlDataMediator.SqlSetInt32( target.GoodsBarCodeKind );
            setParaOfferDate.Value = SqlDataMediator.SqlSetInt32( target.OfferDate );
            setParaOfferDataDiv.Value = SqlDataMediator.SqlSetInt32( target.OfferDataDiv );

            queryText = queryStrings.ToString();

            return status;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）レコード新規登録クエリ生成
        /// </summary>
        /// <param name="target">登録対象商品バーコード関連付けマスタ（ユーザーデータ）情報</param>
        /// <param name="sqlCommand">商品バーコード関連付けマスタ（ユーザーデータ）レコード新規登録クエリ実行用オブジェクト</param>
        /// <param name="queryText">クエリ文字列格納オブジェクト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ（ユーザーデータ）レコード読み込みを行うクエリの生成及びパラメータの設定</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int CreateInserQuery( ref GoodsBarCodeRevnWork target, SqlCommand sqlCommand, out string queryText )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            StringBuilder queryStrings = new StringBuilder();

            queryText = null;

            //クエリ文字列のセット
            queryStrings.Append( PrmGoodsBarCodeRevnUpdateDB.InsertQuery );

            //Parameterオブジェクト生成
            //Set句
            SqlParameter setParaCreateDateTime = sqlCommand.Parameters.Add( "@SETCREATEDATETIME", SqlDbType.BigInt );
            SqlParameter setParaUpdateDateTime = sqlCommand.Parameters.Add( "@SETUPDATEDATETIME", SqlDbType.BigInt );
            SqlParameter setParaEnterpriseCode = sqlCommand.Parameters.Add( "@SETENTERPRISECODE", SqlDbType.NChar );
            SqlParameter setParaFileHeaderGuid = sqlCommand.Parameters.Add( "@SETFILEHEADERGUID", SqlDbType.UniqueIdentifier );
            SqlParameter setParaUpdEmployeeCode = sqlCommand.Parameters.Add( "@SETUPDEMPLOYEECODE", SqlDbType.NChar );
            SqlParameter setParaUpdAssemblyId1 = sqlCommand.Parameters.Add( "@SETUPDASSEMBLYID1", SqlDbType.NChar );
            SqlParameter setParaUpdAssemblyId2 = sqlCommand.Parameters.Add( "@SETUPDASSEMBLYID2", SqlDbType.NChar );
            SqlParameter setParaLogicalDeleteCode = sqlCommand.Parameters.Add( "@SETLOGICALDELETECODE", SqlDbType.Int );
            SqlParameter setParaGoodsMakerCd = sqlCommand.Parameters.Add( "@SETGOODSMAKERCD", SqlDbType.Int );
            SqlParameter setParaGoodsNo = sqlCommand.Parameters.Add( "@SETGOODSNO", SqlDbType.NChar );
            SqlParameter setParaGoodsBarCode = sqlCommand.Parameters.Add( "@SETGOODSBARCODE", SqlDbType.NChar );
            SqlParameter setParaGoodsBarCodeKind = sqlCommand.Parameters.Add( "@SETGOODSBARCODEKIND", SqlDbType.Int );
            SqlParameter setParaCheckdigitCode = sqlCommand.Parameters.Add( "@SETCHECKDIGITCODE", SqlDbType.Int );
            SqlParameter setParaOfferDate = sqlCommand.Parameters.Add( "@SETOFFERDATE", SqlDbType.Int );
            SqlParameter setParaOfferDataDiv = sqlCommand.Parameters.Add( "@SETOFFERDATADIV", SqlDbType.Int );

            //Parameterオブジェクトへ値設定
            //Set句
            setParaCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks( target.CreateDateTime );
            setParaUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks( target.UpdateDateTime );
            setParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( target.EnterpriseCode );
            setParaFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid( target.FileHeaderGuid );
            setParaUpdEmployeeCode.Value = SqlDataMediator.SqlSetString( target.UpdEmployeeCode );
            setParaUpdAssemblyId1.Value = SqlDataMediator.SqlSetString( target.UpdAssemblyId1 );
            setParaUpdAssemblyId2.Value = SqlDataMediator.SqlSetString( target.UpdAssemblyId2 );
            setParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32( target.LogicalDeleteCode );
            setParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32( target.GoodsMakerCd );
            setParaGoodsNo.Value = SqlDataMediator.SqlSetString( target.GoodsNo );
            setParaGoodsBarCode.Value = SqlDataMediator.SqlSetString( target.GoodsBarCode );
            setParaGoodsBarCodeKind.Value = SqlDataMediator.SqlSetInt32( target.GoodsBarCodeKind );
            setParaCheckdigitCode.Value = SqlDataMediator.SqlSetInt32( target.CheckdigitCode );
            setParaOfferDate.Value = SqlDataMediator.SqlSetInt32( target.OfferDate );
            setParaOfferDataDiv.Value = SqlDataMediator.SqlSetInt32( target.OfferDataDiv );

            queryText = queryStrings.ToString();

            return status;
        }

        #endregion //クエリ生成メソッド

        #region 抽出結果生成メソッド

        /// <summary>
        /// 優良設定マスタ抽出結果生成
        /// </summary>
        /// <param name="myReader">優良設定マスタ抽出結果のデータストリーム</param>
        /// <returns>優良設定マスタ抽出結果リスト</returns>
        /// <remarks>
        /// <br>Note       : 優良設定マスタ抽出クエリを実行して得たデータストリームから抽出結果リストを生成</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private object CreateGetPrmPartsInfoResult( SqlDataReader myReader )
        {
            object resultObject = null;
            ArrayList resultList = new ArrayList();

            if (myReader != null)
            {
                while (myReader.Read())
                {
                    GetPrmPartsBrcdParaWork work = new GetPrmPartsBrcdParaWork();
                    work.EnterpriseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISECODERF" ) );  // 企業コード
                    work.MakerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PARTSMAKERCDRF" ) );  // メーカーコード
                    work.BLGoodsCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TBSPARTSCODERF" ) );  // BL商品コード
                    resultList.Add( work );
                }
                resultObject = (object)resultList;
            }

            return resultObject;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）抽出件数取得結果生成
        /// </summary>
        /// <param name="myReader">商品バーコード関連付けマスタ（ユーザーデータ）抽出件数取得結果のデータストリーム</param>
        /// <returns> 抽出件数</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ（ユーザーデータ）抽出件数取得クエリを実行して得たデータストリームから取得結果を生成</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private object CreateGetSearchCountResult( SqlDataReader myReader )
        {
            object resultObject = null;

            if (myReader != null)
            {
                myReader.Read();
                int count = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SELECTCOUNT" ) );  // 件数
                resultObject = (object)count.ToString();
            }

            return resultObject;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）抽出結果生成
        /// </summary>
        /// <param name="myReader">商品バーコード関連付けマスタ（ユーザーデータ）抽出結果のデータストリーム</param>
        /// <returns> 商品バーコード関連付けマスタ（ユーザーデータ）抽出結果リスト</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ（ユーザーデータ）抽出クエリを実行して得たデータストリームから取得結果を生成</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private object CreateSearchResult( SqlDataReader myReader )
        {
            object resultObject = null;
            ArrayList resultList = new ArrayList();

            if (myReader != null)
            {
                while (myReader.Read())
                {
                    GoodsBarCodeRevnWork work = this.CopyToGoodsBarCodeRevnWorkFromDataReader( myReader );
                    resultList.Add( work );
                }
                resultObject = (object)resultList;
            }

            return resultObject;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ（ユーザーデータ）情報ワーク生成
        /// </summary>
        /// <param name="myReader">商品バーコード関連付けマスタ（ユーザーデータ）抽出結果のデータストリーム</param>
        /// <returns>商品バーコード関連付けマスタ（ユーザーデータ）情報ワーク</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ（ユーザーデータ）抽出クエリを実行して得たデータストリームの現在行から情報ワークを生成</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private GoodsBarCodeRevnWork CopyToGoodsBarCodeRevnWorkFromDataReader( SqlDataReader myReader )
        {
            GoodsBarCodeRevnWork work = new GoodsBarCodeRevnWork();
            work.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks( myReader, myReader.GetOrdinal( "CREATEDATETIMERF" ) );  // 作成日時
            work.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks( myReader, myReader.GetOrdinal( "UPDATEDATETIMERF" ) );  // 更新日時
            work.EnterpriseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISECODERF" ) );  // 企業コード
            work.FileHeaderGuid = SqlDataMediator.SqlGetGuid( myReader, myReader.GetOrdinal( "FILEHEADERGUIDRF" ) );  // GUID
            work.UpdEmployeeCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UPDEMPLOYEECODERF" ) );  // 更新従業員コード
            work.UpdAssemblyId1 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UPDASSEMBLYID1RF" ) );  // 更新アセンブリID1
            work.UpdAssemblyId2 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UPDASSEMBLYID2RF" ) );  // 更新アセンブリID2
            work.LogicalDeleteCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "LOGICALDELETECODERF" ) );  // 論理削除区分
            work.GoodsMakerCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSMAKERCDRF" ) );  // 商品メーカーコード
            work.GoodsNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNORF" ) );  // 商品番号
            work.GoodsBarCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSBARCODERF" ) );  // 商品バーコード
            work.GoodsBarCodeKind = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSBARCODEKINDRF" ) );  // 商品バーコード種別
            work.CheckdigitCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CHECKDIGITCODERF" ) );  // チェックデジット区分
            work.OfferDate = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "OFFERDATERF" ) );  // 提供日付
            work.OfferDataDiv = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "OFFERDATADIVRF" ) );  // 提供データ区分
            return work;
        }

        #endregion //結果格納メソッド

        #region 抽出クエリ実行メソッド

        /// <summary>
        /// 優良部品バーコード情報抽出実体
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="createQueryMethod">抽出クエリ生成処理として呼び出すメソッド</param>
        /// <param name="getResultListMethod">抽出結果リスト生成処理呼び出すメソッド</param>
        /// <param name="errorText">予期せぬエラーが発生した場合に表題として出力するテキスト</param>
        /// <param name="searchResult">抽出結果</param>
        /// <param name="resultInfo">処理結果追加情報（例外情報等）</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する情報を取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private int SearchProcBase(
              object selectParam
            , PrmGoodsBarCodeRevnUpdateDB.CreateQueryDelegate createQueryMethod
            , CreateResultDelegate getResultListMethod
            , string errorText
            , out object searchResult
            , out object resultInfo )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string queryText = null;
            ArrayList execResultList = new ArrayList();

            searchResult = null;
            resultInfo = null;

            try
            {
                using (SqlConnection sqlConnection = this.CreateSqlConnection())
                {
                    if (sqlConnection == null)
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_OFFLINE;
                    }
                    sqlConnection.Open();

                    try
                    {
                        using (SqlCommand sqlCommand = new SqlCommand( string.Empty, sqlConnection ))
                        {
                            try
                            {
                                //クエリ文字列の生成
                                int funcResult = createQueryMethod( ref selectParam, sqlCommand, out queryText );
                                if (funcResult != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    return funcResult;
                                }
                                sqlCommand.CommandText = queryText;
                                sqlCommand.CommandTimeout = PrmGoodsBarCodeRevnUpdateDB.SqlCommandTimeoutDefault;

                                SqlDataReader myReader = null;
                                try
                                {
                                    // 結果の取得
                                    myReader = sqlCommand.ExecuteReader();
                                    searchResult = getResultListMethod( myReader );
                                    if (searchResult == null)
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                    }
                                    else
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                    }
                                }
                                finally
                                {
                                    if (myReader != null)
                                        myReader.Close();
                                }
                            }
                            finally
                            {
                                if (sqlCommand != null)
                                    sqlCommand.Dispose();
                            }
                        }
                    }
                    finally
                    {
                        if (sqlConnection != null)
                            sqlConnection.Close();
                    }
                }

            }
            catch (SqlException sqlExp)
            {
                status = base.WriteSQLErrorLog( sqlExp );
                CustomSerializeArrayList errorList = new CustomSerializeArrayList();
                errorList.Add( sqlExp );
                resultInfo = (object)errorList;
            }
            catch (Exception exp)
            {
                base.WriteErrorLog( exp, errorText );
                CustomSerializeArrayList errorList = new CustomSerializeArrayList();
                errorList.Add( exp );
                resultInfo = (object)errorList;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (int)status;
        }

        #endregion //抽出クエリ実行メソッド

        #region SQL Serverデータベース接続処理

        /// <summary>
        /// SQL Serverデータベース接続情報処理
        /// </summary>
        /// <returns>SQL Serverデータベースとの接続情報</returns>
        /// <remarks>
        /// <br>Note       : SQL Serverデータベースへの開いた接続情報を取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
            if (string.IsNullOrEmpty( connectionText ))
                return null;

            retSqlConnection = new SqlConnection( connectionText );

            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlConnection">SQL Serverデータベースとの接続情報</param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/07/22</br>
        /// </remarks>
        private SqlTransaction CreateTransaction( SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlConnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlConnection.State & ConnectionState.Open) == 0)
                {
                    sqlConnection.Open();
                }

                // トランザクションの生成(開始)
                retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }

        #endregion //SQL Serverデータベース接続処理

        #endregion //プライベートメソッド
    }
}

