//****************************************************************************//
// システム         : PM-Tablet
// プログラム名称   : 部品詳細情報検索WEBアクセス
// プログラム概要   : 部品詳細情報検索WEBアクセス制御を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370090-00  作成担当 : chenyk
// 作 成 日  2017.11.02   修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using Broadleaf.Runtime.Serialization.Json;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using System.Collections;
using Broadleaf.Web.Common;
using Broadleaf.Web;
using Broadleaf.Library.Collections;
using System.Globalization;
using Broadleaf.Application.Resources;
using System.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 部品詳細情報検索WEBアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部品詳細情報検索WEBアクセス制御を行います。</br>
    /// <br>Programmer : chenyk</br>
    /// <br>Date       : 2017.11.02</br>
    /// </remarks>
    public partial class PartsDetailInfoSearchWebAcs
    {
        #region << Constructor >>
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 部品詳細情報検索WEBアクセスクラスのインスタンス化を行います。</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        /// </remarks>
        public PartsDetailInfoSearchWebAcs()
        {
            // 部品詳細情報検索リモートオブジェクトの取得
            AspLoginInfoAcquisition loginInfoAcq = new AspLoginInfoAcquisition();
            string wkStrApSvr = loginInfoAcq.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
            this.IPrimePartsDtDBObj = GetPmtPartsSearchDB(wkStrApSvr);
        }
        #endregion

        #region << Private Const >>
        /// <summary>PGID</summary>
        private const string Pgid = "PMTAB08042A";
        /// <summary>部品詳細情報有無チェック処理メソッド名称</summary>
        private const string CheckProcName = "部品詳細情報有無チェック処理";
        // <summary>部品詳細情報取得処理メソッド名称</summary>
        private const string GetProcName = "部品詳細情報取得処理";
        /// <summary>初期化エラーメッセージ</summary>
        private const string InitErrorMsg = "{0}にて初期化エラーが発生しました。";
        /// <summary>例外エラーメッセージ</summary>
        private const string ExceptionMsg = "{0}にて例外が発生しました。";

        /// <summary>JSONパラメータ　部品詳細検索パラメータ</summary>
        private const string JSParaPartsDetail = "PartsDetailPara";
        /// <summary>JSONパラメータ　部品メーカーコード</summary>
        private const string JSParaPartsMakerCd = "GoodsMakerCd";
        /// <summary>JSONパラメータ　部品品番</summary>
        private const string JSParaPartsNo = "GoodsNo";
        /// <summary>JSON戻る結果　部品詳細情報有無データ</summary>
        private const string JSParaPartsDetailExistInfo = "PartsDetailExistInfo";
        /// <summary>JSON戻る結果　部品詳細情報</summary>
        private const string JSParaPartsDetailInfo = "PartsDetailInfo";
        /// <summary>ハイフン</summary>
        private const string HyphenStr = "-";
        /// <summary>半角スペース</summary>
        private const string SpaceStr = " ";
        #endregion

        #region << Private Member >>

        /// <summary>部品詳細情報検索リモートオブジェクト</summary>
        private IPrimePartsDtlDB IPrimePartsDtDBObj = null;

        #endregion

        # region << Public Method(WEBハンドラ) >>
        /// <summary>
        /// 部品詳細情報有無チェック処理
        /// </summary>
        /// <param name="parameterValue">検索パラメータ</param>
        /// <param name="resultValue">検索結果</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 部品詳細情報有無チェック処理を行います。</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        /// </remarks>
        public int CheckPartsDetailInfoList(JsonValue parameterValue, out JsonValue resultValue, out string errMsg)
        {
            return this.CheckPartsDetailInfoListProc(parameterValue, out resultValue, out errMsg);
        }

        /// <summary>
        /// 部品詳細情報取得処理
        /// </summary>
        /// <param name="parameterValue">検索パラメータ</param>
        /// <param name="resultValue">検索結果</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 部品詳細情報取得処理を行います。</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        /// </remarks>
        public int GetPartsDetailInfoList(JsonValue parameterValue, out JsonValue resultValue, out string errMsg)
        {
            return this.GetPartsDetailInfoListProc(parameterValue, out resultValue, out errMsg);
        }
        # endregion

        #region << Private Method >>
        /// <summary>
        /// 部品詳細情報検索リモートオブジェクトの取得
        /// </summary>
        /// <param name="wkStrApSvr">APサーバー名</param>
        /// <returns>部品詳細情報検索リモートオブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 部品詳細情報検索リモートオブジェクトの取得を行います。</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        /// </remarks>
        private IPrimePartsDtlDB GetPmtPartsSearchDB(string wkStrApSvr)
        {
            return (IPrimePartsDtlDB)Activator.GetObject(typeof(IPrimePartsDtlDB), string.Format("{0}/MyAppPrimePartsDtl", wkStrApSvr));
        }

        /// <summary>
        /// 部品詳細情報有無チェック処理
        /// </summary>
        /// <param name="parameterValue">検索パラメータ</param>
        /// <param name="resultValue">検索結果</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 部品詳細情報有無チェック処理を行います。</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        /// </remarks>
        private int CheckPartsDetailInfoListProc(JsonValue parameterValue, out JsonValue resultValue, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            resultValue = null;
            errMsg = string.Empty;
            try
            {
                // パラメータ
                JsonObject paramObj = parameterValue as JsonObject;

                if (this.IPrimePartsDtDBObj == null)
                {
                    // プログラムID、メッセージ、ステータス、Exception をセット
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    throw new MobileWebException(Pgid, CheckProcName, string.Format(InitErrorMsg, CheckProcName), -1, null);
                }
                else
                {
                    CustomSerializeArrayList retCSList = null;
                    object primPartsCheckObj = retCSList;

                    //--------------------------------------------------
                    // 部品詳細情報有無チェック条件の生成
                    //--------------------------------------------------
                    CustomSerializeArrayList paraCSList = new CustomSerializeArrayList();
                    JsonArray jsonArray = null;
                    int partsMakerCd = 0;
                    string partsNo = string.Empty;
                    PrmPrtDtParaWork paraWork = null;
                    if (paramObj.HasValueArray(JSParaPartsDetail))
                    {
                        jsonArray = paramObj.GetValueArray(JSParaPartsDetail);
                    }
                    if (jsonArray != null)
                    {
                        foreach (JsonObject jsonObj in jsonArray)
                        {
                            // 部品メーカーコード
                            partsMakerCd = jsonObj.GetValueInt32(JSParaPartsMakerCd, 0);
                            // 部品品番
                            if (jsonObj.HasValueString(JSParaPartsNo))
                            {
                                partsNo = jsonObj.GetValueString(JSParaPartsNo);
                            }
                            paraWork = new PrmPrtDtParaWork();
                            paraWork.PartsMakerCode = partsMakerCd;
                            paraWork.PrimePartsNoWithH = partsNo;
                            paraCSList.Add(paraWork);
                        }
                    }

                    //--------------------------------------------------
                    // 部品詳細情報有無チェック処理リモート呼び出し(CheckExist)
                    //--------------------------------------------------
                    status = this.IPrimePartsDtDBObj.CheckExist(out primPartsCheckObj, paraCSList);

                    // 検索結果から表示内容を生成
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                        primPartsCheckObj != null &&
                        primPartsCheckObj is CustomSerializeArrayList)
                    {
                        JsonObject resultObj = new JsonObject();

                        CustomSerializeArrayList retList = primPartsCheckObj as CustomSerializeArrayList;

                        //--------------------------------------------------
                        // 結果の判断（Listの要素数チェック）
                        //--------------------------------------------------
                        if (retList == null || retList.Count == 0)
                        {
                            // 該当データが無い
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }

                        //--------------------------------------------------
                        // データ移行
                        //--------------------------------------------------
                        List<PrmPrtDtParaWork> partsDetailInfoList = new List<PrmPrtDtParaWork>();
                        // PartsDetailExistInfo
                        foreach (PrmPrtDtParaWork prmPrtDtParaWork in retList)
                        {
                            // PartsDetailExistInfoリストに追加する
                            partsDetailInfoList.Add(prmPrtDtParaWork);
                        }

                        //--------------------------------------------------
                        // JsonObjectへのセット
                        //--------------------------------------------------
                        resultObj.SetValue(JSParaPartsDetailExistInfo, (JsonArray)JsonSerializer.ConvertToJsonValue(partsDetailInfoList.ToArray()));

                        resultValue = resultObj;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (MobileWebException)
            {
                throw;
            }
            catch (Exception ex)
            {
                // プログラムID、メッセージ、ステータス、Exception をセット
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                throw new MobileWebException(Pgid, CheckProcName, string.Format(ExceptionMsg, CheckProcName), -1, ex);
            }
            return status;
        }

        /// <summary>
        /// 部品詳細情報取得処理
        /// </summary>
        /// <param name="parameterValue">検索パラメータ</param>
        /// <param name="resultValue">検索結果</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 部品詳細情報取得処理を行います。</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        /// </remarks>
        private int GetPartsDetailInfoListProc(JsonValue parameterValue, out JsonValue resultValue, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            resultValue = null;
            errMsg = string.Empty;
            try
            {
                // パラメータ
                JsonObject paramObj = parameterValue as JsonObject;

                if (this.IPrimePartsDtDBObj == null)
                {
                    // プログラムID、メッセージ、ステータス、Exception をセット
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    throw new MobileWebException(Pgid, GetProcName, string.Format(InitErrorMsg, GetProcName), -1, null);
                }
                else
                {
                    CustomSerializeArrayList retCSList = null;
                    object prmPrtDtInfobj = retCSList;

                    //--------------------------------------------------
                    // 部品詳細情報取得処理条件の生成
                    //--------------------------------------------------
                    int partsMakerCd = 0;
                    string partsNo = string.Empty;
                    PrmPrtDtParaWork paraWork = new PrmPrtDtParaWork();
                    // 部品メーカーコード
                    partsMakerCd = paramObj.GetValueInt32(JSParaPartsMakerCd, 0);
                    // 部品品番
                    if (paramObj.HasValueString(JSParaPartsNo))
                    {
                        partsNo = paramObj.GetValueString(JSParaPartsNo);
                    }
                    paraWork.PartsMakerCode = partsMakerCd;
                    paraWork.PrimePartsNoWithH = partsNo;

                    //--------------------------------------------------
                    // 部品詳細情報取得処理リモート呼び出し(Read)
                    //--------------------------------------------------
                    status = this.IPrimePartsDtDBObj.Read(out prmPrtDtInfobj, paraWork);

                    // 検索結果から表示内容を生成
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                        prmPrtDtInfobj != null)
                    {
                        JsonObject resultObj = new JsonObject();

                        PrmPrtDtInfWork retWork = prmPrtDtInfobj as PrmPrtDtInfWork;

                        //--------------------------------------------------
                        // JSON-IF用のクラスへセット
                        //--------------------------------------------------
                        JSPartsDetailInfo jsonWork = new JSPartsDetailInfo();
                        // メーカーコード
                        jsonWork.PartsMakerCode = retWork.PartsMakerCode;
                        // メーカー名
                        jsonWork.PartsMakerFullName = retWork.PartsMakerFullName;
                        // 品名
                        jsonWork.PrimePartsName = retWork.PrimePartsName;
                        // 品番
                        jsonWork.PrimePartsNo = retWork.PrimePartsNoWithH;
                        // 商品説明（商品説明（B向け））
                        jsonWork.GoodsDetailDesc = retWork.GoodsDetailDescToB;
                        // 特記
                        jsonWork.PrimePartsSpecialNote = retWork.PrimePartsSpecialNote;
                        // メーカー名ホームページURL
                        jsonWork.PrmPartsMakerUrl = retWork.PrmPartsMakerUrl;
                        // カタログ情報ページURL
                        jsonWork.PrmPartsCatalogUri = retWork.PrmPartsCatalogUri;
                        // 商品情報ページURL
                        jsonWork.PrmPtDescMovieUri = retWork.PrmPtDescMovieUri;
                        // 寸法（長さ）（商品寸法単位付き）
                        jsonWork.GoodsSizeLengthWithUnit = GetSizeWithUnit(retWork.GoodsSizeLength, retWork.GoodsSizeUnit);
                        // 寸法（幅）（商品寸法単位付き）
                        jsonWork.GoodsSizeWidthWithUnit = GetSizeWithUnit(retWork.GoodsSizeWidth, retWork.GoodsSizeUnit);
                        // 寸法（高さ）（商品寸法単位付き）
                        jsonWork.GoodsSizeHeightWithUnit = GetSizeWithUnit(retWork.GoodsSizeHeight, retWork.GoodsSizeUnit);
                        // 箱寸法（長さ）（商品箱寸法単位付き）
                        jsonWork.GoodsPkgBoxLengthWithUnit = GetSizeWithUnit(retWork.GoodsPkgBoxLength, retWork.GoodsPkgBoxUnit);
                        // 箱寸法（幅）（商品箱寸法単位付き）
                        jsonWork.GoodsPkgBoxWidthWithUnit = GetSizeWithUnit(retWork.GoodsPkgBoxWidth, retWork.GoodsPkgBoxUnit);
                        // 箱寸法（高さ）（商品箱寸法単位付き）
                        jsonWork.GoodsPkgBoxHeightWithUnit = GetSizeWithUnit(retWork.GoodsPkgBoxHeight, retWork.GoodsPkgBoxUnit);
                        // 商品容量（商品内容量単位付き）
                        jsonWork.GoodsVolumeWithUnit = GetSizeWithUnit(retWork.GoodsVolume, retWork.GoodsVolumeUnit);
                        // 商品重量（商品重量単位付き）
                        jsonWork.GoodsWeightWithUnit = GetSizeWithUnit(retWork.GoodsWeight, retWork.GoodsWeightUnit);
                        // 商品サムネイル画像有無区分
                        jsonWork.GoodsTmbImgExtDiv = retWork.GoodsTmbImgExtDiv;
                        // 画像1
                        jsonWork.GoodsTmbImgFlName1 = retWork.GoodsTmbImgFlName1;
                        // 画像2
                        jsonWork.GoodsTmbImgFlName2 = retWork.GoodsTmbImgFlName2;
                        // 画像3
                        jsonWork.GoodsTmbImgFlName3 = retWork.GoodsTmbImgFlName3;
                        // 画像4
                        jsonWork.GoodsTmbImgFlName4 = retWork.GoodsTmbImgFlName4;
                        // 画像5
                        jsonWork.GoodsTmbImgFlName5 = retWork.GoodsTmbImgFlName5;
                        // 画像6
                        jsonWork.GoodsTmbImgFlName6 = retWork.GoodsTmbImgFlName6;
                        // 画像7
                        jsonWork.GoodsTmbImgFlName7 = retWork.GoodsTmbImgFlName7;
                        // 画像8
                        jsonWork.GoodsTmbImgFlName8 = retWork.GoodsTmbImgFlName8;
                        // 画像9
                        jsonWork.GoodsTmbImgFlName9 = retWork.GoodsTmbImgFlName9;
                        // 販売終了日（廃番日付）
                        if (retWork.CarPrtsDiscontDate != 0)
                        {
                            DateTime dt = DateTime.ParseExact(retWork.CarPrtsDiscontDate.ToString(), "yyyyMMdd",
                                System.Globalization.CultureInfo.CurrentCulture);
                            jsonWork.CarPrtsDiscontDate = dt.ToString("yyyy/M/d"); // 2017/5/9の型
                        }
                        else
                        {
                            // 販売終了日（廃番日付）ない場合、ハイフン「-」固定とする。
                            jsonWork.CarPrtsDiscontDate = HyphenStr;
                        }

                        //--------------------------------------------------
                        // JsonObjectへのセット
                        //--------------------------------------------------
                        resultObj.SetValue(JSParaPartsDetailInfo, (JsonObject)JsonSerializer.ConvertToJsonValue(jsonWork));

                        resultValue = resultObj;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (MobileWebException)
            {
                throw;
            }
            catch (Exception ex)
            {
                // プログラムID、メッセージ、ステータス、Exception をセット
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                throw new MobileWebException(Pgid, GetProcName, string.Format(ExceptionMsg, GetProcName), -1, ex);
            }
            return status;
        }

        /// <summary>
        /// 寸法（単位付き）の取得
        /// </summary>
        /// <param name="size">寸法（長さ、幅、高さ）</param>
        /// <param name="unit">単位</param>
        /// <returns>寸法（単位付き）</returns>
        /// <remarks>
        /// <br>Note       : 寸法（単位付き）の取得を行います。</br>
        /// <br>Programmer : chenyk</br>
        /// <br>Date       : 2017.11.02</br>
        /// </remarks>
        private string GetSizeWithUnit(double size, string unit)
        {
            // 寸法未設定の場合、ハイフン「-」固定とする。
            string sizeWithUnit = HyphenStr;

            if (size != 0)
            {
                sizeWithUnit = size.ToString("#,##0.00") + SpaceStr + unit;
            }

            return sizeWithUnit;
        }
        #endregion
    }
}