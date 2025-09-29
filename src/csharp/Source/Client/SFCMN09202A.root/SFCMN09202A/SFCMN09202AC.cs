using System;
using System.Collections;
using System.Data;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

using Broadleaf.Application.Controller.Other;
namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// プリンタ管理テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : プリンタ管理テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 97606 藤　江梨子</br>
	/// <br>Date       : 2005.03.22</br>
	/// <br>Update Note: 2005.11.11 22011 柏原　頼人</br>
	/// <br>           : O,D統合対応</br>
	/// <br>Update Note: 2005.12.02 22011 柏原　頼人</br>
	/// <br>           : O,D分離対応</br>
	/// <br>Update Note: 2005.12.03 22011 柏原　頼人</br>
	/// <br>           : O,Gを参照から外す。（ローカルを見に行くようにする対応です。）</br>
	/// <br>Update Note: 2005.12.03 23003 榎田　まさみ</br>
	/// <br>			 ・親マスタ反映同期対応</br>
    /// <br>Update Note: 2006.09.05 22011 柏原　頼人</br>
    /// <br>			 ・高速化対応(ReadStaticMemoryメソッド追加)</br>
    /// <br>Update Note: 2006.09.13 22011 柏原　頼人</br>
    /// <br>			 ・XMLローカル保存対応</br>
    /// <br>               XMLの格納ディレクトリが変わったので、まず新ディレクトリをサーチしてファイルがなければ</br>
    /// <br>               旧ディレクトリ(カレント)もサーチしに行く仕様です。</br>
    /// <br>Update Note: 2022.04.25 田村　顕成</br>
    /// <br>			 11870080-00　電子帳簿2対応（納品書PDF出力対応）</br>
    /// </remarks>
	public class PrtManageAcs
	{
		/// <summary>リモートオブジェクト格納バッファ</summary>
		/// <summary>ＸＭＬファイル名</summary>
		private string _fileName;
        //2006.09.13 Kashihara Add -------------
        /// <summary>ＸＭＬファイルパス</summary>
        private string _filePath;
        //2006.09.13 Kashihara Add -------------

		/// <summary>データバッファ</summary>
		private static ArrayList _buff_PrtManage = null;
		private static ArrayList _logicalBuff_PrtManage = null;

        // add 2022.04.25 11870080-00　電子帳簿2次対応 >>>>>
        const string processNameSalesSlip = "MAHNB01001U";
        const string processNameCustElec = "PMKAU04000U";
        const string processNameBLPAutoReply = "PMSCM00005U";
        eBooksOutputSetting _eBooksPDFPrinterSetting;
        private enum eBookOperationApplication
        {
            APPLICATION_SALESSLIP = 1,          //売上伝票入力
            APPLICATION_CUSTOMERELECNOTE = 2,   //得意先電子元帳
            APPLICATION_BLPAUTOREPLY = 4,       //BLP自動回答
        }
        // add 2022.04.25 11870080-00　電子帳簿2次対応 <<<<<

		/// <summary>
		/// プリンタ管理テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : プリンタ管理テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public PrtManageAcs()
		{
			try
			{
				// ＸＭＬファイル名を設定
				this._fileName = "PrtManage.xml";
                //2006.09.13 Kashihara ADD---------------------
                // ＸＭＬファイルパス
                this._filePath = ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData + "\\PrtManage.xml";
                //2006.09.13 Kashihara ADD---------------------
            }
			catch (Exception)
			{		
			}
		}

		/// <summary>オンラインモードの列挙型です。</summary>
		public enum OnlineMode 
		{
			/// <summary>オフライン</summary>
			Offline,
			/// <summary>オンライン</summary>
			Online 
		}

		/// <summary>
		/// プリンタ管理読み込み処理
		/// </summary>
		/// <param name="prtManage">プリンタ管理オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="printerMngNo">プリンタ管理No</param>
		/// <returns>プリンタ管理クラス</returns>
		/// <remarks>
		/// <br>Note       : プリンタ管理情報を読み込みます。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Read(out PrtManage prtManage, string enterpriseCode, int printerMngNo)
		{			
			prtManage = null;

			try
			{
				int status = 0;

				// データ比較用パラメータ
				PrtManage prtManagePara         = new PrtManage();
				prtManagePara.EnterpriseCode    = enterpriseCode;
				prtManagePara.PrinterMngNo      = printerMngNo;              

				// ＸＭＬの読み込み
				//2006.09.13 PrtManage[] prtManages = (PrtManage[])XmlByteSerializer.Deserialize(this._fileName, typeof(PrtManage[]));
                //2006.09.13 -------------------------------- Kashihara START
                PrtManage[] prtManages = HybridXmlDeserialize();
                //2006.09.13 -------------------------------- Kashihara END
 
				foreach (PrtManage prtManageTemp in prtManages)
				{
					if (prtManageTemp.CompareTo(prtManagePara) == 0)
					{
						prtManage = prtManageTemp.Clone();
						break;
					}
				}

				if ((prtManages.Length == 0) || (prtManage == null))
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
		
				return status;
			}
			catch (System.IO.FileNotFoundException)
			{
				return (int)ConstantManagement.DB_Status.ctDB_EOF;
			}
			catch (Exception)
			{				
				prtManage = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// プリンタ管理登録・更新処理
		/// </summary>
		/// <param name="prtManage">プリンタ管理クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : プリンタ管理情報の登録・更新を行います。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Write(ref PrtManage prtManage)
		{
			ArrayList prtManageList = new ArrayList();
			prtManageList.Clear();

			// ステータスを ctDB_NOT_FOUND にしておく
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			try
			{
				// ＸＭＬの読み込み
				//2006.09.13 PrtManage[] prtManages = (PrtManage[])XmlByteSerializer.Deserialize(this._fileName, typeof(PrtManage[]));
                //2006.09.13 -------------------------------- Kashihara START
                PrtManage[] prtManages = HybridXmlDeserialize();
                //2006.09.13 -------------------------------- Kashihara END

				for (int ix=0; ix<prtManages.Length; ix++)
				{
					// データあり？
					if (prtManages[ix].CompareTo(prtManage) == 0)
					{
						// とりあえず GUID が同じなら更新ＯＫとしよう
						if (prtManages[ix].FileHeaderGuid.Equals(prtManage.FileHeaderGuid))
						{
							// 共通ヘッダを設定
							prtManage.UpdateDateTime = DateTime.Now;	// 更新日時
								// 企業コード
								// GUID
								// 更新従業員コード
								// 更新アセンブリID1
								// 更新アセンブリID2
							// 更新データをコレクションに追加
							prtManageList.Add(prtManage);
							// ステータスを ctDB_NORMAL にする
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
						prtManageList.Add(prtManages[ix]);		
					}
				}

				// 重複データがなかったら
				if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) 
				{
					// 共通ヘッダを設定
					prtManage.CreateDateTime = DateTime.Now;	// 作成日時
					prtManage.UpdateDateTime = DateTime.Now;	// 更新日時
					// 企業コード
					prtManage.FileHeaderGuid = System.Guid.NewGuid();	// GUID
					// 更新従業員コード
					// 更新アセンブリID1
					// 更新アセンブリID2
					// 追加データをコレクションに追加
					prtManageList.Add(prtManage);
					// ステータスを ctDB_NORMAL にする
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}

				// ステータスをチェック
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// KEYで並び替える
					prtManageList.Sort();
					// ＸＭＬの書き込み（プリンタ管理Listシリアライズ処理）
					this.ListSerialize(prtManageList, this._fileName);
				}

				// 2005.12.03 enokida ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
				if(_buff_PrtManage != null)
				{
					SortedList sortList = new SortedList();

					// 既にキャッシュがあれば削除
					foreach(PrtManage prtManagewk in  _buff_PrtManage)
					{
						if(prtManagewk.PrinterMngNo == prtManage.PrinterMngNo)
						{
							_buff_PrtManage.Remove(prtManagewk);
							break;
						}
					}
					// キャッシュに追加
					_buff_PrtManage.Add(prtManage);

					foreach(PrtManage prtManagewk in  _buff_PrtManage)
					{
						sortList.Add(prtManagewk.PrinterMngNo, prtManagewk);
					}
					_buff_PrtManage.Clear();
					_buff_PrtManage.AddRange(sortList.Values);
				}
				//--キャッシュの更新（論理削除）--//
				if(_logicalBuff_PrtManage != null)
				{
					SortedList sortList = new SortedList();
					// 既にキャッシュがあれば削除
					foreach(PrtManage prtManagewk in  _logicalBuff_PrtManage)
					{
						if(prtManagewk.PrinterMngNo == prtManage.PrinterMngNo)
						{
							_logicalBuff_PrtManage.Remove(prtManagewk);
							break;
						}
					}
					
					// キャッシュに追加
					_logicalBuff_PrtManage.Add(prtManage);

					foreach(PrtManage prtManagewk in  _logicalBuff_PrtManage)
					{
						sortList.Add(prtManagewk.PrinterMngNo, prtManagewk);
					}
					_logicalBuff_PrtManage.Clear();
					_logicalBuff_PrtManage.AddRange(sortList.Values);
				}
			}
			catch (System.IO.FileNotFoundException)
			{
				// ファイルが存在しない場合（初回のみ）に以下の処理を行う
				// 共通ヘッダを設定
				prtManage.CreateDateTime = DateTime.Now;	// 作成日時
				prtManage.UpdateDateTime = DateTime.Now;	// 更新日時
					// 企業コード
				prtManage.FileHeaderGuid = System.Guid.NewGuid();	// GUID
					// 更新従業員コード
					// 更新アセンブリID1
					// 更新アセンブリID2
				// 追加データをコレクションに追加
				prtManageList.Add(prtManage);
				// ＸＭＬの書き込み（プリンタ管理Listシリアライズ処理）
				this.ListSerialize(prtManageList, this._fileName);
				// ステータスを ctDB_NORMAL にする
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (Exception)
			{
				// エラー！
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// プリンタ管理Listシリアライズ処理
		/// </summary>
		/// <param name="prtManageList">シリアライズ対象プリンタ管理Listクラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : プリンタ管理List情報のシリアライズを行います。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void ListSerialize(ArrayList prtManageList, string fileName)
		{
			// ArrayListから配列を生成
			PrtManage[] prtManages = (PrtManage[])prtManageList.ToArray(typeof(PrtManage));
			// プリンタ管理クラスをシリアライズ
			//2006.09.13 ---------------------------- Kashihara START
            //2006.09.13 DEL XmlByteSerializer.Serialize(prtManages,fileName);
            //格納ディレクトリがなければ作成
            if (System.IO.Directory.Exists(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData) == false)
            {
                System.IO.Directory.CreateDirectory(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData);
            }

            UserSettingController.SerializeUserSetting(prtManages, _filePath);
            //2006.09.13 ---------------------------- Kashihara END
            
		}

        //2006.09.13 -------------------------------- Kashihara START
        /// <summary>
        /// XMLからプリンタ設定クラスへデシリアライズします
        /// </summary>
        /// <returns>プリンタ設定配列</returns>
        private PrtManage[] HybridXmlDeserialize()
        {
            //新パスにファイルがあるかチェック
            if (System.IO.File.Exists(_filePath))
            {
                //新ファイルがあれば新ロジックを使用
                return (PrtManage[])UserSettingController.DeserializeUserSetting(this._filePath, typeof(PrtManage[]));
            }
            else
            {
                //新ファイルがないときは旧ロジック
                return (PrtManage[])XmlByteSerializer.Deserialize(this._fileName, typeof(PrtManage[]));
            }
        }
        //2006.09.13 -------------------------------- Kashihara End

		/// <summary>
		/// プリンタ管理論理削除処理
		/// </summary>
		/// <param name="prtManage">プリンタ管理オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : プリンタ管理情報の論理削除を行います。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int LogicalDelete(ref PrtManage prtManage)
		{
			try
			{
				int status = 0;

				ArrayList prtManageList = new ArrayList();
				prtManageList.Clear();

				// ＸＭＬの読み込み
				//2006.09.13 PrtManage[] prtManages = (PrtManage[])XmlByteSerializer.Deserialize(this._fileName, typeof(PrtManage[]));
                //2006.09.13 -------------------------------- Kashihara START
                PrtManage[] prtManages = HybridXmlDeserialize();
                //2006.09.13 -------------------------------- Kashihara END
                
                for (int ix=0; ix<prtManages.Length; ix++)
				{
					// 対象データなら論理削除区分を立ててコレクションに追加
					if (prtManages[ix].CompareTo(prtManage) == 0)
					{
						prtManage.LogicalDeleteCode = 1;
						prtManageList.Add(prtManage);
					} 
					else
					{
						prtManageList.Add(prtManages[ix]);
					}
				}
				// ＸＭＬの書き込み（プリンタ管理Listシリアライズ処理）
				this.ListSerialize(prtManageList, this._fileName);
				//--キャッシュから削除--//
				if(_buff_PrtManage != null)
				{
					// 既にキャッシュがあれば削除
					foreach(PrtManage prtManagewk in  _buff_PrtManage)
					{
						if(prtManagewk.PrinterMngNo == prtManage.PrinterMngNo)
						{
							_buff_PrtManage.Remove(prtManagewk);
							break;
						}
					}
				}

				//--キャッシュの更新（論理削除）--//
				if(_logicalBuff_PrtManage != null)
				{
					SortedList sortList = new SortedList();
					// 既にキャッシュがあれば削除
					foreach(PrtManage prtManagewk in  _logicalBuff_PrtManage)
					{
						if(prtManagewk.PrinterMngNo == prtManage.PrinterMngNo)
						{
							_logicalBuff_PrtManage.Remove(prtManagewk);
							break;
						}
					}
					// 論理削除区分を論理削除にする
					prtManage.LogicalDeleteCode = 1;
					// キャッシュに追加
					_logicalBuff_PrtManage.Add(prtManage);

					foreach(PrtManage prtManagewk in  _logicalBuff_PrtManage)
					{
						sortList.Add(prtManagewk.PrinterMngNo, prtManagewk);
					}
					_logicalBuff_PrtManage.Clear();
					_logicalBuff_PrtManage.AddRange(sortList.Values);
				}

				return status;
			}
			catch (Exception)
			{
				// 通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// プリンタ管理物理削除処理
		/// </summary>
		/// <param name="prtManage">プリンタ管理オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : プリンタ管理情報の物理削除を行います。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Delete(PrtManage prtManage)
		{
			try
			{
				int status = 0;

				ArrayList prtManageList = new ArrayList();
				prtManageList.Clear();

				// ＸＭＬの読み込み
				//2006.09.13 PrtManage[] prtManages = (PrtManage[])XmlByteSerializer.Deserialize(this._fileName, typeof(PrtManage[]));
                //2006.09.13 -------------------------------- Kashihara START
                PrtManage[] prtManages = HybridXmlDeserialize();
                //2006.09.13 -------------------------------- Kashihara END

				for (int ix=0; ix<prtManages.Length; ix++)
				{
					// 対象データでなかったらコレクションに追加
					if (prtManages[ix].CompareTo(prtManage) != 0)
						prtManageList.Add(prtManages[ix]);
				}
				// ＸＭＬの書き込み（プリンタ管理Listシリアライズ処理）
				this.ListSerialize(prtManageList, this._fileName);

                //キャッシュの更新
				if(_logicalBuff_PrtManage != null)
				{
					foreach(PrtManage prtManagewk in  _logicalBuff_PrtManage)
					{
						if(prtManagewk.PrinterMngNo == prtManage.PrinterMngNo)
						{
							_logicalBuff_PrtManage.Remove(prtManagewk);
							break;
						}
					}
				}

				return status;
			}
			catch (Exception)
			{
				// 通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// プリンタ管理検索処理（論理削除除く）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : プリンタ管理検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int GetCnt(out int retTotalCnt,string enterpriseCode)
		{
			retTotalCnt = 0;
			return 0;
		}

		/// <summary>
		/// プリンタ管理検索処理（論理削除含む）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : プリンタ管理検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int GetAllCnt(out int retTotalCnt,string enterpriseCode)
		{
			retTotalCnt = 0;
			return 0;
		}

		/// <summary>
		/// プリンタ管理全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : プリンタ管理の全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Search(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int  retTotalCnt;
			return SearchPrtManageProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,0,null);			
		}

		/// <summary>
		/// プリンタ管理検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : プリンタ管理の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int	 retTotalCnt;
			return SearchPrtManageProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData01,0,null);
		}

		/// <summary>
		/// 件数指定プリンタ管理検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevPrtManageがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevPrtManage">前回最終担当者データオブジェクト（初回はnull指定必須）</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定してプリンタ管理の検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchSpecification(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,PrtManage prevPrtManage)
		{			
			return SearchPrtManageProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,readCnt,prevPrtManage);			
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
		/// <remarks>
		/// <br>Note       : 件数を指定してプリンタ管理の検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchSpecificationAll(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,PrtManage prevPrtManage)
		{			
			return SearchPrtManageProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData01,readCnt,prevPrtManage);	
		}

		/// <summary>
		/// プリンタ管理論理削除復活処理
		/// </summary>
		/// <param name="prtManage">プリンタ管理オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : プリンタ管理情報の復活を行います。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Revival(ref PrtManage prtManage)
		{
			try
			{
				int status = 0;

				ArrayList prtManageList = new ArrayList();
				prtManageList.Clear();

				// ＸＭＬの読み込み
				//2006.09.13 PrtManage[] prtManages = (PrtManage[])XmlByteSerializer.Deserialize(this._fileName, typeof(PrtManage[]));

                //2006.09.13 -------------------------------- Kashihara START
                PrtManage[] prtManages = HybridXmlDeserialize();
                //2006.09.13 -------------------------------- Kashihara END

                for (int ix=0; ix<prtManages.Length; ix++)
				{
					// 対象データなら論理削除区分を正常に戻してコレクションに追加
					if (prtManages[ix].CompareTo(prtManage) == 0)
					{
						prtManage.LogicalDeleteCode = 0;
						prtManageList.Add(prtManage);
					} 
					else
					{
						prtManageList.Add(prtManages[ix]);
					}
				}
				// ＸＭＬの書き込み（プリンタ管理Listシリアライズ処理）
				this.ListSerialize(prtManageList, this._fileName);

				//--キャッシュの更新--//
				if(_buff_PrtManage != null)
				{
					SortedList sortList = new SortedList();
					_buff_PrtManage.Add(prtManage);
					foreach(PrtManage prtManagewk in  _buff_PrtManage)
					{
						sortList.Add(prtManagewk.PrinterMngNo, prtManagewk);
					}
					_buff_PrtManage.Clear();
					_buff_PrtManage.AddRange(sortList.Values);
				}

				//--キャッシュの更新（論理削除）--//
				if(_logicalBuff_PrtManage != null)
				{
					SortedList sortList = new SortedList();
					// 既にキャッシュがあれば削除
					foreach(PrtManage prtManagewk in  _logicalBuff_PrtManage)
					{
						if(prtManagewk.PrinterMngNo == prtManage.PrinterMngNo)
						{
							_logicalBuff_PrtManage.Remove(prtManagewk);
							break;
						}
					}
					// 論理削除区分を有効にする
					prtManage.LogicalDeleteCode = 0;
					// キャッシュに追加
					_logicalBuff_PrtManage.Add(prtManage);

					foreach(PrtManage prtManagewk in  _logicalBuff_PrtManage)
					{
						sortList.Add(prtManagewk.PrinterMngNo, prtManagewk);
					}
					_logicalBuff_PrtManage.Clear();
					_logicalBuff_PrtManage.AddRange(sortList.Values);
				}
				return status;
			}
			catch (Exception)
			{
				// 通信エラーは-1を戻す
				return -1;
			}
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
		/// <remarks>
		/// <br>Note       : プリンタ管理の検索処理を行います。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// <br>Note       : 11870080-00　電子帳簿2対応（納品書PDF出力対応）</br>
		/// <br>Programmer : 田村　顕成</br>
		/// <br>Date       : 2022.04.25</br>
		/// </remarks>
		private int SearchPrtManageProc(
			out ArrayList retList,
			out int retTotalCnt,
			out bool nextData,
			string enterpriseCode,
			ConstantManagement.LogicalMode logicalMode,
			int readCnt,
			PrtManage prevPrtManage)
		{
			
			//次データ有無初期化
			nextData = false;
			//0で初期化
			retTotalCnt = 0;

			retList = new ArrayList();
			retList.Clear();

			int status = 0;
			try
			{
				// ＸＭＬの読み込み
				//2006.09.13 PrtManage[] prtManages = (PrtManage[])XmlByteSerializer.Deserialize(this._fileName, typeof(PrtManage[]));
                //2006.09.13 -------------------------------- Kashihara START
                PrtManage[] prtManages = HybridXmlDeserialize();
                //2006.09.13 -------------------------------- Kashihara END

                // 全件リード？
				if (readCnt == 0) 
				{
                    // add 2022.04.25 11870080-00　電子帳簿2次対応 >>>>>
                    System.Diagnostics.Process current = System.Diagnostics.Process.GetCurrentProcess();
                    SalesSlipInputAcs _salesSlipInputAcs = SalesSlipInputAcs.GetInstance();//売伝
                    CustPrtSlipSearchAcs _customerElecNote = new CustPrtSlipSearchAcs();//得意先電子元帳
                    ArrayList salesDataList = new ArrayList();
                    SlipPrinter _slipPrinter = new SlipPrinter(salesDataList);//BLP自動回答
                    int PDFPrintMnNo = 0;//PDF仮想プリンタ管理番号
                    int PDFPrintIndexNo = 0;//PDF仮想プリンタリストインデックス番号
                    int PDFPrintApplication = 0;
                    if (current.ProcessName == processNameSalesSlip ||
                        current.ProcessName == processNameCustElec ||
                        current.ProcessName == processNameBLPAutoReply)
                    {
                        //プリンタ設定呼出アプリケーション（売伝／得意先電子元帳）
                        PDFPrintApplication = _salesSlipInputAcs.PDFPrinterStatus_EXT | _customerElecNote.PDFPrinterStatus_EXT << 1 | _slipPrinter.PDFPrinterStatus_EXT << 2 ;
                    }
                    else
                    {
                        PDFPrintApplication = 0;
                    }
                    switch (PDFPrintApplication)
                    {
                        case (int)eBookOperationApplication.APPLICATION_SALESSLIP://売伝から呼ばれている
                        case (int)eBookOperationApplication.APPLICATION_BLPAUTOREPLY://BLP自動回答から呼ばれている(売伝として扱う)
                            //MAHNB01001U_PDFOutputSettings.xmlの読み込み
                            PDFPrintMnNo = Int32.Parse(GetEBooksPDFPrinterManageNumber((int)eBookOperationApplication.APPLICATION_SALESSLIP));
                            break;
                        case (int)eBookOperationApplication.APPLICATION_CUSTOMERELECNOTE://得意先電子元帳から呼ばれている
                            //PMKAU04001U_PDFOutputSettings.xmlの読み込み
                            PDFPrintMnNo = Int32.Parse(GetEBooksPDFPrinterManageNumber((int)eBookOperationApplication.APPLICATION_CUSTOMERELECNOTE));
                            break;
                        default:
                            PDFPrintMnNo = 0;//do as usual
                            break;

                    }
                    // add 2022.04.25 11870080-00　電子帳簿2次対応 <<<<<

                    for (int ix = 0; ix < prtManages.Length; ix++)
					{
						// 読込結果コレクションに追加
                        // add 2022.04.25 11870080-00　電子帳簿2次対応 >>>>>
                        //if (checkTarGetData(prtManages[ix], logicalMode)) retList.Add(prtManages[ix]);
                        if (checkTarGetData(prtManages[ix], logicalMode))
                        {
                            retList.Add(prtManages[ix]);
                            if (PDFPrintApplication != 0)
                            {
                                if (prtManages[ix].PrinterMngNo == PDFPrintMnNo)
                                {
                                    PDFPrintIndexNo = ix;
                                }
                            }
                        }
                        // add 2022.04.25 11870080-00　電子帳簿2次対応 <<<<<
                    }
                    
                    // add 2022.04.25 11870080-00　電子帳簿2次対応 >>>>>
                    if (PDFPrintApplication != 0)
                    {
                        retList.Insert(0, prtManages[PDFPrintIndexNo]);
                        retList.RemoveAt(PDFPrintIndexNo);
                    }
                    // add 2022.04.25 11870080-00　電子帳簿2次対応 <<<<<
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
						for (int ix=0; ix<prtManages.Length; ix++)
						{
							// 読込件数に達したら抜ける
							if (retList.Count >= readCnt)
							{
								nextData = true;	// これ要らんかも
								break;
							}
							// 読込結果コレクションに追加
							if (checkTarGetData(prtManages[ix], logicalMode)) retList.Add(prtManages[ix]);
						}
					}
					else
					{	// 前回データがない

						// 前回データのインデックスを初期化
						int prevDataIndex = -1;
						
						for (int ix=0; ix<prtManages.Length; ix++)
						{
							// 読込件数に達したら抜ける
							if (retList.Count >= readCnt)
							{
								nextData = true;	// これ要らんかも
								break;
							}
							// 前回データが見つかったらインデックスを退避しておく
							if (prtManages[ix].Equals(prevPrtManage) == true)
								prevDataIndex = ix;
							// 前回データの次のデータ以降を読込結果コレクションに追加
							if ((prevDataIndex >= 0) && (ix > prevDataIndex))
								if (checkTarGetData(prtManages[ix], logicalMode)) retList.Add(prtManages[ix]);
						}
					}
				}

				// 読込結果なしの場合はEOFを返す
				if (retList.Count <= 0)
					status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			}
			catch (System.IO.FileNotFoundException)
			{
				return (int)ConstantManagement.DB_Status.ctDB_EOF;
			}
			catch (Exception)
			{
				// エラー！
				return -1;
			}

			// 全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// 電子帳簿設定取得（売上伝票入力、得意先電子元帳）
        /// </summary>
        /// <param name="type">呼出元アプリケーション</param>
        /// <returns>電子帳簿受け渡しフォルダパス</returns>
        /// <remarks> 
        /// <br>Note       : 11870080-00　電子帳簿2対応（納品書PDF出力対応）</br>
        /// <br>Programmer : 田村　顕成</br>
        /// <br>Date       : 2022.04.25</br>
        /// </remarks>
        private string GetEBooksPDFPrinterManageNumber(int type)
        {
            string sXmlfileName;
            string sCustomFoldertPath = string.Empty;
            _eBooksPDFPrinterSetting = new eBooksOutputSetting();

            switch (type)
            {
                case (int)eBookOperationApplication.APPLICATION_SALESSLIP:
                    sXmlfileName = "MAHNB01001U_PDFOutputSettings.xml";
                    break;
                case (int)eBookOperationApplication.APPLICATION_CUSTOMERELECNOTE:
                    sXmlfileName = "PMKAU04001U_PDFOutputSettings.xml";
                    break;
                default:
                    sXmlfileName = string.Empty;//for raise error.
                    break;
            }

            //  電子帳簿連携設定情報XMLファイル存在の判断           
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, sXmlfileName)))
            {
                try
                {
                    _eBooksPDFPrinterSetting = UserSettingController.DeserializeUserSetting<eBooksOutputSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, sXmlfileName));
                    if (!string.IsNullOrEmpty(_eBooksPDFPrinterSetting.PDFPrinterNumber))
                    {
                        sCustomFoldertPath = _eBooksPDFPrinterSetting.PDFPrinterNumber;
                    }
                    else
                    {
                        sCustomFoldertPath = "0";
                    }

                }
                catch (System.InvalidOperationException)
                {
                    return sCustomFoldertPath = "0";
                }
            }
            return sCustomFoldertPath;
        }

		/// <summary>
		/// プリンタ管理検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : プリンタ管理の検索処理を行い、取得結果をDataSetで返します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchPrtManageDS(ref DataSet ds,string enterpriseCode)
		{
			ArrayList prtManageList = new ArrayList();
			prtManageList.Clear();

			// 対象データチェック用パラメータ
			PrtManage prtManagePara = new PrtManage();
			prtManagePara.EnterpriseCode = enterpriseCode;

			try
			{
				// ＸＭＬの読み込み
				//2006.09.13 PrtManage[] prtManages = (PrtManage[])XmlByteSerializer.Deserialize(this._fileName, typeof(PrtManage[]));
                //2006.09.13 -------------------------------- Kashihara START
                PrtManage[] prtManages = HybridXmlDeserialize();
                //2006.09.13 -------------------------------- Kashihara END

				// 対象データをコレクションに追加
				for (int ix=0; ix<prtManages.Length; ix++)
				{
					if (checkTarGetData(prtManages[ix],0)) prtManageList.Add(prtManages[ix]);
				}
				// ArrayListから配列を生成
				prtManages = (PrtManage[])prtManageList.ToArray(typeof(PrtManage));
				// プリンタ管理→ＸＭＬ（バイナリ化）
				byte[] buffer = XmlByteSerializer.Serialize(prtManages);
				// DataSetへＸＭＬデータを取り込む
				XmlByteSerializer.ReadXml(ref ds, buffer);

				return 0;
			}
			catch (System.IO.FileNotFoundException)
			{
				return (int)ConstantManagement.DB_Status.ctDB_EOF;
			}
			catch (Exception)
			{
				// エラー！
				return -1;
			}
		}

		/// <summary>
		/// 対象データチェック
		/// </summary>
		/// <param name="prtManage">対象データ</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <returns>チェック結果（true:OK false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 対象データとパラメータを比較します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private bool checkTarGetData(PrtManage prtManage, ConstantManagement.LogicalMode logicalMode)
		{
			if (logicalMode == ConstantManagement.LogicalMode.GetData0)
			{
				if (prtManage.LogicalDeleteCode != 0) return false;
			}
			else if (logicalMode == ConstantManagement.LogicalMode.GetData1)
			{
				if (prtManage.LogicalDeleteCode != 1) return false;
			}
			
			return true;
		}

		/// <summary>
		/// キャッシュ取得処理
		/// </summary>
		/// <param name="retList">データバッファ</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="mode">0:論理削除を除く,1:論理削除を含む</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : データバッファを取得します</br>
		/// <br>Programmer : 23003 榎田　まさみ</br>
		/// <br>Date       : 2005.12.03</br>
		/// </remarks>
		public int GetBuff(out ArrayList retList, string enterpriseCode, int mode)
		{
			int status = 0;
			
			// ガイド用バッファにデータが無ければリモートより取得する
			if((_buff_PrtManage == null)||(_buff_PrtManage.Count == 0))
			{
				if(_buff_PrtManage == null){_buff_PrtManage = new ArrayList();}
				_buff_PrtManage.Clear();

				if(_logicalBuff_PrtManage == null){_logicalBuff_PrtManage = new ArrayList();}
				_logicalBuff_PrtManage.Clear();

				ArrayList prtManageAL = new ArrayList();
				status = SearchAll(out prtManageAL,enterpriseCode);

				foreach(PrtManage prtManage in prtManageAL)
				{
					if(prtManage.LogicalDeleteCode == 0)
					{
						_buff_PrtManage.Add(prtManage);
					}
					_logicalBuff_PrtManage.Add(prtManage);
				}
			}
			if(mode == 0)
			{
				retList = _buff_PrtManage;
			}
			else
			{
				retList = _logicalBuff_PrtManage;
			}

			return status;
		}

        /// <summary>
        /// プリンタ管理読み込み処理(キャッシュから)
        /// </summary>
        /// <param name="prtManage">プリンタ管理オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="printerMngNo">プリンタ管理No</param>
        /// <returns>プリンタ管理クラス</returns>
        /// <remarks>
        /// <br>Note       : プリンタ管理情報をキャッシュから読み込みます。</br>
        /// <br>Programmer : 22011 柏原　頼人</br>
        /// <br>Date       : 2006.09.05</br>
        /// </remarks>
        public int ReadStaticMemory(out PrtManage prtManage, string enterpriseCode, int printerMngNo)
        {
            prtManage = null;

            try
            {
                int status = 0;

                // ガイド用バッファにデータが無ければXMLより取得する
                if ((_buff_PrtManage == null) || (_buff_PrtManage.Count == 0))
                {
                    if (_buff_PrtManage == null) { _buff_PrtManage = new ArrayList(); }
                    _buff_PrtManage.Clear();

                    if (_logicalBuff_PrtManage == null) { _logicalBuff_PrtManage = new ArrayList(); }
                    _logicalBuff_PrtManage.Clear();

                    ArrayList prtManageAL = new ArrayList();
                    status = SearchAll(out prtManageAL, enterpriseCode);

                    foreach (PrtManage prtMng in prtManageAL)
                    {
                        if (prtMng.LogicalDeleteCode == 0)
                        {
                            _buff_PrtManage.Add(prtMng);
                        }
                        _logicalBuff_PrtManage.Add(prtMng);
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
                // カウントが０件なら終了
                if (_logicalBuff_PrtManage.Count == 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    foreach (PrtManage prtManageTemp in _logicalBuff_PrtManage)
                    {
                        if ((prtManageTemp.EnterpriseCode == enterpriseCode) && (prtManageTemp.PrinterMngNo == printerMngNo))
                        {
                            prtManage = prtManageTemp.Clone();
                        }
                    }
                    if (prtManage == null)
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }

                return status;
            }
            catch (Exception)            
            {
                prtManage = null;
                // 通信エラーは-1を戻す
                return -1;
            }
        }
	}

    /// <summary>
    /// 電子帳簿連携サポート設定情報
    /// </summary>
    /// <remarks> 
    /// </remarks>
    public class eBooksOutputSetting
    {
        /// <summary>
        /// 電子帳簿連携サポート設定情報
        /// </summary>
        public eBooksOutputSetting()
        {

        }

        /// <summary>伝票PDF出力</summary>
        private string _eBooksOutputMode;
        /// <summary>PDF出力伝票タイプ</summary>
        private string _eBooksOutputSlipType;
        /// <summary>PDFプリンタ</summary>
        private string _eBooksPDFPrinter;
        /// <summary>PDFプリンタ管理番号</summary>
        private string _eBooksPDFPrinterNumber;
        /// <summary>PDFプリンタ待機時間</summary>
        private string _eBooksPDFPrinterWait;


        /// <summary>伝票PDF出力</summary>
        public string OutPutMode
        {
            get { return _eBooksOutputMode; }
            set { _eBooksOutputMode = value; }
        }
        /// <summary>PDF出力伝票タイプ</summary>
        public string OutputSlipType
        {
            get { return _eBooksOutputSlipType; }
            set { _eBooksOutputSlipType = value; }
        }
        /// <summary>PDFプリンタ</summary>
        public string PDFPrinter
        {
            get { return _eBooksPDFPrinter; }
            set { _eBooksPDFPrinter = value; }
        }
        /// <summary>PDFプリンタ管理番号</summary>
        public string PDFPrinterNumber
        {
            get { return _eBooksPDFPrinterNumber; }
            set { _eBooksPDFPrinterNumber = value; }
        }
        /// <summary>PDFプリンタ待機時間</summary>
        public string PDFPrinterWait
        {
            get { return _eBooksPDFPrinterWait; }
            set { _eBooksPDFPrinterWait = value; }
        }
    }
}