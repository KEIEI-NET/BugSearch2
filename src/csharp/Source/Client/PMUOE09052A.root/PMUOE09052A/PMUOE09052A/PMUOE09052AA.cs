//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : UOE接続先情報マスタメンテナンス
// プログラム概要   : UOE接続先情報マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : caowj
// 作 成 日  2010/07/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// UOE接続先情報マスタメンテナンスアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: UOE接続先情報マスタテーブルのアクセスクラスです。</br>
    /// <br>Programmer	: caowj</br>
    /// <br>Date		: 2010/07/27</br>
    /// <br></br>
    /// </remarks>
    public class UOEConnectInfoAcs
    {
        # region -- Private Members --
        /// <summary> リモートオブジェクト格納バッファ </summary>
        private IUOEConnectInfoDB _iUOEConnectInfoDB = null;
        /// <summary>ログイン拠点</summary>
        private string _loginSectionCode = "";
        # endregion

        # region -- コンストラクタ --
        /// <summary>
        ///  UOE接続先情報マスタメンテナンスアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: UOE接続先情報マスタメンテナンスアクセスクラスのコンストラクタです。</br>
        /// <br>Programmer	: caowj</br>
        /// <br>Date		: 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        public UOEConnectInfoAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iUOEConnectInfoDB = (IUOEConnectInfoDB)MediationUOEConnectInfoDB.GetUOEConnectInfoDB();

            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iUOEConnectInfoDB = null;
            }

            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee;
            if (loginEmployee != null)
            {
                this._loginSectionCode = loginEmployee.BelongSectionCode;
            }
        }
        # endregion

        # region [ローカルアクセス用]
        /// <summary> オンラインモードの列挙型 </summary>
        public enum OnlineMode
        {
            /// <summary> オフライン </summary>
            Offline,
            /// <summary> オンライン </summary>
            Online
        }

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note		: オンラインモードを取得します</br>
        /// <br>Programmer	: caowj</br>
        /// <br>Date		: 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iUOEConnectInfoDB == null)
            {
                return (int)OnlineMode.Offline;
            }
            else
            {
                return (int)OnlineMode.Online;
            }
        }
        # endregion

        # region -- 検索処理 --
        /// <summary>
        /// UOE接続先情報マスタクラス読み込み処理
        /// </summary>
        /// <param name="uOEConnectInfo">UOE接続先情報マスタクラスオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <param name="cashRegisterNo">レジ番号</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : UOE接続先情報マスタクラス情報を読み込みます。</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int Read(out UOEConnectInfo uOEConnectInfo, string enterpriseCode, string commAssemblyId, int cashRegisterNo)
        {
            try
            {
                uOEConnectInfo = null;
                UOEConnectInfoWork uOEConnectInfoWork = new UOEConnectInfoWork();
                uOEConnectInfoWork.EnterpriseCode = enterpriseCode;
                uOEConnectInfoWork.CommAssemblyId = commAssemblyId;
                uOEConnectInfoWork.CashRegisterNo = cashRegisterNo;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWork);

                // UOE接続先情報マスタ読み込み
                int status = this._iUOEConnectInfoDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XMLの読み込み
                    uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));
                    // クラス内メンバコピー
                    uOEConnectInfo = CopyToUOEConnectInfoFromUOEConnectInfoWork(uOEConnectInfoWork);
                }
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                uOEConnectInfo = null;
                //オフライン時はnullをセット
                this._iUOEConnectInfoDB = null;
                return -1;
            }
        }

        /// <summary>
        /// 全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE接続先情報マスタの全検索処理を行います。</br>
        /// <br>	       : 論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchUOEConnectInfoProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null);
        }

        /// <summary>
        /// 検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE接続先情報マスタの全検索処理を行います。</br>
        /// <br>		   : 論理削除データも抽出対象となります。</br>
        /// <br>Programmer	: caowj</br>
        /// <br>Date		: 2010/07/27</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, UOEConnectInfo prevUOEConnectInfo)
        {
            return SearchUOEConnectInfoProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, readCnt, prevUOEConnectInfo);
        }
        
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer	: caowj</br>
        /// <br>Date		: 2010/07/27</br>
        /// </remarks>
        private int SearchUOEConnectInfoProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, UOEConnectInfo prevUOEConnectInfo)
        {
            UOEConnectInfoWork uOEConnectInfoWork = new UOEConnectInfoWork();
            if (prevUOEConnectInfo != null)
            {
                uOEConnectInfoWork = CopyToUOEConnectInfoWorkFromUOEConnectInfo(prevUOEConnectInfo);
            }
            uOEConnectInfoWork.EnterpriseCode = enterpriseCode;

            // 次データ有無初期化
            nextData = false;
            // 0で初期化
            retTotalCnt = 0;

            UOEConnectInfoWork[] al;
            retList = new ArrayList();
            retList.Clear();

            // 拠点情報取得処理
            ArrayList wkList = new ArrayList();
            wkList.Clear();

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWork);

            byte[] retbyte;

            // UOE接続先情報マスタ検索
            int status = 0;
            status = this._iUOEConnectInfoDB.Search(out retbyte, parabyte, 0, logicalMode);

            if ((status == 0) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                // XMLの読み込み
                al = (UOEConnectInfoWork[])XmlByteSerializer.Deserialize(retbyte, typeof(UOEConnectInfoWork[]));

                for (int i = 0; i < al.Length; i++)
                {
                    // サーチ結果取得
                    UOEConnectInfoWork wkUOEConnectInfoWork = (UOEConnectInfoWork)al[i];
                    // UOE接続先情報マスタクラスへメンバコピー
                    wkList.Add(CopyToUOEConnectInfoFromUOEConnectInfoWork(wkUOEConnectInfoWork));
                }

                retList = wkList;
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
            }
            // 全件リードの場合は戻り値の件数をセット
            if (readCnt == 0)
            {
                retTotalCnt = retList.Count;
            }

            return status;
        }
        # endregion

        # region -- 登録･更新処理 --
        /// <summary>
        /// UOE接続先情報マスタ登録・更新処理
        /// </summary>
        /// <param name="uOEConnectInfo">UOE接続先情報マスタクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE接続先情報マスタ登録・更新処理を行います。</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int Write(ref UOEConnectInfo uOEConnectInfo)
        {
            // UOE接続先情報マスタクラスからUOE接続先情報マスタワーカークラスにメンバコピー
            UOEConnectInfoWork uOEConnectInfoWork = CopyToUOEConnectInfoWorkFromUOEConnectInfo(uOEConnectInfo);

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWork);

            int status = 0;
            try
            {
                // UOE接続先情報マスタワーク書き込み
                status = this._iUOEConnectInfoDB.Write(ref parabyte);
                if (status == 0)
                {
                    // ファイル名を渡してUOE接続先情報マスタワーククラスをデシリアライズする
                    uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));
                    // クラス内メンバコピー
                    uOEConnectInfo = CopyToUOEConnectInfoFromUOEConnectInfoWork(uOEConnectInfoWork);
                }
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOEConnectInfoDB = null;
                //通信エラーは-1を戻す
                status = -1;
            }
            return status;
        }
        # endregion

        #region -- 削除･復活処理 --
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="uOEConnectInfo">データクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 物理削除を行います。</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int Delete(UOEConnectInfo uOEConnectInfo)
        {
            try
            {
                UOEConnectInfoWork uOEConnectInfoWorks = new UOEConnectInfoWork();
                uOEConnectInfoWorks = CopyToUOEConnectInfoWorkFromUOEConnectInfo(uOEConnectInfo);

                byte[] parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWorks);

                // 物理削除
                int status = this._iUOEConnectInfoDB.Delete(parabyte);
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOEConnectInfoDB = null;

                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="uOEConnectInfo">データクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 論理削除を行います。</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int LogicalDelete(ref UOEConnectInfo uOEConnectInfo)
        {
            try
            {
                UOEConnectInfoWork uOEConnectInfoWork = CopyToUOEConnectInfoWorkFromUOEConnectInfo(uOEConnectInfo);
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWork);
                // 任意保険ガイド論理削除
                int status = this._iUOEConnectInfoDB.LogicalDelete(ref parabyte);

                if (status == 0)
                {
                    // ファイル名を渡して任意保険ガイドワーククラスをデシリアライズする
                    uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));
                    // クラス内メンバコピー
                    uOEConnectInfo = CopyToUOEConnectInfoFromUOEConnectInfoWork(uOEConnectInfoWork);

                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOEConnectInfoDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// UOE接続先情報マスタ論理削除復活処理
        /// </summary>
        /// <param name="uOEConnectInfo">UOE接続先情報マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE接続先情報マスタ復活を行います。</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int Revival(ref UOEConnectInfo uOEConnectInfo)
        {
            try
            {
                UOEConnectInfoWork uOEConnectInfoWork = CopyToUOEConnectInfoWorkFromUOEConnectInfo(uOEConnectInfo);
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWork);
                // 復活処理
                int status = this._iUOEConnectInfoDB.RevivalLogicalDelete(ref parabyte);

                if (status == 0)
                {
                    // ファイル名を渡して従業員ワーククラスをデシリアライズする
                    uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));
                    // クラス内メンバコピー
                    uOEConnectInfo = CopyToUOEConnectInfoFromUOEConnectInfoWork(uOEConnectInfoWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOEConnectInfoDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        # endregion

        # region -- クラスメンバーコピー処理 --
        /// <summary>
        /// クラスメンバコピー処理（UOE接続先情報マスタワーククラス⇒UOE接続先情報マスタクラス）
        /// </summary>
        /// <param name="uOEConnectInfoWork">UOE接続先情報マスタワーククラス</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: UOE接続先情報マスタワーククラスからUOE接続先情報マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer  : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        private UOEConnectInfo CopyToUOEConnectInfoFromUOEConnectInfoWork(UOEConnectInfoWork uOEConnectInfoWork)
        {
            UOEConnectInfo uOEConnectInfo = new UOEConnectInfo();

            uOEConnectInfo.CreateDateTime = uOEConnectInfoWork.CreateDateTime;
            uOEConnectInfo.UpdateDateTime = uOEConnectInfoWork.UpdateDateTime;
            uOEConnectInfo.EnterpriseCode = uOEConnectInfoWork.EnterpriseCode;
            uOEConnectInfo.FileHeaderGuid = uOEConnectInfoWork.FileHeaderGuid;
            uOEConnectInfo.UpdEmployeeCode = uOEConnectInfoWork.UpdEmployeeCode;
            uOEConnectInfo.UpdAssemblyId1 = uOEConnectInfoWork.UpdAssemblyId1;
            uOEConnectInfo.UpdAssemblyId2 = uOEConnectInfoWork.UpdAssemblyId2;
            uOEConnectInfo.LogicalDeleteCode = uOEConnectInfoWork.LogicalDeleteCode;
            uOEConnectInfo.CommAssemblyId = uOEConnectInfoWork.CommAssemblyId;
            uOEConnectInfo.CashRegisterNo = uOEConnectInfoWork.CashRegisterNo;
            uOEConnectInfo.SocketCommPort = uOEConnectInfoWork.SocketCommPort;
            uOEConnectInfo.ReceiveComputerNm = uOEConnectInfoWork.ReceiveComputerNm;
            uOEConnectInfo.ClientTimeOut = uOEConnectInfoWork.ClientTimeOut;

            return uOEConnectInfo;
        }

        /// <summary>
        /// クラスメンバコピー処理（UOE接続先情報マスタクラス⇒UOE接続先情報マスタワーククラス）
        /// </summary>
        /// <param name="uOEConnectInfo">UOE接続先情報マスタクラス</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: UOE接続先情報マスタクラスからUOE接続先情報マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer  : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        private UOEConnectInfoWork CopyToUOEConnectInfoWorkFromUOEConnectInfo(UOEConnectInfo uOEConnectInfo)
        {
            UOEConnectInfoWork uOEConnectInfoWork = new UOEConnectInfoWork();

            uOEConnectInfoWork.CreateDateTime = uOEConnectInfo.CreateDateTime;
            uOEConnectInfoWork.UpdateDateTime = uOEConnectInfo.UpdateDateTime;
            uOEConnectInfoWork.EnterpriseCode = uOEConnectInfo.EnterpriseCode;
            uOEConnectInfoWork.FileHeaderGuid = uOEConnectInfo.FileHeaderGuid;
            uOEConnectInfoWork.UpdEmployeeCode = uOEConnectInfo.UpdEmployeeCode;
            uOEConnectInfoWork.UpdAssemblyId1 = uOEConnectInfo.UpdAssemblyId1;
            uOEConnectInfoWork.UpdAssemblyId2 = uOEConnectInfo.UpdAssemblyId2;
            uOEConnectInfoWork.LogicalDeleteCode = uOEConnectInfo.LogicalDeleteCode;
            uOEConnectInfoWork.CommAssemblyId = uOEConnectInfo.CommAssemblyId;
            uOEConnectInfoWork.CashRegisterNo = uOEConnectInfo.CashRegisterNo;
            uOEConnectInfoWork.SocketCommPort = uOEConnectInfo.SocketCommPort;
            uOEConnectInfoWork.ReceiveComputerNm = uOEConnectInfo.ReceiveComputerNm;
            uOEConnectInfoWork.ClientTimeOut = uOEConnectInfo.ClientTimeOut;

            return uOEConnectInfoWork;
        }
        # endregion
    }
}
