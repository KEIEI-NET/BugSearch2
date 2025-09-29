//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : リモート伝発設定マスタ
// プログラム概要   : リモート伝発設定の登録・修正・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 欧方方
// 作 成 日  2011.08.03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 修 正 日 2011.09.21   修正内容 : #25386 論理削除データ表示不正
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Globarization;
using System.Drawing;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.Web.Services;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : リモート伝発設定マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 欧方方</br>
    /// <br>Date       : 2011.08.03</br>
    /// </remarks>
    public class RmSlpPrtStAcs : IGeneralGuideData
    {
        // --------------------------------------------------
        #region Private Members

        // 企業コード
        private string _enterpriseCode = "";
        //問合せ先企業コード
        private string _inqOtherEpCd = string.Empty;
        //問合せ先拠点コード
        private string _inqOtherSecCd = string.Empty;
        //リモート伝発設定マスタリモートオブジェクト格納バッファ
        private IRmSlpPrtStDB _iRmSlpPrtStDB = null;
        // データセット
        private DataSet _bindDataSet = null;
        private DataTable _rmSlpPrtStTable = null;
        // 印刷設定用帳票コンボボックス用
        private SortedList _slipPrtSetPaperIdList = null;
        // マスタクラス格納リスト
        private Dictionary<string, RmSlpPrtStWork> _rmSlpPrtStDic = null;     // リモート伝発設定マスタ格納用
        // マスタ取得用リスト
        private ArrayList _rmSlpPrtStWorkList = null;                         // リモート伝発設定マスタ取得用
        // プロパティセット用リスト
        private ArrayList _rmSlpPrtStList = null;
        // 伝票印刷設定用マスタアクセスクラス
        private SlipPrtSetAcs _slipPrtSetAcs = null;
        // 得意先
        private CustomerInfoAcs _customerInfoAcs = null;
        // 文字列結合用
        private StringBuilder _stringBuilder = null;
        // 拠点マスタアクセスクラス
        SecInfoAcs _secInfoAcs;

        // ガイド用
        private const string GUIDE_XML_FILENAME = "CUSTSLIPMNGGUIDEPARENT.XML";        // XMLファイル名
        private const string GUIDE_INQORIGINALEPCDRF_TITLE = "InqOriginalEpCd";        // 問合せ元企業コード
        private const string GUIDE_INQORIGINALEPCDRFNAME_TITLE = "InqOriginalEpCdName";// 問合せ元企業名
        private const string GUIDE_INQORIGINALSECCD_TITLE = "InqOriginalSecCd";        // 問合せ元拠点コード
        private const string GUIDE_INQORIGINALSECCDNAME_TITLE = "InqOriginalSecCdName";// 問合せ元拠点名
        private const string GUIDE_INQOTHEREPCDRF_TITLE = "InqOtherEpCd";              // 問合せ先企業コード
        private const string GUIDE_INQOTHEREPCDRFNAME_TITLE = "InqOtherEpCdName";      // 問合せ先企業名
        private const string GUIDE_INQOTHERSECCD_TITLE = "InqOtherSecCd";              // 問合せ先拠点コード
        private const string GUIDE_INQOTHERSECCDNAME_TITLE = "InqOtherSecCdName";      // 問合せ先拠点名
        private const string GUIDE_SLIPPRTKINDID_TITLE = "SlipPrtKindId";              // 伝票印刷種別コード
        private const string GUIDE_SLIPPRTKIND_TITLE = "SlipPrtKind";                  // 伝票印刷種別名称
        private const string GUIDE_SLIPPRTSETPAPERID_TITLE = "SlipPrtSetPaperId";      // 伝票印刷設定用帳票ID
        private const string GUIDE_RMTSLPPRTDIV_TITLE = "RmtSlpPrtDiv";                // リモート伝発区分
        private const string GUIDE_PPCCCOMPANYCODE_TITLE = "PccCompanyCode";           // PCC自社コード
        private const string GUIDE_PPCCCOMPANYCODENAME_TITLE = "PccCompanyCodeName";   // PCC自社名
        private const string GUIDE_CREATEDATETIME_TITLE = "CreateDateTime";            // 作成日時
        private const string GUIDE_UPDATEDATETIME_TITLE = "UpdateDateTime";            // 更新日時
        private const string GUIDE_LOGICALDELETECODE_TITLE = "LogicalDeleteCode";      // 論理削除区分
        // 2011.09.16 zhouzy UPDATE STA >>>>>>
        private const string GUIDE_TOPMARGIN_TITLE = "TopMargin";                      // 上余白
        private const string GUIDE_LEFTMARGINE_TITLE = "LeftMargine";                  // 左余白
                // 2011.09.16 zhouzy UPDATE END <<<<<<

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)

        private const string TBL_RMSLPPRTST_TITLE = "RMSLPPRTST_TABLE";
        private const string COL_DELETEDATE_TITLE = "削除日";
        private const string COL_SLIPPRTKINDID_TITLE = "伝票印刷種別";
        private const string COL_SLIPPRTKIND_TITLE = "伝票印刷種別名";
        private const string COL_SLIPPRTSETPAPERID_TITLE = "伝票印刷設定用帳票ID_Dmmy";
        private const string COL_SLIPPRTSETPAPERNAME_TITLE = "伝票印刷設定用帳票ID";
        private const string COL_RMTSLPPRTDIV_TITLE = "リモート伝発区分";
        private const string COL_INQORIGINALEPCD_TITLE = "問合せ元企業コード";
        private const string COL_INQORIGINALEPCDNAME_TITLE = "問合せ元企業名";
        private const string COL_INQORIGINALSECCD_TITLE = "問合せ元拠点コード";
        private const string COL_INQORIGINALSECCDNAME_TITLE = "問合せ元拠点名";
        private const string COL_INQOTHEREPCD_TITLE = "問合せ先企業コード";
        private const string COL_INQOTHEREPCDNAME_TITLE = "問合せ先企業名";
        private const string COL_INQOTHERSECCD_TITLE = "問合せ先拠点コード";
        private const string COL_INQOTHERSECCDNAME_TITLE = "問合せ先拠点名";
        private const string COL_PCCCOMPANYCODE_TITLE = "得意先コード";
        private const string COL_PCCCOMPANYCODENAME_TITLE = "得意先名";
        private const string COL_CREATEDATETIME_TITLE = "作成日時";
        private const string COL_UPDATEDATETIME_TITLE = "更新日時";
        private const string COL_LOGICALDELETECODE_TITLE = "論理削除区分";
        // 2011.09.16 zhouzy UPDATE STA >>>>>>
        private const string COL_TOPMARGIN_TITLE = "上余白";
        private const string COL_LEFTMARGINE_TITLE = "左余白";
        // 2011.09.16 zhouzy UPDATE END <<<<<<
        private const string COL_GUID_TITLE = "GUID";


        // デフォルトはリモート
        private static bool _isLocalDBRead = false;

        #endregion

        // --------------------------------------------------
        #region enum
        /// <summary>
        /// 入力エラーチェックステータス
        /// </summary>
        private enum InputChkStatus
        {
            // 未入力
            NotInput = -1,
            // 存在しない
            NotExist = -2,
            // 入力ミス
            InputErr = -3,
            // 正常
            Normal = 0,
            // キャンセル
            Cancel = 1,
            // 異なる
            Different
        }

        /// <summary>
        /// 画面データ設定ステータス
        /// </summary>
        private enum DispSetStatus
        {
            // クリア
            Clear = 0,
            // 更新
            Update = 1,
            // 元に戻す
            Back = 2
        }
        #endregion enum

        // --------------------------------------------------
        #region Constructor

        /// <summary>
        ///リモート伝発設定マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : リモート伝発設定マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public RmSlpPrtStAcs()
        {
            try
            {
                // 企業コード取得
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                // 問合せ元企業コード
                this._inqOtherEpCd = this._enterpriseCode.TrimEnd();
                // 問合せ元拠点コード
                this._inqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
                // リモートオブジェクト取得
                this._iRmSlpPrtStDB = (IRmSlpPrtStDB)MediationRmSlpPrtStDB.GetRmSlpPrtStDB();
                // マスタクラス格納リスト初期化
                this._rmSlpPrtStDic = new Dictionary<string, RmSlpPrtStWork>();
                // マスタ取得用リスト初期化
                this._rmSlpPrtStWorkList = new ArrayList();
                // プロパティセット用リスト
                this._rmSlpPrtStList = new ArrayList();
                // データセット初期化
                this._bindDataSet = new DataSet();
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).BeginInit();
                this._bindDataSet.DataSetName = "NewDataSet";
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).EndInit();

                // データセット列情報構築
                this.DataSetColumnConstruction();
                // 伝票印刷設定
                this._slipPrtSetAcs = new SlipPrtSetAcs();
                // 印刷設定用帳票コンボボックス用
                this._slipPrtSetPaperIdList = new SortedList();
                // 文字列結合用
                this._stringBuilder = new StringBuilder();
                // 拠点情報取得部品
                this._secInfoAcs = new SecInfoAcs();
                // 得意先初期化
                this._customerInfoAcs = new CustomerInfoAcs();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iRmSlpPrtStDB = null;
            }

        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///                  データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            // 伝票管理マスタテーブル
            this._rmSlpPrtStTable = new DataTable(TBL_RMSLPPRTST_TITLE);

            // Addを行う順番が、列の表示順位となります。
            this._rmSlpPrtStTable.Columns.Add(COL_DELETEDATE_TITLE, typeof(string));            // 削除日
            this._rmSlpPrtStTable.Columns.Add(COL_SLIPPRTKINDID_TITLE, typeof(string));         // 伝票印刷種別
            this._rmSlpPrtStTable.Columns.Add(COL_SLIPPRTKIND_TITLE, typeof(string));           // 伝票印刷種別名
            this._rmSlpPrtStTable.Columns.Add(COL_INQORIGINALEPCD_TITLE, typeof(string));       // 問合せ元企業コード
            this._rmSlpPrtStTable.Columns.Add(COL_INQORIGINALEPCDNAME_TITLE, typeof(string));   // 問合せ元企業名
            this._rmSlpPrtStTable.Columns.Add(COL_INQORIGINALSECCD_TITLE, typeof(string));      // 問合せ元拠点コード
            this._rmSlpPrtStTable.Columns.Add(COL_INQORIGINALSECCDNAME_TITLE, typeof(string));  // 問合せ元拠点名
            this._rmSlpPrtStTable.Columns.Add(COL_INQOTHEREPCD_TITLE, typeof(string));          // 問合せ先企業コード 
            this._rmSlpPrtStTable.Columns.Add(COL_INQOTHEREPCDNAME_TITLE, typeof(string));      // 問合せ先企業名
            this._rmSlpPrtStTable.Columns.Add(COL_INQOTHERSECCD_TITLE, typeof(string));         // 問合せ先拠点コード
            this._rmSlpPrtStTable.Columns.Add(COL_INQOTHERSECCDNAME_TITLE, typeof(string));     // 問合せ先拠点名
            this._rmSlpPrtStTable.Columns.Add(COL_PCCCOMPANYCODE_TITLE, typeof(Int32));         // PCC自社コード
            this._rmSlpPrtStTable.Columns.Add(COL_PCCCOMPANYCODENAME_TITLE, typeof(string));    // PCC自社名
            this._rmSlpPrtStTable.Columns.Add(COL_SLIPPRTSETPAPERID_TITLE, typeof(string));     // 帳票ID
            this._rmSlpPrtStTable.Columns.Add(COL_SLIPPRTSETPAPERNAME_TITLE, typeof(string));   // 帳票名
            this._rmSlpPrtStTable.Columns.Add(COL_RMTSLPPRTDIV_TITLE, typeof(string));          // リモート伝発区分
            this._rmSlpPrtStTable.Columns.Add(COL_CREATEDATETIME_TITLE, typeof(DateTime));      // 作成日時
            this._rmSlpPrtStTable.Columns.Add(COL_UPDATEDATETIME_TITLE, typeof(DateTime));      // 更新日時   
            this._rmSlpPrtStTable.Columns.Add(COL_LOGICALDELETECODE_TITLE, typeof(Int32));      // 論理削除区分
            this._rmSlpPrtStTable.Columns.Add(COL_GUID_TITLE, typeof(string));                  // GUID
            // 2011.09.16 zhouzy UPDATE STA >>>>>> 
            this._rmSlpPrtStTable.Columns.Add(COL_TOPMARGIN_TITLE, typeof(double));             // 上余白
            this._rmSlpPrtStTable.Columns.Add(COL_LEFTMARGINE_TITLE, typeof(double));           // 左余白
        // 2011.09.16 zhouzy UPDATE END <<<<<<

            this._rmSlpPrtStTable.PrimaryKey = new DataColumn[] { this._rmSlpPrtStTable.Columns[COL_GUID_TITLE] };

            this._bindDataSet.Tables.Add(this._rmSlpPrtStTable);
        }

        #endregion

        // --------------------------------------------------
        #region Properties

        /// <summary>データセットプロパティ</summary>
        /// <value>データセットを取得します。</value>
        public Dictionary<string, RmSlpPrtStWork> RmSlpPrtStDic
        {
            get
            {
                return this._rmSlpPrtStDic;
            }
        }

        /// <summary>データセットプロパティ</summary>
        /// <value>データセットを取得します。</value>
        public DataSet BindDataSet
        {
            get
            {
                return this._bindDataSet;
            }
        }

        /// <summary>リモート伝発設定マスタリスト</summary>
        /// <value>リモート伝発設定マスタを取得します。</value>
        public ArrayList RmSlpPrtStList
        {
            get { return _rmSlpPrtStList; }
        }

        /// <summary>
        /// ローカルＤＢReadモード
        /// </summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
        /// 印刷設定用帳票コンボボックス用
        /// </summary>
        public SortedList SlipPrtSetPaperIdList
        {
            get { return _slipPrtSetPaperIdList; }
            set { _slipPrtSetPaperIdList = value; }
        }

        #endregion

        // --------------------------------------------------
        #region GetOnlineMode

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードの取得を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            // オンラインモードを取得
            if (this._iRmSlpPrtStDB == null)
            {
                // オフライン
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                // オンライン
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        #endregion

        // --------------------------------------------------
        #region Read Methods

        /// <summary>
        ///読み込み処理
        /// </summary>
        /// <param name="RmSlpPrtSt">リモート伝発設定マスタオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="dataInputSystem">リモート伝発区分</param>
        /// <param name="slipPrtKind">伝票印刷種別コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">リモート伝発設定コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の読み込み処理を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int Read(out RmSlpPrtSt RmSlpPrtSt, string enterpriseCode, Int32 dataInputSystem, Int32 slipPrtKind, string sectionCode, Int32 customerCode)
        {
            return this.ReadProc(out RmSlpPrtSt, enterpriseCode, dataInputSystem, slipPrtKind, sectionCode, customerCode);
        }

        /// <summary>
        ///リモート伝発設定マスタ読み込み処理
        /// </summary>
        /// <param name="rmSlpPrtSt">リモート伝発設定マスタオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="rmtSlpPrtDiv">リモート伝発区分</param>
        /// <param name="slipPrtKind">伝票印刷種別</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">リモート伝発設定コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : リモート伝発設定マスタの読み込み処理を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private int ReadProc(out RmSlpPrtSt rmSlpPrtSt, string enterpriseCode, Int32 rmtSlpPrtDiv, Int32 slipPrtKind, string sectionCode, Int32 customerCode)
        {
            int status1 = 0;

            rmSlpPrtSt = null;

            try
            {
                // キー情報をセット
                RmSlpPrtStWork rmSlpPrtStWork = new RmSlpPrtStWork();
                rmSlpPrtStWork.InqOtherEpCd = enterpriseCode;        // 問合せ先企業コード
                rmSlpPrtStWork.RmtSlpPrtDiv = rmtSlpPrtDiv;          // リモート伝発区分
                rmSlpPrtStWork.SlipPrtKind = slipPrtKind;            // 伝票印刷種別
                rmSlpPrtStWork.InqOriginalSecCd = sectionCode;       // 問合せ元拠点コード
                rmSlpPrtStWork.PccCompanyCode = customerCode;        // 得意先コード

                //リモート伝発設定マスタ読み込み
                status1 = this._iRmSlpPrtStDB.Read(ref rmSlpPrtStWork, 0);

                if (status1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果をメンバコピー
                    rmSlpPrtSt = this.CopyToRmSlpPrtStFromRmSlpPrtStWork(rmSlpPrtStWork);
                }

            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                rmSlpPrtSt = null;
                this._iRmSlpPrtStDB = null;

                // 通信エラーは-1を返す
                status1 = -1;
            }

            return status1;
        }

        #endregion

        // --------------------------------------------------
        #region Write Methods

        /// <summary>
        ///書き込み処理
        /// </summary>
        /// <param name="RmSlpPrtSt">リモート伝発設定マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタの書き込み処理を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int Write(RmSlpPrtSt RmSlpPrtSt)
        {
            // リモート伝発設定マスタ更新
            return this.WriteProc(RmSlpPrtSt);
        }

        /// <summary>
        ///リモート伝発設定マスタ書き込み処理
        /// </summary>
        /// <param name="RmSlpPrtSt">リモート伝発設定マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : リモート伝発設定マスタの書き込み処理を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private int WriteProc(RmSlpPrtSt RmSlpPrtSt)
        {
            int status = 0;

            try
            {
                RmSlpPrtStWork rmSlpPrtStWork = new RmSlpPrtStWork();

                // 編集前情報取得
                if (this._rmSlpPrtStDic.ContainsKey(RmSlpPrtSt.EnterpriseCode) == true)
                {
                    rmSlpPrtStWork = (this._rmSlpPrtStDic[RmSlpPrtSt.EnterpriseCode] as RmSlpPrtStWork);
                }

                // 編集情報取得
                CopyToRmSlpPrtStWorkFromDispRmSlpPrtSt(ref rmSlpPrtStWork, RmSlpPrtSt);

                object retObj = (object)rmSlpPrtStWork;

                //リモート伝発設定マスタ書き込み
                status = this._iRmSlpPrtStDB.Write(ref retObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // データセットに追加
                    ArrayList retArray = new ArrayList();
                    retArray = (ArrayList)retObj;
                    rmSlpPrtStWork = (RmSlpPrtStWork)retArray[0];
                    string keyConst = "";
                    keyConst = rmSlpPrtStWork.InqOriginalEpCd.Trim() + rmSlpPrtStWork.InqOriginalSecCd.Trim() + rmSlpPrtStWork.InqOtherEpCd.Trim() + rmSlpPrtStWork.InqOtherSecCd.Trim() + rmSlpPrtStWork.SlipPrtKind;

                    rmSlpPrtStWork.EnterpriseCode = keyConst;

                    this.RmSlpPrtStWorkToDataSet(rmSlpPrtStWork);
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iRmSlpPrtStDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region LogicalDelete Methods

        /// <summary>
        ///論理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">リモート伝発設定マスタGuid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の論理削除処理を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int LogicalDelete(string fileHeaderGuid)
        {
            // リモート伝発設定マスタ論理削除
            return this.LogicalDeleteProc(fileHeaderGuid);
        }

        /// <summary>
        ///リモート伝発設定マスタ論理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">リモート伝発設定マスタGuid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : リモート伝発設定マスタの論理削除処理を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private int LogicalDeleteProc(string fileHeaderGuid)
        {
            int status = 0;

            try
            {
                // 編集前情報取得
                RmSlpPrtStWork rmSlpPrtStWork = (this._rmSlpPrtStDic[fileHeaderGuid] as RmSlpPrtStWork);

                object retObj = (object)rmSlpPrtStWork;

                //リモート伝発設定マスタ論理削除
                status = this._iRmSlpPrtStDB.LogicalDelete(ref retObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // データセットに追加
                    rmSlpPrtStWork = (RmSlpPrtStWork)retObj;
                    //-----ADD by huanghx for #25386 論理削除データ表示不正 on 20110921 ----->>>>>
                    string keyConst = "";
                    keyConst = rmSlpPrtStWork.InqOriginalEpCd.Trim() + rmSlpPrtStWork.InqOriginalSecCd.Trim() + rmSlpPrtStWork.InqOtherEpCd.Trim() + rmSlpPrtStWork.InqOtherSecCd.Trim() + rmSlpPrtStWork.SlipPrtKind;
                    rmSlpPrtStWork.EnterpriseCode = keyConst;
                    //-----ADD by huanghx for #25386 論理削除データ表示不正 on 20110921 -----<<<<<
                    this.RmSlpPrtStWorkToDataSet(rmSlpPrtStWork);
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iRmSlpPrtStDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region Revival Methods

        /// <summary>
        ///論理削除復活処理
        /// </summary>
        /// <param name="fileHeaderGuid">リモート伝発設定マスタGuid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の論理削除復活処理を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int Revival(string fileHeaderGuid)
        {
            // リモート伝発設定マスタ復活
            return this.RevivalProc(fileHeaderGuid);
        }

        /// <summary>
        ///リモート伝発設定マスタ論理削除復活処理
        /// </summary>
        /// <param name="fileHeaderGuid">リモート伝発設定マスタGuid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : リモート伝発設定マスタの論理削除復活処理を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private int RevivalProc(string fileHeaderGuid)
        {
            int status = 0;

            try
            {
                // 編集前情報取得
                RmSlpPrtStWork rmSlpPrtStWork = (this._rmSlpPrtStDic[fileHeaderGuid] as RmSlpPrtStWork);

                object retObj = (object)rmSlpPrtStWork;

                //リモート伝発設定マスタ論理削除復活
                status = this._iRmSlpPrtStDB.RevivalLogicalDelete(ref retObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // データセットに追加
                    rmSlpPrtStWork = (RmSlpPrtStWork)retObj;
                    //-----ADD by huanghx for #25386 論理削除データ表示不正 on 20110921 ----->>>>>
                    string keyConst = "";
                    keyConst = rmSlpPrtStWork.InqOriginalEpCd.Trim() + rmSlpPrtStWork.InqOriginalSecCd.Trim() + rmSlpPrtStWork.InqOtherEpCd.Trim() + rmSlpPrtStWork.InqOtherSecCd.Trim() + rmSlpPrtStWork.SlipPrtKind;
                    rmSlpPrtStWork.EnterpriseCode = keyConst;
                    //-----ADD by huanghx for #25386 論理削除データ表示不正 on 20110921 -----<<<<<
                    
                    this.RmSlpPrtStWorkToDataSet(rmSlpPrtStWork);
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iRmSlpPrtStDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region Delete Methods

        /// <summary>
        ///物理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">リモート伝発設定マスタGuid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の物理削除処理を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int Delete(string fileHeaderGuid)
        {
            // リモート伝発設定マスタ物理削除
            return this.DeleteProc(fileHeaderGuid);
        }

        /// <summary>
        ///リモート伝発設定マスタ物理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">リモート伝発設定マスタGuid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : リモート伝発設定マスタの物理削除処理を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private int DeleteProc(string fileHeaderGuid)
        {
            int status = 0;

            try
            {
                // 編集前情報取得
                RmSlpPrtStWork rmSlpPrtStWork = (this._rmSlpPrtStDic[fileHeaderGuid] as RmSlpPrtStWork);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(rmSlpPrtStWork);

                //リモート伝発設定マスタ物理削除
                status = this._iRmSlpPrtStDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 詳細グリッド用キャッシュテーブルから削除
                    this._rmSlpPrtStDic.Remove(rmSlpPrtStWork.EnterpriseCode);
                    // データテーブルから削除
                    DataRow dr = this._rmSlpPrtStTable.Rows.Find(rmSlpPrtStWork.EnterpriseCode);

                    dr.Delete();
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iRmSlpPrtStDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region Search Methods

        /// <summary>
        ///検索処理(論理削除除く)
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="inqOtherSecCd">拠点コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データは検索対象外です。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int Search(out int totalCount, string enterpriseCode, string inqOtherSecCd)
        {
            // リモート伝発設定マスタ検索
            return this.SearchProc(out totalCount, enterpriseCode, inqOtherSecCd, ConstantManagement.LogicalMode.GetData0);
        }

        /// <summary>
        /// 検索処理（論理削除除く、RmSlpPrtStのみSearch）
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="inqOtherSecCd">拠点コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データは検索対象外です。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int SearchOnlyRmSlpPrtSt(out int totalCount, string enterpriseCode, string inqOtherSecCd)
        {
            return this.SearchProcOnlyRmSlpPrtSt(out totalCount, enterpriseCode, inqOtherSecCd, ConstantManagement.LogicalMode.GetData0);
        }

        /// <summary>
        ///検索処理(論理削除含む)
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="inqOtherSecCd">拠点コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データも検索対象に含みます。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int SearchAll(out int totalCount, string enterpriseCode, string inqOtherSecCd)
        {
            // リモート伝発設定マスタ検索
            return this.SearchProc(out totalCount, enterpriseCode, inqOtherSecCd, ConstantManagement.LogicalMode.GetData01);

        }

        /// <summary>
        ///検索処理
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="inqOtherSecCd">拠点コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private int SearchProc(out int totalCount, string enterpriseCode, string inqOtherSecCd, ConstantManagement.LogicalMode logicalMode)
        {
            int status1 = 0;
            int status2 = 0;
            int status = 0;


            // 伝票印刷設定用帳票ID全取得
            ArrayList slipPrtRetList = null;

            try
            {
                // 伝票印刷設定用ローカルフラグ設定
                this._slipPrtSetAcs.IsLocalDBRead = _isLocalDBRead;
                status = this._slipPrtSetAcs.SearchSlipPrtSet(out slipPrtRetList, enterpriseCode);
            }
            catch { }


            if ((status == 0) && (slipPrtRetList != null) && (slipPrtRetList.Count > 0))
            {
                this._slipPrtSetPaperIdList = new SortedList();

                string key = "";

                foreach (SlipPrtSet slipPrtSet in (ArrayList)slipPrtRetList)
                {
                    //--------------------------------------------------------------------
                    // Key  ：ファイルレイアウトのキー項目を結合する
                    //   ﾃﾞｰﾀ入力ｼｽﾃﾑ(2桁) + 伝票印刷種別(4桁)＋伝票印刷設定用帳票ID(24桁)
                    // Value：伝票印刷設定マスタクラス
                    //--------------------------------------------------------------------
                    this._stringBuilder.Remove(0, this._stringBuilder.Length);
                    this._stringBuilder.Append(slipPrtSet.DataInputSystem.ToString("d2"));
                    this._stringBuilder.Append(slipPrtSet.SlipPrtKind.ToString("d4"));
                    this._stringBuilder.Append(slipPrtSet.SlipPrtSetPaperId.TrimEnd());
                    key = this._stringBuilder.ToString();

                    this._slipPrtSetPaperIdList.Add(key, slipPrtSet);
                }
            }

            // リモート伝発設定マスタ検索
            status1 = this.SearchSlipTypeMngProc(out totalCount, enterpriseCode, inqOtherSecCd, logicalMode);


            if ((status1 != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                return status1;
            }

            if (totalCount > 0)
            {
                // キャッシュ処理
                status2 = this.Cache(this._rmSlpPrtStWorkList);
            }
            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status2;
            }


            // ステータス判断
            if ((status1 == (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                (status2 == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// リモート伝発設定マスタ検索処理（RmSlpPrtStのみSearch）
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="inqOtherSecCd">拠点コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private int SearchProcOnlyRmSlpPrtSt(out int totalCount, string enterpriseCode, string inqOtherSecCd, ConstantManagement.LogicalMode logicalMode)
        {
            return this.SearchSlipTypeMngProc(out totalCount, enterpriseCode, inqOtherSecCd, logicalMode);
        }

        /// <summary>
        ///リモート伝発設定マスタ検索処理
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="inqOtherSecCd">拠点コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : リモート伝発設定マスタの検索処理を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private int SearchSlipTypeMngProc(out int totalCount, string enterpriseCode, string inqOtherSecCd, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;
            totalCount = 0;

            try
            {
                // 取得リスト初期化
                this._rmSlpPrtStWorkList.Clear();

                // プロパティセット用リスト
                this._rmSlpPrtStList.Clear();

                // キャッシュ用テーブルをクリア
                this._rmSlpPrtStDic.Clear();

                // キー情報をセット
                RmSlpPrtStWork paramRmSlpPrtStWork = new RmSlpPrtStWork();
                paramRmSlpPrtStWork.InqOtherEpCd = enterpriseCode;    // 企業コード
                paramRmSlpPrtStWork.InqOtherSecCd = inqOtherSecCd;    // 拠点コード

                object retobj = null;


                //リモート伝発設定マスタ検索
                status = this._iRmSlpPrtStDB.Search(out retobj, paramRmSlpPrtStWork, 0, logicalMode);


                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._rmSlpPrtStWorkList = retobj as ArrayList;

                    if (this._rmSlpPrtStWorkList != null && this._rmSlpPrtStWorkList.Count > 0)
                    {
                        // プロパティセット用リスト作成
                        this._rmSlpPrtStList = this.CopyToRmSlpPrtStListFromRmSlpPrtStWorkList(this._rmSlpPrtStWorkList);
                        // 該当件数格納
                        totalCount = this._rmSlpPrtStWorkList.Count;
                    }

                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                }
            }
            catch (Exception ex)
            {
                // オフライン時はnullをセット
                this._iRmSlpPrtStDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }
        #endregion

        // --------------------------------------------------
        #region Cache Methods

        /// <summary>
        /// マスタキャッシュ処理
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">伝票管理マスタ取得結果リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報のキャッシュ処理を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int Cache(ArrayList rmSlpPrtStWorkList)
        {
            try
            {
                try
                {
                    // 更新処理開始
                    this._rmSlpPrtStTable.BeginLoadData();

                    // テーブルをクリア
                    this._rmSlpPrtStTable.Clear();

                    // 管理データをDataSetに格納
                    foreach (RmSlpPrtStWork rmSlpPrtStWork in rmSlpPrtStWorkList)
                    {
                        switch (rmSlpPrtStWork.SlipPrtKind)
                        {
                            case 10:        // 見積書
                            case 30:        // 売上伝票
                            case 120:       // 受注伝票
                            case 130:       // 貸出伝票
                            case 140:       // 見積伝票
                            case 150:       // 在庫移動伝票
                            case 160:       // ＵＯＥ伝票
                                {
                                    this.RmSlpPrtStWorkToDataSet(rmSlpPrtStWork);
                                    break;
                                }
                        }
                    }
                }
                finally
                {
                    // 更新処理終了
                    this._rmSlpPrtStTable.EndLoadData();

                    // ソート
                    this._rmSlpPrtStTable.DefaultView.Sort = COL_SLIPPRTKIND_TITLE + " ASC";           // 伝票印刷種別コード
                    this._rmSlpPrtStTable.AcceptChanges();
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return 0;
        }

        #endregion

        // --------------------------------------------------
        #region MemberCopy Methods

        /// <summary>
        /// クラスメンバコピー処理 (画面変更リモート伝発設定マスタクラス⇒リモート伝発設定マスタワーククラス)
        /// </summary>
        /// <param name="rmSlpPrtStWork">リモート伝発設定マスタワーククラス</param>
        /// <param name="RmSlpPrtSt">リモート伝発設定マスタクラス</param>
        /// <remarks>
        /// <br>Note       : 画面変更リモート伝発設定マスタクラスから
        ///                  リモート伝発設定マスタワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private void CopyToRmSlpPrtStWorkFromDispRmSlpPrtSt(ref RmSlpPrtStWork rmSlpPrtStWork, RmSlpPrtSt RmSlpPrtSt)
        {
            rmSlpPrtStWork.CreateDateTime = RmSlpPrtSt.CreateDateTime;          // 作成日時  
            rmSlpPrtStWork.UpdateDateTime = RmSlpPrtSt.UpdateDateTime;          // 更新日時
            rmSlpPrtStWork.SlipPrtKind = RmSlpPrtSt.SlipPrtKind;                // 伝票印刷種別
            rmSlpPrtStWork.SlipPrtSetPaperId = RmSlpPrtSt.SlipPrtSetPaperId;    // 伝票印刷設定用帳票ID
            rmSlpPrtStWork.InqOriginalEpCd = RmSlpPrtSt.InqOriginalEpCd.Trim();        // 問合せ元企業コード//@@@@20230303
            rmSlpPrtStWork.InqOriginalSecCd = RmSlpPrtSt.InqOriginalSecCd;      // 問合せ元拠点コード
            rmSlpPrtStWork.InqOtherEpCd = RmSlpPrtSt.InqOtherEpCd;              // 問合せ先企業コード
            rmSlpPrtStWork.InqOtherSecCd = RmSlpPrtSt.InqOtherSecCd;            // 問合せ先拠点コード
            rmSlpPrtStWork.RmtSlpPrtDiv = RmSlpPrtSt.RmtSlpPrtDiv;              // リモート伝発区分
            rmSlpPrtStWork.PccCompanyCode = RmSlpPrtSt.PccCompanyCode;          // 得意先コード
            rmSlpPrtStWork.LogicalDeleteCode = RmSlpPrtSt.LogicalDeleteCode;    // 論理削除区分
            // 2011.09.16 zhouzy UPDATE STA >>>>>>
            rmSlpPrtStWork.TopMargin = RmSlpPrtSt.TopMargin;                                        // 上余白
            rmSlpPrtStWork.LeftMargin = RmSlpPrtSt.LeftMargin;                                       // 左余白
            // 2011.09.16 zhouzy UPDATE END <<<<<<

        }

        /// <summary>
        /// リモート伝発処理
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">リモート伝発取得結果リスト</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Note       : リモート伝発処理を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private ArrayList CopyToRmSlpPrtStListFromRmSlpPrtStWorkList(ArrayList rmSlpPrtStWorkList)
        {
            ArrayList retList = new ArrayList();
            foreach (RmSlpPrtStWork rmSlpPrtStWork in rmSlpPrtStWorkList)
            {
                switch (rmSlpPrtStWork.SlipPrtKind)
                {
                    case 10:        // 見積書
                    case 30:        // 売上伝票
                    case 120:       // 受注伝票
                    case 130:       // 貸出伝票
                    case 140:       // 見積伝票
                    case 150:       // 在庫移動伝票
                    case 160:       // ＵＯＥ伝票
                        {
                            RmSlpPrtSt RmSlpPrtSt = this.CopyToRmSlpPrtStFromRmSlpPrtStWork(rmSlpPrtStWork);
                            retList.Add(RmSlpPrtSt);
                            break;
                        }
                }
            }
            return retList;
        }

        /// <summary>
        /// クラスメンバコピー処理 (リモート伝発設定マスタワーククラス⇒リモート伝発設定マスタクラス)
        /// </summary>
        /// <param name="rmSlpPrtStWork">リモート伝発設定マスタワーククラス</param>
        /// <returns>リモート伝発設定マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : リモート伝発設定マスタワーククラスから
        ///                  リモート伝発設定マスタクラスへメンバコピーを行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private RmSlpPrtSt CopyToRmSlpPrtStFromRmSlpPrtStWork(RmSlpPrtStWork rmSlpPrtStWork)
        {
            RmSlpPrtSt rmSlpPrtSt = new RmSlpPrtSt();
            string keyConst = "";
            rmSlpPrtSt.CreateDateTime = rmSlpPrtStWork.CreateDateTime;        // 作成日時
            rmSlpPrtSt.UpdateDateTime = rmSlpPrtStWork.UpdateDateTime;        // 更新日時
            rmSlpPrtSt.SlipPrtKind = rmSlpPrtStWork.SlipPrtKind;              // 伝票印刷種別
            rmSlpPrtSt.SlipPrtSetPaperId = rmSlpPrtStWork.SlipPrtSetPaperId;  // 伝票印刷設定用帳票ID
            rmSlpPrtSt.InqOriginalEpCd = rmSlpPrtStWork.InqOriginalEpCd.Trim();      // 問合せ元企業コード//@@@@20230303
            rmSlpPrtSt.InqOriginalSecCd = rmSlpPrtStWork.InqOriginalSecCd;    // 問合せ元拠点コード
            rmSlpPrtSt.InqOtherEpCd = rmSlpPrtStWork.InqOtherEpCd;            // 問合せ先企業コード
            rmSlpPrtSt.InqOtherSecCd = rmSlpPrtStWork.InqOtherSecCd;          // 問合せ先拠点コード
            rmSlpPrtSt.RmtSlpPrtDiv = rmSlpPrtStWork.RmtSlpPrtDiv;            // リモート伝発区分
            rmSlpPrtSt.PccCompanyCode = rmSlpPrtStWork.PccCompanyCode;        // 得意先コード
            rmSlpPrtSt.LogicalDeleteCode = rmSlpPrtStWork.LogicalDeleteCode;  // 論理削除区分
            rmSlpPrtSt.FileHeaderGuid = rmSlpPrtStWork.FileHeaderGuid;        // GUID
            rmSlpPrtSt.UpdEmployeeCode = "";                                  // 更新従業員コード
            rmSlpPrtSt.UpdAssemblyId1 = "";                                   // 更新アセンブリID1
            rmSlpPrtSt.UpdAssemblyId2 = "";                                   // 更新アセンブリID2
            // 2011.09.16 zhouzy UPDATE STA >>>>>>
            rmSlpPrtSt.TopMargin = rmSlpPrtStWork.TopMargin;                                        // 上余白
            rmSlpPrtSt.LeftMargin = rmSlpPrtStWork.LeftMargin;                                       // 左余白
            // 2011.09.16 zhouzy UPDATE END <<<<<<

            // 条件組合
            keyConst = rmSlpPrtSt.InqOriginalEpCd.Trim() + rmSlpPrtSt.InqOriginalSecCd.Trim() + rmSlpPrtSt.InqOtherEpCd.Trim() + rmSlpPrtSt.InqOtherSecCd.Trim() + rmSlpPrtSt.SlipPrtKind;

            rmSlpPrtStWork.EnterpriseCode = keyConst;
            rmSlpPrtSt.EnterpriseCode = rmSlpPrtStWork.EnterpriseCode;

            // テーブル更新
            _rmSlpPrtStDic[rmSlpPrtSt.EnterpriseCode] = rmSlpPrtStWork;

            return rmSlpPrtSt;
        }

        /// <summary>
        /// リモート伝発設定マスタオブジェクトメインDataSet展開処理
        /// </summary>
        /// <param name="rmSlpPrtStWork">リモート伝発設定マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : リモート伝発設定マスタオブジェクトを、メインDataSetに格納します。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private void RmSlpPrtStWorkToDataSet(RmSlpPrtStWork rmSlpPrtStWork)
        {
            bool newFlg = false;    // 新規・既存フラグ

            // 更新対象行の取得
            DataRow dr = this._rmSlpPrtStTable.Rows.Find(rmSlpPrtStWork.EnterpriseCode);
            if (dr == null)
            {
                // 新規に行を作成
                dr = this._rmSlpPrtStTable.NewRow();

                // 新規レコードチェック
                newFlg = true;
            }

            #region 削除日
            // 削除日
            if (rmSlpPrtStWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", rmSlpPrtStWork.UpdateDateTime);
            }
            #endregion

            #region 伝票印刷種別 伝票印刷種別名称
            // 伝票印刷種別
            dr[COL_SLIPPRTKINDID_TITLE] = rmSlpPrtStWork.SlipPrtKind;
            // 伝票印刷種別名称
            switch (rmSlpPrtStWork.SlipPrtKind)
            {
                case 10:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "見積書";
                        break;
                    }
                case 20:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "指示書(注文書)";
                        break;
                    }
                case 21:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "承り書";
                        break;
                    }
                case 30:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "納品書";
                        break;
                    }
                case 40:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "返品伝票";
                        break;
                    }
                case 100:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "ワークシート";
                        break;
                    }
                case 110:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "ボディ寸法図";
                        break;
                    }
                case 120:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "受注伝票";
                        break;
                    }
                case 130:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "貸出伝票";
                        break;
                    }
                case 140:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "見積伝票";
                        break;
                    }
                case 150:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "在庫移動伝票";
                        break;
                    }
                case 160:
                    {
                        dr[COL_SLIPPRTKIND_TITLE] = "ＵＯＥ伝票";
                        break;
                    }
            }
            #endregion

            #region 得意先 得意先名
            // 得意先
            dr[COL_PCCCOMPANYCODE_TITLE] = rmSlpPrtStWork.PccCompanyCode;

            // 条件設定クリア
            object inParamObj = null;
            object outParamObj = null;
            // 条件設定
            inParamObj = rmSlpPrtStWork.PccCompanyCode;
            this.CheckCustomerCode(inParamObj, out outParamObj);
            // 得意先名の設定
            if ((outParamObj != null) &&
                (((ArrayList)outParamObj).Count == 2) &&
                (((ArrayList)outParamObj)[1] is string))
            {
                dr[COL_PCCCOMPANYCODENAME_TITLE] = (string)((ArrayList)outParamObj)[1];  // 得意先名称
            }
            else
            {
                dr[COL_PCCCOMPANYCODENAME_TITLE] = "";
            }
            #endregion

            #region 伝票印刷設定用帳票ID 名称
            // 伝票印刷設定用帳票ID 
            dr[COL_SLIPPRTSETPAPERID_TITLE] = rmSlpPrtStWork.SlipPrtSetPaperId;

            // 伝票印刷設定用帳票名称
            dr[COL_SLIPPRTSETPAPERNAME_TITLE] = GetSlipPrtSetPaperName(rmSlpPrtStWork);
            #endregion

            #region リモート伝発区分
            // リモート伝発区分 
            if (rmSlpPrtStWork.RmtSlpPrtDiv == 0)  // 0:発行しない, 1:発行する
            {
                dr[COL_RMTSLPPRTDIV_TITLE] = "発行しない";
            }
            else
            {
                dr[COL_RMTSLPPRTDIV_TITLE] = "発行する";
            }
            #endregion

            #region コード
            bool msgDiv;
            string errMsg;
            int i = 0;
            List<ScmEpCnect> scmEpCnectWorks = null;
            List<ScmEpScCnt> scmEpScCntWorks = null;
            ScmEpCnect aimScmEpCnectWork = null;
            ScmEpScCnt aimScmEpScCntWork = null;

            ScmEpScCntAcs scmEpScCntAcs = new ScmEpScCntAcs();
            int status = scmEpScCntAcs.SearchAll(string.Empty, string.Empty, 0, out scmEpCnectWorks, out scmEpScCntWorks, out msgDiv, out errMsg);


            //拠点
            if (rmSlpPrtStWork.InqOriginalEpCd.Trim().Equals("00") && rmSlpPrtStWork.InqOriginalSecCd.Trim().Equals("00"))
            {
                //問合せ元企業コード
                dr[COL_INQORIGINALEPCD_TITLE] = "";
                dr[COL_INQORIGINALEPCDNAME_TITLE] = "";
                // 問合せ元拠点コード
                dr[COL_INQORIGINALSECCD_TITLE] = "";
                dr[COL_INQORIGINALSECCDNAME_TITLE] = "";

                // 問合せ先企業コード
                dr[COL_INQOTHEREPCD_TITLE] = rmSlpPrtStWork.InqOtherEpCd;

                for (i = 0; i < scmEpCnectWorks.Count; i++)
                {
                    if (scmEpCnectWorks[i].CnectOtherEpCd == rmSlpPrtStWork.InqOtherEpCd)
                    {
                        aimScmEpCnectWork = scmEpCnectWorks[i] as ScmEpCnect;
                        dr[COL_INQOTHEREPCDNAME_TITLE] = aimScmEpCnectWork.CnectOtherEpNm;
                        break;
                    }

                }

                // 問合せ先拠点コード
                dr[COL_INQOTHERSECCD_TITLE] = rmSlpPrtStWork.InqOtherSecCd;
                for (i = 0; i < scmEpScCntWorks.Count; i++)
                {
                    if (scmEpScCntWorks[i].CnectOtherEpCd == rmSlpPrtStWork.InqOtherEpCd && scmEpScCntWorks[i].CnectOtherSecCd == rmSlpPrtStWork.InqOtherSecCd)
                    {
                        aimScmEpScCntWork = scmEpScCntWorks[i] as ScmEpScCnt;
                        dr[COL_INQOTHERSECCDNAME_TITLE] = aimScmEpScCntWork.CnectOtherSecNm;
                        break;
                    }
                }

            }
            else//得意先
            {
                //問合せ元企業コード
                dr[COL_INQORIGINALEPCD_TITLE] = rmSlpPrtStWork.InqOriginalEpCd.Trim();//@@@@20230303
                // 問合せ元拠点コード
                dr[COL_INQORIGINALSECCD_TITLE] = rmSlpPrtStWork.InqOriginalSecCd;
                // 問合せ先企業コード
                dr[COL_INQOTHEREPCD_TITLE] = rmSlpPrtStWork.InqOtherEpCd;
                // 問合せ先拠点コード
                dr[COL_INQOTHERSECCD_TITLE] = rmSlpPrtStWork.InqOtherSecCd;

                for (i = 0; i < scmEpCnectWorks.Count; i++)
                {
                    if (scmEpCnectWorks[i].CnectOtherEpCd == rmSlpPrtStWork.InqOtherEpCd && scmEpCnectWorks[i].CnectOriginalEpCd.Trim() == rmSlpPrtStWork.InqOriginalEpCd.Trim())//@@@@20230303
                    {
                        aimScmEpCnectWork = scmEpCnectWorks[i] as ScmEpCnect;
                        dr[COL_INQOTHEREPCDNAME_TITLE] = aimScmEpCnectWork.CnectOtherEpNm;
                        dr[COL_INQORIGINALEPCDNAME_TITLE] = aimScmEpCnectWork.CnectOriginalEpNm;
                        break;
                    }

                }

                for (i = 0; i < scmEpScCntWorks.Count; i++)
                {
                    if (scmEpScCntWorks[i].CnectOtherEpCd == rmSlpPrtStWork.InqOtherEpCd && scmEpScCntWorks[i].CnectOriginalEpCd.Trim() == rmSlpPrtStWork.InqOriginalEpCd.Trim())//@@@@20230303
                    {
                        aimScmEpScCntWork = scmEpScCntWorks[i] as ScmEpScCnt;
                        if (scmEpScCntWorks[i].CnectOtherSecCd == rmSlpPrtStWork.InqOtherSecCd)
                        {
                            dr[COL_INQOTHERSECCDNAME_TITLE] = aimScmEpScCntWork.CnectOtherSecNm;
                            break;
                        }
                    }
                }

                for (i = 0; i < scmEpScCntWorks.Count; i++)
                {
                    if (scmEpScCntWorks[i].CnectOtherEpCd == rmSlpPrtStWork.InqOtherEpCd && scmEpScCntWorks[i].CnectOriginalEpCd.Trim() == rmSlpPrtStWork.InqOriginalEpCd.Trim())//@@@@20230303
                    {
                        aimScmEpScCntWork = scmEpScCntWorks[i] as ScmEpScCnt;
                        if (scmEpScCntWorks[i].CnectOriginalSecCd == rmSlpPrtStWork.InqOriginalSecCd)
                        {
                            dr[COL_INQORIGINALSECCDNAME_TITLE] = aimScmEpScCntWork.CnectOriginalSecNm;
                            break;
                        }
                    }
                }

            }

            // 拠点名称 問合せ元拠点コード
            if ((int.Parse(rmSlpPrtStWork.InqOtherSecCd.Trim()) == 0))
            {
                // 拠点コードがゼロで、得意先コードが設定されていない
                dr[COL_INQOTHERSECCDNAME_TITLE] = "全社共通";
            }
            else
            {
                dr[COL_INQOTHERSECCDNAME_TITLE] = GetSectionName(rmSlpPrtStWork.InqOtherSecCd);
            }
            #endregion

            #region その他

            // GUID 
            dr[COL_GUID_TITLE] = rmSlpPrtStWork.EnterpriseCode;

            // 作成日時
            dr[COL_CREATEDATETIME_TITLE] = rmSlpPrtStWork.CreateDateTime;

            // 更新日時
            dr[COL_UPDATEDATETIME_TITLE] = rmSlpPrtStWork.UpdateDateTime;

            // 論理削除区分
            dr[COL_LOGICALDELETECODE_TITLE] = rmSlpPrtStWork.LogicalDeleteCode;

            // 2011.09.16 zhouzy UPDATE STA >>>>>>
            // 上余白
            dr[COL_TOPMARGIN_TITLE] = rmSlpPrtStWork.TopMargin;
            // 左余白
            dr[COL_LEFTMARGINE_TITLE] = rmSlpPrtStWork.LeftMargin;
            // 2011.09.16 zhouzy UPDATE END <<<<<<
            #endregion

            // 新規レコードの場合のみ
            if (newFlg == true)
            {
                // 新規行の追加
                this._rmSlpPrtStTable.Rows.Add(dr);
            }

            // テーブルに格納
            if (this._rmSlpPrtStDic.ContainsKey(rmSlpPrtStWork.EnterpriseCode) == true)
            {
                this._rmSlpPrtStDic.Remove(rmSlpPrtStWork.EnterpriseCode);
            }
            this._rmSlpPrtStDic.Add(rmSlpPrtStWork.EnterpriseCode, rmSlpPrtStWork);
        }

        /// <summary>
        /// 得意先コードエラーチェック処理
        /// </summary>
        /// <param name="inParamObj">条件オブジェクト</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <returns>チェック結果（0:正常 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note       : 得意先コードエラーチェックを行います。</br>
        ///	<br>			 条件オブジェクト:得意先コード</br>
        ///	<br>			 結果オブジェクト:得意先マスタ検索結果ステータス, 得意先名称</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private void CheckCustomerCode(object inParamObj, out object outParamObj)
        {
            //-------------------------------------------------------------
            // 初期値設定
            //-------------------------------------------------------------
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //-------------------------------------------------------------
                // 実行チェック
                //-------------------------------------------------------------
                if (inParamObj == null) return;             // 入力なし
                if ((inParamObj is int) == false) return;   // 入力値Ｉｎｔ以外
                if ((int)inParamObj == 0) return;           // 入力値ゼロ

                //-------------------------------------------------------------
                // 得意先マスタ読込
                //-------------------------------------------------------------
                CustomerInfo customerInfo = null;
                ret = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, (int)inParamObj, out customerInfo);
                outParamList.Add(status);	// 得意先マスタステータス設定

                //-------------------------------------------------------------
                // 得意先情報設定
                //-------------------------------------------------------------
                if (customerInfo != null)
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(customerInfo.CustomerSnm);	// 得意先略称設定
                }
                else
                {
                    ret = (int)InputChkStatus.NotExist;
                }
            }
            catch (Exception)
            {
            }
            outParamObj = outParamList;

        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks> 
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        /// <summary>
        /// 印刷設定用帳票名称名称取得処理
        /// </summary>
        /// <param name="rmSlpPrtStWork">印刷設定用帳票ID</param>
        /// <returns>印刷設定用帳票名称</returns>
        /// <remarks>
        /// <br>Note       : 印刷設定用帳票名称を取得します。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks> 
        private string GetSlipPrtSetPaperName(RmSlpPrtStWork rmSlpPrtStWork)
        {
            string slipPrtSetPaperName = "";

            foreach (DictionaryEntry de in this._slipPrtSetPaperIdList)
            {
                SlipPrtSet slipPrtSetWk = (SlipPrtSet)de.Value;
                if (rmSlpPrtStWork.SlipPrtSetPaperId.TrimEnd().Equals(slipPrtSetWk.SlipPrtSetPaperId))
                {
                    slipPrtSetPaperName = slipPrtSetWk.SlipComment.TrimEnd();
                }
            }

            return slipPrtSetPaperName;

        }
        #endregion

        // --------------------------------------------------
        #region Guide Methods

        /// <summary>
        /// マスタガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="RmSlpPrtSt">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note       : マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out RmSlpPrtSt RmSlpPrtSt)
        {
            int status = -1;
            RmSlpPrtSt = new RmSlpPrtSt();

            TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add(GUIDE_INQOTHEREPCDRF_TITLE, enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                RmSlpPrtSt.SlipPrtKind = (int)retObj[GUIDE_SLIPPRTKIND_TITLE];                          // 伝票印刷種別
                RmSlpPrtSt.SlipPrtSetPaperId = retObj[GUIDE_SLIPPRTSETPAPERID_TITLE].ToString();        // 帳票ID
                RmSlpPrtSt.InqOriginalSecCd = retObj[GUIDE_INQORIGINALSECCD_TITLE].ToString();          // 問合せ元企業コード
                RmSlpPrtSt.InqOriginalEpCd = retObj[GUIDE_INQORIGINALEPCDRF_TITLE].ToString().Trim();          // 問合せ元拠点コード//@@@@20230303
                RmSlpPrtSt.InqOtherEpCd = retObj[GUIDE_INQOTHEREPCDRF_TITLE].ToString();                // 問合せ先企業コード
                RmSlpPrtSt.InqOtherSecCd = retObj[GUIDE_INQOTHERSECCD_TITLE].ToString();                // 問合せ先拠点コード
                RmSlpPrtSt.RmtSlpPrtDiv = (int)retObj[GUIDE_RMTSLPPRTDIV_TITLE];                        // リモート伝発区分
                RmSlpPrtSt.PccCompanyCode = (int)retObj[GUIDE_PPCCCOMPANYCODE_TITLE];                   // 得意先コード

                status = 0;
            }
            // キャンセル
            else
            {
                status = 1;
            }

            return status;
        }

        /// <summary>
        /// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note	   : 汎用ガイド設定用データを取得します。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";
            string inqOtherSeCd = "";

            // 企業コード設定有り
            if (inParm.ContainsKey(GUIDE_INQOTHEREPCDRF_TITLE))
            {
                enterpriseCode = inParm[GUIDE_INQOTHEREPCDRF_TITLE].ToString();
                inqOtherSeCd = inParm[GUIDE_INQOTHERSECCD_TITLE].ToString();
            }
            // 企業コード設定無し
            else
            {
                // 有り得ないのでエラー
                return status;
            }

            // マスタテーブル読込み
            int iCnt = 0;
            status = Search(out iCnt, enterpriseCode, inqOtherSeCd);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ガイド初期起動時はカラム設定をおこなう
                        if (guideList.Tables.Count == 0)
                        {
                            DataTable table = new DataTable();
                            DataColumn column;

                            // 伝票印刷種別
                            column = new DataColumn();
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = GUIDE_SLIPPRTKINDID_TITLE;
                            table.Columns.Add(column);
                            // 伝票印刷種別名
                            column = new DataColumn();
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = GUIDE_SLIPPRTKIND_TITLE;
                            table.Columns.Add(column);
                            // 問合せ元企業コード
                            column = new DataColumn();
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = GUIDE_INQORIGINALEPCDRF_TITLE;
                            table.Columns.Add(column);
                            // 問合せ元企業名
                            column = new DataColumn();
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = GUIDE_INQORIGINALEPCDRFNAME_TITLE;
                            table.Columns.Add(column);
                            // 問合せ元拠点コード
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_INQORIGINALSECCD_TITLE;
                            table.Columns.Add(column);
                            // 問合せ元拠点名
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_INQORIGINALSECCDNAME_TITLE;
                            table.Columns.Add(column);
                            // 問合せ先企業コード
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_INQOTHEREPCDRF_TITLE;
                            table.Columns.Add(column);
                            // 問合せ先企業名
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_INQOTHEREPCDRFNAME_TITLE;
                            table.Columns.Add(column);
                            // 問合せ先拠点コード
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_INQOTHERSECCD_TITLE;
                            table.Columns.Add(column);
                            // 問合せ先拠点名
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_INQOTHERSECCDNAME_TITLE;
                            table.Columns.Add(column);
                            // 得意先コード
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_PPCCCOMPANYCODE_TITLE;
                            table.Columns.Add(column);
                            // 得意先名
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_PPCCCOMPANYCODENAME_TITLE;
                            table.Columns.Add(column);
                            // 伝票印刷設定用帳票ID
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_SLIPPRTSETPAPERID_TITLE;
                            table.Columns.Add(column);
                            // リモート伝発区分
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = GUIDE_RMTSLPPRTDIV_TITLE;
                            table.Columns.Add(column);

                            guideList.Tables.Add(table.Clone());
                        }

                        // ガイド用データセットの作成
                        GetGuideDataSet(ref guideList, mode);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    {
                        status = -1;
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// ガイド用データセット作成処理
        /// </summary>
        /// <param name="retDataSet">結果取得データセット</param>>
        /// <param name="mode">汎用ガイド表示切替(0:通常表示 5:全件表示)</param>>
        /// <remarks>
        /// <br>Note	   : ガイド用データセット処理を行なう</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private void GetGuideDataSet(ref DataSet retDataSet, int mode)
        {
            int dataCnt = 0;

            // 行を初期化して新しいデータを追加
            retDataSet.Tables[0].Rows.Clear();
            retDataSet.Tables[0].BeginLoadData();
            switch (mode)
            {
                // 通常表示
                case 0:
                // 全件表示
                case 5:
                    {
                        while (dataCnt < this._rmSlpPrtStTable.Rows.Count)
                        {
                            // 論理削除区分:有効
                            if ((string)this._rmSlpPrtStTable.DefaultView[dataCnt][COL_DELETEDATE_TITLE] == "")
                            {
                                DataRow dr = retDataSet.Tables[0].NewRow();
                                dr[GUIDE_SLIPPRTKINDID_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_SLIPPRTKINDID_TITLE];                // 伝票印刷種別
                                dr[GUIDE_SLIPPRTKIND_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_SLIPPRTKIND_TITLE];                    // 伝票印刷種別
                                dr[GUIDE_SLIPPRTSETPAPERID_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_SLIPPRTSETPAPERID_TITLE];        // 伝票印刷設定用帳票ID
                                dr[GUIDE_INQORIGINALEPCDRF_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_INQORIGINALEPCD_TITLE];          // 問合せ元企業コード
                                dr[GUIDE_INQORIGINALEPCDRFNAME_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_INQORIGINALEPCDNAME_TITLE];  // 問合せ元企業名
                                dr[GUIDE_INQORIGINALSECCD_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_INQORIGINALSECCD_TITLE];          // 問合せ元拠点コード
                                dr[GUIDE_INQORIGINALSECCDNAME_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_INQORIGINALSECCDNAME_TITLE];  // 問合せ元拠点名
                                dr[GUIDE_INQOTHEREPCDRF_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_INQOTHEREPCD_TITLE];                // 問合せ先企業コード
                                dr[GUIDE_INQOTHEREPCDRFNAME_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_INQOTHEREPCDNAME_TITLE];        // 問合せ先企業名
                                dr[GUIDE_INQOTHERSECCD_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_INQOTHERSECCD_TITLE];                // 問合せ先拠点コード
                                dr[GUIDE_INQOTHERSECCDNAME_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_INQOTHERSECCDNAME_TITLE];        // 問合せ先拠点名
                                dr[GUIDE_RMTSLPPRTDIV_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_RMTSLPPRTDIV_TITLE];                  // リモート伝発区分
                                dr[GUIDE_PPCCCOMPANYCODE_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_PCCCOMPANYCODE_TITLE];             // PCC自社コード
                                dr[GUIDE_PPCCCOMPANYCODENAME_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_PCCCOMPANYCODENAME_TITLE];     // PCC自社コード
                                dr[GUIDE_CREATEDATETIME_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_CREATEDATETIME_TITLE];              // 作成日時
                                dr[GUIDE_UPDATEDATETIME_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_UPDATEDATETIME_TITLE];              // 更新日時
                                dr[GUIDE_LOGICALDELETECODE_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_LOGICALDELETECODE_TITLE];        // 論理削除区分
                                // 2011.09.16 zhouzy UPDATE STA >>>>>>
                                dr[GUIDE_TOPMARGIN_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_TOPMARGIN_TITLE];              // 上余白
                                dr[GUIDE_LEFTMARGINE_TITLE] = this._rmSlpPrtStTable.DefaultView[dataCnt][COL_LEFTMARGINE_TITLE];        // 左余白
                                // 2011.09.16 zhouzy UPDATE END <<<<<<

                                retDataSet.Tables[0].Rows.Add(dr);
                            }
                            dataCnt++;
                        }
                        break;
                    }
            }
            retDataSet.Tables[0].EndLoadData();
        }

        #endregion

        // --------------------------------------------------
        #region 比較用クラス

        /// <summary>
        ///リモート伝発設定マスタ比較クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : リモート伝発設定マスタオブジェクトの比較を行います。</br>
        /// <br>Programmer : 欧方方</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public class RmSlpPrtStCompare : IComparer
        {
            #region IComparer メンバ

            /// <summary>
            /// 比較用メソッド
            /// </summary>
            /// <param name="x">比較対象オブジェクト</param>
            /// <param name="y">比較対象オブジェクト</param>
            /// <returns>比較結果(x ＞ y : 0より大きい整数, x ＜ y : 0より小さい整数, x ＝ y : 0)</returns>
            /// <remarks>
            /// <br>Note       : リモート伝発設定マスタオブジェクトの比較を行います。</br>
            /// <br>Programmer : 欧方方</br>
            /// <br>Date       : 2011.08.03</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                RmSlpPrtSt obj1 = x as RmSlpPrtSt;
                RmSlpPrtSt obj2 = y as RmSlpPrtSt;

                // 伝票印刷種別で比較
                return obj1.SlipPrtKind.CompareTo(obj2.SlipPrtKind);
            }

            #endregion
        }

        #endregion

    }
}
