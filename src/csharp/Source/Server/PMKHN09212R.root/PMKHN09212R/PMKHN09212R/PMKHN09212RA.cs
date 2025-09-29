//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ユーザーマージ処理リモートオブジェクト
//                  :   PMKHN09212R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   30290 
// Date             :   2008.09.08
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
// 管理番号  11070266-00 作成担当 : 30757 佐々木　貴英 							
// 修 正 日  2015/02/24  修正内容 : SCM高速化 Ｃ向け種別対応
//                                  ①追加項目の取得と更新
//                                    ・優良設定詳細名称２(工場向け)
//                                    ・優良設定詳細名称２(カーオーナー向け)
//----------------------------------------------------------------------
// 管理番号  11670219-00 作成担当 : 陳艶丹
// 修 正 日  2020/06/18  修正内容 : PMKOBETSU-4005 ＥＢＥ対策
//----------------------------------------------------------------------
// 管理番号  12170169-00 作成担当 : 田村顕成
// 修 正 日  2025/08/11  修正内容 : 提供データの提供日付が未来の日付に
//                                  なっている不具合の救済対応
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using Broadleaf.Application.Common;// ADD 陳艶丹 2020/06/18 PMKOBETSU-4005の対応

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// ユーザーマージ処理リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : ユーザーマージ処理リモートオブジェクト</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.08</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note: 2009/12/11 21024 佐々木 健</br>
    /// <br>           :・BLコード更新区分対応(MANTIS[0014775])</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/23 21024 佐々木 健</br>
    /// <br>           :・優良設定を取得するように修正(MANTIS[0015332])</br>
    /// <br>Update Note: 2010/05/24 朱俊成</br>
    /// <br>             PM.NS1009</br>
    /// <br>             価格改正履歴削除</br>
    /// <br></br>
    /// <br>Update Note: 2010/09/07 30517 夏野 駿希</br>
    /// <br>           :・優良設定詳細コードの書き換え条件の修正(MANTIS[0015809])</br>
    /// <br></br>
    /// <br>Update Note: 2010/10/06 22018 鈴木 正臣</br>
    /// <br>           :・優良設定詳細コード(セレクト/種別)を更新する際に、</br>
    /// <br>              商品管理情報マスタレコードが削除される件の修正。(MANTIS[0015809])</br>
    /// <br></br>
    /// <br>Update Note: 2011/05/25 22008 長内 数馬</br>
    /// <br>           :優良設定変更マスタに削除のレコードが存在した場合、ＢＬコード０のレコードがユーザーの優良設定マスタから</br>
    /// <br>            削除されない不具合を修正</br>
    /// <br></br>
    /// <br>Update Note: 2012/01/17 22008 長内 数馬</br>
    /// <br>           :イスコジャパンにてタイムアウトエラーが発生し、提供データが更新されない件の対応</br>
    /// <br>Update Note: 2014/08/21 songg </br>
    /// <br>管理番号   : 11070149-00 仕掛№1923 Redmine#35573</br>
    /// <br>           : 提供データ更新で「種類 'System.OutOfMemmoryException' の例外がスローされました。」のエラーが発生し、価格更新ができない。</br>
    /// <br></br>
    /// <br>Update Note: 2015/02/25 30757 佐々木 貴英</br>
    /// <br>           : 11070266-00　SCM高速化 Ｃ向け種別対応 </br>
    /// <br>Update Note: 2020/06/18 陳艶丹</br>
    /// <br>           : 11670219-00　PMKOBETSU-4005 ＥＢＥ対策 </br>
    /// <br></br>
    /// <br>Update Note: 2021/07/20 3H 王俊</br>
    /// <br>           : 11770032-00 先行配信マージ対応</br>
    /// <br>           : ①提供データ更新処理にてトヨタと日産の価格改定が行われない</br>
    /// <br>           : ②提供データ更新で「種類 'System.OutOfMemmoryException' の例外がスローされました。」のエラーが発生し、価格更新ができない。</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class OfferMergeDB : RemoteWithAppLockDB, IOfferMerge
    {
        #region [ Private Member]
        private int _updateDataDiv;
        private int _offerDate;
        private OprtnHisLogDB _oprtnHisLogDB = new OprtnHisLogDB();
        private VersionChkWorkDB _versionChkWorkDB = new VersionChkWorkDB();
        private string _currentVersion = string.Empty;
        private string EnterpriseCd;
        private GoodsMngDB _goodsMngDB = null;

        //private GoodsPriceUWork deleteGoodsPriceUWork = new GoodsPriceUWork();  // 削除用価格ワーク
        //private GoodsPriceUWork PriorGoodsPriceUWork = new GoodsPriceUWork();   // 前回ユーザー価格ワーク
        //private GoodsPriceUWork CashGoodsPriceUwork = new GoodsPriceUWork();    // 書込価格ワーク
        //private GoodsPriceUWork PriorOfrGoodsPriceUWork = new GoodsPriceUWork(); // 前回提供価格ワーク

        //private GoodsPriceUWork writeGoodsPriseUwork = new GoodsPriceUWork();   // 新規用価格ワーク
        //private GoodsUWork PriGoodsUWork = new GoodsUWork();                    // 前回商品ワーク

        #endregion

        #region [ マージ処理 ]

        /// <summary>
        /// マージ対象のユーザーDBデータを取得する。
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="lstPMaker"></param>
        /// <param name="retList"></param>
        /// <returns></returns>
        public int GetMergeObject(MergeObjectCond cond, ArrayList lstPMaker, out object retList)
        {
            int status = 0;
            CustomSerializeArrayList ret = new CustomSerializeArrayList();
            retList = ret;

            SqlConnection sqlConnection = CreateSqlConnection();
            SqlTransaction sqlTransaction = null;
            if (sqlConnection == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }

　           sqlConnection.Open();
            try
            {
                if (cond.PMakerFlg == 1)
                {
                    ArrayList retPMakerLst = null;
                    MakerUDB MakerUDB = new MakerUDB();
                    MakerUWork MakerUWork = new MakerUWork();
                    MakerUWork.EnterpriseCode = cond.EnterpriseCode;
                    status = MakerUDB.SearchMakerProc(out retPMakerLst, MakerUWork, 0,
                            ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection);
                    if (status == 0)
                        ret.Add(retPMakerLst);
                }

                if (cond.ModelNameFlg == 1 && status == 0)
                {
                    ArrayList retModelNameLst = new ArrayList();
                    ModelNameUDB ModelNameUDB = new ModelNameUDB();

                    foreach (ModelNameUWork ModelNameUWork in lstPMaker)
                    {
                        //ModelNameUWork ModelNameUWork = new ModelNameUWork();
                        status = ModelNameUDB.Search(ref retModelNameLst, ModelNameUWork, 0, ConstantManagement.LogicalMode.GetDataAll,
                                ref sqlConnection, ref sqlTransaction);
                        if (status != 0 && status != 4)
                            break;
                    }
                    if (status == 0 || status == 4)
                        ret.Add(retModelNameLst);
                }

                if (cond.GoodsMGroupFlg == 1 && (status == 0 || status == 4))
                {
                    ArrayList retGoodsGroupLst = new ArrayList();
                    GoodsGroupUDB GoodsGroupUDB = new GoodsGroupUDB();
                    GoodsGroupUWork GoodsGroupUWork = new GoodsGroupUWork();
                    GoodsGroupUWork.EnterpriseCode = cond.EnterpriseCode;
                    status = GoodsGroupUDB.Search(ref retGoodsGroupLst, GoodsGroupUWork, 0, ConstantManagement.LogicalMode.GetDataAll,
                        ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        ret.Add(retGoodsGroupLst);
                }

                if (cond.BLGroupFlg == 1 && status == 0)
                {
                    ArrayList retBLGroupLst = new ArrayList();
                    BLGroupUDB BLGroupUDB = new BLGroupUDB();
                    BLGroupUWork BLGroupUWork = new BLGroupUWork();
                    BLGroupUWork.EnterpriseCode = cond.EnterpriseCode;
                    status = BLGroupUDB.Search(ref retBLGroupLst, BLGroupUWork, 0, ConstantManagement.LogicalMode.GetDataAll,
                        ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        ret.Add(retBLGroupLst);
                }

                if (cond.BLFlg == 1 && status == 0)
                {
                    ArrayList retBLGoodsCodeLst = null;
                    BLGoodsCdUDB BLGoodsCdUDB = new BLGoodsCdUDB();
                    BLGoodsCdUWork BLGoodsCdUWork = new BLGoodsCdUWork();
                    BLGoodsCdUWork.EnterpriseCode = cond.EnterpriseCode;
                    status = BLGoodsCdUDB.SearchBLGoodsCdProc(out retBLGoodsCodeLst, BLGoodsCdUWork, 0,
                        ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection);
                    if (status == 0)
                        ret.Add(retBLGoodsCodeLst);
                }

                #region DELETE
                //if (cond.SupplierFlg == 1 && status == 0)
                //{
                //    SupplierDB SupplierDB = new SupplierDB();
                //    SupplierWork SupplierWork = new SupplierWork();
                //    SupplierWork.EnterpriseCode = cond.EnterpriseCode;
                //    status = SupplierDB.Search(out retSupplierLst, SupplierWork, 0,
                //        ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);
                //    if (status == 0)
                //        ret.Add(retSupplierLst);
                //}
                #endregion

                if (cond.PartsPosFlg == 1 && status == 0)
                {
                    ArrayList retPartsPosLst = new ArrayList();
                    PartsPosCodeUDB PartsPosCodeUDB = new PartsPosCodeUDB();
                    PartsPosCodeUWork PartsPosCodeUWork = new PartsPosCodeUWork();
                    PartsPosCodeUWork.EnterpriseCode = cond.EnterpriseCode;
                    PartsPosCodeUWork.CustomerCode = 0; // 共通設定のみ取得
                    status = PartsPosCodeUDB.Search(ref retPartsPosLst, PartsPosCodeUWork, 0,
                        ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        ret.Add(retPartsPosLst);
                }

                if (cond.PrmSetFlg == 1 && status == 0)
                {
                    ArrayList retPrmSetLst = new ArrayList();
                    PrmSettingUDB PrmSettingUDB = new PrmSettingUDB();
                    PrmSettingUWork PrmSettingUWork = new PrmSettingUWork();
                    PrmSettingUWork.EnterpriseCode = cond.EnterpriseCode;
                    PrmSettingUWork.PrimeDisplayCode = -1;  // ADD 2011/05/25 ＢＬコード０のレコードも削除対象とするため、優良設定を全て取得
                    status = PrmSettingUDB.Search(ref retPrmSetLst, PrmSettingUWork, 0,
                        ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        ret.Add(retPrmSetLst);
                }
            }
            catch
            {
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();

                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        /// <summary>
        /// データを渡し、マージ処理を行う。
        /// </summary>
        /// <param name="updateDataDiv">更新データ区分(0:ＵＩ　1:自動)[履歴記録用]</param>
        /// <param name="offerDate">提供日付[履歴記録用]</param>
        /// <param name="lstData"></param>
        /// <returns></returns>
        /// 
        public int WriteMergeData(int updateDataDiv, int offerDate, object lstData)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null)
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            SqlTransaction sqlTransaction = null;

            try
            {
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction();
                //status = WriteMergeDataProc(updateDataDiv, offerDate, lstData, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                base.WriteErrorLog(ex, "マージ処理失敗");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                    sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// データを渡し、マージ処理を行う。
        /// </summary>
        /// <param name="updateDataDiv">更新データ区分(0:ＵＩ　1:自動)[履歴記録用]</param>
        /// <param name="offerDate">提供日付[履歴記録用]</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="lstData"></param>
        /// <param name="blCodeOfferDate"></param>
        /// <param name="blGroupOfferDate"></param>
        /// <param name="goodsMGroupOfferDate"></param>
        /// <param name="makerOfferDate"></param>
        /// <param name="modelNameOfferDate"></param>
        /// <param name="partsPosOffrDate"></param>
        /// <param name="updateMasterFlg"></param>
        /// <returns></returns>
        /// 
        public int WriteMergeDataProc(int updateDataDiv, int offerDate, object lstData, MergeObjectCond updateMasterFlg, SqlConnection sqlConnection, SqlTransaction sqlTransaction
            , int makerOfferDate, int modelNameOfferDate, int goodsMGroupOfferDate, int blGroupOfferDate, int blCodeOfferDate, int partsPosOffrDate, int partsPsDate)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            _updateDataDiv = updateDataDiv;
            _offerDate = offerDate;
            CustomSerializeArrayList lstUsrUpdateData = lstData as CustomSerializeArrayList;

            status = WriteMergeDataProc(lstUsrUpdateData, updateMasterFlg, sqlConnection, sqlTransaction, updateDataDiv
                , makerOfferDate, modelNameOfferDate, goodsMGroupOfferDate, blGroupOfferDate, blCodeOfferDate, partsPosOffrDate, partsPsDate);

            return status;
        }

        private int WriteMergeDataProc(CustomSerializeArrayList lstUsrUpdateData, MergeObjectCond updateMasterFlg, SqlConnection sqlConnection, SqlTransaction sqlTransaction, int updateDataDiv
            , int makerOfferDate, int modelNameOfferDate, int goodsMGroupOfferDate, int blGroupOfferDate, int blCodeOfferDate, int partsPosOffrDate,int partspsDate)
        {
            int status = 0;

            ArrayList usrUpdatePMakerLst = null; // ユーザー部品メーカー名称更新データリスト
            ArrayList usrUpdateModelNameLst = null; // ユーザー車種マスタ更新データリスト
            ArrayList usrUpdateGoodsMGrpLst = null; // ユーザー商品中分類マスタ更新データリスト
            ArrayList usrUpdateBLGroupLst = null; // ユーザーBLグループマスタ更新データリスト
            ArrayList usrUpdateTbsPartsCodeLst = null; // ユーザーBLコード更新データリスト
            //ArrayList usrUpdateSupplierLst    = null; // ユーザー仕入先マスタ更新データリスト
            ArrayList usrUpdatePartsPosLst = null; // ユーザー部位マスタ更新データリスト

            // **Add 2009/1/15 sakurai**
            //ArrayList usrUpdatePrmSettingLst = null; // 優良設定マスタ更新データリスト
            ArrayList usrUpdateGoodsMngLst = null; // 商品管理情報マスタ
            // **Add 2009/1/15 sakurai**           

            ArrayList historyList = new ArrayList();    // 価格改正履歴リスト

            for (int i = 0; i < lstUsrUpdateData.Count; i++)
            {
                switch (((ArrayList)lstUsrUpdateData[i])[0].GetType().Name)
                {
                    case "MakerUWork":
                        usrUpdatePMakerLst = lstUsrUpdateData[i] as ArrayList; // ユーザー部品メーカー名称更新データリスト
                        break;
                    case "ModelNameUWork":
                        usrUpdateModelNameLst = lstUsrUpdateData[i] as ArrayList; // ユーザー車種マスタ更新データリスト
                        break;
                    case "GoodsGroupUWork":
                        usrUpdateGoodsMGrpLst = lstUsrUpdateData[i] as ArrayList; // ユーザー商品中分類マスタ更新データリスト
                        break;
                    case "BLGroupUWork":
                        usrUpdateBLGroupLst = lstUsrUpdateData[i] as ArrayList; // ユーザーBLグループマスタ更新データリスト
                        break;
                    case "BLGoodsCdUWork":
                        usrUpdateTbsPartsCodeLst = lstUsrUpdateData[i] as ArrayList; // ユーザーBLコード更新データリスト
                        break;
                    //case "SupplierWork":
                    //    usrUpdateSupplierLst  = lstUsrUpdateData[i] as ArrayList; // ユーザー仕入先マスタ
                    //    break;
                    case "PartsPosCodeUWork":
                        usrUpdatePartsPosLst = lstUsrUpdateData[i] as ArrayList; // ユーザー部位マスタ
                        break;
                    //case "PrmSettingUWork":
                    //    usrUpdatePrmSettingLst = lstUsrUpdateData[i] as ArrayList; // ユーザー優良設定マスタ
                    //    break;
                    case "GoodsMngWork":
                        usrUpdateGoodsMngLst = lstUsrUpdateData[i] as ArrayList; // ユーザー商品管理情報設定マスタ 
                        break;
                }
            }

            //SqlConnection sqlConnection = CreateSqlConnection();
            //if (sqlConnection == null)
            //{
            //    return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            //}
            //SqlTransaction sqlTransaction = null;
            try
            {
                //sqlConnection.Open();
                //sqlTransaction = sqlConnection.BeginTransaction();
                PriUpdTblUpdHisWork hist;

                

                // ﾒｰｶｰ
                if (usrUpdatePMakerLst != null)
                {
                    MakerUDB MakerUDB = new MakerUDB();
                    status = MakerUDB.WriteMakerProc(ref usrUpdatePMakerLst, ref sqlConnection, ref sqlTransaction);
                }
                // ﾒｰｶｰ履歴
                if (updateMasterFlg.PMakerFlg == 1)
                {
                    hist = MakeHistInfo();
                    hist.SyncTableID = "MAKERURF";
                    hist.SyncTableName = "メーカーマスタ";
                    if (status == 0)
                    {
                        if (usrUpdatePMakerLst == null)
                        {
                            // 更新リストがない場合前回提供日付で履歴書き込み
                            hist.AddUpdateRowsNo = 0;
                            hist.OfferDate = makerOfferDate;

                        }
                        else
                        {
                            // 更新リストがあれば最終提供日付で履歴書き込み
                            hist.AddUpdateRowsNo = usrUpdatePMakerLst.Count;
                            MakerUWork lastMaker = usrUpdatePMakerLst[usrUpdatePMakerLst.Count - 1] as MakerUWork;
                            hist.OfferDate = int.Parse((lastMaker.OfferDate).ToString("yyyyMMdd"));
                        }
                    }
                    else
                    {
                        hist.AddUpdateRowsNo = status;
                        hist.OfferDate = makerOfferDate;
                    }
                    historyList.Add(hist);
                }

                // 車種
                if (usrUpdateModelNameLst != null && status == 0)
                {
                    ModelNameUDB ModelNameUDB = new ModelNameUDB();
                    status = ModelNameUDB.Write(ref usrUpdateModelNameLst, ref sqlConnection, ref sqlTransaction);
                }
                // 車種履歴
                if (updateMasterFlg.ModelNameFlg == 1)
                {
                    hist = MakeHistInfo();
                    hist.SyncTableID = "MODELNAMEURF";
                    hist.SyncTableName = "車種マスタ";
                    if (status == 0)
                    {
                        if (usrUpdateModelNameLst != null)
                        {
                            hist.AddUpdateRowsNo = usrUpdateModelNameLst.Count;
                            ModelNameUWork lastModel = usrUpdateModelNameLst[usrUpdateModelNameLst.Count - 1] as ModelNameUWork;
                            hist.OfferDate = int.Parse((lastModel.OfferDate).ToString("yyyyMMdd"));
                        }
                        else
                        {
                            hist.AddUpdateRowsNo = 0;
                            hist.OfferDate = modelNameOfferDate;
                        }
                    }


                    else
                    {
                        hist.AddUpdateRowsNo = status;
                        hist.OfferDate = modelNameOfferDate;
                    }
                    historyList.Add(hist);
                }

                // 中分類
                if (usrUpdateGoodsMGrpLst != null && status == 0)
                {
                    GoodsGroupUDB GoodsGroupUDB = new GoodsGroupUDB();
                    status = GoodsGroupUDB.Write(ref usrUpdateGoodsMGrpLst, ref sqlConnection, ref sqlTransaction);
                }
                // 中分類履歴
                if (updateMasterFlg.GoodsMGroupFlg == 1)
                {
                    hist = MakeHistInfo();
                    hist.SyncTableID = "GOODSGROUPURF";
                    hist.SyncTableName = "中分類マスタ";
                    if (status == 0)
                    {
                        if (usrUpdateGoodsMGrpLst != null)
                        {
                            hist.AddUpdateRowsNo = usrUpdateGoodsMGrpLst.Count;
                            GoodsGroupUWork lastGoodsM = usrUpdateGoodsMGrpLst[usrUpdateGoodsMGrpLst.Count - 1] as GoodsGroupUWork;
                            hist.OfferDate = int.Parse((lastGoodsM.OfferDate).ToString("yyyyMMdd"));
                        }
                        else
                        {
                            hist.AddUpdateRowsNo = 0;
                            hist.OfferDate = goodsMGroupOfferDate;
                        }
                    }
                    else
                    {
                        hist.AddUpdateRowsNo = status;
                        hist.OfferDate = goodsMGroupOfferDate;
                    }
                    historyList.Add(hist);
                }

                // BLｸﾞﾙｰﾌﾟ
                if (usrUpdateBLGroupLst != null && status == 0)
                {
                    BLGroupUDB BLGroupUDB = new BLGroupUDB();
                    status = BLGroupUDB.Write(ref usrUpdateBLGroupLst, ref sqlConnection, ref sqlTransaction);
                }
                // BLｸﾞﾙｰﾌﾟ履歴
                if (updateMasterFlg.BLGroupFlg == 1)
                {
                    hist = MakeHistInfo();
                    hist.SyncTableID = "BLGROUPURF";

                    hist.SyncTableName = "BLグループマスタ";
                    if (status == 0)
                    {
                        if (usrUpdateBLGroupLst != null)
                        {
                            hist.AddUpdateRowsNo = usrUpdateBLGroupLst.Count;
                            BLGroupUWork lastBLGroup = usrUpdateBLGroupLst[usrUpdateBLGroupLst.Count - 1] as BLGroupUWork;
                            hist.OfferDate = int.Parse((lastBLGroup.OfferDate).ToString("yyyyMMdd"));
                        }
                        else
                        {
                            hist.AddUpdateRowsNo = 0;
                            hist.OfferDate = blGroupOfferDate;
                        }
                    }
                    else
                    {
                        hist.AddUpdateRowsNo = status;
                        hist.OfferDate = blGroupOfferDate;
                    }
                    historyList.Add(hist);
                }
                // BLｺｰﾄﾞ
                if (usrUpdateTbsPartsCodeLst != null && status == 0)
                {
                    BLGoodsCdUDB BLGoodsCdUDB = new BLGoodsCdUDB();
                    status = BLGoodsCdUDB.WriteBLGoodsCdProc(ref usrUpdateTbsPartsCodeLst, ref sqlConnection, ref sqlTransaction);
                }
                // BLｺｰﾄﾞ履歴
                if (updateMasterFlg.BLFlg == 1)
                {
                    hist = MakeHistInfo();
                    hist.SyncTableID = "BLGOODSCDURF";
                    hist.SyncTableName = "BLコードマスタ";
                    if (status == 0)
                    {
                        if (usrUpdateTbsPartsCodeLst != null)
                        {
                            hist.AddUpdateRowsNo = usrUpdateTbsPartsCodeLst.Count;
                            BLGoodsCdUWork lastBLCode = usrUpdateTbsPartsCodeLst[usrUpdateTbsPartsCodeLst.Count - 1] as BLGoodsCdUWork;
                            hist.OfferDate = int.Parse((lastBLCode.OfferDate).ToString("yyyyMMdd"));
                        }
                        else
                        {
                            hist.OfferDate = blCodeOfferDate;
                            hist.AddUpdateRowsNo = 0;
                        }
                    }
                    else
                    {
                        hist.AddUpdateRowsNo = status;
                        hist.OfferDate = blCodeOfferDate;
                    }
                    historyList.Add(hist);
                }
                #region DELETE
                //if (usrUpdateSupplierLst != null && status == 0)
                //{ // PMKHN09024
                //    SupplierDB SupplierDB = new SupplierDB();
                //    status = SupplierDB.Write(ref usrUpdateSupplierLst, ref sqlConnection, ref sqlTransaction);
                //}
                #endregion

                // 部位
                if (usrUpdatePartsPosLst != null && status == 0)
                {
                    PartsPosCodeUDB PartsPosCodeUDB = new PartsPosCodeUDB();
                    //status = PartsPosCodeUDB.Write(ref usrUpdatePartsPosLst, ref sqlConnection, ref sqlTransaction);
                    status = writePartsPosCd(ref usrUpdatePartsPosLst, ref sqlConnection, ref sqlTransaction);
                }
                // 部位マスタ
                if (updateMasterFlg.PartsPosFlg == 1)
                {
                    hist = MakeHistInfo();
                    hist.SyncTableID = "PARTSPOSCODEURF";
                    hist.SyncTableName = "部位マスタ";
                    if (status == 0)
                    {
                        if (usrUpdatePartsPosLst != null)
                        {
                            hist.AddUpdateRowsNo = usrUpdatePartsPosLst.Count;
                            hist.OfferDate = partspsDate;
                        }
                        else
                        {
                            hist.AddUpdateRowsNo = 0;
                            hist.OfferDate = partsPosOffrDate;
                        }
                    }
                    else
                    {
                        hist.AddUpdateRowsNo = status;
                        hist.OfferDate = partsPosOffrDate;
                    }
                    historyList.Add(hist);
                }
                #region DELETE
                //if (usrUpdatePrmSettingLst != null && status == 0)
                //{
                //    PrmSettingUDB PrmSettingUDB = new PrmSettingUDB();

                //    ArrayList DelPrmSettingList;
                //    ArrayList InsPrmSettingList;

                //    status = CreatePrmSetWork(ref usrUpdatePrmSettingLst, out DelPrmSettingList, out InsPrmSettingList);

                //    if (DelPrmSettingList.Count != 0 && DelPrmSettingList != null)
                //    {
                //        status = PrimeSettingDelete(DelPrmSettingList, ref sqlConnection, ref sqlTransaction);
                //    }
                //    if (InsPrmSettingList.Count != 0 && InsPrmSettingList != null)
                //    {
                //        status = PrmSettingWrite(ref InsPrmSettingList, ref sqlConnection, ref sqlTransaction);

                //    }

                //    hist = MakeHistInfo();
                //    hist.SyncTableID = "PRMSETTINGURF";
                //    hist.SyncTableName = "優良設定マスタ";
                //    if (status == 0)
                //        hist.AddUpdateRowsNo = usrUpdatePrmSettingLst.Count;
                //    else
                //        hist.AddUpdateRowsNo = status;
                //    historyList.Add(hist);
                //}
                #endregion

                #region DELETE
                //if (usrUpdateGoodsMngLst != null && status == 0)
                //{
                //    GoodsMngDB GoodsMngDB = new GoodsMngDB();
                //    status = GoodsMngDB.WriteGoodsMngProc(ref usrUpdateGoodsMngLst, ref sqlConnection, ref sqlTransaction);

                //    hist = MakeHistInfo();
                //    hist.SyncTableID = "GOODSMNGWORK";
                //    hist.SyncTableName = "商品管理情報マスタ";
                //    if (status == 0)
                //        hist.AddUpdateRowsNo = usrUpdateGoodsMngLst.Count;
                //    else
                //        hist.AddUpdateRowsNo = status;
                //    historyList.Add(hist);
                //}
                #endregion

                if (status == 0)
                {
                    //sqlTransaction.Commit();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    //sqlTransaction.Rollback();
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                WriteHistoryProc(ref historyList, sqlConnection, sqlTransaction); // 履歴記録
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                base.WriteErrorLog(ex, "マージ処理失敗");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //if (sqlTransaction != null)
                //    sqlTransaction.Dispose();
                //if (sqlConnection != null)
                //    sqlConnection.Dispose();
            }
            return status;
        }

        /// <summary>
        /// 部位マスタ更新
        /// </summary>
        private int writePartsPosCd(ref ArrayList usrUpdatePartsPosLst, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (usrUpdatePartsPosLst != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < usrUpdatePartsPosLst.Count; i++)
                    {
                        PartsPosCodeUWork partsPosCodeUWork = usrUpdatePartsPosLst[i] as PartsPosCodeUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PARTSPOSCODEURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE" + Environment.NewLine;
                        sqlText += "  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaSearchPartsPosCode = sqlCommand.Parameters.Add("@FINDSEARCHPARTSPOSCODE", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);


                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                        findParaSectionCode.Value = partsPosCodeUWork.SectionCode;
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                        findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE PARTSPOSCODEURF SET" + Environment.NewLine;
                            sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " , SEARCHPARTSPOSCODERF=@SEARCHPARTSPOSCODE" + Environment.NewLine;
                            sqlText += " , SEARCHPARTSPOSNAMERF=@SEARCHPARTSPOSNAME" + Environment.NewLine;
                            sqlText += " , POSDISPORDERRF=@POSDISPORDER" + Environment.NewLine;
                            sqlText += " , TBSPARTSCODERF=@TBSPARTSCODE" + Environment.NewLine;
                            sqlText += " , TBSPARTSCDDERIVEDNORF=@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                            sqlText += " , OFFERDATERF = @OFFERDATE" + Environment.NewLine;
                            sqlText += " , OFFERDATADIVRF = @OFFERDATADIV" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE" + Environment.NewLine;
                            sqlText += "  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                            findParaSectionCode.Value = partsPosCodeUWork.SectionCode;
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                            findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)partsPosCodeUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO PARTSPOSCODEURF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += "  ,SEARCHPARTSPOSCODERF" + Environment.NewLine;
                            sqlText += "  ,SEARCHPARTSPOSNAMERF" + Environment.NewLine;
                            sqlText += "  ,POSDISPORDERRF" + Environment.NewLine;
                            sqlText += "  ,TBSPARTSCODERF" + Environment.NewLine;
                            sqlText += "  ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                            sqlText += "  , OFFERDATERF" + Environment.NewLine;
                            sqlText += "  , OFFERDATADIVRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "  ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "  ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  ,@SEARCHPARTSPOSCODE" + Environment.NewLine;
                            sqlText += "  ,@SEARCHPARTSPOSNAME" + Environment.NewLine;
                            sqlText += "  ,@POSDISPORDER" + Environment.NewLine;
                            sqlText += "  ,@TBSPARTSCODE" + Environment.NewLine;
                            sqlText += "  ,@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                            sqlText += "  ,@OFFERDATE" + Environment.NewLine;
                            sqlText += "  ,@OFFERDATADIV" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)partsPosCodeUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraSearchPartsPosCode = sqlCommand.Parameters.Add("@SEARCHPARTSPOSCODE", SqlDbType.Int);
                        SqlParameter paraSearchPartsPosName = sqlCommand.Parameters.Add("@SEARCHPARTSPOSNAME", SqlDbType.NVarChar);
                        SqlParameter paraPosDispOrder = sqlCommand.Parameters.Add("@POSDISPORDER", SqlDbType.Int);
                        SqlParameter paraTbsPartsCode = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);
                        SqlParameter paraTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@TBSPARTSCDDERIVEDNO", SqlDbType.Int);
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);  // 提供日付
                        SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);  // 提供データ区分
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(partsPosCodeUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(partsPosCodeUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(partsPosCodeUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.LogicalDeleteCode);
                        paraSectionCode.Value = partsPosCodeUWork.SectionCode;  //キー項目の為、SqlDataMediatorは使用しない
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                        paraSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                        paraSearchPartsPosName.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.SearchPartsPosName);
                        paraPosDispOrder.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.PosDispOrder);
                        paraTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);
                        paraTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCdDerivedNo);
                        paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(partsPosCodeUWork.OfferDate);  // 提供日付
                        paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.OfferDataDiv);  // 提供データ区分
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(partsPosCodeUWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                //status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            usrUpdatePartsPosLst = al;

            return status;
        }


        /// <summary>
        /// 優良設定更新･削除リスト作成
        /// </summary>
        private int CreatePrmSetWork(ref ArrayList usrUpdatePrmSettingLst, out ArrayList DelPrmSettingList, out ArrayList InsPrmSettingList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            DelPrmSettingList = new ArrayList();
            InsPrmSettingList = new ArrayList();

            foreach (PrmSettingUWork prmSetWork in usrUpdatePrmSettingLst)
            {
                if (prmSetWork.LogicalDeleteCode == 0)
                {
                    #region Writeデータ格納
                    PrmSettingUWork writeWork = new PrmSettingUWork();

                    writeWork.CreateDateTime = prmSetWork.CreateDateTime;
                    writeWork.EnterpriseCode = prmSetWork.EnterpriseCode;
                    writeWork.FileHeaderGuid = prmSetWork.FileHeaderGuid;
                    writeWork.GoodsMGroup = prmSetWork.GoodsMGroup;
                    writeWork.LogicalDeleteCode = prmSetWork.LogicalDeleteCode;
                    writeWork.MakerDispOrder = prmSetWork.MakerDispOrder;
                    writeWork.OfferDate = prmSetWork.OfferDate;
                    writeWork.PartsMakerCd = prmSetWork.PartsMakerCd;
                    writeWork.PrimeDisplayCode = prmSetWork.PrimeDisplayCode;
                    writeWork.PrimeDispOrder = prmSetWork.PrimeDispOrder;
                    writeWork.PrmSetDtlName1 = prmSetWork.PrmSetDtlName1;
                    writeWork.PrmSetDtlName2 = prmSetWork.PrmSetDtlName2;
                    writeWork.PrmSetDtlNo1 = prmSetWork.PrmSetDtlNo1;
                    writeWork.PrmSetDtlNo2 = prmSetWork.PrmSetDtlNo2;
                    writeWork.SectionCode = prmSetWork.SectionCode;
                    writeWork.TbsPartsCdDerivedNo = prmSetWork.TbsPartsCdDerivedNo;
                    writeWork.TbsPartsCode = prmSetWork.TbsPartsCode;
                    writeWork.UpdAssemblyId1 = prmSetWork.UpdAssemblyId1;
                    writeWork.UpdAssemblyId2 = prmSetWork.UpdAssemblyId2;
                    //writeWork.UpdateDateTime      = prmSetWork.UpdateDateTime;
                    writeWork.UpdEmployeeCode = prmSetWork.UpdEmployeeCode;

                    InsPrmSettingList.Add(writeWork);
                    #endregion
                }
                else if (prmSetWork.LogicalDeleteCode == 2)
                {
                    #region Deleteデータ格納
                    PrmSettingUWork deleteWork = new PrmSettingUWork();

                    deleteWork.CreateDateTime = prmSetWork.CreateDateTime;
                    deleteWork.EnterpriseCode = prmSetWork.EnterpriseCode;
                    deleteWork.FileHeaderGuid = prmSetWork.FileHeaderGuid;
                    deleteWork.GoodsMGroup = prmSetWork.GoodsMGroup;
                    deleteWork.LogicalDeleteCode = prmSetWork.LogicalDeleteCode;
                    deleteWork.MakerDispOrder = prmSetWork.MakerDispOrder;
                    deleteWork.OfferDate = prmSetWork.OfferDate;
                    deleteWork.PartsMakerCd = prmSetWork.PartsMakerCd;
                    deleteWork.PrimeDisplayCode = prmSetWork.PrimeDisplayCode;
                    deleteWork.PrimeDispOrder = prmSetWork.PrimeDispOrder;
                    deleteWork.PrmSetDtlName1 = prmSetWork.PrmSetDtlName1;
                    deleteWork.PrmSetDtlName2 = prmSetWork.PrmSetDtlName2;
                    deleteWork.PrmSetDtlNo1 = prmSetWork.PrmSetDtlNo1;
                    deleteWork.PrmSetDtlNo2 = prmSetWork.PrmSetDtlNo2;
                    deleteWork.SectionCode = prmSetWork.SectionCode;
                    deleteWork.TbsPartsCdDerivedNo = prmSetWork.TbsPartsCdDerivedNo;
                    deleteWork.TbsPartsCode = prmSetWork.TbsPartsCode;
                    deleteWork.UpdAssemblyId1 = prmSetWork.UpdAssemblyId1;
                    deleteWork.UpdAssemblyId2 = prmSetWork.UpdAssemblyId2;
                    deleteWork.UpdateDateTime = prmSetWork.UpdateDateTime;
                    deleteWork.UpdEmployeeCode = prmSetWork.UpdEmployeeCode;

                    DelPrmSettingList.Add(prmSetWork);
                    #endregion
                }
            }
            return status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報を追加・更新します。
        /// </summary>
        /// <param name="prmSettingUList">追加・更新する優良設定マスタ（ユーザー登録分）情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PrmSettingUList に格納されている優良設定マスタ（ユーザー登録分）情報を追加・更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        /// <br></br>
        /// <br>Update Note: 11070266-00　SCM高速化 Ｃ向け種別対応 </br>
        /// <br>Programmer : 30757 佐々木 貴英</br>
        /// <br>Date       : 2015/02/25</br>
        /// <br></br>
        /// </remarks>
        private int PrmSettingWrite(ref ArrayList prmSettingUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (prmSettingUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < prmSettingUList.Count; i++)
                    {
                        PrmSettingUWork prmSettingUWork = prmSettingUList[i] as PrmSettingUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                        sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                        SqlParameter findParaPartsMakerCd = sqlCommand.Parameters.Add("@FINDPARTSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo1 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO1", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                        findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                        findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                        findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE PRMSETTINGURF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += " , GOODSMGROUPRF=@GOODSMGROUP" + Environment.NewLine;
                            sqlText += " , TBSPARTSCODERF=@TBSPARTSCODE" + Environment.NewLine;
                            sqlText += " , TBSPARTSCDDERIVEDNORF=@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                            sqlText += " , MAKERDISPORDERRF=@MAKERDISPORDER" + Environment.NewLine;
                            sqlText += " , PARTSMAKERCDRF=@PARTSMAKERCD" + Environment.NewLine;
                            sqlText += " , PRIMEDISPORDERRF=@PRIMEDISPORDER" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNO1RF=@PRMSETDTLNO1" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNAME1RF=@PRMSETDTLNAME1" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNO2RF=@PRMSETDTLNO2" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNAME2RF=@PRMSETDTLNAME2" + Environment.NewLine;
                            sqlText += " , PRIMEDISPLAYCODERF=@PRIMEDISPLAYCODE" + Environment.NewLine;
                            sqlText += " , OFFERDATERF = @OFFERDATE" + Environment.NewLine;
                            //---ADD　30757 佐々木　貴英　2015/02/25 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                            sqlText += " ,PRMSETDTLNAME2FORFACRF=@PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                            sqlText += " ,PRMSETDTLNAME2FORCOWRF=@PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                            //---ADD　30757 佐々木　貴英　2015/02/25 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                            sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                            sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                            findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                            findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                            findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)prmSettingUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO PRMSETTINGURF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "    ,GOODSMGROUPRF" + Environment.NewLine;
                            sqlText += "    ,TBSPARTSCODERF" + Environment.NewLine;
                            sqlText += "    ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                            sqlText += "    ,MAKERDISPORDERRF" + Environment.NewLine;
                            sqlText += "    ,PARTSMAKERCDRF" + Environment.NewLine;
                            sqlText += "    ,PRIMEDISPORDERRF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNO1RF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME1RF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNO2RF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME2RF" + Environment.NewLine;
                            sqlText += "    ,PRIMEDISPLAYCODERF" + Environment.NewLine;
                            sqlText += "    ,OFFERDATERF" + Environment.NewLine;
                            //---ADD　30757 佐々木　貴英　2015/02/25 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                            sqlText += "    ,PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                            //---ADD　30757 佐々木　貴英　2015/02/25 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "    ,@GOODSMGROUP" + Environment.NewLine;
                            sqlText += "    ,@TBSPARTSCODE" + Environment.NewLine;
                            sqlText += "    ,@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                            sqlText += "    ,@MAKERDISPORDER" + Environment.NewLine;
                            sqlText += "    ,@PARTSMAKERCD" + Environment.NewLine;
                            sqlText += "    ,@PRIMEDISPORDER" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNO1" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME1" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNO2" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME2" + Environment.NewLine;
                            sqlText += "    ,@PRIMEDISPLAYCODE" + Environment.NewLine;
                            sqlText += "    ,@OFFERDATE" + Environment.NewLine;
                            //---ADD　30757 佐々木　貴英　2015/02/25 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                            sqlText += "    ,@PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                            //---ADD　30757 佐々木　貴英　2015/02/25 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)prmSettingUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraTbsPartsCode = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);
                        SqlParameter paraTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@TBSPARTSCDDERIVEDNO", SqlDbType.Int);
                        SqlParameter paraMakerDispOrder = sqlCommand.Parameters.Add("@MAKERDISPORDER", SqlDbType.Int);
                        SqlParameter paraPartsMakerCd = sqlCommand.Parameters.Add("@PARTSMAKERCD", SqlDbType.Int);
                        SqlParameter paraPrimeDispOrder = sqlCommand.Parameters.Add("@PRIMEDISPORDER", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlNo1 = sqlCommand.Parameters.Add("@PRMSETDTLNO1", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlName1 = sqlCommand.Parameters.Add("@PRMSETDTLNAME1", SqlDbType.NVarChar);
                        SqlParameter paraPrmSetDtlNo2 = sqlCommand.Parameters.Add("@PRMSETDTLNO2", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlName2 = sqlCommand.Parameters.Add("@PRMSETDTLNAME2", SqlDbType.NVarChar);
                        SqlParameter paraPrimeDisplayCode = sqlCommand.Parameters.Add("@PRIMEDISPLAYCODE", SqlDbType.Int);
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                        //---ADD　30757 佐々木　貴英　2015/02/25 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                        SqlParameter paraPrmSetDtlName2ForFac = sqlCommand.Parameters.Add("@PRMSETDTLNAME2FORFACRF", SqlDbType.NVarChar);
                        SqlParameter paraPrmSetDtlName2ForCOw = sqlCommand.Parameters.Add("@PRMSETDTLNAME2FORCOWRF", SqlDbType.NVarChar);
                        //---ADD　30757 佐々木　貴英　2015/02/25 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(prmSettingUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(prmSettingUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(prmSettingUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                        paraTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                        paraTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCdDerivedNo);
                        paraMakerDispOrder.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.MakerDispOrder);
                        paraPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                        paraPrimeDispOrder.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrimeDispOrder);
                        paraPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                        paraPrmSetDtlName1.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName1);
                        paraPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);
                        paraPrmSetDtlName2.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName2);
                        paraOfferDate.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.OfferDate);

                        if (prmSettingUWork.TbsPartsCode == 0)
                        {
                            paraPrimeDisplayCode.Value = 0;
                        }
                        else
                        {
                            paraPrimeDisplayCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrimeDisplayCode);
                        }
                        //---ADD　30757 佐々木　貴英　2015/02/25 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                        paraPrmSetDtlName2ForFac.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName2ForFac);
                        paraPrmSetDtlName2ForCOw.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName2ForCOw);
                        //---ADD　30757 佐々木　貴英　2015/02/25 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(prmSettingUWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
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

            prmSettingUList = al;

            return status;
        }

        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）情報を物理削除します
        /// </summary>
        /// <param name="prmSettingUList">優良設定マスタ（ユーザー登録分）情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUList に格納されている優良設定マスタ（ユーザー登録分）情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        private int PrimeSettingDelete(ArrayList prmSettingUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            try
            {
                if (prmSettingUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < prmSettingUList.Count; i++)
                    {
                        PrmSettingUWork prmSettingUWork = prmSettingUList[i] as PrmSettingUWork;

                        # region [DELETE文]
                        sqlText = string.Empty;
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                        sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                        SqlParameter findParaPartsMakerCd = sqlCommand.Parameters.Add("@FINDPARTSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo1 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO1", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int);

                        // KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                        findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                        findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                        findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                        
                        
                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }




        /// <summary>
        /// 履歴情報作成
        /// </summary>
        private PriUpdTblUpdHisWork MakeHistInfo()
        {
            DateTime dt = DateTime.Now;
            PriUpdTblUpdHisWork hist = new PriUpdTblUpdHisWork();
            hist.SyncExecuteDate = (dt.Year * 10000) + (dt.Month * 100) + dt.Day;
            hist.DataUpdateDateTime = dt.Ticks;
            hist.OfferDate = _offerDate;
            hist.UpdateDataDiv = _updateDataDiv;
            hist.OfferVersion = _currentVersion;

            //hist.SyncTableID = "";

            //hist.SyncTableName = "";
            //hist.AddUpdateRowsNo = 0;

            return hist;
        }
        #endregion

        #region [ 価格改正処理 ]
        /// <summary>
        /// 価格改正処理
        /// </summary>
        /// <param name="st">価格改正設定</param>
        /// <param name="lst">価格改正処理用データリスト</param>
        /// <param name="retList">処理結果のリスト</param>
        /// <returns></returns>
        public int DoPriceRevision(PriceMergeSt st, CustomSerializeArrayList lst, out object retList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retList = null;

            SqlConnection sqlConnection = CreateSqlConnection();
            SqlConnection sqlConnection2 = CreateSqlConnection();
            if (sqlConnection == null || sqlConnection2 == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            SqlTransaction sqlTransaction = null;
            try
            {
                sqlConnection.Open();
                sqlConnection2.Open();
                sqlTransaction = sqlConnection.BeginTransaction();
                //status = DoPriceRevisionProc(st, lst, out retList, sqlConnection, sqlConnection2, sqlTransaction);
            }
            catch
            {
                sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null)
                    sqlTransaction.Dispose();
                if (sqlConnection != null)
                    sqlConnection.Dispose();
                if (sqlConnection2 != null)
                    sqlConnection2.Dispose();
            }
            return status;
        }

        // 2010/04/23 Add >>>
        /// <summary>
        /// ユーザー部品検索（商品・価格・優良設定の取得
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="makerCd"></param>
        /// <param name="goodsNoList">品番リスト（商品情報フィルタ用）</param>
        /// <param name="retObj"></param>
        /// <returns></returns>
        // public int UsrPartsSearch(string enterpriseCode, string sectionCode, int makerCd, out object retObj) // DEL 2014/08/21 songg 仕掛№1923
        public int UsrPartsSearch(string enterpriseCode, string sectionCode, int makerCd, ArrayList goodsNoList, out object retObj)    // ADD 2014/08/21 songg 仕掛№1923
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            retObj = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // ADD 2014/08/21 songg 仕掛№1923 ---->>>>
                Dictionary<string, string> goodsNoDic = new Dictionary<string, string>();
                if (null != goodsNoList)
                {
                    for (int i = 0; i < goodsNoList.Count; i++)
                    {
                        string goodsNo = goodsNoList[i].ToString();
                        if (!goodsNoDic.ContainsKey(goodsNo))
                        {
                            goodsNoDic.Add(goodsNo, goodsNo);
                        }
                    }
                }
                // ADD 2014/08/21 songg 仕掛№1923 ----<<<<
           
                ArrayList goodsList;
                // status = this.UsrJoinPartsSearch(enterpriseCode, makerCd, out goodsList, ref sqlConnection, ref sqlTransaction); // DEL 2014/08/21 songg 仕掛№1923
                status = this.UsrJoinPartsSearch(enterpriseCode, makerCd, out goodsList, ref sqlConnection, ref sqlTransaction, goodsNoDic); // ADD 2014/08/21 songg 仕掛№1923

                if (goodsList != null && goodsList.Count > 0)
                {
                    retList.Add(goodsList);
                }

                ArrayList prmList;
                status = this.PrimeSettingSearch(enterpriseCode, sectionCode, makerCd, out prmList, ref sqlConnection, ref sqlTransaction);
                if (prmList != null && prmList.Count > 0)
                {
                    retList.Add(prmList);
                }

                if (( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ) &&
                    ( goodsList != null || prmList != null ))
                {
                    //該当無しステータスで対象マスタのどれか１件でも存在した場合はステータスを正常とする。
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                retObj = (object)retList;
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "OfferMergeDB.UsrPartsSearch", ex.Number);
            }
            catch
            {
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
        /// 優良設定検索
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="makerCode"></param>
        /// <param name="retList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int PrimeSettingSearch(string enterpriseCode, string sectionCode, int makerCode, out ArrayList retList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            PrmSettingUWork para = new PrmSettingUWork();
            para.EnterpriseCode = enterpriseCode;
            para.SectionCode = sectionCode;
            para.PartsMakerCd = makerCode;
            PrmSettingUDB prmSettingUDB = new PrmSettingUDB();
            retList = new ArrayList();
            return prmSettingUDB.Search(ref retList, para, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTransaction);
        }
        // 2010/04/23 Add <<<

        /// <summary>
        /// ユーザー商品･価格マスタ取得
        /// </summary>
        /// <param name="_enterpriseCode">企業コード</param>
        /// <param name="_makerCd">メーカーコード</param>
        /// <param name="retlst">処理結果のリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="goodsNoDic">検索条件</param>
        /// <returns></returns>
        // 2010/04/23 >>>
        ////private int UsrJoinPartsSearch(out ArrayList retlst, GoodsUWork DummyWork, SqlConnection sqlConnection)
        //public int UsrJoinPartsSearch(string _enterpriseCode, int _makerCd, out ArrayList retlst)
        // private int UsrJoinPartsSearch(string _enterpriseCode, int _makerCd, out ArrayList retlst, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)// DEL 2014/08/21 songg 仕掛№1923
        private int UsrJoinPartsSearch(string _enterpriseCode, int _makerCd, out ArrayList retlst, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, Dictionary<string,string> goodsNoDic)// ADD 2014/08/21 songg 仕掛№1923
        // 2010/04/23 <<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retlst = new ArrayList();

            ArrayList al = new ArrayList();

            // 2010/04/23 >>>
            //// コネクション生成
            //SqlConnection sqlConnection = CreateSqlConnection();
            // 2010/04/23 <<<

            string sqlText = "";

            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
        
            try
            {
                // ADD 2014/08/21 songg 仕掛№1923 ---->>>>
                // --- DEL 3H 王俊 2021/07/20 ---------->>>>>
                //// 1:トヨタ　2：日産
                //if (_makerCd == 1 || _makerCd == 2)
                //{
                // --- DEL 3H 王俊 2021/07/20 ----------<<<<<
                    // 一時テーブルをクリエート
                    // --- DEL 3H 王俊 2021/07/20 ---------->>>>>
                    //string createText = "CREATE TABLE #GOODSNOWORK (GOODSNO varchar(40))";
                    // --- DEL 3H 王俊 2021/07/20 ----------<<<<<
                    // --- ADD 3H 王俊 2021/07/20 ---------->>>>>
                    string createText = "CREATE TABLE #GOODSNOWORK (GOODSNO varchar(40) COLLATE DATABASE_DEFAULT)";
                    // --- ADD 3H 王俊 2021/07/20 ----------<<<<<
                    sqlCommand = new SqlCommand(createText, sqlConnection, sqlTransaction);
                    sqlCommand.ExecuteNonQuery();
                    // 一時テーブルにデータをインサート
                    string insertText = "INSERT INTO #GOODSNOWORK(GOODSNO)VALUES(@GOODSNOTEMP)";
                    sqlCommand = new SqlCommand(insertText, sqlConnection, sqlTransaction);
                    SqlParameter goodsNoTemp = sqlCommand.Parameters.Add("@GOODSNOTEMP", SqlDbType.NVarChar);
                    foreach (string key in goodsNoDic.Keys)
                    {
                        goodsNoTemp.Value = SqlDataMediator.SqlSetString(key);
                        sqlCommand.ExecuteNonQuery();
                    } 
                // --- DEL 3H 王俊 2021/07/20 ---------->>>>>
                //}
                // --- DEL 3H 王俊 2021/07/20 ----------<<<<<
                // ADD 2014/08/21 songg 仕掛№1923 ----<<<<

                
                // 2010/04/23 >>>
                //sqlConnection.Open();
                // 2010/04/23 <<<

                #region  SELECT文
                sqlText += " SELECT" + Environment.NewLine;
                sqlText += "  GOODS.BLGOODSCODERF" + Environment.NewLine;
                sqlText += " ,GOODS.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                sqlText += " ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                sqlText += " ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                sqlText += " ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                sqlText += " ,GOODS.GOODSNAMERF" + Environment.NewLine;
                sqlText += " ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                sqlText += " ,GOODS.GOODSNORF" + Environment.NewLine;
                sqlText += " ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                sqlText += " ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                sqlText += " ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                sqlText += " ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                sqlText += " ,GOODS.JANRF" + Environment.NewLine;
                sqlText += " ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,GOODS.OFFERDATADIVRF" + Environment.NewLine;
                sqlText += " ,GOODS.OFFERDATERF" + Environment.NewLine;
                sqlText += " ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                sqlText += " ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,GOODS.UPDATEDATERF" + Environment.NewLine;
                sqlText += " ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,PRICE.CREATEDATETIMERF AS PRICECREATEDATETIMERF " + Environment.NewLine;
                sqlText += " ,PRICE.UPDATEDATETIMERF AS PRICEUPDATEDATETIMERF  " + Environment.NewLine;
                sqlText += " ,PRICE.FILEHEADERGUIDRF AS PRICEFILEHEADERGUIDRF " + Environment.NewLine;
                sqlText += " ,PRICE.UPDASSEMBLYID1RF AS PRICEUPDASSEMBLYID1RF " + Environment.NewLine;
                sqlText += " ,PRICE.UPDASSEMBLYID2RF AS PRICEUPDASSEMBLYID2RF " + Environment.NewLine;
                sqlText += " ,PRICE.ENTERPRISECODERF AS PRICEENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,PRICE.UPDEMPLOYEECODERF AS PRICEUPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,PRICE.LOGICALDELETECODERF AS PRICELOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,PRICE.GOODSMAKERCDRF AS PRICEGOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " ,PRICE.GOODSNORF AS PRICEGOODSNORF" + Environment.NewLine;
                sqlText += " ,PRICE.PRICESTARTDATERF AS PRICEPRICESTARTDATERF" + Environment.NewLine;
                sqlText += " ,PRICE.LISTPRICERF AS PRICELISTPRICERF" + Environment.NewLine;
                sqlText += " ,PRICE.SALESUNITCOSTRF AS PRICESALESUNITCOSTRF" + Environment.NewLine;
                sqlText += " ,PRICE.STOCKRATERF AS PRICESTOCKRATERF" + Environment.NewLine;
                sqlText += " ,PRICE.OPENPRICEDIVRF AS PRICEOPENPRICEDIVRF" + Environment.NewLine;
                sqlText += " ,PRICE.OFFERDATERF AS PRICEOFFERDATERF" + Environment.NewLine;
                sqlText += " ,PRICE.UPDATEDATERF AS PRICEUPDATEDATERF" + Environment.NewLine;
                sqlText += " ,COUNTRF.COUNTRF AS PRICECOUNTRF" + Environment.NewLine;
                sqlText += " FROM GOODSURF AS GOODS" + Environment.NewLine;
                // ADD 2014/08/21 songg 仕掛№1923 ---->>>>
                // --- DEL 3H 王俊 2021/07/20 ---------->>>>>
                //if (_makerCd == 1 || _makerCd == 2)
                //{
                // --- DEL 3H 王俊 2021/07/20 ----------<<<<<
                    sqlText += " LEFT JOIN #GOODSNOWORK" + Environment.NewLine;
                    sqlText += " ON #GOODSNOWORK.GOODSNO = GOODS.GOODSNORF " + Environment.NewLine;
                // --- DEL 3H 王俊 2021/07/20 ---------->>>>>
                //}
                // --- DEL 3H 王俊 2021/07/20 ----------<<<<<
                // ADD 2014/08/21 songg 仕掛№1923 ----<<<<<
                sqlText += " LEFT JOIN GOODSPRICEURF AS PRICE" + Environment.NewLine;
                sqlText += " ON" + Environment.NewLine;
                sqlText += " 	 PRICE.ENTERPRISECODERF = GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRICE.GOODSNORF = GOODS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND PRICE.GOODSMAKERCDRF = GOODS.GOODSMAKERCDRF" + Environment.NewLine;

                sqlText += " LEFT JOIN " + Environment.NewLine;
                sqlText += " ( " + Environment.NewLine;
                sqlText += " SELECT " + Environment.NewLine;
                sqlText += " 	 COUNT(GOD.ENTERPRISECODERF) AS COUNTRF " + Environment.NewLine;
                sqlText += " 	,GOD.GOODSNORF " + Environment.NewLine;
                sqlText += " 	,GOD.GOODSMAKERCDRF " + Environment.NewLine;
                sqlText += " 	,GOD.ENTERPRISECODERF " + Environment.NewLine;
                sqlText += " FROM GOODSURF AS GOD " + Environment.NewLine;
                sqlText += " LEFT JOIN GOODSPRICEURF AS PRI " + Environment.NewLine;
                sqlText += "  ON " + Environment.NewLine;
                sqlText += " 	 PRI.ENTERPRISECODERF = GOD.ENTERPRISECODERF " + Environment.NewLine;
                sqlText += " AND PRI.GOODSMAKERCDRF = GOD.GOODSMAKERCDRF " + Environment.NewLine;
                sqlText += " AND PRI.GOODSNORF = GOD.GOODSNORF " + Environment.NewLine;
                sqlText += " WHERE  GOD.GOODSMAKERCDRF = @GOODSMAKERCD " + Environment.NewLine;
                sqlText += " GROUP BY GOD.GOODSMAKERCDRF, GOD.GOODSNORF, GOD.ENTERPRISECODERF " + Environment.NewLine;
                sqlText += " ) AS COUNTRF " + Environment.NewLine;
                sqlText += " ON " + Environment.NewLine;
                sqlText += " 	 COUNTRF.ENTERPRISECODERF = GOODS.ENTERPRISECODERF " + Environment.NewLine;
                sqlText += " AND COUNTRF.GOODSMAKERCDRF = GOODS.GOODSMAKERCDRF " + Environment.NewLine;
                sqlText += " AND COUNTRF.GOODSNORF = GOODS.GOODSNORF " + Environment.NewLine;

                sqlText += " WHERE" + Environment.NewLine;
                sqlText += " 	 GOODS.ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND GOODS.GOODSMAKERCDRF = @GOODSMAKERCD" + Environment.NewLine;
                // ADD 2014/08/21 songg 仕掛№1923 ---->>>>
                // --- DEL 3H 王俊 2021/07/20 ---------->>>>>
                //if (_makerCd == 1 || _makerCd == 2)
                //{
                // --- DEL 3H 王俊 2021/07/20 ----------<<<<<
                    sqlText += "  AND #GOODSNOWORK.GOODSNO IS NOT NULL" + Environment.NewLine; 
                // --- DEL 3H 王俊 2021/07/20 ---------->>>>>
                //}
                // --- DEL 3H 王俊 2021/07/20 ----------<<<<<
                // ADD 2014/08/21 songg 仕掛№1923 ----<<<<
                #endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                sqlCommand.CommandText += "ORDER BY GOODS.GOODSMAKERCDRF ASC, GOODS.GOODSNORF ASC ,PRICE.PRICESTARTDATERF ASC" + Environment.NewLine;

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                //paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(DummyWork.EnterpriseCode);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_enterpriseCode);

                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                //paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(DummyWork.GoodsMakerCd);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_makerCd);

                sqlCommand.CommandTimeout = 3600;  // ADD 2012/01/17

                myReader = sqlCommand.ExecuteReader();


                while (myReader.Read())
                {
                    // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                    //al.Add(CopyToGoodsUnitDataWork(ref myReader));
                    al.Add(CopyToGoodsUnitDataWork(ref myReader, convertDoubleRelease));
                    // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }


            }
            // -- ADD 2012/01/17 ------------------------>>>
            //catch
            //{
            //}
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "OfferMergeDB.UsrJoinPartsSearch", ex.Number);
            }
            // -- ADD 2012/01/17 ------------------------<<<
            finally
            {

                // ADD 2014/08/21 songg 仕掛№1923 ---->>>>
                // --- DEL 3H 王俊 2021/07/20 ---------->>>>>
                //if (_makerCd == 1 || _makerCd == 2)
                //{
                // --- DEL 3H 王俊 2021/07/20 ----------<<<<<
                    if (myReader != null)
                        if (!myReader.IsClosed) myReader.Close();

                    string dropText = "DROP TABLE #GOODSNOWORK";
                    sqlCommand = new SqlCommand(dropText, sqlConnection, sqlTransaction);
                    sqlCommand.ExecuteNonQuery();
                // --- DEL 3H 王俊 2021/07/20 ---------->>>>>
                //}
                // --- DEL 3H 王俊 2021/07/20 ----------<<<<<
                // ADD 2014/08/21 songg 仕掛№1923 ----<<<<<
     
                if (sqlCommand != null) sqlCommand.Dispose();

                // ADD 2014/08/21 songg 仕掛№1923 ---->>>>
                // --- DEL 3H 王俊 2021/07/20 ---------->>>>>
                //if (!(_makerCd == 1 || _makerCd == 2))
                //{
                //    if (myReader != null)
                //        if (!myReader.IsClosed) myReader.Close();
                //}
                // --- DEL 3H 王俊 2021/07/20 ----------<<<<<
                // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<

                // ADD 2014/08/21 songg 仕掛№1923 ----<<<<
                // DEL 2014/08/21 songg 仕掛№1923 ---->>>>
                //if (myReader != null)
                //    if (!myReader.IsClosed) myReader.Close();
                // DEL 2014/08/21 songg 仕掛№1923 ----<<<<

            }
            retlst = al;
            return status;
        }

        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
        //private GetUsrGoodsUnitDataWork CopyToGoodsUnitDataWork(ref SqlDataReader myReader)
        private GetUsrGoodsUnitDataWork CopyToGoodsUnitDataWork(ref SqlDataReader myReader, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
        {
            GetUsrGoodsUnitDataWork wkGoodsUnitDataWork = new GetUsrGoodsUnitDataWork();

            # region  結果セット
            wkGoodsUnitDataWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsUnitDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsUnitDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsUnitDataWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsUnitDataWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsUnitDataWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsUnitDataWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsUnitDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsUnitDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsUnitDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsUnitDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkGoodsUnitDataWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            wkGoodsUnitDataWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            wkGoodsUnitDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkGoodsUnitDataWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            wkGoodsUnitDataWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkGoodsUnitDataWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            wkGoodsUnitDataWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            wkGoodsUnitDataWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsUnitDataWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            wkGoodsUnitDataWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
            wkGoodsUnitDataWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
            wkGoodsUnitDataWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
            wkGoodsUnitDataWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            wkGoodsUnitDataWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            wkGoodsUnitDataWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));
            wkGoodsUnitDataWork.PriceCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("PRICECREATEDATETIMERF"));
            wkGoodsUnitDataWork.PriceUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("PRICEUPDATEDATETIMERF"));
            wkGoodsUnitDataWork.PriceEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRICEENTERPRISECODERF"));
            wkGoodsUnitDataWork.PriceFileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("PRICEFILEHEADERGUIDRF"));
            wkGoodsUnitDataWork.PriceUpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRICEUPDEMPLOYEECODERF"));
            wkGoodsUnitDataWork.PriceUpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRICEUPDASSEMBLYID1RF"));
            wkGoodsUnitDataWork.PriceUpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRICEUPDASSEMBLYID2RF"));
            wkGoodsUnitDataWork.PriceLogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICELOGICALDELETECODERF"));
            wkGoodsUnitDataWork.PriceGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEGOODSMAKERCDRF"));
            wkGoodsUnitDataWork.PriceGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRICEGOODSNORF"));
            wkGoodsUnitDataWork.PricePriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEPRICESTARTDATERF"));
            // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
            //wkGoodsUnitDataWork.PriceListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICELISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = wkGoodsUnitDataWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = wkGoodsUnitDataWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = wkGoodsUnitDataWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICELISTPRICERF"));

            // 変換処理実行
            convertDoubleRelease.ReleaseProc();

            wkGoodsUnitDataWork.PriceListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
            wkGoodsUnitDataWork.PriceSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICESALESUNITCOSTRF"));
            wkGoodsUnitDataWork.PriceStockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICESTOCKRATERF"));
            wkGoodsUnitDataWork.PriceOpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEOPENPRICEDIVRF"));
            wkGoodsUnitDataWork.PriceOfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEOFFERDATERF"));
            wkGoodsUnitDataWork.PriceUpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEUPDATEDATERF"));
            wkGoodsUnitDataWork.PriceCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECOUNTRF"));
            #endregion

            return wkGoodsUnitDataWork;
        }

        /// <summary>
        /// 価格改正処理
        /// </summary>
        /// <param name="st">価格改正設定</param>
        /// <param name="lst">価格改正処理用データリスト</param>
        /// <param name="retList">処理結果のリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlConnection2">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns></returns>
        private int DoPriceRevisionProc(PriceMergeSt st, CustomSerializeArrayList lst, out object retList, SqlConnection sqlConnection, SqlConnection sqlConnection2, SqlTransaction sqlTransaction, int pricerevisionOfferDate, MergeObjectCond updateMasterFlg)
        {
            #region 1.5次分ロジック
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            
            retList = new ArrayList();
            CustomSerializeArrayList ret = new CustomSerializeArrayList();

            PriUpdTblUpdHisWork hist = new PriUpdTblUpdHisWork();           // 履歴更新ﾜｰｸ
            ArrayList histList = new ArrayList();    

            if (lst != null)
            {
                if (lst.Count == 0)
                {
                    return status;
                }
                ArrayList GoodsList   = null;  // 商品マスタ書き込みリスト
                ArrayList PriceList   = null;  // 価格マスタ書き込みリスト
                ArrayList DelteteList = null;  // 価格マスタ削除リスト

                if (lst[0] != null) GoodsList = lst[0] as ArrayList;  // 商品マスタ書き込みリスト
                if (lst[1] != null) PriceList = lst[1] as ArrayList;  // 価格マスタ書き込みリスト
                if (lst[2] != null) DelteteList = lst[2] as ArrayList;  // 価格マスタ削除リスト

                // 商品マスタ書き込み

                if (GoodsList != null)
                {
                    if (GoodsList.Count !=0) status = WriteGoodsURF(ref GoodsList, sqlConnection, sqlTransaction);
                }
                // 価格マスタ書き込み
                if (PriceList != null)
                {
                    if (PriceList.Count != 0) status = WriteGoodsPriceURF(ref PriceList, sqlConnection, sqlTransaction);
                }
                // 価格管理件数を超えた場合の削除処理
                if (DelteteList != null)
                {
                    if (DelteteList.Count != 0) status = DeleteGoodsPriceURF(ref DelteteList, sqlConnection, sqlTransaction);
                }
                if (updateMasterFlg.GoodsUFlg == 1)
                {
                    hist = MakeHistInfo();
                    hist.SyncTableID = "GOODSURF";
                    hist.SyncTableName = "商品･価格マスタ";

                    int goodsCnt = 0;
                    int priceCnt = 0;
                    GoodsUWork goodsUWork = null;
                    GoodsPriceUWork goodsPriceUWork = null;
                    int goodsOfferDate = 0;
                    int priceOfferDate = 0;

                    // 履歴用件数
                    if (GoodsList != null) goodsCnt = GoodsList.Count;
                    if (PriceList != null) priceCnt = PriceList.Count;

                    // 履歴用日付取得
                    if (goodsCnt != 0)
                    {
                        goodsUWork = GoodsList[goodsCnt - 1] as GoodsUWork;
                        goodsOfferDate = int.Parse((goodsUWork.OfferDate).ToString("yyyyMMdd"));
                    }
                    if (priceCnt != 0)
                    {
                        goodsPriceUWork = PriceList[priceCnt - 1] as GoodsPriceUWork;
                        priceOfferDate = int.Parse((goodsPriceUWork.OfferDate).ToString("yyyyMMdd"));
                    }

                    if (status == 0)
                    {
                        hist.AddUpdateRowsNo = (goodsCnt + priceCnt);
                        if (goodsOfferDate != 0 || priceOfferDate != 0)
                        {
                            if (goodsOfferDate > priceOfferDate)
                                hist.OfferDate = goodsOfferDate;
                            else
                                hist.OfferDate = priceOfferDate;
                        }
                        else
                        {
                            hist.OfferDate = pricerevisionOfferDate;
                        }
                    }
                    else
                    {
                        hist.AddUpdateRowsNo = 0;
                        hist.OfferDate = pricerevisionOfferDate;
                    }
                    histList.Add(hist);

                    WriteHistoryProc(ref histList, sqlConnection, sqlTransaction); // 履歴記録
                }
            }

            return status;
            #endregion

            #region 1次分ロジック + 初期版
            /*
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new ArrayList();
            CustomSerializeArrayList ret = new CustomSerializeArrayList();

            ArrayList historyList = new ArrayList();

            PriUpdTblUpdHisWork hist;

            int MergeCounthist = 0;

            bool SkipFlg = false;
            bool FirstFlg = false;
            bool flg = false;

            #region Delete
            //SqlConnection sqlConnection = CreateSqlConnection();
            //SqlConnection sqlConnection2 = CreateSqlConnection();
            //if (sqlConnection == null || sqlConnection2 == null)
            //{
            //    return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            //}

            //SqlTransaction sqlTransaction = null;

            //try
            //{
            //    sqlConnection.Open();
            //    sqlConnection2.Open();
            //    sqlTransaction = sqlConnection.BeginTransaction();
            #endregion

            // *** ディクショナリ内構図 *** *** *** *** *** *** *** *** *** *** ***
            //
            // dicPriceUpdate<GoodsMakerCD,lstMaker>     [大枠]
            // │
            // ├lstMaker(※CashList)       [メーカー毎のアレイリスト]
            // │├lstGoods (商品マスタ)    [純正の場合は部品価格マスタより取得]
            // │└lstPrices(価格マスタ)    [純正の場合は部品価格マスタより取得]
            // │
            // ├lstMaker(※CashList)       [メーカー毎のアレイリスト]
            // │├lstGoods (商品マスタ)    [優良の場合は優良部品マスタより取得]
            // │└lstPrices(価格マスタ)    [優良の場合は優良価格マスタより取得]
            //          : 
            //          :                   [以下あるだけ]
            //
            // *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** ***

            if (lst.Count != 0)
            {
                Dictionary<int, ArrayList> dicPriceUpdate = new Dictionary<int, ArrayList>();

                // 更新リスト取り出し 
                dicPriceUpdate = lst[0] as Dictionary<int, ArrayList>;

                // 各ﾒｰｶｰでﾙｰﾌﾟします
                foreach (ArrayList MakerList in dicPriceUpdate.Values)
                {
                    ArrayList retlst = new ArrayList();         // ﾕｰｻﾞｰ商品連結リスト
                    ArrayList writeGoodsList = new ArrayList(); // 更新用商品リスト
                    ArrayList writePriceList = new ArrayList(); // 更新用価格リスト
                    ArrayList DeletePriceList = new ArrayList(); // 削除用価格リスト

                    // ﾒｰｶｰｺｰﾄﾞを取り出したいだけ & 中身のリストも後で使うので取っておく
                    ArrayList lstPrice = ListUtils.Find(MakerList, typeof(GoodsPriceUWork), ListUtils.FindType.Array) as ArrayList;
                    ArrayList lstGoods = ListUtils.Find(MakerList, typeof(GoodsUWork), ListUtils.FindType.Array) as ArrayList;
                    GoodsUWork DummyWork = new GoodsUWork();
                    if (lstGoods != null && lstGoods.Count > 0)
                    {
                        DummyWork = lstGoods[0] as GoodsUWork;
                    }
                    else if (lstPrice != null && lstPrice.Count > 0)
                    {
                        DummyWork.GoodsMakerCd = (lstPrice[0] as GoodsPriceUWork).GoodsMakerCd;
                    }
                    else
                    {
                        continue;
                    }
                    DummyWork.EnterpriseCode = st.EnterpriseCode;

                    // 指定ﾒｰｶｰでﾕｰｻﾞｰ検索:実行(上限なし)
                    //UsrJoinPartsSearch(out retlst, DummyWork, sqlConnection2);

                    // ﾕｰｻﾞｰﾃﾞｰﾀがあれば更新
                    if (retlst.Count > 0)
                    {
                        // ﾕｰｻﾞｰ商品結合データで回す
                        foreach (GetUsrGoodsUnitDataWork userGoodsUnitWork in retlst)
                        {
                            if (lstGoods != null && lstGoods.Count > 0)
                            {
                                // 提供商品リスト
                                foreach (GoodsUWork goodsUwork in lstGoods)
                                {
                                    // マージ対象となるキーが一致していたら(ﾒｰｶｰ･品番) 
                                    if (userGoodsUnitWork.GoodsMakerCd == goodsUwork.GoodsMakerCd
                                          && userGoodsUnitWork.GoodsNo == goodsUwork.GoodsNo)
                                    {
                                        if (!(userGoodsUnitWork.GoodsMakerCd == PriGoodsUWork.GoodsMakerCd
                                           && userGoodsUnitWork.GoodsNo == PriGoodsUWork.GoodsNo))
                                        {
                                            GoodsUWork writeGoodsUwork = new GoodsUWork();

                                            // 取敢えずキー格納
                                            writeGoodsUwork.CreateDateTime = userGoodsUnitWork.CreateDateTime;
                                            writeGoodsUwork.BLGoodsCode = userGoodsUnitWork.BLGoodsCode;
                                            writeGoodsUwork.DisplayOrder = userGoodsUnitWork.DisplayOrder;
                                            writeGoodsUwork.EnterpriseGanreCode = userGoodsUnitWork.EnterpriseGanreCode;
                                            writeGoodsUwork.FileHeaderGuid = userGoodsUnitWork.FileHeaderGuid;
                                            writeGoodsUwork.GoodsKindCode = userGoodsUnitWork.GoodsKindCode;
                                            writeGoodsUwork.GoodsName = userGoodsUnitWork.GoodsName;
                                            writeGoodsUwork.GoodsNameKana = userGoodsUnitWork.GoodsNameKana;
                                            writeGoodsUwork.GoodsNoNoneHyphen = userGoodsUnitWork.GoodsNoNoneHyphen;
                                            writeGoodsUwork.GoodsNote1 = userGoodsUnitWork.GoodsNote1;
                                            writeGoodsUwork.GoodsNote2 = userGoodsUnitWork.GoodsNote2;
                                            writeGoodsUwork.GoodsRateRank = userGoodsUnitWork.GoodsRateRank;
                                            writeGoodsUwork.GoodsSpecialNote = userGoodsUnitWork.GoodsSpecialNote;
                                            writeGoodsUwork.Jan = userGoodsUnitWork.Jan;
                                            writeGoodsUwork.LogicalDeleteCode = userGoodsUnitWork.LogicalDeleteCode;
                                            writeGoodsUwork.OfferDataDiv = userGoodsUnitWork.OfferDataDiv;
                                            writeGoodsUwork.OfferDate = userGoodsUnitWork.OfferDate;
                                            writeGoodsUwork.TaxationDivCd = userGoodsUnitWork.TaxationDivCd;
                                            writeGoodsUwork.UpdAssemblyId1 = userGoodsUnitWork.UpdAssemblyId1;
                                            writeGoodsUwork.UpdAssemblyId2 = userGoodsUnitWork.UpdAssemblyId2;
                                            writeGoodsUwork.UpdateDate = userGoodsUnitWork.UpdateDate;
                                            writeGoodsUwork.UpdateDateTime = userGoodsUnitWork.UpdateDateTime;
                                            writeGoodsUwork.UpdEmployeeCode = userGoodsUnitWork.UpdEmployeeCode;
                                            writeGoodsUwork.EnterpriseCode = userGoodsUnitWork.EnterpriseCode;
                                            writeGoodsUwork.GoodsMakerCd = goodsUwork.GoodsMakerCd;
                                            writeGoodsUwork.GoodsNo = goodsUwork.GoodsNo;

                                            // マージ処理
                                            // [名称更新] [する]の場合
                                            bool updateFlg = false;
                                            if (st.NameMergeFlg == 0)
                                            {
                                                writeGoodsUwork.GoodsName = goodsUwork.GoodsName;
                                                writeGoodsUwork.GoodsNameKana = goodsUwork.GoodsNameKana;
                                                updateFlg = true;
                                            }
                                            // [層別更新] [する]の場合
                                            if (st.GoodsRankMergeFlg == 0)
                                            {
                                                writeGoodsUwork.GoodsRateRank = goodsUwork.GoodsRateRank;
                                                updateFlg = true;
                                            }
                                            // 名称又は層別の更新がある場合　商品属性・提供日付・更新年月日を更新する。
                                            if (updateFlg)
                                            {
                                                writeGoodsUwork.GoodsKindCode = goodsUwork.GoodsKindCode;
                                                writeGoodsUwork.OfferDate = goodsUwork.OfferDate;
                                                writeGoodsUwork.UpdateDate = DateTime.Now;
                                                writeGoodsUwork.OfferDataDiv = 1;

                                                // 更新用リストにAdd
                                                writeGoodsList.Add(writeGoodsUwork);

                                            }
                                            PriGoodsUWork = goodsUwork;
                                            break;
                                        }
                                    }
                                }
                            }

                            // *** *** *** *** *** *** 価格マージ *** *** *** *** *** *** ***

                            if (lstPrice != null && lstPrice.Count > 0)
                            {

                                // 価格更新フラグが0:するだったら 
                                if (st.PriceMergeFlg == 0)
                                {
                                    GoodsPriceUWork UpdateGoodsPriceUwork = new GoodsPriceUWork();　// 更新用価格ワーク


                                    // もし前回と異なる提供価格だったら
                                    if (!(PriorOfrGoodsPriceUWork.GoodsMakerCd == userGoodsUnitWork.GoodsMakerCd
                                      && PriorOfrGoodsPriceUWork.GoodsNo == userGoodsUnitWork.GoodsNo) || FirstFlg == false)
                                    {
                                        // 提供価格リストから取得
                                        foreach (GoodsPriceUWork goodsPriceUwork in lstPrice)
                                        {
                                            // マージ対象となるキーが一致していたら(ﾒｰｶｰ･品番) 
                                            if (userGoodsUnitWork.GoodsMakerCd == goodsPriceUwork.GoodsMakerCd
                                                  && userGoodsUnitWork.GoodsNo == goodsPriceUwork.GoodsNo)
                                            {
                                                PriorOfrGoodsPriceUWork = goodsPriceUwork;
                                                FirstFlg = true;
                                                SkipFlg = false;
                                                flg = true;
                                                break;
                                            }
                                        }
                                    }
                                    if (flg == false)
                                    {
                                        PriorOfrGoodsPriceUWork = new GoodsPriceUWork();
                                    }

                                    flg = false;


                                    // もし前回と同メーカー･品番だったら
                                    if (PriorGoodsPriceUWork.GoodsMakerCd == userGoodsUnitWork.GoodsMakerCd
                                          && PriorGoodsPriceUWork.GoodsNo == userGoodsUnitWork.GoodsNo)
                                    {
                                        //if (SkipFlg == true)
                                        //    break;
                                    }
                                    else
                                    {
                                        // データ入っているか確認するために提供日付で判断
                                        if (writeGoodsPriseUwork.OfferDate != DateTime.MinValue)
                                        {
                                            // 前回取っておいたメーカー品番を書込リストにAdd
                                            writePriceList.Add(writeGoodsPriseUwork);
                                            // 前回取っておいたメーカー品番を削除リストにAdd
                                            if (deleteGoodsPriceUWork.EnterpriseCode != "")
                                            {
                                                DeletePriceList.Add(deleteGoodsPriceUWork);
                                            }
                                            writeGoodsPriseUwork = new GoodsPriceUWork();
                                            deleteGoodsPriceUWork = new GoodsPriceUWork();
                                        }
                                        SkipFlg = false;
                                    }

                                    // テスト用
                                    //if (userGoodsUnitWork.GoodsMakerCd == 1003 && userGoodsUnitWork.GoodsNo == "NN1065")
                                    //{
                                    //    string a ="";
                                    //    a = "0";
                                    //}

                                    // データ入っているか確認するために提供日付で判断
                                    if (PriorOfrGoodsPriceUWork.OfferDate != DateTime.MinValue)
                                    {

                                        if (SkipFlg == false)
                                        {
                                            DateTime priceStartDate = DateTime.MinValue;
                                            // Datetimeに変換　※価格開始日
                                            if (userGoodsUnitWork.PricePriceStartDate != 0)
                                            {
                                                priceStartDate = DateTime.Parse(userGoodsUnitWork.PricePriceStartDate.ToString("0000/00/00"));
                                            }
                                            // ﾕｰｻﾞｰのﾚｺｰﾄﾞ数がマスタの価格保持件数よりも大きければ
                                            if (userGoodsUnitWork.PriceCount >= st.PriceManage)
                                            {
                                                // ﾕｰｻﾞｰ価格開始日が提供の価格開始日以上ならば
                                                if (priceStartDate > PriorOfrGoodsPriceUWork.PriceStartDate)
                                                {
                                                    SkipFlg = true;
                                                    continue;
                                                }
                                                // ﾕｰｻﾞｰと提供の価格開始日が一緒なら
                                                else if (priceStartDate == PriorOfrGoodsPriceUWork.PriceStartDate)
                                                {
                                                    // 更新処理　後で作成
                                                    UpdatePrice(userGoodsUnitWork, st, ref writePriceList, ref PriorOfrGoodsPriceUWork);

                                                    SkipFlg = true;
                                                    continue;
                                                }
                                                // ﾕｰｻﾞｰより提供の価格開始日が大きい場合(ｲｺｰﾙは含まれない)
                                                else
                                                {
                                                    // 新規ワーク作成
                                                    WriteNewPrice(userGoodsUnitWork, st, ref writePriceList, ref PriorOfrGoodsPriceUWork);
                                                    deleteGoodsPriceUWork = PriorOfrGoodsPriceUWork;
                                                }
                                            }
                                            // ﾕｰｻﾞｰのﾚｺｰﾄﾞ数がマスタの価格保持件数より小さければ
                                            else
                                            {
                                                // ﾕｰｻﾞｰと提供の価格開始日が一緒なら
                                                if (priceStartDate == PriorOfrGoodsPriceUWork.PriceStartDate)
                                                {
                                                    // 更新処理　後で作成
                                                    UpdatePrice(userGoodsUnitWork, st, ref writePriceList, ref PriorOfrGoodsPriceUWork);

                                                    SkipFlg = true;
                                                    continue;
                                                }
                                                else
                                                {
                                                    // 新規ワーク作成
                                                    WriteNewPrice(userGoodsUnitWork, st, ref writePriceList, ref PriorOfrGoodsPriceUWork);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        // 商品マスタ書き込み
                        if (writeGoodsList != null && writeGoodsList.Count != 0)
                            status = WriteGoodsURF(ref writeGoodsList, sqlConnection, sqlTransaction);

                        // 価格マスタ書き込み
                        if (writePriceList != null && writePriceList.Count != 0)
                            status = WriteGoodsPriceURF(ref writePriceList, sqlConnection, sqlTransaction);

                        // 価格管理件数を超えた場合の削除処理
                        if (DeletePriceList != null && DeletePriceList.Count != 0)
                            status = DeleteGoodsPriceURF(ref DeletePriceList, sqlConnection, sqlTransaction);

                        // 履歴用更新件数保存
                        MergeCounthist += (writeGoodsList.Count + writePriceList.Count);
                    }
                }
                ArrayList lastwritePriceList = new ArrayList();
                ArrayList lastDeletePriceList = new ArrayList();
                // データ入っているか確認するために提供日付で判断
                if (writeGoodsPriseUwork.OfferDate != DateTime.MinValue)
                {
                    // 前回取っておいたメーカー品番を書込リストにAdd
                    lastwritePriceList.Add(writeGoodsPriseUwork);
                    // 前回取っておいたメーカー品番を削除リストにAdd
                    if (deleteGoodsPriceUWork.EnterpriseCode != "")
                    {
                        lastDeletePriceList.Add(deleteGoodsPriceUWork);
                    }
                }
                // 価格マスタ書き込み
                if (lastwritePriceList != null && lastwritePriceList.Count != 0)
                    status = WriteGoodsPriceURF(ref lastwritePriceList, sqlConnection, sqlTransaction);

                // 価格管理件数を超えた場合の削除処理
                if (lastDeletePriceList != null && lastDeletePriceList.Count != 0)
                    status = DeleteGoodsPriceURF(ref lastDeletePriceList, sqlConnection, sqlTransaction);

                // 履歴更新
                if (MergeCounthist > 0)
                {
                    hist = MakeHistInfo();
                    hist.SyncTableID = "GOODSURF";
                    hist.SyncTableName = "商品･価格マスタ";

                    if (status == 0) hist.AddUpdateRowsNo = MergeCounthist;
                    else hist.AddUpdateRowsNo = status;

                    historyList.Add(hist);
                    WriteHistoryProc(ref historyList, sqlConnection, sqlTransaction);
                }

                #region  旧ロジック

                //if (lst.Count != 0)
                //{
                //        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                //        ArrayList lstGoods = lst[0] as ArrayList;
                //        ArrayList lstPrices = lst[1] as ArrayList;

                //        // マージ処理を行った商品・価格の情報リスト
                //        ArrayList lstRetGoods = new ArrayList();　//UIからくる商品情報リスト
                //        ArrayList lstRetPrices = new ArrayList();　//UIからくる価格情報リスト

                //        ArrayList lstUpdateGoods = new ArrayList();

                //        UsrJoinPartsSearchDB UsrJoinPartsSearchDB = new UsrJoinPartsSearchDB();
                //        ArrayList retlst;
                //        foreach (GoodsUWork GoodsUWork in lstGoods) //商品マージ対象となるリスト分回す
                //        {

                //            // キー作成　企業,ﾒｰｶｰ,品番
                //            GoodsUCndtnWork GoodsUCndtnWork = new GoodsUCndtnWork();
                //            GoodsUCndtnWork.EnterpriseCode = st.EnterpriseCode;
                //            //GoodsUCndtnWork.GoodsMakerCd = GoodsUWork.GoodsMakerCd;
                //            //GoodsUCndtnWork.GoodsNo = GoodsUWork.GoodsNo;
                //            GoodsUCndtnWork.GoodsKindCode = 9;

                //            #region [ 部品・価格マージ ]

                //            // 基準　取敢えず1000件試す(ユーザーデータ)
                //            UsrJoinPartsSearchDB.SearchGoodsURelationDataProc(out retlst, null, GoodsUCndtnWork, null, 0,1000,
                //                ConstantManagement.LogicalMode.GetData0, ref sqlConnection2); // ユーザー商品マスタ取得　retlst　
                //            {
                //                if (retlst.Count > 0)
                //                {
                //                    GoodsUnitDataWork GoodsUnitDataWork = retlst[0] as GoodsUnitDataWork;　// ﾕｰｻﾞｰ商品ワーク
                //                    bool updateFlg = GoodsMergeProc(st, GoodsUnitDataWork, GoodsUWork);

                //                    for (int i = 0; i < lstPrices.Count; i++) //価格マージ対象となるリスト分回す
                //                    {
                //                        GoodsPriceUWork GoodsPriceUWork = lstPrices[i] as GoodsPriceUWork;　// 提供価格ワーク

                //                        // キーが同じだったら･･･
                //                        if (GoodsPriceUWork.GoodsMakerCd == GoodsUCndtnWork.GoodsMakerCd && GoodsPriceUWork.GoodsNo == GoodsUCndtnWork.GoodsNo)
                //                        {
                //                            int j;
                //                            for (j = 0; j < GoodsUnitDataWork.PriceList.Count; j++)
                //                            {
                //                                GoodsPriceUWork price = GoodsUnitDataWork.PriceList[j] as GoodsPriceUWork;
                //                                if (GoodsPriceUWork.PriceStartDate == price.PriceStartDate) // 提供価格がユーザーDBに存在する場合（商品もあり）
                //                                {
                //                                    if (st.PriceMergeFlg == 0)
                //                                    {
                //                                        price.OpenPriceDiv = GoodsPriceUWork.OpenPriceDiv;
                //                                        if (price.OpenPriceDiv == 0) // 通常価格の場合
                //                                        {
                //                                            price.ListPrice = GoodsPriceUWork.ListPrice;
                //                                        }
                //                                        else                         // オープン価格の場合
                //                                        {
                //                                            if (st.OpenPriceFlg == 0) // 価格を引継ぐ
                //                                            {
                //                                                if (j < GoodsUnitDataWork.PriceList.Count - 1)
                //                                                {
                //                                                    price.ListPrice = ((GoodsPriceUWork)GoodsUnitDataWork.PriceList[j + 1]).ListPrice;
                //                                                }
                //                                                else
                //                                                {
                //                                                    price.ListPrice = 0;
                //                                                }
                //                                            }
                //                                            else                      // ０で更新
                //                                            {
                //                                                price.ListPrice = 0;
                //                                            }
                //                                        }
                //                                    }
                //                                    lstRetPrices.Add(GoodsPriceUWork);
                //                                    lstPrices.RemoveAt(i); // 処理済みの価格はリストから削除する。
                //                                    i--; // 処理済みの価格情報削除によるインデックス変更対応
                //                                    break;
                //                                }
                //                            }
                //                            if (j >= GoodsUnitDataWork.PriceList.Count) // 新規価格の場合
                //                            {
                //                                GoodsUnitDataWork.PriceList.Insert(0, GoodsPriceUWork);
                //                                lstRetPrices.Add(GoodsPriceUWork);
                //                                lstPrices.RemoveAt(i); // 処理済みの価格はリストから削除する。
                //                                if (GoodsUnitDataWork.PriceList.Count > st.PriceManage)  // 商品の価格数が価格管理件数を超える場合
                //                                {
                //                                    GoodsUnitDataWork.PriceList.RemoveAt(GoodsUnitDataWork.PriceList.Count - 1); // 一番古い価格を削除する。
                //                                }
                //                            }
                //                        }
                //                    }
                //                    lstUpdateGoods.Add(GoodsUnitDataWork);
                //                    lstRetGoods.Add(GoodsUWork);
                //                }
                //            }
                //            #endregion
                //        }
                //        CustomSerializeArrayList lstUpdate = new CustomSerializeArrayList();
                //        lstUpdate.Add(lstUpdateGoods);
                //        status = UsrJoinPartsSearchDB.WriteRelationProc(ref lstUpdate, sqlConnection, sqlTransaction);
                //        if (status == 0)
                //        {
                //            MergeCounthist += lstUpdate.Count;
                //        }

                //        #region [ 部品価格マージ ]
                //        ArrayList lstPriceUpdate = new ArrayList();
                //        ArrayList lstPriceDelete = new ArrayList();
                //        GoodsPriceUDB GoodsPriceUDB = new GoodsPriceUDB();
                //        for (int i = 0; i < lstPrices.Count; i++)
                //        {
                //            GoodsPriceUWork GoodsPriceUWork = lstPrices[i] as GoodsPriceUWork;
                //            GoodsPriceUWork cond = new GoodsPriceUWork();
                //            cond.EnterpriseCode = st.EnterpriseCode;
                //            GoodsPriceUWork.EnterpriseCode = st.EnterpriseCode;
                //            cond.GoodsNo = GoodsPriceUWork.GoodsNo;
                //            cond.GoodsMakerCd = GoodsPriceUWork.GoodsMakerCd;
                //            //GoodsPriceUDB.SearchGoodsPriceProc(out retlst, cond, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection2);
                //            GoodsPriceUDB.SearchGoodsPriceProc(out retlst, cond, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection2);
                //            //if (retlst != null && retlst.Count > 0)
                //            //{
                //                int j;
                //                int maxJ = 0;
                //                DateTime maxDate = DateTime.MinValue;
                //                for (j = 0; j < retlst.Count; j++)
                //                {
                //                    GoodsPriceUWork dest = retlst[j] as GoodsPriceUWork;
                //                    dest.EnterpriseCode = st.EnterpriseCode;
                //                    if (dest.PriceStartDate > maxDate)
                //                    {
                //                        maxDate = dest.PriceStartDate;
                //                        maxJ = j;
                //                    }
                //                    if (dest.PriceStartDate == GoodsPriceUWork.PriceStartDate)
                //                    {
                //                        if (st.PriceMergeFlg == 0)
                //                        {

                //                            dest.OpenPriceDiv = GoodsPriceUWork.OpenPriceDiv;
                //                            if (dest.OpenPriceDiv == 0) // 通常価格の場合
                //                            {
                //                                dest.ListPrice = GoodsPriceUWork.ListPrice;
                //                            }
                //                            else                         // オープン価格の場合
                //                            {
                //                                if (st.OpenPriceFlg == 0) // 価格を引継ぐ
                //                                {
                //                                    if (j < retlst.Count - 1)
                //                                    {
                //                                        dest.ListPrice = ((GoodsPriceUWork)retlst[j + 1]).ListPrice;
                //                                    }
                //                                    else
                //                                    {
                //                                        dest.ListPrice = 0;
                //                                    }
                //                                }
                //                                else                      // ０で更新
                //                                {
                //                                    dest.ListPrice = 0;
                //                                }
                //                            }
                //                        }
                //                        lstPriceUpdate.Add(dest);
                //                        lstRetPrices.Add(GoodsPriceUWork);
                //                        lstPrices.RemoveAt(i); // 処理済みの価格はリストから削除する。
                //                        i--; // 処理済みの価格情報削除によるインデックス変更対応
                //                        break;
                //                    }
                //                }
                //                if (j >= retlst.Count)
                //                {
                //                    lstPriceUpdate.Add(GoodsPriceUWork);
                //                    lstRetPrices.Add(GoodsPriceUWork);
                //                    if (retlst.Count == st.PriceManage) // 価格数が価格管理件数を超えるか
                //                    {
                //                        lstPriceDelete.Add(retlst[maxJ]);
                //                    }
                //                }
                //            }
                //        //}
                //        status = GoodsPriceUDB.DeleteGoodsPriceProc(lstPriceDelete, ref sqlConnection, ref sqlTransaction);
                //        ArrayList lstErrorLst;
                //        status = GoodsPriceUDB.WriteGoodsPriceProc(ref lstPriceUpdate, out lstErrorLst, ref sqlConnection, ref sqlTransaction);
                //        if (status == 0)
                //        {
                //            MergeCounthist += lstPriceUpdate.Count;
                //        }
                //// 履歴更新
                //hist = MakeHistInfo();
                //hist.SyncTableID = "GOODSPRICEURF";
                //hist.SyncTableName = "価格マスタ";
                //if (status == 0)
                //    hist.AddUpdateRowsNo = lstPriceUpdate.Count;
                //else
                //    hist.AddUpdateRowsNo = status;
                //historyList.Add(hist);

                // 履歴作成
                #endregion

        #endregion

                #region DELETE
                //}
                //catch
                //{
                //    sqlTransaction.Rollback();
                //}
                //finally
                //{
                //    if (status == 0 || status == 9　||status == 4)
                //        sqlTransaction.Commit();
                //    if (sqlTransaction != null)
                //        sqlTransaction.Dispose();
                //    if (sqlConnection != null)
                //        sqlConnection.Dispose();
                //    if (sqlConnection2 != null)
                //        sqlConnection2.Dispose();
                //}
                #endregion
            }
            return status;
             */
        #endregion
        }

        private int DeleteGoodsPriceURF(ref ArrayList DeletePriceList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            string errorMessage = String.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = String.Empty;

            try
            {
                foreach (GoodsPriceUWork GoodsPriceUWork in DeletePriceList)
                {
                    #region [更新処理]
                    //Selectコマンドの生成
                    sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                    findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                    findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        ////既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        //if (_updateDateTime != GoodsPriceUWork.UpdateDateTime)
                        //{
                        //    //既存データで更新日時違いの場合には排他
                        //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        //    errorMessage = "このデータは既に更新されています。";

                        //    sqlCommand.Cancel();

                        //    if (myReader.IsClosed == false)
                        //        myReader.Close();
                        //    myReader.Dispose();

                        //    continue;
                        //}

                        sqlText = "";
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  GOODSPRICEURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                        sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                        findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                        findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                    }
                    //else
                    //{
                    //    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    //    errorMessage = "このデータは既に削除されています。";
                    //    sqlCommand.Cancel();
                    //    return status;
                    //}

                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                    #endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
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

        // 更新処理
        #region 1次分 DELETE
        /*
        private void UpdatePrice(GetUsrGoodsUnitDataWork userGoodsUnitWork, PriceMergeSt st, ref ArrayList writepriceList, ref GoodsPriceUWork list)
        {
            // マージ処理
            writeGoodsPriseUwork.EnterpriseCode = userGoodsUnitWork.PriceEnterpriseCode;
            writeGoodsPriseUwork.UpdateDateTime = userGoodsUnitWork.PriceUpdateDateTime;
            writeGoodsPriseUwork.CreateDateTime = userGoodsUnitWork.PriceCreateDateTime;
            writeGoodsPriseUwork.UpdAssemblyId1 = userGoodsUnitWork.PriceUpdAssemblyId1;
            writeGoodsPriseUwork.UpdAssemblyId2 = userGoodsUnitWork.PriceUpdAssemblyId2;
            writeGoodsPriseUwork.FileHeaderGuid = userGoodsUnitWork.PriceFileHeaderGuid;
            writeGoodsPriseUwork.LogicalDeleteCode = PriorOfrGoodsPriceUWork.LogicalDeleteCode;

            writeGoodsPriseUwork.SalesUnitCost = userGoodsUnitWork.PriceSalesUnitCost;
            writeGoodsPriseUwork.StockRate = userGoodsUnitWork.PriceStockRate;
            writeGoodsPriseUwork.UpdEmployeeCode = userGoodsUnitWork.PriceUpdEmployeeCode;
            writeGoodsPriseUwork.GoodsMakerCd = PriorOfrGoodsPriceUWork.GoodsMakerCd;
            writeGoodsPriseUwork.GoodsNo = PriorOfrGoodsPriceUWork.GoodsNo;
            writeGoodsPriseUwork.OpenPriceDiv = PriorOfrGoodsPriceUWork.OpenPriceDiv;
            writeGoodsPriseUwork.PriceStartDate = PriorOfrGoodsPriceUWork.PriceStartDate;
            writeGoodsPriseUwork.OfferDate = PriorOfrGoodsPriceUWork.OfferDate;
            writeGoodsPriseUwork.UpdateDate = DateTime.Now;

            // 通常価格の場合
            if (writeGoodsPriseUwork.OpenPriceDiv == 0)
            {
                writeGoodsPriseUwork.ListPrice = PriorOfrGoodsPriceUWork.ListPrice;
            }
            // オープン価格の場合
            else
            {
                // オープン価格区分が0:価格を引継ぐの場合
                if (st.OpenPriceFlg == 0)
                {
                    //　部品価格引き継ぎ
                    writeGoodsPriseUwork.ListPrice = PriorOfrGoodsPriceUWork.ListPrice;
                }
                // オープン価格区分が1:0で更新だったら
                else
                {
                    // 0で更新
                    writeGoodsPriseUwork.ListPrice = 0;
                }
            }
            // 前回ワークとして格納しておく
            PriorGoodsPriceUWork = PriorOfrGoodsPriceUWork;
        }
        */
         
        // 新規作成処理 
        /*
        private void WriteNewPrice(GetUsrGoodsUnitDataWork userGoodsUnitWork, PriceMergeSt st, ref ArrayList writepriceList, ref GoodsPriceUWork list)
        {
            // マージ処理
            writeGoodsPriseUwork.EnterpriseCode = userGoodsUnitWork.PriceEnterpriseCode;
            //writeGoodsPriseUwork.UpdateDateTime = userGoodsUnitWork.PriceUpdateDateTime;
            writeGoodsPriseUwork.CreateDateTime = userGoodsUnitWork.PriceCreateDateTime;
            writeGoodsPriseUwork.UpdAssemblyId1 = userGoodsUnitWork.PriceUpdAssemblyId1;
            writeGoodsPriseUwork.UpdAssemblyId2 = userGoodsUnitWork.PriceUpdAssemblyId2;
            writeGoodsPriseUwork.FileHeaderGuid = userGoodsUnitWork.PriceFileHeaderGuid;
            writeGoodsPriseUwork.LogicalDeleteCode = userGoodsUnitWork.PriceLogicalDeleteCode;

            writeGoodsPriseUwork.SalesUnitCost = userGoodsUnitWork.PriceSalesUnitCost;
            writeGoodsPriseUwork.StockRate = userGoodsUnitWork.PriceStockRate;
            writeGoodsPriseUwork.UpdEmployeeCode = userGoodsUnitWork.PriceUpdEmployeeCode;
            writeGoodsPriseUwork.GoodsMakerCd = PriorOfrGoodsPriceUWork.GoodsMakerCd;
            writeGoodsPriseUwork.GoodsNo = PriorOfrGoodsPriceUWork.GoodsNo;
            writeGoodsPriseUwork.OpenPriceDiv = PriorOfrGoodsPriceUWork.OpenPriceDiv;
            writeGoodsPriseUwork.PriceStartDate = PriorOfrGoodsPriceUWork.PriceStartDate;
            writeGoodsPriseUwork.OfferDate = PriorOfrGoodsPriceUWork.OfferDate;
            writeGoodsPriseUwork.UpdateDate = DateTime.Now;

            // 通常価格の場合
            if (writeGoodsPriseUwork.OpenPriceDiv == 0)
            {
                writeGoodsPriseUwork.ListPrice = PriorOfrGoodsPriceUWork.ListPrice;
            }
            // オープン価格の場合
            else
            {
                // オープン価格区分が0:価格を引継ぐの場合
                if (st.OpenPriceFlg == 0)
                {
                    //　部品価格引き継ぎ
                    writeGoodsPriseUwork.ListPrice = PriorOfrGoodsPriceUWork.ListPrice;
                }
                // オープン価格区分が1:0で更新だったら
                else
                {
                    // 0で更新
                    writeGoodsPriseUwork.ListPrice = 0;
                }
            }
            // 前回ワークとして格納しておく
            PriorGoodsPriceUWork = PriorOfrGoodsPriceUWork;
        }
        */
        #endregion

        // 商品マスタ更新処理
        private int WriteGoodsURF(ref ArrayList writeGoodsList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList retList = new ArrayList();

            try
            {
                if (writeGoodsList != null)
                {
                    foreach (GoodsUWork goodsuWork in writeGoodsList)
                    {
                        string sqlTxt = string.Empty;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                        #region UPDATE文
                        sqlTxt += "UPDATE GOODSURF" + Environment.NewLine;
                        sqlTxt += "SET" + Environment.NewLine;
                        sqlTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlTxt += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                        sqlTxt += " , GOODSNAMERF=@GOODSNAME" + Environment.NewLine;
                        sqlTxt += " , GOODSNAMEKANARF=@GOODSNAMEKANA" + Environment.NewLine;
                        sqlTxt += " , JANRF=@JAN" + Environment.NewLine;
                        sqlTxt += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                        sqlTxt += " , DISPLAYORDERRF=@DISPLAYORDER" + Environment.NewLine;
                        sqlTxt += " , GOODSRATERANKRF=@GOODSRATERANK" + Environment.NewLine;
                        sqlTxt += " , TAXATIONDIVCDRF=@TAXATIONDIVCD" + Environment.NewLine;
                        sqlTxt += " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                        sqlTxt += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                        sqlTxt += " , GOODSKINDCODERF=@GOODSKINDCODE" + Environment.NewLine;
                        sqlTxt += " , GOODSNOTE1RF=@GOODSNOTE1" + Environment.NewLine;
                        sqlTxt += " , GOODSNOTE2RF=@GOODSNOTE2" + Environment.NewLine;
                        sqlTxt += " , GOODSSPECIALNOTERF=@GOODSSPECIALNOTE" + Environment.NewLine;
                        sqlTxt += " , ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE" + Environment.NewLine;
                        sqlTxt += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                        sqlTxt += " , OFFERDATADIVRF=@OFFERDATADIVRF" + Environment.NewLine;
                        sqlTxt += "WHERE" + Environment.NewLine;
                        sqlTxt += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        #endregion

                        sqlCommand.CommandText = sqlTxt;

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuWork.EnterpriseCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNo);

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)goodsuWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                        SqlParameter paraJan = sqlCommand.Parameters.Add("@JAN", SqlDbType.NVarChar);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                        SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                        SqlParameter paraTaxationDivCd = sqlCommand.Parameters.Add("@TAXATIONDIVCD", SqlDbType.Int);
                        SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                        SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                        SqlParameter paraGoodsNote1 = sqlCommand.Parameters.Add("@GOODSNOTE1", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNote2 = sqlCommand.Parameters.Add("@GOODSNOTE2", SqlDbType.NVarChar);
                        SqlParameter paraGoodsSpecialNote = sqlCommand.Parameters.Add("@GOODSSPECIALNOTE", SqlDbType.NVarChar);
                        SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                        SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                        SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIVRF", SqlDbType.Int);
                        


                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsuWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsuWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsuWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsuWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsuWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsuWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsuWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsuWork.LogicalDeleteCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNo);
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsName);
                        paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNameKana);
                        paraJan.Value = SqlDataMediator.SqlSetString(goodsuWork.Jan);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsuWork.BLGoodsCode);
                        paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(goodsuWork.DisplayOrder);
                        paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsRateRank);
                        paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(goodsuWork.TaxationDivCd);
                        paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNoNoneHyphen);
                        paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsuWork.OfferDate);
                        paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(goodsuWork.GoodsKindCode);
                        paraGoodsNote1.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNote1);
                        paraGoodsNote2.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsNote2);
                        paraGoodsSpecialNote.Value = SqlDataMediator.SqlSetString(goodsuWork.GoodsSpecialNote);
                        paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(goodsuWork.EnterpriseGanreCode);
                        paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsuWork.UpdateDateTime);
                        paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(goodsuWork.OfferDataDiv);

                        goodsuWork.UpdateDate = goodsuWork.UpdateDateTime.Date;
                        #endregion

                        sqlCommand.ExecuteNonQuery();

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch
            {

            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                        myReader.Dispose();
                    }
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        // 価格マスタ更新処理
        private int WriteGoodsPriceURF(ref ArrayList writePriceList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            string errorMessage = String.Empty;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = String.Empty;
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
            try
            {
                foreach (GoodsPriceUWork GoodsPriceUWork in writePriceList)
                {
                    //Selectコマンドの生成
                    sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UPDATEDATETIMERF " + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  GOODSPRICEURF " + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    sqlText += "  AND PRICESTARTDATERF = @FINDPRICESTARTDATE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaPriceStartDate = sqlCommand.Parameters.Add("@FINDPRICESTARTDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                    findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                    findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        //if (_updateDateTime != GoodsPriceUWork.UpdateDateTime)
                        //{
                        //    //新規登録で該当データ有りの場合には重複
                        //    if (GoodsPriceUWork.UpdateDateTime == DateTime.MinValue)
                        //    {
                        //        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        //        errorMessage = "重複するデータがあるため更新できません。";
                        //    }
                        //    //既存データで更新日時違いの場合には排他
                        //    else
                        //    {
                        //        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        //        errorMessage = "このデータは既に更新されています。";
                        //    }

                        //    sqlCommand.Cancel();

                        //    if (myReader.IsClosed == false)
                        //        myReader.Close();
                        //    myReader.Dispose();

                        //    continue;
                        //}

                        //更新用のSQL文を生成
                        #region UPDATE文
                        sqlText = "";
                        sqlText += "UPDATE GOODSPRICEURF SET" + Environment.NewLine;
                        sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                        sqlText += " , GOODSNORF=@GOODSNO" + Environment.NewLine;
                        sqlText += " , PRICESTARTDATERF=@PRICESTARTDATE" + Environment.NewLine;
                        sqlText += " , LISTPRICERF=@LISTPRICE" + Environment.NewLine;
                        sqlText += " , SALESUNITCOSTRF=@SALESUNITCOST" + Environment.NewLine;
                        sqlText += " , STOCKRATERF=@STOCKRATE" + Environment.NewLine;
                        sqlText += " , OPENPRICEDIVRF=@OPENPRICEDIV" + Environment.NewLine;
                        sqlText += " , OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                        sqlText += " , UPDATEDATERF=@UPDATEDATE" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                        sqlText += "  AND PRICESTARTDATERF=@FINDPRICESTARTDATE" + Environment.NewLine;
                        #endregion

                        sqlCommand.CommandText = sqlText;

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)GoodsPriceUWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                        GoodsPriceUWork.UpdateDate = GoodsPriceUWork.UpdateDateTime.Date;

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                        findParaMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                        findParaPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        //if (GoodsPriceUWork.UpdateDateTime > DateTime.MinValue)
                        //{
                        //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        //    errorMessage = "このデータは既に削除されています。";
                        //    sqlCommand.Cancel();
                        //    return status;
                        //}

                        //新規作成時のSQL文を生成
                        #region INSERT文
                        sqlText = "";
                        sqlText += "INSERT INTO GOODSPRICEURF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlText += "  ,GOODSNORF" + Environment.NewLine;
                        sqlText += "  ,PRICESTARTDATERF" + Environment.NewLine;
                        sqlText += "  ,LISTPRICERF" + Environment.NewLine;
                        sqlText += "  ,SALESUNITCOSTRF" + Environment.NewLine;
                        sqlText += "  ,STOCKRATERF" + Environment.NewLine;
                        sqlText += "  ,OPENPRICEDIVRF" + Environment.NewLine;
                        sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                        sqlText += "  ,UPDATEDATERF" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        sqlText += " VALUES" + Environment.NewLine;
                        sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                        sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  ,@GOODSNO" + Environment.NewLine;
                        sqlText += "  ,@PRICESTARTDATE" + Environment.NewLine;
                        sqlText += "  ,@LISTPRICE" + Environment.NewLine;
                        sqlText += "  ,@SALESUNITCOST" + Environment.NewLine;
                        sqlText += "  ,@STOCKRATE" + Environment.NewLine;
                        sqlText += "  ,@OPENPRICEDIV" + Environment.NewLine;
                        sqlText += "  ,@OFFERDATE" + Environment.NewLine;
                        sqlText += "  ,@UPDATEDATE" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        #endregion

                        sqlCommand.CommandText = sqlText;

                        //以下の処理で論理削除区分が０に書き換えられてしまう為、退避しておく
                        //商品在庫マスタからの論理削除時に使用する
                        int logicalDeleteCode = GoodsPriceUWork.LogicalDeleteCode;

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)GoodsPriceUWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                        GoodsPriceUWork.UpdateDate = GoodsPriceUWork.UpdateDateTime.Date;

                        GoodsPriceUWork.LogicalDeleteCode = logicalDeleteCode;
                    }
                    if (myReader.IsClosed == false)
                        myReader.Close();
                    myReader.Dispose();

                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraPriceStartDate = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
                    SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Float);
                    SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Float);
                    SqlParameter paraStockRate = sqlCommand.Parameters.Add("@STOCKRATE", SqlDbType.Float);
                    SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                    SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                    SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                    #endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(GoodsPriceUWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(GoodsPriceUWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(GoodsPriceUWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.LogicalDeleteCode);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.GoodsMakerCd);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(GoodsPriceUWork.GoodsNo);
                    paraPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.PriceStartDate);
                    // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                    //paraListPrice.Value = SqlDataMediator.SqlSetDouble(GoodsPriceUWork.ListPrice);
                    convertDoubleRelease.EnterpriseCode = GoodsPriceUWork.EnterpriseCode;
                    convertDoubleRelease.GoodsMakerCd = GoodsPriceUWork.GoodsMakerCd;
                    convertDoubleRelease.GoodsNo = GoodsPriceUWork.GoodsNo;
                    convertDoubleRelease.ConvertSetParam = GoodsPriceUWork.ListPrice;

                    // 変換処理実行
                    convertDoubleRelease.ConvertProc();

                    paraListPrice.Value = SqlDataMediator.SqlSetDouble(convertDoubleRelease.ConvertInfParam.ConvertGetParam);
                    // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
                    
                    paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(GoodsPriceUWork.SalesUnitCost);
                    paraStockRate.Value = SqlDataMediator.SqlSetDouble(GoodsPriceUWork.StockRate);
                    paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(GoodsPriceUWork.OpenPriceDiv);
                    paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.OfferDate);
                    paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(GoodsPriceUWork.UpdateDate);
                    #endregion

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                errorMessage = "更新処理でエラーが発生しました。";
                sqlCommand.Cancel();
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
            }

            return status;
        }



        bool GoodsMergeProc(PriceMergeSt st, GoodsUnitDataWork dest, GoodsUWork src)
        {
            bool updateFlg = false;
            if (st.NameMergeFlg == 0) // [名称更新] [する]の場合
            {
                dest.GoodsName = src.GoodsName;
                dest.GoodsNameKana = src.GoodsNameKana;
                updateFlg = true;
            }
            if (st.GoodsRankMergeFlg == 0) // [層別更新] [する]の場合
            {
                dest.GoodsRateRank = src.GoodsRateRank;
                updateFlg = true;
            }
            // 2009/12/11 Add >>>
            if (st.BLGoodeCdMergeFlg == 0) // [BLコード更新] [する]の場合
            {
                dest.BLGoodsCode = src.BLGoodsCode;
                updateFlg = true;
            }
            // 2009/12/11 Add <<<

            if (updateFlg) // 名称又は層別の更新がある場合　商品属性・提供日付・更新年月日を更新する。
            {
                dest.GoodsKindCode = src.GoodsKindCode;
                dest.OfferDate = src.OfferDate;
                dest.UpdateDate = DateTime.Now;
                dest.OfferDataDiv = 1;
            }
            return updateFlg;
        }
        #endregion

        #region [ 価格改正履歴処理 ]
        /// <summary>
        /// 価格改正履歴取得
        /// </summary>
        /// <param name="cond">履歴取得条件</param>
        /// <param name="retList">価格改正履歴データリスト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns></returns>
        public int GetUpdateHistory(PriUpdHistCondWork cond,
            out object retList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retList = null;
            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            SqlTransaction sqlTransaction = null;
            sqlConnection.Open();
            try
            {
                status = GetUpdateHistoryProc(cond, out retList, readMode, logicalMode, sqlConnection, sqlTransaction);
            }
            catch
            {
            }
            finally
            {
                if (sqlTransaction != null)
                {
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
        /// 価格改正履歴取得
        /// </summary>
        /// <param name="cond">履歴取得条件</param>
        /// <param name="retList">価格改正履歴データリスト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int GetUpdateHistory(
            PriUpdHistCondWork cond,
            out object retList, int readMode, ConstantManagement.LogicalMode logicalMode,
            SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return GetUpdateHistoryProc(cond, out retList, readMode, logicalMode, sqlConnection, sqlTransaction);
        }

        private int GetUpdateHistoryProc(PriUpdHistCondWork cond, out object retList, int readMode,
            ConstantManagement.LogicalMode logicalMode,
            SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retList = null;

            CustomSerializeArrayList al = new CustomSerializeArrayList();
            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                #region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "CREATEDATETIMERF," + Environment.NewLine;
                sqlText += "UPDATEDATETIMERF," + Environment.NewLine;
                sqlText += "ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "FILEHEADERGUIDRF," + Environment.NewLine;
                sqlText += "UPDEMPLOYEECODERF," + Environment.NewLine;
                sqlText += "UPDASSEMBLYID1RF," + Environment.NewLine;
                sqlText += "UPDASSEMBLYID2RF," + Environment.NewLine;
                sqlText += "LOGICALDELETECODERF," + Environment.NewLine;

                sqlText += "UPDATEDATADIVRF," + Environment.NewLine;
                sqlText += "DATAUPDATEDATETIMERF," + Environment.NewLine;
                sqlText += "SYNCTABLEIDRF," + Environment.NewLine;
                sqlText += "SYNCTABLENAMERF," + Environment.NewLine;
                sqlText += "ADDUPDATEROWSNORF," + Environment.NewLine;
                sqlText += "SYNCEXECUTEDATERF," + Environment.NewLine;
                sqlText += "OFFERDATERF," + Environment.NewLine;
                sqlText += "OFFERVERSIONRF" + Environment.NewLine;
                sqlText += "FROM PRIUPDHISRF" + Environment.NewLine;
                sqlText += MakeWhereString(cond, ref sqlCommand, logicalMode);

                sqlCommand.CommandText = sqlText;
                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToPriUpdTblUpdHisWorkFromReader(ref myReader));
                }

                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                retList = al;
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "OfferMergeDB.GetUpdateHistoryProc", ex.Number);
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

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="cond">条件</param>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        private string MakeWhereString(PriUpdHistCondWork cond, ref SqlCommand sqlCommand, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // 企業コード
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(cond.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = " AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = " AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // シンク実行日付
            if (cond.StartDate > 0)
            {
                retstring += " AND SYNCEXECUTEDATERF >= @FINDSYNCEXECUTEDATERFST" + Environment.NewLine;
                SqlParameter findSyncExecuteDtSt = sqlCommand.Parameters.Add("@FINDSYNCEXECUTEDATERFST", SqlDbType.Int);
                findSyncExecuteDtSt.Value = SqlDataMediator.SqlSetInt32(cond.StartDate);
            }
            if (cond.EndDate > 0)
            {
                retstring += " AND SYNCEXECUTEDATERF <= @FINDSYNCEXECUTEDATERFED" + Environment.NewLine;
                SqlParameter findSyncExecuteDtEd = sqlCommand.Parameters.Add("@FINDSYNCEXECUTEDATERFED", SqlDbType.Int);
                findSyncExecuteDtEd.Value = SqlDataMediator.SqlSetInt32(cond.StartDate);
            }

            return retstring;
        }

        /// <summary>
        /// クラス格納処理 Reader → PriUpdTblUpdHisWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PriUpdTblUpdHisWork</returns>
        private PriUpdTblUpdHisWork CopyToPriUpdTblUpdHisWorkFromReader(ref SqlDataReader myReader)
        {
            PriUpdTblUpdHisWork updHistWork = new PriUpdTblUpdHisWork();
            if (myReader != null)
            {
                # region クラスへ格納
                updHistWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                updHistWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                updHistWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                updHistWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                updHistWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                updHistWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                updHistWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                updHistWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                updHistWork.UpdateDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATADIVRF"));
                updHistWork.DataUpdateDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DATAUPDATEDATETIMERF"));
                updHistWork.SyncTableID = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYNCTABLEIDRF"));
                updHistWork.SyncTableName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYNCTABLENAMERF"));
                updHistWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                updHistWork.SyncExecuteDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYNCEXECUTEDATERF"));
                updHistWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                updHistWork.OfferVersion = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFERVERSIONRF"));
                # endregion
            }
            return updHistWork;
        }

        /// <summary>
        /// 価格改正履歴更新
        /// </summary>
        /// <param name="historyList">価格改正更新情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int WriteHistory(ref ArrayList historyList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            status = WriteHistoryProc(ref historyList, sqlConnection, sqlTransaction);

            return status;
        }

        private int WriteHistoryProc(ref ArrayList historyList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (historyList != null)
                {
                    string sqlText = string.Empty;

                    for (int i = 0; i < historyList.Count; i++)
                    {
                        sqlText = string.Empty;
                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        PriUpdTblUpdHisWork updHistWork = historyList[i] as PriUpdTblUpdHisWork;

                        # region [SELECT文]
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PRIUPDHISRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND DATAUPDATEDATETIMERF = @FINDDATAUPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "  AND SYNCTABLEIDRF = @FINDSYNCTABLEIDRF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findDataUpdateDateTime = sqlCommand.Parameters.Add("@FINDDATAUPDATEDATETIMERF", SqlDbType.BigInt);
                        SqlParameter findSyncTableID = sqlCommand.Parameters.Add("@FINDSYNCTABLEIDRF", SqlDbType.NVarChar);

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(updHistWork.EnterpriseCode);
                        findDataUpdateDateTime.Value = SqlDataMediator.SqlSetInt64(updHistWork.DataUpdateDateTime);
                        findSyncTableID.Value = SqlDataMediator.SqlSetString(updHistWork.SyncTableID);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            //if (_updateDateTime != updHistWork.UpdateDateTime)
                            //{
                            //    if (updHistWork.UpdateDateTime == DateTime.MinValue)
                            //    {
                            //        // 新規登録で該当データ有りの場合には重複
                            //        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //    }
                            //    else
                            //    {
                            //        // 既存データで更新日時違いの場合には排他
                            //        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            //    }

                            //    return status;
                            //}

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  PRIUPDHISRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;

                            sqlText += " ,UPDATEDATADIVRF = @UPDATEDATADIVRF" + Environment.NewLine;
                            sqlText += " ,DATAUPDATEDATETIMERF = @DATAUPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,SYNCTABLEIDRF = @SYNCTABLEIDRF" + Environment.NewLine;
                            sqlText += " ,SYNCTABLENAMERF = @SYNCTABLENAMERF" + Environment.NewLine;
                            sqlText += " ,ADDUPDATEROWSNORF = @ADDUPDATEROWSNORF" + Environment.NewLine;
                            sqlText += " ,SYNCEXECUTEDATERF = @SYNCEXECUTEDATERF" + Environment.NewLine;
                            sqlText += " ,OFFERDATERF = @OFFERDATERF" + Environment.NewLine;
                            sqlText += " ,OFFERVERSIONRF = @OFFERVERSIONRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND DATAUPDATEDATETIMERF = @FINDDATAUPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  AND SYNCTABLEIDRF = @FINDSYNCTABLEIDRF" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(updHistWork.EnterpriseCode);
                            findDataUpdateDateTime.Value = SqlDataMediator.SqlSetInt64(updHistWork.DataUpdateDateTime);
                            findSyncTableID.Value = SqlDataMediator.SqlSetString(updHistWork.SyncTableID);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)updHistWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            //if (updHistWork.UpdateDateTime > DateTime.MinValue)
                            //{
                            //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            //    return status;
                            //}

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO PRIUPDHISRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;

                            sqlText += " ,UPDATEDATADIVRF" + Environment.NewLine;
                            sqlText += " ,DATAUPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,SYNCTABLEIDRF" + Environment.NewLine;
                            sqlText += " ,SYNCTABLENAMERF" + Environment.NewLine;
                            sqlText += " ,ADDUPDATEROWSNORF" + Environment.NewLine;
                            sqlText += " ,SYNCEXECUTEDATERF" + Environment.NewLine;
                            sqlText += " ,OFFERDATERF" + Environment.NewLine;
                            sqlText += " ,OFFERVERSIONRF" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;

                            sqlText += " ,@UPDATEDATADIVRF" + Environment.NewLine;
                            sqlText += " ,@DATAUPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,@SYNCTABLEIDRF" + Environment.NewLine;
                            sqlText += " ,@SYNCTABLENAMERF" + Environment.NewLine;
                            sqlText += " ,@ADDUPDATEROWSNORF" + Environment.NewLine;
                            sqlText += " ,@SYNCEXECUTEDATERF" + Environment.NewLine;
                            sqlText += " ,@OFFERDATERF" + Environment.NewLine;
                            sqlText += " ,@OFFERVERSIONRF" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)updHistWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        SqlParameter paraUpdateDataDiv = sqlCommand.Parameters.Add("@UPDATEDATADIVRF", SqlDbType.NVarChar);
                        SqlParameter paraDataUpdateDateTime = sqlCommand.Parameters.Add("@DATAUPDATEDATETIMERF", SqlDbType.BigInt);
                        SqlParameter paraSyncTableID = sqlCommand.Parameters.Add("@SYNCTABLEIDRF", SqlDbType.NVarChar);
                        SqlParameter paraSyncTableName = sqlCommand.Parameters.Add("@SYNCTABLENAMERF", SqlDbType.NVarChar);
                        SqlParameter paraAddUpdateRowsNo = sqlCommand.Parameters.Add("@ADDUPDATEROWSNORF", SqlDbType.Int);
                        SqlParameter paraSyncExecuteDate = sqlCommand.Parameters.Add("@SYNCEXECUTEDATERF", SqlDbType.Int);
                        SqlParameter paraOfferData = sqlCommand.Parameters.Add("@OFFERDATERF", SqlDbType.Int);
                        SqlParameter paraOfferVersion = sqlCommand.Parameters.Add("@OFFERVERSIONRF", SqlDbType.NVarChar);

                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(updHistWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(updHistWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(updHistWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(updHistWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(updHistWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(updHistWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(updHistWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(updHistWork.LogicalDeleteCode);

                        paraUpdateDataDiv.Value = SqlDataMediator.SqlSetInt32(updHistWork.UpdateDataDiv);
                        paraDataUpdateDateTime.Value = SqlDataMediator.SqlSetInt64(updHistWork.DataUpdateDateTime);
                        paraSyncTableID.Value = SqlDataMediator.SqlSetString(updHistWork.SyncTableID);
                        paraSyncTableName.Value = SqlDataMediator.SqlSetString(updHistWork.SyncTableName);
                        paraAddUpdateRowsNo.Value = SqlDataMediator.SqlSetInt32(updHistWork.AddUpdateRowsNo);
                        paraSyncExecuteDate.Value = SqlDataMediator.SqlSetInt32(updHistWork.SyncExecuteDate);
                        paraOfferData.Value = SqlDataMediator.SqlSetInt32(updHistWork.OfferDate);
                        paraOfferVersion.Value = SqlDataMediator.SqlSetString(updHistWork.OfferVersion);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(updHistWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "OfferMergeDB.WriteHistoryProc(ref ArrayList, ref SqlConnection, ref SqlTransaction)", ex.Number);
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

            historyList = al;

            return status;
        }

        // --- ADD 2010/05/24 ---------->>>>>
        /// <summary>
        /// 価格改正履歴削除
        /// </summary>
        /// <param name="historyList">価格改正更新情報を格納する</param>
        /// <remarks>
        /// <br>Note       : 削除処理を追加する</br>
        /// <br>Programmer : 朱俊成</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int DeleteHistory(ArrayList historyList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            status = DeleteHistoryProc(historyList);

            return status;
        }

        /// <summary>
        /// 価格改正履歴削除
        /// </summary>
        /// <param name="historyList">価格改正更新情報を格納する</param>
        /// <remarks>
        /// <br>Note       : 削除処理を追加する</br>
        /// <br>Programmer : 朱俊成</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private int DeleteHistoryProc(ArrayList historyList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = CreateSqlConnection();
            // トランザクション開始
            SqlTransaction sqlTransaction = this.CreateTransaction(ref sqlConnection);
            if (sqlConnection == null || sqlTransaction == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (historyList != null)
                {
                    string sqlText = string.Empty;

                    for (int i = 0; i < historyList.Count; i++)
                    {
                        sqlText = string.Empty;
                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        PriUpdTblUpdHisWork updHistWork = historyList[i] as PriUpdTblUpdHisWork;

                        # region [SELECT文]
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PRIUPDHISRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND UPDATEDATADIVRF = @FINDUPDATEDATADIVRF" + Environment.NewLine;
                        sqlText += "  AND DATAUPDATEDATETIMERF = @FINDDATAUPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "  AND SYNCTABLEIDRF = @FINDSYNCTABLEIDRF" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findUpdateDataDiv = sqlCommand.Parameters.Add("@FINDUPDATEDATADIVRF", SqlDbType.NChar);
                        SqlParameter findDataUpdateDateTime = sqlCommand.Parameters.Add("@FINDDATAUPDATEDATETIMERF", SqlDbType.BigInt);
                        SqlParameter findSyncTableID = sqlCommand.Parameters.Add("@FINDSYNCTABLEIDRF", SqlDbType.NVarChar);

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(updHistWork.EnterpriseCode);
                        findUpdateDataDiv.Value = SqlDataMediator.SqlSetInt32(updHistWork.UpdateDataDiv);
                        findDataUpdateDateTime.Value = SqlDataMediator.SqlSetInt64(updHistWork.DataUpdateDateTime);
                        findSyncTableID.Value = SqlDataMediator.SqlSetString(updHistWork.SyncTableID);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != updHistWork.UpdateDateTime)
                            {
                                if (updHistWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    // 新規登録で該当データ有りの場合には重複
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    // 既存データで更新日時違いの場合には排他
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  PRIUPDHISRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND UPDATEDATADIVRF = @FINDUPDATEDATADIVRF" + Environment.NewLine;
                            sqlText += "  AND DATAUPDATEDATETIMERF = @FINDDATAUPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  AND SYNCTABLEIDRF = @FINDSYNCTABLEIDRF" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(updHistWork.EnterpriseCode);
                            findUpdateDataDiv.Value = SqlDataMediator.SqlSetInt32(updHistWork.UpdateDataDiv);
                            findDataUpdateDateTime.Value = SqlDataMediator.SqlSetInt64(updHistWork.DataUpdateDateTime);
                            findSyncTableID.Value = SqlDataMediator.SqlSetString(updHistWork.SyncTableID);

                        }
                        else
                        {
                           status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                           return status;

                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.ExecuteNonQuery();
                        //al.Add(updHistWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "OfferMergeDB.DeleteHistoryProc(ArrayList)", ex.Number);
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
        // --- ADD 2010/05/24 -----------<<<<<



        /// <summary>
        /// 価格改正履歴の最新提供日付取得
        /// </summary>
        /// <param name="offerDate">最新提供日付</param>
        /// <returns></returns>
        public int GetLastOfferDate(out int offerDate)
        {
            return GetLastOfferDateProc(out offerDate);
        }

        private int GetLastOfferDateProc(out int offerDate)
        {
            offerDate = 0;
            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            sqlConnection.Open();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlCommand sqlCommand = null;
            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region [SELECT文]
                sqlText += "SELECT TOP 1" + Environment.NewLine;
                sqlText += "OFFERDATERF" + Environment.NewLine;
                sqlText += "FROM PRIUPDHISRF" + Environment.NewLine;
                sqlText += "ORDER BY OFFERDATERF DESC" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                #endregion

                object val = sqlCommand.ExecuteScalar();
                if (val != null)
                    offerDate = (int)val;

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "OfferMergeDB.GetUpdateHistoryProc", ex.Number);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        /// <summary>
        /// マージチェック処理
        /// </summary>
        /// <param name="MergeResultData">チェック区分</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="currentVersion"></param>
        /// <returns></returns>
        public int MergeChk(string enterpriseCode, out int MergeResultData, string currentVersion)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string LogDataObjProcNm = string.Empty;
            string LogDataMassage = string.Empty;
            int count = 0;
            MergeResultData = 0;

            // マージチェックリモート読み込み
            //status = _versionChkWorkDB.MergeCheck(out MergeResultData, enterpriseCode, currentVersion);

            LogDataObjProcNm = "MergeChk";
            LogDataMassage = "マージチェック(手動)";
            count = 0;
            WriteLog(enterpriseCode, LogDataObjProcNm, LogDataMassage, status, count);

            return status;
        }

        /// <summary>
        /// 勝手にインスタンスが消える減少を防ぐため
        /// </summary>
        /// <returns></returns>
        public override object InitializeLifetimeService()
        {
            ILease lease = (ILease)base.InitializeLifetimeService();
            if (lease.CurrentState == LeaseState.Initial)
            {
                //lease.InitialLeaseTime = TimeSpan.FromMinutes(10);
                lease.InitialLeaseTime = TimeSpan.FromHours(10);
                lease.SponsorshipTimeout = TimeSpan.FromMinutes(20);
                lease.RenewOnCallTime = TimeSpan.FromMinutes(60);
            }
            return lease;

        }

        /// <summary>
        /// マージ処理＋価格改正処理
        /// </summary>
        /// <param name="upDateDiv">更新データ区分(0:ＵＩ　1:自動)[履歴記録用]</param>
        /// <param name="offerDate">提供日付[履歴記録用]</param>
        /// <param name="st">価格改正設定</param>
        /// <param name="lst">価格改正処理用データリスト</param>
        /// <param name="retList">処理結果のリスト</param>
        /// <param name="lstData">処理結果のリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="currentVersion">提供バージョン</param>
        /// <param name="prmSetList"></param>
        /// <param name="NameChgFlg"></param>
        /// <param name="allUpdateCount">優良設定更新件数</param>
        /// <returns></returns>
        public int WriteManual(int upDateDiv, int offerDate, PriceMergeSt st, CustomSerializeArrayList lst, out object retList, object lstData, CustomSerializeArrayList prmSetList,
            string enterpriseCode, string currentVersion, bool NameChgFlg, ref int allUpdateCount, object updateMasterObj, int PartsPsDate)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string LogDataObjProcNm = string.Empty;
            string LogDataMassage = string.Empty;
            string resNm = string.Empty;
            int count = 0;
            bool checkFlg = false;

            EnterpriseCd = enterpriseCode;

            retList = null;

            _currentVersion = currentVersion;

            // コネクション生成
            SqlConnection sqlConnection = CreateSqlConnection();
            SqlConnection sqlConnection2 = CreateSqlConnection();

            if (sqlConnection == null || sqlConnection2 == null)
            {
                return status = (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            SqlTransaction sqlTransaction = null;
            try
            {
                // ｺﾈｸｼｮﾝ･ﾄﾗﾝｯｻﾞｸｼｮﾝ開始
                sqlConnection.Open();
                sqlConnection2.Open();
                sqlTransaction = sqlConnection.BeginTransaction();

                # if !DEBUG
                // APPロック
                resNm = GetResourceName(enterpriseCode);
                Lock(resNm, sqlConnection, sqlTransaction);
                # endif

                #region バージョンチェック処理　1.5次追加分 DELETE
                // 自動の場合 のみ　　DELETE → か手動の場合でもﾊﾞｰｼﾞｮﾝが異なる場合のみ(価格改正ﾌﾗｸﾞが入っている)
                // 手動でﾊﾞｰｼﾞｮﾝが一緒の場合はここではチェックしない
                if (upDateDiv == 1 /*|| st != null*/)
                {
                    // 価格改正履歴の最終versionと一致していないか再度確認
                    status = VersionChkWork(enterpriseCode, currentVersion, ref checkFlg, ref sqlConnection2);
                    if (checkFlg == false)
                    {
                        return status;
                    }
                }
                #endregion

                #region 履歴更新用前回日付取得処理
                MergeObjectCond updateMasterFlg = updateMasterObj as MergeObjectCond;

                int makerOfferDate = 0;         // 前回ﾒｰｶｰ提供日付
                int modelNameOfferDate = 0;     // 前回車種提供日付
                int goodsMGroupOfferDate = 0;   // 前回中分類提供日付
                int blGroupOfferDate = 0;       // 前回BLｸﾞﾙｰﾌﾟ提供日付
                int blCodeOfferDate = 0;        // 前回BLｺｰﾄﾞ提供日付
                int partsPosOffrDate = 0;       // 前回部位提供日付
                int prmSettingOfferDate = 0;    // 前回優良設定提供日付
                int pricerevisionOfferDate =0;  // 前回価格改正提供日付

                // 前回履歴検索
                object LatestOfferDateObj = null;
                GetLatestHistoryProc(EnterpriseCd, out LatestOfferDateObj);
                ArrayList Latestlst = LatestOfferDateObj as ArrayList;
                if (Latestlst.Count != 0)
                {
                    // 各テーブル前回処理日抽出
                    foreach (PriUpdTblUpdHisWork priupdWork in Latestlst)
                    {
                        switch (priupdWork.SyncTableName)
                        {
                            case "MAKERURF":
                                makerOfferDate = priupdWork.OfferDate;
                                break;
                            case "MODELNAMEURF":
                                modelNameOfferDate = priupdWork.OfferDate;
                                break;
                            case "GOODSGROUPURF":
                                goodsMGroupOfferDate = priupdWork.OfferDate;
                                break;
                            case "BLGROUPURF":
                                blGroupOfferDate = priupdWork.OfferDate;
                                break;
                            case "BLGOODSCDURF":
                                blCodeOfferDate = priupdWork.OfferDate;
                                break;
                            case "PARTSPOSCODEURF":
                                partsPosOffrDate = priupdWork.OfferDate;
                                break;
                            case "PRMSETTINGURF":
                                prmSettingOfferDate = priupdWork.OfferDate;
                                break;
                            case "GOODSURF":
                                pricerevisionOfferDate = priupdWork.OfferDate;
                                break;
                        }
                    }
                }
                #endregion

                #region WriteMergeData読み込み(マージ処理:手動)

                // 各ﾏｽﾀﾏｰｼﾞ処理
                status = this.WriteMergeDataProc(upDateDiv, offerDate, lstData, updateMasterFlg, sqlConnection, sqlTransaction
                    , makerOfferDate, modelNameOfferDate, goodsMGroupOfferDate, blGroupOfferDate, blCodeOfferDate, partsPosOffrDate, PartsPsDate);
                if ((lstData as ArrayList).Count != 0)
                {
                    LogDataObjProcNm = "WriteMergeData";
                    LogDataMassage = "マージ処理";
                    CustomSerializeArrayList lstdataList = lstData as CustomSerializeArrayList;
                    count = lstdataList.Count;

                    WriteLog(enterpriseCode, LogDataObjProcNm, LogDataMassage, status, count);
                }

                #endregion

                #region 優良設定マスタSFILE対応　1.5次追加分

                status = SettingSfile(upDateDiv, offerDate, prmSetList, NameChgFlg, enterpriseCode, ref allUpdateCount, sqlConnection, sqlTransaction, prmSettingOfferDate, updateMasterFlg);

                #endregion


                #region PriceRevision読み込み(価格改正処理:手動)
                status = this.DoPriceRevisionProc(st, lst, out retList, sqlConnection, sqlConnection2, sqlTransaction, pricerevisionOfferDate, updateMasterFlg);
                LogDataObjProcNm = "DoPriceRevision";
                LogDataMassage = "価格改正処理";
                count = lst.Count;

                WriteLog(enterpriseCode, LogDataObjProcNm, LogDataMassage, status, count);
                //if (retList == null) retList = new ArrayList();
                #endregion

                # if !DEBUG
                // APPロック解除
                Release(resNm, sqlConnection, sqlTransaction);
                # endif
            }                  
            catch
            {
                sqlTransaction.Rollback();
            }
            finally
            {
                if (status == 0 || status == 9 || status == 4)
                {
                    status = 0;
                }
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == 0 || status == 9 || status == 4)
                        {
                            status = 0;
                            sqlTransaction.Commit();
                        }
                        else
                            sqlTransaction.Rollback();
                    }
                    sqlTransaction.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                if (sqlConnection2 != null)
                {
                    sqlConnection2.Close();
                    sqlConnection2.Dispose();
                }
            }
            return status;
        }

        // バージョンチェック
        private int VersionChkWork(string EnterpriseCode, string currentVersion, ref bool checkFlg, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE; 
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string MergedVersion = string.Empty;

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection);

            sqlText += " SELECT " + Environment.NewLine;
            sqlText += "  MAX(OFFERVERSIONRF) AS OFFERVERSION " + Environment.NewLine;
            sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
            sqlText += " WHERE ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;

            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);

            sqlCommand.CommandText = sqlText;
            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {
                MergedVersion = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFERVERSION"));
            }

            if (MergedVersion != currentVersion)
            {
                checkFlg = true;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; 
            }

            return status;
        }

        // 優良設定マスタSFILE対応
        private int SettingSfile(int upDateDiv, int offerDate, CustomSerializeArrayList prmSetList, bool NameChgFlg, string enterpriseCode, ref int allUpdateCount, SqlConnection sqlConnection, SqlTransaction sqlTransaction, int prmSettingOfferDate, MergeObjectCond updateMasterFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // *** ディクショナリ内構図 *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** ***
            //
            // prmSetList(CustomSerialArray)                             [大枠]
            // │
            // ├usrUpdatePrmSettingChgLst(Dictionary<int,ArrayList>)    [優良設定変更マスタ]
            // │├[0] <日付,変更マスタ>                                 [ﾃﾞｨｸｼｮﾅﾘ<日付,変更ﾏｽﾀ>]
            // │└[1] <日付,変更マスタ>                                 [          〃          ]
            // │           :
            // ｜
            // └usrUpdatePrmSettingLst(Dictionary<int,ArrayList>)       [優良設定マスタ]
            //   ├[0] <日付,設定マスタ>                                 [ﾃﾞｨｸｼｮﾅﾘ<日付,設定ﾏｽﾀ>]
            //   └｢1｣ <日付,設定マスタ>                                 [          〃          ]
            //              ：
            // *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** ***

            Dictionary<int, ArrayList> offerUpdatePrmSettingLst = null;     // 提供優良設定マスタ
            Dictionary<int, ArrayList> offerUpdatePrmSettingChgLst =null;   // 提供優良設定変更マスタ
            object usrUpdatePrmSettingChgLst = null;                        // ﾕｰｻﾞｰ優良設定マスタ

            ArrayList deletePrmSetList = new ArrayList();                   // ﾕｰｻﾞｰ削除ﾘｽﾄ
            ArrayList writePrmSetList = new ArrayList();                    // ﾕｰｻﾞｰ更新ﾘｽﾄ
            PrmSettingUWork writePrmSettingUWork = new PrmSettingUWork();   // ﾕｰｻﾞｰ書込優良設定ﾃﾞｰﾀｸﾗｽ 
            ArrayList deleteGoodsMngList = new ArrayList();                 // 商品管理情報削除ﾘｽﾄ

            PriUpdTblUpdHisWork hist = new PriUpdTblUpdHisWork();           // 履歴更新ﾜｰｸ
            ArrayList histList = new ArrayList();                           // 履歴更新リスト

            int UpdateCount = 0;　// 優良設定変更更新件数
            allUpdateCount = 0;   // 優良設定更新総件数

            int histPrmOfferDate =0; // 履歴用提供日付
            PrmSettingUWork histWork =null; // 履歴用ワーク

            _goodsMngDB = new GoodsMngDB();

            // 提供リスト
            for(int i = 0; i < prmSetList.Count; i++)
            {
                Dictionary<int, ArrayList> retList = (Dictionary<int, ArrayList>)prmSetList[i];
                ArrayList List = null;
                if (retList != null && retList.Count > 0)
                {
                    for (int j = 0; j < retList.Count; j++)
                    {
                        foreach (int _offerDate in retList.Keys)
                        {
                            // ｷｰになる日付が存在しなかったら戻る
                            if (!(retList.ContainsKey(_offerDate)))
                            {
                                continue;
                            }

                            // 提供リスト抽出
                            retList.TryGetValue(_offerDate, out List);
                            switch (List[0].GetType().Name)
                            {
                                case "PrmSettingWork":　// 提供優良設定マスタ
                                    offerUpdatePrmSettingLst = prmSetList[i] as Dictionary<int, ArrayList>;
                                    break;

                                case "PrmSettingChgWork": // 提供優良設定変更マスタ
                                    offerUpdatePrmSettingChgLst = prmSetList[i] as Dictionary<int, ArrayList>;
                                    break;
                            }
                        }
                    }
                }
            }

            // ﾕｰｻﾞｰ優良取得用
            MergeObjectCond mergeCond = new MergeObjectCond();

            // 優良設定取得フラグ
            mergeCond.PrmSetFlg = 1;
            mergeCond.EnterpriseCode = enterpriseCode;

            // 空っぽのリスト、メソット呼ぶためだけに使用
            ArrayList EmptyList = new ArrayList();

            // ﾕｰｻﾞｰ検索
            //this.GetMergeObject(mergeCond, EmptyList, out usrUpdatePrmSettingChgLst);

            ArrayList UsrList = null;

            //if (usrUpdatePrmSettingChgLst != null)
            //{
            //    UsrList = (usrUpdatePrmSettingChgLst as ArrayList)[0] as ArrayList;
            //}

            // 日付リスト作成
            ArrayList OfferDateList = new ArrayList();
            if(offerUpdatePrmSettingLst != null)
            {
                foreach (int Date in offerUpdatePrmSettingLst.Keys)
                {
                    if (!(OfferDateList.Contains(Date)))
                    {
                        OfferDateList.Add(Date);
                        OfferDateList.Sort();
                    }
                }
            }
            if (offerUpdatePrmSettingChgLst != null)
            {
                foreach (int Date in offerUpdatePrmSettingChgLst.Keys)
                {
                    if (!(OfferDateList.Contains(Date)))
                    {
                        OfferDateList.Add(Date);
                        OfferDateList.Sort();
                    }
                }
            }

            //// コネクション生成
            //SqlConnection sqlConnection2 = CreateSqlConnection();
            //if (sqlConnection == null || sqlConnection2 == null)
            //{
            //    return status = (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            //}

            //// 日付ﾙｰﾌﾟ用ﾄﾗﾝｻﾞｸｼｮﾝ
            //SqlTransaction sqlTransaction2 = null;

            try
            {
                //if (UsrList != null)
                //{
                    //// コネクションオープン
                    //sqlConnection2.Open();
                    //// 日付毎のﾄﾗﾝｻﾞｸｼｮﾝ開始
                    //sqlTransaction2 = sqlConnection2.BeginTransaction();

                    // 日付で変更マスタをマージしてから設定マスタをマージする

                    // 日付ﾙｰﾌﾟ
                    if (OfferDateList.Count != 0)
                    {
                        foreach (int prmOfferDate in OfferDateList)
                        {
                            writePrmSetList.Clear();

                            // 優良設定変更ﾏｽﾀﾏｰｼﾞ
                            ArrayList offerCHGList = null;
                            if (offerUpdatePrmSettingChgLst != null) offerUpdatePrmSettingChgLst.TryGetValue(prmOfferDate, out offerCHGList);

                            ArrayList offerSETList = null;
                            if (offerUpdatePrmSettingLst != null) offerUpdatePrmSettingLst.TryGetValue(prmOfferDate, out offerSETList);

                            #region 変更マスタマージ

                            // コネクション生成
                            SqlConnection sqlConnection2 = CreateSqlConnection();
                            if (sqlConnection == null || sqlConnection2 == null)
                            {
                                return status = (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
                            }

                            // 日付ﾙｰﾌﾟ用ﾄﾗﾝｻﾞｸｼｮﾝ
                            SqlTransaction sqlTransaction2 = null;
                            try
                            {
                                // コネクションオープン
                                sqlConnection2.Open();
                                // 日付毎のﾄﾗﾝｻﾞｸｼｮﾝ開始
                                sqlTransaction2 = sqlConnection2.BeginTransaction();

                                // ﾕｰｻﾞｰ検索
                                this.GetMergeObject(mergeCond, EmptyList, out usrUpdatePrmSettingChgLst);

                                if (usrUpdatePrmSettingChgLst != null)
                                {
                                    if (UsrList != null)
                                    {
                                        UsrList.Clear();
                                    }
                                    if ((usrUpdatePrmSettingChgLst as ArrayList).Count != 0)
                                        UsrList = (usrUpdatePrmSettingChgLst as ArrayList)[0] as ArrayList;
                                    
                                }
                                if (UsrList == null) break;

                                // ﾕｰｻﾞｰﾙｰﾌﾟ
                                foreach (PrmSettingUWork SetUsrWork in UsrList)
                                {
                                    if (offerCHGList == null)
                                    {
                                        break;
                                    }

                                    // 変更マスタループ
                                    foreach (PrmSettingChgWork SetChgWork in offerCHGList)
                                    {
                                        // 5つのｷｰが同じだったら (ﾒｰｶｰ･BL･中分類･詳細ｺｰﾄﾞ1･詳細ｺｰﾄﾞ2)
                                        if (SetUsrWork.PartsMakerCd == SetChgWork.PartsMakerCd && SetUsrWork.TbsPartsCode == SetChgWork.TbsPartsCode && SetUsrWork.GoodsMGroup == SetChgWork.GoodsMGroup
                                            && SetUsrWork.PrmSetDtlNo1 == SetChgWork.PrmSetDtlNo1 && SetUsrWork.PrmSetDtlNo2 == SetChgWork.PrmSetDtlNo2)
                                        {
                                            // 提供データの提供日付とユーザーデータの提供日付が同じだった場合処理を行わない
                                            if (SetUsrWork.OfferDate == SetChgWork.OfferDate)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                // 削除判定
                                                if (SetChgWork.ProcDivCd == 1)
                                                {
                                                    //削除リストに追加
                                                    deletePrmSetList.Add(SetUsrWork);
                                                }

                                                // マージ 
                                                else
                                                {
                                                    // 書込ﾃﾞｰﾀｸﾗｽｸﾘｱ処理
                                                    writePrmSettingUWork = new PrmSettingUWork();

                                                    // 2010/09/07 >>>
                                                    //if (SetChgWork.AfPrmSetDtlNo1 > 0 || SetChgWork.AfPrmSetDtlNo2 > 0 || SetChgWork.AfPrimeDisplayCode == 1 || SetChgWork.AfPrimeDisplayCode == 2)
                                                    if (SetChgWork.AfPrmSetDtlNo1 >= 0 || SetChgWork.AfPrmSetDtlNo2 >= 0 || SetChgWork.AfPrimeDisplayCode == 1 || SetChgWork.AfPrimeDisplayCode == 2)
                                                    // 2010/09/07 <<<
                                                    {
                                                        // 詳細コード1,2,優良表示区分書換
                                                        SetPrmSetDtlNo(ref writePrmSettingUWork, SetUsrWork, SetChgWork);

                                                        // 詳細ｺｰﾄﾞ1,2,優良表示区分を書き換えた場合の書込ﾃﾞｰﾀｸﾗｽを書込用ﾘｽﾄに追加
                                                        writePrmSetList.Add(writePrmSettingUWork);

                                                        // 詳細ｺｰﾄﾞ1,2,優良表示区分を書き換えた場合は元のﾃﾞｰﾀは削除ﾘｽﾄに追加
                                                        deletePrmSetList.Add(SetUsrWork);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                // ｸﾘｱ処理
                                deleteGoodsMngList.Clear();

                                // 商品管理情報マスタ削除ﾘｽﾄ作成処理
                                if (deletePrmSetList.Count != 0)
                                {
                                    // --- UPD m.suzuki 2010/10/06 ---------->>>>>
                                    //status = DeleteGoodsMng(deletePrmSetList, ref deleteGoodsMngList, ref sqlConnection2, ref sqlTransaction2);
                                    status = DeleteGoodsMng( writePrmSetList, deletePrmSetList, ref deleteGoodsMngList, ref sqlConnection2, ref sqlTransaction2 );
                                    // --- UPD m.suzuki 2010/10/06 ----------<<<<<
                                }

                                // ﾕｰｻﾞｰ優良設定ﾏｽﾀ削除処理
                                if (deletePrmSetList.Count != 0)
                                {
                                    status = PrimeSettingDelete(deletePrmSetList, ref sqlConnection2, ref sqlTransaction2);
                                }

                                // ﾕｰｻﾞｰ優良設定ﾏｽﾀに書込
                                if (writePrmSetList.Count != 0)
                                {
                                    status = PrmSettingWrite(ref writePrmSetList, ref sqlConnection2, ref sqlTransaction2);
                                }
                            }
                            catch
                            {
                                sqlTransaction2.Rollback();
                            }
                            finally
                            {
                                if (sqlTransaction2 != null)
                                {
                                    if (sqlTransaction2.Connection != null)
                                    {
                                        if (status == 0 || status == 9 || status == 4)
                                            sqlTransaction2.Commit();
                                        else
                                            sqlTransaction2.Rollback();
                                    }
                                    sqlTransaction2.Dispose();
                                }

                                if (sqlConnection2 != null)
                                {
                                    sqlConnection2.Close();
                                    sqlConnection2.Dispose();
                                }
                            }
                            #endregion

                            UpdateCount += writePrmSetList.Count;

                            if(writePrmSetList.Count !=0)
                            {
                                histWork = writePrmSetList[writePrmSetList.Count -1] as PrmSettingUWork;
                                histPrmOfferDate = histWork.OfferDate;
                            }
                            writePrmSetList.Clear();

                            #region　設定マスタマージ

                            // コネクション生成
                            SqlConnection sqlConnection3 = CreateSqlConnection();
                            if (sqlConnection == null || sqlConnection3 == null)
                            {
                                return status = (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
                            }

                            // 日付ﾙｰﾌﾟ用ﾄﾗﾝｻﾞｸｼｮﾝ
                            SqlTransaction sqlTransaction3 = null;

                            // 名称更新ﾌﾗｸﾞがあれば更新
                            try
                            {
                                if (NameChgFlg == true)
                                {
                                    // コネクションオープン
                                    sqlConnection3.Open();
                                    // 日付毎のﾄﾗﾝｻﾞｸｼｮﾝ開始
                                    sqlTransaction3 = sqlConnection3.BeginTransaction();

                                    // ﾕｰｻﾞｰ検索
                                    this.GetMergeObject(mergeCond, EmptyList, out usrUpdatePrmSettingChgLst);

                                    if (usrUpdatePrmSettingChgLst != null)
                                    {
                                        if (UsrList != null) UsrList.Clear();
                                        UsrList = (usrUpdatePrmSettingChgLst as ArrayList)[0] as ArrayList;
                                    }

                                    // ﾕｰｻﾞｰﾙｰﾌﾟ
                                    foreach (PrmSettingUWork SetUsrWork in UsrList)
                                    {
                                        if (offerSETList == null)
                                        {
                                            break;
                                        }

                                        // 優良設定ﾏｽﾀﾏｰｼﾞ
                                        foreach (PrmSettingWork SettOfrWork in offerSETList)
                                        {
                                            // 5つのｷｰが同じだったら (ﾒｰｶｰ･BL･中分類･詳細ｺｰﾄﾞ1,2)
                                            if (SetUsrWork.PartsMakerCd == SettOfrWork.PartsMakerCd && SetUsrWork.TbsPartsCode == SettOfrWork.TbsPartsCode && SetUsrWork.GoodsMGroup == SettOfrWork.GoodsMGroup
                                                && SetUsrWork.PrmSetDtlNo1 == SettOfrWork.PrmSetDtlNo1 && SetUsrWork.PrmSetDtlNo2 == SettOfrWork.PrmSetDtlNo2)
                                            {
                                                //// 提供データの提供日付とユーザーデータの提供日付が同じだった場合処理を行わない
                                                //if (SetUsrWork.OfferDate == SettOfrWork.OfferDate)
                                                if (SetUsrWork.OfferDate > SettOfrWork.OfferDate)
                                                {
                                                    continue;
                                                }
                                                else
                                                {
                                                    // 書込ﾃﾞｰﾀｸﾗｽｸﾘｱ処理
                                                    writePrmSettingUWork = new PrmSettingUWork();

                                                    // 詳細名称1,2書換
                                                    SetPrmSetDtlName(ref writePrmSettingUWork, SetUsrWork, SettOfrWork);

                                                    // 更新ﾘｽﾄに追加
                                                    writePrmSetList.Add(writePrmSettingUWork);
                                                }
                                            }
                                        }
                                    }
                                }
                                // 優良設定ﾏｽﾀ書込処理
                                if (writePrmSetList.Count != 0)
                                {
                                    status = PrmSettingWrite(ref writePrmSetList, ref sqlConnection3, ref sqlTransaction3);
                                }
                            }
                            catch
                            {
                                sqlTransaction3.Rollback();
                            }
                            finally
                            {
                                if (sqlTransaction3 != null)
                                {
                                    if (sqlTransaction3.Connection != null)
                                    {
                                        if (status == 0 || status == 9 || status == 4)
                                            sqlTransaction3.Commit();
                                        else
                                            sqlTransaction3.Rollback();
                                    }
                                    sqlTransaction3.Dispose();

                                }

                                if (sqlConnection3 != null)
                                {
                                    sqlConnection3.Close();
                                    sqlConnection3.Dispose();
                                }
                            }

                            UpdateCount += writePrmSetList.Count;

                            if(writePrmSetList.Count !=0)
                            {
                                histWork = writePrmSetList[writePrmSetList.Count -1] as PrmSettingUWork;
                                histPrmOfferDate = histWork.OfferDate;
                            }
                            #endregion
                        }
                    }
                //}
                    if (updateMasterFlg.PrmSetFlg == 1)
                    {
                        hist = MakeHistInfo();
                        hist.SyncTableID = "PRMSETTINGURF";
                        hist.SyncTableName = "優良設定マスタ";

                        if (status == 0)
                        {
                            if (UpdateCount != 0)
                            {
                                hist.AddUpdateRowsNo = (UpdateCount);
                                if (histPrmOfferDate != 0) hist.OfferDate = histPrmOfferDate;
                                else hist.OfferDate = prmSettingOfferDate;
                            }
                            else
                            {
                                hist.AddUpdateRowsNo = 0;
                                hist.OfferDate = prmSettingOfferDate;
                            }
                        }
                        else
                        {
                            hist.AddUpdateRowsNo = 0;
                            hist.OfferDate = prmSettingOfferDate;
                        }
                        histList.Add(hist);

                        WriteHistoryProc(ref histList, sqlConnection, sqlTransaction); // 履歴記録

                        allUpdateCount += (UpdateCount);
                    }
                }
                catch
                {
                    //sqlTransaction2.Rollback();
                }
                finally
                {
                    //if (sqlTransaction2 != null)
                    //{
                    //    if (sqlTransaction2.Connection != null)
                    //    {
                    //        if (status == 0 || status == 9 || status == 4)
                    //            sqlTransaction2.Commit();
                    //        else
                    //            sqlTransaction2.Rollback();
                    //    }
                    //    sqlTransaction2.Dispose();
                    //}

                    //if (sqlConnection2 != null)
                    //{
                    //    sqlConnection2.Close();
                    //    sqlConnection2.Dispose();
                    //}
                }
                return status;
            }


        // 商品管理情報削除処理
        // --- UPD m.suzuki 2010/10/06 ---------->>>>>
        //private int DeleteGoodsMng(ArrayList deletePrmSetList,ref ArrayList deleteGoodsMngList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int DeleteGoodsMng( ArrayList writePrmSetList, ArrayList deletePrmSetList, ref ArrayList deleteGoodsMngList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        // --- UPD m.suzuki 2010/10/06 ----------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList goodsMngList = null;

            PrmSettingUWork _prmSettingUWork = deletePrmSetList[0] as PrmSettingUWork;
            GoodsMngWork goodsMngWork = new GoodsMngWork();

            goodsMngWork.EnterpriseCode = _prmSettingUWork.EnterpriseCode;

            SqlConnection sqlConnectionMng =  CreateSqlConnection();

            if (sqlConnection == null || sqlConnectionMng == null)
            {
                return status = (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            sqlConnectionMng.Open();
            // 商品管理情報検索(ｷｰ:企業)
            //status = _goodsMngDB.SearchGoodsMngProc(out goodsMngList, goodsMngWork, 0, 0, ref sqlConnectionMng);
            status = SearchGoodsMng(out goodsMngList, goodsMngWork, sqlConnectionMng);

            if (sqlConnectionMng != null)
            {
                sqlConnectionMng.Close();
                sqlConnectionMng.Dispose();
            }

            if (goodsMngList.Count != 0)
            {
                // --- UPD m.suzuki 2010/10/06 ---------->>>>>
                //// ﾕｰｻﾞｰ商品管理情報ﾘｽﾄで回す
                //foreach (GoodsMngWork usrMngWork in goodsMngList)
                //{
                //    foreach (PrmSettingUWork delSetUWork in deletePrmSetList)
                //    {
                //        // 一致しているｷｰがあれば(拠点､ﾒｰｶｰ､BL､中分類)
                //        if (usrMngWork.SectionCode == delSetUWork.SectionCode && usrMngWork.BLGoodsCode == delSetUWork.TbsPartsCode &&
                //            usrMngWork.GoodsMGroup == delSetUWork.GoodsMGroup && usrMngWork.GoodsMakerCd == delSetUWork.PartsMakerCd)
                //        {
                //            // 削除ﾘｽﾄに追加
                //            deleteGoodsMngList.Add(usrMngWork);
                //        }
                //    }
                //}

                //----------------------------------------
                // リストをディクショナリに退避する
                // 　※今回変更により処理がＮ×Ｎ×Ｎにならないよう、
                //  　 あらかじめディクショナリを生成する。(ほぼＮ＋Ｎ＋Ｎになる)
                //----------------------------------------
                // 削除リスト⇒削除ディクショナリ
                Dictionary<string, bool> deleteDic = new Dictionary<string, bool>();
                foreach ( PrmSettingUWork work in deletePrmSetList )
                {
                    string key = GetGoodsMngKey( work.SectionCode, work.TbsPartsCode, work.GoodsMGroup, work.PartsMakerCd );
                    if ( !deleteDic.ContainsKey( key ) )
                    {
                        deleteDic.Add( key, true );
                    }
                }
                // 追加リスト⇒追加ディクショナリ
                Dictionary<string, bool> writeDic = new Dictionary<string, bool>();
                foreach ( PrmSettingUWork work in writePrmSetList )
                {
                    string key = GetGoodsMngKey( work.SectionCode, work.TbsPartsCode, work.GoodsMGroup, work.PartsMakerCd );
                    if ( !writeDic.ContainsKey( key ) )
                    {
                        writeDic.Add( key, true );
                    }
                }

                //----------------------------------------
                // ﾕｰｻﾞｰ商品管理情報の削除判定
                //----------------------------------------
                foreach ( GoodsMngWork usrMngWork in goodsMngList )
                {
                    string key = GetGoodsMngKey( usrMngWork.SectionCode, usrMngWork.BLGoodsCode, usrMngWork.GoodsMGroup, usrMngWork.GoodsMakerCd );

                    // 削除ディクショナリに有って、追加ディクショナリに無い　⇒　削除
                    if ( deleteDic.ContainsKey( key ) && !writeDic.ContainsKey( key ) )
                    {
                        // 削除ﾘｽﾄに追加
                        deleteGoodsMngList.Add( usrMngWork );
                    }
                }
                // --- UPD m.suzuki 2010/10/06 ----------<<<<<
            }

            if (deleteGoodsMngList.Count != 0)
            {
                // 商品管理情報マスタ削除処理
                status = _goodsMngDB.DeleteGoodsMngProc(deleteGoodsMngList, ref sqlConnection, ref sqlTransaction);
            }
            return status;
        }
        // --- ADD m.suzuki 2010/10/06 ---------->>>>>
        /// <summary>
        /// 商品管理マスタレコードキー文字列生成処理
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="blGoodsCode"></param>
        /// <param name="goodsMGroup"></param>
        /// <param name="goodsMakerCd"></param>
        /// <returns></returns>
        private string GetGoodsMngKey( string sectionCode, int blGoodsCode, int goodsMGroup, int goodsMakerCd )
        {
            return string.Format( "{0},{1},{2},{3}", sectionCode.Trim(), blGoodsCode, goodsMGroup, goodsMakerCd );
        }
        // --- ADD m.suzuki 2010/10/06 ----------<<<<<

        // 商品管理情報検索
        private int SearchGoodsMng(out ArrayList goodsMngList, GoodsMngWork goodsMngWork, SqlConnection sqlConnectionMng)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = "";
                #region SELECT文
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "	 GDM.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "	,GDM.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "	,GDM.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "	,GDM.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "	,GDM.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSNORF" + Environment.NewLine;
                sqlTxt += "	,GDM.SUPPLIERCDRF" + Environment.NewLine;
                sqlTxt += "	,GDM.SUPPLIERLOTRF" + Environment.NewLine;
                sqlTxt += "	,GDM.GOODSMGROUPRF" + Environment.NewLine;
                sqlTxt += "FROM GOODSMNGRF AS GDM" + Environment.NewLine;

                #endregion
                sqlCommand = new SqlCommand(sqlTxt, sqlConnectionMng);

                sqlTxt = "";
                sqlTxt += "WHERE" + Environment.NewLine;

                //企業コード
                sqlTxt += " GDM.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsMngWork.EnterpriseCode);

                sqlCommand.CommandText += sqlTxt;

                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    GoodsMngWork wkGoodsMngWork = new GoodsMngWork();

                    #region クラスへ格納
                    wkGoodsMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkGoodsMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkGoodsMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkGoodsMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkGoodsMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkGoodsMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkGoodsMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkGoodsMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkGoodsMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkGoodsMngWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkGoodsMngWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkGoodsMngWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkGoodsMngWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkGoodsMngWork.SupplierLot = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERLOTRF"));
                    wkGoodsMngWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    #endregion
                    al.Add(wkGoodsMngWork);
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

            goodsMngList = al;

            return status;
        }

        // 詳細名称変更処理
        /// <summary>
        /// 詳細名称変更処理
        /// </summary>
        /// <param name="writePrmSettingUWork"></param>
        /// <param name="SetUsrWork"></param>
        /// <param name="SetChgWork"></param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// <br></br>
        /// <br>Update Note: 11070266-00　SCM高速化 Ｃ向け種別対応 </br>
        /// <br>Programmer : 30757 佐々木 貴英</br>
        /// <br>Date       : 2015/02/25</br>
        /// <br></br>
        /// </remarks>
        private void SetPrmSetDtlName(ref PrmSettingUWork writePrmSettingUWork, PrmSettingUWork SetUsrWork, PrmSettingWork SettOfrWork)
        {
            writePrmSettingUWork.CreateDateTime = SetUsrWork.CreateDateTime;
            writePrmSettingUWork.EnterpriseCode = SetUsrWork.EnterpriseCode;
            writePrmSettingUWork.FileHeaderGuid = SetUsrWork.FileHeaderGuid;
            writePrmSettingUWork.GoodsMGroup = SetUsrWork.GoodsMGroup;
            writePrmSettingUWork.LogicalDeleteCode = SetUsrWork.LogicalDeleteCode;
            writePrmSettingUWork.MakerDispOrder = SetUsrWork.MakerDispOrder;
            writePrmSettingUWork.PartsMakerCd = SetUsrWork.PartsMakerCd;
            writePrmSettingUWork.PrimeDispOrder = SetUsrWork.PrimeDispOrder;
            writePrmSettingUWork.PrmSetDtlName1 = SetUsrWork.PrmSetDtlName1;
            writePrmSettingUWork.PrmSetDtlName2 = SetUsrWork.PrmSetDtlName2;
            writePrmSettingUWork.SectionCode = SetUsrWork.SectionCode;
            writePrmSettingUWork.TbsPartsCdDerivedNo = SetUsrWork.TbsPartsCdDerivedNo;
            writePrmSettingUWork.TbsPartsCode = SetUsrWork.TbsPartsCode;
            writePrmSettingUWork.UpdAssemblyId1 = SetUsrWork.UpdAssemblyId1;
            writePrmSettingUWork.UpdAssemblyId2 = SetUsrWork.UpdAssemblyId2;
            writePrmSettingUWork.UpdateDateTime = SetUsrWork.UpdateDateTime;
            writePrmSettingUWork.UpdEmployeeCode = SetUsrWork.UpdEmployeeCode;
            writePrmSettingUWork.PrmSetDtlNo1 = SetUsrWork.PrmSetDtlNo1;
            writePrmSettingUWork.PrmSetDtlNo2 = SetUsrWork.PrmSetDtlNo2;
            writePrmSettingUWork.PrimeDisplayCode = SetUsrWork.PrimeDisplayCode;
            
            // 提供優良設定ﾏｽﾀの名称で更新
            writePrmSettingUWork.PrmSetDtlName1 = SettOfrWork.PrmSetDtlName1;
            writePrmSettingUWork.PrmSetDtlName2 = SettOfrWork.PrmSetDtlName2;
            //---ADD　30757 佐々木　貴英　2015/02/25 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
            writePrmSettingUWork.PrmSetDtlName2ForFac = SettOfrWork.PrmSetDtlName2ForFac;
            writePrmSettingUWork.PrmSetDtlName2ForCOw = SettOfrWork.PrmSetDtlName2ForCOw;
            //---ADD　30757 佐々木　貴英　2015/02/25 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<

            // 提供日付更新
            writePrmSettingUWork.OfferDate = SettOfrWork.OfferDate;
        }

        // 書込ﾃﾞｰﾀｸﾗｽｸﾘｱ処理
        /// <summary>
        /// 書込ﾃﾞｰﾀｸﾗｽｸﾘｱ処理
        /// </summary>
        /// <param name="writePrmSettingUWork"></param>
        /// <param name="SetUsrWork"></param>
        /// <param name="SetChgWork"></param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// <br></br>
        /// <br>Update Note: 11070266-00　SCM高速化 Ｃ向け種別対応 </br>
        /// <br>Programmer : 30757 佐々木 貴英</br>
        /// <br>Date       : 2015/02/25</br>
        /// <br></br>
        /// </remarks>
        private void ClearPrmSetUWork(ref PrmSettingUWork writePrmSettingUWork)
        {
            writePrmSettingUWork.CreateDateTime = DateTime.MinValue;
            writePrmSettingUWork.EnterpriseCode = string.Empty;
            writePrmSettingUWork.FileHeaderGuid = Guid.Empty;
            writePrmSettingUWork.GoodsMGroup = 0;
            writePrmSettingUWork.LogicalDeleteCode = 0;
            writePrmSettingUWork.MakerDispOrder = 0;
            writePrmSettingUWork.OfferDate = 0;
            writePrmSettingUWork.PartsMakerCd = 0;
            writePrmSettingUWork.PrimeDisplayCode =0;
            writePrmSettingUWork.PrimeDispOrder =0;
            writePrmSettingUWork.PrmSetDtlName1 = string.Empty;
            writePrmSettingUWork.PrmSetDtlName2 = string.Empty;
            writePrmSettingUWork.PrmSetDtlNo1 = 0;
            writePrmSettingUWork.PrmSetDtlNo2 = 0;
            writePrmSettingUWork.SectionCode = string.Empty;
            writePrmSettingUWork.TbsPartsCdDerivedNo = 0;
            writePrmSettingUWork.TbsPartsCode = 0;
            writePrmSettingUWork.UpdAssemblyId1 = string.Empty;
            writePrmSettingUWork.UpdAssemblyId2 = string.Empty;
            writePrmSettingUWork.UpdateDateTime = DateTime.MinValue;
            writePrmSettingUWork.UpdEmployeeCode = string.Empty;
            //---ADD　30757 佐々木　貴英　2015/02/25 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
            writePrmSettingUWork.PrmSetDtlName2ForFac = string.Empty;
            writePrmSettingUWork.PrmSetDtlName2ForCOw = string.Empty;
            //---ADD　30757 佐々木　貴英　2015/02/25 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<
        }

        // 詳細ｺｰﾄﾞ変更処理
        /// <summary>
        /// 詳細ｺｰﾄﾞ変更処理
        /// </summary>
        /// <param name="writePrmSettingUWork"></param>
        /// <param name="SetUsrWork"></param>
        /// <param name="SetChgWork"></param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// <br></br>
        /// <br>Update Note: 11070266-00　SCM高速化 Ｃ向け種別対応 </br>
        /// <br>Programmer : 30757 佐々木 貴英</br>
        /// <br>Date       : 2015/02/25</br>
        /// <br></br>
        /// </remarks>
        private void SetPrmSetDtlNo(ref PrmSettingUWork writePrmSettingUWork, PrmSettingUWork SetUsrWork, PrmSettingChgWork SetChgWork)
        {
            writePrmSettingUWork.CreateDateTime = SetUsrWork.CreateDateTime;
            writePrmSettingUWork.EnterpriseCode = SetUsrWork.EnterpriseCode;
            writePrmSettingUWork.FileHeaderGuid = SetUsrWork.FileHeaderGuid;
            writePrmSettingUWork.GoodsMGroup = SetUsrWork.GoodsMGroup;
            writePrmSettingUWork.LogicalDeleteCode = SetUsrWork.LogicalDeleteCode;
            writePrmSettingUWork.MakerDispOrder = SetUsrWork.MakerDispOrder;
            writePrmSettingUWork.PartsMakerCd = SetUsrWork.PartsMakerCd;
            writePrmSettingUWork.PrimeDispOrder = SetUsrWork.PrimeDispOrder;
            writePrmSettingUWork.PrmSetDtlName1 = SetUsrWork.PrmSetDtlName1;
            writePrmSettingUWork.PrmSetDtlName2 = SetUsrWork.PrmSetDtlName2;
            writePrmSettingUWork.SectionCode = SetUsrWork.SectionCode;
            writePrmSettingUWork.TbsPartsCdDerivedNo = SetUsrWork.TbsPartsCdDerivedNo;
            writePrmSettingUWork.TbsPartsCode = SetUsrWork.TbsPartsCode;
            writePrmSettingUWork.UpdAssemblyId1 = SetUsrWork.UpdAssemblyId1;
            writePrmSettingUWork.UpdAssemblyId2 = SetUsrWork.UpdAssemblyId2;
            writePrmSettingUWork.UpdateDateTime = SetUsrWork.UpdateDateTime;
            writePrmSettingUWork.UpdEmployeeCode = SetUsrWork.UpdEmployeeCode;
            //---ADD　30757 佐々木　貴英　2015/02/25 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
            writePrmSettingUWork.PrmSetDtlName2ForFac = SetUsrWork.PrmSetDtlName2ForFac;
            writePrmSettingUWork.PrmSetDtlName2ForCOw = SetUsrWork.PrmSetDtlName2ForCOw;
            //---ADD　30757 佐々木　貴英　2015/02/25 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<

            // 変更ﾏｽﾀの変更後詳細ｺｰﾄﾄﾞ1が"-1"じゃなかったら書き換え
            // 2010/09/07 >>>
            //if (SetChgWork.AfPrmSetDtlNo1 > 0)
            if (SetChgWork.AfPrmSetDtlNo1 >= 0)
            // 2010/09/07 <<<
            {
                writePrmSettingUWork.PrmSetDtlNo1 = SetChgWork.AfPrmSetDtlNo1;
            }
            else
            {
                writePrmSettingUWork.PrmSetDtlNo1 = SetUsrWork.PrmSetDtlNo1;
            }

            // 変更ﾏｽﾀの変更後詳細ｺｰﾄﾄﾞ2が"-1"じゃなかったら書き換え
            // 2010/09/07 >>>
            //if (SetChgWork.AfPrmSetDtlNo2 > 0)
            if (SetChgWork.AfPrmSetDtlNo2 >= 0)
            // 2010/09/07 <<<
            {
                writePrmSettingUWork.PrmSetDtlNo2 = SetChgWork.AfPrmSetDtlNo2;
            }
            else
            {
                writePrmSettingUWork.PrmSetDtlNo2 = SetUsrWork.PrmSetDtlNo2;
            }

            // 変更後優良表示区分が1,2の場合は更新
            if (SetChgWork.AfPrimeDisplayCode == 1 || SetChgWork.AfPrimeDisplayCode == 2)
            {
                writePrmSettingUWork.PrimeDisplayCode = SetChgWork.AfPrimeDisplayCode;
            }
            else
            {
                writePrmSettingUWork.PrimeDisplayCode = SetUsrWork.PrimeDisplayCode;
            }

            // 提供日付更新
            writePrmSettingUWork.OfferDate = SetChgWork.OfferDate;
            //writePrmSettingUWork.OfferDate = SetUsrWork.OfferDate;
        }

        // ログ書き込み処理
        private void WriteLog(string enterpriseCode, string LogDataObjProcNm, string LogDataMassage, int status, int count)
        {
            OprtnHisLogWork oprtnHisLogWork = new OprtnHisLogWork();
            object obj;

            oprtnHisLogWork.EnterpriseCode = enterpriseCode;
            oprtnHisLogWork.LogDataObjClassID = "OfferMergeDB";
            oprtnHisLogWork.LogDataCreateDateTime = DateTime.Now;
            oprtnHisLogWork.LogDataKindCd = 9;
            oprtnHisLogWork.LogDataObjAssemblyID = "PMKHN09212R";
            oprtnHisLogWork.LogDataObjAssemblyNm = "提供データ更新処理";
            oprtnHisLogWork.LogDataObjProcNm = LogDataObjProcNm;
            oprtnHisLogWork.LogOperationStatus = 0;
            oprtnHisLogWork.LogDataMassage = LogDataMassage;
            if (status == 0) oprtnHisLogWork.LogOperationData = "正常終了 (" + count + "件)";
            else oprtnHisLogWork.LogOperationData = "SQL,リモートのエラーコード等";

            obj = oprtnHisLogWork;
            status = _oprtnHisLogDB.Write(ref obj);
        }


        /// <summary>
        /// 価格改正履歴の最新提供日付取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="LatestList">結果</param>
        /// <returns></returns>
        public int GetLatestHistory(string enterpriseCode, out object LatestList)
        {
            return GetLatestHistoryProc(enterpriseCode, out LatestList);
        }
        private int GetLatestHistoryProc(string enterpriseCode, out object LatestList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList DateList = new ArrayList();
            PriUpdTblUpdHisWork priWork = new PriUpdTblUpdHisWork();

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;

            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null)
            {
                LatestList = DateList;
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            sqlConnection.Open();

            try
            {
                // BLグループマスタ
                sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                sqlText += "	,ADDUPDATEROWSNORF " + Environment.NewLine;
                sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                sqlText += " WHERE SYNCTABLEIDRF = 'BLGROUPURF' " + Environment.NewLine;
                sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                //sqlText += " GROUP BY ADDUPDATEROWSNORF " + Environment.NewLine;
                //sqlText += " ORDER BY OFFERDATERF DESC " + Environment.NewLine;
                sqlText += " GROUP BY ADDUPDATEROWSNORF , DATAUPDATEDATETIMERF " + Environment.NewLine;
                sqlText += " ORDER BY DATAUPDATEDATETIMERF DESC " + Environment.NewLine;

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                sqlCommand.CommandText = sqlText;
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    priWork = new PriUpdTblUpdHisWork();
                    priWork.SyncTableName = "BLGROUPURF";
                    priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                    DateList.Add(priWork);
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();

                // 中分類マスタ
                sqlText = string.Empty;
                sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                sqlText += "	,ADDUPDATEROWSNORF " + Environment.NewLine;
                sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                sqlText += " WHERE SYNCTABLEIDRF = 'GOODSGROUPURF' " + Environment.NewLine;
                sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                //sqlText += " GROUP BY ADDUPDATEROWSNORF " + Environment.NewLine;
                //sqlText += " ORDER BY OFFERDATERF DESC " + Environment.NewLine;
                sqlText += " GROUP BY ADDUPDATEROWSNORF  , DATAUPDATEDATETIMERF " + Environment.NewLine;
                sqlText += " ORDER BY DATAUPDATEDATETIMERF DESC " + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    priWork = new PriUpdTblUpdHisWork();
                    priWork.SyncTableName = "GOODSGROUPURF";
                    priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                    DateList.Add(priWork);
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();

                // 車種マスタ
                sqlText = string.Empty;
                sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                sqlText += "	,ADDUPDATEROWSNORF " + Environment.NewLine;
                sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                sqlText += " WHERE SYNCTABLEIDRF = 'MODELNAMEURF' " + Environment.NewLine;
                sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                //sqlText += " GROUP BY ADDUPDATEROWSNORF " + Environment.NewLine;
                //sqlText += " ORDER BY OFFERDATERF DESC " + Environment.NewLine;
                sqlText += " GROUP BY ADDUPDATEROWSNORF  , DATAUPDATEDATETIMERF " + Environment.NewLine;
                sqlText += " ORDER BY DATAUPDATEDATETIMERF DESC " + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    priWork = new PriUpdTblUpdHisWork();
                    priWork.SyncTableName = "MODELNAMEURF";
                    priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                    DateList.Add(priWork);
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();

                // 部位マスタ
                sqlText = string.Empty;
                sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                sqlText += "	,ADDUPDATEROWSNORF " + Environment.NewLine;
                sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                sqlText += " WHERE SYNCTABLEIDRF = 'PARTSPOSCODEURF' " + Environment.NewLine;
                sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                //sqlText += " GROUP BY ADDUPDATEROWSNORF " + Environment.NewLine;
                //sqlText += " ORDER BY OFFERDATERF DESC " + Environment.NewLine;
                sqlText += " GROUP BY ADDUPDATEROWSNORF  , DATAUPDATEDATETIMERF " + Environment.NewLine;
                sqlText += " ORDER BY DATAUPDATEDATETIMERF DESC " + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    priWork = new PriUpdTblUpdHisWork();
                    priWork.SyncTableName = "PARTSPOSCODEURF";
                    priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                    DateList.Add(priWork);
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();

                // BLコードマスタ
                sqlText = string.Empty;
                sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                sqlText += "	,ADDUPDATEROWSNORF " + Environment.NewLine;
                sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                sqlText += " WHERE SYNCTABLEIDRF = 'BLGOODSCDURF' " + Environment.NewLine;
                sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                //sqlText += " GROUP BY ADDUPDATEROWSNORF " + Environment.NewLine;
                //sqlText += " ORDER BY OFFERDATERF DESC " + Environment.NewLine;
                sqlText += " GROUP BY ADDUPDATEROWSNORF , DATAUPDATEDATETIMERF  " + Environment.NewLine;
                sqlText += " ORDER BY DATAUPDATEDATETIMERF DESC " + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    priWork = new PriUpdTblUpdHisWork();
                    priWork.SyncTableName = "BLGOODSCDURF";
                    priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                    DateList.Add(priWork);
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();

                // 優良設定マスタ
                sqlText = string.Empty;
                sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                sqlText += "	,ADDUPDATEROWSNORF " + Environment.NewLine;
                sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                sqlText += " WHERE SYNCTABLEIDRF = 'PRMSETTINGURF' " + Environment.NewLine;
                sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                //sqlText += " GROUP BY ADDUPDATEROWSNORF " + Environment.NewLine;
                //sqlText += " ORDER BY OFFERDATERF DESC " + Environment.NewLine;
                sqlText += " GROUP BY ADDUPDATEROWSNORF  , DATAUPDATEDATETIMERF " + Environment.NewLine;
                sqlText += " ORDER BY DATAUPDATEDATETIMERF DESC " + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    priWork = new PriUpdTblUpdHisWork();
                    priWork.SyncTableName = "PRMSETTINGURF";
                    priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                    DateList.Add(priWork);
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();

                // 商品管理情報マスタ
                //sqlText = string.Empty;
                //sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                //sqlText += "	,ADDUPDATEROWSNORF " + Environment.NewLine;
                //sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                //sqlText += " WHERE SYNCTABLEIDRF = 'GOODSMNGURF' " + Environment.NewLine;
                //sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                //sqlText += " GROUP BY ADDUPDATEROWSNORF " + Environment.NewLine;
                //sqlText += " ORDER BY OFFERDATERF DESC " + Environment.NewLine;
                //sqlText += " GROUP BY ADDUPDATEROWSNORF , SYNCEXECUTEDATERF  " + Environment.NewLine;
                //sqlText += " ORDER BY SYNCEXECUTEDATERF DESC " + Environment.NewLine;
                //sqlCommand.CommandText = sqlText;
                //myReader = sqlCommand.ExecuteReader();
                //while (myReader.Read())
                //{
                //    priWork = new PriUpdTblUpdHisWork();
                //    priWork.SyncTableName = "GOODSMNGURF";
                //    priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                //    priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                //    DateList.Add(priWork);
                //}
                //if (!myReader.IsClosed) myReader.Close();
                //if (sqlCommand != null) sqlCommand.Dispose();

                // 価格改正
                sqlText = string.Empty;
                sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                sqlText += "	,ADDUPDATEROWSNORF " + Environment.NewLine;
                sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                sqlText += " WHERE SYNCTABLEIDRF = 'GOODSURF' OR SYNCTABLEIDRF = 'GOODSPRICEURF' " + Environment.NewLine;
                sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                //sqlText += " GROUP BY ADDUPDATEROWSNORF " + Environment.NewLine;
                //sqlText += " ORDER BY OFFERDATERF DESC " + Environment.NewLine;
                sqlText += " GROUP BY ADDUPDATEROWSNORF , DATAUPDATEDATETIMERF  " + Environment.NewLine;
                sqlText += " ORDER BY DATAUPDATEDATETIMERF DESC " + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                 
                    priWork = new PriUpdTblUpdHisWork();
                    //priWork.SyncTableName = "PRICEURF";
                    priWork.SyncTableName = "GOODSURF";
                    priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                    DateList.Add(priWork);
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();

                // メーカーマスタ
                sqlText = string.Empty;
                sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                sqlText += "	,ADDUPDATEROWSNORF " + Environment.NewLine;
                sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                sqlText += " WHERE SYNCTABLEIDRF = 'MAKERURF' " + Environment.NewLine;
                sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                //sqlText += " GROUP BY ADDUPDATEROWSNORF " + Environment.NewLine;
                //sqlText += " ORDER BY OFFERDATERF DESC " + Environment.NewLine;
                sqlText += " GROUP BY ADDUPDATEROWSNORF  , DATAUPDATEDATETIMERF " + Environment.NewLine;
                sqlText += " ORDER BY DATAUPDATEDATETIMERF DESC " + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    priWork = new PriUpdTblUpdHisWork();
                    priWork.SyncTableName = "MAKERURF";
                    priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                    DateList.Add(priWork);
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "OfferMergeDB.GetUpdateHistoryProc", ex.Number);
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (!myReader.IsClosed)
                    myReader.Close();

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            LatestList = DateList;
            return status;
        }


        // ADD 2025/08/11 田村顕成 ----->>>>> 
        /// <summary>
        /// 価格改正履歴の提供日付を指定した日付の一つ前のデータを取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="currentDate">検索用提供データ日付</param>
        /// <param name="AllList">結果</param>
        /// <returns></returns>
        public int GetOtherHistories(string enterpriseCode, string currentDate, string tableID, out object AllList)
        {
            return GetOtherHistoriesProc(enterpriseCode, currentDate, tableID, out AllList);
        }
        private int GetOtherHistoriesProc(string enterpriseCode, string currentDate, string tableID, out object AllList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList DateList = new ArrayList();
            PriUpdTblUpdHisWork priWork = new PriUpdTblUpdHisWork();

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;

            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null)
            {
                AllList = DateList;
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            sqlConnection.Open();

            try
            {
                if (tableID.Equals("BLGROUPURF"))
                {
                    // BLグループマスタ
                    sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);

                    sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                    sqlText += " ,ADDUPDATEROWSNORF " + Environment.NewLine;
                    sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                    sqlText += " WHERE SYNCTABLEIDRF = 'BLGROUPURF' " + Environment.NewLine;
                    sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND OFFERDATERF<@OFFERDATERF" + Environment.NewLine;
                    sqlText += " GROUP BY ADDUPDATEROWSNORF , DATAUPDATEDATETIMERF " + Environment.NewLine;
                    sqlText += " ORDER BY DATAUPDATEDATETIMERF DESC " + Environment.NewLine;

                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATERF", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    paraOfferDate.Value = SqlDataMediator.SqlSetString(currentDate);

                    sqlCommand.CommandText = sqlText;
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        priWork = new PriUpdTblUpdHisWork();
                        priWork.SyncTableName = "BLGROUPURF";
                        priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                        DateList.Add(priWork);
                    }
                    if (!myReader.IsClosed) myReader.Close();
                    if (sqlCommand != null) sqlCommand.Dispose();
                }

                if (tableID.Equals("GOODSGROUPURF"))
                {
                    // 中分類マスタ
                    sqlText = string.Empty;
                    sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                    sqlText += " ,ADDUPDATEROWSNORF " + Environment.NewLine;
                    sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                    sqlText += " WHERE SYNCTABLEIDRF = 'GOODSGROUPURF' " + Environment.NewLine;
                    sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND OFFERDATERF<@OFFERDATERF" + Environment.NewLine;
                    sqlText += " GROUP BY ADDUPDATEROWSNORF  , DATAUPDATEDATETIMERF " + Environment.NewLine;
                    sqlText += " ORDER BY DATAUPDATEDATETIMERF DESC " + Environment.NewLine;
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATERF", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    paraOfferDate.Value = SqlDataMediator.SqlSetString(currentDate);
                    sqlCommand.CommandText = sqlText;
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        priWork = new PriUpdTblUpdHisWork();
                        priWork.SyncTableName = "GOODSGROUPURF";
                        priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                        DateList.Add(priWork);
                    }
                    if (!myReader.IsClosed) myReader.Close();
                    if (sqlCommand != null) sqlCommand.Dispose();
                }

                if (tableID.Equals("MODELNAMEURF"))
                {
                    // 車種マスタ
                    sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                    sqlText += " ,ADDUPDATEROWSNORF " + Environment.NewLine;
                    sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                    sqlText += " WHERE SYNCTABLEIDRF = 'MODELNAMEURF' " + Environment.NewLine;
                    sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND OFFERDATERF<@OFFERDATERF" + Environment.NewLine;
                    sqlText += " GROUP BY ADDUPDATEROWSNORF  , DATAUPDATEDATETIMERF " + Environment.NewLine;
                    sqlText += " ORDER BY DATAUPDATEDATETIMERF DESC " + Environment.NewLine;
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATERF", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    paraOfferDate.Value = SqlDataMediator.SqlSetString(currentDate);
                    sqlCommand.CommandText = sqlText;
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        priWork = new PriUpdTblUpdHisWork();
                        priWork.SyncTableName = "MODELNAMEURF";
                        priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                        DateList.Add(priWork);
                    }
                    if (!myReader.IsClosed) myReader.Close();
                    if (sqlCommand != null) sqlCommand.Dispose();
                }

                if (tableID.Equals("PARTSPOSCODEURF"))
                {
                    // 部位マスタ
                    sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                    sqlText += " ,ADDUPDATEROWSNORF " + Environment.NewLine;
                    sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                    sqlText += " WHERE SYNCTABLEIDRF = 'PARTSPOSCODEURF' " + Environment.NewLine;
                    sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND OFFERDATERF<@OFFERDATERF" + Environment.NewLine;
                    sqlText += " GROUP BY ADDUPDATEROWSNORF  , DATAUPDATEDATETIMERF " + Environment.NewLine;
                    sqlText += " ORDER BY DATAUPDATEDATETIMERF DESC " + Environment.NewLine;
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATERF", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    paraOfferDate.Value = SqlDataMediator.SqlSetString(currentDate);
                    sqlCommand.CommandText = sqlText;
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        priWork = new PriUpdTblUpdHisWork();
                        priWork.SyncTableName = "PARTSPOSCODEURF";
                        priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                        DateList.Add(priWork);
                    }
                    if (!myReader.IsClosed) myReader.Close();
                    if (sqlCommand != null) sqlCommand.Dispose();
                }

                if (tableID.Equals("BLGOODSCDURF"))
                {
                    // BLコードマスタ
                    sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                    sqlText += " ,ADDUPDATEROWSNORF " + Environment.NewLine;
                    sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                    sqlText += " WHERE SYNCTABLEIDRF = 'BLGOODSCDURF' " + Environment.NewLine;
                    sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND OFFERDATERF<@OFFERDATERF" + Environment.NewLine;
                    sqlText += " GROUP BY ADDUPDATEROWSNORF , DATAUPDATEDATETIMERF  " + Environment.NewLine;
                    sqlText += " ORDER BY DATAUPDATEDATETIMERF DESC " + Environment.NewLine;
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATERF", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    paraOfferDate.Value = SqlDataMediator.SqlSetString(currentDate);
                    sqlCommand.CommandText = sqlText;
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        priWork = new PriUpdTblUpdHisWork();
                        priWork.SyncTableName = "BLGOODSCDURF";
                        priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                        DateList.Add(priWork);
                    }
                    if (!myReader.IsClosed) myReader.Close();
                    if (sqlCommand != null) sqlCommand.Dispose();
                }

                if (tableID.Equals("PRMSETTINGURF"))
                {
                    // 優良設定マスタ
                    sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                    sqlText += " ,ADDUPDATEROWSNORF " + Environment.NewLine;
                    sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                    sqlText += " WHERE SYNCTABLEIDRF = 'PRMSETTINGURF' " + Environment.NewLine;
                    sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND OFFERDATERF<@OFFERDATERF" + Environment.NewLine;
                    sqlText += " GROUP BY ADDUPDATEROWSNORF  , DATAUPDATEDATETIMERF " + Environment.NewLine;
                    sqlText += " ORDER BY DATAUPDATEDATETIMERF DESC " + Environment.NewLine;
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATERF", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    paraOfferDate.Value = SqlDataMediator.SqlSetString(currentDate);
                    sqlCommand.CommandText = sqlText;
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        priWork = new PriUpdTblUpdHisWork();
                        priWork.SyncTableName = "PRMSETTINGURF";
                        priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                        DateList.Add(priWork);
                    }
                    if (!myReader.IsClosed) myReader.Close();
                    if (sqlCommand != null) sqlCommand.Dispose();
                }

                if (tableID.Equals("GOODSURF"))
                {
                    // 価格改正
                    sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                    sqlText += " ,ADDUPDATEROWSNORF " + Environment.NewLine;
                    sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                    sqlText += " WHERE (SYNCTABLEIDRF = 'GOODSURF' OR SYNCTABLEIDRF = 'GOODSPRICEURF') " + Environment.NewLine;
                    sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND OFFERDATERF<@OFFERDATERF" + Environment.NewLine;
                    sqlText += " GROUP BY ADDUPDATEROWSNORF , DATAUPDATEDATETIMERF  " + Environment.NewLine;
                    sqlText += " ORDER BY DATAUPDATEDATETIMERF DESC " + Environment.NewLine;
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATERF", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    paraOfferDate.Value = SqlDataMediator.SqlSetString(currentDate);
                    sqlCommand.CommandText = sqlText;
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {

                        priWork = new PriUpdTblUpdHisWork();
                        //priWork.SyncTableName = "PRICEURF";
                        priWork.SyncTableName = "GOODSURF";
                        priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                        DateList.Add(priWork);
                    }
                    if (!myReader.IsClosed) myReader.Close();
                    if (sqlCommand != null) sqlCommand.Dispose();
                }

                if (tableID.Equals("MAKERURF"))
                {
                    // メーカーマスタ
                    sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);
                    sqlText += " SELECT TOP 1 MAX(OFFERDATERF) AS OFFERDATERF " + Environment.NewLine;
                    sqlText += " ,ADDUPDATEROWSNORF " + Environment.NewLine;
                    sqlText += " FROM PRIUPDHISRF " + Environment.NewLine;
                    sqlText += " WHERE SYNCTABLEIDRF = 'MAKERURF' " + Environment.NewLine;
                    sqlText += " AND ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND OFFERDATERF<@OFFERDATERF" + Environment.NewLine;
                    sqlText += " GROUP BY ADDUPDATEROWSNORF  , DATAUPDATEDATETIMERF " + Environment.NewLine;
                    sqlText += " ORDER BY DATAUPDATEDATETIMERF DESC " + Environment.NewLine;
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATERF", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    paraOfferDate.Value = SqlDataMediator.SqlSetString(currentDate);
                    sqlCommand.CommandText = sqlText;
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        priWork = new PriUpdTblUpdHisWork();
                        priWork.SyncTableName = "MAKERURF";
                        priWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        priWork.AddUpdateRowsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATEROWSNORF"));
                        DateList.Add(priWork);
                    }
                    if (!myReader.IsClosed) myReader.Close();
                    if (sqlCommand != null) sqlCommand.Dispose();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "OfferMergeDB.GetOtherHistoriesProc", ex.Number);
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (!myReader.IsClosed)
                    myReader.Close();

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            AllList = DateList;
            return status;
        }
        // ADD 2025/08/11 田村顕成 -----<<<<< 

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.04</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            //#if DEBUG
            //connectionText = @"workstation id=AN;packet size=4096; User id=pmuser; Pwd=pmuser001; data source=10.30.20.228; persist security info=False; initial catalog=PM_USER_DB_PM";
            //#else
            if (string.IsNullOrEmpty(connectionText))
                return null;

            //#endif
            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

    }
}
