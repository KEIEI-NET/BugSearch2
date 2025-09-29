//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 提供マスタ削除処理
// プログラム概要   : 提供データ重複するユーザー結合、セットマスタのレコードを削除する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/06/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/07/08  修正内容 : 削除メソッド呼び出し処理に関して 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/07/10  修正内容 : 削除件数の不正 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 修 正 日  2010/01/28  修正内容 : Mantis:14923　結合マスタ処理時にエラー発生する件の修正
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net.NetworkInformation;
using Microsoft.Win32;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    ///提供マスタ削除処理スクラス
    /// </summary>
    /// <remarks>
    /// Note       : 提供マスタ削除処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009.06.18<br />
    /// UpdateNote : Mantis:14923　結合マスタ処理時にエラー発生する件の修正<br />
    /// Programmer : 30517 夏野 駿希<br />
    /// Date       : 2010/01/28<br />
    /// </remarks>
    public class OfferMstDelInputAcs
    {
        #region ■ Const Memebers ■
        private const string PROGRAM_ID = "PMKHN01200U";
        private const string PROGRAM_NAME = "提供マスタ削除処理";
        private const string MARK_1 = "<-->";
        #endregion

        # region ■ Private Members ■
        private static OfferMstDelInputAcs _offerMstDelInputAcs;
        private IJoinPartsUDB _iJoinPartsUDB;
        private IGoodsSetDB _iGoodsSetDB;

        #endregion

        # region ■ Constructor ■
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        /// <remarks>
        /// Note       : なし。<br />
        /// Programmer : 譚洪<br />
        /// Date       : 2009.06.18<br />
        /// </remarks>
        private OfferMstDelInputAcs()
        {
            // 変数初期化

        }
        # endregion ■ Constructor ■

        # region ■ 提供マスタ削除処理アクセスクラス インスタンス取得処理 ■
        /// <summary>
        /// 提供マスタ削除処理アクセスクラス インスタンス取得処理
        /// </summary>
        /// <remarks>
        /// Note       : なし。<br />
        /// Programmer : 譚洪<br />
        /// Date       : 2009.06.18<br />
        /// </remarks>
        /// <returns>提供マスタ削除処理アクセスクラス インスタンス</returns>
        public static OfferMstDelInputAcs GetInstance()
        {
            if (_offerMstDelInputAcs == null)
            {
                _offerMstDelInputAcs = new OfferMstDelInputAcs();
            }

            return _offerMstDelInputAcs;
        }
        #endregion

        #region ■ 結合マスタ（ユーザー）削除処理 ■
        /// <summary>
        /// 結合マスタ（ユーザー）削除処理
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="joinCount">削除件数</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 結合マスタ（ユーザー）削除処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.06.18</br> 
        /// </remarks>
        /// <returns>削除結果ステータス</returns>
        public int DeleteJoinProc(string enterpriseCode, out int joinCount)
        {
            string joinLogStr = string.Empty;
            // 更新日時用HASHTABLE
            Hashtable updateTimeTable = new Hashtable();
            joinCount = 0;
            // ユーザーDBの検索結果リスト
            ArrayList joinPartsUserList = new ArrayList();
            object joinPartsUserObj = (object)joinPartsUserList;
            // ユーザーDBの検索条件ワーク
            JoinPartsUWork paraJoinPartsUserWork = new JoinPartsUWork();
            paraJoinPartsUserWork.EnterpriseCode = enterpriseCode;
            object paraJoinPartsUserObj = (object)paraJoinPartsUserWork;
            // OFFER_DBの検索結果リスト
            ArrayList joinPartsOfferList = new ArrayList();
            object joinPartsOfferObj = (object)joinPartsOfferList;
            // 2010/01/28 Add >>>
            JoinPartsUWork oldParaJoinPartsUserWork = new JoinPartsUWork();
            ArrayList loopAllList = new ArrayList();
            int joinInt = 100000;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            IJoinPartsDB _iJoinPartsDB = MediationJoinPartsDB.GetJoinPartsDB();
            // 2010/01/28 Add <<<

            // ログ用アクセス
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            // ユーザーDBを検索する。
            // 2010/01/28 Add >>>
            while (joinInt == 100000)
            {
                joinPartsUserList = new ArrayList();
                joinPartsUserObj = (object)joinPartsUserList;
                if (oldParaJoinPartsUserWork != null)
                {
                    paraJoinPartsUserWork.JoinSourceMakerCode = oldParaJoinPartsUserWork.JoinSourceMakerCode;
                    paraJoinPartsUserWork.JoinSourPartsNoWithH = oldParaJoinPartsUserWork.JoinSourPartsNoWithH;
                    paraJoinPartsUserWork.JoinDestMakerCd = oldParaJoinPartsUserWork.JoinDestMakerCd;
                    paraJoinPartsUserWork.JoinDestPartsNo = oldParaJoinPartsUserWork.JoinDestPartsNo;
                }
                // 2010/01/28 Add <<<
                this._iJoinPartsUDB = MediationJoinPartsUDB.GetJoinPartsUDB();
                // 2010/01/28 >>>
                //int status = _iJoinPartsUDB.Search(ref joinPartsUserObj, paraJoinPartsUserObj, 0, ConstantManagement.LogicalMode.GetDataAll);
                status = _iJoinPartsUDB.SearchMstDel(ref joinPartsUserObj, paraJoinPartsUserObj, 0, ConstantManagement.LogicalMode.GetDataAll, 100000);
                // 2010/01/28 <<<
                // 結合マスタ(提供)の抽出
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList joinPartsUserTempList = joinPartsUserObj as ArrayList;
                    //IJoinPartsDB _iJoinPartsDB = MediationJoinPartsDB.GetJoinPartsDB(); // 2010/01/28 Del
                    ArrayList loopList = new ArrayList();
                    //ArrayList loopAllList = new ArrayList();    // 2010/01/28 Del
                    JoinPartsUWork loopWork = null;
                    // 2010/01/28 >>>
                    //int joinInt = joinPartsUserTempList.Count;
                    joinInt = joinPartsUserTempList.Count;
                    // 2010/01/28 <<<

                    for (int i = 1; i <= joinInt; i++)
                    {
                        loopWork = (JoinPartsUWork)joinPartsUserTempList[i - 1];
                        loopList.Add(loopWork);
                        // MOD 譚洪 2009/07/08 --->>>
                        if (i != 1 && i % 100000 == 0)
                        // MOD 譚洪 2009/07/08 ---<<<
                        {

                            loopAllList.Add(loopList);
                            loopList = new ArrayList();
                        }
                    }

                    if (loopList.Count != 0)
                    {
                        loopAllList.Add(loopList);
                    }

                    // 2010/01/28 Add >>>
                    oldParaJoinPartsUserWork.JoinSourceMakerCode = loopWork.JoinSourceMakerCode;
                    oldParaJoinPartsUserWork.JoinSourPartsNoWithH = loopWork.JoinSourPartsNoWithH;
                    oldParaJoinPartsUserWork.JoinDestMakerCd = loopWork.JoinDestMakerCd;
                    oldParaJoinPartsUserWork.JoinDestPartsNo = loopWork.JoinDestPartsNo;
                }
                else
                    joinInt = 0;
            }
            if (loopAllList.Count != 0)
            {
                // 2010/01/28 Add <<<

                ArrayList loopTempList = new ArrayList();
                // OFFER_DB検索用リスト
                ArrayList joinPartsOfferTempList;
                JoinPartsWork JoinPartsTempWork = null;
                int joinTempCount = 0;

                for (int m = 0; m < loopAllList.Count; m++)
                {
                    joinPartsOfferTempList = new ArrayList();
                    loopTempList = (ArrayList)loopAllList[m];
                    for (int n = 0; n < loopTempList.Count; n++)
                    {
                        JoinPartsUWork tempWork = (JoinPartsUWork)loopTempList[n];
                        JoinPartsTempWork = new JoinPartsWork();
                        JoinPartsTempWork.JoinSourceMakerCode = tempWork.JoinSourceMakerCode;
                        JoinPartsTempWork.JoinSourPartsNoWithH = tempWork.JoinSourPartsNoWithH;
                        JoinPartsTempWork.JoinDestMakerCd = tempWork.JoinDestMakerCd;
                        JoinPartsTempWork.JoinDestPartsNo = tempWork.JoinDestPartsNo;
                        // MOD 譚洪 2009/07/08 --->>>
                        // 更新日時用HASHTABLE
                        updateTimeTable.Add(Convert.ToString(tempWork.JoinSourceMakerCode) + MARK_1 + tempWork.JoinSourPartsNoWithH
                            + MARK_1 + Convert.ToString(tempWork.JoinDestMakerCd) + MARK_1 + tempWork.JoinDestPartsNo, tempWork.UpdateDateTime);
                        // MOD 譚洪 2009/07/08 ---<<<
                        joinPartsOfferTempList.Add(JoinPartsTempWork);
                    }

                    // OFFER_DBの検索条件
                    object paraJoinPartsOfferObj = (object)joinPartsOfferTempList;

                    try
                    {
                        status = _iJoinPartsDB.Search(out joinPartsOfferObj, paraJoinPartsOfferObj);
                    }
                    catch
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }

                    // 結合マスタ(ユーザー)の削除
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ArrayList joinPartsOfferChgList = joinPartsOfferObj as ArrayList;
                        // OFFER_DB削除用リスト
                        ArrayList joinPartsOfferDelList = new ArrayList();
                        JoinPartsUWork JoinPartsUdelWork = null;

                        bool isFirst = true;
                        Hashtable JoinPartstable = new Hashtable();
                        foreach (JoinPartsWork delWork in joinPartsOfferChgList)
                        {

                            // MOD 譚洪 2009/07/08 --->>>
                            if (isFirst)
                            {
                                JoinPartstable.Add(Convert.ToString(delWork.JoinSourceMakerCode)
                                    + MARK_1 + delWork.JoinSourPartsNoWithH
                                    + MARK_1 + Convert.ToString(delWork.JoinDestMakerCd)
                                    + MARK_1 + delWork.JoinDestPartsNo, MARK_1);

                                JoinPartsUdelWork = new JoinPartsUWork();
                                JoinPartsUdelWork.EnterpriseCode = enterpriseCode;
                                JoinPartsUdelWork.JoinSourceMakerCode = delWork.JoinSourceMakerCode;
                                JoinPartsUdelWork.JoinSourPartsNoWithH = delWork.JoinSourPartsNoWithH;
                                JoinPartsUdelWork.JoinDestMakerCd = delWork.JoinDestMakerCd;
                                JoinPartsUdelWork.JoinDestPartsNo = delWork.JoinDestPartsNo;
                                // 更新日時用HASHTABLE
                                JoinPartsUdelWork.UpdateDateTime = (DateTime)updateTimeTable[Convert.ToString(delWork.JoinSourceMakerCode) + MARK_1 + delWork.JoinSourPartsNoWithH
                                    + MARK_1 + Convert.ToString(delWork.JoinDestMakerCd) + MARK_1 + delWork.JoinDestPartsNo];

                                joinPartsOfferDelList.Add(JoinPartsUdelWork);

                                isFirst = false;
                            }
                            else
                            {
                                if (JoinPartstable.ContainsKey(Convert.ToString(delWork.JoinSourceMakerCode)
                                    + MARK_1 + delWork.JoinSourPartsNoWithH
                                    + MARK_1 + Convert.ToString(delWork.JoinDestMakerCd)
                                    + MARK_1 + delWork.JoinDestPartsNo))
                                {
                                    continue;
                                }
                                else
                                {
                                    JoinPartstable.Add(Convert.ToString(delWork.JoinSourceMakerCode)
                                        + MARK_1 + delWork.JoinSourPartsNoWithH
                                        + MARK_1 + Convert.ToString(delWork.JoinDestMakerCd)
                                        + MARK_1 + delWork.JoinDestPartsNo, MARK_1);

                                    JoinPartsUdelWork = new JoinPartsUWork();
                                    JoinPartsUdelWork.EnterpriseCode = enterpriseCode;
                                    JoinPartsUdelWork.JoinSourceMakerCode = delWork.JoinSourceMakerCode;
                                    JoinPartsUdelWork.JoinSourPartsNoWithH = delWork.JoinSourPartsNoWithH;
                                    JoinPartsUdelWork.JoinDestMakerCd = delWork.JoinDestMakerCd;
                                    JoinPartsUdelWork.JoinDestPartsNo = delWork.JoinDestPartsNo;
                                    // 更新日時用HASHTABLE
                                    JoinPartsUdelWork.UpdateDateTime = (DateTime)updateTimeTable[Convert.ToString(delWork.JoinSourceMakerCode) + MARK_1 + delWork.JoinSourPartsNoWithH
                                        + MARK_1 + Convert.ToString(delWork.JoinDestMakerCd) + MARK_1 + delWork.JoinDestPartsNo];

                                    joinPartsOfferDelList.Add(JoinPartsUdelWork);
                                }
                            }
                        }
                        // ADD 譚洪 2009/07/10 --->>>
                        // 削除件数
                        joinTempCount = joinPartsOfferDelList.Count;
                        // ADD 譚洪 2009/07/10 ---<<<

                        object joinPartsOfferDelObj = (object)joinPartsOfferDelList;
                        status = _iJoinPartsUDB.Delete(joinPartsOfferDelObj);
                        // MOD 譚洪 2009/07/08 ---<<<
                    }
                    // 結合マスタ(提供)のデータが存在の場合、
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        continue;
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        joinCount = joinCount + joinTempCount;
                    }
                    else
                    {
                        break;
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    joinLogStr = "結合マスタ 削除件数：" + IntConvert(joinCount) + " 処理結果：正常終了";
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, joinLogStr, string.Empty);
                }
                else
                {
                    joinLogStr = "結合マスタ 削除件数：" + IntConvert(joinCount) + " 処理結果：更新処理に失敗しました。";
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, joinLogStr, string.Empty);
                }
            }
            // ユーザーDBのデータがないの場合、
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                joinLogStr = "結合マスタ 削除件数：0 処理結果：正常終了";
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, joinLogStr, string.Empty);
                return status;
            }
            else
            {
                joinLogStr = "結合マスタ 削除件数：0 処理結果：更新処理に失敗しました。";
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, joinLogStr, string.Empty);
                return status;
            }
            return status;
        }

        /// <summary>
        /// 検索件数フォーマット設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 検索件数フォーマット設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private String IntConvert(Int32 searchCount)
        {
            String searchCountStr = Convert.ToString(searchCount);
            Int32 searchCountLen = searchCountStr.Length;
            if (3 < searchCountLen && searchCountLen <= 6)
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 3) + "," + searchCountStr.Substring(searchCountLen - 3);
            }
            else if (6 < searchCountLen && searchCountLen <= 9)
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 6) + ","
                    + searchCountStr.Substring(searchCountLen - 6, 3) + ","
                    + searchCountStr.Substring(searchCountLen - 3);
            }
            return searchCountStr;
        }
        #endregion

        #region ■ セットマスタ（ユーザー）削除処理 ■
        /// <summary>
        /// セットマスタ（ユーザー）削除処理
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="setCount">削除件数</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : セットマスタ（ユーザー）削除処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.06.18</br> 
        /// </remarks>
        /// <returns>読込結果ステータス</returns>
        public int DeleteSetProc(string enterpriseCode, out int setCount)
        {
            string setLogStr = string.Empty;
            // 更新日時用HASHTABLE
            Hashtable updateTimeTable = new Hashtable(); 
            setCount = 0;
            // ユーザーDBの検索結果リスト
            ArrayList setPartsUserList = new ArrayList();
            object setPartsUserObj = (object)setPartsUserList;
            // ユーザーDBの検索条件ワーク
            GoodsSetWork paraSetPartsUserWork = new GoodsSetWork();
            paraSetPartsUserWork.EnterpriseCode = enterpriseCode;
            object paraSetPartsUserObj = (object)paraSetPartsUserWork;
            // OFFER_DBの検索結果リスト
            ArrayList setPartsOfferList = new ArrayList();
            object setPartsOfferObj = (object)setPartsOfferList;

            // ログ用アクセス
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            // ユーザーDBを検索する。
            this._iGoodsSetDB = MediationGoodsSetDB.GetGoodsSetDB();
            int status = _iGoodsSetDB.Search(out setPartsUserObj, paraSetPartsUserObj, 0, ConstantManagement.LogicalMode.GetDataAll);
            // セットマスタ(提供)の抽出
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList setPartsUserTempList = setPartsUserObj as ArrayList;
                ISetPartsDB _iSetPartsDB = MediationSetPartsDB.GetSetPartsDB();
                ArrayList loopList = new ArrayList();
                ArrayList loopAllList = new ArrayList();
                GoodsSetWork loopWork = null;
                int setInt = setPartsUserTempList.Count;

                for (int i = 1; i <= setInt; i++)
                {
                    loopWork = (GoodsSetWork)setPartsUserTempList[i - 1];
                    loopList.Add(loopWork);
                    // MOD 譚洪 2009/07/08 --->>>
                    if (i != 1 && i%100000 == 0)
                    // MOD 譚洪 2009/07/08 ---<<<
                    {

                        loopAllList.Add(loopList);
                        loopList = new ArrayList();
                    }
                }

                if (loopList.Count != 0)
                {
                    loopAllList.Add(loopList);
                }

                ArrayList loopTempList = new ArrayList();
                // OFFER_DB検索用リスト
                ArrayList setPartsOfferTempList;
                SetPartsWork setPartsTempWork = null;
                int setTempCount = 0;

                for (int m = 0; m < loopAllList.Count; m++)
                {
                    setPartsOfferTempList = new ArrayList();
                    loopTempList = (ArrayList)loopAllList[m];
                    for (int n = 0; n < loopTempList.Count; n++)
                    {
                        GoodsSetWork tempWork = (GoodsSetWork)loopTempList[n];
                        setPartsTempWork = new SetPartsWork();
                        setPartsTempWork.SetMainMakerCd = tempWork.ParentGoodsMakerCd;
                        setPartsTempWork.SetMainPartsNo = tempWork.ParentGoodsNo;
                        setPartsTempWork.SetSubMakerCd = tempWork.SubGoodsMakerCd;
                        setPartsTempWork.SetSubPartsNo = tempWork.SubGoodsNo;
                        // MOD 譚洪 2009/07/08 --->>>
                        // 更新日時用HASHTABLE
                        updateTimeTable.Add(Convert.ToString(tempWork.ParentGoodsMakerCd) + MARK_1 + tempWork.ParentGoodsNo
                            + MARK_1 + Convert.ToString(tempWork.SubGoodsMakerCd) + MARK_1 + tempWork.SubGoodsNo, tempWork.UpdateDateTime);
                        // MOD 譚洪 2009/07/08 ---<<<
                        setPartsOfferTempList.Add(setPartsTempWork);
                    }

                    // OFFER_DBの検索条件
                    object paraSetPartsOfferObj = (object)setPartsOfferTempList;


                    try
                    {
                        status = _iSetPartsDB.Search(out setPartsOfferObj, paraSetPartsOfferObj);
                    }
                    catch
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ArrayList setPartsOfferChgList = setPartsOfferObj as ArrayList;
                        setTempCount = setPartsOfferChgList.Count;
                        // OFFER_DB削除用リスト
                        ArrayList setPartsOfferDelList = new ArrayList();
                        GoodsSetWork goodsSetDelWork = null;
                        foreach (SetPartsWork delWork in setPartsOfferChgList)
                        {
                            goodsSetDelWork = new GoodsSetWork();
                            goodsSetDelWork.EnterpriseCode = enterpriseCode;
                            goodsSetDelWork.ParentGoodsMakerCd = delWork.SetMainMakerCd;
                            goodsSetDelWork.ParentGoodsNo = delWork.SetMainPartsNo;
                            goodsSetDelWork.SubGoodsMakerCd = delWork.SetSubMakerCd;
                            goodsSetDelWork.SubGoodsNo = delWork.SetSubPartsNo;
                            // MOD 譚洪 2009/07/08 --->>>
                            // 更新日時用HASHTABLE
                            goodsSetDelWork.UpdateDateTime = (DateTime)updateTimeTable[Convert.ToString(delWork.SetMainMakerCd) + MARK_1 + delWork.SetMainPartsNo
                                + MARK_1 + Convert.ToString(delWork.SetSubMakerCd) + MARK_1 + delWork.SetSubPartsNo];
                            // MOD 譚洪 2009/07/08 ---<<<
                            setPartsOfferDelList.Add(goodsSetDelWork);
                        }
                        GoodsSetWork[] goodsSetDelWorks = (GoodsSetWork[])setPartsOfferDelList.ToArray(typeof(GoodsSetWork));
                        byte[] setPartsOfferDelObj = XmlByteSerializer.Serialize(goodsSetDelWorks);

                        status = _iGoodsSetDB.Delete(setPartsOfferDelObj);
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        continue;
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        setCount = setCount + setTempCount;
                    }
                    else
                    {
                        break;
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    setLogStr = "セットマスタ 削除件数：" + IntConvert(setCount) + " 処理結果：正常終了";
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, setLogStr, string.Empty);
                }
                else
                {
                    setLogStr = "セットマスタ 削除件数：" + IntConvert(setCount) + " 処理結果：更新処理に失敗しました。";
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, setLogStr, string.Empty);
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                setLogStr = "セットマスタ 削除件数：0 処理結果：正常終了";
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, setLogStr, string.Empty);
                return status;
            }
            else
            {
                setLogStr = "セットマスタ 削除件数：0 処理結果：更新処理に失敗しました。";
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, setLogStr, string.Empty);
                return status;
            }
            return status;
        }
        #endregion
    }
}
