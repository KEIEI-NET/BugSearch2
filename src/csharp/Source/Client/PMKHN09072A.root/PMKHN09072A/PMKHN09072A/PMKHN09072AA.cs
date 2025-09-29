using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品中分類マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 商品中分類マスタのアクセス制御を行います。
    ///					  IGeneralGuideDataを実装しています。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/06/11</br>
    /// </remarks>
    public class GoodsGroupUAcs : IGeneralGuideData
    {
        #region Constants

        //データ区分
        private const int DIVISION_USR = 0;
        private const int DIVISION_OFR = 1;
        private const string DIVISIONNAME_USR = "ユーザーデータ";
        private const string DIVISIONNAME_OFR = "提供データ";

        #endregion Constants

        #region Private Members

        /// <summary>リモートオブジェクト格納バッファ</summary>
        IGoodsGroupUDB _iGoodsGroupUDB = null;
        IGoodsMGroupDB _iGoodsMGroupDB = null;

        // キャッシュ用ハッシュテーブル
        private static Hashtable _goodsGroupUTable = null;

        #endregion Private Members

        # region Constructor

        /// <summary>
        /// 商品中分類テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品中分類テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public GoodsGroupUAcs()
        {
            _goodsGroupUTable = null;

            try
            {
                // リモートオブジェクト取得
                this._iGoodsGroupUDB = (IGoodsGroupUDB)MediationGoodsGroupUDB.GetGoodsGroupUDB();
                this._iGoodsMGroupDB = (IGoodsMGroupDB)MediationGoodsMGroupDB.GetGoodsMGroupDB();

            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iGoodsGroupUDB = null;
                this._iGoodsMGroupDB = null;
            }
        }

        # endregion

        #region Public Methods

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if ((this._iGoodsGroupUDB == null) || (this._iGoodsMGroupDB == null))
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// 商品中分類コード全件読み込み処理(論理削除含む)
        /// </summary>
        /// <param name="retList">参照結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品中分類コード情報を読み込みます。<br/>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            _goodsGroupUTable = new Hashtable();

            // ユーザーデータ
            status = SearchGoodsGroupUser(ref retList, enterpriseCode, 0);

            // 提供データ
            //status = SearchGoodsGroupOffer(ref retList, 0);

            return 0;
        }

        /// <summary>
        /// マスタ検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 取得結果をDataSetで返します。</br>
        /// <br>Programmer  : 30414 忍　幸史</br>
        /// <br>Date	    : 2008/06/11</br>
        /// </remarks>
        public int Search(ref DataSet dataSet, string enterpriseCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // マスタサーチ
            status = SearchAll(out retList, enterpriseCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList wkList = retList.Clone() as ArrayList;
            SortedList wkSort = new SortedList();

            // --- [全て] --- //
            // そのまま全件返す
            foreach (GoodsGroupU goodsGroupU in wkList)
            {
                if (goodsGroupU.LogicalDeleteCode == 0)
                {
                    wkSort.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                }
            }

            GoodsGroupU[] aryGoodsGroupU = new GoodsGroupU[wkSort.Count];

            // データを元に戻す
            for (int i = 0; i < wkSort.Count; i++)
            {
                aryGoodsGroupU[i] = (GoodsGroupU)wkSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(aryGoodsGroupU);
            XmlByteSerializer.ReadXml(ref dataSet, retbyte);

            return status;
        }

        /// <summary>
        /// 商品中分類データ検索処理
        /// </summary>
        /// <param name="goodsGroupU">商品中分類オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsGroupUCode">商品中分類コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品中分類データを検索します。<br/>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int Search(out GoodsGroupU goodsGroupU, string enterpriseCode, int goodsGroupUCode)
        {
            int status;
            goodsGroupU = new GoodsGroupU();
            _goodsGroupUTable = new Hashtable();
            ArrayList retList = new ArrayList();

            // ユーザーデータ
            status = SearchGoodsGroupUser(ref retList, enterpriseCode, goodsGroupUCode);

            // 提供データ
            //status = SearchGoodsGroupOffer(ref retList, goodsGroupUCode);

            if ((retList == null) || (retList.Count == 0))
            {
                return 9;
            }
            else
            {
                goodsGroupU = (GoodsGroupU)retList[0];
                return 0;
            }
        }

        /// <summary>
        /// 商品中分類マスタ登録・更新処理
        /// </summary>
        /// <param name="goodsGroupU">商品中分類マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品中分類マスタ情報の登録・更新を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int Write(ref GoodsGroupU goodsGroupU)
        {
            // ------------------------------------------------------
            // 登録はユーザー登録分しかありえない
            // ------------------------------------------------------

            int status = 0;

            try
            {
                // クラスメンバーコピー処理(Ｅクラス→Ｄクラス(ユーザー))
                GoodsGroupUWork goodsGroupUWork = CopyToGoodsGroupUWorkFromGoodsGroupU(goodsGroupU);
                ArrayList paraList = new ArrayList();
                paraList.Add(goodsGroupUWork);

                object paraobj = paraList;

                // 商品中分類マスタ書き込み
                status = this._iGoodsGroupUDB.Write(ref paraobj);
                if (status == 0)
                {
                    ArrayList retList = new ArrayList();
                    retList = (ArrayList)paraobj;

                    goodsGroupUWork = (GoodsGroupUWork)retList[0];

                    // クラスメンバーコピー処理(Ｄクラス(ユーザー)→Ｅクラス)
                    goodsGroupU = CopyToGoodsGroupUFromGoodsGroupUWork(goodsGroupUWork);
                }
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iGoodsGroupUDB = null;

                //通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 商品中分類マスタ物理削除処理
        /// </summary>
        /// <param name="goodsGroupU">商品中分類マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品中分類マスタの物理削除を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int Delete(GoodsGroupU goodsGroupU)
        {
            // ------------------------------------------------------
            // 物理削除はユーザー登録分しかありえない
            // ------------------------------------------------------

            int status = 0;

            try
            {
                // クラスメンバーコピー処理(Ｅクラス→Ｄクラス(ユーザー))
                GoodsGroupUWork goodsGroupUWork = CopyToGoodsGroupUWorkFromGoodsGroupU(goodsGroupU);
                ArrayList paraList = new ArrayList();
                paraList.Add(goodsGroupUWork);

                object paraObj = paraList;

                // 商品中分類マスタ物理削除
                status = this._iGoodsGroupUDB.Delete(paraObj);
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iGoodsGroupUDB = null;

                //通信エラーは-1を戻す
                return -1;
            }

            return status;
        }

        /// <summary>
        /// 商品中分類マスタ論理削除処理
        /// </summary>
        /// <param name="goodsGroupU">商品中分類マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品中分類マスタの論理削除を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int LogicalDelete(ref GoodsGroupU goodsGroupU)
        {
            // ------------------------------------------------------
            // 論理削除はユーザー登録分しかありえない
            // ------------------------------------------------------

            int status = 0;

            try
            {
                // クラスメンバーコピー処理(Ｅクラス→Ｄクラス(ユーザー))
                GoodsGroupUWork goodsGroupUWork = CopyToGoodsGroupUWorkFromGoodsGroupU(goodsGroupU);
                ArrayList paraList = new ArrayList();
                paraList.Add(goodsGroupUWork);

                object paraObj = paraList;

                // 商品中分類マスタ論理削除
                status = this._iGoodsGroupUDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    ArrayList retList = new ArrayList();
                    retList = (ArrayList)paraObj;

                    goodsGroupUWork = (GoodsGroupUWork)retList[0];

                    // クラスメンバーコピー処理(Ｄクラス(ユーザー)→Ｅクラス)
                    goodsGroupU = CopyToGoodsGroupUFromGoodsGroupUWork(goodsGroupUWork);
                }
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iGoodsGroupUDB = null;

                //通信エラーは-1を戻す
                return -1;
            }

            return status;
        }

        /// <summary>
        /// 商品中分類マスタ復活処理
        /// </summary>
        /// <param name="goodsGroupU">商品中分類マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品中分類マスタの復活を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int Revival(ref GoodsGroupU goodsGroupU)
        {
            // ------------------------------------------------------
            // 論理削除復活はユーザー登録分しかありえない
            // ------------------------------------------------------

            int status = 0;

            try
            {
                // クラスメンバーコピー処理(Ｅクラス→Ｄクラス(ユーザー))
                GoodsGroupUWork goodsGroupUWork = CopyToGoodsGroupUWorkFromGoodsGroupU(goodsGroupU);
                ArrayList paraList = new ArrayList();
                paraList.Add(goodsGroupUWork);

                object paraObj = paraList;

                // 復活処理
                status = this._iGoodsGroupUDB.RevivalLogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = new ArrayList();
                    retList = (ArrayList)paraObj;

                    goodsGroupUWork = (GoodsGroupUWork)retList[0];

                    // クラスメンバーコピー処理(Ｄクラス(ユーザー)→Ｅクラス)
                    goodsGroupU = CopyToGoodsGroupUFromGoodsGroupUWork(goodsGroupUWork);
                }
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iGoodsGroupUDB = null;

                //通信エラーは-1を戻す
                return -1;
            }

            return status;
        }

        /// <summary>
        /// 商品中分類ガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsGroupU">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: BL商品コードマスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date	    : 2008/06/11</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out GoodsGroupU goodsGroupU)
        {
            int status = ExecuteGuid(enterpriseCode, "GOODSMGROUPGUIDEPARENT.XML", out goodsGroupU);

            return status;
        }

        /// <summary>
        /// 商品中分類ガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsGroupU">取得データ</param>
        /// <param name="dispGoodsMGroup">商品中分類表示ガイドフラグ(True:商品中分類ガイド　False:商品掛率ｸﾞﾙｰﾌﾟガイド)</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: BL商品コードマスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date	    : 2008/06/11</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out GoodsGroupU goodsGroupU, bool dispGoodsMGroup)
        {
            string guideFileName;

            if (dispGoodsMGroup == true)
            {
                // 商品中分類ガイドを表示
                guideFileName = "GOODSMGROUPGUIDEPARENT.XML";
            }
            else
            {
                // 商品掛率グループガイドを表示
                guideFileName = "GOODSGROUPGUIDEPARENT.XML";
            }

            int status = ExecuteGuid(enterpriseCode, guideFileName, out goodsGroupU);

            return status;
        }

        /// <summary>
        /// 商品中分類ガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="guideFileName">ガイドXML名</param>
        /// <param name="goodsGroupU">取得データ</param>
        /// <returns></returns>
        private int ExecuteGuid(string enterpriseCode, string guideFileName, out GoodsGroupU goodsGroupU)
        {
            int status = -1;
            goodsGroupU = new GoodsGroupU();

            TableGuideParent tableGuideParent = new TableGuideParent(guideFileName);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                string strCode;

                // 商品中分類コード
                strCode = retObj["GoodsMGroup"].ToString();
                goodsGroupU.GoodsMGroup = int.Parse(strCode);

                // 商品中分類名称
                goodsGroupU.GoodsMGroupName = retObj["GoodsMGroupName"].ToString();

                // データ区分コード
                strCode = retObj["DivisionCode"].ToString();
                goodsGroupU.DivisionCode = int.Parse(strCode);

                // データ区分名称
                goodsGroupU.DivisionName = retObj["DivisionName"].ToString();

                status = 0;
            }
            // キャンセル
            else
            {
                status = 1;
            }

            return (status);
        }

        /// <summary>
        /// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note		: 汎用ガイド設定用データを取得します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date	    : 2008/06/11</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet dataSet)
        {
            int status = -1;
            string enterpriseCode = "";

            // 企業コード設定有り
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            // 企業コード設定無し
            else
            {
                // 有り得ないのでエラー
                return status;
            }

            // マスタテーブル読込み
            status = Search(ref dataSet, enterpriseCode);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    status = -1;
                    break;
            }

            return status;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// 商品中分類コード(ユーザーデータ)全件読み込み処理(論理削除含む)
        /// </summary>
        /// <param name="retList">参照結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsGroupUCode">商品中分類コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品中分類コード(ユーザーデータ)を読み込みます。<br/>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        private int SearchGoodsGroupUser(ref ArrayList retList, string enterpriseCode, int goodsGroupCode)
        {
            // 初期化処理
            int status = 0;
            int hashKey;

            // 条件抽出クラス(D)の設定
            GoodsGroupUWork goodsGroupUWork = new GoodsGroupUWork();
            goodsGroupUWork.EnterpriseCode = enterpriseCode;
            goodsGroupUWork.GoodsMGroup = goodsGroupCode;

            ArrayList paraList = new ArrayList();
            object paraobj = goodsGroupUWork;
            object retobj = paraList;

            // リモートオブジェクトの呼び出し
            status = this._iGoodsGroupUDB.Search(ref retobj, paraobj, 0, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    paraList = retobj as ArrayList;

                    if (paraList == null)
                    {
                        return status;
                    }

                    foreach (GoodsGroupUWork wkgoodsGroupUWork in paraList)
                    {
                        // 商品中分類コード
                        hashKey = wkgoodsGroupUWork.GoodsMGroup;

                        if (_goodsGroupUTable[hashKey] != null)
                        {
                            continue;
                        }

                        // クラスメンバーコピー処理(Ｄクラス(ユーザー)→Ｅクラス)
                        GoodsGroupU goodsGroupU = CopyToGoodsGroupUFromGoodsGroupUWork(wkgoodsGroupUWork);
                        retList.Add(goodsGroupU);

                        // static保持
                        _goodsGroupUTable[hashKey] = goodsGroupU;
                    }

                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    return status;
            }

            return status;
        }

        ///// <summary>
        ///// 商品中分類コード(提供データ)全件読み込み処理(論理削除含む)
        ///// </summary>
        ///// <param name="retList">参照結果リスト</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="goodsGroupUCode">商品中分類コード</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 商品中分類コード(提供データ)を読み込みます。<br/>
        ///// <br>Programmer : 30414 忍　幸史</br>
        ///// <br>Date	   : 2008/06/11</br>
        ///// </remarks>
        //private int SearchGoodsGroupOffer(ref ArrayList retList, int goodsGroupCode)
        //{
        //    // 初期化処理
        //    int status = 0;
        //    int hashKey;

        //    // 条件抽出クラス(D)の設定
        //    GoodsMGroupWork goodsMGroupWork = new GoodsMGroupWork();
        //    goodsMGroupWork.GoodsMGroup = goodsGroupCode;

        //    ArrayList paraList = new ArrayList();
        //    object paraobj = goodsMGroupWork;
        //    object retobj = paraList;

        //    // リモートオブジェクトの呼び出し
        //    status = this._iGoodsMGroupDB.Search(out retobj, paraobj);
        //    switch (status)
        //    {
        //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //            paraList = retobj as ArrayList;

        //            if (paraList == null)
        //            {
        //                return status;
        //            }

        //            foreach (GoodsMGroupWork wkGoodsGroupWork in paraList)
        //            {
        //                // 商品中分類コード取得
        //                hashKey = wkGoodsGroupWork.GoodsMGroup;

        //                if (_goodsGroupUTable[hashKey] != null)
        //                {
        //                    continue;
        //                }

        //                // クラスメンバーコピー処理(Ｄクラス(提供)→Ｅクラス)
        //                GoodsGroupU goodsGroupU = CopyToGoodsGroupUFromGoodsGroupWork(wkGoodsGroupWork);
        //                retList.Add(goodsGroupU);

        //                // static保持
        //                _goodsGroupUTable[hashKey] = goodsGroupU;
        //            }

        //            break;
        //        case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //            break;
        //        default:
        //            return status;
        //    }

        //    return status;
        //}

        /// <summary>
        /// クラスメンバーコピー処理（商品中分類マスタクラス(E)⇒ユーザー商品中分類マスタワーククラス(D)）
        /// </summary>
        /// <param name="goodsGroupU">商品中分類マスタクラス</param>
        /// <returns>商品中分類マスタワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 商品中分類マスタクラスから商品中分類マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        private GoodsGroupUWork CopyToGoodsGroupUWorkFromGoodsGroupU(GoodsGroupU goodsGroupU)
        {
            GoodsGroupUWork goodsGroupUWork = new GoodsGroupUWork();

            goodsGroupUWork.EnterpriseCode = goodsGroupU.EnterpriseCode;        // 企業コード
            goodsGroupUWork.CreateDateTime = goodsGroupU.CreateDateTime;        // 作成日時
            goodsGroupUWork.UpdateDateTime = goodsGroupU.UpdateDateTime;        // 更新日時
            goodsGroupUWork.FileHeaderGuid = goodsGroupU.FileHeaderGuid;        // GUID
            goodsGroupUWork.UpdEmployeeCode = goodsGroupU.UpdEmployeeCode;      // 更新従業員コード
            goodsGroupUWork.UpdAssemblyId1 = goodsGroupU.UpdAssemblyId1;        // 更新アセンブリID1
            goodsGroupUWork.UpdAssemblyId2 = goodsGroupU.UpdAssemblyId2;        // 更新アセンブリID2
            goodsGroupUWork.LogicalDeleteCode = goodsGroupU.LogicalDeleteCode;  // 論理削除区分

            goodsGroupUWork.GoodsMGroup = goodsGroupU.GoodsMGroup;              // 商品中分類コード
            goodsGroupUWork.GoodsMGroupName = goodsGroupU.GoodsMGroupName;      // 商品中分類名称
            goodsGroupUWork.OfferDate = goodsGroupU.OfferDate;                  // 提供日付
            goodsGroupUWork.OfferDataDiv = goodsGroupU.OfferDataDiv;            // 提供データ区分
            
            return goodsGroupUWork;
        }

        /// <summary>
        /// クラスメンバーコピー処理（ユーザー商品中分類マスタワーククラス(D)⇒商品中分類マスタクラス(E)）
        /// </summary>
        /// <param name="goodsGroupUWork">商品中分類マスタワーククラス</param>
        /// <returns>商品中分類マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 商品中分類マスタワーククラスから商品中分類マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        private GoodsGroupU CopyToGoodsGroupUFromGoodsGroupUWork(GoodsGroupUWork goodsGroupUWork)
        {
            GoodsGroupU goodsGroupU = new GoodsGroupU();

            goodsGroupU.EnterpriseCode = goodsGroupUWork.EnterpriseCode;        // 企業コード
            goodsGroupU.CreateDateTime = goodsGroupUWork.CreateDateTime;        // 作成日時
            goodsGroupU.UpdateDateTime = goodsGroupUWork.UpdateDateTime;        // 更新日時
            goodsGroupU.FileHeaderGuid = goodsGroupUWork.FileHeaderGuid;        // GUID
            goodsGroupU.UpdEmployeeCode = goodsGroupUWork.UpdEmployeeCode;      // 更新従業員コード
            goodsGroupU.UpdAssemblyId1 = goodsGroupUWork.UpdAssemblyId1;        // 更新アセンブリID1
            goodsGroupU.UpdAssemblyId2 = goodsGroupUWork.UpdAssemblyId2;        // 更新アセンブリID2
            goodsGroupU.LogicalDeleteCode = goodsGroupUWork.LogicalDeleteCode;  // 論理削除区分

            goodsGroupU.GoodsMGroup = goodsGroupUWork.GoodsMGroup;              // 商品中分類コード
            goodsGroupU.GoodsMGroupName = goodsGroupUWork.GoodsMGroupName;      // 商品中分類名称
            goodsGroupU.OfferDate = goodsGroupUWork.OfferDate;                  // 提供日付
            goodsGroupU.OfferDataDiv = goodsGroupUWork.OfferDataDiv;            // 提供データ区分

            if (goodsGroupU.OfferDate == DateTime.MinValue)
            {
                goodsGroupU.DivisionCode = DIVISION_USR;                         
                goodsGroupU.DivisionName = DIVISIONNAME_USR;                   
            }
            else
            {
                goodsGroupU.DivisionCode = DIVISION_OFR;
                goodsGroupU.DivisionName = DIVISIONNAME_OFR;
            }

            return goodsGroupU;
        }

        ///// <summary>
        ///// クラスメンバーコピー処理（提供商品中分類マスタワーククラス(D)⇒商品中分類マスタクラス(E)）
        ///// </summary>
        ///// <param name="goodsMGroupWork">商品中分類マスタワーククラス</param>
        ///// <returns>商品中分類マスタクラス</returns>
        ///// <remarks>
        ///// <br>Note       : 商品中分類マスタワーククラスから商品中分類マスタクラスへメンバーのコピーを行います。</br>
        ///// <br>Programmer : 30414 忍　幸史</br>
        ///// <br>Date	   : 2008/06/11</br>
        ///// </remarks>
        //private GoodsGroupU CopyToGoodsGroupUFromGoodsGroupWork(GoodsMGroupWork goodsMGroupWork)
        //{
        //    GoodsGroupU goodsGroupU = new GoodsGroupU();

        //    goodsGroupU.GoodsMGroup = goodsMGroupWork.GoodsMGroup;              // 商品中分類コード
        //    goodsGroupU.GoodsMGroupName = goodsMGroupWork.GoodsMGroupName;      // 商品中分類名称
        //    goodsGroupU.DivisionCode = DIVISION_OFR;                            // データ区分
        //    goodsGroupU.DivisionName = DIVISIONNAME_OFR;                        // データ区分名称

        //    return goodsGroupU;
        //}

        #endregion Private Methods
    }
}
