using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;
// 2008.02.08 96012 ローカルＤＢ参照対応 Begin
using Broadleaf.Application.LocalAccess;
// 2008.02.08 96012 ローカルＤＢ参照対応 end

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// メーカーアクセスクラス
    /// </summary>
    /// <remarks>
    /// Note       : メーカー情報を取得するためのアクセスクラスです。<br />
    /// Programmer : 96186 立花裕輔<br />
    /// Date       : 2007.08.01<br />
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
    /// <br>           : ローカルＤＢ参照対応</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.20 30167　上野　弘貴</br>
	/// <br>           : ガイド表記修正（MAKERGUIDE.XMLも修正）</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.28 96012　日色 馨</br>
    /// <br>           : 提供分はローカルＤＢへのアクセスのみ</br>
    /// -----------------------------------------------------------------------
    /// <br>Update Note: 2008.06.11 30413 犬飼</br>
    /// <br>           : PM.NS対応</br>
    /// <br>           : ユーザＤＢの読込エラー時は提供ＤＢの読込を行わないように変更</br>
    /// <br>           : 提供ＤＢ（部品メーカー名称マスタ）のリモートアクセスに対応</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2020.02.27 31739　岸</br>
    /// <br>           : ハンディ常駐PGからの呼出メソッドを追加</br>
    /// </remarks>
    public class MakerAcs : IGeneralGuideData
    {
        /// <summary>スタティックサーチ用</summary>
        private static Hashtable _maker_Stc = null;

        /// <summary>リモートオブジェクト格納バッファ</summary>
        // 2008.02.28 96012 提供分はローカルＤＢへのアクセスのみ Begin
        //private IMakerDB _iMakerDB = null;		//提供リモートオブジェクト
        // 2008.02.28 96012 提供分はローカルＤＢへのアクセスのみ end
        // 2008.06.11 30413 犬飼 提供ＤＢ（部品メーカー名称マスタ）に対応 >>>>>>START
        private IPMakerNmDB _iPMakerNmDB = null;
        // 2008.06.11 30413 犬飼 提供ＤＢ（部品メーカー名称マスタ）に対応 <<<<<<END
        private IMakerUDB _iMakerUDB = null;	//ユーザーリモートオブジェクト
        // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
        private MakerLcDB _makerLcDB = null;
        private MakerULcDB _makerULcDB = null;
        private static bool _isLocalDBRead = false;
        // 2008.02.08 96012 ローカルＤＢ参照対応 end

        // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        // 2008.02.08 96012 ローカルＤＢ参照対応 end

        /// <summary>
        /// メーカーアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// -----------------------------------------------------------------------------------
        /// Note       : メーカー取得のためのリモートオブジェクトを記述します。<br />
        /// Programmer : 96186  立花裕輔<br />
        /// Date       : 2007.08.01<br />
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.28 96012　日色 馨</br>
        /// <br>           : 提供分はローカルＤＢへのアクセスのみ</br>
        /// </remarks>
        public MakerAcs()
        {
            try
            {
                // リモートオブジェクト取得
                // 2008.02.28 96012 提供分はローカルＤＢへのアクセスのみ Begin
                //this._iMakerDB = (IMakerDB)MediationMakerDB.GetMakerDB();
                // 2008.02.28 96012 提供分はローカルＤＢへのアクセスのみ end

                // 2008.06.11 30413 犬飼 提供ＤＢ（部品メーカー名称マスタ）に対応 >>>>>>START
                this._iPMakerNmDB = (IPMakerNmDB)MediationPMakerNmDB.GetPMakerNmDB();
                // 2008.06.11 30413 犬飼 提供ＤＢ（部品メーカー名称マスタ）に対応 <<<<<<END

                this._iMakerUDB = (IMakerUDB)MediationMakerUDB.GetMakerUDB();
			}
            catch (Exception)
            {
                // 2008.02.28 96012 提供分はローカルＤＢへのアクセスのみ Begin
                //this._iMakerDB = null;
                // 2008.02.28 96012 提供分はローカルＤＢへのアクセスのみ end

                // 2008.06.11 30413 犬飼 提供ＤＢ（部品メーカー名称マスタ）に対応 >>>>>>START
                this._iPMakerNmDB = null;
                // 2008.06.11 30413 犬飼 提供ＤＢ（部品メーカー名称マスタ）に対応 <<<<<<END

                this._iMakerUDB = null;
			}
            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            // ローカルDBアクセスオブジェクト取得
            this._makerLcDB = new MakerLcDB();
            this._makerULcDB = new MakerULcDB();
            // 2008.02.08 96012 ローカルＤＢ参照対応 end
        }

        // --- ADD 2020.02.27 ---------->>>>>
        /// <summary>
        /// メーカー全件読み込み処理(論理削除含む)（ハンディ常駐呼出用）
        /// </summary>
        /// <param name="retList">参照結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : メーカー名称情報を読み込みます。<br />
        /// Programmer : 31739 岸<br />
        /// Date       : 2020.02.27<br />
        /// </remarks>
        public int SearchAll(out object retList, object enterpriseCode)
        {
            // 型変換
            ArrayList paraList = new ArrayList();
            ArrayList resultList = new ArrayList();
            string paraEnterpriseCode = enterpriseCode as string;

            // 既存メソッド呼出
            int status = this.SearchAll(out paraList, paraEnterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 型変換
                int count = 0;
                foreach (MakerUMnt itm in paraList)
                {
                	if (itm != null)
                	{
                        if (itm.LogicalDeleteCode == 0)
                        {
                            MakerUWork resItm = CopyToMakerUWorkFromMaker(itm);
                            resultList.Add(resItm);
                            count++;
                            if (count >= 100)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            // 出力パラメータを呼出パラメータへ設定
            retList = (object)resultList;

            // 既存メソッド呼出結果ステータスを返却
            return status;
        }
        // --- ADD 2020.02.27 ----------<<<<<

        /// <summary>
        /// メーカー全件読み込み処理(論理削除含む)
        /// </summary>
        /// <param name="retList">参照結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : メーカー名称情報を読み込みます。<br />
        /// Programmer : 96186 立花裕輔<br />
        /// Date       : 2007.08.01<br />
        /// </remarks>
		public int SearchAll(out ArrayList retList, string enterpriseCode)
		{
			//変数の初期化
			bool nextData;
			int retTotalCnt;
			int status = 0;
			ArrayList list = new ArrayList();

			retList = new ArrayList();
			retList.Clear();
			retTotalCnt = 0;

			_maker_Stc = new Hashtable();

			//ユーザー
			status = SearchUsrProc(ref list, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, 0, null);

            // 2008.06.11 30413 犬飼 ユーザＤＢの読込エラー時は提供ＤＢの読込を行わないように変更 >>>>>>START
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    return status;
            }
            // 2008.06.11 30413 犬飼 ユーザＤＢの読込エラー時は提供ＤＢの読込を行わないように変更 <<<<<<END
            
			//提供
			//status = SearchOfrProc(ref list, out retTotalCnt, out nextData, ConstantManagement.LogicalMode.GetDataAll, 0, null);

			retList = list;

            // 2008.06.11 30413 戻り値はstatusを返すように変更 >>>>>>START
			//return 0;
            return status;
            // 2008.06.11 30413 戻り値はstatusを返すように変更 <<<<<<END
		}


		/// <summary>
        /// メーカー検索処理＜ユーザー＞
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevMakerがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevMaker">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : メーカーの検索処理を行います。<br />
        /// Programmer : 96186 立花裕輔<br />
        /// Date       : 2007.08.01<br />
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
		private int SearchUsrProc(ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, MakerUMnt prevMaker)
        {
			//初期化処理
            int status = 0;
			retTotalCnt = 0;
            nextData = false;

			//条件抽出クラス(D)の設定
			MakerUWork makerUWork = new MakerUWork();
			if (prevMaker != null) makerUWork = CopyToMakerUWorkFromMaker(prevMaker);
            makerUWork.EnterpriseCode = enterpriseCode;

            ArrayList paraList = new ArrayList();
            paraList.Clear();
            object paraobj = makerUWork;
            object retobj = null;

            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            ////リモートオブジェクトの呼び出し
			//status = this._iMakerUDB.Search(out retobj, paraobj, readCnt, logicalMode);
            //
            //switch (status)
            //{
            //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //        paraList = retobj as ArrayList;
            //
            //        if (paraList != null)
            //        {
            //            foreach (MakerUWork wkMakerWork in paraList)
            //            {
			//				if (_maker_Stc[wkMakerWork.GoodsMakerCd] != null)
			//				{
			//					continue;
			//				}
            //
			//				MakerUMnt makerBuff = CopyToMakerFromMakerUWork(wkMakerWork);
            //                retList.Add(makerBuff);
            //                // static保持
            //                _maker_Stc[makerBuff.GoodsMakerCd] = makerBuff;
            //            }
            //        }
            //        break;
            //    case (int)ConstantManagement.DB_Status.ctDB_EOF:
            //        break;
            //    default:
            //        return status;
            //}
            if (_isLocalDBRead)
            {
                List<MakerUWork> workList = new List<MakerUWork>();
                //ローカルオブジェクトの呼び出し
                status = this._makerULcDB.Search(out workList, makerUWork, 0, logicalMode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        for (int i = 0; i < workList.Count; ++ i)
                        {
                            if (_maker_Stc[workList[i].GoodsMakerCd] != null)
                            {
                                continue;
                            }
                            MakerUMnt makerBuff = CopyToMakerFromMakerUWork(workList[i]);
                            retList.Add(makerBuff);
                            // static保持
                            _maker_Stc[makerBuff.GoodsMakerCd] = makerBuff;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        return status;
                }
                readCnt = workList.Count;
            }
            else
            {
                //リモートオブジェクトの呼び出し
                status = this._iMakerUDB.Search(out retobj, paraobj, readCnt, logicalMode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        paraList = retobj as ArrayList;
                        if (paraList != null)
                        {
                            foreach (MakerUWork wkMakerWork in paraList)
                            {
                				if (_maker_Stc[wkMakerWork.GoodsMakerCd] != null)
                				{
                					continue;
                				}
                				MakerUMnt makerBuff = CopyToMakerFromMakerUWork(wkMakerWork);
                                retList.Add(makerBuff);
                                // static保持
                                _maker_Stc[makerBuff.GoodsMakerCd] = makerBuff;
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        return status;
                }
            }
            // 2008.02.08 96012 ローカルＤＢ参照対応 end

            //全件リードの場合は戻り値の件数をセット
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        /// <summary>
        /// メーカー検索処理＜提供＞
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevMakerがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevMaker">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : メーカーの検索処理を行います。<br />
        /// Programmer : 96186 立花裕輔<br />
        /// Date       : 2007.08.01<br />
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.28 96012　日色 馨</br>
        /// <br>           : 提供分はローカルＤＢへのアクセスのみ</br>
        /// -----------------------------------------------------------------------
        /// <br>Update Note: 2008.06.11 30413 犬飼</br>
        /// <br>           : 提供メーカーワーククラスの参照を削除</br>
        /// </remarks>
        private int SearchOfrProc(ref ArrayList retList, out int retTotalCnt, out bool nextData, ConstantManagement.LogicalMode logicalMode, int readCnt, MakerUMnt prevMaker)
        {
            //初期化処理
            int status = 0;
            retTotalCnt = 0;
            nextData = false;

            // 2008.06.11 30413 犬飼 提供メーカーワーククラスの参照を削除 >>>>>>START
            //条件抽出クラス(D)の設定
            //MakerWork makerWork = new MakerWork();
            //if (prevMaker != null) makerWork = CopyToMakerWorkFromMaker(prevMaker);
            //
            ArrayList paraList = new ArrayList();
            paraList.Clear();
            //object paraobj = makerWork;
            // 2008.06.11 30413 犬飼 提供メーカーワーククラスの参照を削除 <<<<<<END
			
            // 2008.02.28 96012 提供分はローカルＤＢへのアクセスのみ Begin
            //object retobj = null;
            //
            ////リモートオブジェクトの呼び出し
            //status = this._iMakerDB.Search(out retobj, paraobj, readCnt, logicalMode);
            //
            //switch (status)
            //{
            //	case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //		paraList = retobj as ArrayList;
            //
            //		if (paraList != null)
            //		{
            //			foreach (MakerWork wkMakerWork in paraList)
            //			{
            //				if (_maker_Stc[wkMakerWork.GoodsMakerCd] != null)
            //				{
            //					continue;
            //				}
            //
            //				MakerUMnt makerBuff = CopyToMakerFromMakerWork(wkMakerWork);
            //				retList.Add(makerBuff);
            //				// static保持
            //				_maker_Stc[makerBuff.GoodsMakerCd] = makerBuff;
            //			}
            //		}
            //		break;
            //	case (int)ConstantManagement.DB_Status.ctDB_EOF:
            //		break;
            //	default:
            //		return status;
            //}
            // 2008.06.11 30413 犬飼 提供ＤＢ（部品メーカー名称マスタ）のリモートアクセスに対応 >>>>>>START
            object retobj = null;

            //リモートオブジェクトの呼び出し
            status = this._iPMakerNmDB.Search(out retobj, (int)logicalMode);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    paraList = retobj as ArrayList;

                    if (paraList != null)
                    {
                        foreach (PMakerNmWork wkPMakerNmWork in paraList)
                        {
                            if (_maker_Stc[wkPMakerNmWork.PartsMakerCode] != null)
                            {
                                continue;
                            }

                            MakerUMnt makerBuff = CopyToMakerFromPMakerNmWork(wkPMakerNmWork);
                            retList.Add(makerBuff);
                            // static保持
                            _maker_Stc[makerBuff.GoodsMakerCd] = makerBuff;
                        }
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    return status;
            }
            // 2008.06.11 30413 犬飼 提供ＤＢ（部品メーカー名称マスタ）のリモートアクセスに対応 <<<<<<END

            // 2008.06.11 30413 犬飼 既存のローカルアクセスをコメント化 >>>>>>START
            //List<MakerWork> workList = new List<MakerWork>();
            ////ローカルオブジェクトの呼び出し
            //status = this._makerLcDB.Search(out workList, makerWork, 0, logicalMode);
            //switch (status)
            //{
            //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //        if (workList.Count > 0)
            //        {
            //            for (int i = 0; i < workList.Count; ++i)
            //            {
            //                if (_maker_Stc[workList[i].GoodsMakerCd] != null)
            //                {
            //                    continue;
            //                }
            //                MakerUMnt makerBuff = CopyToMakerFromMakerWork(workList[i]);
            //                retList.Add(makerBuff);
            //                // static保持
            //                _maker_Stc[makerBuff.GoodsMakerCd] = makerBuff;
            //            }
            //        }
            //        break;
            //    case (int)ConstantManagement.DB_Status.ctDB_EOF:
            //        break;
            //    default:
            //        return status;
            //}
            //readCnt = workList.Count;
            // 2008.06.11 30413 犬飼 既存のローカルアクセスをコメント化 <<<<<<END
            // 2008.02.28 96012 提供分はローカルＤＢへのアクセスのみ end

            //全件リードの場合は戻り値の件数をセット
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        // --- ADD 2020/02/27 ---------->>>>>
        /// <summary>
        /// メーカー読み込みメイン処理（ハンディ用）
        /// </summary>
        /// <param name="retValue">メーカーオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : メーカー名称情報を読み込みます。<br />
        /// Programmer : 31739 岸<br />
        /// Date       : 2020.02.27<br />
        /// </remarks>
        public int ReadHandy(out object retValue, object enterpriseCode, object goodsMakerCd)
        {
            // 型変換
            MakerUMnt result = new MakerUMnt();
            string pEnterpriseCode = enterpriseCode as string;
            int pGoodsMakerCd = (int)goodsMakerCd;
            MakerUWork resultValue = new MakerUWork();

            // 既存メソッド呼出
            int status = this.Read(out result, pEnterpriseCode, pGoodsMakerCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
            	if (result != null)
            	{
                    // 型変換
                    resultValue = CopyToMakerUWorkFromMaker(result);
                }
            }

            // 戻り値設定
            retValue = (object)resultValue;
            return status;

        }
        // --- ADD 2020/02/27 ---------->>>>>

        /// <summary>
		/// メーカー読み込みメイン処理
        /// </summary>
        /// <param name="maker">メーカーオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : メーカー名称情報を読み込みます。<br />
        /// Programmer : 96186 立花裕輔<br />
        /// Date       : 2007.08.01<br />
        /// </remarks>
		public int Read(out MakerUMnt makerUMnt, string enterpriseCode, int goodsMakerCd)
		{
			int status = 0;

			//ユーザー読み込み
			status = ReadUWork(out makerUMnt, enterpriseCode, goodsMakerCd);
			if (status == 0) return(status);

            // 2009.02.06 30413 犬飼 提供分は読まないように修正 >>>>>>START
            ////メーカー読み込み
            //status = ReadWork(out makerUMnt, goodsMakerCd);
            // 2009.02.06 30413 犬飼 提供分は読まないように修正 <<<<<<END
            return (status);
		}

		/// <summary>
		/// メーカー読み込み処理＜提供＞
		/// </summary>
		/// <param name="maker">メーカーオブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="makerCode">メーカーコード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// Note       : メーカー名称情報を読み込みます。<br />
		/// Programmer : 96186 立花裕輔<br />
		/// Date       : 2007.08.01<br />
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.28 96012　日色 馨</br>
        /// <br>           : 提供分はローカルＤＢへのアクセスのみ</br>
        /// </remarks>
		private int ReadWork(out MakerUMnt makerUMnt, int goodsMakerCd)
		{
			try
			{
				int status = 0;

				makerUMnt = null;

                // 2008.06.11 30413 犬飼 提供メーカーワーククラスの参照を削除 >>>>>>START
				// ｢D｣に対して入力パラメータを格納する
				//MakerWork makerWork = new MakerWork();
				//makerWork.GoodsMakerCd = goodsMakerCd;
                // 2008.06.11 30413 犬飼 提供メーカーワーククラスの参照を削除 <<<<<<END

                // 2008.06.11 30413 提供ＤＢ（部品メーカー名称マスタ）のリモートアクセスに対応 >>>>>>START
                PMakerNmWork pMakerNmWork = new PMakerNmWork();
                pMakerNmWork.PartsMakerCode = goodsMakerCd;
                // 2008.06.11 30413 提供ＤＢ（部品メーカー名称マスタ）のリモートアクセスに対応 <<<<<<END

				// レスポンス
				ArrayList retList = new ArrayList();

                // 2008.02.28 96012 提供分はローカルＤＢへのアクセスのみ Begin
                //// XMLへ変換し、文字列のバイナリ化 iitani d
				//byte[] parabyte = XmlByteSerializer.Serialize(makerWork);
                //
				//// メーカー名称読み込み
				//status = this._iMakerDB.Read(ref parabyte, 0);
                //
				//// 成功したら取得データを抽出
				//if (status == 0)
				//{
				//	// XMLの読み込み
				//	makerUMnt = CopyToMakerFromMakerWork(makerWork);
				//}
                // 2008.06.11 30413 犬飼 既存のローカルアクセスをコメント化 >>>>>>START
                // メーカー名称読み込み
                //status = this._makerLcDB.Read(ref makerWork, 0);
                // 成功したら取得データを抽出
                //if (status == 0)
                //{
                //    // XMLの読み込み
                //    makerUMnt = CopyToMakerFromMakerWork(makerWork);
                //}
                // 2008.06.11 30413 犬飼 既存のローカルアクセスをコメント化 <<<<<<END
                // 2008.02.28 96012 提供分はローカルＤＢへのアクセスのみ end

                // 2008.06.11 30413 犬飼 提供ＤＢのリモートアクセスを復活 >>>>>>START
                // リモートアクセス
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(pMakerNmWork);

                // メーカー名称読み込み
                status = this._iPMakerNmDB.Read(ref parabyte, 0);

                // 成功したら取得データを抽出
                if (status == 0)
                {
                    // 2008.07.03 30413 犬飼 デシリアライズ処理を追加 >>>>>>START
                    // XMLの読み込み
                    pMakerNmWork = (PMakerNmWork)XmlByteSerializer.Deserialize(parabyte, typeof(PMakerNmWork));
                    // 2008.07.03 30413 犬飼 デシリアライズ処理を追加 <<<<<<END
                    // クラス内メンバコピー
                    makerUMnt = CopyToMakerFromPMakerNmWork(pMakerNmWork);
                }                
                // 2008.06.11 30413 犬飼 提供ＤＢのリモートアクセスを復活 <<<<<<END

                return status;
			}
			catch (Exception)
			{
				//通信エラーは-1を戻す
				makerUMnt = null;
				//オフライン時はnullをセット
                //this._iMakerDB = null;  // iitani d 2007.05.21
                // 2008.06.11 30413 犬飼 提供ＤＢ（部品メーカー名称マスタ）に対応 >>>>>>START
                this._iPMakerNmDB = null;
                // 2008.06.11 30413 犬飼 提供ＤＢ（部品メーカー名称マスタ）に対応 <<<<<<END

                // 2008.06.11 30413 犬飼 ユーザーＤＢのリモートオブジェクトをnullセット >>>>>>START
                this._iMakerUDB = null;
                // 2008.06.11 30413 犬飼 ユーザーＤＢのリモートオブジェクトをnullセット <<<<<<END
				return -1;
			}
		}


        /// <summary>
		/// メーカー読み込み処理＜ユーザー＞
        /// </summary>
        /// <param name="maker">メーカーオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : メーカー名称情報を読み込みます。<br />
        /// Programmer : 96186 立花裕輔<br />
        /// Date       : 2007.08.01<br />
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
		private int ReadUWork(out MakerUMnt makerUMnt, string enterpriseCode, int goodsMakerCd)
        {
            try
            {
                int status = 0;

				makerUMnt = null;

                // オフライン状態の場合
                //if (!LoginInfoAcquisition.OnlineFlag)
                //{
                //    status = ReadStaticMakerMemory(out maker, enterpriseCode, makerCode);

                //}
                //else
                //{
                // ｢D｣に対して入力パラメータを格納する
                MakerUWork makerUWork = new MakerUWork();
                makerUWork.EnterpriseCode = enterpriseCode;
				makerUWork.GoodsMakerCd = goodsMakerCd;

                // レスポンス
                ArrayList retList = new ArrayList();

                // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
                //// XMLへ変換し、文字列のバイナリ化 iitani d
                //byte[] parabyte = XmlByteSerializer.Serialize(makerUWork);
                //
                //// メーカー名称読み込み(ローカルDB) iitani c
                //status = this._iMakerUDB.Read(ref parabyte, 0);
                ////status = this._makerLcDB.Read(ref makerWork, 0);
                //
                //// 成功したら取得データを抽出
                //if (status == 0)
                //{
                //    // XMLの読み込み
                //    makerUWork = (MakerUWork)XmlByteSerializer.Deserialize(parabyte, typeof(MakerUWork));
				//	makerUMnt = CopyToMakerFromMakerUWork(makerUWork);
                //}
                ////}
                if (_isLocalDBRead)
                {
                    status = this._makerULcDB.Read(ref makerUWork, 0);
                    if (status == 0)
                    {
                        // XMLの読み込み
                        makerUMnt = CopyToMakerFromMakerUWork(makerUWork);
                    }
                }
                else
                {
                    // XMLへ変換し、文字列のバイナリ化 iitani d
                    byte[] parabyte = XmlByteSerializer.Serialize(makerUWork);
                    // メーカー名称読み込み(ローカルDB) iitani c
                    status = this._iMakerUDB.Read(ref parabyte, 0);
                    // 成功したら取得データを抽出
                    if (status == 0)
                    {
                        // XMLの読み込み
                        makerUWork = (MakerUWork)XmlByteSerializer.Deserialize(parabyte, typeof(MakerUWork));
                    	makerUMnt = CopyToMakerFromMakerUWork(makerUWork);
                    }
                }
                // 2008.02.08 96012 ローカルＤＢ参照対応 end
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
				makerUMnt = null;
                //オフライン時はnullをセット
                //this._iMakerDB = null;  // iitani d 2007.05.21
                // 2008.06.11 30413 犬飼 提供ＤＢ（部品メーカー名称マスタ）に対応 >>>>>>START
                this._iPMakerNmDB = null;
                // 2008.06.11 30413 犬飼 提供ＤＢ（部品メーカー名称マスタ）に対応 <<<<<<END

                // 2008.06.11 30413 犬飼 ユーザーＤＢのリモートオブジェクトをnullセット >>>>>>START
                this._iMakerUDB = null;
                // 2008.06.11 30413 犬飼 ユーザーＤＢのリモートオブジェクトをnullセット <<<<<<END
                return -1;
            }
        }

        /// <summary>
        /// メーカー登録・更新処理
        /// </summary>
        /// <param name="maker">メーカー</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : メーカー情報の登録・更新を行います。<br />
        /// Programmer : 20006 立花裕輔<br />
        /// Date       : 2006.12.05<br />
        /// </remarks>
		public int Write(ref MakerUMnt makerUMnt)
        {
            int status = 0;

            try
            {
				MakerUWork makerUWork = this.CopyToMakerUWorkFromMaker(makerUMnt);

                // XMLへ変換し、文字列のバイナリ化
                //byte[] parabyte = XmlByteSerializer.Serialize(makerUWork);
                ArrayList paraList = new ArrayList();
                paraList.Add(makerUWork);
                object paraobj = paraList;

                // メーカー名称書き込み(｢A｣→｢O｣へ接続)
                //status = this._iMakerUDB.Write(ref parabyte);
                status = this._iMakerUDB.Write(ref paraobj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraobj;
                    // ファイル名を渡してワーククラスをデシリアライズする
                    //makerWork = (MakerUWork)XmlByteSerializer.Deserialize(parabyte, typeof(MakerUWork));
					makerUMnt = this.CopyToMakerFromMakerUWork((MakerUWork)paraList[0]);
                    // static保持
                    //_maker_Stc[maker.GoodsMakerCd] = maker;
                }
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                //this._iMakerDB = null;
                // 2008.06.11 30413 犬飼 提供ＤＢ（部品メーカー名称マスタ）に対応 >>>>>>START
                this._iPMakerNmDB = null;
                // 2008.06.11 30413 犬飼 提供ＤＢ（部品メーカー名称マスタ）に対応 <<<<<<END

                // 2008.06.11 30413 犬飼 ユーザーＤＢのリモートオブジェクトをnullセット >>>>>>START
                this._iMakerUDB = null;
                // 2008.06.11 30413 犬飼 ユーザーＤＢのリモートオブジェクトをnullセット <<<<<<END
                //通信エラーは-1を戻す
                status = -1;
            }
            return status;
        }

        /// <summary>
        /// メーカー論理削除処理
        /// </summary>
        /// <param name="maker">メーカーオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : メーカー情報の論理削除を行います。<br />
        /// Programmer : 96186 立花裕輔<br />
        /// Date       : 2007.08.01<br />
        /// </remarks>
		public int LogicalDelete(ref MakerUMnt makerUMnt)
        {
            int status = 0;

            try
            {
				MakerUWork makerUWork = CopyToMakerUWorkFromMaker(makerUMnt);

                ArrayList paraList = new ArrayList();
				paraList.Add(makerUWork);
                object paraObj = paraList;

                // メーカー名称クラス論理削除
                status = this._iMakerUDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    // クラス内メンバコピー
					makerUMnt = CopyToMakerFromMakerUWork((MakerUWork)paraList[0]);

					// static保持
                    //_maker_Stc[maker.GoodsMakerCd] = maker;

                    //Maker deleteMaker = new Maker();
                    //deleteMaker.EnterpriseCode = maker.EnterpriseCode;
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                //this._iMakerDB = null;
                // 2008.06.11 30413 犬飼 提供ＤＢ（部品メーカー名称マスタ）に対応 >>>>>>START
                this._iPMakerNmDB = null;
                // 2008.06.11 30413 犬飼 提供ＤＢ（部品メーカー名称マスタ）に対応 <<<<<<END

                // 2008.06.11 30413 犬飼 ユーザーＤＢのリモートオブジェクトをnullセット >>>>>>START
                this._iMakerUDB = null;
                // 2008.06.11 30413 犬飼 ユーザーＤＢのリモートオブジェクトをnullセット <<<<<<END
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// メーカー物理削除処理
        /// </summary>
        /// <param name="maker">メーカーオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : メーカー情報の物理削除を行います。<br />
        /// Programmer : 96186 立花裕輔<br />
        /// Date       : 2007.08.01<br />
        /// </remarks>
		public int Delete(MakerUMnt makerUMnt)
        {
			try
            {
				MakerUWork makerUWork = CopyToMakerUWorkFromMaker(makerUMnt);
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(makerUWork);

                // メーカー名称物理削除
                int status = this._iMakerUDB.Delete(parabyte);

                //makerWork = (MakerUWork)XmlByteSerializer.Deserialize(parabyte, typeof(MakerUWork));
                //maker = CopyToMakerFromMakerWork(makerWork);

				//makerUMnt = this.CopyToMakerFromMakerUWork((MakerUWork)paraList[0]);


                // static削除
                //_maker_Stc.Remove(maker.GoodsMakerCd);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                //this._iMakerDB = null;
                // 2008.06.11 30413 犬飼 ユーザーＤＢのリモートオブジェクトをnullセット >>>>>>START
                this._iMakerUDB = null;
                // 2008.06.11 30413 犬飼 ユーザーＤＢのリモートオブジェクトをnullセット <<<<<<END
                //通信エラーは-1を戻す
                return -1;
            }
		}

        /// <summary>
        /// メーカー論理削除復活処理
        /// </summary>
        /// <param name="maker">メーカー名称オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : メーカー情報の復活を行います。<br />
        /// Programmer : 96186 立花裕輔<br />
        /// Date       : 2007.08.01<br />
        /// </remarks>
		public int Revival(ref MakerUMnt makerUMnt)
        {
            // 論理削除復活はユーザー登録分しかありえない！！
            try
            {
				MakerUWork makerUWork = CopyToMakerUWorkFromMaker(makerUMnt);
                ArrayList paraList = new ArrayList();
                paraList.Add(makerUWork);
                object paraobj = paraList;

                // 復活処理
                int status = this._iMakerUDB.RevivalLogicalDelete(ref paraobj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraobj;
                    // クラス内メンバコピー
					makerUMnt = CopyToMakerFromMakerUWork((MakerUWork)paraList[0]);
                    // static保持
                    //_maker_Stc[maker.GoodsMakerCd] = maker;
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                // 2008.02.28 96012 提供分はローカルＤＢへのアクセスのみ Begin
                //this._iMakerDB = null;
                this._iMakerUDB = null;
                // 2008.02.28 96012 提供分はローカルＤＢへのアクセスのみ end
                //通信エラーは-1を戻す
                return -1;
            }
        }

		/// <summary>
		/// クラスメンバーコピー処理（提供メーカーワーククラス(D)⇒メーカークラス(E)）
		/// </summary>
		/// <param name="makerWork">メーカーワーククラス</param>
		/// <returns>メーカークラス</returns>
		/// <remarks>
		/// Note       : メーカーワーククラス(ユーザー)からメーカークラスへメンバーのコピーを行います。<br />
		/// Programmer : 立花裕輔<br />
		/// Date       : 2007.08.01<br />
        /// -----------------------------------------------------------------------
        /// <br>Update Note: 2008.06.11 30413 犬飼</br>
        /// <br>           : 提供メーカーワーククラスの参照を削除</br>
        /// </remarks>
		//private MakerUMnt CopyToMakerFromMakerWork(MakerWork makerWork)
		//{
		//	MakerUMnt makerUMnt = new MakerUMnt();
        //
		//	makerUMnt.CreateDateTime = makerWork.CreateDateTime;
		//	makerUMnt.GoodsMakerCd = makerWork.GoodsMakerCd;
		//	makerUMnt.LogicalDeleteCode = makerWork.LogicalDeleteCode;
		//	makerUMnt.MakerKanaName = makerWork.MakerKanaName;
		//	makerUMnt.MakerName = makerWork.MakerName;
		//	makerUMnt.MakerShortName = makerWork.MakerShortName;
		//	makerUMnt.UpdateDateTime = makerWork.UpdateDateTime;
		//	makerUMnt.Division = 1;
		//	//----- ueno upd ---------- start 2008.02.20 提供データ→提供
		//	makerUMnt.DivisionName = "提供";
		//	//----- ueno upd ---------- start 2008.02.20
        //
		//	return makerUMnt;
		//}

        /// <summary>
        /// クラスメンバーコピー処理（提供部品メーカー名称ワーククラス(D)⇒メーカークラス(E)）
        /// </summary>
        /// <param name="pMakerNmWork">部品メーカー名称ワーククラス</param>
        /// <returns>メーカークラス</returns>
        /// <remarks>
        /// <br>Note       : 部品メーカー名称ワーククラス(ユーザー)からメーカークラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        private MakerUMnt CopyToMakerFromPMakerNmWork(PMakerNmWork pMakerNmWork)
        {
            MakerUMnt makerUMnt = new MakerUMnt();

            makerUMnt.GoodsMakerCd = pMakerNmWork.PartsMakerCode;           // 部品メーカーコード
            makerUMnt.MakerName = pMakerNmWork.PartsMakerFullName;          // 部品メーカー名称（全角）
            makerUMnt.MakerKanaName = pMakerNmWork.PartsMakerHalfName;      // 部品メーカー名称（半角）
            //makerUMnt.Division = 1;
            //makerUMnt.DivisionName = "提供";
            
            return makerUMnt;
        }

		/// <summary>
		/// クラスメンバーコピー処理（ユーザーメーカーワーククラス(D)⇒メーカークラス(E)）
		/// </summary>
		/// <param name="makerWork">メーカーワーククラス</param>
		/// <returns>メーカークラス</returns>
		/// <remarks>
		/// Note       : メーカーワーククラス(ユーザー)からメーカークラスへメンバーのコピーを行います。<br />
		/// Programmer : 立花裕輔<br />
		/// Date       : 2007.08.01<br />
        /// </remarks>
		private MakerUMnt CopyToMakerFromMakerUWork(MakerUWork makerUWork)
		{
			MakerUMnt makerUMnt = new MakerUMnt();

			makerUMnt.CreateDateTime = makerUWork.CreateDateTime;
			makerUMnt.DisplayOrder = makerUWork.DisplayOrder;
			makerUMnt.EnterpriseCode = makerUWork.EnterpriseCode;
			makerUMnt.FileHeaderGuid = makerUWork.FileHeaderGuid;
			makerUMnt.GoodsMakerCd = makerUWork.GoodsMakerCd;
			makerUMnt.LogicalDeleteCode = makerUWork.LogicalDeleteCode;
			makerUMnt.MakerKanaName = makerUWork.MakerKanaName;
			makerUMnt.MakerName = makerUWork.MakerName;
			makerUMnt.MakerShortName = makerUWork.MakerShortName;
			makerUMnt.UpdAssemblyId1 = makerUWork.UpdAssemblyId1;
			makerUMnt.UpdAssemblyId2 = makerUWork.UpdAssemblyId2;
			makerUMnt.UpdateDateTime = makerUWork.UpdateDateTime;
			makerUMnt.UpdEmployeeCode = makerUWork.UpdEmployeeCode;
            makerUMnt.OfferDate = makerUWork.OfferDate;                    // 提供日付
            makerUMnt.OfferDataDiv = makerUWork.OfferDataDiv;              // 提供データ区分
            if (makerUMnt.OfferDate == DateTime.MinValue)
            {
                makerUMnt.Division = 0;
                makerUMnt.DivisionName = "ユーザー";
            }
            else
            {
                makerUMnt.Division = 1;
                makerUMnt.DivisionName = "提供";
            }
			//----- ueno upd ---------- start 2008.02.20 ユーザーデータ→ユーザー
			//makerUMnt.DivisionName = "ユーザー";
			//----- ueno upd ---------- end 2008.02.20

			return makerUMnt;
		}

        /// <summary>
		/// クラスメンバーコピー処理（メーカークラス(E)⇒提供メーカーワーククラス(D)）
        /// </summary>
        /// <param name="maker">メーカークラス</param>
        /// <returns>メーカーワーカークラス</returns>
        /// <remarks>
        /// Note       : メーカークラスからメーカーワーククラスへメンバーのコピーを行います。<br />
        /// Programmer : 立花裕輔<br />
        /// >Date       : 2007.08.01<br />
        /// -----------------------------------------------------------------------
        /// <br>Update Note: 2008.06.11 30413 犬飼</br>
        /// <br>           : 提供メーカーワーククラスの参照を削除</br>
        /// </remarks>
        //private MakerWork CopyToMakerWorkFromMaker(MakerUMnt makerUMnt)
        //{
        //    MakerWork makerWork = new MakerWork();
        //
		//	makerWork.CreateDateTime = makerUMnt.CreateDateTime;
		//	makerWork.GoodsMakerCd = makerUMnt.GoodsMakerCd;
		//	makerWork.LogicalDeleteCode = makerUMnt.LogicalDeleteCode;
		//	makerWork.MakerKanaName = makerUMnt.MakerKanaName;
		//	makerWork.MakerName = makerUMnt.MakerName;
		//	makerWork.MakerShortName = makerUMnt.MakerShortName;
		//	makerWork.UpdateDateTime = makerUMnt.UpdateDateTime;
		//	return makerWork;
        //}

        /// <summary>
        /// クラスメンバーコピー処理（メーカークラス(E)⇒提供部品メーカー名称ワーククラス(D)）
        /// </summary>
        /// <param name="maker">メーカークラス</param>
        /// <returns>部品メーカー名称ワーククラス</returns>
        /// <remarks>
        /// Note       : メーカークラスから部品メーカー名称ワーククラスへメンバーのコピーを行います。<br />
        /// Programmer : 30413 犬飼<br />
        /// >Date       : 2008.06.11<br />
        /// </remarks>
        private PMakerNmWork CopyToPMakerNmWorkFromMaker(MakerUMnt makerUMnt)
        {
            PMakerNmWork pMakerNmWork = new PMakerNmWork();

            pMakerNmWork.PartsMakerCode = makerUMnt.GoodsMakerCd;           // 部品メーカーコード
            pMakerNmWork.PartsMakerFullName = makerUMnt.MakerName;          // 部品メーカー名称（全角）
            pMakerNmWork.PartsMakerHalfName = makerUMnt.MakerKanaName;      // 部品メーカー名称（半角）
            return pMakerNmWork;
        }

		/// <summary>
		/// クラスメンバーコピー処理（メーカークラス(E)⇒ユーザーメーカーワーククラス(D)）
		/// </summary>
		/// <param name="maker">メーカークラス</param>
		/// <returns>メーカーワーカークラス</returns>
		/// <remarks>
		/// Note       : メーカークラスからメーカーワーククラスへメンバーのコピーを行います。<br />
		/// Programmer : 立花裕輔<br />
		/// >Date       : 2007.08.01<br />
		/// </remarks>
		private MakerUWork CopyToMakerUWorkFromMaker(MakerUMnt makerUMnt)
		{
			MakerUWork makerUWork = new MakerUWork();

			makerUWork.CreateDateTime = makerUMnt.CreateDateTime;
			makerUWork.DisplayOrder = makerUMnt.DisplayOrder;
			makerUWork.EnterpriseCode = makerUMnt.EnterpriseCode;
			makerUWork.FileHeaderGuid = makerUMnt.FileHeaderGuid;
			makerUWork.GoodsMakerCd = makerUMnt.GoodsMakerCd;
			makerUWork.LogicalDeleteCode = makerUMnt.LogicalDeleteCode;
			makerUWork.MakerKanaName = makerUMnt.MakerKanaName;
			makerUWork.MakerName = makerUMnt.MakerName;
			makerUWork.MakerShortName = makerUMnt.MakerShortName;
			makerUWork.UpdAssemblyId1 = makerUMnt.UpdAssemblyId1;
			makerUWork.UpdAssemblyId2 = makerUMnt.UpdAssemblyId2;
			makerUWork.UpdateDateTime = makerUMnt.UpdateDateTime;
			makerUWork.UpdEmployeeCode = makerUMnt.UpdEmployeeCode;
            makerUWork.OfferDate = makerUMnt.OfferDate;                    // 提供日付
            makerUWork.OfferDataDiv = makerUMnt.OfferDataDiv;              // 提供データ区分
			return makerUWork;
		}


		/// <summary>
		/// マスタ検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <param name="belongSectionCode">拠点コード</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 取得結果をDataSetで返します。</br>
		/// <br>Programmer	: 96186 立花裕輔</br>
		/// <br>Date		: 2007.08.01</br>
		/// </remarks>
		public int Search(ref DataSet ds, string enterpriseCode)
		{
			//LGoodsGanreWork lgoodsganreWork = new LGoodsGanreWork();
			//lgoodsganreWork.EnterpriseCode = enterpriseCode;

			//ArrayList ar = new ArrayList();


			ArrayList retList = new ArrayList();

			int status = 0;
			//object objectLGoodsGanreWork;

			// オンライン且つ、Searchが行われていない場合（オフラインの場合はコンストラクタでStatic展開済み）
			//if ((!_searchFlg) && (LoginInfoAcquisition.OnlineFlag))
			//{

			// マスタサーチ
			status = SearchAll(out retList, enterpriseCode);
			if (status != 0)
			{
				return status;
			}

			ArrayList wkList = retList.Clone() as ArrayList;
			SortedList wkSort = new SortedList();

			// --- [全て] --- //
			// そのまま全件返す
			foreach (MakerUMnt wkMakerUMnt in wkList)
			{
				if (wkMakerUMnt.LogicalDeleteCode == 0)
				{
					wkSort.Add(wkMakerUMnt.GoodsMakerCd, wkMakerUMnt);
				}
			}

			MakerUMnt[] makerUMnt = new MakerUMnt[wkSort.Count];

			// データを元に戻す
			for (int i = 0; i < wkSort.Count; i++)
			{
				makerUMnt[i] = (MakerUMnt)wkSort.GetByIndex(i);
			}

			byte[] retbyte = XmlByteSerializer.Serialize(makerUMnt);
			XmlByteSerializer.ReadXml(ref ds, retbyte);

			return status;
		}

        /// <summary>
        /// マスタ検索処理（DataSet用）(部品メーカーは抽出対象外)
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="belongSectionCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部品メーカーを抽出対象外とした取得結果をDataSetで返します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.12.05</br>
        /// </remarks>
        public int SearchExtra(ref DataSet ds, string enterpriseCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;
            
            // マスタサーチ
            status = SearchAll(out retList, enterpriseCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList wkList = retList.Clone() as ArrayList;
            SortedList wkSort = new SortedList();

            // --- [全て] --- //
            // 部品メーカーを抽出対象外として返す
            foreach (MakerUMnt wkMakerUMnt in wkList)
            {
                if ((wkMakerUMnt.LogicalDeleteCode == 0) && (wkMakerUMnt.GoodsMakerCd < 1000))
                {
                    wkSort.Add(wkMakerUMnt.GoodsMakerCd, wkMakerUMnt);
                }
            }

            MakerUMnt[] makerUMnt = new MakerUMnt[wkSort.Count];

            // データを元に戻す
            for (int i = 0; i < wkSort.Count; i++)
            {
                makerUMnt[i] = (MakerUMnt)wkSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(makerUMnt);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

        /// <summary>
        /// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note		: 汎用ガイド設定用データを取得します。</br>
        /// <br>Programmer	: 96186 立花裕輔</br>
        /// <br>Date		: 2007.08.01</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";

            // 企業コード設定有り
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            // 企業コード設定無し
            else
            {
                // 有り得ないのでエラー
                return status;
            }

            // 2008.12.05 30413 犬飼 部品メーカーの表示制御を追加 >>>>>>START
            // メーカーマスタテーブル読込み(ローカルDB) iitani c
            //status = Search(ref guideList, enterpriseCode);
            ////status = SearchLocalDB(ref guideList, enterpriseCode);

            int extraFlg = 0;
            if (inParm.ContainsKey("MakerCdExtraFlg"))
            {
                extraFlg = (int)inParm["MakerCdExtraFlg"];
            }

            if (extraFlg == 0)
            {
                status = Search(ref guideList, enterpriseCode);
            }
            else
            {
                status = SearchExtra(ref guideList, enterpriseCode);
            }
            // 2008.12.05 30413 犬飼 部品メーカーの表示制御を追加 <<<<<<END
            
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

        /// <summary>
        /// メーカーマスタガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="maker">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: メーカーマスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer	: 96186 立花裕輔</br>
        /// <br>Date		: 2007.08.01</br>
        /// </remarks>
		public int ExecuteGuid(string enterpriseCode, out MakerUMnt makerUMnt)
        {
            int status = -1;
			makerUMnt = new MakerUMnt();

            TableGuideParent tableGuideParent = new TableGuideParent("MAKERGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
				string strCode = retObj["GoodsMakerCd"].ToString();
				makerUMnt.GoodsMakerCd = int.Parse(strCode);
				makerUMnt.MakerName = retObj["MakerName"].ToString();
				makerUMnt.MakerShortName = retObj["MakerShortName"].ToString();
				makerUMnt.MakerKanaName = retObj["MakerKanaName"].ToString();
				strCode = retObj["DisplayOrder"].ToString();
				makerUMnt.DisplayOrder = int.Parse(strCode);
				strCode = retObj["Division"].ToString();
				makerUMnt.Division = int.Parse(strCode);
				makerUMnt.DivisionName = retObj["DivisionName"].ToString();
				status = 0;
            }
            // キャンセル
            else
            {
                status = 1;
            }

            return status;
        }
    }
}
