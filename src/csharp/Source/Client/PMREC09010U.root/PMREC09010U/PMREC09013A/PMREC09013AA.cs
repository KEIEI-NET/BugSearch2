//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : レコメンド商品関連設定マスタ
// プログラム概要   : レコメンド商品関連設定マスタの保守を行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/01/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/02/10  修正内容 : ①BLコード入力時に商品コメント(提供)を表示
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/03/02  修正内容 : Redmine#296
//                                  全得意先を指定してサンプル取込した場合、得意先・元企業・元拠点にゼロをセット
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/03/03  修正内容 : Redmine#297
//                                  推奨先BLコードとパーツ説明に入力がない場合は新規行（登録不要行）と判定
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/03/06  修正内容 : Redmine#338 全得意先設定内容を定数化
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本利明
// 作 成 日  2015/03/09  修正内容 : Redmine#338 「全得意先」→「全得意先共通」
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Diagnostics;
using System.Threading;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// レコメンド商品関連設定マスタ アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : レコメンド商品関連設定マスタ アクセスクラス</br>
    /// <br>Programmer : 宮本利明</br>
    /// <br>Date       : 2015/01/20</br>
    /// </remarks>
    public class RecGoodsLkStAcs
    {
        #region Private Member
        private static RecGoodsLkStAcs _RecGoodsLkStAcs = null;

        private RecGoodsLkDataSet _dataSet;
        private RecGoodsLkDataSet.RecGoodsLkDataTable _recGoodsLkDataTable;
        private Dictionary<Guid, RecGoodsLkSt> _prevRecGoodsLkDic = new Dictionary<Guid, RecGoodsLkSt>();
        private IRecGoodsLkDB _iRecGoodsLkDB = null;

        // --- ADD 2015/02/06 T.Miyamoto サンプル取込機能追加 ------------------------------>>>>>
        private const int DELETEFLG_DEFAULT = 0;       // 通常
        private const int DELETEFLG_DELETE = 1;       // 削除
        private const int DELETEFLG_REVIVAL = 2;       // 復活
        private const int DELETEFLG_SAMPLE = 9;       // サンプル取込

        private IRecGoodsLkODB _IRecGoodsLkODB = null;

        private string _sampleSecCd = string.Empty;
        private string _sampleSecNm = string.Empty;
        public string SampleSecCd
        {
            get { return this._sampleSecCd; }
            set { this._sampleSecCd = value; }
        }
        public string SampleSecNm
        {
            get { return this._sampleSecNm; }
            set { this._sampleSecNm = value; }
        }

        private CustomerInfo _sampleCustomerInfo = null;
        public CustomerInfo SampleCustomerInfo
        {
            get { return this._sampleCustomerInfo; }
            set { this._sampleCustomerInfo = value; }
        }
        // --- ADD 2015/02/06 T.Miyamoto サンプル取込機能追加 ------------------------------<<<<<
        // --- ADD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------>>>>>
        public const string ALL_CUSTOMERCODE = "00000000";
        public const string ALL_CUSTOMERNAME = "全得意先共通"; // UPD 2015/03/09 T.Miyamoto Redmine#338 「全得意先」→「全得意先共通」
        public const string ALL_ORIGINALEPCD = "0000000000000000";
        public const string ALL_ORIGINALSECCD = "000000";
        // --- ADD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------<<<<<

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        /// <summary>処理結果状況</summary>
        private string _statusOfResult = string.Empty;

        private SecInfoAcs _secInfoAcs = null; // 拠点情報アクセスクラス

        /// <summary>DCKHN09092A)BLコード</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;
        /// <summary>SFCMN09062A)ユーザーガイド</summary>
        private UserGuideAcs _userGuideAcs;
        /// <summary>PMREC09013A)得意先</summary>
        private CustomerInfoAcs _customerInfoAcs;
        /// <summary> SCM企業連結データアクセスクラス </summary>
        private ScmEpScCntAcs _scmEpScCntAcs;

        //private IWin32Window _owner = null;

        private Dictionary<string, SecInfoSet> _secInfoSetDic = new Dictionary<string, SecInfoSet>(); // 拠点情報ディクショナリー
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdDic = new Dictionary<int, BLGoodsCdUMnt>();  // BLコードマスタディクショナリー
        private Dictionary<int, UserGdBd> _userGdBdDic = new Dictionary<int, UserGdBd>();             // ユーザーガイドディクショナリー
        private Dictionary<int, CustomerInfo> _customerDic = new Dictionary<int, CustomerInfo>();     // 得意先ディクショナリー
        private List<ScmEpScCnt> _scmEpScCntList = new List<ScmEpScCnt>();

        private List<RecGoodsLkSt> _recGoodsLkList = new List<RecGoodsLkSt>();

        // レコメンド商品関連設定データリスト
        //private List<RecGoodsLkSt> _RecGoodsLkStList = null;

        //true:削除指定区分=1、false:削除指定区分=0
        private bool _deleteSearchMode = false;

        /// <summary>// true:ローカル参照 false:サーバー参照</summary>
        public static readonly bool ctIsLocalDBRead = false;

        private RecGoodsLkSt _newRecGoodsLkObj = new RecGoodsLkSt(); // 新規行の場合用

        private Thread _masterAcsThread;   // マスタデータ取得スレッド

        #endregion

        #region プロパティ
        /// <summary>
        /// マスタデータ取得スレッドプロパティ
        /// </summary>
        public Thread MasterAcsThread
        {
            get { return this._masterAcsThread; }
        }

        /// <summary>
        /// グリッドテーブルプロパティ
        /// </summary>
        public RecGoodsLkDataSet.RecGoodsLkDataTable RecGoodsLkDataTable
        {
            get { return this._recGoodsLkDataTable; }
        }

        /// <summary>
        /// レコメンド商品関連設定ディクショナリープロパティ
        /// </summary>
        public Dictionary<Guid, RecGoodsLkSt> PrevRecGoodsLkDic
        {
            get { return this._prevRecGoodsLkDic; }
        }

        /// <summary>
        /// ＢＬコードマスタディクショナリープロパティ
        /// </summary>
        public Dictionary<int, BLGoodsCdUMnt> BLGoodsCdDic
        {
            get { return this._blGoodsCdDic; }
        }

        /// <summary>
        /// 販売区分ディクショナリープロパティ
        /// </summary>
        public Dictionary<int, UserGdBd> UserGdBdDic
        {
            get { return this._userGdBdDic; }
        }

        /// <summary>
        /// 削除指定区分プロパティ
        /// </summary>
        public bool DeleteSearchMode
        {
            get { return this._deleteSearchMode; }
        }

        /// <summary>
        /// 拠点情報マスタディクショナリープロパティ
        /// </summary>
        public Dictionary<string, SecInfoSet> SecInfoSetDic
        {
            get { return this._secInfoSetDic; }
        }

        /// <summary>
        /// 得意先マスタディクショナリープロパティ
        /// </summary>
        public Dictionary<int, CustomerInfo> CustomerDic
        {
            get { return this._customerDic; }
        }

        /// <summary>
        /// レコメンド商品関連設定ディクショナリープロパティ
        /// </summary>
        public List<RecGoodsLkSt> RecGoodsLkList
        {
            get { return this._recGoodsLkList; }
        }

        /// <summary>
        /// レコメンド商品関連設定プロパティ、新規行の場合用
        /// </summary>
        public RecGoodsLkSt NewRecGoodsLkObj
        {
            get { return _newRecGoodsLkObj; }
            set { _newRecGoodsLkObj = value; }
        }
        #endregion

        #region ●その他補助メソッド
        /// <summary>
        /// 比較関数
        /// </summary>
        /// <typeparam name="T">型指定</typeparam>
        /// <param name="condition">条件</param>
        /// <param name="valueOnTrue">Trueの時の値</param>
        /// <param name="valueOnFalse">Falseの時の値</param>
        /// <returns>条件により選択された値</returns>
        /// <remarks>
        /// <br>Note       : レコメンド商品関連設定マスタ アクセスクラス</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        static public T diverge<T>(bool condition, T valueOnTrue, T valueOnFalse)
        {
            if (condition)
            {
                return valueOnTrue;
            }
            else
            {
                return valueOnFalse;
            }
        }
        #endregion

        # region Constroctors
        /// <summary>
        /// 入力明細入力コントロールクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入力明細入力コントロールクラス デフォルトを行うコントロールクラスです。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public RecGoodsLkStAcs()
        {
            this._dataSet = new RecGoodsLkDataSet();
            this._recGoodsLkDataTable = this._dataSet.RecGoodsLk;
            this._secInfoAcs = new SecInfoAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._iRecGoodsLkDB = (IRecGoodsLkDB)MediationRecGoodsLkDB.GetRecGoodsLkDB();
            this._scmEpScCntAcs = new ScmEpScCntAcs();
            this._IRecGoodsLkODB = (IRecGoodsLkODB)MediationRecGoodsLkODB.GetRecGoodsLkODB(); // ADD 2015/02/06 T.Miyamoto サンプル取込機能追加
        }
        #endregion

        #region Public Method
        /// <summary>
        /// レコメンド商品関連設定アクセスクラス インスタンス取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : レコメンド商品関連設定アクセスクラス インスタンス取得処理</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public static RecGoodsLkStAcs GetInstance()
        {
            if (_RecGoodsLkStAcs == null)
            {
                _RecGoodsLkStAcs = new RecGoodsLkStAcs();
            }

            return _RecGoodsLkStAcs;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="searchCondition">検索条件クラス</param>
        /// <param name="count">count</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public int Search(SearchCondition searchCondition, out int count, out string msg)
        {
            int status = 0;
            count = 0;
            msg = string.Empty;

            ArrayList recGoodsLkList = null;
            RecGoodsLkWork recGoodsLkWork = this.CopyToSearchConditionWorkFromSearchCondition(searchCondition);

            try
            {
                if (searchCondition.DeleteFlag == 0)
                {
                    status = this.SearchPrc(out recGoodsLkList, recGoodsLkWork, ConstantManagement.LogicalMode.GetData0, out count, ref msg);
                }
                else
                {
                    status = this.SearchPrc(out recGoodsLkList, recGoodsLkWork, ConstantManagement.LogicalMode.GetData1, out count, ref msg);
                }
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (searchCondition.DeleteFlag == 0)
                {
                    this._deleteSearchMode = false;
                }
                else
                {
                    this._deleteSearchMode = true;
                }

                if (recGoodsLkList != null && recGoodsLkList.Count > 0)
                {
                    this.SettingDetailRowAfterSearch(recGoodsLkList);
                }
            }
            return status;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retArray">レコメンド商品関連設定マスタデータ</param>
        /// <param name="searchConditionWork">検索条件クラス</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <param name="count">count</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public int SearchPrc(out ArrayList retArray, RecGoodsLkWork recGoodsLkWork, ConstantManagement.LogicalMode logicalMode, out int count, ref string msg)
        {
            int status = 0;
            count = 0;
            try
            {
                ArrayList recGoodsLkList = null;
                object retObj = recGoodsLkList as object;

                object paraObj = recGoodsLkWork as object;
                status = this._iRecGoodsLkDB.SearchRcmd(out retObj, paraObj, 0, logicalMode, out count, ref msg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retArray = retObj as ArrayList;
                }
                else
                {
                    retArray = null;
                }
            }
            catch (Exception ex)
            {
                retArray = null;
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }


        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retArray">レコメンド商品関連設定マスタデータ</param>
        /// <param name="RecGoodsLkSt">検索条件クラス</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public int Read(out ArrayList retArray, RecGoodsLkSt RecGoodsLkSt, ref string msg)
        {
            int status = 0;
            try
            {
                ArrayList recGoodsLkList = null;
                object retObj = recGoodsLkList as object;

                //RecGoodsLkStWork RecGoodsLkStWork = this.CopyToRecGoodsLkWorkFromRecGoodsLk(RecGoodsLkSt);
                //object paraObj = RecGoodsLkStWork as object;
                //status = this._iRecGoodsLkStDB.Read(ref retObj, 0, ConstantManagement.LogicalMode.GetData0);
                //status = this._iRecGoodsLkDB.Read(out retObj, paraObj, ref msg);
                //status = this._iCampaignObjGoodsStDB.Read(out retObj, paraObj, ref msg);
                status = this._iRecGoodsLkDB.Read(ref retObj, 0, ConstantManagement.LogicalMode.GetData0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retArray = retObj as ArrayList;
                }
                else
                {
                    retArray = null;
                }
            }
            catch (Exception ex)
            {
                retArray = null;
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 明細データテーブルの初期設定を行います。
        /// </summary>
        /// <param name="defaultRowCount">初期行数</param>
        /// <remarks>
        /// <br>Note       : 明細データテーブルの初期設定を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void DetailRowInitialSetting(int defaultRowCount)
        {
            this.RecGoodsLkDataTable.BeginLoadData();
            this.RecGoodsLkDataTable.Clear();
            this._deleteSearchMode = false;

            for (int i = 1; i <= defaultRowCount; i++)
            {
                RecGoodsLkDataSet.RecGoodsLkRow row = this.RecGoodsLkDataTable.NewRecGoodsLkRow();
                row.RowNo = i;
                row.FilterGuid = Guid.Empty;
                //row.GoodsName = "";
                row.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                row.InqOtherEpCd = this._enterpriseCode;
                //row.InqOtherSecCd = this._loginSectionCode;
                this.RecGoodsLkDataTable.AddRecGoodsLkRow(row);
            }
            this.CopyToRecGoodsLkFromDetailRow((RecGoodsLkDataSet.RecGoodsLkRow)this._recGoodsLkDataTable.Rows[this._recGoodsLkDataTable.Count - 1], ref this._newRecGoodsLkObj);
            this.RecGoodsLkDataTable.EndLoadData();
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="deleteList">削除リスト</param>
        /// <param name="updateList">登録・更新リスト</param>
        /// <param name="RecGoodsLkSt">エラーオブジェクト</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public int SaveProc(List<RecGoodsLkSt> deleteList, List<RecGoodsLkSt> updateList, out RecGoodsLkSt RecGoodsLkSt)
        {
            int status = 0;
            RecGoodsLkSt = null;
            ArrayList delList = new ArrayList();
            ArrayList UpdList = new ArrayList();

            RecGoodsLkWork recGoodsLkWork = null;
            foreach (RecGoodsLkSt recGoodsLk in deleteList)
            {
                recGoodsLkWork = this.CopyToRecGoodsLkWorkFromRecGoodsLk(recGoodsLk);
                delList.Add(recGoodsLkWork);
            }
            foreach (RecGoodsLkSt recGoodsLk in updateList)
            {
                recGoodsLkWork = this.CopyToRecGoodsLkWorkFromRecGoodsLk(recGoodsLk);
                UpdList.Add(recGoodsLkWork);
            }

            object paraDelObj = delList as object;
            object paraUpdObj = UpdList as object;
            if (this._deleteSearchMode == false)
            {
//                status = this._iRecGoodsLkDB.WriteRcmd(ref paraUpdObj);

                object errorObj = null;
                status = this._iRecGoodsLkDB.DeleteAndWrite(paraDelObj, ref paraUpdObj, out errorObj);
                if (errorObj != null)
                {
                    RecGoodsLkWork errorWork = errorObj as RecGoodsLkWork;
                    RecGoodsLkSt = this.CopyToRecGoodsLkFromRecGoodsLkWork(errorWork);
                }
            }
            else
            {
                status = this._iRecGoodsLkDB.DeleteAndRevival(paraDelObj, ref paraUpdObj);
            }
            return status;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 検索処理後、明細行追加処理
        /// </summary>
        /// <param name="retList">0:登録・更新、1:完全削除と復活</param>
        /// <remarks>
        /// <br>Note       : 検索処理後、明細行追加処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void SettingDetailRowAfterSearch(ArrayList retList)
        {
            this.RecGoodsLkDataTable.BeginLoadData();
            this._recGoodsLkDataTable.Clear();
            RecGoodsLkSt RecGoodsLkSt = null;

            // 登録済行の追加
            for (int i = 1; i <= retList.Count; i++)
            {
                RecGoodsLkSt = this.CopyToRecGoodsLkFromRecGoodsLkWork((RecGoodsLkWork)retList[i - 1]);
                RecGoodsLkDataSet.RecGoodsLkRow row = this._recGoodsLkDataTable.NewRecGoodsLkRow();
                row.RowNo = i;
                this.CopyToDetailRowFromRecGoodsLk(ref row, RecGoodsLkSt);

                this._recGoodsLkDataTable.AddRecGoodsLkRow(row);
                this._prevRecGoodsLkDic.Add(row.FilterGuid, RecGoodsLkSt);
            }

            if (this._deleteSearchMode == false)
            {
                // 新規行の追加
                RecGoodsLkDataSet.RecGoodsLkRow newRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
                newRow.RowNo = retList.Count + 1;
                newRow.FilterGuid = Guid.Empty;
                newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                newRow.InqOtherEpCd = this._enterpriseCode;
                //newRow.InqOtherSecCd = this._loginSectionCode;
                this._recGoodsLkDataTable.AddRecGoodsLkRow(newRow);
            }

            this.RecGoodsLkDataTable.EndLoadData();
        }

        /// <summary>
        /// 明細行ー＞レコメンド設定マスタ
        /// </summary>
        /// <param name="row">明細行</param>
        /// <param name="recGoodsLk">レコメンド設定マスタ</param>
        /// <remarks>
        /// <br>Note       : 明細行ー＞レコメンド設定マスタ</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void CopyToDetailRowFromRecGoodsLk(ref RecGoodsLkDataSet.RecGoodsLkRow row, RecGoodsLkSt recGoodsLk)
        {
            row.UpdateTime = recGoodsLk.UpdateDateTime.Date.ToString("yy/MM/dd"); //更新日
            row.FilterGuid = Guid.NewGuid();

            row.InqOriginalEpCd = recGoodsLk.InqOriginalEpCd;
            row.InqOriginalSecCd = recGoodsLk.InqOriginalSecCd;
            row.InqOtherEpCd = recGoodsLk.InqOtherEpCd;
            row.InqOtherSecCd = recGoodsLk.InqOtherSecCd;

            //得意先
            row.CustomerCode = recGoodsLk.CustomerCode.ToString().PadLeft(8, '0');
            CustomerInfo customerInfo = null;
            if (this._customerDic.ContainsKey(recGoodsLk.CustomerCode))
            {
                customerInfo = this._customerDic[recGoodsLk.CustomerCode];
                row.CustomerSnm = customerInfo.CustomerSnm; //得意先略称
            }
            else if (recGoodsLk.CustomerCode == 0)
            {
                // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------>>>>>
                //row.CustomerSnm = "全得意先共通"; //拠点略称
                row.CustomerSnm = ALL_CUSTOMERNAME; //拠点略称
                // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------<<<<<
            }
            //拠点
            string inqOtherSecCd = recGoodsLk.InqOtherSecCd.Trim().PadLeft(2, '0');

            row.InqOtherSecCd = inqOtherSecCd;
            SecInfoSet secInfoSet = null;
            if (this._secInfoSetDic.ContainsKey(inqOtherSecCd))
            {
                secInfoSet = this._secInfoSetDic[inqOtherSecCd];
                row.InqOtherSecNm = secInfoSet.SectionGuideNm; //拠点略称
            }
            else if (inqOtherSecCd == "00")
            {
                row.InqOtherSecNm = "全社共通"; //拠点略称
            }
            BLGoodsCdUMnt blGoodsCdUMnt = null;
            //推奨元BLコード
            row.RecSourceBLGoodsCd = recGoodsLk.RecSourceBLGoodsCd;
            if (this.BLGoodsCdDic.ContainsKey(recGoodsLk.RecSourceBLGoodsCd))
            {
                blGoodsCdUMnt = BLGoodsCdDic[recGoodsLk.RecSourceBLGoodsCd];
                row.RecSourceBLGoodsNm = blGoodsCdUMnt.BLGoodsHalfName;
            }
            //推奨先BLコード
            row.RecDestBLGoodsCd = recGoodsLk.RecDestBLGoodsCd;
            if (BLGoodsCdDic.ContainsKey(recGoodsLk.RecDestBLGoodsCd))
            {
                blGoodsCdUMnt = BLGoodsCdDic[recGoodsLk.RecDestBLGoodsCd];
                row.RecDestBLGoodsNm = blGoodsCdUMnt.BLGoodsHalfName;
            }
            // --- ADD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------>>>>>
            // 商品コメント
            row.GoodsComment = recGoodsLk.GoodsComment;
            // --- ADD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------<<<<<
        }

        /// <summary>
        /// レコメンド商品関連設定マスター＞明細行
        /// </summary>
        /// <param name="row">明細行</param>
        /// <param name="recGoodsLk">レコメンド商品関連設定マスタ</param>
        /// <remarks>
        /// <br>Note       : レコメンド商品関連設定マスター＞明細行</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/22</br>
        /// </remarks>
        public void CopyToRecGoodsLkFromDetailRow(RecGoodsLkDataSet.RecGoodsLkRow row, ref RecGoodsLkSt recGoodsLk)
        {
            if (recGoodsLk == null)
            {
                recGoodsLk = new RecGoodsLkSt();
            }

            Int32 customerCode = 0;
            Int32.TryParse(row.CustomerCode, out customerCode);
            recGoodsLk.CustomerCode = customerCode;

            recGoodsLk.InqOriginalEpCd = row.InqOriginalEpCd;
            recGoodsLk.InqOriginalSecCd = row.InqOriginalSecCd;
            recGoodsLk.InqOtherEpCd = row.InqOtherEpCd;
            recGoodsLk.InqOtherSecCd = row.InqOtherSecCd;
            recGoodsLk.RecSourceBLGoodsCd = row.RecSourceBLGoodsCd;
            recGoodsLk.RecDestBLGoodsCd = row.RecDestBLGoodsCd;
            recGoodsLk.RecDestBLGoodsNm = row.RecDestBLGoodsNm;
            // --- ADD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------>>>>>
            recGoodsLk.GoodsComment = string.Empty; ;
            if (!row.IsGoodsCommentNull())
            {
                recGoodsLk.GoodsComment = row.GoodsComment;
            }
            // --- ADD 2015/02/06 T.Miyamoto コメント項目追加 ------------------------------<<<<<

            recGoodsLk.RowIndex = row.RowNo;
        }

        /// <summary>
        /// レコメンド商品関連設定マスタ比較処理
        /// </summary>
        /// <param name="recGoodsLk1">レコメンド商品関連設定マスタ</param>
        /// <param name="recGoodsLk2">レコメンド商品関連設定マスタ</param>
        /// <returns>true:不同、false:同じ</returns>
        /// <remarks>
        /// <br>Note       : レコメンド商品関連設定マスタ比較処理</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool Compare(RecGoodsLkSt recGoodsLk1, RecGoodsLkSt recGoodsLk2)
        {
            if (recGoodsLk1.CustomerCode != recGoodsLk2.CustomerCode
             || recGoodsLk1.RecSourceBLGoodsCd != recGoodsLk2.RecSourceBLGoodsCd
             || recGoodsLk1.RecDestBLGoodsCd != recGoodsLk2.RecDestBLGoodsCd
             || recGoodsLk1.GoodsComment != recGoodsLk2.GoodsComment) // ADD 2015/02/06 T.Miyamoto コメント項目追加
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// レコメンド商品関連設定マスタ比較処理
        /// </summary>
        /// <param name="recGoodsLk1">レコメンド商品関連設定マスタ</param>
        /// <param name="recGoodsLk2">レコメンド商品関連設定マスタ</param>
        /// <returns>true:不同、false:同じ</returns>
        /// <remarks>
        /// <br>Note       : レコメンド商品関連設定マスタ比較処理</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CompareKey(RecGoodsLkSt recGoodsLk1, RecGoodsLkSt recGoodsLk2)
        {
            if (recGoodsLk1.InqOriginalEpCd != recGoodsLk2.InqOriginalEpCd
             || recGoodsLk1.InqOriginalSecCd != recGoodsLk2.InqOriginalSecCd
             || recGoodsLk1.InqOtherEpCd != recGoodsLk2.InqOtherEpCd
             || recGoodsLk1.InqOtherSecCd != recGoodsLk2.InqOtherSecCd
             || recGoodsLk1.RecSourceBLGoodsCd != recGoodsLk2.RecSourceBLGoodsCd
             || recGoodsLk1.RecDestBLGoodsCd != recGoodsLk2.RecDestBLGoodsCd
             || recGoodsLk1.GoodsComment != recGoodsLk2.GoodsComment) // ADD 2015/02/06 T.Miyamoto コメント項目追加
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 抽出条件比較処理
        /// </summary>
        /// <param name="searchCondition1">抽出条件1</param>
        /// <param name="searchCondition2">抽出条件2</param>
        /// <returns>true:同、false:不同</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件比較処理</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CompareSearchCondition(SearchCondition searchCondition1, SearchCondition searchCondition2)
        {
            //検索条件が変更なしの場合は検索しない
            if (searchCondition1.InqOtherSecCd == searchCondition2.InqOtherSecCd
             && searchCondition1.CustomerCode == searchCondition2.CustomerCode
             && searchCondition1.RecSourceBLGoodsCdSt == searchCondition2.RecSourceBLGoodsCdSt
             && searchCondition1.RecSourceBLGoodsCdEd == searchCondition2.RecSourceBLGoodsCdEd
             && searchCondition1.DeleteFlag == searchCondition2.DeleteFlag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 新規行の判断処理
        /// </summary>
        /// <param name="row">新規行</param>
        /// <returns>true:不同、false:同じ</returns>
        /// <remarks>
        /// <br>Note       : 新規行の判断処理</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool IsRowUpdate(RecGoodsLkDataSet.RecGoodsLkRow row)
        {
            // --- UPD 2015/03/03 T.Miyamoto Redmine#297 ------------------------------>>>>>
            //if (row.CustomerCode.Trim().PadLeft(8, '0') != this._newRecGoodsLkObj.CustomerCode.ToString().PadLeft(8, '0')
            // || row.RecSourceBLGoodsCd != this._newRecGoodsLkObj.RecSourceBLGoodsCd
            // || row.RecDestBLGoodsCd != this._newRecGoodsLkObj.RecDestBLGoodsCd)
            // 推奨先BLコードとパーツ説明に入力がない場合は新規行（登録不要行）と判定
            if ((row.RecDestBLGoodsCd != this._newRecGoodsLkObj.RecDestBLGoodsCd)
             || (row.GoodsComment != this._newRecGoodsLkObj.GoodsComment))
            // --- UPD 2015/03/03 T.Miyamoto Redmine#297 ------------------------------<<<<<
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// マスタデータ取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : マスタデータ取得処理</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void LoadMstData()
        {
            this._masterAcsThread = new Thread(new ThreadStart(MasterThreadProc)); // マスタデータ取得スレッド
            this._masterAcsThread.Start();
        }

        /// <summary>
        /// マスタデータ取得スレッド
        /// </summary>
        /// <remarks>
        /// <br>Note       : マスタデータ取得スレッド</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public void MasterThreadProc()
        {
            this.LoadBlCodeMst();//BLマスタの読み込み

            this.ReadSecInfoSet();//拠点マスタの読み込み

            this.GetCustomerDic();//得意先マスタの読み込み

            this.SearchCnectOriginalEpFromSc(); //SCM企業連結データ読込処理
        }

        /// <summary>
        /// BlCodeマスタデータ取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : BlCodeマスタデータ取得処理</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void LoadBlCodeMst()
        {
            this._blGoodsCdDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                int status = _blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);

                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode != 0)
                        {
                            continue;
                        }

                        this._blGoodsCdDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                    }
                }
            }
            catch
            {

                this._blGoodsCdDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報マスタ読込処理</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim().PadLeft(2, '0'), secInfoSet);
                }
            }
        }

        /// <summary>
        /// 得意先マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタ読込処理</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private void GetCustomerDic()
        {
            this._customerDic = new Dictionary<int, CustomerInfo>();

            try
            {
                List<CustomerInfo> customerInfoList;

                int status = this._customerInfoAcs.Search(this._enterpriseCode, false, false, out customerInfoList);

                if (status == 0)
                {
                    foreach (CustomerInfo customerInfo in customerInfoList)
                    {
                        if (customerInfo.LogicalDeleteCode != 0)
                        {
                            continue;
                        }

                        this._customerDic.Add(customerInfo.CustomerCode, customerInfo);
                    }
                }
            }
            catch
            {
                this._customerDic = new Dictionary<int, CustomerInfo>();
            }
        }

        /// <summary>
        /// 得意先チェック処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="chkFlg">必須チェック区分(ture:有,false:無)</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアプデト後発生イベント</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CheckCustomer(int customerCode, bool chkFlg, out string errMsg, out CustomerInfo retCustomerInfo)
        {
            retCustomerInfo = null;

            bool bRet = true;
            errMsg = string.Empty;

            if (customerCode == 0)
            {
            
                // --- ADD 2015/02/20 T.Nishi ------------------------------>>>>>
                //全社設定対応の為削除
                //if (chkFlg)
                //{
                //    bRet = false;
                //    errMsg = "得意先コードを入力して下さい。";
                //}
                // --- ADD 2015/02/20 T.Nishi ------------------------------<<<<<
            }
            else
            {
                if (this._customerDic.ContainsKey(customerCode))
                {
                    retCustomerInfo = this._customerDic[customerCode];
                }
                if (retCustomerInfo == null)
                {
                    bRet = false;
                    errMsg = "得意先が存在しません。";
                }
                else
                {
                    bRet = false;
                    errMsg = "連携している得意先ではありません。";
                    if (retCustomerInfo.OnlineKindDiv != 0       //オンライン種別区分
                     && retCustomerInfo.CustomerEpCode != null   //得意先企業コード
                     && retCustomerInfo.CustomerSecCode != null) //得意先拠点コード
                    {
                        // SCM企業連結データ該当チェック
                        bRet = false;
                        errMsg = "連携している得意先ではありません。";
                        foreach (ScmEpScCnt wk in this._scmEpScCntList)
                        {
                            if (!wk.LogicalDeleteCode.Equals(0)) continue;                              // 論理削除：有効以外
                            if (wk.DiscDivCd.Equals(1)) continue;                                       // 連結無効
                            if (wk.ScmCommMethod.Equals(0) && wk.PccUoeCommMethod.Equals(0)) continue;  // 通信方式が無効

                            // オンライン種別区分、得意先企業コード、得意先拠点コードの判定
                            if (retCustomerInfo.OnlineKindDiv == 10  // 10:SCM
                               && retCustomerInfo.CustomerEpCode.Trim().Equals(wk.CnectOriginalEpCd.Trim())
                               && retCustomerInfo.CustomerSecCode.Trim().Equals(wk.CnectOriginalSecCd.Trim())
                                 )
                            {
                                bRet = true;
                                break;
                            }
                        }
                    }
                }
            }
            return bRet;
        }
        /// <summary>
        /// 拠点チェック処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="chkFlg">必須チェック区分(ture:有,false:無)</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアプデト後発生イベント</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CheckSection(string sectionCode, bool chkFlg, out string errMsg, out SecInfoSet retSecInfoSet)
        {
            retSecInfoSet = null;

            bool bRet = true;
            errMsg = string.Empty;

            // --- UPD 2015/02/12 T.Miyamoto ------------------------------>>>>>
            //if (int.Parse(sectionCode.Trim()) == 0)
            Int32 chkSectionCode = 0;
            Int32.TryParse(sectionCode, out chkSectionCode);
            if (chkSectionCode == 0)
            // --- UPD 2015/02/12 T.Miyamoto ------------------------------<<<<<
            {
                if (chkFlg)
                {
                    bRet = false;
                    errMsg = "拠点コードを入力して下さい。";
                }
            }
            else
            {
                if (this._secInfoSetDic.ContainsKey(sectionCode.Trim().PadLeft(2, '0')))
                {
                    retSecInfoSet = this._secInfoSetDic[sectionCode.Trim().PadLeft(2, '0')];
                }
                if (retSecInfoSet == null)
                {
                    bRet = false;
                    errMsg = "拠点が存在しません。";
                }
            }
            return bRet;
        }

        /// <summary>
        /// SearchCondition->SearchConditionWork
        /// </summary>
        /// <param name="searchCondition">検索条件</param>
        /// <returns>検索条件</returns>
        /// <remarks>
        /// <br>Note       : SearchCondition->SearchConditionWork</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private RecGoodsLkWork CopyToSearchConditionWorkFromSearchCondition(SearchCondition searchCondition)
        {
            RecGoodsLkWork recGoodsLkWork = new RecGoodsLkWork();

            recGoodsLkWork.InqOtherEpCd   = searchCondition.InqOtherEpCd;   //問合せ先企業コード
            recGoodsLkWork.InqOtherSecCd  = searchCondition.InqOtherSecCd;  //問合せ先拠点コード
            recGoodsLkWork.CustomerCode      = searchCondition.CustomerCode;      //得意先コード
            recGoodsLkWork.RecSourceBLGoodsCdSt = searchCondition.RecSourceBLGoodsCdSt; //推奨元BLコード（開始）
            recGoodsLkWork.RecSourceBLGoodsCdEd = searchCondition.RecSourceBLGoodsCdEd; //推奨元BLコード（終了）
            recGoodsLkWork.LogicalDeleteCode  = searchCondition.DeleteFlag;        //削除指定区分
            // --- ADD 2015/02/16 Y.Wakita RedMine#218 ------------------------------>>>>>
            recGoodsLkWork.InqOriginalEpCd  = searchCondition.InqOriginalEpCd;  //問合せ元企業コード
            recGoodsLkWork.InqOriginalSecCd = searchCondition.InqOriginalSecCd; //問合せ元拠点コード
            // --- ADD 2015/02/16 Y.Wakita RedMine#218 ------------------------------<<<<<

            return recGoodsLkWork;
        }

        /// <summary>
        /// RecGoodsLkWork->RecGoodsLk
        /// </summary>
        /// <param name="recGoodsLkWork">レコメンド商品関連設定ワーク</param>
        /// <returns>レコメンド商品関連設定</returns>
        /// <remarks>
        /// <br>Note       : RecGoodsLkWork->RecGoodsLk</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private RecGoodsLkSt CopyToRecGoodsLkFromRecGoodsLkWork(RecGoodsLkWork recGoodsLkWork)
        {
            RecGoodsLkSt RecGoodsLkSt = new RecGoodsLkSt();

            RecGoodsLkSt.CreateDateTime      = recGoodsLkWork.CreateDateTime;
            RecGoodsLkSt.UpdateDateTime      = recGoodsLkWork.UpdateDateTime;
            RecGoodsLkSt.LogicalDeleteCode   = recGoodsLkWork.LogicalDeleteCode;
            RecGoodsLkSt.InqOriginalEpCd     = recGoodsLkWork.InqOriginalEpCd;
            RecGoodsLkSt.InqOriginalSecCd    = recGoodsLkWork.InqOriginalSecCd;
            RecGoodsLkSt.InqOtherEpCd        = recGoodsLkWork.InqOtherEpCd;
            RecGoodsLkSt.InqOtherSecCd       = recGoodsLkWork.InqOtherSecCd;
            RecGoodsLkSt.CustomerCode        = recGoodsLkWork.CustomerCode;
            RecGoodsLkSt.RecSourceBLGoodsCd  = recGoodsLkWork.RecSourceBLGoodsCd;
            RecGoodsLkSt.RecDestBLGoodsCd    = recGoodsLkWork.RecDestBLGoodsCd;
            RecGoodsLkSt.RecDestBLGoodsNm    = recGoodsLkWork.RecDestBLGoodsNm;
            RecGoodsLkSt.GoodsComment        = recGoodsLkWork.GoodsComment; // ADD 2015/02/06 T.Miyamoto コメント項目追加

            return RecGoodsLkSt;
        }

        /// <summary>
        /// RecGoodsLk->RecGoodsLkWork
        /// </summary>
        /// <param name="RecGoodsLkSt">レコメンド商品関連設定</param>
        /// <returns>レコメンド商品関連設定ワーク</returns>
        /// <remarks>
        /// <br>Note       : RecGoodsLk->RecGoodsLkWork</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        private RecGoodsLkWork CopyToRecGoodsLkWorkFromRecGoodsLk(RecGoodsLkSt RecGoodsLkSt)
        {
            RecGoodsLkWork recGoodsLkWork = new RecGoodsLkWork();

            recGoodsLkWork.CreateDateTime      = RecGoodsLkSt.CreateDateTime;
            recGoodsLkWork.UpdateDateTime      = RecGoodsLkSt.UpdateDateTime;
            recGoodsLkWork.LogicalDeleteCode   = RecGoodsLkSt.LogicalDeleteCode;
            recGoodsLkWork.InqOriginalEpCd     = RecGoodsLkSt.InqOriginalEpCd;
            recGoodsLkWork.InqOriginalSecCd    = RecGoodsLkSt.InqOriginalSecCd;
            recGoodsLkWork.InqOtherEpCd        = RecGoodsLkSt.InqOtherEpCd;
            recGoodsLkWork.InqOtherSecCd       = RecGoodsLkSt.InqOtherSecCd;
            recGoodsLkWork.CustomerCode        = RecGoodsLkSt.CustomerCode;
            recGoodsLkWork.RecSourceBLGoodsCd  = RecGoodsLkSt.RecSourceBLGoodsCd;
            recGoodsLkWork.RecDestBLGoodsCd    = RecGoodsLkSt.RecDestBLGoodsCd;
            recGoodsLkWork.RecDestBLGoodsNm    = RecGoodsLkSt.RecDestBLGoodsNm;
            recGoodsLkWork.GoodsComment        = RecGoodsLkSt.GoodsComment; // ADD 2015/02/06 T.Miyamoto コメント項目追加

            return recGoodsLkWork;
        }

        /// <summary>
        /// SCM企業連結データ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : SCM企業連結データ読込処理</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/02/04</br>
        /// </remarks>
        private void SearchCnectOriginalEpFromSc()
        {
            try
            {
                bool msgDiv;
                string errMsg;

                int status = this._scmEpScCntAcs.SearchCnectOriginalEpFromSc(this._enterpriseCode, ConstantManagement.LogicalMode.GetData01, out this._scmEpScCntList, out msgDiv, out errMsg);
            }
            catch
            {
            }
        }
        #endregion

        // --- ADD 2015/02/06 T.Miyamoto サンプル取込機能追加 ------------------------------>>>>>
        /// <summary>
        /// サンプル取込チェック処理
        /// </summary>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : サンプル取込チェック処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        public int SampleCheck(out string msg)
        {
            msg = string.Empty;
            int status = 0;
            int count = 0;
            try
            {
                ArrayList recGoodsLkList = null;
                object retObj = recGoodsLkList as object;

                RecGoodsLkWork recGoodsLkWork    = new RecGoodsLkWork();
                recGoodsLkWork.InqOtherEpCd      = this._enterpriseCode;                     //問合せ先企業コード
                recGoodsLkWork.InqOtherSecCd     = this._sampleSecCd;                        //問合せ先拠点コード
                recGoodsLkWork.CustomerCode      = this._sampleCustomerInfo.CustomerCode;    //得意先コード
                recGoodsLkWork.InqOriginalEpCd   = this._sampleCustomerInfo.CustomerEpCode;  //問合せ元企業コード
                recGoodsLkWork.InqOriginalSecCd  = this._sampleCustomerInfo.CustomerSecCode; //問合せ元拠点コード
                recGoodsLkWork.LogicalDeleteCode = 0;                                        //削除指定区分
                object paraObj = recGoodsLkWork as object;

                status = this._iRecGoodsLkDB.SearchRcmd(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0, out count, ref msg);
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        // --- ADD 2015/02/10① T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// 商品コメント検索処理
        /// </summary>
        /// <param name="recSourceBLCode">推奨元BLコード</param>
        /// <param name="recDestBLCode">推奨先BLコード</param>
        /// <returns>string</returns>
        /// <remarks>
        /// <br>Note       : 指定したBLコードから商品コメントの検索を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/02/10</br>
        /// </remarks>
        public string SampleRead(int recSourceBLCode, int recDestBLCode)
        {
            string goodsComment = string.Empty;

            ArrayList retArrayList = new ArrayList();
            RecGoodsLkOWork pararecGoodsLkOWork = new RecGoodsLkOWork();
            pararecGoodsLkOWork.RecSourceBLGoodsCd = recSourceBLCode;
            pararecGoodsLkOWork.RecDestBLGoodsCd = recDestBLCode;

            string msg = string.Empty;
            retArrayList.Add(pararecGoodsLkOWork);
            int status = this.SampleReadProc(ref retArrayList, ref msg);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                RecGoodsLkOWork recGoodsLkOWork = (RecGoodsLkOWork)retArrayList[0];
                goodsComment = recGoodsLkOWork.GoodsComment.Trim();
            }
            return goodsComment;
        }

        /// <summary>
        /// 商品コメント検索処理
        /// </summary>
        /// <param name="recGoodsLkOWork">検索条件</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 商品コメント検索処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/02/10</br>
        /// </remarks>
        public int SampleReadProc(ref ArrayList retArray, ref string msg)
        {
            int status = 0;
            try
            {
                object retObj = null;
                retObj = retArray[0] as Object;
                ArrayList retArrayList = new ArrayList();
                status = this._IRecGoodsLkODB.Read(ref retObj, 0, ConstantManagement.LogicalMode.GetData0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retArrayList.Add(retObj as RecGoodsLkOWork);
                    retArray = retArrayList;
                }
                else
                {
                    retArray = null;
                }
            }
            catch (Exception ex)
            {
                retArray = null;
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        // --- ADD 2015/02/10① T.Miyamoto ------------------------------<<<<<

        /// <summary>
        /// サンプルデータ検索処理
        /// </summary>
        /// <param name="searchCondition">検索条件クラス</param>
        /// <param name="count">count</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : サンプルデータ検索処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public int SampleSearch(out string msg)
        {
            int status = 0;
            msg = string.Empty;

            ArrayList recGoodsLkOWorkList = null;
            try
            {
                status = this.SampleSearchPrc(out recGoodsLkOWorkList, ref msg);
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (recGoodsLkOWorkList != null && recGoodsLkOWorkList.Count > 0)
                {
                    this.SettingDetailRowAfterSampleSearch(recGoodsLkOWorkList);
                }
            }
            return status;
        }

        /// <summary>
        /// サンプルデータ検索処理
        /// </summary>
        /// <param name="retArray">商品コメントデータ</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : サンプルデータ検索処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        public int SampleSearchPrc(out ArrayList retArray, ref string msg)
        {
            int status = 0;
            try
            {
                object retObj = null;
                RecGoodsLkOWork recGoodsLkOWork = new RecGoodsLkOWork();
                status = this._IRecGoodsLkODB.Search(out retObj, recGoodsLkOWork, 0, ConstantManagement.LogicalMode.GetData0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retArray = retObj as ArrayList;
                }
                else
                {
                    retArray = null;
                }
            }
            catch (Exception ex)
            {
                retArray = null;
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        /// <summary>
        /// 商品コメント検索処理後、明細行追加処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品コメント検索処理後、明細行追加処理を行います。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        private void SettingDetailRowAfterSampleSearch(ArrayList retList)
        {
            this.RecGoodsLkDataTable.BeginLoadData();
            RecGoodsLkSt RecGoodsLkSt = null;

            this._recGoodsLkDataTable.Rows[this._recGoodsLkDataTable.Count - 1].Delete(); //既存の新規行を削除
            int startRowNo = this._recGoodsLkDataTable.Count;
            // サンプルデータを展開
            for (int iCnt = 1; iCnt <= retList.Count; iCnt++)
            {
                // 新規行の追加
                RecGoodsLkDataSet.RecGoodsLkRow setRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
                setRow.RowNo = startRowNo + iCnt;
                setRow.FilterGuid = Guid.Empty;
                setRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                setRow.InqOtherEpCd = this._enterpriseCode;                         //問合せ先企業コード

                // 取込画面で入力した拠点・得意先をセット
                setRow.InqOtherSecCd = this._sampleSecCd;                           //問合せ先拠点コード
                setRow.InqOtherSecNm = this._sampleSecNm;                           //問合せ先拠点名
                // --- UPD 2015/03/02 T.Miyamoto Redmine#296 ------------------------------>>>>>
                //setRow.CustomerCode = this._sampleCustomerInfo.CustomerCode.ToString().PadLeft(8, '0'); //得意先コード
                //setRow.CustomerSnm = this._sampleCustomerInfo.CustomerSnm;          //得意先略称
                //setRow.InqOriginalEpCd = this._sampleCustomerInfo.CustomerEpCode;   //問合せ元企業コード←得意先企業コード
                //setRow.InqOriginalSecCd = this._sampleCustomerInfo.CustomerSecCode; //問合せ元拠点コード←得意先拠点コード
                if ((this._sampleCustomerInfo == null) || (this._sampleCustomerInfo.CustomerCode == 0))
                {
                    // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------>>>>>
                    //setRow.CustomerCode = "00000000";
                    //setRow.CustomerSnm = "全得意先";
                    //setRow.InqOriginalEpCd = "0000000000000000";
                    //setRow.InqOriginalSecCd = "000000";
                    setRow.CustomerCode = ALL_CUSTOMERCODE;
                    setRow.CustomerSnm = ALL_CUSTOMERNAME;
                    setRow.InqOriginalEpCd = ALL_ORIGINALEPCD;
                    setRow.InqOriginalSecCd = ALL_ORIGINALSECCD;
                    // --- UPD 2015/03/06 T.Miyamoto Redmine#338 ------------------------------<<<<<
                }
                else
                {
                    setRow.CustomerCode = this._sampleCustomerInfo.CustomerCode.ToString().PadLeft(8, '0'); //得意先コード
                    setRow.CustomerSnm = this._sampleCustomerInfo.CustomerSnm;          //得意先略称
                    setRow.InqOriginalEpCd = this._sampleCustomerInfo.CustomerEpCode;   //問合せ元企業コード←得意先企業コード
                    setRow.InqOriginalSecCd = this._sampleCustomerInfo.CustomerSecCode; //問合せ元拠点コード←得意先拠点コード
                }
                // --- UPD 2015/03/02 T.Miyamoto Redmine#296 ------------------------------<<<<<

                // サンプルデータをセット
                RecGoodsLkOWork recGoodsLkOWork = (RecGoodsLkOWork)retList[iCnt - 1];
                //推奨元BL商品コード
                setRow.RecSourceBLGoodsCd = recGoodsLkOWork.RecSourceBLGoodsCd;     
                setRow.RecSourceBLGoodsNm = GetBLGoodsNm(recGoodsLkOWork.RecSourceBLGoodsCd);
                //推奨先BL商品コード
                setRow.RecDestBLGoodsCd = recGoodsLkOWork.RecDestBLGoodsCd;
                setRow.RecDestBLGoodsNm = GetBLGoodsNm(recGoodsLkOWork.RecDestBLGoodsCd);
                //商品コメント
                setRow.GoodsComment = recGoodsLkOWork.GoodsComment;

                // 行削除フラグ
                setRow.RowDeleteFlg = DELETEFLG_SAMPLE; //サンプル取込のフラグをセット

                this._recGoodsLkDataTable.AddRecGoodsLkRow(setRow);
            }
            // 新規行の追加
            RecGoodsLkDataSet.RecGoodsLkRow newRow = this._recGoodsLkDataTable.NewRecGoodsLkRow();
            newRow.RowNo = this._recGoodsLkDataTable.Count + 1;
            newRow.FilterGuid = Guid.Empty;
            newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
            newRow.InqOtherEpCd = this._enterpriseCode;
            newRow.RowDeleteFlg = DELETEFLG_SAMPLE; //サンプル取込のフラグをセット
            this._recGoodsLkDataTable.AddRecGoodsLkRow(newRow);

            this.RecGoodsLkDataTable.EndLoadData();
        }

        /// <summary>
        /// BLコード名称取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLコード名称を取得します。</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/02/06</br>
        /// </remarks>
        private string GetBLGoodsNm(int BLGoodsCd)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = new BLGoodsCdUMnt();
            if (this.BLGoodsCdDic.ContainsKey(BLGoodsCd))
            {
                blGoodsCdUMnt = BLGoodsCdDic[BLGoodsCd];
            }
            return blGoodsCdUMnt.BLGoodsHalfName;
        }
        // --- ADD 2015/02/06 T.Miyamoto サンプル取込機能追加 ------------------------------<<<<<
    }
}
