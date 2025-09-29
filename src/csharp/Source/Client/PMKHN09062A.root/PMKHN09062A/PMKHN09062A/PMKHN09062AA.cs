using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Windows.Forms;

using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// BLグループマスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: BLグループマスタのアクセス制御を行います。
    ///					  IGeneralGuideDataを実装しています。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/06/11</br>
    /// </remarks>
    public class BLGroupUAcs : IGeneralGuideData
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
        IBLGroupUDB _iBLGroupUDB = null;
        //IBlGroupDB _iBLGroupDB = null;

        // キャッシュ用ハッシュテーブル
        private static Hashtable _bLGroupUTable = null;

        #endregion Private Members

        # region Constructor

        /// <summary>
        /// BLグループテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLグループテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public BLGroupUAcs()
        {
            _bLGroupUTable = null;

            try
            {
                // リモートオブジェクト取得
                this._iBLGroupUDB = (IBLGroupUDB)MediationBLGroupUDB.GetBLGroupUDB();
                //this._iBLGroupDB = (IBlGroupDB)MediationBLGroupDB.GetBLGroupDB();

            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iBLGroupUDB = null;
                //this._iBLGroupDB = null;
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
            //if ((this._iBLGroupUDB == null) || (this._iBLGroupDB == null))
            if (this._iBLGroupUDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }




        /// <summary>
        /// BLグループコード全件読み込み処理(論理削除含む)
        /// </summary>
        /// <param name="retList">参照結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BLグループコード情報を読み込みます。<br/>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            _bLGroupUTable = new Hashtable();

            // ユーザーデータ
            status = SearchBLGroupUser(ref retList, enterpriseCode, 0);

            // 提供データ
            //status = SearchBLGroupOffer(ref retList, 0);

            return status;
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
            foreach (BLGroupU bLGroupU in wkList)
            {
                if (bLGroupU.LogicalDeleteCode == 0)
                {
                    wkSort.Add(bLGroupU.BLGroupCode, bLGroupU);
                }
            }

            BLGroupU[] aryBLGroupU = new BLGroupU[wkSort.Count];

            // データを元に戻す
            for (int i = 0; i < wkSort.Count; i++)
            {
                aryBLGroupU[i] = (BLGroupU)wkSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(aryBLGroupU);
            XmlByteSerializer.ReadXml(ref dataSet, retbyte);

            return status;
        }

        /// <summary>
        /// BLグループデータ検索処理
        /// </summary>
        /// <param name="bLGroupU">BLグループオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="bLGroupCode">BLグループコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品中分類データを検索します。<br/>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int Search(out BLGroupU bLGroupU, string enterpriseCode, int bLGroupCode)
        {
            int status;
            bLGroupU = new BLGroupU();
            _bLGroupUTable = new Hashtable();
            ArrayList retList = new ArrayList();

            // ユーザーデータ
            status = SearchBLGroupUser(ref retList, enterpriseCode, bLGroupCode);

            // 提供データ
            //status = SearchBLGroupOffer(ref retList, bLGroupCode);

            if ((retList == null) || (retList.Count == 0))
            {
                return 9;
            }
            else
            {
                bLGroupU = (BLGroupU)retList[0];
                return 0;
            }
        }

        /// <summary>
        /// BLグループマスタ登録・更新処理
        /// </summary>
        /// <param name="bLGroupU">BLグループマスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BLグループマスタ情報の登録・更新を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int Write(ref BLGroupU bLGroupU)
        {
            // ------------------------------------------------------
            // 登録はユーザー登録分しかありえない
            // ------------------------------------------------------

            int status = 0;

            try
            {
                // クラスメンバーコピー処理(Ｅクラス→Ｄクラス(ユーザー))
                BLGroupUWork bLGroupUWork = CopyToBLGroupUWorkFromBLGroupU(bLGroupU);
                ArrayList paraList = new ArrayList();
                paraList.Add(bLGroupUWork);

                object paraobj = paraList;

                // BLグループマスタ書き込み
                status = this._iBLGroupUDB.Write(ref paraobj);
                if (status == 0)
                {
                    ArrayList retList = new ArrayList();
                    retList = (ArrayList)paraobj;

                    bLGroupUWork = (BLGroupUWork)retList[0];

                    // クラスメンバーコピー処理(Ｄクラス(ユーザー)→Ｅクラス)
                    bLGroupU = CopyToBLGroupUFromBLGroupUWork(bLGroupUWork);
                }
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iBLGroupUDB = null;

                //通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// BLグループマスタ物理削除処理
        /// </summary>
        /// <param name="bLGroupU">BLグループマスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BLグループマスタの物理削除を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int Delete(BLGroupU bLGroupU)
        {
            // ------------------------------------------------------
            // 物理削除はユーザー登録分しかありえない
            // ------------------------------------------------------

            int status = 0;

            try
            {
                // クラスメンバーコピー処理(Ｅクラス→Ｄクラス(ユーザー))
                BLGroupUWork bLGroupUWork = CopyToBLGroupUWorkFromBLGroupU(bLGroupU);
                ArrayList paraList = new ArrayList();
                paraList.Add(bLGroupUWork);

                object paraObj = paraList;

                // BLグループマスタ物理削除
                status = this._iBLGroupUDB.Delete(paraObj);
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iBLGroupUDB = null;

                //通信エラーは-1を戻す
                return -1;
            }

            return status;
        }

        /// <summary>
        /// BLグループマスタ論理削除処理
        /// </summary>
        /// <param name="bLGroupU">BLグループマスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BLグループマスタの論理削除を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int LogicalDelete(ref BLGroupU bLGroupU)
        {
            // ------------------------------------------------------
            // 論理削除はユーザー登録分しかありえない
            // ------------------------------------------------------

            int status = 0;

            try
            {
                // クラスメンバーコピー処理(Ｅクラス→Ｄクラス(ユーザー))
                BLGroupUWork bLGroupUWork = CopyToBLGroupUWorkFromBLGroupU(bLGroupU);
                ArrayList paraList = new ArrayList();
                paraList.Add(bLGroupUWork);

                object paraObj = paraList;

                // BLグループマスタ論理削除
                status = this._iBLGroupUDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    ArrayList retList = new ArrayList();
                    retList = (ArrayList)paraObj;

                    bLGroupUWork = (BLGroupUWork)retList[0];

                    // クラスメンバーコピー処理(Ｄクラス(ユーザー)→Ｅクラス)
                    bLGroupU = CopyToBLGroupUFromBLGroupUWork(bLGroupUWork);
                }
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iBLGroupUDB = null;

                //通信エラーは-1を戻す
                return -1;
            }

            return status;
        }

        /// <summary>
        /// BLグループマスタ復活処理
        /// </summary>
        /// <param name="bLGroupU">BLグループマスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BLグループマスタの復活を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int Revival(ref BLGroupU bLGroupU)
        {
            // ------------------------------------------------------
            // 論理削除復活はユーザー登録分しかありえない
            // ------------------------------------------------------

            int status = 0;

            try
            {
                // クラスメンバーコピー処理(Ｅクラス→Ｄクラス(ユーザー))
                BLGroupUWork bLGroupUWork = CopyToBLGroupUWorkFromBLGroupU(bLGroupU);
                ArrayList paraList = new ArrayList();
                paraList.Add(bLGroupUWork);

                object paraObj = paraList;

                // 復活処理
                status = this._iBLGroupUDB.RevivalLogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = new ArrayList();
                    retList = (ArrayList)paraObj;

                    bLGroupUWork = (BLGroupUWork)retList[0];

                    // クラスメンバーコピー処理(Ｄクラス(ユーザー)→Ｅクラス)
                    bLGroupU = CopyToBLGroupUFromBLGroupUWork(bLGroupUWork);
                }
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iBLGroupUDB = null;

                //通信エラーは-1を戻す
                return -1;
            }

            return status;
        }

        /// <summary>
        /// BLグループコードマスタガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="bLGroupU">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: BL商品コードマスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date	    : 2008/06/11</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out BLGroupU bLGroupU)
        {
            int status = -1;
            bLGroupU = new BLGroupU();

            TableGuideParent tableGuideParent = new TableGuideParent("BLGROUPGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                string strCode;

                // BLグループコード
                strCode = retObj["BLGroupCode"].ToString();
                bLGroupU.BLGroupCode = int.Parse(strCode);

                // BLグループ名称
                bLGroupU.BLGroupName = retObj["BLGroupName"].ToString();

                // 商品大分類コード
                strCode = retObj["GoodsLGroup"].ToString();
                bLGroupU.GoodsLGroup = int.Parse(strCode);

                // 商品中分類コード
                strCode = retObj["GoodsMGroup"].ToString();
                bLGroupU.GoodsMGroup = int.Parse(strCode);

                // 販売区分コード
                strCode = retObj["SalesCode"].ToString();
                bLGroupU.SalesCode = int.Parse(strCode);

                // データ区分コード
                strCode = retObj["OfferDataDiv"].ToString();
                bLGroupU.OfferDataDiv = int.Parse(strCode);

                // データ区分名称
                bLGroupU.OfferDataDivName = retObj["OfferDataDivName"].ToString();

                status = 0;
            }
            // キャンセル
            else
            {
                status = 1;
            }

            return status;
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
        /// BLグループコード(ユーザーデータ)全件読み込み処理(論理削除含む)
        /// </summary>
        /// <param name="retList">参照結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="bLGroupUCode">BLグループコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BLグループコード(ユーザーデータ)を読み込みます。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        private int SearchBLGroupUser(ref ArrayList retList, string enterpriseCode, int bLGroupCode)
        {
            // 初期化処理
            int status = 0;
            int hashKey;

            // 条件抽出クラス(D)の設定
            BLGroupUWork bLGroupUWork = new BLGroupUWork();
            bLGroupUWork.EnterpriseCode = enterpriseCode;
            bLGroupUWork.BLGroupCode = bLGroupCode;

            ArrayList paraList = new ArrayList();
            object paraobj = bLGroupUWork;
            object retobj = paraList;

            // リモートオブジェクトの呼び出し
            status = this._iBLGroupUDB.Search(ref retobj, paraobj, 0, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    paraList = retobj as ArrayList;

                    if (paraList == null)
                    {
                        return status;
                    }

                    foreach (BLGroupUWork wkbLGroupUWork in paraList)
                    {
                        // BLグループコード取得
                        hashKey = wkbLGroupUWork.BLGroupCode;

                        if (_bLGroupUTable[hashKey] != null)
                        {
                            continue;
                        }

                        // クラスメンバーコピー処理(Ｄクラス(ユーザー)→Ｅクラス)
                        BLGroupU bLGroupU = CopyToBLGroupUFromBLGroupUWork(wkbLGroupUWork);
                        retList.Add(bLGroupU);

                        // static保持
                        _bLGroupUTable[hashKey] = bLGroupU;
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
        ///// BLグループコード(提供データ)全件読み込み処理(論理削除含む)
        ///// </summary>
        ///// <param name="retList">参照結果リスト</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="bLGroupUCode">BLグループコード</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : BLグループコード(提供データ)を読み込みます。</br>
        ///// <br>Programmer : 30414 忍　幸史</br>
        ///// <br>Date	   : 2008/06/11</br>
        ///// </remarks>
        //private int SearchBLGroupOffer(ref ArrayList retList, int bLGroupCode)
        //{
        //    // 初期化処理
        //    int status = 0;
        //    int hashKey;

        //    // 条件抽出クラス(D)の設定
        //    BLGroupWork bLGroupWork = new BLGroupWork();
        //    bLGroupWork.BLGloupCode = bLGroupCode;

        //    ArrayList paraList = new ArrayList();
        //    object paraobj = bLGroupWork;
        //    object retobj = paraList;

        //    // リモートオブジェクトの呼び出し
        //    status = this._iBLGroupDB.Search(out retobj, paraobj);
        //    switch (status)
        //    {
        //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //            paraList = retobj as ArrayList;

        //            if (paraList == null)
        //            {
        //                return status;
        //            }

        //            foreach (BLGroupWork wkbLGroupWork in paraList)
        //            {
        //                // BLグループコード取得
        //                hashKey = wkbLGroupWork.BLGloupCode;

        //                if (_bLGroupUTable[hashKey] != null)
        //                {
        //                    continue;
        //                }

        //                // クラスメンバーコピー処理(Ｄクラス(提供)→Ｅクラス)
        //                BLGroupU bLGroupU = CopyToBLGroupUFromBLGroupWork(wkbLGroupWork);
        //                retList.Add(bLGroupU);

        //                // static保持
        //                _bLGroupUTable[hashKey] = bLGroupU;
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
        /// クラスメンバーコピー処理（BLグループマスタクラス(E)⇒ユーザーBLグループマスタワーククラス(D)）
        /// </summary>
        /// <param name="bLGroupU">BLグループマスタクラス</param>
        /// <returns>BLグループマスタワーククラス</returns>
        /// <remarks>
        /// <br>Note       : BLグループマスタクラスからBLグループマスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        private BLGroupUWork CopyToBLGroupUWorkFromBLGroupU(BLGroupU bLGroupU)
        {
            BLGroupUWork bLGroupUWork = new BLGroupUWork();

            bLGroupUWork.EnterpriseCode = bLGroupU.EnterpriseCode;          // 企業コード
            bLGroupUWork.CreateDateTime = bLGroupU.CreateDateTime;          // 作成日時
            bLGroupUWork.UpdateDateTime = bLGroupU.UpdateDateTime;          // 更新日時
            bLGroupUWork.FileHeaderGuid = bLGroupU.FileHeaderGuid;          // GUID
            bLGroupUWork.UpdEmployeeCode = bLGroupU.UpdEmployeeCode;        // 更新従業員コード
            bLGroupUWork.UpdAssemblyId1 = bLGroupU.UpdAssemblyId1;          // 更新アセンブリID1
            bLGroupUWork.UpdAssemblyId2 = bLGroupU.UpdAssemblyId2;          // 更新アセンブリID2
            bLGroupUWork.LogicalDeleteCode = bLGroupU.LogicalDeleteCode;    // 論理削除区分

            bLGroupUWork.BLGroupCode = bLGroupU.BLGroupCode;                // BLグループコード
            bLGroupUWork.BLGroupName = bLGroupU.BLGroupName;                // BLグループ名称
            bLGroupUWork.BLGroupKanaName = bLGroupU.BLGroupKanaName;        // BLグループ名称(カナ)
            bLGroupUWork.GoodsLGroup = bLGroupU.GoodsLGroup;                // 商品大分類コード
            bLGroupUWork.GoodsMGroup = bLGroupU.GoodsMGroup;                // 商品中分類コード
            bLGroupUWork.SalesCode = bLGroupU.SalesCode;                    // 販売区分コード
            bLGroupUWork.OfferDate = bLGroupU.OfferDate;                    // 提供日付
            bLGroupUWork.OfferDataDiv = bLGroupU.OfferDataDiv;              // 提供データ区分

            return bLGroupUWork;
        }

        /// <summary>
        /// クラスメンバーコピー処理（ユーザーBLグループマスタワーククラス(D)⇒BLグループマスタクラス(E)）
        /// </summary>
        /// <param name="bLGroupUWork">BLグループマスタワーククラス</param>
        /// <returns>BLグループマスタクラス</returns>
        /// <remarks>
        /// <br>Note       : BLグループマスタワーククラスからBLグループマスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        private BLGroupU CopyToBLGroupUFromBLGroupUWork(BLGroupUWork bLGroupUWork)
        {
            BLGroupU bLGroupU = new BLGroupU();

            bLGroupU.EnterpriseCode = bLGroupUWork.EnterpriseCode;          // 企業コード
            bLGroupU.CreateDateTime = bLGroupUWork.CreateDateTime;          // 作成日時
            bLGroupU.UpdateDateTime = bLGroupUWork.UpdateDateTime;          // 更新日時
            bLGroupU.FileHeaderGuid = bLGroupUWork.FileHeaderGuid;          // GUID
            bLGroupU.UpdEmployeeCode = bLGroupUWork.UpdEmployeeCode;        // 更新従業員コード
            bLGroupU.UpdAssemblyId1 = bLGroupUWork.UpdAssemblyId1;          // 更新アセンブリID1
            bLGroupU.UpdAssemblyId2 = bLGroupUWork.UpdAssemblyId2;          // 更新アセンブリID2
            bLGroupU.LogicalDeleteCode = bLGroupUWork.LogicalDeleteCode;    // 論理削除区分

            bLGroupU.BLGroupCode = bLGroupUWork.BLGroupCode;                // BLグループコード
            bLGroupU.BLGroupName = bLGroupUWork.BLGroupName;                // BLグループ名称
            bLGroupU.BLGroupKanaName = bLGroupUWork.BLGroupKanaName;        // BLグループ名称(カナ)
            bLGroupU.GoodsLGroup = bLGroupUWork.GoodsLGroup;                // 商品大分類コード
            bLGroupU.GoodsMGroup = bLGroupUWork.GoodsMGroup;                // 商品中分類コード
            bLGroupU.SalesCode = bLGroupUWork.SalesCode;                    // 販売区分コード
            bLGroupU.OfferDate = bLGroupUWork.OfferDate;                    // 提供日付
            bLGroupU.OfferDataDiv = bLGroupUWork.OfferDataDiv;              // 提供データ区分
            if (bLGroupU.OfferDate == DateTime.MinValue)
            {
                bLGroupU.OfferDataDiv = DIVISION_USR;                           // データ区分
                bLGroupU.OfferDataDivName = DIVISIONNAME_USR;                   // データ区分名称
            }
            else
            {
                bLGroupU.OfferDataDiv = DIVISION_OFR;
                bLGroupU.OfferDataDivName = DIVISIONNAME_OFR;
            }
            
            return bLGroupU;
        }

        ///// <summary>
        ///// クラスメンバーコピー処理（提供BLグループマスタワーククラス(D)⇒BLグループマスタクラス(E)）
        ///// </summary>
        ///// <param name="bLGroupWork">BLグループマスタワーククラス</param>
        ///// <returns>BLグループマスタクラス</returns>
        ///// <remarks>
        ///// <br>Note       : BLグループマスタワーククラスからBLグループマスタクラスへメンバーのコピーを行います。</br>
        ///// <br>Programmer : 30414 忍　幸史</br>
        ///// <br>Date	   : 2008/06/11</br>
        ///// </remarks>
        //private BLGroupU CopyToBLGroupUFromBLGroupWork(BLGroupWork bLGroupWork)
        //{
        //    BLGroupU bLGroupU = new BLGroupU();

        //    bLGroupU.BLGroupCode = bLGroupWork.BLGloupCode;     // BLグループコード
        //    bLGroupU.BLGroupName = bLGroupWork.BLGloupName;     // BLグループ名称
        //    bLGroupU.GoodsMGroup = bLGroupWork.GoodsMGroup;     // 商品中分類コード
        //    bLGroupU.DivisionCode = DIVISION_OFR;               // データ区分
        //    bLGroupU.DivisionName = DIVISIONNAME_OFR;           // データ区分名称

        //    return bLGroupU;
        //}
        
        #endregion Private Methods
    }
}
