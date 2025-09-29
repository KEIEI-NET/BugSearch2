//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 接続先情報設定マスタメンテナンス
// プログラム概要   : 接続先情報設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570219-00 作成担当 : 田建委
// 作 成 日  2019/12/03  修正内容 : 新規作成
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
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/12/03</br>
    /// <br>管理番号  : 11570219-00</br>
    /// <br></br>
    /// </remarks>
    public class SalCprtConnectInfoWorkAcs
    {
        #region -- リモートオブジェクト格納バッファ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// リモートオブジェクト格納バッファ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号  : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private ISalCprtConnectInfoPrcPrStDB _iSalCprtConnectInfoWorkAcsDB = null;

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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号  : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public SalCprtConnectInfoWorkAcs()
        {
            // リモートオブジェクト取得
            this._iSalCprtConnectInfoWorkAcsDB = (ISalCprtConnectInfoPrcPrStDB)MediationSalCprtConnectInfoPrcPrStDB.GetSalCprtConnectInfoPrcPrStDB();
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
        /// <param name="flag">時間更新フラグ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号  : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public int Write(ref SalCprtConnectInfoWork connectInfoWork, int flag)
        {
            int status = 0;
           
            try
            {
                object objConnectInfoWorkAcsWork = connectInfoWork;

                int writeMode = 0;

                // 書き込み処理
                status = this._iSalCprtConnectInfoWorkAcsDB.Write(ref objConnectInfoWorkAcsWork, writeMode, flag);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    connectInfoWork = objConnectInfoWorkAcsWork as SalCprtConnectInfoWork;
                }
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSalCprtConnectInfoWorkAcsDB = null;

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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号  : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public int LogicalDelete(ref SalCprtConnectInfoWork connectInfoWork)
        {
            try
            {
                object objConnectInfoWorkAcsWork = connectInfoWork;

                // 接続先情報論理削除
                int status = this._iSalCprtConnectInfoWorkAcsDB.LogicalDelete(ref objConnectInfoWorkAcsWork);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ファイル名を渡して情報ワーククラスをデシリアライズする
                    connectInfoWork = objConnectInfoWorkAcsWork as SalCprtConnectInfoWork;
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSalCprtConnectInfoWorkAcsDB = null;

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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号  : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public int Delete(SalCprtConnectInfoWork connectInfoWork)
        {
            try
            {
                byte[] parabyte = XmlByteSerializer.Serialize(connectInfoWork);

                // 物理削除
                int status = this._iSalCprtConnectInfoWorkAcsDB.Delete(parabyte);
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSalCprtConnectInfoWorkAcsDB = null;

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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号  : 11570219-00</br>
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList connectInfoWorkAcsList, string enterpriseCode, SearchMode searchMode)
        {
            try
            {
                // モードをセット
                _isLocalDBRead = searchMode == SearchMode.Local ? true : false;

                SalCprtConnectInfoWork connectInfoWork = new SalCprtConnectInfoWork();

                connectInfoWork.EnterpriseCode = enterpriseCode;
                connectInfoWork.SupplierCd = 0;
                connectInfoWork.CnectProgramType = 1;

                int status = 0;

                connectInfoWorkAcsList = new ArrayList();
                connectInfoWorkAcsList.Clear();

                ArrayList connectInfoWorkAcsWorkList = new ArrayList();
                connectInfoWorkAcsWorkList.Clear();

                // リモートに読込結果用
                object paraobj = connectInfoWork;
                object retobj = null;

                status = this._iSalCprtConnectInfoWorkAcsDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    connectInfoWorkAcsWorkList = retobj as ArrayList;

                    foreach (SalCprtConnectInfoWork wkConnectInfoWork in connectInfoWorkAcsWorkList)
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
                this._iSalCprtConnectInfoWorkAcsDB = null;
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
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報設定マスタの検索処理を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public int Read(out SalCprtConnectInfoWork connectInfoWork, string enterpriseCode, int supplierCd, string sectionCode, int customerCode)
        {
            try
            {
                connectInfoWork = new SalCprtConnectInfoWork();

                connectInfoWork.EnterpriseCode = enterpriseCode;
                connectInfoWork.SupplierCd = supplierCd;
                connectInfoWork.SectionCode = sectionCode;
                connectInfoWork.CustomerCode = customerCode;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(connectInfoWork);

                // メール送信管理フィールド名称読み込み
                int status = this._iSalCprtConnectInfoWorkAcsDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XMLの読み込み
                    connectInfoWork = (SalCprtConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(SalCprtConnectInfoWork));
                }
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                connectInfoWork = null;
                //オフライン時はnullをセット
                this._iSalCprtConnectInfoWorkAcsDB = null;
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref SalCprtConnectInfoWork connectInfoWork)
        {
            try
            {
                // XMLへ変換し、文字列のバイナリ化
                object objConnectInfoWorkAcsWork = connectInfoWork;

                // 復活処理
                int status = this._iSalCprtConnectInfoWorkAcsDB.RevivalLogicalDelete(ref objConnectInfoWorkAcsWork);


                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ファイル名を渡して情報ワーククラスをデシリアライズする
                    connectInfoWork = objConnectInfoWorkAcsWork as SalCprtConnectInfoWork;
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSalCprtConnectInfoWorkAcsDB = null;

                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion -- 検索･復活処理 --
    }
}
