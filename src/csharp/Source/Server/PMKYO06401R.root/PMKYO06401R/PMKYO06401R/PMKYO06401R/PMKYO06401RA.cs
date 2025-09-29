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
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/06/06  修正内容 : PMKYO06003Dが存在しないとエラーの修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/06/09  修正内容 : マスタ送受信不備対応について 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/07/06  修正内容 : マスタ送受信処理のＡＰＰロックについて
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/07/06  修正内容 : データ送信処理のDCサーバーのエラーログについて
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/07/26  修正内容 : SCM対応-拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/08/25  修正内容 : #23798 条件送信で更新ボタン押下で処理が終了しない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/26  修正内容 : DC履歴ログとDC各データのクリア処理を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Liangsd
// 修 正 日  2011/09/06 修正内容 :  Redmine#23918拠点管理改良PG変更追加依頼を追加
//----------------------------------------------------------------------------//
// 管理番号  10802197-00 修正担当 : FSI東 隆史
// 修 正 日  2012/07/26  修正内容 : 拠点管理 抽出条件追加対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 修 正 日  2012/07/26  修正内容 : 拠点管理DCログ時間追加改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 修 正 日  2012/09/05  修正内容 : APアンロック時の条件変更（ロック出来なかった場合はアンロックしない）
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
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br>Update Note : 2012/07/26 姚学剛 </br>
    /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
    /// <br>Update Note: 2012/10/16 李亜博</br>
    ///	<br>			 10801804-00、Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
    /// <br>Update Note: 2021/04/12 陳艶丹</br>
    /// <br>管理番号   : 11770021-00</br>
    /// <br>           : PMKOBETSU-4136 得意先メモ情報の追加</br>
    /// </remarks>
    public class MstDCControlDB : RemoteWithAppLockDB, IMstDCControlDB
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
        //private const string MST_ID_EMPLOYEE = "EmployeeDtlRF";   // DEL 2012/07/26 姚学剛
        private const string MST_ID_EMPLOYEE = "EmployeeRF";   // ADD 2012/07/26 姚学剛
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
        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
        private const int CNT_ZERO = 0;
        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
        #endregion ■ Const Memebers ■

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
        private Int32 customerMemoInt = CNT_ZERO;
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
        # endregion ■ Private Members ■

        # region ■ Constructor ■
        /// <summary>
        /// DCコントロールリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.4.24</br>
        /// </remarks>
        public MstDCControlDB()
        {
        }
        # endregion ■ Constructor ■

        # region ■ マスタ受信のデータ検索処理 ■
        /// <summary>
        /// マスタ受信のデータ検索処理
        /// </summary>
        /// <param name="masterDivList">マスタ区分</param>
        /// <param name="pmEnterpriseCodes">PM企業コード</param>
        /// <param name="beginningDate">検索条件</param>
        /// <param name="endingDate">検索条件</param>
        /// <param name="retCSAList">更新データ</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ送信処理READの実データ検索を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        /// <br>Update Note : 2012/07/26 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 10801804-00、Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先メモ情報の追加</br>
        public int SearchCustomSerializeArrayList(ArrayList masterDivList, string pmEnterpriseCodes, Int64 beginningDate, Int64 endingDate, ref CustomSerializeArrayList retCSAList, out string retMessage)
        {
            // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// 処理開始日時を取得する。
            //DateTime startCurrentTime = new DateTime();
            //startCurrentTime = DateTime.Now;
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            
            string tempSndRcvFileID = string.Empty;
            Dictionary<string, string> tempSndRcvDic = new Dictionary<string, string>();
            // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMessage = string.Empty;

            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            ArrayList tempSndRcvHisResWorkList = new ArrayList();

            SndRcvHisTableWork tempSndRcvHisTableWork = new SndRcvHisTableWork();

            if (masterDivList.Count > 0)
            {
                // 企業コード
                tempSndRcvHisTableWork.EnterpriseCode = pmEnterpriseCodes;
                // 拠点コード
                tempSndRcvHisTableWork.SectionCode = ((DCSecMngSndRcvWork)masterDivList[0]).SectionCode;
                //送受信履歴ログ送信番号
                tempSndRcvHisTableWork.SndRcvHisConsNo = ((DCSecMngSndRcvWork)masterDivList[0]).SndRcvHisConsNo;
                // 送受信区分:受信処理（開始）
                tempSndRcvHisTableWork.SendOrReceiveDivCd = 3;
                // 送受信日時
                tempSndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
                // 種別
                tempSndRcvHisTableWork.Kind = 1;
                // 送受信ログ抽出条件区分
                tempSndRcvHisTableWork.SndLogExtraCondDiv = 0;
                // 送信先企業コード
                tempSndRcvHisTableWork.SendDestEpCode = ((DCSecMngSndRcvWork)masterDivList[0]).EnterpriseCode;
                // 送信先拠点コード
                tempSndRcvHisTableWork.SendDestSecCode = ((DCSecMngSndRcvWork)masterDivList[0]).SendDestSecCode;
                //送信対象開始日時
                tempSndRcvHisTableWork.SndObjStartDate = beginningDate;
                //送信対象終了日時
                tempSndRcvHisTableWork.SndObjEndDate = endingDate;
                // 仮受信区分
                if (((DCSecMngSndRcvWork)masterDivList[0]).TempReceiveDiv == 2)
                {   // 仮受信の場合
                    tempSndRcvHisTableWork.TempReceiveDiv = 2;
                }
                else
                {   // 受信の場合
                    tempSndRcvHisTableWork.TempReceiveDiv = 1;
                }
                // エラー内容
                tempSndRcvHisTableWork.SndRcvErrContents = retMessage;
                // 送受信ファイルＩＤ
                tempSndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;
                tempSndRcvHisResWorkList.Add(tempSndRcvHisTableWork);
            }
            SndRcvHisTableDB tempSndRcvHisResDB = new SndRcvHisTableDB();
            object tempObjSndRcvHisResWorkList = tempSndRcvHisResWorkList as object;
            tempSndRcvHisResDB.Write(ref tempObjSndRcvHisResWorkList);
            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
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
                // MOD 2009/06/06 --->>>
                foreach (DCSecMngSndRcvWork secMngSndRcvWork in masterDivList)
                // MOD 2009/06/06 ---<<<
                {
                    // 拠点設定マスタ
                    if (MST_SECINFOSET.Equals(secMngSndRcvWork.MasterName) && MST_ID_SECINFOSET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        secInfoSetInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 部門設定マスタ
                    if (MST_SUBSECTION.Equals(secMngSndRcvWork.MasterName) && MST_ID_SUBSECTION.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        subSectionInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 倉庫設定マスタ
                    if (MST_WAREHOUSE.Equals(secMngSndRcvWork.MasterName) && MST_ID_WAREHOUSE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        warehouseInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 従業員マスタ
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        employeeInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 従業員詳細マスタ
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEEDTL.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        employeeDtlInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 得意先マスタ
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOME.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        customerInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 得意先マスタ(変動情報)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMECHA.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        customerChangeInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                    // 得意先マスタ(メモ情報)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMEMEMO.Equals(secMngSndRcvWork.FileId)
                        && CNT_ZERO != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        customerMemoInt = secMngSndRcvWork.SecMngRecvDiv;
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                    }
                    // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                    // 得意先マスタ（伝票管理）
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMESLIPMNG.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        custSlipMngInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 得意先マスタ（掛率グループ）
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMEGROUP.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        custRateGroupInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 得意先マスタ(伝票番号)
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOMESLIPNO.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        custSlipNoSetInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 仕入先マスタ
                    if (MST_SUPPLIER.Equals(secMngSndRcvWork.MasterName) && MST_ID_SUPPLIER.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        supplierInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // メーカーマスタ（ユーザー登録分）
                    if (MST_MAKERU.Equals(secMngSndRcvWork.MasterName) && MST_ID_MAKERU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        makerUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // BL商品コードマスタ（ユーザー登録分）
                    if (MST_BLGOODSCDU.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLGOODSCDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        bLGoodsCdUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 商品マスタ（ユーザー登録分）
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 価格マスタ（ユーザー登録）
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUPRI.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsPriceInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 商品管理情報マスタ
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUMNG.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsMngInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 離島価格マスタ
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSUISO.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        isolIslandPrcInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 在庫マスタ
                    if (MST_STOCK.Equals(secMngSndRcvWork.MasterName) && MST_ID_STOCK.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        stockInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ユーザーガイドマスタ(販売エリア区分）
                    if (MST_USERGDAREADIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdAreaDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ユーザーガイドマスタ（業務区分）
                    if (MST_USERGDBUSDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBusDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ユーザーガイドマスタ（業種）
                    if (MST_USERGDCATEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdCateUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ユーザーガイドマスタ（職種）
                    if (MST_USERGDBUSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBusUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ユーザーガイドマスタ（商品区分）
                    if (MST_USERGDGOODSDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdGoodsDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ユーザーガイドマスタ（得意先掛率グループ）
                    if (MST_USERGDCUSGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdCusGrouPUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ユーザーガイドマスタ（銀行）
                    if (MST_USERGDBANKU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBankUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ユーザーガイドマスタ（価格区分）
                    if (MST_USERGDPRIDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdPriDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ユーザーガイドマスタ（納品区分）
                    if (MST_USERGDDELIDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdDeliDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ユーザーガイドマスタ（商品大分類）
                    if (MST_USERGDGOODSBIGU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdGoodsBigUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ユーザーガイドマスタ（販売区分）
                    if (MST_USERGDBUYDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBuyDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ユーザーガイドマスタ（在庫管理区分１）
                    if (MST_USERGDSTOCKDIVOU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdStockDivOUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ユーザーガイドマスタ（在庫管理区分２）
                    if (MST_USERGDSTOCKDIVTU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdStockDivTUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // ユーザーガイドマスタ（返品理由）
                    if (MST_USERGDRETURNREAU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdReturnReaUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString()))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId + secMngSndRcvWork.UserGuideDivCd.ToString(), secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 掛率優先管理マスタ
                    if (MST_RATEPROTYMNG.Equals(secMngSndRcvWork.MasterName) && MST_ID_RATEPROTYMNG.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        rateProtyMngInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 掛率マスタ
                    if (MST_RATE.Equals(secMngSndRcvWork.MasterName) && MST_ID_RATE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        rateInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 商品セットマスタ
                    if (MST_GOODSSET.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSSET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsSetInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 部品代替マスタ（ユーザー登録分）
                    if (MST_PARTSSUBSTU.Equals(secMngSndRcvWork.MasterName) && MST_ID_PARTSSUBSTU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        partsSubstUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 従業員別売上目標設定マスタ
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        empSalesTargetInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 得意先別売上目標設定マスタ
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        custSalesTargetInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 商品別売上目標設定マスタ
                    if (MST_SALESTARGET.Equals(secMngSndRcvWork.MasterName) && MST_ID_GCDSALESTARGET.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        gcdSalesTargetInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 商品中分類マスタ（ユーザー登録分）
                    if (MST_GOODSMGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSMGROUPU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsMGroupUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // BLグループマスタ（ユーザー登録分）
                    if (MST_BLGROUPU.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLGROUPU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        bLGroupUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 結合マスタ（ユーザー登録分）
                    if (MST_JOINPARTSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_JOINPARTSU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        joinPartsUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // TBO検索マスタ（ユーザー登録）
                    if (MST_TBOSEARCHU.Equals(secMngSndRcvWork.MasterName) && MST_ID_TBOSEARCHU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        tBOSearchUCountInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 部位コードマスタ（ユーザー登録）
                    if (MST_PARTSPOSCODEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_PARTSPOSCODEU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        partsPosCodeUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // BLコードガイドマスタ
                    if (MST_BLCODEGUIDE.Equals(secMngSndRcvWork.MasterName) && MST_ID_BLCODEGUIDE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        bLCodeGuideInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 車種名称マスタ
                    if (MST_MODELNAMEU.Equals(secMngSndRcvWork.MasterName) && MST_ID_MODELNAMEU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        modelNameUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                }

                // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                foreach (KeyValuePair<string, string> tempFileId in tempSndRcvDic)
                {
                    if (string.IsNullOrEmpty(tempSndRcvFileID))
                    {
                        tempSndRcvFileID = tempSndRcvFileID + tempFileId.Key;
                    }
                    else
                    {
                        tempSndRcvFileID = tempSndRcvFileID + "," + tempFileId.Key;
                    }
                    
                }
                // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<

                if (secInfoSetInt != 0)
                {
                    // 拠点情報設定マスタデータ抽出
                    ArrayList secInfoSetArrList = new ArrayList();
                    DCSecInfoSetDB _secInfoSetDB = new DCSecInfoSetDB();
                    status = _secInfoSetDB.SearchSecInfoSet(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out secInfoSetArrList, out retMessage);
                    retCSAList.Add(secInfoSetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && subSectionInt != 0)
                {
                    // 部門マスタデータ抽出
                    ArrayList subSectionArrList = new ArrayList();
                    DCSubSectionDB _subSectionDB = new DCSubSectionDB();
                    status = _subSectionDB.SearchSubSection(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out subSectionArrList, out retMessage);
                    retCSAList.Add(subSectionArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeInt != 0)
                {
                    // 従業員マスタデータ抽出
                    ArrayList employeeArrList = new ArrayList();
                    DCEmployeeDB _employeeDB = new DCEmployeeDB();
                    status = _employeeDB.SearchEmployee(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out employeeArrList, out retMessage);
                    retCSAList.Add(employeeArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeDtlInt != 0)
                {
                    // 従業員詳細マスタデータ抽出
                    ArrayList employeeDtlArrList = new ArrayList();
                    DCEmployeeDtlDB _employeeDtlDB = new DCEmployeeDtlDB();
                    status = _employeeDtlDB.SearchEmployeeDtl(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out employeeDtlArrList, out retMessage);
                    retCSAList.Add(employeeDtlArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && warehouseInt != 0)
                {
                    // 倉庫マスタデータ抽出
                    ArrayList warehouseArrList = new ArrayList();
                    DCWarehouseDB _warehouseDB = new DCWarehouseDB();
                    status = _warehouseDB.SearchWarehouse(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out warehouseArrList, out retMessage);
                    retCSAList.Add(warehouseArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInt != 0)
                {
                    // 得意先マスタデータ抽出
                    ArrayList customerArrList = new ArrayList();
                    DCCustomerDB _customerDB = new DCCustomerDB();
                    status = _customerDB.SearchCustomer(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out customerArrList, out retMessage);
                    retCSAList.Add(customerArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerChangeInt != 0)
                {
                    // 得意先マスタ(変動情報)データ抽出
                    ArrayList customerChangeArrList = new ArrayList();
                    DCCustomerChangeDB _customerChangeDB = new DCCustomerChangeDB();
                    status = _customerChangeDB.SearchCustomerChange(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out customerChangeArrList, out retMessage);
                    retCSAList.Add(customerChangeArrList);
                }
                // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerMemoInt != CNT_ZERO)
                {
                    // 得意先マスタ(メモ情報)データ抽出
                    ArrayList customerMemoArrList = new ArrayList();
                    DCCustomerMemoDB _customerMemoDB = new DCCustomerMemoDB();
                    status = _customerMemoDB.SearchCustomerMemo(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out customerMemoArrList, out retMessage);
                    retCSAList.Add(customerMemoArrList);
                }
                // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && custSlipMngInt != 0)
                {
                    // 得意先マスタ（伝票管理）データ抽出
                    ArrayList custSlipMngArrList = new ArrayList();
                    DCCustSlipMngDB _custSlipMngDB = new DCCustSlipMngDB();
                    status = _custSlipMngDB.SearchCustSlipMng(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custSlipMngArrList, out retMessage);
                    retCSAList.Add(custSlipMngArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && custRateGroupInt != 0)
                {
                    // 得意先マスタ（掛率グループ）データ抽出
                    ArrayList custRateGroupArrList = new ArrayList();
                    DCCustRateGroupDB _custRateGroupDB = new DCCustRateGroupDB();
                    status = _custRateGroupDB.SearchCustRateGroup(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custRateGroupArrList, out retMessage);
                    retCSAList.Add(custRateGroupArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && custSlipNoSetInt != 0)
                {
                    // 得意先マスタ(伝票番号)データ抽出
                    ArrayList custSlipNoSetArrList = new ArrayList();
                    DCCustSlipNoSetDB _custSlipNoSetDB = new DCCustSlipNoSetDB();
                    status = _custSlipNoSetDB.SearchCustSlipNoSet(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custSlipNoSetArrList, out retMessage);
                    retCSAList.Add(custSlipNoSetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplierInt != 0)
                {
                    // 仕入先マスタデータ抽出
                    ArrayList supplierArrList = new ArrayList();
                    DCSupplierDB _supplierDB = new DCSupplierDB();
                    status = _supplierDB.SearchSupplier(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out supplierArrList, out retMessage);
                    retCSAList.Add(supplierArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && makerUInt != 0)
                {
                    // メーカーマスタ（ユーザー登録分）データ抽出
                    ArrayList makerUArrList = new ArrayList();
                    DCMakerUDB _makerUDB = new DCMakerUDB();
                    status = _makerUDB.SearchMakerU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out makerUArrList, out retMessage);
                    retCSAList.Add(makerUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && bLGoodsCdUInt != 0)
                {
                    // BL商品コードマスタ（ユーザー登録分）データ抽出
                    ArrayList bLGoodsCdUArrList = new ArrayList();
                    DCBLGoodsCdUDB _bLGoodsCdUDB = new DCBLGoodsCdUDB();
                    status = _bLGoodsCdUDB.SearchBLGoodsCdU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out bLGoodsCdUArrList, out retMessage);
                    retCSAList.Add(bLGoodsCdUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsUInt != 0)
                {
                    // 商品マスタ（ユーザー登録分）データ抽出
                    ArrayList goodsUArrList = new ArrayList();
                    DCGoodsUDB _goodsUDB = new DCGoodsUDB();
                    status = _goodsUDB.SearchGoodsU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsUArrList, out retMessage);
                    retCSAList.Add(goodsUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsPriceInt != 0)
                {
                    // 価格マスタ（ユーザー登録）データ抽出
                    ArrayList goodsPriceUArrList = new ArrayList();
                    DCGoodsPriceUDB _goodsPriceUDB = new DCGoodsPriceUDB();
                    status = _goodsPriceUDB.SearchGoodsPriceU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsPriceUArrList, out retMessage);
                    retCSAList.Add(goodsPriceUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsMngInt != 0)
                {
                    // 商品管理情報マスタデータ抽出
                    ArrayList goodsMngArrList = new ArrayList();
                    DCGoodsMngDB _goodsMngDB = new DCGoodsMngDB();
                    status = _goodsMngDB.SearchGoodsMng(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsMngArrList, out retMessage);
                    retCSAList.Add(goodsMngArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && isolIslandPrcInt != 0)
                {
                    // 離島価格マスタデータ抽出
                    ArrayList isolIslandPrcArrList = new ArrayList();
                    DCIsolIslandPrcDB _isolIslandPrcDB = new DCIsolIslandPrcDB();
                    status = _isolIslandPrcDB.SearchIsolIslandPrc(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out isolIslandPrcArrList, out retMessage);
                    retCSAList.Add(isolIslandPrcArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockInt != 0)
                {
                    // 在庫マスタデータ抽出
                    ArrayList stockArrList = new ArrayList();
                    DCStockDB _stockDB = new DCStockDB();
                    status = _stockDB.SearchStock(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockArrList, out retMessage);
                    retCSAList.Add(stockArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ユーザーガイドマスタデータ抽出
                    ArrayList userGdBdUArrList = new ArrayList();
                    DCUserGdBdUDB _userGdBdUDB = new DCUserGdBdUDB();
                    // ユーザーガイドマスタ(販売エリア区分）
                    if (userGdAreaDivUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(21, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（業務区分）
                    if (userGdBusDivUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(31, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（業種）
                    if (userGdCateUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(33, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（職種）
                    if (userGdBusUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(34, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（商品区分）
                    if (userGdGoodsDivUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(41, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（得意先掛率グループ）
                    if (userGdCusGrouPUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(43, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（銀行）
                    if (userGdBankUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(46, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（価格区分）
                    if (userGdPriDivUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(47, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（納品区分）
                    if (userGdDeliDivUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(48, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（商品大分類）
                    if (userGdGoodsBigUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(70, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（販売区分）
                    if (userGdBuyDivUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(71, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（在庫管理区分１）
                    if (userGdStockDivOUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(72, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（在庫管理区分２）
                    if (userGdStockDivTUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(73, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    // ユーザーガイドマスタ（返品理由）
                    if (userGdReturnReaUInt != 0)
                    {
                        status = _userGdBdUDB.SearchUserGdBdU(91, pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, ref userGdBdUArrList, out retMessage);
                    }
                    retCSAList.Add(userGdBdUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && rateProtyMngInt != 0)
                {
                    // 掛率優先管理マスタデータ抽出
                    ArrayList rateProtyMngArrList = new ArrayList();
                    DCRateProtyMngDB _rateProtyMngDB = new DCRateProtyMngDB();
                    status = _rateProtyMngDB.SearchRateProtyMng(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out rateProtyMngArrList, out retMessage);
                    retCSAList.Add(rateProtyMngArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && rateInt != 0)
                {
                    // 掛率マスタデータ抽出
                    ArrayList rateArrList = new ArrayList();
                    DCRateDB _rateDB = new DCRateDB();
                    status = _rateDB.SearchRate(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out rateArrList, out retMessage);
                    retCSAList.Add(rateArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsSetInt != 0)
                {
                    // 商品セットマスタデータ抽出
                    ArrayList goodsSetArrList = new ArrayList();
                    DCGoodsSetDB _goodsSetDB = new DCGoodsSetDB();
                    status = _goodsSetDB.SearchGoodsSet(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsSetArrList, out retMessage);
                    retCSAList.Add(goodsSetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && partsSubstUInt != 0)
                {
                    // 部品代替マスタ（ユーザー登録分）データ抽出
                    ArrayList partsSubstUArrList = new ArrayList();
                    DCPartsSubstUDB _partsSubstUDB = new DCPartsSubstUDB();
                    status = _partsSubstUDB.SearchPartsSubstU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out partsSubstUArrList, out retMessage);
                    retCSAList.Add(partsSubstUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && empSalesTargetInt != 0)
                {
                    // 従業員別売上目標設定マスタデータ抽出
                    ArrayList empSalesTargetArrList = new ArrayList();
                    DCEmpSalesTargetDB _empSalesTargetDB = new DCEmpSalesTargetDB();
                    status = _empSalesTargetDB.SearchEmpSalesTarget(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out empSalesTargetArrList, out retMessage);
                    retCSAList.Add(empSalesTargetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && custSalesTargetInt != 0)
                {
                    // 得意先別売上目標設定マスタデータ抽出
                    ArrayList custSalesTargetArrList = new ArrayList();
                    DCCustSalesTargetDB _custSalesTargetDB = new DCCustSalesTargetDB();
                    status = _custSalesTargetDB.SearchCustSalesTarget(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out custSalesTargetArrList, out retMessage);
                    retCSAList.Add(custSalesTargetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && gcdSalesTargetInt != 0)
                {
                    // 商品別売上目標設定マスタデータ抽出
                    ArrayList gcdSalesTargetArrList = new ArrayList();
                    DCGcdSalesTargetDB _gcdSalesTargetDB = new DCGcdSalesTargetDB();
                    status = _gcdSalesTargetDB.SearchGcdSalesTarget(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out gcdSalesTargetArrList, out retMessage);
                    retCSAList.Add(gcdSalesTargetArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsMGroupUInt != 0)
                {
                    // 商品中分類マスタ（ユーザー登録分）データ抽出
                    ArrayList goodsGroupUArrList = new ArrayList();
                    DCGoodsGroupUDB _goodsGroupUDB = new DCGoodsGroupUDB();
                    status = _goodsGroupUDB.SearchGoodsGroupU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out goodsGroupUArrList, out retMessage);
                    retCSAList.Add(goodsGroupUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && bLGroupUInt != 0)
                {
                    // BLグループマスタ（ユーザー登録分）データ抽出
                    ArrayList bLGroupUArrList = new ArrayList();
                    DCBLGroupUDB _bLGroupUDB = new DCBLGroupUDB();
                    status = _bLGroupUDB.SearchBLGroupU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out bLGroupUArrList, out retMessage);
                    retCSAList.Add(bLGroupUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && joinPartsUInt != 0)
                {
                    // 結合マスタ（ユーザー登録分）データ抽出
                    ArrayList joinPartsUArrList = new ArrayList();
                    DCJoinPartsUDB _joinPartsUDB = new DCJoinPartsUDB();
                    status = _joinPartsUDB.SearchJoinPartsU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out joinPartsUArrList, out retMessage);
                    retCSAList.Add(joinPartsUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && tBOSearchUCountInt != 0)
                {
                    // TBO検索マスタ（ユーザー登録）データ抽出
                    ArrayList tBOSearchUArrList = new ArrayList();
                    DCTBOSearchUDB _tBOSearchUDB = new DCTBOSearchUDB();
                    status = _tBOSearchUDB.SearchTBOSearchU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out tBOSearchUArrList, out retMessage);
                    retCSAList.Add(tBOSearchUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && partsPosCodeUInt != 0)
                {
                    // 部位コードマスタ（ユーザー登録）データ抽出
                    ArrayList partsPosCodeUArrList = new ArrayList();
                    DCPartsPosCodeUDB _partsPosCodeUDB = new DCPartsPosCodeUDB();
                    status = _partsPosCodeUDB.SearchPartsPosCodeU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out partsPosCodeUArrList, out retMessage);
                    retCSAList.Add(partsPosCodeUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && bLCodeGuideInt != 0)
                {
                    // BLコードガイドマスタデータ抽出
                    ArrayList bLCodeGuideArrList = new ArrayList();
                    DCBLCodeGuideDB _bLCodeGuideDB = new DCBLCodeGuideDB();
                    status = _bLCodeGuideDB.SearchBLCodeGuide(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out bLCodeGuideArrList, out retMessage);
                    retCSAList.Add(bLCodeGuideArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && modelNameUInt != 0)
                {
                    // 部門マスタデータ抽出
                    ArrayList modelNameUArrList = new ArrayList();
                    DCModelNameUDB _modelNameUDB = new DCModelNameUDB();
                    status = _modelNameUDB.SearchModelNameU(pmEnterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out modelNameUArrList, out retMessage);
                    retCSAList.Add(modelNameUArrList);
                }
            }
            catch (Exception ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "MstDCControlDB.SearchCustomSerializeArrayList Exception=" + ex.Message);
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
            // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// 処理終了日付を取得する。
            //DateTime endCurrentTime = new DateTime();
            //endCurrentTime = DateTime.Now;
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<

            ArrayList sndRcvHisResWorkList = new ArrayList();

            SndRcvHisTableWork sndRcvHisTableWork = new SndRcvHisTableWork();

            if (masterDivList.Count > 0)
            {
                // 企業コード
                //sndRcvHisTableWork.EnterpriseCode = ((DCSecMngSndRcvWork)masterDivList[0]).EnterpriseCode;//DEL 2012/10/16 李亜博 for redmine#31026
                sndRcvHisTableWork.EnterpriseCode = pmEnterpriseCodes;//ADD 2012/10/16 李亜博 for redmine#31026
                // 拠点コード
                sndRcvHisTableWork.SectionCode = ((DCSecMngSndRcvWork)masterDivList[0]).SectionCode;
                //送受信履歴ログ送信番号
                sndRcvHisTableWork.SndRcvHisConsNo = ((DCSecMngSndRcvWork)masterDivList[0]).SndRcvHisConsNo;
                // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                //// 送受信区分
                //sndRcvHisTableWork.SendOrReceiveDivCd = 1;
                // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                // 送受信区分:受信処理（終了）
                sndRcvHisTableWork.SendOrReceiveDivCd = 4;
                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                // 送受信日時
                //sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));//DEL 2012/10/16 李亜博 for redmine#31026
                sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));//ADD 2012/10/16 李亜博 for redmine#31026
                // 種別
                sndRcvHisTableWork.Kind = 1;
                // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                //// 送受信ログ抽出条件区分
                //sndRcvHisTableWork.SndLogExtraCondDiv = ((DCSecMngSndRcvWork)masterDivList[0]).SndLogExtraCondDiv;
                //// 処理開始日時
                //sndRcvHisTableWork.ProcStartDateTime = startCurrentTime.Ticks;
                //// 処理終了日時
                //sndRcvHisTableWork.ProcEndDateTime = endCurrentTime.Ticks;
                // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                // 送受信ログ抽出条件区分
                sndRcvHisTableWork.SndLogExtraCondDiv = 0;
                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                // 送信先企業コード
                //sndRcvHisTableWork.SendDestEpCode = ((DCSecMngSndRcvWork)masterDivList[0]).SendDestEpCode;//DEL 2012/10/16 李亜博 for redmine#31026
                sndRcvHisTableWork.SendDestEpCode = ((DCSecMngSndRcvWork)masterDivList[0]).EnterpriseCode;//ADD 2012/10/16 李亜博 for redmine#31026
                // 送信先拠点コード
                sndRcvHisTableWork.SendDestSecCode = ((DCSecMngSndRcvWork)masterDivList[0]).SendDestSecCode;
                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                //送信対象開始日時
                sndRcvHisTableWork.SndObjStartDate = beginningDate;
                //送信対象終了日時
                sndRcvHisTableWork.SndObjEndDate = endingDate;
                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                // 送受信状態
                if (status == 0)
                {   // DC更新成功の場合
                    sndRcvHisTableWork.SndRcvCondition = 0;
                }
                else
                {   // DC更新失敗の場合
                    sndRcvHisTableWork.SndRcvCondition = 1;
                }
                // 仮受信区分
                if (((DCSecMngSndRcvWork)masterDivList[0]).TempReceiveDiv == 2)
                {   // 仮受信の場合
                    sndRcvHisTableWork.TempReceiveDiv = 2;
                }
                else
                {   // 受信の場合
                    sndRcvHisTableWork.TempReceiveDiv = 1;
                }
                // エラー内容
                sndRcvHisTableWork.SndRcvErrContents = retMessage;
                // 送受信ファイルＩＤ
                sndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;
                sndRcvHisResWorkList.Add(sndRcvHisTableWork);
            }
            
            SndRcvHisTableDB sndRcvHisResDB = new SndRcvHisTableDB();
            object objSndRcvHisResWorkList = sndRcvHisResWorkList as object;
            sndRcvHisResDB.Write(ref objSndRcvHisResWorkList);
            // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
            return status;
        }

        # endregion ■ マスタ受信のデータ検索処理 ■

        #region ■ マスタ送信の更新処理 ■
        /// <summary>
        /// DCコントロールリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先メモ情報の追加</br>
        /// </remarks>
        public int Update(ref CustomSerializeArrayList retCSAList, string enterpriseCode, out string retMessage)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // add 2012/09/05 >>>
            // 念の為APロック用のステータスを用意する。
            int status2 = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // add 2012/09/05 <<<
            retMessage = string.Empty;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            string resNm = "";

            // private field
            DCSecInfoSetDB _secInfoSetDB = new DCSecInfoSetDB();
            DCSecInfoSetWork secInfoSetWork = new DCSecInfoSetWork();
            DCSubSectionDB _subSectionDB = new DCSubSectionDB();
            DCSubSectionWork subSectionWork = new DCSubSectionWork();
            DCEmployeeDB _employeeDB = new DCEmployeeDB();
            DCEmployeeWork employeeWork = new DCEmployeeWork();
            DCEmployeeDtlDB _employeeDtlDB = new DCEmployeeDtlDB();
            DCEmployeeDtlWork employeeDtlWork = new DCEmployeeDtlWork();
            DCWarehouseDB _warehouseDB = new DCWarehouseDB();
            DCWarehouseWork warehouseWork = new DCWarehouseWork();
            DCCustomerDB _customerWorkDB = new DCCustomerDB();
            DCCustomerWork customerWork = new DCCustomerWork();
            DCCustomerChangeDB _customerChangeDB = new DCCustomerChangeDB();
            DCCustomerChangeWork customerChangeWork = new DCCustomerChangeWork();
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            DCCustomerMemoDB _customerMemoDB = new DCCustomerMemoDB();
            DCCustomerMemoWork customerMemoWork = new DCCustomerMemoWork();
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
            DCCustSlipMngDB _custSlipMngDB = new DCCustSlipMngDB();
            DCCustSlipMngWork custSlipMngWork = new DCCustSlipMngWork();
            DCCustRateGroupDB _custRateGroupDB = new DCCustRateGroupDB();
            DCCustRateGroupWork custRateGroupWork = new DCCustRateGroupWork();
            DCCustSlipNoSetDB _custSlipNoSetDB = new DCCustSlipNoSetDB();
            DCCustSlipNoSetWork custSlipNoSetWork = new DCCustSlipNoSetWork();
            DCSupplierDB _supplierDB = new DCSupplierDB();
            DCSupplierWork supplierWork = new DCSupplierWork();
            DCMakerUDB _makerUWorkDB = new DCMakerUDB();
            DCMakerUWork makerUWork = new DCMakerUWork();
            DCBLGoodsCdUDB _bLGoodsCdUWorkDB = new DCBLGoodsCdUDB();
            DCBLGoodsCdUWork bLGoodsCdUWork = new DCBLGoodsCdUWork();
            DCGoodsUDB _goodsUDB = new DCGoodsUDB();
            DCGoodsUWork goodsUWork = new DCGoodsUWork();
            DCGoodsPriceUDB _goodsPriceUDB = new DCGoodsPriceUDB();
            DCGoodsPriceUWork goodsPriceUWork = new DCGoodsPriceUWork();
            DCGoodsMngDB _goodsMngDB = new DCGoodsMngDB();
            DCGoodsMngWork goodsMngWork = new DCGoodsMngWork();
            DCIsolIslandPrcDB _isolIslandPrcDB = new DCIsolIslandPrcDB();
            DCIsolIslandPrcWork isolIslandPrcWork = new DCIsolIslandPrcWork();
            DCStockDB _stockDB = new DCStockDB();
            DCStockWork stockWork = new DCStockWork();
            DCUserGdBdUDB _userGdBdUDB = new DCUserGdBdUDB();
            DCUserGdBdUWork userGdBdUWork = new DCUserGdBdUWork();
            DCRateProtyMngDB _rateProtyMngDB = new DCRateProtyMngDB();
            DCRateProtyMngWork rateProtyMngWork = new DCRateProtyMngWork();
            DCRateDB _rateDB = new DCRateDB();
            DCRateWork rateWork = new DCRateWork();
            DCGoodsSetDB _goodsSetDB = new DCGoodsSetDB();
            DCGoodsSetWork goodsSetWork = new DCGoodsSetWork();
            DCPartsSubstUDB _partsSubstUDB = new DCPartsSubstUDB();
            DCPartsSubstUWork partsSubstUWork = new DCPartsSubstUWork();
            DCEmpSalesTargetDB _empSalesTargetDB = new DCEmpSalesTargetDB();
            DCEmpSalesTargetWork empSalesTargetWork = new DCEmpSalesTargetWork();
            DCCustSalesTargetDB _custSalesTargetDB = new DCCustSalesTargetDB();
            DCCustSalesTargetWork custSalesTargetWork = new DCCustSalesTargetWork();
            DCGcdSalesTargetDB _gcdSalesTargetDB = new DCGcdSalesTargetDB();
            DCGcdSalesTargetWork gcdSalesTargetWork = new DCGcdSalesTargetWork();
            DCGoodsGroupUDB _goodsGroupUDB = new DCGoodsGroupUDB();
            DCGoodsGroupUWork goodsGroupUWork = new DCGoodsGroupUWork();
            DCBLGroupUDB _bLGroupUDB = new DCBLGroupUDB();
            DCBLGroupUWork bLGroupUWork = new DCBLGroupUWork();
            DCJoinPartsUDB _joinPartsUDB = new DCJoinPartsUDB();
            DCJoinPartsUWork joinPartsUWork = new DCJoinPartsUWork();
            DCTBOSearchUDB _tBOSearchUDB = new DCTBOSearchUDB();
            DCTBOSearchUWork tBOSearchUWork = new DCTBOSearchUWork();
            DCPartsPosCodeUDB _partsPosCodeUDB = new DCPartsPosCodeUDB();
            DCPartsPosCodeUWork partsPosCodeUWork = new DCPartsPosCodeUWork();
            DCBLCodeGuideDB _bLCodeGuideDB = new DCBLCodeGuideDB();
            DCBLCodeGuideWork bLCodeGuideWork = new DCBLCodeGuideWork();
            DCModelNameUDB _modelNameUDB = new DCModelNameUDB();
            DCModelNameUWork modelNameUWork = new DCModelNameUWork();

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
                // del 2012/09/05 >>>
                //// MOD 2009/07/06 --->>>
                ////ＡＰロック
                //status = Lock(resNm, 1, sqlConnection, sqlTransaction);
                //// MOD 2009/07/06 ---<<<

                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    return status;
                //}
                // del 2012/09/05 <<<
                // add 2012/09/05 >>>
                //ＡＰロック
                status2 = Lock(resNm, 1, sqlConnection, sqlTransaction);

                if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status2;
                }
                status2 = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                // add 2012/09/05 <<<

                for (int i = 0; i < retCSAList.Count; i++)
                {
                    ArrayList retCSATemList = (ArrayList)retCSAList[i];
                    for (int j = 0; j < retCSATemList.Count; j++)
                    {
                        Type wktype = retCSATemList[j].GetType();

                        // DC拠点情報設定マスタ更新処理
                        if (wktype.Equals(typeof(DCSecInfoSetWork)))
                        {
                            _secInfoSetDB = new DCSecInfoSetDB();
                            secInfoSetWork = (DCSecInfoSetWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _secInfoSetDB.Delete(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _secInfoSetDB.Insert(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                        }
                        // DC部門マスタ更新処理
                        else if (wktype.Equals(typeof(DCSubSectionWork)))
                        {
                            _subSectionDB = new DCSubSectionDB();
                            subSectionWork = (DCSubSectionWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _subSectionDB.Delete(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _subSectionDB.Insert(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC従業員マスタ更新処理
                        else if (wktype.Equals(typeof(DCEmployeeWork)))
                        {
                            _employeeDB = new DCEmployeeDB();
                            employeeWork = (DCEmployeeWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _employeeDB.Delete(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _employeeDB.Insert(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC従業員詳細マスタ更新処理
                        else if (wktype.Equals(typeof(DCEmployeeDtlWork)))
                        {
                            _employeeDtlDB = new DCEmployeeDtlDB();
                            employeeDtlWork = (DCEmployeeDtlWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _employeeDtlDB.Delete(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _employeeDtlDB.Insert(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC倉庫マスタ更新処理
                        else if (wktype.Equals(typeof(DCWarehouseWork)))
                        {
                            _warehouseDB = new DCWarehouseDB();
                            warehouseWork = (DCWarehouseWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _warehouseDB.Delete(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _warehouseDB.Insert(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC得意先マスタ更新処理
                        else if (wktype.Equals(typeof(DCCustomerWork)))
                        {
                            _customerWorkDB = new DCCustomerDB();
                            customerWork = (DCCustomerWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _customerWorkDB.Delete(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _customerWorkDB.Insert(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC得意先マスタ(変動情報)更新処理
                        else if (wktype.Equals(typeof(DCCustomerChangeWork)))
                        {
                            _customerChangeDB = new DCCustomerChangeDB();
                            customerChangeWork = (DCCustomerChangeWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _customerChangeDB.Delete(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _customerChangeDB.Insert(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                        // DC得意先マスタ(メモ情報)更新処理
                        else if (wktype.Equals(typeof(DCCustomerMemoWork)))
                        {
                            _customerMemoDB = new DCCustomerMemoDB();
                            customerMemoWork = (DCCustomerMemoWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _customerMemoDB.Delete(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _customerMemoDB.Insert(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                        // DC得意先マスタ（伝票管理）更新処理
                        else if (wktype.Equals(typeof(DCCustSlipMngWork)))
                        {
                            _custSlipMngDB = new DCCustSlipMngDB();
                            custSlipMngWork = (DCCustSlipMngWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _custSlipMngDB.Delete(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _custSlipMngDB.Insert(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC得意先マスタ（掛率グループ）更新処理
                        else if (wktype.Equals(typeof(DCCustRateGroupWork)))
                        {

                            custRateGroupWork = (DCCustRateGroupWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_custRateGroupDB.Delete(custRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_custRateGroupDB.Insert(custRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 売上データ
                            _custRateGroupList.Add(custRateGroupWork);
                        }
                        // DC得意先マスタ(伝票番号)更新処理
                        else if (wktype.Equals(typeof(DCCustSlipNoSetWork)))
                        {
                            _custSlipNoSetDB = new DCCustSlipNoSetDB();
                            custSlipNoSetWork = (DCCustSlipNoSetWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _custSlipNoSetDB.Delete(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _custSlipNoSetDB.Insert(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC仕入先マスタ更新処理
                        else if (wktype.Equals(typeof(DCSupplierWork)))
                        {
                            _supplierDB = new DCSupplierDB();
                            supplierWork = (DCSupplierWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _supplierDB.Delete(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _supplierDB.Insert(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DCメーカーマスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCMakerUWork)))
                        {
                            _makerUWorkDB = new DCMakerUDB();
                            makerUWork = (DCMakerUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _makerUWorkDB.Delete(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _makerUWorkDB.Insert(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DCBL商品コードマスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCBLGoodsCdUWork)))
                        {
                            _bLGoodsCdUWorkDB = new DCBLGoodsCdUDB();
                            bLGoodsCdUWork = (DCBLGoodsCdUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _bLGoodsCdUWorkDB.Delete(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _bLGoodsCdUWorkDB.Insert(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC商品マスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCGoodsUWork)))
                        {
                            _goodsUDB = new DCGoodsUDB();
                            goodsUWork = (DCGoodsUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _goodsUDB.Delete(goodsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _goodsUDB.Insert(goodsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC価格マスタ（ユーザー登録）更新処理
                        else if (wktype.Equals(typeof(DCGoodsPriceUWork)))
                        {
                            goodsPriceUWork = (DCGoodsPriceUWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_goodsPriceUDB.Delete(goodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_goodsPriceUDB.Insert(goodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _goodsPriceUList.Add(goodsPriceUWork);
                        }
                        // DC商品管理情報マスタ更新処理
                        else if (wktype.Equals(typeof(DCGoodsMngWork)))
                        {
                            _goodsMngDB = new DCGoodsMngDB();
                            goodsMngWork = (DCGoodsMngWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _goodsMngDB.Delete(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _goodsMngDB.Insert(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC離島価格マスタ更新処理
                        else if (wktype.Equals(typeof(DCIsolIslandPrcWork)))
                        {
                            _isolIslandPrcDB = new DCIsolIslandPrcDB();
                            isolIslandPrcWork = (DCIsolIslandPrcWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _isolIslandPrcDB.Delete(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _isolIslandPrcDB.Insert(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC在庫マスタ更新処理
                        else if (wktype.Equals(typeof(DCStockWork)))
                        {
                            _stockDB = new DCStockDB();
                            stockWork = (DCStockWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _stockDB.Delete(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _stockDB.Insert(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DCユーザーガイドマスタ更新処理
                        else if (wktype.Equals(typeof(DCUserGdBdUWork)))
                        {
                            _userGdBdUDB = new DCUserGdBdUDB();
                            userGdBdUWork = (DCUserGdBdUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC掛率優先管理マスタ更新処理
                        else if (wktype.Equals(typeof(DCRateProtyMngWork)))
                        {
                            rateProtyMngWork = (DCRateProtyMngWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_rateProtyMngDB.Delete(rateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_rateProtyMngDB.Insert(rateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _rateProtyMngList.Add(rateProtyMngWork);
                        }
                        // DC掛率マスタ更新処理
                        else if (wktype.Equals(typeof(DCRateWork)))
                        {
                            rateWork = (DCRateWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_rateDB.Delete(rateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_rateDB.Insert(rateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _rateList.Add(rateWork);
                        }
                        // DC商品セットマスタ更新処理
                        else if (wktype.Equals(typeof(DCGoodsSetWork)))
                        {
                            goodsSetWork = (DCGoodsSetWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_goodsSetDB.Delete(goodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_goodsSetDB.Insert(goodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _goodsSetList.Add(goodsSetWork);
                        }
                        // DC部品代替マスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCPartsSubstUWork)))
                        {
                            _partsSubstUDB = new DCPartsSubstUDB();
                            partsSubstUWork = (DCPartsSubstUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _partsSubstUDB.Delete(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _partsSubstUDB.Insert(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC従業員別売上目標設定マスタ更新処理
                        else if (wktype.Equals(typeof(DCEmpSalesTargetWork)))
                        {
                            _empSalesTargetDB = new DCEmpSalesTargetDB();
                            empSalesTargetWork = (DCEmpSalesTargetWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _empSalesTargetDB.Delete(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _empSalesTargetDB.Insert(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC得意先別売上目標設定マスタ更新処理
                        else if (wktype.Equals(typeof(DCCustSalesTargetWork)))
                        {
                            _custSalesTargetDB = new DCCustSalesTargetDB();
                            custSalesTargetWork = (DCCustSalesTargetWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _custSalesTargetDB.Delete(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _custSalesTargetDB.Insert(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC商品別売上目標設定マスタ更新処理
                        else if (wktype.Equals(typeof(DCGcdSalesTargetWork)))
                        {
                            _gcdSalesTargetDB = new DCGcdSalesTargetDB();
                            gcdSalesTargetWork = (DCGcdSalesTargetWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _gcdSalesTargetDB.Delete(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _gcdSalesTargetDB.Insert(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC商品中分類マスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCGoodsGroupUWork)))
                        {
                            _goodsGroupUDB = new DCGoodsGroupUDB();
                            goodsGroupUWork = (DCGoodsGroupUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _goodsGroupUDB.Delete(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _goodsGroupUDB.Insert(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DCBLグループマスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCBLGroupUWork)))
                        {
                            _bLGroupUDB = new DCBLGroupUDB();
                            bLGroupUWork = (DCBLGroupUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _bLGroupUDB.Delete(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _bLGroupUDB.Insert(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC結合マスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCJoinPartsUWork)))
                        {
                            joinPartsUWork = (DCJoinPartsUWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_joinPartsUDB.Delete(joinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_joinPartsUDB.Insert(joinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _joinPartsUList.Add(joinPartsUWork);
                        }
                        // DCTBO検索マスタ（ユーザー登録）更新処理
                        else if (wktype.Equals(typeof(DCTBOSearchUWork)))
                        {
                            tBOSearchUWork = (DCTBOSearchUWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_tBOSearchUDB.Delete(tBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_tBOSearchUDB.Insert(tBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _tboSearchUList.Add(tBOSearchUWork);
                        }
                        // DC部位コードマスタ（ユーザー登録）更新処理
                        else if (wktype.Equals(typeof(DCPartsPosCodeUWork)))
                        {
                            partsPosCodeUWork = (DCPartsPosCodeUWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_partsPosCodeUDB.Delete(partsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_partsPosCodeUDB.Insert(partsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _partsPosCodeUList.Add(partsPosCodeUWork);
                        }
                        // DCBLコードガイドマスタ更新処理
                        else if (wktype.Equals(typeof(DCBLCodeGuideWork)))
                        {
                            bLCodeGuideWork = (DCBLCodeGuideWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_bLCodeGuideDB.Delete(bLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_bLCodeGuideDB.Insert(bLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _blCodeGuideList.Add(bLCodeGuideWork);
                        }
                        // DC車種名称マスタ更新処理
                        else if (wktype.Equals(typeof(DCModelNameUWork)))
                        {
                            _modelNameUDB = new DCModelNameUDB();
                            modelNameUWork = (DCModelNameUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _modelNameUDB.Delete(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _modelNameUDB.Insert(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                    }
                }
                // ADD 2009/06/09 --->>>
                // 得意先マスタ（掛率グループ）
                if (_custRateGroupList != null && _custRateGroupList.Count > 0)
                {
                    _custRateGroupDB = new DCCustRateGroupDB();
                    // 削除
                    foreach (DCCustRateGroupWork dcCustRateGroupWork in _custRateGroupList)
                    {
                        _custRateGroupDB.Delete(dcCustRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCCustRateGroupWork dcCustRateGroupWork in _custRateGroupList)
                    {
                        _custRateGroupDB.Insert(dcCustRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // 価格マスタ（ユーザー登録）
                if (_goodsPriceUList != null && _goodsPriceUList.Count > 0)
                {
                    _goodsPriceUDB = new DCGoodsPriceUDB();
                    // 削除
                    foreach (DCGoodsPriceUWork dcGoodsPriceUWork in _goodsPriceUList)
                    {
                        _goodsPriceUDB.Delete(dcGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCGoodsPriceUWork dcGoodsPriceUWork in _goodsPriceUList)
                    {
                        _goodsPriceUDB.Insert(dcGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // 掛率優先管理マスタ
                if (_rateProtyMngList != null && _rateProtyMngList.Count > 0)
                {
                    _rateProtyMngDB = new DCRateProtyMngDB();
                    // 削除
                    foreach (DCRateProtyMngWork dcRateProtyMngWork in _rateProtyMngList)
                    {
                        _rateProtyMngDB.Delete(dcRateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCRateProtyMngWork dcRateProtyMngWork in _rateProtyMngList)
                    {
                        _rateProtyMngDB.Insert(dcRateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // 掛率マスタ
                if (_rateList != null && _rateList.Count > 0)
                {
                    _rateDB = new DCRateDB();
                    // 削除
                    foreach (DCRateWork dcRateWork in _rateList)
                    {
                        _rateDB.Delete(dcRateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCRateWork dcRateWork in _rateList)
                    {
                        _rateDB.Insert(dcRateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // 商品セットマスタ
                if (_goodsSetList != null && _goodsSetList.Count > 0)
                {
                    _goodsSetDB = new DCGoodsSetDB();
                    // 削除
                    foreach (DCGoodsSetWork dcGoodsSetWork in _goodsSetList)
                    {
                        _goodsSetDB.Delete(dcGoodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCGoodsSetWork dcGoodsSetWork in _goodsSetList)
                    {
                        _goodsSetDB.Insert(dcGoodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // 結合マスタ（ユーザー登録分）
                if (_joinPartsUList != null && _joinPartsUList.Count > 0)
                {
                    _joinPartsUDB = new DCJoinPartsUDB();
                    // 削除
                    foreach (DCJoinPartsUWork dcJoinPartsUWork in _joinPartsUList)
                    {
                        _joinPartsUDB.Delete(dcJoinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCJoinPartsUWork dcJoinPartsUWork in _joinPartsUList)
                    {
                        _joinPartsUDB.Insert(dcJoinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // TBO検索合マスタ（ユーザー登録分）
                if (_tboSearchUList != null && _tboSearchUList.Count > 0)
                {
                    _tBOSearchUDB = new DCTBOSearchUDB();
                    // 削除
                    foreach (DCTBOSearchUWork dcTBOSearchUWork in _tboSearchUList)
                    {
                        _tBOSearchUDB.Delete(dcTBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCTBOSearchUWork dcTBOSearchUWork in _tboSearchUList)
                    {
                        _tBOSearchUDB.Insert(dcTBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // 部位コードマスタ（ユーザー登録）
                if (_partsPosCodeUList != null && _partsPosCodeUList.Count > 0)
                {
                    _partsPosCodeUDB = new DCPartsPosCodeUDB();
                    // 削除
                    foreach (DCPartsPosCodeUWork dcPartsPosCodeUWork in _partsPosCodeUList)
                    {
                        _partsPosCodeUDB.Delete(dcPartsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCPartsPosCodeUWork dcPartsPosCodeUWork in _partsPosCodeUList)
                    {
                        _partsPosCodeUDB.Insert(dcPartsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // BLコードガイドマスタ
                if (_blCodeGuideList != null && _blCodeGuideList.Count > 0)
                {
                    _bLCodeGuideDB = new DCBLCodeGuideDB();
                    // 削除
                    foreach (DCBLCodeGuideWork dcBLCodeGuideWork in _blCodeGuideList)
                    {
                        _bLCodeGuideDB.Delete(dcBLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCBLCodeGuideWork dcBLCodeGuideWork in _blCodeGuideList)
                    {
                        _bLCodeGuideDB.Insert(dcBLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // ADD 2009/06/09 ---<<<

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "MstDCControlDB.Update SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "MstDCControlDB.Update Exception=" + e.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // upd 2012/09/05 >>>
                //if (resNm != "")
                if (resNm != "" && status2 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                // upd 2012/09/05 <<<
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

        # region ■ [コネクション生成処理] ■
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlConnection CreateSqlConnectionData(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);

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
        /// <br>Programmer : 劉洋</br>
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
        # endregion

        #region ADD 2011/07/26 孫東響  SCM対応-拠点管理（10704767-00）
        # region ■ マスタ受信のデータ検索処理 ■
        /// <summary>
        /// マスタ受信のデータ検索処理
        /// </summary>
        /// <param name="masterDivList">マスタ区分</param>
        /// <param name="pmEnterpriseCodes">PM企業コード</param>
        /// <param name="paramList">マスタ抽出条件クラス</param>
        /// <param name="retCSAList">更新データ</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ送信処理READの実データ検索を行うクラスです。</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.07.26</br>
        /// <br>Update Note : 2012/07/26 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 10801804-00、Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        public int SearchCustomSerializeArrayList(ArrayList masterDivList, string pmEnterpriseCodes, ArrayList paramList, ref CustomSerializeArrayList retCSAList, out string retMessage)
        {
            // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// 処理開始日時を取得する。
            //DateTime startCurrentTime = new DateTime();
            //startCurrentTime = DateTime.Now;
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<

            string tempSndRcvFileID = string.Empty;
            Dictionary<string, string> tempSndRcvDic = new Dictionary<string, string>();
            // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMessage = string.Empty;
            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            ArrayList tempSndRcvHisResWorkList = new ArrayList();

            SndRcvHisTableWork tempSndRcvHisTableWork = new SndRcvHisTableWork();

            if (masterDivList.Count > 0)
            {
                // 企業コード
                tempSndRcvHisTableWork.EnterpriseCode = pmEnterpriseCodes;
                // 拠点コード
                tempSndRcvHisTableWork.SectionCode = ((DCSecMngSndRcvWork)masterDivList[0]).SectionCode;
                //送受信履歴ログ送信番号
                tempSndRcvHisTableWork.SndRcvHisConsNo = ((DCSecMngSndRcvWork)masterDivList[0]).SndRcvHisConsNo;
                // 送受信区分:受信処理（開始）
                tempSndRcvHisTableWork.SendOrReceiveDivCd = 3;
                // 送受信日時
                tempSndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
                // 種別
                tempSndRcvHisTableWork.Kind = 1;
                // 送受信ログ抽出条件区分
                tempSndRcvHisTableWork.SndLogExtraCondDiv = 1;
                // 送信先企業コード
                tempSndRcvHisTableWork.SendDestEpCode = ((DCSecMngSndRcvWork)masterDivList[0]).EnterpriseCode;
                // 送信先拠点コード
                tempSndRcvHisTableWork.SendDestSecCode = ((DCSecMngSndRcvWork)masterDivList[0]).SendDestSecCode;

                for (int i=0;i< paramList.Count;i++)
                {
                    if (paramList[i].GetType() == typeof(CustomerProcParamWork))
                    {
                        CustomerProcParamWork customerProcParamWork = (CustomerProcParamWork)paramList[i];
                        //送信対象開始日時
                        tempSndRcvHisTableWork.SndObjStartDate = customerProcParamWork.UpdateDateTimeBegin;
                        //送信対象終了日時
                        tempSndRcvHisTableWork.SndObjEndDate = customerProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    else if (paramList[i].GetType() == typeof(GoodsProcParamWork))
                    {
                        GoodsProcParamWork goodsProcParamWork = (GoodsProcParamWork)paramList[i];
                        //送信対象開始日時
                        tempSndRcvHisTableWork.SndObjStartDate = goodsProcParamWork.UpdateDateTimeBegin;
                        //送信対象終了日時
                        tempSndRcvHisTableWork.SndObjEndDate = goodsProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    else if (paramList[i].GetType() == typeof(StockProcParamWork))
                    {
                        StockProcParamWork stockProcParamWork = (StockProcParamWork)paramList[i];
                        //送信対象開始日時
                        tempSndRcvHisTableWork.SndObjStartDate = stockProcParamWork.UpdateDateTimeBegin;
                        //送信対象終了日時
                        tempSndRcvHisTableWork.SndObjEndDate = stockProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    else if (paramList[i].GetType() == typeof(SupplierProcParamWork))
                    {
                        SupplierProcParamWork supplierProcParamWork = (SupplierProcParamWork)paramList[i];
                        //送信対象開始日時
                        tempSndRcvHisTableWork.SndObjStartDate = supplierProcParamWork.UpdateDateTimeBegin;
                        //送信対象終了日時
                        tempSndRcvHisTableWork.SndObjEndDate = supplierProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    else if (paramList[i].GetType() == typeof(RateProcParamWork))
                    {
                        RateProcParamWork rateProcParamWork = (RateProcParamWork)paramList[i];
                        //送信対象開始日時
                        tempSndRcvHisTableWork.SndObjStartDate = rateProcParamWork.UpdateDateTimeBegin;
                        //送信対象終了日時
                        tempSndRcvHisTableWork.SndObjEndDate = rateProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    // --- ADD 2012/07/26 ------------------------------>>>>>
                	else if (paramList[i].GetType() == typeof(EmployeeProcParamWork))
                	{
                        EmployeeProcParamWork employeeProcParamWork = (EmployeeProcParamWork)paramList[i];
                        //送信対象開始日時
                        tempSndRcvHisTableWork.SndObjStartDate = employeeProcParamWork.UpdateDateTimeBegin;
                        //送信対象終了日時
                        tempSndRcvHisTableWork.SndObjEndDate = employeeProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                	else if (paramList[i].GetType() == typeof(JoinPartsUProcParamWork))
                	{
                        JoinPartsUProcParamWork joinPartsUProcParamWork = (JoinPartsUProcParamWork)paramList[i];
                        //送信対象開始日時
                        tempSndRcvHisTableWork.SndObjStartDate = joinPartsUProcParamWork.UpdateDateTimeBegin;
                        //送信対象終了日時
                        tempSndRcvHisTableWork.SndObjEndDate = joinPartsUProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                	else if (paramList[i].GetType() == typeof(UserGdBuyDivUProcParamWork))
                	{
                        UserGdBuyDivUProcParamWork userGdBuyDivUProcParamWork = (UserGdBuyDivUProcParamWork)paramList[i];
                        //送信対象開始日時
                        tempSndRcvHisTableWork.SndObjStartDate = userGdBuyDivUProcParamWork.UpdateDateTimeBegin;
                        //送信対象終了日時
                        tempSndRcvHisTableWork.SndObjEndDate = userGdBuyDivUProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    // --- ADD 2012/07/26 ------------------------------<<<<<
                }
                // 仮受信区分
                if (((DCSecMngSndRcvWork)masterDivList[0]).TempReceiveDiv == 2)
                {   // 仮受信の場合
                    tempSndRcvHisTableWork.TempReceiveDiv = 2;
                }
                else
                {   // 受信の場合
                    tempSndRcvHisTableWork.TempReceiveDiv = 1;
                }
                // エラー内容
                tempSndRcvHisTableWork.SndRcvErrContents = retMessage;
                // 送受信ファイルＩＤ
                tempSndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;
                tempSndRcvHisResWorkList.Add(tempSndRcvHisTableWork);
            }
            SndRcvHisTableDB tempSndRcvHisResDB = new SndRcvHisTableDB();
            object tempObjSndRcvHisResWorkList = tempSndRcvHisResWorkList as object;
            tempSndRcvHisResDB.Write(ref tempObjSndRcvHisResWorkList);
            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<

            //抽出条件クラス
            // --- ADD 2012/07/26 ------------------------------>>>>>
            EmployeeProcParamWork employeeProcParam = null;
            JoinPartsUProcParamWork joinPartsUProcParam = null;
            UserGdBuyDivUProcParamWork userGdBuyDivUProcParam = null;
            // --- ADD 2012/07/26 ------------------------------<<<<<
            CustomerProcParamWork customerProcParam = null;
            GoodsProcParamWork goodsProcParam = null;
            StockProcParamWork stockProcParam = null;
            SupplierProcParamWork supplierProcParam = null;
            RateProcParamWork rateProcParam = null;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();

                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                for(int i = 0; i< paramList.Count;i++)
                {
                    Type paramType = paramList[i].GetType();

                    // --- ADD 2012/07/26 ------------------------------------------->>>>>
                    if (paramType.Equals(typeof(EmployeeProcParamWork)))
                    {
                        employeeProcParam = (EmployeeProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(JoinPartsUProcParamWork)))
                    {
                        joinPartsUProcParam = (JoinPartsUProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(UserGdBuyDivUProcParamWork)))
                    {
                        userGdBuyDivUProcParam = (UserGdBuyDivUProcParamWork)paramList[i];
                    }
                    // --- ADD 2012/07/26 -------------------------------------------<<<<<
                    if (paramType.Equals(typeof(CustomerProcParamWork)))
                    {
                        customerProcParam = (CustomerProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(GoodsProcParamWork)))
                    {
                        goodsProcParam = (GoodsProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(StockProcParamWork)))
                    {
                        stockProcParam = (StockProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(SupplierProcParamWork)))
                    {
                        supplierProcParam = (SupplierProcParamWork)paramList[i];
                    }
                    if (paramType.Equals(typeof(RateProcParamWork)))
                    {
                        rateProcParam = (RateProcParamWork)paramList[i];
                    }                
                }

                retCSAList = new CustomSerializeArrayList();

                foreach (DCSecMngSndRcvWork secMngSndRcvWork in masterDivList)
                {
                    // --- ADD 2012/07/26 --------------------------------------------->>>>>
                    // 従業員マスタ
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        employeeInt = secMngSndRcvWork.SecMngRecvDiv;
                        
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                    }
                    // 従業員詳細マスタ
                    if (MST_EMPLOYEE.Equals(secMngSndRcvWork.MasterName) && MST_ID_EMPLOYEEDTL.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        employeeDtlInt = secMngSndRcvWork.SecMngRecvDiv;
                        
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                    }
                    // 結合マスタ（ユーザー登録分）
                    if (MST_JOINPARTSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_JOINPARTSU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        joinPartsUInt = secMngSndRcvWork.SecMngRecvDiv;
                        
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                    }
                    // ユーザーガイドマスタ（販売区分）
                    if (MST_USERGDBUYDIVU.Equals(secMngSndRcvWork.MasterName) && MST_ID_USERGDU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        userGdBuyDivUInt = secMngSndRcvWork.SecMngRecvDiv;
                        
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                    }
                    // --- ADD 2012/07/26 ---------------------------------------------<<<<<
                    // 得意先マスタ
                    if (MST_CUSTOME.Equals(secMngSndRcvWork.MasterName) && MST_ID_CUSTOME.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        customerInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 商品マスタ（ユーザー登録分）
                    if (MST_GOODSU.Equals(secMngSndRcvWork.MasterName) && MST_ID_GOODSU.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        goodsUInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 在庫マスタ
                    if (MST_STOCK.Equals(secMngSndRcvWork.MasterName) && MST_ID_STOCK.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        stockInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 仕入先マスタ
                    if (MST_SUPPLIER.Equals(secMngSndRcvWork.MasterName) && MST_ID_SUPPLIER.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        supplierInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                    // 掛率マスタ
                    if (MST_RATE.Equals(secMngSndRcvWork.MasterName) && MST_ID_RATE.Equals(secMngSndRcvWork.FileId)
                        && 0 != secMngSndRcvWork.SecMngRecvDiv)
                    {
                        rateInt = secMngSndRcvWork.SecMngRecvDiv;
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                        if (!tempSndRcvDic.ContainsKey(secMngSndRcvWork.FileId))
                        {
                            tempSndRcvDic.Add(secMngSndRcvWork.FileId, secMngSndRcvWork.FileId);
                        }
                        // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
                    }
                }

                // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
                foreach (KeyValuePair<string, string> tempFileId in tempSndRcvDic)
                {
                    if (string.IsNullOrEmpty(tempSndRcvFileID))
                    {
                        tempSndRcvFileID = tempSndRcvFileID + tempFileId.Key;
                    }
                    else
                    {
                        tempSndRcvFileID = tempSndRcvFileID + "," + tempFileId.Key;
                    }

                }
                // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<

                // --- ADD 2012/07/26 --------------------------------------------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeInt != 0 && employeeProcParam != null)
                {
                    // 従業員マスタデータ抽出
                    ArrayList employeeArrList = new ArrayList();
                    DCEmployeeDB _employeeDB = new DCEmployeeDB();
                    status = _employeeDB.SearchEmployee(pmEnterpriseCodes, employeeProcParam, sqlConnection, sqlTransaction, out employeeArrList, out retMessage);
                    retCSAList.Add(employeeArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeDtlInt != 0 && employeeProcParam != null)
                {
                    // 従業員詳細マスタデータ抽出
                    ArrayList employeeDtlArrList = new ArrayList();
                    DCEmployeeDtlDB _employeeDtlDB = new DCEmployeeDtlDB();
                    status = _employeeDtlDB.SearchEmployeeDtl(pmEnterpriseCodes, employeeProcParam, sqlConnection, sqlTransaction, out employeeDtlArrList, out retMessage);
                    retCSAList.Add(employeeDtlArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && joinPartsUInt != 0 && joinPartsUProcParam != null)
                {
                    // 結合マスタ（ユーザー登録分）データ抽出
                    ArrayList joinPartsUArrList = new ArrayList();
                    DCJoinPartsUDB _joinPartsUDB = new DCJoinPartsUDB();
                    status = _joinPartsUDB.SearchJoinPartsU(pmEnterpriseCodes, joinPartsUProcParam, sqlConnection, sqlTransaction, out joinPartsUArrList, out retMessage);
                    retCSAList.Add(joinPartsUArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && userGdBuyDivUInt != 0 && userGdBuyDivUProcParam != null)
                {
                    // ユーザーガイドマスタ（販売区分）データ抽出
                    ArrayList userGdBdUArrList = new ArrayList();
                    DCUserGdBdUDB _userGdBdUDB = new DCUserGdBdUDB();
                    status = _userGdBdUDB.SearchUserGdBdU(71, pmEnterpriseCodes, userGdBuyDivUProcParam, sqlConnection, sqlTransaction, out userGdBdUArrList, out retMessage);
                    retCSAList.Add(userGdBdUArrList);
                }
                // --- ADD 2012/07/26 ---------------------------------------------<<<<<
                if (customerInt != 0 && customerProcParam != null)
                {
                    //ADD 2011/08/25 #23798 条件送信で更新ボタン押下で処理が終了しない--------------------------------->>>>>
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 得意先マスタデータ抽出
                        ArrayList customerArrList = new ArrayList();
                        DCCustomerDB _customerDB = new DCCustomerDB();
                        status = _customerDB.SearchAllCustomer(pmEnterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out customerArrList, out retMessage);
                        for (int m = 0; m < customerArrList.Count; m++)
                        {
                            retCSAList.Add(customerArrList[m]);
                        }
                    }
                    //ADD 2011/08/25 #23798 条件送信で更新ボタン押下で処理が終了しない---------------------------------<<<<<
                    #region DEL 
                    //DEL 2011/08/25 #23798 条件送信で更新ボタン押下で処理が終了しない--------------------------------->>>>>
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // 得意先マスタデータ抽出
                    //    ArrayList customerArrList = new ArrayList();
                    //    DCCustomerDB _customerDB = new DCCustomerDB();
                    //    status = _customerDB.SearchCustomer(pmEnterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out customerArrList, out retMessage);
                    //    retCSAList.Add(customerArrList);
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // 得意先マスタ（掛率グループ）データ抽出
                    //    ArrayList custRateGroupArrList = new ArrayList();
                    //    DCCustRateGroupDB _custRateGroupDB = new DCCustRateGroupDB();
                    //    status = _custRateGroupDB.SearchCustRateGroup(pmEnterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out custRateGroupArrList, out retMessage);
                    //    retCSAList.Add(custRateGroupArrList);
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // 得意先マスタ(変動情報)データ抽出
                    //    ArrayList customerChangeArrList = new ArrayList();
                    //    DCCustomerChangeDB _customerChangeDB = new DCCustomerChangeDB();
                    //    status = _customerChangeDB.SearchCustomerChange(pmEnterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out customerChangeArrList, out retMessage);
                    //    retCSAList.Add(customerChangeArrList);
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // 得意先マスタ（伝票管理）データ抽出
                    //    ArrayList custSlipMngArrList = new ArrayList();
                    //    DCCustSlipMngDB _custSlipMngDB = new DCCustSlipMngDB();
                    //    status = _custSlipMngDB.SearchCustSlipMng(pmEnterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out custSlipMngArrList, out retMessage);
                    //    retCSAList.Add(custSlipMngArrList);
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // 得意先マスタ(伝票番号)データ抽出
                    //    ArrayList custSlipNoSetArrList = new ArrayList();
                    //    DCCustSlipNoSetDB _custSlipNoSetDB = new DCCustSlipNoSetDB();
                    //    status = _custSlipNoSetDB.SearchCustSlipNoSet(pmEnterpriseCodes, customerProcParam, sqlConnection, sqlTransaction, out custSlipNoSetArrList, out retMessage);
                    //    retCSAList.Add(custSlipNoSetArrList);
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
                        DCGoodsUDB _goodsUDB = new DCGoodsUDB();
                        status = _goodsUDB.SearchGoodsAll(pmEnterpriseCodes, goodsProcParam, sqlConnection, sqlTransaction, out goodsAllList, out retMessage);
                        for (int m = 0; m < goodsAllList.Count; m++)
                        {
                            retCSAList.Add(goodsAllList[m]);
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
                    //    DCGoodsUDB _goodsUDB = new DCGoodsUDB();
                    //    status = _goodsUDB.SearchGoodsU(pmEnterpriseCodes, goodsProcParam, sqlConnection, sqlTransaction, out goodsUArrList, out goodsMngArrList, out retMessage);
                    //    retCSAList.Add(goodsUArrList);
                    //}

                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // 価格マスタ（ユーザー登録）データ抽出
                    //    ArrayList goodsPriceUArrList = new ArrayList();
                    //    DCGoodsPriceUDB _goodsPriceUDB = new DCGoodsPriceUDB();
                    //    status = _goodsPriceUDB.SearchGoodsPriceU(pmEnterpriseCodes, goodsProcParam, sqlConnection, sqlTransaction, out goodsPriceUArrList, out retMessage);
                    //    retCSAList.Add(goodsPriceUArrList);
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    // 離島価格マスタデータ抽出
                    //    ArrayList isolIslandPrcArrList = new ArrayList();
                    //    DCIsolIslandPrcDB _isolIslandPrcDB = new DCIsolIslandPrcDB();
                    //    status = _isolIslandPrcDB.SearchIsolIslandPrc(pmEnterpriseCodes, goodsProcParam, sqlConnection, sqlTransaction, out isolIslandPrcArrList, out retMessage);
                    //    retCSAList.Add(isolIslandPrcArrList);
                    //}
                    //DEL 2011/08/25 #23798 条件送信で更新ボタン押下で処理が終了しない---------------------------------<<<<<
                    #endregion
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && stockInt != 0 && stockProcParam != null)
                {
                    // 在庫マスタデータ抽出
                    ArrayList stockArrList = new ArrayList();
                    DCStockDB _stockDB = new DCStockDB();
                    status = _stockDB.SearchStock(pmEnterpriseCodes, stockProcParam, sqlConnection, sqlTransaction, out stockArrList, out retMessage);
                    retCSAList.Add(stockArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplierInt != 0 && supplierProcParam != null)
                {
                    // 仕入先マスタデータ抽出
                    ArrayList supplierArrList = new ArrayList();
                    DCSupplierDB _supplierDB = new DCSupplierDB();
                    status = _supplierDB.SearchSupplier(pmEnterpriseCodes, supplierProcParam, sqlConnection, sqlTransaction, out supplierArrList, out retMessage);
                    retCSAList.Add(supplierArrList);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && rateInt != 0 && rateProcParam != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 掛率マスタデータ抽出
                        ArrayList rateArrList = new ArrayList();
                        DCRateDB _rateDB = new DCRateDB();
                        status = _rateDB.SearchRate(pmEnterpriseCodes, rateProcParam, sqlConnection, sqlTransaction, out rateArrList, out retMessage);
                        retCSAList.Add(rateArrList);
                    }                    
                }                
            }
            catch (Exception ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "MstDCControlDB.SearchCustomSerializeArrayList Exception=" + ex.Message);
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
            // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// 処理終了日付を取得する。
            //DateTime endCurrentTime = new DateTime();
            //endCurrentTime = DateTime.Now;
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<

            ArrayList sndRcvHisResWorkList = new ArrayList();

            SndRcvHisTableWork sndRcvHisTableWork = new SndRcvHisTableWork();

            if (masterDivList.Count > 0)
            {
                // 企業コード
                //sndRcvHisTableWork.EnterpriseCode = ((DCSecMngSndRcvWork)masterDivList[0]).EnterpriseCode;//DEL 2012/10/16 李亜博 for redmine#31026
                sndRcvHisTableWork.EnterpriseCode = pmEnterpriseCodes;//ADD 2012/10/16 李亜博 for redmine#31026
                // 拠点コード
                sndRcvHisTableWork.SectionCode = ((DCSecMngSndRcvWork)masterDivList[0]).SectionCode;
                //送受信履歴ログ送信番号
                sndRcvHisTableWork.SndRcvHisConsNo = ((DCSecMngSndRcvWork)masterDivList[0]).SndRcvHisConsNo;
                // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                //// 送受信区分
                //sndRcvHisTableWork.SendOrReceiveDivCd = 1;
                // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                // 送受信区分:受信処理（終了）
                sndRcvHisTableWork.SendOrReceiveDivCd = 4;
                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                // 送受信日時
                //sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));//DEL 2012/10/16 李亜博 for redmine#31026
                sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));//ADD 2012/10/16 李亜博 for redmine#31026
                // 種別
                sndRcvHisTableWork.Kind = 1;
                // 送受信ログ抽出条件区分
                //sndRcvHisTableWork.SndLogExtraCondDiv = ((DCSecMngSndRcvWork)masterDivList[0]).SndLogExtraCondDiv;//DEL 2012/10/16 李亜博 for redmine#31026
                sndRcvHisTableWork.SndLogExtraCondDiv = 1;//ADD 2012/10/16 李亜博 for redmine#31026
                // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                //// 処理開始日時
                //sndRcvHisTableWork.ProcStartDateTime = startCurrentTime.Ticks;
                //// 処理終了日時
                //sndRcvHisTableWork.ProcEndDateTime = endCurrentTime.Ticks;
                // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                // 送信先企業コード
                //sndRcvHisTableWork.SendDestEpCode = ((DCSecMngSndRcvWork)masterDivList[0]).SendDestEpCode;//DEL 2012/10/16 李亜博 for redmine#31026
                sndRcvHisTableWork.SendDestEpCode = ((DCSecMngSndRcvWork)masterDivList[0]).EnterpriseCode;//ADD 2012/10/16 李亜博 for redmine#31026
                // 送信先拠点コード
                sndRcvHisTableWork.SendDestSecCode = ((DCSecMngSndRcvWork)masterDivList[0]).SendDestSecCode;
                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                for (int i = 0; i < paramList.Count; i++)
                {
                    if (paramList[i].GetType() == typeof(CustomerProcParamWork))
                    {
                        CustomerProcParamWork customerProcParamWork = (CustomerProcParamWork)paramList[i];
                        //送信対象開始日時
                        sndRcvHisTableWork.SndObjStartDate = customerProcParamWork.UpdateDateTimeBegin;
                        //送信対象終了日時
                        sndRcvHisTableWork.SndObjEndDate = customerProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    else if (paramList[i].GetType() == typeof(GoodsProcParamWork))
                    {
                        GoodsProcParamWork goodsProcParamWork = (GoodsProcParamWork)paramList[i];
                        //送信対象開始日時
                        sndRcvHisTableWork.SndObjStartDate = goodsProcParamWork.UpdateDateTimeBegin;
                        //送信対象終了日時
                        sndRcvHisTableWork.SndObjEndDate = goodsProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    else if (paramList[i].GetType() == typeof(StockProcParamWork))
                    {
                        StockProcParamWork stockProcParamWork = (StockProcParamWork)paramList[i];
                        //送信対象開始日時
                        sndRcvHisTableWork.SndObjStartDate = stockProcParamWork.UpdateDateTimeBegin;
                        //送信対象終了日時
                        sndRcvHisTableWork.SndObjEndDate = stockProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    else if (paramList[i].GetType() == typeof(SupplierProcParamWork))
                    {
                        SupplierProcParamWork supplierProcParamWork = (SupplierProcParamWork)paramList[i];
                        //送信対象開始日時
                        sndRcvHisTableWork.SndObjStartDate = supplierProcParamWork.UpdateDateTimeBegin;
                        //送信対象終了日時
                        sndRcvHisTableWork.SndObjEndDate = supplierProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    else if (paramList[i].GetType() == typeof(RateProcParamWork))
                    {
                        RateProcParamWork rateProcParamWork = (RateProcParamWork)paramList[i];
                        //送信対象開始日時
                        sndRcvHisTableWork.SndObjStartDate = rateProcParamWork.UpdateDateTimeBegin;
                        //送信対象終了日時
                        sndRcvHisTableWork.SndObjEndDate = rateProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                    // --- ADD 2012/07/26 --------------------------------------------->>>>>
                	else if (paramList[i].GetType() == typeof(EmployeeProcParamWork))
                    {
                        EmployeeProcParamWork employeeProcParamWork = (EmployeeProcParamWork)paramList[i];
                        //送信対象開始日時
                        sndRcvHisTableWork.SndObjStartDate = employeeProcParamWork.UpdateDateTimeBegin;
                        //送信対象終了日時
                        sndRcvHisTableWork.SndObjEndDate = employeeProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                	else if (paramList[i].GetType() == typeof(JoinPartsUProcParamWork))
                    {
                        JoinPartsUProcParamWork joinPartsUProcParamWork = (JoinPartsUProcParamWork)paramList[i];
                        //送信対象開始日時
                        sndRcvHisTableWork.SndObjStartDate = joinPartsUProcParamWork.UpdateDateTimeBegin;
                        //送信対象終了日時
                        sndRcvHisTableWork.SndObjEndDate = joinPartsUProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                	else if (paramList[i].GetType() == typeof(UserGdBuyDivUProcParamWork))
                    {
                        UserGdBuyDivUProcParamWork userGdBuyDivUProcParamWork = (UserGdBuyDivUProcParamWork)paramList[i];
                        //送信対象開始日時
                        sndRcvHisTableWork.SndObjStartDate = userGdBuyDivUProcParamWork.UpdateDateTimeBegin;
                        //送信対象終了日時
                        sndRcvHisTableWork.SndObjEndDate = userGdBuyDivUProcParamWork.UpdateDateTimeEnd;
                        break;
                    }
                	// --- ADD 2012/07/26 ---------------------------------------------<<<<<
                }
                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                // 送受信状態
                if (status == 0)
                {   // DC更新成功の場合
                    sndRcvHisTableWork.SndRcvCondition = 0;
                }
                else
                {   // DC更新失敗の場合
                    sndRcvHisTableWork.SndRcvCondition = 1;
                }
                // 仮受信区分
                if (((DCSecMngSndRcvWork)masterDivList[0]).TempReceiveDiv == 2)
                {   // 仮受信の場合
                    sndRcvHisTableWork.TempReceiveDiv = 2;
                }
                else
                {   // 受信の場合
                    sndRcvHisTableWork.TempReceiveDiv = 1;
                }
                // エラー内容
                sndRcvHisTableWork.SndRcvErrContents = retMessage;
                // 送受信ファイルＩＤ
                sndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;
                sndRcvHisResWorkList.Add(sndRcvHisTableWork);
            }
            SndRcvHisTableDB sndRcvHisResDB = new SndRcvHisTableDB();
            object objSndRcvHisResWorkList = sndRcvHisResWorkList as object;
            sndRcvHisResDB.Write(ref objSndRcvHisResWorkList);
            // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<

            return status;
        }

        # endregion ■ マスタ受信のデータ検索処理 ■

        #region ■ マスタ送信の更新処理 ■
        /// <summary>
        /// DCコントロールリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.07.30</br>
        /// <br>Update Note : 2012/07/26 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 10801804-00、Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先メモ情報の追加</br>
        /// </remarks>
        public int Update(ref CustomSerializeArrayList retCSAList, string enterpriseCode, ArrayList logList, out string retMessage)
        {
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
            //// 処理開始日時を取得する。
            //DateTime startCurrentTime = new DateTime();
            //startCurrentTime = DateTime.Now;
            //// ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<

            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            string tempSndRcvFileID = string.Empty;
            Dictionary<string, string> tempSndRcvDic = new Dictionary<string, string>();
            ArrayList tempSndRcvHisResWorkList = new ArrayList();
            SndRcvHisTableWork tempSndRcvHisTableWork = null;

            for (int i = 0; i < logList.Count; i++)
            {
                if (logList[i].GetType() == typeof(ArrayList))
                {
                    ArrayList tempLogList = logList[i] as ArrayList;

                    for (int j = 0; j < tempLogList.Count; j++)
                    {
                        if (tempLogList[j].GetType() == typeof(SndRcvHisWork))
                        {
                            tempSndRcvHisTableWork = new SndRcvHisTableWork();
                            // 企業コード
                            tempSndRcvHisTableWork.EnterpriseCode = ((SndRcvHisWork)tempLogList[j]).EnterpriseCode;
                            // 拠点コード
                            tempSndRcvHisTableWork.SectionCode = ((SndRcvHisWork)tempLogList[j]).SectionCode;
                            // 送受信履歴送信番号
                            tempSndRcvHisTableWork.SndRcvHisConsNo = ((SndRcvHisWork)tempLogList[j]).SndRcvHisConsNo;
                            // 送受信区分:送信処理（開始）
                            tempSndRcvHisTableWork.SendOrReceiveDivCd = 0;
                            // 送受信日時
                            tempSndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
                            // 種別
                            tempSndRcvHisTableWork.Kind = 1;
                            // 送受信ログ抽出条件区分
                            tempSndRcvHisTableWork.SndLogExtraCondDiv = ((SndRcvHisWork)tempLogList[j]).SndLogExtraCondDiv;
                            // 送信先企業コード
                            tempSndRcvHisTableWork.SendDestEpCode = ((SndRcvHisWork)tempLogList[j]).SendDestEpCode;
                            // 送信先拠点コード
                            tempSndRcvHisTableWork.SendDestSecCode = ((SndRcvHisWork)tempLogList[j]).SendDestSecCode;
                            //送信対象開始日時
                            tempSndRcvHisTableWork.SndObjStartDate = ((SndRcvHisWork)tempLogList[j]).SndObjStartDate.Ticks;
                            //送信対象終了日時
                            tempSndRcvHisTableWork.SndObjEndDate = ((SndRcvHisWork)tempLogList[j]).SndObjEndDate.Ticks;
                            // 送受信状態
                            tempSndRcvHisTableWork.SndRcvCondition = 0;
                            // 仮受信区分
                            tempSndRcvHisTableWork.TempReceiveDiv = 0;
                            // 送受信ファイルＩＤ
                            tempSndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;

                            tempSndRcvHisResWorkList.Add(tempSndRcvHisTableWork);
                        }
                    }
                }
            }
            SndRcvHisTableDB tempSndRcvHisTableDB = new SndRcvHisTableDB();
            object tempObjSndRcvHisResWorkList = tempSndRcvHisResWorkList as object;
            tempSndRcvHisTableDB.Write(ref tempObjSndRcvHisResWorkList);
            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int status2 = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // add 2012/09/05 >>>
            // 念の為APロック用のステータスを用意
            int status3 = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // add 2012/09/05 <<<
            retMessage = string.Empty;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            string resNm = "";

            // private field
            DCSecInfoSetDB _secInfoSetDB = new DCSecInfoSetDB();
            DCSecInfoSetWork secInfoSetWork = new DCSecInfoSetWork();
            DCSubSectionDB _subSectionDB = new DCSubSectionDB();
            DCSubSectionWork subSectionWork = new DCSubSectionWork();
            DCEmployeeDB _employeeDB = new DCEmployeeDB();
            DCEmployeeWork employeeWork = new DCEmployeeWork();
            DCEmployeeDtlDB _employeeDtlDB = new DCEmployeeDtlDB();
            DCEmployeeDtlWork employeeDtlWork = new DCEmployeeDtlWork();
            DCWarehouseDB _warehouseDB = new DCWarehouseDB();
            DCWarehouseWork warehouseWork = new DCWarehouseWork();
            DCCustomerDB _customerWorkDB = new DCCustomerDB();
            DCCustomerWork customerWork = new DCCustomerWork();
            DCCustomerChangeDB _customerChangeDB = new DCCustomerChangeDB();
            DCCustomerChangeWork customerChangeWork = new DCCustomerChangeWork();
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            DCCustomerMemoDB _customerMemoDB = new DCCustomerMemoDB();
            DCCustomerMemoWork customerMemoWork = new DCCustomerMemoWork();
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
            DCCustSlipMngDB _custSlipMngDB = new DCCustSlipMngDB();
            DCCustSlipMngWork custSlipMngWork = new DCCustSlipMngWork();
            DCCustRateGroupDB _custRateGroupDB = new DCCustRateGroupDB();
            DCCustRateGroupWork custRateGroupWork = new DCCustRateGroupWork();
            DCCustSlipNoSetDB _custSlipNoSetDB = new DCCustSlipNoSetDB();
            DCCustSlipNoSetWork custSlipNoSetWork = new DCCustSlipNoSetWork();
            DCSupplierDB _supplierDB = new DCSupplierDB();
            DCSupplierWork supplierWork = new DCSupplierWork();
            DCMakerUDB _makerUWorkDB = new DCMakerUDB();
            DCMakerUWork makerUWork = new DCMakerUWork();
            DCBLGoodsCdUDB _bLGoodsCdUWorkDB = new DCBLGoodsCdUDB();
            DCBLGoodsCdUWork bLGoodsCdUWork = new DCBLGoodsCdUWork();
            DCGoodsUDB _goodsUDB = new DCGoodsUDB();
            DCGoodsUWork goodsUWork = new DCGoodsUWork();
            DCGoodsPriceUDB _goodsPriceUDB = new DCGoodsPriceUDB();
            DCGoodsPriceUWork goodsPriceUWork = new DCGoodsPriceUWork();
            DCGoodsMngDB _goodsMngDB = new DCGoodsMngDB();
            DCGoodsMngWork goodsMngWork = new DCGoodsMngWork();
            DCIsolIslandPrcDB _isolIslandPrcDB = new DCIsolIslandPrcDB();
            DCIsolIslandPrcWork isolIslandPrcWork = new DCIsolIslandPrcWork();
            DCStockDB _stockDB = new DCStockDB();
            DCStockWork stockWork = new DCStockWork();
            DCUserGdBdUDB _userGdBdUDB = new DCUserGdBdUDB();
            DCUserGdBdUWork userGdBdUWork = new DCUserGdBdUWork();
            DCRateProtyMngDB _rateProtyMngDB = new DCRateProtyMngDB();
            DCRateProtyMngWork rateProtyMngWork = new DCRateProtyMngWork();
            DCRateDB _rateDB = new DCRateDB();
            DCRateWork rateWork = new DCRateWork();
            DCGoodsSetDB _goodsSetDB = new DCGoodsSetDB();
            DCGoodsSetWork goodsSetWork = new DCGoodsSetWork();
            DCPartsSubstUDB _partsSubstUDB = new DCPartsSubstUDB();
            DCPartsSubstUWork partsSubstUWork = new DCPartsSubstUWork();
            DCEmpSalesTargetDB _empSalesTargetDB = new DCEmpSalesTargetDB();
            DCEmpSalesTargetWork empSalesTargetWork = new DCEmpSalesTargetWork();
            DCCustSalesTargetDB _custSalesTargetDB = new DCCustSalesTargetDB();
            DCCustSalesTargetWork custSalesTargetWork = new DCCustSalesTargetWork();
            DCGcdSalesTargetDB _gcdSalesTargetDB = new DCGcdSalesTargetDB();
            DCGcdSalesTargetWork gcdSalesTargetWork = new DCGcdSalesTargetWork();
            DCGoodsGroupUDB _goodsGroupUDB = new DCGoodsGroupUDB();
            DCGoodsGroupUWork goodsGroupUWork = new DCGoodsGroupUWork();
            DCBLGroupUDB _bLGroupUDB = new DCBLGroupUDB();
            DCBLGroupUWork bLGroupUWork = new DCBLGroupUWork();
            DCJoinPartsUDB _joinPartsUDB = new DCJoinPartsUDB();
            DCJoinPartsUWork joinPartsUWork = new DCJoinPartsUWork();
            DCTBOSearchUDB _tBOSearchUDB = new DCTBOSearchUDB();
            DCTBOSearchUWork tBOSearchUWork = new DCTBOSearchUWork();
            DCPartsPosCodeUDB _partsPosCodeUDB = new DCPartsPosCodeUDB();
            DCPartsPosCodeUWork partsPosCodeUWork = new DCPartsPosCodeUWork();
            DCBLCodeGuideDB _bLCodeGuideDB = new DCBLCodeGuideDB();
            DCBLCodeGuideWork bLCodeGuideWork = new DCBLCodeGuideWork();
            DCModelNameUDB _modelNameUDB = new DCModelNameUDB();
            DCModelNameUWork modelNameUWork = new DCModelNameUWork();
            //送受信抽出条件履歴ログ
            SndRcvHisDB _logDB = new SndRcvHisDB();

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

                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                resNm = GetResourceName(enterpriseCode);
                // del 2012/09/05 >>>
                //// MOD 2009/07/06 --->>>
                ////ＡＰロック
                //status = Lock(resNm, 1, sqlConnection, sqlTransaction);
                //// MOD 2009/07/06 ---<<<

                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    return status;
                //}
                // del 2012/09/05 <<<
                // add 2012/09/05 >>>
                //ＡＰロック
                status3 = Lock(resNm, 1, sqlConnection, sqlTransaction);

                if (status3 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status3;
                }
                status3 = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                // add 2012/09/05 <<<

                for (int i = 0; i < retCSAList.Count; i++)
                {
                    ArrayList retCSATemList = (ArrayList)retCSAList[i];
                    for (int j = 0; j < retCSATemList.Count; j++)
                    {
                        Type wktype = retCSATemList[j].GetType();

                        // DC拠点情報設定マスタ更新処理
                        if (wktype.Equals(typeof(DCSecInfoSetWork)))
                        {
                            _secInfoSetDB = new DCSecInfoSetDB();
                            secInfoSetWork = (DCSecInfoSetWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _secInfoSetDB.Delete(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _secInfoSetDB.Insert(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_SECINFOSET))
                            {
                                tempSndRcvDic.Add(MST_ID_SECINFOSET, MST_ID_SECINFOSET);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC部門マスタ更新処理
                        else if (wktype.Equals(typeof(DCSubSectionWork)))
                        {
                            _subSectionDB = new DCSubSectionDB();
                            subSectionWork = (DCSubSectionWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _subSectionDB.Delete(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _subSectionDB.Insert(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_SUBSECTION))
                            {
                                tempSndRcvDic.Add(MST_ID_SUBSECTION, MST_ID_SUBSECTION);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC従業員マスタ更新処理
                        else if (wktype.Equals(typeof(DCEmployeeWork)))
                        {
                            _employeeDB = new DCEmployeeDB();
                            employeeWork = (DCEmployeeWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _employeeDB.Delete(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _employeeDB.Insert(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_EMPLOYEE))
                            {
                                tempSndRcvDic.Add(MST_ID_EMPLOYEE, MST_ID_EMPLOYEE);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC従業員詳細マスタ更新処理
                        else if (wktype.Equals(typeof(DCEmployeeDtlWork)))
                        {
                            _employeeDtlDB = new DCEmployeeDtlDB();
                            employeeDtlWork = (DCEmployeeDtlWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _employeeDtlDB.Delete(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _employeeDtlDB.Insert(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_EMPLOYEEDTL))
                            {
                                tempSndRcvDic.Add(MST_ID_EMPLOYEEDTL, MST_ID_EMPLOYEEDTL);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC倉庫マスタ更新処理
                        else if (wktype.Equals(typeof(DCWarehouseWork)))
                        {
                            _warehouseDB = new DCWarehouseDB();
                            warehouseWork = (DCWarehouseWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _warehouseDB.Delete(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _warehouseDB.Insert(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_WAREHOUSE))
                            {
                                tempSndRcvDic.Add(MST_ID_WAREHOUSE, MST_ID_WAREHOUSE);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC得意先マスタ更新処理
                        else if (wktype.Equals(typeof(DCCustomerWork)))
                        {
                            _customerWorkDB = new DCCustomerDB();
                            customerWork = (DCCustomerWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _customerWorkDB.Delete(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _customerWorkDB.Insert(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_CUSTOME))
                            {
                                tempSndRcvDic.Add(MST_ID_CUSTOME, MST_ID_CUSTOME);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC得意先マスタ(変動情報)更新処理
                        else if (wktype.Equals(typeof(DCCustomerChangeWork)))
                        {
                            _customerChangeDB = new DCCustomerChangeDB();
                            customerChangeWork = (DCCustomerChangeWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _customerChangeDB.Delete(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _customerChangeDB.Insert(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_CUSTOMECHA))
                            {
                                tempSndRcvDic.Add(MST_ID_CUSTOMECHA, MST_ID_CUSTOMECHA);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                        // DC得意先マスタ(メモ情報)更新処理
                        else if (wktype.Equals(typeof(DCCustomerMemoWork)))
                        {
                            _customerMemoDB = new DCCustomerMemoDB();
                            customerMemoWork = (DCCustomerMemoWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _customerMemoDB.Delete(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _customerMemoDB.Insert(customerMemoWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            if (!tempSndRcvDic.ContainsKey(MST_ID_CUSTOMEMEMO))
                            {
                                tempSndRcvDic.Add(MST_ID_CUSTOMEMEMO, MST_ID_CUSTOMEMEMO);
                            }
                        }
                        // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                        // DC得意先マスタ（伝票管理）更新処理
                        else if (wktype.Equals(typeof(DCCustSlipMngWork)))
                        {
                            _custSlipMngDB = new DCCustSlipMngDB();
                            custSlipMngWork = (DCCustSlipMngWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _custSlipMngDB.Delete(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _custSlipMngDB.Insert(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_CUSTOMESLIPMNG))
                            {
                                tempSndRcvDic.Add(MST_ID_CUSTOMESLIPMNG, MST_ID_CUSTOMESLIPMNG);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC得意先マスタ（掛率グループ）更新処理
                        else if (wktype.Equals(typeof(DCCustRateGroupWork)))
                        {

                            custRateGroupWork = (DCCustRateGroupWork)retCSATemList[j];                           
                            // 売上データ
                            _custRateGroupList.Add(custRateGroupWork);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_CUSTOMEGROUP))
                            {
                                tempSndRcvDic.Add(MST_ID_CUSTOMEGROUP, MST_ID_CUSTOMEGROUP);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC得意先マスタ(伝票番号)更新処理
                        else if (wktype.Equals(typeof(DCCustSlipNoSetWork)))
                        {
                            _custSlipNoSetDB = new DCCustSlipNoSetDB();
                            custSlipNoSetWork = (DCCustSlipNoSetWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _custSlipNoSetDB.Delete(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _custSlipNoSetDB.Insert(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_CUSTOMESLIPNO))
                            {
                                tempSndRcvDic.Add(MST_ID_CUSTOMESLIPNO, MST_ID_CUSTOMESLIPNO);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC仕入先マスタ更新処理
                        else if (wktype.Equals(typeof(DCSupplierWork)))
                        {
                            _supplierDB = new DCSupplierDB();
                            supplierWork = (DCSupplierWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _supplierDB.Delete(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _supplierDB.Insert(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_SUPPLIER))
                            {
                                tempSndRcvDic.Add(MST_ID_SUPPLIER, MST_ID_SUPPLIER);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DCメーカーマスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCMakerUWork)))
                        {
                            _makerUWorkDB = new DCMakerUDB();
                            makerUWork = (DCMakerUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _makerUWorkDB.Delete(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _makerUWorkDB.Insert(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_MAKERU))
                            {
                                tempSndRcvDic.Add(MST_ID_MAKERU, MST_ID_MAKERU);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DCBL商品コードマスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCBLGoodsCdUWork)))
                        {
                            _bLGoodsCdUWorkDB = new DCBLGoodsCdUDB();
                            bLGoodsCdUWork = (DCBLGoodsCdUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _bLGoodsCdUWorkDB.Delete(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _bLGoodsCdUWorkDB.Insert(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_BLGOODSCDU))
                            {
                                tempSndRcvDic.Add(MST_ID_BLGOODSCDU, MST_ID_BLGOODSCDU);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC商品マスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCGoodsUWork)))
                        {
                            _goodsUDB = new DCGoodsUDB();
                            goodsUWork = (DCGoodsUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _goodsUDB.Delete(goodsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _goodsUDB.Insert(goodsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_GOODSU))
                            {
                                tempSndRcvDic.Add(MST_ID_GOODSU, MST_ID_GOODSU);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC価格マスタ（ユーザー登録）更新処理
                        else if (wktype.Equals(typeof(DCGoodsPriceUWork)))
                        {
                            goodsPriceUWork = (DCGoodsPriceUWork)retCSATemList[j];
                            _goodsPriceUList.Add(goodsPriceUWork);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_GOODSUPRI))
                            {
                                tempSndRcvDic.Add(MST_ID_GOODSUPRI, MST_ID_GOODSUPRI);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC商品管理情報マスタ更新処理
                        else if (wktype.Equals(typeof(DCGoodsMngWork)))
                        {
                            _goodsMngDB = new DCGoodsMngDB();
                            goodsMngWork = (DCGoodsMngWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _goodsMngDB.Delete(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _goodsMngDB.Insert(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_GOODSUMNG))
                            {
                                tempSndRcvDic.Add(MST_ID_GOODSUMNG, MST_ID_GOODSUMNG);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC離島価格マスタ更新処理
                        else if (wktype.Equals(typeof(DCIsolIslandPrcWork)))
                        {
                            _isolIslandPrcDB = new DCIsolIslandPrcDB();
                            isolIslandPrcWork = (DCIsolIslandPrcWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _isolIslandPrcDB.Delete(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _isolIslandPrcDB.Insert(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_GOODSUISO))
                            {
                                tempSndRcvDic.Add(MST_ID_GOODSUISO, MST_ID_GOODSUISO);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC在庫マスタ更新処理
                        else if (wktype.Equals(typeof(DCStockWork)))
                        {
                            _stockDB = new DCStockDB();
                            stockWork = (DCStockWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _stockDB.Delete(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _stockDB.Insert(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_STOCK))
                            {
                                tempSndRcvDic.Add(MST_ID_STOCK, MST_ID_STOCK);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DCユーザーガイドマスタ更新処理
                        else if (wktype.Equals(typeof(DCUserGdBdUWork)))
                        {
                            _userGdBdUDB = new DCUserGdBdUDB();
                            userGdBdUWork = (DCUserGdBdUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_USERGDU))
                            {
                                tempSndRcvDic.Add(MST_ID_USERGDU, MST_ID_USERGDU);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC掛率優先管理マスタ更新処理
                        else if (wktype.Equals(typeof(DCRateProtyMngWork)))
                        {
                            rateProtyMngWork = (DCRateProtyMngWork)retCSATemList[j];
                            _rateProtyMngList.Add(rateProtyMngWork);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_RATEPROTYMNG))
                            {
                                tempSndRcvDic.Add(MST_ID_RATEPROTYMNG, MST_ID_RATEPROTYMNG);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC掛率マスタ更新処理
                        else if (wktype.Equals(typeof(DCRateWork)))
                        {
                            rateWork = (DCRateWork)retCSATemList[j];
                            _rateList.Add(rateWork);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_RATE))
                            {
                                tempSndRcvDic.Add(MST_ID_RATE, MST_ID_RATE);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC商品セットマスタ更新処理
                        else if (wktype.Equals(typeof(DCGoodsSetWork)))
                        {
                            goodsSetWork = (DCGoodsSetWork)retCSATemList[j];
                            _goodsSetList.Add(goodsSetWork);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_GOODSSET))
                            {
                                tempSndRcvDic.Add(MST_ID_GOODSSET, MST_ID_GOODSSET);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC部品代替マスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCPartsSubstUWork)))
                        {
                            _partsSubstUDB = new DCPartsSubstUDB();
                            partsSubstUWork = (DCPartsSubstUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _partsSubstUDB.Delete(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _partsSubstUDB.Insert(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_PARTSSUBSTU))
                            {
                                tempSndRcvDic.Add(MST_ID_PARTSSUBSTU, MST_ID_PARTSSUBSTU);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC従業員別売上目標設定マスタ更新処理
                        else if (wktype.Equals(typeof(DCEmpSalesTargetWork)))
                        {
                            _empSalesTargetDB = new DCEmpSalesTargetDB();
                            empSalesTargetWork = (DCEmpSalesTargetWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _empSalesTargetDB.Delete(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _empSalesTargetDB.Insert(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_EMPSALESTARGET))
                            {
                                tempSndRcvDic.Add(MST_ID_EMPSALESTARGET, MST_ID_EMPSALESTARGET);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC得意先別売上目標設定マスタ更新処理
                        else if (wktype.Equals(typeof(DCCustSalesTargetWork)))
                        {
                            _custSalesTargetDB = new DCCustSalesTargetDB();
                            custSalesTargetWork = (DCCustSalesTargetWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _custSalesTargetDB.Delete(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _custSalesTargetDB.Insert(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_CUSTSALESTARGET))
                            {
                                tempSndRcvDic.Add(MST_ID_CUSTSALESTARGET, MST_ID_CUSTSALESTARGET);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC商品別売上目標設定マスタ更新処理
                        else if (wktype.Equals(typeof(DCGcdSalesTargetWork)))
                        {
                            _gcdSalesTargetDB = new DCGcdSalesTargetDB();
                            gcdSalesTargetWork = (DCGcdSalesTargetWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _gcdSalesTargetDB.Delete(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _gcdSalesTargetDB.Insert(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_GCDSALESTARGET))
                            {
                                tempSndRcvDic.Add(MST_ID_GCDSALESTARGET, MST_ID_GCDSALESTARGET);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC商品中分類マスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCGoodsGroupUWork)))
                        {
                            _goodsGroupUDB = new DCGoodsGroupUDB();
                            goodsGroupUWork = (DCGoodsGroupUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _goodsGroupUDB.Delete(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _goodsGroupUDB.Insert(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_GOODSMGROUPU))
                            {
                                tempSndRcvDic.Add(MST_ID_GOODSMGROUPU, MST_ID_GOODSMGROUPU);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DCBLグループマスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCBLGroupUWork)))
                        {
                            _bLGroupUDB = new DCBLGroupUDB();
                            bLGroupUWork = (DCBLGroupUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _bLGroupUDB.Delete(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _bLGroupUDB.Insert(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_BLGROUPU))
                            {
                                tempSndRcvDic.Add(MST_ID_BLGROUPU, MST_ID_BLGROUPU);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC結合マスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCJoinPartsUWork)))
                        {
                            joinPartsUWork = (DCJoinPartsUWork)retCSATemList[j];
                            _joinPartsUList.Add(joinPartsUWork);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_JOINPARTSU))
                            {
                                tempSndRcvDic.Add(MST_ID_JOINPARTSU, MST_ID_JOINPARTSU);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DCTBO検索マスタ（ユーザー登録）更新処理
                        else if (wktype.Equals(typeof(DCTBOSearchUWork)))
                        {
                            tBOSearchUWork = (DCTBOSearchUWork)retCSATemList[j];
                            _tboSearchUList.Add(tBOSearchUWork);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_TBOSEARCHU))
                            {
                                tempSndRcvDic.Add(MST_ID_TBOSEARCHU, MST_ID_TBOSEARCHU);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC部位コードマスタ（ユーザー登録）更新処理
                        else if (wktype.Equals(typeof(DCPartsPosCodeUWork)))
                        {
                            partsPosCodeUWork = (DCPartsPosCodeUWork)retCSATemList[j];
                            _partsPosCodeUList.Add(partsPosCodeUWork);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_PARTSPOSCODEU))
                            {
                                tempSndRcvDic.Add(MST_ID_PARTSPOSCODEU, MST_ID_PARTSPOSCODEU);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DCBLコードガイドマスタ更新処理
                        else if (wktype.Equals(typeof(DCBLCodeGuideWork)))
                        {
                            bLCodeGuideWork = (DCBLCodeGuideWork)retCSATemList[j];
                            _blCodeGuideList.Add(bLCodeGuideWork);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_BLCODEGUIDE))
                            {
                                tempSndRcvDic.Add(MST_ID_BLCODEGUIDE, MST_ID_BLCODEGUIDE);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                        // DC車種名称マスタ更新処理
                        else if (wktype.Equals(typeof(DCModelNameUWork)))
                        {
                            _modelNameUDB = new DCModelNameUDB();
                            modelNameUWork = (DCModelNameUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _modelNameUDB.Delete(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _modelNameUDB.Insert(modelNameUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            if (!tempSndRcvDic.ContainsKey(MST_ID_MODELNAMEU))
                            {
                                tempSndRcvDic.Add(MST_ID_MODELNAMEU, MST_ID_MODELNAMEU);
                            }
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                        }
                    }
                }
                // ADD 2009/06/09 --->>>
                // 得意先マスタ（掛率グループ）
                if (_custRateGroupList != null && _custRateGroupList.Count > 0)
                {
                    _custRateGroupDB = new DCCustRateGroupDB();
                    // 削除
                    foreach (DCCustRateGroupWork dcCustRateGroupWork in _custRateGroupList)
                    {
                        _custRateGroupDB.Delete(dcCustRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCCustRateGroupWork dcCustRateGroupWork in _custRateGroupList)
                    {
                        _custRateGroupDB.Insert(dcCustRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // 価格マスタ（ユーザー登録）
                if (_goodsPriceUList != null && _goodsPriceUList.Count > 0)
                {
                    _goodsPriceUDB = new DCGoodsPriceUDB();
                    // 削除
                    foreach (DCGoodsPriceUWork dcGoodsPriceUWork in _goodsPriceUList)
                    {
                        _goodsPriceUDB.Delete(dcGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCGoodsPriceUWork dcGoodsPriceUWork in _goodsPriceUList)
                    {
                        _goodsPriceUDB.Insert(dcGoodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // 掛率優先管理マスタ
                if (_rateProtyMngList != null && _rateProtyMngList.Count > 0)
                {
                    _rateProtyMngDB = new DCRateProtyMngDB();
                    // 削除
                    foreach (DCRateProtyMngWork dcRateProtyMngWork in _rateProtyMngList)
                    {
                        _rateProtyMngDB.Delete(dcRateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCRateProtyMngWork dcRateProtyMngWork in _rateProtyMngList)
                    {
                        _rateProtyMngDB.Insert(dcRateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // 掛率マスタ
                if (_rateList != null && _rateList.Count > 0)
                {
                    _rateDB = new DCRateDB();
                    // 削除
                    foreach (DCRateWork dcRateWork in _rateList)
                    {
                        _rateDB.Delete(dcRateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCRateWork dcRateWork in _rateList)
                    {
                        _rateDB.Insert(dcRateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // 商品セットマスタ
                if (_goodsSetList != null && _goodsSetList.Count > 0)
                {
                    _goodsSetDB = new DCGoodsSetDB();
                    // 削除
                    foreach (DCGoodsSetWork dcGoodsSetWork in _goodsSetList)
                    {
                        _goodsSetDB.Delete(dcGoodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCGoodsSetWork dcGoodsSetWork in _goodsSetList)
                    {
                        _goodsSetDB.Insert(dcGoodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // 結合マスタ（ユーザー登録分）
                if (_joinPartsUList != null && _joinPartsUList.Count > 0)
                {
                    _joinPartsUDB = new DCJoinPartsUDB();
                    // 削除
                    foreach (DCJoinPartsUWork dcJoinPartsUWork in _joinPartsUList)
                    {
                        _joinPartsUDB.Delete(dcJoinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCJoinPartsUWork dcJoinPartsUWork in _joinPartsUList)
                    {
                        _joinPartsUDB.Insert(dcJoinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // TBO検索合マスタ（ユーザー登録分）
                if (_tboSearchUList != null && _tboSearchUList.Count > 0)
                {
                    _tBOSearchUDB = new DCTBOSearchUDB();
                    // 削除
                    foreach (DCTBOSearchUWork dcTBOSearchUWork in _tboSearchUList)
                    {
                        _tBOSearchUDB.Delete(dcTBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCTBOSearchUWork dcTBOSearchUWork in _tboSearchUList)
                    {
                        _tBOSearchUDB.Insert(dcTBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // 部位コードマスタ（ユーザー登録）
                if (_partsPosCodeUList != null && _partsPosCodeUList.Count > 0)
                {
                    _partsPosCodeUDB = new DCPartsPosCodeUDB();
                    // 削除
                    foreach (DCPartsPosCodeUWork dcPartsPosCodeUWork in _partsPosCodeUList)
                    {
                        _partsPosCodeUDB.Delete(dcPartsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCPartsPosCodeUWork dcPartsPosCodeUWork in _partsPosCodeUList)
                    {
                        _partsPosCodeUDB.Insert(dcPartsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // BLコードガイドマスタ
                if (_blCodeGuideList != null && _blCodeGuideList.Count > 0)
                {
                    _bLCodeGuideDB = new DCBLCodeGuideDB();
                    // 削除
                    foreach (DCBLCodeGuideWork dcBLCodeGuideWork in _blCodeGuideList)
                    {
                        _bLCodeGuideDB.Delete(dcBLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // 追加
                    foreach (DCBLCodeGuideWork dcBLCodeGuideWork in _blCodeGuideList)
                    {
                        _bLCodeGuideDB.Insert(dcBLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }
                // ADD 2009/06/09 ---<<<

                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                foreach (KeyValuePair<string, string> tempFileId in tempSndRcvDic)
                {
                    if (string.IsNullOrEmpty(tempSndRcvFileID))
                    {
                        tempSndRcvFileID = tempSndRcvFileID + tempFileId.Key;
                    }
                    else
                    {
                        tempSndRcvFileID = tempSndRcvFileID + "," + tempFileId.Key;
                    }

                }

                ArrayList temSndRcvHisResWorkList = new ArrayList();
                SndRcvHisTableWork temSndRcvHisTableWork = null;

                for (int i = 0; i < logList.Count; i++)
                {
                    if (logList[i].GetType() == typeof(ArrayList))
                    {
                        ArrayList temLogList = logList[i] as ArrayList;

                        for (int j = 0; j < temLogList.Count; j++)
                        {
                            if (temLogList[j].GetType() == typeof(SndRcvHisWork))
                            {
                                temSndRcvHisTableWork = new SndRcvHisTableWork();
                                // 企業コード
                                temSndRcvHisTableWork.EnterpriseCode = ((SndRcvHisWork)temLogList[j]).EnterpriseCode;
                                // 拠点コード
                                temSndRcvHisTableWork.SectionCode = ((SndRcvHisWork)temLogList[j]).SectionCode;
                                // 送受信履歴送信番号
                                temSndRcvHisTableWork.SndRcvHisConsNo = ((SndRcvHisWork)temLogList[j]).SndRcvHisConsNo;
                                // 送受信区分:送信処理（終了）
                                temSndRcvHisTableWork.SendOrReceiveDivCd = 1;
                                // 送受信日時
                                temSndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
                                // 種別
                                temSndRcvHisTableWork.Kind = 1;
                                // 送受信ログ抽出条件区分
                                temSndRcvHisTableWork.SndLogExtraCondDiv = ((SndRcvHisWork)temLogList[j]).SndLogExtraCondDiv;
                                // 送信先企業コード
                                temSndRcvHisTableWork.SendDestEpCode = ((SndRcvHisWork)temLogList[j]).SendDestEpCode;
                                // 送信先拠点コード
                                temSndRcvHisTableWork.SendDestSecCode = ((SndRcvHisWork)temLogList[j]).SendDestSecCode;
                                //送信対象開始日時
                                temSndRcvHisTableWork.SndObjStartDate = ((SndRcvHisWork)temLogList[j]).SndObjStartDate.Ticks;
                                //送信対象終了日時
                                temSndRcvHisTableWork.SndObjEndDate = ((SndRcvHisWork)temLogList[j]).SndObjEndDate.Ticks;
                                // 送受信状態
                                temSndRcvHisTableWork.SndRcvCondition = 0;
                                // 仮受信区分
                                temSndRcvHisTableWork.TempReceiveDiv = 0;
                                // 送受信ファイルＩＤ
                                temSndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;

                                temSndRcvHisResWorkList.Add(temSndRcvHisTableWork);
                            }
                        }
                    }
                }

                SndRcvHisTableDB temSndRcvHisTableDB = new SndRcvHisTableDB();
                object temObjSndRcvHisResWorkList = temSndRcvHisResWorkList as object;
                temSndRcvHisTableDB.Write(ref temObjSndRcvHisResWorkList);
                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                //履歴ログ
                status2 = _logDB.WriteProc(logList, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "MstDCControlDB.Update SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                retMessage = ex.Message;    // ADD 2012/07/26 姚学剛
            }
            catch (Exception e)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "MstDCControlDB.Update Exception=" + e.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                retMessage = e.Message;    // ADD 2012/07/26 姚学剛
            }
            finally
            {
                // upd 2012/09/05 >>>
                //if (resNm != "")
                if (resNm != "" && status3 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                // upd 2012/09/05 <<<
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
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && status2 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
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
            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //STATUSを戻す
            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = status2;
            }
            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026-------->>>>>
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// 処理終了日付を取得する。
            //DateTime endCurrentTime = new DateTime();
            //endCurrentTime = DateTime.Now;
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<

            ArrayList sndRcvHisResWorkList = new ArrayList();

            SndRcvHisTableWork sndRcvHisTableWork = new SndRcvHisTableWork();

            for (int i = 0; i < logList.Count; i++)
            {
                if (logList[i].GetType() == typeof(ArrayList))
                {
                    ArrayList al= logList[i] as ArrayList;

                    for (int j = 0; j < al.Count; j++)
                    {
                        if (al[j].GetType() == typeof(SndRcvHisWork))
                        {
                            // 企業コード
                            sndRcvHisTableWork.EnterpriseCode = ((SndRcvHisWork)al[j]).EnterpriseCode;
                            // 拠点コード
                            sndRcvHisTableWork.SectionCode = ((SndRcvHisWork)al[j]).SectionCode;
                            // 送受信履歴送信番号
                            sndRcvHisTableWork.SndRcvHisConsNo = ((SndRcvHisWork)al[j]).SndRcvHisConsNo;
                            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            //// 送受信区分
                            //sndRcvHisTableWork.SendOrReceiveDivCd = 0;
                            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            // 送受信区分:送信処理（送受信履歴更新）
                            sndRcvHisTableWork.SendOrReceiveDivCd = 2;
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                            // 送受信日時
                            //sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));//DEL 2012/10/16 李亜博 for redmine#31026
                            sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));//ADD 2012/10/16 李亜博 for redmine#31026
                            // 種別
                            sndRcvHisTableWork.Kind = 1;
                            // 送受信ログ抽出条件区分
                            sndRcvHisTableWork.SndLogExtraCondDiv = ((SndRcvHisWork)al[j]).SndLogExtraCondDiv;
                            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            //// 処理開始日時
                            //sndRcvHisTableWork.ProcStartDateTime = startCurrentTime.Ticks;
                            //// 処理終了日時
                            //sndRcvHisTableWork.ProcEndDateTime = endCurrentTime.Ticks;
                            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                            // 送信先企業コード
                            sndRcvHisTableWork.SendDestEpCode = ((SndRcvHisWork)al[j]).SendDestEpCode;
                            // 送信先拠点コード
                            sndRcvHisTableWork.SendDestSecCode = ((SndRcvHisWork)al[j]).SendDestSecCode;
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            //送信対象開始日時
                            sndRcvHisTableWork.SndObjStartDate = ((SndRcvHisWork)al[j]).SndObjStartDate.Ticks;
                            //送信対象終了日時
                            sndRcvHisTableWork.SndObjEndDate = ((SndRcvHisWork)al[j]).SndObjEndDate.Ticks;
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                            // 送受信状態
                            if (status == 0)
                            {
                                sndRcvHisTableWork.SndRcvCondition = 0;
                            }
                            else
                            {
                                sndRcvHisTableWork.SndRcvCondition = 1;
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                                // エラー内容
                                if (string.IsNullOrEmpty(retMessage))
                                {
                                    sndRcvHisTableWork.SndRcvErrContents = "履歴ログ更新失敗しました。";
                                }
                                else
                                {
                                    sndRcvHisTableWork.SndRcvErrContents = retMessage;
                                }
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                            }
                            // 仮受信区分
                            sndRcvHisTableWork.TempReceiveDiv = 0;
                            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            //// エラー内容
                            //sndRcvHisTableWork.SndRcvErrContents = retMessage;
                            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                            // 送受信ファイルＩＤ
                            //sndRcvHisTableWork.SndRcvFileID = ((SndRcvHisWork)al[j]).SndRcvFileID;//DEL 2012/10/16 李亜博 for redmine#31026
                            sndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;//ADD 2012/10/16 李亜博 for redmine#31026

                            sndRcvHisResWorkList.Add(sndRcvHisTableWork);
                        }
                    }
                }
            }
            SndRcvHisTableDB sndRcvHisTableDB = new SndRcvHisTableDB();
            object objSndRcvHisResWorkList = sndRcvHisResWorkList as object;
            sndRcvHisTableDB.Write(ref objSndRcvHisResWorkList);
            // ------------ADD 姚学剛 2012/07/26 FOR Redmine#31026---------<<<<<

            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            ////STATUSを戻す
            //if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    status = status2;
            //}
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            return status;
        }

        #endregion

        # region ■ マスタ受信のデータ件数検索処理 ■
        /// <summary>
        /// マスタ受信のデータ検索処理
        /// </summary>
        /// <param name="pmEnterpriseCodes">PM企業コード</param>
        /// <param name="secMngSndRcvWork">マスタ区分</param>
        /// <param name="param">マスタ抽出条件クラス</param>
        /// <param name="count">戻る件数</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ送信処理READの実データ検索を行うクラスです。</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.07.26</br>
        public int GetObjCount(string pmEnterpriseCodes, DCSecMngSndRcvWork secMngSndRcvWork, object param, ref int count, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMessage = string.Empty;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();

                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                switch (secMngSndRcvWork.FileId)
                { 
                    case MST_GOODSU:
                        //商品マスタ
                        DCGoodsUDB _goodsUDB = new DCGoodsUDB();
                        status = _goodsUDB.SearchGoodsUCount(pmEnterpriseCodes, param, sqlConnection, sqlTransaction, ref count,out retMessage);
                        break;
                    case MST_STOCK:
                        // 在庫マスタ
                        DCStockDB _stockDB = new DCStockDB();
                        status = _stockDB.SearchStockCount(pmEnterpriseCodes, param, sqlConnection, sqlTransaction, ref count, out retMessage);
                        break;
                    default:
                        count = -1;
                        break;
                
                }
            }
            catch (Exception ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "MstDCControlDB.GetObjCount Exception=" + ex.Message);
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
        # endregion ■ マスタ受信のデータ件数検索処理 ■
        #endregion ADD 2011/07/26 孫東響  SCM対応-拠点管理（10704767-00）


        #region ■ マスタデータのクリア処理 ■DEL by Liangsd     2011/09/06
        //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
        ///// <summary>
        ///// Dマスタデータのクリア処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 特になし</br>
        ///// <br>Programmer : 張莉莉</br>
        ///// <br>Date       : 2011.08.26</br>
        ///// </remarks>
        //public int DCMSDataClear(string enterpriseCode)
        //{
        //    //●STATUS初期化
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    int status2 = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    SqlTransaction sqlTransaction = null;
        //    SqlConnection sqlConnection = null;
        //    SqlCommand sqlCommand = null;
        //    string resNm = "";

        //    // private field
        //    DCSecInfoSetDB _secInfoSetDB = new DCSecInfoSetDB();
        //    DCSecInfoSetWork secInfoSetWork = new DCSecInfoSetWork();
        //    DCSubSectionDB _subSectionDB = new DCSubSectionDB();
        //    DCSubSectionWork subSectionWork = new DCSubSectionWork();
        //    DCEmployeeDB _employeeDB = new DCEmployeeDB();
        //    DCEmployeeWork employeeWork = new DCEmployeeWork();
        //    DCEmployeeDtlDB _employeeDtlDB = new DCEmployeeDtlDB();
        //    DCEmployeeDtlWork employeeDtlWork = new DCEmployeeDtlWork();
        //    DCWarehouseDB _warehouseDB = new DCWarehouseDB();
        //    DCWarehouseWork warehouseWork = new DCWarehouseWork();
        //    DCCustomerDB _customerWorkDB = new DCCustomerDB();
        //    DCCustomerWork customerWork = new DCCustomerWork();
        //    DCCustomerChangeDB _customerChangeDB = new DCCustomerChangeDB();
        //    DCCustomerChangeWork customerChangeWork = new DCCustomerChangeWork();
        //    DCCustSlipMngDB _custSlipMngDB = new DCCustSlipMngDB();
        //    DCCustSlipMngWork custSlipMngWork = new DCCustSlipMngWork();
        //    DCCustRateGroupDB _custRateGroupDB = new DCCustRateGroupDB();
        //    DCCustRateGroupWork custRateGroupWork = new DCCustRateGroupWork();
        //    DCCustSlipNoSetDB _custSlipNoSetDB = new DCCustSlipNoSetDB();
        //    DCCustSlipNoSetWork custSlipNoSetWork = new DCCustSlipNoSetWork();
        //    DCSupplierDB _supplierDB = new DCSupplierDB();
        //    DCSupplierWork supplierWork = new DCSupplierWork();
        //    DCMakerUDB _makerUWorkDB = new DCMakerUDB();
        //    DCMakerUWork makerUWork = new DCMakerUWork();
        //    DCBLGoodsCdUDB _bLGoodsCdUWorkDB = new DCBLGoodsCdUDB();
        //    DCBLGoodsCdUWork bLGoodsCdUWork = new DCBLGoodsCdUWork();
        //    DCGoodsUDB _goodsUDB = new DCGoodsUDB();
        //    DCGoodsUWork goodsUWork = new DCGoodsUWork();
        //    DCGoodsPriceUDB _goodsPriceUDB = new DCGoodsPriceUDB();
        //    DCGoodsPriceUWork goodsPriceUWork = new DCGoodsPriceUWork();
        //    DCGoodsMngDB _goodsMngDB = new DCGoodsMngDB();
        //    DCGoodsMngWork goodsMngWork = new DCGoodsMngWork();
        //    DCIsolIslandPrcDB _isolIslandPrcDB = new DCIsolIslandPrcDB();
        //    DCIsolIslandPrcWork isolIslandPrcWork = new DCIsolIslandPrcWork();
        //    DCStockDB _stockDB = new DCStockDB();
        //    DCStockWork stockWork = new DCStockWork();
        //    DCUserGdBdUDB _userGdBdUDB = new DCUserGdBdUDB();
        //    DCUserGdBdUWork userGdBdUWork = new DCUserGdBdUWork();
        //    DCRateProtyMngDB _rateProtyMngDB = new DCRateProtyMngDB();
        //    DCRateProtyMngWork rateProtyMngWork = new DCRateProtyMngWork();
        //    DCRateDB _rateDB = new DCRateDB();
        //    DCRateWork rateWork = new DCRateWork();
        //    DCGoodsSetDB _goodsSetDB = new DCGoodsSetDB();
        //    DCGoodsSetWork goodsSetWork = new DCGoodsSetWork();
        //    DCPartsSubstUDB _partsSubstUDB = new DCPartsSubstUDB();
        //    DCPartsSubstUWork partsSubstUWork = new DCPartsSubstUWork();
        //    DCEmpSalesTargetDB _empSalesTargetDB = new DCEmpSalesTargetDB();
        //    DCEmpSalesTargetWork empSalesTargetWork = new DCEmpSalesTargetWork();
        //    DCCustSalesTargetDB _custSalesTargetDB = new DCCustSalesTargetDB();
        //    DCCustSalesTargetWork custSalesTargetWork = new DCCustSalesTargetWork();
        //    DCGcdSalesTargetDB _gcdSalesTargetDB = new DCGcdSalesTargetDB();
        //    DCGcdSalesTargetWork gcdSalesTargetWork = new DCGcdSalesTargetWork();
        //    DCGoodsGroupUDB _goodsGroupUDB = new DCGoodsGroupUDB();
        //    DCGoodsGroupUWork goodsGroupUWork = new DCGoodsGroupUWork();
        //    DCBLGroupUDB _bLGroupUDB = new DCBLGroupUDB();
        //    DCBLGroupUWork bLGroupUWork = new DCBLGroupUWork();
        //    DCJoinPartsUDB _joinPartsUDB = new DCJoinPartsUDB();
        //    DCJoinPartsUWork joinPartsUWork = new DCJoinPartsUWork();
        //    DCTBOSearchUDB _tBOSearchUDB = new DCTBOSearchUDB();
        //    DCTBOSearchUWork tBOSearchUWork = new DCTBOSearchUWork();
        //    DCPartsPosCodeUDB _partsPosCodeUDB = new DCPartsPosCodeUDB();
        //    DCPartsPosCodeUWork partsPosCodeUWork = new DCPartsPosCodeUWork();
        //    DCBLCodeGuideDB _bLCodeGuideDB = new DCBLCodeGuideDB();
        //    DCBLCodeGuideWork bLCodeGuideWork = new DCBLCodeGuideWork();
        //    DCModelNameUDB _modelNameUDB = new DCModelNameUDB();
        //    DCModelNameUWork modelNameUWork = new DCModelNameUWork();

        //    try
        //    {
				
        //        // コネクション生成
        //        sqlConnection = this.CreateSqlConnectionData(true);

        //        // トランザクション
        //        sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

        //        resNm = GetResourceName(enterpriseCode);

        //        //ＡＰロック
        //        status = Lock(resNm, 1, sqlConnection, sqlTransaction);

        //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            return status;
        //        }

        //        //	拠点設定マスタ
        //        _secInfoSetDB = new DCSecInfoSetDB();
        //        _secInfoSetDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	部門設定マスタ
        //        _subSectionDB = new DCSubSectionDB();
        //        _subSectionDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	倉庫設定マスタ
        //        _warehouseDB = new DCWarehouseDB();
        //        _warehouseDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	従業員詳細マスタ
        //        _employeeDtlDB = new DCEmployeeDtlDB();
        //        _employeeDtlDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	従業員設定マスタ
        //        _employeeDB = new DCEmployeeDB();
        //        _employeeDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	ユーザーガイドマスタ
        //        _userGdBdUDB = new DCUserGdBdUDB();
        //        _userGdBdUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	掛率優先管理マスタ
        //        _rateProtyMngDB = new DCRateProtyMngDB();
        //        _rateProtyMngDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	掛率マスタ
        //        _rateDB = new DCRateDB();
        //        _rateDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	商品別売上目標設定マスタ
        //        _gcdSalesTargetDB = new DCGcdSalesTargetDB();
        //        _gcdSalesTargetDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	得意先別売上目標設定マスタ
        //        _custSalesTargetDB = new DCCustSalesTargetDB();
        //        _custSalesTargetDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	従業員別売上目標設定マスタ
        //        _empSalesTargetDB = new DCEmpSalesTargetDB();
        //        _empSalesTargetDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	得意先マスタ
        //        _customerWorkDB = new DCCustomerDB();
        //        _customerWorkDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	得意先マスタ(伝票番号)
        //        _custSlipNoSetDB = new DCCustSlipNoSetDB();
        //        _custSlipNoSetDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	得意先マスタ(変動情報)
        //        _customerChangeDB = new DCCustomerChangeDB();
        //        _customerChangeDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	得意先マスタ（掛率グループ）
        //        _custRateGroupDB = new DCCustRateGroupDB();
        //        _custRateGroupDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	得意先マスタ（伝票管理）
        //        _custSlipMngDB = new DCCustSlipMngDB();
        //        _custSlipMngDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	仕入先マスタ
        //        _supplierDB = new DCSupplierDB();
        //        _supplierDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	結合マスタ
        //        _joinPartsUDB = new DCJoinPartsUDB();
        //        _joinPartsUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	セットマスタ
        //        _goodsSetDB = new DCGoodsSetDB();
        //        _goodsSetDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	ＴＢＯマスタ
        //        _tBOSearchUDB = new DCTBOSearchUDB();
        //        _tBOSearchUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	車種名称マスタ
        //        _modelNameUDB = new DCModelNameUDB();
        //        _modelNameUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	ＢＬコードマスタ
        //        _bLGoodsCdUWorkDB = new DCBLGoodsCdUDB();
        //        _bLGoodsCdUWorkDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	メーカーマスタ
        //        _makerUWorkDB = new DCMakerUDB();
        //        _makerUWorkDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	商品中分類マスタ
        //        _goodsGroupUDB = new DCGoodsGroupUDB();
        //        _goodsGroupUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	グループコードマスタ
        //        _bLGroupUDB = new DCBLGroupUDB();
        //        _bLGroupUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	BLコードガイドマスタ
        //        _bLCodeGuideDB = new DCBLCodeGuideDB();
        //        _bLCodeGuideDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	商品管理情報マスタ
        //        _goodsMngDB = new DCGoodsMngDB();
        //        _goodsMngDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	商品マスタ(価格情報）
        //        _goodsPriceUDB = new DCGoodsPriceUDB();
        //        _goodsPriceUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	商品マスタ
        //        _goodsUDB = new DCGoodsUDB();
        //        _goodsUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	離島価格マスタ
        //        _isolIslandPrcDB = new DCIsolIslandPrcDB();
        //        _isolIslandPrcDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	在庫マスタ
        //        _stockDB = new DCStockDB();
        //        _stockDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	代替マスタ
        //        _partsSubstUDB = new DCPartsSubstUDB();
        //        _partsSubstUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        //	部位マスタ
        //        _partsPosCodeUDB = new DCPartsPosCodeUDB();
        //        _partsPosCodeUDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        // 送信履歴ログ
        //        this.ClearSndRcvEtr(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        //        this.ClearSndRcvhis(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        // 基底クラスに例外を渡して処理してもらう
        //        base.WriteErrorLog(ex, "MstDCControlDB.Update SqlException=" + ex.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    catch (Exception e)
        //    {
        //        //基底クラスに例外を渡して処理してもらう
        //        base.WriteErrorLog(e, "MstDCControlDB.Update Exception=" + e.Message);
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        if (resNm != "")
        //        {
        //            //ＡＰアンロック
        //            status2 = Release(resNm, sqlConnection, sqlTransaction);

        //            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //            {
        //                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //            }
        //        }

        //        if (sqlTransaction != null)
        //        {
        //            if (sqlTransaction.Connection != null)
        //            {
        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && status2 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    sqlTransaction.Commit();
        //                }
        //                else
        //                {
        //                    sqlTransaction.Rollback();
        //                }
        //            }
        //        }

        //        if (sqlTransaction != null) sqlTransaction.Dispose();
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //        }
        //        if (sqlCommand != null)
        //        {
        //            sqlCommand.Cancel();
        //            sqlCommand.Dispose();
        //        }
        //    }
        //    //STATUSを戻す
        //    if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        status = status2;
        //    }
        //    return status;
        //}
        //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
		#endregion

		// ADD 2011.08.26 張莉莉 ---------->>>>>
		# region [ClearSndRcvEtr] DLL by Liangsd 
        //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
        //// Rクラスの MethodでSQL文字が駄目
        ///// <summary>
        ///// データクリア
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sqlConnection">データベース接続情報</param>
        ///// <param name="sqlTransaction">トランザクション情報</param>
        ///// <param name="sqlCommand">SQLコメント</param>
        ///// <returns></returns>
        //private void ClearSndRcvEtr(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    ClearSndRcvEtrProc(enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        //}
        ///// <summary>
        ///// データクリア
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sqlConnection">データベース接続情報</param>
        ///// <param name="sqlTransaction">トランザクション情報</param>
        ///// <param name="sqlCommand">SQLコメント</param>
        ///// <returns></returns>
        //private void ClearSndRcvEtrProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //    // Deleteコマンドの生成
        //    sqlCommand.CommandText = "DELETE FROM SNDRCVETRRF WHERE EXISTS ( SELECT * FROM SNDRCVHISRF WHERE (SNDRCVHISRF.ENTERPRISECODERF = @FINFENTERPRISECODE OR SNDRCVHISRF.SENDDESTEPCODERF = @FINDSENDDESTEPCODE ) AND SNDRCVHISRF.KINDRF = @FINDKIND AND SNDRCVHISRF.ENTERPRISECODERF = SNDRCVETRRF.ENTERPRISECODERF AND SNDRCVHISRF.SECTIONCODERF = SNDRCVETRRF.SECTIONCODERF AND SNDRCVHISRF.SNDRCVHISCONSNORF = SNDRCVETRRF.SNDRCVHISCONSNORF ) ";
        //    //Prameterオブジェクトの作成
        //    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINFENTERPRISECODE", SqlDbType.NChar);
        //    SqlParameter findParaSendEstEpCode = sqlCommand.Parameters.Add("@FINDSENDDESTEPCODE", SqlDbType.NChar);
        //    SqlParameter paraKind = sqlCommand.Parameters.Add("@FINDKIND", SqlDbType.Int);

        //    //Parameterオブジェクトへ値設定
        //    findParaEnterpriseCode.Value = enterpriseCode;
        //    findParaSendEstEpCode.Value = enterpriseCode;
        //    paraKind.Value = SqlDataMediator.SqlSetInt32(1);

        //    // データを削除する
        //    sqlCommand.ExecuteNonQuery();

        //}
        //#endregion

        //# region [ClearSndRcvhis]
        //// Rクラスの MethodでSQL文字が駄目
        ///// <summary>
        ///// データクリア
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sqlConnection">データベース接続情報</param>
        ///// <param name="sqlTransaction">トランザクション情報</param>
        ///// <param name="sqlCommand">SQLコメント</param>
        ///// <returns></returns>
        //private void ClearSndRcvhis(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    ClearSndRcvhisProc(enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        //}
        ///// <summary>
        ///// データクリア
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sqlConnection">データベース接続情報</param>
        ///// <param name="sqlTransaction">トランザクション情報</param>
        ///// <param name="sqlCommand">SQLコメント</param>
        ///// <returns></returns>
        //private void ClearSndRcvhisProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //    // Deleteコマンドの生成
        //    sqlCommand.CommandText = "DELETE FROM SNDRCVHISRF WHERE ( ENTERPRISECODERF=@FINDENTERPRISECODE OR SENDDESTEPCODERF=@FINDSENDDESTEPCODE) AND KINDRF=@FINDKINDRF ";
        //    //Prameterオブジェクトの作成
        //    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //    SqlParameter findParaSendEstEpCode = sqlCommand.Parameters.Add("@FINDSENDDESTEPCODE", SqlDbType.NChar);
        //    SqlParameter paraKind = sqlCommand.Parameters.Add("@FINDKINDRF", SqlDbType.Int);

        //    //Parameterオブジェクトへ値設定
        //    findParaEnterpriseCode.Value = enterpriseCode;
        //    findParaSendEstEpCode.Value = enterpriseCode;
        //    paraKind.Value = SqlDataMediator.SqlSetInt32(1);

        //    // データを削除する
        //    sqlCommand.ExecuteNonQuery();

        //}
		#endregion
		// ADD 2011.08.26 張莉莉 ----------<<<<<
        //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
    }
}
