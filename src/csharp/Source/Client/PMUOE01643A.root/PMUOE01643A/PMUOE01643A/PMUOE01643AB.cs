//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 回答データ取込処理
// プログラム概要   : UOE発注データと発注回答データのつけ合わせを行い、
//                    売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10702591-00 作成担当 : 曹文傑
// 作 成 日  2011/05/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Data;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 発注回答データの構築クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注回答データの構築クラスを行います。</br>
    /// <br>Programmer : 曹文傑</br>
    /// <br>Date       : 2011/05/18</br>
    /// </remarks>
    public abstract class UOEOrderDtlInfoBuilder
    {
        # region -- プライベート変数 --
        /*----------------------------------------------------------------------------------*/
        private UOEOrderDtlAcs _uOEOrderDtlAcs;
        private UoeSndRcvCtlAcs _uoeSndRcvCtlAcs;
        private UOESupplierAcs _uOESupplierAcs;

        private List<UOEOrderDtlWork> _uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
        private List<StockDetailWork> _stockDetailWorkList = new List<StockDetailWork>();

        /// <summary>
        /// 発注先コード
        /// </summary>
        public  int UOESupplierCd = 0;
        private const string MAZDACOMMASSEMBLY_ID_0403 = "0403";
        #endregion

        # region -- コンストラクタ --
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オフライン対応</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected UOEOrderDtlInfoBuilder()
        {
            this._uOEOrderDtlAcs = new UOEOrderDtlAcs();
            this._uoeSndRcvCtlAcs = new UoeSndRcvCtlAcs();
            this._uOESupplierAcs = new UOESupplierAcs();

            // DB更新が完了したら進捗表示用フォームを閉じます。
            this._uoeSndRcvCtlAcs.UpdateProgress += new UoeSndRcvCtlAcs.OnUpdateProgress(this.CloseProgressForm);

            // データセット列情報構築処理
            this.DataTableColumnConstruction();
        }
        #endregion

        # region -- 検索処理 --
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="answerDateMazdaPara">画面情報</param>
        /// <param name="errMessage">メッセージ</param>
        /// <returns>チェック結果。　0：正常；　-1：異常</returns>
        /// <remarks>
        /// <br>Note       : MLG情報を取得処理する。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public int DoSearch(AnswerDateMazdaPara answerDateMazdaPara, out string errMessage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMessage = string.Empty;

            List<UOEOrderDtlInfo> filesDataDtlList;
            this._stockDetailWorkList.Clear();
            this._uOEOrderDtlWorkList.Clear();
            UOESupplierCd = answerDateMazdaPara.UOESupplierCd;

            // ファイル情報取得処理
            status = this.GetFilesData(out filesDataDtlList, answerDateMazdaPara.AnswerSaveFolder, ref errMessage);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            // Filesのデータがない場合
            if (filesDataDtlList == null || filesDataDtlList.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            Dictionary<string, object> uoeRemarkDic = new Dictionary<string, object>();
            Dictionary<int, ArrayList> systemDivDic = new Dictionary<int, ArrayList>();

            foreach (UOEOrderDtlInfo info in filesDataDtlList)
            {
                // 発注回答データのリマーク2
                string uoeRemark = info.UoeRemark2.Trim();

                if (!uoeRemarkDic.ContainsKey(uoeRemark))
                { 
                    List<UOEOrderDtlInfo> tempList;
                    uoeRemarkDic.Add(uoeRemark, null);
                    tempList = filesDataDtlList.FindAll(
                                delegate(UOEOrderDtlInfo info2)
                                {
                                    if (info2.UoeRemark2.Trim() == uoeRemark)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                    );

                    // システム区分
                    int systemDivCd = Int32.Parse(uoeRemark.Substring(3, 1));

                    List<UOEOrderDtlWork> uOEOrderDtlWorkList = new List<UOEOrderDtlWork>(); // UOE発注データ
                    List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>(); // 仕入明細データ

                    if (systemDivDic.ContainsKey(systemDivCd))
                    {
                        uOEOrderDtlWorkList = systemDivDic[systemDivCd][0] as List<UOEOrderDtlWork>;
                        stockDetailWorkList = systemDivDic[systemDivCd][1] as List<StockDetailWork>;
                    }
                    else
                    {
                        // UOE発注データを検索,検索条件の設定
                        UOESendProcCndtnPara para = new UOESendProcCndtnPara();
                        para.EnterpriseCode = answerDateMazdaPara.EnterpriseCode; //企業コード					
                        para.CashRegisterNo = 0; //レジ番号					
                        para.SystemDivCd = systemDivCd; //システム区分	
                        para.St_InputDay = DateTime.MinValue; //開始入力日					
                        para.Ed_InputDay = DateTime.MaxValue; //終了入力日					
                        para.CustomerCode = 0; //得意先コード					
                        para.UOESupplierCd = answerDateMazdaPara.UOESupplierCd; //UOE発注先コード					
                        para.St_OnlineNo = int.MinValue; //開始呼出番号					
                        para.Ed_OnlineNo = int.MaxValue; //終了呼出番号					
                        para.DataSendCodes = new int[] { 1 }; //データ送信フラグ

                        // UOE発注データを検索
                        status = this._uOEOrderDtlAcs.Search(para, out uOEOrderDtlWorkList, out stockDetailWorkList, out errMessage);

                        if (status != 0)
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                                continue;
                            }

                            return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        }

                        ArrayList list = new ArrayList();
                        list.Add(uOEOrderDtlWorkList);
                        list.Add(stockDetailWorkList);
                        systemDivDic.Add(systemDivCd, list);
                    }

                    if (uOEOrderDtlWorkList == null || uOEOrderDtlWorkList.Count == 0)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        continue;
                    }
                    
                    // 発注処理で作成されたデータの絞込み
                    List<UOEOrderDtlWork> retuOEOrderDtlWorkList = this.FilterUOEOrderDtlList(uOEOrderDtlWorkList, uoeRemark);

                    if (retuOEOrderDtlWorkList == null || retuOEOrderDtlWorkList.Count == 0)
                    {
                        continue;
                    }

                    // 絞り込まれた発注データと対になる仕入明細データを抽出
                    List<StockDetailWork> retStockDetailWorkList = this.FilterStockDetailList(retuOEOrderDtlWorkList, stockDetailWorkList);

                    // 対象UOE発注データを回答発注データのソート順でソート
                    retuOEOrderDtlWorkList.Sort(new UOEOrderDtlWorkComparer());

                    this.MergeList(ref retuOEOrderDtlWorkList, tempList);

                    // 確定処理使用
                    this._uOEOrderDtlWorkList.AddRange(retuOEOrderDtlWorkList);
                    this._stockDetailWorkList.AddRange(retStockDetailWorkList);
                }
            }

            if (this._uOEOrderDtlWorkList.Count == 0 || this._stockDetailWorkList.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            else
            {
                // データセット行増加処理
                this.DataTableAddRow(this._uOEOrderDtlWorkList);
            }

            return status;
        }

        /// <summary>
        /// ファイル情報取得処理
        /// </summary>
        /// <param name="filesDataDtlList">ファイル情報</param>
        /// <param name="answerSaveFolder">回答保存フォルダ</param>
        /// <param name="errMessage">メッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : ファイル情報を取得処理する。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected abstract int GetFilesData(out List<UOEOrderDtlInfo> filesDataDtlList, string answerSaveFolder, ref string errMessage);

        /// <summary>
        /// 発注処理で作成されたデータの絞込み
        /// </summary>
        /// <param name="list">情報</param>
        /// <param name="remark2">リマーク2</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : 発注処理で作成されたデータの絞込み。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected abstract List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, string remark2);
        #endregion

        # region -- 確定処理 --
        /// <summary>
        /// 確定処理
        /// </summary>
        /// <param name="answerDateMazdaPara">画面情報</param>
        /// <param name="errMessage">メッセージ</param>
        /// <returns>チェック結果。　0：正常；　-1：異常</returns>
        /// <remarks>
        /// <br>Note       : 確定処理する。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public int DoConfirm(AnswerDateMazdaPara answerDateMazdaPara, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            errMessage = string.Empty;

            if (this._uOEOrderDtlWorkList.Count == 0 || this._stockDetailWorkList.Count == 0)
            {
                errMessage = "取込処理に失敗しました。";
                return (-1);
            }

            Dictionary<int, object> sysDivDic = new Dictionary<int, object>();
            foreach (UOEOrderDtlWork uOEOrderDtlWork in this._uOEOrderDtlWorkList)
            {
                int sysDiv = uOEOrderDtlWork.SystemDivCd;

                if (sysDivDic.ContainsKey(sysDiv))
                {
                    continue;
                }

                sysDivDic.Add(sysDiv, null);

                List<UOEOrderDtlWork> uOEOrderDtlWorkList = this._uOEOrderDtlWorkList.FindAll(
                            delegate(UOEOrderDtlWork work)
                            {
                                if (work.SystemDivCd == sysDiv)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                 );

                // 絞り込まれた発注データと対になる仕入明細データの抽出処理
                List<StockDetailWork> stockDetailWorkList = this.FilterStockDetailList(uOEOrderDtlWorkList, this._stockDetailWorkList);

                // 条件クラス
                UoeSndRcvCtlPara uoeSndRcvCtlPara = new UoeSndRcvCtlPara();
                uoeSndRcvCtlPara.BusinessCode = 1; // 1:発注 2:見積 3:在庫確認 4:取消処理
                uoeSndRcvCtlPara.EnterpriseCode = answerDateMazdaPara.EnterpriseCode;
                uoeSndRcvCtlPara.SystemDivCd = sysDiv;
                uoeSndRcvCtlPara.ProcessDiv = 1;            //0：通常、1：復旧

                // ＵＯＥ送受信制御
                status = this._uoeSndRcvCtlAcs.UoeSndRcvCtl(uoeSndRcvCtlPara, uOEOrderDtlWorkList, stockDetailWorkList, out errMessage);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    break;
                }
            }

            return status;
        }
        #endregion

        # region -- DataTableの処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データセットクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットクリア処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public abstract void DataTableClear();

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected abstract void DataTableColumnConstruction();

        /// <summary>
        /// データセット行増加処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセット行増加処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected abstract void DataTableAddRow(List<UOEOrderDtlWork> workList);
        # endregion

        # region -- 文字列編集処理 --
        /// <summary>
        /// string -> int 処理
        /// </summary>
        /// <param name="targetText">処理対象テキスト</param>
        /// <remarks>
        /// <br>Note	   : intを返します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected int StringToInt(string targetText)
        {
            int result = 0;

            if (string.IsNullOrEmpty(targetText)) return result;

            try
            {
                result = Convert.ToInt32(targetText);
            }
            catch
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// string -> Double 処理
        /// </summary>
        /// <param name="targetText">処理対象テキスト</param>
        /// <remarks>
        /// <br>Note	   : intを返します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected double StringToDouble(string targetText)
        {
            double result = 0;

            if (string.IsNullOrEmpty(targetText)) return result;

            try
            {
                result = Convert.ToDouble(targetText);
            }
            catch
            {
                result = 0;
            }

            return result;
        }
        #endregion

        # region -- リスト順の作成処理 --
        /// <summary>
        /// 対象UOE発注データ比較クラス(オンライン番号(昇順)、インライン行番号(昇順)、UOE発注番号(昇順)、UOE発注行番号(昇順))
        /// </summary>
        /// <remarks>
        /// <br>Note       : 対象UOE発注データ比較クラス。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private class UOEOrderDtlWorkComparer : Comparer<UOEOrderDtlWork>
        {
            /// <summary>
            /// 比較処理
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override int Compare(UOEOrderDtlWork x, UOEOrderDtlWork y)
            {
                // オンライン番号 
                int result = x.OnlineNo.CompareTo(y.OnlineNo);
                if (result != 0) return result;

                // オンライン行番号
                result = x.OnlineRowNo.CompareTo(y.OnlineRowNo);
                if (result != 0) return result;

                // UOE発注番号
                result = x.UOESalesOrderNo.CompareTo(y.UOESalesOrderNo);
                if (result != 0) return result;

                // UOE発注行番号
                result = x.UOESalesOrderRowNo.CompareTo(y.UOESalesOrderRowNo);
                return result;
            }
        }
        # endregion

        # region  -- その他処理 --
        /// <summary>
        /// リマーク2のチェック処理
        /// </summary>
        /// <param name="uoeRemark2">リマーク2</param>
        /// <returns>True:有効  False:無効</returns>
        /// <remarks>
        /// <br>Note       : リマーク2のチェック処理を行い</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected bool CheckUoeRemark2(string uoeRemark2)
        {
            // リマーク2は空場合
            if (uoeRemark2 == null
                || uoeRemark2.Trim() == ""
                || uoeRemark2.Length < 2)
            {
                return false;
            }

            // 「"@" + システム区分（1桁） + 連携No.」のチェック
            if (uoeRemark2.Substring(0, 2) != "@0"
                && uoeRemark2.Substring(0, 2) != "@1"
                && uoeRemark2.Substring(0, 2) != "@2"
                && uoeRemark2.Substring(0, 2) != "@3"
                && uoeRemark2.Substring(0, 2) != "@4")
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 絞り込まれた発注データと対になる仕入明細データの抽出処理
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">絞り込まれた発注データリスト</param>
        /// <param name="stockDetailWorkList">仕入明細データリスト</param>
        /// <returns>結果仕入明細データリスト</returns>
        /// <remarks>
        /// <br>Note       : 絞り込まれた発注データと対になる仕入明細データを抽出</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private List<StockDetailWork> FilterStockDetailList(List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList)
        {
            List<StockDetailWork> retList = new List<StockDetailWork>();

            foreach (UOEOrderDtlWork uOEOrderDtlWork in uOEOrderDtlWorkList)
            {
                // 仕入形式
                int supplierFormal = uOEOrderDtlWork.SupplierFormal;
                // 仕入明細通番
                long stockSlipDtlNum = uOEOrderDtlWork.StockSlipDtlNum;

                foreach (StockDetailWork stockDetailWork in stockDetailWorkList)
                {
                    if (stockDetailWork.EnterpriseCode == uOEOrderDtlWork.EnterpriseCode
                        && stockDetailWork.SupplierFormal == supplierFormal
                        && stockDetailWork.StockSlipDtlNum == stockSlipDtlNum)
                    {
                        retList.Add(stockDetailWork);
                    }
                }
            }

            return retList;
        }

        /// <summary>
        /// 発注回答データをUOE発注データに反映の処理
        /// </summary>
        /// <param name="workList">UOE発注データ</param>
        /// <param name="dateList">発注回答データ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 発注回答データをUOE発注データに反映ﾞを処理</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        protected abstract int MergeList(ref List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList);
        #endregion

        #region -- 進捗表示 --

        /// <summary>進捗表示用フォーム</summary>
        SFCMN00299CA _progressForm;
        /// <summary>進捗表示用フォームを取得または設定します。</summary>
        public SFCMN00299CA ProgressForm
        {
            get { return _progressForm; }
            set { _progressForm = value; }
        }

        /// <summary>
        /// 進捗表示用フォームを閉じるイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void CloseProgressForm(object sender, UoeSndRcvCtlAcs.UpdateProgressEventArgs e)
        {
            if (ProgressForm == null) return;

            // DB更新が完了したら進捗表示用フォームを閉じます。
            if (e.ProgressState.Equals(UoeSndRcvCtlAcs.SendAndReceiveProgress.DoneUpdateDB))
            {
                ProgressForm.Close();
            }
        }
        #endregion // 進捗表示

        # region -- キャッシュ処理 --
        /// <summary>
        /// 発注先の算出
        /// </summary>
        /// <param name="outUOESupplierlilst">UOE発注先マスタInfo</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">ログイン拠点</param>
        /// <param name="commAssemblyId">commAssemblyId</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 発注先の算出処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public int GetUOESupplier(out ArrayList outUOESupplierlilst, string enterpriseCode, string sectionCode, string commAssemblyId)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            outUOESupplierlilst = new ArrayList();

            // 検索結果
            ArrayList uOESupplierList = new ArrayList();

            // ＵＯＥ発注先マスタを読み込み
            status = this._uOESupplierAcs.SearchAll(out uOESupplierList, enterpriseCode, sectionCode);

            // 正常の場合
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                status = 0;

                foreach (UOESupplier uOESupplier in uOESupplierList)
                {
                    if (uOESupplier.LogicalDeleteCode == 0 && (uOESupplier.CommAssemblyId == commAssemblyId || uOESupplier.CommAssemblyId == MAZDACOMMASSEMBLY_ID_0403) && uOESupplier.InqOrdDivCd == 0)
                    {
                        outUOESupplierlilst.Add(uOESupplier);
                    }
                }
            }

            return status;
        }
        # endregion
    }
}
