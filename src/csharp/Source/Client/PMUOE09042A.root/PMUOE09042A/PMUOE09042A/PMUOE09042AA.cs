using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// UOE自社マスタ アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE自社マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2008.06.25</br>
    /// <br></br>
    /// </remarks>
    public class UOESettingAcs
    {
        #region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        // UOE自社マスタ
        private IUOESettingDB _iUOESettingDB = null;
        
        #endregion

        #region Constructor

        /// <summary>
        /// UOE自社マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE自社マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public UOESettingAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iUOESettingDB = (IUOESettingDB)MediationUOESettingDB.GetUOESettingDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOESettingDB = null;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iUOESettingDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// UOE自社マスタ読み込み処理
        /// </summary>
        /// <param name="uoeSetting">UOE自社オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : UOE自社情報を読み込みます。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public int Read(out UOESetting uoeSetting, string enterpriseCode, string sectionCode)
        {
            try
            {
                // キー情報の設定
                uoeSetting = null;
                UOESettingWork uoeSettingWork = new UOESettingWork();
                uoeSettingWork.EnterpriseCode = enterpriseCode;
                uoeSettingWork.SectionCode = sectionCode;
                // UOE自社ワーカークラスをオブジェクトに設定
                object paraObj = (object)uoeSettingWork;
                
                //UOE自社マスタ読み込み
                int status = this._iUOESettingDB.Read(ref paraObj, 0);

                if (status == 0)
                {
                    // 読み込み結果をUOE自社ワーカークラスに設定
                    UOESettingWork wkUOESettingWork = (UOESettingWork)paraObj;
                    // UOE自社ワーカークラスからUOE自社クラスにコピー
                    uoeSetting = CopyToUOESettingFromUOESettingWork(wkUOESettingWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOESettingDB = null;
                //通信エラーは-1を戻す
                uoeSetting = null;
                return -1;
            }
        }

        /// <summary>
        /// UOE自社シリアライズ処理
        /// </summary>
        /// <param name="uoeSetting">シリアライズ対象UOE自社クラス</param>
        /// <param name="fileName">シリアライズファイル名</param>
        /// <remarks>
        /// <br>Note       : UOE自社のシリアライズを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public void Serialize(UOESetting uoeSetting, string fileName)
        {
            // UOE自社クラスからUOE自社ワーカークラスにメンバコピー
            UOESettingWork uoeSettingWork = CopyToUOESettingWorkFromUOESetting(uoeSetting);

            // UOE自社ワーカークラスをシリアライズ
            XmlByteSerializer.Serialize(uoeSettingWork, fileName);
        }

        /// <summary>
        /// UOE自社Listシリアライズ処理
        /// </summary>
        /// <param name="arrUOESetting">シリアライズ対象UOE自社Listクラス</param>
        /// <param name="fileName">シリアライズファイル名</param>
        /// <remarks>
        /// <br>Note       : UOE自社List情報のシリアライズを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public void ListSerialize(ArrayList uoeSettingList, string fileName)
        {
            UOESettingWork[] uoeSettingWorks = new UOESettingWork[uoeSettingList.Count];

            for (int i = 0; i < uoeSettingList.Count; i++)
            {
                uoeSettingWorks[i] = CopyToUOESettingWorkFromUOESetting((UOESetting)uoeSettingList[i]);
            }

            // UOE自社ワーカークラスをシリアライズ
            XmlByteSerializer.Serialize(uoeSettingWorks, fileName);
        }

        /// <summary>
        /// UOE自社クラスデシリアライズ処理
        /// </summary>
        /// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
        /// <returns>UOE自社クラス</returns>
        /// <remarks>
        /// <br>Note       : UOE自社クラスをデシリアライズします。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public UOESetting Deserialize(string fileName)
        {
            UOESetting uoeSetting = null;

            // ファイル名を渡してUOE自社ワーククラスをデシリアライズする
            UOESettingWork uoeSettingWork = (UOESettingWork)XmlByteSerializer.Deserialize(fileName, typeof(UOESettingWork));

            // デシリアライズ結果をUOE自社クラスへコピー
            if (uoeSettingWork != null) uoeSetting = CopyToUOESettingFromUOESettingWork(uoeSettingWork);

            return uoeSetting;
        }

        /// <summary>
        /// UOE自社登録・更新処理
        /// </summary>
        /// <param name="uoeSetting">UOE自社クラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE自社の登録・更新を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public int Write(ref UOESetting uoeSetting)
        {
            UOESettingWork uoeSettingWork = new UOESettingWork();
            ArrayList paraList = new ArrayList();

            // UOE自社クラスからUOE自社ワーククラスにメンバコピー
            uoeSettingWork = CopyToUOESettingWorkFromUOESetting(uoeSetting);

            // UOE自社の登録・更新情報を設定
            paraList.Add(uoeSettingWork);
            
            object paraObj = paraList;

            int status = 0;
            try
            {
                // UOE自社書き込み
                status = this._iUOESettingDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;

                    uoeSetting = new UOESetting();

                    // UOE自社ワーククラスからUOE自社クラスにメンバコピー
                    uoeSetting = this.CopyToUOESettingFromUOESettingWork((UOESettingWork)paraList[0]);
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iUOESettingDB = null;
                // 通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// UOE自社論理削除処理
        /// </summary>
        /// <param name="uoeSettingList">UOE自社オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE自社情報の論理削除を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList uoeSettingList)
        {
            int status = 0;

            try
            {
                UOESettingWork uoeSettingWork = new UOESettingWork();
                ArrayList paraList = new ArrayList();

                foreach (UOESetting wkUOESetting in uoeSettingList)
                {
                    // UOE自社クラスからUOE自社ワーククラスにメンバコピー
                    uoeSettingWork = CopyToUOESettingWorkFromUOESetting(wkUOESetting);
                    // UOE自社の論理削除情報を設定
                    paraList.Add(uoeSettingWork);
                }

                object paraObj = paraList;

                // UOE自社クラス論理削除
                status = this._iUOESettingDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    uoeSettingList.Clear();

                    foreach (UOESettingWork wkUOESettingWork in paraList)
                    {
                        UOESetting uoeSetting = new UOESetting();
                        // UOE自社ワーククラスからUOE自社クラスにメンバコピー
                        uoeSetting = this.CopyToUOESettingFromUOESettingWork((UOESettingWork)wkUOESettingWork);
                        uoeSettingList.Add(uoeSetting);
                    }
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOESettingDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// UOE自社物理削除処理
        /// </summary>
        /// <param name="uoeSettingList">UOE自社オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE自社情報の物理削除を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public int Delete(ArrayList uoeSettingList)
        {
            try
            {
                UOESettingWork uoeSettingWork = new UOESettingWork();
                ArrayList paraList = new ArrayList();

                foreach (UOESetting wkUOESetting in uoeSettingList)
                {
                    // UOE自社クラスからUOE自社ワーククラスにメンバコピー
                    uoeSettingWork = CopyToUOESettingWorkFromUOESetting(wkUOESetting);

                    // UOE自社の登録・更新情報を設定
                    paraList.Add(uoeSettingWork);
                }

                object paraObj = paraList;

                // UOE自社物理削除
                int status = this._iUOESettingDB.Delete(paraObj);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOESettingDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// UOE自社論理削除復活処理
        /// </summary>
        /// <param name="uoeSettingList">UOE自社名称オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE自社情報の復活を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public int Revival(ref ArrayList uoeSettingList)
        {
            try
            {
                UOESettingWork uoeSettingWork = new UOESettingWork();
                ArrayList paraList = new ArrayList();

                foreach (UOESetting wkUOESetting in uoeSettingList)
                {
                    // UOE自社クラスからUOE自社ワーククラスにメンバコピー
                    uoeSettingWork = CopyToUOESettingWorkFromUOESetting(wkUOESetting);
                    // UOE自社の復活情報を設定
                    paraList.Add(uoeSettingWork);
                }

                object paraobj = paraList;

                // 復活処理
                int status = this._iUOESettingDB.RevivalLogicalDelete(ref paraobj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraobj;
                    uoeSettingList.Clear();

                    foreach (UOESettingWork wkUOESettingWork in paraList)
                    {
                        UOESetting uoeSetting = new UOESetting();
                        // UOE自社ワーククラスからUOE自社クラスにメンバコピー
                        uoeSetting = this.CopyToUOESettingFromUOESettingWork((UOESettingWork)wkUOESettingWork);
                        uoeSettingList.Add(uoeSetting);
                    }
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOESettingDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// UOE自社マスタ検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : UOE自社の全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.06.25</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            int retTotalCnt;
            bool nextData;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retTotalCnt = 0;

            status = SearchUOESetting(ref list, out retTotalCnt, out nextData, enterpriseCode, sectionCode, 0, 0);

            retList = list;

            return status;
        }

        /// <summary>
        /// UOE自社検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE自社の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retTotalCnt = 0;

            // UOE自社マスタ
            status = SearchUOESetting(ref list, out retTotalCnt, out nextData, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetDataAll, 0);

            retList = list;

            return status;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// クラスメンバーコピー処理（UOE自社ワーククラス⇒UOE自社クラス）
        /// </summary>
        /// <param name="partsPosCodeUWork">UOE自社ワーククラス</param>
        /// <returns>UOE自社クラス</returns>
        /// <remarks>
        /// <br>Note       : UOE自社ワーククラスからUOE自社クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private UOESetting CopyToUOESettingFromUOESettingWork(UOESettingWork uoeSettingWork)
        {
            UOESetting uoeSetting = new UOESetting();

            uoeSetting.CreateDateTime = uoeSettingWork.CreateDateTime;
            uoeSetting.UpdateDateTime = uoeSettingWork.UpdateDateTime;
            uoeSetting.EnterpriseCode = uoeSettingWork.EnterpriseCode;
            uoeSetting.FileHeaderGuid = uoeSettingWork.FileHeaderGuid;
            uoeSetting.UpdEmployeeCode = uoeSettingWork.UpdEmployeeCode;
            uoeSetting.UpdAssemblyId1 = uoeSettingWork.UpdAssemblyId1;
            uoeSetting.UpdAssemblyId2 = uoeSettingWork.UpdAssemblyId2;
            uoeSetting.LogicalDeleteCode = uoeSettingWork.LogicalDeleteCode;
            uoeSetting.SectionCode = uoeSettingWork.SectionCode;

            uoeSetting.SlipOutputDivCd = uoeSettingWork.SlipOutputDivCd;                // 伝票出力区分
            uoeSetting.FollowSlipOutputDiv = uoeSettingWork.FollowSlipOutputDiv;        // フォロー伝票出力区分
            uoeSetting.AddUpADateDiv = uoeSettingWork.AddUpADateDiv;                    // 計上日付区分
            uoeSetting.StockBlnktPrtNoDiv = uoeSettingWork.StockBlnktPrtNoDiv;          // 在庫一括品番区分
            uoeSetting.MakerFollowAddUpDiv = uoeSettingWork.MakerFollowAddUpDiv;        // メーカーフォロー計上区分
            uoeSetting.DistEnterDiv = uoeSettingWork.DistEnterDiv;                      // 卸商入庫更新区分
            uoeSetting.DistSectionSetDiv = uoeSettingWork.DistSectionSetDiv;            // 卸商拠点設定区分
            uoeSetting.InpSearchRemark = uoeSettingWork.InpSearchRemark;                // 手入力検索リマーク
            uoeSetting.StockBlnktRemark = uoeSettingWork.StockBlnktRemark;              // 在庫一括補充リマーク
            uoeSetting.SlipOutputRemark = uoeSettingWork.SlipOutputRemark;              // 伝発リマーク
            uoeSetting.SlipOutputRemarkDiv = uoeSettingWork.SlipOutputRemarkDiv;        // 伝発リマーク区分

            // 2008.12.24 30413 犬飼 UOE伝票発行区分を追加 >>>>>>START
            uoeSetting.UOESlipPrtDiv = uoeSettingWork.UOESlipPrtDiv;                    // UOE伝票発行区分
            // 2008.12.24 30413 犬飼 UOE伝票発行区分を追加 <<<<<<END

            return uoeSetting;
        }

        /// <summary>
        /// クラスメンバーコピー処理（UOE自社クラス⇒UOE自社ワーククラス）
        /// </summary>
        /// <param name="partsPosCodeU">UOE自社ワーククラス</param>
        /// <returns>UOE自社クラス</returns>
        /// <remarks>
        /// <br>Note       : UOE自社クラスからUOE自社ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private UOESettingWork CopyToUOESettingWorkFromUOESetting(UOESetting uoeSetting)
        {
            UOESettingWork uoeSettingWork = new UOESettingWork();

            uoeSettingWork.CreateDateTime = uoeSetting.CreateDateTime;
            uoeSettingWork.UpdateDateTime = uoeSetting.UpdateDateTime;
            uoeSettingWork.EnterpriseCode = uoeSetting.EnterpriseCode;
            uoeSettingWork.FileHeaderGuid = uoeSetting.FileHeaderGuid;
            uoeSettingWork.UpdEmployeeCode = uoeSetting.UpdEmployeeCode;
            uoeSettingWork.UpdAssemblyId1 = uoeSetting.UpdAssemblyId1;
            uoeSettingWork.UpdAssemblyId2 = uoeSetting.UpdAssemblyId2;
            uoeSettingWork.LogicalDeleteCode = uoeSetting.LogicalDeleteCode;
            uoeSettingWork.SectionCode = uoeSetting.SectionCode;

            uoeSettingWork.SlipOutputDivCd = uoeSetting.SlipOutputDivCd;                // 伝票出力区分
            uoeSettingWork.FollowSlipOutputDiv = uoeSetting.FollowSlipOutputDiv;        // フォロー伝票出力区分
            uoeSettingWork.AddUpADateDiv = uoeSetting.AddUpADateDiv;                    // 計上日付区分
            uoeSettingWork.StockBlnktPrtNoDiv = uoeSetting.StockBlnktPrtNoDiv;          // 在庫一括品番区分
            uoeSettingWork.MakerFollowAddUpDiv = uoeSetting.MakerFollowAddUpDiv;        // メーカーフォロー計上区分
            uoeSettingWork.DistEnterDiv = uoeSetting.DistEnterDiv;                      // 卸商入庫更新区分
            uoeSettingWork.DistSectionSetDiv = uoeSetting.DistSectionSetDiv;            // 卸商拠点設定区分
            uoeSettingWork.InpSearchRemark = uoeSetting.InpSearchRemark;                // 手入力検索リマーク
            uoeSettingWork.StockBlnktRemark = uoeSetting.StockBlnktRemark;              // 在庫一括補充リマーク
            uoeSettingWork.SlipOutputRemark = uoeSetting.SlipOutputRemark;              // 伝発リマーク
            uoeSettingWork.SlipOutputRemarkDiv = uoeSetting.SlipOutputRemarkDiv;        // 伝発リマーク区分

            // 2008.12.24 30413 犬飼 UOE伝票発行区分を追加 >>>>>>START
            uoeSettingWork.UOESlipPrtDiv = uoeSetting.UOESlipPrtDiv;                    // UOE伝票発行区分
            // 2008.12.24 30413 犬飼 UOE伝票発行区分を追加 <<<<<<END

            return uoeSettingWork;
        }

        /// <summary>
        /// UOE自社検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE自社の検索処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private int SearchUOESetting(ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, string sectionCode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            UOESettingWork uoeSettingWork = new UOESettingWork();

            // 次データ有無初期化
            nextData = false;
            // 読込対象データ総件数0で初期化
            retTotalCnt = 0;

            int status = 0;

            ArrayList workList = new ArrayList();
            object retObj = workList;

            if (retList.Count == 0)
            {
                // セキュリティレベルキー指定
                uoeSettingWork.EnterpriseCode = enterpriseCode;
                uoeSettingWork.SectionCode = sectionCode;

                // UOE自社ワーカークラスをオブジェクトに設定
                ArrayList list = new ArrayList();
                list.Add(uoeSettingWork);
                //object paraObj = (object)uoeSettingWork;
                object paraObj = list;

                // 全件読込
                status = this._iUOESettingDB.Search(ref retObj, paraObj, 0, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        workList = retObj as ArrayList;
                        if (workList != null)
                        {
                            foreach (UOESettingWork wkUOESettingWork in workList)
                            {
                                // リモートパラメータデータ ⇒ データクラス
                                UOESetting wkUOESetting = CopyToUOESettingFromUOESettingWork(wkUOESettingWork);
                                // データクラスを読込結果へコピー
                                retList.Add(wkUOESetting);
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        return status;
                }
            }

            // 全件リードの場合は戻り値の件数をセット
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        #endregion
    }
}
