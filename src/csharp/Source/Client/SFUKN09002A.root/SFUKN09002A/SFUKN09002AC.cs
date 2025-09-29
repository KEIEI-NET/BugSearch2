using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
// 2008.02.12 96012 ローカルＤＢ参照対応 Begin
using Broadleaf.Application.LocalAccess;
// 2008.02.12 96012 ローカルＤＢ参照対応 end

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 自社設定テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自社設定テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 小黒大輔</br>
	/// <br>Date       : 2004.04.11</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.21 22025 當間 豊</br>
	/// <br>					・保存時にスペースカット(TrimEnd)対応</br>
    /// <br>Update Note: 2007.04.10 20031 古賀　小百合</br>
    /// <br>					・携帯.NS開発のため項目『実績用期首月』を追加</br>
    /// <br>Update Note: 2007.04.13 20031 古賀　小百合</br>
    /// <br>					・項目名及び、項目ID変更</br>
    /// <br>Update Note: 2007.05.16 20031 古賀　小百合</br>
    /// <br>					・項目追加</br>
    /// <br>Update Note:   2007.09.26 980035 金沢　貞義</br>
    /// <br>		            ・項目追加（DC.NS対応）</br>
    /// <br>Update Note:   2008.01.11 980035 金沢　貞義</br>
    /// <br>		            ・項目追加（部署管理区分）</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.12 96012　日色 馨</br>
    /// <br>           : ローカルＤＢ参照対応</br>
    /// <br>UpdateNote  : 2008/09/05 30414　忍 幸史</br>
    /// <br>           : ファイルレイアウト変更対応</br>
    /// <br>UpdateNote  : 2008.12.01 21024　佐々木 健</br>
    /// <br>           : リモート変更対応</br>
    /// <br>UpdateNote : 連番 42 zhouyu </br>
    /// <br>             2011/07/12 月次更新で、古いデータを削除sの対応</br>
    /// <br>UpdateNote : 2011/07/14 LDNS wangqx</br>
    /// <br>           : 自社設定テーブルにデータクリア時間をセット</br>
    /// </remarks>
	public class CompanyInfAcs
	{

		/// <summary>リモートオブジェクト格納バッファ</summary>
		private ICompanyInfDB _iCompanyInfDB = null;

//		private string fileName;//kokot

        // 2008.02.12 96012 ローカルＤＢ参照対応 Begin
        private CompanyInfLcDB _companyInfLcDB = null;
        private static bool _isLocalDBRead = false;
        // 2008.02.12 96012 ローカルＤＢ参照対応 end

        // 2008.02.12 96012 ローカルＤＢ参照対応 Begin
        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        // 2008.02.12 96012 ローカルＤＢ参照対応 end

		/// <summary>
		/// 自社設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 自社設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.12 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
		public CompanyInfAcs()
		{
			try
			{
				// リモートオブジェクト取得
				this._iCompanyInfDB = (ICompanyInfDB)MediationCompanyInfDB.GetCompanyInfDB();
				// XMLファイル名を設定
//				this.fileName = "CompanyInf.xml";
			}
			catch (Exception ex)
			{
				if(ex.Message=="")
					this._iCompanyInfDB = null;
				
				//オフライン時はnullをセット
 				this._iCompanyInfDB = null;
			}
            // 2008.02.12 96012 ローカルＤＢ参照対応 Begin
            // ローカルDBアクセスオブジェクト取得
            this._companyInfLcDB = new CompanyInfLcDB();
            // 2008.02.12 96012 ローカルＤＢ参照対応 end
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
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int GetOnlineMode()
		{
 			if (this._iCompanyInfDB == null)
 			{
				return (int)OnlineMode.Offline;
 			}
 			else
 			{
				return (int)OnlineMode.Online;
 			}
		}

		/// <summary>
		/// 自社設定読み込み処理
		/// </summary>
		/// <param name="companyInf">自社設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>自社設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 自社設定を読み込みます。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.12 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
		public int Read(out CompanyInf companyInf, string enterpriseCode)
		{			
			try
			{
				companyInf = null;
				CompanyInfWork companyInfWork	= new CompanyInfWork();
				companyInfWork.EnterpriseCode	= enterpriseCode;
				companyInfWork.CompanyCode		= 0;	//←取りあえず０固定読み

                // 2008.02.12 96012 ローカルＤＢ参照対応 Begin
                //// XMLへ変換し、文字列のバイナリ化
				//byte[] parabyte = XmlByteSerializer.Serialize(companyInfWork);
                //
				////自賠責設定読み込み
				//int status = this._iCompanyInfDB.Read(ref parabyte,0);
                //
				//if (status == 0)
				//{
				//	// XMLの読み込み
				//	companyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyInfWork));
				//	// クラス内メンバコピー
				//	companyInf = CopyToCompanyInfFromCompanyInfWork(companyInfWork);
				//}
                int status;
                if (_isLocalDBRead)
                {
                    status = this._companyInfLcDB.Read(ref companyInfWork, 0);
                    if (status == 0)
                    {
                        // クラス内メンバコピー
                        companyInf = CopyToCompanyInfFromCompanyInfWork(companyInfWork);
                    }
                }
                else
                {
                    // 2008.12.01 Update >>>
                    //// XMLへ変換し、文字列のバイナリ化
                    //byte[] parabyte = XmlByteSerializer.Serialize(companyInfWork);
                    ////自賠責設定読み込み
                    //status = this._iCompanyInfDB.Read(ref parabyte, 0);

                    //if (status == 0)
                    //{
                    //    // XMLの読み込み
                    //    companyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(parabyte, typeof(CompanyInfWork));
                    //    // クラス内メンバコピー
                    //    companyInf = CopyToCompanyInfFromCompanyInfWork(companyInfWork);
                    //}

                    object paraObj = companyInfWork;
                    status = this._iCompanyInfDB.Read(ref paraObj, 0);
                    if (status == 0)
                    {
                        companyInfWork = (CompanyInfWork)paraObj;
                        companyInf = CopyToCompanyInfFromCompanyInfWork(companyInfWork);
                    }
                    // 2008.12.01 Update <<<
                }
                // 2008.02.12 96012 ローカルＤＢ参照対応 end
				
				return status;
			}
			catch (Exception)
			{
				//通信エラーは-1を戻す
				companyInf = null;
				//オフライン時はnullをセット
				this._iCompanyInfDB = null;
				return -1;
			}
		}
#if xml			
			try
			{
				companyInf = null;
				//自社設定読み込み
				int status = 0;

				if (System.IO.File.Exists(fileName))
				{
					// XMLの読み込み（自社設定Listクラスデシリアライズ処理）
					//					ArrayList CompanyInfList = this.CompanyInfListDeserialize(this.fileName);
					CompanyInf company = this.CompanyInfDeserialize(this.fileName);
					companyInf = company;
					// 対象データチェック用パラメータ
					//					CompanyInf clCompanyInfPara = new CompanyInf();
					//					clCompanyInfPara.EnterpriseCode = enterpriseCode;
					//					foreach (CompanyInf clCompanyInf in CompanyInfList)
					//					{
					//						if (!checkTarGetData(clCompanyInf,clCompanyInfPara))
					//						{
					//							CompanyInf = clCompanyInf.Clone();
					//							break;
					//						}
					//						else
					//						{
					//							CompanyInf = clCompanyInf;
					//							break;
					//						}
					//					}
				}
				else
				{
					status = 9;
				}

				return status;
			}
			catch (Exception)
			{				
				//通信エラーは-1を戻す
				companyInf = null;
				//オフライン時はnullをセット
//koko 				this._iCompanyInfDB = null;
				return -1;
			}
#endif
#if xml
		/// <summary>
		/// 自社設定クラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>自社設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 自社設定クラスをデシリアライズします。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public CompanyInf CompanyInfDeserialize(string fileName)
		{
			CompanyInf companyInf = null;
			try
			{
				// ファイル名を渡してプリンタ管理ワーククラスをデシリアライズする
				companyInf = (CompanyInf)XmlByteSerializer.Deserialize(fileName,typeof(CompanyInf));

/*
				// ファイル名を渡して自社設定ワーククラスをデシリアライズする
				CompanyInfWork CompanyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(fileName,typeof(CompanyInfWork));
				//デシリアライズ結果を自社設定クラスへコピー
				if (CompanyInfWork != null) CompanyInf = CopyToCompanyInfFromCompanyInfWork(CompanyInfWork);
*/
				return companyInf;
			}
			catch(Exception ex)
			{
				string msg =ex.Message.ToString();
				if(msg=="")
					return companyInf;
				return companyInf;

			}

			}
#endif

		/// <summary>
		/// 自社設定登録・更新処理
		/// </summary>
		/// <param name="companyInf">自社設定クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社設定の登録・更新を行います。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Write(ref CompanyInf companyInf)
		{
			//クラスからワーカークラスにメンバコピー
			CompanyInfWork companyInfWork = CopyToCompanyInfWorkFromCompanyInf(companyInf);

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(companyInfWork);

			int status = 0;
			try
			{
				//書き込み
				status = this._iCompanyInfDB.Write(ref parabyte);
				if (status == 0)
				{
					// ファイル名を渡してワーククラスをデシリアライズする
					companyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyInfWork));
					// クラス内メンバコピー
					companyInf = CopyToCompanyInfFromCompanyInfWork(companyInfWork);
				}

			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iCompanyInfDB = null;
				//通信エラーは-1を戻す
				status = -1;
			}
			return status;
		}

		/// <summary>
		/// 自社設定シリアライズ処理
		/// </summary>
		/// <param name="CompanyInf">シリアライズ対象自社設定クラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 自社設定のシリアライズを行います。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void CompanyInfSerialize(CompanyInf CompanyInf,string fileName)
		{
			//プリンタ管理ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(CompanyInf,fileName);
		}

		/// <summary>
		/// 自社設定Listシリアライズ処理
		/// </summary>
		/// <param name="CompanyInfList">シリアライズ対象自社設定Listクラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 自社設定List情報のシリアライズを行います。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void CompanyInfListSerialize(ArrayList CompanyInfList,string fileName)
		{
			// ArrayListから配列を生成
			CompanyInf[] CompanyInfs = (CompanyInf[])CompanyInfList.ToArray(typeof(CompanyInf));
			// プリンタ管理ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(CompanyInfs,fileName);

		}
#if false   //自社マスメンは１レコードの為、削除・サーチは不要
		/// <summary>
		/// 自社設定論理削除処理
		/// </summary>
		/// <param name="CompanyInf">自社設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社設定の論理削除を行います。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int LogicalDeleteCompanyInf(ref CompanyInf CompanyInf)
		{
			try
			{
				int status = 0;

				CompanyInf[] CompanyInfs;
				ArrayList CompanyInfList = new ArrayList();
				CompanyInfList.Clear();

				// XMLの読み込み
				CompanyInfs = (CompanyInf[])XmlByteSerializer.Deserialize(this.fileName, typeof(CompanyInf[]));
				for (int ix=0; ix<CompanyInfs.Length; ix++)
				{
					// 削除対象データなら論理削除区分を立ててコレクションに追加
					if (CompanyInfs[ix].Equals(CompanyInf))
					{
						CompanyInf.LogicalDeleteCode = 1;
						CompanyInfList.Add(CompanyInf);
					} 
					else
					{
						CompanyInfList.Add(CompanyInfs[ix]);
					}
				}
				// XMLの書き込み（プリンタ管理Listシリアライズ処理）
				this.CompanyInfListSerialize(CompanyInfList, this.fileName);

				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
//koko			this._iCompanyInfDB = null;
				//通信エラーは-1を戻す
				return -1;
			}
		}


		/// <summary>
		/// 自社設定物理削除処理
		/// </summary>
		/// <param name="CompanyInf">自社設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社設定の物理削除を行います。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int DeleteCompanyInf(CompanyInf CompanyInf)
		{
			try
			{
				int status = 0;

				CompanyInf[] CompanyInfs;
				ArrayList CompanyInfList = new ArrayList();
				CompanyInfList.Clear();

				// XMLの読み込み
				CompanyInfs = (CompanyInf[])XmlByteSerializer.Deserialize(this.fileName, typeof(CompanyInf[]));
				for (int ix=0; ix<CompanyInfs.Length; ix++)
				{
					// 削除対象データでなかったらコレクションに追加
					if (!CompanyInfs[ix].Equals(CompanyInf))
						CompanyInfList.Add(CompanyInfs[ix]);
				}
				this.CompanyInfListSerialize(CompanyInfList, this.fileName);

				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
//koko				this._iCompanyInfDB = null;
				//通信エラーは-1を戻す
				return -1;
			}
		}


		/// <summary>
		/// 自社設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : 自社設定検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchCntCompanyInf(out int retTotalCnt,string enterpriseCode)
		{
			return SearchCntCompanyInfProc(out retTotalCnt,enterpriseCode,0);
		}

		/// <summary>
		/// 自社設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : 自社設定検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchAllCntCompanyInf(out int retTotalCnt,string enterpriseCode)
		{
			return SearchCntCompanyInfProc(out retTotalCnt,enterpriseCode,ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// 自社設定数検索処理
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:全ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社設定数の検索を行います。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private int SearchCntCompanyInfProc(out int retTotalCnt,string enterpriseCode,ConstantManagement.LogicalMode logicalMode)
		{
			retTotalCnt = 0;

			// XMLの読み込み
//			ArrayList CompanyInfList = this.CompanyInfListDeserialize(this.fileName);
//			CompanyInf company = this.CompanyInfDeserialize(this.fileName);
						
			// 対象データチェック用パラメータ
//			CompanyInf CompanyInfPara = new CompanyInf();
//			CompanyInfPara.EnterpriseCode = enterpriseCode;
//			foreach (CompanyInf CompanyInf in CompanyInfList)
//			{
//				if (checkTarGetData(CompanyInf,CompanyInfPara))
//					retTotalCnt++;
//			}

			retTotalCnt=1;
			int status = 0;
				
			return status;
		}

		/// <summary>
		/// 自社設定全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社設定の全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchCompanyInf(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int  retTotalCnt;
			return SearchCompanyInfProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,0,null);			
		}

		/// <summary>
		/// 自社設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchAllCompanyInf(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int	 retTotalCnt;
			return SearchCompanyInfProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData01,0,null);
		}

		/// <summary>
		/// 件数指定自社設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevCompanyInf">前回最終自社設定データオブジェクト（初回はnull指定必須）</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して自社設定の検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchSpecificationCompanyInf(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,CompanyInf prevCompanyInf)
		{			
			return SearchCompanyInfProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,readCnt,prevCompanyInf);			
		}

		/// <summary>
		/// 件数指定自社設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevCompanyInfがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevCompanyInf">前回最終自社設定データオブジェクト（初回はnull指定必須）</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して自社設定の検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchSpecificationAllCompanyInf(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,CompanyInf prevCompanyInf)
		{			
			return SearchCompanyInfProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData0,readCnt,prevCompanyInf);

			
		}

		/// <summary>
		/// 自社設定論理削除復活処理
		/// </summary>
		/// <param name="CompanyInf">自社設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社設定の復活を行います。</br>
		/// <br>Programmer : 坂本明夫</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int RevivalCompanyInf(ref CompanyInf CompanyInf)
		{
			try
			{
				int status = 0;

				CompanyInf[] CompanyInfs;
				ArrayList CompanyInfList = new ArrayList();
				CompanyInfList.Clear();

				// XMLの読み込み
				CompanyInfs = (CompanyInf[])XmlByteSerializer.Deserialize(this.fileName, typeof(CompanyInf[]));
				for (int ix=0; ix<CompanyInfs.Length; ix++)
				{
					// 削除対象データなら論理削除区分を正常に戻してコレクションに追加
					if (CompanyInfs[ix].Equals(CompanyInf))
					{
						CompanyInf.LogicalDeleteCode = 0;
						CompanyInfList.Add(CompanyInf);
					} 
					else
					{
						CompanyInfList.Add(CompanyInfs[ix]);
					}
				}
				// XMLの書き込み（プリンタ管理Listシリアライズ処理）
				this.CompanyInfListSerialize(CompanyInfList, this.fileName);

				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
//koko				this._iCompanyInfDB = null;
				//通信エラーは-1を戻す
				return -1;
			}
		}


		/// <summary>
		/// 自社設定検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
		/// <param name="prevCompanyInf">前回最終自社設定データオブジェクト（初回はnull指定必須）</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社設定の検索処理を行います。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private int SearchCompanyInfProc(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,ConstantManagement.LogicalMode logicalMode,int readCnt,CompanyInf prevCompanyInf)
		{
			// 次データ有無初期化
			nextData = false;
			// 読込対象データ総件数0で初期化
			retTotalCnt = 0;

			CompanyInf[] CompanyInfs;
			retList = new ArrayList();
			retList.Clear();

			// 対象データチェック用パラメータ
			CompanyInf CompanyInfPara = new CompanyInf();
			CompanyInfPara.EnterpriseCode = enterpriseCode;

			try
			{
				// XMLの読み込み
				CompanyInfs = (CompanyInf[])XmlByteSerializer.Deserialize(this.fileName, typeof(CompanyInf[]));
				// 全件リード？
				if (readCnt == 0) 
				{
					for (int ix=0; ix<CompanyInfs.Length; ix++)
					{
						// 読込結果コレクションに追加
						if (checkTarGetData(CompanyInfs[ix],CompanyInfPara))
							retList.Add(CompanyInfs[ix]);
					}
					// 読込対象データ総件数←ArrayListの件数
					retTotalCnt = retList.Count;
				}
				else
				{	// 読込件数指定リード
					
					// 読込対象データ総件数←配列要素数
					retTotalCnt = CompanyInfs.Length;
					// 前回データがない？
					if (prevCompanyInf == null)	 
					{
						for (int ix=0; ix<CompanyInfs.Length; ix++)
						{
							// 読込件数に達したら抜ける
							if (retList.Count >= readCnt)
							{
								nextData = true;	// これ要らんかも
								break;
							}
							// 読込結果コレクションに追加
							if (checkTarGetData(CompanyInfs[ix],CompanyInfPara))
								retList.Add(CompanyInfs[ix]);
						}
					}
					else
					{	// 前回データがない

						// 前回データのインデックスを初期化
						int dataIndex = -1;
						
						for (int ix=0; ix<CompanyInfs.Length; ix++)
						{
							// 読込件数に達したら抜ける
							if (retList.Count >= readCnt)
							{
								nextData = true;	// これ要らんかも
								break;
							}
							// 前回データが見つかったらインデックスを退避しておく
							if (CompanyInfs[ix].Equals(prevCompanyInf) == true)
								dataIndex = ix;
							// 前回データの次のデータ以降を読込結果コレクションに追加
							if ((dataIndex >= 0) && (ix > dataIndex))
								if (checkTarGetData(CompanyInfs[ix],CompanyInfPara))
									retList.Add(CompanyInfs[ix]);
						}
					}
				}

				int status = 0;
				// 読込結果なしの場合はEOFを返す
				if (retList.Count <= 0)
					status = (int)ConstantManagement.DB_Status.ctDB_EOF;

				return status;
			}
			catch (System.IO.FileNotFoundException)
			{
				return (int)ConstantManagement.DB_Status.ctDB_EOF;
			}
			catch (Exception)
			{
				return -1;
			}
		}

		/// <summary>
		/// 自社設定検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社設定の検索処理を行い、取得結果をDataSetで返します。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchCompanyInfDS(ref DataSet ds,string enterpriseCode)
		{
			CompanyInf[] CompanyInfs;
			ArrayList CompanyInfList = new ArrayList();
			CompanyInfList.Clear();

			// 対象データチェック用パラメータ
			CompanyInf CompanyInfPara = new CompanyInf();
			CompanyInfPara.EnterpriseCode = enterpriseCode;

			try
			{
				// XMLの読み込み
				CompanyInfs = (CompanyInf[])XmlByteSerializer.Deserialize(this.fileName, typeof(CompanyInf[]));
				
				// 対象データをコレクションに追加
				for (int ix=0; ix<CompanyInfs.Length; ix++)
				{
					if (checkTarGetData(CompanyInfs[ix],CompanyInfPara))
						CompanyInfList.Add(CompanyInfs[ix]);
				}
				// ArrayListから配列を生成
				CompanyInfs = (CompanyInf[])CompanyInfList.ToArray(typeof(CompanyInf));
				// クラスをXMLバイト列へ変換
				byte[] buffer = XmlByteSerializer.Serialize(CompanyInfs);
				// DataSet XML読み込み
				XmlByteSerializer.ReadXml(ref ds, buffer);

				return 0;
			}
			catch (System.IO.FileNotFoundException)
			{
				return (int)ConstantManagement.DB_Status.ctDB_EOF;
			}
			catch (Exception)
			{
				return -1;
			}
		}
#endif

		/// <summary>
		/// クラスメンバーコピー処理（自社設定ワーククラス⇒自社設定クラス）
		/// </summary>
		/// <param name="CompanyInfWork">自社設定ワーククラス</param>
		/// <returns>自社設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 自社設定ワーククラスから自社設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.04.14</br>
		/// </remarks>
		private CompanyInf CopyToCompanyInfFromCompanyInfWork(CompanyInfWork CompanyInfWork)
		{
			CompanyInf CompanyInf = new CompanyInf();

			//ファイルヘッダ部分
			CompanyInf.CreateDateTime			= CompanyInfWork.CreateDateTime;
			CompanyInf.UpdateDateTime			= CompanyInfWork.UpdateDateTime;
			CompanyInf.EnterpriseCode			= CompanyInfWork.EnterpriseCode;
			CompanyInf.FileHeaderGuid			= CompanyInfWork.FileHeaderGuid;
			CompanyInf.UpdEmployeeCode		    = CompanyInfWork.UpdEmployeeCode;
			CompanyInf.UpdAssemblyId1			= CompanyInfWork.UpdAssemblyId1;
			CompanyInf.UpdAssemblyId2			= CompanyInfWork.UpdAssemblyId2;
			CompanyInf.LogicalDeleteCode		= CompanyInfWork.LogicalDeleteCode;

			CompanyInf.CompanyCode				= CompanyInfWork.CompanyCode;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			CompanyInf.CompanyPr				= CompanyInfWork.CompanyPr;
//			CompanyInf.CompanyName1				= CompanyInfWork.CompanyName1;
//			CompanyInf.CompanyName2				= CompanyInfWork.CompanyName2;
//			CompanyInf.PostNo					= CompanyInfWork.PostNo;
//			CompanyInf.Address1					= CompanyInfWork.Address1;
//			CompanyInf.Address2					= CompanyInfWork.Address2;
//			CompanyInf.Address3					= CompanyInfWork.Address3;
//			CompanyInf.Address4					= CompanyInfWork.Address4;
//			CompanyInf.CompanyTelNo1			= CompanyInfWork.CompanyTelNo1;
//			CompanyInf.CompanyTelNo2			= CompanyInfWork.CompanyTelNo2;
//			CompanyInf.CompanyTelNo3			= CompanyInfWork.CompanyTelNo3;
//			CompanyInf.CompanyTelTitle1			= CompanyInfWork.CompanyTelTitle1;
//			CompanyInf.CompanyTelTitle2			= CompanyInfWork.CompanyTelTitle2;
//			CompanyInf.CompanyTelTitle3			= CompanyInfWork.CompanyTelTitle3;
//			CompanyInf.TransferGuidance			= CompanyInfWork.TransferGuidance;
//			CompanyInf.AccountNoInfo1			= CompanyInfWork.AccountNoInfo1;
//			CompanyInf.AccountNoInfo2			= CompanyInfWork.AccountNoInfo2;
//			CompanyInf.AccountNoInfo3			= CompanyInfWork.AccountNoInfo3;
//			CompanyInf.CompanySetNote1			= CompanyInfWork.CompanySetNote1;
//			CompanyInf.CompanySetNote2			= CompanyInfWork.CompanySetNote2;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			CompanyInf.CompanyTotalDay			= CompanyInfWork.CompanyTotalDay;
            CompanyInf.CompanyBiginMonth        = CompanyInfWork.CompanyBiginMonth;
            
            // 2007.04.13  S.Koga  amend --------------------------------------
            // 2007.04.10  S.Koga  add ----------------------------------------
            //CompanyInf.CompRestBiginMonth     = CompanyInfWork.CompRestBiginMonth;
            // ----------------------------------------------------------------
            CompanyInf.CompanyBiginMonth2       = CompanyInfWork.CompanyBiginMonth2;
            // ----------------------------------------------------------------

            // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
            CompanyInf.FinancialYear            = CompanyInfWork.FinancialYear;
            CompanyInf.CompanyBiginDate         = CompanyInfWork.CompanyBiginDate;
            CompanyInf.StartYearDiv             = CompanyInfWork.StartYearDiv;
            CompanyInf.StartMonthDiv            = CompanyInfWork.StartMonthDiv;
            // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<
            // 2008.01.11 追加 >>>>>>>>>>>>>>>>>>>>
            CompanyInf.SecMngDiv                = CompanyInfWork.SecMngDiv;
            // 2008.01.11 追加 <<<<<<<<<<<<<<<<<<<<

            // 2007.05.16  S.Koga  add ----------------------------------------
            CompanyInf.CompanyName1 = CompanyInfWork.CompanyName1;
            CompanyInf.CompanyName2 = CompanyInfWork.CompanyName2;
            // ----------------------------------------------------------------

            // --- ADD 2008/09/05 --------------------------------------------------------------------->>>>>
            CompanyInf.PostNo = CompanyInfWork.PostNo;
            CompanyInf.Address1 = CompanyInfWork.Address1;
            CompanyInf.Address3 = CompanyInfWork.Address3;
            CompanyInf.Address4 = CompanyInfWork.Address4;
            CompanyInf.CompanyTelTitle1 = CompanyInfWork.CompanyTelTitle1;
            CompanyInf.CompanyTelTitle2 = CompanyInfWork.CompanyTelTitle2;
            CompanyInf.CompanyTelTitle3 = CompanyInfWork.CompanyTelTitle3;
            CompanyInf.CompanyTelNo1 = CompanyInfWork.CompanyTelNo1;
            CompanyInf.CompanyTelNo2 = CompanyInfWork.CompanyTelNo2;
            CompanyInf.CompanyTelNo3 = CompanyInfWork.CompanyTelNo3;
            // --- ADD 2008/09/05 ---------------------------------------------------------------------<<<<<
            //ADD START 2011/07/12 zhouyu FOR 連番 42 ------------------->>>>>>
            CompanyInf.DataSaveMonths = CompanyInfWork.DataSaveMonths;
            CompanyInf.DataCompressDt = CompanyInfWork.DataCompressDt;
            CompanyInf.ResultDtSaveMonths = CompanyInfWork.ResultDtSaveMonths;
            CompanyInf.ResultDtCompressDt = CompanyInfWork.ResultDtCompressDt;
            CompanyInf.CaPrtsDtSaveMonths = CompanyInfWork.CaPrtsDtSaveMonths;
            CompanyInf.CaPrtsDtCompressDt = CompanyInfWork.CaPrtsDtCompressDt;
            CompanyInf.MasterSaveMonths = CompanyInfWork.MasterSaveMonths;
            CompanyInf.MasterCompressDt = CompanyInfWork.MasterCompressDt;
            CompanyInf.RatePriorityDiv = CompanyInfWork.RatePriorityDiv;
            //ADD END 2011/07/12 zhouyu FOR 連番 42 ---------------------<<<<<<
            // -- ADD 2011/07/14 ------------------------------------------->>>
            CompanyInf.DataClrExecDate = CompanyInfWork.DataClrExecDate;
            CompanyInf.DataClrExecTime = CompanyInfWork.DataClrExecTime;
            // -- ADD 2011/07/14 -------------------------------------------<<<
			// 自社名称読み込み
			return CompanyInf;
		}

		/// <summary>
		/// クラスメンバーコピー処理（自社設定クラス⇒自社設定ワーククラス）
		/// </summary>
		/// <param name="CompanyInf">自社設定ワーククラス</param>
		/// <returns>自社設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 自社設定クラスから自社設定ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private CompanyInfWork CopyToCompanyInfWorkFromCompanyInf(CompanyInf CompanyInf)
		{
			CompanyInfWork CompanyInfWork = new CompanyInfWork();

			CompanyInfWork.CreateDateTime			= CompanyInf.CreateDateTime;
			CompanyInfWork.UpdateDateTime			= CompanyInf.UpdateDateTime;
			CompanyInfWork.EnterpriseCode			= CompanyInf.EnterpriseCode.Trim();
			CompanyInfWork.FileHeaderGuid			= CompanyInf.FileHeaderGuid;
			CompanyInfWork.UpdEmployeeCode		    = CompanyInf.UpdEmployeeCode;
			CompanyInfWork.UpdAssemblyId1			= CompanyInf.UpdAssemblyId1;
			CompanyInfWork.UpdAssemblyId2			= CompanyInf.UpdAssemblyId2;
			CompanyInfWork.LogicalDeleteCode		= CompanyInf.LogicalDeleteCode;

			CompanyInfWork.CompanyCode				= CompanyInf.CompanyCode;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			CompanyInfWork.CompanyPr				= CompanyInf.CompanyPr.TrimEnd();
//			CompanyInfWork.CompanyName1				= CompanyInf.CompanyName1.TrimEnd();
//			CompanyInfWork.CompanyName2				= CompanyInf.CompanyName2.TrimEnd();
//			CompanyInfWork.PostNo					= CompanyInf.PostNo;
//			CompanyInfWork.Address1					= CompanyInf.Address1.TrimEnd();
//			CompanyInfWork.Address2					= CompanyInf.Address2;
//			CompanyInfWork.Address3					= CompanyInf.Address3.TrimEnd();
//			CompanyInfWork.Address4					= CompanyInf.Address4.TrimEnd();
//			CompanyInfWork.CompanyTelNo1			= CompanyInf.CompanyTelNo1.Trim();
//			CompanyInfWork.CompanyTelNo2			= CompanyInf.CompanyTelNo2.Trim();
//			CompanyInfWork.CompanyTelNo3			= CompanyInf.CompanyTelNo3.Trim();
//			CompanyInfWork.CompanyTelTitle1			= CompanyInf.CompanyTelTitle1.TrimEnd();
//			CompanyInfWork.CompanyTelTitle2			= CompanyInf.CompanyTelTitle2.TrimEnd();
//			CompanyInfWork.CompanyTelTitle3			= CompanyInf.CompanyTelTitle3.TrimEnd();
//			CompanyInfWork.TransferGuidance			= CompanyInf.TransferGuidance.TrimEnd();
//			CompanyInfWork.AccountNoInfo1			= CompanyInf.AccountNoInfo1.TrimEnd();
//			CompanyInfWork.AccountNoInfo2			= CompanyInf.AccountNoInfo2.TrimEnd();
//			CompanyInfWork.AccountNoInfo3			= CompanyInf.AccountNoInfo3.TrimEnd();
//			CompanyInfWork.CompanySetNote1			= CompanyInf.CompanySetNote1.TrimEnd();
//			CompanyInfWork.CompanySetNote2			= CompanyInf.CompanySetNote2.TrimEnd();
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			CompanyInfWork.CompanyTotalDay			= CompanyInf.CompanyTotalDay;
            CompanyInfWork.CompanyBiginMonth        = CompanyInf.CompanyBiginMonth;
            
            // 2007.04.13  S.Koga  amend --------------------------------------
            // 2007.04.10  S.Koga  add ----------------------------------------
            //CompanyInfWork.CompRestBiginMonth     = CompanyInf.CompRestBiginMonth;
            // ----------------------------------------------------------------
            CompanyInfWork.CompanyBiginMonth2       = CompanyInf.CompanyBiginMonth2;
            // ----------------------------------------------------------------

            // 2007.09.26 修正 >>>>>>>>>>>>>>>>>>>>
            CompanyInfWork.FinancialYear            = CompanyInf.FinancialYear;
            CompanyInfWork.CompanyBiginDate         = CompanyInf.CompanyBiginDate;
            CompanyInfWork.StartYearDiv             = CompanyInf.StartYearDiv;
            CompanyInfWork.StartMonthDiv            = CompanyInf.StartMonthDiv;
            // 2007.09.26 修正 <<<<<<<<<<<<<<<<<<<<
            // 2008.01.11 追加 >>>>>>>>>>>>>>>>>>>>
            CompanyInfWork.SecMngDiv                = CompanyInf.SecMngDiv;
            // 2008.01.11 追加 <<<<<<<<<<<<<<<<<<<<

            // 2007.05.16  S.Koga  add ----------------------------------------
            CompanyInfWork.CompanyName1 = CompanyInf.CompanyName1;
            CompanyInfWork.CompanyName2 = CompanyInf.CompanyName2;
            // ----------------------------------------------------------------

            // --- ADD 2008/09/05 --------------------------------------------------------------------->>>>>
            CompanyInfWork.PostNo = CompanyInf.PostNo;
            CompanyInfWork.Address1 = CompanyInf.Address1;
            CompanyInfWork.Address3 = CompanyInf.Address3;
            CompanyInfWork.Address4 = CompanyInf.Address4;
            CompanyInfWork.CompanyTelTitle1 = CompanyInf.CompanyTelTitle1;
            CompanyInfWork.CompanyTelTitle2 = CompanyInf.CompanyTelTitle2;
            CompanyInfWork.CompanyTelTitle3 = CompanyInf.CompanyTelTitle3;
            CompanyInfWork.CompanyTelNo1 = CompanyInf.CompanyTelNo1;
            CompanyInfWork.CompanyTelNo2 = CompanyInf.CompanyTelNo2;
            CompanyInfWork.CompanyTelNo3 = CompanyInf.CompanyTelNo3;
            // --- ADD 2008/09/05 ---------------------------------------------------------------------<<<<<
            //ADD START 2011/07/12 zhouyu FOR 連番 42 ------------------->>>>>>
            CompanyInfWork.DataSaveMonths = CompanyInf.DataSaveMonths;
            CompanyInfWork.DataCompressDt = CompanyInf.DataCompressDt;
            CompanyInfWork.ResultDtSaveMonths = CompanyInf.ResultDtSaveMonths;
            CompanyInfWork.ResultDtCompressDt = CompanyInf.ResultDtCompressDt;
            CompanyInfWork.CaPrtsDtSaveMonths = CompanyInf.CaPrtsDtSaveMonths;
            CompanyInfWork.CaPrtsDtCompressDt = CompanyInf.CaPrtsDtCompressDt;
            CompanyInfWork.MasterSaveMonths = CompanyInf.MasterSaveMonths;
            CompanyInfWork.MasterCompressDt = CompanyInf.MasterCompressDt;
            CompanyInfWork.RatePriorityDiv = CompanyInf.RatePriorityDiv;
            //ADD END 2011/07/12 zhouyu FOR 連番 42 ---------------------<<<<<<
            // -- ADD 2011/07/14 ------------------------------------------->>>
            CompanyInfWork.DataClrExecDate = CompanyInf.DataClrExecDate;
            CompanyInfWork.DataClrExecTime = CompanyInf.DataClrExecTime;
            // -- ADD 2011/07/14 -------------------------------------------<<<

            return CompanyInfWork;
		}
#if false
		/// <summary>
		/// 対象データチェック
		/// </summary>
		/// <param name="CompanyInf">対象データ</param>
		/// <param name="CompanyInfPara">パラメータ</param>
		/// <returns>チェック結果（true:OK false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 対象データとパラメータを比較します。</br>
		/// <br>Programmer : 小黒大輔</br>
		/// <br>Date       : 2005.03.24</br>
		/// </remarks>
		private bool checkTarGetData(
			CompanyInf CompanyInf,
			CompanyInf CompanyInfPara)
		{
			// 企業コードを比較
			if (CompanyInfPara.EnterpriseCode != null)
			{
				if (!CompanyInfPara.EnterpriseCode.Equals(CompanyInf.EnterpriseCode))
					return false;
			}
			return true;
		}
#endif

        // -- ADD 2011/07/14 ------------------------------------------->>>
        /// <summary>
        /// 自社情報マスタにデータクリア時間更新処理
        /// </summary>
        /// <param name="companyInf">自社情報</param>
        /// <param name="DelYMD">データクリア年月日</param>
        /// <param name="DelHMSXXX">データクリア時分秒ミリ秒</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データクリア時間更新を行います。</br>
        /// <br>Programmer : LDNS wangqx</br>
        /// <br>Date       : 2011.07.14</br>
        /// </remarks>
        public int WriteClearTime(CompanyInf companyInf, String DelYMD, String DelHMSXXX, out string errMsg)
        {
            int status = 0;

            //クラスからワーカークラスにメンバコピー
            CompanyInfWork companyInfWork = CopyToCompanyInfWorkFromCompanyInf(companyInf);
            errMsg = string.Empty;
            object paraObj = companyInfWork;

            try
            {
                //書き込み
                status = this._iCompanyInfDB.WriteClearTime(paraObj, DelYMD, DelHMSXXX, out errMsg);
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iCompanyInfDB = null;
                //通信エラーは-1を戻す
                status = -1;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードのデータクリア時間を戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="DelYMD">データクリア年月日</param>
        /// <param name="DelHMSXXX">データクリア時分秒ミリ秒</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのデータクリア時間を戻します</br>
        /// <br>Programmer : LDNS wangqx</br>
        /// <br>Date       : 2011.07.14</br>
        public int ReadClearTime(string enterpriseCode, out Int32 DelYMD, out Int32 DelHMSXXX)
        {
            DelYMD = 0;
            DelHMSXXX = 0;
            try
			{   
                int status;
                status = this._iCompanyInfDB.ReadClearTime(enterpriseCode, out DelYMD, out DelHMSXXX);
				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iCompanyInfDB = null;
				return -1;
			}
        }
        // -- ADD 2011/07/14 -------------------------------------------<<<
	}
}
