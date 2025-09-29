//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   コンバート処理 リモートオブジェクト
//                  :   PMKHN08003R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   30290
// Date             :   2008.09.22
//----------------------------------------------------------------------
// Update Note      : 
// 管理番号  10704766-00 作成担当 : wangf
// 修 正 日  2011/08/12  修正内容 : NSユーザー改良要望一覧_20110629_障害_連番1023対応
// 管理番号  10704766-00 作成担当 : wangf
// 修 正 日  2011/08/19  修正内容 : NSユーザー改良要望一覧_20110629_障害_連番953対応
// 管理番号  10704766-00 作成担当 : 鄧潘ハン
// 修 正 日  2011/08/22  修正内容 : NSユーザー改良要望一覧_20110629_障害_連番938対応
// 管理番号  10704766-00 作成担当 : wangf
// 修 正 日  2011/08/30  修正内容 : NSユーザー改良要望一覧_20110629_障害_連番943対応
// 管理番号  10704766-00 作成担当 : 李占川
// 修 正 日  2011/09/06  修正内容 : 連番991、Redmine#23658の対応
// 管理番号              作成担当 : 王君
// 修 正 日  2012/11/05  修正内容 : No.892 Redmine#32201の対応
// 管理番号              作成担当 : Lizc
// 修 正 日  2013/07/01  修正内容 : No.2007 Redmine#36971の対応
// 管理番号  11170129-00 作成担当 : gongzc
// 修 正 日  2015/08/27  修正内容 : Redmine#47009 【№271】NS側在庫仕入データコンバートの障害対応
// 管理番号  11370032-00 作成担当 : 田建委
// 修 正 日  2019/10/22  修正内容 : SQLSERVER2017対応
// 管理番号  11670219-00 作成担当 : 佐々木亘
// 修 正 日  2020/06/18  修正内容 : ＥＢＥ対策
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
// DEL Lizc 2013/07/01 Redmine#36971 ----->>>>>
//using MSMC = Microsoft.SqlServer.Management.Common;
//using Microsoft.SqlServer.Management.Smo;
//using Microsoft.SqlServer.Server;
// DEL Lizc 2013/07/01 Redmine#36971 -----<<<<<
using Microsoft.SqlServer.Server;// ADD　2019/10/22 田建委 SQLSERVER2017対応
using Microsoft.Win32;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Text;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

using System.Runtime.Remoting.Lifetime;

// 2009/02/27 SQL Server認証変更対応>>>>>>
using CustomInstaller;
using UBAU.Common;
// 2009/02/27 <<<<<<<<<<<<<<<<<<<<<<<<<<<<
using Broadleaf.Application.Remoting.Adapter; // add wangf 2011/08/12
// --- DEL　2019/10/22 田建委 SQLSERVER2017対応---------->>>>>
//using System.Reflection; // ADD Lizc 2013/07/01 Redmine#36971
// --- DEL　2019/10/22 田建委 SQLSERVER2017対応----------<<<<<

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// コンバート処理 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート処理実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.22</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   在庫移動データからの在庫受払履歴の作成方法の変更</br>
    /// <br>Programmer       :   22008 長内</br>
    /// <br>Date             :   2009/06/19</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 13645 在庫マスタ 管理区分"0"がNULLになる不具合の修正</br>
    /// <br>                     ※列のインデックスにて、管理区分の列を判断しているため、</br>
    /// <br>                     　３４行より前に在庫マスタの列追加があった場合はインデックスの修正をする必要あり</br>
    /// <br>Programmer       :   22008 長内</br>
    /// <br>Date             :   2009/06/29</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 14369 車両管理マスタ 配列バイナリがNULLになる不具合の修正</br>
    /// <br>Programmer       :   97427 花原</br>
    /// <br>Date             :   2009/10/05</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 13967 品番の最初が,だとエラーになる不具合の修正</br>
    /// <br>Programmer       :   30517 夏野 駿希</br>
    /// <br>Date             :   2009/11/09</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 14529 CSV元データがなくてもクリア処理をするように修正</br>
    /// <br>Programmer       :   30517 夏野 駿希</br>
    /// <br>Date             :   2009/11/17</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 13966 全角空白を半角空白２桁に変換するように修正する</br>
    /// <br>Programmer       :   22008 長内 数馬</br>
    /// <br>Date             :   2010/01/28</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 15150 濁点、半濁音符で始まる文字列の対応処理を追加</br>
    /// <br>Programmer       :   980035 金沢 貞義</br>
    /// <br>Date             :   2010/03/16</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS xxxxx 全角文字を半角文字＋半角空白に変換するように修正する</br>
    /// <br>                     データの多い処理に売上履歴データ、受注マスタ、受注マスタ（車両）を追加</br>
    /// <br>Programmer       :   980035 金沢 貞義</br>
    /// <br>Date             :   2010/04/28</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 15742 自由検索型式マスタ　キー項目がNULLの時、エラーになる不具合の対応</br>
    /// <br>Programmer       :   30531  大矢 睦美</br>
    /// <br>Date             :   2010/07/07</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 15894 データの多い処理に得意先請求金額マスタを追加</br>
    /// <br>Programmer       :   30517  夏野 駿希</br>
    /// <br>Date             :   2010/08/03</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 16068 自由検索型式固定番号配列のセット値をNULLに変更</br>
    /// <br>Programmer       :   980035 金沢 貞義</br>
    /// <br>Date             :   2010/09/16</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 16007 在庫移動受払作成時、移動中のデータも入荷済みになる不具合修正</br>
    /// <br>Programmer       :   30517 夏野 駿希</br>
    /// <br>Date             :   2010/09/17</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 16007 フィードバック：入荷確定無しで在庫移動受払作成時、</br>
    /// <br>                     入荷データから出荷データを作成する場合出荷確定日がNullとなる不具合の修正</br>
    /// <br>Programmer       :   30517 夏野 駿希</br>
    /// <br>Date             :   2010/10/05</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 16076 売上履歴の在庫受払履歴データ作成時にタイムアウトとなる件の修正</br>
    /// <br>                     タイムアウト時間を延ばして対応</br>
    /// <br>Programmer       :   30517 夏野 駿希</br>
    /// <br>Date             :   2010/10/12</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 16007 フィードバック</br>
    /// <br>                     ①在庫移動受払：再コンバート時、コンバート前後で入力拠点が異なるデータがある</br>
    /// <br>                     ②再コンバート時、論理削除データが存在する時、対になるマイナスデータが作成されない</br>
    /// <br>Programmer       :   30517 夏野 駿希</br>
    /// <br>Date             :   2010/10/13</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   MANTIS 16007 フィードバック</br>
    /// <br>                     ①再コンバート時、論理削除データが存在する時、対になるマイナスデータが作成されない（在庫調整データ）</br>
    /// <br>                     ②貸出計上のデータがある場合、コンバート前後で受払の作成仕様が異なる為修正する。</br>
    /// <br>Programmer       :   30517 夏野 駿希</br>
    /// <br>Date             :   2010/10/20</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   </br>
    /// <br>                     NSユーザー改良要望一覧_20110629_障害_連番1023対応</br>
    /// <br>Programmer       :   wangf</br>
    /// <br>Date             :   2011/08/12</br>
    /// <br>--------------------------------------</br>
    /// <br>                     NSユーザー改良要望一覧_20110629_障害_連番953対応</br>
    /// <br>Programmer       :   wangf</br>
    /// <br>Date             :   2011/08/19</br>
    /// <br>Update Note      :   NSユーザー改良要望一覧_20110629_障害_連番938対応</br>
    /// <br>Programmer       :   鄧潘ハン</br>
    /// <br>Date             :   2011/08/25</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   </br>
    /// <br>                     NSユーザー改良要望一覧_20110629_障害_連番943対応</br>
    /// <br>Programmer       :   wangf</br>
    /// <br>Date             :   2011/08/30</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   </br>
    /// <br>                     redmine#24171</br>
    /// <br>Programmer       :   tianjw</br>
    /// <br>Date             :   2011/09/03</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   連番991、Redmine#23658の対応</br>
    /// <br>Programmer       :   李占川</br>
    /// <br>Date             :   2011/09/06</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   管理№10701342-00　キャンペーン管理</br>
    /// <br>                     キャンペーン管理マスタでBL+ﾒｰｶｰの場合に品番NULLでエラーにならないように修正</br>
    /// <br>Programmer       :   97427 花原</br>
    /// <br>Date             :   2011/07/13</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   大量データが存在するテーブルに対して、追加型でINSERTした場合に</br>
    /// <br>                 :   タイムアウトエラーが発生する件の修正（イスコで発生）</br>
    /// <br>Programmer       :   長内 数馬</br>
    /// <br>Date             :   2011/09/29</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   データの多い処理に仕入履歴データ・仕入履歴明細データを追加</br>
    /// <br>Programmer       :   夏野 駿希</br>
    /// <br>Date             :   2012/02/15</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   データの多い処理に在庫履歴データを追加</br>
    /// <br>Programmer       :   夏野 駿希</br>
    /// <br>Date             :   2012/02/20</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   在庫受払履歴データ作成時にタイムアウトとなる件の修正</br>
    /// <br>                     タイムアウト時間を延ばして対応</br>
    /// <br>Programmer       :   97427 花原</br>
    /// <br>Date             :   2012/04/27</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   Redmine#32201の対応</br>
    /// <br>                     全体初期設定の対応</br>
    /// <br>Programmer       :   王君</br>
    /// <br>Date             :   2012/11/05</br>
    /// <br>Update Note      :   Redmine#36971の対応</br>
    /// <br>                     仕掛№2007 コンバートプログラムのSQLSERVER2012対応</br>
    /// <br>Programmer       :   Lizc</br>
    /// <br>Date             :   2013/07/01</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   Redmine#47009 【№271】NS側在庫仕入データコンバートの障害対応</br>
    /// <br>Programmer       :   gongzc</br>
    /// <br>Date             :   2015/08/27</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   SQLSERVER2017対応</br>
    /// <br>Programmer       :   田建委</br>
    /// <br>Date             :   2019/10/22</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   11670219-00　ＥＢＥ対策</br>
    /// <br>Programmer       :   佐々木亘</br>
    /// <br>Date             :   2020/06/18</br>
    /// </remarks>

    [Serializable]
    public class ConvertProcessDB : RemoteWithAppLockDB, IConvertProcessDB
    {
        #region [ PRIVATE MEMBER ]

        // ----- DEL Lizc 2013/07/01 Redmine#36971----->>>>>
        //private MSMC.ServerConnection srvCon;
        //private Server serv;
        // ----- DEL Lizc 2013/07/01 Redmine#36971-----<<<<<
        // --- DEL　2019/10/22 田建委 SQLSERVER2017対応---------->>>>>
        //// ----- ADD Lizc 2013/07/01 Redmine#36971----->>>>>
        //private Type srvCon;
        //private Type serv;
        //private object servObj;
        //// ----- ADD Lizc 2013/07/01 Redmine#36971-----<<<<<
        // --- DEL　2019/10/22 田建委 SQLSERVER2017対応----------<<<<<
        private SqlConnection sqlConnection;
        private SqlTransaction sqlTransaction;
        private SqlDataAdapter da;
        //private string _tblId;// DEL　2019/10/22 田建委 SQLSERVER2017対応

        private bool onProcess = false;
        private bool stopFlg = false;
        private bool transactionFlg = false;

        private string _enterpriseCode = string.Empty;
        private string _updEmployeeCode = string.Empty;
        private string _updAssemblyId1 = string.Empty;
        private string _updAssemblyId2 = string.Empty;
        private const string ctConfFileNm = "ConvertSetting.xml";
        private const string ctDDTable = "DDSet";
        private const string ctColDfTable = "ColumnDf";
        private const string ctItemName = "ItemName";
        private const string ctItemDDName = "ItemDDName";
        private const string ctColumn = "Column";
        private const string ctPadZero = "PadZero";

        private DataSet conf;
        private StockAcPayHistDB stockAcPayHistDB = null;
        private Dictionary<string, SecInfoSetWork> lstSec = null;
        private Dictionary<int, BLGoodsCdUWork> lstBLCode = null;
        //private List<StockProcMoneyWork> lstFractionInfo = null;

        /// <summary>重複例外テーブル</summary>
        private List<string> listChkExcpt;

        /// <summary>データなしを空白扱いする例外の一覧格納用</summary>
        private struct ExcptTblCol
        {
            private string tblName;  // テーブル名
            private int colNo;       // カラムNo（テーブル仕様書上の番号-1）

            /// <summary>テーブル名</summary>
            public string TblName
            {
                get { return tblName; }
                set { tblName = value; }
            }
            /// <summary>テーブル名</summary>
            public int ColNo
            {
                get { return colNo; }
                set { colNo = value; }
            }

            /// <summary>テーブル名</summary>
            public ExcptTblCol(string _tblName, int _colNo)
            {
                tblName = _tblName;
                colNo = _colNo;
            }
        }

        /// <summary>データなしを空白扱いする例外の一覧</summary>
        private List<ExcptTblCol> lstSpaceExcptTblCol;

        /// <summary>データなしを0扱いする例外の一覧</summary>
        private List<ExcptTblCol> lstSpaceZeroExcptTblCol;

        ///// <summary>0を空白扱いする例外の一覧</summary>
        //private List<ExcptTblCol> lstZeroExcptTblCol;

        /// <summary>0をNULL扱いする例外の一覧</summary>
        private List<ExcptTblCol> lstZeroNullExcptTblCol;

        /// <summary>削除しないキッティングデータの一覧</summary>
        private List<ExcptTblCol> lstKittingTblCol;

        /// <summary>大量データテーブルの一覧</summary>
        private List<string> lstDataFullTbl;

        // ADD BY gongzc 2015/08/27 FOR Redmine#47009 【№271】NS側在庫仕入データコンバートの障害対応 ---->>>>
        // 0をNULLにコンバートしない例外の一覧
        private List<ExcptTblCol> lstNotConvrtZeroToNullExcptTblCol;
        // ADD BY gongzc 2015/08/27 FOR Redmine#47009 【№271】NS側在庫仕入データコンバートの障害対応 ----<<<<

        // -- ADD 2010/04/28 ------------------------------>>>
        /// <summary>全角文字チェック対象の一覧</summary>
        private List<string> lstFullSizeCheckTbl;
        // -- ADD 2010/04/28 ------------------------------<<<
        // -- add wangf 2011/08/12 ---------->>>>>
        /// <summary>リモートオブジェクト格納バッファ</summary>
        //private StockSlipDB _stockSlipDB = null; // DEL tianjw 2011/09/03
        private AcceptOdrDB _acceptOdr = null;
        private Hashtable _acceptAnOrderNoHashTable = new Hashtable();
        // -- add wangf 2011/08/12 ----------<<<<<
        private Hashtable _hisDtlAcceptAnOrderNoHashTable = new Hashtable(); // ADD tianjw 2011/09/03

        private OprtnHisLogDB _oprtnHisLogDB = new OprtnHisLogDB(); // ADD 2011/09/06
        #endregion

        #region [ Constructor / Destructor ]
        //private static int cnt;
        /// <summary>
        /// コンバート処理DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>Update Note: NSユーザー改良要望一覧_20110629_障害_連番938対応</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/08/25</br>
        /// <br>Update Note: NSユーザー改良要望一覧_20110629_障害_連番943対応</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2011/08/30</br>
        /// <br>Update Note: 仕掛№2007 コンバートプログラムのSQLSERVER2012対応</br>
        /// <br>Programmer : Lizc</br>
        /// <br>Date       : 2013/07/01</br>
        /// <br>Update Note: PMKOBETSU-2232 SQLSERVER2017対応</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/10/22</br>
        /// </remarks>
        public ConvertProcessDB()
            : base("PMKHN08005D", "Broadleaf.Application.Remoting.ParamData.ConvertResultWork", "ConvertProcess")
        {
            // --- DEL　2019/10/22 田建委 SQLSERVER2017対応---------->>>>>
            //srvCon = null;
            //serv = null;
            //servObj = null; // ADD Lizc 2013/07/01 Redmine#36971
            // --- DEL　2019/10/22 田建委 SQLSERVER2017対応----------<<<<<
            sqlConnection = null;
            sqlTransaction = null;
            da = null;
            //_tblId = string.Empty;// DEL　2019/10/22 田建委 SQLSERVER2017対応
            // -- add wangf 2011/08/12 ---------->>>>>
            // リモートオブジェクト取得
            //this._stockSlipDB = new StockSlipDB(); // DEL tianjw 2011/09/03
            this._acceptOdr = new AcceptOdrDB();
            // -- add wangf 2011/08/12 ---------->>>>>

            //cnt++;
            //System.Diagnostics.Debug.Write("Constructor");
            //System.Diagnostics.Debug.Write(string.Format("回数:{0}\n", cnt));

            conf = new DataSet();
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            string path = key.GetValue("InstallDirectory", @"d:\Partsman\USER_AP").ToString();
            conf.ReadXml(System.IO.Path.Combine(path, ctConfFileNm));
            conf.Tables[ctColDfTable].Constraints.Add("c1", conf.Tables[ctColDfTable].Columns[ctItemName], true);
            conf.Tables[ctDDTable].Constraints.Add("c2", conf.Tables[ctDDTable].Columns[ctItemDDName], true);

            listChkExcpt = new List<string>(
                new string[] {
                    "USERGDBDURF",      // ユーザーガイド(銀行の支店コードによる重複するケース）
                    "PARTSPOSCODEURF",  // 部位（BLコードが例外的に重複するケース）
                    "JOINPARTSURF",     // 結合マスタ(ユーザー登録）（表示順位違いで結合先品が重複するケース）
                    "GOODSSETRF"        // 商品セットマスタ（表示順位違いでセット子が重複するケース）
                });

            // データなしを空白扱いする例外の一覧作成
            lstSpaceExcptTblCol = new List<ExcptTblCol>(
                new ExcptTblCol[] {
                     new ExcptTblCol("PARTSPOSCODEURF", 8)    //  部位コードマスタテーブル 拠点コードカラム
                    ,new ExcptTblCol("GOODSMNGRF", 12)        //  商品管理情報マスタテーブル 商品番号カラム
                    ,new ExcptTblCol("CUSTDMDPRCRF", 13)      //  得意先請求金額マスタテーブル 実績拠点コードカラム
                    ,new ExcptTblCol("RATERF", 17)            //  掛率マスタテーブル 商品番号カラム
                    ,new ExcptTblCol("RATERF", 18)            //  掛率マスタテーブル 商品掛率ランクカラム
                    ,new ExcptTblCol("SUPLIERPAYRF", 13)      //  仕入先支払金額マスタテーブル 実績拠点コードカラム
                    ,new ExcptTblCol("GOODSMTTLSASLIPRF", 15) //  商品別売上月次集計データテーブル 商品番号カラム
                    ,new ExcptTblCol("GCDSALESTARGETRF", 14)  //  商品別売上目標設定マスタテーブル 商品番号カラム
                    ,new ExcptTblCol("UOEGUIDENAMERF", 11)    //  UOEガイド名称マスタテーブル UOEガイドコードカラム
                    ,new ExcptTblCol("EMPSALESTARGETRF", 15)  //  従業員別売上目標設定マスタテーブル 従業員コードカラム
                    // --- ADD  大矢睦美  2010/07/07 ---------->>>>>
                    ,new ExcptTblCol("FREESEARCHMODELRF", 12) //  自由検索型式マスタテーブル 排ガス記号カラム
                    ,new ExcptTblCol("FREESEARCHMODELRF", 14) //  自由検索型式マスタテーブル 型式(類別記号)カラム
                    // --- ADD  大矢睦美  2010/07/07 ----------<<<<<
                    // --- ADD  2011/07/13 ---------->>>>>
                    ,new ExcptTblCol("CAMPAIGNMNGRF", 12)     //  キャンペーン管理マスタ 商品番号カラム
                    // --- ADD  2011/07/13 ----------<<<<<
                });

            // データなしを0扱いする例外の一覧
            lstSpaceZeroExcptTblCol = new List<ExcptTblCol>(
                new ExcptTblCol[] {
                     new ExcptTblCol("CUSTDMDPRCRF", 14)   //  得意先請求金額マスタテーブル 得意先コードカラム
                    ,new ExcptTblCol("SUPLIERPAYRF", 14)   //  仕入先支払金額マスタテーブル 仕入先コードカラム
                });

            //// 0を空白扱いする例外の一覧作成
            //lstZeroExcptTblCol = new List<ExcptTblCol>(
            //    new ExcptTblCol[] {
            //        new ExcptTblCol("PARTSPOSCODEURF", 8)   //  部位コードマスタテーブル 拠点コードカラム
            //    });

            // 0をNULL扱いする例外の一覧作成
            lstZeroNullExcptTblCol = new List<ExcptTblCol>(
                new ExcptTblCol[] {
                     new ExcptTblCol("SALESDETAILRF", 15)     //  売上明細データテーブル 売上日付カラム
                    ,new ExcptTblCol("SALESDETAILRF", 23)     //  売上明細データテーブル 納品完了予定日カラム
                    ,new ExcptTblCol("SALESDETAILRF", 42)     //  売上明細データテーブル 倉庫コードカラム
                    ,new ExcptTblCol("SALESHISTORYRF", 104)   //  売上履歴データテーブル ＥＤＩ送信日カラム
                    ,new ExcptTblCol("SALESHISTORYRF", 105)   //  売上履歴データテーブル ＥＤＩ取込日カラム
                    ,new ExcptTblCol("SALESHISTDTLRF", 40)    //  売上履歴明細データテーブル 倉庫コードカラム
                    ,new ExcptTblCol("SALESSLIPRF", 24)       //  売上データテーブル 売上日付カラム
                    ,new ExcptTblCol("SALESSLIPRF", 25)       //  売上データテーブル 計上日付カラム
                    ,new ExcptTblCol("SALESSLIPRF", 105)      //  売上データテーブル レジ処理日カラム
                    ,new ExcptTblCol("SALESSLIPRF", 109)      //  売上データテーブル ＥＤＩ送信日カラム
                    ,new ExcptTblCol("SALESSLIPRF", 110)      //  売上データテーブル ＥＤＩ取込日カラム
                    ,new ExcptTblCol("SALESSLIPRF", 115)      //  売上データテーブル 売上伝票発行日カラム
                    ,new ExcptTblCol("STOCKSLIPRF", 72)       //  仕入データテーブル ＥＤＩ送信日カラム
                    ,new ExcptTblCol("STOCKSLIPRF", 73)       //  仕入データテーブル ＥＤＩ取込日カラム
                    ,new ExcptTblCol("STOCKSLIPRF", 78)       //  仕入データテーブル 仕入伝票発行日カラム
                    ,new ExcptTblCol("STOCKDETAILRF", 43)     //  仕入明細データテーブル 倉庫コードカラム
                    ,new ExcptTblCol("STOCKDETAILRF", 54)     //  仕入明細データテーブル 掛率設定拠点（仕入単価）カラム
                    ,new ExcptTblCol("STOCKDETAILRF", 55)     //  仕入明細データテーブル 掛率設定区分（仕入単価）カラム
                    ,new ExcptTblCol("STOCKDETAILRF", 98)     //  仕入明細データテーブル 納品完了予定日カラム
                    ,new ExcptTblCol("STOCKDETAILRF", 99)     //  仕入明細データテーブル 希望納期カラム
                    ,new ExcptTblCol("STOCKDETAILRF", 101)    //  仕入明細データテーブル 発注データ作成日カラム
                    ,new ExcptTblCol("STOCKSLIPHISTRF", 72)   //  仕入履歴データテーブル ＥＤＩ送信日カラム
                    ,new ExcptTblCol("STOCKSLIPHISTRF", 73)   //  仕入履歴データテーブル ＥＤＩ取込日カラム
                    ,new ExcptTblCol("STOCKSLIPHISTRF", 78)   //  仕入履歴データテーブル 仕入伝票発行日カラム
                    ,new ExcptTblCol("STOCKSLHISTDTLRF", 41)  //  仕入履歴明細データテーブル 倉庫コードカラム
                    ,new ExcptTblCol("STOCKSLHISTDTLRF", 52)  //  仕入履歴明細データテーブル 掛率設定拠点（仕入単価）カラム
                    ,new ExcptTblCol("STOCKSLHISTDTLRF", 53)  //  仕入履歴明細データテーブル 掛率設定区分（仕入単価）カラム
                    ,new ExcptTblCol("DEPSITMAINRF", 23)      //  入金マスタテーブル 手形振出日カラム
                    ,new ExcptTblCol("DEPSITMAINRF", 32)      //  入金マスタテーブル 最終消し込み計上日カラム
                    ,new ExcptTblCol("PAYMENTSLPRF", 31)      //  支払伝票マスタテーブル 手形振出日カラム
                    ,new ExcptTblCol("PAYMENTSLPRF", 38)      //  支払伝票マスタテーブル 支払入力者コードカラム
                    ,new ExcptTblCol("PAYMENTSLPRF", 40)      //  支払伝票マスタテーブル 支払担当者コードカラム
                    ,new ExcptTblCol("ACCEPTODRCARRF", 15)    //  受注マスタ（車両）テーブル 車両登録番号（種別）カラム
                    ,new ExcptTblCol("ACCEPTODRCARRF", 18)    //  受注マスタ（車両）テーブル 初年度カラム
                    ,new ExcptTblCol("STOCKMOVERF", 22)       //  在庫移動データテーブル 入荷日カラム
                });

            // ADD BY gongzc 2015/08/27 FOR Redmine#47009 【№271】NS側在庫仕入データコンバートの障害対応 ---->>>>
            // 0をNULLにコンバートしないテーブルの例外リスト
            lstNotConvrtZeroToNullExcptTblCol = new List<ExcptTblCol>(
               new ExcptTblCol[] {
                   new ExcptTblCol("GOODSURF", 17)          // 商品マスタ(ユーザー登録)　ハイフン無商品番号カラム
                  ,new ExcptTblCol("STOCKRF", 33)           // 在庫マスタ　部品管理区分１
                  ,new ExcptTblCol("STOCKRF", 34)           // 在庫マスタ　部品管理区分２
                  // 以降、0をNULLにコンバートしないテーブルとカラムを追加
                  ,new ExcptTblCol("STOCKRF", 29)           // 在庫マスタ　ハイフン無商品番号
                  ,new ExcptTblCol("FREESEARCHPARTSRF", 16) // 自由検索部品マスタ　ハイフン無商品番号
                  ,new ExcptTblCol("SALESDETAILRF", 29)     // 売上明細データ　商品番号
                  ,new ExcptTblCol("SALESHISTDTLRF", 27)    // 売上履歴明細データ　商品番号
                  ,new ExcptTblCol("CNVCARPARTSRF", 16)     // 車輌部品データ（コンバート）　商品番号
                  ,new ExcptTblCol("STOCKDETAILRF", 30)     // 仕入明細データ　商品番号
                  ,new ExcptTblCol("STOCKSLHISTDTLRF", 28)  // 仕入履歴明細データ　商品番号
                  ,new ExcptTblCol("STOCKMOVERF", 35)       // 在庫移動データ　商品番号
                  ,new ExcptTblCol("STOCKADJUSTDTLRF", 19)  // 在庫調整明細データ　商品番号
               });
            // ADD BY gongzc 2015/08/27 FOR Redmine#47009 【№271】NS側在庫仕入データコンバートの障害対応 ----<<<<

            // 削除しないキッティングデータの一覧作成
            lstKittingTblCol = new List<ExcptTblCol>(
                new ExcptTblCol[] {
                    new ExcptTblCol("BILLALLSTRF", 8)       //  請求全体設定マスタテーブル 拠点コードカラム
                   ,new ExcptTblCol("SALESTTLSTRF", 8)      //  売上全体設定マスタテーブル 拠点コードカラム
                   ,new ExcptTblCol("STOCKTTLSTRF", 8)      //  仕入在庫全体設定マスタテーブル 拠点コードカラム
                   ,new ExcptTblCol("STOCKMNGTTLSTRF", 8)   //  在庫全体設定マスタテーブル 拠点コードカラム
                    //2009/02/14 ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>
                   ,new ExcptTblCol("EMPLOYEERF", 8)        //  従業員設定マスタテーブル 従業員コードカラム
                   ,new ExcptTblCol("EMPLOYEEDTLRF", 8)     //  従業員詳細設定マスタテーブル 従業員コードカラム
                    //2009/02/14 ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<
                });

            // データの多いテーブルの一覧作成 (lstKittingTblColと同じ項目がないように注意)
            lstDataFullTbl = new List<string>(
                new string[] {
                    "MTTLSALESSLIPRF"    // 売上月次集計データ
                   ,"GOODSMTTLSASLIPRF"  // 商品別売上月次集計データ
                   ,"SALESHISTDTLRF"     // 売上履歴明細データ
                // -- ADD 2010/04/28 ------------------------------>>>
                   ,"SALESHISTORYRF"     // 売上履歴データ
                   ,"ACCEPTODRRF"        // 受注マスタ
                   ,"ACCEPTODRCARRF"     // 受注マスタ（車両）
                // -- ADD 2010/04/28 ------------------------------<<<
                // 2010/08/03 Add >>>
                    ,"CUSTDMDPRCRF"      // 得意先請求金額マスタ
                // 2010/08/03 Add <<<
                // 2012/02/15 Add >>>
                    ,"STOCKDETAILRF"     // 仕入明細データ
                    ,"STOCKSLIPHISTRF"   // 仕入履歴データ
                    ,"STOCKSLHISTDTLRF"  // 仕入履歴明細データ
                // 2012/02/15 Add <<<
                // 2012/02/20 Add >>>
                    ,"STOCKHISTORYRF"    // 在庫履歴データ
                // 2012/02/20 Add <<<
                });

            // -- ADD 2010/04/28 ------------------------------>>>
            // 全角文字チェック対象の一覧作成
            lstFullSizeCheckTbl = new List<string>(
                new string[] {
                    // 英字（大文字）
                    "Ａ","Ｂ","Ｃ","Ｄ","Ｅ","Ｆ","Ｇ","Ｈ","Ｉ","Ｊ","Ｋ","Ｌ","Ｍ","Ｎ","Ｏ","Ｐ","Ｑ","Ｒ","Ｓ","Ｔ","Ｕ","Ｖ","Ｗ","Ｘ","Ｙ","Ｚ"
                    // 英字（小文字）
                   ,"ａ","ｂ","ｃ","ｄ","ｅ","ｆ","ｇ","ｈ","ｉ","ｊ","ｋ","ｌ","ｍ","ｎ","ｏ","ｐ","ｑ","ｒ","ｓ","ｔ","ｕ","ｖ","ｗ","ｘ","ｙ","ｚ"
                    // 数字
                   ,"０","１","２","３","４","５","６","７","８","９"
                    //---ADD 2011/08/25 -------------------------->>>>>
                    // 全角カタカナの５０文字
                   ,"ア","イ","ウ","エ","オ","カ","キ","ク","ケ","コ"
                   ,"サ","シ","ス","セ","ソ","ナ","ニ","ヌ","ネ","ノ"
                   ,"タ","チ","ツ","テ","ト","ラ","リ","ル","レ","ロ"
                   ,"ハ","ヒ","フ","ヘ","ホ","マ","ミ","ム","メ","モ"
                   ,"ワ","ヲ","ン","ヤ","ユ","ヨ"
                　 ,"ャ","ュ","ョ","ゥ","ォ","ィ","ッ","ェ","ァ"
                　 ,"ガ","ギ","グ","ゲ","ゴ","ザ","ジ","ズ","ゼ","ゾ"
            　　　 ,"ダ","ヂ","ヅ","デ","ド","バ","ビ","ブ","ベ","ボ"
                　 ,"パ","ピ","プ","ペ","ポ"
                    // 全角記号
                  ,"‘","～","！","＠","＃","＄","％","＾","＆","＊","（","）","＿","ー","＋","＝","｛","｝","「","」","；","：","’","”","＜","＞","，","。","？","｜","￥","．","／"
                  ,"、","゜","￤"
                    //---ADD 2011/08/25 --------------------------<<<<<
                });
            // -- ADD 2010/04/28 ------------------------------<<<
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~ConvertProcessDB()
        {
            // ----- DEL 2019/10/22 田建委 SQLSERVER2017対応 ----->>>>>
            //if (srvCon != null)
            //{
            //    /* ----- DEL Lizc 2013/07/01 Redmine#36971 ----->>>>>
            //    try
            //    {
            //        if (srvCon.IsOpen)
            //            srvCon.Disconnect();
            //    }
            //    catch { }
            //    srvCon = null;
            //    ----- DEL Lizc 2013/07/01 Redmine#36971 -----<<<<<*/

            //    // ----- DEL Lizc 2013/07/01 Redmine#36971 ----->>>>>
            //    try
            //    {
            //        bool isOpen = Convert.ToBoolean(srvCon.GetProperty("IsOpen").GetValue(servObj, null));

            //        if (isOpen)
            //        {
            //            srvCon.InvokeMember("Disconnect", BindingFlags.InvokeMethod, null, servObj, null);
            //        }
            //    }
            //    catch { }
            //    srvCon = null;
            //    // ----- DEL Lizc 2013/07/01 Redmine#36971 -----<<<<<
            //}
            // ----- DEL 2019/10/22 田建委 SQLSERVER2017対応 -----<<<<<
            if (sqlConnection != null)
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null && sqlTransaction.Connection.State == ConnectionState.Open)
                    {
                        try
                        {
                            sqlTransaction.Rollback();
                        }
                        catch { }
                    }
                    sqlTransaction.Dispose();
                    sqlTransaction = null;
                }
                if (sqlConnection.State != ConnectionState.Closed)
                {
                    try
                    {
                        sqlConnection.Dispose();
                        sqlConnection = null;
                    }
                    catch { }
                }
            }
        }
        #endregion

        #region [ トランザクション処理 ]
        /// <summary>
        /// トランザクションを開始します。
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : トランザクションを開始します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>Update Note: 仕掛№2007 コンバートプログラムのSQLSERVER2012対応</br>
        /// <br>Programmer : Lizc</br>
        /// <br>Date       : 2013/07/01</br>
        /// <br>Update Note: PMKOBETSU-2232 SQLSERVER2017対応</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/10/22</br>
        public int BeginTransaction()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            SqlConnection sqlConnection1 = null;// ADD　2019/10/22 田建委 SQLSERVER2017対応
            if (string.IsNullOrEmpty(connectionText))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            else
            {
                try
                {
                    // --- ADD　2019/10/22 田建委 SQLSERVER2017対応---------->>>>>
                    sqlConnection1 = new SqlConnection(connectionText);
                    sqlConnection1.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(String.Format("ALTER DATABASE {0} SET RECOVERY bulk_logged", sqlConnection1.Database), sqlConnection1))
                    {
                        sqlCommand.ExecuteReader();
                    }
                    // --- ADD　2019/10/22 田建委 SQLSERVER2017対応----------<<<<
                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();
                    sqlTransaction = sqlConnection.BeginTransaction();//IsolationLevel.ReadUncommitted);

                    // --- DEL　2019/10/22 田建委 SQLSERVER2017対応---------->>>>>
                    //if (srvCon == null)
                    //{
                    //    //srvCon = new MSMC.ServerConnection();  // DEL Lizc 2013/07/01 Redmine#36971
                    //    // 2009/02/27 SQL Server認証変更対応>>>>>>>>>>>>>>>>>>>>
                    //    // Windows認証ではAPサーバー、DBサーバーの配置が分かれた場合にエラーとなるため、
                    //    // sa権限でSQL Server認証をするように修正
                    //    //srvCon.LoginSecure = true;

                    //    UbauControl ubauControl = new UbauControl();
                    //    UbauControl.DbMaintenanceInfo dbMaintenanceInfo = new UbauControl.DbMaintenanceInfo();
                    //    InstallationInfo installationInfo = new InstallationInfo();

                    //    installationInfo.ServerName = Environment.MachineName;
                    //    installationInfo.ServerType = "DB";
                    //    installationInfo.ServiceCode = "USER_DB";         //DBの種類コード(USER_DB,OFFER_DB等）
                    //    installationInfo.OsAdminId = "";                        //未入力OK
                    //    installationInfo.OsAdminPwd = "";                      //未入力OK
                    //    installationInfo.InstallMngr = "";                      //未入力OK
                    //    installationInfo.ProductCode = ConstantManagement_SF_PRO.ProductCode;      //プロダクトコード(必須)
                    //    installationInfo.DBTblNmLst = new string[] { };

                    //    dbMaintenanceInfo = ubauControl.GetDbInfo(installationInfo, UbauControl.TargetSystem.LSM);

                    //    if (dbMaintenanceInfo == null)
                    //    {
                    //        transactionFlg = false;
                    //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    //        return status;
                    //    }

                    //    /* ----- DEL Lizc 2013/07/01 Redmine#36971 ----->>>>>
                    //    srvCon.LoginSecure = false;

                    //    srvCon.Login = dbMaintenanceInfo.MyDbInfo.AdminId;
                    //    srvCon.Password = dbMaintenanceInfo.MyDbInfo.AdminPwd;
                    //    // 2009/02/27 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    //    srvCon.ServerInstance = sqlConnection.DataSource;
                    //    serv = new Server(srvCon);
                    //    ----- DEL Lizc 2013/07/01 Redmine#36971 -----<<<<< */
                    //    //----- ADD Lizc 2013/07/01 Redmine#36971 ----->>>>>
                    //    // SqlServerのDLLを動的ロード
                    //    string connectionInfoName = string.Empty;
                    //    string smoName = string.Empty;

                    //    int dbVersion = CheckDBVersion(sqlConnection, sqlTransaction);
                    //    // SqlServerのバージョンが「2008」時
                    //    if (dbVersion == (int)DB_Version.ctDB_2008)
                    //    {
                    //        connectionInfoName = "Microsoft.SqlServer.ConnectionInfo, Version=10.0.0.0,Culture=neutral, PublicKeyToken=89845dcd8080cc91";
                    //        smoName = "Microsoft.SqlServer.Smo, Version=10.0.0.0, Culture=neutral,PublicKeyToken=89845dcd8080cc91";
                    //    }
                    //    // SqlServerのバージョンが「2012」時
                    //    else if (dbVersion == (int)DB_Version.ctDB_2012)
                    //    {
                    //        connectionInfoName = "Microsoft.SqlServer.ConnectionInfo, Version=11.0.0.0, Culture=neutral,PublicKeyToken=89845dcd8080cc91";
                    //        smoName = "Microsoft.SqlServer.Smo, Version=11.0.0.0,Culture=neutral, PublicKeyToken=89845dcd8080cc91";
                    //    }
                    //    // SqlServerのバージョンがそのた時
                    //    else
                    //    {
                    //        connectionInfoName = "Microsoft.SqlServer.ConnectionInfo";
                    //        smoName = "Microsoft.SqlServer.Smo";
                    //    }

                    //    // 「srvCon = new MSMC.ServerConnection();」を代替する
                    //    Assembly connectionInfoAssembly = Assembly.Load(connectionInfoName);
                    //    srvCon = connectionInfoAssembly.GetType("Microsoft.SqlServer.Management.Common.ServerConnection");
                    //    object serverConnection = srvCon.InvokeMember(null, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance, null, null, null);

                    //    // 「srvCon.LoginSecure = false;」を代替する
                    //    srvCon.GetProperty("LoginSecure").SetValue(serverConnection, false, null);
                    //    // 「srvCon.Login = dbMaintenanceInfo.MyDbInfo.AdminId;」を代替する
                    //    srvCon.GetProperty("Login").SetValue(serverConnection, dbMaintenanceInfo.MyDbInfo.AdminId, null);
                    //    // 「srvCon.Password = dbMaintenanceInfo.MyDbInfo.AdminPwd;」を代替する
                    //    srvCon.GetProperty("Password").SetValue(serverConnection, dbMaintenanceInfo.MyDbInfo.AdminPwd, null);
                    //    // 「srvCon.ServerInstance = sqlConnection.DataSource;」を代替する
                    //    srvCon.GetProperty("ServerInstance").SetValue(serverConnection, sqlConnection.DataSource, null);

                    //    // 「serv = new Server(srvCon);」を代替する
                    //    Assembly smoAssembly = Assembly.Load(smoName);
                    //    servObj = smoAssembly.CreateInstance("Microsoft.SqlServer.Management.Smo.Server", false, BindingFlags.CreateInstance, null, new object[] { serverConnection }, null, null);
                    //    serv = servObj.GetType();
                    //    //----- ADD Lizc 2013/07/01 Redmine#36971 -----<<<<<
                    //}
                    ////serv.Databases[sqlConnection.Database].DatabaseOptions.RecoveryModel = RecoveryModel.BulkLogged;  // DEL Lizc 2013/07/01 Redmine#36971
                    //SetRecoveryModel(servObj, sqlConnection.Database, 2); // ADD Lizc 2013/07/01   Redmine#36971
                    // --- DEL　2019/10/22 田建委 SQLSERVER2017対応----------<<<<<
                    //transactionFlg = true;  
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("ROLLBACK") && sqlConnection.State == ConnectionState.Open)
                    { // ありえない操作すると一回目のトランザクション処理が失敗する場合があり、
                        try // リトライするうとOKなのでこの処理をいれた。
                        {
                            sqlTransaction = sqlConnection.BeginTransaction();//IsolationLevel.ReadUncommitted);
                        }
                        catch
                        {
                            transactionFlg = false;
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                    }
                    else
                    {
                        transactionFlg = false;
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
                // --- ADD　2019/10/22 田建委 SQLSERVER2017対応---------->>>>>
                finally
                {
                    if (sqlConnection1 != null)
                    {
                        sqlConnection1.Close();
                        sqlConnection1 = null;
                    }
                }
                // --- ADD　2019/10/22 田建委 SQLSERVER2017対応----------<<<<<
            }
            return status;
        }

        /// <summary>
        /// トランザクションを終了します。
        /// </summary>
        /// <param name="commitFlg">true : コミット　false : ロールバック</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : トランザクションを終了します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>Update Note: 仕掛№2007 コンバートプログラムのSQLSERVER2012対応</br>
        /// <br>Programmer : Lizc</br>
        /// <br>Date       : 2013/07/01</br>
        /// <br>Update Note: PMKOBETSU-2232 SQLSERVER2017対応</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/10/22</br>
        public int EndTransaction(bool commitFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // --- ADD　2019/10/22 田建委 SQLSERVER2017対応---------->>>>>
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            // --- ADD　2019/10/22 田建委 SQLSERVER2017対応----------<<<<<
            if (sqlTransaction == null)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            else
            {
                try
                {
                    if (commitFlg)
                    {
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        if (transactionFlg)
                            sqlTransaction.Rollback();
                    }
                    // --- UPD　2019/10/22 田建委 SQLSERVER2017対応---------->>>>>
                    sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;

                    string cmdStr = string.Format("SELECT BytesOnDisk / 1048576 AS FILESIZE  FROM fn_virtualfilestats(DB_ID(N'{0}'), FILE_ID('PM_USER_DB_Log'));",
                        sqlConnection.Database);
                    sqlCommand.CommandText = cmdStr;
                    myReader = sqlCommand.ExecuteReader();
                    //string cmdStr = string.Format("SELECT BytesOnDisk / 1048576 FROM fn_virtualfilestats(DB_ID(N'{0}'), FILE_ID('PM_USER_DB_Log'));",
                    //sqlConnection.Database);
                    // --- UPD　2019/10/22 田建委 SQLSERVER2017対応----------<<<<
                    long logFileSizeM;
                    try
                    {
                        // --- UPD　2019/10/22 田建委 SQLSERVER2017対応---------->>>>>
                        ////DataSet ds = serv.Databases[sqlConnection.Database].ExecuteWithResults(cmdStr); // DEL Lizc 2013/07/01 Redmine#36971 
                        //DataSet ds = (DataSet)ExecuteSql(serv, sqlConnection.Database, cmdStr);// ADD Lizc 2013/07/01 Redmine#36971 
                        //logFileSizeM = (long)ds.Tables[0].Rows[0][0];
                        if (myReader.Read())
                        {
                            logFileSizeM = SqlDataMediator.SqlGetLong(myReader, myReader.GetOrdinal("FILESIZE"));
                            if (myReader != null)
                            {
                                if (!myReader.IsClosed) myReader.Close();
                                myReader.Dispose();
                            }
                        }
                        else
                        {
                            logFileSizeM = 1025;
                        }
                        // --- UPD　2019/10/22 田建委 SQLSERVER2017対応----------<<<<<
                    }
                    catch
                    {
                        logFileSizeM = 1025; // ログファイルサイズ取得失敗時無条件ログファイル縮小
                    }

                    /* ----- DEL Lizc 2013/07/01 Redmine#36971 ----->>>>>
                    if (logFileSizeM > 1024) // ログファイルが1GB超えるか
                        serv.Databases[sqlConnection.Database].ExecuteNonQuery("DBCC SHRINKFILE (PM_USER_DB_Log, 500)");
                    serv.Databases[sqlConnection.Database].DatabaseOptions.RecoveryModel = RecoveryModel.Full;
                    ----- DEL Lizc 2013/07/01 Redmine#36971 -----<<<<<*/
                    // ----- ADD Lizc 2013/07/01 Redmine#36971 ----->>>>>
                    if (logFileSizeM > 1024) // ログファイルが1GB超えるか
                    // --- UPD　2019/10/22 田建委 SQLSERVER2017対応---------->>>>
                    //        ExecuteSql(serv, sqlConnection.Database, "DBCC SHRINKFILE (PM_USER_DB_Log, 500)");
                    //SetRecoveryModel(servObj, sqlConnection.Database, 1);
                    // ----- ADD Lizc 2013/07/01 Redmine#36971 -----<<<<<
                    {
                        sqlCommand.CommandText = "DBCC SHRINKFILE (PM_USER_DB_Log, 500)";
                        sqlCommand.ExecuteReader();
                    }

                    //serv.Databases[sqlConnection.Database].DatabaseOptions.RecoveryModel = RecoveryModel.Full;
                    sqlCommand.CommandText = string.Format("ALTER DATABASE {0} SET RECOVERY full", sqlConnection.Database);
                    sqlCommand.ExecuteReader();
                    // --- UPD　2019/10/22 田建委 SQLSERVER2017対応----------<<<<<

                }
                catch
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                finally
                {
                    // --- ADD　2019/10/22 田建委 SQLSERVER2017対応---------->>>>
                    if (sqlCommand != null)
                        sqlCommand.Dispose();
                    // --- ADD　2019/10/22 田建委 SQLSERVER2017対応----------<<<<
                    if (sqlTransaction != null)
                    {
                        sqlTransaction.Dispose();
                        sqlTransaction = null;
                    }
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        //sqlConnection.Dispose();
                        sqlConnection = null;
                    }
                    transactionFlg = false;
                }
            }
            return status;
        }
        #endregion

        #region [ コンバートデータ展開処理 ]
        /// <summary>
        /// 処理開始
        /// </summary>        
        /// <returns></returns>
        public int StartProcess()
        {
            onProcess = true;
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        // --- DEL　2019/10/22 田建委 SQLSERVER2017対応---------->>>>
        //// ----- ADD Lizc 2013/07/01 Redmine#36971 ----->>>>>

        //private enum DB_Version
        //{
        //    ctDB_2008 = 2008,
        //    ctDB_2012 = 2012,
        //    ctDB_Other = 0,
        //}

        ///// <summary>
        ///// データベースのバージョンを取得処理。
        ///// </summary>
        ///// <param name="sqlConnection">SqlConnection</param>
        ///// <param name="sqlTransaction">SqlTransaction</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : データベースのバージョンを取得処理。</br>
        ///// <br>Programmer : Lizc</br>
        ///// <br>Date       : 2013/07/01</br>
        ///// </remarks>
        //private int CheckDBVersion(SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        //{
        //    int dbVersion = (int)DB_Version.ctDB_2008;

        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;
        //    try
        //    {
        //        // データベースのバージョンを取得処理
        //        string selectTxt = "SELECT SERVERPROPERTY('productversion') AS productversion";

        //        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {

        //            string productversion = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("productversion"));

        //            // 2008時
        //            if ("10".Equals(productversion.Substring(0, 2)))
        //            {
        //                dbVersion = (int)DB_Version.ctDB_2008;
        //            }
        //            // 2012時
        //            else if ("11".Equals(productversion.Substring(0, 2)))
        //            {
        //                dbVersion = (int)DB_Version.ctDB_2012;
        //            }
        //            // その他
        //            else
        //            {
        //                dbVersion = (int)DB_Version.ctDB_Other;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //nothing
        //    }
        //    finally
        //    {
        //        if (myReader != null)
        //            myReader.Dispose();
        //        if (sqlCommand != null)
        //            sqlCommand.Dispose();
        //    }

        //    return dbVersion;
        //}

        ///// <summary>
        ///// データベース情報を取得処理。
        ///// </summary>
        ///// <param name="database">データベース</param>
        ///// <param name="recoveryModel">モード</param>
        ///// <param name="servObj">server Object</param>
        ///// <remarks>
        ///// <br>Note       : データベース情報を取得処理。</br>
        ///// <br>Programmer : Lizc</br>
        ///// <br>Date       : 2013/07/01</br>
        ///// </remarks>
        //private void SetRecoveryModel(object servObj, string database, int recoveryModel)
        //{
        //    PropertyInfo databaseInfo = servObj.GetType().GetProperty("Databases");
        //    object databasesObj = databaseInfo.GetValue(servObj, null);
        //    PropertyInfo databaseGetInfo = databaseInfo.PropertyType.GetProperty("Item", null, new Type[] { typeof(string) });
        //    object databaseObj = databaseGetInfo.GetValue(databasesObj, new object[] { sqlConnection.Database });

        //    // 「serv.Databases[sqlConnection.Database].DatabaseOptions.RecoveryModel = xx;」を代替する
        //    object databaseOptions = databaseGetInfo.PropertyType.GetProperty("DatabaseOptions").GetValue(databaseObj, null);
        //    databaseOptions.GetType().GetProperty("RecoveryModel").SetValue(databaseOptions, recoveryModel, null);
        //}

        ///// <summary>
        ///// データベースクエリ処理。
        ///// </summary>
        ///// <param name="database">データベース情報</param>
        ///// <param name="serv">server Type</param>
        ///// <param name="sql">sqlクエリ</param>
        ///// <remarks>
        ///// <br>Note       : データベースクエリ処理。</br>
        ///// <br>Programmer : Lizc</br>
        ///// <br>Date       : 2013/07/01</br>
        ///// </remarks>
        //private object ExecuteSql(Type serv, string database, string sql)
        //{
        //    // 「serv.Databases[sqlConnection.Database].ExecuteNonQuery(xxxx);」を代替する
        //    PropertyInfo databaseInfo = serv.GetProperty("Databases");
        //    object databasesObj = databaseInfo.GetValue(servObj, null);
        //    PropertyInfo databaseGetInfo = databaseInfo.PropertyType.GetProperty("Item", null, new Type[] { typeof(string) });
        //    object databaseObj = databaseGetInfo.GetValue(databasesObj, new object[] { database });
        //    return databaseObj.GetType().InvokeMember("ExecuteNonQuery", BindingFlags.InvokeMethod, null, databaseObj, new object[] { sql });
        //}

        //// ----- ADD Lizc 2013/07/01 Redmine#36971 -----<<<<<
        // --- DEL　2019/10/22 田建委 SQLSERVER2017対応----------<<<<

        /// <summary>
        /// コンバートデータをPM.NSのユーザーDBに展開します。
        /// </summary>
        /// <param name="tableID">対象のテーブルID</param>
        /// <param name="truncateFlg">削除フラグ</param>
        /// <param name="deployDataList">データのリスト(CustomSerializeArrayList)</param>
        /// <param name="errList"></param>
        /// <param name="result">コンバート結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : コンバートデータをPM.NSのユーザーDBに展開します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        public int DeployConvertData(string tableID, bool truncateFlg, CustomSerializeArrayList deployDataList,
                ref CustomSerializeArrayList errList, out ConvertResultWork result)
        {
            result = new ConvertResultWork();
            if (stopFlg)
            {
                return DoCancel(result, errList);
            }
            int status = SetDataSet(tableID, truncateFlg, deployDataList, ref errList, ref result);
            onProcess = false;
            return status;
        }

        private int SetDataSet(string tableID, bool truncateFlg, CustomSerializeArrayList deployDataList,
                ref CustomSerializeArrayList errList, ref ConvertResultWork result)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int exceptionCnt = 0;
            ExcptTblCol ExcptTblCol = new ExcptTblCol(tableID, 0);
            string _tblId = string.Empty;// ADD　2019/10/22 田建委 SQLSERVER2017対応
            char[] pat = new char[] { ',' };
            object[] row;
            result.UpdateCnt = 0;
            result.FailedRowCnt = 0;
            DataTable dt = null;    // 2009/11/17 Add
            if (deployDataList.Count == 0)
                return status;
            ArrayList list = deployDataList[0] as ArrayList;
            // 2009/11/17 del >>>
            //if (list == null)
            //    return status;
            // 2009/11/17 del <<<
            // 2009/11/17 Add >>>
            if (list == null || list.Count == 0)
            {
                if (stopFlg)
                {
                    return DoCancel(result, errList);
                }
                GetFileHeaderInfo();
                //if (sqlConnection == null) // 30万件以上のデータの処理でその都度コミットするときはトランザクション開始が必要
                //    BeginTransaction();
                if (_tblId != tableID)
                {
                    _tblId = tableID;
                     // -- UPD 2011/09/29 ----------------------------->>>
                    //string query = string.Format("SELECT * FROM {0} WHERE ENTERPRISECODERF = '{1}'", tableID, _enterpriseCode);
                    //スキーマの取得に全件取得は不要のため、１件もヒットしない条件クエリとするように修正
                    string query = string.Format("SELECT * FROM {0} WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF = '{1}' AND 1=0 ", tableID, _enterpriseCode);
                    // -- UPD 2011/09/29 -----------------------------<<<
                    da = new SqlDataAdapter(query, sqlConnection);

                    da.SelectCommand.Transaction = sqlTransaction;
                    da.SelectCommand.CommandTimeout = 3600;  // ADD 2011/09/29

                    SqlCommandBuilder builder1 = new SqlCommandBuilder(da);
                }
                dt = new DataTable();
                dt.CaseSensitive = true;
                da.FillSchema(dt, SchemaType.Mapped);
                if (truncateFlg)
                {
                    ExcptTblCol.ColNo = 8;
                    if (lstKittingTblCol.Contains(ExcptTblCol) == false) // 行毎の削除対象のテーブルでない場合
                    {
                        dt.Rows.Clear();
                        SqlCommand command = new SqlCommand();// ADD　2019/10/22 田建委 SQLSERVER2017対応
                        ////command.CommandText = string.Format("DELETE FROM {0} WHERE ENTERPRISECODERF = '{1}'", tableID, _enterpriseCode);
                        //// DELETEだと大量データの削除時タイムアウトになるため、下記にする。
                        //// 企業コード違いはコンバート時はないため無視していいと確認。(2009/01/15)
                        // --- UPD　2019/10/22 田建委 SQLSERVER2017対応---------->>>>
                        command.CommandText = string.Format("TRUNCATE TABLE {0} ", tableID);
                        command.Connection = sqlConnection;
                        command.Transaction = sqlTransaction;
                        command.ExecuteNonQuery();
                        command.Dispose();
                        // --- UPD　2019/10/22 田建委 SQLSERVER2017対応----------<<<<
                        //serv.Databases[sqlConnection.Database].ExecuteNonQuery(string.Format("TRUNCATE TABLE {0} ", tableID)); // DEL Lizc 2013/07/01 Redmine#36971
                        //ExecuteSql(serv, sqlConnection.Database, string.Format("TRUNCATE TABLE {0} ", tableID));     // ADD Lizc 2013/07/01 Redmine#36971    // DEL 2019/10/22 田建委 SQLSERVER2017対応           

                        dt.AcceptChanges();
                        da.Update(dt);
                        return 0;
                    }
                }
                //return status; // del wangf 2011/08/30
                return 0; // add wangf 2011/08/30
            }

            // --- ADD 2020/06/18 佐々木亘 ---------->>>>>
            // 変換情報 価格マスタのみ呼び出し
            double dListPrice = double.MinValue;  // 定価
            ConvertDoubleRelease convertDoubleRelease = null;
            if ("GOODSPRICEURF".Equals(tableID))
            {
                // 変換情報呼び出し
                convertDoubleRelease = new ConvertDoubleRelease();

                // 変換情報初期化
                convertDoubleRelease.ReleaseInitLib();
            }
            // --- ADD 2020/06/18 佐々木亘 ----------<<<<<

            // 2009/11/17 Add <<<
            //SqlDataAdapter da = null;
            //DataTable dt = null;    // 2009/11/17 Del
            try
            {
                if (stopFlg)
                {
                    return DoCancel(result, errList);
                }
                GetFileHeaderInfo();
                //if (sqlConnection == null) // 30万件以上のデータの処理でその都度コミットするときはトランザクション開始が必要
                //    BeginTransaction();
                if (_tblId != tableID)
                {
                    _tblId = tableID;
                    string query = string.Format("SELECT * FROM {0} WHERE ENTERPRISECODERF = '{1}'", tableID, _enterpriseCode);
                    da = new SqlDataAdapter(query, sqlConnection);

                    da.SelectCommand.Transaction = sqlTransaction;
                    SqlCommandBuilder builder1 = new SqlCommandBuilder(da);
                }

                dt = new DataTable();
                dt.CaseSensitive = true;

                // -- ADD 2011/09/29 ----------------------------->>>
                //下記、スキーマの取得に全件取得は不要のため、１件もヒットしない条件クエリとするように修正
                da.SelectCommand.CommandText = string.Format("SELECT * FROM {0} WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF = '{1}' AND 1=0 ", tableID, _enterpriseCode); ;
                // -- ADD 2011/09/29 -----------------------------<<<
                da.SelectCommand.CommandTimeout = 3600;  // ADD 2011/09/29

                da.FillSchema(dt, SchemaType.Mapped);

                // -- ADD 2011/09/29 ----------------------------->>>
                //Fillで使用するため、CommandTextを書き戻す
                da.SelectCommand.CommandText = string.Format("SELECT * FROM {0} WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF = '{1}'", tableID, _enterpriseCode);
                // -- ADD 2011/09/29 -----------------------------<<<

                if (stopFlg)
                {
                    return DoCancel(result, errList);
                }
                ExcptTblCol.ColNo = 8;
                if ((truncateFlg == false  // 削除フラグなし
                    && lstDataFullTbl.Contains(tableID) == false) || // 大量データは重複チェックのための既存データロードなし
                    (truncateFlg && lstKittingTblCol.Contains(ExcptTblCol)))  // データ内容チェックしながら削除するパターン                    
                    da.Fill(dt);

                if (stopFlg)
                {
                    return DoCancel(result, errList);
                }
                if (truncateFlg)
                {
                    ExcptTblCol.ColNo = 8;
                    if (lstKittingTblCol.Contains(ExcptTblCol) == false) // 行毎の削除対象のテーブルでない場合
                    {
                        dt.Rows.Clear();
                        SqlCommand command = new SqlCommand();//ADD　2019/10/22 田建委 SQLSERVER2017対応
                        ////command.CommandText = string.Format("DELETE FROM {0} WHERE ENTERPRISECODERF = '{1}'", tableID, _enterpriseCode);
                        //// DELETEだと大量データの削除時タイムアウトになるため、下記にする。
                        //// 企業コード違いはコンバート時はないため無視していいと確認。(2009/01/15)
                        //command.CommandText = string.Format("TRUNCATE TABLE {0} ", tableID);
                        //command.Connection = sqlConnection;
                        //command.Transaction = sqlTransaction;
                        //command.ExecuteNonQuery();
                        //command.Dispose();
                        // ----- ADD 王君 Redmine#32201 2012/11/05 -------------------->>>>>
                        if ("USERGDBDURF".Equals(tableID))
                        {
                            // --- UPD　2019/10/22 田建委 SQLSERVER2017対応---------->>>>
                            //serv.Databases[sqlConnection.Database].ExecuteNonQuery(string.Format("DELETE FROM {0} WHERE ENTERPRISECODERF = '{1}' AND USERGUIDEDIVCDRF ! = 80 ", tableID, _enterpriseCode)); // ADD Lizc 2013/07/01 Redmine#36971
                            //ExecuteSql(serv, sqlConnection.Database, string.Format("DELETE FROM {0} WHERE ENTERPRISECODERF = '{1}' AND USERGUIDEDIVCDRF ! = 80 ", tableID, _enterpriseCode));  // ADD Lizc 2013/07/01 Redmine#36971
                            command.CommandText = string.Format("DELETE FROM {0} WHERE ENTERPRISECODERF = '{1}' AND USERGUIDEDIVCDRF ! = 80 ", tableID, _enterpriseCode);
                            // --- UPD　2019/10/22 田建委 SQLSERVER2017対応----------<<<<
                        }
                        else
                        {
                        // ----- ADD 王君 Redmine#32201 2012/11/05 --------------------<<<<<
                            // --- UPD　2019/10/22 田建委 SQLSERVER2017対応----------<<<<
                            //serv.Databases[sqlConnection.Database].ExecuteNonQuery(string.Format("TRUNCATE TABLE {0} ", tableID));// DEL Lizc 2013/07/01 Redmine#36971
                            //ExecuteSql(serv, sqlConnection.Database, string.Format("TRUNCATE TABLE {0} ", tableID)); // ADD Lizc 2013/07/01 Redmine#36971
                            command.CommandText = string.Format("TRUNCATE TABLE {0} ", tableID);
                            // --- UPD　2019/10/22 田建委 SQLSERVER2017対応----------<<<<
                        }   // ADD 王君 Redmine#32201 2012/11/05
                        // --- ADD　2019/10/22 田建委 SQLSERVER2017対応---------->>>>
                        command.Connection = sqlConnection;
                        command.Transaction = sqlTransaction;
                        command.ExecuteNonQuery();
                        command.Dispose();
                        // --- ADD　2019/10/22 田建委 SQLSERVER2017対応----------<<<<
                        dt.AcceptChanges();
                    }
                    else
                    {
                        int rowCnt = dt.Rows.Count;
                        for (int i = 0; i < rowCnt; i++)
                        {
                            // 2009/02/14 MAINTIS 11475 >>>>>>>>>>>>>>>>>>>>>>
                            //if (dt.Rows[i][8].ToString().Trim().Equals("00") == false) // 削除対象外か
                            //    dt.Rows[i].Delete();

                            if (tableID != "EMPLOYEERF" && tableID != "EMPLOYEEDTLRF")
                            {
                                //全体設定関係は拠点コード'00'は削除しない(インデックス[8]はレイアウト上の拠点コード)
                                if (dt.Rows[i][8].ToString().Trim().Equals("00") == false) // 削除対象外か
                                    dt.Rows[i].Delete();
                            }
                            else
                            {
                                //従業員マスタは、従業員コードが文字列の場合は削除しない（文字列はキッティング）
                                if (CheckValueNum(dt.Rows[i][8].ToString()))
                                    dt.Rows[i].Delete();
                            }
                            // 2009/02/14 MAINTIS 11475 <<<<<<<<<<<<<<<<<<<<<<
                        }
                        da.Update(dt);
                    }
                    transactionFlg = true;
                }
                if (stopFlg)
                {
                    return DoCancel(result, errList);
                }
                Int64 now = DateTime.Now.Ticks;
                int cnt = dt.Columns.Count;

                row = new object[cnt];
                // ヘッダ作成
                row[0] = now; // 作成日時
                row[1] = now; // 更新日時
                row[2] = _enterpriseCode; // 企業コード
                //row[3] = Guid.NewGuid(); // GUID
                row[4] = _updEmployeeCode; // 更新従業員コード
                row[5] = _updAssemblyId1; // 更新アセンブリID1
                row[6] = _updAssemblyId2; // 更新アセンブリID2
                row[7] = 0; // 論理削除区分
                foreach (string str in list)
                {

                    try
                    {
                        //CSVのレコードの内容を文字列の配列に格納
                        string[] dat = SplitString(str, cnt);// str.Split(pat);
                        row[3] = Guid.NewGuid(); // GUID
                        // -- add wangf 2011/08/12 ---------->>>>>
                        string tmpSectionCode = string.Empty;
                        int columnIndex = 0;
                        int tmpAcceptAnOrderNo = 0; // 受注番号
                        // ----- DEL tianjw 2011/09/03 ---------------->>>>>
                        //int tmpSupplierFormalSync = 0; // 仕入形式
                        //long tmpStockSlipDtlNumSync = 0; // 仕入明細通番
                        // ----- DEL tianjw 2011/09/03 ----------------<<<<<

                        int tmpHisDtlAcceptAnOrderNo = 0; // 受注番号

                        // -- add wangf 2011/08/12 ----------<<<<<
                        //列毎に処理
                        for (int i = 0; i < cnt; i++)
                        {
                            dat[i] = dat[i].Substring(1, dat[i].Length - 2).Replace("\"\"", "\"");
                            if (dat[i] != string.Empty) // データあり
                            {
                                ExcptTblCol.ColNo = i;
                                if (lstZeroNullExcptTblCol.Contains(ExcptTblCol) && (dat[i].Equals("0") || dat[i].Equals(0)))
                                {
                                    row[i] = DBNull.Value;
                                }
                                else if (dt.Columns[i].DataType.Name == "String") // 文字列の場合、
                                {
                                    //if (lstZeroExcptTblCol.Contains(ExcptTblCol) && dat[i].Equals("0"))
                                    //{  // 0を空白扱いする例外処理か
                                    //    row[i] = string.Empty;
                                    //}
                                    //else 
                                    if (tableID == "GCDSALESTARGETRF" && dat[10].Equals("\"45\"") && i == 8)
                                    { // 商品別売上目標設定マスタ 目標対比区分が[45:拠点+自社分類]の場合 0を空白とする
                                        row[i] = string.Empty;
                                    }
                                    // DEL BY gongzc 2015/08/27 FOR Redmine#47009 【№271】NS側在庫仕入データコンバートの障害対応 ---->>>>
                                    //// 2009/06/29 MANTIS 13645 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
                                    //// 在庫マスタの管理区分(列)では文字列"0"が存在するため、NULLをセットしない
                                    ////else if (dat[i].Equals("0") && dt.Columns[i].AllowDBNull)
                                    //else if (dat[i].Equals("0") && dt.Columns[i].AllowDBNull
                                    //    //&& !(tableID == "STOCKRF" && (i==33 || i==34)) ) // del wangf 2011/08/19
                                    //    // -- add wangf 2011/08/19 ---------->>>>>
                                    //          && !(tableID == "STOCKRF" && (i == 33 || i == 34))
                                    //          && !(tableID == "GOODSURF" && (i == 17))) // 商品マスタ（ユーザー登録分）にでハイフン無商品番号
                                    //// -- add wangf 2011/08/19 ----------<<<<<
                                    //// 2009/06/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                    // DEL BY gongzc 2015/08/27 FOR Redmine#47009 【№271】NS側在庫仕入データコンバートの障害対応 ----<<<<
                                    // ADD BY gongzc 2015/08/27 FOR Redmine#47009 【№271】NS側在庫仕入データコンバートの障害対応 ---->>>>
                                    else if (!lstNotConvrtZeroToNullExcptTblCol.Contains(ExcptTblCol)
                                             && dat[i].Equals("0")
                                             && dt.Columns[i].AllowDBNull)
                                    // ADD BY gongzc 2015/08/27 FOR Redmine#47009 【№271】NS側在庫仕入データコンバートの障害対応 ----<<<<
                                    {
                                        row[i] = DBNull.Value;
                                    }
                                    // -- ADD 2010/01/28 ------------------------------>>>
                                    //商品月次集計データで品番に全角空白がセットされていた場合は、半角２桁の空白に変換する。
                                    else if (tableID == "GOODSMTTLSASLIPRF" && i == 15 && dat[i].Contains("　"))
                                    {
                                        row[i] = dat[i].Replace("　","  ");
                                    }
                                    // -- ADD 2010/01/28 ------------------------------<<<
                                    // -- ADD 2010/04/28 ------------------------------>>>
                                    //商品月次集計データで品番に全角英数文字がセットされていた場合は、半角文字＋半角空白に変換する。
                                    else if (tableID == "GOODSMTTLSASLIPRF" && i == 15)
                                    {
                                        string workdat = dat[i];
                                        for (int j = 0; j < lstFullSizeCheckTbl.Count; j++)
                                        {
                                            //置き換え対象の全角文字を含むかチェック
                                            if (workdat.Contains(lstFullSizeCheckTbl[j].ToString()))
                                            {
                                                workdat = workdat.Replace(lstFullSizeCheckTbl[j].ToString(), Microsoft.VisualBasic.Strings.StrConv(lstFullSizeCheckTbl[j].ToString(), Microsoft.VisualBasic.VbStrConv.Narrow, 0) + " ");
                                            }
                                        }
                                        row[i] = workdat;
                                    }
                                    // -- ADD 2010/04/28 ------------------------------<<<
                                    else
                                    {
                                        DataRow rowCol = conf.Tables[ctColDfTable].Rows.Find(dt.Columns[i].ColumnName);
                                        if (rowCol == null) // 0詰処理不要
                                        {
                                            row[i] = Convert.ChangeType(dat[i], dt.Columns[i].DataType);
                                        }
                                        else // 0詰処理が必要
                                        {
                                            DataRow rowDD = conf.Tables[ctDDTable].Rows.Find(rowCol[ctItemDDName].ToString());
                                            int cntCol = Convert.ToInt32(rowDD[ctColumn]);
                                            if (cntCol > 0 && cntCol < 256)
                                            {
                                                StringBuilder fmt = new StringBuilder();
                                                fmt.Append("{0:");
                                                fmt.Append('0', cntCol);
                                                fmt.Append("}");
                                                row[i] = string.Format(fmt.ToString(), Convert.ToInt32(dat[i]));
                                            }
                                            else
                                            {
                                                row[i] = Convert.ChangeType(dat[i], dt.Columns[i].DataType);
                                            }
                                        }
                                    }
                                    // -- add wangf 2011/08/12 ---------->>>>>
                                    // 拠点コードを保存
                                    if ("SECTIONCODERF".Equals(dt.Columns[i].ToString()))
                                    {
                                        tmpSectionCode = dat[i];
                                    }
                                    // -- add wangf 2011/08/12 ----------<<<<<
                                }
                                else // データタイプがStringでない場合
                                {
                                    row[i] = Convert.ChangeType(dat[i], dt.Columns[i].DataType);
                                    // -- add wangf 2011/08/12 ---------->>>>>
                                    if ("SALESDETAILRF".Equals(tableID))
                                    {
                                        if ("ACCEPTANORDERNORF".Equals(dt.Columns[i].ToString()))
                                        {
                                            columnIndex = i;
                                            tmpAcceptAnOrderNo = Convert.ToInt32(dat[i]);
                                        }
                                        // ----- DEL tianjw 2011/09/03 ---------------->>>>>
                                        //// 仕入形式を保存
                                        //if ("SUPPLIERFORMALSYNCRF".Equals(dt.Columns[i].ToString()))
                                        //{
                                        //    tmpSupplierFormalSync = Convert.ToInt32(dat[i]);
                                        //}
                                        //// 仕入明細通番を保存
                                        //if ("STOCKSLIPDTLNUMSYNCRF".Equals(dt.Columns[i].ToString()))
                                        //{
                                        //    tmpStockSlipDtlNumSync = Convert.ToInt64(dat[i]);
                                        //}
                                        // ----- DEL tianjw 2011/09/03 ----------------<<<<<
                                    }
                                    // ----- ADD tianjw 2011/09/03 ----------------------------->>>>>
                                    if ("SALESHISTDTLRF".Equals(tableID))
                                    {
                                        if ("ACCEPTANORDERNORF".Equals(dt.Columns[i].ToString()))
                                        {
                                            columnIndex = i;
                                            tmpHisDtlAcceptAnOrderNo = Convert.ToInt32(dat[i]);
                                        }
                                    }
                                    // ----- ADD tianjw 2011/09/03 -----------------------------<<<<<
                                    if ("ACCEPTODRCARRF".Equals(tableID))
                                    {
                                        if ("ACCEPTANORDERNORF".Equals(dt.Columns[i].ToString()))
                                        {
                                            if (Convert.ToInt32(dat[i]) < 0)
                                            {
                                                if (this._acceptAnOrderNoHashTable.Contains(Convert.ToInt32(dat[i])))
                                                {
                                                    row[i] = this._acceptAnOrderNoHashTable[Convert.ToInt32(dat[i])];
                                                    this._acceptAnOrderNoHashTable.Remove(Convert.ToInt32(dat[i])); // ADD tianjw 2011/09/05
                                                }
                                                // ----- ADD tianjw 2011/09/03 ----------------------------->>>>>
                                                else if (this._hisDtlAcceptAnOrderNoHashTable.Contains(Convert.ToInt32(dat[i])))
                                                {
                                                    row[i] = this._hisDtlAcceptAnOrderNoHashTable[Convert.ToInt32(dat[i])];
                                                    this._hisDtlAcceptAnOrderNoHashTable.Remove(Convert.ToInt32(dat[i])); // ADD tianjw 2011/09/05
                                                }
                                                // ----- ADD tianjw 2011/09/03 -----------------------------<<<<<
                                            }
                                        }
                                    }
                                    // -- add wangf 2011/08/12 ----------<<<<<

                                    // --- ADD 2020/06/18 佐々木亘 ---------->>>>>
                                    if ("GOODSPRICEURF".Equals(tableID))
                                    {
                                        if ("LISTPRICERF".Equals(dt.Columns[i].ToString()))
                                        {
                                            if (double.TryParse(dat[i], out dListPrice) == true)
                                            {
                                                convertDoubleRelease.EnterpriseCode = _enterpriseCode;
                                                convertDoubleRelease.GoodsMakerCd = int.MinValue; // ダミー
                                                convertDoubleRelease.GoodsNo = string.Empty; // ダミー
                                                convertDoubleRelease.ConvertSetParam = dListPrice; 
                                                // 変換処理実行
                                                convertDoubleRelease.ConvertProc();

                                                row[i] = Convert.ChangeType(convertDoubleRelease.ConvertInfParam.ConvertGetParam, dt.Columns[i].DataType);
                                            }
                                        }
                                    }
                                    // --- ADD 2020/06/18 佐々木亘 ----------<<<<<
                                }
                            }
                            else if (i > 7) // データなし且つヘッダでない場合
                            {
                                //if (tableID == "GOODSMNGRF" && i == 11) // 商品管理情報マスタテーブルの商品番号（例外処理）
                                ExcptTblCol.ColNo = i;
                                if (lstSpaceExcptTblCol.Contains(ExcptTblCol))
                                {
                                    row[i] = string.Empty; // キーなのでNULL不可の項目のため、例外的に空白設定
                                }
                                else if (lstSpaceZeroExcptTblCol.Contains(ExcptTblCol))
                                {
                                    row[i] = 0; // NULL不可且つ数字カラムのため、例外的に0設定
                                }
                                // 2009/10/05 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
                                //else if (tableID == "ACCEPTODRCARRF" &&
                                else if ((tableID == "ACCEPTODRCARRF" || tableID == "CARMANAGEMENTRF") &&
                                    // 2009/10/05 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                    dt.Columns[i].DataType.Name == "Byte[]") // 受注マスタ（車両）のバイナリ配列対応
                                {
                                    // 2010/09/16 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
                                    //row[i] = new byte[0];
                                    if (dt.Columns[i].ColumnName == "FREESRCHMDLFXDNOARYRF")
                                    {
                                        // 自由検索型式固定番号配列のバイナリ配列対応
                                        row[i] = DBNull.Value;
                                    }
                                    else
                                    {
                                        row[i] = new byte[0];
                                    }
                                    // 2010/09/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                }
                                else
                                {
                                    row[i] = DBNull.Value;
                                }
                            }
                        }
                        // -- add wangf 2011/08/12 ---------->>>>>
                        if ("SALESDETAILRF".Equals(tableID))
                        {
                            if (tmpAcceptAnOrderNo < 0)
                            {
                                int standardAcceptAnOrderNo = 0;
                                // 番号管理設定読み込み
                                int statusNoMng = this._acceptOdr.GetAcceptAnOrderNo(_enterpriseCode, tmpSectionCode.PadLeft(2, '0'), out standardAcceptAnOrderNo);
                                if (statusNoMng == 0)
                                {
                                    // XMLの読み込み
                                    row[columnIndex] = standardAcceptAnOrderNo;
                                    if (!this._acceptAnOrderNoHashTable.Contains(tmpAcceptAnOrderNo))
                                    {
                                        this._acceptAnOrderNoHashTable.Add(tmpAcceptAnOrderNo, standardAcceptAnOrderNo);
                                    }
                                    else
                                    {
                                        this._acceptAnOrderNoHashTable.Remove(tmpAcceptAnOrderNo);
                                        this._acceptAnOrderNoHashTable.Add(tmpAcceptAnOrderNo, standardAcceptAnOrderNo);
                                    }
                                }
                                // ----- DEL tianjw 2011/09/03 --------------------------->>>>>
                                //// 仕入明細データ更新
                                //ArrayList stockDetailWorks = new ArrayList();
                                //ArrayList parastockDetailWorks = new ArrayList();
                                //StockDetailWork paraDtlWork = new StockDetailWork();
                                //paraDtlWork.EnterpriseCode = this._enterpriseCode;
                                //// 仕入形式
                                //paraDtlWork.SupplierFormal = tmpSupplierFormalSync;
                                //// 仕入明細通番
                                //paraDtlWork.StockSlipDtlNum = (int)tmpStockSlipDtlNumSync;
                                //parastockDetailWorks.Add(paraDtlWork);
                                //int statusStockDetailWork = this._stockSlipDB.ReadStockDetailWork(out stockDetailWorks, parastockDetailWorks, ref sqlConnection, ref sqlTransaction);
                                //if (statusStockDetailWork == 0)
                                //{
                                //    StockDetailWork tmpStockDetailWork = (StockDetailWork)stockDetailWorks[0];
                                //    tmpStockDetailWork.AcceptAnOrderNo = standardAcceptAnOrderNo;
                                //    tmpStockDetailWork.EnterpriseCode = this._enterpriseCode;
                                //    tmpStockDetailWork.SupplierFormal = tmpSupplierFormalSync;
                                //    tmpStockDetailWork.StockSlipDtlNum = (int)tmpStockSlipDtlNumSync;
                                //    this._stockSlipDB.UpdateConvertStockDetailWork(ref tmpStockDetailWork, ref sqlConnection, ref sqlTransaction);
                                //}
                                // ----- DEL tianjw 2011/09/03 ---------------------------<<<<<
                            }
                        }
                        // -- add wangf 2011/08/12 ----------<<<<<
                        // ----- ADD tianjw 2011/09/03 ----------------------------->>>>>
                        if ("SALESHISTDTLRF".Equals(tableID))
                        {
                            if (tmpHisDtlAcceptAnOrderNo < 0)
                            {
                                int standardAcceptAnOrderNo = 0;
                                int statusNoMng = 0;
                                if (!this._acceptAnOrderNoHashTable.Contains(tmpHisDtlAcceptAnOrderNo))
                                {
                                    // 番号管理設定読み込み
                                    statusNoMng = this._acceptOdr.GetAcceptAnOrderNo(_enterpriseCode, tmpSectionCode.PadLeft(2, '0'), out standardAcceptAnOrderNo);

                                    if (statusNoMng == 0)
                                    {
                                        // XMLの読み込み
                                        row[columnIndex] = standardAcceptAnOrderNo;
                                        if (!this._hisDtlAcceptAnOrderNoHashTable.Contains(tmpHisDtlAcceptAnOrderNo))
                                        {
                                            this._hisDtlAcceptAnOrderNoHashTable.Add(tmpHisDtlAcceptAnOrderNo, standardAcceptAnOrderNo);
                                        }
                                        else
                                        {
                                            this._hisDtlAcceptAnOrderNoHashTable.Remove(tmpHisDtlAcceptAnOrderNo);
                                            this._hisDtlAcceptAnOrderNoHashTable.Add(tmpHisDtlAcceptAnOrderNo, standardAcceptAnOrderNo);
                                        }
                                    }
                                }
                                else
                                {
                                    row[columnIndex] = this._acceptAnOrderNoHashTable[tmpHisDtlAcceptAnOrderNo];
                                }
                            }
                        }
                        // ----- ADD tianjw 2011/09/03 -----------------------------<<<<<

                        DataRow addedRow = dt.Rows.Add(row);
                        if (stopFlg)
                        {
                            return DoCancel(result, errList);
                        }
                    }
                    catch (Exception ex) // データタイプミスマッチ　又は 既に同じキーを持つデータがDBに存在する場合　など
                    {
                        if (listChkExcpt.Contains(tableID) // 重複例外テーブルか
                                && ex is ConstraintException)
                        {
                            exceptionCnt++;
                        }

                        result.FailedRowCnt++;
                        ErrorReportWork err = new ErrorReportWork();
                        err.ProcessingData = str;

                        if (ex is ConstraintException || ex is NoNullAllowedException || ex is ArgumentException
                            || ex is FormatException || ex.Source == "PMKHN08003R")
                            err.ErrMsg = ex.Message;
                        else
                            // 2012/02/15 >>>
                            //err.ErrMsg = "処理中エラーが発生しました。";
                            err.ErrMsg = ex.Message + " : 処理中エラーが発生しました。";
                            // 2012/02/15 <<<

                        errList.Add(err);
                    }
                }
                if (errList.Count == 0 || (listChkExcpt.Contains(tableID) && errList.Count == exceptionCnt))
                {
                    // -- ADD 2011/09/29 ----------------------------->>>
                    // 追加時のタイムアウト時間を延長する。
                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                    da.InsertCommand = cmdBuilder.GetInsertCommand();
                    da.InsertCommand.CommandTimeout = 3600;
                    // -- ADD 2011/09/29 -----------------------------<<<

                    result.UpdateCnt = da.Update(dt);
                    transactionFlg = true;
                    if (result.UpdateCnt == list.Count || (listChkExcpt.Contains(tableID) && result.UpdateCnt + exceptionCnt == list.Count))
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        if (listChkExcpt.Contains(tableID) && exceptionCnt > 0)
                            result.ErrMsg = "DB更新中一部行の更新に失敗しました。DBログを参照して下さい。";
                    }
                    else
                    {
                        result.ErrMsg = "DB更新中一部行の更新に失敗しました。DBログを参照して下さい。";
                        result.FailedRowCnt = list.Count - result.UpdateCnt;
                    }
                    //if (result.UpdateCnt == 100000) // 10万件ごとの分割処理の場合その都度コミットする。
                    //{
                    //    EndTransaction(true);
                    //}
                }
                else // データテーブル作成中のエラー
                {
                    result.UpdateCnt = 0;
                    result.FailedRowCnt = list.Count;
                    result.ErrMsg = "データ異常です。ConvertErrorLogフォルダにあるエラーログを参照して下さい。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, " ");
                // FOR TEST
                //result.ErrMsg = ex.Message;
                // 2012/02/15 >>>
                //result.ErrMsg = "処理中エラーが発生しました。";
                result.ErrMsg = ex.Message + " : 処理中エラーが発生しました。";
                // 2012/02/15 <<<

                WriteLog(_enterpriseCode, "SetDataSet", ex.Message, status);  // ADD 2011/09/06
            }
            finally
            {
                dt.Rows.Clear();
                dt.Dispose();
                // --- ADD 2020/06/18 佐々木亘 ---------->>>>>
                // 解放
                if (convertDoubleRelease != null)
                {
                    convertDoubleRelease.Dispose();
                }
                // --- ADD 2020/06/18 佐々木亘 ----------<<<<<
                GC.Collect();
                //da.Dispose();
            }

            // --- ADD 2011/09/06---------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                WriteLog(_enterpriseCode, "SetDataSet", "コンバートデータをPM.NSのユーザーDBに展開", status);
            }
            // --- ADD 2011/09/06----------<<<<<

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
        /// キャンセル処理
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errList"></param>
        /// <returns></returns>
        private int DoCancel(ConvertResultWork result, CustomSerializeArrayList errList)
        {
            stopFlg = false;
            result.ErrMsg = "処理は中止されました。";
            if (errList.Count > 0)
            {
                result.ErrMsg += "エラーログを確認して下さい。";
            }
            return (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
        }

        private static string[] SplitString(string src, int cnt)
        {
            char[] pat = new char[] { ',' };
            string[] ret = src.Split(pat);
            // 2009/11/09 Add >>>
            // 項目数確認用
            int retCount = 0;
            int delCount = 0;
            string[] newret = new string[ret.Length];
            // 2009/11/09 Add <<<
            if (ret.Length < cnt)
            {
                string msg = string.Format("項目が{0}個足りません。CSVファイルをもう一度確認お願いします。", cnt - ret.Length);
                throw new Exception(msg);
            }
            // 2009/11/09 >>>
            //else if (ret.Length > cnt)
            else
            // 2009/11/09 <<<
            {
                for (int i = 0; i < ret.Length; i++)
                {
                    if (ret[i].EndsWith("\"") == false)
                    {
                        if (ret[i].StartsWith("\""))
                        {
                            ret[i] = ret[i] + "," + ret[i + 1];
                            Array.Copy(ret, i + 2, ret, i + 1, ret.Length - i - 2);
                            // 2009/11/09 Add >>>
                            // コンマ対応中は次の要素へ移動しないようにする
                            i--;
                            delCount++;
                            // 2009/11/09 Add <<<
                        }
                        // 2010/03/16 Add >>>
                        else if ((ret[i].StartsWith("\"ﾞ"))  || (ret[i].StartsWith("\"ﾟ"))  ||
                                 (ret[i].StartsWith("\"ﾞﾞ")) || (ret[i].StartsWith("\"ﾟﾞ")) ||
                                 (ret[i].StartsWith("\"ﾞﾟ")) || (ret[i].StartsWith("\"ﾟﾟ")))
                        {
                            ret[i] = ret[i] + "," + ret[i + 1];
                            Array.Copy(ret, i + 2, ret, i + 1, ret.Length - i - 2);
                            // コンマ対応中は次の要素へ移動しないようにする
                            i--;
                            delCount++;
                        }
                        // 2010/03/16 Add <<<
                        // 2009/11/09 Del >>>
                        //else
                        //{
                        //    ret[i - 1] = ret[i - 1] + "," + ret[i];
                        //    if (i < ret.Length - 1)
                        //    {
                        //        Array.Copy(ret, i + 1, ret, i, ret.Length - i - 1);
                        //        i--;
                        //    }
                        //}
                        // 2009/11/09 Del <<<
                    }
                    else
                    {
                        // 2009/11/09 Del >>>
                        //if (ret[i].Length < 2 || ret[i].StartsWith("\"") == false)
                        //{
                        //    ret[i - 1] = ret[i - 1] + "," + ret[i];
                        //    if (i < ret.Length - 1)
                        //    {
                        //        Array.Copy(ret, i + 1, ret, i, ret.Length - i - 1);
                        //        i--;
                        //    }
                        //}
                        // 2009/11/09 Del <<<
                        // 2009/11/09 Add >>>
                        if (ret[i].Length < 2)
                        {
                            if (i < ret.Length - 1)
                            {
                                ret[i] = ret[i] + "," + ret[i + 1];
                                Array.Copy(ret, i + 2, ret, i + 1, ret.Length - i - 2);
                                i--;
                                delCount++;
                            }
                        }
                        else
                        {
                            // フィールド内に","がある場合の対応
                            int count = 0;
                            for (int j = 0; ret[i].Length > j; j++)
                            {
                                j = ret[i].IndexOf("\"", j);
                                count++;
                            }
                            // 2010/03/16 Add >>>
                            if ((ret[i].StartsWith("\"ﾞ"))  || (ret[i].StartsWith("\"ﾟ"))  ||
                                (ret[i].StartsWith("\"ﾞﾞ")) || (ret[i].StartsWith("\"ﾟﾞ")) ||
                                (ret[i].StartsWith("\"ﾞﾟ")) || (ret[i].StartsWith("\"ﾟﾟ")))
                            {
                                count++;
                            }
                            // 2010/03/16 Add <<<
                            if (count % 2 == 1)
                            {
                                if (i < ret.Length - delCount)
                                {
                                    ret[i] = ret[i] + "," + ret[i + 1];
                                    Array.Copy(ret, i + 2, ret, i + 1, ret.Length - i - 2);
                                    i--;
                                    delCount++;
                                }
                            }
                            else
                            {
                                if (retCount + delCount < ret.Length)
                                {
                                    newret[retCount] = ret[retCount];
                                    retCount++;
                                }
                            }
                        }
                        // 2009/11/09 Add <<<
                    }
                }
            }

            // 2009/11/09 Add >>>
            // 解析後再度項目数チェック
            if (retCount < cnt)
            {
                string msg = string.Format("項目が{0}個足りません。CSVファイルをもう一度確認お願いします。", cnt - retCount);
                throw new Exception(msg);
            }
            else if (retCount > cnt)
            {
                string msg = string.Format("項目が{0}個多いです。CSVファイルをもう一度確認お願いします。", retCount - cnt);
                throw new Exception(msg);
            }
            // 2009/11/09 Add <<<

            // 2009/11/09 >>>
            return ret;
            //return newret;
            // 2009/11/09 <<<
        }

        private void GetFileHeaderInfo()
        {
            if (string.IsNullOrEmpty(_enterpriseCode))
            {
                ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
                _enterpriseCode = acquisition.EnterpriseCode;
                // 2009/02/24 MANTIS 11844>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //ログイン従業員情報が取得出来ない件の修正
                //_updEmployeeCode = string.Format("{0:0000}", Convert.ToInt32(acquisition.EmployeeCode));
                if (CheckValueNum(acquisition.EmployeeCode))
                {
                    _updEmployeeCode = string.Format("{0:0000}", Convert.ToInt32(acquisition.EmployeeCode));
                }
                else
                {
                    //supportでコンバートを行うため修正
                    _updEmployeeCode = acquisition.EmployeeCode;
                }
                // 2009/02/24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                _updAssemblyId1 = acquisition.ClientUpateAssemblyId;
                _updAssemblyId2 = "PMConvert";
            }
        }

        /// <summary>
        /// 処理中止
        /// </summary>        
        /// <returns></returns>
        public int StopProcess()
        {
            return StopProcessProc();
        }

        private int StopProcessProc()
        {
            if (onProcess == false) // 処理中でない場合(キャンセルリクエストがくる途中処理が終了することがあるので)
                return 1; // 戻り値1は処理キャンセルが利かず処理終了したとのこと。
            stopFlg = true;
            int cnt = 0;
            do
            {
                System.Threading.Thread.Sleep(50);
                cnt++;
                if (cnt > 30) // 一定時間待っててもtrueにならないと失敗と見なす。
                {
                    stopFlg = false;
                    return -1;
                }
            } while (stopFlg);
            return 0;
        }
        #endregion

        #region [ 受払履歴データ設定処理 ]
        /// <summary>
        /// 在庫受払設定処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="lstSource">在庫受払設定の元データ[0:売上/1:売上履歴/2:仕入/3:仕入履歴/4:在庫移動/5:在庫調整]</param>
        /// <param name="resultCnt">処理データ件数</param>
        /// <returns></returns>
        public int SetStockAcPayHist(string enterpriseCode, List<int> lstSource, out int resultCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            _enterpriseCode = enterpriseCode;
            resultCnt = 0;
            int cnt = 0;
            foreach (int source in lstSource)
            {
                switch (source)
                {
                    case -1: // テーブルクリア
                        status = SetStockAcPayHistClear();
                        break;
                    case 0: // 売上
                        status = SetStockAcPayHistFromSales(out cnt);
                        break;
                    case 1: // 売上履歴
                        status = SetStockAcPayHistFromSalesHist(out cnt);
                        break;
                    case 2: // 仕入
                        status = SetStockAcPayHistFromStockSlip(out cnt);
                        break;
                    case 3: // 仕入履歴
                        status = SetStockAcPayHistFromStockSlipHist(out cnt);
                        break;
                    // 2009/03/23 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //case 4: // 在庫移動
                    //    status = SetStockAcPayHistFromStockMove(out cnt);
                    //    break;
                    case 4:
                    case 6:
                        {
                            if (source == 4)
                                //入荷、出荷受払作成
                                status = SetStockAcPayHistFromStockMove(out cnt, 0);
                            else
                                //入荷のみ受払作成
                                status = SetStockAcPayHistFromStockMove(out cnt, 1);

                        }
                        break;
                    // 2009/03/23 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    case 5: // 在庫調整
                        status = SetStockAcPayHistFromStockAdjust(out cnt);
                        break;
                }
                if (status == 0)
                {
                    resultCnt += cnt;
                }
                else
                {
                    resultCnt = 0;
                    break;
                }
            }
            return status;
        }

        /// <summary>
        /// 在庫受払履歴データクリア
        /// </summary>
        private int SetStockAcPayHistClear()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;// ADD　2019/10/22 田建委 SQLSERVER2017対応
            try
            {
                sqlCommand = new SqlCommand();// ADD　2019/10/22 田建委 SQLSERVER2017対応

                //sqlCommand.CommandText = string.Format("DELETE FROM STOCKACPAYHISTRF WHERE ENTERPRISECODERF = '{0}'", _enterpriseCode);
                // --- UPD　2019/10/22 田建委 SQLSERVER2017対応---------->>>>
                //serv.Databases[sqlConnection.Database].ExecuteNonQuery("TRUNCATE TABLE STOCKACPAYHISTRF ");
                sqlCommand.CommandText = string.Format("TRUNCATE TABLE STOCKACPAYHISTRF");
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.ExecuteNonQuery();
                //serv.Databases[sqlConnection.Database].ExecuteNonQuery("TRUNCATE TABLE STOCKACPAYHISTRF "); // DEL Lizc 2013/07/01 Redmine#36971
                //this.ExecuteSql(serv, sqlConnection.Database, "TRUNCATE TABLE STOCKACPAYHISTRF ");  // ADD Lizc 2013/07/01 Redmine#36971
                // --- UPD　2019/10/22 田建委 SQLSERVER2017対応----------<<<<
                status = 0;
            }
            // --- UPD 2011/09/06---------->>>>>
            //catch
            //{
            //    return -1;
            //}
            catch (SqlException ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistClear", "在庫受払履歴データクリア[" +ex.Message + "]", ex.Number);
            }
            catch (Exception ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistClear", "在庫受払履歴データクリア[" + ex.Message + "]", status);
            }
            // --- UPD 2011/09/06----------<<<<<
            finally
            {
                // --- ADD　2019/10/22 田建委 SQLSERVER2017対応---------->>>>
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                // --- ADD　2019/10/22 田建委 SQLSERVER2017対応---------->>>>
            }

            // --- ADD 2011/09/06---------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistClear", "在庫受払履歴データクリア", status);
            }
            // --- ADD 2011/09/06----------<<<<<

            return status;
        }

        /// <summary>
        /// 売上から在庫受払履歴データ設定(貸出)
        /// </summary>
        /// <param name="cnt">処理データカウンタ</param>
        private int SetStockAcPayHistFromSales(out int cnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            cnt = 0;
            if (lstSec == null)
                GetSectionInfo();

            #region [ 売上から在庫受払情報取得 ]
            SqlConnection sqlCon = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            try
            {
                sqlCon = new SqlConnection(connectionText);
                sqlCon.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlCon;

                #region [ 売上データ取得クエリ ]
                string sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "SLIP.LOGICALDELETECODERF," + Environment.NewLine;   // 2010/10/13 Add
                sqlText += "SLIP.SALESINPSECCDRF," + Environment.NewLine;
                sqlText += "SLIP.SALESDATERF," + Environment.NewLine;
                sqlText += "SLIP.ADDUPADATERF," + Environment.NewLine;
                sqlText += "SLIP.SHIPMENTDAYRF," + Environment.NewLine; // 2009/03/27 MANTIS 12822
                sqlText += "SLIP.INPUTAGENCDRF," + Environment.NewLine;
                sqlText += "SLIP.INPUTAGENNMRF," + Environment.NewLine;
                sqlText += "SLIP.CUSTOMERCODERF," + Environment.NewLine;
                sqlText += "SLIP.CUSTOMERSNMRF," + Environment.NewLine;
                sqlText += "SLIP.CUSTSLIPNORF," + Environment.NewLine;
                sqlText += "DTIL.SALESSLIPNUMRF," + Environment.NewLine;
                sqlText += "DTIL.SALESROWNORF," + Environment.NewLine;
                sqlText += "DTIL.SECTIONCODERF," + Environment.NewLine;
                sqlText += "DTIL.SALESSLIPDTLNUMRF," + Environment.NewLine;
                sqlText += "DTIL.SALESSLIPCDDTLRF," + Environment.NewLine;
                sqlText += "DTIL.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "DTIL.MAKERNAMERF," + Environment.NewLine;
                sqlText += "DTIL.GOODSNORF," + Environment.NewLine;
                sqlText += "DTIL.GOODSNAMERF," + Environment.NewLine;
                sqlText += "DTIL.BLGOODSCODERF," + Environment.NewLine;
                sqlText += "DTIL.BLGOODSFULLNAMERF," + Environment.NewLine;
                sqlText += "DTIL.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "DTIL.WAREHOUSENAMERF," + Environment.NewLine;
                sqlText += "DTIL.WAREHOUSESHELFNORF," + Environment.NewLine;
                sqlText += "DTIL.LISTPRICETAXEXCFLRF," + Environment.NewLine;
                sqlText += "DTIL.SALESUNPRCTAXEXCFLRF," + Environment.NewLine;
                sqlText += "DTIL.SALESUNITCOSTRF," + Environment.NewLine;
                sqlText += "DTIL.SHIPMENTCNTRF," + Environment.NewLine;
                sqlText += "DTIL.SALESMONEYTAXEXCRF," + Environment.NewLine;
                sqlText += "DTIL.COSTRF," + Environment.NewLine;
                sqlText += "DTIL.SALESSLIPCDDTLRF," + Environment.NewLine;
                // 2010/10/20 >>>
                //sqlText += "DTIL.SALESORDERDIVCDRF" + Environment.NewLine;
                sqlText += "DTIL.SALESORDERDIVCDRF," + Environment.NewLine;
                // 2010/10/20 <<<
                // 2010/10/21 >>>
                //sqlText += "DTIL.ACPTANODRREMAINCNTRF" + Environment.NewLine;  // 2010/10/20 Add
                sqlText += "DTIL.ACPTANODRREMAINCNTRF," + Environment.NewLine;
                // 2010/10/21 <<<
                // 2010/10/21 Add >>>
                sqlText += "DTL2.SHIPMENTCNTRF AS SHIPMENTCNTRF2," + Environment.NewLine;
                sqlText += "DTL2.SALESSLIPCDDTLRF AS SALESSLIPCDDTLRF2," + Environment.NewLine;
                sqlText += "SLP2.ADDUPADATERF AS ADDUPADATERF2" + Environment.NewLine;
                // 2010/10/21 Add <<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SALESSLIPRF AS SLIP" + Environment.NewLine;
                sqlText += "  INNER JOIN SALESDETAILRF AS DTIL" + Environment.NewLine;
                sqlText += "ON SLIP.ACPTANODRSTATUSRF = DTIL.ACPTANODRSTATUSRF AND  SLIP.SALESSLIPNUMRF = DTIL.SALESSLIPNUMRF" + Environment.NewLine;
                // 2010/10/21 Add >>>
                sqlText += "  LEFT JOIN SALESDETAILRF AS DTL2" + Environment.NewLine;
                sqlText += "  ON DTIL.SALESSLIPDTLNUMRF=DTL2.SALESSLIPDTLNUMSRCRF" + Environment.NewLine;
                sqlText += "  AND SLIP.ACPTANODRSTATUSRF=DTL2.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                sqlText += "  LEFT JOIN SALESSLIPRF AS SLP2" + Environment.NewLine;
                sqlText += "  ON SLP2.ACPTANODRSTATUSRF = DTL2.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += "  AND  SLP2.SALESSLIPNUMRF = DTL2.SALESSLIPNUMRF" + Environment.NewLine;
                // 2010/10/21 Add <<<
                sqlText += "WHERE SLIP.ACPTANODRSTATUSRF = 40";
                #endregion
                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 300;// 2010/10/12 Add

                ArrayList innerList = null;
                DateTime prevDateTime = DateTime.MaxValue;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockAcPayHistWork stockAcPayHistWork = new StockAcPayHistWork();
                    StockAcPayHistWork stockAcPayHistDeleteWork = null;

                    stockAcPayHistWork.LogicalDeleteCode = 0;
                    // 2009/03/27 MANTIS 12822 >>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                    //stockAcPayHistWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    //stockAcPayHistWork.AcPaySlipCd = 20; // 20:売上固定

                    stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
                    stockAcPayHistWork.AcPaySlipCd = 22; // 22:出荷
                    // 2009/03/27 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    stockAcPayHistWork.AcPaySlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    stockAcPayHistWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                    int kubun = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                    if (kubun == 0)
                        stockAcPayHistWork.AcPayTransCd = 10; // 0:売上	 -> 10:通常伝票
                    else if (kubun == 1)
                        stockAcPayHistWork.AcPayTransCd = 11; // 1:返品	 -> 11:返品

                    stockAcPayHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPSECCDRF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.InputSectionCd))
                    {
                        stockAcPayHistWork.InputSectionGuidNm = lstSec[stockAcPayHistWork.InputSectionCd].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.InputSectionGuidNm = "";
                    }
                    stockAcPayHistWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
                    stockAcPayHistWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
                    stockAcPayHistWork.MoveStatus = 0; // 0:移動対象外
                    stockAcPayHistWork.CustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNORF")).ToString();
                    stockAcPayHistWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
                    stockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockAcPayHistWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockAcPayHistWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockAcPayHistWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    stockAcPayHistWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    stockAcPayHistWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.SectionCode))
                    {
                        stockAcPayHistWork.SectionGuideNm = lstSec[stockAcPayHistWork.SectionCode].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.SectionGuideNm = "";
                    }
                    stockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockAcPayHistWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockAcPayHistWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    stockAcPayHistWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    stockAcPayHistWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    stockAcPayHistWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    stockAcPayHistWork.OpenPriceDiv = 0; // 0:通常
                    stockAcPayHistWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    stockAcPayHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    stockAcPayHistWork.StockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                    stockAcPayHistWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    stockAcPayHistWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));

                    // 在庫管理する条件
                    // ① 倉庫コードが設定されている
                    // ② 売上在庫取寄せ区分が 1:在庫
                    // ③ 出荷数が0以外
                    // ④ 売上伝票区分(明細)が 0:売上 1:返品 の場合
                    // 2010/10/08 Add >>>
                    // ⑤ 品番がセットされている
                    // 2010/10/08 Add <<<
                    int slipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                    int orderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                    string goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // 2010/10/08 Add
                    // 2010/10/08 >>>
                    //if (string.IsNullOrEmpty(stockAcPayHistWork.WarehouseCode) ||
                    //    orderDivCd != 1 ||
                    //    stockAcPayHistWork.ShipmentCnt == 0 ||
                    //    (slipCdDtl != 0 && slipCdDtl != 1))
                    //    continue;
                    if (string.IsNullOrEmpty(stockAcPayHistWork.WarehouseCode) ||
                        orderDivCd != 1 ||
                        stockAcPayHistWork.ShipmentCnt == 0 ||
                        (slipCdDtl != 0 && slipCdDtl != 1) ||
                        string.IsNullOrEmpty(goodsNo))
                        continue;
                    // 2010/10/08 <<<

                    // 2010/10/13 Add >>>
                    int logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    double acptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));    // 2010/10/20 Add
                    // 2010/10/20 >>>
                    // 貸出分で受注残数が0の場合は出荷データ計上残区分が『残さない』で作成されたデータの為コンバート対象外
                    //if (logicalDeleteCode == 1)
                    // 2010/10/21 >>>
                    //if (logicalDeleteCode == 1 && acptAnOdrRemainCnt != 0.0)
                    if (logicalDeleteCode == 1)
                    // 2010/10/21 <<<
                    // 2010/10/20 <<<
                    {
                        // 2010/10/21 Add >>>
                        if (acptAnOdrRemainCnt != 0.0)
                        {
                            // 2010/10/21 Add <<<
                            stockAcPayHistDeleteWork = new StockAcPayHistWork();
                            stockAcPayHistDeleteWork.LogicalDeleteCode = 0;

                            stockAcPayHistDeleteWork.IoGoodsDay = stockAcPayHistWork.IoGoodsDay;
                            stockAcPayHistDeleteWork.AcPaySlipCd = 22; // 22:出荷
                            stockAcPayHistDeleteWork.AcPaySlipNum = stockAcPayHistWork.AcPaySlipNum;
                            stockAcPayHistDeleteWork.AcPaySlipRowNo = stockAcPayHistWork.AcPaySlipRowNo;
                            stockAcPayHistDeleteWork.AcPayTransCd = 21; // 21:削除
                            stockAcPayHistDeleteWork.InputSectionCd = stockAcPayHistWork.InputSectionCd;
                            stockAcPayHistDeleteWork.InputSectionGuidNm = stockAcPayHistWork.InputSectionGuidNm;
                            stockAcPayHistDeleteWork.InputAgenCd = stockAcPayHistWork.InputAgenCd;
                            stockAcPayHistDeleteWork.InputAgenNm = stockAcPayHistWork.InputAgenNm;
                            stockAcPayHistDeleteWork.MoveStatus = 0; // 0:移動対象外
                            stockAcPayHistDeleteWork.CustSlipNo = stockAcPayHistWork.CustSlipNo;
                            stockAcPayHistDeleteWork.SlipDtlNum = stockAcPayHistWork.SlipDtlNum;
                            stockAcPayHistDeleteWork.GoodsMakerCd = stockAcPayHistWork.GoodsMakerCd;
                            stockAcPayHistDeleteWork.MakerName = stockAcPayHistWork.MakerName;
                            stockAcPayHistDeleteWork.GoodsNo = stockAcPayHistWork.GoodsNo;
                            stockAcPayHistDeleteWork.GoodsName = stockAcPayHistWork.GoodsName;
                            stockAcPayHistDeleteWork.BLGoodsCode = stockAcPayHistWork.BLGoodsCode;
                            stockAcPayHistDeleteWork.BLGoodsFullName = stockAcPayHistWork.BLGoodsFullName;
                            stockAcPayHistDeleteWork.SectionCode = stockAcPayHistWork.SectionCode;
                            stockAcPayHistDeleteWork.SectionGuideNm = stockAcPayHistWork.SectionGuideNm;
                            stockAcPayHistDeleteWork.WarehouseCode = stockAcPayHistWork.WarehouseCode;
                            stockAcPayHistDeleteWork.WarehouseName = stockAcPayHistWork.WarehouseName;
                            stockAcPayHistDeleteWork.ShelfNo = stockAcPayHistWork.ShelfNo;
                            stockAcPayHistDeleteWork.CustomerCode = stockAcPayHistWork.CustomerCode;
                            stockAcPayHistDeleteWork.CustomerSnm = stockAcPayHistWork.CustomerSnm;
                            stockAcPayHistDeleteWork.ShipmentCnt = -stockAcPayHistWork.ShipmentCnt;
                            stockAcPayHistDeleteWork.OpenPriceDiv = 0; // 0:通常
                            stockAcPayHistDeleteWork.ListPriceTaxExcFl = stockAcPayHistWork.ListPriceTaxExcFl;
                            stockAcPayHistDeleteWork.StockUnitPriceFl = stockAcPayHistWork.StockUnitPriceFl;
                            stockAcPayHistDeleteWork.StockPrice = -stockAcPayHistWork.StockPrice;
                            stockAcPayHistDeleteWork.SalesUnPrcTaxExcFl = stockAcPayHistWork.SalesUnPrcTaxExcFl;
                            stockAcPayHistDeleteWork.SalesMoney = -stockAcPayHistWork.SalesMoney;
                            // 2010/10/21 Add >>>
                        }
                        else
                        {
                            // 未計上残さないで作成されたデータの為、貸出返品データを作成する
                            int salesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF2"));
                            if (salesSlipCdDtl == 0)
                            {
                                // ただし計上先の売上データの売上伝票区分（明細）が売上の時のみ作成
                                stockAcPayHistDeleteWork = new StockAcPayHistWork();
                                stockAcPayHistDeleteWork.LogicalDeleteCode = 0;

                                stockAcPayHistDeleteWork.IoGoodsDay = stockAcPayHistWork.IoGoodsDay;
                                stockAcPayHistDeleteWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF2"));
                                stockAcPayHistDeleteWork.AcPaySlipCd = 22; // 22:出荷
                                stockAcPayHistDeleteWork.AcPaySlipNum = stockAcPayHistWork.AcPaySlipNum;
                                stockAcPayHistDeleteWork.AcPaySlipRowNo = stockAcPayHistWork.AcPaySlipRowNo;
                                stockAcPayHistDeleteWork.AcPayTransCd = 11; // 11:返品
                                stockAcPayHistDeleteWork.InputSectionCd = stockAcPayHistWork.InputSectionCd;
                                stockAcPayHistDeleteWork.InputSectionGuidNm = stockAcPayHistWork.InputSectionGuidNm;
                                stockAcPayHistDeleteWork.InputAgenCd = stockAcPayHistWork.InputAgenCd;
                                stockAcPayHistDeleteWork.InputAgenNm = stockAcPayHistWork.InputAgenNm;
                                stockAcPayHistDeleteWork.MoveStatus = 0; // 0:移動対象外
                                stockAcPayHistDeleteWork.CustSlipNo = stockAcPayHistWork.CustSlipNo;
                                stockAcPayHistDeleteWork.SlipDtlNum = stockAcPayHistWork.SlipDtlNum;
                                stockAcPayHistDeleteWork.GoodsMakerCd = stockAcPayHistWork.GoodsMakerCd;
                                stockAcPayHistDeleteWork.MakerName = stockAcPayHistWork.MakerName;
                                stockAcPayHistDeleteWork.GoodsNo = stockAcPayHistWork.GoodsNo;
                                stockAcPayHistDeleteWork.GoodsName = stockAcPayHistWork.GoodsName;
                                stockAcPayHistDeleteWork.BLGoodsCode = stockAcPayHistWork.BLGoodsCode;
                                stockAcPayHistDeleteWork.BLGoodsFullName = stockAcPayHistWork.BLGoodsFullName;
                                stockAcPayHistDeleteWork.SectionCode = stockAcPayHistWork.SectionCode;
                                stockAcPayHistDeleteWork.SectionGuideNm = stockAcPayHistWork.SectionGuideNm;
                                stockAcPayHistDeleteWork.WarehouseCode = stockAcPayHistWork.WarehouseCode;
                                stockAcPayHistDeleteWork.WarehouseName = stockAcPayHistWork.WarehouseName;
                                stockAcPayHistDeleteWork.ShelfNo = stockAcPayHistWork.ShelfNo;
                                stockAcPayHistDeleteWork.CustomerCode = stockAcPayHistWork.CustomerCode;
                                stockAcPayHistDeleteWork.CustomerSnm = stockAcPayHistWork.CustomerSnm;
                                double ShipmentCnt2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF2"));
                                stockAcPayHistDeleteWork.ShipmentCnt = ShipmentCnt2 - stockAcPayHistWork.ShipmentCnt;
                                stockAcPayHistDeleteWork.OpenPriceDiv = 0; // 0:通常
                                stockAcPayHistDeleteWork.ListPriceTaxExcFl = stockAcPayHistWork.ListPriceTaxExcFl;
                                stockAcPayHistDeleteWork.StockUnitPriceFl = stockAcPayHistWork.StockUnitPriceFl;
                                stockAcPayHistDeleteWork.StockPrice = (long)stockAcPayHistWork.StockUnitPriceFl * (long)stockAcPayHistDeleteWork.ShipmentCnt;
                                stockAcPayHistDeleteWork.SalesUnPrcTaxExcFl = stockAcPayHistWork.SalesUnPrcTaxExcFl;
                                stockAcPayHistDeleteWork.SalesMoney = (long)stockAcPayHistWork.SalesUnPrcTaxExcFl * (long)stockAcPayHistDeleteWork.ShipmentCnt;
                                if (stockAcPayHistDeleteWork.ShipmentCnt == 0.0)
                                {
                                    // 返品数が0の場合は未計上分が0の為返品データを作成しない
                                    stockAcPayHistDeleteWork = null;
                                }
                            }
                            else
                            {
                                stockAcPayHistDeleteWork = null;
                            }
                        }
                        // 2010/10/21 Add <<<
                    }
                    else
                    {
                        stockAcPayHistDeleteWork = null;
                    }
                    // 2010/10/13 Add <<<
                    if (stockAcPayHistWork.IoGoodsDay != prevDateTime) // 売上日付が前回データと違うか？（初回目ふくめ）                        
                    {
                        if (innerList != null && innerList.Count > 0)
                        {
                            if (stockAcPayHistDB == null)
                                stockAcPayHistDB = new StockAcPayHistDB();
                            //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                            status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                            if (status == 0)
                                cnt += innerList.Count;
                            else
                                break;
                        }
                        innerList = new ArrayList();
                        prevDateTime = stockAcPayHistWork.IoGoodsDay;
                    }
                    innerList.Add(stockAcPayHistWork);
                    // 2010/10/13 Add >>>
                    if (stockAcPayHistDeleteWork != null)
                        innerList.Add(stockAcPayHistDeleteWork);
                    // 2010/10/13 Add <<<

                }
                if (innerList != null && innerList.Count > 0)
                {
                    if (stockAcPayHistDB == null)
                        stockAcPayHistDB = new StockAcPayHistDB();
                    //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                    status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        cnt += innerList.Count;
                }
                else if (cnt == 0) // 0件は正常と見なす。
                {
                    status = 0;
                }
            }
            // --- UPD 2011/09/06---------->>>>>
            // catch { }
            catch (SqlException ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromSales", "売上から在庫受払履歴データ設定(貸出)[" + ex.Message + "]", ex.Number);
            }
            catch (Exception ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromSales", "売上から在庫受払履歴データ設定(貸出)[" + ex.Message + "]", status);
            }
            // --- UPD 2011/09/06----------<<<<<
            finally
            {
                if (myReader != null)
                    myReader.Dispose();
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlCon != null)
                    sqlCon.Dispose();
            }
            #endregion

            // --- ADD 2011/09/06---------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromSales", "売上から在庫受払履歴データ設定(貸出)", status);
            }
            // --- ADD 2011/09/06----------<<<<<

            return status;
        }

        /// <summary>
        /// 売上履歴から在庫受払履歴データ設定
        /// </summary>
        /// <param name="cnt">処理データカウンタ</param>
        private int SetStockAcPayHistFromSalesHist(out int cnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            cnt = 0;
            if (lstSec == null)
                GetSectionInfo();

            #region [ 売上履歴から在庫受払情報取得 ]
            SqlConnection sqlCon = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            try
            {
                sqlCon = new SqlConnection(connectionText);
                sqlCon.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlCon;

                string sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "SHST.LOGICALDELETECODERF," + Environment.NewLine;   // 2010/10/13 Add
                sqlText += "SHST.SALESINPSECCDRF," + Environment.NewLine;
                sqlText += "SHST.SALESDATERF," + Environment.NewLine;
                sqlText += "SHST.ADDUPADATERF," + Environment.NewLine;
                sqlText += "SHST.INPUTAGENCDRF," + Environment.NewLine;
                sqlText += "SHST.INPUTAGENNMRF," + Environment.NewLine;
                sqlText += "SHST.CUSTOMERCODERF," + Environment.NewLine;
                sqlText += "SHST.CUSTOMERSNMRF," + Environment.NewLine;

                sqlText += "DTHS.SALESSLIPNUMRF," + Environment.NewLine;
                sqlText += "DTHS.SALESROWNORF," + Environment.NewLine;
                sqlText += "DTHS.SECTIONCODERF," + Environment.NewLine;
                sqlText += "DTHS.SALESSLIPDTLNUMRF," + Environment.NewLine;
                sqlText += "DTHS.ACPTANODRSTATUSSRCRF," + Environment.NewLine;  // 2010/10/20 Add
                sqlText += "DTHS.SALESSLIPCDDTLRF," + Environment.NewLine;
                sqlText += "DTHS.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "DTHS.MAKERNAMERF," + Environment.NewLine;
                sqlText += "DTHS.GOODSNORF," + Environment.NewLine;
                sqlText += "DTHS.GOODSNAMERF," + Environment.NewLine;
                sqlText += "DTHS.BLGOODSCODERF," + Environment.NewLine;
                sqlText += "DTHS.BLGOODSFULLNAMERF," + Environment.NewLine;
                sqlText += "DTHS.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "DTHS.WAREHOUSENAMERF," + Environment.NewLine;
                sqlText += "DTHS.WAREHOUSESHELFNORF," + Environment.NewLine;
                sqlText += "DTHS.LISTPRICETAXEXCFLRF," + Environment.NewLine;
                sqlText += "DTHS.SALESUNPRCTAXEXCFLRF," + Environment.NewLine;
                sqlText += "DTHS.SALESUNITCOSTRF," + Environment.NewLine;
                sqlText += "DTHS.SHIPMENTCNTRF," + Environment.NewLine;
                sqlText += "DTHS.SALESMONEYTAXEXCRF," + Environment.NewLine;
                sqlText += "DTHS.COSTRF," + Environment.NewLine;
                sqlText += "DTHS.SALESSLIPCDDTLRF," + Environment.NewLine;
                sqlText += "DTHS.SALESORDERDIVCDRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SALESHISTORYRF AS SHST" + Environment.NewLine;
                sqlText += "  INNER JOIN SALESHISTDTLRF AS DTHS" + Environment.NewLine;
                sqlText += "ON SHST.ACPTANODRSTATUSRF = DTHS.ACPTANODRSTATUSRF AND  SHST.SALESSLIPNUMRF = DTHS.SALESSLIPNUMRF";

                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 300;// 2010/10/12 Add

                ArrayList innerList = null;
                // --- DEL 2020/06/18 佐々木亘 警告対応 ---------->>>>>
                //ArrayList innerDeleteList = null; // 2010/10/13 Add
                // --- DEL 2020/06/18 佐々木亘 警告対応 ----------<<<<<
                DateTime prevDateTime = DateTime.MaxValue;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockAcPayHistWork stockAcPayHistWork = new StockAcPayHistWork();
                    StockAcPayHistWork stockAcPayHistDeleteWork = null;   // 2010/10/13 Add

                    stockAcPayHistWork.LogicalDeleteCode = 0;
                    // 2010/10/20 Add >>>
                    // 貸出計上分は入出荷日をセットしない
                    int acptAnOdrStatusSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSRCRF"));
                    if (acptAnOdrStatusSrc == 40)
                    {
                        stockAcPayHistWork.IoGoodsDay = DateTime.MinValue;
                    }
                    else
                    // 2010/10/20 Add <<<
                        stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                    stockAcPayHistWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    stockAcPayHistWork.AcPaySlipCd = 20; // 20:売上固定
                    stockAcPayHistWork.AcPaySlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    stockAcPayHistWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                    int kubun = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                    if (kubun == 0)
                        stockAcPayHistWork.AcPayTransCd = 10; // 0:売上	 -> 10:通常伝票
                    else if (kubun == 1)
                        stockAcPayHistWork.AcPayTransCd = 11; // 1:返品	 -> 11:返品

                    stockAcPayHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPSECCDRF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.InputSectionCd))
                    {
                        stockAcPayHistWork.InputSectionGuidNm = lstSec[stockAcPayHistWork.InputSectionCd].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.InputSectionGuidNm = "";
                    }
                    stockAcPayHistWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
                    stockAcPayHistWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
                    stockAcPayHistWork.MoveStatus = 0; // 0:移動対象外
                    stockAcPayHistWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
                    stockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockAcPayHistWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockAcPayHistWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockAcPayHistWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    stockAcPayHistWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    stockAcPayHistWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.SectionCode))
                    {
                        stockAcPayHistWork.SectionGuideNm = lstSec[stockAcPayHistWork.SectionCode].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.SectionGuideNm = "";
                    }
                    stockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockAcPayHistWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockAcPayHistWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    stockAcPayHistWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    stockAcPayHistWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    stockAcPayHistWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    stockAcPayHistWork.OpenPriceDiv = 0; // 0 : 通常
                    stockAcPayHistWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    stockAcPayHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    stockAcPayHistWork.StockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                    stockAcPayHistWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    stockAcPayHistWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));

                    // 在庫管理する条件
                    // ① 倉庫コードが設定されている
                    // ② 売上在庫取寄せ区分が 1:在庫
                    // ③ 出荷数が0以外
                    // ④ 売上伝票区分(明細)が 0:売上 1:返品 の場合
                    // 2010/10/08 Add >>>
                    // ⑤ 品番がセットされている
                    // 2010/10/08 Add <<<
                    int slipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                    int orderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                    string goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // 2010/10/08 Add
                    // 2010/10/08 >>>
                    //if (string.IsNullOrEmpty(stockAcPayHistWork.WarehouseCode) ||
                    //    orderDivCd != 1 ||
                    //    stockAcPayHistWork.ShipmentCnt == 0 ||
                    //    (slipCdDtl != 0 && slipCdDtl != 1))
                    //    continue;
                    if (string.IsNullOrEmpty(stockAcPayHistWork.WarehouseCode) ||
                        orderDivCd != 1 ||
                        stockAcPayHistWork.ShipmentCnt == 0 ||
                        (slipCdDtl != 0 && slipCdDtl != 1) ||
                        string.IsNullOrEmpty(goodsNo))
                        continue;
                    // 2010/10/08 <<<

                    // 2010/10/13 Add >>>
                    int logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    if (logicalDeleteCode == 1)
                    {
                        stockAcPayHistDeleteWork = new StockAcPayHistWork();
                        stockAcPayHistDeleteWork.LogicalDeleteCode = 0;
                        stockAcPayHistDeleteWork.IoGoodsDay = stockAcPayHistWork.IoGoodsDay;
                        stockAcPayHistDeleteWork.AddUpADate = stockAcPayHistWork.AddUpADate;
                        stockAcPayHistDeleteWork.AcPaySlipCd = 20; // 20:売上固定
                        stockAcPayHistDeleteWork.AcPaySlipNum = stockAcPayHistWork.AcPaySlipNum;
                        stockAcPayHistDeleteWork.AcPaySlipRowNo = stockAcPayHistWork.AcPaySlipRowNo;
                        stockAcPayHistDeleteWork.AcPayTransCd = 21; // 21:削除
                        stockAcPayHistDeleteWork.InputSectionCd = stockAcPayHistWork.InputSectionCd;
                        stockAcPayHistDeleteWork.InputSectionGuidNm = stockAcPayHistWork.InputSectionGuidNm;
                        stockAcPayHistDeleteWork.InputAgenCd = stockAcPayHistWork.InputAgenCd;
                        stockAcPayHistDeleteWork.InputAgenNm = stockAcPayHistWork.InputAgenNm;
                        stockAcPayHistDeleteWork.MoveStatus = 0; // 0:移動対象外
                        stockAcPayHistDeleteWork.SlipDtlNum = stockAcPayHistWork.SlipDtlNum;
                        stockAcPayHistDeleteWork.GoodsMakerCd = stockAcPayHistWork.GoodsMakerCd;
                        stockAcPayHistDeleteWork.MakerName = stockAcPayHistWork.MakerName;
                        stockAcPayHistDeleteWork.GoodsNo = stockAcPayHistWork.GoodsNo;
                        stockAcPayHistDeleteWork.GoodsName = stockAcPayHistWork.GoodsName;
                        stockAcPayHistDeleteWork.BLGoodsCode = stockAcPayHistWork.BLGoodsCode;
                        stockAcPayHistDeleteWork.BLGoodsFullName = stockAcPayHistWork.BLGoodsFullName;
                        stockAcPayHistDeleteWork.SectionCode = stockAcPayHistWork.SectionCode;
                        stockAcPayHistDeleteWork.SectionGuideNm = stockAcPayHistWork.SectionGuideNm;
                        stockAcPayHistDeleteWork.WarehouseCode = stockAcPayHistWork.WarehouseCode;
                        stockAcPayHistDeleteWork.WarehouseName = stockAcPayHistWork.WarehouseName;
                        stockAcPayHistDeleteWork.ShelfNo = stockAcPayHistWork.ShelfNo;
                        stockAcPayHistDeleteWork.CustomerCode = stockAcPayHistWork.CustomerCode;
                        stockAcPayHistDeleteWork.CustomerSnm = stockAcPayHistWork.CustomerSnm;
                        stockAcPayHistDeleteWork.ShipmentCnt = -stockAcPayHistWork.ShipmentCnt;
                        stockAcPayHistDeleteWork.OpenPriceDiv = 0; // 0 : 通常
                        stockAcPayHistDeleteWork.ListPriceTaxExcFl = stockAcPayHistWork.ListPriceTaxExcFl;
                        stockAcPayHistDeleteWork.StockUnitPriceFl = stockAcPayHistWork.StockUnitPriceFl;
                        stockAcPayHistDeleteWork.StockPrice = -stockAcPayHistWork.StockPrice;
                        stockAcPayHistDeleteWork.SalesUnPrcTaxExcFl = stockAcPayHistWork.SalesUnPrcTaxExcFl;
                        stockAcPayHistDeleteWork.SalesMoney = -stockAcPayHistWork.SalesMoney;
                    }
                    else
                    {
                        stockAcPayHistDeleteWork = null;
                    }
                    // 2010/10/13 Add <<<
                    if (stockAcPayHistWork.IoGoodsDay != prevDateTime) // 売上日付が前回データと違うか？（初回目ふくめ）                        
                    {
                        if (innerList != null)
                        {
                            if (stockAcPayHistDB == null)
                                stockAcPayHistDB = new StockAcPayHistDB();
                            //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                            status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                            if (status == 0)
                                cnt += innerList.Count;
                            else
                                break;
                        }
                        innerList = new ArrayList();
                        prevDateTime = stockAcPayHistWork.IoGoodsDay;
                    }
                    innerList.Add(stockAcPayHistWork);
                    // 2010/10/13 Add >>>
                    if (stockAcPayHistDeleteWork != null)
                        innerList.Add(stockAcPayHistDeleteWork);
                    // 2010/10/13 Add <<<
                }
                if (innerList != null && innerList.Count > 0)
                {
                    if (stockAcPayHistDB == null)
                        stockAcPayHistDB = new StockAcPayHistDB();
                    //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                    status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        cnt += innerList.Count;
                }
                else if (cnt == 0) // 0件は正常と見なす。
                {
                    status = 0;
                }
            }
            // --- UPD 2011/09/06---------->>>>>
            // catch {}
            catch (SqlException ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromSalesHist", "売上履歴から在庫受払履歴データ設定[" + ex.Message + "]", ex.Number);
            }
            catch (Exception ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromSalesHist", "売上履歴から在庫受払履歴データ設定[" + ex.Message + "]", status);
            }
            // --- UPD 2011/09/06----------<<<<<
            finally
            {
                if (myReader != null)
                    myReader.Dispose();
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlCon != null)
                    sqlCon.Dispose();
            }
            #endregion

            // --- ADD 2011/09/06---------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromSalesHist", "売上履歴から在庫受払履歴データ設定", status);
            }
            // --- ADD 2011/09/06----------<<<<<

            return status;
        }

        /// <summary>
        /// 仕入から在庫受払履歴データ設定
        /// </summary>
        /// <param name="cnt">処理データカウンタ</param>
        private int SetStockAcPayHistFromStockSlip(out int cnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            cnt = 0;
            if (lstSec == null)
                GetSectionInfo();

            #region [ 仕入から在庫受払情報取得 ]
            SqlConnection sqlCon = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            try
            {
                sqlCon = new SqlConnection(connectionText);
                sqlCon.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlCon;

                string sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "STOK.SECTIONCODERF," + Environment.NewLine;
                sqlText += "STOK.STOCKDATERF," + Environment.NewLine;
                sqlText += "STOK.STOCKADDUPADATERF," + Environment.NewLine;
                sqlText += "STOK.STOCKINPUTCODERF," + Environment.NewLine;
                sqlText += "STOK.STOCKINPUTNAMERF," + Environment.NewLine;
                sqlText += "STOK.SUPPLIERCDRF," + Environment.NewLine;
                sqlText += "STOK.SUPPLIERSNMRF," + Environment.NewLine;
                sqlText += "STOK.PARTYSALESLIPNUMRF," + Environment.NewLine;

                sqlText += "STDT.SUPPLIERSLIPNORF," + Environment.NewLine;
                sqlText += "STDT.STOCKROWNORF," + Environment.NewLine;
                sqlText += "STDT.STOCKSLIPDTLNUMRF," + Environment.NewLine;
                sqlText += "STDT.STOCKSLIPCDDTLRF," + Environment.NewLine;
                sqlText += "STDT.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "STDT.MAKERNAMERF," + Environment.NewLine;
                sqlText += "STDT.GOODSNORF," + Environment.NewLine;
                sqlText += "STDT.GOODSNAMERF," + Environment.NewLine;
                sqlText += "STDT.BLGOODSCODERF," + Environment.NewLine;
                sqlText += "STDT.BLGOODSFULLNAMERF," + Environment.NewLine;
                sqlText += "STDT.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "STDT.WAREHOUSENAMERF," + Environment.NewLine;
                sqlText += "STDT.WAREHOUSESHELFNORF," + Environment.NewLine;
                sqlText += "STDT.LISTPRICETAXEXCFLRF," + Environment.NewLine;
                sqlText += "STDT.STOCKUNITPRICEFLRF," + Environment.NewLine;
                sqlText += "STDT.STOCKCOUNTRF," + Environment.NewLine;
                sqlText += "STDT.STOCKPRICETAXEXCRF," + Environment.NewLine;
                sqlText += "STDT.STOCKORDERDIVCDRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKSLIPRF AS STOK" + Environment.NewLine;
                sqlText += "  INNER JOIN STOCKDETAILRF AS STDT" + Environment.NewLine;
                sqlText += "ON STOK.SUPPLIERSLIPNORF = STDT.SUPPLIERSLIPNORF AND  STOK.SUPPLIERFORMALRF = STDT.SUPPLIERFORMALRF";

                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 300;// 2012/04/27 Add

                ArrayList innerList = null;
                DateTime prevDateTime = DateTime.MaxValue;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockAcPayHistWork stockAcPayHistWork = new StockAcPayHistWork();

                    stockAcPayHistWork.LogicalDeleteCode = 0;
                    stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
                    stockAcPayHistWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
                    stockAcPayHistWork.AcPaySlipCd = 10; // 10:仕入固定
                    stockAcPayHistWork.AcPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF")).ToString();
                    stockAcPayHistWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
                    int kubun = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
                    if (kubun == 0)
                        stockAcPayHistWork.AcPayTransCd = 10; // 0:仕入	 -> 10:通常伝票
                    else if (kubun == 1)
                        stockAcPayHistWork.AcPayTransCd = 11; // 1:返品	 -> 11:返品
                    else if (kubun == 2)
                        stockAcPayHistWork.AcPayTransCd = 12; // 2:値引	 -> 12:値引

                    stockAcPayHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.InputSectionCd))
                    {
                        stockAcPayHistWork.InputSectionGuidNm = lstSec[stockAcPayHistWork.InputSectionCd].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.InputSectionGuidNm = "";
                    }
                    stockAcPayHistWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
                    stockAcPayHistWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
                    stockAcPayHistWork.MoveStatus = 0; // 0 : 移動対象外
                    stockAcPayHistWork.CustSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                    stockAcPayHistWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
                    stockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockAcPayHistWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockAcPayHistWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockAcPayHistWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    stockAcPayHistWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    stockAcPayHistWork.SectionCode = stockAcPayHistWork.InputSectionCd;
                    if (lstSec.ContainsKey(stockAcPayHistWork.SectionCode))
                    {
                        stockAcPayHistWork.SectionGuideNm = lstSec[stockAcPayHistWork.SectionCode].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.SectionGuideNm = "";
                    }

                    stockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockAcPayHistWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockAcPayHistWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    stockAcPayHistWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    stockAcPayHistWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    stockAcPayHistWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
                    stockAcPayHistWork.OpenPriceDiv = 0; // 0:通常
                    stockAcPayHistWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    stockAcPayHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    stockAcPayHistWork.StockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));

                    // 在庫管理する条件
                    // ① 倉庫コードが設定されている
                    // ② 仕入在庫取寄せ区分が 1:在庫
                    // ③ 仕入数が0以外
                    // ④ 仕入伝票区分(明細)が 0:売上 1:返品 の場合
                    // 2010/10/08 Add >>>
                    // ⑤ 品番がセットされている
                    // 2010/10/08 Add <<<
                    int orderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
                    string goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // 2010/10/08 Add
                    // 2010/10/08 >>>
                    //if (string.IsNullOrEmpty(stockAcPayHistWork.WarehouseCode) ||
                    //    orderDivCd != 1 ||
                    //    stockAcPayHistWork.ArrivalCnt == 0 ||
                    //    (kubun != 0 && kubun != 1))
                    //    continue;
                    if (string.IsNullOrEmpty(stockAcPayHistWork.WarehouseCode) ||
                        orderDivCd != 1 ||
                        stockAcPayHistWork.ArrivalCnt == 0 ||
                        (kubun != 0 && kubun != 1) ||
                        string.IsNullOrEmpty(goodsNo))
                        continue;
                    // 2010/10/08 <<<

                    if (stockAcPayHistWork.IoGoodsDay != prevDateTime) // 売上日付が前回データと違うか？（初回目ふくめ）                        
                    {
                        if (innerList != null)
                        {
                            if (stockAcPayHistDB == null)
                                stockAcPayHistDB = new StockAcPayHistDB();
                            //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                            status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                            if (status == 0)
                                cnt += innerList.Count;
                            else
                                break;
                        }
                        innerList = new ArrayList();
                        prevDateTime = stockAcPayHistWork.IoGoodsDay;
                    }
                    innerList.Add(stockAcPayHistWork);

                }
                if (innerList != null && innerList.Count > 0)
                {
                    if (stockAcPayHistDB == null)
                        stockAcPayHistDB = new StockAcPayHistDB();
                    //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                    status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        cnt += innerList.Count;
                }
                else if (cnt == 0) // 0件は正常と見なす。
                {
                    status = 0;
                }
            }
            // --- UPD 2011/09/06---------->>>>>
            // catch {}
            catch (SqlException ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockSlip", "仕入から在庫受払履歴データ設定[" + ex.Message + "]", ex.Number);
            }
            catch (Exception ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockSlip", "仕入から在庫受払履歴データ設定[" + ex.Message + "]", status);
            }
            // --- UPD 2011/09/06----------<<<<<
            finally
            {
                if (myReader != null)
                    myReader.Dispose();
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlCon != null)
                    sqlCon.Dispose();
            }
            #endregion

            // --- ADD 2011/09/06---------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockSlip", "仕入から在庫受払履歴データ設定", status);
            }
            // --- ADD 2011/09/06----------<<<<<

            return status;
        }

        /// <summary>
        /// 仕入履歴から在庫受払履歴データ設定
        /// </summary>
        /// <param name="cnt">処理データカウンタ</param>
        private int SetStockAcPayHistFromStockSlipHist(out int cnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            cnt = 0;
            if (lstSec == null)
                GetSectionInfo();
            #region [ 仕入履歴から在庫受払情報取得 ]
            SqlConnection sqlCon = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            try
            {
                sqlCon = new SqlConnection(connectionText);
                sqlCon.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlCon;

                string sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "STHST.LOGICALDELETECODERF," + Environment.NewLine;    // 2010/10/13 Add
                sqlText += "STHST.SECTIONCODERF," + Environment.NewLine;
                sqlText += "STHST.STOCKSECTIONCDRF," + Environment.NewLine;
                sqlText += "STHST.ARRIVALGOODSDAYRF," + Environment.NewLine;  // 2010/10/13 Add
                sqlText += "STHST.STOCKDATERF," + Environment.NewLine;
                sqlText += "STHST.STOCKADDUPADATERF," + Environment.NewLine;
                sqlText += "STHST.STOCKINPUTCODERF," + Environment.NewLine;
                sqlText += "STHST.STOCKINPUTNAMERF," + Environment.NewLine;
                sqlText += "STHST.SUPPLIERCDRF," + Environment.NewLine;
                sqlText += "STHST.SUPPLIERSNMRF," + Environment.NewLine;
                sqlText += "STHST.PARTYSALESLIPNUMRF," + Environment.NewLine;

                sqlText += "STHDT.SUPPLIERSLIPNORF," + Environment.NewLine;
                sqlText += "STHDT.STOCKROWNORF," + Environment.NewLine;
                sqlText += "STHDT.STOCKSLIPDTLNUMRF," + Environment.NewLine;
                sqlText += "STHDT.STOCKSLIPCDDTLRF," + Environment.NewLine;
                sqlText += "STHDT.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "STHDT.MAKERNAMERF," + Environment.NewLine;
                sqlText += "STHDT.GOODSNORF," + Environment.NewLine;
                sqlText += "STHDT.GOODSNAMERF," + Environment.NewLine;
                sqlText += "STHDT.BLGOODSCODERF," + Environment.NewLine;
                sqlText += "STHDT.BLGOODSFULLNAMERF," + Environment.NewLine;
                sqlText += "STHDT.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "STHDT.WAREHOUSENAMERF," + Environment.NewLine;
                sqlText += "STHDT.WAREHOUSESHELFNORF," + Environment.NewLine;
                sqlText += "STHDT.LISTPRICETAXEXCFLRF," + Environment.NewLine;
                sqlText += "STHDT.STOCKUNITPRICEFLRF," + Environment.NewLine;
                sqlText += "STHDT.STOCKCOUNTRF," + Environment.NewLine;
                sqlText += "STHDT.STOCKPRICETAXEXCRF," + Environment.NewLine;
                sqlText += "STHDT.STOCKORDERDIVCDRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKSLIPHISTRF AS STHST" + Environment.NewLine;
                sqlText += "  INNER JOIN STOCKSLHISTDTLRF AS STHDT" + Environment.NewLine;
                sqlText += "ON STHST.SUPPLIERSLIPNORF = STHDT.SUPPLIERSLIPNORF AND  STHST.SUPPLIERFORMALRF = STHDT.SUPPLIERFORMALRF";

                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 300;// 2012/04/27 Add

                ArrayList innerList = null;
                DateTime prevDateTime = DateTime.MaxValue;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockAcPayHistWork stockAcPayHistWork = new StockAcPayHistWork();
                    StockAcPayHistWork stockAcPayHistDeleteWork = null;

                    stockAcPayHistWork.LogicalDeleteCode = 0;
                    // 2010/10/13 >>>
                    //stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
                    stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
                    // 2010/10/13 <<<
                    stockAcPayHistWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
                    stockAcPayHistWork.AcPaySlipCd = 10; // 10:仕入固定
                    stockAcPayHistWork.AcPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF")).ToString();
                    stockAcPayHistWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
                    int kubun = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
                    if (kubun == 0)
                        stockAcPayHistWork.AcPayTransCd = 10; // 0:仕入	 -> 10:通常伝票
                    else if (kubun == 1)
                        stockAcPayHistWork.AcPayTransCd = 11; // 1:返品	 -> 11:返品
                    else if (kubun == 2)
                        stockAcPayHistWork.AcPayTransCd = 12; // 2:値引	 -> 12:値引
                    stockAcPayHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.InputSectionCd))
                    {
                        stockAcPayHistWork.InputSectionGuidNm = lstSec[stockAcPayHistWork.InputSectionCd].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.InputSectionGuidNm = "";
                    }
                    stockAcPayHistWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
                    stockAcPayHistWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
                    stockAcPayHistWork.MoveStatus = 0; // 0:移動対象外
                    stockAcPayHistWork.CustSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                    stockAcPayHistWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
                    stockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockAcPayHistWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockAcPayHistWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockAcPayHistWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    stockAcPayHistWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    stockAcPayHistWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.SectionCode))
                    {
                        stockAcPayHistWork.SectionGuideNm = lstSec[stockAcPayHistWork.SectionCode].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.SectionGuideNm = "";
                    }
                    stockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockAcPayHistWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockAcPayHistWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    stockAcPayHistWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    stockAcPayHistWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    stockAcPayHistWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
                    stockAcPayHistWork.OpenPriceDiv = 0; // 0:通常
                    stockAcPayHistWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    stockAcPayHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    stockAcPayHistWork.StockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));

                    // 在庫管理する条件
                    // ① 倉庫コードが設定されている
                    // ② 仕入在庫取寄せ区分が 1:在庫
                    // ③ 仕入数が0以外
                    // ④ 仕入伝票区分(明細)が 0:売上 1:返品 の場合
                    // 2010/10/08 Add >>>
                    // ⑤ 品番がセットされている
                    // 2010/10/08 Add <<<
                    int orderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
                    string goodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));  // 2010/10/08 Add
                    if (string.IsNullOrEmpty(stockAcPayHistWork.WarehouseCode) ||
                        orderDivCd != 1 ||
                        stockAcPayHistWork.ArrivalCnt == 0 ||
                        (kubun != 0 && kubun != 1) ||
                        string.IsNullOrEmpty(goodsNo))
                        continue;

                    // 2010/10/13 Add >>>
                    int logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    if (logicalDeleteCode == 1)
                    {
                        stockAcPayHistDeleteWork = new StockAcPayHistWork();
                        stockAcPayHistDeleteWork.LogicalDeleteCode = 0;
                        stockAcPayHistDeleteWork.IoGoodsDay = stockAcPayHistWork.IoGoodsDay;
                        stockAcPayHistDeleteWork.AddUpADate = stockAcPayHistWork.AddUpADate;
                        stockAcPayHistDeleteWork.AcPaySlipCd = 10; // 10:仕入固定
                        stockAcPayHistDeleteWork.AcPaySlipNum = stockAcPayHistWork.AcPaySlipNum;
                        stockAcPayHistDeleteWork.AcPaySlipRowNo = stockAcPayHistWork.AcPaySlipRowNo;
                        stockAcPayHistDeleteWork.AcPayTransCd = 21; // 21:削除
                        stockAcPayHistDeleteWork.InputSectionCd = stockAcPayHistWork.InputSectionCd;
                        stockAcPayHistDeleteWork.InputSectionGuidNm = stockAcPayHistWork.InputSectionGuidNm;
                        stockAcPayHistDeleteWork.InputAgenCd = stockAcPayHistWork.InputAgenCd;
                        stockAcPayHistDeleteWork.InputAgenNm = stockAcPayHistWork.InputAgenNm;
                        stockAcPayHistDeleteWork.MoveStatus = 0; // 0:移動対象外
                        stockAcPayHistDeleteWork.CustSlipNo = stockAcPayHistWork.CustSlipNo;
                        stockAcPayHistDeleteWork.SlipDtlNum = stockAcPayHistWork.SlipDtlNum;
                        stockAcPayHistDeleteWork.GoodsMakerCd = stockAcPayHistWork.GoodsMakerCd;
                        stockAcPayHistDeleteWork.MakerName = stockAcPayHistWork.MakerName;
                        stockAcPayHistDeleteWork.GoodsNo = stockAcPayHistWork.GoodsNo;
                        stockAcPayHistDeleteWork.GoodsName = stockAcPayHistWork.GoodsName;
                        stockAcPayHistDeleteWork.BLGoodsCode = stockAcPayHistWork.BLGoodsCode;
                        stockAcPayHistDeleteWork.BLGoodsFullName = stockAcPayHistWork.BLGoodsFullName;
                        stockAcPayHistDeleteWork.SectionCode = stockAcPayHistWork.SectionCode;
                        stockAcPayHistDeleteWork.SectionGuideNm = stockAcPayHistWork.SectionGuideNm;
                        stockAcPayHistDeleteWork.WarehouseCode = stockAcPayHistWork.WarehouseCode;
                        stockAcPayHistDeleteWork.WarehouseName = stockAcPayHistWork.WarehouseName;
                        stockAcPayHistDeleteWork.ShelfNo = stockAcPayHistWork.ShelfNo;
                        stockAcPayHistDeleteWork.SupplierCd = stockAcPayHistWork.SupplierCd;
                        stockAcPayHistDeleteWork.SupplierSnm = stockAcPayHistWork.SupplierSnm;
                        stockAcPayHistDeleteWork.ArrivalCnt = -stockAcPayHistWork.ArrivalCnt;
                        stockAcPayHistDeleteWork.OpenPriceDiv = 0; // 0:通常
                        stockAcPayHistDeleteWork.ListPriceTaxExcFl = stockAcPayHistWork.ListPriceTaxExcFl;
                        stockAcPayHistDeleteWork.StockUnitPriceFl = stockAcPayHistWork.StockUnitPriceFl;
                        stockAcPayHistDeleteWork.StockPrice = -stockAcPayHistWork.StockPrice;
                    }
                    else
                    {
                        stockAcPayHistDeleteWork = null;
                    }
                    // 2010/10/13 Add <<<

                    if (stockAcPayHistWork.IoGoodsDay != prevDateTime) // 売上日付が前回データと違うか？（初回目ふくめ）                        
                    {
                        if (innerList != null)
                        {
                            if (stockAcPayHistDB == null)
                                stockAcPayHistDB = new StockAcPayHistDB();
                            //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                            status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                            if (status == 0)
                                cnt += innerList.Count;
                            else
                                break;
                        }
                        innerList = new ArrayList();
                        prevDateTime = stockAcPayHistWork.IoGoodsDay;
                    }
                    innerList.Add(stockAcPayHistWork);
                    if (stockAcPayHistDeleteWork != null)
                    {
                        innerList.Add(stockAcPayHistDeleteWork);
                    }
                }
                if (innerList != null && innerList.Count > 0)
                {
                    if (stockAcPayHistDB == null)
                        stockAcPayHistDB = new StockAcPayHistDB();
                    //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                    status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        cnt += innerList.Count;
                }
                else if (cnt == 0) // 0件は正常と見なす。
                {
                    status = 0;
                }

            }
            // --- UPD 2011/09/06---------->>>>>
            // catch {}
            catch (SqlException ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockSlipHist", "仕入履歴から在庫受払履歴データ設定[" + ex.Message + "]", ex.Number);
            }
            catch (Exception ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockSlipHist", "仕入履歴から在庫受払履歴データ設定[" + ex.Message + "]", status);
            }
            // --- UPD 2011/09/06----------<<<<<
            finally
            {
                if (myReader != null)
                    myReader.Dispose();
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlCon != null)
                    sqlCon.Dispose();
            }
            #endregion

            // --- ADD 2011/09/06---------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockSlipHist", "仕入履歴から在庫受払履歴データ設定", status);
            }
            // --- ADD 2011/09/06----------<<<<<

            return status;
        }

        /// <summary>
        /// 在庫移動から在庫受払履歴データ設定
        /// </summary>
        /// <param name="cnt">処理データカウンタ</param>
        /// <param name="mode">入荷済みデータの対象 0:出荷、入荷,1:入荷のみ作成</param>
        private int SetStockAcPayHistFromStockMove(out int cnt, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            cnt = 0;
            if (lstSec == null)
                GetSectionInfo();
            //if (lstFractionInfo == null)
            //    GetStockProcMoneyInfo();
            //if (lstFractionInfo == null) // GetStockProcMoneyInfo処理で端数処理情報取得失敗した場合処理を中断
            //    return status;

            #region [ 在庫移動から在庫受払情報取得 ]
            SqlConnection sqlCon = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            try
            {
                sqlCon = new SqlConnection(connectionText);
                sqlCon.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlCon;


                string sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "STKMV.LOGICALDELETECODERF," + Environment.NewLine;   // 2010/10/13 Add
                sqlText += "STKMV.MOVESTATUSRF," + Environment.NewLine;   // 2010/09/17 Add
                sqlText += "STKMV.STOCKMOVEFORMALRF," + Environment.NewLine;   // 2009/06/19
                sqlText += "STKMV.STOCKMOVESLIPNORF," + Environment.NewLine;
                sqlText += "STKMV.STOCKMOVEROWNORF," + Environment.NewLine;
                sqlText += "SECINF.SECTIONGUIDESNMRF," + Environment.NewLine; // 2010/10/13 Add
                sqlText += "STKMV.UPDATESECCDRF," + Environment.NewLine;  // 2010/10/13 Add
                sqlText += "STKMV.BFSECTIONCODERF," + Environment.NewLine;
                sqlText += "STKMV.BFSECTIONGUIDESNMRF," + Environment.NewLine;
                sqlText += "STKMV.BFENTERWAREHCODERF," + Environment.NewLine;
                sqlText += "STKMV.BFENTERWAREHNAMERF," + Environment.NewLine;
                sqlText += "STKMV.AFSECTIONCODERF," + Environment.NewLine;
                sqlText += "STKMV.AFSECTIONGUIDESNMRF," + Environment.NewLine;
                sqlText += "STKMV.AFENTERWAREHCODERF," + Environment.NewLine;
                sqlText += "STKMV.AFENTERWAREHNAMERF," + Environment.NewLine;
                sqlText += "STKMV.SHIPMENTFIXDAYRF," + Environment.NewLine;
                sqlText += "STKMV.ARRIVALGOODSDAYRF," + Environment.NewLine;
                sqlText += "STKMV.STOCKMVEMPCODERF," + Environment.NewLine;
                sqlText += "STKMV.STOCKMVEMPNAMERF," + Environment.NewLine;
                sqlText += "STKMV.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "STKMV.MAKERNAMERF," + Environment.NewLine;
                sqlText += "STKMV.GOODSNORF," + Environment.NewLine;
                sqlText += "STKMV.GOODSNAMERF," + Environment.NewLine;
                sqlText += "STKMV.STOCKUNITPRICEFLRF," + Environment.NewLine;
                sqlText += "STKMV.MOVECOUNTRF," + Environment.NewLine;
                sqlText += "STKMV.BFSHELFNORF," + Environment.NewLine;
                sqlText += "STKMV.AFSHELFNORF," + Environment.NewLine;
                sqlText += "STKMV.BLGOODSCODERF," + Environment.NewLine;
                sqlText += "STKMV.BLGOODSFULLNAMERF," + Environment.NewLine;
                sqlText += "STKMV.LISTPRICEFLRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKMOVERF AS STKMV" + Environment.NewLine;
                // 2010/10/13 Add >>>
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += "  SECINFOSETRF AS SECINF" + Environment.NewLine;
                sqlText += "    ON STKMV.ENTERPRISECODERF=SECINF.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND STKMV.UPDATESECCDRF=SECINF.SECTIONCODERF" + Environment.NewLine;
                // 2010/10/13 Add <<<

                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 300;// 2012/04/27 Add

                ArrayList innerListShipping = null;
                ArrayList innerListArrival = null;
                DateTime prevDateTimeShipping = DateTime.MaxValue;
                DateTime prevDateTimeArrival = DateTime.MaxValue;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region [ 移動出荷 ]
                    StockAcPayHistWork shippingStockHistWork = new StockAcPayHistWork(); // 移動出荷
                    shippingStockHistWork.LogicalDeleteCode = 0;
                    // 2010/10/05 Add >>>
                    // 入荷確定なしの場合、入荷データに出荷確定日がセットされていない為、入荷日から出荷確定日をセットする
                    if(mode==1)
                        shippingStockHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF")); // 出荷確定日
                    else
                    // 2010/10/05 Add <<<
                    shippingStockHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF")); // 出荷確定日
                    //shippingStockHistWork.AddUpADate = shippingStockHistWork.IoGoodsDay;  // DEL 2009/03/27 MANTIS 12532
                    shippingStockHistWork.AcPaySlipCd = 30; // 30:移動出荷
                    shippingStockHistWork.AcPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVESLIPNORF")).ToString();
                    shippingStockHistWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEROWNORF"));
                    shippingStockHistWork.AcPayTransCd = 10; // 10:通常伝票

                    // 2010/10/13 >>>
                    //shippingStockHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF"));
                    shippingStockHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                    // 2010/10/13 <<<
                    if (lstSec.ContainsKey(shippingStockHistWork.InputSectionCd))
                    {
                        shippingStockHistWork.InputSectionGuidNm = lstSec[shippingStockHistWork.InputSectionCd].SectionGuideNm;
                    }
                    else
                    {
                        // 2010/10/13 >>>
                        //shippingStockHistWork.InputSectionGuidNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF"));
                        shippingStockHistWork.InputSectionGuidNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                        // 2010/10/13 <<<
                        if (shippingStockHistWork.InputSectionGuidNm.Length > 6) // 略称は10桁・ガイド名は6桁のため、
                        {
                            shippingStockHistWork.InputSectionGuidNm = shippingStockHistWork.InputSectionGuidNm.Remove(6);
                        }
                    }
                    shippingStockHistWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKMVEMPCODERF"));
                    shippingStockHistWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKMVEMPNAMERF"));
                    
                    // 2009/06/19 >>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //// 2009/03/27 MANTIS 12532>>>>>>>>>>>>>>>>>
                    ////shippingStockHistWork.MoveStatus = 9; // 9:入荷済 
                    //shippingStockHistWork.MoveStatus = 2; // 3:移動中 
                    //// 2009/03/27 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    // 2010/09/17 >>>
                    //shippingStockHistWork.MoveStatus = 9; // 9:入荷済 
                    shippingStockHistWork.MoveStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTATUSRF"));
                    // 2010/09/17 <<<
                    // 2009/06/19 <<<<<<<<<<<<<<<<<<<<<<<<<<<
                    shippingStockHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    shippingStockHistWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    shippingStockHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    shippingStockHistWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    shippingStockHistWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    shippingStockHistWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));

                    // 2010/10/13 Add >>>
                    shippingStockHistWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF")); ;
                    if (lstSec.ContainsKey(shippingStockHistWork.BfSectionCode))
                    {
                        shippingStockHistWork.BfSectionGuideNm = lstSec[shippingStockHistWork.BfSectionCode].SectionGuideNm;
                    }
                    else
                    {
                        shippingStockHistWork.BfSectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF"));
                        if (shippingStockHistWork.BfSectionGuideNm.Length > 6) // 略称は10桁・ガイド名は6桁のため、
                        {
                            shippingStockHistWork.BfSectionGuideNm = shippingStockHistWork.BfSectionGuideNm.Remove(6);
                        }
                    }
                    // 2010/10/13 Add <<<
                    // 2010/10/13 >>>
                    //shippingStockHistWork.SectionCode = shippingStockHistWork.InputSectionCd;
                    //shippingStockHistWork.SectionGuideNm = shippingStockHistWork.InputSectionGuidNm;
                    shippingStockHistWork.SectionCode = shippingStockHistWork.BfSectionCode;
                    shippingStockHistWork.SectionGuideNm = shippingStockHistWork.BfSectionGuideNm;
                    // 2010/10/13 <<<
                    shippingStockHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
                    shippingStockHistWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
                    shippingStockHistWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
                    //shippingStockHistWork.BfSectionCode = shippingStockHistWork.InputSectionCd; // 2010/10/13 Del
                    //shippingStockHistWork.BfSectionGuideNm = shippingStockHistWork.InputSectionGuidNm;  // 2010/10/13 Del

                    shippingStockHistWork.BfEnterWarehCode = shippingStockHistWork.WarehouseCode;
                    shippingStockHistWork.BfEnterWarehName = shippingStockHistWork.WarehouseName;
                    shippingStockHistWork.BfShelfNo = shippingStockHistWork.ShelfNo;

                    shippingStockHistWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF"));
                    if (lstSec.ContainsKey(shippingStockHistWork.AfSectionCode))
                    {
                        shippingStockHistWork.AfSectionGuideNm = lstSec[shippingStockHistWork.AfSectionCode].SectionGuideNm;
                    }
                    else
                    {
                        shippingStockHistWork.AfSectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDESNMRF"));
                        if (shippingStockHistWork.AfSectionGuideNm.Length > 6) // 略称は10桁・ガイド名は6桁のため、
                        {
                            shippingStockHistWork.AfSectionGuideNm = shippingStockHistWork.AfSectionGuideNm.Remove(6);
                        }
                    }
                    shippingStockHistWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
                    shippingStockHistWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
                    shippingStockHistWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));

                    shippingStockHistWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
                    shippingStockHistWork.OpenPriceDiv = 0; // 0:通常
                    shippingStockHistWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
                    //shippingStockHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    shippingStockHistWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    double price = shippingStockHistWork.SalesUnPrcTaxExcFl * shippingStockHistWork.ShipmentCnt;
                    //shippingStockHistWork.StockPrice = GetStockPrice(price);
                    shippingStockHistWork.SalesMoney = GetStockPrice(price);
                    #endregion
                    
                    // 2009/06/19 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //modeが1の場合、在庫移動形式が1:在庫移動（出庫）,2:倉庫移動（出庫）の場合に出荷レコードを作成する
                    int stockMoveFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEFORMALRF"));

                    // 2010/10/08 Add >>>
                    bool updflg = true;
                    if (mode == 1)
                    {
                        // 在庫マスタRead　なければ、在庫移動の際は新規追加しない
                        StockDB stockDB = new StockDB();
                        StockWork stWork = new StockWork();
                        stWork.EnterpriseCode = _enterpriseCode;
                        stWork.WarehouseCode = shippingStockHistWork.BfEnterWarehCode;
                        stWork.GoodsMakerCd = shippingStockHistWork.GoodsMakerCd;
                        stWork.GoodsNo = shippingStockHistWork.GoodsNo;

                        int stockstatus = stockDB.ReadProc(ref stWork, 0, ref sqlConnection, ref sqlTransaction);

                        if (stockstatus != 0)
                        {
                            if (stockMoveFormal == 1 || stockMoveFormal == 3)
                                updflg = false;
                        }

                    }
                    StockAcPayHistWork deleteShippingStockHistWork = null;
                    StockAcPayHistWork deletearrivalStockHistWork = null;
                    int logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    // 2010/10/08 Add <<<

                    //// 2009/03/23 >>>>>>>>>>>>>>>>>>>>>>>>>
                    //// 入出荷作成モードの場合は無条件、入荷のみ作成モードの場合は入荷日が未設定のレコードのみ出荷の受払履歴データを作成する
                    //if (mode == 0 || SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF")) == DateTime.MinValue)
                    //// 2009/03/23 <<<<<<<<<<<<<<<<<<<<<<<<<
                    // 2010/09/17 modeの切替が逆 >>>
                    //if (mode == 0 || (mode == 1 && (stockMoveFormal == 1 || stockMoveFormal == 2)))
                    if ((mode == 1 || (mode == 0 && (stockMoveFormal == 1 || stockMoveFormal == 2))) && updflg)
                    // 2010/09/17 <<<
                    // 2009/06/19 <<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        // 2010/10/13 Add >>>
                        #region [移動出荷・削除分]
                        if (logicalDeleteCode == 1)
                        {
                            deleteShippingStockHistWork = new StockAcPayHistWork();
                            deleteShippingStockHistWork.LogicalDeleteCode = 0;
                            deleteShippingStockHistWork.IoGoodsDay = shippingStockHistWork.IoGoodsDay;
                            deleteShippingStockHistWork.AcPaySlipCd = 30; // 30:移動出荷
                            deleteShippingStockHistWork.AcPaySlipNum = shippingStockHistWork.AcPaySlipNum;
                            deleteShippingStockHistWork.AcPaySlipRowNo = shippingStockHistWork.AcPaySlipRowNo;
                            deleteShippingStockHistWork.AcPayTransCd = 21; // 21:削除

                            deleteShippingStockHistWork.InputSectionCd = shippingStockHistWork.InputSectionCd;
                            deleteShippingStockHistWork.InputSectionGuidNm = shippingStockHistWork.InputSectionGuidNm;
                            deleteShippingStockHistWork.InputAgenCd = shippingStockHistWork.InputAgenCd;
                            deleteShippingStockHistWork.InputAgenNm = shippingStockHistWork.InputAgenNm;

                            deleteShippingStockHistWork.MoveStatus = shippingStockHistWork.MoveStatus;
                            deleteShippingStockHistWork.GoodsMakerCd = shippingStockHistWork.GoodsMakerCd;
                            deleteShippingStockHistWork.MakerName = shippingStockHistWork.MakerName;
                            deleteShippingStockHistWork.GoodsNo = shippingStockHistWork.GoodsNo;
                            deleteShippingStockHistWork.GoodsName = shippingStockHistWork.GoodsName;
                            deleteShippingStockHistWork.BLGoodsCode = shippingStockHistWork.BLGoodsCode;
                            deleteShippingStockHistWork.BLGoodsFullName = shippingStockHistWork.BLGoodsFullName;

                            deleteShippingStockHistWork.SectionCode = shippingStockHistWork.InputSectionCd;
                            deleteShippingStockHistWork.SectionGuideNm = shippingStockHistWork.InputSectionGuidNm;
                            deleteShippingStockHistWork.WarehouseCode = shippingStockHistWork.WarehouseCode;
                            deleteShippingStockHistWork.WarehouseName = shippingStockHistWork.WarehouseName;
                            deleteShippingStockHistWork.ShelfNo = shippingStockHistWork.ShelfNo;
                            deleteShippingStockHistWork.BfSectionCode = shippingStockHistWork.InputSectionCd;
                            deleteShippingStockHistWork.BfSectionGuideNm = shippingStockHistWork.InputSectionGuidNm;

                            deleteShippingStockHistWork.BfEnterWarehCode = shippingStockHistWork.WarehouseCode;
                            deleteShippingStockHistWork.BfEnterWarehName = shippingStockHistWork.WarehouseName;
                            deleteShippingStockHistWork.BfShelfNo = shippingStockHistWork.ShelfNo;

                            deleteShippingStockHistWork.AfSectionCode = shippingStockHistWork.AfSectionCode;
                            deleteShippingStockHistWork.AfSectionGuideNm = shippingStockHistWork.AfSectionGuideNm;
                            deleteShippingStockHistWork.AfEnterWarehCode = shippingStockHistWork.AfEnterWarehCode;
                            deleteShippingStockHistWork.AfEnterWarehName = shippingStockHistWork.AfEnterWarehName;
                            deleteShippingStockHistWork.AfShelfNo = shippingStockHistWork.AfShelfNo;

                            deleteShippingStockHistWork.ShipmentCnt = -shippingStockHistWork.ShipmentCnt;
                            deleteShippingStockHistWork.OpenPriceDiv = shippingStockHistWork.OpenPriceDiv; // 0:通常
                            deleteShippingStockHistWork.ListPriceTaxExcFl = shippingStockHistWork.ListPriceTaxExcFl;
                            deleteShippingStockHistWork.SalesUnPrcTaxExcFl = shippingStockHistWork.SalesUnPrcTaxExcFl;
                            price = deleteShippingStockHistWork.SalesUnPrcTaxExcFl * deleteShippingStockHistWork.ShipmentCnt;
                            deleteShippingStockHistWork.SalesMoney = GetStockPrice(price);
                        }
                        else
                        {
                            deleteShippingStockHistWork = null;
                        }
                        #endregion
                        // 2010/10/13 Add <<<
                        if (shippingStockHistWork.IoGoodsDay != prevDateTimeShipping) // 売上日付が前回データと違うか？（初回目ふくめ）                        
                        {
                            if (innerListShipping != null)
                            {
                                if (stockAcPayHistDB == null)
                                    stockAcPayHistDB = new StockAcPayHistDB();
                                //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerListShipping, prevDateTimeShipping.Ticks, ref sqlConnection, ref sqlTransaction);
                                status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerListShipping, ref sqlConnection, ref sqlTransaction);
                                if (status == 0)
                                    cnt += innerListShipping.Count;
                                else
                                    break;
                            }
                            innerListShipping = new ArrayList();
                            prevDateTimeShipping = shippingStockHistWork.IoGoodsDay;
                        }
                        innerListShipping.Add(shippingStockHistWork);
                        // 2010/10/13 Add >>>
                        if (deleteShippingStockHistWork != null)
                        {
                            innerListShipping.Add(deleteShippingStockHistWork);
                        }
                        // 2010/10/13 Add <<<

                    } // 2009/03/23 

                    #region [ 移動入荷 ]
                    StockAcPayHistWork arrivalStockHistWork = new StockAcPayHistWork(); // 移動入荷
                    arrivalStockHistWork.LogicalDeleteCode = 0;
                    arrivalStockHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF")); // 入荷日
                    // 2009/03/27 MANTIS 12532 >>>>>>>>>>>>>>>>>
                    //// 2009/02/25 MANTIS 11630 >>>>>>>>>>>>>>>>>>
                    //if (arrivalStockHistWork.IoGoodsDay == DateTime.MinValue)
                    //{
                    //    //入荷日がNULLの場合は出荷確定日をセット
                    //    arrivalStockHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF")); // 出荷確定日
                    //}
                    //// 2009/02/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    // 2009/03/27 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    arrivalStockHistWork.AddUpADate = arrivalStockHistWork.IoGoodsDay;
                    arrivalStockHistWork.AcPaySlipCd = 31; // 31:移動入荷
                    arrivalStockHistWork.AcPaySlipNum = shippingStockHistWork.AcPaySlipNum;
                    arrivalStockHistWork.AcPaySlipRowNo = shippingStockHistWork.AcPaySlipRowNo;
                    arrivalStockHistWork.AcPayTransCd = 10; // 10:通常伝票

                    // 2010/10/13 >>>
                    //arrivalStockHistWork.InputSectionCd = shippingStockHistWork.AfSectionCode;
                    //arrivalStockHistWork.InputSectionGuidNm = shippingStockHistWork.AfSectionGuideNm;
                    arrivalStockHistWork.InputSectionCd = shippingStockHistWork.InputSectionCd;
                    arrivalStockHistWork.InputSectionGuidNm = shippingStockHistWork.InputSectionGuidNm;
                    // 2010/10/13 <<<
                    arrivalStockHistWork.InputAgenCd = shippingStockHistWork.InputAgenCd;
                    arrivalStockHistWork.InputAgenNm = shippingStockHistWork.InputAgenNm;
                    // 2010/09/17 >>>
                    //arrivalStockHistWork.MoveStatus = 9; // 9:入荷済
                    arrivalStockHistWork.MoveStatus = shippingStockHistWork.MoveStatus; // 9:入荷済
                    // 2010/09/17 <<<
                    arrivalStockHistWork.GoodsMakerCd = shippingStockHistWork.GoodsMakerCd;
                    arrivalStockHistWork.MakerName = shippingStockHistWork.MakerName;
                    arrivalStockHistWork.GoodsNo = shippingStockHistWork.GoodsNo;
                    arrivalStockHistWork.GoodsName = shippingStockHistWork.GoodsName;
                    arrivalStockHistWork.BLGoodsCode = shippingStockHistWork.BLGoodsCode;
                    arrivalStockHistWork.BLGoodsFullName = shippingStockHistWork.BLGoodsFullName;

                    // 2010/10/13 >>>
                    //arrivalStockHistWork.SectionCode = arrivalStockHistWork.InputSectionCd;
                    //arrivalStockHistWork.SectionGuideNm = arrivalStockHistWork.InputSectionGuidNm;
                    arrivalStockHistWork.SectionCode = shippingStockHistWork.AfSectionCode;
                    arrivalStockHistWork.SectionGuideNm = shippingStockHistWork.AfSectionGuideNm;
                    // 2010/10/13 <<<
                    arrivalStockHistWork.WarehouseCode = shippingStockHistWork.AfEnterWarehCode;
                    arrivalStockHistWork.WarehouseName = shippingStockHistWork.AfEnterWarehName;
                    arrivalStockHistWork.ShelfNo = shippingStockHistWork.AfShelfNo;

                    arrivalStockHistWork.BfSectionCode = shippingStockHistWork.BfSectionCode;
                    arrivalStockHistWork.BfSectionGuideNm = shippingStockHistWork.BfSectionGuideNm;
                    arrivalStockHistWork.BfEnterWarehCode = shippingStockHistWork.BfEnterWarehCode;
                    arrivalStockHistWork.BfEnterWarehName = shippingStockHistWork.BfEnterWarehName;
                    arrivalStockHistWork.BfShelfNo = shippingStockHistWork.BfShelfNo;

                    arrivalStockHistWork.AfSectionCode = shippingStockHistWork.AfSectionCode;
                    arrivalStockHistWork.AfSectionGuideNm = shippingStockHistWork.AfSectionGuideNm;
                    arrivalStockHistWork.AfEnterWarehCode = shippingStockHistWork.AfEnterWarehCode;
                    arrivalStockHistWork.AfEnterWarehName = shippingStockHistWork.AfEnterWarehName;
                    arrivalStockHistWork.AfShelfNo = shippingStockHistWork.AfShelfNo;

                    arrivalStockHistWork.ArrivalCnt = shippingStockHistWork.ShipmentCnt;
                    arrivalStockHistWork.OpenPriceDiv = 0; // 0:通常
                    arrivalStockHistWork.ListPriceTaxExcFl = shippingStockHistWork.ListPriceTaxExcFl;
                    //arrivalStockHistWork.StockUnitPriceFl = shippingStockHistWork.StockUnitPriceFl;
                    arrivalStockHistWork.StockUnitPriceFl = shippingStockHistWork.SalesUnPrcTaxExcFl;
                    price = arrivalStockHistWork.StockUnitPriceFl * arrivalStockHistWork.ArrivalCnt;
                    arrivalStockHistWork.StockPrice = GetStockPrice(price);
                    #endregion

                    // 2009/06/19 >>>>>>>>>>>>>>>>>>>
                    //modeが1の場合、在庫移動形式が3:在庫移動（入庫）,4:倉庫移動（入庫）の場合に入荷レコードを作成する

                    // 2010/10/08 Add >>>
                    updflg = true;
                    if (mode == 1)
                    {
                        // 在庫マスタRead　なければ、在庫移動の際は新規追加しない
                        StockDB stockDB = new StockDB();
                        StockWork stWork = new StockWork();
                        stWork.EnterpriseCode = _enterpriseCode;
                        stWork.WarehouseCode = shippingStockHistWork.AfEnterWarehCode;
                        stWork.GoodsMakerCd = shippingStockHistWork.GoodsMakerCd;
                        stWork.GoodsNo = shippingStockHistWork.GoodsNo;

                        int stockstatus = stockDB.ReadProc(ref stWork, 0, ref sqlConnection, ref sqlTransaction);

                        if (stockstatus != 0)
                        {
                            if (stockMoveFormal == 1 || stockMoveFormal == 3)
                                updflg = false;
                        }

                    }
                    // 2010/10/08 Add <<<
                    //// 2009/03/23 >>>>>>>>>>>>>>>
                    //// 入荷日がセットされている場合のみ、入荷済みとして入荷の受払履歴データを作成する
                    //if (SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF")) != DateTime.MinValue)
                    //// 2009/03/23 <<<<<<<<<<<<<<<
                    // 2010/09/17 modeの切替が逆 >>>
                    //if (mode == 0 || (mode == 1 && (stockMoveFormal == 3 || stockMoveFormal == 4)))
                    if ((mode == 1 || (mode == 0 && (stockMoveFormal == 3 || stockMoveFormal == 4))) && updflg)
                    // 2010/09/17 <<<
                    // 2009/06/19 <<<<<<<<<<<<<<<<<<<
                    {
                        // 2010/10/13 Add >>>
                        if (logicalDeleteCode == 1)
                        {
                            deletearrivalStockHistWork = new StockAcPayHistWork();
                            deletearrivalStockHistWork.LogicalDeleteCode = 0;
                            deletearrivalStockHistWork.IoGoodsDay = arrivalStockHistWork.IoGoodsDay; // 入荷日
                            deletearrivalStockHistWork.AddUpADate = arrivalStockHistWork.IoGoodsDay;
                            deletearrivalStockHistWork.AcPaySlipCd = 31; // 31:移動入荷
                            deletearrivalStockHistWork.AcPaySlipNum = arrivalStockHistWork.AcPaySlipNum;
                            deletearrivalStockHistWork.AcPaySlipRowNo = arrivalStockHistWork.AcPaySlipRowNo;
                            deletearrivalStockHistWork.AcPayTransCd = 21; // 21:削除

                            deletearrivalStockHistWork.InputSectionCd = arrivalStockHistWork.InputSectionCd;
                            deletearrivalStockHistWork.InputSectionGuidNm = arrivalStockHistWork.AfSectionGuideNm;
                            deletearrivalStockHistWork.InputAgenCd = arrivalStockHistWork.InputAgenCd;
                            deletearrivalStockHistWork.InputAgenNm = arrivalStockHistWork.InputAgenNm;
                            deletearrivalStockHistWork.MoveStatus = arrivalStockHistWork.MoveStatus; // 9:入荷済
                            deletearrivalStockHistWork.GoodsMakerCd = arrivalStockHistWork.GoodsMakerCd;
                            deletearrivalStockHistWork.MakerName = arrivalStockHistWork.MakerName;
                            deletearrivalStockHistWork.GoodsNo = arrivalStockHistWork.GoodsNo;
                            deletearrivalStockHistWork.GoodsName = arrivalStockHistWork.GoodsName;
                            deletearrivalStockHistWork.BLGoodsCode = arrivalStockHistWork.BLGoodsCode;
                            deletearrivalStockHistWork.BLGoodsFullName = arrivalStockHistWork.BLGoodsFullName;

                            deletearrivalStockHistWork.SectionCode = arrivalStockHistWork.InputSectionCd;
                            deletearrivalStockHistWork.SectionGuideNm = arrivalStockHistWork.InputSectionGuidNm;
                            deletearrivalStockHistWork.WarehouseCode = arrivalStockHistWork.AfEnterWarehCode;
                            deletearrivalStockHistWork.WarehouseName = arrivalStockHistWork.AfEnterWarehName;
                            deletearrivalStockHistWork.ShelfNo = arrivalStockHistWork.AfShelfNo;

                            deletearrivalStockHistWork.BfSectionCode = arrivalStockHistWork.BfSectionCode;
                            deletearrivalStockHistWork.BfSectionGuideNm = arrivalStockHistWork.BfSectionGuideNm;
                            deletearrivalStockHistWork.BfEnterWarehCode = arrivalStockHistWork.BfEnterWarehCode;
                            deletearrivalStockHistWork.BfEnterWarehName = arrivalStockHistWork.BfEnterWarehName;
                            deletearrivalStockHistWork.BfShelfNo = arrivalStockHistWork.BfShelfNo;

                            deletearrivalStockHistWork.AfSectionCode = arrivalStockHistWork.AfSectionCode;
                            deletearrivalStockHistWork.AfSectionGuideNm = arrivalStockHistWork.AfSectionGuideNm;
                            deletearrivalStockHistWork.AfEnterWarehCode = arrivalStockHistWork.AfEnterWarehCode;
                            deletearrivalStockHistWork.AfEnterWarehName = arrivalStockHistWork.AfEnterWarehName;
                            deletearrivalStockHistWork.AfShelfNo = arrivalStockHistWork.AfShelfNo;

                            deletearrivalStockHistWork.ArrivalCnt = -arrivalStockHistWork.ArrivalCnt;
                            deletearrivalStockHistWork.OpenPriceDiv = 0; // 0:通常
                            deletearrivalStockHistWork.ListPriceTaxExcFl = arrivalStockHistWork.ListPriceTaxExcFl;
                            deletearrivalStockHistWork.StockUnitPriceFl = arrivalStockHistWork.StockUnitPriceFl;
                            price = deletearrivalStockHistWork.StockUnitPriceFl * deletearrivalStockHistWork.ArrivalCnt;
                            deletearrivalStockHistWork.StockPrice = GetStockPrice(price);
                        }
                        else
                        {
                            deletearrivalStockHistWork = null;
                        }
                        // 2010/10/13 Add <<<
                        
                        if (arrivalStockHistWork.IoGoodsDay != prevDateTimeArrival) // 売上日付が前回データと違うか？（初回目ふくめ）                        
                        {
                            if (innerListArrival != null)
                            {
                                if (stockAcPayHistDB == null)
                                    stockAcPayHistDB = new StockAcPayHistDB();
                                //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerListArrival, prevDateTimeArrival.Ticks, ref sqlConnection, ref sqlTransaction);
                                status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerListArrival, ref sqlConnection, ref sqlTransaction);
                                if (status == 0)
                                    cnt += innerListArrival.Count;
                                else
                                    break;
                            }
                            innerListArrival = new ArrayList();
                            prevDateTimeArrival = arrivalStockHistWork.IoGoodsDay;
                        }
                        innerListArrival.Add(arrivalStockHistWork);
                        // 2010/10/13 Add >>>
                        if (deletearrivalStockHistWork != null)
                        {
                            innerListArrival.Add(deletearrivalStockHistWork);
                        }
                        // 2010/10/13 Add <<<

                    } //2009/03/23
                }

                if (innerListShipping != null && innerListShipping.Count > 0)
                {
                    if (stockAcPayHistDB == null)
                        stockAcPayHistDB = new StockAcPayHistDB();
                    //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerListShipping, prevDateTimeShipping.Ticks, ref sqlConnection, ref sqlTransaction);
                    status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerListShipping, ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        cnt += innerListShipping.Count;
                }
                if (innerListArrival != null && innerListArrival.Count > 0)
                {
                    if (stockAcPayHistDB == null)
                        stockAcPayHistDB = new StockAcPayHistDB();
                    //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerListArrival, prevDateTimeArrival.Ticks, ref sqlConnection, ref sqlTransaction);
                    status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerListArrival, ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        cnt += innerListArrival.Count;
                }
                if (cnt == 0) // 0件は正常と見なす。
                {
                    status = 0;
                }
            }
            // --- UPD 2011/09/06---------->>>>>
            // catch { }
            catch (SqlException ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockMove", "在庫移動から在庫受払履歴データ設定[" + ex.Message + "]", ex.Number);
            }
            catch (Exception ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockMove", "在庫移動から在庫受払履歴データ設定[" + ex.Message + "]", status);
            }
            // --- UPD 2011/09/06----------<<<<<
            finally
            {
                if (myReader != null)
                    myReader.Dispose();
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlCon != null)
                    sqlCon.Dispose();
            }
            #endregion

            // --- ADD 2011/09/06---------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockMove", "在庫移動から在庫受払履歴データ設定", status);
            }
            // --- ADD 2011/09/06----------<<<<<

            return status;
        }

        /// <summary>
        /// 在庫仕入[在庫調整]から在庫受払履歴データ設定
        /// </summary>
        /// <param name="cnt">処理データカウンタ</param>
        private int SetStockAcPayHistFromStockAdjust(out int cnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            cnt = 0;
            ArrayList lst = new ArrayList();
            if (lstSec == null)
                GetSectionInfo();
            if (lstBLCode == null)
                GetBlInfo();
            //if (lstFractionInfo == null)
            //    GetStockProcMoneyInfo();
            //if (lstFractionInfo == null) // GetStockProcMoneyInfo処理で端数処理情報取得失敗した場合処理を中断
            //    return status;
            #region [ 在庫仕入[在庫調整]から在庫受払情報取得 ]
            SqlConnection sqlCon = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            try
            {
                sqlCon = new SqlConnection(connectionText);
                sqlCon.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlCon;

                string sqlText = "";
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "STAD.LOGICALDELETECODERF," + Environment.NewLine;   // 2010/10/20 Add
                sqlText += "STAD.SECTIONCODERF AS INPUTSECTIONCODERF," + Environment.NewLine;
                sqlText += "STAD.STOCKINPUTCODERF," + Environment.NewLine;
                sqlText += "STAD.STOCKINPUTNAMERF," + Environment.NewLine;

                sqlText += "SADT.SECTIONCODERF," + Environment.NewLine;
                sqlText += "SADT.STOCKADJUSTSLIPNORF," + Environment.NewLine;
                sqlText += "SADT.STOCKADJUSTROWNORF," + Environment.NewLine;
                sqlText += "SADT.ACPAYSLIPCDRF," + Environment.NewLine;
                sqlText += "SADT.ACPAYTRANSCDRF," + Environment.NewLine;
                sqlText += "SADT.ADJUSTDATERF," + Environment.NewLine;
                sqlText += "SADT.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "SADT.MAKERNAMERF," + Environment.NewLine;
                sqlText += "SADT.GOODSNORF," + Environment.NewLine;
                sqlText += "SADT.GOODSNAMERF," + Environment.NewLine;
                sqlText += "SADT.STOCKUNITPRICEFLRF," + Environment.NewLine;
                sqlText += "SADT.ADJUSTCOUNTRF," + Environment.NewLine;
                sqlText += "SADT.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "SADT.WAREHOUSENAMERF," + Environment.NewLine;
                sqlText += "SADT.BLGOODSCODERF," + Environment.NewLine;
                sqlText += "SADT.WAREHOUSESHELFNORF," + Environment.NewLine;
                sqlText += "SADT.LISTPRICEFLRF," + Environment.NewLine;
                sqlText += "SADT.STOCKPRICETAXEXCRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  STOCKADJUSTRF AS STAD" + Environment.NewLine;
                sqlText += "  INNER JOIN STOCKADJUSTDTLRF AS SADT" + Environment.NewLine;
                sqlText += " ON STAD.STOCKADJUSTSLIPNORF = SADT.STOCKADJUSTSLIPNORF";

                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandTimeout = 300;// 2012/04/27 Add

                ArrayList innerList = null;
                DateTime prevDateTime = DateTime.MaxValue;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockAcPayHistWork stockAcPayHistWork = new StockAcPayHistWork();
                    StockAcPayHistWork stockAcPayHistDeleteWork = null; // 2010/10/20 Add
                    stockAcPayHistWork.LogicalDeleteCode = 0;
                    stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
                    stockAcPayHistWork.AddUpADate = stockAcPayHistWork.IoGoodsDay;
                    stockAcPayHistWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
                    stockAcPayHistWork.AcPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF")).ToString();
                    stockAcPayHistWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTROWNORF"));
                    stockAcPayHistWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));

                    stockAcPayHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTSECTIONCODERF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.InputSectionCd))
                    {
                        stockAcPayHistWork.InputSectionGuidNm = lstSec[stockAcPayHistWork.InputSectionCd].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.InputSectionGuidNm = "";
                    }
                    stockAcPayHistWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
                    stockAcPayHistWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
                    stockAcPayHistWork.MoveStatus = 0; // 0:移動対象外
                    stockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockAcPayHistWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockAcPayHistWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockAcPayHistWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    if (lstBLCode.ContainsKey(stockAcPayHistWork.BLGoodsCode))
                    {
                        stockAcPayHistWork.BLGoodsFullName = lstBLCode[stockAcPayHistWork.BLGoodsCode].BLGoodsFullName;
                    }
                    else
                    {
                        stockAcPayHistWork.BLGoodsFullName = "";
                    }
                    stockAcPayHistWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    if (lstSec.ContainsKey(stockAcPayHistWork.SectionCode))
                    {
                        stockAcPayHistWork.SectionGuideNm = lstSec[stockAcPayHistWork.SectionCode].SectionGuideNm;
                    }
                    else
                    {
                        stockAcPayHistWork.SectionGuideNm = "";
                    }
                    stockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockAcPayHistWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockAcPayHistWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    // 2010/10/20 Add >>>
                    if (stockAcPayHistWork.AcPaySlipCd == 71)
                    {
                        double shipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
                        stockAcPayHistWork.ShipmentCnt = -shipmentCnt;
                        // 2010/10/21 Add >>>
                        double salesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                        long salesMoney = SqlDataMediator.SqlGetLong(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                        stockAcPayHistWork.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
                        stockAcPayHistWork.SalesMoney = -salesMoney;
                        // 2010/10/21 Add <<<
                    }
                    else
                    // 2010/10/20 Add <<<
                    // 2010/10/21 Add >>>
                    {
                        stockAcPayHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                        stockAcPayHistWork.StockPrice = SqlDataMediator.SqlGetLong(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                        // 2010/10/21 Add <<<
                        stockAcPayHistWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
                    }   // 2010/10/21 Add
                    stockAcPayHistWork.OpenPriceDiv = 0; // 0:通常
                    stockAcPayHistWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICEFLRF"));
                    // 2010/10/21 Del >>>
                    //stockAcPayHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    //stockAcPayHistWork.StockPrice = SqlDataMediator.SqlGetLong(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                    // 2010/10/21 Del <<<
                    //double price = stockAcPayHistWork.StockUnitPriceFl * stockAcPayHistWork.ArrivalCnt;
                    //stockAcPayHistWork.StockPrice = GetStockPrice(price);


                    // 2010/10/20 Add >>>
                    int logcalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    if (logcalDeleteCode == 1)
                    {
                        stockAcPayHistDeleteWork = new StockAcPayHistWork();
                        stockAcPayHistDeleteWork.LogicalDeleteCode = 0;
                        stockAcPayHistDeleteWork.IoGoodsDay = stockAcPayHistWork.IoGoodsDay;
                        stockAcPayHistDeleteWork.AddUpADate = stockAcPayHistDeleteWork.IoGoodsDay;
                        stockAcPayHistDeleteWork.AcPaySlipCd = stockAcPayHistWork.AcPaySlipCd;
                        stockAcPayHistDeleteWork.AcPaySlipNum = stockAcPayHistWork.AcPaySlipNum;
                        stockAcPayHistDeleteWork.AcPaySlipRowNo = stockAcPayHistWork.AcPaySlipRowNo;
                        stockAcPayHistDeleteWork.AcPayTransCd = 21; // 21:削除

                        stockAcPayHistDeleteWork.InputSectionCd = stockAcPayHistWork.InputSectionCd;
                        stockAcPayHistDeleteWork.InputSectionGuidNm = stockAcPayHistWork.InputSectionGuidNm;
                        stockAcPayHistDeleteWork.InputAgenCd = stockAcPayHistWork.InputAgenCd;
                        stockAcPayHistDeleteWork.InputAgenNm = stockAcPayHistWork.InputAgenNm;
                        stockAcPayHistDeleteWork.MoveStatus = 0; // 0:移動対象外
                        stockAcPayHistDeleteWork.GoodsMakerCd = stockAcPayHistWork.GoodsMakerCd;
                        stockAcPayHistDeleteWork.MakerName = stockAcPayHistWork.MakerName;
                        stockAcPayHistDeleteWork.GoodsNo = stockAcPayHistWork.GoodsNo;
                        stockAcPayHistDeleteWork.GoodsName = stockAcPayHistWork.GoodsName;
                        stockAcPayHistDeleteWork.BLGoodsCode = stockAcPayHistWork.BLGoodsCode;
                        stockAcPayHistDeleteWork.BLGoodsFullName = stockAcPayHistWork.BLGoodsFullName;
                        stockAcPayHistDeleteWork.SectionCode = stockAcPayHistWork.SectionCode;
                        stockAcPayHistDeleteWork.SectionGuideNm = stockAcPayHistWork.SectionGuideNm;
                        stockAcPayHistDeleteWork.WarehouseCode = stockAcPayHistWork.WarehouseCode;
                        stockAcPayHistDeleteWork.WarehouseName = stockAcPayHistWork.WarehouseName;
                        stockAcPayHistDeleteWork.ShelfNo = stockAcPayHistWork.ShelfNo;
                        stockAcPayHistDeleteWork.ArrivalCnt = -stockAcPayHistWork.ArrivalCnt;
                        stockAcPayHistDeleteWork.OpenPriceDiv = 0; // 0:通常
                        stockAcPayHistDeleteWork.ListPriceTaxExcFl = stockAcPayHistWork.ListPriceTaxExcFl;
                        stockAcPayHistDeleteWork.StockUnitPriceFl = stockAcPayHistWork.StockUnitPriceFl;
                        stockAcPayHistDeleteWork.StockPrice = -stockAcPayHistWork.StockPrice;
                    }
                    else
                    {
                        stockAcPayHistDeleteWork = null;
                    }
                    // 2010/10/20 Add <<<
                    if (stockAcPayHistWork.IoGoodsDay != prevDateTime) // 売上日付が前回データと違うか？（初回目ふくめ）                        
                    {
                        if (innerList != null)
                        {
                            if (stockAcPayHistDB == null)
                                stockAcPayHistDB = new StockAcPayHistDB();
                            //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                            status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                            if (status == 0)
                                cnt += innerList.Count;
                            else
                                break;
                        }
                        innerList = new ArrayList();
                    }
                    innerList.Add(stockAcPayHistWork);
                    // 2010/10/20 Add >>>
                    if (stockAcPayHistDeleteWork != null)
                    {
                        innerList.Add(stockAcPayHistDeleteWork);
                    }
                    // 2010/10/20 Add <<<
                    prevDateTime = stockAcPayHistWork.IoGoodsDay;
                }
                if (innerList != null && innerList.Count > 0)
                {
                    if (stockAcPayHistDB == null)
                        stockAcPayHistDB = new StockAcPayHistDB();
                    //status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, prevDateTime.Ticks, ref sqlConnection, ref sqlTransaction);
                    status = stockAcPayHistDB.WriteStockAcPayHistProc(ref innerList, ref sqlConnection, ref sqlTransaction);
                    if (status == 0)
                        cnt += innerList.Count;
                }
                else if (cnt == 0) // 0件は正常と見なす。
                {
                    status = 0;
                }
            }
            // --- UPD 2011/09/06---------->>>>>
            // catch { }
            catch (SqlException ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockAdjust", "在庫仕入[在庫調整]から在庫受払履歴データ設定[" + ex.Message + "]", ex.Number);
            }
            catch (Exception ex)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockAdjust", "在庫仕入[在庫調整]から在庫受払履歴データ設定[" + ex.Message + "]", status);
            }
            // --- UPD 2011/09/06----------<<<<<
            finally
            {
                if (myReader != null)
                    myReader.Dispose();
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (sqlCon != null)
                    sqlCon.Dispose();
            }
            #endregion

            // --- ADD 2011/09/06---------->>>>>
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                WriteLog(_enterpriseCode, "SetStockAcPayHistFromStockAdjust", "在庫仕入[在庫調整]から在庫受払履歴データ設定", status);
            }
            // --- ADD 2011/09/06----------<<<<<

            return status;
        }
        #endregion

        #region [ データ補足処理のためのマスタ取得 ]
        /// <summary>
        /// 拠点マスタ情報取得
        /// </summary>
        private void GetSectionInfo()
        {
            SqlConnection sqlCon = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            try
            {
                sqlCon = new SqlConnection(connectionText);
                sqlCon.Open();

                if (sqlCon != null)
                {
                    SectionInfo sectionInfo = new SectionInfo();
                    lstSec = new Dictionary<string, SecInfoSetWork>();

                    CustomSerializeArrayList retList = null;
                    SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
                    secInfoSetWork.EnterpriseCode = _enterpriseCode;
                    int status = sectionInfo.Search(out retList, secInfoSetWork, ref sqlCon, 0, ConstantManagement.LogicalMode.GetDataAll);
                    if (status == 0 && retList.Count > 0)
                    {
                        if (retList[0] is ArrayList)
                        {
                            foreach (ArrayList list in retList)
                            {
                                if (list.Count > 0 && list[0] is SecInfoSetWork)
                                {
                                    foreach (SecInfoSetWork sec in list)
                                    {
                                        lstSec.Add(sec.SectionCode, sec);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            finally
            {
                if (sqlCon != null)
                    sqlCon.Dispose();
            }
        }

        /// <summary>
        /// BLマスタ情報取得
        /// </summary>
        private void GetBlInfo()
        {
            SqlConnection sqlCon = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            try
            {
                sqlCon = new SqlConnection(connectionText);
                sqlCon.Open();

                if (sqlCon != null)
                {
                    BLGoodsCdUDB bLGoodsCdUDB = new BLGoodsCdUDB();
                    lstBLCode = new Dictionary<int, BLGoodsCdUWork>();

                    ArrayList retList = null;
                    BLGoodsCdUWork bLGoodsCdUWork = new BLGoodsCdUWork();
                    bLGoodsCdUWork.EnterpriseCode = _enterpriseCode;
                    int status = bLGoodsCdUDB.SearchBLGoodsCdProc(out retList, bLGoodsCdUWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlCon);
                    if (status == 0)
                    {
                        foreach (BLGoodsCdUWork bl in retList)
                        {
                            lstBLCode.Add(bl.BLGoodsCode, bl);
                        }
                    }
                }
            }
            catch { }
            finally
            {
                if (sqlCon != null)
                    sqlCon.Dispose();
            }
        }

        #region [DELETE]
        // 在庫調整・在庫移動は固定で四捨五入するようになったため下記処理は不要 2008.12.05
        ///// <summary>
        ///// 仕入金額用端数処理情報取得[不要]
        ///// </summary>
        //private void GetStockProcMoneyInfo()
        //{
        //    SqlConnection sqlCon = null;
        //    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
        //    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
        //    try
        //    {
        //        sqlCon = new SqlConnection(connectionText);
        //        sqlCon.Open();

        //        if (sqlCon != null)
        //        {
        //            StockProcMoneyDB stockProcMoneyDB = new StockProcMoneyDB();

        //            ArrayList retList = null;
        //            StockProcMoneyWork stockProcMoneyWork = new StockProcMoneyWork();
        //            stockProcMoneyWork.EnterpriseCode = _enterpriseCode;
        //            stockProcMoneyWork.FracProcMoneyDiv = 0; // 端数処理対象金額区分[0:仕入金額]
        //            stockProcMoneyWork.FractionProcCd = 0; // 自社用（標準）[ 仕入先情報がないため自社用端数コード使用 ]
        //            int status = stockProcMoneyDB.SearchStockProcMoneyProc(out retList, stockProcMoneyWork, 0,
        //                ConstantManagement.LogicalMode.GetData0, ref sqlCon);
        //            if (status == 0 && retList.Count > 0)
        //            {
        //                lstFractionInfo = new List<StockProcMoneyWork>();
        //                foreach (StockProcMoneyWork stockProckMoneyInfo in retList)
        //                {
        //                    bool addFlg = false;
        //                    for (int i = 0; i < lstFractionInfo.Count; i++) // 上限金額の降順で並び処理
        //                    {
        //                        if (stockProckMoneyInfo.UpperLimitPrice > lstFractionInfo[i].UpperLimitPrice)
        //                        {
        //                            lstFractionInfo.Insert(i, stockProckMoneyInfo);
        //                            addFlg = true;
        //                            break;
        //                        }
        //                    }
        //                    if (addFlg == false)
        //                    {
        //                        lstFractionInfo.Add(stockProckMoneyInfo);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch { }
        //    finally
        //    {
        //        if (sqlCon != null)
        //            sqlCon.Dispose();
        //    }
        //}
        #endregion

        /// <summary>
        /// 端数処理を行った仕入金額を算出する
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        private long GetStockPrice(double price)
        {
            double tmpRet;
            long retPrice = 0;
            //for (int i = 0; i < lstFractionInfo.Count; i++)
            //{
            //    if (lstFractionInfo[i].UpperLimitPrice > price)
            //    {
            //        FracCalc(price, lstFractionInfo[i].FractionProcUnit, lstFractionInfo[i].FractionProcCd, out tmpRet);
            //        retPrice = Convert.ToInt64(tmpRet);
            //        break;
            //    }
            //}
            // 売・仕入の場合は端数処理が不要なので在庫関連処理に関してのみ下記の固定四捨五入でOK
            FracCalc(price, 1, 2, out tmpRet); // 端数処理は四捨五入固定とする
            retPrice = Convert.ToInt64(tmpRet);
            return retPrice;
        }

        /// <summary>
        /// 端数処理
        /// </summary>
        /// <param name="inputNumerical">数値</param>
        /// <param name="fractionUnit">端数処理単位</param>
        /// <param name="fractionProcess">端数処理（1:切捨 2:四捨五入 3:切上）</param>
        /// <param name="resultNumerical">算出金額</param>
        private void FracCalc(double inputNumerical, double fractionUnit, Int32 fractionProcess, out double resultNumerical)
        {
            // 初期値セット
            resultNumerical = inputNumerical;

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
            resultNumerical = (double)((decimal)tmpKin * (decimal)fractionUnit);

        }

        // 2009/02/14 ADD >>>>>>>>>>>>>>>>>>>>>>>>
        private bool CheckValueNum(string num)
        {
            //文字列が数値変換可能な範囲か
            try
            {
                Int32.Parse(num);
                return true;
            }
            catch
            {
                return false;
            }
        }
        // 2009/02/14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion

        // --- ADD 2011/09/06---------->>>>>
        /// <summary>
        /// ログ書き込み処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="LogDataObjProcNm">処理名</param>
        /// <param name="LogDataMassage">ログに記録するメッセージ</param>
        /// <param name="status">通常ログの場合は 0 例外ログの場合はメソッドの戻り値など。</param>
        /// <remarks>
        /// <br>Note       : ログ書き込み処理。</br>
        /// <br>Programer  : 李占川</br>
        /// <br>Date       : 2011/09/06</br>
        /// </remarks>
        private void WriteLog(string enterpriseCode, string LogDataObjProcNm, string LogDataMassage, int status)
        {
            OprtnHisLogWork oprtnHisLogWork = new OprtnHisLogWork();
            object obj;

            oprtnHisLogWork.EnterpriseCode = enterpriseCode;
            oprtnHisLogWork.LogDataCreateDateTime = DateTime.Now;
            oprtnHisLogWork.LoginSectionCd = "";
            oprtnHisLogWork.LogDataKindCd = 9;
            oprtnHisLogWork.LogDataObjBootProgramNm = "コンバート処理";
            oprtnHisLogWork.LogDataObjAssemblyID = "PMKHN08003R";
            oprtnHisLogWork.LogDataObjAssemblyNm = "コンバート処理";
            oprtnHisLogWork.LogDataObjClassID = "ConvertProcessDB";
            oprtnHisLogWork.LogDataObjProcNm = LogDataObjProcNm;
            oprtnHisLogWork.LogOperationStatus = 0;
            oprtnHisLogWork.LogOperaterDtProcLvl = "99";
            oprtnHisLogWork.LogOperaterFuncLvl = "99";
            oprtnHisLogWork.LogOperationStatus = status;
            oprtnHisLogWork.LogDataMassage = LogDataMassage;

            obj = oprtnHisLogWork;
            status = _oprtnHisLogDB.Write(ref obj);
        }
        // --- ADD 2011/09/06----------<<<<<

    }
}

