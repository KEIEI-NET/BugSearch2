//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 譚洪
// 修 正 日  2009/05/25  修正内容 : 表示順位100以上
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 譚洪
// 修 正 日  2009/06/08  修正内容 : マスタ送受信不備対応について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 張莉莉
// 修 正 日  2009/06/12  修正内容 : public MethodでSQL文字が駄目対応について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 譚洪
// 修 正 日  2009/06/24  修正内容 : PVCS#255 商品マスタの受信について 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/07/06  修正内容 : マスタ送受信処理のＡＰＰロックについて
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/07/06  修正内容 : データ送信処理のDCサーバーのエラーログについて
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 馮文雄
// 修 正 日  2011/07/25  修正内容 : SCM対応-拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/08/25  修正内容 : #23798 条件送信で更新ボタン押下で処理が終了しない
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/09/05  修正内容 : #24047 送信失敗時の対処について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 馮文雄
// 修 正 日  2011/09/06  修正内容 : #24364 送信タイムアウト問題の対応
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響 
// 修 正 日  2011/09/06  修正内容 : #24252 データを受信する時、
//                                  在庫マスタの数量の更新について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : yangmj 
// 修 正 日  2011/10/08  修正内容 : #25778 マスタ送受信リモートでDispose処理がありませんの対応
//----------------------------------------------------------------------------//
// 管理番号  10802197-00 修正担当 : FSI東 隆史
// 修 正 日  2012/07/26  修正内容 : 拠点管理 抽出条件追加対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 修 正 日  2012/07/26  修正内容 : 拠点管理DCログ時間追加改良
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 作 成 日  2012/10/16  修正内容 : 拠点管理ログ参照ツール不具合の対応
//----------------------------------------------------------------------------//
// 管理番号  11770021-00 作成担当 : 陳艶丹
// 作 成 日  2021/04/12  修正内容 : 得意先メモ情報の追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// DCコントロールDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : DCコントロールDBの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: 2011/10/08 yangmj</br>
    /// <br>             Redmine #25778の対応</br>
    /// <br>Update Note: 2012/10/16 李亜博</br>
    ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
    /// <br>Update Note: 2021/04/12 陳艶丹</br>
    /// <br>管理番号   : 11770021-00</br>
    /// <br>           : PMKOBETSU-4136 得意先メモ情報の追加</br>
    /// </remarks>
    [Serializable]
    public class APMSTControlDB : RemoteWithAppLockDB, IAPMSTControlDB
    {
        #region ■ Const Memebers ■
        private const string MST_SECINFOSET = "拠点設定マスタ";
        private const string MST_SUBSECTION = "部門設定マスタ";
        private const string MST_WAREHOUSE = "倉庫設定マスタ";
        private const string MST_EMPLOYEE = "従業員設定マスタ";
        private const string MST_USERGDAREADIVU = "ユーザーガイドマスタ(販売エリア区分）";
        private const string MST_USERGDBUSDIVU = "ユーザーガイドマスタ（業務区分）";
        private const string MST_USERGDCATEU = "ユーザーガイドマスタ（業種）";
        private const string MST_USERGDBUSU = "ユーザーガイドマスタ（職種）";
        private const string MST_USERGDGOODSDIVU = "ユーザーガイドマスタ（商品区分）";
        private const string MST_USERGDCUSGROUPU = "ユーザーガイドマスタ（得意先掛率グループ）";
        private const string MST_USERGDBANKU = "ユーザーガイドマスタ（銀行）";
        private const string MST_USERGDPRIDIVU = "ユーザーガイドマスタ（価格区分）";
        private const string MST_USERGDDELIDIVU = "ユーザーガイドマスタ（納品区分）";
        private const string MST_USERGDGOODSBIGU = "ユーザーガイドマスタ（商品大分類）";
        private const string MST_USERGDBUYDIVU = "ユーザーガイドマスタ（販売区分）";
        private const string MST_USERGDSTOCKDIVOU = "ユーザーガイドマスタ（在庫管理区分１）";
        private const string MST_USERGDSTOCKDIVTU = "ユーザーガイドマスタ（在庫管理区分２）";
        private const string MST_USERGDRETURNREAU = "ユーザーガイドマスタ（返品理由）";
        private const string MST_RATEPROTYMNG = "掛率優先管理マスタ";
        private const string MST_RATE = "掛率マスタ";
        private const string MST_SALESTARGET = "売上目標設定マスタ";
        private const string MST_CUSTOME = "得意先マスタ";
        private const string MST_SUPPLIER = "仕入先マスタ";
        private const string MST_JOINPARTSU = "結合マスタ";
        private const string MST_GOODSSET = "セットマスタ";
        private const string MST_TBOSEARCHU = "ＴＢＯマスタ";
        private const string MST_MODELNAMEU = "車種マスタ";
        private const string MST_BLGOODSCDU = "ＢＬコードマスタ";
        private const string MST_MAKERU = "メーカーマスタ";
        private const string MST_GOODSMGROUPU = "商品中分類マスタ";
        private const string MST_BLGROUPU = "グループコードマスタ";
        private const string MST_BLCODEGUIDE = "BLコードガイドマスタ";
        private const string MST_GOODSU = "商品マスタ";
        private const string MST_STOCK = "在庫マスタ";
        private const string MST_PARTSSUBSTU = "代替マスタ";
        private const string MST_PARTSPOSCODEU = "部位マスタ";

        private const string MST_ID_SECINFOSET = "SecInfoSetRF";
        private const string MST_ID_SUBSECTION = "SubSectionRF";
        private const string MST_ID_WAREHOUSE = "WarehouseRF";
        // --- DEL 2012/07/26 --------------------------------------------->>>>>
        //private const string MST_ID_EMPLOYEE = "EmployeeDtlRF";
        // --- DEL 2012/07/26 ---------------------------------------------<<<<<
        // --- ADD 2012/07/26 --------------------------------------------->>>>>
        private const string MST_ID_EMPLOYEE = "EmployeeRF";
        // --- ADD 2012/07/26 ---------------------------------------------<<<<<
        private const string MST_ID_EMPLOYEEDTL = "EmployeeDtlRF";
        private const string MST_ID_USERGDU = "UserGdBdURF";
        private const string MST_ID_RATEPROTYMNG = "RateProtyMngRF";
        private const string MST_ID_RATE = "RateRF";
        private const string MST_ID_CUSTSALESTARGET = "CustSalesTargetRF";
        private const string MST_ID_EMPSALESTARGET = "EmpSalesTargetRF";
        private const string MST_ID_GCDSALESTARGET = "GcdSalesTargetRF";
        private const string MST_ID_CUSTOMECHA = "CustomerChangeRF";
        private const string MST_ID_CUSTOMEMEMO = "CustomerMemoRF"; // ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136
        private const string MST_ID_CUSTOME = "CustomerRF";
        private const string MST_ID_CUSTOMEGROUP = "CustRateGroupRF";
        private const string MST_ID_CUSTOMESLIPMNG = "CustSlipMngRF";
        private const string MST_ID_CUSTOMESLIPNO = "CustSlipNoSetRF";
        private const string MST_ID_SUPPLIER = "SupplierRF";
        private const string MST_ID_JOINPARTSU = "JoinPartsURF";
        private const string MST_ID_GOODSSET = "GoodsSetRF";
        private const string MST_ID_TBOSEARCHU = "TBOSearchURF";
        private const string MST_ID_MODELNAMEU = "ModelNameURF";
        private const string MST_ID_BLGOODSCDU = "BLGoodsCdURF";
        private const string MST_ID_MAKERU = "MakerURF";
        private const string MST_ID_GOODSMGROUPU = "GoodsMGroupURF";
        private const string MST_ID_BLGROUPU = "BLGroupURF";
        private const string MST_ID_BLCODEGUIDE = "BLCodeGuideRF";
        private const string MST_ID_GOODSUMNG = "GoodsMngRF";
        private const string MST_ID_GOODSUPRI = "GoodsPriceURF";
        private const string MST_ID_GOODSU = "GoodsURF";
        private const string MST_ID_GOODSUISO = "IsolIslandPrcRF";
        private const string MST_ID_STOCK = "StockRF";
        private const string MST_ID_PARTSSUBSTU = "PartsSubstURF";
        private const string MST_ID_PARTSPOSCODEU = "PartsPosCodeURF";

        private const int MAX_CNT = 20000;//ADD 2011.09.06 #24364


        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
        private const int CNT_ZERO = 0;
        //受信区分
        enum CusMemoSedDiv
        {
            // 受信区分なし
            None = 0,
            // 受信区分＝受信あり（追加のみ）
            Add = 1,
            // 受信区分＝受信あり（追加・更新）
            AddUpd = 2,
            // 受信区分＝受信あり（更新のみ）
            Upd = 3,
        }
        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
        #endregion

        # region ■ Private Members ■
        // 拠点情報設定マスタ
        private Int32 secInfoSetInt = 0;
        // 部門マスタ
        private Int32 subSectionInt = 0;
        // 倉庫マスタ
        private Int32 warehouseInt = 0;
        // 従業員マスタ
        private Int32 employeeInt = 0;
        // 従業員詳細マスタ
        private Int32 employeeDtlInt = 0;
        // 得意先マスタ
        private Int32 customerInt = 0;
        // 得意先マスタ(変動情報)
        private Int32 customerChangeInt = 0;
        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
        // 得意先マスタ(メモ情報)
        private Int32 customerMemoInt =  Convert.ToInt32(CusMemoSedDiv.None);
        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
        // 得意先マスタ（伝票管理）
        private Int32 custSlipMngInt = 0;
        // 得意先マスタ（掛率グループ）
        private Int32 custRateGroupInt = 0;
        // 得意先マスタ(伝票番号)
        private Int32 custSlipNoSetInt = 0;
        // 仕入先マスタ
        private Int32 supplierInt = 0;
        // メーカーマスタ（ユーザー登録分）
        private Int32 makerUInt = 0;
        // BL商品コードマスタ（ユーザー登録分）
        private Int32 bLGoodsCdUInt = 0;
        // 商品マスタ（ユーザー登録分）
        private Int32 goodsUInt = 0;
        // 価格マスタ（ユーザー登録）
        private Int32 goodsPriceInt = 0;
        // 商品管理情報マスタ
        private Int32 goodsMngInt = 0;
        // 離島価格マスタ
        private Int32 isolIslandPrcInt = 0;
        // 在庫マスタ
        private Int32 stockInt = 0;
        // ユーザーガイドマスタ(販売エリア区分）
        private Int32 userGdAreaDivUInt = 0;
        // ユーザーガイドマスタ（業務区分）
        private Int32 userGdBusDivUInt = 0;
        // ユーザーガイドマスタ（業種）
        private Int32 userGdCateUInt = 0;
        // ユーザーガイドマスタ（職種）
        private Int32 userGdBusUInt = 0;
        // ユーザーガイドマスタ（商品区分）
        private Int32 userGdGoodsDivUInt = 0;
        // ユーザーガイドマスタ（得意先掛率グループ）
        private Int32 userGdCusGrouPUInt = 0;
        // ユーザーガイドマスタ（銀行）
        private Int32 userGdBankUInt = 0;
        // ユーザーガイドマスタ（価格区分）
        private Int32 userGdPriDivUInt = 0;
        // ユーザーガイドマスタ（納品区分）
        private Int32 userGdDeliDivUInt = 0;
        // ユーザーガイドマスタ（商品大分類）
        private Int32 userGdGoodsBigUInt = 0;
        // ユーザーガイドマスタ（販売区分）
        private Int32 userGdBuyDivUInt = 0;
        // ユーザーガイドマスタ（在庫管理区分１）
        private Int32 userGdStockDivOUInt = 0;
        // ユーザーガイドマスタ（在庫管理区分２）
        private Int32 userGdStockDivTUInt = 0;
        // ユーザーガイドマスタ（返品理由）
        private Int32 userGdReturnReaUInt = 0;
        // 掛率優先管理マスタ
        private Int32 rateProtyMngInt = 0;
        // 掛率マスタ
        private Int32 rateInt = 0;
        // 商品セットマスタ
        private Int32 goodsSetInt = 0;
        // 部品代替マスタ（ユーザー登録分）
        private Int32 partsSubstUInt = 0;
        // 従業員別売上目標設定マスタ
        private Int32 empSalesTargetInt = 0;
        // 得意先別売上目標設定マスタ
        private Int32 custSalesTargetInt = 0;
        // 商品別売上目標設定マスタ
        private Int32 gcdSalesTargetInt = 0;
        // 商品中分類マスタ（ユーザー登録分）
        private Int32 goodsMGroupUInt = 0;
        // BLグループマスタ（ユーザー登録分）
        private Int32 bLGroupUInt = 0;
        // 結合マスタ（ユーザー登録分）
        private Int32 joinPartsUInt = 0;
        // TBO検索マスタ（ユーザー登録）
        private Int32 tBOSearchUCountInt = 0;
        // 部位コードマスタ（ユーザー登録）
        private Int32 partsPosCodeUInt = 0;
        // BLコードガイドマスタ
        private Int32 bLCodeGuideInt = 0;
        // 車種名称マスタ
        private Int32 modelNameUInt = 0;
        #endregion

        # region ■ Constructor ■
        /// <summary>
        /// DCコントロールリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.4.24</br>
        /// </remarks>
        public APMSTControlDB()
        {
        }
        #endregion

        # region ■ マスタ送受信処理 ■

         /// <summary>
        /// 送信マスタ名称を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterNameList">マスタ名称リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送信マスタ名称取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        public int SearchMstName(string enterpriseCode, out ArrayList masterNameList)
        {
            return SearchMstNameProc(enterpriseCode, out masterNameList);
        }
        /// <summary>
        /// 送信マスタ名称を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterNameList">マスタ名称リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送信マスタ名称取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Update Note : 2012/07/26 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
        /// <br>Date       : 2009.3.31</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        private int SearchMstNameProc(string enterpriseCode, out ArrayList masterNameList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            string sqlString = string.Empty;
            masterNameList = new ArrayList();
            SecMngSndRcvWork secMngSndRcvWork = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

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

                sqlCommand = new SqlCommand("", sqlConnection);

                // Selectコマンドの生成
                sqlString += " SELECT DISTINCT" + Environment.NewLine;
                sqlString += "     A.MASTERNAMERF" + Environment.NewLine;
                sqlString += "    ,A.USERGUIDEDIVCDRF" + Environment.NewLine;
                sqlString += "    ,A.DISPLAYORDERRF" + Environment.NewLine;
                //sqlString += "    ,A.FILEIDRF" + Environment.NewLine;   // ADD 2012/07/26 姚学剛 //DEL 2012/10/16 李亜博 for redmine#31026
                sqlString += " FROM" + Environment.NewLine;
                sqlString += "    SECMNGSNDRCVRF A WITH (READUNCOMMITTED)  " + Environment.NewLine;
                sqlString += " WHERE ";
                // 企業コード
                sqlString += " A.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // 論理削除区分
                sqlString += " AND A.LOGICALDELETECODERF=@LOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                // ADD 2009/05/25 --->>>
                // 表示順位100以上
                sqlString += " AND A.DISPLAYORDERRF > @DISPLAYORDER ";
                SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(100);
                // ADD 2009/05/25 ---<<<


                // 拠点管理送信区分
                sqlString += " AND A.SECMNGSENDDIVRF=@SECMNGSENDDIVRF ";
                SqlParameter paraSecMngSendDiv = sqlCommand.Parameters.Add("@SECMNGSENDDIVRF", SqlDbType.Int);
                paraSecMngSendDiv.Value = SqlDataMediator.SqlSetInt32(1);

                // ORDER BY
                sqlString += " ORDER BY A.DISPLAYORDERRF ";

                sqlCommand.CommandText = sqlString;

                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    secMngSndRcvWork = new SecMngSndRcvWork();
                    secMngSndRcvWork.MasterName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MASTERNAMERF"));
                    secMngSndRcvWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    //secMngSndRcvWork.FileId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILEIDRF"));  // ADD 2012/07/26 姚学剛 //DEL 2012/10/16 李亜博 for redmine#31026
                    masterNameList.Add(secMngSndRcvWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APMSTControlDB.SearchMstName SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "APMSTControlDB.SearchMstName Exception=" + e.Message);
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


        /// <summary>
        /// 送信マスタ名称区分を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterDivList">マスタ名称区分リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送信マスタ名称区分取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        public int SearchMstDoDiv(string enterpriseCode, out ArrayList masterDivList)
        {
            return SearchMstDoDivProc(enterpriseCode, out masterDivList);
        }
        /// <summary>
        /// 送信マスタ名称区分を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterDivList">マスタ名称区分リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送信マスタ名称区分取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        /// <br>Update Note : 2012/07/26 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        private int SearchMstDoDivProc(string enterpriseCode, out ArrayList masterDivList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            string sqlString = string.Empty;
            masterDivList = new ArrayList();
            SecMngSndRcvWork secMngSndRcvWork = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

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

                sqlCommand = new SqlCommand("", sqlConnection);

                // Selectコマンドの生成
                sqlString += " SELECT " + Environment.NewLine;
                sqlString += "     A.MASTERNAMERF" + Environment.NewLine;
                sqlString += "    ,A.FILEIDRF" + Environment.NewLine;
                sqlString += "    ,A.SECMNGSENDDIVRF" + Environment.NewLine;
                sqlString += "    ,A.USERGUIDEDIVCDRF" + Environment.NewLine;   // ADD 2012/07/26 姚学剛
                sqlString += " FROM" + Environment.NewLine;
                sqlString += "    SECMNGSNDRCVRF A WITH (READUNCOMMITTED)  " + Environment.NewLine;
                sqlString += " WHERE ";
                // 企業コード
                sqlString += " A.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // 論理削除区分
                sqlString += " AND A.LOGICALDELETECODERF=@LOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sqlString;

                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    secMngSndRcvWork = new SecMngSndRcvWork();
                    secMngSndRcvWork.MasterName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MASTERNAMERF"));
                    secMngSndRcvWork.FileId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILEIDRF"));
                    secMngSndRcvWork.SecMngSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECMNGSENDDIVRF"));
                    secMngSndRcvWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));   // ADD 2012/07/26 姚学剛
                    secMngSndRcvWork.EnterpriseCode = enterpriseCode;//ADD 2012/10/16 李亜博 for redmine#31026
                    masterDivList.Add(secMngSndRcvWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APMSTControlDB.SearchMstDoDiv SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "APMSTControlDB.SearchMstDoDiv Exception=" + e.Message);
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

        /// <summary>
        /// 受信マスタ名称区分を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterDivList">マスタ名称区分リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受信マスタ名称区分取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        public int SearchReceMstDoDiv(string enterpriseCode, out ArrayList masterDivList)
        {
            return SearchReceMstDoDivProc(enterpriseCode, out masterDivList);
        }
        /// <summary>
        /// 受信マスタ名称区分を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterDivList">マスタ名称区分リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受信マスタ名称区分取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        /// <br>Update Note : 2012/07/26 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        private int SearchReceMstDoDivProc(string enterpriseCode, out ArrayList masterDivList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            string sqlString = string.Empty;
            masterDivList = new ArrayList();
            SecMngSndRcvWork secMngSndRcvWork = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

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

                sqlCommand = new SqlCommand("", sqlConnection);

                // Selectコマンドの生成
                sqlString += " SELECT " + Environment.NewLine;
                sqlString += "     A.MASTERNAMERF" + Environment.NewLine;
                sqlString += "    ,A.FILEIDRF" + Environment.NewLine;
                sqlString += "    ,A.SECMNGRECVDIVRF" + Environment.NewLine;
                sqlString += "    ,A.USERGUIDEDIVCDRF" + Environment.NewLine;   // ADD 2012/07/26 姚学剛
                sqlString += " FROM" + Environment.NewLine;
                sqlString += "    SECMNGSNDRCVRF A WITH (READUNCOMMITTED)  " + Environment.NewLine;
                sqlString += " WHERE ";
                // 企業コード
                sqlString += " A.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // 論理削除区分
                sqlString += " AND A.LOGICALDELETECODERF=@LOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sqlString;

                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    secMngSndRcvWork = new SecMngSndRcvWork();
                    secMngSndRcvWork.MasterName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MASTERNAMERF"));
                    secMngSndRcvWork.FileId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILEIDRF"));
                    secMngSndRcvWork.SecMngRecvDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECMNGRECVDIVRF"));
                    secMngSndRcvWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));   // ADD 2012/07/26 姚学剛
                    secMngSndRcvWork.EnterpriseCode = enterpriseCode;//ADD 2012/10/16 李亜博 for redmine#31026
                    masterDivList.Add(secMngSndRcvWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "MSTControlDB.SearchMstName SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "MSTControlDB.SearchMstName Exception=" + e.Message);
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


        /// <summary>
        /// 受信マスタ名称明細区分を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterDtlDivList">マスタ名称明細区分リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受信マスタ名称明細区分取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        public int SearchReceMstDtlDoDiv(string enterpriseCode, out ArrayList masterDtlDivList)
        {
            return SearchReceMstDtlDoDivProc( enterpriseCode, out  masterDtlDivList);
        }
        /// <summary>
        /// 受信マスタ名称明細区分を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterDtlDivList">マスタ名称明細区分リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受信マスタ名称明細区分取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        private int SearchReceMstDtlDoDivProc(string enterpriseCode, out ArrayList masterDtlDivList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            string sqlString = string.Empty;
            masterDtlDivList = new ArrayList();
            SecMngSndRcvDtlWork secMngSndRcvDtlWork = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

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

                sqlCommand = new SqlCommand("", sqlConnection);

                // Selectコマンドの生成
                sqlString += " SELECT " + Environment.NewLine;
                sqlString += "     A.FILENMRF" + Environment.NewLine;
                sqlString += "    ,A.ITEMIDRF" + Environment.NewLine;
                sqlString += "    ,A.DATAUPDATEDIVRF" + Environment.NewLine;
                sqlString += " FROM" + Environment.NewLine;
                sqlString += "    SECMNGSNDRCVDTLRF A WITH (READUNCOMMITTED)  " + Environment.NewLine;
                sqlString += " WHERE ";
                // 企業コード
                sqlString += " A.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // 論理削除区分
                sqlString += " AND A.LOGICALDELETECODERF=@LOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sqlString;

                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    secMngSndRcvDtlWork = new SecMngSndRcvDtlWork();
                    secMngSndRcvDtlWork.FileNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILENMRF"));
                    secMngSndRcvDtlWork.ItemId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ITEMIDRF"));
                    secMngSndRcvDtlWork.DataUpdateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAUPDATEDIVRF"));
                    masterDtlDivList.Add(secMngSndRcvDtlWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "MSTControlDB.SearchMstName SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "MSTControlDB.SearchMstName Exception=" + e.Message);
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

         /// <summary>
        /// 受信マスタ名称を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterNameList">マスタ名称リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受信マスタ名称を取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        public int SearchReceMstName(string enterpriseCode, out ArrayList masterNameList)
        {
            return SearchReceMstNameProc( enterpriseCode, out  masterNameList);
        }
        /// <summary>
        /// 受信マスタ名称を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterNameList">マスタ名称リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受信マスタ名称を取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        private int SearchReceMstNameProc(string enterpriseCode, out ArrayList masterNameList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            string sqlString = string.Empty;
            masterNameList = new ArrayList();
            SecMngSndRcvWork secMngSndRcvWork = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

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

                sqlCommand = new SqlCommand("", sqlConnection);

                // Selectコマンドの生成
                sqlString += " SELECT DISTINCT" + Environment.NewLine;
                sqlString += "     A.MASTERNAMERF" + Environment.NewLine;
                sqlString += "    ,A.USERGUIDEDIVCDRF" + Environment.NewLine;
                sqlString += "    ,A.DISPLAYORDERRF" + Environment.NewLine;
                sqlString += " FROM" + Environment.NewLine;
                sqlString += "    SECMNGSNDRCVRF A WITH (READUNCOMMITTED)  " + Environment.NewLine;
                sqlString += " WHERE ";
                // 企業コード
                sqlString += "A.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // 論理削除区分
                sqlString += "AND A.LOGICALDELETECODERF=@LOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                // ADD 2009/05/25 --->>>
                // 表示順位100以上
                sqlString += " AND A.DISPLAYORDERRF > @DISPLAYORDER ";
                SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(100);
                // ADD 2009/05/25 ---<<<

                // 拠点管理受信区分
                sqlString += "AND A.SECMNGRECVDIVRF!=@SECMNGRECVDIVRF ";
                SqlParameter paraSecMngSendDiv = sqlCommand.Parameters.Add("@SECMNGRECVDIVRF", SqlDbType.Int);
                paraSecMngSendDiv.Value = SqlDataMediator.SqlSetInt32(0);

                // ORDER BY
                sqlString += "ORDER BY A.DISPLAYORDERRF ";

                sqlCommand.CommandText = sqlString;

                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    secMngSndRcvWork = new SecMngSndRcvWork();
                    secMngSndRcvWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF")); //ADD 2011/07/25
                    secMngSndRcvWork.MasterName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MASTERNAMERF"));
                    secMngSndRcvWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    masterNameList.Add(secMngSndRcvWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "MSTControlDB.SearchMstName SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "MSTControlDB.SearchMstName Exception=" + e.Message);
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

        /// <summary>
        /// 送信のシンク日時を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secMngSetArrList">シンク日時リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送信のシンク日時を取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        public int SearchSyncExecDate(string enterpriseCode, out ArrayList secMngSetArrList)
        {
            return SearchSyncExecDateProc( enterpriseCode, out secMngSetArrList);
        }
        /// <summary>
        /// 送信のシンク日時を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secMngSetArrList">シンク日時リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送信のシンク日時を取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        private int SearchSyncExecDateProc(string enterpriseCode, out ArrayList secMngSetArrList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            secMngSetArrList = new ArrayList();
            APMSTSecMngSetWork secMngSetWork = null;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string sqlString = string.Empty;

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
                sqlString += " SELECT" + Environment.NewLine;
                sqlString += "      A.SECTIONCODERF" + Environment.NewLine;
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                sqlString += "     ,A.SENDDESTSECCODERF" + Environment.NewLine;
                sqlString += "     ,A.AUTOSENDDIVRF" + Environment.NewLine;
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                sqlString += "     ,A.SYNCEXECDATERF" + Environment.NewLine;
                sqlString += "     ,B.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlString += " FROM" + Environment.NewLine;
                sqlString += "      SECMNGSETRF A WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlString += "     ,SECINFOSETRF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlString += " WHERE";
                // 企業コード
                sqlString += " A.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                //拠点コード
                sqlString += " AND A.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString("00");
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                // 種別(1:マスタ)
                sqlString += " AND A.KINDRF=@KINDRF ";
                SqlParameter paraKind = sqlCommand.Parameters.Add("@KINDRF", SqlDbType.Int);
                paraKind.Value = SqlDataMediator.SqlSetInt32(1);
                // 受信状況(0:送信1:受信)
                sqlString += " AND A.RECEIVECONDITIONRF=@RECEIVECONDITIONRF ";
                SqlParameter paraReceiveCondition = sqlCommand.Parameters.Add("@RECEIVECONDITIONRF", SqlDbType.Int);
                paraReceiveCondition.Value = SqlDataMediator.SqlSetInt32(0);
                // 論理削除区分
                sqlString += " AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ";
                SqlParameter paraALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                paraALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 論理削除区分
                sqlString += " AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ";
                SqlParameter paraBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                paraBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                //sqlString += " AND A.ENTERPRISECODERF = B.ENTERPRISECODERF AND A.SECTIONCODERF = B.SECTIONCODERF";//DEL 2011/07/25
                sqlString += " AND A.ENTERPRISECODERF = B.ENTERPRISECODERF AND A.SENDDESTSECCODERF = B.SECTIONCODERF";//ADD 2011/07/25


                sqlCommand.CommandText = sqlString;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    secMngSetWork = new APMSTSecMngSetWork();
                    secMngSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                    secMngSetWork.SendDestSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDDESTSECCODERF"));
                    secMngSetWork.AutoSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOSENDDIVRF"));
                    //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                    secMngSetWork.SyncExecDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("SYNCEXECDATERF"));
                    secMngSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    secMngSetArrList.Add(secMngSetWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "MSTControlDB.SearchSyncExecDate Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "MSTControlDB.SearchSyncExecDate Exception=" + e.Message);
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

        /// <summary>
        /// 受信のシンク日時を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secMngSetArrList">シンク日時リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受信のシンク日時を取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        public int SearchReceSyncExecDate(string enterpriseCode, out ArrayList secMngSetArrList)
        {
            return SearchReceSyncExecDateProc(enterpriseCode, out secMngSetArrList);
        }
        /// <summary>
        /// 受信のシンク日時を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secMngSetArrList">シンク日時リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受信のシンク日時を取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        /// <br>Update Note: 2011/10/08 yangmj</br>
        /// <br>             Redmine #25778の対応</br>
        private int SearchReceSyncExecDateProc(string enterpriseCode, out ArrayList secMngSetArrList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            secMngSetArrList = new ArrayList();
            APMSTSecMngSetWork secMngSetWork = null;
            string resNm = "";

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            SqlTransaction sqlTransaction = null;
            string sqlString = string.Empty;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (_connectionText == null || _connectionText == "")
            {
                return status;
            }

            sqlConnection = new SqlConnection(_connectionText);
            sqlConnection.Open();

#if DEBUG
            // トランザクション
            sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            resNm = GetResourceName(enterpriseCode);
            // MOD 2009/07/06 --->>>
            //ＡＰロック
            status = Lock(resNm, 1, sqlConnection, sqlTransaction);
            // MOD 2009/07/06 ---<<<

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            try
            {
                // Selectコマンドの生成
                sqlString += " SELECT" + Environment.NewLine;
                sqlString += "      A.SECTIONCODERF" + Environment.NewLine;
                sqlString += "     ,A.SYNCEXECDATERF" + Environment.NewLine;
                sqlString += "     ,B.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlString += " FROM" + Environment.NewLine;
                sqlString += "      SECMNGSETRF A WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlString += "     ,SECINFOSETRF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlString += "     ,SECMNGEPSETRF C WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlString += " WHERE";
                // 企業コード
                sqlString += " A.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                // 種別(1:マスタ)
                sqlString += " AND A.KINDRF=@KINDRF ";
                SqlParameter paraKind = sqlCommand.Parameters.Add("@KINDRF", SqlDbType.Int);
                paraKind.Value = SqlDataMediator.SqlSetInt32(1);
                // 受信状況(0:送信1:受信)
                sqlString += " AND A.RECEIVECONDITIONRF=@RECEIVECONDITIONRF ";
                SqlParameter paraReceiveCondition = sqlCommand.Parameters.Add("@RECEIVECONDITIONRF", SqlDbType.Int);
                paraReceiveCondition.Value = SqlDataMediator.SqlSetInt32(1);
                // 論理削除区分
                sqlString += " AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ";
                SqlParameter paraALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                paraALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 論理削除区分
                sqlString += " AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ";
                SqlParameter paraBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                paraBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlString += " AND A.ENTERPRISECODERF = B.ENTERPRISECODERF AND A.SECTIONCODERF = B.SECTIONCODERF ";
                sqlString += " AND A.ENTERPRISECODERF = C.ENTERPRISECODERF AND C.LOGICALDELETECODERF = 0 AND A.SECTIONCODERF = C.SECTIONCODERF ";

                sqlCommand.CommandText = sqlString;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    secMngSetWork = new APMSTSecMngSetWork();
                    secMngSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    secMngSetWork.SyncExecDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("SYNCEXECDATERF"));
                    secMngSetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    secMngSetArrList.Add(secMngSetWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "MSTControlDB.SearchSyncExecDate Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "MSTControlDB.SearchSyncExecDate Exception=" + e.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose(); // ADD 2011/10/08
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

        /// <summary>
        /// PM企業コードを取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="pmCode">PM企業コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PM企業コードを取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        public int SeachPmCode(string enterpriseCode, string baseCode, out string pmCode)
        {
            return SeachPmCodeProc(enterpriseCode,  baseCode, out  pmCode);
        }
        /// <summary>
        /// PM企業コードを取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="pmCode">PM企業コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PM企業コードを取得する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        private int SeachPmCodeProc(string enterpriseCode, string baseCode, out string pmCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            string sqlString = string.Empty;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            pmCode = string.Empty;

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

                sqlCommand = new SqlCommand("", sqlConnection);

                // Selectコマンドの生成
                sqlString += " SELECT " + Environment.NewLine;
                sqlString += "     A.PMENTERPRISECODERF " + Environment.NewLine;
                sqlString += " FROM" + Environment.NewLine;
                sqlString += "    SECMNGEPSETRF A WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlString += " WHERE ";
                // 企業コード
                sqlString += " A.ENTERPRISECODERF=@FINDENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // 論理削除区分
                sqlString += " AND A.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                // 拠点管理受信区分
                sqlString += " AND A.SECTIONCODERF=@FINDSECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                sqlCommand.CommandText = sqlString;

                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    pmCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PMENTERPRISECODERF"));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "MSTControlDB.SearchMstName SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "MSTControlDB.SearchMstName Exception=" + e.Message);
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

        #region ◆ 拠点管理設定マスタの更新処理 ◆

         /// <summary>
        /// 送信拠点管理設定マスタの更新処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="updEmployeeCode">従業員コード</param>
        /// <param name="syncExecDt">シンク日時</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送信拠点管理設定マスタの更新処理を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        public int UpdateSecMngSet(string enterpriseCodes, string baseCode, string updEmployeeCode, DateTime syncExecDt, out string retMessage)
        {
            return UpdateSecMngSetProc(enterpriseCodes, baseCode, updEmployeeCode, syncExecDt, out retMessage);
        }
        /// <summary>
        /// 送信拠点管理設定マスタの更新処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="updEmployeeCode">従業員コード</param>
        /// <param name="syncExecDt">シンク日時</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送信拠点管理設定マスタの更新処理を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        private int UpdateSecMngSetProc(string enterpriseCodes, string baseCode, string updEmployeeCode, DateTime syncExecDt, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retMessage = string.Empty;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;

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
                sqlCommand = new SqlCommand("", sqlConnection);

                if (string.IsNullOrEmpty(updEmployeeCode))
                {
                    // 拠点管理設定マスタを更新する
                    //sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF = @SECTIONCODE";//DEL 2011/07/25
                    sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF = @SECTIONCODE AND SENDDESTSECCODERF = @SENDDESTSECCODE";//ADD 2011/07/25

                    //Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);

                    //Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(System.DateTime.Now);
                    paraSyncExecDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncExecDt);
                }
                else
                {
                    // 拠点管理設定マスタを更新する
                    //sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";//DEL 2011/07/25
                    sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF = @SECTIONCODE AND SENDDESTSECCODERF = @SENDDESTSECCODE";//ADD 2011/07/25

                    //Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);

                    //Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(System.DateTime.Now);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(updEmployeeCode);
                    paraSyncExecDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncExecDt);
                }



                //Parameterオブジェクトの作成(検索用)
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaKind = sqlCommand.Parameters.Add("@FINDKIND", SqlDbType.Int);
                SqlParameter findParaReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITION", SqlDbType.Int);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter findSendDestSecCode = sqlCommand.Parameters.Add("@SENDDESTSECCODE", SqlDbType.NChar);//ADD 2011/07/25

                //Parameterオブジェクトへ値設定(検索用)
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaKind.Value = SqlDataMediator.SqlSetInt32(1);
                findParaReceiveCondition.Value = SqlDataMediator.SqlSetInt32(0);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                //findSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);//DEL 2011/07/25
                //-----ADD 2011/07/25----->>>>>
                findSectionCode.Value = SqlDataMediator.SqlSetString("00");
                findSendDestSecCode.Value = SqlDataMediator.SqlSetString(baseCode);
                //-----ADD 2011/07/25-----<<<<<

                // 拠点管理設定マスタを更新する
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APMSTControlDB.UpdateSecMngSet Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 受信拠点管理設定マスタの更新処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="updEmployeeCode">従業員コード</param>
        /// <param name="syncExecDt">シンク日時</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受信拠点管理設定マスタの更新処理を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        public int UpdateReceSecMngSet(string enterpriseCodes, string baseCode, string updEmployeeCode, DateTime syncExecDt, out string retMessage)
        {
            return UpdateReceSecMngSetProc( enterpriseCodes,  baseCode,  updEmployeeCode,  syncExecDt, out  retMessage);
        }
        /// <summary>
        /// 受信拠点管理設定マスタの更新処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="updEmployeeCode">従業員コード</param>
        /// <param name="syncExecDt">シンク日時</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受信拠点管理設定マスタの更新処理を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        private int UpdateReceSecMngSetProc(string enterpriseCodes, string baseCode, string updEmployeeCode, DateTime syncExecDt, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retMessage = string.Empty;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;

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
                sqlCommand = new SqlCommand("", sqlConnection);

                if (string.IsNullOrEmpty(updEmployeeCode))
                {
                    // 拠点管理設定マスタを更新する
                    sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF = @SECTIONCODE";

                    //Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);

                    //Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(System.DateTime.Now);
                    paraSyncExecDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncExecDt);
                }
                else
                {
                    // 拠点管理設定マスタを更新する
                    sqlCommand.CommandText = "UPDATE SECMNGSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , SYNCEXECDATERF=@SYNCEXECDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND KINDRF=@FINDKIND AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND RECEIVECONDITIONRF=@FINDRECEIVECONDITION AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF = @SECTIONCODE";

                    //Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);

                    //Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(System.DateTime.Now);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(updEmployeeCode);
                    paraSyncExecDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncExecDt);
                }



                //Parameterオブジェクトの作成(検索用)
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaKind = sqlCommand.Parameters.Add("@FINDKIND", SqlDbType.Int);
                SqlParameter findParaReceiveCondition = sqlCommand.Parameters.Add("@FINDRECEIVECONDITION", SqlDbType.Int);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定(検索用)
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaKind.Value = SqlDataMediator.SqlSetInt32(1);
                findParaReceiveCondition.Value = SqlDataMediator.SqlSetInt32(1);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                // 拠点管理設定マスタを更新する
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APMSTControlDB.UpdateReceSecMngSet Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        #endregion ◆ 拠点管理設定マスタの更新処理 ◆

        # region ■ マスタ送信のデータ検索処理 ■
        /// <summary>
        /// マスタ送信のデータ検索処理
        /// </summary>
        /// <param name="masterDivList">マスタ名称区分</param>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="updSectionCode">拠点コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="retCSAList">検索結果</param>
        /// <param name="sndRcvHisConsNo">送信番号</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ送信処理READの実データ検索を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先メモ情報の追加</br>
        /// 
        //public int SearchCustomSerializeArrayList(ArrayList masterDivList, string enterpriseCodes, Int64 beginningDate, Int64 endingDate, ref CustomSerializeArrayList retCSAList, out string retMessage)//DEL 2011/07/25
        public int SearchCustomSerializeArrayList(ArrayList masterDivList, string enterpriseCodes, string updSectionCode, Int64 beginningDate, Int64 endingDate, ref CustomSerializeArrayList retCSAList, out int sndRcvHisConsNo, out string retMessage)//ADD 2011/07/25
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMessage = string.Empty;
            sndRcvHisConsNo = -1; //ADD 2011/07/25
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

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



#if DEBUG
                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif

                retCSAList = new CustomSerializeArrayList();

                foreach (SecMngSndRcvWork secMngSndRcvWork in masterDivList)
                {
                    // 拠点設定マスタ
                    if (MST_SECINFOSET.Equals(secMngSndRcvWork.MasterName) && MST_ID_SECINFOSET.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        secInfoSetInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 部門設定マスタ
                    if (MST_SUBSECTION.Equals(secMngSndRcvWork.MasterName) && MST_ID_SUBSECTION.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        subSectionInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 倉庫設定マスタ
                    if (MST_WAREHOUSE.Equals(secMngSndRcvWork.MasterName) && MST_ID_WAREHOUSE.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        warehouseInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 従業員マスタ
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEE.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        employeeInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 従業員詳細マスタ
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEEDTL.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        employeeDtlInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 得意先マスタ
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOME.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        customerInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 得意先マスタ(変動情報)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMECHA.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        customerChangeInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                    // 得意先マスタ(メモ情報)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMEMEMO.Equals(secMngSndRcvWork.FileId)
                        &&  Convert.ToInt32(CusMemoSedDiv.Add) == secMngSndRcvWork.SecMngSendDiv)
                    {
                        customerMemoInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                    // 得意先マスタ（伝票管理）
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMESLIPMNG.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        custSlipMngInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 得意先マスタ（掛率グループ）
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMEGROUP.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        custRateGroupInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 得意先マスタ(伝票番号)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMESLIPNO.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        custSlipNoSetInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 仕入先マスタ
                    if (MST_SUPPLIER.Equals(secMngSndRcvWork.MasterName) && MST_ID_SUPPLIER.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        supplierInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // メーカーマスタ（ユーザー登録分）
                    if (MST_MAKERU.Equals(secMngSndRcvWork.MasterName) && MST_ID_MAKERU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        makerUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // BL商品コードマスタ（ユーザー登録分）
                    if (MST_BLGOODSCDU.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLGOODSCDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        bLGoodsCdUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 商品マスタ（ユーザー登録分）
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        goodsUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 価格マスタ（ユーザー登録）
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUPRI.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        goodsPriceInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 商品管理情報マスタ
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUMNG.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        goodsMngInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 離島価格マスタ
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUISO.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        isolIslandPrcInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 在庫マスタ
                    if (MST_STOCK.Equals(secMngSndRcvWork.MasterName) && MST_ID_STOCK.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        stockInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ユーザーガイドマスタ(販売エリア区分）
                    if (MST_USERGDAREADIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdAreaDivUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ユーザーガイドマスタ（業務区分）
                    if (MST_USERGDBUSDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdBusDivUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ユーザーガイドマスタ（業種）
                    if (MST_USERGDCATEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdCateUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ユーザーガイドマスタ（職種）
                    if (MST_USERGDBUSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdBusUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ユーザーガイドマスタ（商品区分）
                    if (MST_USERGDGOODSDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdGoodsDivUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ユーザーガイドマスタ（得意先掛率グループ）
                    if (MST_USERGDCUSGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdCusGrouPUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ユーザーガイドマスタ（銀行）
                    if (MST_USERGDBANKU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdBankUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ユーザーガイドマスタ（価格区分）
                    if (MST_USERGDPRIDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdPriDivUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ユーザーガイドマスタ（納品区分）
                    if (MST_USERGDDELIDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdDeliDivUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ユーザーガイドマスタ（商品大分類）
                    if (MST_USERGDGOODSBIGU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdGoodsBigUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ユーザーガイドマスタ（販売区分）
                    if (MST_USERGDBUYDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdBuyDivUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ユーザーガイドマスタ（在庫管理区分１）
                    if (MST_USERGDSTOCKDIVOU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdStockDivOUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ユーザーガイドマスタ（在庫管理区分２）
                    if (MST_USERGDSTOCKDIVTU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdStockDivTUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ユーザーガイドマスタ（返品理由）
                    if (MST_USERGDRETURNREAU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdReturnReaUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 掛率優先管理マスタ
                    if (MST_RATEPROTYMNG.Equals(secMngSndRcvWork.MasterName) && MST_ID_RATEPROTYMNG.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        rateProtyMngInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 掛率マスタ
                    if (MST_RATE.Equals(secMngSndRcvWork.MasterName) && MST_ID_RATE.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        rateInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 商品セットマスタ
                    if (MST_GOODSSET.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSSET.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        goodsSetInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 部品代替マスタ（ユーザー登録分）
                    if (MST_PARTSSUBSTU.Equals(secMngSndRcvWork.MasterName) && MST_ID_PARTSSUBSTU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        partsSubstUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 従業員別売上目標設定マスタ
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        empSalesTargetInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 得意先別売上目標設定マスタ
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        custSalesTargetInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 商品別売上目標設定マスタ
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_GCDSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        gcdSalesTargetInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 商品中分類マスタ（ユーザー登録分）
                    if (MST_GOODSMGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSMGROUPU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        goodsMGroupUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // BLグループマスタ（ユーザー登録分）
                    if (MST_BLGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLGROUPU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        bLGroupUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 結合マスタ（ユーザー登録分）
                    if (MST_JOINPARTSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_JOINPARTSU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        joinPartsUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // TBO検索マスタ（ユーザー登録）
                    if (MST_TBOSEARCHU.Equals(secMngSndRcvWork.MasterName) && MST_ID_TBOSEARCHU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        tBOSearchUCountInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 部位コードマスタ（ユーザー登録）
                    if (MST_PARTSPOSCODEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_PARTSPOSCODEU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        partsPosCodeUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // BLコードガイドマスタ
                    if (MST_BLCODEGUIDE.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLCODEGUIDE.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        bLCodeGuideInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 車種名称マスタ
                    if (MST_MODELNAMEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_MODELNAMEU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        modelNameUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                }


                if (secInfoSetInt == 1)
                {
                    // 拠点情報設定マスタデータ抽出
                    ArrayList secInfoSetArrList = new ArrayList();
                    APSecInfoSetDB _secInfoSetDB = new APSecInfoSetDB();
                    status = _secInfoSetDB.SearchSecInfoSet(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out secInfoSetArrList, out retMessage);
                    retCSAList.Add(secInfoSetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && subSectionInt == 1)
                {

                    // 部門マスタデータ抽出
                    ArrayList subSectionArrList = new ArrayList();
                    APSubSectionDB _subSectionDB = new APSubSectionDB();
                    status = _subSectionDB.SearchSubSection(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out subSectionArrList, out retMessage);
                    retCSAList.Add(subSectionArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeInt == 1)
                {
                    // 従業員マスタデータ抽出
                    ArrayList employeeArrList = new ArrayList();
                    APEmployeeDB _employeeDB = new APEmployeeDB();
                    status = _employeeDB.SearchEmployee(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out employeeArrList, out retMessage);
                    retCSAList.Add(employeeArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeDtlInt == 1)
                {
                    // 従業員詳細マスタデータ抽出
                    ArrayList employeeDtlArrList = new ArrayList();
                    APEmployeeDtlDB _employeeDtlDB = new APEmployeeDtlDB();
                    status = _employeeDtlDB.SearchEmployeeDtl(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out employeeDtlArrList, out retMessage);
                    retCSAList.Add(employeeDtlArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && warehouseInt == 1)
                {
                    // 倉庫マスタデータ抽出
                    ArrayList warehouseArrList = new ArrayList();
                    APWarehouseDB _warehouseDB = new APWarehouseDB();
                    status = _warehouseDB.SearchWarehouse(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out warehouseArrList, out retMessage);
                    retCSAList.Add(warehouseArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInt == 1)
                {
                    // 得意先マスタデータ抽出
                    ArrayList customerArrList = new ArrayList();
                    APCustomerDB _customerDB = new APCustomerDB();
                    status = _customerDB.SearchCustomer(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out customerArrList, out retMessage);
                    retCSAList.Add(customerArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerChangeInt == 1)
                {
                    // 得意先マスタ(変動情報)データ抽出
                    ArrayList customerChangeArrList = new ArrayList();
                    APCustomerChangeDB _customerChangeDB = new APCustomerChangeDB();
                    status = _customerChangeDB.SearchCustomerChange(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out customerChangeArrList, out retMessage);
                    retCSAList.Add(customerChangeArrList);
                }
                // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerMemoInt ==  Convert.ToInt32(CusMemoSedDiv.Add))
                {
                    // 得意先マスタ(メモ情報)データ抽出
                    ArrayList customerMemoArrList = new ArrayList();
                    APCustomerMemoDB _customerMemoDB = new APCustomerMemoDB();
                    status = _customerMemoDB.SearchCustomerMemo(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out customerMemoArrList, out retMessage);
                    retCSAList.Add(customerMemoArrList);
                }
                // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && custSlipMngInt == 1)
                {
                    // 得意先マスタ（伝票管理）データ抽出
                    ArrayList custSlipMngArrList = new ArrayList();
                    APCustSlipMngDB _custSlipMngDB = new APCustSlipMngDB();
                    status = _custSlipMngDB.SearchCustSlipMng(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custSlipMngArrList, out retMessage);
                    retCSAList.Add(custSlipMngArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && custRateGroupInt == 1)
                {
                    // 得意先マスタ（掛率グループ）データ抽出
                    ArrayList custRateGroupArrList = new ArrayList();
                    APCustRateGroupDB _custRateGroupDB = new APCustRateGroupDB();
                    status = _custRateGroupDB.SearchCustRateGroup(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custRateGroupArrList, out retMessage);
                    retCSAList.Add(custRateGroupArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && custSlipNoSetInt == 1)
                {
                    // 得意先マスタ(伝票番号)データ抽出
                    ArrayList custSlipNoSetArrList = new ArrayList();
                    APCustSlipNoSetDB _custSlipNoSetDB = new APCustSlipNoSetDB();
                    status = _custSlipNoSetDB.SearchCustSlipNoSet(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custSlipNoSetArrList, out retMessage);
                    retCSAList.Add(custSlipNoSetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplierInt == 1)
                {
                    // 仕入先マスタデータ抽出
                    ArrayList supplierArrList = new ArrayList();
                    APSupplierDB _supplierDB = new APSupplierDB();
                    status = _supplierDB.SearchSupplier(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out supplierArrList, out retMessage);
                    retCSAList.Add(supplierArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && makerUInt == 1)
                {
                    ArrayList makerUArrList = new ArrayList();
                    APMakerUDB _makerUDB = new APMakerUDB();
                    // メーカーマスタ（ユーザー登録分）データ抽出
                    status = _makerUDB.SearchMakerU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref makerUArrList, out retMessage);
                    retCSAList.Add(makerUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && bLGoodsCdUInt == 1)
                {
                    // BL商品コードマスタ（ユーザー登録分）データ抽出
                    ArrayList bLGoodsCdUArrList = new ArrayList();
                    APBLGoodsCdUDB _bLGoodsCdUDB = new APBLGoodsCdUDB();
                    status = _bLGoodsCdUDB.SearchBLGoodsCdU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out bLGoodsCdUArrList, out retMessage);
                    retCSAList.Add(bLGoodsCdUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsUInt == 1)
                {
                    // 商品マスタ（ユーザー登録分）データ抽出
                    ArrayList goodsUArrList = new ArrayList();
                    APGoodsUDB _goodsUDB = new APGoodsUDB();
                    status = _goodsUDB.SearchGoodsU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsUArrList, out retMessage);
                    retCSAList.Add(goodsUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsPriceInt == 1)
                {
                    // 価格マスタ（ユーザー登録）データ抽出
                    ArrayList goodsPriceUArrList = new ArrayList();
                    APGoodsPriceUDB _goodsPriceUDB = new APGoodsPriceUDB();
                    status = _goodsPriceUDB.SearchGoodsPriceU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsPriceUArrList, out retMessage);
                    retCSAList.Add(goodsPriceUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsMngInt == 1)
                {
                    // 商品管理情報マスタデータ抽出
                    ArrayList goodsMngArrList = new ArrayList();
                    APGoodsMngDB _goodsMngDB = new APGoodsMngDB();
                    status = _goodsMngDB.SearchGoodsMng(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsMngArrList, out retMessage);
                    retCSAList.Add(goodsMngArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && isolIslandPrcInt == 1)
                {
                    // 離島価格マスタデータ抽出
                    ArrayList isolIslandPrcArrList = new ArrayList();
                    APIsolIslandPrcDB _isolIslandPrcDB = new APIsolIslandPrcDB();
                    status = _isolIslandPrcDB.SearchIsolIslandPrc(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out isolIslandPrcArrList, out retMessage);
                    retCSAList.Add(isolIslandPrcArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockInt == 1)
                {
                    // 在庫マスタデータ抽出
                    ArrayList stockArrList = new ArrayList();
                    APStockDB _stockDB = new APStockDB();
                    status = _stockDB.SearchStock(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockArrList, out retMessage);
                    retCSAList.Add(stockArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ユーザーガイドマスタデータ抽出
                    ArrayList userGdBdUArrList = new ArrayList();
                    APUserGdBdUDB _userGdBdUDB = new APUserGdBdUDB();
                    // ユーザーガイドマスタ(販売エリア区分）
                    if (userGdAreaDivUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(21, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（業務区分）
                    if (userGdBusDivUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(31, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（業種）
                    if (userGdCateUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(33, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（職種）
                    if (userGdBusUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(34, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（商品区分）
                    if (userGdGoodsDivUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(41, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（得意先掛率グループ）
                    if (userGdCusGrouPUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(43, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（銀行）
                    if (userGdBankUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(46, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（価格区分）
                    if (userGdPriDivUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(47, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（納品区分）
                    if (userGdDeliDivUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(48, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（商品大分類）
                    if (userGdGoodsBigUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(70, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（販売区分）
                    if (userGdBuyDivUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(71, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（在庫管理区分１）
                    if (userGdStockDivOUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(72, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（在庫管理区分２）
                    if (userGdStockDivTUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(73, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（返品理由）
                    if (userGdReturnReaUInt == 1)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(91, enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    retCSAList.Add(userGdBdUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && rateProtyMngInt == 1)
                {
                    // 掛率優先管理マスタデータ抽出
                    ArrayList rateProtyMngArrList = new ArrayList();
                    APRateProtyMngDB _rateProtyMngDB = new APRateProtyMngDB();
                    status = _rateProtyMngDB.SearchRateProtyMng(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out rateProtyMngArrList, out retMessage);
                    retCSAList.Add(rateProtyMngArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && rateInt == 1)
                {
                    // 掛率マスタデータ抽出
                    ArrayList rateArrList = new ArrayList();
                    APRateDB _rateDB = new APRateDB();
                    status = _rateDB.SearchRate(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out rateArrList, out retMessage);
                    retCSAList.Add(rateArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsSetInt == 1)
                {
                    // 商品セットマスタデータ抽出
                    ArrayList goodsSetArrList = new ArrayList();
                    APGoodsSetDB _goodsSetDB = new APGoodsSetDB();
                    status = _goodsSetDB.SearchGoodsSet(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsSetArrList, out retMessage);
                    retCSAList.Add(goodsSetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && partsSubstUInt == 1)
                {
                    // 部品代替マスタ（ユーザー登録分）データ抽出
                    ArrayList partsSubstUArrList = new ArrayList();
                    APPartsSubstUDB _partsSubstUDB = new APPartsSubstUDB();
                    status = _partsSubstUDB.SearchPartsSubstU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out partsSubstUArrList, out retMessage);
                    retCSAList.Add(partsSubstUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && empSalesTargetInt == 1)
                {
                    // 従業員別売上目標設定マスタデータ抽出
                    ArrayList empSalesTargetArrList = new ArrayList();
                    APEmpSalesTargetDB _empSalesTargetDB = new APEmpSalesTargetDB();
                    status = _empSalesTargetDB.SearchEmpSalesTarget(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out empSalesTargetArrList, out retMessage);
                    retCSAList.Add(empSalesTargetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && custSalesTargetInt == 1)
                {
                    // 得意先別売上目標設定マスタデータ抽出
                    ArrayList custSalesTargetArrList = new ArrayList();
                    APCustSalesTargetDB _custSalesTargetDB = new APCustSalesTargetDB();
                    status = _custSalesTargetDB.SearchCustSalesTarget(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custSalesTargetArrList, out retMessage);
                    retCSAList.Add(custSalesTargetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && gcdSalesTargetInt == 1)
                {
                    // 商品別売上目標設定マスタデータ抽出
                    ArrayList gcdSalesTargetArrList = new ArrayList();
                    APGcdSalesTargetDB _gcdSalesTargetDB = new APGcdSalesTargetDB();
                    status = _gcdSalesTargetDB.SearchGcdSalesTarget(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out gcdSalesTargetArrList, out retMessage);
                    retCSAList.Add(gcdSalesTargetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsMGroupUInt == 1)
                {
                    // 商品中分類マスタ（ユーザー登録分）データ抽出
                    ArrayList goodsGroupUArrList = new ArrayList();
                    APGoodsGroupUDB _goodsGroupUDB = new APGoodsGroupUDB();
                    status = _goodsGroupUDB.SearchGoodsGroupU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsGroupUArrList, out retMessage);
                    retCSAList.Add(goodsGroupUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && bLGroupUInt == 1)
                {
                    // BLグループマスタ（ユーザー登録分）データ抽出
                    ArrayList bLGroupUArrList = new ArrayList();
                    APBLGroupUDB _bLGroupUDB = new APBLGroupUDB();
                    status = _bLGroupUDB.SearchBLGroupU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out bLGroupUArrList, out retMessage);
                    retCSAList.Add(bLGroupUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && joinPartsUInt == 1)
                {
                    // 結合マスタ（ユーザー登録分）データ抽出
                    ArrayList joinPartsUArrList = new ArrayList();
                    APJoinPartsUDB _joinPartsUDB = new APJoinPartsUDB();
                    status = _joinPartsUDB.SearchJoinPartsU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out joinPartsUArrList, out retMessage);
                    retCSAList.Add(joinPartsUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && tBOSearchUCountInt == 1)
                {
                    // TBO検索マスタ（ユーザー登録）データ抽出
                    ArrayList tBOSearchUArrList = new ArrayList();
                    APTBOSearchUDB _tBOSearchUDB = new APTBOSearchUDB();
                    status = _tBOSearchUDB.SearchTBOSearchU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out tBOSearchUArrList, out retMessage);
                    retCSAList.Add(tBOSearchUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && partsPosCodeUInt == 1)
                {
                    // 部位コードマスタ（ユーザー登録）データ抽出
                    ArrayList partsPosCodeUArrList = new ArrayList();
                    APPartsPosCodeUDB _partsPosCodeUDB = new APPartsPosCodeUDB();
                    status = _partsPosCodeUDB.SearchPartsPosCodeU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out partsPosCodeUArrList, out retMessage);
                    retCSAList.Add(partsPosCodeUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && bLCodeGuideInt == 1)
                {
                    // BLコードガイドマスタデータ抽出
                    ArrayList bLCodeGuideArrList = new ArrayList();
                    APBLCodeGuideDB _bLCodeGuideDB = new APBLCodeGuideDB();
                    status = _bLCodeGuideDB.SearchBLCodeGuide(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out bLCodeGuideArrList, out retMessage);
                    retCSAList.Add(bLCodeGuideArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && modelNameUInt == 1)
                {
                    // 部門マスタデータ抽出
                    ArrayList modelNameUArrList = new ArrayList();
                    APModelNameUDB _modelNameUDB = new APModelNameUDB();
                    status = _modelNameUDB.SearchModelNameU(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out modelNameUArrList, out retMessage);
                    retCSAList.Add(modelNameUArrList);
                }
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                if (retCSAList.Count > 0)
                {
                    long no = -1;
                    NumberingManager numberingManager = new NumberingManager();
                    SerialNumberCode serialnumcd = SerialNumberCode.SndRcvHisConsNo;
                    status = numberingManager.GetSerialNumber(enterpriseCodes, updSectionCode.Trim(), serialnumcd, out no);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && no != -1)
                    {
                        sndRcvHisConsNo = (int)no;
                    }
                }
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            }
            catch (Exception ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APMSTControlDB.SearchCustomSerializeArrayList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region ■ マスタ送信の更新処理 ■
        /// <summary>
        /// マスタ送信の更新処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterDivList">マスタ区分</param>
        /// <param name="masterDtlDivList">マスタ詳細区分</param>
        /// <param name="retCSAList">シンク日時</param>
        /// <param name="pmEnterpriseCode">PM企業コード</param>
        /// <param name="isEmpty">空判断</param>
        /// <param name="searchCountWork">検索ワーク</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : マスタ送信の更新を処理する。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先メモ情報の追加</br>
        /// </remarks>
        public int Update(string enterpriseCode, ArrayList masterDivList, ArrayList masterDtlDivList, ref CustomSerializeArrayList retCSAList, string pmEnterpriseCode, out bool isEmpty, out MstSearchCountWorkWork searchCountWork, out string retMessage)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 拠点情報設定データ
            Int32 secInfoSetCount = 0;
            // 部門マスタ
            Int32 subSectionCount = 0;
            // 従業員マスタ
            Int32 employeeCount = 0;
            // 従業員詳細マスタ
            Int32 employeeDtlCount = 0;
            // 倉庫マスタ
            Int32 warehouseCount = 0;
            // 得意先マスタ
            Int32 customerCount = 0;
            // 得意先マスタ(変動情報)
            Int32 customerChangeCount = 0;
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            // 得意先マスタ(メモ情報)
            Int32 customerMemoCount = CNT_ZERO;
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
            // 得意先マスタ（伝票管理）
            Int32 custSlipMngCount = 0;
            // 得意先マスタ（掛率グループ）
            Int32 custRateGroupCount = 0;
            // 得意先マスタ(伝票番号)
            Int32 custSlipNoSetCount = 0;
            // 仕入先マスタ
            Int32 supplierCount = 0;
            // メーカーマスタ（ユーザー登録分）
            Int32 makerUCount = 0;
            // BL商品コードマスタ（ユーザー登録分）
            Int32 bLGoodsCdUCount = 0;
            // 商品マスタ（ユーザー登録分）
            Int32 goodsUCount = 0;
            // 価格マスタ（ユーザー登録）
            Int32 goodsPriceCount = 0;
            // 商品管理情報マスタ
            Int32 goodsMngCount = 0;
            // 離島価格マスタ
            Int32 isolIslandPrcCount = 0;
            // 在庫マスタ
            Int32 stockCount = 0;
            // ユーザーガイドマスタ(販売エリア区分）
            Int32 userGdAreaDivUCount = 0;
            // ユーザーガイドマスタ（業務区分）
            Int32 userGdBusDivUCount = 0;
            // ユーザーガイドマスタ（業種）
            Int32 userGdCateUCount = 0;
            // ユーザーガイドマスタ（職種）
            Int32 userGdBusUCount = 0;
            // ユーザーガイドマスタ（商品区分）
            Int32 userGdGoodsDivUCount = 0;
            // ユーザーガイドマスタ（得意先掛率グループ）
            Int32 userGdCusGrouPUCount = 0;
            // ユーザーガイドマスタ（銀行）
            Int32 userGdBankUCount = 0;
            // ユーザーガイドマスタ（価格区分）
            Int32 userGdPriDivUCount = 0;
            // ユーザーガイドマスタ（納品区分）
            Int32 userGdDeliDivUCount = 0;
            // ユーザーガイドマスタ（商品大分類）
            Int32 userGdGoodsBigUCount = 0;
            // ユーザーガイドマスタ（販売区分）
            Int32 userGdBuyDivUCount = 0;
            // ユーザーガイドマスタ（在庫管理区分１）
            Int32 userGdStockDivOUCount = 0;
            // ユーザーガイドマスタ（在庫管理区分２）
            Int32 userGdStockDivTUCount = 0;
            // ユーザーガイドマスタ（返品理由）
            Int32 userGdReturnReaUCount = 0;
            // 掛率優先管理マスタ
            Int32 rateProtyMngCount = 0;
            // 掛率マスタ
            Int32 rateCount = 0;
            // 商品セットマスタ
            Int32 goodsSetCount = 0;
            // 部品代替マスタ（ユーザー登録分）
            Int32 partsSubstUCount = 0;
            // 従業員別売上目標設定マスタ
            Int32 empSalesTargetCount = 0;
            // 得意先別売上目標設定マスタ
            Int32 custSalesTargetCount = 0;
            // 商品別売上目標設定マスタ
            Int32 gcdSalesTargetCount = 0;
            // 商品中分類マスタ（ユーザー登録分）
            Int32 goodsMGroupUCount = 0;
            // BLグループマスタ（ユーザー登録分）
            Int32 bLGroupUCount = 0;
            // 結合マスタ（ユーザー登録分）
            Int32 joinPartsUCount = 0;
            // TBO検索マスタ（ユーザー登録）
            Int32 tBOSearchUCount = 0;
            // 部位コードマスタ（ユーザー登録）
            Int32 partsPosCodeUCount = 0;
            // BLコードガイドマスタ
            Int32 bLCodeGuideCount = 0;
            // 車種名称マスタ
            Int32 modelNameUCount = 0;

            searchCountWork = new MstSearchCountWorkWork();

            // private field
            APSecInfoSetDB _secInfoSetDB = new APSecInfoSetDB();
            APSecInfoSetWork secInfoSetWork = new APSecInfoSetWork();
            APSubSectionDB _subSectionDB = new APSubSectionDB();
            APSubSectionWork subSectionWork = new APSubSectionWork();
            APEmployeeDB _employeeDB = new APEmployeeDB();
            APEmployeeWork employeeWork = new APEmployeeWork();
            APEmployeeDtlDB _employeeDtlDB = new APEmployeeDtlDB();
            APEmployeeDtlWork employeeDtlWork = new APEmployeeDtlWork();
            APWarehouseDB _warehouseDB = new APWarehouseDB();
            APWarehouseWork warehouseWork = new APWarehouseWork();
            APCustomerDB _customerWorkDB = new APCustomerDB();
            APCustomerWork customerWork = new APCustomerWork();
            APCustomerChangeDB _customerChangeDB = new APCustomerChangeDB();
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            APCustomerMemoDB _customerMemoDB = new APCustomerMemoDB();
            APCustomerMemoWork customerMemoWork = new APCustomerMemoWork();
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
            APCustomerChangeWork customerChangeWork = new APCustomerChangeWork();
            APCustSlipMngDB _custSlipMngDB = new APCustSlipMngDB();
            APCustSlipMngWork custSlipMngWork = new APCustSlipMngWork();
            APCustRateGroupDB _custRateGroupDB = new APCustRateGroupDB();
            APCustRateGroupWork custRateGroupWork = new APCustRateGroupWork();
            APCustSlipNoSetDB _custSlipNoSetDB = new APCustSlipNoSetDB();
            APCustSlipNoSetWork custSlipNoSetWork = new APCustSlipNoSetWork();
            APSupplierDB _supplierDB = new APSupplierDB();
            APSupplierWork supplierWork = new APSupplierWork();
            APMakerUDB _makerUWorkDB = new APMakerUDB();
            APMakerUWork makerUWork = new APMakerUWork();
            APBLGoodsCdUDB _bLGoodsCdUWorkDB = new APBLGoodsCdUDB();
            APBLGoodsCdUWork bLGoodsCdUWork = new APBLGoodsCdUWork();
            APGoodsUDB _goodsUDB = new APGoodsUDB();
            APGoodsUWork goodsUWork = new APGoodsUWork();
            APGoodsPriceUDB _goodsPriceUDB = new APGoodsPriceUDB();
            APGoodsPriceUWork goodsPriceUWork = new APGoodsPriceUWork();
            APGoodsMngDB _goodsMngDB = new APGoodsMngDB();
            APGoodsMngWork goodsMngWork = new APGoodsMngWork();
            APIsolIslandPrcDB _isolIslandPrcDB = new APIsolIslandPrcDB();
            APIsolIslandPrcWork isolIslandPrcWork = new APIsolIslandPrcWork();
            APStockDB _stockDB = new APStockDB();
            APStockWork stockWork = new APStockWork();
            APUserGdBdUDB _userGdBdUDB = new APUserGdBdUDB();
            APUserGdBdUWork userGdBdUWork = new APUserGdBdUWork();
            APRateProtyMngDB _rateProtyMngDB = new APRateProtyMngDB();
            APRateProtyMngWork rateProtyMngWork = new APRateProtyMngWork();
            APRateDB _rateDB = new APRateDB();
            APRateWork rateWork = new APRateWork();
            APGoodsSetDB _goodsSetDB = new APGoodsSetDB();
            APGoodsSetWork goodsSetWork = new APGoodsSetWork();
            APPartsSubstUDB _partsSubstUDB = new APPartsSubstUDB();
            APPartsSubstUWork partsSubstUWork = new APPartsSubstUWork();
            APEmpSalesTargetDB _empSalesTargetDB = new APEmpSalesTargetDB();
            APEmpSalesTargetWork empSalesTargetWork = new APEmpSalesTargetWork();
            APCustSalesTargetDB _custSalesTargetDB = new APCustSalesTargetDB();
            APCustSalesTargetWork custSalesTargetWork = new APCustSalesTargetWork();
            APGcdSalesTargetDB _gcdSalesTargetDB = new APGcdSalesTargetDB();
            APGcdSalesTargetWork gcdSalesTargetWork = new APGcdSalesTargetWork();
            APGoodsGroupUDB _goodsGroupUDB = new APGoodsGroupUDB();
            APGoodsGroupUWork goodsGroupUWork = new APGoodsGroupUWork();
            APBLGroupUDB _bLGroupUDB = new APBLGroupUDB();
            APBLGroupUWork bLGroupUWork = new APBLGroupUWork();
            APJoinPartsUDB _joinPartsUDB = new APJoinPartsUDB();
            APJoinPartsUWork joinPartsUWork = new APJoinPartsUWork();
            APTBOSearchUDB _tBOSearchUDB = new APTBOSearchUDB();
            APTBOSearchUWork tBOSearchUWork = new APTBOSearchUWork();
            APPartsPosCodeUDB _partsPosCodeUDB = new APPartsPosCodeUDB();
            APPartsPosCodeUWork partsPosCodeUWork = new APPartsPosCodeUWork();
            APBLCodeGuideDB _bLCodeGuideDB = new APBLCodeGuideDB();
            APBLCodeGuideWork bLCodeGuideWork = new APBLCodeGuideWork();
            APModelNameUDB _modelNameUDB = new APModelNameUDB();
            APModelNameUWork modelNameUWork = new APModelNameUWork();

            // 得意先マスタ（掛率グループ）
            ArrayList _custRateGroupList = new ArrayList();
            // 価格マスタ（ユーザー登録）
            ArrayList _goodsPriceUList = new ArrayList();
            // 掛率優先管理マスタ
            ArrayList _rateProtyMngList = new ArrayList();
            // 掛率マスタ
            ArrayList _rateList = new ArrayList();
            // 商品セットマスタ
            ArrayList _goodsSetList = new ArrayList();
            // 結合マスタ（ユーザー登録分）
            ArrayList _joinPartsUList = new ArrayList();
            // TBO検索合マスタ（ユーザー登録分）
            ArrayList _tboSearchUList = new ArrayList();
            // 部位コードマスタ（ユーザー登録）
            ArrayList _partsPosCodeUList = new ArrayList();
            // BLコードガイドマスタ
            ArrayList _blCodeGuideList = new ArrayList();
            // 商品マスタ
            ArrayList _goodsUList = new ArrayList();

            // 得意先マスタ（掛率グループ）
            ArrayList _custRateGroupListTmp = new ArrayList();
            // 価格マスタ（ユーザー登録）
            ArrayList _goodsPriceUListTmp = new ArrayList();
            // 掛率優先管理マスタ
            ArrayList _rateProtyMngListTmp = new ArrayList();
            // 掛率マスタ
            ArrayList _rateListTmp = new ArrayList();
            // 商品セットマスタ
            ArrayList _goodsSetListTmp = new ArrayList();
            // 結合マスタ（ユーザー登録分）
            ArrayList _joinPartsUListTmp = new ArrayList();
            // TBO検索合マスタ（ユーザー登録分）
            ArrayList _tboSearchUListTmp = new ArrayList();
            // 部位コードマスタ（ユーザー登録）
            ArrayList _partsPosCodeUListTmp = new ArrayList();
            // BLコードガイドマスタ
            ArrayList _blCodeGuideListTmp = new ArrayList();


            // 得意先マスタ（掛率グループ）
            ArrayList _custRateGroupListDelTmp = new ArrayList();
            // 価格マスタ（ユーザー登録）
            ArrayList _goodsPriceUListDelTmp = new ArrayList();
            // 掛率優先管理マスタ
            ArrayList _rateProtyMngListDelTmp = new ArrayList();
            // 掛率マスタ
            ArrayList _rateListDelTmp = new ArrayList();
            // 商品セットマスタ
            ArrayList _goodsSetListDelTmp = new ArrayList();
            // 結合マスタ（ユーザー登録分）
            ArrayList _joinPartsUListDelTmp = new ArrayList();
            // TBO検索合マスタ（ユーザー登録分）
            ArrayList _tboSearchUListDelTmp = new ArrayList();
            // 部位コードマスタ（ユーザー登録）
            ArrayList _partsPosCodeUListDelTmp = new ArrayList();
            // BLコードガイドマスタ
            ArrayList _blCodeGuideListDelTmp = new ArrayList();


            retMessage = string.Empty;
            isEmpty = true;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            string resNm = "";

            try
            {
                //●パラメータチェック
                if (retCSAList == null || retCSAList.Count <= 0)
                {
                    base.WriteErrorLog(null, "プログラムエラー。パラメータが未設定です");
                    return status;
                }

                // コネクション生成
                sqlConnection = this.CreateSqlConnectionData(true);

#if DEBUG
                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif

                resNm = GetResourceName(enterpriseCode);
                // MOD 2009/07/06 --->>>
                //ＡＰロック
                status = Lock(resNm, 1, sqlConnection, sqlTransaction);
                // MOD 2009/07/06 ---<<<

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                foreach (SecMngSndRcvWork secMngSndRcvWork in masterDivList)
                {
                    // 拠点設定マスタ
                    if (MST_SECINFOSET.Equals(secMngSndRcvWork.MasterName) && MST_ID_SECINFOSET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        secInfoSetInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 部門設定マスタ
                    if (MST_SUBSECTION.Equals(secMngSndRcvWork.MasterName) && MST_ID_SUBSECTION.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        subSectionInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 倉庫設定マスタ
                    if (MST_WAREHOUSE.Equals(secMngSndRcvWork.MasterName) && MST_ID_WAREHOUSE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        warehouseInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 従業員マスタ
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        employeeInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 従業員詳細マスタ
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEEDTL.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        employeeDtlInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 得意先マスタ
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOME.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        customerInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 得意先マスタ(変動情報)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMECHA.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        customerChangeInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                    // 得意先マスタ(メモ情報)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMEMEMO.Equals(secMngSndRcvWork.FileId)
                        &&  Convert.ToInt32(CusMemoSedDiv.None) != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        customerMemoInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                    // 得意先マスタ（伝票管理）
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMESLIPMNG.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        custSlipMngInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 得意先マスタ（掛率グループ）
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMEGROUP.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        custRateGroupInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 得意先マスタ(伝票番号)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMESLIPNO.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        custSlipNoSetInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 仕入先マスタ
                    if (MST_SUPPLIER.Equals(secMngSndRcvWork.MasterName) && MST_ID_SUPPLIER.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        supplierInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // メーカーマスタ（ユーザー登録分）
                    if (MST_MAKERU.Equals(secMngSndRcvWork.MasterName) && MST_ID_MAKERU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        makerUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // BL商品コードマスタ（ユーザー登録分）
                    if (MST_BLGOODSCDU.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLGOODSCDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        bLGoodsCdUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 商品マスタ（ユーザー登録分）
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 価格マスタ（ユーザー登録）
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUPRI.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsPriceInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 商品管理情報マスタ
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUMNG.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsMngInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 離島価格マスタ
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUISO.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        isolIslandPrcInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 在庫マスタ
                    if (MST_STOCK.Equals(secMngSndRcvWork.MasterName) && MST_ID_STOCK.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        stockInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ユーザーガイドマスタ(販売エリア区分）
                    if (MST_USERGDAREADIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdAreaDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ユーザーガイドマスタ（業務区分）
                    if (MST_USERGDBUSDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBusDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ユーザーガイドマスタ（業種）
                    if (MST_USERGDCATEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdCateUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ユーザーガイドマスタ（職種）
                    if (MST_USERGDBUSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBusUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ユーザーガイドマスタ（商品区分）
                    if (MST_USERGDGOODSDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdGoodsDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ユーザーガイドマスタ（得意先掛率グループ）
                    if (MST_USERGDCUSGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdCusGrouPUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ユーザーガイドマスタ（銀行）
                    if (MST_USERGDBANKU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBankUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ユーザーガイドマスタ（価格区分）
                    if (MST_USERGDPRIDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdPriDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ユーザーガイドマスタ（納品区分）
                    if (MST_USERGDDELIDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdDeliDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ユーザーガイドマスタ（商品大分類）
                    if (MST_USERGDGOODSBIGU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdGoodsBigUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ユーザーガイドマスタ（販売区分）
                    if (MST_USERGDBUYDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBuyDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ユーザーガイドマスタ（在庫管理区分１）
                    if (MST_USERGDSTOCKDIVOU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdStockDivOUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ユーザーガイドマスタ（在庫管理区分２）
                    if (MST_USERGDSTOCKDIVTU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdStockDivTUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // ユーザーガイドマスタ（返品理由）
                    if (MST_USERGDRETURNREAU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdReturnReaUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 掛率優先管理マスタ
                    if (MST_RATEPROTYMNG.Equals(secMngSndRcvWork.MasterName) && MST_ID_RATEPROTYMNG.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        rateProtyMngInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 掛率マスタ
                    if (MST_RATE.Equals(secMngSndRcvWork.MasterName) && MST_ID_RATE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        rateInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 商品セットマスタ
                    if (MST_GOODSSET.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSSET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsSetInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 部品代替マスタ（ユーザー登録分）
                    if (MST_PARTSSUBSTU.Equals(secMngSndRcvWork.MasterName) && MST_ID_PARTSSUBSTU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        partsSubstUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 従業員別売上目標設定マスタ
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        empSalesTargetInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 得意先別売上目標設定マスタ
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        custSalesTargetInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 商品別売上目標設定マスタ
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_GCDSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        gcdSalesTargetInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 商品中分類マスタ（ユーザー登録分）
                    if (MST_GOODSMGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSMGROUPU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsMGroupUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // BLグループマスタ（ユーザー登録分）
                    if (MST_BLGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLGROUPU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        bLGroupUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 結合マスタ（ユーザー登録分）
                    if (MST_JOINPARTSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_JOINPARTSU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        joinPartsUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // TBO検索マスタ（ユーザー登録）
                    if (MST_TBOSEARCHU.Equals(secMngSndRcvWork.MasterName) && MST_ID_TBOSEARCHU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        tBOSearchUCountInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 部位コードマスタ（ユーザー登録）
                    if (MST_PARTSPOSCODEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_PARTSPOSCODEU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        partsPosCodeUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // BLコードガイドマスタ
                    if (MST_BLCODEGUIDE.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLCODEGUIDE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        bLCodeGuideInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                    // 車種名称マスタ
                    if (MST_MODELNAMEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_MODELNAMEU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        modelNameUInt = secMngSndRcvWork.SecMngRecvDiv;
                    }
                }

                for (int i = 0; i < retCSAList.Count; i++)
                {
                    ArrayList retCSATemList = (ArrayList)retCSAList[i];
                    for (int j = 0; j < retCSATemList.Count; j++)
                    {
                        Type wktype = retCSATemList[j].GetType();

                        // DC拠点情報設定マスタ更新処理
                        if (wktype.Equals(typeof(APSecInfoSetWork)))
                        {
                            _secInfoSetDB = new APSecInfoSetDB();
                            secInfoSetWork = (APSecInfoSetWork)retCSATemList[j];
                            secInfoSetWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (secInfoSetInt == 1)
                            {
                                status = _secInfoSetDB.SearchSecInfoSetCount(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) 
                                {
                                    // 抽出したデータを登録する。
                                    _secInfoSetDB.Insert(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    secInfoSetCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (secInfoSetInt == 2)
                            {
                                // 存在するデータを削除する。
                                _secInfoSetDB.Delete(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _secInfoSetDB.Insert(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                secInfoSetCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (secInfoSetInt == 3)
                            {
                                status = _secInfoSetDB.SearchSecInfoSetCount(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _secInfoSetDB.Delete(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _secInfoSetDB.Insert(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    secInfoSetCount++;
                                }
                            }
                        }
                        // DC部門マスタ更新処理
                        else if (wktype.Equals(typeof(APSubSectionWork)))
                        {
                            _subSectionDB = new APSubSectionDB();
                            subSectionWork = (APSubSectionWork)retCSATemList[j];
                            subSectionWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (subSectionInt == 1)
                            {
                                status = _subSectionDB.SearchSubSectionCount(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _subSectionDB.Insert(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    subSectionCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (subSectionInt == 2)
                            {
                                // 存在するデータを削除する。
                                _subSectionDB.Delete(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _subSectionDB.Insert(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                subSectionCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (subSectionInt == 3)
                            {
                                status = _subSectionDB.SearchSubSectionCount(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _subSectionDB.Delete(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _subSectionDB.Insert(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    subSectionCount++;
                                }
                            }
                        }
                        // DC従業員マスタ更新処理
                        else if (wktype.Equals(typeof(APEmployeeWork)))
                        {
                            _employeeDB = new APEmployeeDB();
                            employeeWork = (APEmployeeWork)retCSATemList[j];
                            employeeWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (employeeInt == 1)
                            {
                                status = _employeeDB.SearchEmployeeCount(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _employeeDB.Insert(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    employeeCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (employeeInt == 2)
                            {
                                // 存在するデータを削除する。
                                _employeeDB.Delete(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _employeeDB.Insert(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                employeeCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (employeeInt == 3)
                            {
                                status = _employeeDB.SearchEmployeeCount(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _employeeDB.Delete(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _employeeDB.Insert(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    employeeCount++;
                                }
                            }
                        }
                        // DC従業員詳細マスタ更新処理
                        else if (wktype.Equals(typeof(APEmployeeDtlWork)))
                        {
                            _employeeDtlDB = new APEmployeeDtlDB();
                            employeeDtlWork = (APEmployeeDtlWork)retCSATemList[j];
                            employeeDtlWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (employeeDtlInt == 1)
                            {
                                status = _employeeDtlDB.SearchEmployeeDtlCount(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _employeeDtlDB.Insert(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    employeeDtlCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (employeeDtlInt == 2)
                            {
                                // 存在するデータを削除する。
                                _employeeDtlDB.Delete(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _employeeDtlDB.Insert(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                employeeDtlCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (employeeDtlInt == 3)
                            {
                                status = _employeeDtlDB.SearchEmployeeDtlCount(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _employeeDtlDB.Delete(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _employeeDtlDB.Insert(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    employeeDtlCount++;
                                }
                            }
                        }
                        // DC倉庫マスタ更新処理
                        else if (wktype.Equals(typeof(APWarehouseWork)))
                        {
                            _warehouseDB = new APWarehouseDB();
                            warehouseWork = (APWarehouseWork)retCSATemList[j];
                            warehouseWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (warehouseInt == 1)
                            {
                                status = _warehouseDB.SearchWarehouseCount(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _warehouseDB.Insert(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    warehouseCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (warehouseInt == 2)
                            {
                                // 存在するデータを削除する。
                                _warehouseDB.Delete(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _warehouseDB.Insert(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                warehouseCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (warehouseInt == 3)
                            {
                                status = _warehouseDB.SearchWarehouseCount(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _warehouseDB.Delete(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _warehouseDB.Insert(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    warehouseCount++;
                                }
                            }
                        }
                        // DC得意先マスタ更新処理
                        else if (wktype.Equals(typeof(APCustomerWork)))
                        {
                            _customerWorkDB = new APCustomerDB();
                            customerWork = (APCustomerWork)retCSATemList[j];
                            customerWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (customerInt == 1)
                            {
                                status = _customerWorkDB.SearchCustomerCount(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _customerWorkDB.Insert(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    customerCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (customerInt == 2)
                            {
                                // 存在するデータを削除する。
                                _customerWorkDB.Delete(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _customerWorkDB.Insert(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                customerCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (customerInt == 3)
                            {
                                status = _customerWorkDB.SearchCustomerCount(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _customerWorkDB.Delete(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _customerWorkDB.Insert(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    customerCount++;
                                }
                            }
                        }
                        // DC得意先マスタ(変動情報)更新処理
                        else if (wktype.Equals(typeof(APCustomerChangeWork)))
                        {
                            _customerChangeDB = new APCustomerChangeDB();
                            customerChangeWork = (APCustomerChangeWork)retCSATemList[j];
                            customerChangeWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (customerChangeInt == 1)
                            {
                                status = _customerChangeDB.SearchCustomerChangeCount(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _customerChangeDB.Insert(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    customerChangeCount++; 
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (customerChangeInt == 2)
                            {
                                // 存在するデータを削除する。
                                _customerChangeDB.Delete(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _customerChangeDB.Insert(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                customerChangeCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (customerChangeInt == 3)
                            {
                                status = _customerChangeDB.SearchCustomerChangeCount(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _customerChangeDB.Delete(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _customerChangeDB.Insert(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    customerChangeCount++;
                                }
                            }
                        }
                        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                        // DC得意先マスタ(メモ情報)更新処理
                        else if (wktype.Equals(typeof(APCustomerMemoWork)))
                        {
                            _customerMemoDB = new APCustomerMemoDB();
                            customerMemoWork = (APCustomerMemoWork)retCSATemList[j];
                            customerMemoWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (customerMemoInt ==  Convert.ToInt32(CusMemoSedDiv.Add))
                            {
                                status = _customerMemoDB.SearchCustomerMemoCount(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _customerMemoDB.Insert(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    customerMemoCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (customerMemoInt ==  Convert.ToInt32(CusMemoSedDiv.AddUpd))
                            {
                                // 存在するデータを削除する。
                                _customerMemoDB.Delete(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _customerMemoDB.Insert(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                customerMemoCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (customerMemoInt ==  Convert.ToInt32(CusMemoSedDiv.Upd))
                            {
                                status = _customerMemoDB.SearchCustomerMemoCount(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _customerMemoDB.Delete(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _customerMemoDB.Insert(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    customerMemoCount++;
                                }
                            }
                        }
                        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                        // DC得意先マスタ（伝票管理）更新処理
                        else if (wktype.Equals(typeof(APCustSlipMngWork)))
                        {
                            _custSlipMngDB = new APCustSlipMngDB();
                            custSlipMngWork = (APCustSlipMngWork)retCSATemList[j];
                            custSlipMngWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (custSlipMngInt == 1)
                            {
                                status = _custSlipMngDB.SearchCustSlipMngCount(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _custSlipMngDB.Insert(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    custSlipMngCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (custSlipMngInt == 2)
                            {
                                // 存在するデータを削除する。
                                _custSlipMngDB.Delete(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _custSlipMngDB.Insert(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                custSlipMngCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (custSlipMngInt == 3)
                            {
                                status = _custSlipMngDB.SearchCustSlipMngCount(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _custSlipMngDB.Delete(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _custSlipMngDB.Insert(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    custSlipMngCount++;
                                }
                            }
                        }
                        // DC得意先マスタ（掛率グループ）更新処理
                        else if (wktype.Equals(typeof(APCustRateGroupWork)))
                        {
                            custRateGroupWork = (APCustRateGroupWork)retCSATemList[j];
                            custRateGroupWork.EnterpriseCode = enterpriseCode;

                            _custRateGroupList.Add(custRateGroupWork);
                        }
                        // DC得意先マスタ(伝票番号)更新処理
                        else if (wktype.Equals(typeof(APCustSlipNoSetWork)))
                        {
                            _custSlipNoSetDB = new APCustSlipNoSetDB();
                            custSlipNoSetWork = (APCustSlipNoSetWork)retCSATemList[j];
                            custSlipNoSetWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (custSlipNoSetInt == 1)
                            {
                                status = _custSlipNoSetDB.SearchCustSlipNoSetCount(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _custSlipNoSetDB.Insert(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    custSlipNoSetCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (custSlipNoSetInt == 2)
                            {
                                // 存在するデータを削除する。
                                _custSlipNoSetDB.Delete(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _custSlipNoSetDB.Insert(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                custSlipNoSetCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (custSlipNoSetInt == 3)
                            {
                                status = _custSlipNoSetDB.SearchCustSlipNoSetCount(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _custSlipNoSetDB.Delete(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _custSlipNoSetDB.Insert(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    custSlipNoSetCount++;
                                }
                            }
                        }
                        // DC仕入先マスタ更新処理
                        else if (wktype.Equals(typeof(APSupplierWork)))
                        {
                            _supplierDB = new APSupplierDB();
                            supplierWork = (APSupplierWork)retCSATemList[j];
                            supplierWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (supplierInt == 1)
                            {
                                status = _supplierDB.SearchSupplierCount(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _supplierDB.Insert(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    supplierCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (supplierInt == 2)
                            {
                                // 存在するデータを削除する。
                                _supplierDB.Delete(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _supplierDB.Insert(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                supplierCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (supplierInt == 3)
                            {
                                status = _supplierDB.SearchSupplierCount(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _supplierDB.Delete(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _supplierDB.Insert(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    supplierCount++;
                                }
                            }
                        }
                        // DCメーカーマスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(APMakerUWork)))
                        {
                            _makerUWorkDB = new APMakerUDB();
                            makerUWork = (APMakerUWork)retCSATemList[j];
                            makerUWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (makerUInt == 1)
                            {
                                status = _makerUWorkDB.SearchMakerUCount(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _makerUWorkDB.Insert(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    makerUCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (makerUInt == 2)
                            {
                                // 存在するデータを削除する。
                                _makerUWorkDB.Delete(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _makerUWorkDB.Insert(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                makerUCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (makerUInt == 3)
                            {
                                status = _makerUWorkDB.SearchMakerUCount(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _makerUWorkDB.Delete(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _makerUWorkDB.Insert(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    makerUCount++;
                                }
                            }
                        }
                        // DCBL商品コードマスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(APBLGoodsCdUWork)))
                        {
                            _bLGoodsCdUWorkDB = new APBLGoodsCdUDB();
                            bLGoodsCdUWork = (APBLGoodsCdUWork)retCSATemList[j];
                            bLGoodsCdUWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (bLGoodsCdUInt == 1)
                            {
                                status = _bLGoodsCdUWorkDB.SearchBLGoodsCdUCount(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _bLGoodsCdUWorkDB.Insert(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    bLGoodsCdUCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (bLGoodsCdUInt == 2)
                            {
                                // 存在するデータを削除する。
                                _bLGoodsCdUWorkDB.Delete(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _bLGoodsCdUWorkDB.Insert(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                bLGoodsCdUCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (bLGoodsCdUInt == 3)
                            {
                                status = _bLGoodsCdUWorkDB.SearchBLGoodsCdUCount(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _bLGoodsCdUWorkDB.Delete(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _bLGoodsCdUWorkDB.Insert(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    bLGoodsCdUCount++;
                                }
                            }
                        }
                        // DC商品マスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(APGoodsUWork)))
                        {
                            goodsUWork = (APGoodsUWork)retCSATemList[j];
                            goodsUWork.EnterpriseCode = enterpriseCode;

                            _goodsUList.Add(goodsUWork);

                        }
                        // DC価格マスタ（ユーザー登録）更新処理
                        else if (wktype.Equals(typeof(APGoodsPriceUWork)))
                        {
                            goodsPriceUWork = (APGoodsPriceUWork)retCSATemList[j];
                            goodsPriceUWork.EnterpriseCode = enterpriseCode;

                            _goodsPriceUList.Add(goodsPriceUWork);
                        }
                        // DC商品管理情報マスタ更新処理
                        else if (wktype.Equals(typeof(APGoodsMngWork)))
                        {
                            _goodsMngDB = new APGoodsMngDB();
                            goodsMngWork = (APGoodsMngWork)retCSATemList[j];
                            goodsMngWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (goodsMngInt == 1)
                            {
                                status = _goodsMngDB.SearchGoodsMngCount(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _goodsMngDB.Insert(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    goodsMngCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (goodsMngInt == 2)
                            {
                                // 存在するデータを削除する。
                                _goodsMngDB.Delete(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _goodsMngDB.Insert(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                goodsMngCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (goodsMngInt == 3)
                            {
                                status = _goodsMngDB.SearchGoodsMngCount(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _goodsMngDB.Delete(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _goodsMngDB.Insert(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    goodsMngCount++;
                                }
                            }
                        }
                        // DC離島価格マスタ更新処理
                        else if (wktype.Equals(typeof(APIsolIslandPrcWork)))
                        {
                            _isolIslandPrcDB = new APIsolIslandPrcDB();
                            isolIslandPrcWork = (APIsolIslandPrcWork)retCSATemList[j];
                            isolIslandPrcWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (isolIslandPrcInt == 1)
                            {
                                status = _isolIslandPrcDB.SearchIsolIslandPrcCount(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _isolIslandPrcDB.Insert(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    isolIslandPrcCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (isolIslandPrcInt == 2)
                            {
                                // 存在するデータを削除する。
                                _isolIslandPrcDB.Delete(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _isolIslandPrcDB.Insert(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                isolIslandPrcCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (isolIslandPrcInt == 3)
                            {
                                status = _isolIslandPrcDB.SearchIsolIslandPrcCount(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _isolIslandPrcDB.Delete(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _isolIslandPrcDB.Insert(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    isolIslandPrcCount++;
                                }
                            }
                        }
                        // DC在庫マスタ更新処理
                        else if (wktype.Equals(typeof(APStockWork)))
                        {
                            _stockDB = new APStockDB();
                            stockWork = (APStockWork)retCSATemList[j];
                            stockWork.EnterpriseCode = enterpriseCode;

                            status = _stockDB.SearchStockCount(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            // 受信区分＝受信あり（追加のみ）
                            if (stockInt == 1)
                            {
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    //_stockDB.Insert(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);//DEL 2011/09/06 #24252
                                    _stockDB.Insert(masterDtlDivList, stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);//ADD 2011/09/06 #24252
                                    stockCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (stockInt == 2)
                            {
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    //_stockDB.Insert(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);//DEL 2011/09/06 #24252
                                    _stockDB.Insert(masterDtlDivList, stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);//ADD 2011/09/06 #24252
                                    stockCount++;
                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 抽出したデータを登録する。
                                    _stockDB.Update(masterDtlDivList, stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    stockCount++;
                                }
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (stockInt == 3)
                            {
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 抽出したデータを登録する。
                                    _stockDB.Update(masterDtlDivList, stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    stockCount++;
                                }
                            }
                        }
                        // DCユーザーガイドマスタ更新処理
                        else if (wktype.Equals(typeof(APUserGdBdUWork)))
                        {
                            _userGdBdUDB = new APUserGdBdUDB();
                            userGdBdUWork = (APUserGdBdUWork)retCSATemList[j];
                            userGdBdUWork.EnterpriseCode = enterpriseCode;

                            // ユーザーガイドマスタ(販売エリア区分）
                            if (userGdBdUWork.UserGuideDivCd == 21)
                            {
                                // 受信区分＝受信あり（追加のみ）
                                if (userGdAreaDivUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdAreaDivUCount++; 
                                    }
                                }
                                // 受信区分＝受信あり（追加・更新）
                                else if (userGdAreaDivUInt == 2)
                                {
                                    // 存在するデータを削除する。
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdAreaDivUCount++;
                                }
                                // 受信区分＝受信あり（更新のみ）
                                else if (userGdAreaDivUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // 存在するデータを削除する。
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdAreaDivUCount++;
                                    }
                                }
                            }
                            // ユーザーガイドマスタ（業務区分）
                            else if (userGdBdUWork.UserGuideDivCd == 31)
                            {
                                // 受信区分＝受信あり（追加のみ）
                                if (userGdBusDivUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdBusDivUCount++;
                                    }
                                }
                                // 受信区分＝受信あり（追加・更新）
                                else if (userGdBusDivUInt == 2)
                                {
                                    // 存在するデータを削除する。
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdBusDivUCount++;
                                }
                                // 受信区分＝受信あり（更新のみ）
                                else if (userGdBusDivUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // 存在するデータを削除する。
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdBusDivUCount++;
                                    }
                                }
                            }
                            // ユーザーガイドマスタ（業種）
                            else if (userGdBdUWork.UserGuideDivCd == 33)
                            {
                                // 受信区分＝受信あり（追加のみ）
                                if (userGdCateUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdCateUCount++;
                                    }
                                }
                                // 受信区分＝受信あり（追加・更新）
                                else if (userGdCateUInt == 2)
                                {
                                    // 存在するデータを削除する。
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdCateUCount++;
                                }
                                // 受信区分＝受信あり（更新のみ）
                                else if (userGdCateUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // 存在するデータを削除する。
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdCateUCount++;
                                    }
                                }
                            }
                            // ユーザーガイドマスタ（職種）
                            else if (userGdBdUWork.UserGuideDivCd == 34)
                            {
                                // 受信区分＝受信あり（追加のみ）
                                if (userGdBusUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdBusUCount++; 
                                    }
                                }
                                // 受信区分＝受信あり（追加・更新）
                                else if (userGdBusUInt == 2)
                                {
                                    // 存在するデータを削除する。
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdBusUCount++;
                                }
                                // 受信区分＝受信あり（更新のみ）
                                else if (userGdBusUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // 存在するデータを削除する。
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdBusUCount++;
                                    }
                                }
                            }
                            // ユーザーガイドマスタ（商品区分）
                            else if (userGdBdUWork.UserGuideDivCd == 41)
                            {
                                // 受信区分＝受信あり（追加のみ）
                                if (userGdGoodsDivUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdGoodsDivUCount++;
                                    }
                                }
                                // 受信区分＝受信あり（追加・更新）
                                else if (userGdGoodsDivUInt == 2)
                                {
                                    // 存在するデータを削除する。
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdGoodsDivUCount++;
                                }
                                // 受信区分＝受信あり（更新のみ）
                                else if (userGdGoodsDivUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // 存在するデータを削除する。
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdGoodsDivUCount++;
                                    }
                                }
                            }
                            // ユーザーガイドマスタ（得意先掛率グループ）
                            else if (userGdBdUWork.UserGuideDivCd == 43)
                            {
                                // 受信区分＝受信あり（追加のみ）
                                if (userGdCusGrouPUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdCusGrouPUCount++;
                                    }
                                }
                                // 受信区分＝受信あり（追加・更新）
                                else if (userGdCusGrouPUInt == 2)
                                {
                                    // 存在するデータを削除する。
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdCusGrouPUCount++;
                                }
                                // 受信区分＝受信あり（更新のみ）
                                else if (userGdCusGrouPUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // 存在するデータを削除する。
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdCusGrouPUCount++;
                                    }
                                }
                            }
                            // ユーザーガイドマスタ（銀行）
                            else if (userGdBdUWork.UserGuideDivCd == 46)
                            {
                                // 受信区分＝受信あり（追加のみ）
                                if (userGdBankUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdBankUCount++; 
                                    }
                                }
                                // 受信区分＝受信あり（追加・更新）
                                else if (userGdBankUInt == 2)
                                {
                                    // 存在するデータを削除する。
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdBankUCount++;
                                }
                                // 受信区分＝受信あり（更新のみ）
                                else if (userGdBankUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // 存在するデータを削除する。
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdBankUCount++;
                                    }
                                }
                            }
                            // ユーザーガイドマスタ（価格区分）
                            else if (userGdBdUWork.UserGuideDivCd == 47)
                            {
                                // 受信区分＝受信あり（追加のみ）
                                if (userGdPriDivUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdPriDivUCount++;
                                    }
                                }
                                // 受信区分＝受信あり（追加・更新）
                                else if (userGdPriDivUInt == 2)
                                {
                                    // 存在するデータを削除する。
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdPriDivUCount++;
                                }
                                // 受信区分＝受信あり（更新のみ）
                                else if (userGdPriDivUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // 存在するデータを削除する。
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdPriDivUCount++;
                                    }
                                }
                            }
                            // ユーザーガイドマスタ（納品区分）
                            else if (userGdBdUWork.UserGuideDivCd == 48)
                            {
                                // 受信区分＝受信あり（追加のみ）
                                if (userGdDeliDivUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdDeliDivUCount++;
                                    }
                                }
                                // 受信区分＝受信あり（追加・更新）
                                else if (userGdDeliDivUInt == 2)
                                {
                                    // 存在するデータを削除する。
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdDeliDivUCount++;
                                }
                                // 受信区分＝受信あり（更新のみ）
                                else if (userGdDeliDivUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // 存在するデータを削除する。
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdDeliDivUCount++;
                                    }
                                }
                            }
                            // ユーザーガイドマスタ（商品大分類）
                            else if (userGdBdUWork.UserGuideDivCd == 70)
                            {
                                // 受信区分＝受信あり（追加のみ）
                                if (userGdGoodsBigUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdGoodsBigUCount++;
                                    }
                                }
                                // 受信区分＝受信あり（追加・更新）
                                else if (userGdGoodsBigUInt == 2)
                                {
                                    // 存在するデータを削除する。
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdGoodsBigUCount++;
                                }
                                // 受信区分＝受信あり（更新のみ）
                                else if (userGdGoodsBigUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // 存在するデータを削除する。
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdGoodsBigUCount++;
                                    }
                                }
                            }
                            // ユーザーガイドマスタ（販売区分）
                            else if (userGdBdUWork.UserGuideDivCd == 71)
                            {
                                // 受信区分＝受信あり（追加のみ）
                                if (userGdBuyDivUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdBuyDivUCount++;
                                    }
                                }
                                // 受信区分＝受信あり（追加・更新）
                                else if (userGdBuyDivUInt == 2)
                                {
                                    // 存在するデータを削除する。
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdBuyDivUCount++;
                                }
                                // 受信区分＝受信あり（更新のみ）
                                else if (userGdBuyDivUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // 存在するデータを削除する。
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdBuyDivUCount++;
                                    }
                                }
                            }
                            // ユーザーガイドマスタ（在庫管理区分１）
                            else if (userGdBdUWork.UserGuideDivCd == 72)
                            {
                                // 受信区分＝受信あり（追加のみ）
                                if (userGdStockDivOUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdStockDivOUCount++;
                                    }
                                }
                                // 受信区分＝受信あり（追加・更新）
                                else if (userGdStockDivOUInt == 2)
                                {
                                    // 存在するデータを削除する。
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdStockDivOUCount++;
                                }
                                // 受信区分＝受信あり（更新のみ）
                                else if (userGdStockDivOUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // 存在するデータを削除する。
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdStockDivOUCount++;
                                    }
                                }
                            }
                            // ユーザーガイドマスタ（在庫管理区分２）
                            else if (userGdBdUWork.UserGuideDivCd == 73)
                            {
                                // 受信区分＝受信あり（追加のみ）
                                if (userGdStockDivTUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdStockDivTUCount++;
                                    }
                                }
                                // 受信区分＝受信あり（追加・更新）
                                else if (userGdStockDivTUInt == 2)
                                {
                                    // 存在するデータを削除する。
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdStockDivTUCount++;
                                }
                                // 受信区分＝受信あり（更新のみ）
                                else if (userGdStockDivTUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // 存在するデータを削除する。
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdStockDivTUCount++;
                                    }
                                }
                            }
                            // ユーザーガイドマスタ（返品理由）
                            else if (userGdBdUWork.UserGuideDivCd == 91)
                            {
                                // 受信区分＝受信あり（追加のみ）
                                if (userGdReturnReaUInt == 1)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdReturnReaUCount++;
                                    }
                                }
                                // 受信区分＝受信あり（追加・更新）
                                else if (userGdReturnReaUInt == 2)
                                {
                                    // 存在するデータを削除する。
                                    _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    userGdReturnReaUCount++;
                                }
                                // 受信区分＝受信あり（更新のみ）
                                else if (userGdReturnReaUInt == 3)
                                {
                                    status = _userGdBdUDB.SearchUserGdBdUCount(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // 存在するデータを削除する。
                                        _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        // 抽出したデータを登録する。
                                        _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                        userGdReturnReaUCount++;
                                    }
                                }
                            }
                        }
                        // DC掛率優先管理マスタ更新処理
                        else if (wktype.Equals(typeof(APRateProtyMngWork)))
                        {
                            rateProtyMngWork = (APRateProtyMngWork)retCSATemList[j];
                            rateProtyMngWork.EnterpriseCode = enterpriseCode;

                            _rateProtyMngList.Add(rateProtyMngWork);
                        }
                        // DC掛率マスタ更新処理
                        else if (wktype.Equals(typeof(APRateWork)))
                        {
                            rateWork = (APRateWork)retCSATemList[j];
                            rateWork.EnterpriseCode = enterpriseCode;

                            _rateList.Add(rateWork);
                        }
                        // DC商品セットマスタ更新処理
                        else if (wktype.Equals(typeof(APGoodsSetWork)))
                        {
                            goodsSetWork = (APGoodsSetWork)retCSATemList[j];
                            goodsSetWork.EnterpriseCode = enterpriseCode;

                            _goodsSetList.Add(goodsSetWork);
                        }
                        // DC部品代替マスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(APPartsSubstUWork)))
                        {
                            _partsSubstUDB = new APPartsSubstUDB();
                            partsSubstUWork = (APPartsSubstUWork)retCSATemList[j];
                            partsSubstUWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (partsSubstUInt == 1)
                            {
                                status = _partsSubstUDB.SearchPartsSubstUCount(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _partsSubstUDB.Insert(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    partsSubstUCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (partsSubstUInt == 2)
                            {
                                // 存在するデータを削除する。
                                _partsSubstUDB.Delete(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _partsSubstUDB.Insert(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                partsSubstUCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (partsSubstUInt == 3)
                            {
                                status = _partsSubstUDB.SearchPartsSubstUCount(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _partsSubstUDB.Delete(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _partsSubstUDB.Insert(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    partsSubstUCount++;
                                }
                            }
                        }
                        // DC従業員別売上目標設定マスタ更新処理
                        else if (wktype.Equals(typeof(APEmpSalesTargetWork)))
                        {
                            _empSalesTargetDB = new APEmpSalesTargetDB();
                            empSalesTargetWork = (APEmpSalesTargetWork)retCSATemList[j];
                            empSalesTargetWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (empSalesTargetInt == 1)
                            {
                                status = _empSalesTargetDB.SearchEmpSalesTargetCount(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _empSalesTargetDB.Insert(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    empSalesTargetCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (empSalesTargetInt == 2)
                            {
                                // 存在するデータを削除する。
                                _empSalesTargetDB.Delete(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _empSalesTargetDB.Insert(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                empSalesTargetCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (empSalesTargetInt == 3)
                            {
                                status = _empSalesTargetDB.SearchEmpSalesTargetCount(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _empSalesTargetDB.Delete(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _empSalesTargetDB.Insert(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    empSalesTargetCount++;
                                }
                            }
                        }
                        // DC得意先別売上目標設定マスタ更新処理
                        else if (wktype.Equals(typeof(APCustSalesTargetWork)))
                        {
                            _custSalesTargetDB = new APCustSalesTargetDB();
                            custSalesTargetWork = (APCustSalesTargetWork)retCSATemList[j];
                            custSalesTargetWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (custSalesTargetInt == 1)
                            {
                                status = _custSalesTargetDB.SearchCustSalesTargetCount(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _custSalesTargetDB.Insert(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    custSalesTargetCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (custSalesTargetInt == 2)
                            {
                                // 存在するデータを削除する。
                                _custSalesTargetDB.Delete(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _custSalesTargetDB.Insert(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                custSalesTargetCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (custSalesTargetInt == 3)
                            {
                                status = _custSalesTargetDB.SearchCustSalesTargetCount(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _custSalesTargetDB.Delete(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _custSalesTargetDB.Insert(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    custSalesTargetCount++;
                                }
                            }
                        }
                        // DC商品別売上目標設定マスタ更新処理
                        else if (wktype.Equals(typeof(APGcdSalesTargetWork)))
                        {
                            _gcdSalesTargetDB = new APGcdSalesTargetDB();
                            gcdSalesTargetWork = (APGcdSalesTargetWork)retCSATemList[j];
                            gcdSalesTargetWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (gcdSalesTargetInt == 1)
                            {
                                status = _gcdSalesTargetDB.SearchGcdSalesTargetCount(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _gcdSalesTargetDB.Insert(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    gcdSalesTargetCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (gcdSalesTargetInt == 2)
                            {
                                // 存在するデータを削除する。
                                _gcdSalesTargetDB.Delete(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _gcdSalesTargetDB.Insert(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                gcdSalesTargetCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (gcdSalesTargetInt == 3)
                            {
                                status = _gcdSalesTargetDB.SearchGcdSalesTargetCount(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _gcdSalesTargetDB.Delete(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _gcdSalesTargetDB.Insert(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    gcdSalesTargetCount++;
                                }
                            }
                        }
                        // DC商品中分類マスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(APGoodsGroupUWork)))
                        {
                            _goodsGroupUDB = new APGoodsGroupUDB();
                            goodsGroupUWork = (APGoodsGroupUWork)retCSATemList[j];
                            goodsGroupUWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (goodsMGroupUInt == 1)
                            {
                                status = _goodsGroupUDB.SearchGoodsGroupUCount(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _goodsGroupUDB.Insert(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    goodsMGroupUCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (goodsMGroupUInt == 2)
                            {
                                // 存在するデータを削除する。
                                _goodsGroupUDB.Delete(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _goodsGroupUDB.Insert(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                goodsMGroupUCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (goodsMGroupUInt == 3)
                            {
                                status = _goodsGroupUDB.SearchGoodsGroupUCount(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _goodsGroupUDB.Delete(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _goodsGroupUDB.Insert(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    goodsMGroupUCount++;
                                }
                            }
                        }
                        // DCBLグループマスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(APBLGroupUWork)))
                        {
                            _bLGroupUDB = new APBLGroupUDB();
                            bLGroupUWork = (APBLGroupUWork)retCSATemList[j];
                            bLGroupUWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (bLGroupUInt == 1)
                            {
                                status = _bLGroupUDB.SearchBLGroupUCount(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _bLGroupUDB.Insert(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    bLGroupUCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (bLGroupUInt == 2)
                            {
                                // 存在するデータを削除する。
                                _bLGroupUDB.Delete(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _bLGroupUDB.Insert(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                bLGroupUCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (bLGroupUInt == 3)
                            {
                                status = _bLGroupUDB.SearchBLGroupUCount(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _bLGroupUDB.Delete(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _bLGroupUDB.Insert(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    bLGroupUCount++;
                                }
                            }
                        }
                        // DC結合マスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(APJoinPartsUWork)))
                        {
                            joinPartsUWork = (APJoinPartsUWork)retCSATemList[j];
                            joinPartsUWork.EnterpriseCode = enterpriseCode;

                            _joinPartsUList.Add(joinPartsUWork);
                        }
                        // DCTBO検索マスタ（ユーザー登録）更新処理
                        else if (wktype.Equals(typeof(APTBOSearchUWork)))
                        {
                            tBOSearchUWork = (APTBOSearchUWork)retCSATemList[j];
                            tBOSearchUWork.EnterpriseCode = enterpriseCode;

                            _tboSearchUList.Add(tBOSearchUWork);
                        }
                        // DC部位コードマスタ（ユーザー登録）更新処理
                        else if (wktype.Equals(typeof(APPartsPosCodeUWork)))
                        {
                            partsPosCodeUWork = (APPartsPosCodeUWork)retCSATemList[j];
                            partsPosCodeUWork.EnterpriseCode = enterpriseCode;

                            _partsPosCodeUList.Add(partsPosCodeUWork);
                        }
                        // DCBLコードガイドマスタ更新処理
                        else if (wktype.Equals(typeof(APBLCodeGuideWork)))
                        {
                            bLCodeGuideWork = (APBLCodeGuideWork)retCSATemList[j];
                            bLCodeGuideWork.EnterpriseCode = enterpriseCode;

                            _blCodeGuideList.Add(bLCodeGuideWork);
                        }
                        // DC車種名称マスタ更新処理
                        else if (wktype.Equals(typeof(APModelNameUWork)))
                        {
                            _modelNameUDB = new APModelNameUDB();
                            modelNameUWork = (APModelNameUWork)retCSATemList[j];
                            modelNameUWork.EnterpriseCode = enterpriseCode;
                            // 受信区分＝受信あり（追加のみ）
                            if (modelNameUInt == 1)
                            {
                                status = _modelNameUDB.SearchModelNameUCount(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 抽出したデータを登録する。
                                    _modelNameUDB.Insert(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    modelNameUCount++;
                                }
                            }
                            // 受信区分＝受信あり（追加・更新）
                            else if (modelNameUInt == 2)
                            {
                                // 存在するデータを削除する。
                                _modelNameUDB.Delete(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                // 抽出したデータを登録する。
                                _modelNameUDB.Insert(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                modelNameUCount++;
                            }
                            // 受信区分＝受信あり（更新のみ）
                            else if (modelNameUInt == 3)
                            {
                                status = _modelNameUDB.SearchModelNameUCount(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在するデータを削除する。
                                    _modelNameUDB.Delete(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    // 抽出したデータを登録する。
                                    _modelNameUDB.Insert(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                    modelNameUCount++;
                                }
                            }
                        }
                    }
                }

                // ADD 2009/06/09 --->>>
                // 得意先マスタ（掛率グループ）
                if (_custRateGroupList != null && _custRateGroupList.Count > 0)
                {
                    _custRateGroupDB = new APCustRateGroupDB();

                    // 受信区分＝受信あり（追加のみ）
                    if (custRateGroupInt == 1)
                    {
                        foreach (APCustRateGroupWork work in _custRateGroupList)
                        {
                            status = _custRateGroupDB.SearchCustRateGroupCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _custRateGroupListTmp.Add(work);
                            }
                        }
                        foreach (APCustRateGroupWork apCustRateGroupWork in _custRateGroupListTmp)
                        {
                            // 抽出したデータを登録する。
                            _custRateGroupDB.Insert(apCustRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            custRateGroupCount++;
                        }
                    }
                    // 受信区分＝受信あり（追加・更新）
                    else if (custRateGroupInt == 2)
                    {
                        // データが本社に削除する。
                        foreach (APCustRateGroupWork work in _custRateGroupList)
                        {
                            // 本社に削除する。
                            _custRateGroupDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // データが本社に削除する。
                        foreach (APCustRateGroupWork apCustRateGroupWork in _custRateGroupList)
                        {
                            // 抽出したデータを登録する。
                            _custRateGroupDB.Insert(apCustRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            custRateGroupCount++;
                        }

                    }
                    // 受信区分＝受信あり（更新のみ）
                    else if (custRateGroupInt == 3)
                    {
                        // データが本社に存在場合、抽出レコードに保存する、又は、本社に削除する。
                        foreach (APCustRateGroupWork work in _custRateGroupList)
                        {
                            status = _custRateGroupDB.SearchCustRateGroupCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 存在場合には本社から
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _custRateGroupListTmp.Add(work);
                            }
                        }

                        foreach (APCustRateGroupWork delWork in _custRateGroupListTmp)
                        {

                            // 存在するデータは本社に削除する。
                            _custRateGroupDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APCustRateGroupWork apCustRateGroupWork in _custRateGroupListTmp)
                        {
                            // 抽出したデータを登録する。
                            _custRateGroupDB.Insert(apCustRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            custRateGroupCount++;
                        }
                    }
                }
                // 価格マスタ（ユーザー登録）
                if (_goodsPriceUList != null && _goodsPriceUList.Count > 0)
                {
                    _goodsPriceUDB = new APGoodsPriceUDB();

                    // 受信区分＝受信あり（追加のみ）
                    if (goodsPriceInt == 1)
                    {
                        foreach (APGoodsPriceUWork work in _goodsPriceUList)
                        {
                            status = _goodsPriceUDB.SearchGoodsUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _goodsPriceUListTmp.Add(work);
                            }
                        }

                        foreach (APGoodsPriceUWork apGoodsPriceUWork in _goodsPriceUListTmp)
                        {
                            // 抽出したデータを登録する。
                            _goodsPriceUDB.Insert(apGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            goodsPriceCount++;
                        }
                    }
                    // 受信区分＝受信あり（追加・更新）
                    else if (goodsPriceInt == 2)
                    {
                        // データが本社に削除する。
                        foreach (APGoodsPriceUWork work in _goodsPriceUList)
                        {
                            // 本社に削除する。
                            _goodsPriceUDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // データが本社に削除する。
                        foreach (APGoodsPriceUWork apGoodsPriceUWork in _goodsPriceUList)
                        {
                            // 抽出したデータを登録する。
                            _goodsPriceUDB.Insert(apGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            goodsPriceCount++;
                        }

                    }
                    // 受信区分＝受信あり（更新のみ）
                    else if (goodsPriceInt == 3)
                    {
                        // データが本社に存在場合、抽出レコードに保存する、又は、本社に削除する。
                        foreach (APGoodsPriceUWork work in _goodsPriceUList)
                        {
                            status = _goodsPriceUDB.SearchGoodsUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 存在場合には本社から削除
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _goodsPriceUListTmp.Add(work);
                            }
                        }

                        foreach (APGoodsPriceUWork delWork in _goodsPriceUList)
                        {

                            // 存在するデータは本社に削除する。
                            _goodsPriceUDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APGoodsPriceUWork apGoodsPriceUWork in _goodsPriceUListTmp)
                        {
                            // 抽出したデータを登録する。
                            _goodsPriceUDB.Insert(apGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            goodsPriceCount++;
                        }
                    }
                }
                // 掛率優先管理マスタ
                if (_rateProtyMngList != null && _rateProtyMngList.Count > 0) 
                {
                    _rateProtyMngDB = new APRateProtyMngDB();

                    // 受信区分＝受信あり（追加のみ）
                    if (rateProtyMngInt == 1)
                    {
                        foreach (APRateProtyMngWork work in _rateProtyMngList)
                        {
                            status = _rateProtyMngDB.SearchRateProtyMngCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _rateProtyMngListTmp.Add(work);
                            }
                        }

                        foreach (APRateProtyMngWork apRateProtyMngWork in _rateProtyMngListTmp)
                        {
                            // 抽出したデータを登録する。
                            _rateProtyMngDB.Insert(apRateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            rateProtyMngCount++;
                        }
                    }
                    // 受信区分＝受信あり（追加・更新）
                    else if (rateProtyMngInt == 2)
                    {
                        // データが本社に削除する。
                        foreach (APRateProtyMngWork work in _rateProtyMngList)
                        {
                            // 本社に削除する。
                            _rateProtyMngDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // データが本社に削除する。
                        foreach (APRateProtyMngWork apRateProtyMngWork in _rateProtyMngList)
                        {
                            // 抽出したデータを登録する。
                            _rateProtyMngDB.Insert(apRateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            rateProtyMngCount++;
                        }

                    }
                    // 受信区分＝受信あり（更新のみ）
                    else if (rateProtyMngInt == 3)
                    {
                        // データが本社に存在場合、抽出レコードに保存する、又は、本社に削除する。
                        foreach (APRateProtyMngWork work in _rateProtyMngList)
                        {
                            status = _rateProtyMngDB.SearchRateProtyMngCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 存在場合には本社から削除
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _rateProtyMngListTmp.Add(work);
                            }
                        }

                        foreach (APRateProtyMngWork delWork in _rateProtyMngList)
                        {
                            // 存在するデータは本社に削除する。
                            _rateProtyMngDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APRateProtyMngWork apRateProtyMngWork in _rateProtyMngListTmp)
                        {
                            // 抽出したデータを登録する。
                            _rateProtyMngDB.Insert(apRateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            rateProtyMngCount++;
                        }
                    }
                }
                // 掛率マスタ
                if (_rateList != null && _rateList.Count > 0)
                {
                    _rateDB = new APRateDB();

                    // 受信区分＝受信あり（追加のみ）
                    if (rateInt == 1)
                    {
                        foreach (APRateWork work in _rateList)
                        {
                            status = _rateDB.SearchRateCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _rateListTmp.Add(work);
                            }
                        }

                        foreach (APRateWork apRateWork in _rateListTmp)
                        {
                            // 抽出したデータを登録する。
                            _rateDB.Insert(apRateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            rateCount++;
                        }
                    }
                    // 受信区分＝受信あり（追加・更新）
                    else if (rateInt == 2)
                    {
                        // データが本社に削除する。
                        foreach (APRateWork work in _rateList)
                        {
                            // 本社に削除する。
                            _rateDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // データが本社に削除する。
                        foreach (APRateWork apRateWork in _rateList)
                        {
                            // 抽出したデータを登録する。
                            _rateDB.Insert(apRateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            rateCount++;
                        }

                    }
                    // 受信区分＝受信あり（更新のみ）
                    else if (rateInt == 3)
                    {
                        // データが本社に存在場合、抽出レコードに保存する、又は、本社に削除する。
                        foreach (APRateWork work in _rateList)
                        {
                            status = _rateDB.SearchRateCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 存在場合には本社から削除
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _rateListTmp.Add(work);
                            }
                        }

                        foreach (APRateWork delWork in _rateList)
                        {

                            // 存在するデータは本社に削除する。
                            _rateDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APRateWork apRateWork in _rateListTmp)
                        {
                            // 抽出したデータを登録する。
                            _rateDB.Insert(apRateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            rateCount++;
                        }
                    }
                }
                // 商品セットマスタ
                if (_goodsSetList != null && _goodsSetList.Count > 0)
                {
                    _goodsSetDB = new APGoodsSetDB();

                    // 受信区分＝受信あり（追加のみ）
                    if (goodsSetInt == 1)
                    {
                        foreach (APGoodsSetWork work in _goodsSetList)
                        {
                            status = _goodsSetDB.SearchGoodsSetCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _goodsSetListTmp.Add(work);
                            }
                        }

                        foreach (APGoodsSetWork apGoodsSetWork in _goodsSetListTmp)
                        {
                            // 抽出したデータを登録する。
                            _goodsSetDB.Insert(apGoodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            goodsSetCount++;
                        }
                    }
                    // 受信区分＝受信あり（追加・更新）
                    else if (goodsSetInt == 2)
                    {
                        // データが本社に削除する。
                        foreach (APGoodsSetWork work in _goodsSetList)
                        {
                            // 本社に削除する。
                            _goodsSetDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // データが本社に削除する。
                        foreach (APGoodsSetWork apGoodsSetWork in _goodsSetList)
                        {
                            // 抽出したデータを登録する。
                            _goodsSetDB.Insert(apGoodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            goodsSetCount++;
                        }

                    }
                    // 受信区分＝受信あり（更新のみ）
                    else if (goodsSetInt == 3)
                    {
                        // データが本社に存在場合、抽出レコードに保存する、又は、本社に削除する。
                        foreach (APGoodsSetWork work in _goodsSetList)
                        {
                            status = _goodsSetDB.SearchGoodsSetCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 存在場合には本社から削除
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _goodsSetListTmp.Add(work);
                            }
                        }

                        foreach (APGoodsSetWork delWork in _goodsSetList)
                        {

                            // 存在するデータは本社に削除する。
                            _goodsSetDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APGoodsSetWork apGoodsSetWork in _goodsSetListTmp)
                        {
                            // 抽出したデータを登録する。
                            _goodsSetDB.Insert(apGoodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            goodsSetCount++;
                        }
                    }
                }
                // 結合マスタ（ユーザー登録分）
                if (_joinPartsUList != null && _joinPartsUList.Count > 0)
                {
                    _joinPartsUDB = new APJoinPartsUDB();

                    // 受信区分＝受信あり（追加のみ）
                    if (joinPartsUInt == 1)
                    {
                        foreach (APJoinPartsUWork work in _joinPartsUList)
                        {
                            status = _joinPartsUDB.SearchJoinPartsUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _joinPartsUListTmp.Add(work);
                            }
                        }

                        foreach (APJoinPartsUWork apJoinPartsUWork in _joinPartsUListTmp)
                        {
                            // 抽出したデータを登録する。
                            _joinPartsUDB.Insert(apJoinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            joinPartsUCount++;
                        }
                    }
                    // 受信区分＝受信あり（追加・更新）
                    else if (joinPartsUInt == 2)
                    {
                        // データが本社に削除する。
                        foreach (APJoinPartsUWork work in _joinPartsUList)
                        {
                            // 本社に削除する。
                            _joinPartsUDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // データが本社に削除する。
                        foreach (APJoinPartsUWork apJoinPartsUWork in _joinPartsUList)
                        {
                            // 抽出したデータを登録する。
                            _joinPartsUDB.Insert(apJoinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            joinPartsUCount++;
                        }

                    }
                    // 受信区分＝受信あり（更新のみ）
                    else if (joinPartsUInt == 3)
                    {
                        // データが本社に存在場合、抽出レコードに保存する、又は、本社に削除する。
                        foreach (APJoinPartsUWork work in _joinPartsUList)
                        {
                            status = _joinPartsUDB.SearchJoinPartsUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 存在場合には本社から削除
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _joinPartsUListTmp.Add(work);

                            }
                        }

                        foreach (APJoinPartsUWork delWork in _joinPartsUList)
                        {

                            // 存在するデータは本社に削除する。
                            _joinPartsUDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APJoinPartsUWork apJoinPartsUWork in _joinPartsUListTmp)
                        {
                            // 抽出したデータを登録する。
                            _joinPartsUDB.Insert(apJoinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            joinPartsUCount++;
                        }
                    }
                }
                // TBO検索合マスタ（ユーザー登録分）
                if (_tboSearchUList != null && _tboSearchUList.Count > 0)
                {
                    _tBOSearchUDB = new APTBOSearchUDB();

                    // 受信区分＝受信あり（追加のみ）
                    if (tBOSearchUCountInt == 1)
                    {
                        foreach (APTBOSearchUWork work in _tboSearchUList)
                        {
                            status = _tBOSearchUDB.SearchTBOSearchUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _tboSearchUListTmp.Add(work);
                            }
                        }

                        foreach (APTBOSearchUWork apTBOSearchUWork in _tboSearchUListTmp)
                        {
                            // 抽出したデータを登録する。
                            _tBOSearchUDB.Insert(apTBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            tBOSearchUCount++;
                        }
                    }
                    // 受信区分＝受信あり（追加・更新）
                    else if (tBOSearchUCountInt == 2)
                    {
                        // データが本社に削除する。
                        foreach (APTBOSearchUWork work in _tboSearchUList)
                        {
                            // 本社に削除する。
                            _tBOSearchUDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // データが本社に削除する。
                        foreach (APTBOSearchUWork apTBOSearchUWork in _tboSearchUList)
                        {
                            // 抽出したデータを登録する。
                            _tBOSearchUDB.Insert(apTBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            tBOSearchUCount++;
                        }

                    }
                    // 受信区分＝受信あり（更新のみ）
                    else if (tBOSearchUCountInt == 3)
                    {
                        // データが本社に存在場合、抽出レコードに保存する、又は、本社に削除する。
                        foreach (APTBOSearchUWork work in _tboSearchUList)
                        {
                            status = _tBOSearchUDB.SearchTBOSearchUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 存在場合には本社から削除
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _tboSearchUListTmp.Add(work);
                            }
                        }

                        foreach (APTBOSearchUWork delWork in _tboSearchUList)
                        {

                            // 存在するデータは本社に削除する。
                            _tBOSearchUDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APTBOSearchUWork apTBOSearchUWork in _tboSearchUListTmp)
                        {
                            // 抽出したデータを登録する。
                            _tBOSearchUDB.Insert(apTBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            tBOSearchUCount++;
                        }
                    }
                }
                // 部位コードマスタ（ユーザー登録）
                if (_partsPosCodeUList != null && _partsPosCodeUList.Count > 0)
                {
                    _partsPosCodeUDB = new APPartsPosCodeUDB();

                    // 受信区分＝受信あり（追加のみ）
                    if (partsPosCodeUInt == 1)
                    {
                        foreach (APPartsPosCodeUWork work in _partsPosCodeUList)
                        {
                            status = _partsPosCodeUDB.SearchPartsPosCodeUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _partsPosCodeUListTmp.Add(work);
                            }
                        }

                        foreach (APPartsPosCodeUWork apPartsPosCodeUWork in _partsPosCodeUListTmp)
                        {
                            // 抽出したデータを登録する。
                            _partsPosCodeUDB.Insert(apPartsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            partsPosCodeUCount++;
                        }
                    }
                    // 受信区分＝受信あり（追加・更新）
                    else if (partsPosCodeUInt == 2)
                    {
                        // データが本社に削除する。
                        foreach (APPartsPosCodeUWork work in _partsPosCodeUList)
                        {
                            // 本社に削除する。
                            _partsPosCodeUDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // データが本社に削除する。
                        foreach (APPartsPosCodeUWork apPartsPosCodeUWork in _partsPosCodeUList)
                        {
                            // 抽出したデータを登録する。
                            _partsPosCodeUDB.Insert(apPartsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            partsPosCodeUCount++;
                        }

                    }
                    // 受信区分＝受信あり（更新のみ）
                    else if (partsPosCodeUInt == 3)
                    {
                        // データが本社に存在場合、抽出レコードに保存する、又は、本社に削除する。
                        foreach (APPartsPosCodeUWork work in _partsPosCodeUList)
                        {
                            status = _partsPosCodeUDB.SearchPartsPosCodeUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 存在場合には本社から削除
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _partsPosCodeUListTmp.Add(work);
                            }
                        }

                        foreach (APPartsPosCodeUWork delWork in _partsPosCodeUList)
                        {

                            // 存在するデータは本社に削除する。
                            _partsPosCodeUDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APPartsPosCodeUWork apPartsPosCodeUWork in _partsPosCodeUListTmp)
                        {
                            // 抽出したデータを登録する。
                            _partsPosCodeUDB.Insert(apPartsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            partsPosCodeUCount++;
                        }
                    }
                }
                // BLコードガイドマスタ
                if (_blCodeGuideList != null && _blCodeGuideList.Count > 0)
                {
                    _bLCodeGuideDB = new APBLCodeGuideDB();

                    // 受信区分＝受信あり（追加のみ）
                    if (bLCodeGuideInt == 1)
                    {
                        foreach (APBLCodeGuideWork work in _blCodeGuideList)
                        {
                            status = _bLCodeGuideDB.SearchBLCodeGuideCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                _blCodeGuideListTmp.Add(work);
                            }
                        }

                        foreach (APBLCodeGuideWork apBLCodeGuideWork in _blCodeGuideListTmp)
                        {
                            // 抽出したデータを登録する。
                            _bLCodeGuideDB.Insert(apBLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            bLCodeGuideCount++;
                        }
                    }
                    // 受信区分＝受信あり（追加・更新）
                    else if (bLCodeGuideInt == 2)
                    {
                        // データが本社に削除する。
                        foreach (APBLCodeGuideWork work in _blCodeGuideList)
                        {
                            // 本社に削除する。
                            _bLCodeGuideDB.Delete(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        // データが本社に削除する。
                        foreach (APBLCodeGuideWork apBLCodeGuideWork in _blCodeGuideList)
                        {
                            // 抽出したデータを登録する。
                            _bLCodeGuideDB.Insert(apBLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            bLCodeGuideCount++;
                        }

                    }
                    // 受信区分＝受信あり（更新のみ）
                    else if (bLCodeGuideInt == 3)
                    {
                        // データが本社に存在場合、抽出レコードに保存する、又は、本社に削除する。
                        foreach (APBLCodeGuideWork work in _blCodeGuideList)
                        {
                            status = _bLCodeGuideDB.SearchBLCodeGuideCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 存在場合には本社から削除
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                _blCodeGuideListTmp.Add(work);
                            }
                        }

                        foreach (APBLCodeGuideWork delWork in _blCodeGuideList)
                        {

                            // 存在するデータは本社に削除する。
                            _bLCodeGuideDB.Delete(delWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }

                        foreach (APBLCodeGuideWork apBLCodeGuideWork in _blCodeGuideListTmp)
                        {
                            // 抽出したデータを登録する。
                            _bLCodeGuideDB.Insert(apBLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            bLCodeGuideCount++;
                        }
                    }
                }
                // MOD 2009/06/24 --->>>
                // 商品マスタ
                if (_goodsUList != null && _goodsUList.Count > 0)
                {
                    _goodsUDB = new APGoodsUDB();

                    foreach (APGoodsUWork work in _goodsUList)
                    {
                        status = _goodsUDB.SearchGoodsUCount(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                        // 受信区分＝受信あり（追加のみ）
                        if (goodsUInt == 1)
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                // 抽出したデータを登録する。
                                _goodsUDB.Insert(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                goodsUCount++;
                            }
                        }
                        // 受信区分＝受信あり（追加・更新）
                        else if (goodsUInt == 2)
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                // 抽出したデータを登録する。
                                _goodsUDB.Insert(work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                goodsUCount++;
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // 存在するデータを更新する。
                                _goodsUDB.Update(masterDtlDivList, work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                goodsUCount++;
                            }
                        }
                        // 受信区分＝受信あり（更新のみ）
                        else if (goodsUInt == 3)
                        {
                            // 抽出したデータを登録する。
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // 存在するデータを更新する。
                                _goodsUDB.Update(masterDtlDivList, work, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                                goodsUCount++;
                            }
                        }
                    }
                }
                // MOD 2009/06/24 ---<<<
                // ADD 2009/06/09 ---<<<

                // 拠点情報設定データデータ
                if (secInfoSetCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.SecInfoSetCount = secInfoSetCount;
                // 部門マスタデータ
                if (subSectionCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.SubSectionCount = subSectionCount;
                // 従業員マスタデータ
                if (employeeCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.EmployeeCount = employeeCount;
                // 従業員詳細マスタデータ
                if (employeeDtlCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.EmployeeDtlCount = employeeDtlCount;
                // 倉庫マスタ
                if (warehouseCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.WarehouseCount = warehouseCount;
                // 得意先マスタデータ
                if (customerCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.CustomerCount = customerCount;
                // 得意先マスタ(変動情報)データ
                if (customerChangeCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.CustomerChangeCount = customerChangeCount;
                // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                // 得意先マスタ(メモ情報)データ
                if (customerMemoCount != CNT_ZERO)
                {
                    isEmpty = false;
                }
                searchCountWork.CustomerMemoCount = customerMemoCount;
                // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                // 得意先マスタ（伝票管理）データ
                if (custSlipMngCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.CustSlipMngCount = custSlipMngCount;
                // 得意先マスタ（掛率グループ）データ
                if (custRateGroupCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.CustRateGroupCount = custRateGroupCount;
                // 得意先マスタ(伝票番号)データ
                if (custSlipNoSetCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.CustSlipNoSetCount = custSlipNoSetCount;
                // 仕入先マスタ
                if (supplierCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.SupplierCount = supplierCount;
                // メーカーマスタ（ユーザー登録分）データ
                if (makerUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.MakerUCount = makerUCount;
                // BL商品コードマスタ（ユーザー登録分）
                if (bLGoodsCdUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.BLGoodsCdUCount = bLGoodsCdUCount;
                // 商品マスタ（ユーザー登録分）
                if (goodsUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.GoodsUCount = goodsUCount;
                // 価格マスタ（ユーザー登録）データ
                if (goodsPriceCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.GoodsPriceCount = goodsPriceCount;
                // 商品管理情報マスタデータ
                if (goodsMngCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.GoodsMngCount = goodsMngCount;
                // 離島価格マスタデータ
                if (isolIslandPrcCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.IsolIslandPrcCount = isolIslandPrcCount;
                // 在庫マスタデータ
                if (stockCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.StockCount = stockCount;
                // ユーザーガイドマスタデータ
                // ユーザーガイドマスタ(販売エリア区分）
                if (userGdAreaDivUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdAreaDivUCount = userGdAreaDivUCount;
                // ユーザーガイドマスタ（業務区分）
                if (userGdBusDivUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdBusDivUCount = userGdBusDivUCount;
                // ユーザーガイドマスタ（業種）
                if (userGdCateUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdCateUCount = userGdCateUCount;
                // ユーザーガイドマスタ（職種）
                if (userGdBusUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdBusUCount = userGdBusUCount;
                // ユーザーガイドマスタ（商品区分）
                if (userGdGoodsDivUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdGoodsDivUCount = userGdGoodsDivUCount;
                // ユーザーガイドマスタ（得意先掛率グループ）
                if (userGdCusGrouPUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdCusGrouPUCount = userGdCusGrouPUCount;
                // ユーザーガイドマスタ（銀行）
                if (userGdBankUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdBankUCount = userGdBankUCount;
                // ユーザーガイドマスタ（価格区分）
                if (userGdPriDivUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdPriDivUCount = userGdPriDivUCount;
                // ユーザーガイドマスタ（納品区分）
                if (userGdDeliDivUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdDeliDivUCount = userGdDeliDivUCount;
                // ユーザーガイドマスタ（商品大分類）
                if (userGdGoodsBigUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdGoodsBigUCount = userGdGoodsBigUCount;
                // ユーザーガイドマスタ（販売区分）
                if (userGdBuyDivUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdBuyDivUCount = userGdBuyDivUCount;
                // ユーザーガイドマスタ（在庫管理区分１）
                if (userGdStockDivOUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdStockDivOUCount = userGdStockDivOUCount;
                // ユーザーガイドマスタ（在庫管理区分２）
                if (userGdStockDivTUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdStockDivTUCount = userGdStockDivTUCount;
                // ユーザーガイドマスタ（返品理由）
                if (userGdReturnReaUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.UserGdReturnReaUCount = userGdReturnReaUCount;
                // 掛率優先管理マスタデータ
                if (rateProtyMngCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.RateProtyMngCount = rateProtyMngCount;
                // 掛率マスタデータ
                if (rateCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.RateCount = rateCount;
                // 商品セットマスタデータ
                if (goodsSetCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.GoodsSetCount = goodsSetCount;
                // 部品代替マスタ（ユーザー登録分）データ
                if (partsSubstUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.PartsSubstUCount = partsSubstUCount;
                // 従業員別売上目標設定マスタデータ
                if (empSalesTargetCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.EmpSalesTargetCount = empSalesTargetCount;
                // 得意先別売上目標設定マスタデータ
                if (custSalesTargetCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.CustSalesTargetCount = custSalesTargetCount;
                // 商品別売上目標設定マスタデータ
                if (gcdSalesTargetCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.GcdSalesTargetCount = gcdSalesTargetCount;
                // 商品中分類マスタ（ユーザー登録分）データ
                if (goodsMGroupUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.GoodsMGroupUCount = goodsMGroupUCount;
                // BLグループマスタ（ユーザー登録分）データ
                if (bLGroupUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.BLGroupUCount = bLGroupUCount;
                // 結合マスタ（ユーザー登録分）データ
                if (joinPartsUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.JoinPartsUCount = joinPartsUCount;
                // TBO検索マスタ（ユーザー登録）データ
                if (tBOSearchUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.TBOSearchUCount = tBOSearchUCount;
                // 部位コードマスタ（ユーザー登録）データ
                if (partsPosCodeUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.PartsPosCodeUCount = partsPosCodeUCount;
                // BLコードガイドマスタデータ
                if (bLCodeGuideCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.BLCodeGuideCount = bLCodeGuideCount;
                // 車種名称マスタデータ
                if (modelNameUCount != 0)
                {
                    isEmpty = false;
                }
                searchCountWork.ModelNameUCount = modelNameUCount;

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APMSTControlDB.Update Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (resNm != "")
                {
                    // ↓ 2009/07/06 譚洪 modify
                    //ＡＰアンロック
                    status = Release(resNm, sqlConnection, sqlTransaction);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                    // ↑ 2009/07/06 譚洪 modify
                }

                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
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
                }

                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            //STATUSを戻す
            return status;
        }

        #endregion

        # region ◆ [コネクション生成処理] ◆
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlConnection CreateSqlConnectionData(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlTransaction CreateTransactionData(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // トランザクションの生成(開始)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        # endregion ◆ [コネクション生成処理] ◆

        #region ADD 2011/07/25 孫東響  SCM対応-拠点管理（10704767-00）
        # region ■ マスタ送信のデータ検索処理 ■
        /// <summary>
        /// マスタ受信のデータ検索処理
        /// </summary>
        /// <param name="masterDivList">マスタ区分</param>
        /// <param name="enterpriseCodes">PM企業コード</param>
        /// <param name="updSectionCode">拠点コード</param>
        /// <param name="paramList">マスタ抽出条件クラス</param>
        /// <param name="retCSAList">更新データ</param>
        /// <param name="sndRcvHisConsNo">送信番号</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ送信処理READの実データ検索を行うクラスです。</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.07.26</br>
        public int SearchCustomSerializeArrayList(ArrayList masterDivList, string enterpriseCodes, string updSectionCode, ArrayList paramList, ref CustomSerializeArrayList retCSAList, out int sndRcvHisConsNo, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMessage = string.Empty;
            sndRcvHisConsNo = -1;

            //抽出条件クラス
            // --- ADD 2012/07/26 -------------------------------->>>>>
            APEmployeeProcParamWork employeeProcParam = null;
            APJoinPartsUProcParamWork joinPartsUProcParam = null;
            APUserGdBuyDivUProcParamWork userGdBuyDivUProcParam = null;
            // --- ADD 2012/07/26 --------------------------------<<<<<
            APCustomerProcParamWork customerProcParam = null;
            APGoodsProcParamWork goodsProcParam = null;
            APStockProcParamWork stockProcParam = null;
            APSupplierProcParamWork supplierProcParam = null;
            APRateProcParamWork rateProcParam = null;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

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

                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                for (int i = 0; i < paramList.Count; i++)
                {
                    Type paramType = paramList[i].GetType();

                    // --- ADD 2012/07/26 --------------------------------------------->>>>>
                    if (paramType.Equals(typeof(APEmployeeProcParamWork)))
                    {
                        employeeProcParam = (APEmployeeProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(APJoinPartsUProcParamWork)))
                    {
                        joinPartsUProcParam = (APJoinPartsUProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(APUserGdBuyDivUProcParamWork)))
                    {
                        userGdBuyDivUProcParam = (APUserGdBuyDivUProcParamWork)paramList[i];
                    }
                    // --- ADD 2012/07/26 ---------------------------------------------<<<<<
                    if (paramType.Equals(typeof(APCustomerProcParamWork)))
                    {
                        customerProcParam = (APCustomerProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(APGoodsProcParamWork)))
                    {
                        goodsProcParam = (APGoodsProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(APStockProcParamWork)))
                    {
                        stockProcParam = (APStockProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(APSupplierProcParamWork)))
                    {
                        supplierProcParam = (APSupplierProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(APRateProcParamWork)))
                    {
                        rateProcParam = (APRateProcParamWork)paramList[i];
                    }
                }

                retCSAList = new CustomSerializeArrayList();

                foreach (SecMngSndRcvWork secMngSndRcvWork in masterDivList)
                {
                    // --- ADD 2012/07/26 --------------------------------------------->>>>>
                    // 従業員マスタ
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEE.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        employeeInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 従業員詳細マスタ
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEEDTL.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        employeeDtlInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 結合マスタ（ユーザー登録分）
                    if (MST_JOINPARTSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_JOINPARTSU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        joinPartsUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // ユーザーガイドマスタ（販売区分）
                    if (MST_USERGDBUYDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        userGdBuyDivUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // --- ADD 2012/07/26 ---------------------------------------------<<<<<
                    // 得意先マスタ
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOME.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        customerInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 商品マスタ（ユーザー登録分）
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        goodsUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 在庫マスタ
                    if (MST_STOCK.Equals(secMngSndRcvWork.MasterName) && MST_ID_STOCK.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        stockInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 仕入先マスタ
                    if (MST_SUPPLIER.Equals(secMngSndRcvWork.MasterName) && MST_ID_SUPPLIER.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        supplierInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 掛率マスタ
                    if (MST_RATE.Equals(secMngSndRcvWork.MasterName) && MST_ID_RATE.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        rateInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                }
                // --- ADD 2012/07/26 --------------------------------------------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeInt != 0 && employeeProcParam != null)
                {
                    // 従業員マスタデータ抽出
                    ArrayList employeeArrList = new ArrayList();
                    APEmployeeDB _employeeDB = new APEmployeeDB();
                    status = _employeeDB.SearchEmployee(enterpriseCodes, employeeProcParam, sqlConnection, sqlTransaction, out employeeArrList, out retMessage);
                    if (employeeArrList.Count > 0)
                    {
                        retCSAList.Add(employeeArrList);
                    }
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeDtlInt != 0 && employeeProcParam != null)
                {
                    // 従業員詳細マスタデータ抽出
                    ArrayList employeeDtlArrList = new ArrayList();
                    APEmployeeDtlDB _employeeDtlDB = new APEmployeeDtlDB();
                    status = _employeeDtlDB.SearchEmployeeDtl(enterpriseCodes, employeeProcParam, sqlConnection, sqlTransaction, out employeeDtlArrList, out retMessage);
                    if (employeeDtlArrList.Count > 0)
                    {
                        retCSAList.Add(employeeDtlArrList);
                    }
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && joinPartsUInt != 0 && joinPartsUProcParam != null)
                {
                    // 結合マスタ（ユーザー登録分）データ抽出
                    ArrayList joinPartsUArrList = new ArrayList();
                    APJoinPartsUDB _joinPartsUDB = new APJoinPartsUDB();
                    status = _joinPartsUDB.SearchJoinPartsU(enterpriseCodes, joinPartsUProcParam, sqlConnection, sqlTransaction, out joinPartsUArrList, out retMessage);
                    if (joinPartsUArrList.Count > 0)
                    {
                        retCSAList.Add(joinPartsUArrList);
                    }
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && userGdBuyDivUInt != 0 && userGdBuyDivUProcParam != null)
                {
                    // ユーザーガイドマスタ（販売区分）データ抽出
                    ArrayList userGdBdUArrList = new ArrayList();
                    APUserGdBdUDB _userGdBdUDB = new APUserGdBdUDB();
                    status = _userGdBdUDB.SearchUserGdBdU(71, enterpriseCodes, userGdBuyDivUProcParam, sqlConnection, sqlTransaction, out userGdBdUArrList, out retMessage);
                    if (userGdBdUArrList.Count > 0)
                    {
                        retCSAList.Add(userGdBdUArrList);
                    }
                }
                // --- ADD 2012/07/26 ---------------------------------------------<<<<<
                if (customerInt != 0 && customerProcParam != null)
                {
                    //ADD 2011/08/25 #23798 条件送信で更新ボタン押下で処理が終了しない--------------------------------->>>>>
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 得意先マスタデータ抽出
                        ArrayList customerArrList = new ArrayList();
                        APCustomerDB _customerDB = new APCustomerDB();
                        status = _customerDB.SearchAllCustomer(enterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out customerArrList, out retMessage);
                        for (int m = 0; m < customerArrList.Count; m++)
                        {
                            if (((ArrayList)customerArrList[m]).Count > 0)
                            {
                                retCSAList.Add(customerArrList[m]);
                            }
                        }
                    }
                    //ADD 2011/08/25 #23798 条件送信で更新ボタン押下で処理が終了しない---------------------------------<<<<<
                    #region DEL 
                    //DEL 2011/08/25 #23798 条件送信で更新ボタン押下で処理が終了しない--------------------------------->>>>>                   if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // 得意先マスタデータ抽出
                    //    ArrayList customerArrList = new ArrayList();
                    //    APCustomerDB _customerDB = new APCustomerDB();
                    //    status = _customerDB.SearchCustomer(enterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out customerArrList, out retMessage);
                    //    if (customerArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(customerArrList);
                    //    }
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // 得意先マスタ（掛率グループ）データ抽出
                    //    ArrayList custRateGroupArrList = new ArrayList();
                    //    APCustRateGroupDB _custRateGroupDB = new APCustRateGroupDB();
                    //    status = _custRateGroupDB.SearchCustRateGroup(enterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out custRateGroupArrList, out retMessage);
                    //    if (custRateGroupArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(custRateGroupArrList);
                    //    }
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // 得意先マスタ(変動情報)データ抽出
                    //    ArrayList customerChangeArrList = new ArrayList();
                    //    APCustomerChangeDB _customerChangeDB = new APCustomerChangeDB();
                    //    status = _customerChangeDB.SearchCustomerChange(enterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out customerChangeArrList, out retMessage);
                    //    if (customerChangeArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(customerChangeArrList);
                    //    }
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // 得意先マスタ（伝票管理）データ抽出
                    //    ArrayList custSlipMngArrList = new ArrayList();
                    //    APCustSlipMngDB _custSlipMngDB = new APCustSlipMngDB();
                    //    status = _custSlipMngDB.SearchCustSlipMng(enterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out custSlipMngArrList, out retMessage);
                    //    if (custSlipMngArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(custSlipMngArrList);
                    //    }
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // 得意先マスタ(伝票番号)データ抽出
                    //    ArrayList custSlipNoSetArrList = new ArrayList();
                    //    APCustSlipNoSetDB _custSlipNoSetDB = new APCustSlipNoSetDB();
                    //    status = _custSlipNoSetDB.SearchCustSlipNoSet(enterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out custSlipNoSetArrList, out retMessage);
                    //    if (custSlipNoSetArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(custSlipNoSetArrList);
                    //    }
                    //}
                    //DEL 2011/08/25 #23798 条件送信で更新ボタン押下で処理が終了しない---------------------------------<<<<<
                    #endregion
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsUInt != 0 && goodsProcParam != null)
                {
                    //ADD 2011/08/25 #23798 条件送信で更新ボタン押下で処理が終了しない--------------------------------->>>>>
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 商品マスタ４つデータ抽出
                        ArrayList goodsAllList = new ArrayList();
                        APGoodsUDB _goodsUDB = new APGoodsUDB();
                        status = _goodsUDB.SearchGoodsAll(enterpriseCodes, goodsProcParam, sqlConnection, sqlTransaction, out goodsAllList, out retMessage);
                        for (int m = 0; m < goodsAllList.Count; m++)
                        {
                            if (((ArrayList)goodsAllList[m]).Count > 0)
                            {
                                retCSAList.Add(goodsAllList[m]);
                            }
                        }
                    }
                    //ADD 2011/08/25 #23798 条件送信で更新ボタン押下で処理が終了しない---------------------------------<<<<<
                    #region DEL
                    //DEL 2011/08/25 #23798 条件送信で更新ボタン押下で処理が終了しない--------------------------------->>>>>
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // 商品マスタ（ユーザー登録分）データと商品管理情報マスタデータ抽出
                    //    ArrayList goodsUArrList = new ArrayList();
                    //    ArrayList goodsMngArrList = new ArrayList();
                    //    APGoodsUDB _goodsUDB = new APGoodsUDB();
                    //    status = _goodsUDB.SearchGoodsU(enterpriseCodes, goodsProcParam, sqlConnection, sqlTransaction, out goodsUArrList, out goodsMngArrList, out retMessage);
                    //    if (goodsUArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(goodsUArrList);
                    //    }
                    //    if (goodsMngArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(goodsMngArrList);
                    //    }
                    //}

                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // 価格マスタ（ユーザー登録）データ抽出
                    //    ArrayList goodsPriceUArrList = new ArrayList();
                    //    APGoodsPriceUDB _goodsPriceUDB = new APGoodsPriceUDB();
                    //    status = _goodsPriceUDB.SearchGoodsPriceU(enterpriseCodes, goodsProcParam, sqlConnection, sqlTransaction, out goodsPriceUArrList, out retMessage);
                    //    if (goodsPriceUArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(goodsPriceUArrList);
                    //    }
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // 離島価格マスタデータ抽出
                    //    ArrayList isolIslandPrcArrList = new ArrayList();
                    //    APIsolIslandPrcDB _isolIslandPrcDB = new APIsolIslandPrcDB();
                    //    status = _isolIslandPrcDB.SearchIsolIslandPrc(enterpriseCodes, goodsProcParam, sqlConnection, sqlTransaction, out isolIslandPrcArrList, out retMessage);
                    //    if (isolIslandPrcArrList.Count > 0)
                    //    {
                    //        retCSAList.Add(isolIslandPrcArrList);
                    //    }
                    //}
                    //DEL 2011/08/25 #23798 条件送信で更新ボタン押下で処理が終了しない---------------------------------<<<<<
                    #endregion
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockInt != 0 && stockProcParam != null)
                {
                    // 在庫マスタデータ抽出
                    ArrayList stockArrList = new ArrayList();
                    APStockDB _stockDB = new APStockDB();
                    status = _stockDB.SearchStock(enterpriseCodes, stockProcParam, sqlConnection, sqlTransaction, out stockArrList, out retMessage);
                    if (stockArrList.Count > 0)
                    {
                        retCSAList.Add(stockArrList);
                    }
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplierInt != 0 && supplierProcParam != null)
                {
                    // 仕入先マスタデータ抽出
                    ArrayList supplierArrList = new ArrayList();
                    APSupplierDB _supplierDB = new APSupplierDB();
                    status = _supplierDB.SearchSupplier(enterpriseCodes, supplierProcParam, sqlConnection, sqlTransaction, out supplierArrList, out retMessage);
                    if (supplierArrList.Count > 0)
                    {
                        retCSAList.Add(supplierArrList);
                    }
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && rateInt != 0 && rateProcParam != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 掛率マスタデータ抽出
                        ArrayList rateArrList = new ArrayList();
                        APRateDB _rateDB = new APRateDB();
                        status = _rateDB.SearchRate(enterpriseCodes, rateProcParam, sqlConnection, sqlTransaction, out rateArrList, out retMessage);
                        if (rateArrList.Count > 0)
                        {
                            retCSAList.Add(rateArrList);
                        }
                    }
                }

                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                //if (retCSAList.Count > 0)//DEL 2011/09/05 #24047
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retCSAList.Count > 0)//ADD 2011/09/05 #24047
                {
                    long no = -1;
                    NumberingManager numberingManager = new NumberingManager();
                    SerialNumberCode serialnumcd = SerialNumberCode.SndRcvHisConsNo;
                    status = numberingManager.GetSerialNumber(enterpriseCodes, updSectionCode.Trim(), serialnumcd, out no);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && no != -1)
                    {
                        sndRcvHisConsNo = (int)no;
                    }
                }
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            }
            catch (Exception ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APMSTControlDB.SearchCustomSerializeArrayList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        # region ■ マスタ受信のデータ件数検索処理 ■
        #region DEL 2011.09.06 #24364
        ///// <summary>
        ///// マスタ受信のデータ検索処理
        ///// </summary>
        ///// <param name="pmEnterpriseCodes">PM企業コード</param>
        ///// <param name="secMngSndRcvWork">マスタ区分</param>
        ///// <param name="param">マスタ抽出条件クラス</param>
        ///// <param name="count">戻る件数</param>
        ///// <param name="retMessage">戻るメッセージ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : データ送信処理READの実データ検索を行うクラスです。</br>
        ///// <br>Programmer : sundx</br>
        ///// <br>Date       : 2011.07.26</br>
        //public int GetObjCount(string pmEnterpriseCodes, SecMngSndRcvWork secMngSndRcvWork, object param, ref int count, out string retMessage)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    retMessage = string.Empty;

        //    //--------------------------
        //    // データベースオープン
        //    //--------------------------
        //    SqlConnection sqlConnection = null;
        //    SqlTransaction sqlTransaction = null;

        //    try
        //    {
        //        SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
        //        string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
        //        if (_connectionText == null || _connectionText == "")
        //        {
        //            return status;
        //        }

        //        sqlConnection = new SqlConnection(_connectionText);
        //        sqlConnection.Open();

        //        // トランザクション
        //        sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

        //        switch (secMngSndRcvWork.FileId)
        //        {
        //            case MST_GOODSU:
        //                //商品マスタ
        //                APGoodsUDB _goodsUDB = new APGoodsUDB();
        //                status = _goodsUDB.SearchGoodsUCount(pmEnterpriseCodes, param, sqlConnection, sqlTransaction, ref count, out retMessage);
        //                break;
        //            case MST_STOCK:
        //                // 在庫マスタ
        //                APStockDB _stockDB = new APStockDB();
        //                status = _stockDB.SearchStockCount(pmEnterpriseCodes, param, sqlConnection, sqlTransaction, ref count, out retMessage);
        //                break;
        //            default:
        //                count = -1;
        //                break;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
        //        //基底クラスに例外を渡して処理してもらう
        //        base.WriteErrorLog(ex, "APMSTControlDB.GetObjCount Exception=" + ex.Message);
        //        retMessage = ex.Message;
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null) sqlTransaction.Dispose();
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //    }
        //    return status;
        //}
        #endregion DEL 2011.09.06 #24364
        //-----ADD 2011.09.06 #24364----->>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="masterDivList">マスタ区分</param>
        /// <param name="enterpriseCodes">PM企業コード</param>
        /// <param name="paramList">マスタ抽出条件クラス</param>
        /// <param name="searchCountWork">検索計数ワーク</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns></returns>
        public int GetObjCount(ArrayList masterDivList, string enterpriseCodes, ArrayList paramList, out MstSearchCountWorkWork searchCountWork, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int count = 0;
            searchCountWork = new MstSearchCountWorkWork();
            retMessage = string.Empty;

            //抽出条件クラス
            APGoodsProcParamWork goodsProcParam = null;
            APStockProcParamWork stockProcParam = null;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

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

                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                for (int i = 0; i < paramList.Count; i++)
                {
                    Type paramType = paramList[i].GetType();

                    if (paramType.Equals(typeof(APGoodsProcParamWork)))
                    {
                        goodsProcParam = (APGoodsProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(APStockProcParamWork)))
                    {
                        stockProcParam = (APStockProcParamWork)paramList[i];
                    }
                }

                foreach (SecMngSndRcvWork secMngSndRcvWork in masterDivList)
                {
                    // 商品マスタ（ユーザー登録分）
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSU.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        goodsUInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                    // 在庫マスタ
                    if (MST_STOCK.Equals(secMngSndRcvWork.MasterName) && MST_ID_STOCK.Equals(secMngSndRcvWork.FileId)
                        && 1 == secMngSndRcvWork.SecMngSendDiv)
                    {
                        stockInt = secMngSndRcvWork.SecMngSendDiv;
                    }
                }
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockInt != 0 && stockProcParam != null)
                {
                    // 在庫マスタデータ抽出
                    APStockDB _stockDB = new APStockDB();
                    status = _stockDB.SearchStockCount(enterpriseCodes, stockProcParam, sqlConnection, sqlTransaction, out count, out retMessage);
                    if (count > MAX_CNT)
                    {
                        searchCountWork.ErrorKubun = -4;
                        return status;
                    }
                }
            }
            catch (Exception ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APMSTControlDB.GetObjCount Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        //-----ADD 2011.09.06 #24364-----<<<<<
        # endregion ■ マスタ受信のデータ件数検索処理 ■
        #endregion ADD 2011/07/25 孫東響  SCM対応-拠点管理（10704767-00）
    }
}
