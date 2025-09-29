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
    /// 請求金額マスタ更新リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先請求金額マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.03.15</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 分離レベル最適化処理追加(クエリヒント追加)</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.04.12</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 他リモートからの呼び出し対応</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.04.18</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 請求処理通番の自動採番対応</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.04.20</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 金額計算の区分を伝票から取得</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.07.27</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 流通基幹対応</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2007.12.07</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 請求先略称をセットするよう修正</br>
    /// <br>           : 全拠点一括締め対応</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2007.12.07</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 管理拠点分の得意先のみを更新するよう修正</br>
    /// <br>           : 金額セット項目修正</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2008.03.12</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: ＰＭ.ＮＳ用に変更</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.07.18</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 請求締更新履歴マスタテーブルレイアウト変更対応</br>
    /// <br>Programmer : 23015  森本 大輝</br>
    /// <br>Date       : 2008.10.01</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 請求締更新履歴マスタ作成処理変更対応</br>
    /// <br>Programmer : 23012  畠中 啓次朗</br>
    /// <br>Date       : 2008.10.20　2008.11.18</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 請求締更新処理の全体的な見直し</br>
    /// <br>Programmer : 23012  畠中 啓次朗</br>
    /// <br>Date       : 2008.12.10</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 不具合修正</br>
    /// <br>Programmer : 23012  畠中 啓次朗</br>
    /// <br>Date       : 2009.01.16</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 不具合修正</br>
    /// <br>Programmer : 23012  畠中 啓次朗</br>
    /// <br>Date       : 2009.01.20</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 仕様変更(消費税転嫁方式別計算処理の大変更)</br>
    /// <br>Programmer : 23012  畠中 啓次朗</br>
    /// <br>Date       : 2009.04.14</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 仕様変更(請求書番号セット対応)</br>
    /// <br>Programmer : 23012  畠中 啓次朗</br>
    /// <br>Date       : 2009/06/18</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 請求書番号取得処理エラー対応(MANTIS:13705)</br>
    /// <br>Programmer : 23012  畠中 啓次朗</br>
    /// <br>Date       : 2009/07/02</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 更新処理修正(MANTIS:13549)</br>
    /// <br>Programmer : 23012  畠中 啓次朗</br>
    /// <br>Date       : 2009/07/03</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 入金マイナスかつ残マイナスの場合の残高算出処理修正(MANTIS:14990)</br>
    /// <br>Programmer : 22018  鈴木　正臣</br>
    /// <br>Date       : 2010/03/01</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 得意先電子元帳の残高合計の抽出時、</br>
    /// <br>             請求金額マスタに該当レコードが無い場合は(データ量を制限する為)指定開始日以降となるよう変更。</br>
    /// <br>Programmer : 22018  鈴木 正臣</br>
    /// <br>Date       : 2010/07/21</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 締次ロックの実装（※集計中も集計対象外の伝票と衝突しない）</br>
    /// <br>Programmer : 22018  鈴木 正臣</br>
    /// <br>Date       : 2010/08/18</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 請求拠点・締日毎に最初の請求先しか更新されない不具合の修正</br>
    /// <br>             (※2010/08/18変更後の内容をユーザー環境に配信する前に発覚)</br>
    /// <br>Programmer : 22018  鈴木 正臣</br>
    /// <br>Date       : 2010/09/30</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 得意先マスタの請求拠点を変更した場合の不具合修正(MANTIS:16183)</br>
    /// <br>Programmer : 22008  長内 数馬</br>
    /// <br>Date       : 2010/10/06</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 前回残取得時の不具合を修正</br>
    /// <br>Programmer : 22008  長内 数馬</br>
    /// <br>Date       : 2010/11/24</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 得意先請求金額マスタのデータセット仕様変更</br>
    /// <br>Programmer : 鄧潘ハン </br>
    /// <br>Date       : 2010/12/20</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 2011/12/22 凌小青</br>
    /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
    /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
    /// <br>Update Note: READUNCOMMITTEDの追加</br>
    /// <br>Programmer : 西 毅 </br>
    /// <br>Date       : 2012/02/15</br>
    /// <br>-------------------------------------------------------</br>    
    /// <br>Update Note: 売上データ取得のパフォーマンス向上</br>
    /// <br>Programmer : 30755  菅原 庸平 </br>
    /// <br>Date       : 2012/04/27</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 入金入力/売上額表示不正 --> 日付溢れ異常の修正</br>
    /// <br>管理番号   ：10801804-00 2012/11/14配信分</br>
    /// <br>             Redmine#32866 入金入力/売上額表示不正</br> 
    /// <br>Programmer : liusy </br>
    /// <br>Date       : 2012/10/18</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 2012/12/12 dpp</br>
    /// <br>管理番号   : 10801804-00 2013/01/16配信分</br>
    /// <br>             Redmine#33856 入金予定日の計算の不正</br> 
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 与信額設定処理の不具合を修正</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2013/02/28</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 「売上締次更新」の処理速度遅延の調査と対応(№1921)</br>
    /// <br>管理番号   ：10902175-00 2013/06/18配信分</br>
    /// <br>             Redmine#35552 「売上締次更新」の処理速度遅延の調査と対応(№1921)</br> 
    /// <br>Programmer : 汪権来</br>
    /// <br>Date       : 2013/08/08</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 2016/10/27 田建委</br>
    /// <br>管理番号   : 11275240-00</br>
    /// <br>             Redmine#48899 売上締次処理のレコードロック解除-READUNCOMMITTEDの追加</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 2019/10/15 譚洪</br>
    /// <br>管理番号   : 11575156-00</br>
    /// <br>             PMKOBETSU-1860 速度遅延やタイムアウトの対応</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note: 2023/11/24 田村顕成</br>
    /// <br>管理番号   : 11900025-00</br>
    /// <br>             売掛残高一覧消費税額相違不具合修正
    /// <br>-------------------------------------------------------</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class CustDmdPrcDB : RemoteWithAppLockDB, ICustDmdPrcDB
    {
        private int _timeOut = 3600;//ADD 凌小青 2011/12/22 Redmine#27450
        /// <summary>
        /// 請求金額マスタ更新リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.14</br>
        /// </remarks>
        public CustDmdPrcDB()
            :
            base("MAKAU00125D", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcWork", "CUSTDMDPRCRF")
        {
            
        }

        #region [Write 請求締処理]
        /// <summary>
        /// 得意先請求金額マスタを更新します
        /// </summary>
        /// <param name="paraObj">得意先請求金額マスタ更新パラメータ</param>
        /// <param name="retList">得意先請求金額マスタ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額マスタを更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.15</br>
        /// <br>Note       : CustomerDataマスタを作成する</br>
        /// <br>Update Note: 2013/08/08 汪権来</br>
        /// <br>管理番号   ：10902175-00 2013/06/18配信分</br>
        /// <br>             Redmine#35552 「売上締次更新」の処理速度遅延の調査と対応(№1921)</br>
        /// </remarks>
        public int Write(ref object paraObj, out object retList, out string retMsg)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retList = null;
            retMsg = null;

            //請求金額マスタList(更新用)
            ArrayList custDmdPrcWorkList = new ArrayList();
            
            //請求金額マスタList(請求先子出力用)
            ArrayList custDmdPrcChildWorkList = new ArrayList();

            //得意先単位の更新ステータスList(UI側にリターン)
            ArrayList statusList = new ArrayList();
            
            //請求締更新履歴List
            ArrayList dmdCAddUpHisWorkList = null;
            
            //請求入金集計データList(更新用)
            ArrayList dmdDepoTotalWorkList = new ArrayList(); 

            //請求金額マスタ
            CustDmdPrcWork custDmdPrcWork = null;
            CustDmdPrcUpdStatusWork custDmdPrcUpdStatusWork = null;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection_read = null;

            //排他制御部品           
            ShareCheckInfo info = new ShareCheckInfo();

            //拠点情報設定取得部品
            SecInfoSetDB secInfoSetDB = new SecInfoSetDB();
            try
            {
                //●パラメータセット
                CustDmdPrcUpdateWork custDmdPrcUpdateWork = paraObj as CustDmdPrcUpdateWork;
                
                if (custDmdPrcUpdateWork == null)
                {
                    base.WriteErrorLog(null, "プログラムエラー。パラメータが未設定です");
                    return status;
                }

                //メソッド開始時にコネクション文字列を取得
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // --- ADD m.suzuki 2010/08/18 ---------->>>>>
                // 対象請求先のリスト
                ArrayList orgCustDmdPrcWorkList = new ArrayList();
                // 更新対象ありフラグ
                bool updateTargetExistsFlag = false;

                // ロック用コネクション
                SqlConnection sqlConnection_lock = null;
                // ロック用トランザクション
                SqlTransaction sqlTransaction_lock = null;

                Dictionary<string, List<CustDmdPrcWork>> custDmdPrcParentWorkList = null;//ADD 2013/08/08 汪権来 Redmine#35552 速度改善
                Dictionary<string, List<CustDmdPrcWork>> custDmdPrcChildrenWorkList = null;//ADD 2013/08/08 汪権来 Redmine#35552 速度改善
                try
                {
                    # region [ロック開始]
                    // ロック用コネクションオープン
                    sqlConnection_lock = new SqlConnection( connectionText );
                    sqlConnection_lock.Open();
                    // ロック用トランザクション開始
                    sqlTransaction_lock = sqlConnection_lock.BeginTransaction( (IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default );
                    
                    // 締次集計ロックの為に拠点コード補正
                    string sectionCode = custDmdPrcUpdateWork.AddUpSecCode.Trim();
                    if ( sectionCode == string.Empty )
                    {
                        sectionCode = "00";
                    }

                    // 締次集計ロック
                    info.Keys.Add( new ShareCheckKey( custDmdPrcUpdateWork.EnterpriseCode,
                                                      ShareCheckType.AddUpUpdate,
                                                      sectionCode,
                                                      "",
                                                      custDmdPrcUpdateWork.CustomerTotalDay,
                                                      ToLongDate( custDmdPrcUpdateWork.AddUpDate ) ) );
                    // 締次ロック開始
                    status = this.ShareCheck( info, LockControl.Locke, sqlConnection_lock, sqlTransaction_lock );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        return status;
                    }
                    # endregion

                    # region [対象請求先の抽出]
                    int status_init = 0;
                    SqlConnection sqlConnection_init = new SqlConnection( connectionText );
                    try
                    {
                        // コネクション・オープン
                        sqlConnection_init.Open();

                        // 対象得意先抽出
                        status_init = GetCustomer( ref custDmdPrcUpdateWork, ref orgCustDmdPrcWorkList, ref sqlConnection_init );
                    }
                    finally
                    {
                        // コネクション破棄
                        if ( sqlConnection_init != null )
                        {
                            sqlConnection_init.Close();
                        }
                    }
                    # endregion
                    //----- ADD 2013/08/08 汪権来 Redmine#35552 速度改善 ------------------->>>>>
                    SqlConnection sqlConnection_read1 = new SqlConnection(connectionText);
                    try
                    {
                        // コネクション・オープン
                        sqlConnection_read1.Open();

                        // 対象請求先、一時テーブル作成
                        if (status_init == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = InsertCustomerData(custDmdPrcUpdateWork, ref sqlConnection_read1);
                        }
                        // 対象売上、一時テーブル作成
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = InsertSalesSlipClaimWork(custDmdPrcUpdateWork, ref sqlConnection_read1);
                        }

                        //親集計
                        custDmdPrcParentWorkList = new Dictionary<string, List<CustDmdPrcWork>>();
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = GetDictionaryProc(ref custDmdPrcParentWorkList, ref sqlConnection_read1);
                        }
                        //子集計
                        custDmdPrcChildrenWorkList = new Dictionary<string, List<CustDmdPrcWork>>();
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = GetDictionaryCroc(ref custDmdPrcChildrenWorkList, ref sqlConnection_read1);
                        }


                    }
                    finally
                    {
                        // コネクション破棄
                        if (sqlConnection_read1 != null)
                        {
                            sqlConnection_read1.Close();
                        }
                    }

                    //----- ADD 2013/08/08 汪権来 Redmine#35552 速度改善 -------------------<<<<<
                    // --- ADD m.suzuki 2010/09/30 ---------->>>>>
                    // 拠点毎の最後のindexを退避しておく
                    Dictionary<string, int> finIndexDic = new Dictionary<string, int>();
                    for ( int index = 0; index < orgCustDmdPrcWorkList.Count; index++ )
                    {
                        CustDmdPrcWork targetWork = (CustDmdPrcWork)orgCustDmdPrcWorkList[index];
                        if ( finIndexDic.ContainsKey( targetWork.AddUpSecCode ) )
                        {
                            finIndexDic[targetWork.AddUpSecCode] = index;
                        }
                        else
                        {
                            finIndexDic.Add( targetWork.AddUpSecCode, index );
                        }
                    }
                    // --- ADD m.suzuki 2010/09/30 ----------<<<<<

                    // --- UPD m.suzuki 2010/09/30 ---------->>>>>
                    //foreach ( CustDmdPrcWork targetWork in orgCustDmdPrcWorkList )
                    //{
                    for ( int index = 0; index < orgCustDmdPrcWorkList.Count; index++ )
                    {
                        CustDmdPrcWork targetWork = (CustDmdPrcWork)orgCustDmdPrcWorkList[index];
                    // --- UPD m.suzuki 2010/09/30 ----------<<<<<
                        // 請求先１件だけリストに格納
                        custDmdPrcWorkList = new ArrayList();
                        custDmdPrcWorkList.Add( targetWork );
                        
                        // 子リストを初期化
                        custDmdPrcChildWorkList = new ArrayList();
                // --- ADD m.suzuki 2010/08/18 ----------<<<<<


                        //●SQLコネクションオブジェクト作成
                        using ( sqlConnection = new SqlConnection( connectionText ) )
                        {
                            //SqlEncryptInfo sqlEncryptInfo = null;
                            try
                            {
                                sqlConnection.Open();
                                // Read用コネクションをインスタンス化
                                sqlConnection_read = new SqlConnection( connectionText );
                                sqlConnection_read.Open();

                                //●トランザクション開始
                                sqlTransaction = sqlConnection.BeginTransaction( (IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default );

                                // --- DEL m.suzuki 2010/08/18 ---------->>>>>
                                # region // DEL
                                //#region 排他制御
                                //if ( custDmdPrcUpdateWork.AddUpSecCode == "00" || custDmdPrcUpdateWork.AddUpSecCode == "" )
                                //{
                                //    //システムロック(企業)
                                //    info.Keys.Add( custDmdPrcUpdateWork.EnterpriseCode, ShareCheckType.Enterprise, "", "" );
                                //    status = this.ShareCheck( info, LockControl.Locke, sqlConnection, sqlTransaction );
                                //}
                                //else
                                //{
                                //    //システムロック(拠点)
                                //    info.Keys.Add( custDmdPrcUpdateWork.EnterpriseCode, ShareCheckType.Section, custDmdPrcUpdateWork.AddUpSecCode, "" );
                                //    status = this.ShareCheck( info, LockControl.Locke, sqlConnection, sqlTransaction );

                                //}
                                //if ( status != 0 )
                                //{
                                //    return status;
                                //}
                                //#endregion

                                //// 修正 2009/04/16 全拠点締の場合、登録拠点回数分クエリを実行しているため、修正 >>>
                                //#region DEL 2009/04/16
                                // /*
                                //SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
                                //secInfoSetWork.EnterpriseCode = custDmdPrcUpdateWork.EnterpriseCode;
                                //ArrayList secInfoList = new ArrayList();
                                //if (custDmdPrcUpdateWork.AddUpSecCode == null || custDmdPrcUpdateWork.AddUpSecCode == "00" || custDmdPrcUpdateWork.AddUpSecCode == "")
                                //{
                                //    // 全拠点
                                //    secInfoSetDB.Search(out secInfoList, secInfoSetWork, 0, 0, ref sqlConnection_read);
                                //}
                                //else
                                //{
                                //    // 単独拠点(画面指定の拠点を使用)
                                //    secInfoSetWork.SectionCode = custDmdPrcUpdateWork.AddUpSecCode;　
                                //    secInfoList.Add(secInfoSetWork);
                                //}
                                //string addUpSecCode = custDmdPrcUpdateWork.AddUpSecCode;

                                //for (int loopCount = 0; loopCount < secInfoList.Count; loopCount++)
                                //{
                                //    custDmdPrcUpdateWork.AddUpSecCode = (secInfoList[loopCount] as SecInfoSetWork).SectionCode;
                                //    //●得意先マスタから締日を取得
                                //    if (custDmdPrcUpdateWork.UpdObjectFlag == 1)
                                //    {
                                //        status = GetCustomer(ref custDmdPrcUpdateWork, ref custDmdPrcWorkList, ref sqlConnection_read);
                                //    }
                                //}

                                //custDmdPrcUpdateWork.AddUpSecCode = addUpSecCode;
                                //*/
                                //#endregion
                                //status = GetCustomer( ref custDmdPrcUpdateWork, ref custDmdPrcWorkList, ref sqlConnection_read );
                                //// 修正 2009/04/16 <<<
                                # endregion
                                // --- DEL m.suzuki 2010/08/18 ----------<<<<<

                                if ( custDmdPrcWorkList.Count > 0 )
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }

                                // --- DEL m.suzuki 2010/08/18 ---------->>>>>
                                //if ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                                //{
                                //    retMsg = "対象となる得意先が存在しません。";
                                //    return status;
                                //}
                                // --- DEL m.suzuki 2010/08/18 ----------<<<<<

                                //●請求金額マスタ更新パラメータList作成
                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    //status = MakeCustDmdPrcParameters(ref custDmdPrcUpdateWork, ref custDmdPrcWorkList, ref custDmdPrcChildWorkList, ref dmdDepoTotalWorkList, out dmdCAddUpHisWorkList, out retMsg, ref sqlConnection_read);//DEL 2013/08/08 汪権来 Redmine#35552 速度改善
                                    status = MakeCustDmdPrcParameters(ref custDmdPrcUpdateWork, ref custDmdPrcWorkList, ref custDmdPrcChildWorkList, ref dmdDepoTotalWorkList, out dmdCAddUpHisWorkList, out retMsg, ref sqlConnection_read, custDmdPrcParentWorkList, custDmdPrcChildrenWorkList);//ADD 2013/08/08 汪権来 Redmine#35552 速度改善
                                }

                                if ( sqlConnection_read != null ) sqlConnection_read.Close();
                                // --- UPD m.suzuki 2010/08/18 ---------->>>>>
                                //if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) return status;
                                if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) break;
                                // --- UPD m.suzuki 2010/08/18 ----------<<<<<

                                try
                                {
                                    #region DEL 2009/04/16
                                    /*
                            int listCount = 0;
                            for (int i = 0; i < custDmdPrcWorkList.Count; i++)
                            {
                                custDmdPrcWork = custDmdPrcWorkList[i] as CustDmdPrcWork;
                                if (custDmdPrcWork.UpdateStatus == 0)
                                {
                                    listCount += 1;
                                }
                            }
                            Int32[] customerCodeList = new Int32[listCount];
                            ArrayList al = new ArrayList();//ワーク用
                            //得意先コードList作成
                            for (int i = 0; i < custDmdPrcWorkList.Count; i++)
                            {
                                custDmdPrcWork = custDmdPrcWorkList[i] as CustDmdPrcWork;
                                //更新得意先コード抽出
                                if (custDmdPrcWork.UpdateStatus == 0)
                                {
                                    al.Add(custDmdPrcWork.CustomerCode);
                                }
                            }
                            customerCodeList = (Int32[])al.ToArray(typeof(Int32));
                            //status = ctrlExclsvOdAcs.LockDB(custDmdPrcUpdateWork.EnterpriseCode, customerCodeList, null);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            */
                                    #endregion

                                    //●請求金額マスタ更新処理
                                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                    {
                                        if ( custDmdPrcWorkList.Count > 0 )
                                        {

                                            // ADD 2009/06/18 >>>
                                            long no;
                                            NumberingManager numberingManager = new NumberingManager();

                                            #region 請求書番号セット処理
                                            // 集計レコードのセット処理
                                            for ( int i = 0; i < custDmdPrcWorkList.Count; i++ )
                                            {
                                                //請求書№取得
                                                status = numberingManager.GetSerialNumber( ((CustDmdPrcWork)custDmdPrcWorkList[i]).EnterpriseCode, "00", (Remoting.SerialNumberCode)1400, out no );

                                                // ADD 2009/07/02 >>>
                                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                                {
                                                    ((CustDmdPrcWork)custDmdPrcWorkList[i]).BillNo = System.Convert.ToInt32( no );
                                                }
                                                else
                                                {
                                                    retMsg = "請求書番号の取得に失敗しました。";
                                                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                                                    return status;
                                                }
                                                // ADD 2009/07/02 <<<
                                            }

                                            //親子レコードのセット処理
                                            for ( int i = 0; i < custDmdPrcChildWorkList.Count; i++ )
                                            {
                                                for ( int j = 0; j < custDmdPrcWorkList.Count; j++ )
                                                {
                                                    if ( ((CustDmdPrcWork)custDmdPrcWorkList[j]).AddUpSecCode == ((CustDmdPrcWork)custDmdPrcChildWorkList[i]).AddUpSecCode &&
                                                        ((CustDmdPrcWork)custDmdPrcWorkList[j]).ClaimCode == ((CustDmdPrcWork)custDmdPrcChildWorkList[i]).ClaimCode )
                                                    {
                                                        //集計レコードと同一の請求書№取得
                                                        ((CustDmdPrcWork)custDmdPrcChildWorkList[i]).BillNo = ((CustDmdPrcWork)custDmdPrcWorkList[j]).BillNo;
                                                    }
                                                }
                                            }
                                            #endregion

                                            // ADD 2009/06/18 <<<

                                            // ↓ 2007.11.20 980081 c 請求先子レコード作成対応
                                            //status = WriteCustDmdPrc(ref custDmdPrcWorkList, ref sqlConnection, ref sqlTransaction);
                                            status = WriteCustDmdPrc( ref custDmdPrcWorkList, ref custDmdPrcChildWorkList, ref sqlConnection, ref sqlTransaction );
                                            // ↑ 2007.11.20 980081 c

                                            // --- ADD m.suzuki 2010/08/18 ---------->>>>>
                                            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                            {
                                                updateTargetExistsFlag = true;
                                            }
                                            // --- ADD m.suzuki 2010/08/18 ----------<<<<<
                                        }
                                        // --- DEL m.suzuki 2010/08/18 ---------->>>>>
                                        //else
                                        //{
                                        //    retMsg = "更新可能な得意先が存在しません。\r\n更新件数は0件です。";
                                        //    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                        //    return status;
                                        //}
                                        // --- DEL m.suzuki 2010/08/18 ----------<<<<<
                                    }

                                    //●請求入金集計データ更新処理
                                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                    {
                                        if ( dmdDepoTotalWorkList.Count > 0 )
                                        {
                                            status = WriteDepoTotalPrc( ref dmdDepoTotalWorkList, ref sqlConnection, ref sqlTransaction );
                                            // ADD 菅原 庸平 2012/04/27 >>>
                                            dmdDepoTotalWorkList.Clear();
                                            // ADD 菅原 庸平 2012/04/27 <<<
                                        }
                                    }

                                    //●請求締更新履歴マスタ更新処理
                                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                    {
                                        if ( custDmdPrcUpdateWork.ProcCntntsFlag == 1 )
                                        {
                                            if ( dmdCAddUpHisWorkList.Count > 0 )
                                            {
                                                // --- UPD m.suzuki 2010/09/30 ---------->>>>>
                                                ////締次更新処理実行時
                                                //status = WriteDmdCAddUpHis( ref dmdCAddUpHisWorkList, ref sqlConnection, ref sqlTransaction );
                                                if ( custDmdPrcWorkList.Count > 0 )
                                                {
                                                    // 請求拠点がディクショナリに含まれるか（※Listを操作しているので[0]固定）
                                                    if ( finIndexDic.ContainsKey( (custDmdPrcWorkList[0] as CustDmdPrcWork).AddUpSecCode ) )
                                                    {
                                                        // 請求拠点毎の最終indexと一致するか
                                                        if ( finIndexDic[(custDmdPrcWorkList[0] as CustDmdPrcWork).AddUpSecCode] == index )
                                                        {
                                                            // 対象の請求拠点の最後の請求先を処理するタイミングでのみ、請求締更新履歴を書き込む。
                                                            status = WriteDmdCAddUpHis( ref dmdCAddUpHisWorkList, ref sqlConnection, ref sqlTransaction );
                                                        }
                                                    }
                                                }
                                                // --- UPD m.suzuki 2010/09/30 ----------<<<<<
                                            }
                                            // --- DEL m.suzuki 2010/08/18 ---------->>>>>
                                            ////一応念のため追加
                                            //else
                                            //{
                                            //    retMsg = "更新可能な得意先が存在しません。\r\n更新件数は0件です。";
                                            //    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                            //    return status;
                                            //}
                                            // --- DEL m.suzuki 2010/08/18 ----------<<<<<
                                        }
                                    }
                                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                                    {
                                        retMsg = "請求締履歴の作成に失敗しました。";
                                        // --- UPD m.suzuki 2010/08/18 ---------->>>>>
                                        //return status;
                                        break;
                                        // --- UPD m.suzuki 2010/08/18 ----------<<<<<
                                    }

                                    //●更新ステータス情報生成
                                    for ( int i = 0; i < custDmdPrcWorkList.Count; i++ )
                                    {
                                        custDmdPrcWork = custDmdPrcWorkList[i] as CustDmdPrcWork;
                                        custDmdPrcUpdStatusWork = new CustDmdPrcUpdStatusWork();

                                        custDmdPrcUpdStatusWork.EnterpriseCode = custDmdPrcWork.EnterpriseCode;
                                        custDmdPrcUpdStatusWork.CustomerCode = custDmdPrcWork.ClaimCode;
                                        custDmdPrcUpdStatusWork.AddUpSecCode = custDmdPrcWork.AddUpSecCode;
                                        custDmdPrcUpdStatusWork.UpdateStatus = custDmdPrcWork.UpdateStatus;

                                        if ( custDmdPrcWork.ClaimCode == custDmdPrcWork.CustomerCode )
                                        {
                                            statusList.Add( custDmdPrcUpdStatusWork );
                                        }
                                    }

                                    //●戻り値をセット
                                    retList = (object)statusList;
                                }
                                catch ( SqlException ex )
                                {
                                    status = base.WriteSQLErrorLog( ex );
                                }
                                catch ( Exception ex )
                                {
                                    base.WriteErrorLog( ex, "CustDmdPrcDB.Write Exception=" + ex.Message );
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

                                    //●更新時ロック解除
                                    //if (ctrlExclsvOdAcs != null) ctrlExclsvOdAcs.UnlockDB();
                                }
                            }
                            finally
                            {
                                // --- DEL m.suzuki 2010/08/18 ---------->>>>>
                                ////システムロック解除 //2009/1/27 Add sakurai
                                //if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                //{
                                //    status = this.ShareCheck( info, LockControl.Release, sqlConnection, sqlTransaction );
                                //}
                                // --- DEL m.suzuki 2010/08/18 ----------<<<<<

                                //●コミットorロールバック
                                //正常更新時コミット、異常発生時ロールバック
                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ) sqlTransaction.Commit();
                                else sqlTransaction.Rollback();

                                //●コネクション破棄
                                if ( sqlConnection != null ) sqlConnection.Close();
                                if ( sqlConnection_read != null ) sqlConnection_read.Close();

                            }
                        }

                // --- ADD m.suzuki 2010/08/18 ---------->>>>>
                    } // end foreach

                    //--------------------------------------------------
                    // 該当データが１件もなかった場合
                    //--------------------------------------------------
                    if ( updateTargetExistsFlag == false )
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        retMsg = "更新可能な得意先が存在しません。\r\n更新件数は0件です。";
                        return status;
                    }
                    //--------------------------------------------------
                    // ※途中でエラーになった場合は、既にコミットした分の解除処理が必要
                    //--------------------------------------------------
                    else if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        // 解除実行（※既にロック中なのでDeleteProc内でロックしない(false)）
                        string deleteMessage;
                        this.DeleteProc( ref paraObj, out deleteMessage, false );
                    }
                }
                finally
                {
                    # region [ロック解除]
                    if ( sqlConnection_lock != null && sqlTransaction_lock != null )
                    {
                        // ロック解除
                        this.ShareCheck( info, LockControl.Release, sqlConnection_lock, sqlTransaction_lock );
                    }
                    if ( sqlTransaction_lock != null ) sqlTransaction_lock.Commit();
                    if ( sqlConnection_lock != null ) sqlConnection_lock.Close();
                    # endregion
                }
                // --- ADD m.suzuki 2010/08/18 ----------<<<<<
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustDmdPrcDB.Write Exception=" + ex.Message);
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

        /// <summary>
        /// 得意先請求金額マスタを更新します
        /// </summary>
        /// <param name="custDmdPrcWorkList">得意先請求金額マスタList</param>
        /// <param name="custDmdPrcChildWorkList">得意先請求金額マスタList</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額マスタを更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.15</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        /// </remarks>
        // ↓ 2007.11.20 980081 c
        //private int WriteCustDmdPrc(ref ArrayList custDmdPrcWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int WriteCustDmdPrc(ref ArrayList custDmdPrcWorkList, ref ArrayList custDmdPrcChildWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        // ↑ 2007.11.20 980081 c
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            string sqlText = string.Empty; // 2008.07.18 add


            //Deleteコマンドの生成
            try
            {

                for (int i = 0; i < custDmdPrcWorkList.Count; i++)
                {
                    CustDmdPrcWork custDmdPrcWork = custDmdPrcWorkList[i] as CustDmdPrcWork;
                    if (custDmdPrcWork.UpdateStatus == 0)
                    {
                        // ↓ 2007.11.20 980081 c 得意先コードで削除していたのを請求先コードに変更
                        //using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM CUSTDMDPRCRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ADDUPDATERF>=@FINDSTARTCADDUPUPDDATE AND ADDUPDATERF<=@FINDADDUPDATE ", sqlConnection, sqlTransaction))
                        // 2008.07.18 upd start --------------------------------------------->>
                        //using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM CUSTDMDPRCRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND CLAIMCODERF=@FINDCLAIMCODE AND ADDUPDATERF>=@FINDSTARTCADDUPUPDDATE AND ADDUPDATERF<=@FINDADDUPDATE ", sqlConnection, sqlTransaction))
                        sqlText = string.Empty;
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += " FROM CUSTDMDPRCRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                        sqlText += "    AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                        // 修正 2009/07/03 >>>
                        //sqlText += "    AND ADDUPDATERF>=@FINDSTARTCADDUPUPDDATE" + Environment.NewLine;
                        //sqlText += "    AND ADDUPDATERF<=@FINDADDUPDATE" + Environment.NewLine;
                        sqlText += "    AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;
                        // 修正 2009/07/03 <<<
                        using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))    
                        // 2008.07.18 upd end -----------------------------------------------<<
                        // ↑ 2007.11.20 980081 c
                        {
                            sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                            //Prameterオブジェクトの作成
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                            // ↓ 2007.11.20 980081 c 得意先コードで削除していたのを請求先コードに変更
                            //SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                            SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                            // ↑ 2007.11.20 980081 c
                            SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                            //SqlParameter findParaStartCAddUpUpdDate = sqlCommand.Parameters.Add("@FINDSTARTCADDUPUPDDATE", SqlDbType.Int); // DEL 2009/07/03

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                            findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                            // ↓ 2007.11.20 980081 c 得意先コードで削除していたのを請求先コードに変更
                            //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                            findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                            // ↑ 2007.11.20 980081 c
                            findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);
                            // DEL 2009/07/03 >>>
                            //findParaStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.StartCAddUpUpdDate);
                            //if (custDmdPrcWork.StartCAddUpUpdDate == DateTime.MinValue)
                            //    findParaStartCAddUpUpdDate.Value = 20000101;
                            // DEL 2009/07/03 <<<
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    if (custDmdPrcWork.UpdateStatus == 0 && custDmdPrcWork.CAddUpUpdExecDate != DateTime.MinValue)
                    {
                        // 2008.07.18 upd start ------------------------------------------------------------------->>
                        //using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO CUSTDMDPRCRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPSECCODERF, CLAIMCODERF, CLAIMNAMERF, CLAIMNAME2RF, CLAIMSNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, ADDUPDATERF, ADDUPYEARMONTHRF, LASTTIMEDEMANDRF, THISTIMEFEEDMDNRMLRF, THISTIMEDISDMDNRMLRF, THISTIMEDMDNRMLRF, THISTIMETTLBLCDMDRF, OFSTHISTIMESALESRF, OFSTHISSALESTAXRF, ITDEDOFFSETOUTTAXRF, ITDEDOFFSETINTAXRF, ITDEDOFFSETTAXFREERF, OFFSETOUTTAXRF, OFFSETINTAXRF, THISTIMESALESRF, THISSALESTAXRF, ITDEDSALESOUTTAXRF, ITDEDSALESINTAXRF, ITDEDSALESTAXFREERF, SALESOUTTAXRF, SALESINTAXRF, THISSALESPRICRGDSRF, THISSALESPRCTAXRGDSRF, TTLITDEDRETOUTTAXRF, TTLITDEDRETINTAXRF, TTLITDEDRETTAXFREERF, TTLRETOUTERTAXRF, TTLRETINNERTAXRF, THISSALESPRICDISRF, THISSALESPRCTAXDISRF, TTLITDEDDISOUTTAXRF, TTLITDEDDISINTAXRF, TTLITDEDDISTAXFREERF, TTLDISOUTERTAXRF, TTLDISINNERTAXRF, THISPAYOFFSETRF, THISPAYOFFSETTAXRF, ITDEDPAYMOUTTAXRF, ITDEDPAYMINTAXRF, ITDEDPAYMTAXFREERF, PAYMENTOUTTAXRF, PAYMENTINTAXRF, TAXADJUSTRF, BALANCEADJUSTRF, AFCALDEMANDPRICERF, ACPODRTTL2TMBFBLDMDRF, ACPODRTTL3TMBFBLDMDRF, CADDUPUPDEXECDATERF, STARTCADDUPUPDDATERF, LASTCADDUPUPDDATERF, SALESSLIPCOUNTRF, BILLPRINTDATERF, EXPECTEDDEPOSITDATERF, COLLECTCONDRF, CONSTAXLAYMETHODRF, CONSTAXRATERF, FRACTIONPROCCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ADDUPSECCODE, @CLAIMCODE, @CLAIMNAME, @CLAIMNAME2, @CLAIMSNM, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @CUSTOMERSNM, @ADDUPDATE, @ADDUPYEARMONTH, @LASTTIMEDEMAND, @THISTIMEFEEDMDNRML, @THISTIMEDISDMDNRML, @THISTIMEDMDNRML, @THISTIMETTLBLCDMD, @OFSTHISTIMESALES, @OFSTHISSALESTAX, @ITDEDOFFSETOUTTAX, @ITDEDOFFSETINTAX, @ITDEDOFFSETTAXFREE, @OFFSETOUTTAX, @OFFSETINTAX, @THISTIMESALES, @THISSALESTAX, @ITDEDSALESOUTTAX, @ITDEDSALESINTAX, @ITDEDSALESTAXFREE, @SALESOUTTAX, @SALESINTAX, @THISSALESPRICRGDS, @THISSALESPRCTAXRGDS, @TTLITDEDRETOUTTAX, @TTLITDEDRETINTAX, @TTLITDEDRETTAXFREE, @TTLRETOUTERTAX, @TTLRETINNERTAX, @THISSALESPRICDIS, @THISSALESPRCTAXDIS, @TTLITDEDDISOUTTAX, @TTLITDEDDISINTAX, @TTLITDEDDISTAXFREE, @TTLDISOUTERTAX, @TTLDISINNERTAX, @THISPAYOFFSET, @THISPAYOFFSETTAX, @ITDEDPAYMOUTTAX, @ITDEDPAYMINTAX, @ITDEDPAYMTAXFREE, @PAYMENTOUTTAX, @PAYMENTINTAX, @TAXADJUST, @BALANCEADJUST, @AFCALDEMANDPRICE, @ACPODRTTL2TMBFBLDMD, @ACPODRTTL3TMBFBLDMD, @CADDUPUPDEXECDATE, @STARTCADDUPUPDDATE, @LASTCADDUPUPDDATE, @SALESSLIPCOUNT, @BILLPRINTDATE, @EXPECTEDDEPOSITDATE, @COLLECTCOND, @CONSTAXLAYMETHOD, @CONSTAXRATE, @FRACTIONPROCCD)", sqlConnection, sqlTransaction))
                        #region INSERT
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO CUSTDMDPRCRF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "    ,ADDUPSECCODERF" + Environment.NewLine;
                        sqlText += "    ,CLAIMCODERF" + Environment.NewLine;
                        sqlText += "    ,CLAIMNAMERF" + Environment.NewLine;
                        sqlText += "    ,CLAIMNAME2RF" + Environment.NewLine;
                        sqlText += "    ,CLAIMSNMRF" + Environment.NewLine;
                        sqlText += "    ,RESULTSSECTCDRF" + Environment.NewLine;
                        sqlText += "    ,CUSTOMERCODERF" + Environment.NewLine;
                        sqlText += "    ,CUSTOMERNAMERF" + Environment.NewLine;
                        sqlText += "    ,CUSTOMERNAME2RF" + Environment.NewLine;
                        sqlText += "    ,CUSTOMERSNMRF" + Environment.NewLine;
                        sqlText += "    ,ADDUPDATERF" + Environment.NewLine;
                        sqlText += "    ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        sqlText += "    ,LASTTIMEDEMANDRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMEDMDNRMLRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMETTLBLCDMDRF" + Environment.NewLine;
                        sqlText += "    ,OFSTHISTIMESALESRF" + Environment.NewLine;
                        sqlText += "    ,OFSTHISSALESTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDOFFSETINTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,OFFSETOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,OFFSETINTAXRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMESALESRF" + Environment.NewLine;
                        sqlText += "    ,THISSALESTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDSALESOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDSALESINTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDSALESTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,SALESOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,SALESINTAXRF" + Environment.NewLine;
                        sqlText += "    ,THISSALESPRICRGDSRF" + Environment.NewLine;
                        sqlText += "    ,THISSALESPRCTAXRGDSRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDRETINTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDRETTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,TTLRETOUTERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLRETINNERTAXRF" + Environment.NewLine;
                        sqlText += "    ,THISSALESPRICDISRF" + Environment.NewLine;
                        sqlText += "    ,THISSALESPRCTAXDISRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDDISINTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDDISTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,TTLDISOUTERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLDISINNERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TAXADJUSTRF" + Environment.NewLine;
                        sqlText += "    ,BALANCEADJUSTRF" + Environment.NewLine;
                        sqlText += "    ,AFCALDEMANDPRICERF" + Environment.NewLine;
                        sqlText += "    ,ACPODRTTL2TMBFBLDMDRF" + Environment.NewLine;
                        sqlText += "    ,ACPODRTTL3TMBFBLDMDRF" + Environment.NewLine;
                        sqlText += "    ,CADDUPUPDEXECDATERF" + Environment.NewLine;
                        sqlText += "    ,STARTCADDUPUPDDATERF" + Environment.NewLine;
                        sqlText += "    ,LASTCADDUPUPDDATERF" + Environment.NewLine;
                        sqlText += "    ,SALESSLIPCOUNTRF" + Environment.NewLine;
                        sqlText += "    ,BILLPRINTDATERF" + Environment.NewLine;
                        sqlText += "    ,EXPECTEDDEPOSITDATERF" + Environment.NewLine;
                        sqlText += "    ,COLLECTCONDRF" + Environment.NewLine;
                        sqlText += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                        sqlText += "    ,CONSTAXRATERF" + Environment.NewLine;
                        sqlText += "    ,FRACTIONPROCCDRF" + Environment.NewLine;
                        // ADD 2009/06/18 >>>
                        sqlText += "    ,BILLNORF" + Environment.NewLine;
                        // ADD 2009/06/18 <<<
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
                        sqlText += "    ,@CLAIMCODE" + Environment.NewLine;
                        sqlText += "    ,@CLAIMNAME" + Environment.NewLine;
                        sqlText += "    ,@CLAIMNAME2" + Environment.NewLine;
                        sqlText += "    ,@CLAIMSNM" + Environment.NewLine;
                        sqlText += "    ,@RESULTSSECTCD" + Environment.NewLine;
                        sqlText += "    ,@CUSTOMERCODE" + Environment.NewLine;
                        sqlText += "    ,@CUSTOMERNAME" + Environment.NewLine;
                        sqlText += "    ,@CUSTOMERNAME2" + Environment.NewLine;
                        sqlText += "    ,@CUSTOMERSNM" + Environment.NewLine;
                        sqlText += "    ,@ADDUPDATE" + Environment.NewLine;
                        sqlText += "    ,@ADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += "    ,@LASTTIMEDEMAND" + Environment.NewLine;
                        sqlText += "    ,@THISTIMEFEEDMDNRML" + Environment.NewLine;
                        sqlText += "    ,@THISTIMEDISDMDNRML" + Environment.NewLine;
                        sqlText += "    ,@THISTIMEDMDNRML" + Environment.NewLine;
                        sqlText += "    ,@THISTIMETTLBLCDMD" + Environment.NewLine;
                        sqlText += "    ,@OFSTHISTIMESALES" + Environment.NewLine;
                        sqlText += "    ,@OFSTHISSALESTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDOFFSETINTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@OFFSETOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@OFFSETINTAX" + Environment.NewLine;
                        sqlText += "    ,@THISTIMESALES" + Environment.NewLine;
                        sqlText += "    ,@THISSALESTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDSALESOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDSALESINTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDSALESTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@SALESOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@SALESINTAX" + Environment.NewLine;
                        sqlText += "    ,@THISSALESPRICRGDS" + Environment.NewLine;
                        sqlText += "    ,@THISSALESPRCTAXRGDS" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDRETINTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@TTLRETOUTERTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLRETINNERTAX" + Environment.NewLine;
                        sqlText += "    ,@THISSALESPRICDIS" + Environment.NewLine;
                        sqlText += "    ,@THISSALESPRCTAXDIS" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDDISINTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@TTLDISOUTERTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLDISINNERTAX" + Environment.NewLine;
                        sqlText += "    ,@TAXADJUST" + Environment.NewLine;
                        sqlText += "    ,@BALANCEADJUST" + Environment.NewLine;
                        sqlText += "    ,@AFCALDEMANDPRICE" + Environment.NewLine;
                        sqlText += "    ,@ACPODRTTL2TMBFBLDMD" + Environment.NewLine;
                        sqlText += "    ,@ACPODRTTL3TMBFBLDMD" + Environment.NewLine;
                        sqlText += "    ,@CADDUPUPDEXECDATE" + Environment.NewLine;
                        sqlText += "    ,@STARTCADDUPUPDDATE" + Environment.NewLine;
                        sqlText += "    ,@LASTCADDUPUPDDATE" + Environment.NewLine;
                        sqlText += "    ,@SALESSLIPCOUNT" + Environment.NewLine;
                        sqlText += "    ,@BILLPRINTDATE" + Environment.NewLine;
                        sqlText += "    ,@EXPECTEDDEPOSITDATE" + Environment.NewLine;
                        sqlText += "    ,@COLLECTCOND" + Environment.NewLine;
                        sqlText += "    ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                        sqlText += "    ,@CONSTAXRATE" + Environment.NewLine;
                        sqlText += "    ,@FRACTIONPROCCD" + Environment.NewLine;
                        // ADD 2009/06/18 >>>
                        sqlText += "    ,@BILLNO" + Environment.NewLine;
                        // ADD 2009/06/18 <<<
                        sqlText += " )" + Environment.NewLine;
                        #endregion
                        using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                        // 2008.07.18 upd end ---------------------------------------------------------------------<<
                        
                        {
                            sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450 
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custDmdPrcWork;
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
                            SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                            SqlParameter paraClaimName = sqlCommand.Parameters.Add("@CLAIMNAME", SqlDbType.NVarChar);
                            SqlParameter paraClaimName2 = sqlCommand.Parameters.Add("@CLAIMNAME2", SqlDbType.NVarChar);
                            SqlParameter paraClaimSnm = sqlCommand.Parameters.Add("@CLAIMSNM", SqlDbType.NVarChar);
                            SqlParameter paraResultsSectCd = sqlCommand.Parameters.Add("@RESULTSSECTCD", SqlDbType.NChar);
                            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                            SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                            SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                            SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                            SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                            SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                            SqlParameter paraLastTimeDemand = sqlCommand.Parameters.Add("@LASTTIMEDEMAND", SqlDbType.BigInt);
                            SqlParameter paraThisTimeFeeDmdNrml = sqlCommand.Parameters.Add("@THISTIMEFEEDMDNRML", SqlDbType.BigInt);
                            SqlParameter paraThisTimeDisDmdNrml = sqlCommand.Parameters.Add("@THISTIMEDISDMDNRML", SqlDbType.BigInt);
                            SqlParameter paraThisTimeDmdNrml = sqlCommand.Parameters.Add("@THISTIMEDMDNRML", SqlDbType.BigInt);
                            SqlParameter paraThisTimeTtlBlcDmd = sqlCommand.Parameters.Add("@THISTIMETTLBLCDMD", SqlDbType.BigInt);
                            SqlParameter paraOfsThisTimeSales = sqlCommand.Parameters.Add("@OFSTHISTIMESALES", SqlDbType.BigInt);
                            SqlParameter paraOfsThisSalesTax = sqlCommand.Parameters.Add("@OFSTHISSALESTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedOffsetOutTax = sqlCommand.Parameters.Add("@ITDEDOFFSETOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedOffsetInTax = sqlCommand.Parameters.Add("@ITDEDOFFSETINTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedOffsetTaxFree = sqlCommand.Parameters.Add("@ITDEDOFFSETTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraOffsetOutTax = sqlCommand.Parameters.Add("@OFFSETOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraOffsetInTax = sqlCommand.Parameters.Add("@OFFSETINTAX", SqlDbType.BigInt);
                            SqlParameter paraThisTimeSales = sqlCommand.Parameters.Add("@THISTIMESALES", SqlDbType.BigInt);
                            SqlParameter paraThisSalesTax = sqlCommand.Parameters.Add("@THISSALESTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedSalesOutTax = sqlCommand.Parameters.Add("@ITDEDSALESOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedSalesInTax = sqlCommand.Parameters.Add("@ITDEDSALESINTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedSalesTaxFree = sqlCommand.Parameters.Add("@ITDEDSALESTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraSalesOutTax = sqlCommand.Parameters.Add("@SALESOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraSalesInTax = sqlCommand.Parameters.Add("@SALESINTAX", SqlDbType.BigInt);
                            SqlParameter paraThisSalesPricRgds = sqlCommand.Parameters.Add("@THISSALESPRICRGDS", SqlDbType.BigInt);
                            SqlParameter paraThisSalesPrcTaxRgds = sqlCommand.Parameters.Add("@THISSALESPRCTAXRGDS", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedRetOutTax = sqlCommand.Parameters.Add("@TTLITDEDRETOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedRetInTax = sqlCommand.Parameters.Add("@TTLITDEDRETINTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedRetTaxFree = sqlCommand.Parameters.Add("@TTLITDEDRETTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraTtlRetOuterTax = sqlCommand.Parameters.Add("@TTLRETOUTERTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlRetInnerTax = sqlCommand.Parameters.Add("@TTLRETINNERTAX", SqlDbType.BigInt);
                            SqlParameter paraThisSalesPricDis = sqlCommand.Parameters.Add("@THISSALESPRICDIS", SqlDbType.BigInt);
                            SqlParameter paraThisSalesPrcTaxDis = sqlCommand.Parameters.Add("@THISSALESPRCTAXDIS", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedDisOutTax = sqlCommand.Parameters.Add("@TTLITDEDDISOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedDisInTax = sqlCommand.Parameters.Add("@TTLITDEDDISINTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedDisTaxFree = sqlCommand.Parameters.Add("@TTLITDEDDISTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraTtlDisOuterTax = sqlCommand.Parameters.Add("@TTLDISOUTERTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlDisInnerTax = sqlCommand.Parameters.Add("@TTLDISINNERTAX", SqlDbType.BigInt);
                            SqlParameter paraTaxAdjust = sqlCommand.Parameters.Add("@TAXADJUST", SqlDbType.BigInt);
                            SqlParameter paraBalanceAdjust = sqlCommand.Parameters.Add("@BALANCEADJUST", SqlDbType.BigInt);
                            SqlParameter paraAfCalDemandPrice = sqlCommand.Parameters.Add("@AFCALDEMANDPRICE", SqlDbType.BigInt);
                            SqlParameter paraAcpOdrTtl2TmBfBlDmd = sqlCommand.Parameters.Add("@ACPODRTTL2TMBFBLDMD", SqlDbType.BigInt);
                            SqlParameter paraAcpOdrTtl3TmBfBlDmd = sqlCommand.Parameters.Add("@ACPODRTTL3TMBFBLDMD", SqlDbType.BigInt);
                            SqlParameter paraCAddUpUpdExecDate = sqlCommand.Parameters.Add("@CADDUPUPDEXECDATE", SqlDbType.Int);
                            SqlParameter paraStartCAddUpUpdDate = sqlCommand.Parameters.Add("@STARTCADDUPUPDDATE", SqlDbType.Int);
                            SqlParameter paraLastCAddUpUpdDate = sqlCommand.Parameters.Add("@LASTCADDUPUPDDATE", SqlDbType.Int);
                            SqlParameter paraSalesSlipCount = sqlCommand.Parameters.Add("@SALESSLIPCOUNT", SqlDbType.Int);
                            SqlParameter paraBillPrintDate = sqlCommand.Parameters.Add("@BILLPRINTDATE", SqlDbType.Int);
                            SqlParameter paraExpectedDepositDate = sqlCommand.Parameters.Add("@EXPECTEDDEPOSITDATE", SqlDbType.Int);
                            SqlParameter paraCollectCond = sqlCommand.Parameters.Add("@COLLECTCOND", SqlDbType.Int);
                            SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                            SqlParameter paraConsTaxRate = sqlCommand.Parameters.Add("@CONSTAXRATE", SqlDbType.Float);
                            SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                            // ADD 2009/06/18 >>>
                            SqlParameter paraBillNo = sqlCommand.Parameters.Add("@BILLNO", SqlDbType.Int);
                            // ADD 2009/06/18 <<<
                            #endregion

                            #region Parameterオブジェクト設定
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custDmdPrcWork.CreateDateTime);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custDmdPrcWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(custDmdPrcWork.FileHeaderGuid);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.LogicalDeleteCode);
                            paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                            paraClaimCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                            paraClaimName.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.CustomerName);
                            paraClaimName2.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.CustomerName2);
                            paraClaimSnm.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.CustomerSnm);
                            
                            // 修正 2008.12.10 >>>
                            //if (custDmdPrcWork.ResultsSectCd == string.Empty)
                            //{
                            //    paraResultsSectCd.Value = string.Empty;
                            //}
                            //else
                            //{
                            //    paraResultsSectCd.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.ResultsSectCd);
                            //}
                            paraResultsSectCd.Value = "00";
                            // 修正 2008.12.10 <<<
                            paraCustomerCode.Value = 0;
                            paraCustomerName.Value = "";
                            paraCustomerName2.Value = "";
                            paraCustomerSnm.Value = "";
                            paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);
                            paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(custDmdPrcWork.AddUpYearMonth);
                            paraLastTimeDemand.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.LastTimeDemand);
                            paraThisTimeFeeDmdNrml.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeFeeDmdNrml);
                            paraThisTimeDisDmdNrml.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeDisDmdNrml);
                            paraThisTimeDmdNrml.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeDmdNrml);
                            paraThisTimeTtlBlcDmd.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeTtlBlcDmd);
                            paraOfsThisTimeSales.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.OfsThisTimeSales);
                            paraOfsThisSalesTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.OfsThisSalesTax);
                            paraItdedOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedOffsetOutTax);
                            paraItdedOffsetInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedOffsetInTax);
                            paraItdedOffsetTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedOffsetTaxFree);
                            paraOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.OffsetOutTax);
                            paraOffsetInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.OffsetInTax);
                            paraThisTimeSales.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeSales);
                            paraThisSalesTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesTax);
                            paraItdedSalesOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedSalesOutTax);
                            paraItdedSalesInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedSalesInTax);
                            paraItdedSalesTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedSalesTaxFree);
                            paraSalesOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.SalesOutTax);
                            paraSalesInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.SalesInTax);
                            paraThisSalesPricRgds.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesPricRgds);
                            paraThisSalesPrcTaxRgds.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesPrcTaxRgds);
                            paraTtlItdedRetOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedRetOutTax);
                            paraTtlItdedRetInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedRetInTax);
                            paraTtlItdedRetTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedRetTaxFree);
                            paraTtlRetOuterTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlRetOuterTax);
                            paraTtlRetInnerTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlRetInnerTax);
                            paraThisSalesPricDis.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesPricDis);
                            paraThisSalesPrcTaxDis.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesPrcTaxDis);
                            paraTtlItdedDisOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedDisOutTax);
                            paraTtlItdedDisInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedDisInTax);
                            paraTtlItdedDisTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedDisTaxFree);
                            paraTtlDisOuterTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlDisOuterTax);
                            paraTtlDisInnerTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlDisInnerTax);
                            // 修正 2008.12.10 >>>
                            //paraTaxAdjust.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TaxAdjust);
                            //paraBalanceAdjust.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.BalanceAdjust);
                            paraTaxAdjust.Value = 0;
                            paraBalanceAdjust.Value = 0;
                            // 修正 2008.12.10 <<<
                            paraAfCalDemandPrice.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.AfCalDemandPrice);
                            paraAcpOdrTtl2TmBfBlDmd.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.AcpOdrTtl2TmBfBlDmd);
                            paraAcpOdrTtl3TmBfBlDmd.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.AcpOdrTtl3TmBfBlDmd);
                            paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.CAddUpUpdExecDate);
                            paraStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.StartCAddUpUpdDate);
                            paraLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.LastCAddUpUpdDate);
                            paraSalesSlipCount.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.SalesSlipCount);
                            paraBillPrintDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.BillPrintDate);
                            paraExpectedDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.ExpectedDepositDate);
                            paraCollectCond.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CollectCond);
                            paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ConsTaxLayMethod);
                            paraConsTaxRate.Value = SqlDataMediator.SqlSetDouble(custDmdPrcWork.ConsTaxRate);
                            paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.FractionProcCd);
                            // ADD 2009/06/18 >>>
                            paraBillNo.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.BillNo);
                            // ADD 2009/06/18 <<<
                            #endregion

                            sqlCommand.ExecuteNonQuery();
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }

                // ↓ 2007.09.14 980081 a 請求先子レコード作成対応
                for (int i = 0; i < custDmdPrcChildWorkList.Count; i++)
                {
                    CustDmdPrcWork custDmdPrcWork = new CustDmdPrcWork();
                    custDmdPrcWork = custDmdPrcChildWorkList[i] as CustDmdPrcWork;
                    if (custDmdPrcWork.UpdateStatus == 0)
                    {
                        // 2008.07.18 upd start ------------------------------------------------------->>
                        //using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO CUSTDMDPRCRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPSECCODERF, CLAIMCODERF, CLAIMNAMERF, CLAIMNAME2RF, CLAIMSNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, ADDUPDATERF, ADDUPYEARMONTHRF, LASTTIMEDEMANDRF, THISTIMEFEEDMDNRMLRF, THISTIMEDISDMDNRMLRF, THISTIMEDMDNRMLRF, THISTIMETTLBLCDMDRF, OFSTHISTIMESALESRF, OFSTHISSALESTAXRF, ITDEDOFFSETOUTTAXRF, ITDEDOFFSETINTAXRF, ITDEDOFFSETTAXFREERF, OFFSETOUTTAXRF, OFFSETINTAXRF, THISTIMESALESRF, THISSALESTAXRF, ITDEDSALESOUTTAXRF, ITDEDSALESINTAXRF, ITDEDSALESTAXFREERF, SALESOUTTAXRF, SALESINTAXRF, THISSALESPRICRGDSRF, THISSALESPRCTAXRGDSRF, TTLITDEDRETOUTTAXRF, TTLITDEDRETINTAXRF, TTLITDEDRETTAXFREERF, TTLRETOUTERTAXRF, TTLRETINNERTAXRF, THISSALESPRICDISRF, THISSALESPRCTAXDISRF, TTLITDEDDISOUTTAXRF, TTLITDEDDISINTAXRF, TTLITDEDDISTAXFREERF, TTLDISOUTERTAXRF, TTLDISINNERTAXRF, THISPAYOFFSETRF, THISPAYOFFSETTAXRF, ITDEDPAYMOUTTAXRF, ITDEDPAYMINTAXRF, ITDEDPAYMTAXFREERF, PAYMENTOUTTAXRF, PAYMENTINTAXRF, TAXADJUSTRF, BALANCEADJUSTRF, AFCALDEMANDPRICERF, ACPODRTTL2TMBFBLDMDRF, ACPODRTTL3TMBFBLDMDRF, CADDUPUPDEXECDATERF, STARTCADDUPUPDDATERF, LASTCADDUPUPDDATERF, SALESSLIPCOUNTRF, BILLPRINTDATERF, EXPECTEDDEPOSITDATERF, COLLECTCONDRF, CONSTAXLAYMETHODRF, CONSTAXRATERF, FRACTIONPROCCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ADDUPSECCODE, @CLAIMCODE, @CLAIMNAME, @CLAIMNAME2, @CLAIMSNM, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @CUSTOMERSNM, @ADDUPDATE, @ADDUPYEARMONTH, @LASTTIMEDEMAND, @THISTIMEFEEDMDNRML, @THISTIMEDISDMDNRML, @THISTIMEDMDNRML, @THISTIMETTLBLCDMD, @OFSTHISTIMESALES, @OFSTHISSALESTAX, @ITDEDOFFSETOUTTAX, @ITDEDOFFSETINTAX, @ITDEDOFFSETTAXFREE, @OFFSETOUTTAX, @OFFSETINTAX, @THISTIMESALES, @THISSALESTAX, @ITDEDSALESOUTTAX, @ITDEDSALESINTAX, @ITDEDSALESTAXFREE, @SALESOUTTAX, @SALESINTAX, @THISSALESPRICRGDS, @THISSALESPRCTAXRGDS, @TTLITDEDRETOUTTAX, @TTLITDEDRETINTAX, @TTLITDEDRETTAXFREE, @TTLRETOUTERTAX, @TTLRETINNERTAX, @THISSALESPRICDIS, @THISSALESPRCTAXDIS, @TTLITDEDDISOUTTAX, @TTLITDEDDISINTAX, @TTLITDEDDISTAXFREE, @TTLDISOUTERTAX, @TTLDISINNERTAX, @THISPAYOFFSET, @THISPAYOFFSETTAX, @ITDEDPAYMOUTTAX, @ITDEDPAYMINTAX, @ITDEDPAYMTAXFREE, @PAYMENTOUTTAX, @PAYMENTINTAX, @TAXADJUST, @BALANCEADJUST, @AFCALDEMANDPRICE, @ACPODRTTL2TMBFBLDMD, @ACPODRTTL3TMBFBLDMD, @CADDUPUPDEXECDATE, @STARTCADDUPUPDDATE, @LASTCADDUPUPDDATE, @SALESSLIPCOUNT, @BILLPRINTDATE, @EXPECTEDDEPOSITDATE, @COLLECTCOND, @CONSTAXLAYMETHOD, @CONSTAXRATE, @FRACTIONPROCCD)", sqlConnection, sqlTransaction))
                        #region INSERT
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO CUSTDMDPRCRF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "    ,ADDUPSECCODERF" + Environment.NewLine;
                        sqlText += "    ,CLAIMCODERF" + Environment.NewLine;
                        sqlText += "    ,CLAIMNAMERF" + Environment.NewLine;
                        sqlText += "    ,CLAIMNAME2RF" + Environment.NewLine;
                        sqlText += "    ,CLAIMSNMRF" + Environment.NewLine;
                        sqlText += "    ,RESULTSSECTCDRF" + Environment.NewLine;
                        sqlText += "    ,CUSTOMERCODERF" + Environment.NewLine;
                        sqlText += "    ,CUSTOMERNAMERF" + Environment.NewLine;
                        sqlText += "    ,CUSTOMERNAME2RF" + Environment.NewLine;
                        sqlText += "    ,CUSTOMERSNMRF" + Environment.NewLine;
                        sqlText += "    ,ADDUPDATERF" + Environment.NewLine;
                        sqlText += "    ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        sqlText += "    ,LASTTIMEDEMANDRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMEDMDNRMLRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMETTLBLCDMDRF" + Environment.NewLine;
                        sqlText += "    ,OFSTHISTIMESALESRF" + Environment.NewLine;
                        sqlText += "    ,OFSTHISSALESTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDOFFSETOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDOFFSETINTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDOFFSETTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,OFFSETOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,OFFSETINTAXRF" + Environment.NewLine;
                        sqlText += "    ,THISTIMESALESRF" + Environment.NewLine;
                        sqlText += "    ,THISSALESTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDSALESOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDSALESINTAXRF" + Environment.NewLine;
                        sqlText += "    ,ITDEDSALESTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,SALESOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,SALESINTAXRF" + Environment.NewLine;
                        sqlText += "    ,THISSALESPRICRGDSRF" + Environment.NewLine;
                        sqlText += "    ,THISSALESPRCTAXRGDSRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDRETOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDRETINTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDRETTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,TTLRETOUTERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLRETINNERTAXRF" + Environment.NewLine;
                        sqlText += "    ,THISSALESPRICDISRF" + Environment.NewLine;
                        sqlText += "    ,THISSALESPRCTAXDISRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDDISOUTTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDDISINTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLITDEDDISTAXFREERF" + Environment.NewLine;
                        sqlText += "    ,TTLDISOUTERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TTLDISINNERTAXRF" + Environment.NewLine;
                        sqlText += "    ,TAXADJUSTRF" + Environment.NewLine;
                        sqlText += "    ,BALANCEADJUSTRF" + Environment.NewLine;
                        sqlText += "    ,AFCALDEMANDPRICERF" + Environment.NewLine;
                        sqlText += "    ,ACPODRTTL2TMBFBLDMDRF" + Environment.NewLine;
                        sqlText += "    ,ACPODRTTL3TMBFBLDMDRF" + Environment.NewLine;
                        sqlText += "    ,CADDUPUPDEXECDATERF" + Environment.NewLine;
                        sqlText += "    ,STARTCADDUPUPDDATERF" + Environment.NewLine;
                        sqlText += "    ,LASTCADDUPUPDDATERF" + Environment.NewLine;
                        sqlText += "    ,SALESSLIPCOUNTRF" + Environment.NewLine;
                        sqlText += "    ,BILLPRINTDATERF" + Environment.NewLine;
                        sqlText += "    ,EXPECTEDDEPOSITDATERF" + Environment.NewLine;
                        sqlText += "    ,COLLECTCONDRF" + Environment.NewLine;
                        sqlText += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                        sqlText += "    ,CONSTAXRATERF" + Environment.NewLine;
                        sqlText += "    ,FRACTIONPROCCDRF" + Environment.NewLine;
                        // ADD 2009/06/18 >>>
                        sqlText += "    ,BILLNORF" + Environment.NewLine;
                        // ADD 2009/06/18 <<<
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
                        sqlText += "    ,@CLAIMCODE" + Environment.NewLine;
                        sqlText += "    ,@CLAIMNAME" + Environment.NewLine;
                        sqlText += "    ,@CLAIMNAME2" + Environment.NewLine;
                        sqlText += "    ,@CLAIMSNM" + Environment.NewLine;
                        sqlText += "    ,@RESULTSSECTCD" + Environment.NewLine;
                        sqlText += "    ,@CUSTOMERCODE" + Environment.NewLine;
                        sqlText += "    ,@CUSTOMERNAME" + Environment.NewLine;
                        sqlText += "    ,@CUSTOMERNAME2" + Environment.NewLine;
                        sqlText += "    ,@CUSTOMERSNM" + Environment.NewLine;
                        sqlText += "    ,@ADDUPDATE" + Environment.NewLine;
                        sqlText += "    ,@ADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += "    ,@LASTTIMEDEMAND" + Environment.NewLine;
                        sqlText += "    ,@THISTIMEFEEDMDNRML" + Environment.NewLine;
                        sqlText += "    ,@THISTIMEDISDMDNRML" + Environment.NewLine;
                        sqlText += "    ,@THISTIMEDMDNRML" + Environment.NewLine;
                        sqlText += "    ,@THISTIMETTLBLCDMD" + Environment.NewLine;
                        sqlText += "    ,@OFSTHISTIMESALES" + Environment.NewLine;
                        sqlText += "    ,@OFSTHISSALESTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDOFFSETOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDOFFSETINTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDOFFSETTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@OFFSETOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@OFFSETINTAX" + Environment.NewLine;
                        sqlText += "    ,@THISTIMESALES" + Environment.NewLine;
                        sqlText += "    ,@THISSALESTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDSALESOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDSALESINTAX" + Environment.NewLine;
                        sqlText += "    ,@ITDEDSALESTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@SALESOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@SALESINTAX" + Environment.NewLine;
                        sqlText += "    ,@THISSALESPRICRGDS" + Environment.NewLine;
                        sqlText += "    ,@THISSALESPRCTAXRGDS" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDRETOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDRETINTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDRETTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@TTLRETOUTERTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLRETINNERTAX" + Environment.NewLine;
                        sqlText += "    ,@THISSALESPRICDIS" + Environment.NewLine;
                        sqlText += "    ,@THISSALESPRCTAXDIS" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDDISOUTTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDDISINTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLITDEDDISTAXFREE" + Environment.NewLine;
                        sqlText += "    ,@TTLDISOUTERTAX" + Environment.NewLine;
                        sqlText += "    ,@TTLDISINNERTAX" + Environment.NewLine;
                        sqlText += "    ,@TAXADJUST" + Environment.NewLine;
                        sqlText += "    ,@BALANCEADJUST" + Environment.NewLine;
                        sqlText += "    ,@AFCALDEMANDPRICE" + Environment.NewLine;
                        sqlText += "    ,@ACPODRTTL2TMBFBLDMD" + Environment.NewLine;
                        sqlText += "    ,@ACPODRTTL3TMBFBLDMD" + Environment.NewLine;
                        sqlText += "    ,@CADDUPUPDEXECDATE" + Environment.NewLine;
                        sqlText += "    ,@STARTCADDUPUPDDATE" + Environment.NewLine;
                        sqlText += "    ,@LASTCADDUPUPDDATE" + Environment.NewLine;
                        sqlText += "    ,@SALESSLIPCOUNT" + Environment.NewLine;
                        sqlText += "    ,@BILLPRINTDATE" + Environment.NewLine;
                        sqlText += "    ,@EXPECTEDDEPOSITDATE" + Environment.NewLine;
                        sqlText += "    ,@COLLECTCOND" + Environment.NewLine;
                        sqlText += "    ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                        sqlText += "    ,@CONSTAXRATE" + Environment.NewLine;
                        sqlText += "    ,@FRACTIONPROCCD" + Environment.NewLine;
                        // ADD 2009/06/18 >>>
                        sqlText += "    ,@BILLNO" + Environment.NewLine;
                        // ADD 2009/06/18 <<<

                        sqlText += " )" + Environment.NewLine;
                        #endregion
                        using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                        // 2008.07.18 upd end ---------------------------------------------------------<<
                        {
                            sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custDmdPrcWork;
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
                            SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                            SqlParameter paraClaimName = sqlCommand.Parameters.Add("@CLAIMNAME", SqlDbType.NVarChar);
                            SqlParameter paraClaimName2 = sqlCommand.Parameters.Add("@CLAIMNAME2", SqlDbType.NVarChar);
                            SqlParameter paraClaimSnm = sqlCommand.Parameters.Add("@CLAIMSNM", SqlDbType.NVarChar);
                            SqlParameter paraResultsSectCd = sqlCommand.Parameters.Add("@RESULTSSECTCD", SqlDbType.NChar);
                            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                            SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                            SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                            SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                            SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                            SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                            SqlParameter paraLastTimeDemand = sqlCommand.Parameters.Add("@LASTTIMEDEMAND", SqlDbType.BigInt);
                            SqlParameter paraThisTimeFeeDmdNrml = sqlCommand.Parameters.Add("@THISTIMEFEEDMDNRML", SqlDbType.BigInt);
                            SqlParameter paraThisTimeDisDmdNrml = sqlCommand.Parameters.Add("@THISTIMEDISDMDNRML", SqlDbType.BigInt);
                            SqlParameter paraThisTimeDmdNrml = sqlCommand.Parameters.Add("@THISTIMEDMDNRML", SqlDbType.BigInt);
                            SqlParameter paraThisTimeTtlBlcDmd = sqlCommand.Parameters.Add("@THISTIMETTLBLCDMD", SqlDbType.BigInt);
                            SqlParameter paraOfsThisTimeSales = sqlCommand.Parameters.Add("@OFSTHISTIMESALES", SqlDbType.BigInt);
                            SqlParameter paraOfsThisSalesTax = sqlCommand.Parameters.Add("@OFSTHISSALESTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedOffsetOutTax = sqlCommand.Parameters.Add("@ITDEDOFFSETOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedOffsetInTax = sqlCommand.Parameters.Add("@ITDEDOFFSETINTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedOffsetTaxFree = sqlCommand.Parameters.Add("@ITDEDOFFSETTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraOffsetOutTax = sqlCommand.Parameters.Add("@OFFSETOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraOffsetInTax = sqlCommand.Parameters.Add("@OFFSETINTAX", SqlDbType.BigInt);
                            SqlParameter paraThisTimeSales = sqlCommand.Parameters.Add("@THISTIMESALES", SqlDbType.BigInt);
                            SqlParameter paraThisSalesTax = sqlCommand.Parameters.Add("@THISSALESTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedSalesOutTax = sqlCommand.Parameters.Add("@ITDEDSALESOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedSalesInTax = sqlCommand.Parameters.Add("@ITDEDSALESINTAX", SqlDbType.BigInt);
                            SqlParameter paraItdedSalesTaxFree = sqlCommand.Parameters.Add("@ITDEDSALESTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraSalesOutTax = sqlCommand.Parameters.Add("@SALESOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraSalesInTax = sqlCommand.Parameters.Add("@SALESINTAX", SqlDbType.BigInt);
                            SqlParameter paraThisSalesPricRgds = sqlCommand.Parameters.Add("@THISSALESPRICRGDS", SqlDbType.BigInt);
                            SqlParameter paraThisSalesPrcTaxRgds = sqlCommand.Parameters.Add("@THISSALESPRCTAXRGDS", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedRetOutTax = sqlCommand.Parameters.Add("@TTLITDEDRETOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedRetInTax = sqlCommand.Parameters.Add("@TTLITDEDRETINTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedRetTaxFree = sqlCommand.Parameters.Add("@TTLITDEDRETTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraTtlRetOuterTax = sqlCommand.Parameters.Add("@TTLRETOUTERTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlRetInnerTax = sqlCommand.Parameters.Add("@TTLRETINNERTAX", SqlDbType.BigInt);
                            SqlParameter paraThisSalesPricDis = sqlCommand.Parameters.Add("@THISSALESPRICDIS", SqlDbType.BigInt);
                            SqlParameter paraThisSalesPrcTaxDis = sqlCommand.Parameters.Add("@THISSALESPRCTAXDIS", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedDisOutTax = sqlCommand.Parameters.Add("@TTLITDEDDISOUTTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedDisInTax = sqlCommand.Parameters.Add("@TTLITDEDDISINTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlItdedDisTaxFree = sqlCommand.Parameters.Add("@TTLITDEDDISTAXFREE", SqlDbType.BigInt);
                            SqlParameter paraTtlDisOuterTax = sqlCommand.Parameters.Add("@TTLDISOUTERTAX", SqlDbType.BigInt);
                            SqlParameter paraTtlDisInnerTax = sqlCommand.Parameters.Add("@TTLDISINNERTAX", SqlDbType.BigInt);
                            SqlParameter paraTaxAdjust = sqlCommand.Parameters.Add("@TAXADJUST", SqlDbType.BigInt);
                            SqlParameter paraBalanceAdjust = sqlCommand.Parameters.Add("@BALANCEADJUST", SqlDbType.BigInt);
                            SqlParameter paraAfCalDemandPrice = sqlCommand.Parameters.Add("@AFCALDEMANDPRICE", SqlDbType.BigInt);
                            SqlParameter paraAcpOdrTtl2TmBfBlDmd = sqlCommand.Parameters.Add("@ACPODRTTL2TMBFBLDMD", SqlDbType.BigInt);
                            SqlParameter paraAcpOdrTtl3TmBfBlDmd = sqlCommand.Parameters.Add("@ACPODRTTL3TMBFBLDMD", SqlDbType.BigInt);
                            SqlParameter paraCAddUpUpdExecDate = sqlCommand.Parameters.Add("@CADDUPUPDEXECDATE", SqlDbType.Int);
                            SqlParameter paraStartCAddUpUpdDate = sqlCommand.Parameters.Add("@STARTCADDUPUPDDATE", SqlDbType.Int);
                            SqlParameter paraLastCAddUpUpdDate = sqlCommand.Parameters.Add("@LASTCADDUPUPDDATE", SqlDbType.Int);
                            SqlParameter paraSalesSlipCount = sqlCommand.Parameters.Add("@SALESSLIPCOUNT", SqlDbType.Int);
                            SqlParameter paraBillPrintDate = sqlCommand.Parameters.Add("@BILLPRINTDATE", SqlDbType.Int);
                            SqlParameter paraExpectedDepositDate = sqlCommand.Parameters.Add("@EXPECTEDDEPOSITDATE", SqlDbType.Int);
                            SqlParameter paraCollectCond = sqlCommand.Parameters.Add("@COLLECTCOND", SqlDbType.Int);
                            SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                            SqlParameter paraConsTaxRate = sqlCommand.Parameters.Add("@CONSTAXRATE", SqlDbType.Float);
                            SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                            // ADD 2009/06/18 >>>
                            SqlParameter paraBillNo = sqlCommand.Parameters.Add("@BILLNO", SqlDbType.Int);
                            // ADD 2009/06/18 <<<
                            #endregion

                            #region Parameterオブジェクト設定
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custDmdPrcWork.CreateDateTime);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custDmdPrcWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(custDmdPrcWork.FileHeaderGuid);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.LogicalDeleteCode);
                            paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                            paraClaimCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                            paraClaimName.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.ClaimName);
                            paraClaimName2.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.ClaimName2);
                            paraClaimSnm.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.ClaimSnm);
                            if (custDmdPrcWork.ResultsSectCd == string.Empty)
                            {
                                paraResultsSectCd.Value = string.Empty;
                            }
                            else
                            {
                                paraResultsSectCd.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.ResultsSectCd);
                            }
                            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                            paraCustomerName.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.CustomerName);
                            paraCustomerName2.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.CustomerName2);
                            paraCustomerSnm.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.CustomerSnm);
                            paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);
                            paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(custDmdPrcWork.AddUpYearMonth);
                            // 修正 2008.12.10 >>>
                            //paraLastTimeDemand.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.LastTimeDemand);
                            //paraThisTimeFeeDmdNrml.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeFeeDmdNrml);
                            //paraThisTimeDisDmdNrml.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeDisDmdNrml);
                            //paraThisTimeDmdNrml.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeDmdNrml);
                            //paraThisTimeTtlBlcDmd.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeTtlBlcDmd);
                            paraLastTimeDemand.Value = 0;
                            paraThisTimeFeeDmdNrml.Value = 0;
                            paraThisTimeDisDmdNrml.Value = 0;
                            paraThisTimeDmdNrml.Value = 0;
                            paraThisTimeTtlBlcDmd.Value = 0;
                            // 修正 2008.12.10 <<<
                            paraOfsThisTimeSales.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.OfsThisTimeSales);
                            paraOfsThisSalesTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.OfsThisSalesTax);
                            paraItdedOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedOffsetOutTax);
                            paraItdedOffsetInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedOffsetInTax);
                            paraItdedOffsetTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedOffsetTaxFree);
                            paraOffsetOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.OffsetOutTax);
                            paraOffsetInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.OffsetInTax);
                            paraThisTimeSales.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisTimeSales);
                            paraThisSalesTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesTax);
                            paraItdedSalesOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedSalesOutTax);
                            paraItdedSalesInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedSalesInTax);
                            paraItdedSalesTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ItdedSalesTaxFree);
                            paraSalesOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.SalesOutTax);
                            paraSalesInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.SalesInTax);
                            paraThisSalesPricRgds.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesPricRgds);
                            paraThisSalesPrcTaxRgds.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesPrcTaxRgds);
                            paraTtlItdedRetOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedRetOutTax);
                            paraTtlItdedRetInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedRetInTax);
                            paraTtlItdedRetTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedRetTaxFree);
                            paraTtlRetOuterTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlRetOuterTax);
                            paraTtlRetInnerTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlRetInnerTax);
                            paraThisSalesPricDis.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesPricDis);
                            paraThisSalesPrcTaxDis.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.ThisSalesPrcTaxDis);
                            paraTtlItdedDisOutTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedDisOutTax);
                            paraTtlItdedDisInTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedDisInTax);
                            paraTtlItdedDisTaxFree.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlItdedDisTaxFree);
                            paraTtlDisOuterTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlDisOuterTax);
                            paraTtlDisInnerTax.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TtlDisInnerTax);
                            // 修正 2008.12.10 >>>
                            //paraTaxAdjust.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.TaxAdjust);
                            //paraBalanceAdjust.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.BalanceAdjust);
                            //paraAfCalDemandPrice.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.AfCalDemandPrice);
                            //paraAcpOdrTtl2TmBfBlDmd.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.AcpOdrTtl2TmBfBlDmd);
                            //paraAcpOdrTtl3TmBfBlDmd.Value = SqlDataMediator.SqlSetInt64(custDmdPrcWork.AcpOdrTtl3TmBfBlDmd);
                            paraTaxAdjust.Value = 0;
                            paraBalanceAdjust.Value = 0;
                            paraAfCalDemandPrice.Value = 0;
                            paraAcpOdrTtl2TmBfBlDmd.Value = 0;
                            paraAcpOdrTtl3TmBfBlDmd.Value = 0;
                            // 修正 2008.12.10 <<<
                            paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.CAddUpUpdExecDate);
                            paraStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.StartCAddUpUpdDate);
                            paraLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.LastCAddUpUpdDate);
                            paraSalesSlipCount.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.SalesSlipCount);
                            paraBillPrintDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.BillPrintDate);
                            paraExpectedDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.ExpectedDepositDate);
                            paraCollectCond.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CollectCond);
                            paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ConsTaxLayMethod);
                            paraConsTaxRate.Value = SqlDataMediator.SqlSetDouble(custDmdPrcWork.ConsTaxRate);
                            paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.FractionProcCd);
                            // ADD 2009/06/18 >>>
                            paraBillNo.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.BillNo);
                            // ADD 2009/06/18 <<<
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

        // 2008.07.18 add start --------------------------------------->>
        /// <summary>
        /// 請求入金集計データを更新します
        /// </summary>
        /// <param name="dmdDepoTotalWorkList">請求入金集計データList</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 請求入金集計データを更新します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.07.18</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        /// </remarks>
        private int WriteDepoTotalPrc(ref ArrayList dmdDepoTotalWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            string sqlText = string.Empty;

            //Deleteコマンドの生成
            try
            {
                for (int i = 0; i < dmdDepoTotalWorkList.Count; i++)
                {
                    DmdDepoTotalWork dmdDepoTotalWork = dmdDepoTotalWorkList[i] as DmdDepoTotalWork;
                    if (dmdDepoTotalWork.UpdateStatus == 0)
                    {
                        sqlText = string.Empty;
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += " FROM DMDDEPOTOTALRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                        sqlText += "    AND CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                        sqlText += "    AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;
                        //sqlText += "    AND MONEYKINDCODERF=@FINDMONEYKINDCODE" + Environment.NewLine; // ADD 2008.12.10

                        using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                        {
                            //Prameterオブジェクトの作成
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                            SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                            SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                            //SqlParameter findMoneyKindCode = sqlCommand.Parameters.Add("@FINDMONEYKINDCODE", SqlDbType.Int); // ADD 2008.12.10

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.EnterpriseCode);
                            findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.AddUpSecCode);
                            findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.ClaimCode);
                            findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dmdDepoTotalWork.AddUpDate);
                            //findMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.MoneyKindCode); // ADD 2008.12.10

                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }

                for (int i = 0; i < dmdDepoTotalWorkList.Count; i++)
                {
                    DmdDepoTotalWork dmdDepoTotalWork = dmdDepoTotalWorkList[i] as DmdDepoTotalWork;

                    if (dmdDepoTotalWork.UpdateStatus == 0)
                    {
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO DMDDEPOTOTALRF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "    ,ADDUPSECCODERF" + Environment.NewLine;
                        sqlText += "    ,CLAIMCODERF" + Environment.NewLine;
                        sqlText += "    ,CUSTOMERCODERF" + Environment.NewLine;
                        sqlText += "    ,ADDUPDATERF" + Environment.NewLine;
                        sqlText += "    ,MONEYKINDCODERF" + Environment.NewLine;
                        sqlText += "    ,MONEYKINDNAMERF" + Environment.NewLine;
                        sqlText += "    ,MONEYKINDDIVRF" + Environment.NewLine;
                        sqlText += "    ,DEPOSITRF" + Environment.NewLine;
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
                        sqlText += "    ,@CLAIMCODE" + Environment.NewLine;
                        sqlText += "    ,@CUSTOMERCODE" + Environment.NewLine;
                        sqlText += "    ,@ADDUPDATE" + Environment.NewLine;
                        sqlText += "    ,@MONEYKINDCODE" + Environment.NewLine;
                        sqlText += "    ,@MONEYKINDNAME" + Environment.NewLine;
                        sqlText += "    ,@MONEYKINDDIV" + Environment.NewLine;
                        sqlText += "    ,@DEPOSIT" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)dmdDepoTotalWork;
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
                            SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                            SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                            SqlParameter paraMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int);
                            SqlParameter paraMoneyKindName = sqlCommand.Parameters.Add("@MONEYKINDNAME", SqlDbType.NVarChar);
                            SqlParameter paraMoneyKindDiv = sqlCommand.Parameters.Add("@MONEYKINDDIV", SqlDbType.Int);
                            SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                            #endregion

                            #region Parameterオブジェクト設定
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dmdDepoTotalWork.CreateDateTime);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dmdDepoTotalWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dmdDepoTotalWork.FileHeaderGuid);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.LogicalDeleteCode);
                            paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.AddUpSecCode);
                            paraClaimCode.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.ClaimCode);
                            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.CustomerCode);
                            paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dmdDepoTotalWork.AddUpDate);
                            paraMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.MoneyKindCode);
                            paraMoneyKindName.Value = SqlDataMediator.SqlSetString(dmdDepoTotalWork.MoneyKindName);
                            paraMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(dmdDepoTotalWork.MoneyKindDiv);
                            paraDeposit.Value = SqlDataMediator.SqlSetInt64(dmdDepoTotalWork.Deposit);
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

        /// <summary>
        /// 得意先マスタ(伝票番号)を更新します
        /// </summary>
        /// <param name="custDmdPrcWorkList">得意先請求金額マスタList</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(伝票番号)を更新します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.07.18</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        /// </remarks>
        private int WriteCustSlipNoSetPrc(ref ArrayList custDmdPrcWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (custDmdPrcWorkList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                    sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                    for (int i = 0; i < custDmdPrcWorkList.Count; i++)
                    {
                        CustDmdPrcWork custDmdPrcWork = custDmdPrcWorkList[i] as CustDmdPrcWork;

                        if (custDmdPrcWork.CustomerSlipNoDiv == 2)
                        {
                            # region [SELECT文]
                            sqlText = string.Empty;
                            sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += "    ,ADDUPYEARMONTHRF" + Environment.NewLine;
                            sqlText += "    ,PRESENTCUSTSLIPNORF" + Environment.NewLine;
                            sqlText += "    ,STARTCUSTSLIPNORF" + Environment.NewLine;
                            sqlText += "    ,ENDCUSTSLIPNORF" + Environment.NewLine;
                            sqlText += "    ,CUSTSLIPNOHEADERRF" + Environment.NewLine;
                            sqlText += "    ,CUSTSLIPNOFOOTERRF" + Environment.NewLine;
                            sqlText += " FROM CUSTSLIPNOSETRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "    AND ADDUPYEARMONTHRF=DATEADD(MONTH, 1, @FINDADDUPYEARMONTH)" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // Prameterオブジェクトの作成
                            sqlCommand.Parameters.Clear();
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                            SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.DateTime);

                            // Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                            findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(custDmdPrcWork.AddUpYearMonth);

                            myReader = sqlCommand.ExecuteReader();

                            if (myReader.Read())
                            {

                                # region [UPDATE文]
                                sqlText = string.Empty;
                                sqlText += "UPDATE CUSTSLIPNOSETRF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                                sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                sqlText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                                sqlText += " , ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                                sqlText += " , PRESENTCUSTSLIPNORF=@PRESENTCUSTSLIPNO" + Environment.NewLine;
                                sqlText += " , STARTCUSTSLIPNORF=@STARTCUSTSLIPNO" + Environment.NewLine;
                                sqlText += " , ENDCUSTSLIPNORF=@ENDCUSTSLIPNO" + Environment.NewLine;
                                sqlText += " , CUSTSLIPNOHEADERRF=@CUSTSLIPNOHEADER" + Environment.NewLine;
                                sqlText += " , CUSTSLIPNOFOOTERRF=@CUSTSLIPNOFOOTER" + Environment.NewLine;
                                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                                sqlText += "    AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                                sqlText += "    AND ADDUPYEARMONTHRF=DATEADD(MONTH, 1, @FINDADDUPYEARMONTH)" + Environment.NewLine;
                                sqlCommand.CommandText = sqlText;
                                # endregion

                                // KEYコマンドを再設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                                findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(custDmdPrcWork.AddUpYearMonth);

                                // 更新ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)custDmdPrcWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);
                            }
                            else
                            {
                                # region [INSERT文]
                                sqlText = string.Empty;
                                sqlText += "INSERT INTO CUSTSLIPNOSETRF" + Environment.NewLine;
                                sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlText += "    ,CUSTOMERCODERF" + Environment.NewLine;
                                sqlText += "    ,ADDUPYEARMONTHRF" + Environment.NewLine;
                                sqlText += "    ,PRESENTCUSTSLIPNORF" + Environment.NewLine;
                                sqlText += "    ,STARTCUSTSLIPNORF" + Environment.NewLine;
                                sqlText += "    ,ENDCUSTSLIPNORF" + Environment.NewLine;
                                sqlText += "    ,CUSTSLIPNOHEADERRF" + Environment.NewLine;
                                sqlText += "    ,CUSTSLIPNOFOOTERRF" + Environment.NewLine;
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
                                sqlText += "    ,@CUSTOMERCODE" + Environment.NewLine;
                                sqlText += "    ,@ADDUPYEARMONTH" + Environment.NewLine;
                                sqlText += "    ,@PRESENTCUSTSLIPNO" + Environment.NewLine;
                                sqlText += "    ,@STARTCUSTSLIPNO" + Environment.NewLine;
                                sqlText += "    ,@ENDCUSTSLIPNO" + Environment.NewLine;
                                sqlText += "    ,@CUSTSLIPNOHEADER" + Environment.NewLine;
                                sqlText += "    ,@CUSTSLIPNOFOOTER" + Environment.NewLine;
                                sqlText += " )" + Environment.NewLine;
                                sqlCommand.CommandText = sqlText;
                                # endregion

                                // 登録ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)custDmdPrcWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                            }

                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }

                            # region Parameterオブジェクトの作成(更新用)
                            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                            SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                            SqlParameter paraPresentCustSlipNo = sqlCommand.Parameters.Add("@PRESENTCUSTSLIPNO", SqlDbType.BigInt);
                            # endregion

                            # region Parameterオブジェクトへ値設定(更新用)
                            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                            paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(custDmdPrcWork.AddUpDate);
                            paraPresentCustSlipNo.Value = 1;
                            # endregion

                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }
        // 2008.07.18 add end -----------------------------------------<<

        /// <summary>
        /// 請求締更新履歴マスタを更新します
        /// </summary>
        /// <param name="dmdCAddUpHisWorkList">得意先請求金額マスタList</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額マスタを更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.26</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        /// </remarks>
        private int WriteDmdCAddUpHis(ref ArrayList dmdCAddUpHisWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            string sqlText = string.Empty; // 2008.07.18 add

            //Insertコマンドの生成
            try
            {
                for (int i = 0; i < dmdCAddUpHisWorkList.Count; i++)
                {
                    #region [2008.10.01 DEL]
                    /* --- DEL 2008.10.01 ---------->>>>>
                    DmdCAddUpHisWork dmdCAddUpHisWork = dmdCAddUpHisWorkList[i] as DmdCAddUpHisWork;
                    // 2008.07.18 upd start ----------------------------------------------------------------->>
                    //using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO DMDCADDUPHISRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ADDUPSECCODERF, CUSTOMERCODERF, STARTCADDUPUPDDATERF, CADDUPUPDDATERF, CADDUPUPDYEARMONTHRF, CADDUPUPDEXECDATERF, LASTCADDUPUPDDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ADDUPSECCODE, @CUSTOMERCODE, @STARTCADDUPUPDDATE, @CADDUPUPDDATE, @CADDUPUPDYEARMONTH, @CADDUPUPDEXECDATE, @LASTCADDUPUPDDATE)", sqlConnection, sqlTransaction))
                    sqlText = string.Empty;
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += " FROM DMDCADDUPHISRF" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "    AND CADDUPUPDDATERF=@FINDCADDUPUPDDATE" + Environment.NewLine;

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaCAddUpUpdDate = sqlCommand.Parameters.Add("@FINDCADDUPUPDDATE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.EnterpriseCode);
                        findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.AddUpSecCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(dmdCAddUpHisWork.CustomerCode);
                        findParaCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dmdCAddUpHisWork.CAddUpUpdDate);

                        sqlCommand.ExecuteNonQuery();
                    }
                 
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO DMDCADDUPHISRF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += "    ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += "    ,CUSTOMERCODERF" + Environment.NewLine;
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
                    sqlText += "    ,@CUSTOMERCODE" + Environment.NewLine;
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
                    // 2008.07.18 upd end -------------------------------------------------------------------<<
                    {
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)dmdCAddUpHisWork;
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
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraStartCAddUpUpdDate = sqlCommand.Parameters.Add("@STARTCADDUPUPDDATE", SqlDbType.Int);
                        SqlParameter paraCAddUpUpdDate = sqlCommand.Parameters.Add("@CADDUPUPDDATE", SqlDbType.Int);
                        SqlParameter paraCAddUpUpdYearMonth = sqlCommand.Parameters.Add("@CADDUPUPDYEARMONTH", SqlDbType.Int);
                        SqlParameter paraCAddUpUpdExecDate = sqlCommand.Parameters.Add("@CADDUPUPDEXECDATE", SqlDbType.Int);
                        SqlParameter paraLastCAddUpUpdDate = sqlCommand.Parameters.Add("@LASTCADDUPUPDDATE", SqlDbType.Int);
                        // 2008.07.18 add start ----------------------------------------------------------------->>
                        SqlParameter paraProcDivCd = sqlCommand.Parameters.Add("@PROCDIVCD", SqlDbType.Int);
                        SqlParameter paraErrorStatus = sqlCommand.Parameters.Add("@ERRORSTATUS", SqlDbType.Int);
                        SqlParameter paraHistCtlCd = sqlCommand.Parameters.Add("@HISTCTLCD", SqlDbType.Int);
                        SqlParameter paraProcResult = sqlCommand.Parameters.Add("@PROCRESULT", SqlDbType.NVarChar);
                        SqlParameter paraConvertProcessDivCd = sqlCommand.Parameters.Add("@CONVERTPROCESSDIVCD", SqlDbType.Int);
                        // 2008.07.18 add end -------------------------------------------------------------------<<
                        #endregion

                        #region Parameterオブジェクト設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dmdCAddUpHisWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dmdCAddUpHisWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dmdCAddUpHisWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dmdCAddUpHisWork.LogicalDeleteCode);
                        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.AddUpSecCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dmdCAddUpHisWork.CustomerCode);
                        paraStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dmdCAddUpHisWork.StartCAddUpUpdDate);
                        paraCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dmdCAddUpHisWork.CAddUpUpdDate);
                        paraCAddUpUpdYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(dmdCAddUpHisWork.CAddUpUpdYearMonth);
                        paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dmdCAddUpHisWork.CAddUpUpdExecDate);
                        paraLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dmdCAddUpHisWork.LastCAddUpUpdDate);
                        // 2008.07.18 add start ----------------------------------------------------------------->>
                        paraProcDivCd.Value = 0;
                        paraErrorStatus.Value = 0;
                        paraHistCtlCd.Value = 0;
                        paraProcResult.Value = string.Empty;
                        paraConvertProcessDivCd.Value = 0;
                        // 2008.07.18 add end -------------------------------------------------------------------<<
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
                    DmdCAddUpHisWork dmdCAddUpHisWork = dmdCAddUpHisWorkList[i] as DmdCAddUpHisWork;

                    #region [Insert文作成]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO DMDCADDUPHISRF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
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
                    sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
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
                        sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)dmdCAddUpHisWork;
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
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
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
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dmdCAddUpHisWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dmdCAddUpHisWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dmdCAddUpHisWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dmdCAddUpHisWork.LogicalDeleteCode);
                        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.AddUpSecCode);
                        //paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dmdCAddUpHisWork.CustomerCode); // DEL 2008.10.20
                        paraCustomerCode.Value = 0; // ADD 2008.10.20
                        paraStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dmdCAddUpHisWork.StartCAddUpUpdDate);
                        paraCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dmdCAddUpHisWork.CAddUpUpdDate);
                        paraCAddUpUpdYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(dmdCAddUpHisWork.CAddUpUpdYearMonth);
                        paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dmdCAddUpHisWork.CAddUpUpdExecDate);
                        paraLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dmdCAddUpHisWork.LastCAddUpUpdDate);
                        paraDataUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dmdCAddUpHisWork.CreateDateTime);
                        paraProcDivCd.Value = 0;
                        paraErrorStatus.Value = 0;
                        paraHistCtlCd.Value = 0;
                        paraProcResult.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.ProcResult);
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
        /// 得意先請求金額マスタ更新パラメータを取得します
        /// </summary>
        /// <param name="custDmdPrcUpdateWork">請求準備処理パラメータ</param>
        /// <param name="custDmdPrcWorkList">請求金額マスタ更新パラメータList</param>
        /// <param name="custDmdPrcChildWorkList">請求金額マスタ更新パラメータList</param>
        /// <param name="dmdDepoTotalWorkList">請求入金集計更新パラメータList</param>
        /// <param name="dmdCAddUpHisWorkList">請求締更新パラメータList</param>
        /// <param name="custDmdPrcParentWorkList">子集計得意先請求金額ワークList</param>//ADD 2013/08/08 汪権来 Redmine#35552 速度改善
        /// <param name="custDmdPrcChildrenWorkList">親集計得意先請求金額ワークList</param>//ADD 2013/08/08 汪権来 Redmine#35552 速度改善
        /// <param name="retMsg">エラーメッセージ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額マスタ更新パラメータを取得します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>s
        /// <br>Date       : 2007.03.20</br>
        /// <br>Update Note: 2013/08/08 汪権来</br>
        /// <br>管理番号   ：10902175-00 2013/06/18配信分</br>
        /// <br>             Redmine#35552 「売上締次更新」の処理速度遅延の調査と対応(№1921)</br>
        /// </remarks>
        // ↓ 2007.11.20 980081 c
        //private int MakeCustDmdPrcParameters(ref CustDmdPrcUpdateWork custDmdPrcUpdateWork, ref ArrayList custDmdPrcWorkList, out ArrayList dmdCAddUpHisWorkList, out string retMsg, ref SqlConnection sqlConnection)
        //private int MakeCustDmdPrcParameters(ref CustDmdPrcUpdateWork custDmdPrcUpdateWork, ref ArrayList custDmdPrcWorkList, ref ArrayList custDmdPrcChildWorkList, ref ArrayList dmdDepoTotalWorkList, out ArrayList dmdCAddUpHisWorkList, out string retMsg, ref SqlConnection sqlConnection)//DEL 2013/08/08 汪権来 Redmine#35552 速度改善
        private int MakeCustDmdPrcParameters(ref CustDmdPrcUpdateWork custDmdPrcUpdateWork, ref ArrayList custDmdPrcWorkList, ref ArrayList custDmdPrcChildWorkList, ref ArrayList dmdDepoTotalWorkList, out ArrayList dmdCAddUpHisWorkList, out string retMsg, ref SqlConnection sqlConnection, Dictionary<string, List<CustDmdPrcWork>> custDmdPrcParentWorkList, Dictionary<string, List<CustDmdPrcWork>> custDmdPrcChildrenWorkList)//ADD 2013/08/08 汪権来 Redmine#35552 速度改善
        // ↑ 2007.11.20 980081 c
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //請求締更新履歴List
            dmdCAddUpHisWorkList = new ArrayList();
            retMsg = null;

            //請求金額マスタ
            CustDmdPrcWork custDmdPrcWork = null;
            
            Int32[] customerCodeList = new Int32[1];

            //伝票更新排他制御部品
            //ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;

            try
            {
                //●得意先請求金額マスタ更新List作成処理
                if (custDmdPrcWorkList != null && custDmdPrcWorkList.Count > 0)
                {
                    //●請求締更新履歴マスタのチェック
                    for (int i = 0; i < custDmdPrcWorkList.Count; i++)
                    {
                        custDmdPrcWork = custDmdPrcWorkList[i] as CustDmdPrcWork;
                        if (custDmdPrcWork.UpdateStatus == 0)
                        {
                            status = CheckDmdCAddUpHis(ref custDmdPrcWork, ref sqlConnection);
                        }
                    }
                    
                    //●前回請求情報の取得　得意先請求金額マスタ・請求締更新履歴マスタ
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        for (int i = 0; i < custDmdPrcWorkList.Count; i++)
                        {
                            custDmdPrcWork = custDmdPrcWorkList[i] as CustDmdPrcWork;
                            customerCodeList[0] = new Int32();
                            customerCodeList[0] = custDmdPrcWork.ClaimCode;
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                            //●前回請求情報取得
                            if (custDmdPrcWork.UpdateStatus == 0)
                                status = GetDmdCAddUpHisAndCustDmdPrc(ref custDmdPrcWork, ref sqlConnection);
                            //締次更新実行年月日
                            //if (custDmdPrcUpdateWork.ProcCntntsFlag == 1) // del 2007.07.31 saito
                            //請求準備処理の時も締次更新実行年月日を挿入する
                            custDmdPrcWork.CAddUpUpdExecDate = DateTime.Now;

                            ////●全体初期値設定マスタから総額表示方法区分を取得　※全体参照の場合のみ
                            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            //{
                            //    if (custDmdPrcWork.TotalAmntDspWayRef == 0)
                            //        status = GetTotalAmount(ref custDmdPrcWork, ref sqlConnection);
                            //}
                            //if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            //{
                            //    retMsg = "全体初期値設定が不正です。";
                            //    return status;
                            //}

                            //●入金マスタ取得
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (custDmdPrcWork.UpdateStatus == 0)
                                    status = GetDepsitMain(ref custDmdPrcWork, ref sqlConnection);
                            }

                            // 2008.07.18 add start ------------------------------->>
                            //●入金明細データ＆入金マスタ取得
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (custDmdPrcWork.UpdateStatus == 0)
                                    //status = GetDepsitDtlMain(ref custDmdPrcWork, ref dmdDepoTotalWorkList, ref sqlConnection);//DEL 2013/08/08 汪権来 Redmine#35552 速度改善
                                    status = GetDepsitDtlMainForCustDmd(ref custDmdPrcWork, ref dmdDepoTotalWorkList, ref sqlConnection);//ADD 2013/08/08 汪権来 Redmine#35552 速度改善
                            }
                            // 2008.07.18 add end ---------------------------------<<

                            //●売上データ取得
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (custDmdPrcWork.UpdateStatus == 0)
                                    // ↓ 2007.11.20 980081 c
                                    //status = GetSalesSlip(ref custDmdPrcWork, ref sqlConnection);
                                    //status = GetSalesSlip(ref custDmdPrcWork, ref custDmdPrcChildWorkList, ref sqlConnection);//DEL 2013/08/08 汪権来 Redmine#35552 速度改善
                                    status = GetSalesSlipForCustDmd(ref custDmdPrcWork, ref custDmdPrcChildWorkList, ref sqlConnection, custDmdPrcParentWorkList, custDmdPrcChildrenWorkList);//ADD 2013/08/08 汪権来 Redmine#35552 速度改善
                                // ↑ 2007.11.20 980081 c
                            }

                                //if (ctrlExclsvOdAcs != null) ctrlExclsvOdAcs.UnlockDB();
                            // 2008.12.10 DEL >>>
                            //// ↓ 2008.03.12 980081
                            //}
                            //// ↑ 2008.03.12 980081 
                            // 2008.12.10 DEL <<<
                        }
                    }
                    
                    //●請求締更新履歴マスタ更新List作成
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //締次更新処理の場合
                        status = MakeUpdateList(ref custDmdPrcWorkList, out dmdCAddUpHisWorkList, custDmdPrcUpdateWork);
                    }
                }
                
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustDmdPrcDB.MakeCustDmdPrcParameters Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;

        }
        #endregion

        #region [GetCustomer 得意先マスタ]
        /// <summary>
        /// 得意先マスタ、税率設定マスタから更新情報を取得します
        /// </summary>
        /// <param name="custDmdPrcUpdateWork">得意先請求金額マスタ更新パラメータ</param>
        /// <param name="custDmdPrcWorkList">得意先請求金額ワーク用List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ、税率設定マスタから更新情報を取得します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.15</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        /// <br>Update Note: 2012/12/12 dpp</br>
        /// <br>管理番号   : 10801804-00 2013/01/16配信分</br>
        /// <br>             Redmine#33856 入金予定日の計算の不正</br> 
        /// </remarks>
        private int GetCustomer(ref CustDmdPrcUpdateWork custDmdPrcUpdateWork, ref ArrayList custDmdPrcWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            //得意先マスタ
            CustomerWork customerWork = null;
            //税率設定マスタ
            TaxRateSetWork taxRateSetWork = null;
            //請求金額マスタ
            CustDmdPrcWork custDmdPrcWork = null;
            DateTime collectmoneyDate = DateTime.MinValue;
            string sqlText = string.Empty; // 2008.07.18 add

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                    // 修正 2009/04/14 >>>
                    #region DEL 2009/04/14
                    /*
                    if (custDmdPrcUpdateWork.CustomerTotalDay != 99)
                    {
                        #region SELECT
                        // 2008.07.18 upd start ----------------------------------------------------->>
                        #region DEL
                        //sqlCommand.CommandText = "SELECT A.ENTERPRISECODERF,A.CUSTOMERCODERF,CAST(DECRYPTBYKEY(A.NAMERF) AS NVARCHAR(30)) AS NAMERF,CAST(DECRYPTBYKEY(A.NAME2RF) AS NVARCHAR(30)) AS NAME2RF,A.CLAIMCODERF,CAST(DECRYPTBYKEY(A.CLAIMNAMERF) AS NVARCHAR(30)) AS CLAIMNAMERF,CAST(DECRYPTBYKEY(A.CLAIMNAME2RF) AS NVARCHAR(30)) AS CLAIMNAME2RF,A.TOTALDAYRF,A.CONSTAXLAYMETHODRF,A.TOTALAMOUNTDISPWAYCDRF,A.TOTALAMNTDSPWAYREFRF, "
                        //                + "CAST(DECRYPTBYKEY(A.CUSTOMERSNMRF) AS NVARCHAR(20)) AS CUSTOMERSNMRF,"
                        //                + "CAST(DECRYPTBYKEY(A.CLAIMSNMRF) AS NVARCHAR(20)) AS CLAIMSNMRF,"
                        //                + "B.TAXRATESTARTDATERF,B.TAXRATEENDDATERF,B.TAXRATERF,B.TAXRATESTARTDATE2RF,B.TAXRATEENDDATE2RF,B.TAXRATE2RF,B.TAXRATESTARTDATE3RF,B.TAXRATEENDDATE3RF,B.TAXRATE3RF,B.CONSTAXLAYMETHODRF CONSTAXLAYMETHOD_TAXRF,C.FRACTIONPROCCDRF "
                        //                // ↓ 2008.03.12 980081 a
                        //                + ",A.MNGSECTIONCODERF,A.ACCEPTWHOLESALERF "
                        //                // ↑ 2008.03.12 980081 a
                        //                + "FROM ((CUSTOMERRF AS A WITH (READUNCOMMITTED) LEFT JOIN TAXRATESETRF AS B WITH (READUNCOMMITTED) ON A.ENTERPRISECODERF=B.ENTERPRISECODERF) LEFT JOIN SALESPROCMONEYRF AS C WITH (READUNCOMMITTED) ON A.ENTERPRISECODERF=C.ENTERPRISECODERF AND C.FRACPROCMONEYDIVRF=1 AND A.SALESCNSTAXFRCPROCCDRF=C.FRACTIONPROCCODERF) WHERE A.ENTERPRISECODERF=@FINDENTERPRISECODE AND B.TAXRATECODERF=0 ";
                        #endregion
                        sqlText = string.Empty;
                        sqlText += "SELECT A.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,A.CUSTOMERCODERF" + Environment.NewLine;
                        // 修正 2008.12.10 >>>
                        #region 削除
                        //sqlText += "    ,CAST" + Environment.NewLine;
                        //sqlText += "    (DECRYPTBYKEY" + Environment.NewLine;
                        //sqlText += "        (A.NAMERF" + Environment.NewLine;
                        //sqlText += "        ) AS NVARCHAR" + Environment.NewLine;
                        //sqlText += "        (30" + Environment.NewLine;
                        //sqlText += "        )" + Environment.NewLine;
                        //sqlText += "    ) AS NAMERF" + Environment.NewLine;
                        //sqlText += "    ,CAST" + Environment.NewLine;
                        //sqlText += "    (DECRYPTBYKEY" + Environment.NewLine;
                        //sqlText += "        (A.NAME2RF" + Environment.NewLine;
                        //sqlText += "        ) AS NVARCHAR" + Environment.NewLine;
                        //sqlText += "        (30" + Environment.NewLine;
                        //sqlText += "        )" + Environment.NewLine;
                        //sqlText += "    ) AS NAME2RF" + Environment.NewLine;
                        #endregion
                        sqlText += "    ,A.NAMERF" + Environment.NewLine;
                        sqlText += "    ,A.NAME2RF" + Environment.NewLine;
                        // 修正 2008.12.10 <<<
                        sqlText += "    ,A.CLAIMCODERF" + Environment.NewLine;
                        sqlText += "    ,A.TOTALDAYRF" + Environment.NewLine;
                        sqlText += "    ,A.CONSTAXLAYMETHODRF" + Environment.NewLine;
                        sqlText += "    ,A.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                        sqlText += "    ,A.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                        // 修正 2008.12.10 >>>
                        #region 削除
                        //sqlText += "    ,CAST" + Environment.NewLine;
                        //sqlText += "    (DECRYPTBYKEY" + Environment.NewLine;
                        //sqlText += "        (A.CUSTOMERSNMRF" + Environment.NewLine;
                        //sqlText += "        ) AS NVARCHAR" + Environment.NewLine;
                        //sqlText += "        (20" + Environment.NewLine;
                        //sqlText += "        )" + Environment.NewLine;
                        //sqlText += "    ) AS CUSTOMERSNMRF" + Environment.NewLine;
                        #endregion
                        sqlText += "    ,A.CUSTOMERSNMRF" + Environment.NewLine;
                        sqlText += "    ,D.NAMERF AS CLAIMNAMERF" + Environment.NewLine;
                        sqlText += "    ,D.NAME2RF AS CLAIMNAME2RF" + Environment.NewLine;
                        sqlText += "    ,D.CUSTOMERSNMRF AS CLAIMCUSTOMERSNMRF" + Environment.NewLine;
                        // 修正 2008.12.10 <<<
                        sqlText += "    ,B.TAXRATESTARTDATERF" + Environment.NewLine;
                        sqlText += "    ,B.TAXRATEENDDATERF" + Environment.NewLine;
                        sqlText += "    ,B.TAXRATERF" + Environment.NewLine;
                        sqlText += "    ,B.TAXRATESTARTDATE2RF" + Environment.NewLine;
                        sqlText += "    ,B.TAXRATEENDDATE2RF" + Environment.NewLine;
                        sqlText += "    ,B.TAXRATE2RF" + Environment.NewLine;
                        sqlText += "    ,B.TAXRATESTARTDATE3RF" + Environment.NewLine;
                        sqlText += "    ,B.TAXRATEENDDATE3RF" + Environment.NewLine;
                        sqlText += "    ,B.TAXRATE3RF" + Environment.NewLine;
                        sqlText += "    ,B.CONSTAXLAYMETHODRF CONSTAXLAYMETHOD_TAXRF" + Environment.NewLine;
                        sqlText += "    ,C.FRACTIONPROCCDRF" + Environment.NewLine;
                        sqlText += "    ,A.MNGSECTIONCODERF" + Environment.NewLine;
                        sqlText += "    ,A.ACCEPTWHOLESALERF" + Environment.NewLine;
                        sqlText += "    ,A.CLAIMSECTIONCODERF" + Environment.NewLine;
                        sqlText += "    ,A.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                        sqlText += "    ,A.COLLECTCONDRF" + Environment.NewLine;
                        sqlText += "    ,A.COLLECTMONEYCODERF" + Environment.NewLine;
                        sqlText += "    ,A.COLLECTMONEYDAYRF" + Environment.NewLine;

                        sqlText += " FROM" + Environment.NewLine;
                        sqlText += "    (" + Environment.NewLine;
                        sqlText += "        (" + Environment.NewLine;
                        sqlText += "          CUSTOMERRF AS A WITH(READUNCOMMITTED) LEFT" + Environment.NewLine;
                        // 税率マスタ
                        sqlText += "          JOIN TAXRATESETRF AS B WITH(READUNCOMMITTED)" + Environment.NewLine;
                        sqlText += "          ON A.ENTERPRISECODERF=B.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "        ) LEFT" + Environment.NewLine;
                        // 売上金額処理区分設定マスタ
                        sqlText += "        JOIN SALESPROCMONEYRF AS C WITH(READUNCOMMITTED)" + Environment.NewLine;
                        sqlText += "         ON A.ENTERPRISECODERF=C.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "         AND C.FRACPROCMONEYDIVRF=1" + Environment.NewLine;
                        sqlText += "         AND A.SALESCNSTAXFRCPROCCDRF=C.FRACTIONPROCCODERF LEFT" + Environment.NewLine;
                        // 得意先マスタ
                        sqlText += "        JOIN CUSTOMERRF AS D WITH(READUNCOMMITTED) " + Environment.NewLine;
                        sqlText += "         ON A.ENTERPRISECODERF=D.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "         AND A.CLAIMCODERF=D.CUSTOMERCODERF" + Environment.NewLine;

                        sqlText += "    )" + Environment.NewLine;
                        sqlText += " WHERE A.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND A.LOGICALDELETECODERF=0" + Environment.NewLine;
                        sqlText += "    AND B.TAXRATECODERF=0" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        // 2008.07.18 upd end -------------------------------------------------------<<
                        #endregion
                    }
                    else
                    {
                        #region SELECT
                        // 2008.07.18 upd start ----------------------------------------------->>
                        #region DEL
                        //sqlCommand.CommandText = "SELECT A.ENTERPRISECODERF,A.CUSTOMERCODERF,CAST(DECRYPTBYKEY(A.NAMERF) AS NVARCHAR(30)) AS NAMERF,CAST(DECRYPTBYKEY(A.NAME2RF) AS NVARCHAR(30)) AS NAME2RF,A.CLAIMCODERF,CAST(DECRYPTBYKEY(A.CLAIMNAMERF) AS NVARCHAR(30)) AS CLAIMNAMERF,CAST(DECRYPTBYKEY(A.CLAIMNAME2RF) AS NVARCHAR(30)) AS CLAIMNAME2RF,A.TOTALDAYRF,A.CONSTAXLAYMETHODRF,A.TOTALAMOUNTDISPWAYCDRF,A.TOTALAMNTDSPWAYREFRF, "
                        //                + "CAST(DECRYPTBYKEY(A.CUSTOMERSNMRF) AS NVARCHAR(20)) AS CUSTOMERSNMRF,"
                        //                + "CAST(DECRYPTBYKEY(A.CLAIMSNMRF) AS NVARCHAR(20)) AS CLAIMSNMRF,"
                        //                + "B.TAXRATESTARTDATERF,B.TAXRATEENDDATERF,B.TAXRATERF,B.TAXRATESTARTDATE2RF,B.TAXRATEENDDATE2RF,B.TAXRATE2RF,B.TAXRATESTARTDATE3RF,B.TAXRATEENDDATE3RF,B.TAXRATE3RF,B.CONSTAXLAYMETHODRF CONSTAXLAYMETHOD_TAXRF,C.FRACTIONPROCCDRF  "
                        //                // ↓ 2008.03.12 980081 a
                        //                + ",A.MNGSECTIONCODERF,A.ACCEPTWHOLESALERF "
                        //                // ↑ 2008.03.12 980081 a
                        //                + "FROM CUSTOMERRF AS A WITH (READUNCOMMITTED) LEFT JOIN TAXRATESETRF AS B WITH (READUNCOMMITTED) ON A.ENTERPRISECODERF=B.ENTERPRISECODERF "
                        //                + "LEFT JOIN SALESPROCMONEYRF AS C WITH (READUNCOMMITTED) ON A.ENTERPRISECODERF=C.ENTERPRISECODERF AND C.FRACPROCMONEYDIVRF=1 AND A.SALESCNSTAXFRCPROCCDRF=C.FRACTIONPROCCODERF "
                        //                + "WHERE A.ENTERPRISECODERF=@FINDENTERPRISECODE AND (A.TOTALDAYRF>=28 AND A.TOTALDAYRF<=31) AND B.TAXRATECODERF=0 ";
                        #endregion
                        sqlText = string.Empty;
                        sqlText += "SELECT A.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,A.CUSTOMERCODERF" + Environment.NewLine;
                        // 修正 2008.12.10 >>>
                        #region DEL
                        //sqlText += "    ,CAST" + Environment.NewLine;
                        //sqlText += "    (DECRYPTBYKEY" + Environment.NewLine;
                        //sqlText += "        (A.NAMERF" + Environment.NewLine;
                        //sqlText += "        ) AS NVARCHAR" + Environment.NewLine;
                        //sqlText += "        (30" + Environment.NewLine;
                        //sqlText += "        )" + Environment.NewLine;
                        //sqlText += "    ) AS NAMERF" + Environment.NewLine;
                        //sqlText += "    ,CAST" + Environment.NewLine;
                        //sqlText += "    (DECRYPTBYKEY" + Environment.NewLine;
                        //sqlText += "        (A.NAME2RF" + Environment.NewLine;
                        //sqlText += "        ) AS NVARCHAR" + Environment.NewLine;
                        //sqlText += "        (30" + Environment.NewLine;
                        //sqlText += "        )" + Environment.NewLine;
                        //sqlText += "    ) AS NAME2RF" + Environment.NewLine;
                        #endregion
                        sqlText += "    ,A.NAMERF" + Environment.NewLine;
                        sqlText += "    ,A.NAME2RF" + Environment.NewLine;
                        sqlText += "    ,D.NAMERF AS CLAIMNAMERF" + Environment.NewLine;
                        sqlText += "    ,D.NAME2RF AS CLAIMNAME2RF" + Environment.NewLine;
                        sqlText += "    ,D.CUSTOMERSNMRF AS CLAIMCUSTOMERSNMRF" + Environment.NewLine;
                        // 修正 2008.12.10 <<<
                        sqlText += "    ,A.CLAIMCODERF" + Environment.NewLine;
                        sqlText += "    ,A.TOTALDAYRF" + Environment.NewLine;
                        sqlText += "    ,A.CONSTAXLAYMETHODRF" + Environment.NewLine;
                        sqlText += "    ,A.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                        sqlText += "    ,A.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                        // 修正 2008.12.10 >>>
                        #region DEL
                        //sqlText += "    ,CAST" + Environment.NewLine;
                        //sqlText += "    (DECRYPTBYKEY" + Environment.NewLine;
                        //sqlText += "        (A.CUSTOMERSNMRF" + Environment.NewLine;
                        //sqlText += "        ) AS NVARCHAR" + Environment.NewLine;
                        //sqlText += "        (20" + Environment.NewLine;
                        //sqlText += "        )" + Environment.NewLine;
                        //sqlText += "    ) AS CUSTOMERSNMRF" + Environment.NewLine;
                        #endregion
                        sqlText += "    ,A.CUSTOMERSNMRF" + Environment.NewLine;
                        // 修正 2008.12.10 <<<
                        sqlText += "    ,B.TAXRATESTARTDATERF" + Environment.NewLine;
                        sqlText += "    ,B.TAXRATEENDDATERF" + Environment.NewLine;
                        sqlText += "    ,B.TAXRATERF" + Environment.NewLine;
                        sqlText += "    ,B.TAXRATESTARTDATE2RF" + Environment.NewLine;
                        sqlText += "    ,B.TAXRATEENDDATE2RF" + Environment.NewLine;
                        sqlText += "    ,B.TAXRATE2RF" + Environment.NewLine;
                        sqlText += "    ,B.TAXRATESTARTDATE3RF" + Environment.NewLine;
                        sqlText += "    ,B.TAXRATEENDDATE3RF" + Environment.NewLine;
                        sqlText += "    ,B.TAXRATE3RF" + Environment.NewLine;
                        sqlText += "    ,B.CONSTAXLAYMETHODRF CONSTAXLAYMETHOD_TAXRF" + Environment.NewLine;
                        sqlText += "    ,C.FRACTIONPROCCDRF" + Environment.NewLine;
                        sqlText += "    ,A.MNGSECTIONCODERF" + Environment.NewLine;
                        sqlText += "    ,A.ACCEPTWHOLESALERF" + Environment.NewLine;
                        sqlText += "    ,A.CLAIMSECTIONCODERF" + Environment.NewLine;
                        sqlText += "    ,A.CUSTOMERSLIPNODIVRF" + Environment.NewLine;

                        sqlText += "    ,A.COLLECTCONDRF" + Environment.NewLine;
                        sqlText += "    ,A.COLLECTMONEYCODERF" + Environment.NewLine;
                        sqlText += "    ,A.COLLECTMONEYDAYRF" + Environment.NewLine;
                        // 修正 2008.12.10 >>>
                        #region DEL                        
                        //sqlText += " FROM CUSTOMERRF AS A WITH" + Environment.NewLine;
                        //sqlText += "    (READUNCOMMITTED" + Environment.NewLine;
                        //sqlText += "    ) LEFT" + Environment.NewLine;
                        //sqlText += " JOIN TAXRATESETRF AS B WITH" + Environment.NewLine;
                        //sqlText += " (READUNCOMMITTED" + Environment.NewLine;
                        //sqlText += " ) ON A.ENTERPRISECODERF=B.ENTERPRISECODERF LEFT" + Environment.NewLine;
                        //sqlText += " JOIN SALESPROCMONEYRF AS C WITH" + Environment.NewLine;
                        //sqlText += " (READUNCOMMITTED" + Environment.NewLine;
                        //sqlText += " ) ON A.ENTERPRISECODERF=C.ENTERPRISECODERF" + Environment.NewLine;
                        //sqlText += " AND C.FRACPROCMONEYDIVRF=1" + Environment.NewLine;
                        //sqlText += " AND A.SALESCNSTAXFRCPROCCDRF=C.FRACTIONPROCCODERF" + Environment.NewLine;
                        //sqlText += " WHERE A.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        //sqlText += "    AND" + Environment.NewLine;
                        //sqlText += "    (A.TOTALDAYRF>=28" + Environment.NewLine;
                        //sqlText += "        AND A.TOTALDAYRF<=31" + Environment.NewLine;
                        //sqlText += "    )" + Environment.NewLine;
                        //sqlText += "    AND B.TAXRATECODERF=0" + Environment.NewLine;                       
                        #endregion
                        sqlText += "FROM CUSTOMERRF AS A WITH (READUNCOMMITTED) LEFT" + Environment.NewLine;
                        // 税率マスタ
                        sqlText += " JOIN TAXRATESETRF AS B WITH (READUNCOMMITTED) " + Environment.NewLine;
                        sqlText += "  ON A.ENTERPRISECODERF=B.ENTERPRISECODERF LEFT" + Environment.NewLine;
                        // 売上金額処理区分設定マスタ
                        sqlText += " JOIN SALESPROCMONEYRF AS C WITH(READUNCOMMITTED) " + Environment.NewLine;
                        sqlText += "  ON A.ENTERPRISECODERF=C.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "  AND C.FRACPROCMONEYDIVRF=1" + Environment.NewLine;
                        sqlText += "  AND A.SALESCNSTAXFRCPROCCDRF=C.FRACTIONPROCCODERF LEFT" + Environment.NewLine;
                        // 得意先マスタ
                        sqlText += " JOIN CUSTOMERRF AS D WITH(READUNCOMMITTED) " + Environment.NewLine;
                        sqlText += "  ON A.ENTERPRISECODERF=D.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "  AND A.CLAIMCODERF=D.CUSTOMERCODERF" + Environment.NewLine;
 
                        sqlText += " WHERE A.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND A.LOGICALDELETECODERF=0" + Environment.NewLine;
                        sqlText += "    AND B.TAXRATECODERF=0" + Environment.NewLine;
                        // 修正 2008.12.10 <<<
                        sqlCommand.CommandText = sqlText;
                        // 2008.07.18 upd end -------------------------------------------------<<
                        #endregion
                    }
                    */
                    #endregion

                    #region SELECT文
                    sqlText = string.Empty;
                    sqlText += "SELECT A.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,A.CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += "    ,A.NAMERF" + Environment.NewLine;
                    sqlText += "    ,A.NAME2RF" + Environment.NewLine;
                    sqlText += "    ,A.CLAIMCODERF" + Environment.NewLine;
                    sqlText += "    ,A.TOTALDAYRF" + Environment.NewLine;
                    sqlText += "    ,A.CONSTAXLAYMETHODRF" + Environment.NewLine;
                    sqlText += "    ,A.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                    sqlText += "    ,A.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                    sqlText += "    ,A.CUSTOMERSNMRF" + Environment.NewLine;
                    sqlText += "    ,D.NAMERF AS CLAIMNAMERF" + Environment.NewLine;
                    sqlText += "    ,D.NAME2RF AS CLAIMNAME2RF" + Environment.NewLine;
                    sqlText += "    ,D.CUSTOMERSNMRF AS CLAIMCUSTOMERSNMRF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATESTARTDATERF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATEENDDATERF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATERF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATESTARTDATE2RF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATEENDDATE2RF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATE2RF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATESTARTDATE3RF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATEENDDATE3RF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATE3RF" + Environment.NewLine;
                    sqlText += "    ,B.CONSTAXLAYMETHODRF CONSTAXLAYMETHOD_TAXRF" + Environment.NewLine;
                    sqlText += "    ,C.FRACTIONPROCCDRF" + Environment.NewLine;
                    sqlText += "    ,A.MNGSECTIONCODERF" + Environment.NewLine;
                    sqlText += "    ,A.ACCEPTWHOLESALERF" + Environment.NewLine;
                    sqlText += "    ,A.CLAIMSECTIONCODERF" + Environment.NewLine;
                    sqlText += "    ,A.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                    sqlText += "    ,A.COLLECTCONDRF" + Environment.NewLine;
                    sqlText += "    ,A.COLLECTMONEYCODERF" + Environment.NewLine;
                    sqlText += "    ,A.COLLECTMONEYDAYRF" + Environment.NewLine;
                    sqlText += " FROM" + Environment.NewLine;
                    sqlText += "    (" + Environment.NewLine;
                    sqlText += "        (" + Environment.NewLine;
                    sqlText += "          CUSTOMERRF AS A WITH(READUNCOMMITTED) LEFT" + Environment.NewLine;
                    // 税率マスタ
                    sqlText += "          JOIN TAXRATESETRF AS B WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "          ON A.ENTERPRISECODERF=B.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "        ) LEFT" + Environment.NewLine;
                    // 売上金額処理区分設定マスタ
                    sqlText += "        JOIN SALESPROCMONEYRF AS C WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "         ON A.ENTERPRISECODERF=C.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "         AND C.FRACPROCMONEYDIVRF=1" + Environment.NewLine;
                    sqlText += "         AND A.SALESCNSTAXFRCPROCCDRF=C.FRACTIONPROCCODERF LEFT" + Environment.NewLine;
                    // 得意先マスタ
                    sqlText += "        JOIN CUSTOMERRF AS D WITH(READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "         ON A.ENTERPRISECODERF=D.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "         AND A.CLAIMCODERF=D.CUSTOMERCODERF" + Environment.NewLine;

                    if (custDmdPrcUpdateWork.AddUpSecCode == "" || custDmdPrcUpdateWork.AddUpSecCode == "00")
                    {
                        sqlText += "        INNER JOIN SECINFOSETRF AS E WITH (READUNCOMMITTED)" + Environment.NewLine;
                        sqlText += "         ON A.ENTERPRISECODERF=E.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "         AND A.CLAIMSECTIONCODERF= E.SECTIONCODERF" + Environment.NewLine;
                        sqlText += "         AND E.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    }

                    sqlText += "    )" + Environment.NewLine;
                    sqlText += " WHERE A.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND A.LOGICALDELETECODERF=0" + Environment.NewLine;
                    sqlText += "    AND B.TAXRATECODERF=0" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    #endregion

                    // 修正 2009/04/17 <<<


                    #region Parameterオブジェクトへ値設定

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcUpdateWork.EnterpriseCode);

                    //得意先締日
                    if (custDmdPrcUpdateWork.CustomerTotalDay != 0 && custDmdPrcUpdateWork.CustomerTotalDay != 99)
                    {
                        // ADD 2008.12.10 >>>
                        // 28日以降は末締とする
                        if (custDmdPrcUpdateWork.CustomerTotalDay >= 28 && custDmdPrcUpdateWork.CustomerTotalDay <= 31)
                        {
                            sqlCommand.CommandText += "AND (A.TOTALDAYRF>=28 AND A.TOTALDAYRF<=31)";
                        }
                        else
                        {
                        // ADD 2008.12.10 <<<
                            sqlCommand.CommandText += "AND A.TOTALDAYRF=@FINDTOTALDAY ";
                            SqlParameter findParaTotalDay = sqlCommand.Parameters.Add("@FINDTOTALDAY", SqlDbType.Int);
                            findParaTotalDay.Value = SqlDataMediator.SqlSetInt32(custDmdPrcUpdateWork.CustomerTotalDay);
                        }
                    }

                    // ADD 2008.10.20 >>>
                    if (custDmdPrcUpdateWork.AddUpSecCode != "" && custDmdPrcUpdateWork.AddUpSecCode != "00")
                    {
                        sqlCommand.CommandText += "    AND A.CLAIMSECTIONCODERF =@FINDSECTIONCODE" + Environment.NewLine;
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(custDmdPrcUpdateWork.AddUpSecCode);
                    }
                    // ADD 2008.10.20 <<<

                    #endregion

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        #region 結果セット
                        customerWork = new CustomerWork();
                        custDmdPrcWork = new CustDmdPrcWork();
                        taxRateSetWork = new TaxRateSetWork();
                        //得意先マスタ・税率設定マスタからデータセット
                        customerWork = CopyToCustomerWorkFromReader(ref myReader);
                        taxRateSetWork = CopyToTaxRateSetWorkFromReader(ref myReader);

                        //●画面パラメータから
                        custDmdPrcWork.AddUpSecCode = custDmdPrcUpdateWork.AddUpSecCode;       //計上拠点コード 
                        custDmdPrcWork.AddUpDate = custDmdPrcUpdateWork.AddUpDate;             //計上年月日
                        custDmdPrcWork.AddUpYearMonth = custDmdPrcUpdateWork.AddUpYearMonth;   //計上年月

                        //●得意先マスタから
                        custDmdPrcWork.EnterpriseCode = customerWork.EnterpriseCode;       //企業コード
                        custDmdPrcWork.ClaimCode = customerWork.ClaimCode;                 //請求先コード
                        custDmdPrcWork.ClaimName = customerWork.ClaimName;                 //請求先名称
                        custDmdPrcWork.ClaimName2 = customerWork.ClaimName2;               //請求先名称2
                        custDmdPrcWork.ClaimSnm = customerWork.ClaimSnm;                   //請求先略称
                        custDmdPrcWork.CustomerSnm = customerWork.CustomerSnm;             //得意先略称
                        custDmdPrcWork.CustomerCode = customerWork.CustomerCode;           //得意先コード
                        custDmdPrcWork.CustomerName = customerWork.Name;                   //得意先名称
                        custDmdPrcWork.CustomerName2 = customerWork.Name2;                 //得意先名称2
                        custDmdPrcWork.CustomerTotalDay = customerWork.TotalDay;           //得意先締日

                         custDmdPrcWork.AddUpSecCode = customerWork.ClaimSectionCode;       //請求拠点コード 

                        if (custDmdPrcUpdateWork.TermLastDiv == 1)
                        {
                            custDmdPrcWork.CustomerSlipNoDiv = 2; //得意先伝票番号区分
                        }
                        else
                        {
                            custDmdPrcWork.CustomerSlipNoDiv = customerWork.CustomerSlipNoDiv; //得意先伝票番号区分
                        }

                        if (customerWork.ConsTaxLayMethod < 0)
                        {
                            custDmdPrcWork.ConsTaxLayMethod = taxRateSetWork.ConsTaxLayMethod;     //消費税転嫁方式
                        }
                        else
                        {
                            custDmdPrcWork.ConsTaxLayMethod = customerWork.ConsTaxLayMethod;       //消費税転嫁方式
                        }

                        custDmdPrcWork.TotalAmountDispWayCd = customerWork.TotalAmountDispWayCd;   //総額表示方法区分
                        custDmdPrcWork.TotalAmntDspWayRef = customerWork.TotalAmntDspWayRef;       //総額表示方法参照区分

                        //※端数処理区分を税率マスタから取得するパターンから売上金額処理区分設定マスタから取得
                        //　パターンに変更
                        //●売上金額処理区分設定マスタ
                        custDmdPrcWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
                        
                        //●税率設定マスタから
                        //税率セット
                        if (custDmdPrcWork.AddUpDate >= taxRateSetWork.TaxRateStartDate && custDmdPrcWork.AddUpDate <= taxRateSetWork.TaxRateEndDate)
                        {
                            //税率
                            custDmdPrcWork.ConsTaxRate = taxRateSetWork.TaxRate;
                        }
                        else if (custDmdPrcWork.AddUpDate >= taxRateSetWork.TaxRateStartDate2 && custDmdPrcWork.AddUpDate <= taxRateSetWork.TaxRateEndDate2)
                        {
                            //税率2
                            custDmdPrcWork.ConsTaxRate = taxRateSetWork.TaxRate2;
                        }
                        else if (custDmdPrcWork.AddUpDate >= taxRateSetWork.TaxRateStartDate3 && custDmdPrcWork.AddUpDate <= taxRateSetWork.TaxRateEndDate3)
                        {
                            //税率3
                            custDmdPrcWork.ConsTaxRate = taxRateSetWork.TaxRate3;
                        }

                        custDmdPrcWork.MngSectionCode = customerWork.MngSectionCode;
                        custDmdPrcWork.AcceptWholeSale = customerWork.AcceptWholeSale;
                        custDmdPrcWork.UpdateStatus = 0;   //更新ステータス
                        custDmdPrcWork.CollectCond = customerWork.CollectCond;
                        
                        // 入金予定日計算 >>>
                        // 集金月区分によってセット内容変動( クエリ内で処理しきれない為、セット時に計算 )
                        collectmoneyDate = custDmdPrcUpdateWork.AddUpDate;
                        //add by liusy #32866 2012/10/18-->>>>>
                        //if (collectmoneyDate.Year != 9999 && collectmoneyDate.Month != 12)//del by dpp #33856 2012/12/12
                        if (collectmoneyDate.Year != 9999)//add by dpp #33856 2012/12/12
                        {
                        //add by liusy #32866 2012/10/18--<<<<<
                            switch (customerWork.CollectMoneyCode) // 0:当月,1:翌月,2:翌々月,3翌々々月
                            {
                                case 1:
                                    collectmoneyDate = collectmoneyDate.AddMonths(1);
                                    break;
                                case 2:
                                    collectmoneyDate = collectmoneyDate.AddMonths(2);
                                    break;
                                case 3:
                                    collectmoneyDate = collectmoneyDate.AddMonths(3);
                                    break;
                            }
                            // 28日以降は末日とする
                            if (customerWork.CollectMoneyDay >= 28)
                            {
                                collectmoneyDate = new DateTime(collectmoneyDate.Year, collectmoneyDate.Month, 1);
                                collectmoneyDate = collectmoneyDate.AddMonths(1);
                                collectmoneyDate = collectmoneyDate.AddDays(-1);
                            }
                            else
                            {
                                collectmoneyDate = new DateTime(collectmoneyDate.Year, collectmoneyDate.Month, customerWork.CollectMoneyDay);
                            }
                        //add by liusy #32866 2012/10/18-->>>>>
                        }
                        //add by liusy #32866 2012/10/18--<<<<<
                        custDmdPrcWork.ExpectedDepositDate = collectmoneyDate;　// 入金予定日
                        // 入金予定日計算 <<<
                        custDmdPrcWork.BillPrintDate = DateTime.Now;  // 請求書発行日(システム日付)


                        if (custDmdPrcWork.ClaimCode == custDmdPrcWork.CustomerCode)
                        {
                            custDmdPrcWorkList.Add(custDmdPrcWork);
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        #endregion
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
        /// 得意先マスタ、税率設定マスタ、全体初期値設定マスタから更新情報を取得します
        /// </summary>
        /// <param name="custDmdPrcUpdateWork">得意先請求金額マスタ更新パラメータ</param>
        /// <param name="custDmdPrcWork">得意先請求金額マスタ更新パラメータ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ、税率設定マスタ、全体初期値設定マスタから更新情報を取得します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.02</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        /// </remarks>
        private int GetIndivCustomer(ref CustDmdPrcUpdateWork custDmdPrcUpdateWork, ref CustDmdPrcWork custDmdPrcWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            //得意先マスタ
            CustomerWork customerWork = null;
            //税率設定マスタ
            TaxRateSetWork taxRateSetWork = null;

            string sqlText = string.Empty; // 2008.07.18 add

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                    // 2008.07.18 upd start ------------------------------------------------------------------->>
                    #region DEL
                    //sqlCommand.CommandText = "SELECT A.ENTERPRISECODERF,A.CUSTOMERCODERF,CAST(DECRYPTBYKEY(A.NAMERF) AS NVARCHAR(30)) AS NAMERF,CAST(DECRYPTBYKEY(A.NAME2RF) AS NVARCHAR(30)) AS NAME2RF,CAST(DECRYPTBYKEY(A.CUSTOMERSNMRF) AS NVARCHAR(20)) AS CUSTOMERSNMRF,A.CLAIMCODERF,CAST(DECRYPTBYKEY(A.CLAIMNAMERF) AS NVARCHAR(30)) AS CLAIMNAMERF,CAST(DECRYPTBYKEY(A.CLAIMNAME2RF) AS NVARCHAR(30)) AS CLAIMNAME2RF,CAST(DECRYPTBYKEY(A.CLAIMSNMRF) AS NVARCHAR(20)) AS CLAIMSNMRF,A.TOTALDAYRF,A.CONSTAXLAYMETHODRF,A.TOTALAMOUNTDISPWAYCDRF,A.TOTALAMNTDSPWAYREFRF, "
                    //                    + "B.TAXRATESTARTDATERF,B.TAXRATEENDDATERF,B.TAXRATERF,B.TAXRATESTARTDATE2RF,B.TAXRATEENDDATE2RF,B.TAXRATE2RF,B.TAXRATESTARTDATE3RF,B.TAXRATEENDDATE3RF,B.TAXRATE3RF,B.CONSTAXLAYMETHODRF CONSTAXLAYMETHOD_TAXRF,C.FRACTIONPROCCDRF "
                    //                    // ↓ 2008.03.12 980081 a
                    //                    + ",A.MNGSECTIONCODERF,A.ACCEPTWHOLESALERF "
                    //                    // ↑ 2008.03.12 980081 a
                    //                    + "FROM CUSTOMERRF AS A WITH (READUNCOMMITTED) LEFT JOIN TAXRATESETRF AS B WITH (READUNCOMMITTED) ON A.ENTERPRISECODERF=B.ENTERPRISECODERF "
                    //                    + "LEFT JOIN SALESPROCMONEYRF AS C WITH (READUNCOMMITTED) ON A.ENTERPRISECODERF=C.ENTERPRISECODERF AND C.FRACPROCMONEYDIVRF=1 AND A.SALESCNSTAXFRCPROCCDRF=C.FRACTIONPROCCODERF "
                    //                    + "WHERE A.ENTERPRISECODERF=@FINDENTERPRISECODE AND A.CUSTOMERCODERF=@FINDCUSTOMERCODE AND B.TAXRATECODERF=0 ";
                    #endregion
                    sqlText = string.Empty;
                    sqlText += "SELECT A.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    ,A.CUSTOMERCODERF" + Environment.NewLine;
                    // 修正 2008.12.10 >>>
                    #region DEL
                    //sqlText += "    ,CAST" + Environment.NewLine;
                    //sqlText += "    (DECRYPTBYKEY" + Environment.NewLine;
                    //sqlText += "        (A.NAMERF" + Environment.NewLine;
                    //sqlText += "        ) AS NVARCHAR" + Environment.NewLine;
                    //sqlText += "        (30" + Environment.NewLine;
                    //sqlText += "        )" + Environment.NewLine;
                    //sqlText += "    ) AS NAMERF" + Environment.NewLine;
                    //sqlText += "    ,CAST" + Environment.NewLine;
                    //sqlText += "    (DECRYPTBYKEY" + Environment.NewLine;
                    //sqlText += "        (A.NAME2RF" + Environment.NewLine;
                    //sqlText += "        ) AS NVARCHAR" + Environment.NewLine;
                    //sqlText += "        (30" + Environment.NewLine;
                    //sqlText += "        )" + Environment.NewLine;
                    //sqlText += "    ) AS NAME2RF" + Environment.NewLine;
                    //sqlText += "    ,CAST" + Environment.NewLine;
                    //sqlText += "    (DECRYPTBYKEY" + Environment.NewLine;
                    //sqlText += "        (A.CUSTOMERSNMRF" + Environment.NewLine;
                    //sqlText += "        ) AS NVARCHAR" + Environment.NewLine;
                    //sqlText += "        (20" + Environment.NewLine;
                    //sqlText += "        )" + Environment.NewLine;
                    //sqlText += "    ) AS CUSTOMERSNMRF" + Environment.NewLine;
                    #endregion
                    sqlText += "    ,A.NAMERF" + Environment.NewLine;
                    sqlText += "    ,A.NAME2RF" + Environment.NewLine;
                    sqlText += "    ,A.CUSTOMERSNMRF" + Environment.NewLine;
                    // 修正 2008.12.10 <<<
                    sqlText += "    ,A.CLAIMCODERF" + Environment.NewLine;
                    sqlText += "    ,D.NAMERF AS CLAIMNAMERF" + Environment.NewLine;
                    sqlText += "    ,D.NAME2RF AS CLAIMNAME2RF" + Environment.NewLine;
                    sqlText += "    ,D.CUSTOMERSNMRF AS CLAIMCUSTOMERSNMRF" + Environment.NewLine;
                    sqlText += "    ,A.TOTALDAYRF" + Environment.NewLine;
                    sqlText += "    ,A.CONSTAXLAYMETHODRF" + Environment.NewLine;
                    sqlText += "    ,A.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                    sqlText += "    ,A.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATESTARTDATERF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATEENDDATERF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATERF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATESTARTDATE2RF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATEENDDATE2RF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATE2RF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATESTARTDATE3RF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATEENDDATE3RF" + Environment.NewLine;
                    sqlText += "    ,B.TAXRATE3RF" + Environment.NewLine;
                    sqlText += "    ,B.CONSTAXLAYMETHODRF CONSTAXLAYMETHOD_TAXRF" + Environment.NewLine;
                    sqlText += "    ,C.FRACTIONPROCCDRF" + Environment.NewLine;
                    sqlText += "    ,A.MNGSECTIONCODERF" + Environment.NewLine;
                    sqlText += "    ,A.ACCEPTWHOLESALERF" + Environment.NewLine;
                    sqlText += "    ,A.CLAIMSECTIONCODERF" + Environment.NewLine;
                    sqlText += "    ,A.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                    sqlText += "    ,D.COLLECTCONDRF" + Environment.NewLine;
                    sqlText += "    ,D.COLLECTMONEYCODERF" + Environment.NewLine;
                    sqlText += "    ,D.COLLECTMONEYDAYRF" + Environment.NewLine;
                    sqlText += " FROM CUSTOMERRF AS A WITH (READUNCOMMITTED) LEFT" + Environment.NewLine;
                    // 税率設定マスタ
                    sqlText += " JOIN TAXRATESETRF AS B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "  ON A.ENTERPRISECODERF=B.ENTERPRISECODERF LEFT" + Environment.NewLine;
                    // 売上金額処理区分設定マスタ
                    sqlText += " JOIN SALESPROCMONEYRF AS C WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "  ON A.ENTERPRISECODERF=C.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND C.FRACPROCMONEYDIVRF=1" + Environment.NewLine;
                    sqlText += "  AND A.SALESCNSTAXFRCPROCCDRF=C.FRACTIONPROCCODERF LEFT" + Environment.NewLine;
                    // 得意先マスタ
                    sqlText += " JOIN CUSTOMERRF AS D WITH(READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "  ON A.ENTERPRISECODERF=D.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND A.CLAIMCODERF=D.CUSTOMERCODERF" + Environment.NewLine;

                    sqlText += " WHERE A.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND A.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "    AND B.TAXRATECODERF=0" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    // 2008.07.18 upd end ---------------------------------------------------------------------<<

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);


                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        customerWork = new CustomerWork();
                        taxRateSetWork = new TaxRateSetWork();
                        //得意先マスタ・税率設定マスタからデータセット
                        customerWork = CopyToCustomerWorkFromReader(ref myReader);
                        taxRateSetWork = CopyToTaxRateSetWorkFromReader(ref myReader);


                        //●得意先マスタから
                        custDmdPrcWork.EnterpriseCode = customerWork.EnterpriseCode;   //企業コード
                        custDmdPrcWork.ClaimCode = customerWork.ClaimCode;             //請求先コード
                        custDmdPrcWork.ClaimName = customerWork.ClaimName;             //請求先名称
                        custDmdPrcWork.ClaimName2 = customerWork.ClaimName2;           //請求先名称2
                        custDmdPrcWork.ClaimSnm = customerWork.ClaimSnm;               //請求先略称
                        custDmdPrcWork.CustomerCode = customerWork.CustomerCode;       //得意先コード
                        custDmdPrcWork.CustomerName = customerWork.Name;               //得意先名称
                        custDmdPrcWork.CustomerName2 = customerWork.Name2;             //得意先名称2
                        custDmdPrcWork.CustomerTotalDay = customerWork.TotalDay;       //得意先締日
                        if (customerWork.ConsTaxLayMethod < 0)
                        {
                            custDmdPrcWork.ConsTaxLayMethod = taxRateSetWork.ConsTaxLayMethod;  //消費税転嫁方式
                        }
                        else
                        {
                            custDmdPrcWork.ConsTaxLayMethod = customerWork.ConsTaxLayMethod;    //消費税転嫁方式
                        }
                        custDmdPrcWork.TotalAmountDispWayCd = customerWork.TotalAmountDispWayCd;//総額表示方法区分
                        custDmdPrcWork.TotalAmntDspWayRef = customerWork.TotalAmntDspWayRef;    //総額表示方法参照区分

                        //●売上金額処理区分設定マスタ
                        //端数処理区分
                        custDmdPrcWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));

                        //●税率設定マスタから
                        //税率セット
                        if (custDmdPrcWork.AddUpDate >= taxRateSetWork.TaxRateStartDate && custDmdPrcWork.AddUpDate <= taxRateSetWork.TaxRateEndDate)
                        {
                            //税率
                            custDmdPrcWork.ConsTaxRate = taxRateSetWork.TaxRate;
                        }
                        else if (custDmdPrcWork.AddUpDate >= taxRateSetWork.TaxRateStartDate2 && custDmdPrcWork.AddUpDate <= taxRateSetWork.TaxRateEndDate2)
                        {
                            //税率2
                            custDmdPrcWork.ConsTaxRate = taxRateSetWork.TaxRate2;
                        }
                        else if (custDmdPrcWork.AddUpDate >= taxRateSetWork.TaxRateStartDate3 && custDmdPrcWork.AddUpDate <= taxRateSetWork.TaxRateEndDate3)
                        {
                            //税率3
                            custDmdPrcWork.ConsTaxRate = taxRateSetWork.TaxRate3;
                        }
                        
                        custDmdPrcWork.MngSectionCode = customerWork.MngSectionCode;
                        custDmdPrcWork.AcceptWholeSale = customerWork.AcceptWholeSale;
                        custDmdPrcWork.AddUpSecCode = customerWork.ClaimSectionCode;
                        if (custDmdPrcUpdateWork.TermLastDiv == 1)
                        {
                            custDmdPrcWork.CustomerSlipNoDiv = 2; //得意先伝票番号区分
                        }
                        else
                        {
                            custDmdPrcWork.CustomerSlipNoDiv = customerWork.CustomerSlipNoDiv; //得意先伝票番号区分
                        }
                        custDmdPrcWork.UpdateStatus = 0;   //更新ステータス

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

        #region [全体初期値設定マスタ]
        /// <summary>
        /// 全体初期値設定マスタから総額表示方法区分を取得します
        /// </summary>
        /// <param name="custDmdPrcWork">請求準備処理パラメータ</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 全体初期値設定マスタから総額表示方法区分を取得します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.07</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        /// </remarks>
        private int GetTotalAmount(ref CustDmdPrcWork custDmdPrcWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            string sqlText = string.Empty; // 2008.07.18 add

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                    // 2008.07.18 upd start ----------------------------------------------------->>
                    //sqlCommand.CommandText = "SELECT TOTALAMOUNTDISPWAYCDRF FROM ALLDEFSETRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDADDUPSECCODE ";
                    sqlText = string.Empty;
                    sqlText += "SELECT TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                    sqlText += " FROM ALLDEFSETRF WITH" + Environment.NewLine;
                    sqlText += "    (READUNCOMMITTED" + Environment.NewLine;
                    sqlText += "    )" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND SECTIONCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    // 2008.07.18 upd end -------------------------------------------------------<<

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //全体初期値設定マスタからデータセット
                        custDmdPrcWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));

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

        #region [前回情報取得 請求締更新履歴マスタ 得意先請求金額マスタ]
        /// <summary>
        /// 前回情報取得　請求締更新履歴マスタ/得意先請求金額マスタ
        /// </summary>
        /// <param name="custDmdPrcWork">請求金額マスタワーク用クラス</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 前回情報取得　請求締更新履歴マスタ得意先請求金額マスタ</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.16</br>
        /// </remarks>
        public int GetDmdCAddUpHisAndCustDmdPrc(ref CustDmdPrcWork custDmdPrcWork, ref SqlConnection sqlConnection)
        {
            return GetDmdCAddUpHisAndCustDmdPrcPrc(ref custDmdPrcWork, ref sqlConnection);
        }

        /// <summary>
        /// 前回情報取得　請求締更新履歴マスタ/得意先請求金額マスタ
        /// </summary>
        /// <param name="custDmdPrcWork">請求金額マスタワーク用クラス</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 前回情報取得　請求締更新履歴マスタ得意先請求金額マスタ</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.16</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        /// </remarks>
        private int GetDmdCAddUpHisAndCustDmdPrcPrc(ref CustDmdPrcWork custDmdPrcWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            string sqlText = string.Empty; // 2008.07.18 add
            
            Int64 thisTimeDmdNrml = 0;       // 2008.07.18 add 今回入金金額  
            Int64 dmdNrml1 = 0;              // 2008.07.18 add 入金金額① 
            Int64 dmdNrml2 = 0;              // 2008.07.18 add 入金金額②
            Int64 lastTimeDemand = 0;        // 2008.07.18 add 前回請求金額
            Int64 acpOdrTtl2TmBfBlDmd = 0;   // 2008.07.18 add 前々回請求金額
            Int64 acpOdrTtl3TmBfBlDmd = 0;   // 2008.07.18 add 前前々回請求金額

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                    #region [2008.10.01 DEL]
                    /* --- DEL 2008.10.01 ---------->>>>>
                    // 2008.07.18 upd start ----------------------------------------------------->>
                    //sqlCommand.CommandText = "SELECT AFCALDEMANDPRICERF,LASTTIMEDEMANDRF,ACPODRTTL2TMBFBLDMDRF,ADDUPDATERF FROM CUSTDMDPRCRF WITH (READUNCOMMITTED) "
                    //                + "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CLAIMCODERF=@FINDCUSTOMERCODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND "
                    //                + "ADDUPDATERF=(SELECT MAX(CADDUPUPDDATERF) FROM DMDCADDUPHISRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ADDUPSECCODERF=@FINDADDUPSECCODE)";
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "     THISTIMEDMDNRMLRF" + Environment.NewLine;
                    sqlText += "    ,AFCALDEMANDPRICERF" + Environment.NewLine;
                    sqlText += "    ,LASTTIMEDEMANDRF" + Environment.NewLine;
                    sqlText += "    ,ACPODRTTL2TMBFBLDMDRF" + Environment.NewLine;
                    sqlText += "    ,ADDUPDATERF" + Environment.NewLine;
                    sqlText += " FROM CUSTDMDPRCRF WITH" + Environment.NewLine;
                    sqlText += "    (READUNCOMMITTED" + Environment.NewLine;
                    sqlText += "    )" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "    AND ADDUPDATERF=" + Environment.NewLine;
                    sqlText += "    (" + Environment.NewLine;
                    sqlText += "        SELECT MAX" + Environment.NewLine;
                    sqlText += "            (CADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += "            )" + Environment.NewLine;
                    sqlText += "        FROM DMDCADDUPHISRF WITH" + Environment.NewLine;
                    sqlText += "            (READUNCOMMITTED" + Environment.NewLine;
                    sqlText += "            )" + Environment.NewLine;
                    sqlText += "        WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "            AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "            AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "    )" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    // 2008.07.18 upd end -------------------------------------------------------<<

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    // ↓ 2007.11.20 980081 c
                    //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                    // ↑ 2007.11.20 980081 c
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                       --- DEL 2008.10.01 ----------<<<<< */
                    #endregion

                    // --- ADD 2008.10.01 ---------->>>>>
                    #region [Select文作成]
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "   AFCALDEMANDPRICERF" + Environment.NewLine;
                    sqlText += "  ,LASTTIMEDEMANDRF" + Environment.NewLine;
                    sqlText += "  ,ACPODRTTL2TMBFBLDMDRF" + Environment.NewLine;
                    sqlText += "  ,ACPODRTTL3TMBFBLDMDRF" + Environment.NewLine;
                    sqlText += "  ,ADDUPDATERF" + Environment.NewLine;
                    sqlText += "  ,THISTIMEDMDNRMLRF" + Environment.NewLine;
                    sqlText += "  ,OFSTHISTIMESALESRF" + Environment.NewLine;
                    sqlText += "  ,OFSTHISSALESTAXRF" + Environment.NewLine;
                    sqlText += " FROM CUSTDMDPRCRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    //sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;  // DEL 2010/10/06
                    sqlText += "  AND RESULTSSECTCDRF='00'" + Environment.NewLine;  // ADD 2010/11/24
                    sqlText += "  AND CUSTOMERCODERF=0" + Environment.NewLine;      // ADD 2010/11/24
                    sqlText += "  AND ADDUPDATERF=" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    // 修正 2008.11.19 >>>
                    #region DEL 2008.11.19
                    // DEL 2008.11.19 >>>
                    //sqlText += "   SELECT MAX(CADDUPUPDDATERF)" + Environment.NewLine;
                    //sqlText += "   FROM DMDCADDUPHISRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    //sqlText += "   WHERE" + Environment.NewLine;
                    //sqlText += "        ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    ////sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine; // DEL 2008.10.20
                    //sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    //sqlText += "    AND PROCDIVCDRF=0" + Environment.NewLine;
                    //sqlText += "    AND HISTCTLCDRF=0" + Environment.NewLine;
                    // DEL 2008.11.19 <<<
                    #endregion
                    sqlText += "    SELECT" + Environment.NewLine;
                    sqlText += "       MAX(ADDUPDATERF)" + Environment.NewLine;
                    sqlText += "    FROM CUSTDMDPRCRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "    WHERE" + Environment.NewLine;
                    sqlText += "         ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "     AND CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    //sqlText += "     AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;  // DEL 2010/10/06
                    sqlText += "     AND RESULTSSECTCDRF='00'" + Environment.NewLine;  // ADD 2010/11/24
                    sqlText += "     AND CUSTOMERCODERF=0" + Environment.NewLine;      // ADD 2010/11/24
                    sqlText += "     AND ADDUPDATERF<@FINDADDUPDATE" + Environment.NewLine;

                    // 修正 2008.11.19 <<<
                    sqlText += "  )" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Select文作成]

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int); 
                    //SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);  // DEL 2010/10/06
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int); // ADD 2009/07/03

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode); 
                    //findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);  // DEL 2010/10/06
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate); // ADD 2009/07/03
                    // --- ADD 2008.10.01 ----------<<<<<

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // 修正 2008.12.10 >>>
                        #region 2008.12.10 DEL
                        /*
                        ////前回請求金額　←　計算後請求金額
                        //custDmdPrcWork.LastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"));
                        ////受注2回前残高（請求計）←　前回請求金額
                        //custDmdPrcWork.AcpOdrTtl2TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEDEMANDRF"));
                        ////受注3回前残高（請求計）←　受注2回前残高（請求計）
                        //custDmdPrcWork.AcpOdrTtl3TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"));

                        // 今回入金額
                        thisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
                        // 計算後請求金額
                        lastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"));
                        // 前回請求金額
                        acpOdrTtl2TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEDEMANDRF"));
                        // 前々回請求金額　 + 前々々回請求金額
                        acpOdrTtl3TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFBLDMDRF")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"));

                        // 入金金額減算
                        if (acpOdrTtl3TmBfBlDmd - thisTimeDmdNrml >= 0)
                        {
                            acpOdrTtl3TmBfBlDmd = acpOdrTtl3TmBfBlDmd - thisTimeDmdNrml;
                        }
                        else
                        {
                            dmdNrml1 = thisTimeDmdNrml - acpOdrTtl3TmBfBlDmd;
                            acpOdrTtl3TmBfBlDmd = 0;

                            if (acpOdrTtl2TmBfBlDmd - dmdNrml1 >= 0)
                            {
                                acpOdrTtl2TmBfBlDmd = acpOdrTtl2TmBfBlDmd - dmdNrml1;
                            }
                            else
                            {
                                dmdNrml2 = dmdNrml1 - acpOdrTtl2TmBfBlDmd;
                                acpOdrTtl2TmBfBlDmd = 0;
                                lastTimeDemand = lastTimeDemand - dmdNrml2;
                            }
                        }
                        // 前回請求金額
                        custDmdPrcWork.LastTimeDemand = lastTimeDemand;
                        // 受注2回前残高（請求計）
                        custDmdPrcWork.AcpOdrTtl2TmBfBlDmd = acpOdrTtl2TmBfBlDmd;
                        // 受注3回前残高（請求計）
                        custDmdPrcWork.AcpOdrTtl3TmBfBlDmd = acpOdrTtl3TmBfBlDmd;                        
                        //前回締次更新年月日　←　計上年月日
                        custDmdPrcWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
                        */
                        #endregion

                        // 今回入金額
                        thisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));                        
                        // 計算後請求金額
                        //lastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"));
                        lastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
                        // 前回請求金額
                        acpOdrTtl2TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEDEMANDRF"));
                        // 前々回請求金額　 + 前々々回請求金額
                        acpOdrTtl3TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFBLDMDRF")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"));

                        //if (acpOdrTtl2TmBfBlDmd < 0) // 前回残がマイナス値の場合、前々回残へ移動しない
                        //{
                        //    lastTimeDemand = lastTimeDemand + acpOdrTtl2TmBfBlDmd;
                        //    acpOdrTtl2TmBfBlDmd = 0;
                        //}

                        if (lastTimeDemand == 0 && acpOdrTtl2TmBfBlDmd == 0 && acpOdrTtl3TmBfBlDmd == 0)
                        {
                            // 計算後請求金額
                            lastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
                            // 計算後請求金額
                            custDmdPrcWork.LastTimeDemand = lastTimeDemand - thisTimeDmdNrml;
                            //前回締次更新年月日　←　計上年月日
                            custDmdPrcWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
                        }
                        else
                        {
                            if (thisTimeDmdNrml > 0)
                            {
                                // 入金金額減算
                                if (acpOdrTtl3TmBfBlDmd - thisTimeDmdNrml >= 0)
                                {
                                    acpOdrTtl3TmBfBlDmd = acpOdrTtl3TmBfBlDmd - thisTimeDmdNrml;
                                }
                                else
                                {
                                    dmdNrml1 = thisTimeDmdNrml - acpOdrTtl3TmBfBlDmd;
                                    acpOdrTtl3TmBfBlDmd = 0;

                                    if (acpOdrTtl2TmBfBlDmd - dmdNrml1 >= 0)
                                    {
                                        acpOdrTtl2TmBfBlDmd = acpOdrTtl2TmBfBlDmd - dmdNrml1;
                                    }
                                    else
                                    {
                                        dmdNrml2 = dmdNrml1 - acpOdrTtl2TmBfBlDmd;
                                        acpOdrTtl2TmBfBlDmd = 0;
                                        lastTimeDemand = lastTimeDemand - dmdNrml2;
                                    }
                                }
                            }
                            else if (thisTimeDmdNrml < 0) // マイナス入金の場合の処理
                            {
                                if ((acpOdrTtl3TmBfBlDmd >= 0) && (acpOdrTtl2TmBfBlDmd >= 0))
                                {
                                    // マイナス入金の場合、前回残高に入金金額加算
                                    lastTimeDemand = lastTimeDemand - thisTimeDmdNrml;
                                }
                                else if (acpOdrTtl3TmBfBlDmd < 0) // 3回前残がマイナスの場合
                                {
                                    if (acpOdrTtl3TmBfBlDmd - thisTimeDmdNrml <= 0)
                                    {
                                        acpOdrTtl3TmBfBlDmd = acpOdrTtl3TmBfBlDmd - thisTimeDmdNrml;
                                        lastTimeDemand = lastTimeDemand + acpOdrTtl3TmBfBlDmd + acpOdrTtl2TmBfBlDmd;
                                        acpOdrTtl3TmBfBlDmd = 0;
                                        acpOdrTtl2TmBfBlDmd = 0;
                                    }
                                    else
                                    {
                                        // --- UPD m.suzuki 2010/03/01 ---------->>>>>
                                        //dmdNrml1 = thisTimeDmdNrml + acpOdrTtl3TmBfBlDmd;
                                        // 入金work ← 前月入金 - ３回前残
                                        dmdNrml1 = thisTimeDmdNrml - acpOdrTtl3TmBfBlDmd;
                                        // --- UPD m.suzuki 2010/03/01 ----------<<<<<
                                        acpOdrTtl3TmBfBlDmd = 0;

                                        if (acpOdrTtl2TmBfBlDmd < 0)
                                        {
                                            if (acpOdrTtl2TmBfBlDmd - dmdNrml1 <= 0)
                                            {
                                                acpOdrTtl2TmBfBlDmd = acpOdrTtl2TmBfBlDmd - dmdNrml1;
                                                lastTimeDemand = lastTimeDemand  + acpOdrTtl2TmBfBlDmd;
                                                acpOdrTtl2TmBfBlDmd = 0;

                                            }
                                            else
                                            {
                                                dmdNrml2 = dmdNrml1 - acpOdrTtl2TmBfBlDmd;
                                                acpOdrTtl2TmBfBlDmd = 0;
                                                lastTimeDemand = lastTimeDemand - dmdNrml2;
                                            }
                                        }
                                        else
                                        {
                                            lastTimeDemand = lastTimeDemand - dmdNrml1;
                                        }
                                    }
                                }
                                else if (acpOdrTtl2TmBfBlDmd < 0)
                                {
                                    if (acpOdrTtl2TmBfBlDmd - thisTimeDmdNrml <= 0)
                                    {
                                        acpOdrTtl2TmBfBlDmd = acpOdrTtl2TmBfBlDmd - thisTimeDmdNrml;
                                        lastTimeDemand = lastTimeDemand + acpOdrTtl2TmBfBlDmd;
                                        acpOdrTtl2TmBfBlDmd = 0;
                                    }
                                    else
                                    {
                                        dmdNrml1 = thisTimeDmdNrml - acpOdrTtl2TmBfBlDmd;
                                        acpOdrTtl2TmBfBlDmd = 0;
                                        lastTimeDemand = lastTimeDemand - dmdNrml1;
                                    }
                                }
                            }


                            // 前回請求金額
                            custDmdPrcWork.LastTimeDemand = lastTimeDemand;
                            // 受注2回前残高（請求計）
                            custDmdPrcWork.AcpOdrTtl2TmBfBlDmd = acpOdrTtl2TmBfBlDmd;
                            // 受注3回前残高（請求計）
                            custDmdPrcWork.AcpOdrTtl3TmBfBlDmd = acpOdrTtl3TmBfBlDmd;
                            //前回締次更新年月日　←　計上年月日
                            custDmdPrcWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));


                        }
                        // 修正 2008.12.10　<<<
                        if (custDmdPrcWork.LastCAddUpUpdDate != DateTime.MinValue)
                        {
                            //締次更新開始年月日
                            custDmdPrcWork.StartCAddUpUpdDate = custDmdPrcWork.LastCAddUpUpdDate.AddDays(1.0);
                        }
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        //初期データ挿入時はデータがないので前回締次更新年月日に最小値を挿入する
                        custDmdPrcWork.LastCAddUpUpdDate = DateTime.MinValue;
                        custDmdPrcWork.StartCAddUpUpdDate = DateTime.MinValue;
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

        #region [請求締更新履歴マスタ(更新可否チェック)]
        /// <summary>
        /// 請求締更新履歴マスタのチェック
        /// </summary>
        /// <param name="custDmdPrcWork">請求金額マスタ更新パラメータ</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 請求締更新履歴マスタのチェック</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>s
        /// <br>Date       : 2007.03.22</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        /// </remarks>
        private int CheckDmdCAddUpHis(ref CustDmdPrcWork custDmdPrcWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
            SqlDataReader myReader = null;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                    #region [2008.10.01 DEL]
                    /* --- DEL 2008.10.01 ---------->>>>>
                    // 2008.07.18 upd start ----------------------------------------------------->>
                    //sqlCommand.CommandText = "SELECT * FROM DMDCADDUPHISRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND CADDUPUPDDATERF>=@FINDADDUPDATE ";
                    string sqlText = string.Empty;
                    sqlText += "SELECT *" + Environment.NewLine;
                    sqlText += " FROM DMDCADDUPHISRF WITH" + Environment.NewLine;
                    sqlText += "    (READUNCOMMITTED" + Environment.NewLine;
                    sqlText += "    )" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "    AND CADDUPUPDDATERF>=@FINDADDUPDATE" + Environment.NewLine;
                    sqlText += "    AND PROCDIVCDRF=0" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    // 2008.07.18 upd end -------------------------------------------------------<<

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    // ↓ 2007.11.20 980081 c
                    //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                    // ↑ 2007.11.20 980081 c
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);
                       --- DEL 2008.10.01 ----------<<<<< */
                    #endregion

                    // --- ADD 2008.10.01 ---------->>>>>
                    #region [Select文作成]
                    string sqlText = string.Empty;
                    sqlText += "SELECT *" + Environment.NewLine;
                    sqlText += " FROM DMDCADDUPHISRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    //sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine; // DEL 2008.10.20
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;  // 計上拠点コード
                    sqlText += "  AND CADDUPUPDDATERF>=@FINDADDUPDATE" + Environment.NewLine;   // 締次更新年月日
                    sqlText += "  AND PROCDIVCDRF=0" + Environment.NewLine;                     // 処理区分
                    sqlText += "  AND HISTCTLCDRF=0" + Environment.NewLine;                     // 履歴制御区分

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Select文作成]

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int); // DEL 2008.10.20
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode); // DEL 2008.10.20
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);
                    // --- ADD 2008.10.01 ----------<<<<<

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //未更新ステータス挿入
                        custDmdPrcWork.UpdateStatus = 1;

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        //更新ステータス挿入
                        custDmdPrcWork.UpdateStatus = 0;

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

        #region [入金マスタ ]
        /// <summary>
        /// 得意先請求金額ワーク用Listから入金マスタを取得します
        /// </summary>
        /// <param name="custDmdPrcWork">得意先請求金額マスタ更新List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額ワーク用Listから入金マスタを取得します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.15</br>
        /// </remarks>
        public int GetDepsitMain(ref CustDmdPrcWork custDmdPrcWork, ref SqlConnection sqlConnection)
        {
            return GetDepsitMainPrc(ref custDmdPrcWork, ref sqlConnection);
        }

        /// <summary>
        /// 得意先請求金額ワーク用Listから入金マスタを取得します
        /// </summary>
        /// <param name="custDmdPrcWork">得意先請求金額マスタ更新List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額ワーク用Listから入金マスタを取得します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.15</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        /// </remarks>
        private int GetDepsitMainPrc(ref CustDmdPrcWork custDmdPrcWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;

            //入金マスタ
            DepsitMainWork depsitMainWork = null;

            try
            {
                // 修正 2008.12.10 >>>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM DEPSITMAINRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CLAIMCODERF=@FINDCUSTOMERCODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND (ADDUPADATERF<=@FINDADDUPDATE AND ADDUPADATERF>@FINDLASTTIMEADDUPDATE) ", sqlConnection))
                //{
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                    String sqlText = string.Empty;
                    // 修正 2008.12.10 >>>
                    #region 2008.12.10 DEL
                    /*
                    sqlText += "SELECT *" + Environment.NewLine;
                    sqlText += " FROM DEPSITMAINRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "       AND CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "       AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "       AND (" + Environment.NewLine;
                    sqlText += "             ADDUPADATERF<=@FINDADDUPDATE" + Environment.NewLine;
                    sqlText += "             AND ADDUPADATERF>@FINDLASTTIMEADDUPDATE" + Environment.NewLine;
                    sqlText += "           )" + Environment.NewLine;
                    */
                    #endregion
                    sqlText += "SELECT" + Environment.NewLine;
                    //sqlText += "  CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += " CLAIMCODERF" + Environment.NewLine; 
                    //sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;  // DEL 2008.12.10
                    sqlText += " ,SUM(DEPOSITTOTALRF) AS DEPOSITTOTALRF" + Environment.NewLine;
                    sqlText += " ,SUM(FEEDEPOSITRF) AS FEEDEPOSITRF" + Environment.NewLine;
                    sqlText += " ,SUM(DISCOUNTDEPOSITRF) AS DISCOUNTDEPOSITRF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ---------->>>>>
                    //sqlText += " DEPSITMAINRF" + Environment.NewLine;
                    sqlText += " DEPSITMAINRF WITH(READUNCOMMITTED) " + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ----------<<<<<
                    sqlText += "WHERE " + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;     
                    //sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;  // DEL 2008.12.10
                    //sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "  AND (ADDUPADATERF<=@FINDADDUPDATE" + Environment.NewLine;
                    sqlText += "        AND ADDUPADATERF>@FINDLASTTIMEADDUPDATE" + Environment.NewLine;
                    sqlText += "       )" + Environment.NewLine;
                    sqlText += "  AND LOGICALDELETECODERF = 0" + Environment.NewLine; // ADD 2009/04/24
                    sqlText += "GROUP BY" + Environment.NewLine;
                    //sqlText += " CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += " CLAIMCODERF" + Environment.NewLine;
                    //sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                    //sqlText += " ,DEPOSITDEBITNOTECDRF" + Environment.NewLine;
                    //sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    // 修正 2008.12.10 <<<

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    //SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar); // DEL 2008.12.10 
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
                    
                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    // 修正 2008.12.10 >>>
                    #region DEL 2008.12.10
                    // ↓ 2007.11.20 980081 c
                    ////findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                    //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                    //// ↑ 2007.11.20 980081 c
                    #endregion
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                    // 修正 2008.12.10 <<<

                    //findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);　 // DEL 2008.12.10 
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);
                    
                    // --- UPD m.suzuki 2010/07/21 ---------->>>>>
                    //if (custDmdPrcWork.LastCAddUpUpdDate == DateTime.MinValue)
                    //    findParaLastTimeAddUpDate.Value = 20000101;
                    //else
                    //    findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.LastCAddUpUpdDate);

                    if ( custDmdPrcWork.LastCAddUpUpdDate != DateTime.MinValue )
                    {
                        findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( custDmdPrcWork.LastCAddUpUpdDate );
                    }
                    else if ( custDmdPrcWork.ExtractStartDate != DateTime.MinValue )
                    {
                        findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( custDmdPrcWork.ExtractStartDate.AddDays( -1 ) );
                    }
                    else
                    {
                        findParaLastTimeAddUpDate.Value = 20000101;
                    }
                    // --- UPD m.suzuki 2010/07/21 ----------<<<<<

                    myReader = sqlCommand.ExecuteReader();


                    while (myReader.Read())
                    {
                        depsitMainWork = new DepsitMainWork();
                        
                        depsitMainWork = CopyToDepsitMainWorkFromReader(ref myReader);

                        // 修正 2008.12.10 >>>
                        ////計上拠点コード
                        //custDmdPrcWork.AddUpSecCode = depsitMainWork.AddUpSecCode;
                        custDmdPrcWork.AddUpSecCode = custDmdPrcWork.AddUpSecCode; // 請求拠点コード(得意先マスタ)
                        custDmdPrcWork.ClaimCode = custDmdPrcWork.ClaimCode;       // 請求得意先(得意先マスタ)
                        // 修正 2008.12.10 <<<
                        
                        //得意先請求金額マスタ更新パラメータ作成
                        // 修正 2008.12.10 >>>
                        #region 2008.12.10 DEL
                        // ↓ 2007.11.20 980081 c
                        //#region 旧レイアウト(コメントアウト)
                        //////預り金区分
                        ////if (depsitMainWork.DepositCd == 0)
                        ////{
                        ////    custDmdPrcWork.ThisTimeDmdNrml += depsitMainWork.Deposit;      //今回入金金額（通常入金）
                        ////    custDmdPrcWork.ThisTimeFeeDmdNrml += depsitMainWork.FeeDeposit;    //今回手数料額（通常入金）
                        ////    custDmdPrcWork.ThisTimeDisDmdNrml += depsitMainWork.DiscountDeposit;   //今回値引金額（通常入金）
                        ////    custDmdPrcWork.ThisTimeRbtDmdNrml += depsitMainWork.RebateDeposit;     //今回リベート額（通常入金）
                        ////}
                        ////else if (depsitMainWork.DepositCd == 1)
                        ////{
                        ////    custDmdPrcWork.ThisTimeDmdDepo += depsitMainWork.Deposit;      //今回入金金額（預り金）
                        ////    custDmdPrcWork.ThisTimeFeeDmdDepo += depsitMainWork.FeeDeposit;    //今回手数料額（預り金）
                        ////    custDmdPrcWork.ThisTimeDisDmdDepo += depsitMainWork.DiscountDeposit;    //今回値引額（預り金）
                        ////    custDmdPrcWork.ThisTimeRbtDmdDepo += depsitMainWork.RebateDeposit;      //今回リベート額（預り金）
                        ////}
                        //#endregion
                        ////if (depsitMainWork.DepositCd == 0 && depsitMainWork.AutoDepositCd == 0) // 2008.07.18 del
                        //if (depsitMainWork.AutoDepositCd == 0)                                    // 2008.07.18 add
                        //{
                        #endregion
                        // 修正 2008.12.10 >>> 
                        custDmdPrcWork.ThisTimeDmdNrml += depsitMainWork.DepositTotal;         //今回入金金額（通常入金）合計金額を加算
                        custDmdPrcWork.ThisTimeFeeDmdNrml += depsitMainWork.FeeDeposit;        //今回手数料額（通常入金）
                        custDmdPrcWork.ThisTimeDisDmdNrml += depsitMainWork.DiscountDeposit;   //今回値引金額（通常入金）
                        //}
                        // ↑ 2007.11.20 980081 c
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

        #region [入金明細データ]
        /// <summary>
        /// 得意先請求金額ワーク用Listから入金明細データを取得します
        /// </summary>
        /// <param name="custDmdPrcWork">得意先請求金額マスタ更新List</param>
        /// <param name="dmdDepoTotalWorkList">請求入金集計データ更新List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額ワーク用Listから入金明細データを取得します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.07.18</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        /// </remarks>
        private int GetDepsitDtlMain(ref CustDmdPrcWork custDmdPrcWork, ref ArrayList dmdDepoTotalWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //int moneyKindCode = 0;

            List<DmdDepoTotalWork> dmdDepoTotalList = new List<DmdDepoTotalWork>();   // データ格納用

            SqlDataReader myReader = null;

            string sqlText = string.Empty;

            //入金明細データ
            // 修正 2008.12.10 >>>
            #region 2008.12.10 DEL
            /*
            sqlText += "SELECT" + Environment.NewLine;
            sqlText += " DEPS.CREATEDATETIMERF" + Environment.NewLine;
            sqlText += ",DEPS.UPDATEDATETIMERF" + Environment.NewLine;
            sqlText += ",DEPS.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += ",DEPS.FILEHEADERGUIDRF" + Environment.NewLine;
            sqlText += ",DEPS.UPDEMPLOYEECODERF" + Environment.NewLine;
            sqlText += ",DEPS.UPDASSEMBLYID1RF" + Environment.NewLine;
            sqlText += ",DEPS.UPDASSEMBLYID2RF" + Environment.NewLine;
            sqlText += ",DEPS.LOGICALDELETECODERF" + Environment.NewLine;
            sqlText += ",DEPS.ADDUPSECCODERF" + Environment.NewLine;
            sqlText += ",DEPS.ADDUPADATERF" + Environment.NewLine;
            sqlText += ",DEPS.CUSTOMERCODERF" + Environment.NewLine;
            sqlText += ",DEPS.CUSTOMERNAMERF" + Environment.NewLine;
            sqlText += ",DEPS.CUSTOMERNAME2RF" + Environment.NewLine;
            sqlText += ",DEPS.CLAIMCODERF" + Environment.NewLine;
            sqlText += ",DEPS.CLAIMNAMERF" + Environment.NewLine; 
            sqlText += ",DEPS.CLAIMNAME2RF" + Environment.NewLine;
            // --- ADD 2008.10.01 ---------->>>>>
            //sqlText += ",DEPDTL1.MONEYKINDCODERF" + Environment.NewLine;
            //sqlText += ",DEPDTL1.MONEYKINDNAMERF" + Environment.NewLine;
            //sqlText += ",DEPDTL1.MONEYKINDDIVRF" + Environment.NewLine;
            //sqlText += ",DEPDTL1.DEPOSITRF" + Environment.NewLine;
            sqlText += ",DEPDTL.MONEYKINDCODERF" + Environment.NewLine;
            sqlText += ",DEPDTL.MONEYKINDNAMERF" + Environment.NewLine;
            sqlText += ",DEPDTL.MONEYKINDDIVRF" + Environment.NewLine;
            sqlText += ",DEPDTL.DEPOSITRF" + Environment.NewLine;
            // --- ADD 2008.10.01 ----------<<<<<
            sqlText += "FROM DEPSITMAINRF AS DEPS" + Environment.NewLine;
            sqlText += "INNER JOIN DEPSITDTLRF AS DEPDTL ON" + Environment.NewLine;
            sqlText += "(" + Environment.NewLine;
            sqlText += "DEPDTL.ENTERPRISECODERF= DEPS.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND DEPDTL.ACPTANODRSTATUSRF= DEPS.ACPTANODRSTATUSRF" + Environment.NewLine;
            sqlText += "    AND DEPDTL.DEPOSITSLIPNORF= DEPS.DEPOSITSLIPNORF" + Environment.NewLine;
            sqlText += ")" + Environment.NewLine;
            sqlText += "WHERE DEPS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += " AND DEPS.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
            sqlText += " AND DEPS.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
            sqlText += " AND (DEPS.ADDUPADATERF<=@FINDADDUPDATE AND DEPS.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
            sqlText += "ORDER BY DEPDTL.MONEYKINDCODERF" + Environment.NewLine;
            */
            #endregion
            /*
            sqlText += "SELECT" + Environment.NewLine;
            sqlText += "DEPS.CLAIMCODERF," + Environment.NewLine;
            //sqlText += "DEPS.CUSTOMERCODERF," + Environment.NewLine;
            sqlText += "DEPDTL.MONEYKINDCODERF ," + Environment.NewLine;            
            sqlText += "DEPDTL.MONEYKINDNAMERF," + Environment.NewLine;
            sqlText += "DEPDTL.MONEYKINDDIVRF," + Environment.NewLine;
            sqlText += "SUM(DEPDTL.DEPOSITRF) AS DEPOSITRF" + Environment.NewLine;
            sqlText += "FROM DEPSITMAINRF AS DEPS" + Environment.NewLine;
            sqlText += "INNER JOIN DEPSITDTLRF AS DEPDTL" + Environment.NewLine;
            sqlText += " ON (DEPDTL.ENTERPRISECODERF= DEPS.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "     AND DEPDTL.ACPTANODRSTATUSRF= DEPS.ACPTANODRSTATUSRF" + Environment.NewLine;
            sqlText += "     AND DEPDTL.DEPOSITSLIPNORF= DEPS.DEPOSITSLIPNORF)" + Environment.NewLine;
            sqlText += "WHERE DEPS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "  AND DEPS.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
            //sqlText += "  AND DEPS.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
            //sqlText += "  AND DEPS.CUSTOMERCODERF=@FINDCLAIMCODE" + Environment.NewLine;
            sqlText += "  AND (DEPS.ADDUPADATERF<=@FINDADDUPDATE AND DEPS.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
            sqlText += "GROUP BY" + Environment.NewLine;
            sqlText += "  DEPS.CLAIMCODERF," + Environment.NewLine;
            //sqlText += "  DEPS.CUSTOMERCODERF," + Environment.NewLine;
            sqlText += "  DEPDTL.MONEYKINDCODERF," + Environment.NewLine;            
            sqlText += "  DEPDTL.MONEYKINDNAMERF," + Environment.NewLine;
            sqlText += "  DEPDTL.MNEYKINDDIVRF" + Environment.NewLine;
            */



            sqlText += "SELECT" + Environment.NewLine;
            sqlText += "DEP.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "DEP.CLAIMCODERF," + Environment.NewLine;
            sqlText += "DEP.MONEYKINDCODERF ," + Environment.NewLine;
            sqlText += "DEP.DEPOSITRF," + Environment.NewLine;
            sqlText += "(CASE WHEN MONEYKIND.MONEYKINDNAMERF IS NOT NULL THEN MONEYKIND.MONEYKINDNAMERF ELSE '未登録' END) AS MONEYKINDNAMERF," + Environment.NewLine;
            sqlText += "(CASE WHEN MONEYKIND.MONEYKINDDIVRF IS NOT NULL THEN MONEYKIND.MONEYKINDDIVRF ELSE 0 END) AS MONEYKINDDIVRF" + Environment.NewLine;
            sqlText += "FROM" + Environment.NewLine;
            sqlText += "(" + Environment.NewLine;
            sqlText += "SELECT" + Environment.NewLine;
            sqlText += "DEPS.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "DEPS.CLAIMCODERF," + Environment.NewLine;
            sqlText += "DEPDTL.MONEYKINDCODERF ," + Environment.NewLine;
            // 修正 2009.01.16 >>>
            //sqlText += "SUM(DEPDTL.DEPOSITRF) AS DEPOSITRF" + Environment.NewLine;
            sqlText += "SUM(CASE WHEN DEPS.DEPOSITDEBITNOTECDRF = 1 THEN DEPDTL.DEPOSITRF *-1  ELSE DEPDTL.DEPOSITRF END) AS DEPOSITRF" + Environment.NewLine;
            // 修正2009.01.16 <<<
            // --- UPD T.Nishi 2012/02/15 ---------->>>>>
            //sqlText += "FROM DEPSITMAINRF AS DEPS" + Environment.NewLine;
            //sqlText += "INNER JOIN DEPSITDTLRF AS DEPDTL" + Environment.NewLine;
            sqlText += "FROM DEPSITMAINRF AS DEPS WITH(READUNCOMMITTED) " + Environment.NewLine;
            sqlText += "INNER JOIN DEPSITDTLRF AS DEPDTL WITH(READUNCOMMITTED) " + Environment.NewLine;
            // --- UPD T.Nishi 2012/02/15 ----------<<<<<
            sqlText += " ON (DEPDTL.ENTERPRISECODERF= DEPS.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "     AND DEPDTL.ACPTANODRSTATUSRF= DEPS.ACPTANODRSTATUSRF" + Environment.NewLine;
            // 修正 2009.01.16 >>>
            //sqlText += "     AND DEPDTL.DEPOSITSLIPNORF= DEPS.DEPOSITSLIPNORF)" + Environment.NewLine;
            sqlText += "     AND ((DEPS.DEPOSITDEBITNOTECDRF != 1 AND DEPS.DEPOSITSLIPNORF = DEPDTL.DEPOSITSLIPNORF) OR" + Environment.NewLine;
            sqlText += "          (DEPS.DEPOSITDEBITNOTECDRF = 1 AND DEPS.DEBITNOTELINKDEPONORF = DEPDTL.DEPOSITSLIPNORF)))" + Environment.NewLine;
            // 修正 2009.01.16 <<<
            sqlText += "WHERE DEPS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "  AND DEPS.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
            sqlText += "  AND (DEPS.ADDUPADATERF<=@FINDADDUPDATE AND DEPS.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
            sqlText += "  AND DEPS.LOGICALDELETECODERF = 0" + Environment.NewLine; // ADD 2009/04/24
            sqlText += "GROUP BY" + Environment.NewLine;
            sqlText += "  DEPS.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "  DEPS.CLAIMCODERF," + Environment.NewLine;
            sqlText += "  DEPDTL.MONEYKINDCODERF" + Environment.NewLine;
            sqlText += ") AS DEP" + Environment.NewLine;
            // --- UPD T.Nishi 2012/02/15 ---------->>>>>
            //sqlText += "LEFT JOIN MONEYKINDURF AS MONEYKIND" + Environment.NewLine;
            sqlText += "LEFT JOIN MONEYKINDURF AS MONEYKIND WITH(READUNCOMMITTED) " + Environment.NewLine;
            // --- UPD T.Nishi 2012/02/15 ----------<<<<<
            sqlText += "ON DEP.ENTERPRISECODERF = MONEYKIND.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "AND DEP.MONEYKINDCODERF = MONEYKIND.MONEYKINDCODERF" + Environment.NewLine;


            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    //SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    //findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                    //findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode); // 得意先コード
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);

                    // --- UPD m.suzuki 2010/07/21 ---------->>>>>
                    //if (custDmdPrcWork.LastCAddUpUpdDate == DateTime.MinValue)
                    //    findParaLastTimeAddUpDate.Value = 20000101;
                    //else
                    //    findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.LastCAddUpUpdDate);

                    if ( custDmdPrcWork.LastCAddUpUpdDate != DateTime.MinValue )
                    {
                        findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( custDmdPrcWork.LastCAddUpUpdDate );
                    }
                    else if ( custDmdPrcWork.ExtractStartDate != DateTime.MinValue )
                    {
                        findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( custDmdPrcWork.ExtractStartDate.AddDays( -1 ) );
                    }
                    else
                    {
                        findParaLastTimeAddUpDate.Value = 20000101;
                    }
                    // --- UPD m.suzuki 2010/07/21 ----------<<<<<

                    DmdDepoTotalWork dmdDepoTotalWork = new DmdDepoTotalWork();

                    myReader = sqlCommand.ExecuteReader();

                    // 修正 2008.12.10 >>>
                    #region　2008.12.10 DEL
                    /*                     
                    while (myReader.Read())
                    {
                        //請求入金集計にセット
                        dmdDepoTotalWork = CopyToDmdDepoTotalWorkFromReader(ref myReader);
                        dmdDepoTotalList.Add(dmdDepoTotalWork);
                    }

                    if (dmdDepoTotalList.Count > 0)
                    {
                        moneyKindCode = dmdDepoTotalList[0].MoneyKindCode;
                        dmdDepoTotalWork = new DmdDepoTotalWork();
                        SetDmdDepoTotal(ref dmdDepoTotalWork, dmdDepoTotalList[0]);

                        for (int i = 1; i < dmdDepoTotalList.Count; i++)
                        {
                            if (moneyKindCode == dmdDepoTotalList[i].MoneyKindCode)
                            {
                                SetDmdDepoTotal(ref dmdDepoTotalWork, dmdDepoTotalList[i]);
                            }
                            else
                            {
                                moneyKindCode = dmdDepoTotalList[i].MoneyKindCode;

                                dmdDepoTotalWork = new DmdDepoTotalWork();
                                SetDmdDepoTotal(ref dmdDepoTotalWork, dmdDepoTotalList[i]);
                                dmdDepoTotalWorkList.Add(dmdDepoTotalWork);
                            }
                        }
                    }
                    */
                    #endregion
                    while (myReader.Read())
                    {
                        //請求入金集計にセット
                        dmdDepoTotalWork = CopyToDmdDepoTotalWorkFromReader(ref myReader);
                        // 修正 2009.01.16 >>>
                        if (dmdDepoTotalWork.Deposit == 0)
                        {
                            continue;
                        }
                        // 修正 2009.01.16 <<<
                        dmdDepoTotalWork.EnterpriseCode = custDmdPrcWork.EnterpriseCode; // 企業コード 
                        dmdDepoTotalWork.AddUpDate = custDmdPrcWork.AddUpDate;       // 計上年月日(画面設定値)
                        dmdDepoTotalWork.AddUpSecCode = custDmdPrcWork.AddUpSecCode; // 請求拠点(得意先マスタ)
                        dmdDepoTotalWork.ClaimCode = custDmdPrcWork.ClaimCode; 　　　// 請求得意先(得意先マスタ)
                        dmdDepoTotalWork.CustomerCode = custDmdPrcWork.ClaimCode; 

                        dmdDepoTotalWorkList.Add(dmdDepoTotalWork);
                    }
                    // 修正 2008.12.10 <<<

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

        private void SetDmdDepoTotal(ref DmdDepoTotalWork dmdDepoTotalWork, DmdDepoTotalWork dmdDepoTotalList)
        {
            dmdDepoTotalWork.CreateDateTime = dmdDepoTotalList.CreateDateTime;
            dmdDepoTotalWork.UpdateDateTime = dmdDepoTotalList.UpdateDateTime;
            dmdDepoTotalWork.EnterpriseCode = dmdDepoTotalList.EnterpriseCode;
            dmdDepoTotalWork.FileHeaderGuid = dmdDepoTotalList.FileHeaderGuid;
            dmdDepoTotalWork.UpdEmployeeCode = dmdDepoTotalList.UpdEmployeeCode;
            dmdDepoTotalWork.UpdAssemblyId1 = dmdDepoTotalList.UpdAssemblyId1;
            dmdDepoTotalWork.UpdAssemblyId2 = dmdDepoTotalList.UpdAssemblyId2;
            dmdDepoTotalWork.LogicalDeleteCode = dmdDepoTotalList.LogicalDeleteCode;
            dmdDepoTotalWork.AddUpSecCode = dmdDepoTotalList.AddUpSecCode;
            dmdDepoTotalWork.ClaimCode = dmdDepoTotalList.ClaimCode;
            dmdDepoTotalWork.CustomerCode = dmdDepoTotalList.CustomerCode;
            dmdDepoTotalWork.AddUpDate = dmdDepoTotalList.AddUpDate;
            dmdDepoTotalWork.MoneyKindCode = dmdDepoTotalList.MoneyKindCode;
            dmdDepoTotalWork.MoneyKindName = dmdDepoTotalList.MoneyKindName;
            dmdDepoTotalWork.MoneyKindDiv = dmdDepoTotalList.MoneyKindDiv;
            dmdDepoTotalWork.Deposit += dmdDepoTotalList.Deposit;
        }
        #endregion

        #region [売上データ]
        /// <summary>
        /// 得意先請求金額ワーク用Listから売上データを取得します
        /// </summary>
        /// <param name="custDmdPrcWork">得意先請求金額ワーク</param>
        /// <param name="custDmdPrcChildWorkList">請求金額マスタ更新パラメータList</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額ワーク用Listから売上データを取得します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.15</br>
        /// </remarks>
        public int GetSalesSlip(ref CustDmdPrcWork custDmdPrcWork, ref ArrayList custDmdPrcChildWorkList, ref SqlConnection sqlConnection)
        {
            return GetSalesSlipProc(ref custDmdPrcWork, ref custDmdPrcChildWorkList, ref sqlConnection);
        }

        /// <summary>
        /// 得意先請求金額ワーク用Listから売上データを取得します
        /// </summary>
        /// <param name="custDmdPrcWork">得意先請求金額ワーク</param>
        /// <param name="custDmdPrcChildWorkList">請求金額マスタ更新パラメータList</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額ワーク用Listから売上データを取得します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.15</br>
        /// <br>Update Note		:	2010/12/20  鄧潘ハン</br>
        /// <br>					①得意先請求金額マスタのデータセット仕様変更</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        /// <br>Update Note: 2012/12/12 dpp</br>
        /// <br>管理番号   : 10801804-00 2013/01/16配信分</br>
        /// <br>             Redmine#33856 入金予定日の計算の不正</br> 
        /// </remarks>
        // ↓ 2007.11.20 980081 c
        //private int GetSalesSlip(ref CustDmdPrcWork custDmdPrcWork, ref SqlConnection sqlConnection)
        private int GetSalesSlipProc(ref CustDmdPrcWork custDmdPrcWork, ref ArrayList custDmdPrcChildWorkList, ref SqlConnection sqlConnection)
        // ↑ 2007.11.20 980081 c
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;

            //売上データ
            //SalesSlipWork salesSlipWork = null;

            try
            { 

                // 修正 2008.12.10 >>>

                #region 2008.12.10 DEL
                ////※サービス伝票区分=OFFのみ抽出　受注ステータス=売上のみ抽出
                //// ↓ 2007.11.20 980081 c
                ////using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM SALESSLIPRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CLAIMCODERF=@FINDCUSTOMERCODE AND DEMANDADDUPSECCDRF=@FINDADDUPSECCODE AND (ADDUPADATERF<=@FINDADDUPDATE AND ADDUPADATERF>@FINDLASTTIMEADDUPDATE) AND SERVICESLIPCDRF=0 AND ACPTANODRSTATUSRF=30 ", sqlConnection))
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM SALESSLIPRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CLAIMCODERF=@FINDCUSTOMERCODE AND DEMANDADDUPSECCDRF=@FINDADDUPSECCODE AND (ADDUPADATERF<=@FINDADDUPDATE AND ADDUPADATERF>@FINDLASTTIMEADDUPDATE) AND LOGICALDELETECODERF=0 AND ACPTANODRSTATUSRF=30 AND DEBITNOTEDIVRF=0 AND ACCRECDIVCDRF=1 ORDER BY CLAIMCODERF,CUSTOMERCODERF ", sqlConnection))
                #endregion

                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                    //string sqlText = string.Empty;// DEL 菅原 庸平 2012/04/27
                    StringBuilder sqlText = new StringBuilder();// ADD 菅原 庸平 2012/04/27

                    #region 2008.12.10 DEL
                    /*
                    string sqlText = string.Empty;
                    sqlText += "SELECT *" + Environment.NewLine;
                    sqlText += " FROM SALESSLIPRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "   AND CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "   AND DEMANDADDUPSECCDRF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "   AND(ADDUPADATERF<=@FINDADDUPDATE AND ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                    sqlText += "   AND LOGICALDELETECODERF=0" + Environment.NewLine;
                    sqlText += "   AND ACPTANODRSTATUSRF=30" + Environment.NewLine;
                    sqlText += "   AND DEBITNOTEDIVRF=0" + Environment.NewLine;
                    //sqlText += "   AND ACCRECDIVCDRF=1" + Environment.NewLine;
                    sqlText += " ORDER BY " + Environment.NewLine;
                    sqlText += "    CLAIMCODERF" + Environment.NewLine;
                    sqlText += "   ,CUSTOMERCODERF" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                // 修正 2008.12.10 <<<

                // ↑ 2007.11.20 980081 c
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastCAddUpUpdDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    // ↓ 2007.11.20 980081 c
                    //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                    // ↑ 2007.11.20 980081 c
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);
                    if (custDmdPrcWork.LastCAddUpUpdDate == DateTime.MinValue)
                        findParaLastCAddUpUpdDate.Value = 20000101;
                    else
                        findParaLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.LastCAddUpUpdDate);
                    
                    // ↓ 2007.11.20 980081 a
                    custDmdPrcWork.CustomerCode = 0;
                    custDmdPrcWork.SalesSlipCount = 0;
                    int customerCode = 0;
                    //Int64 offsetOutTax = 0;
                    CustDmdPrcWork custDmdPrcChildWork = new CustDmdPrcWork();
                    // ↑ 2007.11.20 980081 a
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        salesSlipWork = new SalesSlipWork();
                        
                        salesSlipWork = CopyToSalesSlipWorkFromReader(ref myReader);

                        // ↓ 2007.09.14 980081 a
                        if (customerCode == 0 || customerCode != salesSlipWork.CustomerCode)
                        {
                            if (customerCode != 0)
                            {
                                // 2008.07.18 upd start ------------------------------------------------->>
                                #region 2008.07.18 DEL
                                ////相殺後今回売上金額 = 今回売上金額＋今回売上返品金額＋今回売上値引＋今回支払相殺金額
                                //custDmdPrcChildWork.OfsThisTimeSales = custDmdPrcChildWork.ThisTimeSales + custDmdPrcChildWork.ThisSalesPricRgds + custDmdPrcChildWork.ThisSalesPricDis + custDmdPrcChildWork.ThisPayOffset;
                                ////相殺後外税対象額 = 売上外税対象額+売上返品外税対象額＋売上値引外税対象額＋相殺支払外税対象額
                                //custDmdPrcChildWork.ItdedOffsetOutTax = custDmdPrcChildWork.ItdedSalesOutTax + custDmdPrcChildWork.TtlItdedRetOutTax + custDmdPrcChildWork.TtlItdedDisOutTax + custDmdPrcChildWork.ItdedPaymOutTax;
                                ////相殺後内税対象額 = 売上内税額合計＋返品内税額合計＋値引内税額合計＋支払内税額合計
                                //custDmdPrcChildWork.ItdedOffsetInTax = custDmdPrcChildWork.SalesInTax + custDmdPrcChildWork.TtlRetInnerTax + custDmdPrcChildWork.TtlDisInnerTax + custDmdPrcChildWork.PaymentInTax;
                                ////相殺後非課税対象額 = 売上非課税対象額+返品非課税税象額合計＋値引非課税対象額合計＋支払非課税対象額
                                //custDmdPrcChildWork.ItdedOffsetTaxFree = custDmdPrcChildWork.ItdedSalesTaxFree + custDmdPrcChildWork.TtlItdedRetTaxFree + custDmdPrcChildWork.TtlItdedDisTaxFree + custDmdPrcChildWork.ItdedPaymTaxFree;
                                ////相殺後内税消費税 = 売上内税額合計＋返品内税額合計＋値引内税額合計＋支払内税額合計
                                //custDmdPrcChildWork.OffsetInTax = custDmdPrcChildWork.SalesInTax + custDmdPrcChildWork.TtlRetInnerTax + custDmdPrcChildWork.TtlDisInnerTax + custDmdPrcChildWork.PaymentInTax;
                                #endregion
                                //相殺後今回売上金額 = 今回売上金額＋今回売上返品金額＋今回売上値引 +残高調整額 
                                custDmdPrcChildWork.OfsThisTimeSales = custDmdPrcChildWork.ThisTimeSales + custDmdPrcChildWork.ThisSalesPricRgds + custDmdPrcChildWork.ThisSalesPricDis + custDmdPrcChildWork.BalanceAdjust;
                                //相殺後外税対象額 = 売上外税対象額+売上返品外税対象額＋売上値引外税対象額
                                custDmdPrcChildWork.ItdedOffsetOutTax = custDmdPrcChildWork.ItdedSalesOutTax + custDmdPrcChildWork.TtlItdedRetOutTax + custDmdPrcChildWork.TtlItdedDisOutTax;
                                //相殺後内税対象額 = 売上内税額合計＋返品内税額合計＋値引内税額合計
                                custDmdPrcChildWork.ItdedOffsetInTax = custDmdPrcChildWork.SalesInTax + custDmdPrcChildWork.TtlRetInnerTax + custDmdPrcChildWork.TtlDisInnerTax;
                                //相殺後非課税対象額 = 売上非課税対象額+返品非課税税象額合計＋値引非課税対象額合計
                                custDmdPrcChildWork.ItdedOffsetTaxFree = custDmdPrcChildWork.ItdedSalesTaxFree + custDmdPrcChildWork.TtlItdedRetTaxFree + custDmdPrcChildWork.TtlItdedDisTaxFree;
                                //相殺後内税消費税 = 売上内税額合計＋返品内税額合計＋値引内税額合計
                                custDmdPrcChildWork.OffsetInTax = custDmdPrcChildWork.SalesInTax + custDmdPrcChildWork.TtlRetInnerTax + custDmdPrcChildWork.TtlDisInnerTax;
                                // 2008.07.18 upd end --------------------------------------------------<<
                                
                                custDmdPrcWork.OffsetInTax += custDmdPrcChildWork.OffsetInTax;
                                if (custDmdPrcWork.ConsTaxLayMethod == 0 || custDmdPrcWork.ConsTaxLayMethod == 1)
                                {
                                    // 2008.07.18 upd start ------------------------------------------------->>
                                    ////消費税転嫁区分 0:伝票、1:明細の場合 売上外税額＋返品外税額＋値引外税額
                                    //custDmdPrcChildWork.OffsetOutTax = custDmdPrcChildWork.SalesOutTax + custDmdPrcChildWork.TtlRetOuterTax + custDmdPrcChildWork.TtlDisOuterTax + custDmdPrcChildWork.PaymentOutTax;
                                    //custDmdPrcChildWork.OffsetInTax = custDmdPrcChildWork.SalesInTax + custDmdPrcChildWork.TtlRetInnerTax + custDmdPrcChildWork.TtlDisInnerTax + custDmdPrcChildWork.PaymentInTax;
                                    //消費税転嫁区分 0:伝票、1:明細の場合 売上外税額＋返品外税額＋値引外税額
                                    custDmdPrcChildWork.OffsetOutTax = custDmdPrcChildWork.SalesOutTax + custDmdPrcChildWork.TtlRetOuterTax + custDmdPrcChildWork.TtlDisOuterTax;
                                    custDmdPrcChildWork.OffsetInTax = custDmdPrcChildWork.SalesInTax + custDmdPrcChildWork.TtlRetInnerTax + custDmdPrcChildWork.TtlDisInnerTax;
                                    // 2008.07.18 upd end --------------------------------------------------<<
                                    custDmdPrcChildWork.OfsThisSalesTax = custDmdPrcChildWork.OffsetOutTax + custDmdPrcChildWork.OffsetInTax + custDmdPrcChildWork.TaxAdjust;
                                }
                                if (custDmdPrcWork.ConsTaxLayMethod == 3)
                                {
                                    //得意先転嫁の場合、消費税算出を行う
                                    //相殺後外税消費税額
                                    custDmdPrcChildWork.OffsetOutTax = Fraction(custDmdPrcChildWork.ItdedOffsetOutTax * custDmdPrcWork.ConsTaxRate, custDmdPrcWork.FractionProcCd);
                                    custDmdPrcWork.OffsetOutTax += custDmdPrcChildWork.OffsetOutTax;
                                    //相殺後消費税額
                                    custDmdPrcChildWork.OfsThisSalesTax = custDmdPrcChildWork.OffsetOutTax + custDmdPrcChildWork.OffsetInTax + custDmdPrcChildWork.TaxAdjust;
                                    custDmdPrcWork.OfsThisSalesTax += custDmdPrcChildWork.OfsThisSalesTax;
                                    //売上外税額(参考値)
                                    custDmdPrcChildWork.SalesOutTax = Fraction(custDmdPrcChildWork.ItdedSalesOutTax * custDmdPrcWork.ConsTaxRate, custDmdPrcWork.FractionProcCd);
                                    custDmdPrcWork.SalesOutTax += custDmdPrcChildWork.SalesOutTax;
                                    //売上消費税額
                                    custDmdPrcChildWork.ThisSalesTax = custDmdPrcChildWork.SalesOutTax + custDmdPrcChildWork.SalesInTax;
                                    custDmdPrcWork.ThisSalesTax += custDmdPrcChildWork.ThisSalesTax;
                                    //返品外税額(参考値)
                                    custDmdPrcChildWork.TtlRetOuterTax = Fraction(custDmdPrcChildWork.TtlItdedRetOutTax * custDmdPrcWork.ConsTaxRate, custDmdPrcWork.FractionProcCd);
                                    custDmdPrcWork.TtlRetOuterTax += custDmdPrcChildWork.TtlRetOuterTax;
                                    //返品消費税額
                                    custDmdPrcChildWork.ThisSalesPrcTaxRgds = custDmdPrcChildWork.TtlRetOuterTax + custDmdPrcChildWork.TtlRetInnerTax;
                                    custDmdPrcWork.ThisSalesPrcTaxRgds += custDmdPrcChildWork.ThisSalesPrcTaxRgds;
                                    //値引外税額(参考値)
                                    custDmdPrcChildWork.TtlDisOuterTax = Fraction(custDmdPrcChildWork.TtlItdedDisOutTax * custDmdPrcWork.ConsTaxRate, custDmdPrcWork.FractionProcCd);
                                    custDmdPrcWork.TtlDisOuterTax += custDmdPrcChildWork.TtlDisOuterTax;
                                    //値引消費税額
                                    custDmdPrcChildWork.ThisSalesPrcTaxDis = custDmdPrcChildWork.TtlDisOuterTax + custDmdPrcChildWork.TtlDisInnerTax;
                                    custDmdPrcWork.ThisSalesPrcTaxDis += custDmdPrcChildWork.ThisSalesPrcTaxDis;
                                }
                                CalculateCustDmdChildPrc(ref custDmdPrcChildWork);
                                custDmdPrcChildWorkList.Add(custDmdPrcChildWork);
                                custDmdPrcChildWork = new CustDmdPrcWork();
                            }
                            customerCode = salesSlipWork.CustomerCode;
                            custDmdPrcChildWork.EnterpriseCode = custDmdPrcWork.EnterpriseCode;
                            custDmdPrcChildWork.AddUpSecCode = custDmdPrcWork.AddUpSecCode;
                            custDmdPrcChildWork.ClaimCode = custDmdPrcWork.ClaimCode;
                            custDmdPrcChildWork.ClaimName = custDmdPrcWork.ClaimName;
                            custDmdPrcChildWork.ClaimName2 = custDmdPrcWork.ClaimName2;
                            custDmdPrcChildWork.ClaimSnm = custDmdPrcWork.ClaimSnm;
                            custDmdPrcChildWork.ResultsSectCd = salesSlipWork.ResultsAddUpSecCd;
                            custDmdPrcChildWork.CustomerCode = salesSlipWork.CustomerCode;
                            custDmdPrcChildWork.CustomerName = salesSlipWork.CustomerName;
                            custDmdPrcChildWork.CustomerName2 = salesSlipWork.CustomerName2;
                            custDmdPrcChildWork.CustomerSnm = salesSlipWork.CustomerSnm;
                            custDmdPrcChildWork.AddUpDate = custDmdPrcWork.AddUpDate;
                            custDmdPrcChildWork.AddUpYearMonth = custDmdPrcWork.AddUpYearMonth;
                            custDmdPrcChildWork.ConsTaxRate = custDmdPrcWork.ConsTaxRate;
                            custDmdPrcChildWork.CAddUpUpdExecDate = custDmdPrcWork.CAddUpUpdExecDate;
                            custDmdPrcChildWork.ExpectedDepositDate = custDmdPrcWork.ExpectedDepositDate;
                            custDmdPrcChildWork.FractionProcCd = custDmdPrcWork.FractionProcCd;
                            custDmdPrcChildWork.ConsTaxLayMethod = custDmdPrcWork.ConsTaxLayMethod;
                            
                        }
                        // ↑ 2007.09.14 980081 a
                        //対象となる売上データを取得します
                        #region [売上データ取得]
                        custDmdPrcWork.AddUpSecCode = salesSlipWork.DemandAddUpSecCd;
                        custDmdPrcWork.ResultsSectCd = salesSlipWork.ResultsAddUpSecCd;
                        // ↓ 2007.11.20 980081 c
                        #region 旧レイアウト(コメントアウト)
                        ////※消費税転嫁方式を得意先ごとに抽出するマスタが未決定
                        ////売上商品区分
                        //if (salesSlipWork.SalesGoodsCd == 0 || salesSlipWork.SalesGoodsCd == 1)
                        //{
                        //    //消費税転嫁方式：伝票転嫁
                        //    if (custDmdPrcWork.ConsTaxLayMethod == 0 || custDmdPrcWork.ConsTaxLayMethod == 1)
                        //    {
                        //        //if (custDmdPrcWork.TotalAmountDispWayCd == 0) //総額表示しない
                        //        if (salesSlipWork.TotalAmountDispWayCd == 0)
                        //        {
                        //            custDmdPrcWork.ItdedSalesOutTaxSlip += salesSlipWork.SalesSubtotalTaxExc; //売上外税対象額（伝票）
                        //            custDmdPrcWork.SalesOutTaxSlip += salesSlipWork.SalesSubtotalTax; //売上外税額（伝票）
                        //        }
                        //        //else if (custDmdPrcWork.TotalAmountDispWayCd == 1) //総額表示する
                        //        else if (salesSlipWork.TotalAmountDispWayCd == 1)
                        //        {
                        //            custDmdPrcWork.ItdedSalesInTaxSlip += salesSlipWork.SalesSubtotalTaxExc; //売上内税対象額（伝票）
                        //        }
                        //    }
                        //    //消費税転嫁方式：請求転嫁
                        //    else if (custDmdPrcWork.ConsTaxLayMethod == 2)
                        //    {
                        //        //if (custDmdPrcWork.TotalAmountDispWayCd == 0) //総額表示しない
                        //        if (salesSlipWork.TotalAmountDispWayCd == 0)
                        //        {
                        //            custDmdPrcWork.ItdedSalesOutTaxDmd += salesSlipWork.SalesSubtotalTaxExc; //売上外税対象額（請求）
                        //        }
                        //        //else if (custDmdPrcWork.TotalAmountDispWayCd == 1) //総額表示する
                        //        else if (salesSlipWork.TotalAmountDispWayCd == 1)
                        //        {
                        //            custDmdPrcWork.ItdedSalesInTaxDmd += salesSlipWork.SalesSubtotalTaxExc; //売上内税対象額（請求）
                        //        }
                        //    }
                        //    custDmdPrcWork.ItdedSalesTaxFree += salesSlipWork.SalSubttlSubToTaxFre; //売上非課税対象額
                        //    //if (custDmdPrcWork.TotalAmountDispWayCd == 1) //総額表示する
                        //    if (salesSlipWork.TotalAmountDispWayCd == 1)
                        //    {
                        //        custDmdPrcWork.SalesInTax += salesSlipWork.SalesSubtotalTax; //売上内税額
                        //    }
                        //}
                        ////消費税調整額
                        //else if (salesSlipWork.SalesGoodsCd == 2)
                        //{
                        //    custDmdPrcWork.TaxAdust += salesSlipWork.TaxAdjust;             //消費税調整額
                        //}
                        ////残高調整額
                        //else if (salesSlipWork.SalesGoodsCd == 3)
                        //{
                        //    custDmdPrcWork.BalanceAdjust += salesSlipWork.BalanceAdjust;    //残高調整額
                        //}
                        #endregion
                        //売上商品区分
                        if (salesSlipWork.SalesGoodsCd == 0)
                        {
                            //売上伝票枚数カウント
                            custDmdPrcWork.SalesSlipCount += 1;
                            custDmdPrcChildWork.SalesSlipCount += 1;
                            //売上
                            if (salesSlipWork.SalesSlipCd == 0)
                            {
                                //今回売上金額 = 値引、返品を含まない 税抜きの売上金額(売上正価金額)
                                // ↓ 2008.02.26 980081 c
                                //custDmdPrcWork.ThisTimeSales += salesSlipWork.SalesTotalTaxExc;
                                //custDmdPrcChildWork.ThisTimeSales += salesSlipWork.SalesTotalTaxExc;
                                custDmdPrcWork.ThisTimeSales += salesSlipWork.SalesNetPrice;
                                custDmdPrcChildWork.ThisTimeSales += salesSlipWork.SalesTotalTaxExc;
                                // ↑ 2008.02.26 980081 c
                                //売上外税対象額 = 売上外税対象額
                                custDmdPrcWork.ItdedSalesOutTax += salesSlipWork.ItdedSalesOutTax;
                                custDmdPrcChildWork.ItdedSalesOutTax += salesSlipWork.ItdedSalesOutTax;
                                //売上内税対象額 = 売上内税対象額
                                custDmdPrcWork.ItdedSalesInTax += salesSlipWork.ItdedSalesInTax;
                                custDmdPrcChildWork.ItdedSalesInTax += salesSlipWork.ItdedSalesInTax;
                                //売上非課税対象額 = 売上小計非課税対象額
                                custDmdPrcWork.ItdedSalesTaxFree += salesSlipWork.SalSubttlSubToTaxFre;
                                custDmdPrcChildWork.ItdedSalesTaxFree += salesSlipWork.SalSubttlSubToTaxFre;
                                if (custDmdPrcWork.ConsTaxLayMethod == 0 || custDmdPrcWork.ConsTaxLayMethod == 1)
                                {
                                    //売上外税額 = 売上の外税額(返品、値引含まず)
                                    //             消費税転嫁区分：明細単位、伝票単位･･･売上金額消費税額(外税)を集計
                                    //             消費税転嫁区分：請求子、請求親････それぞれに集計した売上外税対象額 × 税率 (参考消費税となる)
                                    custDmdPrcWork.SalesOutTax += salesSlipWork.SalesOutTax;
                                    custDmdPrcChildWork.SalesOutTax += salesSlipWork.SalesOutTax;
                                    //今回売上消費税 = 売上外税額＋売上内税額
                                    custDmdPrcWork.ThisSalesTax += salesSlipWork.SalesOutTax + salesSlipWork.SalAmntConsTaxInclu;
                                    custDmdPrcChildWork.ThisSalesTax += salesSlipWork.SalesOutTax + salesSlipWork.SalAmntConsTaxInclu;
                                }
                                //売上内税額 = 内税商品の売上(値引、返品を含まない)の内税額
                                //             売上金額消費税額(内税)
                                custDmdPrcWork.SalesInTax += salesSlipWork.SalAmntConsTaxInclu;
                                custDmdPrcChildWork.SalesInTax += salesSlipWork.SalAmntConsTaxInclu;
                            }
                            //返品
                            else if (salesSlipWork.SalesSlipCd == 1)
                            {
                                //今回売上返品金額 = 値引を含まない 税抜きの売上返品金額(売上正価金額)
                                // ↓ 2008.02.26 980081 c
                                //custDmdPrcWork.ThisSalesPricRgds += salesSlipWork.SalesTotalTaxExc;
                                //custDmdPrcChildWork.ThisSalesPricRgds += salesSlipWork.SalesTotalTaxExc;
                                custDmdPrcWork.ThisSalesPricRgds += salesSlipWork.SalesNetPrice;
                                custDmdPrcChildWork.ThisSalesPricRgds += salesSlipWork.SalesNetPrice;
                                // ↑ 2008.02.26 980081 c
                                //返品外税対象額合計 = 売上外税対象額
                                custDmdPrcWork.TtlItdedRetOutTax += salesSlipWork.ItdedSalesOutTax;
                                custDmdPrcChildWork.TtlItdedRetOutTax += salesSlipWork.ItdedSalesOutTax;
                                //返品内税対象額合計 = 売上内税対象額
                                custDmdPrcWork.TtlItdedRetInTax += salesSlipWork.ItdedSalesInTax;
                                custDmdPrcChildWork.TtlItdedRetInTax += salesSlipWork.ItdedSalesInTax;
                                //返品非課税対象額合計 = 売上小計非課税対象額
                                custDmdPrcWork.TtlItdedRetTaxFree += salesSlipWork.SalSubttlSubToTaxFre;
                                custDmdPrcChildWork.TtlItdedRetTaxFree += salesSlipWork.SalSubttlSubToTaxFre;
                                if (custDmdPrcWork.ConsTaxLayMethod == 0 || custDmdPrcWork.ConsTaxLayMethod == 1)
                                {
                                    //返品外税額合計 = 売上返品の外税額(値引含まず)
                                    //                 消費税転嫁区分：明細単位、伝票単位･･･売上金額消費税額(外税)を集計
                                    //                 消費税転嫁区分：請求子、請求親････それぞれに集計した返品外税対象額合計 × 税率 (参考消費税となる)
                                    custDmdPrcWork.TtlRetOuterTax += salesSlipWork.SalesOutTax;
                                    custDmdPrcChildWork.TtlRetOuterTax += salesSlipWork.SalesOutTax;
                                    //今回売上返品消費税 = 返品外税額額合計＋返品内税額合計
                                    custDmdPrcWork.ThisSalesPrcTaxRgds += salesSlipWork.SalesOutTax + salesSlipWork.SalAmntConsTaxInclu;
                                    custDmdPrcChildWork.ThisSalesPrcTaxRgds += salesSlipWork.SalesOutTax + salesSlipWork.SalAmntConsTaxInclu;
                                }
                                //返品内税額合計 = 内税商品の売上返品の内税額
                                //                 売上金額消費税額(内税)
                                custDmdPrcWork.TtlRetInnerTax += salesSlipWork.SalAmntConsTaxInclu;
                                custDmdPrcChildWork.TtlRetInnerTax += salesSlipWork.SalAmntConsTaxInclu;
                            }
                            
                            //今回売上値引金額 = 売上値引金額計(税抜き)
                            custDmdPrcWork.ThisSalesPricDis += salesSlipWork.SalesDisTtlTaxExc;
                            custDmdPrcChildWork.ThisSalesPricDis += salesSlipWork.SalesDisTtlTaxExc;
                            //値引外税対象額合計 = 売上値引外税対象額合計
                            custDmdPrcWork.TtlItdedDisOutTax += salesSlipWork.ItdedSalesDisOutTax;
                            custDmdPrcChildWork.TtlItdedDisOutTax += salesSlipWork.ItdedSalesDisOutTax;
                            //値引内税対象額合計 = 売上値引内税対象額合計
                            custDmdPrcWork.TtlItdedDisInTax += salesSlipWork.ItdedSalesDisInTax;
                            custDmdPrcChildWork.TtlItdedDisInTax += salesSlipWork.ItdedSalesDisInTax;
                            //値引非課税対象額合計 = 売上値引非課税対象額合計
                            custDmdPrcWork.TtlItdedDisTaxFree += salesSlipWork.ItdedSalesDisTaxFre;
                            custDmdPrcChildWork.TtlItdedDisTaxFree += salesSlipWork.ItdedSalesDisTaxFre;
                            if (custDmdPrcWork.ConsTaxLayMethod == 0 || custDmdPrcWork.ConsTaxLayMethod == 1)
                            {
                                //値引外税額合計 = 値引の外税額
                                //                 消費税転嫁区分：明細単位、伝票単位･･･売上金額消費税額(外税)を集計
                                //                 消費税転嫁区分：請求子、請求親････それぞれに集計した値引外税対象額合計 × 税率 (参考消費税となる)
                                custDmdPrcWork.TtlDisOuterTax += salesSlipWork.SalesDisOutTax;
                                custDmdPrcChildWork.TtlDisOuterTax += salesSlipWork.SalesDisOutTax;
                                //今回売上値引消費税 = 値引外税額合計＋値引内税額合計
                                custDmdPrcWork.ThisSalesPrcTaxDis += salesSlipWork.SalesDisOutTax + salesSlipWork.SalesDisTtlTaxInclu;
                                custDmdPrcChildWork.ThisSalesPrcTaxDis += salesSlipWork.SalesDisOutTax + salesSlipWork.SalesDisTtlTaxInclu;
                            }
                            //値引内税額合計 = 売上金額消費税額(内税)
                            custDmdPrcWork.TtlDisInnerTax += salesSlipWork.SalesDisTtlTaxInclu;
                            custDmdPrcChildWork.TtlDisInnerTax += salesSlipWork.SalesDisTtlTaxInclu;
                        }
                        // 2008.07.18 del start ----------------------------------->>
                        #region 2008.07.18 DEL
                        //相殺・相殺(自動発生)
                        //else if (salesSlipWork.SalesGoodsCd == 11 || salesSlipWork.SalesGoodsCd == 12)
                        //{
                        //    // ↓ 2008.03.17 980081 d
                        //    ////売上伝票枚数カウント
                        //    //custDmdPrcWork.SalesSlipCount += 1;
                        //    //custDmdPrcChildWork.SalesSlipCount += 1;
                        //    // ↑ 2008.03.17 980081 d
                        //    if (salesSlipWork.SalesSlipCd == 0 || salesSlipWork.SalesSlipCd == 1)
                        //    {
                        //        //今回支払相殺金額 = 売上伝票合計(税抜き)
                        //        custDmdPrcWork.ThisPayOffset += salesSlipWork.SalesTotalTaxExc;
                        //        custDmdPrcChildWork.ThisPayOffset += salesSlipWork.SalesTotalTaxExc;
                        //        //支払外税対象額 = 売上外税対象額 ＋ 売上値引外税対象額
                        //        custDmdPrcWork.ItdedPaymOutTax += salesSlipWork.ItdedSalesOutTax + salesSlipWork.ItdedSalesDisOutTax;
                        //        custDmdPrcChildWork.ItdedPaymOutTax += salesSlipWork.ItdedSalesOutTax + salesSlipWork.ItdedSalesDisOutTax;
                        //        //支払内税対象額 = 売上内税対象額 ＋ 売上値引内税対象額
                        //        custDmdPrcWork.ItdedPaymInTax += salesSlipWork.ItdedSalesInTax + salesSlipWork.ItdedSalesDisInTax;
                        //        custDmdPrcChildWork.ItdedPaymInTax += salesSlipWork.ItdedSalesInTax + salesSlipWork.ItdedSalesDisInTax;
                        //        //支払非課税対象額 = 売上小計非課税対象額 ＋売上値引非課税対照額
                        //        custDmdPrcWork.ItdedPaymTaxFree += salesSlipWork.SalSubttlSubToTaxFre + salesSlipWork.ItdedSalseDisTaxFre;
                        //        custDmdPrcChildWork.ItdedPaymTaxFree += salesSlipWork.SalSubttlSubToTaxFre + salesSlipWork.ItdedSalseDisTaxFre;
                        //        if (custDmdPrcWork.ConsTaxLayMethod == 0 || custDmdPrcWork.ConsTaxLayMethod == 1)
                        //        {
                        //            //支払外税消費税 = 相殺の外税額(値引、返品込み)
                        //            //                 消費税転嫁区分：明細単位、伝票単位･･売上金額消費税額(外税)＋ 売上値引消費税額(外税)を集計
                        //            //                 消費税転嫁区分：請求子、請求親･･ それぞれに集計した支払外税対象額合計 × 税率(参考消費税となる)
                        //            custDmdPrcWork.PaymentOutTax += salesSlipWork.SalseOutTax + salesSlipWork.SalesDisOutTax;
                        //            custDmdPrcChildWork.PaymentOutTax += salesSlipWork.SalseOutTax + salesSlipWork.SalesDisOutTax;
                        //            //今回支払相殺消費税 = 支払外税消費税＋支払内税消費税
                        //            custDmdPrcWork.ThisPayOffsetTax += salesSlipWork.ItdedSalesOutTax + salesSlipWork.ItdedSalesDisOutTax + salesSlipWork.SalAmntConsTaxInclu + salesSlipWork.SalesDisTtlTaxInclu;
                        //            custDmdPrcChildWork.ThisPayOffsetTax += salesSlipWork.ItdedSalesOutTax + salesSlipWork.ItdedSalesDisOutTax + salesSlipWork.SalAmntConsTaxInclu + salesSlipWork.SalesDisTtlTaxInclu;
                        //        }
                        //        //支払内税消費税 = 売上金額消費税額(内税)＋ 売上値引金額消費税額(内税)
                        //        custDmdPrcWork.PaymentInTax += salesSlipWork.SalAmntConsTaxInclu + salesSlipWork.SalesDisTtlTaxInclu;
                        //        custDmdPrcChildWork.PaymentInTax += salesSlipWork.SalAmntConsTaxInclu + salesSlipWork.SalesDisTtlTaxInclu;
                        //    }
                        //}
                        #endregion
                        // 2008.07.18 del end -------------------------------------<<
                        //消費税調整
                        else if (salesSlipWork.SalesGoodsCd == 2)
                        {
                            if (salesSlipWork.SalesSlipCd == 0 || salesSlipWork.SalesSlipCd == 1)
                            {
                                //消費税調整額
                                custDmdPrcWork.TaxAdjust += salesSlipWork.SalesSubtotalTax;
                                custDmdPrcChildWork.TaxAdjust += salesSlipWork.SalesSubtotalTax;
                            }
                        }
                        //残高調整
                        else if (salesSlipWork.SalesGoodsCd == 3)
                        {
                            if (salesSlipWork.SalesSlipCd == 0 || salesSlipWork.SalesSlipCd == 1)
                            {
                                //残高調整額
                                custDmdPrcWork.BalanceAdjust += salesSlipWork.SalesTotalTaxInc;
                                custDmdPrcChildWork.BalanceAdjust += salesSlipWork.SalesTotalTaxInc;
                            }
                        }
                        // ↑ 2007.11.20 980081 c
                        #endregion
                        
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    // ↓ 2007.11.20 980081 c
                    #region 旧レイアウト(コメントアウト)
                    ////売上外税対象額
                    //custDmdPrcWork.ItdedSalesOutTax = custDmdPrcWork.ItdedSalesOutTaxSlip + custDmdPrcWork.ItdedSalesOutTaxDmd;
                    ////売上内税対象額
                    //custDmdPrcWork.ItdedSalesInTax = custDmdPrcWork.ItdedSalesInTaxSlip + custDmdPrcWork.ItdedSalesInTaxDmd;
                    ////売上非課税対象額　※伝票転嫁/請求転嫁によって変わらない
                    //
                    ////売上外税額　請求転嫁の場合　(売上小計（税抜き）の合計×消費税税率)，端数処理区分
                    //if (custDmdPrcWork.ConsTaxLayMethod == 2)
                    //{
                    //    custDmdPrcWork.OffsetOutTax = (long)(CalculateConsTax.Fraction(custDmdPrcWork.ItdedOffsetOutTax * custDmdPrcWork.ConsTaxRate, custDmdPrcWork.FractionProcCd));
                    //    custDmdPrcWork.SalesOutTaxDmd = (long)(CalculateConsTax.Fraction(custDmdPrcWork.ItdedSalesOutTaxDmd * custDmdPrcWork.ConsTaxRate, custDmdPrcWork.FractionProcCd));
                    //}
                    ////売上外税額
                    //custDmdPrcWork.SalesOutTax = custDmdPrcWork.SalesOutTaxSlip + custDmdPrcWork.SalesOutTaxDmd;
                    ////売上内税額　※伝票転嫁/請求転嫁によって変わらない
                    #endregion
                    if (customerCode != 0)
                    {
                        // 2008.07.18 upd start -------------------------------------------------------->>
                        #region 2008.07.18 DEL
                        ////相殺後今回売上金額 = 今回売上金額＋今回売上返品金額＋今回売上値引＋今回支払相殺金額
                        //custDmdPrcChildWork.OfsThisTimeSales = custDmdPrcChildWork.ThisTimeSales + custDmdPrcChildWork.ThisSalesPricRgds + custDmdPrcChildWork.ThisSalesPricDis + custDmdPrcChildWork.ThisPayOffset;
                        ////相殺後外税対象額 = 売上外税対象額+売上返品外税対象額＋売上値引外税対象額＋相殺支払外税対象額
                        //custDmdPrcChildWork.ItdedOffsetOutTax = custDmdPrcChildWork.ItdedSalesOutTax + custDmdPrcChildWork.TtlItdedRetOutTax + custDmdPrcChildWork.TtlItdedDisOutTax + custDmdPrcChildWork.ItdedPaymOutTax;
                        ////相殺後内税対象額 = 売上内税額合計＋返品内税額合計＋値引内税額合計＋支払内税額合計
                        //custDmdPrcChildWork.ItdedOffsetInTax = custDmdPrcChildWork.SalesInTax + custDmdPrcChildWork.TtlRetInnerTax + custDmdPrcChildWork.TtlDisInnerTax + custDmdPrcChildWork.PaymentInTax;
                        ////相殺後非課税対象額 = 売上非課税対象額+返品非課税税象額合計＋値引非課税対象額合計＋支払非課税対象額
                        //custDmdPrcChildWork.ItdedOffsetTaxFree = custDmdPrcChildWork.ItdedSalesTaxFree + custDmdPrcChildWork.TtlItdedRetTaxFree + custDmdPrcChildWork.TtlItdedDisTaxFree + custDmdPrcChildWork.ItdedPaymTaxFree;
                        ////相殺後内税消費税 = 売上内税額合計＋返品内税額合計＋値引内税額合計＋支払内税額合計
                        //custDmdPrcChildWork.OffsetInTax = custDmdPrcChildWork.SalesInTax + custDmdPrcChildWork.TtlRetInnerTax + custDmdPrcChildWork.TtlDisInnerTax + custDmdPrcChildWork.PaymentInTax;
                        #endregion
                        //相殺後今回売上金額 = 今回売上金額＋今回売上返品金額＋今回売上値引 + 残高調整額
                        custDmdPrcChildWork.OfsThisTimeSales = custDmdPrcChildWork.ThisTimeSales + custDmdPrcChildWork.ThisSalesPricRgds + custDmdPrcChildWork.ThisSalesPricDis + custDmdPrcChildWork.BalanceAdjust;
                        //相殺後外税対象額 = 売上外税対象額+売上返品外税対象額＋売上値引外税対象額
                        custDmdPrcChildWork.ItdedOffsetOutTax = custDmdPrcChildWork.ItdedSalesOutTax + custDmdPrcChildWork.TtlItdedRetOutTax + custDmdPrcChildWork.TtlItdedDisOutTax;
                        //相殺後内税対象額 = 売上内税額合計＋返品内税額合計＋値引内税額合計
                        custDmdPrcChildWork.ItdedOffsetInTax = custDmdPrcChildWork.SalesInTax + custDmdPrcChildWork.TtlRetInnerTax + custDmdPrcChildWork.TtlDisInnerTax;
                        //相殺後非課税対象額 = 売上非課税対象額+返品非課税税象額合計＋値引非課税対象額合計
                        custDmdPrcChildWork.ItdedOffsetTaxFree = custDmdPrcChildWork.ItdedSalesTaxFree + custDmdPrcChildWork.TtlItdedRetTaxFree + custDmdPrcChildWork.TtlItdedDisTaxFree;
                        //相殺後内税消費税 = 売上内税額合計＋返品内税額合計＋値引内税額合計
                        custDmdPrcChildWork.OffsetInTax = custDmdPrcChildWork.SalesInTax + custDmdPrcChildWork.TtlRetInnerTax + custDmdPrcChildWork.TtlDisInnerTax;
                        // 2008.07.18 upd end ----------------------------------------------------------<<
                        custDmdPrcWork.OffsetInTax += custDmdPrcChildWork.OffsetInTax;
                        if (custDmdPrcWork.ConsTaxLayMethod == 0 || custDmdPrcWork.ConsTaxLayMethod == 1)
                        {
                            // 2008.07.18 upd start -------------------------------------------------------->>
                            #region 2008.07.18 DEL
                            ////消費税転嫁区分 0:伝票、1:明細の場合 売上外税額＋返品外税額＋値引外税額＋支払外税額
                            //custDmdPrcChildWork.OffsetOutTax = custDmdPrcChildWork.SalesOutTax + custDmdPrcChildWork.TtlRetOuterTax + custDmdPrcChildWork.TtlDisOuterTax + custDmdPrcChildWork.PaymentOutTax;
                            //custDmdPrcChildWork.OffsetInTax = custDmdPrcChildWork.SalesInTax + custDmdPrcChildWork.TtlRetInnerTax + custDmdPrcChildWork.TtlDisInnerTax + custDmdPrcChildWork.PaymentInTax;
                            #endregion
                            //消費税転嫁区分 0:伝票、1:明細の場合 売上外税額＋返品外税額＋値引外税額
                            custDmdPrcChildWork.OffsetOutTax = custDmdPrcChildWork.SalesOutTax + custDmdPrcChildWork.TtlRetOuterTax + custDmdPrcChildWork.TtlDisOuterTax;
                            custDmdPrcChildWork.OffsetInTax = custDmdPrcChildWork.SalesInTax + custDmdPrcChildWork.TtlRetInnerTax + custDmdPrcChildWork.TtlDisInnerTax;
                            // 2008.07.18 upd end ----------------------------------------------------------<<
                            custDmdPrcChildWork.OfsThisSalesTax = custDmdPrcChildWork.OffsetOutTax + custDmdPrcChildWork.OffsetInTax + custDmdPrcChildWork.TaxAdjust;
                        }
                        if (custDmdPrcWork.ConsTaxLayMethod == 3)
                        {
                            //得意先転嫁の場合、消費税算出を行う
                            //相殺後外税消費税額
                            custDmdPrcChildWork.OffsetOutTax = Fraction(custDmdPrcChildWork.ItdedOffsetOutTax * custDmdPrcWork.ConsTaxRate, custDmdPrcWork.FractionProcCd);
                            custDmdPrcWork.OffsetOutTax += custDmdPrcChildWork.OffsetOutTax;
                            //相殺後消費税額
                            custDmdPrcChildWork.OfsThisSalesTax = custDmdPrcChildWork.OffsetOutTax + custDmdPrcChildWork.OffsetInTax + custDmdPrcChildWork.TaxAdjust;
                            custDmdPrcWork.OfsThisSalesTax += custDmdPrcChildWork.OfsThisSalesTax;
                            //売上外税額(参考値)
                            custDmdPrcChildWork.SalesOutTax = Fraction(custDmdPrcChildWork.ItdedSalesOutTax * custDmdPrcWork.ConsTaxRate, custDmdPrcWork.FractionProcCd);
                            custDmdPrcWork.SalesOutTax += custDmdPrcChildWork.SalesOutTax;
                            //売上消費税額
                            custDmdPrcChildWork.ThisSalesTax = custDmdPrcChildWork.SalesOutTax + custDmdPrcChildWork.SalesInTax;
                            custDmdPrcWork.ThisSalesTax += custDmdPrcChildWork.ThisSalesTax;
                            //返品外税額(参考値)
                            custDmdPrcChildWork.TtlRetOuterTax = Fraction(custDmdPrcChildWork.TtlItdedRetOutTax * custDmdPrcWork.ConsTaxRate, custDmdPrcWork.FractionProcCd);
                            custDmdPrcWork.TtlRetOuterTax += custDmdPrcChildWork.TtlRetOuterTax;
                            //返品消費税額
                            custDmdPrcChildWork.ThisSalesPrcTaxRgds = custDmdPrcChildWork.TtlRetOuterTax + custDmdPrcChildWork.TtlRetInnerTax;
                            custDmdPrcWork.ThisSalesPrcTaxRgds += custDmdPrcChildWork.ThisSalesPrcTaxRgds;
                            //値引外税額(参考値)
                            custDmdPrcChildWork.TtlDisOuterTax = Fraction(custDmdPrcChildWork.TtlItdedDisOutTax * custDmdPrcWork.ConsTaxRate, custDmdPrcWork.FractionProcCd);
                            custDmdPrcWork.TtlDisOuterTax += custDmdPrcChildWork.TtlDisOuterTax;
                            //値引消費税額
                            custDmdPrcChildWork.ThisSalesPrcTaxDis = custDmdPrcChildWork.TtlDisOuterTax + custDmdPrcChildWork.TtlDisInnerTax;
                            custDmdPrcWork.ThisSalesPrcTaxDis += custDmdPrcChildWork.ThisSalesPrcTaxDis;
                            
                            // 2008.07.18 del start ------------------------------------>>
                            ////支払外税額(参考値)
                            //custDmdPrcChildWork.PaymentOutTax = Fraction(custDmdPrcChildWork.ItdedPaymOutTax * custDmdPrcWork.ConsTaxRate, custDmdPrcWork.FractionProcCd);
                            //custDmdPrcWork.PaymentOutTax += custDmdPrcChildWork.PaymentOutTax;
                            ////支払消費税額
                            //custDmdPrcChildWork.ThisPayOffsetTax = custDmdPrcChildWork.PaymentOutTax + custDmdPrcChildWork.PaymentInTax;
                            //custDmdPrcWork.ThisPayOffsetTax += custDmdPrcChildWork.ThisPayOffsetTax;
                            // 2008.07.18 del end --------------------------------------<<
                        }
                        CalculateCustDmdChildPrc(ref custDmdPrcChildWork);
                        custDmdPrcChildWorkList.Add(custDmdPrcChildWork);
                        custDmdPrcChildWork = new CustDmdPrcWork();
                    }
                    // ↑ 2007.11.20 980081 c
                    */
#endregion

                    if (custDmdPrcWork.CustomerCode == custDmdPrcWork.ClaimCode)
                    {
                        #region ■集計レコード集計処理

                        #region SELECT文

                        #region DEL 2009/04/14
                        /*
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "DMDPRC.CLAIMCODERF," + Environment.NewLine;
                        sqlText += "DMDPRC.CLAIMNAMERF," + Environment.NewLine;
                        sqlText += "DMDPRC.CLAIMNAME2RF," + Environment.NewLine;
                        sqlText += "DMDPRC.CLAIMSNMRF," + Environment.NewLine;
                        sqlText += "DMDPRC.FRACTIONPROCCDRF,  --端数処理単位" + Environment.NewLine;
                        sqlText += "DMDPRC.FRACTIONPROCUNITRF,--端数処理区分" + Environment.NewLine;
                        //sqlText += "DMDPRC.CUSTOMERCODERF," + Environment.NewLine;
                        // ■相殺
                        //相殺後今回売上消費税額/相殺後外税消費税は データセット時に計算
                        sqlText += "DMDPRC.SALESNETPRICERF + DMDPRC.RETSALESNETPRICERF +DMDPRC.SALESDISTTLTAXEXCRF AS OFSTHISTIMESALESRF,       --相殺後今回売上金額" + Environment.NewLine;
                        sqlText += "DMDPRC.ITDEDSALESOUTTAXRF+DMDPRC.RETITDEDSALESOUTTAXRF+DMDPRC.ITDEDSALESDISOUTTAXRF AS ITDEDOFFSETOUTTAXRF, --相殺後外税対象額 " + Environment.NewLine;
                        sqlText += "DMDPRC.ITDEDSALESINTAXRF+ DMDPRC.RETITDEDSALESINTAXRF+ DMDPRC.ITDEDSALESDISINTAXRF AS ITDEDOFFSETINTAXRF," + Environment.NewLine;
                        sqlText += "DMDPRC.SALSUBTTLSUBTOTAXFRERF+DMDPRC.RETSALSUBTTLSUBTOTAXFRERF+DMDPRC.ITDEDSALESDISTAXFRERF AS ITDEDOFFSETTAXFREERF, --相殺後非課税対象額" + Environment.NewLine;
                        sqlText += "DMDPRC.SALAMNTCONSTAXINCLURF + DMDPRC.RETSALAMNTCONSTAXINCLURF + DMDPRC.SALESDISTTLTAXINCLURF AS OFFSETINTAXRF,      --相殺後内税消費税" + Environment.NewLine;
                        // ■売上
                        sqlText += "DMDPRC.SALESNETPRICERF AS THISTIMESALESRF, --今回売上金額" + Environment.NewLine;
                        // 修正 2009.01.20 >>>
                        //sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 OR DMDPRC.CONSTAXLAYMETHODRF=1) THEN DMDPRC.SALESOUTTAXRF " + Environment.NewLine;
                        //sqlText += "ELSE (DMDPRC.SALESOUTTAXRF1 +DMDPRC.SALESOUTTAXRF2 +DMDPRC.SALESOUTTAXRF3) END)+DMDPRC.SALAMNTCONSTAXINCLURF AS THISSALESTAXRF, --今回売上消費税" + Environment.NewLine;
                        sqlText += "(CASE WHEN DMDPRC.CONSTAXLAYMETHODRF=0  THEN DMDPRC.SALESOUTTAXRF " + Environment.NewLine;
                        sqlText += " ELSE (CASE WHEN DMDPRC.CONSTAXLAYMETHODRF=1 THEN DMDPRC.DTLSALESOUTTAXRF " + Environment.NewLine;
                        sqlText += "        ELSE (DMDPRC.SALESOUTTAXRF1 +DMDPRC.SALESOUTTAXRF2 +DMDPRC.SALESOUTTAXRF3) END)END)+DMDPRC.SALAMNTCONSTAXINCLURF AS THISSALESTAXRF, --今回売上消費税" + Environment.NewLine;
                        // 修正 2009.01.20 <<<
                        sqlText += "DMDPRC.ITDEDSALESOUTTAXRF  AS ITDEDSALESOUTTAXRF,    --売上外税対象額" + Environment.NewLine;
                        sqlText += "DMDPRC.ITDEDSALESINTAXRF AS ITDEDSALESINTAXRF,       --売上内税対象額" + Environment.NewLine;
                        sqlText += "DMDPRC.SALSUBTTLSUBTOTAXFRERF AS ITDEDSALESTAXFREERF,--売上非課税対象額" + Environment.NewLine;
                        // 修正 2009.01.20 >>>
                        //sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 OR DMDPRC.CONSTAXLAYMETHODRF=1) THEN DMDPRC.SALESOUTTAXRF " + Environment.NewLine;
                        //sqlText += "ELSE (DMDPRC.SALESOUTTAXRF1 +DMDPRC.SALESOUTTAXRF2 +DMDPRC.SALESOUTTAXRF3) END)AS SALESOUTTAXRF, --売上外税額" + Environment.NewLine;
                        sqlText += "(CASE WHEN DMDPRC.CONSTAXLAYMETHODRF=0  THEN DMDPRC.SALESOUTTAXRF " + Environment.NewLine;
                        sqlText += " ELSE(CASE WHEN  DMDPRC.CONSTAXLAYMETHODRF=1 THEN DMDPRC.DTLSALESOUTTAXRF " + Environment.NewLine;
                        sqlText += "       ELSE(DMDPRC.SALESOUTTAXRF1 +DMDPRC.SALESOUTTAXRF2 +DMDPRC.SALESOUTTAXRF3) END) END)AS SALESOUTTAXRF, --売上外税額" + Environment.NewLine;
                        // 修正 2009.01.20 <<<
                        sqlText += "DMDPRC.SALAMNTCONSTAXINCLURF AS SALESINTAXRF,--売上内税額" + Environment.NewLine;
                        // ■返品
                        sqlText += "DMDPRC.RETSALESNETPRICERF AS THISSALESPRICRGDSRF,         -- 今回売上返品額" + Environment.NewLine;
                        // 修正 2009.01.20 >>>
                        //sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 OR DMDPRC.CONSTAXLAYMETHODRF=1) THEN DMDPRC.RETSALESOUTTAXRF " + Environment.NewLine;
                        //sqlText += "ELSE (DMDPRC.RETSALESOUTTAXRF1 +DMDPRC.RETSALESOUTTAXRF2 +DMDPRC.RETSALESOUTTAXRF3) END)+DMDPRC.RETSALAMNTCONSTAXINCLURF AS THISSALESPRCTAXRGDSRF, --今回売上返品消費税" + Environment.NewLine;
                        sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 ) THEN DMDPRC.RETSALESOUTTAXRF " + Environment.NewLine;
                        sqlText += "  ELSE (CASE WHEN DMDPRC.CONSTAXLAYMETHODRF=1 THEN DMDPRC.DTLRETSALESOUTTAXRF " + Environment.NewLine;
                        sqlText += "         ELSE (DMDPRC.RETSALESOUTTAXRF1 +DMDPRC.RETSALESOUTTAXRF2 +DMDPRC.RETSALESOUTTAXRF3) END ) END)+DMDPRC.RETSALAMNTCONSTAXINCLURF AS THISSALESPRCTAXRGDSRF, --今回売上返品消費税" + Environment.NewLine;                       
                        // 修正 2009.01.20 <<<
                        sqlText += "DMDPRC.RETITDEDSALESOUTTAXRF AS TTLITDEDRETOUTTAXRF,      --返品外税対象額合計" + Environment.NewLine;
                        sqlText += "DMDPRC.RETITDEDSALESINTAXRF AS TTLITDEDRETINTAXRF,        --返品内税対象額合計" + Environment.NewLine;
                        sqlText += "DMDPRC.RETSALSUBTTLSUBTOTAXFRERF AS TTLITDEDRETTAXFREERF, --返品非課税対象額合計" + Environment.NewLine;
                        // 修正 2009.01.20 >>>
                        //sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 OR DMDPRC.CONSTAXLAYMETHODRF=1) THEN DMDPRC.RETSALESOUTTAXRF " + Environment.NewLine;
                        //sqlText += "ELSE (DMDPRC.RETSALESOUTTAXRF1 +DMDPRC.RETSALESOUTTAXRF2 +DMDPRC.RETSALESOUTTAXRF3) END)AS TTLRETOUTERTAXRF, --返品外税額合計" + Environment.NewLine;
                        sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0  ) THEN DMDPRC.RETSALESOUTTAXRF " + Environment.NewLine;
                        sqlText += "  ELSE (CASE WHEN DMDPRC.CONSTAXLAYMETHODRF=1 THEN DMDPRC.DTLRETSALESOUTTAXRF " + Environment.NewLine;
                        sqlText += "         ELSE (DMDPRC.RETSALESOUTTAXRF1 +DMDPRC.RETSALESOUTTAXRF2 +DMDPRC.RETSALESOUTTAXRF3) END ) END)AS TTLRETOUTERTAXRF, --返品外税額合計" + Environment.NewLine;
                        // 修正 2009.01.20 <<<
                        sqlText += "DMDPRC.RETSALAMNTCONSTAXINCLURF AS TTLRETINNERTAXRF,      --返品内税額合計" + Environment.NewLine;
                        // ■値引
                        sqlText += "DMDPRC.SALESDISTTLTAXEXCRF AS THISSALESPRICDISRF,     --今回売上値引金額" + Environment.NewLine;
                        // 修正 2009.01.20 >>>
                        //sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 OR DMDPRC.CONSTAXLAYMETHODRF=1) THEN DMDPRC.SALESDISOUTTAXRF " + Environment.NewLine;
                        //sqlText += " ELSE (DMDPRC.SALESDISOUTTAXRF1 +DMDPRC.SALESDISOUTTAXRF2 +DMDPRC.SALESDISOUTTAXRF3) END)+DMDPRC.SALESDISTTLTAXINCLURF AS THISSALESPRCTAXDISRF, --今回売上値引消費税" + Environment.NewLine;
                        sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 ) THEN DMDPRC.SALESDISOUTTAXRF " + Environment.NewLine;
                        sqlText += " ELSE(CASE WHEN DMDPRC.CONSTAXLAYMETHODRF=1 THEN DMDPRC.DTLSALESDISOUTTAXRF " + Environment.NewLine;
                        sqlText += "      ELSE (DMDPRC.SALESDISOUTTAXRF1 +DMDPRC.SALESDISOUTTAXRF2 +DMDPRC.SALESDISOUTTAXRF3) END) END)+DMDPRC.SALESDISTTLTAXINCLURF AS THISSALESPRCTAXDISRF, --今回売上値引消費税" + Environment.NewLine;
                        // 修正 2009.01.20 <<<
                        sqlText += "DMDPRC.ITDEDSALESDISOUTTAXRF AS TTLITDEDDISOUTTAXRF,  --値引外税対象額合計" + Environment.NewLine;
                        sqlText += "DMDPRC.ITDEDSALESDISINTAXRF AS TTLITDEDDISINTAXRF,    --値引内税対象額合計" + Environment.NewLine;
                        sqlText += "DMDPRC.ITDEDSALESDISTAXFRERF AS TTLITDEDDISTAXFREERF, --値引非課税対象額合計" + Environment.NewLine;
                        // 修正 2009.01.20 >>>
                        //sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 OR DMDPRC.CONSTAXLAYMETHODRF=1) THEN DMDPRC.SALESDISOUTTAXRF " + Environment.NewLine;
                        //sqlText += " ELSE (DMDPRC.SALESDISOUTTAXRF1 +DMDPRC.SALESDISOUTTAXRF2 +DMDPRC.SALESDISOUTTAXRF3)  END)AS TTLDISOUTERTAXRF, --値引外税額合計" + Environment.NewLine;
                        sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 ) THEN DMDPRC.SALESDISOUTTAXRF " + Environment.NewLine;
                        sqlText += " ELSE (CASE WHEN DMDPRC.CONSTAXLAYMETHODRF=1 THEN DMDPRC.DTLSALESDISOUTTAXRF " + Environment.NewLine;
                        sqlText += "       ELSE  (DMDPRC.SALESDISOUTTAXRF1 +DMDPRC.SALESDISOUTTAXRF2 +DMDPRC.SALESDISOUTTAXRF3) END) END)AS TTLDISOUTERTAXRF, --値引外税額合計" + Environment.NewLine;
                        // 修正 2009.01.20 <<<
                        sqlText += "DMDPRC.SALESDISTTLTAXINCLURF AS TTLDISINNERTAXRF, --値引内税額合計" + Environment.NewLine;
                        sqlText += "DMDPRC.SALESSLIPCOUNT AS SALESSLIPCOUNTRF,        --売上伝票枚数" + Environment.NewLine;
                        sqlText += "DMDPRC.COLLECTCONDRF AS COLLECTCONDRF,            --回収条件" + Environment.NewLine;
                        sqlText += "DMDPRC.CONSTAXLAYMETHODRF AS CONSTAXLAYMETHODRF,  --消費税転嫁方式" + Environment.NewLine;
                        sqlText += "DMDPRC.SALESCNSTAXFRCPROCCDRF AS FRACTIONPROCCDRF,--端数処理区分" + Environment.NewLine;
                        sqlText += "DMDPRC.COLLECTMONEYCODERF AS COLLECTMONEYCODERF,  --集金月区分コード" + Environment.NewLine;
                        sqlText += "DMDPRC.COLLECTMONEYDAYRF AS COLLECTMONEYDAYRF,    --集金日" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,  --税率開始日" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATEENDDATERF AS TAXRATEENDDATERF,      --税率終了日" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATERF AS TAXRATERF,                    --税率" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF,--税率開始日2" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,    --税率終了日2" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATE2RF AS TAXRATE2RF,                  --税率2" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF,--税率開始日3" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,    --税率終了日3" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATE3RF AS TAXRATE3RF                   --税率3" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        */
                        #endregion
                        // DEL 菅原 庸平 2012/04/27 >>>
                        /*
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "DMDPRC.CLAIMCODERF," + Environment.NewLine;
                        sqlText += "DMDPRC.CLAIMNAMERF," + Environment.NewLine;
                        sqlText += "DMDPRC.CLAIMNAME2RF," + Environment.NewLine;
                        sqlText += "DMDPRC.CLAIMSNMRF," + Environment.NewLine;
                        sqlText += "DMDPRC.FRACTIONPROCCDRF,  --端数処理単位" + Environment.NewLine;
                        sqlText += "DMDPRC.FRACTIONPROCUNITRF,--端数処理区分" + Environment.NewLine;
                        sqlText += "DMDPRC.SALESNETPRICERF + DMDPRC.RETSALESNETPRICERF +DMDPRC.SALESDISTTLTAXEXCRF AS OFSTHISTIMESALESRF,      --相殺後今回売上金額" + Environment.NewLine;
                        sqlText += "DMDPRC.ITDEDSALESOUTTAXRF+DMDPRC.RETITDEDSALESOUTTAXRF+DMDPRC.ITDEDSALESDISOUTTAXRF AS ITDEDOFFSETOUTTAXRF,--相殺後外税対象額 " + Environment.NewLine;
                        sqlText += "DMDPRC.ITDEDSALESINTAXRF+ DMDPRC.RETITDEDSALESINTAXRF+ DMDPRC.ITDEDSALESDISINTAXRF AS ITDEDOFFSETINTAXRF," + Environment.NewLine;
                        sqlText += "DMDPRC.SALSUBTTLSUBTOTAXFRERF+DMDPRC.RETSALSUBTTLSUBTOTAXFRERF+DMDPRC.ITDEDSALESDISTAXFRERF AS ITDEDOFFSETTAXFREERF,--相殺後非課税対象額" + Environment.NewLine;
                        sqlText += "DMDPRC.SALAMNTCONSTAXINCLURF + DMDPRC.RETSALAMNTCONSTAXINCLURF + DMDPRC.SALESDISTTLTAXINCLURF AS OFFSETINTAXRF,     --相殺後内税消費税" + Environment.NewLine;
                        sqlText += "-- ■ ■ 売上 ■ ■" + Environment.NewLine;
                        sqlText += "DMDPRC.SALESNETPRICERF AS THISTIMESALESRF,--今回売上金額" + Environment.NewLine;
                        sqlText += "DMDPRC.ITDEDSALESOUTTAXRF  AS ITDEDSALESOUTTAXRF,    --売上外税対象額" + Environment.NewLine;
                        sqlText += "DMDPRC.ITDEDSALESINTAXRF AS ITDEDSALESINTAXRF,       --売上内税対象額" + Environment.NewLine;
                        sqlText += "DMDPRC.SALSUBTTLSUBTOTAXFRERF AS ITDEDSALESTAXFREERF,--売上非課税対象額" + Environment.NewLine;
                        sqlText += "DMDPRC.SALESOUTTAXRF AS SALESOUTTAX_D,    -- 伝票転嫁消費税" + Environment.NewLine;
                        sqlText += "DMDPRC.DTLSALESOUTTAXRF AS SALESOUTTAX_M, -- 明細転嫁消費税" + Environment.NewLine;
                        sqlText += "DMDPRC.SALESOUTTAXRF1 +DMDPRC.SALESOUTTAXRF2 +DMDPRC.SALESOUTTAXRF3 AS SALESOUTTAX_S, --請求転嫁(親)" + Environment.NewLine;
                        sqlText += "DMDPRC.SALAMNTCONSTAXINCLURF AS SALESINTAXRF,--売上内税額" + Environment.NewLine;
                        sqlText += "-- ■ ■ 返品 ■ ■" + Environment.NewLine;
                        sqlText += "DMDPRC.RETSALESNETPRICERF AS THISSALESPRICRGDSRF,    -- 今回売上返品額" + Environment.NewLine;
                        sqlText += "DMDPRC.RETITDEDSALESOUTTAXRF AS TTLITDEDRETOUTTAXRF, --返品外税対象額合計" + Environment.NewLine;
                        sqlText += "DMDPRC.RETITDEDSALESINTAXRF AS TTLITDEDRETINTAXRF,   --返品内税対象額合計" + Environment.NewLine;
                        sqlText += "DMDPRC.RETSALSUBTTLSUBTOTAXFRERF AS TTLITDEDRETTAXFREERF, --返品非課税対象額合計" + Environment.NewLine;
                        sqlText += "DMDPRC.RETSALESOUTTAXRF AS RETSALESOUTTAX_D,    -- 伝票転嫁消費税" + Environment.NewLine;
                        sqlText += "DMDPRC.DTLRETSALESOUTTAXRF AS RETSALESOUTTAX_M, -- 明細転嫁消費税" + Environment.NewLine;
                        sqlText += "DMDPRC.RETSALESOUTTAXRF1 +DMDPRC.RETSALESOUTTAXRF2 +DMDPRC.RETSALESOUTTAXRF3 AS RETSALESOUTTAX_S, -- 請求転嫁(親)消費税" + Environment.NewLine;
                        sqlText += "DMDPRC.RETSALAMNTCONSTAXINCLURF AS TTLRETINNERTAXRF,--返品内税額合計" + Environment.NewLine;
                        sqlText += "-- ■ ■ 値引 ■ ■" + Environment.NewLine;
                        sqlText += "DMDPRC.SALESDISTTLTAXEXCRF AS THISSALESPRICDISRF,    --今回売上値引金額" + Environment.NewLine;
                        sqlText += "DMDPRC.ITDEDSALESDISOUTTAXRF AS TTLITDEDDISOUTTAXRF, --値引外税対象額合計" + Environment.NewLine;
                        sqlText += "DMDPRC.ITDEDSALESDISINTAXRF AS TTLITDEDDISINTAXRF,   --値引内税対象額合計" + Environment.NewLine;
                        sqlText += "DMDPRC.ITDEDSALESDISTAXFRERF AS TTLITDEDDISTAXFREERF,--値引非課税対象額合計" + Environment.NewLine;
                        sqlText += "DMDPRC.SALESDISOUTTAXRF AS DISSALEOUTTAX_D,          --伝票転嫁消費税" + Environment.NewLine;
                        sqlText += "DMDPRC.DTLSALESDISOUTTAXRF AS DISSALEOUTTAX_M,       --明細転嫁消費税" + Environment.NewLine;
                        sqlText += "DMDPRC.SALESDISOUTTAXRF1 +DMDPRC.SALESDISOUTTAXRF2 +DMDPRC.SALESDISOUTTAXRF3 AS DISSALEOUTTAX_S,--請求転嫁(親)消費税" + Environment.NewLine;
                        sqlText += "DMDPRC.SALESDISTTLTAXINCLURF AS TTLDISINNERTAXRF,  --値引内税額合計" + Environment.NewLine;
                        sqlText += "DMDPRC.SALESSLIPCOUNT AS SALESSLIPCOUNTRF,         --売上伝票枚数" + Environment.NewLine;
                        sqlText += "DMDPRC.COLLECTCONDRF AS COLLECTCONDRF,             --回収条件" + Environment.NewLine;
                        sqlText += "DMDPRC.SALESCNSTAXFRCPROCCDRF AS FRACTIONPROCCDRF, --端数処理区分" + Environment.NewLine;
                        sqlText += "DMDPRC.COLLECTMONEYCODERF AS COLLECTMONEYCODERF,   --集金月区分コード" + Environment.NewLine;
                        sqlText += "DMDPRC.COLLECTMONEYDAYRF AS COLLECTMONEYDAYRF,     --集金日" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,   --税率開始日" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATEENDDATERF AS TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATERF AS TAXRATERF,                     --税率" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF, --税率開始日2" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,     --税率終了日2" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATE2RF AS TAXRATE2RF,                   --税率2" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF, --税率開始日3" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,     --税率終了日3" + Environment.NewLine;
                        sqlText += "DMDPRC.TAXRATE3RF AS TAXRATE3RF                    --税率3" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        */
                        // DEL 菅原 庸平 2012/04/27 <<<
                        // ADD 菅原 庸平  2012/04/27 >>>
                        sqlText.Append("SELECT" + Environment.NewLine);
                        sqlText.Append("DMDPRC.CLAIMCODERF," + Environment.NewLine);
                        sqlText.Append("DMDPRC.CLAIMNAMERF," + Environment.NewLine);
                        sqlText.Append("DMDPRC.CLAIMNAME2RF," + Environment.NewLine);
                        sqlText.Append("DMDPRC.CLAIMSNMRF," + Environment.NewLine);
                        sqlText.Append("DMDPRC.FRACTIONPROCCDRF,  --端数処理単位" + Environment.NewLine);
                        sqlText.Append("DMDPRC.FRACTIONPROCUNITRF,--端数処理区分" + Environment.NewLine);
                        sqlText.Append("DMDPRC.SALESNETPRICERF + DMDPRC.RETSALESNETPRICERF +DMDPRC.SALESDISTTLTAXEXCRF AS OFSTHISTIMESALESRF,      --相殺後今回売上金額" + Environment.NewLine);
                        sqlText.Append("DMDPRC.ITDEDSALESOUTTAXRF+DMDPRC.RETITDEDSALESOUTTAXRF+DMDPRC.ITDEDSALESDISOUTTAXRF AS ITDEDOFFSETOUTTAXRF,--相殺後外税対象額 " + Environment.NewLine);
                        sqlText.Append("DMDPRC.ITDEDSALESINTAXRF+ DMDPRC.RETITDEDSALESINTAXRF+ DMDPRC.ITDEDSALESDISINTAXRF AS ITDEDOFFSETINTAXRF," + Environment.NewLine);
                        sqlText.Append("DMDPRC.SALSUBTTLSUBTOTAXFRERF+DMDPRC.RETSALSUBTTLSUBTOTAXFRERF+DMDPRC.ITDEDSALESDISTAXFRERF AS ITDEDOFFSETTAXFREERF,--相殺後非課税対象額" + Environment.NewLine);
                        sqlText.Append("DMDPRC.SALAMNTCONSTAXINCLURF + DMDPRC.RETSALAMNTCONSTAXINCLURF + DMDPRC.SALESDISTTLTAXINCLURF AS OFFSETINTAXRF,     --相殺後内税消費税" + Environment.NewLine);
                        sqlText.Append("-- ■ ■ 売上 ■ ■" + Environment.NewLine);
                        sqlText.Append("DMDPRC.SALESNETPRICERF AS THISTIMESALESRF,--今回売上金額" + Environment.NewLine);
                        sqlText.Append("DMDPRC.ITDEDSALESOUTTAXRF  AS ITDEDSALESOUTTAXRF,    --売上外税対象額" + Environment.NewLine);
                        sqlText.Append("DMDPRC.ITDEDSALESINTAXRF AS ITDEDSALESINTAXRF,       --売上内税対象額" + Environment.NewLine);
                        sqlText.Append("DMDPRC.SALSUBTTLSUBTOTAXFRERF AS ITDEDSALESTAXFREERF,--売上非課税対象額" + Environment.NewLine);
                        sqlText.Append("DMDPRC.SALESOUTTAXRF AS SALESOUTTAX_D,    -- 伝票転嫁消費税" + Environment.NewLine);
                        sqlText.Append("DMDPRC.DTLSALESOUTTAXRF AS SALESOUTTAX_M, -- 明細転嫁消費税" + Environment.NewLine);
                        //sqlText.Append("DMDPRC.SALESOUTTAXRF1 +DMDPRC.SALESOUTTAXRF2 +DMDPRC.SALESOUTTAXRF3 AS SALESOUTTAX_S, --請求転嫁(親)" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                        sqlText.Append("DMDPRC.SALESOUTTAXRF1*TAXRATERF +DMDPRC.SALESOUTTAXRF2*TAXRATE2RF +DMDPRC.SALESOUTTAXRF3*TAXRATE3RF AS SALESOUTTAX_S, --請求転嫁(親)" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                        sqlText.Append("DMDPRC.SALAMNTCONSTAXINCLURF AS SALESINTAXRF,--売上内税額" + Environment.NewLine);
                        sqlText.Append("-- ■ ■ 返品 ■ ■" + Environment.NewLine);
                        sqlText.Append("DMDPRC.RETSALESNETPRICERF AS THISSALESPRICRGDSRF,    -- 今回売上返品額" + Environment.NewLine);
                        sqlText.Append("DMDPRC.RETITDEDSALESOUTTAXRF AS TTLITDEDRETOUTTAXRF, --返品外税対象額合計" + Environment.NewLine);
                        sqlText.Append("DMDPRC.RETITDEDSALESINTAXRF AS TTLITDEDRETINTAXRF,   --返品内税対象額合計" + Environment.NewLine);
                        sqlText.Append("DMDPRC.RETSALSUBTTLSUBTOTAXFRERF AS TTLITDEDRETTAXFREERF, --返品非課税対象額合計" + Environment.NewLine);
                        sqlText.Append("DMDPRC.RETSALESOUTTAXRF AS RETSALESOUTTAX_D,    -- 伝票転嫁消費税" + Environment.NewLine);
                        sqlText.Append("DMDPRC.DTLRETSALESOUTTAXRF AS RETSALESOUTTAX_M, -- 明細転嫁消費税" + Environment.NewLine);
                        //sqlText.Append("DMDPRC.RETSALESOUTTAXRF1 +DMDPRC.RETSALESOUTTAXRF2 +DMDPRC.RETSALESOUTTAXRF3 AS RETSALESOUTTAX_S, -- 請求転嫁(親)消費税" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                        sqlText.Append("DMDPRC.RETSALESOUTTAXRF1*TAXRATERF +DMDPRC.RETSALESOUTTAXRF2*TAXRATE2RF +DMDPRC.RETSALESOUTTAXRF3*TAXRATE3RF AS RETSALESOUTTAX_S, -- 請求転嫁(親)消費税" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                        sqlText.Append("DMDPRC.RETSALAMNTCONSTAXINCLURF AS TTLRETINNERTAXRF,--返品内税額合計" + Environment.NewLine);
                        sqlText.Append("-- ■ ■ 値引 ■ ■" + Environment.NewLine);
                        sqlText.Append("DMDPRC.SALESDISTTLTAXEXCRF AS THISSALESPRICDISRF,    --今回売上値引金額" + Environment.NewLine);
                        sqlText.Append("DMDPRC.ITDEDSALESDISOUTTAXRF AS TTLITDEDDISOUTTAXRF, --値引外税対象額合計" + Environment.NewLine);
                        sqlText.Append("DMDPRC.ITDEDSALESDISINTAXRF AS TTLITDEDDISINTAXRF,   --値引内税対象額合計" + Environment.NewLine);
                        sqlText.Append("DMDPRC.ITDEDSALESDISTAXFRERF AS TTLITDEDDISTAXFREERF,--値引非課税対象額合計" + Environment.NewLine);
                        sqlText.Append("DMDPRC.SALESDISOUTTAXRF AS DISSALEOUTTAX_D,          --伝票転嫁消費税" + Environment.NewLine);
                        sqlText.Append("DMDPRC.DTLSALESDISOUTTAXRF AS DISSALEOUTTAX_M,       --明細転嫁消費税" + Environment.NewLine);
                        //sqlText.Append("DMDPRC.SALESDISOUTTAXRF1 +DMDPRC.SALESDISOUTTAXRF2 +DMDPRC.SALESDISOUTTAXRF3 AS DISSALEOUTTAX_S,--請求転嫁(親)消費税" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                        sqlText.Append("DMDPRC.SALESDISOUTTAXRF1*TAXRATERF +DMDPRC.SALESDISOUTTAXRF2*TAXRATE2RF +DMDPRC.SALESDISOUTTAXRF3*TAXRATE3RF AS DISSALEOUTTAX_S,--請求転嫁(親)消費税" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                        sqlText.Append("DMDPRC.SALESDISTTLTAXINCLURF AS TTLDISINNERTAXRF,  --値引内税額合計" + Environment.NewLine);
                        sqlText.Append("DMDPRC.SALESSLIPCOUNT AS SALESSLIPCOUNTRF,         --売上伝票枚数" + Environment.NewLine);
                        sqlText.Append("DMDPRC.COLLECTCONDRF AS COLLECTCONDRF,             --回収条件" + Environment.NewLine);
                        sqlText.Append("DMDPRC.SALESCNSTAXFRCPROCCDRF AS FRACTIONPROCCDRF, --端数処理区分" + Environment.NewLine);
                        sqlText.Append("DMDPRC.COLLECTMONEYCODERF AS COLLECTMONEYCODERF,   --集金月区分コード" + Environment.NewLine);
                        sqlText.Append("DMDPRC.COLLECTMONEYDAYRF AS COLLECTMONEYDAYRF,     --集金日" + Environment.NewLine);
                        sqlText.Append("DMDPRC.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,   --税率開始日" + Environment.NewLine);
                        sqlText.Append("DMDPRC.TAXRATEENDDATERF AS TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine);
                        sqlText.Append("DMDPRC.TAXRATERF AS TAXRATERF,                     --税率" + Environment.NewLine);
                        sqlText.Append("DMDPRC.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF, --税率開始日2" + Environment.NewLine);
                        sqlText.Append("DMDPRC.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,     --税率終了日2" + Environment.NewLine);
                        sqlText.Append("DMDPRC.TAXRATE2RF AS TAXRATE2RF,                   --税率2" + Environment.NewLine);
                        sqlText.Append("DMDPRC.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF, --税率開始日3" + Environment.NewLine);
                        sqlText.Append("DMDPRC.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,     --税率終了日3" + Environment.NewLine);
                        sqlText.Append("DMDPRC.TAXRATE3RF AS TAXRATE3RF                    --税率3" + Environment.NewLine);
                        sqlText.Append("FROM" + Environment.NewLine);
                        sqlText.Append("(" + Environment.NewLine);
                        // ADD 菅原 庸平 2012/04/27 <<<

                        #endregion

                        #region SUBクエリ

                        #region DEL 2009/04/14
                        /*
                        sqlText += "  SELECT" + Environment.NewLine;
                        sqlText += "   SALE.CLAIMCODERF AS CLAIMCODERF," + Environment.NewLine;
                        sqlText += "   CLAIM.NAMERF AS CLAIMNAMERF," + Environment.NewLine;
                        sqlText += "   CLAIM.NAME2RF AS CLAIMNAME2RF," + Environment.NewLine;
                        sqlText += "   CLAIM.CUSTOMERSNMRF AS CLAIMSNMRF," + Environment.NewLine;
                        //sqlText += "   SALE.CUSTOMERCODERF AS CUSTOMERCODERF," + Environment.NewLine;
                        sqlText += "   (CASE WHEN CLAIM.CUSTCTAXLAYREFCDRF = 0 THEN SALE.TAXCONSTAXLAYMETHODRF ELSE CLAIM.CONSTAXLAYMETHODRF END ) AS CONSTAXLAYMETHODRF," + Environment.NewLine;        //消費税転嫁方式
                        sqlText += "   CLAIM.COLLECTCONDRF AS COLLECTCONDRF," + Environment.NewLine;                  //回収条件
                        sqlText += "   CLAIM.COLLECTMONEYCODERF AS COLLECTMONEYCODERF," + Environment.NewLine;        //集金月区分コード
                        sqlText += "   CLAIM.COLLECTMONEYDAYRF AS COLLECTMONEYDAYRF," + Environment.NewLine;          //集金日
                        sqlText += "   CLAIM.SALESCNSTAXFRCPROCCDRF AS SALESCNSTAXFRCPROCCDRF," + Environment.NewLine;//売上消費税端数処理コード
                        sqlText += "   SALESPROC.FRACTIONPROCCDRF," + Environment.NewLine;                          //端数処理単位
                        sqlText += "   SALESPROC.FRACTIONPROCUNITRF," + Environment.NewLine;                        //端数処理区分
                        sqlText += "   SALE.TAXRATESTARTDATERF AS TAXRATESTARTDATERF," + Environment.NewLine;       //税率開始日
                        sqlText += "   SALE.TAXRATEENDDATERF AS TAXRATEENDDATERF," + Environment.NewLine;           //税率終了日
                        sqlText += "   SALE.TAXRATERF AS TAXRATERF," + Environment.NewLine;                         //税率
                        sqlText += "   SALE.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF," + Environment.NewLine;     //税率開始日2
                        sqlText += "   SALE.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF," + Environment.NewLine;         //税率終了日2
                        sqlText += "   SALE.TAXRATE2RF AS TAXRATE2RF," + Environment.NewLine;                       //税率2
                        sqlText += "   SALE.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF," + Environment.NewLine;     //税率開始日3
                        sqlText += "   SALE.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF," + Environment.NewLine;         //税率終了日3
                        sqlText += "   SALE.TAXRATE3RF AS TAXRATE3RF," + Environment.NewLine;                       //税率3
                        sqlText += "   COUNT(SALE.SALESSLIPNUMRF) SALESSLIPCOUNT," + Environment.NewLine;           //伝票枚数
                        // ■売上
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS SALESNETPRICERF," + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.ITDEDSALESOUTTAXRF ELSE 0 END)) AS ITDEDSALESOUTTAXRF," + Environment.NewLine;          //売上外税対象額 
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.ITDEDSALESINTAXRF ELSE 0 END)) AS ITDEDSALESINTAXRF," + Environment.NewLine;            //売上内税対象額
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALSUBTTLSUBTOTAXFRERF ELSE 0 END)) AS SALSUBTTLSUBTOTAXFRERF," + Environment.NewLine;  //売上小計非課税対象額 
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALESOUTTAXRF ELSE 0 END)) AS SALESOUTTAXRF," + Environment.NewLine;                    //消費税額（外税）伝票転嫁用消費税
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.DTLSALESOUTTAXRF ELSE 0 END)) AS DTLSALESOUTTAXRF," + Environment.NewLine;              //消費税額（外税）明細転嫁用消費税　ADD 2009.01.20 
                        // 請求転嫁用消費税 >>>
                        sqlText += "   SUM((CASE WHEN (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine;
                        sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS SALESOUTTAXRF1," + Environment.NewLine;                           // 売上金額消費税額（外税）税率1
                        sqlText += "   SUM((CASE WHEN (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine;
                        sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESOUTTAXRF2," + Environment.NewLine;                                // 売上金額消費税額（外税）税率2
                        sqlText += "   SUM((CASE WHEN (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine;
                        sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESOUTTAXRF3," + Environment.NewLine;                                // 消費税額（外税）税率3
                        // 請求転嫁用消費税 <<<
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALAMNTCONSTAXINCLURF ELSE 0 END)) AS SALAMNTCONSTAXINCLURF,     --消費税額（内税）" + Environment.NewLine;
                        // ■返品
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS RETSALESNETPRICERF,              --返品 売上正価金額" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.ITDEDSALESOUTTAXRF ELSE 0 END)) AS RETITDEDSALESOUTTAXRF,        --返品 売上外税対象額 " + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.ITDEDSALESINTAXRF ELSE 0 END)) AS RETITDEDSALESINTAXRF,          --返品 売上内税対象額 " + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALSUBTTLSUBTOTAXFRERF ELSE 0 END)) AS RETSALSUBTTLSUBTOTAXFRERF,--返品 売上小計非課税対象額 " + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALESOUTTAXRF ELSE 0 END)) AS RETSALESOUTTAXRF,                  --返品 消費税（外税）伝票" + Environment.NewLine; // 伝票転嫁用消費税
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.DTLSALESOUTTAXRF ELSE 0 END)) AS DTLRETSALESOUTTAXRF,            --返品 消費税（外税）明細" + Environment.NewLine; // 明細転嫁用消費税 ADD 2009.01.20
                        // 請求転嫁用消費税 >>>
                        sqlText += "   SUM((CASE WHEN (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine;
                        sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS RETSALESOUTTAXRF1,                                --返品 消費税額（外税）税率1" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine;
                        sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS RETSALESOUTTAXRF2,                                    --返品 消費税額（外税）税率2" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine;
                        sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS RETSALESOUTTAXRF3,                                    --返品 消費税額（外税）税率3" + Environment.NewLine;
                        // 請求転嫁用消費税 <<<
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALAMNTCONSTAXINCLURF ELSE 0 END)) AS RETSALAMNTCONSTAXINCLURF,  --返品 消費税額（内税）" + Environment.NewLine;
                        // ■値引
                        sqlText += "   SUM(SALE.SALESDISTTLTAXEXCRF) AS SALESDISTTLTAXEXCRF,        --値引金額計（税抜き）" + Environment.NewLine;
                        sqlText += "   SUM(SALE.ITDEDSALESDISOUTTAXRF) AS ITDEDSALESDISOUTTAXRF,    --値引外税対象額合計" + Environment.NewLine;
                        sqlText += "   SUM(SALE.ITDEDSALESDISINTAXRF) AS ITDEDSALESDISINTAXRF,      --値引内税対象額合計 " + Environment.NewLine;
                        sqlText += "   SUM(SALE.ITDEDSALESDISTAXFRERF) AS ITDEDSALESDISTAXFRERF,    --値引非課税対象額合計" + Environment.NewLine;
                        sqlText += "   SUM(SALE.SALESDISOUTTAXRF) AS SALESDISOUTTAXRF,              --値引消費税額（外税）伝票" + Environment.NewLine;  // 伝票転嫁用消費税
                        sqlText += "   SUM(SALE.SALESDISOUTTAXRF) AS DTLSALESDISOUTTAXRF,        --値引消費税額（外税）明細" + Environment.NewLine;  // 明細転嫁用消費税 ADD  2009.01.20 

                        // 請求転嫁用消費税 >>>
                        sqlText += "   SUM((CASE WHEN (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine;
                        sqlText += "        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATERF) ELSE 0 END)) AS SALESDISOUTTAXRF1,              --売上値引消費税額（外税）税率1" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine;
                        sqlText += "        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESDISOUTTAXRF2,              --売上値引消費税額（外税）税率2" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine;
                        sqlText += "        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESDISOUTTAXRF3,              --売上値引消費税額（外税）税率3" + Environment.NewLine;
                        // 請求転嫁用消費税 <<<
                        sqlText += "   SUM(SALE.SALESDISTTLTAXINCLURF) AS SALESDISTTLTAXINCLURF --売上値引消費税額（内税）" + Environment.NewLine;
                        sqlText += "  FROM" + Environment.NewLine;
                        sqlText += "  (" + Environment.NewLine;
                        sqlText += "     SELECT" + Environment.NewLine;
                        sqlText += "      SUBSALE.ENTERPRISECODERF," + Environment.NewLine;
                        //sqlText += "      SUBSALE.CLAIMCODERF," + Environment.NewLine;
                        sqlText += "      (CASE WHEN (SEARCHCUST.CLAIMCODERF IS NOT NULL) THEN SEARCHCUST.CLAIMCODERF ELSE SUBSALE.CLAIMCODERF END) AS CLAIMCODERF," + Environment.NewLine;
                        sqlText += "      SUBSALE.CUSTOMERCODERF," + Environment.NewLine;
                        sqlText += "      SUBSALE.ADDUPADATERF," + Environment.NewLine;
                        sqlText += "      SUBSALE.LOGICALDELETECODERF," + Environment.NewLine;
                        sqlText += "      SUBSALE.ACPTANODRSTATUSRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.DEBITNOTEDIVRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.SALESSLIPNUMRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.SALESSLIPCDRF," + Environment.NewLine;

                        // 修正 2009.03.23 >>>
                        //sqlText += "      SUBSALE.SALESNETPRICERF," + Environment.NewLine;
                        //sqlText += "      SUBSALE.ITDEDSALESOUTTAXRF," + Environment.NewLine;
                        //sqlText += "      SUBSALE.ITDEDSALESINTAXRF," + Environment.NewLine;
                        //sqlText += "      SUBSALE.SALSUBTTLSUBTOTAXFRERF," + Environment.NewLine;
                        //sqlText += "      SUBSALE.SALESOUTTAXRF," + Environment.NewLine;
                        //sqlText += "      SUBSALE.SALAMNTCONSTAXINCLURF," + Environment.NewLine;
                        //sqlText += "      SUBSALE.SALESDISTTLTAXEXCRF," + Environment.NewLine;
                        //sqlText += "      SUBSALE.ITDEDSALESDISOUTTAXRF," + Environment.NewLine;
                        //sqlText += "      SUBSALE.ITDEDSALESDISINTAXRF," + Environment.NewLine;
                        //sqlText += "      SUBSALE.ITDEDSALESDISTAXFRERF," + Environment.NewLine;
                        //sqlText += "      SUBSALE.SALESDISOUTTAXRF," + Environment.NewLine;
                        //sqlText += "      SUBSALE.SALESDISTTLTAXINCLURF," + Environment.NewLine;
                        // 売上・返品(行値引含む)
                        sqlText += "      SUBSALE.SALESNETPRICERF + DISSALESTAXEXCGYO AS SALESNETPRICERF ," + Environment.NewLine;
                        sqlText += "      SUBSALE.ITDEDSALESOUTTAXRF + ITDEDDISSALESOUTTAXGYO AS ITDEDSALESOUTTAXRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.ITDEDSALESINTAXRF + ITDEDDISSALESINTAXGYO AS ITDEDSALESINTAXRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.SALSUBTTLSUBTOTAXFRERF + ITDEDDISSALESTAXFREGYO AS SALSUBTTLSUBTOTAXFRERF," + Environment.NewLine;
                        sqlText += "      SUBSALE.SALESOUTTAXRF + DISSALESOUTTAXGYO AS SALESOUTTAXRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.SALAMNTCONSTAXINCLURF + DISSALESTAXFREGYO AS SALAMNTCONSTAXINCLURF," + Environment.NewLine;
                        // 値引(行値引除く)
                        //sqlText += "      SALESDTL.DISSALESTAXEXCGOODS AS SALESDISTTLTAXEXCRF,-- 税抜値引金額(商品値引)" + Environment.NewLine;
                        //sqlText += "      SALESDTL.ITDEDDISSALESOUTTAXGOODS AS ITDEDSALESDISOUTTAXRF,-- 外税対象額(商品値引)" + Environment.NewLine;
                        //sqlText += "      SALESDTL.ITDEDDISSALESINTAXGOODS AS ITDEDSALESDISINTAXRF, -- 内税対象額(商品値引)" + Environment.NewLine;
                        //sqlText += "      SALESDTL.ITDEDDISSALESTAXFREGOODS AS ITDEDSALESDISTAXFRERF,-- 非課税対象額(商品値引)" + Environment.NewLine;
                        //sqlText += "      SALESDTL.DISSALESOUTTAXGOODS AS SALESDISOUTTAXRF,    -- 外税額(商品値引)" + Environment.NewLine;
                        //sqlText += "      SALESDTL.DISSALESTAXFREGOODS AS SALESDISTTLTAXINCLURF,    -- 内税額(商品値引)" + Environment.NewLine;
                        sqlText += "      SUBSALE.SALESDISTTLTAXEXCRF -  SALESDTL.DISSALESTAXEXCGYO AS SALESDISTTLTAXEXCRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.ITDEDSALESDISOUTTAXRF - SALESDTL.ITDEDDISSALESOUTTAXGYO AS ITDEDSALESDISOUTTAXRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.ITDEDSALESDISINTAXRF - SALESDTL.ITDEDDISSALESINTAXGYO AS ITDEDSALESDISINTAXRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.ITDEDSALESDISTAXFRERF - SALESDTL.ITDEDDISSALESTAXFREGYO AS ITDEDSALESDISTAXFRERF," + Environment.NewLine;
                        sqlText += "      SUBSALE.SALESDISOUTTAXRF - SALESDTL.DISSALESOUTTAXGYO AS SALESDISOUTTAXRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.SALESDISTTLTAXINCLURF - SALESDTL.DISSALESTAXFREGYO AS SALESDISTTLTAXINCLURF," + Environment.NewLine;
                        // 修正 2009.03.23 <<<

                        sqlText += "      SALESDTL.DTLSALESOUTTAXRF + SALESDTL.DISSALESOUTTAXGYO AS DTLSALESOUTTAXRF, " + Environment.NewLine;
                        sqlText += "      SALESDTL.DTLSALAMNTCONSTAXINCLURF + SALESDTL.DISSALESTAXFREGYO AS DTLSALAMNTCONSTAXINCLURF," + Environment.NewLine;
                        // DEL >>>
                        //sqlText += "      SALEDISDTL.DTLSALESDISOUTTAXRF," + Environment.NewLine;
                        //sqlText += "      SALEDISDTL.DTLSALESDISTTLTAXINCLURF," + Environment.NewLine;
                        // DEL <<<
                        sqlText += "      TAX.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,   --税率開始日" + Environment.NewLine;
                        sqlText += "      TAX.TAXRATEENDDATERF AS TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine;
                        sqlText += "      TAX.TAXRATERF AS TAXRATERF,                     --税率" + Environment.NewLine;
                        sqlText += "      TAX.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF, --税率開始日2" + Environment.NewLine;
                        sqlText += "      TAX.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,     --税率終了日2" + Environment.NewLine;
                        sqlText += "      TAX.TAXRATE2RF AS TAXRATE2RF,                   --税率2" + Environment.NewLine;
                        sqlText += "      TAX.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF, --税率開始日3" + Environment.NewLine;
                        sqlText += "      TAX.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,     --税率終了日3" + Environment.NewLine;
                        sqlText += "      TAX.TAXRATE3RF AS TAXRATE3RF,                   --税率3" + Environment.NewLine;
                        sqlText += "      TAX.CONSTAXLAYMETHODRF AS TAXCONSTAXLAYMETHODRF" + Environment.NewLine;
                        sqlText += "     FROM" + Environment.NewLine;
                        sqlText += "      SALESSLIPRF AS SUBSALE WITH(READUNCOMMITTED)" + Environment.NewLine;
                        */
                        #endregion
                        // DEL 菅原 庸平 2012/04/27 >>>
                        /*
                        sqlText += "  SELECT" + Environment.NewLine;
                        sqlText += "   SALE.CLAIMCODERF AS CLAIMCODERF," + Environment.NewLine;
                        sqlText += "   CLAIM.NAMERF AS CLAIMNAMERF," + Environment.NewLine;
                        sqlText += "   CLAIM.NAME2RF AS CLAIMNAME2RF," + Environment.NewLine;
                        sqlText += "   CLAIM.CUSTOMERSNMRF AS CLAIMSNMRF," + Environment.NewLine;
                        sqlText += "   CLAIM.COLLECTCONDRF AS COLLECTCONDRF," + Environment.NewLine;
                        sqlText += "   CLAIM.COLLECTMONEYCODERF AS COLLECTMONEYCODERF," + Environment.NewLine;
                        sqlText += "   CLAIM.COLLECTMONEYDAYRF AS COLLECTMONEYDAYRF," + Environment.NewLine;
                        sqlText += "   CLAIM.SALESCNSTAXFRCPROCCDRF AS SALESCNSTAXFRCPROCCDRF," + Environment.NewLine;
                        sqlText += "   SALESPROC.FRACTIONPROCCDRF," + Environment.NewLine;
                        sqlText += "   SALESPROC.FRACTIONPROCUNITRF," + Environment.NewLine;
                        sqlText += "   SALE.TAXRATESTARTDATERF AS TAXRATESTARTDATERF," + Environment.NewLine;
                        sqlText += "   SALE.TAXRATEENDDATERF AS TAXRATEENDDATERF," + Environment.NewLine;
                        sqlText += "   SALE.TAXRATERF AS TAXRATERF," + Environment.NewLine;
                        sqlText += "   SALE.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF," + Environment.NewLine;
                        sqlText += "   SALE.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF," + Environment.NewLine;
                        sqlText += "   SALE.TAXRATE2RF AS TAXRATE2RF," + Environment.NewLine;
                        sqlText += "   SALE.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF," + Environment.NewLine;
                        sqlText += "   SALE.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF," + Environment.NewLine;
                        sqlText += "   SALE.TAXRATE3RF AS TAXRATE3RF," + Environment.NewLine;
                        sqlText += "   COUNT(SALE.SALESSLIPNUMRF) SALESSLIPCOUNT," + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS SALESNETPRICERF," + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.ITDEDSALESOUTTAXRF ELSE 0 END)) AS ITDEDSALESOUTTAXRF," + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.ITDEDSALESINTAXRF ELSE 0 END)) AS ITDEDSALESINTAXRF," + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALSUBTTLSUBTOTAXFRERF ELSE 0 END)) AS SALSUBTTLSUBTOTAXFRERF," + Environment.NewLine;
                        sqlText += "   -- 伝票転嫁" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =0) AND (SALE.SALESSLIPCDRF =0) THEN SALE.SALESOUTTAXRF ELSE 0 END)) AS SALESOUTTAXRF," + Environment.NewLine;
                        sqlText += "   -- 明細転嫁" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =1) AND (SALE.SALESSLIPCDRF =0) THEN SALE.DTLSALESOUTTAXRF ELSE 0 END)) AS DTLSALESOUTTAXRF," + Environment.NewLine;
                        sqlText += "   --請求親転嫁(親)" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)" + Environment.NewLine;
                        sqlText += "          THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS SALESOUTTAXRF1,--税率1" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF)" + Environment.NewLine;
                        sqlText += "          THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESOUTTAXRF2,    --税率2" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF)" + Environment.NewLine;
                        sqlText += "             THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESOUTTAXRF3, --税率3" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALAMNTCONSTAXINCLURF ELSE 0 END)) AS SALAMNTCONSTAXINCLURF,     --消費税額（内税）" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS RETSALESNETPRICERF,              --返品 売上正価金額" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.ITDEDSALESOUTTAXRF ELSE 0 END)) AS RETITDEDSALESOUTTAXRF,        --返品 売上外税対象額" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.ITDEDSALESINTAXRF ELSE 0 END)) AS RETITDEDSALESINTAXRF,          --返品 売上内税対象額" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALSUBTTLSUBTOTAXFRERF ELSE 0 END)) AS RETSALSUBTTLSUBTOTAXFRERF,--返品 売上小計非課税対象額" + Environment.NewLine;
                        sqlText += "   --伝票転嫁" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =0) AND (SALE.SALESSLIPCDRF =1) THEN SALE.SALESOUTTAXRF ELSE 0 END)) AS RETSALESOUTTAXRF,--返品 消費税（外税）伝票" + Environment.NewLine;
                        sqlText += "   --明細転嫁" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =1) AND (SALE.SALESSLIPCDRF =1) THEN SALE.DTLSALESOUTTAXRF ELSE 0 END)) AS DTLRETSALESOUTTAXRF, --返品 消費税（外税）明細" + Environment.NewLine;
                        sqlText += "   --請求転嫁(親)" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine;
                        sqlText += "           THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS RETSALESOUTTAXRF1,--返品 消費税額（外税）税率1" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND(SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine;
                        sqlText += "           THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS RETSALESOUTTAXRF2,  --返品 消費税額（外税）税率2" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine;
                        sqlText += "           THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS RETSALESOUTTAXRF3,  --返品 消費税額（外税）税率3" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALAMNTCONSTAXINCLURF ELSE 0 END)) AS RETSALAMNTCONSTAXINCLURF,  --返品 消費税額（内税）" + Environment.NewLine;
                        sqlText += "   SUM(SALE.SALESDISTTLTAXEXCRF) AS SALESDISTTLTAXEXCRF,    --値引金額計（税抜き）" + Environment.NewLine;
                        sqlText += "   SUM(SALE.ITDEDSALESDISOUTTAXRF) AS ITDEDSALESDISOUTTAXRF,--値引外税対象額合計" + Environment.NewLine;
                        sqlText += "   SUM(SALE.ITDEDSALESDISINTAXRF) AS ITDEDSALESDISINTAXRF,  --値引内税対象額合計" + Environment.NewLine;
                        sqlText += "   SUM(SALE.ITDEDSALESDISTAXFRERF) AS ITDEDSALESDISTAXFRERF,--値引非課税対象額合計" + Environment.NewLine;
                        sqlText += "   --伝票転嫁" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.CONSTAXLAYMETHODRF =0 THEN SALE.SALESDISOUTTAXRF ELSE 0 END )) AS SALESDISOUTTAXRF,   --値引消費税額（外税）伝票" + Environment.NewLine;
                        sqlText += "   --明細転嫁" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN SALE.CONSTAXLAYMETHODRF =1 THEN SALE.SALESDISOUTTAXRF ELSE 0 END )) AS DTLSALESDISOUTTAXRF,--値引消費税額（外税）明細" + Environment.NewLine;
                        sqlText += "   --請求転嫁(親)" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)" + Environment.NewLine;
                        sqlText += "           THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATERF) ELSE 0 END)) AS SALESDISOUTTAXRF1, --売上値引消費税額（外税）税率1" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine;
                        sqlText += "           THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESDISOUTTAXRF2,--売上値引消費税額（外税）税率2" + Environment.NewLine;
                        sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF)" + Environment.NewLine;
                        sqlText += "          THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESDISOUTTAXRF3, --売上値引消費税額（外税）税率3" + Environment.NewLine;
                        sqlText += "   SUM(SALE.SALESDISTTLTAXINCLURF) AS SALESDISTTLTAXINCLURF --売上値引消費税額（内税）" + Environment.NewLine;
                        sqlText += "  FROM" + Environment.NewLine;
                        sqlText += "  (" + Environment.NewLine;
                        sqlText += "     SELECT" + Environment.NewLine;
                        sqlText += "      SUBSALE.ENTERPRISECODERF," + Environment.NewLine;
                        sqlText += "      (CASE WHEN (SEARCHCUST.CLAIMCODERF IS NOT NULL) THEN SEARCHCUST.CLAIMCODERF ELSE SUBSALE.CLAIMCODERF END) AS CLAIMCODERF," + Environment.NewLine;
                        sqlText += "      SUBSALE.CUSTOMERCODERF," + Environment.NewLine;
                        sqlText += "      SUBSALE.ADDUPADATERF," + Environment.NewLine;
                        sqlText += "      SUBSALE.LOGICALDELETECODERF," + Environment.NewLine;
                        sqlText += "      SUBSALE.ACPTANODRSTATUSRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.DEBITNOTEDIVRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.SALESSLIPNUMRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.SALESSLIPCDRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.CONSTAXLAYMETHODRF, -- ADD 2009/04/13" + Environment.NewLine;
                        sqlText += "      SUBSALE.SALESNETPRICERF + DISSALESTAXEXCGYO AS SALESNETPRICERF ," + Environment.NewLine;
                        sqlText += "      SUBSALE.ITDEDSALESOUTTAXRF + ITDEDDISSALESOUTTAXGYO AS ITDEDSALESOUTTAXRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.ITDEDSALESINTAXRF + ITDEDDISSALESINTAXGYO AS ITDEDSALESINTAXRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.SALSUBTTLSUBTOTAXFRERF + ITDEDDISSALESTAXFREGYO AS SALSUBTTLSUBTOTAXFRERF," + Environment.NewLine;
                        sqlText += "      SUBSALE.SALESOUTTAXRF + DISSALESOUTTAXGYO AS SALESOUTTAXRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.SALAMNTCONSTAXINCLURF + DISSALESTAXFREGYO AS SALAMNTCONSTAXINCLURF," + Environment.NewLine;
                        sqlText += "      SUBSALE.SALESDISTTLTAXEXCRF -  SALESDTL.DISSALESTAXEXCGYO AS SALESDISTTLTAXEXCRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.ITDEDSALESDISOUTTAXRF - SALESDTL.ITDEDDISSALESOUTTAXGYO AS ITDEDSALESDISOUTTAXRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.ITDEDSALESDISINTAXRF - SALESDTL.ITDEDDISSALESINTAXGYO AS ITDEDSALESDISINTAXRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.ITDEDSALESDISTAXFRERF - SALESDTL.ITDEDDISSALESTAXFREGYO AS ITDEDSALESDISTAXFRERF," + Environment.NewLine;
                        sqlText += "      SUBSALE.SALESDISOUTTAXRF - SALESDTL.DISSALESOUTTAXGYO AS SALESDISOUTTAXRF," + Environment.NewLine;
                        sqlText += "      SUBSALE.SALESDISTTLTAXINCLURF - SALESDTL.DISSALESTAXFREGYO AS SALESDISTTLTAXINCLURF," + Environment.NewLine;
                        sqlText += "      SALESDTL.DTLSALESOUTTAXRF + SALESDTL.DISSALESOUTTAXGYO AS DTLSALESOUTTAXRF, " + Environment.NewLine;
                        sqlText += "      SALESDTL.DTLSALAMNTCONSTAXINCLURF + SALESDTL.DISSALESTAXFREGYO AS DTLSALAMNTCONSTAXINCLURF," + Environment.NewLine;
                        sqlText += "      TAX.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,   --税率開始日" + Environment.NewLine;
                        sqlText += "      TAX.TAXRATEENDDATERF AS TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine;
                        sqlText += "      TAX.TAXRATERF AS TAXRATERF,                     --税率" + Environment.NewLine;
                        sqlText += "      TAX.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF, --税率開始日2" + Environment.NewLine;
                        sqlText += "      TAX.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,     --税率終了日2" + Environment.NewLine;
                        sqlText += "      TAX.TAXRATE2RF AS TAXRATE2RF,                   --税率2" + Environment.NewLine;
                        sqlText += "      TAX.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF, --税率開始日3" + Environment.NewLine;
                        sqlText += "      TAX.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,     --税率終了日3" + Environment.NewLine;
                        sqlText += "      TAX.TAXRATE3RF AS TAXRATE3RF,                   --税率3" + Environment.NewLine;
                        sqlText += "      TAX.CONSTAXLAYMETHODRF AS TAXCONSTAXLAYMETHODRF" + Environment.NewLine;
                        sqlText += "     FROM" + Environment.NewLine;
                        sqlText += "      SALESSLIPRF AS SUBSALE WITH(READUNCOMMITTED)" + Environment.NewLine;
                        */
                        // DEL 菅原 庸平 2012/04/27 <<<
                        // ADD 菅原 庸平  2012/04/27 >>>
                        sqlText.Append("  SELECT" + Environment.NewLine);
                        sqlText.Append("   SALE.CLAIMCODERF AS CLAIMCODERF," + Environment.NewLine);
                        sqlText.Append("   CLAIM.NAMERF AS CLAIMNAMERF," + Environment.NewLine);
                        sqlText.Append("   CLAIM.NAME2RF AS CLAIMNAME2RF," + Environment.NewLine);
                        sqlText.Append("   CLAIM.CUSTOMERSNMRF AS CLAIMSNMRF," + Environment.NewLine);
                        sqlText.Append("   CLAIM.COLLECTCONDRF AS COLLECTCONDRF," + Environment.NewLine);
                        sqlText.Append("   CLAIM.COLLECTMONEYCODERF AS COLLECTMONEYCODERF," + Environment.NewLine);
                        sqlText.Append("   CLAIM.COLLECTMONEYDAYRF AS COLLECTMONEYDAYRF," + Environment.NewLine);
                        sqlText.Append("   CLAIM.SALESCNSTAXFRCPROCCDRF AS SALESCNSTAXFRCPROCCDRF," + Environment.NewLine);
                        sqlText.Append("   SALESPROC.FRACTIONPROCCDRF," + Environment.NewLine);
                        sqlText.Append("   SALESPROC.FRACTIONPROCUNITRF," + Environment.NewLine);
                        sqlText.Append("   SALE.TAXRATESTARTDATERF AS TAXRATESTARTDATERF," + Environment.NewLine);
                        sqlText.Append("   SALE.TAXRATEENDDATERF AS TAXRATEENDDATERF," + Environment.NewLine);
                        sqlText.Append("   SALE.TAXRATERF AS TAXRATERF," + Environment.NewLine);
                        sqlText.Append("   SALE.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF," + Environment.NewLine);
                        sqlText.Append("   SALE.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF," + Environment.NewLine);
                        sqlText.Append("   SALE.TAXRATE2RF AS TAXRATE2RF," + Environment.NewLine);
                        sqlText.Append("   SALE.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF," + Environment.NewLine);
                        sqlText.Append("   SALE.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF," + Environment.NewLine);
                        sqlText.Append("   SALE.TAXRATE3RF AS TAXRATE3RF," + Environment.NewLine);
                        sqlText.Append("   COUNT(SALE.SALESSLIPNUMRF) SALESSLIPCOUNT," + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS SALESNETPRICERF," + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.ITDEDSALESOUTTAXRF ELSE 0 END)) AS ITDEDSALESOUTTAXRF," + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.ITDEDSALESINTAXRF ELSE 0 END)) AS ITDEDSALESINTAXRF," + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALSUBTTLSUBTOTAXFRERF ELSE 0 END)) AS SALSUBTTLSUBTOTAXFRERF," + Environment.NewLine);
                        sqlText.Append("   -- 伝票転嫁" + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =0) AND (SALE.SALESSLIPCDRF =0) THEN SALE.SALESOUTTAXRF ELSE 0 END)) AS SALESOUTTAXRF," + Environment.NewLine);
                        sqlText.Append("   -- 明細転嫁" + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =1) AND (SALE.SALESSLIPCDRF =0) THEN SALE.DTLSALESOUTTAXRF ELSE 0 END)) AS DTLSALESOUTTAXRF," + Environment.NewLine);
                        sqlText.Append("   --請求親転嫁(親)" + Environment.NewLine);
                        // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                        //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)" + Environment.NewLine);
                        //sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS SALESOUTTAXRF1,--税率1" + Environment.NewLine);
                        //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF)" + Environment.NewLine);
                        //sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESOUTTAXRF2,    --税率2" + Environment.NewLine);
                        //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF)" + Environment.NewLine);
                        //sqlText.Append("             THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESOUTTAXRF3, --税率3" + Environment.NewLine);
                        // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                        // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                        sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)" + Environment.NewLine);
                        sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF1,--税率1" + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF)" + Environment.NewLine);
                        sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF2,    --税率2" + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF)" + Environment.NewLine);
                        sqlText.Append("             THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF3, --税率3" + Environment.NewLine);
                        // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                        sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALAMNTCONSTAXINCLURF ELSE 0 END)) AS SALAMNTCONSTAXINCLURF,     --消費税額（内税）" + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS RETSALESNETPRICERF,              --返品 売上正価金額" + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.ITDEDSALESOUTTAXRF ELSE 0 END)) AS RETITDEDSALESOUTTAXRF,        --返品 売上外税対象額" + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.ITDEDSALESINTAXRF ELSE 0 END)) AS RETITDEDSALESINTAXRF,          --返品 売上内税対象額" + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALSUBTTLSUBTOTAXFRERF ELSE 0 END)) AS RETSALSUBTTLSUBTOTAXFRERF,--返品 売上小計非課税対象額" + Environment.NewLine);
                        sqlText.Append("   --伝票転嫁" + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =0) AND (SALE.SALESSLIPCDRF =1) THEN SALE.SALESOUTTAXRF ELSE 0 END)) AS RETSALESOUTTAXRF,--返品 消費税（外税）伝票" + Environment.NewLine);
                        sqlText.Append("   --明細転嫁" + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =1) AND (SALE.SALESSLIPCDRF =1) THEN SALE.DTLSALESOUTTAXRF ELSE 0 END)) AS DTLRETSALESOUTTAXRF, --返品 消費税（外税）明細" + Environment.NewLine);
                        sqlText.Append("   --請求転嫁(親)" + Environment.NewLine);
                        // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                        //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                        //sqlText.Append("           THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS RETSALESOUTTAXRF1,--返品 消費税額（外税）税率1" + Environment.NewLine);
                        //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND(SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                        //sqlText.Append("           THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS RETSALESOUTTAXRF2,  --返品 消費税額（外税）税率2" + Environment.NewLine);
                        //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                        //sqlText.Append("           THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS RETSALESOUTTAXRF3,  --返品 消費税額（外税）税率3" + Environment.NewLine);
                        // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                        // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                        sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                        sqlText.Append("           THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF1,--返品 消費税額（外税）税率1" + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND(SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                        sqlText.Append("           THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF2,  --返品 消費税額（外税）税率2" + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                        sqlText.Append("           THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF3,  --返品 消費税額（外税）税率3" + Environment.NewLine);
                        // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                        sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALAMNTCONSTAXINCLURF ELSE 0 END)) AS RETSALAMNTCONSTAXINCLURF,  --返品 消費税額（内税）" + Environment.NewLine);
                        sqlText.Append("   SUM(SALE.SALESDISTTLTAXEXCRF) AS SALESDISTTLTAXEXCRF,    --値引金額計（税抜き）" + Environment.NewLine);
                        sqlText.Append("   SUM(SALE.ITDEDSALESDISOUTTAXRF) AS ITDEDSALESDISOUTTAXRF,--値引外税対象額合計" + Environment.NewLine);
                        sqlText.Append("   SUM(SALE.ITDEDSALESDISINTAXRF) AS ITDEDSALESDISINTAXRF,  --値引内税対象額合計" + Environment.NewLine);
                        sqlText.Append("   SUM(SALE.ITDEDSALESDISTAXFRERF) AS ITDEDSALESDISTAXFRERF,--値引非課税対象額合計" + Environment.NewLine);
                        sqlText.Append("   --伝票転嫁" + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN SALE.CONSTAXLAYMETHODRF =0 THEN SALE.SALESDISOUTTAXRF ELSE 0 END )) AS SALESDISOUTTAXRF,   --値引消費税額（外税）伝票" + Environment.NewLine);
                        sqlText.Append("   --明細転嫁" + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN SALE.CONSTAXLAYMETHODRF =1 THEN SALE.SALESDISOUTTAXRF ELSE 0 END )) AS DTLSALESDISOUTTAXRF,--値引消費税額（外税）明細" + Environment.NewLine);
                        sqlText.Append("   --請求転嫁(親)" + Environment.NewLine);
                        // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                        //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)" + Environment.NewLine);
                        //sqlText.Append("           THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATERF) ELSE 0 END)) AS SALESDISOUTTAXRF1, --売上値引消費税額（外税）税率1" + Environment.NewLine);
                        //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                        //sqlText.Append("           THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESDISOUTTAXRF2,--売上値引消費税額（外税）税率2" + Environment.NewLine);
                        //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF)" + Environment.NewLine);
                        //sqlText.Append("          THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESDISOUTTAXRF3, --売上値引消費税額（外税）税率3" + Environment.NewLine);
                        // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                        // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                        sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)" + Environment.NewLine);
                        sqlText.Append("           THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF1, --売上値引消費税額（外税）税率1" + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                        sqlText.Append("           THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF2,--売上値引消費税額（外税）税率2" + Environment.NewLine);
                        sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF)" + Environment.NewLine);
                        sqlText.Append("          THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF3, --売上値引消費税額（外税）税率3" + Environment.NewLine);
                        // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                        sqlText.Append("   SUM(SALE.SALESDISTTLTAXINCLURF) AS SALESDISTTLTAXINCLURF --売上値引消費税額（内税）" + Environment.NewLine);
                        sqlText.Append("  FROM" + Environment.NewLine);
                        sqlText.Append("  (" + Environment.NewLine);
                        sqlText.Append("     SELECT" + Environment.NewLine);
                        sqlText.Append("      SUBSALE.ENTERPRISECODERF," + Environment.NewLine);
                        sqlText.Append("      (CASE WHEN (SEARCHCUST.CLAIMCODERF IS NOT NULL) THEN SEARCHCUST.CLAIMCODERF ELSE SUBSALE.CLAIMCODERF END) AS CLAIMCODERF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.CUSTOMERCODERF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.ADDUPADATERF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.LOGICALDELETECODERF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.ACPTANODRSTATUSRF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.DEBITNOTEDIVRF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.SALESSLIPNUMRF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.SALESSLIPCDRF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.CONSTAXLAYMETHODRF, -- ADD 2009/04/13" + Environment.NewLine);
                        sqlText.Append("      SUBSALE.SALESNETPRICERF + DISSALESTAXEXCGYO AS SALESNETPRICERF ," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.ITDEDSALESOUTTAXRF + ITDEDDISSALESOUTTAXGYO AS ITDEDSALESOUTTAXRF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.ITDEDSALESINTAXRF + ITDEDDISSALESINTAXGYO AS ITDEDSALESINTAXRF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.SALSUBTTLSUBTOTAXFRERF + ITDEDDISSALESTAXFREGYO AS SALSUBTTLSUBTOTAXFRERF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.SALESOUTTAXRF + DISSALESOUTTAXGYO AS SALESOUTTAXRF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.SALAMNTCONSTAXINCLURF + DISSALESTAXFREGYO AS SALAMNTCONSTAXINCLURF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.SALESDISTTLTAXEXCRF -  SALESDTL.DISSALESTAXEXCGYO AS SALESDISTTLTAXEXCRF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.ITDEDSALESDISOUTTAXRF - SALESDTL.ITDEDDISSALESOUTTAXGYO AS ITDEDSALESDISOUTTAXRF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.ITDEDSALESDISINTAXRF - SALESDTL.ITDEDDISSALESINTAXGYO AS ITDEDSALESDISINTAXRF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.ITDEDSALESDISTAXFRERF - SALESDTL.ITDEDDISSALESTAXFREGYO AS ITDEDSALESDISTAXFRERF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.SALESDISOUTTAXRF - SALESDTL.DISSALESOUTTAXGYO AS SALESDISOUTTAXRF," + Environment.NewLine);
                        sqlText.Append("      SUBSALE.SALESDISTTLTAXINCLURF - SALESDTL.DISSALESTAXFREGYO AS SALESDISTTLTAXINCLURF," + Environment.NewLine);
                        sqlText.Append("      SALESDTL.DTLSALESOUTTAXRF + SALESDTL.DISSALESOUTTAXGYO AS DTLSALESOUTTAXRF, " + Environment.NewLine);
                        sqlText.Append("      SALESDTL.DTLSALAMNTCONSTAXINCLURF + SALESDTL.DISSALESTAXFREGYO AS DTLSALAMNTCONSTAXINCLURF," + Environment.NewLine);
                        sqlText.Append("      TAX.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,   --税率開始日" + Environment.NewLine);
                        sqlText.Append("      TAX.TAXRATEENDDATERF AS TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine);
                        sqlText.Append("      TAX.TAXRATERF AS TAXRATERF,                     --税率" + Environment.NewLine);
                        sqlText.Append("      TAX.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF, --税率開始日2" + Environment.NewLine);
                        sqlText.Append("      TAX.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,     --税率終了日2" + Environment.NewLine);
                        sqlText.Append("      TAX.TAXRATE2RF AS TAXRATE2RF,                   --税率2" + Environment.NewLine);
                        sqlText.Append("      TAX.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF, --税率開始日3" + Environment.NewLine);
                        sqlText.Append("      TAX.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,     --税率終了日3" + Environment.NewLine);
                        sqlText.Append("      TAX.TAXRATE3RF AS TAXRATE3RF,                   --税率3" + Environment.NewLine);
                        sqlText.Append("      TAX.CONSTAXLAYMETHODRF AS TAXCONSTAXLAYMETHODRF" + Environment.NewLine);
                        sqlText.Append("     FROM" + Environment.NewLine);
                        sqlText.Append("      SALESSLIPRF AS SUBSALE WITH(READUNCOMMITTED)" + Environment.NewLine);
                        // ADD 菅原 庸平  2012/04/27 <<<

                        #region SUBクエリ JOIN
                        #region DEL 2009/04/14
                        /*
                        sqlText += "    LEFT JOIN TAXRATESETRF AS TAX" + Environment.NewLine;
                        sqlText += "     ON SUBSALE.ENTERPRISECODERF = TAX.ENTERPRISECODERF " + Environment.NewLine;
                        sqlText += "    LEFT JOIN CUSTOMERRF AS SEARCHCUST " + Environment.NewLine;
                        sqlText += "     ON  SUBSALE.ENTERPRISECODERF = SEARCHCUST.ENTERPRISECODERF " + Environment.NewLine;
                        sqlText += "     AND SUBSALE.CUSTOMERCODERF = SEARCHCUST.CUSTOMERCODERF " + Environment.NewLine;

                        // ADD 2009.03.23 >>>
                        sqlText += "    LEFT JOIN" + Environment.NewLine;
                        sqlText += "    (" + Environment.NewLine;
                        sqlText += "      SELECT" + Environment.NewLine;
                        sqlText += "       SALES.ENTERPRISECODERF," + Environment.NewLine;
                        sqlText += "       SALES.ACPTANODRSTATUSRF," + Environment.NewLine;
                        sqlText += "       SALES.SALESSLIPNUMRF," + Environment.NewLine;
                        sqlText += "       SALES.SALESSLIPCDRF," + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN ((SALES.SALESSLIPCDRF = 0 OR SALES.SALESSLIPCDRF =1 ) AND DTL.SALESSLIPCDDTLRF != 2 AND DTL.TAXATIONDIVCDRF = 2) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALAMNTCONSTAXINCLURF,-- 明細内税消費税金額" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN ((SALES.SALESSLIPCDRF = 0 OR SALES.SALESSLIPCDRF =1 ) AND DTL.SALESSLIPCDDTLRF != 2 AND DTL.TAXATIONDIVCDRF = 0) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALESOUTTAXRF, -- 明細外税消費税金額" + Environment.NewLine;
                        sqlText += "       --行値引" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISSALESTAXEXCGYO,-- 税抜値引金額(行値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESOUTTAXGYO,-- 外税対象額(行値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 1) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESTAXFREGYO, -- 非課税対象額(行値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESINTAXGYO,-- 内税対象額(行値引)       " + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESOUTTAXGYO,    -- 外税額(行値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESTAXFREGYO,    -- 内税額(行値引)       " + Environment.NewLine;
                        sqlText += "       --商品値引" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF !=0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISSALESTAXEXCGOODS,-- 税抜値引金額(商品値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF !=0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESOUTTAXGOODS,-- 外税対象額(商品値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF !=0  AND DTL.TAXATIONDIVCDRF  = 1) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESTAXFREGOODS, -- 非課税対象額(商品値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF !=0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESINTAXGOODS,-- 内税対象額(商品値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF !=0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESOUTTAXGOODS,    -- 外税額(商品値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF !=0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESTAXFREGOODS     -- 内税額(商品値引)" + Environment.NewLine;
                        sqlText += "      FROM" + Environment.NewLine;
                        sqlText += "       SALESDETAILRF AS DTL" + Environment.NewLine;
                        sqlText += "      LEFT JOIN SALESSLIPRF AS SALES" + Environment.NewLine;
                        sqlText += "       ON  SALES.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "       AND SALES.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                        sqlText += "       AND SALES.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF" + Environment.NewLine;
                        sqlText += "      GROUP BY" + Environment.NewLine;
                        sqlText += "       SALES.ENTERPRISECODERF," + Environment.NewLine;
                        sqlText += "       SALES.ACPTANODRSTATUSRF," + Environment.NewLine;
                        sqlText += "       SALES.SALESSLIPNUMRF," + Environment.NewLine;
                        sqlText += "       SALES.SALESSLIPCDRF" + Environment.NewLine;
                        sqlText += "    ) AS SALESDTL" + Environment.NewLine;
                        sqlText += "     ON  SUBSALE.ENTERPRISECODERF = SALESDTL.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "     AND SUBSALE.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                        sqlText += "     AND SUBSALE.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF" + Environment.NewLine;
                        // ADD 2009.03.23 <<<
                        */
                        #endregion
                        #region DEL 2009.03.23
                        /*
                        sqlText += "    LEFT JOIN  -- 売上・返品の明細転嫁消費税" + Environment.NewLine;
                        sqlText += "      (" + Environment.NewLine;
                        sqlText += "       SELECT" + Environment.NewLine;
                        sqlText += "        DTL.ENTERPRISECODERF," + Environment.NewLine;
                        sqlText += "        DTL.SALESSLIPNUMRF, --伝票番号" + Environment.NewLine;
                        sqlText += "        DTL.SALESSLIPCDDTLRF, -- 伝票区分" + Environment.NewLine;
                        sqlText += "        DTL.ACPTANODRSTATUSRF, -- 受注ステータス        " + Environment.NewLine;
                        sqlText += "        SUM(CASE WHEN DTL.TAXATIONDIVCDRF = 2 THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALAMNTCONSTAXINCLURF,-- 明細内税消費税金額" + Environment.NewLine;
                        sqlText += "        SUM(CASE WHEN DTL.TAXATIONDIVCDRF = 0 THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALESOUTTAXRF -- 明細外税消費税金額" + Environment.NewLine;
                        sqlText += "       FROM" + Environment.NewLine;
                        sqlText += "        SALESDETAILRF AS DTL" + Environment.NewLine;
                        sqlText += "       WHERE" + Environment.NewLine;
                        sqlText += "        DTL.SALESSLIPCDDTLRF = 0 -- 売上" + Environment.NewLine;
                        sqlText += "        OR DTL.SALESSLIPCDDTLRF = 1 -- 返品        " + Environment.NewLine;
                        sqlText += "       GROUP BY" + Environment.NewLine;
                        sqlText += "        DTL.ENTERPRISECODERF," + Environment.NewLine;
                        sqlText += "        DTL.SALESSLIPNUMRF, --伝票番号" + Environment.NewLine;
                        sqlText += "        DTL.SALESSLIPCDDTLRF, -- 伝票区分" + Environment.NewLine;
                        sqlText += "        DTL.ACPTANODRSTATUSRF -- 受注ステータス        " + Environment.NewLine;
                        sqlText += "      ) AS SALEDTL" + Environment.NewLine;
                        sqlText += "     ON  SUBSALE.ENTERPRISECODERF = SALEDTL.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "     AND SUBSALE.ACPTANODRSTATUSRF = SALEDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                        sqlText += "     AND SUBSALE.SALESSLIPNUMRF = SALEDTL.SALESSLIPNUMRF" + Environment.NewLine;
                        sqlText += "    LEFT JOIN -- 値引の明細転嫁消費税" + Environment.NewLine;
                        sqlText += "      (" + Environment.NewLine;
                        sqlText += "       SELECT" + Environment.NewLine;
                        sqlText += "        DISDTL.ENTERPRISECODERF," + Environment.NewLine;
                        sqlText += "        DISDTL.SALESSLIPNUMRF, --伝票番号" + Environment.NewLine;
                        sqlText += "        DISDTL.ACPTANODRSTATUSRF, -- 受注ステータス        " + Environment.NewLine;
                        sqlText += "        SUM(CASE WHEN DISDTL.TAXATIONDIVCDRF = 2 THEN DISDTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALESDISTTLTAXINCLURF,-- 明細内税消費税金額" + Environment.NewLine;
                        sqlText += "        SUM(CASE WHEN DISDTL.TAXATIONDIVCDRF = 0 THEN DISDTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALESDISOUTTAXRF -- 明細外税消費税金額" + Environment.NewLine;
                        sqlText += "       FROM" + Environment.NewLine;
                        sqlText += "        SALESDETAILRF AS DISDTL" + Environment.NewLine;
                        sqlText += "       WHERE" + Environment.NewLine;
                        sqlText += "        DISDTL.SALESSLIPCDDTLRF = 2 -- 値引" + Environment.NewLine;
                        sqlText += "       GROUP BY" + Environment.NewLine;
                        sqlText += "        DISDTL.ENTERPRISECODERF," + Environment.NewLine;
                        sqlText += "        DISDTL.SALESSLIPNUMRF, --伝票番号" + Environment.NewLine;
                        sqlText += "        DISDTL.ACPTANODRSTATUSRF -- 受注ステータス        " + Environment.NewLine;
                        sqlText += "      ) AS SALEDISDTL" + Environment.NewLine;
                        sqlText += "     ON  SUBSALE.ENTERPRISECODERF = SALEDISDTL.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "     AND SUBSALE.ACPTANODRSTATUSRF = SALEDISDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                        sqlText += "     AND SUBSALE.SALESSLIPNUMRF = SALEDISDTL.SALESSLIPNUMRF" + Environment.NewLine;
                        */
                        #endregion 

                        // DEL 菅原 庸平 2012/04/27 >>>
                        /*
                        // --- UPD T.Nishi 2012/02/15 ---------->>>>>
                        //sqlText += "    LEFT JOIN TAXRATESETRF AS TAX" + Environment.NewLine;
                        sqlText += "    LEFT JOIN TAXRATESETRF AS TAX WITH(READUNCOMMITTED) " + Environment.NewLine;
                        // --- UPD T.Nishi 2012/02/15 ----------<<<<<
                        sqlText += "     ON SUBSALE.ENTERPRISECODERF = TAX.ENTERPRISECODERF " + Environment.NewLine;
                        // --- UPD T.Nishi 2012/02/15 ---------->>>>>
                        //sqlText += "    LEFT JOIN CUSTOMERRF AS SEARCHCUST " + Environment.NewLine;
                        sqlText += "    LEFT JOIN CUSTOMERRF AS SEARCHCUST WITH(READUNCOMMITTED) " + Environment.NewLine;
                        // --- UPD T.Nishi 2012/02/15 ----------<<<<<
                        sqlText += "     ON  SUBSALE.ENTERPRISECODERF = SEARCHCUST.ENTERPRISECODERF " + Environment.NewLine;
                        sqlText += "     AND SUBSALE.CUSTOMERCODERF = SEARCHCUST.CUSTOMERCODERF " + Environment.NewLine;
                        sqlText += "    LEFT JOIN" + Environment.NewLine;
                        sqlText += "    (" + Environment.NewLine;
                        sqlText += "      SELECT" + Environment.NewLine;
                        sqlText += "       SALES.ENTERPRISECODERF," + Environment.NewLine;
                        sqlText += "       SALES.ACPTANODRSTATUSRF," + Environment.NewLine;
                        sqlText += "       SALES.SALESSLIPNUMRF," + Environment.NewLine;
                        sqlText += "       SALES.SALESSLIPCDRF," + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN ((SALES.SALESSLIPCDRF = 0 OR SALES.SALESSLIPCDRF =1 ) AND DTL.SALESSLIPCDDTLRF != 2 AND DTL.TAXATIONDIVCDRF = 2) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALAMNTCONSTAXINCLURF,-- 明細内税消費税金額" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN ((SALES.SALESSLIPCDRF = 0 OR SALES.SALESSLIPCDRF =1 ) AND DTL.SALESSLIPCDDTLRF != 2 AND DTL.TAXATIONDIVCDRF = 0) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALESOUTTAXRF, -- 明細外税消費税金額" + Environment.NewLine;
                        sqlText += "       --行値引" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISSALESTAXEXCGYO,-- 税抜値引金額(行値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESOUTTAXGYO,-- 外税対象額(行値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 1) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESTAXFREGYO, -- 非課税対象額(行値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESINTAXGYO,-- 内税対象額(行値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESOUTTAXGYO,    -- 外税額(行値引)" + Environment.NewLine;
                        sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESTAXFREGYO    -- 内税額(行値引)" + Environment.NewLine;
                        sqlText += "      FROM" + Environment.NewLine;
                        // --- UPD T.Nishi 2012/02/15 ---------->>>>>
                        //sqlText += "       SALESDETAILRF AS DTL" + Environment.NewLine;
                        //sqlText += "      LEFT JOIN SALESSLIPRF AS SALES" + Environment.NewLine;
                        sqlText += "       SALESDETAILRF AS DTL WITH(READUNCOMMITTED) " + Environment.NewLine;
                        sqlText += "      LEFT JOIN SALESSLIPRF AS SALES WITH(READUNCOMMITTED) " + Environment.NewLine;
                        // --- UPD T.Nishi 2012/02/15 ----------<<<<<
                        sqlText += "       ON  SALES.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "       AND SALES.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                        sqlText += "       AND SALES.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF" + Environment.NewLine;
                        sqlText += "      GROUP BY" + Environment.NewLine;
                        sqlText += "       SALES.ENTERPRISECODERF," + Environment.NewLine;
                        sqlText += "       SALES.ACPTANODRSTATUSRF," + Environment.NewLine;
                        sqlText += "       SALES.SALESSLIPNUMRF," + Environment.NewLine;
                        sqlText += "       SALES.SALESSLIPCDRF" + Environment.NewLine;
                        sqlText += "    ) AS SALESDTL" + Environment.NewLine;
                        sqlText += "     ON  SUBSALE.ENTERPRISECODERF = SALESDTL.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "     AND SUBSALE.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                        sqlText += "     AND SUBSALE.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF" + Environment.NewLine;
                        sqlText += "  ) AS SALE" + Environment.NewLine;
                        */
                        // DEL 菅原 庸平 2012/04/27 <<<
                        // ADD 菅原 庸平  2012/04/27 >>>
                        sqlText.Append("    LEFT JOIN TAXRATESETRF AS TAX WITH(READUNCOMMITTED) " + Environment.NewLine);
                        sqlText.Append("     ON SUBSALE.ENTERPRISECODERF = TAX.ENTERPRISECODERF " + Environment.NewLine);
                        sqlText.Append("    LEFT JOIN CUSTOMERRF AS SEARCHCUST WITH(READUNCOMMITTED) " + Environment.NewLine);
                        sqlText.Append("     ON  SUBSALE.ENTERPRISECODERF = SEARCHCUST.ENTERPRISECODERF " + Environment.NewLine);
                        sqlText.Append("     AND SUBSALE.CUSTOMERCODERF = SEARCHCUST.CUSTOMERCODERF " + Environment.NewLine);
                        sqlText.Append("    LEFT JOIN" + Environment.NewLine);
                        sqlText.Append("    (" + Environment.NewLine);
                        sqlText.Append("      SELECT" + Environment.NewLine);
                        sqlText.Append("       SALES.ENTERPRISECODERF," + Environment.NewLine);
                        sqlText.Append("       SALES.ACPTANODRSTATUSRF," + Environment.NewLine);
                        sqlText.Append("       SALES.SALESSLIPNUMRF," + Environment.NewLine);
                        sqlText.Append("       SALES.SALESSLIPCDRF," + Environment.NewLine);
                        sqlText.Append("       SUM(CASE WHEN ((SALES.SALESSLIPCDRF = 0 OR SALES.SALESSLIPCDRF =1 ) AND DTL.SALESSLIPCDDTLRF != 2 AND DTL.TAXATIONDIVCDRF = 2) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALAMNTCONSTAXINCLURF,-- 明細内税消費税金額" + Environment.NewLine);
                        sqlText.Append("       SUM(CASE WHEN ((SALES.SALESSLIPCDRF = 0 OR SALES.SALESSLIPCDRF =1 ) AND DTL.SALESSLIPCDDTLRF != 2 AND DTL.TAXATIONDIVCDRF = 0) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALESOUTTAXRF, -- 明細外税消費税金額" + Environment.NewLine);
                        sqlText.Append("       --行値引" + Environment.NewLine);
                        sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISSALESTAXEXCGYO,-- 税抜値引金額(行値引)" + Environment.NewLine);
                        sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESOUTTAXGYO,-- 外税対象額(行値引)" + Environment.NewLine);
                        sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 1) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESTAXFREGYO, -- 非課税対象額(行値引)" + Environment.NewLine);
                        sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESINTAXGYO,-- 内税対象額(行値引)" + Environment.NewLine);
                        sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESOUTTAXGYO,    -- 外税額(行値引)" + Environment.NewLine);
                        sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESTAXFREGYO    -- 内税額(行値引)" + Environment.NewLine);
                        sqlText.Append("      FROM" + Environment.NewLine);
                        sqlText.Append("       SALESDETAILRF AS DTL WITH(READUNCOMMITTED) " + Environment.NewLine);
                        sqlText.Append("      LEFT JOIN SALESSLIPRF AS SALES WITH(READUNCOMMITTED) " + Environment.NewLine);
                        sqlText.Append("       ON  SALES.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine);
                        sqlText.Append("       AND SALES.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine);
                        sqlText.Append("       AND SALES.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF" + Environment.NewLine);
                        sqlText.Append("      GROUP BY" + Environment.NewLine);
                        sqlText.Append("       SALES.ENTERPRISECODERF," + Environment.NewLine);
                        sqlText.Append("       SALES.ACPTANODRSTATUSRF," + Environment.NewLine);
                        sqlText.Append("       SALES.SALESSLIPNUMRF," + Environment.NewLine);
                        sqlText.Append("       SALES.SALESSLIPCDRF" + Environment.NewLine);
                        sqlText.Append("    ) AS SALESDTL" + Environment.NewLine);
                        sqlText.Append("     ON  SUBSALE.ENTERPRISECODERF = SALESDTL.ENTERPRISECODERF" + Environment.NewLine);
                        sqlText.Append("     AND SUBSALE.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine);
                        sqlText.Append("     AND SUBSALE.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF" + Environment.NewLine);
                        sqlText.Append("  ) AS SALE" + Environment.NewLine);
                        // ADD 菅原 庸平  2012/04/27 <<<
                        #endregion

                        #endregion

                        #region JOIN
                        // DEL 菅原 庸平 2012/04/27 >>>
                        /*
                        sqlText += "LEFT JOIN CUSTOMERRF AS CUST WITH(READUNCOMMITTED)" + Environment.NewLine;
                        sqlText += " ON SALE.ENTERPRISECODERF = CUST.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " AND SALE.CUSTOMERCODERF = CUST.CUSTOMERCODERF" + Environment.NewLine;
                        sqlText += "LEFT JOIN CUSTOMERRF AS CLAIM WITH(READUNCOMMITTED)" + Environment.NewLine;
                        sqlText += " ON SALE.ENTERPRISECODERF = CLAIM.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " AND SALE.CLAIMCODERF = CLAIM.CUSTOMERCODERF" + Environment.NewLine;
                        // 売上金額処理区分設定マスタ
                        sqlText += "LEFT JOIN SALESPROCMONEYRF AS SALESPROC WITH(READUNCOMMITTED)" + Environment.NewLine;
                        sqlText += " ON  CLAIM.ENTERPRISECODERF=SALESPROC.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " AND SALESPROC.FRACPROCMONEYDIVRF=1" + Environment.NewLine;
                        sqlText += " AND CLAIM.SALESCNSTAXFRCPROCCDRF=SALESPROC.FRACTIONPROCCODERF" + Environment.NewLine;
                        */
                        // DEL 菅原 庸平 2012/04/27 <<<
                        // ADD 菅原 庸平  2012/04/27 >>>
                        sqlText.Append("LEFT JOIN CUSTOMERRF AS CUST WITH(READUNCOMMITTED)" + Environment.NewLine);
                        sqlText.Append(" ON SALE.ENTERPRISECODERF = CUST.ENTERPRISECODERF" + Environment.NewLine);
                        sqlText.Append(" AND SALE.CUSTOMERCODERF = CUST.CUSTOMERCODERF" + Environment.NewLine);
                        sqlText.Append("LEFT JOIN CUSTOMERRF AS CLAIM WITH(READUNCOMMITTED)" + Environment.NewLine);
                        sqlText.Append(" ON SALE.ENTERPRISECODERF = CLAIM.ENTERPRISECODERF" + Environment.NewLine);
                        sqlText.Append(" AND SALE.CLAIMCODERF = CLAIM.CUSTOMERCODERF" + Environment.NewLine);
                        // 売上金額処理区分設定マスタ
                        sqlText.Append("LEFT JOIN SALESPROCMONEYRF AS SALESPROC WITH(READUNCOMMITTED)" + Environment.NewLine);
                        sqlText.Append(" ON  CLAIM.ENTERPRISECODERF=SALESPROC.ENTERPRISECODERF" + Environment.NewLine);
                        sqlText.Append(" AND SALESPROC.FRACPROCMONEYDIVRF=1" + Environment.NewLine);
                        sqlText.Append(" AND CLAIM.SALESCNSTAXFRCPROCCDRF=SALESPROC.FRACTIONPROCCODERF" + Environment.NewLine);
                        // ADD 菅原 庸平  2012/04/27 <<<

                        #endregion

                        #region WHERE句
                        // DEL 菅原 庸平 2012/04/27 >>>
                        /*
                        sqlText += " WHERE SALE.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "   AND SALE.CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        //sqlText += "   AND SALE.DEMANDADDUPSECCDRF=@FINDADDUPSECCODE" + Environment.NewLine;
                        sqlText += "   AND(SALE.ADDUPADATERF<=@FINDADDUPDATE AND SALE.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                        sqlText += "   AND SALE.LOGICALDELETECODERF=0" + Environment.NewLine;
                        sqlText += "   AND SALE.ACPTANODRSTATUSRF=30" + Environment.NewLine;
                        sqlText += "   AND SALE.DEBITNOTEDIVRF=0" + Environment.NewLine;
                        */
                        // DEL 菅原 庸平 2012/04/27 <<<
                        // ADD 菅原 庸平  2012/04/27 >>>
                        sqlText.Append(" WHERE SALE.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                        sqlText.Append("   AND SALE.CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine);
                        sqlText.Append("   AND(SALE.ADDUPADATERF<=@FINDADDUPDATE AND SALE.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine);
                        sqlText.Append("   AND SALE.LOGICALDELETECODERF=0" + Environment.NewLine);
                        sqlText.Append("   AND SALE.ACPTANODRSTATUSRF=30" + Environment.NewLine);
                        sqlText.Append("   AND SALE.DEBITNOTEDIVRF=0" + Environment.NewLine);
                        // ADD 菅原 庸平  2012/04/27 <<<
                        #endregion

                        #region GROUP BY句
                        // DEL 菅原 庸平 2012/04/27 >>>
                        /*
                        sqlText += "GROUP BY " + Environment.NewLine;
                        sqlText += " SALE.CLAIMCODERF," + Environment.NewLine;
                        sqlText += " CLAIM.NAMERF," + Environment.NewLine;
                        sqlText += " CLAIM.NAME2RF," + Environment.NewLine;
                        sqlText += " CLAIM.CUSTOMERSNMRF," + Environment.NewLine;
                        //sqlText += " SALE.CUSTOMERCODERF," + Environment.NewLine;
                        sqlText += " CLAIM.CONSTAXLAYMETHODRF,    --消費税転嫁方式" + Environment.NewLine;
                        sqlText += " CLAIM.COLLECTCONDRF,         --回収条件" + Environment.NewLine;
                        sqlText += " CLAIM.COLLECTMONEYCODERF,    --集金月区分コード" + Environment.NewLine;
                        sqlText += " CLAIM.COLLECTMONEYDAYRF,     --集金日" + Environment.NewLine;
                        sqlText += " CLAIM.SALESCNSTAXFRCPROCCDRF,--売上消費税端数処理コード" + Environment.NewLine;
                        sqlText += " SALESPROC.FRACTIONPROCCDRF,  --端数処理単位" + Environment.NewLine;
                        sqlText += " SALESPROC.FRACTIONPROCUNITRF,--端数処理区分" + Environment.NewLine;
                        sqlText += " SALE.TAXRATESTARTDATERF,     --税率開始日" + Environment.NewLine;
                        sqlText += " SALE.TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine;
                        sqlText += " SALE.TAXRATERF,              --税率" + Environment.NewLine;
                        sqlText += " SALE.TAXRATESTARTDATE2RF,    --税率開始日2" + Environment.NewLine;
                        sqlText += " SALE.TAXRATEENDDATE2RF,      --税率終了日2" + Environment.NewLine;
                        sqlText += " SALE.TAXRATE2RF,             --税率2" + Environment.NewLine;
                        sqlText += " SALE.TAXRATESTARTDATE3RF,    --税率開始日3" + Environment.NewLine;
                        sqlText += " SALE.TAXRATEENDDATE3RF,      --税率終了日3" + Environment.NewLine;
                        sqlText += " SALE.TAXRATE3RF,             --税率3" + Environment.NewLine;
                        sqlText += " CLAIM.CUSTCTAXLAYREFCDRF," + Environment.NewLine;
                        sqlText += " SALE.TAXCONSTAXLAYMETHODRF" + Environment.NewLine;
                        sqlText += ") AS DMDPRC" + Environment.NewLine;
                        */
                        // DEL 菅原 庸平 2012/04/27 <<<
                        // ADD 菅原 庸平  2012/04/27 >>>
                        sqlText.Append("GROUP BY " + Environment.NewLine);
                        sqlText.Append(" SALE.CLAIMCODERF," + Environment.NewLine);
                        sqlText.Append(" CLAIM.NAMERF," + Environment.NewLine);
                        sqlText.Append(" CLAIM.NAME2RF," + Environment.NewLine);
                        sqlText.Append(" CLAIM.CUSTOMERSNMRF," + Environment.NewLine);
                        sqlText.Append(" CLAIM.CONSTAXLAYMETHODRF,    --消費税転嫁方式" + Environment.NewLine);
                        sqlText.Append(" CLAIM.COLLECTCONDRF,         --回収条件" + Environment.NewLine);
                        sqlText.Append(" CLAIM.COLLECTMONEYCODERF,    --集金月区分コード" + Environment.NewLine);
                        sqlText.Append(" CLAIM.COLLECTMONEYDAYRF,     --集金日" + Environment.NewLine);
                        sqlText.Append(" CLAIM.SALESCNSTAXFRCPROCCDRF,--売上消費税端数処理コード" + Environment.NewLine);
                        sqlText.Append(" SALESPROC.FRACTIONPROCCDRF,  --端数処理単位" + Environment.NewLine);
                        sqlText.Append(" SALESPROC.FRACTIONPROCUNITRF,--端数処理区分" + Environment.NewLine);
                        sqlText.Append(" SALE.TAXRATESTARTDATERF,     --税率開始日" + Environment.NewLine);
                        sqlText.Append(" SALE.TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine);
                        sqlText.Append(" SALE.TAXRATERF,              --税率" + Environment.NewLine);
                        sqlText.Append(" SALE.TAXRATESTARTDATE2RF,    --税率開始日2" + Environment.NewLine);
                        sqlText.Append(" SALE.TAXRATEENDDATE2RF,      --税率終了日2" + Environment.NewLine);
                        sqlText.Append(" SALE.TAXRATE2RF,             --税率2" + Environment.NewLine);
                        sqlText.Append(" SALE.TAXRATESTARTDATE3RF,    --税率開始日3" + Environment.NewLine);
                        sqlText.Append(" SALE.TAXRATEENDDATE3RF,      --税率終了日3" + Environment.NewLine);
                        sqlText.Append(" SALE.TAXRATE3RF,             --税率3" + Environment.NewLine);
                        sqlText.Append(" CLAIM.CUSTCTAXLAYREFCDRF," + Environment.NewLine);
                        sqlText.Append(" SALE.TAXCONSTAXLAYMETHODRF" + Environment.NewLine);
                        sqlText.Append(") AS DMDPRC" + Environment.NewLine);
                        // ADD 菅原 庸平  2012/04/27 <<<
                        #endregion

                        //sqlCommand.CommandText = sqlText; // DEL 菅原 庸平  2012/04/27
                        sqlCommand.CommandText = sqlText.ToString(); // ADD 菅原 庸平  2012/04/27

                        #region Prameterオブジェクトの作成
                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        //SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                        SqlParameter findParaLastCAddUpUpdDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定
                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                        //findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                        findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);
                        // --- UPD m.suzuki 2010/07/21 ---------->>>>>                        
                        //if (custDmdPrcWork.LastCAddUpUpdDate == DateTime.MinValue)
                        //    findParaLastCAddUpUpdDate.Value = 20000101;
                        //else
                        //    findParaLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.LastCAddUpUpdDate);

                        if ( custDmdPrcWork.LastCAddUpUpdDate != DateTime.MinValue )
                        {
                            findParaLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( custDmdPrcWork.LastCAddUpUpdDate );
                        }
                        else if ( custDmdPrcWork.ExtractStartDate != DateTime.MinValue )
                        {
                            findParaLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( custDmdPrcWork.ExtractStartDate.AddDays( -1 ) );
                        }
                        else
                        {
                            findParaLastCAddUpUpdDate.Value = 20000101;
                        }
                        // --- UPD m.suzuki 2010/07/21 ----------<<<<<
                        #endregion

                        myReader = sqlCommand.ExecuteReader();
                        double FractionProcUnit =0;
                        long SetTax = 0;

                        while (myReader.Read())
                        {
                            #region 集計レコードセット
                            custDmdPrcWork.FractionProcCd =SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); //端数処理区分
                            FractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF")); // 端数処理単位
                            custDmdPrcWork.AddUpSecCode = custDmdPrcWork.AddUpSecCode;
                            custDmdPrcWork.ClaimCode = custDmdPrcWork.ClaimCode;
                            custDmdPrcWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
                            custDmdPrcWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
                            custDmdPrcWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                            custDmdPrcWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));　　　　　　// 回収条件(得意先マスタ)
                            //custDmdPrcWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));　// 消費税転嫁方式(得意先マスタ) //DEL 2009/04/14
                            //custDmdPrcWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));         // 税率(セット済　※得意先マスタ)
                            custDmdPrcWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));      // 端数処理区分(得意先マスタ)
                            custDmdPrcWork.ResultsSectCd = "00"; // 実績拠点コード(00固定)
                            //custDmdPrcWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                            //custDmdPrcWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                            //custDmdPrcWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                            //custDmdPrcWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                            //custDmdPrcWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
                            //custDmdPrcWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                            //custDmdPrcWork.LastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEDEMANDRF"));         // 前回請求金額(セット済   ※前回履歴から)
                            //custDmdPrcWork.ThisTimeFeeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDNRMLRF")); // 今回手数料金額(セット済 ※入金マスタから)
                            //custDmdPrcWork.ThisTimeDisDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDNRMLRF")); // 今回値引金額(セット済   ※入金マスタから)
                            //custDmdPrcWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));       // 今回入金金額(セット済   ※入金マスタから)

                            // 今回繰越残高(請求計) = 前回請求残高 - 今回入金金額 
                            custDmdPrcWork.ThisTimeTtlBlcDmd = (custDmdPrcWork.LastTimeDemand + custDmdPrcWork.AcpOdrTtl2TmBfBlDmd + custDmdPrcWork.AcpOdrTtl3TmBfBlDmd) - custDmdPrcWork.ThisTimeDmdNrml;// 今回繰越残高(請求計)
                            // ■相殺
                            custDmdPrcWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));     // 相殺後今回売上金額
                            custDmdPrcWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));   // 相殺後外税対象額
                            custDmdPrcWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));     // 相殺後内税対象額
                            custDmdPrcWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF")); // 相殺後非課税対象額
                            custDmdPrcWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));               // 相殺後売上内税額

                            // 修正 2009/04/14 >>>
                            #region 相殺後消費税金額の計算( OffsetOutTax )
                            // ①請求転嫁(親)相殺後消費税　売上＋返品＋値引
                            SetTax = 0;
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESOUTTAX_S")) + SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSALESOUTTAX_S")) +
                                SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSALEOUTTAX_S")), FractionProcUnit, custDmdPrcWork.FractionProcCd, out SetTax);

                            // ②伝票転嫁相殺後消費税 売上+返品+値引
                            SetTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSALESOUTTAX_D")) +
                                     SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSALEOUTTAX_D"));

                            // ③明細転嫁相殺後消費税 売上+返品+値引
                            SetTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAX_M")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSALESOUTTAX_M")) +
                                     SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSALEOUTTAX_M"));

                            // ④請求転嫁(子)相殺消費税 売上+返品+値引 ※親子レコード集計時に計算

                            custDmdPrcWork.OffsetOutTax = SetTax;
                            #endregion

                            // 相殺後今回売上消費税額 = 相殺後売上外税額 + 相殺後売上内税額
                            custDmdPrcWork.OfsThisSalesTax = custDmdPrcWork.OffsetOutTax + custDmdPrcWork.OffsetInTax;       // 相殺後今回売上消費税額
                            // 修正 2009/04/14  <<<


                            // 修正 2009/04/14 >>>
                            // ■売上
                            custDmdPrcWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));            // 今回売上金額 
                            custDmdPrcWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));      // 今回売上外税対象額
                            custDmdPrcWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));        // 今回売上内税対象額
                            custDmdPrcWork.ItdedSalesTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESTAXFREERF"));    // 今回売上非課税対象額 
                            custDmdPrcWork.SalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESINTAXRF"));                  // 今回売上内税額
                            // 売上外税額 = 請求転嫁(親) + 伝票転嫁 + 明細転嫁 + 請求転嫁(子) ※請求転嫁(子)は親子レコード集計時に計算
                            SetTax = 0; 
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESOUTTAX_S")), FractionProcUnit, custDmdPrcWork.FractionProcCd, out SetTax);                            
                            SetTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAX_M"));
                            custDmdPrcWork.SalesOutTax = SetTax;// 今回売上外税額
                            custDmdPrcWork.ThisSalesTax = custDmdPrcWork.SalesOutTax + custDmdPrcWork.SalesInTax; // 今回売上消費税額
                            // 修正 2009/04/14 <<<

                            // 修正 2009/04/14 >>>
                            // ■返品
                            custDmdPrcWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));    // 今回売上返品金額
                            custDmdPrcWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));    // 今回売上返品外税対象額
                            custDmdPrcWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));      // 今回売上返品内税対象額
                            custDmdPrcWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));  // 今回売上返品非課税対象額
                            custDmdPrcWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));          // 今回売上返品内税額
                            // 今回返品外税額 = 請求転嫁(親) + 伝票転嫁 + 明細転嫁 + 請求転嫁(子) ※請求転嫁(子)は親子レコード集計時に計算
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSALESOUTTAX_S")), FractionProcUnit, custDmdPrcWork.FractionProcCd, out SetTax);
                            SetTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSALESOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSALESOUTTAX_M"));
                            custDmdPrcWork.TtlRetOuterTax = SetTax;// 今回売上返品外税額
                            custDmdPrcWork.ThisSalesPrcTaxRgds = custDmdPrcWork.TtlRetOuterTax + custDmdPrcWork.TtlRetInnerTax;// 今回売上返品消費税額
                            // 修正 2009/04/14 <<<

                            // 修正 2009/04/14 >>>
                            // ■値引
                            custDmdPrcWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));      // 今回売上値引金額
                            custDmdPrcWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));    // 今回売上値引外税対象金額
                            custDmdPrcWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));      // 今回売上値引内税対象金額
                            custDmdPrcWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));  // 今回売上値引非課税対象金額
                            custDmdPrcWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));          // 今回売上値引内税額
                            // 今回値引外税額 = 請求(親) + 伝票転嫁 + 明細転嫁 + 請求転嫁(子) ※請求転嫁(子)は親子レコード集計時に計算
                            FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSALEOUTTAX_S")), FractionProcUnit, custDmdPrcWork.FractionProcCd, out SetTax);
                            SetTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSALEOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSALEOUTTAX_M"));
                            custDmdPrcWork.TtlDisOuterTax = SetTax;// 今回売上値引外税額
                            custDmdPrcWork.ThisSalesPrcTaxDis = custDmdPrcWork.TtlDisOuterTax + custDmdPrcWork.TtlDisInnerTax;  // 今回売上値引消費税額
                            // 修正 2009/04/14 <<<

                            custDmdPrcWork.TaxAdjust = 0;     // 消費税調整額 (0固定)
                            custDmdPrcWork.BalanceAdjust = 0; // 残高調整額　 (0固定)

                            // 修正 2009/04/14 >>>
                            // 計算後請求金額 = 今回繰越残高 + (相殺後今回売上金額 + 相殺後今回売上消費税) ※親子レコード集計時に請求転嫁(子)の消費税加算
                            custDmdPrcWork.AfCalDemandPrice = custDmdPrcWork.ThisTimeTtlBlcDmd + (custDmdPrcWork.OfsThisTimeSales + custDmdPrcWork.OfsThisSalesTax);
                            // 修正 2009/04/14 <<<
                            //custDmdPrcWork.AcpOdrTtl2TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF")); // 受注2回前残高(請求計) (セット済み ※前回履歴から)
                            //custDmdPrcWork.AcpOdrTtl3TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFBLDMDRF")); // 受注3回前残高(請求計) (セット済み ※前回履歴から)                      
                            //custDmdPrcWork.CAddUpUpdExecDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDEXECDATERF"));   // 締次更新実行年月日(セット済み ※前回履歴から)
                            //custDmdPrcWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STARTCADDUPUPDDATERF")); // 締次更新開始年月日(セット済み ※前回履歴から) 
                            //custDmdPrcWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTCADDUPUPDDATERF"));   // 前回締次更新年月日(セット済み ※前回履歴から)
                            custDmdPrcWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF")); // 売上伝票枚数
                            custDmdPrcWork.BillPrintDate = DateTime.Now;  // 請求書発行日(システム日付)
                            // 入金予定日計算 >>>
                            // 集金月区分によってセット内容変動
                            // 修正 2009/07/10 >>>
                            //DateTime collectmoneyDate = custDmdPrcWork.CAddUpUpdExecDate;
                            DateTime collectmoneyDate = custDmdPrcWork.AddUpDate;
                            // 修正 2009/07/10 <<<
                            //add by liusy #32866 2012/10/18-->>>>>
                            //if (collectmoneyDate.Year != 9999 && collectmoneyDate.Month!= 12)//del by dpp #33856 2012/12/12
                            if (collectmoneyDate.Year != 9999)//add by dpp #33856 2012/12/12
                            {
                            //add by liusy #32866 2012/10/18--<<<<<
                                switch (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"))) // 0:当月,1:翌月,2:翌々月,3翌々々月
                                {
                                    case 1:
                                        collectmoneyDate = collectmoneyDate.AddMonths(1);
                                        break;
                                    case 2:
                                        collectmoneyDate = collectmoneyDate.AddMonths(2);
                                        break;
                                    case 3:
                                        collectmoneyDate = collectmoneyDate.AddMonths(3);
                                        break;
                                }
                                // 28日以降は末日とする
                                if (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF")) >= 28)
                                {
                                    collectmoneyDate = new DateTime(collectmoneyDate.Year, collectmoneyDate.Month, 1);
                                    collectmoneyDate = collectmoneyDate.AddMonths(1);
                                    collectmoneyDate = collectmoneyDate.AddDays(-1);
                                }
                                else
                                {
                                    collectmoneyDate = new DateTime(collectmoneyDate.Year, collectmoneyDate.Month, SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF")));
                                }
                            //add by liusy #32866 2012/10/18-->>>>>
                            }
                            //add by liusy #32866 2012/10/18--<<<<<
                            custDmdPrcWork.ExpectedDepositDate = collectmoneyDate;　// 入金予定日
                            // 入金予定日計算 <<<



                            #endregion
                        }

                        #endregion
                    }
                    // 初期化
                    if (!myReader.IsClosed) myReader.Close();
                    sqlCommand.Parameters.Clear();
                    sqlCommand.CommandText = string.Empty;
                    //sqlText = string.Empty; // DEL 菅原 庸平  2012/04/27
                    sqlText.Length = 0; // ADD 菅原 庸平  2012/04/27
                    //long itdedOffsetOutTax = 0; // 外税対象額
                    long OffsetOutTax = 0;      // 外税額
                    long SalesOutTax = 0;       // 売上外税額
                    long RetSalesOutTax = 0;    // 返品外税額
                    long DisSalesOutTax = 0;    // 返品外税額

                    int ChildCnt = 0;
                    double fractionProcUnit = 0;
                    long setTax = 0;
                    
                    #region ■親・子レコード集計処理

                    #region SELECT文
                    #region DEL 2009/04/14
                    /*
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "DMDPRC.CLAIMCODERF," + Environment.NewLine;
                    sqlText += "DMDPRC.CLAIMNAMERF," + Environment.NewLine;
                    sqlText += "DMDPRC.CLAIMNAME2RF," + Environment.NewLine;
                    sqlText += "DMDPRC.CLAIMSNMRF," + Environment.NewLine;
                    sqlText += "DMDPRC.CUSTOMERCODERF," + Environment.NewLine;
                    sqlText += "DMDPRC.CUSTOMERNAMERF," + Environment.NewLine;
                    sqlText += "DMDPRC.CUSTOMERNAME2RF," + Environment.NewLine;
                    sqlText += "DMDPRC.CUSTOMERSNMRF," + Environment.NewLine;
                    sqlText += "DMDPRC.FRACTIONPROCCDRF,  --端数処理単位" + Environment.NewLine;
                    sqlText += "DMDPRC.FRACTIONPROCUNITRF,--端数処理区分" + Environment.NewLine;
                    sqlText += "DMDPRC.RESULTSADDUPSECCDRF AS RESULTSSECTCDRF, --実績計上拠点" + Environment.NewLine;
                    sqlText += "DMDPRC.SALESNETPRICERF + DMDPRC.RETSALESNETPRICERF +DMDPRC.SALESDISTTLTAXEXCRF AS OFSTHISTIMESALESRF,               --相殺後今回売上金額" + Environment.NewLine;                   
                    sqlText += "DMDPRC.ITDEDSALESOUTTAXRF+DMDPRC.RETITDEDSALESOUTTAXRF+DMDPRC.ITDEDSALESDISOUTTAXRF AS ITDEDOFFSETOUTTAXRF,         --相殺後外税対象額 " + Environment.NewLine;
                    sqlText += "DMDPRC.ITDEDSALESINTAXRF+ DMDPRC.RETITDEDSALESINTAXRF+ DMDPRC.ITDEDSALESDISINTAXRF AS ITDEDOFFSETINTAXRF," + Environment.NewLine;
                    sqlText += "DMDPRC.SALSUBTTLSUBTOTAXFRERF+DMDPRC.RETSALSUBTTLSUBTOTAXFRERF+DMDPRC.ITDEDSALESDISTAXFRERF AS ITDEDOFFSETTAXFREERF, --相殺後非課税対象額" + Environment.NewLine;
                    sqlText += "DMDPRC.SALAMNTCONSTAXINCLURF + DMDPRC.RETSALAMNTCONSTAXINCLURF + DMDPRC.SALESDISTTLTAXINCLURF AS OFFSETINTAXRF,      --相殺後内税消費税" + Environment.NewLine;
                    // 売上
                    sqlText += "DMDPRC.SALESNETPRICERF AS THISTIMESALESRF,             --今回売上金額" + Environment.NewLine;
                    // 修正 2009.01.20 >>>
                    //sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 OR DMDPRC.CONSTAXLAYMETHODRF=1) THEN DMDPRC.SALESOUTTAXRF " + Environment.NewLine;
                    //sqlText += "ELSE (DMDPRC.SALESOUTTAXRF1 +DMDPRC.SALESOUTTAXRF2 +DMDPRC.SALESOUTTAXRF3) END)+DMDPRC.SALAMNTCONSTAXINCLURF AS THISSALESTAXRF, --今回売上消費税" + Environment.NewLine;
                    sqlText += "(CASE WHEN DMDPRC.CONSTAXLAYMETHODRF=0  THEN DMDPRC.SALESOUTTAXRF " + Environment.NewLine;
                    sqlText += "  ELSE (CASE WHEN DMDPRC.CONSTAXLAYMETHODRF=1 THEN DMDPRC.DTLSALESOUTTAXRF " + Environment.NewLine;
                    sqlText += "         ELSE (DMDPRC.SALESOUTTAXRF1 +DMDPRC.SALESOUTTAXRF2 +DMDPRC.SALESOUTTAXRF3) END)END)+DMDPRC.SALAMNTCONSTAXINCLURF AS THISSALESTAXRF, --今回売上消費税" + Environment.NewLine;

                    // 修正 2009.01.20 <<<
                    sqlText += "DMDPRC.ITDEDSALESOUTTAXRF AS ITDEDSALESOUTTAXRF,       --売上外税対象額" + Environment.NewLine;
                    sqlText += "DMDPRC.ITDEDSALESINTAXRF AS ITDEDSALESINTAXRF,         --売上内税対象額" + Environment.NewLine;
                    sqlText += "DMDPRC.SALSUBTTLSUBTOTAXFRERF AS ITDEDSALESTAXFREERF,  --売上非課税対象額" + Environment.NewLine;
                    // 修正 2009.01.20 >>>
                    //sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 OR DMDPRC.CONSTAXLAYMETHODRF=1) THEN DMDPRC.SALESOUTTAXRF " + Environment.NewLine;
                    //sqlText += "ELSE (DMDPRC.SALESOUTTAXRF1 +DMDPRC.SALESOUTTAXRF2 +DMDPRC.SALESOUTTAXRF3) END)AS SALESOUTTAXRF, --売上外税額" + Environment.NewLine;
                    sqlText += "(CASE WHEN DMDPRC.CONSTAXLAYMETHODRF=0  THEN DMDPRC.SALESOUTTAXRF " + Environment.NewLine;
                    sqlText += " ELSE(CASE WHEN  DMDPRC.CONSTAXLAYMETHODRF=1 THEN DMDPRC.DTLSALESOUTTAXRF " + Environment.NewLine;
                    sqlText += "       ELSE(DMDPRC.SALESOUTTAXRF1 +DMDPRC.SALESOUTTAXRF2 +DMDPRC.SALESOUTTAXRF3) END) END)AS SALESOUTTAXRF, --売上外税額" + Environment.NewLine;
                    // 修正 2009.01.20 <<<
                    sqlText += "DMDPRC.SALAMNTCONSTAXINCLURF AS SALESINTAXRF,         --売上内税額" + Environment.NewLine;
                    // 返品
                    sqlText += "DMDPRC.RETSALESNETPRICERF AS THISSALESPRICRGDSRF,     --今回売上返品額" + Environment.NewLine;
                    // 修正 2009.01.20 >>>
                    //sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 OR DMDPRC.CONSTAXLAYMETHODRF=1) THEN DMDPRC.RETSALESOUTTAXRF " + Environment.NewLine;
                    //sqlText += "ELSE (DMDPRC.RETSALESOUTTAXRF1 +DMDPRC.RETSALESOUTTAXRF2 +DMDPRC.RETSALESOUTTAXRF3) END)+DMDPRC.RETSALAMNTCONSTAXINCLURF AS THISSALESPRCTAXRGDSRF, --今回売上返品消費税" + Environment.NewLine;
                    sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 ) THEN DMDPRC.RETSALESOUTTAXRF " + Environment.NewLine;
                    sqlText += "  ELSE (CASE WHEN DMDPRC.CONSTAXLAYMETHODRF=1 THEN DMDPRC.DTLRETSALESOUTTAXRF " + Environment.NewLine;
                    sqlText += "         ELSE (DMDPRC.RETSALESOUTTAXRF1 +DMDPRC.RETSALESOUTTAXRF2 +DMDPRC.RETSALESOUTTAXRF3) END ) END)+DMDPRC.RETSALAMNTCONSTAXINCLURF AS THISSALESPRCTAXRGDSRF, --今回売上返品消費税" + Environment.NewLine;
                    // 修正 2009.01.20 <<<
                    sqlText += "DMDPRC.RETITDEDSALESOUTTAXRF AS TTLITDEDRETOUTTAXRF,      --返品外税対象額合計" + Environment.NewLine;
                    sqlText += "DMDPRC.RETITDEDSALESINTAXRF AS TTLITDEDRETINTAXRF,        --返品内税対象額合計" + Environment.NewLine;
                    sqlText += "DMDPRC.RETSALSUBTTLSUBTOTAXFRERF AS TTLITDEDRETTAXFREERF, --返品非課税対象額合計" + Environment.NewLine;
                    // 修正 2009.01.20 >>>
                    //sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 OR DMDPRC.CONSTAXLAYMETHODRF=1) THEN DMDPRC.RETSALESOUTTAXRF " + Environment.NewLine;
                    //sqlText += "ELSE (DMDPRC.RETSALESOUTTAXRF1 +DMDPRC.RETSALESOUTTAXRF2 +DMDPRC.RETSALESOUTTAXRF3) END)AS TTLRETOUTERTAXRF, --返品外税額合計" + Environment.NewLine;
                    sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0  ) THEN DMDPRC.RETSALESOUTTAXRF " + Environment.NewLine;
                    sqlText += "  ELSE (CASE WHEN DMDPRC.CONSTAXLAYMETHODRF=1 THEN DMDPRC.DTLRETSALESOUTTAXRF " + Environment.NewLine;
                    sqlText += "         ELSE (DMDPRC.RETSALESOUTTAXRF1 +DMDPRC.RETSALESOUTTAXRF2 +DMDPRC.RETSALESOUTTAXRF3) END ) END)AS TTLRETOUTERTAXRF, --返品外税額合計" + Environment.NewLine;
                    // 修正 2009.01.20 <<<
                    sqlText += "DMDPRC.RETSALAMNTCONSTAXINCLURF AS TTLRETINNERTAXRF,  --返品内税額合計" + Environment.NewLine;
                    // 値引
                    sqlText += "DMDPRC.SALESDISTTLTAXEXCRF AS THISSALESPRICDISRF,     --今回売上値引金額" + Environment.NewLine;
                    // 修正 2009.01.20 >>>
                    //sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 OR DMDPRC.CONSTAXLAYMETHODRF=1) THEN DMDPRC.SALESDISOUTTAXRF " + Environment.NewLine;
                    //sqlText += " ELSE (DMDPRC.SALESDISOUTTAXRF1 +DMDPRC.SALESDISOUTTAXRF2 +DMDPRC.SALESDISOUTTAXRF3) END)+DMDPRC.SALESDISTTLTAXINCLURF AS THISSALESPRCTAXDISRF, --今回売上値引消費税" + Environment.NewLine;
                    sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 ) THEN DMDPRC.SALESDISOUTTAXRF " + Environment.NewLine;
                    sqlText += " ELSE(CASE WHEN DMDPRC.CONSTAXLAYMETHODRF=1 THEN DMDPRC.DTLSALESDISOUTTAXRF " + Environment.NewLine;
                    sqlText += "      ELSE (DMDPRC.SALESDISOUTTAXRF1 +DMDPRC.SALESDISOUTTAXRF2 +DMDPRC.SALESDISOUTTAXRF3) END) END)+DMDPRC.SALESDISTTLTAXINCLURF AS THISSALESPRCTAXDISRF, --今回売上値引消費税" + Environment.NewLine;
                    // 修正 2009.01.20 <<<
                    sqlText += "DMDPRC.ITDEDSALESDISOUTTAXRF AS TTLITDEDDISOUTTAXRF,  --値引外税対象額合計" + Environment.NewLine;
                    sqlText += "DMDPRC.ITDEDSALESDISINTAXRF AS TTLITDEDDISINTAXRF,    --値引内税対象額合計" + Environment.NewLine;
                    sqlText += "DMDPRC.ITDEDSALESDISTAXFRERF AS TTLITDEDDISTAXFREERF, --値引非課税対象額合計" + Environment.NewLine;
                    // 修正 2009.01.20 >>>
                    //sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 OR DMDPRC.CONSTAXLAYMETHODRF=1) THEN DMDPRC.SALESDISOUTTAXRF " + Environment.NewLine;
                    //sqlText += " ELSE (DMDPRC.SALESDISOUTTAXRF1 +DMDPRC.SALESDISOUTTAXRF2 +DMDPRC.SALESDISOUTTAXRF3) END)AS TTLDISOUTERTAXRF, --値引外税額合計" + Environment.NewLine;
                    sqlText += "(CASE WHEN (DMDPRC.CONSTAXLAYMETHODRF=0 ) THEN DMDPRC.SALESDISOUTTAXRF " + Environment.NewLine;
                    sqlText += " ELSE (CASE WHEN DMDPRC.CONSTAXLAYMETHODRF=1 THEN DMDPRC.DTLSALESDISOUTTAXRF " + Environment.NewLine;
                    sqlText += "       ELSE  (DMDPRC.SALESDISOUTTAXRF1 +DMDPRC.SALESDISOUTTAXRF2 +DMDPRC.SALESDISOUTTAXRF3) END) END)AS TTLDISOUTERTAXRF, --値引外税額合計" + Environment.NewLine;
                    // 修正 2009.01.20 <<<
                    sqlText += "DMDPRC.SALESDISTTLTAXINCLURF AS TTLDISINNERTAXRF,  --値引内税額合計" + Environment.NewLine;
                    sqlText += "DMDPRC.SALESSLIPCOUNT AS SALESSLIPCOUNTRF,         --売上伝票枚数" + Environment.NewLine;
                    sqlText += "DMDPRC.COLLECTCONDRF AS COLLECTCONDRF,             --回収条件" + Environment.NewLine;
                    sqlText += "DMDPRC.CONSTAXLAYMETHODRF AS CONSTAXLAYMETHODRF,   --消費税転嫁方式" + Environment.NewLine;
                    sqlText += "DMDPRC.SALESCNSTAXFRCPROCCDRF AS FRACTIONPROCCDRF, --端数処理区分" + Environment.NewLine;
                    sqlText += "DMDPRC.COLLECTMONEYCODERF AS COLLECTMONEYCODERF,   --集金月区分コード" + Environment.NewLine;
                    sqlText += "DMDPRC.COLLECTMONEYDAYRF AS COLLECTMONEYDAYRF,     --集金日" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,   --税率開始日" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATEENDDATERF AS TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATERF AS TAXRATERF,                     --税率" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF, --税率開始日2" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,     --税率終了日2" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATE2RF AS TAXRATE2RF,                   --税率2" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF, --税率開始日3" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,     --税率終了日3" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATE3RF AS TAXRATE3RF                    --税率3" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    */
                    #endregion
                    // DEL 菅原 庸平 2012/04/27 >>>
                    /*
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "DMDPRC.CLAIMCODERF," + Environment.NewLine;
                    sqlText += "DMDPRC.CLAIMNAMERF," + Environment.NewLine;
                    sqlText += "DMDPRC.CLAIMNAME2RF," + Environment.NewLine;
                    sqlText += "DMDPRC.CLAIMSNMRF," + Environment.NewLine;
                    sqlText += "DMDPRC.CUSTOMERCODERF," + Environment.NewLine;
                    sqlText += "DMDPRC.CUSTOMERNAMERF," + Environment.NewLine;
                    sqlText += "DMDPRC.CUSTOMERNAME2RF," + Environment.NewLine;
                    sqlText += "DMDPRC.CUSTOMERSNMRF," + Environment.NewLine;
                    sqlText += "DMDPRC.FRACTIONPROCCDRF,  --端数処理単位" + Environment.NewLine;
                    sqlText += "DMDPRC.FRACTIONPROCUNITRF,--端数処理区分" + Environment.NewLine;
                    sqlText += "DMDPRC.RESULTSADDUPSECCDRF AS RESULTSSECTCDRF, --実績計上拠点" + Environment.NewLine;
                    sqlText += "DMDPRC.SALESNETPRICERF + DMDPRC.RETSALESNETPRICERF +DMDPRC.SALESDISTTLTAXEXCRF AS OFSTHISTIMESALESRF,      --相殺後今回売上金額" + Environment.NewLine;
                    sqlText += "DMDPRC.ITDEDSALESOUTTAXRF+DMDPRC.RETITDEDSALESOUTTAXRF+DMDPRC.ITDEDSALESDISOUTTAXRF AS ITDEDOFFSETOUTTAXRF,--相殺後外税対象額 " + Environment.NewLine;
                    sqlText += "DMDPRC.ITDEDSALESINTAXRF+ DMDPRC.RETITDEDSALESINTAXRF+ DMDPRC.ITDEDSALESDISINTAXRF AS ITDEDOFFSETINTAXRF," + Environment.NewLine;
                    sqlText += "DMDPRC.SALSUBTTLSUBTOTAXFRERF+DMDPRC.RETSALSUBTTLSUBTOTAXFRERF+DMDPRC.ITDEDSALESDISTAXFRERF AS ITDEDOFFSETTAXFREERF, --相殺後非課税対象額" + Environment.NewLine;
                    sqlText += "DMDPRC.SALAMNTCONSTAXINCLURF + DMDPRC.RETSALAMNTCONSTAXINCLURF + DMDPRC.SALESDISTTLTAXINCLURF AS OFFSETINTAXRF,      --相殺後内税消費税" + Environment.NewLine;
                    sqlText += "-- ■ ■ 売上 ■ ■" + Environment.NewLine;
                    sqlText += "DMDPRC.SALESNETPRICERF AS THISTIMESALESRF,      --今回売上金額" + Environment.NewLine;
                    sqlText += "DMDPRC.ITDEDSALESOUTTAXRF AS ITDEDSALESOUTTAXRF,--売上外税対象額" + Environment.NewLine;
                    sqlText += "DMDPRC.ITDEDSALESINTAXRF AS ITDEDSALESINTAXRF,  --売上内税対象額" + Environment.NewLine;
                    sqlText += "DMDPRC.SALSUBTTLSUBTOTAXFRERF AS ITDEDSALESTAXFREERF,--売上非課税対象額" + Environment.NewLine;
                    sqlText += "DMDPRC.SALESOUTTAXRF AS SALESOUTTAX_D,    -- 伝票転嫁" + Environment.NewLine;
                    sqlText += "DMDPRC.DTLSALESOUTTAXRF AS SALESOUTTAX_M,-- 明細転嫁" + Environment.NewLine;
                    sqlText += "DMDPRC.SALESOUTTAXRF1 +DMDPRC.SALESOUTTAXRF2 +DMDPRC.SALESOUTTAXRF3 AS  SALESOUTTAX_S, -- 請求転嫁(子)" + Environment.NewLine;
                    sqlText += "DMDPRC.SALESOUTTAXRF1_2 +DMDPRC.SALESOUTTAXRF2_2 +DMDPRC.SALESOUTTAXRF3_2 AS  SALESOUTTAX_S2, -- 請求転嫁(親)" + Environment.NewLine;
                    sqlText += "DMDPRC.SALAMNTCONSTAXINCLURF AS SALESINTAXRF,--売上内税額" + Environment.NewLine;
                    sqlText += "-- ■ ■ 返品 ■ ■" + Environment.NewLine;
                    sqlText += "DMDPRC.RETSALESNETPRICERF AS THISSALESPRICRGDSRF,   --今回売上返品額" + Environment.NewLine;
                    sqlText += "DMDPRC.RETITDEDSALESOUTTAXRF AS TTLITDEDRETOUTTAXRF,--返品外税対象額合計" + Environment.NewLine;
                    sqlText += "DMDPRC.RETITDEDSALESINTAXRF AS TTLITDEDRETINTAXRF,  --返品内税対象額合計" + Environment.NewLine;
                    sqlText += "DMDPRC.RETSALSUBTTLSUBTOTAXFRERF AS TTLITDEDRETTAXFREERF,--返品非課税対象額合計" + Environment.NewLine;
                    sqlText += "DMDPRC.RETSALESOUTTAXRF AS RETSALESOUTTAX_D, -- 伝票転嫁" + Environment.NewLine;
                    sqlText += "DMDPRC.DTLRETSALESOUTTAXRF AS RETSALESOUTTAX_M, -- 伝票転嫁" + Environment.NewLine;
                    sqlText += "DMDPRC.RETSALESOUTTAXRF1 +DMDPRC.RETSALESOUTTAXRF2 +DMDPRC.RETSALESOUTTAXRF3 AS RETSALESOUTTAX_S, -- 請求転嫁(子)" + Environment.NewLine;
                    sqlText += "DMDPRC.RETSALESOUTTAXRF1_2 +DMDPRC.RETSALESOUTTAXRF2_2 +DMDPRC.RETSALESOUTTAXRF3_2 AS RETSALESOUTTAX_S2, -- 請求転嫁(親)" + Environment.NewLine;
                    sqlText += "DMDPRC.RETSALAMNTCONSTAXINCLURF AS TTLRETINNERTAXRF,  --返品内税額合計" + Environment.NewLine;
                    sqlText += "-- ■ ■ 値引 ■ ■" + Environment.NewLine;
                    sqlText += "DMDPRC.SALESDISTTLTAXEXCRF AS THISSALESPRICDISRF,     --今回売上値引金額" + Environment.NewLine;
                    sqlText += "DMDPRC.ITDEDSALESDISOUTTAXRF AS TTLITDEDDISOUTTAXRF,  --値引外税対象額合計" + Environment.NewLine;
                    sqlText += "DMDPRC.ITDEDSALESDISINTAXRF AS TTLITDEDDISINTAXRF,    --値引内税対象額合計" + Environment.NewLine;
                    sqlText += "DMDPRC.ITDEDSALESDISTAXFRERF AS TTLITDEDDISTAXFREERF, --値引非課税対象額合計" + Environment.NewLine;
                    sqlText += "DMDPRC.SALESDISOUTTAXRF AS DISSALESOUTTAX_D,    -- 伝票転嫁" + Environment.NewLine;
                    sqlText += "DMDPRC.DTLSALESDISOUTTAXRF AS DISSALESOUTTAX_M, -- 明細転嫁" + Environment.NewLine;
                    sqlText += "DMDPRC.SALESDISOUTTAXRF1 +DMDPRC.SALESDISOUTTAXRF2 +DMDPRC.SALESDISOUTTAXRF3 AS DISSALESOUTTAX_S, -- 請求転嫁(子)" + Environment.NewLine;
                    sqlText += "DMDPRC.SALESDISOUTTAXRF1_2 +DMDPRC.SALESDISOUTTAXRF2_2 +DMDPRC.SALESDISOUTTAXRF3_2 AS DISSALESOUTTAX_S2, -- 請求転嫁(親)" + Environment.NewLine;
                    sqlText += "DMDPRC.SALESDISTTLTAXINCLURF AS TTLDISINNERTAXRF,  --値引内税額合計" + Environment.NewLine;
                    sqlText += "DMDPRC.SALESSLIPCOUNT AS SALESSLIPCOUNTRF,         --売上伝票枚数" + Environment.NewLine;
                    sqlText += "DMDPRC.COLLECTCONDRF AS COLLECTCONDRF,             --回収条件" + Environment.NewLine;
                    sqlText += "DMDPRC.CONSTAXLAYMETHODRF AS CONSTAXLAYMETHODRF,   --消費税転嫁方式" + Environment.NewLine;// ADD 2010/12/20
                    sqlText += "DMDPRC.SALESCNSTAXFRCPROCCDRF AS FRACTIONPROCCDRF, --端数処理区分" + Environment.NewLine;
                    sqlText += "DMDPRC.COLLECTMONEYCODERF AS COLLECTMONEYCODERF,   --集金月区分コード" + Environment.NewLine;
                    sqlText += "DMDPRC.COLLECTMONEYDAYRF AS COLLECTMONEYDAYRF,     --集金日" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,   --税率開始日" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATEENDDATERF AS TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATERF AS TAXRATERF,                     --税率" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF, --税率開始日2" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,     --税率終了日2" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATE2RF AS TAXRATE2RF,                   --税率2" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF, --税率開始日3" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,     --税率終了日3" + Environment.NewLine;
                    sqlText += "DMDPRC.TAXRATE3RF AS TAXRATE3RF                    --税率3" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    */
                    // DEL 菅原 庸平 2012/04/27 <<<
                    // ADD 菅原 庸平  2012/04/27 >>>
                    sqlText.Append("SELECT" + Environment.NewLine);
                    sqlText.Append("DMDPRC.CLAIMCODERF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CLAIMNAMERF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CLAIMNAME2RF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CLAIMSNMRF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CUSTOMERCODERF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CUSTOMERNAMERF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CUSTOMERNAME2RF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CUSTOMERSNMRF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.FRACTIONPROCCDRF,  --端数処理単位" + Environment.NewLine);
                    sqlText.Append("DMDPRC.FRACTIONPROCUNITRF,--端数処理区分" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RESULTSADDUPSECCDRF AS RESULTSSECTCDRF, --実績計上拠点" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESNETPRICERF + DMDPRC.RETSALESNETPRICERF +DMDPRC.SALESDISTTLTAXEXCRF AS OFSTHISTIMESALESRF,      --相殺後今回売上金額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESOUTTAXRF+DMDPRC.RETITDEDSALESOUTTAXRF+DMDPRC.ITDEDSALESDISOUTTAXRF AS ITDEDOFFSETOUTTAXRF,--相殺後外税対象額 " + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESINTAXRF+ DMDPRC.RETITDEDSALESINTAXRF+ DMDPRC.ITDEDSALESDISINTAXRF AS ITDEDOFFSETINTAXRF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALSUBTTLSUBTOTAXFRERF+DMDPRC.RETSALSUBTTLSUBTOTAXFRERF+DMDPRC.ITDEDSALESDISTAXFRERF AS ITDEDOFFSETTAXFREERF, --相殺後非課税対象額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALAMNTCONSTAXINCLURF + DMDPRC.RETSALAMNTCONSTAXINCLURF + DMDPRC.SALESDISTTLTAXINCLURF AS OFFSETINTAXRF,      --相殺後内税消費税" + Environment.NewLine);
                    sqlText.Append("-- ■ ■ 売上 ■ ■" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESNETPRICERF AS THISTIMESALESRF,      --今回売上金額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESOUTTAXRF AS ITDEDSALESOUTTAXRF,--売上外税対象額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESINTAXRF AS ITDEDSALESINTAXRF,  --売上内税対象額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALSUBTTLSUBTOTAXFRERF AS ITDEDSALESTAXFREERF,--売上非課税対象額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESOUTTAXRF AS SALESOUTTAX_D,    -- 伝票転嫁" + Environment.NewLine);
                    sqlText.Append("DMDPRC.DTLSALESOUTTAXRF AS SALESOUTTAX_M,-- 明細転嫁" + Environment.NewLine);
                    //sqlText.Append("DMDPRC.SALESOUTTAXRF1 +DMDPRC.SALESOUTTAXRF2 +DMDPRC.SALESOUTTAXRF3 AS  SALESOUTTAX_S, -- 請求転嫁(子)" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.SALESOUTTAXRF1*TAXRATERF +DMDPRC.SALESOUTTAXRF2*TAXRATE2RF +DMDPRC.SALESOUTTAXRF3*TAXRATE3RF AS  SALESOUTTAX_S, -- 請求転嫁(子)" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    //sqlText.Append("DMDPRC.SALESOUTTAXRF1_2 +DMDPRC.SALESOUTTAXRF2_2 +DMDPRC.SALESOUTTAXRF3_2 AS  SALESOUTTAX_S2, -- 請求転嫁(親)" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.SALESOUTTAXRF1_2*TAXRATERF +DMDPRC.SALESOUTTAXRF2_2*TAXRATE2RF +DMDPRC.SALESOUTTAXRF3_2*TAXRATE3RF AS  SALESOUTTAX_S2, -- 請求転嫁(親)" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.SALAMNTCONSTAXINCLURF AS SALESINTAXRF,--売上内税額" + Environment.NewLine);
                    sqlText.Append("-- ■ ■ 返品 ■ ■" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RETSALESNETPRICERF AS THISSALESPRICRGDSRF,   --今回売上返品額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RETITDEDSALESOUTTAXRF AS TTLITDEDRETOUTTAXRF,--返品外税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RETITDEDSALESINTAXRF AS TTLITDEDRETINTAXRF,  --返品内税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RETSALSUBTTLSUBTOTAXFRERF AS TTLITDEDRETTAXFREERF,--返品非課税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RETSALESOUTTAXRF AS RETSALESOUTTAX_D, -- 伝票転嫁" + Environment.NewLine);
                    sqlText.Append("DMDPRC.DTLRETSALESOUTTAXRF AS RETSALESOUTTAX_M, -- 伝票転嫁" + Environment.NewLine);
                    //sqlText.Append("DMDPRC.RETSALESOUTTAXRF1 +DMDPRC.RETSALESOUTTAXRF2 +DMDPRC.RETSALESOUTTAXRF3 AS RETSALESOUTTAX_S, -- 請求転嫁(子)" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.RETSALESOUTTAXRF1*TAXRATERF +DMDPRC.RETSALESOUTTAXRF2*TAXRATE2RF +DMDPRC.RETSALESOUTTAXRF3*TAXRATE3RF AS RETSALESOUTTAX_S, -- 請求転嫁(子)" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    //sqlText.Append("DMDPRC.RETSALESOUTTAXRF1_2 +DMDPRC.RETSALESOUTTAXRF2_2 +DMDPRC.RETSALESOUTTAXRF3_2 AS RETSALESOUTTAX_S2, -- 請求転嫁(親)" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.RETSALESOUTTAXRF1_2*TAXRATERF +DMDPRC.RETSALESOUTTAXRF2_2*TAXRATE2RF +DMDPRC.RETSALESOUTTAXRF3_2*TAXRATE3RF AS RETSALESOUTTAX_S2, -- 請求転嫁(親)" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.RETSALAMNTCONSTAXINCLURF AS TTLRETINNERTAXRF,  --返品内税額合計" + Environment.NewLine);
                    sqlText.Append("-- ■ ■ 値引 ■ ■" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESDISTTLTAXEXCRF AS THISSALESPRICDISRF,     --今回売上値引金額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESDISOUTTAXRF AS TTLITDEDDISOUTTAXRF,  --値引外税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESDISINTAXRF AS TTLITDEDDISINTAXRF,    --値引内税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESDISTAXFRERF AS TTLITDEDDISTAXFREERF, --値引非課税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESDISOUTTAXRF AS DISSALESOUTTAX_D,    -- 伝票転嫁" + Environment.NewLine);
                    sqlText.Append("DMDPRC.DTLSALESDISOUTTAXRF AS DISSALESOUTTAX_M, -- 明細転嫁" + Environment.NewLine);
                    //sqlText.Append("DMDPRC.SALESDISOUTTAXRF1 +DMDPRC.SALESDISOUTTAXRF2 +DMDPRC.SALESDISOUTTAXRF3 AS DISSALESOUTTAX_S, -- 請求転嫁(子)" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.SALESDISOUTTAXRF1*TAXRATERF +DMDPRC.SALESDISOUTTAXRF2*TAXRATE2RF +DMDPRC.SALESDISOUTTAXRF3*TAXRATE3RF AS DISSALESOUTTAX_S, -- 請求転嫁(子)" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    //sqlText.Append("DMDPRC.SALESDISOUTTAXRF1_2 +DMDPRC.SALESDISOUTTAXRF2_2 +DMDPRC.SALESDISOUTTAXRF3_2 AS DISSALESOUTTAX_S2, -- 請求転嫁(親)" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.SALESDISOUTTAXRF1_2*TAXRATERF +DMDPRC.SALESDISOUTTAXRF2_2*TAXRATE2RF +DMDPRC.SALESDISOUTTAXRF3_2*TAXRATE3RF AS DISSALESOUTTAX_S2, -- 請求転嫁(親)" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.SALESDISTTLTAXINCLURF AS TTLDISINNERTAXRF,  --値引内税額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESSLIPCOUNT AS SALESSLIPCOUNTRF,         --売上伝票枚数" + Environment.NewLine);
                    sqlText.Append("DMDPRC.COLLECTCONDRF AS COLLECTCONDRF,             --回収条件" + Environment.NewLine);
                    sqlText.Append("DMDPRC.CONSTAXLAYMETHODRF AS CONSTAXLAYMETHODRF,   --消費税転嫁方式" + Environment.NewLine);// ADD 2010/12/20
                    sqlText.Append("DMDPRC.SALESCNSTAXFRCPROCCDRF AS FRACTIONPROCCDRF, --端数処理区分" + Environment.NewLine);
                    sqlText.Append("DMDPRC.COLLECTMONEYCODERF AS COLLECTMONEYCODERF,   --集金月区分コード" + Environment.NewLine);
                    sqlText.Append("DMDPRC.COLLECTMONEYDAYRF AS COLLECTMONEYDAYRF,     --集金日" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,   --税率開始日" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATEENDDATERF AS TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATERF AS TAXRATERF,                     --税率" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF, --税率開始日2" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,     --税率終了日2" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATE2RF AS TAXRATE2RF,                   --税率2" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF, --税率開始日3" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,     --税率終了日3" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATE3RF AS TAXRATE3RF                    --税率3" + Environment.NewLine);
                    sqlText.Append("FROM" + Environment.NewLine);
                    sqlText.Append("(" + Environment.NewLine);
                    // ADD 菅原 庸平  2012/04/27 <<<
                    #endregion

                    #region SUBクエリ
                    #region DEL 2009/04/14
                    /*
                    sqlText += "  SELECT" + Environment.NewLine;
                    sqlText += "   SALE.CLAIMCODERF AS CLAIMCODERF," + Environment.NewLine;
                    sqlText += "   CLAIM.NAMERF AS CLAIMNAMERF," + Environment.NewLine;
                    sqlText += "   CLAIM.NAME2RF AS CLAIMNAME2RF," + Environment.NewLine;
                    sqlText += "   CLAIM.CUSTOMERSNMRF AS CLAIMSNMRF," + Environment.NewLine;
                    sqlText += "   SALE.CUSTOMERCODERF AS CUSTOMERCODERF," + Environment.NewLine;
                    sqlText += "   CUST.NAMERF AS CUSTOMERNAMERF," + Environment.NewLine;
                    sqlText += "   CUST.NAME2RF AS CUSTOMERNAME2RF," + Environment.NewLine;
                    sqlText += "   CUST.CUSTOMERSNMRF AS CUSTOMERSNMRF," + Environment.NewLine;
                    sqlText += "   SALE.RESULTSADDUPSECCDRF,                              --実績計上拠点" + Environment.NewLine;
                    //sqlText += "   CLAIM.CONSTAXLAYMETHODRF AS CONSTAXLAYMETHODRF,        --消費税転嫁方式" + Environment.NewLine;
                    sqlText += "   (CASE WHEN CLAIM.CUSTCTAXLAYREFCDRF = 0 THEN SALE.TAXCONSTAXLAYMETHODRF ELSE CLAIM.CONSTAXLAYMETHODRF END ) AS CONSTAXLAYMETHODRF," + Environment.NewLine;        //消費税転嫁方式
                    sqlText += "   CLAIM.COLLECTCONDRF AS COLLECTCONDRF,                  --回収条件" + Environment.NewLine;
                    sqlText += "   CLAIM.COLLECTMONEYCODERF AS COLLECTMONEYCODERF,        --集金月区分コード" + Environment.NewLine;
                    sqlText += "   CLAIM.COLLECTMONEYDAYRF AS COLLECTMONEYDAYRF,          --集金日" + Environment.NewLine;
                    sqlText += "   CLAIM.SALESCNSTAXFRCPROCCDRF AS SALESCNSTAXFRCPROCCDRF,--売上消費税端数処理コード" + Environment.NewLine;
                    sqlText += "   SALESPROC.FRACTIONPROCCDRF,                            --端数処理単位" + Environment.NewLine;
                    sqlText += "   SALESPROC.FRACTIONPROCUNITRF,                          --端数処理区分" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,         --税率開始日" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATEENDDATERF AS TAXRATEENDDATERF,             --税率終了日" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATERF AS TAXRATERF,                           --税率" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF,       --税率開始日2" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,           --税率終了日2" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATE2RF AS TAXRATE2RF,                         --税率2" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF,       --税率開始日3" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,           --税率終了日3" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATE3RF AS TAXRATE3RF,                         --税率3" + Environment.NewLine;
                    sqlText += "   COUNT(SALE.SALESSLIPNUMRF) SALESSLIPCOUNT,             --伝票枚数" + Environment.NewLine;

                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS SALESNETPRICERF,                --売上正価金額" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.ITDEDSALESOUTTAXRF ELSE 0 END)) AS ITDEDSALESOUTTAXRF,          --売上外税対象額" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.ITDEDSALESINTAXRF ELSE 0 END)) AS ITDEDSALESINTAXRF,            --売上内税対象額" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALSUBTTLSUBTOTAXFRERF ELSE 0 END)) AS SALSUBTTLSUBTOTAXFRERF,  --売上小計非課税対象額" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALESOUTTAXRF ELSE 0 END)) AS SALESOUTTAXRF,                    --消費税額（外税）伝票" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.DTLSALESOUTTAXRF ELSE 0 END)) AS DTLSALESOUTTAXRF,              --消費税額（外税）明細" + Environment.NewLine; //2009.01.20 追加 <<<
                    sqlText += "   SUM((CASE WHEN (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS SALESOUTTAXRF1,                                --売上金額消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESOUTTAXRF2,                                    --売上金額消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESOUTTAXRF3,                                    --売上金額消費税額（外税）税率3" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALAMNTCONSTAXINCLURF ELSE 0 END)) AS SALAMNTCONSTAXINCLURF,     --売上金額消費税額（内税）" + Environment.NewLine;
                    //返品
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS RETSALESNETPRICERF,              --返品 売上正価金額" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.ITDEDSALESOUTTAXRF ELSE 0 END)) AS RETITDEDSALESOUTTAXRF,        --返品 売上外税対象額" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.ITDEDSALESINTAXRF ELSE 0 END)) AS RETITDEDSALESINTAXRF,          --返品 売上内税対象額" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALSUBTTLSUBTOTAXFRERF ELSE 0 END)) AS RETSALSUBTTLSUBTOTAXFRERF,--返品 売上小計非課税対象額 " + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALESOUTTAXRF ELSE 0 END)) AS RETSALESOUTTAXRF,                  --返品 消費税額（外税）伝票転嫁" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.DTLSALESOUTTAXRF ELSE 0 END)) AS DTLRETSALESOUTTAXRF,            --返品 消費税額（外税）明細転嫁" + Environment.NewLine; //2009.01.20 追加    
                    sqlText += "   SUM((CASE WHEN (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS RETSALESOUTTAXRF1,                         --返品 売上金額消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS RETSALESOUTTAXRF2,                             --返品 売上金額消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS RETSALESOUTTAXRF3,                             --返品 売上金額消費税額（外税）税率3" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALAMNTCONSTAXINCLURF ELSE 0 END)) AS RETSALAMNTCONSTAXINCLURF,  --返品 売上金額消費税額（内税）" + Environment.NewLine;
                    // 値引
                    sqlText += "   SUM(SALE.SALESDISTTLTAXEXCRF) AS SALESDISTTLTAXEXCRF,        --売上値引金額計（税抜き）" + Environment.NewLine;
                    sqlText += "   SUM(SALE.ITDEDSALESDISOUTTAXRF) AS ITDEDSALESDISOUTTAXRF,    --売上値引外税対象額合計" + Environment.NewLine;
                    sqlText += "   SUM(SALE.ITDEDSALESDISINTAXRF) AS ITDEDSALESDISINTAXRF,      --売上値引内税対象額合計 " + Environment.NewLine;
                    sqlText += "   SUM(SALE.ITDEDSALESDISTAXFRERF) AS ITDEDSALESDISTAXFRERF,    --売上値引非課税対象額合計" + Environment.NewLine;
                    sqlText += "   SUM(SALE.SALESDISOUTTAXRF) AS SALESDISOUTTAXRF,              --値引消費税額（外税）伝票転嫁" + Environment.NewLine;
                    sqlText += "   SUM(SALE.SALESDISOUTTAXRF) AS DTLSALESDISOUTTAXRF,        --値引消費税額（外税）明細転嫁" + Environment.NewLine; // 2009.01.20 追加    
                    sqlText += "   SUM((CASE WHEN (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATERF) ELSE 0 END)) AS SALESDISOUTTAXRF1,              --売上値引消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESDISOUTTAXRF2,              --売上値引消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESDISOUTTAXRF3,              --売上値引消費税額（外税）税率3" + Environment.NewLine;
                    sqlText += "   SUM(SALE.SALESDISTTLTAXINCLURF) AS SALESDISTTLTAXINCLURF    --売上値引消費税額（内税）" + Environment.NewLine;
                    sqlText += "  FROM" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    sqlText += "     SELECT" + Environment.NewLine;
                    sqlText += "      SUBSALE.ENTERPRISECODERF," + Environment.NewLine;
                    //sqlText += "      SUBSALE.CLAIMCODERF," + Environment.NewLine;
                    sqlText += "      (CASE WHEN (SEARCHCUST.CLAIMCODERF IS NOT NULL) THEN SEARCHCUST.CLAIMCODERF ELSE SUBSALE.CLAIMCODERF END) AS CLAIMCODERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.CUSTOMERCODERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.RESULTSADDUPSECCDRF, --実績計上拠点" + Environment.NewLine;
                    sqlText += "      SUBSALE.ADDUPADATERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.ACPTANODRSTATUSRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.DEBITNOTEDIVRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESSLIPNUMRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESSLIPCDRF," + Environment.NewLine;
                    // 修正 2009.03.23 >>>
                    //sqlText += "      SUBSALE.SALESNETPRICERF," + Environment.NewLine;
                    //sqlText += "      SUBSALE.ITDEDSALESOUTTAXRF," + Environment.NewLine;
                    //sqlText += "      SUBSALE.ITDEDSALESINTAXRF," + Environment.NewLine;
                    //sqlText += "      SUBSALE.SALSUBTTLSUBTOTAXFRERF," + Environment.NewLine;
                    //sqlText += "      SUBSALE.SALESOUTTAXRF," + Environment.NewLine;
                    //sqlText += "      SUBSALE.SALAMNTCONSTAXINCLURF," + Environment.NewLine;
                    //sqlText += "      SUBSALE.SALESDISTTLTAXEXCRF," + Environment.NewLine;
                    //sqlText += "      SUBSALE.ITDEDSALESDISOUTTAXRF," + Environment.NewLine;
                    //sqlText += "      SUBSALE.ITDEDSALESDISINTAXRF," + Environment.NewLine;
                    //sqlText += "      SUBSALE.ITDEDSALESDISTAXFRERF," + Environment.NewLine;
                    //sqlText += "      SUBSALE.SALESDISOUTTAXRF," + Environment.NewLine;
                    //sqlText += "      SUBSALE.SALESDISTTLTAXINCLURF," + Environment.NewLine;
                    //sqlText += "      SALEDTL.DTLSALESOUTTAXRF, " + Environment.NewLine;
                    //sqlText += "      SALEDTL.DTLSALAMNTCONSTAXINCLURF," + Environment.NewLine;
                    // 売上/返品(行値引含む)
                    sqlText += "      SUBSALE.SALESNETPRICERF + DISSALESTAXEXCGYO AS SALESNETPRICERF ," + Environment.NewLine;
                    sqlText += "      SUBSALE.ITDEDSALESOUTTAXRF + ITDEDDISSALESOUTTAXGYO AS ITDEDSALESOUTTAXRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.ITDEDSALESINTAXRF + ITDEDDISSALESINTAXGYO AS ITDEDSALESINTAXRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALSUBTTLSUBTOTAXFRERF + ITDEDDISSALESTAXFREGYO AS SALSUBTTLSUBTOTAXFRERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESOUTTAXRF + DISSALESOUTTAXGYO AS SALESOUTTAXRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALAMNTCONSTAXINCLURF + DISSALESTAXFREGYO AS SALAMNTCONSTAXINCLURF," + Environment.NewLine;
                    //sqlText += "      SALESDTL.DISSALESTAXEXCGOODS AS SALESDISTTLTAXEXCRF,-- 税抜値引金額(商品値引)" + Environment.NewLine;
                    //sqlText += "      SALESDTL.ITDEDDISSALESOUTTAXGOODS AS ITDEDSALESDISOUTTAXRF,-- 外税対象額(商品値引)" + Environment.NewLine;
                    //sqlText += "      SALESDTL.ITDEDDISSALESINTAXGOODS AS ITDEDSALESDISINTAXRF, -- 内税対象額(商品値引)" + Environment.NewLine;
                    //sqlText += "      SALESDTL.ITDEDDISSALESTAXFREGOODS AS ITDEDSALESDISTAXFRERF,-- 非課税対象額(商品値引)" + Environment.NewLine;
                    //sqlText += "      SALESDTL.DISSALESOUTTAXGOODS AS SALESDISOUTTAXRF,    -- 外税額(商品値引)" + Environment.NewLine;
                    //sqlText += "      SALESDTL.DISSALESTAXFREGOODS AS SALESDISTTLTAXINCLURF,    -- 内税額(商品値引)" + Environment.NewLine;
                    // 値引(行値引除く)
                    sqlText += "      SUBSALE.SALESDISTTLTAXEXCRF - DISSALESTAXEXCGYO AS SALESDISTTLTAXEXCRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.ITDEDSALESDISOUTTAXRF - ITDEDDISSALESOUTTAXGYO AS ITDEDSALESDISOUTTAXRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.ITDEDSALESDISINTAXRF - ITDEDDISSALESINTAXGYO AS ITDEDSALESDISINTAXRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.ITDEDSALESDISTAXFRERF - ITDEDDISSALESTAXFREGYO AS ITDEDSALESDISTAXFRERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESDISOUTTAXRF - DISSALESOUTTAXGYO AS SALESDISOUTTAXRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESDISTTLTAXINCLURF - DISSALESTAXFREGYO AS SALESDISTTLTAXINCLURF," + Environment.NewLine;
                    sqlText += "      SALESDTL.DTLSALESOUTTAXRF + SALESDTL.DISSALESOUTTAXGYO AS DTLSALESOUTTAXRF, " + Environment.NewLine;
                    sqlText += "      SALESDTL.DTLSALAMNTCONSTAXINCLURF + SALESDTL.DISSALESTAXFREGYO AS DTLSALAMNTCONSTAXINCLURF," + Environment.NewLine;
                    // 修正 2009.03.23 <<<
                    // DEL 2009.03.23 >>>
                    //sqlText += "      SALEDISDTL.DTLSALESDISOUTTAXRF," + Environment.NewLine;
                    //sqlText += "      SALEDISDTL.DTLSALESDISTTLTAXINCLURF," + Environment.NewLine;
                    // DEL 2009.03.23 <<<
                    sqlText += "      TAX.CONSTAXLAYMETHODRF AS TAXCONSTAXLAYMETHODRF," + Environment.NewLine;
                    sqlText += "      TAX.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,   --税率開始日" + Environment.NewLine;
                    sqlText += "      TAX.TAXRATEENDDATERF AS TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine;
                    sqlText += "      TAX.TAXRATERF AS TAXRATERF,                     --税率" + Environment.NewLine;
                    sqlText += "      TAX.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF, --税率開始日2" + Environment.NewLine;
                    sqlText += "      TAX.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,     --税率終了日2" + Environment.NewLine;
                    sqlText += "      TAX.TAXRATE2RF AS TAXRATE2RF,                   --税率2" + Environment.NewLine;
                    sqlText += "      TAX.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF, --税率開始日3" + Environment.NewLine;
                    sqlText += "      TAX.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,     --税率終了日3" + Environment.NewLine;
                    sqlText += "      TAX.TAXRATE3RF AS TAXRATE3RF                    --税率3" + Environment.NewLine;
                    sqlText += "     FROM" + Environment.NewLine;
                    sqlText += "      SALESSLIPRF AS SUBSALE" + Environment.NewLine;
                    */
                    #endregion
                    // DEL 菅原 庸平 2012/04/27 >>>
                    /*
                    sqlText += "  SELECT" + Environment.NewLine;
                    sqlText += "   SALE.CLAIMCODERF AS CLAIMCODERF," + Environment.NewLine;
                    sqlText += "   CLAIM.NAMERF AS CLAIMNAMERF," + Environment.NewLine;
                    sqlText += "   CLAIM.NAME2RF AS CLAIMNAME2RF," + Environment.NewLine;
                    sqlText += "   CLAIM.CUSTOMERSNMRF AS CLAIMSNMRF," + Environment.NewLine;
                    sqlText += "   SALE.CUSTOMERCODERF AS CUSTOMERCODERF," + Environment.NewLine;
                    sqlText += "   CUST.NAMERF AS CUSTOMERNAMERF," + Environment.NewLine;
                    sqlText += "   CUST.NAME2RF AS CUSTOMERNAME2RF," + Environment.NewLine;
                    sqlText += "   CUST.CUSTOMERSNMRF AS CUSTOMERSNMRF," + Environment.NewLine;
                    sqlText += "   SALE.RESULTSADDUPSECCDRF,                              --実績計上拠点" + Environment.NewLine;
                    sqlText += "   CLAIM.CONSTAXLAYMETHODRF AS CONSTAXLAYMETHODRF,        --消費税転嫁方式" + Environment.NewLine;// ADD 2010/12/20
                    sqlText += "   CLAIM.COLLECTCONDRF AS COLLECTCONDRF,                  --回収条件" + Environment.NewLine;
                    sqlText += "   CLAIM.COLLECTMONEYCODERF AS COLLECTMONEYCODERF,        --集金月区分コード" + Environment.NewLine;
                    sqlText += "   CLAIM.COLLECTMONEYDAYRF AS COLLECTMONEYDAYRF,          --集金日" + Environment.NewLine;
                    sqlText += "   CLAIM.SALESCNSTAXFRCPROCCDRF AS SALESCNSTAXFRCPROCCDRF,--売上消費税端数処理コード" + Environment.NewLine;
                    sqlText += "   SALESPROC.FRACTIONPROCCDRF,                            --端数処理単位" + Environment.NewLine;
                    sqlText += "   SALESPROC.FRACTIONPROCUNITRF,                          --端数処理区分" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,         --税率開始日" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATEENDDATERF AS TAXRATEENDDATERF,             --税率終了日" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATERF AS TAXRATERF,                           --税率" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF,       --税率開始日2" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,           --税率終了日2" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATE2RF AS TAXRATE2RF,                         --税率2" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF,       --税率開始日3" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,           --税率終了日3" + Environment.NewLine;
                    sqlText += "   SALE.TAXRATE3RF AS TAXRATE3RF,                         --税率3" + Environment.NewLine;
                    sqlText += "   COUNT(SALE.SALESSLIPNUMRF) SALESSLIPCOUNT,             --伝票枚数" + Environment.NewLine;
                    sqlText += "   -- ■ ■ 売上 ■ ■ " + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS SALESNETPRICERF,              --売上正価金額" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.ITDEDSALESOUTTAXRF ELSE 0 END)) AS ITDEDSALESOUTTAXRF,        --売上外税対象額" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.ITDEDSALESINTAXRF ELSE 0 END)) AS ITDEDSALESINTAXRF,          --売上内税対象額" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALSUBTTLSUBTOTAXFRERF ELSE 0 END)) AS SALSUBTTLSUBTOTAXFRERF,--売上小計非課税対象額" + Environment.NewLine;
                    sqlText += "   -- 伝票転嫁" + Environment.NewLine;
                    sqlText += "   SUM( CASE WHEN SALE.CONSTAXLAYMETHODRF =0 AND SALE.SALESSLIPCDRF =0 THEN SALE.SALESOUTTAXRF ELSE 0 END ) AS SALESOUTTAXRF,--消費税額（外税）伝票" + Environment.NewLine;
                    sqlText += "   -- 明細転嫁" + Environment.NewLine;
                    sqlText += "   SUM(CASE WHEN SALE.CONSTAXLAYMETHODRF = 1 AND SALE.SALESSLIPCDRF =0 THEN SALE.DTLSALESOUTTAXRF ELSE 0 END ) AS DTLSALESOUTTAXRF,--消費税額（外税）明細" + Environment.NewLine;
                    sqlText += "   -- 請求転嫁(子)   " + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)    " + Environment.NewLine;
                    sqlText += "          THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS SALESOUTTAXRF1, --売上金額消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "          THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESOUTTAXRF2,     --売上金額消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "          THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESOUTTAXRF3,     --売上金額消費税額（外税）税率3" + Environment.NewLine;
                    sqlText += "   -- 請求転嫁(親)" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)    " + Environment.NewLine;
                    sqlText += "          THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS SALESOUTTAXRF1_2,--売上金額消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "          THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESOUTTAXRF2_2,     --売上金額消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "          THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESOUTTAXRF3_2,     --売上金額消費税額（外税）税率3       " + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALAMNTCONSTAXINCLURF ELSE 0 END)) AS SALAMNTCONSTAXINCLURF,     --売上金額消費税額（内税）" + Environment.NewLine;
                    sqlText += "   -- ■ ■ 返品 ■ ■ " + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS RETSALESNETPRICERF,              --返品 売上正価金額" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.ITDEDSALESOUTTAXRF ELSE 0 END)) AS RETITDEDSALESOUTTAXRF,        --返品 売上外税対象額" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.ITDEDSALESINTAXRF ELSE 0 END)) AS RETITDEDSALESINTAXRF,          --返品 売上内税対象額" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALSUBTTLSUBTOTAXFRERF ELSE 0 END)) AS RETSALSUBTTLSUBTOTAXFRERF,--返品 売上小計非課税対象額 " + Environment.NewLine;
                    sqlText += "   -- 伝票転嫁" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 0 ) AND (SALE.SALESSLIPCDRF =1) THEN SALE.SALESOUTTAXRF ELSE 0 END)) AS RETSALESOUTTAXRF,     --返品 消費税額（外税）伝票転嫁" + Environment.NewLine;
                    sqlText += "   -- 明細転嫁" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 1) AND (SALE.SALESSLIPCDRF =1) THEN SALE.DTLSALESOUTTAXRF ELSE 0 END)) AS DTLRETSALESOUTTAXRF,--返品 消費税額（外税）明細転嫁" + Environment.NewLine;
                    sqlText += "   -- 請求転嫁(子)" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS RETSALESOUTTAXRF1, --返品 売上金額消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS RETSALESOUTTAXRF2,     --返品 売上金額消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS RETSALESOUTTAXRF3,     --返品 売上金額消費税額（外税）税率3" + Environment.NewLine;
                    sqlText += "   -- 請求転嫁(親)" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS RETSALESOUTTAXRF1_2, --返品 売上金額消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS RETSALESOUTTAXRF2_2,     --返品 売上金額消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS RETSALESOUTTAXRF3_2,     --返品 売上金額消費税額（外税）税率3" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALAMNTCONSTAXINCLURF ELSE 0 END)) AS RETSALAMNTCONSTAXINCLURF,  --返品 売上金額消費税額（内税）      " + Environment.NewLine;
                    sqlText += "   SUM(SALE.SALESDISTTLTAXEXCRF) AS SALESDISTTLTAXEXCRF,    --売上値引金額計（税抜き）" + Environment.NewLine;
                    sqlText += "   SUM(SALE.ITDEDSALESDISOUTTAXRF) AS ITDEDSALESDISOUTTAXRF,--売上値引外税対象額合計" + Environment.NewLine;
                    sqlText += "   SUM(SALE.ITDEDSALESDISINTAXRF) AS ITDEDSALESDISINTAXRF,  --売上値引内税対象額合計 " + Environment.NewLine;
                    sqlText += "   SUM(SALE.ITDEDSALESDISTAXFRERF) AS ITDEDSALESDISTAXFRERF,--売上値引非課税対象額合計" + Environment.NewLine;
                    sqlText += "   -- 伝票転嫁" + Environment.NewLine;
                    sqlText += "   SUM(CASE WHEN (SALE.CONSTAXLAYMETHODRF = 0) THEN SALE.SALESDISOUTTAXRF ELSE 0 END) AS SALESDISOUTTAXRF,    --値引消費税額（外税）伝票転嫁" + Environment.NewLine;
                    sqlText += "   -- 明細転嫁" + Environment.NewLine;
                    sqlText += "   SUM(CASE WHEN (SALE.CONSTAXLAYMETHODRF = 1) THEN SALE.SALESDISOUTTAXRF ELSE 0 END) AS DTLSALESDISOUTTAXRF, --値引消費税額（外税）明細転嫁" + Environment.NewLine;
                    sqlText += "   -- 請求転嫁(子)" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATERF) ELSE 0 END)) AS SALESDISOUTTAXRF1,--売上値引消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESDISOUTTAXRF2,--売上値引消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESDISOUTTAXRF3,--売上値引消費税額（外税）税率3" + Environment.NewLine;
                    sqlText += "   -- 請求転嫁(親)" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATERF) ELSE 0 END)) AS SALESDISOUTTAXRF1_2,--売上値引消費税額（外税）税率1" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESDISOUTTAXRF2_2,--売上値引消費税額（外税）税率2" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine;
                    sqlText += "        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESDISOUTTAXRF3_2,--売上値引消費税額（外税）税率3" + Environment.NewLine;
                    sqlText += "   SUM(SALE.SALESDISTTLTAXINCLURF) AS SALESDISTTLTAXINCLURF --売上値引消費税額（内税）" + Environment.NewLine;
                    sqlText += "  FROM" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    sqlText += "     SELECT" + Environment.NewLine;
                    sqlText += "      SUBSALE.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "      (CASE WHEN (SEARCHCUST.CLAIMCODERF IS NOT NULL) THEN SEARCHCUST.CLAIMCODERF ELSE SUBSALE.CLAIMCODERF END) AS CLAIMCODERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.CONSTAXLAYMETHODRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.CUSTOMERCODERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.RESULTSADDUPSECCDRF, --実績計上拠点" + Environment.NewLine;
                    sqlText += "      SUBSALE.ADDUPADATERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.ACPTANODRSTATUSRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.DEBITNOTEDIVRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESSLIPNUMRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESSLIPCDRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESNETPRICERF + DISSALESTAXEXCGYO AS SALESNETPRICERF ," + Environment.NewLine;
                    sqlText += "      SUBSALE.ITDEDSALESOUTTAXRF + ITDEDDISSALESOUTTAXGYO AS ITDEDSALESOUTTAXRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.ITDEDSALESINTAXRF + ITDEDDISSALESINTAXGYO AS ITDEDSALESINTAXRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALSUBTTLSUBTOTAXFRERF + ITDEDDISSALESTAXFREGYO AS SALSUBTTLSUBTOTAXFRERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESOUTTAXRF + DISSALESOUTTAXGYO AS SALESOUTTAXRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALAMNTCONSTAXINCLURF + DISSALESTAXFREGYO AS SALAMNTCONSTAXINCLURF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESDISTTLTAXEXCRF - DISSALESTAXEXCGYO AS SALESDISTTLTAXEXCRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.ITDEDSALESDISOUTTAXRF - ITDEDDISSALESOUTTAXGYO AS ITDEDSALESDISOUTTAXRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.ITDEDSALESDISINTAXRF - ITDEDDISSALESINTAXGYO AS ITDEDSALESDISINTAXRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.ITDEDSALESDISTAXFRERF - ITDEDDISSALESTAXFREGYO AS ITDEDSALESDISTAXFRERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESDISOUTTAXRF - DISSALESOUTTAXGYO AS SALESDISOUTTAXRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESDISTTLTAXINCLURF - DISSALESTAXFREGYO AS SALESDISTTLTAXINCLURF," + Environment.NewLine;
                    sqlText += "      SALESDTL.DTLSALESOUTTAXRF + SALESDTL.DISSALESOUTTAXGYO AS DTLSALESOUTTAXRF, " + Environment.NewLine;
                    sqlText += "      SALESDTL.DTLSALAMNTCONSTAXINCLURF + SALESDTL.DISSALESTAXFREGYO AS DTLSALAMNTCONSTAXINCLURF," + Environment.NewLine;
                    sqlText += "      TAX.CONSTAXLAYMETHODRF AS TAXCONSTAXLAYMETHODRF," + Environment.NewLine;
                    sqlText += "      TAX.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,   --税率開始日" + Environment.NewLine;
                    sqlText += "      TAX.TAXRATEENDDATERF AS TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine;
                    sqlText += "      TAX.TAXRATERF AS TAXRATERF,                     --税率" + Environment.NewLine;
                    sqlText += "      TAX.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF, --税率開始日2" + Environment.NewLine;
                    sqlText += "      TAX.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,     --税率終了日2" + Environment.NewLine;
                    sqlText += "      TAX.TAXRATE2RF AS TAXRATE2RF,                   --税率2" + Environment.NewLine;
                    sqlText += "      TAX.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF, --税率開始日3" + Environment.NewLine;
                    sqlText += "      TAX.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,     --税率終了日3" + Environment.NewLine;
                    sqlText += "      TAX.TAXRATE3RF AS TAXRATE3RF                    --税率3" + Environment.NewLine;
                    sqlText += "     FROM" + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ---------->>>>>
                    //sqlText += "      SALESSLIPRF AS SUBSALE" + Environment.NewLine;
                    sqlText += "      SALESSLIPRF AS SUBSALE WITH(READUNCOMMITTED) " + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ----------<<<<<
                    */
                    // DEL 菅原 庸平 2012/04/27 <<<
                    // ADD 菅原 庸平  2012/04/27 >>>
                    sqlText.Append("  SELECT" + Environment.NewLine);
                    sqlText.Append("   SALE.CLAIMCODERF AS CLAIMCODERF," + Environment.NewLine);
                    sqlText.Append("   CLAIM.NAMERF AS CLAIMNAMERF," + Environment.NewLine);
                    sqlText.Append("   CLAIM.NAME2RF AS CLAIMNAME2RF," + Environment.NewLine);
                    sqlText.Append("   CLAIM.CUSTOMERSNMRF AS CLAIMSNMRF," + Environment.NewLine);
                    sqlText.Append("   SALE.CUSTOMERCODERF AS CUSTOMERCODERF," + Environment.NewLine);
                    sqlText.Append("   CUST.NAMERF AS CUSTOMERNAMERF," + Environment.NewLine);
                    sqlText.Append("   CUST.NAME2RF AS CUSTOMERNAME2RF," + Environment.NewLine);
                    sqlText.Append("   CUST.CUSTOMERSNMRF AS CUSTOMERSNMRF," + Environment.NewLine);
                    sqlText.Append("   SALE.RESULTSADDUPSECCDRF,                              --実績計上拠点" + Environment.NewLine);
                    sqlText.Append("   CLAIM.CONSTAXLAYMETHODRF AS CONSTAXLAYMETHODRF,        --消費税転嫁方式" + Environment.NewLine);// ADD 2010/12/20
                    sqlText.Append("   CLAIM.COLLECTCONDRF AS COLLECTCONDRF,                  --回収条件" + Environment.NewLine);
                    sqlText.Append("   CLAIM.COLLECTMONEYCODERF AS COLLECTMONEYCODERF,        --集金月区分コード" + Environment.NewLine);
                    sqlText.Append("   CLAIM.COLLECTMONEYDAYRF AS COLLECTMONEYDAYRF,          --集金日" + Environment.NewLine);
                    sqlText.Append("   CLAIM.SALESCNSTAXFRCPROCCDRF AS SALESCNSTAXFRCPROCCDRF,--売上消費税端数処理コード" + Environment.NewLine);
                    sqlText.Append("   SALESPROC.FRACTIONPROCCDRF,                            --端数処理単位" + Environment.NewLine);
                    sqlText.Append("   SALESPROC.FRACTIONPROCUNITRF,                          --端数処理区分" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,         --税率開始日" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATEENDDATERF AS TAXRATEENDDATERF,             --税率終了日" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATERF AS TAXRATERF,                           --税率" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF,       --税率開始日2" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,           --税率終了日2" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATE2RF AS TAXRATE2RF,                         --税率2" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF,       --税率開始日3" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,           --税率終了日3" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATE3RF AS TAXRATE3RF,                         --税率3" + Environment.NewLine);
                    sqlText.Append("   COUNT(SALE.SALESSLIPNUMRF) SALESSLIPCOUNT,             --伝票枚数" + Environment.NewLine);
                    sqlText.Append("   -- ■ ■ 売上 ■ ■ " + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS SALESNETPRICERF,              --売上正価金額" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.ITDEDSALESOUTTAXRF ELSE 0 END)) AS ITDEDSALESOUTTAXRF,        --売上外税対象額" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.ITDEDSALESINTAXRF ELSE 0 END)) AS ITDEDSALESINTAXRF,          --売上内税対象額" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALSUBTTLSUBTOTAXFRERF ELSE 0 END)) AS SALSUBTTLSUBTOTAXFRERF,--売上小計非課税対象額" + Environment.NewLine);
                    sqlText.Append("   -- 伝票転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM( CASE WHEN SALE.CONSTAXLAYMETHODRF =0 AND SALE.SALESSLIPCDRF =0 THEN SALE.SALESOUTTAXRF ELSE 0 END ) AS SALESOUTTAXRF,--消費税額（外税）伝票" + Environment.NewLine);
                    sqlText.Append("   -- 明細転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM(CASE WHEN SALE.CONSTAXLAYMETHODRF = 1 AND SALE.SALESSLIPCDRF =0 THEN SALE.DTLSALESOUTTAXRF ELSE 0 END ) AS DTLSALESOUTTAXRF,--消費税額（外税）明細" + Environment.NewLine);
                    sqlText.Append("   -- 請求転嫁(子)   " + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)    " + Environment.NewLine);
                    //sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS SALESOUTTAXRF1, --売上金額消費税額（外税）税率1" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    //sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESOUTTAXRF2,     --売上金額消費税額（外税）税率2" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    //sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESOUTTAXRF3,     --売上金額消費税額（外税）税率3" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)    " + Environment.NewLine);
                    sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF1, --売上金額消費税額（外税）税率1" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF2,     --売上金額消費税額（外税）税率2" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF3,     --売上金額消費税額（外税）税率3" + Environment.NewLine);
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    sqlText.Append("   -- 請求転嫁(親)" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)    " + Environment.NewLine);
                    //sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS SALESOUTTAXRF1_2,--売上金額消費税額（外税）税率1" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    //sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESOUTTAXRF2_2,     --売上金額消費税額（外税）税率2" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    //sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESOUTTAXRF3_2,     --売上金額消費税額（外税）税率3       " + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)    " + Environment.NewLine);
                    sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF1_2,--売上金額消費税額（外税）税率1" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF2_2,     --売上金額消費税額（外税）税率2" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF3_2,     --売上金額消費税額（外税）税率3       " + Environment.NewLine);
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALAMNTCONSTAXINCLURF ELSE 0 END)) AS SALAMNTCONSTAXINCLURF,     --売上金額消費税額（内税）" + Environment.NewLine);
                    sqlText.Append("   -- ■ ■ 返品 ■ ■ " + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS RETSALESNETPRICERF,              --返品 売上正価金額" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.ITDEDSALESOUTTAXRF ELSE 0 END)) AS RETITDEDSALESOUTTAXRF,        --返品 売上外税対象額" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.ITDEDSALESINTAXRF ELSE 0 END)) AS RETITDEDSALESINTAXRF,          --返品 売上内税対象額" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALSUBTTLSUBTOTAXFRERF ELSE 0 END)) AS RETSALSUBTTLSUBTOTAXFRERF,--返品 売上小計非課税対象額 " + Environment.NewLine);
                    sqlText.Append("   -- 伝票転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 0 ) AND (SALE.SALESSLIPCDRF =1) THEN SALE.SALESOUTTAXRF ELSE 0 END)) AS RETSALESOUTTAXRF,     --返品 消費税額（外税）伝票転嫁" + Environment.NewLine);
                    sqlText.Append("   -- 明細転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 1) AND (SALE.SALESSLIPCDRF =1) THEN SALE.DTLSALESOUTTAXRF ELSE 0 END)) AS DTLRETSALESOUTTAXRF,--返品 消費税額（外税）明細転嫁" + Environment.NewLine);
                    sqlText.Append("   -- 請求転嫁(子)" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS RETSALESOUTTAXRF1, --返品 売上金額消費税額（外税）税率1" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS RETSALESOUTTAXRF2,     --返品 売上金額消費税額（外税）税率2" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS RETSALESOUTTAXRF3,     --返品 売上金額消費税額（外税）税率3" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF1, --返品 売上金額消費税額（外税）税率1" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF2,     --返品 売上金額消費税額（外税）税率2" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF3,     --返品 売上金額消費税額（外税）税率3" + Environment.NewLine);
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    sqlText.Append("   -- 請求転嫁(親)" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS RETSALESOUTTAXRF1_2, --返品 売上金額消費税額（外税）税率1" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS RETSALESOUTTAXRF2_2,     --返品 売上金額消費税額（外税）税率2" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS RETSALESOUTTAXRF3_2,     --返品 売上金額消費税額（外税）税率3" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF1_2, --返品 売上金額消費税額（外税）税率1" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF2_2,     --返品 売上金額消費税額（外税）税率2" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF3_2,     --返品 売上金額消費税額（外税）税率3" + Environment.NewLine);
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALAMNTCONSTAXINCLURF ELSE 0 END)) AS RETSALAMNTCONSTAXINCLURF,  --返品 売上金額消費税額（内税）      " + Environment.NewLine);
                    sqlText.Append("   SUM(SALE.SALESDISTTLTAXEXCRF) AS SALESDISTTLTAXEXCRF,    --売上値引金額計（税抜き）" + Environment.NewLine);
                    sqlText.Append("   SUM(SALE.ITDEDSALESDISOUTTAXRF) AS ITDEDSALESDISOUTTAXRF,--売上値引外税対象額合計" + Environment.NewLine);
                    sqlText.Append("   SUM(SALE.ITDEDSALESDISINTAXRF) AS ITDEDSALESDISINTAXRF,  --売上値引内税対象額合計 " + Environment.NewLine);
                    sqlText.Append("   SUM(SALE.ITDEDSALESDISTAXFRERF) AS ITDEDSALESDISTAXFRERF,--売上値引非課税対象額合計" + Environment.NewLine);
                    sqlText.Append("   -- 伝票転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM(CASE WHEN (SALE.CONSTAXLAYMETHODRF = 0) THEN SALE.SALESDISOUTTAXRF ELSE 0 END) AS SALESDISOUTTAXRF,    --値引消費税額（外税）伝票転嫁" + Environment.NewLine);
                    sqlText.Append("   -- 明細転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM(CASE WHEN (SALE.CONSTAXLAYMETHODRF = 1) THEN SALE.SALESDISOUTTAXRF ELSE 0 END) AS DTLSALESDISOUTTAXRF, --値引消費税額（外税）明細転嫁" + Environment.NewLine);
                    sqlText.Append("   -- 請求転嫁(子)" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATERF) ELSE 0 END)) AS SALESDISOUTTAXRF1,--売上値引消費税額（外税）税率1" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESDISOUTTAXRF2,--売上値引消費税額（外税）税率2" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESDISOUTTAXRF3,--売上値引消費税額（外税）税率3" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF1,--売上値引消費税額（外税）税率1" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF2,--売上値引消費税額（外税）税率2" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF3,--売上値引消費税額（外税）税率3" + Environment.NewLine);
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    sqlText.Append("   -- 請求転嫁(親)" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATERF) ELSE 0 END)) AS SALESDISOUTTAXRF1_2,--売上値引消費税額（外税）税率1" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESDISOUTTAXRF2_2,--売上値引消費税額（外税）税率2" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESDISOUTTAXRF3_2,--売上値引消費税額（外税）税率3" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF1_2,--売上値引消費税額（外税）税率1" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF2_2,--売上値引消費税額（外税）税率2" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF3_2,--売上値引消費税額（外税）税率3" + Environment.NewLine);
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    sqlText.Append("   SUM(SALE.SALESDISTTLTAXINCLURF) AS SALESDISTTLTAXINCLURF --売上値引消費税額（内税）" + Environment.NewLine);
                    sqlText.Append("  FROM" + Environment.NewLine);
                    sqlText.Append("  (" + Environment.NewLine);
                    sqlText.Append("     SELECT" + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ENTERPRISECODERF," + Environment.NewLine);
                    sqlText.Append("      (CASE WHEN (SEARCHCUST.CLAIMCODERF IS NOT NULL) THEN SEARCHCUST.CLAIMCODERF ELSE SUBSALE.CLAIMCODERF END) AS CLAIMCODERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.CONSTAXLAYMETHODRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.CUSTOMERCODERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.RESULTSADDUPSECCDRF, --実績計上拠点" + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ADDUPADATERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.LOGICALDELETECODERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ACPTANODRSTATUSRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.DEBITNOTEDIVRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESSLIPNUMRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESSLIPCDRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESNETPRICERF + DISSALESTAXEXCGYO AS SALESNETPRICERF ," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ITDEDSALESOUTTAXRF + ITDEDDISSALESOUTTAXGYO AS ITDEDSALESOUTTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ITDEDSALESINTAXRF + ITDEDDISSALESINTAXGYO AS ITDEDSALESINTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALSUBTTLSUBTOTAXFRERF + ITDEDDISSALESTAXFREGYO AS SALSUBTTLSUBTOTAXFRERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESOUTTAXRF + DISSALESOUTTAXGYO AS SALESOUTTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALAMNTCONSTAXINCLURF + DISSALESTAXFREGYO AS SALAMNTCONSTAXINCLURF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESDISTTLTAXEXCRF - DISSALESTAXEXCGYO AS SALESDISTTLTAXEXCRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ITDEDSALESDISOUTTAXRF - ITDEDDISSALESOUTTAXGYO AS ITDEDSALESDISOUTTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ITDEDSALESDISINTAXRF - ITDEDDISSALESINTAXGYO AS ITDEDSALESDISINTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ITDEDSALESDISTAXFRERF - ITDEDDISSALESTAXFREGYO AS ITDEDSALESDISTAXFRERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESDISOUTTAXRF - DISSALESOUTTAXGYO AS SALESDISOUTTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESDISTTLTAXINCLURF - DISSALESTAXFREGYO AS SALESDISTTLTAXINCLURF," + Environment.NewLine);
                    sqlText.Append("      SALESDTL.DTLSALESOUTTAXRF + SALESDTL.DISSALESOUTTAXGYO AS DTLSALESOUTTAXRF, " + Environment.NewLine);
                    sqlText.Append("      SALESDTL.DTLSALAMNTCONSTAXINCLURF + SALESDTL.DISSALESTAXFREGYO AS DTLSALAMNTCONSTAXINCLURF," + Environment.NewLine);
                    sqlText.Append("      TAX.CONSTAXLAYMETHODRF AS TAXCONSTAXLAYMETHODRF," + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,   --税率開始日" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATEENDDATERF AS TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATERF AS TAXRATERF,                     --税率" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF, --税率開始日2" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,     --税率終了日2" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATE2RF AS TAXRATE2RF,                   --税率2" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF, --税率開始日3" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,     --税率終了日3" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATE3RF AS TAXRATE3RF                    --税率3" + Environment.NewLine);
                    sqlText.Append("     FROM" + Environment.NewLine);
                    sqlText.Append("      SALESSLIPRF AS SUBSALE WITH(READUNCOMMITTED) " + Environment.NewLine);
                    // ADD 菅原 庸平  2012/04/27 <<<

                    #region SUBクエリ JOIN
                    // DEL 菅原 庸平 2012/04/27 >>>
                    /*
                    // --- UPD T.Nishi 2012/02/15 ---------->>>>>
                    //sqlText += "    LEFT JOIN TAXRATESETRF AS TAX" + Environment.NewLine;
                    sqlText += "    LEFT JOIN TAXRATESETRF AS TAX WITH(READUNCOMMITTED) " + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ----------<<<<<
                    sqlText += "     ON SUBSALE.ENTERPRISECODERF = TAX.ENTERPRISECODERF " + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ---------->>>>>
                    //sqlText += "    LEFT JOIN CUSTOMERRF AS SEARCHCUST " + Environment.NewLine;
                    sqlText += "    LEFT JOIN CUSTOMERRF AS SEARCHCUST WITH(READUNCOMMITTED) " + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ----------<<<<<
                    sqlText += "     ON  SUBSALE.ENTERPRISECODERF = SEARCHCUST.ENTERPRISECODERF " + Environment.NewLine;
                    sqlText += "     AND SUBSALE.CUSTOMERCODERF = SEARCHCUST.CUSTOMERCODERF " + Environment.NewLine;
                    // ADD 2009.03.23 >>>
                    sqlText += "    LEFT JOIN" + Environment.NewLine;
                    sqlText += "    (" + Environment.NewLine;
                    sqlText += "      SELECT" + Environment.NewLine;
                    sqlText += "       SALES.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "       SALES.ACPTANODRSTATUSRF," + Environment.NewLine;
                    sqlText += "       SALES.SALESSLIPNUMRF," + Environment.NewLine;
                    sqlText += "       SALES.SALESSLIPCDRF," + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN ((SALES.SALESSLIPCDRF = 0 OR SALES.SALESSLIPCDRF =1 ) AND DTL.SALESSLIPCDDTLRF != 2 AND DTL.TAXATIONDIVCDRF = 2) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALAMNTCONSTAXINCLURF,-- 明細内税消費税金額" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN ((SALES.SALESSLIPCDRF = 0 OR SALES.SALESSLIPCDRF =1 ) AND DTL.SALESSLIPCDDTLRF != 2 AND DTL.TAXATIONDIVCDRF = 0) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALESOUTTAXRF, -- 明細外税消費税金額" + Environment.NewLine;
                    sqlText += "       --行値引" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISSALESTAXEXCGYO,-- 税抜値引金額(行値引)" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESOUTTAXGYO,-- 外税対象額(行値引)" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 1) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESTAXFREGYO, -- 非課税対象額(行値引)" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESINTAXGYO,-- 内税対象額(行値引)       " + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESOUTTAXGYO,    -- 外税額(行値引)" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESTAXFREGYO    -- 内税額(行値引)       " + Environment.NewLine;
                    //sqlText += "       --商品値引" + Environment.NewLine;
                    //sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF !=0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISSALESTAXEXCGOODS,-- 税抜値引金額(商品値引)" + Environment.NewLine;
                    //sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF !=0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESOUTTAXGOODS,-- 外税対象額(商品値引)" + Environment.NewLine;
                    //sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF !=0  AND DTL.TAXATIONDIVCDRF  = 1) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESTAXFREGOODS, -- 非課税対象額(商品値引)" + Environment.NewLine;
                    //sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF !=0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESINTAXGOODS,-- 内税対象額(商品値引)" + Environment.NewLine;
                    //sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF !=0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESOUTTAXGOODS,    -- 外税額(商品値引)" + Environment.NewLine;
                    //sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF !=0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESTAXFREGOODS     -- 内税額(商品値引)" + Environment.NewLine;
                    sqlText += "      FROM" + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ---------->>>>>
                    //sqlText += "       SALESDETAILRF AS DTL" + Environment.NewLine;
                    //sqlText += "      LEFT JOIN SALESSLIPRF AS SALES" + Environment.NewLine;
                    sqlText += "       SALESDETAILRF AS DTL WITH(READUNCOMMITTED) " + Environment.NewLine;
                    sqlText += "      LEFT JOIN SALESSLIPRF AS SALES WITH(READUNCOMMITTED) " + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ----------<<<<<
                    sqlText += "       ON  SALES.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "       AND SALES.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "       AND SALES.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += "      GROUP BY" + Environment.NewLine;
                    sqlText += "       SALES.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "       SALES.ACPTANODRSTATUSRF," + Environment.NewLine;
                    sqlText += "       SALES.SALESSLIPNUMRF," + Environment.NewLine;
                    sqlText += "       SALES.SALESSLIPCDRF" + Environment.NewLine;
                    sqlText += "    ) AS SALESDTL" + Environment.NewLine;
                    sqlText += "     ON  SUBSALE.ENTERPRISECODERF = SALESDTL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "     AND SUBSALE.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "     AND SUBSALE.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF" + Environment.NewLine;
                    // ADD 2009.03.23 <<<
                    */
                    // DEL 菅原 庸平 2012/04/27 <<<

                    #region DEL 2009.03.23
                    /*
                    // ADD 2009.01.20 >>>
                    sqlText += "    LEFT JOIN  -- 売上・返品の明細転嫁消費税" + Environment.NewLine;
                    sqlText += "      (" + Environment.NewLine;
                    sqlText += "       SELECT" + Environment.NewLine;
                    sqlText += "        ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "        SALESSLIPNUMRF, --伝票番号" + Environment.NewLine;
                    sqlText += "        SALESSLIPCDDTLRF, -- 伝票区分" + Environment.NewLine;
                    sqlText += "        ACPTANODRSTATUSRF, -- 受注ステータス        " + Environment.NewLine;
                    sqlText += "        SUM(CASE WHEN TAXATIONDIVCDRF = 2 THEN SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALAMNTCONSTAXINCLURF,-- 明細内税消費税金額" + Environment.NewLine;
                    sqlText += "        SUM(CASE WHEN TAXATIONDIVCDRF = 0 THEN SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALESOUTTAXRF -- 明細外税消費税金額" + Environment.NewLine;
                    sqlText += "       FROM" + Environment.NewLine;
                    sqlText += "        SALESDETAILRF AS SUBSALESDTL" + Environment.NewLine;
                    sqlText += "       WHERE" + Environment.NewLine;
                    sqlText += "        SALESSLIPCDDTLRF = 0 -- 売上" + Environment.NewLine;
                    sqlText += "        OR SALESSLIPCDDTLRF = 1 -- 返品        " + Environment.NewLine;
                    sqlText += "       GROUP BY" + Environment.NewLine;
                    sqlText += "        ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "        SALESSLIPNUMRF, --伝票番号" + Environment.NewLine;
                    sqlText += "        SALESSLIPCDDTLRF, -- 伝票区分" + Environment.NewLine;
                    sqlText += "        ACPTANODRSTATUSRF -- 受注ステータス        " + Environment.NewLine;
                    sqlText += "      ) AS SALEDTL" + Environment.NewLine;
                    sqlText += "     ON  SUBSALE.ENTERPRISECODERF = SALEDTL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "     AND SUBSALE.ACPTANODRSTATUSRF = SALEDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "     AND SUBSALE.SALESSLIPNUMRF = SALEDTL.SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += "    LEFT JOIN -- 値引の明細転嫁消費税" + Environment.NewLine;
                    sqlText += "      (" + Environment.NewLine;
                    sqlText += "       SELECT" + Environment.NewLine;
                    sqlText += "        ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "        SALESSLIPNUMRF, --伝票番号" + Environment.NewLine;
                    sqlText += "        ACPTANODRSTATUSRF, -- 受注ステータス        " + Environment.NewLine;
                    sqlText += "        SUM(CASE WHEN TAXATIONDIVCDRF = 2 THEN SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALESDISTTLTAXINCLURF,-- 明細内税消費税金額" + Environment.NewLine;
                    sqlText += "        SUM(CASE WHEN TAXATIONDIVCDRF = 0 THEN SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALESDISOUTTAXRF -- 明細外税消費税金額" + Environment.NewLine;
                    sqlText += "       FROM" + Environment.NewLine;
                    sqlText += "        SALESDETAILRF AS SUBSALESDTL" + Environment.NewLine;
                    sqlText += "       WHERE" + Environment.NewLine;
                    sqlText += "        SALESSLIPCDDTLRF = 2 -- 値引" + Environment.NewLine;
                    sqlText += "       GROUP BY" + Environment.NewLine;
                    sqlText += "        ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "        SALESSLIPNUMRF, --伝票番号" + Environment.NewLine;
                    sqlText += "        ACPTANODRSTATUSRF -- 受注ステータス        " + Environment.NewLine;
                    sqlText += "      ) AS SALEDISDTL" + Environment.NewLine;
                    sqlText += "     ON  SUBSALE.ENTERPRISECODERF = SALEDISDTL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "     AND SUBSALE.ACPTANODRSTATUSRF = SALEDISDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "     AND SUBSALE.SALESSLIPNUMRF = SALEDISDTL.SALESSLIPNUMRF" + Environment.NewLine;
                    // ADD 2009.01.20 <<<
                    */
                    #endregion 

                    //sqlText += "  ) AS SALE" + Environment.NewLine; // DEL 菅原 庸平  2012/04/27
                    // ADD 菅原 庸平  2012/04/27 >>>
                    sqlText.Append("    LEFT JOIN TAXRATESETRF AS TAX WITH(READUNCOMMITTED) " + Environment.NewLine);
                    sqlText.Append("     ON SUBSALE.ENTERPRISECODERF = TAX.ENTERPRISECODERF " + Environment.NewLine);
                    sqlText.Append("    LEFT JOIN CUSTOMERRF AS SEARCHCUST WITH(READUNCOMMITTED) " + Environment.NewLine);
                    sqlText.Append("     ON  SUBSALE.ENTERPRISECODERF = SEARCHCUST.ENTERPRISECODERF " + Environment.NewLine);
                    sqlText.Append("     AND SUBSALE.CUSTOMERCODERF = SEARCHCUST.CUSTOMERCODERF " + Environment.NewLine);
                    sqlText.Append("    LEFT JOIN" + Environment.NewLine);
                    sqlText.Append("    (" + Environment.NewLine);
                    sqlText.Append("      SELECT" + Environment.NewLine);
                    sqlText.Append("       SALES.ENTERPRISECODERF," + Environment.NewLine);
                    sqlText.Append("       SALES.ACPTANODRSTATUSRF," + Environment.NewLine);
                    sqlText.Append("       SALES.SALESSLIPNUMRF," + Environment.NewLine);
                    sqlText.Append("       SALES.SALESSLIPCDRF," + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN ((SALES.SALESSLIPCDRF = 0 OR SALES.SALESSLIPCDRF =1 ) AND DTL.SALESSLIPCDDTLRF != 2 AND DTL.TAXATIONDIVCDRF = 2) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALAMNTCONSTAXINCLURF,-- 明細内税消費税金額" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN ((SALES.SALESSLIPCDRF = 0 OR SALES.SALESSLIPCDRF =1 ) AND DTL.SALESSLIPCDDTLRF != 2 AND DTL.TAXATIONDIVCDRF = 0) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALESOUTTAXRF, -- 明細外税消費税金額" + Environment.NewLine);
                    sqlText.Append("       --行値引" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISSALESTAXEXCGYO,-- 税抜値引金額(行値引)" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESOUTTAXGYO,-- 外税対象額(行値引)" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 1) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESTAXFREGYO, -- 非課税対象額(行値引)" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESINTAXGYO,-- 内税対象額(行値引)       " + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESOUTTAXGYO,    -- 外税額(行値引)" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESTAXFREGYO    -- 内税額(行値引)       " + Environment.NewLine);
                    sqlText.Append("      FROM" + Environment.NewLine);
                    sqlText.Append("       SALESDETAILRF AS DTL WITH(READUNCOMMITTED) " + Environment.NewLine);
                    sqlText.Append("      LEFT JOIN SALESSLIPRF AS SALES WITH(READUNCOMMITTED) " + Environment.NewLine);
                    sqlText.Append("       ON  SALES.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append("       AND SALES.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine);
                    sqlText.Append("       AND SALES.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF" + Environment.NewLine);
                    sqlText.Append("      GROUP BY" + Environment.NewLine);
                    sqlText.Append("       SALES.ENTERPRISECODERF," + Environment.NewLine);
                    sqlText.Append("       SALES.ACPTANODRSTATUSRF," + Environment.NewLine);
                    sqlText.Append("       SALES.SALESSLIPNUMRF," + Environment.NewLine);
                    sqlText.Append("       SALES.SALESSLIPCDRF" + Environment.NewLine);
                    sqlText.Append("    ) AS SALESDTL" + Environment.NewLine);
                    sqlText.Append("     ON  SUBSALE.ENTERPRISECODERF = SALESDTL.ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append("     AND SUBSALE.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine);
                    sqlText.Append("     AND SUBSALE.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF" + Environment.NewLine);
                    sqlText.Append("  ) AS SALE" + Environment.NewLine);
                    // ADD 菅原 庸平  2012/04/27 <<<
                    #endregion

                    #endregion

                    #region JOIN
                    // DEL 菅原 庸平 2012/04/27 >>>
                    /*
                    // --- UPD T.Nishi 2012/02/15 ---------->>>>>
                    //sqlText += "LEFT JOIN CUSTOMERRF AS CUST" + Environment.NewLine;
                    sqlText += "LEFT JOIN CUSTOMERRF AS CUST WITH(READUNCOMMITTED) " + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ----------<<<<<
                    sqlText += " ON SALE.ENTERPRISECODERF = CUST.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND SALE.CUSTOMERCODERF = CUST.CUSTOMERCODERF" + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ---------->>>>>
                    //sqlText += "LEFT JOIN CUSTOMERRF AS CLAIM" + Environment.NewLine;
                    sqlText += "LEFT JOIN CUSTOMERRF AS CLAIM WITH(READUNCOMMITTED) " + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ----------<<<<<
                    sqlText += " ON SALE.ENTERPRISECODERF = CLAIM.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND SALE.CLAIMCODERF = CLAIM.CUSTOMERCODERF" + Environment.NewLine;
                    // 売上金額処理区分設定マスタ
                    sqlText += "LEFT JOIN SALESPROCMONEYRF AS SALESPROC WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON  CLAIM.ENTERPRISECODERF=SALESPROC.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND SALESPROC.FRACPROCMONEYDIVRF=1" + Environment.NewLine;
                    sqlText += " AND CLAIM.SALESCNSTAXFRCPROCCDRF=SALESPROC.FRACTIONPROCCODERF" + Environment.NewLine;
                    */
                    // DEL 菅原 庸平 2012/04/27 <<<
                    // ADD 菅原 庸平  2012/04/27 >>>
                    sqlText.Append("LEFT JOIN CUSTOMERRF AS CUST WITH(READUNCOMMITTED) " + Environment.NewLine);
                    sqlText.Append(" ON SALE.ENTERPRISECODERF = CUST.ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append(" AND SALE.CUSTOMERCODERF = CUST.CUSTOMERCODERF" + Environment.NewLine);
                    sqlText.Append("LEFT JOIN CUSTOMERRF AS CLAIM WITH(READUNCOMMITTED) " + Environment.NewLine);
                    sqlText.Append(" ON SALE.ENTERPRISECODERF = CLAIM.ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append(" AND SALE.CLAIMCODERF = CLAIM.CUSTOMERCODERF" + Environment.NewLine);
                    // 売上金額処理区分設定マスタ
                    sqlText.Append("LEFT JOIN SALESPROCMONEYRF AS SALESPROC WITH(READUNCOMMITTED)" + Environment.NewLine);
                    sqlText.Append(" ON  CLAIM.ENTERPRISECODERF=SALESPROC.ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append(" AND SALESPROC.FRACPROCMONEYDIVRF=1" + Environment.NewLine);
                    sqlText.Append(" AND CLAIM.SALESCNSTAXFRCPROCCDRF=SALESPROC.FRACTIONPROCCODERF" + Environment.NewLine);
                    // ADD 菅原 庸平  2012/04/27 <<<
                    #endregion

                    #region WHERE句
                    // DEL 菅原 庸平 2012/04/27 >>>
                    /*
                    sqlText += " WHERE SALE.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "   AND SALE.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                    //sqlText += "   AND SALE.DEMANDADDUPSECCDRF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "   AND(SALE.ADDUPADATERF<=@FINDADDUPDATE AND SALE.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                    sqlText += "   AND SALE.LOGICALDELETECODERF=0" + Environment.NewLine;
                    sqlText += "   AND SALE.ACPTANODRSTATUSRF=30" + Environment.NewLine;
                    sqlText += "   AND SALE.DEBITNOTEDIVRF=0" + Environment.NewLine;
                    */
                    // DEL 菅原 庸平 2012/04/27 <<<
                    // ADD 菅原 庸平  2012/04/27 >>>
                    sqlText.Append(" WHERE SALE.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                    sqlText.Append("   AND SALE.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine);
                    sqlText.Append("   AND(SALE.ADDUPADATERF<=@FINDADDUPDATE AND SALE.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine);
                    sqlText.Append("   AND SALE.LOGICALDELETECODERF=0" + Environment.NewLine);
                    sqlText.Append("   AND SALE.ACPTANODRSTATUSRF=30" + Environment.NewLine);
                    sqlText.Append("   AND SALE.DEBITNOTEDIVRF=0" + Environment.NewLine);
                    // ADD 菅原 庸平  2012/04/27 <<<
                    #endregion

                    #region GROUP BY句
                    // DEL 菅原 庸平 2012/04/27 >>>
                    /*
                    sqlText += "GROUP BY " + Environment.NewLine;
                    sqlText += " SALE.CLAIMCODERF," + Environment.NewLine;
                    sqlText += " CLAIM.NAMERF," + Environment.NewLine;
                    sqlText += " CLAIM.NAME2RF," + Environment.NewLine;
                    sqlText += " CLAIM.CUSTOMERSNMRF," + Environment.NewLine;
                    sqlText += " SALE.CUSTOMERCODERF," + Environment.NewLine;
                    sqlText += " CUST.NAMERF," + Environment.NewLine;
                    sqlText += " CUST.NAME2RF," + Environment.NewLine;
                    sqlText += " CUST.CUSTOMERSNMRF," + Environment.NewLine;
                    sqlText += " SALE.RESULTSADDUPSECCDRF," + Environment.NewLine;
                    sqlText += " CLAIM.CONSTAXLAYMETHODRF,     --消費税転嫁方式" + Environment.NewLine;
                    sqlText += " CLAIM.COLLECTCONDRF,          --回収条件" + Environment.NewLine;
                    sqlText += " CLAIM.COLLECTMONEYCODERF,     --集金月区分コード" + Environment.NewLine;
                    sqlText += " CLAIM.COLLECTMONEYDAYRF,      --集金日" + Environment.NewLine;
                    sqlText += " CLAIM.SALESCNSTAXFRCPROCCDRF, --売上消費税端数処理コード" + Environment.NewLine;
                    sqlText += " CLAIM.CUSTCTAXLAYREFCDRF," + Environment.NewLine;
                    sqlText += " SALESPROC.FRACTIONPROCCDRF,   --端数処理単位" + Environment.NewLine;
                    sqlText += " SALESPROC.FRACTIONPROCUNITRF, --端数処理区分" + Environment.NewLine;
                    sqlText += " SALE.TAXRATESTARTDATERF,      --税率開始日" + Environment.NewLine;
                    sqlText += " SALE.TAXRATEENDDATERF,        --税率終了日" + Environment.NewLine;
                    sqlText += " SALE.TAXRATERF,               --税率" + Environment.NewLine;
                    sqlText += " SALE.TAXRATESTARTDATE2RF,     --税率開始日2" + Environment.NewLine;
                    sqlText += " SALE.TAXRATEENDDATE2RF,       --税率終了日2" + Environment.NewLine;
                    sqlText += " SALE.TAXRATE2RF,              --税率2" + Environment.NewLine;
                    sqlText += " SALE.TAXRATESTARTDATE3RF,     --税率開始日3" + Environment.NewLine;
                    sqlText += " SALE.TAXRATEENDDATE3RF,       --税率終了日3" + Environment.NewLine;
                    sqlText += " SALE.TAXRATE3RF,              --税率3" + Environment.NewLine;
                    sqlText += " SALE.TAXCONSTAXLAYMETHODRF" + Environment.NewLine;
                    sqlText += ") AS DMDPRC" + Environment.NewLine;
                    */
                    // DEL 菅原 庸平 2012/04/27 <<<
                    // ADD 菅原 庸平  2012/04/27 >>>
                    sqlText.Append("GROUP BY " + Environment.NewLine);
                    sqlText.Append(" SALE.CLAIMCODERF," + Environment.NewLine);
                    sqlText.Append(" CLAIM.NAMERF," + Environment.NewLine);
                    sqlText.Append(" CLAIM.NAME2RF," + Environment.NewLine);
                    sqlText.Append(" CLAIM.CUSTOMERSNMRF," + Environment.NewLine);
                    sqlText.Append(" SALE.CUSTOMERCODERF," + Environment.NewLine);
                    sqlText.Append(" CUST.NAMERF," + Environment.NewLine);
                    sqlText.Append(" CUST.NAME2RF," + Environment.NewLine);
                    sqlText.Append(" CUST.CUSTOMERSNMRF," + Environment.NewLine);
                    sqlText.Append(" SALE.RESULTSADDUPSECCDRF," + Environment.NewLine);
                    sqlText.Append(" CLAIM.CONSTAXLAYMETHODRF,     --消費税転嫁方式" + Environment.NewLine);
                    sqlText.Append(" CLAIM.COLLECTCONDRF,          --回収条件" + Environment.NewLine);
                    sqlText.Append(" CLAIM.COLLECTMONEYCODERF,     --集金月区分コード" + Environment.NewLine);
                    sqlText.Append(" CLAIM.COLLECTMONEYDAYRF,      --集金日" + Environment.NewLine);
                    sqlText.Append(" CLAIM.SALESCNSTAXFRCPROCCDRF, --売上消費税端数処理コード" + Environment.NewLine);
                    sqlText.Append(" CLAIM.CUSTCTAXLAYREFCDRF," + Environment.NewLine);
                    sqlText.Append(" SALESPROC.FRACTIONPROCCDRF,   --端数処理単位" + Environment.NewLine);
                    sqlText.Append(" SALESPROC.FRACTIONPROCUNITRF, --端数処理区分" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATESTARTDATERF,      --税率開始日" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATEENDDATERF,        --税率終了日" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATERF,               --税率" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATESTARTDATE2RF,     --税率開始日2" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATEENDDATE2RF,       --税率終了日2" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATE2RF,              --税率2" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATESTARTDATE3RF,     --税率開始日3" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATEENDDATE3RF,       --税率終了日3" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATE3RF,              --税率3" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXCONSTAXLAYMETHODRF" + Environment.NewLine);
                    sqlText.Append(") AS DMDPRC" + Environment.NewLine);
                    // ADD 菅原 庸平  2012/04/27 <<<
                    #endregion

                    //sqlCommand.CommandText = sqlText; // DEL 菅原 庸平  2012/04/27
                    sqlCommand.CommandText = sqlText.ToString(); // ADD 菅原 庸平  2012/04/27

                    #region Prameterオブジェクトの作成
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCodeChild = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaClaimCodeChild = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    //SqlParameter findParaAddUpSecCodeChild = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDateChild = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastCAddUpUpdDateChild = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
                    #endregion

                    #region Parameterオブジェクトへ値設定
                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCodeChild.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    findParaClaimCodeChild.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                    //findParaAddUpSecCodeChild.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                    findParaAddUpDateChild.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);
                    // --- UPD m.suzuki 2010/07/21 ---------->>>>>
                    //if (custDmdPrcWork.LastCAddUpUpdDate == DateTime.MinValue)
                    //    findParaLastCAddUpUpdDateChild.Value = 20000101;
                    //else
                    //    findParaLastCAddUpUpdDateChild.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.LastCAddUpUpdDate);

                    if ( custDmdPrcWork.LastCAddUpUpdDate != DateTime.MinValue )
                    {
                        findParaLastCAddUpUpdDateChild.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( custDmdPrcWork.LastCAddUpUpdDate );
                    }
                    else if ( custDmdPrcWork.ExtractStartDate != DateTime.MinValue )
                    {
                        findParaLastCAddUpUpdDateChild.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( custDmdPrcWork.ExtractStartDate.AddDays( -1 ) );
                    }
                    else
                    {
                        findParaLastCAddUpUpdDateChild.Value = 20000101;
                    }
                    // --- UPD m.suzuki 2010/07/21 ----------<<<<<
                    #endregion

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        CustDmdPrcWork custDmdPrcChildWork = new CustDmdPrcWork();

                        #region 親・子レコードセット

                        custDmdPrcChildWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); //端数処理区分
                        fractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF")); // 端数処理単位

                        custDmdPrcChildWork.AddUpSecCode = custDmdPrcWork.AddUpSecCode;
                        custDmdPrcChildWork.ClaimCode = custDmdPrcWork.ClaimCode;
                        custDmdPrcChildWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
                        custDmdPrcChildWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
                        custDmdPrcChildWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                        custDmdPrcChildWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));　　　　　　// 回収条件(得意先マスタ)
                        //custDmdPrcChildWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));　// 消費税転嫁方式(得意先マスタ)
                        custDmdPrcChildWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));　// 消費税転嫁方式(得意先マスタ) // ADD 2010/12/20
                        custDmdPrcChildWork.ConsTaxRate = custDmdPrcWork.ConsTaxRate;                                                             // 税率(セット済　※得意先マスタ)
                        custDmdPrcChildWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));      // 端数処理区分(得意先マスタ)
                        custDmdPrcChildWork.ResultsSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSSECTCDRF"));       // 実績拠点コード

                        custDmdPrcChildWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        custDmdPrcChildWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        custDmdPrcChildWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                        custDmdPrcChildWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));

                        custDmdPrcChildWork.AddUpDate = custDmdPrcWork.AddUpDate;           // 計上年月日(画面設定値)
                        custDmdPrcChildWork.AddUpYearMonth = custDmdPrcWork.AddUpYearMonth; // 計上年月(画面設定値の年月)

                        // 親・子レコードは未セット項目(※集計レコードのみセットする) >>>
                        custDmdPrcChildWork.LastTimeDemand = 0;         // 前回請求金額(0固定)
                        custDmdPrcChildWork.ThisTimeFeeDmdNrml = 0;     // 今回手数料金額(0固定)
                        custDmdPrcChildWork.ThisTimeDisDmdNrml = 0;     // 今回値引金額(0固定)
                        custDmdPrcChildWork.ThisTimeDmdNrml = 0;        // 今回入金金額(0固定)                        
                        custDmdPrcChildWork.ThisTimeTtlBlcDmd = 0;      // 今回繰越残高(0固定)
                        // 親・子レコードは未セット項目(※集計レコードのみセットする) <<<

                        // ■相殺
                        custDmdPrcChildWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));     // 相殺後今回売上金額
                        custDmdPrcChildWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));   // 相殺後外税対象額
                        custDmdPrcChildWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));     // 相殺後内税対象額
                        custDmdPrcChildWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF")); // 相殺後非課税対象額
                        custDmdPrcChildWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));               // 相殺後売上内税額
                        // 修正 2009/04/14 >>>
                        // 相殺後売上外税額 = 今回売上外税額( 請求親転嫁+請求子転嫁+伝票転嫁+明細転嫁 ) + 今回売上返品外税額( 請求親転嫁+請求子転嫁+伝票転嫁+明細転嫁 ) + 今回売上値引外税額( 請求親転嫁+請求子転嫁+伝票転嫁+明細転嫁 )
                        
                        // ①請求転嫁子の相殺後消費税算出
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESOUTTAX_S")) + SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSALESOUTTAX_S")) +
                            SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSALESOUTTAX_S")), fractionProcUnit, custDmdPrcChildWork.FractionProcCd, out setTax);                        
                        OffsetOutTax += setTax; // 集計レコード計算用に退避
                        custDmdPrcChildWork.OffsetOutTax = setTax;
                        
                        // ②請求転嫁親の相殺消費税算出                        
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESOUTTAX_S2")) + SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSALESOUTTAX_S2")) +
                            SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSALESOUTTAX_S2")), fractionProcUnit, custDmdPrcChildWork.FractionProcCd, out setTax);
                        custDmdPrcChildWork.OffsetOutTax += setTax;

                        // ③伝票転嫁の相殺消費税算出
                        custDmdPrcChildWork.OffsetOutTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSALESOUTTAX_D")) +
                                                            SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSALESOUTTAX_D"));

                        // ④明細転嫁の相殺消費税算出
                        custDmdPrcChildWork.OffsetOutTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAX_M")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSALESOUTTAX_M")) +
                                                            SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSALESOUTTAX_M"));

                        // 相殺後今回売上消費税額 = 相殺後売上外税額 + 相殺後売上内税額
                        custDmdPrcChildWork.OfsThisSalesTax = custDmdPrcChildWork.OffsetOutTax + custDmdPrcChildWork.OffsetInTax;      // 相殺後今回売上消費税額

                        // 修正 2009/04/14 <<<
                        //相殺後売上外税額 <<<

                        // ■売上
                        // 修正 2009/04/14 >>>
                        custDmdPrcChildWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));            // 今回売上金額 
                        custDmdPrcChildWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));      // 今回売上外税対象額
                        custDmdPrcChildWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));        // 今回売上内税対象額
                        custDmdPrcChildWork.ItdedSalesTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESTAXFREERF"));    // 今回売上非課税対象額 
                        custDmdPrcChildWork.SalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESINTAXRF"));                  // 今回売上内税額
                        // 今回売上外税額 = 請求転嫁(子) + 請求転嫁(親) + 伝票転嫁 + 明細転嫁
                        // 請求転嫁(子)
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESOUTTAX_S")), fractionProcUnit, custDmdPrcChildWork.FractionProcCd, out setTax);
                        custDmdPrcChildWork.SalesOutTax = setTax;
                        SalesOutTax += setTax;
                        // 請求転嫁(親)
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESOUTTAX_S2")), fractionProcUnit, custDmdPrcChildWork.FractionProcCd, out setTax);
                        custDmdPrcChildWork.SalesOutTax += setTax;
                        // 伝票転嫁 + 明細転嫁
                        custDmdPrcChildWork.SalesOutTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAX_M"));
                        custDmdPrcChildWork.ThisSalesTax = custDmdPrcChildWork.SalesOutTax + custDmdPrcChildWork.SalesInTax; // 今回消費税金額
                        // 修正 2009/04/14 <<<

                        // ■返品
                        // 修正 2009/04/14 >>>
                        custDmdPrcChildWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));  // 今回売上返品金額
                        custDmdPrcChildWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));  // 今回売上返品外税対象額
                        custDmdPrcChildWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));    // 今回売上返品内税対象額
                        custDmdPrcChildWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));// 今回売上返品非課税対象額
                        custDmdPrcChildWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));        // 今回売上返品内税額
                        // 今回売上返品外税額 = 請求転嫁(子) + 請求転嫁(親) + 伝票転嫁 + 明細転嫁
                         // 請求転嫁(子)
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSALESOUTTAX_S")), fractionProcUnit, custDmdPrcChildWork.FractionProcCd, out setTax);
                        custDmdPrcChildWork.TtlRetOuterTax = setTax;
                        RetSalesOutTax += setTax;
                         // 請求転嫁(親)
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSALESOUTTAX_S2")), fractionProcUnit, custDmdPrcChildWork.FractionProcCd, out setTax);
                        custDmdPrcChildWork.TtlRetOuterTax += setTax;
                         // 伝票転嫁 + 明細転嫁
                        custDmdPrcChildWork.TtlRetOuterTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSALESOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSALESOUTTAX_M"));

                        // 今回返品消費税額
                        custDmdPrcChildWork.ThisSalesPrcTaxRgds = custDmdPrcChildWork.TtlRetOuterTax + custDmdPrcChildWork.TtlRetInnerTax;

                        // 修正 2009/04/14 <<<

                        // ■値引
                        // 修正 2009/04/14 >>>
                        custDmdPrcChildWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));      // 今回売上値引金額
                        custDmdPrcChildWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));    // 今回売上値引外税対象金額
                        custDmdPrcChildWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));      // 今回売上値引内税対象金額
                        custDmdPrcChildWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));  // 今回売上値引非課税対象金額
                        custDmdPrcChildWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));          // 今回売上値引内税額
                        // 今回売上値引外税額 = 請求転嫁(子) + 請求転嫁(親) + 伝票転嫁 + 明細転嫁
                         // 請求転嫁(子)
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSALESOUTTAX_S")), fractionProcUnit, custDmdPrcChildWork.FractionProcCd, out setTax);
                        custDmdPrcChildWork.TtlDisOuterTax = setTax;
                        DisSalesOutTax += setTax;
                         // 請求転嫁(親)
                        FracCalc(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSALESOUTTAX_S2")), fractionProcUnit, custDmdPrcChildWork.FractionProcCd, out setTax);
                        custDmdPrcChildWork.TtlDisOuterTax += setTax;
                         // 伝票転嫁 + 明細転嫁
                        custDmdPrcChildWork.TtlDisOuterTax += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSALESOUTTAX_D")) + SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSALESOUTTAX_M"));
                        // 今回売上値引消費税額
                        custDmdPrcChildWork.ThisSalesPrcTaxDis = custDmdPrcChildWork.TtlDisOuterTax + custDmdPrcChildWork.TtlDisInnerTax;
                        // 修正 2009/04/14 <<<

                        custDmdPrcChildWork.TaxAdjust = 0;           // 消費税調整額  (0固定)
                        custDmdPrcChildWork.BalanceAdjust = 0;       // 残高調整額　  (0固定)
                        custDmdPrcChildWork.AfCalDemandPrice = 0;    // 計算後請求金額(0固定)
                        custDmdPrcChildWork.AcpOdrTtl2TmBfBlDmd = 0; // 受注2回前残高(請求計) (0固定)
                        custDmdPrcChildWork.AcpOdrTtl3TmBfBlDmd = 0; // 受注3回前残高(請求計) (0固定)

                        custDmdPrcChildWork.CAddUpUpdExecDate = custDmdPrcWork.CAddUpUpdExecDate;   // 締次更新実行年月日(セット済み ※前回履歴から)
                        custDmdPrcChildWork.StartCAddUpUpdDate = custDmdPrcWork.StartCAddUpUpdDate; // 締次更新開始年月日(セット済み ※前回履歴から) 
                        custDmdPrcChildWork.LastCAddUpUpdDate = custDmdPrcWork.LastCAddUpUpdDate;   // 前回締次更新年月日(セット済み ※前回履歴から)

                        custDmdPrcChildWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF")); // 売上伝票枚数
                        custDmdPrcChildWork.BillPrintDate = DateTime.Now;  // 請求書発行日(システム日付)

                        // 入金予定日計算 >>>
                        // 集金月区分によってセット内容変動( クエリ内で処理しきれない為、セット時に計算 )
                        // 修正 2009/07/10 >>>
                        //DateTime collectmoneyDate = custDmdPrcChildWork.CAddUpUpdExecDate;
                        DateTime collectmoneyDate = custDmdPrcChildWork.AddUpDate;
                        // 修正 2009/07/10 <<<
                        //add by liusy #32866 2012/10/18-->>>>>
                        //if (collectmoneyDate.Year != 9999 && collectmoneyDate.Month != 12)//del by dpp #33856 2012/12/12
                        if (collectmoneyDate.Year != 9999)//add by dpp #33856 2012/12/12
                        {
                        //add by liusy #32866 2012/10/18--<<<<<
                            switch (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"))) // 0:当月,1:翌月,2:翌々月,3翌々々月
                            {
                                case 1:
                                    collectmoneyDate = collectmoneyDate.AddMonths(1);
                                    break;
                                case 2:
                                    collectmoneyDate = collectmoneyDate.AddMonths(2);
                                    break;
                                case 3:
                                    collectmoneyDate = collectmoneyDate.AddMonths(3);
                                    break;
                            }
                            // 28日以降は末日とする
                            if (SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF")) >= 28)
                            {
                                collectmoneyDate = new DateTime(collectmoneyDate.Year, collectmoneyDate.Month, 1);
                                collectmoneyDate = collectmoneyDate.AddMonths(1);
                                collectmoneyDate = collectmoneyDate.AddDays(-1);
                            }
                            else
                            {
                                collectmoneyDate = new DateTime(collectmoneyDate.Year, collectmoneyDate.Month, SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF")));
                            }
                        //add by liusy #32866 2012/10/18-->>>>>
                        }
                        //add by liusy #32866 2012/10/18--<<<<<
                        custDmdPrcChildWork.ExpectedDepositDate = collectmoneyDate;　// 入金予定日
                        // 入金予定日計算 <<<
                        #endregion

                        custDmdPrcChildWorkList.Add(custDmdPrcChildWork);
                        ChildCnt += 1;
                    }

                    #endregion

                    #region ■■ 集計レコード計算用の処理 ■■
                    if (ChildCnt != 0)
                    {
                        // DEL 2009/04/14 >>>
                        //if ((custDmdPrcWork.ConsTaxLayMethod == 3))// 消費税転嫁区分 = 3:請求子
                        //{
                        // DEL 2009/04/14 <<<

                        // 2008.12.24 戻り対応>>>
                        ////相殺後外税消費税 = 子レコード集計(相殺後外税対象金額)×税率
                        //FracCalc((itdedOffsetOutTax * custDmdPrcWork.ConsTaxRate), fractionProcUnit, custDmdPrcWork.FractionProcCd, out setTax);
                        //custDmdPrcWork.OffsetOutTax = setTax;

                        //今回売上外税
                        custDmdPrcWork.SalesOutTax += SalesOutTax;
                        //今回売上消費税
                        custDmdPrcWork.ThisSalesTax = custDmdPrcWork.SalesOutTax + custDmdPrcWork.SalesInTax;

                        //今回返品外税
                        custDmdPrcWork.TtlRetOuterTax += RetSalesOutTax;
                        //今回返品消費税
                        custDmdPrcWork.ThisSalesPrcTaxRgds = custDmdPrcWork.TtlRetOuterTax + custDmdPrcWork.TtlRetInnerTax;

                        //今回値引外税
                        custDmdPrcWork.TtlDisOuterTax += DisSalesOutTax;
                        //今回値引消費税
                        custDmdPrcWork.ThisSalesPrcTaxDis = custDmdPrcWork.TtlDisOuterTax + custDmdPrcWork.TtlDisInnerTax;

                        // 相殺後外税消費税 = 子レコード集計(相殺後外税金額)
                        custDmdPrcWork.OffsetOutTax += OffsetOutTax;
                        // 2008.12.24 <<<

                        //相殺後今回売上消費税 = 相殺後外税消費税 + 相殺後内税消費税
                        custDmdPrcWork.OfsThisSalesTax = custDmdPrcWork.OffsetOutTax + custDmdPrcWork.OffsetInTax;

                        // 計算後請求金額 = 今回繰越残高 + (相殺後今回売上金額 + 相殺後今回売上消費税)
                        custDmdPrcWork.AfCalDemandPrice = custDmdPrcWork.ThisTimeTtlBlcDmd + (custDmdPrcWork.OfsThisTimeSales + custDmdPrcWork.OfsThisSalesTax);

                        //} // DEL 2009/04/14 
                    }
                    #endregion

                    #region ■■ 実績無しの場合の処理 ■■
                    // 実績無しの場合でも、親レコードは作成する。
                    if (ChildCnt == 0)
                    {
                        // ■親レコード( 不足項目セット )
                        // 実績拠点コード
                        custDmdPrcWork.ResultsSectCd = custDmdPrcWork.AddUpSecCode;

                        custDmdPrcChildWorkList.Add(custDmdPrcWork);

                        // ■集計レコード( 不足項目セット )
                        // 今回繰越残高
                        custDmdPrcWork.ThisTimeTtlBlcDmd = (custDmdPrcWork.LastTimeDemand + custDmdPrcWork.AcpOdrTtl2TmBfBlDmd + custDmdPrcWork.AcpOdrTtl3TmBfBlDmd) - custDmdPrcWork.ThisTimeDmdNrml;
                        // 計算後請求金額
                        custDmdPrcWork.AfCalDemandPrice = custDmdPrcWork.ThisTimeTtlBlcDmd + (custDmdPrcWork.OfsThisTimeSales + custDmdPrcWork.OfsThisSalesTax);

                    }
                    #endregion

                }
                // 修正 2008.12.10 <<<
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

        #region [請求締更新履歴マスタ更新パラメータ]
        /// <summary>
        /// 得意先請求金額マスタ計算処理/請求締更新履歴マスタ更新パラメータ作成
        /// </summary>
        /// <param name="custDmdPrcWorkList">請求金額マスタ更新List</param>
        /// <param name="dmdCAddUpHisWorkList">請求締更新履歴マスタ更新List</param>
        /// <param name="custDmdPrcUpdateWork"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額マスタ計算処理/請求締更新履歴マスタ更新パラメータ作成</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>s
        /// <br>Date       : 2007.03.26</br>
        /// </remarks>
        private int MakeUpdateList(ref ArrayList custDmdPrcWorkList, out ArrayList dmdCAddUpHisWorkList, CustDmdPrcUpdateWork custDmdPrcUpdateWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            dmdCAddUpHisWorkList = new ArrayList();
            CustDmdPrcWork custDmdPrcWork = null;
            int upFlg = 0;
            for (int i = 0; i < custDmdPrcWorkList.Count; i++)
            {
                upFlg = 0;
                custDmdPrcWork = custDmdPrcWorkList[i] as CustDmdPrcWork;

                if (custDmdPrcWork.UpdateStatus == 0)
                {
                    //status = CalculateCustDmdPrc(ref custDmdPrcWork); // 2008.12.10 DEL

                    //請求締更新履歴マスタList作成
                    if (custDmdPrcUpdateWork.ProcCntntsFlag == 1 && (custDmdPrcWork.CustomerCode ==custDmdPrcWork.ClaimCode))
                    {
                        DmdCAddUpHisWork dmdCAddUpHisWork = new DmdCAddUpHisWork();
                        // ADD 2008.11.18 >>>
                        if (dmdCAddUpHisWorkList.Count > 0)
                        {
                            for (int j = 0; j < dmdCAddUpHisWorkList.Count; j++)
                            {
                                if ((((DmdCAddUpHisWork)dmdCAddUpHisWorkList[j]).EnterpriseCode == custDmdPrcWork.EnterpriseCode) &&
                                    (((DmdCAddUpHisWork)dmdCAddUpHisWorkList[j]).AddUpSecCode == custDmdPrcWork.AddUpSecCode))
                                {
                                    upFlg = 1;
                                    break;
                                }
                            }
                        }
                        if (upFlg == 0)
                        {
                        // ADD 2008.11.18 <<<
                            dmdCAddUpHisWork.EnterpriseCode = custDmdPrcWork.EnterpriseCode;  //企業コード
                            dmdCAddUpHisWork.AddUpSecCode = custDmdPrcWork.AddUpSecCode;      //計上拠点コード
                            dmdCAddUpHisWork.CustomerCode = custDmdPrcWork.ClaimCode;         //得意先コード


                            dmdCAddUpHisWork.CAddUpUpdDate = custDmdPrcWork.AddUpDate;              //締次更新年月日
                            dmdCAddUpHisWork.CAddUpUpdYearMonth = custDmdPrcWork.AddUpYearMonth;    //締次更新年月
                            dmdCAddUpHisWork.CAddUpUpdExecDate = custDmdPrcWork.CAddUpUpdExecDate;  //締次更新実行年月日

                            // 修正 2009/06/22 >>>
                            //dmdCAddUpHisWork.LastCAddUpUpdDate = custDmdPrcWork.LastCAddUpUpdDate;  //前回締次更新年月日
                            //if (custDmdPrcWork.LastCAddUpUpdDate == DateTime.MinValue)
                                //dmdCAddUpHisWork.StartCAddUpUpdDate = DateTime.MinValue;
                            //else
                                //dmdCAddUpHisWork.StartCAddUpUpdDate = custDmdPrcWork.LastCAddUpUpdDate.AddDays(1);
                            if (custDmdPrcWork.CustomerTotalDay >= 28)
                            {
                                //前回締次更新年月日
                                dmdCAddUpHisWork.LastCAddUpUpdDate = new DateTime(custDmdPrcWork.AddUpDate.Year, custDmdPrcWork.AddUpDate.Month, 1);
                                dmdCAddUpHisWork.LastCAddUpUpdDate = dmdCAddUpHisWork.LastCAddUpUpdDate.AddDays(-1);
                            }
                            else
                            {
                                //前回締次更新年月日
                                dmdCAddUpHisWork.LastCAddUpUpdDate = custDmdPrcWork.AddUpDate.AddMonths(-1);
                            }
                            //締次更新開始年月日
                            dmdCAddUpHisWork.StartCAddUpUpdDate = dmdCAddUpHisWork.LastCAddUpUpdDate.AddDays(1);
                            // 修正 2009/06/22 <<<



                            //2008.07.18 add start ----------------------------->>
                            dmdCAddUpHisWork.ProcDivCd = 0;
                            dmdCAddUpHisWork.ErrorStatus = 0;
                            dmdCAddUpHisWork.HistCtlCd = 0;
                            dmdCAddUpHisWork.ProcResult = "正常終了";
                            dmdCAddUpHisWork.ConvertProcessDivCd = 0;
                            //2008.07.18 add end -------------------------------<<
                            

                            dmdCAddUpHisWorkList.Add(dmdCAddUpHisWork);
                        }
                    }
                    
                }
            }

            return status;
        }

        /// <summary>
        /// 得意先請求金額マスタ計算処理
        /// </summary>
        /// <param name="custDmdPrcWork"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額マスタ計算処理</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>s
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int CalculateCustDmdPrc(ref CustDmdPrcWork custDmdPrcWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //今回繰越残高（請求計）
            custDmdPrcWork.ThisTimeTtlBlcDmd = custDmdPrcWork.LastTimeDemand - custDmdPrcWork.ThisTimeDmdNrml;

            // 2008.07.18 add start ----------------------------------------------------->>
            custDmdPrcWork.OfsThisTimeSales = custDmdPrcWork.ThisTimeSales + custDmdPrcWork.ThisSalesPricRgds + custDmdPrcWork.ThisSalesPricDis + custDmdPrcWork.BalanceAdjust;
            //相殺後外税対象額 = 売上外税対象額+売上返品外税対象額＋売上値引外税対象額
            custDmdPrcWork.ItdedOffsetOutTax = custDmdPrcWork.ItdedSalesOutTax + custDmdPrcWork.TtlItdedRetOutTax + custDmdPrcWork.TtlItdedDisOutTax;
            //相殺後内税対象額 = 売上内税額合計＋返品内税額合計＋値引内税額合計
            custDmdPrcWork.ItdedOffsetInTax = custDmdPrcWork.SalesInTax + custDmdPrcWork.TtlRetInnerTax + custDmdPrcWork.TtlDisInnerTax;
            //相殺後非課税対象額 = 売上非課税対象額+返品非課税税象額合計＋値引非課税対象額合計
            custDmdPrcWork.ItdedOffsetTaxFree = custDmdPrcWork.ItdedSalesTaxFree + custDmdPrcWork.TtlItdedRetTaxFree + custDmdPrcWork.TtlItdedDisTaxFree;
            // 2008.07.18 add end -------------------------------------------------------<<

            //相殺後外税消費税 = 外税消費税の合計
            if (custDmdPrcWork.ConsTaxLayMethod == 2)
            {
                //消費税転嫁区分 2:請求親の場合(相殺後外税対象額×税率)
                //相殺後外税消費税額
                custDmdPrcWork.OffsetOutTax = Fraction(custDmdPrcWork.ItdedOffsetOutTax * custDmdPrcWork.ConsTaxRate, custDmdPrcWork.FractionProcCd);
                // 2008.07.18 upd start ---------------------------->>
                //相殺後消費税額
                //custDmdPrcWork.OfsThisSalesTax = custDmdPrcWork.OffsetOutTax + custDmdPrcWork.SalesInTax + custDmdPrcWork.TtlRetInnerTax + custDmdPrcWork.TtlDisInnerTax + custDmdPrcWork.PaymentInTax;
                custDmdPrcWork.OfsThisSalesTax = custDmdPrcWork.OffsetOutTax + custDmdPrcWork.SalesInTax + custDmdPrcWork.TtlRetInnerTax + custDmdPrcWork.TtlDisInnerTax + custDmdPrcWork.TaxAdjust;
                // 2008.07.18 upd end ------------------------------<<
                //売上外税額(参考値)
                custDmdPrcWork.SalesOutTax = Fraction(custDmdPrcWork.ItdedSalesOutTax * custDmdPrcWork.ConsTaxRate, custDmdPrcWork.FractionProcCd);
                //売上消費税額
                custDmdPrcWork.ThisSalesTax = custDmdPrcWork.SalesOutTax + custDmdPrcWork.SalesInTax;
                //返品外税額(参考値)
                custDmdPrcWork.TtlRetOuterTax = Fraction(custDmdPrcWork.TtlItdedRetOutTax * custDmdPrcWork.ConsTaxRate, custDmdPrcWork.FractionProcCd);
                //返品消費税額
                custDmdPrcWork.ThisSalesPrcTaxRgds = custDmdPrcWork.TtlRetOuterTax + custDmdPrcWork.TtlRetInnerTax;
                //値引外税額(参考値)
                custDmdPrcWork.TtlDisOuterTax = Fraction(custDmdPrcWork.TtlItdedDisOutTax * custDmdPrcWork.ConsTaxRate, custDmdPrcWork.FractionProcCd);
                //値引消費税額
                custDmdPrcWork.ThisSalesPrcTaxDis = custDmdPrcWork.TtlDisOuterTax + custDmdPrcWork.TtlDisInnerTax;
                // 2008.07.18 del start ---------------------------------------->>
                ////支払外税額(参考値)
                //custDmdPrcWork.PaymentOutTax = Fraction(custDmdPrcWork.ItdedPaymOutTax * custDmdPrcWork.ConsTaxRate, custDmdPrcWork.FractionProcCd);
                ////支払消費税額
                //custDmdPrcWork.ThisPayOffsetTax = custDmdPrcWork.PaymentOutTax + custDmdPrcWork.PaymentInTax;
                // 2008.07.18 del end ------------------------------------------<<
            }
            else if (custDmdPrcWork.ConsTaxLayMethod == 3)
            {
                //消費税転嫁区分 3:請求子の場合 得意先単位に外税対象額を集計し計算する。(相殺後外税対象額×税率)
            }
            else
            {
                // 2008.07.18 upd start ---------------------------->>
                //消費税転嫁区分 0:伝票、1:明細の場合 売上外税額＋返品外税額＋値引外税額
                //custDmdPrcWork.OffsetOutTax = custDmdPrcWork.SalesOutTax + custDmdPrcWork.TtlRetOuterTax + custDmdPrcWork.TtlDisOuterTax + custDmdPrcWork.PaymentOutTax;
                custDmdPrcWork.OffsetOutTax = custDmdPrcWork.SalesOutTax + custDmdPrcWork.TtlRetOuterTax + custDmdPrcWork.TtlDisOuterTax;
                // 2008.07.18 upd end ------------------------------<<
            }

            // 2008.07.18 upd start ---------------------------->>
            //相殺後内税消費税 = 売上内税額合計＋返品内税額合計＋値引内税額合計
            //custDmdPrcWork.OffsetInTax = custDmdPrcWork.SalesInTax + custDmdPrcWork.TtlRetInnerTax + custDmdPrcWork.TtlDisInnerTax + custDmdPrcWork.PaymentInTax;
            custDmdPrcWork.OffsetInTax = custDmdPrcWork.SalesInTax + custDmdPrcWork.TtlRetInnerTax + custDmdPrcWork.TtlDisInnerTax;
            // 2008.07.18 upd end ------------------------------<<

            //相殺後今回売上消費税 = 相殺後外税消費税＋相殺後内税消費税 + 消費税調整
            custDmdPrcWork.OfsThisSalesTax = custDmdPrcWork.OffsetOutTax + custDmdPrcWork.OffsetInTax + custDmdPrcWork.TaxAdjust;

            //計算後請求金額
            custDmdPrcWork.AfCalDemandPrice = custDmdPrcWork.ThisTimeTtlBlcDmd + custDmdPrcWork.OfsThisTimeSales + custDmdPrcWork.OfsThisSalesTax + custDmdPrcWork.BalanceAdjust + custDmdPrcWork.TaxAdjust;
            // ↑ 2007.11.20 980081 c

            return status;
        }

        // ↓ 2007.12.07 980081 a
        /// <summary>
        /// 得意先請求金額マスタ計算処理(子レコード)
        /// </summary>
        /// <param name="custDmdPrcWork"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額マスタ計算処理(子レコード)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.12.06</br>
        /// </remarks>
        private int CalculateCustDmdChildPrc(ref CustDmdPrcWork custDmdPrcWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //相殺後外税消費税 = 外税消費税の合計
            if (custDmdPrcWork.ConsTaxLayMethod == 3)
            {
                //消費税転嫁区分 3:請求子の場合 得意先単位に外税対象額を集計し計算する。(相殺後外税対象額×税率)

            }
            else if (custDmdPrcWork.ConsTaxLayMethod == 2)
            {
                //消費税転嫁区分 2:請求親の場合(相殺後外税対象額×税率)
            }
            else
            {
                // 2008.07.18 upd start -------------------------->>
                //消費税転嫁区分 0:伝票、1:明細の場合 売上外税額＋返品外税額＋値引外税額
                //custDmdPrcWork.OffsetOutTax = custDmdPrcWork.SalesOutTax + custDmdPrcWork.TtlRetOuterTax + custDmdPrcWork.TtlDisOuterTax + custDmdPrcWork.PaymentOutTax;
                custDmdPrcWork.OffsetOutTax = custDmdPrcWork.SalesOutTax + custDmdPrcWork.TtlRetOuterTax + custDmdPrcWork.TtlDisOuterTax;
                // 2008.07.18 upd end ----------------------------<<
            }

            // 2008.07.18 upd start -------------------------->>
            //相殺後内税消費税 = 売上内税額合計＋返品内税額合計＋値引内税額合計
            //custDmdPrcWork.OffsetInTax = custDmdPrcWork.SalesInTax + custDmdPrcWork.TtlRetInnerTax + custDmdPrcWork.TtlDisInnerTax + custDmdPrcWork.PaymentInTax;
            custDmdPrcWork.OffsetInTax = custDmdPrcWork.SalesInTax + custDmdPrcWork.TtlRetInnerTax + custDmdPrcWork.TtlDisInnerTax;
            // 2008.07.18 upd end ----------------------------<<

            //相殺後今回売上消費税 = 相殺後外税消費税＋相殺後内税消費税 + 消費税調整額
            custDmdPrcWork.OfsThisSalesTax = custDmdPrcWork.OffsetOutTax + custDmdPrcWork.OffsetInTax + custDmdPrcWork.TaxAdjust;

            //計算後請求金額
            custDmdPrcWork.AfCalDemandPrice = 0;

            return status;
        }
        // ↑ 2007.12.07 980081 a
        #endregion

        #region [Delete 最終締取消]
        // --- ADD m.suzuki 2010/08/18 ---------->>>>>
        /// <summary>
        /// 最終締取消を行います
        /// </summary>
        /// <param name="paraObj">得意先請求金額マスタ更新パラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 最終締取消を行います</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.15</br>
        public int Delete( ref object paraObj, out string retMsg )
        {
            // 外部から呼び出す時は必ずロック処理あり(true)
            return DeleteProc( ref paraObj, out retMsg, true );
        }
        // --- ADD m.suzuki 2010/08/18 ----------<<<<<
        /// <summary>
        /// 最終締取消を行います
        /// </summary>
        /// <param name="paraObj">得意先請求金額マスタ更新パラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <param name="executeLock">ロック処理有無（※既に呼び出し側でロック中の場合のみ"無"とする必要がある）</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 最終締取消を行います</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.15</br>
        // --- UPD m.suzuki 2010/08/18 ---------->>>>>
        //public int Delete(ref object paraObj, out string retMsg)
        private int DeleteProc( ref object paraObj, out string retMsg, bool executeLock )
        // --- UPD m.suzuki 2010/08/18 ----------<<<<<
        {

            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            retMsg = null;

            //●削除パラメータ
            //CustDmdPrcWork custDmdPrcWork = null;
            //ArrayList deleteList = new ArrayList();

            // ↓ 2008.01.10 980081 a
            //拠点情報設定取得部品
            SecInfoSetDB secInfoSetDB = new SecInfoSetDB();
            // ↑ 2008.01.10 980081 a
            try
            {
                CustDmdPrcUpdateWork custDmdPrcUpdateWork = paraObj as CustDmdPrcUpdateWork;

                //●パラメータチェック
                if (custDmdPrcUpdateWork == null)
                {
                    base.WriteErrorLog(null, "プログラムエラー。パラメータが未設定です");
                    return status;
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                #region 2008.12.10 DEL 
                /*
                //●削除得意先List作成
                // ↓ 2008.01.10 980081 a
                //全拠点一括締め対応
                SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
                secInfoSetWork.EnterpriseCode = custDmdPrcUpdateWork.EnterpriseCode;
                ArrayList secInfoList = new ArrayList();
                if (custDmdPrcUpdateWork.AddUpSecCode == null || custDmdPrcUpdateWork.AddUpSecCode == "00")
                {
                    secInfoSetDB.Search(out secInfoList, secInfoSetWork, 0, 0, ref sqlConnection);
                }
                else
                {
                    secInfoSetWork.SectionCode = custDmdPrcUpdateWork.AddUpSecCode;
                    secInfoList.Add(secInfoSetWork);
                }
                string addUpSecCode = custDmdPrcUpdateWork.AddUpSecCode;
                for (int loopCount = 0; loopCount < secInfoList.Count; loopCount++)
                {
                    custDmdPrcUpdateWork.AddUpSecCode = (secInfoList[loopCount] as SecInfoSetWork).SectionCode;
                // ↑ 2008.01.10 980081 a
                    //全得意先対象
                    if (custDmdPrcUpdateWork.UpdObjectFlag == 1)
                    {
                        status = GetCustomer(ref custDmdPrcUpdateWork, ref deleteList, ref sqlConnection);
                    }
                    //個別得意先指定
                    else if (custDmdPrcUpdateWork.UpdObjectFlag == 2)
                    {
                        #region [得意先1～10まで]　現在未使用
                        //if (custDmdPrcUpdateWork.CustomerCode1 != 0 && custDmdPrcUpdateWork.CustomerTotalDay != custDmdPrcUpdateWork.Customer1TotalDay)
                        if (custDmdPrcUpdateWork.CustomerCode1 != 0)
                        {
                            custDmdPrcWork = new CustDmdPrcWork();
                            
                            custDmdPrcWork.EnterpriseCode = custDmdPrcUpdateWork.EnterpriseCode;
                            custDmdPrcWork.AddUpSecCode = custDmdPrcUpdateWork.AddUpSecCode;
                            custDmdPrcWork.CustomerCode = custDmdPrcUpdateWork.CustomerCode1;
                            custDmdPrcWork.CustomerTotalDay = custDmdPrcUpdateWork.Customer1TotalDay;

                            status = GetIndivCustomer(ref custDmdPrcUpdateWork, ref custDmdPrcWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "得意先が登録されておりません : " + custDmdPrcUpdateWork.CustomerCode1;
                                return status;
                            }
                            else
                            {
                                // ↓ 2007.09.14 980081 a 請求先＝得意先のものだけ実行
                                if (custDmdPrcWork.ClaimCode != custDmdPrcWork.CustomerCode)
                                {
                                    retMsg = "請求先ではありません : " + custDmdPrcUpdateWork.CustomerCode1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ↑ 2007.09.14 980081 a
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (custDmdPrcUpdateWork.AddUpSecCode.Trim() != custDmdPrcWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と請求拠点が一致しません : " + custDmdPrcUpdateWork.CustomerCode1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (custDmdPrcUpdateWork.CustomerTotalDay != 0)
                                {
                                    if (custDmdPrcUpdateWork.CustomerTotalDay == 99)
                                    {
                                        if (custDmdPrcWork.CustomerTotalDay == 28 || custDmdPrcWork.CustomerTotalDay == 29 ||
                                            custDmdPrcWork.CustomerTotalDay == 30 || custDmdPrcWork.CustomerTotalDay == 31)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode1.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (custDmdPrcUpdateWork.CustomerTotalDay == custDmdPrcWork.CustomerTotalDay)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode1.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(custDmdPrcWork);
                                }
                            }
                        }
                        if (custDmdPrcUpdateWork.CustomerCode2 != 0)
                        {
                            custDmdPrcWork = new CustDmdPrcWork();
                            custDmdPrcWork.EnterpriseCode = custDmdPrcUpdateWork.EnterpriseCode;
                            custDmdPrcWork.AddUpSecCode = custDmdPrcUpdateWork.AddUpSecCode;
                            custDmdPrcWork.CustomerCode = custDmdPrcUpdateWork.CustomerCode2;
                            custDmdPrcWork.CustomerTotalDay = custDmdPrcUpdateWork.Customer2TotalDay;

                            status = GetIndivCustomer(ref custDmdPrcUpdateWork, ref custDmdPrcWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "得意先が登録されておりません : " + custDmdPrcUpdateWork.CustomerCode2;
                                return status;
                            }
                            else
                            {
                                // ↓ 2007.09.14 980081 a 請求先＝得意先のものだけ実行
                                if (custDmdPrcWork.ClaimCode != custDmdPrcWork.CustomerCode)
                                {
                                    retMsg = "請求先ではありません : " + custDmdPrcUpdateWork.CustomerCode2.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ↑ 2007.09.14 980081 a
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (custDmdPrcUpdateWork.AddUpSecCode.Trim() != custDmdPrcWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と請求拠点が一致しません : " + custDmdPrcUpdateWork.CustomerCode1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (custDmdPrcUpdateWork.CustomerTotalDay != 0)
                                {
                                    if (custDmdPrcUpdateWork.CustomerTotalDay == 99)
                                    {
                                        if (custDmdPrcWork.CustomerTotalDay == 28 || custDmdPrcWork.CustomerTotalDay == 29 ||
                                            custDmdPrcWork.CustomerTotalDay == 30 || custDmdPrcWork.CustomerTotalDay == 31)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode2.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (custDmdPrcUpdateWork.CustomerTotalDay == custDmdPrcWork.CustomerTotalDay)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode2.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(custDmdPrcWork);
                                }
                            }
                        }
                        if (custDmdPrcUpdateWork.CustomerCode3 != 0)
                        {
                            custDmdPrcWork = new CustDmdPrcWork();
                            custDmdPrcWork.EnterpriseCode = custDmdPrcUpdateWork.EnterpriseCode;
                            custDmdPrcWork.AddUpSecCode = custDmdPrcUpdateWork.AddUpSecCode;
                            custDmdPrcWork.CustomerCode = custDmdPrcUpdateWork.CustomerCode3;

                            status = GetIndivCustomer(ref custDmdPrcUpdateWork, ref custDmdPrcWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "得意先が登録されておりません : " + custDmdPrcUpdateWork.CustomerCode3;
                                return status;
                            }
                            else
                            {
                                // ↓ 2007.09.14 980081 a 請求先＝得意先のものだけ実行
                                if (custDmdPrcWork.ClaimCode != custDmdPrcWork.CustomerCode)
                                {
                                    retMsg = "請求先ではありません : " + custDmdPrcUpdateWork.CustomerCode3.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ↑ 2007.09.14 980081 a
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (custDmdPrcUpdateWork.AddUpSecCode.Trim() != custDmdPrcWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と請求拠点が一致しません : " + custDmdPrcUpdateWork.CustomerCode1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (custDmdPrcUpdateWork.CustomerTotalDay != 0)
                                {
                                    if (custDmdPrcUpdateWork.CustomerTotalDay == 99)
                                    {
                                        if (custDmdPrcWork.CustomerTotalDay == 28 || custDmdPrcWork.CustomerTotalDay == 29 ||
                                            custDmdPrcWork.CustomerTotalDay == 30 || custDmdPrcWork.CustomerTotalDay == 31)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode3.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (custDmdPrcUpdateWork.CustomerTotalDay == custDmdPrcWork.CustomerTotalDay)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode3.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(custDmdPrcWork);
                                }
                            }
                        }
                        if (custDmdPrcUpdateWork.CustomerCode4 != 0)
                        {
                            custDmdPrcWork = new CustDmdPrcWork();
                            custDmdPrcWork.EnterpriseCode = custDmdPrcUpdateWork.EnterpriseCode;
                            custDmdPrcWork.AddUpSecCode = custDmdPrcUpdateWork.AddUpSecCode;
                            custDmdPrcWork.CustomerCode = custDmdPrcUpdateWork.CustomerCode4;

                            status = GetIndivCustomer(ref custDmdPrcUpdateWork, ref custDmdPrcWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "得意先が登録されておりません : " + custDmdPrcUpdateWork.CustomerCode4;
                                return status;
                            }
                            else
                            {
                                // ↓ 2007.09.14 980081 a 請求先＝得意先のものだけ実行
                                if (custDmdPrcWork.ClaimCode != custDmdPrcWork.CustomerCode)
                                {
                                    retMsg = "請求先ではありません : " + custDmdPrcUpdateWork.CustomerCode4.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ↑ 2007.09.14 980081 a
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (custDmdPrcUpdateWork.AddUpSecCode.Trim() != custDmdPrcWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と請求拠点が一致しません : " + custDmdPrcUpdateWork.CustomerCode1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (custDmdPrcUpdateWork.CustomerTotalDay != 0)
                                {
                                    if (custDmdPrcUpdateWork.CustomerTotalDay == 99)
                                    {
                                        if (custDmdPrcWork.CustomerTotalDay == 28 || custDmdPrcWork.CustomerTotalDay == 29 ||
                                            custDmdPrcWork.CustomerTotalDay == 30 || custDmdPrcWork.CustomerTotalDay == 31)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode4.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (custDmdPrcUpdateWork.CustomerTotalDay == custDmdPrcWork.CustomerTotalDay)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode4.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(custDmdPrcWork);
                                }
                            }
                        }
                        if (custDmdPrcUpdateWork.CustomerCode5 != 0)
                        {
                            custDmdPrcWork = new CustDmdPrcWork();
                            custDmdPrcWork.EnterpriseCode = custDmdPrcUpdateWork.EnterpriseCode;
                            custDmdPrcWork.AddUpSecCode = custDmdPrcUpdateWork.AddUpSecCode;
                            custDmdPrcWork.CustomerCode = custDmdPrcUpdateWork.CustomerCode5;

                            status = GetIndivCustomer(ref custDmdPrcUpdateWork, ref custDmdPrcWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "得意先が登録されておりません : " + custDmdPrcUpdateWork.CustomerCode5;
                                return status;
                            }
                            else
                            {
                                // ↓ 2007.09.14 980081 a 請求先＝得意先のものだけ実行
                                if (custDmdPrcWork.ClaimCode != custDmdPrcWork.CustomerCode)
                                {
                                    retMsg = "請求先ではありません : " + custDmdPrcUpdateWork.CustomerCode5.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ↑ 2007.09.14 980081 a
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (custDmdPrcUpdateWork.AddUpSecCode.Trim() != custDmdPrcWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と請求拠点が一致しません : " + custDmdPrcUpdateWork.CustomerCode1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (custDmdPrcUpdateWork.CustomerTotalDay != 0)
                                {
                                    if (custDmdPrcUpdateWork.CustomerTotalDay == 99)
                                    {
                                        if (custDmdPrcWork.CustomerTotalDay == 28 || custDmdPrcWork.CustomerTotalDay == 29 ||
                                            custDmdPrcWork.CustomerTotalDay == 30 || custDmdPrcWork.CustomerTotalDay == 31)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode5.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (custDmdPrcUpdateWork.CustomerTotalDay == custDmdPrcWork.CustomerTotalDay)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode5.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(custDmdPrcWork);
                                }
                            }
                        }
                        if (custDmdPrcUpdateWork.CustomerCode6 != 0)
                        {
                            custDmdPrcWork = new CustDmdPrcWork();
                            custDmdPrcWork.EnterpriseCode = custDmdPrcUpdateWork.EnterpriseCode;
                            custDmdPrcWork.AddUpSecCode = custDmdPrcUpdateWork.AddUpSecCode;
                            custDmdPrcWork.CustomerCode = custDmdPrcUpdateWork.CustomerCode6;

                            status = GetIndivCustomer(ref custDmdPrcUpdateWork, ref custDmdPrcWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "得意先が登録されておりません : " + custDmdPrcUpdateWork.CustomerCode6;
                                return status;
                            }
                            else
                            {
                                // ↓ 2007.09.14 980081 a 請求先＝得意先のものだけ実行
                                if (custDmdPrcWork.ClaimCode != custDmdPrcWork.CustomerCode)
                                {
                                    retMsg = "請求先ではありません : " + custDmdPrcUpdateWork.CustomerCode6.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ↑ 2007.09.14 980081 a
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (custDmdPrcUpdateWork.AddUpSecCode.Trim() != custDmdPrcWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と請求拠点が一致しません : " + custDmdPrcUpdateWork.CustomerCode1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (custDmdPrcUpdateWork.CustomerTotalDay != 0)
                                {
                                    if (custDmdPrcUpdateWork.CustomerTotalDay == 99)
                                    {
                                        if (custDmdPrcWork.CustomerTotalDay == 28 || custDmdPrcWork.CustomerTotalDay == 29 ||
                                            custDmdPrcWork.CustomerTotalDay == 30 || custDmdPrcWork.CustomerTotalDay == 31)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode6.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (custDmdPrcUpdateWork.CustomerTotalDay == custDmdPrcWork.CustomerTotalDay)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode6.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(custDmdPrcWork);
                                }
                            }
                        }
                        if (custDmdPrcUpdateWork.CustomerCode7 != 0)
                        {
                            custDmdPrcWork = new CustDmdPrcWork();
                            custDmdPrcWork.EnterpriseCode = custDmdPrcUpdateWork.EnterpriseCode;
                            custDmdPrcWork.AddUpSecCode = custDmdPrcUpdateWork.AddUpSecCode;
                            custDmdPrcWork.CustomerCode = custDmdPrcUpdateWork.CustomerCode7;

                            status = GetIndivCustomer(ref custDmdPrcUpdateWork, ref custDmdPrcWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "得意先が登録されておりません : " + custDmdPrcUpdateWork.CustomerCode7;
                                return status;
                            }
                            else
                            {
                                // ↓ 2007.09.14 980081 a 請求先＝得意先のものだけ実行
                                if (custDmdPrcWork.ClaimCode != custDmdPrcWork.CustomerCode)
                                {
                                    retMsg = "請求先ではありません : " + custDmdPrcUpdateWork.CustomerCode7.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ↑ 2007.09.14 980081 a
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (custDmdPrcUpdateWork.AddUpSecCode.Trim() != custDmdPrcWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と請求拠点が一致しません : " + custDmdPrcUpdateWork.CustomerCode1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (custDmdPrcUpdateWork.CustomerTotalDay != 0)
                                {
                                    if (custDmdPrcUpdateWork.CustomerTotalDay == 99)
                                    {
                                        if (custDmdPrcWork.CustomerTotalDay == 28 || custDmdPrcWork.CustomerTotalDay == 29 ||
                                            custDmdPrcWork.CustomerTotalDay == 30 || custDmdPrcWork.CustomerTotalDay == 31)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode7.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (custDmdPrcUpdateWork.CustomerTotalDay == custDmdPrcWork.CustomerTotalDay)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode7.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(custDmdPrcWork);
                                }
                            }
                        }
                        if (custDmdPrcUpdateWork.CustomerCode8 != 0)
                        {
                            custDmdPrcWork = new CustDmdPrcWork();
                            custDmdPrcWork.EnterpriseCode = custDmdPrcUpdateWork.EnterpriseCode;
                            custDmdPrcWork.AddUpSecCode = custDmdPrcUpdateWork.AddUpSecCode;
                            custDmdPrcWork.CustomerCode = custDmdPrcUpdateWork.CustomerCode8;

                            status = GetIndivCustomer(ref custDmdPrcUpdateWork, ref custDmdPrcWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "得意先が登録されておりません : " + custDmdPrcUpdateWork.CustomerCode8;
                                return status;
                            }
                            else
                            {
                                // ↓ 2007.09.14 980081 a 請求先＝得意先のものだけ実行
                                if (custDmdPrcWork.ClaimCode != custDmdPrcWork.CustomerCode)
                                {
                                    retMsg = "請求先ではありません : " + custDmdPrcUpdateWork.CustomerCode8.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ↑ 2007.09.14 980081 a
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (custDmdPrcUpdateWork.AddUpSecCode.Trim() != custDmdPrcWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と請求拠点が一致しません : " + custDmdPrcUpdateWork.CustomerCode1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (custDmdPrcUpdateWork.CustomerTotalDay != 0)
                                {
                                    if (custDmdPrcUpdateWork.CustomerTotalDay == 99)
                                    {
                                        if (custDmdPrcWork.CustomerTotalDay == 28 || custDmdPrcWork.CustomerTotalDay == 29 ||
                                            custDmdPrcWork.CustomerTotalDay == 30 || custDmdPrcWork.CustomerTotalDay == 31)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode8.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (custDmdPrcUpdateWork.CustomerTotalDay == custDmdPrcWork.CustomerTotalDay)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode8.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(custDmdPrcWork);
                                }
                            }
                        }
                        if (custDmdPrcUpdateWork.CustomerCode9 != 0)
                        {
                            custDmdPrcWork = new CustDmdPrcWork();
                            custDmdPrcWork.EnterpriseCode = custDmdPrcUpdateWork.EnterpriseCode;
                            custDmdPrcWork.AddUpSecCode = custDmdPrcUpdateWork.AddUpSecCode;
                            custDmdPrcWork.CustomerCode = custDmdPrcUpdateWork.CustomerCode9;

                            status = GetIndivCustomer(ref custDmdPrcUpdateWork, ref custDmdPrcWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "得意先が登録されておりません : " + custDmdPrcUpdateWork.CustomerCode9;
                                return status;
                            }
                            else
                            {
                                // ↓ 2007.09.14 980081 a 請求先＝得意先のものだけ実行
                                if (custDmdPrcWork.ClaimCode != custDmdPrcWork.CustomerCode)
                                {
                                    retMsg = "請求先ではありません : " + custDmdPrcUpdateWork.CustomerCode9.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ↑ 2007.09.14 980081 a
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (custDmdPrcUpdateWork.AddUpSecCode.Trim() != custDmdPrcWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と請求拠点が一致しません : " + custDmdPrcUpdateWork.CustomerCode1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (custDmdPrcUpdateWork.CustomerTotalDay != 0)
                                {
                                    if (custDmdPrcUpdateWork.CustomerTotalDay == 99)
                                    {
                                        if (custDmdPrcWork.CustomerTotalDay == 28 || custDmdPrcWork.CustomerTotalDay == 29 ||
                                            custDmdPrcWork.CustomerTotalDay == 30 || custDmdPrcWork.CustomerTotalDay == 31)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode9.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (custDmdPrcUpdateWork.CustomerTotalDay == custDmdPrcWork.CustomerTotalDay)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode9.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(custDmdPrcWork);
                                }
                            }
                        }
                        if (custDmdPrcUpdateWork.CustomerCode10 != 0)
                        {
                            custDmdPrcWork = new CustDmdPrcWork();
                            custDmdPrcWork.EnterpriseCode = custDmdPrcUpdateWork.EnterpriseCode;
                            custDmdPrcWork.AddUpSecCode = custDmdPrcUpdateWork.AddUpSecCode;
                            custDmdPrcWork.CustomerCode = custDmdPrcUpdateWork.CustomerCode10;

                            status = GetIndivCustomer(ref custDmdPrcUpdateWork, ref custDmdPrcWork, ref sqlConnection);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg = "得意先が登録されておりません : " + custDmdPrcUpdateWork.CustomerCode10;
                                return status;
                            }
                            else
                            {
                                // ↓ 2007.09.14 980081 a 請求先＝得意先のものだけ実行
                                if (custDmdPrcWork.ClaimCode != custDmdPrcWork.CustomerCode)
                                {
                                    retMsg = "請求先ではありません : " + custDmdPrcUpdateWork.CustomerCode10.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ↑ 2007.09.14 980081 a
                                // ADD 2008.10.20 >>>
                                // 計上拠点チェック
                                if (custDmdPrcUpdateWork.AddUpSecCode.Trim() != custDmdPrcWork.AddUpSecCode.Trim())
                                {
                                    retMsg = "指定拠点と請求拠点が一致しません : " + custDmdPrcUpdateWork.CustomerCode1.ToString();
                                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                    return status;
                                }
                                // ADD 2008.10.20 <<<

                                //締日チェック
                                if (custDmdPrcUpdateWork.CustomerTotalDay != 0)
                                {
                                    if (custDmdPrcUpdateWork.CustomerTotalDay == 99)
                                    {
                                        if (custDmdPrcWork.CustomerTotalDay == 28 || custDmdPrcWork.CustomerTotalDay == 29 ||
                                            custDmdPrcWork.CustomerTotalDay == 30 || custDmdPrcWork.CustomerTotalDay == 31)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode10.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                    else
                                    {
                                        if (custDmdPrcUpdateWork.CustomerTotalDay == custDmdPrcWork.CustomerTotalDay)
                                        {
                                            deleteList.Add(custDmdPrcWork);
                                        }
                                        else
                                        {
                                            retMsg = "指定締日と得意先締日が一致しません : " + custDmdPrcUpdateWork.CustomerCode10.ToString();
                                            status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                                            return status;
                                        }
                                    }
                                }
                                else
                                {
                                    deleteList.Add(custDmdPrcWork);
                                }
                            }
                        }
                        #endregion
                    }
                    //個別得意先除外
                    else if (custDmdPrcUpdateWork.UpdObjectFlag == 3)
                    {
                        #region 得意先除外 ※現在未使用
                        status = GetCustomer(ref custDmdPrcUpdateWork, ref deleteList, ref sqlConnection);

                        for (int i = 0; i < deleteList.Count; i++)
                        {
                            custDmdPrcWork = deleteList[i] as CustDmdPrcWork;
                            if (custDmdPrcWork.CustomerCode == custDmdPrcUpdateWork.CustomerCode1 ||
                                custDmdPrcWork.CustomerCode == custDmdPrcUpdateWork.CustomerCode2 ||
                                custDmdPrcWork.CustomerCode == custDmdPrcUpdateWork.CustomerCode3 ||
                                custDmdPrcWork.CustomerCode == custDmdPrcUpdateWork.CustomerCode4 ||
                                custDmdPrcWork.CustomerCode == custDmdPrcUpdateWork.CustomerCode5 ||
                                custDmdPrcWork.CustomerCode == custDmdPrcUpdateWork.CustomerCode6 ||
                                custDmdPrcWork.CustomerCode == custDmdPrcUpdateWork.CustomerCode7 ||
                                custDmdPrcWork.CustomerCode == custDmdPrcUpdateWork.CustomerCode8 ||
                                custDmdPrcWork.CustomerCode == custDmdPrcUpdateWork.CustomerCode9 ||
                                custDmdPrcWork.CustomerCode == custDmdPrcUpdateWork.CustomerCode10)
                            {
                                //未更新ステータスにする
                                custDmdPrcWork.UpdateStatus = 1;
                            }
                        }
                        #endregion
                    }
                // ↓ 2008.01.10 980081 a
                }
                custDmdPrcUpdateWork.AddUpSecCode = addUpSecCode;
                // ↑ 2008.01.10 980081 a

                //●請求締更新履歴マスタチェック
                //※レコード存在有無チェックする
                //※得意先Listと削除得意先Listの数を比較する
                int customerCount = 0;
                int notUpdateCount = 0;
                for (int i = 0; i < deleteList.Count; i++)
                {
                    custDmdPrcWork = deleteList[i] as CustDmdPrcWork;
                    status = CheckCAddUpUpdDate(ref custDmdPrcWork, ref sqlConnection);
                    if (custDmdPrcWork.UpdateStatus == 1)
                    {
                        notUpdateCount += 1;
                    }
                    customerCount += 1;
                }
                
                if (notUpdateCount == customerCount)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                    //constをリターン(後日)
                    retMsg = "取消を行う得意先が存在しません。";
                    return status;
                }
                
                //トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // 2008.07.18 upd start --------------------------------------------->>
                //●請求締更新履歴マスタ削除
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    if (custDmdPrcUpdateWork.ProcCntntsFlag == 1)
                //        status = DeleteDmdCAddUpHisProc(deleteList, ref sqlConnection, ref sqlTransaction);
                //}
                //●請求締更新履歴マスタ更新
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (custDmdPrcUpdateWork.ProcCntntsFlag == 1)
                        status = UpdateDmdCAddUpHisProc(deleteList, ref sqlConnection, ref sqlTransaction);
                }
                // 2008.07.18 upd end -----------------------------------------------<<
                // ADD 2008.12.10 >>> 

                // ●請求入金データ削除
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = DeleteDmdDepoTotalProc(deleteList, ref sqlConnection, ref sqlTransaction);
                }
                // ADD 2008.12.10 <<<

                //●請求金額マスタ削除
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    status = DeleteCustDmdPrcProc(deleteList, ref sqlConnection, ref sqlTransaction);

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

                //●請求締更新履歴マスタ更新
                // --- UPD m.suzuki 2010/08/18 ---------->>>>>
                //if (custDmdPrcUpdateWork.ProcCntntsFlag == 2)
                if ( custDmdPrcUpdateWork.ProcCntntsFlag == 2 || executeLock == false )
                // --- UPD m.suzuki 2010/08/18 ----------<<<<<
                {
                    ShareCheckInfo info = new ShareCheckInfo();

                    #region 排他制御
                    // --- UPD m.suzuki 2010/08/18 ---------->>>>>
                    //if (custDmdPrcUpdateWork.AddUpSecCode == "00" || custDmdPrcUpdateWork.AddUpSecCode == "")
                    //{
                    //    //システムロック(企業)
                    //    info.Keys.Add(custDmdPrcUpdateWork.EnterpriseCode, ShareCheckType.Enterprise, "", "");
                    //    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    //}
                    //else
                    //{
                    //    //システムロック(拠点)
                    //    info.Keys.Add(custDmdPrcUpdateWork.EnterpriseCode, ShareCheckType.Section, custDmdPrcUpdateWork.AddUpSecCode, "");
                    //    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    //}
                    //if (status != 0)
                    //{
                    //    return status = 851;
                    //}

                    if ( executeLock )
                    {
                        string sectionCode = custDmdPrcUpdateWork.AddUpSecCode.Trim();
                        if ( sectionCode == string.Empty )
                        {
                            sectionCode = "00";
                        }

                        // 締次集計ロック(解除する時は締日=99でロックする(判断できない為))
                        // なお、executeLock=falseの場合は元々更新処理した時の締日でロックしたままなので本処理が不要。
                        info.Keys.Add( new ShareCheckKey( custDmdPrcUpdateWork.EnterpriseCode,
                                                          ShareCheckType.AddUpUpdate,
                                                          sectionCode,
                                                          "",
                                                          99,
                                                          ToLongDate( custDmdPrcUpdateWork.AddUpDate ) ) );
                        status = this.ShareCheck( info, LockControl.Locke, sqlConnection, sqlTransaction );
                        if ( status != 0 )
                        {
                            return status;
                        }
                    }
                    else
                    {
                        // 締次ロックしない場合(＝更新処理時にエラーで解除する場合)はstatus初期化
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    // --- UPD m.suzuki 2010/08/18 ----------<<<<<
                    #endregion

                    // ●締更新履歴マスタ更新
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = UpdateDmdCAddUpHisProc(custDmdPrcUpdateWork, ref sqlConnection, ref sqlTransaction);
                    }

                    // ●請求入金データ削除
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = DeleteDmdDepoTotalProc(custDmdPrcUpdateWork, ref sqlConnection, ref sqlTransaction);
                    }

                    //●請求金額マスタ削除
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = DeleteCustDmdPrcProc(custDmdPrcUpdateWork, ref sqlConnection, ref sqlTransaction);
                    }

                    // --- UPD m.suzuki 2010/08/18 ---------->>>>>
                    ////排他制御解除 //2009/1/27 Add sakurai
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                    //}

                    //排他制御解除
                    if ( executeLock )
                    {
                        if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                        {
                            status = this.ShareCheck( info, LockControl.Release, sqlConnection, sqlTransaction );
                        }
                    }
                    // --- UPD m.suzuki 2010/08/18 ----------<<<<<

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        sqlTransaction.Commit();
                    else
                    {
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustDmdPrcDB.Delete");
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

        // --- ADD m.suzuki 2010/08/18 ---------->>>>>
        /// <summary>
        /// 日付変換処理
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int ToLongDate( DateTime dateTime )
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
        // --- ADD m.suzuki 2010/08/18 ----------<<<<<

        #region [DeleteDmdCAddUpHisProc 2008.10.01 DEL]
        /* --- DEL 2008.10.01 ---------->>>>>
        /// <summary>
        /// 締取消を行います(請求締更新履歴マスタ削除)
        /// </summary>
        /// <param name="deleteList">CustDmdPrcWorkParamWork削除List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 締取消を行います(請求締更新履歴マスタ削除)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.23</br>
        private int DeleteDmdCAddUpHisProc(ArrayList deleteList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {

                for (int i = 0; i < deleteList.Count; i++)
                {
                    CustDmdPrcWork custDmdPrcWork = deleteList[i] as CustDmdPrcWork;
                    if (custDmdPrcWork.UpdateStatus == 1) continue;

                    using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM DMDCADDUPHISRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND CADDUPUPDDATERF=@FINDADDUPDATE", sqlConnection, sqlTransaction))
                    {
                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                        // ↓ 2007.11.20 980081 c
                        //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                        // ↑ 2007.11.20 980081 c
                        findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                        findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);

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

        // 2008.07.18 add start ----------------------------------------->>
        /// <summary>
        /// 締取消を行います(請求締更新履歴マスタを更新)
        /// </summary>
        /// <param name="paraWork">CustDmdPrcWorkParamWork更新List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 締取消を行います(請求締更新履歴マスタを更新)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.07.18</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        //private int UpdateDmdCAddUpHisProc(ArrayList paradeleteList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int UpdateDmdCAddUpHisProc(CustDmdPrcUpdateWork paraWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {           
            #region [2008.10.01 DEL]
            /* --- DEL 2008.10.01 ---------->>>>>
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string sqlText = string.Empty;

            sqlText += "UPDATE " + Environment.NewLine;
            sqlText += "DMDCADDUPHISRF " + Environment.NewLine;
            sqlText += "SET " + Environment.NewLine;
            sqlText += "   PROCDIVCDRF=@PROCDIVCD" + Environment.NewLine;
            sqlText += "  ,ERRORSTATUSRF=@ERRORSTATUS" + Environment.NewLine;
            sqlText += "  ,HISTCTLCDRF=@HISTCTLCD" + Environment.NewLine;
            sqlText += "  ,PROCRESULTRF=@PROCRESULT" + Environment.NewLine;
            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
            sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
            sqlText += "    AND CADDUPUPDDATERF=@FINDCADDUPUPDDATE" + Environment.NewLine;

            try
            {
                for (int i = 0; i < deleteList.Count; i++)
                {
                    CustDmdPrcWork custDmdPrcWork = deleteList[i] as CustDmdPrcWork;
                    if (custDmdPrcWork.UpdateStatus == 1) continue;

                    using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                    {
                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDCADDUPUPDDATE", SqlDbType.Int);

                        SqlParameter findParaProcDivCd = sqlCommand.Parameters.Add("@PROCDIVCD", SqlDbType.Int);
                        SqlParameter findParaErrorStatus = sqlCommand.Parameters.Add("@ERRORSTATUS", SqlDbType.Int);
                        SqlParameter findParaHistCtlCd = sqlCommand.Parameters.Add("@HISTCTLCD", SqlDbType.Int);
                        SqlParameter findParaProcResult = sqlCommand.Parameters.Add("@PROCRESULT", SqlDbType.NVarChar);
                        
                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                        findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                        findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);
                        findParaProcDivCd.Value = 1;
                        findParaErrorStatus.Value = 0;
                        findParaHistCtlCd.Value = 1;
                        findParaProcResult.Value = string.Empty;

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
               --- DEL 2008.10.01 ----------<<<<< */
            #endregion

            // --- ADD 2008.10.01 ---------->>>>>
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string sqlText = string.Empty;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            #region 2008.12.10 DEL
            /*
            // ADD 2008.11.18 >>>
            ArrayList deleteList = new ArrayList();
            int UpFlg = 0;
            for (int j = 0; j < paradeleteList.Count; j++)
            {
                UpFlg = 0;
                if (j == 0)
                {
                    deleteList.Add(paradeleteList[j]);
                }
                else
                {
                    for (int k = 0; k < deleteList.Count; k++)
                    {
                        if ((((CustDmdPrcWork)paradeleteList[j]).EnterpriseCode == ((CustDmdPrcWork)deleteList[k]).EnterpriseCode) &&
                           (((CustDmdPrcWork)paradeleteList[j]).AddUpSecCode == ((CustDmdPrcWork)deleteList[k]).AddUpSecCode))
                        {
                            UpFlg = 1;
                            break;
                        }
                    }
                    if (UpFlg == 0)
                    {
                        deleteList.Add(paradeleteList[j]);
                    }
                }
            }
            // ADD 2008.11.18 <<<

            for (int i = 0; i < deleteList.Count; i++)
            {
                DmdCAddUpHisWork _dmdCAddUpHisWork = new DmdCAddUpHisWork();  //検索結果格納用
                CustDmdPrcWork custDmdPrcWork = deleteList[i] as CustDmdPrcWork;
                if (custDmdPrcWork.UpdateStatus == 1) continue;

                //親レコード情報検索 -> 締取消レコードのセット情報に使用
                #region [親レコード情報検索]
                try
                {
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    #region [Select文作成]
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  *" + Environment.NewLine;
                    sqlText += " FROM DMDCADDUPHISRF" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    //sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine; // DEL 2008.10.20
                    sqlText += "  AND CADDUPUPDDATERF=@FINDCADDUPUPDDATE" + Environment.NewLine;
                    sqlText += "  AND PROCDIVCDRF=0" + Environment.NewLine;
                    sqlText += "  AND HISTCTLCDRF=0" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Select文作成]

                    sqlCommand.Parameters.Clear();

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    //SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int); // DEL 2008.10.20
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDCADDUPUPDDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                    //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode); // DEL 2008.10.20
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        _dmdCAddUpHisWork = CopyToDmdCAddUpHisWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        throw new Exception("取消対象の親レコードがありません。");
                    }
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
                #endregion  //[親レコード情報検索]

                if (!myReader.IsClosed) myReader.Close();
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) throw new Exception("請求締更新履歴マスタ読込失敗。");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                //締取消レコードINSERT -> 検索した親レコードの情報を使用して取消レコードをINSERT
                #region [締取消レコードINSERT]
                try
                {
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    #region [Insert文作成]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO DMDCADDUPHISRF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
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
                    sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
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
                    IFileHeader flhd = (IFileHeader)_dmdCAddUpHisWork;
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
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
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
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(_dmdCAddUpHisWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(_dmdCAddUpHisWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_dmdCAddUpHisWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(_dmdCAddUpHisWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(_dmdCAddUpHisWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(_dmdCAddUpHisWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(_dmdCAddUpHisWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(_dmdCAddUpHisWork.LogicalDeleteCode);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(_dmdCAddUpHisWork.AddUpSecCode);
                    //paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(_dmdCAddUpHisWork.CustomerCode); // DEL 2008.10.20
                    paraCustomerCode.Value = 0; // ADD 2008.10.20
                    paraStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_dmdCAddUpHisWork.StartCAddUpUpdDate);
                    paraCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_dmdCAddUpHisWork.CAddUpUpdDate);
                    paraCAddUpUpdYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_dmdCAddUpHisWork.CAddUpUpdYearMonth);
                    paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_dmdCAddUpHisWork.CAddUpUpdExecDate);
                    paraLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_dmdCAddUpHisWork.LastCAddUpUpdDate);
                    paraDataUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(_dmdCAddUpHisWork.CreateDateTime);
                    paraErrorStatus.Value = SqlDataMediator.SqlSetInt32(_dmdCAddUpHisWork.ErrorStatus);
                    paraProcResult.Value = SqlDataMediator.SqlSetString(_dmdCAddUpHisWork.ProcResult);
                    paraConvertProcessDivCd.Value = SqlDataMediator.SqlSetInt32(_dmdCAddUpHisWork.ConvertProcessDivCd);
                    paraProcDivCd.Value = 1;
                    paraHistCtlCd.Value = 1;
                    #endregion  //Parameterオブジェクトへ値設定

                    sqlCommand.ExecuteNonQuery();

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
                    sqlText += "   DMDCADDUPHISRF " + Environment.NewLine;
                    sqlText += " SET " + Environment.NewLine;
                    sqlText += "  HISTCTLCDRF=1" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    //sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine; // DEL 2008.10.20
                    sqlText += "  AND CADDUPUPDDATERF=@FINDCADDUPUPDDATE" + Environment.NewLine;
                    sqlText += "  AND PROCDIVCDRF=0" + Environment.NewLine;
                    sqlText += "  AND HISTCTLCDRF=0" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Update文作成]

                    sqlCommand.Parameters.Clear();

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    //SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int); // DEL 2008.10.20
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDCADDUPUPDDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                    //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode); // DEL 2008.10.20
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
                #endregion  //[親レコードUPDATE]

            }

            // --- ADD 2008.10.01 ----------<<<<<
            */
            #endregion

            // ADD 2008.12.10 >>>
            DmdCAddUpHisWork _dmdCAddUpHisWork = new DmdCAddUpHisWork();  //検索結果格納用
            ArrayList _dmdCAddUpHisWorkList = new ArrayList();

            //親レコード情報検索 -> 締取消レコードのセット情報に使用
            #region [親レコード情報検索]
            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                #region [Select文作成]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  *" + Environment.NewLine;
                // --- UPD T.Nishi 2012/02/15 ---------->>>>>
                //sqlText += " FROM DMDCADDUPHISRF" + Environment.NewLine;
                sqlText += " FROM DMDCADDUPHISRF WITH(READUNCOMMITTED) " + Environment.NewLine;
                // --- UPD T.Nishi 2012/02/15 ----------<<<<<
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CADDUPUPDDATERF=@FINDCADDUPUPDDATE" + Environment.NewLine;
                sqlText += "  AND PROCDIVCDRF=0" + Environment.NewLine;
                sqlText += "  AND HISTCTLCDRF=0" + Environment.NewLine;
                // 2009.04.02 全拠点締対応 >>>
                if (paraWork.AddUpSecCode != "00" && paraWork.AddUpSecCode != "")
                {
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                }
                // 2009.04.02 <<<

                sqlCommand.CommandText = sqlText;
                #endregion  //[Select文作成]

                sqlCommand.Parameters.Clear();

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDCADDUPUPDDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.AddUpDate);

                // 2009.04.02 全拠点締対応 >>>
                if (paraWork.AddUpSecCode != "00" && paraWork.AddUpSecCode != "")
                {
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(paraWork.AddUpSecCode);
                }
                // 2009.04.02 <<<

                myReader = sqlCommand.ExecuteReader();
                // 修正 2009.04.02  全拠点締対応>>>
                //if (myReader.Read())
                //{
                //    _dmdCAddUpHisWork = CopyToDmdCAddUpHisWorkFromReader(ref myReader);
                //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //}
                //else
                //{
                //    throw new Exception("取消対象の親レコードがありません。");
                //}
                while (myReader.Read())
                {
                    _dmdCAddUpHisWorkList.Add(CopyToDmdCAddUpHisWorkFromReader(ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (_dmdCAddUpHisWorkList == null || _dmdCAddUpHisWorkList.Count == 0)
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
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) throw new Exception("請求締更新履歴マスタ読込失敗。");
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //締取消レコードINSERT -> 検索した親レコードの情報を使用して取消レコードをINSERT
            #region [締取消レコードINSERT]
            try
            {
                for (int i = 0; i < _dmdCAddUpHisWorkList.Count; i++)
                {
                    _dmdCAddUpHisWork = _dmdCAddUpHisWorkList[i] as DmdCAddUpHisWork;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                    sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                    #region [Insert文作成]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO DMDCADDUPHISRF" + Environment.NewLine;
                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
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
                    sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
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
                    IFileHeader flhd = (IFileHeader)_dmdCAddUpHisWork;
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
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
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
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(_dmdCAddUpHisWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(_dmdCAddUpHisWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_dmdCAddUpHisWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(_dmdCAddUpHisWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(_dmdCAddUpHisWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(_dmdCAddUpHisWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(_dmdCAddUpHisWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(_dmdCAddUpHisWork.LogicalDeleteCode);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(_dmdCAddUpHisWork.AddUpSecCode);
                    paraCustomerCode.Value = 0;
                    paraStartCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_dmdCAddUpHisWork.StartCAddUpUpdDate);
                    paraCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_dmdCAddUpHisWork.CAddUpUpdDate);
                    paraCAddUpUpdYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_dmdCAddUpHisWork.CAddUpUpdYearMonth);
                    paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_dmdCAddUpHisWork.CAddUpUpdExecDate);
                    paraLastCAddUpUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_dmdCAddUpHisWork.LastCAddUpUpdDate);
                    paraDataUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(_dmdCAddUpHisWork.CreateDateTime);
                    paraErrorStatus.Value = SqlDataMediator.SqlSetInt32(_dmdCAddUpHisWork.ErrorStatus);
                    paraProcResult.Value = SqlDataMediator.SqlSetString(_dmdCAddUpHisWork.ProcResult);
                    paraConvertProcessDivCd.Value = SqlDataMediator.SqlSetInt32(_dmdCAddUpHisWork.ConvertProcessDivCd);
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
                sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                #region [Update文作成]
                sqlText = string.Empty;
                sqlText += "UPDATE " + Environment.NewLine;
                sqlText += "   DMDCADDUPHISRF " + Environment.NewLine;
                sqlText += " SET " + Environment.NewLine;
                sqlText += "  HISTCTLCDRF=1" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CADDUPUPDDATERF=@FINDCADDUPUPDDATE" + Environment.NewLine;
                sqlText += "  AND PROCDIVCDRF=0" + Environment.NewLine;
                sqlText += "  AND HISTCTLCDRF=0" + Environment.NewLine;

                // 修正 2009.04.02 全拠点締対応 >>>
                if (paraWork.AddUpSecCode != "00" && paraWork.AddUpSecCode != "")
                {
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                }
                // 修正 2009.04.02 全拠点締対応 <<<

                sqlCommand.CommandText = sqlText;
                #endregion  //[Update文作成]

                sqlCommand.Parameters.Clear();

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDCADDUPUPDDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.AddUpDate);

                // 2009.04.02 全拠点締対応 >>>
                if (paraWork.AddUpSecCode != "00" && paraWork.AddUpSecCode != "")
                {
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(paraWork.AddUpSecCode);
                }
                // 2009.04.02 全拠点締対応 <<<

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            #endregion  //[親レコードUPDATE]
            // ADD 2008.12.10 <<<

            return status;
        }
        // 2008.07.18 add end -------------------------------------------<<

        /// <summary>
        /// 締取消を行います(得意先請求金額マスタ削除)
        /// </summary>
        /// <param name="paraWork">CustDmdPrcWorkParamWork削除List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 締取消を行います(得意先請求金額マスタ削除)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.23</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        //private int DeleteCustDmdPrcProc(ArrayList deleteList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int DeleteCustDmdPrcProc(CustDmdPrcUpdateWork paraWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            #region 2008.12.10 DEL
            /*
            try
            {

                for (int i = 0; i < deleteList.Count; i++)
                {
                    CustDmdPrcWork custDmdPrcWork = deleteList[i] as CustDmdPrcWork;
                    if (custDmdPrcWork.UpdateStatus == 1) continue;

                    // ↓ 2007.11.20 980081 c
                    //using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM CUSTDMDPRCRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND ADDUPDATERF=@FINDADDUPDATE", sqlConnection, sqlTransaction))
                    using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM CUSTDMDPRCRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CLAIMCODERF=@FINDCUSTOMERCODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND ADDUPDATERF=@FINDADDUPDATE", sqlConnection, sqlTransaction))
                    // ↑ 2007.11.20 980081 c
                    {
                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                        // ↓ 2007.11.20 980081 c
                        //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                        // ↑ 2007.11.20 980081 c
                        findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                        findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);

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
            */
            #endregion

            try
            {
                String sqlText = String.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += " FROM CUSTDMDPRCRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "        AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                // 修正 2009.04.02 全社締対応 >>>
                if (paraWork.AddUpSecCode != "00" && paraWork.AddUpSecCode != "")
                {
                    sqlText += "        AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                }
                // 修正 2009.04.02 <<<

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.AddUpDate);

                    // 修正 2009.04.02 全社締対応 >>>
                    if (paraWork.AddUpSecCode != "00" && paraWork.AddUpSecCode != "")
                    {
                        SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                        findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(paraWork.AddUpSecCode);
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

        // ADD 2008.12.10 >>>
        /// <summary>
        /// 締取消を行います(得意先請求入金集計データ削除)
        /// </summary>
        /// <param name="paraWork">CustDmdPrcWorkParamWork削除List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 締取消を行います(得意先請求入金集計データ削除)</br>
        /// <br>Programmer : 23012　畠中 啓次朗</br>
        /// <br>Date       : 2008.12.10</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        //private int DeleteDmdDepoTotalProc(ArrayList deleteList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int DeleteDmdDepoTotalProc(CustDmdPrcUpdateWork paraWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                String sqlText = String.Empty;
                sqlText = String.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += " FROM DMDDEPOTOTALRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "        AND ADDUPDATERF=@FINDADDUPDATE" + Environment.NewLine;

                // 修正 2009.04.02 全拠点締対応>>>
                if (paraWork.AddUpSecCode != "00" && paraWork.AddUpSecCode != "")
                {
                    sqlText += "        AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                }
                // 修正 2009.04.02 <<<

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.AddUpDate);

                    // 修正 2009.04.02 全拠点締対応 >>>
                    if (paraWork.AddUpSecCode != "00" && paraWork.AddUpSecCode != "")
                    {
                        SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                        findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(paraWork.AddUpSecCode);
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

        // ADD 2008.12.10 <<<

        /// <summary>
        /// 締次更新年月日をチェックします
        /// </summary>
        /// <param name="custDmdPrcWork">請求締取消List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 締次更新年月日をチェックします</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.26</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        private int CheckCAddUpUpdDate(ref CustDmdPrcWork custDmdPrcWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                    #region [2008.10.01 DEL]
                    /* --- DEL 2008.10.01 ---------->>>>>
                    // del 2007.04.12 Saitoh >>>>>>>>>>
                    //sqlCommand.CommandText = "SELECT MAX(CADDUPUPDDATERF) AS MAXCADDUPUPDDATE FROM DMDCADDUPHISRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ADDUPSECCODERF=@FINDADDUPSECCODE ";
                    // del 2007.04.12 Saitoh <<<<<<<<<<

                    // add 2007.04.12 Saitoh >>>>>>>>>>
                    sqlCommand.CommandText = "SELECT MAX(CADDUPUPDDATERF) AS MAXCADDUPUPDDATE FROM DMDCADDUPHISRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ADDUPSECCODERF=@FINDADDUPSECCODE ";
                    // add 2007.04.12 Saitoh <<<<<<<<<<
                    
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    // ↓ 2007.11.20 980081 c
                    //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode);
                    // ↑ 2007.11.20 980081 c
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                       --- DEL 2008.10.01 ----------<<<<< */
                    #endregion

                    // --- ADD 2008.10.01 ---------->>>>>
                    #region [Select文作成]
                    string sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  MAX(CADDUPUPDDATERF) AS MAXCADDUPUPDDATE" + Environment.NewLine;
                    sqlText += " FROM DMDCADDUPHISRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    //sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine; // DEL 2008.10.20
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "  AND PROCDIVCDRF=0" + Environment.NewLine;
                    sqlText += "  AND HISTCTLCDRF=0" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Select文作成]

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int); // DEL 2008.10.20
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.ClaimCode); // DEL 2008.10.20
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.AddUpSecCode);
                    // --- ADD 2008.10.01 ----------<<<<<

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //検索結果を戻す
                        custDmdPrcWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MAXCADDUPUPDDATE"));

                        if (custDmdPrcWork.AddUpDate == DateTime.MinValue)
                        {
                            custDmdPrcWork.UpdateStatus = 1;
                        }
                        else
                        {
                            if (custDmdPrcWork.UpdateStatus != 1)
                                custDmdPrcWork.UpdateStatus = 0;
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        //検索結果がない場合は初期データなので最小値を挿入
                        custDmdPrcWork.UpdateStatus = 1;
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
        /// 得意先マスタ　クラス格納処理 Reader → CustomerWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustomerWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.15</br>
        /// </remarks>
        private CustomerWork CopyToCustomerWorkFromReader(ref SqlDataReader myReader)
        {
            CustomerWork wkCustomerWork = new CustomerWork();

            #region クラスへ格納
            wkCustomerWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCustomerWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkCustomerWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
            wkCustomerWork.Name2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
            wkCustomerWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkCustomerWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            // ADD 2008.12.10 >>>
            wkCustomerWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            wkCustomerWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            wkCustomerWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMCUSTOMERSNMRF"));
            wkCustomerWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
            wkCustomerWork.CollectMoneyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));
            wkCustomerWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
            // ADD 2008.12.10 <<<
            wkCustomerWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
            wkCustomerWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            wkCustomerWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
            wkCustomerWork.TotalAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMNTDSPWAYREFRF"));
            wkCustomerWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
            wkCustomerWork.AcceptWholeSale = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTWHOLESALERF"));
            wkCustomerWork.ClaimSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));
            #endregion

            return wkCustomerWork;
        }

        /// <summary>
        /// 得意先請求金額マスタ　クラス格納処理 Reader → CustDmdPrcWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustDmdPrcWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.19</br>
        /// </remarks>
        private CustDmdPrcWork CopyToCustDmdPrcWorkFromReader(ref SqlDataReader myReader)
        {
            CustDmdPrcWork wkCustDmdPrcWork = new CustDmdPrcWork();

            #region クラスへ格納
            wkCustDmdPrcWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkCustDmdPrcWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkCustDmdPrcWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCustDmdPrcWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkCustDmdPrcWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkCustDmdPrcWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkCustDmdPrcWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkCustDmdPrcWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkCustDmdPrcWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkCustDmdPrcWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkCustDmdPrcWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            wkCustDmdPrcWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            wkCustDmdPrcWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkCustDmdPrcWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkCustDmdPrcWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            wkCustDmdPrcWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            wkCustDmdPrcWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkCustDmdPrcWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkCustDmdPrcWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            wkCustDmdPrcWork.LastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEDEMANDRF"));
            wkCustDmdPrcWork.ThisTimeFeeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDNRMLRF"));
            wkCustDmdPrcWork.ThisTimeDisDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDNRMLRF"));
            wkCustDmdPrcWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
            wkCustDmdPrcWork.ThisTimeTtlBlcDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCDMDRF"));
            wkCustDmdPrcWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
            wkCustDmdPrcWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
            wkCustDmdPrcWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));
            wkCustDmdPrcWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));
            wkCustDmdPrcWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF"));
            wkCustDmdPrcWork.OffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETOUTTAXRF"));
            wkCustDmdPrcWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));
            wkCustDmdPrcWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));
            wkCustDmdPrcWork.ThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESTAXRF"));
            wkCustDmdPrcWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
            wkCustDmdPrcWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
            wkCustDmdPrcWork.ItdedSalesTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESTAXFREERF"));
            wkCustDmdPrcWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));
            wkCustDmdPrcWork.SalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESINTAXRF"));
            wkCustDmdPrcWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));
            wkCustDmdPrcWork.ThisSalesPrcTaxRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXRGDSRF"));
            wkCustDmdPrcWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));
            wkCustDmdPrcWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));
            wkCustDmdPrcWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));
            wkCustDmdPrcWork.TtlRetOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETOUTERTAXRF"));
            wkCustDmdPrcWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));
            wkCustDmdPrcWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));
            wkCustDmdPrcWork.ThisSalesPrcTaxDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRCTAXDISRF"));
            wkCustDmdPrcWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));
            wkCustDmdPrcWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));
            wkCustDmdPrcWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));
            wkCustDmdPrcWork.TtlDisOuterTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISOUTERTAXRF"));
            wkCustDmdPrcWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));
            wkCustDmdPrcWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            wkCustDmdPrcWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            wkCustDmdPrcWork.AfCalDemandPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"));
            wkCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"));
            wkCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFBLDMDRF"));
            wkCustDmdPrcWork.CAddUpUpdExecDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDEXECDATERF"));
            wkCustDmdPrcWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STARTCADDUPUPDDATERF"));
            wkCustDmdPrcWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTCADDUPUPDDATERF"));
            wkCustDmdPrcWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));
            wkCustDmdPrcWork.BillPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("BILLPRINTDATERF"));
            wkCustDmdPrcWork.ExpectedDepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EXPECTEDDEPOSITDATERF"));
            wkCustDmdPrcWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
            wkCustDmdPrcWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            wkCustDmdPrcWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
            wkCustDmdPrcWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
            #endregion

            return wkCustDmdPrcWork;
        }

        /// <summary>
        /// 入金マスタ　クラス格納処理 Reader → DepsitMainWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>DepsitMainWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.19</br>
        /// </remarks>
        private DepsitMainWork CopyToDepsitMainWorkFromReader(ref SqlDataReader myReader)
        {
            DepsitMainWork wkDepsitMainWork = new DepsitMainWork();

            #region クラスへ格納
            // 修正 2008.12.10 未使用項目を削除 >>>
            #region 2008.12.10 DEL
            /*
            wkDepsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkDepsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkDepsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkDepsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkDepsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkDepsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkDepsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkDepsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkDepsitMainWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            wkDepsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
            wkDepsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
            wkDepsitMainWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            wkDepsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
            wkDepsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkDepsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
            wkDepsitMainWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            wkDepsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
            wkDepsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            wkDepsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"));
            wkDepsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
            wkDepsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));
            wkDepsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
            wkDepsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
            wkDepsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
            wkDepsitMainWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
            wkDepsitMainWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
            wkDepsitMainWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
            wkDepsitMainWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
            wkDepsitMainWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
            wkDepsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));
            wkDepsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
            wkDepsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
            wkDepsitMainWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
            wkDepsitMainWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTCDRF"));
            wkDepsitMainWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));
            wkDepsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkDepsitMainWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            wkDepsitMainWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            wkDepsitMainWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkDepsitMainWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkDepsitMainWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            wkDepsitMainWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            wkDepsitMainWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkDepsitMainWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
            wkDepsitMainWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
            wkDepsitMainWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
            */
            #endregion
            //wkDepsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkDepsitMainWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));        
            //wkDepsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF")); // DEL 2008.12.10
            wkDepsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"));
            wkDepsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));
            wkDepsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));                        
            // 修正 2008.12.10 <<<

            #endregion

            return wkDepsitMainWork;
        }

        // 2008.07.18 add start --------------------------------------->>
        /// <summary>
        /// 請求入金集計データ クラス格納処理 Reader → DmdDepoTotalWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>DmdDepoTotalWork</returns>
        /// <remarks>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.07.18</br>
        /// </remarks>
        private DmdDepoTotalWork CopyToDmdDepoTotalWorkFromReader(ref SqlDataReader myReader)
        {
            DmdDepoTotalWork wkDmdDepoTotalWork = new DmdDepoTotalWork();

            #region クラスへ格納
            // 修正 2008.12.10 >>>
            #region 2008.12.10 DEL
            /*
            wkDmdDepoTotalWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkDmdDepoTotalWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkDmdDepoTotalWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkDmdDepoTotalWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkDmdDepoTotalWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkDmdDepoTotalWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkDmdDepoTotalWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkDmdDepoTotalWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkDmdDepoTotalWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkDmdDepoTotalWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkDmdDepoTotalWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkDmdDepoTotalWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            wkDmdDepoTotalWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            wkDmdDepoTotalWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            wkDmdDepoTotalWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            wkDmdDepoTotalWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
            */
            #endregion
            wkDmdDepoTotalWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF")); // DEL 2008.12.10
            //wkDmdDepoTotalWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkDmdDepoTotalWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
            wkDmdDepoTotalWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
            wkDmdDepoTotalWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
            wkDmdDepoTotalWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
            // 修正 2008.12.10 <<<

            #endregion

            return wkDmdDepoTotalWork;
        }
        // 2008.07.18 add end -----------------------------------------<<

        /// <summary>
        /// 売上データ　クラス格納処理 Reader → SalesSlipWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesSlipWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.19</br>
        /// </remarks>
        private SalesSlipWork CopyToSalesSlipWorkFromReader(ref SqlDataReader myReader)
        {
            SalesSlipWork wkSalesSlipWork = new SalesSlipWork();

            #region クラスへ格納

            # region [--- DEL 2008/12/02 M.Kubota ---]
            //wkSalesSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            //wkSalesSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            //wkSalesSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            //wkSalesSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            //wkSalesSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            //wkSalesSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            //wkSalesSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            //wkSalesSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //wkSalesSlipWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            //wkSalesSlipWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            //wkSalesSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            //wkSalesSlipWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            //wkSalesSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            //wkSalesSlipWork.DebitNLnkSalesSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEBITNLNKSALESSLNUMRF"));
            //wkSalesSlipWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
            //wkSalesSlipWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
            //wkSalesSlipWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
            //wkSalesSlipWork.SalesInpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPSECCDRF"));
            //wkSalesSlipWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
            //wkSalesSlipWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
            //wkSalesSlipWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
            //wkSalesSlipWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
            //wkSalesSlipWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
            //wkSalesSlipWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            //wkSalesSlipWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            //wkSalesSlipWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
            //wkSalesSlipWork.EstimateFormNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATEFORMNORF"));
            //wkSalesSlipWork.EstimateDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEDIVIDERF"));
            //wkSalesSlipWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
            //wkSalesSlipWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
            //wkSalesSlipWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
            //wkSalesSlipWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
            //wkSalesSlipWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
            //wkSalesSlipWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
            //wkSalesSlipWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
            //wkSalesSlipWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
            //wkSalesSlipWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
            //wkSalesSlipWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
            //wkSalesSlipWork.SalesSubtotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));
            //wkSalesSlipWork.SalesSubtotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));
            //wkSalesSlipWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
            //wkSalesSlipWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
            //wkSalesSlipWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
            //wkSalesSlipWork.SalSubttlSubToTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALSUBTTLSUBTOTAXFRERF"));
            //wkSalesSlipWork.SalAmntConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALAMNTCONSTAXINCLURF"));
            //wkSalesSlipWork.SalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXEXCRF"));
            //wkSalesSlipWork.ItdedSalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISOUTTAXRF"));
            //wkSalesSlipWork.ItdedSalesDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISINTAXRF"));
            //wkSalesSlipWork.SalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISOUTTAXRF"));
            //wkSalesSlipWork.SalesDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXINCLURF"));
            //wkSalesSlipWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
            //wkSalesSlipWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            //wkSalesSlipWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
            //wkSalesSlipWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
            //wkSalesSlipWork.AccRecConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCRECCONSTAXRF"));
            //wkSalesSlipWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
            //wkSalesSlipWork.AutoDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITSLIPNORF"));
            //wkSalesSlipWork.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
            //wkSalesSlipWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
            //wkSalesSlipWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            //wkSalesSlipWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            //wkSalesSlipWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            //wkSalesSlipWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            //wkSalesSlipWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            //wkSalesSlipWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            //wkSalesSlipWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
            //wkSalesSlipWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
            //wkSalesSlipWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));
            //wkSalesSlipWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
            //wkSalesSlipWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
            //wkSalesSlipWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
            //wkSalesSlipWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
            //wkSalesSlipWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
            //wkSalesSlipWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
            //wkSalesSlipWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
            //wkSalesSlipWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
            //wkSalesSlipWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
            //wkSalesSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            //wkSalesSlipWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
            //wkSalesSlipWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
            //wkSalesSlipWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
            //wkSalesSlipWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
            //wkSalesSlipWork.RegiProcDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REGIPROCDATERF"));
            //wkSalesSlipWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
            //wkSalesSlipWork.PosReceiptNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSRECEIPTNORF"));
            //wkSalesSlipWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
            //wkSalesSlipWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
            //wkSalesSlipWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
            //wkSalesSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            //wkSalesSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            //wkSalesSlipWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
            //wkSalesSlipWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
            //wkSalesSlipWork.SalesSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESSLIPPRINTDATERF"));
            //wkSalesSlipWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            //wkSalesSlipWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
            //wkSalesSlipWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
            //wkSalesSlipWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));
            //wkSalesSlipWork.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVNMRF"));
            //wkSalesSlipWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            //wkSalesSlipWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
            //wkSalesSlipWork.ReconcileFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECONCILEFLAGRF"));
            //wkSalesSlipWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
            //wkSalesSlipWork.CompleteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPLETECDRF"));
            //wkSalesSlipWork.SalesPriceFracProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESPRICEFRACPROCCDRF"));
            //wkSalesSlipWork.StockGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKGOODSTTLTAXEXCRF"));
            //wkSalesSlipWork.PureGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PUREGOODSTTLTAXEXCRF"));
            //wkSalesSlipWork.ListPricePrintDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEPRINTDIVRF"));
            //wkSalesSlipWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
            //wkSalesSlipWork.EstimaTaxDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATAXDIVCDRF"));
            //wkSalesSlipWork.EstimateFormPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEFORMPRTCDRF"));
            //wkSalesSlipWork.EstimateSubject = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATESUBJECTRF"));
            //wkSalesSlipWork.Footnotes1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOOTNOTES1RF"));
            //wkSalesSlipWork.Footnotes2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOOTNOTES2RF"));
            //wkSalesSlipWork.EstimateTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE1RF"));
            //wkSalesSlipWork.EstimateTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE2RF"));
            //wkSalesSlipWork.EstimateTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE3RF"));
            //wkSalesSlipWork.EstimateTitle4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE4RF"));
            //wkSalesSlipWork.EstimateTitle5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE5RF"));
            //wkSalesSlipWork.EstimateNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE1RF"));
            //wkSalesSlipWork.EstimateNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE2RF"));
            //wkSalesSlipWork.EstimateNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE3RF"));
            //wkSalesSlipWork.EstimateNote4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE4RF"));
            //wkSalesSlipWork.EstimateNote5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE5RF"));
            # endregion

            //--- ADD 2008/12/02 M.Kubota --->>>
            wkSalesSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));                 // 作成日時
            wkSalesSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));                 // 更新日時
            wkSalesSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                            // 企業コード
            wkSalesSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                              // GUID
            wkSalesSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));                          // 更新従業員コード
            wkSalesSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                            // 更新アセンブリID1
            wkSalesSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                            // 更新アセンブリID2
            wkSalesSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));                       // 論理削除区分
            wkSalesSlipWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));                           // 受注ステータス
            wkSalesSlipWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));                                // 売上伝票番号
            wkSalesSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));                                  // 拠点コード
            wkSalesSlipWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));                             // 部門コード
            wkSalesSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));                                 // 赤伝区分
            wkSalesSlipWork.DebitNLnkSalesSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEBITNLNKSALESSLNUMRF"));                  // 赤黒連結売上伝票番号
            wkSalesSlipWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));                                   // 売上伝票区分
            wkSalesSlipWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));                                 // 売上商品区分
            wkSalesSlipWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));                                   // 売掛区分
            wkSalesSlipWork.SalesInpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPSECCDRF"));                              // 売上入力拠点コード
            wkSalesSlipWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));                        // 請求計上拠点コード
            wkSalesSlipWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));                      // 実績計上拠点コード
            wkSalesSlipWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));                                  // 更新拠点コード
            wkSalesSlipWork.SalesSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPUPDATECDRF"));                       // 売上伝票更新区分
            wkSalesSlipWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));              // 伝票検索日付
            wkSalesSlipWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));                    // 出荷日付
            wkSalesSlipWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));                        // 売上日付
            wkSalesSlipWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));                      // 計上日付
            wkSalesSlipWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));                           // 来勘区分
            wkSalesSlipWork.EstimateFormNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATEFORMNORF"));                            // 見積書番号
            wkSalesSlipWork.EstimateDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEDIVIDERF"));                             // 見積区分
            wkSalesSlipWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));                                  // 入力担当者コード
            wkSalesSlipWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));                                  // 入力担当者名称
            wkSalesSlipWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));                            // 売上入力者コード
            wkSalesSlipWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));                            // 売上入力者名称
            wkSalesSlipWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));                          // 受付従業員コード
            wkSalesSlipWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));                          // 受付従業員名称
            wkSalesSlipWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));                          // 販売従業員コード
            wkSalesSlipWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));                          // 販売従業員名称
            wkSalesSlipWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));                 // 総額表示方法区分
            wkSalesSlipWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));                     // 総額表示掛率適用区分
            wkSalesSlipWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));                         // 売上伝票合計（税込み）
            wkSalesSlipWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));                         // 売上伝票合計（税抜き）
            wkSalesSlipWork.SalesPrtTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTTOTALTAXINCRF"));                   // 売上部品合計（税込み）
            wkSalesSlipWork.SalesPrtTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTTOTALTAXEXCRF"));                   // 売上部品合計（税抜き）
            wkSalesSlipWork.SalesWorkTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKTOTALTAXINCRF"));                 // 売上作業合計（税込み）
            wkSalesSlipWork.SalesWorkTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKTOTALTAXEXCRF"));                 // 売上作業合計（税抜き）
            wkSalesSlipWork.SalesSubtotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));                   // 売上小計（税込み）
            wkSalesSlipWork.SalesSubtotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));                   // 売上小計（税抜き）
            wkSalesSlipWork.SalesPrtSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTSUBTTLINCRF"));                       // 売上部品小計（税込み）
            wkSalesSlipWork.SalesPrtSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTSUBTTLEXCRF"));                       // 売上部品小計（税抜き）
            wkSalesSlipWork.SalesWorkSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKSUBTTLINCRF"));                     // 売上作業小計（税込み）
            wkSalesSlipWork.SalesWorkSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKSUBTTLEXCRF"));                     // 売上作業小計（税抜き）
            wkSalesSlipWork.SalesNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESNETPRICERF"));                               // 売上正価金額
            wkSalesSlipWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));                         // 売上小計（税）
            wkSalesSlipWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));                         // 売上外税対象額
            wkSalesSlipWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));                           // 売上内税対象額
            wkSalesSlipWork.SalSubttlSubToTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALSUBTTLSUBTOTAXFRERF"));                 // 売上小計非課税対象額
            wkSalesSlipWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));                                   // 売上金額消費税額（外税）
            wkSalesSlipWork.SalAmntConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALAMNTCONSTAXINCLURF"));                   // 売上金額消費税額（内税）
            wkSalesSlipWork.SalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXEXCRF"));                       // 売上値引金額計（税抜き）
            wkSalesSlipWork.ItdedSalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISOUTTAXRF"));                   // 売上値引外税対象額合計
            wkSalesSlipWork.ItdedSalesDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISINTAXRF"));                     // 売上値引内税対象額合計
            wkSalesSlipWork.ItdedPartsDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPARTSDISOUTTAXRF"));                   // 部品値引対象額合計（税抜き）
            wkSalesSlipWork.ItdedPartsDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPARTSDISINTAXRF"));                     // 部品値引対象額合計（税込み）
            wkSalesSlipWork.ItdedWorkDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDWORKDISOUTTAXRF"));                     // 作業値引対象額合計（税抜き）
            wkSalesSlipWork.ItdedWorkDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDWORKDISINTAXRF"));                       // 作業値引対象額合計（税込み）
            wkSalesSlipWork.ItdedSalesDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISTAXFRERF"));                   // 売上値引非課税対象額合計
            wkSalesSlipWork.SalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISOUTTAXRF"));                             // 売上値引消費税額（外税）
            wkSalesSlipWork.SalesDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXINCLURF"));                   // 売上値引消費税額（内税）
            wkSalesSlipWork.PartsDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSDISCOUNTRATERF"));                      // 部品値引率
            wkSalesSlipWork.RavorDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RAVORDISCOUNTRATERF"));                      // 工賃値引率
            wkSalesSlipWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));                                       // 原価金額計
            wkSalesSlipWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));                         // 消費税転嫁方式
            wkSalesSlipWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));                                  // 消費税税率
            wkSalesSlipWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));                             // 端数処理区分
            wkSalesSlipWork.AccRecConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCRECCONSTAXRF"));                               // 売掛消費税
            wkSalesSlipWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));                               // 自動入金区分
            wkSalesSlipWork.AutoDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITSLIPNORF"));                       // 自動入金伝票番号
            wkSalesSlipWork.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));                   // 入金引当合計額
            wkSalesSlipWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));                         // 入金引当残高
            wkSalesSlipWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));                                       // 請求先コード
            wkSalesSlipWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));                                        // 請求先略称
            wkSalesSlipWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));                                 // 得意先コード
            wkSalesSlipWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));                                // 得意先名称
            wkSalesSlipWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));                              // 得意先名称2
            wkSalesSlipWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));                                  // 得意先略称
            wkSalesSlipWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));                            // 敬称
            wkSalesSlipWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));                             // 諸口コード
            wkSalesSlipWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));                                    // 諸口名称
            wkSalesSlipWork.CustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNORF"));                                     // 得意先伝票番号
            wkSalesSlipWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));                             // 伝票住所区分
            wkSalesSlipWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));                               // 納品先コード
            wkSalesSlipWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));                              // 納品先名称
            wkSalesSlipWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));                            // 納品先名称2
            wkSalesSlipWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));                          // 納品先郵便番号
            wkSalesSlipWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));                            // 納品先住所1(都道府県市区郡・町村・字)
            wkSalesSlipWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));                            // 納品先住所3(番地)
            wkSalesSlipWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));                            // 納品先住所4(アパート名称)
            wkSalesSlipWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));                            // 納品先電話番号
            wkSalesSlipWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));                            // 納品先FAX番号
            wkSalesSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));                        // 相手先伝票番号
            wkSalesSlipWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));                                        // 伝票備考
            wkSalesSlipWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));                                      // 伝票備考２
            wkSalesSlipWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));                                      // 伝票備考３
            wkSalesSlipWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));                       // 返品理由コード
            wkSalesSlipWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));                            // 返品理由
            wkSalesSlipWork.RegiProcDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REGIPROCDATERF"));                  // レジ処理日
            wkSalesSlipWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));                             // レジ番号
            wkSalesSlipWork.PosReceiptNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSRECEIPTNORF"));                                 // POSレシート番号
            wkSalesSlipWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));                             // 明細行数
            wkSalesSlipWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));                    // ＥＤＩ送信日
            wkSalesSlipWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));                // ＥＤＩ取込日
            wkSalesSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));                                    // ＵＯＥリマーク１
            wkSalesSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));                                    // ＵＯＥリマーク２
            wkSalesSlipWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));                             // 伝票発行区分
            wkSalesSlipWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));                       // 伝票発行済区分
            wkSalesSlipWork.SalesSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESSLIPPRINTDATERF"));      // 売上伝票発行日
            wkSalesSlipWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));                         // 業種コード
            wkSalesSlipWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));                        // 業種名称
            wkSalesSlipWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));                                  // 発注番号
            wkSalesSlipWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));                       // 納品区分
            wkSalesSlipWork.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVNMRF"));                  // 納品区分名称
            wkSalesSlipWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));                               // 販売エリアコード
            wkSalesSlipWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));                              // 販売エリア名称
            wkSalesSlipWork.ReconcileFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECONCILEFLAGRF"));                               // 消込フラグ
            wkSalesSlipWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));                      // 伝票印刷設定用帳票ID
            wkSalesSlipWork.CompleteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPLETECDRF"));                                     // 一式伝票区分
            wkSalesSlipWork.SalesPriceFracProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESPRICEFRACPROCCDRF"));                 // 売上金額端数処理区分
            wkSalesSlipWork.StockGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKGOODSTTLTAXEXCRF"));                   // 在庫商品合計金額（税抜）
            wkSalesSlipWork.PureGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PUREGOODSTTLTAXEXCRF"));                     // 純正商品合計金額（税抜）
            wkSalesSlipWork.ListPricePrintDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEPRINTDIVRF"));                       // 定価印刷区分
            wkSalesSlipWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));                             // 元号表示区分１
            wkSalesSlipWork.EstimaTaxDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATAXDIVCDRF"));                             // 見積消費税区分
            wkSalesSlipWork.EstimateFormPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEFORMPRTCDRF"));                       // 見積書印刷区分
            wkSalesSlipWork.EstimateSubject = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATESUBJECTRF"));                          // 見積件名
            wkSalesSlipWork.Footnotes1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOOTNOTES1RF"));                                    // 脚注１
            wkSalesSlipWork.Footnotes2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOOTNOTES2RF"));                                    // 脚注２
            wkSalesSlipWork.EstimateTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE1RF"));                            // 見積タイトル１
            wkSalesSlipWork.EstimateTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE2RF"));                            // 見積タイトル２
            wkSalesSlipWork.EstimateTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE3RF"));                            // 見積タイトル３
            wkSalesSlipWork.EstimateTitle4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE4RF"));                            // 見積タイトル４
            wkSalesSlipWork.EstimateTitle5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE5RF"));                            // 見積タイトル５
            wkSalesSlipWork.EstimateNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE1RF"));                              // 見積備考１
            wkSalesSlipWork.EstimateNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE2RF"));                              // 見積備考２
            wkSalesSlipWork.EstimateNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE3RF"));                              // 見積備考３
            wkSalesSlipWork.EstimateNote4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE4RF"));                              // 見積備考４
            wkSalesSlipWork.EstimateNote5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE5RF"));                              // 見積備考５
            wkSalesSlipWork.EstimateValidityDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ESTIMATEVALIDITYDATERF"));  // 見積有効期限
            wkSalesSlipWork.PartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSNOPRTCDRF"));                                 // 品番印字区分
            wkSalesSlipWork.OptionPringDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPTIONPRINGDIVCDRF"));                         // オプション印字区分
            wkSalesSlipWork.RateUseCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEUSECODERF"));                                   // 掛率使用区分
            //--- ADD 2008/12/02 M.Kubota ---<<<

            #endregion

            return wkSalesSlipWork;
        }

        /// <summary>
        /// 税率設定マスタ　クラス格納処理 Reader → TaxRateSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>TaxRateSetWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.30</br>
        /// </remarks>
        private TaxRateSetWork CopyToTaxRateSetWorkFromReader(ref SqlDataReader myReader)
        {
            TaxRateSetWork wkTaxRateSetWork = new TaxRateSetWork();

            #region クラスへ格納
            wkTaxRateSetWork.TaxRateStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATERF"));
            wkTaxRateSetWork.TaxRateEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATERF"));
            wkTaxRateSetWork.TaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATERF"));
            wkTaxRateSetWork.TaxRateStartDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE2RF"));
            wkTaxRateSetWork.TaxRateEndDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE2RF"));
            wkTaxRateSetWork.TaxRate2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE2RF"));
            wkTaxRateSetWork.TaxRateStartDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE3RF"));
            wkTaxRateSetWork.TaxRateEndDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE3RF"));
            wkTaxRateSetWork.TaxRate3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE3RF"));
            wkTaxRateSetWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHOD_TAXRF"));
            #endregion

            return wkTaxRateSetWork;
        }

        /// <summary>
        /// 請求締更新履歴マスタ　クラス格納処理 Reader → DmdCAddUpHisWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>DmdCAddUpHisWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.30</br>
        /// </remarks>
        private DmdCAddUpHisWork CopyToDmdCAddUpHisWorkFromReader(ref SqlDataReader myReader)
        {
            DmdCAddUpHisWork wkDmdCAddUpHisWork = new DmdCAddUpHisWork();

            #region [2008.10.01 DEL]
            /* --- DEL 2008.10.01 ---------->>>>>
            #region クラスへ格納
            wkDmdCAddUpHisWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkDmdCAddUpHisWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkDmdCAddUpHisWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkDmdCAddUpHisWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkDmdCAddUpHisWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkDmdCAddUpHisWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkDmdCAddUpHisWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkDmdCAddUpHisWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkDmdCAddUpHisWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkDmdCAddUpHisWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkDmdCAddUpHisWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STARTCADDUPUPDDATERF"));
            wkDmdCAddUpHisWork.CAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDDATERF"));
            wkDmdCAddUpHisWork.CAddUpUpdYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("CADDUPUPDYEARMONTHRF"));
            wkDmdCAddUpHisWork.CAddUpUpdExecDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDEXECDATERF"));
            wkDmdCAddUpHisWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTCADDUPUPDDATERF"));
            wkDmdCAddUpHisWork.ProcDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROCDIVCDRF"));
            wkDmdCAddUpHisWork.ErrorStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERRORSTATUSRF"));
            wkDmdCAddUpHisWork.HistCtlCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HISTCTLCDRF"));
            wkDmdCAddUpHisWork.ProcResult = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROCRESULTRF"));
            wkDmdCAddUpHisWork.ConvertProcessDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONVERTPROCESSDIVCDRF"));
            #endregion
               --- DEL 2008.10.01 ----------<<<<< */
            #endregion

            // --- ADD 2008.10.01 ---------->>>>>
            #region クラスへ格納
            wkDmdCAddUpHisWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkDmdCAddUpHisWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkDmdCAddUpHisWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkDmdCAddUpHisWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkDmdCAddUpHisWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkDmdCAddUpHisWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkDmdCAddUpHisWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkDmdCAddUpHisWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkDmdCAddUpHisWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkDmdCAddUpHisWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkDmdCAddUpHisWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STARTCADDUPUPDDATERF"));
            wkDmdCAddUpHisWork.CAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDDATERF"));
            wkDmdCAddUpHisWork.CAddUpUpdYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("CADDUPUPDYEARMONTHRF"));
            wkDmdCAddUpHisWork.CAddUpUpdExecDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDEXECDATERF"));
            wkDmdCAddUpHisWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTCADDUPUPDDATERF"));
            wkDmdCAddUpHisWork.DataUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("DATAUPDATEDATETIMERF"));
            wkDmdCAddUpHisWork.ProcDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROCDIVCDRF"));
            wkDmdCAddUpHisWork.ErrorStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERRORSTATUSRF"));
            wkDmdCAddUpHisWork.HistCtlCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HISTCTLCDRF"));
            wkDmdCAddUpHisWork.ProcResult = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROCRESULTRF"));
            wkDmdCAddUpHisWork.ConvertProcessDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONVERTPROCESSDIVCDRF"));
            #endregion
            // --- ADD 2008.10.01 ----------<<<<<

            return wkDmdCAddUpHisWork;
        }

        // ↓ 2007.11.20 980081 d
        #region 支払インセンティブデータ　クラス格納処理(コメントアウト)
        ///// <summary>
        ///// 支払インセンティブデータ　クラス格納処理 Reader → IncDtbtWork
        ///// </summary>
        ///// <param name="myReader">SqlDataReader</param>
        ///// <returns>IncDtbtWork</returns>
        ///// <remarks>
        ///// <br>Programmer : 20036　斉藤　雅明</br>
        ///// <br>Date       : 2007.06.06</br>
        ///// </remarks>
        //private IncDtbtWork CopyToIncDtbtWorkFromReader(ref SqlDataReader myReader)
        //{
        //    IncDtbtWork wkIncDtbtWork = new IncDtbtWork();
        //
        //    #region クラスへ格納
        //    wkIncDtbtWork.IncDtbtTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INCDTBTTAXINCRF"));
        //    wkIncDtbtWork.IncDtbtTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INCDTBTTAXEXCRF"));
        //    wkIncDtbtWork.IncDtbtTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INCDTBTTAXFREERF"));
        //    wkIncDtbtWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
        //    #endregion
        //
        //    return wkIncDtbtWork;
        //}
        #endregion
        // ↑ 2007.11.20 980081 d

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.03.15</br>
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

        #region [Read 最終請求締履歴取得]
        /// <summary>
        /// 最終請求締履歴取得処理
        /// </summary>
        /// <param name="paraObj">請求締履歴更新マスタReadパラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 最終請求締履歴取得処理</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int ReadHis(ref object paraObj, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            retMsg = null;

            DmdCAddUpHisWork dmdCAddUpHisWork = null;

            try
            {
                dmdCAddUpHisWork = paraObj as DmdCAddUpHisWork;

                if (dmdCAddUpHisWork.EnterpriseCode == "" || dmdCAddUpHisWork.AddUpSecCode == "" ||
                    dmdCAddUpHisWork.CustomerCode == 0)
                {
                    retMsg = "条件が整っておりません。\r\n再度入力項目を入れなおしてください。";
                    return status;
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadHisProc(ref dmdCAddUpHisWork, ref sqlConnection);

                paraObj = (object)dmdCAddUpHisWork;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustDmdPrcDB.ReadHis");
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
        /// 最終請求締履歴取得処理
        /// </summary>
        /// <param name="dmdCAddUpHisWork">請求締履歴更新マスタReadパラメータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 最終請求締履歴取得処理</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.17</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        private int ReadHisProc(ref DmdCAddUpHisWork dmdCAddUpHisWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                    // --- ADD 2008.10.01 ---------->>>>>
                    //sqlCommand.CommandText = "SELECT * FROM DMDCADDUPHISRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND CADDUPUPDDATERF=(SELECT MAX(CADDUPUPDDATERF) FROM DMDCADDUPHISRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ADDUPSECCODERF=@FINDADDUPSECCODE) ";

                    #region [Select文作成]
                    string sqlText = string.Empty;
                    sqlText += "SELECT *" + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ---------->>>>>
                    //sqlText += " FROM DMDCADDUPHISRF" + Environment.NewLine;
                    sqlText += " FROM DMDCADDUPHISRF WITH(READUNCOMMITTED) " + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ----------<<<<<
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    //sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine; // DEL 2008.10.20
                    sqlText += "  AND CADDUPUPDDATERF=" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    sqlText += "   SELECT MAX(CADDUPUPDDATERF)" + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ---------->>>>>
                    //sqlText += "   FROM DMDCADDUPHISRF" + Environment.NewLine;
                    sqlText += "   FROM DMDCADDUPHISRF WITH(READUNCOMMITTED) " + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ----------<<<<<
                    sqlText += "   WHERE" + Environment.NewLine;
                    sqlText += "        ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    //sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine; // DEL 2008.10.20
                    sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "    AND PROCDIVCDRF=0" + Environment.NewLine;
                    sqlText += "    AND HISTCTLCDRF=0" + Environment.NewLine;
                    sqlText += "  )" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Select文作成]
                    // --- ADD 2008.10.01 ----------<<<<<

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(dmdCAddUpHisWork.CustomerCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.AddUpSecCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        dmdCAddUpHisWork = CopyToDmdCAddUpHisWorkFromReader(ref myReader);
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
        /// 最終請求締履歴取得処理(SqlConnection付)
        /// </summary>
        /// <param name="dmdCAddUpHisWork">請求締履歴更新マスタReadパラメータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 最終請求締履歴取得処理(SqlConnection付)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.17</br>
        public int ReadHis(ref DmdCAddUpHisWork dmdCAddUpHisWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            status = ReadHisProcProc(ref dmdCAddUpHisWork, ref sqlConnection, ref sqlTransaction);

            return status;
        }

        /// <summary>
        /// 最終請求締履歴取得処理(SqlConnection付)
        /// </summary>
        /// <param name="dmdCAddUpHisWork">請求締履歴更新マスタReadパラメータ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 最終請求締履歴取得処理(SqlConnection付)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.17</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/22 凌小青</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27450　売上締次/タイムアウトエラーの修正</br>
        private int ReadHisProcProc(ref DmdCAddUpHisWork dmdCAddUpHisWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = _timeOut;//ADD 凌小青 2011/12/22 Redmine#27450
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    // --- ADD 2008.10.01 ---------->>>>>
                    //sqlCommand.CommandText = "SELECT * FROM DMDCADDUPHISRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ADDUPSECCODERF=@FINDADDUPSECCODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND CADDUPUPDDATERF=(SELECT MAX(CADDUPUPDDATERF) FROM DMDCADDUPHISRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ADDUPSECCODERF=@FINDADDUPSECCODE) ";

                    #region [Select文作成]
                    string sqlText = string.Empty;
                    sqlText += "SELECT *" + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ---------->>>>>
                    //sqlText += " FROM DMDCADDUPHISRF" + Environment.NewLine;
                    sqlText += " FROM DMDCADDUPHISRF WITH(READUNCOMMITTED) " + Environment.NewLine;
                    // --- UPDD T.Nishi 2012/02/15 ----------<<<<<
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    //sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine; // DEL 2008.10.20
                    sqlText += "  AND CADDUPUPDDATERF=" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    sqlText += "   SELECT MAX(CADDUPUPDDATERF)" + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ---------->>>>>
                    //sqlText += "   FROM DMDCADDUPHISRF" + Environment.NewLine;
                    sqlText += "   FROM DMDCADDUPHISRF WITH(READUNCOMMITTED) " + Environment.NewLine;
                    // --- UPD T.Nishi 2012/02/15 ----------<<<<<
                    sqlText += "   WHERE" + Environment.NewLine;
                    sqlText += "        ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    //sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine; // DEL 2008.10.20
                    sqlText += "    AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "    AND PROCDIVCDRF=0" + Environment.NewLine;
                    sqlText += "    AND HISTCTLCDRF=0" + Environment.NewLine;
                    sqlText += "  )" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[Select文作成]
                    // --- ADD 2008.10.01 ----------<<<<<

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(dmdCAddUpHisWork.CustomerCode);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(dmdCAddUpHisWork.AddUpSecCode);

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        dmdCAddUpHisWork = CopyToDmdCAddUpHisWorkFromReader(ref myReader);
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

        #region [ReadCustDmdPrc 請求準備処理結果を取得する]
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
        /// <summary>
        /// 請求準備処理結果を取得する
        /// </summary>
        /// <param name="paraObj"></param>
        /// <param name="retMsg"></param>
        /// <returns></returns>
        public int ReadCustDmdPrc( ref object paraObj, out string retMsg )
        {
            object childObj = null;
            return ReadCustDmdPrc( ref paraObj, ref childObj, out retMsg );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD
        /// <summary>
        /// 請求準備処理結果を取得する
        /// </summary>
        /// <param name="paraObj">得意先請求金額マスタパラメータ</param>
        /// <param name="childObj"></param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 請求準備処理結果を取得する</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        //public int ReadCustDmdPrc(ref object paraObj, out string retMsg) // m.suzuki 2009/02/23
        public int ReadCustDmdPrc(ref object paraObj, ref object childObj, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            retMsg = null;

            //●得意先請求金額マスタ
            CustDmdPrcWork custDmdPrcWork = null;
            //●排他制御部品
            //ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;

            Int32[] customerCodeList = new Int32[1];

            try
            {
                custDmdPrcWork = paraObj as CustDmdPrcWork;

                if (custDmdPrcWork.EnterpriseCode == "" || custDmdPrcWork.AddUpSecCode == "" ||
                    custDmdPrcWork.CustomerCode == 0 || custDmdPrcWork.AddUpDate == DateTime.MinValue)
                {
                    retMsg = "条件が整っておりません。\r\n再度入力項目を入れなおしてください。";
                    return (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //ctrlExclsvOdAcs = new ControlExclusiveOrderAccess();

                customerCodeList[0] = new Int32();
                // ↓ 2007.09.14 980081 c
                //customerCodeList[0] = custDmdPrcWork.CustomerCode;
                customerCodeList[0] = custDmdPrcWork.ClaimCode;
                ArrayList dmdDepoTotalWorkList = new ArrayList();
                ArrayList custDmdPrcChildWorkList = new ArrayList();
                // ↑ 2007.09.14 980081 c

                CustDmdPrcUpdateWork custDmdPrcUpdateWork = new CustDmdPrcUpdateWork();

                //status = ctrlExclsvOdAcs.LockDB(custDmdPrcWork.EnterpriseCode, customerCodeList, null);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //●得意先マスタから取得
                    status = GetIndivCustomer(ref custDmdPrcUpdateWork, ref custDmdPrcWork, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        retMsg = "対象となる得意先が存在しません。";
                    }

                    //●前回請求情報取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = GetDmdCAddUpHisAndCustDmdPrc(ref custDmdPrcWork, ref sqlConnection);
                    }

                    ////●全体初期値設定マスタから総額表示方法区分を取得　※全体参照の場合のみ
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    if (custDmdPrcWork.TotalAmntDspWayRef == 0)
                    //        status = GetTotalAmount(ref custDmdPrcWork, ref sqlConnection);
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    //{
                    //    retMsg = "全体初期値設定が不正です。";
                    //}

                    //●入金マスタ取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = GetDepsitMain(ref custDmdPrcWork, ref sqlConnection);
                    }

                    // 2008.07.18 add start ------------------------------->>
                    //●入金明細データ＆入金マスタ取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = GetDepsitDtlMain(ref custDmdPrcWork, ref dmdDepoTotalWorkList, ref sqlConnection);
                    }
                    // 2008.07.18 add end ---------------------------------<<

                    //●売上データ取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ↓ 2007.11.20 980081 c
                        //status = GetSalesSlip(ref custDmdPrcWork, ref sqlConnection);
                        status = GetSalesSlip(ref custDmdPrcWork, ref custDmdPrcChildWorkList, ref sqlConnection);
                        // ↑ 2007.11.20 980081 c
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
                        CustomSerializeArrayList retChildList = new CustomSerializeArrayList();
                        foreach ( CustDmdPrcWork childWork in custDmdPrcChildWorkList )
                        {
                            retChildList.Add( childWork );
                        }
                        //retChildList.AddRange( suplierPayChildWorkList );
                        childObj = retChildList;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD
                    }

                    // ↓ 2007.11.20 980081 d
                    ////●インセンティブデータ取得
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    status = GetIncDtbt(ref custDmdPrcWork, ref sqlConnection);
                    //}
                    // ↑ 2007.11.20 980081 d

                    #region 2008.12.10 DEL
                    /*
                    //●金額計算処理
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = CalculateCustDmdPrc(ref custDmdPrcWork);
                    }
                    */
                    #endregion
                }

                paraObj = (object)custDmdPrcWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustDmdPrcDB.ReadCustDmdPrc");
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                //if (ctrlExclsvOdAcs != null) ctrlExclsvOdAcs.UnlockDB();
            }

            return status;
        }

        /// <summary>
        /// 請求準備処理結果を取得する(SqlConnection付)
        /// </summary>
        /// <param name="paraObj">得意先請求金額マスタパラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 請求準備処理結果を取得する(SqlConnection付)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int ReadCustDmdPrc(ref object paraObj, out string retMsg, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retMsg = null;

            //●得意先請求金額マスタ
            CustDmdPrcWork custDmdPrcWork = null;
            CustDmdPrcUpdateWork custDmdPrcUpdateWork = null;
            //●排他制御部品
            //ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;
            ArrayList dmdDepoTotalWorkList = new ArrayList();
            // ↓ 2007.11.20 980081 a
            ArrayList custDmdPrcChildWorkList = new ArrayList();
            // ↑ 2007.11.20 980081 a

            Int32[] customerCodeList = new Int32[1];

            try
            {
                custDmdPrcWork = paraObj as CustDmdPrcWork;

                if (custDmdPrcWork.EnterpriseCode == "" || custDmdPrcWork.AddUpSecCode == "" ||
                    custDmdPrcWork.CustomerCode == 0 || custDmdPrcWork.AddUpDate == DateTime.MinValue)
                {
                    retMsg = "条件が整っておりません。\r\n再度入力項目を入れなおしてください。";
                    return (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }

                //ctrlExclsvOdAcs = new ControlExclusiveOrderAccess();

                customerCodeList[0] = new Int32();
                customerCodeList[0] = custDmdPrcWork.CustomerCode;

                custDmdPrcUpdateWork = new CustDmdPrcUpdateWork();

                //status = ctrlExclsvOdAcs.LockDB(custDmdPrcWork.EnterpriseCode, customerCodeList, null);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //●得意先マスタから取得
                    status = GetIndivCustomer(ref custDmdPrcUpdateWork, ref custDmdPrcWork, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        retMsg = "対象となる得意先が存在しません。";
                    }

                    //●前回請求情報取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = GetDmdCAddUpHisAndCustDmdPrc(ref custDmdPrcWork, ref sqlConnection);
                    }

                    ////●全体初期値設定マスタから総額表示方法区分を取得　※全体参照の場合のみ
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    if (custDmdPrcWork.TotalAmntDspWayRef == 0)
                    //        status = GetTotalAmount(ref custDmdPrcWork, ref sqlConnection);
                    //}
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    //{
                    //    retMsg = "全体初期値設定が不正です。";
                    //}

                    //●入金マスタ取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = GetDepsitMain(ref custDmdPrcWork, ref sqlConnection);
                    }

                    // 2008.07.18 add start ------------------------------->>
                    //●入金明細データ＆入金マスタ取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = GetDepsitDtlMain(ref custDmdPrcWork, ref dmdDepoTotalWorkList, ref sqlConnection);
                    }
                    // 2008.07.18 add end ---------------------------------<<

                    //●売上データ取得
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ↓ 2007.11.20 980081 c
                        //status = GetSalesSlip(ref custDmdPrcWork, ref sqlConnection);
                        status = GetSalesSlip(ref custDmdPrcWork, ref custDmdPrcChildWorkList, ref sqlConnection);
                        // ↑ 2007.11.20 980081 c
                    }

                    // ↓ 2007.11.20 980081 d
                    ////●インセンティブデータ取得
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    status = GetIncDtbt(ref custDmdPrcWork, ref sqlConnection);
                    //}
                    // ↑ 2007.11.20 980081 d

                    // --- DEL 2013/02/28 Y.Wakita ---------->>>>>
                    ////●金額計算処理
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    status = CalculateCustDmdPrc(ref custDmdPrcWork);
                    //}
                    // --- DEL 2013/02/28 Y.Wakita ----------<<<<<
                }

                paraObj = (object)custDmdPrcWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustDmdPrcDB.ReadCustDmdPrc");
            }
            finally
            {
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

            // --- ADD m.suzuki 2010/09/30 ---------->>>>>
            // ゼロ除算防止
            if ( ((decimal)fractionUnit) == 0 )
            {
                fractionUnit = 1;
            }
            // --- ADD m.suzuki 2010/09/30 ----------<<<<<
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

        //----- ADD 2013/08/08 汪権来 Redmine#35552 速度改善 ------------------->>>>>
        #region [売上データ]
        #region [CustomerData]
        /// <summary>
        /// 「売上締次専用」対象請求先、一時テーブルを作成する
        /// </summary>
        /// <param name="custDmdPrcUpdateWork">請求金額マスタワーク用クラス</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 対象請求先、一時テーブルを作成する</br>
        /// <br>Programmer : 2013/08/08 汪権来</br>
        /// <br>管理番号   ：10801804-00 2013/06/18配信分</br>
        /// <br>             Redmine#35552 「売上締次更新」の処理速度遅延の調査と対応(№1921)</br>
        /// <br>Update Note: 2019/10/15 譚洪</br>
        /// <br>管理番号   : 11575156-00</br>
        /// <br>           : PMKOBETSU-1860 速度遅延やタイムアウトの対応</br>
        /// </remarks>
        private int InsertCustomerData(CustDmdPrcUpdateWork custDmdPrcUpdateWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlText = string.Empty;

            //----- ADD  2019/10/15 譚洪 PMKOBETSU-1860 速度遅延やタイムアウトの対応 ---------->>>>>
            bool chgFlg = false;
            int per2yearAddUpdate = 0;
            //自社情報取得
            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
            CompanyInfDB companyInfDB = new CompanyInfDB();
            ArrayList arrayList = new ArrayList();

            paraCompanyInfWork.EnterpriseCode = custDmdPrcUpdateWork.EnterpriseCode;
            companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);
            paraCompanyInfWork = (CompanyInfWork)arrayList[0];

            //自社情報.期首年月日の1年前の日の設定
            if (paraCompanyInfWork.CompanyBiginDate != 0)
            {
                DateTime dt = DateTime.ParseExact(paraCompanyInfWork.CompanyBiginDate.ToString(), "yyyyMMdd", null);
                DateTime dt1YearBefore = dt.AddYears(-1);
                DateTime dt1DayBefore = dt1YearBefore.AddDays(-1);
                chgFlg = Int32.TryParse(dt1DayBefore.ToString("yyyyMMdd"), out per2yearAddUpdate);
            }
            //----- ADD  2019/10/15 譚洪 PMKOBETSU-1860 速度遅延やタイムアウトの対応 ----------<<<<<

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = _timeOut;

                    #region INSERT
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "   @FINDENTERPRISECODE AS ENTERPRISECODERF " + Environment.NewLine;
                    sqlText += "   ,CUST.CUSTOMERCODERF AS CLAIMCODERF " + Environment.NewLine;
                    //----- UPD  2019/10/15 譚洪 PMKOBETSU-1860 速度遅延やタイムアウトの対応 ---------->>>>>
                    //sqlText += "   ,ISNULL(CLAIM.ADDUPDATERF, 20000101) AS LASTCADDUPUPDDATERF " + Environment.NewLine;
                    if (chgFlg && (per2yearAddUpdate > 20000101))
                    {
                        sqlText += "   ,ISNULL(CLAIM.ADDUPDATERF, " + per2yearAddUpdate.ToString() + ") AS LASTCADDUPUPDDATERF " + Environment.NewLine;
                    }
                    else
                    {
                        sqlText += "   ,ISNULL(CLAIM.ADDUPDATERF, 20000101) AS LASTCADDUPUPDDATERF " + Environment.NewLine;
                    }
                    //----- UPD  2019/10/15 譚洪 PMKOBETSU-1860 速度遅延やタイムアウトの対応 ----------<<<<<
                    sqlText += "   ,@FINDADDUPDATE AS ADDUPDATERF " + Environment.NewLine;
                    sqlText += "   INTO  ##CUSTOMERDATERF " + Environment.NewLine;
                    sqlText += "   FROM " + Environment.NewLine;
                    sqlText += "   (" + Environment.NewLine;
                    sqlText += "   CUSTOMERRF AS CUST WITH(READUNCOMMITTED) " + Environment.NewLine;

                    // 税率マスタ
                    sqlText += "   LEFT JOIN TAXRATESETRF AS B WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "   ON CUST.ENTERPRISECODERF=B.ENTERPRISECODERF" + Environment.NewLine;

                    sqlText += "   LEFT JOIN " + Environment.NewLine;
                    sqlText += "   (SELECT	 " + Environment.NewLine;
                    sqlText += "   CLAIMCODERF	 " + Environment.NewLine;
                    sqlText += "   ,  MAX(ADDUPDATERF) AS ADDUPDATERF" + Environment.NewLine;
                    sqlText += "   FROM	 " + Environment.NewLine;
                    sqlText += "   CUSTDMDPRCRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "   WHERE	 " + Environment.NewLine;
                    sqlText += "   ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND RESULTSSECTCDRF='00'" + Environment.NewLine;
                    sqlText += "  AND CUSTOMERCODERF=0" + Environment.NewLine;
                    sqlText += "  AND ADDUPDATERF<@FINDADDUPDATE" + Environment.NewLine;
                    sqlText += "  GROUP BY CLAIMCODERF" + Environment.NewLine;
                    sqlText += "  ) AS CLAIM" + Environment.NewLine;
                    sqlText += "  ON" + Environment.NewLine;
                    sqlText += "  CUST.CUSTOMERCODERF = CLAIM.CLAIMCODERF" + Environment.NewLine;

                    if (custDmdPrcUpdateWork.AddUpSecCode == "" || custDmdPrcUpdateWork.AddUpSecCode == "00")
                    {
                        sqlText += " INNER JOIN SECINFOSETRF AS E WITH (READUNCOMMITTED)" + Environment.NewLine;
                        sqlText += " ON CUST.ENTERPRISECODERF=E.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " AND CUST.CLAIMSECTIONCODERF= E.SECTIONCODERF" + Environment.NewLine;
                        sqlText += " AND E.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    }
                    sqlText += "  ) " + Environment.NewLine;

                    sqlText += " WHERE CUST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND CUST.LOGICALDELETECODERF=0" + Environment.NewLine;
                    sqlText += " AND B.TAXRATECODERF=0" + Environment.NewLine;

                    //得意先締日
                    if (custDmdPrcUpdateWork.CustomerTotalDay != 0 && custDmdPrcUpdateWork.CustomerTotalDay != 99)
                    {
                        // 28日以降は末締とする
                        if (custDmdPrcUpdateWork.CustomerTotalDay >= 28 && custDmdPrcUpdateWork.CustomerTotalDay <= 31)
                        {
                            sqlText += " AND (CUST.TOTALDAYRF>=28 AND CUST.TOTALDAYRF<=31)";
                        }
                        else
                        {
                            sqlText += " AND CUST.TOTALDAYRF=@FINDTOTALDAY ";
                            SqlParameter findParaTotalDay = sqlCommand.Parameters.Add("@FINDTOTALDAY", SqlDbType.Int);
                            findParaTotalDay.Value = SqlDataMediator.SqlSetInt32(custDmdPrcUpdateWork.CustomerTotalDay);
                        }
                    }

                    if (custDmdPrcUpdateWork.AddUpSecCode != "" && custDmdPrcUpdateWork.AddUpSecCode != "00")
                    {
                        sqlText += " AND CUST.CLAIMSECTIONCODERF =@FINDSECTIONCODE" + Environment.NewLine;
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(custDmdPrcUpdateWork.AddUpSecCode);
                    }


                    #endregion  //[INTO文作成]
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcUpdateWork.EnterpriseCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcUpdateWork.AddUpDate);

                    sqlCommand.CommandText = sqlText;
                    sqlCommand.ExecuteNonQuery();

                    sqlText = string.Empty;
                    sqlText += "  CREATE NONCLUSTERED " + Environment.NewLine;
                    sqlText += "  INDEX   CUSTOMERDATERF_IDX1 " + Environment.NewLine;
                    sqlText += "  ON ##CUSTOMERDATERF (ENTERPRISECODERF, CLAIMCODERF) " + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
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

        #endregion [CustomerData]

        #region [SalesSlipClaimWork]
        /// <summary>
        /// 「売上締次専用」対象売上、一時テーブルを作成する
        /// </summary>
        /// <param name="custDmdPrcUpdateWork">請求金額マスタワーク用クラス</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 対象売上、一時テーブルを作成する</br>
        /// <br>Programmer : 2013/08/08 汪権来</br>
        /// <br>管理番号   ：10902175-00 2013/06/18配信分</br>
        /// <br>             Redmine#35552 「売上締次更新」の処理速度遅延の調査と対応(№1921)</br>
        /// <br>Update Note: 2016/10/27 田建委</br>
        /// <br>管理番号   : 11275240-00</br>
        /// <br>             Redmine#48899 売上締次処理のレコードロック解除-READUNCOMMITTEDの追加</br>
        /// </remarks>
        private int InsertSalesSlipClaimWork(CustDmdPrcUpdateWork custDmdPrcUpdateWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlText = string.Empty;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = _timeOut;

                    #region INSERT
                    sqlText += "SELECT " + Environment.NewLine;
                    sqlText += "SALEWORK.ENTERPRISECODERF,  " + Environment.NewLine;
                    sqlText += "SALEWORK.ACPTANODRSTATUSRF,  " + Environment.NewLine;
                    sqlText += "SALEWORK.SALESSLIPNUMRF,  " + Environment.NewLine;
                    sqlText += "SALEWORK.SALESSLIPCDRF, " + Environment.NewLine;
                    sqlText += "SALEWORK.CLAIMCODERF, " + Environment.NewLine;
                    sqlText += "SALEWORK.ADDUPADATERF " + Environment.NewLine;
                    sqlText += "INTO ##SALESSLIPCLAIMWORKRF " + Environment.NewLine;
                    sqlText += "FROM  " + Environment.NewLine;
                    sqlText += "##CUSTOMERDATERF AS CUSTWORK " + Environment.NewLine;
                    sqlText += "INNER JOIN ( " + Environment.NewLine;
                    sqlText += "SELECT  " + Environment.NewLine;
                    sqlText += "SALE.ENTERPRISECODERF,  " + Environment.NewLine;
                    sqlText += "SALE.ACPTANODRSTATUSRF,  " + Environment.NewLine;
                    sqlText += "SALE.SALESSLIPNUMRF,  " + Environment.NewLine;
                    sqlText += "SALE.SALESSLIPCDRF, " + Environment.NewLine;
                    sqlText += "ISNULL(CUST.CLAIMCODERF, SALE.CLAIMCODERF) CLAIMCODERF, " + Environment.NewLine;
                    sqlText += "SALE.ADDUPADATERF " + Environment.NewLine;
                    sqlText += "FROM  " + Environment.NewLine;
                    //----- UPD 2016/10/27 田建委 Redmine#48899 売上締次処理のレコードロック解除 ----->>>>>
                    //sqlText += "SALESSLIPRF AS SALE " + Environment.NewLine;
                    //sqlText += "LEFT JOIN CUSTOMERRF AS CUST  " + Environment.NewLine;
                    sqlText += "SALESSLIPRF AS SALE WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "LEFT JOIN CUSTOMERRF AS CUST WITH (READUNCOMMITTED)" + Environment.NewLine;
                    //----- UPD 2016/10/27 田建委 Redmine#48899 売上締次処理のレコードロック解除 -----<<<<<
                    sqlText += "ON SALE.ENTERPRISECODERF = CUST.ENTERPRISECODERF " + Environment.NewLine;
                    sqlText += "AND SALE.CUSTOMERCODERF = CUST.CUSTOMERCODERF " + Environment.NewLine;
                    sqlText += "WHERE " + Environment.NewLine;
                    sqlText += "SALE.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "AND SALE.LOGICALDELETECODERF=0 " + Environment.NewLine;
                    sqlText += "AND SALE.ACPTANODRSTATUSRF = 30 " + Environment.NewLine;
                    sqlText += "AND SALE.DEBITNOTEDIVRF=0) SALEWORK " + Environment.NewLine;
                    sqlText += "ON SALEWORK.ENTERPRISECODERF = CUSTWORK.ENTERPRISECODERF " + Environment.NewLine;
                    sqlText += "AND SALEWORK.CLAIMCODERF = CUSTWORK.CLAIMCODERF " + Environment.NewLine;
                    sqlText += "WHERE SALEWORK.ADDUPADATERF > CUSTWORK.LASTCADDUPUPDDATERF " + Environment.NewLine;
                    sqlText += "AND SALEWORK.ADDUPADATERF <= CUSTWORK.ADDUPDATERF " + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion  //[INTO文作成]
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcUpdateWork.EnterpriseCode);
                    sqlCommand.ExecuteNonQuery();

                    sqlText = string.Empty;
                    sqlText += "  CREATE NONCLUSTERED " + Environment.NewLine;
                    sqlText += "  INDEX   SALESSLIPCLAIMWORKRF_IDX1 " + Environment.NewLine;
                    sqlText += "  ON ##SALESSLIPCLAIMWORKRF (ENTERPRISECODERF, ACPTANODRSTATUSRF, SALESSLIPNUMRF) " + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
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
        #endregion

        /// <summary>
        /// 「売上締次専用」親集計を作成する
        /// </summary>
        /// <param name="custDmdPrcParentWorkList">親集計得意先請求金額ワークList</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : CustomerDataマスタを作成する</br>
        /// <br>Programmer : 2013/08/08 汪権来</br>
        /// <br>管理番号   ：10902175-00 2013/06/18配信分</br>
        /// <br>             Redmine#35552 「売上締次更新」の処理速度遅延の調査と対応(№1921)</br>
        /// <br>Update Note: 2016/10/27 田建委</br>
        /// <br>管理番号   : 11275240-00</br>
        /// <br>             Redmine#48899 売上締次処理のレコードロック解除-READUNCOMMITTEDの追加</br>
        /// </remarks>
        private int GetDictionaryProc(ref Dictionary<string, List<CustDmdPrcWork>> custDmdPrcParentWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = _timeOut;
                    StringBuilder sqlText = new StringBuilder();

                    #region ■集計レコード集計処理

                    #region SELECT文
                    sqlText.Append("SELECT" + Environment.NewLine);
                    sqlText.Append("DMDPRC.CLAIMCODERF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CLAIMNAMERF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CLAIMNAME2RF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CLAIMSNMRF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.FRACTIONPROCCDRF,  --端数処理単位" + Environment.NewLine);
                    sqlText.Append("DMDPRC.FRACTIONPROCUNITRF,--端数処理区分" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESNETPRICERF + DMDPRC.RETSALESNETPRICERF +DMDPRC.SALESDISTTLTAXEXCRF AS OFSTHISTIMESALESRF,      --相殺後今回売上金額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESOUTTAXRF+DMDPRC.RETITDEDSALESOUTTAXRF+DMDPRC.ITDEDSALESDISOUTTAXRF AS ITDEDOFFSETOUTTAXRF,--相殺後外税対象額 " + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESINTAXRF+ DMDPRC.RETITDEDSALESINTAXRF+ DMDPRC.ITDEDSALESDISINTAXRF AS ITDEDOFFSETINTAXRF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALSUBTTLSUBTOTAXFRERF+DMDPRC.RETSALSUBTTLSUBTOTAXFRERF+DMDPRC.ITDEDSALESDISTAXFRERF AS ITDEDOFFSETTAXFREERF,--相殺後非課税対象額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALAMNTCONSTAXINCLURF + DMDPRC.RETSALAMNTCONSTAXINCLURF + DMDPRC.SALESDISTTLTAXINCLURF AS OFFSETINTAXRF,     --相殺後内税消費税" + Environment.NewLine);
                    sqlText.Append("-- ■ ■ 売上 ■ ■" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESNETPRICERF AS THISTIMESALESRF,--今回売上金額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESOUTTAXRF  AS ITDEDSALESOUTTAXRF,    --売上外税対象額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESINTAXRF AS ITDEDSALESINTAXRF,       --売上内税対象額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALSUBTTLSUBTOTAXFRERF AS ITDEDSALESTAXFREERF,--売上非課税対象額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESOUTTAXRF AS SALESOUTTAX_D,    -- 伝票転嫁消費税" + Environment.NewLine);
                    sqlText.Append("DMDPRC.DTLSALESOUTTAXRF AS SALESOUTTAX_M, -- 明細転嫁消費税" + Environment.NewLine);
                    //sqlText.Append("DMDPRC.SALESOUTTAXRF1 +DMDPRC.SALESOUTTAXRF2 +DMDPRC.SALESOUTTAXRF3 AS SALESOUTTAX_S, --請求転嫁(親)" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.SALESOUTTAXRF1*TAXRATERF +DMDPRC.SALESOUTTAXRF2*TAXRATE2RF +DMDPRC.SALESOUTTAXRF3*TAXRATE3RF AS SALESOUTTAX_S, --請求転嫁(親)" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.SALAMNTCONSTAXINCLURF AS SALESINTAXRF,--売上内税額" + Environment.NewLine);
                    sqlText.Append("-- ■ ■ 返品 ■ ■" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RETSALESNETPRICERF AS THISSALESPRICRGDSRF,    -- 今回売上返品額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RETITDEDSALESOUTTAXRF AS TTLITDEDRETOUTTAXRF, --返品外税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RETITDEDSALESINTAXRF AS TTLITDEDRETINTAXRF,   --返品内税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RETSALSUBTTLSUBTOTAXFRERF AS TTLITDEDRETTAXFREERF, --返品非課税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RETSALESOUTTAXRF AS RETSALESOUTTAX_D,    -- 伝票転嫁消費税" + Environment.NewLine);
                    sqlText.Append("DMDPRC.DTLRETSALESOUTTAXRF AS RETSALESOUTTAX_M, -- 明細転嫁消費税" + Environment.NewLine);
                    //sqlText.Append("DMDPRC.RETSALESOUTTAXRF1 +DMDPRC.RETSALESOUTTAXRF2 +DMDPRC.RETSALESOUTTAXRF3 AS RETSALESOUTTAX_S, -- 請求転嫁(親)消費税" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.RETSALESOUTTAXRF1*TAXRATERF +DMDPRC.RETSALESOUTTAXRF2*TAXRATE2RF +DMDPRC.RETSALESOUTTAXRF3*TAXRATE3RF AS RETSALESOUTTAX_S, -- 請求転嫁(親)消費税" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.RETSALAMNTCONSTAXINCLURF AS TTLRETINNERTAXRF,--返品内税額合計" + Environment.NewLine);
                    sqlText.Append("-- ■ ■ 値引 ■ ■" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESDISTTLTAXEXCRF AS THISSALESPRICDISRF,    --今回売上値引金額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESDISOUTTAXRF AS TTLITDEDDISOUTTAXRF, --値引外税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESDISINTAXRF AS TTLITDEDDISINTAXRF,   --値引内税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESDISTAXFRERF AS TTLITDEDDISTAXFREERF,--値引非課税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESDISOUTTAXRF AS DISSALEOUTTAX_D,          --伝票転嫁消費税" + Environment.NewLine);
                    sqlText.Append("DMDPRC.DTLSALESDISOUTTAXRF AS DISSALEOUTTAX_M,       --明細転嫁消費税" + Environment.NewLine);
                    //sqlText.Append("DMDPRC.SALESDISOUTTAXRF1 +DMDPRC.SALESDISOUTTAXRF2 +DMDPRC.SALESDISOUTTAXRF3 AS DISSALEOUTTAX_S,--請求転嫁(親)消費税" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.SALESDISOUTTAXRF1*TAXRATERF +DMDPRC.SALESDISOUTTAXRF2*TAXRATE2RF +DMDPRC.SALESDISOUTTAXRF3*TAXRATE3RF AS DISSALEOUTTAX_S,--請求転嫁(親)消費税" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.SALESDISTTLTAXINCLURF AS TTLDISINNERTAXRF,  --値引内税額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESSLIPCOUNT AS SALESSLIPCOUNTRF,         --売上伝票枚数" + Environment.NewLine);
                    sqlText.Append("DMDPRC.COLLECTCONDRF AS COLLECTCONDRF,             --回収条件" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESCNSTAXFRCPROCCDRF AS FRACTIONPROCCDRF, --端数処理区分" + Environment.NewLine);
                    sqlText.Append("DMDPRC.COLLECTMONEYCODERF AS COLLECTMONEYCODERF,   --集金月区分コード" + Environment.NewLine);
                    sqlText.Append("DMDPRC.COLLECTMONEYDAYRF AS COLLECTMONEYDAYRF,     --集金日" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,   --税率開始日" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATEENDDATERF AS TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATERF AS TAXRATERF,                     --税率" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF, --税率開始日2" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,     --税率終了日2" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATE2RF AS TAXRATE2RF,                   --税率2" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF, --税率開始日3" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,     --税率終了日3" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATE3RF AS TAXRATE3RF                    --税率3" + Environment.NewLine);
                    sqlText.Append("FROM" + Environment.NewLine);
                    sqlText.Append("(" + Environment.NewLine);
                    #endregion

                    #region SUBクエリ

                    sqlText.Append("  SELECT" + Environment.NewLine);
                    sqlText.Append("   SALE.CLAIMCODERF AS CLAIMCODERF," + Environment.NewLine);
                    sqlText.Append("   CLAIM.NAMERF AS CLAIMNAMERF," + Environment.NewLine);
                    sqlText.Append("   CLAIM.NAME2RF AS CLAIMNAME2RF," + Environment.NewLine);
                    sqlText.Append("   CLAIM.CUSTOMERSNMRF AS CLAIMSNMRF," + Environment.NewLine);
                    sqlText.Append("   CLAIM.COLLECTCONDRF AS COLLECTCONDRF," + Environment.NewLine);
                    sqlText.Append("   CLAIM.COLLECTMONEYCODERF AS COLLECTMONEYCODERF," + Environment.NewLine);
                    sqlText.Append("   CLAIM.COLLECTMONEYDAYRF AS COLLECTMONEYDAYRF," + Environment.NewLine);
                    sqlText.Append("   CLAIM.SALESCNSTAXFRCPROCCDRF AS SALESCNSTAXFRCPROCCDRF," + Environment.NewLine);
                    sqlText.Append("   SALESPROC.FRACTIONPROCCDRF," + Environment.NewLine);
                    sqlText.Append("   SALESPROC.FRACTIONPROCUNITRF," + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATESTARTDATERF AS TAXRATESTARTDATERF," + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATEENDDATERF AS TAXRATEENDDATERF," + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATERF AS TAXRATERF," + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF," + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF," + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATE2RF AS TAXRATE2RF," + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF," + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF," + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATE3RF AS TAXRATE3RF," + Environment.NewLine);
                    sqlText.Append("   COUNT(SALE.SALESSLIPNUMRF) SALESSLIPCOUNT," + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS SALESNETPRICERF," + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.ITDEDSALESOUTTAXRF ELSE 0 END)) AS ITDEDSALESOUTTAXRF," + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.ITDEDSALESINTAXRF ELSE 0 END)) AS ITDEDSALESINTAXRF," + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALSUBTTLSUBTOTAXFRERF ELSE 0 END)) AS SALSUBTTLSUBTOTAXFRERF," + Environment.NewLine);
                    sqlText.Append("   -- 伝票転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =0) AND (SALE.SALESSLIPCDRF =0) THEN SALE.SALESOUTTAXRF ELSE 0 END)) AS SALESOUTTAXRF," + Environment.NewLine);
                    sqlText.Append("   -- 明細転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =1) AND (SALE.SALESSLIPCDRF =0) THEN SALE.DTLSALESOUTTAXRF ELSE 0 END)) AS DTLSALESOUTTAXRF," + Environment.NewLine);
                    sqlText.Append("   --請求親転嫁(親)" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)" + Environment.NewLine);
                    //sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS SALESOUTTAXRF1,--税率1" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF)" + Environment.NewLine);
                    //sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESOUTTAXRF2,    --税率2" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF)" + Environment.NewLine);
                    //sqlText.Append("             THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESOUTTAXRF3, --税率3" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)" + Environment.NewLine);
                    sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF1,--税率1" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF)" + Environment.NewLine);
                    sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF2,    --税率2" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF)" + Environment.NewLine);
                    sqlText.Append("             THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF3, --税率3" + Environment.NewLine);
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALAMNTCONSTAXINCLURF ELSE 0 END)) AS SALAMNTCONSTAXINCLURF,     --消費税額（内税）" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS RETSALESNETPRICERF,              --返品 売上正価金額" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.ITDEDSALESOUTTAXRF ELSE 0 END)) AS RETITDEDSALESOUTTAXRF,        --返品 売上外税対象額" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.ITDEDSALESINTAXRF ELSE 0 END)) AS RETITDEDSALESINTAXRF,          --返品 売上内税対象額" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALSUBTTLSUBTOTAXFRERF ELSE 0 END)) AS RETSALSUBTTLSUBTOTAXFRERF,--返品 売上小計非課税対象額" + Environment.NewLine);
                    sqlText.Append("   --伝票転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =0) AND (SALE.SALESSLIPCDRF =1) THEN SALE.SALESOUTTAXRF ELSE 0 END)) AS RETSALESOUTTAXRF,--返品 消費税（外税）伝票" + Environment.NewLine);
                    sqlText.Append("   --明細転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =1) AND (SALE.SALESSLIPCDRF =1) THEN SALE.DTLSALESOUTTAXRF ELSE 0 END)) AS DTLRETSALESOUTTAXRF, --返品 消費税（外税）明細" + Environment.NewLine);
                    sqlText.Append("   --請求転嫁(親)" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    //sqlText.Append("           THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS RETSALESOUTTAXRF1,--返品 消費税額（外税）税率1" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND(SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    //sqlText.Append("           THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS RETSALESOUTTAXRF2,  --返品 消費税額（外税）税率2" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    //sqlText.Append("           THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS RETSALESOUTTAXRF3,  --返品 消費税額（外税）税率3" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    sqlText.Append("           THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF1,--返品 消費税額（外税）税率1" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND(SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    sqlText.Append("           THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF2,  --返品 消費税額（外税）税率2" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    sqlText.Append("           THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF3,  --返品 消費税額（外税）税率3" + Environment.NewLine);
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALAMNTCONSTAXINCLURF ELSE 0 END)) AS RETSALAMNTCONSTAXINCLURF,  --返品 消費税額（内税）" + Environment.NewLine);
                    sqlText.Append("   SUM(SALE.SALESDISTTLTAXEXCRF) AS SALESDISTTLTAXEXCRF,    --値引金額計（税抜き）" + Environment.NewLine);
                    sqlText.Append("   SUM(SALE.ITDEDSALESDISOUTTAXRF) AS ITDEDSALESDISOUTTAXRF,--値引外税対象額合計" + Environment.NewLine);
                    sqlText.Append("   SUM(SALE.ITDEDSALESDISINTAXRF) AS ITDEDSALESDISINTAXRF,  --値引内税対象額合計" + Environment.NewLine);
                    sqlText.Append("   SUM(SALE.ITDEDSALESDISTAXFRERF) AS ITDEDSALESDISTAXFRERF,--値引非課税対象額合計" + Environment.NewLine);
                    sqlText.Append("   --伝票転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.CONSTAXLAYMETHODRF =0 THEN SALE.SALESDISOUTTAXRF ELSE 0 END )) AS SALESDISOUTTAXRF,   --値引消費税額（外税）伝票" + Environment.NewLine);
                    sqlText.Append("   --明細転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.CONSTAXLAYMETHODRF =1 THEN SALE.SALESDISOUTTAXRF ELSE 0 END )) AS DTLSALESDISOUTTAXRF,--値引消費税額（外税）明細" + Environment.NewLine);
                    sqlText.Append("   --請求転嫁(親)" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)" + Environment.NewLine);
                    //sqlText.Append("           THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATERF) ELSE 0 END)) AS SALESDISOUTTAXRF1, --売上値引消費税額（外税）税率1" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    //sqlText.Append("           THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESDISOUTTAXRF2,--売上値引消費税額（外税）税率2" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF)" + Environment.NewLine);
                    //sqlText.Append("          THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESDISOUTTAXRF3, --売上値引消費税額（外税）税率3" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)" + Environment.NewLine);
                    sqlText.Append("           THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF1, --売上値引消費税額（外税）税率1" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    sqlText.Append("           THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF2,--売上値引消費税額（外税）税率2" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF =2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF)" + Environment.NewLine);
                    sqlText.Append("          THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF3, --売上値引消費税額（外税）税率3" + Environment.NewLine);
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    sqlText.Append("   SUM(SALE.SALESDISTTLTAXINCLURF) AS SALESDISTTLTAXINCLURF --売上値引消費税額（内税）" + Environment.NewLine);
                    sqlText.Append("  FROM" + Environment.NewLine);
                    sqlText.Append("  (" + Environment.NewLine);
                    sqlText.Append("     SELECT" + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ENTERPRISECODERF," + Environment.NewLine);
                    sqlText.Append("      SALEWORK.CLAIMCODERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.CUSTOMERCODERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ADDUPADATERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.LOGICALDELETECODERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ACPTANODRSTATUSRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.DEBITNOTEDIVRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESSLIPNUMRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESSLIPCDRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.CONSTAXLAYMETHODRF, -- ADD 2009/04/13" + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESNETPRICERF + DISSALESTAXEXCGYO AS SALESNETPRICERF ," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ITDEDSALESOUTTAXRF + ITDEDDISSALESOUTTAXGYO AS ITDEDSALESOUTTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ITDEDSALESINTAXRF + ITDEDDISSALESINTAXGYO AS ITDEDSALESINTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALSUBTTLSUBTOTAXFRERF + ITDEDDISSALESTAXFREGYO AS SALSUBTTLSUBTOTAXFRERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESOUTTAXRF + DISSALESOUTTAXGYO AS SALESOUTTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALAMNTCONSTAXINCLURF + DISSALESTAXFREGYO AS SALAMNTCONSTAXINCLURF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESDISTTLTAXEXCRF -  SALESDTL.DISSALESTAXEXCGYO AS SALESDISTTLTAXEXCRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ITDEDSALESDISOUTTAXRF - SALESDTL.ITDEDDISSALESOUTTAXGYO AS ITDEDSALESDISOUTTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ITDEDSALESDISINTAXRF - SALESDTL.ITDEDDISSALESINTAXGYO AS ITDEDSALESDISINTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ITDEDSALESDISTAXFRERF - SALESDTL.ITDEDDISSALESTAXFREGYO AS ITDEDSALESDISTAXFRERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESDISOUTTAXRF - SALESDTL.DISSALESOUTTAXGYO AS SALESDISOUTTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESDISTTLTAXINCLURF - SALESDTL.DISSALESTAXFREGYO AS SALESDISTTLTAXINCLURF," + Environment.NewLine);
                    sqlText.Append("      SALESDTL.DTLSALESOUTTAXRF + SALESDTL.DISSALESOUTTAXGYO AS DTLSALESOUTTAXRF, " + Environment.NewLine);
                    sqlText.Append("      SALESDTL.DTLSALAMNTCONSTAXINCLURF + SALESDTL.DISSALESTAXFREGYO AS DTLSALAMNTCONSTAXINCLURF," + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,   --税率開始日" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATEENDDATERF AS TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATERF AS TAXRATERF,                     --税率" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF, --税率開始日2" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,     --税率終了日2" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATE2RF AS TAXRATE2RF,                   --税率2" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF, --税率開始日3" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,     --税率終了日3" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATE3RF AS TAXRATE3RF,                   --税率3" + Environment.NewLine);
                    sqlText.Append("      TAX.CONSTAXLAYMETHODRF AS TAXCONSTAXLAYMETHODRF" + Environment.NewLine);
                    sqlText.Append("     FROM" + Environment.NewLine);
                    sqlText.Append("     TAXRATESETRF AS TAX WITH(READUNCOMMITTED) " + Environment.NewLine);
                    #region SUBクエリ JOIN

                    sqlText.Append("    INNER JOIN ##SALESSLIPCLAIMWORKRF AS SALEWORK WITH(READUNCOMMITTED) " + Environment.NewLine);
                    sqlText.Append("     ON SALEWORK.ENTERPRISECODERF = TAX.ENTERPRISECODERF " + Environment.NewLine);
                    //----- UPD 2016/10/27 田建委 Redmine#48899 売上締次処理のレコードロック解除 ----->>>>>
                    //sqlText.Append("    INNER JOIN SALESSLIPRF AS SUBSALE " + Environment.NewLine);
                    sqlText.Append("    INNER JOIN SALESSLIPRF AS SUBSALE WITH (READUNCOMMITTED)" + Environment.NewLine);
                    //----- UPD 2016/10/27 田建委 Redmine#48899 売上締次処理のレコードロック解除 -----<<<<<
                    sqlText.Append("    ON SALEWORK.ENTERPRISECODERF = SUBSALE.ENTERPRISECODERF	 " + Environment.NewLine);
                    sqlText.Append("    AND SALEWORK.ACPTANODRSTATUSRF = SUBSALE.ACPTANODRSTATUSRF " + Environment.NewLine);
                    sqlText.Append("    AND SALEWORK.SALESSLIPNUMRF = SUBSALE.SALESSLIPNUMRF " + Environment.NewLine);
                    sqlText.Append("    LEFT JOIN" + Environment.NewLine);
                    sqlText.Append("    (" + Environment.NewLine);
                    sqlText.Append("      SELECT" + Environment.NewLine);
                    sqlText.Append("       SALES.ENTERPRISECODERF," + Environment.NewLine);
                    sqlText.Append("       SALES.ACPTANODRSTATUSRF," + Environment.NewLine);
                    sqlText.Append("       SALES.SALESSLIPNUMRF," + Environment.NewLine);
                    sqlText.Append("       SALES.SALESSLIPCDRF," + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN ((SALES.SALESSLIPCDRF = 0 OR SALES.SALESSLIPCDRF =1 ) AND DTL.SALESSLIPCDDTLRF != 2 AND DTL.TAXATIONDIVCDRF = 2) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALAMNTCONSTAXINCLURF,-- 明細内税消費税金額" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN ((SALES.SALESSLIPCDRF = 0 OR SALES.SALESSLIPCDRF =1 ) AND DTL.SALESSLIPCDDTLRF != 2 AND DTL.TAXATIONDIVCDRF = 0) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALESOUTTAXRF, -- 明細外税消費税金額" + Environment.NewLine);
                    sqlText.Append("       --行値引" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISSALESTAXEXCGYO,-- 税抜値引金額(行値引)" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESOUTTAXGYO,-- 外税対象額(行値引)" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 1) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESTAXFREGYO, -- 非課税対象額(行値引)" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESINTAXGYO,-- 内税対象額(行値引)" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESOUTTAXGYO,    -- 外税額(行値引)" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESTAXFREGYO    -- 内税額(行値引)" + Environment.NewLine);
                    sqlText.Append("      FROM" + Environment.NewLine);
                    sqlText.Append("       ##SALESSLIPCLAIMWORKRF AS SALES WITH(READUNCOMMITTED) " + Environment.NewLine);
                    sqlText.Append("       INNER JOIN SALESDETAILRF AS DTL WITH(READUNCOMMITTED) " + Environment.NewLine);
                    sqlText.Append("       ON  SALES.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append("       AND SALES.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine);
                    sqlText.Append("       AND SALES.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF" + Environment.NewLine);
                    sqlText.Append("      GROUP BY" + Environment.NewLine);
                    sqlText.Append("       SALES.ENTERPRISECODERF," + Environment.NewLine);
                    sqlText.Append("       SALES.ACPTANODRSTATUSRF," + Environment.NewLine);
                    sqlText.Append("       SALES.SALESSLIPNUMRF," + Environment.NewLine);
                    sqlText.Append("       SALES.SALESSLIPCDRF" + Environment.NewLine);
                    sqlText.Append("    ) AS SALESDTL" + Environment.NewLine);
                    sqlText.Append("     ON  SUBSALE.ENTERPRISECODERF = SALESDTL.ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append("     AND SUBSALE.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine);
                    sqlText.Append("     AND SUBSALE.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF" + Environment.NewLine);
                    sqlText.Append("  ) AS SALE" + Environment.NewLine);

                    #endregion

                    #endregion

                    #region JOIN
                    sqlText.Append("LEFT JOIN CUSTOMERRF AS CLAIM WITH(READUNCOMMITTED)" + Environment.NewLine);
                    sqlText.Append(" ON SALE.ENTERPRISECODERF = CLAIM.ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append(" AND SALE.CLAIMCODERF = CLAIM.CUSTOMERCODERF" + Environment.NewLine);
                    // 売上金額処理区分設定マスタ
                    sqlText.Append("LEFT JOIN SALESPROCMONEYRF AS SALESPROC WITH(READUNCOMMITTED)" + Environment.NewLine);
                    sqlText.Append(" ON  CLAIM.ENTERPRISECODERF=SALESPROC.ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append(" AND SALESPROC.FRACPROCMONEYDIVRF=1" + Environment.NewLine);
                    sqlText.Append(" AND CLAIM.SALESCNSTAXFRCPROCCDRF=SALESPROC.FRACTIONPROCCODERF" + Environment.NewLine);

                    #endregion

                    #region GROUP BY句
                    sqlText.Append("GROUP BY " + Environment.NewLine);
                    sqlText.Append(" SALE.CLAIMCODERF," + Environment.NewLine);
                    sqlText.Append(" CLAIM.NAMERF," + Environment.NewLine);
                    sqlText.Append(" CLAIM.NAME2RF," + Environment.NewLine);
                    sqlText.Append(" CLAIM.CUSTOMERSNMRF," + Environment.NewLine);
                    sqlText.Append(" CLAIM.CONSTAXLAYMETHODRF,    --消費税転嫁方式" + Environment.NewLine);
                    sqlText.Append(" CLAIM.COLLECTCONDRF,         --回収条件" + Environment.NewLine);
                    sqlText.Append(" CLAIM.COLLECTMONEYCODERF,    --集金月区分コード" + Environment.NewLine);
                    sqlText.Append(" CLAIM.COLLECTMONEYDAYRF,     --集金日" + Environment.NewLine);
                    sqlText.Append(" CLAIM.SALESCNSTAXFRCPROCCDRF,--売上消費税端数処理コード" + Environment.NewLine);
                    sqlText.Append(" SALESPROC.FRACTIONPROCCDRF,  --端数処理単位" + Environment.NewLine);
                    sqlText.Append(" SALESPROC.FRACTIONPROCUNITRF,--端数処理区分" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATESTARTDATERF,     --税率開始日" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATERF,              --税率" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATESTARTDATE2RF,    --税率開始日2" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATEENDDATE2RF,      --税率終了日2" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATE2RF,             --税率2" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATESTARTDATE3RF,    --税率開始日3" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATEENDDATE3RF,      --税率終了日3" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATE3RF,             --税率3" + Environment.NewLine);
                    sqlText.Append(" CLAIM.CUSTCTAXLAYREFCDRF," + Environment.NewLine);
                    sqlText.Append(" SALE.TAXCONSTAXLAYMETHODRF" + Environment.NewLine);
                    sqlText.Append(") AS DMDPRC" + Environment.NewLine);
                    #endregion

                    sqlCommand.CommandText = sqlText.ToString();
                    myReader = sqlCommand.ExecuteReader();
                    List<CustDmdPrcWork> custDmdPrcWorkList = null;
                    CustDmdPrcWork custDmdPrcWork = null;
                    while (myReader.Read())
                    {
                        custDmdPrcWorkList = new List<CustDmdPrcWork>();
                        custDmdPrcWork = new CustDmdPrcWork();
                        #region 集計レコードセット
                        custDmdPrcWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); //端数処理区分
                        custDmdPrcWork.FractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF")); // 端数処理単位
                        custDmdPrcWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
                        custDmdPrcWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
                        custDmdPrcWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                        custDmdPrcWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));　　　　　　// 回収条件(得意先マスタ)
                        custDmdPrcWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));      // 端数処理区分(得意先マスタ)

                        // ■相殺
                        custDmdPrcWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));     // 相殺後今回売上金額
                        custDmdPrcWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));   // 相殺後外税対象額
                        custDmdPrcWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));     // 相殺後内税対象額
                        custDmdPrcWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF")); // 相殺後非課税対象額
                        custDmdPrcWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));               // 相殺後売上内税額
                        custDmdPrcWork.Salesouttax_s = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESOUTTAX_S"));
                        custDmdPrcWork.Retsalesouttax_s = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSALESOUTTAX_S"));
                        custDmdPrcWork.Dissaleouttax_s = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSALEOUTTAX_S"));
                        
                        custDmdPrcWork.Salesouttax_d = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAX_D"));
                        custDmdPrcWork.Retsalesouttax_d = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSALESOUTTAX_D"));
                        custDmdPrcWork.Dissaleouttax_d = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSALEOUTTAX_D"));

                        custDmdPrcWork.Salesouttax_m = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAX_M"));
                        custDmdPrcWork.Retsalesouttax_m = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSALESOUTTAX_M"));
                        custDmdPrcWork.Dissaleouttax_m = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSALEOUTTAX_M"));

                        // ■売上
                        custDmdPrcWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));            // 今回売上金額 
                        custDmdPrcWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));      // 今回売上外税対象額
                        custDmdPrcWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));        // 今回売上内税対象額
                        custDmdPrcWork.ItdedSalesTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESTAXFREERF"));    // 今回売上非課税対象額 
                        custDmdPrcWork.SalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESINTAXRF"));                  // 今回売上内税額
                        
                        // ■返品
                        custDmdPrcWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));    // 今回売上返品金額
                        custDmdPrcWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));    // 今回売上返品外税対象額
                        custDmdPrcWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));      // 今回売上返品内税対象額
                        custDmdPrcWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));  // 今回売上返品非課税対象額
                        custDmdPrcWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));          // 今回売上返品内税額
                        
                        // ■値引
                        custDmdPrcWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));      // 今回売上値引金額
                        custDmdPrcWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));    // 今回売上値引外税対象金額
                        custDmdPrcWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));      // 今回売上値引内税対象金額
                        custDmdPrcWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));  // 今回売上値引非課税対象金額
                        custDmdPrcWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));          // 今回売上値引内税額
                        
                        // 計算後請求金額 = 今回繰越残高 + (相殺後今回売上金額 + 相殺後今回売上消費税) ※親子レコード集計時に請求転嫁(子)の消費税加算
                        custDmdPrcWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF")); // 売上伝票枚数

                        custDmdPrcWork.Collectmoneycode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));// 0:当月,1:翌月,2:翌々月,3翌々々月
                        custDmdPrcWork.Collectmoneyday = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));

                        custDmdPrcWorkList.Add(custDmdPrcWork);
                        custDmdPrcParentWorkList.Add(SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF")).ToString(), custDmdPrcWorkList);
                        #endregion

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
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }

        /// <summary>
        /// 「売上締次専用」DictionaryProcマスタを作成する
        /// </summary>
        /// <param name="custDmdPrcChildrenWorkList">子集計得意先請求金額ワークList</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : CustomerDataマスタを作成する</br>
        /// <br>Programmer : 2013/08/08 汪権来</br>
        /// <br>管理番号   ：10902175-00 2013/06/18配信分</br>
        /// <br>             Redmine#35552 「売上締次更新」の処理速度遅延の調査と対応(№1921)</br>
        /// <br>Update Note: 2016/10/27 田建委</br>
        /// <br>管理番号   : 11275240-00</br>
        /// <br>             Redmine#48899 売上締次処理のレコードロック解除-READUNCOMMITTEDの追加</br>
        /// </remarks>
        private int GetDictionaryCroc(ref Dictionary<string, List<CustDmdPrcWork>> custDmdPrcChildrenWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = _timeOut;
                    StringBuilder sqlText = new StringBuilder();

                    #region ■集計レコード集計処理

                    #region SELECT文

                    sqlText.Append("SELECT" + Environment.NewLine);
                    sqlText.Append("DMDPRC.CLAIMCODERF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CLAIMNAMERF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CLAIMNAME2RF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CLAIMSNMRF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CUSTOMERCODERF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CUSTOMERNAMERF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CUSTOMERNAME2RF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.CUSTOMERSNMRF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.FRACTIONPROCCDRF,  --端数処理単位" + Environment.NewLine);
                    sqlText.Append("DMDPRC.FRACTIONPROCUNITRF,--端数処理区分" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RESULTSADDUPSECCDRF AS RESULTSSECTCDRF, --実績計上拠点" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESNETPRICERF + DMDPRC.RETSALESNETPRICERF +DMDPRC.SALESDISTTLTAXEXCRF AS OFSTHISTIMESALESRF,      --相殺後今回売上金額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESOUTTAXRF+DMDPRC.RETITDEDSALESOUTTAXRF+DMDPRC.ITDEDSALESDISOUTTAXRF AS ITDEDOFFSETOUTTAXRF,--相殺後外税対象額 " + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESINTAXRF+ DMDPRC.RETITDEDSALESINTAXRF+ DMDPRC.ITDEDSALESDISINTAXRF AS ITDEDOFFSETINTAXRF," + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALSUBTTLSUBTOTAXFRERF+DMDPRC.RETSALSUBTTLSUBTOTAXFRERF+DMDPRC.ITDEDSALESDISTAXFRERF AS ITDEDOFFSETTAXFREERF, --相殺後非課税対象額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALAMNTCONSTAXINCLURF + DMDPRC.RETSALAMNTCONSTAXINCLURF + DMDPRC.SALESDISTTLTAXINCLURF AS OFFSETINTAXRF,      --相殺後内税消費税" + Environment.NewLine);
                    sqlText.Append("-- ■ ■ 売上 ■ ■" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESNETPRICERF AS THISTIMESALESRF,      --今回売上金額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESOUTTAXRF AS ITDEDSALESOUTTAXRF,--売上外税対象額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESINTAXRF AS ITDEDSALESINTAXRF,  --売上内税対象額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALSUBTTLSUBTOTAXFRERF AS ITDEDSALESTAXFREERF,--売上非課税対象額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESOUTTAXRF AS SALESOUTTAX_D,    -- 伝票転嫁" + Environment.NewLine);
                    sqlText.Append("DMDPRC.DTLSALESOUTTAXRF AS SALESOUTTAX_M,-- 明細転嫁" + Environment.NewLine);
                    //sqlText.Append("DMDPRC.SALESOUTTAXRF1 +DMDPRC.SALESOUTTAXRF2 +DMDPRC.SALESOUTTAXRF3 AS  SALESOUTTAX_S, -- 請求転嫁(子)" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.SALESOUTTAXRF1*TAXRATERF +DMDPRC.SALESOUTTAXRF2*TAXRATE2RF +DMDPRC.SALESOUTTAXRF3*TAXRATE3RF AS  SALESOUTTAX_S, -- 請求転嫁(子)" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    //sqlText.Append("DMDPRC.SALESOUTTAXRF1_2 +DMDPRC.SALESOUTTAXRF2_2 +DMDPRC.SALESOUTTAXRF3_2 AS  SALESOUTTAX_S2, -- 請求転嫁(親)" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.SALESOUTTAXRF1_2*TAXRATERF +DMDPRC.SALESOUTTAXRF2_2*TAXRATE2RF +DMDPRC.SALESOUTTAXRF3_2*TAXRATE3RF AS  SALESOUTTAX_S2, -- 請求転嫁(親)" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.SALAMNTCONSTAXINCLURF AS SALESINTAXRF,--売上内税額" + Environment.NewLine);
                    sqlText.Append("-- ■ ■ 返品 ■ ■" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RETSALESNETPRICERF AS THISSALESPRICRGDSRF,   --今回売上返品額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RETITDEDSALESOUTTAXRF AS TTLITDEDRETOUTTAXRF,--返品外税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RETITDEDSALESINTAXRF AS TTLITDEDRETINTAXRF,  --返品内税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RETSALSUBTTLSUBTOTAXFRERF AS TTLITDEDRETTAXFREERF,--返品非課税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.RETSALESOUTTAXRF AS RETSALESOUTTAX_D, -- 伝票転嫁" + Environment.NewLine);
                    sqlText.Append("DMDPRC.DTLRETSALESOUTTAXRF AS RETSALESOUTTAX_M, -- 伝票転嫁" + Environment.NewLine);
                    //sqlText.Append("DMDPRC.RETSALESOUTTAXRF1 +DMDPRC.RETSALESOUTTAXRF2 +DMDPRC.RETSALESOUTTAXRF3 AS RETSALESOUTTAX_S, -- 請求転嫁(子)" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.RETSALESOUTTAXRF1*TAXRATERF +DMDPRC.RETSALESOUTTAXRF2*TAXRATE2RF +DMDPRC.RETSALESOUTTAXRF3*TAXRATE3RF AS RETSALESOUTTAX_S, -- 請求転嫁(子)" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    //sqlText.Append("DMDPRC.RETSALESOUTTAXRF1_2 +DMDPRC.RETSALESOUTTAXRF2_2 +DMDPRC.RETSALESOUTTAXRF3_2 AS RETSALESOUTTAX_S2, -- 請求転嫁(親)" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.RETSALESOUTTAXRF1_2*TAXRATERF +DMDPRC.RETSALESOUTTAXRF2_2*TAXRATE2RF +DMDPRC.RETSALESOUTTAXRF3_2*TAXRATE3RF AS RETSALESOUTTAX_S2, -- 請求転嫁(親)" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.RETSALAMNTCONSTAXINCLURF AS TTLRETINNERTAXRF,  --返品内税額合計" + Environment.NewLine);
                    sqlText.Append("-- ■ ■ 値引 ■ ■" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESDISTTLTAXEXCRF AS THISSALESPRICDISRF,     --今回売上値引金額" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESDISOUTTAXRF AS TTLITDEDDISOUTTAXRF,  --値引外税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESDISINTAXRF AS TTLITDEDDISINTAXRF,    --値引内税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.ITDEDSALESDISTAXFRERF AS TTLITDEDDISTAXFREERF, --値引非課税対象額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESDISOUTTAXRF AS DISSALESOUTTAX_D,    -- 伝票転嫁" + Environment.NewLine);
                    sqlText.Append("DMDPRC.DTLSALESDISOUTTAXRF AS DISSALESOUTTAX_M, -- 明細転嫁" + Environment.NewLine);
                    //sqlText.Append("DMDPRC.SALESDISOUTTAXRF1 +DMDPRC.SALESDISOUTTAXRF2 +DMDPRC.SALESDISOUTTAXRF3 AS DISSALESOUTTAX_S, -- 請求転嫁(子)" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.SALESDISOUTTAXRF1*TAXRATERF +DMDPRC.SALESDISOUTTAXRF2*TAXRATE2RF +DMDPRC.SALESDISOUTTAXRF3*TAXRATE3RF AS DISSALESOUTTAX_S, -- 請求転嫁(子)" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    //sqlText.Append("DMDPRC.SALESDISOUTTAXRF1_2 +DMDPRC.SALESDISOUTTAXRF2_2 +DMDPRC.SALESDISOUTTAXRF3_2 AS DISSALESOUTTAX_S2, -- 請求転嫁(親)" + Environment.NewLine);// DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.SALESDISOUTTAXRF1_2*TAXRATERF +DMDPRC.SALESDISOUTTAXRF2_2*TAXRATE2RF +DMDPRC.SALESDISOUTTAXRF3_2*TAXRATE3RF AS DISSALESOUTTAX_S2, -- 請求転嫁(親)" + Environment.NewLine);// ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正
                    sqlText.Append("DMDPRC.SALESDISTTLTAXINCLURF AS TTLDISINNERTAXRF,  --値引内税額合計" + Environment.NewLine);
                    sqlText.Append("DMDPRC.SALESSLIPCOUNT AS SALESSLIPCOUNTRF,         --売上伝票枚数" + Environment.NewLine);
                    sqlText.Append("DMDPRC.COLLECTCONDRF AS COLLECTCONDRF,             --回収条件" + Environment.NewLine);
                    sqlText.Append("DMDPRC.CONSTAXLAYMETHODRF AS CONSTAXLAYMETHODRF,   --消費税転嫁方式" + Environment.NewLine);// ADD 2010/12/20
                    sqlText.Append("DMDPRC.SALESCNSTAXFRCPROCCDRF AS FRACTIONPROCCDRF, --端数処理区分" + Environment.NewLine);
                    sqlText.Append("DMDPRC.COLLECTMONEYCODERF AS COLLECTMONEYCODERF,   --集金月区分コード" + Environment.NewLine);
                    sqlText.Append("DMDPRC.COLLECTMONEYDAYRF AS COLLECTMONEYDAYRF,     --集金日" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,   --税率開始日" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATEENDDATERF AS TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATERF AS TAXRATERF,                     --税率" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF, --税率開始日2" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,     --税率終了日2" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATE2RF AS TAXRATE2RF,                   --税率2" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF, --税率開始日3" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,     --税率終了日3" + Environment.NewLine);
                    sqlText.Append("DMDPRC.TAXRATE3RF AS TAXRATE3RF                    --税率3" + Environment.NewLine);
                    sqlText.Append("FROM" + Environment.NewLine);
                    sqlText.Append("(" + Environment.NewLine);
                    #endregion

                    #region SUBクエリ
                    sqlText.Append("  SELECT" + Environment.NewLine);
                    sqlText.Append("   SALE.CLAIMCODERF AS CLAIMCODERF," + Environment.NewLine);
                    sqlText.Append("   CLAIM.NAMERF AS CLAIMNAMERF," + Environment.NewLine);
                    sqlText.Append("   CLAIM.NAME2RF AS CLAIMNAME2RF," + Environment.NewLine);
                    sqlText.Append("   CLAIM.CUSTOMERSNMRF AS CLAIMSNMRF," + Environment.NewLine);
                    sqlText.Append("   SALE.CUSTOMERCODERF AS CUSTOMERCODERF," + Environment.NewLine);
                    sqlText.Append("   CUST.NAMERF AS CUSTOMERNAMERF," + Environment.NewLine);
                    sqlText.Append("   CUST.NAME2RF AS CUSTOMERNAME2RF," + Environment.NewLine);
                    sqlText.Append("   CUST.CUSTOMERSNMRF AS CUSTOMERSNMRF," + Environment.NewLine);
                    sqlText.Append("   SALE.RESULTSADDUPSECCDRF,                              --実績計上拠点" + Environment.NewLine);
                    sqlText.Append("   CLAIM.CONSTAXLAYMETHODRF AS CONSTAXLAYMETHODRF,        --消費税転嫁方式" + Environment.NewLine);// ADD 2010/12/20
                    sqlText.Append("   CLAIM.COLLECTCONDRF AS COLLECTCONDRF,                  --回収条件" + Environment.NewLine);
                    sqlText.Append("   CLAIM.COLLECTMONEYCODERF AS COLLECTMONEYCODERF,        --集金月区分コード" + Environment.NewLine);
                    sqlText.Append("   CLAIM.COLLECTMONEYDAYRF AS COLLECTMONEYDAYRF,          --集金日" + Environment.NewLine);
                    sqlText.Append("   CLAIM.SALESCNSTAXFRCPROCCDRF AS SALESCNSTAXFRCPROCCDRF,--売上消費税端数処理コード" + Environment.NewLine);
                    sqlText.Append("   SALESPROC.FRACTIONPROCCDRF,                            --端数処理単位" + Environment.NewLine);
                    sqlText.Append("   SALESPROC.FRACTIONPROCUNITRF,                          --端数処理区分" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,         --税率開始日" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATEENDDATERF AS TAXRATEENDDATERF,             --税率終了日" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATERF AS TAXRATERF,                           --税率" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF,       --税率開始日2" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,           --税率終了日2" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATE2RF AS TAXRATE2RF,                         --税率2" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF,       --税率開始日3" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,           --税率終了日3" + Environment.NewLine);
                    sqlText.Append("   SALE.TAXRATE3RF AS TAXRATE3RF,                         --税率3" + Environment.NewLine);
                    sqlText.Append("   COUNT(SALE.SALESSLIPNUMRF) SALESSLIPCOUNT,             --伝票枚数" + Environment.NewLine);
                    sqlText.Append("   -- ■ ■ 売上 ■ ■ " + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS SALESNETPRICERF,              --売上正価金額" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.ITDEDSALESOUTTAXRF ELSE 0 END)) AS ITDEDSALESOUTTAXRF,        --売上外税対象額" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.ITDEDSALESINTAXRF ELSE 0 END)) AS ITDEDSALESINTAXRF,          --売上内税対象額" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALSUBTTLSUBTOTAXFRERF ELSE 0 END)) AS SALSUBTTLSUBTOTAXFRERF,--売上小計非課税対象額" + Environment.NewLine);
                    sqlText.Append("   -- 伝票転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM( CASE WHEN SALE.CONSTAXLAYMETHODRF =0 AND SALE.SALESSLIPCDRF =0 THEN SALE.SALESOUTTAXRF ELSE 0 END ) AS SALESOUTTAXRF,--消費税額（外税）伝票" + Environment.NewLine);
                    sqlText.Append("   -- 明細転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM(CASE WHEN SALE.CONSTAXLAYMETHODRF = 1 AND SALE.SALESSLIPCDRF =0 THEN SALE.DTLSALESOUTTAXRF ELSE 0 END ) AS DTLSALESOUTTAXRF,--消費税額（外税）明細" + Environment.NewLine);
                    sqlText.Append("   -- 請求転嫁(子)   " + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)    " + Environment.NewLine);
                    //sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS SALESOUTTAXRF1, --売上金額消費税額（外税）税率1" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    //sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESOUTTAXRF2,     --売上金額消費税額（外税）税率2" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    //sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESOUTTAXRF3,     --売上金額消費税額（外税）税率3" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)    " + Environment.NewLine);
                    sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF1, --売上金額消費税額（外税）税率1" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF2,     --売上金額消費税額（外税）税率2" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF3,     --売上金額消費税額（外税）税率3" + Environment.NewLine);
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    sqlText.Append("   -- 請求転嫁(親)" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)    " + Environment.NewLine);
                    //sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS SALESOUTTAXRF1_2,--売上金額消費税額（外税）税率1" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    //sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESOUTTAXRF2_2,     --売上金額消費税額（外税）税率2" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    //sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESOUTTAXRF3_2,     --売上金額消費税額（外税）税率3       " + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF)    " + Environment.NewLine);
                    sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF1_2,--売上金額消費税額（外税）税率1" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF2_2,     --売上金額消費税額（外税）税率2" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =0) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    sqlText.Append("          THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS SALESOUTTAXRF3_2,     --売上金額消費税額（外税）税率3       " + Environment.NewLine);
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALAMNTCONSTAXINCLURF ELSE 0 END)) AS SALAMNTCONSTAXINCLURF,     --売上金額消費税額（内税）" + Environment.NewLine);
                    sqlText.Append("   -- ■ ■ 返品 ■ ■ " + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS RETSALESNETPRICERF,              --返品 売上正価金額" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.ITDEDSALESOUTTAXRF ELSE 0 END)) AS RETITDEDSALESOUTTAXRF,        --返品 売上外税対象額" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.ITDEDSALESINTAXRF ELSE 0 END)) AS RETITDEDSALESINTAXRF,          --返品 売上内税対象額" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALSUBTTLSUBTOTAXFRERF ELSE 0 END)) AS RETSALSUBTTLSUBTOTAXFRERF,--返品 売上小計非課税対象額 " + Environment.NewLine);
                    sqlText.Append("   -- 伝票転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 0 ) AND (SALE.SALESSLIPCDRF =1) THEN SALE.SALESOUTTAXRF ELSE 0 END)) AS RETSALESOUTTAXRF,     --返品 消費税額（外税）伝票転嫁" + Environment.NewLine);
                    sqlText.Append("   -- 明細転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 1) AND (SALE.SALESSLIPCDRF =1) THEN SALE.DTLSALESOUTTAXRF ELSE 0 END)) AS DTLRETSALESOUTTAXRF,--返品 消費税額（外税）明細転嫁" + Environment.NewLine);
                    sqlText.Append("   -- 請求転嫁(子)" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS RETSALESOUTTAXRF1, --返品 売上金額消費税額（外税）税率1" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS RETSALESOUTTAXRF2,     --返品 売上金額消費税額（外税）税率2" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS RETSALESOUTTAXRF3,     --返品 売上金額消費税額（外税）税率3" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF1, --返品 売上金額消費税額（外税）税率1" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF2,     --返品 売上金額消費税額（外税）税率2" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF3,     --返品 売上金額消費税額（外税）税率3" + Environment.NewLine);
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    sqlText.Append("   -- 請求転嫁(親)" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF * SALE.TAXRATERF) ELSE 0 END)) AS RETSALESOUTTAXRF1_2, --返品 売上金額消費税額（外税）税率1" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS RETSALESOUTTAXRF2_2,     --返品 売上金額消費税額（外税）税率2" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS RETSALESOUTTAXRF3_2,     --返品 売上金額消費税額（外税）税率3" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF1_2, --返品 売上金額消費税額（外税）税率1" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF2_2,     --返品 売上金額消費税額（外税）税率2" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.SALESSLIPCDRF =1) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESOUTTAXRF) ELSE 0 END)) AS RETSALESOUTTAXRF3_2,     --返品 売上金額消費税額（外税）税率3" + Environment.NewLine);
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    sqlText.Append("   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALAMNTCONSTAXINCLURF ELSE 0 END)) AS RETSALAMNTCONSTAXINCLURF,  --返品 売上金額消費税額（内税）      " + Environment.NewLine);
                    sqlText.Append("   SUM(SALE.SALESDISTTLTAXEXCRF) AS SALESDISTTLTAXEXCRF,    --売上値引金額計（税抜き）" + Environment.NewLine);
                    sqlText.Append("   SUM(SALE.ITDEDSALESDISOUTTAXRF) AS ITDEDSALESDISOUTTAXRF,--売上値引外税対象額合計" + Environment.NewLine);
                    sqlText.Append("   SUM(SALE.ITDEDSALESDISINTAXRF) AS ITDEDSALESDISINTAXRF,  --売上値引内税対象額合計 " + Environment.NewLine);
                    sqlText.Append("   SUM(SALE.ITDEDSALESDISTAXFRERF) AS ITDEDSALESDISTAXFRERF,--売上値引非課税対象額合計" + Environment.NewLine);
                    sqlText.Append("   -- 伝票転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM(CASE WHEN (SALE.CONSTAXLAYMETHODRF = 0) THEN SALE.SALESDISOUTTAXRF ELSE 0 END) AS SALESDISOUTTAXRF,    --値引消費税額（外税）伝票転嫁" + Environment.NewLine);
                    sqlText.Append("   -- 明細転嫁" + Environment.NewLine);
                    sqlText.Append("   SUM(CASE WHEN (SALE.CONSTAXLAYMETHODRF = 1) THEN SALE.SALESDISOUTTAXRF ELSE 0 END) AS DTLSALESDISOUTTAXRF, --値引消費税額（外税）明細転嫁" + Environment.NewLine);
                    sqlText.Append("   -- 請求転嫁(子)" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATERF) ELSE 0 END)) AS SALESDISOUTTAXRF1,--売上値引消費税額（外税）税率1" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESDISOUTTAXRF2,--売上値引消費税額（外税）税率2" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESDISOUTTAXRF3,--売上値引消費税額（外税）税率3" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF1,--売上値引消費税額（外税）税率1" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF2,--売上値引消費税額（外税）税率2" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 3) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF3,--売上値引消費税額（外税）税率3" + Environment.NewLine);
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    sqlText.Append("   -- 請求転嫁(親)" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATERF) ELSE 0 END)) AS SALESDISOUTTAXRF1_2,--売上値引消費税額（外税）税率1" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE2RF) ELSE 0 END)) AS SALESDISOUTTAXRF2_2,--売上値引消費税額（外税）税率2" + Environment.NewLine);
                    //sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    //sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF * TAXRATE3RF) ELSE 0 END)) AS SALESDISOUTTAXRF3_2,--売上値引消費税額（外税）税率3" + Environment.NewLine);
                    // DEL 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 ----->>>>>
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATERF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATERF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF1_2,--売上値引消費税額（外税）税率1" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE2RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE2RF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF2_2,--売上値引消費税額（外税）税率2" + Environment.NewLine);
                    sqlText.Append("   SUM((CASE WHEN (SALE.CONSTAXLAYMETHODRF = 2) AND (SALE.ADDUPADATERF >= SALE.TAXRATESTARTDATE3RF AND SALE.ADDUPADATERF <= SALE.TAXRATEENDDATE3RF) " + Environment.NewLine);
                    sqlText.Append("        THEN (SALE.ITDEDSALESDISOUTTAXRF) ELSE 0 END)) AS SALESDISOUTTAXRF3_2,--売上値引消費税額（外税）税率3" + Environment.NewLine);
                    // ADD 田村顕成 2023/11/24 売掛残高一覧消費税額相違不具合修正 -----<<<<<
                    sqlText.Append("   SUM(SALE.SALESDISTTLTAXINCLURF) AS SALESDISTTLTAXINCLURF --売上値引消費税額（内税）" + Environment.NewLine);
                    sqlText.Append("  FROM" + Environment.NewLine);
                    sqlText.Append("  (" + Environment.NewLine);
                    sqlText.Append("     SELECT" + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ENTERPRISECODERF," + Environment.NewLine);
                    sqlText.Append("      SALEWORK.CLAIMCODERF AS CLAIMCODERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.CONSTAXLAYMETHODRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.CUSTOMERCODERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.RESULTSADDUPSECCDRF, --実績計上拠点" + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ADDUPADATERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.LOGICALDELETECODERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ACPTANODRSTATUSRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.DEBITNOTEDIVRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESSLIPNUMRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESSLIPCDRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESNETPRICERF + DISSALESTAXEXCGYO AS SALESNETPRICERF ," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ITDEDSALESOUTTAXRF + ITDEDDISSALESOUTTAXGYO AS ITDEDSALESOUTTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ITDEDSALESINTAXRF + ITDEDDISSALESINTAXGYO AS ITDEDSALESINTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALSUBTTLSUBTOTAXFRERF + ITDEDDISSALESTAXFREGYO AS SALSUBTTLSUBTOTAXFRERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESOUTTAXRF + DISSALESOUTTAXGYO AS SALESOUTTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALAMNTCONSTAXINCLURF + DISSALESTAXFREGYO AS SALAMNTCONSTAXINCLURF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESDISTTLTAXEXCRF - DISSALESTAXEXCGYO AS SALESDISTTLTAXEXCRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ITDEDSALESDISOUTTAXRF - ITDEDDISSALESOUTTAXGYO AS ITDEDSALESDISOUTTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ITDEDSALESDISINTAXRF - ITDEDDISSALESINTAXGYO AS ITDEDSALESDISINTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.ITDEDSALESDISTAXFRERF - ITDEDDISSALESTAXFREGYO AS ITDEDSALESDISTAXFRERF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESDISOUTTAXRF - DISSALESOUTTAXGYO AS SALESDISOUTTAXRF," + Environment.NewLine);
                    sqlText.Append("      SUBSALE.SALESDISTTLTAXINCLURF - DISSALESTAXFREGYO AS SALESDISTTLTAXINCLURF," + Environment.NewLine);
                    sqlText.Append("      SALESDTL.DTLSALESOUTTAXRF + SALESDTL.DISSALESOUTTAXGYO AS DTLSALESOUTTAXRF, " + Environment.NewLine);
                    sqlText.Append("      SALESDTL.DTLSALAMNTCONSTAXINCLURF + SALESDTL.DISSALESTAXFREGYO AS DTLSALAMNTCONSTAXINCLURF," + Environment.NewLine);
                    sqlText.Append("      TAX.CONSTAXLAYMETHODRF AS TAXCONSTAXLAYMETHODRF," + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATESTARTDATERF AS TAXRATESTARTDATERF,   --税率開始日" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATEENDDATERF AS TAXRATEENDDATERF,       --税率終了日" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATERF AS TAXRATERF,                     --税率" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATESTARTDATE2RF AS TAXRATESTARTDATE2RF, --税率開始日2" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATEENDDATE2RF AS TAXRATEENDDATE2RF,     --税率終了日2" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATE2RF AS TAXRATE2RF,                   --税率2" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATESTARTDATE3RF AS TAXRATESTARTDATE3RF, --税率開始日3" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATEENDDATE3RF AS TAXRATEENDDATE3RF,     --税率終了日3" + Environment.NewLine);
                    sqlText.Append("      TAX.TAXRATE3RF AS TAXRATE3RF                    --税率3" + Environment.NewLine);
                    sqlText.Append("     FROM" + Environment.NewLine);
                    sqlText.Append("     TAXRATESETRF AS TAX WITH(READUNCOMMITTED) " + Environment.NewLine);

                    #region SUBクエリ JOIN
                    sqlText.Append("     INNER JOIN ##SALESSLIPCLAIMWORKRF AS SALEWORK WITH(READUNCOMMITTED) " + Environment.NewLine);
                    sqlText.Append("     ON SALEWORK.ENTERPRISECODERF = TAX.ENTERPRISECODERF " + Environment.NewLine);
                    //----- UPD 2016/10/27 田建委 Redmine#48899 売上締次処理のレコードロック解除 ----->>>>>
                    //sqlText.Append("     INNER JOIN SALESSLIPRF AS SUBSALE " + Environment.NewLine);
                    sqlText.Append("     INNER JOIN SALESSLIPRF AS SUBSALE WITH(READUNCOMMITTED)" + Environment.NewLine);
                    //----- UPD 2016/10/27 田建委 Redmine#48899 売上締次処理のレコードロック解除 -----<<<<<
                    sqlText.Append("     ON SALEWORK.ENTERPRISECODERF = SUBSALE.ENTERPRISECODERF " + Environment.NewLine);
                    sqlText.Append("     AND SALEWORK.ACPTANODRSTATUSRF = SUBSALE.ACPTANODRSTATUSRF " + Environment.NewLine);
                    sqlText.Append("     AND SALEWORK.SALESSLIPNUMRF = SUBSALE.SALESSLIPNUMRF " + Environment.NewLine);


                    sqlText.Append("    LEFT JOIN" + Environment.NewLine);
                    sqlText.Append("    (" + Environment.NewLine);
                    sqlText.Append("      SELECT" + Environment.NewLine);
                    sqlText.Append("       SALES.ENTERPRISECODERF," + Environment.NewLine);
                    sqlText.Append("       SALES.ACPTANODRSTATUSRF," + Environment.NewLine);
                    sqlText.Append("       SALES.SALESSLIPNUMRF," + Environment.NewLine);
                    sqlText.Append("       SALES.SALESSLIPCDRF," + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN ((SALES.SALESSLIPCDRF = 0 OR SALES.SALESSLIPCDRF =1 ) AND DTL.SALESSLIPCDDTLRF != 2 AND DTL.TAXATIONDIVCDRF = 2) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALAMNTCONSTAXINCLURF,-- 明細内税消費税金額" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN ((SALES.SALESSLIPCDRF = 0 OR SALES.SALESSLIPCDRF =1 ) AND DTL.SALESSLIPCDDTLRF != 2 AND DTL.TAXATIONDIVCDRF = 0) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DTLSALESOUTTAXRF, -- 明細外税消費税金額" + Environment.NewLine);
                    sqlText.Append("       --行値引" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISSALESTAXEXCGYO,-- 税抜値引金額(行値引)" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESOUTTAXGYO,-- 外税対象額(行値引)" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 1) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESTAXFREGYO, -- 非課税対象額(行値引)" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS ITDEDDISSALESINTAXGYO,-- 内税対象額(行値引)       " + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 0) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESOUTTAXGYO,    -- 外税額(行値引)" + Environment.NewLine);
                    sqlText.Append("       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0  AND DTL.TAXATIONDIVCDRF  = 2) THEN DTL.SALESPRICECONSTAXRF ELSE 0 END) AS DISSALESTAXFREGYO    -- 内税額(行値引)       " + Environment.NewLine);
                    sqlText.Append("      FROM" + Environment.NewLine);
                    sqlText.Append("       ##SALESSLIPCLAIMWORKRF  AS SALES WITH(READUNCOMMITTED) " + Environment.NewLine);
                    sqlText.Append("       INNER JOIN SALESDETAILRF AS DTL WITH(READUNCOMMITTED) " + Environment.NewLine);
                    sqlText.Append("       ON  SALES.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append("       AND SALES.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine);
                    sqlText.Append("       AND SALES.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF" + Environment.NewLine);
                    sqlText.Append("      GROUP BY" + Environment.NewLine);
                    sqlText.Append("       SALES.ENTERPRISECODERF," + Environment.NewLine);
                    sqlText.Append("       SALES.ACPTANODRSTATUSRF," + Environment.NewLine);
                    sqlText.Append("       SALES.SALESSLIPNUMRF," + Environment.NewLine);
                    sqlText.Append("       SALES.SALESSLIPCDRF" + Environment.NewLine);
                    sqlText.Append("    ) AS SALESDTL" + Environment.NewLine);
                    sqlText.Append("     ON  SUBSALE.ENTERPRISECODERF = SALESDTL.ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append("     AND SUBSALE.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine);
                    sqlText.Append("     AND SUBSALE.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF" + Environment.NewLine);
                    sqlText.Append("  ) AS SALE" + Environment.NewLine);
                    #endregion

                    #endregion

                    #region JOIN
                    sqlText.Append("LEFT JOIN CUSTOMERRF AS CUST WITH(READUNCOMMITTED) " + Environment.NewLine);
                    sqlText.Append(" ON SALE.ENTERPRISECODERF = CUST.ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append(" AND SALE.CUSTOMERCODERF = CUST.CUSTOMERCODERF" + Environment.NewLine);
                    sqlText.Append("LEFT JOIN CUSTOMERRF AS CLAIM WITH(READUNCOMMITTED) " + Environment.NewLine);
                    sqlText.Append(" ON SALE.ENTERPRISECODERF = CLAIM.ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append(" AND SALE.CLAIMCODERF = CLAIM.CUSTOMERCODERF" + Environment.NewLine);
                    // 売上金額処理区分設定マスタ
                    sqlText.Append("LEFT JOIN SALESPROCMONEYRF AS SALESPROC WITH(READUNCOMMITTED)" + Environment.NewLine);
                    sqlText.Append(" ON  CLAIM.ENTERPRISECODERF=SALESPROC.ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append(" AND SALESPROC.FRACPROCMONEYDIVRF=1" + Environment.NewLine);
                    sqlText.Append(" AND CLAIM.SALESCNSTAXFRCPROCCDRF=SALESPROC.FRACTIONPROCCODERF" + Environment.NewLine);
                    #endregion

                    #region GROUP BY句
                    sqlText.Append("GROUP BY " + Environment.NewLine);
                    sqlText.Append(" SALE.CLAIMCODERF," + Environment.NewLine);
                    sqlText.Append(" CLAIM.NAMERF," + Environment.NewLine);
                    sqlText.Append(" CLAIM.NAME2RF," + Environment.NewLine);
                    sqlText.Append(" CLAIM.CUSTOMERSNMRF," + Environment.NewLine);
                    sqlText.Append(" SALE.CUSTOMERCODERF," + Environment.NewLine);
                    sqlText.Append(" CUST.NAMERF," + Environment.NewLine);
                    sqlText.Append(" CUST.NAME2RF," + Environment.NewLine);
                    sqlText.Append(" CUST.CUSTOMERSNMRF," + Environment.NewLine);
                    sqlText.Append(" SALE.RESULTSADDUPSECCDRF," + Environment.NewLine);
                    sqlText.Append(" CLAIM.CONSTAXLAYMETHODRF,     --消費税転嫁方式" + Environment.NewLine);
                    sqlText.Append(" CLAIM.COLLECTCONDRF,          --回収条件" + Environment.NewLine);
                    sqlText.Append(" CLAIM.COLLECTMONEYCODERF,     --集金月区分コード" + Environment.NewLine);
                    sqlText.Append(" CLAIM.COLLECTMONEYDAYRF,      --集金日" + Environment.NewLine);
                    sqlText.Append(" CLAIM.SALESCNSTAXFRCPROCCDRF, --売上消費税端数処理コード" + Environment.NewLine);
                    sqlText.Append(" CLAIM.CUSTCTAXLAYREFCDRF," + Environment.NewLine);
                    sqlText.Append(" SALESPROC.FRACTIONPROCCDRF,   --端数処理単位" + Environment.NewLine);
                    sqlText.Append(" SALESPROC.FRACTIONPROCUNITRF, --端数処理区分" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATESTARTDATERF,      --税率開始日" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATEENDDATERF,        --税率終了日" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATERF,               --税率" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATESTARTDATE2RF,     --税率開始日2" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATEENDDATE2RF,       --税率終了日2" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATE2RF,              --税率2" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATESTARTDATE3RF,     --税率開始日3" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATEENDDATE3RF,       --税率終了日3" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXRATE3RF,              --税率3" + Environment.NewLine);
                    sqlText.Append(" SALE.TAXCONSTAXLAYMETHODRF" + Environment.NewLine);
                    sqlText.Append(") AS DMDPRC" + Environment.NewLine);
                    #endregion

                    sqlCommand.CommandText = sqlText.ToString();
                    myReader = sqlCommand.ExecuteReader();
                    CustDmdPrcWork custDmdPrcChildWork = null;
                    List<CustDmdPrcWork> custDmdPrcChildWorkList = null;
                    while (myReader.Read())
                    {
                        #region 集計レコードセット
                        custDmdPrcChildWork = new CustDmdPrcWork();

                        #region 親・子レコードセット
                        custDmdPrcChildWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                        custDmdPrcChildWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        custDmdPrcChildWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); //端数処理区分
                        custDmdPrcChildWork.FractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF")); // 端数処理単位

                        custDmdPrcChildWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
                        custDmdPrcChildWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
                        custDmdPrcChildWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                        custDmdPrcChildWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));　　　　　　// 回収条件(得意先マスタ)
                        custDmdPrcChildWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));　// 消費税転嫁方式(得意先マスタ) // ADD 2010/12/20
                        custDmdPrcChildWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));      // 端数処理区分(得意先マスタ)
                        custDmdPrcChildWork.ResultsSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSSECTCDRF"));       // 実績拠点コード

                        custDmdPrcChildWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        custDmdPrcChildWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        custDmdPrcChildWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                        custDmdPrcChildWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));

                        // ■相殺
                        custDmdPrcChildWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));     // 相殺後今回売上金額
                        custDmdPrcChildWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));   // 相殺後外税対象額
                        custDmdPrcChildWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));     // 相殺後内税対象額
                        custDmdPrcChildWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF")); // 相殺後非課税対象額
                        custDmdPrcChildWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));               // 相殺後売上内税額

                        custDmdPrcChildWork.Salesouttax_s = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESOUTTAX_S"));
                        custDmdPrcChildWork.Retsalesouttax_s = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSALESOUTTAX_S"));
                        custDmdPrcChildWork.Dissalesouttax_s = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSALESOUTTAX_S"));

                        custDmdPrcChildWork.Salesouttax_s2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESOUTTAX_S2"));
                        custDmdPrcChildWork.Retsalesouttax_s2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETSALESOUTTAX_S2"));
                        custDmdPrcChildWork.Dissalesouttax_s2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISSALESOUTTAX_S2"));
                        
                        custDmdPrcChildWork.Salesouttax_d = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAX_D"));
                        custDmdPrcChildWork.Retsalesouttax_d = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSALESOUTTAX_D"));
                        custDmdPrcChildWork.Dissalesouttax_d = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSALESOUTTAX_D"));

                        custDmdPrcChildWork.Salesouttax_m = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAX_M"));
                        custDmdPrcChildWork.Retsalesouttax_m = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("RETSALESOUTTAX_M"));
                        custDmdPrcChildWork.Dissalesouttax_m = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISSALESOUTTAX_M"));

                        // ■売上
                        custDmdPrcChildWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));            // 今回売上金額 
                        custDmdPrcChildWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));      // 今回売上外税対象額
                        custDmdPrcChildWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));        // 今回売上内税対象額
                        custDmdPrcChildWork.ItdedSalesTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESTAXFREERF"));    // 今回売上非課税対象額 
                        custDmdPrcChildWork.SalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESINTAXRF"));                  // 今回売上内税額
                        
                        // ■返品
                        custDmdPrcChildWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));  // 今回売上返品金額
                        custDmdPrcChildWork.TtlItdedRetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETOUTTAXRF"));  // 今回売上返品外税対象額
                        custDmdPrcChildWork.TtlItdedRetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETINTAXRF"));    // 今回売上返品内税対象額
                        custDmdPrcChildWork.TtlItdedRetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDRETTAXFREERF"));// 今回売上返品非課税対象額
                        custDmdPrcChildWork.TtlRetInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLRETINNERTAXRF"));        // 今回売上返品内税額
                        
                        // ■値引
                        custDmdPrcChildWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));      // 今回売上値引金額
                        custDmdPrcChildWork.TtlItdedDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISOUTTAXRF"));    // 今回売上値引外税対象金額
                        custDmdPrcChildWork.TtlItdedDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISINTAXRF"));      // 今回売上値引内税対象金額
                        custDmdPrcChildWork.TtlItdedDisTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDDISTAXFREERF"));  // 今回売上値引非課税対象金額
                        custDmdPrcChildWork.TtlDisInnerTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLDISINNERTAXRF"));          // 今回売上値引内税額
                        
                        custDmdPrcChildWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF")); // 売上伝票枚数

                        custDmdPrcChildWork.Collectmoneycode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));// 0:当月,1:翌月,2:翌々月,3翌々々月
                        custDmdPrcChildWork.Collectmoneyday = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));

                        #endregion

                        custDmdPrcChildrenWorkList.TryGetValue(custDmdPrcChildWork.ClaimCode.ToString(), out custDmdPrcChildWorkList);

                        //親・子レコードセット
                        if (custDmdPrcChildWorkList != null)
                        {
                            custDmdPrcChildWorkList.Add(custDmdPrcChildWork);
                            custDmdPrcChildrenWorkList[custDmdPrcChildWork.ClaimCode.ToString()] = custDmdPrcChildWorkList;
                        }
                        else
                        {
                            custDmdPrcChildWorkList = new List<CustDmdPrcWork>();
                            custDmdPrcChildWorkList.Add(custDmdPrcChildWork);
                            custDmdPrcChildrenWorkList.Add(custDmdPrcChildWork.ClaimCode.ToString(), custDmdPrcChildWorkList);
                        }

                        #endregion

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
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }

        /// <summary>
        /// 「売上締次専用」得意先請求金額ワーク用Listから売上データを取得します
        /// </summary>
        /// <param name="custDmdPrcWork">得意先請求金額ワーク</param>
        /// <param name="custDmdPrcChildWorkList">請求金額マスタ更新パラメータList</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="custDmdPrcParentWorkList">親集計得意先請求金額ワークList</param>
        /// <param name="custDmdPrcChildrenWorkList">子集計得意先請求金額ワークList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額ワーク用Listから売上データを取得します</br>
        /// <br>Programmer : 2013/08/08 汪権来</br>
        /// <br>管理番号   ：10902175-00 2013/06/18配信分</br>
        /// <br>             Redmine#35552 「売上締次更新」の処理速度遅延の調査と対応(№1921)</br>
        /// </remarks>
        private int GetSalesSlipForCustDmd(ref CustDmdPrcWork custDmdPrcWork, ref ArrayList custDmdPrcChildWorkList,
            ref SqlConnection sqlConnection, Dictionary<string, List<CustDmdPrcWork>> custDmdPrcParentWorkList,
            Dictionary<string, List<CustDmdPrcWork>> custDmdPrcChildrenWorkList)
        {
            return GetSalesSlipProcForCustDmd(ref custDmdPrcWork, ref custDmdPrcChildWorkList, ref sqlConnection, custDmdPrcParentWorkList, custDmdPrcChildrenWorkList);
        }

        /// <summary>
        /// 「売上締次専用」得意先請求金額ワーク用Listから売上データを取得します
        /// </summary>
        /// <param name="custDmdPrcWork">得意先請求金額ワーク</param>
        /// <param name="custDmdPrcChildWorkList">請求金額マスタ更新パラメータList</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="custDmdPrcParentWorkList">親集計得意先請求金額ワークList</param>
        /// <param name="custDmdPrcChildrenWorkList">子集計得意先請求金額ワークList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額ワーク用Listから売上データを取得します</br>
        /// <br>Programmer : 2013/08/08 汪権来</br>
        /// <br>管理番号   ：10902175-00 2013/06/18配信分</br>
        /// <br>             Redmine#35552 「売上締次更新」の処理速度遅延の調査と対応(№1921)</br>
        /// </remarks>
        private int GetSalesSlipProcForCustDmd(ref CustDmdPrcWork custDmdPrcWork, ref ArrayList custDmdPrcChildWorkList,
            ref SqlConnection sqlConnection, Dictionary<string, List<CustDmdPrcWork>> custDmdPrcParentWorkList,
            Dictionary<string, List<CustDmdPrcWork>> custDmdPrcChildrenWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                List<CustDmdPrcWork> custDmdPrcWorkPList = null;
                custDmdPrcParentWorkList.TryGetValue(custDmdPrcWork.ClaimCode.ToString(), out custDmdPrcWorkPList);

                if (custDmdPrcWork.CustomerCode == custDmdPrcWork.ClaimCode)
                {
                    #region ■集計レコード集計処理

                    double FractionProcUnit = 0;
                    long SetTax = 0;
                    if (custDmdPrcWorkPList != null)
                    {
                        CustDmdPrcWork custDmdPrcWorkP = custDmdPrcWorkPList[0];
                        #region 集計レコードセット
                        custDmdPrcWork.FractionProcCd = custDmdPrcWorkP.FractionProcCd; //端数処理区分
                        FractionProcUnit = custDmdPrcWorkP.FractionProcUnit; // 端数処理単位
                        custDmdPrcWork.AddUpSecCode = custDmdPrcWork.AddUpSecCode;
                        custDmdPrcWork.ClaimCode = custDmdPrcWork.ClaimCode;
                        custDmdPrcWork.ClaimName = custDmdPrcWorkP.ClaimName;
                        custDmdPrcWork.ClaimName2 = custDmdPrcWorkP.ClaimName2;
                        custDmdPrcWork.ClaimSnm = custDmdPrcWorkP.ClaimSnm;
                        custDmdPrcWork.CollectCond = custDmdPrcWorkP.CollectCond;　　　　　　// 回収条件(得意先マスタ)
                        custDmdPrcWork.FractionProcCd = custDmdPrcWorkP.FractionProcCd;      // 端数処理区分(得意先マスタ)
                        custDmdPrcWork.ResultsSectCd = "00"; // 実績拠点コード(00固定)

                        // 今回繰越残高(請求計) = 前回請求残高 - 今回入金金額 
                        custDmdPrcWork.ThisTimeTtlBlcDmd = (custDmdPrcWork.LastTimeDemand + custDmdPrcWork.AcpOdrTtl2TmBfBlDmd + custDmdPrcWork.AcpOdrTtl3TmBfBlDmd) - custDmdPrcWork.ThisTimeDmdNrml;// 今回繰越残高(請求計)
                        // ■相殺
                        custDmdPrcWork.OfsThisTimeSales = custDmdPrcWorkP.OfsThisTimeSales;     // 相殺後今回売上金額
                        custDmdPrcWork.ItdedOffsetOutTax = custDmdPrcWorkP.ItdedOffsetOutTax;   // 相殺後外税対象額
                        custDmdPrcWork.ItdedOffsetInTax = custDmdPrcWorkP.ItdedOffsetInTax;     // 相殺後内税対象額
                        custDmdPrcWork.ItdedOffsetTaxFree = custDmdPrcWorkP.ItdedOffsetTaxFree; // 相殺後非課税対象額
                        custDmdPrcWork.OffsetInTax = custDmdPrcWorkP.OffsetInTax;               // 相殺後売上内税額

                        
                        #region 相殺後消費税金額の計算( OffsetOutTax )
                        // ①請求転嫁(親)相殺後消費税　売上＋返品＋値引
                        SetTax = 0;
                        FracCalc(custDmdPrcWorkP.Salesouttax_s + custDmdPrcWorkP.Retsalesouttax_s +
                            custDmdPrcWorkP.Dissaleouttax_s, FractionProcUnit, custDmdPrcWork.FractionProcCd, out SetTax);
                        
                        // ②伝票転嫁相殺後消費税 売上+返品+値引
                        SetTax += custDmdPrcWorkP.Salesouttax_d + custDmdPrcWorkP.Retsalesouttax_d +
                                 custDmdPrcWorkP.Dissaleouttax_d;

                        // ③明細転嫁相殺後消費税 売上+返品+値引
                        SetTax += custDmdPrcWorkP.Salesouttax_m + custDmdPrcWorkP.Retsalesouttax_m +
                                 custDmdPrcWorkP.Dissaleouttax_m;

                        // ④請求転嫁(子)相殺消費税 売上+返品+値引 ※親子レコード集計時に計算

                        custDmdPrcWork.OffsetOutTax = SetTax;
                        #endregion

                        // 相殺後今回売上消費税額 = 相殺後売上外税額 + 相殺後売上内税額
                        custDmdPrcWork.OfsThisSalesTax = custDmdPrcWork.OffsetOutTax + custDmdPrcWork.OffsetInTax;       // 相殺後今回売上消費税額

                        // ■売上
                        custDmdPrcWork.ThisTimeSales = custDmdPrcWorkP.ThisTimeSales;            // 今回売上金額 
                        custDmdPrcWork.ItdedSalesOutTax = custDmdPrcWorkP.ItdedSalesOutTax;      // 今回売上外税対象額
                        custDmdPrcWork.ItdedSalesInTax = custDmdPrcWorkP.ItdedSalesInTax;        // 今回売上内税対象額
                        custDmdPrcWork.ItdedSalesTaxFree = custDmdPrcWorkP.ItdedSalesTaxFree;    // 今回売上非課税対象額 
                        custDmdPrcWork.SalesInTax = custDmdPrcWorkP.SalesInTax;                  // 今回売上内税額
                        // 売上外税額 = 請求転嫁(親) + 伝票転嫁 + 明細転嫁 + 請求転嫁(子) ※請求転嫁(子)は親子レコード集計時に計算
                        SetTax = 0;
                        FracCalc(custDmdPrcWorkP.Salesouttax_s, FractionProcUnit, custDmdPrcWork.FractionProcCd, out SetTax);
                        
                        SetTax += custDmdPrcWorkP.Salesouttax_d + custDmdPrcWorkP.Salesouttax_m;
                        custDmdPrcWork.SalesOutTax = SetTax;// 今回売上外税額
                        custDmdPrcWork.ThisSalesTax = custDmdPrcWork.SalesOutTax + custDmdPrcWork.SalesInTax; // 今回売上消費税額

                        // ■返品
                        custDmdPrcWork.ThisSalesPricRgds = custDmdPrcWorkP.ThisSalesPricRgds;    // 今回売上返品金額
                        custDmdPrcWork.TtlItdedRetOutTax = custDmdPrcWorkP.TtlItdedRetOutTax;    // 今回売上返品外税対象額
                        custDmdPrcWork.TtlItdedRetInTax = custDmdPrcWorkP.TtlItdedRetInTax;      // 今回売上返品内税対象額
                        custDmdPrcWork.TtlItdedRetTaxFree = custDmdPrcWorkP.TtlItdedRetTaxFree;  // 今回売上返品非課税対象額
                        custDmdPrcWork.TtlRetInnerTax = custDmdPrcWorkP.TtlRetInnerTax;          // 今回売上返品内税額
                        // 今回返品外税額 = 請求転嫁(親) + 伝票転嫁 + 明細転嫁 + 請求転嫁(子) ※請求転嫁(子)は親子レコード集計時に計算
                        FracCalc(custDmdPrcWorkP.Retsalesouttax_s, FractionProcUnit, custDmdPrcWork.FractionProcCd, out SetTax);
                        
                        SetTax += custDmdPrcWorkP.Retsalesouttax_d + custDmdPrcWorkP.Retsalesouttax_m;
                        custDmdPrcWork.TtlRetOuterTax = SetTax;// 今回売上返品外税額
                        custDmdPrcWork.ThisSalesPrcTaxRgds = custDmdPrcWork.TtlRetOuterTax + custDmdPrcWork.TtlRetInnerTax;// 今回売上返品消費税額

                        // ■値引
                        custDmdPrcWork.ThisSalesPricDis = custDmdPrcWorkP.ThisSalesPricDis;      // 今回売上値引金額
                        custDmdPrcWork.TtlItdedDisOutTax = custDmdPrcWorkP.TtlItdedDisOutTax;    // 今回売上値引外税対象金額
                        custDmdPrcWork.TtlItdedDisInTax = custDmdPrcWorkP.TtlItdedDisInTax;      // 今回売上値引内税対象金額
                        custDmdPrcWork.TtlItdedDisTaxFree = custDmdPrcWorkP.TtlItdedDisTaxFree;  // 今回売上値引非課税対象金額
                        custDmdPrcWork.TtlDisInnerTax = custDmdPrcWorkP.TtlDisInnerTax;          // 今回売上値引内税額
                        // 今回値引外税額 = 請求(親) + 伝票転嫁 + 明細転嫁 + 請求転嫁(子) ※請求転嫁(子)は親子レコード集計時に計算
                        FracCalc(custDmdPrcWorkP.Dissaleouttax_s, FractionProcUnit, custDmdPrcWork.FractionProcCd, out SetTax);
                        
                        SetTax += custDmdPrcWorkP.Dissaleouttax_d + custDmdPrcWorkP.Dissaleouttax_m;
                        custDmdPrcWork.TtlDisOuterTax = SetTax;// 今回売上値引外税額
                        custDmdPrcWork.ThisSalesPrcTaxDis = custDmdPrcWork.TtlDisOuterTax + custDmdPrcWork.TtlDisInnerTax;  // 今回売上値引消費税額

                        custDmdPrcWork.TaxAdjust = 0;     // 消費税調整額 (0固定)
                        custDmdPrcWork.BalanceAdjust = 0; // 残高調整額　 (0固定)

                        // 計算後請求金額 = 今回繰越残高 + (相殺後今回売上金額 + 相殺後今回売上消費税) ※親子レコード集計時に請求転嫁(子)の消費税加算
                        custDmdPrcWork.AfCalDemandPrice = custDmdPrcWork.ThisTimeTtlBlcDmd + (custDmdPrcWork.OfsThisTimeSales + custDmdPrcWork.OfsThisSalesTax);
                        custDmdPrcWork.SalesSlipCount = custDmdPrcWorkP.SalesSlipCount; // 売上伝票枚数
                        custDmdPrcWork.BillPrintDate = DateTime.Now;  // 請求書発行日(システム日付)
                        // 入金予定日計算 >>>
                        // 集金月区分によってセット内容変動
                        DateTime collectmoneyDate = custDmdPrcWork.AddUpDate;
                        if (collectmoneyDate.Year != 9999)
                        {
                            switch (custDmdPrcWorkP.Collectmoneycode) // 0:当月,1:翌月,2:翌々月,3翌々々月
                            {
                                case 1:
                                    collectmoneyDate = collectmoneyDate.AddMonths(1);
                                    break;
                                case 2:
                                    collectmoneyDate = collectmoneyDate.AddMonths(2);
                                    break;
                                case 3:
                                    collectmoneyDate = collectmoneyDate.AddMonths(3);
                                    break;
                            }
                            // 28日以降は末日とする
                            if (custDmdPrcWorkP.Collectmoneyday >= 28)
                            {
                                collectmoneyDate = new DateTime(collectmoneyDate.Year, collectmoneyDate.Month, 1);
                                collectmoneyDate = collectmoneyDate.AddMonths(1);
                                collectmoneyDate = collectmoneyDate.AddDays(-1);
                            }
                            else
                            {
                                collectmoneyDate = new DateTime(collectmoneyDate.Year, collectmoneyDate.Month, custDmdPrcWorkP.Collectmoneyday);
                            }
                        }
                        custDmdPrcWork.ExpectedDepositDate = collectmoneyDate;　// 入金予定日
                        // 入金予定日計算 <<<



                        #endregion
                    }

                    #endregion
                }
                // 初期化
                long OffsetOutTax = 0;      // 外税額
                long SalesOutTax = 0;       // 売上外税額
                long RetSalesOutTax = 0;    // 返品外税額
                long DisSalesOutTax = 0;    // 返品外税額

                int ChildCnt = 0;
                double fractionProcUnit = 0;
                long setTax = 0;

                #region ■親・子レコード集計処理

                if (custDmdPrcChildrenWorkList != null)
                {
                    List<CustDmdPrcWork> custDmdPrcWorkCList = null;
                    custDmdPrcChildrenWorkList.TryGetValue(custDmdPrcWork.ClaimCode.ToString(), out custDmdPrcWorkCList);

                    if (custDmdPrcWorkCList != null)
                    {

                        foreach (CustDmdPrcWork custDmdPrcWorkDB in custDmdPrcWorkCList)
                        {
                            CustDmdPrcWork custDmdPrcChildWork = new CustDmdPrcWork();
                            #region 親・子レコードセット

                            custDmdPrcChildWork.FractionProcCd = custDmdPrcWorkDB.FractionProcCd; //端数処理区分
                            fractionProcUnit = custDmdPrcWorkDB.FractionProcUnit; // 端数処理単位

                            custDmdPrcChildWork.AddUpSecCode = custDmdPrcWork.AddUpSecCode;
                            custDmdPrcChildWork.ClaimCode = custDmdPrcWork.ClaimCode;
                            custDmdPrcChildWork.ClaimName = custDmdPrcWorkDB.ClaimName;
                            custDmdPrcChildWork.ClaimName2 = custDmdPrcWorkDB.ClaimName2;
                            custDmdPrcChildWork.ClaimSnm = custDmdPrcWorkDB.ClaimSnm;
                            custDmdPrcChildWork.CollectCond = custDmdPrcWorkDB.CollectCond;　　　　　　// 回収条件(得意先マスタ)
                            custDmdPrcChildWork.ConsTaxLayMethod = custDmdPrcWorkDB.ConsTaxLayMethod;　// 消費税転嫁方式(得意先マスタ) // ADD 2010/12/20
                            custDmdPrcChildWork.ConsTaxRate = custDmdPrcWork.ConsTaxRate;                                                             // 税率(セット済　※得意先マスタ)
                            custDmdPrcChildWork.FractionProcCd = custDmdPrcWorkDB.FractionProcCd;      // 端数処理区分(得意先マスタ)
                            custDmdPrcChildWork.ResultsSectCd = custDmdPrcWorkDB.ResultsSectCd;       // 実績拠点コード

                            custDmdPrcChildWork.CustomerCode = custDmdPrcWorkDB.CustomerCode;
                            custDmdPrcChildWork.CustomerName = custDmdPrcWorkDB.CustomerName;
                            custDmdPrcChildWork.CustomerName2 = custDmdPrcWorkDB.CustomerName2;
                            custDmdPrcChildWork.CustomerSnm = custDmdPrcWorkDB.CustomerSnm;

                            custDmdPrcChildWork.AddUpDate = custDmdPrcWork.AddUpDate;           // 計上年月日(画面設定値)
                            custDmdPrcChildWork.AddUpYearMonth = custDmdPrcWork.AddUpYearMonth; // 計上年月(画面設定値の年月)

                            // 親・子レコードは未セット項目(※集計レコードのみセットする) >>>
                            custDmdPrcChildWork.LastTimeDemand = 0;         // 前回請求金額(0固定)
                            custDmdPrcChildWork.ThisTimeFeeDmdNrml = 0;     // 今回手数料金額(0固定)
                            custDmdPrcChildWork.ThisTimeDisDmdNrml = 0;     // 今回値引金額(0固定)
                            custDmdPrcChildWork.ThisTimeDmdNrml = 0;        // 今回入金金額(0固定)                        
                            custDmdPrcChildWork.ThisTimeTtlBlcDmd = 0;      // 今回繰越残高(0固定)
                            // 親・子レコードは未セット項目(※集計レコードのみセットする) <<<

                            // ■相殺
                            custDmdPrcChildWork.OfsThisTimeSales = custDmdPrcWorkDB.OfsThisTimeSales;     // 相殺後今回売上金額
                            custDmdPrcChildWork.ItdedOffsetOutTax = custDmdPrcWorkDB.ItdedOffsetOutTax;   // 相殺後外税対象額
                            custDmdPrcChildWork.ItdedOffsetInTax = custDmdPrcWorkDB.ItdedOffsetInTax;     // 相殺後内税対象額
                            custDmdPrcChildWork.ItdedOffsetTaxFree = custDmdPrcWorkDB.ItdedOffsetTaxFree; // 相殺後非課税対象額
                            custDmdPrcChildWork.OffsetInTax = custDmdPrcWorkDB.OffsetInTax;               // 相殺後売上内税額
                            // 相殺後売上外税額 = 今回売上外税額( 請求親転嫁+請求子転嫁+伝票転嫁+明細転嫁 ) + 今回売上返品外税額( 請求親転嫁+請求子転嫁+伝票転嫁+明細転嫁 ) + 今回売上値引外税額( 請求親転嫁+請求子転嫁+伝票転嫁+明細転嫁 )

                            // ①請求転嫁子の相殺後消費税算出
                            FracCalc(custDmdPrcWorkDB.Salesouttax_s + custDmdPrcWorkDB.Retsalesouttax_s +
                                custDmdPrcWorkDB.Dissalesouttax_s, fractionProcUnit, custDmdPrcChildWork.FractionProcCd, out setTax);
                            OffsetOutTax += setTax; // 集計レコード計算用に退避

                            custDmdPrcChildWork.OffsetOutTax = setTax;

                            // ②請求転嫁親の相殺消費税算出
                            FracCalc(custDmdPrcWorkDB.Salesouttax_s2 + custDmdPrcWorkDB.Retsalesouttax_s2 +
                                custDmdPrcWorkDB.Dissalesouttax_s2, fractionProcUnit, custDmdPrcChildWork.FractionProcCd, out setTax);
                            custDmdPrcChildWork.OffsetOutTax += setTax;

                            // ③伝票転嫁の相殺消費税算出
                            custDmdPrcChildWork.OffsetOutTax += custDmdPrcWorkDB.Salesouttax_d + custDmdPrcWorkDB.Retsalesouttax_d +
                                                                custDmdPrcWorkDB.Dissalesouttax_d;

                            // ④明細転嫁の相殺消費税算出
                            custDmdPrcChildWork.OffsetOutTax += custDmdPrcWorkDB.Salesouttax_m + custDmdPrcWorkDB.Retsalesouttax_m +
                                                                custDmdPrcWorkDB.Dissalesouttax_m;

                            // 相殺後今回売上消費税額 = 相殺後売上外税額 + 相殺後売上内税額
                            custDmdPrcChildWork.OfsThisSalesTax = custDmdPrcChildWork.OffsetOutTax + custDmdPrcChildWork.OffsetInTax;      // 相殺後今回売上消費税額

                            //相殺後売上外税額 <<<

                            // ■売上
                            custDmdPrcChildWork.ThisTimeSales = custDmdPrcWorkDB.ThisTimeSales;            // 今回売上金額 
                            custDmdPrcChildWork.ItdedSalesOutTax = custDmdPrcWorkDB.ItdedSalesOutTax;      // 今回売上外税対象額
                            custDmdPrcChildWork.ItdedSalesInTax = custDmdPrcWorkDB.ItdedSalesInTax;        // 今回売上内税対象額
                            custDmdPrcChildWork.ItdedSalesTaxFree = custDmdPrcWorkDB.ItdedSalesTaxFree;    // 今回売上非課税対象額 
                            custDmdPrcChildWork.SalesInTax = custDmdPrcWorkDB.SalesInTax;                  // 今回売上内税額
                            // 今回売上外税額 = 請求転嫁(子) + 請求転嫁(親) + 伝票転嫁 + 明細転嫁
                            // 請求転嫁(子)
                            FracCalc(custDmdPrcWorkDB.Salesouttax_s, fractionProcUnit, custDmdPrcChildWork.FractionProcCd, out setTax);
                            custDmdPrcChildWork.SalesOutTax = setTax;
                            SalesOutTax += setTax;

                            // 請求転嫁(親)
                            FracCalc(custDmdPrcWorkDB.Salesouttax_s2, fractionProcUnit, custDmdPrcChildWork.FractionProcCd, out setTax);
                            custDmdPrcChildWork.SalesOutTax += setTax;
                            
                            // 伝票転嫁 + 明細転嫁
                            custDmdPrcChildWork.SalesOutTax += custDmdPrcWorkDB.Salesouttax_d + custDmdPrcWorkDB.Salesouttax_m;
                            custDmdPrcChildWork.ThisSalesTax = custDmdPrcChildWork.SalesOutTax + custDmdPrcChildWork.SalesInTax; // 今回消費税金額

                            // ■返品
                            custDmdPrcChildWork.ThisSalesPricRgds = custDmdPrcWorkDB.ThisSalesPricRgds;  // 今回売上返品金額
                            custDmdPrcChildWork.TtlItdedRetOutTax = custDmdPrcWorkDB.TtlItdedRetOutTax;  // 今回売上返品外税対象額
                            custDmdPrcChildWork.TtlItdedRetInTax = custDmdPrcWorkDB.TtlItdedRetInTax;    // 今回売上返品内税対象額
                            custDmdPrcChildWork.TtlItdedRetTaxFree = custDmdPrcWorkDB.TtlItdedRetTaxFree;// 今回売上返品非課税対象額
                            custDmdPrcChildWork.TtlRetInnerTax = custDmdPrcWorkDB.TtlRetInnerTax;        // 今回売上返品内税額
                            // 今回売上返品外税額 = 請求転嫁(子) + 請求転嫁(親) + 伝票転嫁 + 明細転嫁
                            // 請求転嫁(子)
                            FracCalc(custDmdPrcWorkDB.Retsalesouttax_s, fractionProcUnit, custDmdPrcChildWork.FractionProcCd, out setTax);
                            custDmdPrcChildWork.TtlRetOuterTax = setTax;
                            RetSalesOutTax += setTax;

                            // 請求転嫁(親)
                            FracCalc(custDmdPrcWorkDB.Retsalesouttax_s2, fractionProcUnit, custDmdPrcChildWork.FractionProcCd, out setTax);
                            custDmdPrcChildWork.TtlRetOuterTax += setTax;
                            
                            // 伝票転嫁 + 明細転嫁
                            custDmdPrcChildWork.TtlRetOuterTax += custDmdPrcWorkDB.Retsalesouttax_d + custDmdPrcWorkDB.Retsalesouttax_m;

                            // 今回返品消費税額
                            custDmdPrcChildWork.ThisSalesPrcTaxRgds = custDmdPrcChildWork.TtlRetOuterTax + custDmdPrcChildWork.TtlRetInnerTax;

                            // ■値引
                            custDmdPrcChildWork.ThisSalesPricDis = custDmdPrcWorkDB.ThisSalesPricDis;      // 今回売上値引金額
                            custDmdPrcChildWork.TtlItdedDisOutTax = custDmdPrcWorkDB.TtlItdedDisOutTax;    // 今回売上値引外税対象金額
                            custDmdPrcChildWork.TtlItdedDisInTax = custDmdPrcWorkDB.TtlItdedDisInTax;      // 今回売上値引内税対象金額
                            custDmdPrcChildWork.TtlItdedDisTaxFree = custDmdPrcWorkDB.TtlItdedDisTaxFree;  // 今回売上値引非課税対象金額
                            custDmdPrcChildWork.TtlDisInnerTax = custDmdPrcWorkDB.TtlDisInnerTax;          // 今回売上値引内税額
                            // 今回売上値引外税額 = 請求転嫁(子) + 請求転嫁(親) + 伝票転嫁 + 明細転嫁
                            // 請求転嫁(子)
                            FracCalc(custDmdPrcWorkDB.Dissalesouttax_s, fractionProcUnit, custDmdPrcChildWork.FractionProcCd, out setTax);
                            custDmdPrcChildWork.TtlDisOuterTax = setTax;
                            DisSalesOutTax += setTax;

                            // 請求転嫁(親)
                            FracCalc(custDmdPrcWorkDB.Dissalesouttax_s2, fractionProcUnit, custDmdPrcChildWork.FractionProcCd, out setTax);
                            custDmdPrcChildWork.TtlDisOuterTax += setTax;
                            
                            // 伝票転嫁 + 明細転嫁
                            custDmdPrcChildWork.TtlDisOuterTax += custDmdPrcWorkDB.Dissalesouttax_d + custDmdPrcWorkDB.Dissalesouttax_m;
                            // 今回売上値引消費税額
                            custDmdPrcChildWork.ThisSalesPrcTaxDis = custDmdPrcChildWork.TtlDisOuterTax + custDmdPrcChildWork.TtlDisInnerTax;

                            custDmdPrcChildWork.TaxAdjust = 0;           // 消費税調整額  (0固定)
                            custDmdPrcChildWork.BalanceAdjust = 0;       // 残高調整額　  (0固定)
                            custDmdPrcChildWork.AfCalDemandPrice = 0;    // 計算後請求金額(0固定)
                            custDmdPrcChildWork.AcpOdrTtl2TmBfBlDmd = 0; // 受注2回前残高(請求計) (0固定)
                            custDmdPrcChildWork.AcpOdrTtl3TmBfBlDmd = 0; // 受注3回前残高(請求計) (0固定)

                            custDmdPrcChildWork.CAddUpUpdExecDate = custDmdPrcWork.CAddUpUpdExecDate;   // 締次更新実行年月日(セット済み ※前回履歴から)
                            custDmdPrcChildWork.StartCAddUpUpdDate = custDmdPrcWork.StartCAddUpUpdDate; // 締次更新開始年月日(セット済み ※前回履歴から) 
                            custDmdPrcChildWork.LastCAddUpUpdDate = custDmdPrcWork.LastCAddUpUpdDate;   // 前回締次更新年月日(セット済み ※前回履歴から)

                            custDmdPrcChildWork.SalesSlipCount = custDmdPrcWorkDB.SalesSlipCount; // 売上伝票枚数
                            custDmdPrcChildWork.BillPrintDate = DateTime.Now;  // 請求書発行日(システム日付)

                            // 入金予定日計算 >>>
                            // 集金月区分によってセット内容変動( クエリ内で処理しきれない為、セット時に計算 )
                            DateTime collectmoneyDate = custDmdPrcChildWork.AddUpDate;
                            if (collectmoneyDate.Year != 9999)
                            {
                                switch (custDmdPrcWorkDB.Collectmoneycode) // 0:当月,1:翌月,2:翌々月,3翌々々月
                                {
                                    case 1:
                                        collectmoneyDate = collectmoneyDate.AddMonths(1);
                                        break;
                                    case 2:
                                        collectmoneyDate = collectmoneyDate.AddMonths(2);
                                        break;
                                    case 3:
                                        collectmoneyDate = collectmoneyDate.AddMonths(3);
                                        break;
                                }
                                // 28日以降は末日とする
                                if (custDmdPrcWorkDB.Collectmoneyday >= 28)
                                {
                                    collectmoneyDate = new DateTime(collectmoneyDate.Year, collectmoneyDate.Month, 1);
                                    collectmoneyDate = collectmoneyDate.AddMonths(1);
                                    collectmoneyDate = collectmoneyDate.AddDays(-1);
                                }
                                else
                                {
                                    collectmoneyDate = new DateTime(collectmoneyDate.Year, collectmoneyDate.Month, custDmdPrcWorkDB.Collectmoneyday);
                                }
                            }
                            custDmdPrcChildWork.ExpectedDepositDate = collectmoneyDate;　// 入金予定日
                            // 入金予定日計算 <<<
                            #endregion

                            custDmdPrcChildWorkList.Add(custDmdPrcChildWork);
                            ChildCnt += 1;
                        }
                    }
                }
                #endregion

                #region ■■ 集計レコード計算用の処理 ■■
                if (ChildCnt != 0)
                {
                    
                    //今回売上外税
                    custDmdPrcWork.SalesOutTax += SalesOutTax;
                    //今回売上消費税
                    custDmdPrcWork.ThisSalesTax = custDmdPrcWork.SalesOutTax + custDmdPrcWork.SalesInTax;

                    //今回返品外税
                    custDmdPrcWork.TtlRetOuterTax += RetSalesOutTax;
                    //今回返品消費税
                    custDmdPrcWork.ThisSalesPrcTaxRgds = custDmdPrcWork.TtlRetOuterTax + custDmdPrcWork.TtlRetInnerTax;

                    //今回値引外税
                    custDmdPrcWork.TtlDisOuterTax += DisSalesOutTax;
                    //今回値引消費税
                    custDmdPrcWork.ThisSalesPrcTaxDis = custDmdPrcWork.TtlDisOuterTax + custDmdPrcWork.TtlDisInnerTax;

                    // 相殺後外税消費税 = 子レコード集計(相殺後外税金額)
                    custDmdPrcWork.OffsetOutTax += OffsetOutTax;

                    //相殺後今回売上消費税 = 相殺後外税消費税 + 相殺後内税消費税
                    custDmdPrcWork.OfsThisSalesTax = custDmdPrcWork.OffsetOutTax + custDmdPrcWork.OffsetInTax;

                    // 計算後請求金額 = 今回繰越残高 + (相殺後今回売上金額 + 相殺後今回売上消費税)
                    custDmdPrcWork.AfCalDemandPrice = custDmdPrcWork.ThisTimeTtlBlcDmd + (custDmdPrcWork.OfsThisTimeSales + custDmdPrcWork.OfsThisSalesTax);

                }
                #endregion

                #region ■■ 実績無しの場合の処理 ■■
                // 実績無しの場合でも、親レコードは作成する。
                if (ChildCnt == 0)
                {
                    // ■親レコード( 不足項目セット )
                    // 実績拠点コード
                    custDmdPrcWork.ResultsSectCd = custDmdPrcWork.AddUpSecCode;

                    custDmdPrcChildWorkList.Add(custDmdPrcWork);

                    // ■集計レコード( 不足項目セット )
                    // 今回繰越残高
                    custDmdPrcWork.ThisTimeTtlBlcDmd = (custDmdPrcWork.LastTimeDemand + custDmdPrcWork.AcpOdrTtl2TmBfBlDmd + custDmdPrcWork.AcpOdrTtl3TmBfBlDmd) - custDmdPrcWork.ThisTimeDmdNrml;
                    // 計算後請求金額
                    custDmdPrcWork.AfCalDemandPrice = custDmdPrcWork.ThisTimeTtlBlcDmd + (custDmdPrcWork.OfsThisTimeSales + custDmdPrcWork.OfsThisSalesTax);

                }
                #endregion
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }

            return status;
        }
        #endregion

        #region [入金明細データ]
        /// <summary>
        /// 得意先請求金額ワーク用Listから入金明細データを取得します
        /// </summary>
        /// <param name="custDmdPrcWork">得意先請求金額マスタ更新List</param>
        /// <param name="dmdDepoTotalWorkList">請求入金集計データ更新List</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額ワーク用Listから入金明細データを取得します</br>
        /// <br>Programmer : 2013/08/08 汪権来</br>
        /// <br>管理番号   ：10902175-00 2013/06/18配信分</br>
        /// <br>             Redmine#35552 「売上締次更新」の処理速度遅延の調査と対応(№1921)</br>
        /// </remarks>
        private int GetDepsitDtlMainForCustDmd(ref CustDmdPrcWork custDmdPrcWork, ref ArrayList dmdDepoTotalWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            List<DmdDepoTotalWork> dmdDepoTotalList = new List<DmdDepoTotalWork>();   // データ格納用

            SqlDataReader myReader = null;

            string sqlText = string.Empty;

            //入金明細データ

            sqlText += "SELECT" + Environment.NewLine;
            sqlText += "DEP.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "DEP.CLAIMCODERF," + Environment.NewLine;
            sqlText += "DEP.MONEYKINDCODERF ," + Environment.NewLine;
            sqlText += "DEP.DEPOSITRF," + Environment.NewLine;
            sqlText += "(CASE WHEN MONEYKIND.MONEYKINDNAMERF IS NOT NULL THEN MONEYKIND.MONEYKINDNAMERF ELSE '未登録' END) AS MONEYKINDNAMERF," + Environment.NewLine;
            sqlText += "(CASE WHEN MONEYKIND.MONEYKINDDIVRF IS NOT NULL THEN MONEYKIND.MONEYKINDDIVRF ELSE 0 END) AS MONEYKINDDIVRF" + Environment.NewLine;
            sqlText += "FROM" + Environment.NewLine;
            sqlText += "(" + Environment.NewLine;
            sqlText += "  SELECT" + Environment.NewLine;
            sqlText += "  DEPSMD.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "  DEPSMD.CLAIMCODERF," + Environment.NewLine;
            sqlText += "  DEPSMD.MONEYKINDCODERF ," + Environment.NewLine;
            sqlText += "  SUM(CASE WHEN DEPSMD.DEPOSITDEBITNOTECDRF = 1 THEN DEPSMD.DEPOSITRF *-1  ELSE DEPSMD.DEPOSITRF END) AS DEPOSITRF" + Environment.NewLine;
            sqlText += "  FROM ( " + Environment.NewLine;
            sqlText += "    SELECT" + Environment.NewLine;
            sqlText += "    DEPS.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "    DEPS.CLAIMCODERF," + Environment.NewLine;
            sqlText += "    DEPS.DEPOSITDEBITNOTECDRF," + Environment.NewLine;
            sqlText += "    DEPDTL.MONEYKINDCODERF ," + Environment.NewLine;
            sqlText += "    DEPDTL.DEPOSITRF " + Environment.NewLine;
            sqlText += "    FROM DEPSITMAINRF AS DEPS WITH(READUNCOMMITTED) " + Environment.NewLine;
            sqlText += "    INNER JOIN DEPSITDTLRF AS DEPDTL WITH(READUNCOMMITTED) " + Environment.NewLine;
            sqlText += "      ON (DEPDTL.ENTERPRISECODERF= DEPS.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "         AND DEPDTL.ACPTANODRSTATUSRF= DEPS.ACPTANODRSTATUSRF" + Environment.NewLine;
            sqlText += "         AND DEPS.DEPOSITSLIPNORF = DEPDTL.DEPOSITSLIPNORF)" + Environment.NewLine;
            sqlText += "    WHERE DEPS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "      AND DEPS.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
            sqlText += "      AND (DEPS.ADDUPADATERF<=@FINDADDUPDATE AND DEPS.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
            sqlText += "      AND DEPS.LOGICALDELETECODERF = 0" + Environment.NewLine;
            sqlText += "      AND DEPS.DEPOSITDEBITNOTECDRF != 1" + Environment.NewLine;
            sqlText += "    UNION ALL" + Environment.NewLine;
            sqlText += "    SELECT" + Environment.NewLine;
            sqlText += "    DEPS.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "    DEPS.CLAIMCODERF," + Environment.NewLine;
            sqlText += "    DEPS.DEPOSITDEBITNOTECDRF," + Environment.NewLine;
            sqlText += "    DEPDTL.MONEYKINDCODERF ," + Environment.NewLine;
            sqlText += "    DEPDTL.DEPOSITRF " + Environment.NewLine;
            sqlText += "    FROM DEPSITMAINRF AS DEPS WITH(READUNCOMMITTED) " + Environment.NewLine;
            sqlText += "    INNER JOIN DEPSITDTLRF AS DEPDTL WITH(READUNCOMMITTED) " + Environment.NewLine;
            sqlText += "     ON (DEPDTL.ENTERPRISECODERF= DEPS.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "         AND DEPDTL.ACPTANODRSTATUSRF= DEPS.ACPTANODRSTATUSRF" + Environment.NewLine;
            sqlText += "         AND DEPS.DEBITNOTELINKDEPONORF = DEPDTL.DEPOSITSLIPNORF)" + Environment.NewLine;
            sqlText += "    WHERE DEPS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "      AND DEPS.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
            sqlText += "      AND (DEPS.ADDUPADATERF<=@FINDADDUPDATE AND DEPS.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
            sqlText += "      AND DEPS.LOGICALDELETECODERF = 0" + Environment.NewLine;
            sqlText += "      AND DEPS.DEPOSITDEBITNOTECDRF = 1" + Environment.NewLine;
            sqlText += "  ) AS DEPSMD" + Environment.NewLine;
            sqlText += "  GROUP BY" + Environment.NewLine;
            sqlText += "    DEPSMD.ENTERPRISECODERF," + Environment.NewLine;
            sqlText += "    DEPSMD.CLAIMCODERF," + Environment.NewLine;
            sqlText += "    DEPSMD.MONEYKINDCODERF" + Environment.NewLine;

            sqlText += ") AS DEP" + Environment.NewLine;
            sqlText += "LEFT JOIN MONEYKINDURF AS MONEYKIND WITH(READUNCOMMITTED) " + Environment.NewLine;
            sqlText += "ON DEP.ENTERPRISECODERF = MONEYKIND.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "AND DEP.MONEYKINDCODERF = MONEYKIND.MONEYKINDCODERF" + Environment.NewLine;


            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    sqlCommand.CommandTimeout = _timeOut;
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custDmdPrcWork.EnterpriseCode);
                    findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(custDmdPrcWork.CustomerCode); // 得意先コード
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.AddUpDate);

                    if (custDmdPrcWork.LastCAddUpUpdDate != DateTime.MinValue)
                    {
                        findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.LastCAddUpUpdDate);
                    }
                    else if (custDmdPrcWork.ExtractStartDate != DateTime.MinValue)
                    {
                        findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custDmdPrcWork.ExtractStartDate.AddDays(-1));
                    }
                    else
                    {
                        findParaLastTimeAddUpDate.Value = 20000101;
                    }

                    DmdDepoTotalWork dmdDepoTotalWork = new DmdDepoTotalWork();

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        //請求入金集計にセット
                        dmdDepoTotalWork = CopyToDmdDepoTotalWorkFromReader(ref myReader);
                        if (dmdDepoTotalWork.Deposit == 0)
                        {
                            continue;
                        }
                        dmdDepoTotalWork.EnterpriseCode = custDmdPrcWork.EnterpriseCode; // 企業コード 
                        dmdDepoTotalWork.AddUpDate = custDmdPrcWork.AddUpDate;       // 計上年月日(画面設定値)
                        dmdDepoTotalWork.AddUpSecCode = custDmdPrcWork.AddUpSecCode; // 請求拠点(得意先マスタ)
                        dmdDepoTotalWork.ClaimCode = custDmdPrcWork.ClaimCode; 　　　// 請求得意先(得意先マスタ)
                        dmdDepoTotalWork.CustomerCode = custDmdPrcWork.ClaimCode;

                        dmdDepoTotalWorkList.Add(dmdDepoTotalWork);
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
        #endregion
        //----- ADD 2013/08/08 汪権来 Redmine#35552 速度改善 -------------------<<<<<
    }
}
