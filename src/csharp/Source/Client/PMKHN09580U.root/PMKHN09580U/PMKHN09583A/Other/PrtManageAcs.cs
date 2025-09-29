//****************************************************************************//
// システム         : プリンタ設定マスタ（サーバ用）
// プログラム名称   : プリンタ設定マスタ（サーバ用）コントローラ
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/09/16  修正内容 : 新規作成（SFCMN09202Aを移植およびアレンジ）
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using Broadleaf.Application.UIData.Other;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller.Other
{
	/// <summary>
    /// プリンタ管理マスタアクセスクラス
	/// </summary>
	public sealed class PrtManageAcs
	{
        #region <設定ファイル>

        /// <summary>XMLファイル名</summary>
		private const string FILE_NAME = "PrtManage.xml";

        /// <summary>XMLファイルパス</summary>
        private readonly static string _filePath =Path.Combine(HomePath, FILE_NAME);
        /// <summary>XMLファイルパスを取得します。</summary>
        private static string FilePath {  get { return _filePath; } }

        /// <summary>
        /// ホームパスを取得します。
        /// </summary>
        private static string HomePath
        {
            get { return ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData; }
        }

        #endregion // </設定ファイル>

        #region <キャッシュ>

        /// <summary>データバッファ</summary>
        private static ArrayList _prtManageBufferList;
        private static ArrayList PrtManageBufferList
        {
            get { return _prtManageBufferList; }
            set { _prtManageBufferList = value; }
        }

        private static ArrayList _logicalPrtManageBufferList;
        private static ArrayList LogicalPrtManageBufferList
        {
            get { return _logicalPrtManageBufferList; }
            set { _logicalPrtManageBufferList = value; }
        }

        #endregion // <キャッシュ>

        #region <Constructor>

        /// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public PrtManageAcs() { }

        #endregion // </Constructor>

        #region <読み>

        /// <summary>
		/// プリンタ管理読み込み処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="printerMngNo">プリンタ管理No</param>
		/// <param name="prtManage">プリンタ管理オブジェクト</param>
		/// <returns>プリンタ管理クラス</returns>
		public int Read(
            string enterpriseCode,
            int printerMngNo,
            out PrtManage prtManage
        )
		{			
			prtManage = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			try
            {
                // データ比較用パラメータ
                PrtManage prtManagePara = new PrtManage();
                {
                    prtManagePara.EnterpriseCode= enterpriseCode;
                    prtManagePara.PrinterMngNo  = printerMngNo;
                }
                // XMLの読み込み
                PrtManage[] prtManages = DeserializeHybridXML();
                {
                    foreach (PrtManage enmPrtManage in prtManages)
                    {
                        if (enmPrtManage.CompareTo(prtManagePara).Equals(0))
                        {
                            prtManage = enmPrtManage.Clone();
                            break;
                        }
                    }
                    if (prtManage == null || prtManages.Length.Equals(0))
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                return status;
            }
			catch (FileNotFoundException ex)
			{
                Debug.WriteLine(ex.ToString());
                Debug.Assert(false, ex.ToString());

				return (int)ConstantManagement.DB_Status.ctDB_EOF;
			}
			catch (Exception ex)
			{
                Debug.WriteLine(ex.ToString());
                Debug.Assert(false, ex.ToString());

				prtManage = null;
                return -1;  // 通信エラーは-1を戻す
			}
		}

        /// <summary>
        /// XMLからプリンタ設定クラスへデシリアライズします。
        /// </summary>
        /// <returns>プリンタ設定配列</returns>
        private static PrtManage[] DeserializeHybridXML()
        {
            // 新パスにファイルがあるかチェック
            if (File.Exists(FilePath))
            {
                // 新ファイルがあれば新ロジックを使用
                return (PrtManage[])UserSettingController.DeserializeUserSetting(FilePath, typeof(PrtManage[]));
            }
            // 新ファイルがないときは旧ロジック
            return (PrtManage[])XmlByteSerializer.Deserialize(FILE_NAME, typeof(PrtManage[]));
        }

        #endregion // </読み>

        #region <書き>

        /// <summary>
		/// プリンタ管理登録・更新処理
		/// </summary>
		/// <param name="prtManage">プリンタ管理クラス</param>
		/// <returns>STATUS</returns>
		public int Write(ref PrtManage prtManage)
		{
			ArrayList prtManageList = new ArrayList();

			// ステータスを ctDB_NOT_FOUND にしておく
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			try
			{
				// XMLの読み込み
                PrtManage[] prtManages = DeserializeHybridXML();

				for (int i = 0; i < prtManages.Length; i++)
				{
					// データあり？
					if (prtManages[i].CompareTo(prtManage).Equals(0))
					{
						// とりあえず GUID が同じなら更新ＯＫとしよう
						if (prtManages[i].FileHeaderGuid.Equals(prtManage.FileHeaderGuid))
						{
							// 共通ヘッダを設定
							prtManage.UpdateDateTime = DateTime.Now;    // 更新日時
							// 企業コード
							// GUID
							// 更新従業員コード
							// 更新アセンブリID1
							// 更新アセンブリID2

                            prtManageList.Add(prtManage);   // 更新データをコレクションに追加

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; // ステータスを ctDB_NORMAL にする
						}
						else
						{
							// 重複エラー！
							status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
							break;
						}
					} 
					else
					{	// データなし
						// 既存データをコレクションに追加
						prtManageList.Add(prtManages[i]);		
					}
                }   // for (int i = 0; i < prtManages.Length; i++)

				// 重複データがなかったら
				if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
				{
					// 共通ヘッダを設定
					prtManage.CreateDateTime = DateTime.Now;            // 作成日時
					prtManage.UpdateDateTime = DateTime.Now;	        // 更新日時
					// 企業コード
					prtManage.FileHeaderGuid = System.Guid.NewGuid();   // GUID
					// 更新従業員コード
					// 更新アセンブリID1
					// 更新アセンブリID2

                    prtManageList.Add(prtManage);   // 追加データをコレクションに追加

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; // ステータスを ctDB_NORMAL にする
				}

				// ステータスをチェック
				if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
				{
					// KEYで並び替える
					prtManageList.Sort();
					// XMLの書き込み（プリンタ管理Listシリアライズ処理）
					SerializeList(prtManageList);
				}

				if(PrtManageBufferList != null)
				{
					SortedList sortList = new SortedList();

					// 既にキャッシュがあれば削除
					foreach(PrtManage prtManagewk in PrtManageBufferList)
					{
						if(prtManagewk.PrinterMngNo.Equals(prtManage.PrinterMngNo))
						{
							PrtManageBufferList.Remove(prtManagewk);
							break;
						}
					}
					// キャッシュに追加
					PrtManageBufferList.Add(prtManage);

					foreach(PrtManage prtManagewk in  PrtManageBufferList)
					{
						sortList.Add(prtManagewk.PrinterMngNo, prtManagewk);
					}
					PrtManageBufferList.Clear();
					PrtManageBufferList.AddRange(sortList.Values);
				}

				//-- キャッシュの更新（論理削除）--//
				if(LogicalPrtManageBufferList != null)
				{
					SortedList sortList = new SortedList();
					// 既にキャッシュがあれば削除
					foreach(PrtManage prtManagewk in  LogicalPrtManageBufferList)
					{
						if(prtManagewk.PrinterMngNo.Equals(prtManage.PrinterMngNo))
						{
							LogicalPrtManageBufferList.Remove(prtManagewk);
							break;
						}
					}
					
					// キャッシュに追加
					LogicalPrtManageBufferList.Add(prtManage);

					foreach (PrtManage prtManagewk in LogicalPrtManageBufferList)
					{
						sortList.Add(prtManagewk.PrinterMngNo, prtManagewk);
					}
					LogicalPrtManageBufferList.Clear();
					LogicalPrtManageBufferList.AddRange(sortList.Values);
				}
			}
			catch (FileNotFoundException)
			{
				// ファイルが存在しない場合（初回のみ）に以下の処理を行う
				// 共通ヘッダを設定
				prtManage.CreateDateTime = DateTime.Now;	        // 作成日時
				prtManage.UpdateDateTime = DateTime.Now;	        // 更新日時
				// 企業コード
				prtManage.FileHeaderGuid = System.Guid.NewGuid();   // GUID
				// 更新従業員コード
				// 更新アセンブリID1
				// 更新アセンブリID2

                prtManageList.Add(prtManage);   // 追加データをコレクションに追加
                SerializeList(prtManageList);   // XMLの書き込み（プリンタ管理Listシリアライズ処理）

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; // ステータスを ctDB_NORMAL にする
			}
			catch (Exception)
			{
                status = -1;    // エラー！
			}
			return status;
		}

		/// <summary>
		/// プリンタ管理Listシリアライズ処理
		/// </summary>
		/// <param name="prtManageList">シリアライズ対象プリンタ管理Listクラス</param>
		private static void SerializeList(ArrayList prtManageList)
		{
			// ArrayListから配列を生成
			PrtManage[] prtManages = (PrtManage[])prtManageList.ToArray(typeof(PrtManage));

			// プリンタ管理クラスをシリアライズ
            if (!Directory.Exists(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData))
            {
                //格納ディレクトリがなければ作成
                Directory.CreateDirectory(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData);
            }
            UserSettingController.SerializeUserSetting(prtManages, FilePath);
        }

        #endregion // </書き>

        #region <消し>

        /// <summary>
		/// プリンタ管理論理削除処理
		/// </summary>
		/// <param name="prtManage">プリンタ管理オブジェクト</param>
		/// <returns>STATUS</returns>
		public int LogicalDelete(ref PrtManage prtManage)
		{
			try
			{
				int status = 0;

				ArrayList prtManageList = new ArrayList();

				// XMLの読み込み
                PrtManage[] prtManages = DeserializeHybridXML();
                
                for (int i = 0; i < prtManages.Length; i++)
				{
					// 対象データなら論理削除区分を立ててコレクションに追加
					if (prtManages[i].CompareTo(prtManage).Equals(0))
					{
						prtManage.LogicalDeleteCode = 1;
						prtManageList.Add(prtManage);
					} 
					else
					{
						prtManageList.Add(prtManages[i]);
					}
				}
				// XMLの書き込み（プリンタ管理Listシリアライズ処理）
				SerializeList(prtManageList);

				//-- キャッシュから削除 --//
				if(PrtManageBufferList != null)
				{
					// 既にキャッシュがあれば削除
					foreach(PrtManage bufferedPrtManage in  PrtManageBufferList)
					{
						if(bufferedPrtManage.PrinterMngNo.Equals(prtManage.PrinterMngNo))
						{
							PrtManageBufferList.Remove(bufferedPrtManage);
							break;
						}
					}
				}

				//-- キャッシュの更新（論理削除） --//
				if(LogicalPrtManageBufferList != null)
				{
					SortedList sortList = new SortedList();
					// 既にキャッシュがあれば削除
					foreach(PrtManage bufferedLogicalPrtManage in  LogicalPrtManageBufferList)
					{
						if(bufferedLogicalPrtManage.PrinterMngNo.Equals(prtManage.PrinterMngNo))
						{
							LogicalPrtManageBufferList.Remove(bufferedLogicalPrtManage);
							break;
						}
					}
					// 論理削除区分を論理削除にする
					prtManage.LogicalDeleteCode = 1;
					// キャッシュに追加
					LogicalPrtManageBufferList.Add(prtManage);

					foreach(PrtManage bufferedLogicalPrtManage in  LogicalPrtManageBufferList)
					{
						sortList.Add(bufferedLogicalPrtManage.PrinterMngNo, bufferedLogicalPrtManage);
					}
					LogicalPrtManageBufferList.Clear();
					LogicalPrtManageBufferList.AddRange(sortList.Values);
				}

				return status;
			}
			catch (Exception)
			{
                return -1;  // 通信エラーは-1を戻す
			}
		}

		/// <summary>
		/// プリンタ管理物理削除処理
		/// </summary>
		/// <param name="prtManage">プリンタ管理オブジェクト</param>
		/// <returns>STATUS</returns>
		public int Delete(PrtManage prtManage)
		{
			try
			{
				int status = 0;

				ArrayList prtManageList = new ArrayList();

				// XMLの読み込み
                PrtManage[] prtManages = DeserializeHybridXML();

				for (int i = 0; i < prtManages.Length; i++)
				{
					// 対象データでなかったらコレクションに追加
					if (!prtManages[i].CompareTo(prtManage).Equals(0)) prtManageList.Add(prtManages[i]);
				}
				// XMLの書き込み（プリンタ管理Listシリアライズ処理）
				SerializeList(prtManageList);

                // キャッシュの更新
				if(LogicalPrtManageBufferList != null)
				{
					foreach(PrtManage bufferedLogicalPrtManage in  LogicalPrtManageBufferList)
					{
						if(bufferedLogicalPrtManage.PrinterMngNo.Equals(prtManage.PrinterMngNo))
						{
							LogicalPrtManageBufferList.Remove(bufferedLogicalPrtManage);
							break;
						}
					}
				}

				return status;
			}
			catch (Exception)
			{
                return -1;  // 通信エラーは-1を戻す
			}
        }

        #endregion // </消し>

        #region <戻し>

        /// <summary>
        /// プリンタ管理論理削除復活処理
        /// </summary>
        /// <param name="prtManage">プリンタ管理オブジェクト</param>
        /// <returns>STATUS</returns>
        public int Revival(ref PrtManage prtManage)
        {
            try
            {
                int status = 0;

                ArrayList prtManageList = new ArrayList();

                // XMLの読み込み
                PrtManage[] prtManages = DeserializeHybridXML();

                for (int i = 0; i < prtManages.Length; i++)
                {
                    // 対象データなら論理削除区分を正常に戻してコレクションに追加
                    if (prtManages[i].CompareTo(prtManage).Equals(0))
                    {
                        prtManage.LogicalDeleteCode = 0;
                        prtManageList.Add(prtManage);
                    }
                    else
                    {
                        prtManageList.Add(prtManages[i]);
                    }
                }
                // XMLの書き込み（プリンタ管理Listシリアライズ処理）
                SerializeList(prtManageList);

                //-- キャッシュの更新 --//
                if (PrtManageBufferList != null)
                {
                    SortedList sortList = new SortedList();
                    PrtManageBufferList.Add(prtManage);
                    foreach (PrtManage bufferedPrtManage in PrtManageBufferList)
                    {
                        sortList.Add(bufferedPrtManage.PrinterMngNo, bufferedPrtManage);
                    }
                    PrtManageBufferList.Clear();
                    PrtManageBufferList.AddRange(sortList.Values);
                }

                //-- キャッシュの更新（論理削除） --//
                if (LogicalPrtManageBufferList != null)
                {
                    SortedList sortList = new SortedList();
                    // 既にキャッシュがあれば削除
                    foreach (PrtManage bufferedLogicalPrtManage in LogicalPrtManageBufferList)
                    {
                        if (bufferedLogicalPrtManage.PrinterMngNo.Equals(prtManage.PrinterMngNo))
                        {
                            LogicalPrtManageBufferList.Remove(bufferedLogicalPrtManage);
                            break;
                        }
                    }
                    // 論理削除区分を有効にする
                    prtManage.LogicalDeleteCode = 0;
                    // キャッシュに追加
                    LogicalPrtManageBufferList.Add(prtManage);

                    foreach (PrtManage bufferedLogicalPrtManage in LogicalPrtManageBufferList)
                    {
                        sortList.Add(bufferedLogicalPrtManage.PrinterMngNo, bufferedLogicalPrtManage);
                    }
                    LogicalPrtManageBufferList.Clear();
                    LogicalPrtManageBufferList.AddRange(sortList.Values);
                }
                return status;
            }
            catch (Exception)
            {
                return -1;  // 通信エラーは-1を戻す
            }
        }

        #endregion // </戻し>

        #region <探し>

        /// <summary>
        /// プリンタ管理検索処理（論理削除含む）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="retList">読込結果コレクション</param>		
        /// <returns>STATUS</returns>
        public int SearchAll(string enterpriseCode, out ArrayList retList)
        {
            bool nextData = false;
            int retTotalCnt = 0;
            return SearchPrtManageProc(
                out retList,
                out retTotalCnt,
                out nextData,
                enterpriseCode,
                ConstantManagement.LogicalMode.GetData01,
                0,
                null
            );
        }

        /// <summary>
        /// 件数指定プリンタ管理検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevPrtManageがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="readCnt">読込件数</param>		
        /// <param name="prevPrtManage">前回最終プリンタ管理データオブジェクト（初回はnull指定必須）</param>			
        /// <returns>STATUS</returns>
        public int SearchSpecificationAll(
            out ArrayList retList,
            out int retTotalCnt,
            out bool nextData,
            string enterpriseCode,
            int readCnt,
            PrtManage prevPrtManage
        )
        {
            return SearchPrtManageProc(
                out retList,
                out retTotalCnt,
                out nextData,
                enterpriseCode,
                ConstantManagement.LogicalMode.GetData01,
                readCnt,
                prevPrtManage
            );
        }

        /// <summary>
        /// プリンタ管理検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevPrtManageがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevPrtManage">前回最終プリンタ管理データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        private int SearchPrtManageProc(
            out ArrayList retList,
            out int retTotalCnt,
            out bool nextData,
            string enterpriseCode,
            ConstantManagement.LogicalMode logicalMode,
            int readCnt,
            PrtManage prevPrtManage
        )
        {
            // 次データ有無初期化
            nextData = false;
            // 0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();

            int status = 0;
            try
            {
                // XMLの読み込み
                PrtManage[] prtManages = DeserializeHybridXML();

                // 全件リード？
                if (readCnt.Equals(0))
                {
                    for (int i = 0; i < prtManages.Length; i++)
                    {
                        // 読込結果コレクションに追加
                        if (CheckTargetData(prtManages[i], logicalMode)) retList.Add(prtManages[i]);
                    }
                    // 読込対象データ総件数←ArrayListの件数
                    retTotalCnt = retList.Count;
                }
                else
                {	// 読込件数指定リード

                    // 読込対象データ総件数←配列要素数
                    retTotalCnt = prtManages.Length;
                    // 前回データがない？
                    if (prevPrtManage == null)
                    {
                        for (int i = 0; i < prtManages.Length; i++)
                        {
                            // 読込件数に達したら抜ける
                            if (retList.Count >= readCnt)
                            {
                                nextData = true;	// これ要らんかも
                                break;
                            }
                            // 読込結果コレクションに追加
                            if (CheckTargetData(prtManages[i], logicalMode)) retList.Add(prtManages[i]);
                        }
                    }
                    else
                    {	// 前回データがない

                        // 前回データのインデックスを初期化
                        int prevDataIndex = -1;

                        for (int i = 0; i < prtManages.Length; i++)
                        {
                            // 読込件数に達したら抜ける
                            if (retList.Count >= readCnt)
                            {
                                nextData = true;	// これ要らんかも
                                break;
                            }
                            // 前回データが見つかったらインデックスを退避しておく
                            if (prtManages[i].Equals(prevPrtManage) == true)
                                prevDataIndex = i;
                            // 前回データの次のデータ以降を読込結果コレクションに追加
                            if ((prevDataIndex >= 0) && (i > prevDataIndex))
                            {
                                if (CheckTargetData(prtManages[i], logicalMode)) retList.Add(prtManages[i]);
                            }
                        }
                    }
                }

                // 読込結果なしの場合はEOFを返す
                if (retList.Count <= 0) status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch (FileNotFoundException)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch (Exception)
            {
                return -1;  // エラー！
            }

            // 全件リードの場合は戻り値の件数をセット
            if (readCnt.Equals(0)) retTotalCnt = retList.Count;

            return status;
        }

        /// <summary>
        /// 対象データチェック
        /// </summary>
        /// <param name="prtManage">対象データ</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <returns>チェック結果（true:OK false:NG）</returns>
        private static bool CheckTargetData(
            PrtManage prtManage,
            ConstantManagement.LogicalMode logicalMode
        )
        {
            if (logicalMode.Equals(ConstantManagement.LogicalMode.GetData0))
            {
                if (!prtManage.LogicalDeleteCode.Equals(0)) return false;
            }
            else if (logicalMode.Equals(ConstantManagement.LogicalMode.GetData1))
            {
                if (!prtManage.LogicalDeleteCode.Equals(1)) return false;
            }
            return true;
        }

        #endregion // </探し>

        /// <summary>
        /// プリンタ管理マスタから検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>プリンタ設定データのリスト</returns>
        public static List<PrtManage> SearchFromPrtManageMaster(string enterpriseCode)
        {
            ArrayList prtManageList = null;
            {
                PrtManageAcs clientDataAcs = new PrtManageAcs();
                {
                    int status = clientDataAcs.SearchAll(enterpriseCode, out prtManageList);
                    if (!status.Equals(0))
                    {
                        if (prtManageList == null) prtManageList = new ArrayList();
                        string msg = string.Format(
                            "プリンタ設定マスタアクセスエラー…PrtManageAcs.SearchAll() : status = {0}",
                            status
                        );
                        Debug.WriteLine(msg);
                    }
                }
            }
            return new List<PrtManage>((PrtManage[])prtManageList.ToArray(typeof(PrtManage)));
        }

        /// <summary>
        /// プリンタ設定マスタへ書込みます。
        /// </summary>
        /// <param name="prtManage">プリンタ設定データ</param>
        /// <returns>結果コード</returns>
        public static int WriteToPrtManageMaster(ref PrtManage prtManage)
        {
            PrtManageAcs clientDataAcs = new PrtManageAcs();
            {
                int status = clientDataAcs.Write(ref prtManage);
                if (!status.Equals(0))    
                {
                    string msg = string.Format(
                        "プリンタ設定マスタアクセスエラー…PrtManageAcs.Write()：status = {0}",
                        status
                    );
                    Debug.WriteLine(msg);
                }
                return status;
            }
        }

        /// <summary>
        /// プリンタ設定マスタから論理削除します。
        /// </summary>
        /// <param name="prtManage">プリンタ設定データ</param>
        /// <returns>結果コード</returns>
        public static int DeleteLogicallyFromPrtManageMaster(ref PrtManage prtManage)
        {
            PrtManageAcs clientDataAcs = new PrtManageAcs();
            {
                int status = clientDataAcs.LogicalDelete(ref prtManage);
                if (!status.Equals(0))
                {
                    string msg = string.Format(
                        "プリンタ設定マスタアクセスエラー…PrtManageAcs.LogicalDelete()：status = {0}",
                        status
                    );
                    Debug.WriteLine(msg);
                }
                return status;
            }
        }

        /// <summary>
        /// プリンタ設定マスタに復活させます。
        /// </summary>
        /// <param name="prtManage">プリンタ設定データ</param>
        /// <returns>結果コード</returns>
        public static int ReviveIntoPrtManageMaster(ref PrtManage prtManage)
        {
            PrtManageAcs clientDataAcs = new PrtManageAcs();
            {
                int status = clientDataAcs.Revival(ref prtManage);
                if (!status.Equals(0))
                {
                    string msg = string.Format(
                        "プリンタ設定マスタアクセスエラー…PrtManageAcs.Revival()：status = {0}",
                        status
                    );
                    Debug.WriteLine(msg);
                }
                return status;
            }
        }

        /// <summary>
        /// プリンタ設定マスタから物理削除します。
        /// </summary>
        /// <param name="prtManage">プリンタ設定データ</param>
        /// <returns>結果コード</returns>
        public static int DeletePhysicallyFromPrtManageMaster(PrtManage prtManage)
        {
            PrtManageAcs clientDataAcs = new PrtManageAcs();
            {
                int status = clientDataAcs.Delete(prtManage);
                if (!status.Equals(0))
                {
                    string msg = string.Format(
                        "プリンタ設定マスタアクセスエラー…PrtManageAcs.Delete()：status = {0}",
                        status
                    );
                    Debug.WriteLine(msg);
                }
                return status;
            }
        }
    }
}