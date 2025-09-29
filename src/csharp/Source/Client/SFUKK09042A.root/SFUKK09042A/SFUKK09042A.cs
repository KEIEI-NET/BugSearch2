using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
// TODO : ↓SFCMN00201u SFCMN00212i の参照を追加
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.LocalAccess;


namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 金額種別設定テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 金額種別設定テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 97134 元村 雅博</br>
	/// <br>Date       : 2005.06.24</br>
	/// <br></br>
	/// <br>UpdateNote : 2005.06.08 マスメンチーム作成仮ガイドコメントアウト</br>
	/// <br>		   : 22033 三崎  貴史 </br>
	/// <br>UpdateNode : 2005.06.13 正式ガイド対応 </br>
	/// <br>           : 99032 伊藤 美紀</br>
	/// <br>Update Note: 2005.12.17 23003 榎田　まさみ</br>
    /// <br>		   :        ・ユーザ分のみ読込・編集するよう修正</br>	
    /// <br>Update Note: 2006.12.26 22022 段上 知子</br>
    /// <br>					1.SF版を流用し携帯版を作成</br>
    /// <br>UpdateNote : 2007.04.04 980023　飯谷 耕平</br>
    /// <br>                    Read、ガイドのSearch の処理をローカルDBからの読込に変更</br>
    /// <br>UpdateNote : 2007.05.07 980023　飯谷 耕平</br>
    /// <br>                    ガイドのSearchの処理を、引数指定でリモート読込にできるよう変更</br>
    /// <br>Update Note: 2007.05.17 20031 古賀　小百合</br>
    /// <br>					項目追加</br>
    /// <br>Update Note: 2007.05.20 980023 飯谷 耕平</br>
    /// <br>					ガイドXML未指定時のデフォルトを設定</br>
    /// <br>Update Note: 2007.07.04 20031 古賀　小百合</br>
    /// <br>					Read処理をリモートDB読込もできるように変更</br>
    /// <br>Update Note: 2008.02.08 96012 日色　馨</br>
    /// <br>					DC.NS対応(通常はリモートDB読込に変更)</br>
    /// <br>Programmer : 2008/06/12 30415 柴田 倫幸</br>
    /// <br>                    項目削除の為、修正</br>
    /// </remarks>

	public class MoneyKindAcs : IGeneralGuideData
	{      
        
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private IMoneyKindDB _iMoneyKindDB = null;

        /// <summary>ローカルDBオブジェクト格納バッファ</summary>
        private MoneyKindLcDB _moneyKindLcDB = null;  // iitani a

        /// <summary>ガイド用データバッファ</summary>
		private static ArrayList _guidBuff_MoneyKind;
		// 2005.12.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
		/// <summary>論理削除用データバッファ</summary>
		private static ArrayList _Logical_guidBuff_MoneyKind = null;
		// 2005.12.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

        private const string GUIDE_SEARCHMODE_PARA = "SearchMode";                     // ガイドデータサーチモード(0:ローカル,1:リモート) iitani a 2007.05.07

        /// <summary>ローカルＤＢモード</summary>
        // 2008.02.08 96012 DC.NS対応(通常はリモートDB読込に変更) Begin
        //private static bool _isLocalDBRead = true;
        private static bool _isLocalDBRead = false;
        // 2008.02.08 96012 DC.NS対応(通常はリモートDB読込に変更) end

		/// <summary>
		/// 金額種別設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 金額種別設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public MoneyKindAcs()
		{
			try
			{
				// リモートオブジェクト取得
				this._iMoneyKindDB = (IMoneyKindDB)MediationMoneyKindDB.GetMoneyKindDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
				this._iMoneyKindDB = null;
			}

            // ローカルDBアクセスオブジェクト取得
            this._moneyKindLcDB = new MoneyKindLcDB();   // iitani a

            _guidBuff_MoneyKind = new ArrayList();
        }

		/// <summary>オンラインモードの列挙型です。</summary>
		public enum OnlineMode 
		{
			/// <summary>オフライン</summary>
			Offline,
			/// <summary>オンライン</summary>
			Online 
		}
        //================================================================================
        //  プロパティ
        //================================================================================
        #region Public Property

        /// <summary>
        /// ローカルＤＢReadモード
        /// </summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        #endregion

		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iMoneyKindDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// 金額種別設定読み込み処理
		/// </summary>
		/// <param name="moneykind">金額種別設定オブジェクト</param>
		/// <returns>金額種別設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定を読み込みます。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int Read(ref MoneyKind moneykind)
		{	

			/* 2005.12.17 enokida DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
			GetMoneyKindDataType datatype;
			if(dttype == 0) datatype = GetMoneyKindDataType.OfferMoneyKindData;  //提供ﾃﾞｰﾀ読込み
			else            datatype = GetMoneyKindDataType.UserMoneyKindData;   //ﾕｰｻﾞﾃﾞｰﾀ読込み 
			2005.12.17 enokida DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end */
            
			try
			{
               
				//読み込む為にキーとなる項目をセット
				MoneyKindWork moneykindWork     = new MoneyKindWork();
				moneykindWork.EnterpriseCode = moneykind.EnterpriseCode;
				moneykindWork.PriceStCode    = moneykind.PriceStCode;
				moneykindWork.MoneyKindCode  = moneykind.MoneyKindCode;
				moneykind = null;

                // XMLへ変換し、文字列のバイナリ化 iitani d
                //byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);

				/* 2005.12.17 enokida DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
				int status = this._iMoneyKindDB.Read(ref parabyte     //ﾊﾞｲﾅﾘﾃﾞｰﾀ
													  ,0               //現在未使用
													  ,datatype );     //提供orユーザ
				2005.12.17 enokida DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end */

				// 2005.12.17 enokida ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
                //int status = this._iMoneyKindDB.Read(ref parabyte     //ﾊﾞｲﾅﾘﾃﾞｰﾀ
                //    ,0               //現在未使用
                //    ,GetMoneyKindDataType.UserMoneyKindData );     //ユーザ
                // ローカルDBアクセス iitani c
                int status = 0;
                if (_isLocalDBRead)
                {
                    // ローカル
                    status = this._moneyKindLcDB.Read(ref moneykindWork, 0, Broadleaf.Application.LocalAccess.MoneyKindLcDB.GetMoneyKindDataType.UserMoneyKindData);     //ユーザ
                }
                else
                {
                    byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);
                    // リモート
                    status = this._iMoneyKindDB.Read(ref parabyte     //ﾊﾞｲﾅﾘﾃﾞｰﾀ
                        ,0               //現在未使用
                        ,GetMoneyKindDataType.UserMoneyKindData );     //ユーザ
                    // 2007.07.04  S.Koga  ADD --------------------------------
                    if(status == 0)
                        moneykindWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte, typeof(MoneyKindWork));
                    // --------------------------------------------------------
                }

				// 2005.12.17 enokida ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

				if (status == 0)
				{
                    // XMLの読み込み iitani d
                    //moneykindWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte, typeof(MoneyKindWork));
					// クラス内メンバコピー
					moneykind = CopyToMoneyKindFromMoneyKindWork(moneykindWork);
				}

				return status;
			}
			catch (Exception)
			{				
				//通信エラーは-1を戻す
				moneykind = null;
				//オフライン時はnullをセット
				this._iMoneyKindDB = null;

				return -1;
			}            
		}

        /// <summary>
		/// 金額種別設定クラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>金額種別設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定クラスをデシリアライズします。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
        public MoneyKind Deserialize(string fileName)
        {
            MoneyKind moneykind = null;
            // ファイル名を渡してプリンタ管理ワーククラスをデシリアライズする
            moneykind = (MoneyKind)XmlByteSerializer.Deserialize(fileName, typeof(MoneyKind));

            // ファイル名を渡して金額種別設定ワーククラスをデシリアライズする
            MoneyKindWork MoneyKindWork = (MoneyKindWork)XmlByteSerializer.Deserialize(fileName, typeof(MoneyKindWork));

            //デシリアライズ結果を金額種別設定クラスへコピー
            if (MoneyKindWork != null) moneykind = CopyToMoneyKindFromMoneyKindWork(MoneyKindWork);

            return moneykind;
        }

		/// <summary>
		/// 金額種別設定Listクラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>金額種別設定クラスLIST</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定リストクラスをデシリアライズします。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();
			// ファイル名を渡して金額種別設定ワーククラスをデシリアライズする
			MoneyKindWork[] MoneyKindWorks = (MoneyKindWork[])XmlByteSerializer.Deserialize(fileName,typeof(MoneyKindWork[]));

			//デシリアライズ結果を金額種別設定クラスへコピー
			if (MoneyKindWorks != null) 
			{
				al.Capacity = MoneyKindWorks.Length;
				for(int i=0; i < MoneyKindWorks.Length; i++)
				{
					al.Add(CopyToMoneyKindFromMoneyKindWork(MoneyKindWorks[i]));
				}
			}
			return al;

		}

		/// <summary>
		/// 金額種別設定登録・更新処理
		/// </summary>
		/// <param name="moneykind">金額種別設定クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定の登録・更新を行います。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int Write(ref MoneyKind moneykind)
		{
			// クラスからワーカークラスにメンバコピー
			MoneyKindWork moneykindWork = CopyToMoneyKindWorkFromMoneyKind(moneykind);

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);

			
			int status = 0;
			try
			{
				//				// XMLの書き込み（シリアライズ処理）
				//				this.MoneyKindSerialize(moneykind, this.fileName);
				//書き込み
				//  書込みを行えるのはユーザーデータのみ
				status = this._iMoneyKindDB.Write(ref parabyte, GetMoneyKindDataType.UserMoneyKindData);
				if ( status == 0 )
				{
					// ファイル名を渡してワーククラスをデシリアライズする
					moneykindWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte, typeof(MoneyKindWork) );
					// クラス内メンバコピー
					moneykind = CopyToMoneyKindFromMoneyKindWork(moneykindWork);

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.02 TAKAHASHI ADD START
					if(_guidBuff_MoneyKind != null)
					{
						SortedList sortList = new SortedList();
						
						//既にキャッシュがあれば削除
                        foreach (MoneyKind moneyKindwk in _guidBuff_MoneyKind)
                        {
                            if (moneyKindwk.PriceStCode == moneykind.PriceStCode)
                            {
                                if (moneyKindwk.MoneyKindCode == moneykind.MoneyKindCode)
                                {
                                    _guidBuff_MoneyKind.Remove(moneyKindwk);
                                    break;
                                }
                            }
                        }

						//キャッシュに今回Write分を追加				
						_guidBuff_MoneyKind.Add(moneykind);
						
					}
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.02 TAKAHASHI ADD END
					// 2005.12.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if(_Logical_guidBuff_MoneyKind != null)
					{
						SortedList sortList = new SortedList();

                        foreach (MoneyKind moneyKindwks in _Logical_guidBuff_MoneyKind)
                        {
							if((moneyKindwks.PriceStCode == moneykind.PriceStCode)&&
								(moneyKindwks.MoneyKindCode == moneykind.MoneyKindCode))
							{
								_Logical_guidBuff_MoneyKind.Remove(moneyKindwks);
								break;
							}
						}
						// キャッシュに追加
						_Logical_guidBuff_MoneyKind.Add(moneykind);
					}
					// 2005.12.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
				}
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iMoneyKindDB = null;
				
				// 通信エラーは-1を戻す
				status = -1;
			}
			return status;
		}

		/// <summary>
		/// 金額種別設定シリアライズ処理
		/// </summary>
		/// <param name="moneykind">シリアライズ対象金額種別設定クラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 金額種別設定のシリアライズを行います。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
        public void Serialize(MoneyKind moneykind,string fileName)
		{
			//			//プリンタ管理ワーカークラスをシリアライズ
			//			XmlByteSerializer.Serialize(moneykind,fileName);

			//金額種別設定クラスから金額種別設定ワーカークラスにメンバコピー
			MoneyKindWork MoneyKindWork = CopyToMoneyKindWorkFromMoneyKind(moneykind);
			//金額種別ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(MoneyKindWork,fileName);

		}

		/// <summary>
		/// 金額種別設定Listシリアライズ処理
		/// </summary>
		/// <param name="moneykindList">シリアライズ対象金額種別設定Listクラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 金額種別設定List情報のシリアライズを行います。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public void ListSerialize(ArrayList moneykindList,string fileName)
		{
			//			// ArrayListから配列を生成
			//			MoneyKind[] moneykinds = (MoneyKind[])moneykindList.ToArray(typeof(MoneyKind));
			//			// プリンタ管理ワーカークラスをシリアライズ
			//			XmlByteSerializer.Serialize(moneykinds,fileName);

			MoneyKindWork[] MoneyKindWorks = new MoneyKindWork[moneykindList.Count];
			for(int i= 0; i < moneykindList.Count; i++)
			{
				MoneyKindWorks[i] = CopyToMoneyKindWorkFromMoneyKind((MoneyKind)moneykindList[i]);
			}
			//金額種別設定ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(MoneyKindWorks,fileName);

		}

		/// <summary>
		/// 金額種別設定論理削除処理
		/// </summary>
		/// <param name="moneykind">金額種別設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定の論理削除を行います。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int LogicalDelete(ref MoneyKind moneykind)
		{
			try
			{
				MoneyKindWork moneykindWork = CopyToMoneyKindWorkFromMoneyKind(moneykind);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);
				// 論理削除
				int status = this._iMoneyKindDB.LogicalDelete(ref parabyte, GetMoneyKindDataType.UserMoneyKindData);

				if (status == 0)
				{
					// ファイル名を渡してワーククラスをデシリアライズする
					moneykindWork = (MoneyKindWork)XmlByteSerializer.Deserialize( parabyte, typeof(MoneyKindWork));
					// クラス内メンバコピー
					moneykind = CopyToMoneyKindFromMoneyKindWork(moneykindWork);

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.02 TAKAHASHI ADD START
					if(_guidBuff_MoneyKind != null)
					{
						foreach (MoneyKind moneyKindwk in _guidBuff_MoneyKind)
						{
							if (moneyKindwk.PriceStCode == moneykind.PriceStCode)
							{
								if (moneyKindwk.MoneyKindCode == moneykind.MoneyKindCode)
								{
									_guidBuff_MoneyKind.Remove(moneyKindwk);
									break;
								}
							}
						}		
					}
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.02 TAKAHASHI ADD END
					// 2005.12.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if(_Logical_guidBuff_MoneyKind != null)
					{
                        foreach (MoneyKind moneyKindwks in _Logical_guidBuff_MoneyKind)
						{
							if ((moneyKindwks.PriceStCode == moneykind.PriceStCode)&&
								 (moneyKindwks.MoneyKindCode == moneykind.MoneyKindCode))
							{
								_Logical_guidBuff_MoneyKind.Remove(moneyKindwks);
								_Logical_guidBuff_MoneyKind.Add(moneykind);
								break;
							}
						}		
					}
					// 2005.12.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
				}

				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iMoneyKindDB = null;
				//通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 金額種別設定物理削除処理
		/// </summary>
		/// <param name="moneykind">金額種別設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定の物理削除を行います。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int Delete(MoneyKind moneykind)
		{
			try
			{
				MoneyKindWork moneykindWork = CopyToMoneyKindWorkFromMoneyKind(moneykind);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);
				// ユーザー登録分物理削除
				int status = this._iMoneyKindDB.Delete(parabyte, GetMoneyKindDataType.UserMoneyKindData);
				// 2005.12.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				if(status == 0)
				{
					if(_Logical_guidBuff_MoneyKind != null)
					{
                        foreach(MoneyKind moneyKindwk in  _Logical_guidBuff_MoneyKind)
						{
							if((moneyKindwk.PriceStCode == moneykindWork.PriceStCode)&&
								(moneyKindwk.MoneyKindCode == moneykindWork.MoneyKindCode))
							{
								_Logical_guidBuff_MoneyKind.Remove(moneyKindwk);
								break;
							}
						}
					}
				}
				// 2005.12.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
				
				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iMoneyKindDB = null;
				//通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 金額種別設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int GetCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt,enterpriseCode,0);
		}

		/// <summary>
		/// 金額種別設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int GetAllCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt,enterpriseCode,ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// 金額種別設定数検索処理
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:全ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定数の検索を行います。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		private int GetCntProc(out int retTotalCnt,string enterpriseCode,ConstantManagement.LogicalMode logicalMode)
		{
			MoneyKindWork moneykindWork = new MoneyKindWork();
			moneykindWork.EnterpriseCode = enterpriseCode;
			int sumTotalCnt = 0;
			
            //K.HIIRO
			//// XMLへ変換し、文字列のバイナリ化
			//byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);
            //
			////検索
            //
			///* 2005.12.17 enokida DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
			////  提供分を取得
			//int status = this._iMoneyKindDB.SearchCnt(out sumTotalCnt, 
			//										   parabyte, 
			//										   0,                               //検索区分 未使用
			//										   logicalMode,                     //論理削除有無
			//										   GetMoneyKindDataType.OfferMoneyKindData); //取得対象データ
			//if ( status != 0 ){
			//	sumTotalCnt = 0;
			//}
			//2005.12.17 enokida DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end */
            //
			//retTotalCnt = sumTotalCnt;
            //
			////  ユーザ登録分を取得
			//int status =     this._iMoneyKindDB.SearchCnt(out sumTotalCnt, 
			//	parabyte, 
			//	0,                               //検索区分  未使用
			//	logicalMode,                     //論理削除有無
			//	GetMoneyKindDataType.UserMoneyKindData); //取得対象データ
			//if ( status != 0 )
			//{
			//	sumTotalCnt = 0;
			//}
            int status;
            retTotalCnt = sumTotalCnt;
            //  ユーザ登録分を取得
            if (_isLocalDBRead)
            {
                status = this._moneyKindLcDB.SearchCnt(out retTotalCnt,
                    moneykindWork,
                    0,
                    logicalMode,
                    MoneyKindLcDB.GetMoneyKindDataType.UserMoneyKindData);
            }
            else
            {
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);
                status = this._iMoneyKindDB.SearchCnt(out sumTotalCnt,
                    parabyte,
                    0,                               //検索区分  未使用
                    logicalMode,                     //論理削除有無
                    GetMoneyKindDataType.UserMoneyKindData); //取得対象データ
            }
            if (status != 0)
            {
                sumTotalCnt = 0;
            }
            //K.HIIRO

			retTotalCnt += sumTotalCnt;

			return status;
		}


		/// <summary>
		/// 金額種別設定全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定の全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int Search(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int  retTotalCnt;
			return SearchProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,0,null);			
		}

		/// <summary>
		/// 金額種別設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int	 retTotalCnt;
			return SearchProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData01,0,null);
		}

		/// <summary>
		/// 件数指定金額種別設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevMoneyKind">前回最終金額種別設定データオブジェクト（初回はnull指定必須）</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して金額種別設定の検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int SearchSpecification(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,MoneyKind prevMoneyKind)
		{			
			return SearchProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,readCnt,prevMoneyKind);			
		}

		/// <summary>
		/// 件数指定金額種別設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevMoneyKindがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevMoneyKind">前回最終金額種別設定データオブジェクト（初回はnull指定必須）</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して金額種別設定の検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int SearchSpecificationAll(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,MoneyKind prevMoneyKind)
		{			
			return SearchProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData0,readCnt,prevMoneyKind);

			
		}

		/// <summary>
		/// 金額種別設定論理削除復活処理
		/// </summary>
		/// <param name="moneykind">金額種別設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定の復活を行います。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int Revival(ref MoneyKind moneykind)
		{
			try
			{
				MoneyKindWork MoneyKindWork = CopyToMoneyKindWorkFromMoneyKind(moneykind);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(MoneyKindWork);
				// ユーザー登録分復活処理
				int status = this._iMoneyKindDB.RevivalLogicalDelete(ref parabyte, GetMoneyKindDataType.UserMoneyKindData);

				if (status == 0)
				{
					// ファイル名を渡して従業員ワーククラスをデシリアライズする
					MoneyKindWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte, typeof(MoneyKindWork));
					// クラス内メンバコピー
					moneykind = CopyToMoneyKindFromMoneyKindWork(MoneyKindWork);

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.02 TAKAHASHI ADD START
					if(_guidBuff_MoneyKind != null)
					{
						SortedList sortList = new SortedList();
						_guidBuff_MoneyKind.Add(moneykind);

                        foreach (MoneyKind moneyKinds in _guidBuff_MoneyKind)
						{
							string keyOfList = moneyKinds.PriceStCode + "," + moneyKinds.MoneyKindCode;
							sortList.Add(keyOfList, moneyKinds);
						}

						_guidBuff_MoneyKind.Clear();
						_guidBuff_MoneyKind.AddRange(sortList.Values);
					}
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.02 TAKAHASHI ADD END
					// 2005.12.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if(_Logical_guidBuff_MoneyKind != null)
					{
                        foreach (MoneyKind moneyKindwks in _Logical_guidBuff_MoneyKind)
						{
							if ((moneyKindwks.PriceStCode == moneykind.PriceStCode)&&
								(moneyKindwks.MoneyKindCode == moneykind.MoneyKindCode))
							{
								_Logical_guidBuff_MoneyKind.Remove(moneyKindwks);
								_Logical_guidBuff_MoneyKind.Add(moneykind);
								break;
							}
						}		
					}
					// 2005.12.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
				
				}

				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iMoneyKindDB = null;
				//通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 金額種別設定検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
		/// <param name="prevMoneyKind">前回最終金額種別設定データオブジェクト（初回はnull指定必須）</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定の検索処理を行います。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		private int SearchProc(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,ConstantManagement.LogicalMode logicalMode,int readCnt,MoneyKind prevMoneyKind)
		{

			nextData = false;	    // 次データ有無初期化
			retTotalCnt     = 0;    // 0で初期化
			int totalCnt    = 0;
			//            int totalCntUsr = 0;

			//			MoneyKindWork[] mnkindWkAly;
			MoneyKindWork[] mnkindUsrWkAly;

			retList = new ArrayList();
			retList.Clear();

			//抽出条件項目用にクラスを作成し、抽出条件セット
			MoneyKindWork moneykindWork = new MoneyKindWork();
			moneykindWork.EnterpriseCode = enterpriseCode;

            // 2008.12.01 Del >>>
            ////抽出条件設定用クラスをXMLへ変換し、文字列のバイナリ化
            //byte[] parabyte    = XmlByteSerializer.Serialize(moneykindWork);    
            //byte[] parabyteUsr = XmlByteSerializer.Serialize(moneykindWork);
            // 2008.12.01 Del <<<

			//抽出結果受け側用バイナリ
			//            byte[] retbyte;
			byte[] retbyteUsr;
           

			if ( prevMoneyKind != null )
			{
				moneykindWork = CopyToMoneyKindWorkFromMoneyKind(prevMoneyKind);
			}
			moneykindWork.EnterpriseCode = enterpriseCode;

			#region 2005.12.17 enokida DEL
			/* 2005.12.17 enokida DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
						// ---------------- //
						// データ取得
						// ---------------- //
						int status = 0;
						int status_o = 0;
						int status_u = 0;
						if (readCnt == 0){
							//全件読込
							status_u = this._iMoneyKindDB.Search( out retbyteUsr,  parabyteUsr, 0, logicalMode, GetMoneyKindDataType.UserMoneyKindData);
							status_o = this._iMoneyKindDB.Search( out retbyte,     parabyte,    0, logicalMode, GetMoneyKindDataType.OfferMoneyKindData);
						}else{
							status_u = this._iMoneyKindDB.SearchSpecification( out retbyteUsr, out totalCnt,    out nextData, parabyteUsr, 0, logicalMode, readCnt,GetMoneyKindDataType.UserMoneyKindData  );
							status_o = this._iMoneyKindDB.SearchSpecification( out retbyte,    out totalCntUsr, out nextData, parabyte,    0, logicalMode, readCnt,GetMoneyKindDataType.OfferMoneyKindData );
							retTotalCnt = totalCntUsr + totalCnt;
						}

						// ---------------- //
						// XMLの読み込み
						// ---------------- //
						if( ( status_o == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) || 
							( status_o == ( int )ConstantManagement.DB_Status.ctDB_EOF ) ) {
							// ----- 提供データ取得 ----- //
							mnkindWkAly = (MoneyKindWork[])XmlByteSerializer.Deserialize(retbyte,     typeof(MoneyKindWork[]));
							for ( int i = 0; i < mnkindWkAly.Length; i++ )
							{					
								MoneyKindWork wkMoneyKindWork = (MoneyKindWork)mnkindWkAly[i];      // サーチ結果取得
								retList.Add( CopyToMoneyKindFromMoneyKindWork(wkMoneyKindWork));    // 記録簿管理クラスへメンバコピー
							}
						}
						else {
							return status_o;
						}

						if( ( status_u == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) || 
							( status_u == ( int )ConstantManagement.DB_Status.ctDB_EOF ) ) {
							// ----- ユーザーデータ取得 ----- //                
							mnkindUsrWkAly = (MoneyKindWork[])XmlByteSerializer.Deserialize(retbyteUsr, typeof(MoneyKindWork[]));
							for ( int i = 0; i < mnkindUsrWkAly.Length; i++ )
							{
								MoneyKindWork wkMoneyKindWork = (MoneyKindWork)mnkindUsrWkAly[i];   // サーチ結果取得
								retList.Add( CopyToMoneyKindFromMoneyKindWork(wkMoneyKindWork));    // 記録簿管理クラスへメンバコピー
							}
						}
						else {
							return status_u;
						}

						// 全件リードの場合は戻り値の件数をセット
						if ( readCnt == 0 )
						{
							retTotalCnt = retList.Count;
						}
			
						//リスト内部を並び替えする
						IMnyKindComp imnykindcmp = new IMnyKindComp();
						retList.Sort(imnykindcmp);

						// STATUSを設定
						if( ( status_o == ( int )ConstantManagement.DB_Status.ctDB_EOF ) && 
							( status_u == ( int )ConstantManagement.DB_Status.ctDB_EOF ) && 
							( retList.Count == 0 ) ) {
							status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
						}
						else {
							status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
						}

						return status;
			 2005.12.17 enokida DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end */
			#endregion

			// 2005.12.17 enokida ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
			int status = 0;
            //K.HIIRO
            //if (readCnt == 0)
            //{
            //    //全件読込
            //    status = this._iMoneyKindDB.Search( out retbyteUsr,  parabyteUsr, 0, logicalMode, GetMoneyKindDataType.UserMoneyKindData);
            //}
            //else
            //{
            //    status = this._iMoneyKindDB.SearchSpecification(out retbyteUsr, out totalCnt, out nextData, parabyteUsr, 0, logicalMode, readCnt, GetMoneyKindDataType.UserMoneyKindData);
            //    retTotalCnt = totalCnt;
            //}
            //// ---------------- //
            //// XMLの読み込み
            //// ---------------- //
            //if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
            //    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            //{
            //    // ----- ユーザーデータ取得 ----- //                
            //    mnkindUsrWkAly = (MoneyKindWork[])XmlByteSerializer.Deserialize(retbyteUsr, typeof(MoneyKindWork[]));
            //    for ( int i = 0; i < mnkindUsrWkAly.Length; i++ )
            //    {
            //    	MoneyKindWork wkMoneyKindWork = (MoneyKindWork)mnkindUsrWkAly[i];   // サーチ結果取得
            //    	retList.Add( CopyToMoneyKindFromMoneyKindWork(wkMoneyKindWork));    // 記録簿管理クラスへメンバコピー
            //    }
            //}
            //else
            //{
            //    return status;
            //}
            if (_isLocalDBRead)
            {
                List<MoneyKindWork> workList = new List<MoneyKindWork>();
                if (readCnt == 0)
                {
                    //全件読込
                    status = this._moneyKindLcDB.Search(out workList, moneykindWork, 0, logicalMode, MoneyKindLcDB.GetMoneyKindDataType.UserMoneyKindData);
                }
                else
                {
                    status = this._moneyKindLcDB.SearchSpecification(out workList, out totalCnt, out nextData, moneykindWork, 0, logicalMode, readCnt, MoneyKindLcDB.GetMoneyKindDataType.UserMoneyKindData);
                    retTotalCnt = totalCnt;
                }
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    // ----- ユーザーデータ取得 ----- //                
                    for (int i = 0; i < workList.Count; ++i)
                    {
                        retList.Add(CopyToMoneyKindFromMoneyKindWork(workList[i]));    // 記録簿管理クラスへメンバコピー
                    }
                }
                else
                {
                    return status;
                }
            }
            else
            {
                // 2008.12.01 Update >>>
                //if (readCnt == 0)
                //{
                //    //全件読込
                //    status = this._iMoneyKindDB.Search( out retbyteUsr,  parabyteUsr, 0, logicalMode, GetMoneyKindDataType.UserMoneyKindData);
                //}
                //else
                //{
                //    status = this._iMoneyKindDB.SearchSpecification(out retbyteUsr, out totalCnt, out nextData, parabyteUsr, 0, logicalMode, readCnt, GetMoneyKindDataType.UserMoneyKindData);
                //    retTotalCnt = totalCnt;
                //}
                //// ---------------- //
                //// XMLの読み込み
                //// ---------------- //
                //if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                //    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                //{
                //    // ----- ユーザーデータ取得 ----- //                
                //    mnkindUsrWkAly = (MoneyKindWork[])XmlByteSerializer.Deserialize(retbyteUsr, typeof(MoneyKindWork[]));
                //    for ( int i = 0; i < mnkindUsrWkAly.Length; i++ )
                //    {
                //        MoneyKindWork wkMoneyKindWork = (MoneyKindWork)mnkindUsrWkAly[i];   // サーチ結果取得
                //        retList.Add( CopyToMoneyKindFromMoneyKindWork(wkMoneyKindWork));    // 記録簿管理クラスへメンバコピー
                //    }
                //}
                //else
                //{
                //    return status;
                //}
                if (readCnt == 0)
                {
                    object retObj;
                    object paraObj = moneykindWork;			//抽出条件設定用クラスをXMLへ変換し、文字列のバイナリ化

                    //全件読込
                    status = this._iMoneyKindDB.Search(out retObj, paraObj, 0, logicalMode, GetMoneyKindDataType.UserMoneyKindData);

                    if (( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ) ||
                        ( status == (int)ConstantManagement.DB_Status.ctDB_EOF ))
                    {

                        foreach (MoneyKindWork wkMoneyKindWork in (ArrayList)retObj)
                        {
                            retList.Add(CopyToMoneyKindFromMoneyKindWork(wkMoneyKindWork));    // 記録簿管理クラスへメンバコピー
                        }
                    }
                    else
                    {
                        return status;
                    }
                }
                else
                {
                    //抽出条件設定用クラスをXMLへ変換し、文字列のバイナリ化
                    byte[] parabyte    = XmlByteSerializer.Serialize(moneykindWork);    
                    byte[] parabyteUsr = XmlByteSerializer.Serialize(moneykindWork);
                    status = this._iMoneyKindDB.SearchSpecification(out retbyteUsr, out totalCnt, out nextData, parabyteUsr, 0, logicalMode, readCnt, GetMoneyKindDataType.UserMoneyKindData);
                    retTotalCnt = totalCnt;

                    // ---------------- //
                    // XMLの読み込み
                    // ---------------- //
                    if (( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ) ||
                        ( status == (int)ConstantManagement.DB_Status.ctDB_EOF ))
                    {
                        // ----- ユーザーデータ取得 ----- //                
                        mnkindUsrWkAly = (MoneyKindWork[])XmlByteSerializer.Deserialize(retbyteUsr, typeof(MoneyKindWork[]));
                        for (int i = 0; i < mnkindUsrWkAly.Length; i++)
                        {
                            MoneyKindWork wkMoneyKindWork = (MoneyKindWork)mnkindUsrWkAly[i];   // サーチ結果取得
                            retList.Add(CopyToMoneyKindFromMoneyKindWork(wkMoneyKindWork));    // 記録簿管理クラスへメンバコピー
                        }
                    }
                    else
                    {
                        return status;
                    }
                }
                // 2008.12.01 Update <<<
            }
            //K.HIIRO

			// 全件リードの場合は戻り値の件数をセット
			if ( readCnt == 0 )
			{
				retTotalCnt = retList.Count;
			}
			
			//リスト内部を並び替えする
			IMnyKindComp imnykindcmp = new IMnyKindComp();
			retList.Sort(imnykindcmp);

			// STATUSを設定
			if( ( status == ( int )ConstantManagement.DB_Status.ctDB_EOF ) && 
				( retList.Count == 0 ) ) 
			{
				status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
			}
			else 
			{
				status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
			}

			return status;
			// 2005.12.17 enokida ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
		}

        
		/// <summary>
		/// 金額種別クラス並び替え用クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 金額設定区分→金種区分→金種コード順に並び替えるクラス。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public class IMnyKindComp : IComparer  
		{
			int IComparer.Compare( Object x, Object y )  
			{

				int retst = 0;
                MoneyKind mnkindX = (MoneyKind)x;
                MoneyKind mnkindY = (MoneyKind)y;

				//金額設定区分を比較
				retst = mnkindX.PriceStCode - mnkindY.PriceStCode;  
				if(retst == 0)
				{
					//金種区分を比較
					retst = mnkindX.MoneyKindDiv - mnkindY.MoneyKindDiv;
					if(retst == 0)
					{
						//金種コードを比較               
						retst = mnkindX.MoneyKindCode - mnkindY.MoneyKindCode;
					} 

				}

				return retst;
			}
		}


		/// <summary>
		/// 金額種別設定検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定の検索処理を行い、取得結果をDataSetで返します。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int SearchDS(ref DataSet ds,string enterpriseCode)
		{
			MoneyKindWork moneykindWork = new MoneyKindWork();
			moneykindWork.EnterpriseCode = enterpriseCode;

            //K.HIIRO
			//// XMLへ変換し、文字列のバイナリ化
			//byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);
            //
			//byte[] retbyte;
            //
			//// 金額種別サーチ
			//int status = this._iMoneyKindDB.Search(out retbyte, parabyte, 0, 0, GetMoneyKindDataType.UserMoneyKindData);
            //
			//if ( status == 0 )
			//{
			//	XmlByteSerializer.ReadXml(ref ds, retbyte);
			//}
            int status;
            if (_isLocalDBRead)
            {
                List<MoneyKindWork> workList = new List<MoneyKindWork>();
                status = this._moneyKindLcDB.Search(out workList, moneykindWork, 0, 0, MoneyKindLcDB.GetMoneyKindDataType.UserMoneyKindData);
                if (status == 0)
                {
                    byte[] retbyte = XmlByteSerializer.Serialize(workList);
                    XmlByteSerializer.ReadXml(ref ds, retbyte);
                }
            }
            else
            {
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);
                byte[] retbyte;
                // 金額種別サーチ
                status = this._iMoneyKindDB.Search(out retbyte, parabyte, 0, 0, GetMoneyKindDataType.UserMoneyKindData);
                if (status == 0)
                {
                    XmlByteSerializer.ReadXml(ref ds, retbyte);
                }
            }
            //K.HIIRO
				
			return status;
		}

        /// <summary>
        /// 金額種別設定ローカルデータ検索処理（DataSet(ガイド)用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 金額種別設定の検索処理を行い、取得結果をDataSetで返します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.04.04</br>
        /// </remarks>
        public int SearchLocalDB(string enterpriseCode, int priceStCode, ref DataSet ds)
        {
            MoneyKindWork moneykindWork = new MoneyKindWork();
            moneykindWork.EnterpriseCode = enterpriseCode;

            MoneyKind moneyKind = new MoneyKind();

            List<MoneyKindWork> moneyKindWorkList = new List<MoneyKindWork>();
            ArrayList ar = new ArrayList();

            // 金額種別サーチ
            int status = this._moneyKindLcDB.Search(out moneyKindWorkList, moneykindWork, 0, 0, Broadleaf.Application.LocalAccess.MoneyKindLcDB.GetMoneyKindDataType.UserMoneyKindData);
            if (status == 0)
            {
                foreach (MoneyKindWork retMoneyKindWork in moneyKindWorkList)
                {
                    if ((retMoneyKindWork.PriceStCode == priceStCode) && (retMoneyKindWork.LogicalDeleteCode == 0))
                    {
                        moneyKind = CopyToMoneyKindFromMoneyKindWork(retMoneyKindWork);
                        // サーチ結果取得
                        ar.Add(moneyKind.Clone());
                    }
                }
            }

            ArrayList wkList = ar.Clone() as ArrayList;
            SortedList wkSort = new SortedList();

            // --- [全て] --- //
            // そのまま全件返す
            foreach (MoneyKind wkMoneyKind in wkList)
            {
                if (wkMoneyKind.LogicalDeleteCode == 0)
                {
                    wkSort.Add(wkMoneyKind.MoneyKindCode, wkMoneyKind);
                }
            }

            MoneyKind[] moneyKinds = new MoneyKind[wkSort.Count];

            // データを元に戻す
            for (int i = 0; i < wkSort.Count; i++)
            {
                moneyKinds[i] = (MoneyKind)wkSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(moneyKinds);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

		/// <summary>
		/// クラスメンバーコピー処理（金額種別設定ワーククラス⇒金額種別設定クラス）
		/// </summary>
		/// <returns>金額種別設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定ワーククラスから金額種別設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		private MoneyKind CopyToMoneyKindFromMoneyKindWork(MoneyKindWork moneyKindWorkBuf)

			// <param name="MoneyKindWork">金額種別設定ワーククラス</param>
		{
			MoneyKind moneykind = new MoneyKind();

			//ファイルヘッダ部分
			moneykind.CreateDateTime    = moneyKindWorkBuf.CreateDateTime;
			moneykind.UpdateDateTime    = moneyKindWorkBuf.UpdateDateTime;
			moneykind.EnterpriseCode    = moneyKindWorkBuf.EnterpriseCode.TrimEnd();
			moneykind.FileHeaderGuid    = moneyKindWorkBuf.FileHeaderGuid;
			moneykind.UpdEmployeeCode   = moneyKindWorkBuf.UpdEmployeeCode.TrimEnd();
			moneykind.UpdAssemblyId1    = moneyKindWorkBuf.UpdAssemblyId1.TrimEnd();
			moneykind.UpdAssemblyId2    = moneyKindWorkBuf.UpdAssemblyId2.TrimEnd();
			moneykind.LogicalDeleteCode = moneyKindWorkBuf.LogicalDeleteCode;

			moneykind.PriceStCode       = moneyKindWorkBuf.PriceStCode;
			moneykind.MoneyKindCode     = moneyKindWorkBuf.MoneyKindCode;
			moneykind.MoneyKindName     = moneyKindWorkBuf.MoneyKindName.TrimEnd();
			moneykind.MoneyKindDiv      = moneyKindWorkBuf.MoneyKindDiv;

            // 2007.05.17  S.Koga  Add ----------------------------------------
            //moneykind.RegiMgCd          = moneyKindWorkBuf.RegiMgCd;  // DEL 2008/06/12
            // ----------------------------------------------------------------

			return moneykind;
		}

		/// <summary>
		/// クラスメンバーコピー処理（金額種別設定クラス⇒金額種別設定ワーククラス）
		/// </summary>
		/// <param name="moneykind">金額種別設定ワーククラス</param>
		/// <returns>金額種別設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 金額種別設定クラスから金額種別設定ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		private MoneyKindWork CopyToMoneyKindWorkFromMoneyKind(MoneyKind moneykind)
		{

			MoneyKindWork moneyKindWorkBuf = new MoneyKindWork();

			moneyKindWorkBuf.CreateDateTime		= moneykind.CreateDateTime;
			moneyKindWorkBuf.UpdateDateTime		= moneykind.UpdateDateTime;
			moneyKindWorkBuf.EnterpriseCode		= moneykind.EnterpriseCode;
			moneyKindWorkBuf.FileHeaderGuid		= moneykind.FileHeaderGuid;
			moneyKindWorkBuf.UpdEmployeeCode	= moneykind.UpdEmployeeCode;
			moneyKindWorkBuf.UpdAssemblyId1		= moneykind.UpdAssemblyId1;
			moneyKindWorkBuf.UpdAssemblyId2		= moneykind.UpdAssemblyId2;
			moneyKindWorkBuf.LogicalDeleteCode	= moneykind.LogicalDeleteCode;

			moneyKindWorkBuf.PriceStCode        = moneykind.PriceStCode;
			moneyKindWorkBuf.MoneyKindCode      = moneykind.MoneyKindCode;
			moneyKindWorkBuf.MoneyKindName      = moneykind.MoneyKindName;
			moneyKindWorkBuf.MoneyKindDiv       = moneykind.MoneyKindDiv;

            // 2007.05.17  S.Koga  add ----------------------------------------
            //moneyKindWorkBuf.RegiMgCd           = moneykind.RegiMgCd;  // DEL 2008/06/12
            // ----------------------------------------------------------------

			return moneyKindWorkBuf;
		}

        /// <summary>
        /// マスタガイド起動処理(通常(ローカル))
        /// </summary>
        /// <param name="itemsDisp">取得データ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="guideMode">ガイド起動モード</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note       : マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.05.07</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, int priceStCode, out MoneyKind moneyKind, string guideXmlParentFile)
        {
            if (_isLocalDBRead)
            {
                // ローカル
                return this.ExecuteGuid(enterpriseCode, priceStCode, out moneyKind, guideXmlParentFile, 0);
            }
            else
            {
                // リモート
                return this.ExecuteGuid(enterpriseCode, priceStCode, out moneyKind, guideXmlParentFile, 1);
            }
        }

		// マスメンチーム作成ガイド 2005.06.08 Misaki Del
		/// <summary>
		/// 金額種別ガイド起動処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="moneyKind">取得データ</param>
		/// <param name="priceStCode">取得データ</param>
		/// <param name="guideXmlParentFile">取得データ</param>
		/// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
		/// <remarks>
		/// <br>Note		: 金額種別設定マスタの一覧表示機能を持つガイドを起動します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2005.05.20</br>
		/// <br>UpdateNote : 2005.09.13 金額設定区分毎にデータを取得できるように変更</br>
		/// <br>           : 23011 野口 暢朗</br>
		/// </remarks>
        // ----- iitani c ---------- start 2007.05.07
        //public int ExecuteGuid(string enterpriseCode, int priceStCode, out MoneyKind moneyKind, string guideXmlParentFile)
        public int ExecuteGuid(string enterpriseCode, int priceStCode, out MoneyKind moneyKind, string guideXmlParentFile, int searchMode)
        // ----- iitani c ---------- end 2007.05.07
        {
			int status = -1;
            moneyKind = new MoneyKind();
            
            // ----- iitani a ---------- start  2007.05.20
            if (guideXmlParentFile == "")
            {
                // デフォルト設定
                guideXmlParentFile = "MONEYKINDGUIDEPARENT.XML";
            }
            // ----- iitani a ---------- end  2007.05.20

			TableGuideParent tableGuideParent = new TableGuideParent(guideXmlParentFile);
			// 条件設定用のハッシュテーブル
			Hashtable inObj = new Hashtable();
			// ガイドで選択されたデータをセットするハッシュテーブル
			Hashtable retObj = new Hashtable();

			// 企業コード
			inObj.Add("EnterpriseCode", enterpriseCode);
			inObj.Add("PriceStCode", priceStCode );
            inObj.Add(GUIDE_SEARCHMODE_PARA, searchMode);  // ガイドデータサーチモード(0:ローカル,1:リモート) iitani a 2007.05.07
			
			if (tableGuideParent.Execute(0, inObj, ref retObj))
			{
				Object retMoneyKind = (Object)moneyKind;
				// 取得したデータをクラスにセット
				TableGuideParent.HashTableToClassProperty(retObj, ref retMoneyKind);
				moneyKind = (MoneyKind)retMoneyKind;
                status = 0;
			}
			else
			{
				status = 1;
			}
			return status;
		}
		
		/// <summary>
		/// 検索処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="ds">データセット</param>
		/// <param name="priceStCode">金額設定区分</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ガイド用データバッファが空ならリモートからデータを取得する</br>
		/// <br>Programmer : 99032 伊藤 美紀</br>
		/// <br>Date       : 2005.06.13</br>
		/// <br>UpdateNote : 2005.09.13 金額設定区分毎にデータを取得できるように変更</br>
		/// <br>           : 23011 野口 暢朗</br>
		/// </remarks>
		private int SearchDS(string enterpriseCode, int priceStCode, ref DataSet ds)
		{
			int status = 0;
			SortedList sortList = new SortedList();
			
			// バッファが空ならデータを取得
			if((_guidBuff_MoneyKind == null)||(_guidBuff_MoneyKind.Count == 0))
			{
				status = Search(out _guidBuff_MoneyKind,enterpriseCode);
				/*
								// 2005.12.16 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
								//ソート
								foreach (MoneyKind moneyKind in _guidBuff_MoneyKind)
								{
									string keyOfList = moneyKind.PriceStCode + "," + moneyKind.MoneyKindCode;
									sortList.Add(keyOfList, moneyKind);
								}

								_guidBuff_MoneyKind.Clear();
								_guidBuff_MoneyKind.AddRange(sortList.Values);
								// 2005.12.16 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
				*/
				if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					return status;
			}
			
			MoneyKind[] moneyKinds = null;
			
			ArrayList alTmp = new ArrayList();
			
			sortList.Clear();
			//対象の区分だった場合のみ結果に追加
            foreach(MoneyKind moneyKind in _guidBuff_MoneyKind)
			{
				if(( moneyKind.PriceStCode == priceStCode )&&(moneyKind.LogicalDeleteCode == 0))
				{
					alTmp.Add( moneyKind );
				}
			}
			
			// 2005.12.16 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            foreach(MoneyKind moneyKindsort in alTmp)
            {
				sortList.Add(moneyKindsort.MoneyKindCode, moneyKindsort);
			}

			alTmp.Clear();
			alTmp.AddRange(sortList.Values);
			// 2005.12.16 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            moneyKinds = (MoneyKind[])alTmp.ToArray(typeof(MoneyKind));
			byte[] retByte = XmlByteSerializer.Serialize(moneyKinds);
			XmlByteSerializer.ReadXml(ref ds,retByte);
			
			return status;
		}
		
		#region IGeneralGuidData Method
		/// <summary>
		/// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
		/// </summary>
		/// <param name="mode"></param>
		/// <param name="inParm"></param>
		/// <param name="guideList"></param>
		/// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
		/// <remarks>
		/// <br>Note		: 汎用ガイド設定用データを取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2005.05.20</br>
		/// <br>UpdateNote : 2005.09.13 金額設定区分毎にデータを取得できるように変更</br>
		/// <br>           : 23011 野口 暢朗</br>
		/// </remarks>
		public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
		{
			int status   = -1;
			string enterpriseCode = "";
			int priceStCode = 0;
			
			// 企業コード設定有り
			if ( inParm.ContainsKey("EnterpriseCode") && inParm.ContainsKey("PriceStCode") )
			{
				enterpriseCode = inParm["EnterpriseCode"].ToString();
				priceStCode = (int)inParm["PriceStCode"];
			}
				// 企業コード、金額設定区分の指定無し
			else 
			{
				return status;
			}

            // 金額種別設定テーブル読込み（DataSet用）ローカルDBに変更 iitani c 
            //status = SearchDS(enterpriseCode, priceStCode, ref guideList);
            // ----- iitani c ---------- start 2007.05.07
            //status = SearchLocalDB(enterpriseCode, priceStCode, ref guideList);
            int searchMode = 0;
            if (inParm.ContainsKey(GUIDE_SEARCHMODE_PARA))
            {
                searchMode = int.Parse(inParm[GUIDE_SEARCHMODE_PARA].ToString());
            }

            if (searchMode == 1)
            {
                status = SearchDS(enterpriseCode, priceStCode, ref guideList);
            }
            else
            {
                status = SearchLocalDB(enterpriseCode, priceStCode, ref guideList);
            }
            // ----- iitani c ---------- end 2007.05.07

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
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
		#endregion
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Del
	
	
		/// <summary>
		/// キャッシュ取得処理
		/// </summary>
		/// <param name="retList">データバッファ</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="mode">0:論理削除を除く,1:論理削除を含む</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : データバッファを取得します</br>
		/// <br>Programmer : 22021 谷藤　範幸</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public int GetBuff(out ArrayList retList, string enterpriseCode, int mode)
		{
			int status = 0;
		
			// ガイド用バッファにデータが無ければリモートより取得する
			if((_guidBuff_MoneyKind == null)||(_guidBuff_MoneyKind.Count == 0))
			{
				if(_guidBuff_MoneyKind == null){_guidBuff_MoneyKind = new ArrayList();}
				_guidBuff_MoneyKind.Clear();
	
				if(_Logical_guidBuff_MoneyKind == null){_Logical_guidBuff_MoneyKind = new ArrayList();}
				_Logical_guidBuff_MoneyKind.Clear();
				ArrayList insMoneyKindAll = new ArrayList();
				status = SearchAll(out insMoneyKindAll, enterpriseCode);

				foreach(MoneyKind MoneyKinds in insMoneyKindAll)
                {
                    if (MoneyKinds.LogicalDeleteCode == 0)
                    {
                        _guidBuff_MoneyKind.Add(MoneyKinds);
                    }
                    _Logical_guidBuff_MoneyKind.Add(MoneyKinds);
                }
            }
			if(mode == 0)
			{
				retList = _guidBuff_MoneyKind;
			}
			else
			{
				retList = _Logical_guidBuff_MoneyKind;
			}
				return status;
		}
	
	}
}
