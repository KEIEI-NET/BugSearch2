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
// 管理番号              修正担当 : 譚洪
// 修 正 日  2009/06/08  修正内容 : マスタ送受信不備対応について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/07/06  修正内容 : マスタ送受信処理のＡＰＰロックについて
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/07/06  修正内容 : データ送信処理のDCサーバーのエラーログについて
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
    /// 集計機コントロールDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 集計機コントロールDBの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.3.31</br>
    /// </remarks>
    public class MstTotalMachControlDB : RemoteWithAppLockDB, IMstTotalMachControlDB
    {

        #region ■ 定数 ■
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
        private const string MST_ID_EMPLOYEE = "EmployeeDtlRF";
        private const string MST_ID_EMPLOYEEDTL = "EmployeeDtlRF";
        private const string MST_ID_USERGDU = "UserGdBdURF";
        private const string MST_ID_RATEPROTYMNG = "RateProtyMngRF";
        private const string MST_ID_RATE = "RateRF";
        private const string MST_ID_CUSTSALESTARGET = "CustSalesTargetRF";
        private const string MST_ID_EMPSALESTARGET = "EmpSalesTargetRF";
        private const string MST_ID_GCDSALESTARGET = "GcdSalesTargetRF";
        private const string MST_ID_CUSTOMECHA = "CustomerChangeRF";
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
        public MstTotalMachControlDB()
        {
            // 変数初期化
            //_secInfoSetDB = new DCSecInfoSetDB();
            //_subSectionDB = new DCSubSectionDB();
            //_employeeDB = new DCEmployeeDB();
            //_employeeDtlDB = new DCEmployeeDtlDB();
            //_warehouseDB = new DCWarehouseDB();
            //_customerWorkDB = new DCCustomerDB();
            //_customerChangeDB = new DCCustomerChangeDB();
            //_custSlipMngDB = new DCCustSlipMngDB();
            //_custRateGroupDB = new DCCustRateGroupDB();
            //_custSlipNoSetDB = new DCCustSlipNoSetDB();
            //_supplierDB = new DCSupplierDB();
            //_makerUWorkDB = new DCMakerUDB();
            //_bLGoodsCdUWorkDB = new DCBLGoodsCdUDB();
            //_goodsUDB = new DCGoodsUDB();
            //_goodsPriceUDB = new DCGoodsPriceUDB();
            //_goodsMngDB = new DCGoodsMngDB();
            //_isolIslandPrcDB = new DCIsolIslandPrcDB();
            //_stockDB = new DCStockDB();
            //_userGdBdUDB = new DCUserGdBdUDB();
            //_rateProtyMngDB = new DCRateProtyMngDB();
            //_rateDB = new DCRateDB();
            //_goodsSetDB = new DCGoodsSetDB();
            //_partsSubstUDB = new DCPartsSubstUDB();
            //_empSalesTargetDB = new DCEmpSalesTargetDB();
            //_custSalesTargetDB = new DCCustSalesTargetDB();
            //_gcdSalesTargetDB = new DCGcdSalesTargetDB();
            //_goodsGroupUDB = new DCGoodsGroupUDB();
            //_bLGroupUDB = new DCBLGroupUDB();
            //_joinPartsUDB = new DCJoinPartsUDB();
            //_tBOSearchUDB = new DCTBOSearchUDB();
            //_partsPosCodeUDB = new DCPartsPosCodeUDB();
            //_bLCodeGuideDB = new DCBLCodeGuideDB();
            //_modelNameUDB = new DCModelNameUDB();
        }
        #endregion

        # region ■ マスタ受信のデータ検索処理 ■
        /// <summary>
        /// データ送信のデータ検索処理
        /// </summary>
        /// <param name="masterDivList">マスタ区分</param>
        /// <param name="pmEnterpriseCodes">PM企業コード</param>
        /// <param name="beginningDate">検索結果</param>
        /// <param name="endingDate">検索条件</param>
        /// <param name="retCSAList">更新データ</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ送信処理READの実データ検索を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int SearchCustomSerializeArrayList(ArrayList masterDivList, string pmEnterpriseCodes, Int64 beginningDate, Int64 endingDate, ref CustomSerializeArrayList retCSAList, out string retMessage)
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
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Summary_DB);
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
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.UpdateShipmentDir Exception=" + ex.Message);
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
        /// DCコントロールリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        public int Update(ref CustomSerializeArrayList retCSAList, string enterpriseCode, out string retMessage)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMessage = string.Empty;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            string resNm = "";

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
                // MOD 2009/07/06 --->>>
                //ＡＰロック
                status = Lock(resNm, 1, sqlConnection, sqlTransaction);
                // MOD 2009/07/06 ---<<<

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                for (int i = 0; i < retCSAList.Count; i++)
                {
                    ArrayList retCSATemList = (ArrayList)retCSAList[i];
                    for (int j = 0; j < retCSATemList.Count; j++)
                    {
                        Type wktype = retCSATemList[j].GetType();

                        // DC拠点情報設定マスタ更新処理
                        if (wktype.Equals(typeof(DCSecInfoSetWork)))
                        {
                            DCSecInfoSetDB _secInfoSetDB = new DCSecInfoSetDB();
                            DCSecInfoSetWork secInfoSetWork = (DCSecInfoSetWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _secInfoSetDB.Delete(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _secInfoSetDB.Insert(secInfoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                        }
                        // DC部門マスタ更新処理
                        else if (wktype.Equals(typeof(DCSubSectionWork)))
                        {
                            DCSubSectionDB _subSectionDB = new DCSubSectionDB();
                            DCSubSectionWork subSectionWork = (DCSubSectionWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _subSectionDB.Delete(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _subSectionDB.Insert(subSectionWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC従業員マスタ更新処理
                        else if (wktype.Equals(typeof(DCEmployeeWork)))
                        {
                            DCEmployeeDB _employeeDB = new DCEmployeeDB();
                            DCEmployeeWork employeeWork = (DCEmployeeWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _employeeDB.Delete(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _employeeDB.Insert(employeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC従業員詳細マスタ更新処理
                        else if (wktype.Equals(typeof(DCEmployeeDtlWork)))
                        {
                            DCEmployeeDtlDB _employeeDtlDB = new DCEmployeeDtlDB();
                            DCEmployeeDtlWork employeeDtlWork = (DCEmployeeDtlWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _employeeDtlDB.Delete(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _employeeDtlDB.Insert(employeeDtlWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC倉庫マスタ更新処理
                        else if (wktype.Equals(typeof(DCWarehouseWork)))
                        {
                            DCWarehouseDB _warehouseDB = new DCWarehouseDB();
                            DCWarehouseWork warehouseWork = (DCWarehouseWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _warehouseDB.Delete(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _warehouseDB.Insert(warehouseWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC得意先マスタ更新処理
                        else if (wktype.Equals(typeof(DCCustomerWork)))
                        {
                            DCCustomerDB _customerWorkDB = new DCCustomerDB();
                            DCCustomerWork customerWork = (DCCustomerWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _customerWorkDB.Delete(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _customerWorkDB.Insert(customerWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC得意先マスタ(変動情報)更新処理
                        else if (wktype.Equals(typeof(DCCustomerChangeWork)))
                        {
                            DCCustomerChangeDB _customerChangeDB = new DCCustomerChangeDB();
                            DCCustomerChangeWork customerChangeWork = (DCCustomerChangeWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _customerChangeDB.Delete(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _customerChangeDB.Insert(customerChangeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC得意先マスタ（伝票管理）更新処理
                        else if (wktype.Equals(typeof(DCCustSlipMngWork)))
                        {
                            DCCustSlipMngDB _custSlipMngDB = new DCCustSlipMngDB();
                            DCCustSlipMngWork custSlipMngWork = (DCCustSlipMngWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _custSlipMngDB.Delete(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _custSlipMngDB.Insert(custSlipMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC得意先マスタ（掛率グループ）更新処理
                        else if (wktype.Equals(typeof(DCCustRateGroupWork)))
                        {
                            //DCCustRateGroupDB _custRateGroupDB = new DCCustRateGroupDB();
                            DCCustRateGroupWork custRateGroupWork = (DCCustRateGroupWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_custRateGroupDB.Delete(custRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_custRateGroupDB.Insert(custRateGroupWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _custRateGroupList.Add(custRateGroupWork);
                        }
                        // DC得意先マスタ(伝票番号)更新処理
                        else if (wktype.Equals(typeof(DCCustSlipNoSetWork)))
                        {
                            DCCustSlipNoSetDB _custSlipNoSetDB = new DCCustSlipNoSetDB();
                            DCCustSlipNoSetWork custSlipNoSetWork = (DCCustSlipNoSetWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _custSlipNoSetDB.Delete(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _custSlipNoSetDB.Insert(custSlipNoSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC仕入先マスタ更新処理
                        else if (wktype.Equals(typeof(DCSupplierWork)))
                        {
                            DCSupplierDB _supplierDB = new DCSupplierDB();
                            DCSupplierWork supplierWork = (DCSupplierWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _supplierDB.Delete(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _supplierDB.Insert(supplierWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DCメーカーマスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCMakerUWork)))
                        {
                            DCMakerUDB _makerUWorkDB = new DCMakerUDB();
                            DCMakerUWork makerUWork = (DCMakerUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _makerUWorkDB.Delete(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _makerUWorkDB.Insert(makerUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DCBL商品コードマスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCBLGoodsCdUWork)))
                        {
                            DCBLGoodsCdUDB _bLGoodsCdUWorkDB = new DCBLGoodsCdUDB();
                            DCBLGoodsCdUWork bLGoodsCdUWork = (DCBLGoodsCdUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _bLGoodsCdUWorkDB.Delete(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _bLGoodsCdUWorkDB.Insert(bLGoodsCdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC商品マスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCGoodsUWork)))
                        {
                            DCGoodsUDB _goodsUDB = new DCGoodsUDB();
                            DCGoodsUWork goodsUWork = (DCGoodsUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _goodsUDB.Delete(goodsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _goodsUDB.Insert(goodsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC価格マスタ（ユーザー登録）更新処理
                        else if (wktype.Equals(typeof(DCGoodsPriceUWork)))
                        {
                            //DCGoodsPriceUDB _goodsPriceUDB = new DCGoodsPriceUDB();
                            DCGoodsPriceUWork goodsPriceUWork = (DCGoodsPriceUWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_goodsPriceUDB.Delete(goodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_goodsPriceUDB.Insert(goodsPriceUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _goodsPriceUList.Add(goodsPriceUWork);
                        }
                        // DC商品管理情報マスタ更新処理
                        else if (wktype.Equals(typeof(DCGoodsMngWork)))
                        {
                            DCGoodsMngDB _goodsMngDB = new DCGoodsMngDB();
                            DCGoodsMngWork goodsMngWork = (DCGoodsMngWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _goodsMngDB.Delete(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _goodsMngDB.Insert(goodsMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC離島価格マスタ更新処理
                        else if (wktype.Equals(typeof(DCIsolIslandPrcWork)))
                        {
                            DCIsolIslandPrcDB _isolIslandPrcDB = new DCIsolIslandPrcDB();
                            DCIsolIslandPrcWork isolIslandPrcWork = (DCIsolIslandPrcWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _isolIslandPrcDB.Delete(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _isolIslandPrcDB.Insert(isolIslandPrcWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC在庫マスタ更新処理
                        else if (wktype.Equals(typeof(DCStockWork)))
                        {
                            DCStockDB _stockDB = new DCStockDB();
                            DCStockWork stockWork = (DCStockWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _stockDB.Delete(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _stockDB.Insert(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DCユーザーガイドマスタ更新処理
                        else if (wktype.Equals(typeof(DCUserGdBdUWork)))
                        {
                            DCUserGdBdUDB _userGdBdUDB = new DCUserGdBdUDB();
                            DCUserGdBdUWork userGdBdUWork = (DCUserGdBdUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _userGdBdUDB.Delete(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _userGdBdUDB.Insert(userGdBdUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC掛率優先管理マスタ更新処理
                        else if (wktype.Equals(typeof(DCRateProtyMngWork)))
                        {
                            //DCRateProtyMngDB _rateProtyMngDB = new DCRateProtyMngDB();
                            DCRateProtyMngWork rateProtyMngWork = (DCRateProtyMngWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_rateProtyMngDB.Delete(rateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_rateProtyMngDB.Insert(rateProtyMngWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _rateProtyMngList.Add(rateProtyMngWork);
                        }
                        // DC掛率マスタ更新処理
                        else if (wktype.Equals(typeof(DCRateWork)))
                        {
                            //DCRateDB _rateDB = new DCRateDB();
                            DCRateWork rateWork = (DCRateWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_rateDB.Delete(rateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_rateDB.Insert(rateWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _rateList.Add(rateWork);
                        }
                        // DC商品セットマスタ更新処理
                        else if (wktype.Equals(typeof(DCGoodsSetWork)))
                        {
                            //DCGoodsSetDB _goodsSetDB = new DCGoodsSetDB();
                            DCGoodsSetWork goodsSetWork = (DCGoodsSetWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_goodsSetDB.Delete(goodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_goodsSetDB.Insert(goodsSetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _goodsSetList.Add(goodsSetWork);
                        }
                        // DC部品代替マスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCPartsSubstUWork)))
                        {
                            DCPartsSubstUDB _partsSubstUDB = new DCPartsSubstUDB();
                            DCPartsSubstUWork partsSubstUWork = (DCPartsSubstUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _partsSubstUDB.Delete(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _partsSubstUDB.Insert(partsSubstUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC従業員別売上目標設定マスタ更新処理
                        else if (wktype.Equals(typeof(DCEmpSalesTargetWork)))
                        {
                            DCEmpSalesTargetDB _empSalesTargetDB = new DCEmpSalesTargetDB();
                            DCEmpSalesTargetWork empSalesTargetWork = (DCEmpSalesTargetWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _empSalesTargetDB.Delete(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _empSalesTargetDB.Insert(empSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC得意先別売上目標設定マスタ更新処理
                        else if (wktype.Equals(typeof(DCCustSalesTargetWork)))
                        {
                            DCCustSalesTargetDB _custSalesTargetDB = new DCCustSalesTargetDB();
                            DCCustSalesTargetWork custSalesTargetWork = (DCCustSalesTargetWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _custSalesTargetDB.Delete(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _custSalesTargetDB.Insert(custSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC商品別売上目標設定マスタ更新処理
                        else if (wktype.Equals(typeof(DCGcdSalesTargetWork)))
                        {
                            DCGcdSalesTargetDB _gcdSalesTargetDB = new DCGcdSalesTargetDB();
                            DCGcdSalesTargetWork gcdSalesTargetWork = (DCGcdSalesTargetWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _gcdSalesTargetDB.Delete(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _gcdSalesTargetDB.Insert(gcdSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC商品中分類マスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCGoodsGroupUWork)))
                        {
                            DCGoodsGroupUDB _goodsGroupUDB = new DCGoodsGroupUDB();
                            DCGoodsGroupUWork goodsGroupUWork = (DCGoodsGroupUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _goodsGroupUDB.Delete(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _goodsGroupUDB.Insert(goodsGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DCBLグループマスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCBLGroupUWork)))
                        {
                            DCBLGroupUDB _bLGroupUDB = new DCBLGroupUDB();
                            DCBLGroupUWork bLGroupUWork = (DCBLGroupUWork)retCSATemList[j];
                            // 存在するデータを削除する。
                            _bLGroupUDB.Delete(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            // 抽出したデータを登録する。
                            _bLGroupUDB.Insert(bLGroupUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                        // DC結合マスタ（ユーザー登録分）更新処理
                        else if (wktype.Equals(typeof(DCJoinPartsUWork)))
                        {
                            //DCJoinPartsUDB _joinPartsUDB = new DCJoinPartsUDB();
                            DCJoinPartsUWork joinPartsUWork = (DCJoinPartsUWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_joinPartsUDB.Delete(joinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_joinPartsUDB.Insert(joinPartsUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _joinPartsUList.Add(joinPartsUWork);
                        }
                        // DCTBO検索マスタ（ユーザー登録）更新処理
                        else if (wktype.Equals(typeof(DCTBOSearchUWork)))
                        {
                            //DCTBOSearchUDB _tBOSearchUDB = new DCTBOSearchUDB();
                            DCTBOSearchUWork tBOSearchUWork = (DCTBOSearchUWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_tBOSearchUDB.Delete(tBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_tBOSearchUDB.Insert(tBOSearchUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _tboSearchUList.Add(tBOSearchUWork);
                        }
                        // DC部位コードマスタ（ユーザー登録）更新処理
                        else if (wktype.Equals(typeof(DCPartsPosCodeUWork)))
                        {
                            //DCPartsPosCodeUDB _partsPosCodeUDB = new DCPartsPosCodeUDB();
                            DCPartsPosCodeUWork partsPosCodeUWork = (DCPartsPosCodeUWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_partsPosCodeUDB.Delete(partsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_partsPosCodeUDB.Insert(partsPosCodeUWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _partsPosCodeUList.Add(partsPosCodeUWork);
                        }
                        // DCBLコードガイドマスタ更新処理
                        else if (wktype.Equals(typeof(DCBLCodeGuideWork)))
                        {
                            //DCBLCodeGuideDB _bLCodeGuideDB = new DCBLCodeGuideDB();
                            DCBLCodeGuideWork bLCodeGuideWork = (DCBLCodeGuideWork)retCSATemList[j];
                            //// 存在するデータを削除する。
                            //_bLCodeGuideDB.Delete(bLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            //// 抽出したデータを登録する。
                            //_bLCodeGuideDB.Insert(bLCodeGuideWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                            _blCodeGuideList.Add(bLCodeGuideWork);
                        }
                        // DC車種名称マスタ更新処理
                        else if (wktype.Equals(typeof(DCModelNameUWork)))
                        {
                            DCModelNameUDB _modelNameUDB = new DCModelNameUDB();
                            DCModelNameUWork modelNameUWork = (DCModelNameUWork)retCSATemList[j];
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
                    DCCustRateGroupDB _custRateGroupDB = new DCCustRateGroupDB();
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
                    DCGoodsPriceUDB _goodsPriceUDB = new DCGoodsPriceUDB();
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
                    DCRateProtyMngDB _rateProtyMngDB = new DCRateProtyMngDB();
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
                    DCRateDB _rateDB = new DCRateDB();
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
                    DCGoodsSetDB _goodsSetDB = new DCGoodsSetDB();
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
                    DCJoinPartsUDB _joinPartsUDB = new DCJoinPartsUDB();
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
                    DCTBOSearchUDB _tBOSearchUDB = new DCTBOSearchUDB();
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
                    DCPartsPosCodeUDB _partsPosCodeUDB = new DCPartsPosCodeUDB();
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
                    DCBLCodeGuideDB _bLCodeGuideDB = new DCBLCodeGuideDB();
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
                base.WriteErrorLog(ex, "IOWriteMAHNBDB.Read(Connection付) Exception=" + ex.Message);
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

        # region ■ コネクション生成処理 ■
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

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Summary_DB);

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
    }
}
