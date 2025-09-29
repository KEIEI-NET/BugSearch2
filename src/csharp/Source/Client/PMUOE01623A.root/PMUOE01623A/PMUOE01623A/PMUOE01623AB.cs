//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 回答データ取込処理
// プログラム概要   : UOE発注データと発注回答データのつけ合わせを行い、
//                    売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 李占川
// 作 成 日  2010/03/08  修正内容 : 新規作成
//                                 【要件No.6】UOE発注データと発注回答データのつけ合わせを行い、売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 李占川
// 修 正 日  2010/03/18  修正内容 : redmine#4044,4046とソース指摘の修正
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 李占川
// 修 正 日  2010/03/22  修正内容 : redmine#4067,4068の修正
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : 鄧潘ハン
// 修 正 日  2010/12/31  修正内容 : 自動取込区分の追加に伴い処理が変更になるため、既存の手動処理は残しつつ	、自動取込の処理追加を行います。 
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : liyp
// 修 正 日  2011/03/01  修正内容 : 日産自動化追加仕様分の組み込み
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : 曹文傑
// 修 正 日  2011/03/15  修正内容 : Redmine #19908・#19948の対応
//----------------------------------------------------------------------------//
using System;
using Microsoft.VisualBasic.FileIO;
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
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2010/03/08</br>
    /// <br>UpdateNote : 李占川 2010/03/18 redmine#4044,4046とソース指摘の修正</br>
    /// <br>UpdateNote : 李占川 2010/03/22 redmine#4067,4068の修正</br>
    /// <br>UpdateNote : 2010/12/31 鄧潘ハン</br>
    /// <br>           　自動取込区分の追加に伴い処理が変更になるため、既存の手動処理は残しつつ	、自動取込の処理追加を行います。</br> 
    /// <br>UpdateNpet :2011/03/01 liyp 日産自動化追加仕様分の組み込み</br>
    /// <br>UpdateNote :2011/03/15 曹文傑 Redmine #19908・#19948の対応</br>
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

        public  int UOESupplierCd = 0;// ADD 2010/12/31
        private int _uOESupplierFlag = 0; // ADD 2011/03/15
        private const string NISSANCOMMASSEMBLY_ID_0205 = "0205"; // ADD 2011/03/01
        private const string NISSANCOMMASSEMBLY_ID_0204 = "0204"; // ADD 2011/03/15
        private const string NISSANCOMMASSEMBLY_ID_0206 = "0206"; // ADD 2011/03/15
        #endregion

        # region -- コンストラクタ --
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オフライン対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 李占川 2010/03/18 redmine#4037の修正</br>
        /// </remarks>
        //public UOEOrderDtlInfoBuilder() // DEL 2010/03/18
        protected UOEOrderDtlInfoBuilder() // ADD 2010/03/18
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
        /// <param name="answerDateNissanPara">画面情報</param>
        /// <param name="errMessage">メッセージ</param>
        /// <returns>チェック結果。　0：正常；　-1：異常</returns>
        /// <remarks>
        /// <br>Note       : RCV情報を取得処理する。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 李占川 2010/03/18 redmine#4046の修正</br>
        /// <br>UpdateNote : 李占川 2010/03/22 redmine#4067,4068の修正</br>
        /// <br>UpdateNote : 2010/12/31 鄧潘ハン</br>
        /// <br>           　自動取込区分の追加に伴い処理が変更になるため、既存の手動処理は残しつつ	、自動取込の処理追加を行います。</br> 
        /// <br>UpdateNote :2011/03/01 liyp 日産自動化追加仕様分の組み込み</br>
        /// <br>UpdateNote :2011/03/15 曹文傑 Redmine #19948の対応</br>
        /// </remarks>
        public int DoSearch(AnswerDateNissanPara answerDateNissanPara, out string errMessage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMessage = string.Empty;

            List<UOEOrderDtlInfo> filesDataDtlList;
            this._stockDetailWorkList.Clear();
            this._uOEOrderDtlWorkList.Clear();
            UOESupplierCd = answerDateNissanPara.UOESupplierCd;// ADD 2010/12/31

            // ファイル情報取得処理
            // --- UPD 2010/03/18 ---------->>>>>
            //status = this.GetFilesDate(out filesDataDtlList, answerDateNissanPara.AnswerSaveFolder, ref errMessage);
            status = this.GetFilesData(out filesDataDtlList, answerDateNissanPara.AnswerSaveFolder, ref errMessage);
            // --- UPD 2010/03/18 ----------<<<<<

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            // Filesのデータがない場合
            if (filesDataDtlList == null || filesDataDtlList.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // ソート順でソート
            //filesDataDtlList.Sort(new UOEOrderDtlInfoComparer()); // DEL 2010/03/18

            Dictionary<string, object> uoeRemarkDic = new Dictionary<string, object>();
            Dictionary<int, ArrayList> systemDivDic = new Dictionary<int, ArrayList>();

            foreach (UOEOrderDtlInfo info in filesDataDtlList)
            {
                // 発注回答データのリマーク2
                string uoeRemark = info.UoeRemark2.Trim();
                // -----ADD 2011/03/01 ------------>>>>>
                if (!string.IsNullOrEmpty(info.RenkeNo))
                {
                    uoeRemark = info.RenkeNo.Trim();
                }
                // -----ADD 2011/03/01 ------------<<<<<
                if (!uoeRemarkDic.ContainsKey(uoeRemark))
                { 
                    // ---------UPD 2011/03/01 ---------------->>>>>
                    List<UOEOrderDtlInfo> tempList;
                    uoeRemarkDic.Add(uoeRemark, null);
                    if (!string.IsNullOrEmpty(info.RenkeNo))
                    {
                        tempList = filesDataDtlList.FindAll(
                                    delegate(UOEOrderDtlInfo info2)
                                    {
                                        if (info2.RenkeNo == uoeRemark)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                        );
                    }
                    else
                    {
                        tempList = filesDataDtlList.FindAll(
                                    delegate(UOEOrderDtlInfo info2)
                                    {
                                        if (info2.UoeRemark2 == uoeRemark)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                        );
                    }
                    // ---------UPD 2011/03/01 ----------------<<<<<

                    // ---UPD 2011/03/15---------------->>>>>
                    // システム区分
                    //int systemDivCd = Int32.Parse(uoeRemark.Substring(1, 1));
                    int systemDivCd = 0;
                    if (this._uOESupplierFlag == 5)
                    {
                        systemDivCd = Int32.Parse(uoeRemark.Substring(3, 1));
                    }
                    else
                    {
                        systemDivCd = Int32.Parse(uoeRemark.Substring(1, 1));
                    }
                    // ---UPD 2011/03/15----------------<<<<<

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
                        para.EnterpriseCode = answerDateNissanPara.EnterpriseCode; //企業コード					
                        para.CashRegisterNo = 0; //レジ番号					
                        para.SystemDivCd = systemDivCd; //システム区分	
                        para.St_InputDay = DateTime.MinValue; //開始入力日					
                        para.Ed_InputDay = DateTime.MaxValue; //終了入力日					
                        para.CustomerCode = 0; //得意先コード					
                        para.UOESupplierCd = answerDateNissanPara.UOESupplierCd; //UOE発注先コード					
                        para.St_OnlineNo = int.MinValue; //開始呼出番号					
                        para.Ed_OnlineNo = int.MaxValue; //終了呼出番号					
                        para.DataSendCodes = new int[] { 1 }; //データ送信フラグ

                        // UOE発注データを検索
                        status = this._uOEOrderDtlAcs.Search(para, out uOEOrderDtlWorkList, out stockDetailWorkList, out errMessage);

                        if (status != 0)
                        {
                            // --- ADD 2010/03/22 ---------->>>>>
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                                continue;
                            }
                            // --- ADD 2010/03/22 ----------<<<<<

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
        /// CSV情報取得処理
        /// </summary>
        /// <param name="csvDataList">CSV情報</param>
        /// <param name="filePathName">ファイル名前</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : CSV情報を取得処理する。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 李占川 2010/03/18 ソース指摘の修正</br>
        /// </remarks>
        //public int GetCSVData(out List<string[]> csvDataList, string filePathName) // DEL 2010/03/18
        protected int GetCSVData(out List<string[]> csvDataList, string filePathName) // ADD 2010/03/18
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // CSV情報
            csvDataList = new List<string[]>();
            try
            {
                FileStream fileStream = new FileStream(filePathName, FileMode.Open, FileAccess.Read, FileShare.None);
                byte[] bytes = new byte[fileStream.Length];
                fileStream.Read(bytes, 0, bytes.Length);
                fileStream.Close();
                Stream stream = new MemoryStream(bytes);

                TextFieldParser parser = new TextFieldParser(stream, System.Text.Encoding.GetEncoding("Shift_JIS"));
                using (parser)
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(","); // 区切り文字はコンマ
                    while (!parser.EndOfData)
                    {
                        string[] row = parser.ReadFields(); // 1行読み込み
                        csvDataList.Add(row);
                    }
                }
            }
            catch
            {
                // 異常場合
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 李占川 2010/03/18 ソース指摘の修正</br>
        /// </remarks>
        //public abstract int GetFilesDate(out List<UOEOrderDtlInfo> filesDataDtlList, string answerSaveFolder, ref string errMessage); // DEL 2010/03/18
        protected abstract int GetFilesData(out List<UOEOrderDtlInfo> filesDataDtlList, string answerSaveFolder, ref string errMessage); // ADD 2010/03/18

        /// <summary>
        /// 発注処理で作成されたデータの絞込み
        /// </summary>
        /// <param name="list">情報</param>
        /// <param name="remark2">リマーク2</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : 発注処理で作成されたデータの絞込み。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        //public abstract List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, string remark2); // DEL 2010/03/18
        protected abstract List<UOEOrderDtlWork> FilterUOEOrderDtlList(List<UOEOrderDtlWork> list, string remark2); // ADD 2010/03/18
        #endregion

        # region -- 確定処理 --
        /// <summary>
        /// 確定処理
        /// </summary>
        /// <param name="answerDateNissanPara">画面情報</param>
        /// <param name="errMessage">メッセージ</param>
        /// <returns>チェック結果。　0：正常；　-1：異常</returns>
        /// <remarks>
        /// <br>Note       : 確定処理する。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public int DoConfirm(AnswerDateNissanPara answerDateNissanPara, out string errMessage)
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
                uoeSndRcvCtlPara.EnterpriseCode = answerDateNissanPara.EnterpriseCode;
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.06.08</br>
        /// </remarks>
        public abstract void DataTableClear();

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 李占川 2010/03/18 ソース指摘の修正</br>
        /// </remarks>
        //public abstract void DataTableColumnConstruction(); // DEL 2010/03/18
        protected abstract void DataTableColumnConstruction(); // ADD 2010/03/18

        /// <summary>
        /// データセット行増加処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセット行増加処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 李占川 2010/03/18 ソース指摘の修正</br>
        /// </remarks>
        //public abstract void DataTableAddRow(List<UOEOrderDtlWork> workList); // DEL 2010/03/18
        protected abstract void DataTableAddRow(List<UOEOrderDtlWork> workList); // ADD 2010/03/18
        # endregion

        # region -- 文字列編集処理 --
        /// <summary>
        /// string -> int 処理
        /// </summary>
        /// <param name="targetText">処理対象テキスト</param>
        /// <remarks>
        /// <br>Note	   : intを返します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 李占川 2010/03/18 ソース指摘の修正</br>
        /// </remarks>
        //public int StringToInt(string targetText) // DEL 2010/03/18
        protected int StringToInt(string targetText) // ADD 2010/03/18
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 李占川 2010/03/18 ソース指摘の修正</br>
        /// </remarks>
        //public double StringToDouble(string targetText) // DEL 2010/03/18
        protected double StringToDouble(string targetText) // ADD 2010/03/18
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
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

        // --- DEL 2010/03/18 ---------->>>>>
        ///// <summary>
        ///// 対象UOE発注データ比較クラス(オンライン番号(昇順)、インライン行番号(昇順)、UOE発注番号(昇順)、UOE発注行番号(昇順))
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : 対象UOE発注データ比較クラス。</br>
        ///// <br>Programmer : 李占川</br>
        ///// <br>Date       : 2010/03/08</br>
        ///// </remarks>
        //private class UOEOrderDtlInfoComparer : Comparer<UOEOrderDtlInfo>
        //{
        //    /// <summary>
        //    /// 比較処理
        //    /// </summary>
        //    /// <param name="x"></param>
        //    /// <param name="y"></param>
        //    /// <returns></returns>
        //    public override int Compare(UOEOrderDtlInfo x, UOEOrderDtlInfo y)
        //    {
        //        // ＵＯＥリマーク２
        //        int result = x.UoeRemark2.CompareTo(y.UoeRemark2);
        //        if (result != 0) return result;

        //        // オンライン番号 
        //        int result = x.OnlineNo.CompareTo(y.OnlineNo);
        //        if (result != 0) return result;

        //        // オンライン行番号
        //        result = x.OnlineRowNo.CompareTo(y.OnlineRowNo);
        //        if (result != 0) return result;

        //        // UOE発注番号
        //        result = x.UOESalesOrderNo.CompareTo(y.UOESalesOrderNo);
        //        if (result != 0) return result;

        //        // UOE発注行番号
        //        result = x.UOESalesOrderRowNo.CompareTo(y.UOESalesOrderRowNo);
        //        return result;
        //    }
        //}
        // --- DEL 2010/03/18 ----------<<<<<
        # endregion

        # region  -- その他処理 --
        /// <summary>
        /// リマーク2のチェック処理
        /// </summary>
        /// <param name="uoeRemark2">リマーク2</param>
        /// <returns>True:有効  False:無効</returns>
        /// <remarks>
        /// <br>Note       : リマーク2のチェック処理を行い</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 李占川 2010/03/18 ソース指摘の修正</br>
        /// </remarks>
        //public bool CheckUoeRemark2(string uoeRemark2) // DEL 2010/03/18
        protected bool CheckUoeRemark2(string uoeRemark2) // ADD 2010/03/18
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

        // ---ADD 2011/03/15-------------->>>>>
        /// <summary>
        /// リマーク2のチェック処理（プログラム：0206のみ用）
        /// </summary>
        /// <param name="uoeRemark2">リマーク2</param>
        /// <returns>True:有効  False:無効</returns>
        /// <remarks>
        /// <br>Note       : リマーク2のチェック処理を行い</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/03/15</br>
        /// </remarks>
        protected bool CheckRenKeNo(string uoeRemark2)
        {
            // リマーク2は空場合
            if (uoeRemark2 == null
                || uoeRemark2.Trim() == ""
                || uoeRemark2.Length < 4)
            {
                return false;
            }

            // 「"@" + システム区分（1桁） + 連携No.」のチェック
            if (uoeRemark2.Substring(3, 1) != "0"
                && uoeRemark2.Substring(3, 1) != "1"
                && uoeRemark2.Substring(3, 1) != "2"
                && uoeRemark2.Substring(3, 1) != "3"
                && uoeRemark2.Substring(3, 1) != "4")
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// プログラムIDを設定
        /// </summary>
        /// <param name="uOESupplierFlag">プログラムID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : プログラムIDを設定</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/03/15</br>
        /// </remarks>
        protected void SetUOESupplierFlag(int uOESupplierFlag)
        {
            this._uOESupplierFlag = uOESupplierFlag;
        }
        // ---ADD 2011/03/15--------------<<<<<

        /// <summary>
        /// 絞り込まれた発注データと対になる仕入明細データの抽出処理
        /// </summary>
        /// <param name="uOEOrderDtlWorkList">絞り込まれた発注データリスト</param>
        /// <param name="stockDetailWorkList">仕入明細データリスト</param>
        /// <returns>結果仕入明細データリスト</returns>
        /// <remarks>
        /// <br>Note       : 絞り込まれた発注データと対になる仕入明細データを抽出</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 李占川 2010/03/18 ソース指摘の修正</br>
        /// </remarks>
        //public abstract int MergeList(ref List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList); // DEL 2010/03/18
        protected abstract int MergeList(ref List<UOEOrderDtlWork> workList, List<UOEOrderDtlInfo> dateList); // ADD 2010/03/18
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote :2011/03/01 liyp</br>
        /// <br>          日産UOE自動化B対応</br>
        /// <br>UpdateNote :2011/03/15 曹文傑</br>
        /// <br>          Redmine #19908の対応</br>
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
                    //if (uOESupplier.LogicalDeleteCode == 0 && uOESupplier.CommAssemblyId == commAssemblyId) // DEL 2011/03/01
                    // ---UPD 2011/03/15--------------->>>>>
                    //if (uOESupplier.LogicalDeleteCode == 0 && (uOESupplier.CommAssemblyId == commAssemblyId || uOESupplier.CommAssemblyId == NISSANCOMMASSEMBLY_ID_0205) && uOESupplier.InqOrdDivCd == 0)// ADD 2011/03/01
                    if (uOESupplier.LogicalDeleteCode == 0 && (uOESupplier.CommAssemblyId == commAssemblyId || 
                                                                uOESupplier.CommAssemblyId == NISSANCOMMASSEMBLY_ID_0205 ||
                                                                uOESupplier.CommAssemblyId == NISSANCOMMASSEMBLY_ID_0204 ||
                                                                uOESupplier.CommAssemblyId == NISSANCOMMASSEMBLY_ID_0206))
                    // ---UPD 2011/03/15---------------<<<<<
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
