//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE発注用I/OWriteDBリモートオブジェクト
//                  :   PMUOE01006R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112　久保田
// Date             :   2008.09.22
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
// 管理番号              作成担当 : xuxh
// 修 正 日  2009/12/29  修正内容 :【要件No.2】																																							
//	                                発注先にトヨタを指定時には、リマーク２の入力は不可とする
//                                 （連携時、ﾘﾏｰｸ2に連携番号として使用する為）																																							
//	                                仕入明細（発注データ）の作成を行い通信は行わない様にする																																							
//                       修正内容 :【要件No.3】
//                                  発注先の入力制御（トヨタは入力不可とする）を行う
//                                  トヨタ電子カタログで使用する送信・受信データの保存場所を設定する
//----------------------------------------------------------------------------
// 管理番号  10601190-00 作成担当 : 楊明俊
// 修 正 日  2010/03/08  修正内容 : PM1006 ＵＯＥ発注番号・ＵＯＥ発注行番号の設定の対応
//----------------------------------------------------------------------------
// 管理番号  10601191-00 作成担当 : gaoyh
// 作 成 日  2010/04/26  修正内容 : PM1007C 三菱UOE-WEB対応に伴う仕様追加
//----------------------------------------------------------------------------
// 管理番号  10601190-00 作成担当 : 高峰
// 修 正 日  2010/05/07  修正内容 : PM1008 明治UOE-WEB対応に伴う仕様追加
//----------------------------------------------------------------------------
// 管理番号  10607734-00 作成担当 : liyp
// 修 正 日  2011/01/06  修正内容 : ＜IOWriteControlDB＞の機能追加
//----------------------------------------------------------------------------
// 管理番号  10607734-00 作成担当 : 朱 猛
// 修 正 日  2011/01/30  修正内容 : UOE自動化改良 
//----------------------------------------------------------------------------
// 管理番号  10607734-01 作成担当 : liyp
// 修 正 日  2011/03/01  修正内容 : 日産UOE自動化B対応
//----------------------------------------------------------------------------
// 管理番号  10702591-00 作成担当 : 施炳中
// 修 正 日  2011/05/10  修正内容 : ＜IOWriteControlDB＞の機能追加
//----------------------------------------------------------------------------
// 管理番号              作成担当 : 凌小青
// 修 正 日  2011/10/28  修正内容 :障害報告 #26283と障害報告 #26284の対応
//----------------------------------------------------------------------------
// 管理番号  10702591-00 作成担当 : LIUSY
// 修 正 日  2011/11/26  修正内容 : PM1113 卸NET-WEB対応に伴う仕様追加
//----------------------------------------------------------------------------
// 管理番号  10900690-00 作成担当 : wangyl
// 修 正 日  2013/02/06  修正内容 : 10900690-00 2013/03/13配信分の緊急対応
//                                  Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい 
//----------------------------------------------------------------------------
// 管理番号  10900690-00 作成担当 : wangyl
// 修 正 日  2013/02/26  修正内容 : 10900690-00 2013/03/13配信分の緊急対応
//                                  Redmine#34578の対応 発注一覧表から在庫一括発注後、送信処理画面で品番が降順になっている 
//----------------------------------------------------------------------------
// 管理番号  10801804-00 作成担当 : pengjie
// 作 成 日  2013/03/14  修正内容 : redmine#34986の対応 発注一覧表とUOE発送処理のサーバ端で、操作履歴ログ追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangl2
// 修 正 日  2013/04/03  修正内容 : Redmine#35210の対応 「UOE手入力発注」で連番が全て "1" でエラーになる（№1802） 
//----------------------------------------------------------------------------
// 管理番号  10801804-00 作成担当 : zhangll
// 修 正 日  2013/05/10  修正内容 : Redmine#34986の対応 操作履歴ログ内容修正
//----------------------------------------------------------------------------
// 管理番号  10801804-00 作成担当 : wuyk
// 修 正 日  2013/08/19  修正内容 : Redmine#39934の対応・UOE／仕入受信を行った際のオンライン番号不正の件について修正
//----------------------------------------------------------------------------
// 管理番号  10801804-00 作成担当 : 譚洪
// 修 正 日  2013/11/18  修正内容 : Redmine#41206の対応・回答番号が採番の修正
//----------------------------------------------------------------------------
// 管理番号  11000192-00 作成担当 : 鄧潘ハン
// 修 正 日  2014/11/19  修正内容 : 仕掛一覧：№2565 Redmine#43752の対応・明治UOEWEBの卸商仕入受信処理の場合、メモリ違反の調査の対応
//----------------------------------------------------------------------------
// 管理番号  11900025-00  作成担当 : 田村顕成
// 作 成 日  2023/01/20   修正内容 : PMKOBETSU-4202 卸商仕入受信処理障害対応
//----------------------------------------------------------------------------//
// 管理番号  12100013-00  作成担当 : 陳艶丹
// 作 成 日  2025/01/10   修正内容 : PMKOBETSU-4369 山形部品㈱_卸商仕入受信処理不具合対応
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// UOE発注用I/OWriteDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE発注用I/OWriteの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21112　久保田</br>
    /// <br>Date       : 2008.09.22</br>
    /// <br></br>
    /// <br>Update Note: 22008 長内 e-Parts対応</br>
    /// <br>Date       : 2009.05.25</br>
    /// <br></br>
    /// <br>Update Note: 2009/12/29 xuxh</br>
    /// <br>             ・【要件No.2】と【要件No.3】の修正</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/03/08 楊明俊　PM1006</br>
    /// <br>             ＵＯＥ発注番号・ＵＯＥ発注行番号の設定の対応</br>
    /// <br>UpdateNote : 2010/05/07 高峰　PM1008</br>
    /// <br>             明治UOE-WEB対応に伴う仕様追加</br>
    /// <br>UpdateNote  : 2011/03/01 liyp </br>
    /// <br>             日産UOE自動化B対応</br>
    /// <br>UpdateNote  : 2011/05/10 施炳中</br>
    /// <br>             ＜IOWriteControlDB＞の機能追加</br>
    /// <br>Update Note : 2013/02/06 wangyl</br>
    /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
    /// <br>              RRedmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
    /// <br>Update Note : 2013/04/03 wangl2</br>
    /// <br>管理番号    : 10801804-00</br>
    /// <br>              Redmine#35210の対応 「UOE手入力発注」で連番が全て "1" でエラーになる（№1802）  </br>
    /// <br>Update Note : 2013/08/19 wuyk</br>
    /// <br>管理番号    : 10801804-00</br>
    /// <br>              Redmine#39934の対応・UOE／仕入受信を行った際のオンライン番号不正の件について修正  </br>
    /// <br>Update Note : 2014/11/19 鄧潘ハン</br>
    /// <br>管理番号    : 11000192-00</br>
    /// <br>              仕掛一覧：№2565 Redmine#43752の対応・明治UOEWEBの卸商仕入受信処理の場合、メモリ違反の調査の対応  </br>
    /// </remarks>
    [Serializable]
    public class IOWriteUOEOdrDtlDB : RemoteWithAppLockDB, IIOWriteUOEOdrDtlDB
    {
        private Hashtable _ComAsmIdToMaxDtlCntTable = null;

        # region [使用リモート]

        # region [採番管理クラス プロパティ]
        private NumberingManager _numMng = null;

        private NumberingManager NumMng
        {
            get
            {
                if (this._numMng == null)
                {
                    this._numMng = new NumberingManager();
                }

                return this._numMng;
            }
        }
        # endregion

        # region [UOE発注データリモート プロパティ]
        private UOEOrderDtlDB _UOEOdrDtlDb = null;

        private UOEOrderDtlDB UOEOdrDtlDb
        {
            get
            {
                if (this._UOEOdrDtlDb == null)
                {
                    this._UOEOdrDtlDb = new UOEOrderDtlDB();
                }

                return this._UOEOdrDtlDb;
            }
        }
        # endregion

        # region [仕入I/Oリモート プロパティ]
        private IOWriteMASIRDB _IOWriteMaSirDb = null;

        private IOWriteMASIRDB IOWriteMaSirDb
        {
            get
            {
                if (this._IOWriteMaSirDb == null)
                {
                    this._IOWriteMaSirDb = new IOWriteMASIRDB();
                }

                return this._IOWriteMaSirDb;
            }
        }
        # endregion

        # region [仕入リモート プロパティ]
        private StockSlipDB _StockSlipDb = null;

        private StockSlipDB StockSlipDb
        {
            get
            {
                if (this._StockSlipDb == null)
                {
                    this._StockSlipDb = new StockSlipDB();
                }

                return this._StockSlipDb;
            }
        }
        # endregion


        # endregion

        /// <summary>
        /// UOE発注用I/OWriteDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>UpdateNote  : 2010/03/08 楊明俊 ＵＯＥ発注番号・ＵＯＥ発注行番号の設定の対応</br>
        /// <br>UpdateNote  : 2010/05/07 高峰 PM1008 明治UOE-WEB対応に伴う仕様追加</br>
        /// <br>UpdateNote :2011/01/06 liyp ＵＯＥ発注行番号の設定は、１つのＵＯＥ発注番号に対して、最大４明細までとする</br>
        /// <br>UpdateNote  : 2011/01/30 朱 猛 ＵＯＥ自動化改良</br>
        /// <br>UpdateNote  : 2011/03/01 liyp 日産UOE自動化B対応</br>
        /// <br>UpdateNote  : 2011/05/10 施炳中 マツダWEB対応</br>
        /// </remarks>
        public IOWriteUOEOdrDtlDB()
            : base("PMUOE01008D", "Broadleaf.Application.Remoting.ParamData.IOWriteUOEOdrDtlWork", "IOWRITEUOEODRDTLRF")
        {
            _ComAsmIdToMaxDtlCntTable = new Hashtable();

            // 通信アセンブリID と メーカー毎の送信最大明細数を関連付ける
            _ComAsmIdToMaxDtlCntTable.Add("0102", 3);   //トヨタ
            _ComAsmIdToMaxDtlCntTable.Add("0202", 4);   //日産
            _ComAsmIdToMaxDtlCntTable.Add("0301", 3);   //三菱
            // ---ADD 2010/04/26 gaoyh ---------------------------------------->>>>>
            _ComAsmIdToMaxDtlCntTable.Add("0302", 5);　//三菱web-UOE
            // ---ADD 2010/04/26 gaoyh ----------------------------------------<<<<<
            _ComAsmIdToMaxDtlCntTable.Add("0303", 5);　//三菱web-UOE ADD 2011/01/06
            _ComAsmIdToMaxDtlCntTable.Add("0401", 6);   //旧マツダ
            _ComAsmIdToMaxDtlCntTable.Add("0402", 6);   //新マツダ
            _ComAsmIdToMaxDtlCntTable.Add("0501", 10);  //ホンダ
            _ComAsmIdToMaxDtlCntTable.Add("0801", 1);   //スバル
            _ComAsmIdToMaxDtlCntTable.Add("1001", 5);   //優良メーカー
            // 2009/05/25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            _ComAsmIdToMaxDtlCntTable.Add("0502", 6);   //e-Parts
            // 2009/05/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            _ComAsmIdToMaxDtlCntTable.Add("0103", 3);　//トヨタ電子カタログ // ADD 2009/12/29 xuxh
            // ---ADD 2010/03/08 ---------------------------------------->>>>>
            _ComAsmIdToMaxDtlCntTable.Add("0203", 4);　//日産web-UOE
            // ---ADD 2010/03/08 ----------------------------------------<<<<<
            _ComAsmIdToMaxDtlCntTable.Add("0204", 4); //日産web-UOE ADD 2011/01/06
            // ---ADD 2010/05/07 ---------------------------------------->>>>>
            _ComAsmIdToMaxDtlCntTable.Add("1004", 5);　//明治web-UOE
            // ---ADD 2010/05/07 ----------------------------------------<<<<<
            _ComAsmIdToMaxDtlCntTable.Add("0104", 3);　//トヨタ自動処理 // ADD 2011/01/30 朱 猛
            // ---ADD 2011/03/01 ---------------------------------------->>>>>
            _ComAsmIdToMaxDtlCntTable.Add("0205", 4); // 日産WEBUOE
            _ComAsmIdToMaxDtlCntTable.Add("0206", 4); // 日産WEBUOE
            // ---ADD 2011/03/01 ----------------------------------------<<<<<
            // ---ADD 2011/05/10 ---------------------------------------->>>>>
            _ComAsmIdToMaxDtlCntTable.Add("0403", 5);   //マツダWEB
            // ---ADD 2011/05/10 ----------------------------------------<<<<

            // ---ADD 2011/10/26 ---------------------------------------->>>>>
            _ComAsmIdToMaxDtlCntTable.Add("1003", 5);　//卸NET-WEB
            // ---ADD 2011/10/26 ----------------------------------------<<<<

#if DEBUG
            Console.WriteLine("UOE発注用I/OWriteDBリモートオブジェクト");
#endif
        }

        # region [Write]
        /// <summary>
        /// UOE発注用I/OWrite情報を追加・更新します。
        /// </summary>
        /// <param name="uoeOdrDtlList">追加・更新するUOE発注用I/OWrite情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList に格納されているUOE発注用I/OWrite情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        public int Write(ref object uoeOdrDtlList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = uoeOdrDtlList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// UOE発注用I/OWrite情報を追加・更新します。
        /// </summary>
        /// <param name="uoeOdrDtlList">追加・更新するUOE発注用I/OWrite情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList に格納されているUOE発注用I/OWrite情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        public int Write(ref ArrayList uoeOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // システムロック 
            Dictionary<string, string> dic = new Dictionary<string, string>();

            ArrayList infoList = new ArrayList();
            UOEOrderDtlWork stockdtlwork = uoeOdrDtlList[0] as UOEOrderDtlWork;

            foreach (UOEOrderDtlWork st in uoeOdrDtlList)
            {
                if (dic.ContainsKey(st.SectionCode) == false)
                {
                    dic.Add(st.SectionCode, st.SectionCode);
                }
            }

            ShareCheckInfo info = new ShareCheckInfo();
            foreach (string secCd in dic.Keys)
            {
                info.Keys.Add(stockdtlwork.EnterpriseCode, ShareCheckType.Section, secCd, "");
            }
            status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

            if (status != 0) return status;

            status = this.WriteInitial(ref uoeOdrDtlList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = this.WriteProc(ref uoeOdrDtlList, ref sqlConnection, ref sqlTransaction);
            }

            // システムロック解除
            status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);

            return status;
        }

        /// <summary>
        /// UOE発注用I/OWrite情報を追加・更新します。
        /// </summary>
        /// <param name="uoeOdrDtlList">追加・更新するUOE発注用I/OWrite情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList に格納されているUOE発注用I/OWrite情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>UpdateNote  : 2010/03/08 楊明俊 ＵＯＥ発注番号・ＵＯＥ発注行番号の設定の対応</br>
        /// <br>UpdateNote  : 2011/01/30 朱 猛 ＵＯＥ自動化改良</br>
        /// <br>UpdateNote  : 2011/03/01 liyp 日産UOE自動化B対応</br>
        /// <br>UpdateNote  : 2011/05/10 施炳中 ＜IOWriteControlDB＞の機能追加</br>
        /// <br>UpdateNote  : 2011/11/18 譚洪 回答番号が採番不正</br>
        public int WriteInitial(ref ArrayList uoeOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                if (ListUtils.IsNotEmpty(uoeOdrDtlList) && sqlConnection != null && sqlTransaction != null)
                {
                    UOEOrderDtlWork UOEOdrDtl = uoeOdrDtlList[0] as UOEOrderDtlWork;

                    if (UOEOdrDtl != null)
                    {
                        // 番号採番時に色々と並び変えるので、コピーを取って処理を行う
                        // リストに格納されているUOE発注データは同一インスタンスの為、採番結果などは正しく格納される
                        ArrayList tmpOdrDtlList = new ArrayList();
                        tmpOdrDtlList.AddRange(uoeOdrDtlList);

                        # region [オンライン番号採番処理]
                        // オンライン番号とオンライン行番号の採番処理 (前提として未採番・採番済のデータは混在しない)
                        if (UOEOdrDtl.OnlineNo == 0)
                        {
                            status = this.NumberingOfOnlineNo(ref tmpOdrDtlList, ref sqlConnection, ref sqlTransaction);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                errmsg += ": オンライン番号の採番に失敗しました.";
                                base.WriteErrorLog(errmsg, status);
                                return status;
                            }

                            // 2009/05/25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //if (UOEOdrDtl.SystemDivCd != 0)
                            //if (UOEOdrDtl.SystemDivCd != 0 || UOEOdrDtl.CommAssemblyId == "0502") // DEL 2009/12/29 xuxh
                            if (UOEOdrDtl.SystemDivCd != 0 || UOEOdrDtl.CommAssemblyId == "0502"
                                // ---UPD 2010/03/08 ---------------------------------------->>>>>
                                //|| UOEOdrDtl.CommAssemblyId == "0103") // ADD 2009/12/29 xuxh
                                || UOEOdrDtl.CommAssemblyId == "0103" || UOEOdrDtl.CommAssemblyId == "0203"
                                || UOEOdrDtl.CommAssemblyId == "0104" // トヨタ自動処理 // ADD 2011/01/30 朱 猛
                                || UOEOdrDtl.CommAssemblyId == "0204" // ADD 2011/01/06 liyp
                                || UOEOdrDtl.CommAssemblyId == "0302" // ADD 2010/04/26 gaoyh
                                || UOEOdrDtl.CommAssemblyId == "0205" // ADD 2011/03/01
                                || UOEOdrDtl.CommAssemblyId == "0206" // ADD 2011/03/01
                                || UOEOdrDtl.CommAssemblyId == "0303" // ADD 2011/01/06	liyp
                                || UOEOdrDtl.CommAssemblyId == "0403")  // ADD 2011/05/10
                            // ---UPD 2010/03/08 ----------------------------------------<<<<<
                            // 2009/05/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            {
                                // 手入力発注以外の場合、オンライン番号を採番した場合はそこで処理を中断する
                                // ※手入力発注の場合は引き続きUOE発注番号の採番処理を行う
                                return status;
                            }
                        }
                        # endregion

                        # region [UOE発注番号採番処理]
                        // UOE発注番号とUOE発注行番号の採番処理 (前提として未採番・採番済のデータが混在しない)
                        //if (UOEOdrDtl.UOESalesOrderNo == 0)   // DEL 譚洪 2013/11/18
                        if (UOEOdrDtl.UOEKind == 0 && UOEOdrDtl.UOESalesOrderNo == 0) // ADD 譚洪 2013/11/18
                        {
                            status = this.NumberingOfUOESalesOrderNo(ref tmpOdrDtlList, ref sqlConnection, ref sqlTransaction);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                errmsg += ": UOE発注番号の採番に失敗しました.";
                                base.WriteErrorLog(errmsg, status);
                                return status;
                            }
                        }
                        # endregion

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// UOE発注用I/OWrite情報を追加・更新します。
        /// </summary>
        /// <param name="uoeOdrDtlList">追加・更新するUOE発注用I/OWrite情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList に格納されているUOE発注用I/OWrite情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        public int WriteProc(ref ArrayList uoeOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                if (ListUtils.IsNotEmpty(uoeOdrDtlList) && sqlConnection != null && sqlTransaction != null)
                {
                    status = this.UOEOdrDtlDb.Write(ref uoeOdrDtlList, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }
        # endregion

        #region ADD 2013/04/3 Redmine#35210 wangl2 for No.1802の対応
        #region  [WriteUOESalesOrderNo]
        /// <summary>
        /// UOE発注データを追加・更新します。
        /// </summary>
        /// <param name="uoeOdrDtlList">UOE発注データリスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList に格納されているUOE発注データを追加・更新します。</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013.04.03</br>
        public int WriteUOESalesOrderNo(ref ArrayList uoeOdrDtlList)
        {
            SqlConnection sqlConnection = this.CreateConnection(true);
            SqlTransaction sqlTransaction = this.CreateTransaction(ref sqlConnection);
            // UOE発注番号設定処理
            int status = this.NumberingOfUOESalesOrderNoForStockEstmt(ref uoeOdrDtlList, ref sqlConnection, ref sqlTransaction);
            return status;
        }
        #endregion
        #endregion

        # region [Search]

        /// <summary>
        /// 特定のキー情報が合致するUOE発注データを複数検索します。
        /// </summary>
        /// <param name="param">検索キーを含むUOE発注データのリスト</param>
        /// <param name="result">検索結果</param>
        /// <param name="sqlConnection">DB接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        public int Search(ArrayList param, out ArrayList result, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList uoeOdrDtlList = new ArrayList();

            result = new ArrayList();

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            if (ListUtils.IsEmpty(param))
            {
                errmsg += ": UOE発注データ読込パラメータが未設定です.";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(errmsg, status);
            }
            else
            {
                foreach (object item in param)
                {
                    UOEOrderDtlWork uoeOdrDtl = item as UOEOrderDtlWork;

                    if (uoeOdrDtl != null)
                    {
                        uoeOdrDtlList.Clear();
                        status = this.UOEOdrDtlDb.Search(ref uoeOdrDtlList, uoeOdrDtl, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            result.AddRange(uoeOdrDtlList);
                        }
                        else
                        {
                            result.Clear();
                            break;
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// UOE発注データの特定項目をキーに、UOE発注データとそれに紐付く仕入データ＋仕入明細データを取得します。
        /// </summary>
        /// <param name="uoeOrderDtlList">検索条件となるUOE発注データ</param>
        /// <param name="slipGroupList">検索結果(UOE発注データ、仕入データ、仕入明細データ)</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 検索条件に一致するUOE発注データと、それに紐付く仕入明細データを取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.12.10</br>
        // <br>Update Note : 2014/11/19 鄧潘ハン</br>
        /// <br>管理番号   : 11000192-00</br>
        /// <br>             仕掛一覧：№2565 Redmine#43752の対応・明治UOEWEBの卸商仕入受信処理の場合、メモリ違反の調査の対応  </br>
        public int Search(ref object uoeOrderDtlList, ref object slipGroupList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                # region [パラメータチェック]

                if (ListUtils.IsEmpty(uoeOrderDtlList as ArrayList))
                {
                    errmsg += ": UOE発注データ読込パラメータが未設定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (slipGroupList != null && !(slipGroupList is CustomSerializeArrayList))
                {
                    errmsg += ": 検索結果格納リストが未設定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                SqlConnection sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    errmsg += ": データベース接続情報の取得に失敗しました.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                SqlTransaction sqlTransaction = null;

                # endregion

                # region [UOE発注データ読込]

                ArrayList uoeReadParam = uoeOrderDtlList as ArrayList;
                ArrayList uoeReadResult = new ArrayList();
                ArrayList uoeOdrDtlList = new ArrayList();
                CustomSerializeArrayList stockList = new CustomSerializeArrayList();// ADD 2014/11/19 鄧潘ハン 仕掛一覧：№2565

                foreach (object item in uoeReadParam)
                {
                    UOEOrderDtlWork uoeOdrDtl = item as UOEOrderDtlWork;

                    if (uoeOdrDtl != null)
                    {
                        uoeReadResult.Clear();

                        status = this.UOEOdrDtlDb.Search(ref uoeReadResult, uoeOdrDtl, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            uoeOdrDtlList.AddRange(uoeReadResult);
                        }
                        else
                        {
                            errmsg += ": UOE発注データの読込に失敗しました.";
                            this.WriteErrorLog(errmsg, status);
                            break;
                        }
                    }
                }

                # endregion

                # region [仕入データ読込]

                ArrayList slipGrpList = slipGroupList as ArrayList;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    slipGrpList.Add(uoeOdrDtlList);

                    Dictionary<StockSlipPrimary, StockSlipReadWork> stcReadDic = new Dictionary<StockSlipPrimary, StockSlipReadWork>();

                    # region [UOE発注明細データより、重複しない仕入データのキー値を収集する]
                    foreach (UOEOrderDtlWork odrDtlWrk in uoeOdrDtlList)
                    {
                        StockSlipPrimary key = new StockSlipPrimary();
                        key.EnterpriseCode = odrDtlWrk.EnterpriseCode;  // 企業コード
                        key.SupplierFormal = odrDtlWrk.SupplierFormal;  // 仕入形式
                        key.SupplierSlipNo = odrDtlWrk.SupplierSlipNo;  // 仕入伝票番号

                        if (!stcReadDic.ContainsKey(key))
                        {
                            StockSlipReadWork value = new StockSlipReadWork();
                            value.EnterpriseCode = key.EnterpriseCode;
                            value.SupplierFormal = key.SupplierFormal;
                            value.SupplierSlipNo = key.SupplierSlipNo;
                            stcReadDic.Add(key, value);
                        }
                    }
                    # endregion

                    CustomSerializeArrayList stcReadParam = new CustomSerializeArrayList();
                    CustomSerializeArrayList stcReadResult = new CustomSerializeArrayList();
                    object freeParam = null;

                    foreach (StockSlipReadWork readWrk in stcReadDic.Values)
                    {
                        stcReadParam.Clear();
                        stcReadParam.Add(readWrk);
                        stcReadResult.Clear();// ADD 2014/11/19 鄧潘ハン 仕掛一覧：№2565 
                        status = this.StockSlipDb.Read(this.GetType().Name, ref stcReadParam, ref stcReadResult, 0, "", ref freeParam, ref sqlConnection);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            stockList.AddRange(stcReadResult);// ADD 2014/11/19 鄧潘ハン 仕掛一覧：№2565
                            //slipGrpList.Add(stcReadResult);// DEL 2014/11/19 鄧潘ハン 仕掛一覧：№2565
                        }
                        else
                        {
                            errmsg += ": 仕入データの読込に失敗しました.";
                            this.WriteErrorLog(errmsg, status);
                            break;
                        }
                    }
                }

                # endregion

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    slipGrpList.Clear();
                }
                // --- ADD 2014/11/19 鄧潘ハン 仕掛一覧：№2565 ---------->>>>>
                else
                {
                    slipGrpList.Add(stockList);
                }
                // --- ADD 2014/11/19 鄧潘ハン 仕掛一覧：№2565 ----------<<<<<
            }
            catch (SqlException ex)
            {
                status = this.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        // ------ADD 2023/01/20 田村顕成 卸商仕入受信処理障害対応 ------>>>>>
        /// <summary>
        /// UOE発注データの特定項目をキーに、UOE発注データとそれに紐付く仕入データ＋仕入明細データを取得します。
        /// </summary>
        /// <param name="uoeOrderDtlList">検索条件となるUOE発注データ</param>
        /// <param name="slipGroupList">検索結果(UOE発注データ、仕入データ、仕入明細データ)</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: PMKOBETSU-4202 卸商仕入受信処理障害対応</br>
        /// <br>Programmer : 田村顕成</br>
        /// <br>Date       : 2023/01/20</br>
        /// <br>Update Note: PMKOBETSU-4369 山形部品㈱_卸商仕入受信処理不具合対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2025/01/10</br>
        public int Search2(ref object uoeOrderDtlList, ref object slipGroupList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                # region [パラメータチェック]

                if (ListUtils.IsEmpty(uoeOrderDtlList as ArrayList))
                {
                    errmsg += ": UOE発注データ読込パラメータが未設定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (slipGroupList != null && !(slipGroupList is CustomSerializeArrayList))
                {
                    errmsg += ": 検索結果格納リストが未設定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                SqlConnection sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    errmsg += ": データベース接続情報の取得に失敗しました.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                SqlTransaction sqlTransaction = null;

                # endregion

                # region [UOE発注データ読込]

                ArrayList uoeReadParam = uoeOrderDtlList as ArrayList;
                ArrayList uoeReadResult = new ArrayList();
                ArrayList uoeOdrDtlList = new ArrayList();
                CustomSerializeArrayList stockList = new CustomSerializeArrayList();

                foreach (object item in uoeReadParam)
                {
                    UOEOrderDtlWork uoeOdrDtl = item as UOEOrderDtlWork;

                    if (uoeOdrDtl != null)
                    {
                        uoeReadResult.Clear();

                        status = this.UOEOdrDtlDb.Search(ref uoeReadResult, uoeOdrDtl, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            uoeOdrDtlList.AddRange(uoeReadResult);
                        }
                        else
                        {
                        	//PMUOE01051R.Serchの検索結果が4の場合は、エラーとせずにそれ以降の検索も行う
                        	if(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        	{
                        		continue;
                        	}
                            errmsg += ": UOE発注データの読込に失敗しました.";
                            this.WriteErrorLog(errmsg, status);
                            break;
                        }
                    }
                }

                # endregion

                # region [仕入データ読込]

                ArrayList slipGrpList = slipGroupList as ArrayList;

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)     // DEL 2025/01/10 陳艶丹 PMKOBETSU-4369 山形部品㈱_卸商仕入受信処理不具合対応
                if (uoeOdrDtlList.Count > 0)    // ADD 2025/01/10 陳艶丹 PMKOBETSU-4369 山形部品㈱_卸商仕入受信処理不具合対応
                {
                    slipGrpList.Add(uoeOdrDtlList);

                    Dictionary<StockSlipPrimary, StockSlipReadWork> stcReadDic = new Dictionary<StockSlipPrimary, StockSlipReadWork>();

                    # region [UOE発注明細データより、重複しない仕入データのキー値を収集する]
                    foreach (UOEOrderDtlWork odrDtlWrk in uoeOdrDtlList)
                    {
                        StockSlipPrimary key = new StockSlipPrimary();
                        key.EnterpriseCode = odrDtlWrk.EnterpriseCode;  // 企業コード
                        key.SupplierFormal = odrDtlWrk.SupplierFormal;  // 仕入形式
                        key.SupplierSlipNo = odrDtlWrk.SupplierSlipNo;  // 仕入伝票番号

                        if (!stcReadDic.ContainsKey(key))
                        {
                            StockSlipReadWork value = new StockSlipReadWork();
                            value.EnterpriseCode = key.EnterpriseCode;
                            value.SupplierFormal = key.SupplierFormal;
                            value.SupplierSlipNo = key.SupplierSlipNo;
                            stcReadDic.Add(key, value);
                        }
                    }
                    # endregion

                    CustomSerializeArrayList stcReadParam = new CustomSerializeArrayList();
                    CustomSerializeArrayList stcReadResult = new CustomSerializeArrayList();
                    object freeParam = null;

                    foreach (StockSlipReadWork readWrk in stcReadDic.Values)
                    {
                        stcReadParam.Clear();
                        stcReadParam.Add(readWrk);
                        stcReadResult.Clear();
                        status = this.StockSlipDb.Read(this.GetType().Name, ref stcReadParam, ref stcReadResult, 0, "", ref freeParam, ref sqlConnection);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            stockList.AddRange(stcReadResult);
                        }
                        else
                        {
                            // --- ADD 2025/01/10 陳艶丹 PMKOBETSU-4369 山形部品㈱_卸商仕入受信処理不具合対応 ----->>>>>
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                continue;
                            }
                            // --- ADD 2025/01/10 陳艶丹 PMKOBETSU-4369 山形部品㈱_卸商仕入受信処理不具合対応 -----<<<<<
                            errmsg += ": 仕入データの読込に失敗しました.";
                            this.WriteErrorLog(errmsg, status);
                            break;
                        }
                    }
                }

                # endregion

                // --- UPD 2025/01/10 陳艶丹 PMKOBETSU-4369 山形部品㈱_卸商仕入受信処理不具合対応 ----->>>>>
                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    slipGrpList.Clear();
                //}
                //else
                //{
                //    slipGrpList.Add(stockList);
                //}
                if (stockList.Count > 0)
                {
                    slipGrpList.Add(stockList);
                }
                // --- UPD 2025/01/10 陳艶丹 PMKOBETSU-4369 山形部品㈱_卸商仕入受信処理不具合対応 -----<<<<<
            }
            catch (SqlException ex)
            {
                status = this.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }
        // ------ADD 2023/01/20 田村顕成 卸商仕入受信処理障害対応 ------<<<<<

        // 2009/05/25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// UOE発注データの特定項目をキーに、UOE発注データとそれに紐付く仕入データ＋仕入明細データを取得します。
        /// </summary>
        /// <param name="paraList">検索条件</param>
        /// <param name="uoeOrderDtlList">検索結果(UOE発注データ)</param>
        /// <param name="stockDtlList">検索結果(仕入明細データ)</param>        
        /// <returns>STATUS</returns>
        /// <br>Note       : 検索条件に一致するUOE発注データと、それに紐付く仕入明細データを取得します。</br>
        /// <br>Programmer : 22008　長内</br>
        /// <br>Date       : 2009.05.25</br>
        public int UoeOdrDtlGodsReadAll(object paraList, ref object uoeOrderDtlList, ref object stockDtlList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                # region [パラメータチェック]

                if (ListUtils.IsEmpty(paraList as ArrayList))
                {
                    errmsg += ": UOE発注データ読込パラメータが未設定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (uoeOrderDtlList == null || stockDtlList == null)
                {
                    errmsg += ": 検索結果格納リストが未設定です.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                SqlConnection sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    errmsg += ": データベース接続情報の取得に失敗しました.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                SqlTransaction sqlTransaction = null;

                # endregion

                # region [UOE発注データ読込]

                ArrayList uoeReadParam = paraList as ArrayList;
                ArrayList uoeOrderDtlArray = uoeOrderDtlList as ArrayList;

                if (uoeReadParam != null)
                {
                    status = this.UOEOdrDtlDb.UoeOdrDtlGodsReadAll(ref uoeOrderDtlArray, uoeReadParam, ref sqlConnection, ref sqlTransaction);
                }

                # endregion

                # region [仕入データ読込]
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList prmDtlList = new ArrayList();
                    ArrayList retDtlList = null;

                    foreach (UOEOrderDtlWork uoeOdrDtl in uoeOrderDtlArray)
                    {
                        // ※通常は起こり得ないが、不正データはスキップする
                        if (string.IsNullOrEmpty(uoeOdrDtl.EnterpriseCode) ||
                            uoeOdrDtl.StockSlipDtlNum == 0)
                        {
                            continue;
                        }

                        StockDetailWork stkDtl = new StockDetailWork();
                        stkDtl.EnterpriseCode = uoeOdrDtl.EnterpriseCode;    // 企業コード
                        stkDtl.SupplierFormal = uoeOdrDtl.SupplierFormal;    // 仕入形式
                        stkDtl.StockSlipDtlNum = uoeOdrDtl.StockSlipDtlNum;  // 仕入明細通番
                        prmDtlList.Add(stkDtl);
                    }

                    status = this.StockSlipDb.ReadStockDetailWork(out retDtlList, prmDtlList, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ((ArrayList)stockDtlList).AddRange(retDtlList);

                        # region [UOE発注データと仕入明細データの突合]
                        List<UOEOrderDtlWork> uoeOdrDtlListSrc = new List<UOEOrderDtlWork>((UOEOrderDtlWork[])uoeOrderDtlArray.ToArray(typeof(UOEOrderDtlWork)));
                        List<UOEOrderDtlWork> uoeOdrDtlListDst = new List<UOEOrderDtlWork>();

                        foreach (StockDetailWork stcDtlItem in retDtlList)
                        {
                            UOEOrderDtlWork match = uoeOdrDtlListSrc.Find(delegate(UOEOrderDtlWork uoeDtlItem)
                            {
                                return (uoeDtlItem.EnterpriseCode == stcDtlItem.EnterpriseCode &&
                                        uoeDtlItem.SupplierFormal == stcDtlItem.SupplierFormal &&
                                        uoeDtlItem.StockSlipDtlNum == stcDtlItem.StockSlipDtlNum);
                            });

                            if (match != null)
                            {
                                uoeOdrDtlListDst.Add(match);
                            }
                        }

                        uoeOrderDtlArray.Clear();
                        uoeOrderDtlArray.AddRange(uoeOdrDtlListDst);

                        # endregion
                    }
                }

                # endregion
            }
            catch (SqlException ex)
            {
                status = this.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }
        // 2009/05/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// UOE発注用I/OWrite情報のリストを取得します。
        /// </summary>
        /// <param name="uoeSendProcCndtn">検索条件</param>
        /// <param name="uoeOrderDtlList">検索結果(UOE発注データ)</param>
        /// <param name="stockDtlList">検索結果(仕入明細データ)</param>        
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE発注データのキー値が一致する、全てのUOE発注データ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>Note       : 発注一覧表とUOE発送処理のサーバ端で、操作履歴ログ追加</br>
        /// <br>Programmer : pengjie</br>
        /// <br>Date       : 2012.03.14</br>
        public int Search(object uoeSendProcCndtn, ref object uoeOrderDtlList, ref object stockDtlList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB(); // ADD pengjie 2013/03/14 REDMINE#34986
            String recordMsg = ""; // ADD zhangll 2013/05/10 REDMINE#34986
            try
            {
                # region [パラメーターチェック]
                ArrayList uoeOrderDtlArray = uoeOrderDtlList as ArrayList;

                if (uoeOrderDtlArray == null)
                {
                    errmsg += ": 検索結果を格納するリストが設定されていません.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                UOESendProcCndtnWork uoeSndPrcCnd = uoeSendProcCndtn as UOESendProcCndtnWork;

                if (uoeSndPrcCnd == null)
                {
                    errmsg += ": 検索条件が設定されていません.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);
                # endregion

                //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                // DB操作ログ
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, uoeSndPrcCnd.EnterpriseCode, "UOE発注データ", "抽出開始", "PMUOE01006R", 0); 
                //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                // UOE発注データ読込
                status = this.UOEOdrDtlDb.SearchUoeSend(ref uoeOrderDtlArray, uoeSndPrcCnd, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);

                //-----DEL zhangll 2013/05/10 REDMINE#34986 ----->>>>>
                ////-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                //// DB操作ログ
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && ListUtils.IsNotEmpty(uoeOrderDtlArray))
                //{
                //    String recordMsg = "抽出終了" + "、" + "ST=" + status + "、" + "抽出件数=" + uoeOrderDtlArray.Count;
                //    oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, uoeSndPrcCnd.EnterpriseCode, "UOE発注データ", recordMsg, "PMUOE01006R", 0);
                //}
                //else
                //{
                //    String recordMsg = "抽出終了" + "、" + "ST=" + status;
                //    oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, uoeSndPrcCnd.EnterpriseCode, "UOE発注データ", recordMsg, "PMUOE01006R", 0);
                //}
                ////-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<
                //-----DEL zhangll 2013/05/10 REDMINE#34986 -----<<<<<

                //-----ADD zhangll 2013/05/10 REDMINE#34986 ----->>>>>
                recordMsg = "抽出終了" + "、" + "ST=" + status;
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, uoeSndPrcCnd.EnterpriseCode, "UOE発注データ", recordMsg, "PMUOE01006R", 0);
                //-----ADD zhangll 2013/05/10 REDMINE#34986 -----<<<<<

                # region [発注データの読込]

                // UOE発注データに紐付く仕入データを取得する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && ListUtils.IsNotEmpty(uoeOrderDtlArray))
                {
                    ArrayList prmDtlList = new ArrayList();
                    ArrayList retDtlList = null;

                    foreach (UOEOrderDtlWork uoeOdrDtl in uoeOrderDtlArray)
                    {
                        // ※通常は起こり得ないが、不正データはスキップする
                        if (string.IsNullOrEmpty(uoeOdrDtl.EnterpriseCode) ||
                            uoeOdrDtl.StockSlipDtlNum == 0)
                        {
                            continue;
                        }

                        StockDetailWork stkDtl = new StockDetailWork();
                        stkDtl.EnterpriseCode = uoeOdrDtl.EnterpriseCode;    // 企業コード
                        stkDtl.SupplierFormal = uoeOdrDtl.SupplierFormal;    // 仕入形式
                        stkDtl.StockSlipDtlNum = uoeOdrDtl.StockSlipDtlNum;  // 仕入明細通番
                        prmDtlList.Add(stkDtl);
                    }

                    //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                    // DB操作ログ
                    oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, uoeSndPrcCnd.EnterpriseCode, "仕入明細データ", "抽出開始", "PMUOE01006R", 0);
                    //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                    status = this.StockSlipDb.ReadStockDetailWork(out retDtlList, prmDtlList, ref sqlConnection, ref sqlTransaction);

                    //-----DEL zhangll 2013/05/10 REDMINE#34986 ----->>>>>
                    ////-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                    //// DB操作ログ
                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && ListUtils.IsNotEmpty(retDtlList))
                    //{
                    //    String recordMsg = "抽出終了" + "、" + "ST=" + status + "、" + "抽出件数=" + retDtlList.Count;
                    //    oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, uoeSndPrcCnd.EnterpriseCode, "仕入明細データ", recordMsg, "PMUOE01006R", 0);
                    //}
                    //else
                    //{
                    //    String recordMsg = "抽出終了" + "、" + "ST=" + status;
                    //    oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, uoeSndPrcCnd.EnterpriseCode, "仕入明細データ", recordMsg, "PMUOE01006R", 0);

                    //}
                    ////-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<
                    //-----DEL zhangll 2013/05/10 REDMINE#34986 -----<<<<<

                    //-----ADD zhangll 2013/05/10 REDMINE#34986 ----->>>>>
                    recordMsg = "抽出終了" + "、" + "ST=" + status;
                    oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, uoeSndPrcCnd.EnterpriseCode, "仕入明細データ", recordMsg, "PMUOE01006R", 0);
                    //-----ADD zhangll 2013/05/10 REDMINE#34986 -----<<<<<

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ((ArrayList)stockDtlList).AddRange(retDtlList);

                        # region [UOE発注データと仕入明細データの突合]
                        List<UOEOrderDtlWork> uoeOdrDtlListSrc = new List<UOEOrderDtlWork>((UOEOrderDtlWork[])uoeOrderDtlArray.ToArray(typeof(UOEOrderDtlWork)));
                        List<UOEOrderDtlWork> uoeOdrDtlListDst = new List<UOEOrderDtlWork>();

                        foreach (StockDetailWork stcDtlItem in retDtlList)
                        {
                            UOEOrderDtlWork match = uoeOdrDtlListSrc.Find(delegate(UOEOrderDtlWork uoeDtlItem)
                            {
                                return (uoeDtlItem.EnterpriseCode == stcDtlItem.EnterpriseCode &&
                                        uoeDtlItem.SupplierFormal == stcDtlItem.SupplierFormal &&
                                        uoeDtlItem.StockSlipDtlNum == stcDtlItem.StockSlipDtlNum);
                            });

                            if (match != null)
                            {
                                uoeOdrDtlListDst.Add(match);
                            }
                        }

                        uoeOrderDtlArray.Clear();
                        uoeOrderDtlArray.AddRange(uoeOdrDtlListDst);

                        # endregion
                    }
                }

                # endregion
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
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

        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// UOE発注データと、それに紐付く仕入明細データを論理削除します。
        /// </summary>
        /// <param name="uoeOdrDtlList">論理削除するUOE発注データを含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE発注データと、それに紐付く仕入明細データを論理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        public int LogicalDelete(ref object uoeOdrDtlList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            SqlConnection sqlConnection = this.CreateSqlConnection(true);
            SqlTransaction sqlTransaction = this.CreateTransaction(ref sqlConnection);
            SqlEncryptInfo sqlEncryptInfo = null;

            try
            {
                ArrayList uoeOdrDtlArray = uoeOdrDtlList as ArrayList;
                status = this.LogicalDelete(ref uoeOdrDtlArray, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
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

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// UOE発注用I/OWrite情報の論理削除を操作します。
        /// </summary>
        /// <param name="uoeOdrDtlList">論理削除を操作するUOE発注用I/OWrite情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlEncryptInfo">暗号化情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ioWriteUOEOdrDtlWork に格納されているUOE発注用I/OWrite情報の論理削除を操作します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        public int LogicalDelete(ref ArrayList uoeOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
            ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                # region [パラメーターチェック]

                if (ListUtils.IsEmpty(uoeOdrDtlList))
                {
                    errmsg += ": 削除対象のUOE発注データが設定されていません.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (ListUtils.Find(uoeOdrDtlList, typeof(UOEOrderDtlWork), ListUtils.FindType.Class) == null)
                {
                    errmsg += ": 削除対象のUOE発注データが設定されていません.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (sqlConnection == null)
                {
                    errmsg += ": データベース接続情報が設定されていません.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                if (sqlTransaction == null)
                {
                    errmsg += ": トランザクション情報が設定されていません.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # endregion
                // UOE受注データの論理削除
                status = this.UOEOdrDtlDb.ReceiptLogicalDelete(ref uoeOdrDtlList, 0, ref sqlConnection, ref sqlTransaction);  // ADD BY 凌小青 on 2011/10/28 for #26283と障害報告 #26284の対応
                // UOE発注データの論理削除
                status = this.UOEOdrDtlDb.LogicalDelete(ref uoeOdrDtlList, 0, ref sqlConnection, ref sqlTransaction);

                // 仕入明細(発注明細)データの論理削除
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList stockDtlList = new ArrayList();

                    foreach (UOEOrderDtlWork UOEOrderDtl in uoeOdrDtlList)
                    {
                        StockDetailWork StockDetail = new StockDetailWork();
                        StockDetail.EnterpriseCode = UOEOrderDtl.EnterpriseCode;
                        StockDetail.SupplierFormal = UOEOrderDtl.SupplierFormal;
                        StockDetail.StockSlipDtlNum = UOEOrderDtl.StockSlipDtlNum;
                        stockDtlList.Add(StockDetail);
                    }

                    string retMsg = string.Empty;
                    string retInfo = string.Empty;
                    status = this.IOWriteMaSirDb.DeleteforOrderInput(ref stockDtlList, out retMsg, out retInfo, ref sqlConnection,
                             ref sqlTransaction, ref sqlEncryptInfo);
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {

            }

            return status;
        }

        # endregion

        # region [UOE発注確定処理]

        /// <summary>
        /// UOE発注確定処理
        /// </summary>
        /// <param name="uoeOdrSlipList"></param>
        /// <returns>STATUS</returns>
        public int OrderFixation(ref object uoeOdrSlipList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlEncryptInfo sqlEncryptInfo = null;  // 保留

            try
            {
                # region [パラメーターチェック]
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    errmsg += ": データベースへの接続に失敗しました.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                if (sqlTransaction == null)
                {
                    errmsg += ": トランザクションの開始に失敗しました.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                ArrayList uoeOrderSlipArray = uoeOdrSlipList as ArrayList;

                if (ListUtils.IsEmpty(uoeOrderSlipArray))
                {
                    errmsg += ": 発注データ(確定)が設定されていません.";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }
                # endregion

                // ********* DEL sakurai 2009/02/25 MAKON01814Rで掛けているため2重ロック防止 ***************
                #region
                // システムロック 
                //Dictionary<string, string> dic = new Dictionary<string, string>();
                //ArrayList allOdrDtlList = new ArrayList();

                // 2009/02/20 MANTIS 11671 >>>>>>>>>>>>>>>>>>>
                //foreach (object item in uoeOrderSlipArray)
                //{
                //    ArrayList OrderSlips = item as ArrayList;

                //    if (OrderSlips != null)
                //    {
                //        ArrayList OdrDtlList = ListUtils.Find(OrderSlips, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                //        if (ListUtils.IsNotEmpty(OdrDtlList))
                //        {
                //            allOdrDtlList.AddRange(OdrDtlList);
                //        }
                //    }
                //}

                //StockDetailWork stockdtlwork = allOdrDtlList[0] as StockDetailWork;

                //foreach (StockDetailWork stwork in allOdrDtlList)
                //{
                //    if (dic.ContainsKey(stwork.SectionCode) == false)
                //    {
                //        dic.Add(stwork.SectionCode, stwork.SectionCode);
                //    }
                //}

                //回線エラー発生時はUOE発注データのみUIから渡されるため、
                //シェアチェック対象リストをUOE発注データに変更
                //allOdrDtlList = ListUtils.Find(uoeOrderSlipArray, typeof(UOEOrderDtlWork), ListUtils.FindType.Array) as ArrayList;

                //UOEOrderDtlWork uoeOrderdtlwork = allOdrDtlList[0] as UOEOrderDtlWork;

                //foreach (UOEOrderDtlWork uoework in allOdrDtlList)
                //{
                //    if (dic.ContainsKey(uoework.SectionCode) == false)
                //    {
                //        dic.Add(uoework.SectionCode, uoework.SectionCode);
                //    }
                //}
                //// 2009/02/20 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<,

                //ShareCheckInfo info = new ShareCheckInfo();
                //foreach (string secCd in dic.Keys)
                //{
                //    info.Keys.Add(uoeOrderdtlwork.EnterpriseCode, ShareCheckType.Section, secCd,"");
                //}

                //if (info.Keys.Count != 0)
                //{
                //    status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                //}

                //if (status != 0) return status;
                #endregion
                // *****************************************************************************************

                status = this.OrderFixationProc(ref uoeOrderSlipArray, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                // ********* DEL sakurai 2009/02/25 MAKON01814Rで掛けているため2重ロック防止 ***************
                #region
                //if (info.Keys.Count != 0)
                //{
                //    // システムロック解除
                //    status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                //}
                #endregion
                // *****************************************************************************************
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
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
        /// 
        /// </summary>
        /// <param name="uoeOdrSlipList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlEncryptInfo"></param>
        /// <returns></returns>
        private int OrderFixationProc(ref ArrayList uoeOdrSlipList,
                                      ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                string retMsg = string.Empty;
                string retItemInfo = string.Empty;

                bool existOdrSlip = false;  // 仕入(発注)データ存在確認フラグ true:有る false:無し

                # region [仕入明細(発注明細)データの更新処理]

                // 仕入明細(発注明細)データを１つのArrayListにまとめる → 発注明細更新処理用
                ArrayList allOdrDtlList = new ArrayList();

                foreach (object item in uoeOdrSlipList)
                {
                    ArrayList OrderSlips = item as ArrayList;

                    if (OrderSlips != null)
                    {
                        ArrayList OdrDtlList = ListUtils.Find(OrderSlips, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                        if (ListUtils.IsNotEmpty(OdrDtlList))
                        {
                            // 仕入明細(発注明細)データを1つにまとめる
                            allOdrDtlList.AddRange(OdrDtlList);
                        }

                        // 併せて仕入(発注[仕入形式=2])データの存在確認も行う
                        if (!existOdrSlip)
                        {
                            StockSlipWork orderSlip = ListUtils.Find(OrderSlips, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;

                            if (orderSlip != null && orderSlip.SupplierFormal == 2)
                            {
                                existOdrSlip = true;
                            }
                        }
                    }
                }

                if (ListUtils.IsNotEmpty(allOdrDtlList))
                {
                    // 更新対象の仕入明細(発注明細)データが有る場合にのみ処理を行う
                    status = this.IOWriteMaSirDb.WriteforOrderInput(ref allOdrDtlList, out retMsg, out retItemInfo,
                                                                    ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errmsg += ": 仕入明細(発注明細)データの更新に失敗しました.";
                        base.WriteErrorLog(errmsg, status);
                        return status;
                    }
                }

                # endregion

                # region [発注データの登録]

                # region [DEL 変更前]
                //foreach (object item in uoeOdrSlipList)
                //{
                //    ArrayList OrdSlip = item as ArrayList;

                //    // 発注データ格納数分処理を行う
                //    if (ListUtils.IsNotEmpty(OrdSlip) &&
                //        ListUtils.Find(OrdSlip, typeof(StockSlipWork), ListUtils.FindType.Class) != null &&
                //        ListUtils.Find(OrdSlip, typeof(StockDetailWork), ListUtils.FindType.Array) != null)
                //    {
                //        status = this.StockSlipDb.WriteforSalesOrderPrint(ref OrdSlip, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //        {
                //            errmsg += ": 発注データの登録に失敗しました.";
                //            base.WriteErrorLog(errmsg, status);
                //            return status;
                //        }
                //    }
                //}
                # endregion

                if (existOdrSlip)
                {
                    //status = this.StockSlipDb.WriteforSalesOrderPrint(ref uoeOdrSlipList, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);                                //DEL 2009/01/16 M.Kubota
                    status = this.IOWriteMaSirDb.WriteforSalesOrderPrint(ref uoeOdrSlipList, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);  //ADD 2009/01/16 M.Kubota

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errmsg += ": 発注データの登録に失敗しました.";
                        base.WriteErrorLog(errmsg, status);
                        return status;
                    }
                }
                # endregion

                # region [UOE発注データの更新処理]

                // UOE発注データのリストを分離する
                ArrayList uoeOdrDtlList = ListUtils.Find(uoeOdrSlipList, typeof(UOEOrderDtlWork), ListUtils.FindType.Array) as ArrayList;

                if (ListUtils.IsNotEmpty(uoeOdrDtlList))
                {
                    if (ListUtils.IsNotEmpty(allOdrDtlList))
                    {
                        // 先に登録した発注データの仕入伝票番号を設定する
                        DtlRelationGuidComp dtlRelGuidCmp = new DtlRelationGuidComp();
                        allOdrDtlList.Sort(dtlRelGuidCmp);

                        foreach (UOEOrderDtlWork uoeOrderDtl in uoeOdrDtlList)
                        {
                            int idx = allOdrDtlList.BinarySearch(uoeOrderDtl, dtlRelGuidCmp);

                            if (idx >= 0)
                            {
                                uoeOrderDtl.SupplierSlipNo = (allOdrDtlList[idx] as StockDetailWork).SupplierSlipNo;
                            }
                        }
                    }

                    // UOE発注データの更新を行う
                    status = this.UOEOdrDtlDb.Write(ref uoeOdrDtlList, ref sqlConnection, ref sqlTransaction);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errmsg += ": UOE発注データの更新に失敗しました.";
                        base.WriteErrorLog(errmsg, status);
                        return status;
                    }
                }
                # endregion

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {

            }

            return status;
        }

        # endregion

        # region [UOEオンライン番号採番処理]

        /// <summary>
        /// UOEオンライン番号設定処理
        /// </summary>
        /// <param name="UoeOdrDtlList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
        /// <br>              RRedmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
        /// <br>Update Note : 2013/08/19 wuyk</br>
        /// <br>管理番号    : 10900690-00</br>
        /// <br>              Redmine#39934の対応・UOE／仕入受信を行った際のオンライン番号不正の件について修正 </br>
        /// </remarks>
        private int NumberingOfOnlineNo(ref ArrayList UoeOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (ListUtils.IsNotEmpty(UoeOdrDtlList))
            {
                UOEOrderDtlWork UOEOdrDtl = ListUtils.Find(UoeOdrDtlList, typeof(UOEOrderDtlWork), ListUtils.FindType.Class) as UOEOrderDtlWork;

                if (UOEOdrDtl != null)
                {
                    // リストに登録されている順番(画面に表示されている順番)を一時的にオンライン行番号に格納する
                    for (int idx = 0; idx < UoeOdrDtlList.Count; idx++)
                    {
                        UOEOdrDtl = UoeOdrDtlList[idx] as UOEOrderDtlWork;

                        if (UOEOdrDtl != null)
                        {
                            UOEOdrDtl.OnlineRowNo = idx + 1;
                        }
                    }

                    int uoeKind = (UoeOdrDtlList[0] as UOEOrderDtlWork).UOEKind;        // UOE種別(0:UOE 1:卸商仕入受信)        // ADD wuyk 2013/08/19 Redmine#39934

                    // オンライン番号採番用の並び替えを行う
                    //UoeOdrDtlList.Sort(new OnlineNoComparer());     // DEL wuyk 2013/08/19 Redmine#39934
                    UoeOdrDtlList.Sort(new OnlineNoComparer(uoeKind));     // ADD wuyk 2013/08/19 Redmine#39934

                    int savUOESupplierCd = 0;  // UOE発注先コード
                    int valOnlineNo = 0;       // オンライン番号
                    int valOnlineRowNo = 0;    // オンライン行番号
                    string savWarehouseCd = ""; // 倉庫コード // ADD wangyl 2013/02/06 FOR Redmine#34578

                    int systemDiv = (UoeOdrDtlList[0] as UOEOrderDtlWork).SystemDivCd;  //システム区分

                    // 並び替えをしたUOE発注データのリストを、UOE発注先コードをブレークキーとして
                    // オンライン番号とオンライン行番号を設定する
                    for (int idx = 0; idx < UoeOdrDtlList.Count; idx++)
                    {
                        UOEOdrDtl = UoeOdrDtlList[idx] as UOEOrderDtlWork;

                        if (UOEOdrDtl != null)
                        {
                            //---DEL wangyl 2013/02/06 Redmine#34578------>>>>>
                            //// 2009/02/14 MANTIS 9776>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //// 伝発の場合は初回のみ、オンライン番号を取得し、それ以降は同一の
                            //// オンライン番号を使用するように変更

                            //// 前回保持分のUOE発注先コードと異なる場合にオンライン番号を採番する
                            ////if (savUOESupplierCd != UOEOdrDtl.UOESupplierCd)
                            //if ((savUOESupplierCd != UOEOdrDtl.UOESupplierCd) &&
                            //    (systemDiv != 1 || idx == 0))
                            //// 2009/02/14 MANTIS 9776<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            //{
                            //    savUOESupplierCd = UOEOdrDtl.UOESupplierCd;

                            //    // オンライン行番号の初期化
                            //    valOnlineRowNo = 0;

                            //    // オンライン番号の採番
                            //    status = this.CreateOnlineNo(UOEOdrDtl, out valOnlineNo, ref sqlConnection, ref sqlTransaction);

                            //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            //    {
                            //        break;  // → 採番に失敗したら処理終了
                            //    }
                            //}
                            //---DEL wangyl 2013/02/06 Redmine#34578------<<<<<

                            //---ADD wuyk 2013/08/19 Redmine#39934------>>>>>
                            // UOE種別(0:UOE 1:卸商仕入受信) 
                            if (uoeKind == 1)
                            {
                                // 伝発の場合は初回のみ、オンライン番号を取得し、それ以降は同一の
                                // オンライン番号を使用するように変更

                                // 前回保持分のUOE発注先コードと異なる場合にオンライン番号を採番する
                                if ((savUOESupplierCd != UOEOdrDtl.UOESupplierCd) &&
                                    (systemDiv != 1 || idx == 0))
                                {
                                    savUOESupplierCd = UOEOdrDtl.UOESupplierCd;

                                    // オンライン行番号の初期化
                                    valOnlineRowNo = 0;

                                    // オンライン番号の採番
                                    status = this.CreateOnlineNo(UOEOdrDtl, out valOnlineNo, ref sqlConnection, ref sqlTransaction);

                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        break;  // → 採番に失敗したら処理終了
                                    }
                                }
                            }
                            else
                            {
                            //---ADD wuyk 2013/08/19 Redmine#39934------<<<<<
                                //---ADD wangyl 2013/02/06 Redmine#34578------>>>>>
                                // 前回保持分のUOE発注先コードと異なる場合にオンライン番号を採番する
                                if (systemDiv != 3)
                                {
                                    if ((savUOESupplierCd != UOEOdrDtl.UOESupplierCd) &&
                                        (systemDiv != 1 || idx == 0))
                                    {
                                        savUOESupplierCd = UOEOdrDtl.UOESupplierCd;
                                        //オンライン行番号の初期化
                                        valOnlineRowNo = 0;

                                        //オンライン番号の採番
                                        status = this.CreateOnlineNo(UOEOdrDtl, out valOnlineNo, ref sqlConnection, ref sqlTransaction);

                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            break;  // → 採番に失敗したら処理終了
                                        }
                                    }
                                }
                                else
                                {
                                    if ((savUOESupplierCd != UOEOdrDtl.UOESupplierCd) || (savWarehouseCd != UOEOdrDtl.WarehouseCode)) //在庫一括発注モードの場合にオンライン番号を採番する
                                    {
                                        savUOESupplierCd = UOEOdrDtl.UOESupplierCd;
                                        savWarehouseCd = UOEOdrDtl.WarehouseCode;
                                        //オンライン行番号の初期化
                                        valOnlineRowNo = 0;

                                        //オンライン番号の採番
                                        status = this.CreateOnlineNo(UOEOdrDtl, out valOnlineNo, ref sqlConnection, ref sqlTransaction);

                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            break;  // → 採番に失敗したら処理終了
                                        }
                                    }
                                }
                                //---ADD wangyl 2013/02/06 Redmine#34578------<<<<<
                            }       // ADD wuyk 2013/08/19 Redmine#39934
                            // UOE発注先コードが同値の間、同じオンライン番号を設定する
                            UOEOdrDtl.OnlineNo = valOnlineNo;

                            // オンライン行番号を増加した後に設定する(初期値が0の為、最初に+1する)
                            valOnlineRowNo++;
                            UOEOdrDtl.OnlineRowNo = valOnlineRowNo;
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// UOEオンライン番号採番処理
        /// </summary>
        /// <param name="keyItem"></param>
        /// <param name="onlineNo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int CreateOnlineNo(UOEOrderDtlWork keyItem, out int onlineNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //戻り値初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            onlineNo = 0;

            //番号範囲分ループ
            Int32 loopCnt = 1;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
            string enterpriseCode = keyItem.EnterpriseCode;
            string sectionCode = keyItem.SectionCode;

            long no = 0;

            # region [SELECT文]
            string sqlText = string.Empty;
            sqlText += "SELECT" + Environment.NewLine;
            sqlText += " UOE.ONLINENORF" + Environment.NewLine;
            sqlText += "FROM" + Environment.NewLine;
            sqlText += "  UOEORDERDTLRF AS UOE" + Environment.NewLine;
            sqlText += "WHERE" + Environment.NewLine;
            sqlText += "  UOE.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "  AND UOE.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
            sqlText += "  AND UOE.ONLINENORF = @FINDONLINENO" + Environment.NewLine;
            # endregion

            SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            SqlParameter findOnlineNo = sqlCommand.Parameters.Add("@FINDONLINENO", SqlDbType.Int);

            SqlDataReader myReader = null;

            try
            {
                # region [番号の取得・空き番号の確認処理]
                while (loopCnt <= 999999999)
                {
                    //オンライン番号は拠点管理有り
                    status = NumMng.GetSerialNumber(enterpriseCode, sectionCode, SerialNumberCode.UOEOnlineNo, out no);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //採番できなかった場合には処理中断。
                        break;
                    }
                    else
                    {
                        //空き番のチェックを行う
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                        //番号を数値型に変換
                        Int32 tmpOnlineNo = System.Convert.ToInt32(no);

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);
                        findOnlineNo.Value = SqlDataMediator.SqlSetInt32(tmpOnlineNo);

                        if (myReader != null && !myReader.IsClosed)
                        {
                            myReader.Close();
                            myReader.Dispose();
                        }

                        myReader = sqlCommand.ExecuteReader();

                        //データ無しの場合には戻り値をセット
                        if (!myReader.Read())
                        {
                            onlineNo = tmpOnlineNo;
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        }
                    }

                    //同一番号がある場合にはループカウンタをインクリメントし再採番
                    loopCnt++;
                }
                # endregion

                //全件ループしても取得出来ない場合
                if (loopCnt == 999999999 && status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    errmsg += ": UOEオンライン番号に空き番号が有りません.";
                    base.WriteErrorLog(errmsg, status);
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            //エラーでもステータス及びメッセージはそのまま戻す
            return status;
        }

        /// <summary>
        /// オンライン番号採番用並び替え処理
        /// </summary>
        /// <remarks>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
        /// <br>              RRedmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
        /// <br>Update Note : 2013/08/19 wuyk</br>
        /// <br>管理番号    : 10900690-00</br>
        /// <br>              Redmine#39934の対応・UOE／仕入受信を行った際のオンライン番号不正の件について修正 </br>
        /// </remarks>
        private class OnlineNoComparer : IComparer
        {
            //---ADD wuyk 2013/08/19 Redmine#39934------>>>>>
            // UOE種別（0:UOE 1:卸商仕入受信）
            private int _uoeKind = 0;

            /// <summary>
            /// UOE種別（0:UOE 1:卸商仕入受信）
            /// </summary>
            public int UOEKind
            {
                get { return _uoeKind; }
                set { _uoeKind = value; }
            }

            /// <summary>
            /// オンライン番号採番用並び替え処理クラスコンストラクタ
            /// </summary>
            /// <param name="uoeKind">UOE種別（0:UOE 1:卸商仕入受信）</param>
            public OnlineNoComparer(int uoeKind)
            {
                this._uoeKind = uoeKind;
            }
            //---ADD wuyk 2013/08/19 Redmine#39934------<<<<<

            public int Compare(object x, object y)
            {
                UOEOrderDtlWork xDtl = x as UOEOrderDtlWork;
                UOEOrderDtlWork yDtl = y as UOEOrderDtlWork;
                int ret = (xDtl == null ? 0 : 1) - (yDtl == null ? 0 : 1);

                #region DEL wuyk 2013/08/19 Redmine#39934
                //if (ret == 0 && xDtl != null)
                //{
                //    //---ADD wangyl 2013/02/06 Redmine#34578------>>>>>
                //    // システム区分が3:一括 の場合にのみ、倉庫コードで比較
                //    if (xDtl.SystemDivCd == 3)
                //    {
                //        ret = xDtl.WarehouseCode.CompareTo(yDtl.WarehouseCode);
                //        //---ADD wangyl 2013/02/26 Redmine#34578------<<<<<
                //        if (ret == 0)
                //        {
                //            ret = xDtl.UOESupplierCd.CompareTo(yDtl.UOESupplierCd);
                //        }
                //        //---ADD wangyl 2013/02/26 Redmine#34578------>>>>>
                //    }
                //    //---ADD wangyl 2013/02/06 Redmine#34578------<<<<<
                //    //---DEL wangyl 2013/02/06 Redmine#34578------>>>>>
                //    //// システム区分が 2:検索 3:一括 の場合にのみ、UOE発注先コードで比較
                //    //if (xDtl.SystemDivCd == 2 || xDtl.SystemDivCd == 3)
                //    //{
                //    //    ret = xDtl.UOESupplierCd.CompareTo(yDtl.UOESupplierCd);
                //    //}
                //    //---DEL wangyl 2013/02/06 Redmine#34578------<<<<<
                //    //---ADD wangyl 2013/02/06 Redmine#34578------>>>>>
                //    // システム区分が 2:検索の場合にのみ、UOE発注先コードで比較
                //    if (xDtl.SystemDivCd == 2)
                //    {
                //        ret = xDtl.UOESupplierCd.CompareTo(yDtl.UOESupplierCd);
                //    }
                //    //---ADD wangyl 2013/02/06 Redmine#34578------<<<<<
                //    if (ret == 0)
                //    {
                //        // オンライン行番号で比較
                //        ret = xDtl.OnlineRowNo.CompareTo(yDtl.OnlineRowNo);
                //        //---DEL wangyl 2013/02/26 Redmine#34578------<<<<<
                //        ////---ADD wangyl 2013/02/06 Redmine#34578------<<<<<
                //        //if (xDtl.SystemDivCd == 3)
                //        //{
                //        //    ret = xDtl.UOESupplierCd.CompareTo(yDtl.UOESupplierCd);
                //        //}
                //        ////---ADD wangyl 2013/02/06 Redmine#34578------>>>>>
                //        //---DEL wangyl 2013/02/26 Redmine#34578------>>>>>
                //    }
                //}
                #endregion

                #region ADD wuyk 2013/08/19 Redmine#39934
                if (ret == 0 && xDtl != null)
                {
                    // UOE種別(0:UOE 1:卸商仕入受信) 
                    if (_uoeKind == 1)
                    {
                        // システム区分が 2:検索 3:一括 の場合、UOE発注先コードで比較
                        if (xDtl.SystemDivCd == 2 || xDtl.SystemDivCd == 3)
                        {
                            ret = xDtl.UOESupplierCd.CompareTo(yDtl.UOESupplierCd);
                        }

                        if (ret == 0)
                        {
                            // オンライン行番号で比較
                            ret = xDtl.OnlineRowNo.CompareTo(yDtl.OnlineRowNo);
                        }
                    }
                    else
                    {
                        // システム区分が3:一括 の場合、倉庫コード、UOE発注先コードで比較
                        if (xDtl.SystemDivCd == 3)
                        {
                            ret = xDtl.WarehouseCode.CompareTo(yDtl.WarehouseCode);
                            if (ret == 0)
                            {
                                ret = xDtl.UOESupplierCd.CompareTo(yDtl.UOESupplierCd);
                            }
                        }

                        // システム区分が 2:検索の場合、UOE発注先コードで比較
                        if (xDtl.SystemDivCd == 2)
                        {
                            ret = xDtl.UOESupplierCd.CompareTo(yDtl.UOESupplierCd);
                        }

                        if (ret == 0)
                        {
                            // オンライン行番号で比較
                            ret = xDtl.OnlineRowNo.CompareTo(yDtl.OnlineRowNo);
                        }
                    }
                }
                #endregion

                return ret;
            }
        }

        # endregion

        # region [UOE発注番号採番処理]

        /// <summary>
        /// UOE発注番号設定処理
        /// </summary>
        /// <param name="UoeOdrDtlList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int NumberingOfUOESalesOrderNo(ref ArrayList UoeOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (ListUtils.IsNotEmpty(UoeOdrDtlList))
            {
                UOEOrderDtlWork UOEOdrDtl = ListUtils.Find(UoeOdrDtlList, typeof(UOEOrderDtlWork), ListUtils.FindType.Class) as UOEOrderDtlWork;

                if (UOEOdrDtl != null)
                {
                    // UOE発注番号採番用に並び替えを行う
                    UoeOdrDtlList.Sort(new SalesOrderNoComparer());

                    int savUOESupplierCd = 0;       // UOE発注先コード
                    int savOnlineNo = 0;            // オンライン番号
                    int savMaxRowCnt = 1;           // 送信可能最大明細行数

                    int valUOESalesOrderNo = 0;     // UOE発注番号
                    int valUOESalesOrderRowNo = 0;  // UOE発注行番号

                    // 並び替えをしたUOE発注データのリストを、UOE発注先コードとオンライン番号をブレークキーとし
                    // 更に通信アセンブリIDに関連付けられる最大明細行数毎にUOE発注番号とUOE発注行番号を設定する
                    for (int idx = 0; idx < UoeOdrDtlList.Count; idx++)
                    {
                        UOEOdrDtl = UoeOdrDtlList[idx] as UOEOrderDtlWork;

                        if (UOEOdrDtl != null)
                        {
                            // 送信可能最大明細行数の取得
                            savMaxRowCnt = (int)this._ComAsmIdToMaxDtlCntTable[UOEOdrDtl.CommAssemblyId];

                            // 前回保持分のUOE発注先コードやオンライン番号が異なる場合に
                            // UOE発注番号を採番する
                            if (savUOESupplierCd != UOEOdrDtl.UOESupplierCd ||
                                savOnlineNo != UOEOdrDtl.OnlineNo ||
                                savMaxRowCnt <= valUOESalesOrderRowNo)
                            {
                                savUOESupplierCd = UOEOdrDtl.UOESupplierCd;
                                savOnlineNo = UOEOdrDtl.OnlineNo;
                                valUOESalesOrderRowNo = 0;

                                // UOE発注番号の採番
                                status = this.CreateUOESalesOrderNo(UOEOdrDtl, out valUOESalesOrderNo, ref sqlConnection, ref sqlTransaction);

                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    break;  // → 採番に失敗したら処理終了
                                }
                            }

                            // UOE発注先コードとオンライン番号が同値で、且つ送信可能最大明細行数以下の間
                            // 同じUOE発注番号を設定する
                            UOEOdrDtl.UOESalesOrderNo = valUOESalesOrderNo;

                            // UOE発注行番号を増加した後に設定する
                            valUOESalesOrderRowNo++;
                            UOEOdrDtl.UOESalesOrderRowNo = valUOESalesOrderRowNo;
                        }
                    }
                }
            }

            return status;
        }

        #region ADD 2013/04/3 Redmine#35210 wangl2 for No.1802の対応
        /// <summary>
        /// UOE発注番号設定処理
        /// </summary>
        /// <param name="UoeOdrDtlList"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int NumberingOfUOESalesOrderNoForStockEstmt(ref ArrayList UoeOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (ListUtils.IsNotEmpty(UoeOdrDtlList))
            {
                UOEOrderDtlWork UOEOdrDtl = ListUtils.Find(UoeOdrDtlList, typeof(UOEOrderDtlWork), ListUtils.FindType.Class) as UOEOrderDtlWork;

                if (UOEOdrDtl != null)
                {
                    int valUOESalesOrderNo = 0;     // UOE発注番号
                    int uOESalesOrderNo = 0;
                    for (int idx = 0; idx < UoeOdrDtlList.Count; idx++)
                    {
                        UOEOdrDtl = UoeOdrDtlList[idx] as UOEOrderDtlWork;

                        if (UOEOdrDtl != null)
                        {
                            
                            // UOE発注番号を採番する
                            if (valUOESalesOrderNo != UOEOdrDtl.UOESalesOrderNo)
                            {
                                valUOESalesOrderNo = UOEOdrDtl.UOESalesOrderNo;
                                // UOE発注番号の採番
                                status = this.CreateUOESalesOrderNo(UOEOdrDtl, out uOESalesOrderNo, ref sqlConnection, ref sqlTransaction);

                                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    break;  // → 採番に失敗したら処理終了
                                }
                            }

                            // 同じUOE発注番号を設定する
                            UOEOdrDtl.UOESalesOrderNo = uOESalesOrderNo;
                        }
                    }
                }
            }

            return status;
        }


        # region ＵＯＥ発注行番号の最大値取得
        /// <summary>
        /// ＵＯＥ発注行番号の最大値取得
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリＩＤ</param>
        /// <param name="businessCode">業務区分</param>
        /// <returns>ＵＯＥ発注行番号の最大値</returns>
        private int GetMaxOrderRowNo(string commAssemblyId, int businessCode)
        {
            int maxOrderRowNo = 0;

            //発注
            if (businessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
            {
                switch (commAssemblyId)
                {
                    case EnumUoeConst.ctCommAssemblyId_0102://トヨタ
                        maxOrderRowNo = 3;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0202://ニッサン
                        maxOrderRowNo = 4;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0301://ミツビシ
                        maxOrderRowNo = 3;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0401://旧マツダ
                        maxOrderRowNo = 6;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0402://新マツダ
                        maxOrderRowNo = 6;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0501://ホンダ
                        maxOrderRowNo = 10;
                        break;
                    default:                                //優良メーカー
                        maxOrderRowNo = 5;
                        break;
                }
            }
            //見積
            else if (businessCode == (int)EnumUoeConst.TerminalDiv.ct_Estmt)
            {
                switch (commAssemblyId)
                {
                    case EnumUoeConst.ctCommAssemblyId_0102://トヨタ
                    case EnumUoeConst.ctCommAssemblyId_0202://ニッサン
                    case EnumUoeConst.ctCommAssemblyId_0301://ミツビシ
                    case EnumUoeConst.ctCommAssemblyId_0401://旧マツダ
                    case EnumUoeConst.ctCommAssemblyId_0402://新マツダ
                    case EnumUoeConst.ctCommAssemblyId_0501://ホンダ
                        maxOrderRowNo = 10;
                        break;
                    default:                                //優良メーカー
                        maxOrderRowNo = 0;
                        break;
                }
            }
            //在庫
            else if (businessCode == (int)EnumUoeConst.TerminalDiv.ct_Stock)
            {
                switch (commAssemblyId)
                {
                    case EnumUoeConst.ctCommAssemblyId_0102://トヨタ
                        maxOrderRowNo = 6;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0202://ニッサン
                        maxOrderRowNo = 5;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0301://ミツビシ
                        maxOrderRowNo = 6;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0401://旧マツダ
                        maxOrderRowNo = 15;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0402://新マツダ
                        maxOrderRowNo = 5;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0501://ホンダ
                        maxOrderRowNo = 15;
                        break;
                    default:                                //優良メーカー
                        maxOrderRowNo = 5;
                        break;
                }
            }
            return (maxOrderRowNo);
        }
        #endregion
        #endregion
        /// <summary>
        /// UOE発注番号採番処理
        /// </summary>
        /// <param name="keyItem"></param>
        /// <param name="uoeSalesOrderNo"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int CreateUOESalesOrderNo(UOEOrderDtlWork keyItem, out int uoeSalesOrderNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //戻り値初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            uoeSalesOrderNo = 0;

            //番号範囲分ループ
            Int32 loopCnt = 1;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
            string enterpriseCode = keyItem.EnterpriseCode;
            string sectionCode = "000000";

            long no = 0;

            # region [SELECT文]
            string sqlText = string.Empty;
            sqlText += "SELECT" + Environment.NewLine;
            sqlText += "  UOE.UOESALESORDERNORF" + Environment.NewLine;
            sqlText += "FROM" + Environment.NewLine;
            sqlText += "  UOEORDERDTLRF AS UOE" + Environment.NewLine;
            sqlText += "WHERE" + Environment.NewLine;
            sqlText += "  UOE.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "  AND UOE.UOESALESORDERNORF = @FINDUOESALESORDERNO" + Environment.NewLine;
            # endregion

            SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findUOESalesOrderNo = sqlCommand.Parameters.Add("@FINDUOESALESORDERNO", SqlDbType.Int);

            SqlDataReader myReader = null;

            try
            {
                # region [番号の取得・空き番号の確認処理]
                while (loopCnt <= 999999999)
                {
                    //オンライン番号は拠点管理有り
                    status = NumMng.GetSerialNumber(enterpriseCode, sectionCode, SerialNumberCode.UOESalesOrderNo, out no);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //採番できなかった場合には処理中断。
                        break;
                    }
                    else
                    {
                        //空き番のチェックを行う
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                        //番号を数値型に変換
                        Int32 tmpUOESalesOrderNo = System.Convert.ToInt32(no);

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                        findUOESalesOrderNo.Value = SqlDataMediator.SqlSetInt32(tmpUOESalesOrderNo);

                        if (myReader != null && !myReader.IsClosed)
                        {
                            myReader.Close();
                            myReader.Dispose();
                        }

                        myReader = sqlCommand.ExecuteReader();

                        //データ無しの場合には戻り値をセット
                        if (!myReader.Read())
                        {
                            uoeSalesOrderNo = tmpUOESalesOrderNo;
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        }
                    }

                    //同一番号がある場合にはループカウンタをインクリメントし再採番
                    loopCnt++;
                }
                # endregion              xmpp

                //全件ループしても取得出来ない場合
                if (loopCnt == 999999999 && status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    errmsg += ": UOE発注番号に空き番号が有りません.";
                    base.WriteErrorLog(errmsg, status);
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            //エラーでもステータス及びメッセージはそのまま戻す
            return status;
        }

        /// <summary>
        /// UOE発注番号採番用並び替え処理
        /// </summary>
        private class SalesOrderNoComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UOEOrderDtlWork xDtl = x as UOEOrderDtlWork;
                UOEOrderDtlWork yDtl = y as UOEOrderDtlWork;
                int ret = (xDtl == null ? 0 : 1) - (yDtl == null ? 0 : 1);

                if (ret == 0 && xDtl != null)
                {
                    // UOE発注先コードで比較
                    ret = xDtl.UOESupplierCd.CompareTo(yDtl.UOESupplierCd);

                    if (ret == 0)
                    {
                        // オンライン番号で比較
                        ret = xDtl.OnlineNo.CompareTo(yDtl.OnlineNo);
                    }

                    if (ret == 0)
                    {
                        // オンライン行番号で比較
                        ret = xDtl.OnlineRowNo.CompareTo(yDtl.OnlineRowNo);
                    }
                }

                return ret;
            }
        }

        # endregion

        private class DtlRelationGuidComp : IComparer
        {
            public int Compare(object x, object y)
            {
                Guid xGuid = Guid.Empty;
                Guid yGuid = Guid.Empty;

                if (x is StockDetailWork)
                {
                    xGuid = (x as StockDetailWork).DtlRelationGuid;
                }
                else if (x is UOEOrderDtlWork)
                {
                    xGuid = (x as UOEOrderDtlWork).DtlRelationGuid;
                }

                if (y is StockDetailWork)
                {
                    yGuid = (y as StockDetailWork).DtlRelationGuid;
                }
                else if (y is UOEOrderDtlWork)
                {
                    yGuid = (y as UOEOrderDtlWork).DtlRelationGuid;
                }

                return xGuid.CompareTo(yGuid);
            }
        }

# if false
        # region [Read]
        /// <summary>
        /// 単一のUOE発注用I/OWrite情報を取得します。
        /// </summary>
        /// <param name="ioWriteUOEOdrDtlObj">IOWriteUOEOdrDtlWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE発注用I/OWriteのキー値が一致するUOE発注用I/OWrite情報を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        public int Read(ref object ioWriteUOEOdrDtlObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                IOWriteUOEOdrDtlWork ioWriteUOEOdrDtlWork = ioWriteUOEOdrDtlObj as IOWriteUOEOdrDtlWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref ioWriteUOEOdrDtlWork, readMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// 単一のUOE発注用I/OWrite情報を取得します。
        /// </summary>
        /// <param name="ioWriteUOEOdrDtlWork">IOWriteUOEOdrDtlWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE発注用I/OWriteのキー値が一致するUOE発注用I/OWrite情報を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        public int Read(ref IOWriteUOEOdrDtlWork ioWriteUOEOdrDtlWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref ioWriteUOEOdrDtlWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一のUOE発注用I/OWrite情報を取得します。
        /// </summary>
        /// <param name="ioWriteUOEOdrDtlWork">IOWriteUOEOdrDtlWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE発注用I/OWriteのキー値が一致するUOE発注用I/OWrite情報を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        private int ReadProc(ref IOWriteUOEOdrDtlWork ioWriteUOEOdrDtlWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

        # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  *" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  IOWRITEUOEODRDTLRF" + Environment.NewLine;
                sqlText += "" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
        # endregion

                // Prameterオブジェクトの作成
                

                // Parameterオブジェクトへ値設定
                

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToIOWriteUOEOdrDtlWorkFromReader(ref myReader, ref ioWriteUOEOdrDtlWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
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
        # endregion

        # region [Delete]
        /// <summary>
        /// UOE発注用I/OWrite情報を物理削除します
        /// </summary>
        /// <param name="uoeOdrDtlList">物理削除するUOE発注用I/OWrite情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE発注用I/OWriteのキー値が一致するUOE発注用I/OWrite情報を物理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        public int Delete(object ioWriteUOEOdrDtlList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = ioWriteUOEOdrDtlList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// UOE発注用I/OWrite情報を物理削除します
        /// </summary>
        /// <param name="uoeOdrDtlList">UOE発注用I/OWrite情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList に格納されているUOE発注用I/OWrite情報を物理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        public int Delete(ArrayList ioWriteUOEOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(ioWriteUOEOdrDtlList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// UOE発注用I/OWrite情報を物理削除します
        /// </summary>
        /// <param name="uoeOdrDtlList">UOE発注用I/OWrite情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOdrDtlList に格納されているUOE発注用I/OWrite情報を物理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        private int DeleteProc(ArrayList ioWriteUOEOdrDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (ioWriteUOEOdrDtlList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < ioWriteUOEOdrDtlList.Count; i++)
                    {
                        IOWriteUOEOdrDtlWork ioWriteUOEOdrDtlWork = ioWriteUOEOdrDtlList[i] as IOWriteUOEOdrDtlWork;

        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  IOWRITEUOEODRDTLRF" + Environment.NewLine;
                        sqlText += "" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        

                        // Parameterオブジェクトへ値設定
                        

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != ioWriteUOEOdrDtlWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

        # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  IOWRITEUOEODRDTLRF" + Environment.NewLine;
                            sqlText += "" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
        # endregion

                            // KEYコマンドを再設定
                            
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
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
        # endregion


        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="ioWriteUOEOdrDtlWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, IOWriteUOEOdrDtlWork ioWriteUOEOdrDtlWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // 企業コード
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(ioWriteUOEOdrDtlWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            

            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → IOWriteUOEOdrDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>IOWriteUOEOdrDtlWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        /// </remarks>
        private IOWriteUOEOdrDtlWork CopyToIOWriteUOEOdrDtlWorkFromReader(ref SqlDataReader myReader)
        {
            IOWriteUOEOdrDtlWork ioWriteUOEOdrDtlWork = new IOWriteUOEOdrDtlWork();

            this.CopyToIOWriteUOEOdrDtlWorkFromReader(ref myReader, ref ioWriteUOEOdrDtlWork);

            return ioWriteUOEOdrDtlWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → IOWriteUOEOdrDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="ioWriteUOEOdrDtlWork">IOWriteUOEOdrDtlWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.09.22</br>
        /// </remarks>
        private void CopyToIOWriteUOEOdrDtlWorkFromReader(ref SqlDataReader myReader, ref IOWriteUOEOdrDtlWork ioWriteUOEOdrDtlWork)
        {
            if (myReader != null && ioWriteUOEOdrDtlWork != null)
            {
        # region クラスへ格納
                
        # endregion
            }
        }
        # endregion

# endif

    }
}
