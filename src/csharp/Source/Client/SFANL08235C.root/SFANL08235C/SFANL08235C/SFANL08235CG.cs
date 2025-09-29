using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 印字データ作成補助クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 印字データ作成補助メソッドを備えるクラスです。</br>
    /// <br>Programmer	: 22011 柏原 頼人</br>
    /// <br>Date		: 2007.08.17</br>
    /// <br>UpdateNote	: </br>
    /// </remarks>
    public class SFANL08235CG
    {
        #region public methods

        #region データ入力システム名称
        /// <summary>
        /// データ入力システムコードからデータ入力システム名称を返します
        /// </summary>
        /// <param name="dataInputSystem">データ入力システムコード</param>
        /// <returns>データ入力システム名称</returns>
        public string GetDataInputSystemName(int dataInputSystem)
        {
            switch (dataInputSystem)
            {
                case 0: { return "共通"; }
                case 1: { return "整備"; }
                case 2: { return "鈑金"; }
                case 3: { return "車販"; }
                default : return "共通";
            }
        }
        #endregion

        #region 個人・法人区分名称取得関数
        /// <summary>
        /// 個人・法人区分名称取得関数
        /// </summary>
        /// <param name="corpporateDivCode">法人区分コード</param>
        /// <returns>個人・法人区分名称</returns>
        public string GetCorpporateDivName(int corpporateDivCode)
        {
            string corpporateDivName = "";

            switch (corpporateDivCode)
            {
                case 1:
                    corpporateDivName = "法人";
                    break;
                case 2:
                    corpporateDivName = "大口法人";
                    break;
                case 3:
                    corpporateDivName = "業者";
                    break;
                case 4:
                    corpporateDivName = "社員";
                    break;
                case 5:
                    corpporateDivName = "ＡＡ";
                    break;
                default:
                    corpporateDivName = "個人";
                    break;
            }
            return corpporateDivName;
        }
        #endregion

        //#region 出力用登録番号作成関数
        ///// <summary>
        ///// 出力用登録番号作成関数
        ///// </summary>
        ///// <param name="carMngNo"></param>
        ///// <param name="numberplate1name"></param>
        ///// <param name="numberplate2"></param>
        ///// <param name="numberplate3"></param>
        ///// <param name="numberplate4"></param>
        ///// <returns>出力用登録番号</returns>
        //public string MakeNumberPlate(int carMngNo, string numberplate1name, string numberplate2, string numberplate3, int numberplate4)
        //{
        //    string numberPlate = CarInfoCalculation.GetNumberPlateString(carMngNo, 0, numberplate1name, numberplate2, numberplate3, numberplate4);
        //    return numberPlate;
        //}
        //#endregion

        #region 和暦変換処理(DataTime -> ○○XX年XX月XX日)
        /// <summary>
        /// 和暦変換処理(DataTime -> ○○XX年XX月XX日)
        /// </summary>
        /// <param name="dt">変換元DateTime</param>
        /// <returns>和暦文字列</returns>
        public string DateTimeToJpFormal(DateTime dt)
        {
            string dateTimes = TDateTime.DateTimeToString("GGyymmdd", dt);
            return dateTimes;
        }
        #endregion]

        #region 受注ステータス取得
        /// <summary>
        /// 受注ステータス取得
        /// </summary>
        /// <param name="AcptAnOdrStatusCd">受注ステータス</param>
        /// <returns>受注ステータス名称</returns>
        public string GetAcptAnOdrStatusName(int AcptAnOdrStatusCd)
        {
            switch (AcptAnOdrStatusCd)
            {
                case 10 : return "見積";
                case 20 : return "指示";
                case 30 : return "納品";
                default: return "";
            }
        }
        #endregion

        #region 車検一般区分名称取得
        /// <summary>
        /// 車検一般区分名称を取得します
        /// </summary>
        /// <param name="carInspectOrGeCd">車検一般区分コード(0:一般,1:車検,2:法定)</param>
        /// <returns>車検一般区分名称</returns>
        public string GetCarInspectOrGeNm(int carInspectOrGeCd)
        {
            switch (carInspectOrGeCd)
            {
                case 0: return "一般";
                case 1: return "車検";
                case 2: return "法定";
                default: return "";
            }
        }
        #endregion

        #region 納整加修ステータス名称
        /// <summary>
        /// 納整加修ステータス名称を返します。
        /// </summary>
        /// <param name="carDeliRepairStatus">納整加修ステータス</param>
        /// <returns>納整加修ステータス名称</returns>
        public string GetCarDeliRepairStatusName(int carDeliRepairStatus)
        {
            switch (carDeliRepairStatus)
            {
                //0:無し,10:見積,20:受注,30:精算
                case 10: return "見積";
                case 20: return "受注";
                case 30: return "精算";
                default: return "";
            }
        }
        #endregion

        #region 在庫加修区分名称
        /// <summary>
        /// 在庫加修区分名称を返します。
        /// </summary>
        /// <param name="stockRepairCd">在庫加修区分</param>
        /// <returns>在庫加修区分名称</returns>
        public string GetStockRepairCdName(int stockRepairCd)
        {
            switch (stockRepairCd)
            {
                //0:通常,1:在庫加修
                case 0: return "通常";
                case 1: return "在庫加修";
                default: return "";
            }
        }
        #endregion

        #region 関連会社区分名称
        /// <summary>
        /// 関連会社区分名称を返します。
        /// </summary>
        /// <param name="relevanceCompanyCd">関連会社区分</param>
        /// <returns>関連会社区分名称</returns>
        public string GetRelevanceCompanyCdName(int relevanceCompanyCd)
        {
            switch (relevanceCompanyCd)
            {
                //0:委託元,1:関連会社
                case 0: return "委託元";
                case 1: return "関連会社";
                default: return "";
            }
        }
        #endregion

        #region 委託発注区分名称
        /// <summary>
        /// 委託発注区分名称を返します。
        /// </summary>
        /// <param name="entrustOrderCd">委託発注区分</param>
        /// <returns>委託発注区分名称</returns>
        public string GetEntrustOrderCdName(int entrustOrderCd)
        {
            switch (entrustOrderCd)
            {
                //0:未発注,1:発注済,2:仕入済
                case 0: return "未発注";
                case 1: return "発注済";
                case 2: return "仕入済";
                default: return "";
            }
        }
        #endregion

        #region 外注発注区分名称
        /// <summary>
        /// 外注発注区分名称を返します。
        /// </summary>
        /// <param name="oSrcOrderDivCd">外注発注区分</param>
        /// <returns>外注発注区分名称</returns>
        public string GetOSrcOrderDivCdName(int oSrcOrderDivCd)
        {
            switch (oSrcOrderDivCd)
            {
                //0:未発注,1:発注済,2:仕入済
                case 0: return "未発注";
                case 1: return "発注済";
                case 2: return "仕入済";
                default: return "";
            }
        }
        #endregion

        #region 赤伝区分名称
        /// <summary>
        /// 赤伝区分名称を返します。
        /// </summary>
        /// <param name="debitNoteDiv">赤伝区分</param>
        /// <returns>赤伝区分名称</returns>
        public string GetDebitNoteDivName(int debitNoteDiv)
        {
            switch (debitNoteDiv)
            {
                //0:黒伝,1:赤伝
                case 0: return "黒伝";
                case 1: return "赤伝";
                default: return "";
            }
        }
        #endregion


        #region 改造車区分名称
        /// <summary>
        /// 改造車区分分名称を返します。
        /// </summary>
        /// <param name="customizeCode">改造車区分</param>
        /// <returns>改造車区分名称</returns>
        public string GetCustomizeCodeName(int customizeCode)
        {
           if(customizeCode == 1)
           {
               return "改";
           }
           else
           {
               return string.Empty;
           }
        }
        #endregion

        #region 手入力区分名称
        /// <summary>
        /// 手入力区分名称を返します。
        /// </summary>
        /// <param name="inputDivCd">手入力区分</param>
        /// <returns>手入力区分名称</returns>
        public string GetInputDivCdName(int inputDivCd)
        {
            switch (inputDivCd)
            {
                //0:顧客車両有り,1:手入力
                case 0: return "顧客車両有り";
                case 1: return "手入力";
                default: return "";
            }
        }
        #endregion

        #region 寒冷地部品抽出区分名称
        /// <summary>
        /// 寒冷地部品抽出区分名称を返します。
        /// </summary>
        /// <param name="cldDstrctPrtsExtraCd">寒冷地部品抽出区分</param>
        /// <returns>寒冷地部品抽出区分名称</returns>
        public string GetCldDstrctPrtsExtraCddName(int cldDstrctPrtsExtraCd)
        {
            switch (cldDstrctPrtsExtraCd)
            {
                //0:寒冷地部品抽出する,1:寒冷地部品抽出しない
                case 0: return "寒冷地部品抽出する";
                case 1: return "寒冷地部品抽出しない";
                default: return "";
            }
        }
        #endregion

        #region 主作業区分名称
        /// <summary>
        /// 寒冷地部品抽出区分名称を返します。
        /// </summary>
        /// <param name="mainWorkDivCode">主作業区分</param>
        /// <returns>主作業区分名称</returns>
        public string GetMainWorkDivName(int mainWorkDivCode)
        {
            switch (mainWorkDivCode)
            {
                //0:一般区分,100:車検点検,203:法定3ヶ月,206:法定6ヶ月,212:法定12ヶ月,301:新車1ヶ月,306:新車6ヶ月,500:鈑金,510:軽鈑金,
                //700:車販（中古車）,710:車販（新車）,800:物販, 1100:スケジュール点検, 1206:リース定期６ヶ月点検
                case 0: return "一般区分";
                case 100: return "車検点検";
                case 203: return "法定3ヶ月";
                case 206: return "法定6ヶ月";
                case 212: return "法定12ヶ月";
                case 301: return "新車1ヶ月";
                case 306: return "新車6ヶ月";
                case 500: return "鈑金";
                case 510: return "軽鈑金";
                case 700: return "車販（中古車）";
                case 710: return "車販（新車）";
                case 800: return "物販";
                case 1100: return "スケジュール点検";
                case 1206: return "リース定期６ヶ月点検";
                default: return "";
            }
        }
        #endregion

        #region 受託会社区分名称
        /// <summary>
        /// 受託会社区分名称を返します。
        /// </summary>
        /// <param name="trustCompanyDivCd">受託会社区分</param>
        /// <returns>受託会社区分名称</returns>
        public string GetTrustCompanyDivCdName(int trustCompanyDivCd)
        {
            switch (trustCompanyDivCd)
            {
                case 0: return "一般";
                case 1: return "受託会社";
                default: return "";
            }
        }
        #endregion

        #region 部品仕入先区分
        /// <summary>
        /// 部品仕入先区分名称を返します。
        /// </summary>
        /// <param name="partsSupplierDivCd">部品仕入先区分</param>
        /// <returns>部品仕入先区分名称</returns>
        public string GetPartsSupplierDivCdName(int partsSupplierDivCd)
        {
            switch (partsSupplierDivCd)
            {
                case 0: return "部品仕入先以外";
                case 1: return "部品仕入先";
                default: return "";
            }
        }
        #endregion

        #region 車両仕入先区分
        /// <summary>
        /// 車両仕入先区分名称を返します。
        /// </summary>
        /// <param name="carSupplierDivCd">車両仕入先区分</param>
        /// <returns>車両仕入先区分名称 </returns>
        public string GetCarSupplierDivCdName(int carSupplierDivCd)
        {
            switch (carSupplierDivCd)
            {
                case 0: return "車両仕入先以外";
                case 1: return "車両仕入先";
                default: return "";
            }
        }
        #endregion

        #region 外注仕入先区分
        /// <summary>
        /// 外注仕入先区分名称を返します。
        /// </summary>
        /// <param name="osrcSupplierDivCd">外注仕入先区分</param>
        /// <returns>外注仕入先区分名称 </returns>
        public string GetOsrcSupplierDivCdName(int osrcSupplierDivCd)
        {
            switch (osrcSupplierDivCd)
            {
                case 0: return "外注仕入先以外";
                case 1: return "外注仕入先";
                default: return "";
            }
        }
        #endregion

        #region 受託契約車両区分
        /// <summary>
        /// 受託契約車両区分名称を返します。
        /// </summary>
        /// <param name="trustContCarDivCd">受託契約車両区分</param>
        /// <returns>受託契約車両区分名称</returns>
        public string GetTrustContCarDivCdName(int trustContCarDivCd)
        {
            switch (trustContCarDivCd)
            {
                case 0: return "受託契約外";
                case 1: return "受託契約車両";
                default: return "";
            }
        }
        #endregion

        #region アジャスタ確認ステータス
        /// <summary>
        /// アジャスタ確認ステータス名称を返します。
        /// </summary>
        /// <param name="adjusterConfStatus">アジャスタ確認ステータス</param>
        /// <returns>アジャスタ確認ステータス名称</returns>
        public string GetAdjusterConfStatusName(int adjusterConfStatus)
        {
            switch (adjusterConfStatus)
            {
                //0:未確認 1:確認中 2:確認完了
                case 0: return "未確認";
                case 1: return "確認中";
                case 2: return "確認完了";
                default: return "";
            }
        }
        #endregion



    #endregion
    }
}
