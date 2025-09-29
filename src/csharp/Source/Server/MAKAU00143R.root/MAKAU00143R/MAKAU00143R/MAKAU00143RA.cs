using System;
using System.IO;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Reflection;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using System.Collections.Generic;
using Broadleaf.Library.Diagnostics;
//using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 支払金額マスタ更新リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先支払金額マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.04.20</br>
    /// <br></br>
    /// <br>Update Note: 2007.12.07  980081 山田 明友</br>
    /// <br>           : 流通基幹対応</br>
    /// <br></br>
    /// <br>Update Note: 2008.01.10  980081 山田 明友</br>
    /// <br>           : 支払先略称・今回繰越残高をセットするよう修正</br>
    /// <br>           : 全拠点一括締め対応</br>
    /// <br></br>
    /// <br>Update Note: 2008.03.12  980081 山田 明友</br>
    /// <br>           : 管理拠点分の仕入先のみを更新するよう修正</br>
    /// <br>           : 金額セット項目修正</br>
    /// <br></br>
    /// <br>Update Note: 2008.03.14  980081 山田 明友</br>
    /// <br>           : 支払先の情報を得意先仕入情報マスタから取得するよう修正</br>
    /// <br></br>
    /// <br>Update Note: 2008.07.24  20081 疋田 勇人</br>
    /// <br>           : ＰＭ.ＮＳ用に変更</br>
    /// <br></br>
    /// <br>Update Note: 2008.10.01  23015 森本 大輝</br>
    /// <br>           : 支払締更新履歴マスタテーブルレイアウト変更対応</br>
    /// <br></br>
    /// <br>Update Note: 2008.10.18  23012 畠中 啓次朗</br>
    /// <br>           : 支払締更新履歴マスタ作成処理変更対応</br>
    /// <br></br>
    /// <br>Update Note: 2009.01.16  23012 畠中 啓次朗</br>
    /// <br>           : 不具合修正</br>
    /// <br></br>
    /// <br>Update Note: 2009.01.21  23012 畠中 啓次朗</br>
    /// <br>           : 不具合修正</br>
    /// <br></br>
    /// <br>Update Note: 2009.03.24  23012 畠中 啓次朗</br>
    /// <br>           : 行値引・商品値引対応</br>
    /// <br></br>
    /// <br>Update Note: 2009/04/17  23012 畠中 啓次朗</br>
    /// <br>           : 仕様変更(消費税算出処理を最終転嫁方式計算からPM7計算方式に変更)</br>
    /// <br></br>
    /// <br>Update Note: 2010/03/02  22018 鈴木 正臣</br>
    /// <br>           : 支払マイナスかつ残マイナスの場合の残高算出処理修正(MANTIS:15081)</br>
    /// <br></br>
    /// <br>Update Note: 2010/10/06  22008 長内 数馬</br>
    /// <br>           : 仕入先マスタの支払拠点を変更した場合の不具合を修正(MANTIS:16185)</br>
    /// <br></br>
    /// <br>Update Note: 2010/11/24  22008 長内 数馬</br>
    /// <br>           : 前回残取得時の不具合を修正</br>
	/// <br></br>
    /// <br>Update Note: 2011/07/28  PM1107C 徐錦山</br>
    /// <br>           : 仕入締次更新処理中も伝票登録できるように修正(#連番847)</br>
    /// <br>Update Note: 2012/05/10  yangmj</br>
    /// <br>           : 売上締次集計処理中に伝票発行不可の修正</br>
    /// <br>Update Note: 2012/09/11  FSI佐々木 貴英</br>
    /// <br>           : 仕入総括処理対応 仕入総括形式の支払締処理を追加</br>
    /// </remarks>
    [Serializable]
    public class SuplierPayDB : RemoteWithAppLockDB, ISuplierPayDB
    {
        /// <summary>
        /// 支払金額マスタ更新リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public SuplierPayDB()
            :
            base("MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.SuplierPayWork", "SUPLIERPAYRF")
        {
        }

        #region [Write 支払締処理]
        /// <summary>
        /// 仕入先支払金額マスタを更新します
        /// </summary>
        /// <param name="paraObj">仕入先支払金額マスタ更新パラメータ</param>
        /// <param name="retList">仕入先支払金額マスタ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額マスタを更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// <br>Update Note: 仕入締次更新処理中も伝票登録できるように修正(#847)</br>
        /// <br>Programmer : PM1107C 徐錦山</br>
        /// <br>Date       : 2011/07/28</br>
        /// <br>Update Note: 売上締次集計処理中に伝票発行不可の修正</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        /// </remarks>
        public int Write(ref object paraObj, out object retList, out string retMsg)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            
            retList = null;
            retMsg = null;

            //支払金額マスタList(更新用)
            ArrayList suplierPayWorkList = new ArrayList();
            
            //支払金額マスタList(支払先子出力用)
            ArrayList suplierPayChildWorkList = new ArrayList();// ← 2007.09.14 980081 a

            //仕入先単位の更新ステータスList(UI側にリターン)
            ArrayList statusList = new ArrayList();

            //支払締更新履歴List
            ArrayList paymentAddUpHisWorkList = null;

            //精算支払集計データList(更新用)
            ArrayList accPayTotalWorkList = new ArrayList(); // 2008.07.24 add

            //支払金額マスタ
            SuplierPayWork suplierPayWork = null;
            SuplierPayUpdStatusWork suplierPayUpdStatusWork = null;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection_read = null;

            // 排他制御部品
            ShareCheckInfo info = new ShareCheckInfo();

            //拠点情報設定取得部品
            SecInfoSetDB secInfoSetDB = new SecInfoSetDB(); // ← 2008.01.10 980081 a

            try
            {
                //●パラメータセット
                SuplierPayUpdateWork suplierPayUpdateWork = paraObj as SuplierPayUpdateWork;
                
                if (suplierPayUpdateWork == null)
                {
                    base.WriteErrorLog(null, "プログラムエラー。パラメータが未設定です");
                    return status;
                }

                //メソッド開始時にコネクション文字列を取得
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //●SQLコネクションオブジェクト作成
                using (sqlConnection = new SqlConnection(connectionText))
                {
                    //SqlEncryptInfo sqlEncryptInfo = null;
                    try
                    {
                        sqlConnection.Open();
                        // Read用コネクションをインスタンス化
                        sqlConnection_read = new SqlConnection(connectionText);
                        sqlConnection_read.Open();

                        sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                        #region 排他制御
                        // 2011/07/28 XUJS DEL STA>>>>>>
                        //if (suplierPayUpdateWork.AddUpSecCode == "" || suplierPayUpdateWork.AddUpSecCode == "00")
                        //{
                        //    // システムロック(企業)
                        //    info.Keys.Add(suplierPayUpdateWork.EnterpriseCode, ShareCheckType.Enterprise, "", "");
                        //    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                        //}
                        //else
                        //{
                        //    //システムロック(拠点) //2009/1/27 Add sakurai
                        //    info.Keys.Add(suplierPayUpdateWork.EnterpriseCode, ShareCheckType.Section, suplierPayUpdateWork.AddUpSecCode, "");
                        //    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                        //}
                        // 2011/07/28 XUJS DEL END<<<<<<

                        // 2011/07/28 XUJS ADD STA>>>>>
                        // 締次集計ロックの為に拠点コード補正
                        string sectionCode = suplierPayUpdateWork.AddUpSecCode.Trim();
                        if (sectionCode == string.Empty)
                        {
                            sectionCode = "00";
                        }

                        // 締次集計ロック
                        info.Keys.Add(new ShareCheckKey(suplierPayUpdateWork.EnterpriseCode,
                                                          //ShareCheckType.AddUpUpdate,//DEL yangmj 2012/05/10 売上締次集計処理中に伝票発行不可の修正
                                                          ShareCheckType.SupUpUpdate,//ADD yangmj 2012/05/10 売上締次集計処理中に伝票発行不可の修正
                                                          sectionCode,
                                                          "",
                                                          suplierPayUpdateWork.SupplierTotalDay,
                                                          ToLongDate(suplierPayUpdateWork.AddUpDate)));
                        // 締次ロック開始
                        status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                        // 2011/07/28 XUJS ADD END<<<<<<

                        if (status != 0)
                        {
                            return status;
                        }
                        #endregion

                        // 修正 2009/04/17 全拠点締の場合、登録拠点分クエリを実行しているため修正 >>>
                        #region DEL 2009/04/17 
                        /*
                        //全拠点一括締め対応 
                        SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
                        secInfoSetWork.EnterpriseCode = suplierPayUpdateWork.EnterpriseCode;
                        ArrayList secInfoList = new ArrayList();
                        if (suplierPayUpdateWork.AddUpSecCode == null || suplierPayUpdateWork.AddUpSecCode == "00") // ADD 2008.11.19
                        {
                            //全拠点
                            secInfoSetDB.Search(out secInfoList, secInfoSetWork, 0, 0, ref sqlConnection_read);
                        }
                        else
                        {
                            // 単独拠点(画面指定の拠点を使用)
                            secInfoSetWork.SectionCode = suplierPayUpdateWork.AddUpSecCode;
                            secInfoList.Add(secInfoSetWork);
                        }
                        string addUpSecCode = suplierPayUpdateWork.AddUpSecCode; 
                        for (int loopCount = 0; loopCount < secInfoList.Count; loopCount++)
                        {
                            #region 仕入先リスト作成処理
                            suplierPayUpdateWork.AddUpSecCode = (secInfoList[loopCount] as SecInfoSetWork).SectionCode;
                        // ↑ 2008.01.10 980081 a
                            //●仕入先マスタから締日を取得
                            //全仕入先対象
                            if (suplierPayUpdateWork.UpdObjectFlag == 1)
                            {
                                status = GetSupplier(ref suplierPayUpdateWork, ref suplierPayWorkList, ref sqlConnection_read);
                            }
                            #endregion
                        }
                        suplierPayUpdateWork.AddUpSecCode = addUpSecCode;
                        */
                        #endregion
                        // 対象仕入先取得
                        status = GetSupplier(ref suplierPayUpdateWork, ref suplierPayWorkList, ref sqlConnection_read);
                        // 修正 2009/04/17 <<<

                        if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                        {
                            retMsg = "仕入日が税率有効日３より未来日付のため消費税率を算出できません。\r\n税率設定を見直してください。";
                            return status;
                        }
                        if (suplierPayWorkList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            retMsg = "対象となる仕入先が存在しません。";
                            return status;
                        }

                        //●支払金額マスタ更新パラメータList作成
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = MakeSuplierPayParameters(ref suplierPayUpdateWork, ref suplierPayWorkList, ref suplierPayChildWorkList, ref accPayTotalWorkList, out paymentAddUpHisWorkList, out retMsg, ref sqlConnection_read);
                        }

                        if (sqlConnection_read != null) sqlConnection_read.Close();
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                        try
                        {
                            #region DEL 2009/04/17
                            //int listCount = 0;
                            //for (int i = 0; i < suplierPayWorkList.Count; i++)
                            //{
                            //    suplierPayWork = suplierPayWorkList[i] as SuplierPayWork;
                            //    if (suplierPayWork.UpdateStatus == 0)
                            //    {
                            //        listCount += 1;
                            //    }
                            //}
                            //Int32[] customerCodeList = new Int32[listCount];
                            //ArrayList al = new ArrayList();//ワーク用
                            ////仕入先コードList作成
                            //for (int i = 0; i < suplierPayWorkList.Count; i++)
                            //{
                            //    suplierPayWork = suplierPayWorkList[i] as SuplierPayWork;
                            //    //更新得意先コード抽出
                            //    if (suplierPayWork.UpdateStatus == 0)
                            //    {
                            //        al.Add(suplierPayWork.PayeeCode);
                            //    }

                            //}
                            //customerCodeList = (Int32[])al.ToArray(typeof(Int32));
                            //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            #endregion

                            //●支払金額マスタ更新処理
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (suplierPayWorkList.Count > 0)
                                {
                                    status = WriteSuplierPay(ref suplierPayWorkList, ref suplierPayChildWorkList, ref sqlConnection, ref sqlTransaction);
                                }
                                else
                                {
                                    retMsg = "更新可能な仕入先が存在しません。\r\n更新件数は0件です。";
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                    return status;
                                }
                            }
                            //●精算支払集計データ更新処理
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (accPayTotalWorkList.Count > 0)
                                {
                                    status = WriteAccPayTotalPrc(ref accPayTotalWorkList, ref sqlConnection, ref sqlTransaction);
                                }
                            }

                            //●支払締更新履歴マスタ更新処理
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (paymentAddUpHisWorkList.Count > 0)
                                {
                                    //締次更新処理実行時
                                    status = WritePaymentAddUpHis(ref paymentAddUpHisWorkList, ref sqlConnection, ref sqlTransaction);
                                }
                                //一応念のため追加
                                else
                                {
                                    retMsg = "更新可能な仕入先が存在しません。\r\n更新件数は0件です。";
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                    return status;
                                }
                            }

                            //●更新ステータス情報生成
                            for (int i = 0; i < suplierPayWorkList.Count; i++)
                            {
                                suplierPayWork = suplierPayWorkList[i] as SuplierPayWork;
                                suplierPayUpdStatusWork = new SuplierPayUpdStatusWork();
                                suplierPayUpdStatusWork.EnterpriseCode = suplierPayWork.EnterpriseCode;
                                suplierPayUpdStatusWork.SupplierCd = suplierPayWork.PayeeCode;
                                suplierPayUpdStatusWork.AddUpSecCode = suplierPayWork.AddUpSecCode;
                                suplierPayUpdStatusWork.UpdateStatus = suplierPayWork.UpdateStatus;
                                if (suplierPayWork.PayeeCode == suplierPayWork.SupplierCd)
                                {
                                    statusList.Add(suplierPayUpdStatusWork);
                                }
                            }

                            //●戻り値をセット
                            retList = (object)statusList;
                        }
                        catch (SqlException ex)
                        {
                            status = base.WriteSQLErrorLog(ex);
                        }
                        catch (Exception ex)
                        {
                            base.WriteErrorLog(ex, "SuplierPayDB.Write Exception=" + ex.Message);
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                        finally
                        {
                            ////システムロック解除 //2009/1/27 Add sakurai
                            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            //{
                            //    status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                            //}

                            ////●コミットorロールバック
                            ////正常更新時コミット、異常発生時ロールバック
                            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) sqlTransaction.Commit();
                            //else sqlTransaction.Rollback();
                        }
                        
                    }
                    finally
                    {
                        //システムロック解除 //2009/1/27 Add sakurai
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        }

                        //●コミットorロールバック
                        //正常更新時コミット、異常発生時ロールバック
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) sqlTransaction.Commit();
                        else sqlTransaction.Rollback();

                        //●コネクション破棄
                        if (sqlConnection != null) sqlConnection.Close();
                        if (sqlConnection_read != null) sqlConnection_read.Close();

                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuplierPayDB.Write Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }

            return status;
        }

        // --- ADD 2012/09/11 ----------->>>>>
        /// <summary>
        /// 仕入総括形式で仕入先支払金額マスタを更新します
        /// </summary>
        /// <param name="paraObj">仕入先支払金額マスタ更新パラメータ</param>
        /// <param name="retList">仕入先支払金額マスタ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入総括形式で仕入先支払金額マスタを更新します</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : 2012/09/11</br>
        /// </remarks>
        public int WriteByAddUpSecCode(ref object paraObj, out object retList, out string retMsg)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            
            retList = null;
            retMsg = null;

            //支払金額マスタList(更新用)
            ArrayList suplierPayWorkList = new ArrayList();
            
            //支払金額マスタList(支払先子出力用)
            ArrayList suplierPayChildWorkList = new ArrayList();

            //仕入先単位の更新ステータスList(UI側にリターン)
            ArrayList statusList = new ArrayList();

            //支払締更新履歴List
            ArrayList paymentAddUpHisWorkList = null;

            //精算支払集計データList(更新用)
            ArrayList accPayTotalWorkList = new ArrayList();

            //支払金額マスタ
            SuplierPayWork suplierPayWork = null;
            SuplierPayUpdStatusWork suplierPayUpdStatusWork = null;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection_read = null;

            // 排他制御部品
            ShareCheckInfo info = new ShareCheckInfo();

            //拠点情報設定取得部品
            SecInfoSetDB secInfoSetDB = new SecInfoSetDB();

            try
            {
                //●パラメータセット
                SuplierPayUpdateWork suplierPayUpdateWork = paraObj as SuplierPayUpdateWork;
                
                if (suplierPayUpdateWork == null)
                {
                    base.WriteErrorLog(null, "プログラムエラー。パラメータが未設定です");
                    return status;
                }

                //メソッド開始時にコネクション文字列を取得
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //●SQLコネクションオブジェクト作成
                using (sqlConnection = new SqlConnection(connectionText))
                {
                    try
                    {
                        sqlConnection.Open();
                        // Read用コネクションをインスタンス化
                        sqlConnection_read = new SqlConnection(connectionText);
                        sqlConnection_read.Open();

                        sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                        #region 排他制御
                        // 締次集計ロックの為に拠点コード補正
                        string sectionCode = suplierPayUpdateWork.AddUpSecCode.Trim();
                        if (sectionCode == string.Empty)
                        {
                            sectionCode = "00";
                        }

                        // 締次集計ロック
                        info.Keys.Add(new ShareCheckKey(suplierPayUpdateWork.EnterpriseCode,
                                                          ShareCheckType.SupUpUpdate,
                                                          sectionCode,
                                                          "",
                                                          suplierPayUpdateWork.SupplierTotalDay,
                                                          ToLongDate(suplierPayUpdateWork.AddUpDate)));
                        // 締次ロック開始
                        status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

                        if (status != 0)
                        {
                            return status;
                        }
                        #endregion

                        // 対象仕入先取得
                        status = GetSupplierByAddUpSecCode(
                            ref suplierPayUpdateWork, ref suplierPayWorkList, ref retMsg, ref sqlConnection_read);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                        {
                            retMsg = "仕入日が税率有効日３より未来日付のため消費税率を算出できません。\r\n税率設定を見直してください。";
                            return status;
                        }
                        if (suplierPayWorkList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            retMsg = "対象となる仕入先が存在しません。";
                            return status;
                        }

                        //●支払金額マスタ更新パラメータList作成
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = MakeSuplierPayParametersByAddUpSecCode(
                                  ref suplierPayUpdateWork
                                , ref suplierPayWorkList
                                , ref suplierPayChildWorkList
                                , ref accPayTotalWorkList
                                , out paymentAddUpHisWorkList
                                , out retMsg
                                , ref sqlConnection_read);
                        }

                        if (sqlConnection_read != null) sqlConnection_read.Close();
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                        try
                        {
                            //●支払金額マスタ更新処理
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (suplierPayWorkList.Count > 0)
                                {
                                    status = WriteSuplierPay(ref suplierPayWorkList, ref sqlConnection, ref sqlTransaction);
                                }
                                else
                                {
                                    retMsg = "更新可能な仕入先が存在しません。\r\n更新件数は0件です。";
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                    return status;
                                }
                            }
                            //●精算支払集計データ更新処理
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (accPayTotalWorkList.Count > 0)
                                {
                                    status = WriteAccPayTotalPrc(ref accPayTotalWorkList, ref sqlConnection, ref sqlTransaction);
                                }
                            }

                            //●支払締更新履歴マスタ更新処理
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (paymentAddUpHisWorkList.Count > 0)
                                {
                                    //締次更新処理実行時
                                    status = WritePaymentAddUpHis(ref paymentAddUpHisWorkList, ref sqlConnection, ref sqlTransaction);
                                }
                                else
                                {
                                    retMsg = "更新可能な仕入先が存在しません。\r\n更新件数は0件です。";
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                    return status;
                                }
                            }

                            //●更新ステータス情報生成
                            for (int i = 0; i < suplierPayWorkList.Count; i++)
                            {
                                suplierPayWork = suplierPayWorkList[i] as SuplierPayWork;
                                suplierPayUpdStatusWork = new SuplierPayUpdStatusWork();
                                suplierPayUpdStatusWork.EnterpriseCode = suplierPayWork.EnterpriseCode;
                                suplierPayUpdStatusWork.SupplierCd = suplierPayWork.PayeeCode;
                                suplierPayUpdStatusWork.AddUpSecCode = suplierPayWork.AddUpSecCode;
                                suplierPayUpdStatusWork.UpdateStatus = suplierPayWork.UpdateStatus;
                                if (suplierPayWork.PayeeCode == suplierPayWork.SupplierCd)
                                {
                                    statusList.Add(suplierPayUpdStatusWork);
                                }
                            }

                            //●戻り値をセット
                            retList = (object)statusList;
                        }
                        catch (SqlException ex)
                        {
                            status = base.WriteSQLErrorLog(ex);
                        }
                        catch (Exception ex)
                        {
                            base.WriteErrorLog(ex, "SuplierPayDB.Write Exception=" + ex.Message);
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                    }
                    finally
                    {
                        //システムロック解除
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        }

                        //●コミットorロールバック
                        //正常更新時コミット、異常発生時ロールバック
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) sqlTransaction.Commit();
                        else sqlTransaction.Rollback();

                        //●コネクション破棄
                        if (sqlConnection != null) sqlConnection.Close();
                        if (sqlConnection_read != null) sqlConnection_read.Close();

                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuplierPayDB.Write Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //データ無しの場合はステータスを警告ステータスに変更する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND ||
                    status == (int)ConstantManagement.DB_Status.ctDB_EOF) status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }

            return status;
        }
        // --- ADD 2012/09/11 -----------<<<<<

        /// <br>Update Note: 仕入締次更新処理中も伝票登録できるように修正(#847)</br>
        /// <br>Programmer : PM1107C 徐錦山</br>
        /// <br>Date       : 2011/07/28</br>
        // 2011/07/28 XUJS ADD STA>>>>>>
        private int ToLongDate(DateTime dateTime)
        {
            try
            {
                return (dateTime.Year * 10000 + dateTime.Month * 100 + dateTime.Day);
            }
            catch
            {
                return 0;
            }
        }
        // 2011/07/28 XUJS ADD END<<<<<<

        /// <summary>
        /// 仕入先支払金額マスタを更新します
        /// </summary>
        /// <param name="suplierPayWorkList">仕入先支払金額マスタList</param>
        /// <param name="suplierPayChildWorkList">仕入先支払金額マスタ(子レコード用)List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額マスタを更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // ↓ 2007.09.14 980081 c 支払先子レコード作成対応
        //private int WriteSuplierPay(ref ArrayList suplierPayWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int WriteSuplierPay(ref ArrayList suplierPayWorkList, ref ArrayList suplierPayChildWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        // ↑ 2007.09.14 980081 c
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            string sqlText = string.Empty; // 2008.07.24 add

            //Deleteコマンドの生成
            try
            {
                for (int i = 0; i < suplierPayWorkList.Count; i++)
                {
                    SuplierPayWork suplierPayWork = suplierPayWorkList[i] as SuplierPayWork;
                    if (suplierPayWork.UpdateStatus == 0)
                    {
                        // 2008.07.24 upd start ---------------------------------------->>
                        //using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM SUPLIERPAYRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND PAYEECODERF=@FINDPAYEECODE AND ADDUPDATERF>=@FINDSTARTCADDUPUPDDATE AND ADDUPDATERF<=@FINDADDUPDATE ", sqlConnection, sqlTransaction))
                        sqlText = string.Empty;
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += " FROM SUPLIERPAYRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                        sqlText += "    AND PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                        // 修正 2009/07/03 >>>
                        //sqlText += "    AND ADDUPDATERF>=@FINDSTARTCADDUPUPDDATE" + Environment.NewLine;
                        //sqlText += "    AND ADDUPDATERF<=@FINDADDUPDATE" + Environment.NewLine;
                        sqlText += "    AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;
                        // 修正 2009/07/03 <<<
                        using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                        // 2008.07.24 upd end ------------------------------------------<<
                        {
                            //Prameterオブジェクトの作成
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                            // ↓ 2007.09.14 980081 c 得意先コードで削除していたのを支払先コードに変更
                            //SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                            SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                            // ↑ 2007.09.14 980081 c
                            SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                            //SqlParameter findParaStartCAddUpUpdDate = sqlCommand.Parameters.Add("@FINDSTARTCADDUPUPDDATE", SqlDbType.Int); // add 2007.06.04 saito // DEL 2009/07/03

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                            findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);
                            // ↓ 2007.09.14 980081 c 得意先コードで削除していたのを支払先コードに変更
                            //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.CustomerCode);
                            findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                            // ↑ 2007.09.14 980081 c
                            findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);
                            // add 2007.06.04 saito
                            // DEL 2009/07/03 >>>
                            //findParaStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.StartCAddUpUpdDate);
                            //if (suplierPayWork.StartCAddUpUpdDate == DateTime.MinValue)
                            //    findParaStartCAddUpUpdDate.Value = 20000101;
                            // DEL 2009/07/03 <<<

                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    if (suplierPayWork.UpdateStatus == 0 && suplierPayWork.CAddUpUpdExecDate != DateTime.MinValue)
                    {
                        // 2008.07.24 upd start --------------------------------->>
                        //using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO SUPLIERPAYRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPSECCODERF, PAYEECODERF, PAYEENAMERF, PAYEENAME2RF, PAYEESNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, ADDUPDATERF, ADDUPYEARMONTHRF, LASTTIMEPAYMENTRF, THISTIMEFEEPAYNRMLRF, THISTIMEDISPAYNRMLRF, THISTIMEPAYNRMLRF, THISTIMETTLBLCPAYRF, OFSTHISTIMESTOCKRF, OFSTHISSTOCKTAXRF, ITDEDOFFSETOUTTAXRF, ITDEDOFFSETINTAXRF, ITDEDOFFSETTAXFREERF, OFFSETOUTTAXRF, OFFSETINTAXRF, THISTIMESTOCKPRICERF, THISSTCPRCTAXRF, TTLITDEDSTCOUTTAXRF, TTLITDEDSTCINTAXRF, TTLITDEDSTCTAXFREERF, TTLSTOCKOUTERTAXRF, TTLSTOCKINNERTAXRF, THISSTCKPRICRGDSRF, THISSTCPRCTAXRGDSRF, TTLITDEDRETOUTTAXRF, TTLITDEDRETINTAXRF, TTLITDEDRETTAXFREERF, TTLRETOUTERTAXRF, TTLRETINNERTAXRF, THISSTCKPRICDISRF, THISSTCPRCTAXDISRF, TTLITDEDDISOUTTAXRF, TTLITDEDDISINTAXRF, TTLITDEDDISTAXFREERF, TTLDISOUTERTAXRF, TTLDISINNERTAXRF, THISRECVOFFSETRF, THISRECVOFFSETTAXRF, THISRECVOUTTAXRF, THISRECVINTAXRF, THISRECVTAXFREERF, THISRECVOUTERTAXRF, THISRECVINNERTAXRF, TAXADJUSTRF, BALANCEADJUSTRF, STOCKTOTALPAYBALANCERF, STOCKTTL2TMBFBLPAYRF, STOCKTTL3TMBFBLPAYRF, CADDUPUPDEXECDATERF, STARTCADDUPUPDDATERF, LASTCADDUPUPDDATERF, STOCKSLIPCOUNTRF, PAYMENTSCHEDULERF, PAYMENTCONDRF, SUPPCTAXLAYCDRF, SUPPLIERCONSTAXRATERF, FRACTIONPROCCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ADDUPSECCODE, @PAYEECODE, @PAYEENAME, @PAYEENAME2, @PAYEESNM, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @CUSTOMERSNM, @ADDUPDATE, @ADDUPYEARMONTH, @LASTTIMEPAYMENT, @THISTIMEFEEPAYNRML, @THISTIMEDISPAYNRML, @THISTIMEPAYNRML, @THISTIMETTLBLCPAY, @OFSTHISTIMESTOCK, @OfsThisStockTax, @ITDEDOFFSETOUTTAX, @ITDEDOFFSETINTAX, @ITDEDOFFSETTAXFREE, @OFFSETOUTTAX, @OFFSETINTAX, @THISTIMESTOCKPRICE, @THISSTCPRCTAX, @TTLITDEDSTCOUTTAX, @TTLITDEDSTCINTAX, @TTLITDEDSTCTAXFREE, @TTLSTOCKOUTERTAX, @TTLSTOCKINNERTAX, @THISSTCKPRICRGDS, @THISSTCPRCTAXRGDS, @TTLITDEDRETOUTTAX, @TTLITDEDRETINTAX, @TTLITDEDRETTAXFREE, @TTLRETOUTERTAX, @TTLRETINNERTAX, @THISSTCKPRICDIS, @THISSTCPRCTAXDIS, @TTLITDEDDISOUTTAX, @TTLITDEDDISINTAX, @TTLITDEDDISTAXFREE, @TTLDISOUTERTAX, @TTLDISINNERTAX, @THISRECVOFFSET, @THISRECVOFFSETTAX, @THISRECVOUTTAX, @THISRECVINTAX, @THISRECVTAXFREE, @THISRECVOUTERTAX, @THISRECVINNERTAX, @TAXADJUST, @BALANCEADJUST, @STOCKTOTALPAYBALANCE, @STOCKTTL2TMBFBLPAY, @STOCKTTL3TMBFBLPAY, @CADDUPUPDEXECDATE, @STARTCADDUPUPDDATE, @LASTCADDUPUPDDATE, @STOCKSLIPCOUNT, @PAYMENTSCHEDULE, @PAYMENTCOND, @SUPPCTAXLAYCD, @SUPPLIERCONSTAXRATE, @FRACTIONPROCCD)", sqlConnection, sqlTransaction))
                        #region INSERT文作成
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO SUPLIERPAYRF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "    ,ADDUPSECCODERF" + Environment.NewLine;
                        sqlText += "    ,PAYEECODERF" + Environment.NewLine;
                        sqlText += "    ,PAYEENAMERF" + Environment.NewLine;
                        sqlText += "    ,PAYEENAME2RF" + Environment.NewLine;
                        sqlText += "    ,PAYEESNMRF" + Environment.NewLine;
                        sqlText += "    ,RESULTSSECTCDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERCDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNM1RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNM2RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERSNMRF" + Environment.NewLine;
                        sqlText += "    ,ADDUPDATERF" + Environment.NewLine;
                        sqlText += "    ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        sqlText += "    ,LASTTIMEPAYMENTRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMEFEEPAYNRMLRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMEDISPAYNRMLRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMEPAYNRMLRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMETTLBLCPAYRF" + Environment.NewLine;
                        sqlText += "    ,OFSTHISTIMESTOCKRF" + Environment.NewLine;
                        sqlText += "    ,OFSTHISSTOCKTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDOFFSETINTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,OFFSETOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,OFFSETINTAXRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMESTOCKPRICERF" + Environment.NewLine;
                        sqlText += "    ,THISSTCPRCTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDSTCOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDSTCINTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDSTCTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,TTLSTOCKOUTERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLSTOCKINNERTAXRF" + Environment.NewLine;
                        sqlText += "    ,THISSTCKPRICRGDSRF" + Environment.NewLine;
                        sqlText += "    ,THISSTCPRCTAXRGDSRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDRETINTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDRETTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,TTLRETOUTERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLRETINNERTAXRF" + Environment.NewLine;
                        sqlText += "    ,THISSTCKPRICDISRF" + Environment.NewLine;
                        sqlText += "    ,THISSTCPRCTAXDISRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDDISINTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDDISTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,TTLDISOUTERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLDISINNERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TAXADJUSTRF" + Environment.NewLine;
                        sqlText += "    ,BALANCEADJUSTRF" + Environment.NewLine;
                        sqlText += "    ,STOCKTOTALPAYBALANCERF" + Environment.NewLine;
                        sqlText += "    ,STOCKTTL2TMBFBLPAYRF" + Environment.NewLine;
                        sqlText += "    ,STOCKTTL3TMBFBLPAYRF" + Environment.NewLine;
                        sqlText += "    ,CADDUPUPDEXECDATERF" + Environment.NewLine;
                        sqlText += "    ,STARTCADDUPUPDDATERF" + Environment.NewLine;
                        sqlText += "    ,LASTCADDUPUPDDATERF" + Environment.NewLine;
                        sqlText += "    ,STOCKSLIPCOUNTRF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTSCHEDULERF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTCONDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPCTAXLAYCDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                        sqlText += "    ,FRACTIONPROCCDRF" + Environment.NewLine;
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
                        sqlText += "    ,@ADDUPSECCODE" + Environment.NewLine;
                        sqlText += "    ,@PAYEECODE" + Environment.NewLine;
                        sqlText += "    ,@PAYEENAME" + Environment.NewLine;
                        sqlText += "    ,@PAYEENAME2" + Environment.NewLine;
                        sqlText += "    ,@PAYEESNM" + Environment.NewLine;
                        sqlText += "    ,@RESULTSSECTCD" + Environment.NewLine;
                        sqlText += "    ,@SUPPLIERCD" + Environment.NewLine;
                        sqlText += "    ,@SUPPLIERNM1" + Environment.NewLine;
                        sqlText += "    ,@SUPPLIERNM2" + Environment.NewLine;
                        sqlText += "    ,@SUPPLIERSNM" + Environment.NewLine;
                        sqlText += "    ,@ADDUPDATE" + Environment.NewLine;
                        sqlText += "    ,@ADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += "    ,@LASTTIMEPAYMENT" + Environment.NewLine;
                        sqlText += "    ,@THISTIMEFEEPAYNRML" + Environment.NewLine;
                        sqlText += "    ,@THISTIMEDISPAYNRML" + Environment.NewLine;
                        sqlText += "    ,@THISTIMEPAYNRML" + Environment.NewLine;
                        sqlText += "    ,@THISTIMETTLBLCPAY" + Environment.NewLine;
                        sqlText += "    ,@OFSTHISTIMESTOCK" + Environment.NewLine;
                        sqlText += "    ,@OFSTHISSTOCKTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDOFFSETINTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@OFFSETOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@OFFSETINTAX" + Environment.NewLine;
                        sqlText += "    ,@THISTIMESTOCKPRICE" + Environment.NewLine;
                        sqlText += "    ,@THISSTCPRCTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDSTCOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDSTCINTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDSTCTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@TTLSTOCKOUTERTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLSTOCKINNERTAX" + Environment.NewLine;
                        sqlText += "    ,@THISSTCKPRICRGDS" + Environment.NewLine;
                        sqlText += "    ,@THISSTCPRCTAXRGDS" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDRETINTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@TTLRETOUTERTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLRETINNERTAX" + Environment.NewLine;
                        sqlText += "    ,@THISSTCKPRICDIS" + Environment.NewLine;
                        sqlText += "    ,@THISSTCPRCTAXDIS" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDDISINTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@TTLDISOUTERTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLDISINNERTAX" + Environment.NewLine;
                        sqlText += "    ,@TAXADJUST" + Environment.NewLine;
                        sqlText += "    ,@BALANCEADJUST" + Environment.NewLine;
                        sqlText += "    ,@STOCKTOTALPAYBALANCE" + Environment.NewLine;
                        sqlText += "    ,@STOCKTTL2TMBFBLPAY" + Environment.NewLine;
                        sqlText += "    ,@STOCKTTL3TMBFBLPAY" + Environment.NewLine;
                        sqlText += "    ,@CADDUPUPDEXECDATE" + Environment.NewLine;
                        sqlText += "    ,@STARTCADDUPUPDDATE" + Environment.NewLine;
                        sqlText += "    ,@LASTCADDUPUPDDATE" + Environment.NewLine;
                        sqlText += "    ,@STOCKSLIPCOUNT" + Environment.NewLine;
                        sqlText += "    ,@PAYMENTSCHEDULE" + Environment.NewLine;
                        sqlText += "    ,@PAYMENTCOND" + Environment.NewLine;
                        sqlText += "    ,@SUPPCTAXLAYCD" + Environment.NewLine;
                        sqlText += "    ,@SUPPLIERCONSTAXRATE" + Environment.NewLine;
                        sqlText += "    ,@FRACTIONPROCCD" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        #endregion

                        using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                        // 2008.07.24 upd end -----------------------------------<<
                        {
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)suplierPayWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            #region Parameterオブジェクト作成
                            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                            SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                            SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                            SqlParameter paraPayeeName = sqlCommand.Parameters.Add("@PAYEENAME", SqlDbType.NVarChar);
                            SqlParameter paraPayeeName2 = sqlCommand.Parameters.Add("@PAYEENAME2", SqlDbType.NVarChar);
                            SqlParameter paraPayeeSnm = sqlCommand.Parameters.Add("@PAYEESNM", SqlDbType.NVarChar);
                            SqlParameter paraResultsSectCd = sqlCommand.Parameters.Add("@RESULTSSECTCD", SqlDbType.NChar);
                            SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                            SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                            SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                            SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                            SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                            SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                            SqlParameter paraLastTimePayment = sqlCommand.Parameters.Add("@LASTTIMEPAYMENT", SqlDbType.BigInt);
                            SqlParameter paraThisTimeFeePayNrml = sqlCommand.Parameters.Add("@THISTIMEFEEPAYNRML", SqlDbType.BigInt);
                            SqlParameter paraThisTimeDisPayNrml = sqlCommand.Parameters.Add("@THISTIMEDISPAYNRML", SqlDbType.BigInt);
                            SqlParameter paraThisTimePayNrml = sqlCommand.Parameters.Add("@THISTIMEPAYNRML", SqlDbType.BigInt);
                            SqlParameter paraThisTimeTtlBlcPay = sqlCommand.Parameters.Add("@THISTIMETTLBLCPAY", SqlDbType.BigInt);
                            SqlParameter paraOfsThisTimeStock = sqlCommand.Parameters.Add("@OFSTHISTIMESTOCK", SqlDbType.BigInt);
                            SqlParameter paraOfsThisStockTax = sqlCommand.Parameters.Add("@OFSTHISSTOCKTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedOffsetOutTax = sqlCommand.Parameters.Add("@ITDEDOFFSETOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedOffsetInTax = sqlCommand.Parameters.Add("@ITDEDOFFSETINTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedOffsetTaxFree = sqlCommand.Parameters.Add("@ITDEDOFFSETTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraOffsetOutTax = sqlCommand.Parameters.Add("@OFFSETOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraOffsetInTax = sqlCommand.Parameters.Add("@OFFSETINTAX", SqlDbType.BigInt);
                            SqlParameter paraThisTimeStockPrice = sqlCommand.Parameters.Add("@THISTIMESTOCKPRICE", SqlDbType.BigInt);
                            SqlParameter paraThisStcPrcTax = sqlCommand.Parameters.Add("@THISSTCPRCTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedStcOutTax = sqlCommand.Parameters.Add("@TTLITDEDSTCOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedStcInTax = sqlCommand.Parameters.Add("@TTLITDEDSTCINTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedStcTaxFree = sqlCommand.Parameters.Add("@TTLITDEDSTCTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraTtlStockOuterTax = sqlCommand.Parameters.Add("@TTLSTOCKOUTERTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlStockInnerTax = sqlCommand.Parameters.Add("@TTLSTOCKINNERTAX", SqlDbType.BigInt);
                            SqlParameter paraThisStckPricRgds = sqlCommand.Parameters.Add("@THISSTCKPRICRGDS", SqlDbType.BigInt);
                            SqlParameter paraThisStcPrcTaxRgds = sqlCommand.Parameters.Add("@THISSTCPRCTAXRGDS", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedRetOutTax = sqlCommand.Parameters.Add("@TTLITDEDRETOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedRetInTax = sqlCommand.Parameters.Add("@TTLITDEDRETINTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedRetTaxFree = sqlCommand.Parameters.Add("@TTLITDEDRETTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraTtlRetOuterTax = sqlCommand.Parameters.Add("@TTLRETOUTERTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlRetInnerTax = sqlCommand.Parameters.Add("@TTLRETINNERTAX", SqlDbType.BigInt);
                            SqlParameter paraThisStckPricDis = sqlCommand.Parameters.Add("@THISSTCKPRICDIS", SqlDbType.BigInt);
                            SqlParameter paraThisStcPrcTaxDis = sqlCommand.Parameters.Add("@THISSTCPRCTAXDIS", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedDisOutTax = sqlCommand.Parameters.Add("@TTLITDEDDISOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedDisInTax = sqlCommand.Parameters.Add("@TTLITDEDDISINTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedDisTaxFree = sqlCommand.Parameters.Add("@TTLITDEDDISTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraTtlDisOuterTax = sqlCommand.Parameters.Add("@TTLDISOUTERTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlDisInnerTax = sqlCommand.Parameters.Add("@TTLDISINNERTAX", SqlDbType.BigInt);
                            SqlParameter paraTaxAdjust = sqlCommand.Parameters.Add("@TAXADJUST", SqlDbType.BigInt);
                            SqlParameter paraBalanceAdjust = sqlCommand.Parameters.Add("@BALANCEADJUST", SqlDbType.BigInt);
                            SqlParameter paraStockTotalPayBalance = sqlCommand.Parameters.Add("@STOCKTOTALPAYBALANCE", SqlDbType.BigInt);
                            SqlParameter paraStockTtl2TmBfBlPay = sqlCommand.Parameters.Add("@STOCKTTL2TMBFBLPAY", SqlDbType.BigInt);
                            SqlParameter paraStockTtl3TmBfBlPay = sqlCommand.Parameters.Add("@STOCKTTL3TMBFBLPAY", SqlDbType.BigInt);
                            SqlParameter paraCAddUpUpdExecDate = sqlCommand.Parameters.Add("@CADDUPUPDEXECDATE", SqlDbType.Int);
                            SqlParameter paraStartCAddUpUpdDate = sqlCommand.Parameters.Add("@STARTCADDUPUPDDATE", SqlDbType.Int);
                            SqlParameter paraLastCAddUpUpdDate = sqlCommand.Parameters.Add("@LASTCADDUPUPDDATE", SqlDbType.Int);
                            SqlParameter paraStockSlipCount = sqlCommand.Parameters.Add("@STOCKSLIPCOUNT", SqlDbType.Int);
                            SqlParameter paraPaymentSchedule = sqlCommand.Parameters.Add("@PAYMENTSCHEDULE", SqlDbType.Int);
                            SqlParameter paraPaymentCond = sqlCommand.Parameters.Add("@PAYMENTCOND", SqlDbType.Int);
                            SqlParameter paraSuppCTaxLayCd = sqlCommand.Parameters.Add("@SUPPCTAXLAYCD", SqlDbType.Int);
                            SqlParameter paraSupplierConsTaxRate = sqlCommand.Parameters.Add("@SUPPLIERCONSTAXRATE", SqlDbType.Float);
                            SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                            #endregion

                            #region Parameterオブジェクト設定
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(suplierPayWork.CreateDateTime);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(suplierPayWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(suplierPayWork.FileHeaderGuid);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(suplierPayWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(suplierPayWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.LogicalDeleteCode);
                            paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);
                            paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                            paraPayeeName.Value = SqlDataMediator.SqlSetString(suplierPayWork.PayeeName);
                            paraPayeeName2.Value = SqlDataMediator.SqlSetString(suplierPayWork.PayeeName2);
                            paraPayeeSnm.Value = SqlDataMediator.SqlSetString(suplierPayWork.PayeeSnm);
                            // 未セット項目 >>>
                            paraResultsSectCd.Value = "00";                            
                            paraSupplierCd.Value = 0;
                            paraSupplierNm1.Value = string.Empty;
                            paraSupplierNm2.Value = string.Empty;
                            paraSupplierSnm.Value = string.Empty;
                            // 未セット項目 <<<
                            paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);
                            paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(suplierPayWork.AddUpYearMonth);
                            paraLastTimePayment.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.LastTimePayment);
                            paraThisTimeFeePayNrml.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisTimeFeePayNrml);
                            paraThisTimeDisPayNrml.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisTimeDisPayNrml);
                            paraThisTimePayNrml.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisTimePayNrml);
                            paraThisTimeTtlBlcPay.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisTimeTtlBlcPay);
                            paraOfsThisTimeStock.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.OfsThisTimeStock);
                            paraOfsThisStockTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.OfsThisStockTax);
                            paraItdedOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ItdedOffsetOutTax);
                            paraItdedOffsetInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ItdedOffsetInTax);
                            paraItdedOffsetTaxFree.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ItdedOffsetTaxFree);
                            paraOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.OffsetOutTax);
                            paraOffsetInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.OffsetInTax);
                            paraThisTimeStockPrice.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisTimeStockPrice);
                            paraThisStcPrcTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStcPrcTax);
                            paraTtlItdedStcOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedStcOutTax);
                            paraTtlItdedStcInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedStcInTax);
                            paraTtlItdedStcTaxFree.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedStcTaxFree);
                            paraTtlStockOuterTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlStockOuterTax);
                            paraTtlStockInnerTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlStockInnerTax);
                            paraThisStckPricRgds.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStckPricRgds);
                            paraThisStcPrcTaxRgds.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStcPrcTaxRgds);
                            paraTtlItdedRetOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedRetOutTax);
                            paraTtlItdedRetInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedRetInTax);
                            paraTtlItdedRetTaxFree.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedRetTaxFree);
                            paraTtlRetOuterTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlRetOuterTax);
                            paraTtlRetInnerTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlRetInnerTax);
                            paraThisStckPricDis.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStckPricDis);
                            paraThisStcPrcTaxDis.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStcPrcTaxDis);
                            paraTtlItdedDisOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedDisOutTax);
                            paraTtlItdedDisInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedDisInTax);
                            paraTtlItdedDisTaxFree.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedDisTaxFree);
                            paraTtlDisOuterTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlDisOuterTax);
                            paraTtlDisInnerTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlDisInnerTax);
                            // 未セット項目 >>>
                            paraTaxAdjust.Value = 0;
                            paraBalanceAdjust.Value = 0;
                            // 未セット項目 <<<
                            paraStockTotalPayBalance.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.StockTotalPayBalance);
                            paraStockTtl2TmBfBlPay.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.StockTtl2TmBfBlPay);
                            paraStockTtl3TmBfBlPay.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.StockTtl3TmBfBlPay);
                            paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.CAddUpUpdExecDate);
                            paraStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.StartCAddUpUpdDate);
                            paraLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.LastCAddUpUpdDate);
                            paraStockSlipCount.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.StockSlipCount);
                            paraPaymentSchedule.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.PaymentSchedule);
                            paraPaymentCond.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PaymentCond);
                            paraSuppCTaxLayCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SuppCTaxLayCd);
                            paraSupplierConsTaxRate.Value = SqlDataMediator.SqlSetDouble(suplierPayWork.SupplierConsTaxRate);
                            paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.FractionProcCd);
                            #endregion

                            sqlCommand.ExecuteNonQuery();
                        }
                        // ↑ 2007.12.07 980081 c

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                // ↓ 2007.09.14 980081 a 支払先子レコード作成対応
                for (int i = 0; i < suplierPayChildWorkList.Count; i++)
                {
                    SuplierPayWork suplierPayWork = new SuplierPayWork(); 
                    suplierPayWork = suplierPayChildWorkList[i] as SuplierPayWork;
                    if (suplierPayWork.UpdateStatus == 0)
                    {
                        // 2008.07.24 upd start --------------------------------->>
                        //using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO SUPLIERPAYRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPSECCODERF, PAYEECODERF, PAYEENAMERF, PAYEENAME2RF, PAYEESNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, ADDUPDATERF, ADDUPYEARMONTHRF, LASTTIMEPAYMENTRF, THISTIMEFEEPAYNRMLRF, THISTIMEDISPAYNRMLRF, THISTIMEPAYNRMLRF, THISTIMETTLBLCPAYRF, OFSTHISTIMESTOCKRF, OFSTHISSTOCKTAXRF, ITDEDOFFSETOUTTAXRF, ITDEDOFFSETINTAXRF, ITDEDOFFSETTAXFREERF, OFFSETOUTTAXRF, OFFSETINTAXRF, THISTIMESTOCKPRICERF, THISSTCPRCTAXRF, TTLITDEDSTCOUTTAXRF, TTLITDEDSTCINTAXRF, TTLITDEDSTCTAXFREERF, TTLSTOCKOUTERTAXRF, TTLSTOCKINNERTAXRF, THISSTCKPRICRGDSRF, THISSTCPRCTAXRGDSRF, TTLITDEDRETOUTTAXRF, TTLITDEDRETINTAXRF, TTLITDEDRETTAXFREERF, TTLRETOUTERTAXRF, TTLRETINNERTAXRF, THISSTCKPRICDISRF, THISSTCPRCTAXDISRF, TTLITDEDDISOUTTAXRF, TTLITDEDDISINTAXRF, TTLITDEDDISTAXFREERF, TTLDISOUTERTAXRF, TTLDISINNERTAXRF, THISRECVOFFSETRF, THISRECVOFFSETTAXRF, THISRECVOUTTAXRF, THISRECVINTAXRF, THISRECVTAXFREERF, THISRECVOUTERTAXRF, THISRECVINNERTAXRF, TAXADJUSTRF, BALANCEADJUSTRF, STOCKTOTALPAYBALANCERF, STOCKTTL2TMBFBLPAYRF, STOCKTTL3TMBFBLPAYRF, CADDUPUPDEXECDATERF, STARTCADDUPUPDDATERF, LASTCADDUPUPDDATERF, STOCKSLIPCOUNTRF, PAYMENTSCHEDULERF, PAYMENTCONDRF, SUPPCTAXLAYCDRF, SUPPLIERCONSTAXRATERF, FRACTIONPROCCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ADDUPSECCODE, @PAYEECODE, @PAYEENAME, @PAYEENAME2, @PAYEESNM, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @CUSTOMERSNM, @ADDUPDATE, @ADDUPYEARMONTH, @LASTTIMEPAYMENT, @THISTIMEFEEPAYNRML, @THISTIMEDISPAYNRML, @THISTIMEPAYNRML, @THISTIMETTLBLCPAY, @OFSTHISTIMESTOCK, @OfsThisStockTax, @ITDEDOFFSETOUTTAX, @ITDEDOFFSETINTAX, @ITDEDOFFSETTAXFREE, @OFFSETOUTTAX, @OFFSETINTAX, @THISTIMESTOCKPRICE, @THISSTCPRCTAX, @TTLITDEDSTCOUTTAX, @TTLITDEDSTCINTAX, @TTLITDEDSTCTAXFREE, @TTLSTOCKOUTERTAX, @TTLSTOCKINNERTAX, @THISSTCKPRICRGDS, @THISSTCPRCTAXRGDS, @TTLITDEDRETOUTTAX, @TTLITDEDRETINTAX, @TTLITDEDRETTAXFREE, @TTLRETOUTERTAX, @TTLRETINNERTAX, @THISSTCKPRICDIS, @THISSTCPRCTAXDIS, @TTLITDEDDISOUTTAX, @TTLITDEDDISINTAX, @TTLITDEDDISTAXFREE, @TTLDISOUTERTAX, @TTLDISINNERTAX, @THISRECVOFFSET, @THISRECVOFFSETTAX, @THISRECVOUTTAX, @THISRECVINTAX, @THISRECVTAXFREE, @THISRECVOUTERTAX, @THISRECVINNERTAX, @TAXADJUST, @BALANCEADJUST, @STOCKTOTALPAYBALANCE, @STOCKTTL2TMBFBLPAY, @STOCKTTL3TMBFBLPAY, @CADDUPUPDEXECDATE, @STARTCADDUPUPDDATE, @LASTCADDUPUPDDATE, @STOCKSLIPCOUNT, @PAYMENTSCHEDULE, @PAYMENTCOND, @SUPPCTAXLAYCD, @SUPPLIERCONSTAXRATE, @FRACTIONPROCCD)", sqlConnection, sqlTransaction))

                        #region INSERT文作成
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO SUPLIERPAYRF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "    ,ADDUPSECCODERF" + Environment.NewLine;
                        sqlText += "    ,PAYEECODERF" + Environment.NewLine;
                        sqlText += "    ,PAYEENAMERF" + Environment.NewLine;
                        sqlText += "    ,PAYEENAME2RF" + Environment.NewLine;
                        sqlText += "    ,PAYEESNMRF" + Environment.NewLine;
                        sqlText += "    ,RESULTSSECTCDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERCDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNM1RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNM2RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERSNMRF" + Environment.NewLine;
                        sqlText += "    ,ADDUPDATERF" + Environment.NewLine;
                        sqlText += "    ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        sqlText += "    ,LASTTIMEPAYMENTRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMEFEEPAYNRMLRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMEDISPAYNRMLRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMEPAYNRMLRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMETTLBLCPAYRF" + Environment.NewLine;
                        sqlText += "    ,OFSTHISTIMESTOCKRF" + Environment.NewLine;
                        sqlText += "    ,OFSTHISSTOCKTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDOFFSETINTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,OFFSETOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,OFFSETINTAXRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMESTOCKPRICERF" + Environment.NewLine;
                        sqlText += "    ,THISSTCPRCTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDSTCOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDSTCINTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDSTCTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,TTLSTOCKOUTERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLSTOCKINNERTAXRF" + Environment.NewLine;
                        sqlText += "    ,THISSTCKPRICRGDSRF" + Environment.NewLine;
                        sqlText += "    ,THISSTCPRCTAXRGDSRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDRETINTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDRETTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,TTLRETOUTERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLRETINNERTAXRF" + Environment.NewLine;
                        sqlText += "    ,THISSTCKPRICDISRF" + Environment.NewLine;
                        sqlText += "    ,THISSTCPRCTAXDISRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDDISINTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDDISTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,TTLDISOUTERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLDISINNERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TAXADJUSTRF" + Environment.NewLine;
                        sqlText += "    ,BALANCEADJUSTRF" + Environment.NewLine;
                        sqlText += "    ,STOCKTOTALPAYBALANCERF" + Environment.NewLine;
                        sqlText += "    ,STOCKTTL2TMBFBLPAYRF" + Environment.NewLine;
                        sqlText += "    ,STOCKTTL3TMBFBLPAYRF" + Environment.NewLine;
                        sqlText += "    ,CADDUPUPDEXECDATERF" + Environment.NewLine;
                        sqlText += "    ,STARTCADDUPUPDDATERF" + Environment.NewLine;
                        sqlText += "    ,LASTCADDUPUPDDATERF" + Environment.NewLine;
                        sqlText += "    ,STOCKSLIPCOUNTRF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTSCHEDULERF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTCONDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPCTAXLAYCDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                        sqlText += "    ,FRACTIONPROCCDRF" + Environment.NewLine;
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
                        sqlText += "    ,@ADDUPSECCODE" + Environment.NewLine;
                        sqlText += "    ,@PAYEECODE" + Environment.NewLine;
                        sqlText += "    ,@PAYEENAME" + Environment.NewLine;
                        sqlText += "    ,@PAYEENAME2" + Environment.NewLine;
                        sqlText += "    ,@PAYEESNM" + Environment.NewLine;
                        sqlText += "    ,@RESULTSSECTCD" + Environment.NewLine;
                        sqlText += "    ,@SUPPLIERCD" + Environment.NewLine;
                        sqlText += "    ,@SUPPLIERNM1" + Environment.NewLine;
                        sqlText += "    ,@SUPPLIERNM2" + Environment.NewLine;
                        sqlText += "    ,@SUPPLIERSNM" + Environment.NewLine;
                        sqlText += "    ,@ADDUPDATE" + Environment.NewLine;
                        sqlText += "    ,@ADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += "    ,@LASTTIMEPAYMENT" + Environment.NewLine;
                        sqlText += "    ,@THISTIMEFEEPAYNRML" + Environment.NewLine;
                        sqlText += "    ,@THISTIMEDISPAYNRML" + Environment.NewLine;
                        sqlText += "    ,@THISTIMEPAYNRML" + Environment.NewLine;
                        sqlText += "    ,@THISTIMETTLBLCPAY" + Environment.NewLine;
                        sqlText += "    ,@OFSTHISTIMESTOCK" + Environment.NewLine;
                        sqlText += "    ,@OFSTHISSTOCKTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDOFFSETINTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@OFFSETOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@OFFSETINTAX" + Environment.NewLine;
                        sqlText += "    ,@THISTIMESTOCKPRICE" + Environment.NewLine;
                        sqlText += "    ,@THISSTCPRCTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDSTCOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDSTCINTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDSTCTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@TTLSTOCKOUTERTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLSTOCKINNERTAX" + Environment.NewLine;
                        sqlText += "    ,@THISSTCKPRICRGDS" + Environment.NewLine;
                        sqlText += "    ,@THISSTCPRCTAXRGDS" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDRETINTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@TTLRETOUTERTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLRETINNERTAX" + Environment.NewLine;
                        sqlText += "    ,@THISSTCKPRICDIS" + Environment.NewLine;
                        sqlText += "    ,@THISSTCPRCTAXDIS" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDDISINTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@TTLDISOUTERTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLDISINNERTAX" + Environment.NewLine;
                        sqlText += "    ,@TAXADJUST" + Environment.NewLine;
                        sqlText += "    ,@BALANCEADJUST" + Environment.NewLine;
                        sqlText += "    ,@STOCKTOTALPAYBALANCE" + Environment.NewLine;
                        sqlText += "    ,@STOCKTTL2TMBFBLPAY" + Environment.NewLine;
                        sqlText += "    ,@STOCKTTL3TMBFBLPAY" + Environment.NewLine;
                        sqlText += "    ,@CADDUPUPDEXECDATE" + Environment.NewLine;
                        sqlText += "    ,@STARTCADDUPUPDDATE" + Environment.NewLine;
                        sqlText += "    ,@LASTCADDUPUPDDATE" + Environment.NewLine;
                        sqlText += "    ,@STOCKSLIPCOUNT" + Environment.NewLine;
                        sqlText += "    ,@PAYMENTSCHEDULE" + Environment.NewLine;
                        sqlText += "    ,@PAYMENTCOND" + Environment.NewLine;
                        sqlText += "    ,@SUPPCTAXLAYCD" + Environment.NewLine;
                        sqlText += "    ,@SUPPLIERCONSTAXRATE" + Environment.NewLine;
                        sqlText += "    ,@FRACTIONPROCCD" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        #endregion

                        using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                        // 2008.07.24 upd end -----------------------------------<<
                        {
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)suplierPayWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            #region Parameterオブジェクト作成
                            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                            SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                            SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                            SqlParameter paraPayeeName = sqlCommand.Parameters.Add("@PAYEENAME", SqlDbType.NVarChar);
                            SqlParameter paraPayeeName2 = sqlCommand.Parameters.Add("@PAYEENAME2", SqlDbType.NVarChar);
                            SqlParameter paraPayeeSnm = sqlCommand.Parameters.Add("@PAYEESNM", SqlDbType.NVarChar);
                            SqlParameter paraResultsSectCd = sqlCommand.Parameters.Add("@RESULTSSECTCD", SqlDbType.NChar);
                            SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                            SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                            SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                            SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                            SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                            SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                            SqlParameter paraLastTimePayment = sqlCommand.Parameters.Add("@LASTTIMEPAYMENT", SqlDbType.BigInt);
                            SqlParameter paraThisTimeFeePayNrml = sqlCommand.Parameters.Add("@THISTIMEFEEPAYNRML", SqlDbType.BigInt);
                            SqlParameter paraThisTimeDisPayNrml = sqlCommand.Parameters.Add("@THISTIMEDISPAYNRML", SqlDbType.BigInt);
                            SqlParameter paraThisTimePayNrml = sqlCommand.Parameters.Add("@THISTIMEPAYNRML", SqlDbType.BigInt);
                            SqlParameter paraThisTimeTtlBlcPay = sqlCommand.Parameters.Add("@THISTIMETTLBLCPAY", SqlDbType.BigInt);
                            SqlParameter paraOfsThisTimeStock = sqlCommand.Parameters.Add("@OFSTHISTIMESTOCK", SqlDbType.BigInt);
                            SqlParameter paraOfsThisStockTax = sqlCommand.Parameters.Add("@OFSTHISSTOCKTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedOffsetOutTax = sqlCommand.Parameters.Add("@ITDEDOFFSETOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedOffsetInTax = sqlCommand.Parameters.Add("@ITDEDOFFSETINTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedOffsetTaxFree = sqlCommand.Parameters.Add("@ITDEDOFFSETTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraOffsetOutTax = sqlCommand.Parameters.Add("@OFFSETOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraOffsetInTax = sqlCommand.Parameters.Add("@OFFSETINTAX", SqlDbType.BigInt);
                            SqlParameter paraThisTimeStockPrice = sqlCommand.Parameters.Add("@THISTIMESTOCKPRICE", SqlDbType.BigInt);
                            SqlParameter paraThisStcPrcTax = sqlCommand.Parameters.Add("@THISSTCPRCTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedStcOutTax = sqlCommand.Parameters.Add("@TTLITDEDSTCOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedStcInTax = sqlCommand.Parameters.Add("@TTLITDEDSTCINTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedStcTaxFree = sqlCommand.Parameters.Add("@TTLITDEDSTCTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraTtlStockOuterTax = sqlCommand.Parameters.Add("@TTLSTOCKOUTERTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlStockInnerTax = sqlCommand.Parameters.Add("@TTLSTOCKINNERTAX", SqlDbType.BigInt);
                            SqlParameter paraThisStckPricRgds = sqlCommand.Parameters.Add("@THISSTCKPRICRGDS", SqlDbType.BigInt);
                            SqlParameter paraThisStcPrcTaxRgds = sqlCommand.Parameters.Add("@THISSTCPRCTAXRGDS", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedRetOutTax = sqlCommand.Parameters.Add("@TTLITDEDRETOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedRetInTax = sqlCommand.Parameters.Add("@TTLITDEDRETINTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedRetTaxFree = sqlCommand.Parameters.Add("@TTLITDEDRETTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraTtlRetOuterTax = sqlCommand.Parameters.Add("@TTLRETOUTERTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlRetInnerTax = sqlCommand.Parameters.Add("@TTLRETINNERTAX", SqlDbType.BigInt);
                            SqlParameter paraThisStckPricDis = sqlCommand.Parameters.Add("@THISSTCKPRICDIS", SqlDbType.BigInt);
                            SqlParameter paraThisStcPrcTaxDis = sqlCommand.Parameters.Add("@THISSTCPRCTAXDIS", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedDisOutTax = sqlCommand.Parameters.Add("@TTLITDEDDISOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedDisInTax = sqlCommand.Parameters.Add("@TTLITDEDDISINTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedDisTaxFree = sqlCommand.Parameters.Add("@TTLITDEDDISTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraTtlDisOuterTax = sqlCommand.Parameters.Add("@TTLDISOUTERTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlDisInnerTax = sqlCommand.Parameters.Add("@TTLDISINNERTAX", SqlDbType.BigInt);
                            SqlParameter paraTaxAdjust = sqlCommand.Parameters.Add("@TAXADJUST", SqlDbType.BigInt);
                            SqlParameter paraBalanceAdjust = sqlCommand.Parameters.Add("@BALANCEADJUST", SqlDbType.BigInt);
                            SqlParameter paraStockTotalPayBalance = sqlCommand.Parameters.Add("@STOCKTOTALPAYBALANCE", SqlDbType.BigInt);
                            SqlParameter paraStockTtl2TmBfBlPay = sqlCommand.Parameters.Add("@STOCKTTL2TMBFBLPAY", SqlDbType.BigInt);
                            SqlParameter paraStockTtl3TmBfBlPay = sqlCommand.Parameters.Add("@STOCKTTL3TMBFBLPAY", SqlDbType.BigInt);
                            SqlParameter paraCAddUpUpdExecDate = sqlCommand.Parameters.Add("@CADDUPUPDEXECDATE", SqlDbType.Int);
                            SqlParameter paraStartCAddUpUpdDate = sqlCommand.Parameters.Add("@STARTCADDUPUPDDATE", SqlDbType.Int);
                            SqlParameter paraLastCAddUpUpdDate = sqlCommand.Parameters.Add("@LASTCADDUPUPDDATE", SqlDbType.Int);
                            SqlParameter paraStockSlipCount = sqlCommand.Parameters.Add("@STOCKSLIPCOUNT", SqlDbType.Int);
                            SqlParameter paraPaymentSchedule = sqlCommand.Parameters.Add("@PAYMENTSCHEDULE", SqlDbType.Int);
                            SqlParameter paraPaymentCond = sqlCommand.Parameters.Add("@PAYMENTCOND", SqlDbType.Int);
                            SqlParameter paraSuppCTaxLayCd = sqlCommand.Parameters.Add("@SUPPCTAXLAYCD", SqlDbType.Int);
                            SqlParameter paraSupplierConsTaxRate = sqlCommand.Parameters.Add("@SUPPLIERCONSTAXRATE", SqlDbType.Float);
                            SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                            #endregion

                            #region Parameterオブジェクト設定
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(suplierPayWork.CreateDateTime);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(suplierPayWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(suplierPayWork.FileHeaderGuid);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(suplierPayWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(suplierPayWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.LogicalDeleteCode);
                            paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);
                            paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                            paraPayeeName.Value = SqlDataMediator.SqlSetString(suplierPayWork.PayeeName);
                            paraPayeeName2.Value = SqlDataMediator.SqlSetString(suplierPayWork.PayeeName2);
                            paraPayeeSnm.Value = SqlDataMediator.SqlSetString(suplierPayWork.PayeeSnm);
                            if (suplierPayWork.ResultsSectCd == string.Empty)
                            {
                                paraResultsSectCd.Value = string.Empty;
                            }
                            else
                            {
                                paraResultsSectCd.Value = SqlDataMediator.SqlSetString(suplierPayWork.ResultsSectCd);
                            }
                            paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SupplierCd);
                            paraSupplierNm1.Value = SqlDataMediator.SqlSetString(suplierPayWork.SupplierNm1);
                            paraSupplierNm2.Value = SqlDataMediator.SqlSetString(suplierPayWork.SupplierNm2);
                            paraSupplierSnm.Value = SqlDataMediator.SqlSetString(suplierPayWork.SupplierSnm);
                            paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);
                            paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(suplierPayWork.AddUpYearMonth);
                            // 未セット項目 >>>
                            paraLastTimePayment.Value = 0;
                            paraThisTimeFeePayNrml.Value = 0;
                            paraThisTimeDisPayNrml.Value = 0;
                            paraThisTimePayNrml.Value = 0;
                            paraThisTimeTtlBlcPay.Value = 0;
                            // 未セット項目 <<<
                            paraOfsThisTimeStock.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.OfsThisTimeStock);
                            paraOfsThisStockTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.OfsThisStockTax);
                            paraItdedOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ItdedOffsetOutTax);
                            paraItdedOffsetInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ItdedOffsetInTax);
                            paraItdedOffsetTaxFree.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ItdedOffsetTaxFree);
                            paraOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.OffsetOutTax);
                            paraOffsetInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.OffsetInTax);
                            paraThisTimeStockPrice.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisTimeStockPrice);
                            paraThisStcPrcTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStcPrcTax);
                            paraTtlItdedStcOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedStcOutTax);
                            paraTtlItdedStcInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedStcInTax);
                            paraTtlItdedStcTaxFree.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedStcTaxFree);
                            paraTtlStockOuterTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlStockOuterTax);
                            paraTtlStockInnerTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlStockInnerTax);
                            paraThisStckPricRgds.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStckPricRgds);
                            paraThisStcPrcTaxRgds.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStcPrcTaxRgds);
                            paraTtlItdedRetOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedRetOutTax);
                            paraTtlItdedRetInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedRetInTax);
                            paraTtlItdedRetTaxFree.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedRetTaxFree);
                            paraTtlRetOuterTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlRetOuterTax);
                            paraTtlRetInnerTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlRetInnerTax);
                            paraThisStckPricDis.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStckPricDis);
                            paraThisStcPrcTaxDis.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStcPrcTaxDis);
                            paraTtlItdedDisOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedDisOutTax);
                            paraTtlItdedDisInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedDisInTax);
                            paraTtlItdedDisTaxFree.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedDisTaxFree);
                            paraTtlDisOuterTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlDisOuterTax);
                            paraTtlDisInnerTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlDisInnerTax);
                            // 未セット項目 >>>
                            paraTaxAdjust.Value = 0;
                            paraBalanceAdjust.Value = 0;
                            paraStockTotalPayBalance.Value = 0;
                            paraStockTtl2TmBfBlPay.Value = 0;
                            paraStockTtl3TmBfBlPay.Value = 0;
                            // 未セット項目 <<<
                            paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.CAddUpUpdExecDate);
                            paraStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.StartCAddUpUpdDate);
                            paraLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.LastCAddUpUpdDate);
                            paraStockSlipCount.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.StockSlipCount);
                            paraPaymentSchedule.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.PaymentSchedule);
                            paraPaymentCond.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PaymentCond);
                            paraSuppCTaxLayCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SuppCTaxLayCd);
                            paraSupplierConsTaxRate.Value = SqlDataMediator.SqlSetDouble(suplierPayWork.SupplierConsTaxRate);
                            paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.FractionProcCd);
                            #endregion

                            sqlCommand.ExecuteNonQuery();
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                // ↑ 2007.09.14 980081 a
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }

        // --- ADD 2012/09/11 ----------->>>>>
        /// <summary>
        /// 仕入先支払金額マスタのレコードを仕入総括形式で更新します
        /// </summary>
        /// <param name="suplierPayWorkList">仕入先支払金額マスタList</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額マスタの仕入総括形式で更新します</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : 2012/09/11</br>
        /// </remarks>
        private int WriteSuplierPay(ref ArrayList suplierPayWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            string sqlText = string.Empty;

            //Deleteコマンドの生成
            try
            {
                for (int i = 0; i < suplierPayWorkList.Count; i++)
                {
                    SuplierPayWork suplierPayWork = suplierPayWorkList[i] as SuplierPayWork;
                    if (suplierPayWork.UpdateStatus == 0)
                    {
                        sqlText = string.Empty;
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += " FROM SUPLIERPAYRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                        sqlText += "    AND PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                        sqlText += "    AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;
                        using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                        {
                            //Prameterオブジェクトの作成
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                            SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                            SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                            findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);
                            findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                            findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);

                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    if (suplierPayWork.UpdateStatus == 0 && suplierPayWork.CAddUpUpdExecDate != DateTime.MinValue)
                    {
                        #region INSERT文作成
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO SUPLIERPAYRF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "    ,ADDUPSECCODERF" + Environment.NewLine;
                        sqlText += "    ,PAYEECODERF" + Environment.NewLine;
                        sqlText += "    ,PAYEENAMERF" + Environment.NewLine;
                        sqlText += "    ,PAYEENAME2RF" + Environment.NewLine;
                        sqlText += "    ,PAYEESNMRF" + Environment.NewLine;
                        sqlText += "    ,RESULTSSECTCDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERCDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNM1RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNM2RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERSNMRF" + Environment.NewLine;
                        sqlText += "    ,ADDUPDATERF" + Environment.NewLine;
                        sqlText += "    ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        sqlText += "    ,LASTTIMEPAYMENTRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMEFEEPAYNRMLRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMEDISPAYNRMLRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMEPAYNRMLRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMETTLBLCPAYRF" + Environment.NewLine;
                        sqlText += "    ,OFSTHISTIMESTOCKRF" + Environment.NewLine;
                        sqlText += "    ,OFSTHISSTOCKTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDOFFSETINTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,OFFSETOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,OFFSETINTAXRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMESTOCKPRICERF" + Environment.NewLine;
                        sqlText += "    ,THISSTCPRCTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDSTCOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDSTCINTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDSTCTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,TTLSTOCKOUTERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLSTOCKINNERTAXRF" + Environment.NewLine;
                        sqlText += "    ,THISSTCKPRICRGDSRF" + Environment.NewLine;
                        sqlText += "    ,THISSTCPRCTAXRGDSRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDRETINTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDRETTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,TTLRETOUTERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLRETINNERTAXRF" + Environment.NewLine;
                        sqlText += "    ,THISSTCKPRICDISRF" + Environment.NewLine;
                        sqlText += "    ,THISSTCPRCTAXDISRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDDISINTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDDISTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,TTLDISOUTERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLDISINNERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TAXADJUSTRF" + Environment.NewLine;
                        sqlText += "    ,BALANCEADJUSTRF" + Environment.NewLine;
                        sqlText += "    ,STOCKTOTALPAYBALANCERF" + Environment.NewLine;
                        sqlText += "    ,STOCKTTL2TMBFBLPAYRF" + Environment.NewLine;
                        sqlText += "    ,STOCKTTL3TMBFBLPAYRF" + Environment.NewLine;
                        sqlText += "    ,CADDUPUPDEXECDATERF" + Environment.NewLine;
                        sqlText += "    ,STARTCADDUPUPDDATERF" + Environment.NewLine;
                        sqlText += "    ,LASTCADDUPUPDDATERF" + Environment.NewLine;
                        sqlText += "    ,STOCKSLIPCOUNTRF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTSCHEDULERF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTCONDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPCTAXLAYCDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                        sqlText += "    ,FRACTIONPROCCDRF" + Environment.NewLine;
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
                        sqlText += "    ,@ADDUPSECCODE" + Environment.NewLine;
                        sqlText += "    ,@PAYEECODE" + Environment.NewLine;
                        sqlText += "    ,@PAYEENAME" + Environment.NewLine;
                        sqlText += "    ,@PAYEENAME2" + Environment.NewLine;
                        sqlText += "    ,@PAYEESNM" + Environment.NewLine;
                        sqlText += "    ,@RESULTSSECTCD" + Environment.NewLine;
                        sqlText += "    ,@SUPPLIERCD" + Environment.NewLine;
                        sqlText += "    ,@SUPPLIERNM1" + Environment.NewLine;
                        sqlText += "    ,@SUPPLIERNM2" + Environment.NewLine;
                        sqlText += "    ,@SUPPLIERSNM" + Environment.NewLine;
                        sqlText += "    ,@ADDUPDATE" + Environment.NewLine;
                        sqlText += "    ,@ADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += "    ,@LASTTIMEPAYMENT" + Environment.NewLine;
                        sqlText += "    ,@THISTIMEFEEPAYNRML" + Environment.NewLine;
                        sqlText += "    ,@THISTIMEDISPAYNRML" + Environment.NewLine;
                        sqlText += "    ,@THISTIMEPAYNRML" + Environment.NewLine;
                        sqlText += "    ,@THISTIMETTLBLCPAY" + Environment.NewLine;
                        sqlText += "    ,@OFSTHISTIMESTOCK" + Environment.NewLine;
                        sqlText += "    ,@OFSTHISSTOCKTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDOFFSETINTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@OFFSETOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@OFFSETINTAX" + Environment.NewLine;
                        sqlText += "    ,@THISTIMESTOCKPRICE" + Environment.NewLine;
                        sqlText += "    ,@THISSTCPRCTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDSTCOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDSTCINTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDSTCTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@TTLSTOCKOUTERTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLSTOCKINNERTAX" + Environment.NewLine;
                        sqlText += "    ,@THISSTCKPRICRGDS" + Environment.NewLine;
                        sqlText += "    ,@THISSTCPRCTAXRGDS" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDRETINTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@TTLRETOUTERTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLRETINNERTAX" + Environment.NewLine;
                        sqlText += "    ,@THISSTCKPRICDIS" + Environment.NewLine;
                        sqlText += "    ,@THISSTCPRCTAXDIS" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDDISINTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@TTLDISOUTERTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLDISINNERTAX" + Environment.NewLine;
                        sqlText += "    ,@TAXADJUST" + Environment.NewLine;
                        sqlText += "    ,@BALANCEADJUST" + Environment.NewLine;
                        sqlText += "    ,@STOCKTOTALPAYBALANCE" + Environment.NewLine;
                        sqlText += "    ,@STOCKTTL2TMBFBLPAY" + Environment.NewLine;
                        sqlText += "    ,@STOCKTTL3TMBFBLPAY" + Environment.NewLine;
                        sqlText += "    ,@CADDUPUPDEXECDATE" + Environment.NewLine;
                        sqlText += "    ,@STARTCADDUPUPDDATE" + Environment.NewLine;
                        sqlText += "    ,@LASTCADDUPUPDDATE" + Environment.NewLine;
                        sqlText += "    ,@STOCKSLIPCOUNT" + Environment.NewLine;
                        sqlText += "    ,@PAYMENTSCHEDULE" + Environment.NewLine;
                        sqlText += "    ,@PAYMENTCOND" + Environment.NewLine;
                        sqlText += "    ,@SUPPCTAXLAYCD" + Environment.NewLine;
                        sqlText += "    ,@SUPPLIERCONSTAXRATE" + Environment.NewLine;
                        sqlText += "    ,@FRACTIONPROCCD" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        #endregion

                        using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                        {
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)suplierPayWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            //集計レコード

                            #region Parameterオブジェクト作成
                            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                            SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                            SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                            SqlParameter paraPayeeName = sqlCommand.Parameters.Add("@PAYEENAME", SqlDbType.NVarChar);
                            SqlParameter paraPayeeName2 = sqlCommand.Parameters.Add("@PAYEENAME2", SqlDbType.NVarChar);
                            SqlParameter paraPayeeSnm = sqlCommand.Parameters.Add("@PAYEESNM", SqlDbType.NVarChar);
                            SqlParameter paraResultsSectCd = sqlCommand.Parameters.Add("@RESULTSSECTCD", SqlDbType.NChar);
                            SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                            SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                            SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                            SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                            SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                            SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                            SqlParameter paraLastTimePayment = sqlCommand.Parameters.Add("@LASTTIMEPAYMENT", SqlDbType.BigInt);
                            SqlParameter paraThisTimeFeePayNrml = sqlCommand.Parameters.Add("@THISTIMEFEEPAYNRML", SqlDbType.BigInt);
                            SqlParameter paraThisTimeDisPayNrml = sqlCommand.Parameters.Add("@THISTIMEDISPAYNRML", SqlDbType.BigInt);
                            SqlParameter paraThisTimePayNrml = sqlCommand.Parameters.Add("@THISTIMEPAYNRML", SqlDbType.BigInt);
                            SqlParameter paraThisTimeTtlBlcPay = sqlCommand.Parameters.Add("@THISTIMETTLBLCPAY", SqlDbType.BigInt);
                            SqlParameter paraOfsThisTimeStock = sqlCommand.Parameters.Add("@OFSTHISTIMESTOCK", SqlDbType.BigInt);
                            SqlParameter paraOfsThisStockTax = sqlCommand.Parameters.Add("@OFSTHISSTOCKTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedOffsetOutTax = sqlCommand.Parameters.Add("@ITDEDOFFSETOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedOffsetInTax = sqlCommand.Parameters.Add("@ITDEDOFFSETINTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedOffsetTaxFree = sqlCommand.Parameters.Add("@ITDEDOFFSETTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraOffsetOutTax = sqlCommand.Parameters.Add("@OFFSETOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraOffsetInTax = sqlCommand.Parameters.Add("@OFFSETINTAX", SqlDbType.BigInt);
                            SqlParameter paraThisTimeStockPrice = sqlCommand.Parameters.Add("@THISTIMESTOCKPRICE", SqlDbType.BigInt);
                            SqlParameter paraThisStcPrcTax = sqlCommand.Parameters.Add("@THISSTCPRCTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedStcOutTax = sqlCommand.Parameters.Add("@TTLITDEDSTCOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedStcInTax = sqlCommand.Parameters.Add("@TTLITDEDSTCINTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedStcTaxFree = sqlCommand.Parameters.Add("@TTLITDEDSTCTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraTtlStockOuterTax = sqlCommand.Parameters.Add("@TTLSTOCKOUTERTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlStockInnerTax = sqlCommand.Parameters.Add("@TTLSTOCKINNERTAX", SqlDbType.BigInt);
                            SqlParameter paraThisStckPricRgds = sqlCommand.Parameters.Add("@THISSTCKPRICRGDS", SqlDbType.BigInt);
                            SqlParameter paraThisStcPrcTaxRgds = sqlCommand.Parameters.Add("@THISSTCPRCTAXRGDS", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedRetOutTax = sqlCommand.Parameters.Add("@TTLITDEDRETOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedRetInTax = sqlCommand.Parameters.Add("@TTLITDEDRETINTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedRetTaxFree = sqlCommand.Parameters.Add("@TTLITDEDRETTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraTtlRetOuterTax = sqlCommand.Parameters.Add("@TTLRETOUTERTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlRetInnerTax = sqlCommand.Parameters.Add("@TTLRETINNERTAX", SqlDbType.BigInt);
                            SqlParameter paraThisStckPricDis = sqlCommand.Parameters.Add("@THISSTCKPRICDIS", SqlDbType.BigInt);
                            SqlParameter paraThisStcPrcTaxDis = sqlCommand.Parameters.Add("@THISSTCPRCTAXDIS", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedDisOutTax = sqlCommand.Parameters.Add("@TTLITDEDDISOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedDisInTax = sqlCommand.Parameters.Add("@TTLITDEDDISINTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedDisTaxFree = sqlCommand.Parameters.Add("@TTLITDEDDISTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraTtlDisOuterTax = sqlCommand.Parameters.Add("@TTLDISOUTERTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlDisInnerTax = sqlCommand.Parameters.Add("@TTLDISINNERTAX", SqlDbType.BigInt);
                            SqlParameter paraTaxAdjust = sqlCommand.Parameters.Add("@TAXADJUST", SqlDbType.BigInt);
                            SqlParameter paraBalanceAdjust = sqlCommand.Parameters.Add("@BALANCEADJUST", SqlDbType.BigInt);
                            SqlParameter paraStockTotalPayBalance = sqlCommand.Parameters.Add("@STOCKTOTALPAYBALANCE", SqlDbType.BigInt);
                            SqlParameter paraStockTtl2TmBfBlPay = sqlCommand.Parameters.Add("@STOCKTTL2TMBFBLPAY", SqlDbType.BigInt);
                            SqlParameter paraStockTtl3TmBfBlPay = sqlCommand.Parameters.Add("@STOCKTTL3TMBFBLPAY", SqlDbType.BigInt);
                            SqlParameter paraCAddUpUpdExecDate = sqlCommand.Parameters.Add("@CADDUPUPDEXECDATE", SqlDbType.Int);
                            SqlParameter paraStartCAddUpUpdDate = sqlCommand.Parameters.Add("@STARTCADDUPUPDDATE", SqlDbType.Int);
                            SqlParameter paraLastCAddUpUpdDate = sqlCommand.Parameters.Add("@LASTCADDUPUPDDATE", SqlDbType.Int);
                            SqlParameter paraStockSlipCount = sqlCommand.Parameters.Add("@STOCKSLIPCOUNT", SqlDbType.Int);
                            SqlParameter paraPaymentSchedule = sqlCommand.Parameters.Add("@PAYMENTSCHEDULE", SqlDbType.Int);
                            SqlParameter paraPaymentCond = sqlCommand.Parameters.Add("@PAYMENTCOND", SqlDbType.Int);
                            SqlParameter paraSuppCTaxLayCd = sqlCommand.Parameters.Add("@SUPPCTAXLAYCD", SqlDbType.Int);
                            SqlParameter paraSupplierConsTaxRate = sqlCommand.Parameters.Add("@SUPPLIERCONSTAXRATE", SqlDbType.Float);
                            SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                            #endregion

                            #region Parameterオブジェクト設定
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(suplierPayWork.CreateDateTime);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(suplierPayWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(suplierPayWork.FileHeaderGuid);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(suplierPayWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(suplierPayWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.LogicalDeleteCode);
                            paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);
                            paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                            paraPayeeName.Value = SqlDataMediator.SqlSetString(suplierPayWork.PayeeName);
                            paraPayeeName2.Value = SqlDataMediator.SqlSetString(suplierPayWork.PayeeName2);
                            paraPayeeSnm.Value = SqlDataMediator.SqlSetString(suplierPayWork.PayeeSnm);
                            // 未セット項目 >>>
                            paraResultsSectCd.Value = SqlDataMediator.SqlSetString("00");
                            paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(0);
                            paraSupplierNm1.Value = SqlDataMediator.SqlSetString(string.Empty);
                            paraSupplierNm2.Value = SqlDataMediator.SqlSetString(string.Empty);
                            paraSupplierSnm.Value = SqlDataMediator.SqlSetString(string.Empty);
                            // 未セット項目 <<<
                            paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);
                            paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(suplierPayWork.AddUpYearMonth);
                            paraLastTimePayment.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.LastTimePayment);
                            paraThisTimeFeePayNrml.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisTimeFeePayNrml);
                            paraThisTimeDisPayNrml.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisTimeDisPayNrml);
                            paraThisTimePayNrml.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisTimePayNrml);
                            paraThisTimeTtlBlcPay.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisTimeTtlBlcPay);
                            paraOfsThisTimeStock.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.OfsThisTimeStock);
                            paraOfsThisStockTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.OfsThisStockTax);
                            paraItdedOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ItdedOffsetOutTax);
                            paraItdedOffsetInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ItdedOffsetInTax);
                            paraItdedOffsetTaxFree.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ItdedOffsetTaxFree);
                            paraOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.OffsetOutTax);
                            paraOffsetInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.OffsetInTax);
                            paraThisTimeStockPrice.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisTimeStockPrice);
                            paraThisStcPrcTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStcPrcTax);
                            paraTtlItdedStcOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedStcOutTax);
                            paraTtlItdedStcInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedStcInTax);
                            paraTtlItdedStcTaxFree.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedStcTaxFree);
                            paraTtlStockOuterTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlStockOuterTax);
                            paraTtlStockInnerTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlStockInnerTax);
                            paraThisStckPricRgds.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStckPricRgds);
                            paraThisStcPrcTaxRgds.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStcPrcTaxRgds);
                            paraTtlItdedRetOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedRetOutTax);
                            paraTtlItdedRetInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedRetInTax);
                            paraTtlItdedRetTaxFree.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedRetTaxFree);
                            paraTtlRetOuterTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlRetOuterTax);
                            paraTtlRetInnerTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlRetInnerTax);
                            paraThisStckPricDis.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStckPricDis);
                            paraThisStcPrcTaxDis.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.ThisStcPrcTaxDis);
                            paraTtlItdedDisOutTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedDisOutTax);
                            paraTtlItdedDisInTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedDisInTax);
                            paraTtlItdedDisTaxFree.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlItdedDisTaxFree);
                            paraTtlDisOuterTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlDisOuterTax);
                            paraTtlDisInnerTax.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.TtlDisInnerTax);
                            // 未セット項目 >>>
                            paraTaxAdjust.Value = 0;
                            paraBalanceAdjust.Value = 0;
                            // 未セット項目 <<<
                            paraStockTotalPayBalance.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.StockTotalPayBalance);
                            paraStockTtl2TmBfBlPay.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.StockTtl2TmBfBlPay);
                            paraStockTtl3TmBfBlPay.Value = SqlDataMediator.SqlSetInt64(suplierPayWork.StockTtl3TmBfBlPay);
                            paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.CAddUpUpdExecDate);
                            paraStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.StartCAddUpUpdDate);
                            paraLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.LastCAddUpUpdDate);
                            paraStockSlipCount.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.StockSlipCount);
                            paraPaymentSchedule.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.PaymentSchedule);
                            paraPaymentCond.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PaymentCond);
                            paraSuppCTaxLayCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SuppCTaxLayCd);
                            paraSupplierConsTaxRate.Value = SqlDataMediator.SqlSetDouble(suplierPayWork.SupplierConsTaxRate);
                            paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.FractionProcCd);
                            #endregion

                            sqlCommand.ExecuteNonQuery();

                            //親レコード

                            #region Parameterオブジェクト設定
                            paraResultsSectCd.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);
                            paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SupplierCd);
                            paraSupplierNm1.Value = SqlDataMediator.SqlSetString(suplierPayWork.SupplierNm1);
                            paraSupplierNm2.Value = SqlDataMediator.SqlSetString(suplierPayWork.SupplierNm2);
                            paraSupplierSnm.Value = SqlDataMediator.SqlSetString(suplierPayWork.SupplierSnm);
                            // 未セット項目 >>>
                            paraLastTimePayment.Value = 0;
                            paraThisTimeFeePayNrml.Value = 0;
                            paraThisTimeDisPayNrml.Value = 0;
                            paraThisTimePayNrml.Value = 0;
                            paraThisTimeTtlBlcPay.Value = 0;
                            paraStockTotalPayBalance.Value = 0;
                            paraStockTtl2TmBfBlPay.Value = 0;
                            paraStockTtl3TmBfBlPay.Value = 0;
                            // 未セット項目 <<<
                            #endregion

                            sqlCommand.ExecuteNonQuery();
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }
        // --- ADD 2012/09/11 -----------<<<<<

        // 2008.07.24 add start --------------------------------------->>
        /// <summary>
        /// 精算支払集計データを更新します
        /// </summary>
        /// <param name="accPayTotalWorkList">精算支払集計データList</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 精算支払集計データを更新します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.07.24</br>
        /// </remarks>
        private int WriteAccPayTotalPrc(ref ArrayList accPayTotalWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            string sqlText = string.Empty;

            //Deleteコマンドの生成
            try
            {
                for (int i = 0; i < accPayTotalWorkList.Count; i++)
                {
                    AccPayTotalWork accPayTotalWork = accPayTotalWorkList[i] as AccPayTotalWork;
                    if (accPayTotalWork.UpdateStatus == 0)
                    {
                        #region DELETE文作成
                        sqlText = string.Empty;
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += " FROM ACCPAYTOTALRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                        sqlText += "    AND PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                        sqlText += "    AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;
                        //sqlText += "    AND MONEYKINDCODERF=@MONEYKINDCODE" + Environment.NewLine; // ADD 2008.12.17 
                        #endregion

                        using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                        {
                            //Prameterオブジェクトの作成
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                            SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                            SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                            //SqlParameter findParaMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int); // ADD 2008.12.17

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(accPayTotalWork.EnterpriseCode);
                            findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(accPayTotalWork.AddUpSecCode);
                            findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(accPayTotalWork.PayeeCode);
                            findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(accPayTotalWork.AddUpDate);
                            //findParaMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(accPayTotalWork.MoneyKindCode); // ADD 2008.12.17

                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }

                for (int i = 0; i < accPayTotalWorkList.Count; i++)
                {
                    AccPayTotalWork accPayTotalWork = accPayTotalWorkList[i] as AccPayTotalWork;

                    if (accPayTotalWork.UpdateStatus == 0)
                    {
                        #region INSERT文作成
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO ACCPAYTOTALRF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "    ,ADDUPSECCODERF" + Environment.NewLine;
                        sqlText += "    ,PAYEECODERF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERCDRF" + Environment.NewLine;
                        sqlText += "    ,ADDUPDATERF" + Environment.NewLine;
                        sqlText += "    ,MONEYKINDCODERF" + Environment.NewLine;
                        sqlText += "    ,MONEYKINDNAMERF" + Environment.NewLine;
                        sqlText += "    ,MONEYKINDDIVRF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTRF" + Environment.NewLine;
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
                        sqlText += "    ,@ADDUPSECCODE" + Environment.NewLine;
                        sqlText += "    ,@PAYEECODE" + Environment.NewLine;
                        sqlText += "    ,@SUPPLIERCD" + Environment.NewLine;
                        sqlText += "    ,@ADDUPDATE" + Environment.NewLine;
                        sqlText += "    ,@MONEYKINDCODE" + Environment.NewLine;
                        sqlText += "    ,@MONEYKINDNAME" + Environment.NewLine;
                        sqlText += "    ,@MONEYKINDDIV" + Environment.NewLine;
                        sqlText += "    ,@PAYMENT" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        #endregion

                        using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                        {
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)accPayTotalWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            #region Parameterオブジェクト作成
                            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                            SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                            SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                            SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                            SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                            SqlParameter paraMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int);
                            SqlParameter paraMoneyKindName = sqlCommand.Parameters.Add("@MONEYKINDNAME", SqlDbType.NVarChar);
                            SqlParameter paraMoneyKindDiv = sqlCommand.Parameters.Add("@MONEYKINDDIV", SqlDbType.Int);
                            SqlParameter paraPayment = sqlCommand.Parameters.Add("@PAYMENT", SqlDbType.BigInt);
                            #endregion

                            #region Parameterオブジェクト設定
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(accPayTotalWork.CreateDateTime);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(accPayTotalWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(accPayTotalWork.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(accPayTotalWork.FileHeaderGuid);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(accPayTotalWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(accPayTotalWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(accPayTotalWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(accPayTotalWork.LogicalDeleteCode);
                            paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(accPayTotalWork.AddUpSecCode);
                            paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(accPayTotalWork.PayeeCode);
                            paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(accPayTotalWork.SupplierCd);
                            paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(accPayTotalWork.AddUpDate);
                            paraMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(accPayTotalWork.MoneyKindCode);
                            paraMoneyKindName.Value = SqlDataMediator.SqlSetString(accPayTotalWork.MoneyKindName);
                            paraMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(accPayTotalWork.MoneyKindDiv);
                            paraPayment.Value = SqlDataMediator.SqlSetInt64(accPayTotalWork.Payment);
                            #endregion

                            sqlCommand.ExecuteNonQuery();
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }
        // 2008.07.24 add end -----------------------------------------<<
        
        /// <summary>
        /// 支払締更新履歴マスタを更新します
        /// </summary>
        /// <param name="paymentAddUpHisWorkList">支払締更新履歴マスタList</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払締更新履歴マスタを更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int WritePaymentAddUpHis(ref ArrayList paymentAddUpHisWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            string sqlText = string.Empty; // 2008.07.24 add

            //Insertコマンドの生成
            try
            {
                for (int i = 0; i < paymentAddUpHisWorkList.Count; i++)
                {
                    #region [2008.10.01 DEL]
                    /* --- DEL 2008.10.01 ---------->>>>>
                    PaymentAddUpHisWork paymentAddUpHisWork = paymentAddUpHisWorkList[i] as PaymentAddUpHisWork;
                    // 2008.07.24 upd start ----------------------------------------------------------------->>
                    //using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO PAYMENTADDUPHISRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPSECCODERF, CUSTOMERCODERF, STARTCADDUPUPDDATERF, CADDUPUPDDATERF, CADDUPUPDYEARMONTHRF, CADDUPUPDEXECDATERF, LASTCADDUPUPDDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ADDUPSECCODE, @CUSTOMERCODE, @STARTCADDUPUPDDATE, @CADDUPUPDDATE, @CADDUPUPDYEARMONTH, @CADDUPUPDEXECDATE, @LASTCADDUPUPDDATE)", sqlConnection, sqlTransaction))
                    sqlText = string.Empty;
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += " FROM PAYMENTADDUPHISRF" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "    AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                    sqlText += "    AND CADDUPUPDDATERF=@FINDCADDUPUPDDATE" + Environment.NewLine;

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaCAddUpUpdDate = sqlCommand.Parameters.Add("@FINDCADDUPUPDDATE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.EnterpriseCode);
                        findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.AddUpSecCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(paymentAddUpHisWork.SupplierCd);
                        findParaCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentAddUpHisWork.CAddUpUpdDate);

                        sqlCommand.ExecuteNonQuery();
                    }

                    sqlText = string.Empty;
                    sqlText += "INSERT INTO PAYMENTADDUPHISRF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "    ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += "    ,STARTCADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += "    ,CADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += "    ,CADDUPUPDYEARMONTHRF" + Environment.NewLine;
                    sqlText += "    ,CADDUPUPDEXECDATERF" + Environment.NewLine;
                    sqlText += "    ,LASTCADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += "    ,PROCDIVCDRF" + Environment.NewLine;
                    sqlText += "    ,ERRORSTATUSRF" + Environment.NewLine;
                    sqlText += "    ,HISTCTLCDRF" + Environment.NewLine;
                    sqlText += "    ,PROCRESULTRF" + Environment.NewLine;
                    sqlText += "    ,CONVERTPROCESSDIVCDRF" + Environment.NewLine;
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
                    sqlText += "    ,@ADDUPSECCODE" + Environment.NewLine;
                    sqlText += "    ,@SUPPLIERCD" + Environment.NewLine;
                    sqlText += "    ,@STARTCADDUPUPDDATE" + Environment.NewLine;
                    sqlText += "    ,@CADDUPUPDDATE" + Environment.NewLine;
                    sqlText += "    ,@CADDUPUPDYEARMONTH" + Environment.NewLine;
                    sqlText += "    ,@CADDUPUPDEXECDATE" + Environment.NewLine;
                    sqlText += "    ,@LASTCADDUPUPDDATE" + Environment.NewLine;
                    sqlText += "    ,@PROCDIVCD" + Environment.NewLine;
                    sqlText += "    ,@ERRORSTATUS" + Environment.NewLine;
                    sqlText += "    ,@HISTCTLCD" + Environment.NewLine;
                    sqlText += "    ,@PROCRESULT" + Environment.NewLine;
                    sqlText += "    ,@CONVERTPROCESSDIVCD" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))    
                    // 2008.07.24 upd end -------------------------------------------------------------------<<
                    {
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)paymentAddUpHisWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameterオブジェクト作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraStartCAddUpUpdDate = sqlCommand.Parameters.Add("@STARTCADDUPUPDDATE", SqlDbType.Int);
                        SqlParameter paraCAddUpUpdDate = sqlCommand.Parameters.Add("@CADDUPUPDDATE", SqlDbType.Int);
                        SqlParameter paraCAddUpUpdYearMonth = sqlCommand.Parameters.Add("@CADDUPUPDYEARMONTH", SqlDbType.Int);
                        SqlParameter paraCAddUpUpdExecDate = sqlCommand.Parameters.Add("@CADDUPUPDEXECDATE", SqlDbType.Int);
                        SqlParameter paraLastCAddUpUpdDate = sqlCommand.Parameters.Add("@LASTCADDUPUPDDATE", SqlDbType.Int);
                        SqlParameter paraProcDivCd = sqlCommand.Parameters.Add("@PROCDIVCD", SqlDbType.Int);
                        SqlParameter paraErrorStatus = sqlCommand.Parameters.Add("@ERRORSTATUS", SqlDbType.Int);
                        SqlParameter paraHistCtlCd = sqlCommand.Parameters.Add("@HISTCTLCD", SqlDbType.Int);
                        SqlParameter paraProcResult = sqlCommand.Parameters.Add("@PROCRESULT", SqlDbType.NVarChar);
                        SqlParameter paraConvertProcessDivCd = sqlCommand.Parameters.Add("@CONVERTPROCESSDIVCD", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクト設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentAddUpHisWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentAddUpHisWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(paymentAddUpHisWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentAddUpHisWork.LogicalDeleteCode);
                        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.AddUpSecCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paymentAddUpHisWork.SupplierCd);
                        paraStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentAddUpHisWork.StartCAddUpUpdDate);
                        paraCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentAddUpHisWork.CAddUpUpdDate);
                        paraCAddUpUpdYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paymentAddUpHisWork.CAddUpUpdYearMonth);
                        paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentAddUpHisWork.CAddUpUpdExecDate);
                        paraLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentAddUpHisWork.LastCAddUpUpdDate);
                        paraProcDivCd.Value = SqlDataMediator.SqlSetInt32(paymentAddUpHisWork.ProcDivCd);
                        paraErrorStatus.Value = SqlDataMediator.SqlSetInt32(paymentAddUpHisWork.ErrorStatus);
                        paraHistCtlCd.Value = SqlDataMediator.SqlSetInt32(paymentAddUpHisWork.HistCtlCd);
                        paraProcResult.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.ProcResult);
                        paraConvertProcessDivCd.Value = SqlDataMediator.SqlSetInt32(paymentAddUpHisWork.ConvertProcessDivCd);
                        #endregion
                        
                        //暗号化キーパラメータ設定
                        //SqlParameter encKeyCustDmdPrcRF = sqlCommand.Parameters.Add("@CUSTDMDPRCRF_ENCRYPTKEY", SqlDbType.Char);
                        //encKeyCustDmdPrcRF.Value = sqlEncryptInfo.GetSymKeyName("CUSTDMDPRCRF");
                        
                        sqlCommand.ExecuteNonQuery();
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                       --- DEL 2008.10.01 ----------<<<<< */
                    #endregion

                    // --- ADD 2008.10.01 ---------->>>>>
                    PaymentAddUpHisWork paymentAddUpHisWork = paymentAddUpHisWorkList[i] as PaymentAddUpHisWork;

                    #region [Insert文作成]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO PAYMENTADDUPHISRF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,STARTCADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += " ,CADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += " ,CADDUPUPDYEARMONTHRF" + Environment.NewLine;
                    sqlText += " ,CADDUPUPDEXECDATERF" + Environment.NewLine;
                    sqlText += " ,LASTCADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += " ,DATAUPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,PROCDIVCDRF" + Environment.NewLine;
                    sqlText += " ,ERRORSTATUSRF" + Environment.NewLine;
                    sqlText += " ,HISTCTLCDRF" + Environment.NewLine;
                    sqlText += " ,PROCRESULTRF" + Environment.NewLine;
                    sqlText += " ,CONVERTPROCESSDIVCDRF" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    sqlText += " VALUES" + Environment.NewLine;
                    sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@ADDUPSECCODE" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                    sqlText += " ,@STARTCADDUPUPDDATE" + Environment.NewLine;
                    sqlText += " ,@CADDUPUPDDATE" + Environment.NewLine;
                    sqlText += " ,@CADDUPUPDYEARMONTH" + Environment.NewLine;
                    sqlText += " ,@CADDUPUPDEXECDATE" + Environment.NewLine;
                    sqlText += " ,@LASTCADDUPUPDDATE" + Environment.NewLine;
                    sqlText += " ,@DATAUPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@PROCDIVCD" + Environment.NewLine;
                    sqlText += " ,@ERRORSTATUS" + Environment.NewLine;
                    sqlText += " ,@HISTCTLCD" + Environment.NewLine;
                    sqlText += " ,@PROCRESULT" + Environment.NewLine;
                    sqlText += " ,@CONVERTPROCESSDIVCD" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    #endregion  //[Insert文作成]

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)paymentAddUpHisWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameterオブジェクト作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraStartCAddUpUpdDate = sqlCommand.Parameters.Add("@STARTCADDUPUPDDATE", SqlDbType.Int);
                        SqlParameter paraCAddUpUpdDate = sqlCommand.Parameters.Add("@CADDUPUPDDATE", SqlDbType.Int);
                        SqlParameter paraCAddUpUpdYearMonth = sqlCommand.Parameters.Add("@CADDUPUPDYEARMONTH", SqlDbType.Int);
                        SqlParameter paraCAddUpUpdExecDate = sqlCommand.Parameters.Add("@CADDUPUPDEXECDATE", SqlDbType.Int);
                        SqlParameter paraLastCAddUpUpdDate = sqlCommand.Parameters.Add("@LASTCADDUPUPDDATE", SqlDbType.Int);
                        SqlParameter paraDataUpdateDateTime = sqlCommand.Parameters.Add("@DATAUPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraProcDivCd = sqlCommand.Parameters.Add("@PROCDIVCD", SqlDbType.Int);
                        SqlParameter paraErrorStatus = sqlCommand.Parameters.Add("@ERRORSTATUS", SqlDbType.Int);
                        SqlParameter paraHistCtlCd = sqlCommand.Parameters.Add("@HISTCTLCD", SqlDbType.Int);
                        SqlParameter paraProcResult = sqlCommand.Parameters.Add("@PROCRESULT", SqlDbType.NVarChar);
                        SqlParameter paraConvertProcessDivCd = sqlCommand.Parameters.Add("@CONVERTPROCESSDIVCD", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクト設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentAddUpHisWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentAddUpHisWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(paymentAddUpHisWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paymentAddUpHisWork.LogicalDeleteCode);
                        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.AddUpSecCode);
                        //paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paymentAddUpHisWork.SupplierCd); // DEL 2008.10.18
                        paraSupplierCd.Value = 0; // ADD 2008.10.18
                        paraStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentAddUpHisWork.StartCAddUpUpdDate);
                        paraCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentAddUpHisWork.CAddUpUpdDate);
                        paraCAddUpUpdYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paymentAddUpHisWork.CAddUpUpdYearMonth);
                        paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentAddUpHisWork.CAddUpUpdExecDate);
                        paraLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paymentAddUpHisWork.LastCAddUpUpdDate);
                        paraDataUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paymentAddUpHisWork.CreateDateTime);
                        paraProcDivCd.Value = 0;
                        paraErrorStatus.Value = 0;
                        paraHistCtlCd.Value = 0;
                        paraProcResult.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.ProcResult);
                        paraConvertProcessDivCd.Value = 0;
                        #endregion

                        //暗号化キーパラメータ設定
                        //SqlParameter encKeyCustDmdPrcRF = sqlCommand.Parameters.Add("@CUSTDMDPRCRF_ENCRYPTKEY", SqlDbType.Char);
                        //encKeyCustDmdPrcRF.Value = sqlEncryptInfo.GetSymKeyName("CUSTDMDPRCRF");

                        sqlCommand.ExecuteNonQuery();

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    // --- ADD 2008.10.01 ----------<<<<<
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }
        #endregion

        #region [パラメータ生成処理]
        /// <summary>
        /// 仕入先支払金額マスタ更新パラメータを取得します
        /// </summary>
        /// <param name="suplierPayUpdateWork">支払処理パラメータ</param>
        /// <param name="suplierPayWorkList">支払金額マスタ更新パラメータList</param>
        /// <param name="suplierPayChildWorkList">仕入先支払金額マスタ(子レコード用)List</param>
        /// <param name="accPayTotalWorkList">精算支払集計データList</param>
        /// <param name="paymentAddUpHisWorkList">支払締更新パラメータList</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額マスタ更新パラメータを取得します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int MakeSuplierPayParameters(ref SuplierPayUpdateWork suplierPayUpdateWork, ref ArrayList suplierPayWorkList, ref ArrayList suplierPayChildWorkList, ref ArrayList accPayTotalWorkList, out ArrayList paymentAddUpHisWorkList, out string retMsg, ref SqlConnection sqlConnection)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //支払締更新履歴List
            paymentAddUpHisWorkList = new ArrayList();
            retMsg = null;

            //支払金額マスタ
            SuplierPayWork suplierPayWork = null;
            Int32[] customerCodeList = new Int32[1];


            try
            {
                //●仕入先支払金額マスタ更新List作成処理
                if (suplierPayWorkList != null && suplierPayWorkList.Count > 0)
                {
                    //●支払締更新履歴マスタのチェック
                    for (int i = 0; i < suplierPayWorkList.Count; i++)
                    {
                        suplierPayWork = suplierPayWorkList[i] as SuplierPayWork;
                        if (suplierPayWork.UpdateStatus == 0)
                        {
                            status = CheckPaymentAddUpHis(ref suplierPayWork, ref sqlConnection);
                            //// ADD 2009.02.04 >>>
                            //// 実績修正マスメン対応のため、仕入先支払金額マスタもチェック対象
                            ////status = CheckSuplierPay(ref suplierPayWork, ref sqlConnection);
                            //// ADD 2009.02.04 <<<
                        }
                    }
                    
                    //●仕入先単位　仕入先支払金額マスタ・支払締更新履歴マスタ更新データ作成
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        for (int i = 0; i < suplierPayWorkList.Count; i++)
                        {
                            suplierPayWork = suplierPayWorkList[i] as SuplierPayWork;

                            customerCodeList[0] = new Int32();
                            customerCodeList[0] = suplierPayWork.PayeeCode;// ← 2007.09.14 980081 c                          
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                            // 更新対象外は読み飛ばし
                            if (suplierPayWork.UpdateStatus != 0)
                            {
                                continue;
                            }

                            //●前回支払情報取得                            
                            status = GetPaymentAddUpHisAndSuplierPay(ref suplierPayWork, ref sqlConnection);
                            

                            //締次更新実行年月日
                            suplierPayWork.CAddUpUpdExecDate = DateTime.Now;

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                //初期データ挿入時はデータがないので前回締次更新年月日に最小値を挿入する
                                suplierPayWork.LastCAddUpUpdDate = DateTime.MinValue;
                                suplierPayWork.StartCAddUpUpdDate = DateTime.MinValue;
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }

                            //●支払伝票マスタ取得
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (suplierPayWork.UpdateStatus == 0)
                                {
                                    status = GetPaymentSlp(ref suplierPayWork, ref sqlConnection);
                                }
                            }

                            //●支払明細データ＆支払マスタ取得
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (suplierPayWork.UpdateStatus == 0)
                                {
                                    status = GetPaymentDtlMain(ref suplierPayWork, ref accPayTotalWorkList, ref sqlConnection);
                                }
                            }

                            //●仕入データ取得
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (suplierPayWork.UpdateStatus == 0)
                                {
                                    status = GetStockSlip(ref suplierPayWork, ref suplierPayChildWorkList, ref sqlConnection);
                                }
                            }
                        }
                    }
                    //●支払締更新履歴マスタ更新List作成
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //締次更新処理の場合
                        status = MakeUpdateList(ref suplierPayWorkList, out paymentAddUpHisWorkList, suplierPayUpdateWork);
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuplierPayDB.MakeSuplierPayParameters Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        // --- ADD 2012/09/11 ----------->>>>>
        /// <summary>
        /// 仕入総括形式で仕入先支払金額マスタ更新パラメータを取得します
        /// </summary>
        /// <param name="suplierPayUpdateWork">支払処理パラメータ</param>
        /// <param name="suplierPayWorkList">支払金額マスタ更新パラメータList</param>
        /// <param name="suplierPayChildWorkList">仕入先支払金額マスタ(子レコード用)List</param>
        /// <param name="accPayTotalWorkList">精算支払集計データList</param>
        /// <param name="paymentAddUpHisWorkList">支払締更新パラメータList</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入総括形式で仕入先支払金額マスタ更新パラメータを取得します</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : 2012/09/11</br>
        /// </remarks>
        private int MakeSuplierPayParametersByAddUpSecCode(ref SuplierPayUpdateWork suplierPayUpdateWork, ref ArrayList suplierPayWorkList, ref ArrayList suplierPayChildWorkList, ref ArrayList accPayTotalWorkList, out ArrayList paymentAddUpHisWorkList, out string retMsg, ref SqlConnection sqlConnection)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //支払締更新履歴List
            paymentAddUpHisWorkList = new ArrayList();
            retMsg = null;

            //支払金額マスタ
            SuplierPayWork suplierPayWork = null;
            Int32[] customerCodeList = new Int32[1];


            try
            {
                //●仕入先支払金額マスタ更新List作成処理
                if (suplierPayWorkList != null && suplierPayWorkList.Count > 0)
                {
                    //●支払締更新履歴マスタのチェック
                    for (int i = 0; i < suplierPayWorkList.Count; i++)
                    {
                        suplierPayWork = suplierPayWorkList[i] as SuplierPayWork;
                        if (suplierPayWork.UpdateStatus == 0)
                        {
                            status = CheckPaymentAddUpHis(ref suplierPayWork, ref sqlConnection);
                        }
                    }
                    
                    //●仕入先単位　仕入先支払金額マスタ・支払締更新履歴マスタ更新データ作成
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        for (int i = 0; i < suplierPayWorkList.Count; i++)
                        {
                            suplierPayWork = suplierPayWorkList[i] as SuplierPayWork;

                            customerCodeList[0] = new Int32();
                            customerCodeList[0] = suplierPayWork.PayeeCode;
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                            // 更新対象外は読み飛ばし
                            if (suplierPayWork.UpdateStatus != 0)
                            {
                                continue;
                            }

                            //●前回支払情報取得                  
                            status = GetPaymentAddUpHisAndSuplierPayByAddUpSecCode(ref suplierPayWork, ref sqlConnection);

                            //締次更新実行年月日
                            suplierPayWork.CAddUpUpdExecDate = DateTime.Now;

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                //初期データ挿入時はデータがないので前回締次更新年月日に最小値を挿入する
                                suplierPayWork.LastCAddUpUpdDate = DateTime.MinValue;
                                suplierPayWork.StartCAddUpUpdDate = DateTime.MinValue;
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }

                            //●支払伝票マスタ取得
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (suplierPayWork.UpdateStatus == 0)
                                {
                                    status = GetPaymentSlpByAddUpSecCode(ref suplierPayWork, ref sqlConnection);
                                }
                            }

                            //●支払明細データ＆支払マスタ取得
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (suplierPayWork.UpdateStatus == 0)
                                {
                                    status = GetPaymentDtlMainByAddUpSecCode(ref suplierPayWork, ref accPayTotalWorkList, ref sqlConnection);
                                }
                            }

                            //●仕入データ取得
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (suplierPayWork.UpdateStatus == 0)
                                {
                                    // 集計方法＝2:計上拠点別支払拠点別の場合
                                    status = GetStockSlipByAddUpSecCode(
                                        ref suplierPayWork, ref suplierPayChildWorkList, ref sqlConnection);
                                }
                            }
                        }
                    }                    
                    //●支払締更新履歴マスタ更新List作成
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //締次更新処理の場合
                        status = MakeUpdateList(ref suplierPayWorkList, out paymentAddUpHisWorkList, suplierPayUpdateWork);
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuplierPayDB.MakeSuplierPayParameters Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        // --- ADD 2012/09/11 -----------<<<<<
        #endregion

        #region [仕入先マスタ]
        /// <summary>
        /// 仕入先マスタから更新情報を取得します
        /// </summary>
        /// <param name="suplierPayUpdateWork">仕入先支払金額マスタ更新パラメータ</param>
        /// <param name="suplierPayWorkList">仕入先支払金額ワーク用List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタから更新情報を取得します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int GetSupplier(ref SuplierPayUpdateWork suplierPayUpdateWork, ref ArrayList suplierPayWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            //仕入先マスタ
            //SupplierWork supplierWork = null;
            //支払金額マスタ
            SuplierPayWork suplierPayWork = null;
            string sqlText = string.Empty; // 2008.07.24 add

            // ADD 2008.12.17 >>>
            DateTime TaxRateStartDateRF  = DateTime.MinValue; // 税率開始日
            DateTime TaxRateEndDateRF    = DateTime.MinValue; // 税率終了日
            DateTime TaxRateStartDate2RF = DateTime.MinValue; // 税率2開始日
            DateTime TaxRateEndDate2RF   = DateTime.MinValue; // 税率2終了日
            DateTime TaxRateStartDate3RF = DateTime.MinValue; // 税率3開始日
            DateTime TaxRateEndDate3RF   = DateTime.MinValue; // 税率3終了日
            // ADD 2008.12.17 <<<

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    #region 2008.12.17 DEL 
                    /*
                    if (suplierPayUpdateWork.SupplierTotalDay != 99)
                    {
                        // 2008.07.24 upd start --------------------------------------------------->>
                        //sqlCommand.CommandText = "SELECT CUS1.ENTERPRISECODERF,CUS1.CUSTOMERCODERF,SUPP.PAYEECODERF CLAIMCODERF,CAST(DECRYPTBYKEY(CUS1.NAMERF) AS NVARCHAR(30)) AS NAMERF,CAST(DECRYPTBYKEY(CUS1.NAME2RF) AS NVARCHAR(30)) AS NAME2RF,CAST(DECRYPTBYKEY(CUS1.CUSTOMERSNMRF) AS NVARCHAR(20)) AS CUSTOMERSNMRF,CAST(DECRYPTBYKEY(CUS2.NAMERF) AS NVARCHAR(30)) AS CLAIMNAMERF,CAST(DECRYPTBYKEY(CUS2.NAME2RF) AS NVARCHAR(30)) AS CLAIMNAME2RF,CAST(DECRYPTBYKEY(CUS2.CUSTOMERSNMRF) AS NVARCHAR(20)) AS CLAIMSNMRF,SUPP.PAYMENTTOTALDAYRF TOTALDAYRF,SUPP.SUPPCTAXLAYREFCDRF CONSTAXLAYMETHODRF,SUPP.SUPPTTLAMNTDSPWAYCDRF TOTALAMOUNTDISPWAYCDRF,SUPP.STCKTTLAMNTDSPWAYREFRF TOTALAMNTDSPWAYREFRF,SUPP.STOCKCNSTAXFRCPROCCDRF STOCKCNSTAXFRCPROCCDRF,CUS1.MNGSECTIONCODERF,CUS1.SUPPLIERDIVRF FROM CUSTOMERRF CUS1 WITH (READUNCOMMITTED) LEFT JOIN CUSTSUPPLIRF SUPP ON (CUS1.ENTERPRISECODERF = SUPP.ENTERPRISECODERF AND CUS1.CUSTOMERCODERF = SUPP.CUSTOMERCODERF) LEFT JOIN CUSTOMERRF CUS2 ON (SUPP.ENTERPRISECODERF = CUS2.ENTERPRISECODERF AND SUPP.PAYEECODERF = CUS2.CUSTOMERCODERF) WHERE CUS1.ENTERPRISECODERF=@FINDENTERPRISECODE ";
                        sqlText = string.Empty;
                        sqlText += "SELECT " + Environment.NewLine;
                        sqlText += "     ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERCDRF" + Environment.NewLine;
                        sqlText += "    ,MNGSECTIONCODERF" + Environment.NewLine;
                        sqlText += "    ,INPSECTIONCODERF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTSECTIONCODERF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNM1RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNM2RF" + Environment.NewLine;
                        sqlText += "    ,SUPPHONORIFICTITLERF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERKANARF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERSNMRF" + Environment.NewLine;
                        sqlText += "    ,ORDERHONORIFICTTLRF" + Environment.NewLine;
                        sqlText += "    ,BUSINESSTYPECODERF" + Environment.NewLine;
                        sqlText += "    ,SALESAREACODERF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERPOSTNORF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERADDR1RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERADDR3RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERADDR4RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERTELNORF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERTELNO1RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERTELNO2RF" + Environment.NewLine;
                        sqlText += "    ,PURECODERF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTMONTHCODERF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTMONTHNAMERF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTDAYRF" + Environment.NewLine;
                        sqlText += "    ,SUPPCTAXLAYREFCDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPCTAXLAYCDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPCTAXATIONCDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPENTERPRISECDRF" + Environment.NewLine;
                        sqlText += "    ,PAYEECODERF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERATTRIBUTEDIVRF" + Environment.NewLine;
                        sqlText += "    ,SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
                        sqlText += "    ,STCKTTLAMNTDSPWAYREFRF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTCONDRF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTTOTALDAYRF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTSIGHTRF" + Environment.NewLine;
                        sqlText += "    ,STOCKAGENTCODERF" + Environment.NewLine;
                        sqlText += "    ,STOCKUNPRCFRCPROCCDRF" + Environment.NewLine;
                        sqlText += "    ,STOCKMONEYFRCPROCCDRF" + Environment.NewLine;
                        sqlText += "    ,STOCKCNSTAXFRCPROCCDRF" + Environment.NewLine;
                        sqlText += "    ,NTIMECALCSTDATERF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNOTE1RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNOTE2RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNOTE3RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNOTE4RF" + Environment.NewLine;
                        sqlText += " FROM SUPPLIERRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        // 2008.07.24 upd end -----------------------------------------------------<<
                    }
                    else
                    {
                        // 2008.07.24 upd start --------------------------------------------------->>
                        //sqlCommand.CommandText = "SELECT CUS1.ENTERPRISECODERF,CUS1.CUSTOMERCODERF,SUPP.PAYEECODERF CLAIMCODERF,CAST(DECRYPTBYKEY(CUS1.NAMERF) AS NVARCHAR(30)) AS NAMERF,CAST(DECRYPTBYKEY(CUS1.NAME2RF) AS NVARCHAR(30)) AS NAME2RF,CAST(DECRYPTBYKEY(CUS1.CUSTOMERSNMRF) AS NVARCHAR(20)) AS CUSTOMERSNMRF,CAST(DECRYPTBYKEY(CUS2.NAMERF) AS NVARCHAR(30)) AS CLAIMNAMERF,CAST(DECRYPTBYKEY(CUS2.NAME2RF) AS NVARCHAR(30)) AS CLAIMNAME2RF,CAST(DECRYPTBYKEY(CUS2.CUSTOMERSNMRF) AS NVARCHAR(20)) AS CLAIMSNMRF,SUPP.PAYMENTTOTALDAYRF TOTALDAYRF,SUPP.SUPPCTAXLAYREFCDRF CONSTAXLAYMETHODRF,SUPP.SUPPTTLAMNTDSPWAYCDRF TOTALAMOUNTDISPWAYCDRF,SUPP.STCKTTLAMNTDSPWAYREFRF TOTALAMNTDSPWAYREFRF,SUPP.STOCKCNSTAXFRCPROCCDRF STOCKCNSTAXFRCPROCCDRF,CUS1.MNGSECTIONCODERF,CUS1.SUPPLIERDIVRF FROM CUSTOMERRF CUS1 WITH (READUNCOMMITTED) LEFT JOIN CUSTSUPPLIRF SUPP ON (CUS1.ENTERPRISECODERF = SUPP.ENTERPRISECODERF AND CUS1.CUSTOMERCODERF = SUPP.CUSTOMERCODERF) LEFT JOIN CUSTOMERRF CUS2 ON (SUPP.ENTERPRISECODERF = CUS2.ENTERPRISECODERF AND SUPP.PAYEECODERF = CUS2.CUSTOMERCODERF) WHERE CUS1.ENTERPRISECODERF=@FINDENTERPRISECODE AND (SUPP.PAYMENTTOTALDAYRF>=28 AND SUPP.PAYMENTTOTALDAYRF<=31) ";
                        sqlText = string.Empty;
                        sqlText += "SELECT " + Environment.NewLine;
                        sqlText += "     ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERCDRF" + Environment.NewLine;
                        sqlText += "    ,MNGSECTIONCODERF" + Environment.NewLine;
                        sqlText += "    ,INPSECTIONCODERF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTSECTIONCODERF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNM1RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNM2RF" + Environment.NewLine;
                        sqlText += "    ,SUPPHONORIFICTITLERF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERKANARF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERSNMRF" + Environment.NewLine;
                        sqlText += "    ,ORDERHONORIFICTTLRF" + Environment.NewLine;
                        sqlText += "    ,BUSINESSTYPECODERF" + Environment.NewLine;
                        sqlText += "    ,SALESAREACODERF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERPOSTNORF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERADDR1RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERADDR3RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERADDR4RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERTELNORF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERTELNO1RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERTELNO2RF" + Environment.NewLine;
                        sqlText += "    ,PURECODERF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTMONTHCODERF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTMONTHNAMERF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTDAYRF" + Environment.NewLine;
                        sqlText += "    ,SUPPCTAXLAYREFCDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPCTAXLAYCDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPCTAXATIONCDRF" + Environment.NewLine;
                        sqlText += "    ,SUPPENTERPRISECDRF" + Environment.NewLine;
                        sqlText += "    ,PAYEECODERF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERATTRIBUTEDIVRF" + Environment.NewLine;
                        sqlText += "    ,SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
                        sqlText += "    ,STCKTTLAMNTDSPWAYREFRF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTCONDRF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTTOTALDAYRF" + Environment.NewLine;
                        sqlText += "    ,PAYMENTSIGHTRF" + Environment.NewLine;
                        sqlText += "    ,STOCKAGENTCODERF" + Environment.NewLine;
                        sqlText += "    ,STOCKUNPRCFRCPROCCDRF" + Environment.NewLine;
                        sqlText += "    ,STOCKMONEYFRCPROCCDRF" + Environment.NewLine;
                        sqlText += "    ,STOCKCNSTAXFRCPROCCDRF" + Environment.NewLine;
                        sqlText += "    ,NTIMECALCSTDATERF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNOTE1RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNOTE2RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNOTE3RF" + Environment.NewLine;
                        sqlText += "    ,SUPPLIERNOTE4RF" + Environment.NewLine;
                        sqlText += " FROM SUPPLIERRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += " AND (PAYMENTTOTALDAYRF>=28 AND PAYMENTTOTALDAYRF<=31)" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        // 2008.07.24 upd end -----------------------------------------------------<<
                    }
                    */
                    #endregion

                    sqlText = string.Empty;

                    #region [ SELECT ]
                    sqlText += "SELECT " + Environment.NewLine;
                    sqlText += "     SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERCDRF  " + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTSECTIONCODERF AS ADDUPSECCODERF " + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERNM1RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERNM2RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYEECODERF    " + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERNM1RF AS PAYEENAMERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERNM2RF AS PAYEENAME2RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERSNMRF AS PAYEESNMRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTTOTALDAYRF AS PAYMENTTOTALDAYRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPCTAXLAYCDRF AS SUPPCTAXLAYCDRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTCONDRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTMONTHCODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTDAYRF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATESTARTDATERF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATEENDDATERF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATERF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATESTARTDATE2RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATEENDDATE2RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATE2RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATESTARTDATE3RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATEENDDATE3RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATE3RF" + Environment.NewLine;
                    sqlText += "    ,PROCMONEY.FRACTIONPROCCDRF    " + Environment.NewLine;
                    sqlText += "FROM SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED)" + Environment.NewLine;
                    #endregion

                    #region [ JOIN句 ]
                    // 税率マスタ
                    sqlText += "LEFT JOIN TAXRATESETRF AS TAX WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "  ON SUPPLIER.ENTERPRISECODERF=TAX.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND TAX.TAXRATECODERF=0" + Environment.NewLine;

                    // 仕入金額処理区分設定マスタ
                    sqlText += "LEFT JOIN STOCKPROCMONEYRF AS PROCMONEY WITH(READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "  ON SUPPLIER.ENTERPRISECODERF=PROCMONEY.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND PROCMONEY.FRACPROCMONEYDIVRF=1" + Environment.NewLine;
                    sqlText += "  AND SUPPLIER.STOCKCNSTAXFRCPROCCDRF=PROCMONEY.FRACTIONPROCCODERF" + Environment.NewLine;

                    if (suplierPayUpdateWork.AddUpSecCode == "" || suplierPayUpdateWork.AddUpSecCode == "00")
                    {
                        sqlText += "INNER JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED)" + Environment.NewLine;
                        sqlText += "  ON SUPPLIER.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "  AND SUPPLIER.PAYMENTSECTIONCODERF= SEC.SECTIONCODERF" + Environment.NewLine;
                        sqlText += "  AND SEC.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    }
                    #endregion

                    #region [ WHERE句 ]
                    sqlText += "WHERE SUPPLIER.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SUPPLIER.SUPPLIERCDRF =SUPPLIER.PAYEECODERF" + Environment.NewLine;
                    sqlText += "  AND SUPPLIER.LOGICALDELETECODERF=0" + Environment.NewLine;
                    if (suplierPayUpdateWork.AddUpSecCode != "" && suplierPayUpdateWork.AddUpSecCode != "00")
                    {
                        sqlText += "  AND SUPPLIER.PAYMENTSECTIONCODERF = @PAYMENTSECTIONCODERF" + Environment.NewLine;
                    }

                    sqlCommand.CommandText = sqlText;

                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayUpdateWork.EnterpriseCode);
                    if (suplierPayUpdateWork.AddUpSecCode != "" && suplierPayUpdateWork.AddUpSecCode != "00")
                    {
                        SqlParameter findParaPaymentSectionCode = sqlCommand.Parameters.Add("@PAYMENTSECTIONCODERF", SqlDbType.NChar);
                        findParaPaymentSectionCode.Value = SqlDataMediator.SqlSetString(suplierPayUpdateWork.AddUpSecCode);
                    }

                    //仕入先締日
                    if (suplierPayUpdateWork.SupplierTotalDay != 0 && suplierPayUpdateWork.SupplierTotalDay != 99)
                    {
                        #region 2008.12.17 DEL
                        /*
                        // ↓ 2008.03.14 980081 c
                        //sqlCommand.CommandText += "AND TOTALDAYRF=@FINDTOTALDAY ";
                        sqlCommand.CommandText += "AND PAYMENTTOTALDAYRF=@FINDTOTALDAY ";
                        // ↑ 2008.03.14 980081 c
                        SqlParameter findParaTotalDay = sqlCommand.Parameters.Add("@FINDTOTALDAY", SqlDbType.Int);
                        findParaTotalDay.Value = SqlDataMediator.SqlSetInt32(suplierPayUpdateWork.SupplierTotalDay);
                        */
                        #endregion

                        // ADD 2008.12.17 >>>
                        // 28日以降は末締とする
                        if (suplierPayUpdateWork.SupplierTotalDay >= 28 && suplierPayUpdateWork.SupplierTotalDay <= 31)
                        {
                            sqlCommand.CommandText += "AND (PAYMENTTOTALDAYRF>=28 AND PAYMENTTOTALDAYRF<=31)";
                        }
                        else
                        {
                            sqlCommand.CommandText += "AND PAYMENTTOTALDAYRF=@FINDTOTALDAY ";
                            SqlParameter findParaTotalDay = sqlCommand.Parameters.Add("@FINDTOTALDAY", SqlDbType.Int);
                            findParaTotalDay.Value = SqlDataMediator.SqlSetInt32(suplierPayUpdateWork.SupplierTotalDay);
                        }
                        // ADD 2008.12.17 <<<
                    }
                    //// ADD 2008.10.20 >>>
                    //if (suplierPayUpdateWork.AddUpSecCode != "" && suplierPayUpdateWork.AddUpSecCode != "00")
                    //{
                    //    sqlCommand.CommandText += "    AND PAYMENTSECTIONCODERF =@FINDSECTIONCODE" + Environment.NewLine;
                    //    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    //    findParaSectionCode.Value = SqlDataMediator.SqlSetString(suplierPayUpdateWork.AddUpSecCode);
                    //}
                    //// ADD 2008.10.20 <<<
                    #endregion

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        suplierPayWork = new SuplierPayWork();
                        #region 2008.12.17 DEL
                        /*
                        supplierWork = new SupplierWork();
                        //仕入先マスタからデータセット
                        supplierWork = CopyToSupplierWorkFromReader(ref myReader);

                        //●画面パラメータから
                        suplierPayWork.AddUpDate = suplierPayUpdateWork.AddUpDate;     　　　　   //計上年月日
                        suplierPayWork.AddUpYearMonth = suplierPayUpdateWork.AddUpYearMonth;      //計上年月

                        //●仕入先マスタから
                        suplierPayWork.AddUpSecCode = supplierWork.PaymentSectionCode;            //計上拠点コード
                        suplierPayWork.EnterpriseCode = supplierWork.EnterpriseCode;              //企業コード
                        suplierPayWork.PayeeCode = supplierWork.PayeeCode;                        //支払先コード
                        suplierPayWork.PayeeName = supplierWork.PayeeName;                        //支払先名称
                        suplierPayWork.PayeeName2 = supplierWork.PayeeName2;                      //支払先名称2
                        suplierPayWork.PayeeSnm = supplierWork.PayeeSnm;                          //支払先略称
                        suplierPayWork.SupplierSnm = supplierWork.SupplierSnm;                    //仕入先略称
                        suplierPayWork.SupplierCd = supplierWork.SupplierCd;                      //仕入先コード
                        suplierPayWork.SupplierNm1 = supplierWork.SupplierNm1;                    //仕入先名称
                        suplierPayWork.SupplierNm2 = supplierWork.SupplierNm2;                    //仕入先名称2
                        suplierPayWork.SupplierTotalDay = supplierWork.PaymentTotalDay;           //支払先締日
                        suplierPayWork.SuppCTaxLayCd = supplierWork.SuppCTaxLayRefCd;             //消費税転嫁方式
                        //suplierPayWork.FractionProcCd = supplierWork.SalesCnsTaxFrcProcCd;
                        suplierPayWork.MngSectionCode = supplierWork.MngSectionCode;
                        //suplierPayWork.SupplierDiv = supplierWork.SupplierDiv;
                        suplierPayWork.SupplierTotalDay = supplierWork.PaymentTotalDay;           //仕入先締日
                        suplierPayWork.SuppCTaxRateRefCd = supplierWork.SuppCTaxLayRefCd;         //仕入先消費税転嫁方式参照区分
                        suplierPayWork.SuppCTaxLayCd = supplierWork.SuppCTaxLayCd;                //仕入先消費税転嫁方式コード
                        suplierPayWork.SuppTtlAmntDspWayCd = supplierWork.SuppTtlAmntDspWayCd;    //仕入先総額表示方法区分
                        suplierPayWork.StckTtlAmntDspWayRef = supplierWork.StckTtlAmntDspWayRef;  //仕入時総額表示方法参照区分
                        
                        suplierPayWork.UpdateStatus = 0;   //更新ステータス

                        if (suplierPayWork.PayeeCode == suplierPayWork.SupplierCd)
                        {
                            suplierPayWorkList.Add(suplierPayWork);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        */
                        #endregion

                        #region 結果セット
                        //●画面パラメータからセット
                        suplierPayWork.AddUpDate = suplierPayUpdateWork.AddUpDate;     　　　　                                         // 計上年月日
                        suplierPayWork.AddUpYearMonth = suplierPayUpdateWork.AddUpYearMonth;                                            // 計上年月
                        suplierPayWork.EnterpriseCode = suplierPayUpdateWork.EnterpriseCode;
                        suplierPayWork.ResultsSectCd = "00";
                        suplierPayWork.SupplierTotalDay = suplierPayUpdateWork.SupplierTotalDay;

                        //●抽出結果からセット
                        suplierPayWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));    // 計上拠点コード
                        suplierPayWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));           // 支払先コード
                        suplierPayWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));          //       名称1
                        suplierPayWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));        //       名称2
                        suplierPayWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));            //　　　 略称 　　
                        suplierPayWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));         // 仕入先コード
                        suplierPayWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));      //       名称1
                        suplierPayWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));      //       名称2
                        suplierPayWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));      //       略称
                        suplierPayWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));   　　// 支払条件　
                        suplierPayWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));   // 支払先消費税転嫁方式
                        suplierPayWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); // 端数処理区分

                        // 税率設定開始終了期間で税率を決定
                        TaxRateStartDateRF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATERF"));          // 税率開始日
                        TaxRateEndDateRF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATERF"));              // 税率終了日
                        TaxRateStartDate2RF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE2RF"));        // 税率2開始日
                        TaxRateEndDate2RF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE2RF"));            // 税率2終了日
                        TaxRateStartDate3RF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE3RF"));        // 税率3開始日
                        TaxRateEndDate3RF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE3RF"));            // 税率3終了日

                        if ( TaxRateStartDateRF <= suplierPayUpdateWork.AddUpDate && suplierPayUpdateWork.AddUpDate <= TaxRateEndDateRF)
                        {
                            // 税率1
                            suplierPayWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATERF"));
                        }
                        else if (TaxRateStartDate2RF <= suplierPayUpdateWork.AddUpDate && suplierPayUpdateWork.AddUpDate <= TaxRateEndDate2RF)
                        {
                            //税率2
                            suplierPayWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE2RF"));
                        }
                        else if (TaxRateStartDate3RF <= suplierPayUpdateWork.AddUpDate && suplierPayUpdateWork.AddUpDate <= TaxRateEndDate3RF)
                        {
                            //税率3
                            suplierPayWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE3RF"));
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                            return status;
                        }
                        suplierPayWork.UpdateStatus = 0;   //更新ステータス
                        // 支払予定日算出
                        DateTime PaymentmoneyDate = suplierPayWork.AddUpDate;
                        switch (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONTHCODERF"))) // 0:当月,1:翌月,2:翌々月,3翌々々月
                        {
                            case 1:
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(1);
                                break;
                            case 2:
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(2);
                                break;
                            case 3:
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(3);
                                break;
                        }
                        // 28日以降は末日とする
                        if (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF")) >= 28)
                        {
                            PaymentmoneyDate = new DateTime(PaymentmoneyDate.Year, PaymentmoneyDate.Month, 1);
                            PaymentmoneyDate = PaymentmoneyDate.AddMonths(1);
                            PaymentmoneyDate = PaymentmoneyDate.AddDays(-1);
                        }
                        else
                        {
                            PaymentmoneyDate = new DateTime(PaymentmoneyDate.Year, PaymentmoneyDate.Month, SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF")));
                        }
                        suplierPayWork.PaymentSchedule = PaymentmoneyDate;　// 支払予定日

                        suplierPayWorkList.Add(suplierPayWork);

                        #endregion

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }

        // --- ADD 2012/09/11 ----------->>>>>
        /// <summary>
        /// 仕入先マスタから仕入計上拠点別更新情報を取得します
        /// </summary>
        /// <param name="suplierPayUpdateWork">仕入先支払金額マスタ更新パラメータ</param>
        /// <param name="suplierPayWorkList">仕入先支払金額ワーク用List</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタから仕入計上拠点別更新情報を取得します</br>
        /// <br>Programmer : FSI佐々木　貴英</br>
        /// <br>Date       : 2012/09/11</br>
        /// </remarks>
        private int GetSupplierByAddUpSecCode(
              ref SuplierPayUpdateWork suplierPayUpdateWork
            , ref ArrayList suplierPayWorkList
            , ref string retMsg
            , ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            //支払金額マスタ
            SuplierPayWork suplierPayWork = null;
            string sqlText = string.Empty;

            DateTime TaxRateStartDateRF = DateTime.MinValue; // 税率開始日
            DateTime TaxRateEndDateRF = DateTime.MinValue; // 税率終了日
            DateTime TaxRateStartDate2RF = DateTime.MinValue; // 税率2開始日
            DateTime TaxRateEndDate2RF = DateTime.MinValue; // 税率2終了日
            DateTime TaxRateStartDate3RF = DateTime.MinValue; // 税率3開始日
            DateTime TaxRateEndDate3RF = DateTime.MinValue; // 税率3終了日

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;


                    sqlText = string.Empty;

                    #region [ SELECT ]
                    sqlText += "SELECT " + Environment.NewLine;
                    sqlText += "     SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERCDRF  " + Environment.NewLine;
                    sqlText += "    ,SUPLACCPAYRF.ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERNM1RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERNM2RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERCDRF AS PAYEECODERF    " + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERNM1RF AS PAYEENAMERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERNM2RF AS PAYEENAME2RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERSNMRF AS PAYEESNMRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTTOTALDAYRF AS PAYMENTTOTALDAYRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPCTAXLAYCDRF AS SUPPCTAXLAYCDRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTCONDRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTMONTHCODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTDAYRF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATESTARTDATERF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATEENDDATERF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATERF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATESTARTDATE2RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATEENDDATE2RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATE2RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATESTARTDATE3RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATEENDDATE3RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATE3RF" + Environment.NewLine;
                    sqlText += "    ,PROCMONEY.FRACTIONPROCCDRF " + Environment.NewLine;
                    sqlText += "    ,ISNULL(MAX(SUPLACCPAYRF.ADDUPADATE), 0) AS ADDUPADATE " + Environment.NewLine;
                    sqlText += "    ,ISNULL(ACCPAY.LATESTADDUPDATE, 0) AS LATESTADDUPDATE " + Environment.NewLine;
                    sqlText += "FROM SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED)" + Environment.NewLine;
                    #endregion

                    #region [ JOIN句 ]
                    // 税率マスタ
                    sqlText += "LEFT JOIN TAXRATESETRF AS TAX WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "  ON SUPPLIER.ENTERPRISECODERF=TAX.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND TAX.TAXRATECODERF=0" + Environment.NewLine;

                    // 仕入金額処理区分設定マスタ
                    sqlText += "LEFT JOIN STOCKPROCMONEYRF AS PROCMONEY WITH(READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "  ON SUPPLIER.ENTERPRISECODERF=PROCMONEY.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND PROCMONEY.FRACPROCMONEYDIVRF=1" + Environment.NewLine;
                    sqlText += "  AND SUPPLIER.STOCKCNSTAXFRCPROCCDRF=PROCMONEY.FRACTIONPROCCODERF" + Environment.NewLine;

                    // 拠点情報マスタ
                    if (suplierPayUpdateWork.AddUpSecCode == "" || suplierPayUpdateWork.AddUpSecCode == "00")
                    {
                        sqlText += "INNER JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED)" + Environment.NewLine;
                        sqlText += "  ON SUPPLIER.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "  AND SUPPLIER.PAYMENTSECTIONCODERF= SEC.SECTIONCODERF" + Environment.NewLine;
                        sqlText += "  AND SEC.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    }

                    // 支払拠点コード
                    sqlText += " LEFT JOIN (" + Environment.NewLine;
                    sqlText += "        SELECT " + Environment.NewLine;
                    sqlText += "             SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "            ,SUPPLIER.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "            ,SUPPLIER.SUPPLIERCDRF  " + Environment.NewLine;
                    sqlText += "            ,SUPPLIER.PAYMENTSECTIONCODERF AS ADDUPSECCODERF " + Environment.NewLine;
                    sqlText += "            ,@FINDNOWADDUPDATE AS ADDUPADATE " + Environment.NewLine;
                    sqlText += "        FROM SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "        WHERE LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += "    UNION" + Environment.NewLine;
                    sqlText += "        SELECT " + Environment.NewLine;
                    sqlText += "             SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "            ,SUPPLIER.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "            ,SUPPLIER.SUPPLIERCDRF  " + Environment.NewLine;
                    sqlText += "            ,ISNULL(SUPLACCPAY.ADDUPSECCODERF ,SUPPLIER.PAYMENTSECTIONCODERF) AS ADDUPSECCODERF " + Environment.NewLine;
                    sqlText += "            ,@FINDNOWADDUPDATE AS ADDUPADATE " + Environment.NewLine;
                    sqlText += "        FROM SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "        LEFT JOIN (" + Environment.NewLine;
                    sqlText += "            SELECT DISTINCT" + Environment.NewLine;
                    sqlText += "                  ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "                , ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += "                , PAYEECODERF" + Environment.NewLine;
                    sqlText += "            FROM" + Environment.NewLine;
                    sqlText += "                SUPLIERPAYRF" + Environment.NewLine;
                    sqlText += "            WHERE " + Environment.NewLine;
                    sqlText += "                LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += "        ) AS SUPLACCPAY" + Environment.NewLine;
                    sqlText += "            ON      SUPLACCPAY.ENTERPRISECODERF = SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "                AND SUPLACCPAY.PAYEECODERF = SUPPLIER.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += "                AND SUPLACCPAY.ADDUPSECCODERF != SUPPLIER.PAYMENTSECTIONCODERF" + Environment.NewLine;
                    sqlText += "    UNION" + Environment.NewLine;
                    sqlText += "        SELECT " + Environment.NewLine;
                    sqlText += "              SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "            , SUPPLIER.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "            , SUPPLIER.SUPPLIERCDRF  " + Environment.NewLine;
                    sqlText += "            , ISNULL(STOCKSLIP.STOCKSECTIONCDRF, SUPPLIER.PAYMENTSECTIONCODERF) AS ADDUPSECCODERF " + Environment.NewLine;
                    sqlText += "            , STOCKSLIP.ADDUPADATE " + Environment.NewLine;
                    sqlText += "        FROM SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "        LEFT JOIN (" + Environment.NewLine;
                    sqlText += "            SELECT DISTINCT" + Environment.NewLine;
                    sqlText += "                  ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "                , STOCKSECTIONCDRF" + Environment.NewLine;
                    sqlText += "                , SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += "                , MAX(STOCKADDUPADATERF) AS ADDUPADATE" + Environment.NewLine;
                    sqlText += "            FROM STOCKSLIPRF" + Environment.NewLine;
                    sqlText += "            WHERE " + Environment.NewLine;
                    sqlText += "                    LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += "                AND STOCKADDUPADATERF <= @FINDNOWADDUPDATE" + Environment.NewLine;
                    sqlText += "            GROUP BY " + Environment.NewLine;
                    sqlText += "                  ENTERPRISECODERF " + Environment.NewLine;
                    sqlText += "                , STOCKSECTIONCDRF " + Environment.NewLine;
                    sqlText += "                , SUPPLIERCDRF " + Environment.NewLine;
                    sqlText += "        ) AS STOCKSLIP" + Environment.NewLine;
                    sqlText += "            ON      STOCKSLIP.ENTERPRISECODERF = SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "                AND STOCKSLIP.SUPPLIERCDRF = SUPPLIER.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += "                AND STOCKSLIP.STOCKSECTIONCDRF != SUPPLIER.PAYMENTSECTIONCODERF" + Environment.NewLine;
                    sqlText += "    UNION " + Environment.NewLine;
                    sqlText += "        SELECT " + Environment.NewLine;
                    sqlText += "              SUPPLIER.ENTERPRISECODERF " + Environment.NewLine;
                    sqlText += "            , SUPPLIER.LOGICALDELETECODERF " + Environment.NewLine;
                    sqlText += "            , SUPPLIER.SUPPLIERCDRF  " + Environment.NewLine;
                    sqlText += "            , ISNULL(PSLP.ADDUPSECCODERF, SUPPLIER.PAYMENTSECTIONCODERF) AS ADDUPSECCODERF " + Environment.NewLine;
                    sqlText += "            , PSLP.ADDUPADATE " + Environment.NewLine;
                    sqlText += "        FROM SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "        lEFT JOIN ( " + Environment.NewLine;
                    sqlText += "            SELECT DISTINCT " + Environment.NewLine;
                    sqlText += "                  ENTERPRISECODERF " + Environment.NewLine;
                    sqlText += "                , ADDUPSECCODERF " + Environment.NewLine;
                    sqlText += "                , SUPPLIERCDRF " + Environment.NewLine;
                    sqlText += "                , MAX(ADDUPADATERF) AS ADDUPADATE " + Environment.NewLine;
                    sqlText += "            FROM PAYMENTSLPRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "            WHERE " + Environment.NewLine;
                    sqlText += "                    LOGICALDELETECODERF = 0 " + Environment.NewLine;
                    sqlText += "                AND ADDUPADATERF <= @FINDNOWADDUPDATE" + Environment.NewLine;
                    sqlText += "            GROUP BY " + Environment.NewLine;
                    sqlText += "                  ENTERPRISECODERF " + Environment.NewLine;
                    sqlText += "                , ADDUPSECCODERF " + Environment.NewLine;
                    sqlText += "                , SUPPLIERCDRF " + Environment.NewLine;
                    sqlText += "        ) AS PSLP " + Environment.NewLine;
                    sqlText += "            ON      PSLP.ENTERPRISECODERF = SUPPLIER.ENTERPRISECODERF " + Environment.NewLine;
                    sqlText += "                AND PSLP.SUPPLIERCDRF = SUPPLIER.SUPPLIERCDRF " + Environment.NewLine;
                    sqlText += "                AND PSLP.ADDUPSECCODERF != SUPPLIER.PAYMENTSECTIONCODERF " + Environment.NewLine;
                    sqlText += " ) AS SUPLACCPAYRF " + Environment.NewLine;
                    sqlText += "    ON      SUPLACCPAYRF.ENTERPRISECODERF = SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "        AND SUPLACCPAYRF.SUPPLIERCDRF = SUPPLIER.SUPPLIERCDRF" + Environment.NewLine;

                    // 仕入先支払金額マスタ
                    sqlText += " LEFT JOIN (" + Environment.NewLine;
                    sqlText += "    SELECT " + Environment.NewLine;
                    sqlText += "          ENTERPRISECODERF " + Environment.NewLine;
                    sqlText += "        , ADDUPSECCODERF " + Environment.NewLine;
                    sqlText += "        , PAYEECODERF " + Environment.NewLine;
                    sqlText += "        , MAX(ADDUPDATERF) AS LATESTADDUPDATE" + Environment.NewLine;
                    sqlText += "        FROM" + Environment.NewLine;
                    sqlText += "            SUPLIERPAYRF" + Environment.NewLine;
                    sqlText += "        WHERE " + Environment.NewLine;
                    sqlText += "            LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += "        GROUP BY " + Environment.NewLine;
                    sqlText += "              ENTERPRISECODERF " + Environment.NewLine;
                    sqlText += "            , PAYEECODERF " + Environment.NewLine;
                    sqlText += "            , ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += " ) AS ACCPAY" + Environment.NewLine;
                    sqlText += "    ON      ACCPAY.ENTERPRISECODERF = SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "        AND ACCPAY.PAYEECODERF = SUPPLIER.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += "        AND ACCPAY.ADDUPSECCODERF = SUPLACCPAYRF.ADDUPSECCODERF" + Environment.NewLine;

                    #endregion

                    #region [ WHERE句 ]
                    sqlText += "WHERE SUPPLIER.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SUPPLIER.LOGICALDELETECODERF=0" + Environment.NewLine;
                    if (suplierPayUpdateWork.AddUpSecCode != "" && suplierPayUpdateWork.AddUpSecCode != "00")
                    {
                        sqlText += "  AND SUPLACCPAYRF.ADDUPSECCODERF = @PAYMENTSECTIONCODERF" + Environment.NewLine;
                    }

                    #region [ パラメータ設定 ]
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayUpdateWork.EnterpriseCode);
                    if (suplierPayUpdateWork.AddUpSecCode != "" && suplierPayUpdateWork.AddUpSecCode != "00")
                    {
                        SqlParameter findParaPaymentSectionCode = sqlCommand.Parameters.Add("@PAYMENTSECTIONCODERF", SqlDbType.NChar);
                        findParaPaymentSectionCode.Value = SqlDataMediator.SqlSetString(suplierPayUpdateWork.AddUpSecCode);
                    }

                    //仕入先締日
                    if (suplierPayUpdateWork.SupplierTotalDay != 0 && suplierPayUpdateWork.SupplierTotalDay != 99)
                    {
                        // 28日以降は末締とする
                        if (suplierPayUpdateWork.SupplierTotalDay >= 28 && suplierPayUpdateWork.SupplierTotalDay <= 31)
                        {
                            sqlText += "AND (PAYMENTTOTALDAYRF>=28 AND PAYMENTTOTALDAYRF<=31)" + Environment.NewLine;
                        }
                        else
                        {
                            sqlText += "AND PAYMENTTOTALDAYRF=@FINDTOTALDAY " + Environment.NewLine;
                            SqlParameter findParaTotalDay = sqlCommand.Parameters.Add("@FINDTOTALDAY", SqlDbType.Int);
                            findParaTotalDay.Value = SqlDataMediator.SqlSetInt32(suplierPayUpdateWork.SupplierTotalDay);
                        }
                    }

                    // 今回締日
                    SqlParameter findParaAddUpdate = sqlCommand.Parameters.Add("@FINDNOWADDUPDATE", SqlDbType.Int);
                    findParaAddUpdate.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(suplierPayUpdateWork.AddUpDate.ToString("yyyyMMdd")));

                    #endregion [ パラメータ設定 ]
                    #endregion [ WHERE句 ]

                    #region [ GROUP BY句 ]
                    sqlText += " GROUP BY " + Environment.NewLine;
                    sqlText += "      SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    , SUPPLIER.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "    , SUPPLIER.SUPPLIERCDRF  " + Environment.NewLine;
                    sqlText += "    , SUPLACCPAYRF.ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += "    , SUPPLIER.SUPPLIERNM1RF" + Environment.NewLine;
                    sqlText += "    , SUPPLIER.SUPPLIERNM2RF" + Environment.NewLine;
                    sqlText += "    , SUPPLIER.SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += "    , SUPPLIER.PAYMENTTOTALDAYRF" + Environment.NewLine;
                    sqlText += "    , SUPPLIER.SUPPCTAXLAYCDRF" + Environment.NewLine;
                    sqlText += "    , SUPPLIER.PAYMENTCONDRF" + Environment.NewLine;
                    sqlText += "    , SUPPLIER.PAYMENTMONTHCODERF" + Environment.NewLine;
                    sqlText += "    , SUPPLIER.PAYMENTDAYRF" + Environment.NewLine;
                    sqlText += "    , TAX.TAXRATESTARTDATERF" + Environment.NewLine;
                    sqlText += "    , TAX.TAXRATEENDDATERF" + Environment.NewLine;
                    sqlText += "    , TAX.TAXRATERF" + Environment.NewLine;
                    sqlText += "    , TAX.TAXRATESTARTDATE2RF" + Environment.NewLine;
                    sqlText += "    , TAX.TAXRATEENDDATE2RF" + Environment.NewLine;
                    sqlText += "    , TAX.TAXRATE2RF" + Environment.NewLine;
                    sqlText += "    , TAX.TAXRATESTARTDATE3RF" + Environment.NewLine;
                    sqlText += "    , TAX.TAXRATEENDDATE3RF" + Environment.NewLine;
                    sqlText += "    , TAX.TAXRATE3RF" + Environment.NewLine;
                    sqlText += "    , PROCMONEY.FRACTIONPROCCDRF " + Environment.NewLine;
                    sqlText += "    , ACCPAY.LATESTADDUPDATE " + Environment.NewLine;
                    #endregion [ GROUP BY句 ]

                    sqlCommand.CommandText = sqlText;

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        int lastAddUpdate =  SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LATESTADDUPDATE"));   
                        int addUpdate =  SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPADATE"));
                        if (addUpdate <= lastAddUpdate)
                        {
                            // 今まで締処理したことがない、拠点での仕入及び支払データが最終締日～今回締日の
                            // 範囲内に存在しない場合、対象外とする
                            continue;
                        }

                        suplierPayWork = new SuplierPayWork();

                        #region 結果セット
                        //●画面パラメータからセット
                        suplierPayWork.AddUpDate = suplierPayUpdateWork.AddUpDate;     　　　　                                         // 計上年月日
                        suplierPayWork.AddUpYearMonth = suplierPayUpdateWork.AddUpYearMonth;                                            // 計上年月
                        suplierPayWork.EnterpriseCode = suplierPayUpdateWork.EnterpriseCode;
                        suplierPayWork.SupplierTotalDay = suplierPayUpdateWork.SupplierTotalDay;

                        //●抽出結果からセット
                        suplierPayWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));    // 計上拠点コード
                        suplierPayWork.ResultsSectCd = suplierPayWork.AddUpSecCode;                                                     // 実績拠点コード
                        suplierPayWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));           // 支払先コード
                        suplierPayWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));          //       名称1
                        suplierPayWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));        //       名称2
                        suplierPayWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));            //　　　 略称 　　
                        suplierPayWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));         // 仕入先コード
                        suplierPayWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));      //       名称1
                        suplierPayWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));      //       名称2
                        suplierPayWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));      //       略称
                        suplierPayWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));   　　// 支払条件　
                        suplierPayWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));   // 支払先消費税転嫁方式
                        suplierPayWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); // 端数処理区分

                        // 税率設定開始終了期間で税率を決定
                        TaxRateStartDateRF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATERF"));          // 税率開始日
                        TaxRateEndDateRF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATERF"));              // 税率終了日
                        TaxRateStartDate2RF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE2RF"));        // 税率2開始日
                        TaxRateEndDate2RF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE2RF"));            // 税率2終了日
                        TaxRateStartDate3RF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE3RF"));        // 税率3開始日
                        TaxRateEndDate3RF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE3RF"));            // 税率3終了日

                        if (TaxRateStartDateRF <= suplierPayUpdateWork.AddUpDate && suplierPayUpdateWork.AddUpDate <= TaxRateEndDateRF)
                        {
                            // 税率1
                            suplierPayWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATERF"));
                        }
                        else if (TaxRateStartDate2RF <= suplierPayUpdateWork.AddUpDate && suplierPayUpdateWork.AddUpDate <= TaxRateEndDate2RF)
                        {
                            //税率2
                            suplierPayWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE2RF"));
                        }
                        else if (TaxRateStartDate3RF <= suplierPayUpdateWork.AddUpDate && suplierPayUpdateWork.AddUpDate <= TaxRateEndDate3RF)
                        {
                            //税率3
                            suplierPayWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE3RF"));
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                            return status;
                        }
                        suplierPayWork.UpdateStatus = 0;   //更新ステータス
                        // 支払予定日算出
                        DateTime PaymentmoneyDate = suplierPayWork.AddUpDate;
                        switch (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONTHCODERF"))) // 0:当月,1:翌月,2:翌々月,3翌々々月
                        {
                            case 1:
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(1);
                                break;
                            case 2:
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(2);
                                break;
                            case 3:
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(3);
                                break;
                        }
                        // 28日以降は末日とする
                        if (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF")) >= 28)
                        {
                            PaymentmoneyDate = new DateTime(PaymentmoneyDate.Year, PaymentmoneyDate.Month, 1);
                            PaymentmoneyDate = PaymentmoneyDate.AddMonths(1);
                            PaymentmoneyDate = PaymentmoneyDate.AddDays(-1);
                        }
                        else
                        {
                            PaymentmoneyDate = new DateTime(PaymentmoneyDate.Year, PaymentmoneyDate.Month, SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF")));
                        }
                        suplierPayWork.PaymentSchedule = PaymentmoneyDate;　// 支払予定日

                        suplierPayWorkList.Add(suplierPayWork);

                        #endregion

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }
        // --- ADD 2012/09/11 -----------<<<<<

        /// <summary>
        /// 仕入先マスタから更新情報を取得します
        /// </summary>
        /// <param name="suplierPayWork">仕入先支払金額マスタ更新パラメータ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタから更新情報を取得します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int GetIndivSupplier(ref SuplierPayWork suplierPayWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            //仕入先マスタ
            //SupplierWork supplierWork = null;

            string sqlText = string.Empty; // 2008.07.24 add

            // ADD 2008.12.17 >>>
            DateTime TaxRateStartDateRF  = DateTime.MinValue; //税率開始日
            DateTime TaxRateEndDateRF    = DateTime.MinValue; //税率終了日
            DateTime TaxRateStartDate2RF = DateTime.MinValue; //税率2開始日
            DateTime TaxRateEndDate2RF   = DateTime.MinValue; //税率2終了日
            DateTime TaxRateStartDate3RF = DateTime.MinValue; //税率3開始日
            DateTime TaxRateEndDate3RF   = DateTime.MinValue; //税率3終了日
            // ADD 2008.12.17 <<<

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    #region 2008.12.17 DEL
                    /*
                    // ↓ 2008.03.14 980081 c
                    #region 旧レイアウト(コメントアウト)
                    //// ↓ 2008.03.12 980081 c
                    ////// ↓ 2007.09.14 980081 c
                    //////sqlCommand.CommandText = "SELECT ENTERPRISECODERF,CUSTOMERCODERF,CAST(DECRYPTBYKEY(NAMERF) AS NVARCHAR(30)) AS NAMERF,CAST(DECRYPTBYKEY(NAME2RF) AS NVARCHAR(30)) AS NAME2RF,TOTALDAYRF,CONSTAXLAYMETHODRF FROM CUSTOMERRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE ";
                    ////sqlCommand.CommandText = "SELECT ENTERPRISECODERF,CUSTOMERCODERF,CLAIMCODERF,CAST(DECRYPTBYKEY(NAMERF) AS NVARCHAR(30)) AS NAMERF,CAST(DECRYPTBYKEY(NAME2RF) AS NVARCHAR(30)) AS NAME2RF,CAST(DECRYPTBYKEY(CUSTOMERSNMRF) AS NVARCHAR(20)) AS CUSTOMERSNMRF,CAST(DECRYPTBYKEY(CLAIMNAMERF) AS NVARCHAR(30)) AS CLAIMNAMERF,CAST(DECRYPTBYKEY(CLAIMNAME2RF) AS NVARCHAR(30)) AS CLAIMNAME2RF,CAST(DECRYPTBYKEY(CLAIMSNMRF) AS NVARCHAR(20)) AS CLAIMSNMRF,TOTALDAYRF,CONSTAXLAYMETHODRF,TOTALAMOUNTDISPWAYCDRF,TOTALAMNTDSPWAYREFRF FROM CUSTOMERRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE ";
                    ////// ↑ 2007.09.14 980081 c
                    //sqlCommand.CommandText = "SELECT ENTERPRISECODERF,CUSTOMERCODERF,CLAIMCODERF,CAST(DECRYPTBYKEY(NAMERF) AS NVARCHAR(30)) AS NAMERF,CAST(DECRYPTBYKEY(NAME2RF) AS NVARCHAR(30)) AS NAME2RF,CAST(DECRYPTBYKEY(CUSTOMERSNMRF) AS NVARCHAR(20)) AS CUSTOMERSNMRF,CAST(DECRYPTBYKEY(CLAIMNAMERF) AS NVARCHAR(30)) AS CLAIMNAMERF,CAST(DECRYPTBYKEY(CLAIMNAME2RF) AS NVARCHAR(30)) AS CLAIMNAME2RF,CAST(DECRYPTBYKEY(CLAIMSNMRF) AS NVARCHAR(20)) AS CLAIMSNMRF,TOTALDAYRF,CONSTAXLAYMETHODRF,TOTALAMOUNTDISPWAYCDRF,TOTALAMNTDSPWAYREFRF,MNGSECTIONCODERF,SUPPLIERDIVRF FROM CUSTOMERRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE ";
                    //// ↑ 2008.03.12 980081 c
                    #endregion
                    // 2008.07.24 upd start -------------------------------------------->>
                    //sqlCommand.CommandText = "SELECT CUS1.ENTERPRISECODERF,CUS1.CUSTOMERCODERF,SUPP.PAYEECODERF CLAIMCODERF,CAST(DECRYPTBYKEY(CUS1.NAMERF) AS NVARCHAR(30)) AS NAMERF,CAST(DECRYPTBYKEY(CUS1.NAME2RF) AS NVARCHAR(30)) AS NAME2RF,CAST(DECRYPTBYKEY(CUS1.CUSTOMERSNMRF) AS NVARCHAR(20)) AS CUSTOMERSNMRF,CAST(DECRYPTBYKEY(CUS2.NAMERF) AS NVARCHAR(30)) AS CLAIMNAMERF,CAST(DECRYPTBYKEY(CUS2.NAME2RF) AS NVARCHAR(30)) AS CLAIMNAME2RF,CAST(DECRYPTBYKEY(CUS2.CUSTOMERSNMRF) AS NVARCHAR(20)) AS CLAIMSNMRF,SUPP.PAYMENTTOTALDAYRF TOTALDAYRF,SUPP.SUPPCTAXLAYREFCDRF CONSTAXLAYMETHODRF,SUPP.SUPPTTLAMNTDSPWAYCDRF TOTALAMOUNTDISPWAYCDRF,SUPP.STCKTTLAMNTDSPWAYREFRF TOTALAMNTDSPWAYREFRF,SUPP.STOCKCNSTAXFRCPROCCDRF STOCKCNSTAXFRCPROCCDRF,CUS1.MNGSECTIONCODERF,CUS1.SUPPLIERDIVRF FROM CUSTOMERRF CUS1 WITH (READUNCOMMITTED) LEFT JOIN CUSTSUPPLIRF SUPP ON (CUS1.ENTERPRISECODERF = SUPP.ENTERPRISECODERF AND CUS1.CUSTOMERCODERF = SUPP.CUSTOMERCODERF) LEFT JOIN CUSTOMERRF CUS2 ON (SUPP.ENTERPRISECODERF = CUS2.ENTERPRISECODERF AND SUPP.PAYEECODERF = CUS2.CUSTOMERCODERF) WHERE CUS1.ENTERPRISECODERF=@FINDENTERPRISECODE AND CUS1.CUSTOMERCODERF=@FINDCUSTOMERCODE ";
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += "    ,MNGSECTIONCODERF" + Environment.NewLine;
                    sqlText += "    ,INPSECTIONCODERF" + Environment.NewLine;
                    sqlText += "    ,PAYMENTSECTIONCODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERNM1RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERNM2RF" + Environment.NewLine;
                    sqlText += "    ,SUPPHONORIFICTITLERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERKANARF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += "    ,ORDERHONORIFICTTLRF" + Environment.NewLine;
                    sqlText += "    ,BUSINESSTYPECODERF" + Environment.NewLine;
                    sqlText += "    ,SALESAREACODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERPOSTNORF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERADDR1RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERADDR3RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERADDR4RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERTELNORF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERTELNO1RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERTELNO2RF" + Environment.NewLine;
                    sqlText += "    ,PURECODERF" + Environment.NewLine;
                    sqlText += "    ,PAYMENTMONTHCODERF" + Environment.NewLine;
                    sqlText += "    ,PAYMENTMONTHNAMERF" + Environment.NewLine;
                    sqlText += "    ,PAYMENTDAYRF" + Environment.NewLine;
                    sqlText += "    ,SUPPCTAXLAYREFCDRF" + Environment.NewLine;
                    sqlText += "    ,SUPPCTAXLAYCDRF" + Environment.NewLine;
                    sqlText += "    ,SUPPCTAXATIONCDRF" + Environment.NewLine;
                    sqlText += "    ,SUPPENTERPRISECDRF" + Environment.NewLine;
                    sqlText += "    ,PAYEECODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERATTRIBUTEDIVRF" + Environment.NewLine;
                    sqlText += "    ,SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
                    sqlText += "    ,STCKTTLAMNTDSPWAYREFRF" + Environment.NewLine;
                    sqlText += "    ,PAYMENTCONDRF" + Environment.NewLine;
                    sqlText += "    ,PAYMENTTOTALDAYRF" + Environment.NewLine;
                    sqlText += "    ,PAYMENTSIGHTRF" + Environment.NewLine;
                    sqlText += "    ,STOCKAGENTCODERF" + Environment.NewLine;
                    sqlText += "    ,STOCKUNPRCFRCPROCCDRF" + Environment.NewLine;
                    sqlText += "    ,STOCKMONEYFRCPROCCDRF" + Environment.NewLine;
                    sqlText += "    ,STOCKCNSTAXFRCPROCCDRF" + Environment.NewLine;
                    sqlText += "    ,NTIMECALCSTDATERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERNOTE1RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERNOTE2RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERNOTE3RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIERNOTE4RF" + Environment.NewLine;
                    sqlText += " FROM SUPPLIERRF" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    // 2008.07.24 upd end ----------------------------------------------<<
                    // ↑ 2008.03.14 980081 
                    */
                    #endregion

                    sqlText = string.Empty;

                    #region [ SELECT ]
                    sqlText += "SELECT " + Environment.NewLine;
                    sqlText += "     SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERCDRF  " + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTSECTIONCODERF AS ADDUPSECCODERF " + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERNM1RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERNM2RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYEECODERF    " + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERNM1RF AS PAYEENAMERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERNM2RF AS PAYEENAME2RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERSNMRF AS PAYEESNMRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTTOTALDAYRF AS PAYMENTTOTALDAYRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPCTAXLAYCDRF AS SUPPCTAXLAYCDRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTCONDRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTMONTHCODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTDAYRF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATESTARTDATERF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATEENDDATERF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATERF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATESTARTDATE2RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATEENDDATE2RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATE2RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATESTARTDATE3RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATEENDDATE3RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATE3RF" + Environment.NewLine;
                    sqlText += "    ,PROCMONEY.FRACTIONPROCCDRF    " + Environment.NewLine;
                    sqlText += "FROM SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED)" + Environment.NewLine;
                    #endregion

                    #region [ JOIN句 ]
                    // 税率マスタ
                    sqlText += "LEFT JOIN TAXRATESETRF AS TAX WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "  ON SUPPLIER.ENTERPRISECODERF=TAX.ENTERPRISECODERF" + Environment.NewLine;
                    // 仕入金額処理区分設定マスタ
                    sqlText += "LEFT JOIN STOCKPROCMONEYRF AS PROCMONEY WITH(READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "  ON SUPPLIER.ENTERPRISECODERF=PROCMONEY.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND PROCMONEY.FRACPROCMONEYDIVRF=1" + Environment.NewLine;
                    sqlText += "  AND SUPPLIER.STOCKCNSTAXFRCPROCCDRF=PROCMONEY.FRACTIONPROCCODERF" + Environment.NewLine;
                    #endregion

                    #region [ WHERE句 ]
                    sqlText += "WHERE SUPPLIER.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SUPPLIER.PAYMENTSECTIONCODERF = @PAYMENTSECTIONCODERF" + Environment.NewLine;
                    sqlText += "  AND SUPPLIER.SUPPLIERCDRF =SUPPLIER.PAYEECODERF" + Environment.NewLine;
                    sqlText += "  AND SUPPLIER.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                    sqlText += "  AND SUPPLIER.LOGICALDELETECODERF=0" + Environment.NewLine;
                    #endregion

                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findPaymentSectionCode = sqlCommand.Parameters.Add("@PAYMENTSECTIONCODERF", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    findPaymentSectionCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SupplierCd);
                    
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        #region 2008.12.17 DEL
                        /*
                        supplierWork = new SupplierWork();
                        
                        //仕入先マスタからデータセット
                        supplierWork = CopyToSupplierWorkFromReader(ref myReader);

                        //●仕入先マスタから
                        suplierPayWork.AddUpSecCode =  supplierWork.PaymentSectionCode;          //計上拠点コード // ADD 2008.10.20                       
                        suplierPayWork.EnterpriseCode = supplierWork.EnterpriseCode;              //企業コード
                        suplierPayWork.PayeeCode = supplierWork.PayeeCode;                        //支払先コード
                        suplierPayWork.PayeeName = supplierWork.PayeeName;                        //支払先名称
                        suplierPayWork.PayeeName2 = supplierWork.PayeeName2;                      //支払先名称2
                        suplierPayWork.PayeeSnm = supplierWork.PayeeSnm;                          //支払先略称
                        suplierPayWork.SupplierSnm = supplierWork.SupplierSnm;                    //仕入先略称
                        suplierPayWork.SupplierCd = supplierWork.SupplierCd;                      //仕入先コード
                        suplierPayWork.SupplierNm1 = supplierWork.SupplierNm1;                    //仕入先名称
                        suplierPayWork.SupplierNm2 = supplierWork.SupplierNm2;                    //仕入先名称2

                        suplierPayWork.SupplierTotalDay = supplierWork.PaymentTotalDay;           //仕入先締日
                        suplierPayWork.SuppCTaxRateRefCd = supplierWork.SuppCTaxLayRefCd;         //仕入先消費税転嫁方式参照区分
                        suplierPayWork.SuppCTaxLayCd = supplierWork.SuppCTaxLayCd;                //仕入先消費税転嫁方式コード
                        suplierPayWork.SuppTtlAmntDspWayCd = supplierWork.SuppTtlAmntDspWayCd;    //仕入先総額表示方法区分
                        suplierPayWork.StckTtlAmntDspWayRef = supplierWork.StckTtlAmntDspWayRef;  //仕入時総額表示方法参照区分
                        // ↓ 2008.03.12 980081 a
                        //suplierPayWork.FractionProcCd = supplierWork.SalesCnsTaxFrcProcCd;
                        suplierPayWork.MngSectionCode = supplierWork.MngSectionCode;
                        //suplierPayWork.SupplierDiv = supplierWork.SupplierDiv;
                        // ↑ 2008.03.12 980081 a
                        suplierPayWork.UpdateStatus = 0;   //更新ステータス
                        */
                        #endregion

                        #region 結果セット
                        //●画面パラメータからセット
                        suplierPayWork.AddUpDate = suplierPayWork.AddUpDate;     　　　　                                         // 計上年月日
                        suplierPayWork.AddUpYearMonth = suplierPayWork.AddUpYearMonth;                                            // 計上年月
                        suplierPayWork.EnterpriseCode = suplierPayWork.EnterpriseCode;

                        //●抽出結果からセット
                        suplierPayWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));    // 計上拠点コード
                        suplierPayWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));           // 支払先コード
                        suplierPayWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));          //       名称1
                        suplierPayWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));        //       名称2
                        suplierPayWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));            //　　　 略称 　　
                        suplierPayWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));         // 仕入先コード
                        suplierPayWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));      //       名称1
                        suplierPayWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));      //       名称2
                        suplierPayWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));      //       略称
                        suplierPayWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));   　　// 支払条件　
                        suplierPayWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));   // 支払先消費税転嫁方式
                        suplierPayWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); // 端数処理区分

                        // 税率設定開始終了期間で税率を決定
                        TaxRateStartDateRF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATERF"));          // 税率開始日
                        TaxRateEndDateRF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATERF"));              // 税率終了日
                        TaxRateStartDate2RF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE2RF"));        // 税率2開始日
                        TaxRateEndDate2RF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE2RF"));            // 税率2終了日
                        TaxRateStartDate3RF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE3RF"));        // 税率3開始日
                        TaxRateEndDate3RF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE3RF"));            // 税率3終了日

                        if (TaxRateStartDateRF <= suplierPayWork.AddUpDate && suplierPayWork.AddUpDate <= TaxRateEndDateRF)
                        {
                            // 税率1
                            suplierPayWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATERF"));
                        }
                        else if (TaxRateStartDate2RF <= suplierPayWork.AddUpDate && suplierPayWork.AddUpDate <= TaxRateEndDate2RF)
                        {
                            //税率2
                            suplierPayWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE2RF"));
                        }
                        else if (TaxRateStartDate3RF <= suplierPayWork.AddUpDate && suplierPayWork.AddUpDate <= TaxRateEndDate3RF)
                        {
                            //税率3
                            suplierPayWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE3RF"));
                        }
                        suplierPayWork.UpdateStatus = 0;   //更新ステータス

                        // 支払予定日算出
                        DateTime PaymentmoneyDate = suplierPayWork.AddUpDate;
                        switch (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONTHCODERF"))) // 0:当月,1:翌月,2:翌々月,3翌々々月
                        {
                            case 1:
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(1);
                                break;
                            case 2:
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(2);
                                break;
                            case 3:
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(3);
                                break;
                        }
                        // 28日以降は末日とする
                        if (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF")) >= 28)
                        {
                            PaymentmoneyDate = new DateTime(PaymentmoneyDate.Year, PaymentmoneyDate.Month, 1);
                            PaymentmoneyDate = PaymentmoneyDate.AddMonths(1);
                            PaymentmoneyDate = PaymentmoneyDate.AddDays(-1);
                        }
                        else
                        {
                            PaymentmoneyDate = new DateTime(PaymentmoneyDate.Year, PaymentmoneyDate.Month, SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF")));
                        }
                        suplierPayWork.PaymentSchedule = PaymentmoneyDate;　// 支払予定日


                        //suplierPayWork.Add(suplierPayWork);
                        #endregion

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }


        // --- ADD 2012/09/11 ----------->>>>>
        /// <summary>
        /// 仕入先マスタから計上拠点別支払処理結果取得用の更新情報を取得します
        /// </summary>
        /// <param name="suplierPayWork">仕入先支払金額マスタ更新パラメータ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタから計上拠点別支払処理結果取得用の更新情報を取得します</br>
        /// <br>Programmer : FSI佐々木　貴英</br>
        /// <br>Date       : 2012.09.11</br>
        /// </remarks>
        private int GetIndivSupplierByAddUpSecCode(ref SuplierPayWork suplierPayWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            //仕入先マスタ
            //SupplierWork supplierWork = null;

            string sqlText = string.Empty;

            DateTime TaxRateStartDateRF = DateTime.MinValue; //税率開始日
            DateTime TaxRateEndDateRF = DateTime.MinValue; //税率終了日
            DateTime TaxRateStartDate2RF = DateTime.MinValue; //税率2開始日
            DateTime TaxRateEndDate2RF = DateTime.MinValue; //税率2終了日
            DateTime TaxRateStartDate3RF = DateTime.MinValue; //税率3開始日
            DateTime TaxRateEndDate3RF = DateTime.MinValue; //税率3終了日

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    sqlText = string.Empty;

                    #region [ SELECT ]
                    sqlText += "SELECT " + Environment.NewLine;
                    sqlText += "     SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERCDRF  " + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTSECTIONCODERF AS ADDUPSECCODERF " + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERNM1RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERNM2RF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERCDRF  AS PAYEECODERF " + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERNM1RF AS PAYEENAMERF " + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERNM2RF AS PAYEENAME2RF " + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPLIERSNMRF AS PAYEESNMRF " + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTTOTALDAYRF AS PAYMENTTOTALDAYRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.SUPPCTAXLAYCDRF AS SUPPCTAXLAYCDRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTCONDRF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTMONTHCODERF" + Environment.NewLine;
                    sqlText += "    ,SUPPLIER.PAYMENTDAYRF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATESTARTDATERF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATEENDDATERF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATERF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATESTARTDATE2RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATEENDDATE2RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATE2RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATESTARTDATE3RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATEENDDATE3RF" + Environment.NewLine;
                    sqlText += "    ,TAX.TAXRATE3RF" + Environment.NewLine;
                    sqlText += "    ,PROCMONEY.FRACTIONPROCCDRF    " + Environment.NewLine;
                    sqlText += "FROM SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED)" + Environment.NewLine;
                    #endregion

                    #region [ JOIN句 ]
                    // 税率マスタ
                    sqlText += "LEFT JOIN TAXRATESETRF AS TAX WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "  ON SUPPLIER.ENTERPRISECODERF=TAX.ENTERPRISECODERF" + Environment.NewLine;
                    // 仕入金額処理区分設定マスタ
                    sqlText += "LEFT JOIN STOCKPROCMONEYRF AS PROCMONEY WITH(READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "  ON SUPPLIER.ENTERPRISECODERF=PROCMONEY.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND PROCMONEY.FRACPROCMONEYDIVRF=1" + Environment.NewLine;
                    sqlText += "  AND SUPPLIER.STOCKCNSTAXFRCPROCCDRF=PROCMONEY.FRACTIONPROCCODERF" + Environment.NewLine;
                    #endregion

                    #region [ WHERE句 ]
                    sqlText += "WHERE SUPPLIER.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND SUPPLIER.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                    sqlText += "  AND SUPPLIER.LOGICALDELETECODERF=0" + Environment.NewLine;
                    #endregion

                    sqlCommand.CommandText = sqlText;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SupplierCd);

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {

                        #region 結果セット
                        //●画面パラメータからセット
                        suplierPayWork.AddUpDate = suplierPayWork.AddUpDate;     　　　　                                         // 計上年月日
                        suplierPayWork.AddUpYearMonth = suplierPayWork.AddUpYearMonth;                                            // 計上年月
                        suplierPayWork.EnterpriseCode = suplierPayWork.EnterpriseCode;
                        suplierPayWork.AddUpSecCode = suplierPayWork.AddUpSecCode;                                                // 計上拠点コード
                        suplierPayWork.ResultsSectCd = suplierPayWork.AddUpSecCode;                                               // 実績計上拠点コード

                        //●抽出結果からセット
                        suplierPayWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));           // 支払先コード
                        suplierPayWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));          //       名称1
                        suplierPayWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));        //       名称2
                        suplierPayWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));            //　　　 略称 　　
                        suplierPayWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));         // 仕入先コード
                        suplierPayWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));      //       名称1
                        suplierPayWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));      //       名称2
                        suplierPayWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));      //       略称
                        suplierPayWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));   　　// 支払条件　
                        suplierPayWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));   // 支払先消費税転嫁方式
                        suplierPayWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); // 端数処理区分

                        // 税率設定開始終了期間で税率を決定
                        TaxRateStartDateRF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATERF"));          // 税率開始日
                        TaxRateEndDateRF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATERF"));              // 税率終了日
                        TaxRateStartDate2RF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE2RF"));        // 税率2開始日
                        TaxRateEndDate2RF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE2RF"));            // 税率2終了日
                        TaxRateStartDate3RF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE3RF"));        // 税率3開始日
                        TaxRateEndDate3RF = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE3RF"));            // 税率3終了日

                        if (TaxRateStartDateRF <= suplierPayWork.AddUpDate && suplierPayWork.AddUpDate <= TaxRateEndDateRF)
                        {
                            // 税率1
                            suplierPayWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATERF"));
                        }
                        else if (TaxRateStartDate2RF <= suplierPayWork.AddUpDate && suplierPayWork.AddUpDate <= TaxRateEndDate2RF)
                        {
                            //税率2
                            suplierPayWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE2RF"));
                        }
                        else if (TaxRateStartDate3RF <= suplierPayWork.AddUpDate && suplierPayWork.AddUpDate <= TaxRateEndDate3RF)
                        {
                            //税率3
                            suplierPayWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE3RF"));
                        }
                        suplierPayWork.UpdateStatus = 0;   //更新ステータス

                        // 支払予定日算出
                        DateTime PaymentmoneyDate = suplierPayWork.AddUpDate;
                        switch (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONTHCODERF"))) // 0:当月,1:翌月,2:翌々月,3翌々々月
                        {
                            case 1:
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(1);
                                break;
                            case 2:
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(2);
                                break;
                            case 3:
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(3);
                                break;
                        }
                        // 28日以降は末日とする
                        if (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF")) >= 28)
                        {
                            PaymentmoneyDate = new DateTime(PaymentmoneyDate.Year, PaymentmoneyDate.Month, 1);
                            PaymentmoneyDate = PaymentmoneyDate.AddMonths(1);
                            PaymentmoneyDate = PaymentmoneyDate.AddDays(-1);
                        }
                        else
                        {
                            PaymentmoneyDate = new DateTime(PaymentmoneyDate.Year, PaymentmoneyDate.Month, SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF")));
                        }
                        suplierPayWork.PaymentSchedule = PaymentmoneyDate;　// 支払予定日


                        #endregion

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }

        // --- ADD 2012/09/11 -----------<<<<<
        #endregion

        #region [仕入金額処理区分設定マスタ]
        /// <summary>
        /// 仕入金額処理区分設定マスタから端数処理区分を取得します
        /// </summary>
        /// <param name="suplierPayWork">仕入先支払金額マスタ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入金額処理区分設定マスタから端数処理区分を取得します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int GetSupplTaxAndFrac(ref SuplierPayWork suplierPayWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            string sqlText = string.Empty;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    // 2008.07.24 upd start ------------------------------>>
                    //sqlCommand.CommandText = "SELECT FRACTIONPROCCDRF FROM STOCKPROCMONEYRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND FRACPROCMONEYDIVRF=1 AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE ";
                    sqlText = string.Empty;
                    sqlText += "SELECT " + Environment.NewLine;
                    sqlText += "    FRACTIONPROCCDRF" + Environment.NewLine;
                    sqlText += " FROM STOCKPROCMONEYRF" + Environment.NewLine;
                    sqlText += " WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND FRACPROCMONEYDIVRF=1" + Environment.NewLine;
                    sqlText += "    AND FRACTIONPROCCODERF=@FINDFRACTIONPROCCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    // 2008.07.24 upd end --------------------------------<<

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // ↓ 2007.09.14 980081 c
                    //SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaFractionProcCode = sqlCommand.Parameters.Add("@FINDFRACTIONPROCCODE", SqlDbType.Int);
                    // ↑ 2007.09.14 980081 c

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    // ↓ 2007.09.14 980081 c
                    //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.CustomerCode);
                    findParaFractionProcCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.FractionProcCd);
                    // ↑ 2007.09.14 980081 c

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //if (suplierPayWork.SuppCTaxRateRefCd == 1)
                        //{
                            //仕入金額処理区分設定マスタからデータセット
                            suplierPayWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
                        //}

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    #region 旧レイアウト(コメントアウト)
                    // del 2007.06.04 saito
                    //else
                    //{
                        //存在しなければ仕入在庫全体設定マスタから取得する
                    //    suplierPayWork.FractionProcCd = 99;
                    //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    //}
                    // del 2007.06.04 saito
                    #endregion
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }
        #endregion

        #region [仕入在庫全体設定マスタ]
        /// <summary>
        /// 仕入在庫全体設定マスタから仕入先消費税税率を取得します
        /// </summary>
        /// <param name="suplierPayWork">仕入先支払金額ワーク</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入在庫全体設定マスタから仕入先消費税税率を取得します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int GetStockTtlSt(ref SuplierPayWork suplierPayWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            //仕入在庫全体設定マスタ
            StockTtlStWork stockTtlStWork = null;

            string sqlText = string.Empty;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    // 2008.07.24 upd start ---------------------------------------->>
                    //sqlCommand.CommandText = "SELECT * FROM STOCKTTLSTRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKALLSTMNGCDRF=0 ";
                    sqlText = string.Empty;
                    sqlText += "SELECT *" + Environment.NewLine;
                    sqlText += " FROM STOCKTTLSTRF WITH" + Environment.NewLine;
                    sqlText += "    (READUNCOMMITTED" + Environment.NewLine;
                    sqlText += "    )" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    // 2008.07.24 upd end ------------------------------------------<<

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        stockTtlStWork = new StockTtlStWork();

                        //仕入在庫全体設定マスタからデータセット
                        stockTtlStWork = CopyToStockTtlStWorkFromReader(ref myReader);

                        if (suplierPayWork.SuppCTaxRateRefCd == 0)
                        {
                            // ↓ 2007.09.14 980081 d stockTtlStWork.ConsTaxFracProcDiv削除対応
                            ////●端数処理区分
                            //suplierPayWork.FractionProcCd = stockTtlStWork.ConsTaxFracProcDiv;
                            // ↑ 2007.09.14 980081 d
                            
                            // 2008.07.24 del start --------------------------------->>
                            //●仕入先消費税税率
                            //if (suplierPayWork.AddUpDate <= stockTtlStWork.ValidDtConsTaxRate1)
                            //{
                            //    suplierPayWork.SupplierConsTaxRate = stockTtlStWork.ConsTaxRate1;
                            //}
                            //else if ((suplierPayWork.AddUpDate > stockTtlStWork.ValidDtConsTaxRate1) &&
                            //        (suplierPayWork.AddUpDate <= stockTtlStWork.ValidDtConsTaxRate2))
                            //{
                            //    suplierPayWork.SupplierConsTaxRate = stockTtlStWork.ConsTaxRate2;
                            //}
                            //else if ((suplierPayWork.AddUpDate > stockTtlStWork.ValidDtConsTaxRate2) &&
                            //        (suplierPayWork.AddUpDate <= stockTtlStWork.ValidDtConsTaxRate3))
                            //{
                            //    suplierPayWork.SupplierConsTaxRate = stockTtlStWork.ConsTaxRate3;
                            //}
                            //else
                            //{
                            //    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                            //}
                            // 2008.07.24 del end -----------------------------------<<
                        }

                        // 2008.07.24 del start --------------------------------->>
                        //●仕入先総額表示方法区分
                        //if (suplierPayWork.StckTtlAmntDspWayRef == 0)
                        //{
                        //    suplierPayWork.SuppTtlAmntDspWayCd = stockTtlStWork.TotalAmountDispWayCd;
                        //}
                        // 2008.07.24 del end -----------------------------------<<

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }
        #endregion

        #region [前回情報取得 支払締更新履歴マスタ 仕入先支払金額マスタ]
        /// <summary>
        /// 前回情報取得　支払締更新履歴マスタ/仕入先支払金額マスタ
        /// </summary>
        /// <param name="suplierPayWork">支払金額マスタワーク用クラス</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 前回情報取得　支払締更新履歴マスタ仕入先支払金額マスタ</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int GetPaymentAddUpHisAndSuplierPay(ref SuplierPayWork suplierPayWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            string sqlText = string.Empty;   // 2008.07.24 add
            Int64 thisTimePayNrml = 0;       // 2008.07.24 add 今回支払金額  
            Int64 payment1 = 0;              // 2008.07.24 add 支払金額① 
            Int64 payment2 = 0;              // 2008.07.24 add 支払金額②
            Int64 lastTimePayment = 0;       // 2008.07.24 add 前回支払金額
            Int64 stockTtl2TmBfBlPay = 0;    // 2008.07.24 add 前々回支払金額
            Int64 stockTtl3TmBfBlPay = 0;    // 2008.07.24 add 前前々回支払金額

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    #region [Select文作成]
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  THISTIMEPAYNRMLRF" + Environment.NewLine;
                    sqlText += "  ,STOCKTOTALPAYBALANCERF" + Environment.NewLine;
                    sqlText += "  ,LASTTIMEPAYMENTRF" + Environment.NewLine;
                    sqlText += "  ,STOCKTTL2TMBFBLPAYRF" + Environment.NewLine;
                    sqlText += "  ,STOCKTTL3TMBFBLPAYRF" + Environment.NewLine;
                    sqlText += "  ,ADDUPDATERF" + Environment.NewLine;
                    sqlText += "  ,OFSTHISTIMESTOCKRF" + Environment.NewLine;
                    sqlText += "  ,OFSTHISSTOCKTAXRF" + Environment.NewLine;
                    sqlText += " FROM SUPLIERPAYRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND PAYEECODERF=@FINDSUPPLIERCD" + Environment.NewLine;
                    //sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;  // DEL 2010/10/06
                    sqlText += "  AND RESULTSSECTCDRF='00'" + Environment.NewLine;  // ADD 2010/11/24
                    sqlText += "  AND SUPPLIERCDRF=0" + Environment.NewLine;      // ADD 2010/11/24
                    sqlText += "  AND ADDUPDATERF=" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    sqlText += " SELECT MAX(ADDUPDATERF)" + Environment.NewLine;
                    sqlText += " FROM SUPLIERPAYRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND PAYEECODERF=@FINDSUPPLIERCD" + Environment.NewLine;
                    //sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine; // DEL 2010/10/06
                    sqlText += "  AND RESULTSSECTCDRF='00'" + Environment.NewLine;  // ADD 2010/11/24
                    sqlText += "  AND SUPPLIERCDRF=0" + Environment.NewLine;      // ADD 2010/11/24
                    sqlText += "  AND ADDUPDATERF<@FINDADDUPDATE" + Environment.NewLine; // ADD 2009/07/03 
                    sqlText += "  )" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Select文作成]

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    //SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);  // DEL 2010/10/06
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int); // ADD 2009/07/03

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                    //findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);  // DEL 2010/10/06
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate); // ADD 2009/07/03

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // 今回支払金額（通常支払）
                        thisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEPAYNRMLRF"));
                        // 仕入合計残高（支払計）
                        //lastTimePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPAYBALANCERF"));
                        lastTimePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSTOCKTAXRF"));
                        // 前回支払金額
                        stockTtl2TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEPAYMENTRF"));
                        // 仕入2回前残高（支払計）+ 仕入3回前残高（支払計）
                        stockTtl3TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL2TMBFBLPAYRF")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL3TMBFBLPAYRF"));

                        if (lastTimePayment == 0 && stockTtl2TmBfBlPay == 0 && stockTtl3TmBfBlPay == 0)
                        {
                            // 前回支払金額
                            suplierPayWork.LastTimePayment = lastTimePayment - thisTimePayNrml;
                        }
                        else
                        {
                            if (thisTimePayNrml > 0)
                            {
                                // 支払金額減算
                                if (stockTtl3TmBfBlPay - thisTimePayNrml >= 0)
                                {
                                    stockTtl3TmBfBlPay = stockTtl3TmBfBlPay - thisTimePayNrml;
                                }
                                else
                                {
                                    payment1 = thisTimePayNrml - stockTtl3TmBfBlPay;
                                    stockTtl3TmBfBlPay = 0;

                                    if (stockTtl2TmBfBlPay - payment1 >= 0)
                                    {
                                        stockTtl2TmBfBlPay = stockTtl2TmBfBlPay - payment1;
                                    }
                                    else
                                    {
                                        payment2 = payment1 - stockTtl2TmBfBlPay;
                                        stockTtl2TmBfBlPay = 0;
                                        lastTimePayment = lastTimePayment - payment2;
                                    }
                                }
                            }
                            else if (thisTimePayNrml < 0) // マイナス支払発生時の処理
                            {
                                // マイナス支払の場合、前回支払額に支払金額加算
                                //lastTimePayment = lastTimePayment - thisTimePayNrml;
                                if ((stockTtl3TmBfBlPay >= 0) && (stockTtl2TmBfBlPay >= 0))
                                {
                                    // マイナス支払の場合、前回支払額に支払金額加算
                                    lastTimePayment = lastTimePayment - thisTimePayNrml;
                                }
                                else if (stockTtl3TmBfBlPay < 0) // 3回前残がマイナスの場合
                                {
                                    if (stockTtl3TmBfBlPay - thisTimePayNrml <= 0)
                                    {
                                        stockTtl3TmBfBlPay = stockTtl3TmBfBlPay - thisTimePayNrml;
                                        lastTimePayment = lastTimePayment + stockTtl3TmBfBlPay + stockTtl2TmBfBlPay;
                                        stockTtl3TmBfBlPay = 0;
                                        stockTtl2TmBfBlPay = 0;
                                    }
                                    else
                                    {
                                        // --- UPD m.suzuki 2010/03/02 ---------->>>>>
                                        //payment1 = thisTimePayNrml + stockTtl3TmBfBlPay;
                                        payment1 = thisTimePayNrml - stockTtl3TmBfBlPay;
                                        // --- UPD m.suzuki 2010/03/02 ----------<<<<<
                                        stockTtl3TmBfBlPay = 0;

                                        if (stockTtl2TmBfBlPay < 0)
                                        {
                                            if (stockTtl2TmBfBlPay - payment1 <= 0)
                                            {
                                                stockTtl2TmBfBlPay = stockTtl2TmBfBlPay - payment1;
                                                lastTimePayment = lastTimePayment + stockTtl2TmBfBlPay;
                                                stockTtl2TmBfBlPay = 0;

                                            }
                                            else
                                            {
                                                payment2 = payment1 - stockTtl2TmBfBlPay;
                                                stockTtl2TmBfBlPay = 0;
                                                lastTimePayment = lastTimePayment - payment2;
                                            }
                                        }
                                        else
                                        {
                                            lastTimePayment = lastTimePayment - payment1;
                                        }
                                    }
                                }
                                else if (stockTtl2TmBfBlPay < 0)
                                {
                                    if (stockTtl2TmBfBlPay - thisTimePayNrml <= 0)
                                    {
                                        stockTtl2TmBfBlPay = stockTtl2TmBfBlPay - thisTimePayNrml;
                                        lastTimePayment = lastTimePayment + stockTtl2TmBfBlPay;
                                        stockTtl2TmBfBlPay = 0;
                                    }
                                    else
                                    {
                                        payment1 = thisTimePayNrml - stockTtl2TmBfBlPay;
                                        stockTtl2TmBfBlPay = 0;
                                        lastTimePayment = lastTimePayment - payment1;
                                    }
                                }

                            }
                            // 前回支払金額
                            suplierPayWork.LastTimePayment = lastTimePayment;
                            // 仕入2回前残高（支払計）
                            suplierPayWork.StockTtl2TmBfBlPay = stockTtl2TmBfBlPay;
                            // 仕入3回前残高（支払計）
                            suplierPayWork.StockTtl3TmBfBlPay = stockTtl3TmBfBlPay;
                        }

                        //前回締次更新年月日　←　計上年月日
                        suplierPayWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
                        //締次更新開始年月日
                        suplierPayWork.StartCAddUpUpdDate = suplierPayWork.LastCAddUpUpdDate.AddDays(1.0);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }

        // --- ADD 2012/09/11 ----------->>>>>
        /// <summary>
        /// 計上拠点別前回情報取得　支払締更新履歴マスタ/仕入先支払金額マスタ
        /// </summary>
        /// <param name="suplierPayWork">支払金額マスタワーク用クラス</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払締更新履歴マスタおよび仕入先支払金額マスタから計上拠点別前回情報取得を取得します</br>
        /// <br>Programmer : FSI佐々木　貴英</br>
        /// <br>Date       : 2012/09/11</br>
        /// </remarks>
        private int GetPaymentAddUpHisAndSuplierPayByAddUpSecCode(ref SuplierPayWork suplierPayWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            string sqlText = string.Empty;
            Int64 thisTimePayNrml = 0;
            Int64 payment1 = 0;
            Int64 payment2 = 0;
            Int64 lastTimePayment = 0;
            Int64 stockTtl2TmBfBlPay = 0;
            Int64 stockTtl3TmBfBlPay = 0;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    #region [Select文作成]
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  THISTIMEPAYNRMLRF" + Environment.NewLine;
                    sqlText += "  ,STOCKTOTALPAYBALANCERF" + Environment.NewLine;
                    sqlText += "  ,LASTTIMEPAYMENTRF" + Environment.NewLine;
                    sqlText += "  ,STOCKTTL2TMBFBLPAYRF" + Environment.NewLine;
                    sqlText += "  ,STOCKTTL3TMBFBLPAYRF" + Environment.NewLine;
                    sqlText += "  ,ADDUPDATERF" + Environment.NewLine;
                    sqlText += "  ,OFSTHISTIMESTOCKRF" + Environment.NewLine;
                    sqlText += "  ,OFSTHISSTOCKTAXRF" + Environment.NewLine;
                    sqlText += " FROM SUPLIERPAYRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND PAYEECODERF=@FINDSUPPLIERCD" + Environment.NewLine;
                    sqlText += "  AND RESULTSSECTCDRF='00'" + Environment.NewLine;
                    sqlText += "  AND SUPPLIERCDRF=0" + Environment.NewLine;
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "  AND ADDUPDATERF=" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    sqlText += " SELECT MAX(ADDUPDATERF)" + Environment.NewLine;
                    sqlText += " FROM SUPLIERPAYRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND PAYEECODERF=@FINDSUPPLIERCD" + Environment.NewLine;
                    sqlText += "  AND RESULTSSECTCDRF='00'" + Environment.NewLine;
                    sqlText += "  AND SUPPLIERCDRF=0" + Environment.NewLine;
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "  AND ADDUPDATERF<@FINDADDUPDATE" + Environment.NewLine; 
                    sqlText += "  )" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Select文作成]

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SupplierCd);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // 今回支払金額（通常支払）
                        thisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEPAYNRMLRF"));
                        // 仕入合計残高（支払計）
                        lastTimePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSTOCKTAXRF"));
                        // 前回支払金額
                        stockTtl2TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEPAYMENTRF"));
                        // 仕入2回前残高（支払計）+ 仕入3回前残高（支払計）
                        stockTtl3TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL2TMBFBLPAYRF")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL3TMBFBLPAYRF"));

                        if (lastTimePayment == 0 && stockTtl2TmBfBlPay == 0 && stockTtl3TmBfBlPay == 0)
                        {
                            // 前回支払金額
                            suplierPayWork.LastTimePayment = lastTimePayment - thisTimePayNrml;
                        }
                        else
                        {
                            if (thisTimePayNrml > 0)
                            {
                                // 支払金額減算
                                if (stockTtl3TmBfBlPay - thisTimePayNrml >= 0)
                                {
                                    stockTtl3TmBfBlPay = stockTtl3TmBfBlPay - thisTimePayNrml;
                                }
                                else
                                {
                                    payment1 = thisTimePayNrml - stockTtl3TmBfBlPay;
                                    stockTtl3TmBfBlPay = 0;

                                    if (stockTtl2TmBfBlPay - payment1 >= 0)
                                    {
                                        stockTtl2TmBfBlPay = stockTtl2TmBfBlPay - payment1;
                                    }
                                    else
                                    {
                                        payment2 = payment1 - stockTtl2TmBfBlPay;
                                        stockTtl2TmBfBlPay = 0;
                                        lastTimePayment = lastTimePayment - payment2;
                                    }
                                }
                            }
                            else if (thisTimePayNrml < 0) // マイナス支払発生時の処理
                            {
                                // マイナス支払の場合、前回支払額に支払金額加算
                                //lastTimePayment = lastTimePayment - thisTimePayNrml;
                                if ((stockTtl3TmBfBlPay >= 0) && (stockTtl2TmBfBlPay >= 0))
                                {
                                    // マイナス支払の場合、前回支払額に支払金額加算
                                    lastTimePayment = lastTimePayment - thisTimePayNrml;
                                }
                                else if (stockTtl3TmBfBlPay < 0) // 3回前残がマイナスの場合
                                {
                                    if (stockTtl3TmBfBlPay - thisTimePayNrml <= 0)
                                    {
                                        stockTtl3TmBfBlPay = stockTtl3TmBfBlPay - thisTimePayNrml;
                                        lastTimePayment = lastTimePayment + stockTtl3TmBfBlPay + stockTtl2TmBfBlPay;
                                        stockTtl3TmBfBlPay = 0;
                                        stockTtl2TmBfBlPay = 0;
                                    }
                                    else
                                    {
                                        payment1 = thisTimePayNrml - stockTtl3TmBfBlPay;
                                        stockTtl3TmBfBlPay = 0;

                                        if (stockTtl2TmBfBlPay < 0)
                                        {
                                            if (stockTtl2TmBfBlPay - payment1 <= 0)
                                            {
                                                stockTtl2TmBfBlPay = stockTtl2TmBfBlPay - payment1;
                                                lastTimePayment = lastTimePayment + stockTtl2TmBfBlPay;
                                                stockTtl2TmBfBlPay = 0;

                                            }
                                            else
                                            {
                                                payment2 = payment1 - stockTtl2TmBfBlPay;
                                                stockTtl2TmBfBlPay = 0;
                                                lastTimePayment = lastTimePayment - payment2;
                                            }
                                        }
                                        else
                                        {
                                            lastTimePayment = lastTimePayment - payment1;
                                        }
                                    }
                                }
                                else if (stockTtl2TmBfBlPay < 0)
                                {
                                    if (stockTtl2TmBfBlPay - thisTimePayNrml <= 0)
                                    {
                                        stockTtl2TmBfBlPay = stockTtl2TmBfBlPay - thisTimePayNrml;
                                        lastTimePayment = lastTimePayment + stockTtl2TmBfBlPay;
                                        stockTtl2TmBfBlPay = 0;
                                    }
                                    else
                                    {
                                        payment1 = thisTimePayNrml - stockTtl2TmBfBlPay;
                                        stockTtl2TmBfBlPay = 0;
                                        lastTimePayment = lastTimePayment - payment1;
                                    }
                                }

                            }
                            // 前回支払金額
                            suplierPayWork.LastTimePayment = lastTimePayment;
                            // 仕入2回前残高（支払計）
                            suplierPayWork.StockTtl2TmBfBlPay = stockTtl2TmBfBlPay;
                            // 仕入3回前残高（支払計）
                            suplierPayWork.StockTtl3TmBfBlPay = stockTtl3TmBfBlPay;
                        }

                        //前回締次更新年月日　←　計上年月日
                        suplierPayWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
                        //締次更新開始年月日
                        suplierPayWork.StartCAddUpUpdDate = suplierPayWork.LastCAddUpUpdDate.AddDays(1.0);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }
        // --- ADD 2012/09/11 -----------<<<<<

        #endregion

        #region [支払締更新履歴マスタ(更新可否チェック)]
        /// <summary>
        /// 支払締更新履歴マスタのチェック
        /// </summary>
        /// <param name="suplierPayWork">支払金額マスタ更新パラメータ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払締更新履歴マスタのチェック</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>s
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int CheckPaymentAddUpHis(ref SuplierPayWork suplierPayWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            string sqlText = string.Empty; // 2008.07.24 add

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    #region [Select文作成]
                    sqlText = string.Empty;
                    sqlText += "SELECT *" + Environment.NewLine;
                    sqlText += " FROM PAYMENTADDUPHISRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "  AND CADDUPUPDDATERF>=@FINDADDUPDATE" + Environment.NewLine;
                    sqlText += "  AND PROCDIVCDRF=0" + Environment.NewLine;
                    sqlText += "  AND HISTCTLCDRF=0" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Select文作成]

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);　
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //未更新ステータス挿入
                        suplierPayWork.UpdateStatus = 1;

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        //更新ステータス挿入
                        suplierPayWork.UpdateStatus = 0;

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }

        /// <summary>
        /// 支払締更新履歴マスタのチェック
        /// </summary>
        /// <param name="suplierPayWork">支払金額マスタ更新パラメータ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払締更新履歴マスタのチェック</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>s
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int CheckSuplierPay(ref SuplierPayWork suplierPayWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            string sqlText = string.Empty; // 2008.07.24 add

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    #region [Select文作成]
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += " *" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += " SUPLIERPAYRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "  AND ADDUPDATERF>=@FINDADDUPDATE" + Environment.NewLine;
                    sqlText += "  AND PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                    sqlText += "  AND SUPPLIERCDRF=0" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Select文作成]

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                    myReader = sqlCommand.ExecuteReader();

                    //更新ステータス挿入
                    if (suplierPayWork.UpdateStatus != 1)
                    {
                        suplierPayWork.UpdateStatus = 0;
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    if (myReader.Read())
                    {
                        //未更新ステータス挿入
                        suplierPayWork.UpdateStatus = 1;

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }

        #endregion

        #region [支払伝票マスタ]
        /// <summary>
        /// 仕入先支払金額ワーク用Listから支払伝票マスタを取得します
        /// </summary>
        /// <param name="suplierPayWork">仕入先支払金額マスタ更新List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額ワーク用Listから支払伝票マスタを取得します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int GetPaymentSlp(ref SuplierPayWork suplierPayWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;

            string sqlText = string.Empty;

            try
            {
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "PAYEECODERF," + Environment.NewLine;
                sqlText += "SUM(PAYMENTTOTALRF) AS PAYMENTTOTALRF," + Environment.NewLine;
                sqlText += "SUM(FEEPAYMENTRF) AS FEEPAYMENTRF," + Environment.NewLine;
                sqlText += "SUM(DISCOUNTPAYMENTRF) AS DISCOUNTPAYMENTRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "PAYMENTSLPRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND PAYEECODERF=@FINDSUPPLIERCD" + Environment.NewLine;    
                //sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine; // DEL 2010/10/06
                sqlText += "    AND ( ADDUPADATERF<=@FINDADDUPDATE AND ADDUPADATERF>@FINDLASTTIMEADDUPDATE )" + Environment.NewLine;
                sqlText += "    AND LOGICALDELETECODERF = 0" + Environment.NewLine; // ADD 2009/04/24
                sqlText += "GROUP BY " + Environment.NewLine;
                sqlText += "ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "PAYEECODERF" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    //SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar); DEL 2010/10/06
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                    //findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode); // DEL 2010/10/06
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);
                    if (suplierPayWork.LastCAddUpUpdDate == DateTime.MinValue)
                        findParaLastTimeAddUpDate.Value = 20000101;
                    else
                        findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.LastCAddUpUpdDate);

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        suplierPayWork.ThisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));      // 今回支払金額
                        suplierPayWork.ThisTimeFeePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));     // 今回手数料金額
                        suplierPayWork.ThisTimeDisPayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));// 今回値引金額 
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }

        // --- ADD 2012/09/11 ----------->>>>>
        /// <summary>
        /// 仕入先支払金額ワーク用Listから計上拠点別に支払伝票マスタを取得します
        /// </summary>
        /// <param name="suplierPayWork">支払金額マスタワーク用クラス</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額ワーク用Listから計上拠点別に支払伝票マスタを取得します</br>
        /// <br>Programmer : FSI佐々木　貴英</br>
        /// <br>Date       : 2012.09.11</br>
        /// </remarks>
        private int GetPaymentSlpByAddUpSecCode(ref SuplierPayWork suplierPayWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;

            string sqlText = string.Empty;

            try
            {
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "PAYEECODERF," + Environment.NewLine;
                sqlText += "ADDUPSECCODERF," + Environment.NewLine;
                sqlText += "SUM(PAYMENTTOTALRF) AS PAYMENTTOTALRF," + Environment.NewLine;
                sqlText += "SUM(FEEPAYMENTRF) AS FEEPAYMENTRF," + Environment.NewLine;
                sqlText += "SUM(DISCOUNTPAYMENTRF) AS DISCOUNTPAYMENTRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "PAYMENTSLPRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND PAYEECODERF=@FINDSUPPLIERCD" + Environment.NewLine;
                sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                sqlText += "    AND ( ADDUPADATERF<=@FINDADDUPDATE AND ADDUPADATERF>@FINDLASTTIMEADDUPDATE )" + Environment.NewLine;
                sqlText += "    AND LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "GROUP BY " + Environment.NewLine;
                sqlText += "ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "PAYEECODERF," + Environment.NewLine;
                sqlText += "ADDUPSECCODERF" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SupplierCd);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);
                    if (suplierPayWork.LastCAddUpUpdDate == DateTime.MinValue)
                        findParaLastTimeAddUpDate.Value = 20000101;
                    else
                        findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.LastCAddUpUpdDate);

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        suplierPayWork.ThisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));      // 今回支払金額
                        suplierPayWork.ThisTimeFeePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));     // 今回手数料金額
                        suplierPayWork.ThisTimeDisPayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));// 今回値引金額 
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }
        // --- ADD 2012/09/11 -----------<<<<<

        #endregion

        #region [支払明細データ]
        /// <summary>
        /// 仕入先支払金額ワーク用Listから支払明細データを取得します
        /// </summary>
        /// <param name="suplierPayWork">仕入先支払金額マスタ更新List</param>
        /// <param name="accPayTotalWorkList">精算支払集計データ更新List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額ワーク用Listから支払明細データを取得します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.07.24</br>
        /// </remarks>
        private int GetPaymentDtlMain(ref SuplierPayWork suplierPayWork, ref ArrayList accPayTotalWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //int moneyKindCode = 0;

            List<AccPayTotalWork> accPayTotalList = new List<AccPayTotalWork>();   // データ格納用

            SqlDataReader myReader = null;

            string sqlText = string.Empty;
            sqlText += "SELECT" + Environment.NewLine;
            sqlText += "  PAY.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += " ,PAY.PAYEECODERF" + Environment.NewLine;
            sqlText += " ,PAY.MONEYKINDCODERF" + Environment.NewLine;
            sqlText += " ,(CASE WHEN MONEYKIND.MONEYKINDNAMERF IS NOT NULL THEN MONEYKIND.MONEYKINDNAMERF ELSE '未登録' END) AS MONEYKINDNAMERF" + Environment.NewLine;
            sqlText += " ,(CASE WHEN MONEYKIND.MONEYKINDDIVRF IS NOT NULL THEN MONEYKIND.MONEYKINDDIVRF ELSE 0 END) AS MONEYKINDDIVRF" + Environment.NewLine;
            sqlText += " ,PAY.PAYMENTRF" + Environment.NewLine;
            sqlText += "FROM" + Environment.NewLine;
            sqlText += "(" + Environment.NewLine;
            sqlText += "  SELECT" + Environment.NewLine;
            sqlText += "    PAYMENTS.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "   ,PAYMENTS.PAYEECODERF" + Environment.NewLine;
            sqlText += "   ,PAYMENTDTL.MONEYKINDCODERF" + Environment.NewLine;
            // 修正 2009.01.16 >>>
            //sqlText += "   ,SUM(PAYMENTDTL.PAYMENTRF) AS PAYMENTRF" + Environment.NewLine;
            sqlText += "   ,SUM((CASE WHEN PAYMENTS.DEBITNOTEDIVRF = 1 THEN PAYMENTDTL.PAYMENTRF * -1 ELSE PAYMENTDTL.PAYMENTRF END))AS PAYMENTRF" + Environment.NewLine;
            // 修正 2009.01.16 <<<
            sqlText += "  FROM PAYMENTSLPRF AS PAYMENTS" + Environment.NewLine;
            sqlText += "  INNER JOIN PAYMENTDTLRF AS PAYMENTDTL " + Environment.NewLine;
            sqlText += "   ON PAYMENTDTL.ENTERPRISECODERF= PAYMENTS.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "   AND PAYMENTDTL.SUPPLIERFORMALRF= PAYMENTS.SUPPLIERFORMALRF" + Environment.NewLine;
            // 修正 2009.01.16 >>>
            //sqlText += "   AND PAYMENTDTL.PAYMENTSLIPNORF= PAYMENTS.PAYMENTSLIPNORF" + Environment.NewLine;
            sqlText += "   AND ((PAYMENTS.DEBITNOTEDIVRF != 1 AND PAYMENTS.PAYMENTSLIPNORF = PAYMENTDTL.PAYMENTSLIPNORF) OR" + Environment.NewLine;
            sqlText += "        (PAYMENTS.DEBITNOTEDIVRF = 1 AND PAYMENTS.DEBITNOTELINKPAYNORF = PAYMENTDTL.PAYMENTSLIPNORF))" + Environment.NewLine;
            // 修正 2009.01.16 <<<
            sqlText += "  WHERE PAYMENTS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "   AND PAYMENTS.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
            sqlText += "   AND (PAYMENTS.ADDUPADATERF<=@FINDADDUPDATE AND PAYMENTS.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)   " + Environment.NewLine;
            sqlText += "   AND PAYMENTS.LOGICALDELETECODERF = 0" + Environment.NewLine; // ADD 2009/04/24
            sqlText += "  GROUP BY" + Environment.NewLine;
            sqlText += "    PAYMENTS.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "   ,PAYMENTS.PAYEECODERF" + Environment.NewLine;
            sqlText += "   ,PAYMENTDTL.MONEYKINDCODERF" + Environment.NewLine;
            sqlText += ") AS PAY" + Environment.NewLine;
            sqlText += "LEFT JOIN MONEYKINDURF AS MONEYKIND" + Environment.NewLine;
            sqlText += " ON PAY.ENTERPRISECODERF = MONEYKIND.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += " AND PAY.MONEYKINDCODERF = MONEYKIND.MONEYKINDCODERF" + Environment.NewLine;
            // 修正 2008.12.17 <<< 


            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);
                    if (suplierPayWork.LastCAddUpUpdDate == DateTime.MinValue)
                        findParaLastTimeAddUpDate.Value = 20000101;
                    else
                        findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.LastCAddUpUpdDate);

                    AccPayTotalWork accPayTotalWork = new AccPayTotalWork();

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        accPayTotalWork = new AccPayTotalWork();
                        accPayTotalWork = CopyToAccPayTotalWorkFromReader(ref myReader);
                        // 修正 2009.01.16 >>>
                        if (accPayTotalWork.Payment == 0)
                        {
                            continue;
                        }
                        // 修正 2009.01.16 <<<

                        accPayTotalWork.AddUpSecCode = suplierPayWork.AddUpSecCode;
                        accPayTotalWork.AddUpDate = suplierPayWork.AddUpDate;
                        accPayTotalWork.SupplierCd = suplierPayWork.SupplierCd;
                        accPayTotalWorkList.Add(accPayTotalWork);
                    }
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
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }

        // --- ADD 2012/09/11 ----------->>>>>
        /// <summary>
        /// 仕入先支払金額ワーク用Listから支払拠点別に支払明細データを取得します
        /// </summary>
        /// <param name="suplierPayWork">仕入先支払金額マスタ更新List</param>
        /// <param name="accPayTotalWorkList">精算支払集計データ更新List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額ワーク用Listから支払拠点別に支払明細データを取得します</br>
        /// <br>Programmer : FSI佐々木　貴英</br>
        /// <br>Date       : 2012/09/11</br>
        /// </remarks>
        private int GetPaymentDtlMainByAddUpSecCode(ref SuplierPayWork suplierPayWork, ref ArrayList accPayTotalWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            List<AccPayTotalWork> accPayTotalList = new List<AccPayTotalWork>();   // データ格納用

            SqlDataReader myReader = null;

            string sqlText = string.Empty;
            sqlText += "SELECT" + Environment.NewLine;
            sqlText += "  PAY.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += " ,PAY.PAYEECODERF" + Environment.NewLine;
            sqlText += " ,PAY.MONEYKINDCODERF" + Environment.NewLine;
            sqlText += " ,PAY.ADDUPSECCODERF" + Environment.NewLine;
            sqlText += " ,(CASE WHEN MONEYKIND.MONEYKINDNAMERF IS NOT NULL THEN MONEYKIND.MONEYKINDNAMERF ELSE '未登録' END) AS MONEYKINDNAMERF" + Environment.NewLine;
            sqlText += " ,(CASE WHEN MONEYKIND.MONEYKINDDIVRF IS NOT NULL THEN MONEYKIND.MONEYKINDDIVRF ELSE 0 END) AS MONEYKINDDIVRF" + Environment.NewLine;
            sqlText += " ,PAY.PAYMENTRF" + Environment.NewLine;
            sqlText += "FROM" + Environment.NewLine;
            sqlText += "(" + Environment.NewLine;
            sqlText += "  SELECT" + Environment.NewLine;
            sqlText += "    PAYMENTS.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "   ,PAYMENTS.PAYEECODERF" + Environment.NewLine;
            sqlText += "   ,PAYMENTDTL.MONEYKINDCODERF" + Environment.NewLine;
            sqlText += "   ,PAYMENTS.ADDUPSECCODERF" + Environment.NewLine;
            sqlText += "   ,SUM((CASE WHEN PAYMENTS.DEBITNOTEDIVRF = 1 THEN PAYMENTDTL.PAYMENTRF * -1 ELSE PAYMENTDTL.PAYMENTRF END))AS PAYMENTRF" + Environment.NewLine;
            sqlText += "  FROM PAYMENTSLPRF AS PAYMENTS" + Environment.NewLine;
            sqlText += "  INNER JOIN PAYMENTDTLRF AS PAYMENTDTL " + Environment.NewLine;
            sqlText += "   ON PAYMENTDTL.ENTERPRISECODERF= PAYMENTS.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "   AND PAYMENTDTL.SUPPLIERFORMALRF= PAYMENTS.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "   AND ((PAYMENTS.DEBITNOTEDIVRF != 1 AND PAYMENTS.PAYMENTSLIPNORF = PAYMENTDTL.PAYMENTSLIPNORF) OR" + Environment.NewLine;
            sqlText += "        (PAYMENTS.DEBITNOTEDIVRF = 1 AND PAYMENTS.DEBITNOTELINKPAYNORF = PAYMENTDTL.PAYMENTSLIPNORF))" + Environment.NewLine;
            sqlText += "  WHERE PAYMENTS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "   AND PAYMENTS.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
            sqlText += "   AND (PAYMENTS.ADDUPADATERF<=@FINDADDUPDATE AND PAYMENTS.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)   " + Environment.NewLine;
            sqlText += "   AND PAYMENTS.LOGICALDELETECODERF = 0" + Environment.NewLine;
            sqlText += "   AND PAYMENTS.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
            sqlText += "  GROUP BY" + Environment.NewLine;
            sqlText += "    PAYMENTS.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "   ,PAYMENTS.PAYEECODERF" + Environment.NewLine;
            sqlText += "   ,PAYMENTDTL.MONEYKINDCODERF" + Environment.NewLine;
            sqlText += "   ,PAYMENTS.ADDUPSECCODERF" + Environment.NewLine;
            sqlText += ") AS PAY" + Environment.NewLine;
            sqlText += "LEFT JOIN MONEYKINDURF AS MONEYKIND" + Environment.NewLine;
            sqlText += " ON PAY.ENTERPRISECODERF = MONEYKIND.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += " AND PAY.MONEYKINDCODERF = MONEYKIND.MONEYKINDCODERF" + Environment.NewLine;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SupplierCd);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);
                    if (suplierPayWork.LastCAddUpUpdDate == DateTime.MinValue)
                        findParaLastTimeAddUpDate.Value = 20000101;
                    else
                        findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.LastCAddUpUpdDate);

                    AccPayTotalWork accPayTotalWork = new AccPayTotalWork();

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        accPayTotalWork = new AccPayTotalWork();
                        accPayTotalWork = CopyToAccPayTotalWorkFromReader(ref myReader);
                        if (accPayTotalWork.Payment == 0)
                        {
                            continue;
                        }

                        accPayTotalWork.AddUpSecCode = suplierPayWork.AddUpSecCode;
                        accPayTotalWork.AddUpDate = suplierPayWork.AddUpDate;
                        accPayTotalWork.SupplierCd = suplierPayWork.SupplierCd;
                        accPayTotalWorkList.Add(accPayTotalWork);
                    }
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
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }
        // --- ADD 2012/09/11 -----------<<<<<

        private void SetAccPayTotal(ref AccPayTotalWork accPayTotalWork, AccPayTotalWork accPayTotalList)
        {
            accPayTotalWork.CreateDateTime = accPayTotalList.CreateDateTime;
            accPayTotalWork.UpdateDateTime = accPayTotalList.UpdateDateTime;
            accPayTotalWork.EnterpriseCode = accPayTotalList.EnterpriseCode;
            accPayTotalWork.FileHeaderGuid = accPayTotalList.FileHeaderGuid;
            accPayTotalWork.UpdEmployeeCode = accPayTotalList.UpdEmployeeCode;
            accPayTotalWork.UpdAssemblyId1 = accPayTotalList.UpdAssemblyId1;
            accPayTotalWork.UpdAssemblyId2 = accPayTotalList.UpdAssemblyId2;
            accPayTotalWork.LogicalDeleteCode = accPayTotalList.LogicalDeleteCode;
            accPayTotalWork.AddUpSecCode = accPayTotalList.AddUpSecCode;
            accPayTotalWork.PayeeCode = accPayTotalList.PayeeCode;
            accPayTotalWork.SupplierCd = accPayTotalList.SupplierCd;
            accPayTotalWork.AddUpDate = accPayTotalList.AddUpDate;
            accPayTotalWork.MoneyKindCode = accPayTotalList.MoneyKindCode;
            accPayTotalWork.MoneyKindName = accPayTotalList.MoneyKindName;
            accPayTotalWork.MoneyKindDiv = accPayTotalList.MoneyKindDiv;
            accPayTotalWork.Payment += accPayTotalList.Payment;
        }
        #endregion

        #region [仕入データ]
        /// <summary>
        /// 仕入先支払金額ワーク用Listから仕入データを取得します
        /// </summary>
        /// <param name="suplierPayWork">仕入先支払金額ワーク</param>
        /// <param name="suplierPayChildWorkList">仕入先支払金額マスタ(子レコード用)List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額ワーク用Listから仕入データを取得します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int GetStockSlip(ref SuplierPayWork suplierPayWork, ref ArrayList suplierPayChildWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;

            string sqlText = string.Empty;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    if (suplierPayWork.SupplierCd == suplierPayWork.PayeeCode) // ←念のため
                    {
                        #region [●集計レコード作成処理]

                        #region SELECT文作成
                        // 修正 2009/04/17 >>>
                        #region DEL 2009/04/17
                        /*
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += " SUPLIERPAY.PAYEECODERF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.SUPPLIERNM1RF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.SUPPLIERNM2RF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.SUPPLIERSNMRF,  " + Environment.NewLine;
                        //sqlText += " SUPLIERPAY.STOCKCNSTAXFRCPROCCDRF AS FRACTIONPROCCDRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.SUPPCTAXLAYCDRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.FRACTIONPROCUNITRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.FRACTIONPROCCDRF,  " + Environment.NewLine;
                        //支払情報
                        sqlText += " SUPLIERPAY.PAYMENTMONTHCODERF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.PAYMENTDAYRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.PAYMENTCONDRF, " + Environment.NewLine;
                        sqlText += " SUPLIERPAY.STOCKSLIPCOUNT," + Environment.NewLine;
                        //相殺
                        sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF + SUPLIERPAY.THISSTCKPRICRGDSRF + SUPLIERPAY.THISSTCKPRICDISRF AS OFSTHISTIMESTOCKRF," + Environment.NewLine;
                        //相殺後今回仕入消費税はセット時に計算
                        sqlText += " SUPLIERPAY.TTLITDEDSTCOUTTAXRF + SUPLIERPAY.TTLITDEDRETOUTTAXRF+SUPLIERPAY.TTLITDEDDISOUTTAXRF AS ITDEDOFFSETOUTTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDSTCINTAXRF + SUPLIERPAY.TTLITDEDRETINTAXRF+SUPLIERPAY.TTLITDEDDISINTAXRF AS ITDEDOFFSETINTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDSTCTAXFREERF + SUPLIERPAY.TTLITDEDRETTAXFREERF+SUPLIERPAY.TTLITDEDDISTAXFREERF AS ITDEDOFFSETTAXFREERF," + Environment.NewLine;
                        //相殺後外税消費税はセット時に計算
                        sqlText += " SUPLIERPAY.STCKPRCCONSTAXINCLURF+SUPLIERPAY.TTLRETINNERTAXRF+SUPLIERPAY.STCKDISTTLTAXINCLURF AS OFFSETINTAXRF," + Environment.NewLine;
                        //仕入
                        sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF AS THISTIMESTOCKPRICERF," + Environment.NewLine;
                        sqlText += " (CASE WHEN (SUPLIERPAY.SUPPCTAXLAYCDRF=0 ) THEN SUPLIERPAY.STOCKOUTTAXRF " + Environment.NewLine;
                        sqlText += "   ELSE(CASE WHEN SUPLIERPAY.SUPPCTAXLAYCDRF=1 THEN SUPLIERPAY.DTLSTOCKOUTTAXRF" + Environment.NewLine;
                        sqlText += "         ELSE (SUPLIERPAY.STOCKOUTTAXRF1 +SUPLIERPAY.STOCKOUTTAXRF2 +SUPLIERPAY.STOCKOUTTAXRF3)END)END)+SUPLIERPAY.STCKPRCCONSTAXINCLURF AS THISSTCPRCTAXRF, --今回消費税" + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDSTCOUTTAXRF AS TTLITDEDSTCOUTTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDSTCINTAXRF AS TTLITDEDSTCINTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDSTCTAXFREERF AS TTLITDEDSTCTAXFREERF," + Environment.NewLine;
                        sqlText += " (CASE WHEN (SUPLIERPAY.SUPPCTAXLAYCDRF=0 ) THEN SUPLIERPAY.STOCKOUTTAXRF" + Environment.NewLine;
                        sqlText += "  ELSE (CASE WHEN SUPLIERPAY.SUPPCTAXLAYCDRF=1 THEN SUPLIERPAY.DTLSTOCKOUTTAXRF " + Environment.NewLine;
                        sqlText += "        ELSE(SUPLIERPAY.STOCKOUTTAXRF1 +SUPLIERPAY.STOCKOUTTAXRF2 +SUPLIERPAY.STOCKOUTTAXRF3) END) END)AS TTLSTOCKOUTERTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.STCKPRCCONSTAXINCLURF AS TTLSTOCKINNERTAXRF," + Environment.NewLine;
                        //返品
                        sqlText += " SUPLIERPAY.THISSTCKPRICRGDSRF AS THISSTCKPRICRGDSRF," + Environment.NewLine;
                        sqlText += " (CASE WHEN (SUPLIERPAY.SUPPCTAXLAYCDRF=0 ) THEN SUPLIERPAY.TTLRETOUTERTAXRF " + Environment.NewLine;
                        sqlText += "   ELSE(CASE WHEN SUPLIERPAY.SUPPCTAXLAYCDRF=1 THEN SUPLIERPAY.DTLTTLRETOUTERTAXRF" + Environment.NewLine;
                        sqlText += "        ELSE (SUPLIERPAY.TTLRETOUTERTAXRF1 +SUPLIERPAY.TTLRETOUTERTAXRF2 +SUPLIERPAY.TTLRETOUTERTAXRF3) END) END)+SUPLIERPAY.TTLRETINNERTAXRF AS THISSTCPRCTAXRGDSRF, --今回消費税" + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDRETOUTTAXRF AS TTLITDEDRETOUTTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDRETINTAXRF AS TTLITDEDRETINTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDRETTAXFREERF AS TTLITDEDRETTAXFREERF," + Environment.NewLine;
                        sqlText += " (CASE WHEN (SUPLIERPAY.SUPPCTAXLAYCDRF=0 ) THEN SUPLIERPAY.TTLRETOUTERTAXRF" + Environment.NewLine;
                        sqlText += "   ELSE( CASE WHEN SUPLIERPAY.SUPPCTAXLAYCDRF=1 THEN SUPLIERPAY.DTLTTLRETOUTERTAXRF" + Environment.NewLine;
                        sqlText += "         ELSE (SUPLIERPAY.TTLRETOUTERTAXRF1 +SUPLIERPAY.TTLRETOUTERTAXRF2 +SUPLIERPAY.TTLRETOUTERTAXRF3) END) END) AS TTLRETOUTERTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLRETINNERTAXRF AS TTLRETINNERTAXRF," + Environment.NewLine;
                        //値引
                        sqlText += " SUPLIERPAY.THISSTCKPRICDISRF AS THISSTCKPRICDISRF," + Environment.NewLine;
                        sqlText += " (CASE WHEN (SUPLIERPAY.SUPPCTAXLAYCDRF=0 ) THEN SUPLIERPAY.STOCKDISOUTTAXRF" + Environment.NewLine;
                        sqlText += "   ELSE( CASE WHEN  SUPLIERPAY.SUPPCTAXLAYCDRF=1 THEN SUPLIERPAY.DTLSTOCKDISOUTTAXRF " + Environment.NewLine;
                        sqlText += "         ELSE (SUPLIERPAY.STOCKDISOUTTAXRF1 +SUPLIERPAY.STOCKDISOUTTAXRF2 +SUPLIERPAY.STOCKDISOUTTAXRF3) END) END)+SUPLIERPAY.STCKDISTTLTAXINCLURF AS THISSTCPRCTAXDISRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDDISOUTTAXRF AS TTLITDEDDISOUTTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDDISINTAXRF AS TTLITDEDDISINTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDDISTAXFREERF AS TTLITDEDDISTAXFREERF," + Environment.NewLine;
                        sqlText += " (CASE WHEN (SUPLIERPAY.SUPPCTAXLAYCDRF=0 ) THEN SUPLIERPAY.STOCKDISOUTTAXRF" + Environment.NewLine;
                        sqlText += "   ELSE(CASE WHEN SUPLIERPAY.SUPPCTAXLAYCDRF=1  THEN SUPLIERPAY.DTLSTOCKDISOUTTAXRF" + Environment.NewLine;
                        sqlText += "        ELSE  (SUPLIERPAY.STOCKDISOUTTAXRF1 +SUPLIERPAY.STOCKDISOUTTAXRF2 +SUPLIERPAY.STOCKDISOUTTAXRF3) END) END) AS TTLDISOUTERTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.STCKDISTTLTAXINCLURF AS TTLDISINNERTAXRF" + Environment.NewLine;
                        sqlText += " FROM" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        */
                        #endregion
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += " SUPLIERPAY.PAYEECODERF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.SUPPLIERNM1RF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.SUPPLIERNM2RF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.SUPPLIERSNMRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.FRACTIONPROCUNITRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.FRACTIONPROCCDRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.PAYMENTMONTHCODERF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.PAYMENTDAYRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.PAYMENTCONDRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.STOCKSLIPCOUNT," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF + SUPLIERPAY.THISSTCKPRICRGDSRF + SUPLIERPAY.THISSTCKPRICDISRF AS OFSTHISTIMESTOCKRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDSTCOUTTAXRF + SUPLIERPAY.TTLITDEDRETOUTTAXRF+SUPLIERPAY.TTLITDEDDISOUTTAXRF AS ITDEDOFFSETOUTTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDSTCINTAXRF + SUPLIERPAY.TTLITDEDRETINTAXRF+SUPLIERPAY.TTLITDEDDISINTAXRF AS ITDEDOFFSETINTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDSTCTAXFREERF + SUPLIERPAY.TTLITDEDRETTAXFREERF+SUPLIERPAY.TTLITDEDDISTAXFREERF AS ITDEDOFFSETTAXFREERF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.STCKPRCCONSTAXINCLURF+SUPLIERPAY.TTLRETINNERTAXRF+SUPLIERPAY.STCKDISTTLTAXINCLURF AS OFFSETINTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF AS THISTIMESTOCKPRICERF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDSTCOUTTAXRF AS TTLITDEDSTCOUTTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDSTCINTAXRF AS TTLITDEDSTCINTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDSTCTAXFREERF AS TTLITDEDSTCTAXFREERF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.STOCKOUTTAXRF AS STOCKOUTTAX_D, -- 仕入消費税_伝票転嫁" + Environment.NewLine;
                        sqlText += " SUPLIERPAY.DTLSTOCKOUTTAXRF AS STOCKOUTTAX_M, -- 仕入消費税_明細転嫁" + Environment.NewLine;
                        sqlText += " SUPLIERPAY.STOCKOUTTAXRF1 +SUPLIERPAY.STOCKOUTTAXRF2 +SUPLIERPAY.STOCKOUTTAXRF3 AS STOCKOUTTAX_S, -- 仕入消費税_支払親転嫁" + Environment.NewLine;
                        sqlText += " SUPLIERPAY.STCKPRCCONSTAXINCLURF AS TTLSTOCKINNERTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.THISSTCKPRICRGDSRF AS THISSTCKPRICRGDSRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDRETOUTTAXRF AS TTLITDEDRETOUTTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDRETINTAXRF AS TTLITDEDRETINTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDRETTAXFREERF AS TTLITDEDRETTAXFREERF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLRETOUTERTAXRF AS RETSTOCKOUTTAX_D,   -- 返品消費税＿伝票転嫁" + Environment.NewLine;
                        sqlText += " SUPLIERPAY.DTLTTLRETOUTERTAXRF AS RETSTOCKOUTTAX_M,-- 返品消費税＿明細転嫁" + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLRETOUTERTAXRF1 +SUPLIERPAY.TTLRETOUTERTAXRF2 +SUPLIERPAY.TTLRETOUTERTAXRF3 AS RETSTOCKOUTTAX_S, --返品消費税＿支払親転嫁" + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLRETINNERTAXRF AS TTLRETINNERTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.THISSTCKPRICDISRF AS THISSTCKPRICDISRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDDISOUTTAXRF AS TTLITDEDDISOUTTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDDISINTAXRF AS TTLITDEDDISINTAXRF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.TTLITDEDDISTAXFREERF AS TTLITDEDDISTAXFREERF," + Environment.NewLine;
                        sqlText += " SUPLIERPAY.STOCKDISOUTTAXRF AS DISSTOCKOUTTAX_D,    -- 値引消費税＿伝票転嫁" + Environment.NewLine;
                        sqlText += " SUPLIERPAY.DTLSTOCKDISOUTTAXRF AS DISSTOCKOUTTAX_M, -- 値引消費税＿明細転嫁" + Environment.NewLine;
                        sqlText += " SUPLIERPAY.STOCKDISOUTTAXRF1 +SUPLIERPAY.STOCKDISOUTTAXRF2 +SUPLIERPAY.STOCKDISOUTTAXRF3 AS DISSTOCKOUTTAX_S, --値引消費税＿支払親転嫁" + Environment.NewLine;
                        sqlText += " SUPLIERPAY.STCKDISTTLTAXINCLURF AS TTLDISINNERTAXRF" + Environment.NewLine;
                        sqlText += " FROM" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        // 修正 2009/04/17 <<<

                        #region [SUBクエリ]
                        // 修正 2009/04/17 >>>
                        #region DEL 2009/04/17
                        /*
                        sqlText += " SELECT" + Environment.NewLine;
                        sqlText += "  STOCK.PAYEECODERF," + Environment.NewLine;
                        sqlText += "  SUPPLIER.SUPPLIERNM1RF," + Environment.NewLine;
                        sqlText += "  SUPPLIER.SUPPLIERNM2RF," + Environment.NewLine;
                        sqlText += "  SUPPLIER.SUPPLIERSNMRF," + Environment.NewLine;
                        sqlText += "  SUPPLIER.STOCKCNSTAXFRCPROCCDRF," + Environment.NewLine;
                        //sqlText += "  SUPPLIER.SUPPCTAXLAYCDRF," + Environment.NewLine;
                        sqlText += "  (CASE WHEN SUPPLIER.SUPPCTAXLAYREFCDRF = 0 THEN STOCK.TAXCONSTAXLAYMETHODRF ELSE SUPPLIER.SUPPCTAXLAYCDRF END) AS  SUPPCTAXLAYCDRF," + Environment.NewLine;
                        sqlText += "  SUPPLIER.PAYMENTMONTHCODERF," + Environment.NewLine;
                        sqlText += "  SUPPLIER.PAYMENTDAYRF," + Environment.NewLine;
                        sqlText += "  SUPPLIER.PAYMENTCONDRF," + Environment.NewLine;
                        sqlText += "  PROCMONEY.FRACTIONPROCUNITRF," + Environment.NewLine;
                        sqlText += "  PROCMONEY.FRACTIONPROCCDRF, " + Environment.NewLine;
                        sqlText += "  COUNT(STOCK.SUPPLIERSLIPNORF) STOCKSLIPCOUNT, --伝票枚数" + Environment.NewLine;
                        //仕入
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STOCKNETPRICERF ELSE 0 END)) AS THISTIMESTOCKPRICERF,       --仕入正価金額" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCOUTTAXRF ELSE 0 END)) AS TTLITDEDSTCOUTTAXRF,    --仕入外税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCINTAXRF ELSE 0 END)) AS TTLITDEDSTCINTAXRF,      --仕入内税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCTAXFREERF ELSE 0 END)) AS TTLITDEDSTCTAXFREERF,  --仕入非課税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STOCKOUTTAXRF ELSE 0 END)) AS STOCKOUTTAXRF,                --消費税額（外税）伝票" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.DTLSTOCKOUTTAXRF ELSE 0 END)) AS DTLSTOCKOUTTAXRF,          --消費税額（外税）明細" + Environment.NewLine; // ADD 2009.01.21
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
                        sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS STOCKOUTTAXRF1,                     --消費税額（外税）税率1" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
                        sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS STOCKOUTTAXRF2,                          --消費税額（外税）税率2" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
                        sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS STOCKOUTTAXRF3,                          --消費税額（外税）税率3" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STCKPRCCONSTAXINCLURF ELSE 0 END)) AS STCKPRCCONSTAXINCLURF,--消費税額（内税）" + Environment.NewLine;
                        //返品
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STOCKNETPRICERF ELSE 0 END)) AS THISSTCKPRICRGDSRF,       --仕入正価金額" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCOUTTAXRF ELSE 0 END)) AS TTLITDEDRETOUTTAXRF,  --仕入外税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCINTAXRF ELSE 0 END)) AS TTLITDEDRETINTAXRF,    --仕入内税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCTAXFREERF ELSE 0 END)) AS TTLITDEDRETTAXFREERF,--仕入非課税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STOCKOUTTAXRF ELSE 0 END)) AS TTLRETOUTERTAXRF,           --消費税額（外税）伝票" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.DTLSTOCKOUTTAXRF ELSE 0 END)) AS DTLTTLRETOUTERTAXRF,     --消費税額（外税）明細" + Environment.NewLine; // ADD 2009.01.21
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
                        sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS TTLRETOUTERTAXRF1,                --消費税額（外税）税率1" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
                        sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS TTLRETOUTERTAXRF2,                     --消費税額（外税）税率2" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
                        sqlText += "           THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS TTLRETOUTERTAXRF3,                      --消費税額（外税）税率3" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STCKPRCCONSTAXINCLURF ELSE 0 END)) AS TTLRETINNERTAXRF,   --消費税額（内税）" + Environment.NewLine;
                        //値引
                        sqlText += "  SUM(STOCK.STCKDISTTLTAXEXCRF) AS THISSTCKPRICDISRF,       --値引金額計（税抜き）" + Environment.NewLine;
                        sqlText += "  SUM(STOCK.ITDEDSTOCKDISOUTTAXRF) AS TTLITDEDDISOUTTAXRF,  --値引外税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM(STOCK.ITDEDSTOCKDISINTAXRF) AS TTLITDEDDISINTAXRF,    --値引内税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM(STOCK.ITDEDSTOCKDISTAXFRERF) AS TTLITDEDDISTAXFREERF, --値引非課税対象額合計   " + Environment.NewLine;
                        sqlText += "  SUM(STOCK.STOCKDISOUTTAXRF) AS STOCKDISOUTTAXRF,          --値引消費税額（外税）伝票" + Environment.NewLine;
                        sqlText += "  SUM(STOCK.STOCKDISOUTTAXRF) AS DTLSTOCKDISOUTTAXRF,    --値引消費税額（外税）明細" + Environment.NewLine; // ADD 2009.01.21 
                        sqlText += "  SUM((CASE WHEN (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
                        sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATERF)ELSE 0 END)) AS STOCKDISOUTTAXRF1,  --値引消費税額（外税）税率1" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
                        sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE2RF)ELSE 0 END)) AS STOCKDISOUTTAXRF2, --値引消費税額（外税）税率2" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
                        sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE3RF)ELSE 0 END)) AS STOCKDISOUTTAXRF3, --値引消費税額（外税）税率3" + Environment.NewLine;
                        sqlText += "  SUM(STOCK.STCKDISTTLTAXINCLURF) AS STCKDISTTLTAXINCLURF    --値引消費税額（内税）" + Environment.NewLine;
                        sqlText += "  FROM" + Environment.NewLine;
                        sqlText += "  (" + Environment.NewLine;
                        */
                        #endregion
                        sqlText += " SELECT" + Environment.NewLine;
                        sqlText += "  STOCK.PAYEECODERF," + Environment.NewLine;
                        sqlText += "  SUPPLIER.SUPPLIERNM1RF," + Environment.NewLine;
                        sqlText += "  SUPPLIER.SUPPLIERNM2RF," + Environment.NewLine;
                        sqlText += "  SUPPLIER.SUPPLIERSNMRF," + Environment.NewLine;
                        sqlText += "  SUPPLIER.STOCKCNSTAXFRCPROCCDRF," + Environment.NewLine;
                        sqlText += "  SUPPLIER.PAYMENTMONTHCODERF," + Environment.NewLine;
                        sqlText += "  SUPPLIER.PAYMENTDAYRF," + Environment.NewLine;
                        sqlText += "  SUPPLIER.PAYMENTCONDRF," + Environment.NewLine;
                        sqlText += "  PROCMONEY.FRACTIONPROCUNITRF," + Environment.NewLine;
                        sqlText += "  PROCMONEY.FRACTIONPROCCDRF," + Environment.NewLine;
                        sqlText += "  COUNT(STOCK.SUPPLIERSLIPNORF) STOCKSLIPCOUNT, --伝票枚数" + Environment.NewLine;
                        sqlText += "  -- ■ ■ 仕入 ■ ■" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STOCKNETPRICERF ELSE 0 END)) AS THISTIMESTOCKPRICERF,       --仕入正価金額" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCOUTTAXRF ELSE 0 END)) AS TTLITDEDSTCOUTTAXRF,    --仕入外税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCINTAXRF ELSE 0 END)) AS TTLITDEDSTCINTAXRF,      --仕入内税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCTAXFREERF ELSE 0 END)) AS TTLITDEDSTCTAXFREERF,  --仕入非課税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 0) AND (STOCK.SUPPLIERSLIPCDRF =10) THEN STOCK.STOCKOUTTAXRF ELSE 0 END)) AS STOCKOUTTAXRF,      --消費税額（外税）伝票" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 1) AND (STOCK.SUPPLIERSLIPCDRF =10) THEN STOCK.DTLSTOCKOUTTAXRF ELSE 0 END)) AS DTLSTOCKOUTTAXRF,--消費税額（外税）明細" + Environment.NewLine;
                        sqlText += "  -- 支払(親)転嫁" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF)" + Environment.NewLine;
                        sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS STOCKOUTTAXRF1,                     --消費税額（外税）税率1" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF)" + Environment.NewLine;
                        sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS STOCKOUTTAXRF2,                          --消費税額（外税）税率2" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF)" + Environment.NewLine;
                        sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS STOCKOUTTAXRF3,                          --消費税額（外税）税率3" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STCKPRCCONSTAXINCLURF ELSE 0 END)) AS STCKPRCCONSTAXINCLURF,--消費税額（内税）" + Environment.NewLine;
                        sqlText += "  -- ■ ■ 返品 ■ ■" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STOCKNETPRICERF ELSE 0 END)) AS THISSTCKPRICRGDSRF,       --仕入正価金額" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCOUTTAXRF ELSE 0 END)) AS TTLITDEDRETOUTTAXRF,  --仕入外税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCINTAXRF ELSE 0 END)) AS TTLITDEDRETINTAXRF,    --仕入内税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCTAXFREERF ELSE 0 END)) AS TTLITDEDRETTAXFREERF,--仕入非課税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 0) AND (STOCK.SUPPLIERSLIPCDRF =20) THEN STOCK.STOCKOUTTAXRF ELSE 0 END)) AS TTLRETOUTERTAXRF,      --消費税額（外税）伝票" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 1) AND (STOCK.SUPPLIERSLIPCDRF =20) THEN STOCK.DTLSTOCKOUTTAXRF ELSE 0 END)) AS DTLTTLRETOUTERTAXRF,--消費税額（外税）明細" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF)" + Environment.NewLine;
                        sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS TTLRETOUTERTAXRF1,                --消費税額（外税）税率1" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF)" + Environment.NewLine;
                        sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS TTLRETOUTERTAXRF2,                     --消費税額（外税）税率2" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF)" + Environment.NewLine;
                        sqlText += "           THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS TTLRETOUTERTAXRF3,                      --消費税額（外税）税率3" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STCKPRCCONSTAXINCLURF ELSE 0 END)) AS TTLRETINNERTAXRF,   --消費税額（内税）" + Environment.NewLine;
                        sqlText += "  -- ■ ■ 値引 ■ ■" + Environment.NewLine;
                        sqlText += "  SUM(STOCK.STCKDISTTLTAXEXCRF) AS THISSTCKPRICDISRF,       --値引金額計（税抜き）" + Environment.NewLine;
                        sqlText += "  SUM(STOCK.ITDEDSTOCKDISOUTTAXRF) AS TTLITDEDDISOUTTAXRF,  --値引外税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM(STOCK.ITDEDSTOCKDISINTAXRF) AS TTLITDEDDISINTAXRF,    --値引内税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM(STOCK.ITDEDSTOCKDISTAXFRERF) AS TTLITDEDDISTAXFREERF, --値引非課税対象額合計" + Environment.NewLine;
                        sqlText += "  SUM(CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 0) THEN STOCK.STOCKDISOUTTAXRF ELSE 0 END) AS STOCKDISOUTTAXRF,   --値引消費税額（外税）伝票" + Environment.NewLine;
                        sqlText += "  SUM(CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 1) THEN STOCK.STOCKDISOUTTAXRF ELSE 0 END) AS DTLSTOCKDISOUTTAXRF,--値引消費税額（外税）明細" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF)" + Environment.NewLine;
                        sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATERF)ELSE 0 END)) AS STOCKDISOUTTAXRF1,  --値引消費税額（外税）税率1" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF)" + Environment.NewLine;
                        sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE2RF)ELSE 0 END)) AS STOCKDISOUTTAXRF2, --値引消費税額（外税）税率2" + Environment.NewLine;
                        sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF)" + Environment.NewLine;
                        sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE3RF)ELSE 0 END)) AS STOCKDISOUTTAXRF3, --値引消費税額（外税）税率3" + Environment.NewLine;
                        sqlText += "  SUM(STOCK.STCKDISTTLTAXINCLURF) AS STCKDISTTLTAXINCLURF    --値引消費税額（内税）" + Environment.NewLine;
                        sqlText += "  FROM" + Environment.NewLine;
                        sqlText += "  (" + Environment.NewLine;
                        // 修正 2009/04/17 <<<

                        #region SUBSUBクエリ
                        sqlText += "   SELECT" + Environment.NewLine;
                        sqlText += "    SUBSTOCK.LOGICALDELETECODERF," + Environment.NewLine;
                        sqlText += "    SUBSTOCK.ENTERPRISECODERF," + Environment.NewLine;
                        sqlText += "    SUBSTOCK.SUPPCTAXLAYCDRF,  --消費税転嫁方式" + Environment.NewLine; // ADD 2009/04/17
                        sqlText += "    SUBSTOCK.SUPPLIERFORMALRF, --仕入形式" + Environment.NewLine;
                        sqlText += "    SUBSTOCK.DEBITNOTEDIVRF,   --赤伝区分" + Environment.NewLine;
                        sqlText += "    SUBSTOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
                        sqlText += "    SUBSTOCK.STOCKGOODSCDRF,   --仕入商品区分" + Environment.NewLine;
                        sqlText += "    SUBSTOCK.SUPPLIERSLIPNORF," + Environment.NewLine;
                        sqlText += "    SUBSTOCK.STOCKADDUPADATERF," + Environment.NewLine;
                        sqlText += "    (CASE WHEN (SEARCHSUPPLIER.PAYEECODERF IS NOT NULL) THEN SEARCHSUPPLIER.PAYEECODERF ELSE SUBSTOCK.PAYEECODERF END) AS PAYEECODERF," + Environment.NewLine;

                        // 修正 2009.03.24 >>>
                        //仕入・返品
                        //sqlText += "    SUBSTOCK.STOCKNETPRICERF," + Environment.NewLine;
                        //sqlText += "    SUBSTOCK.TTLITDEDSTCOUTTAXRF," + Environment.NewLine;
                        //sqlText += "    SUBSTOCK.TTLITDEDSTCINTAXRF," + Environment.NewLine;
                        //sqlText += "    SUBSTOCK.TTLITDEDSTCTAXFREERF," + Environment.NewLine;
                        //sqlText += "    SUBSTOCK.STOCKOUTTAXRF," + Environment.NewLine;
                        //sqlText += "    SUBSTOCK.STCKPRCCONSTAXINCLURF," + Environment.NewLine;
                        //値引
                        //sqlText += "    SUBSTOCK.STCKDISTTLTAXEXCRF," + Environment.NewLine;
                        //sqlText += "    SUBSTOCK.ITDEDSTOCKDISOUTTAXRF," + Environment.NewLine;
                        //sqlText += "    SUBSTOCK.ITDEDSTOCKDISINTAXRF," + Environment.NewLine;
                        //sqlText += "    SUBSTOCK.ITDEDSTOCKDISTAXFRERF," + Environment.NewLine;
                        //sqlText += "    SUBSTOCK.STOCKDISOUTTAXRF," + Environment.NewLine;
                        //sqlText += "    SUBSTOCK.STCKDISTTLTAXINCLURF," + Environment.NewLine;
                        //sqlText += "    SUBSTOCKDTL.DTLSTOCKOUTTAXRF," + Environment.NewLine;
                        //sqlText += "    SUBSTOCKDTL.DTLSTCKPRCCONSTAXINCLURF," + Environment.NewLine;
                        //sqlText += "    SUBSTOCKDISDTL.DTLSTOCKDISOUTTAXRF," + Environment.NewLine;
                        //sqlText += "    SUBSTOCKDISDTL.DTLSTCKDISTTLTAXINCLURF," + Environment.NewLine;
                        //仕入・返品(行値引含む)
                        sqlText += "    SUBSTOCK.STOCKNETPRICERF + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STOCKNETPRICERF," + Environment.NewLine;
                        sqlText += "    SUBSTOCK.TTLITDEDSTCOUTTAXRF + SUBSTOCKDTL.ITDEDSTOCKDISOUTTAXGYO AS TTLITDEDSTCOUTTAXRF," + Environment.NewLine;
                        sqlText += "    SUBSTOCK.TTLITDEDSTCINTAXRF + SUBSTOCKDTL.ITDEDSTOCKDISINTAXGYO AS TTLITDEDSTCINTAXRF," + Environment.NewLine;
                        sqlText += "    SUBSTOCK.TTLITDEDSTCTAXFREERF + SUBSTOCKDTL.ITDEDSTOCKDISFREETAXGYO AS TTLITDEDSTCTAXFREERF," + Environment.NewLine;
                        sqlText += "    SUBSTOCK.STOCKOUTTAXRF + SUBSTOCKDTL.STOCKDISOUTTAXGYO AS STOCKOUTTAXRF," + Environment.NewLine;
                        sqlText += "    SUBSTOCK.STCKPRCCONSTAXINCLURF + SUBSTOCKDTL.STOCKDISINTAXGYO AS STCKPRCCONSTAXINCLURF," + Environment.NewLine;
                        //値引(行値引除く)
                        sqlText += "    SUBSTOCK.STCKDISTTLTAXEXCRF - SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STCKDISTTLTAXEXCRF," + Environment.NewLine;
                        sqlText += "    SUBSTOCK.ITDEDSTOCKDISOUTTAXRF - SUBSTOCKDTL.ITDEDSTOCKDISOUTTAXGYO AS ITDEDSTOCKDISOUTTAXRF," + Environment.NewLine;
                        sqlText += "    SUBSTOCK.ITDEDSTOCKDISINTAXRF - SUBSTOCKDTL.ITDEDSTOCKDISINTAXGYO AS ITDEDSTOCKDISINTAXRF," + Environment.NewLine;
                        sqlText += "    SUBSTOCK.ITDEDSTOCKDISTAXFRERF - SUBSTOCKDTL.ITDEDSTOCKDISFREETAXGYO AS ITDEDSTOCKDISTAXFRERF," + Environment.NewLine;
                        sqlText += "    SUBSTOCK.STOCKDISOUTTAXRF - SUBSTOCKDTL.STOCKDISOUTTAXGYO AS STOCKDISOUTTAXRF," + Environment.NewLine;
                        sqlText += "    SUBSTOCK.STCKDISTTLTAXINCLURF - SUBSTOCKDTL.STOCKDISINTAXGYO AS STCKDISTTLTAXINCLURF," + Environment.NewLine;

                        sqlText += "    SUBSTOCKDTL.DTLSTOCKOUTTAXRF + SUBSTOCKDTL.STOCKDISOUTTAXGYO AS DTLSTOCKOUTTAXRF," + Environment.NewLine;
                        sqlText += "    SUBSTOCKDTL.DTLSTCKPRCCONSTAXINCLURF + SUBSTOCKDTL.STOCKDISINTAXGYO AS DTLSTCKPRCCONSTAXINCLURF," + Environment.NewLine;
                        // 修正 2009.03.24 <<<


                        // 税率取得
                        sqlText += "    TAX.TAXRATESTARTDATERF AS TAXRATESTARTDATERF," + Environment.NewLine;
                        sqlText += "    TAX.TAXRATEENDDATERF AS TAXRATEENDDATERF," + Environment.NewLine;
                        sqlText += "    TAX.TAXRATERF AS TAXRATERF," + Environment.NewLine;
                        sqlText += "    TAX.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF," + Environment.NewLine;
                        sqlText += "    TAX.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF," + Environment.NewLine;
                        sqlText += "    TAX.TAXRATE2RF AS TAXRATE2RF," + Environment.NewLine;
                        sqlText += "    TAX.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF," + Environment.NewLine;
                        sqlText += "    TAX.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF," + Environment.NewLine;
                        sqlText += "    TAX.TAXRATE3RF AS TAXRATE3RF,    " + Environment.NewLine;
                        sqlText += "    TAX.CONSTAXLAYMETHODRF AS TAXCONSTAXLAYMETHODRF" + Environment.NewLine;
                        sqlText += "   FROM" + Environment.NewLine;
                        sqlText += "    STOCKSLIPRF AS SUBSTOCK" + Environment.NewLine;

                        #region [ SUBSUBクエリJOIN ]
                        sqlText += "    LEFT JOIN TAXRATESETRF AS TAX" + Environment.NewLine;
                        sqlText += "     ON SUBSTOCK.ENTERPRISECODERF = TAX.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    LEFT JOIN SUPPLIERRF AS SEARCHSUPPLIER" + Environment.NewLine;
                        sqlText += "     ON SUBSTOCK.ENTERPRISECODERF = SEARCHSUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "     AND SUBSTOCK.SUPPLIERCDRF = SEARCHSUPPLIER.SUPPLIERCDRF" + Environment.NewLine;
                        // ADD 2009.03.24 >>>
                        sqlText += "    LEFT JOIN" + Environment.NewLine;
                        sqlText += "    ( " + Environment.NewLine;
                        sqlText += "      SELECT" + Environment.NewLine;
                        sqlText += "       STOCK.ENTERPRISECODERF," + Environment.NewLine;
                        sqlText += "       STOCK.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
                        sqlText += "       STOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
                        sqlText += "       STOCK.SUPPLIERSLIPNORF, --仕入伝票番号 " + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF != 2 AND DTL.TAXATIONCODERF = 0) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTOCKOUTTAXRF," + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF != 2 AND DTL.TAXATIONCODERF = 2) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTCKPRCCONSTAXINCLURF," + Environment.NewLine;
                        sqlText += "       -- 行値引" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS DISSTOCKPRICETAXEXCGYO," + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISOUTTAXGYO, -- 外税対象額(行値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 1 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISFREETAXGYO,-- 非課税対象額(行値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 2 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISINTAXGYO,  -- 内税対象額(行値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 0 ) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS STOCKDISOUTTAXGYO, -- 外税額(行値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 2 ) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS STOCKDISINTAXGYO  -- 内税額(行値引)" + Environment.NewLine;
                        //sqlText += "       -- 商品値引" + Environment.NewLine;
                        //sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF != 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS DISSTOCKPRICETAXEXCGOODS," + Environment.NewLine;
                        //sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF != 0 AND DTL.TAXATIONCODERF = 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISOUTTAXGOODS, -- 外税対象額(商品値引)" + Environment.NewLine;
                        //sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF != 0 AND DTL.TAXATIONCODERF = 1 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISFREETAXGOODS,-- 非課税対象額(商品値引)" + Environment.NewLine;
                        //sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF != 0 AND DTL.TAXATIONCODERF = 2 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISINTAXGOODS,  -- 内税対象額(商品値引)" + Environment.NewLine;
                        //sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF != 0 AND DTL.TAXATIONCODERF = 0 ) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS STOCKDISOUTTAXGOODS, -- 外税額(商品値引)" + Environment.NewLine;
                        //sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF != 0 AND DTL.TAXATIONCODERF = 2 ) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS STOCKDISINTAXGOODS  -- 内税額(商品値引)" + Environment.NewLine;
                        sqlText += "      FROM" + Environment.NewLine;
                        sqlText += "       STOCKDETAILRF AS DTL" + Environment.NewLine;
                        sqlText += "      LEFT JOIN STOCKSLIPRF AS STOCK" + Environment.NewLine;
                        sqlText += "       ON DTL.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "       AND DTL.SUPPLIERFORMALRF = STOCK.SUPPLIERFORMALRF" + Environment.NewLine;
                        sqlText += "       AND DTL.SUPPLIERSLIPNORF = STOCK.SUPPLIERSLIPNORF" + Environment.NewLine;
                        sqlText += "      GROUP BY" + Environment.NewLine;
                        sqlText += "       STOCK.ENTERPRISECODERF," + Environment.NewLine;
                        sqlText += "       STOCK.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
                        sqlText += "       STOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
                        sqlText += "       STOCK.SUPPLIERSLIPNORF --仕入伝票番号 " + Environment.NewLine;
                        sqlText += "    ) AS SUBSTOCKDTL" + Environment.NewLine;
                        sqlText += "    ON  SUBSTOCK.ENTERPRISECODERF = SUBSTOCKDTL.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    AND SUBSTOCK.SUPPLIERFORMALRF = SUBSTOCKDTL.SUPPLIERFORMALRF" + Environment.NewLine;
                        sqlText += "    AND SUBSTOCK.SUPPLIERSLIPNORF = SUBSTOCKDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
                        // ADD 2009.03.24 <<<

                        #region DEL 2009.03.24
                        /*
                        sqlText += "    LEFT JOIN " + Environment.NewLine;
                        sqlText += "    (" + Environment.NewLine;
                        sqlText += "       SELECT" + Environment.NewLine;
                        sqlText += "        SUBDTL.ENTERPRISECODERF," + Environment.NewLine;
                        sqlText += "        SUBDTL.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
                        sqlText += "        SUBDTL.STOCKSLIPCDDTLRF, --仕入伝票区分" + Environment.NewLine;
                        sqlText += "        SUBDTL.SUPPLIERSLIPNORF, --仕入伝票番号 " + Environment.NewLine;
                        sqlText += "        SUM(CASE WHEN SUBDTL.TAXATIONCODERF = 0 THEN SUBDTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTOCKOUTTAXRF," + Environment.NewLine;
                        sqlText += "        SUM(CASE WHEN SUBDTL.TAXATIONCODERF = 2 THEN SUBDTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTCKPRCCONSTAXINCLURF" + Environment.NewLine;
                        sqlText += "       FROM" + Environment.NewLine;
                        sqlText += "        STOCKDETAILRF AS SUBDTL" + Environment.NewLine;
                        sqlText += "       WHERE" + Environment.NewLine;
                        sqlText += "        SUBDTL.STOCKSLIPCDDTLRF = 0    --仕入" + Environment.NewLine;
                        sqlText += "        OR SUBDTL.STOCKSLIPCDDTLRF = 1 --返品" + Environment.NewLine;
                        sqlText += "       GROUP BY" + Environment.NewLine;
                        sqlText += "        SUBDTL.ENTERPRISECODERF," + Environment.NewLine;
                        sqlText += "        SUBDTL.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
                        sqlText += "        SUBDTL.STOCKSLIPCDDTLRF, --仕入伝票区分" + Environment.NewLine;
                        sqlText += "        SUBDTL.SUPPLIERSLIPNORF --仕入伝票番号 " + Environment.NewLine;
                        sqlText += "    ) AS SUBSTOCKDTL" + Environment.NewLine;
                        sqlText += "    ON  SUBSTOCK.ENTERPRISECODERF = SUBSTOCKDTL.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    AND SUBSTOCK.SUPPLIERFORMALRF = SUBSTOCKDTL.SUPPLIERFORMALRF" + Environment.NewLine;
                        sqlText += "    AND SUBSTOCK.SUPPLIERSLIPNORF = SUBSTOCKDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
                        sqlText += "    AND ((SUBSTOCK.SUPPLIERSLIPCDRF = 10 AND SUBSTOCKDTL.STOCKSLIPCDDTLRF = 0)" + Environment.NewLine;
                        sqlText += "          OR (SUBSTOCK.SUPPLIERSLIPCDRF = 20 AND SUBSTOCKDTL.STOCKSLIPCDDTLRF = 1)) " + Environment.NewLine;
                        sqlText += "    LEFT JOIN " + Environment.NewLine;
                        sqlText += "    (" + Environment.NewLine;
                        sqlText += "       SELECT" + Environment.NewLine;
                        sqlText += "        SUBDTL.ENTERPRISECODERF," + Environment.NewLine;
                        sqlText += "        SUBDTL.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
                        sqlText += "        SUBDTL.SUPPLIERSLIPNORF, --仕入伝票番号 " + Environment.NewLine;
                        sqlText += "        SUM(CASE WHEN SUBDTL.TAXATIONCODERF = 0 THEN SUBDTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTOCKDISOUTTAXRF," + Environment.NewLine;
                        sqlText += "        SUM(CASE WHEN SUBDTL.TAXATIONCODERF = 2 THEN SUBDTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTCKDISTTLTAXINCLURF" + Environment.NewLine;
                        sqlText += "       FROM" + Environment.NewLine;
                        sqlText += "        STOCKDETAILRF AS SUBDTL" + Environment.NewLine;
                        sqlText += "       WHERE" + Environment.NewLine;
                        sqlText += "        SUBDTL.STOCKSLIPCDDTLRF = 2    --値引" + Environment.NewLine;
                        sqlText += "       GROUP BY" + Environment.NewLine;
                        sqlText += "        SUBDTL.ENTERPRISECODERF," + Environment.NewLine;
                        sqlText += "        SUBDTL.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
                        sqlText += "        SUBDTL.SUPPLIERSLIPNORF --仕入伝票番号 " + Environment.NewLine;
                        sqlText += "    ) AS SUBSTOCKDISDTL" + Environment.NewLine;
                        sqlText += "    ON  SUBSTOCK.ENTERPRISECODERF = SUBSTOCKDISDTL.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    AND SUBSTOCK.SUPPLIERFORMALRF = SUBSTOCKDISDTL.SUPPLIERFORMALRF" + Environment.NewLine;
                        sqlText += "    AND SUBSTOCK.SUPPLIERSLIPNORF = SUBSTOCKDISDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
                        */
                        #endregion 

                        #endregion

                        #endregion

                        #region [ WHERE ]
                        sqlText += "   WHERE SUBSTOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        //sqlText += "    AND  SUBSTOCK.PAYEECODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "    AND  (CASE WHEN (SEARCHSUPPLIER.PAYEECODERF IS NOT NULL) THEN SEARCHSUPPLIER.PAYEECODERF ELSE SUBSTOCK.PAYEECODERF END)=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "    AND (SUBSTOCK.STOCKADDUPADATERF<=@FINDADDUPDATE AND SUBSTOCK.STOCKADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                        sqlText += "    AND  SUBSTOCK.LOGICALDELETECODERF=0" + Environment.NewLine;
                        sqlText += "    AND  SUBSTOCK.SUPPLIERFORMALRF=0" + Environment.NewLine;
                        sqlText += "    AND  SUBSTOCK.DEBITNOTEDIVRF=0" + Environment.NewLine;
                        sqlText += "    AND (SUBSTOCK.SUPPLIERSLIPCDRF = 10 OR SUBSTOCK.SUPPLIERSLIPCDRF = 20)" + Environment.NewLine;
                        sqlText += "    AND (SUBSTOCK.STOCKGOODSCDRF=0 OR SUBSTOCK.STOCKGOODSCDRF = 6)" + Environment.NewLine;
                        #endregion

                        #region [ JOIN ]
                        sqlText += "   ) AS STOCK" + Environment.NewLine;
                        sqlText += "   INNER JOIN SUPPLIERRF AS SUPPLIER" + Environment.NewLine;
                        sqlText += "    ON SUPPLIER.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    AND SUPPLIER.SUPPLIERCDRF = STOCK.PAYEECODERF" + Environment.NewLine;
                        sqlText += "   LEFT JOIN STOCKPROCMONEYRF AS PROCMONEY" + Environment.NewLine;
                        sqlText += "    ON PROCMONEY.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    AND PROCMONEY.FRACPROCMONEYDIVRF = 1" + Environment.NewLine;
                        sqlText += "    AND PROCMONEY.FRACTIONPROCCODERF = SUPPLIER.STOCKCNSTAXFRCPROCCDRF" + Environment.NewLine;

                        #endregion

                        #region [ GROUP BY ]
                        sqlText += "   GROUP BY" + Environment.NewLine;
                        sqlText += "    STOCK.PAYEECODERF," + Environment.NewLine;
                        sqlText += "    SUPPLIER.SUPPLIERNM1RF," + Environment.NewLine;
                        sqlText += "    SUPPLIER.SUPPLIERNM2RF," + Environment.NewLine;
                        sqlText += "    SUPPLIER.SUPPLIERSNMRF,   " + Environment.NewLine;
                        sqlText += "    SUPPLIER.STOCKCNSTAXFRCPROCCDRF," + Environment.NewLine;
                        //sqlText += "    SUPPLIER.SUPPCTAXLAYCDRF," + Environment.NewLine;
                        sqlText += "    SUPPLIER.PAYMENTMONTHCODERF," + Environment.NewLine;
                        sqlText += "    SUPPLIER.PAYMENTDAYRF," + Environment.NewLine;
                        sqlText += "    SUPPLIER.PAYMENTCONDRF," + Environment.NewLine;
                        sqlText += "    SUPPLIER.SUPPCTAXLAYREFCDRF," + Environment.NewLine;
                        sqlText += "    STOCK.TAXCONSTAXLAYMETHODRF," + Environment.NewLine;
                        sqlText += "    PROCMONEY.FRACTIONPROCUNITRF," + Environment.NewLine;
                        sqlText += "    PROCMONEY.FRACTIONPROCCDRF " + Environment.NewLine;
                        sqlText += ") AS SUPLIERPAY" + Environment.NewLine;
                        #endregion

                        #endregion
                        #endregion

                        sqlCommand.CommandText = sqlText;

                        #region  Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                        SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                        findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);
                        if (suplierPayWork.LastCAddUpUpdDate == DateTime.MinValue)
                            findParaLastTimeAddUpDate.Value = 20000101;
                        else
                            findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.LastCAddUpUpdDate);
                        #endregion

                        myReader = sqlCommand.ExecuteReader();

                        double FractionProcUnit = 0;
                        long SetTax = 0;
                        while (myReader.Read())
                        {
                            #region 結果セット
                            suplierPayWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); //端数処理区分
                            FractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF"));           // 端数処理単位
                            suplierPayWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                            suplierPayWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                            suplierPayWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                            suplierPayWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                            suplierPayWork.ResultsSectCd = "00";　// 実績拠点コード(00固定)
                            //suplierPayWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF")); // DEL 2009/04/17
                            suplierPayWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));      // 支払条件
                            suplierPayWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));// 端数処理区分

                            // 今回繰越残高(前回支払額-今回支払金額)
                            suplierPayWork.ThisTimeTtlBlcPay = (suplierPayWork.LastTimePayment + suplierPayWork.StockTtl2TmBfBlPay + suplierPayWork.StockTtl3TmBfBlPay) - suplierPayWork.ThisTimePayNrml;                           

                            //■相殺
                            suplierPayWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
                            suplierPayWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));
                            suplierPayWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));
                            suplierPayWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF"));
                            suplierPayWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));

                            // 相殺後今回仕入消費税額 / 相殺後仕入外税額 >>>
                            // 消費税転嫁区分によってセット内容変動
                            // 修正 2009/04/17 >>>
                            #region DEL 2009/04/17
                            /*
                            //if ((suplierPayWork.SuppCTaxLayCd == 0) || (suplierPayWork.SuppCTaxLayCd == 1) || (suplierPayWork.SuppCTaxLayCd == 2))
                            if ((suplierPayWork.SuppCTaxLayCd == 0) || (suplierPayWork.SuppCTaxLayCd == 1))
                            {
                                // 相殺後仕入外税額 = 今回仕入外税額 + 今回仕入返品外税額 + 今回仕入値引外税額
                                SetTax = 0;
                                FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TTLSTOCKOUTERTAXRF")) + SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TTLRETOUTERTAXRF")) +
                                         SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TTLDISOUTERTAXRF")),FractionProcUnit, suplierPayWork.FractionProcCd, out SetTax);
                                suplierPayWork.OffsetOutTax = SetTax;       // 今回仕入外税額

                                // 相殺後今回仕入消費税額 = 相殺後仕入外税額 + 相殺後仕入内税額
                                suplierPayWork.OfsThisStockTax = suplierPayWork.OffsetOutTax + suplierPayWork.OffsetInTax;       // 相殺後今回仕入消費税額

                            }
                            else if ((suplierPayWork.SuppCTaxLayCd == 2))
                            {
                                // 消費税転嫁区分 = 2:請求親
                                // 相殺後外税金対象額　× 税率
                                SetTax = 0;
                                FracCalc((suplierPayWork.ItdedOffsetOutTax * suplierPayWork.SupplierConsTaxRate), FractionProcUnit, suplierPayWork.FractionProcCd, out SetTax);
                                suplierPayWork.OffsetOutTax = SetTax;

                                // 相殺後今回仕入消費税額 = 相殺後仕入外税額 + 相殺後仕入内税額
                                suplierPayWork.OfsThisStockTax = suplierPayWork.OffsetOutTax + suplierPayWork.OffsetInTax;       // 相殺後今回仕入消費税額
                            }
                            else if ((suplierPayWork.SuppCTaxLayCd == 3))
                            {
                                // 消費税転嫁区分 = 3:請求子
                                // 子レコード集計(相殺後外税金額) × 税率　※子レコード集計時に算出                           
                            }
                            */
                            #endregion

                            // 相殺後仕入外税額 = 今回仕入外税額 + 今回仕入返品外税額 + 今回仕入値引外税額 ※各種転嫁方式別に計算を行う

                            // ①支払(親)　今回仕入外税 + 今回返品外税 + 今回値引外税
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKOUTTAX_S")) + SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_S")) +
                                     SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_S")), FractionProcUnit, suplierPayWork.FractionProcCd, out SetTax);
                            suplierPayWork.OffsetOutTax = SetTax;       

                            // ②支払(子) = 親子レコード集計時に計算

                            // ③伝票転嫁 今回仕入外税 + 今回返品外税 + 今回値引外税
                            suplierPayWork.OffsetOutTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_D")) +
                                                           SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_D"));

                            // ④明細転嫁 今回仕入外税 + 今回返品外税 + 今回値引外税
                            suplierPayWork.OffsetOutTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAX_M")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_M")) +
                                                           SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_M")); 

                            // 相殺後今回仕入消費税額 = 相殺後仕入外税額 + 相殺後仕入内税額
                            suplierPayWork.OfsThisStockTax = suplierPayWork.OffsetOutTax + suplierPayWork.OffsetInTax;       // 相殺後今回仕入消費税額
                            // 修正 2009/04/17 <<<

                            // ■仕入
                            // 修正 2009/04/17 >>>
                            #region DEL 2009/04/17
                            /*
                            suplierPayWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
                            SetTax = 0;
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("THISSTCPRCTAXRF")), FractionProcUnit, suplierPayWork.FractionProcCd, out SetTax);
                            suplierPayWork.ThisStcPrcTax = SetTax;              // 今回仕入消費税額
                            suplierPayWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));
                            suplierPayWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));
                            suplierPayWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
                            // 今回仕入外税額
                            SetTax = 0;
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TTLSTOCKOUTERTAXRF")), FractionProcUnit, suplierPayWork.FractionProcCd, out SetTax);
                            suplierPayWork.TtlStockOuterTax = SetTax;
                            suplierPayWork.TtlStockInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLSTOCKINNERTAXRF"));
                            */
                            #endregion
                            suplierPayWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
                            suplierPayWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));
                            suplierPayWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));
                            suplierPayWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
                            suplierPayWork.TtlStockInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLSTOCKINNERTAXRF"));                            
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKOUTTAX_S")), FractionProcUnit, suplierPayWork.FractionProcCd, out SetTax);
                            SetTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAX_M"));
                            suplierPayWork.TtlStockOuterTax = SetTax;
                            suplierPayWork.ThisStcPrcTax = suplierPayWork.TtlStockOuterTax + suplierPayWork.TtlStockInnerTax; // 今回仕入消費税額
                            // 修正 2009/04/17 <<<

                            // ■返品
                            // 修正 2009/04/17 >>>
                            #region DEL 2009/04/17 
                            /*
                            suplierPayWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
                            SetTax = 0;
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("THISSTCPRCTAXRGDSRF")), FractionProcUnit, suplierPayWork.FractionProcCd, out SetTax);
                            suplierPayWork.ThisStcPrcTaxRgds = SetTax;
                            suplierPayWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));
                            suplierPayWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));
                            suplierPayWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));
                            SetTax = 0;
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TTLRETOUTERTAXRF")), FractionProcUnit, suplierPayWork.FractionProcCd, out SetTax);
                            suplierPayWork.TtlRetOuterTax = SetTax;
                            suplierPayWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));
                            */
                            #endregion
                            suplierPayWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
                            suplierPayWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));
                            suplierPayWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));
                            suplierPayWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));
                            suplierPayWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_S")), FractionProcUnit, suplierPayWork.FractionProcCd, out SetTax);
                            SetTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_M"));
                            suplierPayWork.TtlRetOuterTax = SetTax;
                            suplierPayWork.ThisStcPrcTaxRgds = suplierPayWork.TtlRetOuterTax + suplierPayWork.TtlRetInnerTax;
                            // 修正 2009/04/17 <<<

                            // ■値引
                            // 修正 2009/04/17 >>>
                            #region DEL 2009/04/17
                            /*
                            suplierPayWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
                            SetTax = 0;
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("THISSTCPRCTAXDISRF")), FractionProcUnit, suplierPayWork.FractionProcCd, out SetTax);
                            suplierPayWork.ThisStcPrcTaxDis = SetTax;
                            suplierPayWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));
                            suplierPayWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));
                            suplierPayWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));
                            SetTax = 0;
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TTLDISOUTERTAXRF")), FractionProcUnit, suplierPayWork.FractionProcCd, out SetTax);
                            suplierPayWork.TtlDisOuterTax = SetTax;
                            suplierPayWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));
                            */
                            #endregion
                            suplierPayWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
                            suplierPayWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));
                            suplierPayWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));
                            suplierPayWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));
                            suplierPayWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_S")), FractionProcUnit, suplierPayWork.FractionProcCd, out SetTax);
                            SetTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_M"));
                            suplierPayWork.TtlDisOuterTax = SetTax;
                            suplierPayWork.ThisStcPrcTaxDis = suplierPayWork.TtlDisOuterTax + suplierPayWork.TtlDisInnerTax;
                            // 修正 2009/04/17 <<<

                            suplierPayWork.TaxAdjust = 0;     // 消費税調整額(0固定)
                            suplierPayWork.BalanceAdjust = 0; // 残高調整額(0固定)
                            suplierPayWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNT"));　// 伝票枚数

                            // 仕入合計残高(支払計) >>>
                            // 修正 2009/04/17 >>>
                            #region DEL 2009/04/17 
                            /*
                            // 消費税転嫁区分によってセット内容変動( クエリ内で処理しきれない為、セット時に計算 )
                            if ((suplierPayWork.SuppCTaxLayCd == 0) || (suplierPayWork.SuppCTaxLayCd == 1) || (suplierPayWork.SuppCTaxLayCd == 2))
                            {
                                // 消費税転嫁区分 = 0:伝票 or 1:明細 or 2:請求親
                                // 仕入合計残高(支払計) = 今回繰越金額(支払計) + (相殺後今回仕入金額 + 相殺後今回仕入消費税)
                                suplierPayWork.StockTotalPayBalance = suplierPayWork.ThisTimeTtlBlcPay + (suplierPayWork.OfsThisTimeStock + suplierPayWork.OfsThisStockTax);
                            }
                            else if ((suplierPayWork.SuppCTaxLayCd == 3))
                            {
                                // 消費税転嫁区分 = 3:請求子
                                // 子レコード集計(相殺後外税金額) × 税率　※子レコード集計時に算出                           
                            }
                            else if ((suplierPayWork.SuppCTaxLayCd == 9))
                            {
                                // 消費税転嫁方式 = 非課税
                                // 仕入合計残高(支払計) = 今回繰越金額(支払計) + (相殺後今回仕入金額)
                                suplierPayWork.StockTotalPayBalance = suplierPayWork.ThisTimeTtlBlcPay + (suplierPayWork.OfsThisTimeStock);
                            }
                            */
                            #endregion
                            // 仕入合計残高(支払計) = 今回繰越金額(支払計) + (相殺後今回仕入金額 + 相殺後今回仕入消費税)
                            suplierPayWork.StockTotalPayBalance = suplierPayWork.ThisTimeTtlBlcPay + (suplierPayWork.OfsThisTimeStock + suplierPayWork.OfsThisStockTax);
                            // 修正 2009/04/17 <<<
                            // 仕入合計残高(支払計) <<<

                            // 支払予定日計算 >>>
                            // 集金月区分によってセット内容変動( クエリ内で処理しきれない為、セット時に計算 )
                            DateTime PaymentmoneyDate = suplierPayWork.AddUpDate;
                            switch (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONTHCODERF"))) // 0:当月,1:翌月,2:翌々月,3翌々々月
                            {
                                case 1:
                                    PaymentmoneyDate = PaymentmoneyDate.AddMonths(1);
                                    break;
                                case 2:
                                    PaymentmoneyDate = PaymentmoneyDate.AddMonths(2);
                                    break;
                                case 3:
                                    PaymentmoneyDate = PaymentmoneyDate.AddMonths(3);
                                    break;
                            }
                            // 28日以降は末日とする
                            if (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF")) >= 28)
                            {
                                PaymentmoneyDate = new DateTime(PaymentmoneyDate.Year, PaymentmoneyDate.Month, 1);
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(1);
                                PaymentmoneyDate = PaymentmoneyDate.AddDays(-1);
                            }
                            else
                            {
                                PaymentmoneyDate = new DateTime(PaymentmoneyDate.Year, PaymentmoneyDate.Month, SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF")));
                            }
                            suplierPayWork.PaymentSchedule = PaymentmoneyDate;　// 支払予定日
                            // 支払予定日計算 <<<
                            #endregion
                        }
                        #endregion
                    }

                    // 初期化
                    if (!myReader.IsClosed) myReader.Close();
                    sqlCommand.Parameters.Clear();
                    sqlCommand.CommandText = string.Empty;
                    sqlText = string.Empty;
                    //long itdedOffsetOutTax = 0;
                    long OffsetOutTax = 0;
                    long StockOutTax = 0;       // 仕入外税額
                    long RetStockOutTax = 0;    // 返品外税額
                    long DisStockOutTax = 0;    // 値引外税額

                    int ChildCnt = 0;
                    double fractionProcUnit = 0;
                    long setTax = 0;
                    
                    #region [●親・子レコード作成処理]

                    #region SELECT文作成
                    // 修正 2009/04/17 >>>
                    #region DEL 2009/04/17 
                    /*
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.STOCKSECTIONCDRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.PAYEECODERF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.PAYEENM1RF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.PAYEENM2RF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.PAYEESNMRF, " + Environment.NewLine;
                    sqlText += " SUPLIERPAY.SUPPLIERCDRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.SUPPLIERNM1RF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.SUPPLIERNM2RF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.SUPPLIERSNMRF," + Environment.NewLine;
                    //sqlText += " SUPLIERPAY.STOCKCNSTAXFRCPROCCDRF AS FRACTIONPROCCDRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.FRACTIONPROCUNITRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.FRACTIONPROCCDRF,  " + Environment.NewLine;
                    sqlText += " SUPLIERPAY.SUPPCTAXLAYCDRF," + Environment.NewLine;
                    //支払情報
                    sqlText += " SUPLIERPAY.PAYMENTMONTHCODERF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.PAYMENTDAYRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.PAYMENTCONDRF, " + Environment.NewLine;
                    sqlText += " SUPLIERPAY.STOCKSLIPCOUNT," + Environment.NewLine;
                    //相殺
                    sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF + SUPLIERPAY.THISSTCKPRICRGDSRF + SUPLIERPAY.THISSTCKPRICDISRF AS OFSTHISTIMESTOCKRF," + Environment.NewLine;
                    //相殺後今回仕入消費税はセット時に計算
                    sqlText += " SUPLIERPAY.TTLITDEDSTCOUTTAXRF + SUPLIERPAY.TTLITDEDRETOUTTAXRF+SUPLIERPAY.TTLITDEDDISOUTTAXRF AS ITDEDOFFSETOUTTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDSTCINTAXRF + SUPLIERPAY.TTLITDEDRETINTAXRF+SUPLIERPAY.TTLITDEDDISINTAXRF AS ITDEDOFFSETINTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDSTCTAXFREERF + SUPLIERPAY.TTLITDEDRETTAXFREERF+SUPLIERPAY.TTLITDEDDISTAXFREERF AS ITDEDOFFSETTAXFREERF," + Environment.NewLine;
                    //相殺後外税消費税はセット時に計算
                    sqlText += " SUPLIERPAY.STCKPRCCONSTAXINCLURF+SUPLIERPAY.TTLRETINNERTAXRF+SUPLIERPAY.STCKDISTTLTAXINCLURF AS OFFSETINTAXRF," + Environment.NewLine;
                    //仕入
                    sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF AS THISTIMESTOCKPRICERF," + Environment.NewLine;
                    sqlText += " (CASE WHEN (SUPLIERPAY.SUPPCTAXLAYCDRF=0 ) THEN SUPLIERPAY.STOCKOUTTAXRF" + Environment.NewLine;
                    sqlText += "   ELSE(CASE WHEN SUPLIERPAY.SUPPCTAXLAYCDRF=1 THEN SUPLIERPAY.DTLSTOCKOUTTAXRF" + Environment.NewLine;
                    sqlText += "         ELSE (SUPLIERPAY.STOCKOUTTAXRF1 +SUPLIERPAY.STOCKOUTTAXRF2 +SUPLIERPAY.STOCKOUTTAXRF3)END)END)+SUPLIERPAY.STCKPRCCONSTAXINCLURF AS THISSTCPRCTAXRF, --今回消費税" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDSTCOUTTAXRF AS TTLITDEDSTCOUTTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDSTCINTAXRF AS TTLITDEDSTCINTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDSTCTAXFREERF AS TTLITDEDSTCTAXFREERF," + Environment.NewLine;
                    sqlText += " (CASE WHEN (SUPLIERPAY.SUPPCTAXLAYCDRF=0 ) THEN SUPLIERPAY.STOCKOUTTAXRF" + Environment.NewLine;
                    sqlText += "  ELSE (CASE WHEN SUPLIERPAY.SUPPCTAXLAYCDRF=1 THEN SUPLIERPAY.DTLSTOCKOUTTAXRF " + Environment.NewLine;
                    sqlText += "        ELSE(SUPLIERPAY.STOCKOUTTAXRF1 +SUPLIERPAY.STOCKOUTTAXRF2 +SUPLIERPAY.STOCKOUTTAXRF3) END) END)AS TTLSTOCKOUTERTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.STCKPRCCONSTAXINCLURF AS TTLSTOCKINNERTAXRF," + Environment.NewLine;
                    //返品
                    sqlText += " SUPLIERPAY.THISSTCKPRICRGDSRF AS THISSTCKPRICRGDSRF," + Environment.NewLine;
                    sqlText += " (CASE WHEN (SUPLIERPAY.SUPPCTAXLAYCDRF=0 ) THEN SUPLIERPAY.TTLRETOUTERTAXRF " + Environment.NewLine;
                    sqlText += "   ELSE(CASE WHEN SUPLIERPAY.SUPPCTAXLAYCDRF=1 THEN SUPLIERPAY.DTLTTLRETOUTERTAXRF" + Environment.NewLine;
                    sqlText += "        ELSE (SUPLIERPAY.TTLRETOUTERTAXRF1 +SUPLIERPAY.TTLRETOUTERTAXRF2 +SUPLIERPAY.TTLRETOUTERTAXRF3) END) END)+SUPLIERPAY.TTLRETINNERTAXRF AS THISSTCPRCTAXRGDSRF, --今回消費税" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDRETOUTTAXRF AS TTLITDEDRETOUTTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDRETINTAXRF AS TTLITDEDRETINTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDRETTAXFREERF AS TTLITDEDRETTAXFREERF," + Environment.NewLine;
                    sqlText += " (CASE WHEN (SUPLIERPAY.SUPPCTAXLAYCDRF=0 ) THEN SUPLIERPAY.TTLRETOUTERTAXRF " + Environment.NewLine;
                    sqlText += "   ELSE( CASE WHEN SUPLIERPAY.SUPPCTAXLAYCDRF=1 THEN SUPLIERPAY.DTLTTLRETOUTERTAXRF" + Environment.NewLine;
                    sqlText += "         ELSE (SUPLIERPAY.TTLRETOUTERTAXRF1 +SUPLIERPAY.TTLRETOUTERTAXRF2 +SUPLIERPAY.TTLRETOUTERTAXRF3) END) END) AS TTLRETOUTERTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLRETINNERTAXRF AS TTLRETINNERTAXRF," + Environment.NewLine;
                    //値引
                    sqlText += " SUPLIERPAY.THISSTCKPRICDISRF AS THISSTCKPRICDISRF," + Environment.NewLine;
                    sqlText += " (CASE WHEN (SUPLIERPAY.SUPPCTAXLAYCDRF=0 ) THEN SUPLIERPAY.STOCKDISOUTTAXRF" + Environment.NewLine;
                    sqlText += "   ELSE( CASE WHEN  SUPLIERPAY.SUPPCTAXLAYCDRF=1 THEN SUPLIERPAY.DTLSTOCKDISOUTTAXRF " + Environment.NewLine;
                    sqlText += "         ELSE (SUPLIERPAY.STOCKDISOUTTAXRF1 +SUPLIERPAY.STOCKDISOUTTAXRF2 +SUPLIERPAY.STOCKDISOUTTAXRF3) END) END)+SUPLIERPAY.STCKDISTTLTAXINCLURF AS THISSTCPRCTAXDISRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDDISOUTTAXRF AS TTLITDEDDISOUTTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDDISINTAXRF AS TTLITDEDDISINTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDDISTAXFREERF AS TTLITDEDDISTAXFREERF," + Environment.NewLine;
                    sqlText += " (CASE WHEN (SUPLIERPAY.SUPPCTAXLAYCDRF=0 ) THEN SUPLIERPAY.STOCKDISOUTTAXRF" + Environment.NewLine;
                    sqlText += "   ELSE(CASE WHEN SUPLIERPAY.SUPPCTAXLAYCDRF=1  THEN SUPLIERPAY.DTLSTOCKDISOUTTAXRF" + Environment.NewLine;
                    sqlText += "        ELSE  (SUPLIERPAY.STOCKDISOUTTAXRF1 +SUPLIERPAY.STOCKDISOUTTAXRF2 +SUPLIERPAY.STOCKDISOUTTAXRF3) END) END) AS TTLDISOUTERTAXRF," + Environment.NewLine;

                    sqlText += " SUPLIERPAY.STCKDISTTLTAXINCLURF AS TTLDISINNERTAXRF" + Environment.NewLine;
                    sqlText += " FROM" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    */
                    #endregion 
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.STOCKSECTIONCDRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.PAYEECODERF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.PAYEENM1RF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.PAYEENM2RF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.PAYEESNMRF, " + Environment.NewLine;
                    sqlText += " SUPLIERPAY.SUPPLIERCDRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.SUPPLIERNM1RF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.SUPPLIERNM2RF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.SUPPLIERSNMRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.FRACTIONPROCUNITRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.FRACTIONPROCCDRF,  " + Environment.NewLine;
                    sqlText += " SUPLIERPAY.PAYMENTMONTHCODERF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.PAYMENTDAYRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.PAYMENTCONDRF, " + Environment.NewLine;
                    sqlText += " SUPLIERPAY.STOCKSLIPCOUNT," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF + SUPLIERPAY.THISSTCKPRICRGDSRF + SUPLIERPAY.THISSTCKPRICDISRF AS OFSTHISTIMESTOCKRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDSTCOUTTAXRF + SUPLIERPAY.TTLITDEDRETOUTTAXRF+SUPLIERPAY.TTLITDEDDISOUTTAXRF AS ITDEDOFFSETOUTTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDSTCINTAXRF + SUPLIERPAY.TTLITDEDRETINTAXRF+SUPLIERPAY.TTLITDEDDISINTAXRF AS ITDEDOFFSETINTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDSTCTAXFREERF + SUPLIERPAY.TTLITDEDRETTAXFREERF+SUPLIERPAY.TTLITDEDDISTAXFREERF AS ITDEDOFFSETTAXFREERF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.STCKPRCCONSTAXINCLURF+SUPLIERPAY.TTLRETINNERTAXRF+SUPLIERPAY.STCKDISTTLTAXINCLURF AS OFFSETINTAXRF," + Environment.NewLine;
                    sqlText += " -- ■ ■ 売上 ■ ■" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF AS THISTIMESTOCKPRICERF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDSTCOUTTAXRF AS TTLITDEDSTCOUTTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDSTCINTAXRF AS TTLITDEDSTCINTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDSTCTAXFREERF AS TTLITDEDSTCTAXFREERF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.STOCKOUTTAXRF AS STOCKOUTTAX_D, -- 伝票転嫁" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.DTLSTOCKOUTTAXRF AS STOCKOUTTAX_M, --明細転嫁" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.STOCKOUTTAXRF1 +SUPLIERPAY.STOCKOUTTAXRF2 +SUPLIERPAY.STOCKOUTTAXRF3 AS STOCKOUTTAX_S, --支払親" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.STOCKOUTTAXRF1_2 +SUPLIERPAY.STOCKOUTTAXRF2_2 +SUPLIERPAY.STOCKOUTTAXRF3_2 AS STOCKOUTTAX_S2, --支払子" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.STCKPRCCONSTAXINCLURF AS TTLSTOCKINNERTAXRF," + Environment.NewLine;
                    sqlText += " -- ■ ■ 返品 ■ ■" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.THISSTCKPRICRGDSRF AS THISSTCKPRICRGDSRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDRETOUTTAXRF AS TTLITDEDRETOUTTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDRETINTAXRF AS TTLITDEDRETINTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDRETTAXFREERF AS TTLITDEDRETTAXFREERF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLRETOUTERTAXRF AS RETSTOCKOUTTAX_D,   -- 伝票転嫁" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.DTLTTLRETOUTERTAXRF AS RETSTOCKOUTTAX_M,-- 明細転嫁" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLRETOUTERTAXRF1 +SUPLIERPAY.TTLRETOUTERTAXRF2 +SUPLIERPAY.TTLRETOUTERTAXRF3 AS RETSTOCKOUTTAX_S,-- 支払親転嫁" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLRETOUTERTAXRF1_2 +SUPLIERPAY.TTLRETOUTERTAXRF2_2 +SUPLIERPAY.TTLRETOUTERTAXRF3_2 AS RETSTOCKOUTTAX_S2,-- 支払子転嫁" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLRETINNERTAXRF AS TTLRETINNERTAXRF," + Environment.NewLine;
                    sqlText += " -- ■ ■ 値引 ■ ■" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.THISSTCKPRICDISRF AS THISSTCKPRICDISRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDDISOUTTAXRF AS TTLITDEDDISOUTTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDDISINTAXRF AS TTLITDEDDISINTAXRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.TTLITDEDDISTAXFREERF AS TTLITDEDDISTAXFREERF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.STOCKDISOUTTAXRF AS DISSTOCKOUTTAX_D,   -- 伝票転嫁" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.DTLSTOCKDISOUTTAXRF AS DISSTOCKOUTTAX_M,-- 明細転嫁" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.STOCKDISOUTTAXRF1 +SUPLIERPAY.STOCKDISOUTTAXRF2 +SUPLIERPAY.STOCKDISOUTTAXRF3 AS DISSTOCKOUTTAX_S,       -- 支払親転嫁" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.STOCKDISOUTTAXRF1_2 +SUPLIERPAY.STOCKDISOUTTAXRF2_2 +SUPLIERPAY.STOCKDISOUTTAXRF3_2 AS DISSTOCKOUTTAX_S2,-- 支払子転嫁 " + Environment.NewLine;
                    sqlText += " SUPLIERPAY.STCKDISTTLTAXINCLURF AS TTLDISINNERTAXRF" + Environment.NewLine;
                    sqlText += " FROM" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    // 修正 2009/04/17 <<<

                    #region SUBクエリ
                    // 修正 2009/04/17
                    #region DEL 2009/04/17
                    /*
                    sqlText += " SELECT" + Environment.NewLine;
                    sqlText += "  STOCK.STOCKSECTIONCDRF," + Environment.NewLine;
                    sqlText += "  STOCK.PAYEECODERF," + Environment.NewLine;
                    sqlText += "  SUPPLIER.SUPPLIERNM1RF AS PAYEENM1RF," + Environment.NewLine;
                    sqlText += "  SUPPLIER.SUPPLIERNM2RF AS PAYEENM2RF," + Environment.NewLine;
                    sqlText += "  SUPPLIER.SUPPLIERSNMRF AS PAYEESNMRF," + Environment.NewLine;
                    sqlText += "  STOCK.SUPPLIERCDRF," + Environment.NewLine;
                    sqlText += "  KOSUPPLIER.SUPPLIERNM1RF," + Environment.NewLine;
                    sqlText += "  KOSUPPLIER.SUPPLIERNM2RF," + Environment.NewLine;
                    sqlText += "  KOSUPPLIER.SUPPLIERSNMRF,  " + Environment.NewLine;
                    sqlText += "  SUPPLIER.STOCKCNSTAXFRCPROCCDRF," + Environment.NewLine;                    
                    //sqlText += "  SUPPLIER.SUPPCTAXLAYCDRF," + Environment.NewLine;
                    sqlText += "  (CASE WHEN SUPPLIER.SUPPCTAXLAYREFCDRF = 0 THEN STOCK.TAXCONSTAXLAYMETHODRF ELSE SUPPLIER.SUPPCTAXLAYCDRF END) AS  SUPPCTAXLAYCDRF," + Environment.NewLine;
                    sqlText += "  PROCMONEY.FRACTIONPROCUNITRF," + Environment.NewLine;
                    sqlText += "  PROCMONEY.FRACTIONPROCCDRF, " + Environment.NewLine;
                    sqlText += "  SUPPLIER.PAYMENTMONTHCODERF," + Environment.NewLine;
                    sqlText += "  SUPPLIER.PAYMENTDAYRF," + Environment.NewLine;
                    sqlText += "  SUPPLIER.PAYMENTCONDRF," + Environment.NewLine;
                    sqlText += "  COUNT(STOCK.SUPPLIERSLIPNORF) STOCKSLIPCOUNT, --伝票枚数" + Environment.NewLine;
                    //仕入
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STOCKNETPRICERF ELSE 0 END)) AS THISTIMESTOCKPRICERF,       --仕入正価金額" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCOUTTAXRF ELSE 0 END)) AS TTLITDEDSTCOUTTAXRF,    --仕入外税対象額合計" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCINTAXRF ELSE 0 END)) AS TTLITDEDSTCINTAXRF,      --仕入内税対象額合計" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCTAXFREERF ELSE 0 END)) AS TTLITDEDSTCTAXFREERF,  --仕入非課税対象額合計" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STOCKOUTTAXRF ELSE 0 END)) AS STOCKOUTTAXRF,                --消費税額（外税）伝票" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.DTLSTOCKOUTTAXRF ELSE 0 END)) AS DTLSTOCKOUTTAXRF,          --消費税額（外税）明細" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
                    sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS STOCKOUTTAXRF1,                     --消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS STOCKOUTTAXRF2,                          --消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS STOCKOUTTAXRF3,                          --消費税額（外税）税率3" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STCKPRCCONSTAXINCLURF ELSE 0 END)) AS STCKPRCCONSTAXINCLURF,--消費税額（内税）" + Environment.NewLine;
                    //返品
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STOCKNETPRICERF ELSE 0 END)) AS THISSTCKPRICRGDSRF,        --仕入正価金額" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCOUTTAXRF ELSE 0 END)) AS TTLITDEDRETOUTTAXRF,   --仕入外税対象額合計" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCINTAXRF ELSE 0 END)) AS TTLITDEDRETINTAXRF,     --仕入内税対象額合計" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCTAXFREERF ELSE 0 END)) AS TTLITDEDRETTAXFREERF, --仕入非課税対象額合計" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STOCKOUTTAXRF ELSE 0 END)) AS TTLRETOUTERTAXRF,            --消費税額（外税）伝票" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.DTLSTOCKOUTTAXRF ELSE 0 END)) AS DTLTTLRETOUTERTAXRF,      --消費税額（外税）明細" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
                    sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS TTLRETOUTERTAXRF1,                 --消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS TTLRETOUTERTAXRF2,                      --消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "           THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS TTLRETOUTERTAXRF3,                       --消費税額（外税）税率3" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STCKPRCCONSTAXINCLURF ELSE 0 END)) AS TTLRETINNERTAXRF,    --消費税額（内税）" + Environment.NewLine;
                    //値引
                    sqlText += "  SUM(STOCK.STCKDISTTLTAXEXCRF) AS THISSTCKPRICDISRF,        --値引金額計（税抜き）" + Environment.NewLine;
                    sqlText += "  SUM(STOCK.ITDEDSTOCKDISOUTTAXRF) AS TTLITDEDDISOUTTAXRF,   --値引外税対象額合計" + Environment.NewLine;
                    sqlText += "  SUM(STOCK.ITDEDSTOCKDISINTAXRF) AS TTLITDEDDISINTAXRF,     --値引内税対象額合計 " + Environment.NewLine;
                    sqlText += "  SUM(STOCK.ITDEDSTOCKDISTAXFRERF) AS TTLITDEDDISTAXFREERF,  --値引非課税対象額合計   " + Environment.NewLine;
                    sqlText += "  SUM(STOCK.STOCKDISOUTTAXRF) AS STOCKDISOUTTAXRF,           --値引消費税額（外税）伝票" + Environment.NewLine;
                    sqlText += "  SUM(STOCK.STOCKDISOUTTAXRF) AS DTLSTOCKDISOUTTAXRF,     --値引消費税額（外税）明細" + Environment.NewLine;  // 2009.01.21 
                    sqlText += "  SUM((CASE WHEN (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
                    sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATERF)ELSE 0 END)) AS STOCKDISOUTTAXRF1,              --売上値引消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE2RF)ELSE 0 END)) AS STOCKDISOUTTAXRF2,             --売上値引消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE3RF)ELSE 0 END)) AS STOCKDISOUTTAXRF3,             --売上値引消費税額（外税）税率3" + Environment.NewLine;
                    sqlText += "  SUM(STOCK.STCKDISTTLTAXINCLURF) AS STCKDISTTLTAXINCLURF    --売上値引消費税額（内税）" + Environment.NewLine;
                    sqlText += "  FROM" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    */
                    #endregion
                    sqlText += " SELECT" + Environment.NewLine;
                    sqlText += "  STOCK.STOCKSECTIONCDRF," + Environment.NewLine;
                    sqlText += "  STOCK.PAYEECODERF," + Environment.NewLine;
                    sqlText += "  SUPPLIER.SUPPLIERNM1RF AS PAYEENM1RF," + Environment.NewLine;
                    sqlText += "  SUPPLIER.SUPPLIERNM2RF AS PAYEENM2RF," + Environment.NewLine;
                    sqlText += "  SUPPLIER.SUPPLIERSNMRF AS PAYEESNMRF," + Environment.NewLine;
                    sqlText += "  STOCK.SUPPLIERCDRF," + Environment.NewLine;
                    sqlText += "  KOSUPPLIER.SUPPLIERNM1RF," + Environment.NewLine;
                    sqlText += "  KOSUPPLIER.SUPPLIERNM2RF," + Environment.NewLine;
                    sqlText += "  KOSUPPLIER.SUPPLIERSNMRF,  " + Environment.NewLine;
                    sqlText += "  SUPPLIER.STOCKCNSTAXFRCPROCCDRF," + Environment.NewLine;
                    sqlText += "  PROCMONEY.FRACTIONPROCUNITRF," + Environment.NewLine;
                    sqlText += "  PROCMONEY.FRACTIONPROCCDRF, " + Environment.NewLine;
                    sqlText += "  SUPPLIER.PAYMENTMONTHCODERF," + Environment.NewLine;
                    sqlText += "  SUPPLIER.PAYMENTDAYRF," + Environment.NewLine;
                    sqlText += "  SUPPLIER.PAYMENTCONDRF," + Environment.NewLine;
                    sqlText += "  COUNT(STOCK.SUPPLIERSLIPNORF) STOCKSLIPCOUNT, --伝票枚数" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STOCKNETPRICERF ELSE 0 END)) AS THISTIMESTOCKPRICERF,       --仕入正価金額" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCOUTTAXRF ELSE 0 END)) AS TTLITDEDSTCOUTTAXRF,    --仕入外税対象額合計" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCINTAXRF ELSE 0 END)) AS TTLITDEDSTCINTAXRF,      --仕入内税対象額合計" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCTAXFREERF ELSE 0 END)) AS TTLITDEDSTCTAXFREERF,  --仕入非課税対象額合計 " + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 0) AND (STOCK.SUPPLIERSLIPCDRF =10) THEN STOCK.STOCKOUTTAXRF ELSE 0 END)) AS STOCKOUTTAXRF,      --消費税額（外税）伝票" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 1) AND (STOCK.SUPPLIERSLIPCDRF =10) THEN STOCK.DTLSTOCKOUTTAXRF ELSE 0 END)) AS DTLSTOCKOUTTAXRF,--消費税額（外税）明細" + Environment.NewLine;
                    sqlText += "  -- 支払親" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
                    sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS STOCKOUTTAXRF1,--消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS STOCKOUTTAXRF2,     --消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS STOCKOUTTAXRF3,     --消費税額（外税）税率3" + Environment.NewLine;
                    sqlText += "  -- 支払子" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
                    sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS STOCKOUTTAXRF1_2,--消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS STOCKOUTTAXRF2_2,     --消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS STOCKOUTTAXRF3_2,     --消費税額（外税）税率3            " + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STCKPRCCONSTAXINCLURF ELSE 0 END)) AS STCKPRCCONSTAXINCLURF,--消費税額（内税）" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STOCKNETPRICERF       ELSE 0 END)) AS THISSTCKPRICRGDSRF,   --仕入正価金額" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCOUTTAXRF   ELSE 0 END)) AS TTLITDEDRETOUTTAXRF,  --仕入外税対象額合計" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCINTAXRF    ELSE 0 END)) AS TTLITDEDRETINTAXRF,   --仕入内税対象額合計" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCTAXFREERF  ELSE 0 END)) AS TTLITDEDRETTAXFREERF, --仕入非課税対象額合計  " + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 0) AND (STOCK.SUPPLIERSLIPCDRF =20) THEN STOCK.STOCKOUTTAXRF ELSE 0 END)) AS TTLRETOUTERTAXRF,      --消費税額（外税）伝票" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 1) AND (STOCK.SUPPLIERSLIPCDRF =20) THEN STOCK.DTLSTOCKOUTTAXRF ELSE 0 END)) AS DTLTTLRETOUTERTAXRF,--消費税額（外税）明細" + Environment.NewLine;
                    sqlText += "  -- 支払親" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
                    sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS TTLRETOUTERTAXRF1,--消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS TTLRETOUTERTAXRF2,     --消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "           THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS TTLRETOUTERTAXRF3,      --消費税額（外税）税率3" + Environment.NewLine;
                    sqlText += "  -- 支払子" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
                    sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS TTLRETOUTERTAXRF1_2,--消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS TTLRETOUTERTAXRF2_2,     --消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "           THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS TTLRETOUTERTAXRF3_2,      --消費税額（外税）税率3           " + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STCKPRCCONSTAXINCLURF ELSE 0 END)) AS TTLRETINNERTAXRF,--消費税額（内税）" + Environment.NewLine;
                    sqlText += "  SUM(STOCK.STCKDISTTLTAXEXCRF) AS THISSTCKPRICDISRF,      --値引金額計（税抜き）" + Environment.NewLine;
                    sqlText += "  SUM(STOCK.ITDEDSTOCKDISOUTTAXRF) AS TTLITDEDDISOUTTAXRF, --値引外税対象額合計" + Environment.NewLine;
                    sqlText += "  SUM(STOCK.ITDEDSTOCKDISINTAXRF) AS TTLITDEDDISINTAXRF,   --値引内税対象額合計" + Environment.NewLine;
                    sqlText += "  SUM(STOCK.ITDEDSTOCKDISTAXFRERF) AS TTLITDEDDISTAXFREERF,--値引非課税対象額合計" + Environment.NewLine;
                    sqlText += "  SUM(CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 0) THEN STOCK.STOCKDISOUTTAXRF ELSE 0 END) AS STOCKDISOUTTAXRF,   --値引消費税額（外税）伝票" + Environment.NewLine;
                    sqlText += "  SUM(CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 1) THEN STOCK.STOCKDISOUTTAXRF ELSE 0 END) AS DTLSTOCKDISOUTTAXRF,--値引消費税額（外税）明細" + Environment.NewLine;
                    sqlText += "  -- 支払親" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
                    sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATERF)ELSE 0 END)) AS STOCKDISOUTTAXRF1, --売上値引消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE2RF)ELSE 0 END)) AS STOCKDISOUTTAXRF2,--売上値引消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE3RF)ELSE 0 END)) AS STOCKDISOUTTAXRF3,--売上値引消費税額（外税）税率3" + Environment.NewLine;
                    sqlText += "  -- 支払子" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
                    sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATERF)ELSE 0 END)) AS STOCKDISOUTTAXRF1_2, --売上値引消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE2RF)ELSE 0 END)) AS STOCKDISOUTTAXRF2_2,--売上値引消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE3RF)ELSE 0 END)) AS STOCKDISOUTTAXRF3_2,--売上値引消費税額（外税）税率3" + Environment.NewLine;
                    sqlText += "  SUM(STOCK.STCKDISTTLTAXINCLURF) AS STCKDISTTLTAXINCLURF    --売上値引消費税額（内税）" + Environment.NewLine;
                    sqlText += "  FROM" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    // 修正 2009/04/17 <<<

                    #region SUBSUBクエリ
                    sqlText += "   SELECT" + Environment.NewLine;
                    sqlText += "    SUBSTOCK.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.SUPPCTAXLAYCDRF,  --消費税転嫁方式" + Environment.NewLine; // ADD 2009/04/17 
                    sqlText += "    SUBSTOCK.SUPPLIERFORMALRF, --仕入形式" + Environment.NewLine;
                    sqlText += "    SUBSTOCK.DEBITNOTEDIVRF,   --赤伝区分" + Environment.NewLine;
                    sqlText += "    SUBSTOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
                    sqlText += "    SUBSTOCK.STOCKGOODSCDRF,   --仕入商品区分" + Environment.NewLine;
                    sqlText += "    SUBSTOCK.SUPPLIERSLIPNORF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.STOCKADDUPADATERF," + Environment.NewLine;
                    sqlText += "    (CASE WHEN (SEARCHSUPPLIER.PAYEECODERF IS NOT NULL) THEN SEARCHSUPPLIER.PAYEECODERF ELSE SUBSTOCK.PAYEECODERF END) AS PAYEECODERF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.SUPPLIERCDRF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.STOCKSECTIONCDRF," + Environment.NewLine;

                    // 修正 2009.03.24 >>>
                    ////仕入・返品
                    //sqlText += "    SUBSTOCK.STOCKNETPRICERF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCK.TTLITDEDSTCOUTTAXRF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCK.TTLITDEDSTCINTAXRF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCK.TTLITDEDSTCTAXFREERF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCK.STOCKOUTTAXRF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCK.STCKPRCCONSTAXINCLURF," + Environment.NewLine;
                    ////値引
                    //sqlText += "    SUBSTOCK.STCKDISTTLTAXEXCRF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCK.ITDEDSTOCKDISOUTTAXRF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCK.ITDEDSTOCKDISINTAXRF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCK.ITDEDSTOCKDISTAXFRERF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCK.STOCKDISOUTTAXRF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCK.STCKDISTTLTAXINCLURF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCKDTL.DTLSTOCKOUTTAXRF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCKDTL.DTLSTCKPRCCONSTAXINCLURF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCKDISDTL.DTLSTOCKDISOUTTAXRF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCKDISDTL.DTLSTCKDISTTLTAXINCLURF," + Environment.NewLine;
                    //仕入・返品(行値引含む)
                    sqlText += "    SUBSTOCK.STOCKNETPRICERF + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STOCKNETPRICERF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.TTLITDEDSTCOUTTAXRF + SUBSTOCKDTL.ITDEDSTOCKDISOUTTAXGYO AS TTLITDEDSTCOUTTAXRF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.TTLITDEDSTCINTAXRF + SUBSTOCKDTL.ITDEDSTOCKDISINTAXGYO AS TTLITDEDSTCINTAXRF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.TTLITDEDSTCTAXFREERF + SUBSTOCKDTL.ITDEDSTOCKDISFREETAXGYO AS TTLITDEDSTCTAXFREERF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.STOCKOUTTAXRF + SUBSTOCKDTL.STOCKDISOUTTAXGYO AS STOCKOUTTAXRF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.STCKPRCCONSTAXINCLURF + SUBSTOCKDTL.STOCKDISINTAXGYO AS STCKPRCCONSTAXINCLURF," + Environment.NewLine;
                    //値引(行値引除く)
                    sqlText += "    SUBSTOCK.STCKDISTTLTAXEXCRF - SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STCKDISTTLTAXEXCRF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.ITDEDSTOCKDISOUTTAXRF - SUBSTOCKDTL.ITDEDSTOCKDISOUTTAXGYO AS ITDEDSTOCKDISOUTTAXRF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.ITDEDSTOCKDISINTAXRF - SUBSTOCKDTL.ITDEDSTOCKDISINTAXGYO AS ITDEDSTOCKDISINTAXRF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.ITDEDSTOCKDISTAXFRERF - SUBSTOCKDTL.ITDEDSTOCKDISFREETAXGYO AS ITDEDSTOCKDISTAXFRERF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.STOCKDISOUTTAXRF - SUBSTOCKDTL.STOCKDISOUTTAXGYO AS STOCKDISOUTTAXRF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.STCKDISTTLTAXINCLURF - SUBSTOCKDTL.STOCKDISINTAXGYO AS STCKDISTTLTAXINCLURF," + Environment.NewLine;
                    sqlText += "    SUBSTOCKDTL.DTLSTOCKOUTTAXRF + SUBSTOCKDTL.STOCKDISOUTTAXGYO AS DTLSTOCKOUTTAXRF," + Environment.NewLine;
                    sqlText += "    SUBSTOCKDTL.DTLSTCKPRCCONSTAXINCLURF + SUBSTOCKDTL.STOCKDISINTAXGYO AS DTLSTCKPRCCONSTAXINCLURF," + Environment.NewLine;
                    // 修正 2009.03.24 <<<

                    sqlText += "    TAX.TAXRATESTARTDATERF AS TAXRATESTARTDATERF," + Environment.NewLine;
                    sqlText += "    TAX.TAXRATEENDDATERF AS TAXRATEENDDATERF," + Environment.NewLine;
                    sqlText += "    TAX.TAXRATERF AS TAXRATERF," + Environment.NewLine;
                    sqlText += "    TAX.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF," + Environment.NewLine;
                    sqlText += "    TAX.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF," + Environment.NewLine;
                    sqlText += "    TAX.TAXRATE2RF AS TAXRATE2RF," + Environment.NewLine;
                    sqlText += "    TAX.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF," + Environment.NewLine;
                    sqlText += "    TAX.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF," + Environment.NewLine;
                    sqlText += "    TAX.TAXRATE3RF AS TAXRATE3RF," + Environment.NewLine;
                    sqlText += "    TAX.CONSTAXLAYMETHODRF AS TAXCONSTAXLAYMETHODRF" + Environment.NewLine;
                    sqlText += "   FROM" + Environment.NewLine;
                    sqlText += "    STOCKSLIPRF AS SUBSTOCK" + Environment.NewLine;

                    #region [SUBSUBクエリ JOIN]
                    sqlText += "    LEFT JOIN TAXRATESETRF AS TAX" + Environment.NewLine;
                    sqlText += "     ON SUBSTOCK.ENTERPRISECODERF = TAX.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    LEFT JOIN SUPPLIERRF AS SEARCHSUPPLIER" + Environment.NewLine;
                    sqlText += "     ON SUBSTOCK.ENTERPRISECODERF = SEARCHSUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "     AND SUBSTOCK.SUPPLIERCDRF = SEARCHSUPPLIER.SUPPLIERCDRF" + Environment.NewLine;
                    // ADD 2009.03.24 >>>
                    sqlText += "    LEFT JOIN" + Environment.NewLine;
                    sqlText += "    ( " + Environment.NewLine;
                    sqlText += "      SELECT" + Environment.NewLine;
                    sqlText += "       STOCK.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "       STOCK.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
                    sqlText += "       STOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
                    sqlText += "       STOCK.SUPPLIERSLIPNORF, --仕入伝票番号 " + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF != 2 AND DTL.TAXATIONCODERF = 0) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTOCKOUTTAXRF," + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF != 2 AND DTL.TAXATIONCODERF = 2) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTCKPRCCONSTAXINCLURF," + Environment.NewLine;
                    sqlText += "       -- 行値引" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS DISSTOCKPRICETAXEXCGYO," + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISOUTTAXGYO, -- 外税対象額(行値引)" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 1 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISFREETAXGYO,-- 非課税対象額(行値引)" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 2 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISINTAXGYO,  -- 内税対象額(行値引)" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 0 ) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS STOCKDISOUTTAXGYO, -- 外税額(行値引)" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 2 ) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS STOCKDISINTAXGYO  -- 内税額(行値引)" + Environment.NewLine;
                    //sqlText += "       -- 商品値引" + Environment.NewLine;
                    //sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF != 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS DISSTOCKPRICETAXEXCGOODS," + Environment.NewLine;
                    //sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF != 0 AND DTL.TAXATIONCODERF = 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISOUTTAXGOODS, -- 外税対象額(商品値引)" + Environment.NewLine;
                    //sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF != 0 AND DTL.TAXATIONCODERF = 1 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISFREETAXGOODS,-- 非課税対象額(商品値引)" + Environment.NewLine;
                    //sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF != 0 AND DTL.TAXATIONCODERF = 2 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISINTAXGOODS,  -- 内税対象額(商品値引)" + Environment.NewLine;
                    //sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF != 0 AND DTL.TAXATIONCODERF = 0 ) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS STOCKDISOUTTAXGOODS, -- 外税額(商品値引)" + Environment.NewLine;
                    //sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF != 0 AND DTL.TAXATIONCODERF = 2 ) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS STOCKDISINTAXGOODS  -- 内税額(商品値引)" + Environment.NewLine;
                    sqlText += "      FROM" + Environment.NewLine;
                    sqlText += "       STOCKDETAILRF AS DTL" + Environment.NewLine;
                    sqlText += "      LEFT JOIN STOCKSLIPRF AS STOCK" + Environment.NewLine;
                    sqlText += "       ON DTL.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "       AND DTL.SUPPLIERFORMALRF = STOCK.SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += "       AND DTL.SUPPLIERSLIPNORF = STOCK.SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += "      GROUP BY" + Environment.NewLine;
                    sqlText += "       STOCK.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "       STOCK.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
                    sqlText += "       STOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
                    sqlText += "       STOCK.SUPPLIERSLIPNORF --仕入伝票番号 " + Environment.NewLine;
                    sqlText += "    ) AS SUBSTOCKDTL" + Environment.NewLine;
                    sqlText += "    ON  SUBSTOCK.ENTERPRISECODERF = SUBSTOCKDTL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    AND SUBSTOCK.SUPPLIERFORMALRF = SUBSTOCKDTL.SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += "    AND SUBSTOCK.SUPPLIERSLIPNORF = SUBSTOCKDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
                    // ADD 2009.03.24 <<<

                    #region DEL 2009.03.24 
                    // ADD 2009.01.21 >>>
                    //sqlText += "    LEFT JOIN " + Environment.NewLine;
                    //sqlText += "    (" + Environment.NewLine;
                    //sqlText += "       SELECT" + Environment.NewLine;
                    //sqlText += "        SUBDTL.ENTERPRISECODERF," + Environment.NewLine;
                    //sqlText += "        SUBDTL.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
                    //sqlText += "        SUBDTL.STOCKSLIPCDDTLRF, --仕入伝票区分" + Environment.NewLine;
                    //sqlText += "        SUBDTL.SUPPLIERSLIPNORF, --仕入伝票番号 " + Environment.NewLine;
                    //sqlText += "        SUM(CASE WHEN SUBDTL.TAXATIONCODERF = 0 THEN SUBDTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTOCKOUTTAXRF," + Environment.NewLine;
                    //sqlText += "        SUM(CASE WHEN SUBDTL.TAXATIONCODERF = 2 THEN SUBDTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTCKPRCCONSTAXINCLURF" + Environment.NewLine;
                    //sqlText += "       FROM" + Environment.NewLine;
                    //sqlText += "        STOCKDETAILRF AS SUBDTL" + Environment.NewLine;
                    //sqlText += "       WHERE" + Environment.NewLine;
                    //sqlText += "        SUBDTL.STOCKSLIPCDDTLRF = 0    --仕入" + Environment.NewLine;
                    //sqlText += "        OR SUBDTL.STOCKSLIPCDDTLRF = 1 --返品" + Environment.NewLine;
                    //sqlText += "       GROUP BY" + Environment.NewLine;
                    //sqlText += "        SUBDTL.ENTERPRISECODERF," + Environment.NewLine;
                    //sqlText += "        SUBDTL.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
                    //sqlText += "        SUBDTL.STOCKSLIPCDDTLRF, --仕入伝票区分" + Environment.NewLine;
                    //sqlText += "        SUBDTL.SUPPLIERSLIPNORF --仕入伝票番号 " + Environment.NewLine;
                    //sqlText += "    ) AS SUBSTOCKDTL" + Environment.NewLine;
                    //sqlText += "    ON  SUBSTOCK.ENTERPRISECODERF = SUBSTOCKDTL.ENTERPRISECODERF" + Environment.NewLine;
                    //sqlText += "    AND SUBSTOCK.SUPPLIERFORMALRF = SUBSTOCKDTL.SUPPLIERFORMALRF" + Environment.NewLine;
                    //sqlText += "    AND SUBSTOCK.SUPPLIERSLIPNORF = SUBSTOCKDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
                    //sqlText += "    AND ((SUBSTOCK.SUPPLIERSLIPCDRF = 10 AND SUBSTOCKDTL.STOCKSLIPCDDTLRF = 0)" + Environment.NewLine;
                    //sqlText += "          OR (SUBSTOCK.SUPPLIERSLIPCDRF = 20 AND SUBSTOCKDTL.STOCKSLIPCDDTLRF = 1)) " + Environment.NewLine;
                    //sqlText += "    LEFT JOIN " + Environment.NewLine;
                    //sqlText += "    (" + Environment.NewLine;
                    //sqlText += "       SELECT" + Environment.NewLine;
                    //sqlText += "        SUBDTL.ENTERPRISECODERF," + Environment.NewLine;
                    //sqlText += "        SUBDTL.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
                    //sqlText += "        SUBDTL.SUPPLIERSLIPNORF, --仕入伝票番号 " + Environment.NewLine;
                    //sqlText += "        SUM(CASE WHEN SUBDTL.TAXATIONCODERF = 0 THEN SUBDTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTOCKDISOUTTAXRF," + Environment.NewLine;
                    //sqlText += "        SUM(CASE WHEN SUBDTL.TAXATIONCODERF = 2 THEN SUBDTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTCKDISTTLTAXINCLURF" + Environment.NewLine;
                    //sqlText += "       FROM" + Environment.NewLine;
                    //sqlText += "        STOCKDETAILRF AS SUBDTL" + Environment.NewLine;
                    //sqlText += "       WHERE" + Environment.NewLine;
                    //sqlText += "        SUBDTL.STOCKSLIPCDDTLRF = 2    --値引" + Environment.NewLine;
                    //sqlText += "       GROUP BY" + Environment.NewLine;
                    //sqlText += "        SUBDTL.ENTERPRISECODERF," + Environment.NewLine;
                    //sqlText += "        SUBDTL.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
                    //sqlText += "        SUBDTL.SUPPLIERSLIPNORF --仕入伝票番号 " + Environment.NewLine;
                    //sqlText += "    ) AS SUBSTOCKDISDTL" + Environment.NewLine;
                    //sqlText += "    ON  SUBSTOCK.ENTERPRISECODERF = SUBSTOCKDISDTL.ENTERPRISECODERF" + Environment.NewLine;
                    //sqlText += "    AND SUBSTOCK.SUPPLIERFORMALRF = SUBSTOCKDISDTL.SUPPLIERFORMALRF" + Environment.NewLine;
                    //sqlText += "    AND SUBSTOCK.SUPPLIERSLIPNORF = SUBSTOCKDISDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
                    // ADD 2009.01.21 <<<
                    #endregion

                    #endregion
                    #endregion

                    #region WHERE句
                    sqlText += "   WHERE SUBSTOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND  (CASE WHEN (SEARCHSUPPLIER.PAYEECODERF IS NOT NULL) THEN SEARCHSUPPLIER.PAYEECODERF ELSE SUBSTOCK.PAYEECODERF END)=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "    AND (SUBSTOCK.STOCKADDUPADATERF<=@FINDADDUPDATE AND SUBSTOCK.STOCKADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                    sqlText += "    AND  SUBSTOCK.LOGICALDELETECODERF=0" + Environment.NewLine;
                    sqlText += "    AND  SUBSTOCK.SUPPLIERFORMALRF=0" + Environment.NewLine;
                    sqlText += "    AND  SUBSTOCK.DEBITNOTEDIVRF=0" + Environment.NewLine;
                    sqlText += "    AND (SUBSTOCK.SUPPLIERSLIPCDRF = 10 OR SUBSTOCK.SUPPLIERSLIPCDRF = 20)" + Environment.NewLine;
                    sqlText += "    AND (SUBSTOCK.STOCKGOODSCDRF=0 OR SUBSTOCK.STOCKGOODSCDRF = 6)     " + Environment.NewLine;
                    #endregion

                    #region JOIN 句
                    sqlText += "   ) AS STOCK" + Environment.NewLine;
                    sqlText += "   INNER JOIN SUPPLIERRF AS SUPPLIER" + Environment.NewLine;
                    sqlText += "    ON SUPPLIER.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    AND SUPPLIER.SUPPLIERCDRF = STOCK.PAYEECODERF" + Environment.NewLine;
                    sqlText += "   LEFT JOIN SUPPLIERRF AS KOSUPPLIER" + Environment.NewLine;
                    sqlText += "    ON KOSUPPLIER.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    AND KOSUPPLIER.SUPPLIERCDRF = STOCK.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += "   LEFT JOIN STOCKPROCMONEYRF AS PROCMONEY" + Environment.NewLine;
                    sqlText += "    ON PROCMONEY.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    AND PROCMONEY.FRACPROCMONEYDIVRF = 1" + Environment.NewLine;
                    sqlText += "    AND PROCMONEY.FRACTIONPROCCODERF = SUPPLIER.STOCKCNSTAXFRCPROCCDRF" + Environment.NewLine;
                    #endregion

                    #region GROUP BY句
                    sqlText += "   GROUP BY" + Environment.NewLine;
                    sqlText += "    STOCK.STOCKSECTIONCDRF, " + Environment.NewLine;
                    sqlText += "    STOCK.PAYEECODERF," + Environment.NewLine;
                    sqlText += "    SUPPLIER.SUPPLIERNM1RF," + Environment.NewLine;
                    sqlText += "    SUPPLIER.SUPPLIERNM2RF," + Environment.NewLine;
                    sqlText += "    SUPPLIER.SUPPLIERSNMRF,   " + Environment.NewLine;
                    sqlText += "    STOCK.SUPPLIERCDRF," + Environment.NewLine;
                    sqlText += "    KOSUPPLIER.SUPPLIERNM1RF," + Environment.NewLine;
                    sqlText += "    KOSUPPLIER.SUPPLIERNM2RF," + Environment.NewLine;
                    sqlText += "    KOSUPPLIER.SUPPLIERSNMRF,    " + Environment.NewLine;
                    sqlText += "    SUPPLIER.STOCKCNSTAXFRCPROCCDRF," + Environment.NewLine;
                    sqlText += "    PROCMONEY.FRACTIONPROCUNITRF," + Environment.NewLine;
                    sqlText += "    PROCMONEY.FRACTIONPROCCDRF,     " + Environment.NewLine;
                    //sqlText += "    SUPPLIER.SUPPCTAXLAYCDRF," + Environment.NewLine;
                    sqlText += "    SUPPLIER.PAYMENTMONTHCODERF," + Environment.NewLine;
                    sqlText += "    SUPPLIER.PAYMENTDAYRF," + Environment.NewLine;
                    sqlText += "    SUPPLIER.SUPPCTAXLAYREFCDRF," + Environment.NewLine;
                    sqlText += "    STOCK.TAXCONSTAXLAYMETHODRF," + Environment.NewLine;
                    sqlText += "    SUPPLIER.PAYMENTCONDRF    " + Environment.NewLine;
                    sqlText += ") AS SUPLIERPAY" + Environment.NewLine;
                    #endregion

                    #endregion

                    #endregion

                    sqlCommand.CommandText = sqlText;

                    #region Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCodeChild = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCodeChild = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDateChild = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastTimeAddUpDateChild = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
                    #endregion

                    #region Parameterオブジェクトへ値設定
                    findParaEnterpriseCodeChild.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    findParaCustomerCodeChild.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                    findParaAddUpDateChild.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);
                    if (suplierPayWork.LastCAddUpUpdDate == DateTime.MinValue)
                        findParaLastTimeAddUpDateChild.Value = 20000101;
                    else
                        findParaLastTimeAddUpDateChild.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.LastCAddUpUpdDate);
                    #endregion

                    myReader = sqlCommand.ExecuteReader();

                    fractionProcUnit = 0;
                    setTax = 0;

                    while (myReader.Read())
                    {
                        #region 結果セット
                        SuplierPayWork suplierPayChildWork = new SuplierPayWork();

                        suplierPayChildWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));   // 支払先コード
                        suplierPayChildWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENM1RF"));
                        suplierPayChildWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENM2RF"));
                        suplierPayChildWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                        //■ 親子レコードのみセット項目↓↓ ※集計レコードは未設定
                        suplierPayChildWork.ResultsSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));　// 実績拠点コード
                        suplierPayChildWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));         // 仕入先コード
                        suplierPayChildWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                        suplierPayChildWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                        suplierPayChildWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                        //■ 親子レコードのみセット項目↑↑
                        suplierPayChildWork.EnterpriseCode = suplierPayWork.EnterpriseCode;
                        suplierPayChildWork.AddUpSecCode = suplierPayWork.AddUpSecCode;
                        suplierPayChildWork.AddUpDate = suplierPayWork.AddUpDate;           // 計上年月日
                        suplierPayChildWork.AddUpYearMonth = suplierPayWork.AddUpYearMonth; // 計上年月
                        suplierPayChildWork.SupplierConsTaxRate = suplierPayWork.SupplierConsTaxRate;
                        suplierPayChildWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));            // 支払条件
                        suplierPayChildWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); // 端数処理区分
                        fractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF"));           　   // 端数処理単位
                        suplierPayChildWork.SuppCTaxLayCd = suplierPayWork.SuppCTaxLayCd;

                        // ■親子レコード未設定項目 ↓↓ ※集計レコードのみ
                        suplierPayChildWork.LastTimePayment = 0;   // 前回支払金額
                        suplierPayChildWork.ThisTimeFeePayNrml = 0;// 今回手数料金額
                        suplierPayChildWork.ThisTimeDisPayNrml = 0;// 今回値引金額
                        suplierPayChildWork.ThisTimePayNrml = 0;   // 今回支払金額
                        suplierPayChildWork.ThisTimeTtlBlcPay = 0; // 今回繰越残高
                        // ■親子レコード未設定項目 ↑↑


                        //■相殺
                        suplierPayChildWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
                        suplierPayChildWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));
                        suplierPayChildWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));
                        suplierPayChildWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF"));
                        suplierPayChildWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));

                        // 相殺後今回仕入消費税額 / 相殺後仕入外税額 >>>
                        // 修正 2009/04/17 >>>
                        #region DEL 2009/04/17
                        /*
                        // 消費税転嫁区分によってセット内容変動( クエリ内で処理しきれない為、セット時に計算 )
                        //if ((suplierPayChildWork.SuppCTaxLayCd == 0) || (suplierPayChildWork.SuppCTaxLayCd == 1) || (suplierPayChildWork.SuppCTaxLayCd == 2) || (suplierPayChildWork.SuppCTaxLayCd == 3))
                        if ((suplierPayChildWork.SuppCTaxLayCd == 0) || (suplierPayChildWork.SuppCTaxLayCd == 1))
                        {
                            // 相殺後仕入外税額 = 今回仕入外税額 + 今回仕入返品外税額 + 今回仕入値引外税額
                            setTax = 0;
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TTLSTOCKOUTERTAXRF")) + SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TTLRETOUTERTAXRF"))+
                                     SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TTLDISOUTERTAXRF")), fractionProcUnit, suplierPayChildWork.FractionProcCd, out setTax);
                            suplierPayChildWork.OffsetOutTax = setTax;       // 今回仕入外税額
                            // 相殺後今回仕入消費税額 = 相殺後仕入外税額 + 相殺後仕入内税額
                            suplierPayChildWork.OfsThisStockTax = suplierPayChildWork.OffsetOutTax + suplierPayChildWork.OffsetInTax;       // 相殺後今回仕入消費税額
                            //■■ 集計レコード計算用の処理 ■■
                            if ((suplierPayChildWork.SuppCTaxLayCd == 3))
                            {
                                // 消費税転嫁区分 = 3:請求子
                                // 子レコード集計(相殺後外税対象金額)　※子レコード集計時に算出
                                itdedOffsetOutTax += suplierPayChildWork.ItdedOffsetOutTax;
                                // 子レコード集計(相殺後外税金額)　※子レコード集計時に算出
                                OffsetOutTax += suplierPayChildWork.OffsetOutTax;
                            }
                        }
                        else if ((suplierPayChildWork.SuppCTaxLayCd == 2) || (suplierPayChildWork.SuppCTaxLayCd == 3))
                        {
                            // 消費税転嫁区分 = 2:請求親
                            // 相殺後外税金対象額　× 税率
                            setTax = 0;
                            FracCalc((suplierPayChildWork.ItdedOffsetOutTax * suplierPayChildWork.SupplierConsTaxRate), fractionProcUnit, suplierPayChildWork.FractionProcCd, out setTax);
                            suplierPayChildWork.OffsetOutTax = setTax;
                            // 相殺後今回仕入消費税額 = 相殺後仕入外税額 + 相殺後仕入内税額
                            suplierPayChildWork.OfsThisStockTax = suplierPayChildWork.OffsetOutTax + suplierPayChildWork.OffsetInTax;       // 相殺後今回仕入消費税額
                            //■■ 集計レコード計算用の処理 ■■
                            if ((suplierPayChildWork.SuppCTaxLayCd == 3))
                            {
                                // 消費税転嫁区分 = 3:請求子
                                // 子レコード集計(相殺後外税対象金額)　※子レコード集計時に算出
                                itdedOffsetOutTax += suplierPayChildWork.ItdedOffsetOutTax;
                                // 子レコード集計(相殺後外税金額)　※子レコード集計時に算出
                                OffsetOutTax += suplierPayChildWork.OffsetOutTax;
                            }
                        }
                        */
                        #endregion

                        // 相殺後仕入外税額 = 今回仕入外税額 + 今回仕入返品外税額 + 今回仕入値引外税額　(各種転嫁方式別に計算)

                        // ①支払(親) 今回仕入外税額 + 今回仕入返品外税額 + 今回仕入値引外税額 ※参考消費税
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKOUTTAX_S")) + SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_S")) +
                                 SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_S")), fractionProcUnit, suplierPayChildWork.FractionProcCd, out setTax);
                        suplierPayChildWork.OffsetOutTax = setTax;

                        // ②支払(子) 今回仕入外税額 + 今回仕入返品外税額 + 今回仕入値引外税額
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKOUTTAX_S2")) + SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_S2")) +
                                 SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_S2")), fractionProcUnit, suplierPayChildWork.FractionProcCd, out setTax);
                        suplierPayChildWork.OffsetOutTax += setTax;

                        OffsetOutTax += setTax; // 集計レコード計算用 支払(子)を保存

                        // ③伝票転嫁 今回仕入外税額 + 今回仕入返品外税額 + 今回仕入値引外税額
                        suplierPayChildWork.OffsetOutTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_D")) +
                                                           SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_D"));

                        // ④明細転嫁 今回仕入外税額 + 今回仕入返品外税額 + 今回仕入値引外税額
                        suplierPayChildWork.OffsetOutTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAX_M")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_M")) +
                                                           SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_M")); 

                        // 相殺後今回仕入消費税額 = 相殺後仕入外税額 + 相殺後仕入内税額
                        suplierPayChildWork.OfsThisStockTax = suplierPayChildWork.OffsetOutTax + suplierPayChildWork.OffsetInTax;       // 相殺後今回仕入消費税額

                        // 修正 2009/04/17 <<<

                        // ■仕入
                        // 修正 2009/04/17 >>>
                        #region DEL 2009/04/17
                        /*
                        suplierPayChildWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
                        setTax = 0;
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("THISSTCPRCTAXRF")), fractionProcUnit, suplierPayChildWork.FractionProcCd, out setTax);
                        suplierPayChildWork.ThisStcPrcTax = setTax;              // 今回仕入消費税額
                        suplierPayChildWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));
                        suplierPayChildWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));
                        suplierPayChildWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
                        // 今回仕入外税額
                        setTax = 0;
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TTLSTOCKOUTERTAXRF")), fractionProcUnit, suplierPayChildWork.FractionProcCd, out setTax);
                        suplierPayChildWork.TtlStockOuterTax = setTax;
                        suplierPayChildWork.TtlStockInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLSTOCKINNERTAXRF"));
                        */
                        #endregion
                        suplierPayChildWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
                        suplierPayChildWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));
                        suplierPayChildWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));
                        suplierPayChildWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
                        suplierPayChildWork.TtlStockInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLSTOCKINNERTAXRF"));
                        // 支払(親)　※参考消費税
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKOUTTAX_S")), fractionProcUnit, suplierPayChildWork.FractionProcCd, out setTax);
                        suplierPayChildWork.TtlStockOuterTax = setTax;
                        // 支払(子)
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKOUTTAX_S2")), fractionProcUnit, suplierPayChildWork.FractionProcCd, out setTax);
                        suplierPayChildWork.TtlStockOuterTax += setTax;
                        StockOutTax += setTax;       // 集計レコード計算用 支払(子)転嫁の仕入外税額
                        // 伝票転嫁 + 明細転嫁
                        suplierPayChildWork.TtlStockOuterTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAX_M"));
                        suplierPayChildWork.ThisStcPrcTax = suplierPayChildWork.TtlStockOuterTax + suplierPayChildWork.TtlStockInnerTax;// 今回仕入消費税額
                        // 修正 2009/04/17 <<<

                        // ■返品
                        // 修正 2009/04/17 >>>
                        #region DEL 2009/04/17
                        /*
                        suplierPayChildWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
                        setTax = 0;
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("THISSTCPRCTAXRGDSRF")), fractionProcUnit, suplierPayChildWork.FractionProcCd, out setTax);
                        suplierPayChildWork.ThisStcPrcTaxRgds = setTax;
                        suplierPayChildWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));
                        suplierPayChildWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));
                        suplierPayChildWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));
                        setTax = 0;
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TTLRETOUTERTAXRF")), fractionProcUnit, suplierPayChildWork.FractionProcCd, out setTax);
                        suplierPayChildWork.TtlRetOuterTax = setTax;
                        suplierPayChildWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));
                        */
                        #endregion
                        suplierPayChildWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
                        suplierPayChildWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));
                        suplierPayChildWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));
                        suplierPayChildWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));
                        suplierPayChildWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));
                        // 支払(親)　※参考消費税
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_S")), fractionProcUnit, suplierPayChildWork.FractionProcCd, out setTax);
                        suplierPayChildWork.TtlRetOuterTax = setTax;
                        // 支払(子)
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_S2")), fractionProcUnit, suplierPayChildWork.FractionProcCd, out setTax);
                        suplierPayChildWork.TtlRetOuterTax += setTax;
                        RetStockOutTax += setTax;       // 集計レコード計算用 支払(子)転嫁の返品外税額
                        // 伝票転嫁 + 明細転嫁
                        suplierPayChildWork.TtlRetOuterTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_M"));
                        suplierPayChildWork.ThisStcPrcTaxRgds = suplierPayChildWork.TtlRetOuterTax + suplierPayChildWork.TtlRetInnerTax;
                        // 修正 2009/04/17 <<<

                        // ■値引
                        // 修正 2009/04/17 >>>
                        #region DEL 2009/04/17
                        /*
                        suplierPayChildWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
                        setTax = 0;
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("THISSTCPRCTAXDISRF")), fractionProcUnit, suplierPayChildWork.FractionProcCd, out setTax);
                        suplierPayChildWork.ThisStcPrcTaxDis = setTax;
                        suplierPayChildWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));
                        suplierPayChildWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));
                        suplierPayChildWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));
                        setTax = 0;
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TTLDISOUTERTAXRF")), fractionProcUnit, suplierPayChildWork.FractionProcCd, out setTax);
                        suplierPayChildWork.TtlDisOuterTax = setTax;
                        suplierPayChildWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));
                        */
                        #endregion
                        suplierPayChildWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
                        suplierPayChildWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));
                        suplierPayChildWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));
                        suplierPayChildWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));
                        suplierPayChildWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));
                        // 支払(親)　※参考消費税
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_S")), fractionProcUnit, suplierPayChildWork.FractionProcCd, out setTax);
                        suplierPayChildWork.TtlDisOuterTax = setTax;
                        // 支払(子)
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_S2")), fractionProcUnit, suplierPayChildWork.FractionProcCd, out setTax);
                        suplierPayChildWork.TtlDisOuterTax += setTax;
                        DisStockOutTax += setTax;       // 集計レコード計算用 支払(子)転嫁の値引外税額
                        // 伝票転嫁 + 明細転嫁
                        suplierPayChildWork.TtlDisOuterTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_M"));
                        suplierPayChildWork.ThisStcPrcTaxDis = suplierPayChildWork.TtlDisOuterTax + suplierPayChildWork.TtlDisInnerTax;
                        // 修正 2009/04/17 <<<

                        suplierPayChildWork.TaxAdjust = 0;     // 消費税調整額(0固定)
                        suplierPayChildWork.BalanceAdjust = 0; // 残高調整額(0固定)

                        // ■親子レコード未設定項目 (集計レコードのみ) ↓↓ >>>
                        suplierPayChildWork.StockTotalPayBalance = 0; // 仕入合計残高
                        suplierPayChildWork.StockTtl2TmBfBlPay = 0;   // 仕入2回前残高
                        suplierPayChildWork.StockTtl3TmBfBlPay = 0;   // 仕入3回前残高
                        // ■親子レコード未設定項目 ↑↑ <<<

                        suplierPayChildWork.CAddUpUpdExecDate = suplierPayWork.CAddUpUpdExecDate;  // 締次更新実行年月日
                        suplierPayChildWork.StartCAddUpUpdDate = suplierPayWork.StartCAddUpUpdDate;// 締次更新開始年月日
                        suplierPayChildWork.LastCAddUpUpdDate = suplierPayWork.LastCAddUpUpdDate;  // 前回締次更新年月日
                        suplierPayChildWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNT"));　// 伝票枚数

                        // 支払予定日計算 >>>
                        // 集金月区分によってセット内容変動( クエリ内で処理しきれない為、セット時に計算 )
                        DateTime PaymentmoneyDate = suplierPayChildWork.AddUpDate;
                        switch (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONTHCODERF"))) // 0:当月,1:翌月,2:翌々月,3翌々々月
                        {
                            case 1:
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(1);
                                break;
                            case 2:
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(2);
                                break;
                            case 3:
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(3);
                                break;
                        }
                        // 28日以降は末日とする
                        if (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF")) >= 28)
                        {
                            PaymentmoneyDate = new DateTime(PaymentmoneyDate.Year, PaymentmoneyDate.Month, 1);
                            PaymentmoneyDate = PaymentmoneyDate.AddMonths(1);
                            PaymentmoneyDate = PaymentmoneyDate.AddDays(-1);
                        }
                        else
                        {
                            PaymentmoneyDate = new DateTime(PaymentmoneyDate.Year, PaymentmoneyDate.Month, SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF")));
                        }
                        suplierPayChildWork.PaymentSchedule = PaymentmoneyDate;　// 支払予定日
                        // 支払予定日計算 <<<

                        suplierPayChildWorkList.Add(suplierPayChildWork);
                        ChildCnt += 1;
                        #endregion
                    }
                    #endregion

                    #region ■■ 集計レコード計算用の処理 ■■
                    if (ChildCnt > 0)
                    {
                        // DEL 2009/04/17 >>>
                        //if ((suplierPayWork.SuppCTaxLayCd == 3)) // 消費税転嫁区分 = 3:請求子
                        //{
                        // DEL 2009/04/17 <<<

                        //相殺後外税消費税 = 子レコード集計(相殺後外税対象金額)×税率
                        //FracCalc((itdedOffsetOutTax * suplierPayWork.SupplierConsTaxRate), fractionProcUnit, suplierPayWork.FractionProcCd, out setTax);
                        //suplierPayWork.OffsetOutTax = setTax;

                        //相殺後外税消費税 = 子レコード集計(相殺後外税金額)
                        suplierPayWork.OffsetOutTax += OffsetOutTax;
                        //相殺後今回仕入消費税 = 相殺後外税消費税 + 相殺後内税消費税
                        suplierPayWork.OfsThisStockTax = suplierPayWork.OffsetOutTax + suplierPayWork.OffsetInTax;

                        // ADD 2009/04/17 >>>
                        // 今回仕入外税消費税 += 支払(子) 仕入外税消費税
                        suplierPayWork.TtlStockOuterTax += StockOutTax;
                        // 今回仕入消費税 = 今回仕入外税消費税 + 今回仕入内税消費税
                        suplierPayWork.ThisStcPrcTax = suplierPayWork.TtlStockOuterTax + suplierPayWork.TtlStockInnerTax;

                        // 今回返品外税消費税 += 支払(子) 返品外税消費税 
                        suplierPayWork.TtlRetOuterTax += RetStockOutTax;
                        // 今回返品消費税 = 今回返品外税消費税 + 今回返品内税消費税
                        suplierPayWork.ThisStcPrcTaxRgds = suplierPayWork.TtlRetOuterTax + suplierPayWork.TtlRetInnerTax;

                        // 今回値引外税消費税 += 支払(子) 値引外税消費税
                        suplierPayWork.TtlDisOuterTax += DisStockOutTax;
                        // 今回値引消費税 = 今回値引外税消費税 + 今回値引内税消費税
                        suplierPayWork.ThisStcPrcTaxDis = suplierPayWork.TtlDisOuterTax + suplierPayWork.TtlDisInnerTax;
                        // ADD 2009/04/17 <<<

                        // 仕入合計残高(支払計) = 今回繰越金額(支払計) + (相殺後今回仕入金額 + 相殺後今回仕入消費税)
                        suplierPayWork.StockTotalPayBalance = suplierPayWork.ThisTimeTtlBlcPay + (suplierPayWork.OfsThisTimeStock + suplierPayWork.OfsThisStockTax);

                        //}  // DEL 2009/04/17 
                    }
                    #endregion

                    #region ■■ 実績無しの場合の処理 ■■
                    // 実績無しの場合でも、親レコードは作成する。
                    if (ChildCnt == 0)
                    {
                        // ■親・子レコード( 不足項目セット )
                        SuplierPayWork suplierPayChildWork = new SuplierPayWork();
                        suplierPayChildWork = suplierPayWork;
                        // 実績拠点コードセット
                        suplierPayChildWork.ResultsSectCd = suplierPayChildWork.AddUpSecCode; 
                        suplierPayChildWorkList.Add(suplierPayChildWork);

                        // ■集計レコード( 不足項目セット )
                        // 今回繰越残高
                        suplierPayWork.ThisTimeTtlBlcPay = (suplierPayWork.LastTimePayment + suplierPayWork.StockTtl2TmBfBlPay + suplierPayWork.StockTtl3TmBfBlPay) - suplierPayWork.ThisTimePayNrml;
                        // 仕入合計残高
                        suplierPayWork.StockTotalPayBalance = suplierPayWork.ThisTimeTtlBlcPay + (suplierPayWork.OfsThisTimeStock + suplierPayWork.OfsThisStockTax);
                    }
                    #endregion
                }            
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }

        // --- ADD 2012/09/11 ----------->>>>>
        /// <summary>
        /// 仕入先支払金額ワーク用Listか仕入総括形式で仕入データを取得します
        /// </summary>
        /// <param name="suplierPayWork">仕入先支払金額ワーク</param>
        /// <param name="suplierPayChildWorkList">仕入先支払金額マスタ(子レコード用)List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額ワーク用Listから仕入総括形式で仕入データを取得します</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : 2012/09/11</br>
        /// </remarks>
        private int GetStockSlipByAddUpSecCode(ref SuplierPayWork suplierPayWork, ref ArrayList suplierPayChildWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            string sqlText = string.Empty;

            SqlCommand sqlCommRef = null;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    if (suplierPayWork.SupplierCd == suplierPayWork.PayeeCode) // ←念のため
                    {
                        #region [●集計レコード作成処理]

                        sqlCommRef = sqlCommand;
                        status = MakeGetStockSlipSqlByAddUpSecCode(ref suplierPayWork, ref sqlCommRef);

                        if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != status)
                        {
                            return status;
                        }

                        myReader = sqlCommand.ExecuteReader();

                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND; 
                        double FractionProcUnit = 0;
                        long SetTax = 0;
                        while (myReader.Read())
                        {
                            #region 結果セット
                            suplierPayWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); //端数処理区分
                            FractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF"));           // 端数処理単位
                            suplierPayWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                            suplierPayWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                            suplierPayWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                            suplierPayWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                            suplierPayWork.ResultsSectCd = "00";　// 実績拠点コード(00固定)
                            suplierPayWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));      // 支払条件
                            suplierPayWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));// 端数処理区分

                            // 今回繰越残高(前回支払額-今回支払金額)
                            suplierPayWork.ThisTimeTtlBlcPay = (suplierPayWork.LastTimePayment + suplierPayWork.StockTtl2TmBfBlPay + suplierPayWork.StockTtl3TmBfBlPay) - suplierPayWork.ThisTimePayNrml;

                            //■相殺
                            suplierPayWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
                            suplierPayWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));
                            suplierPayWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));
                            suplierPayWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF"));
                            suplierPayWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));

                            // 相殺後今回仕入消費税額 / 相殺後仕入外税額 >>>
                            // 消費税転嫁区分によってセット内容変動

                            // 相殺後仕入外税額 = 今回仕入外税額 + 今回仕入返品外税額 + 今回仕入値引外税額 ※各種転嫁方式別に計算を行う

                            // ①支払(親)　今回仕入外税 + 今回返品外税 + 今回値引外税
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKOUTTAX_S")) + SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_S")) +
                                     SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_S")), FractionProcUnit, suplierPayWork.FractionProcCd, out SetTax);
                            suplierPayWork.OffsetOutTax = SetTax;

                            // ②支払(子) = 今回仕入外税 + 今回返品外税 + 今回値引外税
                            FracCalc(
                                    SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKOUTTAX_S2")) 
                                  + SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_S2")) 
                                  + SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_S2"))
                                , FractionProcUnit
                                , suplierPayWork.FractionProcCd
                                , out SetTax);
                            suplierPayWork.OffsetOutTax += SetTax;

                            // ③伝票転嫁 今回仕入外税 + 今回返品外税 + 今回値引外税
                            suplierPayWork.OffsetOutTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_D")) +
                                                           SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_D"));

                            // ④明細転嫁 今回仕入外税 + 今回返品外税 + 今回値引外税
                            suplierPayWork.OffsetOutTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAX_M")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_M")) +
                                                           SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_M"));

                            // 相殺後今回仕入消費税額 = 相殺後仕入外税額 + 相殺後仕入内税額
                            suplierPayWork.OfsThisStockTax = suplierPayWork.OffsetOutTax + suplierPayWork.OffsetInTax;       // 相殺後今回仕入消費税額

                            // ■仕入
                            suplierPayWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
                            suplierPayWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));
                            suplierPayWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));
                            suplierPayWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
                            suplierPayWork.TtlStockInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLSTOCKINNERTAXRF"));
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKOUTTAX_S")), FractionProcUnit, suplierPayWork.FractionProcCd, out SetTax);
                            SetTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAX_M"));
                            suplierPayWork.TtlStockOuterTax = SetTax;
                            FracCalc(
                                  SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKOUTTAX_S2"))
                                , FractionProcUnit
                                , suplierPayWork.FractionProcCd
                                , out SetTax);
                            suplierPayWork.TtlStockOuterTax += SetTax;
                            suplierPayWork.ThisStcPrcTax = suplierPayWork.TtlStockOuterTax + suplierPayWork.TtlStockInnerTax; // 今回仕入消費税額

                            // ■返品
                            suplierPayWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
                            suplierPayWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));
                            suplierPayWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));
                            suplierPayWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));
                            suplierPayWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_S")), FractionProcUnit, suplierPayWork.FractionProcCd, out SetTax);
                            SetTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_M"));
                            suplierPayWork.TtlRetOuterTax = SetTax;
                            FracCalc(
                                  SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSTOCKOUTTAX_S2"))
                                , FractionProcUnit
                                , suplierPayWork.FractionProcCd
                                , out SetTax);
                            suplierPayWork.TtlRetOuterTax += SetTax;
                            suplierPayWork.ThisStcPrcTaxRgds = suplierPayWork.TtlRetOuterTax + suplierPayWork.TtlRetInnerTax;

                            // ■値引
                            suplierPayWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
                            suplierPayWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));
                            suplierPayWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));
                            suplierPayWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));
                            suplierPayWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_S")), FractionProcUnit, suplierPayWork.FractionProcCd, out SetTax);
                            SetTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_M"));
                            suplierPayWork.TtlDisOuterTax = SetTax;
                            FracCalc(
                                  SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSTOCKOUTTAX_S2"))
                                , FractionProcUnit
                                , suplierPayWork.FractionProcCd
                                , out SetTax);
                            suplierPayWork.TtlDisOuterTax += SetTax;
                            suplierPayWork.ThisStcPrcTaxDis = suplierPayWork.TtlDisOuterTax + suplierPayWork.TtlDisInnerTax;

                            suplierPayWork.TaxAdjust = 0;     // 消費税調整額(0固定)
                            suplierPayWork.BalanceAdjust = 0; // 残高調整額(0固定)
                            suplierPayWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNT"));　// 伝票枚数

                            // 仕入合計残高(支払計) >>>
                            // 仕入合計残高(支払計) = 今回繰越金額(支払計) + (相殺後今回仕入金額 + 相殺後今回仕入消費税)
                            suplierPayWork.StockTotalPayBalance = suplierPayWork.ThisTimeTtlBlcPay + (suplierPayWork.OfsThisTimeStock + suplierPayWork.OfsThisStockTax);
                            // 仕入合計残高(支払計) <<<

                            // 支払予定日計算 >>>
                            // 集金月区分によってセット内容変動( クエリ内で処理しきれない為、セット時に計算 )
                            DateTime PaymentmoneyDate = suplierPayWork.AddUpDate;
                            switch (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONTHCODERF"))) // 0:当月,1:翌月,2:翌々月,3翌々々月
                            {
                                case 1:
                                    PaymentmoneyDate = PaymentmoneyDate.AddMonths(1);
                                    break;
                                case 2:
                                    PaymentmoneyDate = PaymentmoneyDate.AddMonths(2);
                                    break;
                                case 3:
                                    PaymentmoneyDate = PaymentmoneyDate.AddMonths(3);
                                    break;
                            }
                            // 28日以降は末日とする
                            if (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF")) >= 28)
                            {
                                PaymentmoneyDate = new DateTime(PaymentmoneyDate.Year, PaymentmoneyDate.Month, 1);
                                PaymentmoneyDate = PaymentmoneyDate.AddMonths(1);
                                PaymentmoneyDate = PaymentmoneyDate.AddDays(-1);
                            }
                            else
                            {
                                PaymentmoneyDate = new DateTime(PaymentmoneyDate.Year, PaymentmoneyDate.Month, SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF")));
                            }
                            suplierPayWork.PaymentSchedule = PaymentmoneyDate;　// 支払予定日
                            // 支払予定日計算 <<<
                            #endregion

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        #endregion
                    }

                    if ((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND == status)
                    {
                        // 集計レコード不足項目セット
                        // 今回繰越残高
                        suplierPayWork.ThisTimeTtlBlcPay = (suplierPayWork.LastTimePayment + suplierPayWork.StockTtl2TmBfBlPay + suplierPayWork.StockTtl3TmBfBlPay) - suplierPayWork.ThisTimePayNrml;
                        // 仕入合計残高
                        suplierPayWork.StockTotalPayBalance = suplierPayWork.ThisTimeTtlBlcPay + (suplierPayWork.OfsThisTimeStock + suplierPayWork.OfsThisStockTax);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }

        /// <summary>
        /// 支払先別仕入データ取得SQLを設定します
        /// </summary>
        /// <param name="suplierPayWork">仕入先支払金額ワーク</param>
        /// <param name="sqlCommand">sqlステートメント</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払先別仕入データ取得SQLを設定します</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : 2012/09/11</br>
        /// </remarks>
        private int MakeGetStockSlipSql(ref SuplierPayWork suplierPayWork, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string sqlText = string.Empty;

            #region SELECT文作成
            sqlText += "SELECT" + Environment.NewLine;
            sqlText += " SUPLIERPAY.PAYEECODERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.SUPPLIERNM1RF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.SUPPLIERNM2RF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.SUPPLIERSNMRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.FRACTIONPROCUNITRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.FRACTIONPROCCDRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.PAYMENTMONTHCODERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.PAYMENTDAYRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.PAYMENTCONDRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKSLIPCOUNT," + Environment.NewLine;
            sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF + SUPLIERPAY.THISSTCKPRICRGDSRF + SUPLIERPAY.THISSTCKPRICDISRF AS OFSTHISTIMESTOCKRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCOUTTAXRF + SUPLIERPAY.TTLITDEDRETOUTTAXRF+SUPLIERPAY.TTLITDEDDISOUTTAXRF AS ITDEDOFFSETOUTTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCINTAXRF + SUPLIERPAY.TTLITDEDRETINTAXRF+SUPLIERPAY.TTLITDEDDISINTAXRF AS ITDEDOFFSETINTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCTAXFREERF + SUPLIERPAY.TTLITDEDRETTAXFREERF+SUPLIERPAY.TTLITDEDDISTAXFREERF AS ITDEDOFFSETTAXFREERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.STCKPRCCONSTAXINCLURF+SUPLIERPAY.TTLRETINNERTAXRF+SUPLIERPAY.STCKDISTTLTAXINCLURF AS OFFSETINTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF AS THISTIMESTOCKPRICERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCOUTTAXRF AS TTLITDEDSTCOUTTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCINTAXRF AS TTLITDEDSTCINTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCTAXFREERF AS TTLITDEDSTCTAXFREERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKOUTTAXRF AS STOCKOUTTAX_D, -- 仕入消費税_伝票転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.DTLSTOCKOUTTAXRF AS STOCKOUTTAX_M, -- 仕入消費税_明細転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKOUTTAXRF1 +SUPLIERPAY.STOCKOUTTAXRF2 +SUPLIERPAY.STOCKOUTTAXRF3 AS STOCKOUTTAX_S, -- 仕入消費税_支払親転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.STCKPRCCONSTAXINCLURF AS TTLSTOCKINNERTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.THISSTCKPRICRGDSRF AS THISSTCKPRICRGDSRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDRETOUTTAXRF AS TTLITDEDRETOUTTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDRETINTAXRF AS TTLITDEDRETINTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDRETTAXFREERF AS TTLITDEDRETTAXFREERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLRETOUTERTAXRF AS RETSTOCKOUTTAX_D,   -- 返品消費税＿伝票転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.DTLTTLRETOUTERTAXRF AS RETSTOCKOUTTAX_M,-- 返品消費税＿明細転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLRETOUTERTAXRF1 +SUPLIERPAY.TTLRETOUTERTAXRF2 +SUPLIERPAY.TTLRETOUTERTAXRF3 AS RETSTOCKOUTTAX_S, --返品消費税＿支払親転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLRETINNERTAXRF AS TTLRETINNERTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.THISSTCKPRICDISRF AS THISSTCKPRICDISRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDDISOUTTAXRF AS TTLITDEDDISOUTTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDDISINTAXRF AS TTLITDEDDISINTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDDISTAXFREERF AS TTLITDEDDISTAXFREERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKDISOUTTAXRF AS DISSTOCKOUTTAX_D,    -- 値引消費税＿伝票転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.DTLSTOCKDISOUTTAXRF AS DISSTOCKOUTTAX_M, -- 値引消費税＿明細転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKDISOUTTAXRF1 +SUPLIERPAY.STOCKDISOUTTAXRF2 +SUPLIERPAY.STOCKDISOUTTAXRF3 AS DISSTOCKOUTTAX_S, --値引消費税＿支払親転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.STCKDISTTLTAXINCLURF AS TTLDISINNERTAXRF" + Environment.NewLine;
            sqlText += " FROM" + Environment.NewLine;
            sqlText += "(" + Environment.NewLine;

            #region [SUBクエリ]
            sqlText += " SELECT" + Environment.NewLine;
            sqlText += "  STOCK.PAYEECODERF," + Environment.NewLine;
            sqlText += "  SUPPLIER.SUPPLIERNM1RF," + Environment.NewLine;
            sqlText += "  SUPPLIER.SUPPLIERNM2RF," + Environment.NewLine;
            sqlText += "  SUPPLIER.SUPPLIERSNMRF," + Environment.NewLine;
            sqlText += "  SUPPLIER.STOCKCNSTAXFRCPROCCDRF," + Environment.NewLine;
            sqlText += "  SUPPLIER.PAYMENTMONTHCODERF," + Environment.NewLine;
            sqlText += "  SUPPLIER.PAYMENTDAYRF," + Environment.NewLine;
            sqlText += "  SUPPLIER.PAYMENTCONDRF," + Environment.NewLine;
            sqlText += "  PROCMONEY.FRACTIONPROCUNITRF," + Environment.NewLine;
            sqlText += "  PROCMONEY.FRACTIONPROCCDRF," + Environment.NewLine;
            sqlText += "  COUNT(STOCK.SUPPLIERSLIPNORF) STOCKSLIPCOUNT, --伝票枚数" + Environment.NewLine;
            sqlText += "  -- ■ ■ 仕入 ■ ■" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STOCKNETPRICERF ELSE 0 END)) AS THISTIMESTOCKPRICERF,       --仕入正価金額" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCOUTTAXRF ELSE 0 END)) AS TTLITDEDSTCOUTTAXRF,    --仕入外税対象額合計" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCINTAXRF ELSE 0 END)) AS TTLITDEDSTCINTAXRF,      --仕入内税対象額合計" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCTAXFREERF ELSE 0 END)) AS TTLITDEDSTCTAXFREERF,  --仕入非課税対象額合計" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 0) AND (STOCK.SUPPLIERSLIPCDRF =10) THEN STOCK.STOCKOUTTAXRF ELSE 0 END)) AS STOCKOUTTAXRF,      --消費税額（外税）伝票" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 1) AND (STOCK.SUPPLIERSLIPCDRF =10) THEN STOCK.DTLSTOCKOUTTAXRF ELSE 0 END)) AS DTLSTOCKOUTTAXRF,--消費税額（外税）明細" + Environment.NewLine;
            sqlText += "  -- 支払(親)転嫁" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF)" + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS STOCKOUTTAXRF1,                     --消費税額（外税）税率1" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF)" + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS STOCKOUTTAXRF2,                          --消費税額（外税）税率2" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF)" + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS STOCKOUTTAXRF3,                          --消費税額（外税）税率3" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STCKPRCCONSTAXINCLURF ELSE 0 END)) AS STCKPRCCONSTAXINCLURF,--消費税額（内税）" + Environment.NewLine;
            sqlText += "  -- ■ ■ 返品 ■ ■" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STOCKNETPRICERF ELSE 0 END)) AS THISSTCKPRICRGDSRF,       --仕入正価金額" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCOUTTAXRF ELSE 0 END)) AS TTLITDEDRETOUTTAXRF,  --仕入外税対象額合計" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCINTAXRF ELSE 0 END)) AS TTLITDEDRETINTAXRF,    --仕入内税対象額合計" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCTAXFREERF ELSE 0 END)) AS TTLITDEDRETTAXFREERF,--仕入非課税対象額合計" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 0) AND (STOCK.SUPPLIERSLIPCDRF =20) THEN STOCK.STOCKOUTTAXRF ELSE 0 END)) AS TTLRETOUTERTAXRF,      --消費税額（外税）伝票" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 1) AND (STOCK.SUPPLIERSLIPCDRF =20) THEN STOCK.DTLSTOCKOUTTAXRF ELSE 0 END)) AS DTLTTLRETOUTERTAXRF,--消費税額（外税）明細" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF)" + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS TTLRETOUTERTAXRF1,                --消費税額（外税）税率1" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF)" + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS TTLRETOUTERTAXRF2,                     --消費税額（外税）税率2" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF)" + Environment.NewLine;
            sqlText += "           THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS TTLRETOUTERTAXRF3,                      --消費税額（外税）税率3" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STCKPRCCONSTAXINCLURF ELSE 0 END)) AS TTLRETINNERTAXRF,   --消費税額（内税）" + Environment.NewLine;
            sqlText += "  -- ■ ■ 値引 ■ ■" + Environment.NewLine;
            sqlText += "  SUM(STOCK.STCKDISTTLTAXEXCRF) AS THISSTCKPRICDISRF,       --値引金額計（税抜き）" + Environment.NewLine;
            sqlText += "  SUM(STOCK.ITDEDSTOCKDISOUTTAXRF) AS TTLITDEDDISOUTTAXRF,  --値引外税対象額合計" + Environment.NewLine;
            sqlText += "  SUM(STOCK.ITDEDSTOCKDISINTAXRF) AS TTLITDEDDISINTAXRF,    --値引内税対象額合計" + Environment.NewLine;
            sqlText += "  SUM(STOCK.ITDEDSTOCKDISTAXFRERF) AS TTLITDEDDISTAXFREERF, --値引非課税対象額合計" + Environment.NewLine;
            sqlText += "  SUM(CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 0) THEN STOCK.STOCKDISOUTTAXRF ELSE 0 END) AS STOCKDISOUTTAXRF,   --値引消費税額（外税）伝票" + Environment.NewLine;
            sqlText += "  SUM(CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 1) THEN STOCK.STOCKDISOUTTAXRF ELSE 0 END) AS DTLSTOCKDISOUTTAXRF,--値引消費税額（外税）明細" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF)" + Environment.NewLine;
            sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATERF)ELSE 0 END)) AS STOCKDISOUTTAXRF1,  --値引消費税額（外税）税率1" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF)" + Environment.NewLine;
            sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE2RF)ELSE 0 END)) AS STOCKDISOUTTAXRF2, --値引消費税額（外税）税率2" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF)" + Environment.NewLine;
            sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE3RF)ELSE 0 END)) AS STOCKDISOUTTAXRF3, --値引消費税額（外税）税率3" + Environment.NewLine;
            sqlText += "  SUM(STOCK.STCKDISTTLTAXINCLURF) AS STCKDISTTLTAXINCLURF    --値引消費税額（内税）" + Environment.NewLine;
            sqlText += "  FROM" + Environment.NewLine;
            sqlText += "  (" + Environment.NewLine;

            #region SUBSUBクエリ
            sqlText += "   SELECT" + Environment.NewLine;
            sqlText += "    SUBSTOCK.LOGICALDELETECODERF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.SUPPCTAXLAYCDRF,  --消費税転嫁方式" + Environment.NewLine;
            sqlText += "    SUBSTOCK.SUPPLIERFORMALRF, --仕入形式" + Environment.NewLine;
            sqlText += "    SUBSTOCK.DEBITNOTEDIVRF,   --赤伝区分" + Environment.NewLine;
            sqlText += "    SUBSTOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
            sqlText += "    SUBSTOCK.STOCKGOODSCDRF,   --仕入商品区分" + Environment.NewLine;
            sqlText += "    SUBSTOCK.SUPPLIERSLIPNORF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.STOCKADDUPADATERF," + Environment.NewLine;
            sqlText += "    (CASE WHEN (SEARCHSUPPLIER.PAYEECODERF IS NOT NULL) THEN SEARCHSUPPLIER.PAYEECODERF ELSE SUBSTOCK.PAYEECODERF END) AS PAYEECODERF," + Environment.NewLine;

            //仕入・返品(行値引含む)
            sqlText += "    SUBSTOCK.STOCKNETPRICERF + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STOCKNETPRICERF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.TTLITDEDSTCOUTTAXRF + SUBSTOCKDTL.ITDEDSTOCKDISOUTTAXGYO AS TTLITDEDSTCOUTTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.TTLITDEDSTCINTAXRF + SUBSTOCKDTL.ITDEDSTOCKDISINTAXGYO AS TTLITDEDSTCINTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.TTLITDEDSTCTAXFREERF + SUBSTOCKDTL.ITDEDSTOCKDISFREETAXGYO AS TTLITDEDSTCTAXFREERF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.STOCKOUTTAXRF + SUBSTOCKDTL.STOCKDISOUTTAXGYO AS STOCKOUTTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.STCKPRCCONSTAXINCLURF + SUBSTOCKDTL.STOCKDISINTAXGYO AS STCKPRCCONSTAXINCLURF," + Environment.NewLine;
            //値引(行値引除く)
            sqlText += "    SUBSTOCK.STCKDISTTLTAXEXCRF - SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STCKDISTTLTAXEXCRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.ITDEDSTOCKDISOUTTAXRF - SUBSTOCKDTL.ITDEDSTOCKDISOUTTAXGYO AS ITDEDSTOCKDISOUTTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.ITDEDSTOCKDISINTAXRF - SUBSTOCKDTL.ITDEDSTOCKDISINTAXGYO AS ITDEDSTOCKDISINTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.ITDEDSTOCKDISTAXFRERF - SUBSTOCKDTL.ITDEDSTOCKDISFREETAXGYO AS ITDEDSTOCKDISTAXFRERF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.STOCKDISOUTTAXRF - SUBSTOCKDTL.STOCKDISOUTTAXGYO AS STOCKDISOUTTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.STCKDISTTLTAXINCLURF - SUBSTOCKDTL.STOCKDISINTAXGYO AS STCKDISTTLTAXINCLURF," + Environment.NewLine;

            sqlText += "    SUBSTOCKDTL.DTLSTOCKOUTTAXRF + SUBSTOCKDTL.STOCKDISOUTTAXGYO AS DTLSTOCKOUTTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCKDTL.DTLSTCKPRCCONSTAXINCLURF + SUBSTOCKDTL.STOCKDISINTAXGYO AS DTLSTCKPRCCONSTAXINCLURF," + Environment.NewLine;


            // 税率取得
            sqlText += "    TAX.TAXRATESTARTDATERF AS TAXRATESTARTDATERF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATEENDDATERF AS TAXRATEENDDATERF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATERF AS TAXRATERF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATE2RF AS TAXRATE2RF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATE3RF AS TAXRATE3RF,    " + Environment.NewLine;
            sqlText += "    TAX.CONSTAXLAYMETHODRF AS TAXCONSTAXLAYMETHODRF" + Environment.NewLine;
            sqlText += "   FROM" + Environment.NewLine;
            sqlText += "    STOCKSLIPRF AS SUBSTOCK" + Environment.NewLine;

            #region [ SUBSUBクエリJOIN ]
            sqlText += "    LEFT JOIN TAXRATESETRF AS TAX" + Environment.NewLine;
            sqlText += "     ON SUBSTOCK.ENTERPRISECODERF = TAX.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    LEFT JOIN SUPPLIERRF AS SEARCHSUPPLIER" + Environment.NewLine;
            sqlText += "     ON SUBSTOCK.ENTERPRISECODERF = SEARCHSUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "     AND SUBSTOCK.SUPPLIERCDRF = SEARCHSUPPLIER.SUPPLIERCDRF" + Environment.NewLine;
            sqlText += "    LEFT JOIN" + Environment.NewLine;
            sqlText += "    ( " + Environment.NewLine;
            sqlText += "      SELECT" + Environment.NewLine;
            sqlText += "       STOCK.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERSLIPNORF, --仕入伝票番号 " + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF != 2 AND DTL.TAXATIONCODERF = 0) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTOCKOUTTAXRF," + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF != 2 AND DTL.TAXATIONCODERF = 2) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTCKPRCCONSTAXINCLURF," + Environment.NewLine;
            sqlText += "       -- 行値引" + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS DISSTOCKPRICETAXEXCGYO," + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISOUTTAXGYO, -- 外税対象額(行値引)" + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 1 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISFREETAXGYO,-- 非課税対象額(行値引)" + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 2 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISINTAXGYO,  -- 内税対象額(行値引)" + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 0 ) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS STOCKDISOUTTAXGYO, -- 外税額(行値引)" + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 2 ) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS STOCKDISINTAXGYO  -- 内税額(行値引)" + Environment.NewLine;
            sqlText += "      FROM" + Environment.NewLine;
            sqlText += "       STOCKDETAILRF AS DTL" + Environment.NewLine;
            sqlText += "      LEFT JOIN STOCKSLIPRF AS STOCK" + Environment.NewLine;
            sqlText += "       ON DTL.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "       AND DTL.SUPPLIERFORMALRF = STOCK.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "       AND DTL.SUPPLIERSLIPNORF = STOCK.SUPPLIERSLIPNORF" + Environment.NewLine;
            sqlText += "      GROUP BY" + Environment.NewLine;
            sqlText += "       STOCK.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERSLIPNORF --仕入伝票番号 " + Environment.NewLine;
            sqlText += "    ) AS SUBSTOCKDTL" + Environment.NewLine;
            sqlText += "    ON  SUBSTOCK.ENTERPRISECODERF = SUBSTOCKDTL.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SUBSTOCK.SUPPLIERFORMALRF = SUBSTOCKDTL.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "    AND SUBSTOCK.SUPPLIERSLIPNORF = SUBSTOCKDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
            #endregion

            #endregion

            #region [ WHERE ]
            sqlText += "   WHERE SUBSTOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "    AND  (CASE WHEN (SEARCHSUPPLIER.PAYEECODERF IS NOT NULL) THEN SEARCHSUPPLIER.PAYEECODERF ELSE SUBSTOCK.PAYEECODERF END)=@FINDCUSTOMERCODE" + Environment.NewLine;
            sqlText += "    AND (SUBSTOCK.STOCKADDUPADATERF<=@FINDADDUPDATE AND SUBSTOCK.STOCKADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
            sqlText += "    AND  SUBSTOCK.LOGICALDELETECODERF=0" + Environment.NewLine;
            sqlText += "    AND  SUBSTOCK.SUPPLIERFORMALRF=0" + Environment.NewLine;
            sqlText += "    AND  SUBSTOCK.DEBITNOTEDIVRF=0" + Environment.NewLine;
            sqlText += "    AND (SUBSTOCK.SUPPLIERSLIPCDRF = 10 OR SUBSTOCK.SUPPLIERSLIPCDRF = 20)" + Environment.NewLine;
            sqlText += "    AND (SUBSTOCK.STOCKGOODSCDRF=0 OR SUBSTOCK.STOCKGOODSCDRF = 6)" + Environment.NewLine;
            #endregion

            #region [ JOIN ]
            sqlText += "   ) AS STOCK" + Environment.NewLine;
            sqlText += "   INNER JOIN SUPPLIERRF AS SUPPLIER" + Environment.NewLine;
            sqlText += "    ON SUPPLIER.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SUPPLIER.SUPPLIERCDRF = STOCK.PAYEECODERF" + Environment.NewLine;
            sqlText += "   LEFT JOIN STOCKPROCMONEYRF AS PROCMONEY" + Environment.NewLine;
            sqlText += "    ON PROCMONEY.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND PROCMONEY.FRACPROCMONEYDIVRF = 1" + Environment.NewLine;
            sqlText += "    AND PROCMONEY.FRACTIONPROCCODERF = SUPPLIER.STOCKCNSTAXFRCPROCCDRF" + Environment.NewLine;

            #endregion

            #region [ GROUP BY ]
            sqlText += "   GROUP BY" + Environment.NewLine;
            sqlText += "    STOCK.PAYEECODERF," + Environment.NewLine;
            sqlText += "    SUPPLIER.SUPPLIERNM1RF," + Environment.NewLine;
            sqlText += "    SUPPLIER.SUPPLIERNM2RF," + Environment.NewLine;
            sqlText += "    SUPPLIER.SUPPLIERSNMRF,   " + Environment.NewLine;
            sqlText += "    SUPPLIER.STOCKCNSTAXFRCPROCCDRF," + Environment.NewLine;
            sqlText += "    SUPPLIER.PAYMENTMONTHCODERF," + Environment.NewLine;
            sqlText += "    SUPPLIER.PAYMENTDAYRF," + Environment.NewLine;
            sqlText += "    SUPPLIER.PAYMENTCONDRF," + Environment.NewLine;
            sqlText += "    SUPPLIER.SUPPCTAXLAYREFCDRF," + Environment.NewLine;
            sqlText += "    STOCK.TAXCONSTAXLAYMETHODRF," + Environment.NewLine;
            sqlText += "    PROCMONEY.FRACTIONPROCUNITRF," + Environment.NewLine;
            sqlText += "    PROCMONEY.FRACTIONPROCCDRF " + Environment.NewLine;
            sqlText += ") AS SUPLIERPAY" + Environment.NewLine;
            #endregion

            #endregion
            #endregion

            sqlCommand.CommandText = sqlText;

            #region  Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
            SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
            SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
            #endregion

            #region Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SupplierCd);
            findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);
            if (suplierPayWork.LastCAddUpUpdDate == DateTime.MinValue)
                findParaLastTimeAddUpDate.Value = 20000101;
            else
                findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.LastCAddUpUpdDate);
            #endregion

            return status;
        }

        /// <summary>
        /// 仕入計上拠点別仕入データ取得SQLを設定します
        /// </summary>
        /// <param name="suplierPayWork">仕入先支払金額ワーク</param>
        /// <param name="sqlCommand">sqlステートメント</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入計上拠点別仕入データ取得SQLを設定します</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : 2012/09/11</br>
        /// </remarks>
        private int MakeGetStockSlipSqlByAddUpSecCode(ref SuplierPayWork suplierPayWork, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string sqlText = string.Empty;

            #region SELECT文作成
            sqlText += "SELECT" + Environment.NewLine;
            sqlText += " SUPLIERPAY.PAYEECODERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKSECTIONCDRF AS ADDUPSECCODERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.SUPPLIERNM1RF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.SUPPLIERNM2RF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.SUPPLIERSNMRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.FRACTIONPROCUNITRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.FRACTIONPROCCDRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.PAYMENTMONTHCODERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.PAYMENTDAYRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.PAYMENTCONDRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKSLIPCOUNT," + Environment.NewLine;
            sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF + SUPLIERPAY.THISSTCKPRICRGDSRF + SUPLIERPAY.THISSTCKPRICDISRF AS OFSTHISTIMESTOCKRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCOUTTAXRF + SUPLIERPAY.TTLITDEDRETOUTTAXRF+SUPLIERPAY.TTLITDEDDISOUTTAXRF AS ITDEDOFFSETOUTTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCINTAXRF + SUPLIERPAY.TTLITDEDRETINTAXRF+SUPLIERPAY.TTLITDEDDISINTAXRF AS ITDEDOFFSETINTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCTAXFREERF + SUPLIERPAY.TTLITDEDRETTAXFREERF+SUPLIERPAY.TTLITDEDDISTAXFREERF AS ITDEDOFFSETTAXFREERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.STCKPRCCONSTAXINCLURF+SUPLIERPAY.TTLRETINNERTAXRF+SUPLIERPAY.STCKDISTTLTAXINCLURF AS OFFSETINTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF AS THISTIMESTOCKPRICERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCOUTTAXRF AS TTLITDEDSTCOUTTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCINTAXRF AS TTLITDEDSTCINTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCTAXFREERF AS TTLITDEDSTCTAXFREERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKOUTTAXRF AS STOCKOUTTAX_D, -- 仕入消費税_伝票転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.DTLSTOCKOUTTAXRF AS STOCKOUTTAX_M, -- 仕入消費税_明細転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKOUTTAXRF1 +SUPLIERPAY.STOCKOUTTAXRF2 +SUPLIERPAY.STOCKOUTTAXRF3 AS STOCKOUTTAX_S, -- 仕入消費税_支払親転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKOUTTAXRF1_2 +SUPLIERPAY.STOCKOUTTAXRF2_2 +SUPLIERPAY.STOCKOUTTAXRF3_2 AS STOCKOUTTAX_S2, --支払子" + Environment.NewLine;
            sqlText += " SUPLIERPAY.STCKPRCCONSTAXINCLURF AS TTLSTOCKINNERTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.THISSTCKPRICRGDSRF AS THISSTCKPRICRGDSRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDRETOUTTAXRF AS TTLITDEDRETOUTTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDRETINTAXRF AS TTLITDEDRETINTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDRETTAXFREERF AS TTLITDEDRETTAXFREERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLRETOUTERTAXRF AS RETSTOCKOUTTAX_D,   -- 返品消費税＿伝票転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.DTLTTLRETOUTERTAXRF AS RETSTOCKOUTTAX_M,-- 返品消費税＿明細転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLRETOUTERTAXRF1 +SUPLIERPAY.TTLRETOUTERTAXRF2 +SUPLIERPAY.TTLRETOUTERTAXRF3 AS RETSTOCKOUTTAX_S, --返品消費税＿支払親転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLRETOUTERTAXRF1_2 +SUPLIERPAY.TTLRETOUTERTAXRF2_2 +SUPLIERPAY.TTLRETOUTERTAXRF3_2 AS RETSTOCKOUTTAX_S2,-- 支払子転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLRETINNERTAXRF AS TTLRETINNERTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.THISSTCKPRICDISRF AS THISSTCKPRICDISRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDDISOUTTAXRF AS TTLITDEDDISOUTTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDDISINTAXRF AS TTLITDEDDISINTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDDISTAXFREERF AS TTLITDEDDISTAXFREERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKDISOUTTAXRF AS DISSTOCKOUTTAX_D,    -- 値引消費税＿伝票転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.DTLSTOCKDISOUTTAXRF AS DISSTOCKOUTTAX_M, -- 値引消費税＿明細転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKDISOUTTAXRF1 +SUPLIERPAY.STOCKDISOUTTAXRF2 +SUPLIERPAY.STOCKDISOUTTAXRF3 AS DISSTOCKOUTTAX_S, --値引消費税＿支払親転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKDISOUTTAXRF1_2 +SUPLIERPAY.STOCKDISOUTTAXRF2_2 +SUPLIERPAY.STOCKDISOUTTAXRF3_2 AS DISSTOCKOUTTAX_S2,-- 支払子転嫁 " + Environment.NewLine;
            sqlText += " SUPLIERPAY.STCKDISTTLTAXINCLURF AS TTLDISINNERTAXRF" + Environment.NewLine;
            sqlText += " FROM" + Environment.NewLine;
            sqlText += "(" + Environment.NewLine;

            #region [SUBクエリ]
            sqlText += " SELECT" + Environment.NewLine;
            sqlText += "  STOCK.STOCKSECTIONCDRF," + Environment.NewLine;
            sqlText += "  STOCK.PAYEECODERF," + Environment.NewLine;
            sqlText += "  SUPPLIER.SUPPLIERNM1RF," + Environment.NewLine;
            sqlText += "  SUPPLIER.SUPPLIERNM2RF," + Environment.NewLine;
            sqlText += "  SUPPLIER.SUPPLIERSNMRF," + Environment.NewLine;
            sqlText += "  SUPPLIER.STOCKCNSTAXFRCPROCCDRF," + Environment.NewLine;
            sqlText += "  SUPPLIER.PAYMENTMONTHCODERF," + Environment.NewLine;
            sqlText += "  SUPPLIER.PAYMENTDAYRF," + Environment.NewLine;
            sqlText += "  SUPPLIER.PAYMENTCONDRF," + Environment.NewLine;
            sqlText += "  PROCMONEY.FRACTIONPROCUNITRF," + Environment.NewLine;
            sqlText += "  PROCMONEY.FRACTIONPROCCDRF," + Environment.NewLine;
            sqlText += "  COUNT(STOCK.SUPPLIERSLIPNORF) STOCKSLIPCOUNT, --伝票枚数" + Environment.NewLine;
            sqlText += "  -- ■ ■ 仕入 ■ ■" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STOCKNETPRICERF ELSE 0 END)) AS THISTIMESTOCKPRICERF,       --仕入正価金額" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCOUTTAXRF ELSE 0 END)) AS TTLITDEDSTCOUTTAXRF,    --仕入外税対象額合計" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCINTAXRF ELSE 0 END)) AS TTLITDEDSTCINTAXRF,      --仕入内税対象額合計" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCTAXFREERF ELSE 0 END)) AS TTLITDEDSTCTAXFREERF,  --仕入非課税対象額合計" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 0) AND (STOCK.SUPPLIERSLIPCDRF =10) THEN STOCK.STOCKOUTTAXRF ELSE 0 END)) AS STOCKOUTTAXRF,      --消費税額（外税）伝票" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 1) AND (STOCK.SUPPLIERSLIPCDRF =10) THEN STOCK.DTLSTOCKOUTTAXRF ELSE 0 END)) AS DTLSTOCKOUTTAXRF,--消費税額（外税）明細" + Environment.NewLine;
            sqlText += "  -- 支払(親)転嫁" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF)" + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS STOCKOUTTAXRF1,                     --消費税額（外税）税率1" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF)" + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS STOCKOUTTAXRF2,                          --消費税額（外税）税率2" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF)" + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS STOCKOUTTAXRF3,                          --消費税額（外税）税率3" + Environment.NewLine;
            sqlText += "  -- 支払子" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS STOCKOUTTAXRF1_2,--消費税額（外税）税率1" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS STOCKOUTTAXRF2_2,     --消費税額（外税）税率2" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS STOCKOUTTAXRF3_2,     --消費税額（外税）税率3            " + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STCKPRCCONSTAXINCLURF ELSE 0 END)) AS STCKPRCCONSTAXINCLURF,--消費税額（内税）" + Environment.NewLine;
            sqlText += "  -- ■ ■ 返品 ■ ■" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STOCKNETPRICERF ELSE 0 END)) AS THISSTCKPRICRGDSRF,       --仕入正価金額" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCOUTTAXRF ELSE 0 END)) AS TTLITDEDRETOUTTAXRF,  --仕入外税対象額合計" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCINTAXRF ELSE 0 END)) AS TTLITDEDRETINTAXRF,    --仕入内税対象額合計" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCTAXFREERF ELSE 0 END)) AS TTLITDEDRETTAXFREERF,--仕入非課税対象額合計" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 0) AND (STOCK.SUPPLIERSLIPCDRF =20) THEN STOCK.STOCKOUTTAXRF ELSE 0 END)) AS TTLRETOUTERTAXRF,      --消費税額（外税）伝票" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 1) AND (STOCK.SUPPLIERSLIPCDRF =20) THEN STOCK.DTLSTOCKOUTTAXRF ELSE 0 END)) AS DTLTTLRETOUTERTAXRF,--消費税額（外税）明細" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF)" + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS TTLRETOUTERTAXRF1,                --消費税額（外税）税率1" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF)" + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS TTLRETOUTERTAXRF2,                     --消費税額（外税）税率2" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF)" + Environment.NewLine;
            sqlText += "           THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS TTLRETOUTERTAXRF3,                      --消費税額（外税）税率3" + Environment.NewLine;
            sqlText += "  -- 支払子" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS TTLRETOUTERTAXRF1_2,--消費税額（外税）税率1" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS TTLRETOUTERTAXRF2_2,     --消費税額（外税）税率2" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
            sqlText += "           THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS TTLRETOUTERTAXRF3_2,      --消費税額（外税）税率3           " + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STCKPRCCONSTAXINCLURF ELSE 0 END)) AS TTLRETINNERTAXRF,   --消費税額（内税）" + Environment.NewLine;
            sqlText += "  -- ■ ■ 値引 ■ ■" + Environment.NewLine;
            sqlText += "  SUM(STOCK.STCKDISTTLTAXEXCRF) AS THISSTCKPRICDISRF,       --値引金額計（税抜き）" + Environment.NewLine;
            sqlText += "  SUM(STOCK.ITDEDSTOCKDISOUTTAXRF) AS TTLITDEDDISOUTTAXRF,  --値引外税対象額合計" + Environment.NewLine;
            sqlText += "  SUM(STOCK.ITDEDSTOCKDISINTAXRF) AS TTLITDEDDISINTAXRF,    --値引内税対象額合計" + Environment.NewLine;
            sqlText += "  SUM(STOCK.ITDEDSTOCKDISTAXFRERF) AS TTLITDEDDISTAXFREERF, --値引非課税対象額合計" + Environment.NewLine;
            sqlText += "  SUM(CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 0) THEN STOCK.STOCKDISOUTTAXRF ELSE 0 END) AS STOCKDISOUTTAXRF,   --値引消費税額（外税）伝票" + Environment.NewLine;
            sqlText += "  SUM(CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 1) THEN STOCK.STOCKDISOUTTAXRF ELSE 0 END) AS DTLSTOCKDISOUTTAXRF,--値引消費税額（外税）明細" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF)" + Environment.NewLine;
            sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATERF)ELSE 0 END)) AS STOCKDISOUTTAXRF1,  --値引消費税額（外税）税率1" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF)" + Environment.NewLine;
            sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE2RF)ELSE 0 END)) AS STOCKDISOUTTAXRF2, --値引消費税額（外税）税率2" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF)" + Environment.NewLine;
            sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE3RF)ELSE 0 END)) AS STOCKDISOUTTAXRF3, --値引消費税額（外税）税率3" + Environment.NewLine;
            sqlText += "  -- 支払子" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
            sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATERF)ELSE 0 END)) AS STOCKDISOUTTAXRF1_2, --値引消費税額（外税）税率1" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
            sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE2RF)ELSE 0 END)) AS STOCKDISOUTTAXRF2_2,--値引消費税額（外税）税率2" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
            sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE3RF)ELSE 0 END)) AS STOCKDISOUTTAXRF3_2,--値引消費税額（外税）税率3" + Environment.NewLine;
            sqlText += "  SUM(STOCK.STCKDISTTLTAXINCLURF) AS STCKDISTTLTAXINCLURF    --値引消費税額（内税）" + Environment.NewLine;
            sqlText += "  FROM" + Environment.NewLine;
            sqlText += "  (" + Environment.NewLine;

            #region SUBSUBクエリ
            sqlText += "   SELECT" + Environment.NewLine;
            sqlText += "    SUBSTOCK.STOCKSECTIONCDRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.LOGICALDELETECODERF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.SUPPCTAXLAYCDRF,  --消費税転嫁方式" + Environment.NewLine;
            sqlText += "    SUBSTOCK.SUPPLIERFORMALRF, --仕入形式" + Environment.NewLine;
            sqlText += "    SUBSTOCK.DEBITNOTEDIVRF,   --赤伝区分" + Environment.NewLine;
            sqlText += "    SUBSTOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
            sqlText += "    SUBSTOCK.STOCKGOODSCDRF,   --仕入商品区分" + Environment.NewLine;
            sqlText += "    SUBSTOCK.SUPPLIERSLIPNORF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.STOCKADDUPADATERF," + Environment.NewLine;
            sqlText += "    (CASE WHEN (SEARCHSUPPLIER.SUPPLIERCDRF IS NOT NULL) THEN SEARCHSUPPLIER.SUPPLIERCDRF ELSE SUBSTOCK.SUPPLIERCDRF END) AS PAYEECODERF," + Environment.NewLine;

            //仕入・返品(行値引含む)
            sqlText += "    SUBSTOCK.STOCKNETPRICERF + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STOCKNETPRICERF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.TTLITDEDSTCOUTTAXRF + SUBSTOCKDTL.ITDEDSTOCKDISOUTTAXGYO AS TTLITDEDSTCOUTTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.TTLITDEDSTCINTAXRF + SUBSTOCKDTL.ITDEDSTOCKDISINTAXGYO AS TTLITDEDSTCINTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.TTLITDEDSTCTAXFREERF + SUBSTOCKDTL.ITDEDSTOCKDISFREETAXGYO AS TTLITDEDSTCTAXFREERF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.STOCKOUTTAXRF + SUBSTOCKDTL.STOCKDISOUTTAXGYO AS STOCKOUTTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.STCKPRCCONSTAXINCLURF + SUBSTOCKDTL.STOCKDISINTAXGYO AS STCKPRCCONSTAXINCLURF," + Environment.NewLine;
            //値引(行値引除く)
            sqlText += "    SUBSTOCK.STCKDISTTLTAXEXCRF - SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STCKDISTTLTAXEXCRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.ITDEDSTOCKDISOUTTAXRF - SUBSTOCKDTL.ITDEDSTOCKDISOUTTAXGYO AS ITDEDSTOCKDISOUTTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.ITDEDSTOCKDISINTAXRF - SUBSTOCKDTL.ITDEDSTOCKDISINTAXGYO AS ITDEDSTOCKDISINTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.ITDEDSTOCKDISTAXFRERF - SUBSTOCKDTL.ITDEDSTOCKDISFREETAXGYO AS ITDEDSTOCKDISTAXFRERF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.STOCKDISOUTTAXRF - SUBSTOCKDTL.STOCKDISOUTTAXGYO AS STOCKDISOUTTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.STCKDISTTLTAXINCLURF - SUBSTOCKDTL.STOCKDISINTAXGYO AS STCKDISTTLTAXINCLURF," + Environment.NewLine;

            sqlText += "    SUBSTOCKDTL.DTLSTOCKOUTTAXRF + SUBSTOCKDTL.STOCKDISOUTTAXGYO AS DTLSTOCKOUTTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCKDTL.DTLSTCKPRCCONSTAXINCLURF + SUBSTOCKDTL.STOCKDISINTAXGYO AS DTLSTCKPRCCONSTAXINCLURF," + Environment.NewLine;


            // 税率取得
            sqlText += "    TAX.TAXRATESTARTDATERF AS TAXRATESTARTDATERF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATEENDDATERF AS TAXRATEENDDATERF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATERF AS TAXRATERF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATE2RF AS TAXRATE2RF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATE3RF AS TAXRATE3RF,    " + Environment.NewLine;
            sqlText += "    TAX.CONSTAXLAYMETHODRF AS TAXCONSTAXLAYMETHODRF" + Environment.NewLine;
            sqlText += "   FROM" + Environment.NewLine;
            sqlText += "    STOCKSLIPRF AS SUBSTOCK" + Environment.NewLine;

            #region [ SUBSUBクエリJOIN ]
            sqlText += "    LEFT JOIN TAXRATESETRF AS TAX" + Environment.NewLine;
            sqlText += "     ON SUBSTOCK.ENTERPRISECODERF = TAX.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    LEFT JOIN SUPPLIERRF AS SEARCHSUPPLIER" + Environment.NewLine;
            sqlText += "     ON SUBSTOCK.ENTERPRISECODERF = SEARCHSUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "     AND SUBSTOCK.SUPPLIERCDRF = SEARCHSUPPLIER.SUPPLIERCDRF" + Environment.NewLine;
            sqlText += "    LEFT JOIN" + Environment.NewLine;
            sqlText += "    ( " + Environment.NewLine;
            sqlText += "      SELECT" + Environment.NewLine;
            sqlText += "       STOCK.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERSLIPNORF, --仕入伝票番号 " + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF != 2 AND DTL.TAXATIONCODERF = 0) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTOCKOUTTAXRF," + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF != 2 AND DTL.TAXATIONCODERF = 2) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTCKPRCCONSTAXINCLURF," + Environment.NewLine;
            sqlText += "       -- 行値引" + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS DISSTOCKPRICETAXEXCGYO," + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISOUTTAXGYO, -- 外税対象額(行値引)" + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 1 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISFREETAXGYO,-- 非課税対象額(行値引)" + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 2 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISINTAXGYO,  -- 内税対象額(行値引)" + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 0 ) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS STOCKDISOUTTAXGYO, -- 外税額(行値引)" + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 2 ) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS STOCKDISINTAXGYO  -- 内税額(行値引)" + Environment.NewLine;
            sqlText += "      FROM" + Environment.NewLine;
            sqlText += "       STOCKDETAILRF AS DTL" + Environment.NewLine;
            sqlText += "      LEFT JOIN STOCKSLIPRF AS STOCK" + Environment.NewLine;
            sqlText += "       ON DTL.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "       AND DTL.SUPPLIERFORMALRF = STOCK.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "       AND DTL.SUPPLIERSLIPNORF = STOCK.SUPPLIERSLIPNORF" + Environment.NewLine;
            sqlText += "      GROUP BY" + Environment.NewLine;
            sqlText += "       STOCK.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERSLIPNORF --仕入伝票番号 " + Environment.NewLine;
            sqlText += "    ) AS SUBSTOCKDTL" + Environment.NewLine;
            sqlText += "    ON  SUBSTOCK.ENTERPRISECODERF = SUBSTOCKDTL.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SUBSTOCK.SUPPLIERFORMALRF = SUBSTOCKDTL.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "    AND SUBSTOCK.SUPPLIERSLIPNORF = SUBSTOCKDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
            #endregion

            #endregion

            #region [ WHERE ]
            sqlText += "   WHERE SUBSTOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "    AND  (CASE WHEN (SEARCHSUPPLIER.SUPPLIERCDRF IS NOT NULL) THEN SEARCHSUPPLIER.SUPPLIERCDRF ELSE SUBSTOCK.SUPPLIERCDRF END)=@FINDCUSTOMERCODE " + Environment.NewLine;
            sqlText += "    AND (SUBSTOCK.STOCKADDUPADATERF<=@FINDADDUPDATE AND SUBSTOCK.STOCKADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
            sqlText += "    AND  SUBSTOCK.LOGICALDELETECODERF=0" + Environment.NewLine;
            sqlText += "    AND  SUBSTOCK.SUPPLIERFORMALRF=0" + Environment.NewLine;
            sqlText += "    AND  SUBSTOCK.DEBITNOTEDIVRF=0" + Environment.NewLine;
            sqlText += "    AND (SUBSTOCK.SUPPLIERSLIPCDRF = 10 OR SUBSTOCK.SUPPLIERSLIPCDRF = 20)" + Environment.NewLine;
            sqlText += "    AND (SUBSTOCK.STOCKGOODSCDRF=0 OR SUBSTOCK.STOCKGOODSCDRF = 6)" + Environment.NewLine;
            sqlText += "    AND  SUBSTOCK.STOCKSECTIONCDRF=@FINDADDUPSECCODE" + Environment.NewLine;
            #endregion

            #region [ JOIN ]
            sqlText += "   ) AS STOCK" + Environment.NewLine;
            sqlText += "   INNER JOIN SUPPLIERRF AS SUPPLIER" + Environment.NewLine;
            sqlText += "    ON SUPPLIER.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SUPPLIER.SUPPLIERCDRF = STOCK.PAYEECODERF" + Environment.NewLine;
            sqlText += "   LEFT JOIN STOCKPROCMONEYRF AS PROCMONEY" + Environment.NewLine;
            sqlText += "    ON PROCMONEY.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND PROCMONEY.FRACPROCMONEYDIVRF = 1" + Environment.NewLine;
            sqlText += "    AND PROCMONEY.FRACTIONPROCCODERF = SUPPLIER.STOCKCNSTAXFRCPROCCDRF" + Environment.NewLine;

            #endregion

            #region [ GROUP BY ]
            sqlText += "   GROUP BY" + Environment.NewLine;
            sqlText += "    STOCK.PAYEECODERF," + Environment.NewLine;
            sqlText += "    STOCK.STOCKSECTIONCDRF," + Environment.NewLine;
            sqlText += "    SUPPLIER.SUPPLIERNM1RF," + Environment.NewLine;
            sqlText += "    SUPPLIER.SUPPLIERNM2RF," + Environment.NewLine;
            sqlText += "    SUPPLIER.SUPPLIERSNMRF,   " + Environment.NewLine;
            sqlText += "    SUPPLIER.STOCKCNSTAXFRCPROCCDRF," + Environment.NewLine;
            sqlText += "    SUPPLIER.PAYMENTMONTHCODERF," + Environment.NewLine;
            sqlText += "    SUPPLIER.PAYMENTDAYRF," + Environment.NewLine;
            sqlText += "    SUPPLIER.PAYMENTCONDRF," + Environment.NewLine;
            sqlText += "    SUPPLIER.SUPPCTAXLAYREFCDRF," + Environment.NewLine;
            sqlText += "    STOCK.TAXCONSTAXLAYMETHODRF," + Environment.NewLine;
            sqlText += "    PROCMONEY.FRACTIONPROCUNITRF," + Environment.NewLine;
            sqlText += "    PROCMONEY.FRACTIONPROCCDRF " + Environment.NewLine;
            sqlText += ") AS SUPLIERPAY" + Environment.NewLine;
            #endregion

            #endregion
            #endregion

            sqlCommand.CommandText = sqlText;

            #region  Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
            SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
            SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
            SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
            #endregion

            #region Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.SupplierCd);
            findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);
            findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);
            if (suplierPayWork.LastCAddUpUpdDate == DateTime.MinValue)
                findParaLastTimeAddUpDate.Value = 20000101;
            else
                findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.LastCAddUpUpdDate);
            #endregion

            return status;
        }

        /// <summary>
        /// 支払先別仕入親子データ取得SQLを設定します
        /// </summary>
        /// <param name="suplierPayWork">仕入先支払金額ワーク</param>
        /// <param name="sqlCommand">sqlステートメント</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払先別仕入親子データ取得SQLを設定します</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : 2012/09/11</br>
        /// </remarks>
        private int MakeGetParentsStockSlipSql(ref SuplierPayWork suplierPayWork, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string sqlText = string.Empty;

            #region SELECT文作成
            sqlText += "SELECT" + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKSECTIONCDRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.PAYEECODERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.PAYEENM1RF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.PAYEENM2RF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.PAYEESNMRF, " + Environment.NewLine;
            sqlText += " SUPLIERPAY.SUPPLIERCDRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.SUPPLIERNM1RF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.SUPPLIERNM2RF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.SUPPLIERSNMRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.FRACTIONPROCUNITRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.FRACTIONPROCCDRF,  " + Environment.NewLine;
            sqlText += " SUPLIERPAY.PAYMENTMONTHCODERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.PAYMENTDAYRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.PAYMENTCONDRF, " + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKSLIPCOUNT," + Environment.NewLine;
            sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF + SUPLIERPAY.THISSTCKPRICRGDSRF + SUPLIERPAY.THISSTCKPRICDISRF AS OFSTHISTIMESTOCKRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCOUTTAXRF + SUPLIERPAY.TTLITDEDRETOUTTAXRF+SUPLIERPAY.TTLITDEDDISOUTTAXRF AS ITDEDOFFSETOUTTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCINTAXRF + SUPLIERPAY.TTLITDEDRETINTAXRF+SUPLIERPAY.TTLITDEDDISINTAXRF AS ITDEDOFFSETINTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCTAXFREERF + SUPLIERPAY.TTLITDEDRETTAXFREERF+SUPLIERPAY.TTLITDEDDISTAXFREERF AS ITDEDOFFSETTAXFREERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.STCKPRCCONSTAXINCLURF+SUPLIERPAY.TTLRETINNERTAXRF+SUPLIERPAY.STCKDISTTLTAXINCLURF AS OFFSETINTAXRF," + Environment.NewLine;
            sqlText += " -- ■ ■ 売上 ■ ■" + Environment.NewLine;
            sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF AS THISTIMESTOCKPRICERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCOUTTAXRF AS TTLITDEDSTCOUTTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCINTAXRF AS TTLITDEDSTCINTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDSTCTAXFREERF AS TTLITDEDSTCTAXFREERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKOUTTAXRF AS STOCKOUTTAX_D, -- 伝票転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.DTLSTOCKOUTTAXRF AS STOCKOUTTAX_M, --明細転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKOUTTAXRF1 +SUPLIERPAY.STOCKOUTTAXRF2 +SUPLIERPAY.STOCKOUTTAXRF3 AS STOCKOUTTAX_S, --支払親" + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKOUTTAXRF1_2 +SUPLIERPAY.STOCKOUTTAXRF2_2 +SUPLIERPAY.STOCKOUTTAXRF3_2 AS STOCKOUTTAX_S2, --支払子" + Environment.NewLine;
            sqlText += " SUPLIERPAY.STCKPRCCONSTAXINCLURF AS TTLSTOCKINNERTAXRF," + Environment.NewLine;
            sqlText += " -- ■ ■ 返品 ■ ■" + Environment.NewLine;
            sqlText += " SUPLIERPAY.THISSTCKPRICRGDSRF AS THISSTCKPRICRGDSRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDRETOUTTAXRF AS TTLITDEDRETOUTTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDRETINTAXRF AS TTLITDEDRETINTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDRETTAXFREERF AS TTLITDEDRETTAXFREERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLRETOUTERTAXRF AS RETSTOCKOUTTAX_D,   -- 伝票転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.DTLTTLRETOUTERTAXRF AS RETSTOCKOUTTAX_M,-- 明細転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLRETOUTERTAXRF1 +SUPLIERPAY.TTLRETOUTERTAXRF2 +SUPLIERPAY.TTLRETOUTERTAXRF3 AS RETSTOCKOUTTAX_S,-- 支払親転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLRETOUTERTAXRF1_2 +SUPLIERPAY.TTLRETOUTERTAXRF2_2 +SUPLIERPAY.TTLRETOUTERTAXRF3_2 AS RETSTOCKOUTTAX_S2,-- 支払子転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLRETINNERTAXRF AS TTLRETINNERTAXRF," + Environment.NewLine;
            sqlText += " -- ■ ■ 値引 ■ ■" + Environment.NewLine;
            sqlText += " SUPLIERPAY.THISSTCKPRICDISRF AS THISSTCKPRICDISRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDDISOUTTAXRF AS TTLITDEDDISOUTTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDDISINTAXRF AS TTLITDEDDISINTAXRF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.TTLITDEDDISTAXFREERF AS TTLITDEDDISTAXFREERF," + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKDISOUTTAXRF AS DISSTOCKOUTTAX_D,   -- 伝票転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.DTLSTOCKDISOUTTAXRF AS DISSTOCKOUTTAX_M,-- 明細転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKDISOUTTAXRF1 +SUPLIERPAY.STOCKDISOUTTAXRF2 +SUPLIERPAY.STOCKDISOUTTAXRF3 AS DISSTOCKOUTTAX_S,       -- 支払親転嫁" + Environment.NewLine;
            sqlText += " SUPLIERPAY.STOCKDISOUTTAXRF1_2 +SUPLIERPAY.STOCKDISOUTTAXRF2_2 +SUPLIERPAY.STOCKDISOUTTAXRF3_2 AS DISSTOCKOUTTAX_S2,-- 支払子転嫁 " + Environment.NewLine;
            sqlText += " SUPLIERPAY.STCKDISTTLTAXINCLURF AS TTLDISINNERTAXRF" + Environment.NewLine;
            sqlText += " FROM" + Environment.NewLine;
            sqlText += "(" + Environment.NewLine;

            #region SUBクエリ
            sqlText += " SELECT" + Environment.NewLine;
            sqlText += "  STOCK.STOCKSECTIONCDRF," + Environment.NewLine;
            sqlText += "  STOCK.PAYEECODERF," + Environment.NewLine;
            sqlText += "  SUPPLIER.SUPPLIERNM1RF AS PAYEENM1RF," + Environment.NewLine;
            sqlText += "  SUPPLIER.SUPPLIERNM2RF AS PAYEENM2RF," + Environment.NewLine;
            sqlText += "  SUPPLIER.SUPPLIERSNMRF AS PAYEESNMRF," + Environment.NewLine;
            sqlText += "  STOCK.SUPPLIERCDRF," + Environment.NewLine;
            sqlText += "  KOSUPPLIER.SUPPLIERNM1RF," + Environment.NewLine;
            sqlText += "  KOSUPPLIER.SUPPLIERNM2RF," + Environment.NewLine;
            sqlText += "  KOSUPPLIER.SUPPLIERSNMRF,  " + Environment.NewLine;
            sqlText += "  SUPPLIER.STOCKCNSTAXFRCPROCCDRF," + Environment.NewLine;
            sqlText += "  PROCMONEY.FRACTIONPROCUNITRF," + Environment.NewLine;
            sqlText += "  PROCMONEY.FRACTIONPROCCDRF, " + Environment.NewLine;
            sqlText += "  SUPPLIER.PAYMENTMONTHCODERF," + Environment.NewLine;
            sqlText += "  SUPPLIER.PAYMENTDAYRF," + Environment.NewLine;
            sqlText += "  SUPPLIER.PAYMENTCONDRF," + Environment.NewLine;
            sqlText += "  COUNT(STOCK.SUPPLIERSLIPNORF) STOCKSLIPCOUNT, --伝票枚数" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STOCKNETPRICERF ELSE 0 END)) AS THISTIMESTOCKPRICERF,       --仕入正価金額" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCOUTTAXRF ELSE 0 END)) AS TTLITDEDSTCOUTTAXRF,    --仕入外税対象額合計" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCINTAXRF ELSE 0 END)) AS TTLITDEDSTCINTAXRF,      --仕入内税対象額合計" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.TTLITDEDSTCTAXFREERF ELSE 0 END)) AS TTLITDEDSTCTAXFREERF,  --仕入非課税対象額合計 " + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 0) AND (STOCK.SUPPLIERSLIPCDRF =10) THEN STOCK.STOCKOUTTAXRF ELSE 0 END)) AS STOCKOUTTAXRF,      --消費税額（外税）伝票" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 1) AND (STOCK.SUPPLIERSLIPCDRF =10) THEN STOCK.DTLSTOCKOUTTAXRF ELSE 0 END)) AS DTLSTOCKOUTTAXRF,--消費税額（外税）明細" + Environment.NewLine;
            sqlText += "  -- 支払親" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS STOCKOUTTAXRF1,--消費税額（外税）税率1" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS STOCKOUTTAXRF2,     --消費税額（外税）税率2" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS STOCKOUTTAXRF3,     --消費税額（外税）税率3" + Environment.NewLine;
            sqlText += "  -- 支払子" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS STOCKOUTTAXRF1_2,--消費税額（外税）税率1" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS STOCKOUTTAXRF2_2,     --消費税額（外税）税率2" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =10) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS STOCKOUTTAXRF3_2,     --消費税額（外税）税率3            " + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STCKPRCCONSTAXINCLURF ELSE 0 END)) AS STCKPRCCONSTAXINCLURF,--消費税額（内税）" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STOCKNETPRICERF       ELSE 0 END)) AS THISSTCKPRICRGDSRF,   --仕入正価金額" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCOUTTAXRF   ELSE 0 END)) AS TTLITDEDRETOUTTAXRF,  --仕入外税対象額合計" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCINTAXRF    ELSE 0 END)) AS TTLITDEDRETINTAXRF,   --仕入内税対象額合計" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.TTLITDEDSTCTAXFREERF  ELSE 0 END)) AS TTLITDEDRETTAXFREERF, --仕入非課税対象額合計  " + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 0) AND (STOCK.SUPPLIERSLIPCDRF =20) THEN STOCK.STOCKOUTTAXRF ELSE 0 END)) AS TTLRETOUTERTAXRF,      --消費税額（外税）伝票" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 1) AND (STOCK.SUPPLIERSLIPCDRF =20) THEN STOCK.DTLSTOCKOUTTAXRF ELSE 0 END)) AS DTLTTLRETOUTERTAXRF,--消費税額（外税）明細" + Environment.NewLine;
            sqlText += "  -- 支払親" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS TTLRETOUTERTAXRF1,--消費税額（外税）税率1" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS TTLRETOUTERTAXRF2,     --消費税額（外税）税率2" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
            sqlText += "           THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS TTLRETOUTERTAXRF3,      --消費税額（外税）税率3" + Environment.NewLine;
            sqlText += "  -- 支払子" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * STOCK.TAXRATERF) ELSE 0 END)) AS TTLRETOUTERTAXRF1_2,--消費税額（外税）税率1" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
            sqlText += "            THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS TTLRETOUTERTAXRF2_2,     --消費税額（外税）税率2" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.SUPPLIERSLIPCDRF =20) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
            sqlText += "           THEN (STOCK.TTLITDEDSTCOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS TTLRETOUTERTAXRF3_2,      --消費税額（外税）税率3           " + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STCKPRCCONSTAXINCLURF ELSE 0 END)) AS TTLRETINNERTAXRF,--消費税額（内税）" + Environment.NewLine;
            sqlText += "  SUM(STOCK.STCKDISTTLTAXEXCRF) AS THISSTCKPRICDISRF,      --値引金額計（税抜き）" + Environment.NewLine;
            sqlText += "  SUM(STOCK.ITDEDSTOCKDISOUTTAXRF) AS TTLITDEDDISOUTTAXRF, --値引外税対象額合計" + Environment.NewLine;
            sqlText += "  SUM(STOCK.ITDEDSTOCKDISINTAXRF) AS TTLITDEDDISINTAXRF,   --値引内税対象額合計" + Environment.NewLine;
            sqlText += "  SUM(STOCK.ITDEDSTOCKDISTAXFRERF) AS TTLITDEDDISTAXFREERF,--値引非課税対象額合計" + Environment.NewLine;
            sqlText += "  SUM(CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 0) THEN STOCK.STOCKDISOUTTAXRF ELSE 0 END) AS STOCKDISOUTTAXRF,   --値引消費税額（外税）伝票" + Environment.NewLine;
            sqlText += "  SUM(CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 1) THEN STOCK.STOCKDISOUTTAXRF ELSE 0 END) AS DTLSTOCKDISOUTTAXRF,--値引消費税額（外税）明細" + Environment.NewLine;
            sqlText += "  -- 支払親" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
            sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATERF)ELSE 0 END)) AS STOCKDISOUTTAXRF1, --売上値引消費税額（外税）税率1" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
            sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE2RF)ELSE 0 END)) AS STOCKDISOUTTAXRF2,--売上値引消費税額（外税）税率2" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 2) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
            sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE3RF)ELSE 0 END)) AS STOCKDISOUTTAXRF3,--売上値引消費税額（外税）税率3" + Environment.NewLine;
            sqlText += "  -- 支払子" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATERF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATERF) " + Environment.NewLine;
            sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATERF)ELSE 0 END)) AS STOCKDISOUTTAXRF1_2, --売上値引消費税額（外税）税率1" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE2RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE2RF) " + Environment.NewLine;
            sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE2RF)ELSE 0 END)) AS STOCKDISOUTTAXRF2_2,--売上値引消費税額（外税）税率2" + Environment.NewLine;
            sqlText += "  SUM((CASE WHEN (STOCK.SUPPCTAXLAYCDRF = 3) AND (STOCK.STOCKADDUPADATERF >= STOCK.TAXRATESTARTDATE3RF AND STOCK.STOCKADDUPADATERF <= STOCK.TAXRATEENDDATE3RF) " + Environment.NewLine;
            sqlText += "       THEN (STOCK.ITDEDSTOCKDISOUTTAXRF * TAXRATE3RF)ELSE 0 END)) AS STOCKDISOUTTAXRF3_2,--売上値引消費税額（外税）税率3" + Environment.NewLine;
            sqlText += "  SUM(STOCK.STCKDISTTLTAXINCLURF) AS STCKDISTTLTAXINCLURF    --売上値引消費税額（内税）" + Environment.NewLine;
            sqlText += "  FROM" + Environment.NewLine;
            sqlText += "  (" + Environment.NewLine;

            #region SUBSUBクエリ
            sqlText += "   SELECT" + Environment.NewLine;
            sqlText += "    SUBSTOCK.LOGICALDELETECODERF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.SUPPCTAXLAYCDRF,  --消費税転嫁方式" + Environment.NewLine; // ADD 2009/04/17 
            sqlText += "    SUBSTOCK.SUPPLIERFORMALRF, --仕入形式" + Environment.NewLine;
            sqlText += "    SUBSTOCK.DEBITNOTEDIVRF,   --赤伝区分" + Environment.NewLine;
            sqlText += "    SUBSTOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
            sqlText += "    SUBSTOCK.STOCKGOODSCDRF,   --仕入商品区分" + Environment.NewLine;
            sqlText += "    SUBSTOCK.SUPPLIERSLIPNORF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.STOCKADDUPADATERF," + Environment.NewLine;
            sqlText += "    (CASE WHEN (SEARCHSUPPLIER.PAYEECODERF IS NOT NULL) THEN SEARCHSUPPLIER.PAYEECODERF ELSE SUBSTOCK.PAYEECODERF END) AS PAYEECODERF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.SUPPLIERCDRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.STOCKSECTIONCDRF," + Environment.NewLine;

            //仕入・返品(行値引含む)
            sqlText += "    SUBSTOCK.STOCKNETPRICERF + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STOCKNETPRICERF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.TTLITDEDSTCOUTTAXRF + SUBSTOCKDTL.ITDEDSTOCKDISOUTTAXGYO AS TTLITDEDSTCOUTTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.TTLITDEDSTCINTAXRF + SUBSTOCKDTL.ITDEDSTOCKDISINTAXGYO AS TTLITDEDSTCINTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.TTLITDEDSTCTAXFREERF + SUBSTOCKDTL.ITDEDSTOCKDISFREETAXGYO AS TTLITDEDSTCTAXFREERF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.STOCKOUTTAXRF + SUBSTOCKDTL.STOCKDISOUTTAXGYO AS STOCKOUTTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.STCKPRCCONSTAXINCLURF + SUBSTOCKDTL.STOCKDISINTAXGYO AS STCKPRCCONSTAXINCLURF," + Environment.NewLine;
            //値引(行値引除く)
            sqlText += "    SUBSTOCK.STCKDISTTLTAXEXCRF - SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STCKDISTTLTAXEXCRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.ITDEDSTOCKDISOUTTAXRF - SUBSTOCKDTL.ITDEDSTOCKDISOUTTAXGYO AS ITDEDSTOCKDISOUTTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.ITDEDSTOCKDISINTAXRF - SUBSTOCKDTL.ITDEDSTOCKDISINTAXGYO AS ITDEDSTOCKDISINTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.ITDEDSTOCKDISTAXFRERF - SUBSTOCKDTL.ITDEDSTOCKDISFREETAXGYO AS ITDEDSTOCKDISTAXFRERF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.STOCKDISOUTTAXRF - SUBSTOCKDTL.STOCKDISOUTTAXGYO AS STOCKDISOUTTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCK.STCKDISTTLTAXINCLURF - SUBSTOCKDTL.STOCKDISINTAXGYO AS STCKDISTTLTAXINCLURF," + Environment.NewLine;
            sqlText += "    SUBSTOCKDTL.DTLSTOCKOUTTAXRF + SUBSTOCKDTL.STOCKDISOUTTAXGYO AS DTLSTOCKOUTTAXRF," + Environment.NewLine;
            sqlText += "    SUBSTOCKDTL.DTLSTCKPRCCONSTAXINCLURF + SUBSTOCKDTL.STOCKDISINTAXGYO AS DTLSTCKPRCCONSTAXINCLURF," + Environment.NewLine;

            sqlText += "    TAX.TAXRATESTARTDATERF AS TAXRATESTARTDATERF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATEENDDATERF AS TAXRATEENDDATERF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATERF AS TAXRATERF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATE2RF AS TAXRATE2RF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF," + Environment.NewLine;
            sqlText += "    TAX.TAXRATE3RF AS TAXRATE3RF," + Environment.NewLine;
            sqlText += "    TAX.CONSTAXLAYMETHODRF AS TAXCONSTAXLAYMETHODRF" + Environment.NewLine;
            sqlText += "   FROM" + Environment.NewLine;
            sqlText += "    STOCKSLIPRF AS SUBSTOCK" + Environment.NewLine;

            #region [SUBSUBクエリ JOIN]
            sqlText += "    LEFT JOIN TAXRATESETRF AS TAX" + Environment.NewLine;
            sqlText += "     ON SUBSTOCK.ENTERPRISECODERF = TAX.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    LEFT JOIN SUPPLIERRF AS SEARCHSUPPLIER" + Environment.NewLine;
            sqlText += "     ON SUBSTOCK.ENTERPRISECODERF = SEARCHSUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "     AND SUBSTOCK.SUPPLIERCDRF = SEARCHSUPPLIER.SUPPLIERCDRF" + Environment.NewLine;
            sqlText += "    LEFT JOIN" + Environment.NewLine;
            sqlText += "    ( " + Environment.NewLine;
            sqlText += "      SELECT" + Environment.NewLine;
            sqlText += "       STOCK.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERSLIPNORF, --仕入伝票番号 " + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF != 2 AND DTL.TAXATIONCODERF = 0) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTOCKOUTTAXRF," + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF != 2 AND DTL.TAXATIONCODERF = 2) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS DTLSTCKPRCCONSTAXINCLURF," + Environment.NewLine;
            sqlText += "       -- 行値引" + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS DISSTOCKPRICETAXEXCGYO," + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISOUTTAXGYO, -- 外税対象額(行値引)" + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 1 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISFREETAXGYO,-- 非課税対象額(行値引)" + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 2 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS ITDEDSTOCKDISINTAXGYO,  -- 内税対象額(行値引)" + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 0 ) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS STOCKDISOUTTAXGYO, -- 外税額(行値引)" + Environment.NewLine;
            sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 AND DTL.TAXATIONCODERF = 2 ) THEN DTL.STOCKPRICECONSTAXRF ELSE 0 END) AS STOCKDISINTAXGYO  -- 内税額(行値引)" + Environment.NewLine;
            sqlText += "      FROM" + Environment.NewLine;
            sqlText += "       STOCKDETAILRF AS DTL" + Environment.NewLine;
            sqlText += "      LEFT JOIN STOCKSLIPRF AS STOCK" + Environment.NewLine;
            sqlText += "       ON DTL.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "       AND DTL.SUPPLIERFORMALRF = STOCK.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "       AND DTL.SUPPLIERSLIPNORF = STOCK.SUPPLIERSLIPNORF" + Environment.NewLine;
            sqlText += "      GROUP BY" + Environment.NewLine;
            sqlText += "       STOCK.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERFORMALRF, --受注ステータス" + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERSLIPCDRF, --仕入伝票区分" + Environment.NewLine;
            sqlText += "       STOCK.SUPPLIERSLIPNORF --仕入伝票番号 " + Environment.NewLine;
            sqlText += "    ) AS SUBSTOCKDTL" + Environment.NewLine;
            sqlText += "    ON  SUBSTOCK.ENTERPRISECODERF = SUBSTOCKDTL.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SUBSTOCK.SUPPLIERFORMALRF = SUBSTOCKDTL.SUPPLIERFORMALRF" + Environment.NewLine;
            sqlText += "    AND SUBSTOCK.SUPPLIERSLIPNORF = SUBSTOCKDTL.SUPPLIERSLIPNORF" + Environment.NewLine;

            #endregion
            #endregion

            #region WHERE句
            sqlText += "   WHERE SUBSTOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "    AND  (CASE WHEN (SEARCHSUPPLIER.PAYEECODERF IS NOT NULL) THEN SEARCHSUPPLIER.PAYEECODERF ELSE SUBSTOCK.PAYEECODERF END)=@FINDCUSTOMERCODE" + Environment.NewLine;
            sqlText += "    AND (SUBSTOCK.STOCKADDUPADATERF<=@FINDADDUPDATE AND SUBSTOCK.STOCKADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
            sqlText += "    AND  SUBSTOCK.LOGICALDELETECODERF=0" + Environment.NewLine;
            sqlText += "    AND  SUBSTOCK.SUPPLIERFORMALRF=0" + Environment.NewLine;
            sqlText += "    AND  SUBSTOCK.DEBITNOTEDIVRF=0" + Environment.NewLine;
            sqlText += "    AND (SUBSTOCK.SUPPLIERSLIPCDRF = 10 OR SUBSTOCK.SUPPLIERSLIPCDRF = 20)" + Environment.NewLine;
            sqlText += "    AND (SUBSTOCK.STOCKGOODSCDRF=0 OR SUBSTOCK.STOCKGOODSCDRF = 6)     " + Environment.NewLine;
            #endregion

            #region JOIN 句
            sqlText += "   ) AS STOCK" + Environment.NewLine;
            sqlText += "   INNER JOIN SUPPLIERRF AS SUPPLIER" + Environment.NewLine;
            sqlText += "    ON SUPPLIER.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND SUPPLIER.SUPPLIERCDRF = STOCK.PAYEECODERF" + Environment.NewLine;
            sqlText += "   LEFT JOIN SUPPLIERRF AS KOSUPPLIER" + Environment.NewLine;
            sqlText += "    ON KOSUPPLIER.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND KOSUPPLIER.SUPPLIERCDRF = STOCK.SUPPLIERCDRF" + Environment.NewLine;
            sqlText += "   LEFT JOIN STOCKPROCMONEYRF AS PROCMONEY" + Environment.NewLine;
            sqlText += "    ON PROCMONEY.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND PROCMONEY.FRACPROCMONEYDIVRF = 1" + Environment.NewLine;
            sqlText += "    AND PROCMONEY.FRACTIONPROCCODERF = SUPPLIER.STOCKCNSTAXFRCPROCCDRF" + Environment.NewLine;
            #endregion

            #region GROUP BY句
            sqlText += "   GROUP BY" + Environment.NewLine;
            sqlText += "    STOCK.STOCKSECTIONCDRF, " + Environment.NewLine;
            sqlText += "    STOCK.PAYEECODERF," + Environment.NewLine;
            sqlText += "    SUPPLIER.SUPPLIERNM1RF," + Environment.NewLine;
            sqlText += "    SUPPLIER.SUPPLIERNM2RF," + Environment.NewLine;
            sqlText += "    SUPPLIER.SUPPLIERSNMRF,   " + Environment.NewLine;
            sqlText += "    STOCK.SUPPLIERCDRF," + Environment.NewLine;
            sqlText += "    KOSUPPLIER.SUPPLIERNM1RF," + Environment.NewLine;
            sqlText += "    KOSUPPLIER.SUPPLIERNM2RF," + Environment.NewLine;
            sqlText += "    KOSUPPLIER.SUPPLIERSNMRF,    " + Environment.NewLine;
            sqlText += "    SUPPLIER.STOCKCNSTAXFRCPROCCDRF," + Environment.NewLine;
            sqlText += "    PROCMONEY.FRACTIONPROCUNITRF," + Environment.NewLine;
            sqlText += "    PROCMONEY.FRACTIONPROCCDRF,     " + Environment.NewLine;
            sqlText += "    SUPPLIER.PAYMENTMONTHCODERF," + Environment.NewLine;
            sqlText += "    SUPPLIER.PAYMENTDAYRF," + Environment.NewLine;
            sqlText += "    SUPPLIER.SUPPCTAXLAYREFCDRF," + Environment.NewLine;
            sqlText += "    STOCK.TAXCONSTAXLAYMETHODRF," + Environment.NewLine;
            sqlText += "    SUPPLIER.PAYMENTCONDRF    " + Environment.NewLine;
            sqlText += ") AS SUPLIERPAY" + Environment.NewLine;
            #endregion

            #endregion

            #endregion

            sqlCommand.CommandText = sqlText;

            #region Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCodeChild = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaCustomerCodeChild = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
            SqlParameter findParaAddUpDateChild = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
            SqlParameter findParaLastTimeAddUpDateChild = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
            #endregion

            #region Parameterオブジェクトへ値設定
            findParaEnterpriseCodeChild.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
            findParaCustomerCodeChild.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
            findParaAddUpDateChild.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);
            if (suplierPayWork.LastCAddUpUpdDate == DateTime.MinValue)
                findParaLastTimeAddUpDateChild.Value = 20000101;
            else
                findParaLastTimeAddUpDateChild.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.LastCAddUpUpdDate);
            #endregion

            return status;
        }
        // --- ADD 2012/09/11 -----------<<<<<
        #endregion

        #region [支払締更新履歴マスタ更新パラメータ]
        /// <summary>
        /// 仕入先支払金額マスタ計算処理/支払締更新履歴マスタ更新パラメータ作成
        /// </summary>
        /// <param name="suplierPayWorkList">支払金額マスタ更新List</param>
        /// <param name="paymentAddUpHisWorkList">支払締更新履歴マスタ更新List</param>
        /// <param name="suplierPayUpdateWork">仕入先支払金額更新パラメータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額マスタ計算処理/支払締更新履歴マスタ更新パラメータ作成</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>s
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int MakeUpdateList(ref ArrayList suplierPayWorkList, out ArrayList paymentAddUpHisWorkList, SuplierPayUpdateWork suplierPayUpdateWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            paymentAddUpHisWorkList = new ArrayList();
            SuplierPayWork suplierPayWork = null;
            int upFlg = 0;
            for (int i = 0; i < suplierPayWorkList.Count; i++)
            {
                upFlg = 0; // ADD 2008.11.19
                suplierPayWork = suplierPayWorkList[i] as SuplierPayWork;

                if (suplierPayWork.UpdateStatus == 0)
                {
                    // DEL 2008.12.17 >>> 
                    ////支払金額の計算
                    //status = CalculateSuplierPay(ref suplierPayWork);
                    // DEL 2008.12.17 <<<

                    //支払締更新履歴マスタList作成
                    #region 2008.12.19 DEL
                    /*
                    // ↓ 2007.12.07 980081 c
                    //if (suplierPayUpdateWork.ProcCntntsFlag == 2)
                    if (suplierPayUpdateWork.ProcCntntsFlag == 2 && suplierPayWork.SupplierCd == 0)
                    // ↑ 2007.12.07 980081 c
                    {
                    */
                    #endregion

                    PaymentAddUpHisWork paymentAddUpHisWork = new PaymentAddUpHisWork();

                    // ADD 2008.11.18 >>>
                    if (paymentAddUpHisWorkList.Count > 0)
                    {
                        for (int j = 0; j < paymentAddUpHisWorkList.Count; j++)
                        {
                            if ((((PaymentAddUpHisWork)paymentAddUpHisWorkList[j]).EnterpriseCode == suplierPayWork.EnterpriseCode) &&
                                (((PaymentAddUpHisWork)paymentAddUpHisWorkList[j]).AddUpSecCode == suplierPayWork.AddUpSecCode))
                            {
                                upFlg = 1;
                                break;
                            }
                        }
                    }
                    if (upFlg == 0)
                    {
                    // ADD 2008.11.18 <<<

                        paymentAddUpHisWork.EnterpriseCode = suplierPayWork.EnterpriseCode;//企業コード
                        paymentAddUpHisWork.AddUpSecCode = suplierPayWork.AddUpSecCode;//計上拠点コード
                        // ↓ 2007.09.14 980081 c
                        //paymentAddUpHisWork.CustomerCode = suplierPayWork.CustomerCode;//得意先コード
                        paymentAddUpHisWork.SupplierCd = suplierPayWork.PayeeCode;       //仕入先コード
                        // ↑ 2007.09.14 980081 c

                        paymentAddUpHisWork.CAddUpUpdDate = suplierPayWork.AddUpDate;//締次更新年月日
                        paymentAddUpHisWork.CAddUpUpdYearMonth = suplierPayWork.AddUpYearMonth;//締次更新年月
                        paymentAddUpHisWork.CAddUpUpdExecDate = suplierPayWork.CAddUpUpdExecDate;//締次更新実行年月日
                        // 修正 2009/06/22 >>>
                        //paymentAddUpHisWork.LastCAddUpUpdDate = suplierPayWork.LastCAddUpUpdDate;//前回締次更新年月日
                        ////締次更新開始年月日
                        //if (suplierPayWork.LastCAddUpUpdDate == DateTime.MinValue)
                        //    paymentAddUpHisWork.StartCAddUpUpdDate = DateTime.MinValue;
                        //else
                        //    paymentAddUpHisWork.StartCAddUpUpdDate = suplierPayWork.LastCAddUpUpdDate.AddDays(1);

                        if (suplierPayWork.SupplierTotalDay >= 28)
                        {
                            //前回締次更新年月日
                            paymentAddUpHisWork.LastCAddUpUpdDate = new DateTime(suplierPayWork.AddUpDate.Year, suplierPayWork.AddUpDate.Month, 1);
                            paymentAddUpHisWork.LastCAddUpUpdDate = paymentAddUpHisWork.LastCAddUpUpdDate.AddDays(-1);
                        }
                        else
                        {
                            //前回締次更新年月日
                            paymentAddUpHisWork.LastCAddUpUpdDate = suplierPayWork.AddUpDate.AddMonths(-1);

                        }
                        paymentAddUpHisWork.StartCAddUpUpdDate = paymentAddUpHisWork.LastCAddUpUpdDate.AddDays(1);//締次更新開始年月日

                        // 修正 2009/06/22 <<<

                        //2008.07.18 add start ----------------------------->>
                        paymentAddUpHisWork.ProcDivCd = 0;
                        paymentAddUpHisWork.ErrorStatus = 0;
                        paymentAddUpHisWork.HistCtlCd = 0;
                        paymentAddUpHisWork.ProcResult = "正常終了";
                        paymentAddUpHisWork.ConvertProcessDivCd = 0;
                        //2008.07.18 add end -------------------------------<<
                        paymentAddUpHisWorkList.Add(paymentAddUpHisWork);
                    }
                    
                }
            }

            return status;
        }

        /// <summary>
        /// 仕入先支払金額マスタ計算処理
        /// </summary>
        /// <param name="suplierPayWork">仕入先支払金額マスタ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額マスタ計算処理</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>s
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        private int CalculateSuplierPay(ref SuplierPayWork suplierPayWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // ↓ 2007.12.07 980081 c
            #region 旧レイアウト(コメントアウト)
            ////仕入先支払金額マスタ計算処理
            ////相殺後外税対象額
            //suplierPayWork.ItdedOffsetOutTax = suplierPayWork.TtlItdedStcOutTax + suplierPayWork.TtlItdedRetOutTax;
            ////相殺後内税対象額
            //suplierPayWork.ItdedOffsetInTax = suplierPayWork.TtlItdedStcInTax + suplierPayWork.TtlItdedRetInTax;
            ////相殺後非課税対象額
            ////suplierPayWork.ItdedOffsetTaxFree = suplierPayWork.TtlItdedStcTaxFree + suplierPayWork.TtlItdedRetTaxFree + suplierPayWork.BalanceAdjust;
            //suplierPayWork.ItdedOffsetTaxFree = suplierPayWork.TtlItdedStcTaxFree + suplierPayWork.TtlItdedRetTaxFree;
            ////請求転嫁の場合は・・　相殺後外税消費税=(仕入外税対象額-返品外税対象額)×消費税税率，端数処理区分(部品にて処理)
            ////相殺後外税消費税（伝票）
            //suplierPayWork.OffsetOutTaxSlip = suplierPayWork.TtlStockOuterTaxSlip + suplierPayWork.TtlRetOuterTaxSlip;
            ////相殺後外税消費税（請求）
            //suplierPayWork.OffsetOutTaxDmd = (long)(CalculateConsTax.Fraction((suplierPayWork.TtlItdedStcOutTaxDmd + suplierPayWork.TtlItdedRetOutTaxDmd) * suplierPayWork.SupplierConsTaxRate, suplierPayWork.FractionProcCd));
            ////相殺後外税消費税
            //suplierPayWork.OffsetOutTax = suplierPayWork.OffsetOutTaxSlip + suplierPayWork.OffsetOutTaxDmd;
            ////相殺後内税消費税
            //suplierPayWork.OffsetInTax = suplierPayWork.TtlStockInnerTax + suplierPayWork.TtlRetInnerTax;
            ////返品外税額合計（請求）
            //suplierPayWork.TtlRetOuterTaxDmd = suplierPayWork.OffsetOutTaxDmd - suplierPayWork.TtlStockOuterTaxDmd;
            ////返品外税額合計
            //suplierPayWork.TtlRetOuterTax = suplierPayWork.TtlRetOuterTaxSlip + suplierPayWork.TtlRetOuterTaxDmd;
            ////消費税調整額を加算
            ////外税の場合
            ////if (suplierPayWork.SuppTtlAmntDspWayCd == 0)
            ////{
            ////    //相殺後外税消費税
            ////    suplierPayWork.OffsetOutTax += suplierPayWork.TaxAdust;
            ////}
            ////else if (suplierPayWork.SuppTtlAmntDspWayCd == 1)
            ////{
            ////    //相殺後内税消費税
            ////    suplierPayWork.OffsetInTax += suplierPayWork.TaxAdust;
            ////}
            ////今回繰越残高（支払計）
            //suplierPayWork.ThisTimeTtlBlcPay = suplierPayWork.LastTimePayment - (suplierPayWork.ThisTimePayNrml + suplierPayWork.ThisTimeFeePayNrml + suplierPayWork.ThisTimeDisPayNrml + suplierPayWork.ThisTimeRbtPayNrml);
            ////今回仕入金額
            ////suplierPayWork.ThisTimeStockPrice = suplierPayWork.TtlItdedStcOutTax + suplierPayWork.TtlItdedStcInTax + suplierPayWork.TtlItdedStcTaxFree;
            //suplierPayWork.ThisTimeStockPrice = suplierPayWork.TtlItdedStcOutTax + suplierPayWork.TtlItdedStcInTax + suplierPayWork.TtlItdedStcTaxFree + suplierPayWork.BalanceAdjust;
            ////今回仕入消費税
            ////suplierPayWork.ThisStcPrcTax = suplierPayWork.TtlStockOuterTax + suplierPayWork.TtlStockInnerTax;
            //suplierPayWork.ThisStcPrcTax = suplierPayWork.TtlStockOuterTax + suplierPayWork.TtlStockInnerTax + suplierPayWork.TaxAdust;
            ////今回返品金額
            //suplierPayWork.ThisStckPricRgds = suplierPayWork.TtlItdedRetOutTax + suplierPayWork.TtlItdedRetInTax + suplierPayWork.TtlItdedRetTaxFree;
            ////今回返品消費税
            //suplierPayWork.ThisStcPrcTaxRgds = suplierPayWork.TtlRetOuterTax + suplierPayWork.TtlRetInnerTax;
            #endregion
            // ↓ 2008.01.10 980081 a
            //今回繰越残高（支払計）
            suplierPayWork.ThisTimeTtlBlcPay = suplierPayWork.LastTimePayment - suplierPayWork.ThisTimePayNrml;
            // ↑ 2008.01.10 980081 a
            //相殺後今回仕入金額 = 今回仕入金額＋今回返品金額＋今回値引金額 + 残高調整額
            suplierPayWork.OfsThisTimeStock = suplierPayWork.ThisTimeStockPrice + suplierPayWork.ThisStckPricRgds + suplierPayWork.ThisStckPricDis + suplierPayWork.BalanceAdjust;
            //相殺後今回仕入消費税 = 相殺後外税消費税＋相殺後内税消費税 + 消費税調整額 = 今回の消費税総額
            suplierPayWork.OfsThisStockTax = suplierPayWork.OffsetOutTax + suplierPayWork.OffsetInTax + suplierPayWork.TaxAdjust;
            //相殺後外税対象額 = 仕入外税対象額＋返品外税対象額＋値引外税対象額
            suplierPayWork.ItdedOffsetOutTax = suplierPayWork.TtlItdedStcOutTax + suplierPayWork.TtlItdedRetOutTax + suplierPayWork.TtlItdedStcOutTaxDmd;
            //相殺後内税対象額 = 仕入内税対象額＋返品内税対象額＋値引内税対象額
            suplierPayWork.ItdedOffsetInTax = suplierPayWork.TtlItdedStcInTax + suplierPayWork.TtlItdedRetInTax + suplierPayWork.TtlItdedDisInTax;
            //相殺後非課税対象額 = 仕入非課税対象額＋返品非課税対象額＋値引非課税対象額
            suplierPayWork.ItdedOffsetTaxFree = suplierPayWork.TtlItdedStcTaxFree + suplierPayWork.TtlItdedRetTaxFree + suplierPayWork.TtlItdedDisTaxFree;
            
            //相殺後外税消費税 = 消費税外税の合計
            if (suplierPayWork.SuppCTaxLayCd == 2)
            {
                //相殺後外税消費税額
                suplierPayWork.OffsetOutTax = Fraction(suplierPayWork.ItdedOffsetOutTax * suplierPayWork.SupplierConsTaxRate, suplierPayWork.FractionProcCd);
                //相殺後消費税額
                suplierPayWork.OfsThisStockTax = suplierPayWork.OffsetOutTax + suplierPayWork.OffsetInTax + suplierPayWork.TaxAdjust;
                //仕入外税額(参考値)
                suplierPayWork.TtlStockOuterTax = Fraction(suplierPayWork.TtlItdedStcOutTax * suplierPayWork.SupplierConsTaxRate, suplierPayWork.FractionProcCd);
                //仕入消費税額
                suplierPayWork.ThisStcPrcTax = suplierPayWork.TtlStockOuterTax + suplierPayWork.TtlStockInnerTax;
                //返品外税額(参考値)
                suplierPayWork.TtlRetOuterTax = Fraction(suplierPayWork.TtlItdedRetOutTax * suplierPayWork.SupplierConsTaxRate, suplierPayWork.FractionProcCd);
                //返品消費税額
                suplierPayWork.ThisStcPrcTaxRgds = suplierPayWork.TtlRetOuterTax + suplierPayWork.TtlRetInnerTax;
                //値引外税額(参考値)
                suplierPayWork.TtlDisOuterTax = Fraction(suplierPayWork.TtlItdedDisOutTax * suplierPayWork.SupplierConsTaxRate, suplierPayWork.FractionProcCd);
                //値引消費税額
                suplierPayWork.ThisStcPrcTaxDis = suplierPayWork.TtlDisOuterTax + suplierPayWork.TtlDisInnerTax;
                // 2008.07.24 del start ------------------------------------------->>
                ////受取外税額(参考値)
                //suplierPayWork.ThisRecvOuterTax = Fraction(suplierPayWork.ThisRecvOutTax * suplierPayWork.SupplierConsTaxRate, suplierPayWork.FractionProcCd);
                ////受取消費税額
                //suplierPayWork.ThisRecvOffsetTax = suplierPayWork.ThisRecvOuterTax + suplierPayWork.ThisRecvInnerTax;
                // 2008.07.24 del end ---------------------------------------------<<
            }
            else if (suplierPayWork.SuppCTaxLayCd == 3)
            {
                //消費税課税区分 3:支払子の場合 仕入先単位に相殺後外税対象額に対し計算する。(相殺後外税対象額合計×税率)
            }
            else
            {
                //消費税課税区分 0:伝票、1:明細の場合 仕入外税額合計＋返品外税額合計＋値引外税額合計
                suplierPayWork.OffsetOutTax = suplierPayWork.TtlStockOuterTax + suplierPayWork.TtlRetOuterTax + suplierPayWork.TtlDisOuterTax;
            }
            
            //相殺後内税消費税 = 仕入内税額合計＋返品内税額合計＋値引内税額合計
            suplierPayWork.OffsetInTax = suplierPayWork.TtlStockInnerTax + suplierPayWork.TtlRetInnerTax + suplierPayWork.TtlDisInnerTax;

            // ↓ 2008.03.12 980081 a
            //相殺後今回仕入消費税 = 相殺後外税消費税＋相殺後内税消費税 + 消費税調整額
            suplierPayWork.OfsThisStockTax = suplierPayWork.OffsetOutTax + suplierPayWork.OffsetInTax + suplierPayWork.TaxAdjust;
            // ↑ 2008.03.12 980081 a

            //計算後支払金額
            suplierPayWork.StockTotalPayBalance = suplierPayWork.ThisTimeTtlBlcPay + suplierPayWork.OfsThisTimeStock + suplierPayWork.OfsThisStockTax + suplierPayWork.BalanceAdjust + suplierPayWork.TaxAdjust;
            // ↑ 2007.12.07 980081

            return status;
        }

        #endregion

        #region [Delete 最終締取消]
        /// <summary>
        /// 最終締取消を行います
        /// </summary>
        /// <param name="paraObj">仕入先支払金額マスタ更新パラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 最終締取消を行います</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        public int Delete(ref object paraObj, out string retMsg)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            retMsg = null;

            //●削除パラメータ
            //SuplierPayWork suplierPayWork = null;
            //ArrayList deleteList = new ArrayList();

            // ↓ 2008.01.10 980081 a
            //拠点情報設定取得部品
            SecInfoSetDB secInfoSetDB = new SecInfoSetDB();
            // ↑ 2008.01.10 980081 a
            try
            {
                SuplierPayUpdateWork suplierPayUpdateWork = paraObj as SuplierPayUpdateWork;

                //●パラメータチェック
                if (suplierPayUpdateWork == null)
                {
                    base.WriteErrorLog(null, "プログラムエラー。パラメータが未設定です");
                    return status;
                }
                if (suplierPayUpdateWork.ProcCntntsFlag == 2)
                {
                    //コネクション生成
                    sqlConnection = CreateSqlConnection();
                    if (sqlConnection == null) return status;
                    sqlConnection.Open();
                    // 修正 2008.12.17 >>>

                    #region 2008.12.17 DEL
                    /*
                // ↓ 2008.01.10 980081 a
                //全拠点一括締め対応
                SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
                secInfoSetWork.EnterpriseCode = suplierPayUpdateWork.EnterpriseCode;
                ArrayList secInfoList = new ArrayList();
                //if (suplierPayUpdateWork.AddUpSecCode == null || suplierPayUpdateWork.AddUpSecCode == "") // DEL 2008.11.19
                if (suplierPayUpdateWork.AddUpSecCode == null || suplierPayUpdateWork.AddUpSecCode == "00") // ADD 2008.11.19  
                {
                    secInfoSetDB.Search(out secInfoList, secInfoSetWork, 0, 0, ref sqlConnection);
                }
                else
                {
                    secInfoSetWork.SectionCode = suplierPayUpdateWork.AddUpSecCode;
                    secInfoList.Add(secInfoSetWork);
                }
                string addUpSecCode = suplierPayUpdateWork.AddUpSecCode;
                for (int loopCount = 0; loopCount < secInfoList.Count; loopCount++)
                {
                    suplierPayUpdateWork.AddUpSecCode = (secInfoList[loopCount] as SecInfoSetWork).SectionCode;
                // ↑ 2008.01.10 980081 a
                    //●削除得意先List作成
                    //全得意先対象
                    if (suplierPayUpdateWork.UpdObjectFlag == 1)
                    {
                        status = GetSupplier(ref suplierPayUpdateWork, ref deleteList, ref sqlConnection);
                    }
                    //個別仕入先指定
                    else if (suplierPayUpdateWork.UpdObjectFlag == 2)
                    {
                        #region [仕入先1～10まで] ※現在未使用
                        if (suplierPayUpdateWork.SupplierCd1 != 0)
                        {
                            suplierPayWork = new SuplierPayWork();
                            suplierPayWork.EnterpriseCode = suplierPayUpdateWork.EnterpriseCode;
                            suplierPayWork.AddUpSecCode = suplierPayUpdateWork.AddUpSecCode;
                            suplierPayWork.SupplierCd = suplierPayUpdateWork.SupplierCd1;
                            suplierPayWork.SupplierTotalDay = suplierPayUpdateWork.Supplier1TotalDay;

                            status = GetIndivSupplier(ref suplierPayWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "仕入先が登録されておりません : " + suplierPayUpdateWork.SupplierCd1;
                                return status;
                            }
                            else
                            {
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (suplierPayUpdateWork.AddUpSecCode.Trim() != suplierPayWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と支払拠点が一致しません : " + suplierPayUpdateWork.SupplierCd1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (suplierPayUpdateWork.SupplierTotalDay != 0)
                                {
                                    if (suplierPayUpdateWork.SupplierTotalDay == 99)
                                    {
                                        if (suplierPayWork.SupplierTotalDay == 28 || suplierPayWork.SupplierTotalDay == 29 ||
                                            suplierPayWork.SupplierTotalDay == 30 || suplierPayWork.SupplierTotalDay == 31)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd1.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (suplierPayUpdateWork.SupplierTotalDay == suplierPayWork.SupplierTotalDay)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd1.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(suplierPayWork);
                                }
                            }
                        }
                        if (suplierPayUpdateWork.SupplierCd2 != 0)
                        {
                            suplierPayWork = new SuplierPayWork();
                            suplierPayWork.EnterpriseCode = suplierPayUpdateWork.EnterpriseCode;
                            suplierPayWork.AddUpSecCode = suplierPayUpdateWork.AddUpSecCode;
                            suplierPayWork.SupplierCd = suplierPayUpdateWork.SupplierCd2;
                            suplierPayWork.SupplierTotalDay = suplierPayUpdateWork.Supplier2TotalDay;

                            status = GetIndivSupplier(ref suplierPayWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "仕入先が登録されておりません : " + suplierPayUpdateWork.SupplierCd2;
                                return status;
                            }
                            else
                            {
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (suplierPayUpdateWork.AddUpSecCode.Trim() != suplierPayWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と支払拠点が一致しません : " + suplierPayUpdateWork.SupplierCd1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (suplierPayUpdateWork.SupplierTotalDay != 0)
                                {
                                    if (suplierPayUpdateWork.SupplierTotalDay == 99)
                                    {
                                        if (suplierPayWork.SupplierTotalDay == 28 || suplierPayWork.SupplierTotalDay == 29 ||
                                            suplierPayWork.SupplierTotalDay == 30 || suplierPayWork.SupplierTotalDay == 31)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd2.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (suplierPayUpdateWork.SupplierTotalDay == suplierPayWork.SupplierTotalDay)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd2.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(suplierPayWork);
                                }
                            }
                        }
                        if (suplierPayUpdateWork.SupplierCd3 != 0)
                        {
                            suplierPayWork = new SuplierPayWork();
                            suplierPayWork.EnterpriseCode = suplierPayUpdateWork.EnterpriseCode;
                            suplierPayWork.AddUpSecCode = suplierPayUpdateWork.AddUpSecCode;
                            suplierPayWork.SupplierCd = suplierPayUpdateWork.SupplierCd3;

                            status = GetIndivSupplier(ref suplierPayWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "仕入先が登録されておりません : " + suplierPayUpdateWork.SupplierCd3;
                                return status;
                            }
                            else
                            {
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (suplierPayUpdateWork.AddUpSecCode.Trim() != suplierPayWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と支払拠点が一致しません : " + suplierPayUpdateWork.SupplierCd1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (suplierPayUpdateWork.SupplierTotalDay != 0)
                                {
                                    if (suplierPayUpdateWork.SupplierTotalDay == 99)
                                    {
                                        if (suplierPayWork.SupplierTotalDay == 28 || suplierPayWork.SupplierTotalDay == 29 ||
                                            suplierPayWork.SupplierTotalDay == 30 || suplierPayWork.SupplierTotalDay == 31)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd3.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (suplierPayUpdateWork.SupplierTotalDay == suplierPayWork.SupplierTotalDay)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd3.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(suplierPayWork);
                                }
                            }
                        }
                        if (suplierPayUpdateWork.SupplierCd4 != 0)
                        {
                            suplierPayWork = new SuplierPayWork();
                            suplierPayWork.EnterpriseCode = suplierPayUpdateWork.EnterpriseCode;
                            suplierPayWork.AddUpSecCode = suplierPayUpdateWork.AddUpSecCode;
                            suplierPayWork.SupplierCd = suplierPayUpdateWork.SupplierCd4;

                            status = GetIndivSupplier(ref suplierPayWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "仕入先が登録されておりません : " + suplierPayUpdateWork.SupplierCd4;
                                return status;
                            }
                            else
                            {
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (suplierPayUpdateWork.AddUpSecCode.Trim() != suplierPayWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と支払拠点が一致しません : " + suplierPayUpdateWork.SupplierCd1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (suplierPayUpdateWork.SupplierTotalDay != 0)
                                {
                                    if (suplierPayUpdateWork.SupplierTotalDay == 99)
                                    {
                                        if (suplierPayWork.SupplierTotalDay == 28 || suplierPayWork.SupplierTotalDay == 29 ||
                                            suplierPayWork.SupplierTotalDay == 30 || suplierPayWork.SupplierTotalDay == 31)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd4.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (suplierPayUpdateWork.SupplierTotalDay == suplierPayWork.SupplierTotalDay)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd4.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(suplierPayWork);
                                }
                            }
                        }
                        if (suplierPayUpdateWork.SupplierCd5 != 0)
                        {
                            suplierPayWork = new SuplierPayWork();
                            suplierPayWork.EnterpriseCode = suplierPayUpdateWork.EnterpriseCode;
                            suplierPayWork.AddUpSecCode = suplierPayUpdateWork.AddUpSecCode;
                            suplierPayWork.SupplierCd = suplierPayUpdateWork.SupplierCd5;

                            status = GetIndivSupplier(ref suplierPayWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "仕入先が登録されておりません : " + suplierPayUpdateWork.SupplierCd5;
                                return status;
                            }
                            else
                            {
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (suplierPayUpdateWork.AddUpSecCode.Trim() != suplierPayWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と支払拠点が一致しません : " + suplierPayUpdateWork.SupplierCd1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (suplierPayUpdateWork.SupplierTotalDay != 0)
                                {
                                    if (suplierPayUpdateWork.SupplierTotalDay == 99)
                                    {
                                        if (suplierPayWork.SupplierTotalDay == 28 || suplierPayWork.SupplierTotalDay == 29 ||
                                            suplierPayWork.SupplierTotalDay == 30 || suplierPayWork.SupplierTotalDay == 31)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd5.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (suplierPayUpdateWork.SupplierTotalDay == suplierPayWork.SupplierTotalDay)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd5.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(suplierPayWork);
                                }
                            }
                        }
                        if (suplierPayUpdateWork.SupplierCd6 != 0)
                        {
                            suplierPayWork = new SuplierPayWork();
                            suplierPayWork.EnterpriseCode = suplierPayUpdateWork.EnterpriseCode;
                            suplierPayWork.AddUpSecCode = suplierPayUpdateWork.AddUpSecCode;
                            suplierPayWork.SupplierCd = suplierPayUpdateWork.SupplierCd6;

                            status = GetIndivSupplier(ref suplierPayWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "仕入先が登録されておりません : " + suplierPayUpdateWork.SupplierCd6;
                                return status;
                            }
                            else
                            {
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (suplierPayUpdateWork.AddUpSecCode.Trim() != suplierPayWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と支払拠点が一致しません : " + suplierPayUpdateWork.SupplierCd1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (suplierPayUpdateWork.SupplierTotalDay != 0)
                                {
                                    if (suplierPayUpdateWork.SupplierTotalDay == 99)
                                    {
                                        if (suplierPayWork.SupplierTotalDay == 28 || suplierPayWork.SupplierTotalDay == 29 ||
                                            suplierPayWork.SupplierTotalDay == 30 || suplierPayWork.SupplierTotalDay == 31)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd6.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (suplierPayUpdateWork.SupplierTotalDay == suplierPayWork.SupplierTotalDay)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd6.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(suplierPayWork);
                                }
                            }
                        }
                        if (suplierPayUpdateWork.SupplierCd7 != 0)
                        {
                            suplierPayWork = new SuplierPayWork();
                            suplierPayWork.EnterpriseCode = suplierPayUpdateWork.EnterpriseCode;
                            suplierPayWork.AddUpSecCode = suplierPayUpdateWork.AddUpSecCode;
                            suplierPayWork.SupplierCd = suplierPayUpdateWork.SupplierCd7;

                            status = GetIndivSupplier(ref suplierPayWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "仕入先が登録されておりません : " + suplierPayUpdateWork.SupplierCd7;
                                return status;
                            }
                            else
                            {
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (suplierPayUpdateWork.AddUpSecCode.Trim() != suplierPayWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と支払拠点が一致しません : " + suplierPayUpdateWork.SupplierCd1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (suplierPayUpdateWork.SupplierTotalDay != 0)
                                {
                                    if (suplierPayUpdateWork.SupplierTotalDay == 99)
                                    {
                                        if (suplierPayWork.SupplierTotalDay == 28 || suplierPayWork.SupplierTotalDay == 29 ||
                                            suplierPayWork.SupplierTotalDay == 30 || suplierPayWork.SupplierTotalDay == 31)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd7.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (suplierPayUpdateWork.SupplierTotalDay == suplierPayWork.SupplierTotalDay)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd7.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(suplierPayWork);
                                }
                            }
                        }
                        if (suplierPayUpdateWork.SupplierCd8 != 0)
                        {
                            suplierPayWork = new SuplierPayWork();
                            suplierPayWork.EnterpriseCode = suplierPayUpdateWork.EnterpriseCode;
                            suplierPayWork.AddUpSecCode = suplierPayUpdateWork.AddUpSecCode;
                            suplierPayWork.SupplierCd = suplierPayUpdateWork.SupplierCd8;

                            status = GetIndivSupplier(ref suplierPayWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "仕入先が登録されておりません : " + suplierPayUpdateWork.SupplierCd8;
                                return status;
                            }
                            else
                            {
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (suplierPayUpdateWork.AddUpSecCode.Trim() != suplierPayWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と支払拠点が一致しません : " + suplierPayUpdateWork.SupplierCd1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (suplierPayUpdateWork.SupplierTotalDay != 0)
                                {
                                    if (suplierPayUpdateWork.SupplierTotalDay == 99)
                                    {
                                        if (suplierPayWork.SupplierTotalDay == 28 || suplierPayWork.SupplierTotalDay == 29 ||
                                            suplierPayWork.SupplierTotalDay == 30 || suplierPayWork.SupplierTotalDay == 31)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd8.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (suplierPayUpdateWork.SupplierTotalDay == suplierPayWork.SupplierTotalDay)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd8.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(suplierPayWork);
                                }
                            }
                        }
                        if (suplierPayUpdateWork.SupplierCd9 != 0)
                        {
                            suplierPayWork = new SuplierPayWork();
                            suplierPayWork.EnterpriseCode = suplierPayUpdateWork.EnterpriseCode;
                            suplierPayWork.AddUpSecCode = suplierPayUpdateWork.AddUpSecCode;
                            suplierPayWork.SupplierCd = suplierPayUpdateWork.SupplierCd9;

                            status = GetIndivSupplier(ref suplierPayWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "仕入先が登録されておりません : " + suplierPayUpdateWork.SupplierCd9;
                                return status;
                            }
                            else
                            {
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (suplierPayUpdateWork.AddUpSecCode.Trim() != suplierPayWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と支払拠点が一致しません : " + suplierPayUpdateWork.SupplierCd1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (suplierPayUpdateWork.SupplierTotalDay != 0)
                                {
                                    if (suplierPayUpdateWork.SupplierTotalDay == 99)
                                    {
                                        if (suplierPayWork.SupplierTotalDay == 28 || suplierPayWork.SupplierTotalDay == 29 ||
                                            suplierPayWork.SupplierTotalDay == 30 || suplierPayWork.SupplierTotalDay == 31)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd9.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (suplierPayUpdateWork.SupplierTotalDay == suplierPayWork.SupplierTotalDay)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd9.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(suplierPayWork);
                                }
                            }
                        }
                        if (suplierPayUpdateWork.SupplierCd10 != 0)
                        {
                            suplierPayWork = new SuplierPayWork();
                            suplierPayWork.EnterpriseCode = suplierPayUpdateWork.EnterpriseCode;
                            suplierPayWork.AddUpSecCode = suplierPayUpdateWork.AddUpSecCode;
                            suplierPayWork.SupplierCd = suplierPayUpdateWork.SupplierCd10;

                            status = GetIndivSupplier(ref suplierPayWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "仕入先が登録されておりません : " + suplierPayUpdateWork.SupplierCd10;
                                return status;
                            }
                            else
                            {
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (suplierPayUpdateWork.AddUpSecCode.Trim() != suplierPayWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と支払拠点が一致しません : " + suplierPayUpdateWork.SupplierCd1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (suplierPayUpdateWork.SupplierTotalDay != 0)
                                {
                                    if (suplierPayUpdateWork.SupplierTotalDay == 99)
                                    {
                                        if (suplierPayWork.SupplierTotalDay == 28 || suplierPayWork.SupplierTotalDay == 29 ||
                                            suplierPayWork.SupplierTotalDay == 30 || suplierPayWork.SupplierTotalDay == 31)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd10.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (suplierPayUpdateWork.SupplierTotalDay == suplierPayWork.SupplierTotalDay)
                                        {
                                            deleteList.Add(suplierPayWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と仕入先締日が一致しません : " + suplierPayUpdateWork.SupplierCd10.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(suplierPayWork);
                                }
                            }
                        }
                        #endregion

                    }
                    //個別得意先除外
                    else if (suplierPayUpdateWork.UpdObjectFlag == 3)
                    {
                        #region [個別得意先除外] ※現在未使用
                        status = GetSupplier(ref suplierPayUpdateWork, ref deleteList, ref sqlConnection);

                        for (int i = 0; i < deleteList.Count; i++)
                        {
                            suplierPayWork = deleteList[i] as SuplierPayWork;
                            if (suplierPayWork.SupplierCd == suplierPayUpdateWork.SupplierCd1 ||
                                suplierPayWork.SupplierCd == suplierPayUpdateWork.SupplierCd2 ||
                                suplierPayWork.SupplierCd == suplierPayUpdateWork.SupplierCd3 ||
                                suplierPayWork.SupplierCd == suplierPayUpdateWork.SupplierCd4 ||
                                suplierPayWork.SupplierCd == suplierPayUpdateWork.SupplierCd5 ||
                                suplierPayWork.SupplierCd == suplierPayUpdateWork.SupplierCd6 ||
                                suplierPayWork.SupplierCd == suplierPayUpdateWork.SupplierCd7 ||
                                suplierPayWork.SupplierCd == suplierPayUpdateWork.SupplierCd8 ||
                                suplierPayWork.SupplierCd == suplierPayUpdateWork.SupplierCd9 ||
                                suplierPayWork.SupplierCd == suplierPayUpdateWork.SupplierCd10)
                            {
                                //未更新ステータスにする
                                suplierPayWork.UpdateStatus = 1;
                            }
                        }
                        #endregion
                    }
                // ↓ 2008.01.10 980081 a
                }
                suplierPayUpdateWork.AddUpSecCode = addUpSecCode;
                // ↑ 2008.01.10 980081 a



                //●支払締更新履歴マスタチェック
                //※レコード存在有無チェックする
                //※得意先Listと削除得意先Listの数を比較する
                int customerCount = 0;
                int notUpdateCount = 0;
                for (int i = 0; i < deleteList.Count; i++)
                {
                    suplierPayWork = deleteList[i] as SuplierPayWork;
                    status = CheckCAddUpUpdDate(ref suplierPayWork, ref sqlConnection);
                    if (suplierPayWork.UpdateStatus == 1)
                    {
                        notUpdateCount += 1;
                    }
                    customerCount += 1;
                }

                if (notUpdateCount == customerCount)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                    //constをリターン(後日)
                    retMsg = "取消を行う仕入先が存在しません。";
                    return status;
                }
                
                //トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // 2008.07.24 upd start --------------------------------------------->>
                ////●支払締更新履歴マスタ削除
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    if (suplierPayUpdateWork.ProcCntntsFlag == 2)
                //        status = DeletePaymentAddUpHisProc(deleteList, ref sqlConnection, ref sqlTransaction);
                //}
                //●支払締更新履歴マスタ更新
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (suplierPayUpdateWork.ProcCntntsFlag == 2)
                        status = UpdatePaymentAddUpHisProc(deleteList, ref sqlConnection, ref sqlTransaction);
                }
                // 2008.07.24 upd end -----------------------------------------------<<

                //●支払金額マスタ削除
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    status = DeleteSuplierPayProc(deleteList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    sqlTransaction.Commit();
                else
                {
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                */
                    #endregion

                    //トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    ShareCheckInfo info = new ShareCheckInfo();

                    #region 排他制御
                    if (suplierPayUpdateWork.AddUpSecCode == "00" || suplierPayUpdateWork.AddUpSecCode == "")
                    {
                        //システムロック(企業)
                        info.Keys.Add(suplierPayUpdateWork.EnterpriseCode, ShareCheckType.Enterprise, "", "");
                        status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    }
                    else
                    {
                        //システムロック(拠点) //2009/1/27 Add sakurai
                        info.Keys.Add(suplierPayUpdateWork.EnterpriseCode, ShareCheckType.Section, suplierPayUpdateWork.AddUpSecCode, "");
                        status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    }
                    if (status != 0)
                    {
                        return status = 851;
                    }
                    #endregion

                    //●支払締更新履歴マスタ更新
                    status = UpdatePaymentAddUpHisProc(suplierPayUpdateWork, ref sqlConnection, ref sqlTransaction);


                    //●精算支払集計データ削除
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = DeleteAccPayTotalProc(suplierPayUpdateWork, ref sqlConnection, ref sqlTransaction);
                    }

                    //●支払金額マスタ削除
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = DeleteSuplierPayProc(suplierPayUpdateWork, ref sqlConnection, ref sqlTransaction);
                    }

                    //システムロック解除 //2009/1/27 Add sakurai
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        sqlTransaction.Commit();
                    else
                    {
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }
                // 修正 2008.12.17 <<<

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuplierPayDB.Delete");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
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

        #region [DeletePaymentAddUpHisProc 2008.10.01 DEL]
        /* --- DEL 2008.10.01 ---------->>>>>
        /// <summary>
        /// 締取消を行います(支払締更新履歴マスタ削除)
        /// </summary>
        /// <param name="deleteList">suplierPayWorkParamWork削除List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 締取消を行います(支払締更新履歴マスタ削除)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        private int DeletePaymentAddUpHisProc(ArrayList deleteList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                for (int i = 0; i < deleteList.Count; i++)
                {
                    SuplierPayWork suplierPayWork = deleteList[i] as SuplierPayWork;
                    if (suplierPayWork.UpdateStatus == 1) continue;

                    using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM PAYMENTADDUPHISRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND CADDUPUPDDATERF=@FINDADDUPDATE", sqlConnection, sqlTransaction))
                    {
                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                        // ↓ 2007.09.14 980081 c
                        //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.CustomerCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                        // ↑ 2007.09.14 980081 c
                        findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);
                        findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayWork.AddUpDate);

                        sqlCommand.ExecuteNonQuery();

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }
           --- DEL 2008.10.01 ----------<<<<< */
        #endregion

        // 2008.07.24 add start ----------------------------------------->>
        /// <summary>
        /// 締取消を行います(支払締更新履歴マスタを更新)
        /// </summary>
        /// <param name="suplierPayUpdateWork">suplierPayWorkParamWork更新List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 締取消を行います(支払締更新履歴マスタを更新)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.07.18</br>
        private int UpdatePaymentAddUpHisProc(SuplierPayUpdateWork suplierPayUpdateWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string sqlText = string.Empty;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            //検索結果格納用
            PaymentAddUpHisWork _paymentAddUpHisWork = new PaymentAddUpHisWork();
            ArrayList _paymentAddUpHisWorkList = new ArrayList();

            //親レコード情報検索 -> 締取消レコードのセット情報に使用
            #region [親レコード情報検索]
            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                #region [Select文作成]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  *" + Environment.NewLine;
                sqlText += " FROM PAYMENTADDUPHISRF" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                // 修正 2009.04.02 全拠点対応 >>>
                if (suplierPayUpdateWork.AddUpSecCode != "00" && suplierPayUpdateWork.AddUpSecCode != "")
                {
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                }
                // 修正 2009.04.02 <<<
                sqlText += "  AND CADDUPUPDDATERF=@FINDCADDUPUPDDATE" + Environment.NewLine;
                sqlText += "  AND PROCDIVCDRF=0" + Environment.NewLine;
                sqlText += "  AND HISTCTLCDRF=0" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                #endregion  //[Select文作成]

                sqlCommand.Parameters.Clear();

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDCADDUPUPDDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayUpdateWork.EnterpriseCode);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayUpdateWork.AddUpDate);

                // 修正 2009.04.02 全社締対応 >>>
                if (suplierPayUpdateWork.AddUpSecCode != "00" && suplierPayUpdateWork.AddUpSecCode != "")
                {
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayUpdateWork.AddUpSecCode);
                }
                // 修正 2009.04.02 <<<

                myReader = sqlCommand.ExecuteReader();

                // 修正 2009.04.02 全拠点締対応 >>>
                //if (myReader.Read())
                //{
                //    _paymentAddUpHisWork = CopyToPaymentAddUpHisWorkFromReader(ref myReader);
                //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //}
                //else
                //{
                //    throw new Exception("取消対象の親レコードがありません。");
                //}
                while (myReader.Read())
                {
                    _paymentAddUpHisWorkList.Add(CopyToPaymentAddUpHisWorkFromReader(ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (_paymentAddUpHisWorkList == null || _paymentAddUpHisWorkList.Count == 0)
                {
                    throw new Exception("取消対象の親レコードがありません。");
                }
                // 修正 2009.04.02 <<<

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            #endregion  //[親レコード情報検索]

            if (!myReader.IsClosed) myReader.Close();
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) throw new Exception("支払締更新履歴マスタ読込失敗。");
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //締取消レコードINSERT -> 検索した親レコードの情報を使用して取消レコードをINSERT
            #region [締取消レコードINSERT]
            try
            {
                for (int i = 0; i < _paymentAddUpHisWorkList.Count; i++)
                {
                    _paymentAddUpHisWork = _paymentAddUpHisWorkList[i] as PaymentAddUpHisWork;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    #region [Insert文作成]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO PAYMENTADDUPHISRF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,STARTCADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += " ,CADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += " ,CADDUPUPDYEARMONTHRF" + Environment.NewLine;
                    sqlText += " ,CADDUPUPDEXECDATERF" + Environment.NewLine;
                    sqlText += " ,LASTCADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += " ,DATAUPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,PROCDIVCDRF" + Environment.NewLine;
                    sqlText += " ,ERRORSTATUSRF" + Environment.NewLine;
                    sqlText += " ,HISTCTLCDRF" + Environment.NewLine;
                    sqlText += " ,PROCRESULTRF" + Environment.NewLine;
                    sqlText += " ,CONVERTPROCESSDIVCDRF" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;
                    sqlText += " VALUES" + Environment.NewLine;
                    sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@ADDUPSECCODE" + Environment.NewLine;
                    sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                    sqlText += " ,@STARTCADDUPUPDDATE" + Environment.NewLine;
                    sqlText += " ,@CADDUPUPDDATE" + Environment.NewLine;
                    sqlText += " ,@CADDUPUPDYEARMONTH" + Environment.NewLine;
                    sqlText += " ,@CADDUPUPDEXECDATE" + Environment.NewLine;
                    sqlText += " ,@LASTCADDUPUPDDATE" + Environment.NewLine;
                    sqlText += " ,@DATAUPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@PROCDIVCD" + Environment.NewLine;
                    sqlText += " ,@ERRORSTATUS" + Environment.NewLine;
                    sqlText += " ,@HISTCTLCD" + Environment.NewLine;
                    sqlText += " ,@PROCRESULT" + Environment.NewLine;
                    sqlText += " ,@CONVERTPROCESSDIVCD" + Environment.NewLine;
                    sqlText += " )" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Insert文作成]

                    sqlCommand.Parameters.Clear();

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)_paymentAddUpHisWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    #region Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraStartCAddUpUpdDate = sqlCommand.Parameters.Add("@STARTCADDUPUPDDATE", SqlDbType.Int);
                    SqlParameter paraCAddUpUpdDate = sqlCommand.Parameters.Add("@CADDUPUPDDATE", SqlDbType.Int);
                    SqlParameter paraCAddUpUpdYearMonth = sqlCommand.Parameters.Add("@CADDUPUPDYEARMONTH", SqlDbType.Int);
                    SqlParameter paraCAddUpUpdExecDate = sqlCommand.Parameters.Add("@CADDUPUPDEXECDATE", SqlDbType.Int);
                    SqlParameter paraLastCAddUpUpdDate = sqlCommand.Parameters.Add("@LASTCADDUPUPDDATE", SqlDbType.Int);
                    SqlParameter paraDataUpdateDateTime = sqlCommand.Parameters.Add("@DATAUPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraProcDivCd = sqlCommand.Parameters.Add("@PROCDIVCD", SqlDbType.Int);
                    SqlParameter paraErrorStatus = sqlCommand.Parameters.Add("@ERRORSTATUS", SqlDbType.Int);
                    SqlParameter paraHistCtlCd = sqlCommand.Parameters.Add("@HISTCTLCD", SqlDbType.Int);
                    SqlParameter paraProcResult = sqlCommand.Parameters.Add("@PROCRESULT", SqlDbType.NVarChar);
                    SqlParameter paraConvertProcessDivCd = sqlCommand.Parameters.Add("@CONVERTPROCESSDIVCD", SqlDbType.Int);
                    #endregion  //Prameterオブジェクトの作成

                    #region Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(_paymentAddUpHisWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(_paymentAddUpHisWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_paymentAddUpHisWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(_paymentAddUpHisWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(_paymentAddUpHisWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(_paymentAddUpHisWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(_paymentAddUpHisWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(_paymentAddUpHisWork.LogicalDeleteCode);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(_paymentAddUpHisWork.AddUpSecCode);
                    //paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(_paymentAddUpHisWork.SupplierCd); // DEL 2008.10.18
                    paraSupplierCd.Value = 0; // ADD 2008.10.18
                    paraStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_paymentAddUpHisWork.StartCAddUpUpdDate);
                    paraCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_paymentAddUpHisWork.CAddUpUpdDate);
                    paraCAddUpUpdYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_paymentAddUpHisWork.CAddUpUpdYearMonth);
                    paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_paymentAddUpHisWork.CAddUpUpdExecDate);
                    paraLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_paymentAddUpHisWork.LastCAddUpUpdDate);
                    paraDataUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(_paymentAddUpHisWork.CreateDateTime);
                    paraErrorStatus.Value = SqlDataMediator.SqlSetInt32(_paymentAddUpHisWork.ErrorStatus);
                    paraProcResult.Value = SqlDataMediator.SqlSetString(_paymentAddUpHisWork.ProcResult);
                    paraConvertProcessDivCd.Value = SqlDataMediator.SqlSetInt32(_paymentAddUpHisWork.ConvertProcessDivCd);
                    paraProcDivCd.Value = 1;
                    paraHistCtlCd.Value = 1;
                    paraProcResult.Value = "正常終了";
                    #endregion  //Parameterオブジェクトへ値設定

                    sqlCommand.ExecuteNonQuery();

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            #endregion  //[締取消レコードINSERT]

            if (!myReader.IsClosed) myReader.Close();
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) throw new Exception("締取消レコードINSERT失敗。");
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //親レコードUPDATE -> 履歴制御区分を「1:未確定」に更新する
            #region [親レコードUPDATE]
            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                #region [Update文作成]
                sqlText = string.Empty;
                sqlText += "UPDATE " + Environment.NewLine;
                sqlText += "   PAYMENTADDUPHISRF " + Environment.NewLine;
                sqlText += " SET " + Environment.NewLine;
                sqlText += "  HISTCTLCDRF=1" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

                // 修正 2009.04.02 全拠点締対応 >>>
                if (suplierPayUpdateWork.AddUpSecCode != "00" && suplierPayUpdateWork.AddUpSecCode != "")
                {
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                }
                // 修正 2009.04.02 <<<

                sqlText += "  AND CADDUPUPDDATERF=@FINDCADDUPUPDDATE" + Environment.NewLine;
                sqlText += "  AND PROCDIVCDRF=0" + Environment.NewLine;
                sqlText += "  AND HISTCTLCDRF=0" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                #endregion  //[Update文作成]

                sqlCommand.Parameters.Clear();

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDCADDUPUPDDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayUpdateWork.EnterpriseCode);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayUpdateWork.AddUpDate);

                // 修正 2009.04.02 全拠点締対応 >>>
                if (suplierPayUpdateWork.AddUpSecCode != "00" && suplierPayUpdateWork.AddUpSecCode != "")
                {
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayUpdateWork.AddUpSecCode);
                }
                // 修正 2009.04.02 全拠点締対応 <<<

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            #endregion  //[親レコードUPDATE]

            return status;
        }
        // 2008.07.24 add end -------------------------------------------<<
        // ADD 2008.12.17 >>>
        /// <summary>
        /// 締取消を行います(仕入先支払金額マスタ削除)
        /// </summary>
        /// <param name="suplierPayUpdateWork">suplierPayWorkParamWork削除List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 締取消を行います(仕入先支払金額マスタ削除)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        private int DeleteAccPayTotalProc(SuplierPayUpdateWork suplierPayUpdateWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                string sqltext = string.Empty;
                sqltext += "DELETE" + Environment.NewLine;
                sqltext += " FROM ACCPAYTOTALRF" + Environment.NewLine;
                sqltext += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqltext += "        AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                // 修正 2009.04.02 全拠点締対応 >>>
                if (suplierPayUpdateWork.AddUpSecCode != "00" && suplierPayUpdateWork.AddUpSecCode != "")
                {
                    sqltext += "        AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                }
                // 修正 2009.04.02 <<<

                using (SqlCommand sqlCommand = new SqlCommand(sqltext, sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayUpdateWork.EnterpriseCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayUpdateWork.AddUpDate);

                    // 修正 2009.04.02 全拠点締対応 >>>
                    if (suplierPayUpdateWork.AddUpSecCode != "00" && suplierPayUpdateWork.AddUpSecCode != "")
                    {
                        SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                        findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayUpdateWork.AddUpSecCode);
                    }
                    // 修正 2009.04.02 <<<

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            return status;
        }
        // ADD 2008.12.17 <<<

        /// <summary>
        /// 締取消を行います(仕入先支払金額マスタ削除)
        /// </summary>
        /// <param name="suplierPayUpdateWork">suplierPayWorkParamWork削除List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 締取消を行います(仕入先支払金額マスタ削除)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        //private int DeleteSuplierPayProc(ArrayList deleteList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int DeleteSuplierPayProc(SuplierPayUpdateWork suplierPayUpdateWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                string sqltext = string.Empty;
                sqltext += "DELETE" + Environment.NewLine;
                sqltext += " FROM SUPLIERPAYRF" + Environment.NewLine;
                sqltext += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqltext += "        AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;
                // 修正 2009.04.02 全拠点締対応 >>>
                if (suplierPayUpdateWork.AddUpSecCode != "00" && suplierPayUpdateWork.AddUpSecCode != "")
                {
                    sqltext += "        AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                }
                // 修正 2009.04.02 <<<

                using (SqlCommand sqlCommand = new SqlCommand(sqltext, sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayUpdateWork.EnterpriseCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(suplierPayUpdateWork.AddUpDate);

                    // 修正 2009.04.02 全拠点締対応 >>>
                    if (suplierPayUpdateWork.AddUpSecCode != "00" && suplierPayUpdateWork.AddUpSecCode != "")
                    {
                        SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                        findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayUpdateWork.AddUpSecCode);
                    }
                    // 修正 2009.04.02 <<<

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }

        /// <summary>
        /// 締次更新年月日をチェックします
        /// </summary>
        /// <param name="suplierPayWork">仕入先支払金額マスタ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 締次更新年月日をチェックします</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        private int CheckCAddUpUpdDate(ref SuplierPayWork suplierPayWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            string sqlText = string.Empty;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;

                    #region [2008.10.01 DEL]
                    /* --- DEL 2008.10.01 ---------->>>>>
                    // 2008.07.24 upd start ------------------------------------->>
                    //sqlCommand.CommandText = "SELECT MAX(CADDUPUPDDATERF) AS MAXCADDUPUPDDATE FROM PAYMENTADDUPHISRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ADDUPSECCODERF=@FINDADDUPSECCODE ";
                    sqlText += "SELECT MAX" + Environment.NewLine;
                    sqlText += "    (CADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += "    ) AS MAXCADDUPUPDDATE" + Environment.NewLine;
                    sqlText += " FROM PAYMENTADDUPHISRF WITH" + Environment.NewLine;
                    sqlText += "    (READUNCOMMITTED" + Environment.NewLine;
                    sqlText += "    )" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                    sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    // 2008.07.24 upd end ---------------------------------------<<

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    // ↓ 2007.09.14 980081 c
                    //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.CustomerCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);
                    // ↑ 2007.09.14 980081 c
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode);
                       --- DEL 2008.10.01 ----------<<<<< */
                    #endregion

                    // --- ADD 2008.10.01 ---------->>>>>
                    #region [Select文作成]
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  MAX(CADDUPUPDDATERF) AS MAXCADDUPUPDDATE" + Environment.NewLine;
                    sqlText += " FROM PAYMENTADDUPHISRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    //sqlText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;  // DEL 2008.10.18 
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;  
                    sqlText += "  AND PROCDIVCDRF=0" + Environment.NewLine;
                    sqlText += "  AND HISTCTLCDRF=0" + Environment.NewLine;
                    
                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Select文作成]

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int); // DEL 2008.10.18
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar); 

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.EnterpriseCode);
                    //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(suplierPayWork.PayeeCode);  // DEL 2008.10.18
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(suplierPayWork.AddUpSecCode); 
                    // --- ADD 2008.10.01 ----------<<<<<

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //検索結果を戻す
                        suplierPayWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MAXCADDUPUPDDATE"));

                        if (suplierPayWork.AddUpDate == DateTime.MinValue)
                        {
                            suplierPayWork.UpdateStatus = 1;
                        }
                        else
                        {
                            if (suplierPayWork.UpdateStatus != 1)
                                suplierPayWork.UpdateStatus = 0;
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        //検索結果がない場合は初期データなので最小値を挿入
                        suplierPayWork.UpdateStatus = 1;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }
        #endregion

        #region [etc]
        /// <summary>
        /// 仕入先マスタ　クラス格納処理 Reader → CustomerWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustomerWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private SupplierWork CopyToSupplierWorkFromReader(ref SqlDataReader myReader)
        {
            SupplierWork wkSupplierWork = new SupplierWork();

            #region クラスへ格納
            wkSupplierWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkSupplierWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkSupplierWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
            wkSupplierWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONCODERF"));
            wkSupplierWork.PaymentSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTSECTIONCODERF"));
            wkSupplierWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            wkSupplierWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            wkSupplierWork.SuppHonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPHONORIFICTITLERF"));
            wkSupplierWork.SupplierKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERKANARF"));
            wkSupplierWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkSupplierWork.OrderHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERHONORIFICTTLRF"));
            wkSupplierWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            wkSupplierWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            wkSupplierWork.SupplierPostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERPOSTNORF"));
            wkSupplierWork.SupplierAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR1RF"));
            wkSupplierWork.SupplierAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR3RF"));
            wkSupplierWork.SupplierAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR4RF"));
            wkSupplierWork.SupplierTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNORF"));
            wkSupplierWork.SupplierTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNO1RF"));
            wkSupplierWork.SupplierTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNO2RF"));
            wkSupplierWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
            wkSupplierWork.PaymentMonthCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONTHCODERF"));
            wkSupplierWork.PaymentMonthName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONTHNAMERF"));
            wkSupplierWork.PaymentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF"));
            wkSupplierWork.SuppCTaxLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYREFCDRF"));
            wkSupplierWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            wkSupplierWork.SuppCTaxationCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXATIONCDRF"));
            wkSupplierWork.SuppEnterpriseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPENTERPRISECDRF"));
            wkSupplierWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkSupplierWork.SupplierAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERATTRIBUTEDIVRF"));
            wkSupplierWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
            wkSupplierWork.StckTtlAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCKTTLAMNTDSPWAYREFRF"));
            wkSupplierWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));
            wkSupplierWork.PaymentTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTTOTALDAYRF"));
            wkSupplierWork.PaymentSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSIGHTRF"));
            wkSupplierWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            wkSupplierWork.StockUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNPRCFRCPROCCDRF"));
            wkSupplierWork.StockMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMONEYFRCPROCCDRF"));
            wkSupplierWork.StockCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKCNSTAXFRCPROCCDRF"));
            wkSupplierWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NTIMECALCSTDATERF"));
            wkSupplierWork.SupplierNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE1RF"));
            wkSupplierWork.SupplierNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE2RF"));
            wkSupplierWork.SupplierNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE3RF"));
            wkSupplierWork.SupplierNote4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE4RF"));
            #endregion

            return wkSupplierWork;
        }

        /// <summary>
        /// 支払締更新履歴マスタ　クラス格納処理 Reader → PaymentAddUpHisWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PaymentAddUpHisWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private PaymentAddUpHisWork CopyToPaymentAddUpHisWorkFromReader(ref SqlDataReader myReader)
        {
            PaymentAddUpHisWork wkPaymentAddUpHisWork = new PaymentAddUpHisWork();

            #region [2008.10.01 DEL]
            /* --- DEL 2008.10.01 ---------->>>>>
            #region クラスへ格納
            wkPaymentAddUpHisWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkPaymentAddUpHisWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkPaymentAddUpHisWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkPaymentAddUpHisWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkPaymentAddUpHisWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkPaymentAddUpHisWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkPaymentAddUpHisWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkPaymentAddUpHisWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkPaymentAddUpHisWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkPaymentAddUpHisWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkPaymentAddUpHisWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STARTCADDUPUPDDATERF"));
            wkPaymentAddUpHisWork.CAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDDATERF"));
            wkPaymentAddUpHisWork.CAddUpUpdYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("CADDUPUPDYEARMONTHRF"));
            wkPaymentAddUpHisWork.CAddUpUpdExecDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDEXECDATERF"));
            wkPaymentAddUpHisWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTCADDUPUPDDATERF"));
            #endregion
               --- DEL 2008.10.01 ----------<<<<< */
            #endregion

            // --- ADD 2008.10.01 ---------->>>>>
            #region クラスへ格納
            wkPaymentAddUpHisWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkPaymentAddUpHisWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkPaymentAddUpHisWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkPaymentAddUpHisWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkPaymentAddUpHisWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkPaymentAddUpHisWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkPaymentAddUpHisWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkPaymentAddUpHisWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkPaymentAddUpHisWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkPaymentAddUpHisWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkPaymentAddUpHisWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STARTCADDUPUPDDATERF"));
            wkPaymentAddUpHisWork.CAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDDATERF"));
            wkPaymentAddUpHisWork.CAddUpUpdYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("CADDUPUPDYEARMONTHRF"));
            wkPaymentAddUpHisWork.CAddUpUpdExecDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDEXECDATERF"));
            wkPaymentAddUpHisWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTCADDUPUPDDATERF"));
            wkPaymentAddUpHisWork.DataUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("DATAUPDATEDATETIMERF"));
            wkPaymentAddUpHisWork.ProcDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROCDIVCDRF"));
            wkPaymentAddUpHisWork.ErrorStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERRORSTATUSRF"));
            wkPaymentAddUpHisWork.HistCtlCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HISTCTLCDRF"));
            wkPaymentAddUpHisWork.ProcResult = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROCRESULTRF"));
            wkPaymentAddUpHisWork.ConvertProcessDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONVERTPROCESSDIVCDRF"));
            #endregion
            // --- ADD 2008.10.01 ----------<<<<<

            return wkPaymentAddUpHisWork;
        }

        /// <summary>
        /// 支払伝票マスタ　クラス格納処理 Reader → PaymentSlpWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PaymentSlpWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private PaymentSlpWork CopyToPaymentSlpWorkFromReader(ref SqlDataReader myReader)
        {
            PaymentSlpWork wkPaymentSlpWork = new PaymentSlpWork();

            #region クラスへ格納
            wkPaymentSlpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkPaymentSlpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkPaymentSlpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkPaymentSlpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkPaymentSlpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkPaymentSlpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkPaymentSlpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkPaymentSlpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkPaymentSlpWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            wkPaymentSlpWork.PaymentSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
            wkPaymentSlpWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            wkPaymentSlpWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkPaymentSlpWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            wkPaymentSlpWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            wkPaymentSlpWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            wkPaymentSlpWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkPaymentSlpWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
            wkPaymentSlpWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
            wkPaymentSlpWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            wkPaymentSlpWork.PaymentInpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPSECTIONCDRF"));
            wkPaymentSlpWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkPaymentSlpWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
            wkPaymentSlpWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            wkPaymentSlpWork.PaymentDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
            wkPaymentSlpWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            wkPaymentSlpWork.PaymentTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
            wkPaymentSlpWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
            wkPaymentSlpWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
            wkPaymentSlpWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
            wkPaymentSlpWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
            wkPaymentSlpWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
            wkPaymentSlpWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
            wkPaymentSlpWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
            wkPaymentSlpWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
            wkPaymentSlpWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
            wkPaymentSlpWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
            wkPaymentSlpWork.DebitNoteLinkPayNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKPAYNORF"));
            wkPaymentSlpWork.PaymentAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTCODERF"));
            wkPaymentSlpWork.PaymentAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
            wkPaymentSlpWork.PaymentInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTCDRF"));
            wkPaymentSlpWork.PaymentInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTINPUTAGENTNMRF"));
            wkPaymentSlpWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
            wkPaymentSlpWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
            wkPaymentSlpWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
            #endregion

            return wkPaymentSlpWork;
        }

        // 2008.07.24 add start ---------------------------------------------->>
        /// <summary>
        /// 精算支払集計データ クラス格納処理 Reader → AccPayTotalWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AccPayTotalWork</returns>
        /// <remarks>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.07.24</br>
        /// </remarks>
        private AccPayTotalWork CopyToAccPayTotalWorkFromReader(ref SqlDataReader myReader)
        {
            AccPayTotalWork wkAccPayTotalWork = new AccPayTotalWork();

            #region [2008.10.01 DEL]
            /* --- DEL 2008.10.01 ---------->>>>>
            #region クラスへ格納
            wkAccPayTotalWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkAccPayTotalWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkAccPayTotalWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkAccPayTotalWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkAccPayTotalWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkAccPayTotalWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkAccPayTotalWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkAccPayTotalWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkAccPayTotalWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkAccPayTotalWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkAccPayTotalWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkAccPayTotalWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkAccPayTotalWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            wkAccPayTotalWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            wkAccPayTotalWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            wkAccPayTotalWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENT"));
            #endregion
               --- DEL 2008.10.01 ----------<<<<< */
            #endregion

            // --- ADD 2008.10.01 ---------->>>>>
            #region クラスへ格納

            // 修正 2008.12.17 >>>

            #region 2008.12.17 DEL
            /*
            wkAccPayTotalWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkAccPayTotalWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkAccPayTotalWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkAccPayTotalWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkAccPayTotalWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkAccPayTotalWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkAccPayTotalWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkAccPayTotalWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkAccPayTotalWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkAccPayTotalWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkAccPayTotalWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkAccPayTotalWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            wkAccPayTotalWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            wkAccPayTotalWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            wkAccPayTotalWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            wkAccPayTotalWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));
            */
            #endregion

            wkAccPayTotalWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkAccPayTotalWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkAccPayTotalWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            wkAccPayTotalWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            wkAccPayTotalWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            wkAccPayTotalWork.Payment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTRF"));

            // 修正 2008.12.17 <<<

            #endregion
            // --- ADD 2008.10.01 ----------<<<<<

            return wkAccPayTotalWork;
        }
        // 2008.07.24 add end -----------------------------------------------<<

        /// <summary>
        /// 仕入データ　クラス格納処理 Reader → StockSlipWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockSlipWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private StockSlipWork CopyToStockSlipWorkFromReader(ref SqlDataReader myReader)
        {
            StockSlipWork wkStockSlipWork = new StockSlipWork();

            #region クラスへ格納
            wkStockSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockSlipWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            wkStockSlipWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            wkStockSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockSlipWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            //wkStockSlipWork.MinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINSECTIONCODERF"));
            wkStockSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            wkStockSlipWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
            wkStockSlipWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            wkStockSlipWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            wkStockSlipWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
            //wkStockSlipWork.TrustAddUpSpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TRUSTADDUPSPCDRF"));
            wkStockSlipWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            wkStockSlipWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
            wkStockSlipWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            wkStockSlipWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            wkStockSlipWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            wkStockSlipWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            wkStockSlipWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
            wkStockSlipWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkStockSlipWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            wkStockSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            wkStockSlipWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            wkStockSlipWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            wkStockSlipWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            //wkStockSlipWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
            wkStockSlipWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            wkStockSlipWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
            wkStockSlipWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            wkStockSlipWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
            wkStockSlipWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            wkStockSlipWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            wkStockSlipWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            wkStockSlipWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            wkStockSlipWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
            wkStockSlipWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
            wkStockSlipWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            wkStockSlipWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            wkStockSlipWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
            wkStockSlipWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
            wkStockSlipWork.StockNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKNETPRICERF"));
            wkStockSlipWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            wkStockSlipWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));
            wkStockSlipWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));
            wkStockSlipWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
            wkStockSlipWork.StockOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAXRF"));
            wkStockSlipWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));
            wkStockSlipWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));
            wkStockSlipWork.ItdedStockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISOUTTAXRF"));
            wkStockSlipWork.ItdedStockDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISINTAXRF"));
            wkStockSlipWork.ItdedStockDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISTAXFRERF"));
            wkStockSlipWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));
            wkStockSlipWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
            wkStockSlipWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            wkStockSlipWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            wkStockSlipWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            wkStockSlipWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
            wkStockSlipWork.AccPayConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCPAYCONSTAXRF"));
            wkStockSlipWork.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKFRACTIONPROCCDRF"));
            wkStockSlipWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
            wkStockSlipWork.AutoPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYSLIPNUMRF"));
            #endregion

            return wkStockSlipWork;
        }

        /// <summary>
        /// 仕入在庫全体設定マスタ　クラス格納処理 Reader → StockTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.23</br>
        /// </remarks>
        private StockTtlStWork CopyToStockTtlStWorkFromReader(ref SqlDataReader myReader)
        {
            StockTtlStWork wkStockTtlStWork = new StockTtlStWork();

            #region クラスへ格納
            wkStockTtlStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockTtlStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockTtlStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockTtlStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockTtlStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockTtlStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockTtlStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            // 2008.07.24 del start -------------------------------------------->>
            //wkStockTtlStWork.StockAllStMngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKALLSTMNGCDRF"));
            //wkStockTtlStWork.ValidDtConsTaxRate1 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDDTCONSTAXRATE1RF"));
            //wkStockTtlStWork.ConsTaxRate1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATE1RF"));
            //wkStockTtlStWork.ValidDtConsTaxRate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDDTCONSTAXRATE2RF"));
            //wkStockTtlStWork.ConsTaxRate2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATE2RF"));
            //wkStockTtlStWork.ValidDtConsTaxRate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDDTCONSTAXRATE3RF"));
            //wkStockTtlStWork.ConsTaxRate3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATE3RF"));
            // 2008.07.24 del end ----------------------------------------------<<
            // ↓ 2007.09.14 980081 d
            //wkStockTtlStWork.ConsTaxFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXFRACPROCDIVRF"));
            // ↑ 2007.09.14 980081 d
            //wkStockTtlStWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF")); // 2008.07.24 del
            wkStockTtlStWork.StockDiscountName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDISCOUNTNAMERF"));
            //wkStockTtlStWork.PartsUnitPrcZeroCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSUNITPRCZEROCDRF")); // 2008.07.24 del
            // ↓ 2007.09.14 980081 d
            //wkStockTtlStWork.StockFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKFRACPROCDIVRF"));
            //wkStockTtlStWork.StcCstFracProcDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCCSTFRACPROCDIVRF"));
            //wkStockTtlStWork.StockRateUseDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKRATEUSEDIVCDRF"));
            //wkStockTtlStWork.StcCstRateUseDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCCSTRATEUSEDIVCDRF"));
            // ↑ 2007.09.14 980081 d
            #endregion

            return wkStockTtlStWork;
        }

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
        
        #region [ReadHis 最終支払締履歴取得]
        /// <summary>
        /// 最終支払締履歴取得処理
        /// </summary>
        /// <param name="paraObj">支払締履歴更新マスタReadパラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 最終支払締履歴取得処理</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        public int ReadHis(ref object paraObj, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            retMsg = null;

            PaymentAddUpHisWork paymentAddUpHisWork = null;

            try
            {
                paymentAddUpHisWork = paraObj as PaymentAddUpHisWork;

                if (paymentAddUpHisWork.EnterpriseCode == "" || paymentAddUpHisWork.AddUpSecCode == "" ||
                    paymentAddUpHisWork.SupplierCd == 0)
                {
                    retMsg = "条件が整っておりません。\r\n再度入力項目を入れなおしてください。";
                    return status;
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadHisProc(ref paymentAddUpHisWork, ref sqlConnection);

                paraObj = (object)paymentAddUpHisWork;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuplierPayDB.ReadHis");
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
        /// 最終支払締履歴取得処理
        /// </summary>
        /// <param name="paymentAddUpHisWork">支払締履歴更新マスタReadパラメータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 最終支払締履歴取得処理</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.16</br>
        private int ReadHisProc(ref PaymentAddUpHisWork paymentAddUpHisWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                // --- ADD 2008.10.01 ---------->>>>>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM PAYMENTADDUPHISRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND CADDUPUPDDATERF=(SELECT MAX(CADDUPUPDDATERF) FROM PAYMENTADDUPHISRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ADDUPSECCODERF=@FINDADDUPSECCODE)", sqlConnection))
                using (SqlCommand sqlCommand = new SqlCommand())
                // --- ADD 2008.10.01 ----------<<<<<
                {
                    #region [2008.10.01 DEL]
                    /* --- DEL 2008.10.01 ---------->>>>>
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(paymentAddUpHisWork.SupplierCd);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.AddUpSecCode);
                       --- DEL 2008.10.01 ----------<<<<< */
                    #endregion

                    // --- ADD 2008.10.01 ---------->>>>>
                    #region [Select文作成]
                    string sqlText = string.Empty;
                    sqlText += "SELECT *" + Environment.NewLine;
                    sqlText += " FROM PAYMENTADDUPHISRF" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    //sqlText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine; // DEL 2008.10.18 
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "  AND CADDUPUPDDATERF=" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    sqlText += "   SELECT MAX(CADDUPUPDDATERF)" + Environment.NewLine;
                    sqlText += "   FROM PAYMENTADDUPHISRF" + Environment.NewLine;
                    sqlText += "   WHERE" + Environment.NewLine;
                    sqlText += "        ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    //sqlText += "    AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine; // DEL 2008.10.18
                    sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "    AND PROCDIVCDRF=0" + Environment.NewLine;
                    sqlText += "    AND HISTCTLCDRF=0" + Environment.NewLine;
                    sqlText += "  )" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Select文作成]

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int); // DEL 2008.10.18
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.EnterpriseCode);
                    //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(paymentAddUpHisWork.SupplierCd); // DEL 2008.10.18
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.AddUpSecCode);
                    // --- ADD 2008.10.01 ----------<<<<<

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        paymentAddUpHisWork = CopyToPaymentAddUpHisWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 最終支払締履歴取得処理(SqlConnection付)
        /// </summary>
        /// <param name="paymentAddUpHisWork">支払締履歴更新マスタReadパラメータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        public int ReadHis(ref PaymentAddUpHisWork paymentAddUpHisWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadHisProcProc(ref paymentAddUpHisWork, ref sqlConnection);
            return status;

        }

        /// <summary>
        /// 最終支払締履歴取得処理(SqlConnection付)
        /// </summary>
        /// <param name="paymentAddUpHisWork">支払締履歴更新マスタReadパラメータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        private int ReadHisProcProc(ref PaymentAddUpHisWork paymentAddUpHisWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                // --- ADD 2008.10.01 ---------->>>>>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM PAYMENTADDUPHISRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND CADDUPUPDDATERF=(SELECT MAX(CADDUPUPDDATERF) FROM PAYMENTADDUPHISRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ADDUPSECCODERF=@FINDADDUPSECCODE) ", sqlConnection))
                using (SqlCommand sqlCommand = new SqlCommand())
                // --- ADD 2008.10.01 ----------<<<<<
                {
                    #region [2008.10.01 DEL]
                    /* --- DEL 2008.10.01 ---------->>>>>
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(paymentAddUpHisWork.SupplierCd);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.AddUpSecCode);
                       --- DEL 2008.10.01 ----------<<<<< */
                    #endregion

                    // --- ADD 2008.10.01 ---------->>>>>
                    #region [Select文作成]
                    string sqlText = string.Empty;
                    sqlText += "SELECT *" + Environment.NewLine;
                    sqlText += " FROM PAYMENTADDUPHISRF" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    //sqlText += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine; // DEL 2008.10.18
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "  AND CADDUPUPDDATERF=" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    sqlText += "    SELECT MAX(CADDUPUPDDATERF)" + Environment.NewLine;
                    sqlText += "    FROM PAYMENTADDUPHISRF" + Environment.NewLine;
                    sqlText += "    WHERE" + Environment.NewLine;
                    sqlText += "         ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    //sqlText += "    AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine; // DEL 2008.10.18
                    sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "    AND PROCDIVCDRF=0" + Environment.NewLine;
                    sqlText += "    AND HISTCTLCDRF=0" + Environment.NewLine;
                    sqlText += "  )" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Select文作成]

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int); // DEL 2008.10.18
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.EnterpriseCode);
                    //findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(paymentAddUpHisWork.SupplierCd); // DEL 2008.10.18
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(paymentAddUpHisWork.AddUpSecCode);
                    // --- ADD 2008.10.01 ----------<<<<<

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        paymentAddUpHisWork = CopyToPaymentAddUpHisWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }
        #endregion

        #region [ReadSuplierPay 支払処理結果を取得する]
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        /// <summary>
        /// 支払処理結果を取得する
        /// </summary>
        /// <param name="paraObj"></param>
        /// <param name="retMsg"></param>
        /// <returns></returns>
        public int ReadSuplierPay( ref object paraObj, out string retMsg )
        {
            object childObj = null;
            return ReadSuplierPay( ref paraObj, ref childObj, out retMsg );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
        /// <summary>
        /// 支払処理結果を取得する
        /// </summary>
        /// <param name="paraObj">仕入先支払金額マスタパラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払処理処理結果を取得する</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        //public int ReadSuplierPay(ref object paraObj, out string retMsg) // m.suzuki 2009/02/20
        public int ReadSuplierPay( ref object paraObj, ref object childObj,out string retMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retMsg = null;

            //●仕入先支払金額マスタ
            SuplierPayWork suplierPayWork = null;
            //●排他制御部品
            //ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;
            Int32[] customerCodeList = new Int32[1];

            try
            {
                suplierPayWork = paraObj as SuplierPayWork;

                if (suplierPayWork.EnterpriseCode == "" || suplierPayWork.AddUpSecCode == "" ||
                    suplierPayWork.SupplierCd == 0 || suplierPayWork.AddUpDate == DateTime.MinValue)
                {
                    retMsg = "条件が整っておりません。\r\n再度入力項目を入れなおしてください。";
                    return (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //●暗号化キーOPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SUPPLIERRF" });
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //ctrlExclsvOdAcs = new ControlExclusiveOrderAccess();

                customerCodeList[0] = new Int32();
                // ↓ 2007.09.14 980081 c
                //customerCodeList[0] = suplierPayWork.CustomerCode;
                customerCodeList[0] = suplierPayWork.PayeeCode;
                ArrayList suplierPayChildWorkList = new ArrayList();
                // ↑ 2007.09.14 980081 c

                ArrayList accPayTotalWorkList = new ArrayList();

                //status = ctrlExclsvOdAcs.LockDB(suplierPayWork.EnterpriseCode, customerCodeList, null);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //●仕入先マスタから取得
                    status = GetIndivSupplier(ref suplierPayWork, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        retMsg = "対象となる仕入先が存在しません。";
                        return status;
                    }


                    //●仕入金額処理区分設定マスタから端数処理区分を取得
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    if (suplierPayWork.UpdateStatus == 0)
                    //        status = GetSupplTaxAndFrac(ref suplierPayWork, ref sqlConnection);
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    //{
                    //    //仕入金額処理区分設定が設定されていない場合
                    //    suplierPayWork.FractionProcCd = 99;
                    //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    //}


                    //●前回支払情報取得
                    if (suplierPayWork.UpdateStatus == 0)
                        status = GetPaymentAddUpHisAndSuplierPay(ref suplierPayWork, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //初期データ挿入時はデータがないので前回締次更新年月日に最小値を挿入する
                        suplierPayWork.LastCAddUpUpdDate = DateTime.MinValue;
                        suplierPayWork.StartCAddUpUpdDate = DateTime.MinValue;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    // 2008.07.24 del start --------------------------------------------->>
                    //●得意先仕入情報マスタから下記項目を取得
                    //仕入先消費税転嫁方式コード・仕入先消費税税率・仕入先総額表示方法区分
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    if (suplierPayWork.UpdateStatus == 0)
                    //        status = GetCustSuppli(ref suplierPayWork, ref sqlConnection);
                    //}
                    // 2008.07.24 del end -----------------------------------------------<<

                    // DEL 2008.12.17  >>>
                    ////●仕入在庫全体設定マスタから端数処理区分・仕入先消費税税率・仕入先総額表示方法区分を取得
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    if (suplierPayWork.UpdateStatus == 0)
                    //    {
                    //        if (suplierPayWork.FractionProcCd == 99 || suplierPayWork.SupplierConsTaxRate == 99 ||
                    //            suplierPayWork.SuppTtlAmntDspWayCd == 99)
                    //            status = GetStockTtlSt(ref suplierPayWork, ref sqlConnection);
                    //    }
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                    //{
                    //    retMsg = "仕入日が税率有効日３より未来日付のため消費税率を算出できません。\r\n仕入在庫全体設定を見直してください。";
                    //    return status;
                    //}
                    //if (suplierPayWork.FractionProcCd == 99)
                    //{
                    //    retMsg = "仕入時の消費税端数処理区分が設定されておりません。\r\n仕入金額処理区分設定を見直してください。";
                    //    return status;
                    //}

                    //●支払伝票マスタ取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (suplierPayWork.UpdateStatus == 0)
                            status = GetPaymentSlp(ref suplierPayWork, ref sqlConnection);
                    }

                    // 2008.07.24 add start ------------------------------->>
                    //●支払明細データ＆支払マスタ取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (suplierPayWork.UpdateStatus == 0)
                            status = GetPaymentDtlMain(ref suplierPayWork, ref accPayTotalWorkList, ref sqlConnection);
                    }
                    // 2008.07.24 add end ---------------------------------<<


                    //●仕入データ取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if ( suplierPayWork.UpdateStatus == 0 )
                        {
                            // ↓ 2007.09.14 980081 c
                            //status = GetStockSlip(ref suplierPayWork, ref sqlConnection);
                            status = GetStockSlip( ref suplierPayWork, ref suplierPayChildWorkList, ref sqlConnection );
                            // ↑ 2007.09.14 980081 c
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                            CustomSerializeArrayList retChildList = new CustomSerializeArrayList();
                            foreach ( SuplierPayWork childWork in suplierPayChildWorkList )
                            {
                                retChildList.Add( childWork );
                            }
                            //retChildList.AddRange( suplierPayChildWorkList );
                            childObj = retChildList;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
                        }
                    }

                    // DEL 2008.12.17 >>>
                    #region [ ●金額計算処理 ]
                    /*
                    //●金額計算処理
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = CalculateSuplierPay(ref suplierPayWork);
                    }
                    */
                    #endregion
                    // DEL 2008.12.17 <<<
                }

                paraObj = (object)suplierPayWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuplierPayDB.ReadSuplierPay");
            }
            finally
            {
                //●暗号化キーCLOSE
                //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                //if (ctrlExclsvOdAcs != null) ctrlExclsvOdAcs.UnlockDB();
            }

            return status;
        }

        // --- ADD 2012/09/11 ----------->>>>>
        /// <summary>
        /// 仕入総括形式で支払処理結果を取得する
        /// </summary>
        /// <param name="paraObj">仕入先支払金額マスタパラメータ</param>
        /// <param name="childObj">仕入先支払金額マスタ親子レコード格納先</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入総括形式で支払処理結果を取得する</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : 2012/09/11</br>
        /// </remarks>
        public int ReadSuplierPayByAddUpSecCode(ref object paraObj, ref object childObj, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retMsg = null;

            //●仕入先支払金額マスタ
            SuplierPayWork suplierPayWork = null;
            //●排他制御部品
            Int32[] customerCodeList = new Int32[1];

            try
            {
                suplierPayWork = paraObj as SuplierPayWork;

                if (suplierPayWork.EnterpriseCode == "" || suplierPayWork.AddUpSecCode == "" ||
                    suplierPayWork.SupplierCd == 0 || suplierPayWork.AddUpDate == DateTime.MinValue)
                {
                    retMsg = "条件が整っておりません。\r\n再度入力項目を入れなおしてください。";
                    return (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();
                customerCodeList[0] = new Int32();
                customerCodeList[0] = suplierPayWork.PayeeCode;
                ArrayList suplierPayChildWorkList = new ArrayList();

                ArrayList accPayTotalWorkList = new ArrayList();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //●仕入先マスタから取得
                    status = GetIndivSupplierByAddUpSecCode(ref suplierPayWork, ref sqlConnection);

                    //●前回支払情報取得
                    if (suplierPayWork.UpdateStatus == 0)
                    {
                        status = this.GetPaymentAddUpHisAndSuplierPayByAddUpSecCode(ref suplierPayWork, ref sqlConnection);
                    }
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //初期データ挿入時はデータがないので前回締次更新年月日に最小値を挿入する
                        suplierPayWork.LastCAddUpUpdDate = DateTime.MinValue;
                        suplierPayWork.StartCAddUpUpdDate = DateTime.MinValue;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    //●支払伝票マスタ取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (suplierPayWork.UpdateStatus == 0)
                        {
                            status = GetPaymentSlpByAddUpSecCode(ref suplierPayWork, ref sqlConnection);
                        }
                    }

                    //●支払明細データ＆支払マスタ取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (suplierPayWork.UpdateStatus == 0)
                        {
                            status = GetPaymentDtlMainByAddUpSecCode(ref suplierPayWork, ref accPayTotalWorkList, ref sqlConnection);
                        }
                    }

                    //●仕入データ取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (suplierPayWork.UpdateStatus == 0)
                        {
                            status = GetStockSlipByAddUpSecCode(
                                ref suplierPayWork, ref suplierPayChildWorkList, ref sqlConnection);
                            CustomSerializeArrayList retChildList = new CustomSerializeArrayList();
                            foreach (SuplierPayWork childWork in suplierPayChildWorkList)
                            {
                                retChildList.Add(childWork);
                            }
                            childObj = retChildList;
                        }
                    }
                }

                paraObj = (object)suplierPayWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuplierPayDB.ReadSuplierPay");
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
        /// 仕入総括形式で支払処理結果を取得する
        /// </summary>
        /// <param name="paraObj">仕入先支払金額マスタパラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入総括形式で支払処理結果を取得する</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : 2012/09/11</br>
        /// </remarks>
        public int ReadSuplierPayByAddUpSecCode(ref object paraObj, out string retMsg)
        {
            object childObj = null;
            return ReadSuplierPayByAddUpSecCode(ref paraObj, ref childObj, out retMsg);
        }
        // --- ADD 2012/09/11 -----------<<<<<

        /// <summary>
        /// 支払処理結果を取得する(SqlConnection付)
        /// </summary>
        /// <param name="paraObj">仕入先支払金額マスタパラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払処理結果を取得する(SqlConnection付)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.16</br>
        /// </remarks>
        public int ReadSuplierPay(ref object paraObj, out string retMsg, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retMsg = null;
            //SqlEncryptInfo sqlEncryptInfo = null;

            //●仕入先支払金額マスタ
            SuplierPayWork suplierPayWork = null;
            //●排他制御部品
            //ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;
            Int32[] customerCodeList = new Int32[1];
            // ↓ 2007.09.14 980081 c
            ArrayList suplierPayChildWorkList = new ArrayList();
            // ↑ 2007.09.14 980081 c
            ArrayList accPayTotalWorkList = new ArrayList();

            try
            {
                suplierPayWork = paraObj as SuplierPayWork;

                if (suplierPayWork.EnterpriseCode == "" || suplierPayWork.AddUpSecCode == "" ||
                    suplierPayWork.SupplierCd == 0 || suplierPayWork.AddUpDate == DateTime.MinValue)
                {
                    retMsg = "条件が整っておりません。\r\n再度入力項目を入れなおしてください。";
                    return (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }

                //●暗号化キーOPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SUPPLIERRF" });
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //ctrlExclsvOdAcs = new ControlExclusiveOrderAccess();

                customerCodeList[0] = new Int32();
                // ↓ 2007.09.14 980081 c
                //customerCodeList[0] = suplierPayWork.CustomerCode;
                customerCodeList[0] = suplierPayWork.PayeeCode;
                // ↑ 2007.09.14 980081 c

                //status = ctrlExclsvOdAcs.LockDB(suplierPayWork.EnterpriseCode, customerCodeList, null);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    //●仕入先マスタから取得
                    status = GetIndivSupplier(ref suplierPayWork, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        retMsg = "対象となる仕入先が存在しません。";
                        return status;
                    }


                    ////●仕入金額処理区分設定マスタから端数処理区分を取得
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    if (suplierPayWork.UpdateStatus == 0)
                    //        status = GetSupplTaxAndFrac(ref suplierPayWork, ref sqlConnection);
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    //{
                    //    //仕入金額処理区分設定が設定されていない場合
                    //    suplierPayWork.FractionProcCd = 99;
                    //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    //}


                    //●前回支払情報取得
                    if (suplierPayWork.UpdateStatus == 0)
                        status = GetPaymentAddUpHisAndSuplierPay(ref suplierPayWork, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //初期データ挿入時はデータがないので前回締次更新年月日に最小値を挿入する
                        suplierPayWork.LastCAddUpUpdDate = DateTime.MinValue;
                        suplierPayWork.StartCAddUpUpdDate = DateTime.MinValue;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    //2008.07.24 del start ---------------------------------->> 
                    //●得意先仕入情報マスタから下記項目を取得
                    //仕入先消費税転嫁方式コード・仕入先消費税税率・仕入先総額表示方法区分
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    if (suplierPayWork.UpdateStatus == 0)
                    //        status = GetCustSuppli(ref suplierPayWork, ref sqlConnection);
                    //}
                    //2008.07.24 del end ------------------------------------<<

                    ////●仕入在庫全体設定マスタから端数処理区分・仕入先消費税税率・仕入先総額表示方法区分を取得
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    if (suplierPayWork.UpdateStatus == 0)
                    //    {
                    //        if (suplierPayWork.FractionProcCd == 99 || suplierPayWork.SupplierConsTaxRate == 99 ||
                    //            suplierPayWork.SuppTtlAmntDspWayCd == 99)
                    //            status = GetStockTtlSt(ref suplierPayWork, ref sqlConnection);
                    //    }
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                    //{
                    //    retMsg = "仕入日が税率有効日３より未来日付のため消費税率を算出できません。\r\n仕入在庫全体設定を見直してください。";
                    //    return status;
                    //}
                    //if (suplierPayWork.FractionProcCd == 99)
                    //{
                    //    retMsg = "仕入時の消費税端数処理区分が設定されておりません。\r\n仕入金額処理区分設定を見直してください。";
                    //    return status;
                    //}

                    //●支払伝票マスタ取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (suplierPayWork.UpdateStatus == 0)
                            status = GetPaymentSlp(ref suplierPayWork, ref sqlConnection);
                    }

                    // 2008.07.24 add start ------------------------------->>
                    //●支払明細データ＆支払マスタ取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (suplierPayWork.UpdateStatus == 0)
                            status = GetPaymentDtlMain(ref suplierPayWork, ref accPayTotalWorkList, ref sqlConnection);
                    }
                    // 2008.07.24 add end ---------------------------------<<

                    //●仕入データ取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (suplierPayWork.UpdateStatus == 0)
                            // ↓ 2007.09.14 980081 c
                            //status = GetStockSlip(ref suplierPayWork, ref sqlConnection);
                            status = GetStockSlip(ref suplierPayWork, ref suplierPayChildWorkList, ref sqlConnection);
                            // ↑ 2007.09.14 980081 c
                    }

                    #region 2008.12.17 DEL
                    /*
                    //●金額計算処理
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = CalculateSuplierPay(ref suplierPayWork);
                    }
                    */
                    #endregion
                }

                paraObj = (object)suplierPayWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SuplierPayDB.ReadSuplierPay");
            }
            finally
            {
                //●暗号化キーCLOSE
                //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                //if (ctrlExclsvOdAcs != null) ctrlExclsvOdAcs.UnlockDB();
            }

            return status;
        }
        #endregion

        // ↓ 2008.03.26 980081 a
        /// <summary>
        /// 消費税端数処理
        /// </summary>
        /// <param name="value">端数処理を行う金額をセット</param>
        /// <param name="fraccd">1:切捨 2:四捨五入 3:切上</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 消費税端数処理</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.03.26</br>
        /// </remarks>
        private Int64 Fraction(double value, int fraccd)
        {
            Int64 ret = 0;
            switch (fraccd)
            {
                case 2:
                    {
                        ret = (long)Math.Round(value, MidpointRounding.AwayFromZero);
                        break;
                    }
                case 3:
                    {
                        if (value >= 0)
                        {
                            ret = (long)Math.Ceiling(value);
                        }
                        else
                        {
                            ret = (long)Math.Floor(value);
                        }
                        break;
                    }
                default:
                    {
                        if (value >= 0)
                        {
                            ret = (long)Math.Floor(value);
                        }
                        else
                        {
                            ret = (long)Math.Ceiling(value);
                        }
                        break;
                    }
            }
            return ret;
        }
        // ↑ 2008.03.26 980081 a

        // ADD 2008.12.10 >>>
        #region [FracCalc 消費税端数処理]
        /// <summary>
        /// 端数処理
        /// </summary>
        /// <param name="inputNumerical">数値</param>
        /// <param name="fractionUnit">端数処理単位</param>
        /// <param name="fractionProcess">端数処理（1:切捨 2:四捨五入 3:切上）</param>
        /// <param name="resultNumerical">算出金額</param>
        private void FracCalc(double inputNumerical, double fractionUnit, Int32 fractionProcess, out Int64 resultNumerical)
        {
            // 初期値セット
            resultNumerical = (Int64)inputNumerical;

            inputNumerical = (double)((decimal)inputNumerical - ((decimal)inputNumerical % (decimal)0.000001));	// 小数点6桁以下切捨
            fractionUnit = (double)((decimal)fractionUnit - ((decimal)fractionUnit % (decimal)0.000001));		// 小数点6桁以下切捨

            // 端数単位で除算
            decimal tmpKin = (decimal)inputNumerical / (decimal)fractionUnit;

            // マイナス補正
            bool sign = false;
            if (tmpKin < 0)
            {
                sign = true;
                tmpKin = tmpKin * (-1);
            }

            // 小数部1桁取得
            decimal tmpDecimal = (tmpKin - (decimal)((long)tmpKin)) * 10;

            // tmpKin 端数指定
            bool wRoundFlg = true; // 切捨
            switch (fractionProcess)
            {
                //--------------------------------------
                // 1:切捨
                //--------------------------------------
                case 1:
                    {
                        wRoundFlg = true; // 切捨
                        break;
                    }
                //--------------------------------------
                // 2:四捨五入
                //--------------------------------------
                case 2: // 四捨五入
                    {
                        if (tmpDecimal >= 5)
                        {
                            wRoundFlg = false; // 切上
                        }
                        break;
                    }
                //--------------------------------------
                // 3:切上
                //--------------------------------------
                case 3: // 切上
                    {
                        if (tmpDecimal > 0)
                        {
                            wRoundFlg = false; // 切上
                        }
                        break;
                    }
            }

            // 端数処理
            if (wRoundFlg == false)
            {
                tmpKin = tmpKin + 1;
            }

            // 小数部切捨
            tmpKin = (decimal)(long)tmpKin;

            // マイナス補正
            if (sign == true)
            {
                tmpKin = tmpKin * (-1);
            }

            decimal a = tmpKin * (decimal)fractionUnit;

            // 算出値セット
            resultNumerical = (Int64)((decimal)tmpKin * (decimal)fractionUnit);

        }
        #endregion
        // ADD 2008.12.10 <<<


    }

}
