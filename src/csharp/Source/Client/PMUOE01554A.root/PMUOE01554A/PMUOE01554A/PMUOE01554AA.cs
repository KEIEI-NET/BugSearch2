//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 注文一覧更新処理
// プログラム概要   : ホンダe-Partsシステムより「ご注文一覧CSV」を取り込み、
//                    回答情報を更新します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 修 正 日  2011/12/02  修正内容 : Readmine 8304対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 修 正 日  2011/12/20  修正内容 : Readmine 26901対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 修 正 日  2014/03/25  修正内容 : CSV項目タイトル変更
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.UIData;
using System.IO;
using System.Data;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 注文一覧更新処理アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 注文一覧更新処理のアクセス制御を行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.05.31</br>
    /// <br></br>
    /// <br>Update Note: 2009/06/25 李占川</br>
    /// <br>             PVCS#273について、アイテムチェックを修正します。</br>
    /// <br>Update Note: 2009/06/25 李占川</br>
    /// <br>             仕様変更11について、注文対象の明細が存在チェックを追加します。</br>
    /// </remarks>
    public class UoeOrderAllInfoAcs
    {
        # region プライベート変数
        /*----------------------------------------------------------------------------------*/
        private DataTable _dataTable;
        private UOESupplierAcs _uOESupplierAcs;
        private UoeSndRcvCtlAcs _uoeSndRcvCtlAcs;
        # endregion

        # region プライベート定数
        /*----------------------------------------------------------------------------------*/
        // 起動Mode
        private const int INPUT_MODE = 1;  // 手入力
        private const int PM_MODE = 0;  // PM連動

        // datatable名称用
        private const string TABLE_ID = "RESULT_TABLE";
        private const string FILENAME = "fileName"; // ファイル名
        private const string PROCESSNUM = "processNum"; // 件数
        private const string RESULT = "result"; // 結果

        // 更新結果
        private const string RESULT0 = "正常終了";
        private const string RESULT1 = "前回請求日算出エラー";
        private const string RESULT2 = "前回準備処理以前";
        private const string RESULT3 = "取込済";
        private const string RESULT4 = "異常終了";

        // CSV項目(e-Parts手入力時)
        private const string INPUTCSVTITLE_USERNAME = "お客様名";
        private const string INPUTCSVTITLE_USERCODE = "お客様CD";
        private const string INPUTCSVTITLE_ITEMCODE = "アイテム";
        private const string INPUTCSVTITLE_ORDERDATE = "注文日";
        private const string INPUTCSVTITLE_ORDERTIME = "注文時間";
        private const string INPUTCSVTITLE_SLIPNOHEAD = "伝票番号";
        private const string INPUTCSVTITLE_MEMO = "メモ欄";


        // CSV項目(PM連動)
        private const string PMCSVTITLE_USERNAME = "販売店様名";
        private const string PMCSVTITLE_USERCODE = "販売店様コード";
        private const string PMCSVTITLE_SLIPNOHEAD = "伝票番号";
        private const string PMCSVTITLE_ORDERDATE = "発注日";
        private const string PMCSVTITLE_ORDERTIME = "発注時間";
        private const string PMCSVTITLE_ITEMCODE = "アイテム";
        private const string PMCSVTITLE_MSG = "メッセージ";
        private const string PMCSVTITLE_LINKNO = "ｵﾝﾗｲﾝ番号(連携番号)";

        // CSV項目(共通)
        private const string CSVTITLE_ORDERGOODSNO = "発注部品番号";
        private const string CSVTITLE_SHIPMGOODSNO = "出荷部品番号";
        private const string CSVTITLE_GOODSNAME = "出荷部品名";
        private const string CSVTITLE_SHIPMENTCNT = "引当数量";
        private const string CSVTITLE_ORDERREMCNT = "発注残数量";
        private const string CSVTITLE_SOURCESHIPMENT = "出荷元名";
        private const string CSVTITLE_PLANDATE = "お届予定日";
        private const string CSVTITLE_SLIPNODTL = "伝票番号";
        // --- UPD 2014/03/25 T.Miyamoto ------------------------------>>>>>
        //private const string CSVTITLE_ANSWERLISTPRICE = "希望小売価格";
        //private const string CSVTITLE_ANSWERSALESUNITCOST = "仕入れ価格";
        private const string CSVTITLE_ANSWERLISTPRICE = "希望小売単価";
        private const string CSVTITLE_ANSWERSALESUNITCOST = "仕入れ単価";
        // --- UPD 2014/03/25 T.Miyamoto ------------------------------<<<<<
        private const string CSVTITLE_MEMO = "メモ欄";

        private const string SUCCESS_INFO = "ダウンロード成功";

        # endregion

        # region -- コンストラクタ --
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オフライン対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        public UoeOrderAllInfoAcs()
        {
            this._uOESupplierAcs = new UOESupplierAcs();

            // データセット列情報構築処理
            this.DataTableColumnConstruction();
        }
        # endregion

        # region -- 確定処理 --
        /// <summary>
        /// 確定処理
        /// </summary>
        /// <param name="uOESupplierInfo">画面情報</param>
        /// <param name="errMessage">メッセージ</param>
        /// <returns>チェック結果。　0：正常；　-1：異常</returns>
        /// <remarks>
        /// <br>Note       : CSV情報を取得処理する。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        public int DoConfirm(UOESupplierInfo uOESupplierInfo, out string errMessage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMessage = string.Empty;

            this._dataTable.Clear();

            // 注文一覧ＣＳＶファイルの取得
            ArrayList csvFiles = new ArrayList();

            status = this.GetCSVFiles(out csvFiles, uOESupplierInfo.AnswerSaveFolder);

            // 正常場合
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // 処理対象のＣＳＶファイルが存在しない場合
                if (csvFiles.Count == 0)
                {
                    errMessage = "注文一覧ＣＳＶファイルが存在しません。";
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }

                // 注文対象の明細が存在するかどうか
                bool isHaveDetail = false;
                foreach (FileInfo fileInfo in csvFiles)
                {
                    List<string[]> csvDataList;
                    // CSV情報取得処理
                    status = this.GetCSVData(out csvDataList, fileInfo.FullName);

                    // 取得正常場合
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // CSV情報のフォーマットチェック
                        int csvKind = PM_MODE;
                        bool ret = this.CheckCSVFormat(csvDataList, ref csvKind);

                        // フォーマットが正し場合
                        if (ret)
                        {
                            List<OrderLsthead> list = new List<OrderLsthead>();
                            OrderLsthead orderLsthead = new OrderLsthead();

                            ArrayList lstDtl = new ArrayList();
                            // 注文一覧明細の処理
                            if (csvKind == INPUT_MODE)
                            {
                                // 注文一覧明細（手入力）の処理
                                status = this.GetOrderInputDetail(ref lstDtl, csvDataList, uOESupplierInfo, ref errMessage);
                                // 異常場合
                                if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                                {
                                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                }
                                // アイテムは問題がある場合
                                else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                                {
                                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                                    continue;
                                }
                            }
                            else
                            {
                                // 注文一覧明細（PM連動）の処理
                                status = this.GetOrderPMDetail(ref lstDtl, csvDataList, uOESupplierInfo, ref errMessage);
                                // 異常場合
                                if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                                {
                                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                }
                                // アイテムは問題がある場合
                                else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                                {
                                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                                    continue;
                                }
                            }

                            // 注文対象の明細が存在します。
                            isHaveDetail = true;

                            // ＣＳＶ種別
                            orderLsthead.CsvKnd = csvKind;
                            // ＣＳＶファイル名
                            orderLsthead.CsvName = fileInfo.Name;
                            // ＣＳＶフルパス名
                            orderLsthead.CsvFullPath = fileInfo.FullName;
                            // 注文一覧明細クラス
                            orderLsthead.LstDtl = lstDtl;
                            // 企業コード
                            orderLsthead.EnterpriseCode = uOESupplierInfo.EnterpriseCode;
                            // 拠点コード
                            orderLsthead.SectionCode = uOESupplierInfo.SectionCode;
                            // UOE発注先コード
                            orderLsthead.UOESupplierCd = uOESupplierInfo.UOESupplierCd;
                            // 更新結果							
                            orderLsthead.UpdRsl = 9;

                            list.Add(orderLsthead);

                            // 回答データの更新処理
                            status = this.DoUpdate(ref list, ref errMessage);
                            // 正常
                            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                // 更新結果が「0:正常終了」場合
                                if (list[0].UpdRsl == 0)
                                {
                                    // 注文一覧ＣＳＶファイルの削除処理
                                    status = this.DeleteCSVFile(fileInfo);
                                }
                            }
                            // 異常
                            else
                            {
                                errMessage = "ホンダUOE-WEB回答データの更新処理に失敗しました。";
                                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            }
                        }
                    }
                }

                // --- ADD 2009/06/25 ------------------------------->>>>>
                // 注文対象の明細が存在しない場合、エラーとします。
                if (!isHaveDetail)
                {
                    errMessage = "注文一覧ＣＳＶが存在しません。";
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                // --- ADD 2009/06/25 ------------------------------<<<<<
            }
            else
            {
                errMessage = "ＣＳＶファイルの取得に失敗しました。";
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// CSVファイルリスト取得処理
        /// </summary>
        /// <param name="csvFileList">CSVファイルリスト</param>
        /// <param name="filePath">ファイル名前</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : CSVファイルリストを取得処理する。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private int GetCSVFiles(out ArrayList csvFileList, string filePath)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            csvFileList = new ArrayList();
            try
            {                
                // フォルダ下のファイルを取り込
                string[] fileList = System.IO.Directory.GetFiles(filePath, "*.csv");                
                //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304 ---------->>>>>>>>>>>>> 
                string dateFormat = "yyyyMMddHHmmss";
                DateTime dt = DateTime.Now;
                string bakFileName  = string.Empty;
                //------ADD BY 凌小青 on 2011/12/20 for Redmine#26901------>>>>>
                if (!Directory.Exists(filePath + "\\" + "BAK") && fileList.Length > 0)
                {
                    Directory.CreateDirectory(filePath + "\\" + "BAK");
                }
                //------ADD BY 凌小青 on 2011/12/20 for Redmine#26901------<<<<<
                //------DEL BY 凌小青 on 2011/12/20 for Redmine#26901------>>>>>
                //foreach (string file in fileList)
                //{
                //    bakFileName = file.Substring(0, file.Length - 4) + "_" + dt.ToString(dateFormat) + ".csv";
                //    File.Copy(file, bakFileName);
                //}
                //string[] bakFileList = System.IO.Directory.GetFiles(filePath, "*_"+dt.ToString(dateFormat)+".csv");
                //------DEL BY 凌小青 on 2011/12/20 for Redmine#26901------>>>>>
                //--------ADD BY 凌小青 on 2011/12/02 for Redmine#8304 ----------<<<<<<<<<<<<<
                foreach (string file in fileList) 
                {
                    //------ADD BY 凌小青 on 2011/12/20 for Redmine#26901------>>>>>
                    string subFile = file.Substring(0, file.Length - 4);
                    bakFileName = subFile.Substring(filePath.Length + 1) + "_" + dt.ToString(dateFormat) + ".csv";
                    File.Copy(file, filePath + "\\" + "BAK" + "\\" + bakFileName);
                    //------ADD BY 凌小青 on 2011/12/20 for Redmine#26901------<<<<<
                    FileInfo info = new FileInfo(file);
                    csvFileList.Add(info);
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private int GetCSVData(out List<string[]> csvDataList, string filePathName)
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
        /// CSV情報のフォーマットチェック
        /// </summary>
        /// <param name="csvDataList">CSV情報</param>
        /// <param name="csvKind">ＣＳＶ種別</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : CSV情報を取得処理する。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private bool CheckCSVFormat(List<string[]> csvDataList, ref int csvKind)
        {
            if (csvDataList.Count < 5)
            {
                return false;
            }

            // 1行目
            string[] csvInfo1 = csvDataList[0];

            // 1行目に"ダウンロード成功"が存在
            if (!csvInfo1[0].Contains(SUCCESS_INFO))
            {
                return false;
            }

            // 2行目
            string[] csvInfo2 = csvDataList[1];
            // 4行目
            string[] csvInfo4 = csvDataList[3];

            // 「PM連動時」
            if (csvInfo2[0].Equals(PMCSVTITLE_USERNAME)
                && csvInfo2[1].Equals(PMCSVTITLE_USERCODE)
                && csvInfo4[0].Equals(PMCSVTITLE_SLIPNOHEAD)
                && csvInfo4[1].Equals(PMCSVTITLE_ORDERDATE)
                && csvInfo4[2].Equals(PMCSVTITLE_ORDERTIME)
                && csvInfo4[3].Equals(PMCSVTITLE_ITEMCODE)
                && csvInfo4[4].Equals(PMCSVTITLE_MSG)
                && csvInfo4[5].Equals(PMCSVTITLE_LINKNO))
            {
                csvKind = PM_MODE;
                return true;
            }
            // 「e-Parts手入力時」
            else if (csvInfo2[0].Equals(INPUTCSVTITLE_USERNAME)
                     && csvInfo2[1].Equals(INPUTCSVTITLE_USERCODE)
                     && csvInfo2[2].Equals(INPUTCSVTITLE_ITEMCODE)
                     && csvInfo2[3].Equals(INPUTCSVTITLE_ORDERDATE)
                     && csvInfo2[4].Equals(INPUTCSVTITLE_ORDERTIME)
                     && csvInfo2[5].Equals(INPUTCSVTITLE_SLIPNOHEAD)
                     && csvInfo2[6].Equals(INPUTCSVTITLE_MEMO))
            {
                csvKind = INPUT_MODE;
                return true;
            }
            else
            {
                return false;
            }
        }


        // --- DEL 2009/06/25 ------------------------------->>>>>
        ///// <summary>
        ///// UOEアイテムのチェック処理
        ///// </summary>
        ///// <param name="uOESupplierInfo">画面情報</param>
        ///// <param name="uOEItemCd">注文一覧明細クラス＜アイテム＞項目値</param>
        ///// <returns>チェック結果 0:正常  1:ない  2:複数  3:異なる</returns>
        ///// <remarks>
        ///// <br>Note       : UOE発注先コードの算出処理する。</br>
        ///// <br>Programmer : 李占川</br>
        ///// <br>Date       : 2009.06.02</br>
        ///// </remarks>
        //private int CheckuUOEItemCd(UOESupplierInfo uOESupplierInfo, string uOEItemCd)
        //{
        //    int status = 0;

        //    ArrayList list;

        //    // 発注先の算出
        //    status = this.GetUOESupplier(out list, uOESupplierInfo.EnterpriseCode, uOESupplierInfo.SectionCode);

        //    // 結果の処理
        //    int num = 0;
        //    UOESupplier checkUOESupplier = new UOESupplier();
        //    foreach (UOESupplier uOESupplier in list)
        //    {
        //        if (uOESupplier.UOEItemCd.Equals(uOEItemCd))
        //        {
        //            num++;
        //            checkUOESupplier = uOESupplier;
        //        }
        //    }

        //    // UOE発注先マスタが該当しない場合
        //    if (num == 0)
        //    {
        //        status = 1;
        //    }
        //    // 複数のUOE発注先マスタが該当する場合
        //    else if (num > 1)
        //    {
        //        status = 2;
        //    }
        //    else
        //    {
        //        // 異なる場合
        //        if (checkUOESupplier.UOESupplierCd != uOESupplierInfo.UOESupplierCd)
        //        {
        //            status = 3;
        //        }
        //    }

        //    return status;
        //}
        // --- DEL 2009/06/25 ------------------------------<<<<<

        /// <summary>
        /// 注文一覧明細（手入力）の処理
        /// </summary>
        /// <param name="lstDtl">処理結果</param>
        /// <param name="csvDataList">CSV情報</param>
        /// <param name="uOESupplierInfo">画面の情報</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : 注文一覧明細（手入力）の処理する。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private int GetOrderInputDetail(ref ArrayList lstDtl, List<string[]> csvDataList, UOESupplierInfo uOESupplierInfo, ref string msg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ヘッダInfo
                string[] headInfo = csvDataList[2];

                for (int row = 1; row < csvDataList.Count; row++)
                {
                    string[] detailInfo = csvDataList[row];

                    // ブロック処理
                    if (detailInfo[0] == INPUTCSVTITLE_USERNAME)
                    {
                        // 明細チェック
                        string[] detailTitle = csvDataList[row + 2];
                        if (!(detailTitle[0] == CSVTITLE_ORDERGOODSNO
                            && detailTitle[1] == CSVTITLE_SHIPMGOODSNO
                            && detailTitle[2] == CSVTITLE_GOODSNAME
                            && detailTitle[3] == CSVTITLE_SHIPMENTCNT
                            && detailTitle[4] == CSVTITLE_ORDERREMCNT
                            && detailTitle[5] == CSVTITLE_ANSWERLISTPRICE
                            && detailTitle[6] == CSVTITLE_SOURCESHIPMENT
                            && detailTitle[7] == CSVTITLE_PLANDATE
                            && detailTitle[8] == CSVTITLE_SLIPNODTL
                            && detailTitle[9] == CSVTITLE_ANSWERSALESUNITCOST))
                        {
                            return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }

                        headInfo = csvDataList[row + 1];

                        // --- DEL 2009/06/25 ------------------------------->>>>>
                        //// UOEアイテムのチェック処理
                        //status = this.CheckuUOEItemCd(uOESupplierInfo, headInfo[2]);

                        //switch (status)
                        //{
                        //    // 正常場合
                        //    case 0:
                        //        break;
                        //    // 該当しない場合
                        //    case 1:
                        //        msg = "UOE発注先マスタに該当のアイテムが存在しません。\n<" + headInfo[2] + ">";
                        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        //    // 複数
                        //    case 2:
                        //        msg = "UOE発注先マスタに同じアイテムが複数存在します。\n<" + headInfo[2] + ">";
                        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        //    // 異なる場合
                        //    case 3:
                        //        return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        //}
                        // --- DEL 2009/06/25 ------------------------------<<<<<

                        // --- ADD 2009/06/25 ------------------------------->>>>>
                        // アイテムのチェックに関して
                        // 画面入力項目のUOE発注先より算出したアイテムと、ＣＳＶファイルのアイテムが異なる場合
                        if (!uOESupplierInfo.UOEItemCd.Equals(headInfo[2]))
                        {
                            // 別ＣＳＶファイルを処理します
                            return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        // --- ADD 2009/06/25 ------------------------------<<<<<

                        row = row + 2;

                        continue;
                    }

                    OrderLstInputDtl orderLstInputDtl = new OrderLstInputDtl();

                    orderLstInputDtl.UserName = headInfo[0];  // お客様名
                    orderLstInputDtl.UserCode = headInfo[1];  // お客様CD
                    orderLstInputDtl.ItemCode = headInfo[2];  // アイテム
                    orderLstInputDtl.OrderDate = this.StringToDateTime(headInfo[3]);  // 注文日
                    orderLstInputDtl.OrderTime = StringToInt(StringToDateTime(headInfo[4]).ToString("HHmmss"));  // 注文時間
                    orderLstInputDtl.SlipNoHead = headInfo[5];  // 伝票番号
                    orderLstInputDtl.Memo = headInfo[6];  // メモ欄
                    orderLstInputDtl.OrderGoodsNo = detailInfo[0];  // 発注部品番号
                    orderLstInputDtl.ShipmGoodsNo = detailInfo[1];  // 出荷部品番号
                    orderLstInputDtl.GoodsName = detailInfo[2];  // 出荷部品名
                    orderLstInputDtl.ShipmentCnt = this.StringToDouble(detailInfo[3]);  // 引当数量
                    orderLstInputDtl.OrderRemCnt = this.StringToDouble(detailInfo[4]);  // 発注残数量
                    orderLstInputDtl.AnswerListPrice = this.StringToDouble(detailInfo[5]);  // 希望小売価格
                    orderLstInputDtl.SourceShipment = detailInfo[6];  // 出荷元名
                    orderLstInputDtl.PlanDate = this.StringToDateTime(detailInfo[7]);  // お届予定日
                    orderLstInputDtl.SlipNoDtl = detailInfo[8];  // 伝票番号
                    orderLstInputDtl.AnswerSalesUnitCost = this.StringToDouble(detailInfo[9]);  // 仕入れ価格

                    lstDtl.Add(orderLstInputDtl);
                }
            }
            catch
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // 注文対象の明細が存在しない場合
            if (lstDtl.Count == 0) status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            return status;
        }

        /// <summary>
        /// 注文一覧明細（PM連動）の処理
        /// </summary>
        /// <param name="lstDtl">処理結果</param>
        /// <param name="csvDataList">CSV情報</param>
        /// <param name="uOESupplierInfo">画面の情報</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : 注文一覧明細（PM連動）の処理する。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private int GetOrderPMDetail(ref ArrayList lstDtl, List<string[]> csvDataList, UOESupplierInfo uOESupplierInfo, ref string msg)
        {
            int status = 0;

            try
            {
                // ヘッダInfo1
                string[] headInfo1 = csvDataList[2];
                // ヘッダInfo2
                string[] headInfo2 = csvDataList[4];

                for (int row = 3; row < csvDataList.Count; row++)
                {
                    string[] detailInfo = csvDataList[row];

                    // ブロック処理
                    if (detailInfo[0] == PMCSVTITLE_SLIPNOHEAD)
                    {
                        // 明細チェック
                        string[] detailTitle = csvDataList[row + 2];
                        if (!(detailTitle[0] == CSVTITLE_ORDERGOODSNO
                            && detailTitle[1] == CSVTITLE_SHIPMGOODSNO
                            && detailTitle[2] == CSVTITLE_GOODSNAME
                            && detailTitle[3] == CSVTITLE_SHIPMENTCNT
                            && detailTitle[4] == CSVTITLE_ORDERREMCNT
                            && detailTitle[5] == CSVTITLE_ANSWERLISTPRICE
                            && detailTitle[6] == CSVTITLE_SOURCESHIPMENT
                            && detailTitle[7] == CSVTITLE_PLANDATE
                            && detailTitle[8] == CSVTITLE_SLIPNODTL
                            && detailTitle[9] == CSVTITLE_MEMO
                            && detailTitle[10] == CSVTITLE_ANSWERSALESUNITCOST))
                        {
                            return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }

                        headInfo2 = csvDataList[row + 1];

                        // --- DEL 2009/06/25 ------------------------------->>>>>
                        //// UOEアイテムのチェック処理
                        //status = this.CheckuUOEItemCd(uOESupplierInfo, headInfo2[3]);

                        //switch (status)
                        //{
                        //    // 正常場合
                        //    case 0:
                        //        break;
                        //    // 該当しない場合
                        //    case 1:
                        //        msg = "UOE発注先マスタに該当のアイテムが存在しません。\n<" + headInfo2[3] + ">";
                        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        //    // 複数
                        //    case 2:
                        //        msg = "UOE発注先マスタに同じアイテムが複数存在します。\n<" + headInfo2[3] + ">";
                        //        return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        //    // 異なる場合
                        //    case 3:
                        //        return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        //}
                        // --- DEL 2009/06/25 ------------------------------<<<<<

                        // --- ADD 2009/06/25 ------------------------------->>>>>
                        // アイテムのチェックに関して
                        // 画面入力項目のUOE発注先より算出したアイテムと、ＣＳＶファイルのアイテムが異なる場合
                        if (!uOESupplierInfo.UOEItemCd.Equals(headInfo2[3]))
                        {
                            // 別ＣＳＶファイルを処理します
                            return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        // --- ADD 2009/06/25 ------------------------------<<<<<

                        row = row + 2;

                        continue;
                    }

                    OrderLstPmDtl orderLstPmDtl = new OrderLstPmDtl();

                    orderLstPmDtl.UserName = headInfo1[0];  // 販売店様名
                    orderLstPmDtl.UserCode = headInfo1[1];  // 販売店様コード
                    orderLstPmDtl.SlipNoHead = headInfo2[0];  // 伝票番号
                    orderLstPmDtl.OrderDate = this.StringToDateTime(headInfo2[1]);  // 発注日
                    orderLstPmDtl.OrderTime = StringToInt(StringToDateTime(headInfo2[2]).ToString("HHmmss"));  // 発注時間
                    orderLstPmDtl.ItemCode = headInfo2[3];  // アイテム
                    orderLstPmDtl.Msg = headInfo2[4];  // メッセージ
                    orderLstPmDtl.LinkNo = this.StringToInt(headInfo2[5]);// ｵﾝﾗｲﾝ番号(連携番号)
                    orderLstPmDtl.OrderGoodsNo = detailInfo[0];  // 発注部品番号
                    orderLstPmDtl.ShipmGoodsNo = detailInfo[1];  // 出荷部品番号
                    orderLstPmDtl.GoodsName = detailInfo[2];  // 出荷部品名
                    orderLstPmDtl.ShipmentCnt = this.StringToDouble(detailInfo[3]);  // 引当数量
                    orderLstPmDtl.OrderRemCnt = this.StringToDouble(detailInfo[4]);  // 発注残数量

                    string retText1;
                    this.RemoveCommaPeriod(detailInfo[5], out retText1, false);
                    orderLstPmDtl.AnswerListPrice = this.StringToDouble(retText1);  // 希望小売価格

                    orderLstPmDtl.SourceShipment = detailInfo[6];  // 出荷元名
                    orderLstPmDtl.PlanDate = this.StringToDateTime(detailInfo[7]);  // お届予定日
                    orderLstPmDtl.SlipNoDtl = detailInfo[8];  // 伝票番号
                    orderLstPmDtl.Memo = detailInfo[9]; // メモ欄

                    string retText2;
                    this.RemoveCommaPeriod(detailInfo[10], out retText2, false);
                    orderLstPmDtl.AnswerSalesUnitCost = this.StringToDouble(retText2);  // 仕入れ価格

                    lstDtl.Add(orderLstPmDtl);
                }
            }
            catch
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // 注文対象の明細が存在しない場合
            if (lstDtl.Count == 0) status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            return status;
        }

        /// <summary>
        /// 回答データの更新処理
        /// </summary>
        /// <param name="list">CSV情報</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : 回答データの更新処理する。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private int DoUpdate(ref List<OrderLsthead> list, ref string msg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // 送受信制御アクセスクラス
            if (this._uoeSndRcvCtlAcs == null)
            {
                this._uoeSndRcvCtlAcs = new UoeSndRcvCtlAcs();
            }

            // ﾎﾝﾀﾞUOE Web回答データ更新メイン処理
            string message;
            status = this._uoeSndRcvCtlAcs.EpartsUoeWebOrderCtl(ref list, out message);

            // 正常場合
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (list[0].UpdRsl != 9)
                {
                    this.DataTableAddRow(list[0]);
                }
                if (list[0].UpdRsl == -1)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            // 異常場合
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                msg = message;
            }

            return status;
        }

        /// <summary>
        /// 注文一覧ＣＳＶファイルの削除処理
        /// </summary>
        /// <param name="fileInfo">CSV情報</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : 注文一覧ＣＳＶファイルを削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.06.08</br>
        /// </remarks>
        private int DeleteCSVFile(FileInfo fileInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            try
            {
                // ファイルを削除
                fileInfo.Delete();
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        # endregion 確定処理

        # region -- キャッシュ処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 発注先の算出
        /// </summary>
        /// <param name="outUOESupplierlilst">UOE発注先マスタInfo</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">ログイン拠点</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 発注先の算出処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        public int GetUOESupplier(out ArrayList outUOESupplierlilst, string enterpriseCode, string sectionCode)
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
                    if (uOESupplier.LogicalDeleteCode == 0 && uOESupplier.CommAssemblyId == "0502")
                    {
                        outUOESupplierlilst.Add(uOESupplier);
                    }
                }
            }

            return status;
        }
        # endregion

        # region -- 文字列編集処理 --
        /// <summary>
        /// カンマ・ピリオド削除処理
        /// </summary>
        /// <param name="targetText">カンマ・ピリオド削除前テキスト</param>
        /// <param name="retText">カンマ・ピリオド削除済みテキスト</param>
        /// <param name="periodDelFlg">ピリオド削除フラグ(True:カンマ・ピリオド削除  False:カンマ削除)</param>
        /// <remarks>
        /// <br>Note	   : 対象のテキストからカンマ・ピリオドを削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.06.03</br>
        /// </remarks>
        private void RemoveCommaPeriod(string targetText, out string retText, bool periodDelFlg)
        {
            retText = "";

            if (targetText == string.Empty)
            {
                return;
            }
            // セル値編集用にカンマ・ピリオド削除
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                // カンマ・ピリオド削除
                if (periodDelFlg == true)
                {
                    if ((targetText[i].ToString() == ",") || (targetText[i].ToString() == "."))
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
                // カンマのみ削除
                else
                {
                    if (targetText[i].ToString() == ",")
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
            }

            retText = targetText;
        }

        /// <summary>
        /// string -> int 処理
        /// </summary>
        /// <param name="targetText">処理対象テキスト</param>
        /// <remarks>
        /// <br>Note	   : intを返します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.06.03</br>
        /// </remarks>
        private double StringToDouble(string targetText)
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

        /// <summary>
        /// string -> double 処理
        /// </summary>
        /// <param name="targetText">処理対象テキスト</param>
        /// <remarks>
        /// <br>Note	   : intを返します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.06.03</br>
        /// </remarks>
        private int StringToInt(string targetText)
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
        /// string -> DateTime 処理
        /// </summary>
        /// <param name="targetText">処理対象テキスト</param>
        /// <remarks>
        /// <br>Note	   : DateTimeを返します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.06.03</br>
        /// </remarks>
        private DateTime StringToDateTime(string targetText)
        {
            DateTime dt = new DateTime();

            if (string.IsNullOrEmpty(targetText)) return dt;

            try
            {
                dt = Convert.ToDateTime(targetText);
            }
            catch
            {
                dt = DateTime.MinValue;
            }

            return dt;
        }
        # endregion

        # region -- DataTableの処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 処理結果
        /// </summary>
        /// <value>DetailDataTable</value>
        /// <remarks>処理結果をを取得</remarks>
        public DataTable DetailDataTable
        {
            get { return this._dataTable; }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データセットクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットクリア処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.06.08</br>
        /// </remarks>
        public void DataTableClear()
        {
            this._dataTable.Clear();
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSetの列情報を構築します。データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        private void DataTableColumnConstruction()
        {
            DataTable table = new DataTable(TABLE_ID);

            // Addを行う順番が、列の表示順位となります。
            table.Columns.Add(FILENAME, typeof(string));   // ファイル名
            table.Columns.Add(PROCESSNUM, typeof(string)); // 件数
            table.Columns.Add(RESULT, typeof(string));     // 結果

            table.Columns[FILENAME].Caption = "ファイル名";
            table.Columns[PROCESSNUM].Caption = "件数";
            table.Columns[RESULT].Caption = "結果";

            this._dataTable = table;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データセット行増加処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセット行増加処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        private void DataTableAddRow(OrderLsthead orderLsthead)
        {
            DataRow row = this._dataTable.NewRow();

            // ファイル名
            row[FILENAME] = orderLsthead.CsvName;
            // 件数
            if (orderLsthead.UpdRsl != -1)
            {
                row[PROCESSNUM] = orderLsthead.LstDtl.Count.ToString("###,##0") + "件";
            }
            else
            {
                row[PROCESSNUM] = "0件";
            }

            // 結果
            string result = string.Empty;
            // 結果コードより、表示結果の判定
            switch (orderLsthead.UpdRsl)
            {
                // 0:正常終了
                case 0:
                    {
                        result = RESULT0;
                        break;
                    }
                //  1:前回請求日算出エラー 
                case 1:
                    {
                        result = RESULT1;
                        break;
                    }
                // 2:前回準備処理以前
                case 2:
                    {
                        result = RESULT2;
                        break;
                    }
                // 3:取込済
                case 3:
                    {
                        result = RESULT3;
                        break;
                    }
                // -1:異常終了
                case -1:
                    {
                        result = RESULT4;
                        break;
                    }
                // その他
                default:
                    {
                        break;
                    }

            }
            row[RESULT] = result;

            // テーブルRowを追加
            this._dataTable.Rows.Add(row);
        }
        # endregion
    }
}
