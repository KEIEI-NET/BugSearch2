//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌出荷部品表示
// プログラム概要   : 車輌出荷部品表示を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/09/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日  2009/10/20  修正内容 : PM-2-A Redmin#702、749対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日  2009/10/23  修正内容 : PM-2-A Redmin#829対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 修 正 日  2009/12/24  修正内容 : MANTIS[14822] 車輌管理マスタ キー追加対応
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : 曹文傑
// 修 正 日  2011/03/22  修正内容 : 照会プログラムのログ出力対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 凌小青
// 修 正 日  2012/08/09  修正内容 : 2012/09/12配信分、Redmine#31532 車輌出荷部品表示 ソート順不正
//----------------------------------------------------------------------------//
// 管理番号  10900269-00 作成担当 : FSI厚川 宏
// 修 正 日  2013/03/25  修正内容 : SPK車台番号文字列対応に伴う車台番号表示レイアウトの修正
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
using Broadleaf.Library.Collections;
using Broadleaf.Library.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 車輌出荷部品表示処理READDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車輌出荷部品表示処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.09.10</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/20 呉元嘯</br>
    /// <br>             Redmin#702、749対応</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/23 呉元嘯</br>
    /// <br>             Redmin#829対応</br>
    /// <br>Update Note: 2011/03/22 曹文傑</br>
    /// <br>             照会プログラムのログ出力対応</br>
    /// <br>Update Note: 2012/08/09 凌小青</br>
    /// <br>             Redmine#31532 車輌出荷部品表示 ソート順不正</br>
    /// <br>Update Note: SPK車台番号文字列対応に伴う車台番号表示レイアウトの修正</br>
    /// <br>Programmer : FSI厚川 宏</br>
    /// <br>Date       : 2013/03/25</br>
    /// </remarks>
    [Serializable]
    public class CarShipmentPartsDispDB : RemoteDB, ICarShipmentPartsDispDB
    {
        #region 車輌出荷部品表示検索処理
        /// <summary>
        /// 車輌出荷部品表示検索処理
        /// </summary>
        /// <param name="carManagementList">検索条件</param>
        /// <param name="carManagementObj">検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車輌出荷部品表示処理</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        public int CarInfoSearch(ref ArrayList carManagementList, object carManagementObj)
        {
            // ---UPD 2011/03/22---------->>>>>
            //return CarInfoSearchProc(ref carManagementList, carManagementObj);
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CarInfoConditionWorkWork carInfoConditionWorkWork = carManagementObj as CarInfoConditionWorkWork;

            SqlConnection sqlConnection = null;
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();

                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, carInfoConditionWorkWork.EnterpriseCode, "車輌出荷部品表示", "抽出開始");

                status = CarInfoSearchProc(ref carManagementList, carManagementObj);

                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, carInfoConditionWorkWork.EnterpriseCode, "車輌出荷部品表示", "抽出終了");
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "CarShipmentPartsDispDB.CarInfoSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }
            
            return status;
            // ---UPD 2011/03/22---------->>>>>
        }

        /// <summary>
        /// 車輌出荷部品表示検索処理
        /// </summary>
        /// <param name="carManagementList">検索条件</param>
        /// <param name="carManagementObj">検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車輌出荷部品表示処理</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.09.10</br>
        /// <br>Update Note: 2011/03/22 曹文傑</br>
        /// <br>             照会プログラムのログ出力対応</br>
        /// <br>Update Note: 2012/08/09 凌小青</br>
        /// <br>             Redmine#31532 車輌出荷部品表示 ソート順不正</br>
        /// <br>Update Note: SPK車台番号文字列対応に伴う車台番号表示レイアウトの修正</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/03/25</br>
        private int CarInfoSearchProc(ref ArrayList carManagementList, object carManagementObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            CarInfoConditionWorkWork carInfoConditionWorkWork = carManagementObj as CarInfoConditionWorkWork;
            carManagementList = new ArrayList();
            CarShipmentPartsDispWork carShipmentPartsDispWork = null;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (_connectionText == null || _connectionText == "")
            {
                return status;
            }

            sqlConnection = new SqlConnection(_connectionText);
            sqlConnection.Open();

            sqlCommand = new SqlCommand("", sqlConnection);
            try
            {
                // Selectコマンドの生成
                sqlStr = " SELECT "
                + " ACCEPTODRCARRF.CARMNGCODERF, "                // ADD 2009/10/10 受注マスタ(車輌).車輌管理コード
                + " SALESHISTORYRF.SALESDATERF, "                // 売上履歴データ.売上日付
                + " SALESHISTORYRF.SLIPNOTERF AS NOTERF, "                // 売上履歴データ.伝票備考
                + " SALESHISTORYRF.SALESSLIPNUMRF, "                // 売上履歴データ.売上伝票番号
                + " SALESHISTDTLRF.GOODSNAMERF, "                // 売上履歴明細データ.商品名称
                + " SALESHISTDTLRF.GOODSNORF, "                // 売上履歴明細データ.商品番号
                + " SALESHISTDTLRF.GOODSMAKERCDRF, "                // 売上履歴明細データ.商品メーカーコード
                + " SALESHISTDTLRF.BLGOODSCODERF, "                // 売上履歴明細データ.BL商品コード
                + " SALESHISTDTLRF.WAREHOUSECODERF, "                // 売上履歴明細データ.倉庫コード
                + " SALESHISTDTLRF.WAREHOUSESHELFNORF, "                // 売上履歴明細データ.倉庫棚番
                + " SALESHISTDTLRF.SALESROWNORF,"　　　　　　　　//行番号　//ADD BY 凌小青 on 2012/08/09 for Redmine#31532
                + " SALESHISTDTLRF.SALESORDERDIVCDRF, "                // 売上履歴明細データ.売上在庫取寄せ区分
                + " SALESHISTDTLRF.LISTPRICETAXEXCFLRF, "                // 売上履歴明細データ.定価（税抜，浮動）
                + " SALESHISTDTLRF.SHIPMENTCNTRF, "                // 売上履歴明細データ.出荷数
                + " SALESHISTDTLRF.SALESUNPRCTAXEXCFLRF, "                // 売上履歴明細データ.売上単価（税抜，浮動）
                + " SALESHISTDTLRF.SALESMONEYTAXEXCRF, "                // 売上履歴明細データ.売上金額（税抜き）
                + " SALESHISTDTLRF.SALESUNITCOSTRF, "                // 売上履歴明細データ.原価単価
                + " 0 AS GROSSPROFITRF, "                            // 0 粗利金額  // ADD 2009/10/10
                + " SALESHISTDTLRF.WAREHOUSENAMERF, "                // 売上履歴明細データ.倉庫名称
                + " SALESHISTDTLRF.COSTRF, "                // 売上履歴明細データ.原価
                + " SALESHISTDTLRF.SALESSLIPCDDTLRF, "            // 売上履歴明細データ.売上伝票区分（明細） // ADD 2009/10/23
                + " ACCEPTODRCARRF.CARNOTERF, "                // 受注マスタ（車両）.車輌備考
                + " ACCEPTODRCARRF.MILEAGERF, "                // 受注マスタ（車両）.走行距離
                + " ACCEPTODRCARRF.MODELDESIGNATIONNORF, "                // 受注マスタ（車両）.型式指定番号
                + " ACCEPTODRCARRF.CATEGORYNORF, "                // 受注マスタ（車両）.類別番号
                + " ACCEPTODRCARRF.ENGINEMODELNMRF, "                // 受注マスタ（車両）.エンジン型式名称
                + " ACCEPTODRCARRF.FULLMODELRF, "                // 受注マスタ（車両）.型式（フル型）
                + " ACCEPTODRCARRF.MAKERCODERF, "                // 受注マスタ（車両）.メーカーコード
                + " ACCEPTODRCARRF.MODELCODERF, "                // 受注マスタ（車両）.車種コード
                + " ACCEPTODRCARRF.MODELSUBCODERF, "                // 受注マスタ（車両）.車種サブコード
                + " ACCEPTODRCARRF.MODELFULLNAMERF, "                // 受注マスタ（車両）.車種全角名称
                + " ACCEPTODRCARRF.MODELHALFNAMERF, "                // 受注マスタ（車両）.車種半角名称
                + " ACCEPTODRCARRF.FIRSTENTRYDATERF, "                // 受注マスタ（車両）.初年度
                + " ACCEPTODRCARRF.FRAMENORF, "                // 受注マスタ（車両）.車台番号
                + " ACCEPTODRCARRF.COLORCODERF, "                // 受注マスタ（車両）.カラーコード
                + " ACCEPTODRCARRF.COLORNAME1RF, "                // 受注マスタ（車両）.カラー名称1
                + " ACCEPTODRCARRF.TRIMCODERF, "                // 受注マスタ（車両）.トリムコード
                + " ACCEPTODRCARRF.TRIMNAMERF, "                // 受注マスタ（車両）.トリム名称
                + " ACCEPTODRCARRF.NUMBERPLATE1CODERF, "                // 受注マスタ（車両）.陸運事務所番号
                + " ACCEPTODRCARRF.NUMBERPLATE1NAMERF, "                // 受注マスタ（車両）.陸運事務局名称
                + " ACCEPTODRCARRF.NUMBERPLATE2RF, "                // 受注マスタ（車両）.車両登録番号（種別）
                + " ACCEPTODRCARRF.NUMBERPLATE3RF, "                // 受注マスタ（車両）.車両登録番号（カナ）
                + " ACCEPTODRCARRF.NUMBERPLATE4RF, "                // 受注マスタ（車両）.車両登録番号（プレート番号）
                + " ACCEPTODRCARRF.DOMESTICFOREIGNCODERF, "                // 受注マスタ（車両）.国産／外車区分 // ADD 2013/03/25
                + " CARMANAGEMENTRF.SERIESMODELRF, "               // 車輌管理マスタ.シリーズ型式
                + " CARMANAGEMENTRF.CATEGORYSIGNMODELRF, "               // 車輌管理マスタ.型式（類別記号）
                + " CARMANAGEMENTRF.STPRODUCETYPEOFYEARRF, "               // 車輌管理マスタ.開始生産年式
                + " CARMANAGEMENTRF.EDPRODUCETYPEOFYEARRF, "               // 車輌管理マスタ.終了生産年式
                + " CARMANAGEMENTRF.STPRODUCEFRAMENORF, "               // 車輌管理マスタ.生産車台番号開始
                + " CARMANAGEMENTRF.EDPRODUCEFRAMENORF, "               // 車輌管理マスタ.生産車台番号終了
                + " CARMANAGEMENTRF.MODELGRADENMRF, "               // 車輌管理マスタ.型式グレード名称
                + " CARMANAGEMENTRF.ENGINEMODELRF, "               // 車輌管理マスタ.原動機型式（エンジン）
                + " CARMANAGEMENTRF.BODYNAMERF, "               // 車輌管理マスタ.ボディー名称
                + " CARMANAGEMENTRF.DOORCOUNTRF, "               // 車輌管理マスタ.ドア数
                    //+ " CARMANAGEMENTRF.ENGINEMODELNMRF, "               // 車輌管理マスタ.エンジン型式名称
                + " CARMANAGEMENTRF.ENGINEDISPLACENMRF, "               // 車輌管理マスタ.排気量名称
                + " CARMANAGEMENTRF.EDIVNMRF, "               // 車輌管理マスタ.E区分名称
                + " CARMANAGEMENTRF.TRANSMISSIONNMRF, "               // 車輌管理マスタ.ミッション名称
                + " CARMANAGEMENTRF.WHEELDRIVEMETHODNMRF, "               // 車輌管理マスタ.駆動方式名称
                + " CARMANAGEMENTRF.SHIFTNMRF, "               // 車輌管理マスタ.シフト名称
                + " CARMANAGEMENTRF.ADDICARSPECTITLE1RF, "               // 車輌管理マスタ.追加諸元タイトル1
                + " CARMANAGEMENTRF.ADDICARSPECTITLE2RF, "               // 車輌管理マスタ.追加諸元タイトル2
                + " CARMANAGEMENTRF.ADDICARSPECTITLE3RF, "               // 車輌管理マスタ.追加諸元タイトル3
                + " CARMANAGEMENTRF.ADDICARSPECTITLE4RF, "               // 車輌管理マスタ.追加諸元タイトル4
                + " CARMANAGEMENTRF.ADDICARSPECTITLE5RF, "               // 車輌管理マスタ.追加諸元タイトル5
                + " CARMANAGEMENTRF.ADDICARSPECTITLE6RF, "               // 車輌管理マスタ.追加諸元タイトル6
                + " CARMANAGEMENTRF.ADDICARSPEC1RF, "               // 車輌管理マスタ.追加諸元1
                + " CARMANAGEMENTRF.ADDICARSPEC2RF, "               // 車輌管理マスタ.追加諸元2
                + " CARMANAGEMENTRF.ADDICARSPEC3RF, "               // 車輌管理マスタ.追加諸元3
                + " CARMANAGEMENTRF.ADDICARSPEC4RF, "               // 車輌管理マスタ.追加諸元4
                + " CARMANAGEMENTRF.ADDICARSPEC5RF, "               // 車輌管理マスタ.追加諸元5
                + " CARMANAGEMENTRF.ADDICARSPEC6RF, "               // 車輌管理マスタ.追加諸元6
                + " MAKERURF.MAKERNAMERF, "                // メーカーマスタ（ユーザー登録）.メーカー名称
                + " STOCKRF.SHIPMENTPOSCNTRF, "                   // 在庫マスタ.出荷可能数
                + " SALESHISTORYRF.ACPTANODRSTATUSRF " // 売上履歴データ.受注ステータス
                + " FROM "
                    // 売上履歴データ WITH (READUNCOMMITTED)
                + " SALESHISTORYRF WITH (READUNCOMMITTED) "
                    // INNER JOIN 売上履歴明細データ WITH (READUNCOMMITTED) ON (
                + " INNER JOIN SALESHISTDTLRF WITH (READUNCOMMITTED) ON ( "
                    // 売上履歴データ.企業コード = 売上履歴明細データ.企業コード
                + " SALESHISTORYRF.ENTERPRISECODERF = SALESHISTDTLRF.ENTERPRISECODERF "
                    // 売上履歴データ.受注ステータス = 売上履歴明細データ.受注ステータス
                + " AND SALESHISTORYRF.ACPTANODRSTATUSRF = SALESHISTDTLRF.ACPTANODRSTATUSRF "
                    // 売上履歴データ.売上伝票番号 = 売上履歴明細データ.売上伝票番号
                + " AND SALESHISTORYRF.SALESSLIPNUMRF = SALESHISTDTLRF.SALESSLIPNUMRF "
                    // 売上履歴データ.論理削除区分 = 「0：有効」
                + " AND SALESHISTORYRF.LOGICALDELETECODERF = 0 "
                    // 売上履歴データ.受注ステータス = 「30：売上」
                + " AND SALESHISTORYRF.ACPTANODRSTATUSRF = 30  "
                    // 売上履歴データ.企業コード = ログイン担当者.企業コード
                + " AND SALESHISTORYRF.ENTERPRISECODERF = @FINDENTERPRISECODERF ";
                    // Prameterオブジェクトの作成
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                    // Parameterオブジェクトへ値設定
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.EnterpriseCode);

                    // 売上履歴データ.実績計上拠点コード = 画面.拠点コード
                    // 画面入力有り時
                if (!"00".Equals(carInfoConditionWorkWork.SectionCode))
                {
                    sqlStr += " AND SALESHISTORYRF.RESULTSADDUPSECCDRF = @FINDRESULTSADDUPSECCDRF ";
                    // Prameterオブジェクトの作成
                    SqlParameter paraResultsAddUpSecCd = sqlCommand.Parameters.Add("@FINDRESULTSADDUPSECCDRF", SqlDbType.NChar);
                    // Parameterオブジェクトへ値設定
                    paraResultsAddUpSecCd.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.SectionCode.Trim());
                }
                // 売上履歴データ.売上日付 >= 画面.売上日（開始）
                // 画面入力有り時
                if (carInfoConditionWorkWork.StSalesDate != 0)
                {
                    sqlStr += " AND SALESHISTORYRF.SALESDATERF >= @FINDSTSALESDATERF ";
                    // Prameterオブジェクトの作成
                    SqlParameter paraStSalesDate = sqlCommand.Parameters.Add("@FINDSTSALESDATERF", SqlDbType.Int);
                    // Parameterオブジェクトへ値設定
                    paraStSalesDate.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.StSalesDate);
                }
                // 売上履歴データ.売上日付 <= 画面.売上日（終了）
                // 画面入力有り時
                if (carInfoConditionWorkWork.EdSalesDate != 0)
                {
                    sqlStr += " AND SALESHISTORYRF.SALESDATERF <= @FINDEDSALESDATERF ";
                    // Prameterオブジェクトの作成
                    SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@FINDEDSALESDATERF", SqlDbType.Int);
                    // Parameterオブジェクトへ値設定
                    paraEdSalesDate.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.EdSalesDate);
                }
                // 売上履歴データ.伝票検索日付 >= 画面.入力日（開始）
                // 画面入力有り時
                if (carInfoConditionWorkWork.StInputDate != 0)
                {
                    sqlStr += " AND SALESHISTORYRF.SEARCHSLIPDATERF >= @FINDSTSEARCHSLIPDATERF ";
                    // Prameterオブジェクトの作成
                    SqlParameter paraStInputDate = sqlCommand.Parameters.Add("@FINDSTSEARCHSLIPDATERF", SqlDbType.Int);
                    // Parameterオブジェクトへ値設定
                    paraStInputDate.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.StInputDate);
                }
                // 売上履歴データ.伝票検索日付 <= 画面.入力日（終了）
                // 画面入力有り時
                if (carInfoConditionWorkWork.EdInputDate != 0)
                {
                    sqlStr += " AND SALESHISTORYRF.SEARCHSLIPDATERF <= @FINDEDSEARCHSLIPDATERF ";
                    // Prameterオブジェクトの作成
                    SqlParameter paraEdInputDate = sqlCommand.Parameters.Add("@FINDEDSEARCHSLIPDATERF", SqlDbType.Int);
                    // Parameterオブジェクトへ値設定
                    paraEdInputDate.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.EdInputDate);
                }
                // 売上履歴データ.得意先コード = 画面.得意先コード
                // 画面入力有り時
                if (carInfoConditionWorkWork.CustomerCode != 0)
                {
                    sqlStr += " AND SALESHISTORYRF.CUSTOMERCODERF = @FINDCUSTOMERCODERF ";
                    // Prameterオブジェクトの作成
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODERF", SqlDbType.Int);
                    // Parameterオブジェクトへ値設定
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.CustomerCode);
                }
                // 売上履歴明細データ.論理削除区分 = 「0：有効」
                sqlStr += " AND SALESHISTDTLRF.LOGICALDELETECODERF = 0 "
                    // （ 売上履歴明細データ.売上伝票区分（明細）= 「0：売上」
                    //    OR 売上履歴明細データ.売上伝票区分（明細）= 「1：返品」)
                + " AND (SALESHISTDTLRF.SALESSLIPCDDTLRF = 0 OR SALESHISTDTLRF.SALESSLIPCDDTLRF = 1) ";
                    // 売上履歴明細データ.BLグループコード = 画面.BLグループコード
                    // 画面入力有り時
                    if (carInfoConditionWorkWork.BLGroupCode != 0)
                    {
                        sqlStr += " AND SALESHISTDTLRF.BLGROUPCODERF = @FINDBLGROUPCODERF ";
                        // Prameterオブジェクトの作成
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODERF", SqlDbType.Int);
                        // Parameterオブジェクトへ値設定
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.BLGroupCode);
                    }
                    // 売上履歴明細データ.BL商品コード = 画面.BL商品コード
                    // 画面入力有り時
                    if (carInfoConditionWorkWork.BLGoodsCode != 0)
                    {
                        sqlStr += " AND SALESHISTDTLRF.BLGOODSCODERF = @FINDBLGOODSCODERF ";
                        // Prameterオブジェクトの作成
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODERF", SqlDbType.Int);
                        // Parameterオブジェクトへ値設定
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.BLGoodsCode);
                    }
                    // 売上履歴明細データ.倉庫コード = 画面.倉庫コード
                    // 画面入力有り時
                    if (!string.IsNullOrEmpty(carInfoConditionWorkWork.WarehouseCode))
                    {
                        sqlStr += " AND SALESHISTDTLRF.WAREHOUSECODERF = @FINDWAREHOUSECODERF ";
                        // Prameterオブジェクトの作成
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODERF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.WarehouseCode.Trim());
                    }
                    // 画面の在庫取寄区分が「取寄」を選択の場合
                    // 売上履歴明細データ.売上在庫取寄せ区分 = 「1：在庫」
                    if (carInfoConditionWorkWork.SalesOrderDivCd == 1)
                    {
                        sqlStr += " AND SALESHISTDTLRF.SALESORDERDIVCDRF = 1 ";
                    }
                    // 画面の在庫取寄区分が「在庫」を選択の場合
                    // 売上履歴明細データ.売上在庫取寄せ区分 = 「0：取寄」
                    else if (carInfoConditionWorkWork.SalesOrderDivCd == 2)
                    {
                        sqlStr += " AND SALESHISTDTLRF.SALESORDERDIVCDRF = 0 ";
                    }
                    // 画面の品名が入力有り時
                    if (!string.IsNullOrEmpty(carInfoConditionWorkWork.GoodsName))
                    {
                        // 画面の品名検索区分が「と一致」を選択の場合
                        // 売上履歴明細データ.商品名称 = 画面.品名
                        if (carInfoConditionWorkWork.GoodsNameDiv == 0)
                        {
                            // 完全一致の場合
                            sqlStr += "  AND SALESHISTDTLRF.GOODSNAMERF = @FINDGOODSNAMERF ";
                            // Prameterオブジェクトの作成
                            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAMERF", SqlDbType.NChar);
                            // Parameterオブジェクトへ値設定
                            paraGoodsName.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.GoodsName.Trim());
                        }
                        // 画面の品名検索区分が「で始まる」を選択の場合
                        // 売上履歴明細データ.商品名称 LIKE 画面.品名+% 
                        else if (carInfoConditionWorkWork.GoodsNameDiv == 1)
                        {
                            // 前方一致の場合
                            sqlStr += "  AND SALESHISTDTLRF.GOODSNAMERF LIKE @FINDGOODSNAMERF ";
                            // Prameterオブジェクトの作成
                            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAMERF", SqlDbType.NChar);
                            // Parameterオブジェクトへ値設定
                            paraGoodsName.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.GoodsName.Trim() + "%");
                        }
                        // 画面の品名検索区分が「を含む」を選択の場合
                        // 売上履歴明細データ.商品名称 LIKE %+画面.品名+%
                        else if (carInfoConditionWorkWork.GoodsNameDiv == 2)
                        {
                            // 含みの場合
                            sqlStr += "  AND SALESHISTDTLRF.GOODSNAMERF LIKE @FINDGOODSNAMERF";
                            // Prameterオブジェクトの作成
                            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAMERF", SqlDbType.NChar);
                            // Parameterオブジェクトへ値設定
                            paraGoodsName.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.GoodsName.Trim() + "%");
                        }
                        // 画面の品名検索区分が「で終わる」を選択の場合
                        // 売上履歴明細データ.商品名称 LIKE %+画面.品名
                        else
                        {
                            // 後方一致の場合
                            sqlStr += "  AND SALESHISTDTLRF.GOODSNAMERF LIKE @FINDGOODSNAMERF";
                            // Prameterオブジェクトの作成
                            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAMERF", SqlDbType.NChar);
                            // Parameterオブジェクトへ値設定
                            paraGoodsName.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.GoodsName.Trim());
                        }
                    }
                    // 画面の品番が入力有り時
                    if (!string.IsNullOrEmpty(carInfoConditionWorkWork.GoodsNo))
                    {
                        // 画面の品番検索区分が「と一致」を選択の場合
                        // 売上履歴明細データ.商品番号 = 画面.品番
                        if (carInfoConditionWorkWork.GoodsNoDiv == 0)
                        {
                            // 完全一致の場合
                            sqlStr += "  AND SALESHISTDTLRF.GOODSNORF = @FINDGOODSNORF ";
                            // Prameterオブジェクトの作成
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNORF", SqlDbType.NChar);
                            // Parameterオブジェクトへ値設定
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.GoodsNo.Trim());
                        }
                        // 画面の品番検索区分が「で始まる」を選択の場合
                        // 売上履歴明細データ.商品番号 LIKE 画面.品番+% 
                        else if (carInfoConditionWorkWork.GoodsNoDiv == 1)
                        {
                            // 前方一致の場合
                            sqlStr += "  AND SALESHISTDTLRF.GOODSNORF LIKE @FINDGOODSNORF ";
                            // Prameterオブジェクトの作成
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNORF", SqlDbType.NChar);
                            // Parameterオブジェクトへ値設定
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.GoodsNo.Trim() + "%");
                        }
                        // 画面の品番検索区分が「を含む」を選択の場合
                        // 売上履歴明細データ.商品番号 LIKE %+画面.品番+%
                        else if (carInfoConditionWorkWork.GoodsNoDiv == 2)
                        {
                            // 含みの場合
                            sqlStr += "  AND SALESHISTDTLRF.GOODSNORF LIKE @FINDGOODSNORF";
                            // Prameterオブジェクトの作成
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNORF", SqlDbType.NChar);
                            // Parameterオブジェクトへ値設定
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.GoodsNo.Trim() + "%");
                        }
                        // 画面の品名検索区分が「で終わる」を選択の場合
                        // 売上履歴明細データ.商品番号 LIKE %+画面.品番
                        else
                        {
                            // 後方一致の場合
                            sqlStr += "  AND SALESHISTDTLRF.GOODSNORF LIKE @FINDGOODSNORF";
                            // Prameterオブジェクトの作成
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNORF", SqlDbType.NChar);
                            // Parameterオブジェクトへ値設定
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.GoodsNo.Trim());
                        }
                    }

                    sqlStr += " ) ";

                    // INNER JOIN 受注マスタ(車輌) WITH (READUNCOMMITTED) ON (
                    sqlStr += " INNER JOIN ACCEPTODRCARRF WITH (READUNCOMMITTED) ON ( "
                        // 売上履歴明細データ.企業コード = 受注マスタ(車輌).企業コード
                    + " SALESHISTDTLRF.ENTERPRISECODERF = ACCEPTODRCARRF.ENTERPRISECODERF "
                            // 売上履歴明細データ.受注番号 = 受注マスタ(車輌).受注番号
                    + " AND SALESHISTDTLRF.ACCEPTANORDERNORF = ACCEPTODRCARRF.ACCEPTANORDERNORF "
                            // 売上履歴明細データ.受注ステータス = 「30：売上」
                    + " AND SALESHISTDTLRF.ACPTANODRSTATUSRF = 30 "
                            // （ 受注マスタ(車輌).受注ステータス = 「7：売上」OR 受注マスタ(車輌).受注ステータス = 「8：返品」 ）
                    + " AND (ACCEPTODRCARRF.ACPTANODRSTATUSRF = 7 OR ACCEPTODRCARRF.ACPTANODRSTATUSRF = 8) "
                        // 受注マスタ(車輌).データ入力システム = 「10：PM」
                    + " AND ACCEPTODRCARRF.DATAINPUTSYSTEMRF = 10 "
                    // 受注マスタ(車輌).車両管理番号 <> 0
                    +" AND ACCEPTODRCARRF.CARMNGNORF <> 0 "
                     // 受注マスタ(車輌).論理削除区分 = 「0：有効」
                    + " AND ACCEPTODRCARRF.LOGICALDELETECODERF = 0 ";
                    // 内部で保持の車両管理番号≠0の場合、受注マスタ(車輌).車両管理番号 = 画面.車両管理番号
                    if (carInfoConditionWorkWork.CarMngNo != 0)
                    {
                        sqlStr += " AND ACCEPTODRCARRF.CARMNGNORF = @FINDCARMNGNORF ";
                        // Prameterオブジェクトの作成
                        SqlParameter paraCarMngNo = sqlCommand.Parameters.Add("@FINDCARMNGNORF", SqlDbType.Int);
                        // Parameterオブジェクトへ値設定
                        paraCarMngNo.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.CarMngNo);
                    }

                        // 画面の型式が入力有り時
                        if (!string.IsNullOrEmpty(carInfoConditionWorkWork.FullModel))
                        {
                            // 画面の型式検索区分が「と一致」を選択の場合
                            // 受注マスタ（車両）.シリーズ型式 + '-' + 受注マスタ（車両）.型式（類別記号） = 画面.型式
                            if (carInfoConditionWorkWork.FullModelDiv == 0)
                            {
                                // 完全一致の場合
                                sqlStr += " AND ISNULL(ACCEPTODRCARRF.SERIESMODELRF, '') + '-' + ISNULL(ACCEPTODRCARRF.CATEGORYSIGNMODELRF, '') = @FINDFULLMODELRF ";
                                // Prameterオブジェクトの作成
                                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FINDFULLMODELRF", SqlDbType.NChar);
                                // Parameterオブジェクトへ値設定
                                paraFullModel.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.FullModel.Trim());
                            }
                            // 画面の型式検索区分が「で始まる」を選択の場合
                            // 受注マスタ（車両）.シリーズ型式 + '-' + 受注マスタ（車両）.型式（類別記号） LIKE 画面.型式+% 
                            else if (carInfoConditionWorkWork.FullModelDiv == 1)
                            {
                                // 前方一致の場合
                                sqlStr += " AND ISNULL(ACCEPTODRCARRF.SERIESMODELRF, '') + '-' + ISNULL(ACCEPTODRCARRF.CATEGORYSIGNMODELRF, '') LIKE @FINDFULLMODELRF ";
                                // Prameterオブジェクトの作成
                                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FINDFULLMODELRF", SqlDbType.NChar);
                                // Parameterオブジェクトへ値設定
                                paraFullModel.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.FullModel.Trim() + "%");
                            }
                            // 画面の型式検索区分が「を含む」を選択の場合
                            // 受注マスタ（車両）.シリーズ型式 + '-' + 受注マスタ（車両）.型式（類別記号） LIKE %+画面.型式+%
                            else if (carInfoConditionWorkWork.FullModelDiv == 2)
                            {
                                // 含みの場合
                                sqlStr += " AND ISNULL(ACCEPTODRCARRF.SERIESMODELRF, '') + '-' + ISNULL(ACCEPTODRCARRF.CATEGORYSIGNMODELRF, '') LIKE @FINDFULLMODELRF";
                                // Prameterオブジェクトの作成
                                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FINDFULLMODELRF", SqlDbType.NChar);
                                // Parameterオブジェクトへ値設定
                                paraFullModel.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.FullModel.Trim() + "%");
                            }
                            // 画面の型式検索区分が「で終わる」を選択の場合
                            // 受注マスタ（車両）.シリーズ型式 + '-' + 受注マスタ（車両）.型式（類別記号） LIKE %+画面.型式
                            else
                            {
                                // 後方一致の場合
                                sqlStr += " AND ISNULL(ACCEPTODRCARRF.SERIESMODELRF, '') + '-' + ISNULL(ACCEPTODRCARRF.CATEGORYSIGNMODELRF, '') LIKE @FINDFULLMODELRF";
                                // Prameterオブジェクトの作成
                                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FINDFULLMODELRF", SqlDbType.NChar);
                                // Parameterオブジェクトへ値設定
                                paraFullModel.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.FullModel.Trim());
                            }
                        }
                        // 画面の車輌備考が入力有り時
                        if (!string.IsNullOrEmpty(carInfoConditionWorkWork.CarNote))
                        {
                            // 画面の車輌備考検索区分が「と一致」を選択の場合
                            // 受注マスタ(車輌).車輌備考 = 画面.車輌備考
                            if (carInfoConditionWorkWork.CarNoteDiv == 0)
                            {
                                // 完全一致の場合
                                sqlStr += "  AND ACCEPTODRCARRF.CARNOTERF = @FINDCARNOTERF ";
                                // Prameterオブジェクトの作成
                                SqlParameter paraCarNote = sqlCommand.Parameters.Add("@FINDCARNOTERF", SqlDbType.NChar);
                                // Parameterオブジェクトへ値設定
                                paraCarNote.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.CarNote.Trim());
                            }
                            // 画面の車輌備考検索区分が「で始まる」を選択の場合
                            // 受注マスタ(車輌).車輌備考 LIKE 画面.車輌備考+% 
                            else if (carInfoConditionWorkWork.CarNoteDiv == 1)
                            {
                                // 前方一致の場合
                                sqlStr += "  AND ACCEPTODRCARRF.CARNOTERF LIKE @FINDCARNOTERF ";
                                // Prameterオブジェクトの作成
                                SqlParameter paraCarNote = sqlCommand.Parameters.Add("@FINDCARNOTERF", SqlDbType.NChar);
                                // Parameterオブジェクトへ値設定
                                paraCarNote.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.CarNote.Trim() + "%");
                            }
                            // 画面の車輌備考検索区分が「を含む」を選択の場合
                            // 受注マスタ(車輌).車輌備考 LIKE %+画面.車輌備考+%
                            else if (carInfoConditionWorkWork.CarNoteDiv == 2)
                            {
                                // 含みの場合
                                sqlStr += "  AND ACCEPTODRCARRF.CARNOTERF LIKE @FINDCARNOTERF";
                                // Prameterオブジェクトの作成
                                SqlParameter paraCarNote = sqlCommand.Parameters.Add("@FINDCARNOTERF", SqlDbType.NChar);
                                // Parameterオブジェクトへ値設定
                                paraCarNote.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.CarNote.Trim() + "%");
                            }
                            // 画面の車輌備考検索区分が「で終わる」を選択の場合
                            // 受注マスタ(車輌).車輌備考 LIKE %+画面.車輌備考
                            else
                            {
                                // 後方一致の場合
                                sqlStr += "  AND ACCEPTODRCARRF.CARNOTERF LIKE @FINDCARNOTERF";
                                // Prameterオブジェクトの作成
                                SqlParameter paraCarNote = sqlCommand.Parameters.Add("@FINDCARNOTERF", SqlDbType.NChar);
                                // Parameterオブジェクトへ値設定
                                paraCarNote.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.CarNote.Trim());
                            }
                        }
                        // 画面の管理番号が入力有り時
                        if (!string.IsNullOrEmpty(carInfoConditionWorkWork.CarMngCode))
                        {
                            // 画面の管理番号検索区分が「と一致」を選択の場合
                            // 受注マスタ(車輌).車輌管理コード = 画面.管理番号
                            if (carInfoConditionWorkWork.CarMngCodeDiv == 0)
                            {
                                // 完全一致の場合
                                sqlStr += "  AND ACCEPTODRCARRF.CARMNGCODERF = @FINDCARMNGCODERF ";
                                // Prameterオブジェクトの作成
                                SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODERF", SqlDbType.NChar);
                                // Parameterオブジェクトへ値設定
                                paraCarMngCode.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.CarMngCode.Trim());
                            }
                            // 画面の管理番号検索区分が「で始まる」を選択の場合
                            // 受注マスタ(車輌).車輌管理コード LIKE 画面.管理番号+% 
                            else if (carInfoConditionWorkWork.CarMngCodeDiv == 1)
                            {
                                // 前方一致の場合
                                sqlStr += "  AND ACCEPTODRCARRF.CARMNGCODERF LIKE @FINDCARMNGCODERF ";
                                // Prameterオブジェクトの作成
                                SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODERF", SqlDbType.NChar);
                                // Parameterオブジェクトへ値設定
                                paraCarMngCode.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.CarMngCode.Trim() + "%");
                            }
                            // 画面の管理番号検索区分が「を含む」を選択の場合
                            // 受注マスタ(車輌).車輌管理コード LIKE %+画面.管理番号+%
                            else if (carInfoConditionWorkWork.CarMngCodeDiv == 2)
                            {
                                // 含みの場合
                                sqlStr += "  AND ACCEPTODRCARRF.CARMNGCODERF LIKE @FINDCARMNGCODERF";
                                // Prameterオブジェクトの作成
                                SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODERF", SqlDbType.NChar);
                                // Parameterオブジェクトへ値設定
                                paraCarMngCode.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.CarMngCode.Trim() + "%");
                            }
                            // 画面の管理番号検索区分が「で終わる」を選択の場合
                            // 受注マスタ(車輌).車輌管理コード LIKE %+画面.管理番号
                            else
                            {
                                // 後方一致の場合
                                sqlStr += "  AND ACCEPTODRCARRF.CARMNGCODERF LIKE @FINDCARMNGCODERF";
                                // Prameterオブジェクトの作成
                                SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODERF", SqlDbType.NChar);
                                // Parameterオブジェクトへ値設定
                                paraCarMngCode.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.CarMngCode.Trim());
                            }
                        }

                sqlStr += " ) ";

                // INNER JOIN 車輌管理マスタ WITH (READUNCOMMITTED) ON (
                sqlStr += " INNER JOIN CARMANAGEMENTRF WITH (READUNCOMMITTED) ON ( "
                    // 売上履歴データ.企業コード = 車輌管理マスタ.企業コード
                    + " SALESHISTORYRF.ENTERPRISECODERF = CARMANAGEMENTRF.ENTERPRISECODERF "
                    // 売上履歴データ.得意先コード = 車輌管理マスタ.得意先コード
                    + " AND SALESHISTORYRF.CUSTOMERCODERF = CARMANAGEMENTRF.CUSTOMERCODERF "
                    // 受注マスタ(車輌).車両管理番号 = 車輌管理マスタ.車両管理番号
                    + " AND ACCEPTODRCARRF.CARMNGNORF = CARMANAGEMENTRF.CARMNGNORF "
                    // 受注マスタ(車輌).車両管理番号 = 車輌管理マスタ.車両管理番号 // 2009/12/24
                    + " AND ACCEPTODRCARRF.CARMNGCODERF = CARMANAGEMENTRF.CARMNGCODERF " // 2009/12/24
                    // 車輌管理マスタ.論理削除区分 = 「0：有効」
                    + " AND CARMANAGEMENTRF.LOGICALDELETECODERF = 0) ";
                // LEFT JOIN メーカーマスタ（ユーザー登録） WITH (READUNCOMMITTED) ON (
                sqlStr += " LEFT JOIN MAKERURF WITH (READUNCOMMITTED) ON ( "
                    // 売上履歴明細データ.企業コード = メーカーマスタ（ユーザー登録）.企業コード
                    + " SALESHISTDTLRF.ENTERPRISECODERF = MAKERURF.ENTERPRISECODERF "
                    // 売上履歴明細データ.商品メーカーコード = メーカーマスタ（ユーザー登録）.商品メーカーコード
                    + " AND SALESHISTDTLRF.GOODSMAKERCDRF = MAKERURF.GOODSMAKERCDRF "
                    // メーカーマスタ（ユーザー登録）.論理削除区分 = 「0：有効」
                    + " AND MAKERURF.LOGICALDELETECODERF = 0) ";
                // LEFT JOIN 在庫マスタ WITH (READUNCOMMITTED) ON (
                sqlStr += " LEFT JOIN STOCKRF WITH (READUNCOMMITTED) ON ( "
                    // 売上履歴明細データ.企業コード = 在庫マスタ.企業コード
                    + " SALESHISTDTLRF.ENTERPRISECODERF = STOCKRF.ENTERPRISECODERF "
                    // 売上履歴明細データ.商品メーカーコード = 在庫マスタ.商品メーカーコード
                    + " AND SALESHISTDTLRF.GOODSMAKERCDRF = STOCKRF.GOODSMAKERCDRF "
                    // 売上履歴明細データ.商品番号 = 在庫マスタ.商品番号
                    + " AND SALESHISTDTLRF.GOODSNORF = STOCKRF.GOODSNORF "
                    // 売上履歴明細データ.倉庫コード = 在庫マスタ.倉庫コード
                    + " AND SALESHISTDTLRF.WAREHOUSECODERF = STOCKRF.WAREHOUSECODERF "
                    // 在庫マスタ.論理削除区分 = 「0：有効」
                    + " AND STOCKRF.LOGICALDELETECODERF = 0) ";

                // sqlStr += " UNION "  // DEL 2009/10/20 Redmin#749対応
                sqlStr += " UNION ALL " // ADD 2009/10/20 Redmin#749対応
                + " SELECT "
                + " ACCEPTODRCARRF.CARMNGCODERF, "                // ADD 2009/10/10 受注マスタ(車輌).車輌管理コード
                + " CNVCARPARTSRF.SALESDATERF, "                // 車輌部品データ(コンバート).売上日付
                + " CNVCARPARTSRF.DTLNOTERF AS NOTERF, "                // 車輌部品データ(コンバート).明細備考
                + " CNVCARPARTSRF.SALESSLIPNUMRF, "                // 車輌部品データ(コンバート).売上伝票番号
                + " CNVCARPARTSRF.GOODSNAMERF, "                // 車輌部品データ(コンバート).商品名称
                + " CNVCARPARTSRF.GOODSNORF, "                // 車輌部品データ(コンバート).商品番号
                + " CNVCARPARTSRF.GOODSMAKERCDRF, "                // 車輌部品データ(コンバート).商品メーカーコード
                + " CNVCARPARTSRF.BLGOODSCODERF, "                // 車輌部品データ(コンバート).BL商品コード
                + " NULL AS WAREHOUSECODERF, "                // NULL.倉庫コード
                + " NULL AS WAREHOUSESHELFNORF, "                // NULL.倉庫棚番
                + " CNVCARPARTSRF.SALESROWNORF,"              //行番号　//ADD BY 凌小青 on 2012/08/09 for Redmine#31532
                + " CNVCARPARTSRF.SALESORDERDIVCDRF, "                // 車輌部品データ(コンバート).売上在庫取寄せ区分
                + " CNVCARPARTSRF.LISTPRICETAXEXCFLRF, "                // 車輌部品データ(コンバート).定価（税抜，浮動）
                + " CNVCARPARTSRF.SHIPMENTCNTRF, "                // 車輌部品データ(コンバート).出荷数
                + " CNVCARPARTSRF.SALESUNPRCTAXEXCFLRF, "                // 車輌部品データ(コンバート).売上単価（税抜，浮動）
                + " CNVCARPARTSRF.SALESMONEYTAXEXCRF, "                // 車輌部品データ(コンバート).売上金額（税抜き）
                + " CNVCARPARTSRF.SALESUNITCOSTRF, "                // 車輌部品データ(コンバート).原価単価
                + " CNVCARPARTSRF.GROSSPROFITRF, "                // 車輌部品データ(コンバート).粗利金額 // ADD 2009/10/10
                + " NULL AS WAREHOUSENAMERF, "                // NULL.倉庫名称
                + " -999999999 AS COSTRF, "                           // -999999999.原価
                + " 0 AS SALESSLIPCDDTLRF, "            // 0.売上伝票区分（明細） // ADD 2009/10/23
                + " ACCEPTODRCARRF.CARNOTERF, "                // 受注マスタ（車両）.車輌備考
                + " ACCEPTODRCARRF.MILEAGERF, "                // 受注マスタ（車両）.走行距離
                + " ACCEPTODRCARRF.MODELDESIGNATIONNORF, "                // 受注マスタ（車両）.型式指定番号
                + " ACCEPTODRCARRF.CATEGORYNORF, "                // 受注マスタ（車両）.類別番号
                + " ACCEPTODRCARRF.ENGINEMODELNMRF, "                // 受注マスタ（車両）.エンジン型式名称
                + " ACCEPTODRCARRF.FULLMODELRF, "                // 受注マスタ（車両）.型式（フル型）
                + " ACCEPTODRCARRF.MAKERCODERF, "                // 受注マスタ（車両）.メーカーコード
                + " ACCEPTODRCARRF.MODELCODERF, "                // 受注マスタ（車両）.車種コード
                + " ACCEPTODRCARRF.MODELSUBCODERF, "                // 受注マスタ（車両）.車種サブコード
                + " ACCEPTODRCARRF.MODELFULLNAMERF, "                // 受注マスタ（車両）.車種全角名称
                + " ACCEPTODRCARRF.MODELHALFNAMERF, "                // 受注マスタ（車両）.車種半角名称
                + " ACCEPTODRCARRF.FIRSTENTRYDATERF, "                // 受注マスタ（車両）.初年度
                + " ACCEPTODRCARRF.FRAMENORF, "                // 受注マスタ（車両）.車台番号
                + " ACCEPTODRCARRF.COLORCODERF, "                // 受注マスタ（車両）.カラーコード
                + " ACCEPTODRCARRF.COLORNAME1RF, "                // 受注マスタ（車両）.カラー名称1
                + " ACCEPTODRCARRF.TRIMCODERF, "                // 受注マスタ（車両）.トリムコード
                + " ACCEPTODRCARRF.TRIMNAMERF, "                // 受注マスタ（車両）.トリム名称
                + " ACCEPTODRCARRF.NUMBERPLATE1CODERF, "                // 受注マスタ（車両）.陸運事務所番号
                + " ACCEPTODRCARRF.NUMBERPLATE1NAMERF, "                // 受注マスタ（車両）.陸運事務局名称
                + " ACCEPTODRCARRF.NUMBERPLATE2RF, "                // 受注マスタ（車両）.車両登録番号（種別）
                + " ACCEPTODRCARRF.NUMBERPLATE3RF, "                // 受注マスタ（車両）.車両登録番号（カナ）
                + " ACCEPTODRCARRF.NUMBERPLATE4RF, "                // 受注マスタ（車両）.車両登録番号（プレート番号）
                + " ACCEPTODRCARRF.DOMESTICFOREIGNCODERF, "                // 受注マスタ（車両）.国産／外車区分 // ADD 2013/03/25
                + " CARMANAGEMENTRF.SERIESMODELRF, "               // 車輌管理マスタ.シリーズ型式
                + " CARMANAGEMENTRF.CATEGORYSIGNMODELRF, "               // 車輌管理マスタ.型式（類別記号）
                + " CARMANAGEMENTRF.STPRODUCETYPEOFYEARRF, "               // 車輌管理マスタ.開始生産年式
                + " CARMANAGEMENTRF.EDPRODUCETYPEOFYEARRF, "               // 車輌管理マスタ.終了生産年式
                + " CARMANAGEMENTRF.STPRODUCEFRAMENORF, "               // 車輌管理マスタ.生産車台番号開始
                + " CARMANAGEMENTRF.EDPRODUCEFRAMENORF, "               // 車輌管理マスタ.生産車台番号終了
                + " CARMANAGEMENTRF.MODELGRADENMRF, "               // 車輌管理マスタ.型式グレード名称
                + " CARMANAGEMENTRF.ENGINEMODELRF, "               // 車輌管理マスタ.原動機型式（エンジン）
                + " CARMANAGEMENTRF.BODYNAMERF, "               // 車輌管理マスタ.ボディー名称
                + " CARMANAGEMENTRF.DOORCOUNTRF, "               // 車輌管理マスタ.ドア数
                    //+ " CARMANAGEMENTRF.ENGINEMODELNMRF, "               // 車輌管理マスタ.エンジン型式名称
                + " CARMANAGEMENTRF.ENGINEDISPLACENMRF, "               // 車輌管理マスタ.排気量名称
                + " CARMANAGEMENTRF.EDIVNMRF, "               // 車輌管理マスタ.E区分名称
                + " CARMANAGEMENTRF.TRANSMISSIONNMRF, "               // 車輌管理マスタ.ミッション名称
                + " CARMANAGEMENTRF.WHEELDRIVEMETHODNMRF, "               // 車輌管理マスタ.駆動方式名称
                + " CARMANAGEMENTRF.SHIFTNMRF, "               // 車輌管理マスタ.シフト名称
                + " CARMANAGEMENTRF.ADDICARSPECTITLE1RF, "               // 車輌管理マスタ.追加諸元タイトル1
                + " CARMANAGEMENTRF.ADDICARSPECTITLE2RF, "               // 車輌管理マスタ.追加諸元タイトル2
                + " CARMANAGEMENTRF.ADDICARSPECTITLE3RF, "               // 車輌管理マスタ.追加諸元タイトル3
                + " CARMANAGEMENTRF.ADDICARSPECTITLE4RF, "               // 車輌管理マスタ.追加諸元タイトル4
                + " CARMANAGEMENTRF.ADDICARSPECTITLE5RF, "               // 車輌管理マスタ.追加諸元タイトル5
                + " CARMANAGEMENTRF.ADDICARSPECTITLE6RF, "               // 車輌管理マスタ.追加諸元タイトル6
                + " CARMANAGEMENTRF.ADDICARSPEC1RF, "               // 車輌管理マスタ.追加諸元1
                + " CARMANAGEMENTRF.ADDICARSPEC2RF, "               // 車輌管理マスタ.追加諸元2
                + " CARMANAGEMENTRF.ADDICARSPEC3RF, "               // 車輌管理マスタ.追加諸元3
                + " CARMANAGEMENTRF.ADDICARSPEC4RF, "               // 車輌管理マスタ.追加諸元4
                + " CARMANAGEMENTRF.ADDICARSPEC5RF, "               // 車輌管理マスタ.追加諸元5
                + " CARMANAGEMENTRF.ADDICARSPEC6RF, "               // 車輌管理マスタ.追加諸元6
                + " MAKERURF.MAKERNAMERF, "                // メーカーマスタ（ユーザー登録）.メーカー名称
                + " 0 AS SHIPMENTPOSCNTRF, "                   // 0.出荷可能数
                + " CNVCARPARTSRF.ACPTANODRSTATUSRF " // 車輌部品データ(コンバート).受注ステータス
                + " FROM "
                    // 車輌部品データ(コンバート) WITH (READUNCOMMITTED)
                + " CNVCARPARTSRF WITH (READUNCOMMITTED) "
                    // INNER JOIN 受注マスタ(車輌) WITH (READUNCOMMITTED) ON (
                + " INNER JOIN ACCEPTODRCARRF WITH (READUNCOMMITTED) ON ( "
                    // 車輌部品データ.企業コード = 受注マスタ(車輌).企業コード
                + " CNVCARPARTSRF.ENTERPRISECODERF = ACCEPTODRCARRF.ENTERPRISECODERF "
                    // 車輌部品データ.受注番号 = 受注マスタ(車輌).受注番号
                + " AND CNVCARPARTSRF.ACCEPTANORDERNORF = ACCEPTODRCARRF.ACCEPTANORDERNORF "
                    // 車輌部品データ.受注ステータス = 受注マスタ(車輌).受注ステータス
                + " AND CNVCARPARTSRF.ACPTANODRSTATUSRF = ACCEPTODRCARRF.ACPTANODRSTATUSRF "
                    // 車輌部品データ.論理削除区分 = 「0：有効」
                + " AND CNVCARPARTSRF.LOGICALDELETECODERF = 0 "
                    // （ 車輌部品データ.受注ステータス = 「7：売上」OR 車輌部品データ.受注ステータス = 「8：返品」)
                + " AND (CNVCARPARTSRF.ACPTANODRSTATUSRF = 7 OR CNVCARPARTSRF.ACPTANODRSTATUSRF = 8) "
                    // 車輌部品データ.企業コード = ログイン担当者.企業コード
                + " AND CNVCARPARTSRF.ENTERPRISECODERF = @FINDENTERPRISECODE2RF ";
                // Prameterオブジェクトの作成
                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE2RF", SqlDbType.NChar);
                // Parameterオブジェクトへ値設定
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.EnterpriseCode);

                // 車輌部品データ.実績計上拠点コード = 画面.拠点コード
                // 画面入力有り時
                if (!"00".Equals(carInfoConditionWorkWork.SectionCode))
                {
                    sqlStr += " AND CNVCARPARTSRF.RESULTSADDUPSECCDRF = @FINDRESULTSADDUPSECCD2RF ";
                    // Prameterオブジェクトの作成
                    SqlParameter paraResultsAddUpSecCd2 = sqlCommand.Parameters.Add("@FINDRESULTSADDUPSECCD2RF", SqlDbType.NChar);
                    // Parameterオブジェクトへ値設定
                    paraResultsAddUpSecCd2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.SectionCode.Trim());
                }
                // 車輌部品データ.売上日付 >= 画面.売上日（開始）
                // 画面入力有り時
                if (carInfoConditionWorkWork.StSalesDate != 0)
                {
                    sqlStr += " AND CNVCARPARTSRF.SALESDATERF >= @FINDSTSALESDATE2RF ";
                    // Prameterオブジェクトの作成
                    SqlParameter paraStSalesDate2 = sqlCommand.Parameters.Add("@FINDSTSALESDATE2RF", SqlDbType.Int);
                    // Parameterオブジェクトへ値設定
                    paraStSalesDate2.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.StSalesDate);
                }
                // 車輌部品データ.売上日付 <= 画面.売上日（終了）
                // 画面入力有り時
                if (carInfoConditionWorkWork.EdSalesDate != 0)
                {
                    sqlStr += " AND CNVCARPARTSRF.SALESDATERF <= @FINDEDSALESDATE2RF ";
                    // Prameterオブジェクトの作成
                    SqlParameter paraEdSalesDate2 = sqlCommand.Parameters.Add("@FINDEDSALESDATE2RF", SqlDbType.Int);
                    // Parameterオブジェクトへ値設定
                    paraEdSalesDate2.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.EdSalesDate);
                }
                // 車輌部品データ.売上日付 >= 画面.入力日（開始）
                // 画面入力有り時
                if (carInfoConditionWorkWork.StInputDate != 0)
                {
                    sqlStr += " AND CNVCARPARTSRF.SALESDATERF >= @FINDSTSEARCHSLIPDATE2RF ";
                    // Prameterオブジェクトの作成
                    SqlParameter paraStInputDate2 = sqlCommand.Parameters.Add("@FINDSTSEARCHSLIPDATE2RF", SqlDbType.Int);
                    // Parameterオブジェクトへ値設定
                    paraStInputDate2.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.StInputDate);
                }
                // 車輌部品データ.売上日付 <= 画面.入力日（終了）
                // 画面入力有り時
                if (carInfoConditionWorkWork.EdInputDate != 0)
                {
                    sqlStr += " AND CNVCARPARTSRF.SALESDATERF <= @FINDEDSEARCHSLIPDATE2RF ";
                    // Prameterオブジェクトの作成
                    SqlParameter paraEdInputDate2 = sqlCommand.Parameters.Add("@FINDEDSEARCHSLIPDATE2RF", SqlDbType.Int);
                    // Parameterオブジェクトへ値設定
                    paraEdInputDate2.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.EdInputDate);
                }
                // 車輌部品データ.得意先コード = 画面.得意先コード
                // 画面入力有り時
                if (carInfoConditionWorkWork.CustomerCode != 0)
                {
                    sqlStr += " AND CNVCARPARTSRF.CUSTOMERCODERF = @FINDCUSTOMERCODE2RF ";
                    // Prameterオブジェクトの作成
                    SqlParameter paraCustomerCode2 = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE2RF", SqlDbType.Int);
                    // Parameterオブジェクトへ値設定
                    paraCustomerCode2.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.CustomerCode);
                }
                // 車輌部品データ.BLグループコード = 画面.BLグループコード
                // 画面入力有り時
                if (carInfoConditionWorkWork.BLGroupCode != 0)
                {
                    sqlStr += " AND CNVCARPARTSRF.BLGROUPCODERF = @FINDBLGROUPCODE2RF ";
                    // Prameterオブジェクトの作成
                    SqlParameter paraBLGroupCode2 = sqlCommand.Parameters.Add("@FINDBLGROUPCODE2RF", SqlDbType.Int);
                    // Parameterオブジェクトへ値設定
                    paraBLGroupCode2.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.BLGroupCode);
                }
                // 車輌部品データ.BL商品コード = 画面.BL商品コード
                // 画面入力有り時
                if (carInfoConditionWorkWork.BLGoodsCode != 0)
                {
                    sqlStr += " AND CNVCARPARTSRF.BLGOODSCODERF = @FINDBLGOODSCODE2RF ";
                    // Prameterオブジェクトの作成
                    SqlParameter paraBLGoodsCode2 = sqlCommand.Parameters.Add("@FINDBLGOODSCODE2RF", SqlDbType.Int);
                    // Parameterオブジェクトへ値設定
                    paraBLGoodsCode2.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.BLGoodsCode);
                }
                // 画面の在庫取寄区分が「取寄」を選択の場合
                // 車輌部品データ.売上在庫取寄せ区分 = 「1：在庫」
                if (carInfoConditionWorkWork.SalesOrderDivCd == 1)
                {
                    sqlStr += " AND CNVCARPARTSRF.SALESORDERDIVCDRF = 1 ";
                }
                // 画面の在庫取寄区分が「在庫」を選択の場合
                // 車輌部品データ.売上在庫取寄せ区分 = 「0：取寄」
                else if (carInfoConditionWorkWork.SalesOrderDivCd == 2)
                {
                    sqlStr += " AND CNVCARPARTSRF.SALESORDERDIVCDRF = 0 ";
                }
                // 画面の品名が入力有り時
                if (!string.IsNullOrEmpty(carInfoConditionWorkWork.GoodsName))
                {
                    // 画面の品名検索区分が「と一致」を選択の場合
                    // 車輌部品データ.商品名称 = 画面.品名
                    if (carInfoConditionWorkWork.GoodsNameDiv == 0)
                    {
                        // 完全一致の場合
                        sqlStr += "  AND CNVCARPARTSRF.GOODSNAMERF = @FINDGOODSNAME2RF ";
                        // Prameterオブジェクトの作成
                        SqlParameter paraGoodsName2 = sqlCommand.Parameters.Add("@FINDGOODSNAME2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraGoodsName2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.GoodsName.Trim());
                    }
                    // 画面の品名検索区分が「で始まる」を選択の場合
                    // 車輌部品データ.商品名称 LIKE 画面.品名+% 
                    else if (carInfoConditionWorkWork.GoodsNameDiv == 1)
                    {
                        // 前方一致の場合
                        sqlStr += "  AND CNVCARPARTSRF.GOODSNAMERF LIKE @FINDGOODSNAME2RF ";
                        // Prameterオブジェクトの作成
                        SqlParameter paraGoodsName2 = sqlCommand.Parameters.Add("@FINDGOODSNAME2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraGoodsName2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.GoodsName.Trim() + "%");
                    }
                    // 画面の品名検索区分が「を含む」を選択の場合
                    // 車輌部品データ.商品名称 LIKE %+画面.品名+%
                    else if (carInfoConditionWorkWork.GoodsNameDiv == 2)
                    {
                        // 含みの場合
                        sqlStr += "  AND CNVCARPARTSRF.GOODSNAMERF LIKE @FINDGOODSNAME2RF";
                        // Prameterオブジェクトの作成
                        SqlParameter paraGoodsName2 = sqlCommand.Parameters.Add("@FINDGOODSNAME2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraGoodsName2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.GoodsName.Trim() + "%");
                    }
                    // 画面の品名検索区分が「で終わる」を選択の場合
                    // 車輌部品データ.商品名称 LIKE %+画面.品名
                    else
                    {
                        // 後方一致の場合
                        sqlStr += "  AND CNVCARPARTSRF.GOODSNAMERF LIKE @FINDGOODSNAME2RF";
                        // Prameterオブジェクトの作成
                        SqlParameter paraGoodsName2 = sqlCommand.Parameters.Add("@FINDGOODSNAME2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraGoodsName2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.GoodsName.Trim());
                    }
                }
                // 画面の品番が入力有り時
                if (!string.IsNullOrEmpty(carInfoConditionWorkWork.GoodsNo))
                {
                    // 画面の品番検索区分が「と一致」を選択の場合
                    // 車輌部品データ.商品番号 = 画面.品番
                    if (carInfoConditionWorkWork.GoodsNoDiv == 0)
                    {
                        // 完全一致の場合
                        sqlStr += "  AND CNVCARPARTSRF.GOODSNORF = @FINDGOODSNO2RF ";
                        // Prameterオブジェクトの作成
                        SqlParameter paraGoodsNo2 = sqlCommand.Parameters.Add("@FINDGOODSNO2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraGoodsNo2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.GoodsNo.Trim());
                    }
                    // 画面の品番検索区分が「で始まる」を選択の場合
                    // 車輌部品データ.商品番号 LIKE 画面.品番+% 
                    else if (carInfoConditionWorkWork.GoodsNoDiv == 1)
                    {
                        // 前方一致の場合
                        sqlStr += "  AND CNVCARPARTSRF.GOODSNORF LIKE @FINDGOODSNO2RF ";
                        // Prameterオブジェクトの作成
                        SqlParameter paraGoodsNo2 = sqlCommand.Parameters.Add("@FINDGOODSNO2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraGoodsNo2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.GoodsNo.Trim() + "%");
                    }
                    // 画面の品番検索区分が「を含む」を選択の場合
                    // 車輌部品データ.商品番号 LIKE %+画面.品番+%
                    else if (carInfoConditionWorkWork.GoodsNoDiv == 2)
                    {
                        // 含みの場合
                        sqlStr += "  AND CNVCARPARTSRF.GOODSNORF LIKE @FINDGOODSNO2RF";
                        // Prameterオブジェクトの作成
                        SqlParameter paraGoodsNo2 = sqlCommand.Parameters.Add("@FINDGOODSNO2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraGoodsNo2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.GoodsNo.Trim() + "%");
                    }
                    // 画面の品名検索区分が「で終わる」を選択の場合
                    // 車輌部品データ.商品番号 LIKE %+画面.品番
                    else
                    {
                        // 後方一致の場合
                        sqlStr += "  AND CNVCARPARTSRF.GOODSNORF LIKE @FINDGOODSNO2RF";
                        // Prameterオブジェクトの作成
                        SqlParameter paraGoodsNo2 = sqlCommand.Parameters.Add("@FINDGOODSNO2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraGoodsNo2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.GoodsNo.Trim());
                    }
                }
                // 受注マスタ(車輌).論理削除区分 = 「0：有効」
                sqlStr += " AND ACCEPTODRCARRF.LOGICALDELETECODERF = 0 "
                // 受注マスタ(車輌).データ入力システム = 「10：PM」
                +" AND ACCEPTODRCARRF.DATAINPUTSYSTEMRF = 10 "
                // 受注マスタ(車輌).車両管理番号 <> 0
                +" AND ACCEPTODRCARRF.CARMNGNORF <> 0 "
                // 受注マスタ(車輌).論理削除区分 = 「0：有効」
                +" AND ACCEPTODRCARRF.LOGICALDELETECODERF = 0 ";
                // 内部で保持の車両管理番号≠0の場合、受注マスタ(車輌).車両管理番号 = 画面.車両管理番号
                if (carInfoConditionWorkWork.CarMngNo != 0)
                {
                    sqlStr += " AND ACCEPTODRCARRF.CARMNGNORF = @FINDCARMNGNO2RF ";
                    // Prameterオブジェクトの作成
                    SqlParameter paraCarMngNo2 = sqlCommand.Parameters.Add("@FINDCARMNGNO2RF", SqlDbType.Int);
                    // Parameterオブジェクトへ値設定
                    paraCarMngNo2.Value = SqlDataMediator.SqlSetInt32(carInfoConditionWorkWork.CarMngNo);
                }
                // 画面の型式が入力有り時
                if (!string.IsNullOrEmpty(carInfoConditionWorkWork.FullModel))
                {
                    // 画面の型式検索区分が「と一致」を選択の場合
                    // 受注マスタ（車両）.シリーズ型式 + '-' + 受注マスタ（車両）.型式（類別記号） = 画面.型式
                    if (carInfoConditionWorkWork.FullModelDiv == 0)
                    {
                        // 完全一致の場合
                        sqlStr += " AND ISNULL(ACCEPTODRCARRF.SERIESMODELRF, '') + '-' + ISNULL(ACCEPTODRCARRF.CATEGORYSIGNMODELRF, '') = @FINDFULLMODEL2RF ";
                        // Prameterオブジェクトの作成
                        SqlParameter paraFullModel2 = sqlCommand.Parameters.Add("@FINDFULLMODEL2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraFullModel2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.FullModel.Trim());
                    }
                    // 画面の型式検索区分が「で始まる」を選択の場合
                    // 受注マスタ（車両）.シリーズ型式 + '-' + 受注マスタ（車両）.型式（類別記号） LIKE 画面.型式+% 
                    else if (carInfoConditionWorkWork.FullModelDiv == 1)
                    {
                        // 前方一致の場合
                        sqlStr += " AND ISNULL(ACCEPTODRCARRF.SERIESMODELRF, '') + '-' + ISNULL(ACCEPTODRCARRF.CATEGORYSIGNMODELRF, '') LIKE @FINDFULLMODEL2RF ";
                        // Prameterオブジェクトの作成
                        SqlParameter paraFullModel2 = sqlCommand.Parameters.Add("@FINDFULLMODEL2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraFullModel2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.FullModel.Trim() + "%");
                    }
                    // 画面の型式検索区分が「を含む」を選択の場合
                    // 受注マスタ（車両）.シリーズ型式 + '-' + 受注マスタ（車両）.型式（類別記号） LIKE %+画面.型式+%
                    else if (carInfoConditionWorkWork.FullModelDiv == 2)
                    {
                        // 含みの場合
                        sqlStr += " AND ISNULL(ACCEPTODRCARRF.SERIESMODELRF, '') + '-' + ISNULL(ACCEPTODRCARRF.CATEGORYSIGNMODELRF, '') LIKE @FINDFULLMODEL2RF";
                        // Prameterオブジェクトの作成
                        SqlParameter paraFullModel2 = sqlCommand.Parameters.Add("@FINDFULLMODEL2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraFullModel2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.FullModel.Trim() + "%");
                    }
                    // 画面の型式検索区分が「で終わる」を選択の場合
                    // 受注マスタ（車両）.シリーズ型式 + '-' + 受注マスタ（車両）.型式（類別記号） LIKE %+画面.型式
                    else
                    {
                        // 後方一致の場合
                        sqlStr += " AND ISNULL(ACCEPTODRCARRF.SERIESMODELRF, '') + '-' + ISNULL(ACCEPTODRCARRF.CATEGORYSIGNMODELRF, '') LIKE @FINDFULLMODEL2RF";
                        // Prameterオブジェクトの作成
                        SqlParameter paraFullModel2 = sqlCommand.Parameters.Add("@FINDFULLMODEL2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraFullModel2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.FullModel.Trim());
                    }
                }
                // 画面の車輌備考が入力有り時
                if (!string.IsNullOrEmpty(carInfoConditionWorkWork.CarNote))
                {
                    // 画面の車輌備考検索区分が「と一致」を選択の場合
                    // 受注マスタ(車輌).車輌備考 = 画面.車輌備考
                    if (carInfoConditionWorkWork.CarNoteDiv == 0)
                    {
                        // 完全一致の場合
                        sqlStr += "  AND ACCEPTODRCARRF.CARNOTERF = @FINDCARNOTE2RF ";
                        // Prameterオブジェクトの作成
                        SqlParameter paraCarNote2 = sqlCommand.Parameters.Add("@FINDCARNOTE2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraCarNote2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.CarNote.Trim());
                    }
                    // 画面の車輌備考検索区分が「で始まる」を選択の場合
                    // 受注マスタ(車輌).車輌備考 LIKE 画面.車輌備考+% 
                    else if (carInfoConditionWorkWork.CarNoteDiv == 1)
                    {
                        // 前方一致の場合
                        sqlStr += "  AND ACCEPTODRCARRF.CARNOTERF LIKE @FINDCARNOTE2RF ";
                        // Prameterオブジェクトの作成
                        SqlParameter paraCarNote2 = sqlCommand.Parameters.Add("@FINDCARNOTE2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraCarNote2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.CarNote.Trim() + "%");
                    }
                    // 画面の車輌備考検索区分が「を含む」を選択の場合
                    // 受注マスタ(車輌).車輌備考 LIKE %+画面.車輌備考+%
                    else if (carInfoConditionWorkWork.CarNoteDiv == 2)
                    {
                        // 含みの場合
                        sqlStr += "  AND ACCEPTODRCARRF.CARNOTERF LIKE @FINDCARNOTE2RF";
                        // Prameterオブジェクトの作成
                        SqlParameter paraCarNote2 = sqlCommand.Parameters.Add("@FINDCARNOTE2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraCarNote2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.CarNote.Trim() + "%");
                    }
                    // 画面の車輌備考検索区分が「で終わる」を選択の場合
                    // 受注マスタ(車輌).車輌備考 LIKE %+画面.車輌備考
                    else
                    {
                        // 後方一致の場合
                        sqlStr += "  AND ACCEPTODRCARRF.CARNOTERF LIKE @FINDCARNOTE2RF";
                        // Prameterオブジェクトの作成
                        SqlParameter paraCarNote2 = sqlCommand.Parameters.Add("@FINDCARNOTE2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraCarNote2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.CarNote.Trim());
                    }
                }
                // 画面の管理番号が入力有り時
                if (!string.IsNullOrEmpty(carInfoConditionWorkWork.CarMngCode))
                {
                    // 画面の管理番号検索区分が「と一致」を選択の場合
                    // 受注マスタ(車輌).車輌管理コード = 画面.管理番号
                    if (carInfoConditionWorkWork.CarMngCodeDiv == 0)
                    {
                        // 完全一致の場合
                        sqlStr += "  AND ACCEPTODRCARRF.CARMNGCODERF = @FINDCARMNGCODE2RF ";
                        // Prameterオブジェクトの作成
                        SqlParameter paraCarMngCode2 = sqlCommand.Parameters.Add("@FINDCARMNGCODE2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraCarMngCode2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.CarMngCode.Trim());
                    }
                    // 画面の管理番号検索区分が「で始まる」を選択の場合
                    // 受注マスタ(車輌).車輌管理コード LIKE 画面.管理番号+% 
                    else if (carInfoConditionWorkWork.CarMngCodeDiv == 1)
                    {
                        // 前方一致の場合
                        sqlStr += "  AND ACCEPTODRCARRF.CARMNGCODERF LIKE @FINDCARMNGCODE2RF ";
                        // Prameterオブジェクトの作成
                        SqlParameter paraCarMngCode2 = sqlCommand.Parameters.Add("@FINDCARMNGCODE2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraCarMngCode2.Value = SqlDataMediator.SqlSetString(carInfoConditionWorkWork.CarMngCode.Trim() + "%");
                    }
                    // 画面の管理番号検索区分が「を含む」を選択の場合
                    // 受注マスタ(車輌).車輌管理コード LIKE %+画面.管理番号+%
                    else if (carInfoConditionWorkWork.CarMngCodeDiv == 2)
                    {
                        // 含みの場合
                        sqlStr += "  AND ACCEPTODRCARRF.CARMNGCODERF LIKE @FINDCARMNGCODE2RF";
                        // Prameterオブジェクトの作成
                        SqlParameter paraCarMngCode2 = sqlCommand.Parameters.Add("@FINDCARMNGCODE2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraCarMngCode2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.CarMngCode.Trim() + "%");
                    }
                    // 画面の管理番号検索区分が「で終わる」を選択の場合
                    // 受注マスタ(車輌).車輌管理コード LIKE %+画面.管理番号
                    else
                    {
                        // 後方一致の場合
                        sqlStr += "  AND ACCEPTODRCARRF.CARMNGCODERF LIKE @FINDCARMNGCODE2RF";
                        // Prameterオブジェクトの作成
                        SqlParameter paraCarMngCode2 = sqlCommand.Parameters.Add("@FINDCARMNGCODE2RF", SqlDbType.NChar);
                        // Parameterオブジェクトへ値設定
                        paraCarMngCode2.Value = SqlDataMediator.SqlSetString("%" + carInfoConditionWorkWork.CarMngCode.Trim());
                    }
                }

                sqlStr += " ) ";

                // INNER JOIN 車輌管理マスタ WITH (READUNCOMMITTED) ON (
                sqlStr += " INNER JOIN CARMANAGEMENTRF WITH (READUNCOMMITTED) ON ( "
                    // 車輌部品データ.企業コード = 車輌管理マスタ.企業コード
                    + " CNVCARPARTSRF.ENTERPRISECODERF = CARMANAGEMENTRF.ENTERPRISECODERF "
                    // 車輌部品データ.得意先コード = 車輌管理マスタ.得意先コード
                    + " AND CNVCARPARTSRF.CUSTOMERCODERF = CARMANAGEMENTRF.CUSTOMERCODERF "
                    // 受注マスタ(車輌).車両管理番号 = 車輌管理マスタ.車両管理番号
                    + " AND ACCEPTODRCARRF.CARMNGNORF = CARMANAGEMENTRF.CARMNGNORF "
                    // 受注マスタ(車輌).車両管理番号 = 車輌管理マスタ.車両管理番号 // 2009/12/24
                    + " AND ACCEPTODRCARRF.CARMNGCODERF = CARMANAGEMENTRF.CARMNGCODERF " // 2009/12/24
                    // 車輌管理マスタ.論理削除区分 = 「0：有効」
                    + " AND CARMANAGEMENTRF.LOGICALDELETECODERF = 0) ";
                // LEFT JOIN メーカーマスタ（ユーザー登録） WITH (READUNCOMMITTED) ON (
                sqlStr += " LEFT JOIN MAKERURF WITH (READUNCOMMITTED) ON ( "
                    // 車輌部品データ.企業コード = メーカーマスタ（ユーザー登録）.企業コード
                    + " CNVCARPARTSRF.ENTERPRISECODERF = MAKERURF.ENTERPRISECODERF "
                    // 車輌部品データ.商品メーカーコード = メーカーマスタ（ユーザー登録）.商品メーカーコード
                    + " AND CNVCARPARTSRF.GOODSMAKERCDRF = MAKERURF.GOODSMAKERCDRF "
                    // メーカーマスタ（ユーザー登録）.論理削除区分 = 「0：有効」
                    + " AND MAKERURF.LOGICALDELETECODERF = 0) ";
                // 画面の表示区分が「出荷部品」の時
                // ORDER BY 売上日付、商品名称、商品番号、商品メーカーコード
                if (carInfoConditionWorkWork.DispDiv == 1)
                {
                    //sqlStr += " ORDER BY 1, 4, 5, 6 ";// DEL 2009/10/20 Redmin#702対応
                    //sqlStr += " ORDER BY 2,5, 6, 7 ";// ADD 2009/10/20 Redmin#702対応  //DEL BY 凌小青 on 2012/08/09 for Redmine#31532
                    sqlStr += " ORDER BY 2,11,5, 6, 7 "; //ADD BY 凌小青 on 2012/08/09 for Redmine#31532
                }
                // 画面の表示区分が「出荷部品（合計）」の場合
                else
                {
                    //sqlStr += " ORDER BY 4, 5, 6, 7, 8, 9";// DEL 2009/10/20 Redmin#702対応
                    sqlStr += " ORDER BY 5, 6, 7, 8, 9, 10";// ADD 2009/10/20 Redmin#702対応
                }

                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();
                // 画面の表示区分が「出荷部品」の時
                if (carInfoConditionWorkWork.DispDiv == 1)
                {
                    #region 画面の表示区分が「出荷部品」の時
                    while (myReader.Read())
                    {
                        carShipmentPartsDispWork = new CarShipmentPartsDispWork();
                        carShipmentPartsDispWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF")); // ADD 2009/10/10
                        carShipmentPartsDispWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                        carShipmentPartsDispWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTERF"));
                        carShipmentPartsDispWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                        carShipmentPartsDispWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                        carShipmentPartsDispWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                        carShipmentPartsDispWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                        carShipmentPartsDispWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                        carShipmentPartsDispWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                        carShipmentPartsDispWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                        carShipmentPartsDispWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                        carShipmentPartsDispWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                        carShipmentPartsDispWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                        carShipmentPartsDispWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                        carShipmentPartsDispWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                        carShipmentPartsDispWork.CarNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARNOTERF"));
                        carShipmentPartsDispWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                        carShipmentPartsDispWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));
                        carShipmentPartsDispWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
                        carShipmentPartsDispWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));
                        carShipmentPartsDispWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));
                        carShipmentPartsDispWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                        carShipmentPartsDispWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                        carShipmentPartsDispWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                        carShipmentPartsDispWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                        carShipmentPartsDispWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                        carShipmentPartsDispWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                        carShipmentPartsDispWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
                        carShipmentPartsDispWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
                        carShipmentPartsDispWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));
                        carShipmentPartsDispWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));
                        carShipmentPartsDispWork.ColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORCODERF"));
                        carShipmentPartsDispWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));
                        carShipmentPartsDispWork.StProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STPRODUCEFRAMENORF"));
                        carShipmentPartsDispWork.EdProduceFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDPRODUCEFRAMENORF"));
                        carShipmentPartsDispWork.EngineModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELRF"));
                        carShipmentPartsDispWork.ModelGradeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADENMRF"));
                        carShipmentPartsDispWork.EngineDisplaceNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEDISPLACENMRF"));
                        carShipmentPartsDispWork.EDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIVNMRF"));
                        carShipmentPartsDispWork.TransmissionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRANSMISSIONNMRF"));
                        carShipmentPartsDispWork.ShiftNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIFTNMRF"));
                        carShipmentPartsDispWork.WheelDriveMethodNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WHEELDRIVEMETHODNMRF"));
                        carShipmentPartsDispWork.AddiCarSpec1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC1RF"));
                        carShipmentPartsDispWork.AddiCarSpec2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC2RF"));
                        carShipmentPartsDispWork.AddiCarSpec3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC3RF"));
                        carShipmentPartsDispWork.AddiCarSpec4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC4RF"));
                        carShipmentPartsDispWork.AddiCarSpec5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC5RF"));
                        carShipmentPartsDispWork.AddiCarSpec6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPEC6RF"));
                        carShipmentPartsDispWork.AddiCarSpecTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE1RF"));
                        carShipmentPartsDispWork.AddiCarSpecTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE2RF"));
                        carShipmentPartsDispWork.AddiCarSpecTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE3RF"));
                        carShipmentPartsDispWork.AddiCarSpecTitle4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE4RF"));
                        carShipmentPartsDispWork.AddiCarSpecTitle5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE5RF"));
                        carShipmentPartsDispWork.AddiCarSpecTitle6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDICARSPECTITLE6RF"));
                        carShipmentPartsDispWork.StProduceTypeOfYear = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("STPRODUCETYPEOFYEARRF"));
                        carShipmentPartsDispWork.EdProduceTypeOfYear = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("EDPRODUCETYPEOFYEARRF"));
                        carShipmentPartsDispWork.DoorCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOORCOUNTRF"));
                        carShipmentPartsDispWork.BodyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BODYNAMERF"));
                        carShipmentPartsDispWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                        carShipmentPartsDispWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                        carShipmentPartsDispWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                        carShipmentPartsDispWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                        carShipmentPartsDispWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));
                        carShipmentPartsDispWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));
                        carShipmentPartsDispWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));
                        carShipmentPartsDispWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));
                        carShipmentPartsDispWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));
                        carShipmentPartsDispWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));
                        carShipmentPartsDispWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));
                        carShipmentPartsDispWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITRF"));
                        carShipmentPartsDispWork.RowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));//ADD BY 凌小青　on 2012/08/09 for Redmine#31532
                        carShipmentPartsDispWork.DomesticForeignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOMESTICFOREIGNCODERF"));// ADD 2013/03/25
                        carManagementList.Add(carShipmentPartsDispWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    #endregion
                }
                // 画面の表示区分が「出荷部品（合計）」の場合
                else
                {
                    #region 画面の表示区分が「出荷部品（合計）」の場合
                    ArrayList tempList = new ArrayList();
                    CarShipmentPartsDispWork dispWork = null;
                    while (myReader.Read())
                    {
                        dispWork = new CarShipmentPartsDispWork();
                        dispWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                        dispWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                        dispWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                        dispWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                        dispWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                        dispWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                        dispWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                        dispWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                        dispWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                        dispWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                        dispWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                        dispWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                        dispWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                        dispWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                        dispWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                        dispWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                        dispWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                        dispWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                        tempList.Add(dispWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }


                    if (tempList.Count > 0)
                    {

                        string goodsName = string.Empty;
                        string goodsNo = string.Empty;
                        int goodsMakerCd = 0;
                        int blGoodsCode = 0;
                        // 売上伝票番号
                        string salesSlipNum = string.Empty;
                        // 受注ステータス
                        int acptAnOdrStatus = 0;
                        string warehouseCode = string.Empty;
                        // 棚番
                        string warehouseShelfNo = string.Empty;
                        // 売上金額
                        long salesMoneyTaxExc = 0;
                        // 出荷数
                        double shipmentCnt = 0;
                        // 出荷回数
                        int shipmentCntTotal = 0;
                        // 売上在庫取寄せ区分が[0:取寄]の売上履歴明細データ.出荷数の合計
                        double shipmentCntInTotal = 0;
                        // 売上在庫取寄せ区分が[1:在庫]の売上履歴明細データ.出荷数の合計
                        double shipmentCntOutTotal = 0;

                        // メーカー名称
                        string makerName = string.Empty;
                        // 倉庫
                        string warehouseName = string.Empty;
                        // 現在庫数
                        double shipmentPosCnt = 0;

                        for (int i = 0; i < tempList.Count; i++)
                        {
                            CarShipmentPartsDispWork tempWork = (CarShipmentPartsDispWork)tempList[i];
                            if (i == 0)
                            {
                                // 受注ステータス
                                acptAnOdrStatus = tempWork.AcptAnOdrStatus;
                                // 売上伝票番号
                                salesSlipNum = tempWork.SalesSlipNum;
                                // 品名
                                goodsName = tempWork.GoodsName;
                                // 品番
                                goodsNo = tempWork.GoodsNo;
                                // メーカーコード
                                goodsMakerCd = tempWork.GoodsMakerCd;
                                // BLコード
                                blGoodsCode = tempWork.BLGoodsCode;
                                // 倉庫コード
                                warehouseCode = tempWork.WarehouseCode;
                                // 棚番
                                warehouseShelfNo = tempWork.WarehouseShelfNo;
                                // 売上金額
                                salesMoneyTaxExc = tempWork.SalesMoneyTaxExc;
                                // 出荷数
                                shipmentCnt = tempWork.ShipmentCnt;
                                //---------UPD 2009/10/23--------->>>>>
                                // 返品
                                if ((tempWork.SalesSlipCdDtl == 1) || (tempWork.AcptAnOdrStatus == 8))
                                {
                                    // 出荷回数
                                    shipmentCntTotal = -1;
                                }
                                // 売上
                                else
                                {
                                    // 出荷回数
                                    shipmentCntTotal = 1;
                                }
                                //---------UPD 2009/10/23---------<<<<<
                                // 売上在庫取寄せ区分が[0:取寄]の売上履歴明細データ.出荷数の合計
                                if (tempWork.SalesOrderDivCd == 0)
                                {
                                    shipmentCntOutTotal = tempWork.ShipmentCnt;
                                }
                                // 売上在庫取寄せ区分が[1:在庫]の売上履歴明細データ.出荷数の合計
                                else if (tempWork.SalesOrderDivCd == 1)
                                {
                                    shipmentCntInTotal = tempWork.ShipmentCnt;
                                }
                                // メーカー
                                makerName = tempWork.MakerName;
                                // 倉庫
                                warehouseName = tempWork.WarehouseName;
                                // 現在庫数
                                shipmentPosCnt = tempWork.ShipmentPosCnt;
                            }
                            else
                            {
                                if (goodsName.Equals(tempWork.GoodsName)
                                    && goodsNo.Equals(tempWork.GoodsNo)
                                    && goodsMakerCd == tempWork.GoodsMakerCd
                                    && blGoodsCode == tempWork.BLGoodsCode
                                    && warehouseCode.Equals(tempWork.WarehouseCode)
                                    && warehouseShelfNo.Equals(tempWork.WarehouseShelfNo))
                                {
                                    // 売上金額
                                    salesMoneyTaxExc = salesMoneyTaxExc + tempWork.SalesMoneyTaxExc;
                                    // 出荷数
                                    shipmentCnt = shipmentCnt + tempWork.ShipmentCnt;
                                    //--------UPD  2009/10/23------>>>>>
                                    //if (!acptAnOdrStatus.Equals(tempWork.AcptAnOdrStatus) || !salesSlipNum.Equals(tempWork.SalesSlipNum))
                                    //{
                                    // 返品
                                    if ((tempWork.SalesSlipCdDtl == 1) || (tempWork.AcptAnOdrStatus == 8))
                                    {
                                        // 出荷回数
                                        shipmentCntTotal = shipmentCntTotal - 1;
                                        acptAnOdrStatus = tempWork.AcptAnOdrStatus;
                                        salesSlipNum = tempWork.SalesSlipNum;
                                    }
                                    // 売上
                                    else
                                    {
                                        // 出荷回数
                                        shipmentCntTotal = shipmentCntTotal + 1;
                                        acptAnOdrStatus = tempWork.AcptAnOdrStatus;
                                        salesSlipNum = tempWork.SalesSlipNum;
                                    }
                                    //}
                                    //--------UPD  2009/10/23------>>>>>
                                    // 売上在庫取寄せ区分が[0:取寄]の売上履歴明細データ.出荷数の合計
                                    if (tempWork.SalesOrderDivCd == 0)
                                    {
                                        shipmentCntOutTotal += tempWork.ShipmentCnt;
                                    }
                                    // 売上在庫取寄せ区分が[1:在庫]の売上履歴明細データ.出荷数の合計
                                    else if (tempWork.SalesOrderDivCd == 1)
                                    {
                                        shipmentCntInTotal += tempWork.ShipmentCnt;
                                    }
                                }
                                else
                                {
                                    carShipmentPartsDispWork = new CarShipmentPartsDispWork();
                                    // 品名
                                    carShipmentPartsDispWork.GoodsName = goodsName;
                                    // 品番
                                    carShipmentPartsDispWork.GoodsNo = goodsNo;
                                    carShipmentPartsDispWork.GoodsMakerCd = goodsMakerCd;
                                    // メーカー
                                    carShipmentPartsDispWork.MakerName = makerName;
                                    // --- UPD 2009/09/08 -------------->>>
                                    // BLコード
                                    carShipmentPartsDispWork .BLGoodsCode= blGoodsCode;
                                    // --- UPD 2009/09/08 --------------<<<
                                    // 売上金額
                                    carShipmentPartsDispWork.SalesMoneyTaxExcTotal = salesMoneyTaxExc;
                                    // 数量
                                    carShipmentPartsDispWork.ShipmentTotalCnt = shipmentCnt;
                                    // 出荷回数
                                    carShipmentPartsDispWork.ShipmentCntTotal = shipmentCntTotal;
                                    // 倉庫
                                    carShipmentPartsDispWork.WarehouseName = warehouseName;
                                    carShipmentPartsDispWork.WarehouseCode = warehouseCode;
                                    // 棚番
                                    carShipmentPartsDispWork.WarehouseShelfNo = warehouseShelfNo;
                                    // 現在庫数
                                    carShipmentPartsDispWork.ShipmentPosCnt = shipmentPosCnt;
                                    // 数量（在庫）
                                    carShipmentPartsDispWork.ShipmentCntInTotal = shipmentCntInTotal;
                                    // 数量（取寄）
                                    carShipmentPartsDispWork.ShipmentCntOutTotal = shipmentCntOutTotal;

                                    carManagementList.Add(carShipmentPartsDispWork);
                                    // クリア
                                    shipmentCntOutTotal = 0;
                                    shipmentCntInTotal = 0;

                                    // 受注ステータス
                                    acptAnOdrStatus = tempWork.AcptAnOdrStatus;
                                    // 売上伝票番号
                                    salesSlipNum = tempWork.SalesSlipNum;
                                    // 品名
                                    goodsName = tempWork.GoodsName;
                                    // 品番
                                    goodsNo = tempWork.GoodsNo;
                                    // メーカーコード
                                    goodsMakerCd = tempWork.GoodsMakerCd;
                                    // BLコード
                                    blGoodsCode = tempWork.BLGoodsCode;
                                    // 倉庫コード
                                    warehouseCode = tempWork.WarehouseCode;
                                    // 売上金額
                                    salesMoneyTaxExc = tempWork.SalesMoneyTaxExc;
                                    // 出荷数
                                    shipmentCnt = tempWork.ShipmentCnt;
                                    //----------UPD 2009/10/23---------->>>>>
                                    // 返品
                                    if ((tempWork.SalesSlipCdDtl == 1) || (tempWork.AcptAnOdrStatus == 8))
                                    {
                                        // 出荷回数
                                        shipmentCntTotal = -1;
                                    }
                                    else
                                    {
                                        // 出荷回数
                                        shipmentCntTotal = 1;
                                    }
                                    //----------UPD 2009/10/23----------<<<<<
                                        // 売上在庫取寄せ区分が[0:取寄]の売上履歴明細データ.出荷数の合計
                                    if (tempWork.SalesOrderDivCd == 0)
                                    {
                                        shipmentCntOutTotal = tempWork.ShipmentCnt;
                                    }
                                    // 売上在庫取寄せ区分が[1:在庫]の売上履歴明細データ.出荷数の合計
                                    else if (tempWork.SalesOrderDivCd == 1)
                                    {
                                        shipmentCntInTotal = tempWork.ShipmentCnt;
                                    }
                                    // メーカー
                                    makerName = tempWork.MakerName;
                                    // 倉庫
                                    warehouseName = tempWork.WarehouseName;
                                    // 棚番
                                    warehouseShelfNo = tempWork.WarehouseShelfNo;
                                    // 現在庫数
                                    shipmentPosCnt = tempWork.ShipmentPosCnt;
                                }
                            }

                            if (i == tempList.Count - 1)
                            {
                                carShipmentPartsDispWork = new CarShipmentPartsDispWork();
                                // 品名
                                carShipmentPartsDispWork.GoodsName = goodsName;
                                // 品番
                                carShipmentPartsDispWork.GoodsNo = goodsNo;
                                // メーカー
                                carShipmentPartsDispWork.GoodsMakerCd = goodsMakerCd;
                                carShipmentPartsDispWork.MakerName = makerName;
                                // --- UPD 2009/09/08 -------------->>>
                                // BLコード
                                carShipmentPartsDispWork.BLGoodsCode = blGoodsCode;
                                // --- UPD 2009/09/08 --------------<<<
                                // 売上金額
                                carShipmentPartsDispWork.SalesMoneyTaxExcTotal = salesMoneyTaxExc;
                                // 数量
                                carShipmentPartsDispWork.ShipmentTotalCnt = shipmentCnt;
                                // 出荷回数
                                carShipmentPartsDispWork.ShipmentCntTotal = shipmentCntTotal;
                                // 倉庫
                                carShipmentPartsDispWork.WarehouseName = warehouseName;
                                carShipmentPartsDispWork.WarehouseCode = warehouseCode;
                                // 棚番
                                carShipmentPartsDispWork.WarehouseShelfNo = warehouseShelfNo;
                                // 現在庫数
                                carShipmentPartsDispWork.ShipmentPosCnt = shipmentPosCnt;
                                // 数量（在庫）
                                carShipmentPartsDispWork.ShipmentCntInTotal = shipmentCntInTotal;
                                // 数量（取寄）
                                carShipmentPartsDispWork.ShipmentCntOutTotal = shipmentCntOutTotal;

                                carManagementList.Add(carShipmentPartsDispWork);
                            }
                        }
                    }
                    #endregion
                }
            }
            catch (SqlException e)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(e, errmsg, e.Number);
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "CarShipmentPartsDispDB.CarInfoSearch Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion
    }
}
