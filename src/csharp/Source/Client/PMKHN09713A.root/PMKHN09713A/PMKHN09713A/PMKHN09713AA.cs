//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 接続先情報設定マスタメンテナンス
// プログラム概要   : 接続先情報設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10805731-00 作成担当 : 黄興貴
// 作 成 日  2012/12/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using System.Data;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 接続先情報設定マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 接続先情報設定マスタのアクセス制御を行います。</br>
    /// <br>Programmer : 黄興貴</br>
    /// <br>Date       : 2012/12/15</br>
    /// <br>管理番号   : 10805731-00</br>
    /// <br></br>
    /// </remarks>
    public class ConnectInfoWorkAcs
    {
        #region -- リモートオブジェクト格納バッファ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// リモートオブジェクト格納バッファ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private IConnectInfoPrcPrStDB _iConnectInfoWorkAcsDB = null;

        // ローカルＤＢモード
        private static bool _isLocalDBRead = false;	// デフォルトはリモート

        #endregion

        #region -- コンストラクタ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public ConnectInfoWorkAcs()
        {
            // リモートオブジェクト取得
            this._iConnectInfoWorkAcsDB = (IConnectInfoPrcPrStDB)MediationConnectInfoPrcPrStDB.GetConnectInfoPrcPrStDB();
        }

        #endregion

        #region -- [ローカルアクセス用] --
        /// <summary> 検索モード </summary>
        public enum SearchMode
        {
            /// <summary> ローカルアクセス </summary>
            Local = 0,
            /// <summary> リモートアクセス </summary>
            Remote = 1
        }
        #endregion

        #region -- 登録･更新処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="connectInfoWork">UIデータクラス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public int Write(ref ConnectInfoWork connectInfoWork)
        {
            int status = 0;
           
            try
            {
                object objConnectInfoWorkAcsWork = connectInfoWork;

                int writeMode = 0;

                // 書き込み処理
                status = this._iConnectInfoWorkAcsDB.Write(ref objConnectInfoWorkAcsWork, writeMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    connectInfoWork = objConnectInfoWorkAcsWork as ConnectInfoWork;
                }
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iConnectInfoWorkAcsDB = null;

                //通信エラーは-1を戻す
                return -1;
            }
          
            return status;
        }
        #endregion -- 登録･更新処理 --

        #region -- 削除処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="connectInfoWork">接続先情報設定マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報設定マスタの論理削除を行います。</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public int LogicalDelete(ref ConnectInfoWork connectInfoWork)
        {
            try
            {
                object objConnectInfoWorkAcsWork = connectInfoWork;

                // 接続先情報論理削除
                int status = this._iConnectInfoWorkAcsDB.LogicalDelete(ref objConnectInfoWorkAcsWork);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ファイル名を渡して情報ワーククラスをデシリアライズする
                    connectInfoWork = objConnectInfoWorkAcsWork as ConnectInfoWork;
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iConnectInfoWorkAcsDB = null;

                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="connectInfoWork">接続先情報設定マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報設定マスタの物理削除を行います。</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public int Delete(ConnectInfoWork connectInfoWork)
        {
            try
            {
                byte[] parabyte = XmlByteSerializer.Serialize(connectInfoWork);

                // 物理削除
                int status = this._iConnectInfoWorkAcsDB.Delete(parabyte);
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iConnectInfoWorkAcsDB = null;

                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 検索･復活処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 接続先情報設定マスタ全件検索処理（論理削除含む）
        /// </summary>
        /// <param name="connectInfoWorkAcsList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報設定マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public int SearchAll(out ArrayList connectInfoWorkAcsList, string enterpriseCode)
        {
            return SearchProc(out connectInfoWorkAcsList, enterpriseCode, SearchMode.Remote);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 接続先情報設定マスタ全件検索処理
        /// </summary>
        /// <param name="connectInfoWorkAcsList">読込結果コレクション</param>  
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報設定マスタの検索処理を行います。</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList connectInfoWorkAcsList, string enterpriseCode, SearchMode searchMode)
        {
            try
            {
                // モードをセット
                _isLocalDBRead = searchMode == SearchMode.Local ? true : false;

                ConnectInfoWork connectInfoWork = new ConnectInfoWork();

                connectInfoWork.EnterpriseCode = enterpriseCode;

                int status = 0;

                connectInfoWorkAcsList = new ArrayList();
                connectInfoWorkAcsList.Clear();

                ArrayList connectInfoWorkAcsWorkList = new ArrayList();
                connectInfoWorkAcsWorkList.Clear();

                // リモートに読込結果用
                object paraobj = connectInfoWork;
                object retobj = null;

                status = this._iConnectInfoWorkAcsDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    connectInfoWorkAcsWorkList = retobj as ArrayList;

                    foreach (ConnectInfoWork wkConnectInfoWork in connectInfoWorkAcsWorkList)
                    {
                        // 読込結果
                        connectInfoWorkAcsList.Add(wkConnectInfoWork);
                    }
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }

                // STATUS を設定
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (connectInfoWorkAcsList.Count == 0))
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iConnectInfoWorkAcsDB = null;
                // 読込結果nullをセット
                connectInfoWorkAcsList = null;

                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 接続先情報設定マスタ検索処理
        /// </summary>
        /// <param name="connectInfoWork">接続先情報設定クラスオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="SupplierCd">仕入先コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報設定マスタの検索処理を行います。</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public int Read(out ConnectInfoWork connectInfoWork, string enterpriseCode, int SupplierCd)
        {
            try
            {
                connectInfoWork = new ConnectInfoWork();

                connectInfoWork.EnterpriseCode = enterpriseCode;
                connectInfoWork.SupplierCd = SupplierCd;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(connectInfoWork);

                // メール送信管理フィールド名称読み込み
                int status = this._iConnectInfoWorkAcsDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XMLの読み込み
                    connectInfoWork = (ConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(ConnectInfoWork));
                }
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                connectInfoWork = null;
                //オフライン時はnullをセット
                this._iConnectInfoWorkAcsDB = null;
                return -1;
            }
        }

        /// <summary>
        /// 論理削除復活処理
        /// </summary>
        /// <param name="connectInfoWork">オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 復活を行います。</br>
        /// <br>Programmer : 黄興貴</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>管理番号   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref ConnectInfoWork connectInfoWork)
        {
            try
            {
                // XMLへ変換し、文字列のバイナリ化
                object objConnectInfoWorkAcsWork = connectInfoWork;

                // 復活処理
                int status = this._iConnectInfoWorkAcsDB.RevivalLogicalDelete(ref objConnectInfoWorkAcsWork);


                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ファイル名を渡して情報ワーククラスをデシリアライズする
                    connectInfoWork = objConnectInfoWorkAcsWork as ConnectInfoWork;
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iConnectInfoWorkAcsDB = null;

                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion -- 検索･復活処理 --
    }
}
