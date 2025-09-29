//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : SCM売上回答履歴照会
// プログラム概要   : SCM売上回答履歴照会アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/05/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2010/04/28  修正内容 : 在庫区分表示方法修正
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Globalization;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// SCM売上回答履歴照会アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM受注データ、SCM受注明細データ履歴の取得を行う。</br>
    /// <br>Programmer : 30452 上野 俊治</br>
    /// <br>Date       : 2009.05.27</br>
    /// <br></br>
    /// <br>Update Note : 2010/04/28 對馬 大輔 </br>
    /// <br>              在庫区分表示方法修正</br>
    /// <br></br>
    public class SCMAnsHistInquiryAsc
    {
        #region ■private変数
        private static SCMAnsHistInquiryAsc _scmAnsHistInquiryAsc; // 売上回答履歴照会アクセスクラス

        private ISCMAnsHistDB _iSCMAnsHistDB; // リモートDB

        // リモート抽出結果保持用DataTable
        private SCMAcOdrDataDataSet.SCMAnsHistInquiryDataTable _scmAnsHistInquiryDataTable;

        #endregion

        #region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMAnsHistInquiryAsc()
        {
            this._iSCMAnsHistDB = (ISCMAnsHistDB)MediationSCMAnsHistDB.GetSCMAnsHistDB();

            this._scmAnsHistInquiryDataTable = new SCMAcOdrDataDataSet.SCMAnsHistInquiryDataTable();
        }

        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns>インスタンス</returns>
        public static SCMAnsHistInquiryAsc GetInstance()
        {
            if (_scmAnsHistInquiryAsc == null)
            {
                _scmAnsHistInquiryAsc = new SCMAnsHistInquiryAsc();
            }

            return _scmAnsHistInquiryAsc;
        }
        #endregion

        #region ■public プロパティ
        /// <summary>
        /// SCM売上回答履歴照会リモート抽出結果テーブル
        /// </summary>
        public SCMAcOdrDataDataSet.SCMAnsHistInquiryDataTable SCMAnsHistInquiryDataTable
        {
            get { return _scmAnsHistInquiryDataTable; }
        }

        #endregion

        #region ■publicメソッド
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="scmAnsHistInquiryInfo"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public int Search(SCMAnsHistInquiryInfo scmAnsHistInquiryInfo, out string errMsg)
        {
            // 初期化
            this._scmAnsHistInquiryDataTable.Clear();

            errMsg = string.Empty;

            // リモート抽出条件作成
            SCMAnsHistOrderWork scmAnsHistOrderWork;
            this.SetSCMAnsHistOrderWork(scmAnsHistInquiryInfo, out scmAnsHistOrderWork);

            int status;
            object retArray = new ArrayList();

            // テストデータ
            //status = this.GetTestData(out retArray, scmAnsHistOrderWork);
            
            try
            {
                status = this._iSCMAnsHistDB.Search(out retArray, scmAnsHistOrderWork, 0, ConstantManagement.LogicalMode.GetData0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                status = 1000;
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && ((ArrayList)retArray).Count != 0)
            {
                this.ExpandRetArray((ArrayList)retArray);
            }
            else if (
                (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && ((ArrayList)retArray).Count == 0)
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND
                || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                // 該当なし
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                errMsg = "検索条件に該当するデータが存在しません";
            }
            else
            {
                errMsg = "検索処理でエラーが発生しました";
            }

            return status;
        }
        #endregion

        #region ■privateメソッド

        /// <summary>
        /// リモート抽出条件作成
        /// </summary>
        /// <param name="scmInquiryOrder">UI画面データ保持クラス</param>
        /// <param name="scmInquiryOrderWork">リモート抽出条件</param>
        private void SetSCMAnsHistOrderWork(SCMAnsHistInquiryInfo scmAnsHistInquiryInfo, out SCMAnsHistOrderWork scmAnsHistOrderWork)
        {
            scmAnsHistOrderWork = new SCMAnsHistOrderWork();

            scmAnsHistOrderWork.AnswerDivCd = new int[5] { 0, 10, 20, 30, 99 }; // TODO:回答区分

            scmAnsHistOrderWork.St_InquiryDate = scmAnsHistInquiryInfo.St_InquiryDate; // 問合せ日(開始)
            scmAnsHistOrderWork.Ed_InquiryDate = scmAnsHistInquiryInfo.Ed_InquiryDate; // 問合せ日(終了)

            scmAnsHistOrderWork.InqOtherEpCd = scmAnsHistInquiryInfo.InqOtherEpCd; // 問合せ先企業コード
            // 問合せ先拠点コード
            if (scmAnsHistInquiryInfo.InqOtherSecCd == "00")
            {
                scmAnsHistOrderWork.InqOtherSecCd = string.Empty;
            }
            else
            {
                scmAnsHistOrderWork.InqOtherSecCd = scmAnsHistInquiryInfo.InqOtherSecCd;
            }

            scmAnsHistOrderWork.St_CustomerCode = scmAnsHistInquiryInfo.St_CustomerCode; // 得意先コード(開始)
            scmAnsHistOrderWork.Ed_CustomerCode = scmAnsHistInquiryInfo.Ed_CustomerCode; // 得意先コード(終了)

            scmAnsHistOrderWork.AwnserMethod = scmAnsHistInquiryInfo.AwnserMethod; // 回答方法
            scmAnsHistOrderWork.AcptAnOdrStatus = scmAnsHistInquiryInfo.AcptAnOdrStatus; // 受注ステータス
            scmAnsHistOrderWork.St_SalesSlipNum = scmAnsHistInquiryInfo.St_SalesSlipNum; // 伝票番号(開始)
            scmAnsHistOrderWork.Ed_SalesSlipNum = scmAnsHistInquiryInfo.Ed_SalesSlipNum; // 伝票番号(終了)

            scmAnsHistOrderWork.InqOrdDivCd = scmAnsHistInquiryInfo.InqOrdDivCd; // 問合せ・発注種別

            scmAnsHistOrderWork.St_InquiryNumber = scmAnsHistInquiryInfo.St_InquiryNumber; // 問合せ番号(開始)
            scmAnsHistOrderWork.Ed_InquiryNumber = scmAnsHistInquiryInfo.Ed_InquiryNumber; // 問合せ番号(終了)

            scmAnsHistOrderWork.NumberPlate4 = scmAnsHistInquiryInfo.NumberPlate4; // 車両登録番号（プレート番号）

            // 型式(フル)は曖昧検索あり
            if (scmAnsHistInquiryInfo.FullModel != null
                && scmAnsHistInquiryInfo.FullModel.Length > 0)
            {
                int fullModelSearchType = GetSearchType(scmAnsHistInquiryInfo.FullModel);

                if (fullModelSearchType == 0)
                {
                    scmAnsHistOrderWork.FullModel = scmAnsHistInquiryInfo.FullModel;
                }
                else
                {
                    // 完全一致以外は"*"を削除
                    scmAnsHistOrderWork.FullModel = scmAnsHistInquiryInfo.FullModel.Replace("*", "");
                }

                scmAnsHistOrderWork.SerchTypeModelCd = fullModelSearchType;
            }
            else
            {
                scmAnsHistOrderWork.FullModel = string.Empty;
                scmAnsHistOrderWork.SerchTypeModelCd = 0;
            }

            scmAnsHistOrderWork.CarMakerCode = scmAnsHistInquiryInfo.CarMakerCode; // メーカーコード(車両情報)
            scmAnsHistOrderWork.ModelCode = scmAnsHistInquiryInfo.ModelCode; // 車種コード
            scmAnsHistOrderWork.ModelSubCode = scmAnsHistInquiryInfo.ModelSubCode; // 車種サブコード
            scmAnsHistOrderWork.GoodsMakerCd = scmAnsHistInquiryInfo.DetailMakerCode; // メーカーコード
            scmAnsHistOrderWork.BLGoodsCode = scmAnsHistInquiryInfo.BLGoodsCode; // BL商品コード

            // 品番は曖昧検索あり
            if (scmAnsHistInquiryInfo.GoodsNo != null
                && scmAnsHistInquiryInfo.GoodsNo.Length > 0)
            {
                int goodsNoSearchType = GetSearchType(scmAnsHistInquiryInfo.GoodsNo);

                if (goodsNoSearchType == 0)
                {
                    scmAnsHistOrderWork.GoodsNo = scmAnsHistInquiryInfo.GoodsNo;
                }
                else
                {
                    // 完全一致以外は"*"を削除
                    scmAnsHistOrderWork.GoodsNo = scmAnsHistInquiryInfo.GoodsNo.Replace("*", "");
                }

                scmAnsHistOrderWork.SerchTypeGoodsNo = goodsNoSearchType;
            }
            else
            {
                scmAnsHistOrderWork.GoodsNo = string.Empty;
                scmAnsHistOrderWork.SerchTypeGoodsNo = 0;
            }

            // 純正品番は曖昧検索あり
            if (scmAnsHistInquiryInfo.PureGoodsNo != null
                && scmAnsHistInquiryInfo.PureGoodsNo.Length > 0)
            {
                int pureGoodsNoSearchType = GetSearchType(scmAnsHistInquiryInfo.PureGoodsNo);

                if (pureGoodsNoSearchType == 0)
                {
                    scmAnsHistOrderWork.PureGoodsNo = scmAnsHistInquiryInfo.PureGoodsNo;
                }
                else
                {
                    // 完全一致以外は"*"を削除
                    scmAnsHistOrderWork.PureGoodsNo = scmAnsHistInquiryInfo.PureGoodsNo.Replace("*", "");
                }

                scmAnsHistOrderWork.SerchTypePureGoodsNo = pureGoodsNoSearchType;
            }
            else
            {

                scmAnsHistOrderWork.PureGoodsNo = string.Empty;
                scmAnsHistOrderWork.SerchTypePureGoodsNo = 0;
            }

        }

        /// <summary>
        /// リモート抽出結果展開
        /// </summary>
        /// <param name="retArray"></param>
        private void ExpandRetArray(ArrayList retArray)
        {
            foreach (SCMAnsHistResultWork scmAnsHistResultWork in retArray)
            {
                // SCM売上回答履歴テーブルに展開
                this.SetSCMAnsHistInquiryDataTable(scmAnsHistResultWork);
            }

            // ソート
            this.SortSCMAnsHistInquiryDataTable();

            // ソート後に行番号を設定
            int rowNumber = 1;
            foreach (DataRow dr in this._scmAnsHistInquiryDataTable.Rows)
            {
                dr[this._scmAnsHistInquiryDataTable.RowNumberColumn.ColumnName] = rowNumber;
                rowNumber++;
            }
        }

        /// <summary>
        /// リモート抽出結果の展開処理
        /// </summary>
        /// <param name="scmInquiryResultWork"></param>
        private void SetSCMAnsHistInquiryDataTable(SCMAnsHistResultWork scmAnsHistResultWork)
        {
            DataRow row = this._scmAnsHistInquiryDataTable.NewRow();

            #region SCM受注データ
            // 拠点
            row[SCMAnsHistInquiryDataTable.InqOtherSecCdColumn.ColumnName] = scmAnsHistResultWork.InqOtherSecCd; 
            // 拠点名
            row[SCMAnsHistInquiryDataTable.InqOtherSecNmColumn.ColumnName] = scmAnsHistResultWork.SectionGuidNm; 

            // 問合せ番号
            row[SCMAnsHistInquiryDataTable.InquiryNumberColumn.ColumnName] = scmAnsHistResultWork.InquiryNumber;
            // 得意先
            row[SCMAnsHistInquiryDataTable.CustomerCodeColumn.ColumnName] = scmAnsHistResultWork.CustomerCode;
            // 得意先名
            row[SCMAnsHistInquiryDataTable.CustomerNameColumn.ColumnName] = scmAnsHistResultWork.CustomerName;     
            // 更新日時
            row[SCMAnsHistInquiryDataTable.UpdateDateColumn.ColumnName] = scmAnsHistResultWork.UpdateDate;
            row[SCMAnsHistInquiryDataTable.UpdateTimeColumn.ColumnName] = scmAnsHistResultWork.UpdateTime;
            string updateTime = Convert.ToString(scmAnsHistResultWork.UpdateTime);
            row[SCMAnsHistInquiryDataTable.UpdateDateTimeForDispColumn.ColumnName]
                = scmAnsHistResultWork.UpdateDate.ToString("yyyy/MM/dd")
                + " "
                + updateTime.PadLeft(9, '0').Substring(0, 2) + ":" // 時
                + updateTime.PadLeft(9, '0').Substring(2, 2);// +":" // 分
                //+ updateTime.PadLeft(9, '0').Substring(4, 2) + "." // 秒
                //+ updateTime.PadLeft(9, '0').Substring(6, 3); // ミリ秒

            // 回答区分
            row[SCMAnsHistInquiryDataTable.AnswerDivCdColumn.ColumnName] = scmAnsHistResultWork.AnswerDivCd;
            // 回答区分名
            row[SCMAnsHistInquiryDataTable.AnswerDivNmColumn.ColumnName] = GetAnswerDivName(scmAnsHistResultWork.AnswerDivCd);
            // 確定日
            row[SCMAnsHistInquiryDataTable.JudgementDateColumn.ColumnName] = scmAnsHistResultWork.JudgementDate;

            if (scmAnsHistResultWork.JudgementDate >= 10000000)
            {
                string JudgementDate = Convert.ToString(scmAnsHistResultWork.JudgementDate);

                row[SCMAnsHistInquiryDataTable.JudgementDateForDispColumn.ColumnName]
                    = JudgementDate.Substring(0, 4) + "/" // 年
                    + JudgementDate.Substring(4, 2) + "/" // 月
                    + JudgementDate.Substring(6, 2);  // 日
            }

            // 問合せ・発注備考
            row[SCMAnsHistInquiryDataTable.InqOrdNoteColumn.ColumnName] = scmAnsHistResultWork.InqOrdNote;
            // 問合せ従業員コード
            row[SCMAnsHistInquiryDataTable.InqEmployeeCdColumn.ColumnName] = scmAnsHistResultWork.InqEmployeeCd;
            // 問合せ従業員名称
            row[SCMAnsHistInquiryDataTable.InqEmployeeNmColumn.ColumnName] = scmAnsHistResultWork.InqEmployeeNm;
            // 回答従業員コード
            row[SCMAnsHistInquiryDataTable.AnsEmployeeCdColumn.ColumnName] = scmAnsHistResultWork.AnsEmployeeCd;
            // 回答従業員名称
            row[SCMAnsHistInquiryDataTable.AnsEmployeeNmColumn.ColumnName] = scmAnsHistResultWork.AnsEmployeeNm;
            // 問合せ日
            row[SCMAnsHistInquiryDataTable.InquiryDateColumn.ColumnName] = scmAnsHistResultWork.InquiryDate;

            if (scmAnsHistResultWork.InquiryDate != 0)
            {
                string inquiryDate = Convert.ToString(scmAnsHistResultWork.InquiryDate);

                row[SCMAnsHistInquiryDataTable.InquiryDateForDispColumn.ColumnName]
                    = inquiryDate.Substring(0, 4) + "/" // 年
                    + inquiryDate.Substring(4, 2) + "/" // 月
                    + inquiryDate.Substring(6, 2);  // 日
            }

            // 売上伝票合計（税込み）
            row[SCMAnsHistInquiryDataTable.SalesTotalTaxIncColumn.ColumnName] = scmAnsHistResultWork.SalesTotalTaxInc;
            // 売上小計（税）
            row[SCMAnsHistInquiryDataTable.SalesSubtotalTaxColumn.ColumnName] = scmAnsHistResultWork.SalesSubtotalTax;
            // 問発・回答種別
            row[SCMAnsHistInquiryDataTable.InqOrdAnsDivCdColumn.ColumnName] = scmAnsHistResultWork.InqOrdAnsDivCd;
            row[SCMAnsHistInquiryDataTable.InqOrdAnsDivNmColumn.ColumnName] = GetInqOrdAnsDivCdName(scmAnsHistResultWork.InqOrdAnsDivCd);

            // 受信日時(datetime.ticks)
            row[SCMAnsHistInquiryDataTable.ReceiveDateTimeColumn.ColumnName] = scmAnsHistResultWork.ReceiveDateTime;
            DateTime receiveDate = new DateTime(scmAnsHistResultWork.ReceiveDateTime);
            if (scmAnsHistResultWork.ReceiveDateTime != 0)
            {
                row[SCMAnsHistInquiryDataTable.ReceiveDateTimeForDispColumn.ColumnName] = receiveDate.ToString("yyyy/MM/dd HH:mm:ss");
            }
            else
            {
                row[SCMAnsHistInquiryDataTable.ReceiveDateTimeForDispColumn.ColumnName] = "";
            }
            #endregion

            #region SCM受注データ(車両情報)
            // 陸運事務所番号
            row[SCMAnsHistInquiryDataTable.NumberPlate1CodeColumn.ColumnName] = scmAnsHistResultWork.NumberPlate1Code;
            // 陸運事務局名称
            row[SCMAnsHistInquiryDataTable.NumberPlate1NameColumn.ColumnName] = scmAnsHistResultWork.NumberPlate1Name;
            // 車両登録番号(種別)
            row[SCMAnsHistInquiryDataTable.NumberPlate2Column.ColumnName] = scmAnsHistResultWork.NumberPlate2;
            // 車両登録番号(カナ)
            row[SCMAnsHistInquiryDataTable.NumberPlate3Column.ColumnName] = scmAnsHistResultWork.NumberPlate3;
            // 車両登録番号(プレート番号)
            row[SCMAnsHistInquiryDataTable.NumberPlate4Column.ColumnName] = scmAnsHistResultWork.NumberPlate4;
            // 型式指定番号
            row[SCMAnsHistInquiryDataTable.ModelDesignationNoColumn.ColumnName] = scmAnsHistResultWork.ModelDesignationNo;
            // 類別番号
            row[SCMAnsHistInquiryDataTable.CategoryNoColumn.ColumnName] = scmAnsHistResultWork.CategoryNo;
            // メーカー
            row[SCMAnsHistInquiryDataTable.MakerCodeCarColumn.ColumnName] = scmAnsHistResultWork.MakerCode;
            // メーカー名
            row[SCMAnsHistInquiryDataTable.MakerNameCarColumn.ColumnName] = scmAnsHistResultWork.CarMakerName;
            // 車種コード
            row[SCMAnsHistInquiryDataTable.ModelCodeColumn.ColumnName] = scmAnsHistResultWork.ModelCode;
            // 車種サブコード
            row[SCMAnsHistInquiryDataTable.ModelSubCodeColumn.ColumnName] = scmAnsHistResultWork.ModelSubCode;
            // 車種名
            row[SCMAnsHistInquiryDataTable.ModelNameColumn.ColumnName] = scmAnsHistResultWork.ModelName;
            // 車検証型式
            row[SCMAnsHistInquiryDataTable.CarInspectCertModelColumn.ColumnName] = scmAnsHistResultWork.CarInspectCertModel;
            // 型式(フル型)
            row[SCMAnsHistInquiryDataTable.FullModelColumn.ColumnName] = scmAnsHistResultWork.FullModel;
            // 車台番号
            row[SCMAnsHistInquiryDataTable.FrameNoColumn.ColumnName] = scmAnsHistResultWork.FrameNo;
            // 車台型式
            row[SCMAnsHistInquiryDataTable.FrameModelColumn.ColumnName] = scmAnsHistResultWork.FrameModel;
            // シャシーNo
            row[SCMAnsHistInquiryDataTable.ChassisNoColumn.ColumnName] = scmAnsHistResultWork.ChassisNo;
            // 車両固有番号
            row[SCMAnsHistInquiryDataTable.CarProperNoColumn.ColumnName] = scmAnsHistResultWork.CarProperNo;
            // 生産年式
            row[SCMAnsHistInquiryDataTable.ProduceTypeOfYearNumColumn.ColumnName] = scmAnsHistResultWork.ProduceTypeOfYearNum;
            if (scmAnsHistResultWork.ProduceTypeOfYearNum >= 100000)
            {
                string yyyymm   = scmAnsHistResultWork.ProduceTypeOfYearNum.ToString();
                string yyyy     = yyyymm.Substring(0, 4);
                string mm       = yyyymm.Substring(4, 2);
                if (int.Parse(mm) >= 1 && int.Parse(mm) <= 12)
                {
                    DateTime produceTypeOfYear = new DateTime(int.Parse(yyyy), int.Parse(mm), 1);
                    CultureInfo culture = new CultureInfo("ja-JP", true);
                    culture.DateTimeFormat.Calendar = new JapaneseCalendar();

                    row[SCMAnsHistInquiryDataTable.ProduceTypeOfYearStringColumn.ColumnName] = produceTypeOfYear.ToString("ggyy年MM月", culture);
                }
            }

            // コメント
            row[SCMAnsHistInquiryDataTable.CommentColumn.ColumnName] = scmAnsHistResultWork.Comment;
            // リペアカラーコード
            row[SCMAnsHistInquiryDataTable.RpColorCodeColumn.ColumnName] = scmAnsHistResultWork.RpColorCode;
            // カラー名称1
            row[SCMAnsHistInquiryDataTable.ColorName1Column.ColumnName] = scmAnsHistResultWork.ColorName1;
            // トリムコード
            row[SCMAnsHistInquiryDataTable.TrimCodeColumn.ColumnName] = scmAnsHistResultWork.TrimCode;
            // トリム名称
            row[SCMAnsHistInquiryDataTable.TrimNameColumn.ColumnName] = scmAnsHistResultWork.TrimName;
            // 車両走行距離
            row[SCMAnsHistInquiryDataTable.MileageColumn.ColumnName] = scmAnsHistResultWork.Mileage;
            // 装備オブジェクト
            row[SCMAnsHistInquiryDataTable.EquipObjColumn.ColumnName] = Encoding.Unicode.GetString(scmAnsHistResultWork.EquipObj);

            // 類別
            row[SCMAnsHistInquiryDataTable.ModelCategoryColumn.ColumnName] = GetModelCategoryText(scmAnsHistResultWork);

            // プレートNo
            row[SCMAnsHistInquiryDataTable.PlateNoColumn.ColumnName] = GetPlateNoText(scmAnsHistResultWork);

            #endregion

            #region SCM受注明細データ
            // 問合せ行番号
            row[SCMAnsHistInquiryDataTable.InqRowNumberColumn.ColumnName] = scmAnsHistResultWork.InqRowNumber;
            // 問合せ行番号枝番
            row[SCMAnsHistInquiryDataTable.InqRowNumDerivedNoColumn.ColumnName] = scmAnsHistResultWork.InqRowNumDerivedNo;
            // 商品種別
            row[SCMAnsHistInquiryDataTable.GoodsDivCdColumn.ColumnName] = scmAnsHistResultWork.GoodsDivCd;
            row[SCMAnsHistInquiryDataTable.GoodsDivNameColumn.ColumnName] = GetGoodsDivName(scmAnsHistResultWork.GoodsDivCd);

            // リサイクル部品種別
            row[SCMAnsHistInquiryDataTable.RecyclePrtKindCodeColumn.ColumnName] = scmAnsHistResultWork.RecyclePrtKindCode;
            // リサイクル部品種別名称
            row[SCMAnsHistInquiryDataTable.RecyclePrtKindNameColumn.ColumnName] = scmAnsHistResultWork.RecyclePrtKindName;
            // 納品区分
            row[SCMAnsHistInquiryDataTable.DeliveredGoodsDivColumn.ColumnName] = scmAnsHistResultWork.DeliveredGoodsDiv;
            row[SCMAnsHistInquiryDataTable.DeliveredGoodsDivNameColumn.ColumnName] = GetDeliveredGoodsDivName(scmAnsHistResultWork.DeliveredGoodsDiv);
            // 取扱区分
            row[SCMAnsHistInquiryDataTable.HandleDivCodeColumn.ColumnName] = scmAnsHistResultWork.HandleDivCode;
            row[SCMAnsHistInquiryDataTable.HandleDivCodeNameColumn.ColumnName] = GetHandleDivName(scmAnsHistResultWork.HandleDivCode);
            // 商品形態
            row[SCMAnsHistInquiryDataTable.GoodsShapeColumn.ColumnName] = scmAnsHistResultWork.GoodsShape;
            row[SCMAnsHistInquiryDataTable.GoodsShapeNameColumn.ColumnName] = GetGoodsShapeName(scmAnsHistResultWork.GoodsShape);
            // 納品確認区分
            row[SCMAnsHistInquiryDataTable.DelivrdGdsConfCdColumn.ColumnName] = scmAnsHistResultWork.DelivrdGdsConfCd;
            row[SCMAnsHistInquiryDataTable.DelivrdGdsConfNmColumn.ColumnName] = GetDelivrdGdsConfCdName(scmAnsHistResultWork.DelivrdGdsConfCd);
            // 納品完了予定日
            row[SCMAnsHistInquiryDataTable.DeliGdsCmpltDueDateColumn.ColumnName] = scmAnsHistResultWork.DeliGdsCmpltDueDate;
            row[SCMAnsHistInquiryDataTable.DeliGdsCmpltDueDateForDispColumn.ColumnName] = scmAnsHistResultWork.DeliGdsCmpltDueDate.ToString("yyyy/MM/dd");
            // 回答納期
            row[SCMAnsHistInquiryDataTable.AnswerDeliveryDateColumn.ColumnName] = scmAnsHistResultWork.AnswerDeliveryDate;
            // BL商品コード
            row[SCMAnsHistInquiryDataTable.BLGoodsCodeColumn.ColumnName] = scmAnsHistResultWork.BLGoodsCode;
            // BL商品コード枝番
            row[SCMAnsHistInquiryDataTable.BLGoodsDrCodeColumn.ColumnName] = scmAnsHistResultWork.BLGoodsDrCode;
            // 発注数
            row[SCMAnsHistInquiryDataTable.SalesOrderCountColumn.ColumnName] = scmAnsHistResultWork.SalesOrderCount;
            // 納品数
            row[SCMAnsHistInquiryDataTable.DeliveredGoodsCountColumn.ColumnName] = scmAnsHistResultWork.DeliveredGoodsCount;
            // 商品番号
            row[SCMAnsHistInquiryDataTable.GoodsNoColumn.ColumnName] = scmAnsHistResultWork.GoodsNo;
            // HACK:問発商品名
            // row[SCMAnsHistInquiryDataTable.InqGoodsNameColumn.ColumnName] = scmAnsHistResultWork.InqGoodsName;
            // HACK:回答商品名(カナ)
            //row[SCMAnsHistInquiryDataTable.AnsGoodsNameColumn.ColumnName] = scmAnsHistResultWork.AnsGoodsName;
            // メーカー
            row[SCMAnsHistInquiryDataTable.GoodsMakerCdColumn.ColumnName] = scmAnsHistResultWork.GoodsMakerCd;
            // メーカー名
            row[SCMAnsHistInquiryDataTable.GoodsMakerNmColumn.ColumnName] = scmAnsHistResultWork.MakerName;
            // 純正商品メーカー
            row[SCMAnsHistInquiryDataTable.PureGoodsMakerCdColumn.ColumnName] = scmAnsHistResultWork.PureGoodsMakerCd;
            // 純正商品メーカー名
            row[SCMAnsHistInquiryDataTable.PureGoodsMakerNmColumn.ColumnName] = scmAnsHistResultWork.PureMakerName;
            // HACK:問発純正商品番号
            //row[SCMAnsHistInquiryDataTable.InqPureGoodsNoColumn.ColumnName] = scmAnsHistResultWork.InqPureGoodsNo;
            // HACK:問発純正商品名
            //row[SCMAnsHistInquiryDataTable.InqPureGoodsNameColumn.ColumnName] = scmAnsHistResultWork.InqPureGoodsName;
            // HACK:回答純正商品番号
            //row[SCMAnsHistInquiryDataTable.AnsPureGoodsNoColumn.ColumnName] = scmAnsHistResultWork.AnsPureGoodsNo;
            // HACK:回答純正商品名
            //row[SCMAnsHistInquiryDataTable.AnsPureGoodsNameColumn.ColumnName] = scmAnsHistResultWork.AnsPureGoodsName;
            // 定価
            row[SCMAnsHistInquiryDataTable.ListPriceColumn.ColumnName] = scmAnsHistResultWork.ListPrice;
            // 単価
            row[SCMAnsHistInquiryDataTable.UnitPriceColumn.ColumnName] = scmAnsHistResultWork.UnitPrice;
            // 商品補足情報
            row[SCMAnsHistInquiryDataTable.GoodsAddInfoColumn.ColumnName] = scmAnsHistResultWork.GoodsAddInfo;
            // 粗利額
            row[SCMAnsHistInquiryDataTable.RoughRrofitColumn.ColumnName] = scmAnsHistResultWork.RoughRrofit;
            // 粗利率
            row[SCMAnsHistInquiryDataTable.RoughRateColumn.ColumnName] = scmAnsHistResultWork.RoughRate;
            // 回答期限
            row[SCMAnsHistInquiryDataTable.AnswerLimitDateColumn.ColumnName] = scmAnsHistResultWork.AnswerLimitDate;
            if (scmAnsHistResultWork.AnswerLimitDate != 0)
            {
                string answerLimitDate = Convert.ToString(scmAnsHistResultWork.AnswerLimitDate);
                row[SCMAnsHistInquiryDataTable.AnswerLimitDateForDispColumn.ColumnName]
                    = answerLimitDate.Substring(0, 4) + "/" // 年
                    + answerLimitDate.Substring(4, 2) + "/" // 月
                    + answerLimitDate.Substring(6, 2);  // 日
            }
            // 備考(明細)
            row[SCMAnsHistInquiryDataTable.CommentDtlColumn.ColumnName] = scmAnsHistResultWork.CommentDtl;
            // 棚番
            row[SCMAnsHistInquiryDataTable.ShelfNoColumn.ColumnName] = scmAnsHistResultWork.ShelfNo;
            // 追加区分
            row[SCMAnsHistInquiryDataTable.AdditionalDivCdColumn.ColumnName] = scmAnsHistResultWork.AdditionalDivCd;
            // 訂正区分
            row[SCMAnsHistInquiryDataTable.CorrectDivCDColumn.ColumnName] = scmAnsHistResultWork.CorrectDivCD;
            // 受注ステータス
            row[SCMAnsHistInquiryDataTable.AcptAnOdrStatusColumn.ColumnName] = scmAnsHistResultWork.AcptAnOdrStatus;
            row[SCMAnsHistInquiryDataTable.AcptAnOdrStatusNameColumn.ColumnName] = GetAcptAnOdrStatusName(scmAnsHistResultWork.AcptAnOdrStatus);
            // 売上伝票番号
            row[SCMAnsHistInquiryDataTable.SalesSlipNumColumn.ColumnName] = scmAnsHistResultWork.SalesSlipNum;
            // 売上行番号
            row[SCMAnsHistInquiryDataTable.SalesRowNoColumn.ColumnName] = scmAnsHistResultWork.SalesRowNo;
            // 問合せ・発注種別
            row[SCMAnsHistInquiryDataTable.InqOrdDivCdColumn.ColumnName] = scmAnsHistResultWork.InqOrdDivCd;
            row[SCMAnsHistInquiryDataTable.InqOrdDivNmColumn.ColumnName] = GetInqOrdDivCdName(scmAnsHistResultWork.InqOrdDivCd);
            // 回答作成区分0:自動, 1:手動（Web）, 2:手動（その他）
            row[SCMAnsHistInquiryDataTable.AnswerCreateDivColumn.ColumnName] = scmAnsHistResultWork.AnswerCreateDiv;
            row[SCMAnsHistInquiryDataTable.AnswerCreateDivNmColumn.ColumnName] = GetAnswerCreateDivName(scmAnsHistResultWork.AnswerCreateDiv);
            // 在庫区分
            row[SCMAnsHistInquiryDataTable.StockDivColumn.ColumnName] = scmAnsHistResultWork.StockDiv;
            row[SCMAnsHistInquiryDataTable.StockDivNameColumn.ColumnName] = GetStockDivName(scmAnsHistResultWork.StockDiv);
            // 表示順位
            row[SCMAnsHistInquiryDataTable.DisplayOrderColumn.ColumnName] = scmAnsHistResultWork.DisplayOrder;
            #endregion

            #region 売上明細データ
            // キャンペーンコード
            row[SCMAnsHistInquiryDataTable.CampaignCodeColumn.ColumnName] = scmAnsHistResultWork.CampaignCode;
            // キャンペーン名称
            row[SCMAnsHistInquiryDataTable.CampaignNameColumn.ColumnName] = scmAnsHistResultWork.CampaignName;
            #endregion

            this._scmAnsHistInquiryDataTable.Rows.Add(row);
        }

        /// <summary>
        /// 類別のテキストを取得します。
        /// </summary>
        /// <param name="scmAnsHistResultWork"></param>
        /// <returns>型式指定番号 + 類別番号</returns>
        private static string GetModelCategoryText(SCMAnsHistResultWork scmAnsHistResultWork)
        {
            return scmAnsHistResultWork.ModelDesignationNo.ToString("00000")
                    + "-" +
                    scmAnsHistResultWork.CategoryNo.ToString("0000");
        }

        /// <summary>
        /// プレートNoのテキストを取得します。
        /// </summary>
        /// <param name="scmAnsHistResultWork"></param>
        /// <returns>
        /// ４項目を連結して表示する
        /// ＸＸＸＸ  999  Ｘ  9999
        /// 例：札幌 300 は 3100
        /// 陸運事務所名称 + 車両登録番号（種別）+車両登録番号（カナ）車両登録番号（プレート番号）
        /// 文字間は半角スペース
        /// </returns>
        private static string GetPlateNoText(SCMAnsHistResultWork scmAnsHistResultWork)
        {
            const char DELIM = ' ';

            StringBuilder text = new StringBuilder();
            {
                text.Append(scmAnsHistResultWork.NumberPlate1Name.Trim()).Append(DELIM);
                text.Append(scmAnsHistResultWork.NumberPlate2.Trim()).Append(DELIM);
                text.Append(scmAnsHistResultWork.NumberPlate3.Trim()).Append(DELIM);
                if (scmAnsHistResultWork.NumberPlate4 != 0) text.Append(scmAnsHistResultWork.NumberPlate4.ToString("0000"));
            }
            return text.ToString().Trim().Equals("0") ? string.Empty : text.ToString();
        }

        /// <summary>
        /// キーによるソートを行う
        /// </summary>
        private void SortSCMAnsHistInquiryDataTable()
        {
            // ソート条件文字列の作成
            // 履歴も表示するので更新日時も含む
            StringBuilder sortSb = new StringBuilder();
            sortSb.Append(this._scmAnsHistInquiryDataTable.InqOtherEpCdColumn.ColumnName); // 先企業
            sortSb.Append(", ");
            sortSb.Append(this._scmAnsHistInquiryDataTable.InqOtherSecCdColumn.ColumnName); // 先拠点
            sortSb.Append(", ");
            sortSb.Append(this._scmAnsHistInquiryDataTable.CustomerCodeColumn.ColumnName);　// 得意先
            sortSb.Append(", ");
            sortSb.Append(this._scmAnsHistInquiryDataTable.InquiryNumberColumn.ColumnName); // 問合せ番号
            sortSb.Append(", ");
            sortSb.Append(this._scmAnsHistInquiryDataTable.InqRowNumberColumn.ColumnName);// 行番号
            sortSb.Append(", ");
            sortSb.Append(this._scmAnsHistInquiryDataTable.InqRowNumDerivedNoColumn.ColumnName);// 行番号枝番
            sortSb.Append(", ");
            sortSb.Append(this._scmAnsHistInquiryDataTable.InqOrdDivCdColumn.ColumnName);// 問合せ・発注種別
            sortSb.Append(", ");
            sortSb.Append(this._scmAnsHistInquiryDataTable.UpdateDateColumn.ColumnName);// 更新年月日
            sortSb.Append(", ");
            sortSb.Append(this._scmAnsHistInquiryDataTable.UpdateTimeColumn.ColumnName);// 更新時分秒ミリ秒

            DataView dv = new DataView(this._scmAnsHistInquiryDataTable.Copy());
            dv.Sort = sortSb.ToString();

            this._scmAnsHistInquiryDataTable.Clear();

            foreach (DataRowView drv in dv)
            {
                this._scmAnsHistInquiryDataTable.ImportRow(drv.Row);
            }
        }

        #region 検索タイプ取得
        /// <summary>
        /// 検索タイプ取得
        /// </summary>
        /// <param name="targetStr"></param>
        /// <returns>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</returns>
        private int GetSearchType(string targetStr)
        {
            if (targetStr.StartsWith("*") && targetStr.EndsWith("*"))
            {
                // 曖昧検索
                return 3;
            }
            else if (targetStr.StartsWith("*"))
            {
                // 後方一致検索
                return 2;
            }
            else if (targetStr.EndsWith("*"))
            {
                // 前方一致検索
                return 1;
            }
            else
            {
                // その他は完全一致検索
                return 0;
            }
        }
        #endregion

        #region 名称取得処理
        /// <summary>
        /// 回答方法の名称取得
        /// </summary>
        /// <param name="awnserMethod"></param>
        /// <returns></returns>
        private static string GetAnswerDivName(int answerDivCd)
        {
            string answerDivCdName;

            switch (answerDivCd)
            {
                case 0:
                    {
                        answerDivCdName = "未回答";
                        break;
                    }
                case 1:
                    {
                        answerDivCdName = "回答中";
                        break;
                    }
                case 10:
                    {
                        answerDivCdName = "一部回答";
                        break;
                    }
                case 20:
                    {
                        answerDivCdName = "回答完了";
                        break;
                    }
                case 30:
                    {
                        answerDivCdName = "承認";
                        break;
                    }
                case 99:
                    {
                        answerDivCdName = "キャンセル";
                        break;
                    }
                default:
                    {
                        answerDivCdName = string.Empty;
                        break;
                    }
            }

            return answerDivCdName;
        }

        /// <summary>
        /// 問発・回答種別の名称取得
        /// </summary>
        /// <param name="inqOrdAnsDivCd"></param>
        /// <returns></returns>
        private static string GetInqOrdAnsDivCdName(int inqOrdAnsDivCd)
        {
            string inqOrdAnsDivCdName;

            switch (inqOrdAnsDivCd)
            {
                case 1:
                    {
                        inqOrdAnsDivCdName = "問合せ・発注";
                        break;
                    }
                case 2:
                    {
                        inqOrdAnsDivCdName = "回答";
                        break;
                    }
                default:
                    {
                        inqOrdAnsDivCdName = string.Empty;
                        break;
                    }
            }

            return inqOrdAnsDivCdName;
        }

        /// <summary>
        /// 商品種別の名称取得
        /// </summary>
        /// <param name="goodsDivCd"></param>
        /// <returns></returns>
        private static string GetGoodsDivName(int goodsDivCd)
        {
            string goodsDivName;

            switch (goodsDivCd)
            {
                case 0:
                    {
                        goodsDivName = "純正部品";
                        break;
                    }
                case 1:
                    {
                        goodsDivName = "優良部品";
                        break;
                    }
                case 2:
                    {
                        goodsDivName = "リサイクル部品";
                        break;
                    }
                case 3:
                    {
                        goodsDivName = "平均相場";
                        break;
                    }
                default:
                    {
                        goodsDivName = string.Empty;
                        break;
                    }
            }

            return goodsDivName;
        }

        /// <summary>
        /// 納品区分の名称取得
        /// </summary>
        /// <param name="inqOrdAnsDivCd"></param>
        /// <returns></returns>
        private static string GetDeliveredGoodsDivName(int deliveredGoodsDiv)
        {
            string deliveredGoodsDivName;

            switch (deliveredGoodsDiv)
            {
                case 0:
                    {
                        deliveredGoodsDivName = "配送";
                        break;
                    }
                case 1:
                    {
                        deliveredGoodsDivName = "引取";
                        break;
                    }
                default:
                    {
                        deliveredGoodsDivName = string.Empty;
                        break;
                    }
            }

            return deliveredGoodsDivName;
        }

        /// <summary>
        /// 取扱区分の名称取得
        /// </summary>
        /// <param name="inqOrdAnsDivCd"></param>
        /// <returns></returns>
        private static string GetHandleDivName(int handleDivCode)
        {
            string handleDivName;

            switch (handleDivCode)
            {
                case 0:
                    {
                        handleDivName = "取扱品";
                        break;
                    }
                case 1:
                    {
                        handleDivName = "納期確認中";
                        break;
                    }
                case 2:
                    {
                        handleDivName = "未取扱品";
                        break;
                    }
                default:
                    {
                        handleDivName = string.Empty;
                        break;
                    }
            }

            return handleDivName;
        }

        /// <summary>
        /// 商品形態の名称取得
        /// </summary>
        /// <param name="inqOrdAnsDivCd"></param>
        /// <returns></returns>
        private static string GetGoodsShapeName(int goodsShape)
        {
            string goodsShapeName;

            switch (goodsShape)
            {
                case 1:
                    {
                        goodsShapeName = "部品";
                        break;
                    }
                case 2:
                    {
                        goodsShapeName = "用品";
                        break;
                    }
                default:
                    {
                        goodsShapeName = string.Empty;
                        break;
                    }
            }

            return goodsShapeName;
        }

        /// <summary>
        /// 納品確認区分の名称取得
        /// </summary>
        /// <param name="inqOrdAnsDivCd"></param>
        /// <returns></returns>
        private static string GetDelivrdGdsConfCdName(int delivrdGdsConfCd)
        {
            string delivrdGdsConfName;

            switch (delivrdGdsConfCd)
            {
                case 0:
                    {
                        delivrdGdsConfName = "未確認";
                        break;
                    }
                case 1:
                    {
                        delivrdGdsConfName = "確認";
                        break;
                    }
                default:
                    {
                        delivrdGdsConfName = string.Empty;
                        break;
                    }
            }

            return delivrdGdsConfName;
        }

        /// <summary>
        /// 回答方法の名称取得
        /// </summary>
        /// <param name="awnserMethod"></param>
        /// <returns></returns>
        private static string GetAnswerMethodName(int awnserMethod)
        {
            string answerMethodName;

            switch (awnserMethod)
            {
                case 0:
                    {
                        answerMethodName = "自動";
                        break;
                    }
                case 1:
                    {
                        answerMethodName = "手動";
                        break;
                    }
                default:
                    {
                        answerMethodName = string.Empty;
                        break;
                    }
            }

            return answerMethodName;
        }

        /// <summary>
        /// 発注種別の名称取得
        /// </summary>
        /// <param name="inqOrdDivCd"></param>
        /// <returns></returns>
        private static string GetInqOrdDivCdName(int inqOrdDivCd)
        {
            string inqOrdDivCdName;

            switch (inqOrdDivCd)
            {
                case 1:
                    {
                        inqOrdDivCdName = "見積";
                        break;
                    }
                case 2:
                    {
                        inqOrdDivCdName = "受注";
                        break;
                    }
                default:
                    {
                        inqOrdDivCdName = string.Empty;
                        break;
                    }
            }

            return inqOrdDivCdName;
        }

        /// <summary>
        /// 回答作成区分名称取得
        /// </summary>
        /// <param name="answerCreateDiv"></param>
        /// <returns>0:自動, 1:手動（Web）, 2:手動（その他）</returns>
        private static string GetAnswerCreateDivName(int answerCreateDiv)
        {
            string retString = string.Empty;

            switch (answerCreateDiv)
            {
                case 0:
                    retString = "自動";
                    break;
                case 1:
                    retString = "手動(Web)";
                    break;
                case 2:
                    retString = "手動(その他)";
                    break;
            }

            return retString;
        }

        /// <summary>
        /// 受注ステータスの名称取得
        /// </summary>
        /// <param name="inqOrdDivCd"></param>
        /// <returns></returns>
        private static string GetAcptAnOdrStatusName(int acptAnOdrStatus)
        {
            string acptAnOdrStatusName;

            switch (acptAnOdrStatus)
            {
                case 10:
                    {
                        acptAnOdrStatusName = "見積";
                        break;
                    }
                case 20:
                    {
                        acptAnOdrStatusName = "受注";
                        break;
                    }
                case 30:
                    {
                        acptAnOdrStatusName = "売上";
                        break;
                    }
                default:
                    {
                        acptAnOdrStatusName = string.Empty;
                        break;
                    }
            }

            return acptAnOdrStatusName;
        }

        /// <summary>
        /// 在庫区分名称の取得
        /// </summary>
        /// <param name="stockDiv"></param>
        /// <returns></returns>
        private static string GetStockDivName(int stockDiv)
        {
            string stockDivName;

            switch (stockDiv)
            {
                //case 0: // 2010/04/28
                case 1: // 2010/04/28
                    {
                        stockDivName = "委託在庫";
                        break;
                    }
                //case 1: // 2010/04/28
                case 2: // 2010/04/28
                    {
                        stockDivName = "得意先在庫";
                        break;
                    }
                //case 2: // 2010/04/28
                case 3: // 2010/04/28
                    {
                        stockDivName = "優先倉庫";
                        break;
                    }
                //case 3: // 2010/04/28
                case 4: // 2010/04/28
                    {
                        stockDivName = "自社在庫";
                        break;
                    }
                //case 4: // 2010/04/28
                case 0: // 2010/04/28
                    {
                        stockDivName = "非在庫";
                        break;
                    }
                default:
                    {
                        stockDivName = string.Empty;
                        break;
                    }
            }

            return stockDivName;
        }
        #endregion
        #endregion

        #region ■テストデータ
        //private int GetTestData(out object ret, SCMAnsHistOrderWork scmAnsHistOrderWork)
        //{
        //    ret = new CustomSerializeArrayList();

        //    SCMAnsHistResultWork testData1 = new SCMAnsHistResultWork();

        //    #region SCM受注データ
        //    // 拠点
        //    testData1.InqOtherSecCd = "01";
        //    // 拠点名
        //    testData1.SectionGuidNm = "テスト拠点01";

        //    // 問合せ番号
        //    testData1.InquiryNumber = 1000000000;
        //    // 得意先
        //    testData1.CustomerCode = 555;
        //    // 得意先名
        //    testData1.CustomerName = "テスト得意先555";
        //    // 更新日時
        //    testData1.UpdateDate = DateTime.Now;
        //    testData1.UpdateTime = 101100000;

        //    // 回答区分
        //    testData1.AnswerDivCd = 0;
        //    // 確定日
        //    testData1.JudgementDate = 20090605;

        //    // 問合せ・発注備考
        //    testData1.InqOrdNote = "発注備考";
        //    // 問合せ従業員コード
        //    testData1.InqEmployeeCd = "1111";
        //    // 問合せ従業員名称
        //    testData1.InqEmployeeNm = "問従1111";
        //    // 回答従業員コード
        //    testData1.AnsEmployeeCd = "2222";
        //    // 回答従業員名称
        //    testData1.AnsEmployeeNm = "回従2222";
        //    // 問合せ日
        //    testData1.InquiryDate = 20090605;

        //    // 売上伝票合計（税込み）
        //    testData1.SalesTotalTaxInc = 10500;
        //    // 売上小計（税）
        //    testData1.SalesSubtotalTax = 500;
        //    // 問発・回答種別
        //    testData1.InqOrdAnsDivCd = 1;

        //    // 受信日時
        //    testData1.ReceiveDateTime = DateTime.Now.Ticks;

        //    #endregion

        //    #region SCM受注データ(車両情報)
        //    // 陸運事務所番号
        //    testData1.NumberPlate1Code = 15;
        //    // 陸運事務局名称
        //    testData1.NumberPlate1Name = "陸運15";
        //    // 車両登録番号(種別)
        //    testData1.NumberPlate2 = "種別";
        //    // 車両登録番号(カナ)
        //    testData1.NumberPlate3 = "カナ";
        //    // 車両登録番号(プレート番号)
        //    testData1.NumberPlate4 = 1;
        //    // 型式指定番号
        //    testData1.ModelDesignationNo = 2;
        //    // 類別番号
        //    testData1.CategoryNo = 3;
        //    // メーカー
        //    testData1.MakerCode = 1;
        //    // メーカー名
        //    testData1.CarMakerName = "車両メーカー1";
        //    // 車種コード
        //    testData1.ModelCode = 1;
        //    // 車種サブコード
        //    testData1.ModelSubCode = 2;
        //    // 車種名
        //    testData1.ModelName = "シャシュ";
        //    // 車検証型式
        //    testData1.CarInspectCertModel = "車検証型式";
        //    // 型式(フル型)
        //    testData1.FullModel = "型式フル";
        //    // 車台番号
        //    testData1.FrameNo = "157";
        //    // 車台型式
        //    testData1.FrameModel = "車台157";
        //    // シャシーNo
        //    testData1.ChassisNo = "1";
        //    // 車両固有番号
        //    testData1.CarProperNo = 666;
        //    // 生産年式
        //    testData1.ProduceTypeOfYearNum = 200906;
        //    // コメント
        //    testData1.Comment = "テストコメント";
        //    // リペアカラーコード
        //    testData1.RpColorCode = "リペア";
        //    // カラー名称1
        //    testData1.ColorName1 = "フルカラー";
        //    // トリムコード
        //    testData1.TrimCode = "1";
        //    // トリム名称
        //    testData1.TrimName = "ビクトリーム";
        //    // 車両走行距離
        //    testData1.Mileage = 99999;
        //    //// 装備オブジェクト
        //    //testData1.EquipObj = System.Text.Encoding.Unicode.GetBytes("装備");

        //    #endregion

        //    #region SCM受注明細データ
        //    // 問合せ行番号
        //    testData1.InqRowNumber = 1;
        //    // 問合せ行番号枝番
        //    testData1.InqRowNumDerivedNo = 1;
        //    // 商品種別
        //    testData1.GoodsDivCd = 0; // 純正

        //    // リサイクル部品種別
        //    testData1.RecyclePrtKindCode = 1;
        //    // リサイクル部品種別名称
        //    testData1.RecyclePrtKindName = "りさいくる";
        //    // 納品区分
        //    testData1.DeliveredGoodsDiv = 0; // 配送
        //    // 取扱区分
        //    testData1.HandleDivCode = 0; // 取扱
        //    // 商品形態
        //    testData1.GoodsShape = 1; // 部品
        //    // 納品確認区分
        //    testData1.DelivrdGdsConfCd = 1; // 確認
        //    // 納品完了予定日
        //    testData1.DeliGdsCmpltDueDate = DateTime.Now;
        //    // 回答納期
        //    testData1.AnswerDeliveryDate = "回答納期乙";
        //    // BL商品コード
        //    testData1.BLGoodsCode = 1;
        //    // BL商品コード枝番
        //    testData1.BLGoodsDrCode = 0;
        //    // 発注数
        //    testData1.SalesOrderCount = 10;
        //    // 納品数
        //    testData1.DeliveredGoodsCount = 10;
        //    // 商品番号
        //    testData1.GoodsNo = "UENOTEST1";
        //    // 商品名(カナ)
        //    testData1.GoodsName = "商品カナ";
        //    // メーカー
        //    testData1.GoodsMakerCd = 2;
        //    // メーカー名
        //    testData1.MakerName = "明細メーカー";
        //    // 純正商品メーカー
        //    testData1.PureGoodsMakerCd = 99;
        //    // 純正商品メーカー名
        //    testData1.PureMakerName = "純正メーカー";
        //    // 純正商品番号
        //    testData1.PureGoodsNo = "pure1";
        //    // 純正商品名
        //    testData1.PureGoodsName = "純正品名";
        //    // 定価
        //    testData1.ListPrice = 10000;
        //    // 単価
        //    testData1.UnitPrice = 10000;
        //    // 商品補足情報
        //    testData1.GoodsAddInfo = "ほそく";
        //    // 粗利額
        //    testData1.RoughRrofit = 22;
        //    // 粗利率
        //    testData1.RoughRate = 12.95;
        //    // 回答期限
        //    testData1.AnswerLimitDate = 20091010;

        //    // 備考(明細)
        //    testData1.CommentDtl = "備考明細";
        //    // 棚番
        //    testData1.ShelfNo = "棚番1";
        //    // 追加区分
        //    testData1.AdditionalDivCd = 0;
        //    // 訂正区分
        //    testData1.CorrectDivCD = 0;
        //    // 受注ステータス
        //    testData1.AcptAnOdrStatus = 10; // 見積
        //    // 売上伝票番号
        //    testData1.SalesSlipNum = "00000001";
        //    // 売上行番号
        //    testData1.SalesRowNo = 1;
        //    // 問合せ・発注種別
        //    testData1.InqOrdDivCd = 1; // 見積
        //    // 在庫区分
        //    testData1.StockDiv = 0;
        //    // 表示順位
        //    testData1.DisplayOrder = 1;
        //    #endregion

        //    #region 売上明細データ
        //    // キャンペーンコード
        //    testData1.CampaignCode = 33;
        //    // キャンペーン名称
        //    testData1.CampaignName = "キャンぺ名称";
        //    //// キャンペーン売価額
        //    //testData1.DisplayOrder;
        //    //// キャンペーン売価率
        //    //testData1.ra;
        //    #endregion

        //    ((CustomSerializeArrayList)ret).Add(testData1);


        //    SCMAnsHistResultWork testData2 = new SCMAnsHistResultWork();

        //    #region SCM受注データ
        //    // 拠点
        //    testData2.InqOtherSecCd = "01";
        //    // 拠点名
        //    testData2.SectionGuidNm = "テスト拠点01";

        //    // 問合せ番号
        //    testData2.InquiryNumber = 100;
        //    // 得意先
        //    testData2.CustomerCode = 555;
        //    // 得意先名
        //    testData2.CustomerName = "テスト得意先555";
        //    // 更新日時
        //    testData2.UpdateDate = DateTime.Now;
        //    testData2.UpdateTime = 101100000;

        //    // 回答区分
        //    testData2.AnswerDivCd = 0;
        //    // 確定日
        //    testData2.JudgementDate = 20090605;

        //    // 問合せ・発注備考
        //    testData2.InqOrdNote = "発注備考";
        //    // 問合せ従業員コード
        //    testData2.InqEmployeeCd = "1111";
        //    // 問合せ従業員名称
        //    testData2.InqEmployeeNm = "問従1111";
        //    // 回答従業員コード
        //    testData2.AnsEmployeeCd = "2222";
        //    // 回答従業員名称
        //    testData2.AnsEmployeeNm = "回従2222";
        //    // 問合せ日
        //    testData2.InquiryDate = 20090605;

        //    // 売上伝票合計（税込み）
        //    testData2.SalesTotalTaxInc = 10500;
        //    // 売上小計（税）
        //    testData2.SalesSubtotalTax = 500;
        //    // 問発・回答種別
        //    testData2.InqOrdAnsDivCd = 1;

        //    // 受信日時
        //    testData2.ReceiveDateTime = DateTime.Now.Ticks;

        //    #endregion

        //    #region SCM受注データ(車両情報)
        //    // 陸運事務所番号
        //    testData2.NumberPlate1Code = 15;
        //    // 陸運事務局名称
        //    testData2.NumberPlate1Name = "陸運15";
        //    // 車両登録番号(種別)
        //    testData2.NumberPlate2 = "種別";
        //    // 車両登録番号(カナ)
        //    testData2.NumberPlate3 = "カナ";
        //    // 車両登録番号(プレート番号)
        //    testData2.NumberPlate4 = 1;
        //    // 型式指定番号
        //    testData2.ModelDesignationNo = 2;
        //    // 類別番号
        //    testData2.CategoryNo = 3;
        //    // メーカー
        //    testData2.MakerCode = 1;
        //    // メーカー名
        //    testData2.CarMakerName = "車両メーカー1";
        //    // 車種コード
        //    testData2.ModelCode = 1;
        //    // 車種サブコード
        //    testData2.ModelSubCode = 2;
        //    // 車種名
        //    testData2.ModelName = "シャシュ";
        //    // 車検証型式
        //    testData2.CarInspectCertModel = "車検証型式";
        //    // 型式(フル型)
        //    testData2.FullModel = "型式フル";
        //    // 車台番号
        //    testData2.FrameNo = "157";
        //    // 車台型式
        //    testData2.FrameModel = "車台157";
        //    // シャシーNo
        //    testData2.ChassisNo = "1";
        //    // 車両固有番号
        //    testData2.CarProperNo = 666;
        //    // 生産年式
        //    testData2.ProduceTypeOfYearNum = 200906;
        //    // コメント
        //    testData2.Comment = "テストコメント";
        //    // リペアカラーコード
        //    testData2.RpColorCode = "リペア";
        //    // カラー名称1
        //    testData2.ColorName1 = "フルカラー";
        //    // トリムコード
        //    testData2.TrimCode = "1";
        //    // トリム名称
        //    testData2.TrimName = "ビクトリーム";
        //    // 車両走行距離
        //    testData2.Mileage = 99999;
        //    //// 装備オブジェクト
        //    //testData2.EquipObj = System.Text.Encoding.Unicode.GetBytes("そもそも文字型なのか");

        //    #endregion

        //    #region SCM受注明細データ
        //    // 問合せ行番号
        //    testData2.InqRowNumber = 1;
        //    // 問合せ行番号枝番
        //    testData2.InqRowNumDerivedNo = 1;
        //    // 商品種別
        //    testData2.GoodsDivCd = 0; // 純正

        //    // リサイクル部品種別
        //    testData2.RecyclePrtKindCode = 1;
        //    // リサイクル部品種別名称
        //    testData2.RecyclePrtKindName = "りさいくる";
        //    // 納品区分
        //    testData2.DeliveredGoodsDiv = 0; // 配送
        //    // 取扱区分
        //    testData2.HandleDivCode = 0; // 取扱
        //    // 商品形態
        //    testData2.GoodsShape = 1; // 部品
        //    // 納品確認区分
        //    testData2.DelivrdGdsConfCd = 1; // 確認
        //    // 納品完了予定日
        //    testData2.DeliGdsCmpltDueDate = DateTime.Now;
        //    // 回答納期
        //    testData2.AnswerDeliveryDate = "回答納期乙";
        //    // BL商品コード
        //    testData2.BLGoodsCode = 1;
        //    // BL商品コード枝番
        //    testData2.BLGoodsDrCode = 0;
        //    // 発注数
        //    testData2.SalesOrderCount = 10;
        //    // 納品数
        //    testData2.DeliveredGoodsCount = 10;
        //    // 商品番号
        //    testData2.GoodsNo = "UENOTEST1";
        //    // 商品名(カナ)
        //    testData2.GoodsName = "商品カナ";
        //    // メーカー
        //    testData2.GoodsMakerCd = 2;
        //    // メーカー名
        //    testData2.MakerName = "明細メーカー";
        //    // 純正商品メーカー
        //    testData2.PureGoodsMakerCd = 99;
        //    // 純正商品メーカー名
        //    testData2.PureMakerName = "純正メーカー";
        //    // 純正商品番号
        //    testData2.PureGoodsNo = "pure1";
        //    // 純正商品名
        //    testData2.PureGoodsName = "純正品名";
        //    // 定価
        //    testData2.ListPrice = 10000;
        //    // 単価
        //    testData2.UnitPrice = 10000;
        //    // 商品補足情報
        //    testData2.GoodsAddInfo = "ほそく";
        //    // 粗利額
        //    testData2.RoughRrofit = 22;
        //    // 粗利率
        //    testData2.RoughRate = 12.95;
        //    // 回答期限
        //    testData2.AnswerLimitDate = 20091010;

        //    // 備考(明細)
        //    testData2.CommentDtl = "備考明細";
        //    // 棚番
        //    testData2.ShelfNo = "棚番1";
        //    // 追加区分
        //    testData2.AdditionalDivCd = 0;
        //    // 訂正区分
        //    testData2.CorrectDivCD = 0;
        //    // 受注ステータス
        //    testData2.AcptAnOdrStatus = 10; // 見積
        //    // 売上伝票番号
        //    testData2.SalesSlipNum = "00000001";
        //    // 売上行番号
        //    testData2.SalesRowNo = 1;
        //    // 問合せ・発注種別
        //    testData2.InqOrdDivCd = 1; // 見積
        //    // 在庫区分
        //    testData2.StockDiv = 0;
        //    // 表示順位
        //    testData2.DisplayOrder = 1;
        //    #endregion

        //    #region 売上明細データ
        //    // キャンペーンコード
        //    testData2.CampaignCode = 33;
        //    // キャンペーン名称
        //    testData2.CampaignName = "キャンぺ名称";
        //    //// キャンペーン売価額
        //    //testData2.DisplayOrder;
        //    //// キャンペーン売価率
        //    //testData2.ra;
        //    #endregion

        //    ((CustomSerializeArrayList)ret).Add(testData2);

        //    return 0;
        //}
        #endregion
    }
}
