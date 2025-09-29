using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Net;
using System.IO;
using System.Drawing;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// TBOアクセスクラス
    /// </summary>
	public class TBOServiceACS
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
        public TBOServiceACS()
		{ 
           
		}

		private static string tobServerURL = "";

		// GCP用品検索のAPIパス →　原口さんが作ったらここに追加していく
		/// <summary>カテゴリ検索API</summary>
		private readonly string GET_GoodsCategory = "/CarGoodsExchange-web/api/general/goodscategory";

        /// <summary>付随整備設定取得</summary>
        private readonly string GET_Attendrepairs = "/CarGoodsExchange-web/api/wholesale/attendrepairs";

        /// <summary>付随整備設定取得(SFモード)</summary>
        private readonly string GET_Attendrepairs_ModeSF = "/CarGoodsExchange-web/api/store/attendrepairs";

        /// <summary>商品画像取得・登録・削除</summary>
        private readonly string COMMON_GoodsImage = "/CarGoodsExchange-web/api/goodsimage";

        /// <summary>提案商品一括登録</summary>
        private readonly string POST_Goods = "/CarGoodsExchange-web/api/wholesale/proposegoods/bulk";

        /// <summary>提案商品公開（部品商モード）</summary>
        private readonly string POST_Release = "/CarGoodsExchange-web/api/wholesale/proposegoods/release";

        /// <summary>提案商品公開（整備工場モード）</summary>
        private readonly string POST_ReleaseAdopt = "/CarGoodsExchange-web/api/wholesale/proposegoods/releaseAdopt";

        /// <summary>付随整備設定一括更新</summary>
        private readonly string POST_Attendrepairs = "/CarGoodsExchange-web/api/wholesale/attendrepairs/bulk";

        /// <summary>提案商品取得(GET)</summary>
        private readonly string GET_Goods = "/CarGoodsExchange-web/api/wholesale/proposegoods";


        /// <summary>商品公開情報 取得、削除</summary>
        private readonly string COMMON_DestSettings = "/CarGoodsExchange-web/api/wholesale/destsettings";

        /// <summary>商品公開情報一括 削除</summary>
        private readonly string DELET_BULK_DestSettings = "/CarGoodsExchange-web/api/wholesale/destsettings/bulk";

        /// <summary>動作設定 登録・更新・削除 </summary>
        private readonly string COMMON_BULK_Settings = "/CarGoodsExchange-web/api/settings/bulk";

        /// <summary>動作設定 取得</summary>
        private readonly string GET_Settings = "/CarGoodsExchange-web/api/settings/list";

        private void DebugURL(ref string tobServerURL , string para)
        {
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "TBO.txt")))
            {
                using (StreamReader reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "TBO.txt")))
                {
                    tobServerURL = reader.ReadLine() + para;
                }
            }
        }

        private readonly int _timeOut = 1800000; // 30分とする

        #region TBOアクセスメソッド

        // タイムアウトはデフォルトの100秒とする

        #region POST

        #region 提案商品保存処理
        /// <summary>
        /// 提案商品保存処理
        /// </summary>
        /// <returns></returns>
        public int SavePropose_Goods(ref ProposeGoods[] para, out string errMsg)
        {
            errMsg = string.Empty;
            string resultJsonString = "";

            int st = 0;

            // 分割する数 一番パフォーマンスが良かった300件とする
            //int div_count = 100; // 100件ずつ     3:54
            //int div_count = 300;　 // 300件ずつ   3:37
            //int div_count = 500;　 // 500件ずつ   4:03
            int div_count = 1000;　 // 1000件ずつ   4:03

            // 保存データ件数よりループ回数を算定
            int roopCount = (para.Length / div_count);

            // あまりが発生する場合はループ回数を1回追加
            if ((para.Length % div_count) != 0)
            {
                roopCount += 1;
            }

            // 保存時にＸＸ件以降の保存に失敗というメッセージを出す為のインデックス
            int saveIndex = 0;

            // 保存データ（全てから）分割して取り出す要素数
            int copyLength = 0;

             List<ProposeGoods> retList = new List<ProposeGoods>(); 

            try
            {
                // URL取得
                tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + POST_Goods;
#if DEBUG
                DebugURL(ref tobServerURL, POST_Goods);
#endif

                #region 分割
                for (int i = 0; i < roopCount; i++)
                {
                    saveIndex = i;
                    copyLength = div_count;
                    if (i == roopCount - 1)
                    {
                        copyLength = para.Length - (i * div_count);
                    }

                    long sourceIndex = i * div_count;
                    ProposeGoods[] wkProposeGoods = new ProposeGoods[copyLength];
                    Array.Copy(para, sourceIndex, wkProposeGoods, 0, copyLength);

                    // 送信情報の設定
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
                    webRequest.Method = "POST";
                    webRequest.ContentType = "application/json";
                    // TOBのリクエストKEY(要暗号化)
                    webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                    // プロキシ経由の場合必要
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = this._timeOut;

                    //POSTデータ作成
                    string jsonPara = FM.WebSync.Core.JSON.Serialize<ProposeGoods[]>(wkProposeGoods);
                    byte[] reqByte = Encoding.UTF8.GetBytes(jsonPara);

                    webRequest.ContentLength = reqByte.Length;

                    // 実リクエスト開始
                    using (Stream reqStream = webRequest.GetRequestStream())
                    {
                        reqStream.Write(reqByte, 0, reqByte.Length);
                    }

                    using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                    using (Stream resStream = webResponse.GetResponseStream())
                    using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                    {
                        // 結果取得
                        resultJsonString = sr.ReadToEnd();

                        //結果をデシリアライズ
                        ProposeGoods_MAIN main = FM.WebSync.Core.JSON.Deserialize<ProposeGoods_MAIN>(resultJsonString);
                        retList.AddRange(main.goods);
                        st = 0;
                    }

                }
                #endregion

                #region DEL 元
                //// 送信情報の設定
                //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
                //webRequest.Method = "POST";
                //webRequest.ContentType = "application/json";
                //// TOBのリクエストKEY(要暗号化)
                //webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                //// プロキシ経由の場合必要
                //webRequest.ServicePoint.Expect100Continue = false;
                //webRequest.Timeout = this._timeOut;

                ////POSTデータ作成
                //string jsonPara = FM.WebSync.Core.JSON.Serialize<ProposeGoods[]>(para);
                //byte[] reqByte = Encoding.UTF8.GetBytes(jsonPara);

                //webRequest.ContentLength = reqByte.Length;

                //// 実リクエスト開始
                //using (Stream reqStream = webRequest.GetRequestStream())
                //{
                //    reqStream.Write(reqByte, 0, reqByte.Length);
                //}

                //using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                //using (Stream resStream = webResponse.GetResponseStream())
                //using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                //{
                //    // 結果取得
                //    resultJsonString = sr.ReadToEnd();

                //    //結果をデシリアライズ
                //    ProposeGoods_MAIN main = FM.WebSync.Core.JSON.Deserialize<ProposeGoods_MAIN>(resultJsonString);
                //    para = main.goods;
                //    st = 0;
                //}
                #endregion

            }
            #region 元
            //// タイムアウト
            //catch (WebException ex)
            //{
            //    errMsg = "商品情報の保存に失敗しました。";
            //    // 例外処理
            //    this.ErrProc(ex, ref errMsg, out st);
            //}
            //catch (Exception ex)
            //{
            //    errMsg = "商品情報の保存処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString(); ;
            //    st = -1;
            //}
            #endregion
            #region 分割
            catch (WebException ex)
            {
                errMsg = "商品情報の保存に失敗しました。";
                if (retList.Count != 0)
                {
                    errMsg = "商品情報の保存処理で例外が発生しました。" + Environment.NewLine + ((saveIndex * div_count) + 1).ToString() + "件目以降の商品の更新に失敗しました。。" + Environment.NewLine + ex.StackTrace.ToString();
                }
                // 例外処理
                this.ErrProc(ex, ref errMsg, out st);
            }
            catch (Exception ex)
            {
                errMsg = "商品情報の保存処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString();
                if (retList.Count != 0)
                {
                    errMsg = "商品情報の保存処理で例外が発生しました。" + Environment.NewLine + ((saveIndex * div_count) + 1).ToString() + "件目以降の商品の更新に失敗しました。。" + Environment.NewLine + ex.StackTrace.ToString();
                }
                st = -1;
            }
            #endregion
            finally
            {
                para = retList.ToArray();
            }

            return st;
        }
        #endregion

        #region 新着情報保存処理

        #region 部品商
        /// <summary>
        /// 新着情報保存処理
        /// </summary>
        /// <returns></returns>
        public int SaveNews(News news, out string errMsg)
        {
            errMsg = string.Empty;

            int st = 0;

            try
            {
                // URL取得
                tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + POST_Release;
#if DEBUG
                DebugURL(ref tobServerURL, POST_Release);
#endif

                // 送信情報の設定
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";

                // TOBのリクエストKEY(要暗号化)
                webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                // プロキシ経由の場合必要
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.Timeout = this._timeOut;

                //POSTデータ作成
                string jsonPara = FM.WebSync.Core.JSON.Serialize<News>(news);
                byte[] reqByte = Encoding.UTF8.GetBytes(jsonPara);
                webRequest.ContentLength = reqByte.Length;

                // 実リクエスト開始
                using (Stream reqStream = webRequest.GetRequestStream())
                {
                    reqStream.Write(reqByte, 0, reqByte.Length);
                }

                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // 結果は無しよ
                    st = 0;
                }

            }
            // タイムアウト
            catch (WebException ex)
            {
                errMsg = "通知情報の保存に失敗しました。";
                // 例外処理
                this.ErrProc(ex, ref errMsg, out st);
            }
            catch (Exception ex)
            {
                errMsg = "通知情報の保存処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString(); ;
                st = -1;
            }
            return st;
        }
        #endregion

        #region 整備工場
        /// <summary>
        /// 新着情報保存処理
        /// </summary>
        /// <returns></returns>
        public int SaveNewsAdopt(News news, out string errMsg)
        {
            errMsg = string.Empty;

            int st = 0;

            try
            {
                // URL取得
                tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + POST_ReleaseAdopt;
#if DEBUG
                DebugURL(ref tobServerURL, POST_ReleaseAdopt);
#endif
                // 送信情報の設定
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                webRequest.Timeout = this._timeOut;

                // TOBのリクエストKEY(要暗号化)
                webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                // プロキシ経由の場合必要
                webRequest.ServicePoint.Expect100Continue = false;

                //POSTデータ作成
                string jsonPara = FM.WebSync.Core.JSON.Serialize<News>(news);
                byte[] reqByte = Encoding.UTF8.GetBytes(jsonPara);
                webRequest.ContentLength = reqByte.Length;

                // 実リクエスト開始
                using (Stream reqStream = webRequest.GetRequestStream())
                {
                    reqStream.Write(reqByte, 0, reqByte.Length);
                }

                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // 結果は無しよ
                    st = 0;

                 
                }

            }
            // タイムアウト
            catch (WebException ex)
            {
                errMsg = "通知情報の保存に失敗しました。";
                // 例外処理
                this.ErrProc(ex, ref errMsg, out st);
            }
            catch (Exception ex)
            {
                errMsg = "通知情報の保存処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString(); ;
                st = -1;
            }
            return st;
        }
        #endregion


        #endregion

        #region 付随整備設定
        /// <summary>
        /// 付随整備設定 保存処理
        /// </summary>
        /// <returns></returns>
        public int SaveAttendRepairSet(ref AttendRepairSet[] para, out string errMsg)
        {
            errMsg = string.Empty;
            string resultJsonString = "";

            int st = 0;

            try
            {
                // URL取得
                tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + POST_Attendrepairs;
#if DEBUG
                DebugURL(ref tobServerURL, POST_Attendrepairs);
#endif


                // 送信情報の設定
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";

                // TOBのリクエストKEY(要暗号化)
                webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                // プロキシ経由の場合必要
                webRequest.ServicePoint.Expect100Continue = false;

                //POSTデータ作成
                string jsonPara = FM.WebSync.Core.JSON.Serialize<AttendRepairSet[]>(para);

                byte[] reqByte = Encoding.UTF8.GetBytes(jsonPara);
                webRequest.ContentLength = reqByte.Length;

                // 実リクエスト開始
                using (Stream reqStream = webRequest.GetRequestStream())
                {
                    reqStream.Write(reqByte, 0, reqByte.Length);
                }

                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // 結果取得
                    resultJsonString = sr.ReadToEnd();

                    if (resultJsonString != "")
                    {
                        //結果をデシリアライズ(削除したら結果が０件になる)
                        AttendRepairSetMain main = FM.WebSync.Core.JSON.Deserialize<AttendRepairSetMain>(resultJsonString);
                        para = main.attendrepairs;
                    }
                    else
                    {
                        para = new AttendRepairSet[0];
                    }
                    st = 0;
                }

            }
            catch (WebException ex)
            {
                errMsg = "付随整備情報の保存に失敗しました。";
                // 例外処理
                this.ErrProc(ex, ref errMsg, out st);
            }
            catch (Exception ex)
            {
                errMsg = "付随整備情報の保存処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString();
                st = -1;
            }
            return st;
        }
        #endregion

        #region POST時例外処理
        /// <summary>
        /// 例外処理
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="st"></param>
        /// <param name="errMsg"></param>
        private void ErrProc(WebException ex, ref string errMsg, out int st)
        {
            st = -1;
            try
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;

                    using (Stream resStream = ex.Response.GetResponseStream())
                    using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                    {
                        // 結果取得
                        string errInfo = sr.ReadToEnd();
                        if (errInfo.Contains("E0003"))
                        {
                            // 排他エラー
                            errMsg += Environment.NewLine + "既に他端末にて更新されています。";
                            st = 800;
                        }
                        else
                        {
                            errMsg += Environment.NewLine + ex.StackTrace.ToString();
                        }
                    }
                }
            }
            catch
            {

            }
        }
        #endregion

        #endregion

        #region GET

        #region 付随整備設定

        #region 部品商
        /// <summary>
        /// 付随整備設定
        /// </summary>
        /// <returns></returns>
        public int GetAttendRepairSet(string enterpriseCode, out List<AttendRepairSet> attendRepairSetList, out string errMsg)
        {
            int st = 0;
            attendRepairSetList = new List<AttendRepairSet>();

            AttendRepairSetMain retJson;
            errMsg = string.Empty;

            // 接続するAPIによって、ここの値を変更
            tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + GET_Attendrepairs;

#if DEBUG
            DebugURL(ref tobServerURL, GET_Attendrepairs);
#endif

            // 検索条件を付与
            string key = String.Format("?{0}={1}", "EnterpriseCode", enterpriseCode);
            tobServerURL += key;

            string resultJsonString = "";


            // 送信情報の設定
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
            webRequest.Method = "GET";

            // TOBのリクエストKEY(要暗号化)
            webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
            try
            {
                // レスポンスの取得
                using (WebResponse webResponse = webRequest.GetResponse())
                using (Stream responseStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(responseStream, Encoding.UTF8))
                {
                        // 結果取得
                        resultJsonString = sr.ReadToEnd();
                        //結果をデシリアライズ
                        retJson = FM.WebSync.Core.JSON.Deserialize<AttendRepairSetMain>(resultJsonString);
                        attendRepairSetList.AddRange(retJson.attendrepairs);
                        // 表示順でソート
                        attendRepairSetList.Sort(delegate(AttendRepairSet obj1, AttendRepairSet obj2)
                        {
                            return obj1.sortNo.CompareTo(obj2.sortNo);
                        });
                }
            }
            // タイムアウト
            catch (WebException ex)
            {
                errMsg = "付随整備情報の取得に失敗しました。";
                st = -1;
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;
                }
            }
            catch (Exception ex)
            {
                errMsg = "付随整備情報取得処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString();
                st = -1;
            }
            return st;
        }
        #endregion

        #region 整備工場モード(拠点概念あり)
        /// <summary>
        /// 付随整備設定
        /// </summary>
        /// <returns></returns>
        public int GetAttendRepairSetSF(string enterpriseCode, string sectionCode, long goodsCategoryId, out List<AttendRepairSet> attendRepairSetList, out string errMsg)
        {
            int st = 0;
            attendRepairSetList = new List<AttendRepairSet>();

            AttendRepairSetMain retJson;
            errMsg = string.Empty;

            // 接続するAPIによって、ここの値を変更
            tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + GET_Attendrepairs_ModeSF;

#if DEBUG
            DebugURL(ref tobServerURL, GET_Attendrepairs);
#endif

            // 検索条件を付与
            string key = String.Format("?{0}={1}&{2}={3}&{4}={5}", "EnterpriseCode", enterpriseCode, "SectionCode", sectionCode, "GoodsCategoryId", goodsCategoryId);
            tobServerURL += key;

            string resultJsonString = "";


            // 送信情報の設定
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
            webRequest.Method = "GET";

            // TOBのリクエストKEY(要暗号化)
            webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
            try
            {
                // レスポンスの取得
                using (WebResponse webResponse = webRequest.GetResponse())
                using (Stream responseStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(responseStream, Encoding.UTF8))
                {
                    // 結果取得
                    resultJsonString = sr.ReadToEnd();
                    //結果をデシリアライズ
                    retJson = FM.WebSync.Core.JSON.Deserialize<AttendRepairSetMain>(resultJsonString);

                    // 無効データを除外
                    for (int i = 0; i < retJson.attendrepairs.Length; i++)
                    {
                        if (retJson.attendrepairs[i].displayFlag)
                        {
                            attendRepairSetList.Add(retJson.attendrepairs[i]);
                        }
                    }

                    // 表示順でソート
                    attendRepairSetList.Sort(delegate(AttendRepairSet obj1, AttendRepairSet obj2)
                    {
                        return obj1.sortNo.CompareTo(obj2.sortNo);
                    });
                }
            }
            // タイムアウト
            catch (WebException ex)
            {
                errMsg = "付随整備情報の取得に失敗しました。";
                st = -1;
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;
                }
            }
            catch (Exception ex)
            {
                errMsg = "付随整備情報取得処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString();
                st = -1;
            }
            return st;
        }
        #endregion


        #endregion

        #region 商品カテゴリ
        /// <summary>
        /// 商品カテゴリ取得処理
        /// </summary>
        /// <returns></returns>
        public int GetGoodsCategory(out List<GoodsCategory> categoryList, out string errMsg)
        {
            int st = 0;
            categoryList = new List<GoodsCategory>();
            errMsg = string.Empty;

            // 接続するAPIによって、ここの値を変更
            // APIによっては、クエリ文字列を設定する（POSTの場合は、自分でJSON作るべし）

            tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + GET_GoodsCategory;
#if DEBUG
            DebugURL(ref tobServerURL, GET_GoodsCategory);
#endif
            //System.Windows.Forms.MessageBox.Show("tobServerURL = " + tobServerURL);


            // 送信情報の設定
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
            webRequest.Method = "GET";

            // TOBのリクエストKEY(要暗号化)
            webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");

            string resultJsonString = "";

            try
            {
                // レスポンスの取得
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // 結果取得
                    resultJsonString = sr.ReadToEnd();

                    //結果をデシリアライズ
                    GoodsCategory_MAIN main = FM.WebSync.Core.JSON.Deserialize<GoodsCategory_MAIN>(resultJsonString);
                    categoryList.AddRange(main.GoodsCategory);

                    categoryList.Sort(delegate(GoodsCategory obj1, GoodsCategory obj2)
                    {
                        // カテゴリID順
                        return obj1.GoodsCategoryId.CompareTo(obj2.GoodsCategoryId);
                    });
                }
            }
            // タイムアウト
            catch (WebException ex)
            {
                errMsg = "商品カテゴリの取得に失敗しました。";
                st = -1;
                 // HTTPプロトコルエラーかどうか調べる
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;
                }
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "商品カテゴリ取得処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }
        #endregion

        #region 提案商品情報

        /// <summary>
        /// 提案商品情報取得処理
        /// </summary>
        /// <returns></returns>
        public int GetProposegoods(string enterpriseCode, string sectioncode, long categoryId, out List<ProposeGoods> proposeGoodsList, out string errMsg)
        {
            int st = 0;
            proposeGoodsList = new List<ProposeGoods>();
            errMsg = string.Empty;

            // 接続するAPIによって、ここの値を変更
            // APIによっては、クエリ文字列を設定する（POSTの場合は、自分でJSON作るべし）
            tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + GET_Goods;
#if DEBUG
            DebugURL(ref tobServerURL, GET_Goods);
#endif


            // 検索条件を付与
            string key = String.Format("?{0}={1}&{2}={3}&{4}={5}", "EnterpriseCode",enterpriseCode,"SectionCode",sectioncode, "GoodsCategoryId",categoryId);
            tobServerURL += key;

            // 検索条件
            // 企業コード、拠点コード、カテゴリ
            // 戻ってくるのは 提案商品情報、付随作業、個別設定

            // 送信情報の設定
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
            webRequest.Method = "GET";

            // TOBのリクエストKEY(要暗号化)
            webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");

            string resultJsonString = "";
            ProposeGoods_MAIN retJson = new ProposeGoods_MAIN();

            try
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // 結果取得
                    resultJsonString = sr.ReadToEnd();

                    //結果をデシリアライズ
                    retJson = FM.WebSync.Core.JSON.Deserialize<ProposeGoods_MAIN>(resultJsonString);

                    proposeGoodsList.AddRange(retJson.goods);
                    proposeGoodsList.Sort(delegate(ProposeGoods obj1, ProposeGoods obj2)
                   {
                       // ソート順
                       return obj1.sortNo.CompareTo(obj2.sortNo);
                   });

                    st = 0;
                } 

                // 画像取得
                Dictionary<long, Image> imageCash = new Dictionary<long, Image>();
                foreach (ProposeGoods goods in proposeGoodsList)
	            {
            		 if(goods.imageId != 0)
                     {
                         if (imageCash.ContainsKey(goods.imageId))
                         {
                             goods.image_Data = imageCash[goods.imageId];
                         }
                         else
                         {
                             GoodsImage image = new GoodsImage();
                             st = this.GetGoodsImage(goods.enterpriseCode, goods.imageId, out image, out errMsg);
                             if (st == 0)
                             {
                                 goods.image_Data = image.imageData_Image;
                                 imageCash.Add(goods.imageId, image.imageData_Image);
                             }
                             else
                             {
                                 goods.image_Data = null;
                             }
                         }
                     }
	            }
            }
            // タイムアウト
            catch (WebException ex)
            {
                errMsg = "提案商品の取得に失敗しました。";
                st = -1;
                // HTTPプロトコルエラーかどうか調べる
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;
                }
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "提案商品取得処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }

        #endregion

        #endregion

        #region 商品公開情報

        #region Get

        /// <summary>
        /// 商品公開情報取得処理
        /// </summary>
        /// <returns></returns>
        public int GetDestSetting(string enterpriseCode, string sectioncode, long categoryId, out List<DestSetting> destSettingList, out string errMsg)
        {
            int st = 0;
            destSettingList = new List<DestSetting>();
            errMsg = string.Empty;

            // 接続URL
            tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + COMMON_DestSettings;
#if DEBUG
            DebugURL(ref tobServerURL, COMMON_DestSettings);
#endif


            // 検索条件を付与
            string key = String.Format("?{0}={1}&{2}={3}&{4}={5}", "EnterpriseCode", enterpriseCode, "SectionCode", sectioncode, "GoodsCategoryId", categoryId);
            tobServerURL += key;

            // 送信情報の設定
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
            webRequest.Method = "GET";

            // TOBのリクエストKEY(要暗号化)
            webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");

            string resultJsonString = "";

            try
            {
                // レスポンスの取得
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // 結果取得
                    resultJsonString = sr.ReadToEnd();
                    //結果をデシリアライズ
                    DestSetting_MAIN main = FM.WebSync.Core.JSON.Deserialize<DestSetting_MAIN>(resultJsonString);
                    destSettingList.AddRange(main.destSettings);
                }
            }
            // タイムアウト
            catch (WebException ex)
            {
                errMsg = "商品公開情報の取得に失敗しました。";
                st = -1;
                 // HTTPプロトコルエラーかどうか調べる
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;
                }
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "商品開情報取得処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }

        #endregion

        #region Delete

        /// <summary>
        /// 商品公開停止処理
        /// </summary>
        /// <returns></returns>
        public int DeleteDestSetting(DestSetting para, out string errMsg)
        {
            errMsg = string.Empty;
            string resultJsonString = "";

            int st = 0;

            try
            {
                // URL取得
                tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + COMMON_DestSettings;
#if DEBUG
                DebugURL(ref tobServerURL, COMMON_DestSettings);
#endif


                // 検索条件を付与
                string key = String.Format("?{0}={1}&{2}={3}&{4}={5}&{6}={7}", "EnterpriseCode", para.enterpriseCode, "SectionCode", para.sectionCode, "GoodsCategoryId", para.goodsCategoryId, "ProposeDestId", para.proposeDestId);
                tobServerURL += key;

                // 送信情報の設定
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
                webRequest.Method = "DELETE";
                webRequest.ContentType = "application/json";

                // TOBのリクエストKEY(要暗号化)
                webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                // プロキシ経由の場合必要
                webRequest.ServicePoint.Expect100Continue = false;

                using (WebResponse webResponse = webRequest.GetResponse())
                using (Stream responseStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(responseStream, Encoding.UTF8))
                {
                    // 結果取得 ⇒　削除なんで結果なしよ
                    resultJsonString = sr.ReadToEnd();
                    st = 0;
                }
            }
            catch (WebException ex)
            {
                errMsg = "商品の公開停止に失敗しました。";
                // 例外処理
                this.ErrProc(ex, ref errMsg, out st);
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "商品公開停止処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }

        /// <summary>
        /// 商品公開停止処理
        /// </summary>
        /// <returns></returns>
        public int DeleteDestSetting_bulk(List<DestSetting> delList, out string errMsg)
        {
            errMsg = string.Empty;
            string resultJsonString = "";

            int st = 0;

            try
            {
                // URL取得
                tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + DELET_BULK_DestSettings;
#if DEBUG
                DebugURL(ref tobServerURL, DELET_BULK_DestSettings);
#endif


                // 送信情報の設定
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";

                // TOBのリクエストKEY(要暗号化)
                webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                // プロキシ経由の場合必要
                webRequest.ServicePoint.Expect100Continue = false;



                //POSTデータ作成
                string jsonPara = FM.WebSync.Core.JSON.Serialize<DestSetting[]>(delList.ToArray());
                byte[] reqByte = Encoding.UTF8.GetBytes(jsonPara);

                webRequest.ContentLength = reqByte.Length;

                // 実リクエスト開始
                using (Stream reqStream = webRequest.GetRequestStream())
                {
                    reqStream.Write(reqByte, 0, reqByte.Length);
                }

                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // 結果取得
                    resultJsonString = sr.ReadToEnd();
                    // 削除なんで結果はなしよ
                    st = 0;
                }
            }
            catch (WebException ex)
            {
                errMsg = "商品の公開停止に失敗しました。";
                // 例外処理
                this.ErrProc(ex, ref errMsg, out st);
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "商品公開停止処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }

        #endregion

        #endregion

        #region 商品画像

        #region 画像ＩＤリスト取得
        /// <summary>
        /// 画像ＩＤリスト取得
        /// </summary>
        /// <returns></returns>
        public int GetGoodsImageIdList(string enterpriseCode, out List<GoodsImage> goodsImageList, out string errMsg)
        {
            // 画像のIDを一覧で取得後、１件ずづ画像を取得する
            // TODO ローカルキャッシュ
            // 画像ID毎にTempフォルダにキャッシュを作成して、キャッシュがあればそこから取るような仕組みを考える

            int st = 0;
            goodsImageList = new List<GoodsImage>();
            GoodsImage[] retJson = null;
            errMsg = string.Empty;

            // 接続するAPIによって、ここの値を変更
            // APIによっては、クエリ文字列を設定する（POSTの場合は、自分でJSON作るべし）
            tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + COMMON_GoodsImage;
#if DEBUG
            DebugURL(ref tobServerURL, COMMON_GoodsImage);
#endif


            // 検索条件を付与
            string key = String.Format("?{0}={1}", "EnterpriseCode", enterpriseCode);
            tobServerURL += key;

            string resultJsonString = "";

            // 送信情報の設定
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
            webRequest.Method = "GET";

            // TOBのリクエストKEY(要暗号化)
            webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
            try
            {
                // レスポンスの取得
                using (WebResponse webResponse = webRequest.GetResponse())
                using (Stream responseStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(responseStream, Encoding.UTF8))
                {
                    // 負荷軽減の為に初めに画像ＩＤリストを取得
                    // 結果取得
                    resultJsonString = sr.ReadToEnd();
                    //結果をデシリアライズ
                    retJson = FM.WebSync.Core.JSON.Deserialize<GoodsImage[]>(resultJsonString);
                    if (retJson != null)
                    {
                        goodsImageList.AddRange(retJson);
                    }
                }
            }
            // タイムアウト
            catch (WebException ex)
            {
                errMsg = "商品画像の取得に失敗しました。";
                st = -1;
                // HTTPプロトコルエラーかどうか調べる
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;
                }
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "商品画像取得処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }
        #endregion

        #region 商品画像取得
        /// <summary>
        /// 商品画像取得
        /// </summary>
        /// <returns></returns>
        public int GetGoodsImage(string enterpriseCode, long imageId,  out GoodsImage goodsImage, out string errMsg)
        {
            // 画像のIDを一覧で取得後、１件ずづ画像を取得する
            // TODO ローカルキャッシュ
            // 画像ID毎にTempフォルダにキャッシュを作成して、キャッシュがあればそこから取るような仕組みを考える

            int st = 0;
            goodsImage = new GoodsImage();
            errMsg = string.Empty;

            // 接続するAPIによって、ここの値を変更
            // APIによっては、クエリ文字列を設定する（POSTの場合は、自分でJSON作るべし）
            tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + COMMON_GoodsImage + "/json/";
#if DEBUG
            DebugURL(ref tobServerURL, COMMON_GoodsImage + "/json/");
#endif


            // 検索条件を付与
            string key = String.Format("{0}?{1}={2}", imageId.ToString(), "EnterpriseCode", enterpriseCode);
            tobServerURL += key;

            string resultJsonString = "";

            // 送信情報の設定
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
            webRequest.Method = "GET";

            // TOBのリクエストKEY(要暗号化)
            webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
            try
            {
                // レスポンスの取得
                using (WebResponse webResponse = webRequest.GetResponse())
                using (Stream responseStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(responseStream, Encoding.UTF8))
                {
                    // 負荷軽減の為に初めに画像ＩＤリストを取得
                    // 結果取得
                    resultJsonString = sr.ReadToEnd();
                    //結果をデシリアライズ
                    goodsImage = FM.WebSync.Core.JSON.Deserialize<GoodsImage>(resultJsonString);
                    if (goodsImage != null)
                    {
                        // 画像復元
                        goodsImage.imageData_Image = Base64ToImage(goodsImage.imageData);
                        if (goodsImage.imageKeyword == null) goodsImage.imageKeyword = "";
                        if (goodsImage.imageData_Image == null)
                        {
                            st = -1;
                            errMsg = "画像の復元に失敗しました。";
                        }
                    }
                }
            }
            // タイムアウト
            catch (WebException ex)
            {
                errMsg = "商品画像の取得に失敗しました。";
                st = -1;
                // HTTPプロトコルエラーかどうか調べる
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;
                    if (st == 400)
                    {
                        // 画像が消えている場合
                        goodsImage.imageData_Image = null;
                        st = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "商品画像取得処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }
        #endregion

        #region 画像登録
        /// <summary>
        /// 提案商品保存処理
        /// </summary>
        /// <returns></returns>
        public int SaveGoodsImage(int mode, ref GoodsImage para, out string errMsg)
        {
            errMsg = string.Empty;
            string resultJsonString = "";

            int st = 0;

            try
            {
                // URL取得
                tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + COMMON_GoodsImage;
#if DEBUG
                DebugURL(ref tobServerURL, COMMON_GoodsImage);
#endif

                if (mode == 3)
                {
                    // 検索条件を付与
                    string key = "/" + String.Format("{0}?{1}={2}", para.imageId.ToString(), "EnterpriseCode", para.enterpriseCode);
                    tobServerURL += key;
                }

                // 送信情報の設定
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);

                switch (mode)
                {
                    case 1:   // 新規登録
                        webRequest.Method = "POST";
                        break;
                    case 2:   // 更新
                        webRequest.Method = "PUT";
                        break;
                    case 3:　 // 削除
                        webRequest.Method = "DELETE";
                        break;
                    default:
                        webRequest.Method = "POST";
                        break;
                }
                
                webRequest.ContentType = "application/json";

                // TOBのリクエストKEY(要暗号化)
                webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                // プロキシ経由の場合必要
                webRequest.ServicePoint.Expect100Continue = false;


                GoodsImage damy = new GoodsImage();

                if (mode != 3)
                {
                    // Image→Base64
                    para.imageData = ImageToBase64(para.imageData_Image);
                    if (string.IsNullOrEmpty(para.imageData))
                    {
                        errMsg = "画像の圧縮に失敗しました。";
                        st = -1;
                        return st;
                    }

                    // 画像はFM部品に対応してないので
                    damy = para.Clone();
                    damy.imageData_Image = null;

                    //POSTデータ作成
                    string jsonPara = FM.WebSync.Core.JSON.Serialize<GoodsImage>(damy);
                    byte[] reqByte = Encoding.UTF8.GetBytes(jsonPara);
                    webRequest.ContentLength = reqByte.Length;

                    // 実リクエスト開始
                    using (Stream reqStream = webRequest.GetRequestStream())
                    {
                        reqStream.Write(reqByte, 0, reqByte.Length);
                    }

                }
                using (WebResponse webResponse = webRequest.GetResponse())
                using (Stream responseStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(responseStream, Encoding.UTF8))
                {
                    // 結果取得
                    resultJsonString = sr.ReadToEnd();
                    // 削除以外
                    if (mode != 3)
                    {
                        //結果をデシリアライズ
                        GoodsImage_MAIN main = FM.WebSync.Core.JSON.Deserialize<GoodsImage_MAIN>(resultJsonString);
                        if (main != null && main.image != null)
                        {
                            damy = main.image;
                            damy.imageData_Image = para.imageData_Image;
                            para = damy;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    st = 0;
                }
            }
            // タイムアウト
            catch (WebException ex)
            {
                errMsg = "商品画像の登録に失敗しました。";
                // 例外処理
                this.ErrProc(ex, ref errMsg, out st);
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "商品画像登録処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }

        #endregion

        #endregion

        #region 動作設定

        #region POST
        /// <summary>
        /// 動作設定(登録・更新・削除)
        /// </summary>
        /// <returns></returns>
        public int SaveSettings(ref List<Settings> settingsList, out string errMsg)
        {
            errMsg = string.Empty;
            string resultJsonString = "";

            int st = 0;

            try
            {
                // URL取得
                tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + COMMON_BULK_Settings;
#if DEBUG
                DebugURL(ref tobServerURL, COMMON_BULK_Settings);
#endif
                 // 送信情報の設定
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";

                // TOBのリクエストKEY(要暗号化)
                webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
                // プロキシ経由の場合必要
                webRequest.ServicePoint.Expect100Continue = false;

                //POSTデータ作成
                string jsonPara = FM.WebSync.Core.JSON.Serialize<Settings[]>(settingsList.ToArray());
                byte[] reqByte = Encoding.UTF8.GetBytes(jsonPara);
                webRequest.ContentLength = reqByte.Length;

                // 実リクエスト開始
                using (Stream reqStream = webRequest.GetRequestStream())
                {
                    reqStream.Write(reqByte, 0, reqByte.Length);
                }

                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // 結果取得
                    resultJsonString = sr.ReadToEnd();
                    st = 0;

                    //結果をデシリアライズ
                    Settings_MAIN main = FM.WebSync.Core.JSON.Deserialize<Settings_MAIN>(resultJsonString);
                    if (main != null && main.settings != null)
                    {
                        settingsList.Clear();
                        settingsList.AddRange(main.settings);
                    }
                    else
                    {
                        errMsg = "動作設定の登録に失敗しました。";
                        st = -1;
                    }
                }
            }
            catch (WebException ex)
            {
                errMsg = "動作設定の登録に失敗しました。";
                // 例外処理
                this.ErrProc(ex, ref errMsg, out st);
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "動作設定登録処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }
        #endregion

        #region Get
        /// <summary>
        /// 動作設定情報取得処理
        /// </summary>
        /// <returns></returns>
        public int GetSettings(string enterpriseCode, out List<Settings> settingsList, out string errMsg)
        {
            int st = 0;
            settingsList = new List<Settings>();
            errMsg = string.Empty;

            // 接続するAPIによって、ここの値を変更
            // APIによっては、クエリ文字列を設定する（POSTの場合は、自分でJSON作るべし）
            tobServerURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_IllustSelectWeb) + GET_Settings;
#if DEBUG
            DebugURL(ref tobServerURL, GET_Settings);
#endif

            // 検索条件を付与
            string key = String.Format("?{0}={1}", "EnterpriseCode",enterpriseCode);
            tobServerURL += key;
       
            // 送信情報の設定
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(tobServerURL);
            webRequest.Method = "GET";

            // TOBのリクエストKEY(要暗号化)
            webRequest.Headers.Add("bl-app-key", "df8f7b8f-a44a-49e9-a50e-afa1f902cd4e");
            //webRequest.ServicePoint.Expect100Continue = false;

            string resultJsonString = "";
            Settings_MAIN retJson = new Settings_MAIN();

            try
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                using (Stream resStream = webResponse.GetResponseStream())
                using (StreamReader sr = new StreamReader(resStream, Encoding.UTF8))
                {
                    // 結果取得
                    resultJsonString = sr.ReadToEnd();

                    //結果をデシリアライズ
                    retJson = FM.WebSync.Core.JSON.Deserialize<Settings_MAIN>(resultJsonString);
                    settingsList.AddRange(retJson.settings);
                    st = 0;
                } 
            }
            catch (WebException ex)
            {
                errMsg = "動作設定の取得に失敗しました。";
                st = -1;
                // HTTPプロトコルエラーかどうか調べる
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse errorRes = (HttpWebResponse)ex.Response;
                    st = (int)errorRes.StatusCode;
                }
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "動作設定取得処理で例外が発生しました。" + Environment.NewLine + ex.StackTrace.ToString();
            }
            return st;
        }

        #endregion

        #endregion


        /// <summary>
        /// 画像変換処理
        /// </summary>
        /// <returns></returns>
        private Image Base64ToImage(string imageBase64)
        {
            Image img = null;
            try
            {
                byte[] imageBytes = System.Convert.FromBase64String(imageBase64);
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    img = Image.FromStream(ms, true);
                }
            }
            catch
            {
                img = null;
            }
            return img;
        }

        /// <summary>
        /// Base64変換処理
        /// </summary>
        /// <returns></returns>
        private string ImageToBase64(Image image)
        {
            string base64String = string.Empty;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, image.RawFormat);
                    byte[] imageBytes = ms.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                }
            }
            catch
            {
                base64String = "";
            }
            return base64String;
        }

        #endregion
    }


 
}
