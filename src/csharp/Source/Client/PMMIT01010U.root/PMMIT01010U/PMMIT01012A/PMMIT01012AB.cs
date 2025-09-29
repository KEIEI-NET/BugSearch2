using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Text;
using System.Runtime.Serialization.Formatters.Binary;  // Add 2010/04/27
using System.IO;  // Add 2010/04/27

using System.Threading;  // ADD 譚洪 2014/09/01 FOR Redmine#43289

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 検索見積フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検索見積のフォームクラスです。</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2008.05.21</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.07.15 22018 鈴木 正臣 MANTIS[0013805] 車台番号の範囲チェックを一部修正(範囲:1～xなら入力:000…0を許可しない)</br>
    /// <br>2009/09/08 20056 對馬 大輔 MANTIS[0014250] TBO検索時に検索条件をパラメータとしてセットする(検索見積でTBO検索するとエラーとなる対応)</br>
    /// <br>2009/10/15 22018 鈴木 正臣 MANTIS[0014360] 見出貼付機能の修正に伴う変更。（フル型式固定番号＝ゼロを含む場合の対応）</br>
    /// <br></br>
    /// <br>Update Note: 2009/09/08②       汪千来</br>
    /// <br>             PM.NS-2-A・車輌管理</br>
    /// <br>             車輌管理機能の追加</br>
    /// <br>Update Note: 2009/10/22 張莉莉</br>
    /// <br>           : Redmine#779の対応</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/22② 呉元嘯</br>
    /// <br>             PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>             保守依頼②の追加</br>
    /// <br></br>
    /// <br>Update Note: 2009/11/05 呉元嘯</br>
    /// <br>             PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>             Redmine#1087、#1134対応</br>
    /// <br></br>
    /// <br>Update Note: 2009/11/25　21024 佐々木 健</br>
    /// <br>             販売区分コード、販売区分名称をセットするように修正(MANTIS[0014689])</br>
    /// <br></br>
    /// <br>Update Note: 2009/12/17 對馬 大輔 保守依頼③対応</br>
    /// <br>             品番検索、BLｺｰﾄﾞ検索時に売価未設定時区分を設定するように変更する</br>
    /// <br>Update Note: 2010/04/27 gaoyh</br>
    /// <br>             受注マスタ（車両）自由検索型式固定番号配列の追加対応</br>
    /// <br>Update Note: 2010/05/20 gaoyh</br>
    /// <br>             #7653 自由検索型式固定番号配列の追加対応</br>
    /// <br>Update Note: 2010/05/21 22018 鈴木正臣</br>
    /// <br>             自由検索型式固定番号の処理を修正</br>
    /// <br>Update Note: 2011/02/14 14489 施ヘイ中</br>
    /// <br>             修正呼出時の伝票複写によるエラー修正</br>
    /// <br>Update Note: 2011/02/14 yangmj</br>
    /// <br>             用品入力時の売価計算でエラー発生する件の修正</br>
    /// <br>Update Note: 2011/02/14 曹文傑</br>
    /// <br>             データ登録時の車台番号範囲セットの修正</br>
    /// <br>Update Note: 2011/03/28 曹文傑</br>
    /// <br>             Redmine #20177の対応</br>
    /// <br>Update Note: 2011/07/26 高峰</br>
    /// <br>             検索見積印刷時の不具合の対応</br>
    /// <br>Update Note: 2012/08/20 30744 湯上 千加子</br>
    /// <br>           : 2012/09/12配信 システムテスト障害No.8対応</br>
    /// <br>Update Note: 2012/09/07 脇田　靖之 </br>
    /// <br>             カラー・トリムの存在チェックを外し、マスタに存在しないコードも入力可能にするように修正</br>
    /// <br>Update Note: 2012/09/11 脇田　靖之 </br>
    /// <br>             カラー・トリムの存在チェックを外し、マスタに存在しないコードも入力可能にするように修正</br>
    /// <br>Update Note: 2012/09/12 脇田　靖之 </br>
    /// <br>             カラー・トリムの存在チェックを外し、マスタに存在しないコードも入力可能にするように修正</br>
    /// <br>Update Note: 2012/09/13 30744 湯上 千加子</br>
    /// <br>           : 2012/09/19配信 SCM障害№125対応</br>
    /// <br>           :                特記事項40桁以上カット対応</br>
    /// <br>Update Note: 2012/10/25 宮本 利明</br>
    /// <br>           : 障害対応 全て印字時に優良品修正明細に優良品の品名を印字</br>
    /// <br>Update Note: 2012/12/27 宮本 利明</br>
    /// <br>           : 障害対応 純正品名が空白の場合に優良品品名を印字</br>
    /// <br>Update Note: 2013/02/20 譚洪</br>
    /// <br>管理番号   : 10801804-00、2013/03/13配信分</br>
    /// <br>             Redmine#34434 No.1180 現在庫数が０のとき在庫数が空白で表示されるの対応</br>
    /// <br>Update Note: 2013/03/08 脇田 靖之</br>
    /// <br>             車輌情報によって月を入れなければBLコード検索できないことがある障害の修正</br>
    /// <br>Update Note: 2013/03/10 譚洪</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : redmine#34994、検索見積発行　現在庫数が０のとき在庫数が０で表示の対応</br>
    /// <br>Update Note: 2013/03/21 FSI今野 利裕</br>
    /// <br>管理番号   : 10900269-00</br>
    /// <br>             SPK車台番号文字列対応</br>   
    /// <br>Update Note: 2013/12/16 脇田 靖之</br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>           : 純正定価印字対応</br>
    /// <br>Update Note: 2014/09/01 譚洪</br>
    /// <br>管理番号   : 11070184-00　SCM障害対応 №190　RedMine#43289</br>
    /// <br>         　: SFから問合せの車輌情報・備考を売上伝票入力に表示する</br>
    /// </remarks>
    public partial class EstimateInputAcs
    {
        // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- >>>
        /// <summary>車両情報を表示用</summary>
        private const string PGID_XML = "PMMIT01010U";
        //Thread中、車両情報SOLT名
        private const string CARINFOSOLT = "CARINFOSOLT";
        private LocalDataStoreSlot carInfoSolt = null;
        // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- <<<

        // ===================================================================================== //
        // 車輌情報
        // ===================================================================================== //
        #region ●車輌情報
        /// <summary>
        /// 車輌情報存在チェック
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <returns>true:存在する false:存在しない</returns>
        public bool ExistCarInfo( int salesRowNo )
        {
            bool ret = false;

            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._salesSlip.SalesSlipNum.PadLeft(9, '0'), salesRowNo);

            if (row != null)
            {
                // 判定項目：車輌情報共通キー
                if (row.CarRelationGuid != Guid.Empty)
                {
                    //ret = ( this.GetSearchCarInfo(row.CarRelationGuid) == null );
                    ret = true;
                }
            }

            return ret;
        }

        /// <summary>
        /// 車輌情報存在チェック
        /// </summary>
        /// <returns>true:存在する false:存在しない</returns>
        public bool ExistCarInfo()
        {
            bool ret = false;

            foreach (EstimateInputDataSet.EstimateDetailRow salesDetailRow in this._estimateDetailDataTable)
            {
                // 判定項目：車輌情報共通キー
                if (salesDetailRow.CarRelationGuid != Guid.Empty)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// 車輌情報テーブル行追加
        /// </summary>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="salesRowNo">売上行番号</param>
        /// <returns>追加した車輌情報行オブジェクト</returns>
        private EstimateInputDataSet.CarInfoRow AddCarInfoRow( string salesSlipNum, int salesRowNo )
        {
            // 車輌情報共通キー生成
            Guid carRelationGuid = Guid.NewGuid();

            // 車輌情報データ行オブジェクト生成
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.NewCarInfoRow();
            this.ClearCarInfoRow(ref carInfoRow);

            // 売上明細データ行オブジェクト取得
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(salesSlipNum, salesRowNo);
            salesDetailRow.CarRelationGuid = carRelationGuid; // 車輌情報共通キーセット

            // キーセット
            carInfoRow.CarRelationGuid = carRelationGuid;
            carInfoRow.FullModelFixedNoAry = new Int32[0];
            carInfoRow.FreeSrchMdlFxdNoAry = new string[0]; // ADD 2010/04/27
            this._carInfoDataTable.AddCarInfoRow(carInfoRow);

            return carInfoRow;
        }

        /// <summary>
        /// 車両情報テーブルのクリア
        /// </summary>
        /// <param name="tempCarMngCode">車両管理番号</param>
        /// <remarks>
        /// <br>Note       : 車両情報テーブルクリアを処理します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/09/08②</br>
        /// </remarks>
        public void ClearCarInfo(string tempCarMngCode)
        {
            foreach (EstimateInputDataSet.EstimateDetailRow salesDetailRow in this._estimateDetailDataTable)
            {
                // 車両情報行オブジェクト取得
                EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(salesDetailRow.CarRelationGuid);
                if (carInfoRow == null) return;

                this.ClearCarInfoRow(ref carInfoRow);

                carInfoRow.CarMngCode = tempCarMngCode;
            }
        }

        /// <summary>
        /// 車輌情報テーブルのクリア
        /// </summary>
        /// <param name="salesRowNoList">クリア対象売上行番号リスト</param>
        public void ClearCarInfoRow( List<int> salesRowNoList )
        {
            // 指定売上行番号リストを対象としてクリア
            foreach (int salesRowNo in salesRowNoList)
            {
                this.ClearCarInfoRow(salesRowNo);
            }
        }

        /// <summary>
        /// 複写伝票用の車輌情報テーブルを生成します。
        /// </summary>
        /// <br>Update Note: 2009/09/08 汪千来 車輌管理機能対応</br>
        public void CreateSlipCopyCarInfo()
        {
            // --- UPD 2009/09/08 ---------->>>>>
            bool clearflag = false;
            if (this._estimateInputInitDataAcs.GetSalesTtlSt() != null &&
                    this._estimateInputInitDataAcs.GetSalesTtlSt().CarMngNoDispDiv == 1)
            {
                if (this._estimateInputInitDataAcs.Opt_CarMng)
                {
                    clearflag = false;
                }
                else
                {
                    clearflag = true;
                }
            }
            else
            {
                clearflag = true;
            }
            foreach (EstimateInputDataSet.CarInfoRow row in this._carInfoDataTable)
            {
                row.AcceptAnOrderNo = 0;

                if (clearflag == true)
                {
                    // 車両管理番号
                    row.CarMngNo = 0;
                    // 車両走行距離
                    row.Mileage = 0;
                    // 車輌備考
                    row.CarNote = string.Empty;
                    // 陸運事務所番号
                    row.NumberPlate1Code = 0;
                    // 陸運事務局名称
                    row.NumberPlate1Name = string.Empty;
                    // 車両登録番号（種別）
                    row.NumberPlate2 = string.Empty;
                    // 車両登録番号（カナ）
                    row.NumberPlate3 = string.Empty;
                    // 車両登録番号（プレート番号）
                    row.NumberPlate4 = 0;

                    if (this._estimateInputInitDataAcs.GetSalesTtlSt() == null ||
                        this._estimateInputInitDataAcs.GetSalesTtlSt().CarMngNoDispDiv == 0)
                    {
                        row.CarMngCode = string.Empty;
                    }
                }
            }

            // --- UPD 2009/09/08 ----------<<<<<
        }


        /// <summary>
        /// 車輌情報テーブルの受注番号をクリアします。
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        public void ClearCarInfoRowClearAcceptAnOrderNo(int salesRowNo)
        {
            // 売上明細行オブジェクト取得
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow == null) return;

            // 車輌情報行オブジェクト取得
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(salesDetailRow.CarRelationGuid);
            if (carInfoRow == null) return;

            carInfoRow.AcceptAnOrderNo = 0;
        }

        /// <summary>
        /// 車輌情報テーブルのクリア
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        public void ClearCarInfoRow(int salesRowNo)
        {
            // 売上明細行オブジェクト取得
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow == null) return;

            // 車輌情報行オブジェクト取得
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(salesDetailRow.CarRelationGuid);
            if (carInfoRow == null) return;

            this.ClearCarInfoRow(ref carInfoRow);
        }

        /// <summary>
        /// 検索車輌情報のクリア
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        public void ClearCarInfo(int salesRowNo)
        {
            // 売上明細行オブジェクト取得
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow == null) return;

            // 車輌情報行オブジェクト取得
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(salesDetailRow.CarRelationGuid);
            if (carInfoRow == null) return;

            this.ClearCarInfo(ref carInfoRow);
        }

        // ------- ADD 2011/02/14 --------- >>>>
        /// <summary>
        /// 検索車輌情報のクリア
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        public void ClearCarInfoForModelCode(int salesRowNo)
        {
            // 売上明細行オブジェクト取得
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow == null) return;

            // 車輌情報行オブジェクト取得
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(salesDetailRow.CarRelationGuid);
            if (carInfoRow == null) return;

            this.ClearCarInfoForModelCode(ref carInfoRow);
        }

        /// <summary>
        /// 生産年式のクリア
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        public void ClearCarInfoForProduceTypeOfYear(int salesRowNo)
        {
            // 売上明細行オブジェクト取得
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow == null) return;

            // 車輌情報行オブジェクト取得
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(salesDetailRow.CarRelationGuid);
            if (carInfoRow == null) return;

            this.ClearCarInfoForProduceTypeOfYear(ref carInfoRow);
        }
        // ------- ADD 2011/02/14 --------- <<<<

        /// <summary>
        /// 車輌情報テーブルのクリア
        /// </summary>
        /// <param name="carRelationGuid">車輌情報連結GUID</param>
        private void ClearCarInfoRow( Guid carRelationGuid )
        {
            // 車輌情報行オブジェクト取得
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow == null) return;

            this.ClearCarInfoRow(ref carInfoRow);
        }

        /// <summary>
        /// 車輌情報テーブルのクリア
        /// </summary>
        /// <param name="carInfoRow">売上行番号</param>
        /// <br>Update Note: 2009/09/08②       汪千来</br>
        ///	<br>		   : 車輌備考と車輌追加情報１と車輌追加情報２を追加する</br>
        public void ClearCarInfoRow( ref EstimateInputDataSet.CarInfoRow carInfoRow )
        {
            if (carInfoRow == null) return;

            //carInfoRow.CarRelationGuid = Guid.Empty;            // 車輌情報共通キー
            carInfoRow.CustomerCode = 0;                        // 得意先コード
            carInfoRow.CarMngNo = 0;                            // 車輌管理番号
            carInfoRow.CarMngCode = string.Empty;               // 車輌管理コード
            carInfoRow.NumberPlate1Code = 0;                    // 陸運事務所番号
            carInfoRow.NumberPlate1Name = string.Empty;         // 陸運事務局名称
            carInfoRow.NumberPlate2 = string.Empty;             // 車輌登録番号（種別）
            carInfoRow.NumberPlate3 = string.Empty;             // 車輌登録番号（カナ）
            carInfoRow.NumberPlate4 = 0;                        // 車輌登録番号（プレート番号）
            carInfoRow.EntryDate = DateTime.MinValue;           // 登録年月日
            // --- UPD 2009/10/22 ----->>>>>
            //carInfoRow.FirstEntryDate = DateTime.MinValue;      // 初年度
            carInfoRow.FirstEntryDate = 0;
            // --- UPD 2009/10/22 -----<<<<<
            carInfoRow.MakerCode = 0;                           // メーカーコード
            carInfoRow.MakerFullName = string.Empty;            // メーカー全角名称
            carInfoRow.ModelCode = 0;                           // 車種コード
            carInfoRow.ModelSubCode = 0;                        // 車種サブコード
            carInfoRow.ModelFullName = string.Empty;            // 車種全角名称
            carInfoRow.SystematicCode = 0;                      // 系統コード
            carInfoRow.SystematicName = string.Empty;           // 系統名称
            carInfoRow.ProduceTypeOfYearCd = 0;                 // 生産年式コード
            carInfoRow.ProduceTypeOfYearNm = string.Empty;      // 生産年式名称
            carInfoRow.StProduceTypeOfYear = DateTime.MinValue; // 開始生産年式
            carInfoRow.EdProduceTypeOfYear = DateTime.MinValue; // 終了生産年式
            carInfoRow.DoorCount = 0;                           // ドア数
            carInfoRow.BodyNameCode = 0;                        // ボディー名コード
            carInfoRow.BodyName = string.Empty;                 // ボディー名称
            carInfoRow.ExhaustGasSign = string.Empty;           // 排ガス記号
            carInfoRow.SeriesModel = string.Empty;              // シリーズ型式
            carInfoRow.CategorySignModel = string.Empty;        // 型式（類別記号）
            carInfoRow.FullModel = string.Empty;                // 型式（フル型）
            carInfoRow.ModelDesignationNo = 0;                  // 型式指定番号
            carInfoRow.CategoryNo = 0;                          // 類別番号
            carInfoRow.FrameModel = string.Empty;               // 車台型式
            carInfoRow.FrameNo = string.Empty;                  // 車台番号
            carInfoRow.SearchFrameNo = 0;                       // 車台番号（検索用）
            carInfoRow.StProduceFrameNo = 0;                    // 生産車台番号開始
            carInfoRow.EdProduceFrameNo = 0;                    // 生産車台番号終了
            carInfoRow.ModelGradeNm = string.Empty;             // 型式グレード名称
            carInfoRow.EngineModelNm = string.Empty;            // エンジン型式名称
            carInfoRow.EngineDisplaceNm = string.Empty;         // 排気量名称
            carInfoRow.EDivNm = string.Empty;                   // E区分名称
            carInfoRow.TransmissionNm = string.Empty;           // ミッション名称
            carInfoRow.ShiftNm = string.Empty;                  // シフト名称
            carInfoRow.WheelDriveMethodNm = string.Empty;       // 駆動方式名称
            carInfoRow.AddiCarSpec1 = string.Empty;             // 追加諸元1
            carInfoRow.AddiCarSpec2 = string.Empty;             // 追加諸元2
            carInfoRow.AddiCarSpec3 = string.Empty;             // 追加諸元3
            carInfoRow.AddiCarSpec4 = string.Empty;             // 追加諸元4
            carInfoRow.AddiCarSpec5 = string.Empty;             // 追加諸元5
            carInfoRow.AddiCarSpec6 = string.Empty;             // 追加諸元6
            carInfoRow.AddiCarSpecTitle1 = string.Empty;        // 追加諸元タイトル1
            carInfoRow.AddiCarSpecTitle2 = string.Empty;        // 追加諸元タイトル2
            carInfoRow.AddiCarSpecTitle3 = string.Empty;        // 追加諸元タイトル3
            carInfoRow.AddiCarSpecTitle4 = string.Empty;        // 追加諸元タイトル4
            carInfoRow.AddiCarSpecTitle5 = string.Empty;        // 追加諸元タイトル5
            carInfoRow.AddiCarSpecTitle6 = string.Empty;        // 追加諸元タイトル6
            carInfoRow.RelevanceModel = string.Empty;           // 関連型式
            carInfoRow.SubCarNmCd = 0;                          // サブ車名コード
            carInfoRow.ModelGradeSname = string.Empty;          // 型式グレード略称
            carInfoRow.BlockIllustrationCd = 0;                 // ブロックイラストコード
            carInfoRow.ThreeDIllustNo = 0;                      // 3DイラストNo
            carInfoRow.PartsDataOfferFlag = 0;                  // 部品データ提供フラグ
            carInfoRow.InspectMaturityDate = DateTime.MinValue; // 車検満期日
            carInfoRow.LTimeCiMatDate = DateTime.MinValue;      // 前回車検満期日
            carInfoRow.CarInspectYear = 0;                      // 車検期間
            carInfoRow.Mileage = 0;                             // 車輌走行距離
            carInfoRow.CarNo = string.Empty;                    // 号車
            // --- UPD 2009/09/08② ---------->>>>>
            //carInfoRow.FullModelFixedNoAry = null;              // フル型式固定番号配列
            carInfoRow.FullModelFixedNoAry = new Int32[0];        // フル型式固定番号配列
            carInfoRow.FreeSrchMdlFxdNoAry = new string[0];        // 自由検索型式固定番号配列 // ADD 2010/04/27
            // --- UPD 2009/09/08② ---------->>>>>
            carInfoRow.ProduceTypeOfYearInput = 0;              // 年式
            carInfoRow.ColorCode = string.Empty;                // カラーコード
            carInfoRow.ColorName1 = string.Empty;               // カラー名称
            carInfoRow.TrimCode = string.Empty;                 // トリムコード
            carInfoRow.TrimName = string.Empty;                 // トリム名称
            carInfoRow.AcceptAnOrderNo = 0;                     // 受注番号
            // --- ADD 2009/09/08② ---------->>>>>
            carInfoRow.CarNote = string.Empty;                     // 車輌備考
            carInfoRow.CarAddInfo1 = string.Empty;                     // 車輌追加情報１
            carInfoRow.CarAddInfo2 = string.Empty;                     // 車輌追加情報２
            // PMNS:国産/外車区分クリア
            // --- ADD 2013/03/21 ---------->>>>>
            carInfoRow.DomesticForeignCode = 0;                 // 国産/外車区分
            // --- ADD 2013/03/21 ----------<<<<<

            try
            {
                // 初期状態ではCarRelationGuidのGet時に例外発生してしまうのでCatchする。
                if (carInfoRow.CarRelationGuid != null)
                {
                    // カラー・トリム・装備の初期化
                    this.SelectColorInfo(carInfoRow.CarRelationGuid, string.Empty); // カラー情報 初期化
                    this.SelectTrimInfo(carInfoRow.CarRelationGuid, string.Empty); // トリム情報 初期化
                    this.SelectEquipInfo(carInfoRow.CarRelationGuid, new byte[0]); // 装備情報 初期化
                }
            }
            catch
            {
                carInfoRow.CarRelationGuid = Guid.Empty;
            }
            // --- ADD 2009/09/08② ---------->>>>>
        }

        /// <summary>
        /// 車輌情報テーブルのクリア
        /// </summary>
        /// <param name="carInfoRow">売上行番号</param>
        /// <br>Update Note: 2011/03/28 曹文傑</br>
        /// <br>             Redmine #20177の対応</br>
        public void ClearCarInfo(ref EstimateInputDataSet.CarInfoRow carInfoRow)
        {
            if (carInfoRow == null) return;

            //carInfoRow.CarRelationGuid = Guid.Empty;            // 車輌情報共通キー
            //carInfoRow.CustomerCode = 0;                        // 得意先コード
            // UPD 2011/02/14 --- >>>>
            //carInfoRow.CarMngNo = 0;                            // 車輌管理番号
            //carInfoRow.CarMngCode = string.Empty;               // 車輌管理コード
            carInfoRow.CarMngNo = 0;                            // 車輌管理番号
            carInfoRow.CarMngCode = string.Empty;               // 車輌管理コード
            // UPD 2011/02/14 --- <<<<
            //carInfoRow.NumberPlate1Code = 0;                    // 陸運事務所番号
            //carInfoRow.NumberPlate1Name = string.Empty;         // 陸運事務局名称
            //carInfoRow.NumberPlate2 = string.Empty;             // 車輌登録番号（種別）
            //carInfoRow.NumberPlate3 = string.Empty;             // 車輌登録番号（カナ）
            //carInfoRow.NumberPlate4 = 0;                        // 車輌登録番号（プレート番号）
            carInfoRow.EntryDate = DateTime.MinValue;           // 登録年月日
            // ---UPD 2009/10/22 ----->>>>>
            //carInfoRow.FirstEntryDate = DateTime.MinValue;      // 初年度
            carInfoRow.FirstEntryDate = 0;      // 初年度
            // ---UPD 2009/10/22 -----<<<<<
            carInfoRow.MakerCode = 0;                           // メーカーコード
            carInfoRow.MakerFullName = string.Empty;            // メーカー全角名称
            carInfoRow.ModelCode = 0;                           // 車種コード
            carInfoRow.ModelSubCode = 0;                        // 車種サブコード
            carInfoRow.ModelFullName = string.Empty;            // 車種全角名称
            //carInfoRow.SystematicCode = 0;                      // 系統コード
            //carInfoRow.SystematicName = string.Empty;           // 系統名称
            // UPD 2011/02/14 --- >>>>
            carInfoRow.ProduceTypeOfYearCd = 0;                 // 生産年式コード
            carInfoRow.ProduceTypeOfYearNm = string.Empty;      // 生産年式名称
            carInfoRow.StProduceTypeOfYear = DateTime.MinValue; // 開始生産年式
            carInfoRow.EdProduceTypeOfYear = DateTime.MinValue; // 終了生産年式
            // UPD 2011/02/14 --- <<<<
            carInfoRow.DoorCount = 0;                           // ドア数
            carInfoRow.BodyNameCode = 0;                        // ボディー名コード
            carInfoRow.BodyName = string.Empty;                 // ボディー名称
            carInfoRow.ExhaustGasSign = string.Empty;           // 排ガス記号
            carInfoRow.SeriesModel = string.Empty;              // シリーズ型式
            carInfoRow.CategorySignModel = string.Empty;        // 型式（類別記号）
            carInfoRow.FullModel = string.Empty;                // 型式（フル型）
            carInfoRow.ModelDesignationNo = 0;                  // 型式指定番号
            carInfoRow.CategoryNo = 0;                          // 類別番号
            carInfoRow.FrameModel = string.Empty;               // 車台型式
            carInfoRow.FrameNo = string.Empty;                  // 車台番号
            carInfoRow.SearchFrameNo = 0;                       // 車台番号（検索用）
            carInfoRow.StProduceFrameNo = 0;                    // 生産車台番号開始
            carInfoRow.EdProduceFrameNo = 0;                    // 生産車台番号終了
            carInfoRow.ModelGradeNm = string.Empty;             // 型式グレード名称
            carInfoRow.EngineModelNm = string.Empty;            // エンジン型式名称
            carInfoRow.EngineDisplaceNm = string.Empty;         // 排気量名称
            carInfoRow.EDivNm = string.Empty;                   // E区分名称
            carInfoRow.TransmissionNm = string.Empty;           // ミッション名称
            carInfoRow.ShiftNm = string.Empty;                  // シフト名称
            carInfoRow.WheelDriveMethodNm = string.Empty;       // 駆動方式名称
            carInfoRow.AddiCarSpec1 = string.Empty;             // 追加諸元1
            carInfoRow.AddiCarSpec2 = string.Empty;             // 追加諸元2
            carInfoRow.AddiCarSpec3 = string.Empty;             // 追加諸元3
            carInfoRow.AddiCarSpec4 = string.Empty;             // 追加諸元4
            carInfoRow.AddiCarSpec5 = string.Empty;             // 追加諸元5
            carInfoRow.AddiCarSpec6 = string.Empty;             // 追加諸元6
            carInfoRow.AddiCarSpecTitle1 = string.Empty;        // 追加諸元タイトル1
            carInfoRow.AddiCarSpecTitle2 = string.Empty;        // 追加諸元タイトル2
            carInfoRow.AddiCarSpecTitle3 = string.Empty;        // 追加諸元タイトル3
            carInfoRow.AddiCarSpecTitle4 = string.Empty;        // 追加諸元タイトル4
            carInfoRow.AddiCarSpecTitle5 = string.Empty;        // 追加諸元タイトル5
            carInfoRow.AddiCarSpecTitle6 = string.Empty;        // 追加諸元タイトル6
            carInfoRow.RelevanceModel = string.Empty;           // 関連型式
            carInfoRow.SubCarNmCd = 0;                          // サブ車名コード
            carInfoRow.ModelGradeSname = string.Empty;          // 型式グレード略称
            carInfoRow.BlockIllustrationCd = 0;                 // ブロックイラストコード
            carInfoRow.ThreeDIllustNo = 0;                      // 3DイラストNo
            carInfoRow.PartsDataOfferFlag = 0;                  // 部品データ提供フラグ
            carInfoRow.InspectMaturityDate = DateTime.MinValue; // 車検満期日
            carInfoRow.LTimeCiMatDate = DateTime.MinValue;      // 前回車検満期日
            carInfoRow.CarInspectYear = 0;                      // 車検期間
            carInfoRow.Mileage = 0;                             // 車輌走行距離
            carInfoRow.CarNo = string.Empty;                    // 号車
            // ---UPD 2011/03/28------------->>>>>
            //carInfoRow.FullModelFixedNoAry = null;              // フル型式固定番号配列
            //carInfoRow.FreeSrchMdlFxdNoAry = null;              // 自由検索型式固定番号配列 // ADD 2010/04/27
            carInfoRow.FullModelFixedNoAry = new Int32[0];        // フル型式固定番号配列
            carInfoRow.FreeSrchMdlFxdNoAry = new string[0];        // 自由検索型式固定番号配列
            // ---UPD 2011/03/28-------------<<<<<
            carInfoRow.ProduceTypeOfYearInput = 0;              // 年式
            carInfoRow.ColorCode = string.Empty;                // カラーコード
            carInfoRow.ColorName1 = string.Empty;               // カラー名称
            carInfoRow.TrimCode = string.Empty;                 // トリムコード
            carInfoRow.TrimName = string.Empty;                 // トリム名称
            carInfoRow.AcceptAnOrderNo = 0;                     // 受注番号
            // PMNS:国産/外車区分クリア
            // --- ADD 2013/03/21 ---------->>>>>
            carInfoRow.DomesticForeignCode = 0;                 // 国産/外車区分
            // --- ADD 2013/03/21 ----------<<<<<
            // ---ADD 2011/03/28------------->>>>>
            if (_carInfoDictionary.ContainsKey(carInfoRow.CarRelationGuid))
            {
                _carInfoDictionary.Remove(carInfoRow.CarRelationGuid);
            }
            // ---ADD 2011/03/28-------------<<<<<
        }

        /// <summary>
        /// 車輌情報テーブルのクリア
        /// </summary>
        /// <param name="carInfoRow">売上行番号</param>
        /// <br>Update Note: 2011/03/28 曹文傑</br>
        /// <br>             Redmine #20177の対応</br>
        public void ClearCarInfoForModelCode(ref EstimateInputDataSet.CarInfoRow carInfoRow)
        {
            if (carInfoRow == null) return;

            carInfoRow.CarMngNo = 0;                            // 車輌管理番号
            carInfoRow.CarMngCode = string.Empty;               // 車輌管理コード
            carInfoRow.EntryDate = DateTime.MinValue;           // 登録年月日
            carInfoRow.FirstEntryDate = 0;                      // 初年度
            carInfoRow.ProduceTypeOfYearCd = 0;                 // 生産年式コード
            carInfoRow.ProduceTypeOfYearNm = string.Empty;      // 生産年式名称
            carInfoRow.StProduceTypeOfYear = DateTime.MinValue; // 開始生産年式
            carInfoRow.EdProduceTypeOfYear = DateTime.MinValue; // 終了生産年式
            carInfoRow.DoorCount = 0;                           // ドア数
            carInfoRow.BodyNameCode = 0;                        // ボディー名コード
            carInfoRow.BodyName = string.Empty;                 // ボディー名称
            carInfoRow.ExhaustGasSign = string.Empty;           // 排ガス記号
            carInfoRow.SeriesModel = string.Empty;              // シリーズ型式
            carInfoRow.CategorySignModel = string.Empty;        // 型式（類別記号）
            carInfoRow.FullModel = string.Empty;                // 型式（フル型）
            carInfoRow.ModelDesignationNo = 0;                  // 型式指定番号
            carInfoRow.CategoryNo = 0;                          // 類別番号
            carInfoRow.FrameModel = string.Empty;               // 車台型式
            carInfoRow.FrameNo = string.Empty;                  // 車台番号
            carInfoRow.SearchFrameNo = 0;                       // 車台番号（検索用）
            carInfoRow.StProduceFrameNo = 0;                    // 生産車台番号開始
            carInfoRow.EdProduceFrameNo = 0;                    // 生産車台番号終了
            carInfoRow.ModelGradeNm = string.Empty;             // 型式グレード名称
            carInfoRow.EngineModelNm = string.Empty;            // エンジン型式名称
            carInfoRow.EngineDisplaceNm = string.Empty;         // 排気量名称
            carInfoRow.EDivNm = string.Empty;                   // E区分名称
            carInfoRow.TransmissionNm = string.Empty;           // ミッション名称
            carInfoRow.ShiftNm = string.Empty;                  // シフト名称
            carInfoRow.WheelDriveMethodNm = string.Empty;       // 駆動方式名称
            carInfoRow.AddiCarSpec1 = string.Empty;             // 追加諸元1
            carInfoRow.AddiCarSpec2 = string.Empty;             // 追加諸元2
            carInfoRow.AddiCarSpec3 = string.Empty;             // 追加諸元3
            carInfoRow.AddiCarSpec4 = string.Empty;             // 追加諸元4
            carInfoRow.AddiCarSpec5 = string.Empty;             // 追加諸元5
            carInfoRow.AddiCarSpec6 = string.Empty;             // 追加諸元6
            carInfoRow.AddiCarSpecTitle1 = string.Empty;        // 追加諸元タイトル1
            carInfoRow.AddiCarSpecTitle2 = string.Empty;        // 追加諸元タイトル2
            carInfoRow.AddiCarSpecTitle3 = string.Empty;        // 追加諸元タイトル3
            carInfoRow.AddiCarSpecTitle4 = string.Empty;        // 追加諸元タイトル4
            carInfoRow.AddiCarSpecTitle5 = string.Empty;        // 追加諸元タイトル5
            carInfoRow.AddiCarSpecTitle6 = string.Empty;        // 追加諸元タイトル6
            carInfoRow.RelevanceModel = string.Empty;           // 関連型式
            carInfoRow.SubCarNmCd = 0;                          // サブ車名コード
            carInfoRow.ModelGradeSname = string.Empty;          // 型式グレード略称
            carInfoRow.BlockIllustrationCd = 0;                 // ブロックイラストコード
            carInfoRow.ThreeDIllustNo = 0;                      // 3DイラストNo
            carInfoRow.PartsDataOfferFlag = 0;                  // 部品データ提供フラグ
            carInfoRow.InspectMaturityDate = DateTime.MinValue; // 車検満期日
            carInfoRow.LTimeCiMatDate = DateTime.MinValue;      // 前回車検満期日
            carInfoRow.CarInspectYear = 0;                      // 車検期間
            carInfoRow.Mileage = 0;                             // 車輌走行距離
            carInfoRow.CarNo = string.Empty;                    // 号車
            // ---UPD 2011/03/28--------------->>>>>
            //carInfoRow.FullModelFixedNoAry = null;              // フル型式固定番号配列
            //carInfoRow.FreeSrchMdlFxdNoAry = null;              // 自由検索型式固定番号配列 // ADD 2010/04/27
            carInfoRow.FullModelFixedNoAry = new Int32[0];        // フル型式固定番号配列
            carInfoRow.FreeSrchMdlFxdNoAry = new string[0];        // 自由検索型式固定番号配列
            // ---UPD 2011/03/28---------------<<<<<
            carInfoRow.ProduceTypeOfYearInput = 0;              // 年式
            carInfoRow.ColorCode = string.Empty;                // カラーコード
            carInfoRow.ColorName1 = string.Empty;               // カラー名称
            carInfoRow.TrimCode = string.Empty;                 // トリムコード
            carInfoRow.TrimName = string.Empty;                 // トリム名称
            carInfoRow.AcceptAnOrderNo = 0;                     // 受注番号
            // PMNS:国産/外車区分クリア
            // --- ADD 2013/03/21 ---------->>>>>
            carInfoRow.DomesticForeignCode = 0;                 // 国産/外車区分
            // --- ADD 2013/03/21 ----------<<<<<
            // ---ADD 2011/03/28------------->>>>>
            if (_carInfoDictionary.ContainsKey(carInfoRow.CarRelationGuid))
            {
                _carInfoDictionary.Remove(carInfoRow.CarRelationGuid);
            }
            // ---ADD 2011/03/28-------------<<<<<
        }

        /// <summary>
        /// 車輌情報テーブルの生産年式クリア
        /// </summary>
        /// <param name="carInfoRow">売上行番号</param>
        public void ClearCarInfoForProduceTypeOfYear(ref EstimateInputDataSet.CarInfoRow carInfoRow)
        {
            if (carInfoRow == null) return;

            carInfoRow.ProduceTypeOfYearInput = 0;
        }

        /// <summary>
        /// 車輌情報テーブルのカラー情報クリア
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        public void ClearCarInfoRowForColorInfo( Guid carRelationGuid )
        {
            // 車輌情報行オブジェクト取得
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow != null)
            {
                carInfoRow.ColorCode = string.Empty; // カラーコード
                carInfoRow.ColorName1 = string.Empty; // カラー名称
            }
        }

        /// <summary>
        /// 車輌情報テーブルのトリム情報クリア
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        public void ClearCarInfoRowForTrimInfo( Guid carRelationGuid )
        {
            // 車輌情報行オブジェクト取得
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow != null)
            {
                carInfoRow.TrimCode = string.Empty; // トリムコード
                carInfoRow.TrimName = string.Empty; // トリム名称
            }
        }

        /// <summary>
        /// 車輌情報テーブル行削除
        /// </summary>
        /// <param name="selectedSalesRowNoList">選択売上明細行番号リスト</param>
        public void DeleteCarInfoRow( List<int> selectedSalesRowNoList )
        {
            foreach (int salesRowNo in selectedSalesRowNoList)
            {
                // 売上明細行オブジェクト取得
                EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
                this.DeleteCarInfoRow(salesDetailRow.CarRelationGuid);
            }
        }

        /// <summary>
        /// 車輌情報テーブル行削除
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        public void DeleteCarInfoRow( Guid carRelationGuid )
        {
            // 車輌情報行オブジェクト取得
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow == null) return;
            this._carInfoDataTable.RemoveCarInfoRow(carInfoRow);
        }

        /// <summary>
        /// 対象行の車輌情報行オブジェクトを取得
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="getCarInfoMode">車輌情報取得モード</param>
        /// <returns>車輌情報行オブジェクト</returns>
        public EstimateInputDataSet.CarInfoRow GetCarInfoRow(int salesRowNo, EstimateInputAcs.GetCarInfoMode getCarInfoMode)
        {
            return this.GetCarInfoRow(null, salesRowNo, getCarInfoMode);
        }

        /// <summary>
        /// 対象行の車輌情報行オブジェクトを取得
        /// </summary>
        /// <param name="baseSalesSlip">処理元売上データオブジェクト</param>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="getCarInfoMode">車輌情報取得モード</param>
        /// <returns>車輌情報行オブジェクト</returns>
        public EstimateInputDataSet.CarInfoRow GetCarInfoRow(SalesSlip baseSalesSlip, int salesRowNo, EstimateInputAcs.GetCarInfoMode getCarInfoMode)
        {
            // 売上明細データ行オブジェクト取得
            string slipNum = this._currentSalesSlipNum;

            if (baseSalesSlip != null)
            {
                slipNum = baseSalesSlip.SalesSlipNum;
            }

            // 売上明細データ行オブジェクト取得
            //EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(slipNum, salesRowNo);
            EstimateInputDataSet.CarInfoRow carInfoRow = null;


            if (salesDetailRow != null)
            {
                // 車輌情報データ行オブジェクト取得
                carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(salesDetailRow.CarRelationGuid);

                switch (getCarInfoMode)
                {
                    //--------------------------------------------------------------------------
                    // 新規登録モード
                    //--------------------------------------------------------------------------
                    //      指定車輌情報が存在しない場合、新規行追加あり。
                    //--------------------------------------------------------------------------
                    case GetCarInfoMode.NewInsertMode:
                        if (carInfoRow == null)
                        {
                            carInfoRow = this.AddCarInfoRow(slipNum, salesRowNo);
                        }
                        break;
                    //--------------------------------------------------------------------------
                    // 既存修正モード（新規追加なし）
                    //--------------------------------------------------------------------------
                    //      指定車輌情報が存在しない場合、前回車輌情報を取得。
                    //      売上明細行オブジェクトの車輌共通キーセットなし。
                    //--------------------------------------------------------------------------
                    case GetCarInfoMode.ExistGetMode:
                        if (carInfoRow == null)
                        {
                            carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(this._beforeCarRelationGuid);
                        }
                        break;
                    //--------------------------------------------------------------------------
                    // 車輌情報変更モード(新規追加なし)
                    //--------------------------------------------------------------------------
                    //      指定車輌情報が存在しない、明細入力ありの場合、前回車輌情報を取得。
                    //      売上明細行オブジェクトの車輌共通キーセットあり。
                    //--------------------------------------------------------------------------
                    case GetCarInfoMode.CarInfoChangeMode:
                        if (carInfoRow == null)
                        {
                            if (this.ExistDetailInput(salesRowNo) == true)
                            {
                                salesDetailRow.CarRelationGuid = this._beforeCarRelationGuid;
                                carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(salesDetailRow.CarRelationGuid);
                            }
                        }
                        break;
                }
            }
            return carInfoRow;
        }

        /// <summary>
        /// 車輌情報テーブル行の型式指定番号および類別区分番号セット
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="modelDesignationNo">型式指定番号</param>
        /// <param name="categoryNo">類別区分番号</param>
        public void SettingCarInfoRowFromCategoryNoAndDesignationNo( int salesRowNo, Guid carRelationGuid, int modelDesignationNo, int categoryNo )
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, EstimateInputAcs.GetCarInfoMode.ExistGetMode);
            if (carInfoRow != null)
            {
                carInfoRow.ModelDesignationNo = modelDesignationNo; // 型式指定番号
                carInfoRow.CategoryNo = categoryNo; // 類別区分番号
            }
        }


        /// <summary>
        /// 車輌情報テーブル行の型式セット
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="fullModel">型式</param>
        public void SettingCarInfoRowFromFullModel( int salesRowNo, Guid carRelationGuid, string fullModel )
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);
            if (carInfoRow != null)
            {
                carInfoRow.FullModel = fullModel;
            }
        }

        /// <summary>
        /// 車輌情報テーブル行のエンジン型式セット
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="engineModelNm">エンジン型式</param>
        public void SettingCarInfoRowFromEngineModelNm( int salesRowNo, string engineModelNm )
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);

            if (carInfoRow != null)
            {
                carInfoRow.EngineModelNm = engineModelNm;
            }
        }

        /// <summary>
        /// 車輌情報テーブル行の年式セット
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="firstEntryDate">年式</param>
        public void SettingCarInfoRowFromFirstEntryDate( int salesRowNo, int firstEntryDate )
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);

            if (carInfoRow != null)
            {
                if (firstEntryDate != 0)
                {
                    carInfoRow.ProduceTypeOfYearInput = firstEntryDate / 100;
                }
                else
                {
                    carInfoRow.ProduceTypeOfYearInput = 0;
                }
            }
        }

        /// <summary>
        /// 車輌情報テーブル行の車台番号セット
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="frameNo">車台番号</param>
        public void SettingCarInfoRowFromFrameNo(int salesRowNo, Guid carRelationGuid, string frameNo)
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);
            if (carInfoRow != null)
            {
                carInfoRow.FrameNo = frameNo;
                // --- DEL 2013/03/21 ---------->>>>>
                //carInfoRow.SearchFrameNo = TStrConv.StrToIntDef(frameNo.Trim(), 0);
                // --- DEL 2013/03/21 ----------<<<<<
                // --- ADD 2013/03/21 ---------->>>>>
                // PMNS:車台番号(検索用)設定
                // 国産/外車区分が外車(2)の場合は車台番号(検索用)に0をセットする
                if (carInfoRow.DomesticForeignCode == 2)
                {
                    carInfoRow.SearchFrameNo = 0;
                }
                else
                {
                carInfoRow.SearchFrameNo = TStrConv.StrToIntDef(frameNo.Trim(), 0);
            }
                // --- ADD 2013/03/21 ----------<<<<<
            }
        }

        /// <summary>
        /// 車輌情報テーブル行の車種情報セット(カーメーカー、車種コード、車種サブコード)
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="makerCode">カーメーカーコード</param>
        /// <param name="makerFullName">メーカー全角名称</param>
        /// <param name="makerHalfName">メーカー半角名称</param>
        /// <param name="modelCode">車種コード</param>
        /// <param name="modelSubCode">車種サブコード</param>
        /// <param name="modelFullName">車種全角名称</param>
        /// <param name="modelHalfName">車種半角名称</param>
        public void SettingCarInfoRowFromModelInfo(int salesRowNo, int makerCode, string makerFullName, string makerHalfName, int modelCode, int modelSubCode, string modelFullName, string modelHalfName)
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);
            if (carInfoRow != null)
            {
                carInfoRow.MakerCode = makerCode;
                carInfoRow.MakerFullName = makerFullName;
                carInfoRow.MakerHalfName = makerHalfName;
                carInfoRow.ModelCode = modelCode;
                carInfoRow.ModelSubCode = modelSubCode;
                carInfoRow.ModelFullName = modelFullName;
                carInfoRow.ModelHalfName = modelHalfName;

                if (( modelCode == 0 ) && ( modelSubCode == 0 ))
                {
                    carInfoRow.ModelFullName = makerFullName;
                    carInfoRow.ModelHalfName = makerHalfName;
                }
            }
        }


        /// <summary>
        /// 車輌情報テーブル行の車種情報セット(車種マスタ)
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="modelNameU">車種マスタオブジェクト</param>
        public void SettingCarInfoRowFromModelInfo( int salesRowNo, ModelNameU modelNameU )
        {
            string makerName, makerKanaName;
            this._estimateInputInitDataAcs.GetName_FromMaker(modelNameU.MakerCode, out makerName, out makerKanaName);
            this.SettingCarInfoRowFromModelInfo(salesRowNo, modelNameU.MakerCode, makerName, makerKanaName, modelNameU.ModelCode, modelNameU.ModelSubCode, modelNameU.ModelFullName, modelNameU.ModelHalfName);

            //EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);
            //if (carInfoRow != null)
            //{
            //    carInfoRow.MakerCode = modelNameU.MakerCode;
            //    carInfoRow.MakerFullName = makerName;
            //    carInfoRow.MakerHalfName = makerKanaName;
            //    carInfoRow.ModelCode = modelNameU.ModelCode;
            //    carInfoRow.ModelSubCode = modelNameU.ModelSubCode;
            //    carInfoRow.ModelFullName = modelNameU.ModelFullName;
            //    carInfoRow.ModelHalfName = modelNameU.ModelHalfName;
            //}
        }

        /// <summary>
        /// 車輌情報テーブル行のカーメーカー情報セット
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="makerCode">カーメーカーコード</param>
        /// <param name="makerFullName">メーカー全角名称</param>
        /// <param name="makerHalfName">メーカー半角名称</param>
        public void SettingCarInfoRowFromMakerInfo(int salesRowNo, int makerCode, string makerFullName, string makerHalfName)
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);
            if (carInfoRow != null)
            {
                carInfoRow.MakerCode = makerCode;
                carInfoRow.MakerFullName = makerFullName;
                carInfoRow.MakerHalfName = makerHalfName;
            }
        }

        /// <summary>
        /// 車輌情報テーブル行のカラー情報セット
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="colorInfoRow">カラー情報行オブジェクト</param>
        private void SettingCarInfoRowFromColorInfo( Guid carRelationGuid, PMKEN01010E.ColorCdInfoRow colorInfoRow )
        {
            // 車輌情報行オブジェクト取得
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow != null)
            {
                carInfoRow.ColorCode = colorInfoRow.ColorCode; // カラーコード
                carInfoRow.ColorName1 = colorInfoRow.ColorName1; // カラー名称
            }
        }

        // --- ADD 2012/09/07 Y.Wakita ---------->>>>>
        /// <summary>
        /// 車両情報テーブル行のカラー情報セット
        /// </summary>
        /// <param name="carRelationGuid">車両情報共通キー</param>
        /// <param name="colorCode">カラーコード</param>
        private bool SettingCarInfoRowFromColorCode(Guid carRelationGuid, string colorCode)
        {
            bool ret = false;
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            // 車両情報行オブジェクト取得
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow != null)
            {
                CarMangInputExtraInfo selectedInfo;
                status = SearchCarManagement(carInfoRow, out selectedInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (selectedInfo.ColorCode == colorCode)
                    {
                        carInfoRow.ColorCode = colorCode;   // カラーコード
                        ret = true;
                    }
                }
                // --- DEL 2012/09/11 Y.Wakita ---------->>>>>
                //else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                //{
                //    if (carInfoRow.CarMngCode != "")
                //    {
                //        carInfoRow.ColorCode = colorCode;   // カラーコード
                //        ret = true;
                //    }
                //}
                // --- DEL 2012/09/11 Y.Wakita ----------<<<<<
            }
            return ret;
        }
        // --- ADD 2012/09/07 Y.Wakita ----------<<<<<

        /// <summary>
        /// 車輌情報テーブル行のトリム情報セット
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="trimInfoRow">トリム情報行オブジェクト</param>
        private void SettingCarInfoRowFromTrimInfo( Guid carRelationGuid, PMKEN01010E.TrimCdInfoRow trimInfoRow )
        {
            // 車輌情報行オブジェクト取得
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow != null)
            {
                carInfoRow.TrimCode = trimInfoRow.TrimCode; // トリムコード
                carInfoRow.TrimName = trimInfoRow.TrimName; // トリム名称
            }
        }

        /// <summary>
        /// 車輌情報テーブル行の装備情報セット
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        private void SettingCarInfoRowFromTrimInfo( Guid carRelationGuid )
        {
            // 設定用装備情報データテーブル
            PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTableForSave = new PMKEN01010E.CEqpDefDspInfoDataTable();

            // 車輌情報行オブジェクト取得
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);

            // 装備情報データテーブル取得
            PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];

            if (carInfoRow != null)
            {
                foreach (PMKEN01010E.CEqpDefDspInfoRow equipInfoRow in equipInfoDataTable)
                {
                    if (equipInfoRow.SelectionState == true)
                    {
                        PMKEN01010E.CEqpDefDspInfoRow newEquipInfoRow = equipInfoDataTableForSave.NewCEqpDefDspInfoRow();
                        newEquipInfoRow = equipInfoRow;
                    }
                }
                //carInfoRow.CategoryObjAry = equipInfoDataTableForSave.Clone(); // 装備オブジェクト配列
            }
        }

        // --- ADD 2012/09/07 Y.Wakita ---------->>>>>
        /// <summary>
        /// 車両情報テーブル行のトリム情報セット
        /// </summary>
        /// <param name="carRelationGuid">車両情報共通キー</param>
        /// <param name="colorInfoRow">カラー情報行オブジェクト</param>
        private bool SettingCarInfoRowFromTrimCode(Guid carRelationGuid, string trimCode)
        {
            bool ret = false;
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            // 車両情報行オブジェクト取得
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow != null)
            {
                CarMangInputExtraInfo selectedInfo;
                status = SearchCarManagement(carInfoRow, out selectedInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (selectedInfo.TrimCode == trimCode)
                    {
                        carInfoRow.TrimCode = trimCode; // トリムコード
                        ret = true;
                    }
                }
                // --- DEL 2012/09/11 Y.Wakita ---------->>>>>
                //else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                //{
                //    if (carInfoRow.CarMngCode != "")
                //    {
                //        carInfoRow.TrimCode = trimCode; // トリムコード
                //        ret = true;
                //    }
                //}
                // --- DEL 2012/09/11 Y.Wakita ----------<<<<<
            }
            return ret;
        }
        // --- ADD 2012/09/07 Y.Wakita ----------<<<<<

        /// <summary>
        /// 車輌情報テーブル行の年式セット
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="firstEntryDate">年式</param>
        public void SettingCarInfoRowFromFirstEntryDate( Guid carRelationGuid, int firstEntryDate )
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow != null)
            {
                carInfoRow.ProduceTypeOfYearInput = firstEntryDate;
            }
        }

        /// <summary>
        /// 車輌情報テーブル行の車台番号セット
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="frameNo">車台番号</param>
        public void SettingCarInfoRowFromFrameNo(int salesRowNo, string frameNo)
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);
            if (carInfoRow != null)
            {
                //carInfoRow.ProduceFrameNoInput = produceFrameNo;
                carInfoRow.FrameNo = frameNo;
                // --- DEL 2013/03/21 ---------->>>>>
                //carInfoRow.SearchFrameNo = TStrConv.StrToIntDef(frameNo.Trim(), 0);
                // --- DEL 2013/03/21 ----------<<<<<
                // --- ADD 2013/03/21 ---------->>>>>
                // PMNS:車台番号(検索用)設定
                // 国産/外車区分が外車(2)の場合は車台番号(検索用)に0をセットする
                if (carInfoRow.DomesticForeignCode == 2)
                {
                    carInfoRow.SearchFrameNo = 0;
                }
                else
                {
                carInfoRow.SearchFrameNo = TStrConv.StrToIntDef(frameNo.Trim(), 0);
            }
                // --- ADD 2013/03/21 ----------<<<<<
            }
        }

        /// <summary>
        /// 車輌情報テーブル行の管理番号セット
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="carMngCode">管理番号</param>
        public void SettingCarInfoRowFromCarMngCode(int salesRowNo, string carMngCode)
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);
            if (carInfoRow != null)
            {
                carInfoRow.CarMngCode= carMngCode;
                // --- ADD 2009/10/16 ------>>>>>
                if (string.Empty.Equals(carMngCode))
                {
                    carInfoRow.Mileage = 0;
                    carInfoRow.CarNote = string.Empty;
                    carInfoRow.CarMngNo = 0;
                    carInfoRow.NumberPlate1Code = 0;
                    carInfoRow.NumberPlate1Name = string.Empty;
                    carInfoRow.NumberPlate2 = string.Empty;
                    carInfoRow.NumberPlate3 = string.Empty;
                    carInfoRow.NumberPlate4 = 0;
                }
                // --- ADD 2009/10/16 ------<<<<<
            }
        }

        /// <summary>
        /// 売上明細データテーブルの車輌情報キーセット
        /// </summary>
        /// <param name="salesDetailRow">売上明細行オブジェクト</param>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        public void SettingSalesDetailCarRelationGuid( ref EstimateInputDataSet.EstimateDetailRow salesDetailRow, Guid carRelationGuid )
        {
            if (salesDetailRow != null)
            {
                salesDetailRow.CarRelationGuid = carRelationGuid;
            }
        }

        /// <summary>
        /// 売上明細データテーブルの車輌情報キークリア
        /// </summary>
        /// <param name="selectedSalesRowNoList">売上明細データテーブル選択行番号リスト</param>
        public void ClearSalesDetailCarInfoRow( List<int> selectedSalesRowNoList )
        {
            foreach (int salesRowNo in selectedSalesRowNoList)
            {
                this.ClearSalesDetailCarInfoRow(salesRowNo);
            }
        }

        /// <summary>
        /// 売上明細データテーブルの車輌情報キークリア
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        public void ClearSalesDetailCarInfoRow( int salesRowNo )
        {
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow == null) return;
            salesDetailRow.CarRelationGuid = Guid.Empty;
        }

        /// <summary>
        /// 売上明細データテーブルの車輌情報キークリア
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        public void ClearSalesDetailCarInfoRow( Guid carRelationGuid )
        {
            EstimateInputDataSet.EstimateDetailRow[] rows = (EstimateInputDataSet.EstimateDetailRow[])this._estimateDetailDataTable.Select(string.Format("{0}={1}", this._estimateDetailDataTable.CarRelationGuidColumn.ColumnName, carRelationGuid));

            foreach (EstimateInputDataSet.EstimateDetailRow row in rows)
            {
                row.CarRelationGuid = Guid.Empty;
            }
        }

        /// <summary>
        /// 検索車輌情報をディクショナリにキャッシュします。
        /// </summary>
        /// <param name="carRelationGuid"></param>
        /// <param name="carInfo"></param>
        private void CacheSearchCarInfo( Guid carRelationGuid, PMKEN01010E carInfo )
        {
            if (this._carInfoDictionary.ContainsKey(carRelationGuid))
            {
                this._carInfoDictionary[carRelationGuid] = carInfo;
            }
            else
            {
                this._carInfoDictionary.Add(carRelationGuid, carInfo);
            }
        }

        /// <summary>
        /// 指定行の検索車輌情報を取得します。
        /// </summary>
        /// <param name="salesRowNo"></param>
        /// <returns></returns>
        public PMKEN01010E GetSearchCarInfo( int salesRowNo )
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (( row != null ) && ( row.CarRelationGuid != Guid.Empty ))
            {
                return this.GetSearchCarInfo(row.CarRelationGuid);
            }
            else
            {
                return this.GetSearchCarInfo(this._beforeCarRelationGuid);
            }
        }

        /// <summary>
        /// 指定行の検索車輌情報を取得します。
        /// </summary>
        /// <param name="salesRowNo"></param>
        /// <returns>車両検索結果データセット</returns>
        /// <remarks>
        /// <br>Note       : 指定行の検索車輌情報を取得します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009/11/05</br>
        /// </remarks>
        public PMKEN01010E GetSearchCarInfoNew(int salesRowNo)
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if ((row != null) && (row.CarRelationGuid != Guid.Empty))
            {
                return this.GetSearchCarInfoNew(row.CarRelationGuid);
            }
            else
            {
                return this.GetSearchCarInfoNew(this._beforeCarRelationGuid);
            }
        }

        /// <summary>
        /// 車両情報テーブル取得処理(車両情報Dictionaryより取得)
        /// </summary>
        /// <param name="carRelationGuid">車両情報共通キー</param>
        /// <returns>車両検索結果データセット</returns>
        /// <remarks>
        /// <br>Note       : 指定行の検索車輌情報を取得します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009/11/05</br>
        /// </remarks>
        private PMKEN01010E GetSearchCarInfoNew(Guid carRelationGuid)
        {
            PMKEN01010E carInfoDataSet = new PMKEN01010E();
            if (this._carInfoDictionary.ContainsKey(carRelationGuid))
            {
                carInfoDataSet = this._carInfoDictionary[carRelationGuid];
                EstimateInputDataSet.CarInfoRow row = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
                if (row != null)
                {
                    carInfoDataSet.CarModelInfoSummarized[0].MakerCode = row.MakerCode;
                }
                else
                {
                    carInfoDataSet = null;
                }
            }
            else
            {
                carInfoDataSet = null;
 
            }
            return carInfoDataSet;
        }

        /// <summary>
        /// 指定されて車輌連結GUIDの検索車輌情報を取得します。
        /// </summary>
        /// <param name="carRelationGuid"></param>
        /// <returns></returns>
        private PMKEN01010E GetSearchCarInfo( Guid carRelationGuid )
        {
            return ( this._carInfoDictionary.ContainsKey(carRelationGuid) ) ? this._carInfoDictionary[carRelationGuid] : null;
        }

        /// <summary>
        /// 車輌情報キャッシュ（車輌検索情報からキャッシュ）
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="searchCarInfo">車輌検索結果クラス</param>
        public void CacheCarInfo( int salesRowNo, PMKEN01010E searchCarInfo )
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, EstimateInputAcs.GetCarInfoMode.ExistGetMode);
            EstimateInputDataSet.EstimateDetailRow estimateDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            this.CacheCarInfo(ref carInfoRow, estimateDetailRow, searchCarInfo);
        }

        /// <summary>
        /// 車両情報キャッシュ（車両検索情報＋見出貼付情報からキャッシュ）
        /// </summary>
        /// <param name="salesRowNo"></param>
        /// <param name="searchCarInfo"></param>
        /// <param name="salesSlipHeaderCopyData"></param>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/09/08②</br>
        public void CacheCarInfoForSlipHeaderCopy(int salesRowNo, PMKEN01010E searchCarInfo, SalesSlipHeaderCopyData salesSlipHeaderCopyData)
        {
            //----------------------------------------
            // 標準のキャッシュ処理
            //----------------------------------------
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, EstimateInputAcs.GetCarInfoMode.NewInsertMode);
            EstimateInputDataSet.EstimateDetailRow estimateDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
                this.CacheCarInfo(ref carInfoRow, estimateDetailRow, searchCarInfo);


            //----------------------------------------
            // 見出貼付用のキャッシュ処理
            //----------------------------------------
            carInfoRow.CarMngCode = salesSlipHeaderCopyData.CarMngCode; // 車輌管理番号
            carInfoRow.ModelDesignationNo = salesSlipHeaderCopyData.ModelDesignationNo; // 型式指定番号
            carInfoRow.CategoryNo = salesSlipHeaderCopyData.CategoryNo; // 類別番号
            // --- ADD 2009/10/22 ----->>>>>
            //carInfoRow.FirstEntryDate = TDateTime.LongDateToDateTime(salesSlipHeaderCopyData.FirstEntryDate); // 年式
            carInfoRow.FirstEntryDate = salesSlipHeaderCopyData.FirstEntryDate;
            //carInfoRow.ProduceTypeOfYearInput = salesSlipHeaderCopyData.FirstEntryDate / 100; // 初年度
            carInfoRow.ProduceTypeOfYearInput = salesSlipHeaderCopyData.FirstEntryDate;
            // --- ADD 2009/10/22 -----<<<<<
            carInfoRow.FrameNo = salesSlipHeaderCopyData.FrameNo; // 車台番号

            // --- ADD 2009/09/08② ---------->>>>>
            carInfoRow.CarMngNo = salesSlipHeaderCopyData.CarMngNo; // 車両管理番号
            carInfoRow.NumberPlate1Code = salesSlipHeaderCopyData.NumberPlate1Code; //陸運事務所番号
            carInfoRow.NumberPlate1Name = salesSlipHeaderCopyData.NumberPlate1Name; //陸運事務局名称
            carInfoRow.NumberPlate2 = salesSlipHeaderCopyData.NumberPlate2; //車両登録番号（種別）
            carInfoRow.NumberPlate3 = salesSlipHeaderCopyData.NumberPlate3; //車両登録番号（カナ）
            carInfoRow.NumberPlate4 = salesSlipHeaderCopyData.NumberPlate4; //車両登録番号（プレート番号）
            carInfoRow.Mileage = salesSlipHeaderCopyData.Mileage; //車両走行距離
            carInfoRow.CarNote = salesSlipHeaderCopyData.CarNote; //車輌備考
            // フル型式
            carInfoRow.FullModel = salesSlipHeaderCopyData.FullModel;
            // エンジン型式
            carInfoRow.EngineModelNm = salesSlipHeaderCopyData.EngineModelNm;
            carInfoRow.MakerCode = salesSlipHeaderCopyData.MakerCode; // 車種メーカーコード
            carInfoRow.ModelCode = salesSlipHeaderCopyData.ModelCode; // 車種コード
            carInfoRow.ModelSubCode = salesSlipHeaderCopyData.ModelSubCode; // 車種サブコード
            carInfoRow.ModelFullName = salesSlipHeaderCopyData.ModelFullName; // 車種全角名称
            // --- ADD 2009/09/08② ----------<<<<<

            // PMNS:国産/外車区分セット
            // --- ADD 2013/03/21 ---------->>>>>
            carInfoRow.DomesticForeignCode = salesSlipHeaderCopyData.DomesticForeignCode; // 国産/外車区分
            // --- ADD 2013/03/21 ----------<<<<<

            try
            {
                // --- DEL 2013/03/21 ---------->>>>>
                //carInfoRow.SearchFrameNo = Int32.Parse(carInfoRow.FrameNo);
                // --- DEL 2013/03/21 ----------<<<<<
                // --- ADD 2013/03/21 ---------->>>>>
                // PMNS:車台番号(検索用)設定
                // 国産/外車区分が外車(2)の場合は車台番号(検索用)に0をセットする
                if (carInfoRow.DomesticForeignCode == 2)
                {
                    carInfoRow.SearchFrameNo = 0;
                }
                else
                {
                carInfoRow.SearchFrameNo = Int32.Parse(carInfoRow.FrameNo);
            }
                // --- ADD 2013/03/21 ----------<<<<<
            }
            catch
            {
                carInfoRow.SearchFrameNo = 0;
            }

            this.SelectColorInfo(estimateDetailRow.CarRelationGuid, salesSlipHeaderCopyData.ColorCode); // カラー情報
            this.SelectTrimInfo(estimateDetailRow.CarRelationGuid, salesSlipHeaderCopyData.TrimCode); // トリム情報
            this.SelectEquipInfo(estimateDetailRow.CarRelationGuid, salesSlipHeaderCopyData.CategoryObjAry); // 装備情報
        }

        /// <summary>
        /// 車輌情報キャッシュ（車輌検索情報からキャッシュ）
        /// </summary>
        /// <param name="carInfoRow">車輌情報行オブジェクト</param>
        /// <param name="salesDetailRow">売上明細行オブジェクト</param>
        /// <param name="searchCarInfo">車輌検索結果クラス</param>
        /// <br>Update Note: 2011/02/14 曹文傑</br>
        /// <br>             データ登録時の車台番号範囲セットの修正</br>
        private void CacheCarInfo( ref EstimateInputDataSet.CarInfoRow carInfoRow, EstimateInputDataSet.EstimateDetailRow salesDetailRow, PMKEN01010E searchCarInfo )
        {
            PMKEN01010E.CarModelUIDataTable carModelUIDataTable = searchCarInfo.CarModelUIData; // ＵＩ用型式情報テーブル
            PMKEN01010E.CarModelInfoDataTable carModelInfoDataTable = searchCarInfo.CarModelInfoSummarized; // 型式情報要約テーブル
             // --- UPD 2009/10/16 ---------->>>>>
            if (carModelInfoDataTable != null && carModelInfoDataTable.Count > 0)
            {
                carInfoRow.CarRelationGuid = salesDetailRow.CarRelationGuid; // 車輌情報共通キー
                //carInfoRow.CustomerCode = carModelInfoDataTable[0].CustomerCode; // 得意先コード
                //carInfoRow.CarMngNo = carModelInfoDataTable[0].CarMngNo; // 車輌管理番号
                //carInfoRow.CarMngCode = carModelInfoDataTable[0].CarMngCode; // 車輌管理コード
                //carInfoRow.NumberPlate1Code = carModelInfoDataTable[0].NumberPlate1Code; // 陸運事務所番号
                //carInfoRow.NumberPlate1Name = carModelInfoDataTable[0].NumberPlate1Name; // 陸運事務局名称
                //carInfoRow.NumberPlate2 = carModelInfoDataTable[0].NumberPlate2; // 車輌登録番号（種別）
                //carInfoRow.NumberPlate3 = carModelInfoDataTable[0].NumberPlate3; // 車輌登録番号（カナ）
                //carInfoRow.NumberPlate4 = carModelInfoDataTable[0].NumberPlate4; // 車輌登録番号（プレート番号）
                //carInfoRow.EntryDate = carModelInfoDataTable[0].EntryDate; // 登録年月日
                //carInfoRow.FirstEntryDate = carModelInfoDataTable[0].FirstEntryDate; // 初年度
                carInfoRow.MakerCode = carModelInfoDataTable[0].MakerCode; // メーカーコード
                carInfoRow.MakerFullName = carModelInfoDataTable[0].MakerFullName; // メーカー全角名称
                carInfoRow.MakerHalfName = carModelInfoDataTable[0].MakerHalfName; // メーカー半角名称
                carInfoRow.ModelCode = carModelInfoDataTable[0].ModelCode; // 車種コード
                carInfoRow.ModelSubCode = carModelInfoDataTable[0].ModelSubCode; // 車種サブコード
                carInfoRow.ModelFullName = carModelInfoDataTable[0].ModelFullName; // 車種全角名称
                carInfoRow.ModelHalfName = carModelInfoDataTable[0].ModelHalfName; // 車種半角名称
                carInfoRow.SystematicCode = carModelInfoDataTable[0].SystematicCode; // 系統コード
                carInfoRow.SystematicName = carModelInfoDataTable[0].SystematicName; // 系統名称
                carInfoRow.ProduceTypeOfYearCd = carModelInfoDataTable[0].ProduceTypeOfYearCd; // 生産年式コード
                carInfoRow.ProduceTypeOfYearNm = carModelInfoDataTable[0].ProduceTypeOfYearNm; // 生産年式名称
                DateTime sdt;
                DateTime edt;
                int iyy = carModelInfoDataTable[0].StProduceTypeOfYear / 100;
                int imm = carModelInfoDataTable[0].StProduceTypeOfYear % 100;
                if ((iyy == 9999) || (imm == 99))
                {
                    sdt = DateTime.MinValue;
                }
                else
                {
                    sdt = new DateTime(iyy, imm, 1);
                }
                iyy = carModelInfoDataTable[0].EdProduceTypeOfYear / 100;
                imm = carModelInfoDataTable[0].EdProduceTypeOfYear % 100;
                if ((iyy == 9999) || (imm == 99))
                {
                    edt = DateTime.MinValue;
                }
                else
                {
                    edt = new DateTime(iyy, imm, 1);
                }
                carInfoRow.StProduceTypeOfYear = sdt; // 開始生産年式
                carInfoRow.EdProduceTypeOfYear = edt; // 終了生産年式
                carInfoRow.ProduceTypeOfYearInput = carModelUIDataTable[0].ProduceTypeOfYearInput; // 生産年式入力
                carInfoRow.DoorCount = carModelInfoDataTable[0].DoorCount; // ドア数
                carInfoRow.BodyNameCode = carModelInfoDataTable[0].BodyNameCode; // ボディー名コード
                carInfoRow.BodyName = carModelInfoDataTable[0].BodyName; // ボディー名称
                carInfoRow.ExhaustGasSign = carModelInfoDataTable[0].ExhaustGasSign; // 排ガス記号
                carInfoRow.SeriesModel = carModelInfoDataTable[0].SeriesModel; // シリーズ型式
                carInfoRow.CategorySignModel = carModelInfoDataTable[0].CategorySignModel; // 型式（類別記号）
                carInfoRow.FullModel = carModelInfoDataTable[0].FullModel; // 型式（フル型）
                carInfoRow.ModelDesignationNo = carModelUIDataTable[0].ModelDesignationNo; // 型式指定番号
                carInfoRow.CategoryNo = carModelUIDataTable[0].CategoryNo; // 類別番号
                carInfoRow.FrameModel = carModelInfoDataTable[0].FrameModel; // 車台型式
                //carInfoRow.FrameNo = carModelInfoDataTable[0].FrameNo; // 車台番号
                //carInfoRow.SearchFrameNo = carModelInfoDataTable[0].SearchFrameNo; // 車台番号（検索用）
                carInfoRow.FrameNo = carModelUIDataTable[0].FrameNo; // 車台番号
                carInfoRow.SearchFrameNo = carModelUIDataTable[0].SearchFrameNo; // 車台番号（検索用）
                carInfoRow.StProduceFrameNo = carModelInfoDataTable[0].StProduceFrameNo; // 生産車台番号開始
                carInfoRow.EdProduceFrameNo = carModelInfoDataTable[0].EdProduceFrameNo; // 生産車台番号終了
                //carInfoRow.ProduceFrameNoInput = carModelUIDataTable[0].ProduceFrameNoInput; // 生産車台番号入力
                carInfoRow.ModelGradeNm = carModelInfoDataTable[0].ModelGradeNm; // 型式グレード名称
                carInfoRow.EngineModelNm = carModelInfoDataTable[0].EngineModelNm; // エンジン型式名称
                carInfoRow.EngineDisplaceNm = carModelInfoDataTable[0].EngineDisplaceNm; // 排気量名称
                carInfoRow.EDivNm = carModelInfoDataTable[0].EDivNm; // E区分名称
                carInfoRow.TransmissionNm = carModelInfoDataTable[0].TransmissionNm; // ミッション名称
                carInfoRow.ShiftNm = carModelInfoDataTable[0].ShiftNm; // シフト名称
                carInfoRow.WheelDriveMethodNm = carModelInfoDataTable[0].WheelDriveMethodNm; // 駆動方式名称
                carInfoRow.AddiCarSpec1 = carModelInfoDataTable[0].AddiCarSpec1; // 追加諸元1
                carInfoRow.AddiCarSpec2 = carModelInfoDataTable[0].AddiCarSpec2; // 追加諸元2
                carInfoRow.AddiCarSpec3 = carModelInfoDataTable[0].AddiCarSpec3; // 追加諸元3
                carInfoRow.AddiCarSpec4 = carModelInfoDataTable[0].AddiCarSpec4; // 追加諸元4
                carInfoRow.AddiCarSpec5 = carModelInfoDataTable[0].AddiCarSpec5; // 追加諸元5
                carInfoRow.AddiCarSpec6 = carModelInfoDataTable[0].AddiCarSpec6; // 追加諸元6
                carInfoRow.AddiCarSpecTitle1 = carModelInfoDataTable[0].AddiCarSpecTitle1; // 追加諸元タイトル1
                carInfoRow.AddiCarSpecTitle2 = carModelInfoDataTable[0].AddiCarSpecTitle2; // 追加諸元タイトル2
                carInfoRow.AddiCarSpecTitle3 = carModelInfoDataTable[0].AddiCarSpecTitle3; // 追加諸元タイトル3
                carInfoRow.AddiCarSpecTitle4 = carModelInfoDataTable[0].AddiCarSpecTitle4; // 追加諸元タイトル4
                carInfoRow.AddiCarSpecTitle5 = carModelInfoDataTable[0].AddiCarSpecTitle5; // 追加諸元タイトル5
                carInfoRow.AddiCarSpecTitle6 = carModelInfoDataTable[0].AddiCarSpecTitle6; // 追加諸元タイトル6
                carInfoRow.RelevanceModel = carModelInfoDataTable[0].RelevanceModel; // 関連型式
                carInfoRow.SubCarNmCd = carModelInfoDataTable[0].SubCarNmCd; // サブ車名コード
                carInfoRow.ModelGradeSname = carModelInfoDataTable[0].ModelGradeSname; // 型式グレード略称
                carInfoRow.BlockIllustrationCd = carModelInfoDataTable[0].BlockIllustrationCd; // ブロックイラストコード
                carInfoRow.ThreeDIllustNo = carModelInfoDataTable[0].ThreeDIllustNo; // 3DイラストNo
                carInfoRow.PartsDataOfferFlag = carModelInfoDataTable[0].PartsDataOfferFlag; // 部品データ提供フラグ
                //carInfoRow.InspectMaturityDate = carModelInfoDataTable[0].InspectMaturityDate; // 車検満期日
                //carInfoRow.LTimeCiMatDate = carModelInfoDataTable[0].LTimeCiMatDate; // 前回車検満期日
                //carInfoRow.CarInspectYear = carModelInfoDataTable[0].CarInspectYear; // 車検期間
                //carInfoRow.Mileage = carModelInfoDataTable[0].Mileage; // 車輌走行距離
                //carInfoRow.CarNo = carModelInfoDataTable[0].CarNo; // 号車
                // --- ADD 2013/03/21 ---------->>>>>
                // PMNS:国産/外車区分セット
                carInfoRow.DomesticForeignCode = carModelInfoDataTable[0].DomesticForeignCode;
                // --- ADD 2013/03/21 ----------<<<<<
            }
            // --- UPD 2009/10/16 ----------<<<<<
            // --- UPD 2010/05/20 ---------->>>>>
            //carInfoRow.FullModelFixedNoAry = this._carSearchController.GetFullModelFixedNoArray(carModelInfoDataTable); // フル型式固定番号配列
            int[] tmp = new int[0];
            string[] tmp2 = new string[0];
            // ---UPD 2011/02/14--------------->>>>>
            //this._carSearchController.GetFullModelFixedNoArrayWithFreeSrchMdlFxdNo(carModelInfoDataTable, out tmp, out tmp2);
            this._carSearchController.GetFullModelFixedNoArrayWithFreeSrchMdlFxdNo(searchCarInfo.CarModelInfo, out tmp, out tmp2);
            // ---UPD 2011/02/14---------------<<<<<
            carInfoRow.FullModelFixedNoAry = tmp;
            carInfoRow.FreeSrchMdlFxdNoAry = tmp2;
            // --- UPD 2010/05/20 ---------->>>>>

            //carInfoRow.ProduceFrameNoInput = carModelInfoDataTable[0].ProduceFrameNoInput; // 車台番号
            //carInfoRow.ProduceTypeOfYearInput = carModelInfoDataTable[0].ProduceTypeOfYearInput; // 年式
            //carInfoRow.ColorCode; // カラーコード
            //carInfoRow.ColorName1; // カラー名称
            //carInfoRow.TrimCode; // トリムコード
            //carInfoRow.TrimName; // トリム名称

            this.CacheColorInfo(salesDetailRow.SalesSlipNum, salesDetailRow.SalesRowNo, searchCarInfo.ColorCdInfo);                         // カラー情報
            this.CacheTrimInfo(salesDetailRow.SalesSlipNum, salesDetailRow.SalesRowNo, searchCarInfo.TrimCdInfo);                           // トリム情報
            this.CacheEquipInfo(salesDetailRow.SalesSlipNum, salesDetailRow.SalesRowNo, searchCarInfo.CEqpDefDspInfo);                      // 装備情報

            carInfoRow.AcceptAnOrderNo = 0; // 受注番号


            // 車輌情報Dictionaryキャッシュ
            if (this._carInfoDictionary.ContainsKey(carInfoRow.CarRelationGuid))
            {
                this._carInfoDictionary.Remove(carInfoRow.CarRelationGuid);
            }
            this._carInfoDictionary.Add(carInfoRow.CarRelationGuid, searchCarInfo);
        }

        /// <summary>
        /// 車輌情報キャッシュ（受注マスタ（車輌）からキャッシュ）
        /// </summary>
        /// <param name="salesRowNo">設定対象行番号</param>
        /// <param name="salesDetail">売上明細オブジェクトリスト</param>
        /// <param name="acceptOdrCarList">受注マスタ（車輌）オブジェクトリスト</param>
        /// <br>Note       : 修正呼出時の伝票複写によるエラー修正</br>
        /// <br>Programmer : 施ヘイ中</br>
        /// <br>Date       : 2011/02/14</br>
        /// <remarks>Call:明細選択</remarks>
        public void CacheCarInfo(int salesRowNo, SalesDetail salesDetail, List<AcceptOdrCar> acceptOdrCarList)
        {
            SalesSlip baseSalesSlip = null;

            if (acceptOdrCarList != null)
            {
                AcceptOdrCar acceptOdrCar;
                // --- UPD 2011/02/14 ----------------->>>>>>>>>>>>>
                //EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(ctDefaultSalesSlipNum, salesRowNo);
                EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
                // --- UPD 2011/02/14 -----------------<<<<<<<<<<<<<
                acceptOdrCar = this.GetAcceptOdrCar(salesDetail.AcceptAnOrderNo, acceptOdrCarList);
                if (this._carRelationDic.ContainsKey(salesDetail.AcceptAnOrderNo))
                {
                    salesDetailRow.CarRelationGuid = this._carRelationDic[salesDetail.AcceptAnOrderNo];
                }
                else
                {
                    if (acceptOdrCar != null)
                    {
                        this.CacheCarInfo(salesRowNo, null, salesDetail, acceptOdrCar);
                        salesDetailRow.CarRelationGuid = this._carRelationDic[acceptOdrCar.AcceptAnOrderNo];
                    }
                }
            }
        }


        /// <summary>
        /// 車輌情報キャッシュ（受注マスタ（車輌）からキャッシュ）
        /// </summary>
        /// <param name="salesDetail">売上明細オブジェクトリスト</param>
        /// <param name="acceptOdrCarList">受注マスタ（車輌）オブジェクトリスト</param>
        /// <remarks>Call:明細選択時</remarks>
        public void CacheCarInfo(SalesDetail salesDetail, List<AcceptOdrCar> acceptOdrCarList)
        {
            SalesSlip baseSalesSlip = null;

            if (acceptOdrCarList != null)
            {
                AcceptOdrCar acceptOdrCar;

                acceptOdrCar = this.GetAcceptOdrCar(salesDetail.AcceptAnOrderNo, acceptOdrCarList);
                if (this._carRelationDic.ContainsKey(salesDetail.AcceptAnOrderNo))
                {
                    EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(salesDetail.SalesSlipNum, salesDetail.SalesRowNo);
                    salesDetailRow.CarRelationGuid = this._carRelationDic[salesDetail.AcceptAnOrderNo];
                }
                else
                {
                    if (acceptOdrCar != null) this.CacheCarInfo(baseSalesSlip, salesDetail, acceptOdrCar);
                }
            }
        }

        /// <summary>
        /// 車輌情報キャッシュ（受注マスタ（車輌）からキャッシュ）
        /// </summary>
        /// <param name="baseSalesSlip">処理元売上データオブジェクト</param>
        /// <param name="salesDetailList">売上明細オブジェクトリスト</param>
        /// <param name="acceptOdrCarList">受注マスタ（車輌）オブジェクトリスト</param>
        public void CacheCarInfo(SalesSlip baseSalesSlip, List<SalesDetail> salesDetailList, List<AcceptOdrCar> acceptOdrCarList)
        {
            if (acceptOdrCarList != null)
            {
                AcceptOdrCar acceptOdrCar;
                foreach (SalesDetail salesDetail in salesDetailList)
                {
                    acceptOdrCar = this.GetAcceptOdrCar(salesDetail.AcceptAnOrderNo, acceptOdrCarList);
                    if (this._carRelationDic.ContainsKey(salesDetail.AcceptAnOrderNo))
                    {
                        EstimateInputDataSet.EstimateDetailRow estimateDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(salesDetail.SalesSlipNum, salesDetail.SalesRowNo);

                        estimateDetailRow.CarRelationGuid = this._carRelationDic[salesDetail.AcceptAnOrderNo];
                    }
                    else
                    {
                        if (acceptOdrCar != null) this.CacheCarInfo(baseSalesSlip, salesDetail, acceptOdrCar);
                    }
                }
            }
        }

        /// <summary>
        /// 車輌情報キャッシュ（受注マスタ（車輌）からキャッシュ）
        /// </summary>
        /// <param name="baseSalesSlip">処理元売上データオブジェクト</param>
        /// <param name="salesDetail">売上明細データオブジェクト</param>
        /// <param name="acceptOdrCar">受注マスタ（車輌）オブジェクト</param>
        public void CacheCarInfo(SalesSlip baseSalesSlip, SalesDetail salesDetail, AcceptOdrCar acceptOdrCar)
        {
            this.CacheCarInfo(salesDetail.SalesRowNo, baseSalesSlip, salesDetail, acceptOdrCar);
        }

        /// <summary>
        /// 車輌情報キャッシュ（受注マスタ（車輌）からキャッシュ）
        /// </summary>
        /// <param name="salesRowNo">設定対象行番号</param>
        /// <param name="baseSalesSlip">処理元売上データオブジェクト</param>
        /// <param name="salesDetail">売上明細オブジェクト</param>
        /// <param name="acceptOdrCar">受注マスタ（車輌）オブジェクト</param>
        /// <br>Update Note: 2009/09/08②       汪千来</br>
        ///	<br>		   : 車輌備考を追加する</br>
        ///	<br>Update Note: 2011/02/15 譚洪</br>
        ///	<br>		   : 修正呼出時のＴＢＯ検索を可能に修正</br>
        public void CacheCarInfo(int salesRowNo, SalesSlip baseSalesSlip, SalesDetail salesDetail, AcceptOdrCar acceptOdrCar)
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(baseSalesSlip, salesRowNo, EstimateInputAcs.GetCarInfoMode.NewInsertMode);

            string slipNum = this._currentSalesSlipNum;
            if (baseSalesSlip != null) slipNum = baseSalesSlip.SalesSlipNum;
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(slipNum, salesRowNo);
            
            // 車輌再検索
            PMKEN01010E carInfoDataset = new PMKEN01010E();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 UPD
            //CarSearchResultReport result = this.SearchCar(acceptOdrCar.FullModelFixedNoAry, acceptOdrCar.ModelDesignationNo, acceptOdrCar.CategoryNo, ref carInfoDataset);

            CarSearchCondition carSearchCond = new CarSearchCondition();

            carSearchCond.CarModel.FullModel = acceptOdrCar.FullModel;
            carSearchCond.MakerCode = acceptOdrCar.MakerCode;
            carSearchCond.ModelCode = acceptOdrCar.ModelCode;
            carSearchCond.ModelSubCode = acceptOdrCar.ModelSubCode;

            // ---- ADD 2011/02/15 ------- >>>>
            carSearchCond.ModelDesignationNo = acceptOdrCar.ModelDesignationNo;
            carSearchCond.CategoryNo = acceptOdrCar.CategoryNo;
            // ---- ADD 2011/02/15 ------- <<<<

            //CarSearchResultReport result = this.SearchCar( acceptOdrCar.FullModelFixedNoAry, carSearchCond, ref carInfoDataset ); // DEL 2010/05/20
            CarSearchResultReport result = this._carSearchController.SearchByFullModelFixedNo(acceptOdrCar.FullModelFixedNoAry, acceptOdrCar.FreeSrchMdlFxdNoAry, carSearchCond, ref carInfoDataset); // ADD 2010/05/20
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 UPD
            if ((result != CarSearchResultReport.retError) && (result != CarSearchResultReport.retFailed))
            {
                // --- ADD 譚洪 2014/09/01 Redmine#43289---------->>>>>
                if (carInfoDataset.CarModelUIData != null)
                {
                    carInfoDataset.CarModelUIData[0].ProduceTypeOfYearInput = acceptOdrCar.FirstEntryDate;
                    carInfoDataset.CarModelUIData[0].ModelDesignationNo = acceptOdrCar.ModelDesignationNo;
                    carInfoDataset.CarModelUIData[0].CategoryNo = acceptOdrCar.CategoryNo;
                    carInfoDataset.CarModelUIData[0].FrameNo = acceptOdrCar.FrameNo;
                }
                // --- ADD 譚洪 2014/09/01 Redmine#43289----------<<<<<

                this.CacheCarInfo(ref carInfoRow, salesDetailRow, carInfoDataset);
            }
            carInfoRow.CarRelationGuid = salesDetailRow.CarRelationGuid; // 車輌情報共通キー
            //carInfoRow.CustomerCode = acceptOdrCar.CustomerCode; // 得意先コード
            carInfoRow.CarMngNo = acceptOdrCar.CarMngNo; // 車両管理番号
            carInfoRow.CarMngCode = acceptOdrCar.CarMngCode; // 車輌管理コード
            carInfoRow.NumberPlate1Code = acceptOdrCar.NumberPlate1Code; // 陸運事務所番号
            carInfoRow.NumberPlate1Name = acceptOdrCar.NumberPlate1Name; // 陸運事務局名称
            carInfoRow.NumberPlate2 = acceptOdrCar.NumberPlate2; // 車両登録番号（種別）
            carInfoRow.NumberPlate3 = acceptOdrCar.NumberPlate3; // 車両登録番号（カナ）
            carInfoRow.NumberPlate4 = acceptOdrCar.NumberPlate4; // 車両登録番号（プレート番号）
            //carInfoRow.EntryDate = acceptOdrCar.EntryDate; // 登録年月日
            carInfoRow.ProduceTypeOfYearInput = 0; // 初年度
            // --- UPD 2009/10/22 ----->>>>>
            //if (acceptOdrCar.FirstEntryDate != DateTime.MinValue)
            //{
            //    int iyy = acceptOdrCar.FirstEntryDate.Year * 100;
            //    int imm = acceptOdrCar.FirstEntryDate.Month;
            //    carInfoRow.ProduceTypeOfYearInput = iyy + imm; // 初年度
            //}

            if(acceptOdrCar.FirstEntryDate != 0 )
            {
                carInfoRow.ProduceTypeOfYearInput = acceptOdrCar.FirstEntryDate;
            }
            // --- UPD 2009/10/22 -----<<<<<
            carInfoRow.MakerCode = acceptOdrCar.MakerCode; // メーカーコード
            carInfoRow.MakerFullName = acceptOdrCar.MakerFullName; // メーカー全角名称
            carInfoRow.MakerHalfName = acceptOdrCar.MakerHalfName; // メーカー半角名称
            carInfoRow.ModelCode = acceptOdrCar.ModelCode; // 車種コード
            carInfoRow.ModelSubCode = acceptOdrCar.ModelSubCode; // 車種サブコード
            carInfoRow.ModelFullName = acceptOdrCar.ModelFullName; // 車種全角名称
            carInfoRow.ModelHalfName = acceptOdrCar.ModelHalfName; // 車種半角名称
            //carInfoRow.SystematicCode = acceptOdrCar.SystematicCode; // 系統コード
            //carInfoRow.SystematicName = acceptOdrCar.SystematicName; // 系統名称
            //carInfoRow.ProduceTypeOfYearCd = acceptOdrCar.ProduceTypeOfYearCd; // 生産年式コード
            //carInfoRow.ProduceTypeOfYearNm = acceptOdrCar.ProduceTypeOfYearNm; // 生産年式名称
            //carInfoRow.StProduceTypeOfYear = acceptOdrCar.StProduceTypeOfYear; // 開始生産年式
            //carInfoRow.EdProduceTypeOfYear = acceptOdrCar.EdProduceTypeOfYear; // 終了生産年式
            //carInfoRow.DoorCount = acceptOdrCar.DoorCount; // ドア数
            //carInfoRow.BodyNameCode = acceptOdrCar.BodyNameCode; // ボディー名コード
            //carInfoRow.BodyName = acceptOdrCar.BodyName; // ボディー名称
            carInfoRow.ExhaustGasSign = acceptOdrCar.ExhaustGasSign; // 排ガス記号
            carInfoRow.SeriesModel = acceptOdrCar.SeriesModel; // シリーズ型式
            carInfoRow.CategorySignModel = acceptOdrCar.CategorySignModel; // 型式（類別記号）
            carInfoRow.FullModel = acceptOdrCar.FullModel; // 型式（フル型）
            carInfoRow.ModelDesignationNo = acceptOdrCar.ModelDesignationNo; // 型式指定番号
            carInfoRow.CategoryNo = acceptOdrCar.CategoryNo; // 類別番号
            carInfoRow.FrameModel = acceptOdrCar.FrameModel; // 車台型式
            carInfoRow.FrameNo = acceptOdrCar.FrameNo; // 車台番号
            //carInfoRow.ProduceFrameNoInput = TStrConv.StrToIntDef(acceptOdrCar.FrameNo, 0); // 車台番号
            carInfoRow.SearchFrameNo = acceptOdrCar.SearchFrameNo; // 車台番号（検索用）
            //carInfoRow.StProduceFrameNo = acceptOdrCar.StProduceFrameNo; // 生産車台番号開始
            //carInfoRow.EdProduceFrameNo = acceptOdrCar.EdProduceFrameNo; // 生産車台番号終了
            //carInfoRow.ModelGradeNm = acceptOdrCar.ModelGradeNm; // 型式グレード名称
            carInfoRow.EngineModelNm = acceptOdrCar.EngineModelNm; // エンジン型式名称
            //carInfoRow.EngineDisplaceNm = acceptOdrCar.EngineDisplaceNm; // 排気量名称
            //carInfoRow.EDivNm = acceptOdrCar.EDivNm; // E区分名称
            //carInfoRow.TransmissionNm = acceptOdrCar.TransmissionNm; // ミッション名称
            //carInfoRow.ShiftNm = acceptOdrCar.ShiftNm; // シフト名称
            //carInfoRow.WheelDriveMethodNm = acceptOdrCar.WheelDriveMethodNm; // 駆動方式名称
            //carInfoRow.AddiCarSpec1 = acceptOdrCar.AddiCarSpec1; // 追加諸元1
            //carInfoRow.AddiCarSpec2 = acceptOdrCar.AddiCarSpec2; // 追加諸元2
            //carInfoRow.AddiCarSpec3 = acceptOdrCar.AddiCarSpec3; // 追加諸元3
            //carInfoRow.AddiCarSpec4 = acceptOdrCar.AddiCarSpec4; // 追加諸元4
            //carInfoRow.AddiCarSpec5 = acceptOdrCar.AddiCarSpec5; // 追加諸元5
            //carInfoRow.AddiCarSpec6 = acceptOdrCar.AddiCarSpec6; // 追加諸元6
            //carInfoRow.AddiCarSpecTitle1 = acceptOdrCar.AddiCarSpecTitle1; // 追加諸元タイトル1
            //carInfoRow.AddiCarSpecTitle2 = acceptOdrCar.AddiCarSpecTitle2; // 追加諸元タイトル2
            //carInfoRow.AddiCarSpecTitle3 = acceptOdrCar.AddiCarSpecTitle3; // 追加諸元タイトル3
            //carInfoRow.AddiCarSpecTitle4 = acceptOdrCar.AddiCarSpecTitle4; // 追加諸元タイトル4
            //carInfoRow.AddiCarSpecTitle5 = acceptOdrCar.AddiCarSpecTitle5; // 追加諸元タイトル5
            //carInfoRow.AddiCarSpecTitle6 = acceptOdrCar.AddiCarSpecTitle6; // 追加諸元タイトル6
            carInfoRow.RelevanceModel = acceptOdrCar.RelevanceModel; // 関連型式
            carInfoRow.SubCarNmCd = acceptOdrCar.SubCarNmCd; // サブ車名コード
            carInfoRow.ModelGradeSname = acceptOdrCar.ModelGradeSname; // 型式グレード略称
            //carInfoRow.BlockIllustrationCd = acceptOdrCar.BlockIllustrationCd; // ブロックイラストコード
            //carInfoRow.ThreeDIllustNo = acceptOdrCar.ThreeDIllustNo; // 3DイラストNo
            //carInfoRow.PartsDataOfferFlag = acceptOdrCar.PartsDataOfferFlag; // 部品データ提供フラグ
            //carInfoRow.InspectMaturityDate = acceptOdrCar.InspectMaturityDate; // 車検満期日
            //carInfoRow.LTimeCiMatDate = acceptOdrCar.LTimeCiMatDate; // 前回車検満期日
            //carInfoRow.CarInspectYear = acceptOdrCar.CarInspectYear; // 車検期間
            carInfoRow.Mileage = acceptOdrCar.Mileage; // 車両走行距離
            //carInfoRow.CarNo = acceptOdrCar.CarNo; // 号車
            carInfoRow.FullModelFixedNoAry = acceptOdrCar.FullModelFixedNoAry; // フル型式固定番号配列
            carInfoRow.FreeSrchMdlFxdNoAry = acceptOdrCar.FreeSrchMdlFxdNoAry; // 自由検索型式固定番号配列 // ADD 2010/04/27
            //carInfoRow.ProduceFrameNoInput = acceptOdrCar.ProduceFrameNoInput; // 車台番号
            //carInfoRow.ProduceTypeOfYearInput = acceptOdrCar.ProduceTypeOfYearInput; // 年式
            carInfoRow.ColorCode = acceptOdrCar.ColorCode; // カラーコード
            carInfoRow.ColorName1 = acceptOdrCar.ColorName1; // カラー名称
            carInfoRow.TrimCode = acceptOdrCar.TrimCode; // トリムコード
            carInfoRow.TrimName = acceptOdrCar.TrimName; // トリム名称

            // --- ADD 2009/09/08② ---------->>>>>
            carInfoRow.CarNote = acceptOdrCar.CarNote; // 車輌備考
            // --- ADD 2009/09/08② ----------<<<<<

            // --- UPD 2012/09/11 Y.Wakita ---------->>>>>
            //this.SelectColorInfo(salesDetailRow.CarRelationGuid, acceptOdrCar.ColorCode); // カラー情報
            //this.SelectTrimInfo(salesDetailRow.CarRelationGuid, acceptOdrCar.TrimCode); // トリム情報
            this.SelectColorInfo2(salesDetailRow.CarRelationGuid, acceptOdrCar.ColorCode); // カラー情報
            this.SelectTrimInfo2(salesDetailRow.CarRelationGuid, acceptOdrCar.TrimCode); // トリム情報
            // --- UPD 2012/09/11 Y.Wakita ----------<<<<<
            this.SelectEquipInfo(salesDetailRow.CarRelationGuid, acceptOdrCar.CategoryObjAry); // 装備情報

            carInfoRow.AcceptAnOrderNo = acceptOdrCar.AcceptAnOrderNo; // 受注番号

            this._carRelationDic[acceptOdrCar.AcceptAnOrderNo] = carInfoRow.CarRelationGuid; // 車両連結情報
            // --- ADD 2013/03/21 ---------->>>>>
            // PMNS:国産/外車区分セット
            carInfoRow.DomesticForeignCode = acceptOdrCar.DomesticForeignCode;
            // --- ADD 2013/03/21 ----------<<<<<
        }


        /// <summary>
        /// 見出貼付情報クラスワークキャッシュ（車両管理からキャッシュ）
        /// </summary>
        /// <param name="carMangInputExtraInfo">車両管理</param>
        /// <returns>SalesSlipHeaderCopyData</returns>
        /// <remarks>
        /// <br>Note       : 見出貼付情報クラスをキャッシュします。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/09/08②</br>
        /// </remarks>
        public SalesSlipHeaderCopyData CacheCarInfo(CarMangInputExtraInfo carMangInputExtraInfo)
        {
            SalesSlipHeaderCopyData salesSlipHeaderCopyData = new SalesSlipHeaderCopyData();
            // 車両管理番号
            salesSlipHeaderCopyData.CarMngNo = carMangInputExtraInfo.CarMngNo;
            // 車両走行距離
            salesSlipHeaderCopyData.Mileage = carMangInputExtraInfo.Mileage;
            // 車輌備考
            salesSlipHeaderCopyData.CarNote = carMangInputExtraInfo.CarNote;
            // 陸運事務所番号
            salesSlipHeaderCopyData.NumberPlate1Code = carMangInputExtraInfo.NumberPlate1Code;
            // 陸運事務局名称
            salesSlipHeaderCopyData.NumberPlate1Name = carMangInputExtraInfo.NumberPlate1Name;
            // 車両登録番号（種別）
            salesSlipHeaderCopyData.NumberPlate2 = carMangInputExtraInfo.NumberPlate2;
            // 車両登録番号（カナ）
            salesSlipHeaderCopyData.NumberPlate3 = carMangInputExtraInfo.NumberPlate3;
            // 車両登録番号（プレート番号）
            salesSlipHeaderCopyData.NumberPlate4 = carMangInputExtraInfo.NumberPlate4;
            // 車輌管理番号
            salesSlipHeaderCopyData.CarMngCode = carMangInputExtraInfo.CarMngCode;
            // 型式指定番号
            salesSlipHeaderCopyData.ModelDesignationNo = carMangInputExtraInfo.ModelDesignationNo;
            // 類別番号
            salesSlipHeaderCopyData.CategoryNo = carMangInputExtraInfo.CategoryNo;
            // 年式
            // --- ADD 2009/10/22 ----->>>>>
            //salesSlipHeaderCopyData.FirstEntryDate = GetLongDateFromObject(carMangInputExtraInfo.ProduceTypeOfYearInput);
            salesSlipHeaderCopyData.FirstEntryDate = carMangInputExtraInfo.ProduceTypeOfYearInput;
            // --- ADD 2009/10/22 -----<<<<<
            // 車台番号
            salesSlipHeaderCopyData.FrameNo = carMangInputExtraInfo.FrameNo;
            // カラー情報
            salesSlipHeaderCopyData.ColorCode = carMangInputExtraInfo.ColorCode;
            // トリム情報
            salesSlipHeaderCopyData.TrimCode = carMangInputExtraInfo.TrimCode;
            // 装備情報
            salesSlipHeaderCopyData.CategoryObjAry = carMangInputExtraInfo.CategoryObjAry;
            // フル型式固定番号配列
            salesSlipHeaderCopyData.FullModelFixedNoAry = carMangInputExtraInfo.FullModelFixedNoAry;
            // 自由検索型式固定番号配列
            salesSlipHeaderCopyData.FreeSrchMdlFxdNoAry = carMangInputExtraInfo.FreeSrchMdlFxdNoAry; // ADD 2010/04/27
            // 得意先コード
            salesSlipHeaderCopyData.CustomerCode = carMangInputExtraInfo.CustomerCode;
            // 陸運事務所番号
            salesSlipHeaderCopyData.NumberPlate1Code = carMangInputExtraInfo.NumberPlate1Code;
            // 陸運事務局名称
            salesSlipHeaderCopyData.NumberPlate1Name = carMangInputExtraInfo.NumberPlate1Name;
            // 車両登録番号（種別）
            salesSlipHeaderCopyData.NumberPlate2 = carMangInputExtraInfo.NumberPlate2;
            // 車両登録番号（カナ）
            salesSlipHeaderCopyData.NumberPlate3 = carMangInputExtraInfo.NumberPlate3;
            // 車両登録番号（プレート番号）
            salesSlipHeaderCopyData.NumberPlate4 = carMangInputExtraInfo.NumberPlate4;
            // 車両走行距離
            salesSlipHeaderCopyData.Mileage = carMangInputExtraInfo.Mileage;
            // 車輌備考
            salesSlipHeaderCopyData.CarNote = carMangInputExtraInfo.CarNote;
            // 車両管理番号
            salesSlipHeaderCopyData.CarMngNo = carMangInputExtraInfo.CarMngNo;
            // 型式（フル型）
            salesSlipHeaderCopyData.FullModel = carMangInputExtraInfo.FullModel;
            // エンジン
            salesSlipHeaderCopyData.EngineModelNm = carMangInputExtraInfo.EngineModelNm;
            // --- ADD 2009/09/08② ---------->>>>>
            salesSlipHeaderCopyData.MakerCode = carMangInputExtraInfo.MakerCode; // 車種メーカーコード
            salesSlipHeaderCopyData.ModelCode = carMangInputExtraInfo.ModelCode; // 車種コード
            salesSlipHeaderCopyData.ModelSubCode = carMangInputExtraInfo.ModelSubCode; // 車種サブコード
            salesSlipHeaderCopyData.ModelFullName = carMangInputExtraInfo.ModelFullName; // 車種全角名称
            // --- ADD 2009/09/08② ---------->>>>>

            // PMNS:国産/外車区分セット
            // --- ADD 2013/03/21 ---------->>>>>
            salesSlipHeaderCopyData.DomesticForeignCode = carMangInputExtraInfo.DomesticForeignCode; // 国産/外車区分
            // --- ADD 2013/03/21 ----------<<<<<

            return salesSlipHeaderCopyData;

        }

        /// <summary>
        /// オブジェクトからの日付LongDate取得処理
        /// </summary>
        /// <param name="targetInt"></param>
        /// <returns>LongDate</returns>
        /// <remarks>
        /// <br>Note       : 日付LongDateを処理します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/09/08②</br>
        /// </remarks>
        private int GetLongDateFromObject(int targetInt)
        {
            if (targetInt == 0)
            {
                return 0;
            }
            else
            {
                try
                {
                    DateTime time = DateTime.ParseExact(targetInt.ToString(), "yyyyMM", null);
                    return TDateTime.DateTimeToLongDate(time);
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 受注マスタ（車輌）オブジェクトリストから対象オブジェクトを取得
        /// </summary>
        /// <param name="acceptAnOrderNo">受注番号</param>
        /// <param name="acceptOdrCarList">受注マスタ（車輌）リスト</param>
        /// <returns>受注マスタ（車輌）オブジェクト</returns>
        private AcceptOdrCar GetAcceptOdrCar( int acceptAnOrderNo, List<AcceptOdrCar> acceptOdrCarList )
        {
            foreach (AcceptOdrCar acceptOdrCar in acceptOdrCarList)
            {
                if (acceptAnOrderNo == acceptOdrCar.AcceptAnOrderNo)
                {
                    return acceptOdrCar;
                }
            }
            return null;
        }

        /// <summary>
        /// 諸元情報設定処理(車輌情報行オブジェクト→諸元情報行オブジェクト)
        /// </summary>
        /// <param name="carSpecRow">諸元情報行オブジェクト</param>
        /// <param name="carInfoRow">車輌情報行オブジェクト</param>
        public void SetCarSpecFromCarInfoRow( ref EstimateInputDataSet.CarSpecRow carSpecRow, EstimateInputDataSet.CarInfoRow carInfoRow )
        {
            if (carInfoRow == null) return;

            carSpecRow.ModelGradeNm = carInfoRow.ModelGradeNm;                     // グレード
            carSpecRow.BodyName = carInfoRow.BodyName;                             // ボディ
            carSpecRow.DoorCount = carInfoRow.DoorCount;                           // ドア
            carSpecRow.EDivNm = carInfoRow.EDivNm;                                 // Ｅ区分
            carSpecRow.EngineDisplaceNm = carInfoRow.EngineDisplaceNm;             // 排気量
            carSpecRow.EngineModelNm = carInfoRow.EngineModelNm;                   // エンジン
            carSpecRow.ShiftNm = carInfoRow.ShiftNm;                               // シフト
            carSpecRow.TransmissionNm = carInfoRow.TransmissionNm;                 // ミッション
            carSpecRow.WheelDriveMethodNm = carInfoRow.WheelDriveMethodNm;         // 駆動方式
            carSpecRow.AddiCarSpec1 = carInfoRow.AddiCarSpec1;                     // 追加諸元１
            carSpecRow.AddiCarSpec2 = carInfoRow.AddiCarSpec2;                     // 追加諸元２ 
            carSpecRow.AddiCarSpec3 = carInfoRow.AddiCarSpec3;                     // 追加諸元３
            carSpecRow.AddiCarSpec4 = carInfoRow.AddiCarSpec4;                     // 追加諸元４
            carSpecRow.AddiCarSpec5 = carInfoRow.AddiCarSpec5;                     // 追加諸元５
            carSpecRow.AddiCarSpec6 = carInfoRow.AddiCarSpec6;                     // 追加諸元６
        }

        #region ●カラー情報

        /// <summary>
        /// カラー情報キャッシュ
        /// </summary>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="colorCdInfoDataTable">カラー情報データテーブル</param>
        private void CacheColorInfo(string salesSlipNum, int salesRowNo, PMKEN01010E.ColorCdInfoDataTable colorCdInfoDataTable)
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(salesSlipNum, salesRowNo);
            if (this._colorInfoDic.ContainsKey(row.CarRelationGuid)) this._colorInfoDic.Remove(row.CarRelationGuid);
            this._colorInfoDic.Add(row.CarRelationGuid, colorCdInfoDataTable);
        }

        /// <summary>
        /// カラー情報取得処理
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <returns>カラー情報データテーブル</returns>
        public PMKEN01010E.ColorCdInfoDataTable GetColorInfo( int salesRowNo )
        {
            PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable = null;
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow != null)
            {
                colorInfoDataTable = this.GetColorInfo(salesDetailRow.CarRelationGuid);
            }
            return colorInfoDataTable;
        }

        /// <summary>
        /// カラー情報取得処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <returns>カラー情報データテーブル</returns>
        public PMKEN01010E.ColorCdInfoDataTable GetColorInfo( Guid carRelationGuid )
        {
            PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable = null;
            if (this._colorInfoDic.ContainsKey(carRelationGuid))
            {
                colorInfoDataTable = this._colorInfoDic[carRelationGuid];
            }
            return colorInfoDataTable;
        }

        /// <summary>
        /// 選択カラー情報取得処理
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <returns>カラー情報行オブジェクト</returns>
        public PMKEN01010E.ColorCdInfoRow GetSelectColorInfo( int salesRowNo )
        {
            PMKEN01010E.ColorCdInfoRow colorInfoRow = null;
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (salesDetailRow != null)
            {
                colorInfoRow = this.GetSelectColorInfo(salesDetailRow.CarRelationGuid);
            }
            return colorInfoRow;
        }

        /// <summary>
        /// 選択カラー情報取得処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <returns>カラー情報行オブジェクト</returns>
        public PMKEN01010E.ColorCdInfoRow GetSelectColorInfo( Guid carRelationGuid )
        {
            PMKEN01010E.ColorCdInfoRow colorInfoRow = null;
            if (this._colorInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable = this._colorInfoDic[carRelationGuid];
                PMKEN01010E.ColorCdInfoRow[] rows = (PMKEN01010E.ColorCdInfoRow[])colorInfoDataTable.Select(string.Format("{0}={1}", colorInfoDataTable.SelectionStateColumn.ColumnName, true));
                if (rows.Length > 0) colorInfoRow = rows[0];
            }
            return colorInfoRow;
        }

        /// <summary>
        /// カラー情報選択処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="colorCode">カラーコード</param>
        /// <returns>true:該当あり正常選択 false:該当なし</returns>
        public bool SelectColorInfo( Guid carRelationGuid, string colorCode )
        {
            bool ret = false;
            if (this._colorInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable = this._colorInfoDic[carRelationGuid];
                ret = this.SelectColorInfo(carRelationGuid, colorInfoDataTable, colorCode);
            }
            return ret;
        }

        /// <summary>
        /// カラー情報選択処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="colorInfoDataTable">カラー情報データテーブル</param>
        /// <param name="colorCode">カラーコード</param>
        /// <returns>true:該当あり正常選択 false:該当なし</returns>
        private bool SelectColorInfo( Guid carRelationGuid, PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable, string colorCode )
        {
            bool ret = false;
            this.SettingColorInfoAllState(colorInfoDataTable, false);   // 全明細選択解除
            this.ClearCarInfoRowForColorInfo(carRelationGuid);
            if (colorCode != string.Empty)
            {
                PMKEN01010E.ColorCdInfoRow[] rows = (PMKEN01010E.ColorCdInfoRow[])colorInfoDataTable.Select(string.Format("{0}='{1}'", colorInfoDataTable.ColorCodeColumn.ColumnName, colorCode));
                if (rows.Length > 0)
                {
                    PMKEN01010E.ColorCdInfoRow colorInfoRow = rows[0];
                    colorInfoRow.SelectionState = true;
                    this.SettingCarInfoRowFromColorInfo(carRelationGuid, colorInfoRow);
                    ret = true;
                }
                // --- ADD 2012/09/07 Y.Wakita ---------->>>>>
                else
                {
                    ret = this.SettingCarInfoRowFromColorCode(carRelationGuid, colorCode);
                }
                // --- ADD 2012/09/07 Y.Wakita ----------<<<<<
            }
            return ret;
        }

        // --- ADD 2012/09/11 Y.Wakita ---------->>>>>
        /// <summary>
        /// カラー情報選択処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="colorCode">カラーコード</param>
        /// <returns>true:該当あり正常選択 false:該当なし</returns>
        public bool SelectColorInfo2(Guid carRelationGuid, string colorCode)
        {
            bool ret = false;
            if (this._colorInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable = this._colorInfoDic[carRelationGuid];
                ret = this.SelectColorInfo2(carRelationGuid, colorInfoDataTable, colorCode);
            }
            return ret;
        }

        /// <summary>
        /// カラー情報選択処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="colorInfoDataTable">カラー情報データテーブル</param>
        /// <param name="colorCode">カラーコード</param>
        /// <returns>true:該当あり正常選択 false:該当なし</returns>
        private bool SelectColorInfo2(Guid carRelationGuid, PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable, string colorCode)
        {
            bool ret = false;
            this.SettingColorInfoAllState(colorInfoDataTable, false);   // 全明細選択解除
            this.ClearCarInfoRowForColorInfo(carRelationGuid);
            if (colorCode != string.Empty)
            {
                PMKEN01010E.ColorCdInfoRow[] rows = (PMKEN01010E.ColorCdInfoRow[])colorInfoDataTable.Select(string.Format("{0}='{1}'", colorInfoDataTable.ColorCodeColumn.ColumnName, colorCode));
                if (rows.Length > 0)
                {
                    PMKEN01010E.ColorCdInfoRow colorInfoRow = rows[0];
                    colorInfoRow.SelectionState = true;
                    this.SettingCarInfoRowFromColorInfo(carRelationGuid, colorInfoRow);
                    ret = true;
                }
                else
                {
                    // 車両情報行オブジェクト取得
                    EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
                    if (carInfoRow != null)
                    {
                        carInfoRow.ColorCode = colorCode;   // カラーコード
                        ret = true;
                    }
                }
            }
            return ret;
        }
        // --- ADD 2012/09/11 Y.Wakita ----------<<<<<

        /// <summary>
        /// カラー情報全明細選択／解除処理
        /// </summary>
        /// <param name="colorInfoDataTable">カラー情報データテーブル</param>
        /// <param name="state">選択状態</param>
        public void SettingColorInfoAllState( PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable, bool state )
        {
            foreach (PMKEN01010E.ColorCdInfoRow colorInfoRow in colorInfoDataTable)
            {
                colorInfoRow.SelectionState = state;
            }
        }

        #endregion

        #region ●トリム情報

        /// <summary>
        /// トリム情報キャッシュ
        /// </summary>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="trimCdInfoDataTable">トリム情報データテーブル</param>
        private void CacheTrimInfo(string salesSlipNum, int salesRowNo, PMKEN01010E.TrimCdInfoDataTable trimCdInfoDataTable)
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(salesSlipNum, salesRowNo);
            if (this._trimInfoDic.ContainsKey(row.CarRelationGuid)) this._trimInfoDic.Remove(row.CarRelationGuid);
            this._trimInfoDic.Add(row.CarRelationGuid, trimCdInfoDataTable);
        }

        /// <summary>
        /// トリム情報取得処理
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <returns>トリム情報データテーブル</returns>
        public PMKEN01010E.TrimCdInfoDataTable GetTrimInfo( int salesRowNo )
        {
            PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable = null;
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow != null)
            {
                trimInfoDataTable = this.GetTrimInfo(salesDetailRow.CarRelationGuid);
            }
            return trimInfoDataTable;
        }

        /// <summary>
        /// トリム情報取得処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <returns>トリム情報データテーブル</returns>
        public PMKEN01010E.TrimCdInfoDataTable GetTrimInfo( Guid carRelationGuid )
        {
            PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable = null;
            if (this._trimInfoDic.ContainsKey(carRelationGuid))
            {
                trimInfoDataTable = this._trimInfoDic[carRelationGuid];
            }
            return trimInfoDataTable;
        }

        /// <summary>
        /// 選択トリム情報取得処理
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <returns>トリム情報行オブジェクト</returns>
        public PMKEN01010E.TrimCdInfoRow GetSelectTrimInfo( int salesRowNo )
        {
            PMKEN01010E.TrimCdInfoRow trimInfoRow = null;
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (salesDetailRow != null)
            {
                trimInfoRow = this.GetSelectTrimInfo(salesDetailRow.CarRelationGuid);
            }
            return trimInfoRow;
        }

        /// <summary>
        /// 選択トリム情報取得処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <returns>トリム情報行オブジェクト</returns>
        public PMKEN01010E.TrimCdInfoRow GetSelectTrimInfo( Guid carRelationGuid )
        {
            PMKEN01010E.TrimCdInfoRow trimInfoRow = null;
            if (this._trimInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable = this._trimInfoDic[carRelationGuid];
                PMKEN01010E.TrimCdInfoRow[] rows = (PMKEN01010E.TrimCdInfoRow[])trimInfoDataTable.Select(string.Format("{0}={1}", trimInfoDataTable.SelectionStateColumn.ColumnName, true));
                if (rows.Length > 0) trimInfoRow = rows[0];
            }
            return trimInfoRow;
        }

        /// <summary>
        /// トリム情報選択処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="trimCode">トリムコード</param>
        /// <returns>true:該当あり正常選択 false:該当なし</returns>
        public bool SelectTrimInfo( Guid carRelationGuid, string trimCode )
        {
            bool ret = false;
            if (this._trimInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable = this._trimInfoDic[carRelationGuid];
                ret = this.SelectTrimInfo(carRelationGuid, trimInfoDataTable, trimCode);
            }
            return ret;
        }

        /// <summary>
        /// トリム情報選択処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="trimInfoDataTable">トリム情報データテーブル</param>
        /// <param name="trimCode">トリムコード</param>
        /// <returns>true:該当あり正常選択 false:該当なし</returns>
        public bool SelectTrimInfo( Guid carRelationGuid, PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable, string trimCode )
        {
            bool ret = false;
            this.SettingTrimInfoAllState(trimInfoDataTable, false); // 全明細選択解除
            this.ClearCarInfoRowForTrimInfo(carRelationGuid);
            if (trimCode != string.Empty)
            {
                PMKEN01010E.TrimCdInfoRow[] rows = (PMKEN01010E.TrimCdInfoRow[])trimInfoDataTable.Select(string.Format("{0}='{1}'", trimInfoDataTable.TrimCodeColumn.ColumnName, trimCode));
                if (rows.Length > 0)
                {
                    PMKEN01010E.TrimCdInfoRow trimInfoRow = rows[0];
                    trimInfoRow.SelectionState = true;
                    this.SettingCarInfoRowFromTrimInfo(carRelationGuid, trimInfoRow);
                    ret = true;
                }
                // --- ADD 2012/09/07 Y.Wakita ---------->>>>>
                else
                {
                    ret = this.SettingCarInfoRowFromTrimCode(carRelationGuid, trimCode);
                }
                // --- ADD 2012/09/07 Y.Wakita ----------<<<<<
            }
            return ret;
        }

        // --- ADD 2012/09/11 Y.Wakita ---------->>>>>
        /// <summary>
        /// トリム情報選択処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="trimCode">トリムコード</param>
        /// <returns>true:該当あり正常選択 false:該当なし</returns>
        public bool SelectTrimInfo2(Guid carRelationGuid, string trimCode)
        {
            bool ret = false;
            if (this._trimInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable = this._trimInfoDic[carRelationGuid];
                ret = this.SelectTrimInfo2(carRelationGuid, trimInfoDataTable, trimCode);
            }
            return ret;
        }

        /// <summary>
        /// トリム情報選択処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="trimInfoDataTable">トリム情報データテーブル</param>
        /// <param name="trimCode">トリムコード</param>
        /// <returns>true:該当あり正常選択 false:該当なし</returns>
        public bool SelectTrimInfo2(Guid carRelationGuid, PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable, string trimCode)
        {
            bool ret = false;
            this.SettingTrimInfoAllState(trimInfoDataTable, false); // 全明細選択解除
            this.ClearCarInfoRowForTrimInfo(carRelationGuid);
            if (trimCode != string.Empty)
            {
                PMKEN01010E.TrimCdInfoRow[] rows = (PMKEN01010E.TrimCdInfoRow[])trimInfoDataTable.Select(string.Format("{0}='{1}'", trimInfoDataTable.TrimCodeColumn.ColumnName, trimCode));
                if (rows.Length > 0)
                {
                    PMKEN01010E.TrimCdInfoRow trimInfoRow = rows[0];
                    trimInfoRow.SelectionState = true;
                    this.SettingCarInfoRowFromTrimInfo(carRelationGuid, trimInfoRow);
                    ret = true;
                }
                else
                {
                    // 車両情報行オブジェクト取得
                    EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
                    if (carInfoRow != null)
                    {
                        carInfoRow.TrimCode = trimCode; // トリムコード
                        ret = true;
                    }
                }
            }
            return ret;
        }
        // --- ADD 2012/09/11 Y.Wakita ----------<<<<<

        /// <summary>
        /// トリム情報全明細選択／解除処理
        /// </summary>
        /// <param name="trimInfoDataTable">トリム情報データテーブル</param>
        /// <param name="state">選択状態</param>
        public void SettingTrimInfoAllState( PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable, bool state )
        {
            foreach (PMKEN01010E.TrimCdInfoRow trimInfoRow in trimInfoDataTable)
            {
                trimInfoRow.SelectionState = state;
            }
        }

        #endregion

        #region ●装備情報

        /// <summary>
        /// 装備情報キャッシュ
        /// </summary>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="cEqpDefDspInfoDataTable">装備情報データテーブル</param>
        private void CacheEquipInfo(string salesSlipNum, int salesRowNo, PMKEN01010E.CEqpDefDspInfoDataTable cEqpDefDspInfoDataTable)
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(salesSlipNum, salesRowNo);
            if (this._cEqpDspInfoDic.ContainsKey(row.CarRelationGuid)) this._cEqpDspInfoDic.Remove(row.CarRelationGuid);
            this._cEqpDspInfoDic.Add(row.CarRelationGuid, cEqpDefDspInfoDataTable);
        }

        /// <summary>
        /// 装備情報取得処理
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <returns>装備情報データテーブル</returns>
        public PMKEN01010E.CEqpDefDspInfoDataTable GetEquipInfo( int salesRowNo )
        {
            PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable = null;
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow != null)
            {
                equipInfoDataTable = this.GetEquipInfo(salesDetailRow.CarRelationGuid);
            }
            return equipInfoDataTable;
        }

        /// <summary>
        /// 装備情報取得処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <returns>装備情報データテーブル</returns>
        public PMKEN01010E.CEqpDefDspInfoDataTable GetEquipInfo( Guid carRelationGuid )
        {
            PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable = null;
            if (this._cEqpDspInfoDic.ContainsKey(carRelationGuid))
            {
                equipInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];
            }
            return equipInfoDataTable;
        }

        /// <summary>
        /// 装備情報行オブジェクト配列取得
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <returns>装備情報バイト配列</returns>
        private byte[] GetEquipInfoRows( Guid carRelationGuid )
        {
            byte[] equipInfoRows = new byte[0];
            if (this._cEqpDspInfoDic.ContainsKey(carRelationGuid))
            {
                // 装備情報データテーブル取得
                PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];

                if (equipInfoDataTable != null)
                {
                    // 装備情報バイト配列
                    equipInfoRows = equipInfoDataTable.GetByteArray(true);
                }
            }
            return equipInfoRows;
        }

        /// <summary>
        /// 装備情報選択処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="key">装備キー</param>
        /// <param name="selectedIndex">選択位置</param>
        /// <returns></returns>
        public bool SelectEquipInfo( Guid carRelationGuid, string key, int selectedIndex )
        {
            bool ret = false;
            if (this._cEqpDspInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.CEqpDefDspInfoDataTable eqpDspInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];
                ret = this.SelectEquipInfo(carRelationGuid, eqpDspInfoDataTable, key, selectedIndex);
            }
            return ret;
        }

        /// <summary>
        /// 装備情報選択処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="categoryObjAry">装備情報配列</param>
        /// <br>Update Note: 2009/09/08②       汪千来</br>
        ///	<br>		   : 装備情報選択処理を改修する</br>
        private void SelectEquipInfo(Guid carRelationGuid, byte[] categoryObjAry)
        {
            if (( this._cEqpDspInfoDic.ContainsKey(carRelationGuid) ) && ( categoryObjAry != null ) && ( categoryObjAry.Length > 0 ))
            {
                PMKEN01010E.CEqpDefDspInfoDataTable eqpDspInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];
                // --- UPD 2009/09/08② -------------->>>
                // --- DEL 2009/09/08② -------------->>>
                //eqpDspInfoDataTable.SetTableFromByteArray(categoryObjAry);
                // --- DEL 2009/09/08② --------------<<<
                if (categoryObjAry.Length > 0)
                {
                    // 指定の装備を選択状態にする
                    eqpDspInfoDataTable.SetTableFromByteArray(categoryObjAry);
                }
                else
                {
                    // 全て解除
                    foreach (PMKEN01010E.CEqpDefDspInfoRow row in eqpDspInfoDataTable.Rows)
                    {
                        row.SelectionState = false;
                    }
                }
                // --- UPD 2009/09/08② --------------<<<
            }
        }

        /// <summary>
        /// 装備情報選択処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="eqpDspInfoDataTable">装備情報データテーブ</param>
        /// <param name="key">装備キー</param>
        /// <param name="selectedIndex">選択位置</param>
        /// <returns></returns>
        private bool SelectEquipInfo( Guid carRelationGuid, PMKEN01010E.CEqpDefDspInfoDataTable eqpDspInfoDataTable, string key, int selectedIndex )
        {
            bool ret = false;

            PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])eqpDspInfoDataTable.Select(string.Format("{0}='{1}'", eqpDspInfoDataTable.EquipmentGenreNmColumn.ColumnName, key));

            if (rows.Length > 0)
            {
                this.SettingEquipInfoAllState(eqpDspInfoDataTable, key, false);
                PMKEN01010E.CEqpDefDspInfoRow equipInfoRow = rows[selectedIndex];
                equipInfoRow.SelectionState = true;
                ret = true;
            }
            return ret;
        }


        /// <summary>
        ///  装備情報対象装備明細選択／解除処理
        /// </summary>
        /// <param name="equipInfoDataTable">装備情報データテーブル</param>
        /// <param name="key">装備情報キー</param>
        /// <param name="state">選択状態</param>
        public void SettingEquipInfoAllState( PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable, string key, bool state )
        {
            PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])equipInfoDataTable.Select(string.Format("{0}='{1}'", equipInfoDataTable.EquipmentGenreNmColumn.ColumnName, key));

            foreach (PMKEN01010E.CEqpDefDspInfoRow row in rows)
            {
                row.SelectionState = state;
            }
        }

        #endregion

        #region ●車種情報
        /// <summary>
        /// 車種名称取得処理
        /// </summary>
        /// <param name="makerCode">カーメーカーコード</param>
        /// <param name="modelCode">車種コード</param>
        /// <param name="modelSubCode">車種サブコード</param>
        /// <param name="modelFullName">車種名称</param>
        /// <param name="modelHalfName">車種半角名称</param>
        public bool GetModelName(int makerCode, int modelCode, int modelSubCode, out string modelFullName, out string modelHalfName)
        {
            modelFullName = string.Empty;
            modelHalfName = string.Empty;
            ModelNameU modelNameU = new ModelNameU();
            modelNameU = this.GetModelInfo(makerCode, modelCode, modelSubCode);

            if (modelNameU != null)
            {
                modelFullName = modelNameU.ModelFullName;
                modelHalfName = modelNameU.ModelHalfName;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 車種情報取得処理
        /// </summary>
        /// <param name="makerCode">カーメーカーコード</param>
        /// <param name="modelCode">車種コード</param>
        /// <param name="modelSubCode">車種サブコード</param>
        /// <returns></returns>
        public ModelNameU GetModelInfo( int makerCode, int modelCode, int modelSubCode )
        {
            ModelNameU modelNameU = null;

            if (( modelCode == 0 ) && ( modelSubCode == 0 )) return modelNameU;

            if (_modelNameUAcs == null) _modelNameUAcs = new ModelNameUAcs();
            int status = this._modelNameUAcs.Read(out modelNameU, this._enterpriseCode, makerCode, modelCode, modelSubCode);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) modelNameU = null;

            return modelNameU;
        }
        #endregion

        /// <summary>
        /// 車輌管理ワークオブジェクトリストを車輌情報テーブルから取得
        /// </summary>
        /// <param name="carManagementWorkList">車輌管理ワークオブジェクトリスト</param>
        private void GetCurrentCarManagementWorkList( out ArrayList carManagementWorkList )
        {
            //------------------------------------------------------------------------------------
            // リスト構成
            //------------------------------------------------------------------------------------
            // ArrayList                    車輌情報リスト
            //      --CarManagementWork     車輌管理ワークオブジェクト
            //------------------------------------------------------------------------------------
            carManagementWorkList = null;
            if (( this._carInfoDataTable != null ) && ( this._carInfoDataTable.Count != 0 ))
            {
                //-----------------------------------------------------
                // 車輌情報リスト取得
                //-----------------------------------------------------
                this.GetCarManagementWorkListFromCarInfoTable(this._carInfoDataTable, out carManagementWorkList);
            }
        }

        /// <summary>
        /// 車輌管理ワークオブジェクトリスト取得処理
        /// </summary>
        /// <param name="carInfoDataTable">車輌情報テーブル</param>
        /// <param name="carManagementWorkList">車輌管理ワークオブジェクトリスト</param>
        private void GetCarManagementWorkListFromCarInfoTable( EstimateInputDataSet.CarInfoDataTable carInfoDataTable, out ArrayList carManagementWorkList )
        {
            carManagementWorkList = new ArrayList();

            foreach (EstimateInputDataSet.CarInfoRow carInfoRow in carInfoDataTable)
            {
                CarManagementWork carManagementWork = this.GetParamDataFromCarInfoRow(carInfoRow);
                CarManagementWork clearCarManagementWork = new CarManagementWork();
                ArrayList differentList = carManagementWork.Compare(clearCarManagementWork);

                if (differentList.Count > 3)
                {
                    if (carManagementWork != null) carManagementWorkList.Add(carManagementWork);
                }
            }
        }

        /// <summary>
        /// 車輌管理ワークオブジェクト取得処理
        /// </summary>
        /// <param name="carManagementWork"></param>
        /// <param name="CarRelationGuid"></param>
        /// <param name="carManagementWorkList"></param>
        private void GetCarManagementWorkFromCarManagementWorkList( out CarManagementWork carManagementWork, Guid CarRelationGuid, ArrayList carManagementWorkList )
        {
            carManagementWork = null;

            if (( carManagementWorkList == null ) || ( carManagementWorkList.Count == 0 )) return;

            foreach (CarManagementWork cManagementWork in carManagementWorkList)
            {
                if (cManagementWork.CarRelationGuid == CarRelationGuid)
                {
                    carManagementWork = cManagementWork;
                    return;
                }
            }
            return;
        }

        /// <summary>
        /// 車輌管理ワークオブジェクトを車輌情報行オブジェクトから取得
        /// </summary>
        /// <param name="carInfoRow">車輌情報行オブジェクト</param>
        /// <returns></returns>
        /// <br>Update Note: 2009/09/08②       汪千来</br>
        ///	<br>		   : 車輌備考と車輌追加情報１と車輌追加情報２を追加する</br>
        private CarManagementWork GetParamDataFromCarInfoRow( EstimateInputDataSet.CarInfoRow carInfoRow )
        {
            CarManagementWork carManagementWork = new CarManagementWork();

            carManagementWork.EnterpriseCode = this._enterpriseCode;                // 企業コード
            carManagementWork.CustomerCode = this._salesSlip.CustomerCode;          // 得意先コード
            // --- UPD 2009/09/08② -------------->>>
            //carManagementWork.CarMngNo = carInfoRow.CarMngNo;                       // 車両管理番号
            CustomerInfo customerInfo = null;
            int customerstatus = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            if (this._salesSlip.CustomerCode == 0)
            {
                customerInfo = new CustomerInfo();
            }
            else
            {
                customerstatus = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, this._salesSlip.CustomerCode, true, false, out customerInfo);
            }
            if (customerInfo.CarMngDivCd == 0 || customerInfo.CarMngDivCd == 3)
            {
                carManagementWork.CarMngNo = 0;
            }
            else
            {
                carManagementWork.CarMngNo = carInfoRow.CarMngNo;                       // 車両管理番号
            }
            // --- UPD 2009/09/08② --------------<<<
            carManagementWork.CarMngCode = carInfoRow.CarMngCode;                   // 車輌管理コード
            carManagementWork.NumberPlate1Code = carInfoRow.NumberPlate1Code;       // 陸運事務所番号
            carManagementWork.NumberPlate1Name = carInfoRow.NumberPlate1Name;       // 陸運事務局名称
            carManagementWork.NumberPlate2 = carInfoRow.NumberPlate2;               // 車両登録番号（種別）
            carManagementWork.NumberPlate3 = carInfoRow.NumberPlate3;               // 車両登録番号（カナ）
            carManagementWork.NumberPlate4 = carInfoRow.NumberPlate4;               // 車両登録番号（プレート番号）
            carManagementWork.EntryDate = carInfoRow.EntryDate;                     // 登録年月日
            //int iyy = carInfoRow.ProduceTypeOfYearInput / 100;
            //int imm = carInfoRow.ProduceTypeOfYearInput % 100;
            //DateTime produceTypeOfYearInput = DateTime.MinValue;
            //if (( iyy != 0 ) && ( imm != 0 )) produceTypeOfYearInput = new DateTime(iyy, imm, 1);
            carManagementWork.FirstEntryDate = carInfoRow.ProduceTypeOfYearInput;   // 初年度
            carManagementWork.MakerCode = carInfoRow.MakerCode;                     // メーカーコード
            carManagementWork.MakerFullName = carInfoRow.MakerFullName;             // メーカー全角名称
            carManagementWork.MakerHalfName = carInfoRow.MakerHalfName;             // メーカー半角名称
            carManagementWork.ModelCode = carInfoRow.ModelCode;                     // 車種コード
            carManagementWork.ModelSubCode = carInfoRow.ModelSubCode;               // 車種サブコード
            carManagementWork.ModelFullName = carInfoRow.ModelFullName;             // 車種全角名称
            carManagementWork.ModelHalfName = carInfoRow.ModelHalfName;             // 車種半角名称
            carManagementWork.SystematicCode = carInfoRow.SystematicCode;           // 系統コード
            carManagementWork.SystematicName = carInfoRow.SystematicName;           // 系統名称
            carManagementWork.ProduceTypeOfYearCd = carInfoRow.ProduceTypeOfYearCd; // 生産年式コード
            carManagementWork.ProduceTypeOfYearNm = carInfoRow.ProduceTypeOfYearNm; // 生産年式名称
            carManagementWork.StProduceTypeOfYear = carInfoRow.StProduceTypeOfYear; // 開始生産年式
            carManagementWork.EdProduceTypeOfYear = carInfoRow.EdProduceTypeOfYear; // 終了生産年式
            carManagementWork.DoorCount = carInfoRow.DoorCount;                     // ドア数
            carManagementWork.BodyNameCode = carInfoRow.BodyNameCode;               // ボディー名コード
            carManagementWork.BodyName = carInfoRow.BodyName;                       // ボディー名称
            carManagementWork.ExhaustGasSign = carInfoRow.ExhaustGasSign;           // 排ガス記号
            carManagementWork.SeriesModel = carInfoRow.SeriesModel;                 // シリーズ型式
            carManagementWork.CategorySignModel = carInfoRow.CategorySignModel;     // 型式（類別記号）
            carManagementWork.FullModel = carInfoRow.FullModel;                     // 型式（フル型）
            carManagementWork.ModelDesignationNo = carInfoRow.ModelDesignationNo;   // 型式指定番号
            carManagementWork.CategoryNo = carInfoRow.CategoryNo;                   // 類別番号
            carManagementWork.FrameModel = carInfoRow.FrameModel;                   // 車台型式
            //carManagementWork.FrameNo = ( carInfoRow.ProduceFrameNoInput == 0 ) ? string.Empty : carInfoRow.ProduceFrameNoInput.ToString();  // 車台番号
            carManagementWork.FrameNo = carInfoRow.FrameNo;                         // 車台番号
            carManagementWork.SearchFrameNo = carInfoRow.SearchFrameNo;             // 車台番号（検索用）
            carManagementWork.StProduceFrameNo = carInfoRow.StProduceFrameNo;       // 生産車台番号開始
            carManagementWork.EdProduceFrameNo = carInfoRow.EdProduceFrameNo;       // 生産車台番号終了
            carManagementWork.ModelGradeNm = carInfoRow.ModelGradeNm;               // 型式グレード名称
            carManagementWork.EngineModelNm = carInfoRow.EngineModelNm;             // エンジン型式名称
            carManagementWork.EngineDisplaceNm = carInfoRow.EngineDisplaceNm;       // 排気量名称
            carManagementWork.EDivNm = carInfoRow.EDivNm;                           // E区分名称
            carManagementWork.TransmissionNm = carInfoRow.TransmissionNm;           // ミッション名称
            carManagementWork.ShiftNm = carInfoRow.ShiftNm;                         // シフト名称
            carManagementWork.WheelDriveMethodNm = carInfoRow.WheelDriveMethodNm;   // 駆動方式名称
            carManagementWork.AddiCarSpec1 = carInfoRow.AddiCarSpec1;               // 追加諸元1
            carManagementWork.AddiCarSpec2 = carInfoRow.AddiCarSpec2;               // 追加諸元2
            carManagementWork.AddiCarSpec3 = carInfoRow.AddiCarSpec3;               // 追加諸元3
            carManagementWork.AddiCarSpec4 = carInfoRow.AddiCarSpec4;               // 追加諸元4
            carManagementWork.AddiCarSpec5 = carInfoRow.AddiCarSpec5;               // 追加諸元5
            carManagementWork.AddiCarSpec6 = carInfoRow.AddiCarSpec6;               // 追加諸元6
            carManagementWork.AddiCarSpecTitle1 = carInfoRow.AddiCarSpecTitle1;     // 追加諸元タイトル1
            carManagementWork.AddiCarSpecTitle2 = carInfoRow.AddiCarSpecTitle2;     // 追加諸元タイトル2
            carManagementWork.AddiCarSpecTitle3 = carInfoRow.AddiCarSpecTitle3;     // 追加諸元タイトル3
            carManagementWork.AddiCarSpecTitle4 = carInfoRow.AddiCarSpecTitle4;     // 追加諸元タイトル4
            carManagementWork.AddiCarSpecTitle5 = carInfoRow.AddiCarSpecTitle5;     // 追加諸元タイトル5
            carManagementWork.AddiCarSpecTitle6 = carInfoRow.AddiCarSpecTitle6;     // 追加諸元タイトル6
            carManagementWork.RelevanceModel = carInfoRow.RelevanceModel;           // 関連型式
            carManagementWork.SubCarNmCd = carInfoRow.SubCarNmCd;                   // サブ車名コード
            carManagementWork.ModelGradeSname = carInfoRow.ModelGradeSname;         // 型式グレード略称
            carManagementWork.BlockIllustrationCd = carInfoRow.BlockIllustrationCd; // ブロックイラストコード
            carManagementWork.ThreeDIllustNo = carInfoRow.ThreeDIllustNo;           // 3DイラストNo
            carManagementWork.PartsDataOfferFlag = carInfoRow.PartsDataOfferFlag;   // 部品データ提供フラグ
            carManagementWork.InspectMaturityDate = carInfoRow.InspectMaturityDate; // 車検満期日
            carManagementWork.LTimeCiMatDate = carInfoRow.LTimeCiMatDate;           // 前回車検満期日
            carManagementWork.CarInspectYear = carInfoRow.CarInspectYear;           // 車検期間
            carManagementWork.Mileage = carInfoRow.Mileage;                         // 車両走行距離
            carManagementWork.CarNo = carInfoRow.CarNo;                             // 号車
            carManagementWork.FullModelFixedNoAry = carInfoRow.FullModelFixedNoAry; // フル型式固定番号配列
            // ----- ADD 2010/04/27 ----------------->>>>>
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            formatter.Serialize(ms, carInfoRow.FreeSrchMdlFxdNoAry);
            carManagementWork.FreeSrchMdlFxdNoAry = ms.GetBuffer(); // 自由検索型式固定番号配列
            ms.Close();
            // ----- ADD 2010/04/27 -----------------<<<<<
            carManagementWork.ColorCode = carInfoRow.ColorCode;                     // カラーコード
            carManagementWork.ColorName1 = carInfoRow.ColorName1;                   // カラー名称
            carManagementWork.TrimCode = carInfoRow.TrimCode;                       // トリムコード
            carManagementWork.TrimName = carInfoRow.TrimName;                       // トリム名称
            carManagementWork.CategoryObjAry = this.GetEquipInfoRows(carInfoRow.CarRelationGuid); // 装備オブジェクト配列
            carManagementWork.CarRelationGuid = carInfoRow.CarRelationGuid;         // 車両情報共通キー

            // --- ADD 2009/09/08② ---------->>>>>
            carManagementWork.CarAddInfo1 = carInfoRow.CarAddInfo1;         // 車輌追加情報１
            carManagementWork.CarAddInfo2 = carInfoRow.CarAddInfo2;         // 車輌追加情報２
            carManagementWork.CarNote = carInfoRow.CarNote;         // 車輌備考
            // --- ADD 2009/09/08② ---------->>>>>

            // --- ADD 2013/03/21 ---------->>>>>
            // PMNS:国産/外車区分セット
            carManagementWork.DomesticForeignCode = carInfoRow.DomesticForeignCode;
            // --- ADD 2013/03/21 ----------<<<<<

            return carManagementWork;
        }

        /// <summary>
        /// 車輌情報テーブル取得処理(車輌情報Dictionaryより取得)
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <returns>車輌検索結果データセット</returns>
        public PMKEN01010E GetCarInfoFromDic( int salesRowNo )
        {
            PMKEN01010E carInfoDataSet = null;
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (row != null)
            {
                carInfoDataSet = this.GetCarInfoFromDic(row.CarRelationGuid);
            }
            return carInfoDataSet;
        }

        /// <summary>
        /// 車輌情報テーブル取得処理(車輌情報Dictionaryより取得)
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <returns>車輌検索結果データセット</returns>
        private PMKEN01010E GetCarInfoFromDic( Guid carRelationGuid )
        {
            PMKEN01010E carInfoDataSet = null;
            if (this._carInfoDictionary.ContainsKey(carRelationGuid))
            {
                carInfoDataSet = this._carInfoDictionary[carRelationGuid];
            }
            return carInfoDataSet;
        }

        /// <summary>
        /// 車輌検索データテーブル年式設定処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="firstEntryDate">年式</param>
        public void SettingCarModelUIDataFromFirstEntryDate( Guid carRelationGuid, int firstEntryDate )
        {
            if (this._carInfoDictionary.ContainsKey(carRelationGuid))
            {
                this._carInfoDictionary[carRelationGuid].CarModelUIData[0].ProduceTypeOfYearInput = firstEntryDate / 100;
            }
        }

        /// <summary>
        /// 車輌検索データテーブル車台番号設定処理
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="frameNo">車台番号</param>
        public void SettingCarModelUIDataFromProduceFrameNo(Guid carRelationGuid, string frameNo)
        {
            if (this._carInfoDictionary.ContainsKey(carRelationGuid))
            {
                // ---UPD 2009/10/22 ----->>>>>
                if (this._carInfoDictionary[carRelationGuid].CarModelUIData.Count != 0)
                {
                    //this._carInfoDictionary[carRelationGuid].CarModelUIData[0].ProduceFrameNoInput = produceFrameNo;
                    this._carInfoDictionary[carRelationGuid].CarModelUIData[0].FrameNo = frameNo;
                    // --- DEL 2013/03/21 ---------->>>>>
                    //this._carInfoDictionary[carRelationGuid].CarModelUIData[0].SearchFrameNo = TStrConv.StrToIntDef(frameNo.Trim(), 0);
                    // --- DEL 2013/03/21 ----------<<<<<
                    // --- ADD 2013/03/21 ---------->>>>>
                    // PMNS:車台番号(検索用)設定
                    // 国産/外車区分が外車(2)の場合は車台番号(検索用)に0をセットする
                    if (this._carInfoDictionary[carRelationGuid].CarModelUIData[0].DomesticForeignCode == 2)
                    {
                        this._carInfoDictionary[carRelationGuid].CarModelUIData[0].SearchFrameNo = 0;
                    }
                    else
                    {
                    this._carInfoDictionary[carRelationGuid].CarModelUIData[0].SearchFrameNo = TStrConv.StrToIntDef(frameNo.Trim(), 0);
                }
                    // --- ADD 2013/03/21 ----------<<<<<
                }
                // ---UPD 2009/10/22 -----<<<<<
            }
        }

        /// <summary>
        /// 対象年式取得処理(車台番号より取得)
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="frameNo">車台番号</param>
        /// <returns>年式(int)</returns>
        public int GetProduceTypeOfYear( Guid carRelationGuid, int frameNo )
        {
            return this.GetProduceTypeOfYearProc(carRelationGuid, frameNo);
        }

        /// <summary>
        /// 対象年式取得処理(車台番号より取得)
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="frameNo">車台番号</param>
        /// <returns>年式(int)</returns>
        private int GetProduceTypeOfYearProc( Guid carRelationGuid, int frameNo )
        {
            int retDateTime = 0;
            PMKEN01010E carInfoDataSet = this.GetCarInfoFromDic(carRelationGuid);
            if (carInfoDataSet != null)
            {
                string filter = string.Format("{0}<={1} AND {2}>={3}",
                    carInfoDataSet.PrdTypYearInfo.StProduceFrameNoColumn.ColumnName, frameNo,
                    carInfoDataSet.PrdTypYearInfo.EdProduceFrameNoColumn.ColumnName, frameNo);
                PMKEN01010E.PrdTypYearInfoRow[] row = (PMKEN01010E.PrdTypYearInfoRow[])carInfoDataSet.PrdTypYearInfo.Select(filter);
                if (row.Length > 0) retDateTime = row[0].ProduceTypeOfYear;
            }
            return retDateTime * 100;
        }

        /// <summary>
        /// 生産年式範囲チェック
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="firstEntryDate">年式</param>
        /// <returns>true:範囲内 false:範囲外</returns>
        public bool CheckProduceTypeOfYearRange( Guid carRelationGuid, int firstEntryDate )
        {
            bool ret = true;

            if (firstEntryDate != 0)
            {
                firstEntryDate = firstEntryDate / 100 * 100;
                int fyy = firstEntryDate / 10000;
                int fmm = firstEntryDate / 100 % 100;

                EstimateInputDataSet.CarInfoRow row = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
                int styy = row.StProduceTypeOfYear.Year;
                int stmm = row.StProduceTypeOfYear.Month;
                int edyy = row.EdProduceTypeOfYear.Year;
                int edmm = row.EdProduceTypeOfYear.Month;
                int st = 0;
                int ed = 0;
                if (fmm != 0)
                {
                    // 年月でチェック
                    st = styy * 10000 + stmm * 100;
                    ed = edyy * 10000 + edmm * 100;
                }
                else
                {
                    // 年のみでチェック
                    st = styy * 10000;
                    ed = edyy * 10000;
                }

                if (row.StProduceTypeOfYear != DateTime.MinValue) if (firstEntryDate < st) ret = false;

                if (row.EdProduceTypeOfYear != DateTime.MinValue) if (firstEntryDate > ed) ret = false;
            }
            return ret;
        }

        // 2009.06.18 Add >>>
        /// <summary>
        /// 車台番号範囲チェック
        /// </summary>
        /// <param name="carRelationGuid">車両情報共通キー</param>
        /// <param name="inputFrameNo">車台番号入力文字列</param>
        /// <param name="searchFrameNo">車台番号</param>
        /// <returns>True:範囲内、False:範囲外</returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 DEL
        //public bool CheckProduceFrameNo(Guid carRelationGuid, int searchFrameNo)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
        public bool CheckProduceFrameNo( Guid carRelationGuid, string inputFrameNo, int searchFrameNo )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
        {
            bool ret = true;

            EstimateInputDataSet.CarInfoRow row = this._carInfoDataTable.FindByCarRelationGuid( carRelationGuid );

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.14 DEL
            //if (row != null && searchFrameNo != 0)
            //{
            //    if (( row.StProduceFrameNo != 0 && row.StProduceFrameNo > searchFrameNo ) ||
            //        ( row.EdProduceFrameNo != 0 && row.EdProduceFrameNo < searchFrameNo )) ret = false;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.14 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.14 ADD
            if ( row != null )
            {
                if ( searchFrameNo != 0 || !string.IsNullOrEmpty( inputFrameNo ) )
                {
                    if ( (row.StProduceFrameNo != 0 && row.StProduceFrameNo > searchFrameNo) ||
                        (row.EdProduceFrameNo != 0 && row.EdProduceFrameNo < searchFrameNo) ) ret = false;
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.14 ADD

            return ret;
        }
        // 2009.06.18 Add <<<

        /// <summary>
        /// 車輌検索(車輌検索抽出条件より検索)
        /// </summary>
        /// <param name="carSearchCondition">車輌検索抽出条件</param>
        /// <param name="carInfoDataSet">車輌検索データセット</param>
        /// <returns>CarSearchResultReport</returns>
        public CarSearchResultReport SearchCar( CarSearchCondition carSearchCondition, ref PMKEN01010E carInfoDataSet )
        {
            return this._carSearchController.Search(carSearchCondition, ref carInfoDataSet);
        }

        /// <summary>
        /// 車輌検索(フル型式固定番号より検索)
        /// </summary>
        /// <param name="fullModelFixedNo">フル型式固定番号配列</param>
        /// <param name="modelDesignationNo">型式指定番号(未設定可)</param>
        /// <param name="categoryNo">類別区分番号(未設定可)</param>
        /// <param name="carInfoDataSet">車輌検索データセット</param>
        /// <returns>CarSearchResultReport</returns>
        /// <remarks>型式指定番号および類別区分番号は、類別検索によるフル型式固定番号配列の場合のみ必須</remarks>
        // --- UPD m.suzuki 2010/05/21 ---------->>>>>
        //public CarSearchResultReport SearchCar( int[] fullModelFixedNo, int modelDesignationNo, int categoryNo, ref PMKEN01010E carInfoDataSet )
        public CarSearchResultReport SearchCar(int[] fullModelFixedNo, string[] freeSrchMdlFxdNo, int modelDesignationNo, int categoryNo, ref PMKEN01010E carInfoDataSet)
        // --- UPD m.suzuki 2010/05/21 ----------<<<<<
        {
            CarSearchResultReport ret = CarSearchResultReport.retFailed;
            // --- UPD m.suzuki 2010/05/21 ---------->>>>>
            //if (fullModelFixedNo.Length != 0)
            if (fullModelFixedNo.Length != 0 || freeSrchMdlFxdNo.Length != 0)
            // --- UPD m.suzuki 2010/05/21 ----------<<<<<
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 UPD
                //ret = this._carSearchController.SearchByFullModelFixedNo(fullModelFixedNo, modelDesignationNo, categoryNo, ref carInfoDataSet);

                CarSearchCondition carSearchCond = new CarSearchCondition();
                carSearchCond.ModelDesignationNo = modelDesignationNo;
                carSearchCond.CategoryNo = categoryNo;
                // --- UPD m.suzuki 2010/05/21 ---------->>>>>
                //ret = this._carSearchController.SearchByFullModelFixedNo( fullModelFixedNo, carSearchCond, ref carInfoDataSet );
                ret = this._carSearchController.SearchByFullModelFixedNo(fullModelFixedNo, freeSrchMdlFxdNo, carSearchCond, ref carInfoDataSet);
                // --- UPD m.suzuki 2010/05/21 ----------<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 UPD
            }
            return ret;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 ADD
        /// <summary>
        /// 車輌検索(フル型式固定番号より検索)
        /// </summary>
        /// <param name="fullModelFixedNo">フル型式固定番号配列</param>
        /// <param name="carSearchCond">車輌検索条件クラス</param>
        /// <param name="carInfoDataSet">車輌検索データセット</param>
        /// <returns>CarSearchResultReport</returns>
        /// <remarks>型式指定番号および類別区分番号は、類別検索によるフル型式固定番号配列の場合のみ必須</remarks>
        // --- UPD m.suzuki 2010/05/21 ---------->>>>>
        //public CarSearchResultReport SearchCar( int[] fullModelFixedNo, CarSearchCondition carSearchCond, ref PMKEN01010E carInfoDataSet )
        public CarSearchResultReport SearchCar(int[] fullModelFixedNo, string[] freeSrchMdlFxdNo, CarSearchCondition carSearchCond, ref PMKEN01010E carInfoDataSet)
        // --- UPD m.suzuki 2010/05/21 ----------<<<<<
        {
            CarSearchResultReport ret = CarSearchResultReport.retFailed;
            // --- UPD m.suzuki 2010/05/21 ---------->>>>>
            //if ( fullModelFixedNo.Length != 0 )
            if (fullModelFixedNo.Length != 0 || freeSrchMdlFxdNo.Length != 0)
            // --- UPD m.suzuki 2010/05/21 ----------<<<<<
            {
                // --- UPD m.suzuki 2010/05/21 ---------->>>>>
                //ret = this._carSearchController.SearchByFullModelFixedNo( fullModelFixedNo, carSearchCond, ref carInfoDataSet );
                ret = this._carSearchController.SearchByFullModelFixedNo(fullModelFixedNo, freeSrchMdlFxdNo, carSearchCond, ref carInfoDataSet);
                // --- UPD m.suzuki 2010/05/21 ----------<<<<<
            }
            return ret;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 ADD

        // --- ADD 2013/03/21 ---------->>>>>
        /// <summary>
        /// ハンドル位置チェック
        /// </summary>
        /// <param name="carRelationGuid">車輌情報共通キー</param>
        /// <param name="vinCode">VINコード</param>
        /// <returns>true:一致 false:不一致</returns>
        public bool CheckHandlePosition(Guid carRelationGuid, string vinCode)
        {
            // キャッシュの有無をチェック
            if (this._carInfoDictionary.ContainsKey(carRelationGuid))
            {
                try
                {
                    // VINコードからハンドル位置を取得(右/左ハンドル以外の場合はチェックを行わない)
                    HandleInfoCdRet posVin = this._carSearchController.GetHandlePositionFromVinCode(vinCode);
                    if (posVin != HandleInfoCdRet.PositionRight && posVin != HandleInfoCdRet.PositionLeft)
                        return true;

                    // 型式検索で選択されているすべての行を比較する
                    int pos = this._carInfoDictionary[carRelationGuid].CarModelInfo.HandleInfoCdColumn.Ordinal;
                    int state = this._carInfoDictionary[carRelationGuid].CarModelInfo.SelectionStateColumn.Ordinal;
                    foreach (DataRow row in this._carInfoDictionary[carRelationGuid].CarModelInfo.Rows)
                    {
                        // 選択されていない行はスキップする
                        if ((bool)row[state] != true)
                            continue;

                        // 右/左ハンドル以外が1件でもあった場合は処理を中断し、位置のチェックを行わない
                        HandleInfoCdRet posKind = (HandleInfoCdRet)row[pos];
                        if (posKind != HandleInfoCdRet.PositionRight && posKind != HandleInfoCdRet.PositionLeft)
                            return true;

                        // ハンドル位置を比較する
                        if (posKind == posVin)
                        {
                            // 1件でもハンドル位置が一致している場合、一致とする
                            return true;
                        }
                    }

                    // すべての行のハンドル位置が異なる場合、不一致とする
                    return false;
                }
                catch
                {
                    // 例外が発生した場合はチェックを行わない
                }
            }

            return true;
        }
        // --- ADD 2013/03/21 ----------<<<<<
        #endregion

        // ===================================================================================== //
        // 優良部品情報
        // ===================================================================================== //
        #region ●優良部品情報

        /// <summary>
        /// 優良情報選択処理
        /// </summary>
        /// <param name="primeRelationGuid">優良情報連結GUID</param>
        /// <param name="joinDispOrder">結合表示順位</param>
        /// <returns>true:該当あり正常選択 false:該当なし</returns>
        public bool SelectPrimeInfo( Guid primeRelationGuid, int joinDispOrder )
        {
            return  this.SelectPrimeInfo(this._primeInfoDataTable, primeRelationGuid, joinDispOrder);
        }

        /// <summary>
        /// 優良情報選択処理
        /// </summary>
        /// <param name="primeInfoDataTable">優良情報データテーブル</param>
        /// <param name="primeRelationGuid">優良情報連結GUID</param>
        /// <param name="joinDispOrder">結合表示順位</param>
        /// <returns>true:該当あり正常選択 false:該当なし</returns>
        private bool SelectPrimeInfo( EstimateInputDataSet.PrimeInfoDataTable primeInfoDataTable, Guid primeRelationGuid, int joinDispOrder )
        {
            bool ret = false;

            if (primeRelationGuid != Guid.Empty)
            {
                this.SettingPrimeInfoAllState(primeInfoDataTable, primeRelationGuid, false);   // 全明細選択解除

                EstimateInputDataSet.PrimeInfoRow row = primeInfoDataTable.FindByPrimeInfoRelationGuidJoinDispOrder(primeRelationGuid, joinDispOrder);

                if (row!=null)
                {
                    row.SelectionState = true;
                    ret = true;
                }
            }
            
            return ret;
        }


        /// <summary>
        /// 優良情報明細選択／解除処理
        /// </summary>
        /// <param name="primeInfoDataTable">優良情報データテーブル</param>
        /// <param name="primeRelationGuid">優良情報連結GUID</param>
        /// <param name="state">選択状態</param>
        private void SettingPrimeInfoAllState( EstimateInputDataSet.PrimeInfoDataTable primeInfoDataTable,Guid primeRelationGuid, bool state )
        {
            EstimateInputDataSet.PrimeInfoRow[] primeInfoRowArray = (EstimateInputDataSet.PrimeInfoRow[])primeInfoDataTable.Select(string.Format("{0}='{1}'", primeInfoDataTable.PrimeInfoRelationGuidColumn.ColumnName, primeRelationGuid));
            if (( primeInfoRowArray != null ) && ( primeInfoRowArray.Length > 0 ))
            {
                foreach (EstimateInputDataSet.PrimeInfoRow row in primeInfoRowArray)
                {
                    row.SelectionState = false;
                }
            }
        }

        /// <summary>
        /// 優良データのデータテーブル生成
        /// </summary>
        /// <param name="primeInfoRelationGuid">優良情報連結GUID</param>
        /// <param name="goodsSearchDiv">商品検索区分</param>
        /// <param name="genuinePartsRet"></param>
        /// <param name="partsInfoLinkGuid">部品情報リンクGUID</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="warehouseCodeArray">倉庫配列</param>
        /// <param name="searchBLGoodsCode">検索BL商品コード</param>
        /// <br>Note       : 用品入力時の売価計算でエラー発生する件の修正</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/02/14</br>
        /// <br>Update Note: 2013/02/20 譚洪</br>
        /// <br>管理番号   : 10801804-00、2013/03/13配信分</br>
        /// <br>             Redmine#34434 No.1180 現在庫数が０のとき在庫数が空白で表示されるの対応</br>
        private void MakePrimeInfoTable( Guid primeInfoRelationGuid, GoodsSearchDiv goodsSearchDiv, GenuinePartsRet genuinePartsRet, Guid partsInfoLinkGuid, PartsInfoDataSet partsInfoDataSet , string[] warehouseCodeArray,int searchBLGoodsCode )
        {
            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "START");
                
            this._primeInfoDataTable.BeginLoadData();

            this.DeletePrimeInfoRow(primeInfoRelationGuid);

            int dispOrder = 1;
            int firstJoinDispOrder = 0;

            // 印刷用BLコードの決定
            // BLコード検索、印刷用BL商品コード区分「検索」、BLコード有り
            int prtBLGoodsCode = 0;
            string prtBLGoodsName = string.Empty;
            if (( goodsSearchDiv == GoodsSearchDiv.BLPartsSearch ) &&
                ( this._estimateInputInitDataAcs.GetSalesTtlSt().PrtBLGoodsCodeDiv == 1 ) &&
                ( searchBLGoodsCode > 0 ))
            {
                prtBLGoodsCode = searchBLGoodsCode;
                string blGoodsHalfName;
                this._estimateInputInitDataAcs.GetName_FromBLGoods(searchBLGoodsCode, out prtBLGoodsName, out blGoodsHalfName);
            }

            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "結合取得 START");
            List<GoodsUnitData> goodsUnitDataList = partsInfoDataSet.GetGoodsList(genuinePartsRet.PrimePartsList);
            //List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(false, this._estimateInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd).ToArray(typeof(GoodsUnitData)));
            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "結合取得 END" + goodsUnitDataList.Count.ToString());

            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "不足設定 START");
            this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true);
            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "不足設定 END");

            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "単価計算 START");
            List<UnitPriceCalcRet> unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);
            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "単価計算 END" + goodsUnitDataList.Count.ToString());

            foreach (PrimePartsRet primePartsRet in genuinePartsRet.PrimePartsList)
            {
                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1つ展開 START");

                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1つ展開 商品確定 START");
                GoodsUnitData goodsUnitData = null;
                if (goodsUnitDataList != null)
                {
                    // --- UPD 2011/02/14---------->>>>>
                    //foreach ( GoodsUnitData goodsUnitDataWk in goodsUnitDataList )
                    //{
                    //    if ( (goodsUnitDataWk.GoodsNo == primePartsRet.GoodsNo) &&
                    //        (goodsUnitDataWk.GoodsMakerCd == primePartsRet.GoodsMakerCd) )
                    //    {
                    //        goodsUnitData = goodsUnitDataWk;
                    //    }
                    //}
                    goodsUnitData = goodsUnitDataList.Find(
                            delegate(GoodsUnitData goodsUnitDataWk)
                            {
                                return ((goodsUnitDataWk.GoodsNo == primePartsRet.GoodsNo) &&
                                        (goodsUnitDataWk.GoodsMakerCd == primePartsRet.GoodsMakerCd));
                            }
                        );
                    // --- UPD 2011/02/14----------<<<<<
                }
                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1つ展開 商品確定 END");

                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1つ展開 プロパティコピー START");
                //if (goodsUnitData == null) goodsUnitData = (GoodsUnitData)DBAndXMLDataMergeParts.CopyPropertyInClass(primePartsRet, typeof(GoodsUnitData));
                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1つ展開 プロパティコピー END");

                //EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1つ展開 不足設定 START");
                //this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitData, true);
                //EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1つ展開 不足設定 END");

                EstimateInputDataSet.PrimeInfoRow row = this._primeInfoDataTable.NewPrimeInfoRow();

                row.PrimeInfoRelationGuid = primeInfoRelationGuid;
                row.JoinDispOrder = dispOrder;
                row.JoinSrcPartsNoNoneH = primePartsRet.JoinSourPartsNoNoneH;
                row.JoinSrcPartsNoWithH = primePartsRet.JoinSourPartsNoWithH;
                row.JoinSourceMakerCode = primePartsRet.JoinSourceMakerCode;
                row.JoinSpecialNote = primePartsRet.JoinSpecialNote;

                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                row.PrmSetDtlName2 = primePartsRet.PrmSetDtlName2;
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                row.GoodsNo = goodsUnitData.GoodsNo;                                // 品番
                row.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                      // メーカーコード
                row.MakerName = goodsUnitData.MakerName;                            // メーカー名称
                row.MakerKanaName = goodsUnitData.MakerKanaName;                    // メーカー名称カナ
                row.GoodsName = goodsUnitData.GoodsName;                            // 品名
                row.GoodsNameKana = goodsUnitData.GoodsNameKana;                    // 品名カナ
                row.GoodsKindCode = goodsUnitData.GoodsKindCode;                    // 商品属性
                row.GoodsLGroup = goodsUnitData.GoodsLGroup;                        // 商品大分類名称
                row.GoodsLGroupName = goodsUnitData.GoodsLGroupName;                // 商品大分類コード
                row.GoodsMGroup = goodsUnitData.GoodsMGroup;                        // 商品中分類コード
                row.GoodsMGroupName = goodsUnitData.GoodsMGroupName;                // 商品中分類名称
                row.BLGroupCode = goodsUnitData.BLGroupCode;                        // BLグループコード
                row.BLGroupName = goodsUnitData.BLGroupName;                        // BLグループコード名称
                row.BLGoodsCode = goodsUnitData.BLGoodsCode;                        // BL商品コード
                row.BLGoodsFullName = goodsUnitData.BLGoodsFullName;                // BL商品コード名称（全角）
                row.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;        // 自社分類コード
                row.EnterpriseGanreName = goodsUnitData.EnterpriseGanreName;        // 自社分類名称
                row.GoodsRateRank = goodsUnitData.GoodsRateRank;                    // 商品掛率ランク
                row.RateBLGoodsCode = goodsUnitData.BLGoodsCode;                    // BL商品コード（掛率）
                row.RateBLGoodsName = goodsUnitData.BLGoodsFullName;                // BL商品コード名称（掛率）
                row.RateGoodsRateGrpCd = goodsUnitData.GoodsRateGrpCode;            // 商品掛率グループコード（掛率）
                row.RateGoodsRateGrpNm = goodsUnitData.GoodsRateGrpName;            // 商品掛率グループ名称（掛率）
                row.RateBLGroupCode = goodsUnitData.BLGroupCode;                    // BLグループコード（掛率）
                row.RateBLGroupName = goodsUnitData.BLGroupName;                    // BLグループ名称（掛率）
                row.TaxationDivCd = goodsUnitData.TaxationDivCd;                    // 課税区分
                // 2009/11/25 Add >>>
                row.SalesCode = goodsUnitData.SalesCode;                            // 販売区分コード
                row.SalesCdNm = goodsUnitData.SalesCodeName;                        // 販売区分名称
                // 2009/11/25 Add <<<

                row.SupplierCd = goodsUnitData.SupplierCd;                          // 仕入先コード
                row.SupplierSnm = goodsUnitData.SupplierSnm;                        // 仕入先名称

                row.PrtBLGoodsCode = ( prtBLGoodsCode == 0 ) ? goodsUnitData.BLGoodsCode : prtBLGoodsCode;
                row.PrtBLGoodsName = ( prtBLGoodsCode == 0 ) ? goodsUnitData.BLGoodsFullName : prtBLGoodsName;

                row.ShipmentCnt = partsInfoDataSet.GetJoinQty(primePartsRet.JoinSourceMakerCode, primePartsRet.JoinSourPartsNoWithH, row.GoodsMakerCd, row.GoodsNo);

                row.PartsInfoLinkGuid = partsInfoLinkGuid;
                row.DtlRelationGuid = Guid.NewGuid();
                row.UOEOrderGuid = Guid.Empty;

                row.ExistSetInfo = partsInfoDataSet.UsrSetParts.SetExist(row.GoodsMakerCd, row.GoodsNo);

                row.GoodsSearchDivCd = (int)goodsSearchDiv;

                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                GoodsPrice goodsPrice = this._estimateInputInitDataAcs.GetGoodsPrice(this._salesSlip.SalesDate, goodsUnitData);
                if (goodsPrice != null) row.OpenPriceDiv = goodsPrice.OpenPriceDiv; // オープン価格区分
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // ADD 2012/08/20 2012/09/12配信 システムテスト障害№8対応 ------------------------>>>>>
                row.GoodsSpecialNote = primePartsRet.GoodsSpecialNote;
                // ADD 2012/08/20 2012/09/12配信 システムテスト障害№8対応 ------------------------<<<<<
                // ADD 2012/09/13 2012/09/19配信 SCM障害一覧№125対応 ------------------------------>>>>>
                if (primePartsRet.GoodsSpecialNote.Length > 40) row.GoodsSpecialNote = primePartsRet.GoodsSpecialNote.Substring(0, 40);
                // ADD 2012/09/13 2012/09/19配信 SCM障害一覧№125対応 ------------------------------<<<<<

                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1つ展開 単価情報設定 START");
                // 単価情報設定
                this.PrimeInfoRowPriceInfoSettingFromUnitPriceCalcRetList(row, unitPriceCalcRetList, false, false, true, true);
                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1つ展開 単価情報設定 END");

                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1つ展開 在庫 START");
                if (( goodsUnitData.StockList != null ) &&
                    ( goodsUnitData.StockList.Count > 0 ))
                {
                    this.CacheStockInfo(goodsUnitData.StockList);

                    if (( warehouseCodeArray != null ) && ( warehouseCodeArray.Length > 0 ))
                    {
                        Stock stock = this._estimateInputInitDataAcs.GetStockFromGoodsUnitData(goodsUnitData, warehouseCodeArray);
                        if (stock != null)
                        {
                            row.WarehouseCode = stock.WarehouseCode.Trim();
                            row.WarehouseName = stock.WarehouseName;
                            row.WarehouseShelfNo = stock.WarehouseShelfNo;
                            //row.ShipmentPosCnt = stock.ShipmentPosCnt;   // DEL 2013/02/20 tanh Redmine#34434 No.1180 

                            // ADD 2013/02/20 tanh Redmine#34434 No.1180 ---- >>>>>>>>>>>>
                            if (string.IsNullOrEmpty(stock.WarehouseCode.Trim()))
                            {
                                row.ShipmentPosCnt = string.Empty;
                            }
                            else
                            {
                                row.ShipmentPosCnt = stock.ShipmentPosCnt.ToString("N");
                            }
                            // ADD 2013/02/20 tanh Redmine#34434 No.1180 ---- <<<<<<<<<<<<
                        }
                    }
                }
                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1つ展開 在庫 END");

                this.CalculateCost(row);

                this._primeInfoDataTable.AddPrimeInfoRow(row);

                if (firstJoinDispOrder == 0) firstJoinDispOrder = dispOrder;

                dispOrder++;

                // 商品情報をキャッシュ
                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1つ展開 キャッシュSTART");
                this.CacheGoodsUnitData(goodsUnitData);
                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1つ展開 キャッシュEND");

                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1つ展開 END");
            }

            this._primeInfoDataTable.EndLoadData();
            // 1行目を選択
            this.SelectPrimeInfo(primeInfoRelationGuid, firstJoinDispOrder);
            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "END");
        }

        /// <summary>
        /// PrimeInfoRelationGuidが対象GUIDの優良データを削除します。
        /// </summary>
        /// <param name="primeInfoRelationGuid">優良情報連結GUID</param>
        private void DeletePrimeInfoRow( Guid primeInfoRelationGuid )
        {
            if (this._primeInfoControlView == null)
            {
                this._primeInfoControlView = new DataView(this._primeInfoDataTable);
            }

            this._primeInfoControlView.RowFilter = string.Format("{0}='{1}'", this._primeInfoDataTable.PrimeInfoRelationGuidColumn.ColumnName, primeInfoRelationGuid.ToString());

            // 対象GUIDの優良情報が存在する場合は削除
            if (this._primeInfoControlView.Count > 0)
            {
                while (this._primeInfoControlView.Count > 0)
                {
                    this._primeInfoControlView.Delete(0);
                }
            }
        }

        /// <summary>
        /// 優良情報データテーブルColumnChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrimeInfoTableDataTable_ColumnChanged( object sender, DataColumnChangeEventArgs e )
        {
            if (e.Column.ColumnName == this._primeInfoDataTable.SelectionStateColumn.ColumnName)
            {
                if (e.ProposedValue is bool)
                {
                    if ((bool)e.ProposedValue == true)
                    {
                        EstimateInputDataSet.PrimeInfoRow row = (EstimateInputDataSet.PrimeInfoRow)e.Row;

                        EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows = (EstimateInputDataSet.EstimateDetailRow[])this._estimateDetailDataTable.Select(string.Format("{0}='{1}'", this._estimateDetailDataTable.PrimeInfoRelationGuidColumn.ColumnName, row.PrimeInfoRelationGuid));

                        if (( estimateDetailRows != null ) && ( estimateDetailRows.Length > 0 ))
                        {
                            this.SettingEstimateDetailRowFromPrimeInfoRow(ref estimateDetailRows[0], row);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 優良部品連結Guidの選択されている優良部品情報を取得します。
        /// </summary>
        /// <param name="primeRelationGuid"></param>
        /// <returns></returns>
        private EstimateInputDataSet.PrimeInfoRow GetSelectedPrimeInfoRow( Guid primeRelationGuid )
        {
            EstimateInputDataSet.PrimeInfoRow[] rows = this.SelectPrimeInfoRows(string.Format("{0}='{1}' AND {2}={3}", this._primeInfoDataTable.PrimeInfoRelationGuidColumn.ColumnName, primeRelationGuid, this._primeInfoDataTable.SelectionStateColumn.ColumnName, true), this._primeInfoDataTable);

            return ( rows != null && rows.Length > 0 ) ? rows[0] : null;
        }

        /// <summary>
        /// 指定した優良部品連結Guidの優良部品行リストを取得します。
        /// </summary>
        /// <param name="primeRelationGuid"></param>
        /// <returns></returns>
        private EstimateInputDataSet.PrimeInfoRow[] GetPrimeInfoRows(Guid primeRelationGuid)
        {
            EstimateInputDataSet.PrimeInfoRow[] rows = this.SelectPrimeInfoRows(string.Format("{0}='{1}'", this._primeInfoDataTable.PrimeInfoRelationGuidColumn.ColumnName, primeRelationGuid), this._primeInfoDataTable);

            return rows;
        }

        /// <summary>
        /// 指定したフィルタ文字列を使用して優良情報データテーブルの選択を行い、該当する優良情報行オブジェクト配列を取得します。
        /// </summary>
        /// <param name="filterExpression">フィルタをかけるための基準となる文字列</param>
        /// <param name="primeInfoDataTable">優良情報データテーブルオブジェクト</param>
        /// <returns>見積明細行オブジェクト配列</returns>
        public EstimateInputDataSet.PrimeInfoRow[] SelectPrimeInfoRows(string filterExpression, EstimateInputDataSet.PrimeInfoDataTable primeInfoDataTable)
        {
            EstimateInputDataSet.PrimeInfoRow[] primInfoRowArray = null;

            try
            {
                DataRow[] rowArray = primeInfoDataTable.Select(filterExpression);

                if (rowArray != null)
                {
                    primInfoRowArray = (EstimateInputDataSet.PrimeInfoRow[])rowArray;
                }
            }
            catch { }

            return primInfoRowArray;
        }


        /// <summary>
        /// 優良情報データ行オブジェクトから見積明細データ行オブジェクトを設定します。
        /// </summary>
        /// <param name="estimateDetailRow"></param>
        /// <param name="primeInfoRow"></param>
        /// <remarks>
        /// <br>Update Note : 2011/07/26 高峰</br>
        /// <br>              検索見積印刷時の不具合の対応</br>
        /// <br>Update Note: 2013/02/20 譚洪</br>
        /// <br>管理番号   : 10801804-00、2013/03/13配信分</br>
        /// <br>             Redmine#34434 No.1180 現在庫数が０のとき在庫数が空白で表示されるの対応</br>
        /// </remarks>
        private void SettingEstimateDetailRowFromPrimeInfoRow( ref EstimateInputDataSet.EstimateDetailRow estimateDetailRow, EstimateInputDataSet.PrimeInfoRow primeInfoRow )
        {
            if (primeInfoRow != null)
            {
                estimateDetailRow.GoodsKindCode_Prime = primeInfoRow.GoodsKindCode;                     // 商品属性
                estimateDetailRow.GoodsSearchDivCd_Prime = primeInfoRow.GoodsSearchDivCd;               // 商品検索区分
                estimateDetailRow.GoodsMakerCd_Prime = primeInfoRow.GoodsMakerCd;                       // 商品メーカーコード
                estimateDetailRow.MakerName_Prime = primeInfoRow.MakerName;                             // メーカー名称
                estimateDetailRow.MakerKanaName_Prime = primeInfoRow.MakerKanaName;                     // メーカーカナ名称
                estimateDetailRow.GoodsNo_Prime = primeInfoRow.GoodsNo;                                 // 商品番号
                estimateDetailRow.GoodsName_Prime = primeInfoRow.GoodsName;                             // 商品名称
                estimateDetailRow.GoodsNameKana_Prime = primeInfoRow.GoodsNameKana;                     // 商品名称カナ
                estimateDetailRow.GoodsLGroup_Prime = primeInfoRow.GoodsLGroup;                         // 商品大分類コード
                estimateDetailRow.GoodsLGroupName_Prime = primeInfoRow.GoodsLGroupName;                 // 商品大分類名称
                estimateDetailRow.GoodsMGroup_Prime = primeInfoRow.GoodsMGroup;                         // 商品中分類コード
                estimateDetailRow.GoodsMGroupName_Prime = primeInfoRow.GoodsMGroupName;                 // 商品中分類名称
                estimateDetailRow.BLGroupCode_Prime = primeInfoRow.BLGroupCode;                         // BLグループコード
                estimateDetailRow.BLGroupName_Prime = primeInfoRow.BLGroupName;                         // BLグループコード名称
                estimateDetailRow.BLGoodsCode_Prime = primeInfoRow.BLGoodsCode;                         // BL商品コード
                estimateDetailRow.BLGoodsFullName_Prime = primeInfoRow.BLGoodsFullName;                 // BL商品コード名称（全角）
                estimateDetailRow.EnterpriseGanreCode_Prime = primeInfoRow.EnterpriseGanreCode;         // 自社分類コード
                estimateDetailRow.EnterpriseGanreName_Prime = primeInfoRow.EnterpriseGanreName;         // 自社分類名称
                estimateDetailRow.WarehouseCode_Prime = primeInfoRow.WarehouseCode;                     // 倉庫コード
                estimateDetailRow.WarehouseName_Prime = primeInfoRow.WarehouseName;                     // 倉庫名称
                estimateDetailRow.WarehouseShelfNo_Prime = primeInfoRow.WarehouseShelfNo;               // 倉庫棚番
                estimateDetailRow.SalesOrderDivCd_Prime = primeInfoRow.SalesOrderDivCd;                 // 売上在庫取寄せ区分
                estimateDetailRow.OpenPriceDiv_Prime = primeInfoRow.OpenPriceDiv;                       // オープン価格区分
                estimateDetailRow.GoodsRateRank_Prime = primeInfoRow.GoodsRateRank;                     // 商品掛率ランク
                //estimateDetailRow.CustRateGrpCode_Prime = primeInfoRow.CustRateGrpCode;                 // 得意先掛率グループコード // DEL 2011/07/26
                estimateDetailRow.ListPriceRate_Prime = primeInfoRow.ListPriceRate;                     // 定価率
                estimateDetailRow.RateSectPriceUnPrc_Prime = primeInfoRow.RateSectPriceUnPrc;           // 掛率設定拠点（定価）
                estimateDetailRow.RateDivLPrice_Prime = primeInfoRow.RateDivLPrice;                     // 掛率設定区分（定価）
                estimateDetailRow.UnPrcCalcCdLPrice_Prime = primeInfoRow.UnPrcCalcCdLPrice;             // 単価算出区分（定価）
                estimateDetailRow.PriceCdLPrice_Prime = primeInfoRow.PriceCdLPrice;                     // 価格区分（定価）
                estimateDetailRow.StdUnPrcLPrice_Prime = primeInfoRow.StdUnPrcLPrice;                   // 基準単価（定価）
                estimateDetailRow.FracProcUnitLPrice_Prime = primeInfoRow.FracProcUnitLPrice;           // 端数処理単位（定価）
                estimateDetailRow.FracProcLPrice_Prime = primeInfoRow.FracProcLPrice;                   // 端数処理（定価）
                estimateDetailRow.ListPriceTaxIncFl_Prime = primeInfoRow.ListPriceTaxIncFl;             // 定価（税込，浮動）
                estimateDetailRow.ListPriceTaxExcFl_Prime = primeInfoRow.ListPriceTaxExcFl;             // 定価（税抜，浮動）
                estimateDetailRow.ListPriceChngCd_Prime = primeInfoRow.ListPriceChngCd;                 // 定価変更区分
                estimateDetailRow.SalesRate_Prime = primeInfoRow.SalesRate;                             // 売価率
                estimateDetailRow.RateSectSalUnPrc_Prime = primeInfoRow.RateSectSalUnPrc;               // 掛率設定拠点（売上単価）
                estimateDetailRow.RateDivSalUnPrc_Prime = primeInfoRow.RateDivSalUnPrc;                 // 掛率設定区分（売上単価）
                estimateDetailRow.UnPrcCalcCdSalUnPrc_Prime = primeInfoRow.UnPrcCalcCdSalUnPrc;         // 単価算出区分（売上単価）
                estimateDetailRow.PriceCdSalUnPrc_Prime = primeInfoRow.PriceCdSalUnPrc;                 // 価格区分（売上単価）
                estimateDetailRow.StdUnPrcSalUnPrc_Prime = primeInfoRow.StdUnPrcSalUnPrc;               // 基準単価（売上単価）
                estimateDetailRow.FracProcUnitSalUnPrc_Prime = primeInfoRow.FracProcUnitSalUnPrc;       // 端数処理単位（売上単価）
                estimateDetailRow.FracProcSalUnPrc_Prime = primeInfoRow.FracProcSalUnPrc;               // 端数処理（売上単価）
                estimateDetailRow.SalesUnPrcTaxIncFl_Prime = primeInfoRow.SalesUnPrcTaxIncFl;           // 売上単価（税込，浮動）
                estimateDetailRow.SalesUnPrcTaxExcFl_Prime = primeInfoRow.SalesUnPrcTaxExcFl;           // 売上単価（税抜，浮動）
                estimateDetailRow.SalesUnPrcChngCd_Prime = primeInfoRow.SalesUnPrcChngCd;               // 売上単価変更区分
                estimateDetailRow.CostRate_Prime = primeInfoRow.CostRate;                               // 原価率
                estimateDetailRow.RateSectCstUnPrc_Prime = primeInfoRow.RateSectCstUnPrc;               // 掛率設定拠点（原価単価）
                estimateDetailRow.RateDivUnCst_Prime = primeInfoRow.RateDivUnCst;                       // 掛率設定区分（原価単価）
                estimateDetailRow.UnPrcCalcCdUnCst_Prime = primeInfoRow.UnPrcCalcCdUnCst;               // 単価算出区分（原価単価）
                estimateDetailRow.PriceCdUnCst_Prime = primeInfoRow.PriceCdUnCst;                       // 価格区分（原価単価）
                estimateDetailRow.StdUnPrcUnCst_Prime = primeInfoRow.StdUnPrcUnCst;                     // 基準単価（原価単価）
                estimateDetailRow.FracProcUnitUnCst_Prime = primeInfoRow.FracProcUnitUnCst;             // 端数処理単位（原価単価）
                estimateDetailRow.FracProcUnCst_Prime = primeInfoRow.FracProcUnCst;                     // 端数処理（原価単価）
                estimateDetailRow.SalesUnitCost_Prime = primeInfoRow.SalesUnitCost;                     // 原価単価
                estimateDetailRow.SalesUnitCostChngDiv_Prime = primeInfoRow.SalesUnitCostChngDiv;       // 原価単価変更区分
                estimateDetailRow.RateBLGoodsCode_Prime = primeInfoRow.RateBLGoodsCode;                 // BL商品コード（掛率）
                estimateDetailRow.RateBLGoodsName_Prime = primeInfoRow.RateBLGoodsName;                 // BL商品コード名称（掛率）
                estimateDetailRow.RateGoodsRateGrpCd_Prime = primeInfoRow.RateGoodsRateGrpCd;           // 商品掛率グループコード（掛率）
                estimateDetailRow.RateGoodsRateGrpNm_Prime = primeInfoRow.RateGoodsRateGrpNm;           // 商品掛率グループ名称（掛率）
                estimateDetailRow.RateBLGroupCode_Prime = primeInfoRow.RateBLGroupCode;                 // BLグループコード（掛率）
                estimateDetailRow.RateBLGroupName_Prime = primeInfoRow.RateBLGroupName;                 // BLグループ名称（掛率）
                estimateDetailRow.PrtBLGoodsCode_Prime = primeInfoRow.PrtBLGoodsCode;                   // BL商品コード（印刷）
                estimateDetailRow.PrtBLGoodsName_Prime = primeInfoRow.PrtBLGoodsName;                   // BL商品コード名称（印刷）
                estimateDetailRow.SalesCode_Prime = primeInfoRow.SalesCode;                             // 販売区分コード
                estimateDetailRow.SalesCdNm_Prime = primeInfoRow.SalesCdNm;                             // 販売区分名称
                estimateDetailRow.WorkManHour_Prime = primeInfoRow.WorkManHour;                         // 作業工数
                estimateDetailRow.ShipmentCnt_Prime = primeInfoRow.ShipmentCnt;                         // 出荷数
                estimateDetailRow.AcceptAnOrderCnt_Prime = primeInfoRow.AcceptAnOrderCnt;               // 受注数量
                estimateDetailRow.AcptAnOdrAdjustCnt_Prime = primeInfoRow.AcptAnOdrAdjustCnt;           // 受注調整数
                estimateDetailRow.AcptAnOdrRemainCnt_Prime = primeInfoRow.AcptAnOdrRemainCnt;           // 受注残数
                estimateDetailRow.RemainCntUpdDate_Prime = primeInfoRow.RemainCntUpdDate;               // 残数更新日
                estimateDetailRow.SalesMoneyTaxInc_Prime = primeInfoRow.SalesMoneyTaxInc;               // 売上金額（税込み）
                estimateDetailRow.SalesMoneyTaxExc_Prime = primeInfoRow.SalesMoneyTaxExc;               // 売上金額（税抜き）
                estimateDetailRow.Cost_Prime = primeInfoRow.Cost;                                       // 原価
                estimateDetailRow.GrsProfitChkDiv_Prime = primeInfoRow.GrsProfitChkDiv;                 // 粗利チェック区分
                estimateDetailRow.SalesGoodsCd_Prime = primeInfoRow.SalesGoodsCd;                       // 売上商品区分
                estimateDetailRow.SalesPriceConsTax_Prime = primeInfoRow.SalesPriceConsTax;             // 売上金額消費税額
                estimateDetailRow.TaxationDivCd_Prime = primeInfoRow.TaxationDivCd;                     // 課税区分
                estimateDetailRow.PartySlipNumDtl_Prime = primeInfoRow.PartySlipNumDtl;                 // 相手先伝票番号（明細）
                estimateDetailRow.DtlNote_Prime = primeInfoRow.DtlNote;                                 // 明細備考
                estimateDetailRow.SupplierCd_Prime = primeInfoRow.SupplierCd;                           // 仕入先コード
                estimateDetailRow.SupplierSnm_Prime = primeInfoRow.SupplierSnm;                         // 仕入先略称
                estimateDetailRow.OrderNumber_Prime = primeInfoRow.OrderNumber;                         // 発注番号
                estimateDetailRow.WayToOrder_Prime = primeInfoRow.WayToOrder;                           // 注文方法
                estimateDetailRow.SlipMemo1_Prime = primeInfoRow.SlipMemo1;                             // 伝票メモ１
                estimateDetailRow.SlipMemo2_Prime = primeInfoRow.SlipMemo2;                             // 伝票メモ２
                estimateDetailRow.SlipMemo3_Prime = primeInfoRow.SlipMemo3;                             // 伝票メモ３
                estimateDetailRow.InsideMemo1_Prime = primeInfoRow.InsideMemo1;                         // 社内メモ１
                estimateDetailRow.InsideMemo2_Prime = primeInfoRow.InsideMemo2;                         // 社内メモ２
                estimateDetailRow.InsideMemo3_Prime = primeInfoRow.InsideMemo3;                         // 社内メモ３
                estimateDetailRow.BfListPrice_Prime = primeInfoRow.BfListPrice;                         // 変更前定価
                estimateDetailRow.BfSalesUnitPrice_Prime = primeInfoRow.BfSalesUnitPrice;               // 変更前売価
                estimateDetailRow.BfUnitCost_Prime = primeInfoRow.BfUnitCost;                           // 変更前原価
                // --- DEL 2013/12/16 Y.Wakita ---------->>>>>
                //estimateDetailRow.CmpltSalesRowNo_Prime = primeInfoRow.CmpltSalesRowNo;                 // 一式明細番号
                //estimateDetailRow.CmpltGoodsMakerCd_Prime = primeInfoRow.CmpltGoodsMakerCd;             // メーカーコード（一式）
                //estimateDetailRow.CmpltMakerName_Prime = primeInfoRow.CmpltMakerName;                   // メーカー名称（一式）
                //estimateDetailRow.CmpltMakerKanaName_Prime = primeInfoRow.CmpltMakerKanaName;           // メーカーカナ名称（一式）
                //estimateDetailRow.CmpltGoodsName_Prime = primeInfoRow.CmpltGoodsName;                   // 商品名称（一式）
                //estimateDetailRow.CmpltShipmentCnt_Prime = primeInfoRow.CmpltShipmentCnt;               // 数量（一式）
                //estimateDetailRow.CmpltSalesUnPrcFl_Prime = primeInfoRow.CmpltSalesUnPrcFl;             // 売上単価（一式）
                //estimateDetailRow.CmpltSalesMoney_Prime = primeInfoRow.CmpltSalesMoney;                 // 売上金額（一式）
                //estimateDetailRow.CmpltSalesUnitCost_Prime = primeInfoRow.CmpltSalesUnitCost;           // 原価単価（一式）
                //estimateDetailRow.CmpltCost_Prime = primeInfoRow.CmpltCost;                             // 原価金額（一式）
                //estimateDetailRow.CmpltPartySalSlNum_Prime = primeInfoRow.CmpltPartySalSlNum;           // 相手先伝票番号（一式）
                //estimateDetailRow.CmpltNote_Prime = primeInfoRow.CmpltNote;                             // 一式備考
                // --- DEL 2013/12/16 Y.Wakita ----------<<<<<
                estimateDetailRow.PrtGoodsNo_Prime = primeInfoRow.PrtGoodsNo;                           // 印刷用品番
                estimateDetailRow.PrtMakerCode_Prime = primeInfoRow.PrtMakerCode;                       // 印刷用メーカーコード
                estimateDetailRow.PrtMakerName_Prime = primeInfoRow.PrtMakerName;                       // 印刷用メーカー名称

                estimateDetailRow.UOEOrderGuid_Prime = primeInfoRow.UOEOrderGuid;
                estimateDetailRow.DtlRelationGuid_Prime = primeInfoRow.DtlRelationGuid;
                //estimateDetailRow.ShipmentPosCnt_Prime = primeInfoRow.ShipmentPosCnt; // DEL 2013/02/20 tanh Redmine#34434 No.1180 

                // -----DEL 譚洪 Redmine#34994 2013/03/10------ >>>>>
                // ADD 2013/02/20 tanh Redmine#34434 No.1180 ---- >>>>>>>>>>>>
                //if (!string.IsNullOrEmpty(primeInfoRow.ShipmentPosCnt))
                //{
                    //estimateDetailRow.ShipmentPosCnt_Prime = double.Parse(primeInfoRow.ShipmentPosCnt);
                    
                //}
                //else
                //{
                    //estimateDetailRow.ShipmentPosCnt_Prime = 0;
                //}
                // ADD 2013/02/20 tanh Redmine#34434 No.1180 ---- <<<<<<<<<<<<
                // -----DEL 譚洪 Redmine#34994 2013/03/10------ <<<<<

                estimateDetailRow.ShipmentPosCnt_Prime = primeInfoRow.ShipmentPosCnt; // ADD 譚洪 Redmine#34994 2013/03/10

                estimateDetailRow.JoinSourPartsNoWithH = primeInfoRow.JoinSrcPartsNoWithH;
                estimateDetailRow.JoinDispOrder = primeInfoRow.JoinDispOrder;
                estimateDetailRow.ListPriceDisplay_Prime = primeInfoRow.ListPriceDisplay;
                estimateDetailRow.PartsInfoLinkGuid_Prime = primeInfoRow.PartsInfoLinkGuid;
                estimateDetailRow.ExistSetInfo_Prime = primeInfoRow.ExistSetInfo;
                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                estimateDetailRow.PrmSetDtlName2_Prime = primeInfoRow.PrmSetDtlName2;
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2012/08/20 2012/09/12配信 システムテスト障害№8対応 ------------------------>>>>>
                estimateDetailRow.SpecialNote_Prime = primeInfoRow.GoodsSpecialNote;
                // ADD 2012/08/20 2012/09/12配信 システムテスト障害№8対応 ------------------------<<<<<

                if (this.PimeInfoSelectChanged != null)
                {
                    this.PimeInfoSelectChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// 見積明細データ行オブジェクトから優良情報データ行オブジェクトを設定します。
        /// </summary>
        /// <param name="salesRowNo"></param>
        public void SettingPrimeInfoRowFromEstimateDetailRow( int salesRowNo )
        {
            this.SettingPrimeInfoRowFromEstimateDetailRow(this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo));
        }
        /// <summary>
        /// 見積明細データ行オブジェクトから優良情報データ行オブジェクトを設定します。
        /// </summary>
        /// <param name="estimateDetailRow"></param>
        private void SettingPrimeInfoRowFromEstimateDetailRow( EstimateInputDataSet.EstimateDetailRow estimateDetailRow )
        {
            if (estimateDetailRow == null) return;

            if (estimateDetailRow.PrimeInfoRelationGuid != Guid.Empty)
            {
                EstimateInputDataSet.PrimeInfoRow primeInfoRow = this.GetSelectedPrimeInfoRow(estimateDetailRow.PrimeInfoRelationGuid);

                if (primeInfoRow != null)
                {
                    this.SettingPrimeInfoRowFromEstimateDetailRow(ref primeInfoRow, estimateDetailRow);
                }
            }
        }

        /// <summary>
        /// 見積明細データ行オブジェクトから優良情報データ行オブジェクトを設定します。
        /// </summary>
        /// <param name="primeInfoRow">優良情報データ行</param>
        /// <param name="estimateDetailRow">見積明細データ行</param>
        /// <br>Update Note: 2013/02/20 譚洪</br>
        /// <br>管理番号   : 10801804-00、2013/03/13配信分</br>
        /// <br>             Redmine#34434 No.1180 現在庫数が０のとき在庫数が空白で表示されるの対応</br>
        private void SettingPrimeInfoRowFromEstimateDetailRow( ref EstimateInputDataSet.PrimeInfoRow primeInfoRow, EstimateInputDataSet.EstimateDetailRow estimateDetailRow )
        {
            if (primeInfoRow != null)
            {
                primeInfoRow.GoodsKindCode = estimateDetailRow.GoodsKindCode_Prime;                     // 商品属性
                primeInfoRow.GoodsSearchDivCd = estimateDetailRow.GoodsSearchDivCd_Prime;               // 商品検索区分
                primeInfoRow.GoodsMakerCd = estimateDetailRow.GoodsMakerCd_Prime;                       // 商品メーカーコード
                primeInfoRow.MakerName = estimateDetailRow.MakerName_Prime;                             // メーカー名称
                primeInfoRow.MakerKanaName = estimateDetailRow.MakerKanaName_Prime;                     // メーカーカナ名称
                primeInfoRow.GoodsNo = estimateDetailRow.GoodsNo_Prime;                                 // 商品番号
                primeInfoRow.GoodsName = estimateDetailRow.GoodsName_Prime;                             // 商品名称
                primeInfoRow.GoodsNameKana = estimateDetailRow.GoodsNameKana_Prime;                     // 商品名称カナ
                primeInfoRow.GoodsLGroup = estimateDetailRow.GoodsLGroup_Prime;                         // 商品大分類コード
                primeInfoRow.GoodsLGroupName = estimateDetailRow.GoodsLGroupName_Prime;                 // 商品大分類名称
                primeInfoRow.GoodsMGroup = estimateDetailRow.GoodsMGroup_Prime;                         // 商品中分類コード
                primeInfoRow.GoodsMGroupName = estimateDetailRow.GoodsMGroupName_Prime;                 // 商品中分類名称
                primeInfoRow.BLGroupCode = estimateDetailRow.BLGroupCode_Prime;                         // BLグループコード
                primeInfoRow.BLGroupName = estimateDetailRow.BLGroupName_Prime;                         // BLグループコード名称
                primeInfoRow.BLGoodsCode = estimateDetailRow.BLGoodsCode_Prime;                         // BL商品コード
                primeInfoRow.BLGoodsFullName = estimateDetailRow.BLGoodsFullName_Prime;                 // BL商品コード名称（全角）
                primeInfoRow.EnterpriseGanreCode = estimateDetailRow.EnterpriseGanreCode_Prime;         // 自社分類コード
                primeInfoRow.EnterpriseGanreName = estimateDetailRow.EnterpriseGanreName_Prime;         // 自社分類名称
                primeInfoRow.WarehouseCode = estimateDetailRow.WarehouseCode_Prime;                     // 倉庫コード
                primeInfoRow.WarehouseName = estimateDetailRow.WarehouseName_Prime;                     // 倉庫名称
                primeInfoRow.WarehouseShelfNo = estimateDetailRow.WarehouseShelfNo_Prime;               // 倉庫棚番
                primeInfoRow.SalesOrderDivCd = estimateDetailRow.SalesOrderDivCd_Prime;                 // 売上在庫取寄せ区分
                primeInfoRow.OpenPriceDiv = estimateDetailRow.OpenPriceDiv_Prime;                       // オープン価格区分
                primeInfoRow.GoodsRateRank = estimateDetailRow.GoodsRateRank_Prime;                     // 商品掛率ランク
                primeInfoRow.CustRateGrpCode = estimateDetailRow.CustRateGrpCode_Prime;                 // 得意先掛率グループコード
                primeInfoRow.ListPriceRate = estimateDetailRow.ListPriceRate_Prime;                     // 定価率
                primeInfoRow.RateSectPriceUnPrc = estimateDetailRow.RateSectPriceUnPrc_Prime;           // 掛率設定拠点（定価）
                primeInfoRow.RateDivLPrice = estimateDetailRow.RateDivLPrice_Prime;                     // 掛率設定区分（定価）
                primeInfoRow.UnPrcCalcCdLPrice = estimateDetailRow.UnPrcCalcCdLPrice_Prime;             // 単価算出区分（定価）
                primeInfoRow.PriceCdLPrice = estimateDetailRow.PriceCdLPrice_Prime;                     // 価格区分（定価）
                primeInfoRow.StdUnPrcLPrice = estimateDetailRow.StdUnPrcLPrice_Prime;                   // 基準単価（定価）
                primeInfoRow.FracProcUnitLPrice = estimateDetailRow.FracProcUnitLPrice_Prime;           // 端数処理単位（定価）
                primeInfoRow.FracProcLPrice = estimateDetailRow.FracProcLPrice_Prime;                   // 端数処理（定価）
                primeInfoRow.ListPriceTaxIncFl = estimateDetailRow.ListPriceTaxIncFl_Prime;             // 定価（税込，浮動）
                primeInfoRow.ListPriceTaxExcFl = estimateDetailRow.ListPriceTaxExcFl_Prime;             // 定価（税抜，浮動）
                primeInfoRow.ListPriceChngCd = estimateDetailRow.ListPriceChngCd_Prime;                 // 定価変更区分
                primeInfoRow.SalesRate = estimateDetailRow.SalesRate_Prime;                             // 売価率
                primeInfoRow.RateSectSalUnPrc = estimateDetailRow.RateSectSalUnPrc_Prime;               // 掛率設定拠点（売上単価）
                primeInfoRow.RateDivSalUnPrc = estimateDetailRow.RateDivSalUnPrc_Prime;                 // 掛率設定区分（売上単価）
                primeInfoRow.UnPrcCalcCdSalUnPrc = estimateDetailRow.UnPrcCalcCdSalUnPrc_Prime;         // 単価算出区分（売上単価）
                primeInfoRow.PriceCdSalUnPrc = estimateDetailRow.PriceCdSalUnPrc_Prime;                 // 価格区分（売上単価）
                primeInfoRow.StdUnPrcSalUnPrc = estimateDetailRow.StdUnPrcSalUnPrc_Prime;               // 基準単価（売上単価）
                primeInfoRow.FracProcUnitSalUnPrc = estimateDetailRow.FracProcUnitSalUnPrc_Prime;       // 端数処理単位（売上単価）
                primeInfoRow.FracProcSalUnPrc = estimateDetailRow.FracProcSalUnPrc_Prime;               // 端数処理（売上単価）
                primeInfoRow.SalesUnPrcTaxIncFl = estimateDetailRow.SalesUnPrcTaxIncFl_Prime;           // 売上単価（税込，浮動）
                primeInfoRow.SalesUnPrcTaxExcFl = estimateDetailRow.SalesUnPrcTaxExcFl_Prime;           // 売上単価（税抜，浮動）
                primeInfoRow.SalesUnPrcChngCd = estimateDetailRow.SalesUnPrcChngCd_Prime;               // 売上単価変更区分
                primeInfoRow.CostRate = estimateDetailRow.CostRate_Prime;                               // 原価率
                primeInfoRow.RateSectCstUnPrc = estimateDetailRow.RateSectCstUnPrc_Prime;               // 掛率設定拠点（原価単価）
                primeInfoRow.RateDivUnCst = estimateDetailRow.RateDivUnCst_Prime;                       // 掛率設定区分（原価単価）
                primeInfoRow.UnPrcCalcCdUnCst = estimateDetailRow.UnPrcCalcCdUnCst_Prime;               // 単価算出区分（原価単価）
                primeInfoRow.PriceCdUnCst = estimateDetailRow.PriceCdUnCst_Prime;                       // 価格区分（原価単価）
                primeInfoRow.StdUnPrcUnCst = estimateDetailRow.StdUnPrcUnCst_Prime;                     // 基準単価（原価単価）
                primeInfoRow.FracProcUnitUnCst = estimateDetailRow.FracProcUnitUnCst_Prime;             // 端数処理単位（原価単価）
                primeInfoRow.FracProcUnCst = estimateDetailRow.FracProcUnCst_Prime;                     // 端数処理（原価単価）
                primeInfoRow.SalesUnitCost = estimateDetailRow.SalesUnitCost_Prime;                     // 原価単価
                primeInfoRow.SalesUnitCostChngDiv = estimateDetailRow.SalesUnitCostChngDiv_Prime;       // 原価単価変更区分
                primeInfoRow.RateBLGoodsCode = estimateDetailRow.RateBLGoodsCode_Prime;                 // BL商品コード（掛率）
                primeInfoRow.RateBLGoodsName = estimateDetailRow.RateBLGoodsName_Prime;                 // BL商品コード名称（掛率）
                primeInfoRow.RateGoodsRateGrpCd = estimateDetailRow.RateGoodsRateGrpCd_Prime;           // 商品掛率グループコード（掛率）
                primeInfoRow.RateGoodsRateGrpNm = estimateDetailRow.RateGoodsRateGrpNm_Prime;           // 商品掛率グループ名称（掛率）
                primeInfoRow.RateBLGroupCode = estimateDetailRow.RateBLGroupCode_Prime;                 // BLグループコード（掛率）
                primeInfoRow.RateBLGroupName = estimateDetailRow.RateBLGroupName_Prime;                 // BLグループ名称（掛率）
                primeInfoRow.PrtBLGoodsCode = estimateDetailRow.PrtBLGoodsCode_Prime;                   // BL商品コード（印刷）
                primeInfoRow.PrtBLGoodsName = estimateDetailRow.PrtBLGoodsName_Prime;                   // BL商品コード名称（印刷）
                primeInfoRow.SalesCode = estimateDetailRow.SalesCode_Prime;                             // 販売区分コード
                primeInfoRow.SalesCdNm = estimateDetailRow.SalesCdNm_Prime;                             // 販売区分名称
                primeInfoRow.WorkManHour = estimateDetailRow.WorkManHour_Prime;                         // 作業工数
                primeInfoRow.ShipmentCnt = estimateDetailRow.ShipmentCnt_Prime;                         // 出荷数
                primeInfoRow.AcceptAnOrderCnt = estimateDetailRow.AcceptAnOrderCnt_Prime;               // 受注数量
                primeInfoRow.AcptAnOdrAdjustCnt = estimateDetailRow.AcptAnOdrAdjustCnt_Prime;           // 受注調整数
                primeInfoRow.AcptAnOdrRemainCnt = estimateDetailRow.AcptAnOdrRemainCnt_Prime;           // 受注残数
                primeInfoRow.RemainCntUpdDate = estimateDetailRow.RemainCntUpdDate_Prime;               // 残数更新日
                primeInfoRow.SalesMoneyTaxInc = estimateDetailRow.SalesMoneyTaxInc_Prime;               // 売上金額（税込み）
                primeInfoRow.SalesMoneyTaxExc = estimateDetailRow.SalesMoneyTaxExc_Prime;               // 売上金額（税抜き）
                primeInfoRow.Cost = estimateDetailRow.Cost_Prime;                                       // 原価
                primeInfoRow.GrsProfitChkDiv = estimateDetailRow.GrsProfitChkDiv_Prime;                 // 粗利チェック区分
                primeInfoRow.SalesGoodsCd = estimateDetailRow.SalesGoodsCd_Prime;                       // 売上商品区分
                primeInfoRow.SalesPriceConsTax = estimateDetailRow.SalesPriceConsTax_Prime;             // 売上金額消費税額
                primeInfoRow.TaxationDivCd = estimateDetailRow.TaxationDivCd_Prime;                     // 課税区分
                primeInfoRow.PartySlipNumDtl = estimateDetailRow.PartySlipNumDtl_Prime;                 // 相手先伝票番号（明細）
                primeInfoRow.DtlNote = estimateDetailRow.DtlNote_Prime;                                 // 明細備考
                primeInfoRow.SupplierCd = estimateDetailRow.SupplierCd_Prime;                           // 仕入先コード
                primeInfoRow.SupplierSnm = estimateDetailRow.SupplierSnm_Prime;                         // 仕入先略称
                primeInfoRow.OrderNumber = estimateDetailRow.OrderNumber_Prime;                         // 発注番号
                primeInfoRow.WayToOrder = estimateDetailRow.WayToOrder_Prime;                           // 注文方法
                primeInfoRow.SlipMemo1 = estimateDetailRow.SlipMemo1_Prime;                             // 伝票メモ１
                primeInfoRow.SlipMemo2 = estimateDetailRow.SlipMemo2_Prime;                             // 伝票メモ２
                primeInfoRow.SlipMemo3 = estimateDetailRow.SlipMemo3_Prime;                             // 伝票メモ３
                primeInfoRow.InsideMemo1 = estimateDetailRow.InsideMemo1_Prime;                         // 社内メモ１
                primeInfoRow.InsideMemo2 = estimateDetailRow.InsideMemo2_Prime;                         // 社内メモ２
                primeInfoRow.InsideMemo3 = estimateDetailRow.InsideMemo3_Prime;                         // 社内メモ３
                primeInfoRow.BfListPrice = estimateDetailRow.BfListPrice_Prime;                         // 変更前定価
                primeInfoRow.BfSalesUnitPrice = estimateDetailRow.BfSalesUnitPrice_Prime;               // 変更前売価
                primeInfoRow.BfUnitCost = estimateDetailRow.BfUnitCost_Prime;                           // 変更前原価
                primeInfoRow.CmpltSalesRowNo = estimateDetailRow.CmpltSalesRowNo_Prime;                 // 一式明細番号
                primeInfoRow.CmpltGoodsMakerCd = estimateDetailRow.CmpltGoodsMakerCd_Prime;             // メーカーコード（一式）
                primeInfoRow.CmpltMakerName = estimateDetailRow.CmpltMakerName_Prime;                   // メーカー名称（一式）
                primeInfoRow.CmpltMakerKanaName = estimateDetailRow.CmpltMakerKanaName_Prime;           // メーカーカナ名称（一式）
                primeInfoRow.CmpltGoodsName = estimateDetailRow.CmpltGoodsName_Prime;                   // 商品名称（一式）
                primeInfoRow.CmpltShipmentCnt = estimateDetailRow.CmpltShipmentCnt_Prime;               // 数量（一式）
                primeInfoRow.CmpltSalesUnPrcFl = estimateDetailRow.CmpltSalesUnPrcFl_Prime;             // 売上単価（一式）
                primeInfoRow.CmpltSalesMoney = estimateDetailRow.CmpltSalesMoney_Prime;                 // 売上金額（一式）
                primeInfoRow.CmpltSalesUnitCost = estimateDetailRow.CmpltSalesUnitCost_Prime;           // 原価単価（一式）
                primeInfoRow.CmpltCost = estimateDetailRow.CmpltCost_Prime;                             // 原価金額（一式）
                primeInfoRow.CmpltPartySalSlNum = estimateDetailRow.CmpltPartySalSlNum_Prime;           // 相手先伝票番号（一式）
                primeInfoRow.CmpltNote = estimateDetailRow.CmpltNote_Prime;                             // 一式備考
                primeInfoRow.PrtGoodsNo = estimateDetailRow.PrtGoodsNo_Prime;                           // 印刷用品番
                primeInfoRow.PrtMakerCode = estimateDetailRow.PrtMakerCode_Prime;                       // 印刷用メーカーコード
                primeInfoRow.PrtMakerName = estimateDetailRow.PrtMakerName_Prime;                       // 印刷用メーカー名称

                primeInfoRow.UOEOrderGuid = estimateDetailRow.UOEOrderGuid_Prime;
                primeInfoRow.DtlRelationGuid = estimateDetailRow.DtlRelationGuid_Prime;
                //primeInfoRow.ShipmentPosCnt = estimateDetailRow.ShipmentPosCnt_Prime;  // DEL 2013/02/20 tanh Redmine#34434 No.1180 

                // ADD 2013/02/20 tanh Redmine#34434 No.1180 ---- >>>>>>>>>>>>
                if (string.IsNullOrEmpty(primeInfoRow.WarehouseCode.Trim()))
                {
                    primeInfoRow.ShipmentPosCnt = string.Empty;
                }
                else
                {
                    //primeInfoRow.ShipmentPosCnt = estimateDetailRow.ShipmentPosCnt_Prime.ToString("N");// DEL 譚洪 Redmine#34994 2013/03/10
                    primeInfoRow.ShipmentPosCnt = estimateDetailRow.ShipmentPosCnt_Prime;// ADD 譚洪 Redmine#34994 2013/03/10
                }
                // ADD 2013/02/20 tanh Redmine#34434 No.1180 ---- <<<<<<<<<<<<

                primeInfoRow.PartsInfoLinkGuid = estimateDetailRow.PartsInfoLinkGuid_Prime;
                primeInfoRow.ExistSetInfo = estimateDetailRow.ExistSetInfo_Prime;
                primeInfoRow.ListPriceDisplay = estimateDetailRow.ListPriceDisplay_Prime;
                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                primeInfoRow.PrmSetDtlName2 = estimateDetailRow.PrmSetDtlName2_Prime;
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
        }

        #endregion

        // ===================================================================================== //
        // 部品検索
        // ===================================================================================== //
        #region ●部品検索

        /// <summary>
        /// 部品検索（品番検索）
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="joinSearchDivType">結合検索タイプ</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <param name="carInfo">車輌検索結果</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2009/11/05 呉元嘯</br>
        /// <br>             Redmine#1087対応</br>
        /// </remarks>
        public int SearchPartsFromGoodsNo(IWin32Window owner, string enterpriseCode, string sectionCode, int goodsMakerCode, string goodsNo, GoodsCndtn.JoinSearchDivType joinSearchDivType, out List<GoodsUnitData> goodsUnitDataList, out PartsInfoDataSet partsInfoDataSet, out List<UnitPriceCalcRet> unitPriceCalcRetList, PMKEN01010E carInfo)
        {
            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "START");

            //-----------------------------------------------------------------------------
            // 初期化
            //-----------------------------------------------------------------------------
            string msg;

            unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            //----------ADD 2009/11/05-------->>>>>
            partsInfoDataSet = new PartsInfoDataSet();
            goodsUnitDataList = new List<GoodsUnitData>();
            //----------ADD 2009/11/05--------<<<<<
            //-----------------------------------------------------------------------------
            // 抽出条件設定
            //-----------------------------------------------------------------------------
            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;
            cndtn.GoodsMakerCd = goodsMakerCode;
            cndtn.GoodsNo = goodsNo;
            cndtn.JoinSearchDiv = (int)joinSearchDivType;
            cndtn.IsSettingSupplier = 1;
            //----------ADD 2009/11/05-------->>>>>
            cndtn.SearchCarInfo = carInfo;
            //----------ADD 2009/11/05--------<<<<<

            this.SetCommonSerachCndtn(ref cndtn);

            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "部品検索 START");
            //-----------------------------------------------------------------------------
            // 部品検索
            //-----------------------------------------------------------------------------
            int status = this._estimateInputInitDataAcs.SearchParts(owner, cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "部品検索 END");

            // 検索結果がゼロの場合は強制的に該当データ無し
            if (( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL ) && ( ( goodsUnitDataList == null ) || ( goodsUnitDataList.Count == 0 ) ))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_CANCEL: // 選択無し
                    break;
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // 通常処理
                    //CalculateUnitPriceForSearch
                    //CalcPriceForSearch

                    //EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "商品連結データ不足情報設定① START");
                    //this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList);
                    //EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "商品連結データ不足情報設定① END");

                    ////-----------------------------------------------------------------------------
                    //// 単価情報取得
                    ////-----------------------------------------------------------------------------
                    //EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "単価算出 START");
                    //unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);
                    //EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "単価算出 START");

                    ////-----------------------------------------------------------------------------
                    //// 単価情報を部品検索データセットへ反映
                    ////-----------------------------------------------------------------------------
                    //EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "単価情報を部品検索データセットへ反映 START");
                    //if (( unitPriceCalcRetList != null ) && ( unitPriceCalcRetList.Count != 0 )) partsInfoDataSet.SetUnitPriceInfo(unitPriceCalcRetList);
                    //EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "単価情報を部品検索データセットへ反映 END");

                    // 単価算出デリゲート追加
                    if (partsInfoDataSet.CalculateGoodsPrice == null)
                    {
                        partsInfoDataSet.CalculateGoodsPrice += new PartsInfoDataSet.CalculateGoodsPriceCallback(this.CalculateUnitPriceForSearch);
                    }
                    // 価格計算デリゲート追加
                    if (partsInfoDataSet.CalculatePrice == null)
                    {
                        partsInfoDataSet.CalculatePrice += new PartsInfoDataSet.CalculatePriceCallback(CalcPriceForSearch);
                    }

                    // 優先倉庫のセット
                    partsInfoDataSet.ListPriorWarehouse = this.GetSearchWarehouseList();
                    // TODO:品名表示区分のセット
                    // DEL 2010/05/17 品名表示対応 ---------->>>>>
                    //partsInfoDataSet.PartsNameDspDivCd = this._estimateInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd;
                    // DEL 2010/05/17 品名表示対応 ----------<<<<<
                    // ADD 2010/05/17 品名表示対応 ---------->>>>>
                    partsInfoDataSet.SetPartsNameDisplayPattern(this._estimateInputInitDataAcs.GetSalesTtlSt());

                    // BL商品情報
                    if (partsInfoDataSet.GetBLGoodsInfo == null)
                    {
                        partsInfoDataSet.GetBLGoodsInfo += new PartsInfoDataSet.GetBLGoodsInfoCallBack(this.GetBLGoodsInfo);
                    }
                    // ADD 2010/05/17 品名表示対応 ----------<<<<<

                    // 価格適用日のセット
                    partsInfoDataSet.PriceApplyDate = this._salesSlip.SalesDate;

                    // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // 売価未設定時区分
                    partsInfoDataSet.UnPrcNonSettingDiv = this._estimateInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv;
                    // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // 車両情報補正
                    #region 車両情報補正
                    // --- ADD 譚洪 2014/09/01 ---------->>>>>
                    this.SetCarInfoToThread(cndtn);
                    // --- ADD 譚洪 2014/09/01 ----------<<<<<
                    #endregion

                    //-----------------------------------------------------------------------------
                    // 部品選択制御起動
                    //-----------------------------------------------------------------------------
                    //UIDisplayControl.CalcUnitPriceEvent += new UIDisplayControl.CalcUnitPriceEventHandler(this.CalculateUnitPrice);
                    EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "部品選択制御UI START");
                    DialogResult retDialog = UIDisplayControl.SearchEstimatePNo(owner, partsInfoDataSet, 0);
                    EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "部品選択制御UI END");

                    switch (retDialog)
                    {
                        case DialogResult.Abort:
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                        case DialogResult.Cancel:
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                        case DialogResult.Ignore:
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.None:
                            break;
                        case DialogResult.OK:
                        case DialogResult.Yes:
                            //-----------------------------------------------------------------------------
                            // 部品検索データセットから選択情報の商品連結データオブジェクトを取得
                            //-----------------------------------------------------------------------------
                            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "商品リスト取得 START");
                            goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true, this._estimateInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd).ToArray(typeof(GoodsUnitData)));
                            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "商品リスト取得 END");

                            this.CalculateUnitPriceForSearch(goodsUnitDataList, out unitPriceCalcRetList);

                            //-----------------------------------------------------------------------------
                            // 商品連結データ不足情報設定
                            //-----------------------------------------------------------------------------
                            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "商品連結データ不足情報設定 START");
                            this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true);
                            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "商品連結データ不足情報設定 END");

                            //-----------------------------------------------------------------------------
                            // 単価情報取得
                            //-----------------------------------------------------------------------------
                            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "単価算出 START");
                            unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);
                            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "単価算出 END");

                            break;
                        case DialogResult.Retry:
                            break;
                    }


                    break;
                case ConstantManagement.MethodResult.ctFNC_NO_RETURN: // 該当データ無し
                    break;
            }

            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromGoodsNo", "END");
            return status;
        }

        ///// <summary>
        ///// 単価算出処理（部品選択UIのデリゲートに使用)
        ///// </summary>
        ///// <param name="list">商品連結データオブジェクトリスト</param>
        //private void CalculateUnitPrice(ref PartsInfoDataSet partsInfoDataSet, List<PartsInfoDataSet.GoodsPrimaryKey> goodsPrimaryKeyList)
        //{
        //    if (goodsPrimaryKeyList == null) return;

        //    List<GoodsUnitData> goodsUnitDataList = partsInfoDataSet.GetGoodsList(goodsPrimaryKeyList);
        //    List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
        //    this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList);

        //    //-----------------------------------------------------------------------------
        //    // 単価情報取得
        //    //-----------------------------------------------------------------------------
        //    unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);

        //    // データセットに価格反映
        //    if (( unitPriceCalcRetList != null ) && ( unitPriceCalcRetList.Count != 0 )) partsInfoDataSet.SetUnitPriceInfo(unitPriceCalcRetList);
        //}

        /// <summary>
        /// BLコード検索
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="searchCarInfo">検索車輌</param>
        /// <param name="partsSelectFlg">部品選択有無フラグ</param>
        /// <param name="goodsUnitDataList">商品情報オブジェクトリスト</param>
        /// <param name="partsInfoDataSet">検索部品データセット</param>
        /// <param name="unitPriceCalcRetList"></param>
        /// <returns>ConstantManagement.MethodResult(-3:車輌情報無し)</returns>
        public int SearchPartsFromBLCode(IWin32Window owner, string enterpriseCode, string sectionCode, int blGoodsCode, PMKEN01010E searchCarInfo, int partsSelectFlg, out List<GoodsUnitData> goodsUnitDataList, out PartsInfoDataSet partsInfoDataSet, out List<UnitPriceCalcRet> unitPriceCalcRetList )
        {
            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "開始");

            //-----------------------------------------------------------------------------
            // 初期化
            //-----------------------------------------------------------------------------
            string msg;
            goodsUnitDataList= new List<GoodsUnitData>();
            partsInfoDataSet = new PartsInfoDataSet();
            unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            if (searchCarInfo == null)
            {
                return -3;
            }

            unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            //-----------------------------------------------------------------------------
            // 抽出条件設定
            //-----------------------------------------------------------------------------
            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;
            cndtn.BLGoodsCode = blGoodsCode;
            cndtn.SearchCarInfo = searchCarInfo;
            cndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.Search;
            cndtn.IsSettingSupplier = 1;
            cndtn.SearchCarInfo = searchCarInfo;

            this.SetCommonSerachCndtn(ref cndtn);

            // --- ADD 2013/03/08 Y.Wakita ---------->>>>>
            if (cndtn.SearchCarInfo.CarModelUIData[0].ProduceTypeOfYearInput > 0)
            {
                if ((cndtn.SearchCarInfo.CarModelUIData[0].ProduceTypeOfYearInput % 100) == 0)
                {
                    cndtn.SearchCarInfo.CarModelUIData[0].ProduceTypeOfYearInput = 0;
                }
            }
            // --- ADD 2013/03/08 Y.Wakita ----------<<<<<

            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "部品検索 START"); 
            //-----------------------------------------------------------------------------
            // 部品検索
            //-----------------------------------------------------------------------------
            int status = this._estimateInputInitDataAcs.BLPartsSearch(owner, cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);

            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "部品検索 END");

            // 検索結果がゼロの場合は強制的に該当データ無し
            if (( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL ) && ( ( goodsUnitDataList == null ) || ( goodsUnitDataList.Count == 0 ) ))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_CANCEL: // 選択無し
                    break;
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // 通常処理

                    //EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "商品連結データ不足情報設定① START");
                    //this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList);
                    //EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "商品連結データ不足情報設定① END");

                    ////-----------------------------------------------------------------------------
                    //// 単価情報取得
                    ////-----------------------------------------------------------------------------
                    //EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "単価算出 START");
                    //unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);
                    //EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "単価算出 END");


                    ////-----------------------------------------------------------------------------
                    //// 単価情報を部品検索データセットへ反映
                    ////-----------------------------------------------------------------------------
                    //EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "単価情報を部品検索データセットへ反映 START");
                    //if (( unitPriceCalcRetList != null ) && ( unitPriceCalcRetList.Count != 0 )) partsInfoDataSet.SetUnitPriceInfo(unitPriceCalcRetList);
                    //EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "単価情報を部品検索データセットへ反映 END");

                    // 単価算出デリゲート追加
                    if (partsInfoDataSet.CalculateGoodsPrice == null)
                    {
                        partsInfoDataSet.CalculateGoodsPrice += new PartsInfoDataSet.CalculateGoodsPriceCallback(this.CalculateUnitPriceForSearch);
                    }
                    // 価格計算デリゲート追加
                    if (partsInfoDataSet.CalculatePrice == null)
                    {
                        partsInfoDataSet.CalculatePrice += new PartsInfoDataSet.CalculatePriceCallback(CalcPriceForSearch);
                    }


                    // 優先倉庫のセット
                    partsInfoDataSet.ListPriorWarehouse = this.GetSearchWarehouseList();
                    // TODO:品名表示区分のセット
                    // DEL 2010/05/17 品名表示対応 ---------->>>>>
                    //partsInfoDataSet.PartsNameDspDivCd = this._estimateInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd;
                    // DEL 2010/05/17 品名表示対応 ----------<<<<<
                    // ADD 2010/05/17 品名表示対応 ---------->>>>>
                    partsInfoDataSet.SetPartsNameDisplayPattern(this._estimateInputInitDataAcs.GetSalesTtlSt());

                    // BL商品情報
                    if (partsInfoDataSet.GetBLGoodsInfo == null)
                    {
                        partsInfoDataSet.GetBLGoodsInfo += new PartsInfoDataSet.GetBLGoodsInfoCallBack(this.GetBLGoodsInfo);
                    }
                    // ADD 2010/05/17 品名表示対応 ----------<<<<<
                    // 価格適用日のセット
                    partsInfoDataSet.PriceApplyDate = this._salesSlip.SalesDate;

                    // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // 売価未設定時区分
                    partsInfoDataSet.UnPrcNonSettingDiv = this._estimateInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv;
                    // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // 車両情報補正
                    #region 車両情報補正
                    // --- ADD 譚洪 2014/09/01 ---------->>>>>
                    this.SetCarInfoToThread(cndtn);
                    // --- ADD 譚洪 2014/09/01 ----------<<<<<
                    #endregion

                    //-----------------------------------------------------------------------------
                    // 部品選択制御起動
                    //-----------------------------------------------------------------------------
                    EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "部品選択制御UI START");
                    DialogResult retDialog = UIDisplayControl.SearchEstimateBL(owner, searchCarInfo, partsInfoDataSet, partsSelectFlg);
                    EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "部品選択制御UI END");

                    switch (retDialog)
                    {
                        case DialogResult.Abort:
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                        case DialogResult.Cancel:
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                        case DialogResult.Ignore:
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.None:
                            break;case DialogResult.OK:
                        case DialogResult.Yes:

                            //List<g> genuinePartsRetWorkList = partsInfoDataSet.GetSelectedGenuineParts();

                            //-----------------------------------------------------------------------------
                            // 部品検索データセットから選択情報の商品連結データオブジェクトを取得
                            //-----------------------------------------------------------------------------
                            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "商品リスト取得 START");
                            goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true, this._estimateInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd).ToArray(typeof(GoodsUnitData)));
                            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "商品リスト取得 END");

                            //-----------------------------------------------------------------------------
                            // 商品連結データ不足情報設定
                            //-----------------------------------------------------------------------------
                            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "商品連結データ不足情報設定 START");
                            this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true);
                            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "商品連結データ不足情報設定 END");

                            //-----------------------------------------------------------------------------
                            // 単価情報取得
                            //-----------------------------------------------------------------------------
                            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "単価算出 START");
                            unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);
                            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "単価算出 END");

                            break;
                        case DialogResult.Retry:
                            break;
                    }


                    break;
                case ConstantManagement.MethodResult.ctFNC_NO_RETURN: // 該当データ無し

                    break;
            }

            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "SearchPartsFromBLCode", "終了"); 

            return status;
        }

        /// <summary>
        /// TBO検索
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="carInfo">検索車輌</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="partsInfoDataSet">検索部品データセット</param>
        /// <param name="unitPriceCalcRetList">掛率算出結果リスト</param>
        /// <returns></returns>
        public int SearchTBO(IWin32Window owner, string enterpriseCode, string sectionCode, PMKEN01010E carInfo,out List<GoodsUnitData> goodsUnitDataList,out PartsInfoDataSet partsInfoDataSet,out List<UnitPriceCalcRet> unitPriceCalcRetList )
        {
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();

            //-----------------------------------------------------------------------------
            // 初期化
            //-----------------------------------------------------------------------------
            string msg;
            unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            //-----------------------------------------------------------------------------
            // 抽出条件設定
            //-----------------------------------------------------------------------------
            GoodsCndtn cndtn = new GoodsCndtn();
            this.SetCommonSerachCndtn(ref cndtn); // 2009/09/08 ADD
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;
            cndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
            cndtn.ListPriorWarehouse = this.GetSearchWarehouseList();

            cndtn.CustomerCode = this._salesSlip.CustomerCode;
            cndtn.CustRateGrpCode = this._salesSlip.CustRateGrpCode;
            cndtn.PriceApplyDate = this._salesSlip.SalesDate;                           
            cndtn.SalesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
            cndtn.TaxRate = this._salesSlip.ConsTaxRate;
            cndtn.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd;
            cndtn.TtlAmntDspRateDivCd = this._estimateInputInitDataAcs.GetAllDefSet().TtlAmntDspRateDivCd;
            cndtn.SalesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            cndtn.IsSettingSupplier = 1;

            cndtn.SearchCarInfo = carInfo;

            //-----------------------------------------------------------------------------
            // TBO検索
            //-----------------------------------------------------------------------------
            int status = this._estimateInputInitDataAcs.SearchTBO(owner, cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);

            // 検索結果がゼロの場合は強制的に該当データ無し
            if (( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL ) && ( ( goodsUnitDataList == null ) || ( goodsUnitDataList.Count == 0 ) ))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_CANCEL: // 選択無し
                    break;
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // 通常処理

                    ////-------------------------------------------------------------------------
                    //// 商品連結データ不足情報設定
                    ////-------------------------------------------------------------------------
                    this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true);

                    //-----------------------------------------------------------------------------
                    // 単価情報取得
                    //-----------------------------------------------------------------------------
                    unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);

                    //-----------------------------------------------------------------------------
                    // 単価情報を部品検索データセットへ反映
                    //-----------------------------------------------------------------------------
                    if (( unitPriceCalcRetList != null ) && ( unitPriceCalcRetList.Count != 0 )) partsInfoDataSet.SetUnitPriceInfo(unitPriceCalcRetList);

                    ////-----------------------------------------------------------------------------
                    //// 部品検索データセットから選択情報の商品連結データオブジェクトを取得
                    ////-----------------------------------------------------------------------------
                    //goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true).ToArray(typeof(GoodsUnitData)));

                    break;
                case ConstantManagement.MethodResult.ctFNC_NO_RETURN: // 該当データ無し
                    break;
            }
            return status;
        }

        //----------DEL 2009/11/05--------->>>>>
        ///// <summary>
        ///// 標準価格取得
        ///// </summary>
        ///// <param name="partsInfoDataSet">部品検索結果データセット(結合元)</param>
        ///// <remarks>
        ///// <br>Note       : 標準価格を取得する</br>
        ///// <br>Programmer : 呉元嘯</br>
        ///// <br>Date       : 2009/10/22②</br>
        ///// <br>Update Note: 2009/11/05 呉元嘯</br>
        ///// <br>             Redmine#1087、#1134対応</br>
        ///// </remarks>
        //public void CalculateUnitPriceForSearchProc( ref PartsInfoDataSet partsInfoDataSet)
        //{
        //    //----------UPD 2009/11/05--------->>>>>
        //    // 価格適用日のセット
        //    partsInfoDataSet.PriceApplyDate = this._salesSlip.SalesDate;
        //    // 価格計算デリゲート追加
        //    if (partsInfoDataSet.CalculatePrice == null)
        //    {
        //        partsInfoDataSet.CalculatePrice += new PartsInfoDataSet.CalculatePriceCallback(CalcPriceForSearch);
        //    }
        //    List<PartsInfoDataSet.GoodsPrimaryKey> goodsPrimaryKeyList = new List<PartsInfoDataSet.GoodsPrimaryKey>();
        //    for (int i = 0; i < partsInfoDataSet.UsrGoodsInfo.Count; i++)
        //    {
        //        goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(partsInfoDataSet.UsrGoodsInfo[i].GoodsNo, partsInfoDataSet.UsrGoodsInfo[i].GoodsMakerCd));
        //    partsInfoDataSet.SettingDefaultListPrice(goodsPrimaryKeyList);
        //    }
        //    //----------UPD 2009/11/05---------<<<<<

        //}
        //----------DEL 2009/11/05---------<<<<<

        /// <summary>
        /// 検索用の単価算出
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        /// <param name="unitPriceCalcRetList"></param>
        private void CalculateUnitPriceForSearch(List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "CalculateUnitPriceForSearch", "商品連結データ不足情報設定 START");
            this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, false);
            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "CalculateUnitPriceForSearch", "商品連結データ不足情報設定 END");

            //-----------------------------------------------------------------------------
            // 単価情報取得
            //-----------------------------------------------------------------------------
            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "CalculateUnitPriceForSearch", "単価算出 START");
            unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);
            EstimateInputInitDataAcs.LogWrite("－EstimateInputAcs", "CalculateUnitPriceForSearch", "単価算出 END");
        }

        /// <summary>
        /// 検索用の価格計算
        /// </summary>
        /// <param name="taxationCode"></param>
        /// <param name="unitPrice"></param>
        /// <param name="priceTaxExc"></param>
        /// <param name="priceTaxInc"></param>
        private void CalcPriceForSearch(int taxationCode, double unitPrice, out double priceTaxExc, out double priceTaxInc)
        {
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();

            priceTaxExc = unitPrice;
            priceTaxInc = unitPrice;
            // 消費税端数処理コード
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);

            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._estimateInputInitDataAcs.GetSalesFractionProcInfo(EstimateInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);


            // 課税区分「非課税」、転嫁方式：非課税
            if (( taxationCode == (int)CalculateTax.TaxationCode.TaxNone ))
            {
                priceTaxExc = unitPrice;
                priceTaxInc = unitPrice;
            }
            // 課税区分が「課税（内税）」の場合
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                priceTaxExc = unitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
                //priceTaxInc = ( this._salesSlip.ConsTaxLayMethod == 9 ) ? unitPrice : priceTaxExc;
                priceTaxInc = unitPrice;
            }
            // 課税区分が「課税」の場合
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                priceTaxExc = unitPrice;
                //priceTaxInc = ( this._salesSlip.ConsTaxLayMethod == 9 ) ? targetPrice : unitPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
                priceTaxInc = unitPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
            }
        }

        /// <summary>
        /// 品番検索(商品情報一括取得)
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailList">売上明細データリスト</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="msg">メッセージ</param>
        /// <returns></returns>
        public int SearchPartsFromGoodsNoNonVariousSearchWholeWord( SalesSlip salesSlip, List<SalesDetail> salesDetailList, out List<GoodsUnitData> goodsUnitDataList, out String msg )
        {
            //-----------------------------------------------------------------------------
            // 初期処理
            //-----------------------------------------------------------------------------
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();

            //-----------------------------------------------------------------------------
            // 商品検索条件オブジェクトリスト取得
            //-----------------------------------------------------------------------------
            this.GetGoodsCndtnList(salesSlip, salesDetailList, out goodsCndtnList);

            return this.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataList, out msg); ;
        }

        /// <summary>
        /// 品番検索(商品情報一括取得)
        /// </summary>
        /// <param name="goodsCndtnList">商品検索条件リスト</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="msg">メッセージ</param>
        /// <returns></returns>
        public int SearchPartsFromGoodsNoNonVariousSearchWholeWord(List<GoodsCndtn> goodsCndtnList, out List<GoodsUnitData> goodsUnitDataList, out String msg)
        {
            //-----------------------------------------------------------------------------
            // 初期処理
            //-----------------------------------------------------------------------------
            goodsUnitDataList = new List<GoodsUnitData>();
            List<List<GoodsUnitData>> goodsUnitDataListList = new List<List<GoodsUnitData>>();

            //-----------------------------------------------------------------------------
            // 品番検索(商品情報一括取得)
            //-----------------------------------------------------------------------------
            int status = this._estimateInputInitDataAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out msg);

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // 通常処理

                    foreach (List<GoodsUnitData> goodsUnitDataListWk in goodsUnitDataListList)
                    {
                        if (( goodsUnitDataListWk != null ) && ( goodsUnitDataListWk.Count > 0 ))
                        {
                            goodsUnitDataList.Add(goodsUnitDataListWk[0]);
                        }
                    }
                    break;
                default:
                    break;
            }

            return status;
        }

        /// <summary>
        /// 検索部品データセットより、選択した部品の情報を取得します。
        /// </summary>
        /// <param name="partsInfoDataSet">検索部品データセット</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        public void GetSelectedDataFromPartsInfoSet( PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList )
        {
            //-----------------------------------------------------------------------------
            // 部品検索データセットから選択情報の商品連結データオブジェクトを取得
            //-----------------------------------------------------------------------------
            goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true, this._estimateInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd).ToArray(typeof(GoodsUnitData)));

            //-------------------------------------------------------------------------
            // 商品連結データ不足情報設定
            //-------------------------------------------------------------------------
            this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true);

            //-----------------------------------------------------------------------------
            // 単価情報取得
            //-----------------------------------------------------------------------------
            unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);
        }

        /// <summary>
        /// 結合検索
        /// </summary>
        /// <param name="goodsCndtnList">商品検索条件リスト</param>
        /// <param name="goodsInfoDictionary"></param>
        /// <returns></returns>
        public int JoinPartsSearch(List<GoodsCndtn> goodsCndtnList, out Dictionary<GoodsUnitData, PartsInfoDataSet> goodsInfoDictionary)
        {
            goodsInfoDictionary = null;

            List<PartsInfoDataSet> partsInfoDataSetListWk;

            List<List<GoodsUnitData>> goodsUnitDataListList;
            string msg;
            int status = this._estimateInputInitDataAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtnList, out partsInfoDataSetListWk, out goodsUnitDataListList, out msg);

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // 通常処理

                    if (( goodsUnitDataListList != null ) && ( goodsUnitDataListList.Count > 0 ))
                    {
                        goodsInfoDictionary = new Dictionary<GoodsUnitData, PartsInfoDataSet>();
                        foreach (GoodsCndtn goodsCndtn in goodsCndtnList)
                        {
                            for (int i = 0; i < goodsUnitDataListList.Count; i++)
                            {
                                // 検索条件と一致し、データセットもあるデータのみ取得する
                                if (( goodsCndtn.GoodsNo == goodsUnitDataListList[i][0].GoodsNo ) &&
                                    ( goodsCndtn.GoodsMakerCd == goodsUnitDataListList[i][0].GoodsMakerCd ))
                                {
                                    if (i < partsInfoDataSetListWk.Count)
                                    {
                                        goodsInfoDictionary.Add(goodsUnitDataListList[i][0], partsInfoDataSetListWk[i]);
                                    }
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            return status;
        }

        /// <summary>
        /// 商品検索条件オブジェクトリスト取得処理
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
        /// <param name="goodsCndtnList">商品検索条件オブジェクトリスト</param>
        private void GetGoodsCndtnList(SalesSlip salesSlip, List<SalesDetail> salesDetailList, out List<GoodsCndtn> goodsCndtnList)
        {
            goodsCndtnList = new List<GoodsCndtn>();
            List<GoodsCndtn> retGoodsCndtnList = new List<GoodsCndtn>();

            foreach (SalesDetail salesDetail in salesDetailList)
            {
                if (( salesDetail.GoodsMakerCd == 0 ) || ( string.IsNullOrEmpty(salesDetail.GoodsNo) )) continue;

                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.SectionCode = salesSlip.ResultsAddUpSecCd;
                goodsCndtn.GoodsMakerCd = salesDetail.GoodsMakerCd;
                goodsCndtn.GoodsNo = salesDetail.GoodsNo;
                goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
                goodsCndtn.IsSettingSupplier = 1;
                goodsCndtn.ListPriorWarehouse = this.GetSearchWarehouseList();

                retGoodsCndtnList.Add(goodsCndtn);
            }

            goodsCndtnList = retGoodsCndtnList;
        }

        /// <summary>
        /// 商品検索条件オブジェクトリスト取得処理
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="estimateDetailRows">検索見積明細行リスト</param>
        /// <param name="joinSearchDivType">結合検索タイプ</param>
        /// <param name="goodsCndtnList">商品検索条件オブジェクトリスト</param>
        public void GetGoodsCndtnList(SalesSlip salesSlip, EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows, GoodsCndtn.JoinSearchDivType joinSearchDivType, out List<GoodsCndtn> goodsCndtnList)
        {
            goodsCndtnList = new List<GoodsCndtn>();
            List<GoodsCndtn> retGoodsCndtnList = new List<GoodsCndtn>();

            List<GoodsInfoKey> goodsInfoKeyList = new List<GoodsInfoKey>();
            foreach (EstimateInputDataSet.EstimateDetailRow row in estimateDetailRows)
            {
                if (( row.GoodsMakerCd == 0 ) || ( string.IsNullOrEmpty(row.GoodsNo) )) continue;

                if (goodsInfoKeyList.Contains(new GoodsInfoKey(row.GoodsNo, row.GoodsMakerCd))) continue;

                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.SectionCode = salesSlip.ResultsAddUpSecCd;
                goodsCndtn.GoodsMakerCd = row.GoodsMakerCd;
                goodsCndtn.GoodsNo = row.GoodsNo;
                goodsCndtn.JoinSearchDiv = (int)joinSearchDivType;
                goodsCndtn.IsSettingSupplier = 1;                   // 仕入先はReadしない

                retGoodsCndtnList.Add(goodsCndtn);
                goodsInfoKeyList.Add(new GoodsInfoKey(row.GoodsNo, row.GoodsMakerCd));
            }

            goodsCndtnList = retGoodsCndtnList;
        }

        /// <summary>
        /// 検索制御の共通情報を設定します。
        /// </summary>
        /// <param name="goodsCndtn">商品検索条件</param>
        private void SetCommonSerachCndtn(ref GoodsCndtn goodsCndtn)
        {
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();

            goodsCndtn.SubstCondDivCd = this._estimateInputInitDataAcs.GetSalesTtlSt().SubstCondDivCd;
            goodsCndtn.PrmSubstCondDivCd = this._estimateInputInitDataAcs.GetSalesTtlSt().PrmSubstCondDivCd;
            goodsCndtn.SubstApplyDivCd = this._estimateInputInitDataAcs.GetSalesTtlSt().SubstApplyDivCd;
            goodsCndtn.PartsSearchPriDivCd = this._estimateInputInitDataAcs.GetSalesTtlSt().PartsSearchPriDivCd;
            goodsCndtn.JoinInitDispDiv = this._estimateInputInitDataAcs.GetSalesTtlSt().JoinInitDispDiv;
            goodsCndtn.EraNameDispCd1 = this._estimateInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
            goodsCndtn.ListPriorWarehouse = this.GetSearchWarehouseList();
            goodsCndtn.SearchUICntDivCd = 1;

            goodsCndtn.CustomerCode = this._salesSlip.CustomerCode;
            goodsCndtn.CustRateGrpCode = this._salesSlip.CustRateGrpCode;
            goodsCndtn.PriceApplyDate = this._salesSlip.SalesDate;
            goodsCndtn.SalesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
            goodsCndtn.TaxRate = this._salesSlip.ConsTaxRate;
            goodsCndtn.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd;
            goodsCndtn.TtlAmntDspRateDivCd = this._estimateInputInitDataAcs.GetAllDefSet().TtlAmntDspRateDivCd;
            goodsCndtn.SalesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
        }


        /// <summary>
        /// 検索用倉庫コードリストを取得します。
        /// </summary>
        /// <returns>倉庫コードリスト</returns>
        public List<string> GetSearchWarehouseList()
        {
            List<string> warehouseList = new List<string>();
            SecInfoSet secInfoSet = this._estimateInputInitDataAcs.GetSecInfo(this._salesSlip.ResultsAddUpSecCd);

            if (secInfoSet != null)
            {
                if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd1.Trim())) warehouseList.Add(secInfoSet.SectWarehouseCd1.Trim());
                if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd2.Trim())) warehouseList.Add(secInfoSet.SectWarehouseCd2.Trim());
                if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd3.Trim())) warehouseList.Add(secInfoSet.SectWarehouseCd3.Trim());
            }

            return warehouseList;
        }

        #endregion

        // ===================================================================================== //
        // 印刷関連
        // ===================================================================================== //
        #region ●印刷関連

        /// <summary>
        /// 印刷用データを取得します。
        /// </summary>
        /// <param name="allPrintCount">印刷部数(全て）</param>
        /// <param name="purePartsPrintCount">印刷部数(純正のみ）</param>
        /// <param name="primePartsPrintCount">印刷部数(優良のみ）</param>
        /// <param name="selectedPartsPrintCount">印刷部数(選択分のみ）</param>
        /// <returns>印刷データ</returns>
        public EstFmPrintCndtn GetPrintData(int allPrintCount, int purePartsPrintCount, int primePartsPrintCount, int selectedPartsPrintCount)
        {
            // 印刷データの取得
            EstFmPrintCndtn.EstFmUnitData allPrintData = null;
            EstFmPrintCndtn.EstFmUnitData purePartsPrintData = null;
            EstFmPrintCndtn.EstFmUnitData primePartsPrintData = null;
            EstFmPrintCndtn.EstFmUnitData selectedPartsPrintData = null;

            List<EstFmPrintCndtn.EstFmUnitData> estFmUnitDataList = new List<EstFmPrintCndtn.EstFmUnitData>();

            if (allPrintCount > 0)
            {
                allPrintData = this.GetPrintData(DataGetMode.All, allPrintCount);
            }
            if (purePartsPrintCount > 0)
            {
                purePartsPrintData = this.GetPrintData(DataGetMode.PurePartsOnly, purePartsPrintCount); 
            }
            if (primePartsPrintCount > 0)
            {
                primePartsPrintData = this.GetPrintData(DataGetMode.PrimePartsOnly, primePartsPrintCount);
            }
            if (selectedPartsPrintCount > 0)
            {
                selectedPartsPrintData = this.GetPrintData(DataGetMode.SelectedPartsOnly, selectedPartsPrintCount);
            }

            if (allPrintData != null) estFmUnitDataList.Add(allPrintData);
            if (purePartsPrintData != null) estFmUnitDataList.Add(purePartsPrintData);
            if (primePartsPrintData != null) estFmUnitDataList.Add(primePartsPrintData);
            if (selectedPartsPrintData != null) estFmUnitDataList.Add(selectedPartsPrintData);

            if (estFmUnitDataList.Count == 0) return null;

            EstFmPrintCndtn estFmPrintCndtn = new EstFmPrintCndtn();
            estFmPrintCndtn.EnterpriseCode = this._enterpriseCode;
            estFmPrintCndtn.EstFmUnitDataList = estFmUnitDataList;

            // 見積初期値設定マスタの補正
            EstimateDefSet estimateDefSet = this._estimateInputInitDataAcs.GetEstimateDefSet().Clone();
            estimateDefSet.PartsNoPrtCd = this._salesSlip.PartsNoPrtCd;
            estimateDefSet.ListPricePrintDiv = this._salesSlip.ListPricePrintDiv;

            estFmPrintCndtn.EstimateDefSet = estimateDefSet;

            return estFmPrintCndtn;

        }

        /// <summary>
        /// 印刷選択しているデータが存在するかチェックします。
        /// </summary>
        /// <returns>True:印刷データ有り</returns>
        public bool ExistPrintTargetData(int purePartsPrintCount, int primePartsPrintCount, int selectedPartsPrintCount, out List<string> targetList)
        {
            bool ret = true;
            targetList = new List<string>();

            EstimateInputDataSet.EstimateDetailRow[] rows = null;
            if (purePartsPrintCount > 0)
            {
                rows = this.SelectEstimateDetailRows(string.Format("{0}<>''", this._estimateDetailDataTable.GoodsNoColumn.ColumnName), this._estimateDetailDataTable);
                if (( rows == null ) || ( rows.Length == 0 ))
                {
                    ret = false;

                    targetList.Add("純正のみ");
                }
            }

            if (primePartsPrintCount > 0)
            {
                rows = this.SelectEstimateDetailRows(string.Format("{0}<>''", this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName), this._estimateDetailDataTable);
                if (( rows == null ) || ( rows.Length == 0 ))
                {
                    ret = false;

                    targetList.Add("優良のみ");
                }
            }

            if (selectedPartsPrintCount > 0)
            {
                rows = this.SelectEstimateDetailRows(string.Format("({0}<>'' AND {1}='true') OR ({2}<>'' AND {3}='true' )", this._estimateDetailDataTable.GoodsNoColumn.ColumnName, this._estimateDetailDataTable.PrintSelectColumn.ColumnName, this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName), this._estimateDetailDataTable);
                if (( rows == null ) || ( rows.Length == 0 ))
                {
                    ret = false;

                    targetList.Add("選択分のみ");
                }
            }

            return ret;
        }

        /// <summary>
        /// 印刷用データを取得します。
        /// </summary>
        /// <param name="dataGetMode">データ取得モード</param>
        /// <param name="printCount">印刷部数</param>
        private EstFmPrintCndtn.EstFmUnitData GetPrintData(DataGetMode dataGetMode, int printCount)
        {
            EstFmPrintCndtn.EstFmUnitData estFmUnitData = null;

            SalesSlip salesSlip = this._salesSlip.Clone();
            List<SalesDetail> salesDetailList;
            ArrayList carManagementWorkList = new ArrayList();   // 車輌管理ワークオブジェクトリスト
            Dictionary<int, Dictionary<string, object>> detailAddInfoDictionary;
            this.GetCurrentCarManagementWorkList(out carManagementWorkList); // 車輌管理ワークオブジェクトリスト取得
            CarManagementWork carManagementWork = new CarManagementWork();

            FrePEstFmHead frePEstFmHead = null;                     // 見積書ヘッダ
            List<FrePEstFmDetail> frePEstFmDetailList = null;       // 見積書明細リスト

            switch (dataGetMode)
            {

                case DataGetMode.All:                               // 全て
                    // 明細リストを取得する
                    this.GetCurrentData(dataGetMode, ref salesSlip, out salesDetailList, out detailAddInfoDictionary);

                    // 純正部品の合計金額を計算する
                    SalesSlip salesSlip_PureParts = this._salesSlip.Clone();
                    List<SalesDetail> salesDetailList_PureParts;
                    Dictionary<int, Dictionary<string, object>> detailAddInfoDictionary_PureParts;
                    this.GetCurrentData(DataGetMode.PurePartsOnly, ref salesSlip_PureParts, out salesDetailList_PureParts, out detailAddInfoDictionary_PureParts);

                    // 優良部品の合計金額を計算する
                    SalesSlip salesSlip_PrimeParts = this._salesSlip.Clone();
                    List<SalesDetail> salesDetailList_PrimeParts;
                    Dictionary<int, Dictionary<string, object>> detailAddInfoDictionary_PrimeParts;
                    this.GetCurrentData(DataGetMode.PrimePartsOnly, ref salesSlip_PrimeParts, out salesDetailList_PrimeParts, out detailAddInfoDictionary_PrimeParts);

                    if (( salesDetailList != null ) && ( salesDetailList.Count > 0 ))
                    {
                        // 車輌情報の決定
                        foreach (CarManagementWork carManagementWorkWk in carManagementWorkList)
                        {
                            if (carManagementWorkWk.CarRelationGuid == salesDetailList[0].CarRelationGuid)
                            {
                                carManagementWork = carManagementWorkWk;
                                break;
                            }
                        }
                        // 見積書ヘッダ
                        frePEstFmHead = this.CreateFrePEstFmHead(salesSlip_PureParts, salesSlip_PrimeParts, carManagementWork);

                        // 見積書明細リストの生成
                        SortedDictionary<int, SortedDictionary<int, SalesDetail>> detailDictionary = new SortedDictionary<int, SortedDictionary<int, SalesDetail>>();

                        // 同一行を純正・優良に振り分ける
                        foreach (SalesDetail salesDetail in salesDetailList)
                        {
                            SortedDictionary<int, SalesDetail> rowInfoDictionary;
                            if (detailDictionary.ContainsKey(salesDetail.SalesRowNo))
                            {
                                rowInfoDictionary = detailDictionary[salesDetail.SalesRowNo];
                                if (rowInfoDictionary.ContainsKey(salesDetail.SalesRowDerivNo))
                                {
                                    rowInfoDictionary[salesDetail.SalesRowDerivNo] = salesDetail;
                                }
                                else
                                {
                                    rowInfoDictionary.Add(salesDetail.SalesRowDerivNo, salesDetail);
                                }
                            }
                            else
                            {
                                rowInfoDictionary = new SortedDictionary<int, SalesDetail>();
                                rowInfoDictionary.Add(salesDetail.SalesRowDerivNo, salesDetail);
                                detailDictionary.Add(salesDetail.SalesRowNo, rowInfoDictionary);
                            }
                        }

                        frePEstFmDetailList = new List<FrePEstFmDetail>();
                        foreach (int salesRowNo in detailDictionary.Keys)
                        {
                            SortedDictionary<int, SalesDetail> rowInfoDictionary = detailDictionary[salesRowNo];

                            frePEstFmDetailList.Add(this.CreateFrePEstFmDetail(salesSlip_PureParts,
                                                                               ( rowInfoDictionary.ContainsKey((int)SalesRowDerivNo.PureParts) ) ? rowInfoDictionary[(int)SalesRowDerivNo.PureParts] : null,
                                                                               ( rowInfoDictionary.ContainsKey((int)SalesRowDerivNo.PrimeParts) ) ? rowInfoDictionary[(int)SalesRowDerivNo.PrimeParts] : null,
                                                                               ( detailAddInfoDictionary.ContainsKey(salesRowNo) ) ? detailAddInfoDictionary[salesRowNo] : null));
                        }
                        // --- ADD 2012/10/25 T.Miyamoto ------------------------------>>>>>
                        foreach (FrePEstFmDetail frePEstFmDetail in frePEstFmDetailList)
                        {
                            // --- UPD 2012/12/27 T.Miyamoto ------------------------------>>>>>
                            //if (frePEstFmDetail.DPURE_BLGOODSCODERF == 0 && frePEstFmDetail.DPRIM_BLGOODSCODERF != 0)
                            if (frePEstFmDetail.DPURE_GOODSNAMEKANARF == "")
                            // --- UPD 2012/12/27 T.Miyamoto ------------------------------<<<<<
                            {
                                frePEstFmDetail.DPURE_BLGOODSCODERF = frePEstFmDetail.DPRIM_BLGOODSCODERF;
                                frePEstFmDetail.DPURE_GOODSNAMEKANARF = frePEstFmDetail.DPRIM_GOODSNAMEKANARF;
                            }
                        }
                        // --- ADD 2012/10/25 T.Miyamoto ------------------------------<<<<<

                        // 行番号の再付番
                        int rowNo = 1;
                        foreach (FrePEstFmDetail frePEstFmDetail in frePEstFmDetailList)
                        {
                            frePEstFmDetail.SALESDETAILRF_SALESROWNORF = rowNo;
                            rowNo++;
                        }
                    }

                    break;
                case DataGetMode.PurePartsOnly:                     // 純正のみ
                case DataGetMode.PrimePartsOnly:                    // 優良のみ
                case DataGetMode.SelectedPartsOnly:                 // 選択分のみ
                    // 合計金額が計算された売上データを取得する。
                    this.GetCurrentData(dataGetMode, ref salesSlip, out salesDetailList, out detailAddInfoDictionary);

                    if (( salesDetailList != null ) && ( salesDetailList.Count > 0 ))
                    {
                        // 車輌情報の決定
                        foreach(CarManagementWork carManagementWorkWk in carManagementWorkList)
                        {
                            if (carManagementWorkWk.CarRelationGuid ==  salesDetailList[0].CarRelationGuid)
                            {
                                carManagementWork = carManagementWorkWk;
                                break;
                            }
                        }
                        // 見積書ヘッダ
                        frePEstFmHead = this.CreateFrePEstFmHead(salesSlip, null, carManagementWork);

                        // 見積書明細リストの生成
                        frePEstFmDetailList = new List<FrePEstFmDetail>();
                        foreach (SalesDetail salesDetail in salesDetailList)
                        {
                            frePEstFmDetailList.Add(this.CreateFrePEstFmDetail(salesSlip, salesDetail, null, ( detailAddInfoDictionary.ContainsKey(salesDetail.SalesRowNo) ) ? detailAddInfoDictionary[salesDetail.SalesRowNo] : null));
                        }

                        // 行番号の再付番
                        int rowNo = 1;
                        foreach(FrePEstFmDetail frePEstFmDetail in frePEstFmDetailList)
                        {
                            frePEstFmDetail.SALESDETAILRF_SALESROWNORF = rowNo;
                            rowNo++;
                        }
                    }

                    break;
            }

            
            if (( frePEstFmHead != null ) && ( frePEstFmDetailList != null ))
            {
                switch (dataGetMode)
                {
                    case DataGetMode.All:
                        frePEstFmHead.HADD_ESTFMDIVRF = EstFmDivState.All;
                        break;
                    case DataGetMode.PurePartsOnly:
                        frePEstFmHead.HADD_ESTFMDIVRF = EstFmDivState.Pure;
                        break;
                    case DataGetMode.PrimePartsOnly:
                        frePEstFmHead.HADD_ESTFMDIVRF = EstFmDivState.Prime;
                        break;
                    case DataGetMode.SelectedPartsOnly:
                        frePEstFmHead.HADD_ESTFMDIVRF = EstFmDivState.Selection;
                        break;
                }

                estFmUnitData = new EstFmPrintCndtn.EstFmUnitData();
                estFmUnitData.PrintCount = printCount;
                estFmUnitData.FrePEstFmHead = frePEstFmHead;
                estFmUnitData.FrePEstFmDetailList = frePEstFmDetailList;

            }

            return estFmUnitData;
        }

        /// <summary>
        /// 自由帳票見積書ヘッダデータオブジェクトを生成します。
        /// </summary>
        /// <param name="basicSalesSlip">元売上データ</param>
        /// <param name="primePartsSalesSlip">優良売上データ（優良金額のセットにのみ使用）</param>
        /// <param name="carManagementWork">受注マスタ（車輌）</param>
        /// <returns>自由帳票見積書ヘッダデータオブジェクト</returns>
        private FrePEstFmHead CreateFrePEstFmHead(SalesSlip basicSalesSlip, SalesSlip primePartsSalesSlip, CarManagementWork carManagementWork)
        {
            FrePEstFmHead frePEstFmHead = new FrePEstFmHead();

            #region 元売上データからセットする項目

            frePEstFmHead.SALESSLIPRF_SALESSLIPNUMRF = basicSalesSlip.SalesSlipNum;                     // 売上伝票番号
            frePEstFmHead.SALESSLIPRF_SECTIONCODERF = basicSalesSlip.ResultsAddUpSecCd;                 // 拠点コード
            frePEstFmHead.SALESSLIPRF_SALESDATERF = basicSalesSlip.SalesDate;                           // 売上日
            frePEstFmHead.SALESSLIPRF_ESTIMATEFORMNORF = basicSalesSlip.EstimateFormNo;                 // 見積書番号
            frePEstFmHead.SALESSLIPRF_ESTIMATEDIVIDERF = basicSalesSlip.EstimateDivide;                 // 見積区分
            frePEstFmHead.SALESSLIPRF_SALESINPUTCODERF = basicSalesSlip.SalesInputCode;                 // 売上入力者コード
            frePEstFmHead.SALESSLIPRF_SALESINPUTNAMERF = basicSalesSlip.SalesInputName;                 // 売上入力者名称
            frePEstFmHead.SALESSLIPRF_FRONTEMPLOYEECDRF = basicSalesSlip.FrontEmployeeCd;               // 受付従業員コード
            frePEstFmHead.SALESSLIPRF_FRONTEMPLOYEENMRF = basicSalesSlip.FrontEmployeeNm;               // 受付従業員名称
            frePEstFmHead.SALESSLIPRF_SALESEMPLOYEECDRF = basicSalesSlip.SalesEmployeeCd;               // 販売従業員コード
            frePEstFmHead.SALESSLIPRF_SALESEMPLOYEENMRF = basicSalesSlip.SalesEmployeeNm;               // 販売従業員名称
            frePEstFmHead.SALESSLIPRF_CONSTAXLAYMETHODRF = basicSalesSlip.ConsTaxLayMethod;             // 消費税転嫁方式
            frePEstFmHead.SALESSLIPRF_CUSTOMERCODERF = basicSalesSlip.CustomerCode;                     // 得意先コード
            frePEstFmHead.SALESSLIPRF_CUSTOMERNAMERF = basicSalesSlip.CustomerName;                     // 得意先名称
            frePEstFmHead.SALESSLIPRF_CUSTOMERNAME2RF = basicSalesSlip.CustomerName2;                   // 得意先名称2
            frePEstFmHead.SALESSLIPRF_CUSTOMERSNMRF = basicSalesSlip.CustomerSnm;                       // 得意先略称
            frePEstFmHead.SALESSLIPRF_HONORIFICTITLERF = basicSalesSlip.HonorificTitle;                 // 得意先敬称
            frePEstFmHead.SALESSLIPRF_SALESSLIPPRINTDATERF = basicSalesSlip.SalesSlipPrintDate;         // 売上伝票発行日
            frePEstFmHead.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF = basicSalesSlip.TotalAmountDispWayCd;     // 総額表示区分

            frePEstFmHead.HEST_ESTIMATETITLE1RF = basicSalesSlip.EstimateTitle1;                        // 見積タイトル１
            frePEstFmHead.HEST_ESTIMATENOTE1RF = basicSalesSlip.EstimateNote1;                          // 見積備考１
            frePEstFmHead.HEST_ESTIMATENOTE2RF = basicSalesSlip.EstimateNote2;                          // 見積備考２
            frePEstFmHead.HEST_ESTIMATENOTE3RF = basicSalesSlip.EstimateNote3;                          // 見積備考３
            frePEstFmHead.HEST_ESTIMATEVALIDITYLIMITRF = basicSalesSlip.EstimateValidityDate;           // 見積有効期限

            frePEstFmHead.HPURE_SALESTOTALTAXINCRF = basicSalesSlip.SalesTotalTaxInc;                   // 純正売上伝票合計（税込み）
            frePEstFmHead.HPURE_SALESTOTALTAXEXCRF = basicSalesSlip.SalesTotalTaxExc;                   // 純正売上伝票合計（税抜き）
            frePEstFmHead.HPURE_SALESSUBTOTALTAXINCRF = basicSalesSlip.SalesSubtotalTaxInc;             // 純正売上小計（税込み）
            frePEstFmHead.HPURE_SALESSUBTOTALTAXEXCRF = basicSalesSlip.SalesSubtotalTaxExc;             // 純正売上小計（税抜き）
            frePEstFmHead.HPURE_SALESSUBTOTALTAXRF = basicSalesSlip.SalesSubtotalTax;                   // 純正売上小計（税）

            #endregion

            #region 優良売上データからセットする項目

            if (primePartsSalesSlip != null)
            {
                frePEstFmHead.HPRIME_SALESTOTALTAXINCRF = primePartsSalesSlip.SalesTotalTaxInc;         // 優良売上伝票合計（税込み）
                frePEstFmHead.HPRIME_SALESTOTALTAXEXCRF = primePartsSalesSlip.SalesTotalTaxExc;         // 優良売上伝票合計（税抜き）
                frePEstFmHead.HPRIME_SALESSUBTOTALTAXINCRF = primePartsSalesSlip.SalesSubtotalTaxInc;   // 優良売上小計（税込み）
                frePEstFmHead.HPRIME_SALESSUBTOTALTAXEXCRF = primePartsSalesSlip.SalesSubtotalTaxExc;   // 優良売上小計（税抜き）
                frePEstFmHead.HPRIME_SALESSUBTOTALTAXRF = primePartsSalesSlip.SalesSubtotalTax;         // 優良売上小計（税）
            }

            #endregion

            #region 受注マスタ（車輌）からセットする項目

            if (carManagementWork != null)
            {
                frePEstFmHead.HADD_CARMNGNORF = carManagementWork.CarMngNo;                         // 車輌管理番号
                frePEstFmHead.HADD_CARMNGCODERF = carManagementWork.CarMngCode;                     // 車輌管理コード
                frePEstFmHead.HADD_NUMBERPLATE1CODERF = carManagementWork.NumberPlate1Code;         // 陸運事務所番号
                frePEstFmHead.HADD_NUMBERPLATE1NAMERF = carManagementWork.NumberPlate1Name;         // 陸運事務局名称
                frePEstFmHead.HADD_NUMBERPLATE2RF = carManagementWork.NumberPlate2;                 // 車輌登録番号（種別）
                frePEstFmHead.HADD_NUMBERPLATE3RF = carManagementWork.NumberPlate3;                 // 車輌登録番号（カナ）
                frePEstFmHead.HADD_NUMBERPLATE4RF = carManagementWork.NumberPlate4;                 // 車輌登録番号（プレート番号）
                frePEstFmHead.HADD_FIRSTENTRYDATERF = carManagementWork.FirstEntryDate;             // 初年度
                frePEstFmHead.HADD_MAKERCODERF = carManagementWork.MakerCode;                       // メーカーコード
                frePEstFmHead.HADD_MAKERFULLNAMERF = carManagementWork.MakerFullName;               // メーカー全角名称
                frePEstFmHead.HADD_MAKERHALFNAMERF = carManagementWork.MakerHalfName;               // メーカー半角名称
                frePEstFmHead.HADD_MODELCODERF = carManagementWork.ModelCode;                       // 車種コード
                frePEstFmHead.HADD_MODELSUBCODERF = carManagementWork.ModelSubCode;                 // 車種サブコード
                frePEstFmHead.HADD_MODELFULLNAMERF = carManagementWork.ModelFullName;               // 車種全角名称
                frePEstFmHead.HADD_MODELHALFNAMERF = carManagementWork.ModelHalfName;               // 車種半角名称
                frePEstFmHead.HADD_EXHAUSTGASSIGNRF = carManagementWork.ExhaustGasSign;             // 排ガス記号
                frePEstFmHead.HADD_SERIESMODELRF = carManagementWork.SeriesModel;                   // シリーズ型式
                frePEstFmHead.HADD_CATEGORYSIGNMODELRF = carManagementWork.CategorySignModel;       // 型式（類別記号）
                frePEstFmHead.HADD_FULLMODELRF = carManagementWork.FullModel;                       // 型式（フル型）
                frePEstFmHead.HADD_MODELDESIGNATIONNORF = carManagementWork.ModelDesignationNo;     // 型式指定番号
                frePEstFmHead.HADD_CATEGORYNORF = carManagementWork.CategoryNo;                     // 類別番号
                frePEstFmHead.HADD_FRAMEMODELRF = carManagementWork.FrameModel;                     // 車台型式
                frePEstFmHead.HADD_FRAMENORF = carManagementWork.FrameNo;                           // 車台番号
                frePEstFmHead.HADD_SEARCHFRAMENORF = carManagementWork.SearchFrameNo;               // 車台番号（検索用）
                frePEstFmHead.HADD_ENGINEMODELNMRF = carManagementWork.EngineModelNm;               // エンジン型式名称
                frePEstFmHead.HADD_RELEVANCEMODELRF = carManagementWork.RelevanceModel;             // 関連型式
                frePEstFmHead.HADD_SUBCARNMCDRF = carManagementWork.SubCarNmCd;                     // サブ車名コード
                frePEstFmHead.HADD_MODELGRADESNAMERF = carManagementWork.ModelGradeSname;           // 型式グレード略称
                frePEstFmHead.HADD_COLORCODERF = carManagementWork.ColorCode;                       // カラーコード
                frePEstFmHead.HADD_COLORNAME1RF = carManagementWork.ColorName1;                     // カラー名称1
                frePEstFmHead.HADD_TRIMCODERF = carManagementWork.TrimCode;                         // トリムコード
                frePEstFmHead.HADD_TRIMNAMERF = carManagementWork.TrimName;                         // トリム名称
                frePEstFmHead.HADD_MILEAGERF = carManagementWork.Mileage;                           // 車輌走行距離
                frePEstFmHead.HADD_SYSTEMATICCODERF = carManagementWork.SystematicCode;             // 系統コード
                frePEstFmHead.HADD_SYSTEMATICNAMERF = carManagementWork.SystematicName;             // 系統名称
                frePEstFmHead.HADD_STPRODUCETYPEOFYEARRF = carManagementWork.StProduceTypeOfYear;   // 開始生産年式
                frePEstFmHead.HADD_EDPRODUCETYPEOFYEARRF = carManagementWork.EdProduceTypeOfYear;   // 終了生産年式
                frePEstFmHead.HADD_DOORCOUNTRF = carManagementWork.DoorCount;                       // ドア数
                frePEstFmHead.HADD_BODYNAMECODERF = carManagementWork.BodyNameCode;                 // ボディー名コード
                frePEstFmHead.HADD_BODYNAMERF = carManagementWork.BodyName;                         // ボディー名称
                frePEstFmHead.HADD_STPRODUCEFRAMENORF = carManagementWork.StProduceFrameNo;         // 生産車台番号開始
                frePEstFmHead.HADD_EDPRODUCEFRAMENORF = carManagementWork.EdProduceFrameNo;         // 生産車台番号終了
                frePEstFmHead.HADD_ENGINEMODELRF = carManagementWork.EngineModel;                   // 原動機型式（エンジン）
                frePEstFmHead.HADD_MODELGRADENMRF = carManagementWork.ModelGradeNm;                 // 型式グレード名称
                frePEstFmHead.HADD_ENGINEDISPLACENMRF = carManagementWork.EngineDisplaceNm;         // 排気量名称
                frePEstFmHead.HADD_EDIVNMRF = carManagementWork.EDivNm;                             // E区分名称
                frePEstFmHead.HADD_TRANSMISSIONNMRF = carManagementWork.TransmissionNm;             // ミッション名称
                frePEstFmHead.HADD_SHIFTNMRF = carManagementWork.ShiftNm;                           // シフト名称
                frePEstFmHead.HADD_WHEELDRIVEMETHODNMRF = carManagementWork.WheelDriveMethodNm;     // 駆動方式名称
                frePEstFmHead.HADD_ADDICARSPEC1RF = carManagementWork.AddiCarSpec1;                 // 追加諸元1
                frePEstFmHead.HADD_ADDICARSPEC2RF = carManagementWork.AddiCarSpec2;                 // 追加諸元2
                frePEstFmHead.HADD_ADDICARSPEC3RF = carManagementWork.AddiCarSpec3;                 // 追加諸元3
                frePEstFmHead.HADD_ADDICARSPEC4RF = carManagementWork.AddiCarSpec4;                 // 追加諸元4
                frePEstFmHead.HADD_ADDICARSPEC5RF = carManagementWork.AddiCarSpec5;                 // 追加諸元5
                frePEstFmHead.HADD_ADDICARSPEC6RF = carManagementWork.AddiCarSpec6;                 // 追加諸元6
                frePEstFmHead.HADD_ADDICARSPECTITLE1RF = carManagementWork.AddiCarSpecTitle1;       // 追加諸元タイトル1
                frePEstFmHead.HADD_ADDICARSPECTITLE2RF = carManagementWork.AddiCarSpecTitle2;       // 追加諸元タイトル2
                frePEstFmHead.HADD_ADDICARSPECTITLE3RF = carManagementWork.AddiCarSpecTitle3;       // 追加諸元タイトル3
                frePEstFmHead.HADD_ADDICARSPECTITLE4RF = carManagementWork.AddiCarSpecTitle4;       // 追加諸元タイトル4
                frePEstFmHead.HADD_ADDICARSPECTITLE5RF = carManagementWork.AddiCarSpecTitle5;       // 追加諸元タイトル5
                frePEstFmHead.HADD_ADDICARSPECTITLE6RF = carManagementWork.AddiCarSpecTitle6;       // 追加諸元タイトル6

            }

            #endregion

            return frePEstFmHead;
        }

        /// <summary>
        /// 自由帳票見積書明細データオブジェクトを生成します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="salesDetail_PurePasts">売上明細データ(純正情報)</param>
        /// <param name="salesDetail_PrimePasts">売上明細データ(優良情報)</param>
        /// <param name="detailAddInfo">明細追加情報</param>
        /// <returns>自由帳票見積書明細データオブジェクト</returns>
        private FrePEstFmDetail CreateFrePEstFmDetail(SalesSlip salesSlip, SalesDetail salesDetail_PurePasts, SalesDetail salesDetail_PrimePasts, Dictionary<string, object> detailAddInfo)
        {
            FrePEstFmDetail frePEstFmDetail = new FrePEstFmDetail();

            #region ヘッダからセットする項目

            frePEstFmDetail.SALESDETAILRF_SALESSLIPNUMRF = salesSlip.SalesSlipNum;                      // 売上伝票番号

            #endregion

            #region 純正部品項目

            if (salesDetail_PurePasts != null)
            {
                frePEstFmDetail.SALESDETAILRF_SALESROWNORF = salesDetail_PurePasts.SalesRowNo;          // 売上行番号
                frePEstFmDetail.DPURE_GOODSMAKERCDRF = salesDetail_PurePasts.GoodsMakerCd;              // 純正メーカーコード
                frePEstFmDetail.DPURE_MAKERNAMERF = salesDetail_PurePasts.MakerName;                    // 純正メーカー名称
                frePEstFmDetail.DPURE_MAKERKANANAMERF = salesDetail_PurePasts.MakerKanaName;            // 純正メーカーカナ名称
                frePEstFmDetail.DPURE_GOODSNAMERF = salesDetail_PurePasts.GoodsName;                    // 純正商品名称
                frePEstFmDetail.DPURE_GOODSNAMEKANARF= salesDetail_PurePasts.GoodsNameKana;             // 純正商品名称（カナ）
                frePEstFmDetail.DPURE_GOODSNORF = salesDetail_PurePasts.GoodsNo;                        // 純正商品番号
                frePEstFmDetail.DPURE_SALESUNPRCTAXEXCFLRF = salesDetail_PurePasts.SalesUnPrcTaxExcFl;  // 純正売上単価（税抜き）
                frePEstFmDetail.DPURE_SALESUNPRCTAXINCFLRF = salesDetail_PurePasts.SalesUnPrcTaxIncFl;  // 純正売上単価（税込み）
                frePEstFmDetail.DPURE_LISTPRICETAXEXCFLRF = salesDetail_PurePasts.ListPriceTaxExcFl;    // 純正定価（税抜き）
                frePEstFmDetail.DPURE_LISTPRICETAXINCFLRF = salesDetail_PurePasts.ListPriceTaxIncFl;    // 純正定価（税込み）
                frePEstFmDetail.DPURE_SALESMONEYTAXEXCRF = salesDetail_PurePasts.SalesMoneyTaxExc;      // 純正売上金額（税抜き）
                frePEstFmDetail.DPURE_SALESMONEYTAXINCRF = salesDetail_PurePasts.SalesMoneyTaxInc;      // 純正売上金額（税込み）
                frePEstFmDetail.DPURE_SHIPMENTCNTRF = salesDetail_PurePasts.ShipmentCnt;                // 純正出荷数
                frePEstFmDetail.DPURE_BLGOODSCODERF = salesDetail_PurePasts.BLGoodsCode;                // 純正BLコード
                frePEstFmDetail.DPURE_TAXATIONDIVCDRF = salesDetail_PurePasts.TaxationDivCd;            // 純正課税区分
            }

            #endregion

            #region 優良部品

            if (salesDetail_PrimePasts != null)
            {
                frePEstFmDetail.DPRIM_GOODSMAKERCDRF = salesDetail_PrimePasts.GoodsMakerCd;             // 優良メーカーコード
                frePEstFmDetail.DPRIM_MAKERNAMERF = salesDetail_PrimePasts.MakerName;                   // 優良メーカー名称
                frePEstFmDetail.DPRIM_MAKERKANANAMERF = salesDetail_PrimePasts.MakerKanaName;           // 優良メーカーカナ名称
                frePEstFmDetail.DPRIM_GOODSNAMERF = salesDetail_PrimePasts.GoodsName;                   // 優良商品名称
                frePEstFmDetail.DPRIM_GOODSNAMEKANARF = salesDetail_PrimePasts.GoodsNameKana;           // 優良商品名称カナ
                frePEstFmDetail.DPRIM_GOODSNORF = salesDetail_PrimePasts.GoodsNo;                       // 優良商品番号
                frePEstFmDetail.DPRIM_SALESUNPRCTAXEXCFLRF = salesDetail_PrimePasts.SalesUnPrcTaxExcFl; // 優良売上単価（税抜き）
                frePEstFmDetail.DPRIM_SALESUNPRCTAXINCFLRF = salesDetail_PrimePasts.SalesUnPrcTaxIncFl; // 優良売上単価（税込み）
                frePEstFmDetail.DPRIM_LISTPRICETAXEXCFLRF = salesDetail_PrimePasts.ListPriceTaxExcFl;   // 優良定価（税抜き）
                frePEstFmDetail.DPRIM_LISTPRICETAXINCFLRF = salesDetail_PrimePasts.ListPriceTaxIncFl;   // 優良定価（税込み）
                frePEstFmDetail.DPRIM_SALESMONEYTAXEXCRF = salesDetail_PrimePasts.SalesMoneyTaxExc;     // 優良売上金額（税抜き）
                frePEstFmDetail.DPRIM_SALESMONEYTAXINCRF = salesDetail_PrimePasts.SalesMoneyTaxInc;     // 優良売上金額（税込み）
                frePEstFmDetail.DPRIM_SHIPMENTCNTRF = salesDetail_PrimePasts.ShipmentCnt;               // 優良出荷数
                frePEstFmDetail.DPRIM_BLGOODSCODERF = salesDetail_PrimePasts.BLGoodsCode;               // 優良BLコード
                frePEstFmDetail.DPRIM_TAXATIONDIVCDRF = salesDetail_PrimePasts.TaxationDivCd;           // 優良課税区分

                //frePEstFmDetail.DADD_PRIMEXISTSRF = 1;
            }

            #endregion

            if (detailAddInfo != null)
            {
                if (detailAddInfo.ContainsKey(this._estimateDetailDataTable.SpecialNoteColumn.ColumnName))
                {
                    frePEstFmDetail.DADD_SPECIALNOTE = (string)detailAddInfo[this._estimateDetailDataTable.SpecialNoteColumn.ColumnName];
                }
            }
       
            return frePEstFmDetail;
        }

        #endregion

        // ===================================================================================== //
        // 発注選択関連
        // ===================================================================================== //
        #region ●発注選択関連

        /// <summary>
        /// 発注選択情報をデータに反映します。
        /// </summary>
        /// <param name="uoeOrderDataTable"></param>
        /// <param name="uoeOrderDetailDataTable"></param>
        public void ReflectionOrderSelectInfo(EstimateInputDataSet.UOEOrderDataTable uoeOrderDataTable, EstimateInputDataSet.UOEOrderDetailDataTable uoeOrderDetailDataTable)
        {
            try
            {
                this._estimateDetailDataTable.BeginLoadData();
                this._primeInfoDataTable.BeginLoadData();
                this._uoeOrderDataTable.BeginLoadData();
                this._uoeOrderDetailDataTable.BeginLoadData();

                #region 発注情報の解除


                EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows = this.SelectEstimateDetailRows(string.Format("{0}<>'{1}' OR {2}<>'{3}'", this._estimateDetailDataTable.UOEOrderGuidColumn.ColumnName, Guid.Empty, this._estimateDetailDataTable.UOEOrderGuid_PrimeColumn.ColumnName, Guid.Empty), _estimateDetailDataTable);

                if (( estimateDetailRows != null ) && ( estimateDetailRows.Length > 0 ))
                {
                    foreach (EstimateInputDataSet.EstimateDetailRow estimateDetailRow in estimateDetailRows)
                    {
                        estimateDetailRow.UOEOrderGuid = Guid.Empty;
                        estimateDetailRow.UOEOrderGuid_Prime = Guid.Empty;
                    }
                }

                EstimateInputDataSet.PrimeInfoRow[] primeInfoRows = this.SelectPrimeInfoRows(string.Format("{0}<>'{1}'", this._primeInfoDataTable.UOEOrderGuidColumn.ColumnName, Guid.Empty), this._primeInfoDataTable);

                if (( primeInfoRows != null ) && ( primeInfoRows.Length > 0 ))
                {
                    foreach (EstimateInputDataSet.PrimeInfoRow primeInfoRow in primeInfoRows)
                    {
                        primeInfoRow.UOEOrderGuid = Guid.Empty;
                    }
                }

                #endregion

                
                this._uoeOrderDataTable.Rows.Clear();
                this._uoeOrderDataTable = (EstimateInputDataSet.UOEOrderDataTable)uoeOrderDataTable.Copy();
                this._uoeOrderDetailDataTable.Rows.Clear();
                this._uoeOrderDetailDataTable = (EstimateInputDataSet.UOEOrderDetailDataTable)uoeOrderDetailDataTable.Copy();

                foreach (EstimateInputDataSet.UOEOrderDetailRow uoeOrderDetailRow in this._uoeOrderDetailDataTable.Rows)
                {
                    estimateDetailRows = this.SelectEstimateDetailRows(string.Format("{0}='{1}'", this._estimateDetailDataTable.DtlRelationGuidColumn.ColumnName, uoeOrderDetailRow.DtlRelationGuid), this._estimateDetailDataTable);
                    if (( estimateDetailRows != null ) && ( estimateDetailRows.Length > 0 ))
                    {
                        foreach (EstimateInputDataSet.EstimateDetailRow estimateDetailRow in estimateDetailRows)
                        {
                            estimateDetailRow.UOEOrderGuid = uoeOrderDetailRow.OrderGuid;
                        }
                    }
                    else
                    {
                        estimateDetailRows = this.SelectEstimateDetailRows(string.Format("{0}='{1}'", this._estimateDetailDataTable.DtlRelationGuid_PrimeColumn.ColumnName, uoeOrderDetailRow.DtlRelationGuid), this._estimateDetailDataTable);
                        if (( estimateDetailRows != null ) && ( estimateDetailRows.Length > 0 ))
                        {
                            foreach (EstimateInputDataSet.EstimateDetailRow estimateDetailRow in estimateDetailRows)
                            {
                                estimateDetailRow.UOEOrderGuid_Prime = uoeOrderDetailRow.OrderGuid;
                            }
                        }


                        primeInfoRows = this.SelectPrimeInfoRows(string.Format("{0}='{1}'", this._primeInfoDataTable.DtlRelationGuidColumn.ColumnName, uoeOrderDetailRow.DtlRelationGuid), this._primeInfoDataTable);

                        if (( primeInfoRows != null ) && ( primeInfoRows.Length > 0 ))
                        {
                            foreach (EstimateInputDataSet.PrimeInfoRow primeInfoRow in primeInfoRows)
                            {
                                primeInfoRow.UOEOrderGuid = uoeOrderDetailRow.OrderGuid;
                            }
                        }
                    }
                }
            }
            finally
            {
                this._estimateDetailDataTable.EndLoadData();
                this._primeInfoDataTable.EndLoadData();
                this._uoeOrderDataTable.EndLoadData();
                this._uoeOrderDetailDataTable.EndLoadData();
            }
        }

        /// <summary>
        /// 発注選択明細データ削除処理
        /// </summary>
        /// <param name="dtlRelationGuid">明細連結ＧＵＩＤ</param>
        /// <param name="uoeOrderGuid">ＵＯＥ発注ＧＵＩＤ</param>
        private void DeleteUOEOrderDetail(Guid dtlRelationGuid,out Guid uoeOrderGuid)
        {
            uoeOrderGuid=Guid.Empty;
            EstimateInputDataSet.UOEOrderDetailRow uoeOrderDetailRow = this._uoeOrderDetailDataTable.FindByDtlRelationGuid(dtlRelationGuid);

            if (uoeOrderDetailRow != null)
            {
                this._uoeOrderDetailDataTable.RemoveUOEOrderDetailRow(uoeOrderDetailRow);
                uoeOrderGuid = uoeOrderDetailRow.OrderGuid;
            }
        }

        /// <summary>
        /// 発注選択データ削除処理
        /// </summary>
        /// <param name="uoeOrderGuid"></param>
        private void DeleteUOEOrder(Guid uoeOrderGuid)
        {
            uoeOrderGuid = Guid.Empty;
            EstimateInputDataSet.UOEOrderRow uoeOrderRow = this._uoeOrderDataTable.FindByOrderGuid(uoeOrderGuid);

            if (uoeOrderRow != null)
            {
                this._uoeOrderDataTable.RemoveUOEOrderRow(uoeOrderRow);
            }
        }

        /// <summary>
        /// 発注選択情報を削除します。
        /// </summary>
        /// <param name="dtlRelationGuid"></param>
        private void DeleteOrderSelectInfo(Guid dtlRelationGuid)
        {
            Guid orderGuid;
            this.DeleteUOEOrderDetail(dtlRelationGuid, out orderGuid);

            if (orderGuid != Guid.Empty)
            {
                EstimateInputDataSet.UOEOrderDetailRow[] uoeOrderDetailRows = (EstimateInputDataSet.UOEOrderDetailRow[])this._uoeOrderDetailDataTable.Select(string.Format("{0}='{1}'", this._uoeOrderDetailDataTable.OrderGuidColumn.ColumnName, orderGuid));

                if (( uoeOrderDetailRows == null ) || ( uoeOrderDetailRows.Length == 0 ))
                {
                    this.DeleteUOEOrder(orderGuid);
                }
            }
        }

        #endregion

        // ADD 2010/05/17 品名表示対応 ---------->>>>>
        /// <summary>
        /// BL商品情報を取得します。
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <returns>BL商品情報</returns>
        private BLGoodsCdUMnt GetBLGoodsInfo(int blGoodsCode)
        {
            return this._estimateInputInitDataAcs.GetBLGoodsCdUMntFromCache(blGoodsCode);
        }
        // ADD 2010/05/17 品名表示対応 ----------<<<<<

        // --- ADD 2012/09/07 Y.Wakita ---------->>>>>
        /// <summary>
        /// 車輌情報取得
        /// </summary>
        /// <param name="carInfoRow">車両情報行オブジェクト</param>
        /// <param name="selectedInfo">イベントパラメータクラス</param>
        public int SearchCarManagement(EstimateInputDataSet.CarInfoRow carInfoRow, out CarMangInputExtraInfo selectedInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            selectedInfo = new CarMangInputExtraInfo();
            try
            {
                string errMsg = string.Empty;

                // --- ADD 2012/09/12 Y.Wakita ---------->>>>>
                if (carInfoRow.CustomerCode == 0)
                {
                    SalesSlip salesSlip = this._salesSlip.Clone();
                    carInfoRow.CustomerCode = salesSlip.CustomerCode;
                }
                // --- ADD 2012/09/12 Y.Wakita ----------<<<<<

                // 得意先コード
                selectedInfo.CustomerCode = carInfoRow.CustomerCode;
                // 車輌管理番号
                selectedInfo.CarMngNo = carInfoRow.CarMngNo;
                // 管理番号
                selectedInfo.CarMngCode = carInfoRow.CarMngCode;
                // 車輌備考
                selectedInfo.CarNote = carInfoRow.CarNote;

                // 車輌管理マスタの検索
                status = CarMngInputAcs.GetInstance().ReadDB(ref selectedInfo, 0, out errMsg);
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        // --- ADD 2012/09/07 Y.Wakita ----------<<<<<

        // --- ADD 譚洪 2014/09/01 ---------->>>>>
        /// <summary>
        /// 車両情報がTHREADに設定します。
        /// </summary>
        /// <returns></returns>
        public void SetCarInfoToThread(GoodsCndtn cndtn)
        {
            // TLS用の変数
            CarInfoThreadData carInfoThreadData = new CarInfoThreadData();

            // 車両情報
            if (cndtn != null && cndtn.SearchCarInfo != null)
            {
                if (cndtn.SearchCarInfo.CarModelUIData.Count > 0)
                {
                    // 類別(PMの情報)
                    carInfoThreadData.ModelDesignationNo = cndtn.SearchCarInfo.CarModelUIData[0].ModelDesignationNo;
                    // 番号(PMの情報)
                    carInfoThreadData.CategoryNo = cndtn.SearchCarInfo.CarModelUIData[0].CategoryNo;
                    // 車台番号(PMの情報)
                    carInfoThreadData.FrameNo = cndtn.SearchCarInfo.CarModelUIData[0].FrameNo;
                    // 国産／外車区分(PMの情報)車輌管理マスタ「1:国産,2:外車」
                    carInfoThreadData.FrameNoKubun = cndtn.SearchCarInfo.CarModelUIData[0].DomesticForeignCode;
                    // 年式(PMの情報)
                    carInfoThreadData.FirstEntryDate = cndtn.SearchCarInfo.CarModelUIData[0].ProduceTypeOfYearInput;
                }

                if (cndtn.SearchCarInfo.CarModelInfoSummarized.Count > 0)
                {
                    PMKEN01010E.CarModelInfoRow[] row = (PMKEN01010E.CarModelInfoRow[])cndtn.SearchCarInfo.CarModelInfoSummarized.Select("SelectionState = true", "", DataViewRowState.CurrentRows);
                    if (row.Length > 0)
                    {
                        // メーカー(PMの情報)
                        carInfoThreadData.MakerCode = row[0].MakerCode;
                        // 車種(PMの情報)(PMの情報)
                        carInfoThreadData.ModelCode = row[0].ModelCode;
                        // 車種サブコード(PMの情報)
                        carInfoThreadData.ModelSubCode = row[0].ModelSubCode;
                        // 車種名(PMの情報)
                        carInfoThreadData.ModelFullName = row[0].ModelFullName;
                        // 型式(PMの情報)
                        carInfoThreadData.FullModel = row[0].FullModel;
                    }
                }
            }

            // 年式区分(PMの情報)全体初期値設定マスタの「0:西暦　1:和暦（年式）」
            carInfoThreadData.FirstEntryDateKubun = this._estimateInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
            // 備考(PMの情報)
            carInfoThreadData.Note = this._salesSlip.SlipNote;
            // XMLファイル保存用
            carInfoThreadData.Pgid = PGID_XML;

            // SOLTを使う前に、FREE処理を実行します。
            Thread.FreeNamedDataSlot(CARINFOSOLT);
            carInfoSolt = Thread.AllocateNamedDataSlot(CARINFOSOLT);
            Thread.SetData(carInfoSolt, carInfoThreadData);
        }
        // --- ADD 譚洪 2014/09/01 ----------<<<<<
    }
}
