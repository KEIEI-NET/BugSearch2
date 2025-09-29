using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 自由帳票印字位置DLデータセット制御クラス
    /// </summary>
    abstract public class SFANL08230AB : SFANL08230AC
    {

        # region Constructor
		/// <summary>
		/// 印字位置ダウンロード画面アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note		: 自由帳票印字位置DLデータセット制御クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 22011 柏原　頼人</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
        public SFANL08230AB()
        {
            this._dataSet = new DataSet();
        }
        # endregion

        #region Private Members
        /// <summary>
        /// 印字位置設定情報データセット
        /// </summary>
        protected DataSet _dataSet = null;

        /// <summary>
        /// 印字位置設定（ユーザーDB）ソートリスト 
        /// </summary>
        protected SortedList _serverPrtPosSet_SortedList = null;

        /// <summary>
        /// 印字位置設定（ローカルXML）ソートリスト 
        /// </summary>
        protected SortedList _localPrtPosSet_SortedList = null;


        #endregion

        #region Public Methods

        #region コンバート（Int32）処理
        /// <summary>
        /// コンバート（Int32）処理
        /// </summary>
        /// <param name="source">コンバート対象</param>
        /// <returns>コンバート結果</returns>
        /// <remarks>
        /// <br>Note		: オブジェクトをInt32型にコンバートします。コンバート出来ないオブジェクトの場合は０を返します。</br>
        /// <br>Programmer	: 22011 柏原　頼人</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        public static Int32 ConvertToInt32(object source)
        {
            Int32 dest = 0;
            try
            {
                dest = Convert.ToInt32(source);
            }
            catch
            {
                dest = 0;
            }
            return dest;
        }
        #endregion

        #region 印字位置設定引当用キー文字列作成処理
        /// <summary>
        /// 印字位置設定引当用キー文字列作成処理
        /// </summary>
        /// <param name="outputFormFileName">出力ファイル名</param>
        /// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番号</param>
        /// <returns>作成したキー文字列</returns>
        /// <remarks>
        /// <br>Note		: 印字位置設定（ローカルXML）マスタのソートリストを取得します。</br>
        /// <br>Programmer	: 22011 柏原　頼人</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        public static string MakeKeyForHashtable(string outputFormFileName, int userPrtPprIdDerivNo)
        {
            return string.Format("{0},{1:D3}", outputFormFileName.Trim(), userPrtPprIdDerivNo);
        }
        #endregion

        #endregion

        #region Private Methods

        #region システム区分名称取得処理
        /// <summary>
        /// システム区分名称取得処理
        /// </summary>
        /// <param name="systemDivCd"></param>
        /// <returns></returns>
        private string GetSystemDivName(int systemDivCd)
        {
            string systemDivName = "その他";

            if (systemDivCd == 0) systemDivName = "共通";
            else if (systemDivCd == 1) systemDivName = "整備";
            else if (systemDivCd == 2) systemDivName = "鈑金";
            else if (systemDivCd == 3) systemDivName = "車販";

            return systemDivName;
        }
        #endregion

        #region 帳票使用区分名称取得
        /// <summary>
        /// 帳票使用区分名称取得
        /// </summary>
        /// <param name="printPaperUseDivcd"></param>
        /// <returns></returns>
        private string GetPrintPaperUserDivCdNm(int printPaperUseDivcd)
        {
            switch (printPaperUseDivcd)
            {
                case 1: return "帳票";
                case 2: return "伝票";
                case 3: return "ＤＭ一覧表";
                case 4: return "ＤＭはがき";
                default: return "";
            }
        }
        #endregion

        #region 未ダウンロードフラグ取得処理
        /// <summary>
        /// 未ダウンロードフラグ取得処理
        /// </summary>
        /// <param name="outputFormFileName">出力ファイル名</param>
        /// <param name="offerPrtPprIdDerivNo">提供帳票ID枝番号</param>
        /// <returns>未ダウンロードフラグ(0:ダウンロード済み,1:未ダウンロード)</returns>
        /// <remarks>
        /// <br>Note		: 指定の帳票の印字位置情報がユーザーデータにあるかどうかをチェックします</br>
        /// <br>Programmer	: 22011 柏原　頼人</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        private int GetFlag_NoDownLoad(string outputFormFileName, int offerPrtPprIdDerivNo)
        {
            SFANL08230AF userPrtPosSet;

            // ソートリスト(ユーザー)よりデータを取得
            this.GetUserSFANL08230AF(out userPrtPosSet, outputFormFileName, offerPrtPprIdDerivNo);
            if (userPrtPosSet == null)
            {
                return 1;
            }

            // 既存のものがあれば
            if (userPrtPosSet.ExistingDataFlag == 1)
            {
                return 0;
            }
            
            return 1;
        }
        #endregion

        #region 新規バージョンフラグ取得処理
        /// <summary>
        /// 新規バージョンフラグ取得処理
        /// </summary>
        /// <param name="outputFormFileName">出力ファイル名</param>
        /// <param name="offerPrtPprIdDerivNo">帳票ID枝番号</param>
        /// <param name="updateDateTime">更新日時</param>
        /// <returns>新規バージョンフラグ(0:新規バージョンではない,1:新規バージョンである)</returns>
        /// <remarks>
        /// <br>Note		: 指定の帳票のバージョンがローカルファイルよりも新しいかどうかをチェックします</br>
        /// <br>Programmer	: 22011 柏原　頼人</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        private int GetFlag_NewVersion(string outputFormFileName, int offerPrtPprIdDerivNo, DateTime updateDateTime)
        {
            SFANL08230AF userPrtPosSet;

            // ソートリスト(ユーザー)よりデータを取得
            this.GetUserSFANL08230AF(out userPrtPosSet, outputFormFileName, offerPrtPprIdDerivNo);
            if (userPrtPosSet == null)
            {
                return 1;
            }
            // 印字可能バージョン
            if (userPrtPosSet.UpdateDateTime < updateDateTime)
            {
                return 1;
            }

            return 0;
        }
        #endregion
  
        #endregion

        #region Protected Methods

        #region 印字位置（提供）データテーブル生成処理
        /// <summary>
        /// 印字位置（提供）データテーブル生成処理
        /// </summary>
        /// <param name="ds">データセット</param>
        /// <remarks>
        /// <br>Note		: 印字位置（提供）データテーブルを生成して返します</br>
        /// <br>Programmer	: 22011 柏原　頼人</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        protected void SetDataTable_Offer(ref DataSet ds)
        {
            DataTable dt = null;

            if (ds.Tables.Contains(TABLE_OFFER))
            {
                dt = ds.Tables[TABLE_OFFER];
                dt.Rows.Clear();
            }
            else
            {
                dt = new DataTable(TABLE_OFFER);
                dt.Columns.Add(COL_OFFER_SELECT, typeof(Int32));
                dt.Columns.Add(COL_OFFER_KEY, typeof(string));
                dt.Columns.Add(COL_OFFER_OUTPUTFORMFILENAME, typeof(string));
                dt.Columns.Add(COL_OFFER_DISPLAYNAME, typeof(string));
                dt.Columns.Add(COL_OFFER_USERPRTPPRIDDERIVNO, typeof(Int32));
                dt.Columns.Add(COL_OFFER_PRTPPRUSERDERIVNOCMT, typeof(string));
                dt.Columns.Add(COL_OFFER_PRINTPAPERUSEDIVCD, typeof(Int32));
                dt.Columns.Add(COL_OFFER_PRINTPAPERUSEDIVCDNM, typeof(string));
                dt.Columns.Add(COL_OFFER_TAKEINIMAGEGROUPCD, typeof(Guid));
                dt.Columns.Add(COL_OFFER_FREEPRTPPRITEMGRPCD, typeof(Int32));
                dt.Columns.Add(COL_OFFER_UPDATETIMESTR, typeof(string));
                dt.Columns.Add(COL_OFFER_UPDATETIME, typeof(DateTime));
                dt.Columns.Add(COL_OFFER_SYSTEMDIVCD, typeof(Int32));
                dt.Columns.Add(COL_OFFER_SYSTEMDIVNAME, typeof(string));
                dt.Columns.Add(COL_OFFER_OPTIONCODE, typeof(string));
                dt.Columns.Add(COL_OFFER_OPTIONNAME, typeof(string));
                dt.Columns.Add(COL_OFFER_NO_DOWNLOAD, typeof(Int32));
                dt.Columns.Add(COL_OFFER_NEW_VERSION, typeof(Int32));

                dt.Columns[COL_OFFER_SELECT].Caption = "選択";
                dt.Columns[COL_OFFER_KEY].Caption = "KEY";
                dt.Columns[COL_OFFER_OUTPUTFORMFILENAME].Caption = "出力ファイル名";
                dt.Columns[COL_OFFER_DISPLAYNAME].Caption = "帳票名称";
                dt.Columns[COL_OFFER_USERPRTPPRIDDERIVNO].Caption = "ユーザー帳票ID枝番号";
                dt.Columns[COL_OFFER_PRTPPRUSERDERIVNOCMT].Caption = "コメント";
                dt.Columns[COL_OFFER_FREEPRTPPRITEMGRPCD].Caption = "印字項目グループコード";
                dt.Columns[COL_OFFER_UPDATETIMESTR].Caption = "サーバー更新日時";
                dt.Columns[COL_OFFER_UPDATETIME].Caption = "サーバー更新日時";
                dt.Columns[COL_OFFER_SYSTEMDIVCD].Caption = "システム区分";
                dt.Columns[COL_OFFER_SYSTEMDIVNAME].Caption = "システム";
                dt.Columns[COL_OFFER_OPTIONCODE].Caption = "オプションコード";
                dt.Columns[COL_OFFER_OPTIONNAME].Caption = "オプション名称";
                dt.Columns[COL_OFFER_NO_DOWNLOAD].Caption = "未ダウンロード";
                dt.Columns[COL_OFFER_NEW_VERSION].Caption = "新バージョン";
                dt.Columns[COL_OFFER_PRINTPAPERUSEDIVCD].Caption = "帳票使用区分コード";
                dt.Columns[COL_OFFER_PRINTPAPERUSEDIVCDNM].Caption = "帳票使用区分";
                dt.Columns[COL_OFFER_TAKEINIMAGEGROUPCD].Caption = "取込画像コード";
                ds.Tables.Add(dt);
            }

            if (dt != null)
            {
                if (this._serverPrtPosSet_SortedList != null)
                {
                    if (this._serverPrtPosSet_SortedList.Count > 0)
                    {
                        foreach (SFANL08230AF offerPrtPosSet in this._serverPrtPosSet_SortedList.Values)
                        {
                            string offerKey = MakeKeyForHashtable(offerPrtPosSet.OutputFormFileName, offerPrtPosSet.UserPrtPprIdDerivNo);

                            DataRow dr = dt.NewRow();
                            dr[COL_OFFER_SELECT] = offerPrtPosSet.UpdateFlag;
                            dr[COL_OFFER_KEY] = offerKey;
                            dr[COL_OFFER_OUTPUTFORMFILENAME] = offerPrtPosSet.OutputFormFileName;
                            dr[COL_OFFER_USERPRTPPRIDDERIVNO] = offerPrtPosSet.UserPrtPprIdDerivNo;
                            dr[COL_OFFER_DISPLAYNAME] = offerPrtPosSet.DisplayName;
                            dr[COL_OFFER_PRTPPRUSERDERIVNOCMT] = offerPrtPosSet.PrtPprUserDerivNoCmt;
                            dr[COL_OFFER_FREEPRTPPRITEMGRPCD] = offerPrtPosSet.FreePrtPprItemGrpCd;
                            dr[COL_OFFER_UPDATETIMESTR] = offerPrtPosSet.UpdateDateTime.ToString("yyyy.MM.dd HH:mm:ss");
                            dr[COL_OFFER_UPDATETIME] = offerPrtPosSet.UpdateDateTime;
                            dr[COL_OFFER_SYSTEMDIVCD] = offerPrtPosSet.DataInputSystem;
                            dr[COL_OFFER_SYSTEMDIVNAME] = this.GetSystemDivName(offerPrtPosSet.DataInputSystem);
                            dr[COL_OFFER_OPTIONCODE] = offerPrtPosSet.OptionCode;
                            dr[COL_OFFER_OPTIONNAME] = string.Empty;
                            dr[COL_OFFER_NO_DOWNLOAD] = this.GetFlag_NoDownLoad(offerPrtPosSet.OutputFormFileName, offerPrtPosSet.UserPrtPprIdDerivNo);
                            dr[COL_OFFER_NEW_VERSION] = this.GetFlag_NewVersion(offerPrtPosSet.OutputFormFileName, offerPrtPosSet.UserPrtPprIdDerivNo,
                                offerPrtPosSet.UpdateDateTime);
                            dr[COL_OFFER_PRINTPAPERUSEDIVCD] = offerPrtPosSet.PrintPaperUseDivcd;
                            dr[COL_OFFER_PRINTPAPERUSEDIVCDNM] = GetPrintPaperUserDivCdNm(offerPrtPosSet.PrintPaperUseDivcd);
                            dr[COL_OFFER_TAKEINIMAGEGROUPCD] = offerPrtPosSet.TakeInImageGroupCd;
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
        }
        #endregion

        #region 印字位置（ユーザー）データテーブル生成処理
        /// <summary>
        /// 印字位置（ユーザー）データテーブル生成処理
        /// </summary>
        /// <param name="ds">データセット</param>
        /// <remarks>
        /// <br>Note		: 印字位置（ユーザー）データテーブルを生成して返します</br>
        /// <br>Programmer	: 22011 柏原　頼人</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        protected void SetDataTable_User(ref DataSet ds)
        {
            DataTable dt = null;

            if (ds.Tables.Contains(TABLE_USER))
            {
                dt = ds.Tables[TABLE_USER];
                dt.Rows.Clear();
            }
            else
            {
                dt = new DataTable(TABLE_USER);
                dt.Columns.Add(COL_USER_SELECT_UPDATE, typeof(Int32));
                dt.Columns.Add(COL_USER_EXISTFLG, typeof(Int32));
                dt.Columns.Add(COL_USER_UPDATEFLG, typeof(Int32));
                dt.Columns.Add(COL_USER_STATUS, typeof(string));
                dt.Columns.Add(COL_USER_KEY, typeof(string));
                dt.Columns.Add(COL_USER_OUTPUTFORMFILENAME, typeof(string));
                dt.Columns.Add(COL_USER_DISPLAYNAME, typeof(string));
                dt.Columns.Add(COL_USER_USERPRTPPRIDDERIVNO, typeof(Int32));
                dt.Columns.Add(COL_USER_PRTPPRUSERDERIVNOCMT, typeof(string));
                dt.Columns.Add(COL_USER_PRINTPAPERUSEDIVCD, typeof(Int32));
                dt.Columns.Add(COL_USER_PRINTPAPERUSEDIVCDNM, typeof(string));
                dt.Columns.Add(COL_USER_FREEPRTPPRITEMGRPCD, typeof(Int32));
                dt.Columns.Add(COL_USER_UPDATETIME, typeof(string));
                dt.Columns.Add(COL_USER_SYSTEMDIVCD, typeof(Int32));
                dt.Columns.Add(COL_USER_SYSTEMDIVNAME, typeof(string));
                dt.Columns.Add(COL_USER_OPTIONCODE, typeof(string));
                dt.Columns.Add(COL_USER_OPTIONNAME, typeof(string));
                
                dt.Columns[COL_USER_SELECT_UPDATE].Caption = "上書き";
                dt.Columns[COL_USER_EXISTFLG].Caption = "既存";
                dt.Columns[COL_USER_UPDATEFLG].Caption = "新規";
                dt.Columns[COL_USER_STATUS].Caption = "状態";
                dt.Columns[COL_USER_KEY].Caption = "KEY";
                dt.Columns[COL_USER_OUTPUTFORMFILENAME].Caption = "出力ファイル名";
                dt.Columns[COL_USER_DISPLAYNAME].Caption = "帳票名称";
                dt.Columns[COL_USER_USERPRTPPRIDDERIVNO].Caption = "ユーザー帳票ID枝番号";
                dt.Columns[COL_USER_PRTPPRUSERDERIVNOCMT].Caption = "コメント";
                dt.Columns[COL_USER_FREEPRTPPRITEMGRPCD].Caption = "印字項目グループコード";
                dt.Columns[COL_USER_UPDATETIME].Caption = "サーバー更新日時";
                dt.Columns[COL_USER_SYSTEMDIVCD].Caption = "システム区分";
                dt.Columns[COL_USER_SYSTEMDIVNAME].Caption = "システム";
                dt.Columns[COL_USER_OPTIONCODE].Caption = "オプションコード";
                dt.Columns[COL_USER_OPTIONNAME].Caption = "オプション名称";
                dt.Columns[COL_USER_PRINTPAPERUSEDIVCD].Caption = "帳票使用区分コード";
                dt.Columns[COL_USER_PRINTPAPERUSEDIVCDNM].Caption = "帳票使用区分";
                

                ds.Tables.Add(dt);
            }

            if (dt != null)
            {
                if (this._localPrtPosSet_SortedList != null)
                {
                    if (this._localPrtPosSet_SortedList.Count > 0)
                    {
                        foreach (SFANL08230AF userPrtPosSet in this._localPrtPosSet_SortedList.Values)
                        {
                            DataRow dr = dt.NewRow();
                            this.SetDataRow_UserPrtPosSet(ref dr, userPrtPosSet);
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
        }
        #endregion

        #region 印字位置設定 データ行取得処理
        /// <summary>
        /// 印字位置設定（ローカルXML）データ行取得処理
        /// </summary>
        /// <param name="key">キー</param>
        /// <remarks>
        /// <br>Note		: 指定したキーより印字位置設定（ローカルXML）データテーブルの行を取得します</br>
        /// <br>Programmer	: 22011 柏原　頼人</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        protected DataRow GetDataRow_User(string key)
        {
            DataRow dataRow = null;
            DataTable dt = this._dataSet.Tables[TABLE_USER];
            DataRow[] drs = dt.Select(COL_USER_KEY + "='" + key + "'");
            if (drs.Length > 0)
            {
                dataRow = drs[0];
            }
            return dataRow;
        }

        /// <summary>
        /// 印字位置設定（ユーザーDB）データ行取得処理
        /// </summary>
        /// <param name="key">キー</param>
        /// <remarks>
        /// <br>Note		: 指定したキーより印字位置設定（ユーザーDB）データテーブルの行を取得します</br>
        /// <br>Programmer	: 22011 柏原　頼人</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        protected DataRow GetDataRow_Offer(string key)
        {
            DataRow dataRow = null;
            DataTable dt = this._dataSet.Tables[TABLE_OFFER];
            DataRow[] drs = dt.Select(COL_OFFER_KEY + "='" + key + "'");
            if (drs.Length > 0)
            {
                dataRow = drs[0];
            }
            return dataRow;
        }
            #endregion

        #region 印字位置設定（ユーザーDB）ソートリスト取得処理
        /// <summary>
        /// 印字位置設定（ユーザーDB）ソートリスト取得処理
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ソートリスト</returns>
        /// <remarks>
        /// <br>Note		: 印字位置設定（ユーザーDB）マスタのソートリストを取得します。</br>
        /// <br>Programmer	: 22011 柏原　頼人</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        protected SortedList MakeSortedList_OfferPrtPosSet(ArrayList list)
        {
            SortedList sortedList = new SortedList();

            foreach (SFANL08230AF offerPrtPosSet in list)
            {
                string key = MakeKeyForHashtable(offerPrtPosSet.OutputFormFileName, offerPrtPosSet.UserPrtPprIdDerivNo);
                sortedList.Add(key, offerPrtPosSet);
            }

            return sortedList;
        }
        #endregion

        #region 印字位置（ユーザー）データテーブル行内容セット処理
        /// <summary>
        /// 印字位置（ユーザー）データテーブル行内容セット処理
        /// </summary>
        /// <param name="dr">更新対象行</param>
        /// <param name="userPrtPosSet">追加対象の印字位置ダウンロード画面データクラス（ユーザー）</param>
        /// <remarks>
        /// <br>Note		: 印字位置（提供）データテーブルを生成して返します</br>
        /// <br>Programmer	: 22011 柏原　頼人</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        protected void SetDataRow_UserPrtPosSet(ref DataRow dr, SFANL08230AF userPrtPosSet)
        {
            string status = string.Empty;

            if (userPrtPosSet.ExistingDataFlag == 1)
            {
                if (userPrtPosSet.UpdateFlag == UPDATEFLG_UPDATE)
                {
                    status = "上書き";
                }
                else
                {
                    status = "既存";
                }
            }
            else
            {
                status = "新規";
            }

            if (userPrtPosSet.UpdateFlag == UPDATEFLG_NONE)
            {
                dr[COL_USER_SELECT_UPDATE] = 0;
            }
            else if (userPrtPosSet.UpdateFlag == UPDATEFLG_UPDATE)
            {
                dr[COL_USER_SELECT_UPDATE] = 1;
            }
            dr[COL_USER_UPDATEFLG] = userPrtPosSet.UpdateFlag;
            dr[COL_USER_EXISTFLG] = userPrtPosSet.ExistingDataFlag;

            dr[COL_USER_STATUS] = status;
            dr[COL_USER_KEY] = userPrtPosSet.KeyNo;
            dr[COL_USER_OUTPUTFORMFILENAME] = userPrtPosSet.OutputFormFileName;
            dr[COL_USER_USERPRTPPRIDDERIVNO] = userPrtPosSet.UserPrtPprIdDerivNo;
            dr[COL_USER_DISPLAYNAME] = userPrtPosSet.DisplayName;
            dr[COL_USER_PRTPPRUSERDERIVNOCMT] = userPrtPosSet.PrtPprUserDerivNoCmt;
            dr[COL_USER_FREEPRTPPRITEMGRPCD] = userPrtPosSet.FreePrtPprItemGrpCd;
            dr[COL_USER_UPDATETIME] = userPrtPosSet.UpdateDateTime.ToString("yyyy.MM.dd HH:mm:ss");
            dr[COL_USER_SYSTEMDIVCD] = userPrtPosSet.DataInputSystem;
            dr[COL_USER_SYSTEMDIVNAME] = this.GetSystemDivName(userPrtPosSet.DataInputSystem);
            dr[COL_USER_OPTIONCODE] = userPrtPosSet.OptionCode;
            dr[COL_USER_OPTIONNAME] = string.Empty;
            dr[COL_USER_PRINTPAPERUSEDIVCD] = userPrtPosSet.PrintPaperUseDivcd;
            dr[COL_USER_PRINTPAPERUSEDIVCDNM] = GetPrintPaperUserDivCdNm(userPrtPosSet.PrintPaperUseDivcd);
        }
        #endregion

        #region 印字位置ダウンロード画面データクラス（ユーザー）取得処理
        /// <summary>
        /// 印字位置ダウンロード画面データクラス（ユーザー）取得処理
        /// </summary>
        /// <param name="userSFANL08230AF">取得した印字位置ダウンロード画面データクラス</param>
        /// <param name="outputFormFileName">出力ファイル名</param>
        /// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番号</param>
        /// <returns>取得した印字位置ダウンロード画面データクラス</returns>
        /// <remarks>
        /// <br>Note		: 指定したパラメータよりソートリストから印字位置ダウンロードデータクラス（ユーザー）を取得します。
        ///					  存在しない場合はnullが返ります</br>
        /// <br>Programmer	: 22011 柏原　頼人</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        protected void GetUserSFANL08230AF(out SFANL08230AF userSFANL08230AF,string outputFormFileName, int userPrtPprIdDerivNo)
        {
            userSFANL08230AF = null;
            //キャッシュに存在するか
            if (this._localPrtPosSet_SortedList.Contains(MakeKeyForHashtable(outputFormFileName ,userPrtPprIdDerivNo)))
            {
                userSFANL08230AF = (SFANL08230AF)_localPrtPosSet_SortedList[MakeKeyForHashtable(outputFormFileName ,userPrtPprIdDerivNo)];
            }
        }
        #endregion

        #region 印字位置設定（ローカルXML）データテーブル追加処理
        /// <summary>
        /// 印字位置設定（ローカルXML）データテーブル追加処理
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="userPrtPosSet">追加対象の印字位置設定（ローカルXML）</param>
        /// <remarks>
        /// <br>Note		: 印字位置設定（ローカルXML）データテーブルに新しい印字位置設定（ローカルXML）情報を追加します。
        ///					  既にキーが存在する場合は更新します</br>
        /// <br>Programmer	: 22011 柏原　頼人</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        protected void AddUserDataTable(string key, SFANL08230AF userPrtPosSet)
        {
            DataRow dr = this.GetDataRow_User(key);

            if (dr == null)
            {
                DataTable dt = this._dataSet.Tables[TABLE_USER];
                dr = dt.NewRow();
                this.SetDataRow_UserPrtPosSet(ref dr, userPrtPosSet);
                dt.Rows.Add(dr);
            }
            else
            {
                this.SetDataRow_UserPrtPosSet(ref dr, userPrtPosSet);
            }
        }
        #endregion

        #endregion
    }
}
