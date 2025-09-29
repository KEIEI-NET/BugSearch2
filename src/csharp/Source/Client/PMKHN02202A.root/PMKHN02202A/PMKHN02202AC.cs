using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// メニュー制御設定テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : メニュー制御設定テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30747 三戸 伸悟</br>
	/// <br>Date       : 2013/02/15</br>
	/// <br></br>
    /// </remarks>
	public class MenueStSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private IMenueStDB _menuStDB;
        

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// メニュー制御設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : メニュー制御設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30747 三戸 伸悟</br>
        /// <br>Date       : 2013/02/15</br>
        /// </remarks>
        public MenueStSetAcs()
		{
            try
            {
                // リモートオブジェクト取得
                this._menuStDB = (IMenueStDB)MediationMenueStDB.GetMenueStDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._menuStDB = null;
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
        /// メニュー制御設定全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="menueStPrintWork"></param>
        /// <remarks>
        /// <br>Note       : メニュー制御設定の全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 30747 三戸 伸悟</br>
        /// <br>Date       : 2013/02/15</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, MenueStPrintWork menueStPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, menueStPrintWork);
		}

        /// <summary>
        /// メニュー制御設定検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="menueStPrintWork"></param>
        /// <remarks>
        /// <br>Note       : メニュー制御設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 30747 三戸 伸悟</br>
        /// <br>Date       : 2013/02/15</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, MenueStPrintWork menueStPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, menueStPrintWork);
		}

		

		/// <summary>
		/// メニュー制御設定検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
        /// <param name="menueStPrintWork">抽出条件</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : メニュー制御設定の検索処理を行います。</br>
		/// <br>Programmer : 30747 三戸 伸悟</br>
        /// <br>Date       : 2013/02/15</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, MenueStPrintWork menueStPrintWork)
		{
            if (this._menuStDB == null)
            {
                this._menuStDB = (IMenueStDB)MediationMenueStDB.GetMenueStDB();
            }

            int status = 0;
            //int checkstatus = 0;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            object menueStBd = null;

            // ユーザーガイド（ボディ）取得
            status = this._menuStDB.Search(out menueStBd, enterpriseCode, menueStPrintWork.SortCode);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = menueStBd as ArrayList;

                foreach (MenueStWork menueStbd in workList)
                {
                    // 抽出処理
                    if (menueStPrintWork.EmployeeCodeSt != "")
                    {
                        if (menueStbd.EmployeeCode.Trim().CompareTo(menueStPrintWork.EmployeeCodeSt) < 0) continue;
                    }
                    if (menueStPrintWork.EmployeeCodeEd != "")
                    {
                        if (menueStbd.EmployeeCode.Trim().CompareTo(menueStPrintWork.EmployeeCodeEd) > 0) continue;
                    }

                    retList.Add(CopyToMakerSetFromSecInfoSetWork(menueStbd));
                }

                //全件リードの場合は戻り値の件数をセット
                if (readCnt == 0) retTotalCnt = retList.Count;
            }
				
			return status;
		}

        /// <summary>
        /// クラスメンバーコピー処理（メニュー制御設定ワーククラス⇒メニュー制御設定クラス）
        /// </summary>
        /// <param name="menueStbd">メニュー制御設定ワーククラス</param>
        /// <returns>メニュー制御設定クラス</returns>
        /// <remarks>
        /// <br>Note       : メニュー制御設定ワーククラスからメニュー制御設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30747 三戸 伸悟</br>
        /// <br>Date       : 2013/02/15</br>
        /// </remarks>
        private MenueStSet CopyToMakerSetFromSecInfoSetWork(MenueStWork menueStbd)
        {

            MenueStSet menueStSet = new MenueStSet();

            menueStSet.EnterpriseCode = menueStbd.EnterpriseCode;       // 企業コード
            menueStSet.RoleGroupCode = menueStbd.RoleGroupCode;         // ロールグループコード
            menueStSet.RoleGroupName = menueStbd.RoleGroupName;         // ロールグループ名称
            menueStSet.RoleCategoryId = menueStbd.RoleCategoryId;       // カテゴリ
            menueStSet.RoleCategorySubId = menueStbd.RoleCategorySubId; // サブカテゴリ
            menueStSet.RoleItemId = menueStbd.RoleItemId;               // アイテム
            menueStSet.SystemName = menueStbd.SystemName;               // システム機能名称
            menueStSet.EmployeeCode = menueStbd.EmployeeCode;           // 従業員コード
            menueStSet.EmployeeName = menueStbd.EmployeeName;           // 従業員名称

            return menueStSet;
        }

    }
}
