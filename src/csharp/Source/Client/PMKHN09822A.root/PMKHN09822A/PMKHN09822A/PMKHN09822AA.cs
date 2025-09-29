//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタ（インポート）
// プログラム概要   : 掛率マスタ（インポート）アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  ********-** 作成担当 : FSI菅原 庸平
// 作 成 日  2013/06/12  修正内容 : サポートツール対応、新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30521 本山　貴将 
// 修 正 日  2013.10.28  修正内容 : 掛け率マスタインポート・エクスポート機能追加対応
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : K.Miura
// 修 正 日  2015/10/14   修正内容 : クラス名重複のため変更 
//                                   StockMasWork → RateTextWork
//                                   IStockMasDB → IRateTextDB
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : 黒澤　直貴
// 修 正 日  2015/10/14   修正内容 : クラス名重複のため変更 
//                                   MediationStockMasDB → MediationRateTextDB
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using System.Runtime.InteropServices;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data;
using System.Text.RegularExpressions;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 入金マスタ（インポート）アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入金マスタ（インポート）で使用するデータを取得する。</br>
    /// <br>Programmer : FSI菅原 庸平</br>
    /// <br>Date       : 2013/06/12</br>
    /// <br></br>
    /// </remarks>
    public class DepsitMainRfImportAcs
    {
        #region ■ Constructor
        /// <summary>
        /// 掛率マスタ（インポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率マスタ（インポート）アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public DepsitMainRfImportAcs()
        {
            #region Del 2013.10.28 T.MOTOYAMA
            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STA
            //// 掛率DB情報
            //this._DepsitMainAcs = MediationRateDB.GetRateDB();
            // 2013.10.28 T.MOTOYAMA DEL END ///////////////////////////////////////////////////////////////////
            #endregion
// --- CHG  2015/10/14 黒澤　直貴 --- >>>>
//          this._IStockMasDB = MediationStockMasDB.GetStockMasDB();  // Add 2013.10.28 T.MOTOYAMA
            this._IRateTextDB = MediationRateTextDB.GetRateTextDB();
// --- CHG  2015/10/14 黒澤　直貴 --- <<<<

            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        }

        /// <summary>
        /// 掛率マスタ（インポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率マスタ（インポート）アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        static DepsitMainRfImportAcs()
        {

        }
        #endregion ■ Constructor

        #region ■ Static Member
        private static PrtOutSet stc_PrtOutSet;			            // 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	            // 帳票出力設定アクセスクラス

        /// <summary>
        /// 印刷データ
        /// </summary>
        public static DataTable _printDataTable = null;

        #endregion ■ Static Member

        #region ■ Private Member

        private string _enterpriseCode;

        #region Del 2013.10.28 T.MOTOYAMA
        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STA
        //// 掛率アクセスクラス
        //private IRateDB _DepsitMainAcs;
        // 2013.10.28 T.MOTOYAMA DEL END ///////////////////////////////////////////////////////////////////
        #endregion

        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
        // 掛率マスタインポートエクスポートクラス
// --- CHG  2015/10/14 K.Miura --- >>>>
//        private IStockMasDB _IStockMasDB;
          private IRateTextDB _IRateTextDB;
// --- CHG  2015/10/14 K.Miura --- <<<<
        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

        // CSVデータの列番号と列名
        private enum CSVColumnIndex
        {

            SectionCode = 0,          // 拠点コード
            UnitRateSetDivCd = 1,     //単価掛率設定区分
            UnitPriceKind = 2,        //単価種類
            RateSettingDivide = 3,    //掛率設定区分
            RateMngGoodsCd = 4,       //掛率設定区分(商品)
            RateMngGoodsNm = 5,       //掛率設定名称(商品)
            RateMngCustCd = 6,        //掛率設定区分(得意先)
            RateMngCustNm = 7,        //掛率設定名称(得意先)
            GoodsMakerCd = 8,         //商品メーカーコード
            GoodsNo = 9,              //商品番号
            GoodsRateRank = 10,       //商品掛率ランク
            GoodsRateGrpCode = 11,    //商品掛率グループコード
            BLGroupCode = 12,         //BLグループコード
            BLGoodsCode = 13,         //BL商品コード
            CustomerCode = 14,        //得意先コード
            CustRateGrpCode = 15,     //得意先掛率グループコード
            SupplierCd = 16,          //仕入先コード
            LotCount = 17,            //ロット数
            PriceFl = 18,             //価格(浮動)
            RateVal = 19,             //掛率
            UpRate = 20,              //UP率
            GrsProfitSecureRate = 21, //粗利確保率
            UnPrcFracProcUnit = 22,   //単価端数処理単位
            UnPrcFracProcDiv = 23,    //単価端数処理区分

        }

        #endregion ■ Private Member

        #region ■ Const Member

        #endregion ■ Const Member

        #region ■ Public Method
        #region ◆ テキストの取込チェック処理
        /// <summary>
        /// テキストの取込チェック処理
        /// </summary>
        /// <param name="csvDataList">CSVファイルの内容データリスト</param>
        /// <param name="checkOKArrList">チェックOKのデータリスト</param>
        /// <param name="ReadCnt">ReadしたCSVデータの行数</param>
        /// <param name="ErrCnt">Readした結果エラーが存在したCSVデータの行数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>チェック結果：true:エラーあり;false:エラーなし</returns>
        /// <remarks>
        /// <br>Note       : テキストの取込チェック処理を行います</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        //public bool ImportCheck(object csvDataList, out List<string[]> checkOKArrList, out Int32 ReadCnt, out Int32 ErrCnt)                  // Del 2013.10.28 T.MOTOYAMA
        public bool ImportCheck(object csvDataList, out List<string[]> checkOKArrList, out Int32 ReadCnt, out Int32 ErrCnt, out string errMsg) // Add 2013.10.28 T.MOTOYAMA
        {
            // エラーフラグ
            bool errFlg = false;
            // エラー行リスト
            List<string[]> errList = new List<string[]>();
            // CSVデータ
            List<string[]> lineStrList = (List<string[]>)csvDataList;
            // DBへ取込するチェックOKのデータリスト
            checkOKArrList = new List<string[]>();

            int rowIndex = 0;
            // エラー件数初期化
            ErrCnt = 0;

            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
            // エラーメッセージ
            errMsg = String.Empty;
            ReadCnt = 0;
            // 項目行チェック用フラグ
            bool CheckImportWorkflg = false;
            // 拠点情報リスト
            ArrayList secInfoList = new ArrayList();
            // 拠点情報クラス
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
            
            // 行配列リストを繰り返し、取込チェックを行う
            for (rowIndex = 0; rowIndex <= lineStrList.Count - 1; rowIndex++)
            {
                // 1行データ
                string[] strArr = lineStrList[rowIndex];

                bool errFlgSecCode = false;
                bool errFlgDate = false;
                bool errFlgDeposit = false;

                // msg変数には1行のチェック時に発生したエラーが全て書かれる
                string msg = string.Empty;

                ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //                
                // ①データが不正かチェックする
                // 掛率データ
                RateWork depsitDataWork = new RateWork();
                int errRecord = 0;
                
                try
                {                    
                    if (rowIndex == 0)
                    {
                        // 1行目が項目行になっているかチェック
                        CheckImportWorkflg = CheckImportWork(strArr);

                        if (CheckImportWorkflg == true)
                        {
                            continue;
                        }
                    }
                    
                    // データ変換処理で失敗した場合、その行を取込対象から外す
                    depsitDataWork = CopyToDepsitDataWorkFromImportWork(strArr);
                }
                catch
                {
                    // 1行目が項目行じゃない場合
                    if (CheckImportWorkflg == false)
                        errRecord = rowIndex + 1;
                    // 1行目が項目行の場合、その行はカウントから外す
                    else
                        errRecord = rowIndex;
                    
                    errMsg = errRecord + "行目のデータが不正です。";
                    errFlg = true;
                    ErrCnt = 1;
                    return errFlg;    
                }

                // ②拠点コードが正しいかチェックする
                if (secInfoList.Count == 0)
                {
                    try
                    {
                        // 拠点データ取得
                        int status = secInfoSetAcs.Search(out secInfoList, this._enterpriseCode);
                    }
                    catch
                    {
                        errMsg = "拠点情報の取得に失敗しました。";
                        errFlg = true;
                        return errFlg;
                    }
                }
                
                // CSVの拠点コード
                string sectionCode = string.Format(strArr[(int)CSVColumnIndex.SectionCode]);

                // 拠点コードのチェックを行う
                foreach (SecInfoSet secInfoSet in secInfoList)
                {
                    if (sectionCode != "00")
                    {
                        // 同一拠点コードが存在すれば問題無し
                        if (sectionCode == secInfoSet.SectionCode.Trim())
                        {
                            errFlg = false;
                            break;
                        }
                        else
                        {
                            errFlg = true;
                        }
                    }                    
                }

                // 拠点コードが不一致の場合
                if (errFlg == true)
                {
                    // 1行目が項目行じゃない場合
                    if (CheckImportWorkflg == false)
                        errRecord = rowIndex + 1;
                    // 1行目が項目行の場合、その行はカウントから外す
                    else
                        errRecord = rowIndex;

                    // 拠点コードが存在しない場合、メッセージとして表示する
                    errMsg = "拠点コード：" + sectionCode + " は現在の企業に存在しません。" + "\r\n"
                           + errRecord + " 行目の拠点コードを確認して下さい。";                           
                    ErrCnt = 1;
                    return errFlg;
                }                                
                // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

                // 当該行にエラー項目がない場合、「DBに取込可データリスト」に置く
                if (errFlgSecCode == false &&
                    errFlgDate == false &&
                    errFlgDeposit == false)
                {
                    checkOKArrList.Add(strArr);
                }
                else
                {
                    ErrCnt++;

                    // エラー行のLength ＝ 列数 + 1
                    string[] errArr = new string[strArr.Length + 1];

                    // 行データをエラー行にコピーする
                    strArr.CopyTo(errArr, 0);

                    // エラーメッセージを最後列に置く
                    errArr[errArr.Length - 1] = msg;

                    errList.Add(errArr);
                }
            }

            // チェック終了し、エラーデータがあれば印刷データを作成する
            if (errList.Count > 0)
            {
                errFlg = true;

                PMKHN09824EA.CreatePrintDataTable(ref _printDataTable);

                foreach (string[] errStrs in errList)
                {

                    DataRow dr = _printDataTable.NewRow();
                    _printDataTable.Rows.Add(dr);

                }
            }
            
            // ReadCnt = rowIndex;       // Del 2013.10.28 T.MOTOYAMA

            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
            // 項目行が存在する場合、読み込み行からカウントを1引く
            if (CheckImportWorkflg == true)
                ReadCnt = rowIndex - 1;
            else
                ReadCnt = rowIndex;
            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

            return errFlg;
        }

        #region CSV項目行チェック
        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
        /// <summary>
        /// 一行目が項目行かチェックする
        /// </summary>
        /// <param name="csvRowData">CSVデータ1行</param>
        /// <returns>チェック結果(true:問題あり、false:問題なし)</returns>
        /// <remarks>
        /// <br>Note       : 取り込んだCSVの1行目が項目行かチェックする</br>
        /// <br>Programmer : 30521 T.MOTOYAMA</br>
        /// <br>Date       : 2013.10.28</br>
        /// </remarks>
        private bool CheckImportWork(string[] csvRowData)
        {
            bool checkflg = false;

            // 各項目行の名称が入っているか判断する(全部は見なくていいかも・・・)
            if ("拠点コード" == string.Format(csvRowData[(int)CSVColumnIndex.SectionCode]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("単価掛率設定区分" == string.Format(csvRowData[(int)CSVColumnIndex.UnitRateSetDivCd]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("単価種類" == string.Format(csvRowData[(int)CSVColumnIndex.UnitPriceKind]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("掛率設定区分" == string.Format(csvRowData[(int)CSVColumnIndex.RateSettingDivide]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("掛率設定区分(商品)" == string.Format(csvRowData[(int)CSVColumnIndex.RateMngGoodsCd]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("掛率設定区分(得意先)" == string.Format(csvRowData[(int)CSVColumnIndex.RateMngCustCd]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("掛率設定名称(得意先)" == string.Format(csvRowData[(int)CSVColumnIndex.RateMngCustNm]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("商品メーカーコード" == string.Format(csvRowData[(int)CSVColumnIndex.GoodsMakerCd]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("商品番号" == string.Format(csvRowData[(int)CSVColumnIndex.GoodsNo]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("商品掛率ランク" == string.Format(csvRowData[(int)CSVColumnIndex.GoodsRateRank]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("商品掛率グループコード" == string.Format(csvRowData[(int)CSVColumnIndex.GoodsRateGrpCode]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("掛率設定名称(商品)" == string.Format(csvRowData[(int)CSVColumnIndex.RateMngGoodsNm]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("掛率設定名称(商品)" == string.Format(csvRowData[(int)CSVColumnIndex.RateMngGoodsNm]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("BLグループコード" == string.Format(csvRowData[(int)CSVColumnIndex.BLGroupCode]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("BL商品コード" == string.Format(csvRowData[(int)CSVColumnIndex.BLGoodsCode]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("得意先コード" == string.Format(csvRowData[(int)CSVColumnIndex.CustomerCode]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("得意先掛率グループコード" == string.Format(csvRowData[(int)CSVColumnIndex.CustRateGrpCode]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("仕入先コード" == string.Format(csvRowData[(int)CSVColumnIndex.SupplierCd]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("ロット数" == string.Format(csvRowData[(int)CSVColumnIndex.LotCount]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("価格(浮動)" == string.Format(csvRowData[(int)CSVColumnIndex.PriceFl]))
            {
                checkflg = true;
                return checkflg;
            }
           
            if ("掛率" == string.Format(csvRowData[(int)CSVColumnIndex.RateVal]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("UP率" == string.Format(csvRowData[(int)CSVColumnIndex.UpRate]))
            {
                checkflg = true;
                return checkflg;
            }

            if ("粗利確保率" == string.Format(csvRowData[(int)CSVColumnIndex.GrsProfitSecureRate]))
            {
                checkflg = true;
                return checkflg;
            }

            if ("単価端数処理単位" == string.Format(csvRowData[(int)CSVColumnIndex.UnPrcFracProcUnit]))
            {
                checkflg = true;
                return checkflg;
            }

            if ("単価端数処理区分" == string.Format(csvRowData[(int)CSVColumnIndex.UnPrcFracProcDiv]))
            {
                checkflg = true;
                return checkflg;
            }

            return checkflg;
        }
        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////        
        #endregion CSV項目行チェック

        #endregion ◆ テキストの取込チェック処理

        #region ◎ 帳票出力設定取得処理
        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note        : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date        : 2013/06/12</br>
        /// <br></br>
        /// </remarks>
        public static int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = string.Empty;

            try
            {
                // データは読込済みか？
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    if (stc_PrtOutSetAcs == null)
                        stc_PrtOutSetAcs = new PrtOutSetAcs();

                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "帳票出力設定の読込に失敗しました";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #endregion ■ Public Method

        #region ■ Private Method

        #region ◎ インポート処理

        #region Del 2013.10.28 T.MOTOYAMA
        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STA
        ///// <summary>
        ///// インポート処理
        ///// </summary>
        ///// <param name="importWorkTbl">インポートワーク</param>
        ///// <param name="addCnt">追加件数</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : 掛率マスタ（インポート）処理を行う。(Uクラスからコールされる)</br>
        ///// <br>Programmer : FSI菅原 庸平</br>
        ///// <br>Date       : 2013/06/12</br>
        ///// </remarks>
        //public int Import(DepsitMainRfImportWorkTbl importWorkTbl, out Int32 addCnt, out string errMsg)
        //{
        //    return this.ImportProc(importWorkTbl, out addCnt, out errMsg);
        //}
        // 2013.10.28 T.MOTOYAMA DEL END ///////////////////////////////////////////////////////////////////
        #endregion

        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
        /// <summary>
        /// インポート処理
        /// </summary>
        /// <param name="importWorkTbl">インポートワーク</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="writestatus">更新条件　1:追加　2:更新　3:追加＋更新</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタ（インポート）処理を行う。(Uクラスからコールされる)</br>
        /// <br>Programmer : 30521 T.MOTOYAMA</br>
        /// <br>Date       : 2013.10.28</br>
        /// </remarks>
        public int Import(DepsitMainRfImportWorkTbl importWorkTbl, int writestatus, out Int32 addCnt, out Int32 errCnt, out string errMsg)
        {
            return this.ImportProc(importWorkTbl, writestatus, out addCnt, out errCnt, out errMsg);
        }
        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// インポート処理
        /// </summary>
        /// <param name="importWorkTbl">インポートワーク</param>
        /// <param name="writestatus">更新条件　1:追加　2:更新　3:追加＋更新</param>    // Add 2013.10.28 T.MOTOYAMA
        /// <param name="addCnt">追加件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 入金マスタ（インポート）処理を行う。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        // private int ImportProc(DepsitMainRfImportWorkTbl importWorkTbl, out Int32 addCnt, out string errMsg)   // Del 2013.10.28 T.MOTOYAMA
        private int ImportProc(DepsitMainRfImportWorkTbl importWorkTbl, int writestatus, out Int32 addCnt, out Int32 errCnt, out string errMsg)  // Add 2013.10.28 T.MOTOYAMA
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            addCnt = 0;
            errCnt = 0;

            if (importWorkTbl == null || importWorkTbl.CsvDataInfoList.Count == 0)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = "importWorkTblにデータがありません";
                return status;
            }

            // 掛率データ
            // このImport処理では使用しない為、空データ(0次元配列)を作る
            // ループの外で定義して使いまわす
            DepositAlwWork[] depositAlwWorkList = CopyToDepositAlwWork();

            // CSVファイル1行に対してデータ作成を行いWriteをコール
            foreach (string[] csvRowData in importWorkTbl.CsvDataInfoList)
            {
                // 掛率データ
                RateWork depsitDataWork = new RateWork();
                depsitDataWork = CopyToDepsitDataWorkFromImportWork(csvRowData);

                object rateWork = depsitDataWork;

                try
                {
                    #region Del 2013.10.28 T.MOTOYAMA
                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STR //
                    //// DBにWrite要求する
                    //status = _DepsitMainAcs.Write(ref rateWork);
                    // 2013.10.28 T.MOTOYAMA DEL END /////////////////////////////////////////////////////////////////////
                    #endregion

                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                    // DBにWrite要求する
                    status = _IRateTextDB.Write(ref rateWork, writestatus);
                    // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////                    

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        addCnt++;
                    }
                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                    else
                    {
                        errMsg = "不正データがある為、一部のデータの取込がされていません。";
                        errCnt++;
                    }
                    // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
                                        
                    #region Del 2013.10.28
                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STA
                    //else
                    //{
                    //    break;
                    //}
                    // 2013.10.28 T.MOTOYAMA DEL END ///////////////////////////////////////////////////////////////////                    
                    #endregion
                }
                catch (Exception ex)
                {
                    errMsg = ex.Message;
                    break;
                }
            }
            return status;
        }
        #endregion ◎ インポート処理

        #region ◆ データ作成変換処理
        /// <summary>
        /// インポートワーク→掛率マスタワークへコピーを行う
        /// </summary>
        /// <param name="csvRowData">CSVデータ1行</param>
        /// <returns>コピーを行ったDepsitDataWorkを返す</returns>
        /// <remarks>
        /// <br>Note       : インポートワーク→掛率マスタワークへコピーを行う</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private RateWork CopyToDepsitDataWorkFromImportWork(string[] csvRowData)
        {
            RateWork depsitDataWork = new RateWork();

            depsitDataWork.EnterpriseCode = this._enterpriseCode;                     // 企業コード

            depsitDataWork.SectionCode = string.Format(csvRowData[(int)CSVColumnIndex.SectionCode]);//拠点コード
            depsitDataWork.UnitRateSetDivCd = string.Format(csvRowData[(int)CSVColumnIndex.UnitRateSetDivCd]);//単価掛率設定区分
            depsitDataWork.UnitPriceKind = string.Format(csvRowData[(int)CSVColumnIndex.UnitPriceKind]);//単価種類
            depsitDataWork.RateSettingDivide = string.Format(csvRowData[(int)CSVColumnIndex.RateSettingDivide]);//掛率設定区分
            depsitDataWork.RateMngGoodsCd = string.Format(csvRowData[(int)CSVColumnIndex.RateMngGoodsCd]);//掛率設定区分（商品）
            depsitDataWork.RateMngGoodsNm = string.Format(csvRowData[(int)CSVColumnIndex.RateMngGoodsNm]);//掛率設定名称（商品）
            depsitDataWork.RateMngCustCd = string.Format(csvRowData[(int)CSVColumnIndex.RateMngCustCd]);//掛率設定区分（得意先）
            depsitDataWork.RateMngCustNm = string.Format(csvRowData[(int)CSVColumnIndex.RateMngCustNm]);//掛率設定名称（得意先）
            depsitDataWork.GoodsMakerCd = int.Parse(csvRowData[(int)CSVColumnIndex.GoodsMakerCd]);//商品メーカーコード
            depsitDataWork.GoodsNo = string.Format(csvRowData[(int)CSVColumnIndex.GoodsNo]);//商品番号
            depsitDataWork.GoodsRateRank = string.Format(csvRowData[(int)CSVColumnIndex.GoodsRateRank]);//商品掛率ランク
            depsitDataWork.GoodsRateGrpCode = int.Parse(csvRowData[(int)CSVColumnIndex.GoodsRateGrpCode]);//商品掛率グループコード
            depsitDataWork.BLGroupCode = int.Parse(csvRowData[(int)CSVColumnIndex.BLGroupCode]);//BLグループコード
            depsitDataWork.BLGoodsCode = int.Parse(csvRowData[(int)CSVColumnIndex.BLGoodsCode]);//BL商品コード
            depsitDataWork.CustomerCode = int.Parse(csvRowData[(int)CSVColumnIndex.CustomerCode]);//得意先コード
            depsitDataWork.CustRateGrpCode = int.Parse(csvRowData[(int)CSVColumnIndex.CustRateGrpCode]);//得意先掛率グループコード
            depsitDataWork.SupplierCd = int.Parse(csvRowData[(int)CSVColumnIndex.SupplierCd]);//仕入先コード
            depsitDataWork.LotCount = double.Parse(csvRowData[(int)CSVColumnIndex.LotCount]);//ロット数
            depsitDataWork.PriceFl = double.Parse(csvRowData[(int)CSVColumnIndex.PriceFl]);//価格（浮動）
            depsitDataWork.RateVal = double.Parse(csvRowData[(int)CSVColumnIndex.RateVal]);//掛率
            depsitDataWork.UpRate = double.Parse(csvRowData[(int)CSVColumnIndex.UpRate]);//UP率
            depsitDataWork.GrsProfitSecureRate = double.Parse(csvRowData[(int)CSVColumnIndex.GrsProfitSecureRate]);//粗利確保率
            depsitDataWork.UnPrcFracProcUnit = double.Parse(csvRowData[(int)CSVColumnIndex.UnPrcFracProcUnit]);//単価端数処理単位
            depsitDataWork.UnPrcFracProcDiv = int.Parse(csvRowData[(int)CSVColumnIndex.UnPrcFracProcDiv]);//単価端数処理区分

            return depsitDataWork;
        }

        /// <summary>
        /// DepositAlwWorkの空データ作成処理
        /// </summary>
        /// <returns>DepositAlwWorkの空データ1次元配列</returns>
        /// <remarks>
        /// <br>Note       : DepositAlwWorkの空データ作成を行う</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private DepositAlwWork[] CopyToDepositAlwWork()
        {
            // 引当のデータは使用しないので空配列を返す
            DepositAlwWork[] depositAlwWork = new DepositAlwWork[0];

            return depositAlwWork;
        }

        #endregion ◆ データ作成変換処理

        #endregion ■ Private Method

    }
}
