using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 休業日設定マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 休業日設定マスタのアクセス制御を行います。</br>
    /// <br>Programmer  : NEPCO</br>
    /// <br>Date        : 2007.01.10</br>
    /// <br>------------------------------------------------------</br>
    /// <br>Update Note  : 2008.08.11  22018 鈴木正臣</br>
    /// <br>             : ①PM.NS向け変更。営業日算出モジュール機能を追加。</br>
    /// </remarks>
    public class HolidaySettingAcs
    {
        #region -- コンストラクタ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date       : 2007.01.10</br>
        /// </remarks>
        static HolidaySettingAcs()
        {
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date       : 2007.01.10</br>
        /// <br></br>
        /// </remarks>
        public HolidaySettingAcs()
        {
            // オンラインの場合
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // リモートオブジェクト取得
                    this._iHolidaySettingDB = (IHolidaySettingDB)MediationHolidaySettingDB.GetHolidaySettingDB();
                }
                catch (Exception)
                {
                    // オフライン時はnullをセット
                    this._iHolidaySettingDB = null;
                }
            }
            else
            // オフラインの場合
            {
                // オフライン時はnullをセット
                this._iHolidaySettingDB = null;
            }

            // 拠点情報取得用
            this._secInfoAcs = new SecInfoAcs();

        }
        #endregion

        #region -- リモートオブジェクト格納バッファ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// リモートオブジェクト格納バッファ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date       : 2007.01.10</br>
        /// </remarks>
        private IHolidaySettingDB _iHolidaySettingDB = null;

        // 拠点情報取得用
        private SecInfoAcs _secInfoAcs;

        #endregion

        #region -- オンラインモード 列挙型 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// オンラインモードの列挙型です。
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date       : 2007.01.10</br>
        /// </remarks>
        public enum OnlineMode
        {
            /// <summary>オフライン</summary>
            Offline,
            /// <summary>オンライン</summary>
            Online
        }
        #endregion

        #region -- オンラインモード取得処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date       : 2007.01.10</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iHolidaySettingDB == null)
            {
                return (int)OnlineMode.Offline;
            }
            else
            {
                return (int)OnlineMode.Online;
            }
        }
        #endregion

        #region -- 登録･更新処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="holidaySetting">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date       : 2007.01.10</br>
        /// </remarks>
        public int Write(ref ArrayList holidaySettings)
        {
            // UIデータクラス→ワーク
            HolidaySettingWork holidaySettingWork;
            ArrayList paraList = new ArrayList();
            foreach (HolidaySetting holidaySetting in holidaySettings)
            {
                holidaySettingWork = CopyToHolidaySettingWorkFromHolidaySetting(holidaySetting);
                paraList.Add(holidaySettingWork);
            }

            object paraobj = paraList;

            int status;
            try
            {
                // 書き込み処理
                status = this._iHolidaySettingDB.Write(ref paraobj);
                if (status != 0)
                {
                    return (status);
                }

                HolidaySetting holidaySetting2;
                holidaySettings.Clear();
                foreach (HolidaySettingWork holidaySettingWork2 in paraList)
                {
                    holidaySetting2 = CopyToHolidaySettingFromHolidaySettingWork(holidaySettingWork2);
                    holidaySettings.Add(holidaySetting2);
                }
            }
            catch (Exception)
            {
                // 通信エラーは-1を戻す
                status = -1;
            }
            return status;
        }

        #endregion

        #region -- 削除処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="holidaySetting">休業日設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 休業日設定の論理削除を行います。（未実装）</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date       : 2007.01.10</br>
        /// </remarks>
        public int LogicalDelete(ref HolidaySetting holidaySetting)
        {
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="holidaySetting">休業日設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 休業日設定の物理削除を行います。（未実装）</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date       : 2007.01.10</br>
        /// </remarks>
        public int Delete(ArrayList holidaySettings)
        {
            int status;

            try
            {
                // XMLへ変換
                HolidaySettingWork[] holidaySettingWorks = new HolidaySettingWork[holidaySettings.Count];
                HolidaySettingWork holidaySettingWork;
                for (int index = 0; index < holidaySettings.Count; index++)
                {
                    holidaySettingWork = CopyToHolidaySettingWorkFromHolidaySetting((HolidaySetting)holidaySettings[index]);
                    holidaySettingWorks[index] = holidaySettingWork;
                }
                byte[] parabyte = XmlByteSerializer.Serialize(holidaySettingWorks);

                // 削除実行
                status = this._iHolidaySettingDB.Delete(parabyte);
            }
            catch (Exception)
            {
                // 通信エラーは-1を返す
                status = -1;
            }

            return (status);

        }
        #endregion

        #region -- 検索･復活処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 休業日設定全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 休業日設定の全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date       : 2007.01.10</br>
        /// </remarks>
        public int Search(
            out ArrayList retList, 
            string enterpriseCode,
            string sectionCode,
            DateTime applyStaDate,
            DateTime applyEndDate)
        {
            return (SearchProc(out retList, enterpriseCode, sectionCode, applyStaDate, applyEndDate, ConstantManagement.LogicalMode.GetData0));
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 休業日設定検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 休業日設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date       : 2007.01.10</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 件数指定休業日設定検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevCSlpPrtSetがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="readCnt">読込件数</param>		
        /// <param name="prevHolidaySetting">前回最終休業日設定データオブジェクト（初回はnull指定必須）</param>			
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 件数を指定して休業日設定の検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date       : 2007.01.10</br>
        /// </remarks>
        public int SearchSpecificationAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, HolidaySetting prevHolidaySetting)
        {
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, readCnt, prevHolidaySetting);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 休業日設定論理削除復活処理
        /// </summary>
        /// <param name="holidaySetting">休業日設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 休業日設定の復活を行います。（未実装）</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date       : 2007.01.10</br>
        /// </remarks>
        public int Revival(ref HolidaySetting holidaySetting)
        {
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 休業日設定検索処理
        /// </summary>
        /// <param name="holidaySettingDic">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCodeList">拠点コードリスト</param>
        /// <param name="applyStaDate">適用期間(開始)</param>
        /// <param name="applyEndDate">適用期間(終了)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 休業日設定の検索処理を行います。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date       : 2007.07.12</br>
        /// </remarks>
        public int SearchSecList(
            out Dictionary<SectionAndDate, HolidaySetting> holidaySettingDic,
            string enterpriseCode,
            string[] sectionCodeList,
            DateTime applyStaDate,
            DateTime applyEndDate)
        {
            // 検索条件設定
            HolidaySettingSearchWork holidaySettingSearchWork = new HolidaySettingSearchWork();
            holidaySettingSearchWork.EnterpriseCode = enterpriseCode;
            holidaySettingSearchWork.SectionCodeList = sectionCodeList;
            holidaySettingSearchWork.ApplyStaDate = applyStaDate;
            holidaySettingSearchWork.ApplyEndDate = applyEndDate;

            int status;

            holidaySettingDic = new Dictionary<SectionAndDate, HolidaySetting>();

            ArrayList getList;

            if (!LoginInfoAcquisition.OnlineFlag)
            {
                return (int)ConstantManagement.DB_Status.ctDB_OFFLINE;
            }
            else
            {
                HolidaySetting holidaySetting = new HolidaySetting();
                object objectHolidaySettingWork = null;

                try
                {
                    // 休業日設定マスタ検索
                    status = this._iHolidaySettingDB.SearchSecList(out objectHolidaySettingWork, holidaySettingSearchWork, 0, ConstantManagement.LogicalMode.GetData0);
                    if (status != 0)
                    {
                        return status;
                    }

                    // 検索結果格納
                    getList = (ArrayList)objectHolidaySettingWork;
                    SectionAndDate sectionAndDate;
                    foreach (HolidaySettingWork holidaySettingWork in getList)
                    {
                        // データを変換
                        holidaySetting = CopyToHolidaySettingFromHolidaySettingWork(holidaySettingWork);

                        // サーチ結果取得
                        sectionAndDate = new SectionAndDate(holidaySetting.SectionCode, holidaySetting.ApplyDate);
                        holidaySettingDic.Add(sectionAndDate, holidaySetting);
                    }

                    return (0);

                }
                catch (Exception)
                {
                    // 通信エラーは-1を返す
                    return (-1);
                }
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 休業日設定検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>  
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevHolidaySetting">前回最終休業日設定データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 休業日設定の検索処理を行います。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date       : 2007.01.10</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, HolidaySetting prevHolidaySetting)
        {
            HolidaySettingWork holidaySettingWork = new HolidaySettingWork();
            if (prevHolidaySetting != null)
            {
                holidaySettingWork = CopyToHolidaySettingWorkFromHolidaySetting(prevHolidaySetting);
            }
            holidaySettingWork.EnterpriseCode = enterpriseCode;

            int status;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();
            ArrayList paraList = new ArrayList();

            try
            {
                // オフラインの場合はキャッシュから読む
                if (!LoginInfoAcquisition.OnlineFlag)
                {
                    return ((int)ConstantManagement.DB_Status.ctDB_OFFLINE);
                }
                else
                {
                    HolidaySetting holidaySetting = new HolidaySetting();
                    object objectHolidaySettingWork = null;

                    // 休業日設定マスタ検索
                    status = this._iHolidaySettingDB.Search(out objectHolidaySettingWork, holidaySettingWork, 0, logicalMode);
                    if (status == 0)
                    {
                        // パラメータが渡って来ているか確認
                        paraList = objectHolidaySettingWork as ArrayList;
                        HolidaySettingWork[] wkHolidaySettingWork = new HolidaySettingWork[paraList.Count];

                        // データを元に戻す
                        for (int i = 0; i < paraList.Count; i++)
                        {
                            wkHolidaySettingWork[i] = (HolidaySettingWork)paraList[i];
                        }
                        for (int i = 0; i < wkHolidaySettingWork.Length; i++)
                        {
                            holidaySetting = CopyToHolidaySettingFromHolidaySettingWork(wkHolidaySettingWork[i]);
                            // サーチ結果取得
                            retList.Add(holidaySetting);
                        }
                    }
                }
                //全件リードの場合は戻り値の件数をセット
                if (readCnt == 0)
                {
                    retTotalCnt = retList.Count;
                }
            }
            catch (Exception)
            {
                // 通信エラーは-1を返す
                status = -1;
            }

            return status;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 休業日設定検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="applyStaDate">適用期間(開始)</param>
        /// <param name="applyEndDate">適用期間(終了)</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 休業日設定の検索処理を行います。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date       : 2007.01.10</br>
        /// </remarks>
        private int SearchProc(
            out ArrayList retList,
            string enterpriseCode,
            string sectionCode,
            DateTime applyStaDate,
            DateTime applyEndDate,
            ConstantManagement.LogicalMode logicalMode)
        {
            // 検索条件設定
            HolidaySettingWork holidaySettingWork = new HolidaySettingWork();
            holidaySettingWork.EnterpriseCode = enterpriseCode;
            holidaySettingWork.SectionCode = sectionCode;
            holidaySettingWork.ApplyStaDate = applyStaDate;
            holidaySettingWork.ApplyEndDate = applyEndDate;

            int status;

            retList = new ArrayList();
            retList.Clear();
            ArrayList getList;

            try
            {
                if (!LoginInfoAcquisition.OnlineFlag)
                {
                    return ((int)ConstantManagement.DB_Status.ctDB_OFFLINE);
                }
                else
                {
                    HolidaySetting holidaySetting = new HolidaySetting();
                    object objectHolidaySettingWork = null;

                    // 休業日設定マスタ検索
                    status = this._iHolidaySettingDB.Search(out objectHolidaySettingWork, holidaySettingWork, 0, logicalMode);
                    if (status != 0)
                    {
                        return status;
                    }

                    getList = (ArrayList)objectHolidaySettingWork;
                    foreach (HolidaySettingWork holidaySettingWork2 in getList)
                    {
                        // データを変換
                        holidaySetting = CopyToHolidaySettingFromHolidaySettingWork(holidaySettingWork2);

                        // サーチ結果取得
                        retList.Add(holidaySetting);
                    }

                    return (0);

                }
            }
            catch (Exception ex)
            {
                string x = ex.Message;

                // 通信エラーは-1を返す
                return (-1);
            }
        }

        #endregion

        #region -- クラスメンバーコピー処理 --
        /*----------------------------------------------------------------------------------*/
		/// <summary>
		/// クラスメンバーコピー処理（休業日設定ワーククラス⇒休業日設定クラス）
		/// </summary>
		/// <param name="holidaySettingWork">休業日設定ワーククラス</param>
		/// <returns>休業日設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 休業日設定ワーククラスから休業日設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : NEPCO</br>
		/// <br>Date       : 2007.01.10</br>
		/// </remarks>
		private HolidaySetting CopyToHolidaySettingFromHolidaySettingWork(HolidaySettingWork holidaySettingWork)
		{
			HolidaySetting holidaySetting = new HolidaySetting();

            holidaySetting.CreateDateTime = holidaySettingWork.CreateDateTime;
            holidaySetting.UpdateDateTime = holidaySettingWork.UpdateDateTime;
            holidaySetting.EnterpriseCode = holidaySettingWork.EnterpriseCode;
            holidaySetting.FileHeaderGuid = holidaySettingWork.FileHeaderGuid;
            holidaySetting.UpdEmployeeCode = holidaySettingWork.UpdEmployeeCode;
            holidaySetting.UpdAssemblyId1 = holidaySettingWork.UpdAssemblyId1;
            holidaySetting.UpdAssemblyId2 = holidaySettingWork.UpdAssemblyId2;
            holidaySetting.LogicalDeleteCode = holidaySettingWork.LogicalDeleteCode;
            holidaySetting.SectionCode = holidaySettingWork.SectionCode;

            holidaySetting.ApplyDate = holidaySettingWork.ApplyDate;
            holidaySetting.ApplyDateCd = holidaySettingWork.ApplyDateCd;
            holidaySetting.SectionName = GetSectionName(holidaySettingWork.EnterpriseCode, holidaySettingWork.SectionCode);

			return holidaySetting;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// クラスメンバーコピー処理（休業日設定クラス⇒休業日設定ワーククラス）
		/// </summary>
		/// <param name="holidaySetting">休業日設定クラス</param>
		/// <returns>車販書類全体設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 休業日設定クラスから休業日設定ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : NEPCO</br>
		/// <br>Date       : 2007.01.10</br>
		/// </remarks>
		private HolidaySettingWork CopyToHolidaySettingWorkFromHolidaySetting(HolidaySetting holidaySetting)
		{
			HolidaySettingWork holidaySettingWork = new HolidaySettingWork();

            holidaySettingWork.CreateDateTime = holidaySetting.CreateDateTime;
            holidaySettingWork.UpdateDateTime = holidaySetting.UpdateDateTime;
            holidaySettingWork.EnterpriseCode = holidaySetting.EnterpriseCode;
            holidaySettingWork.FileHeaderGuid = holidaySetting.FileHeaderGuid;
            holidaySettingWork.UpdEmployeeCode = holidaySetting.UpdEmployeeCode;
            holidaySettingWork.UpdAssemblyId1 = holidaySetting.UpdAssemblyId1;
            holidaySettingWork.UpdAssemblyId2 = holidaySetting.UpdAssemblyId2;
            holidaySettingWork.LogicalDeleteCode = holidaySetting.LogicalDeleteCode;
            holidaySettingWork.SectionCode = holidaySetting.SectionCode;

            holidaySettingWork.ApplyDate = holidaySetting.ApplyDate;
            holidaySettingWork.ApplyDateCd = holidaySetting.ApplyDateCd;
			
			return holidaySettingWork;
		}
		#endregion
		
		#region -- 対象データチェック、名称取得 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 拠点名称取得
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>拠点名称</returns>
		/// <remarks>
		/// <br>Note       : 拠点コードから拠点名称を取得します。</br>
		/// <br>Programmer : NEPCO</br>
		/// <br>Date       : 2007.01.10</br>
		/// </remarks>
        public string GetSectionName(string enterpriseCode, string sectionCode)
        {
            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.SectionCode.TrimEnd() == "0")
                {
                    return "未登録";
                }
                else if ((secInfoSet.SectionCode.TrimEnd() == sectionCode.TrimEnd()) &&
                    (secInfoSet.LogicalDeleteCode == 0))
                {
                    return secInfoSet.SectionGuideNm;
                }
            }
            return "未登録";

        }
        #endregion

        # region [営業日算出モジュール機能]

        # region [休業日リモート取得済KEY]
        /// <summary>
        /// 休業日リモート取得済KEY
        /// </summary>
        private struct HolidaySelectedKey
        {
            /// <summary>拠点コード</summary>
            private string _sectionCode;
            /// <summary>年</summary>
            private int _year;
            /// <summary>
            /// 拠点コード
            /// </summary>
            public string sectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>
            /// 年
            /// </summary>
            /// <remarks>年度ではない</remarks>
            public int year
            {
                get { return _year; }
                set { _year = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="sectionCode">拠点コード</param>
            /// <param name="year">年</param>
            public HolidaySelectedKey( string sectionCode, int year )
            {
                _sectionCode = sectionCode;
                _year = year;
            }
        }
        # endregion

        # region [private フィールド（営業日算出用）]
        private static Dictionary<HolidaySelectedKey, bool> _selectedDic;
        private static DataTable _holidayTable;

        private const string ct_col_SectionCode = "SectionCode";
        private const string ct_col_Date = "Date";
        # endregion

        # region [営業日算出 共通機能]
        /// <summary>
        /// 営業日算出処理 初期化処理
        /// </summary>
        private void WorkDayProcInitialize()
        {
            if ( _selectedDic == null )
            {
                _selectedDic = new Dictionary<HolidaySelectedKey, bool>();
                _holidayTable = CreateHolidayTable();
            }
            else
            {
                // 初期化済みなら何もしない
            }
        }
        /// <summary>
        /// 休日テーブル生成
        /// </summary>
        /// <returns></returns>
        private DataTable CreateHolidayTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add( new DataColumn( ct_col_SectionCode, typeof( string ) ) );
            table.Columns.Add( new DataColumn( ct_col_Date, typeof( Int32 ) ) );

            return table;
        }
        /// <summary>
        /// 営業日取得用　リモート取得処理
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="year"></param>
        /// <returns>STATUS</returns>
        private int SearchForWorkDay( string sectionCode, int year )
        {
            int status;

            // 取得済みディクショナリに無い場合のみ処理する
            if ( !_selectedDic.ContainsKey( new HolidaySelectedKey( sectionCode, year ) ) )
            {
                if ( _iHolidaySettingDB == null )
                {
                    _iHolidaySettingDB = MediationHolidaySettingDB.GetHolidaySettingDB();
                }

                // リモート呼び出し条件
                HolidaySettingWork paraWork = new HolidaySettingWork();
                paraWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                paraWork.SectionCode = sectionCode;
                // 日付範囲は yyyy.01.01～yyyy.12.31 とする。
                paraWork.ApplyStaDate = new DateTime( year, 1, 1 );
                paraWork.ApplyEndDate = new DateTime( year, 12, 31 );
                
                
                // リモート呼び出し
                object retObj;
                int dbStatus = _iHolidaySettingDB.Search( out retObj, paraWork, 0, ConstantManagement.LogicalMode.GetData0 );

                if ( dbStatus != (int)ConstantManagement.DB_Status.ctDB_ERROR )
                {
                    // 取得済みディクショナリに追加
                    _selectedDic.Add( new HolidaySelectedKey( sectionCode, year ), true );

                    // テーブルに追加
                    ArrayList retList = (ArrayList)retObj;
                    foreach ( HolidaySettingWork work in retList )
                    {
                        DataRow row = _holidayTable.NewRow();
                        row[ct_col_SectionCode] = work.SectionCode;
                        row[ct_col_Date] = GetLongDate( work.ApplyDate );
                        _holidayTable.Rows.Add( row );
                    }
                    // 正常終了
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    // DBエラーが発生した場合はエラーを返す。
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            else
            {
                // ディクショナリに登録済みならば、正常終了とみなす。
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }
        /// <summary>
        /// LongDate取得処理
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private int GetLongDate( DateTime dt )
        {
            if ( dt != DateTime.MinValue )
            {
                return (dt.Year * 10000) + (dt.Month * 100) + (dt.Day);
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 指定範囲内の休日数取得処理
        /// </summary>
        /// <param name="sectionCode">対象拠点コード</param>
        /// <param name="stDate">開始日</param>
        /// <param name="edDate">終了日</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// 開始日、終了日を含めた範囲で休日数を求めます。
        /// </remarks>
        private int GetHolidayInRange( string sectionCode, DateTime stDate, DateTime edDate, out int holidayCount )
        {
            int status;
            holidayCount = 0;

            // 開始日→休業日検索(キャッシュ)
            status = SearchForWorkDay( sectionCode, stDate.Year );
            if ( status != 0 ) return status;

            // 終了日→休業日検索(キャッシュ)
            status = SearchForWorkDay( sectionCode, edDate.Year );
            if ( status != 0 ) return status;

            // ビューを生成
            DataView view = new DataView( _holidayTable );
            view.RowFilter = string.Format( "{0}='{1}' AND {2}>='{3}' AND {2}<='{4}'",
                                            ct_col_SectionCode, sectionCode,
                                            ct_col_Date, GetLongDate( stDate ), GetLongDate( edDate ) );
            // 件数を返す
            holidayCount = view.Count;
            return status;
        }
        # endregion

        # region [①指定日数後の営業日 取得]
        /// <summary>
        /// 指定日数後の営業日 取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="baseDate">基準日</param>
        /// <param name="addDays">加算日数(マイナス可)</param>
        /// <param name="resultDate">(出力)結果日付</param>
        /// <returns>STATUS</returns>
        public int GetWorkDayAfterDays( string sectionCode, DateTime baseDate, int addDays, out DateTime resultDate )
        {
            return GetWorkDayAfterDaysProc( sectionCode, baseDate, addDays, out resultDate );
        }
        /// <summary>
        /// 指定日数後の営業日 取得
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="baseDate"></param>
        /// <param name="addDays"></param>
        /// <param name="resultDate"></param>
        /// <returns>STATUS</returns>
        private int GetWorkDayAfterDaysProc( string sectionCode, DateTime baseDate, int addDays, out DateTime resultDate )
        {
            // 初期処理
            WorkDayProcInitialize();

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            resultDate = DateTime.MinValue;

            //-----------------------------------------------------
            // □:営業日, ■:休業日
            // 
            // ①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰
            // □■■□□■□□■■□□□□□■■
            // 　＜－－－－－＞
            // 　　　　　　　　＜－＞
            // 　　　　　　　　　　　＜＞
            // ・開始日＋１～開始日＋Ｎの範囲で、休日数を求める。→３
            // ・終了日＋１～終了日＋休日数の範囲で、休日数を求める。→２
            // ・範囲内の休日数がゼロになるまで繰り返す。（休日数は必ず収束する）
            //-----------------------------------------------------

            if ( addDays > 0 )
            {
                //-----------------------------------------------------
                // 日付＋
                //-----------------------------------------------------
                # region [+]
                int holidayCount = 0;

                DateTime stDate = baseDate.AddDays( 1 );
                DateTime edDate = baseDate.AddDays( addDays );  // プラス

                while ( true )
                {
                    // 範囲内の休日の数を求める
                    status = GetHolidayInRange( sectionCode, stDate, edDate, out holidayCount );
                    if (status != 0)
                    {
                        // エラー発生
                        break;
                    }
                    if ( holidayCount == 0 ) 
                    {
                        // 範囲内に休日が無くなったら終了
                        break;
                    }
                    // 範囲内の休日の数で、次の検索範囲を決める
                    stDate = edDate.AddDays( 1 );
                    edDate = edDate.AddDays( holidayCount );
                }
                # endregion

                // 終了日を返す
                resultDate = edDate;
            }
            else if ( addDays < 0 )
            {
                //-----------------------------------------------------
                // 日付－
                //-----------------------------------------------------
                # region [-]
                int holidayCount = 0;

                DateTime stDate = baseDate.AddDays( addDays );  // マイナス
                DateTime edDate = baseDate.AddDays( -1 );

                while ( true )
                {
                    // 範囲内の休日の数を求める
                    status = GetHolidayInRange( sectionCode, stDate, edDate, out holidayCount );
                    if ( status != 0 )
                    {
                        // エラー発生
                        break;
                    }
                    if ( holidayCount == 0 )
                    {
                        // 範囲内に休日が無くなったら終了
                        break;
                    }
                    // 範囲内の休日の数で、次の検索範囲を決める
                    stDate = stDate.AddDays( -holidayCount );
                    edDate = stDate.AddDays( -1 );
                }
                # endregion

                // 開始日を返す
                resultDate = stDate;
            }
            else
            {
                //-----------------------------------------------------
                // 同じ日（但し、休日でも無視する）
                //-----------------------------------------------------
                resultDate = baseDate;
            }

            return status;
        }
        # endregion

        # region [②営業日数差分 取得]
        /// <summary>
        /// 営業日数差分 取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="baseDate">基準日</param>
        /// <param name="checkDate">判定日</param>
        /// <param name="difference">(出力)差分</param>
        /// <returns>STATUS</returns>
        public int GetWorkDaysDifference( string sectionCode, DateTime baseDate, DateTime checkDate, out int difference )
        {
            return GetWorkDaysDifferenceProc( sectionCode, baseDate, checkDate, out difference );
        }
        /// <summary>
        /// 営業日数差分 取得
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="baseDate"></param>
        /// <param name="checkDate"></param>
        /// <param name="difference"></param>
        /// <returns></returns>
        private int GetWorkDaysDifferenceProc( string sectionCode, DateTime baseDate, DateTime checkDate, out int difference )
        {
            // 初期処理
            WorkDayProcInitialize();

            DateTime stDate;
            DateTime edDate;

            int sign = 1;

            if ( baseDate < checkDate )
            {
                // base < check
                stDate = baseDate;
                edDate = checkDate;
                sign = 1;
            }
            else if ( checkDate < baseDate )
            {
                // check < base
                stDate = checkDate;
                edDate = baseDate;
                sign = -1;
            }
            else
            {
                // 同じ日
                difference = 0;
                return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            // タイムスパンを求める
            TimeSpan span = edDate.Subtract( stDate );
            
            // 休日の数を求める
            int holidayCount;
            int status = GetHolidayInRange( sectionCode, stDate, edDate, out holidayCount );
            if ( status != 0 )
            {
                holidayCount = 0;
            }

            // 何日後の営業日かを返す ( ( 1 or -1 ) * (日数の差 - 休日数) )
            difference = sign * (span.Days - holidayCount);

            return status;
        }
        # endregion

        # region [③月度の総営業日数 取得]
        /// <summary>
        /// 月度の総営業日数 取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="checkDate">指定日</param>
        /// <param name="workDaysInMonth">月度内営業日数</param>
        /// <param name="progress">経過日数(月初～指定日)</param>
        /// <returns>STATUS</returns>
        public int GetWorkDaysInMonth( string sectionCode, DateTime checkDate, out int workDaysInMonth, out int progress )
        {
            decimal progressRate;
            return GetWorkDaysInMonthProc( sectionCode, checkDate, out workDaysInMonth, out progress, out progressRate );
        }
        /// <summary>
        /// 月度の総営業日数 取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="checkDate">指定日</param>
        /// <param name="workDaysInMonth">月度内営業日数</param>
        /// <param name="progress">経過日数(月初～指定日)</param>
        /// <param name="progressRate">経過率</param>
        /// <returns>STATUS</returns>
        public int GetWorkDaysInMonth( string sectionCode, DateTime checkDate, out int workDaysInMonth, out int progress, out decimal progressRate )
        {
            return GetWorkDaysInMonthProc( sectionCode, checkDate, out workDaysInMonth, out progress, out progressRate );
        }
        /// <summary>
        /// 月度の総営業日数 取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="checkDate">指定日</param>
        /// <param name="progressRate">経過率</param>
        /// <returns>STATUS</returns>
        public int GetWorkDaysInMonth( string sectionCode, DateTime checkDate, out decimal progressRate )
        {
            int workDaysInMonth;
            int progress;
            return GetWorkDaysInMonthProc( sectionCode, checkDate, out workDaysInMonth, out progress, out progressRate );
        }
        /// <summary>
        /// 月度の総営業日数 取得(1)
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="checkDate"></param>
        /// <param name="workDaysInMonth"></param>
        /// <param name="progress"></param>
        /// <param name="progressRate"></param>
        /// <returns></returns>
        private int GetWorkDaysInMonthProc( string sectionCode, DateTime checkDate, out int workDaysInMonth, out int progress, out decimal progressRate )
        {
            int retStatus = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // 共通初期化
            WorkDayProcInitialize();

            //---------------------------------------------------
            // 日付取得部品(UI版)
            //---------------------------------------------------
            DateGetAcs dateGet = DateGetAcs.GetInstance();
            DateTime yearMonth;         // ←読み捨て用
            int year;                   // ←読み捨て用
            DateTime startMonthDate;
            DateTime endMonthDate;
            // checkDateの属する月度の開始日・終了日を得る。
            dateGet.GetYearMonth( checkDate, out yearMonth, out year, out startMonthDate, out endMonthDate );

            //---------------------------------------------------
            // 営業日数取得（月初～月末）
            //---------------------------------------------------
            int holidayCountInMonth;    // ←読み捨て用
            int status = GetWorkDaysInRangeProc( sectionCode, startMonthDate, endMonthDate, out workDaysInMonth, out holidayCountInMonth );
            if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                retStatus = status;
            }

            //---------------------------------------------------
            // 営業日数取得（月初～指定日）
            //---------------------------------------------------
            int holidayCount;           // ←読み捨て用 
            status = GetWorkDaysInRangeProc( sectionCode, startMonthDate, checkDate, out progress, out holidayCount );
            if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                retStatus = status;
            }


            // 経過率算出
            progressRate = (decimal)progress / (decimal)workDaysInMonth;

            // STATUS返却
            return retStatus;
        }
        # endregion

        # region [③'月度の総営業日数 取得（月度指定）]
        /// <summary>
        /// 月度の総営業日数 取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="checkMonth">指定月</param>
        /// <param name="workDaysInMonth">月度内営業日数</param>
        /// <param name="progress">経過日数(月初～指定日)</param>
        /// <returns>STATUS</returns>
        public int GetWorkDaysInMonth( string sectionCode, DateTime checkMonth, out int workDaysInMonth )
        {
            return GetWorkDaysInMonthProcForMonth( sectionCode, checkMonth, out workDaysInMonth );
        }
        /// <summary>
        /// 月度の総営業日数 取得(2)
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="checkMonth"></param>
        /// <param name="workDaysInMonth"></param>
        /// <returns></returns>
        private int GetWorkDaysInMonthProcForMonth( string sectionCode, DateTime checkMonth, out int workDaysInMonth )
        {
            int retStatus = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // 共通初期化
            WorkDayProcInitialize();

            //---------------------------------------------------
            // 日付取得部品(UI版)
            //---------------------------------------------------
            DateGetAcs dateGet = DateGetAcs.GetInstance();
            DateTime startMonthDate;
            DateTime endMonthDate;
            // checkMonth(月度)の開始日・終了日を得る。
            dateGet.GetDaysFromMonth( checkMonth, out startMonthDate, out endMonthDate );

            //---------------------------------------------------
            // 営業日数取得（月初～月末）
            //---------------------------------------------------
            int holidayCountInMonth;    // ←読み捨て用
            int status = GetWorkDaysInRangeProc( sectionCode, startMonthDate, endMonthDate, out workDaysInMonth, out holidayCountInMonth );
            if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                retStatus = status;
            }

            // STATUS返却
            return retStatus;
        }
        # endregion

        # region [④営業日チェック処理]
        /// <summary>
        /// 営業日チェック処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="checkDate">判定日</param>
        /// <returns>true:営業日, false:休業日</returns>
        public bool CheckWorkDay( string sectionCode, DateTime checkDate )
        {
            return CheckWorkDayProc( sectionCode, checkDate );
        }
        /// <summary>
        /// 営業日チェック処理
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        private bool CheckWorkDayProc( string sectionCode, DateTime checkDate )
        {
            // 初期処理
            WorkDayProcInitialize();

            // 検索
            int status = SearchForWorkDay( sectionCode, checkDate.Year );
            if ( status != 0 )
            {
                // エラー時はtrueを返す
                return true;
            }

            // ビューを生成
            DataView view = new DataView( _holidayTable );
            view.RowFilter = string.Format( "{0}='{1}' AND {2}='{3}'",
                                            ct_col_SectionCode, sectionCode,
                                            ct_col_Date, GetLongDate( checkDate ) );

            if ( view.Count > 0 )
            {
                // レコードがある＝休業日(false)
                return false;
            }
            else
            {
                // レコードがない＝営業日(true)
                return true;
            }
        }
        # endregion

        # region [⑤指定範囲内の営業日数 取得]
        /// <summary>
        /// 指定範囲内の営業日数取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="startDate">開始日付</param>
        /// <param name="endDate">終了日付</param>
        /// <param name="workDaysCount">営業日数</param>
        /// <returns>STATUS</returns>
        public int GetWorkDaysInRange( string sectionCode, DateTime startDate, DateTime endDate, out int workDaysCount )
        {
            int holidayCount;
            return GetWorkDaysInRangeProc( sectionCode, startDate, endDate, out workDaysCount, out holidayCount );
        }
        /// <summary>
        /// 指定範囲内の営業日数取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="startDate">開始日付</param>
        /// <param name="endDate">終了日付</param>
        /// <param name="workDaysCount">営業日数</param>
        /// <param name="holidayCount">休業日数</param>
        /// <returns>STATUS</returns>
        public int GetWorkDaysInRange( string sectionCode, DateTime startDate, DateTime endDate, out int workDaysCount, out int holidayCount )
        {
            return GetWorkDaysInRangeProc( sectionCode, startDate, endDate, out workDaysCount, out holidayCount );
        }
        /// <summary>
        /// 指定範囲内の営業日数取得
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="workDaysCount"></param>
        /// <param name="holidayCount"></param>
        /// <returns></returns>
        private int GetWorkDaysInRangeProc( string sectionCode, DateTime startDate, DateTime endDate, out int workDaysCount, out int holidayCount )
        {
            // 共通初期化処理
            WorkDayProcInitialize();

            // 休業日数取得
            int status = GetHolidayInRange( sectionCode, startDate, endDate, out holidayCount );
            if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                // エラー発生したら休日数＝ゼロで処理続行(最後にSTATUSはエラーで返す)
                holidayCount = 0;
            }

            // タイムスパン取得
            startDate = startDate.Date;
            endDate = endDate.Date;
            TimeSpan ts = endDate.Subtract( startDate );

            // 営業日数取得 ( 総日数 - 休業日 )
            workDaysCount = (ts.Days + 1) - holidayCount;

            return status;
        }
        # endregion


        # endregion
    }

    #region Structures

    /// <summary>
    /// 拠点コードと日付
    /// </summary>
    public struct SectionAndDate
    {
        public string SectionCode;
        public DateTime Date;

        public SectionAndDate(string sectionCode, DateTime date)
        {
            this.SectionCode = sectionCode;
            this.Date = date;
        }
    }

    #endregion

}
