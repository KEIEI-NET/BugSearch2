using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ユーザーガイドマスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ユーザーガイドマスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class UserGdSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private UserGuideAcs _userGuideAcs;
        

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// ユーザーガイドマスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : ユーザーガイドマスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public UserGdSetAcs()
		{
			
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
        /// ユーザーガイドヘッダ情報の取得
        /// </summary>
        /// <param name="retList"></param>
        /// <returns></returns>
        public int SearchHeader(out ArrayList retList)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }
            return this._userGuideAcs.SearchHeader(out retList);
        }

		/// <summary>
		/// ユーザーガイドマスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイドマスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, UserGdPrintWork userGdPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, userGdPrintWork);
		}

		/// <summary>
		/// ユーザーガイドマスタ検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイドマスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, UserGdPrintWork userGdPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, userGdPrintWork);
		}

		

		/// <summary>
		/// ユーザーガイドマスタ検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
        /// <param name="sectionPrintWork">抽出条件</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイドマスタの検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, UserGdPrintWork userGdPrintWork)
		{
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            int status = 0;
            int checkstatus = 0;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList userGdBd = null;

            // ユーザーガイド（ボディ）取得
            status = this._userGuideAcs.SearchAllBody(
                    out userGdBd,
                    enterpriseCode,
                    UserGuideAcsData.OfferDivCodeMergeBodyData);

            foreach (UserGdBd usergdbd in userGdBd)
            {
                if (usergdbd.UserGuideDivCd == userGdPrintWork.UserGuideDivCd)
                {
                    // 抽出処理
                    checkstatus = DataCheck(usergdbd, userGdPrintWork);
                    if (checkstatus == 0)
                    {

                        //ユーザーガイド情報クラスへメンバコピー
                        retList.Add(CopyToMakerSetFromSecInfoSetWork(usergdbd, enterpriseCode));

                    }
                }
            }

            //全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// クラスメンバーコピー処理（ユーザーガイドマスタワーククラス⇒ユーザーガイドマスタクラス）
        /// </summary>
        /// <param name="secInfoSetWork">ユーザーガイドマスタワーククラス</param>
        /// <returns>ユーザーガイドマスタクラス</returns>
        /// <remarks>
        /// <br>Note       : ユーザーガイドマスタワーククラスからユーザーガイドマスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private UserGdSet CopyToMakerSetFromSecInfoSetWork(UserGdBd usergdbd, string enterpriseCode)
        {

            UserGdSet userGdSet = new UserGdSet();

            userGdSet.GuideCode = usergdbd.GuideCode;
            userGdSet.GuideName = usergdbd.GuideName;

            return userGdSet;
        }


        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(UserGdBd usergdbd, UserGdPrintWork userGdPrintWork)
        {
            int status = 0;

            if (usergdbd.LogicalDeleteCode != userGdPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = usergdbd.UpdateDateTime.Year.ToString("0000") +
                                usergdbd.UpdateDateTime.Month.ToString("00") +
                                usergdbd.UpdateDateTime.Day.ToString("00");

            if (userGdPrintWork.LogicalDeleteCode == 1 &&
                userGdPrintWork.DeleteDateTimeSt != 0 &&
                userGdPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < userGdPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > userGdPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (userGdPrintWork.LogicalDeleteCode == 1 &&
                        userGdPrintWork.DeleteDateTimeSt != 0 &&
                        userGdPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < userGdPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (userGdPrintWork.LogicalDeleteCode == 1 &&
                userGdPrintWork.DeleteDateTimeSt == 0 &&
                userGdPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > userGdPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (userGdPrintWork.GuideCodeSt != 0 &&
                userGdPrintWork.GuideCodeEd != 0)
            {
                if (usergdbd.GuideCode < userGdPrintWork.GuideCodeSt ||
                   usergdbd.GuideCode > userGdPrintWork.GuideCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (userGdPrintWork.GuideCodeSt != 0)
            {
                if (usergdbd.GuideCode < userGdPrintWork.GuideCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (userGdPrintWork.GuideCodeEd != 0)
            {
                if (usergdbd.GuideCode > userGdPrintWork.GuideCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
