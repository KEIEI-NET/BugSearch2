using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 検品全体設定テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検品全体設定テーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 3H 楊善娟</br>
    /// <br>Date       : K2017/06/02</br>
    /// </remarks>
    public class InspectTtlStAcs
    {
        /// <summary>リモートオブジェクト</summary>
        private IInspectTtlStDB _iInspectTtlStDB = null;

        /// <summary>
        /// 検品全体設定テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検品全体設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        public InspectTtlStAcs()
		{
			try {
				// リモートオブジェクト取得
				this._iInspectTtlStDB = MediationInspectTtlStDB.GetInspectTtlStDB();
				}
			catch( Exception ) {
				// オフライン時はnullをセット
                this._iInspectTtlStDB = null;
			}
		}

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iInspectTtlStDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// 検品全体設定読み込み処理
        /// </summary>
        /// <param name="inspectTtlSt">検品全体設定オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="inspectTtlStCd">検品全体設定オブジェクト</param>
        /// <returns>検品全体設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 検品全体設定を読み込みます。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        public int Read(out InspectTtlSt inspectTtlSt, string enterpriseCode, int inspectTtlStCd)
        {
            int status = -1;
            
            try
            {
                inspectTtlSt = null;
                InspectTtlStWork inspectTtlStWork = new InspectTtlStWork();
                inspectTtlStWork.EnterpriseCode = enterpriseCode;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(inspectTtlStWork);

                // 検品全体設定読み込み
                status = this._iInspectTtlStDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XMLの読み込み
                    inspectTtlStWork = (InspectTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(InspectTtlStWork));
                    // クラス内メンバコピー
                    inspectTtlSt = CopyToInspectTtlStFromInspectTtlStWork(inspectTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                inspectTtlSt = null;
                //オフライン時はnullをセット
                this._iInspectTtlStDB = null;

                return -1;
            }
        }

        /// <summary>
        /// 検品全体設定検索処理
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品全体設定の検索処理を行います。論理削除データは抽出されません。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }
		
        /// <summary>
        /// 検品全体設定検索処理(論理削除データ含む)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品全体設定の検索処理を行います。論理削除データも抽出対象に含みます。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }
		
        /// <summary>
        /// 検品全体設定検索処理(メイン)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品全体設定の検索処理を行います。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            InspectTtlStWork inspectTtlStWork = new InspectTtlStWork();
            inspectTtlStWork.EnterpriseCode = enterpriseCode;		// 企業コード

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = inspectTtlStWork;
            object retobj = null;

            // 検品全体設定全件検索
            status = this._iInspectTtlStDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                wkList = retobj as ArrayList;
                if (wkList != null)
                {
                    foreach (InspectTtlStWork wkInspectTtlStWork in wkList)
                    {
                        retList.Add(CopyToInspectTtlStFromInspectTtlStWork(wkInspectTtlStWork));
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// 検品全体設定登録・更新処理
        /// </summary>
        /// <param name="inspectTtlSt">検品全体設定リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品全体設定の登録・更新を行います。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        public int Write(ref InspectTtlSt inspectTtlSt)
        {
            int status = 0;

            try
            {
                // 検品全体設定クラスを検品全体設定ワーククラスへメンバコピー
                InspectTtlStWork inspectTtlStWork = CopyToInspectTtlStWorkFromInspectTtlSt(inspectTtlSt);

                // 保存
                Object paraObj = (object)inspectTtlStWork;
                status = this._iInspectTtlStDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 検品全体設定ワーククラスから検品全体設定クラスへメンバコピー
                    ArrayList wklist = (ArrayList)paraObj;
                    inspectTtlStWork = wklist[0] as InspectTtlStWork;
                    inspectTtlSt = CopyToInspectTtlStFromInspectTtlStWork(inspectTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iInspectTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 検品全体設定論理削除処理
        /// </summary>
        /// <param name="inspectTtlSt">検品全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品全体設定の論理削除を行います。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        public int LogicalDelete(ref InspectTtlSt inspectTtlSt)
        {
            int status = 0;

            try
            {
                // 検品全体設定クラスを検品全体設定ワーククラスへメンバコピー
                InspectTtlStWork inspectTtlStWork = CopyToInspectTtlStWorkFromInspectTtlSt(inspectTtlSt);

                // 検品全体設定を論理削除
                Object paraObj = (object)inspectTtlStWork;
                status = this._iInspectTtlStDB.LogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 検品全体設定ワーククラスを検品全体設定クラスにメンバコピー
                    inspectTtlStWork = paraObj as InspectTtlStWork;
                    inspectTtlSt = CopyToInspectTtlStFromInspectTtlStWork(inspectTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iInspectTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 検品全体設定物理削除処理
        /// </summary>
        /// <param name="inspectTtlSt">検品全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品全体設定の物理削除を行います。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        public int Delete(InspectTtlSt inspectTtlSt)
        {
            int status = 0;

            try
            {
                // 検品全体設定クラスを検品全体設定ワーククラスへメンバコピー
                InspectTtlStWork inspectTtlStWork = CopyToInspectTtlStWorkFromInspectTtlSt(inspectTtlSt);
                // XML変換し、文字列をバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(inspectTtlStWork);

                // 検品全体設定物理削除
                status = this._iInspectTtlStDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullを設定
                this._iInspectTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 検品全体設定論理削除復活処理
        /// </summary>
        /// <param name="inspectTtlSt">検品全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品全体設定の論理削除復活を行います。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        public int Revival(ref InspectTtlSt inspectTtlSt)
        {
            int status = 0;

            try
            {
                // 検品全体設定クラスを検品全体設定ワーククラスへメンバコピー
                InspectTtlStWork inspectTtlStWork = CopyToInspectTtlStWorkFromInspectTtlSt(inspectTtlSt);

                // 復活
                Object paraObj = (object)inspectTtlStWork;
                status = this._iInspectTtlStDB.RevivalLogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 検品全体設定ワーククラスを検品全体設定クラスにメンバコピー
                    inspectTtlStWork = paraObj as InspectTtlStWork;
                    inspectTtlSt = CopyToInspectTtlStFromInspectTtlStWork(inspectTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iInspectTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// クラスメンバコピー処理（検品全体設定クラス→検品全体設定クラスワーク）
        /// </summary>
        /// <param name="inspectTtlSt">検品全体設定クラス</param>
        /// <returns>検品全体設定ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 検品全体設定クラスから検品全体設定ワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private InspectTtlStWork CopyToInspectTtlStWorkFromInspectTtlSt(InspectTtlSt inspectTtlSt)
        {
            InspectTtlStWork inspectTtlStWork = new InspectTtlStWork();

            // 作成日時
            inspectTtlStWork.CreateDateTime = inspectTtlSt.CreateDateTime;
            // 更新日時
            inspectTtlStWork.UpdateDateTime = inspectTtlSt.UpdateDateTime;
            // 企業コード
            inspectTtlStWork.EnterpriseCode = inspectTtlSt.EnterpriseCode;
            // GUID
            inspectTtlStWork.FileHeaderGuid = inspectTtlSt.FileHeaderGuid;
            // 更新従業員コード
            inspectTtlStWork.UpdEmployeeCode = inspectTtlSt.UpdEmployeeCode;
            // 更新アセンブリID1
            inspectTtlStWork.UpdAssemblyId1 = inspectTtlSt.UpdAssemblyId1;
            // 更新アセンブリID2
            inspectTtlStWork.UpdAssemblyId2 = inspectTtlSt.UpdAssemblyId2;
            // 論理削除区分
            inspectTtlStWork.LogicalDeleteCode = inspectTtlSt.LogicalDeleteCode;
            // 企業コード
            inspectTtlStWork.EnterpriseCode = inspectTtlSt.EnterpriseCode;
            // 拠点コード
            inspectTtlStWork.SectionCode = inspectTtlSt.SectionCode;
            // 取寄検品区分
            inspectTtlStWork.OrderInspectCode = inspectTtlSt.OrderInspectCode;
            return inspectTtlStWork;
        }

        /// <summary>
        /// クラスメンバコピー処理（検品全体設定ワーククラス→検品全体設定クラス）
        /// </summary>
        /// <param name="inspectTtlStWork">検品全体設定ワーククラス</param>
        /// <returns>検品全体設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 検品全体設定設定ワーククラスから検品全体設定クラスへメンバコピーを行います。</br>
        /// <br>Programmer : 3H 楊善娟</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private InspectTtlSt CopyToInspectTtlStFromInspectTtlStWork(InspectTtlStWork inspectTtlStWork)
        {
            InspectTtlSt inspectTtlSt = new InspectTtlSt();

            // 作成日時
            inspectTtlSt.CreateDateTime = inspectTtlStWork.CreateDateTime;
            // 更新日時
            inspectTtlSt.UpdateDateTime = inspectTtlStWork.UpdateDateTime;
            // 企業コード
            inspectTtlSt.EnterpriseCode = inspectTtlStWork.EnterpriseCode;
            // GUID
            inspectTtlSt.FileHeaderGuid = inspectTtlStWork.FileHeaderGuid;
            // 更新従業員コード
            inspectTtlSt.UpdEmployeeCode = inspectTtlStWork.UpdEmployeeCode;
            // 更新アセンブリID1
            inspectTtlSt.UpdAssemblyId1 = inspectTtlStWork.UpdAssemblyId1;
            // 更新アセンブリID2
            inspectTtlSt.UpdAssemblyId2 = inspectTtlStWork.UpdAssemblyId2;
            // 論理削除区分
            inspectTtlSt.LogicalDeleteCode = inspectTtlStWork.LogicalDeleteCode;
            // 拠点コード
            inspectTtlSt.SectionCode = inspectTtlStWork.SectionCode;
            // 取寄検品区分
            inspectTtlSt.OrderInspectCode = inspectTtlStWork.OrderInspectCode;
            return inspectTtlSt;
        }

        /// <summary>
        /// 検品全体設定設定読込処理(全社共通のみ)
        /// </summary>
        /// <param name="inspectTtlSt">読込結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note            : 検品全体設定設定の読み込み処理を行ないます。</br>
        /// <br>Programmer      : 3H 楊善娟</br>
        /// <br>Date            : K2017/06/02</br>
        /// </remarks>
        public int Read(out InspectTtlSt inspectTtlSt, string enterpriseCode)
        {
            int status = -1;

            try
            {
                inspectTtlSt = null;
                InspectTtlStWork inspectTtlStWork = new InspectTtlStWork();
                inspectTtlStWork.EnterpriseCode = enterpriseCode;
                inspectTtlStWork.SectionCode = "00";

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(inspectTtlStWork);

                // 検品全体設定読み込み
                status = this._iInspectTtlStDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XMLの読み込み
                    inspectTtlStWork = (InspectTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(InspectTtlStWork));
                    // クラス内メンバコピー
                    inspectTtlSt = CopyToInspectTtlStFromInspectTtlStWork(inspectTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                inspectTtlSt = null;
                //オフライン時はnullをセット
                this._iInspectTtlStDB = null;

                return -1;
            }
        }
    }
}
