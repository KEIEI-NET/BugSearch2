//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 棚卸準備処理DBリモートオブジェクト
// プログラム概要   : 棚卸準備処理の実データ操作を行うクラスです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22035 三橋 弘憲
// 作 成 日  2007.04.04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22035 三橋 弘憲
// 作 成 日  2007.08.31  修正内容 : 最終原価法の場合、受託の仕入原単価を強制的に０にする（自社、受託クエリを分ける）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 23012　畠中 啓次朗
// 作 成 日  2008.12.02  修正内容 : PM.NS様に修正 & 不具合修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 23012　畠中 啓次朗
// 作 成 日  2009.01.30  修正内容 : 不具合修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 23012　畠中 啓次朗
// 作 成 日  2009/05/11  修正内容 : 仕様変更&不具合修正( MANTIS ID:13257 )
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 23012　畠中 啓次朗
// 作 成 日  2009/05/22  修正内容 : 仕様変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/11/30  修正内容 : 仕様変更
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 李占川
// 作 成 日  2010/02/20  修正内容 : ①速度アップ対応
//                                  ②PM1005 倉庫の指定区分が「単独」の場合、入力された倉庫コードで正しく抽出されるように変更
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : yangmj
// 作 成 日  2011/01/11  修正内容 : 棚卸障害対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 作 成 日  2011/01/28  修正内容 : readmine#18750、18751の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 作 成 日  2011/01/30  修正内容 : readmine#18780の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2011/02/10  修正内容 : readmine#18863の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2011/02/11  修正内容 : readmine#18876の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : wangf
// 作 成 日  2011/09/02  修正内容 : NSユーザー改良要望一覧_20110629_優先_PM7相違_障害_連番1014の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : wangf
// 作 成 日  2012/03/23  作成内容 : readmine#29109の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮津
// 作 成 日  2012/04/09  修正内容 : 障害修正 商品管理情報の仕入先適用チェック処理を修正
//                                  原価の設定方法を修正、在庫取得クエリに拠点条件を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮津
// 作 成 日  2012/05/21  修正内容 : 追加障害修正 処理速度向上、貸出・来勘不正対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李小路
// 修 正 日  2012/05/25  修正内容 : 2012/06/27配信分、Redmine#29996
//                                  棚卸調査票　棚卸連番が、連番で印字されないの対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : yangyi
// 修 正 日  2012/06/08  修正内容 : 2012/06/27配信分、Redmine#30282
//                                  №1002　棚卸準備処理の改良の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮津
// 作 成 日  2012/06/14  修正内容 : 在庫取得のクエリで拠点コードをintとして扱っていた障害の修正
//                                  終了拠点のみを指定した場合、クエリが不正になる障害の修正
//                                  来勘計上、貸出の仕入先は売上データの値をそのまま使用するよう修正(デグレ)
//----------------------------------------------------------------------------//
// 管理番号  　　　　    作成担当 : 凌小青
// 修 正 日  2012/07/10  修正内容 : Redmine#31103棚卸準備処理の速度改良の対応
//----------------------------------------------------------------------------//
// 管理番号  10901225-00 作成担当 : zhoug
// 作 成 日  2013/03/06  修正内容 : 10901225-00 2013/5/15配信分の緊急対応
//                                  Redmine#34756対応：棚卸準備処理
//----------------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当 : yangyi
// 修 正 日  2013/05/06 修正内容 : 配信分の対応、Redmine#35493 
//                                     棚卸準備処理で、掛率マスタの件数が多い時に、処理時間が長く、且つサーバー負荷が高くなる(#1902)
//----------------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当 : wangl2
// 修 正 日  2013/06/07     修正内容 : Redmine#35788 
//                                     「棚卸準備処理」の原価取得で掛率優先順位が評価されない（№1949）
//                                      エラー発生時原価が登録されない件の対応でエラー処理追加(#8の件)
//----------------------------------------------------------------------------//
// 管理番号  11070149-00    作成担当 : caohh
// 修 正 日  2015/03/06     修正内容 : Redmine#44951
//                                     棚卸準備処理の不具合について対応
//                                     ①原価計算の掛率グループのパラメータの設定を修正
//                                      （グループコードマスタの商品中分類->BLコードマスタの商品中分類に変更）
//                                     ②原価を取得する条件を修正
//                                      （棚卸日>=価格マスタの価格開始日の条件を追加）
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 譚洪
// 修 正 日  2020/06/18  修正内容 : PMKOBETSU-4005 価格マスタ　定価数値変換対応
//----------------------------------------------------------------------------//
// 管理番号  11675035-00    作成担当 : 譚洪
// 修 正 日  2020/07/23     修正内容 : PMKOBETSU-3551 棚卸準備処理を実行すると処理に失敗する現象の解除
//----------------------------------------------------------------------------//
// 管理番号  11770024-00    作成担当 : 譚洪
// 修 正 日  2021/03/16     修正内容 : PMKOBETSU-3551 棚卸準備処理の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Globalization;     //ADD 李小路 2012/05/25 Redmine#29996
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 棚卸準備処理DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 棚卸準備処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22035 三橋 弘憲</br>
    /// <br>Date       : 2007.04.04</br>
    /// <br></br>
    /// <br>UpdateNote : 最終原価法の場合、受託の仕入原単価を強制的に０にする（自社、受託クエリを分ける）</br>
    /// <br>           : 一括インサート時に、棚卸区分がNullで格納されていた部分を修正</br>
    /// <br>Programer  : 22035　三橋 弘憲</br>
    /// <br>Date       : 2007.08.31</br>
    /// <br></br>
    /// <br>UpdateNote : 不具合修正</br>
    /// <br>Programer  : 23012　畠中 啓次朗</br>
    /// <br>Date       : 2008.12.02</br>
    /// <br></br>
    /// <br>UpdateNote : 不具合修正</br>
    /// <br>Programer  : 23012　畠中 啓次朗</br>
    /// <br>Date       : 2009.01.30</br>
    /// <br></br>
    /// <br>UpdateNote : 仕様変更&不具合修正( MANTIS ID:13257 )</br>
    /// <br>Programer  : 23012　畠中 啓次朗</br>
    /// <br>Date       : 2009/05/11</br>
    /// <br></br>
    /// <br>UpdateNote : 仕様変更&不具合修正</br>
    /// <br>Programer  : 23012　畠中 啓次朗</br>
    /// <br>Date       : 2009/05/22</br>
    /// <br></br>
    /// <br>Update Note : 2009/11/30 張凱 保守依頼③対応</br>
    /// <br>             既存データ存在時の処理内容を変更</br>
    /// <br>Update Note : 2010/02/20 李占川 PM1005</br>
    /// <br>             ①速度アップ対応</br>
    /// <br>             ②倉庫の指定区分が「単独」の場合、入力された倉庫コードで正しく抽出されるように変更</br>
    /// <br>Update Note : 2011/01/11 yangmj 棚卸障害対応</br>
    /// <br>Update Note : 2011/09/02 wangf NSユーザー改良要望一覧_20110629_優先_PM7相違_障害_連番1014の対応</br>
    /// <br>Update Note:  2012/03/23 wangf </br>
    /// <br>             redmine#29109の対応</br>
    /// <br>Update Note: 2012/05/25 李小路</br>
    /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
    /// <br>             Redmine#29996　棚卸調査票　棚卸連番が、連番で印字されないの対応</br>
    /// <br>Update Note: 2013/03/06 zhoug</br>
    /// <br>管理番号   ：10901225-00 2013/5/15配信分の緊急対応</br>
    /// <br>             Redmine#34756対応：棚卸準備処理</br>
    /// <br>Update Note: 2013/06/07 wangl2</br>
    /// <br>管理番号   ：10801804-00 2013/06/18配信分</br>
    /// <br>             Redmine#35788：「棚卸準備処理」の原価取得で掛率優先順位が評価されない（№1949）</br>
    /// <br>                             エラー発生時原価が登録されない件の対応でエラー処理追加(#8の件)</br>
    /// <br>Update Note: 2015/03/06 caohh</br>
    /// <br>管理番号   ：11070149-00 Redmine#44951 棚卸準備処理の不具合について対応</br>
    /// <br>Update Note: 2020/06/18 譚洪</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br>           : PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Update Note :2020/07/23 譚洪</br>
    /// <br>管理番号    :11675035-00</br>
    /// <br>             PMKOBETSU-3551 棚卸準備処理を実行すると処理に失敗する現象の解除</br>
    /// <br>Update Note: 2021/03/16 譚洪</br>
    /// <br>管理番号   : 11770024-00</br>
    /// <br>             PMKOBETSU-3551 棚卸準備処理の対応</br> 
    /// <br>           : ①GoodsUnitDataの企業コードが空の件</br>
    /// <br>           : ②掛率優先管理マスタの拠点指定が【全社共通】の場合、拠点分の掛率データを使用されてしまう件</br>
    /// <br>           : ③拠点分の単品設定の掛率データがあり、掛率優先管理マスタに[6A]が存在しない場合、拠点分の単品設定の掛率データを使用されてしまう件</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class InventoryExtDB : RemoteWithAppLockDB, IInventoryExtDB
    {
        // --- ADD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
        /// <summary>DICキーフォーマット</summary>
        private const string ctDicKeyFmt = "{0}-{1:D4}-{2}";
        /// <summary>全社</summary>
        private const string ctALLSection = "00";
        // --- ADD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<

        /// <summary>
        /// 棚卸準備処理DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>														   
        /// <br>Date       : 2007.04.04</br>
        /// </remarks>
        public InventoryExtDB()
            :
        base("MAZAI05116D", "Broadleaf.Application.Remoting.ParamData.StockInventoryExtWork", "INVENTORYDATARF") //基底クラスのコンストラクタ
        {
        }

        #region Search　＊棚卸データ（準備処理履歴）
        /// <summary>
        /// 指定された企業コードの棚卸準備処理LIST(準備処理履歴)を全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retobj">検索結果(準備処理履歴)</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの棚卸準備処理LIST(準備処理履歴)を全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        public int Search(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            return SearchProc(out retobj, paraobj, readMode, logicalMode);
        }

        #region SearchProc
        /// <summary>
        /// 指定された企業コードの棚卸準備処理LIST(準備処理履歴)を全て戻します
        /// </summary>
        /// <param name="retobj">検索結果(準備処理履歴)</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの棚卸準備処理LIST(準備処理履歴)を全て戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        /// <br>Update     : 2007.09.14 Yokokawa  流通.NS用に改造</br>
        /// <br>Update Note: 2011/01/11 yangmj 棚卸障害対応</br>
        private int SearchProc(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            InventoryExtCndtnWork inventoryExtCndtnWork = new InventoryExtCndtnWork();
            retobj = null;

            ArrayList al = new ArrayList();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                inventoryExtCndtnWork = paraobj as InventoryExtCndtnWork;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                SqlCommand sqlCommand = null;

                string sqlDm = "";
                //sqlDm += "SELECT *  FROM INVENTDATAPRERF IDP "; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlDm += "SELECT * FROM INVENTDATAPRERF IDP WITH (READUNCOMMITTED) "; // ADD wangf 2012/03/23 FOR Redmine#29109

                sqlCommand = new SqlCommand(sqlDm, sqlConnection);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, inventoryExtCndtnWork, logicalMode, 0);

                //-----ADD 2011/01/11----->>>>>
                //処理日順⇒処理時間順
                sqlCommand.CommandText += "ORDER BY INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF";
                //-----ADD 2011/01/11-----<<<<<

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    InventDataPreWork wkInventDataPreWork = new InventDataPreWork();

                    #region 値セット
                    wkInventDataPreWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkInventDataPreWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkInventDataPreWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkInventDataPreWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkInventDataPreWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkInventDataPreWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkInventDataPreWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkInventDataPreWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                    wkInventDataPreWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkInventDataPreWork.InventoryPreprDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYPREPRDAYRF"));
                    wkInventDataPreWork.InventoryPreprTim = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYPREPRTIMRF"));
                    wkInventDataPreWork.InventoryProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYPROCDIVRF"));
                    wkInventDataPreWork.WarehouseCodeSt = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODESTRF"));
                    wkInventDataPreWork.WarehouseCodeEd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODEEDRF"));
                    wkInventDataPreWork.ShelfNoSt = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNOSTRF"));
                    wkInventDataPreWork.ShelfNoEd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNOEDRF"));
                    wkInventDataPreWork.StartSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STARTSUPPLIERCODERF"));
                    wkInventDataPreWork.EndSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENDSUPPLIERCODERF"));
                    wkInventDataPreWork.BLGoodsCodeSt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODESTRF"));
                    wkInventDataPreWork.BLGoodsCodeEd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODEEDRF"));
                    wkInventDataPreWork.GoodsMakerCdSt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDSTRF"));
                    wkInventDataPreWork.GoodsMakerCdEd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDEDRF"));
                    wkInventDataPreWork.BLGroupCodeSt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODESTRF"));
                    wkInventDataPreWork.BLGroupCodeEd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODEEDRF"));
                    wkInventDataPreWork.TrtStkExtraDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRTSTKEXTRADIVRF"));
                    wkInventDataPreWork.EntCmpStkExtraDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTCMPSTKEXTRADIVRF"));
                    wkInventDataPreWork.LtInventoryUpdateSt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LTINVENTORYUPDATESTRF"));
                    wkInventDataPreWork.LtInventoryUpdateEd = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LTINVENTORYUPDATEEDRF"));
                    wkInventDataPreWork.SelWarehouseCode1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE1RF"));
                    wkInventDataPreWork.SelWarehouseCode2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE2RF"));
                    wkInventDataPreWork.SelWarehouseCode3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE3RF"));
                    wkInventDataPreWork.SelWarehouseCode4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE4RF"));
                    wkInventDataPreWork.SelWarehouseCode5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE5RF"));
                    wkInventDataPreWork.SelWarehouseCode6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE6RF"));
                    wkInventDataPreWork.SelWarehouseCode7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE7RF"));
                    wkInventDataPreWork.SelWarehouseCode8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE8RF"));
                    wkInventDataPreWork.SelWarehouseCode9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE9RF"));
                    wkInventDataPreWork.SelWarehouseCode10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SELWAREHOUSECODE10RF"));
                    wkInventDataPreWork.InventoryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYDATERF"));
                    wkInventDataPreWork.MngSectionCodeSt = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODESTRF"));// ADD 2011/01/30
                    wkInventDataPreWork.MngSectionCodeEd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODEEDRF"));// ADD 2011/01/30


                    #region  変更前(MA.NS)
                    /*
                    wkInventDataPreWork.CreateDateTime      = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkInventDataPreWork.UpdateDateTime      = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkInventDataPreWork.EnterpriseCode      = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkInventDataPreWork.FileHeaderGuid      = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkInventDataPreWork.UpdEmployeeCode     = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkInventDataPreWork.UpdAssemblyId1      = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkInventDataPreWork.UpdAssemblyId2      = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkInventDataPreWork.LogicalDeleteCode   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                    wkInventDataPreWork.SectionCode         = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkInventDataPreWork.InventoryPreprDay   = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYPREPRDAYRF"));
                    wkInventDataPreWork.InventoryPreprTim   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYPREPRTIMRF"));
                    wkInventDataPreWork.InventoryProcDiv    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYPROCDIVRF"));
                    wkInventDataPreWork.GeneralGoodsExtDiv  = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GENERALGOODSEXTDIVRF"));
                    wkInventDataPreWork.MobileGoodsExtDiv   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOBILEGOODSEXTDIVRF"));
                    wkInventDataPreWork.AcsryGoodsExtDiv    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACSRYGOODSEXTDIVRF"));
                    wkInventDataPreWork.WarehouseCodeSt     = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODESTRF"));
                    wkInventDataPreWork.WarehouseCodeEd     = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODEEDRF"));
                    wkInventDataPreWork.MakerCodeSt         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODESTRF"));
                    wkInventDataPreWork.MakerCodeEd         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODEEDRF"));
                    wkInventDataPreWork.CarrierCdSt         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARRIERCDSTRF"));
                    wkInventDataPreWork.CarrierCdEd         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARRIERCDEDRF"));
                    wkInventDataPreWork.LgGoodsGanreCdSt    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LGGOODSGANRECDSTRF"));
                    wkInventDataPreWork.LgGoodsGanreCdEd    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LGGOODSGANRECDEDRF"));
                    wkInventDataPreWork.MdGoodsGanreCdSt    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MDGOODSGANRECDSTRF"));
                    wkInventDataPreWork.MdGoodsGanreCdEd    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MDGOODSGANRECDEDRF"));
                    wkInventDataPreWork.CellphoneModelCdSt  = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CELLPHONEMODELCDSTRF"));
                    wkInventDataPreWork.CellphoneModelCdEd  = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CELLPHONEMODELCDEDRF"));
                    wkInventDataPreWork.KtGoodsCdSt         = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KTGOODSCDSTRF"));
                    wkInventDataPreWork.KtGoodsCdEd         = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KTGOODSCDEDRF"));
                    wkInventDataPreWork.CmpStkExtraDiv      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPSTKEXTRADIVRF"));
                    wkInventDataPreWork.TrtStkExtraDiv      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRTSTKEXTRADIVRF"));
                    wkInventDataPreWork.EntCmpStkExtraDiv   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTCMPSTKEXTRADIVRF"));
                    wkInventDataPreWork.EntTrtStkExtraDiv   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTTRTSTKEXTRADIVRF"));
                    wkInventDataPreWork.LtInventoryUpdateSt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LTINVENTORYUPDATESTRF"));
                    wkInventDataPreWork.LtInventoryUpdateEd = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LTINVENTORYUPDATEEDRF"));
                    */
                    #endregion  // 変更前(MA.NS)

                    #endregion  // 値セット

                    al.Add(wkInventDataPreWork);

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
                base.WriteErrorLog(ex, "InventoryExtDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (!myReader.IsClosed) myReader.Close();
            sqlConnection.Close();

            retobj = al;
            return status;

        }
        #endregion  // SearchProc
        #endregion  // Search　＊棚卸データ（準備処理履歴）

        #region SearchInventoryDate 棚卸データ検索処理
        /// <summary>
        /// 在庫マスタを検索し、棚卸準備処理LIST(棚卸データ)を全て戻します
        /// </summary>
        /// <param name="retobj">検索結果(棚卸データ)</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="statusMSG">statusに対するメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタを検索し、棚卸準備処理LIST(棚卸データ)を全て戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        public int SearchInventoryDate(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode, out string statusMSG)
        {
            return SearchInventoryDateProc(out retobj, paraobj, logicalMode, out statusMSG);
        }

        /// <summary>
        /// 在庫マスタを検索し、棚卸準備処理LIST(棚卸データ)を全て戻します
        /// </summary>
        /// <param name="retobj">検索結果(棚卸データ)</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="statusMSG">statusに対するメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタを検索し、棚卸準備処理LIST(棚卸データ)を全て戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        /// <br>Update Note: 2013/03/06 zhoug</br>
        /// <br>管理番号   ：10901225-00 2013/5/15配信分の緊急対応</br>
        /// <br>             Redmine#34756対応：棚卸準備処理</br>
        private int SearchInventoryDateProc(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode, out string statusMSG)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            statusMSG = "";
            retobj = null;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTrans = null;
            InventoryExtCndtnWork inventoryExtCndtnWork = null;
            List<InventoryDataWork> al = null;   //棚卸データ
            //ArrayList al = new ArrayList();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    statusMSG = "接続異常です。";
                    return status;
                }

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                inventoryExtCndtnWork = paraobj as InventoryExtCndtnWork;

                #region 排他制御 (倉庫ロック)
                Dictionary<string, string> wareList;
                ArrayList infoList = new ArrayList(); //シェアチェック情報リスト
                if (inventoryExtCndtnWork.WarehouseDiv == 0)
                {
                    status = searchWarehouse(ref inventoryExtCndtnWork, out wareList, ref sqlConnection);
                }
                else
                {
                    wareList = new Dictionary<string, string>();
                    if (inventoryExtCndtnWork.WarehouseCd01 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd01)) wareList.Add(inventoryExtCndtnWork.WarehouseCd01, "");
                    if (inventoryExtCndtnWork.WarehouseCd02 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd02)) wareList.Add(inventoryExtCndtnWork.WarehouseCd02, "");
                    if (inventoryExtCndtnWork.WarehouseCd03 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd03)) wareList.Add(inventoryExtCndtnWork.WarehouseCd03, "");
                    if (inventoryExtCndtnWork.WarehouseCd04 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd04)) wareList.Add(inventoryExtCndtnWork.WarehouseCd04, "");
                    if (inventoryExtCndtnWork.WarehouseCd05 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd05)) wareList.Add(inventoryExtCndtnWork.WarehouseCd05, "");
                    if (inventoryExtCndtnWork.WarehouseCd06 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd06)) wareList.Add(inventoryExtCndtnWork.WarehouseCd06, "");
                    if (inventoryExtCndtnWork.WarehouseCd07 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd07)) wareList.Add(inventoryExtCndtnWork.WarehouseCd07, "");
                    if (inventoryExtCndtnWork.WarehouseCd08 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd08)) wareList.Add(inventoryExtCndtnWork.WarehouseCd08, "");
                    if (inventoryExtCndtnWork.WarehouseCd09 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd09)) wareList.Add(inventoryExtCndtnWork.WarehouseCd09, "");
                    if (inventoryExtCndtnWork.WarehouseCd10 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd10)) wareList.Add(inventoryExtCndtnWork.WarehouseCd10, "");
                }

                sqlTrans = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                if (wareList.Count != 0 || wareList != null)
                {
                    foreach (string wCode in wareList.Keys)
                    {
                        ShareCheckInfo info = new ShareCheckInfo();
                        info.Keys.Add(inventoryExtCndtnWork.EnterpriseCode, ShareCheckType.WareHouse, "", wCode);
                        status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTrans);
                        infoList.Add(info);
                        if (status != 0) return status;
                    }
                }
                #endregion

                #region 在庫マスタ検索処理

                Dictionary<int, SupplierWork> supplierDic = null; // ADD 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理
                //status = SeachProductStock(out al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, 0, logicalMode);  // DEL 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理
                status = SeachProductStock(out al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, 0, logicalMode, supplierDic); // ADD 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理

                if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)  //抽出データがない場合
                {
                    statusMSG = "更新対象がありません。";
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)  //抽出データがある場合
                {
                    ArrayList retlist = new ArrayList();
                    for (int i = 0; i < al.Count; i++)
                    {
                        retlist.Add(al[i]);
                    }

                    // 結果セット
                    retobj = retlist;
                }
                #endregion

                #region 排他制御解除(倉庫ロック)
                if (status == 0 || status == 9)
                {
                    foreach (ShareCheckInfo info in infoList)
                    {
                        int sta = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTrans);
                        if (sta != 0) return status = sta;
                    }
                }
                #endregion

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SearchWriteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (status == 0)
                {
                    sqlTrans.Commit();
                }
                else
                {
                    sqlTrans.Rollback();
                }
                sqlConnection.Close();
                sqlTrans.Dispose();
            }
            return status;
        }

        #endregion

        #region WriteInventoryDate　棚卸データ作成処理
        /// <summary>
        /// 棚卸データListから棚卸データへ更新、登録を行います
        /// </summary>
        /// <param name="retobj">検索結果(準備処理履歴)</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="paraobj2">棚卸データList</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="statusMSG">statusに対するメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データListから棚卸データへ更新、登録を行います</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        public int WriteInventoryDate(out object retobj, object paraobj, object paraobj2, ConstantManagement.LogicalMode logicalMode, out string statusMSG)
        {
            return WriteInventoryDateProc(out retobj, paraobj, paraobj2, logicalMode, out statusMSG);
        }

        /// <summary>
        /// 棚卸データListから棚卸データへ更新、登録を行います
        /// </summary>
        /// <param name="retobj">検索結果(準備処理履歴)</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="paraobj2">棚卸データList</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="statusMSG">statusに対するメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データListから棚卸データへ更新、登録を行います</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        private int WriteInventoryDateProc(out object retobj, object paraobj, object paraobj2, ConstantManagement.LogicalMode logicalMode, out string statusMSG)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            statusMSG = "";
            retobj = null;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTrans = null;

            List<InventoryDataWork> al = null;   //棚卸データ
            al = paraobj2 as List<InventoryDataWork>;

            //#Dictionary<Guid, InventoryDataWork> dic = null;  //棚卸データ(準備処理前データ格納Dictionary)
            Dictionary<String, InventoryDataWork> dic = null;  //棚卸データ(準備処理前データ格納Dictionary)
            InventDataPreWork inventDataPreWork = null;
            InventoryExtCndtnWork inventoryExtCndtnWork = null;

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    statusMSG = "接続異常です。";
                    return status;
                }

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                inventoryExtCndtnWork = paraobj as InventoryExtCndtnWork;

                #region 排他制御(倉庫ロック)
                Dictionary<string, string> wareList;
                ArrayList infoList = new ArrayList(); //シェアチェック情報リスト
                if (inventoryExtCndtnWork.WarehouseDiv == 0)
                {
                    status = searchWarehouse(ref inventoryExtCndtnWork, out wareList, ref sqlConnection);
                }
                else
                {
                    wareList = new Dictionary<string, string>();
                    if (inventoryExtCndtnWork.WarehouseCd01 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd01)) wareList.Add(inventoryExtCndtnWork.WarehouseCd01, "");
                    if (inventoryExtCndtnWork.WarehouseCd02 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd02)) wareList.Add(inventoryExtCndtnWork.WarehouseCd02, "");
                    if (inventoryExtCndtnWork.WarehouseCd03 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd03)) wareList.Add(inventoryExtCndtnWork.WarehouseCd03, "");
                    if (inventoryExtCndtnWork.WarehouseCd04 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd04)) wareList.Add(inventoryExtCndtnWork.WarehouseCd04, "");
                    if (inventoryExtCndtnWork.WarehouseCd05 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd05)) wareList.Add(inventoryExtCndtnWork.WarehouseCd05, "");
                    if (inventoryExtCndtnWork.WarehouseCd06 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd06)) wareList.Add(inventoryExtCndtnWork.WarehouseCd06, "");
                    if (inventoryExtCndtnWork.WarehouseCd07 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd07)) wareList.Add(inventoryExtCndtnWork.WarehouseCd07, "");
                    if (inventoryExtCndtnWork.WarehouseCd08 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd08)) wareList.Add(inventoryExtCndtnWork.WarehouseCd08, "");
                    if (inventoryExtCndtnWork.WarehouseCd09 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd09)) wareList.Add(inventoryExtCndtnWork.WarehouseCd09, "");
                    if (inventoryExtCndtnWork.WarehouseCd10 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd10)) wareList.Add(inventoryExtCndtnWork.WarehouseCd10, "");
                }

                sqlTrans = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                if (wareList.Count != 0 || wareList != null)
                {
                    foreach (string wCode in wareList.Keys)
                    {
                        ShareCheckInfo info = new ShareCheckInfo();
                        info.Keys.Add(inventoryExtCndtnWork.EnterpriseCode, ShareCheckType.WareHouse, "", wCode);
                        status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTrans);
                        infoList.Add(info);
                        if (status != 0) return status = 851;
                    }
                }
                #endregion

                //在庫マスタ検索処理
                //status = SeachProductStock(out al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);

                if ((al == null) || (al.Count == 0))  //抽出データがない場合
                {
                    statusMSG = "更新対象がありません。";
                }
                else  //データがある場合
                {
                    //ここで、
                    //alに登録されている各棚卸データごとに指定された棚卸日における在庫数を求める。
                    //これを各棚卸データの在庫総数とし、マシン在庫額を再計算する。
                    CalcStockTotal(ref al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, 0, logicalMode);

                    int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    // ADD 2009/05/22 >>>
                    // 棚卸データに同一倉庫・メーカー・品番が存在する場合、棚卸処理区分により処理が分岐します。
                    // 参照項目: 棚卸処理区分(InventoryProcDiv)  
                    //           0:準備処理対象にしない ⇒(追加・更新しない)残す
                    //           1:準備処理対象にする   ⇒(削除・追加)
                    //  ADD 2009/05/22 <<<


                    #region 棚卸データ検索処理
                    if (inventoryExtCndtnWork.InventoryProcDiv == 0)
                    {
                        st = SeachInventoryData(out dic, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, 0, logicalMode);
                        if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                        {
                            statusMSG += "棚卸データの検索に失敗しました。";
                            status = st;
                        }
                    }
                    #endregion

                    #region 棚卸データ削除処理
                    //棚卸データ削除判定
                    if (inventoryExtCndtnWork.InventoryProcDiv == 1)
                    {
                        st = DeleteInventoryData(inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, logicalMode, al, dic);
                        if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                        {
                            statusMSG += "棚卸データの削除に失敗しました。";
                            status = st;
                        }
                    }
                    #endregion

                    #region 棚卸データ登録処理
                    if ((st == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (st == (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        st = WriteInventoryData(al, dic, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans);
                        if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                        {
                            statusMSG += "棚卸データの登録に失敗しました。";
                            status = st;
                        }
                        if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                        {
                            statusMSG += "更新対象がありません。";
                        }
                    }
                    #endregion

                    #region 棚卸データ（準備処理履歴）登録処理
                    if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //棚卸データ（準備処理履歴）登録処理
                        #region 値セット
                        inventDataPreWork = new InventDataPreWork();
                        inventDataPreWork.EnterpriseCode = inventoryExtCndtnWork.EnterpriseCode;
                        inventDataPreWork.SectionCode = inventoryExtCndtnWork.SectionCode;
                        inventDataPreWork.InventoryPreprDay = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);
                        inventDataPreWork.InventoryPreprTim = SysTime;
                        inventDataPreWork.InventoryProcDiv = inventoryExtCndtnWork.InventoryProcDiv;
                        inventDataPreWork.WarehouseCodeSt = inventoryExtCndtnWork.StWarehouseCd;
                        inventDataPreWork.WarehouseCodeEd = inventoryExtCndtnWork.EdWarehouseCd;
                        inventDataPreWork.ShelfNoSt = inventoryExtCndtnWork.StWarehouseShelfNo;
                        inventDataPreWork.ShelfNoEd = inventoryExtCndtnWork.EdWarehouseShelfNo;
                        inventDataPreWork.StartSupplierCode = inventoryExtCndtnWork.StCustomerCd;
                        inventDataPreWork.EndSupplierCode = inventoryExtCndtnWork.EdCustomerCd;
                        inventDataPreWork.BLGoodsCodeSt = inventoryExtCndtnWork.StBLGoodsCd;
                        inventDataPreWork.BLGoodsCodeEd = inventoryExtCndtnWork.EdBLGoodsCd;
                        inventDataPreWork.GoodsMakerCdSt = inventoryExtCndtnWork.StMakerCd;
                        inventDataPreWork.GoodsMakerCdEd = inventoryExtCndtnWork.EdMakerCd;
                        inventDataPreWork.StartSupplierCode = inventoryExtCndtnWork.StCustomerCd;
                        inventDataPreWork.EndSupplierCode = inventoryExtCndtnWork.EdCustomerCd;
                        inventDataPreWork.BLGroupCodeSt = inventoryExtCndtnWork.StBLGroupCode;
                        inventDataPreWork.BLGroupCodeEd = inventoryExtCndtnWork.EdBLGroupCode;
                        inventDataPreWork.SelWarehouseCode1 = inventoryExtCndtnWork.WarehouseCd01;
                        inventDataPreWork.SelWarehouseCode2 = inventoryExtCndtnWork.WarehouseCd02;
                        inventDataPreWork.SelWarehouseCode3 = inventoryExtCndtnWork.WarehouseCd03;
                        inventDataPreWork.SelWarehouseCode4 = inventoryExtCndtnWork.WarehouseCd04;
                        inventDataPreWork.SelWarehouseCode5 = inventoryExtCndtnWork.WarehouseCd05;
                        inventDataPreWork.SelWarehouseCode6 = inventoryExtCndtnWork.WarehouseCd06;
                        inventDataPreWork.SelWarehouseCode7 = inventoryExtCndtnWork.WarehouseCd07;
                        inventDataPreWork.SelWarehouseCode8 = inventoryExtCndtnWork.WarehouseCd08;
                        inventDataPreWork.SelWarehouseCode9 = inventoryExtCndtnWork.WarehouseCd09;
                        inventDataPreWork.SelWarehouseCode10 = inventoryExtCndtnWork.WarehouseCd10;
                        inventDataPreWork.InventoryDate = inventoryExtCndtnWork.InventoryDate;
                        #endregion    // 値セット
                        st = WriteInventDataPre(ref inventDataPreWork, ref sqlConnection, ref sqlTrans);

                        if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            statusMSG += "棚卸データ（準備処理履歴）の登録に失敗しました。";
                        }
                        else
                        {
                            ArrayList retArray = new ArrayList();
                            retArray.Add(inventDataPreWork);
                            retobj = retArray;
                        }
                    }
                    #endregion

                    status = st;
                }

                #region 排他制御解除(倉庫ロック)
                if (status == 0 || status == 9)
                {
                    foreach (ShareCheckInfo info in infoList)
                    {
                        int sta = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTrans);
                        if (sta != 0) return status = sta;
                    }
                }
                #endregion

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SearchWriteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (status == 0)
                {
                    sqlTrans.Commit();
                }
                else
                {
                    sqlTrans.Rollback();
                }
                sqlConnection.Close();
                sqlTrans.Dispose();
            }
            return status;

        }

        #endregion

        #region SearchWrite
        /// <summary>
        /// 棚卸準備処理情報を検索し、その情報を登録・更新と、棚卸準備処理LIST(準備処理履歴)を全て戻します
        /// </summary>
        /// <param name="retobj">検索結果(準備処理履歴)</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="statusMSG">statusに対するメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸準備処理情報を検索し、その情報を登録・更新と、棚卸準備処理LIST(準備処理履歴)を全て戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        public int SearchWrite(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, out string statusMSG)
        {
            return SearchWriteProc(out retobj, paraobj, readMode, logicalMode, out statusMSG);
        }

        #region SearchWriteProc
        /// <summary>
        /// 棚卸準備処理情報を検索し、その情報を登録・更新と、棚卸準備処理LIST(準備処理履歴)を全て戻します
        /// </summary>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="retobj">検索結果(準備処理履歴)</param>
        /// <param name="statusMSG">statusに対するメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸準備処理情報を検索し、その情報を登録・更新と、棚卸準備処理LIST(準備処理履歴)を全て戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        /// <br>Update Note : 2011/01/11 yangmj 棚卸障害対応</br>
        /// <br>Update Note: 2013/03/06 zhoug</br>
        /// <br>管理番号   ：10901225-00 2013/5/15配信分の緊急対応</br>
        /// <br>             Redmine#34756対応：棚卸準備処理</br>
        /// <br>Update Note: 2013/06/07 wangl2</br>
        /// <br>管理番号   ：10801804-00 2013/06/18配信分</br>
        /// <br>             Redmine#35788：「棚卸準備処理」の原価取得で掛率優先順位が評価されない（№1949）</br>
        /// <br>                             エラー発生時原価が登録されない件の対応でエラー処理追加(#8の件)</br>
        private int SearchWriteProc(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, out string statusMSG)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            statusMSG = "";
            retobj = null;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTrans = null;

            List<InventoryDataWork> al = null;   //棚卸データ
            //#Dictionary<Guid, InventoryDataWork> dic = null;  //棚卸データ(準備処理前データ格納Dictionary)
            Dictionary<String, InventoryDataWork> dic = null;  //棚卸データ(準備処理前データ格納Dictionary)
            InventDataPreWork inventDataPreWork = null;
            InventoryExtCndtnWork inventoryExtCndtnWork = null;

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    statusMSG = "接続異常です。";
                    return status;
                }

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                inventoryExtCndtnWork = paraobj as InventoryExtCndtnWork;

                // システムロック(倉庫) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>          
                #region システムロック(倉庫)
                Dictionary<string, string> wareList;
                ArrayList infoList = new ArrayList(); //シェアチェック情報リスト
                if (inventoryExtCndtnWork.WarehouseDiv == 0)
                {
                    status = searchWarehouse(ref inventoryExtCndtnWork, out wareList, ref sqlConnection);
                }
                else
                {
                    wareList = new Dictionary<string, string>();
                    if (inventoryExtCndtnWork.WarehouseCd01 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd01)) wareList.Add(inventoryExtCndtnWork.WarehouseCd01, "");
                    if (inventoryExtCndtnWork.WarehouseCd02 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd02)) wareList.Add(inventoryExtCndtnWork.WarehouseCd02, "");
                    if (inventoryExtCndtnWork.WarehouseCd03 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd03)) wareList.Add(inventoryExtCndtnWork.WarehouseCd03, "");
                    if (inventoryExtCndtnWork.WarehouseCd04 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd04)) wareList.Add(inventoryExtCndtnWork.WarehouseCd04, "");
                    if (inventoryExtCndtnWork.WarehouseCd05 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd05)) wareList.Add(inventoryExtCndtnWork.WarehouseCd05, "");
                    if (inventoryExtCndtnWork.WarehouseCd06 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd06)) wareList.Add(inventoryExtCndtnWork.WarehouseCd06, "");
                    if (inventoryExtCndtnWork.WarehouseCd07 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd07)) wareList.Add(inventoryExtCndtnWork.WarehouseCd07, "");
                    if (inventoryExtCndtnWork.WarehouseCd08 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd08)) wareList.Add(inventoryExtCndtnWork.WarehouseCd08, "");
                    if (inventoryExtCndtnWork.WarehouseCd09 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd09)) wareList.Add(inventoryExtCndtnWork.WarehouseCd09, "");
                    if (inventoryExtCndtnWork.WarehouseCd10 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd10)) wareList.Add(inventoryExtCndtnWork.WarehouseCd10, "");
                }

                sqlTrans = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                if (wareList.Count != 0 || wareList != null)
                {
                    foreach (string wCode in wareList.Keys)
                    {
                        ShareCheckInfo info = new ShareCheckInfo();
                        info.Keys.Add(inventoryExtCndtnWork.EnterpriseCode, ShareCheckType.WareHouse, "", wCode);
                        status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTrans);
                        infoList.Add(info);
                        if (status != 0) return status;
                    }
                }
                #endregion
                // システムロック(倉庫) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // ADD 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理 ----->>>>>
                Dictionary<int, SupplierWork> supplierDic = new Dictionary<int, SupplierWork>(); ;    // 仕入先マスタ情報Dictionary
                SupplierDB _supplierDB = new SupplierDB();  // 仕入先マスタDBリモートオブジェクトクラスコンストラクタ
                ArrayList supplierList = new ArrayList();
                SupplierWork supplierWork = new SupplierWork();
                supplierWork.EnterpriseCode = inventoryExtCndtnWork.EnterpriseCode;  // 企業コード
                // 仕入先マスタ情報を取得する
                //status = _supplierDB.Search(out supplierList, supplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTrans);　// 仕入先マスタ情報のリストを取得します DEL 2013/06/07 wangl2 for Redmine#35788
                //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                int status0 = _supplierDB.Search(out supplierList, supplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTrans);　// 仕入先マスタ情報のリストを取得します
                if (status0 != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status0 != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND
                    && status0 != (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    status = status0;
                    return status0;
                }

                //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

                // 仕入先マスタ情報Dictionaryを作成
                foreach (SupplierWork supplierwork in supplierList)
                {
                    if (!supplierDic.ContainsKey(supplierwork.SupplierCd))
                    {
                        supplierDic.Add(supplierwork.SupplierCd, supplierwork);
                    }
                }
                // ADD 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理 -----<<<<<

                //在庫マスタ検索処理
                //status = SeachProductStock(out al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);// DEL 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理 
                status = SeachProductStock(out al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode, supplierDic);// ADD 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理 
                //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    return status;
                }
                //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
                //-----ADD 2011/01/11----->>>>>

                #region 貸出分データ抽出
                //int status1 = SearchLendExtra(ref al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);// DEL 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理 
                int status1 = SearchLendExtra(ref al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode, supplierDic);// ADD 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理 
                //----DEL 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                //if (status1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    status = status1;
                //}
                //----DEL 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
                //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status1 != (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    status = status1;
                    return status1;
                }
                //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
                #endregion
            

                #region 来勘計上分データ抽出

                //int status2 = SearchDelayPayment(ref al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);// DEL 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理 
                int status2 = SearchDelayPayment(ref al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode, supplierDic);// ADD 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理 
                //----DEL 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                //if (status2 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    status = status2;
                //}
                //----DEL 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
                //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status2 != (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    status = status2;
                    return status2;
                }
                //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
                #endregion

                //-----ADD 2011/01/11-----<<<<<

                //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
                //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)  //抽出データがない場合
                {
                    statusMSG = "更新対象がありません。";
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)  //抽出データがある場合
                {
                    //ここで、
                    //alに登録されている各棚卸データごとに指定された棚卸日における在庫数を求める。
                    //これを各棚卸データの在庫総数とし、マシン在庫額を再計算する。
                    CalcStockTotal(ref al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);

                    int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    // ADD 2009/05/22 >>>
                    // 棚卸処理区分により処理が分岐します。
                    // --→ 棚卸データに同一倉庫・メーカー・品番が存在する場合の処理
                    // 参照項目: 棚卸処理区分(InventoryProcDiv)  
                    //           0:準備処理対象にしない ⇒(追加・更新しない)残す
                    //           1:準備処理対象にする   ⇒(削除・追加)
                    //  ADD 2009/05/22 <<<

                    #region 棚卸データ検索処理
                    //棚卸データ削除判定
                    //$-- 2007.09.27 修正
                    //$if ((inventoryExtCndtnWork.InventoryProcDiv == 1) || (inventoryExtCndtnWork.InventoryProcDiv == 0))
                    //${

                    // -------UPD 2009/11/30 ---------->>>>>
                    //if (inventoryExtCndtnWork.InventoryProcDiv == 0) // ADD 2009/05/22
                    //{
                    //    st = SeachInventoryData(out dic, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);
                    //    if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                    //    {
                    //        statusMSG += "棚卸データの検索に失敗しました。";
                    //        status = st;
                    //    }
                    //}

                    st = SeachInventoryData(out dic, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);
                    if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        statusMSG += "棚卸データの検索に失敗しました。";
                        status = st;
                    }
                    // -------UPD 2009/11/30-------<<<<<
                    //$}
                    #endregion

                    #region 棚卸データ削除処理
                    //棚卸データ削除判定
                    if (inventoryExtCndtnWork.InventoryProcDiv == 1)　// ADD 2009/05/22 
                    {
                        st = DeleteInventoryData(inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, logicalMode, al, dic);
                        if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                        {
                            statusMSG += "棚卸データの削除に失敗しました。";
                            status = st;
                        }
                    }
                    #endregion

                    #region 棚卸データ登録処理
                    if ((st == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (st == (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        // -------ADD 2009/11/30 ---------->>>>>
                        if (inventoryExtCndtnWork.InventoryProcDiv == 1)
                        {
                            dic = new Dictionary<string, InventoryDataWork>();
                        }
                        // -------ADD 2009/11/30 ----------<<<<<
                        st = WriteInventoryData(al, dic, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans);
                        if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                        {
                            statusMSG += "棚卸データの登録に失敗しました。";
                            status = st;
                        }
                        if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                        {
                            statusMSG += "更新対象がありません。";
                        }
                    }
                    #endregion

                    #region 棚卸データ（準備処理履歴）登録処理
                    if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //棚卸データ（準備処理履歴）登録処理
                        #region 値セット
                        inventDataPreWork = new InventDataPreWork();

                        inventDataPreWork.EnterpriseCode = inventoryExtCndtnWork.EnterpriseCode;

                        inventDataPreWork.SectionCode = inventoryExtCndtnWork.SectionCode;
                        inventDataPreWork.InventoryPreprDay = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);
                        inventDataPreWork.InventoryPreprTim = SysTime;
                        inventDataPreWork.InventoryProcDiv = inventoryExtCndtnWork.InventoryProcDiv;
                        inventDataPreWork.WarehouseCodeSt = inventoryExtCndtnWork.StWarehouseCd;
                        inventDataPreWork.WarehouseCodeEd = inventoryExtCndtnWork.EdWarehouseCd;
                        inventDataPreWork.ShelfNoSt = inventoryExtCndtnWork.StWarehouseShelfNo;
                        inventDataPreWork.ShelfNoEd = inventoryExtCndtnWork.EdWarehouseShelfNo;
                        inventDataPreWork.StartSupplierCode = inventoryExtCndtnWork.StCustomerCd;
                        inventDataPreWork.EndSupplierCode = inventoryExtCndtnWork.EdCustomerCd;
                        inventDataPreWork.BLGoodsCodeSt = inventoryExtCndtnWork.StBLGoodsCd;
                        inventDataPreWork.BLGoodsCodeEd = inventoryExtCndtnWork.EdBLGoodsCd;
                        inventDataPreWork.GoodsMakerCdSt = inventoryExtCndtnWork.StMakerCd;
                        inventDataPreWork.GoodsMakerCdEd = inventoryExtCndtnWork.EdMakerCd;
                        inventDataPreWork.StartSupplierCode = inventoryExtCndtnWork.StCustomerCd;
                        inventDataPreWork.EndSupplierCode = inventoryExtCndtnWork.EdCustomerCd;
                        inventDataPreWork.BLGroupCodeSt = inventoryExtCndtnWork.StBLGroupCode;
                        inventDataPreWork.BLGroupCodeEd = inventoryExtCndtnWork.EdBLGroupCode;
                        // ----ADD 2011/01/30----->>>>>
                        if (string.IsNullOrEmpty(inventoryExtCndtnWork.SectionCodeSt))
                        {
                            inventDataPreWork.MngSectionCodeSt = "0";
                        }
                        else
                        {
                            inventDataPreWork.MngSectionCodeSt = inventoryExtCndtnWork.SectionCodeSt;
                        }
                        if (string.IsNullOrEmpty(inventoryExtCndtnWork.SectionCodeEd))
                        {
                            inventDataPreWork.MngSectionCodeEd = "99";
                        }
                        else
                        {
                            inventDataPreWork.MngSectionCodeEd = inventoryExtCndtnWork.SectionCodeEd;
                        }
                        // ----ADD 2011/01/30-----<<<<<
                        //inventDataPreWork.LgGoodsGanreCdSt = inventoryExtCndtnWork.StLgGoodsGanreCd;
                        //inventDataPreWork.LgGoodsGanreCdEd = inventoryExtCndtnWork.EdLgGoodsGanreCd;
                        //inventDataPreWork.MdGoodsGanreCdSt = inventoryExtCndtnWork.StMdGoodsGanreCd;
                        //inventDataPreWork.MdGoodsGanreCdEd = inventoryExtCndtnWork.EdMdGoodsGanreCd;
                        //inventDataPreWork.DtlGoodsGanreCdSt = Convert.ToString(inventoryExtCndtnWork.StBLGroupCode);
                        //inventDataPreWork.DtlGoodsGanreCdEd = Convert.ToString(inventoryExtCndtnWork.EdBLGroupCode);
                        //inventDataPreWork.EnterpriseGanreCdSt = inventoryExtCndtnWork.StEnterpriseGanreCode;
                        //inventDataPreWork.EnterpriseGanreCdEd = inventoryExtCndtnWork.EdEnterpriseGanreCode;

                        //inventDataPreWork.CmpStkExtraDiv = inventoryExtCndtnWork.CmpStkExtraDiv;
                        //inventDataPreWork.TrtStkExtraDiv = inventoryExtCndtnWork.TrtStkExtraDiv;
                        //inventDataPreWork.EntCmpStkExtraDiv = inventoryExtCndtnWork.EntCmpStkExtraDiv;
                        //inventDataPreWork.EntTrtStkExtraDiv = inventoryExtCndtnWork.EntTrtStkExtraDiv;
                        //inventDataPreWork.LtInventoryUpdateSt = inventoryExtCndtnWork.LtInventoryUpdateSt;
                        //inventDataPreWork.LtInventoryUpdateEd = inventoryExtCndtnWork.LtInventoryUpdateEd;
                        inventDataPreWork.SelWarehouseCode1 = inventoryExtCndtnWork.WarehouseCd01;
                        inventDataPreWork.SelWarehouseCode2 = inventoryExtCndtnWork.WarehouseCd02;
                        inventDataPreWork.SelWarehouseCode3 = inventoryExtCndtnWork.WarehouseCd03;
                        inventDataPreWork.SelWarehouseCode4 = inventoryExtCndtnWork.WarehouseCd04;
                        inventDataPreWork.SelWarehouseCode5 = inventoryExtCndtnWork.WarehouseCd05;
                        inventDataPreWork.SelWarehouseCode6 = inventoryExtCndtnWork.WarehouseCd06;
                        inventDataPreWork.SelWarehouseCode7 = inventoryExtCndtnWork.WarehouseCd07;
                        inventDataPreWork.SelWarehouseCode8 = inventoryExtCndtnWork.WarehouseCd08;
                        inventDataPreWork.SelWarehouseCode9 = inventoryExtCndtnWork.WarehouseCd09;
                        inventDataPreWork.SelWarehouseCode10 = inventoryExtCndtnWork.WarehouseCd10;
                        inventDataPreWork.InventoryDate = inventoryExtCndtnWork.InventoryDate;

                        #region  変更前(MA.NS)
                        /*
                        inventDataPreWork.EnterpriseCode      = inventoryExtCndtnWork.EnterpriseCode;
                        inventDataPreWork.SectionCode         = inventoryExtCndtnWork.SectionCode;
                        inventDataPreWork.InventoryPreprDay   = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);
                        inventDataPreWork.InventoryPreprTim   = SysTime;
                        inventDataPreWork.InventoryProcDiv    = inventoryExtCndtnWork.InventoryProcDiv;
                        inventDataPreWork.GeneralGoodsExtDiv  = inventoryExtCndtnWork.GeneralGoodsExtDiv;
                        inventDataPreWork.MobileGoodsExtDiv   = inventoryExtCndtnWork.MobileGoodsExtDiv;
                        inventDataPreWork.AcsryGoodsExtDiv    = inventoryExtCndtnWork.AcsryGoodsExtDiv;
                        inventDataPreWork.WarehouseCodeSt     = inventoryExtCndtnWork.StWarehouseCd;
                        inventDataPreWork.WarehouseCodeEd     = inventoryExtCndtnWork.EdWarehouseCd;
                        inventDataPreWork.MakerCodeSt         = inventoryExtCndtnWork.StMakerCd;
                        inventDataPreWork.MakerCodeEd         = inventoryExtCndtnWork.EdMakerCd;
                        inventDataPreWork.CarrierCdSt         = inventoryExtCndtnWork.StCarrierCd;
                        inventDataPreWork.CarrierCdEd         = inventoryExtCndtnWork.EdCarrierCd;
                        inventDataPreWork.LgGoodsGanreCdSt    = inventoryExtCndtnWork.StLgGoodsGanreCd;
                        inventDataPreWork.LgGoodsGanreCdEd    = inventoryExtCndtnWork.EdLgGoodsGanreCd;
                        inventDataPreWork.MdGoodsGanreCdSt    = inventoryExtCndtnWork.StMdGoodsGanreCd;
                        inventDataPreWork.MdGoodsGanreCdEd    = inventoryExtCndtnWork.EdMdGoodsGanreCd;
                        inventDataPreWork.CellphoneModelCdSt  = inventoryExtCndtnWork.StCellphoneModelCd;
                        inventDataPreWork.CellphoneModelCdEd  = inventoryExtCndtnWork.EdCellphoneModelCd;
                        inventDataPreWork.KtGoodsCdSt         = inventoryExtCndtnWork.StGoodsCd;
                        inventDataPreWork.KtGoodsCdEd         = inventoryExtCndtnWork.EdGoodsCd;
                        inventDataPreWork.CmpStkExtraDiv      = inventoryExtCndtnWork.CmpStkExtraDiv;
                        inventDataPreWork.TrtStkExtraDiv      = inventoryExtCndtnWork.TrtStkExtraDiv;
                        inventDataPreWork.EntCmpStkExtraDiv   = inventoryExtCndtnWork.EntCmpStkExtraDiv;
                        inventDataPreWork.EntTrtStkExtraDiv   = inventoryExtCndtnWork.EntTrtStkExtraDiv;
                        inventDataPreWork.LtInventoryUpdateSt = inventoryExtCndtnWork.StLtInventoryUpdate;
                        inventDataPreWork.LtInventoryUpdateEd = inventoryExtCndtnWork.EdLtInventoryUpdate;
                        */
                        #endregion    // 変更前(MA.NS)

                        #endregion    // 値セット
                        st = WriteInventDataPre(ref inventDataPreWork, ref sqlConnection, ref sqlTrans);

                        if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            statusMSG += "棚卸データ（準備処理履歴）の登録に失敗しました。";
                        }
                        else
                        {
                            ArrayList retArray = new ArrayList();
                            retArray.Add(inventDataPreWork);
                            retobj = retArray;
                        }
                    }
                    #endregion

                    status = st;

                    // システムロック解除(倉庫) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    if (status == 0 || status == 9)
                    {
                        foreach (ShareCheckInfo info in infoList)
                        {
                            int sta = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTrans);
                            if (sta != 0) return status = sta;
                        }
                    }
                    // システムロック解除(倉庫) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SearchWriteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (status == 0)
                {
                    sqlTrans.Commit();
                }
                else
                {
                    sqlTrans.Rollback();
                }
                sqlConnection.Close();
                sqlTrans.Dispose();
            }
            return status;
        }
        //-----ADD 2011/01/11----->>>>>
        /// <summary>
        /// 貸出分データ抽出
        /// </summary>
        /// <param name="inventoryExtCndtnWork">棚卸準備処理オブジェクト</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="supplierDic">仕入先マスタ情報Dictionary</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 貸出分データ抽出</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/01/11</br>
        /// <br>UpdateNote : 2011/02/11 朱 猛</br>
        /// <br>             Redmine#18876の対応</br>
        /// <br>Update Note: 2013/03/06 zhoug</br>
        /// <br>管理番号   ：10901225-00 2013/5/15配信分の緊急対応</br>
        /// <br>             Redmine#34756対応：棚卸準備処理</br>
        /// <br>Update Note: 2013/06/07 wangl2</br>
        /// <br>管理番号   ：10801804-00 2013/06/18配信分</br>
        /// <br>             Redmine#35788：「棚卸準備処理」の原価取得で掛率優先順位が評価されない（№1949）</br>
        /// <br>                             エラー発生時原価が登録されない件の対応でエラー処理追加(#8の件)</br>
        /// <br>Update Note :2020/07/23 譚洪</br>
        /// <br>管理番号    :11675035-00</br>
        /// <br>             PMKOBETSU-3551 棚卸準備処理を実行すると処理に失敗する現象の解除</br>
        /// <br>Update Note: 2021/03/16 譚洪</br>
        /// <br>管理番号   : 11770024-00</br>
        /// <br>             PMKOBETSU-3551 棚卸準備処理の対応</br>   
        //private int SearchLendExtra(ref List<InventoryDataWork> al, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode)  // DEL 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理
        private int SearchLendExtra(ref List<InventoryDataWork> al, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode, Dictionary<int, SupplierWork> supplierDic) // ADD 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            ArrayList wkList = new ArrayList();
            // 仕入先取得用
            GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();
            List<GoodsSupplierDataWork> GoodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();

            // 原価算出用
            UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
            List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>(); // 原価計算パラメータオブジェクトリスト
            List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();                // 商品連結データオブジェクトリスト
            List<UnitPriceCalcRetWork> unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();       // 原価計算結果リスト 
            Dictionary<string, RateWork> rateWorkByGoodsNoDic = new Dictionary<string, RateWork>();   // 単品掛率Dic// ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));

            if (al == null)
            {
                al = new List<InventoryDataWork>();
            }

            try
            {
                string SelectDm = "";

                ArrayList resultList = new ArrayList();// ADD 2009/12/25

                // 対象テーブル 売上データ・売上明細データ
                // SalesSlipRF・SalesDetailRF 

                #region SELECT分作成
                SelectDm += "SELECT" + Environment.NewLine;
                SelectDm += " MAIN.ENTERPRISECODERF MAIN_ENTERPRISECODERF" + Environment.NewLine;   // 企業コード
                SelectDm += ", MAIN.SECTIONCODERF MAIN_SECTIONCODERF" + Environment.NewLine;        // 拠点コード
                SelectDm += ", MAIN.WAREHOUSECODERF MAIN_WAREHOUSECODERF" + Environment.NewLine;    // 倉庫コード
                SelectDm += ", MAIN.GOODSMAKERCDRF MAIN_GOODSMAKERCDRF" + Environment.NewLine;      // 商品メーカーコード
                SelectDm += ", MAIN.GOODSNORF MAIN_GOODSNORF" + Environment.NewLine;                // 商品コード
                SelectDm += ", MAIN.BLGROUPCODERF MAIN_BLGROUPCODERF" + Environment.NewLine;        // BLグループコード
                SelectDm += ", MAIN.BLGOODSCODERF MAIN_BLGOODSCODERF" + Environment.NewLine;        // BLコード
                SelectDm += ", MAIN.SUPPLIERCDRF MAIN_SUPPLIERCDRF" + Environment.NewLine;          // 仕入先コード
                SelectDm += ", ACPTANODRREMAINCNTRF" + Environment.NewLine;                         // 発注残数
                SelectDm += ", WH.WAREHOUSENAMERF WH_WAREHOUSENAMERF" + Environment.NewLine;        // 倉庫マスタ・倉庫名称
                SelectDm += ", MAK.MAKERNAMERF MAK_MAKERNAMERF" + Environment.NewLine;              // メーカーマスタ・メーカー名称
                SelectDm += ", BLGR.BLGROUPNAMERF BLGR_BLGROUPNAMERF" + Environment.NewLine;        // グループコードマスタ・グループコード名称
                SelectDm += " ,BLGR.GOODSLGROUPRF AS BLGROUP_GOODSLGROUPRF" + Environment.NewLine;  // 商品大分類コード
                SelectDm += " ,BLGR.GOODSMGROUPRF AS BLGROUP_GOODSMGROUPRF" + Environment.NewLine;  // 商品中分類コード
                SelectDm += " ,GOODS.ENTERPRISEGANRECODERF AS GOODS_ENTERPRISEGANRECODERF" + Environment.NewLine;// 自社分類コード
                SelectDm += " ,GOODS.GOODSRATERANKRF AS GOODS_GOODSRATERANKRF" + Environment.NewLine;// 層別
                SelectDm += " ,GOODS.JANRF AS GOODS_JANRF" + Environment.NewLine;// JANコード
                SelectDm += " ,GOODS.GOODSNAMERF AS GOODSNAMERF" + Environment.NewLine;// JANコード
                SelectDm += ", BLCD.GOODSRATEGRPCODERF BLCD_GOODSRATEGRPCODERF" + Environment.NewLine;// BLコードマスタ・商品掛率グループコード // ADD caohh 2015/03/06 for redmine#44951
                SelectDm += ", BLCD.BLGOODSFULLNAMERF BLCD_BLGOODSFULLNAMERF" + Environment.NewLine;// 商品マスタ・商品名称
                SelectDm += ", SEC.SECTWAREHOUSECD1RF SEC_SECTWAREHOUSECD1RF" + Environment.NewLine;// 拠点情報設定マスタ・優先倉庫１
                SelectDm += ", WH1.WAREHOUSENAMERF WH1_WAREHOUSENAMERF" + Environment.NewLine;        // 倉庫マスタ・倉庫名称(優先倉庫１)
                SelectDm += ", SEC.SECTWAREHOUSECD2RF SEC_SECTWAREHOUSECD2RF" + Environment.NewLine;// 拠点情報設定マスタ・優先倉庫２
                SelectDm += ", WH2.WAREHOUSENAMERF WH2_WAREHOUSENAMERF" + Environment.NewLine;        // 倉庫マスタ・倉庫名称(優先倉庫２)
                SelectDm += ", SEC.SECTWAREHOUSECD3RF SEC_SECTWAREHOUSECD3RF" + Environment.NewLine;// 拠点情報設定マスタ・優先倉庫３
                SelectDm += ", WH3.WAREHOUSENAMERF WH3_WAREHOUSENAMERF" + Environment.NewLine;        // 倉庫マスタ・倉庫名称(優先倉庫３)
                SelectDm += ", MAIN.SALESUNITCOSTRF SALESUNITCOSTRF" + Environment.NewLine;           //原価単価
                SelectDm += ", MAIN.LISTPRICETAXEXCFLRF LISTPRICETAXEXCFLRF" + Environment.NewLine;
                SelectDm += ", MAIN.GOODS_GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;
                //-----ADD 2011/01/11----->>>>>
                SelectDm += " , GOODSPRICE.PRICESTARTDATERF AS GOODSPRICE_PRICESTARTDATERF" + Environment.NewLine; ;// 価格開始日
                SelectDm += " , GOODSPRICE.LISTPRICERF AS GOODSPRICE_LISTPRICERF" + Environment.NewLine; ;// 定価（浮動）

                SelectDm += " , STOCK.STOCKDIVRF AS STOCK_STOCKDIVRF" + Environment.NewLine; ;// 在庫区分
                SelectDm += " , STOCK.LASTSTOCKDATERF AS STOCK_LASTSTOCKDATERF" + Environment.NewLine; ;// 最終仕入年月日

                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                SelectDm += " ,RATE.PRICEFLRF AS RATE_PRICEFLRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEVALRF AS RATE_RATEVALRF " + Environment.NewLine;
                // --- ADD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                SelectDm += " ,RATE.UNPRCFRACPROCUNITRF AS RATE_UNPRCFRACPROCUNITRF " + Environment.NewLine;
                SelectDm += " ,RATE.UNPRCFRACPROCDIVRF AS RATE_UNPRCFRACPROCDIVRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATESETTINGDIVIDERF AS RATE_RATESETTINGDIVIDERF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEMNGGOODSCDRF AS RATE_RATEMNGGOODSCDRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEMNGCUSTCDRF AS RATE_RATEMNGCUSTCDRF " + Environment.NewLine;
                SelectDm += " ,RATE.SECTIONCODERF AS RATE_SECTIONCODERF " + Environment.NewLine;
                SelectDm += " ,RATE.LOTCOUNTRF AS RATE_LOTCOUNTRF " + Environment.NewLine;
                // --- ADD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
                SelectDm += " ,RATE2.PRICEFLRF AS RATE2_PRICEFLRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEVALRF AS RATE2_RATEVALRF " + Environment.NewLine;
                SelectDm += " ,RATE2.UNPRCFRACPROCUNITRF AS RATE2_UNPRCFRACPROCUNITRF " + Environment.NewLine;
                SelectDm += " ,RATE2.UNPRCFRACPROCDIVRF AS RATE2_UNPRCFRACPROCDIVRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATESETTINGDIVIDERF AS RATE2_RATESETTINGDIVIDERF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEMNGGOODSCDRF AS RATE2_RATEMNGGOODSCDRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEMNGCUSTCDRF AS RATE2_RATEMNGCUSTCDRF " + Environment.NewLine;
                SelectDm += " ,RATE2.SECTIONCODERF AS RATE2_SECTIONCODERF " + Environment.NewLine;
                SelectDm += " ,RATE2.LOTCOUNTRF AS RATE2_LOTCOUNTRF " + Environment.NewLine;
                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<

                //-----ADD 2011/01/11-----<<<<<

                SelectDm += "FROM" + Environment.NewLine;
                SelectDm += "(" + Environment.NewLine;
                SelectDm += "SELECT" + Environment.NewLine;
                SelectDm += "SLS.ENTERPRISECODERF ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += ", SLS.RESULTSADDUPSECCDRF SECTIONCODERF" + Environment.NewLine;
                SelectDm += ", SLD.WAREHOUSECODERF WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += ", SLD.GOODSMAKERCDRF GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += ", SLD.GOODSNORF GOODSNORF" + Environment.NewLine;
                SelectDm += ", SLD.BLGROUPCODERF BLGROUPCODERF" + Environment.NewLine;
                SelectDm += ", SLD.BLGOODSCODERF BLGOODSCODERF" + Environment.NewLine;
                SelectDm += ", SLD.SUPPLIERCDRF SUPPLIERCDRF" + Environment.NewLine;
                SelectDm += ", SUM(SLD.ACPTANODRREMAINCNTRF) ACPTANODRREMAINCNTRF" + Environment.NewLine;
                // --- ADD 2009/11/30 ---------->>>>>
                SelectDm += ", SLD.SALESUNITCOSTRF SALESUNITCOSTRF" + Environment.NewLine;
                SelectDm += ", SLD.LISTPRICETAXEXCFLRF LISTPRICETAXEXCFLRF" + Environment.NewLine;
                SelectDm += ", SLD.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;
                // --- ADD 2009/11/30 ----------<<<<<

                //SelectDm += " FROM SALESSLIPRF AS SLS" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " FROM SALESSLIPRF AS SLS WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "LEFT JOIN " + Environment.NewLine;
                //SelectDm += " SALESDETAILRF AS SLD" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " SALESDETAILRF AS SLD WITH (READUNCOMMITTED)" + Environment.NewLine; // DD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " ON" + Environment.NewLine;
                SelectDm += " SLS.ENTERPRISECODERF = SLD.ENTERPRISECODERF AND" + Environment.NewLine;
                SelectDm += " SLS.ACPTANODRSTATUSRF = SLD.ACPTANODRSTATUSRF AND" + Environment.NewLine;
                SelectDm += " SLS.SALESSLIPNUMRF = SLD.SALESSLIPNUMRF" + Environment.NewLine;
                #endregion

                #region WHERE文の作成
                SelectDm += " WHERE" + Environment.NewLine;

                // 売上データ：「受注ｽﾃｰﾀｽ=40：出荷」　AND　売上明細データ：「品番がセットされている」レコード
                SelectDm += " SLS.ACPTANODRSTATUSRF = 40 AND " + Environment.NewLine;
                SelectDm += " SLD.GOODSNORF  != ''" + Environment.NewLine;

                sqlCommand = new SqlCommand(SelectDm, sqlConnection, sqlTrans);

                //企業コード設定
                sqlCommand.CommandText += " AND SLS.ENTERPRISECODERF=@ENTERPRISECODE";
                SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EnterpriseCode);

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand.CommandText += " AND SLS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand.CommandText += " AND SLS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                // 管理拠点
                if (inventoryExtCndtnWork.SectionCodeSt != "")
                {
                    sqlCommand.CommandText += " AND SLS.RESULTSADDUPSECCDRF>=@SECTIONCODEST" + Environment.NewLine;
                    SqlParameter paraSectionCodeSt = sqlCommand.Parameters.Add("@SECTIONCODEST", SqlDbType.NVarChar);
                    paraSectionCodeSt.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeSt);
                }

                if (inventoryExtCndtnWork.SectionCodeEd != "")
                {
                    sqlCommand.CommandText += " AND SLS.RESULTSADDUPSECCDRF<=@SECTIONCODEED" + Environment.NewLine;
                    SqlParameter paraSectionCodeEd = sqlCommand.Parameters.Add("@SECTIONCODEED", SqlDbType.NVarChar);
                    paraSectionCodeEd.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd);
                }

                //先頭～棚卸日までのレコード
                if (inventoryExtCndtnWork.InventoryDate != DateTime.MinValue)
                {
                    int InventoryDate = TDateTime.DateTimeToLongDate("YYYYMMDD", inventoryExtCndtnWork.InventoryDate);
                    sqlCommand.CommandText += " AND SLS.SHIPMENTDAYRF <= " + InventoryDate.ToString() + Environment.NewLine;
                }

                //if (inventoryExtCndtnWork.WarehouseDiv == 0) // 倉庫指定区分 0:範囲,1:単独
                //{

                //    //倉庫コード設定
                //    if (inventoryExtCndtnWork.StWarehouseCd != "")
                //    {
                //        sqlCommand.CommandText += " AND SLD.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                //        SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NVarChar);
                //        paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseCd);
                //    }
                //    if (inventoryExtCndtnWork.EdWarehouseCd!= "")
                //    {
                //        //sqlCommand.CommandText += " AND (SLD.WAREHOUSECODERF<=@EDWAREHOUSECODE OR SLD.WAREHOUSECODERF LIKE @EDWAREHOUSECODE)" + Environment.NewLine; // 2008.10.08 DEL 
                //        sqlCommand.CommandText += " AND SLD.WAREHOUSECODERF<=@EDWAREHOUSECODE " + Environment.NewLine;                                                 // 2008.10.08 ADD
                //        SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NVarChar);
                //        paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseCd + "%");
                //    }
                //}
                //else
                //{
                //    #region 倉庫１～10
                //    if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd07 != "" || inventoryExtCndtnWork.WarehouseCd08 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd09 != "" || inventoryExtCndtnWork.WarehouseCd10 != "")
                //    {
                //        sqlCommand.CommandText += " AND ( ";
                //    }

                //    //倉庫コード01設定
                //    if (inventoryExtCndtnWork.WarehouseCd01 != "")
                //    {
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD01";
                //        SqlParameter paraWarehouseCd01 = sqlCommand.Parameters.Add("@WAREHOUSECD01", SqlDbType.NVarChar);
                //        paraWarehouseCd01.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd01);
                //    }

                //    //倉庫コード02設定
                //    if (inventoryExtCndtnWork.WarehouseCd02 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD02";
                //        SqlParameter paraWarehouseCd02 = sqlCommand.Parameters.Add("@WAREHOUSECD02", SqlDbType.NVarChar);
                //        paraWarehouseCd02.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd02);
                //    }

                //    //倉庫コード03設定
                //    if (inventoryExtCndtnWork.WarehouseCd03 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }

                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD03";
                //        SqlParameter paraWarehouseCd03 = sqlCommand.Parameters.Add("@WAREHOUSECD03", SqlDbType.NVarChar);
                //        paraWarehouseCd03.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd03);
                //    }

                //    //倉庫コード04設定
                //    if (inventoryExtCndtnWork.WarehouseCd04 != "")
                //    {

                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD04";
                //        SqlParameter paraWarehouseCd04 = sqlCommand.Parameters.Add("@WAREHOUSECD04", SqlDbType.NVarChar);
                //        paraWarehouseCd04.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd04);
                //    }

                //    //倉庫コード05設定
                //    if (inventoryExtCndtnWork.WarehouseCd05 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD05";
                //        SqlParameter paraWarehouseCd05 = sqlCommand.Parameters.Add("@WAREHOUSECD05", SqlDbType.NVarChar);
                //        paraWarehouseCd05.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd05);
                //    }

                //    //倉庫コード06設定
                //    if (inventoryExtCndtnWork.WarehouseCd06 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }

                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD06";
                //        SqlParameter paraWarehouseCd06 = sqlCommand.Parameters.Add("@WAREHOUSECD06", SqlDbType.NVarChar);
                //        paraWarehouseCd06.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd06);
                //    }

                //    //倉庫コード07設定
                //    if (inventoryExtCndtnWork.WarehouseCd07 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD07";
                //        SqlParameter paraWarehouseCd07 = sqlCommand.Parameters.Add("@WAREHOUSECD07", SqlDbType.NVarChar);
                //        paraWarehouseCd07.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd07);
                //    }

                //    //倉庫コード08設定
                //    if (inventoryExtCndtnWork.WarehouseCd08 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd07 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD08";
                //        SqlParameter paraWarehouseCd08 = sqlCommand.Parameters.Add("@WAREHOUSECD08", SqlDbType.NVarChar);
                //        paraWarehouseCd08.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd08);
                //    }

                //    //倉庫コード09設定
                //    if (inventoryExtCndtnWork.WarehouseCd09 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd07 != "" || inventoryExtCndtnWork.WarehouseCd08 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD09";
                //        SqlParameter paraWarehouseCd09 = sqlCommand.Parameters.Add("@WAREHOUSECD09", SqlDbType.NVarChar);
                //        paraWarehouseCd09.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd09);
                //    }

                //    //倉庫コード10設定
                //    if (inventoryExtCndtnWork.WarehouseCd10 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd07 != "" || inventoryExtCndtnWork.WarehouseCd08 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd09 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD10";
                //        SqlParameter paraWarehouseCd10 = sqlCommand.Parameters.Add("@WAREHOUSECD10", SqlDbType.NVarChar);
                //        paraWarehouseCd10.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd10);
                //    }
                //    if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd07 != "" || inventoryExtCndtnWork.WarehouseCd08 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd09 != "" || inventoryExtCndtnWork.WarehouseCd10 != "")
                //    {
                //        sqlCommand.CommandText += " ) ";
                //    }
                //    #endregion
                //}

                //棚番設定
                if (inventoryExtCndtnWork.StWarehouseShelfNo != "")
                {
                    sqlCommand.CommandText += " AND SLD.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO" + Environment.NewLine;
                    SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                    paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseShelfNo);
                }
                if (inventoryExtCndtnWork.EdWarehouseShelfNo != "")
                {
                    //sqlCommand.CommandText += " AND (SLD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR SLD.WAREHOUSESHELFNORF LIKE @EDWAREHOUSESHELFNO)" + Environment.NewLine; // 2008.10.08 DEL
                    //sqlCommand.CommandText += " AND SLD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO " + Environment.NewLine;   // 2008.10.08 ADD                  //DEL yangyi 2013/05/06 Redmine#35493
                    sqlCommand.CommandText += " AND ( SLD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR SLD.WAREHOUSESHELFNORF IS NULL )" + Environment.NewLine;   //ADD yangyi 2013/05/06 Redmine#35493 
                    SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                    //paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_inventInputSearchCndtnWork.Ed_WarehouseShelfNo + "%"); // 2008.10.08 DEL
                    paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseShelfNo);        // 2008.10.08 ADD 
                }

                //仕入先コード設定
                if (inventoryExtCndtnWork.StCustomerCd != 0)
                {
                    sqlCommand.CommandText += " AND SLD.SUPPLIERCDRF>=@STSUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
                    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StCustomerCd);
                }
                if (inventoryExtCndtnWork.EdCustomerCd != 999999)
                {
                    sqlCommand.CommandText += " AND SLD.SUPPLIERCDRF<=@EDSUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
                    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdCustomerCd);
                }

                //ＢＬ商品コード設定
                if (inventoryExtCndtnWork.StBLGoodsCd != 0)
                {
                    sqlCommand.CommandText += " AND SLD.BLGOODSCODERF>=@STBLGOODSCODE" + Environment.NewLine;
                    SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                    paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StBLGoodsCd);
                }
                if (inventoryExtCndtnWork.EdBLGoodsCd != 99999)
                {
                    sqlCommand.CommandText += " AND SLD.BLGOODSCODERF<=@EDBLGOODSCODE" + Environment.NewLine;
                    SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                    paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdBLGoodsCd);
                }

                // グループコード設定
                if (inventoryExtCndtnWork.StBLGroupCode != 0)
                {
                    sqlCommand.CommandText += " AND SLD.BLGROUPCODERF>=@STBLGROUPCODE" + Environment.NewLine;
                    SqlParameter paraStBlGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                    paraStBlGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StBLGroupCode);
                }
                if (inventoryExtCndtnWork.EdBLGroupCode != 99999)
                {
                    sqlCommand.CommandText += " AND SLD.BLGROUPCODERF<=@EDBLGROUPCODE" + Environment.NewLine;
                    SqlParameter paraEdBlGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                    paraEdBlGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdBLGroupCode);
                }
                //メーカーコード設定
                if (inventoryExtCndtnWork.StMakerCd != 0)
                {
                    sqlCommand.CommandText += " AND SLD.GOODSMAKERCDRF>=@STMAKERCODE" + Environment.NewLine;
                    SqlParameter paraStMakerCode = sqlCommand.Parameters.Add("@STMAKERCODE", SqlDbType.Int);
                    paraStMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StMakerCd);
                }
                if (inventoryExtCndtnWork.EdMakerCd != 9999)
                {
                    sqlCommand.CommandText += " AND SLD.GOODSMAKERCDRF<=@EDMAKERCODE" + Environment.NewLine;
                    SqlParameter paraEdMakerCode = sqlCommand.Parameters.Add("@EDMAKERCODE", SqlDbType.Int);
                    paraEdMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdMakerCd);
                }

                // --- ADD 2009/11/30 ---------->>>>>
                //受注残数(AcptAnOdrRemainCntRF＝0）は印刷対象外
                sqlCommand.CommandText += " AND SLD.ACPTANODRREMAINCNTRF != 0 " + Environment.NewLine;
                // --- ADD 2009/11/30 ----------<<<<<
                #endregion

                #region GROUP文の作成
                sqlCommand.CommandText += "GROUP BY " + Environment.NewLine;
                sqlCommand.CommandText += "SLS.ENTERPRISECODERF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLS.RESULTSADDUPSECCDRF" + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.WAREHOUSECODERF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.GOODSNORF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.SUPPLIERCDRF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.BLGOODSCODERF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.GOODSMAKERCDRF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.BLGROUPCODERF " + Environment.NewLine;


                // --- ADD 2009/11/30 ---------->>>>>
                sqlCommand.CommandText += ", SLD.SALESUNITCOSTRF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.LISTPRICETAXEXCFLRF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.GOODSNAMERF " + Environment.NewLine;
                // --- ADD 2009/11/30 ----------<<<<<
                sqlCommand.CommandText += ")AS MAIN " + Environment.NewLine;
                #endregion

                #region LEFT JOIN文の作成
                // 拠点情報設定マスタ結合
                //sqlCommand.CommandText += " LEFT JOIN SECINFOSETRF AS SEC ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " SEC.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                sqlCommand.CommandText += " SEC.SECTIONCODERF=MAIN.SECTIONCODERF" + Environment.NewLine;
                // 倉庫マスタ結合
                //sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " WH.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                sqlCommand.CommandText += " WH.WAREHOUSECODERF=MAIN.WAREHOUSECODERF" + Environment.NewLine;
                // 倉庫マスタ結合(優先倉庫１)
                //sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH1 ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH1 WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " WH1.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                sqlCommand.CommandText += " WH1.WAREHOUSECODERF=SEC.SECTWAREHOUSECD1RF" + Environment.NewLine;
                // 倉庫マスタ結合(優先倉庫２)
                //sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH2 ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH2 WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " WH2.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                sqlCommand.CommandText += " WH2.WAREHOUSECODERF=SEC.SECTWAREHOUSECD2RF" + Environment.NewLine;
                // 倉庫マスタ結合(優先倉庫３)
                //sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH3 ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH3 WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " WH3.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                sqlCommand.CommandText += " WH3.WAREHOUSECODERF=SEC.SECTWAREHOUSECD3RF" + Environment.NewLine;
                // メーカーマスタ結合
                //sqlCommand.CommandText += " LEFT JOIN MAKERURF AS MAK ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN MAKERURF AS MAK WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " MAK.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                sqlCommand.CommandText += " MAK.GOODSMAKERCDRF=MAIN.GOODSMAKERCDRF" + Environment.NewLine;
                // 商品マスタ結合
                //sqlCommand.CommandText += " LEFT JOIN GOODSURF AS GOODS ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " GOODS.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                sqlCommand.CommandText += " GOODS.GOODSMAKERCDRF=MAIN.GOODSMAKERCDRF AND" + Environment.NewLine;
                sqlCommand.CommandText += " GOODS.GOODSNORF=MAIN.GOODSNORF" + Environment.NewLine;
                // グループコードマスタ結合
                //sqlCommand.CommandText += " LEFT JOIN BLGROUPURF AS BLGR ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN BLGROUPURF AS BLGR WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " BLGR.BLGROUPCODERF=MAIN.BLGROUPCODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND BLGR.ENTERPRISECODERF=MAIN.ENTERPRISECODERF";
                // BLコードマスタ結合
                //sqlCommand.CommandText += " LEFT JOIN BLGOODSCDURF AS BLCD ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN BLGOODSCDURF AS BLCD WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " BLCD.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                sqlCommand.CommandText += " BLCD.BLGOODSCODERF = MAIN.BLGOODSCODERF" + Environment.NewLine;
                //-----ADD 2011/01/11----->>>>>
                int inventoryDateGoods = TDateTime.DateTimeToLongDate("YYYYMMDD", inventoryExtCndtnWork.InventoryDate);

                //sqlCommand.CommandText += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " ON MAIN.ENTERPRISECODERF = GOODSPRICE.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSMAKERCDRF = GOODSPRICE.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSNORF = GOODSPRICE.GOODSNORF " + Environment.NewLine;
                sqlCommand.CommandText += " AND GOODSPRICE.PRICESTARTDATERF  <=" + inventoryDateGoods.ToString() + Environment.NewLine;

                //sqlCommand.CommandText += " LEFT JOIN STOCKRF AS STOCK" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN STOCKRF AS STOCK WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " ON MAIN.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSNORF = STOCK.GOODSNORF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.WAREHOUSECODERF = STOCK.WAREHOUSECODERF" + Environment.NewLine;

                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                sqlCommand.CommandText += " LEFT JOIN RATERF AS RATE WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlCommand.CommandText += " ON MAIN.ENTERPRISECODERF = RATE.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.SECTIONCODERF = RATE.SECTIONCODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSMAKERCDRF = RATE.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSNORF = RATE.GOODSNORF" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.UNITRATESETDIVCDRF = '26A'" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.GOODSRATERANKRF    = ''" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.GOODSRATEGRPCODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.BLGROUPCODERF      = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.BLGOODSCODERF      = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.CUSTOMERCODERF     = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.CUSTRATEGRPCODERF  = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.SUPPLIERCDRF       = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.LOTCOUNTRF         = 9999999.99" + Environment.NewLine;
                sqlCommand.CommandText += " LEFT JOIN RATERF AS RATE2 WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlCommand.CommandText += " ON MAIN.ENTERPRISECODERF = RATE2.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.SECTIONCODERF = '00'" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSMAKERCDRF = RATE2.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSNORF = RATE2.GOODSNORF" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.UNITRATESETDIVCDRF = '26A'" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.GOODSRATERANKRF    = ''" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.GOODSRATEGRPCODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.BLGROUPCODERF      = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.BLGOODSCODERF      = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.CUSTOMERCODERF     = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.CUSTRATEGRPCODERF  = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.SUPPLIERCDRF       = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.LOTCOUNTRF         = 9999999.99" + Environment.NewLine;
                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<

                //-----ADD 2011/01/11-----<<<<<

                #endregion

                //結果取得
                sqlCommand.CommandTimeout = 3600; // ADD 2012/05/21
                myReader = sqlCommand.ExecuteReader();
                //----- ADD 2011/01/11----->>>>>
                InventoryDataWork beInventoryDataWork = null;
                //----- ADD 2011/01/11-----<<<<<
                //-----ADD 2011/01/28 ----->>>>>
                string WarehouseCodeStr = string.Empty;
                //-----ADD 2011/01/28 -----<<<<<

                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                string sectionCode = string.Empty;
                //int goodsMakerCd = 0;// DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応
                //string goodsNo = string.Empty;// DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応
                string keyValue = string.Empty;
                //RateWork rateW = null;// DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応
                RateWork rateAllSec = null;
                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<

                while (myReader.Read())
                {
                    #region 抽出結果セット
                    InventoryDataWork inventoryDataWork = new InventoryDataWork();
                    inventoryDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));
                    inventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_WAREHOUSECODERF"));
                    inventoryDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));
                    inventoryDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));
                    inventoryDataWork.GoodsNoSrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));
                    inventoryDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF"));
                    //---DEL 2011/02/11 ----->>>
                    //if (string.IsNullOrEmpty(inventoryDataWork.GoodsName))
                    //{
                    //    inventoryDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    //}
                    //---DEL 2011/02/11 -----<<<
                    inventoryDataWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGROUPCODERF"));
                    inventoryDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGOODSCODERF"));
                    inventoryDataWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_SUPPLIERCDRF"));
                    inventoryDataWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
                    inventoryDataWork.InventoryDate = inventoryExtCndtnWork.InventoryDate;
                    inventoryDataWork.WarehouseShelfNo = "ｶｼﾀﾞｼ";
                    inventoryDataWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    inventoryDataWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));

                    inventoryDataWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSLGROUPRF"));              // 商品大分類コード  
                    inventoryDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));              // BLグループコード  
                    inventoryDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_ENTERPRISEGANRECODERF"));// 自社分類コード
                    inventoryDataWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));            // 変更前仕入単価
                    inventoryDataWork.InventoryPreprDay = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);                      // 棚卸準備処理日
                    inventoryDataWork.InventoryPreprTim = SysTime;                                                                                    // 棚卸準備処理時間
                    inventoryDataWork.LastInventoryUpdate = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);                    // 最終棚卸更新日 
                    inventoryDataWork.StockMashinePrice = Convert.ToInt64(inventoryDataWork.StockUnitPriceFl * inventoryDataWork.StockTotal);　       // マシン在庫額
                    inventoryDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_JANRF"));                               // 商品マスタ・JANコード
                    inventoryDataWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCK_STOCKDIVRF"));
                    inventoryDataWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCK_LASTSTOCKDATERF")); // 最終仕入年月日
                    //-----ADD 2011/01/28 ----->>>>>
                    if (beInventoryDataWork != null)
                    {
                        if (beInventoryDataWork.EnterpriseCode == inventoryDataWork.EnterpriseCode
                            && beInventoryDataWork.SectionCode == inventoryDataWork.SectionCode
                            && WarehouseCodeStr == inventoryDataWork.WarehouseCode
                            && beInventoryDataWork.GoodsMakerCd == inventoryDataWork.GoodsMakerCd
                            && beInventoryDataWork.GoodsNo == inventoryDataWork.GoodsNo
                            && beInventoryDataWork.BLGroupCode == inventoryDataWork.BLGroupCode
                            && beInventoryDataWork.SupplierCd == inventoryDataWork.SupplierCd
                            && beInventoryDataWork.StockUnitPriceFl == inventoryDataWork.StockUnitPriceFl
                            && beInventoryDataWork.ListPriceFl == inventoryDataWork.ListPriceFl
                            && beInventoryDataWork.GoodsName == inventoryDataWork.GoodsName)
                        {
                            continue;
                        }
                    }
                    WarehouseCodeStr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_WAREHOUSECODERF")); // ADD 2011/01/28
                    //-----ADD 2011/01/28 -----<<<<<

                    if (string.IsNullOrEmpty(inventoryDataWork.WarehouseCode))
                    {
                        inventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD1RF"));
                    }
                    if (string.IsNullOrEmpty(inventoryDataWork.WarehouseCode))
                    {
                        inventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD2RF"));
                    }
                    if (string.IsNullOrEmpty(inventoryDataWork.WarehouseCode))
                    {
                        inventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD3RF"));
                    }

                    //-----ADD 2011/01/28 ----->>>>>
                    String warehouseCode = inventoryDataWork.WarehouseCode.Trim();
                    // 倉庫指定区分 0:範囲,1:単独
                    if (inventoryExtCndtnWork.WarehouseDiv == 0)
                    {
                        if ((inventoryExtCndtnWork.StWarehouseCd != "" && inventoryExtCndtnWork.StWarehouseCd.CompareTo(warehouseCode) > 0) ||
                            (inventoryExtCndtnWork.EdWarehouseCd != "" && inventoryExtCndtnWork.EdWarehouseCd.CompareTo(warehouseCode) < 0))
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (inventoryExtCndtnWork.WarehouseCd01 != "" ||
                            inventoryExtCndtnWork.WarehouseCd02 != "" ||
                            inventoryExtCndtnWork.WarehouseCd03 != "" ||
                            inventoryExtCndtnWork.WarehouseCd04 != "" ||
                            inventoryExtCndtnWork.WarehouseCd05 != "" ||
                            inventoryExtCndtnWork.WarehouseCd06 != "" ||
                            inventoryExtCndtnWork.WarehouseCd07 != "" ||
                            inventoryExtCndtnWork.WarehouseCd08 != "" ||
                            inventoryExtCndtnWork.WarehouseCd09 != "" ||
                            inventoryExtCndtnWork.WarehouseCd10 != "")
                        {
                            if (!((inventoryExtCndtnWork.WarehouseCd01 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd01) ||
                                (inventoryExtCndtnWork.WarehouseCd02 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd02) ||
                                (inventoryExtCndtnWork.WarehouseCd03 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd03) ||
                                (inventoryExtCndtnWork.WarehouseCd04 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd04) ||
                                (inventoryExtCndtnWork.WarehouseCd05 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd05) ||
                                (inventoryExtCndtnWork.WarehouseCd06 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd06) ||
                                (inventoryExtCndtnWork.WarehouseCd07 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd07) ||
                                (inventoryExtCndtnWork.WarehouseCd08 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd08) ||
                                (inventoryExtCndtnWork.WarehouseCd09 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd09) ||
                                (inventoryExtCndtnWork.WarehouseCd10 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd10)))
                            {
                                continue;
                            }
                        }
                    }
                    //-----ADD 2011/01/28 -----<<<<<

                    if (!string.IsNullOrEmpty(inventoryDataWork.WarehouseCode))
                    {
                        //-----DEL 2011/01/28 ----->>>>>
                        //if (beInventoryDataWork != null)
                        //{
                        //    if (beInventoryDataWork.EnterpriseCode == inventoryDataWork.EnterpriseCode
                        //        && beInventoryDataWork.SectionCode == inventoryDataWork.SectionCode
                        //        && beInventoryDataWork.WarehouseCode == inventoryDataWork.WarehouseCode
                        //        && beInventoryDataWork.GoodsMakerCd == inventoryDataWork.GoodsMakerCd
                        //        && beInventoryDataWork.GoodsNo == inventoryDataWork.GoodsNo
                        //        && beInventoryDataWork.BLGroupCode == inventoryDataWork.BLGroupCode
                        //        && beInventoryDataWork.SupplierCd == inventoryDataWork.SupplierCd
                        //        && beInventoryDataWork.StockUnitPriceFl == inventoryDataWork.StockUnitPriceFl
                        //        && beInventoryDataWork.ListPriceFl == inventoryDataWork.ListPriceFl
                        //        && beInventoryDataWork.GoodsName == inventoryDataWork.GoodsName)
                        //    {
                        //        continue;
                        //    }
                        //}
                        //-----DEL 2011/01/28 -----<<<<<
                        //---DEL 2011/02/11 ----->>>
                        //if (inventoryDataWork.ListPriceFl == 0)
                        //{
                        //    inventoryDataWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICE_LISTPRICERF"));
                        //}
                        //---DEL 2011/02/11 -----<<<
                        beInventoryDataWork = inventoryDataWork;
                        resultList.Add(inventoryDataWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // -- DEL 2012/05/21 ------------------>>>>
                    //下に移動
                    //}
                    //#endregion
                    // -- DEL 2012/05/21 ------------------<<<<

                        GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
                        UnitPriceCalcParamWork unitPriceCalcParam = new UnitPriceCalcParamWork();
                        GoodsUnitDataWork goodsUnitData = new GoodsUnitDataWork(); // 商品連結データオブジェクトリスト

                        #region 商品仕入取得データクラス
                        goodsSupplierDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_ENTERPRISECODERF"));// 企業コード
                        goodsSupplierDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));      // 拠点コード
                        goodsSupplierDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));     // メーカーコード
                        goodsSupplierDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));              // 商品番号
                        goodsSupplierDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGOODSCODERF"));     // BLコード
                        goodsSupplierDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));   // 商品中分類コード
                        GoodsSupplierDataWorkList.Add(goodsSupplierDataWork);
                        #endregion

                        #region 単価算出モジュール計算用パラメータ
                        unitPriceCalcParam.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));   // 拠点コード
                        unitPriceCalcParam.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));  // メーカーコード
                        unitPriceCalcParam.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));           // 商品番号
                        //unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));　 // 商品中分類コード // DEL caohh 2015/03/06 for Redmine#44951 
                        unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCD_GOODSRATEGRPCODERF"));　 // 商品掛率グループコード // ADD caohh  2015/03/06 for Redmine#44951 
                        unitPriceCalcParam.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGROUPCODERF"));// BLグループコード
                        unitPriceCalcParam.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGOODSCODERF"));  // BLコード
                        //unitPriceCalcParam.PriceApplyDate = DateTime.Now;// DEL caohh for Redmine#44951 
                        unitPriceCalcParam.PriceApplyDate = inventoryExtCndtnWork.InventoryDate;// ADD caohh  2015/03/06 for Redmine#44951 
                        unitPriceCalcParam.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSRATERANKRF"));  // 層別
                        unitPriceCalcParamList.Add(unitPriceCalcParam);
                        #endregion

                        #region 商品連結データリスト
                        goodsUnitData.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_ENTERPRISECODERF"));// 企業コード
                        goodsUnitData.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));              // 商品番号
                        goodsUnitData.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));     // メーカーコード
                        goodsUnitDataList.Add(goodsUnitData);
                        #endregion

                        // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                        #region 単品掛率リスト

                        //拠点分単品掛率
                        // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                        //sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));   // 拠点コード
                        //goodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));     // メーカーコード
                        //goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));           // 商品番号
                        ////keyValue = sectionCode.Trim() + "-" + goodsMakerCd.ToString("D4") + "-" + goodsNo.Trim();
                        //if (!rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        keyValue = string.Format(ctDicKeyFmt, inventoryDataWork.SectionCode.Trim(), inventoryDataWork.GoodsMakerCd, inventoryDataWork.GoodsNo.Trim());
                        sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_SECTIONCODERF"));
                        //当商品の拠点分単品がある場合、単品dicに追加
                        if (!string.IsNullOrEmpty(sectionCode) && !rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
                        {
                            // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                            //rateW = new RateWork();
                            //rateW.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_RATEVALRF"));
                            //rateW.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_PRICEFLRF"));
                            //rateWorkByGoodsNoDic.Add(keyValue, rateW);
                            rateAllSec = new RateWork();
                            rateAllSec.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_RATEVALRF"));
                            rateAllSec.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_PRICEFLRF"));
                            rateAllSec.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_UNPRCFRACPROCUNITRF"));
                            rateAllSec.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATE_UNPRCFRACPROCDIVRF"));
                            rateAllSec.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATESETTINGDIVIDERF"));
                            rateAllSec.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATEMNGGOODSCDRF"));
                            rateAllSec.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATEMNGCUSTCDRF"));
                            rateAllSec.SectionCode = sectionCode;
                            rateAllSec.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_LOTCOUNTRF"));
                            rateWorkByGoodsNoDic.Add(keyValue, rateAllSec);
                            // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
                        }

                        //全社単品掛率
                        // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                        //keyValue = "00" + "-" + goodsMakerCd.ToString("D4") + "-" + goodsNo.Trim(); 
                        keyValue = string.Format(ctDicKeyFmt, ctALLSection, inventoryDataWork.GoodsMakerCd, inventoryDataWork.GoodsNo.Trim());
                        // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
                        sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_SECTIONCODERF"));
                        //全社単品がある場合、単品dicに追加
                        if (!string.IsNullOrEmpty(sectionCode) && !rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        {
                            rateAllSec = new RateWork();
                            rateAllSec.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_RATEVALRF"));
                            rateAllSec.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_PRICEFLRF"));
                            rateAllSec.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_UNPRCFRACPROCUNITRF"));
                            rateAllSec.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATE2_UNPRCFRACPROCDIVRF"));
                            rateAllSec.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATESETTINGDIVIDERF"));
                            rateAllSec.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATEMNGGOODSCDRF"));
                            rateAllSec.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATEMNGCUSTCDRF"));
                            rateAllSec.SectionCode = sectionCode;
                            rateAllSec.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_LOTCOUNTRF"));
                            rateWorkByGoodsNoDic.Add(keyValue, rateAllSec);
                        }
                        #endregion
                        // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<

                    // -- ADD 2012/05/21 ------------------>>>>
                    }
                    #endregion
                    // -- ADD 2012/05/21 ------------------<<<<
                }

                if (!myReader.IsClosed) myReader.Close();

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 商品仕入先情報取得処理 実行
                    goodsSupplierGetter.GetGoodsMngInfo(ref GoodsSupplierDataWorkList);

                    #region 商品仕入先情報取得処理 結果セット
                    // 商品仕入先情報取得処理により取得した仕入先を
                    // 単価算出パラメータ・棚卸データワークにセット
                    for (int i = 0; i < GoodsSupplierDataWorkList.Count; i++) // 商品仕入取得データクラス
                    {
                        // -- UPD 2012/05/21 ------------------------------------------------>>>>
                        #region DEL 無駄ループを削除、配列番号で紐付けるよう変更する。
                        //for (int j = 0; j < unitPriceCalcParamList.Count; j++) // 単価算出モジュール計算用パラメータ
                        //{
                        //    if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[j].GoodsMakerCd) && // 商品メーカー
                        //        (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[j].GoodsNo) &&           // 商品番号
                        //        (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[j].BLGoodsCode))     // BL商品コード
                        //    {
                        //        if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                        //        {
                        //            unitPriceCalcParamList[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // 仕入先セット
                        //        }
                        //    }
                        //}

                        //for (int j = 0; j < al.Count; j++) // 棚卸データワーク
                        //{
                        //    if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == al[j].GoodsMakerCd) && // 商品メーカー
                        //        (GoodsSupplierDataWorkList[i].GoodsNo == al[j].GoodsNo) &&           // 商品番号
                        //        (GoodsSupplierDataWorkList[i].BLGoodsCode == al[j].BLGoodsCode))     // BL商品コード
                        //    {
                        //        if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                        //        {
                        //            al[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // 仕入先セット
                        //        }
                        //    }
                        //}
                        #endregion
                        if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[i].GoodsMakerCd) && // 商品メーカー
                            (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[i].GoodsNo) &&           // 商品番号
                            (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[i].BLGoodsCode) &&   // BL商品コード
                            (GoodsSupplierDataWorkList[i].GoodsMakerCd == ((InventoryDataWork)resultList[i]).GoodsMakerCd) && // 商品メーカー
                            (GoodsSupplierDataWorkList[i].GoodsNo == ((InventoryDataWork)resultList[i]).GoodsNo) &&           // 商品番号
                            (GoodsSupplierDataWorkList[i].BLGoodsCode == ((InventoryDataWork)resultList[i]).BLGoodsCode))     // BL商品コード
                        {
                            if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                            {
                                unitPriceCalcParamList[i].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd;
                                //((InventoryDataWork)resultList[i]).SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // DEL 2012/06/14
                                // ADD 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理 ----->>>>>
                                if (supplierDic != null && supplierDic.ContainsKey(unitPriceCalcParamList[i].SupplierCd))
                                {
                                    unitPriceCalcParamList[i].StockUnPrcFrcProcCd = supplierDic[unitPriceCalcParamList[i].SupplierCd].StockUnPrcFrcProcCd;
                                }
                                // ADD 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理 -----<<<<<
                            }
                        }
                        else
                        {
                            throw new Exception("商品管理情報と棚卸データの紐付きが不正です。（貸出分データ抽出）: " + 
                                                i.ToString() + " : " +
                                                GoodsSupplierDataWorkList[i].GoodsMakerCd.ToString() + ", " +
                                                GoodsSupplierDataWorkList[i].GoodsNo.ToString() + " : " +
                                                unitPriceCalcParamList[i].GoodsMakerCd.ToString() + ", " +
                                                unitPriceCalcParamList[i].GoodsNo.ToString() + " : " +
                                                ((InventoryDataWork)resultList[i]).GoodsMakerCd.ToString() + ", " +
                                                ((InventoryDataWork)resultList[i]).GoodsNo.ToString());
                        }
                        // -- UPD 2012/05/21 ------------------------------------------------<<<<
                    }
                    #endregion

                    //原価算出処理 実行
                    //unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);//DEL 2012/07/10 for Redmine#31103
                    //unitPriceCalculation.CalculateUnitCostForInventory(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);//ADD 2012/07/10 for Redmine#31103 // DEL 2013/06/07 wangl2 For Redmine#35788
                    //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                    // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                    //status = unitPriceCalculation.CalculateUnitCostForInventory(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);
                    status = unitPriceCalculation.CalculateUnitCostForInventory2(unitPriceCalcParamList, goodsUnitDataList, rateWorkByGoodsNoDic, out unitPriceCalcRetList);
                    // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        return status;
                    }
                    //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

                    #region 原価算出処理 結果セット
                    // 原価算出処理により取得した原価を
                    // 在庫履歴データクラスにセット
                    for (int i = 0; i < unitPriceCalcRetList.Count; i++) // 単価計算結果
                    {
                        // -- UPD 2012/05/21 ------------------------------------------------>>>>
                        #region DEL 無駄ループ削除、配列番号で紐付けるよう変更する
                        //for (int j = 0; j < resultList.Count; j++) // 棚卸データクラス
                        //{
                        //    if ((unitPriceCalcRetList[i].GoodsMakerCd == ((InventoryDataWork)resultList[j]).GoodsMakerCd) && // 商品メーカー
                        //        (unitPriceCalcRetList[i].GoodsNo == ((InventoryDataWork)resultList[j]).GoodsNo))     // BL商品コード
                        //    {
                        //        if (((InventoryDataWork)resultList[j]).StockUnitPriceFl == 0)
                        //        {
                        //            // 仕入単価
                        //            ((InventoryDataWork)resultList[j]).StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                        //            // 変更前仕入単価
                        //            ((InventoryDataWork)resultList[j]).BfStockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;

                        //        }
                        //        double adjstCalcCost = 0;
                        //        FractionCalculate.FracCalcMoney(unitPriceCalcRetList[i].UnitPriceTaxExcFl, 0.01, 1, out adjstCalcCost);
                        //        ((InventoryDataWork)resultList[j]).AdjstCalcCost = adjstCalcCost;
                        //    }
                        //}
                        #endregion
                        if ((unitPriceCalcRetList[i].GoodsMakerCd == ((InventoryDataWork)resultList[i]).GoodsMakerCd) && // 商品メーカー
                            (unitPriceCalcRetList[i].GoodsNo == ((InventoryDataWork)resultList[i]).GoodsNo))     // BL商品コード
                        {
                            if (((InventoryDataWork)resultList[i]).StockUnitPriceFl == 0)
                            {
                                // 仕入単価
                                ((InventoryDataWork)resultList[i]).StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                                // 変更前仕入単価
                                ((InventoryDataWork)resultList[i]).BfStockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                                
                            }
                            // 調製用計算原価
                            double adjstCalcCost = 0;
                            FractionCalculate.FracCalcMoney(unitPriceCalcRetList[i].UnitPriceTaxExcFl, 0.01, 1, out adjstCalcCost);
                            ((InventoryDataWork)resultList[i]).AdjstCalcCost = adjstCalcCost;
                        }
                        else
                        {
                            throw new Exception("原価算出結果と棚卸データの紐付きが不正です。（貸出分データ抽出）" +
                                                i.ToString() + " : " +
                                                unitPriceCalcRetList[i].GoodsMakerCd.ToString() + ", " +
                                                unitPriceCalcRetList[i].GoodsNo.ToString() + " : " +
                                                ((InventoryDataWork)resultList[i]).GoodsMakerCd.ToString() + ", " +
                                                ((InventoryDataWork)resultList[i]).GoodsNo.ToString());
                        }
                        // -- UPD 2012/05/21 ------------------------------------------------<<<<
                    }
                    #endregion

                    #region 仕入先コード抽出条件
                    for (int i = 0; i < resultList.Count; i++) // 棚卸データワーク
                    {
                        if ((inventoryExtCndtnWork.StCustomerCd <= ((InventoryDataWork)resultList[i]).SupplierCd) &&
                            (inventoryExtCndtnWork.EdCustomerCd >= ((InventoryDataWork)resultList[i]).SupplierCd))
                        {
                            wkList.Add((InventoryDataWork)resultList[i]);
                        }
                    }
                    #endregion

                    resultList = wkList;

                }
                //-----UPD 2011/01/28 ----->>>>>
                //SortData(resultList, ref al);

                //SortDataOrderList(ref al);
                List<InventoryDataWork> alResultList = null;
                SortData(resultList, out alResultList);

                SortDataOrderList(ref al, alResultList);
                //-----UPD 2011/01/28 -----<<<<<
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SeachInventoryData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 来勘計上分データ抽出
        /// </summary>
        /// <param name="inventoryExtCndtnWork">棚卸準備処理オブジェクト</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="supplierDic">仕入先マスタ情報Dictionary</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 来勘計上分データ抽出</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/01/11</br>
        /// <br>UpdateNote : 2011/02/11 朱 猛</br>
        /// <br>             Redmine#18876の対応</br>
        /// <br>Update Note: 2013/03/06 zhoug</br>
        /// <br>管理番号   ：10901225-00 2013/5/15配信分の緊急対応</br>
        /// <br>             Redmine#34756対応：棚卸準備処理</br>
        /// <br>Update Note: 2013/06/07 wangl2</br>
        /// <br>管理番号   ：10801804-00 2013/06/18配信分</br>
        /// <br>             Redmine#35788：「棚卸準備処理」の原価取得で掛率優先順位が評価されない（№1949）</br>
        /// <br>                             エラー発生時原価が登録されない件の対応でエラー処理追加(#8の件)</br>
        /// <br>Update Note :2020/07/23 譚洪</br>
        /// <br>管理番号    :11675035-00</br>
        /// <br>             PMKOBETSU-3551 棚卸準備処理を実行すると処理に失敗する現象の解除</br>
        /// <br>Update Note: 2021/03/16 譚洪</br>
        /// <br>管理番号   : 11770024-00</br>
        /// <br>             PMKOBETSU-3551 棚卸準備処理の対応</br> 
        //private int SearchDelayPayment(ref List<InventoryDataWork> al, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode)  // DEL 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理
        private int SearchDelayPayment(ref List<InventoryDataWork> al, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode, Dictionary<int, SupplierWork> supplierDic)  // ADD 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            ArrayList wkList = new ArrayList();
            // 仕入先取得用
            GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();
            List<GoodsSupplierDataWork> GoodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();

            // 原価算出用
            UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
            List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>(); // 原価計算パラメータオブジェクトリスト
            List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();                // 商品連結データオブジェクトリスト
            List<UnitPriceCalcRetWork> unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();       // 原価計算結果リスト 
            Dictionary<string, RateWork> rateWorkByGoodsNoDic = new Dictionary<string, RateWork>();   // 単品掛率Dic // ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));

            if (al == null)
            {
                al = new List<InventoryDataWork>();
            }

            try
            {
                string SelectDm = "";
                // 対象テーブル 売上データ・売上明細データ
                ArrayList resultList = new ArrayList();

                #region SELECT分作成
                SelectDm += "SELECT" + Environment.NewLine;
                SelectDm += " MAIN.ENTERPRISECODERF MAIN_ENTERPRISECODERF" + Environment.NewLine;   // 企業コード
                SelectDm += ", MAIN.SECTIONCODERF MAIN_SECTIONCODERF" + Environment.NewLine;        // 拠点コード
                SelectDm += ", MAIN.WAREHOUSECODERF MAIN_WAREHOUSECODERF" + Environment.NewLine;    // 倉庫コード
                SelectDm += ", MAIN.GOODSMAKERCDRF MAIN_GOODSMAKERCDRF" + Environment.NewLine;      // 商品メーカーコード
                SelectDm += ", MAIN.GOODSNORF MAIN_GOODSNORF" + Environment.NewLine;                // 商品コード
                SelectDm += ", MAIN.BLGROUPCODERF MAIN_BLGROUPCODERF" + Environment.NewLine;        // BLグループコード
                SelectDm += ", MAIN.BLGOODSCODERF MAIN_BLGOODSCODERF" + Environment.NewLine;        // BLコード
                SelectDm += ", MAIN.SUPPLIERCDRF MAIN_SUPPLIERCDRF" + Environment.NewLine;          // 仕入先コード
                SelectDm += ", ACPTANODRREMAINCNTRF" + Environment.NewLine;                         // 発注残数
                SelectDm += ", WH.WAREHOUSENAMERF WH_WAREHOUSENAMERF" + Environment.NewLine;        // 倉庫マスタ・倉庫名称
                SelectDm += ", MAK.MAKERNAMERF MAK_MAKERNAMERF" + Environment.NewLine;              // メーカーマスタ・メーカー名称
                SelectDm += ", BLGR.BLGROUPNAMERF BLGR_BLGROUPNAMERF" + Environment.NewLine;        // グループコードマスタ・グループコード名称
                SelectDm += " ,BLGR.GOODSLGROUPRF AS BLGROUP_GOODSLGROUPRF" + Environment.NewLine;  // 商品大分類コード
                SelectDm += " ,BLGR.GOODSMGROUPRF AS BLGROUP_GOODSMGROUPRF" + Environment.NewLine;  // 商品中分類コード
                SelectDm += " ,GOODS.ENTERPRISEGANRECODERF AS GOODS_ENTERPRISEGANRECODERF" + Environment.NewLine;// 自社分類コード
                SelectDm += " ,GOODS.GOODSRATERANKRF AS GOODS_GOODSRATERANKRF" + Environment.NewLine;// 層別
                SelectDm += " ,GOODS.JANRF AS GOODS_JANRF" + Environment.NewLine;// JANコード
                SelectDm += " ,GOODS.GOODSNAMERF AS GOODSNAMERF" + Environment.NewLine;// JANコード
                SelectDm += ", BLCD.GOODSRATEGRPCODERF BLCD_GOODSRATEGRPCODERF" + Environment.NewLine;// BLコードマスタ・商品掛率グループコード　// ADD caohh  2015/03/06 for Redmine#44951
                SelectDm += ", BLCD.BLGOODSFULLNAMERF BLCD_BLGOODSFULLNAMERF" + Environment.NewLine;// 商品マスタ・商品名称
                SelectDm += ", SEC.SECTWAREHOUSECD1RF SEC_SECTWAREHOUSECD1RF" + Environment.NewLine;// 拠点情報設定マスタ・優先倉庫１
                SelectDm += ", WH1.WAREHOUSENAMERF WH1_WAREHOUSENAMERF" + Environment.NewLine;        // 倉庫マスタ・倉庫名称(優先倉庫１)
                SelectDm += ", SEC.SECTWAREHOUSECD2RF SEC_SECTWAREHOUSECD2RF" + Environment.NewLine;// 拠点情報設定マスタ・優先倉庫２
                SelectDm += ", WH2.WAREHOUSENAMERF WH2_WAREHOUSENAMERF" + Environment.NewLine;        // 倉庫マスタ・倉庫名称(優先倉庫２)
                SelectDm += ", SEC.SECTWAREHOUSECD3RF SEC_SECTWAREHOUSECD3RF" + Environment.NewLine;// 拠点情報設定マスタ・優先倉庫３
                SelectDm += ", WH3.WAREHOUSENAMERF WH3_WAREHOUSENAMERF" + Environment.NewLine;        // 倉庫マスタ・倉庫名称(優先倉庫３)
                SelectDm += ", MAIN.SALESUNITCOSTRF SALESUNITCOSTRF" + Environment.NewLine;
                SelectDm += ", MAIN.LISTPRICETAXEXCFLRF LISTPRICETAXEXCFLRF" + Environment.NewLine;
                SelectDm += ", MAIN.GOODS_GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;
                SelectDm += ", MAIN.SHIPMENTCNTRF " + Environment.NewLine;
                SelectDm += " , GOODSPRICE.PRICESTARTDATERF AS GOODSPRICE_PRICESTARTDATERF" + Environment.NewLine; ;// 価格開始日
                SelectDm += " , GOODSPRICE.LISTPRICERF AS GOODSPRICE_LISTPRICERF" + Environment.NewLine; ;// 定価（浮動）
                SelectDm += " , STOCK.STOCKDIVRF AS STOCK_STOCKDIVRF" + Environment.NewLine; ;// 在庫区分
                SelectDm += " , STOCK.LASTSTOCKDATERF AS STOCK_LASTSTOCKDATERF" + Environment.NewLine; ;// 最終仕入年月日
                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                SelectDm += " ,RATE.PRICEFLRF AS RATE_PRICEFLRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEVALRF AS RATE_RATEVALRF " + Environment.NewLine;
                // --- ADD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                SelectDm += " ,RATE.UNPRCFRACPROCUNITRF AS RATE_UNPRCFRACPROCUNITRF " + Environment.NewLine;
                SelectDm += " ,RATE.UNPRCFRACPROCDIVRF AS RATE_UNPRCFRACPROCDIVRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATESETTINGDIVIDERF AS RATE_RATESETTINGDIVIDERF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEMNGGOODSCDRF AS RATE_RATEMNGGOODSCDRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEMNGCUSTCDRF AS RATE_RATEMNGCUSTCDRF " + Environment.NewLine;
                SelectDm += " ,RATE.SECTIONCODERF AS RATE_SECTIONCODERF " + Environment.NewLine;
                SelectDm += " ,RATE.LOTCOUNTRF AS RATE_LOTCOUNTRF " + Environment.NewLine;
                // --- ADD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
                SelectDm += " ,RATE2.PRICEFLRF AS RATE2_PRICEFLRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEVALRF AS RATE2_RATEVALRF " + Environment.NewLine;
                SelectDm += " ,RATE2.UNPRCFRACPROCUNITRF AS RATE2_UNPRCFRACPROCUNITRF " + Environment.NewLine;
                SelectDm += " ,RATE2.UNPRCFRACPROCDIVRF AS RATE2_UNPRCFRACPROCDIVRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATESETTINGDIVIDERF AS RATE2_RATESETTINGDIVIDERF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEMNGGOODSCDRF AS RATE2_RATEMNGGOODSCDRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEMNGCUSTCDRF AS RATE2_RATEMNGCUSTCDRF " + Environment.NewLine;
                SelectDm += " ,RATE2.SECTIONCODERF AS RATE2_SECTIONCODERF " + Environment.NewLine;
                SelectDm += " ,RATE2.LOTCOUNTRF AS RATE2_LOTCOUNTRF " + Environment.NewLine;
                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<

                SelectDm += "FROM" + Environment.NewLine;
                SelectDm += "(" + Environment.NewLine;
                SelectDm += "SELECT" + Environment.NewLine;
                SelectDm += "SLS.ENTERPRISECODERF ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += ", SLS.RESULTSADDUPSECCDRF SECTIONCODERF" + Environment.NewLine;
                SelectDm += ", SLD.WAREHOUSECODERF WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += ", SLD.GOODSMAKERCDRF GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += ", SLD.GOODSNORF GOODSNORF" + Environment.NewLine;
                SelectDm += ", SLD.BLGROUPCODERF BLGROUPCODERF" + Environment.NewLine;
                SelectDm += ", SLD.BLGOODSCODERF BLGOODSCODERF" + Environment.NewLine;
                SelectDm += ", SLD.SUPPLIERCDRF SUPPLIERCDRF" + Environment.NewLine;
                SelectDm += ", SUM(SLD.ACPTANODRREMAINCNTRF) ACPTANODRREMAINCNTRF" + Environment.NewLine;
                SelectDm += ", SUM(SLD.SHIPMENTCNTRF) SHIPMENTCNTRF" + Environment.NewLine;
                SelectDm += ", SLD.SALESUNITCOSTRF SALESUNITCOSTRF" + Environment.NewLine;
                SelectDm += ", SLD.LISTPRICETAXEXCFLRF LISTPRICETAXEXCFLRF" + Environment.NewLine;
                SelectDm += ", SLD.GOODSNAMERF GOODS_GOODSNAMERF" + Environment.NewLine;

                //SelectDm += " FROM SALESSLIPRF AS SLS" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " FROM SALESSLIPRF AS SLS WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "LEFT JOIN " + Environment.NewLine;
                //SelectDm += " SALESDETAILRF AS SLD" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " SALESDETAILRF AS SLD WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " ON" + Environment.NewLine;
                SelectDm += " SLS.ENTERPRISECODERF = SLD.ENTERPRISECODERF AND" + Environment.NewLine;
                SelectDm += " SLS.ACPTANODRSTATUSRF = SLD.ACPTANODRSTATUSRF AND" + Environment.NewLine;
                SelectDm += " SLS.SALESSLIPNUMRF = SLD.SALESSLIPNUMRF" + Environment.NewLine;
                #endregion

                #region WHERE文の作成
                SelectDm += " WHERE" + Environment.NewLine;
                //売上データ：「受注ｽﾃｰﾀｽ=30：売上」　AND　売上明細データ：「品番がセットされている」レコード
                SelectDm += " SLS.ACPTANODRSTATUSRF = 30 AND " + Environment.NewLine;
                SelectDm += " SLD.GOODSNORF  != ''" + Environment.NewLine;

                sqlCommand = new SqlCommand(SelectDm, sqlConnection, sqlTrans);


                //企業コード設定
                sqlCommand.CommandText += " AND SLS.ENTERPRISECODERF=@ENTERPRISECODE";
                SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EnterpriseCode);

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand.CommandText += " AND SLS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand.CommandText += " AND SLS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                // 管理拠点
                if (inventoryExtCndtnWork.SectionCodeSt != "")
                {
                    sqlCommand.CommandText += " AND SLS.RESULTSADDUPSECCDRF>=@SECTIONCODEST" + Environment.NewLine;
                    SqlParameter paraSectionCodeSt = sqlCommand.Parameters.Add("@SECTIONCODEST", SqlDbType.NVarChar);
                    paraSectionCodeSt.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeSt);
                }

                if (inventoryExtCndtnWork.SectionCodeEd != "")
                {
                    sqlCommand.CommandText += " AND SLS.RESULTSADDUPSECCDRF<=@SECTIONCODEED" + Environment.NewLine;
                    SqlParameter paraSectionCodeEd = sqlCommand.Parameters.Add("@SECTIONCODEED", SqlDbType.NVarChar);
                    paraSectionCodeEd.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd);
                }

                //棚卸日以降のレコード（計上日で判断する）
                if (inventoryExtCndtnWork.InventoryDate != DateTime.MinValue)
                {
                    int InventoryDate = TDateTime.DateTimeToLongDate("YYYYMMDD", inventoryExtCndtnWork.InventoryDate);
                    sqlCommand.CommandText += " AND SLS.ADDUPADATERF > " + InventoryDate.ToString() + Environment.NewLine;
                }

                //-----DEL 2011/01/28 ----->>>>>
                //if (inventoryExtCndtnWork.WarehouseDiv == 0) // 倉庫指定区分 0:範囲,1:単独
                //{
                //    //倉庫コード設定
                //    if (inventoryExtCndtnWork.StWarehouseCd != "")
                //    {
                //        sqlCommand.CommandText += " AND SLD.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                //        SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NVarChar);
                //        paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseCd);
                //    }
                //    if (inventoryExtCndtnWork.EdWarehouseCd != "")
                //    {
                //        sqlCommand.CommandText += " AND SLD.WAREHOUSECODERF<=@EDWAREHOUSECODE " + Environment.NewLine;
                //        SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NVarChar);
                //        paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseCd);
                //    }
                //}
                //else
                //{
                //    #region 単独倉庫指定
                //    if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd07 != "" || inventoryExtCndtnWork.WarehouseCd08 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd09 != "" || inventoryExtCndtnWork.WarehouseCd10 != "")
                //    {
                //        sqlCommand.CommandText += " AND ( ";
                //    }

                //    //倉庫コード01設定
                //    if (inventoryExtCndtnWork.WarehouseCd01 != "")
                //    {
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD01";
                //        SqlParameter paraWarehouseCd01 = sqlCommand.Parameters.Add("@WAREHOUSECD01", SqlDbType.NVarChar);
                //        paraWarehouseCd01.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd01);
                //    }

                //    //倉庫コード02設定
                //    if (inventoryExtCndtnWork.WarehouseCd02 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD02";
                //        SqlParameter paraWarehouseCd02 = sqlCommand.Parameters.Add("@WAREHOUSECD02", SqlDbType.NVarChar);
                //        paraWarehouseCd02.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd02);
                //    }

                //    //倉庫コード03設定
                //    if (inventoryExtCndtnWork.WarehouseCd03 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }

                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD03";
                //        SqlParameter paraWarehouseCd03 = sqlCommand.Parameters.Add("@WAREHOUSECD03", SqlDbType.NVarChar);
                //        paraWarehouseCd03.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd03);
                //    }

                //    //倉庫コード04設定
                //    if (inventoryExtCndtnWork.WarehouseCd04 != "")
                //    {

                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD04";
                //        SqlParameter paraWarehouseCd04 = sqlCommand.Parameters.Add("@WAREHOUSECD04", SqlDbType.NVarChar);
                //        paraWarehouseCd04.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd04);
                //    }

                //    //倉庫コード05設定
                //    if (inventoryExtCndtnWork.WarehouseCd05 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD05";
                //        SqlParameter paraWarehouseCd05 = sqlCommand.Parameters.Add("@WAREHOUSECD05", SqlDbType.NVarChar);
                //        paraWarehouseCd05.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd05);
                //    }

                //    //倉庫コード06設定
                //    if (inventoryExtCndtnWork.WarehouseCd06 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }

                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD06";
                //        SqlParameter paraWarehouseCd06 = sqlCommand.Parameters.Add("@WAREHOUSECD06", SqlDbType.NVarChar);
                //        paraWarehouseCd06.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd06);
                //    }

                //    //倉庫コード07設定
                //    if (inventoryExtCndtnWork.WarehouseCd07 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD07";
                //        SqlParameter paraWarehouseCd07 = sqlCommand.Parameters.Add("@WAREHOUSECD07", SqlDbType.NVarChar);
                //        paraWarehouseCd07.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd07);
                //    }

                //    //倉庫コード08設定
                //    if (inventoryExtCndtnWork.WarehouseCd08 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd07 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD08";
                //        SqlParameter paraWarehouseCd08 = sqlCommand.Parameters.Add("@WAREHOUSECD08", SqlDbType.NVarChar);
                //        paraWarehouseCd08.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd08);
                //    }

                //    //倉庫コード09設定
                //    if (inventoryExtCndtnWork.WarehouseCd09 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd07 != "" || inventoryExtCndtnWork.WarehouseCd08 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD09";
                //        SqlParameter paraWarehouseCd09 = sqlCommand.Parameters.Add("@WAREHOUSECD09", SqlDbType.NVarChar);
                //        paraWarehouseCd09.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd09);
                //    }

                //    //倉庫コード10設定
                //    if (inventoryExtCndtnWork.WarehouseCd10 != "")
                //    {
                //        if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd07 != "" || inventoryExtCndtnWork.WarehouseCd08 != "" ||
                //            inventoryExtCndtnWork.WarehouseCd09 != "")
                //        {
                //            sqlCommand.CommandText += " OR ";
                //        }
                //        sqlCommand.CommandText += " SLD.WAREHOUSECODERF=@WAREHOUSECD10";
                //        SqlParameter paraWarehouseCd10 = sqlCommand.Parameters.Add("@WAREHOUSECD10", SqlDbType.NVarChar);
                //        paraWarehouseCd10.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd10);
                //    }
                //    if (inventoryExtCndtnWork.WarehouseCd01 != "" || inventoryExtCndtnWork.WarehouseCd02 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd03 != "" || inventoryExtCndtnWork.WarehouseCd04 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd05 != "" || inventoryExtCndtnWork.WarehouseCd06 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd07 != "" || inventoryExtCndtnWork.WarehouseCd08 != "" ||
                //        inventoryExtCndtnWork.WarehouseCd09 != "" || inventoryExtCndtnWork.WarehouseCd10 != "")
                //    {
                //        sqlCommand.CommandText += " ) ";
                //    }
                //    #endregion

                //}
                //-----DEL 2011/01/28 -----<<<<<

                //棚番設定
                if (inventoryExtCndtnWork.StWarehouseShelfNo != "")
                {
                    sqlCommand.CommandText += " AND SLD.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO" + Environment.NewLine;
                    SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                    paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseShelfNo);
                }
                if (inventoryExtCndtnWork.EdWarehouseShelfNo != "")
                {
                    //sqlCommand.CommandText += " AND SLD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO " + Environment.NewLine;                                                       // 2008.10.08 ADD  //DEL yangyi 2013/05/06 Redmine#35493
                    sqlCommand.CommandText += " AND ( SLD.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR SLD.WAREHOUSESHELFNORF IS NULL ) " + Environment.NewLine;                   // 2008.10.08 ADD  //ADD yangyi 2013/05/06 Redmine#35493
                    SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                    paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseShelfNo);
                }

                //仕入先コード設定
                if (inventoryExtCndtnWork.StCustomerCd != 0)
                {
                    sqlCommand.CommandText += " AND SLD.SUPPLIERCDRF>=@STSUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
                    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StCustomerCd);
                }
                if (inventoryExtCndtnWork.EdCustomerCd != 999999)
                {
                    sqlCommand.CommandText += " AND SLD.SUPPLIERCDRF<=@EDSUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
                    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdCustomerCd);
                }

                //ＢＬ商品コード設定
                if (inventoryExtCndtnWork.StBLGoodsCd != 0)
                {
                    sqlCommand.CommandText += " AND SLD.BLGOODSCODERF>=@STBLGOODSCODE" + Environment.NewLine;
                    SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                    paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StBLGoodsCd);
                }
                if (inventoryExtCndtnWork.EdBLGoodsCd != 99999)
                {
                    sqlCommand.CommandText += " AND SLD.BLGOODSCODERF<=@EDBLGOODSCODE" + Environment.NewLine;
                    SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                    paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdBLGoodsCd);
                }

                // グループコード設定
                if (inventoryExtCndtnWork.StBLGroupCode != 0)
                {
                    sqlCommand.CommandText += " AND SLD.BLGROUPCODERF>=@STBLGROUPCODE" + Environment.NewLine;
                    SqlParameter paraStBlGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                    paraStBlGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StBLGroupCode);
                }
                if (inventoryExtCndtnWork.EdBLGroupCode != 99999)
                {
                    sqlCommand.CommandText += " AND SLD.BLGROUPCODERF<=@EDBLGROUPCODE" + Environment.NewLine;
                    SqlParameter paraEdBlGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                    paraEdBlGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdBLGroupCode);
                }
                //メーカーコード設定
                if (inventoryExtCndtnWork.StMakerCd != 0)
                {
                    sqlCommand.CommandText += " AND SLD.GOODSMAKERCDRF>=@STMAKERCODE" + Environment.NewLine;
                    SqlParameter paraStMakerCode = sqlCommand.Parameters.Add("@STMAKERCODE", SqlDbType.Int);
                    paraStMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StMakerCd);
                }
                if (inventoryExtCndtnWork.EdMakerCd != 999)
                {
                    sqlCommand.CommandText += " AND SLD.GOODSMAKERCDRF<=@EDMAKERCODE" + Environment.NewLine;
                    SqlParameter paraEdMakerCode = sqlCommand.Parameters.Add("@EDMAKERCODE", SqlDbType.Int);
                    paraEdMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdMakerCd);
                }

                #endregion

                #region GROUP文の作成
                sqlCommand.CommandText += "GROUP BY " + Environment.NewLine;
                sqlCommand.CommandText += "SLS.ENTERPRISECODERF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLS.RESULTSADDUPSECCDRF" + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.WAREHOUSECODERF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.GOODSNORF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.SUPPLIERCDRF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.BLGOODSCODERF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.GOODSMAKERCDRF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.BLGROUPCODERF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.SALESUNITCOSTRF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.LISTPRICETAXEXCFLRF " + Environment.NewLine;
                sqlCommand.CommandText += ", SLD.GOODSNAMERF " + Environment.NewLine;
                sqlCommand.CommandText += ")AS MAIN " + Environment.NewLine;
                #endregion

                #region LEFT JOIN文の作成
                // 拠点情報設定マスタ結合
                //sqlCommand.CommandText += " LEFT JOIN SECINFOSETRF AS SEC ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " SEC.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                sqlCommand.CommandText += " SEC.SECTIONCODERF=MAIN.SECTIONCODERF" + Environment.NewLine;
                // 倉庫マスタ結合
                //sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " WH.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                sqlCommand.CommandText += " WH.WAREHOUSECODERF=MAIN.WAREHOUSECODERF" + Environment.NewLine;
                // 倉庫マスタ結合(優先倉庫１)
                //sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH1 ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH1 WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " WH1.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                sqlCommand.CommandText += " WH1.WAREHOUSECODERF=SEC.SECTWAREHOUSECD1RF" + Environment.NewLine;
                // 倉庫マスタ結合(優先倉庫２)
                //sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH2 ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH2 WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " WH2.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                sqlCommand.CommandText += " WH2.WAREHOUSECODERF=SEC.SECTWAREHOUSECD2RF" + Environment.NewLine;
                // 倉庫マスタ結合(優先倉庫３)
                //sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH3 ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN WAREHOUSERF AS WH3 WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " WH3.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND " + Environment.NewLine;
                sqlCommand.CommandText += " WH3.WAREHOUSECODERF=SEC.SECTWAREHOUSECD3RF" + Environment.NewLine;
                // メーカーマスタ結合
                //sqlCommand.CommandText += " LEFT JOIN MAKERURF AS MAK ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN MAKERURF AS MAK WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " MAK.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                sqlCommand.CommandText += " MAK.GOODSMAKERCDRF=MAIN.GOODSMAKERCDRF" + Environment.NewLine;
                // 商品マスタ結合
                //sqlCommand.CommandText += " LEFT JOIN GOODSURF AS GOODS ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " GOODS.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                sqlCommand.CommandText += " GOODS.GOODSMAKERCDRF=MAIN.GOODSMAKERCDRF AND" + Environment.NewLine;
                sqlCommand.CommandText += " GOODS.GOODSNORF=MAIN.GOODSNORF" + Environment.NewLine;
                // グループコードマスタ結合
                //sqlCommand.CommandText += " LEFT JOIN BLGROUPURF AS BLGR ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN BLGROUPURF AS BLGR WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " BLGR.BLGROUPCODERF=MAIN.BLGROUPCODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND BLGR.ENTERPRISECODERF=MAIN.ENTERPRISECODERF";
                // BLコードマスタ結合
                //sqlCommand.CommandText += " LEFT JOIN BLGOODSCDURF AS BLCD ON" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN BLGOODSCDURF AS BLCD WITH (READUNCOMMITTED) ON" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " BLCD.ENTERPRISECODERF=MAIN.ENTERPRISECODERF AND" + Environment.NewLine;
                sqlCommand.CommandText += " BLCD.BLGOODSCODERF = MAIN.BLGOODSCODERF" + Environment.NewLine;
                //-----ADD 2011/01/11----->>>>>
                int inventoryDateGoods = TDateTime.DateTimeToLongDate("YYYYMMDD", inventoryExtCndtnWork.InventoryDate);
                //sqlCommand.CommandText += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " ON MAIN.ENTERPRISECODERF = GOODSPRICE.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSMAKERCDRF = GOODSPRICE.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSNORF = GOODSPRICE.GOODSNORF " + Environment.NewLine;
                sqlCommand.CommandText += " AND GOODSPRICE.PRICESTARTDATERF  <=" + inventoryDateGoods.ToString() + Environment.NewLine;

                //sqlCommand.CommandText += " LEFT JOIN STOCKRF AS STOCK" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " LEFT JOIN STOCKRF AS STOCK WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlCommand.CommandText += " ON MAIN.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSNORF = STOCK.GOODSNORF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.WAREHOUSECODERF = STOCK.WAREHOUSECODERF" + Environment.NewLine;
                //-----ADD 2011/01/11-----<<<<<

                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                sqlCommand.CommandText += " LEFT JOIN RATERF AS RATE WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlCommand.CommandText += " ON MAIN.ENTERPRISECODERF = RATE.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.SECTIONCODERF = RATE.SECTIONCODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSMAKERCDRF = RATE.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSNORF = RATE.GOODSNORF" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.UNITRATESETDIVCDRF = '26A'" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.GOODSRATERANKRF    = ''" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.GOODSRATEGRPCODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.BLGROUPCODERF      = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.BLGOODSCODERF      = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.CUSTOMERCODERF     = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.CUSTRATEGRPCODERF  = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.SUPPLIERCDRF       = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE.LOTCOUNTRF         = 9999999.99" + Environment.NewLine;
                sqlCommand.CommandText += " LEFT JOIN RATERF AS RATE2 WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlCommand.CommandText += " ON MAIN.ENTERPRISECODERF = RATE2.ENTERPRISECODERF" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.SECTIONCODERF = '00'" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSMAKERCDRF = RATE2.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText += " AND MAIN.GOODSNORF = RATE2.GOODSNORF" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.UNITRATESETDIVCDRF = '26A'" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.GOODSRATERANKRF    = ''" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.GOODSRATEGRPCODERF = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.BLGROUPCODERF      = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.BLGOODSCODERF      = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.CUSTOMERCODERF     = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.CUSTRATEGRPCODERF  = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.SUPPLIERCDRF       = 0" + Environment.NewLine;
                sqlCommand.CommandText += " AND RATE2.LOTCOUNTRF         = 9999999.99" + Environment.NewLine;
                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
                #endregion


                //結果取得
                sqlCommand.CommandTimeout = 3600; // ADD 2012/05/21
                myReader = sqlCommand.ExecuteReader();
                InventoryDataWork beInventoryDataWork = null;
                //-----ADD 2011/01/28 ----->>>>>
                string WarehouseCodeStr = string.Empty;
                //-----ADD 2011/01/28 -----<<<<<

                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                string sectionCode = string.Empty;
                //int goodsMakerCd = 0;// DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応
                //string goodsNo = string.Empty;// DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応
                string keyValue = string.Empty;
                //RateWork rateW = null;// 譚洪 2021/03/16 PMKOBETSU-3551の対応
                RateWork rateAllSec = null;
                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<

                while (myReader.Read())
                {
                    #region 抽出結果セット
                    InventoryDataWork wkInventoryDataWork = new InventoryDataWork();
                    wkInventoryDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));
                    wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_WAREHOUSECODERF"));
                    wkInventoryDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));
                    wkInventoryDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF")).Trim();
                    wkInventoryDataWork.GoodsNoSrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));
                    wkInventoryDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSNAMERF"));
                    //---DEL 2011/02/11 ----->>>
                    //if (string.IsNullOrEmpty(wkInventoryDataWork.GoodsName))
                    //{
                    //    wkInventoryDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    //}
                    //---DEL 2011/02/11 -----<<<
                    wkInventoryDataWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGROUPCODERF"));
                    wkInventoryDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGOODSCODERF"));
                    wkInventoryDataWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_SUPPLIERCDRF"));
                    wkInventoryDataWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
                    wkInventoryDataWork.InventoryDate = inventoryExtCndtnWork.InventoryDate;
                    wkInventoryDataWork.WarehouseShelfNo = "ｻｷﾀﾞｼ";
                    wkInventoryDataWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    wkInventoryDataWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    wkInventoryDataWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));

                    wkInventoryDataWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSLGROUPRF"));              // 商品大分類コード  
                    wkInventoryDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));              // BLグループコード  
                    wkInventoryDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_ENTERPRISEGANRECODERF"));// 自社分類コード
                    wkInventoryDataWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));            // 変更前仕入単価
                    wkInventoryDataWork.InventoryPreprDay = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);                      // 棚卸準備処理日
                    wkInventoryDataWork.InventoryPreprTim = SysTime;                                                                                    // 棚卸準備処理時間
                    wkInventoryDataWork.LastInventoryUpdate = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);                    // 最終棚卸更新日 
                    wkInventoryDataWork.StockMashinePrice = Convert.ToInt64(wkInventoryDataWork.StockUnitPriceFl * wkInventoryDataWork.StockTotal);　       // マシン在庫額
                    wkInventoryDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_JANRF"));                               // 商品マスタ・JANコード
                    wkInventoryDataWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCK_STOCKDIVRF"));
                    wkInventoryDataWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCK_LASTSTOCKDATERF")); // 最終仕入年月日

                    //-----ADD 2011/01/28 ----->>>>>
                    if (beInventoryDataWork != null)
                    {
                        if (beInventoryDataWork.EnterpriseCode == wkInventoryDataWork.EnterpriseCode
                            && beInventoryDataWork.SectionCode == wkInventoryDataWork.SectionCode
                            && WarehouseCodeStr == wkInventoryDataWork.WarehouseCode
                            && beInventoryDataWork.GoodsMakerCd == wkInventoryDataWork.GoodsMakerCd
                            && beInventoryDataWork.GoodsNo == wkInventoryDataWork.GoodsNo
                            && beInventoryDataWork.BLGroupCode == wkInventoryDataWork.BLGroupCode
                            && beInventoryDataWork.SupplierCd == wkInventoryDataWork.SupplierCd
                            && beInventoryDataWork.StockUnitPriceFl == wkInventoryDataWork.StockUnitPriceFl
                            && beInventoryDataWork.ListPriceFl == wkInventoryDataWork.ListPriceFl
                            && beInventoryDataWork.GoodsName == wkInventoryDataWork.GoodsName)
                        {
                            continue;
                        }
                    }
                    WarehouseCodeStr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_WAREHOUSECODERF")); // ADD 2011/01/28
                    //-----ADD 2011/01/28 -----<<<<<

                    if (string.IsNullOrEmpty(wkInventoryDataWork.WarehouseCode))
                    {
                        wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD1RF"));
                    }
                    if (string.IsNullOrEmpty(wkInventoryDataWork.WarehouseCode))
                    {
                        wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD2RF"));
                    }
                    if (string.IsNullOrEmpty(wkInventoryDataWork.WarehouseCode))
                    {
                        wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEC_SECTWAREHOUSECD3RF"));
                    }

                    //-----ADD 2011/01/28 ----->>>>>
                    String warehouseCode = wkInventoryDataWork.WarehouseCode.Trim();
                    // 倉庫指定区分 0:範囲,1:単独
                    if (inventoryExtCndtnWork.WarehouseDiv == 0)
                    {
                        if ((inventoryExtCndtnWork.StWarehouseCd != "" && inventoryExtCndtnWork.StWarehouseCd.CompareTo(warehouseCode) > 0) ||
                            (inventoryExtCndtnWork.EdWarehouseCd != "" && inventoryExtCndtnWork.EdWarehouseCd.CompareTo(warehouseCode) < 0))
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (inventoryExtCndtnWork.WarehouseCd01 != "" ||
                            inventoryExtCndtnWork.WarehouseCd02 != "" ||
                            inventoryExtCndtnWork.WarehouseCd03 != "" ||
                            inventoryExtCndtnWork.WarehouseCd04 != "" ||
                            inventoryExtCndtnWork.WarehouseCd05 != "" ||
                            inventoryExtCndtnWork.WarehouseCd06 != "" ||
                            inventoryExtCndtnWork.WarehouseCd07 != "" ||
                            inventoryExtCndtnWork.WarehouseCd08 != "" ||
                            inventoryExtCndtnWork.WarehouseCd09 != "" ||
                            inventoryExtCndtnWork.WarehouseCd10 != "")
                        {
                            if (!((inventoryExtCndtnWork.WarehouseCd01 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd01) ||
                                (inventoryExtCndtnWork.WarehouseCd02 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd02) ||
                                (inventoryExtCndtnWork.WarehouseCd03 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd03) ||
                                (inventoryExtCndtnWork.WarehouseCd04 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd04) ||
                                (inventoryExtCndtnWork.WarehouseCd05 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd05) ||
                                (inventoryExtCndtnWork.WarehouseCd06 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd06) ||
                                (inventoryExtCndtnWork.WarehouseCd07 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd07) ||
                                (inventoryExtCndtnWork.WarehouseCd08 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd08) ||
                                (inventoryExtCndtnWork.WarehouseCd09 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd09) ||
                                (inventoryExtCndtnWork.WarehouseCd10 != "" && warehouseCode == inventoryExtCndtnWork.WarehouseCd10)))
                            {
                                continue;
                            }
                        }
                    }
                    //-----ADD 2011/01/28 -----<<<<<

                    if (!string.IsNullOrEmpty(wkInventoryDataWork.WarehouseCode))
                    {
                        //-----DEL 2011/01/28 ----->>>>>
                        //if (beInventoryDataWork != null)
                        //{
                        //    if (beInventoryDataWork.EnterpriseCode == wkInventoryDataWork.EnterpriseCode
                        //        && beInventoryDataWork.SectionCode == wkInventoryDataWork.SectionCode
                        //        && beInventoryDataWork.WarehouseCode == wkInventoryDataWork.WarehouseCode
                        //        && beInventoryDataWork.GoodsMakerCd == wkInventoryDataWork.GoodsMakerCd
                        //        && beInventoryDataWork.GoodsNo == wkInventoryDataWork.GoodsNo
                        //        && beInventoryDataWork.BLGroupCode == wkInventoryDataWork.BLGroupCode
                        //        && beInventoryDataWork.SupplierCd == wkInventoryDataWork.SupplierCd
                        //        && beInventoryDataWork.StockUnitPriceFl == wkInventoryDataWork.StockUnitPriceFl
                        //        && beInventoryDataWork.ListPriceFl == wkInventoryDataWork.ListPriceFl
                        //        && beInventoryDataWork.GoodsName == wkInventoryDataWork.GoodsName)
                        //    {
                        //        continue;
                        //    }
                        //}
                        //-----DEL 2011/01/28 -----<<<<<
                        //---DEL 2011/02/11 ----->>>
                        //if (wkInventoryDataWork.ListPriceFl == 0)
                        //{
                        //    wkInventoryDataWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICE_LISTPRICERF"));
                        //}
                        //---DEL 2011/02/11 -----<<<
                        beInventoryDataWork = wkInventoryDataWork;

                        resultList.Add(wkInventoryDataWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // -- DEL 2012/05/21 -------------------------->>>>
                    //}
                    //#endregion
                    // -- DEL 2012/05/21 --------------------------<<<<

                        GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
                        UnitPriceCalcParamWork unitPriceCalcParam = new UnitPriceCalcParamWork();
                        GoodsUnitDataWork goodsUnitData = new GoodsUnitDataWork(); // 商品連結データオブジェクトリスト

                        #region 商品仕入取得データクラス
                        goodsSupplierDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_ENTERPRISECODERF"));// 企業コード
                        goodsSupplierDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));      // 拠点コード
                        goodsSupplierDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));     // メーカーコード
                        goodsSupplierDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));              // 商品番号
                        goodsSupplierDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGOODSCODERF"));     // BLコード
                        goodsSupplierDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));   // 商品中分類コード
                        GoodsSupplierDataWorkList.Add(goodsSupplierDataWork);
                        #endregion

                        #region 単価算出モジュール計算用パラメータ
                        unitPriceCalcParam.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));   // 拠点コード
                        unitPriceCalcParam.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));  // メーカーコード
                        unitPriceCalcParam.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));           // 商品番号
                        //unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));　 // 商品中分類コード // DEL caohh 2015/03/06 for Redmine#44951
                        unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCD_GOODSRATEGRPCODERF"));　 // 商品掛率グループコード// ADD caohh  2015/03/06 for Redmine#44951
                        unitPriceCalcParam.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGROUPCODERF"));// BLグループコード
                        unitPriceCalcParam.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_BLGOODSCODERF"));  // BLコード
                        unitPriceCalcParam.PriceApplyDate = DateTime.Now;// DEL caohh for Redmine#44951
                        unitPriceCalcParam.PriceApplyDate = inventoryExtCndtnWork.InventoryDate;// ADD caohh  2015/03/06 for Redmine#44951
                        unitPriceCalcParam.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSRATERANKRF"));  // 層別
                        unitPriceCalcParamList.Add(unitPriceCalcParam);
                        #endregion

                        #region 商品連結データリスト
                        goodsUnitData.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_ENTERPRISECODERF"));// 企業コード
                        goodsUnitData.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));              // 商品番号
                        goodsUnitData.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));     // メーカーコード
                        goodsUnitDataList.Add(goodsUnitData);
                        #endregion

                        // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                        #region 単品掛率リスト

                        //拠点分単品掛率
                        // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                        //sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_SECTIONCODERF"));   // 拠点コード
                        //goodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAIN_GOODSMAKERCDRF"));     // メーカーコード
                        //goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAIN_GOODSNORF"));           // 商品番号
                        //keyValue = sectionCode.Trim() + "-" + goodsMakerCd.ToString("D4") + "-" + goodsNo.Trim();
                        //if (!rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        keyValue = string.Format(ctDicKeyFmt, wkInventoryDataWork.SectionCode.Trim(), wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo.Trim());
                        sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_SECTIONCODERF"));
                        //当商品の拠点分単品がある場合、単品dicに追加
                        if (!string.IsNullOrEmpty(sectionCode) && !rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
                        {
                            // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                            //rateW = new RateWork();
                            //rateW.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_RATEVALRF"));
                            //rateW.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_PRICEFLRF"));
                            //rateWorkByGoodsNoDic.Add(keyValue, rateW);
                            rateAllSec = new RateWork();
                            rateAllSec.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_RATEVALRF"));
                            rateAllSec.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_PRICEFLRF"));
                            rateAllSec.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_UNPRCFRACPROCUNITRF"));
                            rateAllSec.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATE_UNPRCFRACPROCDIVRF"));
                            rateAllSec.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATESETTINGDIVIDERF"));
                            rateAllSec.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATEMNGGOODSCDRF"));
                            rateAllSec.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATEMNGCUSTCDRF"));
                            rateAllSec.SectionCode = sectionCode;
                            rateAllSec.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_LOTCOUNTRF"));
                            rateWorkByGoodsNoDic.Add(keyValue, rateAllSec);
                            // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
                        }

                        //全社単品掛率 
                        // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                        //keyValue = "00" + "-" + goodsMakerCd.ToString("D4") + "-" + goodsNo.Trim();
                        keyValue = string.Format(ctDicKeyFmt, ctALLSection, wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo.Trim());
                        // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
                        sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_SECTIONCODERF"));
                        //全社単品がある場合、単品dicに追加
                        if (!string.IsNullOrEmpty(sectionCode) && !rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        {
                            rateAllSec = new RateWork();
                            rateAllSec.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_RATEVALRF"));
                            rateAllSec.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_PRICEFLRF"));
                            rateAllSec.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_UNPRCFRACPROCUNITRF"));
                            rateAllSec.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATE2_UNPRCFRACPROCDIVRF"));
                            rateAllSec.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATESETTINGDIVIDERF"));
                            rateAllSec.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATEMNGGOODSCDRF"));
                            rateAllSec.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATEMNGCUSTCDRF"));
                            rateAllSec.SectionCode = sectionCode;
                            rateAllSec.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_LOTCOUNTRF"));

                            rateWorkByGoodsNoDic.Add(keyValue, rateAllSec);
                        }
                        #endregion
                        // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
                    // -- ADD 2012/05/21 -------------------------->>>>
                    }
                    #endregion
                    // -- ADD 2012/05/21 --------------------------<<<<
                }

                if (!myReader.IsClosed) myReader.Close();

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 商品仕入先情報取得処理 実行
                    goodsSupplierGetter.GetGoodsMngInfo(ref GoodsSupplierDataWorkList);

                    #region 商品仕入先情報取得処理 結果セット
                    // 商品仕入先情報取得処理により取得した仕入先を
                    // 単価算出パラメータ・棚卸データワークにセット
                    for (int i = 0; i < GoodsSupplierDataWorkList.Count; i++) // 商品仕入取得データクラス
                    {
                        //-- UPD 2012/05/21 ------------------------------------------------------------------>>>>
                        #region DEL 無駄ループを削除、配列番号で紐付けるようにする。
                        //for (int j = 0; j < unitPriceCalcParamList.Count; j++) // 単価算出モジュール計算用パラメータ
                        //{
                        //    if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[j].GoodsMakerCd) && // 商品メーカー
                        //        (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[j].GoodsNo) &&           // 商品番号
                        //        (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[j].BLGoodsCode))     // BL商品コード
                        //    {
                        //        if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                        //        {
                        //            unitPriceCalcParamList[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // 仕入先セット
                        //        }
                        //    }
                        //}

                        //for (int j = 0; j < al.Count; j++) // 棚卸データワーク
                        //{
                        //    if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == al[j].GoodsMakerCd) && // 商品メーカー
                        //        (GoodsSupplierDataWorkList[i].GoodsNo == al[j].GoodsNo) &&           // 商品番号
                        //        (GoodsSupplierDataWorkList[i].BLGoodsCode == al[j].BLGoodsCode))     // BL商品コード
                        //    {
                        //        if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                        //        {
                        //            al[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // 仕入先セット
                        //        }
                        //    }
                        //}
                        #endregion
                        if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[i].GoodsMakerCd) && // 商品メーカー
                            (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[i].GoodsNo) &&           // 商品番号
                            (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[i].BLGoodsCode) &&   // BL商品コード
                            (GoodsSupplierDataWorkList[i].GoodsMakerCd == ((InventoryDataWork)resultList[i]).GoodsMakerCd) && // 商品メーカー
                            (GoodsSupplierDataWorkList[i].GoodsNo == ((InventoryDataWork)resultList[i]).GoodsNo) &&           // 商品番号
                            (GoodsSupplierDataWorkList[i].BLGoodsCode == ((InventoryDataWork)resultList[i]).BLGoodsCode))     // BL商品コード
                        {
                            if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                            {
                                unitPriceCalcParamList[i].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd;
                                //((InventoryDataWork)resultList[i]).SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // DEL 2012/06/14
                                // ADD 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理 ----->>>>>
                                if (supplierDic != null && supplierDic.ContainsKey(unitPriceCalcParamList[i].SupplierCd))
                                {
                                    unitPriceCalcParamList[i].StockUnPrcFrcProcCd = supplierDic[unitPriceCalcParamList[i].SupplierCd].StockUnPrcFrcProcCd;
                                }
                                // ADD 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理 -----<<<<<
                            }
                        }
                        else
                        {
                            throw new Exception("商品管理情報と棚卸データの紐付きが不正です。（来勘計上分データ抽出）" +
                                                i.ToString() + " : " +
                                                GoodsSupplierDataWorkList[i].GoodsMakerCd.ToString() + ", " +
                                                GoodsSupplierDataWorkList[i].GoodsNo.ToString() + " : " +
                                                unitPriceCalcParamList[i].GoodsMakerCd.ToString() + ", " +
                                                unitPriceCalcParamList[i].GoodsNo.ToString() + " : " +
                                                ((InventoryDataWork)resultList[i]).GoodsMakerCd.ToString() + ", " +
                                                ((InventoryDataWork)resultList[i]).GoodsNo.ToString());
                        }
                        // -- UPD 2012/05/21 ------------------------------------------------------------------<<<<
                    }
                    #endregion

                    //原価算出処理 実行
                    //unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);//DEL 2012/07/10 for Redmine#31103
                    //unitPriceCalculation.CalculateUnitCostForInventory(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);//ADD 2012/07/10 for Redmine#31103 // DEL 2013/06/07 wangl2 For Redmine#35788
                    //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                    // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                    //status = unitPriceCalculation.CalculateUnitCostForInventory(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);
                    status = unitPriceCalculation.CalculateUnitCostForInventory2(unitPriceCalcParamList, goodsUnitDataList, rateWorkByGoodsNoDic, out unitPriceCalcRetList);
                    // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        return status;
                    }
                    //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

                    #region 原価算出処理 結果セット
                    // 原価算出処理により取得した原価を
                    // 在庫履歴データクラスにセット
                    for (int i = 0; i < unitPriceCalcRetList.Count; i++) // 単価計算結果
                    {
                        // -- UPD 2012/05/21 ------------------------------------------------>>>>
                        #region DEL 無駄ループ削除、配列番号で紐付けるよう変更する
                        //for (int j = 0; j < resultList.Count; j++) // 棚卸データクラス
                        //{
                        //    if ((unitPriceCalcRetList[i].GoodsMakerCd == ((InventoryDataWork)resultList[j]).GoodsMakerCd) && // 商品メーカー
                        //        (unitPriceCalcRetList[i].GoodsNo == ((InventoryDataWork)resultList[j]).GoodsNo))     // BL商品コード
                        //    {
                        //        if (((InventoryDataWork)resultList[j]).StockUnitPriceFl == 0)
                        //        {
                        //            // 仕入単価
                        //            ((InventoryDataWork)resultList[j]).StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                        //            // 変更前仕入単価
                        //            ((InventoryDataWork)resultList[j]).BfStockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;

                        //        }
                        //        // 調製用計算原価
                        //        double adjstCalcCost = 0;
                        //        FractionCalculate.FracCalcMoney(unitPriceCalcRetList[i].UnitPriceTaxExcFl, 0.01, 1, out adjstCalcCost);
                        //        ((InventoryDataWork)resultList[j]).AdjstCalcCost = adjstCalcCost;
                        //    }
                        //}
                        #endregion
                        if ((unitPriceCalcRetList[i].GoodsMakerCd == ((InventoryDataWork)resultList[i]).GoodsMakerCd) && // 商品メーカー
                            (unitPriceCalcRetList[i].GoodsNo == ((InventoryDataWork)resultList[i]).GoodsNo))     // BL商品コード
                        {
                            if (((InventoryDataWork)resultList[i]).StockUnitPriceFl == 0)
                            {
                                // 仕入単価
                                ((InventoryDataWork)resultList[i]).StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                                // 変更前仕入単価
                                ((InventoryDataWork)resultList[i]).BfStockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;

                            }
                            // 調製用計算原価
                            double adjstCalcCost = 0;
                            FractionCalculate.FracCalcMoney(unitPriceCalcRetList[i].UnitPriceTaxExcFl, 0.01, 1, out adjstCalcCost);
                            ((InventoryDataWork)resultList[i]).AdjstCalcCost = adjstCalcCost;
                        }
                        else
                        {
                            throw new Exception("原価算出結果と棚卸データの紐付きが不正です。（来勘計上分データ抽出）" +
                                                i.ToString() + " : " +
                                                unitPriceCalcRetList[i].GoodsMakerCd.ToString() + ", " +
                                                unitPriceCalcRetList[i].GoodsNo.ToString() + " : " +
                                                ((InventoryDataWork)resultList[i]).GoodsMakerCd.ToString() + ", " +
                                                ((InventoryDataWork)resultList[i]).GoodsNo.ToString());
                        }
                        // -- UPD 2012/05/21 ------------------------------------------------<<<<
                    }
                    #endregion

                    #region 仕入先コード抽出条件
                    for (int i = 0; i < resultList.Count; i++) // 棚卸データワーク
                    {
                        if ((inventoryExtCndtnWork.StCustomerCd <= ((InventoryDataWork)resultList[i]).SupplierCd) &&
                            (inventoryExtCndtnWork.EdCustomerCd >= ((InventoryDataWork)resultList[i]).SupplierCd))
                        {
                            wkList.Add(((InventoryDataWork)resultList[i]));
                        }
                    }
                    #endregion

                    resultList = wkList;

                }
                //-----UPD 2011/01/28 ----->>>>>
                //SortData(resultList, ref al); List<InventoryDataWork> alLend
                //SortDataOrder(ref al);
                List<InventoryDataWork> alResultList = null;
                SortData(resultList, out alResultList);

                SortDataOrder(ref al, alResultList);
                //-----UPD 2011/01/28 -----<<<<<
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SeachInventoryData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 検索したデータソート処理
        /// </summary>
        /// <param name="resultList">検索結果ArrayList</param>
        /// <param name="al">ソート結果ArrayList</param>
        /// <remarks>
        /// <br>Note       : 検索したデータソートを行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.12.25</br>
        /// <br></br>
        /// </remarks>
        //-----UPD 2011/01/28 ----->>>>>
        //private void SortData(ArrayList resultList, ref List<InventoryDataWork> al)
        private void SortData(ArrayList resultList, out List<InventoryDataWork> alResultList)
        //-----UPD 2011/01/28 -----<<<<<
        {
            alResultList = new List<InventoryDataWork>(); // ADD 2011/01/28

            if (resultList.Count == 0) return;
            string wareCode = string.Empty;
            string goodNo = string.Empty;
            string currentData = string.Empty;
            int makerCode = 0;
            double stockTotal = 0;
            string sectioncode = string.Empty;
            int blgroupcode;
            int blgoodscode;
            int suppliercd;
            double listPriceTaxExcFl = 0;
            double salesunitcost;

            ArrayList arrayList = new ArrayList();
            foreach (InventoryDataWork data in resultList)
            {
                // 倉庫
                wareCode = data.WarehouseCode.Trim();
                // 品
                goodNo = data.GoodsNoSrc.Trim();
                // メーカー
                makerCode = data.GoodsMakerCd;
                sectioncode = data.SectionCode.Trim();
                blgroupcode = data.BLGroupCode;
                blgoodscode = data.BLGoodsCode;
                suppliercd = data.SupplierCd;
                salesunitcost = data.StockUnitPriceFl;
                listPriceTaxExcFl = data.ListPriceFl;
                // 今回のデータの保存
                currentData = wareCode + "-" + goodNo + "-" + makerCode.ToString() + sectioncode + blgroupcode.ToString()
                    + blgoodscode.ToString() + suppliercd.ToString() + salesunitcost.ToString() + listPriceTaxExcFl.ToString();

                // 重複データではない場合(倉庫・品番・メーカー)
                if (arrayList.Count <= 0 || !arrayList.Contains(currentData))
                {
                    arrayList.Add(currentData);
                    foreach (InventoryDataWork searchData in resultList)
                    {
                        string currentWareCode = searchData.WarehouseCode.Trim();
                        string currentGoodNo = searchData.GoodsNoSrc.Trim();
                        int currentMakerCode = searchData.GoodsMakerCd;
                        //倉庫・品番・メーカーが同じで、品名違いのデータが存在する場合
                        if ((currentWareCode.Equals(wareCode)) && (currentGoodNo.Equals(goodNo)) && (currentMakerCode == makerCode)
                            && (searchData.SectionCode.Trim().Equals(sectioncode)) && (searchData.BLGroupCode.Equals(blgroupcode))
                            && (searchData.BLGoodsCode.Equals(blgoodscode)) && (searchData.SupplierCd.Equals(suppliercd))
                            && (searchData.StockUnitPriceFl.Equals(salesunitcost)) && (searchData.ListPriceFl.Equals(listPriceTaxExcFl)))
                        {
                            //来勘
                            if ("ｻｷﾀﾞｼ".Equals(searchData.WarehouseShelfNo))
                            {
                                // 出荷数合計
                                stockTotal += searchData.ShipmentCnt;
                            }
                            //貸出
                            else if ("ｶｼﾀﾞｼ".Equals(searchData.WarehouseShelfNo))
                            {
                                // 帳簿数合計
                                stockTotal += searchData.StockTotal;
                            }
                        }
                    }
                    data.StockTotal = stockTotal;
                    //-----UPD 2011/01/28 ----->>>>>
                    //al.Add(data);
                    alResultList.Add(data);
                    //-----UPD 2011/01/28 -----<<<<<
                    stockTotal = 0;
                }
            }
        }


        /// <summary>
        /// 検索したデータソート処理
        /// </summary>
        /// <param name="flag">検索結果ArrayList</param>
        /// <param name="al">ソート結果ArrayList</param>
        /// <remarks>
        /// <br>Note       : 検索したデータソートを行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.12.25</br>
        /// <br></br>
        /// </remarks>
        //private void SortDataOrderList (ref List<InventoryDataWork> al)// DEL 2011/01/28
        private void SortDataOrderList(ref List<InventoryDataWork> al, List<InventoryDataWork> alResultList)// ADD 2011/01/28
        {
            Dictionary<String, InventoryDataWork> dic = new Dictionary<String, InventoryDataWork>();
            string Key = "";
            ArrayList alList = new ArrayList();

            //foreach (InventoryDataWork wkInventoryDataWork in al)// DEL 2011/01/28
            foreach (InventoryDataWork wkInventoryDataWork in alResultList)// ADD 2011/01/28
            {
                if ("ｶｼﾀﾞｼ".Equals(wkInventoryDataWork.WarehouseShelfNo))
                {
                    wkInventoryDataWork.GoodsNo = wkInventoryDataWork.GoodsNo.PadRight(23, ' ');
                    //品番の先頭>22の場合
                    if (!string.IsNullOrEmpty(wkInventoryDataWork.GoodsNo) && wkInventoryDataWork.GoodsNo.Length > 22)
                    {
                        Key = KeyofDic(wkInventoryDataWork.WarehouseCode,
                            wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo.Substring(0, 22));

                        string goodsNo = wkInventoryDataWork.GoodsNo;

                        if (!dic.ContainsKey(Key))
                        {
                            dic.Add(Key, wkInventoryDataWork);

                            if ("ｶｼﾀﾞｼ".Equals(wkInventoryDataWork.WarehouseShelfNo))
                            {
                                wkInventoryDataWork.GoodsNo = goodsNo.Substring(0, 22) + ".";
                            }
                        }
                        else
                        {
                            int index = 0;
                            for (int i = 0; i < alList.Count; i++)
                            {
                                InventoryDataWork tempwork = (InventoryDataWork)alList[i];
                                if (tempwork.GoodsNo.Length > 22)
                                {
                                    if (tempwork.WarehouseCode.Equals(wkInventoryDataWork.WarehouseCode)
                                        && (tempwork.GoodsMakerCd.Equals(wkInventoryDataWork.GoodsMakerCd))
                                        && (tempwork.GoodsNo.Substring(0, 22).Equals(wkInventoryDataWork.GoodsNo.Substring(0, 22)))
                                        && (tempwork.WarehouseShelfNo.Equals(wkInventoryDataWork.WarehouseShelfNo)))
                                    {
                                        index++;
                                    }
                                }
                            }

                            if (index > 25)
                            {
                                if ("ｶｼﾀﾞｼ".Equals(wkInventoryDataWork.WarehouseShelfNo))
                                {
                                    //「A」から順に付番する
                                    wkInventoryDataWork.GoodsNo = wkInventoryDataWork.GoodsNo.Substring(0, 22) + "." + Convert.ToChar('Z').ToString();
                                }
                            }
                            else
                            {
                                if ("ｶｼﾀﾞｼ".Equals(wkInventoryDataWork.WarehouseShelfNo))
                                {
                                    //「A」から順に付番する
                                    wkInventoryDataWork.GoodsNo = wkInventoryDataWork.GoodsNo.Substring(0, 22) + "." + Convert.ToChar('A' + (index - 1)).ToString();
                                }
                            }
                        }
                    }
                    alList.Add(wkInventoryDataWork);
                    al.Add(wkInventoryDataWork); // ADD 2011/01/28
                }
            }
        }

        /// <summary>
        /// 検索したデータソート処理
        /// </summary>
        /// <param name="flag">検索結果ArrayList</param>
        /// <param name="al">ソート結果ArrayList</param>
        /// <remarks>
        /// <br>Note       : 検索したデータソートを行う</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.12.25</br>
        /// <br></br>
        /// </remarks>
        /// private void SortDataOrder(ref List<InventoryDataWork> al)// DEL 2011/01/28
        private void SortDataOrder(ref List<InventoryDataWork> al, List<InventoryDataWork> alResultList)// ADD 2011/01/28
        {
            Dictionary<String, InventoryDataWork> dic = new Dictionary<String, InventoryDataWork>();
            string Key = "";
            ArrayList alList = new ArrayList();

            //foreach (InventoryDataWork wkInventoryDataWork in al) // DEL 2011/01/28
            foreach (InventoryDataWork wkInventoryDataWork in alResultList) // ADD 2011/01/28
            {
                if ("ｻｷﾀﾞｼ".Equals(wkInventoryDataWork.WarehouseShelfNo))
                {
                    wkInventoryDataWork.GoodsNo = wkInventoryDataWork.GoodsNo.PadRight(23, ' ');
                    //品番の先頭>22の場合
                    if (!string.IsNullOrEmpty(wkInventoryDataWork.GoodsNo) && wkInventoryDataWork.GoodsNo.Length > 22)
                    {
                        Key = KeyofDic(wkInventoryDataWork.WarehouseCode,
                            wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo.Substring(0, 22));

                        string goodsNo = wkInventoryDataWork.GoodsNo;

                        if (!dic.ContainsKey(Key))
                        {
                            dic.Add(Key, wkInventoryDataWork);

                            if ("ｻｷﾀﾞｼ".Equals(wkInventoryDataWork.WarehouseShelfNo))
                            {
                                wkInventoryDataWork.GoodsNo = goodsNo.Substring(0, 22) + "*";
                            }
                        }
                        else
                        {
                            int index = 0;
                            for (int i = 0; i < alList.Count; i++)
                            {
                                InventoryDataWork tempwork = (InventoryDataWork)alList[i];
                                if (tempwork.GoodsNo.Length > 22)
                                {
                                    if (tempwork.WarehouseCode.Equals(wkInventoryDataWork.WarehouseCode)
                                        && (tempwork.GoodsMakerCd.Equals(wkInventoryDataWork.GoodsMakerCd))
                                        && (tempwork.GoodsNo.Substring(0, 22).Equals(wkInventoryDataWork.GoodsNo.Substring(0, 22)))
                                        && (tempwork.WarehouseShelfNo.Equals(wkInventoryDataWork.WarehouseShelfNo)))
                                    {
                                        index++;
                                    }
                                }
                            }

                            if (index > 25)
                            {
                                if ("ｻｷﾀﾞｼ".Equals(wkInventoryDataWork.WarehouseShelfNo))
                                {
                                    //「A」から順に付番する
                                    wkInventoryDataWork.GoodsNo = wkInventoryDataWork.GoodsNo.Substring(0, 22) + "*" + Convert.ToChar('Z').ToString();
                                }
                            }
                            else
                            {
                                if ("ｻｷﾀﾞｼ".Equals(wkInventoryDataWork.WarehouseShelfNo))
                                {
                                    //「A」から順に付番する
                                    wkInventoryDataWork.GoodsNo = wkInventoryDataWork.GoodsNo.Substring(0, 22) + "*" + Convert.ToChar('A' + (index - 1)).ToString();
                                }
                            }
                        }
                    }
                    alList.Add(wkInventoryDataWork);
                    al.Add(wkInventoryDataWork); // ADD 2011/01/28
                }
            }
        }

        //-----ADD 2011/01/11-----<<<<<
        // システムロック用倉庫リスト作成
        private int searchWarehouse(ref InventoryExtCndtnWork inventoryExtCndtnWork, out Dictionary<string, string> wareList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            wareList = new Dictionary<string, string>();
            try
            {
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT " + Environment.NewLine;
                sqlTxt += "     WAREHOUSECODERF" + Environment.NewLine;
                //sqlTxt += " FROM WAREHOUSERF" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sqlTxt += " FROM WAREHOUSERF WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sqlTxt += " WHERE" + Environment.NewLine;
                sqlTxt += "     ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;

                if (inventoryExtCndtnWork.StWarehouseCd != "")
                {
                    sqlTxt += " AND WAREHOUSECODERF >= @STWAREHOUSECODE" + Environment.NewLine;
                }
                if (inventoryExtCndtnWork.EdWarehouseCd != "")
                {
                    sqlTxt += " AND WAREHOUSECODERF <= @EDWAREHOUSECODE" + Environment.NewLine;
                }
                //----ADD 2012/07/10 for Redmine#31103のシステムロック(倉庫)------>>>>>>
                if (inventoryExtCndtnWork.SectionCodeSt != "")
                {
                    sqlTxt += " AND SECTIONCODERF >= @STSECTIONCODE" + Environment.NewLine;
                }
                if (inventoryExtCndtnWork.SectionCodeEd != "")
                {
                    sqlTxt += " AND SECTIONCODERF <= @EDSECTIONCODE" + Environment.NewLine;
                }
                //----ADD 2012/07/10 for Redmine#31103のシステムロック(倉庫)------<<<<<<<
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                //Parameterオブジェクトへ値設定
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EnterpriseCode);

                if (inventoryExtCndtnWork.StWarehouseCd != "")
                {
                    SqlParameter findParaStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                    findParaStWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseCd);
                }
                if (inventoryExtCndtnWork.EdWarehouseCd != "")
                {
                    SqlParameter findParaEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                    findParaEdWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseCd);
                }
                //----ADD 2012/07/10 for Redmine#31103のシステムロック(倉庫)------>>>>>>
                if (inventoryExtCndtnWork.SectionCodeSt != "")
                {
                    SqlParameter findParaStSectionCode = sqlCommand.Parameters.Add("@STSECTIONCODE", SqlDbType.NChar);
                    findParaStSectionCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeSt);
                }
                if (inventoryExtCndtnWork.SectionCodeEd != "")
                {
                    SqlParameter findParaEdSectionCode = sqlCommand.Parameters.Add("@EDSECTIONCODE", SqlDbType.NChar);
                    findParaEdSectionCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd);
                }
                //----ADD 2012/07/10 for Redmine#31103のシステムロック(倉庫)------<<<<<<<<
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    string warehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wareList.Add(warehouseCode, warehouseCode);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion    // SearchWriteProc

        // --- ADD 2010/02/20 ---------->>>>>
        #region 在庫マスタ検索処理(棚卸データ存在チェック用)
        /// <summary>
        /// 在庫製番マスタを検索し、棚卸データListを戻します(棚卸データ存在チェック用)
        /// </summary>
        /// <param name="al">棚卸データList</param>
        /// <param name="inventoryExtCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remark>
        /// <br>Note       : 在庫製番マスタを検索し、棚卸データListを戻します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/02/20</br>
        /// </remark>
        private int SeachProductStockRepate(out List<InventoryDataWork> al, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            al = new List<InventoryDataWork>();
            List<InventoryDataWork> wkList = new List<InventoryDataWork>();

            // 仕入先取得用
            GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();
            List<GoodsSupplierDataWork> GoodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));

            try
            {
                #region 自社在庫取得クエリ

                #region Selecet文
                string SelectDm = string.Empty;
                SelectDm += "SELECT DISTINCT" + Environment.NewLine;
                SelectDm += "  STK.ENTERPRISECODERF AS STK_ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " ,STK.SECTIONCODERF AS STK_SECTIONCODERF" + Environment.NewLine;
                SelectDm += " ,STK.GOODSMAKERCDRF AS STK_GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " ,STK.GOODSNORF AS STK_GOODSNORF " + Environment.NewLine;
                SelectDm += " ,STK.STOCKUNITPRICEFLRF AS STK_STOCKUNITPRICEFLRF" + Environment.NewLine; // 仕入単価（税抜,浮動）
                SelectDm += " ,STK.SUPPLIERSTOCKRF AS STK_SUPPLIERSTOCKRF" + Environment.NewLine;
                SelectDm += " ,STK.LASTSTOCKDATERF AS STK_LASTSTOCKDATERF" + Environment.NewLine;
                SelectDm += " ,STK.LASTINVENTORYUPDATERF AS STK_LASTINVENTORYUPDATERF" + Environment.NewLine;
                SelectDm += " ,STK.WAREHOUSECODERF AS STK_WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += " ,STK.WAREHOUSESHELFNORF AS STK_WAREHOUSESHELFNORF" + Environment.NewLine;
                SelectDm += " ,STK.DUPLICATIONSHELFNO1RF AS STK_DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                SelectDm += " ,STK.DUPLICATIONSHELFNO2RF AS STK_DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                SelectDm += " ,STK.STOCKDIVRF AS STK_STOCKDIVRF" + Environment.NewLine;
                SelectDm += " ,STK.ARRIVALCNTRF AS STK_ARRIVALCNTRF" + Environment.NewLine; //入荷数（未計上）
                SelectDm += " ,STK.SHIPMENTCNTRF AS STK_SHIPMENTCNTRF" + Environment.NewLine;//出荷数（未計上）
                SelectDm += " ,STK.MOVINGSUPLISTOCKRF AS STK_MOVINGSUPLISTOCKRF" + Environment.NewLine;//移動中仕入在庫数
                SelectDm += " ,GOODS.JANRF AS GOODS_JANRF" + Environment.NewLine;
                SelectDm += " ,GOODS.BLGOODSCODERF AS GOODS_BLGOODSCODERF" + Environment.NewLine;
                SelectDm += " ,GOODS.ENTERPRISEGANRECODERF AS GOODS_ENTERPRISEGANRECODERF" + Environment.NewLine;
                SelectDm += " ,GOODS.GOODSRATERANKRF AS GOODS_GOODSRATERANKRF" + Environment.NewLine;
                SelectDm += " ,BLGOODS.BLGROUPCODERF AS BLGOODS_BLGROUPCODERF" + Environment.NewLine;
                SelectDm += " ,BLGROUP.GOODSLGROUPRF AS BLGROUP_GOODSLGROUPRF" + Environment.NewLine;
                SelectDm += " ,BLGROUP.GOODSMGROUPRF AS BLGROUP_GOODSMGROUPRF" + Environment.NewLine;
                //SelectDm += "FROM STOCKRF AS STK" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "FROM STOCKRF AS STK WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                // 商品
                //SelectDm += "INNER JOIN GOODSURF AS GOODS " + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "INNER JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " ON GOODS.ENTERPRISECODERF=STK.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GOODS.GOODSMAKERCDRF=STK.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND GOODS.GOODSNORF=STK.GOODSNORF" + Environment.NewLine;
                // BLコード 
                //SelectDm += "LEFT JOIN BLGOODSCDURF AS BLGOODS " + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "LEFT JOIN BLGOODSCDURF AS BLGOODS WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " ON STK.ENTERPRISECODERF = BLGOODS.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GOODS.BLGOODSCODERF = BLGOODS.BLGOODSCODERF" + Environment.NewLine;
                // BLグループ
                //SelectDm += "LEFT JOIN BLGROUPURF AS BLGROUP " + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "LEFT JOIN BLGROUPURF AS BLGROUP WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " ON STK.ENTERPRISECODERF = BLGROUP.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND BLGOODS.BLGROUPCODERF = BLGROUP.BLGROUPCODERF" + Environment.NewLine;

                sqlCommand = new SqlCommand(SelectDm, sqlConnection, sqlTrans);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, inventoryExtCndtnWork, logicalMode, 1);

                //ソート処理追加
                sqlCommand.CommandText += " ORDER BY STK.WAREHOUSECODERF, STK.GOODSMAKERCDRF, STK.GOODSNORF";

                #endregion    // Selecet文

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    InventoryDataWork wkInventoryDataWork = new InventoryDataWork();

                    GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
                    UnitPriceCalcParamWork unitPriceCalcParam = new UnitPriceCalcParamWork();
                    GoodsUnitDataWork goodsUnitData = new GoodsUnitDataWork(); // 商品連結データオブジェクトリスト

                    #region 棚卸データ値セット
                    wkInventoryDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_ENTERPRISECODERF"));           // 企業コード
                    wkInventoryDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_SECTIONCODERF"));                 // 拠点コード
                    wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_WAREHOUSECODERF"));             // 倉庫コード
                    wkInventoryDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_GOODSMAKERCDRF"));                // メーカーコード
                    wkInventoryDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_GOODSNORF"));                         // 商品コード
                    wkInventoryDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_WAREHOUSESHELFNORF"));       // 棚番
                    wkInventoryDataWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_DUPLICATIONSHELFNO1RF")); // 重複棚番1
                    wkInventoryDataWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_DUPLICATIONSHELFNO2RF")); // 重複棚番2
                    wkInventoryDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_ENTERPRISEGANRECODERF"));// 自社分類コード
                    wkInventoryDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_BLGOODSCODERF"));                // 商品マスタ・BLコード
                    wkInventoryDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_JANRF"));                               // 商品マスタ・JANコード
                    wkInventoryDataWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_STOCKUNITPRICEFLRF"));       // 仕入単価
                    wkInventoryDataWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_STOCKUNITPRICEFLRF"));     // 変更前仕入単価
                    wkInventoryDataWork.StkUnitPriceChgFlg = 0;                                                                                         // 仕入単価変更フラグ 0:無 1:あり 
                    wkInventoryDataWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_STOCKDIVRF"));                        // 在庫区分 0:自社 1:受託
                    wkInventoryDataWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STK_LASTSTOCKDATERF")); // 最終仕入年月日
                    wkInventoryDataWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_SUPPLIERSTOCKRF"));                // 帳簿数
                    wkInventoryDataWork.ShipCustomerCode = 0;                                                                                           // 出荷得意先コード
                    wkInventoryDataWork.InventoryPreprDay = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);                      // 棚卸準備処理日
                    wkInventoryDataWork.InventoryPreprTim = SysTime;                                                                                    // 棚卸準備処理時間
                    wkInventoryDataWork.LastInventoryUpdate = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);                    // 最終棚卸更新日 
                    wkInventoryDataWork.ToleranceUpdateCd = 0; // 過不足更新区分
                    wkInventoryDataWork.StockTotalExec = 0;    // 在庫総数(実施日)
                    wkInventoryDataWork.InventoryNewDiv = 0;                                                                                            // 棚卸新規追加区分 0:自動作成 1:新規作成

                    wkInventoryDataWork.StockMashinePrice = Convert.ToInt64(wkInventoryDataWork.StockUnitPriceFl * wkInventoryDataWork.StockTotal);　 // マシン在庫額
                    wkInventoryDataWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSLGROUPRF"));              // 商品大分類コード  
                    wkInventoryDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));              // 商品中分類コード
                    wkInventoryDataWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODS_BLGROUPCODERF"));              // BLグループコード  

                    wkInventoryDataWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_ARRIVALCNTRF"));               // 入荷数（未計上）
                    wkInventoryDataWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_SHIPMENTCNTRF"));              // 出荷数（未計上）
                    wkInventoryDataWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_MOVINGSUPLISTOCKRF"));     // 移動中仕入在庫数
                    al.Add(wkInventoryDataWork);
                    #endregion    // 棚卸データ値セット

                    #region 商品仕入取得データクラス
                    goodsSupplierDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_ENTERPRISECODERF"));// 企業コード
                    goodsSupplierDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_SECTIONCODERF"));      // 拠点コード
                    goodsSupplierDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_GOODSMAKERCDRF"));     // メーカーコード
                    goodsSupplierDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_GOODSNORF"));              // 商品番号
                    goodsSupplierDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_BLGOODSCODERF"));     // BLコード
                    goodsSupplierDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));   // 商品中分類コード
                    GoodsSupplierDataWorkList.Add(goodsSupplierDataWork);
                    #endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (!myReader.IsClosed) myReader.Close();
                #endregion    // 自社在庫取得クエリ

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 商品仕入先情報取得処理 実行
                    goodsSupplierGetter.GetGoodsMngInfo(ref GoodsSupplierDataWorkList);

                    #region 商品仕入先情報取得処理 結果セット
                    // 商品仕入先情報取得処理により取得した仕入先を
                    // 単価算出パラメータ・棚卸データワークにセット
                    for (int i = 0; i < GoodsSupplierDataWorkList.Count; i++) // 商品仕入取得データクラス
                    {
                        //-- UPD 2012/05/21 ------------------------------------------------------------------>>>>
                        #region DEL 無駄ループを削除、配列番号で紐付けるようにする。
                        //for (int j = 0; j < al.Count; j++) // 棚卸データワーク
                        //{
                        //    if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == al[j].GoodsMakerCd) && // 商品メーカー
                        //        (GoodsSupplierDataWorkList[i].GoodsNo == al[j].GoodsNo) &&           // 商品番号
                        //        (GoodsSupplierDataWorkList[i].BLGoodsCode == al[j].BLGoodsCode))     // BL商品コード
                        //    {
                        //        if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                        //        {
                        //            al[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // 仕入先セット
                        //        }
                        //    }
                        //}
                        #endregion
                        if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == al[i].GoodsMakerCd) && // 商品メーカー
                            (GoodsSupplierDataWorkList[i].GoodsNo == al[i].GoodsNo) &&           // 商品番号
                            (GoodsSupplierDataWorkList[i].BLGoodsCode == al[i].BLGoodsCode))     // BL商品コード
                        {
                            if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                            {
                                al[i].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd;
                            }
                        }
                        else
                        {
                            throw new Exception("商品管理情報と棚卸データの紐付きが不正です。（在庫マスタ検索処理(棚卸データ存在チェック用)）" +
                                                i.ToString() + " : " +
                                                GoodsSupplierDataWorkList[i].GoodsMakerCd.ToString() + ", " +
                                                GoodsSupplierDataWorkList[i].GoodsNo.ToString() + " : " +
                                                al[i].GoodsMakerCd.ToString() + ", " +
                                                al[i].GoodsNo.ToString());
                        }
                        // -- UPD 2012/05/21 ------------------------------------------------------------------<<<<
                    }
                    #endregion

                    #region 仕入先コード抽出条件
                    for (int i = 0; i < al.Count; i++) // 棚卸データワーク
                    {
                        if ((inventoryExtCndtnWork.StCustomerCd <= al[i].SupplierCd) &&
                            (inventoryExtCndtnWork.EdCustomerCd >= al[i].SupplierCd))
                        {
                            wkList.Add(al[i]);
                        }
                    }
                    #endregion

                    al = wkList;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SeachProductStockRepart Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion
        // --- ADD 2010/02/20 ----------<<<<<

        #region 在庫マスタ検索処理
        /// <summary>
        /// 在庫製番マスタを検索し、棚卸データListを戻します
        /// </summary>
        /// <param name="al">棚卸データList</param>
        /// <param name="inventoryExtCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="supplierDic">仕入先マスタ情報Dictionary</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫製番マスタを検索し、棚卸データListを戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        /// <br>Update Note : 2011/01/11 yangmj 棚卸障害対応</br>
        /// <br>Update Note : 2011/09/02 wangf NSユーザー改良要望一覧_20110629_優先_PM7相違_障害_連番1014の対応</br>
        /// <br>Update Note: 2012/06/08 yangyi</br>
        /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#30282 №1002 棚卸準備処理の改良の対応</br>
        /// <br>Update Note: 2013/03/06 zhoug</br>
        /// <br>管理番号   ：10901225-00 2013/5/15配信分の緊急対応</br>
        /// <br>             Redmine#34756対応：棚卸準備処理</br>
        /// <br>Update Note: 2013/06/07 wangl2</br>
        /// <br>管理番号   ：10801804-00 2013/06/18配信分</br>
        /// <br>             Redmine#35788：「棚卸準備処理」の原価取得で掛率優先順位が評価されない（№1949）</br>
        /// <br>                             エラー発生時原価が登録されない件の対応でエラー処理追加(#8の件)</br>
        /// <br>Update Note: 2020/06/18 譚洪</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br>           : PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Update Note :2020/07/23 譚洪</br>
        /// <br>管理番号    :11675035-00</br>
        /// <br>             PMKOBETSU-3551 棚卸準備処理を実行すると処理に失敗する現象の解除</br>
        /// <br>Update Note: 2021/03/16 譚洪</br>
        /// <br>管理番号   : 11770024-00</br>
        /// <br>             PMKOBETSU-3551 棚卸準備処理の対応</br>
        //private int SeachProductStock(out List<InventoryDataWork> al, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode)  // DEL 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理
        private int SeachProductStock(out List<InventoryDataWork> al, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode, Dictionary<int, SupplierWork> supplierDic)  // ADD 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlCommand sqlCommand2 = null;
            SqlDataReader myReader = null;
            SqlDataReader myReader2 = null;
            al = new List<InventoryDataWork>();
            List<InventoryDataWork> wkList = new List<InventoryDataWork>();

            // 修正 2009/04/27 >>>
            // 仕入先取得用
            GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();
            List<GoodsSupplierDataWork> GoodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();

            // 原価算出用
            UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
            List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>(); // 原価計算パラメータオブジェクトリスト
            List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();                // 商品連結データオブジェクトリスト
            List<UnitPriceCalcRetWork> unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();       // 原価計算結果リスト 
            Dictionary<string, RateWork> rateWorkByGoodsNoDic = new Dictionary<string, RateWork>();   // 単品掛率Dic// ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 

            // 修正 2009/04/27 <<<

            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));

            try
            {
                #region 自社在庫取得クエリ

                #region Selecet文
                // 修正 2009/04/27 >>>
                #region DEL 2009/04/27
                /*
                string SelectDm = "";
                SelectDm += "SELECT DISTINCT" + Environment.NewLine;
                //在庫マスタ情報取得
                #region 2008/09/18 修正前                
                //SelectDm += " STK.ENTERPRISECODERF STK_ENTERPRISECODERF";
                //SelectDm += ", STK.SECTIONCODERF STK_SECTIONCODERF";
                //SelectDm += ", STK.GOODSMAKERCDRF STK_GOODSMAKERCDRF";
                //SelectDm += ", STK.MAKERNAMERF STK_MAKERNAMERF";
                //SelectDm += ", STK.GOODSNORF STK_GOODSNORF";
                //SelectDm += ", STK.GOODSNAMERF STK_GOODSNAMERF";
                //SelectDm += ", STK.STOCKUNITPRICEFLRF STK_STOCKUNITPRICEFLRF";
                //SelectDm += ", STK.SUPPLIERSTOCKRF STK_SUPPLIERSTOCKRF";
                //SelectDm += ", STK.LASTSTOCKDATERF STK_LASTSTOCKDATERF";
                //SelectDm += ", STK.LASTINVENTORYUPDATERF STK_LASTINVENTORYUPDATERF";
                //SelectDm += ", STK.WAREHOUSECODERF STK_WAREHOUSECODERF";
                //SelectDm += ", STK.WAREHOUSENAMERF STK_WAREHOUSENAMERF";
                //SelectDm += ", STK.WAREHOUSESHELFNORF STK_WAREHOUSESHELFNORF";
                //SelectDm += ", STK.DUPLICATIONSHELFNO1RF STK_DUPLICATIONSHELFNO1RF";
                //SelectDm += ", STK.DUPLICATIONSHELFNO2RF STK_DUPLICATIONSHELFNO2RF";
                //SelectDm += ", STK.LARGEGOODSGANRECODERF STK_LARGEGOODSGANRECODERF";
                //SelectDm += ", STK.LARGEGOODSGANRENAMERF STK_LARGEGOODSGANRENAMERF";
                //SelectDm += ", STK.MEDIUMGOODSGANRECODERF STK_MEDIUMGOODSGANRECODERF";
                //SelectDm += ", STK.MEDIUMGOODSGANRENAMERF STK_MEDIUMGOODSGANRENAMERF";
                //SelectDm += ", STK.DETAILGOODSGANRECODERF STK_DETAILGOODSGANRECODERF";
                //SelectDm += ", STK.DETAILGOODSGANRENAMERF STK_DETAILGOODSGANRENAMERF";
                //SelectDm += ", STK.BLGOODSCODERF STK_BLGOODSCODERF";
                //SelectDm += ", STK.ENTERPRISEGANRECODERF STK_ENTERPRISEGANRECODERF";
                //SelectDm += ", STK.ENTERPRISEGANRENAMERF STK_ENTERPRISEGANRENAMERF";
                //SelectDm += ", STK.JANRF STK_JANRF";                 
                #endregion
                SelectDm += " STK.ENTERPRISECODERF STK_ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += ", STK.SECTIONCODERF STK_SECTIONCODERF" + Environment.NewLine;
                SelectDm += ", STK.GOODSMAKERCDRF STK_GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += ", STK.GOODSNORF STK_GOODSNORF" + Environment.NewLine;
                SelectDm += ", STK.STOCKUNITPRICEFLRF STK_STOCKUNITPRICEFLRF" + Environment.NewLine;
                SelectDm += ", STK.SUPPLIERSTOCKRF STK_SUPPLIERSTOCKRF" + Environment.NewLine;
                SelectDm += ", STK.LASTSTOCKDATERF STK_LASTSTOCKDATERF" + Environment.NewLine;
                SelectDm += ", STK.LASTINVENTORYUPDATERF STK_LASTINVENTORYUPDATERF" + Environment.NewLine;
                SelectDm += ", STK.WAREHOUSECODERF STK_WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += ", STK.WAREHOUSESHELFNORF STK_WAREHOUSESHELFNORF" + Environment.NewLine;
                SelectDm += ", STK.DUPLICATIONSHELFNO1RF STK_DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                SelectDm += ", STK.DUPLICATIONSHELFNO2RF STK_DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                SelectDm += ", STK.STOCKDIVRF AS STK_STOCKDIVRF" + Environment.NewLine; // ADD 2009.01.30
                SelectDm += ", GOODS.JANRF GOODS_JANRF" + Environment.NewLine;
                SelectDm += ", GOODS.BLGOODSCODERF GOODS_BLGOODSCODERF" + Environment.NewLine;
                SelectDm += ", GOODS.ENTERPRISEGANRECODERF GOODS_ENTERPRISEGANRECODERF" + Environment.NewLine;
                // ADD 2009.01.30 >>>
                SelectDm += ", BLGOODS.BLGROUPCODERF AS BLGOODS_BLGROUPCODERF" + Environment.NewLine;
                SelectDm += ", BLGROUP.GOODSLGROUPRF BLGROUP_GOODSLGROUPRF" + Environment.NewLine;
                SelectDm += ", BLGROUP.GOODSMGROUPRF BLGROUP_GOODSMGROUPRF" + Environment.NewLine;
                //SelectDm += ", (CASE WHEN GOODSMNG.SUPPLIERCDRF IS NOT NULL  THEN GOODSMNG.SUPPLIERCDRF " + Environment.NewLine;
                //SelectDm += "     ELSE (CASE WHEN GOODSMNG2.SUPPLIERCDRF IS NOT NULL THEN GOODSMNG2.SUPPLIERCDRF " + Environment.NewLine;
                //SelectDm += "           ELSE (CASE WHEN GOODSMNG3.SUPPLIERCDRF IS NOT NULL THEN GOODSMNG3.SUPPLIERCDRF ELSE GOODSMNG4.SUPPLIERCDRF END ) END )  END) GOODSMNG_SUPPLIERCDRF" + Environment.NewLine;
                // ADD 2009.01.30 <<<
                SelectDm += " FROM STOCKRF STK " + Environment.NewLine;
                SelectDm += " LEFT JOIN GOODSURF AS GOODS ON" + Environment.NewLine;
                SelectDm += " GOODS.ENTERPRISECODERF=STK.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GOODS.GOODSMAKERCDRF=STK.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND GOODS.GOODSNORF=STK.GOODSNORF" + Environment.NewLine;
                // ADD 2009.01.30 >>>
                // BLコードマスタ
                SelectDm += "LEFT JOIN BLGOODSCDURF AS BLGOODS" + Environment.NewLine;
                SelectDm += " ON STK.ENTERPRISECODERF = BLGOODS.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GOODS.BLGOODSCODERF = BLGOODS.BLGOODSCODERF" + Environment.NewLine;
                // BLグループコードマスタ
                SelectDm += "LEFT JOIN BLGROUPURF AS BLGROUP " + Environment.NewLine;
                SelectDm += " ON STK.ENTERPRISECODERF = BLGROUP.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND BLGOODS.BLGROUPCODERF = BLGROUP.BLGROUPCODERF" + Environment.NewLine;
                // 商品管理情報マスタ
                //SelectDm += "LEFT JOIN GOODSMNGRF AS GOODSMNG" + Environment.NewLine;
                //SelectDm += " ON STK.ENTERPRISECODERF = GOODSMNG.ENTERPRISECODERF --企業" + Environment.NewLine;
                //SelectDm += " AND STK.SECTIONCODERF = GOODSMNG.SECTIONCODERF      -- 拠点" + Environment.NewLine;
                //SelectDm += " AND STK.GOODSMAKERCDRF = GOODSMNG.GOODSMAKERCDRF --メーカー" + Environment.NewLine;
                //SelectDm += " AND STK.GOODSNORF= GOODSMNG.GOODSNORF -- 品番" + Environment.NewLine;

                //SelectDm += "LEFT JOIN GOODSMNGRF AS GOODSMNG2" + Environment.NewLine;
                //SelectDm += " ON STK.ENTERPRISECODERF = GOODSMNG2.ENTERPRISECODERF --企業" + Environment.NewLine;
                //SelectDm += " AND '00' = GOODSMNG2.SECTIONCODERF      -- 拠点" + Environment.NewLine;
                //SelectDm += " AND STK.GOODSMAKERCDRF = GOODSMNG2.GOODSMAKERCDRF --メーカー" + Environment.NewLine;
                //SelectDm += " AND STK.GOODSNORF= GOODSMNG2.GOODSNORF -- 品番" + Environment.NewLine;
                
                //SelectDm += "LEFT JOIN GOODSMNGRF AS GOODSMNG3" + Environment.NewLine;
                //SelectDm += " ON STK.ENTERPRISECODERF = GOODSMNG3.ENTERPRISECODERF --企業" + Environment.NewLine;
                //SelectDm += " AND STK.SECTIONCODERF = GOODSMNG3.SECTIONCODERF      -- 拠点" + Environment.NewLine;
                //SelectDm += " AND STK.GOODSMAKERCDRF = GOODSMNG3.GOODSMAKERCDRF --メーカー" + Environment.NewLine;
                //SelectDm += " AND GOODS.BLGOODSCODERF= GOODSMNG3.BLGOODSCODERF -- BL商品コード" + Environment.NewLine;
                //SelectDm += " AND GOODSMNG2.GOODSNORF = '' -- 品番" + Environment.NewLine;
                //SelectDm += " AND (CASE WHEN BLGROUP.GOODSMGROUPRF IS NULL THEN 0 ELSE BLGROUP.GOODSMGROUPRF END) = GOODSMNG3.GOODSMGROUPRF " + Environment.NewLine;

                //SelectDm += "LEFT JOIN GOODSMNGRF AS GOODSMNG4" + Environment.NewLine;
                //SelectDm += " ON STK.ENTERPRISECODERF = GOODSMNG4.ENTERPRISECODERF --企業" + Environment.NewLine;
                //SelectDm += " AND '00' = GOODSMNG4.SECTIONCODERF      -- 拠点" + Environment.NewLine;
                //SelectDm += " AND STK.GOODSMAKERCDRF = GOODSMNG4.GOODSMAKERCDRF --メーカー" + Environment.NewLine;
                //SelectDm += " AND GOODS.BLGOODSCODERF= GOODSMNG4.BLGOODSCODERF -- BL商品コード" + Environment.NewLine;
                //SelectDm += " AND GOODSMNG4.GOODSNORF = '' -- 品番" + Environment.NewLine;
                //SelectDm += " AND (CASE WHEN BLGROUP.GOODSMGROUPRF IS NULL THEN 0 ELSE BLGROUP.GOODSMGROUPRF END) = GOODSMNG4.GOODSMGROUPRF " + Environment.NewLine;
                // ADD 2009.01.30 <<<
                */
                #endregion
                string SelectDm = string.Empty;
                SelectDm += "SELECT DISTINCT" + Environment.NewLine;
                SelectDm += "  STK.ENTERPRISECODERF AS STK_ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " ,STK.SECTIONCODERF AS STK_SECTIONCODERF" + Environment.NewLine;
                SelectDm += " ,STK.GOODSMAKERCDRF AS STK_GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " ,STK.GOODSNORF AS STK_GOODSNORF " + Environment.NewLine;
                SelectDm += " ,GOODS.GOODSNAMERF AS GOODSNAMERF " + Environment.NewLine;// ADD 2011/01/11
                SelectDm += " ,STK.STOCKUNITPRICEFLRF AS STK_STOCKUNITPRICEFLRF" + Environment.NewLine; // 仕入単価（税抜,浮動）
                SelectDm += " ,STK.SUPPLIERSTOCKRF AS STK_SUPPLIERSTOCKRF" + Environment.NewLine;
                SelectDm += " ,STK.LASTSTOCKDATERF AS STK_LASTSTOCKDATERF" + Environment.NewLine;
                SelectDm += " ,STK.LASTINVENTORYUPDATERF AS STK_LASTINVENTORYUPDATERF" + Environment.NewLine;
                SelectDm += " ,STK.WAREHOUSECODERF AS STK_WAREHOUSECODERF" + Environment.NewLine;
                SelectDm += " ,STK.WAREHOUSESHELFNORF AS STK_WAREHOUSESHELFNORF" + Environment.NewLine;
                SelectDm += " ,STK.DUPLICATIONSHELFNO1RF AS STK_DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                SelectDm += " ,STK.DUPLICATIONSHELFNO2RF AS STK_DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                SelectDm += " ,STK.STOCKDIVRF AS STK_STOCKDIVRF" + Environment.NewLine;
                // --- ADD 2009/11/30 ---------->>>>>
                SelectDm += " ,STK.ARRIVALCNTRF AS STK_ARRIVALCNTRF" + Environment.NewLine; //入荷数（未計上）
                SelectDm += " ,STK.SHIPMENTCNTRF AS STK_SHIPMENTCNTRF" + Environment.NewLine;//出荷数（未計上）
                SelectDm += " ,STK.MOVINGSUPLISTOCKRF AS STK_MOVINGSUPLISTOCKRF" + Environment.NewLine;//移動中仕入在庫数
                // --- ADD 2009/11/30 ----------<<<<<
                SelectDm += " ,GOODS.JANRF AS GOODS_JANRF" + Environment.NewLine;
                SelectDm += " ,GOODS.BLGOODSCODERF AS GOODS_BLGOODSCODERF" + Environment.NewLine;
                SelectDm += " ,GOODS.ENTERPRISEGANRECODERF AS GOODS_ENTERPRISEGANRECODERF" + Environment.NewLine;
                // --- ADD 2009/11/30 ---------->>>>>
                SelectDm += " ,GOODS.GOODSRATERANKRF AS GOODS_GOODSRATERANKRF" + Environment.NewLine;
                // --- ADD 2009/11/30 ----------<<<<<
                SelectDm += " ,BLGOODS.BLGROUPCODERF AS BLGOODS_BLGROUPCODERF" + Environment.NewLine;
                SelectDm += " ,BLGOODS.GOODSRATEGRPCODERF AS BLGOODS_GOODSRATEGRPCODERF" + Environment.NewLine; // ADD caohh 2015/03/06 for Redmine#44951
                SelectDm += " ,BLGROUP.GOODSLGROUPRF AS BLGROUP_GOODSLGROUPRF" + Environment.NewLine;
                SelectDm += " ,BLGROUP.GOODSMGROUPRF AS BLGROUP_GOODSMGROUPRF" + Environment.NewLine;
                // --- DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                ////-----ADD 2011/01/11----->>>>>
                //SelectDm += " , GOODSPRICE.PRICESTARTDATERF AS GOODSPRICE_PRICESTARTDATERF" + Environment.NewLine; ;// 価格開始日
                //SelectDm += " , GOODSPRICE.LISTPRICERF AS GOODSPRICE_LISTPRICERF" + Environment.NewLine; ;// 定価（浮動）
                ////-----ADD 2011/01/11-----<<<<<
                // --- DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
                // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                SelectDm += " ,GOODSPRICEURF.CREATEDATETIMERF AS GPRICEU_CREATEDATETIMERF,GOODSPRICEURF.UPDATEDATETIMERF AS GPRICEU_UPDATEDATETIMERF" + Environment.NewLine;
                SelectDm += " ,GOODSPRICEURF.ENTERPRISECODERF AS GPRICEU_ENTERPRISECODERF,GOODSPRICEURF.FILEHEADERGUIDRF AS GPRICEU_FILEHEADERGUIDRF" + Environment.NewLine;
                SelectDm += " ,GOODSPRICEURF.UPDEMPLOYEECODERF AS GPRICEU_UPDEMPLOYEECODERF,GOODSPRICEURF.UPDASSEMBLYID1RF AS GPRICEU_UPDASSEMBLYID1RF" + Environment.NewLine;
                SelectDm += " ,GOODSPRICEURF.UPDASSEMBLYID2RF AS GPRICEU_UPDASSEMBLYID2RF,GOODSPRICEURF.LOGICALDELETECODERF AS GPRICEU_LOGICALDELETECODERF" + Environment.NewLine;
                SelectDm += " ,GOODSPRICEURF.GOODSMAKERCDRF AS GPRICEU_GOODSMAKERCDRF,GOODSPRICEURF.GOODSNORF AS GPRICEU_GOODSNORF" + Environment.NewLine;
                SelectDm += " ,GOODSPRICEURF.PRICESTARTDATERF AS GPRICEU_PRICESTARTDATERF,GOODSPRICEURF.LISTPRICERF AS GPRICEU_LISTPRICERF" + Environment.NewLine;
                SelectDm += " ,GOODSPRICEURF.SALESUNITCOSTRF AS GPRICEU_SALESUNITCOSTRF,GOODSPRICEURF.STOCKRATERF AS GPRICEU_STOCKRATERF" + Environment.NewLine;
                SelectDm += " ,GOODSPRICEURF.OPENPRICEDIVRF AS GPRICEU_OPENPRICEDIVRF,GOODSPRICEURF.OFFERDATERF AS GPRICEU_OFFERDATERF" + Environment.NewLine;
                SelectDm += " ,GOODSPRICEURF.UPDATEDATERF AS GPRICEU_UPDATEDATERF " + Environment.NewLine;
                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                SelectDm += " ,RATE.PRICEFLRF AS RATE_PRICEFLRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEVALRF AS RATE_RATEVALRF " + Environment.NewLine;
                // --- ADD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                SelectDm += " ,RATE.UNPRCFRACPROCUNITRF AS RATE_UNPRCFRACPROCUNITRF " + Environment.NewLine;
                SelectDm += " ,RATE.UNPRCFRACPROCDIVRF AS RATE_UNPRCFRACPROCDIVRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATESETTINGDIVIDERF AS RATE_RATESETTINGDIVIDERF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEMNGGOODSCDRF AS RATE_RATEMNGGOODSCDRF " + Environment.NewLine;
                SelectDm += " ,RATE.RATEMNGCUSTCDRF AS RATE_RATEMNGCUSTCDRF " + Environment.NewLine;
                SelectDm += " ,RATE.SECTIONCODERF AS RATE_SECTIONCODERF " + Environment.NewLine;
                SelectDm += " ,RATE.LOTCOUNTRF AS RATE_LOTCOUNTRF " + Environment.NewLine;
                // --- ADD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
                SelectDm += " ,RATE2.PRICEFLRF AS RATE2_PRICEFLRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEVALRF AS RATE2_RATEVALRF " + Environment.NewLine;
                SelectDm += " ,RATE2.UNPRCFRACPROCUNITRF AS RATE2_UNPRCFRACPROCUNITRF " + Environment.NewLine;
                SelectDm += " ,RATE2.UNPRCFRACPROCDIVRF AS RATE2_UNPRCFRACPROCDIVRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATESETTINGDIVIDERF AS RATE2_RATESETTINGDIVIDERF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEMNGGOODSCDRF AS RATE2_RATEMNGGOODSCDRF " + Environment.NewLine;
                SelectDm += " ,RATE2.RATEMNGCUSTCDRF AS RATE2_RATEMNGCUSTCDRF " + Environment.NewLine;
                SelectDm += " ,RATE2.SECTIONCODERF AS RATE2_SECTIONCODERF " + Environment.NewLine;
                SelectDm += " ,RATE2.LOTCOUNTRF AS RATE2_LOTCOUNTRF " + Environment.NewLine;
                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
                // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<        
                //SelectDm += "FROM STOCKRF AS STK" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "FROM STOCKRF AS STK WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                // 商品
                //SelectDm += "INNER JOIN GOODSURF AS GOODS " + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "INNER JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " ON GOODS.ENTERPRISECODERF=STK.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GOODS.GOODSMAKERCDRF=STK.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND GOODS.GOODSNORF=STK.GOODSNORF" + Environment.NewLine;
                // BLコード 
                //SelectDm += "LEFT JOIN BLGOODSCDURF AS BLGOODS " + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "LEFT JOIN BLGOODSCDURF AS BLGOODS WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " ON STK.ENTERPRISECODERF = BLGOODS.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND GOODS.BLGOODSCODERF = BLGOODS.BLGOODSCODERF" + Environment.NewLine;
                // BLグループ
                //SelectDm += "LEFT JOIN BLGROUPURF AS BLGROUP " + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += "LEFT JOIN BLGROUPURF AS BLGROUP WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " ON STK.ENTERPRISECODERF = BLGROUP.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND BLGOODS.BLGROUPCODERF = BLGROUP.BLGROUPCODERF" + Environment.NewLine;
                //-----ADD 2011/01/11----->>>>>
                int inventoryDate = TDateTime.DateTimeToLongDate("YYYYMMDD", inventoryExtCndtnWork.InventoryDate);
                //SelectDm += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                // --- DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                //SelectDm += " LEFT JOIN GOODSPRICEURF AS GOODSPRICE WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                //SelectDm += " ON STK.ENTERPRISECODERF = GOODSPRICE.ENTERPRISECODERF" + Environment.NewLine;
                //SelectDm += " AND STK.GOODSMAKERCDRF = GOODSPRICE.GOODSMAKERCDRF" + Environment.NewLine;
                //SelectDm += " AND STK.GOODSNORF = GOODSPRICE.GOODSNORF " + Environment.NewLine;
                //SelectDm += " AND GOODSPRICE.PRICESTARTDATERF  <=" + inventoryDate.ToString() + Environment.NewLine;
                // --- DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
                //-----ADD 2011/01/11-----<<<<<
                // 修正 2009/04/27 <<<
                // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                SelectDm += " LEFT JOIN RATERF AS RATE WITH (READUNCOMMITTED)" + Environment.NewLine;
                SelectDm += " ON STK.ENTERPRISECODERF = RATE.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND STK.SECTIONCODERF = RATE.SECTIONCODERF" + Environment.NewLine;
                SelectDm += " AND STK.GOODSMAKERCDRF = RATE.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND STK.GOODSNORF = RATE.GOODSNORF" + Environment.NewLine;
                SelectDm += " AND STK.LOGICALDELETECODERF = RATE.LOGICALDELETECODERF" + Environment.NewLine;
                SelectDm += " AND RATE.UNITRATESETDIVCDRF = '26A'" + Environment.NewLine;
                SelectDm += " AND RATE.GOODSRATERANKRF    = ''" + Environment.NewLine;
                SelectDm += " AND RATE.GOODSRATEGRPCODERF = 0" + Environment.NewLine;
                SelectDm += " AND RATE.BLGROUPCODERF      = 0" + Environment.NewLine;
                SelectDm += " AND RATE.BLGOODSCODERF      = 0" + Environment.NewLine;
                SelectDm += " AND RATE.CUSTOMERCODERF     = 0" + Environment.NewLine;
                SelectDm += " AND RATE.CUSTRATEGRPCODERF  = 0" + Environment.NewLine;
                SelectDm += " AND RATE.SUPPLIERCDRF       = 0" + Environment.NewLine;
                SelectDm += " AND RATE.LOTCOUNTRF         = 9999999.99" + Environment.NewLine;
                SelectDm += " LEFT JOIN RATERF AS RATE2 WITH (READUNCOMMITTED)" + Environment.NewLine;
                SelectDm += " ON STK.ENTERPRISECODERF = RATE2.ENTERPRISECODERF" + Environment.NewLine;
                SelectDm += " AND RATE2.SECTIONCODERF = '00'" + Environment.NewLine;
                SelectDm += " AND STK.GOODSMAKERCDRF = RATE2.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND STK.GOODSNORF = RATE2.GOODSNORF" + Environment.NewLine;
                SelectDm += " AND STK.LOGICALDELETECODERF = RATE2.LOGICALDELETECODERF" + Environment.NewLine;
                SelectDm += " AND RATE2.UNITRATESETDIVCDRF = '26A'" + Environment.NewLine;
                SelectDm += " AND RATE2.GOODSRATERANKRF    = ''" + Environment.NewLine;
                SelectDm += " AND RATE2.GOODSRATEGRPCODERF = 0" + Environment.NewLine;
                SelectDm += " AND RATE2.BLGROUPCODERF      = 0" + Environment.NewLine;
                SelectDm += " AND RATE2.BLGOODSCODERF      = 0" + Environment.NewLine;
                SelectDm += " AND RATE2.CUSTOMERCODERF     = 0" + Environment.NewLine;
                SelectDm += " AND RATE2.CUSTRATEGRPCODERF  = 0" + Environment.NewLine;
                SelectDm += " AND RATE2.SUPPLIERCDRF       = 0" + Environment.NewLine;
                SelectDm += " AND RATE2.LOTCOUNTRF         = 9999999.99" + Environment.NewLine;
                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
                SelectDm += " LEFT JOIN GOODSPRICEURF WITH (READUNCOMMITTED)" + Environment.NewLine;
                SelectDm += " ON GOODSPRICEURF.ENTERPRISECODERF = STK.ENTERPRISECODERF AND GOODSPRICEURF.GOODSMAKERCDRF = STK.GOODSMAKERCDRF" + Environment.NewLine;
                SelectDm += " AND GOODSPRICEURF.GOODSNORF = STK.GOODSNORF" + Environment.NewLine;
                SelectDm += " AND GOODSPRICEURF.PRICESTARTDATERF  <=" + inventoryDate.ToString() + Environment.NewLine;// ADD caohh 2015/03/06 for Redmine#44951
                // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<     

                sqlCommand = new SqlCommand(SelectDm, sqlConnection, sqlTrans);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, inventoryExtCndtnWork, logicalMode, 1);

                /* -- DEL wangf 2011/09/02 ---------->>>>>
                //----- ADD 2011/01/11----->>>>>
                // 管理拠点
                if (inventoryExtCndtnWork.SectionCodeSt != "")
                {
                    sqlCommand.CommandText += " AND STK.SECTIONCODERF>=@SECTIONCODEST" + Environment.NewLine;
                    SqlParameter paraSectionCodeSt = sqlCommand.Parameters.Add("@SECTIONCODEST", SqlDbType.NVarChar);
                    paraSectionCodeSt.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeSt);
                }

                if (inventoryExtCndtnWork.SectionCodeEd != "")
                {
                    sqlCommand.CommandText += " AND STK.SECTIONCODERF<=@SECTIONCODEED" + Environment.NewLine;
                    SqlParameter paraSectionCodeEd = sqlCommand.Parameters.Add("@SECTIONCODEED", SqlDbType.NVarChar);
                    paraSectionCodeEd.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd);
                }
                //----- ADD 2011/01/11-----<<<<<
                // -- DEL wangf 2011/09/02 ----------<<<<<*/
                //----- ADD 2011/01/11----->>>>>
                // 管理拠点
                if (inventoryExtCndtnWork.SectionCodeSt != "")
                {
                    if (inventoryExtCndtnWork.SectionCodeEd != "")
                    {
                        sqlCommand.CommandText += " AND ((STK.SECTIONCODERF>=@SECTIONCODEST" + Environment.NewLine;
                    }
                    else
                    {
                        sqlCommand.CommandText += " AND STK.SECTIONCODERF>=@SECTIONCODEST" + Environment.NewLine;
                    }
                    SqlParameter paraSectionCodeSt = sqlCommand.Parameters.Add("@SECTIONCODEST", SqlDbType.NVarChar);
                    // 前画面からのパラメーター「管理拠点」左「0」を補足
                    paraSectionCodeSt.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeSt.PadLeft(2, '0'));
                }
                if (inventoryExtCndtnWork.SectionCodeEd != "")
                {
                    int startIndex = 0;
                    // パラメーター「管理拠点」>= 10の場合
                    if (!'0'.Equals(inventoryExtCndtnWork.SectionCodeEd.PadLeft(2, '0').Trim().ToCharArray()[0]))
                    {
                        if (inventoryExtCndtnWork.SectionCodeSt.CompareTo("10") < 0)
                        {
                            if (inventoryExtCndtnWork.SectionCodeSt != "")
                            {
                                sqlCommand.CommandText += " AND STK.SECTIONCODERF<='09'" + Environment.NewLine;
                            }
                            else
                            {
                                sqlCommand.CommandText += " AND ((STK.SECTIONCODERF<='09'" + Environment.NewLine;
                            }
                            if (inventoryExtCndtnWork.SectionCodeSt != "")
                            {
                                startIndex = Convert.ToInt32(inventoryExtCndtnWork.SectionCodeSt.Trim());
                            }
                            // -- UPD 2012/06/14 ------------------------------------>>>>
                            #region DELETE 拠点コードを0埋めにしていない障害の修正
                            //sqlCommand.CommandText += "OR (STK.SECTIONCODERF IN ( 9";
                            //for (int i = startIndex; i < 9; i++)
                            //{
                            //    sqlCommand.CommandText += ", " + i;
                            //}
                            #endregion
                            sqlCommand.CommandText += "OR (STK.SECTIONCODERF IN ( N'09'";
                            for (int i = startIndex; i < 9; i++)
                            {
                                sqlCommand.CommandText += ", N'" + i.ToString("00") + "'";
                            }
                            // -- UPD 2012/06/14 ------------------------------------<<<<
                            if (inventoryExtCndtnWork.SectionCodeSt != "")
                            {
                                sqlCommand.CommandText += "))) OR (STK.SECTIONCODERF >= '10' AND STK.SECTIONCODERF<=@SECTIONCODEED))";
                            }
                            else
                            {
                                sqlCommand.CommandText += "))) OR (STK.SECTIONCODERF >= '10' AND STK.SECTIONCODERF<=@SECTIONCODEED))";
                            }
                            SqlParameter paraSectionCodeEd = sqlCommand.Parameters.Add("@SECTIONCODEED", SqlDbType.NVarChar);
                            paraSectionCodeEd.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd);
                        }
                        else if (inventoryExtCndtnWork.SectionCodeSt.CompareTo("10") >= 0)
                        {
                            sqlCommand.CommandText += " AND STK.SECTIONCODERF<=@SECTIONCODEED))" + Environment.NewLine;
                            SqlParameter paraSectionCodeEd = sqlCommand.Parameters.Add("@SECTIONCODEED", SqlDbType.NVarChar);
                            paraSectionCodeEd.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd);
                        }
                    }
                    else
                    {
                        // -- UPD 2012/06/14 ------------------------------------>>>>
                        #region DELETE 拠点コードを0埋めにしていない障害の修正
                        //String sectionCodeValue = inventoryExtCndtnWork.SectionCodeEd.TrimStart('0');
                        ////循環処理　例：05~09 （5,6,7,8,9）
                        //if (inventoryExtCndtnWork.SectionCodeSt != "")
                        //{
                        //    if ('0'.Equals(inventoryExtCndtnWork.SectionCodeSt.PadLeft(2, '0').Trim().ToCharArray()[0]))
                        //    {
                        //        if (inventoryExtCndtnWork.SectionCodeSt != "")
                        //        {
                        //            startIndex = Convert.ToInt32(inventoryExtCndtnWork.SectionCodeSt.Trim());
                        //        }
                        //        for (int j = startIndex; j < Convert.ToInt32(inventoryExtCndtnWork.SectionCodeEd.Trim()); j++)
                        //        {
                        //            sectionCodeValue += "," + j;
                        //        }
                        //    }
                        //}
                        #endregion
                        String sectionCodeValue = "N'" + inventoryExtCndtnWork.SectionCodeEd + "'";
                        if (inventoryExtCndtnWork.SectionCodeSt != "")
                        {
                            if ('0'.Equals(inventoryExtCndtnWork.SectionCodeSt.PadLeft(2, '0').Trim().ToCharArray()[0]))
                            {
                                startIndex = Convert.ToInt32(inventoryExtCndtnWork.SectionCodeSt.Trim());
                                for (int j = startIndex; j < Convert.ToInt32(inventoryExtCndtnWork.SectionCodeEd.Trim()); j++)
                                {
                                    sectionCodeValue += ", N'" + j.ToString("00") + "'";
                                }
                            }
                        }
                        // -- UPD 2012/06/14 ------------------------------------<<<<
                        // DEL yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                        //sqlCommand.CommandText += " AND STK.SECTIONCODERF<=@SECTIONCODEED) OR STK.SECTIONCODERF IN (" + sectionCodeValue + ")" + Environment.NewLine;
                        // DEL yangyi 2012/06/08 Redmine#30282 -------------<<<<<
                        // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                        if (!string.IsNullOrEmpty(sectionCodeValue))
                        {
                            // -- UPD 2012/06/14 ------------------------------------>>>>
                            //sqlCommand.CommandText += " AND STK.SECTIONCODERF<=@SECTIONCODEED) OR STK.SECTIONCODERF IN (" + sectionCodeValue + ")" + Environment.NewLine;
                            if (inventoryExtCndtnWork.SectionCodeSt != "")
                            {
                                sqlCommand.CommandText += " AND STK.SECTIONCODERF<=@SECTIONCODEED) OR STK.SECTIONCODERF IN (" + sectionCodeValue + ")" + Environment.NewLine;
                            }
                            else
                            {
                                sqlCommand.CommandText += " AND STK.SECTIONCODERF<=@SECTIONCODEED OR STK.SECTIONCODERF IN (" + sectionCodeValue + ")" + Environment.NewLine;
                            }
                            // -- UPD 2012/06/14 ------------------------------------<<<<
                        }
                        else
                        {
                            sqlCommand.CommandText += " AND STK.SECTIONCODERF<=@SECTIONCODEED " + Environment.NewLine;
                        }
                        // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<
                        SqlParameter paraSectionCodeEd = sqlCommand.Parameters.Add("@SECTIONCODEED", SqlDbType.NVarChar);
                        paraSectionCodeEd.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd.PadLeft(2, '0'));
                        if (inventoryExtCndtnWork.SectionCodeSt != "")
                        {
                            sqlCommand.CommandText += ")";
                        }
                    }
                }
                //----- ADD 2011/01/11-----<<<<<

                //ソート処理追加
                // 修正 2008/09/18 >>>
                //sqlCommand.CommandText += " ORDER BY STK.WAREHOUSECODERF, STK.LARGEGOODSGANRECODERF, STK.MEDIUMGOODSGANRECODERF, STK.DETAILGOODSGANRECODERF, STK.GOODSMAKERCDRF, STK.GOODSNORF";
                //sqlCommand.CommandText += " ORDER BY STK.WAREHOUSECODERF, STK.GOODSMAKERCDRF, STK.GOODSNORF";// DEL 2011/01/11
                //sqlCommand.CommandText += " ORDER BY STK.WAREHOUSECODERF, STK.GOODSMAKERCDRF, STK.GOODSNORF, GOODSPRICE.PRICESTARTDATERF";// ADD 2011/01/11
                //sqlCommand.CommandText += " ORDER BY STK.WAREHOUSECODERF ASC, STK.GOODSMAKERCDRF ASC, STK.GOODSNORF ASC, GOODSPRICE.PRICESTARTDATERF DESC";// ADD 2011/02/12 //DEL 2012/04/09
                // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                //sqlCommand.CommandText += " ORDER BY STK.SECTIONCODERF ASC, STK.WAREHOUSECODERF ASC, STK.GOODSMAKERCDRF ASC, STK.GOODSNORF ASC, GOODSPRICE.PRICESTARTDATERF DESC";// ADD 2012/04/09
                sqlCommand.CommandText += " ORDER BY STK.SECTIONCODERF ASC, STK.WAREHOUSECODERF ASC, STK.GOODSMAKERCDRF ASC, STK.GOODSNORF ASC, GOODSPRICEURF.PRICESTARTDATERF DESC";
                // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
                // 修正 2008/09/18 <<<

                #endregion    // Selecet文

                sqlCommand.CommandTimeout = 3600; // ADD 2012/05/21
                myReader = sqlCommand.ExecuteReader();
                //----- ADD 2011/01/11----->>>>>
                InventoryDataWork beInventoryDataWork = null;
                //----- ADD 2011/01/11-----<<<<<
                // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                GoodsSupplierDataWork beGoodsSupplierDataWork = null;
                UnitPriceCalcParamWork beUnitPriceCalcParamWork = null;
                GoodsUnitDataWork beGoodsUnitDataWork = null;
                GoodsPriceUWork beGoodsPriceUWork = null;

                GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();
                string enterpriseCode = "";
                DateTime priceStartDate = DateTime.MinValue;
                //仕入金額処理区分マスタ読み込み
                //List<StockProcMoneyWork> stockProcMoneyList = this.SearchStockProcMoney(inventoryExtCndtnWork.EnterpriseCode);// DEL 2013/06/07 wangl2 For Redmine#35788
                //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                List<StockProcMoneyWork> stockProcMoneyList = new List<StockProcMoneyWork>();
                int status1 = unitPriceCalculation.SearchStockProcMoneyForInventory(inventoryExtCndtnWork.EnterpriseCode, out stockProcMoneyList);
                if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status1 != (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    return status1;
                }
                //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

                // 消費税の端数処理単位、端数処理区分を取得
                double taxFractionProcUnit;
                int taxFractionProcCd;
                this.GetStockFractionProcInfo(1, 0, 0, stockProcMoneyList, out taxFractionProcUnit, out taxFractionProcCd);
                //List<RateProtyMngWork> rateProtyMngAllList = SearchRateProtyMng(inventoryExtCndtnWork.EnterpriseCode);// DEL 2013/06/07 wangl2 For Redmine#35788
                //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                List<RateProtyMngWork> rateProtyMngAllList = new List<RateProtyMngWork>();
                status1 = unitPriceCalculation.SearchRateProtyMngForInventory(inventoryExtCndtnWork.EnterpriseCode, out rateProtyMngAllList);
                if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status1 != (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    return status1;
                }
                //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<


                List<RateWork> rateList;
                List<UnitPriceCalculation.UnitPriceKind> unitPriceKindList = new List<UnitPriceCalculation.UnitPriceKind>();
                unitPriceKindList.Add(UnitPriceCalculation.UnitPriceKind.UnitCost);
                //unitPriceCalculation.SearchRateForInventory(inventoryExtCndtnWork.EnterpriseCode , out rateList);// DEL 2013/06/07 wangl2 For Redmine#35788
                //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                //status1 = unitPriceCalculation.SearchRateForInventory(inventoryExtCndtnWork.EnterpriseCode, out rateList);
                status1 = unitPriceCalculation.SearchRateForInventory2(inventoryExtCndtnWork.EnterpriseCode, out rateList);
                // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
                {
                    if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status1 != (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        return status1;
                    }
                }
                //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

                Dictionary<string, GoodsMngWork> goodsMngDic1 = null;     //拠点＋メーカー＋品番
                Dictionary<string, GoodsMngWork> goodsMngDic2 = null;     //拠点＋中分類＋メーカー＋ＢＬ
                Dictionary<string, GoodsMngWork> goodsMngDic3 = null;     //拠点＋中分類＋メーカー
                Dictionary<string, GoodsMngWork> goodsMngDic4 = null;     //拠点＋メーカー

                goodsSupplierGetter.GetGoodsMngInfo(inventoryExtCndtnWork.EnterpriseCode,ref goodsMngDic1,ref goodsMngDic2,ref goodsMngDic3,ref goodsMngDic4);
                // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                string sectionCode = string.Empty;
                //int goodsMakerCd = 0;// DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応
                //string goodsNo = string.Empty;// DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応
                string keyValue = string.Empty;
                RateWork rateAllSec = null;
                // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<

                while (myReader.Read())
                {

                    InventoryDataWork wkInventoryDataWork = new InventoryDataWork();

                    // ADD 2009/04/27 >>>
                    GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
                    UnitPriceCalcParamWork unitPriceCalcParam = new UnitPriceCalcParamWork();
                    GoodsUnitDataWork goodsUnitData = new GoodsUnitDataWork(); // 商品連結データオブジェクトリスト
                    goodsPriceUWork = new GoodsPriceUWork();      //ADD yangyi 2013/05/06 Redmine#35493
                    // ADD 2009/04/27 <<<

                    #region 棚卸データ値セット
                    wkInventoryDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_ENTERPRISECODERF"));           // 企業コード
                    wkInventoryDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_SECTIONCODERF"));                 // 拠点コード
                    wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_WAREHOUSECODERF"));             // 倉庫コード
                    wkInventoryDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_GOODSMAKERCDRF"));                // メーカーコード
                    wkInventoryDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_GOODSNORF"));                         // 商品コード
                    wkInventoryDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_WAREHOUSESHELFNORF"));       // 棚番
                    wkInventoryDataWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_DUPLICATIONSHELFNO1RF")); // 重複棚番1
                    // --- ADD 2009/11/30 ---------->>>>>
                    wkInventoryDataWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_DUPLICATIONSHELFNO2RF")); // 重複棚番2
                    // --- ADD 2009/11/30 ----------<<<<<
                    wkInventoryDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_ENTERPRISEGANRECODERF"));// 自社分類コード
                    wkInventoryDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_BLGOODSCODERF"));                // 商品マスタ・BLコード
                    wkInventoryDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_JANRF"));                               // 商品マスタ・JANコード
                    wkInventoryDataWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_STOCKUNITPRICEFLRF"));       // 仕入単価
                    wkInventoryDataWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_STOCKUNITPRICEFLRF"));     // 変更前仕入単価
                    wkInventoryDataWork.StkUnitPriceChgFlg = 0;                                                                                         // 仕入単価変更フラグ 0:無 1:あり 
                    wkInventoryDataWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_STOCKDIVRF"));                        // 在庫区分 0:自社 1:受託
                    wkInventoryDataWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STK_LASTSTOCKDATERF")); // 最終仕入年月日
                    wkInventoryDataWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_SUPPLIERSTOCKRF"));                // 帳簿数
                    wkInventoryDataWork.ShipCustomerCode = 0;                                                                                           // 出荷得意先コード
                    wkInventoryDataWork.InventoryPreprDay = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);                      // 棚卸準備処理日
                    wkInventoryDataWork.InventoryPreprTim = SysTime;                                                                                    // 棚卸準備処理時間
                    // ADD 2009/05/22 >>>
                    wkInventoryDataWork.LastInventoryUpdate = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);                    // 最終棚卸更新日 
                    wkInventoryDataWork.ToleranceUpdateCd = 0; // 過不足更新区分
                    wkInventoryDataWork.StockTotalExec = 0;    // 在庫総数(実施日)
                    // ADD 2009/05/22 <<<
                    wkInventoryDataWork.InventoryNewDiv = 0;                                                                                            // 棚卸新規追加区分 0:自動作成 1:新規作成

                    wkInventoryDataWork.StockMashinePrice = Convert.ToInt64(wkInventoryDataWork.StockUnitPriceFl * wkInventoryDataWork.StockTotal);　 // マシン在庫額
                    // ADD 2009.01.30 >>>
                    wkInventoryDataWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSLGROUPRF"));              // 商品大分類コード  
                    wkInventoryDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));              // 商品中分類コード
                    wkInventoryDataWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODS_BLGROUPCODERF"));              // BLグループコード  
                    // ADD 2009.01.30 <<<

                    // --- ADD 2009/11/30 ---------->>>>>
                    wkInventoryDataWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_ARRIVALCNTRF"));               // 入荷数（未計上）
                    wkInventoryDataWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_SHIPMENTCNTRF"));              // 出荷数（未計上）
                    wkInventoryDataWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STK_MOVINGSUPLISTOCKRF"));         // 移動中仕入在庫数
                    // --- ADD 2009/11/30 ----------<<<<<

                    wkInventoryDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF")); // ADD 2011/01/11
                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                    //wkInventoryDataWork.ListPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICE_LISTPRICERF")); // ADD 2011/01/11
                    convertDoubleRelease.EnterpriseCode = wkInventoryDataWork.EnterpriseCode;
                    convertDoubleRelease.GoodsMakerCd = wkInventoryDataWork.GoodsMakerCd;
                    convertDoubleRelease.GoodsNo = wkInventoryDataWork.GoodsNo;
                    // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                    //convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GOODSPRICE_LISTPRICERF"));
                    convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_LISTPRICERF"));
                    // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<

                    // 変換処理実行
                    convertDoubleRelease.ReleaseProc();

                    wkInventoryDataWork.ListPriceFl = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<

                    // --- DEL yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                    //----- ADD 2011/01/11----->>>>>
                    //if (beInventoryDataWork != null)
                    //{
                    //    if (beInventoryDataWork.EnterpriseCode == wkInventoryDataWork.EnterpriseCode
                    //        && beInventoryDataWork.SectionCode == wkInventoryDataWork.SectionCode
                    //        && beInventoryDataWork.WarehouseCode == wkInventoryDataWork.WarehouseCode
                    //        && beInventoryDataWork.GoodsMakerCd == wkInventoryDataWork.GoodsMakerCd
                    //        && beInventoryDataWork.GoodsNo == wkInventoryDataWork.GoodsNo
                    //        && beInventoryDataWork.BLGroupCode == wkInventoryDataWork.BLGroupCode
                    //        && beInventoryDataWork.SupplierCd == wkInventoryDataWork.SupplierCd)
                    //    {
                    //        continue;
                    //    }
                    //}
                    //beInventoryDataWork = wkInventoryDataWork;
                    ////----- ADD 2011/01/11-----<<<<<

                    //al.Add(wkInventoryDataWork);
                    // --- DEL yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<
                    #endregion    // 棚卸データ値セット

                    // ADD 2009/04/24 >>>
                    #region 商品仕入取得データクラス
                    goodsSupplierDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_ENTERPRISECODERF"));// 企業コード
                    goodsSupplierDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_SECTIONCODERF"));      // 拠点コード
                    goodsSupplierDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_GOODSMAKERCDRF"));     // メーカーコード
                    goodsSupplierDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_GOODSNORF"));              // 商品番号
                    goodsSupplierDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_BLGOODSCODERF"));     // BLコード
                    goodsSupplierDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));   // 商品中分類コード
                    //GoodsSupplierDataWorkList.Add(goodsSupplierDataWork); //DEL yangyi 2013/05/06 Redmine#35493
                    //----ADD 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
                    goodsMngDic1 = goodsMngDic1 == null ? new Dictionary<string, GoodsMngWork>() : goodsMngDic1;
                    goodsMngDic2 = goodsMngDic2 == null ? new Dictionary<string, GoodsMngWork>() : goodsMngDic2;
                    goodsMngDic3 = goodsMngDic3 == null ? new Dictionary<string, GoodsMngWork>() : goodsMngDic3;
                    goodsMngDic4 = goodsMngDic4 == null ? new Dictionary<string, GoodsMngWork>() : goodsMngDic4;
                    //----ADD 2013/06/07 wangl2 for Redmine#35788 -------<<<<<
                    goodsSupplierGetter.GetSupplierInfo(ref goodsSupplierDataWork, goodsMngDic1, goodsMngDic2, goodsMngDic3, goodsMngDic4); //ADD yangyi 2013/05/06 Redmine#35493
                    #endregion

                    #region 単価算出モジュール計算用パラメータ
                    unitPriceCalcParam.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_SECTIONCODERF"));   // 拠点コード
                    unitPriceCalcParam.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_GOODSMAKERCDRF"));  // メーカーコード
                    unitPriceCalcParam.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_GOODSNORF"));           // 商品番号
                    //unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUP_GOODSMGROUPRF"));　 // 商品中分類コード// DEL caohh 2015/03/06 for Redmine#44951
                    unitPriceCalcParam.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODS_GOODSRATEGRPCODERF"));　 // 商品掛率グループコード// ADD caohh 2015/03/06 for Redmine#44951
                    unitPriceCalcParam.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODS_BLGROUPCODERF"));// BLグループコード
                    unitPriceCalcParam.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODS_BLGOODSCODERF"));  // BLコード
                    //unitPriceCalcParam.PriceApplyDate = DateTime.Now;// DEL caohh 2015/03/06 for Redmine#44951
                    unitPriceCalcParam.PriceApplyDate = inventoryExtCndtnWork.InventoryDate;  // ADD caohh 2015/03/06 for Redmine#44951
                    // --- ADD 2009/11/30 ---------->>>>>
                    unitPriceCalcParam.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODS_GOODSRATERANKRF"));  // 層別
                    // --- ADD 2009/11/30 ----------<<<<<
                    //unitPriceCalcParamList.Add(unitPriceCalcParam);  //DEL yangyi 2013/05/06 Redmine#35493
                    // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                    unitPriceCalcParam.SupplierCd = goodsSupplierDataWork.SupplierCd;
                    if (supplierDic != null && supplierDic.ContainsKey(unitPriceCalcParam.SupplierCd))
                    {
                        unitPriceCalcParam.StockUnPrcFrcProcCd = supplierDic[unitPriceCalcParam.SupplierCd].StockUnPrcFrcProcCd;
                    }
                    // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<
                    #endregion

                    #region 商品連結データリスト
                    goodsUnitData.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_ENTERPRISECODERF"));// 企業コード
                    goodsUnitData.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_GOODSNORF"));              // 商品番号
                    goodsUnitData.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_GOODSMAKERCDRF"));     // メーカーコード
                    //goodsUnitDataList.Add(goodsUnitData);  //DEL yangyi 2013/05/06 Redmine#35493
                    #endregion
                    // ADD 2009/04/24 <<<

                    // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                    enterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_ENTERPRISECODERF"));
                    if (enterpriseCode != null && enterpriseCode != "")
                    {
                        priceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GPRICEU_PRICESTARTDATERF"));
                        if (priceStartDate < DateTime.Now)
                        {
                            if (priceStartDate > goodsPriceUWork.PriceStartDate)
                            {
                                goodsPriceUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GPRICEU_CREATEDATETIMERF"));
                                goodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("GPRICEU_UPDATEDATETIMERF"));
                                goodsPriceUWork.EnterpriseCode = enterpriseCode;
                                goodsPriceUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("GPRICEU_FILEHEADERGUIDRF"));
                                goodsPriceUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_UPDEMPLOYEECODERF"));
                                goodsPriceUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_UPDASSEMBLYID1RF"));
                                goodsPriceUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_UPDASSEMBLYID2RF"));
                                goodsPriceUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GPRICEU_LOGICALDELETECODERF"));
                                goodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GPRICEU_GOODSMAKERCDRF"));
                                goodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GPRICEU_GOODSNORF"));
                                goodsPriceUWork.PriceStartDate = priceStartDate;
                                //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                                //goodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_LISTPRICERF"));
                                convertDoubleRelease.EnterpriseCode = goodsPriceUWork.EnterpriseCode;
                                convertDoubleRelease.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd;
                                convertDoubleRelease.GoodsNo = goodsPriceUWork.GoodsNo;
                                convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_LISTPRICERF"));

                                // 変換処理実行
                                convertDoubleRelease.ReleaseProc();

                                goodsPriceUWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                                //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                                goodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_SALESUNITCOSTRF"));
                                goodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("GPRICEU_STOCKRATERF"));
                                goodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GPRICEU_OPENPRICEDIVRF"));
                                goodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GPRICEU_OFFERDATERF"));
                                goodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("GPRICEU_UPDATEDATERF"));
                            }
                        }
                        // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                        // --- DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                        //// 当商品の価格未設定の場合、単品掛率の価格、仕入率をセットする
                        //if ((goodsPriceUWork.SalesUnitCost == 0) && ((goodsPriceUWork.StockRate == 0 || goodsPriceUWork.ListPrice == 0)))
                        //{
                        //    goodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_PRICEFLRF"));
                        //    if (goodsPriceUWork.LogicalDeleteCode == 0)
                        //    {
                        //        goodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_RATEVALRF"));
                        //    }
                        //}
                        // --- DEL 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<

                        #region 単品掛率リスト
                        // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------>>>>>
                        //goodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STK_GOODSMAKERCDRF"));     // メーカーコード
                        //goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STK_GOODSNORF"));           // 商品番号
                        //keyValue = "00" + "-" + goodsMakerCd.ToString("D4") + "-" + goodsNo.Trim();
                        //拠点分単品掛率
                        keyValue = string.Format(ctDicKeyFmt, wkInventoryDataWork.SectionCode.Trim(), wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo.Trim());
                        sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_SECTIONCODERF"));
                        //当商品の拠点分単品がある場合、単品dicに追加
                        if (!string.IsNullOrEmpty(sectionCode) && !rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        {
                            rateAllSec = new RateWork();
                            rateAllSec.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_RATEVALRF"));
                            rateAllSec.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_PRICEFLRF"));
                            rateAllSec.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_UNPRCFRACPROCUNITRF"));
                            rateAllSec.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATE_UNPRCFRACPROCDIVRF"));
                            rateAllSec.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATESETTINGDIVIDERF"));
                            rateAllSec.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATEMNGGOODSCDRF"));
                            rateAllSec.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE_RATEMNGCUSTCDRF"));
                            rateAllSec.SectionCode = sectionCode;
                            rateAllSec.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE_LOTCOUNTRF"));
                            rateWorkByGoodsNoDic.Add(keyValue, rateAllSec);
                        }
                        keyValue = string.Format(ctDicKeyFmt, ctALLSection, wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo.Trim());
                        // --- UPD 譚洪 2021/03/16 PMKOBETSU-3551の対応 ------<<<<<
                        sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_SECTIONCODERF"));
                        //全社単品がある場合、単品dicに追加
                        if (!string.IsNullOrEmpty(sectionCode) && !rateWorkByGoodsNoDic.ContainsKey(keyValue))
                        {
                            rateAllSec = new RateWork();
                            rateAllSec.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_RATEVALRF"));
                            rateAllSec.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_PRICEFLRF"));
                            rateAllSec.UnPrcFracProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_UNPRCFRACPROCUNITRF"));
                            rateAllSec.UnPrcFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATE2_UNPRCFRACPROCDIVRF"));
                            rateAllSec.RateSettingDivide = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATESETTINGDIVIDERF"));
                            rateAllSec.RateMngGoodsCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATEMNGGOODSCDRF"));
                            rateAllSec.RateMngCustCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATE2_RATEMNGCUSTCDRF"));
                            rateAllSec.SectionCode = sectionCode;
                            rateAllSec.LotCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATE2_LOTCOUNTRF"));

                            rateWorkByGoodsNoDic.Add(keyValue, rateAllSec);
                        }
                        #endregion
                        // --- ADD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
                    }
                    #region del
                    // 複数レコード取れる場合は最初のレコードではなく最後のレコードをリストに追加するように変更
                    //if (beInventoryDataWork != null)
                    //{
                    //    if (beInventoryDataWork.EnterpriseCode == wkInventoryDataWork.EnterpriseCode
                    //        && beInventoryDataWork.SectionCode == wkInventoryDataWork.SectionCode
                    //        && beInventoryDataWork.WarehouseCode == wkInventoryDataWork.WarehouseCode
                    //        && beInventoryDataWork.GoodsMakerCd == wkInventoryDataWork.GoodsMakerCd
                    //        && beInventoryDataWork.GoodsNo == wkInventoryDataWork.GoodsNo
                    //        && beInventoryDataWork.BLGroupCode == wkInventoryDataWork.BLGroupCode
                    //        && beInventoryDataWork.SupplierCd == wkInventoryDataWork.SupplierCd)
                    //    {
                    //        continue;
                    //    }
                    //}
                    #endregion

                    if (beInventoryDataWork != null)
                    {
                        if (beInventoryDataWork.EnterpriseCode == wkInventoryDataWork.EnterpriseCode
                            && beInventoryDataWork.SectionCode == wkInventoryDataWork.SectionCode
                            && beInventoryDataWork.WarehouseCode == wkInventoryDataWork.WarehouseCode
                            && beInventoryDataWork.GoodsMakerCd == wkInventoryDataWork.GoodsMakerCd
                            && beInventoryDataWork.GoodsNo == wkInventoryDataWork.GoodsNo
                            && beInventoryDataWork.BLGroupCode == wkInventoryDataWork.BLGroupCode
                            && beInventoryDataWork.SupplierCd == wkInventoryDataWork.SupplierCd)
                        {
                            if (goodsPriceUWork.EnterpriseCode != "" )
                            {
                                if (beGoodsPriceUWork  == null || goodsPriceUWork.PriceStartDate > beGoodsPriceUWork.PriceStartDate) // ADD 2012/09/03 yangyi
                                {
                                    beGoodsPriceUWork = goodsPriceUWork;
                                }

                            }

                            // 1レコード前と同じだった場合
                            continue; // 次へ 
                        }
                    }
                    else
                    {
                        // BeforeData
                        beInventoryDataWork = wkInventoryDataWork;
                        beGoodsSupplierDataWork = goodsSupplierDataWork;
                        beUnitPriceCalcParamWork = unitPriceCalcParam;
                        beGoodsUnitDataWork = goodsUnitData;
                        beGoodsPriceUWork = goodsPriceUWork;
                        continue;
                    }

                    // 1レコード前と変わった場合、BeforeDataをリストに追加
                    al.Add(beInventoryDataWork);
                    GoodsSupplierDataWorkList.Add(beGoodsSupplierDataWork);
                    unitPriceCalcParamList.Add(beUnitPriceCalcParamWork);
                    goodsUnitDataList.Add(beGoodsUnitDataWork);

                    // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                    //unitPriceCalculation.CalculateUnitCostPrice(ref unitPriceCalcRetList, beGoodsPriceUWork, taxFractionProcUnit, taxFractionProcCd
                    //    , beUnitPriceCalcParamWork, stockProcMoneyList, rateProtyMngAllList, beGoodsUnitDataWork, rateList);
                    unitPriceCalculation.CalculateUnitCostPrice2(ref unitPriceCalcRetList, beGoodsPriceUWork, taxFractionProcUnit, taxFractionProcCd
                        , beUnitPriceCalcParamWork, stockProcMoneyList, rateProtyMngAllList, beGoodsUnitDataWork, rateList, rateWorkByGoodsNoDic);
                    // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<

                    // 現在のレコードをBeforeDataにセット
                    beInventoryDataWork = wkInventoryDataWork;
                    beGoodsSupplierDataWork = goodsSupplierDataWork;
                    beUnitPriceCalcParamWork = unitPriceCalcParam;
                    beGoodsUnitDataWork = goodsUnitData;
                    if (goodsPriceUWork.EnterpriseCode != "")
                    {
                        beGoodsPriceUWork = goodsPriceUWork;
                    }
                    else
                    {
                        beGoodsPriceUWork = null;
                    }
                    // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                }
                if (!myReader.IsClosed) myReader.Close();
                #endregion    // 自社在庫取得クエリ

                // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                // 最後のBeforeDataをリストに追加する
                if (beInventoryDataWork != null)
                {
                    al.Add(beInventoryDataWork);
                    GoodsSupplierDataWorkList.Add(beGoodsSupplierDataWork);
                    unitPriceCalcParamList.Add(beUnitPriceCalcParamWork);
                    goodsUnitDataList.Add(beGoodsUnitDataWork);
                    // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------>>>>>
                    //unitPriceCalculation.CalculateUnitCostPrice(ref unitPriceCalcRetList, beGoodsPriceUWork, taxFractionProcUnit, taxFractionProcCd
                    //    , beUnitPriceCalcParamWork, stockProcMoneyList, rateProtyMngAllList, beGoodsUnitDataWork, rateList);
                    unitPriceCalculation.CalculateUnitCostPrice2(ref unitPriceCalcRetList, beGoodsPriceUWork, taxFractionProcUnit, taxFractionProcCd
                        , beUnitPriceCalcParamWork, stockProcMoneyList, rateProtyMngAllList, beGoodsUnitDataWork, rateList, rateWorkByGoodsNoDic);
                    // --- UPD 譚洪 2020/07/23 PMKOBETSU-3551の対応 ------<<<<<
                }

                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<
                #endregion    // 自社在庫取得クエリ

                // ADD 2009/04/27 >>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 商品仕入先情報取得処理 実行
                    goodsSupplierGetter.GetGoodsMngInfo(ref GoodsSupplierDataWorkList);

                    #region 商品仕入先情報取得処理 結果セット
                    //商品仕入先情報取得処理により取得した仕入先を
                    //単価算出パラメータ・棚卸データワークにセット
                    for (int i = 0; i < GoodsSupplierDataWorkList.Count; i++) // 商品仕入取得データクラス
                    {
                        //-- UPD 2012/05/21 ------------------------------------------------------------------>>>>
                        #region DEL 無駄ループを削除、配列番号で紐付けるようにする。
                        //for (int j = 0; j < unitPriceCalcParamList.Count; j++) // 単価算出モジュール計算用パラメータ
                        //{
                        //    if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[j].GoodsMakerCd) && // 商品メーカー
                        //        (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[j].GoodsNo) &&           // 商品番号
                        //        (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[j].BLGoodsCode))     // BL商品コード
                        //    {
                        //        if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                        //        {
                        //            // -- UPD 2012/04/09 ----------------------------------->>>>
                        //            //unitPriceCalcParamList[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // 仕入先セット

                        //            //商品管理情報が00全社で、単価モジュールに仕入先がセットされてないなら、セットする
                        //            if (GoodsSupplierDataWorkList[i].SectionCode.Trim() == "00")
                        //            {
                        //                if (unitPriceCalcParamList[j].SupplierCd == 0)
                        //                {
                        //                    unitPriceCalcParamList[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // 仕入先セット
                        //                }
                        //            }
                        //            //商品管理情報が全社以外、単価モジュールの拠点コードが同一なら、仕入先をセットする。
                        //            else if (GoodsSupplierDataWorkList[i].SectionCode == unitPriceCalcParamList[j].SectionCode)
                        //            {
                        //                unitPriceCalcParamList[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // 仕入先セット
                        //            }
                        //            // -- UPD 2012/04/09 -----------------------------------<<<<
                        //        }
                        //    }
                        //}

                        //for (int j = 0; j < al.Count; j++) // 棚卸データワーク
                        //{
                        //    if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == al[j].GoodsMakerCd) && // 商品メーカー
                        //        (GoodsSupplierDataWorkList[i].GoodsNo == al[j].GoodsNo) &&           // 商品番号
                        //        (GoodsSupplierDataWorkList[i].BLGoodsCode == al[j].BLGoodsCode))     // BL商品コード
                        //    {
                        //        if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                        //        {
                        //            // -- UPD 2012/04/09 ----------------------------------->>>>
                        //            //al[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // 仕入先セット

                        //            //商品管理情報が00全社で、棚卸データに仕入先がセットされてないなら、セットする。
                        //            if (GoodsSupplierDataWorkList[i].SectionCode.Trim() == "00")
                        //            {
                        //                if (al[j].SupplierCd == 0)
                        //                {
                        //                    al[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // 仕入先セット
                        //                }
                        //            }
                        //            //商品管理情報が全社以外、棚卸データの拠点コードが同一なら、仕入先をセットする。
                        //            else if (GoodsSupplierDataWorkList[i].SectionCode == al[j].SectionCode)
                        //            {
                        //                al[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // 仕入先セット
                        //            }
                        //            // -- UPD 2012/04/09 -----------------------------------<<<<
                        //        }
                        //    }
                        //}
                        #endregion
                        if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[i].GoodsMakerCd) && // 商品メーカー
                            (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[i].GoodsNo) &&           // 商品番号
                            (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[i].BLGoodsCode) &&   // BL商品コード
                            (GoodsSupplierDataWorkList[i].GoodsMakerCd == al[i].GoodsMakerCd) && // 商品メーカー
                            (GoodsSupplierDataWorkList[i].GoodsNo == al[i].GoodsNo) &&           // 商品番号
                            (GoodsSupplierDataWorkList[i].BLGoodsCode == al[i].BLGoodsCode))     // BL商品コード
                        {
                            if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                            {
                                unitPriceCalcParamList[i].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd;

                                // ADD 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理 ----->>>>>
                                if (supplierDic != null && supplierDic.ContainsKey(unitPriceCalcParamList[i].SupplierCd))
                                {
                                    unitPriceCalcParamList[i].StockUnPrcFrcProcCd = supplierDic[unitPriceCalcParamList[i].SupplierCd].StockUnPrcFrcProcCd;
                                }
                                // ADD 2013/03/06 zhoug For Redmine#34756対応：棚卸準備処理 -----<<<<<
                                al[i].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd;
                            }
                        }
                        else
                        {
                            throw new Exception("商品管理情報と棚卸データの紐付きが不正です。（在庫マスタ検索処理）" +
                                                i.ToString() + " : " +
                                                GoodsSupplierDataWorkList[i].GoodsMakerCd.ToString() + ", " +
                                                GoodsSupplierDataWorkList[i].GoodsNo.ToString() + " : " +
                                                unitPriceCalcParamList[i].GoodsMakerCd.ToString() + ", " +
                                                unitPriceCalcParamList[i].GoodsNo.ToString() + " : " +
                                                al[i].GoodsMakerCd.ToString() + ", " +
                                                al[i].GoodsNo.ToString());
                        }
                        // -- UPD 2012/05/21 ------------------------------------------------------------------<<<<
                    }
                    #endregion

                    //原価算出処理 実行
                    //unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);//DEL 2012/07/10 for Redmine#31103

                    // --- DEL yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                    // リストを回しながらGoodsPriceUを取得する部分を削除
                    //unitPriceCalculation.CalculateUnitCostForInventory(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);//ADD 2012/07/10 for Redmine#31103
                    // --- DEL yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

                    #region 原価算出処理 結果セット
                    // 原価算出処理により取得した原価を
                    // 在庫履歴データクラスにセット
                    for (int i = 0; i < unitPriceCalcRetList.Count; i++) // 単価計算結果
                    {
                        // -- UPD 2012/04/09 ------------------------------------------------>>>>
                        #region DEL 無駄ループ削除、配列番号で紐付けるよう変更する
                        //for (int j = 0; j < al.Count; j++) // 棚卸データクラス
                        //{
                        //    if ((unitPriceCalcRetList[i].GoodsMakerCd == al[j].GoodsMakerCd) && // 商品メーカー
                        //        (unitPriceCalcRetList[i].GoodsNo == al[j].GoodsNo))     // BL商品コード
                        //    {
                        //        if (al[j].StockUnitPriceFl == 0)
                        //        {
                        //            // 仕入単価
                        //            al[j].StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                        //            // 変更前仕入単価
                        //            al[j].BfStockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;

                        //        }
                        //        // ADD 2009/05/11 >>>
                        //        // --- UPD 2009/11/30 ---------->>>>>
                        //        // 調製用計算原価
                        //        //al[j].AdjstCalcCost = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                        //        double adjstCalcCost = 0;
                        //        FractionCalculate.FracCalcMoney(unitPriceCalcRetList[i].UnitPriceTaxExcFl, 0.01, 1, out adjstCalcCost);
                        //        al[j].AdjstCalcCost = adjstCalcCost;
                        //        // --- UPD 2009/11/30 ----------<<<<<
                        //        // ADD 2009/05/11 <<<
                        //    }
                        //}
                        #endregion
                        if ((unitPriceCalcRetList[i].GoodsMakerCd == al[i].GoodsMakerCd) && // 商品メーカー
                            (unitPriceCalcRetList[i].GoodsNo == al[i].GoodsNo))     // BL商品コード
                        {
                            if (al[i].StockUnitPriceFl == 0)
                            {
                                // 仕入単価
                                al[i].StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                                // 変更前仕入単価
                                al[i].BfStockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;

                            }
                            // 調製用計算原価
                            double adjstCalcCost = 0;
                            FractionCalculate.FracCalcMoney(unitPriceCalcRetList[i].UnitPriceTaxExcFl, 0.01, 1, out adjstCalcCost);
                            al[i].AdjstCalcCost = adjstCalcCost;
                        }
                        else
                        {
                            throw new Exception("原価算出結果と棚卸データの紐付きが不正です。（在庫マスタ検索処理）" +
                                                i.ToString() + " : " +
                                                unitPriceCalcRetList[i].GoodsMakerCd.ToString() + ", " +
                                                unitPriceCalcRetList[i].GoodsNo.ToString() + " : " +
                                                al[i].GoodsMakerCd.ToString() + ", " +
                                                al[i].GoodsNo.ToString());
                        }
                        // -- UPD 2012/04/09 ------------------------------------------------<<<<
                    }
                    #endregion

                    #region 仕入先コード抽出条件
                    for (int i = 0; i < al.Count; i++) // 棚卸データワーク
                    {
                        if ((inventoryExtCndtnWork.StCustomerCd <= al[i].SupplierCd) &&
                            (inventoryExtCndtnWork.EdCustomerCd >= al[i].SupplierCd))
                        {
                            wkList.Add(al[i]);
                        }
                    }
                    #endregion
                    al = wkList;

                }
                // ADD 2009/04/27 <<< 
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SeachProductStock Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (sqlCommand2 != null) sqlCommand2.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                if (myReader2 != null && !myReader2.IsClosed) myReader2.Close();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            }

            return status;
        }
        #endregion  // 在庫マスタ検索処理

        //----DEL 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
        /*
        // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
        /// <summary>
        /// 掛率優先管理検索
        /// </summary>
        private List<RateProtyMngWork> SearchRateProtyMng(string _enterpriseCode)
        {
            List<RateProtyMngWork> _rateProtyMngAllList = new List<RateProtyMngWork>();

            RateProtyMngDB rateProtyMngDB = new RateProtyMngDB();

            ArrayList paralist = new ArrayList();
            RateProtyMngWork paraWork = new RateProtyMngWork();
            paraWork.EnterpriseCode = _enterpriseCode;

            paralist.Add(paraWork);

            object rateProtyMngWorkList = null;

            //掛率優先管理の読み込み
            rateProtyMngDB.Search(out rateProtyMngWorkList, paralist, 0, 0);

            if (rateProtyMngWorkList != null)
            {
                ArrayList list = rateProtyMngWorkList as ArrayList;

                _rateProtyMngAllList = new List<RateProtyMngWork>();
                _rateProtyMngAllList.AddRange((RateProtyMngWork[])list.ToArray(typeof(RateProtyMngWork)));

                // 拠点、単価種類、優先順位でソート
                _rateProtyMngAllList.Sort(new FractionProcMoney.RateProtyMngComparer());
            }
            return _rateProtyMngAllList;
        }
        */
        //----DEL 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<

        #region SearchStockProcMoney
        //----DEL 2013/06/07 wangl2 for Redmine#35788 ------->>>>>>
        /*
        /// <summary>
        /// 仕入金額端数処理区分設定検索
        /// </summary>
        private List<StockProcMoneyWork> SearchStockProcMoney(string _enterpriseCode)
        {
            List<StockProcMoneyWork> _stockProcMoneyList = new List<StockProcMoneyWork>();

            StockProcMoneyDB stockProcMoneyDB = new StockProcMoneyDB();

            StockProcMoneyWork paraWork = new StockProcMoneyWork();
            paraWork.EnterpriseCode = _enterpriseCode;
            paraWork.FracProcMoneyDiv = -1;
            paraWork.FractionProcCode = -1;

            ArrayList paraList = new ArrayList();
            paraList.Add(paraWork);

            object retobj = null;

            int status = stockProcMoneyDB.Search(out retobj, paraList, 0, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList list = retobj as ArrayList;

                _stockProcMoneyList.AddRange((StockProcMoneyWork[])list.ToArray(typeof(StockProcMoneyWork)));

                _stockProcMoneyList.Sort(new FractionProcMoney.StockProcMoneyComparer());
            }

            return _stockProcMoneyList;
        }
        */ 
        //----DEL 2013/06/07 wangl2 for Redmine#35788 -------<<<<<<
        #endregion

        #region GetStockFractionProcInfo

        /// <summary>
        /// 仕入金額処理区分設定マスタより、対象金額に該当する端数処理単位、端数処理コードを取得します。
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="price">対象金額</param>
        /// <param name="_stockProcMoneyList">仕入金額処理区分設定マスタ</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        private void GetStockFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double price, List<StockProcMoneyWork> _stockProcMoneyList, out double fractionProcUnit, out int fractionProcCd)
        {
            fractionProcUnit = FractionProcMoney.GetDefaultFractionProcUnit(fracProcMoneyDiv);
            fractionProcCd = FractionProcMoney.GetDefaultFractionProcCd(fracProcMoneyDiv);

            if (_stockProcMoneyList == null || _stockProcMoneyList.Count == 0) return;

            List<StockProcMoneyWork> stockProcMoneyList = _stockProcMoneyList.FindAll(
                                        delegate(StockProcMoneyWork stockProcMoney)
                                        {
                                            if ((stockProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                                                (stockProcMoney.FractionProcCode == fractionProcCode) &&
                                                (stockProcMoney.UpperLimitPrice >= price))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (stockProcMoneyList != null && stockProcMoneyList.Count > 0)
            {
                fractionProcUnit = stockProcMoneyList[0].FractionProcUnit;
                fractionProcCd = stockProcMoneyList[0].FractionProcCd;
            }
        }

        #endregion

        #region UnitPrcCalcDiv

        /// <summary>
        /// 単価算出方法
        /// </summary>
        public enum UnitPrcCalcDiv
        {
            /// <summary>単価直接指定</summary>
            Price = 0,
            /// <summary>掛率</summary>
            RateVal = 1,
            /// <summary>UP率</summary>
            UpRate = 2,
            /// <summary>粗利率</summary>
            GrsProfitSecureRate = 3,
        }

        #endregion

        ///// <summary>
        ///// 掛率優先管理情報のリストを取得します。
        ///// <br>UpdateNote : Redmine#31103棚卸準備処理の速度改良の対応</br>
        ///// <br>Programer  : 凌小青</br>
        ///// <br>Date       : 2012/07/10</br>
        ///// </summary>
        ///// <returns></returns>
        ////private List<RateProtyMngWork> GetRateProtyMngList(string _enterpriseCode, string sectionCode, UnitPriceKind unitPriceKind)//DEL on 2012/07/10 for Redmine#31103
        //private List<RateProtyMngWork> GetRateProtyMngList(List<RateProtyMngWork> _rateProtyMngAllList, string _enterpriseCode, string sectionCode, UnitPriceKind unitPriceKind)//ADD  on 2012/07/10 for Redmine#31103
        //{
        //    //----DEL on 2012/07/10 for Redmine#31103 ------->>>>>>
        //    ////優先管理読み込み
        //    //List<RateProtyMngWork> _rateProtyMngAllList =  SearchRateProtyMng(_enterpriseCode);
        //    //----DEL on 2012/07/10 for Redmine#31103 -------<<<<<<

        //    if (_rateProtyMngAllList == null || _rateProtyMngAllList.Count == 0) return null;

        //    // 対象拠点分の優先管理を取得
        //    List<RateProtyMngWork> _lastRateProtyMngList = _rateProtyMngAllList.FindAll(
        //                                                            delegate(RateProtyMngWork rateProtyMng)
        //                                                            {
        //                                                                if ((rateProtyMng.SectionCode.Trim() == sectionCode.Trim()) &&
        //                                                                    (rateProtyMng.UnitPriceKind == (int)unitPriceKind))
        //                                                                {
        //                                                                    return true;
        //                                                                }
        //                                                                else
        //                                                                {
        //                                                                    return false;
        //                                                                }
        //                                                            });
        //    if (sectionCode.Trim() != "00")
        //    {
        //        // 全社設定分を追加
        //        _lastRateProtyMngList.AddRange(_rateProtyMngAllList.FindAll(
        //            delegate(RateProtyMngWork rateProtyMng)
        //            {
        //                if ((rateProtyMng.SectionCode.Trim() == "00") &&
        //                    (rateProtyMng.UnitPriceKind == (int)unitPriceKind))
        //                {
        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }));
        //    }

        //    return _lastRateProtyMngList;

        //}
        // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

        #region 在庫数算出処理
        /// <summary>
        /// 在庫数算出処理
        /// 在庫履歴データ、在庫受払履歴データから棚卸日のマシン在庫数を算出する。
        /// 
        /// </summary>
        /// <param name="al"></param>
        /// <param name="inventoryExtCndtnWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTrans"></param>
        /// <param name="readMode"></param>
        /// <param name="logicalMode"></param>
        /// <returns></returns>
        private int CalcStockTotal(ref List<InventoryDataWork> al, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // -----------UPD 2010/02/20------------>>>>>
            //int lastAddUpYearMonth = 0;
            //int lastAddUpDate = 0;
            DateTime lastAddUpDate = DateTime.MinValue;
            double stockUnitPriceFl = 0.0;
            double stockTotal = 0.0;
            double arrivalCnt = 0.0;
            double shipmentCnt = 0.0;
            InventoryDataWork ivtDataWork = null;

            //for (int i = 0; i < al.Count; i++)
            //{
            //    ivtDataWork = al[i];
            //    GetStockHistoryData(ivtDataWork, ref lastAddUpYearMonth, ref lastAddUpDate, ref stockUnitPriceFl, ref stockTotal, ref sqlConnection, ref sqlTrans);
            //    //GetLastAddUpDate(inventoryExtCndtnWork, lastAddUpYearMonth, ref lastAddUpDate, ref sqlConnection, ref sqlTrans);// DEL 2009/04/27
            //    GetStockAcPayHistData(ivtDataWork, lastAddUpDate, inventoryExtCndtnWork.InventoryDate, ref arrivalCnt, ref shipmentCnt, ref sqlConnection, ref sqlTrans);
            //    // --- UPD 2009/11/30 ---------->>>>>
            //    //al[i].StockTotal = stockTotal + arrivalCnt - shipmentCnt;
            //    if (inventoryExtCndtnWork.InventoryMngDiv == 0)
            //    {
            //        al[i].StockTotal = stockTotal + arrivalCnt - shipmentCnt;
            //    }
            //    else if (inventoryExtCndtnWork.InventoryMngDiv == 1)
            //    {
            //        //棚卸データ.在庫総数へ「在庫マスタ.仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－ 移動中仕入在庫数」をセット
            //        al[i].StockTotal = al[i].StockTotal + al[i].ArrivalCnt - al[i].ShipmentCnt - al[i].MovingSupliStock;
            //    }
            //    // --- UPD 2009/11/30 ----------<<<<<

            //    al[i].InventoryDate = inventoryExtCndtnWork.InventoryDate;
            //    // マシン在庫額
            //    al[i].StockMashinePrice = Convert.ToInt64(al[i].StockUnitPriceFl * al[i].StockTotal);

            //}

            // 在庫履歴データ
            Dictionary<string, StockHistoryWork> stockHistWorkDic = new Dictionary<string, StockHistoryWork>();
            // 在庫受払履歴データ
            List<StockAcPayHistWork> stockAcpayHistWorkList = new List<StockAcPayHistWork>();

            if (al.Count > 0)
            {
                ivtDataWork = al[0];
                if (inventoryExtCndtnWork.InventoryMngDiv == 0)//ADD 2012/07/10 for Redmine#31103
                {//ADD 2012/07/10
                    // 在庫履歴データ全件検索
                    status = GetStockHistoryDataAll(ref stockHistWorkDic, ivtDataWork, ref sqlConnection, ref sqlTrans);

                    // 在庫受払履歴データ全件検索
                    status = GetStockAcPayHistDataAll(ref stockAcpayHistWorkList, ivtDataWork, ref sqlConnection, ref sqlTrans);
                }//ADD 2012/07/10
                for (int i = 0; i < al.Count; i++)
                {
                    ivtDataWork = al[i];
                    //-----2011/01/11----->>>>>
                    //-----UPD 2011/01/28----->>>>>
                    //if ("ｶｼﾀﾞｼ".Equals(ivtDataWork.WarehouseShelfNo) || ("ｻｷﾀﾞｼ".Equals(ivtDataWork.WarehouseShelfNo)))
                    if (("ｶｼﾀﾞｼ".Equals(ivtDataWork.WarehouseShelfNo) && ((ivtDataWork.GoodsNo.Contains(".") || ivtDataWork.GoodsNo.Contains("*"))))
                        || ("ｻｷﾀﾞｼ".Equals(ivtDataWork.WarehouseShelfNo) && ((ivtDataWork.GoodsNo.Contains(".") || ivtDataWork.GoodsNo.Contains("*")))))
                    //-----UPD 2011/01/28-----<<<<<
                    {
                        continue;
                    }
                    //-----2011/01/11-----<<<<<
                    if (inventoryExtCndtnWork.InventoryMngDiv == 0)//ADD 2012/07/10 for Redmine#31103
                    {//ADD 2012/07/10
                        GetStockHistoryData2(stockHistWorkDic, ivtDataWork, ref lastAddUpDate, ref stockUnitPriceFl, ref stockTotal);
                        GetStockAcPayHistData2(stockAcpayHistWorkList, ivtDataWork, lastAddUpDate, inventoryExtCndtnWork.InventoryDate, ref arrivalCnt, ref shipmentCnt);
                    }//ADD 2012/07/10
                    if (inventoryExtCndtnWork.InventoryMngDiv == 0)
                    {
                        al[i].StockTotal = stockTotal + arrivalCnt - shipmentCnt;
                    }
                    else if (inventoryExtCndtnWork.InventoryMngDiv == 1)
                    {
                        //棚卸データ.在庫総数へ「在庫マスタ.仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－ 移動中仕入在庫数」をセット
                        al[i].StockTotal = al[i].StockTotal + al[i].ArrivalCnt - al[i].ShipmentCnt - al[i].MovingSupliStock;
                    }


                    al[i].InventoryDate = inventoryExtCndtnWork.InventoryDate;
                    // マシン在庫額
                    al[i].StockMashinePrice = Convert.ToInt64(al[i].StockUnitPriceFl * al[i].StockTotal);
                }
            }
            // --- UPD 2010/02/20 ----------<<<<<


            return status;
        }
        #endregion  // 在庫数算出処理

        #region 前回月次更新日取得
        private int GetLastAddUpDate(InventoryExtCndtnWork inventoryExtCndtnWork, int lastAddUpYearMonth, ref int lastAddUpDate,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            int monthAddUpYearMonth = 0;

            lastAddUpDate = 0;

            try
            {
                string sText = "";

                //sText += "SELECT DISTINCT MONTHLYADDUPDATERF, MONTHADDUPYEARMONTHRF FROM MONTHLYADDUPHISRF "; // DEL wangf 2012/03/23 FOR Redmine#29109
                sText += "SELECT DISTINCT MONTHLYADDUPDATERF, MONTHADDUPYEARMONTHRF FROM MONTHLYADDUPHISRF WITH (READUNCOMMITTED) "; // ADD wangf 2012/03/23 FOR Redmine#29109
                sText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE ";
                sText += "AND LOGICALDELETECODERF=0 ";
                sText += "AND PROCDIVCDRF=0 ";
                sText += "AND HISTCTLCDRF=0 ";
                sText += "AND MONTHADDUPYEARMONTHRF = @MONTHADDUPYEARMONTH ";// 追加2009/04/27
                sText += "ORDER BY MONTHADDUPYEARMONTHRF DESC ";

                sqlCommand = new SqlCommand(sText, sqlConnection, sqlTrans);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);

                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    monthAddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONTHADDUPYEARMONTHRF"));
                    if (monthAddUpYearMonth == lastAddUpYearMonth)
                    {
                        lastAddUpDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONTHLYADDUPDATERF"));
                        break;
                    }
                }

                if (!myReader.IsClosed) myReader.Close();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.GetLastAddUpDate Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;

        }
        #endregion // 前回月次更新日取得

        #region 在庫履歴データ検索
        /// <summary>
        /// 在庫履歴データ検索
        /// </summary>
        /// <param name="ivtDataWork"></param>
        /// <param name="addUpYearMonth"></param>
        /// <param name="stockTotal"></param>
        /// <returns></returns>
        private int GetStockHistoryData(InventoryDataWork ivtDataWork,
            ref int lastAddUpYearMonth, ref int lastAddUpDate, ref double stockUnitPriceFl, ref double stockTotal,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                string sText = "";
                // 修正 2009/04/27 >>>
                //sText += "SELECT TOP 1 ADDUPYEARMONTHRF, STOCKUNITPRICEFLRF, STOCKTOTALRF FROM STOCKHISTORYRF ";
                //sText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE ";
                //sText += "AND LOGICALDELETECODERF=0 ";
                //sText += "AND WAREHOUSECODERF=@WAREHOUSECODE ";
                //sText += "AND SECTIONCODERF=@SECTIONCODE ";
                //sText += "AND GOODSNORF=@GOODSNO ";
                //sText += "AND GOODSMAKERCDRF=@GOODSMAKERCD ";
                //sText += "ORDER BY ADDUPYEARMONTHRF DESC ";               
                sText += "SELECT TOP 1  " + Environment.NewLine;
                sText += " STOCKHIS.ADDUPYEARMONTHRF" + Environment.NewLine;
                sText += " ,STOCKHIS.STOCKUNITPRICEFLRF" + Environment.NewLine;
                sText += " ,STOCKHIS.STOCKTOTALRF " + Environment.NewLine;
                sText += " ,ADDUPHIS.MONTHLYADDUPDATERF" + Environment.NewLine;
                //sText += "FROM STOCKHISTORYRF AS STOCKHIS" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sText += "FROM STOCKHISTORYRF AS STOCKHIS WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                //sText += "LEFT JOIN MONTHLYADDUPHISRF AS ADDUPHIS" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sText += "LEFT JOIN MONTHLYADDUPHISRF AS ADDUPHIS WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sText += " ON STOCKHIS.ENTERPRISECODERF = ADDUPHIS.ENTERPRISECODERF" + Environment.NewLine;
                sText += " AND STOCKHIS.ADDUPYEARMONTHRF = ADDUPHIS.MONTHADDUPYEARMONTHRF" + Environment.NewLine;
                sText += " AND ADDUPHIS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sText += " AND ADDUPHIS.PROCDIVCDRF=0" + Environment.NewLine;
                sText += " AND ADDUPHIS.HISTCTLCDRF=0" + Environment.NewLine;
                sText += "WHERE STOCKHIS.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sText += " AND STOCKHIS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sText += " AND STOCKHIS.WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                //sText += " AND STOCKHIS.SECTIONCODERF=@SECTIONCODE" + Environment.NewLine; // DEL 2009/05/11 
                sText += " AND STOCKHIS.GOODSNORF=@GOODSNO" + Environment.NewLine;
                sText += " AND STOCKHIS.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                sText += "ORDER BY ADDUPYEARMONTHRF DESC" + Environment.NewLine;

                /// 修正 2009/04/27 <<<

                sqlCommand = new SqlCommand(sText, sqlConnection, sqlTrans);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                //SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar); // DEL 2009/05/11
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);

                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.EnterpriseCode);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.WarehouseCode);
                //paraSectionCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.SectionCode); // DEL 2009/05/11
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(ivtDataWork.GoodsNo);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(ivtDataWork.GoodsMakerCd);

                lastAddUpYearMonth = 0;
                stockUnitPriceFl = 0.0;
                stockTotal = 0.0;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    lastAddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")); // 計上年月
                    lastAddUpDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONTHLYADDUPDATERF"));    // 計上年月日  // ADD 2009/04/27
                    stockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));// 仕入単価（税抜，浮動）
                    stockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALRF"));            // 在庫総数
                }

                if (!myReader.IsClosed) myReader.Close();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.GetStockHistoryData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion  // 在庫履歴データ検索

        #region 在庫履歴データ全件検索
        /// <summary>
        /// 在庫履歴データ全件検索
        /// </summary>
        /// <param name="stockHisDic">在庫履歴データ</param>
        /// <param name="ivtDataWork">棚卸データWork</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 在庫履歴データ全件検索を行いします。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/02/20</br>
        /// </remarks>
        private int GetStockHistoryDataAll(ref Dictionary<string, StockHistoryWork> stockHisDic, InventoryDataWork ivtDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                string sText = "";
                sText += "SELECT" + Environment.NewLine;
                sText += " STOCKHIS.ADDUPYEARMONTHRF" + Environment.NewLine;
                sText += " ,STOCKHIS.STOCKUNITPRICEFLRF" + Environment.NewLine;
                sText += " ,STOCKHIS.STOCKTOTALRF " + Environment.NewLine;
                sText += " ,STOCKHIS.WAREHOUSECODERF " + Environment.NewLine;
                sText += " ,STOCKHIS.GOODSNORF " + Environment.NewLine;
                sText += " ,STOCKHIS.GOODSMAKERCDRF " + Environment.NewLine;
                sText += " ,ADDUPHIS.MONTHLYADDUPDATERF" + Environment.NewLine;
                //sText += "FROM STOCKHISTORYRF AS STOCKHIS" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sText += "FROM STOCKHISTORYRF AS STOCKHIS WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                //sText += "LEFT JOIN MONTHLYADDUPHISRF AS ADDUPHIS" + Environment.NewLine; // DEL wangf 2012/03/23 FOR Redmine#29109
                sText += "LEFT JOIN MONTHLYADDUPHISRF AS ADDUPHIS WITH (READUNCOMMITTED)" + Environment.NewLine; // ADD wangf 2012/03/23 FOR Redmine#29109
                sText += " ON STOCKHIS.ENTERPRISECODERF = ADDUPHIS.ENTERPRISECODERF" + Environment.NewLine;
                sText += " AND STOCKHIS.ADDUPYEARMONTHRF = ADDUPHIS.MONTHADDUPYEARMONTHRF" + Environment.NewLine;
                sText += " AND ADDUPHIS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sText += " AND ADDUPHIS.PROCDIVCDRF=0" + Environment.NewLine;
                sText += " AND ADDUPHIS.HISTCTLCDRF=0" + Environment.NewLine;
                sText += "WHERE STOCKHIS.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                sText += " AND STOCKHIS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sText += "ORDER BY ADDUPYEARMONTHRF DESC" + Environment.NewLine;

                sqlCommand = new SqlCommand(sText, sqlConnection, sqlTrans);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockHistoryWork work = new StockHistoryWork();

                    #region クラスへ格納
                    work.AddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                    work.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MONTHLYADDUPDATERF"));
                    work.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    work.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    work.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    work.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    work.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTALRF"));

                    string key = work.WarehouseCode + "-" + work.GoodsNo + "-" + work.GoodsMakerCd;
                    if (!stockHisDic.ContainsKey(key))
                    {
                        stockHisDic.Add(key, work);
                    }

                    #endregion
                }

                if (!myReader.IsClosed) myReader.Close();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.GetStockHistoryData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// 在庫履歴データ検索
        /// </summary>
        /// <param name="dic">在庫受払履歴データDic</param>
        /// <param name="ivtDataWork">棚卸データWork</param>
        /// <param name="lastAddUpDate">計上年月</param>
        /// <param name="stockUnitPriceFl">仕入単価</param>
        /// <param name="stockTotal">在庫総数</param>
        /// <remarks>
        /// <br>Note		: 在庫履歴データ検索を行いします。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/02/20</br>
        /// </remarks>
        private void GetStockHistoryData2(Dictionary<string, StockHistoryWork> dic, InventoryDataWork ivtDataWork,
            ref DateTime lastAddUpDate, ref double stockUnitPriceFl, ref double stockTotal)
        {
            string tempKey = ivtDataWork.WarehouseCode + "-" + ivtDataWork.GoodsNo + "-" + ivtDataWork.GoodsMakerCd.ToString();
            lastAddUpDate = DateTime.MinValue;
            stockUnitPriceFl = 0.0;
            stockTotal = 0;
            if (dic.ContainsKey(tempKey))
            {
                StockHistoryWork work = (StockHistoryWork)dic[tempKey];
                lastAddUpDate = work.AddUpADate;
                stockUnitPriceFl = work.StockUnitPriceFl;
                stockTotal = work.StockTotal;
            }
        }
        #endregion  // 在庫履歴データ全件検索

        #region 在庫受払履歴データ検索
        private int GetStockAcPayHistData(InventoryDataWork ivtDataWork, int lastAddUpDate, DateTime inventoryDate,
            ref double arrivalCnt, ref double shipmentCnt,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            string sText = "";

            sText += "SELECT SUM(ARRIVALCNTRF) AS S_ARRIVALCNTRF, ";
            sText += "SUM(SHIPMENTCNTRF) AS S_SHIPMENTCNTRF ";
            //sText += "FROM STOCKACPAYHISTRF "; // DEL wangf 2012/03/23 FOR Redmine#29109
            sText += "FROM STOCKACPAYHISTRF WITH (READUNCOMMITTED) "; // ADD wangf 2012/03/23 FOR Redmine#29109
            sText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE ";
            sText += "AND LOGICALDELETECODERF=0 ";
            // 修正 2009/07/06 >>>
            //sText += "AND IOGOODSDAYRF>@LASTADDUPDATE ";
            //sText += "AND IOGOODSDAYRF<=@INVENTORYDATE ";
            sText += "AND   (  (CASE WHEN ADDUPADATERF IS NULL THEN IOGOODSDAYRF ELSE ADDUPADATERF END)>@LASTADDUPDATE ";
            sText += "      AND (CASE WHEN ADDUPADATERF IS NULL THEN IOGOODSDAYRF ELSE ADDUPADATERF END)<=@INVENTORYDATE )";
            // 修正 2009/07/06 <<<
            sText += "AND WAREHOUSECODERF=@WAREHOUSECODE ";
            //sText += "AND SECTIONCODERF=@SECTIONCODE "; // DEL 2009/05/11
            sText += "AND GOODSNORF=@GOODSNO ";
            sText += "AND GOODSMAKERCDRF=@GOODSMAKERCD ";
            sqlCommand = new SqlCommand(sText, sqlConnection, sqlTrans);

            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraLastAddUpDate = sqlCommand.Parameters.Add("@LASTADDUPDATE", SqlDbType.Int);
            SqlParameter paraInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
            SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
            //SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar); // DEL 2009/05/11
            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);

            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.EnterpriseCode);
            paraLastAddUpDate.Value = SqlDataMediator.SqlSetInt32(lastAddUpDate);
            paraInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDate);
            paraWarehouseCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.WarehouseCode);
            //paraSectionCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.SectionCode); // DEL 2009/05/11
            paraGoodsNo.Value = SqlDataMediator.SqlSetString(ivtDataWork.GoodsNo);
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(ivtDataWork.GoodsMakerCd);


            try
            {
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    arrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("S_ARRIVALCNTRF"));
                    shipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("S_SHIPMENTCNTRF"));
                }
                else
                {
                    arrivalCnt = 0.0;
                    shipmentCnt = 0.0;
                }
                if (!myReader.IsClosed) myReader.Close();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.GetStockAcPayHistData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion  // 在庫受払履歴データ検索

        #region 在庫受払履歴データ全件検索
        /// <summary>
        /// 在庫受払履歴データ全件検索
        /// </summary>
        /// <param name="stockAcPayHistWorkList">在庫履歴データ</param>
        /// <param name="ivtDataWork">棚卸データWork</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 在庫受払履歴データ全件検索を行いします。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/02/20</br>
        /// </remarks>
        private int GetStockAcPayHistDataAll(ref List<StockAcPayHistWork> stockAcPayHistWorkList, InventoryDataWork ivtDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            string sText = "";
            sText += "SELECT ARRIVALCNTRF, SHIPMENTCNTRF, WAREHOUSECODERF, GOODSNORF, GOODSMAKERCDRF,";
            sText += " CASE WHEN ADDUPADATERF IS NULL THEN IOGOODSDAYRF ELSE ADDUPADATERF END AS ADDUPADATEIOGOODSDAY ";
            //sText += "FROM STOCKACPAYHISTRF "; // DEL wangf 2012/03/23 FOR Redmine#29109
            sText += "FROM STOCKACPAYHISTRF WITH (READUNCOMMITTED) "; // ADD wangf 2012/03/23 FOR Redmine#29109
            sText += "WHERE ENTERPRISECODERF=@ENTERPRISECODE ";
            sText += "AND LOGICALDELETECODERF=0 ";

            sqlCommand = new SqlCommand(sText, sqlConnection, sqlTrans);

            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(ivtDataWork.EnterpriseCode);

            try
            {
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockAcPayHistWork stockAcPayHistWork = new StockAcPayHistWork();

                    #region クラスへ格納
                    stockAcPayHistWork.AddUpADateIoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATEIOGOODSDAY"));
                    stockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockAcPayHistWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                    stockAcPayHistWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    #endregion

                    stockAcPayHistWorkList.Add(stockAcPayHistWork);
                }

                if (!myReader.IsClosed) myReader.Close();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.GetStockAcPayHistData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// 在庫受払履歴データ検索
        /// </summary>
        /// <param name="dic">stockAcpayHistWorkList</param>
        /// <param name="ivtDataWork">棚卸データWork</param>
        /// <param name="lastAddUpDate">計上年月</param>
        /// <param name="targetDate">棚卸日</param>
        /// <param name="arrivalCnt">入荷数</param>
        /// <param name="shipmentCnt">出荷数</param>
        /// <remarks>
        /// <br>Note		: 在庫受払履歴データ検索を行いします。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/02/20</br>
        /// </remarks>
        private void GetStockAcPayHistData2(List<StockAcPayHistWork> stockAcpayHistWorkList, InventoryDataWork ivtDataWork, DateTime lastAddUpDate,
                            DateTime targetDate, ref double arrivalCnt, ref double shipmentCnt)
        {
            arrivalCnt = 0.0;
            shipmentCnt = 0.0;

            List<StockAcPayHistWork> newList = stockAcpayHistWorkList.FindAll(
                delegate(StockAcPayHistWork stockAcPayHistWork)
                {
                    if (stockAcPayHistWork.WarehouseCode == ivtDataWork.WarehouseCode
                        && stockAcPayHistWork.GoodsNo == ivtDataWork.GoodsNo
                        && stockAcPayHistWork.GoodsMakerCd.Equals(ivtDataWork.GoodsMakerCd)
                        && (stockAcPayHistWork.AddUpADateIoGoodsDay > lastAddUpDate
                             && stockAcPayHistWork.AddUpADateIoGoodsDay <= targetDate)
                        )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                );

            // 入荷数と出荷数の取得
            foreach (StockAcPayHistWork work in newList)
            {
                arrivalCnt += work.ArrivalCnt;
                shipmentCnt += work.ShipmentCnt;
            }
        }
        #endregion  // 在庫受払履歴データ全件検索

        #region 棚卸データ検索処理
        /// <summary>
        /// 棚卸データを検索し、棚卸データDictionaryを戻します
        /// </summary>
        /// <param name="dic">棚卸データDictionary</param>
        /// <param name="inventoryExtCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データDictionaryを戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        //#private int SeachInventoryData(out Dictionary<Guid,InventoryDataWork> dic, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode)
        private int SeachInventoryData(out Dictionary<String, InventoryDataWork> dic, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            //#dic = new Dictionary<Guid, InventoryDataWork>();
            dic = new Dictionary<String, InventoryDataWork>();

            try
            {
                string SelectDm = "";
                SelectDm += "SELECT";

                //結果取得
                SelectDm += " IVD.SECTIONCODERF  IVD_SECTIONCODERF";
                SelectDm += ", IVD.WAREHOUSECODERF IVD_WAREHOUSECODERF";
                SelectDm += ", IVD.WAREHOUSESHELFNORF IVD_WAREHOUSESHELFNORF";
                SelectDm += ", IVD.GOODSMAKERCDRF  IVD_GOODSMAKERCDRF";
                SelectDm += ", IVD.GOODSNORF  IVD_GOODSNORF";
                SelectDm += ", IVD.INVENTORYSEQNORF IVD_INVENTORYSEQNORF";
                SelectDm += ", IVD.STOCKUNITPRICEFLRF  IVD_STOCKUNITPRICEFLRF";
                SelectDm += ", IVD.BFSTOCKUNITPRICEFLRF  IVD_BFSTOCKUNITPRICEFLRF";
                SelectDm += ", IVD.STKUNITPRICECHGFLGRF IVD_STKUNITPRICECHGFLGRF";
                SelectDm += ", IVD.INVENTORYSTOCKCNTRF IVD_INVENTORYSTOCKCNTRF";
                SelectDm += ", IVD.INVENTORYTOLERANCCNTRF IVD_INVENTORYTOLERANCCNTRF";
                SelectDm += ", IVD.INVENTORYDAYRF IVD_INVENTORYDAYRF";
                SelectDm += ", IVD.LASTINVENTORYUPDATERF IVD_LASTINVENTORYUPDATERF";

                #region  変更前(MA.NS)
                /*
                SelectDm += " IVD.PRODUCTSTOCKGUIDRF IVD_PRODUCTSTOCKGUIDRF";
                SelectDm += ", IVD.INVENTORYSEQNORF IVD_INVENTORYSEQNORF";
                SelectDm += ", IVD.STOCKTELNO1RF IVD_STOCKTELNO1RF";
                SelectDm += ", IVD.BFSTOCKTELNO1RF IVD_BFSTOCKTELNO1RF";
                SelectDm += ", IVD.STKTELNO1CHGFLGRF IVD_STKTELNO1CHGFLGRF";
                SelectDm += ", IVD.STOCKTELNO2RF IVD_STOCKTELNO2RF";
                SelectDm += ", IVD.BFSTOCKTELNO2RF IVD_BFSTOCKTELNO2RF";
                SelectDm += ", IVD.STKTELNO2CHGFLGRF IVD_STKTELNO2CHGFLGRF";
                SelectDm += ", IVD.STOCKUNITPRICERF IVD_STOCKUNITPRICERF";
                SelectDm += ", IVD.BFSTOCKUNITPRICERF IVD_BFSTOCKUNITPRICERF";
                SelectDm += ", IVD.STKUNITPRICECHGFLGRF IVD_STKUNITPRICECHGFLGRF";
                SelectDm += ", IVD.INVENTORYSTOCKCNTRF IVD_INVENTORYSTOCKCNTRF";
                SelectDm += ", IVD.INVENTORYTOLERANCCNTRF IVD_INVENTORYTOLERANCCNTRF";
                SelectDm += ", IVD.INVENTORYDAYRF IVD_INVENTORYDAYRF";
                SelectDm += ", IVD.LASTINVENTORYUPDATERF IVD_LASTINVENTORYUPDATERF";
                */
                #endregion  // 変更前(MA.NS)

                //SelectDm += " FROM INVENTORYDATARF IVD"; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " FROM INVENTORYDATARF IVD WITH (READUNCOMMITTED) "; // ADD wangf 2012/03/23 FOR Redmine#29109

                sqlCommand = new SqlCommand(SelectDm, sqlConnection, sqlTrans);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, inventoryExtCndtnWork, logicalMode, 2);

                string Key = "";

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    InventoryDataWork wkInventoryDataWork = new InventoryDataWork();

                    #region 棚卸データ値セット
                    wkInventoryDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_SECTIONCODERF"));
                    wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSECODERF"));
                    wkInventoryDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSESHELFNORF"));
                    wkInventoryDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMAKERCDRF"));
                    wkInventoryDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_GOODSNORF"));
                    wkInventoryDataWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYSEQNORF"));
                    wkInventoryDataWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKUNITPRICEFLRF"));
                    wkInventoryDataWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_BFSTOCKUNITPRICEFLRF"));
                    wkInventoryDataWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKUNITPRICECHGFLGRF"));
                    wkInventoryDataWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKCNTRF"));
                    wkInventoryDataWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYTOLERANCCNTRF"));
                    wkInventoryDataWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDAYRF"));
                    wkInventoryDataWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTINVENTORYUPDATERF"));
                    // 修正 2009/05/22 >>>
                    //Key = KeyofDic(wkInventoryDataWork.WarehouseCode, wkInventoryDataWork.WarehouseShelfNo, 
                    //               wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo);
                    Key = KeyofDic(wkInventoryDataWork.WarehouseCode,
                                   wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo);
                    // 修正 2009/05/22 <<<
                    if (!dic.ContainsKey(Key))
                    {
                        dic.Add(Key, wkInventoryDataWork);
                    }

                    #region  変更前(MA.NS)
                    /*
                    wkInventoryDataWork.ProductStockGuid     = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("IVD_PRODUCTSTOCKGUIDRF"));
                    wkInventoryDataWork.InventorySeqNo       = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYSEQNORF"));
                    wkInventoryDataWork.StockTelNo1          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_STOCKTELNO1RF"));
                    wkInventoryDataWork.BfStockTelNo1        = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_BFSTOCKTELNO1RF"));
                    wkInventoryDataWork.StkTelNo1ChgFlg      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKTELNO1CHGFLGRF"));
                    wkInventoryDataWork.StockTelNo2          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_STOCKTELNO2RF"));
                    wkInventoryDataWork.BfStockTelNo2        = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_BFSTOCKTELNO2RF"));
                    wkInventoryDataWork.StkTelNo2ChgFlg      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKTELNO2CHGFLGRF"));
                    wkInventoryDataWork.StockUnitPrice       = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_STOCKUNITPRICERF"));
                    wkInventoryDataWork.BfStockUnitPrice     = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("IVD_BFSTOCKUNITPRICERF"));
                    wkInventoryDataWork.StkUnitPriceChgFlg   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKUNITPRICECHGFLGRF"));
                    wkInventoryDataWork.InventoryStockCnt    = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKCNTRF"));
                    wkInventoryDataWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYTOLERANCCNTRF"));
                    wkInventoryDataWork.InventoryDay         = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDAYRF"));
                    wkInventoryDataWork.LastInventoryUpdate  = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTINVENTORYUPDATERF"));
                    if (!dic.ContainsKey(wkInventoryDataWork.ProductStockGuid))
                    {
                        dic.Add(wkInventoryDataWork.ProductStockGuid, wkInventoryDataWork);
                    }
                    */
                    #endregion  // 変更前(MA.NS)
                    #endregion  // 棚卸データ値セット
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (!myReader.IsClosed) myReader.Close();
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SeachInventoryData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                //#if (!myReader.IsClosed) myReader.Close();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion  // 棚卸データ検索処理

        #region 棚卸データ削除処理
        /// <summary>
        /// 棚卸データ情報を物理削除します
        /// </summary>
        /// <param name="inventoryExtCndtnWork">棚卸準備処理オブジェクト</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データを物理削除します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        //#private int DeleteInventoryData(InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, ConstantManagement.LogicalMode logicalMode, List<InventoryDataWork> al, Dictionary<Guid, InventoryDataWork> dic)
        private int DeleteInventoryData(InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, ConstantManagement.LogicalMode logicalMode, List<InventoryDataWork> al, Dictionary<String, InventoryDataWork> dic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlCommand sqlCommand = null;

            Dictionary<string, InventoryDataWork> skipDic = new Dictionary<string, InventoryDataWork>();
            // -------UPD 2009/11/30------->>>>>
            //SkipSearch(out skipDic, al, dic);
            foreach (InventoryDataWork skipInventoryDataWork in dic.Values)
            {
                if (!skipDic.ContainsKey(skipInventoryDataWork.WarehouseCode))
                {
                    skipDic.Add(skipInventoryDataWork.WarehouseCode, skipInventoryDataWork);
                }
            }
            // -------UPD 2009/11/30-------<<<<<

            try
            {
                string SelectDm = "";
                SelectDm += "DELETE FROM INVENTORYDATARF";

                sqlCommand = new SqlCommand(SelectDm, sqlConnection, sqlTrans);
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, inventoryExtCndtnWork, logicalMode, 3);

                if (skipDic.Count > 0)
                {
                    int skipDicCount = 0;
                    // --- ADD 2009/11/30 ---------->>>>>
                    sqlCommand.CommandText += " AND (";
                    // --- ADD 2009/11/30 ----------<<<<<

                    foreach (InventoryDataWork skipInventoryDataWork in skipDic.Values)
                    {
                        // --- UPD 2009/11/30 ---------->>>>>
                        // 修正 2009/05/22 >>>
                        //sqlCommand.CommandText += " AND (" GOODSMAKERCDRF!=@GOODSMAKERCD" + skipDicCount.ToString() + " OR GOODSNORF!=@GOODSNO" + skipDicCount.ToString() + ")";
                        //sqlCommand.CommandText += " AND (WAREHOUSECODERF != @WAREHOUSECODE" + skipDicCount.ToString() + " AND  GOODSMAKERCDRF!=@GOODSMAKERCD" + skipDicCount.ToString() + " AND GOODSNORF!=@GOODSNO" + skipDicCount.ToString() + ")";
                        // 修正 2009/05/22 <<<

                        if (skipDicCount == 0)
                        {
                            sqlCommand.CommandText += " WAREHOUSECODERF = @WAREHOUSECODE" + skipDicCount.ToString();
                        }
                        else
                        {
                            sqlCommand.CommandText += " OR WAREHOUSECODERF = @WAREHOUSECODE" + skipDicCount.ToString();
                        }
                        // --- UPD 2009/11/30 ----------<<<<<

                        // --- DEL 2009/11/30 ---------->>>>>
                        //SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO" + skipDicCount.ToString(), SqlDbType.NVarChar);
                        //SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD" + skipDicCount.ToString(), SqlDbType.Int);
                        // --- DEL 2009/11/30 ----------<<<<<
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE" + skipDicCount.ToString(), SqlDbType.NVarChar); // ADD 2009/05/22

                        // --- DEL 2009/11/30 ---------->>>>>
                        //paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(skipInventoryDataWork.GoodsMakerCd);
                        //paraGoodsNo.Value = SqlDataMediator.SqlSetString(skipInventoryDataWork.GoodsNo);
                        // --- DEL 2009/11/30 ----------<<<<<
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(skipInventoryDataWork.WarehouseCode); // ADD 2009/05/22

                        #region  変更前(MA.NS)
                        /*
                        sqlCommand.CommandText += " AND (MAKERCODERF!=@MAKERCODE" + skipDicCount.ToString() + " OR GOODSCODERF!=@GOODSCODE" + skipDicCount.ToString() + ")";

                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE" + skipDicCount.ToString(), SqlDbType.Int);
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(skipInventoryDataWork.MakerCode);
                        SqlParameter paraGoodsCode = sqlCommand.Parameters.Add("@GOODSCODE" + skipDicCount.ToString(), SqlDbType.NVarChar);
                        paraGoodsCode.Value = SqlDataMediator.SqlSetString(skipInventoryDataWork.GoodsCode);
                        */
                        #endregion  // 変更前(MA.NS)
                        skipDicCount++;
                    }

                    // --- ADD 2009/11/30 ---------->>>>>
                    sqlCommand.CommandText += ")";
                    // --- ADD 2009/11/30 ----------<<<<<
                }

                //sqlCommand.CommandText += " AND (LASTINVENTORYUPDATERF IS NULL OR LASTINVENTORYUPDATERF=10101) "; // DEL 2009/05/22 


                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.DeleteInventoryData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion  // 棚卸データ削除処理

        #region SkipSearch
        /// <summary>
        /// 棚卸関連非表示項目検索
        /// </summary>
        /// <param name="skipDic">棚卸マスタ件数</param>
        /// <param name="_inventInputSearchCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸マスタの非表示項目を取得するクラスです。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.07.24</br>
        //#private void SkipSearch(out Dictionary<string, InventoryDataWork> skipDic, List<InventoryDataWork> al, Dictionary<Guid, InventoryDataWork> dic)
        private void SkipSearch(out Dictionary<string, InventoryDataWork> skipDic, List<InventoryDataWork> al, Dictionary<String, InventoryDataWork> dic)
        {
            skipDic = new Dictionary<string, InventoryDataWork>();
            string Key = "";

            if (dic != null)
            {
                foreach (InventoryDataWork wkInventoryDataWork in dic.Values)
                {
                    if ((wkInventoryDataWork.LastInventoryUpdate != null) && (wkInventoryDataWork.LastInventoryUpdate != DateTime.MinValue))
                    {
                        for (int iCnt = 0; iCnt < al.Count; iCnt++)
                        {
                            InventoryDataWork skipInventoryDataWork = al[iCnt] as InventoryDataWork;

                            if (skipInventoryDataWork.WarehouseCode == wkInventoryDataWork.WarehouseCode &&
                                //skipInventoryDataWork.WarehouseShelfNo == wkInventoryDataWork.WarehouseShelfNo && // DEL 2009/05/22
                                skipInventoryDataWork.GoodsMakerCd == wkInventoryDataWork.GoodsMakerCd &&
                                skipInventoryDataWork.GoodsNo == wkInventoryDataWork.GoodsNo)
                            {
                                wkInventoryDataWork.GoodsMakerCd = skipInventoryDataWork.GoodsMakerCd;
                                wkInventoryDataWork.GoodsNo = skipInventoryDataWork.GoodsNo;
                                // 修正 2009/05/22 >>>
                                //Key = KeyofDic(wkInventoryDataWork.WarehouseCode, wkInventoryDataWork.WarehouseShelfNo,
                                //               wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo);
                                Key = KeyofDic(wkInventoryDataWork.WarehouseCode,
                                               wkInventoryDataWork.GoodsMakerCd, wkInventoryDataWork.GoodsNo);
                                // 修正 2009/05/22 <<<
                                if (!skipDic.ContainsKey(Key))
                                {
                                    skipDic.Add(Key, wkInventoryDataWork);
                                }
                                break;
                            }

                            #region  変更前(MA.NS)
                            /*
                            if (skipInventoryDataWork.ProductStockGuid == wkInventoryDataWork.ProductStockGuid)
                            {
                                wkInventoryDataWork.MakerCode = skipInventoryDataWork.MakerCode;
                                wkInventoryDataWork.GoodsCode = skipInventoryDataWork.GoodsCode;

                                if (!skipDic.ContainsKey(wkInventoryDataWork.MakerCode.ToString() + "-" + wkInventoryDataWork.GoodsCode.ToString()))
                                {
                                    skipDic.Add(wkInventoryDataWork.MakerCode.ToString() + "-" + wkInventoryDataWork.GoodsCode.ToString(), wkInventoryDataWork);
                                }
                                break;
                            }
                            */
                            #endregion  // 変更前(MA.NS)
                        }
                    }
                }
            }
        }
        #endregion  // SkipSearch

        #region 棚卸データ登録処理
        /// <summary>
        /// 棚卸データListから棚卸データへ更新、登録を行います
        /// </summary>
        /// <param name="al">棚卸データList</param>
        /// <param name="dic">棚卸データDictionary</param>
        /// <param name="inventoryExtCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データListから棚卸データへ更新、登録を行います</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        /// <br>Update Note: 2011/01/11 yangmj 棚卸障害対応</br>
        //#private int WriteInventoryData(List<InventoryDataWork> al, Dictionary<Guid, InventoryDataWork> dic, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        private int WriteInventoryData(List<InventoryDataWork> al, Dictionary<String, InventoryDataWork> dic, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int MaxInventorySeqCount;
            //----ADD 2012/07/10 for Redmine#31103------>>>>>>
            Dictionary<String, int> inventorySeqsDic = new Dictionary<String, int>();
            //----ADD 2012/07/10 for Redmine#31103------<<<<<<
            string Key = "";
            try
            {
                // --- UPD 2009/11/30 ---------->>>>>
                //GetMaxInventorySeq(out MaxInventorySeqCount, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans); //DEL 2009/11/30
                al.Sort(new InventoryDataWorkComparer(inventoryExtCndtnWork.InvntryPrtOdrIniDiv));
                // --- UPD 2009/11/30 ----------<<<<<

                // 修正 2009/05/22 >>>
                //if ((inventoryExtCndtnWork.InventoryProcDiv == 0) || (inventoryExtCndtnWork.InventoryProcDiv == 2))
                if ((inventoryExtCndtnWork.InventoryProcDiv == 0)) //同一品番が棚卸データにあれば 準備処理対象にしない
                // 修正 2009/05/22 <<<
                {
                    Dictionary<string, InventoryDataWork> skipDic = new Dictionary<string, InventoryDataWork>();
                    SkipSearch(out skipDic, al, dic);

                    #region 棚卸データ登録 (抽出した在庫マスタより)
                    for (int iCnt = 0; iCnt < al.Count; iCnt++)
                    {
                        InventoryDataWork inventoryDataWork = al[iCnt] as InventoryDataWork;

                        // --- ADD 2009/11/30 ---------->>>>>
                        //GetMaxInventorySeq(out MaxInventorySeqCount, inventoryExtCndtnWork, inventoryDataWork, ref sqlConnection, ref sqlTrans); //DEL 2012/07/10 for Redmine#31103
                        // --- ADD 2009/11/30 ----------<<<<<
                        // --- DEL yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                        //----ADD 2012/07/10 for Redmine#31103------>>>>>>
                        //if (!inventorySeqsDic.ContainsKey(inventoryDataWork.WarehouseCode))
                        //{
                        //    GetMaxInventorySeq(out MaxInventorySeqCount, inventoryExtCndtnWork, inventoryDataWork, ref sqlConnection, ref sqlTrans);
                        //    inventorySeqsDic.Add(inventoryDataWork.WarehouseCode, MaxInventorySeqCount);
                        //}
                        //else
                        //{
                        //    MaxInventorySeqCount = inventorySeqsDic[inventoryDataWork.WarehouseCode] + 1;
                        //    inventorySeqsDic[inventoryDataWork.WarehouseCode] = MaxInventorySeqCount;
                        //}
                        //----ADD 2012/07/10 for Redmine#31103------<<<<<<
                        // --- DEL yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<
                        // InventoryProcDiv = 0 ( 再作成　棚卸入力数クリア) なので棚卸入力数を残さない

                        //$-- 2007.09.27 追加 >>>>>>>>
                        if (inventoryExtCndtnWork.InventoryProcDiv == 0)
                        {
                            if (dic != null)
                            {
                                // 修正 2009/05/22 >>>
                                //Key = KeyofDic(inventoryDataWork.WarehouseCode, inventoryDataWork.WarehouseShelfNo,
                                //               inventoryDataWork.GoodsMakerCd, inventoryDataWork.GoodsNo);
                                Key = KeyofDic(inventoryDataWork.WarehouseCode,
                                               inventoryDataWork.GoodsMakerCd, inventoryDataWork.GoodsNo);

                                // 修正 2009/05/22 <<<
                                if (dic.ContainsKey(Key))
                                {
                                    // 登録しようとする棚卸データと同一商品が既に棚卸データテーブルにある場合
                                    continue;
                                }
                            }
                        }
                        //$-- 2007.09.27 追加 <<<<<<<<

                        if (dic != null)
                        {
                            MergeInventoryDate(ref inventoryDataWork, dic, inventoryExtCndtnWork, skipDic);
                            if (inventoryDataWork == null)
                            {
                                continue;
                            }
                        }
                        // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                        if (!inventorySeqsDic.ContainsKey(inventoryDataWork.WarehouseCode))
                        {
                            GetMaxInventorySeq(out MaxInventorySeqCount, inventoryExtCndtnWork, inventoryDataWork, ref sqlConnection, ref sqlTrans);
                            inventorySeqsDic.Add(inventoryDataWork.WarehouseCode, MaxInventorySeqCount + 1);
                        }
                        else
                        {
                            MaxInventorySeqCount = inventorySeqsDic[inventoryDataWork.WarehouseCode];
                            inventorySeqsDic[inventoryDataWork.WarehouseCode] = MaxInventorySeqCount + 1;
                        }
                        // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<
                        //新規作成時のSQL文を生成
                        //-----ADD 2011/01/11----->>>>>
                        //SqlCommand sqlCommand = new SqlCommand("INSERT INTO INVENTORYDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYSEQNORF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, GOODSLGROUPRF, GOODSMGROUPRF, BLGROUPCODERF, ENTERPRISEGANRECODERF, BLGOODSCODERF, SUPPLIERCDRF, JANRF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, STKUNITPRICECHGFLGRF, STOCKDIVRF, LASTSTOCKDATERF, STOCKTOTALRF, SHIPCUSTOMERCODERF, INVENTORYSTOCKCNTRF, INVENTORYTOLERANCCNTRF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYDAYRF, LASTINVENTORYUPDATERF, INVENTORYNEWDIVRF, STOCKMASHINEPRICERF, INVENTORYSTOCKPRICERF, INVENTORYTLRNCPRICERF, INVENTORYDATERF,STOCKTOTALEXECRF, TOLERANCEUPDATECDRF,ADJSTCALCCOSTRF) "
                        //    + "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYSEQNO, @WAREHOUSECODE, @GOODSMAKERCD, @GOODSNO, @WAREHOUSESHELFNO, @DUPLICATIONSHELFNO1, @DUPLICATIONSHELFNO2, @GOODSLGROUP, @GOODSMGROUP, @BLGROUPCODE, @ENTERPRISEGANRECODE, @BLGOODSCODE, @SUPPLIERCD, @JAN, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @STKUNITPRICECHGFLG, @STOCKDIV, @LASTSTOCKDATE, @STOCKTOTAL, @SHIPCUSTOMERCODE, @INVENTORYSTOCKCNT, @INVENTORYTOLERANCCNT, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYDAY, @LASTINVENTORYUPDATE, @INVENTORYNEWDIV, @STOCKMASHINEPRICE, @INVENTORYSTOCKPRICE, @INVENTORYTLRNCPRICE, @INVENTORYDATE,@STOCKTOTALEXEC,@TOLERANCEUPDATECD,@ADJSTCALCCOST)", sqlConnection, sqlTrans);
                        SqlCommand sqlCommand = new SqlCommand("INSERT INTO INVENTORYDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYSEQNORF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, GOODSLGROUPRF, GOODSMGROUPRF, BLGROUPCODERF, ENTERPRISEGANRECODERF, BLGOODSCODERF, SUPPLIERCDRF, JANRF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, STKUNITPRICECHGFLGRF, STOCKDIVRF, LASTSTOCKDATERF, STOCKTOTALRF, SHIPCUSTOMERCODERF, INVENTORYSTOCKCNTRF, INVENTORYTOLERANCCNTRF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYDAYRF, LASTINVENTORYUPDATERF, INVENTORYNEWDIVRF, STOCKMASHINEPRICERF, INVENTORYSTOCKPRICERF, INVENTORYTLRNCPRICERF, INVENTORYDATERF,STOCKTOTALEXECRF, TOLERANCEUPDATECDRF,ADJSTCALCCOSTRF, GOODSNAMERF,LISTPRICEFLRF) "
                            + "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYSEQNO, @WAREHOUSECODE, @GOODSMAKERCD, @GOODSNO, @WAREHOUSESHELFNO, @DUPLICATIONSHELFNO1, @DUPLICATIONSHELFNO2, @GOODSLGROUP, @GOODSMGROUP, @BLGROUPCODE, @ENTERPRISEGANRECODE, @BLGOODSCODE, @SUPPLIERCD, @JAN, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @STKUNITPRICECHGFLG, @STOCKDIV, @LASTSTOCKDATE, @STOCKTOTAL, @SHIPCUSTOMERCODE, @INVENTORYSTOCKCNT, @INVENTORYTOLERANCCNT, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYDAY, @LASTINVENTORYUPDATE, @INVENTORYNEWDIV, @STOCKMASHINEPRICE, @INVENTORYSTOCKPRICE, @INVENTORYTLRNCPRICE, @INVENTORYDATE,@STOCKTOTALEXEC,@TOLERANCEUPDATECD,@ADJSTCALCCOST,@GOODSNAME,@LISTPRICEFL)", sqlConnection, sqlTrans);
                        //-----ADD 2011/01/11-----<<<<<

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)inventoryDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameterオブジェクトの作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInventorySeqNo = sqlCommand.Parameters.Add("@INVENTORYSEQNO", SqlDbType.Int);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                        SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@GOODSLGROUP", SqlDbType.Int);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraStkUnitPriceChgFlg = sqlCommand.Parameters.Add("@STKUNITPRICECHGFLG", SqlDbType.Int);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                        SqlParameter paraStockTotal = sqlCommand.Parameters.Add("@STOCKTOTAL", SqlDbType.Float);
                        SqlParameter paraShipCustomerCode = sqlCommand.Parameters.Add("@SHIPCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraInventoryStockCnt = sqlCommand.Parameters.Add("@INVENTORYSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraInventoryTolerancCnt = sqlCommand.Parameters.Add("@INVENTORYTOLERANCCNT", SqlDbType.Float);
                        SqlParameter paraInventoryPreprDay = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                        SqlParameter paraInventoryPreprTim = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                        SqlParameter paraInventoryDay = sqlCommand.Parameters.Add("@INVENTORYDAY", SqlDbType.Int);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        SqlParameter paraInventoryNewDiv = sqlCommand.Parameters.Add("@INVENTORYNEWDIV", SqlDbType.Int);
                        SqlParameter paraStockMashinePrice = sqlCommand.Parameters.Add("@STOCKMASHINEPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryStockPrice = sqlCommand.Parameters.Add("@INVENTORYSTOCKPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryTlrncPrice = sqlCommand.Parameters.Add("@INVENTORYTLRNCPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
                        SqlParameter paraStockTotalExec = sqlCommand.Parameters.Add("@STOCKTOTALEXEC", SqlDbType.Float); // ADD 2009/05/22 
                        SqlParameter paraToleranceUpdateCd = sqlCommand.Parameters.Add("@TOLERANCEUPDATECD", SqlDbType.Int);
                        SqlParameter paraAdjstCalcCost = sqlCommand.Parameters.Add("@ADJSTCALCCOST", SqlDbType.Float); // ADD 2009/05/11
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar); // ADD 2011/01/11
                        SqlParameter paraListPriceFl = sqlCommand.Parameters.Add("@LISTPRICEFL", SqlDbType.Float); // ADD 2011/01/11
                        #endregion

                        #region Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inventoryDataWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventoryDataWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventoryDataWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.LogicalDeleteCode);

                        paraSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.SectionCode); // 拠点コード
                        //paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(MaxInventorySeqCount + iCnt + 1); // 棚卸通番 DEL 2009/11/30
                        paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(MaxInventorySeqCount + 1); // 棚卸通番 ADD 2009/11/30
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.WarehouseCode); // 倉庫コード
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.GoodsMakerCd);    // メーカーコード
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(inventoryDataWork.GoodsNo);             // 品番
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryDataWork.WarehouseShelfNo); // 棚番
                        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(inventoryDataWork.DuplicationShelfNo1); // 重複棚番1
                        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(inventoryDataWork.DuplicationShelfNo2); // 重複棚番2
                        paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.GoodsLGroup); // 大分類
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.GoodsMGroup); // 中分類
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.BLGroupCode); // BLグループコード
                        paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.EnterpriseGanreCode); // 自社分類コード
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.BLGoodsCode); // BLコード
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.SupplierCd);   // 仕入先コード
                        paraJan.Value = SqlDataMediator.SqlSetString(inventoryDataWork.Jan);                // JANコード
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.StockUnitPriceFl); // 仕入単価(浮動)
                        paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.BfStockUnitPriceFl);// 変更前仕入単価
                        paraStkUnitPriceChgFlg.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.StkUnitPriceChgFlg); // 仕入単価変更フラグ
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.StockDiv);                     // 在庫区分
                        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.LastStockDate); // 最終仕入年月日
                        paraStockTotal.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.StockTotal);               // 在庫総数
                        paraShipCustomerCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.ShipCustomerCode);    // 出荷得意先コード(未使用項目)
                        paraInventoryStockCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.InventoryStockCnt); // 棚卸入力
                        paraInventoryTolerancCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.InventoryTolerancCnt); // 棚卸過不足数
                        paraInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.InventoryPreprDay);    // 棚卸準備処理日付
                        paraInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.InventoryPreprTim);                   // 棚卸準備処理時間
                        paraInventoryDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.InventoryDay);              // 棚卸入力
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.LastInventoryUpdate);// 最終棚卸更新日
                        paraInventoryNewDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.InventoryNewDiv);
                        paraStockMashinePrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataWork.StockMashinePrice);
                        paraInventoryStockPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataWork.InventoryStockPrice);
                        paraInventoryTlrncPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataWork.InventoryTlrncPrice);
                        paraInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.InventoryDate);
                        paraStockTotalExec.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.StockTotalExec); // ADD 2009/05/22
                        paraToleranceUpdateCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.ToleranceUpdateCd);
                        paraAdjstCalcCost.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.AdjstCalcCost); // ADD 2009/05/11 
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(inventoryDataWork.GoodsName); // ADD 2011/01/11
                        paraListPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.ListPriceFl); // ADD 2011/01/11

                        //通番対応保留（一括で通番を設定することが出来ない為）
                        //SqlParameter paraInventorySeqNo = sqlCommand.Parameters.Add("@INVENTORYSEQNO", SqlDbType.Int);
                        //if (inventoryDataWork.InventorySeqNo == 0)
                        //{
                        //    MaxInventorySeqCount++;
                        //    paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(MaxInventorySeqCount);
                        //}
                        //else
                        //{
                        //    paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.InventorySeqNo);
                        //}
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    #endregion

                }
                else if (inventoryExtCndtnWork.InventoryProcDiv == 1)
                {
                    Dictionary<string, InventoryDataWork> skipDic = new Dictionary<string, InventoryDataWork>();
                    SkipSearch(out skipDic, al, dic);

                    #region 棚卸データ登録 (抽出した在庫マスタより)
                    for (int iCnt = 0; iCnt < al.Count; iCnt++)
                    {
                        InventoryDataWork inventoryDataWork = al[iCnt] as InventoryDataWork;

                        // --- ADD 2009/11/30 ---------->>>>>
                        //GetMaxInventorySeq(out MaxInventorySeqCount, inventoryExtCndtnWork, inventoryDataWork, ref sqlConnection, ref sqlTrans);//DEL 2012/07/10 for Redmine#31103
                        // --- ADD 2009/11/30 ----------<<<<<
                        //----ADD 2012/07/10 for Redmine#31103------>>>>>>
                        //---- DEL yangyi 2012/09/03 ------>>>>>>
                        //if (!inventorySeqsDic.ContainsKey(inventoryDataWork.WarehouseCode))
                        //{
                        //    GetMaxInventorySeq(out MaxInventorySeqCount, inventoryExtCndtnWork, inventoryDataWork, ref sqlConnection, ref sqlTrans);
                        //    inventorySeqsDic.Add(inventoryDataWork.WarehouseCode, MaxInventorySeqCount);
                        //}
                        //else
                        //{
                        //    MaxInventorySeqCount = inventorySeqsDic[inventoryDataWork.WarehouseCode] + 1;
                        //    inventorySeqsDic[inventoryDataWork.WarehouseCode] = MaxInventorySeqCount;
                        //}
                        //----DEL yangyi 2012/09/03 ------<<<<<
                        //----ADD 2012/07/10 for Redmine#31103------<<<<<<<
                        if (dic != null)
                        {
                            MergeInventoryDate(ref inventoryDataWork, dic, inventoryExtCndtnWork, skipDic);
                            if (inventoryDataWork == null)
                            {
                                continue;
                            }
                        }

                        // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                        if (!inventorySeqsDic.ContainsKey(inventoryDataWork.WarehouseCode))
                        {
                            GetMaxInventorySeq(out MaxInventorySeqCount, inventoryExtCndtnWork, inventoryDataWork, ref sqlConnection, ref sqlTrans);
                            inventorySeqsDic.Add(inventoryDataWork.WarehouseCode, MaxInventorySeqCount + 1);
                        }
                        else
                        {
                            MaxInventorySeqCount = inventorySeqsDic[inventoryDataWork.WarehouseCode];
                            inventorySeqsDic[inventoryDataWork.WarehouseCode] = MaxInventorySeqCount + 1;
                        }
                        // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

                        //新規作成時のSQL文を生成
                        //-----ADD 2011/01/11----->>>>>
                        //SqlCommand sqlCommand = new SqlCommand("INSERT INTO INVENTORYDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYSEQNORF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, GOODSLGROUPRF, GOODSMGROUPRF, BLGROUPCODERF, ENTERPRISEGANRECODERF, BLGOODSCODERF, SUPPLIERCDRF, JANRF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, STKUNITPRICECHGFLGRF, STOCKDIVRF, LASTSTOCKDATERF, STOCKTOTALRF, SHIPCUSTOMERCODERF, INVENTORYSTOCKCNTRF, INVENTORYTOLERANCCNTRF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYDAYRF, LASTINVENTORYUPDATERF, INVENTORYNEWDIVRF, STOCKMASHINEPRICERF, INVENTORYSTOCKPRICERF, INVENTORYTLRNCPRICERF, INVENTORYDATERF,STOCKTOTALEXECRF,TOLERANCEUPDATECDRF,ADJSTCALCCOSTRF) "
                        //    + "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYSEQNO, @WAREHOUSECODE, @GOODSMAKERCD, @GOODSNO, @WAREHOUSESHELFNO, @DUPLICATIONSHELFNO1, @DUPLICATIONSHELFNO2, @GOODSLGROUP, @GOODSMGROUP, @BLGROUPCODE, @ENTERPRISEGANRECODE, @BLGOODSCODE, @SUPPLIERCD, @JAN, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @STKUNITPRICECHGFLG, @STOCKDIV, @LASTSTOCKDATE, @STOCKTOTAL, @SHIPCUSTOMERCODE, @INVENTORYSTOCKCNT, @INVENTORYTOLERANCCNT, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYDAY, @LASTINVENTORYUPDATE, @INVENTORYNEWDIV, @STOCKMASHINEPRICE, @INVENTORYSTOCKPRICE, @INVENTORYTLRNCPRICE, @INVENTORYDATE,@STOCKTOTALEXEC, @TOLERANCEUPDATECD,@ADJSTCALCCOST)", sqlConnection, sqlTrans);
                        SqlCommand sqlCommand = new SqlCommand("INSERT INTO INVENTORYDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYSEQNORF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, GOODSLGROUPRF, GOODSMGROUPRF, BLGROUPCODERF, ENTERPRISEGANRECODERF, BLGOODSCODERF, SUPPLIERCDRF, JANRF, STOCKUNITPRICEFLRF, BFSTOCKUNITPRICEFLRF, STKUNITPRICECHGFLGRF, STOCKDIVRF, LASTSTOCKDATERF, STOCKTOTALRF, SHIPCUSTOMERCODERF, INVENTORYSTOCKCNTRF, INVENTORYTOLERANCCNTRF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYDAYRF, LASTINVENTORYUPDATERF, INVENTORYNEWDIVRF, STOCKMASHINEPRICERF, INVENTORYSTOCKPRICERF, INVENTORYTLRNCPRICERF, INVENTORYDATERF,STOCKTOTALEXECRF, TOLERANCEUPDATECDRF,ADJSTCALCCOSTRF, GOODSNAMERF,LISTPRICEFLRF) "
                            + "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYSEQNO, @WAREHOUSECODE, @GOODSMAKERCD, @GOODSNO, @WAREHOUSESHELFNO, @DUPLICATIONSHELFNO1, @DUPLICATIONSHELFNO2, @GOODSLGROUP, @GOODSMGROUP, @BLGROUPCODE, @ENTERPRISEGANRECODE, @BLGOODSCODE, @SUPPLIERCD, @JAN, @STOCKUNITPRICEFL, @BFSTOCKUNITPRICEFL, @STKUNITPRICECHGFLG, @STOCKDIV, @LASTSTOCKDATE, @STOCKTOTAL, @SHIPCUSTOMERCODE, @INVENTORYSTOCKCNT, @INVENTORYTOLERANCCNT, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYDAY, @LASTINVENTORYUPDATE, @INVENTORYNEWDIV, @STOCKMASHINEPRICE, @INVENTORYSTOCKPRICE, @INVENTORYTLRNCPRICE, @INVENTORYDATE,@STOCKTOTALEXEC,@TOLERANCEUPDATECD,@ADJSTCALCCOST,@GOODSNAME,@LISTPRICEFL)", sqlConnection, sqlTrans);
                        //-----ADD 2011/01/11-----<<<<<

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)inventoryDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameterオブジェクトの作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInventorySeqNo = sqlCommand.Parameters.Add("@INVENTORYSEQNO", SqlDbType.Int);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                        SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                        SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@GOODSLGROUP", SqlDbType.Int);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraStkUnitPriceChgFlg = sqlCommand.Parameters.Add("@STKUNITPRICECHGFLG", SqlDbType.Int);
                        SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                        SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                        SqlParameter paraStockTotal = sqlCommand.Parameters.Add("@STOCKTOTAL", SqlDbType.Float);
                        SqlParameter paraShipCustomerCode = sqlCommand.Parameters.Add("@SHIPCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraInventoryStockCnt = sqlCommand.Parameters.Add("@INVENTORYSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraInventoryTolerancCnt = sqlCommand.Parameters.Add("@INVENTORYTOLERANCCNT", SqlDbType.Float);
                        SqlParameter paraInventoryPreprDay = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                        SqlParameter paraInventoryPreprTim = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                        SqlParameter paraInventoryDay = sqlCommand.Parameters.Add("@INVENTORYDAY", SqlDbType.Int);
                        SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                        SqlParameter paraInventoryNewDiv = sqlCommand.Parameters.Add("@INVENTORYNEWDIV", SqlDbType.Int);
                        SqlParameter paraStockMashinePrice = sqlCommand.Parameters.Add("@STOCKMASHINEPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryStockPrice = sqlCommand.Parameters.Add("@INVENTORYSTOCKPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryTlrncPrice = sqlCommand.Parameters.Add("@INVENTORYTLRNCPRICE", SqlDbType.BigInt);
                        SqlParameter paraInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
                        SqlParameter paraStockTotalExec = sqlCommand.Parameters.Add("@STOCKTOTALEXEC", SqlDbType.Float); // ADD 2009/05/22 
                        SqlParameter paraToleranceUpdateCd = sqlCommand.Parameters.Add("@TOLERANCEUPDATECD", SqlDbType.Int);
                        SqlParameter paraAdjstCalcCost = sqlCommand.Parameters.Add("@ADJSTCALCCOST", SqlDbType.Float); // ADD 2009/05/11
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar); // ADD 2011/01/11
                        SqlParameter paraListPriceFl = sqlCommand.Parameters.Add("@LISTPRICEFL", SqlDbType.Float); // ADD 2011/01/11

                        #endregion  // Parameterオブジェクトの作成

                        #region Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventoryDataWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inventoryDataWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventoryDataWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventoryDataWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.SectionCode);
                        //paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(MaxInventorySeqCount + iCnt + 1); // DEL 2009/11/30
                        paraInventorySeqNo.Value = SqlDataMediator.SqlSetInt32(MaxInventorySeqCount + 1); // 棚卸通番 ADD 2009/11/30
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.WarehouseCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(inventoryDataWork.GoodsNo);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryDataWork.WarehouseShelfNo);
                        paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(inventoryDataWork.DuplicationShelfNo1);
                        paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(inventoryDataWork.DuplicationShelfNo2);
                        paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.GoodsLGroup);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.GoodsMGroup);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.BLGroupCode);
                        paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.EnterpriseGanreCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.BLGoodsCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.SupplierCd);
                        paraJan.Value = SqlDataMediator.SqlSetString(inventoryDataWork.Jan);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.StockUnitPriceFl);
                        paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.BfStockUnitPriceFl);
                        paraStkUnitPriceChgFlg.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.StkUnitPriceChgFlg);
                        paraStockDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.StockDiv);
                        paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.LastStockDate);
                        paraStockTotal.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.StockTotal);
                        paraShipCustomerCode.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.ShipCustomerCode);
                        paraInventoryStockCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.InventoryStockCnt);
                        paraInventoryTolerancCnt.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.InventoryTolerancCnt);
                        paraInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.InventoryPreprDay);
                        paraInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.InventoryPreprTim);
                        paraInventoryDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.InventoryDay);
                        paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.LastInventoryUpdate);
                        paraInventoryNewDiv.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.InventoryNewDiv);
                        paraStockMashinePrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataWork.StockMashinePrice);
                        paraInventoryStockPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataWork.InventoryStockPrice);
                        paraInventoryTlrncPrice.Value = SqlDataMediator.SqlSetInt64(inventoryDataWork.InventoryTlrncPrice);
                        paraInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventoryDataWork.InventoryDate);
                        paraStockTotalExec.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.StockTotalExec); // ADD 2009/05/22
                        paraToleranceUpdateCd.Value = SqlDataMediator.SqlSetInt32(inventoryDataWork.ToleranceUpdateCd);
                        paraAdjstCalcCost.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.AdjstCalcCost); // ADD 2009/05/11 
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(inventoryDataWork.GoodsName); // ADD 2011/01/11
                        paraListPriceFl.Value = SqlDataMediator.SqlSetDouble(inventoryDataWork.ListPriceFl); // ADD 2011/01/11

                        #endregion  // Parameterオブジェクトへ値設定

                        sqlCommand.ExecuteNonQuery();
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    #endregion
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.WriteInventoryData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
            }

            return status;
        }
        #region 通番最終番号取得
        /// <summary>
        /// 棚卸準備データ内の通番最終番号を戻します
        /// </summary>
        /// <param name="MaxInventorySeqCount">通番最終番号</param>
        /// <param name="inventoryExtCndtnWork">検索パラメータ</param>
        /// <param name="inventoryDataWork">検索パラメータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸準備データ内の通番最終番号を戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        private int GetMaxInventorySeq(out int MaxInventorySeqCount, InventoryExtCndtnWork inventoryExtCndtnWork, InventoryDataWork inventoryDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;
            MaxInventorySeqCount = 0;
            try
            {
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT MAX(INVENTORYSEQNORF) INVENTORYSEQNO_MAX FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTrans));               
                // ADD 2008/09/18 >>>
                string sText = "";
                sText = "SELECT MAX(INVENTORYSEQNORF) ";
                sText += "INVENTORYSEQNO_MAX ";
                //sText += " FROM INVENTORYDATARF"; // DEL wangf 2012/03/23 FOR Redmine#29109
                sText += " FROM INVENTORYDATARF WITH (READUNCOMMITTED) "; // ADD wangf 2012/03/23 FOR Redmine#29109
                sText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                //sText += " AND SECTIONCODERF=@FINDSECTIONCODE"; // DEL 2008.12.02
                sText += " AND WAREHOUSECODERF=@FINDWAREHOUSECODERF"; // ADD 2009/11/30
                using (SqlCommand sqlCommand = new SqlCommand(sText, sqlConnection, sqlTrans))
                // ADD 2008/09/18 <<<
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // DEL 2008.12.02
                    SqlParameter findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODERF", SqlDbType.NChar); // ADD 2009/11/30

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EnterpriseCode);
                    //findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCode); // DEL 2008.12.02
                    findWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.WarehouseCode); // ADD 2009/11/30

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        MaxInventorySeqCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYSEQNO_MAX"));
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.GetMaxInventorySeq Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //#if (!myReader.IsClosed) myReader.Close();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region マージ処理
        /// <summary>
        /// 準備処理前の棚卸データとのマージを行います
        /// </summary>
        /// <param name="inventoryDataWork">棚卸データWork</param>
        /// <param name="dic">棚卸データDictionary</param>
        /// <param name="inventoryExtCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 準備処理前の棚卸データとのマージを行います（処理区分によって処理内容変更）</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        //#private int MergeInventoryDate(ref InventoryDataWork inventoryDataWork, Dictionary<Guid, InventoryDataWork> dic, InventoryExtCndtnWork inventoryExtCndtnWork, Dictionary<string, InventoryDataWork> skipDic)
        private int MergeInventoryDate(ref InventoryDataWork inventoryDataWork, Dictionary<String, InventoryDataWork> dic, InventoryExtCndtnWork inventoryExtCndtnWork, Dictionary<string, InventoryDataWork> skipDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string Key = "";

            if (inventoryExtCndtnWork.InventoryProcDiv == 1)
            {
                // 修正 2009/05/22 >>>
                //Key = KeyofDic(inventoryDataWork.WarehouseCode, inventoryDataWork.WarehouseShelfNo,
                //               inventoryDataWork.GoodsMakerCd, inventoryDataWork.GoodsNo);
                Key = KeyofDic(inventoryDataWork.WarehouseCode,
                               inventoryDataWork.GoodsMakerCd, inventoryDataWork.GoodsNo);
                // 修正 2009/05/22 <<<

                if (dic.ContainsKey(Key))
                {
                    InventoryDataWork wkInventoryDataWork = (InventoryDataWork)dic[Key];

                    inventoryDataWork.InventorySeqNo = wkInventoryDataWork.InventorySeqNo;
                    inventoryDataWork.StockUnitPriceFl = wkInventoryDataWork.StockUnitPriceFl;
                    inventoryDataWork.BfStockUnitPriceFl = wkInventoryDataWork.BfStockUnitPriceFl;
                    inventoryDataWork.StkUnitPriceChgFlg = wkInventoryDataWork.StkUnitPriceChgFlg;
                    inventoryDataWork.InventoryStockCnt = wkInventoryDataWork.InventoryStockCnt;
                    inventoryDataWork.InventoryTolerancCnt = wkInventoryDataWork.InventoryTolerancCnt;
                    inventoryDataWork.InventoryDay = wkInventoryDataWork.InventoryDay;
                    inventoryDataWork.LastInventoryUpdate = wkInventoryDataWork.LastInventoryUpdate;
                }

                if (skipDic.Count > 0)
                {
                    foreach (InventoryDataWork skipInventoryDataWork in skipDic.Values)
                    {
                        if ((inventoryDataWork.GoodsMakerCd == skipInventoryDataWork.GoodsMakerCd) && (inventoryDataWork.GoodsNo == skipInventoryDataWork.GoodsNo))
                        {
                            inventoryDataWork = null;
                            break;
                        }
                    }
                }
            }

            #region  変更前(MA.NS)
            /*
            if (inventoryExtCndtnWork.InventoryProcDiv == 1)
            {
                if (dic.ContainsKey(inventoryDataWork.ProductStockGuid))
                {
                    InventoryDataWork wkInventoryDataWork = (InventoryDataWork)dic[inventoryDataWork.ProductStockGuid];

                    //inventoryDataWork.InventorySeqNo = wkInventoryDataWork.InventorySeqNo;
                    //inventoryDataWork.StockTelNo1 = wkInventoryDataWork.StockTelNo1;
                    //inventoryDataWork.BfStockTelNo1 = wkInventoryDataWork.BfStockTelNo1;
                    //inventoryDataWork.StkTelNo1ChgFlg = wkInventoryDataWork.StkTelNo1ChgFlg;
                    //inventoryDataWork.StockTelNo2 = wkInventoryDataWork.StockTelNo2;
                    //inventoryDataWork.BfStockTelNo2 = wkInventoryDataWork.BfStockTelNo2;
                    //inventoryDataWork.StkTelNo2ChgFlg = wkInventoryDataWork.StkTelNo2ChgFlg;
                    //inventoryDataWork.StockUnitPrice = wkInventoryDataWork.StockUnitPrice;
                    //inventoryDataWork.BfStockUnitPrice = wkInventoryDataWork.BfStockUnitPrice;
                    //inventoryDataWork.StkUnitPriceChgFlg = wkInventoryDataWork.StkUnitPriceChgFlg;
                    inventoryDataWork.InventoryStockCnt = wkInventoryDataWork.InventoryStockCnt;
                    inventoryDataWork.InventoryTolerancCnt = wkInventoryDataWork.InventoryTolerancCnt;
                    inventoryDataWork.InventoryDay = wkInventoryDataWork.InventoryDay;
                    inventoryDataWork.LastInventoryUpdate = wkInventoryDataWork.LastInventoryUpdate;
                }

                if (skipDic.Count > 0)
                {
                    foreach (InventoryDataWork skipInventoryDataWork in skipDic.Values)
                    {
                        if ((inventoryDataWork.MakerCode == skipInventoryDataWork.MakerCode) && (inventoryDataWork.GoodsCode == skipInventoryDataWork.GoodsCode))
                        {
                            inventoryDataWork = null;
                            break;
                        }
                    }
                }
            }
            */
            #endregion  // 変更前(MA.NS)

            return status;
        }
        #endregion
        #endregion  // 棚卸データ登録処理

        #region 棚卸データ（準備処理履歴）登録処理
        /// <summary>
        /// 棚卸データ（準備処理履歴）を登録、更新します
        /// </summary>
        /// <param name="inventDataPreWork">InventDataPreWorkオブジェクト</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データ（準備処理履歴）を登録、更新します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        private int WriteInventDataPre(ref InventDataPreWork inventDataPreWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成

                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM INVENTDATAPRERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYPREPRDAYRF=@FINDINVENTORYPREPRDAY AND INVENTORYPREPRTIMRF=@FINDINVENTORYPREPRTIM ", sqlConnection, sqlTrans))
                {
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaInventoryPreprDay = sqlCommand.Parameters.Add("@FINDINVENTORYPREPRDAY", SqlDbType.Int);
                    SqlParameter findParaInventoryPreprTim = sqlCommand.Parameters.Add("@FINDINVENTORYPREPRTIM", SqlDbType.Int);

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                    findParaInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                    findParaInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != inventDataPreWork.UpdateDateTime)
                        {
                            //新規登録で該当データ有りの場合には重複
                            if (inventDataPreWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //既存データで更新日時違いの場合には排他
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            if (!myReader.IsClosed) myReader.Close();
                            return status;
                        }
                        // 修正 2008/09/18  >>>
                        //sqlCommand.CommandText = "UPDATE INVENTDATAPRERF SET  UPDATEDATETIMERF=@UPDATEDATETIME, FILEHEADERGUIDRF=@FILEHEADERGUID, UPDEMPLOYEECODERF=@UPDEMPLOYEECODE, UPDASSEMBLYID1RF=@UPDASSEMBLYID1, UPDASSEMBLYID2RF=@UPDASSEMBLYID2, LOGICALDELETECODERF=@LOGICALDELETECODE, SECTIONCODERF=@SECTIONCODE, INVENTORYPREPRDAYRF=@INVENTORYPREPRDAY, INVENTORYPREPRTIMRF=@INVENTORYPREPRTIM, INVENTORYPROCDIVRF=@INVENTORYPROCDIV, WAREHOUSECODESTRF=@WAREHOUSECODEST, WAREHOUSECODEEDRF=@WAREHOUSECODEED, SHELFNOSTRF=@SHELFNOST, SHELFNOEDRF=@SHELFNOED, STARTSUPPLIERCODERF=@STARTSUPPLIERCODE, ENDSUPPLIERCODERF=@ENDSUPPLIERCODE, BLGOODSCODESTRF=@BLGOODSCODEST, BLGOODSCODEEDRF=@BLGOODSCODEED, GOODSMAKERCDSTRF=@GOODSMAKERCDST, GOODSMAKERCDEDRF=@GOODSMAKERCDED, LGGOODSGANRECDSTRF=@LGGOODSGANRECDST, LGGOODSGANRECDEDRF=@LGGOODSGANRECDED, MDGOODSGANRECDSTRF=@MDGOODSGANRECDST, MDGOODSGANRECDEDRF=@MDGOODSGANRECDED, DTLGOODSGANRECDSTRF=@DTLGOODSGANRECDST, DTLGOODSGANRECDEDRF=@DTLGOODSGANRECDED, ENTERPRISEGANRECDSTRF=@ENTERPRISEGANRECDST, ENTERPRISEGANRECDEDRF=@ENTERPRISEGANRECDED, CMPSTKEXTRADIVRF=@CMPSTKEXTRADIV, TRTSTKEXTRADIVRF=@TRTSTKEXTRADIV, ENTCMPSTKEXTRADIVRF=@ENTCMPSTKEXTRADIV, ENTTRTSTKEXTRADIVRF=@ENTTRTSTKEXTRADIV, LTINVENTORYUPDATESTRF=@LTINVENTORYUPDATEST, LTINVENTORYUPDATEEDRF=@LTINVENTORYUPDATEED, SELWAREHOUSECODE1RF=@SELWAREHOUSECODE1, SELWAREHOUSECODE2RF=@SELWAREHOUSECODE2, SELWAREHOUSECODE3RF=@SELWAREHOUSECODE3, SELWAREHOUSECODE4RF=@SELWAREHOUSECODE4, SELWAREHOUSECODE5RF=@SELWAREHOUSECODE5, SELWAREHOUSECODE6RF=@SELWAREHOUSECODE6, SELWAREHOUSECODE7RF=@SELWAREHOUSECODE7, SELWAREHOUSECODE8RF=@SELWAREHOUSECODE8, SELWAREHOUSECODE9RF=@SELWAREHOUSECODE9, SELWAREHOUSECODE10RF=@SELWAREHOUSECODE10, INVENTORYDATERF=@INVENTORYDATE "  
                        //                       + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYPREPRDAYRF=@FINDINVENTORYPREPRDAY AND INVENTORYPREPRTIMRF=@FINDINVENTORYPREPRTIM ";

                        // -------UPD 2011/01/30------->>>>>
                        //sqlCommand.CommandText = "UPDATE INVENTDATAPRERF SET UPDATEDATETIMERF=@UPDATEDATETIME , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , INVENTORYPREPRDAYRF=@INVENTORYPREPRDAY , INVENTORYPREPRTIMRF=@INVENTORYPREPRTIM , INVENTORYPROCDIVRF=@INVENTORYPROCDIV , WAREHOUSECODESTRF=@WAREHOUSECODEST , WAREHOUSECODEEDRF=@WAREHOUSECODEED , SHELFNOSTRF=@SHELFNOST , SHELFNOEDRF=@SHELFNOED , STARTSUPPLIERCODERF=@STARTSUPPLIERCODE , ENDSUPPLIERCODERF=@ENDSUPPLIERCODE , BLGOODSCODESTRF=@BLGOODSCODEST , BLGOODSCODEEDRF=@BLGOODSCODEED , GOODSMAKERCDSTRF=@GOODSMAKERCDST , GOODSMAKERCDEDRF=@GOODSMAKERCDED , BLGROUPCODESTRF=@BLGROUPCODEST , BLGROUPCODEEDRF=@BLGROUPCODEED , TRTSTKEXTRADIVRF=@TRTSTKEXTRADIV , ENTCMPSTKEXTRADIVRF=@ENTCMPSTKEXTRADIV , LTINVENTORYUPDATESTRF=@LTINVENTORYUPDATEST , LTINVENTORYUPDATEEDRF=@LTINVENTORYUPDATEED , SELWAREHOUSECODE1RF=@SELWAREHOUSECODE1 , SELWAREHOUSECODE2RF=@SELWAREHOUSECODE2 , SELWAREHOUSECODE3RF=@SELWAREHOUSECODE3 , SELWAREHOUSECODE4RF=@SELWAREHOUSECODE4 , SELWAREHOUSECODE5RF=@SELWAREHOUSECODE5 , SELWAREHOUSECODE6RF=@SELWAREHOUSECODE6 , SELWAREHOUSECODE7RF=@SELWAREHOUSECODE7 , SELWAREHOUSECODE8RF=@SELWAREHOUSECODE8 , SELWAREHOUSECODE9RF=@SELWAREHOUSECODE9 , SELWAREHOUSECODE10RF=@SELWAREHOUSECODE10 , INVENTORYDATERF=@INVENTORYDATE"
                        //                       + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYPREPRDAYRF=@FINDINVENTORYPREPRDAY AND INVENTORYPREPRTIMRF=@FINDINVENTORYPREPRTIM ";
                        sqlCommand.CommandText = "UPDATE INVENTDATAPRERF SET UPDATEDATETIMERF=@UPDATEDATETIME , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , INVENTORYPREPRDAYRF=@INVENTORYPREPRDAY , INVENTORYPREPRTIMRF=@INVENTORYPREPRTIM , INVENTORYPROCDIVRF=@INVENTORYPROCDIV , WAREHOUSECODESTRF=@WAREHOUSECODEST , WAREHOUSECODEEDRF=@WAREHOUSECODEED , SHELFNOSTRF=@SHELFNOST , SHELFNOEDRF=@SHELFNOED , STARTSUPPLIERCODERF=@STARTSUPPLIERCODE , ENDSUPPLIERCODERF=@ENDSUPPLIERCODE , BLGOODSCODESTRF=@BLGOODSCODEST , BLGOODSCODEEDRF=@BLGOODSCODEED , GOODSMAKERCDSTRF=@GOODSMAKERCDST , GOODSMAKERCDEDRF=@GOODSMAKERCDED , BLGROUPCODESTRF=@BLGROUPCODEST , BLGROUPCODEEDRF=@BLGROUPCODEED , TRTSTKEXTRADIVRF=@TRTSTKEXTRADIV , ENTCMPSTKEXTRADIVRF=@ENTCMPSTKEXTRADIV , LTINVENTORYUPDATESTRF=@LTINVENTORYUPDATEST , LTINVENTORYUPDATEEDRF=@LTINVENTORYUPDATEED , SELWAREHOUSECODE1RF=@SELWAREHOUSECODE1 , SELWAREHOUSECODE2RF=@SELWAREHOUSECODE2 , SELWAREHOUSECODE3RF=@SELWAREHOUSECODE3 , SELWAREHOUSECODE4RF=@SELWAREHOUSECODE4 , SELWAREHOUSECODE5RF=@SELWAREHOUSECODE5 , SELWAREHOUSECODE6RF=@SELWAREHOUSECODE6 , SELWAREHOUSECODE7RF=@SELWAREHOUSECODE7 , SELWAREHOUSECODE8RF=@SELWAREHOUSECODE8 , SELWAREHOUSECODE9RF=@SELWAREHOUSECODE9 , SELWAREHOUSECODE10RF=@SELWAREHOUSECODE10 , INVENTORYDATERF=@INVENTORYDATE, MNGSECTIONCODESTRF=@MNGSECTIONCODEST, MNGSECTIONCODEEDRF=@MNGSECTIONCODEED"
                                               + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYPREPRDAYRF=@FINDINVENTORYPREPRDAY AND INVENTORYPREPRTIMRF=@FINDINVENTORYPREPRTIM ";
                        // -------UPD 2011/01/30-------<<<<<
                        // 修正 2008/09/18 <<<
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                        findParaInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                        findParaInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)inventDataPreWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //新規作成時のSQL文を生成
                        //sqlCommand.CommandText = "INSERT INTO INVENTDATAPRERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYPROCDIVRF, WAREHOUSECODESTRF, WAREHOUSECODEEDRF, SHELFNOSTRF, SHELFNOEDRF, STARTSUPPLIERCODERF, ENDSUPPLIERCODERF, BLGOODSCODESTRF, BLGOODSCODEEDRF, GOODSMAKERCDSTRF, GOODSMAKERCDEDRF, LGGOODSGANRECDSTRF, LGGOODSGANRECDEDRF, MDGOODSGANRECDSTRF, MDGOODSGANRECDEDRF, DTLGOODSGANRECDSTRF, DTLGOODSGANRECDEDRF, ENTERPRISEGANRECDSTRF, ENTERPRISEGANRECDEDRF, CMPSTKEXTRADIVRF, TRTSTKEXTRADIVRF, ENTCMPSTKEXTRADIVRF, ENTTRTSTKEXTRADIVRF, LTINVENTORYUPDATESTRF, LTINVENTORYUPDATEEDRF, SELWAREHOUSECODE1RF, SELWAREHOUSECODE2RF, SELWAREHOUSECODE3RF, SELWAREHOUSECODE4RF, SELWAREHOUSECODE5RF, SELWAREHOUSECODE6RF, SELWAREHOUSECODE7RF, SELWAREHOUSECODE8RF, SELWAREHOUSECODE9RF, SELWAREHOUSECODE10RF, INVENTORYDATERF) "
                        //    + "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYPROCDIV, @WAREHOUSECODEST, @WAREHOUSECODEED, @SHELFNOST, @SHELFNOED, @STARTSUPPLIERCODE, @ENDSUPPLIERCODE, @BLGOODSCODEST, @BLGOODSCODEED, @GOODSMAKERCDST, @GOODSMAKERCDED, @LGGOODSGANRECDST, @LGGOODSGANRECDED, @MDGOODSGANRECDST, @MDGOODSGANRECDED, @DTLGOODSGANRECDST, @DTLGOODSGANRECDED, @ENTERPRISEGANRECDST, @ENTERPRISEGANRECDED, @CMPSTKEXTRADIV, @TRTSTKEXTRADIV, @ENTCMPSTKEXTRADIV, @ENTTRTSTKEXTRADIV, @LTINVENTORYUPDATEST, @LTINVENTORYUPDATEED, @SELWAREHOUSECODE1, @SELWAREHOUSECODE2, @SELWAREHOUSECODE3, @SELWAREHOUSECODE4, @SELWAREHOUSECODE5, @SELWAREHOUSECODE6, @SELWAREHOUSECODE7, @SELWAREHOUSECODE8, @SELWAREHOUSECODE9, @SELWAREHOUSECODE10, @INVENTORYDATE) ";
                        // -------UPD 2011/01/30------->>>>>
                        //sqlCommand.CommandText = "INSERT INTO INVENTDATAPRERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYPROCDIVRF, WAREHOUSECODESTRF, WAREHOUSECODEEDRF, SHELFNOSTRF, SHELFNOEDRF, STARTSUPPLIERCODERF, ENDSUPPLIERCODERF, BLGOODSCODESTRF, BLGOODSCODEEDRF, GOODSMAKERCDSTRF, GOODSMAKERCDEDRF, BLGROUPCODESTRF, BLGROUPCODEEDRF, TRTSTKEXTRADIVRF, ENTCMPSTKEXTRADIVRF, LTINVENTORYUPDATESTRF, LTINVENTORYUPDATEEDRF, SELWAREHOUSECODE1RF, SELWAREHOUSECODE2RF, SELWAREHOUSECODE3RF, SELWAREHOUSECODE4RF, SELWAREHOUSECODE5RF, SELWAREHOUSECODE6RF, SELWAREHOUSECODE7RF, SELWAREHOUSECODE8RF, SELWAREHOUSECODE9RF, SELWAREHOUSECODE10RF, INVENTORYDATERF) "
                        //    + " VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYPROCDIV, @WAREHOUSECODEST, @WAREHOUSECODEED, @SHELFNOST, @SHELFNOED, @STARTSUPPLIERCODE, @ENDSUPPLIERCODE, @BLGOODSCODEST, @BLGOODSCODEED, @GOODSMAKERCDST, @GOODSMAKERCDED, @BLGROUPCODEST, @BLGROUPCODEED, @TRTSTKEXTRADIV, @ENTCMPSTKEXTRADIV, @LTINVENTORYUPDATEST, @LTINVENTORYUPDATEED, @SELWAREHOUSECODE1, @SELWAREHOUSECODE2, @SELWAREHOUSECODE3, @SELWAREHOUSECODE4, @SELWAREHOUSECODE5, @SELWAREHOUSECODE6, @SELWAREHOUSECODE7, @SELWAREHOUSECODE8, @SELWAREHOUSECODE9, @SELWAREHOUSECODE10, @INVENTORYDATE)";
                        sqlCommand.CommandText = "INSERT INTO INVENTDATAPRERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYPROCDIVRF, WAREHOUSECODESTRF, WAREHOUSECODEEDRF, SHELFNOSTRF, SHELFNOEDRF, STARTSUPPLIERCODERF, ENDSUPPLIERCODERF, BLGOODSCODESTRF, BLGOODSCODEEDRF, GOODSMAKERCDSTRF, GOODSMAKERCDEDRF, BLGROUPCODESTRF, BLGROUPCODEEDRF, TRTSTKEXTRADIVRF, ENTCMPSTKEXTRADIVRF, LTINVENTORYUPDATESTRF, LTINVENTORYUPDATEEDRF, SELWAREHOUSECODE1RF, SELWAREHOUSECODE2RF, SELWAREHOUSECODE3RF, SELWAREHOUSECODE4RF, SELWAREHOUSECODE5RF, SELWAREHOUSECODE6RF, SELWAREHOUSECODE7RF, SELWAREHOUSECODE8RF, SELWAREHOUSECODE9RF, SELWAREHOUSECODE10RF, INVENTORYDATERF, MNGSECTIONCODESTRF, MNGSECTIONCODEEDRF) "
                            + " VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYPROCDIV, @WAREHOUSECODEST, @WAREHOUSECODEED, @SHELFNOST, @SHELFNOED, @STARTSUPPLIERCODE, @ENDSUPPLIERCODE, @BLGOODSCODEST, @BLGOODSCODEED, @GOODSMAKERCDST, @GOODSMAKERCDED, @BLGROUPCODEST, @BLGROUPCODEED, @TRTSTKEXTRADIV, @ENTCMPSTKEXTRADIV, @LTINVENTORYUPDATEST, @LTINVENTORYUPDATEED, @SELWAREHOUSECODE1, @SELWAREHOUSECODE2, @SELWAREHOUSECODE3, @SELWAREHOUSECODE4, @SELWAREHOUSECODE5, @SELWAREHOUSECODE6, @SELWAREHOUSECODE7, @SELWAREHOUSECODE8, @SELWAREHOUSECODE9, @SELWAREHOUSECODE10, @INVENTORYDATE, @MNGSECTIONCODEST, @MNGSECTIONCODEED)";

                        // -------UPD 2011/01/30-------<<<<<
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)inventDataPreWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    if (!myReader.IsClosed) myReader.Close();

                    #region Parameterオブジェクトの作成
                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraInventoryPreprDay = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                    SqlParameter paraInventoryPreprTim = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                    SqlParameter paraInventoryProcDiv = sqlCommand.Parameters.Add("@INVENTORYPROCDIV", SqlDbType.Int);
                    SqlParameter paraWarehouseCodeSt = sqlCommand.Parameters.Add("@WAREHOUSECODEST", SqlDbType.NChar);
                    SqlParameter paraWarehouseCodeEd = sqlCommand.Parameters.Add("@WAREHOUSECODEED", SqlDbType.NChar);
                    SqlParameter paraShelfNoSt = sqlCommand.Parameters.Add("@SHELFNOST", SqlDbType.NVarChar);
                    SqlParameter paraShelfNoEd = sqlCommand.Parameters.Add("@SHELFNOED", SqlDbType.NVarChar);
                    SqlParameter paraStartSupplierCode = sqlCommand.Parameters.Add("@STARTSUPPLIERCODE", SqlDbType.Int);
                    SqlParameter paraEndSupplierCode = sqlCommand.Parameters.Add("@ENDSUPPLIERCODE", SqlDbType.Int);
                    SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@BLGOODSCODEST", SqlDbType.Int);
                    SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@BLGOODSCODEED", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                    SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@BLGROUPCODEST", SqlDbType.Int);
                    SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@BLGROUPCODEED", SqlDbType.Int);
                    SqlParameter paraTrtStkExtraDiv = sqlCommand.Parameters.Add("@TRTSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraEntCmpStkExtraDiv = sqlCommand.Parameters.Add("@ENTCMPSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraLtInventoryUpdateSt = sqlCommand.Parameters.Add("@LTINVENTORYUPDATEST", SqlDbType.Int);
                    SqlParameter paraLtInventoryUpdateEd = sqlCommand.Parameters.Add("@LTINVENTORYUPDATEED", SqlDbType.Int);
                    SqlParameter paraSelWarehouseCode1 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE1", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode2 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE2", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode3 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE3", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode4 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE4", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode5 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE5", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode6 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE6", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode7 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE7", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode8 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE8", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode9 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE9", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode10 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE10", SqlDbType.NChar);
                    SqlParameter paraInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
                    SqlParameter paraMngSectionCodeSt = sqlCommand.Parameters.Add("@MNGSECTIONCODEST", SqlDbType.NChar);// ADD 2011/01/30
                    SqlParameter paraMngSectionCodeEd = sqlCommand.Parameters.Add("@MNGSECTIONCODEED", SqlDbType.NChar);// ADD 2011/01/30

                    #region 変更前(MA.NS)
                    /*
                    SqlParameter paraCreateDateTime      = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime      = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode      = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid      = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode     = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1      = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2      = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode   = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    SqlParameter paraSectionCode         = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraInventoryPreprDay   = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                    SqlParameter paraInventoryPreprTim   = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                    SqlParameter paraInventoryProcDiv    = sqlCommand.Parameters.Add("@INVENTORYPROCDIV", SqlDbType.Int);
                    SqlParameter paraGeneralGoodsExtDiv  = sqlCommand.Parameters.Add("@GENERALGOODSEXTDIV", SqlDbType.Int);
                    SqlParameter paraMobileGoodsExtDiv   = sqlCommand.Parameters.Add("@MOBILEGOODSEXTDIV", SqlDbType.Int);
                    SqlParameter paraAcsryGoodsExtDiv    = sqlCommand.Parameters.Add("@ACSRYGOODSEXTDIV", SqlDbType.Int);
                    SqlParameter paraStWarehouseCd       = sqlCommand.Parameters.Add("@WAREHOUSECODEST", SqlDbType.NChar);
                    SqlParameter paraEdWarehouseCd       = sqlCommand.Parameters.Add("@WAREHOUSECODEED", SqlDbType.NChar);
                    SqlParameter paraStMakerCd           = sqlCommand.Parameters.Add("@MAKERCODEST", SqlDbType.Int);
                    SqlParameter paraEdMakerCd           = sqlCommand.Parameters.Add("@MAKERCODEED", SqlDbType.Int);
                    SqlParameter paraStCarrierCd         = sqlCommand.Parameters.Add("@CARRIERCDST", SqlDbType.Int);
                    SqlParameter paraEdCarrierCd         = sqlCommand.Parameters.Add("@CARRIERCDED", SqlDbType.Int);
                    SqlParameter paraStLgGoodsGanreCd    = sqlCommand.Parameters.Add("@LGGOODSGANRECDST", SqlDbType.NChar);
                    SqlParameter paraEdLgGoodsGanreCd    = sqlCommand.Parameters.Add("@LGGOODSGANRECDED", SqlDbType.NChar);
                    SqlParameter paraStMdGoodsGanreCd    = sqlCommand.Parameters.Add("@MDGOODSGANRECDST", SqlDbType.NChar);
                    SqlParameter paraEdMdGoodsGanreCd    = sqlCommand.Parameters.Add("@MDGOODSGANRECDED", SqlDbType.NChar);
                    SqlParameter paraStCellphoneModelCd  = sqlCommand.Parameters.Add("@CELLPHONEMODELCDST", SqlDbType.NVarChar);
                    SqlParameter paraEdCellphoneModelCd  = sqlCommand.Parameters.Add("@CELLPHONEMODELCDED", SqlDbType.NVarChar);
                    SqlParameter paraStGoodsCd           = sqlCommand.Parameters.Add("@KTGOODSCDST", SqlDbType.NVarChar);
                    SqlParameter paraEdGoodsCd           = sqlCommand.Parameters.Add("@KTGOODSCDED", SqlDbType.NVarChar);
                    SqlParameter paraCmpStkExtraDiv      = sqlCommand.Parameters.Add("@CMPSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraTrtStkExtraDiv      = sqlCommand.Parameters.Add("@TRTSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraEntCmpStkExtraDiv   = sqlCommand.Parameters.Add("@ENTCMPSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraEntTrtStkExtraDiv   = sqlCommand.Parameters.Add("@ENTTRTSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraStLtInventoryUpdate = sqlCommand.Parameters.Add("@LTINVENTORYUPDATEST", SqlDbType.Int);
                    SqlParameter paraEdLtInventoryUpdate = sqlCommand.Parameters.Add("@LTINVENTORYUPDATEED", SqlDbType.Int);
                    */
                    #endregion  // 変更前(MA.NS)
                    #endregion

                    #region Parameterオブジェクトへ値設定
                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventDataPreWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventDataPreWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inventDataPreWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventDataPreWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventDataPreWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                    paraInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                    paraInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);
                    paraInventoryProcDiv.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryProcDiv);
                    paraWarehouseCodeSt.Value = SqlDataMediator.SqlSetString(inventDataPreWork.WarehouseCodeSt);
                    paraWarehouseCodeEd.Value = SqlDataMediator.SqlSetString(inventDataPreWork.WarehouseCodeEd);
                    paraShelfNoSt.Value = SqlDataMediator.SqlSetString(inventDataPreWork.ShelfNoSt);
                    paraShelfNoEd.Value = SqlDataMediator.SqlSetString(inventDataPreWork.ShelfNoEd);
                    paraStartSupplierCode.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.StartSupplierCode);
                    paraEndSupplierCode.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.EndSupplierCode);
                    paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGoodsCodeSt);
                    paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGoodsCodeEd);
                    paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.GoodsMakerCdSt);
                    paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.GoodsMakerCdEd);
                    // 修正 2009/05/15 >>>
                    //paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGoodsCodeSt);
                    //paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGoodsCodeEd);
                    paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGroupCodeSt);
                    paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGroupCodeEd);
                    // 修正 2009/05/15 <<<
                    paraTrtStkExtraDiv.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.TrtStkExtraDiv);
                    paraEntCmpStkExtraDiv.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.EntCmpStkExtraDiv);
                    paraLtInventoryUpdateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.LtInventoryUpdateSt);
                    paraLtInventoryUpdateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.LtInventoryUpdateEd);
                    paraSelWarehouseCode1.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode1);
                    paraSelWarehouseCode2.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode2);
                    paraSelWarehouseCode3.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode3);
                    paraSelWarehouseCode4.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode4);
                    paraSelWarehouseCode5.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode5);
                    paraSelWarehouseCode6.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode6);
                    paraSelWarehouseCode7.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode7);
                    paraSelWarehouseCode8.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode8);
                    paraSelWarehouseCode9.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode9);
                    paraSelWarehouseCode10.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode10);
                    paraInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryDate);
                    paraMngSectionCodeSt.Value = SqlDataMediator.SqlSetString(inventDataPreWork.MngSectionCodeSt);// ADD 2011/01/30
                    paraMngSectionCodeEd.Value = SqlDataMediator.SqlSetString(inventDataPreWork.MngSectionCodeEd);// ADD 2011/01/30
                    #region  変更前(MA.NS)
                    /*
                    paraCreateDateTime.Value      = SqlDataMediator.SqlSetDateTimeFromTicks(inventDataPreWork.CreateDateTime);
                    paraUpdateDateTime.Value      = SqlDataMediator.SqlSetDateTimeFromTicks(inventDataPreWork.UpdateDateTime);
                    paraEnterpriseCode.Value      = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                    paraFileHeaderGuid.Value      = SqlDataMediator.SqlSetGuid(inventDataPreWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value     = SqlDataMediator.SqlSetString(inventDataPreWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value      = SqlDataMediator.SqlSetString(inventDataPreWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value      = SqlDataMediator.SqlSetString(inventDataPreWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.LogicalDeleteCode);

                    paraSectionCode.Value         = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                    paraInventoryPreprDay.Value   = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                    paraInventoryPreprTim.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);
                    paraInventoryProcDiv.Value    = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryProcDiv);
                    paraGeneralGoodsExtDiv.Value  = SqlDataMediator.SqlSetInt32(inventDataPreWork.GeneralGoodsExtDiv);
                    paraMobileGoodsExtDiv.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.MobileGoodsExtDiv);
                    paraAcsryGoodsExtDiv.Value    = SqlDataMediator.SqlSetInt32(inventDataPreWork.AcsryGoodsExtDiv);
                    paraStWarehouseCd.Value       = SqlDataMediator.SqlSetString(inventDataPreWork.WarehouseCodeSt);
                    paraEdWarehouseCd.Value       = SqlDataMediator.SqlSetString(inventDataPreWork.WarehouseCodeEd);
                    paraStCarrierCd.Value         = SqlDataMediator.SqlSetInt32(inventDataPreWork.CarrierCdSt);
                    paraEdCarrierCd.Value         = SqlDataMediator.SqlSetInt32(inventDataPreWork.CarrierCdEd);
                    paraStMakerCd.Value           = SqlDataMediator.SqlSetInt32(inventDataPreWork.MakerCodeSt);
                    paraEdMakerCd.Value           = SqlDataMediator.SqlSetInt32(inventDataPreWork.MakerCodeEd);
                    paraStLgGoodsGanreCd.Value    = SqlDataMediator.SqlSetString(inventDataPreWork.LgGoodsGanreCdSt);
                    paraEdLgGoodsGanreCd.Value    = SqlDataMediator.SqlSetString(inventDataPreWork.LgGoodsGanreCdEd);
                    paraStMdGoodsGanreCd.Value    = SqlDataMediator.SqlSetString(inventDataPreWork.MdGoodsGanreCdSt);
                    paraEdMdGoodsGanreCd.Value    = SqlDataMediator.SqlSetString(inventDataPreWork.MdGoodsGanreCdEd);
                    paraStCellphoneModelCd.Value  = SqlDataMediator.SqlSetString(inventDataPreWork.CellphoneModelCdSt);
                    paraEdCellphoneModelCd.Value  = SqlDataMediator.SqlSetString(inventDataPreWork.CellphoneModelCdEd);
                    paraStGoodsCd.Value           = SqlDataMediator.SqlSetString(inventDataPreWork.KtGoodsCdSt);
                    paraEdGoodsCd.Value           = SqlDataMediator.SqlSetString(inventDataPreWork.KtGoodsCdEd);
                    paraCmpStkExtraDiv.Value      = SqlDataMediator.SqlSetInt32(inventDataPreWork.CmpStkExtraDiv);
                    paraTrtStkExtraDiv.Value      = SqlDataMediator.SqlSetInt32(inventDataPreWork.TrtStkExtraDiv);
                    paraEntCmpStkExtraDiv.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.EntCmpStkExtraDiv);
                    paraEntTrtStkExtraDiv.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.EntTrtStkExtraDiv);
                    paraStLtInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.LtInventoryUpdateSt);
                    paraEdLtInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.LtInventoryUpdateEd);
                    */
                    #endregion    // 変更前(MA.NS)

                    #endregion    // Parameterオブジェクトへ値設定
                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.WriteInventDataPre:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            if (!myReader.IsClosed) myReader.Close();
            return status;
        }
        #endregion  // 棚卸データ（準備処理履歴）登録処理
        //#endregion  // SearchWrite

        #region Write　＊棚卸データ（準備処理履歴）
        /// <summary>
        /// 棚卸データ（準備処理履歴）を登録、更新します
        /// </summary>
        /// <param name="parabyte">InventoryExtCndtnWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データ（準備処理履歴）を登録、更新します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        public int Write(ref byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // XMLの読み込み
                InventDataPreWork inventDataPreWork = (InventDataPreWork)XmlByteSerializer.Deserialize(parabyte, typeof(InventDataPreWork));

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                int st = WriteProc(ref inventDataPreWork, ref sqlConnection);

                if (st == 0)
                {
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
                base.WriteErrorLog(ex, "InventoryExtDB.Write:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            sqlConnection.Close();

            return status;
        }

        #region WriteProc
        /// <summary>
        /// 棚卸準備処理履歴情報を登録、更新します
        /// </summary>
        /// <param name="inventDataPreWork">InventDataPreWorkオブジェクト</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸準備処理履歴情報を登録、更新します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        private int WriteProc(ref InventDataPreWork inventDataPreWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM INVENTDATAPRERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYPREPRDAYRF=@FINDINVENTORYPREPRDAY AND INVENTORYPREPRTIMRF=@FINDINVENTORYPREPRTIM ", sqlConnection))
                {
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaInventoryPreprDay = sqlCommand.Parameters.Add("@FINDINVENTORYPREPRDAY", SqlDbType.Int);
                    SqlParameter findParaInventoryPreprTim = sqlCommand.Parameters.Add("@FINDINVENTORYPREPRTIM", SqlDbType.Int);

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                    findParaInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                    findParaInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != inventDataPreWork.UpdateDateTime)
                        {
                            //新規登録で該当データ有りの場合には重複
                            if (inventDataPreWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //既存データで更新日時違いの場合には排他
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            if (!myReader.IsClosed) myReader.Close();
                            return status;
                        }

                        sqlCommand.CommandText = "UPDATE INVENTDATAPRERF SET UPDATEDATETIMERF=@UPDATEDATETIME , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , INVENTORYPREPRDAYRF=@INVENTORYPREPRDAY , INVENTORYPREPRTIMRF=@INVENTORYPREPRTIM , INVENTORYPROCDIVRF=@INVENTORYPROCDIV , WAREHOUSECODESTRF=@WAREHOUSECODEST , WAREHOUSECODEEDRF=@WAREHOUSECODEED , SHELFNOSTRF=@SHELFNOST , SHELFNOEDRF=@SHELFNOED , STARTSUPPLIERCODERF=@STARTSUPPLIERCODE , ENDSUPPLIERCODERF=@ENDSUPPLIERCODE , BLGOODSCODESTRF=@BLGOODSCODEST , BLGOODSCODEEDRF=@BLGOODSCODEED , GOODSMAKERCDSTRF=@GOODSMAKERCDST , GOODSMAKERCDEDRF=@GOODSMAKERCDED , BLGROUPCODESTRF=@BLGROUPCODEST , BLGROUPCODEEDRF=@BLGROUPCODEED , TRTSTKEXTRADIVRF=@TRTSTKEXTRADIV , ENTCMPSTKEXTRADIVRF=@ENTCMPSTKEXTRADIV , LTINVENTORYUPDATESTRF=@LTINVENTORYUPDATEST , LTINVENTORYUPDATEEDRF=@LTINVENTORYUPDATEED , SELWAREHOUSECODE1RF=@SELWAREHOUSECODE1 , SELWAREHOUSECODE2RF=@SELWAREHOUSECODE2 , SELWAREHOUSECODE3RF=@SELWAREHOUSECODE3 , SELWAREHOUSECODE4RF=@SELWAREHOUSECODE4 , SELWAREHOUSECODE5RF=@SELWAREHOUSECODE5 , SELWAREHOUSECODE6RF=@SELWAREHOUSECODE6 , SELWAREHOUSECODE7RF=@SELWAREHOUSECODE7 , SELWAREHOUSECODE8RF=@SELWAREHOUSECODE8 , SELWAREHOUSECODE9RF=@SELWAREHOUSECODE9 , SELWAREHOUSECODE10RF=@SELWAREHOUSECODE10 , INVENTORYDATERF=@INVENTORYDATE "
                        + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYPREPRDAYRF=@FINDINVENTORYPREPRDAY AND INVENTORYPREPRTIMRF=@FINDINVENTORYPREPRTIM ";

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                        findParaInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                        findParaInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)inventDataPreWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //新規作成時のSQL文を生成
                        sqlCommand.CommandText = "INSERT INTO INVENTDATAPRERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, INVENTORYPREPRDAYRF, INVENTORYPREPRTIMRF, INVENTORYPROCDIVRF, WAREHOUSECODESTRF, WAREHOUSECODEEDRF, SHELFNOSTRF, SHELFNOEDRF, STARTSUPPLIERCODERF, ENDSUPPLIERCODERF, BLGOODSCODESTRF, BLGOODSCODEEDRF, GOODSMAKERCDSTRF, GOODSMAKERCDEDRF, BLGROUPCODESTRF, BLGROUPCODEEDRF, TRTSTKEXTRADIVRF, ENTCMPSTKEXTRADIVRF, LTINVENTORYUPDATESTRF, LTINVENTORYUPDATEEDRF, SELWAREHOUSECODE1RF, SELWAREHOUSECODE2RF, SELWAREHOUSECODE3RF, SELWAREHOUSECODE4RF, SELWAREHOUSECODE5RF, SELWAREHOUSECODE6RF, SELWAREHOUSECODE7RF, SELWAREHOUSECODE8RF, SELWAREHOUSECODE9RF, SELWAREHOUSECODE10RF, INVENTORYDATERF) "
                            + "VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @INVENTORYPREPRDAY, @INVENTORYPREPRTIM, @INVENTORYPROCDIV, @WAREHOUSECODEST, @WAREHOUSECODEED, @SHELFNOST, @SHELFNOED, @STARTSUPPLIERCODE, @ENDSUPPLIERCODE, @BLGOODSCODEST, @BLGOODSCODEED, @GOODSMAKERCDST, @GOODSMAKERCDED, @BLGROUPCODEST, @BLGROUPCODEED, @TRTSTKEXTRADIV, @ENTCMPSTKEXTRADIV, @LTINVENTORYUPDATEST, @LTINVENTORYUPDATEED, @SELWAREHOUSECODE1, @SELWAREHOUSECODE2, @SELWAREHOUSECODE3, @SELWAREHOUSECODE4, @SELWAREHOUSECODE5, @SELWAREHOUSECODE6, @SELWAREHOUSECODE7, @SELWAREHOUSECODE8, @SELWAREHOUSECODE9, @SELWAREHOUSECODE10, @INVENTORYDATE) ";

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)inventDataPreWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    if (!myReader.IsClosed) myReader.Close();

                    #region Parameterオブジェクトの作成
                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraInventoryPreprDay = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                    SqlParameter paraInventoryPreprTim = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                    SqlParameter paraInventoryProcDiv = sqlCommand.Parameters.Add("@INVENTORYPROCDIV", SqlDbType.Int);
                    SqlParameter paraWarehouseCodeSt = sqlCommand.Parameters.Add("@WAREHOUSECODEST", SqlDbType.NChar);
                    SqlParameter paraWarehouseCodeEd = sqlCommand.Parameters.Add("@WAREHOUSECODEED", SqlDbType.NChar);
                    SqlParameter paraShelfNoSt = sqlCommand.Parameters.Add("@SHELFNOST", SqlDbType.NVarChar);
                    SqlParameter paraShelfNoEd = sqlCommand.Parameters.Add("@SHELFNOED", SqlDbType.NVarChar);
                    SqlParameter paraStartSupplierCode = sqlCommand.Parameters.Add("@STARTSUPPLIERCODE", SqlDbType.Int);
                    SqlParameter paraEndSupplierCode = sqlCommand.Parameters.Add("@ENDSUPPLIERCODE", SqlDbType.Int);
                    SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@BLGOODSCODEST", SqlDbType.Int);
                    SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@BLGOODSCODEED", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                    SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@BLGROUPCODEST", SqlDbType.Int);
                    SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@BLGROUPCODEED", SqlDbType.Int);
                    SqlParameter paraTrtStkExtraDiv = sqlCommand.Parameters.Add("@TRTSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraEntCmpStkExtraDiv = sqlCommand.Parameters.Add("@ENTCMPSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraLtInventoryUpdateSt = sqlCommand.Parameters.Add("@LTINVENTORYUPDATEST", SqlDbType.Int);
                    SqlParameter paraLtInventoryUpdateEd = sqlCommand.Parameters.Add("@LTINVENTORYUPDATEED", SqlDbType.Int);
                    SqlParameter paraSelWarehouseCode1 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE1", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode2 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE2", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode3 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE3", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode4 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE4", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode5 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE5", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode6 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE6", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode7 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE7", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode8 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE8", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode9 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE9", SqlDbType.NChar);
                    SqlParameter paraSelWarehouseCode10 = sqlCommand.Parameters.Add("@SELWAREHOUSECODE10", SqlDbType.NChar);
                    // 2007.03.07 Add >>>>>>>>
                    SqlParameter paraInventoryDate = sqlCommand.Parameters.Add("@INVENTORYDATE", SqlDbType.Int);
                    // 2007.03.07 Add <<<<<<<<

                    #region  変更前(MA.NS)
                    /*
                    SqlParameter paraCreateDateTime      = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime      = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode      = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid      = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode     = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1      = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2      = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode   = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    SqlParameter paraSectionCode         = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraInventoryPreprDay   = sqlCommand.Parameters.Add("@INVENTORYPREPRDAY", SqlDbType.Int);
                    SqlParameter paraInventoryPreprTim   = sqlCommand.Parameters.Add("@INVENTORYPREPRTIM", SqlDbType.Int);
                    SqlParameter paraInventoryProcDiv    = sqlCommand.Parameters.Add("@INVENTORYPROCDIV", SqlDbType.Int);
                    SqlParameter paraGeneralGoodsExtDiv  = sqlCommand.Parameters.Add("@GENERALGOODSEXTDIV", SqlDbType.Int);
                    SqlParameter paraMobileGoodsExtDiv   = sqlCommand.Parameters.Add("@MOBILEGOODSEXTDIV", SqlDbType.Int);
                    SqlParameter paraAcsryGoodsExtDiv    = sqlCommand.Parameters.Add("@ACSRYGOODSEXTDIV", SqlDbType.Int);
                    SqlParameter paraStWarehouseCd       = sqlCommand.Parameters.Add("@WAREHOUSECODEST", SqlDbType.NChar);
                    SqlParameter paraEdWarehouseCd       = sqlCommand.Parameters.Add("@WAREHOUSECODEED", SqlDbType.NChar);
                    SqlParameter paraStMakerCd           = sqlCommand.Parameters.Add("@MAKERCODEST", SqlDbType.Int);
                    SqlParameter paraEdMakerCd           = sqlCommand.Parameters.Add("@MAKERCODEED", SqlDbType.Int);
                    SqlParameter paraStCarrierCd         = sqlCommand.Parameters.Add("@CARRIERCDST", SqlDbType.Int);
                    SqlParameter paraEdCarrierCd         = sqlCommand.Parameters.Add("@CARRIERCDED", SqlDbType.Int);
                    SqlParameter paraStLgGoodsGanreCd    = sqlCommand.Parameters.Add("@LGGOODSGANRECDST", SqlDbType.NChar);
                    SqlParameter paraEdLgGoodsGanreCd    = sqlCommand.Parameters.Add("@LGGOODSGANRECDED", SqlDbType.NChar);
                    SqlParameter paraStMdGoodsGanreCd    = sqlCommand.Parameters.Add("@MDGOODSGANRECDST", SqlDbType.NChar);
                    SqlParameter paraEdMdGoodsGanreCd    = sqlCommand.Parameters.Add("@MDGOODSGANRECDED", SqlDbType.NChar);
                    SqlParameter paraStCellphoneModelCd  = sqlCommand.Parameters.Add("@CELLPHONEMODELCDST", SqlDbType.NVarChar);
                    SqlParameter paraEdCellphoneModelCd  = sqlCommand.Parameters.Add("@CELLPHONEMODELCDED", SqlDbType.NVarChar);
                    SqlParameter paraStGoodsCd           = sqlCommand.Parameters.Add("@KTGOODSCDST", SqlDbType.NVarChar);
                    SqlParameter paraEdGoodsCd           = sqlCommand.Parameters.Add("@KTGOODSCDED", SqlDbType.NVarChar);
                    SqlParameter paraCmpStkExtraDiv      = sqlCommand.Parameters.Add("@CMPSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraTrtStkExtraDiv      = sqlCommand.Parameters.Add("@TRTSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraEntCmpStkExtraDiv   = sqlCommand.Parameters.Add("@ENTCMPSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraEntTrtStkExtraDiv   = sqlCommand.Parameters.Add("@ENTTRTSTKEXTRADIV", SqlDbType.Int);
                    SqlParameter paraStLtInventoryUpdate = sqlCommand.Parameters.Add("@LTINVENTORYUPDATEST", SqlDbType.Int);
                    SqlParameter paraEdLtInventoryUpdate = sqlCommand.Parameters.Add("@LTINVENTORYUPDATEED", SqlDbType.Int);
                    */
                    #endregion    // 変更前(MA.NS)
                    #endregion    // Parameterオブジェクトの作成

                    #region Parameterオブジェクトへ値設定
                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventDataPreWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inventDataPreWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inventDataPreWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inventDataPreWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inventDataPreWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                    paraInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                    paraInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);
                    paraInventoryProcDiv.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryProcDiv);
                    paraWarehouseCodeSt.Value = SqlDataMediator.SqlSetString(inventDataPreWork.WarehouseCodeSt);
                    paraWarehouseCodeEd.Value = SqlDataMediator.SqlSetString(inventDataPreWork.WarehouseCodeEd);
                    paraShelfNoSt.Value = SqlDataMediator.SqlSetString(inventDataPreWork.ShelfNoSt);
                    paraShelfNoEd.Value = SqlDataMediator.SqlSetString(inventDataPreWork.ShelfNoEd);
                    paraStartSupplierCode.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.StartSupplierCode);
                    paraEndSupplierCode.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.EndSupplierCode);
                    paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGoodsCodeSt);
                    paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGoodsCodeEd);
                    paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.GoodsMakerCdSt);
                    paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.GoodsMakerCdEd);
                    paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGroupCodeSt);
                    paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.BLGroupCodeEd);
                    paraTrtStkExtraDiv.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.TrtStkExtraDiv);
                    paraEntCmpStkExtraDiv.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.EntCmpStkExtraDiv);
                    paraLtInventoryUpdateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.LtInventoryUpdateSt);
                    paraLtInventoryUpdateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.LtInventoryUpdateEd);
                    paraSelWarehouseCode1.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode1);
                    paraSelWarehouseCode2.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode2);
                    paraSelWarehouseCode3.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode3);
                    paraSelWarehouseCode4.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode4);
                    paraSelWarehouseCode5.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode5);
                    paraSelWarehouseCode6.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode6);
                    paraSelWarehouseCode7.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode7);
                    paraSelWarehouseCode8.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode8);
                    paraSelWarehouseCode9.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode9);
                    paraSelWarehouseCode10.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SelWarehouseCode10);
                    // 2008.03.07 Add >>>>>>>>
                    paraInventoryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryDate);
                    // 2008.03.07 Add <<<<<<<<

                    #region  変更前(MA.NS)
                    /*
                    paraCreateDateTime.Value      = SqlDataMediator.SqlSetDateTimeFromTicks(inventDataPreWork.CreateDateTime);
                    paraUpdateDateTime.Value      = SqlDataMediator.SqlSetDateTimeFromTicks(inventDataPreWork.UpdateDateTime);
                    paraEnterpriseCode.Value      = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                    paraFileHeaderGuid.Value      = SqlDataMediator.SqlSetGuid(inventDataPreWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value     = SqlDataMediator.SqlSetString(inventDataPreWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value      = SqlDataMediator.SqlSetString(inventDataPreWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value      = SqlDataMediator.SqlSetString(inventDataPreWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.LogicalDeleteCode);

                    paraSectionCode.Value         = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                    paraInventoryPreprDay.Value   = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                    paraInventoryPreprTim.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);
                    paraInventoryProcDiv.Value    = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryProcDiv);
                    paraGeneralGoodsExtDiv.Value  = SqlDataMediator.SqlSetInt32(inventDataPreWork.GeneralGoodsExtDiv);
                    paraMobileGoodsExtDiv.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.MobileGoodsExtDiv);
                    paraAcsryGoodsExtDiv.Value    = SqlDataMediator.SqlSetInt32(inventDataPreWork.AcsryGoodsExtDiv);
                    paraStWarehouseCd.Value       = SqlDataMediator.SqlSetString(inventDataPreWork.WarehouseCodeSt);
                    paraEdWarehouseCd.Value       = SqlDataMediator.SqlSetString(inventDataPreWork.WarehouseCodeEd);
                    paraStCarrierCd.Value         = SqlDataMediator.SqlSetInt32(inventDataPreWork.CarrierCdSt);
                    paraEdCarrierCd.Value         = SqlDataMediator.SqlSetInt32(inventDataPreWork.CarrierCdEd);
                    paraStMakerCd.Value           = SqlDataMediator.SqlSetInt32(inventDataPreWork.MakerCodeSt);
                    paraEdMakerCd.Value           = SqlDataMediator.SqlSetInt32(inventDataPreWork.MakerCodeEd);
                    paraStLgGoodsGanreCd.Value    = SqlDataMediator.SqlSetString(inventDataPreWork.LgGoodsGanreCdSt);
                    paraEdLgGoodsGanreCd.Value    = SqlDataMediator.SqlSetString(inventDataPreWork.LgGoodsGanreCdEd);
                    paraStMdGoodsGanreCd.Value    = SqlDataMediator.SqlSetString(inventDataPreWork.MdGoodsGanreCdSt);
                    paraEdMdGoodsGanreCd.Value    = SqlDataMediator.SqlSetString(inventDataPreWork.MdGoodsGanreCdEd);
                    paraStCellphoneModelCd.Value  = SqlDataMediator.SqlSetString(inventDataPreWork.CellphoneModelCdSt);
                    paraEdCellphoneModelCd.Value  = SqlDataMediator.SqlSetString(inventDataPreWork.CellphoneModelCdEd);
                    paraStGoodsCd.Value           = SqlDataMediator.SqlSetString(inventDataPreWork.KtGoodsCdSt);
                    paraEdGoodsCd.Value           = SqlDataMediator.SqlSetString(inventDataPreWork.KtGoodsCdEd);
                    paraCmpStkExtraDiv.Value      = SqlDataMediator.SqlSetInt32(inventDataPreWork.CmpStkExtraDiv);
                    paraTrtStkExtraDiv.Value      = SqlDataMediator.SqlSetInt32(inventDataPreWork.TrtStkExtraDiv);
                    paraEntCmpStkExtraDiv.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.EntCmpStkExtraDiv);
                    paraEntTrtStkExtraDiv.Value   = SqlDataMediator.SqlSetInt32(inventDataPreWork.EntTrtStkExtraDiv);
                    paraStLtInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.LtInventoryUpdateSt);
                    paraEdLtInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.LtInventoryUpdateEd);
                    */
                    #endregion    // 変更前(MA.NS)
                    #endregion    // Parameterオブジェクトへ値設定


                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.WriteProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            if (!myReader.IsClosed) myReader.Close();
            return status;
        }
        #endregion  // WriteProc
        #endregion  // Write　＊棚卸データ（準備処理履歴）

        #region Delete　＊棚卸データ（準備処理履歴）
        /// <summary>
        /// 棚卸データ（準備処理履歴）を物理削除します
        /// </summary>
        /// <param name="parabyte">棚卸準備処理オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データ（準備処理履歴）を物理削除します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        public int Delete(byte[] parabyte)
        {
            return this.DeleteProc(parabyte);
        }

        /// <summary>
        /// 棚卸データ（準備処理履歴）を物理削除します
        /// </summary>
        /// <param name="parabyte">棚卸準備処理オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データ（準備処理履歴）を物理削除します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        private int DeleteProc(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // XMLの読み込み
                InventDataPreWork inventDataPreWork = (InventDataPreWork)XmlByteSerializer.Deserialize(parabyte, typeof(InventDataPreWork));

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM INVENTDATAPRERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYPREPRDAYRF=@FINDINVENTORYPREPRDAY AND INVENTORYPREPRTIMRF=@FINDINVENTORYPREPRTIM ", sqlConnection))
                {
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaInventoryPreprDay = sqlCommand.Parameters.Add("@FINDINVENTORYPREPRDAY", SqlDbType.Int);
                    SqlParameter findParaInventoryPreprTim = sqlCommand.Parameters.Add("@FINDINVENTORYPREPRTIM", SqlDbType.Int);

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                    findParaInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                    findParaInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UpdateDateTimeRF"));//更新日時
                        if (_updateDateTime != inventDataPreWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM INVENTDATAPRERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND INVENTORYPREPRDAYRF=@FINDINVENTORYPREPRDAY AND INVENTORYPREPRTIMRF=@FINDINVENTORYPREPRTIM ";
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inventDataPreWork.SectionCode);
                        findParaInventoryPreprDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(inventDataPreWork.InventoryPreprDay);
                        findParaInventoryPreprTim.Value = SqlDataMediator.SqlSetInt32(inventDataPreWork.InventoryPreprTim);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
                        sqlConnection.Close();
                        return status;
                    }
                    if (!myReader.IsClosed) myReader.Close();

                    sqlCommand.ExecuteNonQuery();

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
                base.WriteErrorLog(ex, "InventoryExtDB.Delete:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (!myReader.IsClosed) myReader.Close();
            sqlConnection.Close();

            return status;
        }
        #endregion  // Delete　＊棚卸データ（準備処理履歴）

        #region DeleteInvent　＊棚卸データ
        /// <summary>
        /// 棚卸データを物理削除します
        /// </summary>
        /// <param name="parabyte">棚卸データオブジェクト</param>
        /// <param name="inventoryDataWork">棚卸データ（準備処理履歴）オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データを物理削除します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        public int DeleteInvent(byte[] parabyte, out byte[] retbyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTrans = null;
            retbyte = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // XMLの読み込み
                InventoryDataWork inventoryDataWork = (InventoryDataWork)XmlByteSerializer.Deserialize(parabyte, typeof(InventoryDataWork));

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                sqlTrans = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                object paraobj = inventoryDataWork;
                object retobj = null;

                status = SearchInventoryData(out retobj, paraobj, ConstantManagement.LogicalMode.GetData0);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<<
                //棚卸データ削除処理
                status = DeleteInventProc(inventoryDataWork, out retbyte, ref sqlConnection, ref sqlTrans);


            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.DeleteInvent:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (status == 0)
                {
                    sqlTrans.Commit();
                }
                else
                {
                    sqlTrans.Rollback();
                }
                sqlConnection.Close();
                sqlTrans.Dispose();
            }
            return status;
        }

        #region DeleteInventProc
        /// <summary>
        /// 棚卸データを物理削除します
        /// </summary>
        /// <param name="inventoryDataWork">棚卸データオブジェクト</param>
        /// <param name="inventoryDataWork">棚卸データ（準備処理履歴）オブジェクト</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸準備処理情報を物理削除します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.04.04</br>
        /// <br>Update Note: 2012/06/08 yangyi</br>
        /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#30282 №1002 棚卸準備処理の改良の対応</br>
        private int DeleteInventProc(InventoryDataWork inventoryDataWork, out byte[] retbyte, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));
            retbyte = null;

            try
            {
                // 修正 2008/09/18 // 自拠点で全拠点分の棚卸を実行できる仕様に変更するため、拠点コードの指定を削除(企業コードのみ指定する)  >>>
                // using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE ", sqlConnection, sqlTrans))
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM INVENTORYDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection, sqlTrans))
                // 修正 2008/09/18 <<<
                {
                    //KEYコマンドを再設定
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaSectionCode    = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // DEL 2008/09/18 <<<

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.EnterpriseCode);
                    //findParaSectionCode.Value    = SqlDataMediator.SqlSetString(inventoryDataWork.SectionCode); // DEL 2008/09/18 <<<
                    // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                    //管理拠点開始
                    if (inventoryDataWork.SectionCodeSt != "")
                    {
                        sqlCommand.CommandText += " AND SECTIONCODERF>=@STSECTIONCODE ";
                        SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@STSECTIONCODE", SqlDbType.NChar);
                        paraStSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.SectionCodeSt);
                    }
                    //管理拠点終了
                    if (inventoryDataWork.SectionCodeEd != "")
                    {
                        sqlCommand.CommandText += "AND SECTIONCODERF<=@EDSECTIONCODE ";
                        SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@EDSECTIONCODE", SqlDbType.NChar);
                        paraEdSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.SectionCodeEd);
                    }
                    // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    #region 棚卸データ（準備処理履歴）登録処理
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //棚卸データ（準備処理履歴）登録処理
                        #region 値セット
                        InventDataPreWork inventDataPreWork = new InventDataPreWork();
                        inventDataPreWork.EnterpriseCode = inventoryDataWork.EnterpriseCode;
                        inventDataPreWork.SectionCode = inventoryDataWork.SectionCode;
                        inventDataPreWork.InventoryProcDiv = 3;
                        inventDataPreWork.InventoryPreprDay = Broadleaf.Library.Globarization.TDateTime.LongDateToDateTime(SysDate);
                        inventDataPreWork.InventoryPreprTim = SysTime;
                        // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                        inventDataPreWork.MngSectionCodeSt = inventoryDataWork.SectionCodeSt;
                        inventDataPreWork.MngSectionCodeEd = inventoryDataWork.SectionCodeEd;
                        // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<
                        #endregion
                        status = WriteInventDataPre(ref inventDataPreWork, ref sqlConnection, ref sqlTrans);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            retbyte = XmlByteSerializer.Serialize(inventDataPreWork);
                        }
                    }
                    #endregion
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.DeleteInventProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion  // DeleteInventProc
        #endregion  // DeleteInvent　＊棚卸データ

        #region MakeWhereString
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="inventoryExtCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="selectMode">0:棚卸データ（準備処理履歴）マスタ, 1:製番在庫マスタ, 2:棚卸データ, 3:削除用</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, InventoryExtCndtnWork inventoryExtCndtnWork, ConstantManagement.LogicalMode logicalMode, int selectMode)
        {
            string retstring = " WHERE ";

            string tblDM = "";
            if (selectMode == 0) tblDM = "IDP.";   // 棚卸データ（準備処理履歴）マスタ
            //#if (selectMode == 1) tblDM = "PDS.";   // 製番在庫マスタ
            if (selectMode == 1) tblDM = "STK.";   // 在庫マスタ
            if (selectMode == 2) tblDM = "IVD.";   // 棚卸データ
            if (selectMode == 3) tblDM = "";       // 削除用マスタ

            //企業コード
            retstring += tblDM + "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EnterpriseCode);


            //論理削除
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND " + tblDM + "LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND " + tblDM + "LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            // 修正 2008/09/18 自拠点で全拠点分の棚卸データを作成できる仕様に変更するため、棚卸履歴の抽出時のみ拠点コードの参照をする >>>
            ////拠点コード
            //if ((inventoryExtCndtnWork.SectionCode != "") && (inventoryExtCndtnWork.SectionCode != null))
            //{
            //    retstring += " AND " + tblDM + "SECTIONCODERF=@SECTIONCODE ";
            //    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            //    paraSectionCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCode);
            //}       
            if (selectMode == 0)
            {
                // --- DEL 2009/11/30 ---------->>>>>
                ////拠点コード
                //if ((inventoryExtCndtnWork.SectionCode != "") && (inventoryExtCndtnWork.SectionCode != null))
                //{
                //    retstring += " AND " + tblDM + "SECTIONCODERF=@SECTIONCODE ";
                //    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                //    paraSectionCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCode);
                //}
                // --- DEL 2009/11/30 ----------<<<<<
            }
            // 修正 2008/09/18 <<<
            /*
            if (selectMode == 2)
            {
                //棚卸更新日が初期値以外を除く
                int ymdInventoryUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", DateTime.MinValue);
                retstring +=  " AND (IVD.LASTINVENTORYUPDATERF=" + ymdInventoryUpDate.ToString() + " OR IVD.LASTINVENTORYUPDATERF IS NULL)";
            }
            */

            if (selectMode != 0)
            {
                //倉庫コード開始
                if (inventoryExtCndtnWork.StWarehouseCd != "")
                {
                    retstring += " AND " + tblDM + "WAREHOUSECODERF>=@STWAREHOUSECODE ";
                    SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NVarChar);
                    paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseCd);
                }
                //倉庫コード終了
                if (inventoryExtCndtnWork.EdWarehouseCd != "")
                {
                    retstring += "AND ( " + tblDM + "WAREHOUSECODERF<=@EDWAREHOUSECODE OR " + tblDM + "WAREHOUSECODERF LIKE @EDWAREHOUSECODE ) ";
                    SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NVarChar);
                    paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseCd + "%");
                }

                #region 単独倉庫指定
                // --- UPD 2010/02/20 ---------->>>>>
                ////倉庫コード01設定
                //if (inventoryExtCndtnWork.WarehouseCd01 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD01";
                //    SqlParameter paraWarehouseCd01 = sqlCommand.Parameters.Add("@WAREHOUSECD01", SqlDbType.NVarChar);
                //    paraWarehouseCd01.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd01);
                //}
                ////倉庫コード02設定
                //if (inventoryExtCndtnWork.WarehouseCd02 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD02";
                //    SqlParameter paraWarehouseCd02 = sqlCommand.Parameters.Add("@WAREHOUSECD02", SqlDbType.NVarChar);
                //    paraWarehouseCd02.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd02);
                //}
                ////倉庫コード03設定
                //if (inventoryExtCndtnWork.WarehouseCd03 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD03";
                //    SqlParameter paraWarehouseCd03 = sqlCommand.Parameters.Add("@WAREHOUSECD03", SqlDbType.NVarChar);
                //    paraWarehouseCd03.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd03);
                //}
                ////倉庫コード04設定
                //if (inventoryExtCndtnWork.WarehouseCd04 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD04";
                //    SqlParameter paraWarehouseCd04 = sqlCommand.Parameters.Add("@WAREHOUSECD04", SqlDbType.NVarChar);
                //    paraWarehouseCd04.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd04);
                //}
                ////倉庫コード05設定
                //if (inventoryExtCndtnWork.WarehouseCd05 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD05";
                //    SqlParameter paraWarehouseCd05 = sqlCommand.Parameters.Add("@WAREHOUSECD05", SqlDbType.NVarChar);
                //    paraWarehouseCd05.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd05);
                //}
                ////倉庫コード06設定
                //if (inventoryExtCndtnWork.WarehouseCd06 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD06";
                //    SqlParameter paraWarehouseCd06 = sqlCommand.Parameters.Add("@WAREHOUSECD06", SqlDbType.NVarChar);
                //    paraWarehouseCd06.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd06);
                //}
                ////倉庫コード07設定
                //if (inventoryExtCndtnWork.WarehouseCd07 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD07";
                //    SqlParameter paraWarehouseCd07 = sqlCommand.Parameters.Add("@WAREHOUSECD07", SqlDbType.NVarChar);
                //    paraWarehouseCd07.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd07);
                //}
                ////倉庫コード08設定
                //if (inventoryExtCndtnWork.WarehouseCd08 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD08";
                //    SqlParameter paraWarehouseCd08 = sqlCommand.Parameters.Add("@WAREHOUSECD08", SqlDbType.NVarChar);
                //    paraWarehouseCd08.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd08);
                //}
                ////倉庫コード09設定
                //if (inventoryExtCndtnWork.WarehouseCd09 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD09";
                //    SqlParameter paraWarehouseCd09 = sqlCommand.Parameters.Add("@WAREHOUSECD09", SqlDbType.NVarChar);
                //    paraWarehouseCd09.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd09);
                //}
                ////倉庫コード10設定
                //if (inventoryExtCndtnWork.WarehouseCd10 != "")
                //{
                //    retstring += " AND " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD10";
                //    SqlParameter paraWarehouseCd10 = sqlCommand.Parameters.Add("@WAREHOUSECD10", SqlDbType.NVarChar);
                //    paraWarehouseCd10.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.WarehouseCd10);
                //}

                Dictionary<string, string> wareList = new Dictionary<string, string>();
                if (inventoryExtCndtnWork.WarehouseCd01 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd01)) wareList.Add(inventoryExtCndtnWork.WarehouseCd01, "");
                if (inventoryExtCndtnWork.WarehouseCd02 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd02)) wareList.Add(inventoryExtCndtnWork.WarehouseCd02, "");
                if (inventoryExtCndtnWork.WarehouseCd03 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd03)) wareList.Add(inventoryExtCndtnWork.WarehouseCd03, "");
                if (inventoryExtCndtnWork.WarehouseCd04 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd04)) wareList.Add(inventoryExtCndtnWork.WarehouseCd04, "");
                if (inventoryExtCndtnWork.WarehouseCd05 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd05)) wareList.Add(inventoryExtCndtnWork.WarehouseCd05, "");
                if (inventoryExtCndtnWork.WarehouseCd06 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd06)) wareList.Add(inventoryExtCndtnWork.WarehouseCd06, "");
                if (inventoryExtCndtnWork.WarehouseCd07 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd07)) wareList.Add(inventoryExtCndtnWork.WarehouseCd07, "");
                if (inventoryExtCndtnWork.WarehouseCd08 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd08)) wareList.Add(inventoryExtCndtnWork.WarehouseCd08, "");
                if (inventoryExtCndtnWork.WarehouseCd09 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd09)) wareList.Add(inventoryExtCndtnWork.WarehouseCd09, "");
                if (inventoryExtCndtnWork.WarehouseCd10 != "" && !wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd10)) wareList.Add(inventoryExtCndtnWork.WarehouseCd10, "");

                if (wareList != null && wareList.Count != 0)
                {
                    retstring += " AND (";

                    int wareNum = 1;
                    foreach (string wCode in wareList.Keys)
                    {
                        if (wareNum == 1)
                        {
                            retstring += tblDM + "WAREHOUSECODERF=@WAREHOUSECD" + wareNum.ToString();
                        }
                        else
                        {
                            retstring += " OR " + tblDM + "WAREHOUSECODERF=@WAREHOUSECD" + wareNum.ToString();
                        }
                        SqlParameter paraWarehouseCd = sqlCommand.Parameters.Add("@WAREHOUSECD" + wareNum.ToString(), SqlDbType.NVarChar);
                        paraWarehouseCd.Value = SqlDataMediator.SqlSetString(wCode);

                        wareNum++;
                    }

                    retstring += ")";
                }
                // --- UPD 2010/02/20 ----------<<<<<
                #endregion

                if (selectMode != 3) // ADD 2009/11/30
                {
                    if (selectMode != 2)  //ADD yangyi 2013/05/06 Redmine#35493
                    {
                    //棚番設定
                    if (inventoryExtCndtnWork.StWarehouseShelfNo != "")
                    {
                        retstring += " AND " + tblDM + "WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
                        SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                        paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseShelfNo);
                    }
                    if (inventoryExtCndtnWork.EdWarehouseShelfNo != "")
                    {
                        retstring += " AND ( " + tblDM + "WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR " + tblDM + "WAREHOUSESHELFNORF LIKE @EDWAREHOUSESHELFNO OR " + tblDM + "WAREHOUSESHELFNORF IS NULL )";
                        SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                        // --- UPD 2009/11/30 ---------->>>>>
                        //paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseShelfNo + "%");
                        paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseShelfNo);
                        // --- UPD 2009/11/30 ----------<<<<<
                    }
                    // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                    }
                    else
                    {
                        if (inventoryExtCndtnWork.StWarehouseShelfNo != "" && inventoryExtCndtnWork.EdWarehouseShelfNo != "")
                        {
                            retstring += " AND  ( ( " + tblDM + "WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
                            SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseShelfNo);

                            retstring += " AND " + tblDM + "WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO )";
                            SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseShelfNo);

                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF IS NULL ";
                      
                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF=@WAREHOUSESHELFNO1";
                            SqlParameter paraWarehouseShelfNo1 = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO1", SqlDbType.NVarChar);
                            paraWarehouseShelfNo1.Value = SqlDataMediator.SqlSetString("ｶｼﾀﾞｼ");

                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF=@WAREHOUSESHELFNO2 )";
                            SqlParameter paraWarehouseShelfNo2 = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO2", SqlDbType.NVarChar);
                            paraWarehouseShelfNo2.Value = SqlDataMediator.SqlSetString("ｻｷﾀﾞｼ");
                        }
                        else if(inventoryExtCndtnWork.StWarehouseShelfNo != "" && inventoryExtCndtnWork.EdWarehouseShelfNo == "")
                        {
                            retstring += " AND ( " + tblDM + "WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
                            SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StWarehouseShelfNo);

                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF IS NULL ";

                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF=@WAREHOUSESHELFNO1";
                            SqlParameter paraWarehouseShelfNo1 = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO1", SqlDbType.NVarChar);
                            paraWarehouseShelfNo1.Value = SqlDataMediator.SqlSetString("ｶｼﾀﾞｼ");

                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF=@WAREHOUSESHELFNO2 )";
                            SqlParameter paraWarehouseShelfNo2 = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO2", SqlDbType.NVarChar);
                            paraWarehouseShelfNo2.Value = SqlDataMediator.SqlSetString("ｻｷﾀﾞｼ");
                        }
                        else if (inventoryExtCndtnWork.StWarehouseShelfNo == "" && inventoryExtCndtnWork.EdWarehouseShelfNo != "")
                        {
                            retstring += " AND ( " + tblDM + "WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO ";
                            SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                            paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdWarehouseShelfNo);

                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF IS NULL ";

                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF=@WAREHOUSESHELFNO1";
                            SqlParameter paraWarehouseShelfNo1 = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO1", SqlDbType.NVarChar);
                            paraWarehouseShelfNo1.Value = SqlDataMediator.SqlSetString("ｶｼﾀﾞｼ");

                            retstring += " OR " + tblDM + "WAREHOUSESHELFNORF=@WAREHOUSESHELFNO2 )";
                            SqlParameter paraWarehouseShelfNo2 = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO2", SqlDbType.NVarChar);
                            paraWarehouseShelfNo2.Value = SqlDataMediator.SqlSetString("ｻｷﾀﾞｼ");
                        }
                    }
                    // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

                    // --- ADD 2011/02/10 ---------->>>>>
                    //メーカーコード開始
                    if (inventoryExtCndtnWork.StMakerCd > 0)
                    {
                        retstring += " AND " + tblDM + "GOODSMAKERCDRF>=@STMAKERCODE ";
                        SqlParameter paraStMakerCode = sqlCommand.Parameters.Add("@STMAKERCODE", SqlDbType.Int);
                        paraStMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StMakerCd);
                    }
                    //メーカーコード終了
                    if (inventoryExtCndtnWork.EdMakerCd != 9999)
                    {
                        retstring += " AND " + tblDM + "GOODSMAKERCDRF<=@EDMAKERCODE ";
                        SqlParameter paraEdMakerCode = sqlCommand.Parameters.Add("@EDMAKERCODE", SqlDbType.Int);
                        paraEdMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdMakerCd);
                    }
                    // --- ADD 2011/02/10 ----------<<<<<
                }
                // --- ADD 2011/02/10 ---------->>>>>
                else
                {
                    //管理拠点開始
                    if (inventoryExtCndtnWork.SectionCodeSt != "")
                    {
                        retstring += " AND " + tblDM + "SECTIONCODERF>=@STSECTIONCODE ";
                        SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@STSECTIONCODE", SqlDbType.NChar);
                        paraStSectionCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeSt);
                    }
                    //管理拠点終了
                    if (inventoryExtCndtnWork.SectionCodeEd != "")
                    {
                        retstring += "AND " + tblDM + "SECTIONCODERF<=@EDSECTIONCODE ";
                        SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@EDSECTIONCODE", SqlDbType.NChar);
                        paraEdSectionCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd);
                    }
                }
                // --- ADD 2011/02/10 ----------<<<<<
                // --- DEL 2011/02/10 ---------->>>>>
                ////メーカーコード開始
                //if (inventoryExtCndtnWork.StMakerCd > 0)
                //{
                //    retstring += " AND " + tblDM + "GOODSMAKERCDRF>=@STMAKERCODE ";
                //    SqlParameter paraStMakerCode = sqlCommand.Parameters.Add("@STMAKERCODE", SqlDbType.Int);
                //    paraStMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StMakerCd);
                //}
                ////メーカーコード終了
                //if (inventoryExtCndtnWork.EdMakerCd != 9999)
                //{
                //    retstring += " AND " + tblDM + "GOODSMAKERCDRF<=@EDMAKERCODE ";
                //    SqlParameter paraEdMakerCode = sqlCommand.Parameters.Add("@EDMAKERCODE", SqlDbType.Int);
                //    paraEdMakerCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdMakerCd);
                //}
                // --- DEL 2011/02/10 ----------<<<<<

                if (selectMode == 1)
                {
                    #region 自社在庫抽出条件 (在庫マスタ)
                    //// 仕入先コード
                    //if (inventoryExtCndtnWork.StCustomerCd != 0)
                    //{
                    //    retstring += " AND (CASE WHEN GOODSMNG.SUPPLIERCDRF IS NOT NULL  THEN GOODSMNG.SUPPLIERCDRF " + Environment.NewLine;
                    //    retstring += "     ELSE (CASE WHEN GOODSMNG2.SUPPLIERCDRF IS NOT NULL THEN GOODSMNG2.SUPPLIERCDRF " + Environment.NewLine;
                    //    retstring += "           ELSE (CASE WHEN GOODSMNG3.SUPPLIERCDRF IS NOT NULL THEN GOODSMNG3.SUPPLIERCDRF ELSE GOODSMNG4.SUPPLIERCDRF END ) END )  END) >=@STCUSTOMERCD " + Environment.NewLine;

                    //    SqlParameter paraStCustomerCd = sqlCommand.Parameters.Add("@STCUSTOMERCD", SqlDbType.Int);
                    //    paraStCustomerCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StCustomerCd);

                    //}
                    //if (inventoryExtCndtnWork.EdCustomerCd != 999999)
                    //{
                    //    retstring += " AND (CASE WHEN GOODSMNG.SUPPLIERCDRF IS NOT NULL  THEN GOODSMNG.SUPPLIERCDRF " + Environment.NewLine;
                    //    retstring += "     ELSE (CASE WHEN GOODSMNG2.SUPPLIERCDRF IS NOT NULL THEN GOODSMNG2.SUPPLIERCDRF " + Environment.NewLine;
                    //    retstring += "           ELSE (CASE WHEN GOODSMNG3.SUPPLIERCDRF IS NOT NULL THEN GOODSMNG3.SUPPLIERCDRF ELSE GOODSMNG4.SUPPLIERCDRF END ) END )  END) <=@EDCUSTOMERCD " + Environment.NewLine;

                    //    SqlParameter paraEdCustomerCd = sqlCommand.Parameters.Add("@EDCUSTOMERCD", SqlDbType.Int);
                    //    paraEdCustomerCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdCustomerCd);
                    //}
                    // BLコード
                    if (inventoryExtCndtnWork.StBLGoodsCd != 0)
                    {
                        retstring += " AND GOODS.BLGOODSCODERF>=@STBLGOODSCD ";
                        SqlParameter paraStBLGoodsCd = sqlCommand.Parameters.Add("@STBLGOODSCD", SqlDbType.Int);
                        paraStBLGoodsCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StBLGoodsCd);
                    }
                    if (inventoryExtCndtnWork.EdBLGoodsCd != 99999)
                    {
                        retstring += " AND GOODS.BLGOODSCODERF<=@EDBLGOODSCD ";
                        SqlParameter paraEdBLGoodsCd = sqlCommand.Parameters.Add("@EDBLGOODSCD", SqlDbType.Int);
                        paraEdBLGoodsCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdBLGoodsCd);
                    }
                    // ｸﾞﾙｰﾌﾟｺｰﾄﾞ
                    if (inventoryExtCndtnWork.StBLGroupCode != 0)
                    {
                        retstring += " AND BLGOODS.BLGROUPCODERF>=@STBLGROUPCODE ";
                        SqlParameter paraStBLGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                        paraStBLGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StBLGroupCode);
                    }
                    if (inventoryExtCndtnWork.EdBLGroupCode != 99999)
                    {
                        retstring += " AND BLGOODS.BLGROUPCODERF<=@EDBLGROUPCODE ";
                        SqlParameter paraEdBLGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                        paraEdBLGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdBLGroupCode);
                    }

                    //最終棚卸更新日
                    if (inventoryExtCndtnWork.StLtInventoryUpdate != DateTime.MinValue)
                    {
                        int startLastInventoryExtUpdate = TDateTime.DateTimeToLongDate(inventoryExtCndtnWork.StLtInventoryUpdate);
                        retstring += " AND STK.LASTINVENTORYUPDATERF >= " + startLastInventoryExtUpdate.ToString();
                    }
                    if (inventoryExtCndtnWork.EdLtInventoryUpdate != DateTime.MinValue)
                    {
                        if (inventoryExtCndtnWork.StLtInventoryUpdate == DateTime.MinValue)
                        {
                            retstring += " AND ( STK.LASTINVENTORYUPDATERF IS NULL OR ";
                        }
                        else
                        {
                            retstring += " AND";
                        }

                        int endLastInventoryExtUpdate = TDateTime.DateTimeToLongDate(inventoryExtCndtnWork.EdLtInventoryUpdate);
                        retstring += " STK.LASTINVENTORYUPDATERF <=" + endLastInventoryExtUpdate.ToString();

                        if (inventoryExtCndtnWork.StLtInventoryUpdate == DateTime.MinValue)
                        {
                            retstring += " ) ";
                        }
                    }
                    #endregion
                }

                #region DEL
                //#//キャリアコード設定
                //#if (inventoryExtCndtnWork.StCarrierCd != 0)
                //#{
                //#    retstring += " AND " + tblDM + "CARRIERCODERF>=@STCARRIERCODE";
                //#    SqlParameter paraStCarrierCode = sqlCommand.Parameters.Add("@STCARRIERCODE", SqlDbType.Int);
                //#    paraStCarrierCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StCarrierCd);
                //#}
                //#if (inventoryExtCndtnWork.EdCarrierCd != 999)
                //#{
                //#    retstring += " AND " + tblDM + "CARRIERCODERF<=@EDCARRIERCODE";
                //#    SqlParameter paraEdCarrierCode = sqlCommand.Parameters.Add("@EDCARRIERCODE", SqlDbType.Int);
                //#    paraEdCarrierCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdCarrierCd);
                //#}

                /*
                //商品区分グループコード開始
                if (inventoryExtCndtnWork.StLgGoodsGanreCd != "")
                {
                    retstring += " AND " + tblDM + "LARGEGOODSGANRECODERF>=@STLARGEGOODSGANRECODE ";
                    SqlParameter paraStLargeGoodsGanreCode = sqlCommand.Parameters.Add("@STLARGEGOODSGANRECODE", SqlDbType.NChar);
                    paraStLargeGoodsGanreCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StLgGoodsGanreCd);
                }
                //商品区分グループコード終了
                if (inventoryExtCndtnWork.EdLgGoodsGanreCd != "")
                {
                    retstring += " AND " + tblDM + "LARGEGOODSGANRECODERF<=@EDLARGEGOODSGANRECODE ";
                    SqlParameter paraEdLargeGoodsGanreCode = sqlCommand.Parameters.Add("@EDLARGEGOODSGANRECODE", SqlDbType.NChar);
                    paraEdLargeGoodsGanreCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdLgGoodsGanreCd);
                }

                //商品区分コード開始
                if (inventoryExtCndtnWork.StMdGoodsGanreCd != "")
                {
                    retstring += " AND " + tblDM + "MEDIUMGOODSGANRECODERF>=@STMEDIUMGOODSGANRECODE ";
                    SqlParameter paraStMediumGoodsGanreCode = sqlCommand.Parameters.Add("@STMEDIUMGOODSGANRECODE", SqlDbType.NChar);
                    paraStMediumGoodsGanreCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StMdGoodsGanreCd);
                }
                //商品区分コード終了
                if (inventoryExtCndtnWork.EdMdGoodsGanreCd != "")
                {
                    retstring += " AND " + tblDM + "MEDIUMGOODSGANRECODERF<=@EDMEDIUMGOODSGANRECODE ";
                    SqlParameter paraEdMediumGoodsGanreCode = sqlCommand.Parameters.Add("@EDMEDIUMGOODSGANRECODE", SqlDbType.NChar);
                    paraEdMediumGoodsGanreCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdMdGoodsGanreCd);
                }
                */
                //#//機種コード開始
                //#if (inventoryExtCndtnWork.StCellphoneModelCd != "")
                //#{
                //#    retstring += " AND " + tblDM + "CELLPHONEMODELCODERF>=@STCELLPHONEMODELCODE ";
                //#    SqlParameter paraStCellphoneModelCode = sqlCommand.Parameters.Add("@STCELLPHONEMODELCODE", SqlDbType.NVarChar);
                //#    paraStCellphoneModelCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StCellphoneModelCd);
                //#}
                //#//機種コード終了
                //#if (inventoryExtCndtnWork.EdCellphoneModelCd != "")
                //#{
                //#    retstring += "AND ( " + tblDM + "CELLPHONEMODELCODERF<=@EDCELLPHONEMODELCODE OR " + tblDM + "CELLPHONEMODELCODERF LIKE @EDCELLPHONEMODELCODE ) ";
                //#    SqlParameter paraEdCellphoneModelCode = sqlCommand.Parameters.Add("@EDCELLPHONEMODELCODE", SqlDbType.NVarChar);
                //#    paraEdCellphoneModelCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdCellphoneModelCd + "%");
                //#}

                //#//商品コード開始
                //#if (inventoryExtCndtnWork.StGoodsCd != "")
                //#{
                //#    retstring += " AND " + tblDM + "GOODSCODERF>=@STGOODSCODE ";
                //#    SqlParameter paraStGoodsCode = sqlCommand.Parameters.Add("@STGOODSCODE", SqlDbType.NVarChar);
                //#    paraStGoodsCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.StGoodsCd);
                //#}
                //#//商品コード終了
                //#if (inventoryExtCndtnWork.EdGoodsCd != "")
                //#{
                //#    retstring += "AND ( " + tblDM + "GOODSCODERF<=@EDGOODSCODE OR " + tblDM + "GOODSCODERF LIKE @EDGOODSCODE ) ";
                //#    SqlParameter paraEdGoodsCode = sqlCommand.Parameters.Add("@EDGOODSCODE", SqlDbType.NVarChar);
                //#    paraEdGoodsCode.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.EdGoodsCd + "%");
                //#}
                #endregion
                else if (selectMode == 2)
                {
                    #region 棚卸データ抽出条件
                    // --- DEL yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
                    // ----- ADD 2011/01/11 ----->>>>>
                    //retstring += " OR " + tblDM + "WAREHOUSESHELFNORF=@WAREHOUSESHELFNO1";
                    //SqlParameter paraWarehouseShelfNo1 = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO1", SqlDbType.NVarChar);
                    //paraWarehouseShelfNo1.Value = SqlDataMediator.SqlSetString("ｶｼﾀﾞｼ");

                    //retstring += " OR " + tblDM + "WAREHOUSESHELFNORF=@WAREHOUSESHELFNO2";
                    //SqlParameter paraWarehouseShelfNo2 = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO2", SqlDbType.NVarChar);
                    //paraWarehouseShelfNo2.Value = SqlDataMediator.SqlSetString("ｻｷﾀﾞｼ");
                    // ----- ADD 2011/01/11 -----<<<<<
                    // --- DEL yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<
                    //ＢＬ商品コード開始
                    if (inventoryExtCndtnWork.StBLGoodsCd != 0)
                    {
                        retstring += " AND " + tblDM + "BLGOODSCODERF>=@STBLGOODSCD ";
                        SqlParameter paraStBLGoodsCd = sqlCommand.Parameters.Add("@STBLGOODSCD", SqlDbType.NVarChar);
                        paraStBLGoodsCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StBLGoodsCd);
                    }
                    //ＢＬ商品コード終了
                    if (inventoryExtCndtnWork.EdBLGoodsCd != 0)
                    {
                        retstring += " AND " + tblDM + "BLGOODSCODERF<=@EDBLGOODSCD ";
                        SqlParameter paraEdBLGoodsCd = sqlCommand.Parameters.Add("@EDBLGOODSCD", SqlDbType.NVarChar);
                        paraEdBLGoodsCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdBLGoodsCd);
                    }
                    //仕入先コード設定
                    if (inventoryExtCndtnWork.StCustomerCd != 0)
                    {
                        retstring += " AND " + tblDM + "SUPPLIERCDRF>=@STCUSTOMERCD";
                        SqlParameter paraStCustomerCd = sqlCommand.Parameters.Add("@STCUSTOMERCD", SqlDbType.Int);
                        paraStCustomerCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StCustomerCd);
                    }
                    if (inventoryExtCndtnWork.EdCustomerCd != 999999)
                    {
                        retstring += " AND " + tblDM + "SUPPLIERCDRF<=@EDCUSTOMERCD";
                        SqlParameter paraEdCustomerCd = sqlCommand.Parameters.Add("@EDCUSTOMERCD", SqlDbType.Int);
                        paraEdCustomerCd.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdCustomerCd);
                    }
                    // グループコード設定
                    if (inventoryExtCndtnWork.StBLGroupCode != 0)
                    {
                        retstring += " AND " + tblDM + "BLGROUPCODERF>=@STBLGROUPCODE";
                        SqlParameter paraStBlGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                        paraStBlGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.StBLGroupCode);
                    }
                    if (inventoryExtCndtnWork.EdBLGroupCode != 99999)
                    {
                        retstring += " AND " + tblDM + "BLGROUPCODERF<=@EDBLGROUPCODE";
                        SqlParameter paraEdBlGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                        paraEdBlGroupCode.Value = SqlDataMediator.SqlSetInt32(inventoryExtCndtnWork.EdBLGroupCode);
                    }
                    //-----ADD 2011/01/11----->>>>>
                    // 管理拠点
                    if (inventoryExtCndtnWork.SectionCodeSt != "")
                    {
                        sqlCommand.CommandText += " AND RESULTSADDUPSECCDRF>=@SECTIONCODEST" + Environment.NewLine;
                        SqlParameter paraSectionCodeSt = sqlCommand.Parameters.Add("@SECTIONCODEST", SqlDbType.NVarChar);
                        paraSectionCodeSt.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeSt);
                    }

                    if (inventoryExtCndtnWork.SectionCodeEd != "")
                    {
                        sqlCommand.CommandText += " AND RESULTSADDUPSECCDRF<=@SECTIONCODEED" + Environment.NewLine;
                        SqlParameter paraSectionCodeEd = sqlCommand.Parameters.Add("@SECTIONCODEED", SqlDbType.NVarChar);
                        paraSectionCodeEd.Value = SqlDataMediator.SqlSetString(inventoryExtCndtnWork.SectionCodeEd);
                    }
                    //-----ADD 2011/01/11-----<<<<<
                    #endregion
                }
                #region DEL
                /*
                //在庫抽出区分
                string retstockstring = "";
                //自社在庫抽出区分
                if (inventoryExtCndtnWork.CmpStkExtraDiv == 0)
                {
                    if (retstockstring == "")
                    {
                        retstockstring += "(";
                    }
                    retstockstring += "(" + tblDM + "STOCKDIVRF=0 AND " + tblDM + "STOCKSTATERF=0)";
                }
                //受託在庫抽出区分
                if (inventoryExtCndtnWork.TrtStkExtraDiv == 0)
                {
                    if (retstockstring == "")
                    {
                        retstockstring += "(";
                    }
                    else
                    {
                        retstockstring += " OR ";
                    }
                    retstockstring += "(" + tblDM + "STOCKDIVRF=1 AND " + tblDM + "STOCKSTATERF=10)";
                }
                //委託（自社）在庫抽出区分
                if (inventoryExtCndtnWork.EntCmpStkExtraDiv == 0)
                {
                    if (retstockstring == "")
                    {
                        retstockstring += "(";
                    }
                    else
                    {
                        retstockstring += " OR ";
                    }
                    retstockstring += "(" + tblDM + "STOCKDIVRF=0 AND " + tblDM + "STOCKSTATERF=20)";
                }
                //委託（受託）在庫抽出区分
                if (inventoryExtCndtnWork.EntTrtStkExtraDiv == 0)
                {
                    if (retstockstring == "")
                    {
                        retstockstring += "(";
                    }
                    else
                    {
                        retstockstring += " OR ";
                    }
                    retstockstring += "(" + tblDM + "STOCKDIVRF=1 AND " + tblDM + "STOCKSTATERF=20)";
                }
                if (retstockstring != "")
                {
                    retstockstring += " )";
                    retstring += " AND " + retstockstring;
                }
                */
                //if (selectMode == 1)
                //{
                /*
                //商品種別
                string retgoodsstring = "";
                //一般抽出区分
                if (inventoryExtCndtnWork.GeneralGoodsExtDiv == 0)
                {
                    if (retgoodsstring == "")
                    {
                        retgoodsstring += "(";
                    }
                    retgoodsstring += "(GOD.GOODSKINDCODERF=0)";
                }
                //携帯電話抽出区分
                if (inventoryExtCndtnWork.MobileGoodsExtDiv == 0)
                {
                    if (retgoodsstring == "")
                    {
                        retgoodsstring += "(";
                    }
                    else
                    {
                        retgoodsstring += " OR ";
                    }
                    retgoodsstring += "(GOD.GOODSKINDCODERF=1)";
                }
                //付属品抽出区分
                if (inventoryExtCndtnWork.AcsryGoodsExtDiv == 0)
                {
                    if (retgoodsstring == "")
                    {
                        retgoodsstring += "(";
                    }
                    else
                    {
                        retgoodsstring += " OR ";
                    }
                    retgoodsstring += "(GOD.GOODSKINDCODERF=2)";
                }
                if ((inventoryExtCndtnWork.GeneralGoodsExtDiv == 0) && (inventoryExtCndtnWork.MobileGoodsExtDiv == 0) && (inventoryExtCndtnWork.AcsryGoodsExtDiv == 0))
                {
                    if (retgoodsstring == "")
                    {
                        retgoodsstring += "(";
                    }
                    else
                    {
                        retgoodsstring += " OR ";
                    }
                    retgoodsstring += "(GOD.GOODSKINDCODERF IS NULL)";
                }
                if (retgoodsstring != "")
                {
                    retgoodsstring += " )";
                    retstring += "AND " + retgoodsstring;
                }
                */
                //}
                #endregion
                else
                {
                    #region 棚卸準備処理履歴 抽出条件 ※現在未使用
                    //最終棚卸更新日
                    if (inventoryExtCndtnWork.StLtInventoryUpdate != DateTime.MinValue)
                    {
                        int startLastInventoryExtUpdate = TDateTime.DateTimeToLongDate(inventoryExtCndtnWork.StLtInventoryUpdate);
                        retstring += " AND " + tblDM + "LASTINVENTORYUPDATERF >= " + startLastInventoryExtUpdate.ToString();
                    }
                    if (inventoryExtCndtnWork.EdLtInventoryUpdate != DateTime.MinValue)
                    {
                        if (inventoryExtCndtnWork.StLtInventoryUpdate == DateTime.MinValue)
                        {
                            retstring += " AND ( " + tblDM + "LASTINVENTORYUPDATERF IS NULL OR ";
                        }
                        else
                        {
                            retstring += " AND";
                        }

                        int endLastInventoryExtUpdate = TDateTime.DateTimeToLongDate(inventoryExtCndtnWork.EdLtInventoryUpdate);
                        retstring += " " + tblDM + "LASTINVENTORYUPDATERF <=" + endLastInventoryExtUpdate.ToString();

                        if (inventoryExtCndtnWork.StLtInventoryUpdate == DateTime.MinValue)
                        {
                            retstring += " ) ";
                        }
                    }
                    #endregion
                }
            }

            return retstring;
        }
        #endregion  // MakeWhereString

        /// <summary>
        /// ディクショナリキー
        /// </summary>
        /// <param name="WarehouseCode">倉庫コード</param>
        /// <param name="WarehouseShelfNo">倉庫棚番</param>
        /// <param name="GoodsMakerCd">メーカーコード</param>
        /// <param name="GoodsNo">商品番号</param>
        /// <returns>dicキー</returns>
        private string KeyofDic(string WarehouseCode, int GoodsMakerCd, string GoodsNo)
        {
            return (WarehouseCode + "." + GoodsMakerCd.ToString("%06d") + "." + GoodsNo);
        }

        // --- ADD 2009/11/30 ---------->>>>>
        #region SearchRepateDate
        /// <summary>
        /// 棚卸データを検索し、棚卸データ存在チェックflagを戻します
        /// </summary>
        /// <param name="retobj">存在チェックflag</param>
        /// <param name="parabyte">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="statusMSG">statusに対するメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データを検索し、棚卸データ存在チェックflagを戻します</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.11.30</br>
        public int SearchRepateDate(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, out string statusMSG)
        {
            return SearchRepateDateProc(out retobj, paraobj, readMode, logicalMode, out statusMSG);
        }

        /// <summary>
        /// 棚卸データを検索し、棚卸データ存在チェックflagを戻します
        /// </summary>
        /// <param name="retobj">存在チェックflag</param>
        /// <param name="parabyte">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="statusMSG">statusに対するメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データを検索し、棚卸データ存在チェックflagを戻します</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.11.30</br>
        private int SearchRepateDateProc(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, out string statusMSG)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            statusMSG = "";
            retobj = null;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTrans = null;

            List<InventoryDataWork> al = null;   //棚卸データ
            InventoryExtCndtnWork inventoryExtCndtnWork = null;
            bool repateFlag = false;

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    statusMSG = "接続異常です。";
                    return status;
                }

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                inventoryExtCndtnWork = paraobj as InventoryExtCndtnWork;

                // システムロック(倉庫) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>          
                #region システムロック(倉庫)
                Dictionary<string, string> wareList;
                ArrayList infoList = new ArrayList(); //シェアチェック情報リスト
                if (inventoryExtCndtnWork.WarehouseDiv == 0)
                {
                    status = searchWarehouse(ref inventoryExtCndtnWork, out wareList, ref sqlConnection);
                }
                else
                {
                    wareList = new Dictionary<string, string>();
                    if (inventoryExtCndtnWork.WarehouseCd01 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd01)) wareList.Add(inventoryExtCndtnWork.WarehouseCd01, "");
                    if (inventoryExtCndtnWork.WarehouseCd02 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd02)) wareList.Add(inventoryExtCndtnWork.WarehouseCd02, "");
                    if (inventoryExtCndtnWork.WarehouseCd03 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd03)) wareList.Add(inventoryExtCndtnWork.WarehouseCd03, "");
                    if (inventoryExtCndtnWork.WarehouseCd04 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd04)) wareList.Add(inventoryExtCndtnWork.WarehouseCd04, "");
                    if (inventoryExtCndtnWork.WarehouseCd05 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd05)) wareList.Add(inventoryExtCndtnWork.WarehouseCd05, "");
                    if (inventoryExtCndtnWork.WarehouseCd06 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd06)) wareList.Add(inventoryExtCndtnWork.WarehouseCd06, "");
                    if (inventoryExtCndtnWork.WarehouseCd07 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd07)) wareList.Add(inventoryExtCndtnWork.WarehouseCd07, "");
                    if (inventoryExtCndtnWork.WarehouseCd08 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd08)) wareList.Add(inventoryExtCndtnWork.WarehouseCd08, "");
                    if (inventoryExtCndtnWork.WarehouseCd09 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd09)) wareList.Add(inventoryExtCndtnWork.WarehouseCd09, "");
                    if (inventoryExtCndtnWork.WarehouseCd10 != "" && wareList.ContainsKey(inventoryExtCndtnWork.WarehouseCd10)) wareList.Add(inventoryExtCndtnWork.WarehouseCd10, "");
                }

                sqlTrans = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                if (wareList.Count != 0 || wareList != null)
                {
                    foreach (string wCode in wareList.Keys)
                    {
                        ShareCheckInfo info = new ShareCheckInfo();
                        info.Keys.Add(inventoryExtCndtnWork.EnterpriseCode, ShareCheckType.WareHouse, "", wCode);
                        status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTrans);
                        infoList.Add(info);
                        if (status != 0) return status;
                    }
                }
                #endregion
                // システムロック(倉庫) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // --- UPD 2010/02/20 ---------->>>>>
                //在庫マスタ検索処理
                //status = SeachProductStock(out al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);
                status = SeachProductStockRepate(out al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);
                // --- UPD 2010/02/20 ----------<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)  //抽出データがない場合
                {
                    statusMSG = "更新対象がありません。";
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)  //抽出データがある場合
                {
                    // --- DEL 2010/02/20 ---------->>>>>
                    //ここで、
                    //alに登録されている各棚卸データごとに指定された棚卸日における在庫数を求める。
                    //これを各棚卸データの在庫総数とし、マシン在庫額を再計算する。
                    //CalcStockTotal(ref al, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);
                    // --- DEL 2010/02/20 ----------<<<<<

                    int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    #region 棚卸データ検索処理
                    st = SeachInventoryRepateData(al, ref repateFlag, inventoryExtCndtnWork, ref sqlConnection, ref sqlTrans, readMode, logicalMode);
                    if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (st != (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        statusMSG += "棚卸データの検索に失敗しました。";
                        status = st;
                    }
                    #endregion

                    status = st;

                    // システムロック解除(倉庫) //2009/1/27 Add sakurai >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    if (status == 0 || status == 9)
                    {
                        foreach (ShareCheckInfo info in infoList)
                        {
                            int sta = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTrans);
                            if (sta != 0) return status = sta;
                        }
                    }
                    // システムロック解除(倉庫) //2009/1/27 Add sakurai <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }

                retobj = repateFlag;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SearchRepateDateProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (status == 0)
                {
                    sqlTrans.Commit();
                }
                else
                {
                    sqlTrans.Rollback();
                }
                sqlConnection.Close();
                sqlTrans.Dispose();
            }
            return status;
        }

        /// <summary>
        /// 棚卸データを検索し、棚卸データを戻します
        /// </summary>
        /// <param name="al">棚卸データ</param>
        /// <param name="inventoryExtCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTrans">SqlTransaction</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 棚卸データDictionaryを戻します</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.11.30</br>
        private int SeachInventoryRepateData(List<InventoryDataWork> al, ref bool repateFlag, InventoryExtCndtnWork inventoryExtCndtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTrans, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                string SelectDm = "";
                SelectDm += "SELECT";

                //結果取得
                SelectDm += " IVD.SECTIONCODERF  IVD_SECTIONCODERF";
                SelectDm += ", IVD.WAREHOUSECODERF IVD_WAREHOUSECODERF";
                SelectDm += ", IVD.WAREHOUSESHELFNORF IVD_WAREHOUSESHELFNORF";
                SelectDm += ", IVD.GOODSMAKERCDRF  IVD_GOODSMAKERCDRF";
                SelectDm += ", IVD.GOODSNORF  IVD_GOODSNORF";
                SelectDm += ", IVD.INVENTORYSEQNORF IVD_INVENTORYSEQNORF";
                SelectDm += ", IVD.STOCKUNITPRICEFLRF  IVD_STOCKUNITPRICEFLRF";
                SelectDm += ", IVD.BFSTOCKUNITPRICEFLRF  IVD_BFSTOCKUNITPRICEFLRF";
                SelectDm += ", IVD.STKUNITPRICECHGFLGRF IVD_STKUNITPRICECHGFLGRF";
                SelectDm += ", IVD.INVENTORYSTOCKCNTRF IVD_INVENTORYSTOCKCNTRF";
                SelectDm += ", IVD.INVENTORYTOLERANCCNTRF IVD_INVENTORYTOLERANCCNTRF";
                SelectDm += ", IVD.INVENTORYDAYRF IVD_INVENTORYDAYRF";
                SelectDm += ", IVD.LASTINVENTORYUPDATERF IVD_LASTINVENTORYUPDATERF";

                //SelectDm += " FROM INVENTORYDATARF IVD"; // DEL wangf 2012/03/23 FOR Redmine#29109
                SelectDm += " FROM INVENTORYDATARF IVD WITH (READUNCOMMITTED) "; // ADD wangf 2012/03/23 FOR Redmine#29109

                sqlCommand = new SqlCommand(SelectDm, sqlConnection, sqlTrans);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, inventoryExtCndtnWork, logicalMode, 2);

                string Key = "";

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    InventoryDataWork wkInventoryDataWork = new InventoryDataWork();

                    #region 棚卸データ値セット
                    wkInventoryDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_SECTIONCODERF"));
                    wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSECODERF"));
                    wkInventoryDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_WAREHOUSESHELFNORF"));
                    wkInventoryDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_GOODSMAKERCDRF"));
                    wkInventoryDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("IVD_GOODSNORF"));
                    wkInventoryDataWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_INVENTORYSEQNORF"));
                    wkInventoryDataWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_STOCKUNITPRICEFLRF"));
                    wkInventoryDataWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_BFSTOCKUNITPRICEFLRF"));
                    wkInventoryDataWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IVD_STKUNITPRICECHGFLGRF"));
                    wkInventoryDataWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYSTOCKCNTRF"));
                    wkInventoryDataWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("IVD_INVENTORYTOLERANCCNTRF"));
                    wkInventoryDataWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_INVENTORYDAYRF"));
                    wkInventoryDataWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("IVD_LASTINVENTORYUPDATERF"));

                    foreach (InventoryDataWork inventoryDataWork in al)
                    {
                        if (inventoryDataWork.WarehouseCode.Equals(wkInventoryDataWork.WarehouseCode)
                            && inventoryDataWork.GoodsMakerCd.Equals(wkInventoryDataWork.GoodsMakerCd)
                            && inventoryDataWork.GoodsNo.Equals(wkInventoryDataWork.GoodsNo))
                        {
                            repateFlag = true;
                            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }

                    #endregion  // 棚卸データ値セット
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (!myReader.IsClosed) myReader.Close();
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InventoryExtDB.SeachInventoryRepateData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 棚卸通番を付番比較クラス(棚卸印刷順初期設定区分)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 棚卸データを検索し、棚卸データ存在チェックflagを戻します</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.11.30</br>
        /// <br>Update Note: 2012/05/25 李小路</br>
        /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#29996　棚卸調査票　棚卸連番が、連番で印字されないの対応</br>
        /// </remarks>
        public class InventoryDataWorkComparer : Comparer<InventoryDataWork>
        {
            private int _invntryPrtOdrIniDiv;
            // ADD 李小路 2012/05/25 Redmine#29996 ------------->>>>>
            private CompareInfo myComp = CompareInfo.GetCompareInfo("en-US");
            private CompareOptions myOptions = CompareOptions.Ordinal;
            // ADD 李小路 2012/05/25 Redmine#29996 -------------<<<<<

            public InventoryDataWorkComparer(int invntryPrtOdrIniDiv)
            {
                _invntryPrtOdrIniDiv = invntryPrtOdrIniDiv;
            }
            /// <summary>
            /// 比較処理
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            /// <remarks>
            /// <br>Update Note: 2012/05/25 李小路</br>
            /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
            /// <br>             Redmine#29996　棚卸調査票　棚卸連番が、連番で印字されないの対応</br>
            /// </remarks>
            public override int Compare(InventoryDataWork x, InventoryDataWork y)
            {
                int result = 0;
                //棚番順
                if (_invntryPrtOdrIniDiv == 0)
                {
                    #region DEL 2012/05/25
                    // DEL 李小路 2012/05/25 Redmine#29996 ------------->>>>>
                    //倉庫コード
                    //result = x.WarehouseCode.CompareTo(y.WarehouseCode);
                    //if (result != 0) return result;

                    //倉庫棚番
                    //result = x.WarehouseShelfNo.CompareTo(y.WarehouseShelfNo);
                    //if (result != 0) return result;

                    //商品番号
                    //result = x.GoodsNo.CompareTo(y.GoodsNo);
                    //if (result != 0) return result;
                    // DEL 李小路 2012/05/25 Redmine#29996 -------------<<<<<
                    #endregion DEL 2012/05/25

                    // ADD 李小路 2012/05/25 Redmine#29996 ------------->>>>>
                    //倉庫コード
                    result = myComp.Compare(x.WarehouseCode, y.WarehouseCode, myOptions);
                    if (result != 0) return result;

                    //倉庫棚番
                    result = myComp.Compare(x.WarehouseShelfNo, y.WarehouseShelfNo, myOptions);
                    if (result != 0) return result;

                    //商品番号
                    result = myComp.Compare(x.GoodsNo, y.GoodsNo, myOptions);
                    if (result != 0) return result;
                    // ADD 李小路 2012/05/25 Redmine#29996 -------------<<<<<

                    //商品メーカーコード
                    result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
                    if (result != 0) return result;
                }
                //仕入先順
                else if (_invntryPrtOdrIniDiv == 1)
                {
                    //倉庫コード
                    result = x.WarehouseCode.CompareTo(y.WarehouseCode);
                    if (result != 0) return result;

                    //仕入先コード
                    result = x.SupplierCd.CompareTo(y.SupplierCd);
                    if (result != 0) return result;

                    //商品番号
                    result = x.GoodsNo.CompareTo(y.GoodsNo);
                    if (result != 0) return result;

                    //商品メーカーコード
                    result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
                    if (result != 0) return result;
                }
                //BLコード順
                else if (_invntryPrtOdrIniDiv == 2)
                {
                    //倉庫コード
                    result = x.WarehouseCode.CompareTo(y.WarehouseCode);
                    if (result != 0) return result;

                    //BL商品コード
                    result = x.BLGoodsCode.CompareTo(y.BLGoodsCode);
                    if (result != 0) return result;

                    //商品番号
                    result = x.GoodsNo.CompareTo(y.GoodsNo);
                    if (result != 0) return result;

                    //商品メーカーコード
                    result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
                    if (result != 0) return result;
                }
                //グループコード順
                else if (_invntryPrtOdrIniDiv == 3)
                {
                    //倉庫コード
                    result = x.WarehouseCode.CompareTo(y.WarehouseCode);
                    if (result != 0) return result;

                    //BLグループコード
                    result = x.BLGroupCode.CompareTo(y.BLGroupCode);
                    if (result != 0) return result;

                    //商品番号
                    result = x.GoodsNo.CompareTo(y.GoodsNo);
                    if (result != 0) return result;

                    //商品メーカーコード
                    result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
                    if (result != 0) return result;
                }
                //メーカー順
                else if (_invntryPrtOdrIniDiv == 4)
                {
                    //倉庫コード
                    result = x.WarehouseCode.CompareTo(y.WarehouseCode);
                    if (result != 0) return result;

                    //商品メーカーコード
                    result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
                    if (result != 0) return result;

                    //商品番号
                    result = x.GoodsNo.CompareTo(y.GoodsNo);
                    if (result != 0) return result;
                }
                //仕入先・棚番順
                else if (_invntryPrtOdrIniDiv == 5)
                {
                    #region DEL 2012/05/25
                    // DEL 李小路 2012/05/25 Redmine#29996 ------------->>>>>
                    //倉庫コード
                    //result = x.WarehouseCode.CompareTo(y.WarehouseCode);
                    //if (result != 0) return result;
                    // DEL 李小路 2012/05/25 Redmine#29996 -------------<<<<<
                    #endregion DEL 2012/05/25

                    // ADD 李小路 2012/05/25 Redmine#29996 ------------->>>>>
                    //倉庫コード
                    result = myComp.Compare(x.WarehouseCode, y.WarehouseCode, myOptions);
                    if (result != 0) return result;
                    // ADD 李小路 2012/05/25 Redmine#29996 -------------<<<<<

                    //仕入先コード
                    result = x.SupplierCd.CompareTo(y.SupplierCd);
                    if (result != 0) return result;

                    #region DEL 2012/05/25
                    // DEL 李小路 2012/05/25 Redmine#29996 ------------->>>>>
                    //倉庫棚番
                    //result = x.WarehouseShelfNo.CompareTo(y.WarehouseShelfNo);
                    //if (result != 0) return result;

                    //商品番号
                    //result = x.GoodsNo.CompareTo(y.GoodsNo);
                    //if (result != 0) return result;
                    // DEL 李小路 2012/05/25 Redmine#29996 -------------<<<<<
                    #endregion DEL 2012/05/25

                    // ADD 李小路 2012/05/25 Redmine#29996 ------------->>>>>
                    //倉庫棚番
                    result = myComp.Compare(x.WarehouseShelfNo, y.WarehouseShelfNo, myOptions);
                    if (result != 0) return result;
                    
                    //商品番号
                    result = myComp.Compare(x.GoodsNo, y.GoodsNo, myOptions);
                    if (result != 0) return result;
                    // ADD 李小路 2012/05/25 Redmine#29996 -------------<<<<<

                    //商品メーカーコード
                    result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
                    if (result != 0) return result;
                }
                //仕入先・メーカー順
                else if (_invntryPrtOdrIniDiv == 6)
                {
                    //倉庫コード
                    result = x.WarehouseCode.CompareTo(y.WarehouseCode);
                    if (result != 0) return result;

                    //仕入先コード
                    result = x.SupplierCd.CompareTo(y.SupplierCd);
                    if (result != 0) return result;

                    //商品メーカーコード
                    result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
                    if (result != 0) return result;

                    //商品番号
                    result = x.GoodsNo.CompareTo(y.GoodsNo);
                    if (result != 0) return result;
                }
                else
                {
                    //なし
                }

                return result;
            }
        }
        #endregion  // SearchRepateDate
        // --- ADD 2009/11/30 ----------<<<<<

        // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
        /// <summary>
        /// 指定された企業コードの棚卸データ件数戻します
        /// </summary>
        /// <param name="retobj">検索結果(準備処理履歴)</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの棚卸データ件数戻します</br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2010.06.07</br>
        public int SearchInventoryData(out object retobj, object paraobj, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            InventoryDataWork inventoryDataWork = new InventoryDataWork();
            retobj = null;

            ArrayList al = new ArrayList();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                inventoryDataWork = paraobj as InventoryDataWork;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                SqlCommand sqlCommand = null;
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = "SELECT * FROM INVENTORYDATARF  WITH (READUNCOMMITTED) ";
                
                //企業コード
                sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.EnterpriseCode);


                //論理削除
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand.CommandText += " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand.CommandText += " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                //管理拠点開始
                if (inventoryDataWork.SectionCodeSt != "")
                {
                    sqlCommand.CommandText += " AND SECTIONCODERF>=@STSECTIONCODE ";
                    SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@STSECTIONCODE", SqlDbType.NChar);
                    paraStSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.SectionCodeSt);
                }
                //管理拠点終了
                if (inventoryDataWork.SectionCodeEd != "")
                {
                    sqlCommand.CommandText += "AND SECTIONCODERF<=@EDSECTIONCODE ";
                    SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@EDSECTIONCODE", SqlDbType.NChar);
                    paraEdSectionCode.Value = SqlDataMediator.SqlSetString(inventoryDataWork.SectionCodeEd);
                }

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    InventoryDataWork wkInventoryDataWork = new InventoryDataWork();

                    #region 値セット
                    wkInventoryDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkInventoryDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkInventoryDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkInventoryDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkInventoryDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkInventoryDataWork.InventorySeqNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INVENTORYSEQNORF"));
                    wkInventoryDataWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    wkInventoryDataWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
                    wkInventoryDataWork.StkUnitPriceChgFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STKUNITPRICECHGFLGRF"));
                    wkInventoryDataWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYSTOCKCNTRF"));
                    wkInventoryDataWork.InventoryTolerancCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYTOLERANCCNTRF"));
                    wkInventoryDataWork.InventoryDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INVENTORYDAYRF"));
                    wkInventoryDataWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));

                    #endregion  // 値セット

                    al.Add(wkInventoryDataWork);

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
                base.WriteErrorLog(ex, "InventoryExtDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (!myReader.IsClosed) myReader.Close();
            sqlConnection.Close();

            retobj = al;
            return status;

        }
        // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<
    }
}
