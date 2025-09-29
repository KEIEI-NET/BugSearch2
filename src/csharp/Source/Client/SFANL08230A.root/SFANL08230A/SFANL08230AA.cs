using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller 
{
	/// <summary>
	/// 印字位置ダウンロード画面アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 印字位置ダウンロード画面クラスのアクセス制御を行います。</br>
	/// <br>Programmer	: 22011 柏原　頼人</br>
	/// <br>Date		: 2007.05.14</br>
	/// </remarks>
    public class DownLoadPrtPosAcs : SFANL08230AB
	{
		# region Constructor
		/// <summary>
		/// 印字位置ダウンロード画面アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 印字位置ダウンロード画面アクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public DownLoadPrtPosAcs()
		{
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._userPrtPosSetDBAcs = new SFANL08230AE();
            this._localPrtPosSetDBAcs = new FrePrtPosLocalAcs();    //自由帳票印字位置ローカルXMLアクセスクラス
            this._frePrtPSetAcs = new FrePrtPSetAcs();           //自由帳票印字位置DBアクセスクラス
        }
		# endregion

		#region Private Members
		// 印字位置設定(ユーザーDB)アクセスクラス
		private SFANL08230AE  _userPrtPosSetDBAcs = null;
        // 印字位置設定(ローカルXML)アクセスクラス
        private FrePrtPosLocalAcs _localPrtPosSetDBAcs = null;
        // 印字位置設定(ユーザーDB)I/Oライト用アクセスクラス
        private FrePrtPSetAcs _frePrtPSetAcs = null;

        // 企業コード
		private string _enterpriseCode = null;
		#endregion
		
		#region Public Methods

        #region 孤立ローカル印字位置データ削除処理
        /// <summary>
        /// 孤立したローカル印字位置データを削除します
        /// </summary>
        /// <returns></returns>
        public int DeleteLonelyLocalData(out bool msgdiv,out string errmsg)
        {
            msgdiv = false;
            errmsg = string.Empty;
            int status = 0;
            List<string> delLs = new List<string>();

            // ローカルデータ削除
            foreach (SFANL08230AF userPrtPosSet in this._localPrtPosSet_SortedList.Values)
            {
                string offerKey = MakeKeyForHashtable(userPrtPosSet.OutputFormFileName, userPrtPosSet.UserPrtPprIdDerivNo);
                if (!_serverPrtPosSet_SortedList.Contains(offerKey))
                {
                    status = _localPrtPosSetDBAcs.DeleteLocalFrePrtPSet(userPrtPosSet.EnterpriseCode, userPrtPosSet.OutputFormFileName, userPrtPosSet.UserPrtPprIdDerivNo);
                    if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                    {
                        msgdiv = true;
                        errmsg = _localPrtPosSetDBAcs.ErrorMessage;
                        return status;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        delLs.Add(offerKey);
                    }
                }
            }
            // メモリキャッシュ削除
            foreach (string delkey in delLs)
            {
                _localPrtPosSet_SortedList.Remove(delkey);
            }

            return status;
        }
        #endregion

        #region 印字位置設定DB取得処理
        /// <summary>
		/// 印字位置設定DB取得処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 印字位置設定DBを取得します</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public int ReadDBData(out string errmsg)
		{
			int status;
			
			// 印字位置設定(ユーザーDB)ＤＢ読込み
			ArrayList offerList;
			status = this.ReadDBData_OfferPrtPosSet(out offerList, out errmsg);
			if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
				(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
				(status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_ERROR))
			{
			}
			else
			{
				return status;
			}

			// 印字位置設定(ローカルXML)ＤＢ読込み
			ArrayList userList;
			status = this.ReadLocalFrePrtPSet(out userList, out errmsg);
			if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
				(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
				(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
			{
			}
			else
			{
				return status;
			}
			
			this._serverPrtPosSet_SortedList	= this.MakeSortedList_OfferPrtPosSet(offerList);
			this._localPrtPosSet_SortedList		= this.MakeSortedList_UserPrtPosSet(userList);
			
			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        #endregion

        #region 印字位置設定DB更新処理
        /// <summary>
		/// 印字位置設定DB更新処理
		/// </summary>
		/// <param name="errmsg">エラーメッセージ</param>
		/// <param name="downLoadCount">ダウンロード件数</param>
		/// <param name="updateCount">上書き件数</param>
		/// <remarks>
		/// <br>Note		: ローカル印字位置設定DBを更新します</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public int WriteDBData(out string errmsg, out int downLoadCount, out int updateCount)
		{
			errmsg = string.Empty;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			downLoadCount			= 0;
			updateCount				= 0;

            FrePrtPSet frePrtPSet = null;
            List<FrePprECnd> frePprECndLs = null;
            List<FrePprSrtO> frePprSrtOLs = null;
            string msgBuf = string.Empty;
            try
            {
                foreach (DictionaryEntry de in this._localPrtPosSet_SortedList)
                {
                    SFANL08230AF downLoadPrtPosSet = (SFANL08230AF)de.Value;
                    if (downLoadPrtPosSet.UpdateFlag == UPDATEFLG_NONE) { continue; }
                    frePrtPSet = null;

                    // ローカルデータ読込み(背景画像取得有り)
                    status = this.ReadDB_UserFrePrtPSetWork(out frePrtPSet, out frePprECndLs, out frePprSrtOLs, downLoadPrtPosSet, out msgBuf);


                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        if (errmsg != string.Empty) errmsg += "\n";
                        errmsg += "[" + downLoadPrtPosSet.DisplayName + "," + downLoadPrtPosSet.PrtPprUserDerivNoCmt + "]が見つかりません\n" + "すでに他端末より削除されています";
                        continue;
                    }

                    // ローカル更新(背景画像更新有り)
                    status = this._localPrtPosSetDBAcs.WriteLocalFrePrtPSet(frePrtPSet, frePprECndLs, frePprSrtOLs);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        downLoadCount++;
                        if (downLoadPrtPosSet.UpdateFlag == UPDATEFLG_UPDATE)
                        {
                            updateCount++;
                        }

                        // 印字位置ダウンロード画面データクラス(ローカルXML)の更新
                        this.CopyToOfferPrtPosSetFromFrePrtPSet(ref downLoadPrtPosSet, frePrtPSet);
                        downLoadPrtPosSet.UpdateFlag = UPDATEFLG_NONE;
                        downLoadPrtPosSet.ExistingDataFlag = 1;

                        // 印字位置ダウンロード画面データクラス(ユーザーDB)の更新
                        string offerKey = MakeKeyForHashtable(frePrtPSet.OutputFormFileName, frePrtPSet.UserPrtPprIdDerivNo);
                        SFANL08230AF offerSFANL08230AF = (SFANL08230AF)this._serverPrtPosSet_SortedList[offerKey];
                        offerSFANL08230AF.UpdateFlag = UPDATEFLG_NONE;
                    }
                    else
                    {
                        errmsg += msgBuf +"\n";
                    }
                }
            }
            catch (Exception ex)
            {
                errmsg = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
			finally
			{
                if (errmsg != string.Empty) status = status = (Int32)ConstantManagement.DB_Status.ctDB_ERROR;
				this.SetDataTable_User(ref this._dataSet);
				this.SetDataTable_Offer(ref this._dataSet);
			}
			return status;
        }
        #endregion

        #region 印字位置設定Static取得処理
        /// <summary>
		/// 印字位置設定Static取得処理
		/// </summary>
		/// <param name="ds">データセット</param>
		/// <returns>ステータス(0:正常)</returns>
		/// <remarks>
		/// <br>Note		: 印字位置設定のStatic情報を取得します</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public void ReadStaticData(out DataSet ds)
		{
			this.SetDataTable_User(ref this._dataSet);
			this.SetDataTable_Offer(ref this._dataSet);
			ds = this._dataSet;
        }
        #endregion

        #region 印字位置設定(ローカルXML)ダウンロード警告存在確認処理
        /// <summary>
		/// 印字位置設定(ローカルXML)ダウンロード警告存在確認処理
		/// </summary>
		/// <param name="msg">メッセージ</param>
		/// <returns>チェック結果[true:警告あり,false:警告なし]</returns>
		/// <remarks>
		/// <br>Note		: 印字位置設定(ローカルXML)に警告するべきデータが存在するかどうか確認します</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public bool ExistsWarningData(out string msg)
		{
			msg = string.Empty;

			bool warningUpdate = false;
			bool warningMerge = false;

            foreach (SFANL08230AF user in this._localPrtPosSet_SortedList.Values)
            {
                // 更新なしの場合
                if (user.UpdateFlag == UPDATEFLG_NONE)
                {
                    continue;
                }

                // 新規追加の場合
                if (user.ExistingDataFlag == 0)
                {
                    continue;
                }

                // ローカルデータの取得
                string offerKey = MakeKeyForHashtable(user.OutputFormFileName, user.UserPrtPprIdDerivNo);

                if (!this._serverPrtPosSet_SortedList.Contains(offerKey))
                {
                    continue;
                }

                SFANL08230AF offer = (SFANL08230AF)this._serverPrtPosSet_SortedList[offerKey];

                // 上書き
                if (user.UpdateFlag == UPDATEFLG_UPDATE)
                {
                    // 印字位置バージョン
                    if (user.PrintPositionVer >= offer.PrintPositionVer)
                    {
                        warningUpdate = true;
                    }
                }

                if ((warningUpdate) && (warningMerge)) break;
            }
			if (warningUpdate)
			{
				msg += "すでに印字位置バージョンが最新になっているデータがあります。\n\r";
            }
            if ((warningUpdate) || (warningMerge))
			{
				msg += "\n\rこのまま更新してもよろしいですか？";
				return true;
			}
			return false;
        }
        #endregion

        #region 印字位置設定(ローカルXML)存在チェック処理
        /// <summary>
		/// 印字位置設定(ローカルXML)存在チェック処理
		/// </summary>
		/// <param name="outputFormFileName">出力ファイル名</param>
		/// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番号</param>
		/// <param name="prtPprUserDerivNoCmt">帳票ユーザー枝番コメント</param>
		/// <returns>チェック結果[0:重複なし,1:重複あり(ユーザー帳票ID枝番号),2:重複あり(帳票ユーザー枝番コメント)]</returns>
		/// <remarks>
		/// <br>Note		: 指定したキーのデータが画面上のローカルリストに存在するかを判定します</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public int ExistsUserPrtPosSet(string outputFormFileName, int userPrtPprIdDerivNo, string prtPprUserDerivNoCmt)
		{
            if (this._localPrtPosSet_SortedList.Contains(MakeKeyForHashtable(outputFormFileName, userPrtPprIdDerivNo)))
            {
                return 1;
            }
            else
            {
                // 帳票ユーザー枝番コメント
                foreach (SFANL08230AF userPrtPosSet in _localPrtPosSet_SortedList.Values)
                {
                    if (userPrtPosSet.PrtPprUserDerivNoCmt == prtPprUserDerivNoCmt)
                    {
                        return 2;
                    }
                }
            }
			return 0;
        }
        #endregion

        #region 印字位置設定(ローカル)選択処理
        /// <summary>
		/// 印字位置設定(ローカル)選択処理
		/// </summary>
		/// <param name="keys">対象の印字位置設定情報のKEYの配列</param>
		/// <param name="update">上書き(0:選択なし,1:選択あり)</param>
		/// <remarks>
		/// <br>Note		: 印字位置設定(ローカルXML)を選択・選択解除した時の反映処理を行います</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public void ChangeSelect_User(string[] keys, int update)
		{
			for (int ix = 0; ix < keys.Length; ix++)
			{
				string userKey = keys[ix];

				DataRow dr = this.GetDataRow_User(userKey);
				if (dr == null)
				{
					continue;
				}

				SFANL08230AF userPrtPosSet;
				string outputFormFileName	= (string)dr[COL_USER_OUTPUTFORMFILENAME].ToString();
                int userPrtPprIdDerivNo		= ConvertToInt32(dr[COL_USER_USERPRTPPRIDDERIVNO]);

				// ソートリスト(ローカル)よりデータを取得
				this.GetUserSFANL08230AF(out userPrtPosSet, outputFormFileName, userPrtPprIdDerivNo);
				if (userPrtPosSet == null)
				{
					continue;
				}

				if (update == 1)
				{
					if (userPrtPosSet.ExistingDataFlag == 0)
					{
						continue;
					}
					userPrtPosSet.UpdateFlag = UPDATEFLG_UPDATE;
					this.AddUserDataTable(userKey, userPrtPosSet);
				}
                else
                {
					if (userPrtPosSet.ExistingDataFlag == 0)
					{
						_localPrtPosSet_SortedList.Remove(MakeKeyForHashtable(userPrtPosSet.OutputFormFileName,userPrtPosSet.UserPrtPprIdDerivNo));
						this._dataSet.Tables[TABLE_USER].Rows.Remove(dr);
					}
					else
					{
						userPrtPosSet.UpdateFlag = UPDATEFLG_NONE;
						this.AddUserDataTable(userKey, userPrtPosSet);
					}
				}
            }
            // ここからローカルデータの選択状態を操作

			// ソートリスト(ローカルデータ)を検索
			foreach (DictionaryEntry de in this._serverPrtPosSet_SortedList)
			{
				SFANL08230AF offer = (SFANL08230AF)de.Value;
                string offerKey = offer.KeyNo;
				SFANL08230AF userPrtPosSet;

				// ソートリスト(ローカル)よりデータを取得
				this.GetUserSFANL08230AF(out userPrtPosSet, offer.OutputFormFileName, offer.UserPrtPprIdDerivNo);

				bool isHit = false;

                if (userPrtPosSet != null)
                {
                    // 選択されているものがあるか検索
                    if (userPrtPosSet.UpdateFlag != UPDATEFLG_NONE)
                    {
                        isHit = true;
                    }
                }

				if (isHit)
				{
					offer.UpdateFlag = UPDATEFLG_UPDATE;
				}
				else
				{
					offer.UpdateFlag = UPDATEFLG_NONE;
				}

				// ローカルデータテーブル検索
				DataRow offerDataRow = GetDataRow_Offer(offerKey);
				if (offerDataRow != null)
				{
					if (isHit)
					{
						offerDataRow[COL_OFFER_SELECT] = 1;
					}
					else
					{
						offerDataRow[COL_OFFER_SELECT] = 0;
					}
				}

			}
        }
        #endregion

        #region 印字位置設定(ユーザーDB)選択処理
        /// <summary>
		/// 印字位置設定(ユーザーDB)選択処理
		/// </summary>
		/// <param name="keys">対象の印字位置設定情報のKEYの配列</param>
		/// <param name="isSelect">選択有無</param>
		/// <remarks>
		/// <br>Note		: 印字位置設定(ユーザーDB)を選択・選択解除した時の反映処理を行います</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public void ChangeSelect_Offer(string[] keys, bool isSelect)
		{
			for (int ix = 0; ix < keys.Length; ix++)
			{
				string offerKey = keys[ix];

				// ローカルデータソートリストに無い場合
				if (!this._serverPrtPosSet_SortedList.Contains(offerKey))
				{
					continue;
				}

				SFANL08230AF offerPrtPosSet = (SFANL08230AF)this._serverPrtPosSet_SortedList[offerKey];

				// ローカルデータテーブルに無い場合
				DataRow offerDataRow = GetDataRow_Offer(offerKey);
				if (offerDataRow == null)
				{
					continue;
				}

				if (isSelect)
				{
					offerPrtPosSet.UpdateFlag = UPDATEFLG_UPDATE;
					offerDataRow[COL_OFFER_SELECT] = 1;
				}
				else
				{
					offerPrtPosSet.UpdateFlag = UPDATEFLG_NONE;
					offerDataRow[COL_OFFER_SELECT] = 0;
				}


				// ローカルデータに反映
				SFANL08230AF userPrtPosSet;

				// ソートリスト(ローカル)よりデータを取得
				this.GetUserSFANL08230AF(out userPrtPosSet, offerPrtPosSet.OutputFormFileName, offerPrtPosSet.UserPrtPprIdDerivNo);

				// 新規追加
                if (userPrtPosSet == null)
                {
                    if (isSelect)
                    {
                        if (!_localPrtPosSet_SortedList.Contains(MakeKeyForHashtable(offerPrtPosSet.OutputFormFileName, 0)))
                        {
                            SFANL08230AF user = offerPrtPosSet.Clone();
                            user.UpdateFlag = UPDATEFLG_UPDATE;
                            user.ExistingDataFlag = 0;
                            user.KeyNo = MakeKeyForHashtable(user.OutputFormFileName, user.UserPrtPprIdDerivNo);
                            if (!this._localPrtPosSet_SortedList.Contains(MakeKeyForHashtable(offerPrtPosSet.OutputFormFileName, user.UserPrtPprIdDerivNo)))
                            {
                                this._localPrtPosSet_SortedList.Add(MakeKeyForHashtable(offerPrtPosSet.OutputFormFileName, offerPrtPosSet.UserPrtPprIdDerivNo), user);
                            }
                            this.AddUserDataTable(user.KeyNo, user);
                        }
                    }
                }
                // 更新
                else
                {
                    if (isSelect)
                    {
                        userPrtPosSet.UpdateFlag = UPDATEFLG_UPDATE;
                        this.AddUserDataTable(userPrtPosSet.KeyNo, userPrtPosSet);
                    }
                    else
                    {
                        if (userPrtPosSet.ExistingDataFlag == 0)
                        {
                            DataTable dt = this._dataSet.Tables[TABLE_USER];
                            DataRow dr = this.GetDataRow_User(userPrtPosSet.KeyNo);
                            dt.Rows.Remove(dr);

                            _localPrtPosSet_SortedList.Remove(MakeKeyForHashtable(userPrtPosSet.OutputFormFileName, userPrtPosSet.UserPrtPprIdDerivNo));
                        }
                        else
                        {
                            userPrtPosSet.UpdateFlag = UPDATEFLG_NONE;
                            this.AddUserDataTable(userPrtPosSet.KeyNo, userPrtPosSet);
                        }
                    }
                }
			}
        }
        #endregion

        #region 印字位置設定(ユーザーDB)→ユーザー枝番追加処理
        /// <summary>
		/// 印字位置設定(ユーザーDB)→ユーザー枝番追加処理
		/// </summary>
		/// <param name="offerKey">追加対象の印字位置設定情報のKEY</param>
		/// <param name="userComment">ユーザーコメント</param>
		/// <remarks>
		/// <br>Note		: 印字位置設定(ユーザーDB)を追加選択した時の反映処理を行います</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public void AddCustomUserFromOffer(string offerKey, string userComment)
		{
			// ローカルデータソートリストに存在する場合
			if (this._serverPrtPosSet_SortedList.Contains(offerKey))
			{
				SFANL08230AF offerPrtPosSet = (SFANL08230AF)this._serverPrtPosSet_SortedList[offerKey];

				// ローカルデータテーブルに存在しない場合
				DataRow offerDataRow = GetDataRow_Offer(offerKey);
				if (offerDataRow == null)
				{
					return;
				}

				offerPrtPosSet.UpdateFlag = UPDATEFLG_UPDATE;
				offerDataRow[COL_OFFER_SELECT] = 1;


				// ローカルデータに反映
                SFANL08230AF userPrtPosSet;

				// ソートリスト(ローカル)よりデータを取得
				this.GetUserSFANL08230AF(out userPrtPosSet, offerPrtPosSet.OutputFormFileName, offerPrtPosSet.UserPrtPprIdDerivNo);

				// ユーザー枝番採番とユーザーコメント作成を行う
				int userDerivNo		= 1;

				// 同一帳票が存在する場合
                if (userPrtPosSet != null)
				{
					userDerivNo = this.Set_UserPrtPprIdDerivNo(_localPrtPosSet_SortedList, userDerivNo);
					userComment = this.Set_UserComment(_localPrtPosSet_SortedList, userComment);
				}

				// ローカルデータをベースとする
				userPrtPosSet = offerPrtPosSet.Clone();

				userPrtPosSet.UserPrtPprIdDerivNo	= userDerivNo;
				userPrtPosSet.PrtPprUserDerivNoCmt	= userComment;
				userPrtPosSet.UpdateFlag			= UPDATEFLG_UPDATE;
				userPrtPosSet.ExistingDataFlag		= 0;
				userPrtPosSet.KeyNo					= MakeKeyForHashtable(userPrtPosSet.OutputFormFileName, userPrtPosSet.UserPrtPprIdDerivNo);

                if (!this._localPrtPosSet_SortedList.Contains(MakeKeyForHashtable(offerPrtPosSet.OutputFormFileName,offerPrtPosSet.UserPrtPprIdDerivNo)))
				{
                    this._localPrtPosSet_SortedList.Add(MakeKeyForHashtable(offerPrtPosSet.OutputFormFileName ,offerPrtPosSet.UserPrtPprIdDerivNo), userPrtPosSet);
                    this.AddUserDataTable(userPrtPosSet.KeyNo, userPrtPosSet);
                }
			}
        }
        #endregion

        #region コンバート（double）処理
        /// <summary>
		/// コンバート（double）処理
		/// </summary>
		/// <param name="source">コンバート対象</param>
		/// <returns>コンバート結果</returns>
		/// <remarks>
		/// <br>Note		: オブジェクトをdouble型にコンバートします。コンバート出来ないオブジェクトの場合は０を返します。</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public static double ConvertToDouble(object source)
		{
			double dest = 0;
			try
			{
				dest = Convert.ToDouble(source);
			}
			catch
			{
				dest = 0;
			}
			return dest;
        }
        #endregion

        #region コンバート（double）処理 + 1
        /// <summary>
		/// コンバート（double）処理
		/// </summary>
		/// <param name="dest">コンバート結果</param>
		/// <param name="source">コンバート対象</param>
		/// <returns>true:成功 false:失敗</returns>
		/// <remarks>
		/// <br>Note		: オブジェクトをdouble型にコンバートします。</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public static bool ConvertToDouble(ref double dest, object source)
		{
			dest = 0;
			try
			{
				dest = Convert.ToDouble(source);
			}
			catch
			{
				return false;
			}
			return true;
        }
        #endregion

        #region コンバート（Int32）処理
        /// <summary>
		/// コンバート（Int32）処理
		/// </summary>
		/// <param name="dest">コンバート結果</param>
		/// <param name="source">コンバート対象</param>
		/// <returns>true:成功 false:失敗</returns>
		/// <remarks>
		/// <br>Note		: オブジェクトをInt32型にコンバートします。</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public static bool ConvertToInt32(ref Int32 dest, object source)
		{
			dest = 0;
			try
			{
				dest = Convert.ToInt32(source);
			}
			catch
			{
				return false;
			}
			return true;
        }
        #endregion

        #region コンバート（Int64）処理
        /// <summary>
		/// コンバート（Int64）処理
		/// </summary>
		/// <param name="source">コンバート対象</param>
		/// <returns>コンバート結果</returns>
		/// <remarks>
		/// <br>Note		: オブジェクトをInt64型にコンバートします。コンバート出来ないオブジェクトの場合は０を返します。</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public static Int64 ConvertToInt64(object source)
		{
			Int64 dest = 0;
			try
			{
				dest = Convert.ToInt64(source);
			}
			catch
			{
				dest = 0;
			}
			return dest;
        }
        #endregion

        #region コンバート（Int64）処理 + 1
        /// <summary>
		/// コンバート（Int64）処理
		/// </summary>
		/// <param name="dest">コンバート結果</param>
		/// <param name="source">コンバート対象</param>
		/// <returns>true:成功 false:失敗</returns>
		/// <remarks>
		/// <br>Note		: オブジェクトをInt64型にコンバートします。</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public static bool ConvertToInt64(ref Int64 dest, object source)
		{
			dest = 0;
			try
			{
				dest = Convert.ToInt64(source);
			}
			catch
			{
				return false;
			}
			return true;
        }
        #endregion

        #region　サーバー情報キャッシュ削除処理
        /// <summary>
        /// サーバー情報のキャッシュから指定したキーのデータを削除します
        /// </summary>
        /// <param name="key"></param>
        public void DeleteOfferCash(string key)
        {
            if (_serverPrtPosSet_SortedList.Contains(key))
            {
                _serverPrtPosSet_SortedList.Remove(key);
            }
        }
        #endregion

        #endregion

        #region Private Methods

        #region 印字位置設定(ユーザーDB)ＤＢ読込み処理
        /// <summary>
        /// 印字位置設定(ユーザーDB)ＤＢ読込み処理
		/// </summary>
		/// <param name="offerPrtPosSetList">取得した印字位置設定クラスリスト（ローカルデータ分）</param>
		/// <param name="errmsg">エラーメッセージ</param>
		/// <returns>作成したキー文字列</returns>
		/// <remarks>
		/// <br>Note		: 印字位置設定(ユーザーDB)ＤＢを読込みます。</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private int ReadDBData_OfferPrtPosSet(out ArrayList offerPrtPosSetList, out string errmsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			offerPrtPosSetList = new ArrayList();

			// ローカルデータ
			FrePrtPSetWork[] frePrtPSetWorks;
			status = this._userPrtPosSetDBAcs.Search(_enterpriseCode, string.Empty, out frePrtPSetWorks, 0, ConstantManagement.LogicalMode.GetData0, out errmsg);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				for (int ix = 0; ix < frePrtPSetWorks.Length; ix++)
				{
					SFANL08230AF offerPrtPosSet = new SFANL08230AF();
					this.CopyToOfferPrtPosSetFromWork(ref offerPrtPosSet, frePrtPSetWorks[ix]);
					offerPrtPosSetList.Add(offerPrtPosSet);
				}
			}

			return status;
        }
        #endregion

        /// <summary>
		/// 印字位置設定(ローカルXML)ＤＢ読込み処理
		/// </summary>
		/// <param name="userPrtPosSetList">取得した印字位置設定クラスリスト（ユーザー分）</param>
		/// <param name="errmsg">エラーメッセージ</param>
		/// <returns>作成したキー文字列</returns>
		/// <remarks>
		/// <br>Note		: 印字位置設定(ローカルXML)ＤＢを読込みます。</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private int ReadLocalFrePrtPSet(out ArrayList userPrtPosSetList, out string errmsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errmsg = "";

			userPrtPosSetList = new ArrayList();
			
            List<FrePrtPSet> frePrtPSetList = new List<FrePrtPSet>();
            List<FrePprECnd> frePprECndList = new List<FrePprECnd>();
            List<FrePprSrtO> frePprSrtOList = new List<FrePprSrtO>();

            status = this._localPrtPosSetDBAcs.SearchLocalFrePrtPSet(_enterpriseCode, 0,out frePrtPSetList, out frePprECndList, out frePprSrtOList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                foreach(FrePrtPSet frePrtPosSet in frePrtPSetList) 
                {
                    
                    SFANL08230AF userPrtPosSet = new SFANL08230AF();
                    this.CopyToOfferPrtPosSetFromFrePrtPSet(ref userPrtPosSet, frePrtPosSet);
                    userPrtPosSetList.Add(userPrtPosSet);
                }
			}

			return status;
		}
		
		/// <summary>
		/// ユーザー枝番採番処理
		/// </summary>
		/// <param name="sortedList">ユーザーリスト</param>
		/// <param name="defaultNo">初期値</param>
		/// <remarks>
		/// <br>Note		: ユーザー枝番採番を行います</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private int Set_UserPrtPprIdDerivNo(SortedList sortedList, int defaultNo)
		{
			int no = defaultNo;

			while (true)
			{
				bool isHit = false;
                foreach (SFANL08230AF user in sortedList.Values)
				{
					if (user.UserPrtPprIdDerivNo == no)
					{
						isHit = true;
						break;
					}
				}

				if (!isHit)	break;

				no++;
			}

			return no;
		}
		
		/// <summary>
		/// ユーザーコメント作成処理
		/// </summary>
		/// <param name="sortedList">ユーザーリスト</param>
		/// <param name="defaultCmt">コメント初期値</param>
		/// <remarks>
		/// <br>Note		: ユーザーコメント作成を行います</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private string Set_UserComment(SortedList sortedList, string defaultCmt)
		{
			int no = 0;
			string comment;

			// コメント初期値が設定されている場合
			if (defaultCmt.Trim() != string.Empty)
			{
				comment = defaultCmt;
			}
			else
			{
				no++;
				comment = "ローカル" + no.ToString();
			}

			while (true)
			{
				bool isHit = false;

                foreach (SFANL08230AF user in sortedList.Values)
				{
					if (user.PrtPprUserDerivNoCmt == comment)
					{
						isHit = true;
						break;
					}
				}

				if (!isHit)	break;

				no++;

				if (defaultCmt.Trim() != string.Empty)
				{
					comment = defaultCmt + no.ToString();
				}
				else
				{
					comment = "ローカル" + no.ToString();
				}
			}

			return comment;
		}
        
        /// <summary>
        ///  印字位置設定データ(ローカルXML)読込み処理
        /// </summary>
        /// <param name="userFrePrtPSet">印字位置設定データ</param>
        /// <param name="frePprECndLs">抽出条件</param>
        /// <param name="frePprSrtOLs">ソート順</param>
        /// <param name="errmsg">エラーメッセージ</param>
        /// <param name="downLoadPrtPosSet">印字位置ダウンロード画面データクラス</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印字位置設定データ(ローカルXML)のＤＢ読込み処理を行います</br>
        /// <br>Programmer	: 22011 柏原　頼人</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        private int ReadDB_UserFrePrtPSetWork(out FrePrtPSet userFrePrtPSet, out List<FrePprECnd> frePprECndLs, out List<FrePprSrtO> frePprSrtOLs, SFANL08230AF downLoadPrtPosSet, out string errmsg)
		{
            int status = 0;
            errmsg = "";

            // キーのみを設定
			userFrePrtPSet = new FrePrtPSet();
            userFrePrtPSet.EnterpriseCode       = downLoadPrtPosSet.EnterpriseCode;
            userFrePrtPSet.OutputFormFileName   = downLoadPrtPosSet.OutputFormFileName;
            userFrePrtPSet.UserPrtPprIdDerivNo  = downLoadPrtPosSet.UserPrtPprIdDerivNo;

            //DBから読込
            status = _frePrtPSetAcs.ReadDBFrePrtPSet(ref userFrePrtPSet, out frePprECndLs, out frePprSrtOLs);

			if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)||
				(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
			{
			}
			else
			{
                errmsg = _frePrtPSetAcs.ErrorMessage;
				throw new DownLoadPrtPosException(errmsg, status);
			}

			return status;
        }

		/// <summary>
		/// 印字位置設定(ローカルXML)ソートリスト作成処理
		/// </summary>
		/// <param name="list"></param>
		/// <returns>ソートリスト</returns>
		/// <remarks>
		/// <br>Note		: 印字位置設定(ローカルXML)マスタのソートリストを取得します。</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private SortedList MakeSortedList_UserPrtPosSet(ArrayList list)
		{
			SortedList sortedList = new SortedList();
			
			foreach (SFANL08230AF userPrtPosSet in list)
			{
                // 出力ファイル名がリストに存在しない場合作成
                if (!sortedList.Contains(MakeKeyForHashtable(userPrtPosSet.OutputFormFileName,userPrtPosSet.UserPrtPprIdDerivNo)))
				{
                    sortedList.Add(MakeKeyForHashtable(userPrtPosSet.OutputFormFileName,userPrtPosSet.UserPrtPprIdDerivNo), userPrtPosSet);
				}
			}
			
			return sortedList;
        }

        
        /// <summary>
		/// 印字位置設定クラス(ユーザーDB)→印字位置ダウンロード画面データクラス複製処理
		/// </summary>
		/// <param name="target">複製先の印字位置ダウンロード画面データクラス</param>
		/// <param name="source">複製元の印字位置設定クラス(ユーザーDB)</param>
		/// <remarks>
		/// <br>Note		: 印字位置設定クラス(ユーザーDB)の内容を印字位置ダウンロード画面データクラスに複製します</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private void CopyToOfferPrtPosSetFromWork(ref SFANL08230AF target, FrePrtPSetWork source)
        {
            target.CreateDateTime = source.CreateDateTime;
            target.UpdateDateTime = source.UpdateDateTime;
            target.EnterpriseCode = source.EnterpriseCode;
            target.FileHeaderGuid = source.FileHeaderGuid;
            target.UpdEmployeeCode = source.UpdEmployeeCode;
            target.UpdAssemblyId1 = source.UpdAssemblyId1;
            target.UpdAssemblyId2 = source.UpdAssemblyId2;
            target.LogicalDeleteCode = source.LogicalDeleteCode;
            target.OutputFormFileName = source.OutputFormFileName;
            target.UserPrtPprIdDerivNo = source.UserPrtPprIdDerivNo;
            target.PrintPaperUseDivcd = source.PrintPaperUseDivcd;
            target.PrintPaperDivCd = source.PrintPaperDivCd;
            target.ExtractionPgId = source.ExtractionPgId;
            target.ExtractionPgClassId = source.ExtractionPgClassId;
            target.OutputPgId = source.OutputPgId;
            target.OutputPgClassId = source.OutputPgClassId;
            target.OutConfimationMsg = source.OutConfimationMsg;
            target.DisplayName = source.DisplayName;
            target.PrtPprUserDerivNoCmt = source.PrtPprUserDerivNoCmt;
            target.PrintPositionVer = source.PrintPositionVer;
            target.MergeablePrintPosVer = source.MergeablePrintPosVer;
            target.DataInputSystem = source.DataInputSystem;
            target.OptionCode = source.OptionCode;
            target.FreePrtPprItemGrpCd = source.FreePrtPprItemGrpCd;
            target.PrtPprBgImageRowPos = source.PrtPprBgImageRowPos;
            target.PrtPprBgImageColPos = source.PrtPprBgImageColPos;
            target.TakeInImageGroupCd = source.TakeInImageGroupCd;
            target.PrintPosClassData = source.PrintPosClassData;
            target.FreePrtPprSpPrpseCd = source.FreePrtPprSpPrpseCd;
            target.TakeInImageGroupCd = source.TakeInImageGroupCd;
            target.KeyNo = MakeKeyForHashtable(target.OutputFormFileName, target.UserPrtPprIdDerivNo);
            target.UpdateFlag = UPDATEFLG_NONE;
            target.ExistingDataFlag = 1;
        }

        /// <summary>
        /// 印字位置設定クラス→印字位置設定ワーククラス 
        /// </summary>
        /// <param name="target">印字位置設定ワーククラス</param>
        /// <param name="source">印字位置設定クラス</param>
        /// <param name="enterpriseCode"></param>
        private void CopyToFrePrtPSetWorkFromFrePrtPSet(ref FrePrtPSetWork target, FrePrtPSet source, string enterpriseCode)
        {
            target.CreateDateTime = source.CreateDateTime;
            target.UpdateDateTime = source.UpdateDateTime;
            target.EnterpriseCode = source.EnterpriseCode;
            target.FileHeaderGuid = source.FileHeaderGuid;
            target.UpdEmployeeCode = source.UpdEmployeeCode;
            target.UpdAssemblyId1 = source.UpdAssemblyId1;
            target.UpdAssemblyId2 = source.UpdAssemblyId2;
            target.LogicalDeleteCode = source.LogicalDeleteCode;
            target.OutputFormFileName = source.OutputFormFileName;
            target.UserPrtPprIdDerivNo = source.UserPrtPprIdDerivNo;
            target.PrintPaperUseDivcd = source.PrintPaperUseDivcd;
            target.PrintPaperDivCd = source.PrintPaperDivCd;
            target.ExtractionPgId = source.ExtractionPgId;
            target.ExtractionPgClassId = source.ExtractionPgClassId;
            target.OutputPgId = source.OutputPgId;
            target.OutputPgClassId = source.OutputPgClassId;
            target.OutConfimationMsg = source.OutConfimationMsg;
            target.DisplayName = source.DisplayName;
            target.PrtPprUserDerivNoCmt = source.PrtPprUserDerivNoCmt;
            target.PrintPositionVer = source.PrintPositionVer;
            target.MergeablePrintPosVer = source.MergeablePrintPosVer;
            target.DataInputSystem = source.DataInputSystem;
            target.OptionCode = source.OptionCode;
            target.FreePrtPprItemGrpCd = source.FreePrtPprItemGrpCd;
            target.FormFeedLineCount = source.FormFeedLineCount;
            target.EdgeCharProcDivCd = source.EdgeCharProcDivCd;
            target.PrtPprBgImageRowPos = source.PrtPprBgImageRowPos;
            target.PrtPprBgImageColPos = source.PrtPprBgImageColPos;
            target.TakeInImageGroupCd = source.TakeInImageGroupCd;
            target.FreePrtPprSpPrpseCd = source.FreePrtPprSpPrpseCd;
            target.PrintPosClassData = source.PrintPosClassData;

        }

        /// <summary>
        /// 印字位置設定クラス(ユーザーDB)→印字位置ダウンロード画面データクラス複製処理
        /// </summary>
        /// <param name="target">複製先の印字位置ダウンロード画面データクラス</param>
        /// <param name="source">複製元の印字位置設定クラス(ユーザーDB)</param>
        /// <remarks>
        /// <br>Note		: 印字位置設定クラス(ユーザーDB)の内容を印字位置ダウンロード画面データクラスに複製します</br>
        /// <br>Programmer	: 22011 柏原　頼人</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        private void CopyToOfferPrtPosSetFromFrePrtPSet(ref SFANL08230AF target, FrePrtPSet source)
        {
            target.CreateDateTime = source.CreateDateTime;
            target.UpdateDateTime = source.UpdateDateTime;
            target.EnterpriseCode = source.EnterpriseCode;
            target.FileHeaderGuid = new Guid();
            target.UpdEmployeeCode = source.UpdEmployeeCode;
            target.UpdAssemblyId1 = source.UpdAssemblyId1;
            target.UpdAssemblyId2 = source.UpdAssemblyId2;
            target.LogicalDeleteCode = source.LogicalDeleteCode;
            target.OutputFormFileName = source.OutputFormFileName;
            target.UserPrtPprIdDerivNo = source.UserPrtPprIdDerivNo;
            target.PrintPaperUseDivcd = source.PrintPaperUseDivcd;
            target.PrintPaperDivCd = source.PrintPaperDivCd;
            target.ExtractionPgId = source.ExtractionPgId;
            target.ExtractionPgClassId = source.ExtractionPgClassId;
            target.OutputPgId = source.OutputPgId;
            target.OutputPgClassId = source.OutputPgClassId;
            target.OutConfimationMsg = source.OutConfimationMsg;
            target.DisplayName = source.DisplayName;
            target.PrtPprUserDerivNoCmt = source.PrtPprUserDerivNoCmt;
            target.PrintPositionVer = source.PrintPositionVer;
            target.MergeablePrintPosVer = source.MergeablePrintPosVer;
            target.DataInputSystem = source.DataInputSystem;
            target.OptionCode = source.OptionCode;
            target.FreePrtPprItemGrpCd = source.FreePrtPprItemGrpCd;
            target.PrtPprBgImageRowPos = source.PrtPprBgImageRowPos;
            target.PrtPprBgImageColPos = source.PrtPprBgImageColPos;
            target.PrintPosClassData = source.PrintPosClassData;
            target.TakeInImageGroupCd = source.TakeInImageGroupCd;
            target.FreePrtPprSpPrpseCd = source.FreePrtPprSpPrpseCd;
            target.KeyNo = MakeKeyForHashtable(target.OutputFormFileName, target.UserPrtPprIdDerivNo);
            target.UpdateFlag = UPDATEFLG_NONE;
            target.ExistingDataFlag = 1;
        }
        # endregion

        # region Private Class
        /// <summary>
		/// 印字位置ダウンロード画面アクセス例外処理クラス
		/// </summary>
		/// <remarks>
		/// <br>Note		: 印字位置ダウンロード画面アクセスクラスの例外処理クラスです。</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private class DownLoadPrtPosException : ApplicationException
		{
			/// <summary>
			/// 印字位置ダウンロード画面アクセス例外処理クラスコンストラクタ
			/// </summary>
			/// <remarks>
			/// <br>Note		: 使用するメンバの初期化を行います。</br>
			/// <br>Programmer	: 22011 柏原　頼人</br>
			/// <br>Date		: 2007.05.14</br>
			/// </remarks>
			public DownLoadPrtPosException(string message, int status): base(message)
			{
				_status = status;
			}

			/// <summary>ステータス</summary>
			private int _status;
		
			/// <summary>
			/// ステータス
			/// </summary>
			/// <returns>ステータス</returns>
			/// <remarks>
			/// <br>Note		: ステータスを取得します。</br>
			/// <br>Programmer	: 22011 柏原　頼人</br>
			/// <br>Date		: 2007.05.14</br>
			/// </remarks>
			public int Status
			{
				get {return _status;}
			}
		}
		# endregion
	}
}