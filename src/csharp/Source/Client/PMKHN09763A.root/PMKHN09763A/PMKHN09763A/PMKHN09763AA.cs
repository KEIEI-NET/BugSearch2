using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 品番変換マスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 品番変換の設定を行います。</br>
    /// <br>Programmer : 陳永康</br>
    /// <br>Date       : 2014/12/23</br>
    /// </remarks>
    public class GoodsNoChangeAcs
    {
        #region ◆Public Members

        /// <summary>画面表示データテーブル格納データセットクラス</summary>
        public DataSet GoodsNoChangeDataSet;

        #region ●DataTable用名称情報
        /// <summary>データテーブルカラム名称(G
        /// UID)</summary>
        public static readonly string FILEHEADERGUID_TITLE = "Guid";
        /// <summary>データテーブルカラム名称(削除日)</summary>
        public static readonly string DELETE_DATE = "削除日";
        /// <summary>データテーブルカラム名称(論理削除区分)</summary>
        public static readonly string LOGICALDELETE_TITLE = "論理削除区分";
        /// <summary>データテーブルカラム名称(商品メーカーコード)</summary>
        public static readonly string GOODSMAKERCD_TITLE = "商品メーカーコード";
        /// <summary>データテーブルカラム名称(メーカー名称)</summary>
        public static readonly string MAKERNAME_TITLE = "メーカー名称";
        /// <summary>データテーブルカラム名称(旧商品番号)</summary>
        public static readonly string OLDGOODSNO_TITLE = "旧品番";
        /// <summary>データテーブルカラム名称(新商品番号)</summary>
        public static readonly string NEWGOODSNO_TITLE = "新品番";

        /// <summary>データテーブル名称</summary>
        public static readonly string GOODSMNG_TABLE = "GoodsNoChange_Table";
        #endregion

        #endregion


        #region ◆Private Members

        #region ●Static Members
        /// <summary>品番変換マスタクラスSearchフラグ</summary>
        private static bool _searchFlg = false;
        #endregion

        #region ●Const
        /// <summary>削除日表示形式</summary>
        private const string DATATIME_FORM = "ggYY/MM/DD";
        /// <summary>ガイド用XMLのファイル名</summary>
        private const string GUIDEXML_TITLE = "GOODSSETGUIDEPARENT.XML";
        // 旧商品番号
        private const string OLDGOODSNO_COLUMN = "OldGoodsNoRF";
        // 新商品番号
        private const string NEWGOODSNO_COLUMN = "NewGoodsNoRF";
        // 商品メーカーコード
        private const string GOODSMAKERCD_COLUMN = "GoodsMakerCdRF";
        //エラーメッセージ
        private const string GOODS_ERROR = "GoodsErrorRF";
        // テーブル名称
        private const string PRINTSET_TABLE = "GoodsNoChangeErr";
        #endregion

        #region ●Normal Members

        /// <summary>品番変換リモートオブジェクト格納バッファ</summary>
        private IGoodsNoChangeDB _iGoodsNoChangeDB = null;

        #endregion

        #endregion

        #region ◆Constructor

        /// <summary>
        /// 品番変換アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note           : 品番変換取得のためのリモートオブジェクトを記述します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public GoodsNoChangeAcs()
        {
            try
            {
                // 品番変換マスタリモートオブジェクト取得
                this._iGoodsNoChangeDB = (IGoodsNoChangeDB)MediationGoodsNoChangeDB.GetGoodsNoChangeDB();
            }
            catch (Exception)
            {
                this._iGoodsNoChangeDB = null;
            }
        }

        #endregion

        #region ◆Public Methods

        /// <summary>オンラインモードの列挙型です。</summary>
        public enum OnlineMode
        {
            /// <summary>オフライン</summary>
            Offline,
            /// <summary>オンライン</summary>
            Online
        }

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (LoginInfoAcquisition.OnlineFlag)
            {
                return (int)OnlineMode.Online;
            }
            else
            {
                return (int)OnlineMode.Offline;
            }
        }

        /// <summary>
        /// 品番変換全件読み込み処理(論理削除含む)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// /// <param name="retList">参照結果リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 品番変換情報を読み込みます。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int SearchAll(string enterpriseCode, out ArrayList retList)
        {
            int status = -1;
            bool nextData;
            int retTotalCnt = 0;
            retList = new ArrayList();
            retList.Clear();

            #region < 検索処理 >
            status = SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode,
                                                ConstantManagement.LogicalMode.GetDataAll, 0, null);
            #endregion

            #region < 検索後処理 >
            if (status == 0)
            {
                ArrayList paraList = new ArrayList();

                foreach (object retobj in retList)
                {
                    GoodsNoChange goodsNoChange = this.CopyToGoodsNoChangeFromGoodsNoChangeWork(retobj);

                    paraList.Add(goodsNoChange);
                }
                retList = paraList;
            }
            #endregion

            return status;
        }

        /// <summary>
        /// 品番変換読み込み処理(リモーティング)
        /// </summary>
        /// <param name="retGoodsNoChangeList">品番変換該当データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsNoChangeCode">商品コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 品番変換を読み込みます。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int ReadWithGoodsSet(out List<GoodsNoChange> retGoodsNoChangeList, string enterpriseCode, int goodsNoChangeCode)
        {
            int status = -1;
            retGoodsNoChangeList = new List<GoodsNoChange>();     // 品番変換データリスト
            GoodsNoChange goodsNoChange = new GoodsNoChange();

            // キャッシュ or リモーティングよりデータを取得しデータテーブルを作成します
            status = this.GetGoodsNoChangeData(enterpriseCode);

            #region ●検索後処理
            switch (status)
            {
                #region -- 正常終了 --
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 該当データ取得処理
                        this.GetGoodsNoChangeDataList(ref retGoodsNoChangeList, goodsNoChangeCode);
                        break;
                    }
                #endregion

                #region -- データ無し --
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                #endregion

                #region -- 検索失敗 --
                default:
                    {
                        status = -1;
                        break;
                    }
                #endregion
            }
            #endregion

            return status;
        }

        /// <summary>
        /// 品番変換登録・更新処理
        /// </summary>
        /// <param name="goodsNoChange">品番変換データクラス</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>
        /// <br>Note       : 品番変換の登録・更新を行います。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int Write(ref GoodsNoChange goodsNoChange)
        {
            int status = -1;

            try
            {
                #region < 登録データ準備処理 >
                GoodsNoChangeWork goodsNoChangeWork = new GoodsNoChangeWork();
                ArrayList paraList = new ArrayList();

                //品番変換ワーククラスへのデータ格納処理
                goodsNoChangeWork = this.CopyToGoodsNoChangeWorkFromGoodsNoChange(goodsNoChange);

                object paraobj = goodsNoChangeWork;
                #endregion

                #region < 登録処理 >
                // 品番変換書き込み(｢A｣→｢O｣へ接続)
                status = this._iGoodsNoChangeDB.Write(ref paraobj);
                #endregion

                #region < 登録後処理 >
                if (status == 0)
                {
                    #region < 登録データ反映処理 >

                    // クラス内メンバコピー
                    goodsNoChange = this.CopyToGoodsNoChangeFromGoodsNoChangeWork(paraobj);

                    #endregion

                    status = 0;
                }
                #endregion

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iGoodsNoChangeDB = null;
                //通信エラーは-1を戻す
                status = -1;
                return status;
            }
        }

        /// <summary>
        /// 品番変換論理削除処理
        /// </summary>
        /// <param name="goodsNoChange">品番変換データクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 品番変換論理削除を行います。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int LogicalDelete(ref GoodsNoChange goodsNoChange)
        {
            int status = 0;

            try
            {
                GoodsNoChangeWork goodsNoChangeWork = new GoodsNoChangeWork();
                ArrayList paraList = new ArrayList();

                #region < 論理削除データ準備処理 >
                //品番変換ワーククラスへのデータ格納処理
                goodsNoChangeWork = this.CopyToGoodsNoChangeWorkFromGoodsNoChange(goodsNoChange);
                paraList.Add(goodsNoChangeWork);
                object paraObj = paraList;
                #endregion

                #region < 論理削除処理 >
                status = this._iGoodsNoChangeDB.LogicalDelete(ref paraObj);
                #endregion

                if (status == 0)
                {
                    #region < 論理削除データ反映処理 >
                    // 画面表示用データテーブルに削除日を表示する
                    ArrayList retList = (ArrayList)paraObj;

                    // クラス内メンバコピー
                    goodsNoChange = this.CopyToGoodsNoChangeFromGoodsNoChangeWork((GoodsNoChangeWork)retList[0]);

                    #endregion

                    status = 0;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                }
                else
                {
                    status = -1;
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iGoodsNoChangeDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 品番変換物理削除処理
        /// </summary>
        /// <param name="goodsNoChange">品番変換データクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 品番変換物理削除を行います。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int Delete(GoodsNoChange goodsNoChange)
        {
            int status;

            try
            {
                #region < 物理削除データ準備処理 >
                GoodsNoChangeWork goodsNoChangeWork;
                //品番変換ワーククラスへのデータ格納処理
                goodsNoChangeWork = this.CopyToGoodsNoChangeWorkFromGoodsNoChange(goodsNoChange);
                #endregion

                #region < XML シリアライズ >
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(goodsNoChangeWork);
                #endregion

                #region < 物理削除処理 >
                status = this._iGoodsNoChangeDB.Delete(parabyte);
                #endregion

                #region < 物理削除後処理 >
                if (status == 0)
                {
                    #region -- 正常終了 --
                    #endregion

                    status = 0;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                }
                else
                {
                    //サーバーエラーは-1を戻す
                    status = -1;
                }
                #endregion

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iGoodsNoChangeDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 品番変換論理削除復活処理
        /// </summary>
        /// <param name="goodsNoChange">品番変換データクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 品番変換の復活を行います。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int Revival(ref GoodsNoChange goodsNoChange)
        {
            int status = 0;
            try
            {
                #region < 復活データ準備処理 >
                GoodsNoChangeWork goodsNoChangeWork = new GoodsNoChangeWork();
                ArrayList paraList = new ArrayList();

                //品番変換ワーククラスへのデータ格納処理
                goodsNoChangeWork = this.CopyToGoodsNoChangeWorkFromGoodsNoChange(goodsNoChange);
                paraList.Add(goodsNoChangeWork);
                object paraobj = paraList;
                #endregion

                #region < 復活処理 >
                status = this._iGoodsNoChangeDB.RevivalLogicalDelete(ref paraobj);
                #endregion

                #region < 復活後処理 >
                if (status == 0)
                {
                    #region -- 復活データ反映処理 --
                    ArrayList retList = (ArrayList)paraobj;

                    // クラス内メンバコピー
                    goodsNoChange = this.CopyToGoodsNoChangeFromGoodsNoChangeWork((GoodsNoChangeWork)retList[0]);
                    #endregion

                    status = 0;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                }
                else
                {
                    status = -1;
                }
                #endregion

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iGoodsNoChangeDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 品番変換マスタデータ取得処理(リモーティング)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 品番変換マスタデータをキャッシュ or リモーティングにより取得します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int GetGoodsNoChangeData(string enterpriseCode)
        {
            int status = -1;

            #region ●テーブル作成
            if (_searchFlg == false)
            {
                #region < リモーティング取得 >
                ArrayList retList;
                int retTotalCnt;
                bool nextData;

                // 全検索
                status = this.SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode,
                                                        ConstantManagement.LogicalMode.GetDataAll, 0, null);
                #endregion
            }
            #endregion

            return status;
        }

        #endregion

        #region ◆Private Methods

        /// <summary>
        /// 品番変換検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevMakerがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevGoodsNoChange">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 品番変換の検索処理を行います。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, GoodsNoChange prevGoodsNoChange)
        {
            GoodsNoChangeWork goodsNoChangeWork = new GoodsNoChangeWork();
            goodsNoChangeWork.EnterpriseCode = enterpriseCode;

            int status = 0;
            nextData = false;
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            object paraobj = goodsNoChangeWork;
            object retobj = null;

            // 品番変換検索
            if (readCnt == 0)
            {
                status = this._iGoodsNoChangeDB.Search(out retobj, paraobj, 0, logicalMode);
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    retList = retobj as ArrayList;
                    break;

                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;

                default:
                    return status;
            }

            //全件リードの場合は戻り値の件数をセット
            if (readCnt == 0) retTotalCnt = retList.Count;

            // SearchFlg ON
            _searchFlg = true;

            return status;
        }

        /// <summary>
        /// 品番変換データクラス → 品番変換データワーククラス
        /// </summary>
        /// <param name="goodsNoChange">品番変換データクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 品番変換の復活を行います。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private GoodsNoChangeWork CopyToGoodsNoChangeWorkFromGoodsNoChange(GoodsNoChange goodsNoChange)
        {
            GoodsNoChangeWork goodsNoChangeWork = new GoodsNoChangeWork();

            goodsNoChangeWork.CreateDateTime = goodsNoChange.CreateDateTime;
            goodsNoChangeWork.UpdateDateTime = goodsNoChange.UpdateDateTime;
            goodsNoChangeWork.EnterpriseCode = goodsNoChange.EnterpriseCode;
            goodsNoChangeWork.FileHeaderGuid = goodsNoChange.FileHeaderGuid;
            goodsNoChangeWork.UpdAssemblyId1 = goodsNoChange.UpdAssemblyId1;
            goodsNoChangeWork.UpdAssemblyId2 = goodsNoChange.UpdAssemblyId2;
            goodsNoChangeWork.UpdEmployeeCode = goodsNoChange.UpdEmployeeCode;
            goodsNoChangeWork.LogicalDeleteCode = goodsNoChange.LogicalDeleteCode;

            goodsNoChangeWork.GoodsMakerCd = goodsNoChange.GoodsMakerCd;　　// 商品メーカーコード
            goodsNoChangeWork.OldGoodsNo = goodsNoChange.OldGoodsNo;        // 旧商品コード
            goodsNoChangeWork.NewGoodsNo = goodsNoChange.NewGoodsNo;        // 新商品コード

            return goodsNoChangeWork;
        }

        /// <summary>
        /// Read該当データリスト取得処理
        /// </summary>
        /// <param name="goodsNoChangeList">品番変換データクラスリスト</param>
        /// <param name="BLGoodsCode">検索キー</param>
        /// <remarks>
        /// <br>Note		: キャッシュから品番変換名称を取得します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void GetGoodsNoChangeDataList(ref List<GoodsNoChange> goodsNoChangeList, int BLGoodsCode)
        {
            GoodsNoChange goodsNoChange = new GoodsNoChange();

            #region ●該当データリスト作成
            GoodsAcs goodsAcs = new GoodsAcs();

            #region < 商品情報取得 >
            goodsNoChange.FileHeaderGuid = (Guid)this.GoodsNoChangeDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][FILEHEADERGUID_TITLE];
            goodsNoChange.GoodsMakerCd = (int)this.GoodsNoChangeDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][GOODSMAKERCD_TITLE];
            goodsNoChange.MakerName = (string)this.GoodsNoChangeDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][MAKERNAME_TITLE];
            goodsNoChange.OldGoodsNo = (string)this.GoodsNoChangeDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][OLDGOODSNO_TITLE];
            goodsNoChange.NewGoodsNo = (string)this.GoodsNoChangeDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][NEWGOODSNO_TITLE];
            #endregion

            #endregion
        }

        /// <summary>
        /// Read該当データリスト取得処理
        /// </summary>
        /// <param name="MakerCode">メーカーコード</param>
        /// <remarks>
        /// <br>Note       : キャッシュから品番変換名称を取得します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private string CreateReadRowFilter(int MakerCode)
        {
            string rowFilter = "";

            #region < メーカーコードのみ >
            if (MakerCode != 0)
            {
                rowFilter = GoodsNoChangeAcs.GOODSMAKERCD_TITLE + " = '" + MakerCode + "'";
            }
            #endregion
            return rowFilter;
        }

        /// <summary>
        /// 品番変換ワーククラスから品番変換クラスを作成します。
        /// </summary>
        /// <param name="paraobj">品番変換ワーククラス</param>
        /// <remarks>
        /// <br>Note       : 品番変換クラスを作成します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private GoodsNoChange CopyToGoodsNoChangeFromGoodsNoChangeWork(object paraobj)
        {
            GoodsNoChangeWork goodsNoChangeWork = new GoodsNoChangeWork();
            Type paraType = paraobj.GetType();
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt = new MakerUMnt();

            #region ●Object → GoodsNoChangeWorkクラス処理
            if (paraType.Name == "ArrayList")
            {
                ArrayList paraList = (ArrayList)paraobj;
                goodsNoChangeWork = (GoodsNoChangeWork)paraList[0];
            }
            else if (paraType.Name == "GoodsNoChangeWork")
            {
                goodsNoChangeWork = (GoodsNoChangeWork)paraobj;
            }
            #endregion

            GoodsNoChange goodsNoChange = new GoodsNoChange();
            goodsNoChange.FileHeaderGuid     = goodsNoChangeWork.FileHeaderGuid;          // データテーブルカラム名称
            goodsNoChange.LogicalDeleteCode  = goodsNoChangeWork.LogicalDeleteCode;       // 論理削除区分
            goodsNoChange.UpdateDateTime     = goodsNoChangeWork.UpdateDateTime;          // 修正日付
            goodsNoChange.EnterpriseCode = goodsNoChangeWork.EnterpriseCode;
            goodsNoChange.UpdateDateTime = goodsNoChangeWork.UpdateDateTime;
            goodsNoChange.CreateDateTime = goodsNoChangeWork.CreateDateTime;
            goodsNoChange.UpdAssemblyId1 = goodsNoChangeWork.UpdAssemblyId1;
            goodsNoChange.UpdAssemblyId2 = goodsNoChangeWork.UpdAssemblyId2;
            goodsNoChange.UpdEmployeeCode = goodsNoChangeWork.UpdEmployeeCode;
            goodsNoChange.GoodsMakerCd = goodsNoChangeWork.GoodsMakerCd;
            goodsNoChange.OldGoodsNo = goodsNoChangeWork.OldGoodsNo;
            goodsNoChange.NewGoodsNo = goodsNoChangeWork.NewGoodsNo;
            //メーカー名取得
            int st = makerAcs.Read(out makerUMnt, goodsNoChange.EnterpriseCode, goodsNoChange.GoodsMakerCd);
            if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL && makerUMnt != null)
            {
                goodsNoChange.MakerName = makerUMnt.MakerName;
            }

            return goodsNoChange;
        }

        #endregion
    }
}
