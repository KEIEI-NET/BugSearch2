// 2006.09.11 ueo ユーザーガイド情報をメモリ情報があればメモリから取得するように変更
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.LocalAccess;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 取得対象データ定数
	/// </summary>
	/// <br>Note		: ユーザーガイドマスタ（ボディ）の取得対象データの列挙型です。</br>
	/// <br>Programmer	: 21027　須川  程志郎</br>
	/// <br>Date		: 2005.04.18</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: Read、ガイドのSearch の処理をローカルDBからの読込に変更</br>
    /// <br>Programmer	: 980023　飯谷 耕平</br>
    /// <br>Date		: 2007.05.22</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ローカルDBをやめて、サーバー読み込みに変更</br>
    /// <br>Programmer	: 20081　疋田 勇人</br>
    /// <br>Date		: 2008.06.16</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: 参照設定再設定</br>
    /// <br>Programmer	: 20056　對馬 大輔</br>
    /// <br>Date		: 2008.07.11</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: 提供はローカルを読みに変更</br>
    /// <br>Programmer	: 20081　疋田 勇人</br>
    /// <br>Date		: 2008.09.05</br>
    /// -----------------------------------------------------------------------------------

    public enum UserGuideAcsData
	{
		/// <summary>
		/// ボディデータ(ユーザー変更分)
		/// </summary>
		UserBodyData,
		/// <summary>
		/// ボディデータ(提供分)
		/// </summary>
		OfferBodyData,
		/// <summary>
		/// ボディデータ(マージ分)
		/// </summary>
		MergeBodyData,
		/// <summary>
		/// ボディデータ(提供区分マージ[ヘッダの提供区分に忠実に従ったマージ])
		/// </summary>
		OfferDivCodeMergeBodyData,
	}

	/// <summary>
	/// ユーザーガイドテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: ユーザーガイドテーブルのアクセス制御を行います。</br>
	/// <br>Programmer	: 21027 須川  程志郎</br>
	/// <br>Date		: 2005.04.18</br>
	/// <br>UpDate Note	: 2006.10.12 22033 三崎  貴史</br>
	/// <br>			: ・GetGuideNameメソッドにて、取得対象のユーザーガイド区分のデータが一件も無い場合、</br>
	/// <br>			:   その区分では毎回リモートが走ってしまう問題を修正</br>
	/// <br>			:   （staticキャッシュの有無の判断を全て区分毎のフラグを使用する様に変更）</br>
	/// </remarks>
    public class UserGuideAcs : IGeneralGuideData
	{
		#region Private Members
		/// <summary>リモートオブジェクト格納バッファ</summary>
        // 2008.06.16 upd start -------------------------------->>
        // ----- iitani c ---------- start 2007.05.22
		//private IUserGdBdDB  _iUserGdBdDB  = null;
        private UserGdBdLcDB _userGdBdLcDB = null;
        private UserGdBdULcDB _userGdBdULcDB = null;
        // ----- iitani c ---------- end 2007.05.22
        private IUserGdBdDB _iUserGdBdDB = null;
        // 2008.06.16 upd end ----------------------------------<<
		private IUserGdBdUDB _iUserGdBdUDB = null;

		/// <summary>ユーザーガイド（ボディ）クラスStatic</summary>
		private static Hashtable _userGdBdTable_Stc = null;
		private static ArrayList _userGdHdList = null;

		/// <summary>ユーザーガイドクラスStatic(エントリで使用するメモリ)</summary>
		private static ArrayList _userGdHdEntryList = null;
		private static Hashtable _userGdBdEntryTable = null;

///////////////////////////////////////////////////////////////////// 2005.12.03 AKIYAMA ADD STA //
		// ガイド・名称取得用キャッシュ
		private static Hashtable _guideBufUserGdBd = null;
// 2005.12.03 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
		/// <summary>static情報取得フラグ管理ArrayList</summary>
		private static ArrayList _staticReadMngList = null;
		#endregion

		#region Constructor
		/// <summary>
		/// ユーザーガイドテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : ユーザーガイドテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public UserGuideAcs()
		{
			UserGuideInitProc();
		}

		/// <summary>
		/// ユーザーガイドテーブルアクセスクラスコンストラクタ（メモリ貯蓄版）
		/// </summary>
		/// <param name="userGdHdEntry">ユーザーガイドヘッダ</param>
		/// <param name="userGdBdEntry">ユーザーガイドボディ</param>
		public UserGuideAcs(UserGdHd[] userGdHdEntry, UserGdBd[] userGdBdEntry)
		{
			UserGuideInitProc();
			
			_userGdHdEntryList = new ArrayList();
			_userGdBdEntryTable = new Hashtable();

			// ユーザーガイドヘッダ格納
			if( userGdHdEntry != null )
			{
				foreach( UserGdHd ugh in userGdHdEntry )
					_userGdHdEntryList.Add( ugh );
			}

			if( userGdBdEntry != null )
			{
				// ユーザーガイドボディ格納
				foreach( UserGdBd ugb in userGdBdEntry )
				{
					string key = ugb.UserGuideDivCd.ToString() + "_" + ugb.GuideCode.ToString();
					_userGdBdEntryTable.Add( key, ugb );
				}
			}
		}

		private void UserGuideInitProc()
		{
			// ユーザーガイド（ボディ）
			if( _userGdBdTable_Stc == null )
			{
				_userGdBdTable_Stc = new Hashtable();
			}
			if( _userGdHdList == null )
			{
				_userGdHdList = new ArrayList();
			}
			if (_staticReadMngList == null)
			{
				_staticReadMngList = new ArrayList();
			}

			// ログイン部品で通信状態を確認
            // -- UPD 2010/05/25 ---------------------->>>
            //if( LoginInfoAcquisition.OnlineFlag )
            //{
            //    try
            //    {
            //        // リモートオブジェクト取得
            //        this._iUserGdBdDB = (IUserGdBdDB)MediationUserGdBdDB.GetUserGdBdDB();  // iitani d 2007.05.22 // 2008.06.16 upd
            //        this._iUserGdBdUDB = (IUserGdBdUDB)MediationUserGdBdUDB.GetUserGdBdUDB();
            //    }
            //    catch( Exception )
            //    {
            //        //オフライン時はnullをセット
            //        //this._iUserGdBdDB = null;  // iitani d 2007.05.22
            //        this._iUserGdBdUDB = null;
            //    }
            //}
            //else
            //{
            //    // オフライン時のデータ読み込み
            //    this.SearchOfflineData();
            //}

            try
            {
                // リモートオブジェクト取得
                this._iUserGdBdDB = (IUserGdBdDB)MediationUserGdBdDB.GetUserGdBdDB();  // iitani d 2007.05.22 // 2008.06.16 upd
                this._iUserGdBdUDB = (IUserGdBdUDB)MediationUserGdBdUDB.GetUserGdBdUDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUserGdBdUDB = null;
            }
            // -- UPD 2010/05/25 ----------------------<<<

            
            // ----- iitani a ---------- start 2007.05.22
            // ローカルDBアクセスオブジェクト取得 
            // ヘッダ
            if (this._userGdBdLcDB == null)
            {
                this._userGdBdLcDB = new UserGdBdLcDB();
            }

            // ボディ
            if (this._userGdBdULcDB == null)
            {
                this._userGdBdULcDB = new UserGdBdULcDB();
            }
            // ----- iitani a ---------- end 2007.05.22
            
        }
		#endregion

		#region Public Methods
		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int GetOnlineMode()
		{
            // ----- iitani c ---------- start 2007.05.22
			//if ((this._iUserGdBdDB == null) || (this._iUserGdBdUDB == null))
			if (this._iUserGdBdUDB == null)
            // ----- iitani c ---------- start 2007.05.22
            {
				return (int)ConstantManagement.OnlineMode.Offline;
			}
			else
			{
				return (int)ConstantManagement.OnlineMode.Online;
			}
		}

		/// <summary>
		/// ユーザーガイド（ボディ）Staticメモリ全件取得処理
		/// </summary>
		/// <param name="retList">ユーザーガイド（ボディ）List</param>
		/// <returns>ステータス(0:正常終了, -1:エラー, 9:データ無し)</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）Staticメモリの全件を取得します。</br>
		/// <br>Programer  : 22033  三崎  貴史</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		public int SearchStaticMemory(out ArrayList retList)
		{
			retList = new ArrayList();
			retList.Clear();

			if (_userGdBdTable_Stc == null)
			{
				return -1;
			}
			else if (_userGdBdTable_Stc.Count == 0)
			{
				return 9;
			}

			retList.AddRange(_userGdBdTable_Stc.Values);

			return 0;
		}

		/// <summary>
		/// ユーザーガイド（ボディ）Staticメモリ取得処理
		/// </summary>
		/// <param name="retList">ユーザーガイド（ボディ）List</param>
		/// <param name="userGuideDivCd">ユーザーガイド区分コード</param>
		/// <returns>ステータス(0:正常終了, -1:エラー, 9:データ無し)</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）Staticメモリを区分を指定して取得します。</br>
		/// <br>Programer  : 22033  三崎  貴史</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		public int SearchDivCodeStaticMemory(out ArrayList retList, int userGuideDivCd)
		{
			retList = new ArrayList();
			retList.Clear();

			if (_userGdBdTable_Stc == null)
			{
				return -1;
			}
			else if (_userGdBdTable_Stc.Count == 0)
			{
				return 9;
			}
			else
			{
				SortedList sortedList = new SortedList();
				foreach (UserGdBd wkUserGdBd in _userGdBdTable_Stc.Values)
				{
					if (wkUserGdBd.UserGuideDivCd == userGuideDivCd)
					{
						sortedList.Add(wkUserGdBd.GuideCode, wkUserGdBd);
					}
				}

				retList.AddRange(sortedList.Values);
			}

			return 0;
		}

		/// <summary>
		/// ユーザーガイド（ボディ）取得処理
		/// </summary>
		/// <param name="userGdBd">ユーザーガイド（ボディ）クラス</param>
		/// <param name="userGuideDivCd">ユーザーガイド区分コード</param>
		/// <param name="guideCode">ユーザーガイドコード</param>
		/// <returns>ステータス(0:正常終了, -1:エラー, 4:データ無し)</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）メモリを検索します。</br>
		/// <br>Programer  : 22033  三崎  貴史</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		public int ReadStaticMemory(out UserGdBd userGdBd, int userGuideDivCd, int guideCode)
		{
			userGdBd = new UserGdBd();

			if (_userGdBdTable_Stc == null)
			{
				return -1;
			}

			// Staticから検索
			//if (_userGdBdTable_Stc[userGuideDivCd.ToString() + "_" + guideCode.ToString().PadLeft(4, '0')] == null)
            if (_userGdBdTable_Stc[userGuideDivCd.ToString() + "_" + guideCode.ToString()] == null)
			{
				return 4;
			}
			else
			{
                userGdBd = (UserGdBd)_userGdBdTable_Stc[userGuideDivCd.ToString() + "_" + guideCode.ToString()];
                //userGdBd = (UserGdBd)_userGdBdTable_Stc[userGuideDivCd.ToString() + "_" + guideCode.ToString().PadLeft(4, '0')];
			}
			
			return 0;
		}

		/// <summary>
		/// ユーザーガイドStaticメモリ情報オフライン書き込み処理
		/// </summary>
		/// <param name="sender">object（呼出元オブジェクト）</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイドStaticメモリの情報をローカルファイルに保存します。</br>
		/// <br>Programer  : 22033  三崎  貴史</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		public int WriteOfflineData(object sender)
		{
			// オフラインシリアライズデータ作成部品I/O
			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
			int status = 9;

			if (_userGdBdTable_Stc.Count != 0)
			{
				// KeyList設定
				string[] userGdBdKeys = new string[1];
				userGdBdKeys[0] = LoginInfoAcquisition.EnterpriseCode;

				ArrayList userGdBdUWorkList = new ArrayList();
				foreach (UserGdBd userGdBd in _userGdBdTable_Stc.Values)
				{
					// クラス ⇒ ワーカークラス
					userGdBdUWorkList.Add(CopyToUserGdBdUWorkFromUserGdBd(userGdBd));
				}
				
				status = offlineDataSerializer.Serialize("UserGuideAcs", userGdBdKeys, userGdBdUWorkList);
			}

			return status;
		}

		/// <summary>
		/// KEY指定ユーザーガイド（ボディ）情報読み込み処理
		/// </summary>
		/// <param name="userGdBd">ユーザーガイド（ボディ）クラス</param>
		/// <param name="enterpriseCode">企業コード（ユーザーの場合のみ）</param>
		/// <param name="guideDivCode">ガイド区分</param>
		/// <param name="guideCode">ガイドコード</param>
		/// <param name="acsDataType">取得対象データ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）情報を読み込みます。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int ReadBody(out UserGdBd userGdBd, string enterpriseCode, int guideDivCode, int guideCode, ref UserGuideAcsData acsDataType)
		{
			try
			{
				userGdBd = null;
				int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

				// オンライン時はリモート取得
                // -- DEL 2010/05/25 --------------------->>>
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                // -- DEL 2010/05/25 ---------------------<<<
                    switch (acsDataType)
					{
						case UserGuideAcsData.OfferBodyData :
						{
							// 提供分を読み込み
							status = ReadBodyProc(out userGdBd, enterpriseCode, guideDivCode, guideCode, UserGuideAcsData.OfferBodyData);
							break;
						}
						case UserGuideAcsData.UserBodyData :
						{
							// ユーザー変更分を読み込み
							status = ReadBodyProc(out userGdBd, enterpriseCode, guideDivCode, guideCode, UserGuideAcsData.UserBodyData);
							break;
						}
						case UserGuideAcsData.MergeBodyData :
						{
							// ユーザー変更分を読み込み
							status = ReadBodyProc(out userGdBd, enterpriseCode, guideDivCode, guideCode, UserGuideAcsData.UserBodyData);
							switch (status)
							{
								case (int)ConstantManagement.DB_Status.ctDB_NORMAL :
								{
									acsDataType = UserGuideAcsData.UserBodyData;
									break;
								}
								case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND :
								{
									// 提供分を読み込み
									status = ReadBodyProc(out userGdBd, enterpriseCode, guideDivCode, guideCode, UserGuideAcsData.OfferBodyData);
									switch (status)
									{
										case (int)ConstantManagement.DB_Status.ctDB_NORMAL :
										{
											acsDataType = UserGuideAcsData.OfferBodyData;
											break;
										}
										case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND :
										{
											break;
										}
										default :
										{
											break;
										}
									}
									break;
								}
								default :
								{
									break;
								}
							}
							break;
						}
						default :
						{
							break;
						}
					}

                // -- DEL 2010/05/25 --------------------->>>
                //}
                //else	// オフライン時はキャッシュから取得
                //{
                //    status = ReadStaticMemory(out userGdBd, guideDivCode, guideCode);
                //}
                // -- DEL 2010/05/25 ---------------------<<<

				return status;   
			}
			catch (Exception)
			{				
				//通信エラーは-1を戻す
				userGdBd = null;
				//オフライン時はnullをセット
				//this._iUserGdBdDB  = null;  // iitani d 2007.05.22
				this._iUserGdBdUDB = null;
				return -1;
			}
		}

		/// <summary>
		/// ユーザーガイド（ボディ）（ユーザー）登録・更新処理
		/// </summary>
		/// <param name="userGdBd">ユーザーガイド（ボディ）クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）の登録・更新を行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int Write(ref UserGdBd userGdBd)
		{
			// ユーザーガイド（ボディ）クラスからユーザーガイド（ボディ）（ユーザー）ワーカークラスにメンバコピー
			UserGdBdUWork userGdBdUWork = CopyToUserGdBdUWorkFromUserGdBd(userGdBd);

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(userGdBdUWork);

			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// ユーザーガイド（ボディ）書き込み
				status = this._iUserGdBdUDB.Write(ref parabyte);
				
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// ファイル名を渡してユーザーガイド（ボディ）ワーククラスをデシリアライズする
					userGdBdUWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte, typeof(UserGdBdUWork));
					// クラス内メンバコピー
					userGdBd = CopyToUserGdBdFromUserGdBdUWork(userGdBdUWork);
///////////////////////////////////////////////////////////////////// 2005.12.02 AKIYAMA ADD STA //
					// ガイド用キャッシュを更新
					if (ReadCheck(userGdBdUWork.UserGuideDivCd))
					{
						// ハッシュテーブル取得
						Hashtable wkUserGdBdTable = ( Hashtable )_guideBufUserGdBd[ userGdBd.UserGuideDivCd ];

						// 既に登録済みの場合は一度削除
						if( wkUserGdBdTable.ContainsKey( userGdBd.GuideCode ) == true ) {
							wkUserGdBdTable.Remove( userGdBd.GuideCode );
						}

						// 登録
						wkUserGdBdTable.Add( userGdBd.GuideCode, userGdBd.Clone() );
					}
// 2005.12.02 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
				}
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				//this._iUserGdBdDB = null;  // iitani d 2007.05.22
				// 通信エラーは-1を戻す
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// ユーザーガイド（ボディ）（ユーザー）論理削除処理
		/// </summary>
		/// <param name="userGdBd">ユーザーガイド（ボディ）クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）（ユーザー）の論理削除を行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int LogicalDelete(ref UserGdBd userGdBd)
		{
			try
			{
				// ユーザーガイド（ボディ）クラスからユーザーガイド（ボディ）ワーカークラスにメンバコピー
				UserGdBdUWork userGdBdUWork = CopyToUserGdBdUWorkFromUserGdBd(userGdBd);

				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(userGdBdUWork);

				// ユーザーガイド（ボディ）論理削除
				int status = this._iUserGdBdUDB.LogicalDelete(ref parabyte);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// ファイル名を渡してユーザーガイド（ボディ）ワーククラスをデシリアライズする
					userGdBdUWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte, typeof(UserGdBdUWork));
					// クラス内メンバコピー
					userGdBd = CopyToUserGdBdFromUserGdBdUWork(userGdBdUWork);
///////////////////////////////////////////////////////////////////// 2005.12.02 AKIYAMA ADD STA //
					// ガイド用キャッシュを更新
					if (ReadCheck(userGdBdUWork.UserGuideDivCd))
					{
						// ハッシュテーブル取得
						Hashtable wkUserGdBdTable = ( Hashtable )_guideBufUserGdBd[ userGdBd.UserGuideDivCd ];

						// 既に登録済みの場合は一度削除
						if( wkUserGdBdTable.ContainsKey( userGdBd.GuideCode ) == true ) {
							wkUserGdBdTable.Remove( userGdBd.GuideCode );
						}

						// 登録
						wkUserGdBdTable.Add( userGdBd.GuideCode, userGdBd.Clone() );
					}
// 2005.12.02 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
				}

				return status;
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iUserGdBdUDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// ユーザーガイド（ボディ）（ユーザー）物理削除処理
		/// </summary>
		/// <param name="userGdBd">ユーザーガイド（ボディ）クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）（ユーザー）の物理削除を行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int Delete(UserGdBd userGdBd)
		{
			try
			{
				// ユーザーガイド（ボディ）クラスからユーザーガイド（ボディ）ワーカークラスにメンバコピー
				UserGdBdUWork userGdBdUWork = CopyToUserGdBdUWorkFromUserGdBd(userGdBd);

				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(userGdBdUWork);

				// ユーザーガイド（ボディ）物理削除
				int status = this._iUserGdBdUDB.Delete(parabyte);

///////////////////////////////////////////////////////////////////// 2005.12.02 AKIYAMA ADD STA //
				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					// ガイド用キャッシュを更新
					if (ReadCheck(userGdBdUWork.UserGuideDivCd))
					{
						// ハッシュテーブル取得
						Hashtable wkUserGdBdTable = ( Hashtable )_guideBufUserGdBd[ userGdBd.UserGuideDivCd ];

						// 既に登録済みの場合は一度削除
						if( wkUserGdBdTable.ContainsKey( userGdBd.GuideCode ) == true ) {
							wkUserGdBdTable.Remove( userGdBd.GuideCode );
						}
					}
				}
// 2005.12.02 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
				return status;
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iUserGdBdUDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// ユーザーガイド（ヘッダ）情報全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ヘッダ）情報の全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int SearchHeader(out ArrayList retList)
		{
			return SearchHeaderProc(out retList, ConstantManagement.LogicalMode.GetData0);
		}

        // ----- iitani a ---------- start 2007.05.22
        /// <summary>
        /// ユーザーガイド（ボディ）情報全検索処理（論理削除除く）（ローカル）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="acsDataType">取得対象データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ユーザーガイド（ボディ）情報の全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 21027 須川  程志郎</br>
        /// <br>Date       : 2005.04.18</br>
        /// </remarks>
        public int SearchLocal(out ArrayList retList, string enterpriseCode, UserGuideAcsData acsDataType, int UserGuideDivCd )
        {
            return SearchBodyProc(out retList, enterpriseCode, acsDataType, ConstantManagement.LogicalMode.GetData0, UserGuideDivCd, 0);
        }

        /// <summary>
        /// ユーザーガイド（ボディ）情報全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="acsDataType">取得対象データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ユーザーガイド（ボディ）情報の全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 21027 須川  程志郎</br>
        /// <br>Date       : 2005.04.18</br>
        /// </remarks>
        public int SearchBody(out ArrayList retList, string enterpriseCode, UserGuideAcsData acsDataType, int UserGuideDivCd)
        {
            return SearchBodyProc(out retList, enterpriseCode, acsDataType, ConstantManagement.LogicalMode.GetData0, UserGuideDivCd, 1);
        }
        // ----- iitani a ---------- end 2007.05.22

		/// <summary>
		/// ユーザーガイド（ボディ）情報全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="acsDataType">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）情報の全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int SearchBody(out ArrayList retList, string enterpriseCode, UserGuideAcsData acsDataType)
		{
            // ----- iitani c ---------- start 2007.05.22
            //return SearchBodyProc(out retList, enterpriseCode, acsDataType, ConstantManagement.LogicalMode.GetData0);
            return SearchBodyProc(out retList, enterpriseCode, acsDataType, ConstantManagement.LogicalMode.GetData0, 0, 1);
            // ----- iitani c ---------- end 2007.05.22
		}

        // ----- iitani a ---------- start 2007.05.22
        /// <summary>
        /// ユーザーガイド（ボディ）情報全検索処理（論理削除含む）(ローカル)
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="acsDataType">取得対象データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ユーザーガイド（ボディ）情報の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 21027 須川  程志郎</br>
        /// <br>Date       : 2005.04.18</br>
        /// </remarks>
        public int SearchLocalAllBody(out ArrayList retList, string enterpriseCode, UserGuideAcsData acsDataType)
        {
            return SearchBodyProc(out retList, enterpriseCode, acsDataType, ConstantManagement.LogicalMode.GetData01, 0, 0);
        }
        // ----- iitani a ---------- end 2007.05.22

		/// <summary>
		/// ユーザーガイド（ボディ）情報全検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="acsDataType">取得対象データ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）情報の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int SearchAllBody(out ArrayList retList, string enterpriseCode, UserGuideAcsData acsDataType)
        {
            // ----- iitani c ---------- start 2007.05.22
            //return SearchBodyProc(out retList, enterpriseCode, acsDataType, ConstantManagement.LogicalMode.GetData01);
            return SearchBodyProc(out retList, enterpriseCode, acsDataType, ConstantManagement.LogicalMode.GetData01, 0, 1);
            // ----- iitani c ---------- end 2007.05.22
        }

		/// <summary>
		/// ガイド区分指定ユーザーガイド（ボディ）情報検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="acsDataType">取得対象データ</param>
		/// <param name="guideDivCode">ガイド区分コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定ガイド区分のユーザーガイド（ボディ）情報の検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int SearchDivCodeBody(out ArrayList retList, string enterpriseCode, int guideDivCode, UserGuideAcsData acsDataType)
		{
			return SearchDivCodeBodyProc(out retList, enterpriseCode, guideDivCode, acsDataType, ConstantManagement.LogicalMode.GetData0);
		}

		/// <summary>
		/// ガイド区分指定ユーザーガイド（ボディ）情報検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="acsDataType">取得対象データ</param>
		/// <param name="guideDivCode">ガイド区分コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定ガイド区分のユーザーガイド（ボディ）情報の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int SearchAllDivCodeBody(out ArrayList retList, string enterpriseCode, int guideDivCode, UserGuideAcsData acsDataType)
		{
			return SearchDivCodeBodyProc(out retList, enterpriseCode, guideDivCode, acsDataType, ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// ユーザーガイド（ボディ）論理削除復活処理
		/// </summary>
		/// <param name="userGdBd">ユーザーガイド（ボディ）クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）情報の復活を行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int Revival(ref UserGdBd userGdBd)
		{
			try
			{
				// ユーザーガイド（ボディ）クラスからユーザーガイド（ボディ）ワーカークラスにメンバコピー
				UserGdBdUWork userGdBdUWork = CopyToUserGdBdUWorkFromUserGdBd(userGdBd);

				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(userGdBdUWork);

				// ユーザーガイド（ボディ）復活処理
				int status = this._iUserGdBdUDB.RevivalLogicalDelete(ref parabyte);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// ユーザーガイド（ボディ）ワーククラスをデシリアライズする
					userGdBdUWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte, typeof(UserGdBdUWork));
					// クラス内メンバコピー
					userGdBd = CopyToUserGdBdFromUserGdBdUWork(userGdBdUWork);
///////////////////////////////////////////////////////////////////// 2005.12.02 AKIYAMA ADD STA //
					// ガイド用キャッシュを更新
					if (ReadCheck(userGdBd.UserGuideDivCd))
					{
						// ハッシュテーブル取得
						Hashtable wkUserGdBdTable = ( Hashtable )_guideBufUserGdBd[ userGdBd.UserGuideDivCd ];

						// 既に登録済みの場合は一度削除
						if( wkUserGdBdTable.ContainsKey( userGdBd.GuideCode ) == true ) {
							wkUserGdBdTable.Remove( userGdBd.GuideCode );
						}

						// 登録
						wkUserGdBdTable.Add( userGdBd.GuideCode, userGdBd.Clone() );
					}
// 2005.12.02 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
				}

				return status;
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iUserGdBdUDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// ユーザーガイド（ヘッダ）検索処理（実行部）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ヘッダ）の検索処理を行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		private int SearchHeaderProc(out ArrayList retList, ConstantManagement.LogicalMode logicalMode)
        {
			UserGdHdWork userGdHdWork = new UserGdHdWork();

			retList = new ArrayList();
			retList.Clear();

			object paraObj = userGdHdWork as Object;
			object retObj;

			// ユーザーガイド（ヘッダ）検索
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 2008.06.16 upd start --------------------------->>
            // ----- iitani c ---------- start 2007.05.22
			//status = this._iUserGdBdDB.SearchHeader(out retObj, paraObj, 0, logicalMode);
            status = this._userGdBdLcDB.SearchHeader(out retObj, paraObj, 0, logicalMode);
            // ----- iitani c ---------- start 2007.05.22
            // 2008.06.16 upd end -----------------------------<<
            
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				ArrayList userGdHdWorkList = retObj as ArrayList;
				
				for(int i = 0; i < userGdHdWorkList.Count; i++)
				{
					// クラス内メンバコピー
					retList.Add(CopyToUserGdHdFromUserGdHdWork((UserGdHdWork)userGdHdWorkList[i]));
				}
					
				// キャッシュ保持（SearchProc OfferDivCodeMerge 用）
				_userGdHdList = (ArrayList)retList.Clone();
			}
			return status;
		}

		/// <summary>
		/// ユーザーガイド（ボディ）検索処理（実行部）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="acsDataType">取得対象データ</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）の検索処理を行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
        // ----- iitani c ---------- start 2007.05.22
		//private int SearchBodyProc(out ArrayList retList, string enterpriseCode, UserGuideAcsData acsDataType, ConstantManagement.LogicalMode logicalMode)
        private int SearchBodyProc(out ArrayList retList, string enterpriseCode, UserGuideAcsData acsDataType, ConstantManagement.LogicalMode logicalMode, int UserGuideDivCd, int searchMode)
        // ----- iitani c ---------- end 2007.05.22
        {
			UserGdBdWork userGdBdWork   = new UserGdBdWork();

			UserGdBdUWork userGdBdUWork  = new UserGdBdUWork();
			userGdBdUWork.EnterpriseCode = enterpriseCode;
	
			retList = new ArrayList();
			retList.Clear();

			object offerObj = userGdBdWork as Object;
			object userObj  = userGdBdUWork as Object;
			object retObj;

			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			
			// オフラインの場合キャッシュから取得
            // -- DEL 2010/05/25 ------------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    status = SearchStaticMemory(out retList);
            //}
            //else	// オンラインの場合リモート取得
            //{
            // -- DEL 2010/05/25 -------------------------<<<
                //-- 提供分検索 --//
				if (acsDataType == UserGuideAcsData.OfferBodyData)
				{
					// ユーザーガイド（ボディ）検索
                    // ----- iitani c ---------- start 2007.05.22
                    //status = this._iUserGdBdDB.SearchBody(out retObj, offerObj, 0, logicalMode);
                    status = this._userGdBdLcDB.SearchBody(out retObj, offerObj, 0, logicalMode);
                    // ----- iitani c ---------- start 2007.05.22

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						ArrayList userGdBdWorkList = retObj as ArrayList;

						for(int i = 0; i < userGdBdWorkList.Count; i++)
						{
							// クラス内メンバコピー
							retList.Add(CopyToUserGdBdFromUserGdBdWork((UserGdBdWork)userGdBdWorkList[i]));
							// ユーザーガイド（ボディ）クラス ⇒ Static転記処理
							CopyToStaticFromDataClass(CopyToUserGdBdFromUserGdBdWork((UserGdBdWork)userGdBdWorkList[i]));
						}
					}
				}
					//-- ユーザー分検索 --//
				else if (acsDataType == UserGuideAcsData.UserBodyData)
				{
					// ユーザーガイド（ボディ）（ユーザー）検索
                    // ----- iitani c ----- start 2007.05.22
					//status = this._iUserGdBdUDB.Search(out retObj, userObj, 0, logicalMode);
                    if (searchMode == 1)
                    {
                        // リモート
                        status = this._iUserGdBdUDB.Search(out retObj, userObj, 0, logicalMode);
                    }
                    else
                    {
                        // ローカル
                        status = this._userGdBdULcDB.Search(out retObj, userObj, 0, logicalMode);
                    }

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						ArrayList userGdBdUWorkList = retObj as ArrayList;
				
						for(int i = 0; i < userGdBdUWorkList.Count; i++)
						{
							// クラス内メンバコピー
							retList.Add(CopyToUserGdBdFromUserGdBdUWork((UserGdBdUWork)userGdBdUWorkList[i]));
							// ユーザーガイド（ボディ）クラス ⇒ Static転記処理
							CopyToStaticFromDataClass(CopyToUserGdBdFromUserGdBdUWork((UserGdBdUWork)userGdBdUWorkList[i]));
						}
					}
				}
					//-- 提供分・ユーザー変更分マージ検索 --//
				else if (acsDataType == UserGuideAcsData.MergeBodyData)
				{
					// ユーザーガイド（ボディ）検索
                    // 2008.06.16 upd start ----------------------------->>
                    // ----- iitani c ---------- start 2007.05.22
                    //status = this._iUserGdBdDB.SearchBody(out retObj, offerObj, 0, logicalMode);
                    status = this._userGdBdLcDB.SearchBody(out retObj, offerObj, 0, logicalMode);
                    // ----- iitani c ---------- start 2007.05.22
                    // 2008.06.16 upd end -------------------------------<<

					// 正常取得又は、0件の場合
					if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
						(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
					{
						Hashtable mergeTable = new Hashtable();
						string hashKey;

						ArrayList userGdBdWorkList = retObj as ArrayList;
				
						if (userGdBdWorkList != null)
						{
							foreach (UserGdBdWork wkUserGdBdWork in userGdBdWorkList)
							{
								UserGdBd wkUserGdBd = CopyToUserGdBdFromUserGdBdWork(wkUserGdBdWork);
	
								// ユーザーガイド（ボディ）クラス ⇒ Static転記処理
								CopyToStaticFromDataClass(wkUserGdBd);
							
								hashKey = wkUserGdBd.UserGuideDivCd.ToString() + "_" + wkUserGdBd.GuideCode.ToString();
								mergeTable.Add(hashKey, wkUserGdBd);
							}
						}
					
						// ユーザーガイド（ボディ）検索
                        // ----- iitani c ---------- start 2007.05.22
						//status = this._iUserGdBdUDB.Search(out retObj, userObj, 0, logicalMode);
                        if (searchMode == 1)
                        {
                            // リモート
                            status = this._iUserGdBdUDB.Search(out retObj, userObj, 0, logicalMode);
                        }
                        else
                        {
                            // ローカル
                            status = this._userGdBdULcDB.Search(out retObj, userObj, 0, logicalMode);
                        }
                        // ----- iitani c ---------- end 2007.05.22

						// 正常取得又は、0件の場合
						if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
							(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
						{
							ArrayList userGdBdUWorkList = retObj as ArrayList;
				
							if (userGdBdUWorkList != null)
							{
								foreach (UserGdBdUWork wkUserGdBdUWork in userGdBdUWorkList)
								{
									UserGdBd wkUserGdBd = CopyToUserGdBdFromUserGdBdUWork(wkUserGdBdUWork);

									// ユーザーガイド（ボディ）クラス ⇒ Static転記処理
									CopyToStaticFromDataClass(wkUserGdBd);

									hashKey = wkUserGdBd.UserGuideDivCd.ToString() + "_" + wkUserGdBd.GuideCode.ToString();

									// マージ
									if (mergeTable.ContainsKey(hashKey))
									{
										mergeTable[hashKey] = wkUserGdBd;
									}
									else 
									{
										if (UserGuideDivCd != 0)
										{
											// DivCodeが同じもの
											if (wkUserGdBd.UserGuideDivCd == UserGuideDivCd)
											{
												mergeTable.Add(hashKey, wkUserGdBd);
											}
										}
										else
										{
											mergeTable.Add(hashKey, wkUserGdBd);
										}
									}					
								}
							
								if (mergeTable.Count > 0)
								{
									SortedList sortList = new SortedList();
									sortList.Add(mergeTable, mergeTable.Clone());

									retList = new ArrayList(mergeTable.Values);

                                    // ソート処理
                                    UserGdBdCompare userGdBdCompare = new UserGdBdCompare();
                                    retList.Sort(userGdBdCompare);
                                }
							}
						
							if (retList.Count != 0)
							{
								status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
							}
						}
					}
				}
					//-- Header提供区分毎 マージ検索 --//   (ソートしてません)
				else if	(acsDataType == UserGuideAcsData.OfferDivCodeMergeBodyData)
				{
					// ヘッダーのキャッシュが無い場合
					if (_userGdHdList.Count == 0)
					{
						ArrayList userGdHdListWk;

						// ヘッダー情報取得
						SearchHeaderProc(out userGdHdListWk, 0);
					}

					// ユーザーガイド（ボディ）検索
                    // 2008.06.16 upd start ------------------------------------------->>
                    // ----- iitani c ---------- start 2007.05.22
                    //status = this._iUserGdBdDB.SearchBody(out retObj, offerObj, 0, logicalMode);
                    status = this._userGdBdLcDB.SearchBody(out retObj, offerObj, 0, logicalMode);
                    // ----- iitani c ---------- end 2007.05.22
                    // 2008.06.16 upd end ---------------------------------------------<<

					// 正常取得又は、0件の場合
					if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
						(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
					{
						// マージ用ArrayList（提供）
						ArrayList mergeOfferList = new ArrayList();

						ArrayList userGdBdWorkList = retObj as ArrayList;
				
						if (userGdBdWorkList != null)
						{
							foreach (UserGdBdWork wkUserGdBdWork in userGdBdWorkList)
							{
								UserGdBd wkUserGdBd = CopyToUserGdBdFromUserGdBdWork(wkUserGdBdWork);
	
								// ユーザーガイド（ボディ）クラス ⇒ Static転記処理
								CopyToStaticFromDataClass(wkUserGdBd);

								mergeOfferList.Add(wkUserGdBd);
							}
						}
					
						// ユーザーガイド（ボディ）検索
                        // ----- iitani c ---------- start 2007.05.22
                        if (searchMode == 1)
                        {
                            status = this._iUserGdBdUDB.Search(out retObj, userObj, 0, logicalMode);
                        }
                        else
                        {
                            status = this._userGdBdULcDB.Search(out retObj, userObj, 0, logicalMode);
                        }
                        // ----- iitani c ---------- end 2007.05.22

						// 正常取得又は、0件の場合
						if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
							(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
						{
							// マージ用ArrayList（ユーザー）
							ArrayList mergeUserList = new ArrayList();

							// 最終マージ用List
							ArrayList OfferDivCodeMergeList = new ArrayList();
								
							ArrayList userGdBdUWorkList = retObj as ArrayList;
				
							if (userGdBdUWorkList != null)
							{
								foreach (UserGdBdUWork wkUserGdBdUWork in userGdBdUWorkList)
								{
									UserGdBd wkUserGdBd = CopyToUserGdBdFromUserGdBdUWork(wkUserGdBdUWork);

									// ユーザーガイド（ボディ）クラス ⇒ Static転記処理
									CopyToStaticFromDataClass(wkUserGdBd);

									mergeUserList.Add(wkUserGdBd);
								}

								// ヘッダのDivCode毎に提供区分に従ったデータをセットする
								foreach (UserGdHd userGdHdWk in _userGdHdList)
								{
									// 提供の場合
									if (userGdHdWk.MasterOfferCd == 0)
									{
										// 提供データList全件検索
										foreach (UserGdBd userGdBdWk in mergeOfferList)
										{
											// DivCodeが同じもの
											if (userGdBdWk.UserGuideDivCd == userGdHdWk.UserGuideDivCd)
											{
												OfferDivCodeMergeList.Add(userGdBdWk);
											}
										}
									}
									else  // 初期提供の場合
									{
										// ユーザーデータList全件検索
										foreach (UserGdBd userGdBdWk in mergeUserList)
										{
											// DivCodeが同じもの
											if (userGdBdWk.UserGuideDivCd == userGdHdWk.UserGuideDivCd)
											{
												OfferDivCodeMergeList.Add(userGdBdWk);
											}
										}
									}
								}

								if (OfferDivCodeMergeList.Count > 0)
								{
									retList = OfferDivCodeMergeList;
								}
							}
						
							if (retList.Count != 0)
							{
								status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
							}
						}
					}
				}
			//} // DEL 2010/05/25
			return status;
		}

		/// <summary>
		/// ユーザーガイド（ボディ）検索処理（実行部）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="acsDataType">取得対象データ</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="guideDivCode">ガイド区分コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）の検索処理を行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		private int SearchDivCodeBodyProc(out ArrayList retList, string enterpriseCode, int guideDivCode, UserGuideAcsData acsDataType, ConstantManagement.LogicalMode logicalMode)
		{
			UserGdBdWork userGdBdWork   = new UserGdBdWork();
			userGdBdWork.UserGuideDivCd = guideDivCode;

			UserGdBdUWork userGdBdUWork  = new UserGdBdUWork();
			userGdBdUWork.EnterpriseCode = enterpriseCode;
			userGdBdUWork.UserGuideDivCd = guideDivCode;

			retList = new ArrayList();
			retList.Clear();
			int status = 0;

			object offerObj = userGdBdWork as Object;
			object userObj  = userGdBdUWork as Object;
			object retObj;

			// オフラインの場合キャッシュから取得
            // -- DEL 2010/05/25 ----------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    SearchDivCodeStaticMemory(out retList, guideDivCode);
            //}
            //else	 // オンラインの場合はリモート取得
            //{
            // -- DEL 2010/05/25 -----------------<<<
                //-- 提供分検索 --//
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			
				if (acsDataType == UserGuideAcsData.OfferBodyData)
				{
					// ユーザーガイド（ボディ）検索
                    
                    // ----- iitani c ---------- start 2007.05.22
					//status = this._iUserGdBdDB.SearchGuideDivCode(out retObj, offerObj, 0, logicalMode);
                    status = this._userGdBdLcDB.SearchGuideDivCode(out retObj, offerObj, 0, logicalMode);
                    // ----- iitani c ---------- end 2007.05.22

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						ArrayList userGdBdWorkList = retObj as ArrayList;
				
						for(int i = 0; i < userGdBdWorkList.Count; i++)
						{
							// クラス内メンバコピー
							retList.Add(CopyToUserGdBdFromUserGdBdWork((UserGdBdWork)userGdBdWorkList[i]));
							// ユーザーガイド（ボディ）クラス ⇒ Static転記処理
							CopyToStaticFromDataClass(CopyToUserGdBdFromUserGdBdWork((UserGdBdWork)userGdBdWorkList[i]));
						}
					}
				}
					//-- ユーザー分検索 --//
				else if (acsDataType == UserGuideAcsData.UserBodyData)
				{
					// ユーザーガイド（ボディ）（ユーザー）検索
					status = this._iUserGdBdUDB.SearchGuideDivCode(out retObj, userObj, 0, logicalMode);

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						ArrayList userGdBdUWorkList = retObj as ArrayList;
				
						for(int i = 0; i < userGdBdUWorkList.Count; i++)
						{
							// クラス内メンバコピー
							retList.Add(CopyToUserGdBdFromUserGdBdUWork((UserGdBdUWork)userGdBdUWorkList[i]));
							// ユーザーガイド（ボディ）クラス ⇒ Static転記処理
							CopyToStaticFromDataClass(CopyToUserGdBdFromUserGdBdUWork((UserGdBdUWork)userGdBdUWorkList[i]));
						}
					}
				}
					//-- 提供分・ユーザー変更分マージ検索 --//
				else if (acsDataType == UserGuideAcsData.MergeBodyData)
				{
					// ユーザーガイド（ボディ）検索
                    // 2008.06.16 upd start ---------------------------->>
                    // ----- iitani c ---------- start 2007.05.22
                    //status = this._iUserGdBdDB.SearchGuideDivCode(out retObj, offerObj, 0, logicalMode);
                    status = this._userGdBdLcDB.SearchGuideDivCode(out retObj, offerObj, 0, logicalMode);
                    // ----- iitani c ---------- end 2007.05.22
                    // 2008.06.16 upd end ------------------------------<<

					// 正常取得又は、0件の場合
					if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
						(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
					{
						Hashtable mergeTable = new Hashtable();
						string hashKey;

						ArrayList userGdBdWorkList = retObj as ArrayList;
				
						if (userGdBdWorkList != null)
						{
							foreach (UserGdBdWork wkUserGdBdWork in userGdBdWorkList)
							{
								UserGdBd wkUserGdBd = CopyToUserGdBdFromUserGdBdWork(wkUserGdBdWork);

								// ユーザーガイド（ボディ）クラス ⇒ Static転記処理
								CopyToStaticFromDataClass(wkUserGdBd);
							
								hashKey = wkUserGdBd.UserGuideDivCd.ToString() + "_" + wkUserGdBd.GuideCode.ToString();
								mergeTable.Add(hashKey, wkUserGdBd);
							}
						}
					
						// ユーザーガイド（ボディ）（ユーザー）検索
						status = this._iUserGdBdUDB.SearchGuideDivCode(out retObj, userObj, 0, logicalMode);

						// 正常取得又は、0件の場合
						if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
							(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
						{
							ArrayList userGdBdUWorkList = retObj as ArrayList;
				
							if (userGdBdUWorkList != null)
							{
								foreach (UserGdBdUWork wkUserGdBdUWork in userGdBdUWorkList)
								{
									UserGdBd wkUserGdBd = CopyToUserGdBdFromUserGdBdUWork(wkUserGdBdUWork);
								
									// ユーザーガイド（ボディ）クラス ⇒ Static転記処理
									CopyToStaticFromDataClass(wkUserGdBd);

									hashKey = wkUserGdBd.UserGuideDivCd.ToString() + "_" + wkUserGdBd.GuideCode.ToString();

									// マージ
									if (mergeTable.ContainsKey(hashKey))
									{
										mergeTable[hashKey] = wkUserGdBd;
									}
									else 
									{
										mergeTable.Add(hashKey, wkUserGdBd);
									}					
								}
							
								if (mergeTable.Count > 0)
								{
									SortedList sortList = new SortedList();
									foreach (UserGdBd userGdBd in mergeTable.Values)
									{
										sortList.Add(userGdBd.GuideCode, userGdBd.Clone());
									}
								
									retList = new ArrayList(sortList.Values);
								}
							}

							if (retList.Count != 0)
							{
								status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
							}
						}
					}
				}
					//-- Header提供区分毎 マージ検索 --//   (ソートしてません)
				else if	(acsDataType == UserGuideAcsData.OfferDivCodeMergeBodyData)
				{
					// ヘッダーのキャッシュが無い場合
					if (_userGdHdList.Count == 0)
					{
						ArrayList userGdHdListWk;

						// ヘッダー情報取得
						SearchHeaderProc(out userGdHdListWk, 0);
					}

					// ユーザーガイド（ボディ）検索
                    // 2008.06.16 upd start --------------------------->>
                    // ----- iitani c ---------- start 2007.05.22
                    //status = this._iUserGdBdDB.SearchGuideDivCode(out retObj, offerObj, 0, logicalMode);
                    status = this._userGdBdLcDB.SearchGuideDivCode(out retObj, offerObj, 0, logicalMode);
                    // ----- iitani c ---------- end 2007.05.22
                    // 2008.06.16 upd end -----------------------------<<

					// 正常取得又は、0件の場合
					if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
						(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
					{
						// マージ用ArrayList（提供）
						ArrayList mergeOfferList = new ArrayList();

						ArrayList userGdBdWorkList = retObj as ArrayList;
				
						if (userGdBdWorkList != null)
						{
							foreach (UserGdBdWork wkUserGdBdWork in userGdBdWorkList)
							{
								UserGdBd wkUserGdBd = CopyToUserGdBdFromUserGdBdWork(wkUserGdBdWork);
	
								// ユーザーガイド（ボディ）クラス ⇒ Static転記処理
								CopyToStaticFromDataClass(wkUserGdBd);

								mergeOfferList.Add(wkUserGdBd);
							}
						}
					
						// ユーザーガイド（ボディ）検索
						status = this._iUserGdBdUDB.SearchGuideDivCode(out retObj, userObj, 0, logicalMode);

						// 正常取得又は、0件の場合
						if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
							(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
						{
							// マージ用ArrayList（ユーザー）
							ArrayList mergeUserList = new ArrayList();

							// 最終マージ用List
							ArrayList OfferDivCodeMergeList = new ArrayList();
								
							ArrayList userGdBdUWorkList = retObj as ArrayList;
				
							if (userGdBdUWorkList != null)
							{
								foreach (UserGdBdUWork wkUserGdBdUWork in userGdBdUWorkList)
								{
									UserGdBd wkUserGdBd = CopyToUserGdBdFromUserGdBdUWork(wkUserGdBdUWork);

									// ユーザーガイド（ボディ）クラス ⇒ Static転記処理
									CopyToStaticFromDataClass(wkUserGdBd);

									mergeUserList.Add(wkUserGdBd);
								}

								// ヘッダのDivCode毎に提供区分に従ったデータをセットする
								foreach (UserGdHd userGdHdWk in _userGdHdList)
								{
									if( userGdHdWk.UserGuideDivCd != guideDivCode ) {
										continue;
									}

									// 提供の場合
									if (userGdHdWk.MasterOfferCd == 0)
									{
										// 提供データList全件検索
										foreach (UserGdBd userGdBdWk in mergeOfferList)
										{
											// DivCodeが同じもの
											if (userGdBdWk.UserGuideDivCd == userGdHdWk.UserGuideDivCd)
											{
												OfferDivCodeMergeList.Add(userGdBdWk);
											}
										}
									}
									else  // 初期提供の場合
									{
										// ユーザーデータList全件検索
										foreach (UserGdBd userGdBdWk in mergeUserList)
										{
											// DivCodeが同じもの
											if (userGdBdWk.UserGuideDivCd == userGdHdWk.UserGuideDivCd)
											{
												OfferDivCodeMergeList.Add(userGdBdWk);
											}
										}
									}
								}

								if (OfferDivCodeMergeList.Count > 0)
								{
									retList = OfferDivCodeMergeList;
								}
							}
						
							if (retList.Count != 0)
							{
								status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
							}
							else {
								status = (int)ConstantManagement.DB_Status.ctDB_EOF;
							}
						}
					}
				}
			//}  // DEL 2010/05/25
			return status;
		}

		/// <summary>
		/// ユーザーガイド（ヘッダ）検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ヘッダ）の検索処理を行い、取得結果をDataSetで返します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int SearchHeader(ref DataSet ds)
		{
			UserGdHdWork userGdHdWork = new UserGdHdWork();

			// サーチ用リスト初期化
			ArrayList paraList = new ArrayList();
			paraList.Clear();

			object paraObj = userGdHdWork;
			object retObj = null;

			// 車販ガイドマスタ（ヘッダ）検索
            // 2008.06.16 upd start ------------------------------>>
            // ----- iitani c ---------- start 2007.05.22
            //int status = this._iUserGdBdDB.SearchHeader(out retObj, paraObj, 0, 0);
            int status = this._userGdBdLcDB.SearchHeader(out retObj, paraObj, 0, 0);
            //int status = this._uszzzerGdBdLcDB.SearchHeader(out retObj, paraObj, 0, 0);
            // ----- iitani c ---------- end 2007.05.22
            // 2008.06.16 upd end --------------------------------<<

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				paraList = retObj as ArrayList;
				UserGdHdWork[] byte_userGdHdWork = new UserGdHdWork[paraList.Count];
				
				for(int ix = 0; ix < paraList.Count; ix++)
				{
					byte_userGdHdWork[ix] = (UserGdHdWork)paraList[ix];
				}
								
				// XMLへ変換し、文字列のバイナリ化
				byte[] retbyte = XmlByteSerializer.Serialize(byte_userGdHdWork);
				
				XmlByteSerializer.ReadXml(ref ds, retbyte);
			}
			return status;
		}

        // ----- iitani a ---------- start 2007.05.22
		/// <summary>
		/// ユーザーガイド（ボディ）検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <param name="enterpriseCode">企業コード（ユーザーの場合のみ）</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）の検索処理を行い、取得結果をDataSetで返します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
        public int SearchLocalBody(ref DataSet ds, string enterpriseCode, int userGuideDivCd)
        {
            return SearchBody(ref ds, enterpriseCode, userGuideDivCd, 0);  // ローカル
        }

        /// <summary>
        /// ユーザーガイド（ボディ）検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="enterpriseCode">企業コード（ユーザーの場合のみ）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ユーザーガイド（ボディ）の検索処理を行い、取得結果をDataSetで返します。</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        public int SearchGuidBody(ref DataSet ds, string enterpriseCode, int userGuideDivCd)
        {
            return SearchBody(ref ds, enterpriseCode, userGuideDivCd, 1);  // サーバ
        }
        
		/// <summary>
		/// ユーザーガイド（ボディ）検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <param name="enterpriseCode">企業コード（ユーザーの場合のみ）</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）の検索処理を行い、取得結果をDataSetで返します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
        public int SearchBody(ref DataSet ds, string enterpriseCode)
        {
            return SearchBody(ref ds, enterpriseCode, 0, 1);  // リモート
        }
        // ----- iitani a ---------- end 2007.05.22

		/// <summary>
		/// ユーザーガイド（ボディ）検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <param name="enterpriseCode">企業コード（ユーザーの場合のみ）</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）の検索処理を行い、取得結果をDataSetで返します。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
        // ----- iitani c ---------- start 2007.05.22  
		//public int SearchBody(ref DataSet ds, string enterpriseCode)
        public int SearchBody(ref DataSet ds, string enterpriseCode, int userGuideDivCd, int searchMode)
        // ----- iitani c ---------- start 2007.05.22  
        {
			ArrayList retList = new ArrayList();
			int status;
			
			// オンラインの場合はリモート取得
            // -- UPD 2010/05/25 --------------------->>>
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    // ユーザーガイド（ボディ）検索処理
            //    status = SearchBodyProc(out retList, enterpriseCode, UserGuideAcsData.MergeBodyData, 0, userGuideDivCd, searchMode);
            //}
            //else	// オフラインの場合はキャッシュから読む
            //{
            //    status = SearchStaticMemory(out retList);
            //}

            // ユーザーガイド（ボディ）検索処理
            status = SearchBodyProc(out retList, enterpriseCode, UserGuideAcsData.MergeBodyData, 0, userGuideDivCd, searchMode);
            // -- UPD 2010/05/25 ---------------------<<<
			
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// オンラインの場合はキャッシュに保持
                // -- UPD 2010/05/25 ------------------->>>
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                //    foreach (UserGdBd wkUserGdBd in retList)
                //    {
                //        // ユーザーガイド（ボディ）クラス ⇒ Static転記処理
                //        CopyToStaticFromDataClass(wkUserGdBd);
                //    }
                //}

                foreach (UserGdBd wkUserGdBd in retList)
                {
                    // ユーザーガイド（ボディ）クラス ⇒ Static転記処理
                    CopyToStaticFromDataClass(wkUserGdBd);
                }
                // -- UPD 2010/05/25 -------------------<<<
					
				UserGdBd[] byte_userGdBdWork = new UserGdBd[retList.Count];
								
				for(int ix = 0; ix < retList.Count; ix++)
				{
					byte_userGdBdWork[ix] = (UserGdBd)retList[ix];
				}
								
				// XMLへ変換し、文字列のバイナリ化
				byte[] retbyte = XmlByteSerializer.Serialize(byte_userGdBdWork);
				
				XmlByteSerializer.ReadXml(ref ds, retbyte);
			}
			return status;
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// KEY指定ユーザーガイド（ボディ）情報読み込み処理（実行部）
		/// </summary>
		/// <param name="userGdBd">ユーザーガイド（ボディ）クラス</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="guideDivCode">ガイド区分</param>
		/// <param name="guideCode">ガイドコード</param>
		/// <param name="getDataType">取得対象テーブル区分</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）情報を読み込みます。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		private int ReadBodyProc(out UserGdBd userGdBd, string enterpriseCode, int guideDivCode, int guideCode, UserGuideAcsData getDataType)
		{
			try
			{
				userGdBd = null;
				int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		
				UserGdBdWork userGdBdWork   = new UserGdBdWork();
				userGdBdWork.UserGuideDivCd = guideDivCode;
				userGdBdWork.GuideCode		= guideCode;

				UserGdBdUWork userGdBdUWork  = new UserGdBdUWork();
				userGdBdUWork.EnterpriseCode = enterpriseCode;
				userGdBdUWork.UserGuideDivCd = guideDivCode;
				userGdBdUWork.GuideCode		 = guideCode;

				// XMLへ変換し、文字列のバイナリ化
				byte[] offerbyte = XmlByteSerializer.Serialize(userGdBdWork);
				byte[] userbyte  = XmlByteSerializer.Serialize(userGdBdUWork);

				switch (getDataType)
				{
					case (UserGuideAcsData.OfferBodyData) :
					{
						// ユーザーガイド（ボディ）読み込み
                        
                        // ----- iitani c ---------- start 2007.05.22
                        //status = this._iUserGdBdDB.Read(ref offerbyte, 0);
                        status = this._userGdBdLcDB.Read(ref userGdBdWork, 0);
                        // ----- iitani c ---------- end 2007.05.22
                        
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							// XMLの読み込み
							userGdBdWork = (UserGdBdWork)XmlByteSerializer.Deserialize(offerbyte, typeof(UserGdBdWork));
							// クラス内メンバコピー
							userGdBd = CopyToUserGdBdFromUserGdBdWork(userGdBdWork);
						}
						return status;
					}
					case (UserGuideAcsData.UserBodyData) :
					{
						// ユーザーガイド（ボディ）（ユーザー）読み込み
						status = this._iUserGdBdUDB.Read(ref userbyte, 0);

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							// XMLの読み込み
							userGdBdUWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(userbyte, typeof(UserGdBdUWork));
							// クラス内メンバコピー
							userGdBd = CopyToUserGdBdFromUserGdBdUWork(userGdBdUWork);
						}
						return status;
					}
					case (UserGuideAcsData.MergeBodyData) :
					{
						// ユーザーガイド（ボディ）（ユーザー）読み込み
						status = this._iUserGdBdUDB.Read(ref userbyte, 0);

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							// XMLの読み込み
							userGdBdUWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(userbyte, typeof(UserGdBdUWork));
							// クラス内メンバコピー
							userGdBd = CopyToUserGdBdFromUserGdBdUWork(userGdBdUWork);
							break;
						}
						
						// ユーザーガイド（ボディ）読み込み
                        // 2008.06.16 upd start ---------------------------------->>
                        // ----- iitani c ---------- start 2007.05.22
                        status = this._iUserGdBdDB.Read(ref offerbyte, 0);
                        //status = this._userGdBdLcDB.Read(ref userGdBdWork, 0);
                        // ----- iitani c ---------- end 2007.05.22
                        // 2008.06.16 upd end ------------------------------------<<

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							// XMLの読み込み
							userGdBdWork = (UserGdBdWork)XmlByteSerializer.Deserialize(offerbyte, typeof(UserGdBdWork));
							// クラス内メンバコピー
							userGdBd = CopyToUserGdBdFromUserGdBdWork(userGdBdWork);
							break;
						}
						
						if (userGdBd != null)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}

						break;
					}
				}
				return status;
			}
			catch (Exception)
			{
				// 通信エラーは-1を戻す
				userGdBd = null;
				// オフライン時はnullをセット
				//this._iUserGdBdDB  = null;  // iitani d 2007.05.22
				this._iUserGdBdUDB = null;
				return -1;
			}
		}

		/// <summary>
		/// クラスメンバーコピー処理（ユーザーガイド（ヘッダ）ワーククラス⇒ユーザーガイド（ヘッダ）クラス）
		/// </summary>
		/// <param name="userGdHdWork">ユーザーガイド（ヘッダ）ワーククラス</param>
		/// <returns>ユーザーガイド（ボディ）クラス</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ヘッダ）ワーククラスからユーザーガイド（ヘッダ）クラスへメンバのコピーを行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		private UserGdHd CopyToUserGdHdFromUserGdHdWork(UserGdHdWork userGdHdWork)
		{
			UserGdHd userGdHd = new UserGdHd();

			userGdHd.CreateDateTime		= userGdHdWork.CreateDateTime;
			userGdHd.UpdateDateTime		= userGdHdWork.UpdateDateTime;
			userGdHd.LogicalDeleteCode	= userGdHdWork.LogicalDeleteCode;

			userGdHd.UserGuideDivCd		= userGdHdWork.UserGuideDivCd;
			userGdHd.UserGuideDivNm		= userGdHdWork.UserGuideDivNm;
			userGdHd.MasterOfferCd		= userGdHdWork.MasterOfferCd;

			return userGdHd;
		}

		/// <summary>
		/// クラスメンバーコピー処理（ユーザーガイド（ヘッダ）クラス⇒ユーザーガイド（ヘッダ）ワーククラス）
		/// </summary>
		/// <param name="userGdHd">ユーザーガイド（ヘッダ）クラス</param>
		/// <returns>ユーザーガイド（ヘッダ）クラス</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ヘッダ）ワーククラスからユーザーガイド（ヘッダ）クラスへメンバのコピーを行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		private UserGdHdWork CopyToUserGdHdWorkFromUserGdHd(UserGdHd userGdHd)
		{
			UserGdHdWork userGdHdWork = new UserGdHdWork();

			userGdHdWork.CreateDateTime		= userGdHd.CreateDateTime;
			userGdHdWork.UpdateDateTime		= userGdHd.UpdateDateTime;
			userGdHdWork.LogicalDeleteCode	= userGdHd.LogicalDeleteCode;

			userGdHdWork.UserGuideDivCd		= userGdHd.UserGuideDivCd;
			userGdHdWork.UserGuideDivNm		= userGdHd.UserGuideDivNm;
			userGdHdWork.MasterOfferCd		= userGdHd.MasterOfferCd;

			return userGdHdWork;
		}

		/// <summary>
		/// クラスメンバーコピー処理（ユーザーガイド（ボディ）ワーククラス⇒ユーザーガイド（ボディ）クラス）
		/// </summary>
		/// <param name="userGdBdWork">ユーザーガイド（ボディ）ワーククラス</param>
		/// <returns>ユーザーガイド（ボディ）クラス</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）ワーククラスからユーザーガイド（ボディ）クラスへメンバのコピーを行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		private UserGdBd CopyToUserGdBdFromUserGdBdWork(UserGdBdWork userGdBdWork)
		{
			UserGdBd userGdBd = new UserGdBd();

			userGdBd.CreateDateTime		= userGdBdWork.CreateDateTime;
			userGdBd.UpdateDateTime		= userGdBdWork.UpdateDateTime;
			userGdBd.FileHeaderGuid		= Guid.NewGuid();
			userGdBd.LogicalDeleteCode	= userGdBdWork.LogicalDeleteCode;

			userGdBd.UserGuideDivCd		= userGdBdWork.UserGuideDivCd;
			userGdBd.GuideCode			= userGdBdWork.GuideCode;
			userGdBd.GuideName			= userGdBdWork.GuideName;
			userGdBd.GuideType			= userGdBdWork.GuideType;

			return userGdBd;
		}

		/// <summary>
		/// クラスメンバーコピー処理（ユーザーガイド（ボディ）（ユーザー）ワーククラス⇒ユーザーガイド（ボディ）クラス）
		/// </summary>
		/// <param name="userGdBdUWork">ユーザーガイド（ボディ）（ユーザー）ワーククラス</param>
		/// <returns>ユーザーガイド（ボディ）クラス</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）（ユーザー）ワーククラスから
		///					 ユーザーガイド（ボディ）クラスへメンバのコピーを行います。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.12</br>
		/// </remarks>
		private UserGdBd CopyToUserGdBdFromUserGdBdUWork(UserGdBdUWork userGdBdUWork)
		{
			UserGdBd userGdBd = new UserGdBd();

			userGdBd.CreateDateTime		= userGdBdUWork.CreateDateTime;
			userGdBd.UpdateDateTime		= userGdBdUWork.UpdateDateTime;
			userGdBd.EnterpriseCode		= userGdBdUWork.EnterpriseCode;
			userGdBd.FileHeaderGuid		= userGdBdUWork.FileHeaderGuid;
			userGdBd.LogicalDeleteCode	= userGdBdUWork.LogicalDeleteCode;

			userGdBd.UserGuideDivCd		= userGdBdUWork.UserGuideDivCd;
			userGdBd.GuideCode			= userGdBdUWork.GuideCode;
			userGdBd.GuideName			= userGdBdUWork.GuideName;
			userGdBd.GuideType			= userGdBdUWork.GuideType;

			return userGdBd;
		}

		/// <summary>
		/// クラスメンバーコピー処理（ユーザーガイド（ボディ）クラス⇒ユーザーガイド（ボディ）ワーククラス）
		/// </summary>
		/// <param name="userGdBd">ユーザーガイド（ボディ）クラス</param>	 
		/// <returns>ユーザーガイド（ボディ）クラス</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）ワーククラスからユーザーガイド（ボディ）クラスへメンバのコピーを行います。</br>
		/// <br>Programmer : 21027 須川  程志郎</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		private UserGdBdWork CopyToUserGdBdWorkFromUserGdBd(UserGdBd userGdBd)
		{
			UserGdBdWork userGdBdWork = new UserGdBdWork();

			userGdBdWork.CreateDateTime		= userGdBd.CreateDateTime;
			userGdBdWork.UpdateDateTime		= userGdBd.UpdateDateTime;
			userGdBdWork.LogicalDeleteCode	= userGdBd.LogicalDeleteCode;

			userGdBdWork.UserGuideDivCd		= userGdBd.UserGuideDivCd;
			userGdBdWork.GuideCode			= userGdBd.GuideCode;
			userGdBdWork.GuideName			= userGdBd.GuideName.TrimEnd();
			userGdBdWork.GuideType			= userGdBd.GuideType;

			return userGdBdWork;
		}

		/// <summary>
		/// クラスメンバーコピー処理（ユーザーガイド（ボディ）クラス⇒ユーザーガイド（ボディ）（ユーザー）ワーククラス）
		/// </summary>
		/// <param name="userGdBd">ユーザーガイド（ボディ）クラス</param>	 
		/// <returns>ユーザーガイド（ボディ）（ユーザー）クラス</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）ワーククラスから
		///					 ユーザーガイド（ボディ）（ユーザー）クラスへメンバのコピーを行います。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.12</br>
		/// </remarks>
		private UserGdBdUWork CopyToUserGdBdUWorkFromUserGdBd(UserGdBd userGdBd)
		{
			UserGdBdUWork userGdBdUWork = new UserGdBdUWork();

			userGdBdUWork.CreateDateTime	= userGdBd.CreateDateTime;
			userGdBdUWork.UpdateDateTime	= userGdBd.UpdateDateTime;
			userGdBdUWork.EnterpriseCode	= userGdBd.EnterpriseCode;
			userGdBdUWork.FileHeaderGuid	= userGdBd.FileHeaderGuid;
			userGdBdUWork.LogicalDeleteCode	= userGdBd.LogicalDeleteCode;

			userGdBdUWork.UserGuideDivCd	= userGdBd.UserGuideDivCd;
			userGdBdUWork.GuideCode			= userGdBd.GuideCode;
			userGdBdUWork.GuideName			= userGdBd.GuideName.TrimEnd();
			userGdBdUWork.GuideType			= userGdBd.GuideType;

			return userGdBdUWork;
		}

		/// <summary>
		/// ユーザーガイド（ボディ）クラス ⇒ UIクラス変換処理
		/// </summary>
		/// <param name="userGdBd">ユーザーガイド（ボディ）クラス</param>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）クラスをStaticメモリに保持します。</br>
		/// <br>Programer  : 22033  三崎  貴史</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		private void CopyToStaticFromDataClass(UserGdBd userGdBd)
		{
			// HashKey : 区分コード＋ガイドコード
			string hashKey = userGdBd.UserGuideDivCd + "_" + userGdBd.GuideCode;

			UserGdBd wkUserGdBd = new UserGdBd();

			wkUserGdBd.CreateDateTime		= userGdBd.CreateDateTime;
			wkUserGdBd.UpdateDateTime		= userGdBd.UpdateDateTime;
			wkUserGdBd.LogicalDeleteCode	= userGdBd.LogicalDeleteCode;

			wkUserGdBd.UserGuideDivCd		= userGdBd.UserGuideDivCd;
			wkUserGdBd.GuideCode			= userGdBd.GuideCode;
			wkUserGdBd.GuideName			= userGdBd.GuideName;
			wkUserGdBd.GuideType			= userGdBd.GuideType;
				
			_userGdBdTable_Stc[hashKey] = wkUserGdBd;
		}

		/// <summary>
		/// ユーザーガイド（ボディ）ワーカークラス ⇒ UIクラス変換処理
		/// </summary>
		/// <param name="userGdBdUWork">ユーザーガイド（ボディ）ワーカークラス</param>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）クラスをStaticメモリに保持します。</br>
		/// <br>Programer  : 22033  三崎  貴史</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		private void CopyToStaticFromWork(UserGdBdUWork userGdBdUWork)
		{
			// HashKey : 区分コード＋ガイドコード
			string hashKey = userGdBdUWork.UserGuideDivCd + "_" + userGdBdUWork.GuideCode;

			UserGdBd wkUserGdBd = new UserGdBd();

			wkUserGdBd.CreateDateTime		= userGdBdUWork.CreateDateTime;
			wkUserGdBd.UpdateDateTime		= userGdBdUWork.UpdateDateTime;
			wkUserGdBd.FileHeaderGuid		= userGdBdUWork.FileHeaderGuid;
			wkUserGdBd.LogicalDeleteCode	= userGdBdUWork.LogicalDeleteCode;

			wkUserGdBd.UserGuideDivCd		= userGdBdUWork.UserGuideDivCd;
			wkUserGdBd.GuideCode			= userGdBdUWork.GuideCode;
			wkUserGdBd.GuideName			= userGdBdUWork.GuideName;
			wkUserGdBd.GuideType			= userGdBdUWork.GuideType;
				
			_userGdBdTable_Stc[hashKey] = wkUserGdBd;
		}

		/// <summary>
		/// ローカルファイル読込み処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : ローカルファイルを読込んで、情報をStaticに保持します。</br>
		/// <br>Programer  : 22033  三崎  貴史</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		private void SearchOfflineData()
		{
			// オフラインシリアライズデータ作成部品I/O
			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

			// KeyList設定
			string[] userGdBdKeys = new string[1];
			userGdBdKeys[0] = LoginInfoAcquisition.EnterpriseCode;
			// ローカルファイル読込み処理
			object wkObj = offlineDataSerializer.DeSerialize("UserGuideAcs", userGdBdKeys);
			// ArrayListにセット
			ArrayList wkList = wkObj as ArrayList;

			if ((wkList != null ) &&
				(wkList.Count != 0))
			{
				foreach (UserGdBdUWork userGdBdUWork in wkList)
				{
					// ユーザーガイド（ボディ）ワーカークラス ⇒ Static変換処理
					CopyToStaticFromWork(userGdBdUWork);
				}
			}
		}

		/// <summary>
		/// 既読判定
		/// </summary>
		/// <param name="userGuideDivCd">ガイド区分</param>
		/// <returns>既読判定[true:既読区分, false:未読区分]</returns>
		/// <remarks>指定ガイド区分についてリモートを行ったかどうか判定して返します。</remarks>
		private bool ReadCheck(int userGuideDivCd)
		{
			foreach (int ix in _staticReadMngList)
			{
				if (ix == userGuideDivCd)
				{
					return true;
				}
			}

			return false;
		}
		#endregion

		#region SearchGuideBuf
///////////////////////////////////////////////////////////////////// 2005.12.03 AKIYAMA ADD STA //
		/// <summary>
		/// ガイド名称取得（ボディ）
		/// </summary>
		/// <param name="guideName">ガイド名称</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="userGuideDiv">ユーザーガイド区分</param>
		/// <param name="guideCode">ガイドコード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイド区分・ガイドコードからガイド名称の取得を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.12.03</br>
		/// </remarks>
		public int GetGuideName( out string guideName, string enterpriseCode, int userGuideDiv, int guideCode )
		{
			int status = 0;
			guideName = "";

			try {
				// エントリ用ユーザーバッファがある場合はそちらからどうぞ！
				if( ( _userGdBdEntryTable != null ) && ( _userGdBdEntryTable.Count > 0 ) )
				{
					string key = userGuideDiv.ToString() + "_" + guideCode.ToString();
					if( _userGdBdEntryTable[key] != null )
					{
						guideName = ( (UserGdBdU)_userGdBdEntryTable[key]).GuideName;
						return 0;
					}
					else
					{
						guideName = "未登録";
						return 4;
					}
				}

				if (!ReadCheck(userGuideDiv))
				{
					status = GetUserGdBdBuffer(enterpriseCode, userGuideDiv);
					if( status != ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
						guideName = "未登録";
						return status;
					}
				}

				// キャッシュ用ハッシュテーブル取得
				Hashtable wkUserGdBdTable = ( Hashtable )_guideBufUserGdBd[ userGuideDiv ];

				// 作業・部品区分が存在する
				if( wkUserGdBdTable.ContainsKey( guideCode ) == true ) {
					UserGdBd userGdBd = ( UserGdBd )wkUserGdBdTable[ guideCode ];
					
					// 論理削除されていない
					if( userGdBd.LogicalDeleteCode == 0 ) {
						guideName = userGdBd.GuideName;
					}
					// 論理削除されている
					else {
						guideName = "削除済";
					}
				}
				// 作業・部品区分が存在しない
				else {
					guideName = "未登録";
					status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
			}
			catch( Exception ) {
				guideName = "未登録";
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// ユーザーガイド（ボディ）ガイド用キャッシュ検索処理
		/// </summary>
		/// <param name="retList">検索結果リスト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="userGuideDivCd">ユーザーガイド区分</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ガイド用のStaticキャッシュからユーザーガイド（ボディ）の検索を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.12.02</br>
		/// </remarks>
		public int SearchGuideBufStaticMemory( out ArrayList retList, string enterpriseCode, int userGuideDivCd )
		{
			return SearchGuideBufStaticMemoryProc( out retList, enterpriseCode, userGuideDivCd );
		}
		
		/// <summary>
		/// ユーザーガイド（ボディ）ガイド表示データ取得
		/// </summary>
		/// <param name="retList">検索結果リスト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="userGuideDivCd">ユーザーガイド区分</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ガイドに表示するユーザーガイド（ボディ）データを取得する</br>
		/// <br>Programmer : 99032 伊藤 美紀</br>
		/// <br>Date       : 2005.06.08</br>
		/// </remarks>
		private int SearchGuideBufStaticMemoryProc( out ArrayList retList, string enterpriseCode, int userGuideDivCd )
		{
			int status = 0;
			retList = new ArrayList();
		
			try 
			{
				if (!ReadCheck(userGuideDivCd))
				{
					status = GetUserGdBdBuffer(enterpriseCode, userGuideDivCd);

					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						return status;
					}
				}

				if (_guideBufUserGdBd.ContainsKey(userGuideDivCd) == false)
				{
					return (int)ConstantManagement.DB_Status.ctDB_EOF;
				}

				// キャッシュ用ハッシュテーブル取得
				Hashtable wkUserGdBdTable = (Hashtable)_guideBufUserGdBd[userGuideDivCd];

				foreach (UserGdBd userGdBd in wkUserGdBdTable.Values) 
				{
					if (userGdBd.LogicalDeleteCode == 0)
					{
						retList.Add(userGdBd.Clone());
					}
				}
				retList.Sort(new UserGdBdCompare());

				if (retList.Count > 0)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
				else
				{
					status = (int)ConstantManagement.DB_Status.ctDB_EOF;
				}
			}
			catch (Exception)
			{
				status = -1;
			}

			return status;
		}
		
		/// <summary>
		/// ガイド用ユーザーガイド（ボディ）バッファ取得
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="userGuideDivCd">ユーザーガイド区分</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ガイド用バッファエリアにユーザーガイド（ボディ）情報を取得します</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.12.03</br>
		/// </remarks>
		private int GetUserGdBdBuffer( string enterpriseCode, int userGuideDivCd )
		{
			int status = 0;

			try 
			{
				if (_guideBufUserGdBd == null)
				{
					_guideBufUserGdBd = new Hashtable();
				}

				ArrayList userGdBds = null;
				status = this.SearchAllDivCodeBody( out userGdBds, enterpriseCode, userGuideDivCd, UserGuideAcsData.OfferDivCodeMergeBodyData );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					if( userGdBds.Count > 0 ) {
						foreach( UserGdBd userGdBd in userGdBds ) {
							Hashtable wkUserGdBdTable = null;
							// 作業・部品種別がキャッシュに未登録
							if( _guideBufUserGdBd.ContainsKey( userGdBd.UserGuideDivCd ) == false ) {
								// インスタンスを生成し、登録
								wkUserGdBdTable = new Hashtable();
								_guideBufUserGdBd.Add( userGdBd.UserGuideDivCd, wkUserGdBdTable );
								wkUserGdBdTable.Clear();
							}
							// 作業・部品種別がキャッシュに登録済
							else {
								wkUserGdBdTable = ( Hashtable )_guideBufUserGdBd[ userGdBd.UserGuideDivCd ];
							}
							wkUserGdBdTable.Add( userGdBd.GuideCode, userGdBd.Clone() );
						}
					}
					else {
						status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
					}
				}

				_staticReadMngList.Add(userGuideDivCd);
			}
			catch( Exception ) {
				status = -1;
			}
			return status;
		}

		/// <summary>
		/// ユーザーガイド（ボディ）オブジェクト比較クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : ユーザーガイド（ボディ）の比較を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.12.03</br>
		/// </remarks>
		public class UserGdBdCompare : IComparer
		{
			#region IComparer メンバ

			/// <summary>
			/// ユーザーガイド（ボディ）オブジェクト比較メソッド
			/// </summary>
			/// <param name="x">比較対象オブジェクト</param>
			/// <param name="y">比較対象オブジェクト</param>
			/// <returns>比較結果</returns>
			/// <remarks>
			/// <br>Note       : ユーザーガイド（ボディ）の比較を行います。</br>
			/// <br>Programmer : 23001 秋山　亮介</br>
			/// <br>Date       : 2005.12.03</br>
			/// </remarks>
			public int Compare(object x, object y)
			{
				UserGdBd userGdBd1 = ( UserGdBd )x;
				UserGdBd userGdBd2 = ( UserGdBd )y;

				if( userGdBd1.UserGuideDivCd != userGdBd2.UserGuideDivCd ) {
					return userGdBd1.UserGuideDivCd.CompareTo( userGdBd2.UserGuideDivCd );
				}

				return userGdBd1.GuideCode.CompareTo( userGdBd2.GuideCode );
			}

			#endregion

		}

// 2005.12.03 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
		#endregion

        // ----- iitani a start ---------- 2007.05.22
        #region ▼ガイド起動処理
        /// <summary>
        /// 商品大分類マスタガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="lgoodsganre">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: 商品大分類マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer	: 980023 飯谷  耕平</br>
        /// <br>Date		: 2006.12.04</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out UserGdHd userGdHd, out UserGdBd userGdBd, int userGuideDivCd)
        {
            int status = -1;
            userGdBd = new UserGdBd();
            userGdHd = new UserGdHd();
            string xmlName = "";

            if (userGuideDivCd == 0)
            {
                xmlName = "USERGUIDEKTNGUIDEPARENT.XML";
            }
            else
            {
                xmlName = "USERGUIDEGUIDEPARENT.XML";
            }

            TableGuideParent tableGuideParent = new TableGuideParent(xmlName);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);
            inObj.Add("UserGuideDivCd", userGuideDivCd);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                if (userGuideDivCd == 0)
                {
                    // ユーザーガイド(ヘッダ)
                    string strHdCode = retObj["UserGuideDivCd"].ToString();
                    userGdHd.UserGuideDivCd = int.Parse(strHdCode);
                    userGdHd.UserGuideDivNm = retObj["UserGuideDivNm"].ToString();
                }

                // ユーザーガイド(ボディ)
                string strBdCode = retObj["GuideCode"].ToString();
                userGdBd.GuideCode = int.Parse(strBdCode);
                userGdBd.GuideName = retObj["GuideName"].ToString();

                status = 0;
            }
            // キャンセル
            else
            {
                status = 1;
            }

            return status;
        }
        # endregion


        #region ▼IGeneralGuidData Method
        /// <summary>
        /// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note		: 汎用ガイド設定用データを取得します。</br>
        /// <br>Programmer	: 980023 飯谷  耕平</br>
        /// <br>Date		: 2006.12.04</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";
            int userGuideDivCd = 0;

            // ユーザーガイド区分設定有り(ヘッダ、ボディの呼び分けにも使用)
            if (inParm.ContainsKey("UserGuideDivCd"))
            {
                // 企業コード設定有り
                if (inParm.ContainsKey("EnterpriseCode"))
                {
                    if (inParm["EnterpriseCode"].ToString() != "")
                    {
                        enterpriseCode = inParm["EnterpriseCode"].ToString();
                    }
                    else
                    {
                        // 自企業コードを強制的に入れる
                        enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    }
                }
                // 企業コード設定無し
                else
                {
                    // 有り得ないのでエラー
                    return status;
                }

                object userGuideDivCdObj = inParm["UserGuideDivCd"];
                userGuideDivCd = int.Parse(userGuideDivCdObj.ToString());

                // ユーザーガイドマスタ(Body)テーブル読込み(ローカルDB) 
                //status = SearchLocalBody(ref guideList, enterpriseCode, userGuideDivCd); // 2008.06.16 del
                status = SearchGuidBody(ref guideList, enterpriseCode, userGuideDivCd);    // 2008.06.16 add サーバを参照する
            }
            else
            {
                // ユーザーガイドマスタ(Header)テーブル読込み(ローカルDB) 
                status = SearchHeader(ref guideList);
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
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
        // ----- iitani a end ---------- 2007.05.22

        /// <summary>
        /// ユーザーガイド(ボディ)比較クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザーガイド(ボディ)比較クラス</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2008.01.09</br>
        /// </remarks>
        public class UserGdBdUCompare : System.Collections.IComparer
        {
            /// <summary>
            /// ユーザーガイド(ボディ)比較クラス
            /// </summary>
            public int Compare(object x, object y)
            {
                int result = 0;

                UserGdBdUWork cx = (UserGdBdUWork)x;
                UserGdBdUWork cy = (UserGdBdUWork)y;

                //ユーザーガイド区分コード
                if (result == 0)
                    result = cx.UserGuideDivCd - cy.UserGuideDivCd;

                //ガイドコード
                if (result == 0)
                    result = cx.GuideCode - cy.GuideCode;

                //結果を返す
                return result;
            }
        }

    }
}