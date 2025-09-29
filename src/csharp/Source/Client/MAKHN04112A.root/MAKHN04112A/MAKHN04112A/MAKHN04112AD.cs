# region ※using
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.LocalAccess;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Runtime.Serialization;
# endregion

namespace Broadleaf.Application.Controller
{
    ///// <summary>
    ///// 価格マスタ(提供分) テーブルアクセスクラス
    ///// </summary>
    ///// <remarks>
    ///// -----------------------------------------------------------------------------------
    ///// <br>Note		: 価格マスタ(提供分) テーブルのアクセス制御を行います。</br>
    ///// <br>Programmer	: 20056 對馬 大輔</br>
    ///// <br>Date		: 2007.08.13</br>
    ///// <br>UpdateNote : 2008.02.19 96012　日色 馨</br>
    ///// <br>           : ローカルＤＢ参照対応</br>
    ///// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
    ///// <br>           : 提供分はローカルＤＢへのアクセスのみ</br>
    ///// </remarks>
    //public class OfrGoodsPriceAcs
    //{
    //    # region ■Private Member
    //    /// <summary>リモートオブジェクト格納バッファ</summary>
    //    // 2008.02.29 96012 提供分はローカルＤＢへのアクセスのみ Begin
    //    //private IOfrGoodsPriceDB _iOfrGoodsPriceDB = null;
    //    // 2008.02.29 96012 提供分はローカルＤＢへのアクセスのみ end
    //    // 2008.02.19 96012 ローカルＤＢ参照対応 Begin
    //    private OfrGoodsPriceLcDB _ofrGoodsPriceLcDB = null;
    //    // 2008.02.19 96012 ローカルＤＢ参照対応 end

    //    /// <summary>価格マスタ(提供分) クラスStatic</summary>
    //    private static Hashtable _ofrgoodspriceTable_Stc = null;

    //    /// <summary>ローカルＤＢモード</summary>
    //    // 2008.02.19 96012 ローカルＤＢ参照対応 Begin
    //    //private static bool _isLocalDBRead = true;
    //    private static bool _isLocalDBRead = false;
    //    // 2008.02.19 96012 ローカルＤＢ参照対応 end

    //    private const string GUIDE_SEARCHMODE_PARA = "SearchMode";                     // ガイドデータサーチモード(0:ローカル,1:リモート) iitani a 2007.05.07

    //    # endregion

    //    # region ■Constracter
    //    /// <summary>
    //    /// 価格マスタ(提供分) テーブルアクセスクラスコンストラクタ
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// -----------------------------------------------------------------------
    //    /// <br>UpdateNote : 2008.02.19 96012　日色 馨</br>
    //    /// <br>           : ローカルＤＢ参照対応</br>
    //    /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
    //    /// <br>           : 提供分はローカルＤＢへのアクセスのみ</br>
    //    /// </remarks>
    //    public OfrGoodsPriceAcs()
    //    {
    //        // メモリ生成処理
    //        MemoryCreate();

    //        // 2008.02.29 96012 提供分はローカルＤＢへのアクセスのみ Begin
    //        //// ログイン部品で通信状態を確認
    //        //if (LoginInfoAcquisition.OnlineFlag)
    //        //{
    //        //    try
    //        //    {
    //        //        // リモートオブジェクト取得
    //        //        this._iOfrGoodsPriceDB = (IOfrGoodsPriceDB)MediationOfrGoodsPriceDB.GetOfrGoodsPriceDB();
    //        //    }
    //        //    catch (Exception)
    //        //    {
    //        //        //オフライン時はnullをセット
    //        //        this._iOfrGoodsPriceDB = null;
    //        //    }
    //        //}
    //        //else
    //        //{
    //        //    // オフライン時のデータ読み込み
    //        //    this.SearchOfflineData();
    //        //}
    //        // 2008.02.29 96012 提供分はローカルＤＢへのアクセスのみ end

    //        // ローカルDBアクセスオブジェクト取得
    //        //this._lGoodsGanreLcDB = new LGoodsGanreLcDB();   // iitani a
    //        // 2008.02.19 96012 ローカルＤＢ参照対応 Begin
    //        // ローカルDBアクセスオブジェクト取得
    //        this._ofrGoodsPriceLcDB = new OfrGoodsPriceLcDB();
    //        // 2008.02.19 96012 ローカルＤＢ参照対応 end
    //    }
    //    # endregion

    //    //================================================================================
    //    //  プロパティ
    //    //================================================================================
    //    #region Public Property

    //    /// <summary>
    //    /// ローカルＤＢReadモード
    //    /// </summary>
    //    public bool IsLocalDBRead
    //    {
    //        get { return _isLocalDBRead; }
    //        set { _isLocalDBRead = value; }
    //    }
    //    #endregion

    //    # region ◆public int GetOnlineMode()
    //    /// <summary>
    //    /// オンラインモード取得処理
    //    /// </summary>
    //    /// <returns>OnlineMode</returns>
    //    /// <remarks>
    //    /// <br>Note       : オンラインモードを取得します。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.01</br>
    //    /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
    //    /// <br>           : 提供分はローカルＤＢへのアクセスのみ</br>
    //    /// </remarks>
    //    public int GetOnlineMode()
    //    {
    //        // 2008.02.29 96012 提供分はローカルＤＢへのアクセスのみ Begin
    //        //if (this._iOfrGoodsPriceDB == null)
    //        //{
    //        //    return (int)ConstantManagement.OnlineMode.Offline;
    //        //}
    //        //else
    //        //{
    //        //    return (int)ConstantManagement.OnlineMode.Online;
    //        //}
    //        return (int)ConstantManagement.OnlineMode.Offline;
    //        // 2008.02.29 96012 提供分はローカルＤＢへのアクセスのみ end
    //    }
    //    # endregion

    //    #region ■Public Method
    //    /// <summary>
    //    /// 価格マスタ(提供分) マスタStaticメモリ全件取得処理
    //    /// </summary>
    //    /// <param name="retList">価格マスタ クラスList</param>
    //    /// <returns>ステータス(0:正常終了, -1:エラー, 9:データ無し)</returns>
    //    /// <param name="enterpriseCode">企業コード</param>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ マスタStaticメモリの全件を取得します。</br>
    //    /// <br>Programer  : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int SearchStaticMemory(out ArrayList retList, object objParaList, string enterpriseCode)
    //    {
    //        retList = new ArrayList();
    //        retList.Clear();
    //        SortedList sortedList = new SortedList();

    //        if ((_ofrgoodspriceTable_Stc == null) ||
    //            (_ofrgoodspriceTable_Stc.Count == 0))
    //        {
    //            this.SearchAll(out retList, objParaList, enterpriseCode);
    //            return 0;
    //        }
    //        else if (_ofrgoodspriceTable_Stc.Count == 0)
    //        {
    //            return 9;
    //        }

    //        foreach (OfrGoodsPrice ofrGoodsPrice in _ofrgoodspriceTable_Stc.Values)
    //        {
    //            string strkey = string.Format("000000", ofrGoodsPrice.GoodsMakerCd) + ofrGoodsPrice.GoodsNo + string.Format("00", ofrGoodsPrice.PriceDivCd);
    //            sortedList.Add(strkey, ofrGoodsPrice);
    //        }

    //        retList.AddRange(sortedList.Values);

    //        return 0;
    //    }

    //    /// <summary>
    //    /// 価格マスタ(提供分)　マスタStaticメモリ取得処理
    //    /// </summary>
    //    /// <param name="alttlblockstrf"></param>
    //    /// <param name="enterpriseCodeRF"></param>
    //    /// <param name="alTtlBlockCodeRF"></param>
    //    /// <returns></returns>
    //    public int ReadStaticMemory(out OfrGoodsPrice ofrgoodspricerf, object objParaList, string enterpriseCodeRF, int goodsMakerCdRF, string goodsNoRF, int priceDivCdRF)
    //    //public int ReadStaticMemory(out AlTtlBlockSt alttlblockstrf, string enterpriseCodeRF, string alTtlBlockCodeRF)
    //    {
    //        ofrgoodspricerf = new OfrGoodsPrice();
    //        //alttlblockstrf = new AlTtlBlockSt();

    //        if ((_ofrgoodspriceTable_Stc == null) ||
    //            (_ofrgoodspriceTable_Stc.Count == 0))
    //        {
    //            ArrayList ofrgoodspriceList = new ArrayList();
    //            this.SearchAll(out ofrgoodspriceList, objParaList, enterpriseCodeRF);
    //        }

    //        // Staticから検索
    //        string strkey = string.Format("000000", goodsMakerCdRF) + goodsNoRF + string.Format("00", priceDivCdRF);
    //        if (_ofrgoodspriceTable_Stc[strkey] == null)
    //        {
    //            return 4;
    //        }
    //        else 
    //        {
    //            ofrgoodspricerf = (OfrGoodsPrice)_ofrgoodspriceTable_Stc[strkey];
    //        }

    //        return 0;

    //    }

    //    /// <summary>
    //    /// 価格マスタ(提供分) Staticメモリ情報オフライン書き込み処理
    //    /// </summary>
    //    /// <param name="sender">object（呼出元オブジェクト）</param>
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(提供分) Staticメモリの情報をローカルファイルに保存します。</br>
    //    /// <br>Programer  : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int WriteOfflineData(object sender)
    //    {
    //        // オフラインシリアライズデータ作成部品I/O
    //        OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
    //        int status;

    //        // KeyList設定
    //        string[] ofrgoodspriceKeys = new string[1];
    //        ofrgoodspriceKeys[0] = LoginInfoAcquisition.EnterpriseCode;

    //        SortedList sortedList = new SortedList();

    //        OfrGoodsPriceWork ofrgoodspriceWork = new OfrGoodsPriceWork();
    //        foreach (OfrGoodsPrice ofrgoodsprice in _ofrgoodspriceTable_Stc.Values)
    //        {
    //            // クラス⇒ワーカークラス
    //            ofrgoodspriceWork = CopyToOfrGoodsPriceWorkFromOfrGoodsPrice(ofrgoodsprice);
                
    //            // ソート
    //            string strkey = string.Format("000000", ofrgoodsprice.GoodsMakerCd) + ofrgoodsprice.GoodsNo + string.Format("00", ofrgoodsprice.PriceDivCd);
    //            sortedList.Add(strkey, ofrgoodspriceWork);
    //        }

    //        ArrayList ofrgoodspriceWorkList = new ArrayList();
    //        ofrgoodspriceWorkList.AddRange(sortedList.Values);
    //        status = offlineDataSerializer.Serialize("OfrGoodsPriceAcs", ofrgoodspriceKeys, ofrgoodspriceWorkList);

    //        return status;
    //    }

    //    /// <summary>
    //    /// 価格マスタ(提供)読み込み処理
    //    /// </summary>
    //    /// <param name="ofrgoodsprice">価格マスタ(提供)オブジェクト</param>
    //    /// <param name="enterpriseCode">企業コード</param>
    //    /// <param name="goodsmakercd">商品メーカーコード</param>
    //    /// <param name="goodsno">商品番号</param>
    //    /// <returns></returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(提供)情報を読み込みます。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.01</br>
    //    /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
    //    /// <br>           : 提供分はローカルＤＢへのアクセスのみ</br>
    //    /// </remarks>
    //    public int Read(out OfrGoodsPrice ofrgoodsprice, string enterpriseCode, int goodsmakercd, string goodsno)
    //    {
    //        try
    //        {
    //            int status;
    //            ofrgoodsprice = null;
    //            OfrGoodsPriceWork ofrgoodspriceWork = new OfrGoodsPriceWork();

    //            //ofrgoodspriceWork.EnterpriseCode = enterpriseCode;
    //            ofrgoodspriceWork.GoodsMakerCd = goodsmakercd;
    //            ofrgoodspriceWork.GoodsNo = goodsno;

    //            // 2008.02.29 96012 提供分はローカルＤＢへのアクセスのみ Begin
    //            //byte[] parabyte = null;
    //            //
    //            //// リモート
    //            //parabyte = XmlByteSerializer.Serialize(ofrgoodspriceWork);
    //            //status = this._iOfrGoodsPriceDB.Read(ref parabyte, 0);
    //            //if (status == 0)
    //            //{
    //            //    ofrgoodspriceWork = (OfrGoodsPriceWork)XmlByteSerializer.Deserialize(parabyte, typeof(OfrGoodsPriceWork));
    //            //}
    //            status = this._ofrGoodsPriceLcDB.Read(ref ofrgoodspriceWork, 0);
    //            // 2008.02.29 96012 提供分はローカルＤＢへのアクセスのみ end

    //            if (status == 0)
    //            {
    //                // クラス内メンバコピー
    //                ofrgoodsprice = CopyToOfrGoodsPriceFormOfrGoodsPriceWork(ofrgoodspriceWork);
    //                // Read用Staticに保持
    //                string strkey = string.Format("000000", ofrgoodsprice.GoodsMakerCd) + ofrgoodsprice.GoodsNo + string.Format("00", ofrgoodsprice.PriceDivCd);
    //                _ofrgoodspriceTable_Stc[strkey] = ofrgoodsprice;
    //            }

    //            return status;
    //        }
    //        catch (Exception)
    //        {
    //            //通信エラーは-1を戻す
    //            ofrgoodsprice = null;
    //            // 2008.02.29 96012 提供分はローカルＤＢへのアクセスのみ Begin
    //            ////オフライン時はnullをセット
    //            //this._iOfrGoodsPriceDB = null;
    //            // 2008.02.29 96012 提供分はローカルＤＢへのアクセスのみ end
    //            return -1;
    //        }
    //    }

    //    /// <summary>
    //    /// 価格マスタ(提供) クラスデシリアライズ処理
    //    /// </summary>
    //    /// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
    //    /// <returns>価格マスタ(提供) クラス</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(提供) クラスをデシリアライズします。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public OfrGoodsPrice Deserialize(string fileName)
    //    {
    //        return null;
    //    }

    //    /// <summary>
    //    /// 価格マスタ(提供) Listクラスデシリアライズ処理
    //    /// </summary>
    //    /// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
    //    /// <returns>価格マスタ(提供) クラスLIST</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタマスタ リストクラスをデシリアライズします。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public ArrayList ListDeserialize(string fileName)
    //    {
    //        ArrayList al = new ArrayList();

    //        // ファイル名を渡して価格マスタ(提供)ワーククラスをデシリアライズする
    //        OfrGoodsPriceWork[] ofrgoodspriceWorks = (OfrGoodsPriceWork[])XmlByteSerializer.Deserialize(fileName, typeof(OfrGoodsPriceWork[]));
            
    //        //デシリアライズ結果を価格マスタ(提供)クラスへコピー
    //        if (ofrgoodspriceWorks != null)
    //        {
    //            al.Capacity = ofrgoodspriceWorks.Length;
    //            for (int i = 0; i < ofrgoodspriceWorks.Length; i++)
    //            {
    //                al.Add(CopyToOfrGoodsPriceFormOfrGoodsPriceWork(ofrgoodspriceWorks[i]));
    //            }
    //        }

    //        return al;
    //    }

    //    /// <summary>
    //    /// 価格マスタ(提供)シリアライズ処理
    //    /// </summary>
    //    /// <param name="ofrgoodsprice">シリアライズ対象価格マスタ(提供)クラス</param>
    //    /// <param name="fileName">シリアライズファイル名</param>
    //    public void Serialize(OfrGoodsPrice ofrgoodsprice, string fileName)
    //    {
    //        //価格マスタ(提供)クラスから価格マスタ(提供)ワーカークラスにメンバコピー
    //        OfrGoodsPriceWork ofrgoodspriceWork = CopyToOfrGoodsPriceWorkFromOfrGoodsPrice(ofrgoodsprice);
    //        //価格マスタ(提供)ワーカークラスをシリアライズ
    //        XmlByteSerializer.Serialize(ofrgoodspriceWork, fileName);
    //    }

    //    /// <summary>
    //    /// 価格マスタ(提供)Listシリアライズ処理
    //    /// </summary>
    //    /// <param name="ofrgoodsprices">シリアライズ対象価格マスタ(提供)Listクラス</param>
    //    /// <param name="fileName">シリアライズファイル名</param>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(提供)List情報のシリアライズを行います。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public void ListSerialize(ArrayList ofrgoodsprices, string fileName)
    //    {
    //        OfrGoodsPriceWork[] ofrgoodspriceWorks = new OfrGoodsPriceWork[ofrgoodsprices.Count];
    //        for (int i = 0; i < ofrgoodsprices.Count; i++)
    //        {
    //            ofrgoodspriceWorks[i] = CopyToOfrGoodsPriceWorkFromOfrGoodsPrice((OfrGoodsPrice)ofrgoodsprices[i]);
    //        }
    //        //価格マスタ(提供)ワーカークラスをシリアライズ
    //        XmlByteSerializer.Serialize(ofrgoodsprices, fileName);
    //    }

    //    /// <summary>
    //    /// 価格マスタ(提供)全検索処理（論理削除除く）
    //    /// </summary>
    //    /// <param name="retList">読込結果コレクション</param>
    //    /// <param name="enterpriseCode">企業コード</param>		
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(提供)の全検索処理を行います。論理削除データは抽出対象外となります。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int Search(out ArrayList retList, object objParaList, string enterpriseCode)
    //    {
    //        bool nextData;
    //        int retTotalCnt;
    //        return SearchProc(out retList, out retTotalCnt, out nextData, objParaList, enterpriseCode, 0, 0, null);
    //    }

    //    /// <summary>
    //    /// 価格マスタ(提供)検索処理（論理削除含む）
    //    /// </summary>
    //    /// <param name="retList">読込結果コレクション</param>
    //    /// <param name="enterpriseCode">企業コード</param>		
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int SearchAll(out ArrayList retList, object objParaList, string enterpriseCode)
    //    {
    //        bool nextData;
    //        int retTotalCnt;
    //        return SearchProc(out retList, out retTotalCnt, out nextData, objParaList, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null);
    //    }

    //    /// <summary>
    //    /// 件数指定価格マスタ(提供)検索処理（論理削除除く）
    //    /// </summary>
    //    /// <param name="retList">読込結果コレクション</param>
    //    /// <param name="retTotalCnt">読込対象データ総件数(prevLGoodsGanreがnullの場合のみ戻る)</param>
    //    /// <param name="nextData">次データ有無</param>
    //    /// <param name="enterpriseCode">企業コード</param>
    //    /// <param name="readCnt">読込件数</param>		
    //    /// <param name="prevOfrGoodsPrice">前回データオブジェクト（初回はnull指定必須）</param>			
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : 件数を指定して価格マスタ(提供)の検索処理を行います。論理削除データは抽出対象外となります。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int Search(out ArrayList retList, out int retTotalCnt, out bool nextData, object objParaList, string enterpriseCode, int readCnt, OfrGoodsPrice prevOfrGoodsPrice)
    //    {
    //        return SearchProc(out retList, out retTotalCnt, out nextData, objParaList, enterpriseCode, 0, readCnt, prevOfrGoodsPrice);
    //    }

    //    /// <summary>
    //    /// 件数指定価格マスタ(提供)検索処理（論理削除含む）
    //    /// </summary>
    //    /// <param name="retList">読込結果コレクション</param>
    //    /// <param name="retTotalCnt">読込対象データ総件数(prevLGoodsGanreがnullの場合のみ戻る)</param>
    //    /// <param name="nextData">次データ有無</param>
    //    /// <param name="enterpriseCode">企業コード</param>
    //    /// <param name="readCnt">読込件数</param>		
    //    /// <param name="prevAlTtlBlockSt">前回データオブジェクト（初回はnull指定必須）</param>			
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : 件数を指定して価格マスタ(提供)の検索処理を行います。論理削除データも抽出対象となります。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int SearchAll(out ArrayList retList, out int retTotalCnt, out bool nextData, object objParaList, string enterpriseCode, int readCnt, OfrGoodsPrice prevOfrGoodsPrice)
    //    {
    //        return SearchProc(out retList, out retTotalCnt, out nextData, objParaList, enterpriseCode, ConstantManagement.LogicalMode.GetData01, readCnt, prevOfrGoodsPrice);
    //    }

    //    /// <summary>
    //    /// 価格マスタ(提供)検索処理(DataSet用)
    //    /// </summary>
    //    /// <param name="ds">取得結果格納用DataSet</param>
    //    /// <param name="enterpriseCode">企業コード</param>
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(提供)の検索処理を行い、取得結果をDataSetで返します。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// -----------------------------------------------------------------------
    //    /// <br>UpdateNote : 2008.02.19 96012　日色 馨</br>
    //    /// <br>           : ローカルＤＢ参照対応</br>
    //    /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
    //    /// <br>           : 提供分はローカルＤＢへのアクセスのみ</br>
    //    /// </remarks>
    //    public int Search(ref DataSet ds, object objParaList, string enterpriseCode)
    //    {
    //        OfrGoodsPriceWork ofrgoodspriceWork = new OfrGoodsPriceWork();

    //        ArrayList ar = new ArrayList();

    //        int status = 0;
    //        // 2008.02.29 96012 提供分はローカルＤＢへのアクセスのみ Begin
    //        //object objectOfrGoodsPriceWork;
    //        // 2008.02.29 96012 提供分はローカルＤＢへのアクセスのみ end

    //        // 2008.02.29 96012 提供分はローカルＤＢへのアクセスのみ Begin
    //        //// オンライン且つ、Searchが行われていない場合（オフラインの場合はコンストラクタでStatic展開済み）
    //        //if ((!_searchFlg) && (LoginInfoAcquisition.OnlineFlag))
    //        //{
    //        //    // 価格マスタ(提供)サーチ
    //        //    status = this._iOfrGoodsPriceDB.Search(out objectOfrGoodsPriceWork, ofrgoodspriceWork, 0, ConstantManagement.LogicalMode.GetData01);
    //        //
    //        //    if (status == 0)
    //        //    {
    //        //        // 価格マスタ(提供)ワーカークラス⇒UIクラスStatic転記処理
    //        //        CopyToStaticFromWorker(objectOfrGoodsPriceWork as ArrayList);
    //        //        // SearchFlg ON
    //        //        _searchFlg = true;
    //        //    }
    //        //    else
    //        //    {
    //        //        return status;
    //        //    }
    //        //}
    //        // 価格マスタ(提供)サーチ
    //        List<OfrGoodsPriceWork> workList = new List<OfrGoodsPriceWork>();
    //        status = this._ofrGoodsPriceLcDB.Search(out workList, ofrgoodspriceWork, 0, ConstantManagement.LogicalMode.GetData01);
    //        if (status == 0)
    //        {
    //            for (int i = 0; i < workList.Count; ++i)
    //            {
    //                ar.Add(workList[i]);
    //            }
    //            // 価格マスタ(提供)ワーカークラス⇒UIクラスStatic転記処理
    //            CopyToStaticFromWorker(ar);
    //        }
    //        else
    //        {
    //            return status;
    //        }
    //        // 2008.02.29 96012 提供分はローカルＤＢへのアクセスのみ end

    //        /*
    //        // Staticからガイド表示（オン/オフ共通）	
    //        foreach (AlTtlBlockSt alttlblockstWk in _alttlblockstTable_Stc.Values)
    //        {
    //            // ArrayListへメンバコピー
    //            if (belongSectionCode.Trim() == "")
    //            {
    //                // 全社表示
    //                ar.Add(alttlblockstWk.Clone());
    //            }
    //        }
    //        */

    //        ArrayList wkList = ar.Clone() as ArrayList;
    //        SortedList wkSort = new SortedList();

    //        // --- [全て] --- //
    //        // そのまま全件返す
    //        foreach (OfrGoodsPrice wkOfrGoodsPrice in wkList)
    //        {
    //            if (wkOfrGoodsPrice.LogicalDeleteCode == 0)
    //            {
    //                string strkey = string.Format("000000", wkOfrGoodsPrice.GoodsMakerCd) + wkOfrGoodsPrice.GoodsNo + string.Format("00", wkOfrGoodsPrice.PriceDivCd);
    //                wkSort.Add(strkey, wkOfrGoodsPrice);
    //            }
    //        }

    //        OfrGoodsPrice[] ofrgoodsprices = new OfrGoodsPrice[wkSort.Count];

    //        // データを元に戻す
    //        for (int i = 0; i < wkSort.Count; i++)
    //        {
    //            ofrgoodsprices[i] = (OfrGoodsPrice)wkSort.GetByIndex(i);
    //        }

    //        byte[] retbyte = XmlByteSerializer.Serialize(ofrgoodsprices);
    //        XmlByteSerializer.ReadXml(ref ds, retbyte);

    //        return status;
    //    }

    //    /// <summary>
    //    /// クラスメンバーコピー処理(価格マスタ(提供)ワーククラス⇒価格マスタ(提供)クラス)
    //    /// </summary>
    //    /// <param name="ofrgoodspricework">価格マスタ(提供)ワーククラス</param>
    //    /// <returns>価格マスタ(提供)クラス</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(提供)マスタワーククラスから価格マスタ(提供)クラスへメンバーのコピーを行います。（レイアウト分のみ）</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public static OfrGoodsPrice CopyToOfrGoodsPrice(OfrGoodsPriceWork ofrgoodspricework)
    //    {
    //        OfrGoodsPrice ofrgoodsprice = new OfrGoodsPrice();

    //        ofrgoodsprice.CreateDateTime = ofrgoodspricework.CreateDateTime;
    //        ofrgoodsprice.UpdateDateTime = ofrgoodspricework.UpdateDateTime;
    //        ofrgoodsprice.LogicalDeleteCode = ofrgoodspricework.LogicalDeleteCode;

    //        ofrgoodsprice.GoodsMakerCd = ofrgoodspricework.GoodsMakerCd;
    //        ofrgoodsprice.GoodsNo = ofrgoodspricework.GoodsNo;
    //        ofrgoodsprice.NewPrice = ofrgoodspricework.NewPrice;
    //        ofrgoodsprice.NewPriceStartDate = ofrgoodspricework.NewPriceStartDate;
    //        ofrgoodsprice.OfferDate = ofrgoodspricework.OfferDate;
    //        ofrgoodsprice.OldPrice = ofrgoodspricework.OldPrice;
    //        ofrgoodsprice.OpenPriceDiv = ofrgoodspricework.OpenPriceDiv;
    //        ofrgoodsprice.PriceDivCd = ofrgoodspricework.PriceDivCd;

    //        return ofrgoodsprice;
    //    }

    //    /// <summary>
    //    /// 価格マスタ(提供)テーブル作成処理
    //    /// </summary>
    //    /// <param name="GoodsPriceTable"></param>
    //    /// <param name="goodsPriceTable"></param>
    //    /// <param name="retList"></param>
    //    public void MakeHashTableFromOfrGoodsPrice(out Hashtable GoodsPriceTable, Hashtable goodsPriceTable, ArrayList retList)
    //    {
    //        string HasyKey = "";
    //        Hashtable hashTable = new Hashtable();
    //        foreach (OfrGoodsPrice ofrgoodsprice in retList)
    //        {
    //            HasyKey = ofrgoodsprice.PriceDivCd.ToString("00");
    //            if (!goodsPriceTable.Contains(HasyKey))
    //            {
    //                GoodsPrice goodsprice = new GoodsPrice();

    //                goodsprice.CreateDateTime = ofrgoodsprice.CreateDateTime; // 作成日時
    //                goodsprice.UpdateDateTime = ofrgoodsprice.UpdateDateTime; // 更新日時
    //                //goodsprice.EnterpriseCode = ofrgoodsprice.EnterpriseCode; // 企業コード
    //                //goodsprice.FileHeaderGuid = ofrgoodsprice.FileHeaderGuid; // GUID
    //                //goodsprice.UpdEmployeeCode = ofrgoodsprice.UpdEmployeeCode; // 更新従業員コード
    //                //goodsprice.UpdAssemblyId1 = ofrgoodsprice.UpdAssemblyId1; // 更新アセンブリID1
    //                //goodsprice.UpdAssemblyId2 = ofrgoodsprice.UpdAssemblyId2; // 更新アセンブリID2
    //                goodsprice.LogicalDeleteCode = ofrgoodsprice.LogicalDeleteCode; // 論理削除区分
    //                goodsprice.GoodsMakerCd = ofrgoodsprice.GoodsMakerCd; // 商品メーカーコード
    //                goodsprice.GoodsNo = ofrgoodsprice.GoodsNo; // 商品番号
    //                //goodsprice.PriceStartDate = ofrgoodsprice.PriceStartDate; // 価格開始日
    //                //goodsprice.ListPrice = ofrgoodsprice.ListPrice; // 定価（浮動）
    //                //goodsprice.SalesUnitCost = ofrgoodsprice.SalesUnitCost; // 原価単価
    //                //goodsprice.StockRate = ofrgoodsprice.StockRate; // 仕入率
    //                goodsprice.OpenPriceDiv = ofrgoodsprice.OpenPriceDiv; // オープン価格区分
    //                goodsprice.OfferDate = ofrgoodsprice.OfferDate; // 提供日付
    //                //goodsprice.UpdateDate = ofrgoodsprice.UpdateDate; // 更新年月日

    //                hashTable[HasyKey] = goodsprice;
    //            }
    //        }
    //        GoodsPriceTable = hashTable;

    //    }

    //    #region ▼マスメンUIクラス用参照処理
    //    /// <summary>
    //    /// 拠点名称取得処理
    //    /// </summary>
    //    /// <param name="enterpriseCode">企業コード</param>
    //    /// <param name="sectionCode">拠点コード</param>
    //    /// <returns>拠点名称</returns>
    //    /// <remarks>
    //    /// <br>Note       : 拠点名称を返します。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.01</br>
    //    /// </remarks>
    //    public string GetSectionName(string enterpriseCode, string sectionCode)
    //    {
    //        return "未登録";
    //    }
    //    #endregion

    //    #endregion

    //    #region ■Private Method
    //    /// <summary>
    //    /// 価格マスタ(提供)検索処理
    //    /// </summary>
    //    /// <param name="retList">読込結果コレクション</param>
    //    /// <param name="retTotalCnt">読込対象データ総件数</param>
    //    /// <param name="nextData">次データ有無</param>
    //    /// <param name="enterpriseCode">企業コード</param>
    //    /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
    //    /// <param name="readCnt">読込件数</param>
    //    /// <param name="prevOfrGoodsPriceSt">前回最終担当者データオブジェクト</param>
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(提供)の検索処理を行います。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
    //    /// <br>           : 提供分はローカルＤＢへのアクセスのみ</br>
    //    /// </remarks>
    //    private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, object objParaList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, OfrGoodsPrice prevOfrGoodsPriceSt)
    //    {
    //        OfrGoodsPriceWork ofrgoodspriceWork = new OfrGoodsPriceWork();
    //        if (prevOfrGoodsPriceSt != null) ofrgoodspriceWork = CopyToOfrGoodsPriceWorkFromOfrGoodsPrice(prevOfrGoodsPriceSt);
    //        //alttlblockstWork.EnterpriseCode = enterpriseCode;

    //        int status;

    //        //次データ有無初期化
    //        nextData = false;
    //        //0で初期化
    //        retTotalCnt = 0;

    //        retList = new ArrayList();
    //        retList.Clear();
    //        ArrayList paraList = new ArrayList();

    //        // オフラインの場合はキャッシュから読む
    //        if (!LoginInfoAcquisition.OnlineFlag)
    //        {
    //            status = SearchStaticMemory(out retList, objParaList, enterpriseCode);
    //        }
    //        else
    //        {
    //            OfrGoodsPrice ofrgoodsprice = new OfrGoodsPrice();
    //            object objectOfrGoodsPriceWork = null;

    //            // 価格マスタ(提供)検索
    //            // リモート 
    //            // 2008.02.29 96012 提供分はローカルＤＢへのアクセスのみ Begin
    //            //status = this._iOfrGoodsPriceDB.Search(out objectOfrGoodsPriceWork, objParaList, 0, logicalMode);
    //            List<OfrGoodsPriceWork> workList = new List<OfrGoodsPriceWork>();
    //            status = this._ofrGoodsPriceLcDB.Search(out workList, ofrgoodspriceWork, 0, logicalMode);
    //            if (status == 0)
    //            {
    //                ArrayList ar = new ArrayList();
    //                for (int i = 0; i < workList.Count; ++i)
    //                {
    //                    ar.Add(workList[i]);
    //                }
    //                objectOfrGoodsPriceWork = ar;
    //            }
    //            // 2008.02.29 96012 提供分はローカルＤＢへのアクセスのみ end

    //            if (status == 0)
    //            {
    //                // 価格マスタ(提供)ワーカークラス⇒UIクラスStatic転記処理
    //                CopyToStaticFromWorker(objectOfrGoodsPriceWork as ArrayList);

    //                // パラメータが渡って来ているか確認
    //                paraList = objectOfrGoodsPriceWork as ArrayList;
    //                OfrGoodsPriceWork[] wkOfrGoodsPriceWork = new OfrGoodsPriceWork[paraList.Count];

    //                // データを元に戻す
    //                for (int i = 0; i < paraList.Count; i++)
    //                {
    //                    wkOfrGoodsPriceWork[i] = (OfrGoodsPriceWork)paraList[i];
    //                }
    //                for (int i = 0; i < wkOfrGoodsPriceWork.Length; i++)
    //                {
    //                    ofrgoodsprice = CopyToOfrGoodsPriceFormOfrGoodsPriceWork(wkOfrGoodsPriceWork[i]);
    //                    // サーチ結果取得
    //                    retList.Add(ofrgoodsprice);
    //                    // スタティック更新
    //                    string strkey = string.Format("000000", ofrgoodsprice.GoodsMakerCd) + ofrgoodsprice.GoodsNo + string.Format("00", ofrgoodsprice.PriceDivCd);
    //                    _ofrgoodspriceTable_Stc[strkey] = ofrgoodsprice;
    //                }
    //            }
    //        }
    //        //全件リードの場合は戻り値の件数をセット
    //        if (readCnt == 0) retTotalCnt = retList.Count;

    //        return status;
    //    }

    //    /// <summary>
    //    /// クラスメンバーコピー処理（価格マスタ(提供)ワーククラス⇒価格マスタ(提供)クラス）
    //    /// </summary>
    //    /// <param name="ofrgoodspricework">価格マスタ(提供)ワーククラス</param>
    //    /// <returns>価格マスタ(提供)クラス</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(提供)ワーククラスから価格マスタ(提供)クラスへメンバーのコピーを行います。</br>
    //    /// <br>		    : 自動生成に追加したプロパティ分もセットします。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private OfrGoodsPrice CopyToOfrGoodsPriceFormOfrGoodsPriceWork(OfrGoodsPriceWork ofrgoodspricework)
    //    {
    //        OfrGoodsPrice ofrgoodsprice = new OfrGoodsPrice();

    //        ofrgoodsprice = CopyToOfrGoodsPrice(ofrgoodspricework);

    //        return ofrgoodsprice;
    //    }

    //    /// <summary>
    //    /// クラスメンバーコピー処理（価格マスタ(提供)クラス⇒価格マスタ(提供)ワーククラス）
    //    /// </summary>
    //    /// <param name="ofrgoodsprice">価格マスタ(提供)ワーククラス</param>
    //    /// <returns>価格マスタ(提供)クラス</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(提供)クラスから価格マスタ(提供)マスタワーククラスへメンバーのコピーを行います。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private OfrGoodsPriceWork CopyToOfrGoodsPriceWorkFromOfrGoodsPrice(OfrGoodsPrice ofrgoodsprice)
    //    {
    //        OfrGoodsPriceWork ofrgoodspricework = new OfrGoodsPriceWork();

    //        ofrgoodspricework.CreateDateTime = ofrgoodsprice.CreateDateTime;
    //        ofrgoodspricework.UpdateDateTime = ofrgoodsprice.UpdateDateTime;
    //        ofrgoodspricework.LogicalDeleteCode = ofrgoodsprice.LogicalDeleteCode;

    //        ofrgoodspricework.GoodsMakerCd = ofrgoodsprice.GoodsMakerCd;
    //        ofrgoodspricework.GoodsNo = ofrgoodsprice.GoodsNo;
    //        ofrgoodspricework.NewPrice = ofrgoodsprice.NewPrice;
    //        ofrgoodspricework.NewPriceStartDate = ofrgoodsprice.NewPriceStartDate;
    //        ofrgoodspricework.OfferDate = ofrgoodsprice.OfferDate;
    //        ofrgoodspricework.OldPrice = ofrgoodsprice.OldPrice;
    //        ofrgoodspricework.OpenPriceDiv = ofrgoodsprice.OpenPriceDiv;
    //        ofrgoodspricework.PriceDivCd = ofrgoodsprice.PriceDivCd;

    //        return ofrgoodspricework;
    //    }

    //    /// <summary>
    //    /// メモリ生成処理
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(提供)設定アクセスクラスが保持するメモリを生成します。</br>
    //    /// <br>Programer  : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private void MemoryCreate()
    //    {

    //        // 価格マスタ(提供)マスタクラスStatic
    //        if (_ofrgoodspriceTable_Stc == null)
    //        {
    //            _ofrgoodspriceTable_Stc = new Hashtable();
    //        }

    //    }

    //    /// <summary>
    //    /// 価格マスタ(提供)クラスワーカークラス(List) → UIクラス変換処理
    //    /// </summary>
    //    /// <param name="ofrgoodspriceWorkList"></param>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(提供)「ワーカークラスをUIの部位部品クラスに変換して、
    //    ///					 Search用Staticメモリに保持します。</br>
    //    /// <br>Programer  : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private void CopyToStaticFromWorker(List<OfrGoodsPriceWork> ofrgoodspriceWorkList)
    //    {
    //        ArrayList ofrgoodspriceWorkArray = new ArrayList();
    //        ofrgoodspriceWorkArray.AddRange(ofrgoodspriceWorkList);

    //        CopyToStaticFromWorker(ofrgoodspriceWorkArray);
    //    }

    //    /// <summary>
    //    /// 価格マスタ(提供)クラスワーカークラス(ArrayList) ⇒ UIクラス変換処理
    //    /// </summary>
    //    /// <param name="ofrgoodspriceWorkList"></param>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(提供)ワーカークラスをUIの部位部品クラスに変換して、
    //    ///					 Search用Staticメモリに保持します。</br>
    //    /// <br>Programer  : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private void CopyToStaticFromWorker(ArrayList ofrgoodspriceWorkList)
    //    {
    //        string hashKey;
    //        foreach (OfrGoodsPriceWork wkOfrGoodsPriceWork in ofrgoodspriceWorkList)
    //        {
    //            OfrGoodsPrice wkOfrGoodsPrice = new OfrGoodsPrice();

    //            // HashKey:価格区分
    //            hashKey = string.Format("00", wkOfrGoodsPriceWork.PriceDivCd);

    //            wkOfrGoodsPrice.CreateDateTime = wkOfrGoodsPriceWork.CreateDateTime;
    //            wkOfrGoodsPrice.UpdateDateTime = wkOfrGoodsPriceWork.UpdateDateTime;
    //            wkOfrGoodsPrice.LogicalDeleteCode = wkOfrGoodsPriceWork.LogicalDeleteCode;

    //            wkOfrGoodsPrice.GoodsMakerCd = wkOfrGoodsPriceWork.GoodsMakerCd;
    //            wkOfrGoodsPrice.GoodsNo = wkOfrGoodsPriceWork.GoodsNo;
    //            wkOfrGoodsPrice.NewPrice = wkOfrGoodsPriceWork.NewPrice;
    //            wkOfrGoodsPrice.NewPriceStartDate = wkOfrGoodsPriceWork.NewPriceStartDate;
    //            wkOfrGoodsPrice.OfferDate = wkOfrGoodsPriceWork.OfferDate;
    //            wkOfrGoodsPrice.OldPrice = wkOfrGoodsPriceWork.OldPrice;
    //            wkOfrGoodsPrice.OpenPriceDiv = wkOfrGoodsPriceWork.OpenPriceDiv;
    //            wkOfrGoodsPrice.PriceDivCd = wkOfrGoodsPriceWork.PriceDivCd;

    //            _ofrgoodspriceTable_Stc[hashKey] = wkOfrGoodsPrice;
    //        }
    //    }

    //    /// <summary>
    //    /// ローカルファイル読込み処理
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note       : ローカルファイルを読込んで、情報をStaticに保持します。</br>
    //    /// <br>Programer  : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private void SearchOfflineData()
    //    {
    //        // オフラインシリアライズデータ作成部品I/O
    //        OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

    //        // --- Search用 --- //
    //        // KeyList設定
    //        string[] ofrgoodspriceKeys = new string[1];
    //        ofrgoodspriceKeys[0] = LoginInfoAcquisition.EnterpriseCode;
    //        // ローカルファイル読込み処理
    //        object wkObj = offlineDataSerializer.DeSerialize("OfrGoddsPriceAcs", ofrgoodspriceKeys);
    //        // ArrayListにセット
    //        List<OfrGoodsPriceWork> wkList = new List<OfrGoodsPriceWork>();

    //        if ((wkList != null) &&
    //            (wkList.Count != 0))
    //        {
    //            // 価格マスタ(提供)クラスワーカークラス（ArrayList） ⇒ UIクラス（Static）変換処理
    //            CopyToStaticFromWorker(wkList);
    //        }
    //    }
    //    #endregion
    //}

    ///// <summary>
    ///// 価格マスタ(ユーザー登録分) テーブルアクセスクラス
    ///// </summary>
    ///// <remarks>
    ///// -----------------------------------------------------------------------------------
    ///// <br>Note		: 価格マスタ(ユーザー登録分) テーブルのアクセス制御を行います。</br>
    ///// <br>Programmer	: 20056 對馬 大輔</br>
    ///// <br>Date		: 2007.08.13</br>
    ///// -----------------------------------------------------------------------
    ///// <br>UpdateNote : 2008.02.19 96012　日色 馨</br>
    ///// <br>           : ローカルＤＢ参照対応</br>
    ///// </remarks>
    //public class GoodsPriceUAcs
    //{
    //    # region ■Private Member
    //    /// <summary>リモートオブジェクト格納バッファ</summary>
    //    private IGoodsPriceUDB _iGoodsPriceUDB = null;
    //    // 2008.02.19 96012 ローカルＤＢ参照対応 Begin
    //    private GoodsPriceULcDB _goodsPriceULcDB = null;
    //    // 2008.02.19 96012 ローカルＤＢ参照対応 end

    //    /// <summary>価格マスタ(ユーザー登録分) クラスStatic</summary>
    //    private static List<GoodsPriceU> _goodsPriceUList_Stc = null;
    //    /// <summary>価格マスタクラスSearchフラグ</summary>
    //    private static bool _searchFlg;

    //    /// <summary>ローカルＤＢモード</summary>
    //    // 2008.02.19 96012 ローカルＤＢ参照対応 Begin
    //    //private static bool _isLocalDBRead = true;
    //    private static bool _isLocalDBRead = false;
    //    // 2008.02.19 96012 ローカルＤＢ参照対応 end

    //    /// <summary>ユーザーガイドマスタ アクセスクラス</summary>
    //    private UserGuideAcs _userGuideAcs;

    //    /// <summary>ユーザーガイドマスタ</summary>
    //    private static ArrayList _userGdBdPriceDivCd = null;
    //    private static ArrayList _userGdBdUnitCode = null;
    //    private static ArrayList _userGdBdEnterpriseGanreCode = null;

    //    private const string GUIDE_SEARCHMODE_PARA = "SearchMode";                     // ガイドデータサーチモード(0:ローカル,1:リモート) iitani a 2007.05.07
    //    # endregion

    //    # region ■Constracter
    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録分) テーブルアクセスクラスコンストラクタ
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// -----------------------------------------------------------------------
    //    /// <br>UpdateNote : 2008.02.19 96012　日色 馨</br>
    //    /// <br>           : ローカルＤＢ参照対応</br>
    //    /// </remarks>
    //    public GoodsPriceUAcs()
    //    {
    //        // メモリ生成処理
    //        MemoryCreate();

    //        // ログイン部品で通信状態を確認
    //        if (LoginInfoAcquisition.OnlineFlag)
    //        {
    //            try
    //            {
    //                // リモートオブジェクト取得
    //                this._iGoodsPriceUDB = (IGoodsPriceUDB)MediationGoodsPriceUDB.GetGoodsPriceUDB();
    //            }
    //            catch (Exception)
    //            {
    //                //オフライン時はnullをセット
    //                this._iGoodsPriceUDB = null;
    //            }
    //        }
    //        else
    //        {
    //            // オフライン時のデータ読み込み
    //            this.SearchOfflineData();
    //        }
    //        // 2008.02.19 96012 ローカルＤＢ参照対応 Begin
    //        // 商品価格マスタローカルオブジェクト取得
    //        this._goodsPriceULcDB = new GoodsPriceULcDB();
    //        // 2008.02.19 96012 ローカルＤＢ参照対応 end

    //        this._userGuideAcs = new UserGuideAcs();
            
    //    }
    //    # endregion

    //    //================================================================================
    //    //  プロパティ
    //    //================================================================================
    //    #region Public Property

    //    /// <summary>
    //    /// ローカルＤＢReadモード
    //    /// </summary>
    //    public bool IsLocalDBRead
    //    {
    //        get { return _isLocalDBRead; }
    //        set { _isLocalDBRead = value; }
    //    }

    //    public static ArrayList UserGdBdPriceDivCd
    //    {
    //        get { return _userGdBdPriceDivCd; }
    //        set { _userGdBdPriceDivCd = value; }
    //    }
    //    public static ArrayList UserGdBdUnitCode
    //    {
    //        get { return _userGdBdUnitCode; }
    //        set { _userGdBdUnitCode = value; }
    //    }
    //    public static ArrayList UserGdBdEnterpriseGanreCode
    //    {
    //        get { return _userGdBdEnterpriseGanreCode; }
    //        set { _userGdBdEnterpriseGanreCode = value; }
    //    }
    //    #endregion

    //    # region ◆public int GetOnlineMode()
    //    /// <summary>
    //    /// オンラインモード取得処理
    //    /// </summary>
    //    /// <returns>OnlineMode</returns>
    //    /// <remarks>
    //    /// <br>Note       : オンラインモードを取得します。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.01</br>
    //    /// </remarks>
    //    public int GetOnlineMode()
    //    {
    //        if (this._iGoodsPriceUDB == null)
    //        {
    //            return (int)ConstantManagement.OnlineMode.Offline;
    //        }
    //        else
    //        {
    //            return (int)ConstantManagement.OnlineMode.Online;
    //        }
    //    }
    //    # endregion

    //    #region ■Public Method
    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録分) マスタStaticメモリ全件取得処理
    //    /// </summary>
    //    /// <param name="retList">価格マスタ クラスList</param>
    //    /// <returns>ステータス(0:正常終了, -1:エラー, 9:データ無し)</returns>
    //    /// <param name="enterpriseCode">企業コード</param>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ マスタStaticメモリの全件を取得します。</br>
    //    /// <br>Programer  : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int SearchStaticMemory(out ArrayList retList, object objParaList, string enterpriseCode)
    //    {
    //        retList = new ArrayList();
    //        retList.Clear();
    //        SortedList sortedList = new SortedList();

    //        if ((_goodsPriceUList_Stc == null) ||
    //            (_goodsPriceUList_Stc.Count == 0))
    //        {
    //            this.SearchAll(out retList,  objParaList, enterpriseCode);
    //            return 0;
    //        }
    //        else if (_goodsPriceUList_Stc.Count == 0)
    //        {
    //            return 9;
    //        }

    //        foreach (GoodsPriceU goodsPriceU in _goodsPriceUList_Stc.Values)
    //        {
    //            string strkey = string.Format("000000", goodsPriceU.GoodsMakerCd) + goodsPriceU.GoodsNo + string.Format("00000000000000", goodsPriceU.PriceStartDate.Ticks);
    //            sortedList.Add(strkey, goodsPriceU);
    //        }

    //        retList.AddRange(sortedList.Values);

    //        return 0;
    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録分)　マスタStaticメモリ取得処理
    //    /// </summary>
    //    /// <param name="alttlblockstrf"></param>
    //    /// <param name="enterpriseCodeRF"></param>
    //    /// <param name="alTtlBlockCodeRF"></param>
    //    /// <returns></returns>
    //    public int ReadStaticMemory(out GoodsPriceU goodspriceurf, object objParaList, string enterpriseCodeRF, int goodsMakerCdRF, string goodsNoRF, int priceDivCdRF)
    //    {
    //        goodspriceurf = new GoodsPriceU();

    //        if ((_goodsPriceUList_Stc == null) ||
    //            (_goodsPriceUList_Stc.Count == 0))
    //        {
    //            ArrayList goodspriceuList = new ArrayList();
    //            this.SearchAll(out goodspriceuList,  objParaList, enterpriseCodeRF);
    //        }

    //        // Staticから検索
    //        string strkey = string.Format("000000", goodsMakerCdRF) + goodsNoRF + string.Format("00", priceDivCdRF);
    //        if (_goodsPriceUList_Stc[strkey] == null)
    //        {
    //            return 4;
    //        }
    //        else 
    //        {
    //            goodspriceurf = (GoodsPriceU)_goodsPriceUList_Stc[strkey];
    //        }

    //        return 0;

    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録分) Staticメモリ情報オフライン書き込み処理
    //    /// </summary>
    //    /// <param name="sender">object（呼出元オブジェクト）</param>
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録分) Staticメモリの情報をローカルファイルに保存します。</br>
    //    /// <br>Programer  : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int WriteOfflineData(object sender)
    //    {
    //        // オフラインシリアライズデータ作成部品I/O
    //        OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
    //        int status;

    //        // KeyList設定
    //        string[] goodspriceuKeys = new string[1];
    //        goodspriceuKeys[0] = LoginInfoAcquisition.EnterpriseCode;

    //        SortedList sortedList = new SortedList();

    //        GoodsPriceUWork goodspriceuWork = new GoodsPriceUWork();
    //        foreach (GoodsPriceU goodspriceu in _goodsPriceUList_Stc.Values)
    //        {
    //            // クラス⇒ワーカークラス
    //            goodspriceuWork = CopyToGoodsPriceUWorkFromGoodsPriceU(goodspriceu);
                
    //            // ソート
    //            string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //            sortedList.Add(strkey, goodspriceuWork);
    //        }

    //        ArrayList goodspriceuWorkList = new ArrayList();
    //        goodspriceuWorkList.AddRange(sortedList.Values);
    //        status = offlineDataSerializer.Serialize("GoodsPriceUAcs", goodspriceuKeys, goodspriceuWorkList);

    //        return status;
    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録)読み込み処理
    //    /// </summary>
    //    /// <param name="goodspriceu">価格マスタ(ユーザー登録)オブジェクト</param>
    //    /// <param name="enterpriseCode">企業コード</param>
    //    /// <param name="goodsmakercd">商品メーカーコード</param>
    //    /// <param name="goodsno">商品番号</param>
    //    /// <returns></returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)情報を読み込みます。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.01</br>
    //    /// -----------------------------------------------------------------------
    //    /// <br>UpdateNote : 2008.02.19 96012　日色 馨</br>
    //    /// <br>           : ローカルＤＢ参照対応</br>
    //    /// </remarks>
    //    public int Read(out GoodsPriceU goodspriceu, string enterpriseCode, int goodsmakercd, string goodsno)
    //    {
    //        try
    //        {
    //            int status;
    //            goodspriceu = null;
    //            GoodsPriceUWork goodspriceuWork = new GoodsPriceUWork();

    //            goodspriceuWork.EnterpriseCode = enterpriseCode;
    //            goodspriceuWork.GoodsMakerCd = goodsmakercd;
    //            goodspriceuWork.GoodsNo = goodsno;

    //            byte[] parabyte = null;

    //            // リモート
    //            // 2008.02.19 96012 ローカルＤＢ参照対応 Begin
    //            //parabyte = XmlByteSerializer.Serialize(goodspriceuWork);
    //            //status = this._iGoodsPriceUDB.Read(ref parabyte, 0);
    //            //if (status == 0)
    //            //{
    //            //    goodspriceuWork = (GoodsPriceUWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsPriceUWork));
    //            //}
    //            //
    //            //if (status == 0)
    //            //{
    //            //    // クラス内メンバコピー
    //            //    goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuWork);
    //            //    // Read用Staticに保持
    //            //    string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00", goodspriceu.PriceDivCd);
    //            //    _goodspriceuTable_Stc[strkey] = goodspriceu;
    //            //}
    //            if (_isLocalDBRead)
    //            {
    //                status = this._goodsPriceULcDB.Read(ref goodspriceuWork, 0);
    //                if (status == 0)
    //                {
    //                    goodspriceuWork = (GoodsPriceUWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsPriceUWork));
    //                }
    //                if (status == 0)
    //                {
    //                    // クラス内メンバコピー
    //                    goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuWork);
    //                    // Read用Staticに保持
    //                    string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                    _goodsPriceUList_Stc[strkey] = goodspriceu;
    //                }
    //            }
    //            else
    //            {
    //                parabyte = XmlByteSerializer.Serialize(goodspriceuWork);
    //                status = this._iGoodsPriceUDB.Read(ref parabyte, 0);
    //                if (status == 0)
    //                {
    //                    goodspriceuWork = (GoodsPriceUWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsPriceUWork));
    //                }
    //                if (status == 0)
    //                {
    //                    // クラス内メンバコピー
    //                    goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuWork);
    //                    // Read用Staticに保持
    //                    string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                    _goodsPriceUList_Stc[strkey] = goodspriceu;
    //                }
    //            }
    //            // 2008.02.19 96012 ローカルＤＢ参照対応 end

    //            return status;
    //        }
    //        catch (Exception)
    //        {
    //            //通信エラーは-1を戻す
    //            goodspriceu = null;
    //            //オフライン時はnullをセット
    //            this._iGoodsPriceUDB = null;
    //            return -1;
    //        }
    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録) クラスデシリアライズ処理
    //    /// </summary>
    //    /// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
    //    /// <returns>価格マスタ(ユーザー登録) クラス</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録) クラスをデシリアライズします。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public GoodsPriceU Deserialize(string fileName)
    //    {
    //        return null;
    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録) Listクラスデシリアライズ処理
    //    /// </summary>
    //    /// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
    //    /// <returns>価格マスタ(ユーザー登録) クラスLIST</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタマスタ リストクラスをデシリアライズします。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public ArrayList ListDeserialize(string fileName)
    //    {
    //        ArrayList al = new ArrayList();

    //        // ファイル名を渡して価格マスタ(ユーザー登録)ワーククラスをデシリアライズする
    //        GoodsPriceUWork[] goodspriceuWorks = (GoodsPriceUWork[])XmlByteSerializer.Deserialize(fileName, typeof(GoodsPriceUWork[]));
            
    //        //デシリアライズ結果を価格マスタ(ユーザー登録)クラスへコピー
    //        if (goodspriceuWorks != null)
    //        {
    //            al.Capacity = goodspriceuWorks.Length;
    //            for (int i = 0; i < goodspriceuWorks.Length; i++)
    //            {
    //                al.Add(CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuWorks[i]));
    //            }
    //        }

    //        return al;
    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録)登録・更新
    //    /// </summary>
    //    /// <param name="goodspriceu">価格マスタ(ユーザー登録)</param>
    //    /// <returns></returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)情報の登録・更新を行います。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.01</br>
    //    /// </remarks>
    //    public int Write(ref GoodsPriceU goodspriceu)
    //    {
    //        //価格マスタ(ユーザー登録)から価格マスタワーカークラスにメンバコピー
    //        GoodsPriceUWork goodspriceuWork = CopyToGoodsPriceUWorkFromGoodsPriceU(goodspriceu);
    //        ArrayList al = new ArrayList();

    //        object parabyte = (object)goodspriceuWork;
    //        object errobj = null;

    //        int status = 0;
    //        try
    //        {
    //            //価格マスタ(ユーザー登録)書き込み
    //            status = this._iGoodsPriceUDB.Write(ref parabyte, out errobj);
    //            if (status == 0)
    //            {
    //                al = (ArrayList)parabyte;
    //                goodspriceuWork = (GoodsPriceUWork)al[0];

    //                // クラス内メンバコピー
    //                goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuWork);
    //                // Staticデータ更新
    //                string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                _goodsPriceUList_Stc[strkey] = goodspriceu;
    //            }

    //        }
    //        catch (Exception)
    //        {
    //            //オフライン時はnullをセット
    //            this._iGoodsPriceUDB = null;
    //            //通信エラーは-1を戻す
    //            status = -1;
    //        }

    //        return status;
    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録)登録・更新(リスト)
    //    /// </summary>
    //    /// <param name="goodspriceuList">価格マスタ(ユーザー登録)</param>
    //    /// <returns></returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)情報の登録・更新を行います。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.01</br>
    //    /// </remarks>
    //    public int Write(ref ArrayList goodspriceuList)
    //    {
    //        //価格マスタ(ユーザー登録)から価格マスタワーカークラスにメンバコピー
    //        ArrayList goodspriceuWorkList = CopyToGoodsPriceUWorkFromGoodsPriceUList(goodspriceuList);
    //        ArrayList al = new ArrayList();

    //        object parabyte = (object)goodspriceuWorkList;
    //        object errobj = null;

    //        int status = 0;
    //        try
    //        {
    //            //価格マスタ(ユーザー登録)書き込み
    //            status = this._iGoodsPriceUDB.Write(ref parabyte, out errobj);
    //            if (status == 0)
    //            {

    //                al = (ArrayList)parabyte;
    //                GoodsPriceU goodspriceu = new GoodsPriceU();
    //                foreach (GoodsPriceUWork goodspriceuwork in al)
    //                {
    //                    goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuwork);
    //                    goodspriceuList.Add(goodspriceu);


    //                    // Staticデータ更新
    //                    string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                    _goodsPriceUList_Stc[strkey] = goodspriceu;
    //                }
                    
    //            }

    //        }
    //        catch (Exception)
    //        {
    //            //オフライン時はnullをセット
    //            this._iGoodsPriceUDB = null;
    //            //通信エラーは-1を戻す
    //            status = -1;
    //        }

    //        return status;
    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録)シリアライズ処理
    //    /// </summary>
    //    /// <param name="goodspriceu">シリアライズ対象価格マスタ(ユーザー登録)クラス</param>
    //    /// <param name="fileName">シリアライズファイル名</param>
    //    public void Serialize(GoodsPriceU goodspriceu, string fileName)
    //    {
    //        //価格マスタ(ユーザー登録)クラスから価格マスタ(ユーザー登録)ワーカークラスにメンバコピー
    //        GoodsPriceUWork goodspriceuWork = CopyToGoodsPriceUWorkFromGoodsPriceU(goodspriceu);
    //        //価格マスタ(ユーザー登録)ワーカークラスをシリアライズ
    //        XmlByteSerializer.Serialize(goodspriceuWork, fileName);
    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録)Listシリアライズ処理
    //    /// </summary>
    //    /// <param name="goodspriceus">シリアライズ対象価格マスタ(ユーザー登録)Listクラス</param>
    //    /// <param name="fileName">シリアライズファイル名</param>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)List情報のシリアライズを行います。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public void ListSerialize(ArrayList goodspriceus, string fileName)
    //    {
    //        GoodsPriceUWork[] goodspriceuWorks = new GoodsPriceUWork[goodspriceus.Count];
    //        for (int i = 0; i < goodspriceus.Count; i++)
    //        {
    //            goodspriceuWorks[i] = CopyToGoodsPriceUWorkFromGoodsPriceU((GoodsPriceU)goodspriceus[i]);
    //        }
    //        //価格マスタ(ユーザー登録)ワーカークラスをシリアライズ
    //        XmlByteSerializer.Serialize(goodspriceus, fileName);
    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録)論理削除処理
    //    /// </summary>
    //    /// <param name="goodspriceu">価格マスタ(ユーザー登録)オブジェクト</param>
    //    /// <returns></returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)情報の論理削除を行います。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    //public int LogicalDelete(ref GoodsPriceU goodspriceu)
    //    public int LogicalDelete(ref ArrayList goodspriceuList)
    //    {
    //        try
    //        {

    //            //価格マスタ(ユーザー登録)から価格マスタワーカークラスにメンバコピー
    //            ArrayList goodspriceuWorkList = CopyToGoodsPriceUWorkFromGoodsPriceUList(goodspriceuList);
    //            ArrayList al = new ArrayList();

    //            object parabyte = (object)goodspriceuWorkList;

    //            int status = 0;
    //            try
    //            {
    //                //価格マスタ(ユーザー登録)論理削除
    //                status = this._iGoodsPriceUDB.LogicalDelete(ref parabyte);
    //                if (status == 0)
    //                {

    //                    al = (ArrayList)parabyte;
    //                    GoodsPriceU goodspriceu = new GoodsPriceU();
    //                    foreach (GoodsPriceUWork goodspriceuwork in al)
    //                    {
    //                        goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuwork);
    //                        goodspriceuList.Add(goodspriceu);


    //                        // Staticデータ更新
    //                        string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                        _goodsPriceUList_Stc[strkey] = goodspriceu;
    //                    }

    //                }

    //            }
    //            catch (Exception)
    //            {
    //                //オフライン時はnullをセット
    //                this._iGoodsPriceUDB = null;
    //                //通信エラーは-1を戻す
    //                status = -1;
    //            }
    //            return status;
    //        }
    //        catch (Exception)
    //        {
    //            //オフライン時はnullをセット
    //            this._iGoodsPriceUDB = null;
    //            //通信エラーは-1を戻す
    //            return -1;
    //        }
    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録)物理削除処理
    //    /// </summary>
    //    /// <param name="goodspriceu">価格マスタ(ユーザー登録)オブジェクト</param>
    //    /// <returns></returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)情報の物理削除を行います。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int Delete(ArrayList goodspriceuList)
    //    {
    //        try
    //        {
    //            //価格マスタ(ユーザー登録)から価格マスタワーカークラスにメンバコピー
    //            ArrayList goodspriceuWorkList = CopyToGoodsPriceUWorkFromGoodsPriceUList(goodspriceuList);
    //            ArrayList al = new ArrayList();
    //            GoodsPriceUWork[] goodspriceuWork = null;

    //            byte[] parabyte = XmlByteSerializer.Serialize(goodspriceuWorkList);
                
    //            // 価格マスタ(ユーザー登録)マスタ物理削除
    //            int status = this._iGoodsPriceUDB.Delete(parabyte);

    //            if (status == 0)
    //            {
    //                goodspriceuWork = (GoodsPriceUWork[])XmlByteSerializer.Deserialize(parabyte, typeof(GoodsPriceUWork[]));
    //                al.AddRange(goodspriceuWork);
    //                GoodsPriceU goodspriceu = new GoodsPriceU();
    //                foreach (GoodsPriceUWork goodspriceuwork in al)
    //                {
    //                    goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuwork);
    //                    goodspriceuList.Add(goodspriceu);


    //                    // Staticデータ更新
    //                    string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                    _goodsPriceUList_Stc.Remove(strkey);
    //                }

    //            }

    //            return status;
    //        }
    //        catch (Exception)
    //        {
    //            //オフライン時はnullをセット
    //            this._iGoodsPriceUDB = null;
    //            //通信エラーは-1を戻す
    //            return -1;
    //        }
    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録)全検索処理（論理削除除く）
    //    /// </summary>
    //    /// <param name="retList">読込結果コレクション</param>
    //    /// <param name="enterpriseCode">企業コード</param>		
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)の全検索処理を行います。論理削除データは抽出対象外となります。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int Search(out ArrayList retList, object objParaList, string enterpriseCode)
    //    {
    //        bool nextData;
    //        int retTotalCnt;
    //        return SearchProc(out retList, out retTotalCnt, out nextData, objParaList, enterpriseCode, 0, 0, null);
    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録)検索処理（論理削除含む）
    //    /// </summary>
    //    /// <param name="retList">読込結果コレクション</param>
    //    /// <param name="enterpriseCode">企業コード</param>		
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int SearchAll(out ArrayList retList, object objParaList, string enterpriseCode)
    //    {
    //        bool nextData;
    //        int retTotalCnt;
    //        return SearchProc(out retList, out retTotalCnt, out nextData, objParaList, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null);
    //    }

    //    /// <summary>
    //    /// 件数指定価格マスタ(ユーザー登録)検索処理（論理削除除く）
    //    /// </summary>
    //    /// <param name="retList">読込結果コレクション</param>
    //    /// <param name="retTotalCnt">読込対象データ総件数(prevLGoodsGanreがnullの場合のみ戻る)</param>
    //    /// <param name="nextData">次データ有無</param>
    //    /// <param name="enterpriseCode">企業コード</param>
    //    /// <param name="readCnt">読込件数</param>		
    //    /// <param name="prevGoodsPriceU">前回データオブジェクト（初回はnull指定必須）</param>			
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : 件数を指定して価格マスタ(ユーザー登録)の検索処理を行います。論理削除データは抽出対象外となります。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int Search(out ArrayList retList, out int retTotalCnt, out bool nextData, object objParaList, string enterpriseCode, int readCnt, GoodsPriceU prevGoodsPriceU)
    //    {
    //        return SearchProc(out retList, out retTotalCnt, out nextData,  objParaList, enterpriseCode, 0, readCnt, prevGoodsPriceU);
    //    }

    //    /// <summary>
    //    /// 件数指定価格マスタ(ユーザー登録)検索処理（論理削除除く）
    //    /// </summary>
    //    /// <param name="retList">読込結果コレクション</param>
    //    /// <param name="retTotalCnt">読込対象データ総件数(prevLGoodsGanreがnullの場合のみ戻る)</param>
    //    /// <param name="nextData">次データ有無</param>
    //    /// <param name="enterpriseCode">企業コード</param>
    //    /// <param name="readCnt">読込件数</param>		
    //    /// <param name="prevAlTtlBlockSt">前回データオブジェクト（初回はnull指定必須）</param>			
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : 件数を指定して価格マスタ(ユーザー登録)の検索処理を行います。論理削除データも抽出対象となります。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int SearchAll(out ArrayList retList, out int retTotalCnt, out bool nextData, object objParaList, string enterpriseCode, int readCnt, GoodsPriceU prevGoodsPriceU)
    //    {
    //        return SearchProc(out retList, out retTotalCnt, out nextData, objParaList, enterpriseCode, ConstantManagement.LogicalMode.GetData01, readCnt, prevGoodsPriceU);
    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録)論理削除復活処理
    //    /// </summary>
    //    /// <param name="goodspriceu">価格マスタ(ユーザー登録)マスタオブジェクト</param>
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)情報の復活を行います。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int Revival(ref ArrayList goodspriceuList)
    //    {
    //        try
    //        {
    //            //価格マスタ(ユーザー登録)から価格マスタワーカークラスにメンバコピー
    //            ArrayList goodspriceuWorkList = CopyToGoodsPriceUWorkFromGoodsPriceUList(goodspriceuList);
    //            ArrayList al = new ArrayList();

    //            object parabyte = (object)goodspriceuWorkList;

    //            // 復活処理
    //            int status = this._iGoodsPriceUDB.RevivalLogicalDelete(ref parabyte);

    //            if (status == 0)
    //            {
    //                al = (ArrayList)parabyte;
    //                GoodsPriceU goodspriceu = new GoodsPriceU();
    //                foreach (GoodsPriceUWork goodspriceuwork in al)
    //                {
    //                    goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuwork);
    //                    goodspriceuList.Add(goodspriceu);

    //                    // Staticデータ更新
    //                    string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                    _goodsPriceUList_Stc[strkey] = goodspriceu;
    //                }

    //            }

    //            return status;
    //        }
    //        catch (Exception)
    //        {
    //            //オフライン時はnullをセット
    //            this._iGoodsPriceUDB = null;
    //            //通信エラーは-1を戻す
    //            return -1;
    //        }
    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録)検索処理(DataSet用)
    //    /// </summary>
    //    /// <param name="ds">取得結果格納用DataSet</param>
    //    /// <param name="enterpriseCode">企業コード</param>
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)の検索処理を行い、取得結果をDataSetで返します。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// -----------------------------------------------------------------------
    //    /// <br>UpdateNote : 2008.02.19 96012　日色 馨</br>
    //    /// <br>           : ローカルＤＢ参照対応</br>
    //    /// </remarks>
    //    public int Search(ref DataSet ds, object objParaList, string enterpriseCode)
    //    {
    //        GoodsPriceUWork goodspriceuWork = new GoodsPriceUWork();

    //        ArrayList ar = new ArrayList();

    //        int status = 0;
    //        object objectGoodsPriceUWork;

    //        // 2008.02.19 96012 ローカルＤＢ参照対応 Begin
    //        //// オンライン且つ、Searchが行われていない場合（オフラインの場合はコンストラクタでStatic展開済み）
    //        //if ((!_searchFlg) && (LoginInfoAcquisition.OnlineFlag))
    //        //{
    //        //    // 価格マスタ(ユーザー登録)サーチ
    //        //    status = this._iGoodsPriceUDB.Search(out objectGoodsPriceUWork, objParaList, 0, ConstantManagement.LogicalMode.GetData01);
    //        //
    //        //    if (status == 0)
    //        //    {
    //        //        // 価格マスタ(ユーザー登録)ワーカークラス⇒UIクラスStatic転記処理
    //        //        CopyToStaticFromWorker(objectGoodsPriceUWork as ArrayList);
    //        //        // SearchFlg ON
    //        //        _searchFlg = true;
    //        //    }
    //        //    else
    //        //    {
    //        //        return status;
    //        //    }
    //        //}
    //        if (_isLocalDBRead)
    //        {
    //            List<GoodsPriceUWork> workList = new List<GoodsPriceUWork>();
    //            GoodsPriceUWork workPara = new GoodsPriceUWork();
    //            status = this._goodsPriceULcDB.Search(out workList, objParaList as GoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData01);
    //            if (status == 0)
    //            {
    //                ArrayList arrayList = new ArrayList();
    //                arrayList.AddRange(workList);
    //                // 価格マスタ(ユーザー登録)ワーカークラス⇒UIクラスStatic転記処理
    //                CopyToStaticFromWorker(arrayList);
    //                // SearchFlg ON
    //                _searchFlg = true;
    //            }
    //            else
    //            {
    //                return status;
    //            }
    //        }
    //        else
    //        {
    //            // オンライン且つ、Searchが行われていない場合（オフラインの場合はコンストラクタでStatic展開済み）
    //            if ((!_searchFlg) && (LoginInfoAcquisition.OnlineFlag))
    //            {
    //                // 価格マスタ(ユーザー登録)サーチ
    //                status = this._iGoodsPriceUDB.Search(out objectGoodsPriceUWork, objParaList, 0, ConstantManagement.LogicalMode.GetData01);

    //                if (status == 0)
    //                {
    //                    // 価格マスタ(ユーザー登録)ワーカークラス⇒UIクラスStatic転記処理
    //                    CopyToStaticFromWorker(objectGoodsPriceUWork as ArrayList);
    //                    // SearchFlg ON
    //                    _searchFlg = true;
    //                }
    //                else
    //                {
    //                    return status;
    //                }
    //            }
    //        }
    //        // 2008.02.19 96012 ローカルＤＢ参照対応 end

    //        /*
    //        // Staticからガイド表示（オン/オフ共通）	
    //        foreach (AlTtlBlockSt alttlblockstWk in _alttlblockstTable_Stc.Values)
    //        {
    //            // ArrayListへメンバコピー
    //            if (belongSectionCode.Trim() == "")
    //            {
    //                // 全社表示
    //                ar.Add(alttlblockstWk.Clone());
    //            }
    //        }
    //        */

    //        ArrayList wkList = ar.Clone() as ArrayList;
    //        SortedList wkSort = new SortedList();

    //        // --- [全て] --- //
    //        // そのまま全件返す
    //        foreach (GoodsPriceU wkGoodsPriceU in wkList)
    //        {
    //            if (wkGoodsPriceU.LogicalDeleteCode == 0)
    //            {
    //                string strkey = string.Format("000000", wkGoodsPriceU.GoodsMakerCd) + wkGoodsPriceU.GoodsNo + string.Format("00000000000000", wkGoodsPriceU.PriceStartDate.Ticks);
    //                wkSort.Add(strkey, wkGoodsPriceU);
    //            }
    //        }

    //        GoodsPriceU[] goodspriceus = new GoodsPriceU[wkSort.Count];

    //        // データを元に戻す
    //        for (int i = 0; i < wkSort.Count; i++)
    //        {
    //            goodspriceus[i] = (GoodsPriceU)wkSort.GetByIndex(i);
    //        }

    //        byte[] retbyte = XmlByteSerializer.Serialize(goodspriceus);
    //        XmlByteSerializer.ReadXml(ref ds, retbyte);

    //        return status;
    //    }

    //    /// <summary>
    //    /// クラスメンバーコピー処理(価格マスタ(ユーザー登録)ワーククラス⇒価格マスタ(ユーザー登録)クラス)
    //    /// </summary>
    //    /// <param name="goodspriceuwork">価格マスタ(ユーザー登録)ワーククラス</param>
    //    /// <returns>価格マスタ(ユーザー登録)クラス</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)マスタワーククラスから価格マスタ(ユーザー登録)クラスへメンバーのコピーを行います。（レイアウト分のみ）</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public static GoodsPriceU CopyToGoodsPriceU(GoodsPriceUWork goodspriceuwork)
    //    {
    //        GoodsPriceU goodspriceu = new GoodsPriceU();

    //        goodspriceu.CreateDateTime = goodspriceuwork.CreateDateTime; // 作成日時
    //        goodspriceu.UpdateDateTime = goodspriceuwork.UpdateDateTime; // 更新日時
    //        goodspriceu.EnterpriseCode = goodspriceuwork.EnterpriseCode; // 企業コード
    //        goodspriceu.FileHeaderGuid = goodspriceuwork.FileHeaderGuid; // GUID
    //        goodspriceu.UpdEmployeeCode = goodspriceuwork.UpdEmployeeCode; // 更新従業員コード
    //        goodspriceu.UpdAssemblyId1 = goodspriceuwork.UpdAssemblyId1; // 更新アセンブリID1
    //        goodspriceu.UpdAssemblyId2 = goodspriceuwork.UpdAssemblyId2; // 更新アセンブリID2
    //        goodspriceu.LogicalDeleteCode = goodspriceuwork.LogicalDeleteCode; // 論理削除区分
    //        goodspriceu.GoodsMakerCd = goodspriceuwork.GoodsMakerCd; // 商品メーカーコード
    //        goodspriceu.GoodsNo = goodspriceuwork.GoodsNo; // 商品番号
    //        goodspriceu.PriceStartDate = goodspriceuwork.PriceStartDate; // 価格開始日
    //        goodspriceu.ListPrice = goodspriceuwork.ListPrice; // 定価（浮動）
    //        goodspriceu.SalesUnitCost = goodspriceuwork.SalesUnitCost; // 原価単価
    //        goodspriceu.StockRate = goodspriceuwork.StockRate; // 仕入率
    //        goodspriceu.OpenPriceDiv = goodspriceuwork.OpenPriceDiv; // オープン価格区分
    //        goodspriceu.OfferDate = goodspriceuwork.OfferDate; // 提供日付
    //        goodspriceu.UpdateDate = goodspriceuwork.UpdateDate; // 更新年月日

    //        return goodspriceu;
    //    }

    //    ///// <summary>
    //    ///// 価格マスタ(ユーザー登録)テーブル作成処理
    //    ///// </summary>
    //    ///// <param name="GoodsPriceTable"></param>
    //    ///// <param name="goodsPriceTable"></param>
    //    ///// <param name="retList"></param>
    //    //public void MakeHashTableFromGoodsPriceU(out Hashtable GoodsPriceTable, Hashtable goodsPriceTable, ArrayList retList)
    //    //{
    //    //    Hashtable hashTable = new Hashtable();
    //    //    foreach (GoodsPriceU goodspriceu in retList)
    //    //    {
    //    //        GoodsUnitData.GoodsPriceKey goodsPriceKey = new GoodsUnitData.GoodsPriceKey(goodspriceu.GoodsNo, goodspriceu.GoodsMakerCd, goodspriceu.PriceStartDate);
    //    //        if (!goodsPriceTable.Contains(goodsPriceKey))
    //    //        {
    //    //            GoodsPrice goodsprice = new GoodsPrice();

    //    //            goodsprice.CreateDateTime = goodspriceu.CreateDateTime; // 作成日時
    //    //            goodsprice.UpdateDateTime = goodspriceu.UpdateDateTime; // 更新日時
    //    //            goodsprice.EnterpriseCode = goodspriceu.EnterpriseCode; // 企業コード
    //    //            goodsprice.FileHeaderGuid = goodspriceu.FileHeaderGuid; // GUID
    //    //            goodsprice.UpdEmployeeCode = goodspriceu.UpdEmployeeCode; // 更新従業員コード
    //    //            goodsprice.UpdAssemblyId1 = goodspriceu.UpdAssemblyId1; // 更新アセンブリID1
    //    //            goodsprice.UpdAssemblyId2 = goodspriceu.UpdAssemblyId2; // 更新アセンブリID2
    //    //            goodsprice.LogicalDeleteCode = goodspriceu.LogicalDeleteCode; // 論理削除区分
    //    //            goodsprice.GoodsMakerCd = goodspriceu.GoodsMakerCd; // 商品メーカーコード
    //    //            goodsprice.GoodsNo = goodspriceu.GoodsNo; // 商品番号
    //    //            goodsprice.PriceStartDate = goodspriceu.PriceStartDate; // 価格開始日
    //    //            goodsprice.ListPrice = goodspriceu.ListPrice; // 定価（浮動）
    //    //            goodsprice.SalesUnitCost = goodspriceu.SalesUnitCost; // 原価単価
    //    //            goodsprice.StockRate = goodspriceu.StockRate; // 仕入率
    //    //            goodsprice.OpenPriceDiv = goodspriceu.OpenPriceDiv; // オープン価格区分
    //    //            goodsprice.OfferDate = goodspriceu.OfferDate; // 提供日付
    //    //            goodsprice.UpdateDate = goodspriceu.UpdateDate; // 更新年月日

    //    //            hashTable[goodsPriceKey] = goodsprice;
    //    //        }
    //    //    }
    //    //    GoodsPriceTable = hashTable;
    //    //}

    //    #region ▼マスメンUIクラス用参照処理
    //    /// <summary>
    //    /// 拠点名称取得処理
    //    /// </summary>
    //    /// <param name="enterpriseCode">企業コード</param>
    //    /// <param name="sectionCode">拠点コード</param>
    //    /// <returns>拠点名称</returns>
    //    /// <remarks>
    //    /// <br>Note       : 拠点名称を返します。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.01</br>
    //    /// </remarks>
    //    public string GetSectionName(string enterpriseCode, string sectionCode)
    //    {
    //        return "未登録";
    //    }
    //    #endregion

        //#region ●　ユーザーガイドマスタ取得
        ///// <summary>
        ///// ユーザーガイドマスタ取得
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sectionCode">拠点コード</param>
        ///// <param name="msg">エラーメッセージ</param>
        ///// <returns></returns>
        //public int SearchInitial_UserGdBd(string enterpriseCode, out ArrayList userGdBd, Int32 userGuideDivCd)
        //{
        //    string msg;
        //    return SearchInitial_UserGdBd(enterpriseCode, out msg, out userGdBd, userGuideDivCd);
        //}

        ///// <summary>
        ///// ユーザーガイドマスタ取得
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sectionCode">拠点コード</param>
        ///// <param name="msg">エラーメッセージ</param>
        ///// <returns></returns>
        //public int SearchInitial_UserGdBd(string enterpriseCode, out string msg, out ArrayList userGdBd, Int32 userGuideDivCd)
        //{

        //    userGdBd = null;

        //    // Staticキャッシュクリア
        //    ArrayList clearData = new ArrayList();
        //    clearData.Add(typeof(UserGdBd));

        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    msg = "";

        //    try
        //    {
        //        status = this._userGuideAcs.SearchAllDivCodeBody(
        //            out userGdBd,
        //            enterpriseCode,
        //            userGuideDivCd,
        //            UserGuideAcsData.UserBodyData);

        //        switch (status)
        //        {
        //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //                {
        //                    switch (userGuideDivCd)
        //                    {
        //                        case USERGDBD_PRICEDIVCD:
        //                            {
        //                                _userGdBdPriceDivCd = userGdBd;
        //                                break;
        //                            }
        //                        case USERGDBD_UNITCODE:
        //                            {
        //                                _userGdBdUnitCode = userGdBd;
        //                                break;
        //                            }
        //                        case USERGDBD_ENTERPRISEGANRECODE:
        //                            {
        //                                _userGdBdEnterpriseGanreCode = userGdBd;
        //                                break;
        //                            }
        //                    }
        //                    break;
        //                }
        //            case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //                {
        //                    break;
        //                }
        //            default:
        //                {
        //                    msg = "ユーザーガイドマスタの取得に失敗しました";
        //                    break;
        //                }
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //        msg = "ユーザーガイドマスタの取得で例外が発生しました[" + ex.Message + "]";
        //        msg = ex.Message;
        //    }


        //    return 0;

        //}

        ///// <summary>
        ///// ユーザーガイドインデックス取得処理
        ///// </summary>
        ///// <param name="userGdBd"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public int GetIndex(ArrayList userGdBd, Int32 value)
        //{
        //    int index = 0;
        //    foreach (UserGdBd wkUserGdBdWork in userGdBd)
        //    {
        //        if (wkUserGdBdWork.GuideCode == value)
        //        {
        //            return index;
        //        }
        //        index++;
        //    }
        //    return index;
        //}
        //#endregion


    //    #endregion

    //    #region ■Private Method
    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録)検索処理
    //    /// </summary>
    //    /// <param name="retList">読込結果コレクション</param>
    //    /// <param name="retTotalCnt">読込対象データ総件数</param>
    //    /// <param name="nextData">次データ有無</param>
    //    /// <param name="enterpriseCode">企業コード</param>
    //    /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
    //    /// <param name="readCnt">読込件数</param>
    //    /// <param name="prevGoodsPriceUSt">前回最終担当者データオブジェクト</param>
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)の検索処理を行います。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// -----------------------------------------------------------------------
    //    /// <br>UpdateNote : 2008.02.19 96012　日色 馨</br>
    //    /// <br>           : ローカルＤＢ参照対応</br>
    //    /// </remarks>
    //    private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, object objParaList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, GoodsPriceU prevGoodsPriceUSt)
    //    {
    //        GoodsPriceUWork goodspriceuWork = new GoodsPriceUWork();
    //        if (prevGoodsPriceUSt != null) goodspriceuWork = CopyToGoodsPriceUWorkFromGoodsPriceU(prevGoodsPriceUSt);
    //        //alttlblockstWork.EnterpriseCode = enterpriseCode;

    //        int status;

    //        //次データ有無初期化
    //        nextData = false;
    //        //0で初期化
    //        retTotalCnt = 0;

    //        retList = new ArrayList();
    //        retList.Clear();
    //        ArrayList paraList = new ArrayList();

    //        // 2008.02.19 96012 ローカルＤＢ参照対応 Begin
    //        //// オフラインの場合はキャッシュから読む
    //        //if (!LoginInfoAcquisition.OnlineFlag)
    //        //{
    //        //    status = SearchStaticMemory(out retList, objParaList, enterpriseCode);
    //        //}
    //        //else
    //        //{
    //        //    GoodsPriceU goodspriceu = new GoodsPriceU();
    //        //    object objectGoodsPriceUWork = null;
    //        //
    //        //    // 価格マスタ(ユーザー登録)検索
    //        //    // リモート 
    //        //    status = this._iGoodsPriceUDB.Search(out objectGoodsPriceUWork, objectGoodsPriceUWork, 0, logicalMode);
    //        //
    //        //    if (status == 0)
    //        //    {
    //        //        // 価格マスタ(ユーザー登録)ワーカークラス⇒UIクラスStatic転記処理
    //        //        CopyToStaticFromWorker(objectGoodsPriceUWork as ArrayList);
    //        //
    //        //        // パラメータが渡って来ているか確認
    //        //        paraList = objectGoodsPriceUWork as ArrayList;
    //        //        GoodsPriceUWork[] wkGoodsPriceUWork = new GoodsPriceUWork[paraList.Count];
    //        //
    //        //        // データを元に戻す
    //        //        for (int i = 0; i < paraList.Count; i++)
    //        //        {
    //        //            wkGoodsPriceUWork[i] = (GoodsPriceUWork)paraList[i];
    //        //        }
    //        //        for (int i = 0; i < wkGoodsPriceUWork.Length; i++)
    //        //        {
    //        //            goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(wkGoodsPriceUWork[i]);
    //        //            // サーチ結果取得
    //        //            retList.Add(goodspriceu);
    //        //            // スタティック更新
    //        //            string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00", goodspriceu.PriceDivCd);
    //        //            _goodspriceuTable_Stc[strkey] = goodspriceu;
    //        //        }
    //        //
    //        //        _searchFlg = true;
    //        //    }
    //        //}
    //        if (_isLocalDBRead)
    //        {
    //            List<GoodsPriceUWork> workList = new List<GoodsPriceUWork>();
    //            GoodsPriceUWork workPara = new GoodsPriceUWork();
    //            GoodsPriceU goodspriceu = new GoodsPriceU();
    //            status = this._goodsPriceULcDB.Search(out workList, objParaList as GoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData01);
    //            if (status == 0)
    //            {
    //                ArrayList arrayList = new ArrayList();
    //                arrayList.AddRange(workList);
    //                // 価格マスタ(ユーザー登録)ワーカークラス⇒UIクラスStatic転記処理
    //                CopyToStaticFromWorker(arrayList);
    //                for (int i = 0; i < workList.Count; ++i)
    //                {
    //                    goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(workList[i]);
    //                    // サーチ結果取得
    //                    retList.Add(goodspriceu);
    //                    // スタティック更新
    //                    string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                    _goodsPriceUList_Stc[strkey] = goodspriceu;
    //                }
    //                // SearchFlg ON
    //                _searchFlg = true;
    //            }
    //            else
    //            {
    //                return status;
    //            }
    //        }
    //        else
    //        {
    //            //全件リードの場合は戻り値の件数をセット
    //            if (readCnt == 0) retTotalCnt = retList.Count;
    //            // オフラインの場合はキャッシュから読む
    //            if (!LoginInfoAcquisition.OnlineFlag)
    //            {
    //                status = SearchStaticMemory(out retList, objParaList, enterpriseCode);
    //            }
    //            else
    //            {
    //                GoodsPriceU goodspriceu = new GoodsPriceU();
    //                object objectGoodsPriceUWork = null;
    //                // 価格マスタ(ユーザー登録)検索
    //                // リモート 
    //                status = this._iGoodsPriceUDB.Search(out objectGoodsPriceUWork, objectGoodsPriceUWork, 0, logicalMode);
    //                if (status == 0)
    //                {
    //                    // 価格マスタ(ユーザー登録)ワーカークラス⇒UIクラスStatic転記処理
    //                    CopyToStaticFromWorker(objectGoodsPriceUWork as ArrayList);
    //                    // パラメータが渡って来ているか確認
    //                    paraList = objectGoodsPriceUWork as ArrayList;
    //                    GoodsPriceUWork[] wkGoodsPriceUWork = new GoodsPriceUWork[paraList.Count];
    //                    // データを元に戻す
    //                    for (int i = 0; i < paraList.Count; i++)
    //                    {
    //                        wkGoodsPriceUWork[i] = (GoodsPriceUWork)paraList[i];
    //                    }
    //                    for (int i = 0; i < wkGoodsPriceUWork.Length; i++)
    //                    {
    //                        goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(wkGoodsPriceUWork[i]);
    //                        // サーチ結果取得
    //                        retList.Add(goodspriceu);
    //                        // スタティック更新
    //                        string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                        _goodsPriceUList_Stc[strkey] = goodspriceu;
    //                    }
    //                    _searchFlg = true;
    //                }
    //            }
    //        }
    //        // 2008.02.19 96012 ローカルＤＢ参照対応 end
    //        //全件リードの場合は戻り値の件数をセット
    //        if (readCnt == 0) retTotalCnt = retList.Count;

    //        return status;
    //    }

    //    /// <summary>
    //    /// クラスメンバーコピー処理（価格マスタ(ユーザー登録)ワーククラス⇒価格マスタ(ユーザー登録)クラス）
    //    /// </summary>
    //    /// <param name="goodspriceuwork">価格マスタ(ユーザー登録)ワーククラス</param>
    //    /// <returns>価格マスタ(ユーザー登録)クラス</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)ワーククラスから価格マスタ(ユーザー登録)クラスへメンバーのコピーを行います。</br>
    //    /// <br>		    : 自動生成に追加したプロパティ分もセットします。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private GoodsPriceU CopyToGoodsPriceUFormGoodsPriceUWork(GoodsPriceUWork goodspriceuwork)
    //    {
    //        GoodsPriceU goodspriceu = new GoodsPriceU();

    //        goodspriceu = CopyToGoodsPriceU(goodspriceuwork);

    //        return goodspriceu;
    //    }

    //    /// <summary>
    //    /// クラスメンバーコピー処理（価格マスタ(ユーザー登録)クラス⇒価格マスタ(ユーザー登録)ワーククラス）
    //    /// </summary>
    //    /// <param name="goodspriceu">価格マスタ(ユーザー登録)ワーククラス</param>
    //    /// <returns>価格マスタ(ユーザー登録)クラス</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)クラスから価格マスタ(ユーザー登録)マスタワーククラスへメンバーのコピーを行います。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private GoodsPriceUWork CopyToGoodsPriceUWorkFromGoodsPriceU(GoodsPriceU goodspriceu)
    //    {
    //        GoodsPriceUWork goodspriceuwork = new GoodsPriceUWork();

    //        goodspriceuwork.CreateDateTime = goodspriceu.CreateDateTime; // 作成日時
    //        goodspriceuwork.UpdateDateTime = goodspriceu.UpdateDateTime; // 更新日時
    //        goodspriceuwork.EnterpriseCode = goodspriceu.EnterpriseCode; // 企業コード
    //        goodspriceuwork.FileHeaderGuid = goodspriceu.FileHeaderGuid; // GUID
    //        goodspriceuwork.UpdEmployeeCode = goodspriceu.UpdEmployeeCode; // 更新従業員コード
    //        goodspriceuwork.UpdAssemblyId1 = goodspriceu.UpdAssemblyId1; // 更新アセンブリID1
    //        goodspriceuwork.UpdAssemblyId2 = goodspriceu.UpdAssemblyId2; // 更新アセンブリID2
    //        goodspriceuwork.LogicalDeleteCode = goodspriceu.LogicalDeleteCode; // 論理削除区分
    //        goodspriceuwork.GoodsMakerCd = goodspriceu.GoodsMakerCd; // 商品メーカーコード
    //        goodspriceuwork.GoodsNo = goodspriceu.GoodsNo; // 商品番号
    //        goodspriceuwork.PriceStartDate = goodspriceu.PriceStartDate; // 価格開始日
    //        goodspriceuwork.ListPrice = goodspriceu.ListPrice; // 定価（浮動）
    //        goodspriceuwork.SalesUnitCost = goodspriceu.SalesUnitCost; // 原価単価
    //        goodspriceuwork.StockRate = goodspriceu.StockRate; // 仕入率
    //        goodspriceuwork.OpenPriceDiv = goodspriceu.OpenPriceDiv; // オープン価格区分
    //        goodspriceuwork.OfferDate = goodspriceu.OfferDate; // 提供日付
    //        goodspriceuwork.UpdateDate = goodspriceu.UpdateDate; // 更新年月日

    //        return goodspriceuwork;
    //    }

    //    /// <summary>
    //    /// クラスメンバーコピー処理（価格マスタ(ユーザー登録)クラス⇒価格マスタ(ユーザー登録)ワーククラス(リスト)）
    //    /// </summary>
    //    /// <param name="goodspriceu">価格マスタ(ユーザー登録)ワーククラス</param>
    //    /// <returns>価格マスタ(ユーザー登録)クラス</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)クラスから価格マスタ(ユーザー登録)マスタワーククラスへメンバーのコピーを行います。</br>
    //    /// <br>Programmer : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private ArrayList CopyToGoodsPriceUWorkFromGoodsPriceUList(ArrayList goodspriceuList)
    //    {

    //        ArrayList retArray = new ArrayList();

    //        foreach (GoodsPriceU goodspriceu in goodspriceuList)
    //        {
    //            GoodsPriceUWork goodspriceuwork = new GoodsPriceUWork();
    //            goodspriceuwork.CreateDateTime = goodspriceu.CreateDateTime; // 作成日時
    //            goodspriceuwork.UpdateDateTime = goodspriceu.UpdateDateTime; // 更新日時
    //            goodspriceuwork.EnterpriseCode = goodspriceu.EnterpriseCode; // 企業コード
    //            goodspriceuwork.FileHeaderGuid = goodspriceu.FileHeaderGuid; // GUID
    //            goodspriceuwork.UpdEmployeeCode = goodspriceu.UpdEmployeeCode; // 更新従業員コード
    //            goodspriceuwork.UpdAssemblyId1 = goodspriceu.UpdAssemblyId1; // 更新アセンブリID1
    //            goodspriceuwork.UpdAssemblyId2 = goodspriceu.UpdAssemblyId2; // 更新アセンブリID2
    //            goodspriceuwork.LogicalDeleteCode = goodspriceu.LogicalDeleteCode; // 論理削除区分
    //            goodspriceuwork.GoodsMakerCd = goodspriceu.GoodsMakerCd; // 商品メーカーコード
    //            goodspriceuwork.GoodsNo = goodspriceu.GoodsNo; // 商品番号
    //            goodspriceuwork.PriceStartDate = goodspriceu.PriceStartDate; // 価格開始日
    //            goodspriceuwork.ListPrice = goodspriceu.ListPrice; // 定価（浮動）
    //            goodspriceuwork.SalesUnitCost = goodspriceu.SalesUnitCost; // 原価単価
    //            goodspriceuwork.StockRate = goodspriceu.StockRate; // 仕入率
    //            goodspriceuwork.OpenPriceDiv = goodspriceu.OpenPriceDiv; // オープン価格区分
    //            goodspriceuwork.OfferDate = goodspriceu.OfferDate; // 提供日付
    //            goodspriceuwork.UpdateDate = goodspriceu.UpdateDate; // 更新年月日

    //            retArray.Add(goodspriceuwork);                
    //        }

    //        return retArray;
    //    }
        
    //    /// <summary>
    //    /// メモリ生成処理
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)設定アクセスクラスが保持するメモリを生成します。</br>
    //    /// <br>Programer  : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private void MemoryCreate()
    //    {

    //        // 価格マスタ(ユーザー登録)マスタクラスStatic
    //        if (_goodsPriceUList_Stc == null)
    //        {
    //            _goodsPriceUList_Stc = new Hashtable();
    //        }

    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録)クラスワーカークラス(List) → UIクラス変換処理
    //    /// </summary>
    //    /// <param name="goodspriceuWorkList"></param>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)「ワーカークラスをUIの部位部品クラスに変換して、
    //    ///					 Search用Staticメモリに保持します。</br>
    //    /// <br>Programer  : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private void CopyToStaticFromWorker(List<GoodsPriceUWork> goodspriceuWorkList)
    //    {
    //        ArrayList goodspriceuWorkArray = new ArrayList();
    //        goodspriceuWorkArray.AddRange(goodspriceuWorkList);

    //        CopyToStaticFromWorker(goodspriceuWorkArray);
    //    }

    //    /// <summary>
    //    /// 価格マスタ(ユーザー登録)クラスワーカークラス(ArrayList) ⇒ UIクラス変換処理
    //    /// </summary>
    //    /// <param name="goodspriceuWorkList"></param>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタ(ユーザー登録)ワーカークラスをUIの部位部品クラスに変換して、
    //    ///					 Search用Staticメモリに保持します。</br>
    //    /// <br>Programer  : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private void CopyToStaticFromWorker(ArrayList goodspriceuWorkList)
    //    {
    //        foreach (GoodsPriceUWork wkGoodsPriceUWork in goodspriceuWorkList)
    //        {
    //            GoodsPriceU wkGoodsPriceU = new GoodsPriceU();

    //            GoodsUnitData.GoodsPriceKey goodsPriceKey = new GoodsUnitData.GoodsPriceKey(wkGoodsPriceUWork.GoodsNo, wkGoodsPriceUWork.GoodsMakerCd, wkGoodsPriceUWork.PriceStartDate);

    //            wkGoodsPriceU.CreateDateTime = wkGoodsPriceUWork.CreateDateTime; // 作成日時
    //            wkGoodsPriceU.UpdateDateTime = wkGoodsPriceUWork.UpdateDateTime; // 更新日時
    //            wkGoodsPriceU.EnterpriseCode = wkGoodsPriceUWork.EnterpriseCode; // 企業コード
    //            wkGoodsPriceU.FileHeaderGuid = wkGoodsPriceUWork.FileHeaderGuid; // GUID
    //            wkGoodsPriceU.UpdEmployeeCode = wkGoodsPriceUWork.UpdEmployeeCode; // 更新従業員コード
    //            wkGoodsPriceU.UpdAssemblyId1 = wkGoodsPriceUWork.UpdAssemblyId1; // 更新アセンブリID1
    //            wkGoodsPriceU.UpdAssemblyId2 = wkGoodsPriceUWork.UpdAssemblyId2; // 更新アセンブリID2
    //            wkGoodsPriceU.LogicalDeleteCode = wkGoodsPriceUWork.LogicalDeleteCode; // 論理削除区分
    //            wkGoodsPriceU.GoodsMakerCd = wkGoodsPriceUWork.GoodsMakerCd; // 商品メーカーコード
    //            wkGoodsPriceU.GoodsNo = wkGoodsPriceUWork.GoodsNo; // 商品番号
    //            wkGoodsPriceU.PriceStartDate = wkGoodsPriceUWork.PriceStartDate; // 価格開始日
    //            wkGoodsPriceU.ListPrice = wkGoodsPriceUWork.ListPrice; // 定価（浮動）
    //            wkGoodsPriceU.SalesUnitCost = wkGoodsPriceUWork.SalesUnitCost; // 原価単価
    //            wkGoodsPriceU.StockRate = wkGoodsPriceUWork.StockRate; // 仕入率
    //            wkGoodsPriceU.OpenPriceDiv = wkGoodsPriceUWork.OpenPriceDiv; // オープン価格区分
    //            wkGoodsPriceU.OfferDate = wkGoodsPriceUWork.OfferDate; // 提供日付
    //            wkGoodsPriceU.UpdateDate = wkGoodsPriceUWork.UpdateDate; // 更新年月日

    //            _goodsPriceUList_Stc[goodsPriceKey] = wkGoodsPriceU;
    //        }
    //    }

    //    /// <summary>
    //    /// ローカルファイル読込み処理
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note       : ローカルファイルを読込んで、情報をStaticに保持します。</br>
    //    /// <br>Programer  : 20056 對馬 大輔</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private void SearchOfflineData()
    //    {
    //        // オフラインシリアライズデータ作成部品I/O
    //        OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

    //        // --- Search用 --- //
    //        // KeyList設定
    //        string[] goodspriceuKeys = new string[1];
    //        goodspriceuKeys[0] = LoginInfoAcquisition.EnterpriseCode;
    //        // ローカルファイル読込み処理
    //        object wkObj = offlineDataSerializer.DeSerialize("GoddsPriceUAcs", goodspriceuKeys);
    //        // ArrayListにセット
    //        List<GoodsPriceUWork> wkList = new List<GoodsPriceUWork>();

    //        if ((wkList != null) &&
    //            (wkList.Count != 0))
    //        {
    //            // 価格マスタ(ユーザー登録)クラスワーカークラス（ArrayList） ⇒ UIクラス（Static）変換処理
    //            CopyToStaticFromWorker(wkList);
    //        }
    //    }
    //    #endregion

    //    #region ■Public Const
    //    public const Int32 USERGDBD_PRICEDIVCD = 47; // 価格区分
    //    public const Int32 USERGDBD_UNITCODE = 45; // 単位コード
    //    public const Int32 USERGDBD_ENTERPRISEGANRECODE = 41; // 自社分類コード
    //    #endregion

    //}
}
