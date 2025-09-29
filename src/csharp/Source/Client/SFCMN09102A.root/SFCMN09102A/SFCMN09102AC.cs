# region ※using
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
using Broadleaf.Application.Common;
#endregion

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 番号管理設定テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 番号管理設定テーブルのアクセス制御を行います。</br>
	/// <br>Programmer	: 22033 三崎  貴史</br>
	/// <br>Date		: 2005.09.08</br>
	/// <br>UpDateNote	: 2006.08.30 22033 三崎 貴史</br>
	/// <br>			: ・Search（番号タイプ管理取得用）のstatic対応</br>
    /// <br>Update Note : 2007.05.23 980023 飯谷 耕平</br>
    /// <br>            : ・拠点情報の取得先をリモートに修正</br>
    /// </remarks>
	public class NoMngSetAcs
	{
		# region ■こんすとらくた
		/// <summary>
		/// 番号管理設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 番号管理設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public NoMngSetAcs()
		{
			//---拠点情報部品アクセスクラスのインスタンス化---//
            // ----- iitani c ----- start 2007.05.23
            //this._secInfoAcs = new SecInfoAcs();
            this._secInfoAcs = new SecInfoAcs(1);   // searchMode(0: 1:)
            // ----- iitani c ----- end 2007.05.23

			if (_noTypeMngArray == null)
			{
				_noTypeMngArray = new ArrayList();
			}

			try
			{
				// リモートオブジェクト取得
				this._iNoMngSetDB = (INoMngSetDB)MediationNoMngSetDB.GetNoMngSetDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
				this._iNoMngSetDB = null;
			}
		}
		# endregion

		# region ■Private Members
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private INoMngSetDB _iNoMngSetDB = null;
		/// <summary>拠点情報取得部品</summary>
		private SecInfoAcs _secInfoAcs = null;
		/// <summary>番号タイプ管理static</summary>
		private static ArrayList _noTypeMngArray;
		# endregion

		# region ■Public Methods
		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iNoMngSetDB == null)
			{
				return (int)ConstantManagement.OnlineMode.Offline;
			}
			else
			{
				return (int)ConstantManagement.OnlineMode.Online;
			}
		}

		/// <summary>
		/// 番号管理設定読み込み処理
		/// </summary>
		/// <param name="noMngSet">番号管理設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="noCode">番号コード</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 番号管理設定情報を読み込みます。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public int Read(out NoMngSet noMngSet, string enterpriseCode, string sectionCode, int noCode)
		{			
			try
			{
				noMngSet = null;
				NoMngSetWork noMngSetWork	= new NoMngSetWork();
				noMngSetWork.EnterpriseCode = enterpriseCode;
				noMngSetWork.SectionCode	= sectionCode;
				noMngSetWork.NoCode			= noCode;

				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(noMngSetWork);

				// 番号管理設定読み込み
				int status = this._iNoMngSetDB.ReadNoMngSet(ref parabyte,0);

				if (status == 0)
				{
					// XMLの読み込み
					noMngSetWork = (NoMngSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoMngSetWork));
					// クラス内メンバコピー
					noMngSet = CopyToNoMngSetFromNoMngSetWork(noMngSetWork);
				}
				
				return status;
			}
			catch (Exception)
			{				
				// 通信エラーは-1を戻す
				noMngSet = null;
				
				// オフライン時はnullをセット
				this._iNoMngSetDB = null;
				return -1;
			}
		}

		/// <summary>
		/// 番号管理設定登録・更新処理
		/// </summary>
		/// <param name="noMngSetList">番号管理設定クラスList</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 番号管理設定情報の登録・更新を行います。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public int Write(ref ArrayList noMngSetList)
		{
			ArrayList retList = new ArrayList();
			NoMngSetWork noMngSetWork;
			NoMngSet noMngSet;

			foreach (NoMngSet noMngSetWk in noMngSetList)
			{
				// 番号管理設定クラスから番号管理設定ワーカークラスにメンバコピー
				noMngSetWork = CopyToNoMngSetWorkFromNoMngSet(noMngSetWk);
				retList.Add(noMngSetWork);
			}

			Object retObj = retList as Object;
			
			int status = 0;

			try
			{
				// 番号管理設定書き込み				 
				status = this._iNoMngSetDB.WriteNoMngSet(ref retObj);
				
				if (status == 0)
				{
					retList = retObj as ArrayList;
					noMngSetList.Clear();
					
					foreach (NoMngSetWork wkNoMngSetWork in retList)
					{
						// 番号管理設定ワーカークラスから番号管理設定クラスにメンバコピー
						noMngSet = CopyToNoMngSetFromNoMngSetWork(wkNoMngSetWork);
						noMngSetList.Add(noMngSet);
					}
				}
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iNoMngSetDB = null;
				// 通信エラーは-1を戻す
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// 番号管理設定論理削除処理
		/// </summary>
		/// <param name="noMngSet">番号管理設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 番号管理設定情報の論理削除を行います。(未実装)</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public int LogicalDelete(ref NoMngSet noMngSet)
		{
			try
			{
				NoMngSetWork noMngSetWork = CopyToNoMngSetWorkFromNoMngSet(noMngSet);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(noMngSetWork);
				// 番号管理設定論理削除
				int status = this._iNoMngSetDB.LogicalDeleteNoTypeMng(ref parabyte);

				if (status == 0)
				{
					// ファイル名を渡して番号管理設定ワーククラスをデシリアライズする
					noMngSetWork = (NoMngSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoMngSetWork));
					// クラス内メンバコピー
					noMngSet = CopyToNoMngSetFromNoMngSetWork(noMngSetWork);
				}

				return status;
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iNoMngSetDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}

		}

		/// <summary>
		/// 保適照会交付簿管理物理削除処理
		/// </summary>
		/// <param name="noMngSet">番号管理設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 番号管理設定情報の物理削除を行います。(未実装)</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public int Delete(NoMngSet noMngSet)
		{
			try
			{
				NoMngSetWork noMngSetWork = CopyToNoMngSetWorkFromNoMngSet(noMngSet);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(noMngSetWork);
				// 番号管理設定物理削除
				int status = this._iNoMngSetDB.DeleteNoTypeMng(parabyte);

				return status;
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iNoMngSetDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 番号タイプ管理 全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retNoTypeMngList">番号タイプ管理コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 番号タイプ管理の全検索処理を行います。
		///					 論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.11.29</br>
		/// </remarks>
		public int Search(out ArrayList retNoTypeMngList, string enterpriseCode)
		{
			return SearchProc(out retNoTypeMngList, enterpriseCode, 0);			
		}

		/// <summary>
		/// 番号管理設定・番号タイプ管理 全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retNoMngSetList">番号設定コレクション</param>
		/// <param name="retNoTypeMngList">番号タイプ管理コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 番号管理設定と番号タイプ管理の全検索処理を行います。
		///					 論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public int Search(out ArrayList retNoMngSetList, out ArrayList retNoTypeMngList, string enterpriseCode)
		{
			return SearchProc(out retNoMngSetList, out retNoTypeMngList, enterpriseCode, 0);			
		}

		/// <summary>
		/// 番号管理設定・番号タイプ管理 全検索処理（論理削除含む）
		/// </summary>
		/// <param name="retNoMngSetList">番号設定コレクション</param>
		/// <param name="retNoTypeMngList">番号タイプ管理コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 番号管理設定と番号タイプ管理の全検索処理を行います。
		///					 論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public int SearchAll(out ArrayList retNoMngSetList, out ArrayList retNoTypeMngList, string enterpriseCode)
		{
			return SearchProc(out retNoMngSetList, out retNoTypeMngList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// 番号管理設定理論理削除復活処理
		/// </summary>
		/// <param name="noMngSet">番号管理設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 番号管理設定情報の復活を行います。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		public int Revival(ref NoMngSet noMngSet)
		{
			try
			{
				NoMngSetWork noMngSetWork = CopyToNoMngSetWorkFromNoMngSet(noMngSet);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(noMngSetWork);
				// 復活処理
				int status = this._iNoMngSetDB.RevivalLogicalDeleteNoTypeMng(ref parabyte);

				if (status == 0)
				{
					// ファイル名を渡して番号管理設定ワーククラスをデシリアライズする
					noMngSetWork = (NoMngSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(NoMngSetWork));
					// クラス内メンバコピー
					noMngSet = CopyToNoMngSetFromNoMngSetWork(noMngSetWork);
				}

				return status;
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iNoMngSetDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}
		# endregion

		# region ■Private Methods
		/// <summary>
		/// 番号管理設定・番号タイプ管理 検索処理
		/// </summary>
		/// <param name="retNoMngSetList">番号設定コレクション</param>
		/// <param name="retNoTypeMngList">番号タイプ管理コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 番号管理設定の検索処理を行います。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		private int SearchProc(out ArrayList retNoMngSetList, out ArrayList retNoTypeMngList,string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
		{
			// 検索結果Object
			Object retNoMngSetObj;
			Object retNoTypeMngObj;

			retNoMngSetList  = new ArrayList();
			retNoTypeMngList = new ArrayList();

			// 番号管理設定検索
			int status = this._iNoMngSetDB.Search(out retNoMngSetObj, out retNoTypeMngObj, enterpriseCode, 1, logicalMode);

			if ((status == 0) || (status == 9))
			{
				ArrayList wkNoMngSetList  = new ArrayList();
				ArrayList wkNoTypeMngList = new ArrayList();
				ArrayList wkNoMngSet2List  = new ArrayList();
				ArrayList wkNoTypeMng2List = new ArrayList();
				ArrayList wkNoTypeMng3List = new ArrayList();
				Hashtable noTypeMngTable  = new Hashtable();
				NoTypeMng noTypeMng;
				NoMngSet noMngSet;
		
				// 検索結果をArrayListにキャスト
				wkNoMngSetList  = retNoMngSetObj as ArrayList;
				wkNoTypeMngList = retNoTypeMngObj as ArrayList;

				// ワーカークラス→データクラスにキャストして読込み結果コレクションにAdd
				// 番号タイプ管理マスタ
				foreach (NoTypeMngWork noTypeMngWork in wkNoTypeMngList)
				{
					retNoTypeMngList.Add(CopyToNoTypeMngFromNoTypeMngWork(noTypeMngWork));
					
					// 「番号採番範囲」が[0:企業通番（拠点括り無し）]以外のものを取得
					if (noTypeMngWork.NumberingAmbitDivCd != 0)
					{
						wkNoTypeMng2List.Add(CopyToNoTypeMngFromNoTypeMngWork(noTypeMngWork));
					}
					// 「番号採番範囲」が[0:企業通番（拠点括り無し）]のものを取得
					else
					{
						wkNoTypeMng3List.Add(CopyToNoTypeMngFromNoTypeMngWork(noTypeMngWork));
					}
				}

				// 検索用Hash作成
				foreach (NoTypeMng wkNoTypeMng in retNoTypeMngList)
				{
					noTypeMngTable.Add(wkNoTypeMng.NoCode, wkNoTypeMng);
				}

				// 番号管理設定
				foreach (NoMngSetWork noMngSetWork in wkNoMngSetList)
				{
					retNoMngSetList.Add(CopyToNoMngSetFromNoMngSetWork(noMngSetWork));

					// 「番号採番範囲」が[0:企業通番（拠点括り無し）]以外のものを取得
					noTypeMng = (NoTypeMng)noTypeMngTable[noMngSetWork.NoCode];
					
					if (noTypeMng.NumberingAmbitDivCd != 0)
					{
						wkNoMngSet2List.Add(CopyToNoMngSetFromNoMngSetWork(noMngSetWork));
					}
				}

				// 拠点情報と番号管理設定の拠点数が等しいか確認
				foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
				{
					bool existFlg = false;
					for (int ix = 0; ix != wkNoMngSet2List.Count; ix++)
					{
						noMngSet = (NoMngSet)wkNoMngSet2List[ix];
						if (noMngSet.SectionCode.TrimEnd() == secInfoSet.SectionCode.TrimEnd())				
						{
							existFlg = true;
							break;
						}
					}

					if (existFlg == false)
					{
						// 追加結果取得用
						ArrayList noMngSetList = null;

						// 拠点情報に合わせてレコードを追加
						int st = AddNewNoMngSetRecord(out noMngSetList, enterpriseCode, secInfoSet.SectionCode, wkNoMngSet2List, wkNoTypeMng2List, wkNoTypeMng3List);
						
						if (st == 0)
						{
							foreach (NoMngSet wkNoMngSet in noMngSetList)
							{
								retNoMngSetList.Add(wkNoMngSet.Clone());
							}
						}
					}
				}
			}

			return status;
		}

		/// <summary>
		/// 番号タイプ管理 検索処理
		/// </summary>
		/// <param name="retNoTypeMngList">番号タイプ管理コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 番号タイプ管理の検索処理を行います。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.11.29</br>
		/// </remarks>
		private int SearchProc(out ArrayList retNoTypeMngList,string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
		{
			int status = 0;
			
			// 検索結果Object
			Object retNoTypeMngObj;
			// パラメータ
			NoTypeMngWork noTypeMngWork = new NoTypeMngWork();
			noTypeMngWork.EnterpriseCode = enterpriseCode;
			Object paraObj = noTypeMngWork as Object;
			
			retNoTypeMngList = new ArrayList();

			// staticに無い場合
			if (_noTypeMngArray.Count == 0)
			{
				// 番号管理設定検索
				status = this._iNoMngSetDB.SearchNoTypeMng(out retNoTypeMngObj, paraObj, 0, logicalMode);

				if (status == 0)
				{
					ArrayList wkNoTypeMngList = new ArrayList();

					// 検索結果をArrayListにキャスト
					wkNoTypeMngList = retNoTypeMngObj as ArrayList;

					// ワーカークラス→データクラスにキャストして読込み結果コレクションにAdd
					// 番号タイプ管理マスタ
					foreach (NoTypeMngWork noTypeMngWorkwk in wkNoTypeMngList)
					{
						NoTypeMng noTypeMng = CopyToNoTypeMngFromNoTypeMngWork(noTypeMngWorkwk);

						// 戻りListへセット
						retNoTypeMngList.Add(noTypeMng);
						// staticに保持
						_noTypeMngArray.Add(noTypeMng);
					}
				}
			}
			// staticに保持している場合
			else
			{
				retNoTypeMngList = (ArrayList)_noTypeMngArray.Clone();
			}

			return status;
		}

		/// <summary>
		/// クラスメンバーコピー処理（番号管理設定ワーククラス⇒番号管理設定クラス）
		/// </summary>
		/// <param name="noMngSetWork">番号管理設定ワーククラス</param>
		/// <returns>番号管理設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 番号管理設定ワーククラスから番号管理設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		private NoMngSet CopyToNoMngSetFromNoMngSetWork(NoMngSetWork noMngSetWork)
		{
			NoMngSet noMngSet = new NoMngSet();

			//共通ヘッダ部
			noMngSet.CreateDateTime		= noMngSetWork.CreateDateTime;
			noMngSet.UpdateDateTime		= noMngSetWork.UpdateDateTime;
			noMngSet.EnterpriseCode		= noMngSetWork.EnterpriseCode;
			noMngSet.FileHeaderGuid		= noMngSetWork.FileHeaderGuid;
			noMngSet.UpdEmployeeCode	= noMngSetWork.UpdEmployeeCode;
			noMngSet.UpdAssemblyId1		= noMngSetWork.UpdAssemblyId1;
			noMngSet.UpdAssemblyId2		= noMngSetWork.UpdAssemblyId2;
			noMngSet.LogicalDeleteCode	= noMngSetWork.LogicalDeleteCode;

			noMngSet.SectionCode		= noMngSetWork.SectionCode;	
			noMngSet.NoCode				= noMngSetWork.NoCode;			
			noMngSet.NoPresentVal		= noMngSetWork.NoPresentVal;
			noMngSet.SettingStartNo		= noMngSetWork.SettingStartNo;	
			noMngSet.SettingEndNo		= noMngSetWork.SettingEndNo;	
			noMngSet.NoIncDecWidth		= noMngSetWork.NoIncDecWidth;

			return noMngSet;
		}

		/// <summary>
		/// クラスメンバーコピー処理（番号管理設定クラス⇒番号管理設定ワーククラス）
		/// </summary>
		/// <param name="noMngSet">番号管理設定ワーククラス</param>
		/// <returns>番号管理設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 番号管理設定クラスから番号管理設定ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		private NoMngSetWork CopyToNoMngSetWorkFromNoMngSet(NoMngSet noMngSet)
		{
			NoMngSetWork noMngSetWork = new NoMngSetWork();

			noMngSetWork.CreateDateTime	   = noMngSet.CreateDateTime;
			noMngSetWork.UpdateDateTime	   = noMngSet.UpdateDateTime;
			noMngSetWork.EnterpriseCode	   = noMngSet.EnterpriseCode;
			noMngSetWork.FileHeaderGuid	   = noMngSet.FileHeaderGuid;
			noMngSetWork.UpdEmployeeCode   = noMngSet.UpdEmployeeCode;
			noMngSetWork.UpdAssemblyId1	   = noMngSet.UpdAssemblyId1;
			noMngSetWork.UpdAssemblyId2	   = noMngSet.UpdAssemblyId2;
			noMngSetWork.LogicalDeleteCode = noMngSet.LogicalDeleteCode;

			noMngSetWork.SectionCode	   = noMngSet.SectionCode;	
			noMngSetWork.NoCode			   = noMngSet.NoCode;			
			noMngSetWork.NoPresentVal	   = noMngSet.NoPresentVal;
			noMngSetWork.SettingStartNo	   = noMngSet.SettingStartNo;
			noMngSetWork.SettingEndNo	   = noMngSet.SettingEndNo;	
			noMngSetWork.NoIncDecWidth	   = noMngSet.NoIncDecWidth;

			return noMngSetWork;
		}

		/// <summary>
		/// クラスメンバーコピー処理（番号タイプ管理ワーククラス⇒番号タイプ管理クラス）
		/// </summary>
		/// <param name="noTypeMngWork">番号タイプ管理ワーククラス</param>
		/// <returns>番号タイプ管理クラス</returns>
		/// <remarks>
		/// <br>Note       : 番号タイプ管理ワーククラスから番号タイプ管理クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		private NoTypeMng CopyToNoTypeMngFromNoTypeMngWork(NoTypeMngWork noTypeMngWork)
		{
			NoTypeMng noTypeMng = new NoTypeMng();

			//共通ヘッダ部
			noTypeMng.CreateDateTime	  = noTypeMngWork.CreateDateTime;
			noTypeMng.UpdateDateTime	  = noTypeMngWork.UpdateDateTime;
			noTypeMng.EnterpriseCode	  = noTypeMngWork.EnterpriseCode;
			noTypeMng.FileHeaderGuid	  = noTypeMngWork.FileHeaderGuid;
			noTypeMng.UpdEmployeeCode	  = noTypeMngWork.UpdEmployeeCode;
			noTypeMng.UpdAssemblyId1	  = noTypeMngWork.UpdAssemblyId1;
			noTypeMng.UpdAssemblyId2	  = noTypeMngWork.UpdAssemblyId2;
			noTypeMng.LogicalDeleteCode   = noTypeMngWork.LogicalDeleteCode;

			noTypeMng.NoCode			  = noTypeMngWork.NoCode;			 		   	
			noTypeMng.NoName			  = noTypeMngWork.NoName;			 	       
			noTypeMng.NoItemPatternCd	  = noTypeMngWork.NoItemPatternCd;	
			noTypeMng.NoCharcterCount	  = noTypeMngWork.NoCharcterCount;	
			noTypeMng.ConsNoCharcterCount = noTypeMngWork.ConsNoCharcterCount;	
			noTypeMng.NoDispPositionDivCd = noTypeMngWork.NoDispPositionDivCd;		   	
			noTypeMng.NumberingDivCd	  = noTypeMngWork.NumberingDivCd;
			noTypeMng.NumberingTypeDivCd  = noTypeMngWork.NumberingTypeDivCd;
			noTypeMng.NumberingAmbitDivCd = noTypeMngWork.NumberingAmbitDivCd;
			noTypeMng.NoResetTimingDivCd  = noTypeMngWork.NoResetTimingDivCd;

			return noTypeMng;
		}

		/// <summary>
		/// クラスメンバーコピー処理（番号タイプ管理クラス⇒ワーククラス番号タイプ管理）
		/// </summary>
		/// <param name="noTypeMng">番号タイプ管理ワーククラス</param>
		/// <returns>番号タイプ管理クラス</returns>
		/// <remarks>
		/// <br>Note       : クラスから番番号タイプ番号タイプ管理ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.08</br>
		/// </remarks>
		private NoTypeMngWork CopyToNoTypeMngWorkFromNoTypeMng(NoTypeMng noTypeMng)
		{
			NoTypeMngWork noTypeMngWork = new NoTypeMngWork();

			noTypeMngWork.CreateDateTime	  = noTypeMng.CreateDateTime;
			noTypeMngWork.UpdateDateTime	  = noTypeMng.UpdateDateTime;
			noTypeMngWork.EnterpriseCode	  = noTypeMng.EnterpriseCode;
			noTypeMngWork.FileHeaderGuid	  = noTypeMng.FileHeaderGuid;
			noTypeMngWork.UpdEmployeeCode	  = noTypeMng.UpdEmployeeCode;
			noTypeMngWork.UpdAssemblyId1	  = noTypeMng.UpdAssemblyId1;
			noTypeMngWork.UpdAssemblyId2	  = noTypeMng.UpdAssemblyId2;
			noTypeMngWork.LogicalDeleteCode	  = noTypeMng.LogicalDeleteCode;

			noTypeMngWork.NoCode			  = noTypeMng.NoCode;			 		   	
			noTypeMngWork.NoName			  = noTypeMng.NoName;			 	       
			noTypeMngWork.NoItemPatternCd	  = noTypeMng.NoItemPatternCd;			 	       
			noTypeMngWork.NoCharcterCount	  = noTypeMng.NoCharcterCount;			 	       
			noTypeMngWork.ConsNoCharcterCount = noTypeMng.ConsNoCharcterCount;	
			noTypeMngWork.NoDispPositionDivCd = noTypeMng.NoDispPositionDivCd;		   	
			noTypeMngWork.NumberingDivCd	  = noTypeMng.NumberingDivCd;
			noTypeMngWork.NumberingTypeDivCd  = noTypeMng.NumberingTypeDivCd;
			noTypeMngWork.NumberingAmbitDivCd = noTypeMng.NumberingAmbitDivCd;
			noTypeMngWork.NoResetTimingDivCd  = noTypeMng.NoResetTimingDivCd;

			return noTypeMngWork;
		}
		
		/// <summary>
		/// 番号管理設定追加処理
		/// </summary>
		/// <param name="noMngSetList">番号管理設定オブジェクトLIST</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="wkNoMngSetList">番号管理設定List</param>
		/// <param name="wkNoTypeSetList">番号タイプ管理List(拠点括り有り分)</param>
		/// <param name="wkNoTypeSet2List">番号タイプ管理List(拠点括り無し分)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 番号管理設定レコードを追加します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.14</br>
		/// </remarks>
		private int AddNewNoMngSetRecord(out ArrayList noMngSetList, string enterpriseCode, string sectionCode, ArrayList wkNoMngSetList, ArrayList wkNoTypeSetList, ArrayList wkNoTypeSet2List)
		{
			NoTypeMng noTypeMng = new NoTypeMng();
			noMngSetList = new ArrayList();
			NoMngSet[] noMngSets = new NoMngSet[wkNoTypeSetList.Count];
			// キー項目セット
			for (int ix = 0; ix != noMngSets.Length; ix++)
			{
				noTypeMng = (NoTypeMng)wkNoTypeSetList[ix];
				noMngSets[ix] = new NoMngSet();
				noMngSets[ix].EnterpriseCode	= enterpriseCode;
				noMngSets[ix].SectionCode		= sectionCode;
				noMngSets[ix].NoCode			= noTypeMng.NoCode;
				noMngSets[ix].NoPresentVal		= 0;
				noMngSets[ix].SettingStartNo	= 0;
				noMngSets[ix].SettingEndNo		= 0;
				noMngSets[ix].NoIncDecWidth		= 0;
			}

			noMngSetList.AddRange(noMngSets);

			// 初回時のみ
			if (wkNoMngSetList.Count == 0)
			{
				foreach (NoTypeMng wkNoTypeMng in wkNoTypeSet2List)
				{
					NoMngSet noMngSet = new NoMngSet();
					noMngSet.EnterpriseCode		= enterpriseCode;
                    // 2008.09.23 30413 犬飼 拠点コードは2桁に修正 >>>>>>START
                    noMngSet.SectionCode = "000000";
                    //noMngSet.SectionCode = "00";
                    // 2008.09.23 30413 犬飼 拠点コードは2桁に修正 <<<<<<END
                    noMngSet.NoCode = wkNoTypeMng.NoCode;
					noMngSet.NoPresentVal		= 0;
					noMngSet.SettingStartNo		= 0;
					noMngSet.SettingEndNo		= 0;
					noMngSet.NoIncDecWidth		= 0;
					
					noMngSetList.Add(noMngSet);
				}
			}

			// 新規登録処理
			int status = this.Write(ref noMngSetList);
			return status;
		}
		# endregion
	}
}
