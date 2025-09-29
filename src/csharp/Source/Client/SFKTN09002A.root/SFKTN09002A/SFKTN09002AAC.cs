using System;
using System.Collections;
// 2008.02.08 96012 ローカルＤＢ参照対応 Begin
using System.Collections.Generic;
using System.Text;
// 2008.02.08 96012 ローカルＤＢ参照対応 end
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
// 2008.02.08 96012 ローカルＤＢ参照対応 Begin
using Broadleaf.Application.LocalAccess;
// 2008.02.08 96012 ローカルＤＢ参照対応 end

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 拠点情報テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 拠点情報テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2004.03.22</br>
	/// <br></br>
    /// <br>Update Note: 2005.06.21 22025 當間 豊</br>
    /// <br>					・保存時にスペースカット対応</br>
    /// <br>Update Note: 2006.12.13 22022 段上 知子</br>
    /// <br>					1.SF版を流用し携帯版を作成</br>
    /// <br>					2.自社名称1を必須入力へ変更</br>
    /// <br>Update Note: 2007.05.23 980023 飯谷 耕平</br>
    /// <br>               ・拠点情報の取得先をリモートに修正</br>
    /// <br>Update Note: 2007.05.29 22022 段上 知子</br>
    /// <br>					1.自社名称コードが論理削除・未登録だった場合の表示名称の仕様変更</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
    /// <br>           : ローカルＤＢ参照対応</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.12 96012　日色 馨</br>
    /// <br>           : ローカルＤＢ参照対応(拠点情報)</br>
	/// -----------------------------------------------------------------------
	/// <br>UpdateNote : 2008.02.18 30167　上野 弘貴</br>
	/// <br>           : 全社拠点コードをスペースから"000000"へ変更</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008/06/03 30414　忍　幸史</br>
    /// <br>           :「拠点略称」「導入年月日」追加、「他拠点伝票自社名印刷区分」「予備２～１０」削除</br>
    /// </remarks>
	public class SecInfoSetAcs : IGeneralGuideData
	{

		/// <summary>リモートオブジェクト格納バッファ</summary>
		private ISecInfoSetDB _iSecInfoSetDB = null;
        // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
        private SectionInfoLcDB _sectionInfoLcDB = null;
        private static bool _isLocalDBRead = false;
        // 2008.02.08 96012 ローカルＤＢ参照対応 end

		/// <summary>自社名称格納バッファ</summary>
		private Hashtable _companyNmTable = null;

        /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
        // ↓ 2007.10.5 add///////////////////////////////
        /// <summary>拠点倉庫名称格納バッファ</summary>
        private Hashtable _sectWarehouseNmTable = null;
        // ↑ 2007.10.5 add//////////////////////////////
           --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/
        
        // 2005.12.15 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
		private SecInfoAcs _secInfoAcs;
		// 2005.12.15 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

        // --- ADD 2008/12/11 --------------------------------------------------------------------->>>>>
        private WarehouseAcs _warehouseAcs;

        private Dictionary<string, Warehouse> _warehouseDic;
        // --- ADD 2008/12/11 ---------------------------------------------------------------------<<<<<

        // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        // 2008.02.08 96012 ローカルＤＢ参照対応 end

        /// <summary>
		/// 拠点情報テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 拠点情報テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.12 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応(拠点情報)</br>
        /// </remarks>
		public SecInfoSetAcs()
		{
            // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) Begin
            //// 2005.12.15 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //// ----- iitani c ----- start 2007.05.23
            ////this._secInfoAcs = new SecInfoAcs();
            //this._secInfoAcs = new SecInfoAcs(1);   // searchMode(0: 1:)
            //// ----- iitani c ----- end 2007.05.23
            //// 2005.12.15 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) end

			this._companyNmTable = null;

			try
			{
				// リモートオブジェクト取得
				this._iSecInfoSetDB = (ISecInfoSetDB)MediationSecInfoSetDB.GetSecInfoSetDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
				this._iSecInfoSetDB = null;
			}
            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            // ローカルDBアクセスオブジェクト取得
            this._sectionInfoLcDB = new SectionInfoLcDB();
            // 2008.02.08 96012 ローカルＤＢ参照対応 end

            // --- ADD 2008/12/11 --------------------------------------------------------------------->>>>>
            this._warehouseAcs = new WarehouseAcs();
            ReadWarehouse();
            // --- ADD 2008/12/11 ---------------------------------------------------------------------<<<<<
        }

        // --- ADD 2008/12/11 --------------------------------------------------------------------->>>>>
        private void ReadWarehouse()
        {
            this._warehouseDic = new Dictionary<string, Warehouse>();

            ArrayList retList;

            try
            {
                int status = this._warehouseAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (Warehouse warehouse in retList)
                    {
                        if (warehouse.LogicalDeleteCode == 0)
                        {
                            this._warehouseDic.Add(warehouse.WarehouseCode.Trim(), warehouse);
                        }
                    }
                }
            }
            catch
            {
                this._warehouseDic = new Dictionary<string, Warehouse>();
            }
        }
        // --- ADD 2008/12/11 ---------------------------------------------------------------------<<<<<

        // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) Begin
        /// <summary>
        /// ローカルＤＢ対応拠点情報クラス作成処理
        /// </summary>
        /// <returns>Boolean</returns>
        /// <remarks>
        /// <br>Note       : 拠点情報クラス作成を未作成時に作成します。</br>
        /// <br>Programmer : 96012 日色　馨</br>
        /// <br>Date       : 2008.02.12</br>
        /// </remarks>
        private Boolean ConstructSecInfoAcs()
        {
            if (this._secInfoAcs == null)
            {
                this._secInfoAcs = new SecInfoAcs(_isLocalDBRead ? 0 : 1);
                this._secInfoAcs.ResetSectionInfo();
                if (this._secInfoAcs != null)
                {
                    return true;
                }
            }
            return false;
        }
        // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) end

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
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iSecInfoSetDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// 拠点情報読み込み処理
		/// </summary>
		/// <param name="secInfoSet">拠点情報オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報を読み込みます。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
		public int Read(out SecInfoSet secInfoSet, string enterpriseCode, string sectionCode)
		{			
			try
			{
				secInfoSet = null;
				SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
				secInfoSetWork.EnterpriseCode = enterpriseCode;
				secInfoSetWork.SectionCode = sectionCode;

                // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
                //// XMLへ変換し、文字列のバイナリ化
				//byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);
                //
				////従業員読み込み
				//int status = this._iSecInfoSetDB.Read(ref parabyte,0);
                //
				//if (status == 0)
				//{
				//	// XMLの読み込み
				//	secInfoSetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));
				//	// クラス内メンバコピー
				//	secInfoSet = CopyToSecInfoSetFromSecInfoSetWork(secInfoSetWork);
				//}
                int status;
                if (_isLocalDBRead)
                {
                    //従業員読み込み
                    status = this._sectionInfoLcDB.Read(ref secInfoSetWork, 0);
                    if (status == 0)
                    {
                        // クラス内メンバコピー
                        secInfoSet = CopyToSecInfoSetFromSecInfoSetWork(secInfoSetWork);
                    }
                }
                else
                {
                    // XMLへ変換し、文字列のバイナリ化
                    byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);
                    
                    //従業員読み込み
                    status = this._iSecInfoSetDB.Read(ref parabyte,0);
                    if (status == 0)
                    {
                    	// XMLの読み込み
                    	secInfoSetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));
                    	// クラス内メンバコピー
                    	secInfoSet = CopyToSecInfoSetFromSecInfoSetWork(secInfoSetWork);
                    }
                }
                // 2008.02.08 96012 ローカルＤＢ参照対応 end
				
				return status;
			}
			catch (Exception)
			{				
				//通信エラーは-1を戻す
				secInfoSet = null;
				//オフライン時はnullをセット
				this._iSecInfoSetDB = null;
				return -1;
			}
		}

		/// <summary>
		/// 拠点情報クラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>拠点情報クラス</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報クラスをデシリアライズします。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public SecInfoSet Deserialize(string fileName)
		{
			SecInfoSet secInfoSet = null;

			// ファイル名を渡して拠点情報ワーククラスをデシリアライズする
			SecInfoSetWork secInfoSetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(fileName,typeof(SecInfoSetWork));

			//デシリアライズ結果を拠点情報クラスへコピー
			if (secInfoSetWork != null) secInfoSet = CopyToSecInfoSetFromSecInfoSetWork(secInfoSetWork);

			return secInfoSet;
		}

		/// <summary>
		/// 拠点情報Listクラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>拠点情報クラスLIST</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報リストクラスをデシリアライズします。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();
			al.Clear();

			// ファイル名を渡して拠点情報ワーククラスをデシリアライズする
			SecInfoSetWork[] secInfoSetWorks;
			secInfoSetWorks = (SecInfoSetWork[])XmlByteSerializer.Deserialize(fileName,typeof(SecInfoSetWork[]));

			//デシリアライズ結果を拠点情報クラスへコピー
			if (secInfoSetWorks != null) 
			{
				al.Capacity = secInfoSetWorks.Length;
				for(int i=0; i < secInfoSetWorks.Length; i++)
				{
					al.Add(CopyToSecInfoSetFromSecInfoSetWork(secInfoSetWorks[i]));
				}
			}

			return al;
		}

		/// <summary>
		/// 拠点情報登録・更新処理
		/// </summary>
		/// <param name="secInfoSet">拠点情報クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報の登録・更新を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Write(ref SecInfoSet secInfoSet)
		{
			//拠点情報クラスから拠点情報ワーカークラスにメンバコピー
			SecInfoSetWork secInfoSetWork = CopyToSecInfoSetWorkFromSecInfoSet(secInfoSet);

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);

			int status = 0;
			try
			{
				//拠点情報書き込み
				status = this._iSecInfoSetDB.Write(ref parabyte);
				if (status == 0)
				{
					// ファイル名を渡して拠点情報ワーククラスをデシリアライズする
					secInfoSetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));
					// クラス内メンバコピー
					secInfoSet = CopyToSecInfoSetFromSecInfoSetWork(secInfoSetWork);

                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) end

                    return 0;
                    // 2006.09.01 N.TANIFUJI ADD
                    //status = this._secInfoAcs.ResetSectionInfo();
                }

			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iSecInfoSetDB = null;
				//通信エラーは-1を戻す
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// 拠点情報シリアライズ処理
		/// </summary>
		/// <param name="secInfoSet">シリアライズ対象拠点情報クラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 拠点情報のシリアライズを行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void Serialize(SecInfoSet secInfoSet, string fileName)
		{
			//拠点情報クラスから拠点情報ワーカークラスにメンバコピー
			SecInfoSetWork secInfoSetWork = CopyToSecInfoSetWorkFromSecInfoSet(secInfoSet);
			//拠点情報ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(secInfoSetWork,fileName);
		}

		/// <summary>
		/// 拠点情報Listシリアライズ処理
		/// </summary>
		/// <param name="secInfoSetList">シリアライズ対象拠点情報Listクラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 拠点情報List情報のシリアライズを行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void ListSerialize(ArrayList secInfoSetList, string fileName)
		{
			SecInfoSetWork[] secInfoSetWorks = new SecInfoSetWork[secInfoSetList.Count];
			for(int i= 0; i < secInfoSetList.Count; i++)
			{
				secInfoSetWorks[i] = CopyToSecInfoSetWorkFromSecInfoSet((SecInfoSet)secInfoSetList[i]);
			}
			//拠点情報ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(secInfoSetWorks,fileName);
		}

		/// <summary>
		/// 拠点情報論理削除処理
		/// </summary>
		/// <param name="secInfoSet">拠点情報オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報の論理削除を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int LogicalDelete(ref SecInfoSet secInfoSet)
		{
			try
			{
				SecInfoSetWork secInfoSetWork = CopyToSecInfoSetWorkFromSecInfoSet(secInfoSet);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);
				// 拠点情報論理削除
				int status = this._iSecInfoSetDB.LogicalDelete(ref parabyte);

				if (status == 0)
				{
					// ファイル名を渡して拠点情報ワーククラスをデシリアライズする
					secInfoSetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));
					// クラス内メンバコピー
					secInfoSet = CopyToSecInfoSetFromSecInfoSetWork(secInfoSetWork);

                    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) end

                    // 2006.09.01 N.TANIFUJI ADD
                    this._secInfoAcs.ResetSectionInfo();
                       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                }

				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iSecInfoSetDB = null;
				//通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 拠点情報物理削除処理
		/// </summary>
		/// <param name="secInfoSet">拠点情報オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報の物理削除を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Delete(SecInfoSet secInfoSet)
		{
			try
			{
				SecInfoSetWork secInfoSetWork = CopyToSecInfoSetWorkFromSecInfoSet(secInfoSet);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);
				// 拠点情報物理削除
				int status = this._iSecInfoSetDB.Delete(parabyte);

                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) Begin
                ConstructSecInfoAcs();
                // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) end

                // 2006.09.01 N.TANIFUJI ADD
                this._secInfoAcs.ResetSectionInfo();
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                
                return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iSecInfoSetDB = null;
				//通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 拠点情報検索処理（論理削除除く）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int GetCnt(out int retTotalCnt, string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt, enterpriseCode,0);
		}

		/// <summary>
		/// 拠点情報検索処理（論理削除含む）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int GetAllCnt(out int retTotalCnt, string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// 拠点情報数検索処理
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:全ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報数の検索を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
		private int GetCntProc(out int retTotalCnt, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
		{
			SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
			secInfoSetWork.EnterpriseCode = enterpriseCode;

            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            //// XMLへ変換し、文字列のバイナリ化
			//byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);
            //
			//// 拠点情報検索
			//int status = this._iSecInfoSetDB.SearchCnt(out retTotalCnt,parabyte,0,logicalMode);
            int status;
            if (_isLocalDBRead)
            {
                List<SecInfoSetWork> workList = new List<SecInfoSetWork>();
                // 拠点情報検索
                status = this._sectionInfoLcDB.Search(out workList, secInfoSetWork, 0, logicalMode);
                retTotalCnt = workList.Count;
            }
            else
            {
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);
                
                // 拠点情報検索
                status = this._iSecInfoSetDB.SearchCnt(out retTotalCnt,parabyte,0,logicalMode);
            }
            // 2008.02.08 96012 ローカルＤＢ参照対応 end

			if (status != 0) retTotalCnt = 0;
				
			return status;
		}


		/// <summary>
		/// 拠点情報全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報の全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Search(out ArrayList retList, string enterpriseCode)
		{
			bool nextData;
			int  retTotalCnt;
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, null);
		}

		/// <summary>
		/// 拠点情報検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList, string enterpriseCode)
		{

			bool nextData;
			int	 retTotalCnt;
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null);
		}

		/// <summary>
		/// 件数指定拠点情報検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevSecInfoSet">前回最終拠点情報データオブジェクト（初回はnull指定必須）</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して拠点情報の検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Search(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, SecInfoSet prevSecInfoSet)
		{			
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, readCnt, prevSecInfoSet);
		}

		/// <summary>
		/// 件数指定拠点情報検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevSecInfoSet">前回最終拠点情報データオブジェクト（初回はnull指定必須）</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して拠点情報の検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, SecInfoSet prevSecInfoSet)
		{			
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, readCnt, prevSecInfoSet);
		}

		/// <summary>
		/// 拠点情報論理削除復活処理
		/// </summary>
		/// <param name="secInfoSet">拠点情報オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報の復活を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Revival(ref SecInfoSet secInfoSet)
		{
			try
			{
				SecInfoSetWork secInfoSetWork = CopyToSecInfoSetWorkFromSecInfoSet(secInfoSet);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);
				// 復活処理
				int status = this._iSecInfoSetDB.RevivalLogicalDelete(ref parabyte);

				if (status == 0)
				{
					// ファイル名を渡して拠点情報ワーククラスをデシリアライズする
					secInfoSetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));
					// クラス内メンバコピー
					secInfoSet = CopyToSecInfoSetFromSecInfoSetWork(secInfoSetWork);

                    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) end

                    // 2006.09.01 N.TANIFUJI ADD
                    this._secInfoAcs.ResetSectionInfo();
                       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                }

				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iSecInfoSetDB = null;
				//通信エラーは-1を戻す
				return -1;
			}
		}


		/// <summary>
		/// 拠点情報検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
		/// <param name="prevSecInfoSet">前回最終拠点情報データオブジェクト（初回はnull指定必須）</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報の検索処理を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
		private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, SecInfoSet prevSecInfoSet)
		{
			SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
			if (prevSecInfoSet != null) secInfoSetWork = CopyToSecInfoSetWorkFromSecInfoSet(prevSecInfoSet);
			secInfoSetWork.EnterpriseCode = enterpriseCode;
			
			//次データ有無初期化
			nextData = false;
			//0で初期化
			retTotalCnt = 0;

			SecInfoSetWork[] al;
			retList = new ArrayList();
			retList.Clear();

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);

			byte[] retbyte;

			// 拠点情報検索
			int status = 0;
            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            //if (readCnt == 0)
			//{
			//	status = this._iSecInfoSetDB.Search(out retbyte,parabyte,0,logicalMode);
			//}
			//else
			//{
			//	status = this._iSecInfoSetDB.SearchSpecification(out retbyte,out retTotalCnt,out nextData,parabyte,0,logicalMode,readCnt);
			//}
            //
			//if (status == 0)
			//{
			//	// XMLの読み込み
			//	al = (SecInfoSetWork[])XmlByteSerializer.Deserialize(retbyte,typeof(SecInfoSetWork[]));
            //
			//	for(int i = 0;i < al.Length;i++)
			//	{
			//		//サーチ結果取得
			//		SecInfoSetWork wkSecInfoSetWork = (SecInfoSetWork)al[i];
			//		//拠点情報クラスへメンバコピー
			//		retList.Add(CopyToSecInfoSetFromSecInfoSetWork(wkSecInfoSetWork));
			//	}
			//}
            if (_isLocalDBRead)
            {
                List<SecInfoSetWork> workList = new List<SecInfoSetWork>();
                // 拠点情報検索
                status = this._sectionInfoLcDB.Search(out workList, secInfoSetWork, 0, logicalMode);
                if (status == 0)
                {
                    //拠点情報クラスへメンバコピー
                    for (int i = 0; i < workList.Count; i++)
                    {
                        //拠点情報クラスへメンバコピー
                        retList.Add(CopyToSecInfoSetFromSecInfoSetWork(workList[i]));
                    }
                }
            }
            else
            {
                if (readCnt == 0)
                {
                	status = this._iSecInfoSetDB.Search(out retbyte,parabyte,0,logicalMode);
                }
                else
                {
                	status = this._iSecInfoSetDB.SearchSpecification(out retbyte,out retTotalCnt,out nextData,parabyte,0,logicalMode,readCnt);
                }
                if (status == 0)
                {
                	// XMLの読み込み
                	al = (SecInfoSetWork[])XmlByteSerializer.Deserialize(retbyte,typeof(SecInfoSetWork[]));
                	for(int i = 0;i < al.Length;i++)
                	{
                		//サーチ結果取得
                		SecInfoSetWork wkSecInfoSetWork = (SecInfoSetWork)al[i];
                		//拠点情報クラスへメンバコピー
                		retList.Add(CopyToSecInfoSetFromSecInfoSetWork(wkSecInfoSetWork));
                	}
                }
            }
            // 2008.02.08 96012 ローカルＤＢ参照対応 end
            //全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

		/// <summary>
		/// 拠点情報検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="dispAllSecInfo">"全社"設定有無[true:設定,false:未設定]</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報の検索処理を行い、取得結果をDataSetで返します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Search(ref DataSet ds, string enterpriseCode, bool dispAllSecInfo)
		{
			SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
			secInfoSetWork.EnterpriseCode = enterpriseCode;
            ArrayList ar = new ArrayList();
            
            // XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);

			byte[] retbyte;

            SecInfoSet[] secInfoSets;
			// 従業員サーチ
            int status = 0;
			// 2005.12.15 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//          int i;
//          SecInfoSetWork[] secInfoSetWorks;
//			int status = this._iSecInfoSetDB.Search(out retbyte, parabyte, 0,0);
			// 2005.12.15 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END





            if (status == 0)
            {
                // "全社"表示制御判定
                if (dispAllSecInfo)
                {
                    SecInfoSet secInfoSet = new SecInfoSet();
                    
                    secInfoSet.EnterpriseCode = enterpriseCode;

					//----- ueno upd ---------- start 2008.02.18
					// 全社共通拠点コードは"000000"を設定する
                    //secInfoSet.SectionCode    = "            ";
					secInfoSet.SectionCode = "00";
					//----- ueno upd ---------- end 2008.02.18

                    secInfoSet.SectionGuideNm = "全社";
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//					secInfoSet.CompanyName1   = "全社";
//					secInfoSet.CompanyName2   = "　　　　　　　　　　　　　　　　　　　　";
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
            
                    ar.Add(secInfoSet.Clone());
                }


                // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) Begin
                ConstructSecInfoAcs();
                // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) end

                // 2005.12.15 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                // XMLの読込み
//              secInfoSetWorks = (SecInfoSetWork[])XmlByteSerializer.Deserialize(retbyte,typeof(SecInfoSetWork[]));
//              for(i = 0;i<secInfoSetWorks.Length;i++)
//              {
//                  // サーチ結果取得
//                  SecInfoSetWork wkSecInfoSetWork = (SecInfoSetWork)secInfoSetWorks[i];
//					ar.Add(CopyToSecInfoSetFromSecInfoSetWork(wkSecInfoSetWork).Clone());
//              }
				// 2005.12.15 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            
				// 2005.12.15 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				ArrayList secarrlist = new ArrayList();
				for (int idx = 0; idx<this._secInfoAcs.SecInfoSetList.Length; idx++)
				{
					ar.Add(this._secInfoAcs.SecInfoSetList[idx].Clone());

				}
				// 2005.12.15 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

                if (ar.Count != 0)
                {
                    secInfoSets = (SecInfoSet[])ar.ToArray(typeof(SecInfoSet));
                    retbyte = XmlByteSerializer.Serialize(secInfoSets);
                    XmlByteSerializer.ReadXml(ref ds ,retbyte);
                } 
                else 
                {
                    status = 4;
                }
            }
				
			return status;
		}

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
		/// <summary>
		/// 自社名称１・２取得処理
		/// </summary>
		/// <param name="companyName1">自社名称１</param>
		/// <param name="companyName2">自社名称２</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="companyNameCd">自社名称コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社名称コードから自社名称１と２を取得します</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.13</br>
		/// </remarks>
		public int GetCompanyName( out string companyName1, out string companyName2, string enterpriseCode, int companyNameCd )
		{
			int status = 0;
			CompanyNm companyNm = null;
            
			companyName1 = "";
			companyName2 = "";

			if( companyNameCd > 0 ) {

				// 自社名称読み込み
				status = ReadCompanyNm( out companyNm, enterpriseCode, companyNameCd );
				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					if( companyNm.LogicalDeleteCode == 0 ) {
						companyName1 = companyNm.CompanyName1;
						companyName2 = companyNm.CompanyName2;
					}
					else {
                        companyName1 = "削除済";
                        // 2007.05.29 DANJO CHG  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                        companyName2 = "";
                        //companyName2 = "削除済";
                        // 2007.05.29 DANJO CHG  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
						status = -1;
					}
				}
				else {
                    companyName1 = "未登録";
                    // 2007.05.29 DANJO CHG  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                    companyName2 = "";
                    //companyName2 = "未登録";
                    // 2007.05.29 DANJO CHG  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
				}
			}

			return status;
		}

		/// <summary>
		/// 自社名称読込処理
		/// </summary>
		/// <param name="companyNm">自社名称オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="companyNameCd">自社名称コード</param>
		/// <returns>STATUS</returns>
		public int ReadCompanyNm( out CompanyNm companyNm, string enterpriseCode, int companyNameCd )
		{
			int status = 0;
			companyNm = null;

//			if( this._companyNmTable == null ) {
				status = SetCompanyNmTable( enterpriseCode );
				if( status != ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					// 読み込み失敗
					return status;
				}
//			}

			// テーブルにキーが存在している
			if( this._companyNmTable.ContainsKey( companyNameCd ) == true ) {
				companyNm = ( ( CompanyNm )this._companyNmTable[ companyNameCd ] ).Clone();
			}
			else {
				status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}

			return status;
		}

		/// <summary>
		/// 自社名称検索処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社名称の検索処理を行い、バッファに格納します。</br>
		/// <br>Programmer : 秋山　亮介</br>
		/// <br>Date       : 2005.09.13</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
		private int SetCompanyNmTable( string enterpriseCode )
		{
			
            //this._companyNmTable = new Hashtable();
            //CompanyNmAcs companyNmAcs = new CompanyNmAcs();
            //ArrayList retList = null;
            //this._companyNmTable.Clear();
            //int status = companyNmAcs.SearchAll( out retList, enterpriseCode );
            //if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
            //    foreach( CompanyNm companyNm in retList ) {
            //        if( this._companyNmTable.ContainsKey( companyNm.CompanyNameCd ) == false ) {
            //            this._companyNmTable.Add( companyNm.CompanyNameCd, companyNm.Clone() );
            //        }
            //    }
            //}


            // 2006.09.08 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (this._companyNmTable == null)
            {
                this._companyNmTable = new Hashtable();
                CompanyNmAcs companyNmAcs = new CompanyNmAcs();
                // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
                companyNmAcs.IsLocalDBRead = _isLocalDBRead;
                // 2008.02.08 96012 ローカルＤＢ参照対応 end
                ArrayList retList = null;
                this._companyNmTable.Clear();
                status = companyNmAcs.SearchAll(out retList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (CompanyNm companyNm in retList)
                    {
                        if (this._companyNmTable.ContainsKey(companyNm.CompanyNameCd) == false)
                        {
                            this._companyNmTable.Add(companyNm.CompanyNameCd, companyNm.Clone());
                        }
                    }
                }
            }
            // 2006.09.08 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
            

			return status;
		}

// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

        
        // ↓ 2007.10.5 add//////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 拠点倉庫名称の取得処理
        /// </summary>
        /// <param name="warehouseName">拠点倉庫名称</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="warehouseCode">拠点倉庫コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 拠点倉庫コードから拠点倉庫名称を取得します</br>
        /// <br>Date       : 2007.10.5</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        /// 
        public int GetWarehouseName(out string warehouseName, string enterpriseCode, string sectionCode, string warehouseCode)
        {
            int status = 0;
            // --- CHG 2008/12/11 --------------------------------------------------------------------->>>>>
            //warehouseName = "";

            //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //Warehouse warehouse = null;

            //this._sectWarehouseNmTable = new Hashtable();

            //WarehouseAcs warehouseAcs = new WarehouseAcs();
            //// 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            //warehouseAcs.IsLocalDBRead = _isLocalDBRead;
            //// 2008.02.08 96012 ローカルＤＢ参照対応 end

            //// 拠点倉庫名称の読込
            //status = warehouseAcs.Read(out warehouse, enterpriseCode, sectionCode, warehouseCode);

            //if (warehouseCode != "")
            //{
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        if (warehouse.LogicalDeleteCode == 0)
            //        {
            //            warehouseName = warehouse.WarehouseName;
            //        }

            //        else
            //        {
            //            warehouseName = "削除済";
            //            //status = -1;  // DEL 2008/06/03
            //        }
            //    }

            //    else
            //    {
            //        warehouseName = "未登録";
            //    }
            //}

            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    // 読み込み失敗
            //    return status;
            //}
            if (this._warehouseDic.ContainsKey(warehouseCode.Trim()))
            {
                warehouseName = this._warehouseDic[warehouseCode.Trim()].WarehouseName.Trim();
            }
            else
            {
                warehouseName = "";
            }
            // --- CHG 2008/12/11 ---------------------------------------------------------------------<<<<<

            return status;
        }
        // ↑ 2007.10.5 add//////////////////////////////////////////////////////////////////////////////////////////


		/// <summary>
		/// クラスメンバーコピー処理（拠点情報ワーククラス⇒拠点情報クラス）
		/// </summary>
		/// <param name="secInfoSetWork">拠点情報ワーククラス</param>
		/// <returns>拠点情報クラス</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報ワーククラスから拠点情報クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private SecInfoSet CopyToSecInfoSetFromSecInfoSetWork(SecInfoSetWork secInfoSetWork)
		{

			SecInfoSet secInfoSet = new SecInfoSet();
			
			secInfoSet.CreateDateTime		= secInfoSetWork.CreateDateTime;
			secInfoSet.UpdateDateTime		= secInfoSetWork.UpdateDateTime;
			secInfoSet.EnterpriseCode		= secInfoSetWork.EnterpriseCode;
			secInfoSet.FileHeaderGuid		= secInfoSetWork.FileHeaderGuid;
			secInfoSet.UpdEmployeeCode		= secInfoSetWork.UpdEmployeeCode;
			secInfoSet.UpdAssemblyId1		= secInfoSetWork.UpdAssemblyId1;
			secInfoSet.UpdAssemblyId2		= secInfoSetWork.UpdAssemblyId2;
			secInfoSet.LogicalDeleteCode	= secInfoSetWork.LogicalDeleteCode;
			
			secInfoSet.SectionCode			= secInfoSetWork.SectionCode;
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			secInfoSet.CompanyPr			= secInfoSetWork.CompanyPr;
//			secInfoSet.CompanyName1			= secInfoSetWork.CompanyName1;
//			secInfoSet.CompanyName2			= secInfoSetWork.CompanyName2;
//			secInfoSet.PostNo				= secInfoSetWork.PostNo;
//			secInfoSet.Address1				= secInfoSetWork.Address1;
//			secInfoSet.Address2				= secInfoSetWork.Address2;
//			secInfoSet.Address3				= secInfoSetWork.Address3;
//			secInfoSet.Address4				= secInfoSetWork.Address4;
//			secInfoSet.CompanyTelNo1		= secInfoSetWork.CompanyTelNo1;
//			secInfoSet.CompanyTelNo2		= secInfoSetWork.CompanyTelNo2;
//			secInfoSet.CompanyTelNo3		= secInfoSetWork.CompanyTelNo3;
//			secInfoSet.CompanyTelTitle1		= secInfoSetWork.CompanyTelTitle1;
//			secInfoSet.CompanyTelTitle2		= secInfoSetWork.CompanyTelTitle2;
//			secInfoSet.CompanyTelTitle3		= secInfoSetWork.CompanyTelTitle3;
//			secInfoSet.TransferGuidance		= secInfoSetWork.TransferGuidance;
//			secInfoSet.AccountNoInfo1		= secInfoSetWork.AccountNoInfo1;
//			secInfoSet.AccountNoInfo2		= secInfoSetWork.AccountNoInfo2;
//			secInfoSet.AccountNoInfo3		= secInfoSetWork.AccountNoInfo3;
//			secInfoSet.CompanySetNote1		= secInfoSetWork.CompanySetNote1;
//			secInfoSet.CompanySetNote2		= secInfoSetWork.CompanySetNote2;
//			secInfoSet.SlipCompanyNmCd		= secInfoSetWork.SlipCompanyNmCd;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            //secInfoSet.OthrSlipCompanyNmCd	= secInfoSetWork.OthrSlipCompanyNmCd;  // DEL 2008/06/03
			secInfoSet.SectionGuideNm		= secInfoSetWork.SectionGuideNm;
			secInfoSet.MainOfficeFuncFlag	= secInfoSetWork.MainOfficeFuncFlag;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //secInfoSet.SecCdForNumbering	= secInfoSetWork.SecCdForNumbering;  // DEL 2008/06/03
			secInfoSet.CompanyNameCd1		= secInfoSetWork.CompanyNameCd1;
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			secInfoSet.CompanyNameCd2		= secInfoSetWork.CompanyNameCd2;
			secInfoSet.CompanyNameCd3		= secInfoSetWork.CompanyNameCd3;
			secInfoSet.CompanyNameCd4		= secInfoSetWork.CompanyNameCd4;
			secInfoSet.CompanyNameCd5		= secInfoSetWork.CompanyNameCd5;
			secInfoSet.CompanyNameCd6		= secInfoSetWork.CompanyNameCd6;
			secInfoSet.CompanyNameCd7		= secInfoSetWork.CompanyNameCd7;
			secInfoSet.CompanyNameCd8		= secInfoSetWork.CompanyNameCd8;
			secInfoSet.CompanyNameCd9		= secInfoSetWork.CompanyNameCd9;
			secInfoSet.CompanyNameCd10		= secInfoSetWork.CompanyNameCd10;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            // ↓ 2007.10.5 add//////////////////////////////////////////////////
            secInfoSet.SectWarehouseCd1     = secInfoSetWork.SectWarehouseCd1;
            secInfoSet.SectWarehouseCd2     = secInfoSetWork.SectWarehouseCd2;
            secInfoSet.SectWarehouseCd3     = secInfoSetWork.SectWarehouseCd3;
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            secInfoSet.SectWarehouseNm1     = secInfoSetWork.SectWarehouseNm1;
            secInfoSet.SectWarehouseNm2     = secInfoSetWork.SectWarehouseNm2;
            secInfoSet.SectWarehouseNm3     = secInfoSetWork.SectWarehouseNm3;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // ↑ 2007.10.5 add/////////////////////////////////////////////////

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            secInfoSet.SectionGuideSnm = secInfoSetWork.SectionGuideSnm;
            secInfoSet.IntroductionDate = secInfoSetWork.IntroductionDate;
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

			// 自社名称取得
            //for( int ix = 0; ix < 10; ix++ ) {  // DEL 2008/06/03
			for( int ix = 0; ix < 1; ix++ ) {  // ADD 2008/06/03
				string companyName1 = null;
				string companyName2 = null;
				GetCompanyName( out companyName1, out companyName2, 
					secInfoSetWork.EnterpriseCode, secInfoSet.GetCompanyNameCd( ix ) );
				secInfoSet.SetCompanyName( companyName1 + "　" + companyName2, ix );
			}
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // ↓ 2007.10.5 add//////////////////////////////////////////////////////////////////
            //拠点倉庫名称取得
            for (int ix = 0; ix < 3; ix++) {
                string warehouse1 = null;
                GetWarehouseName(out warehouse1, secInfoSetWork.EnterpriseCode,
                    secInfoSetWork.SectionCode, secInfoSet.GetSectWarehouseCd(ix));
                secInfoSet.SetSectWarehouseNm(warehouse1, ix);
            }
            // ↑ 2007.10.5 add//////////////////////////////////////////////////////////////////


                ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
                //			secInfoSet.BillCompanyNmPrtCd	= secInfoSetWork.BillCompanyNmPrtCd;
                //			
                //			switch (secInfoSetWork.SlipCompanyNmCd)
                //			{
                //				case 0:
                //				{
                //					secInfoSet.SlipCompanyNm = "拠点設定";
                //					break;
                //				}
                //				case 1:
                //				{
                //					secInfoSet.SlipCompanyNm = "自社設定";
                //					break;
                //				}
                //			}
                //			switch (secInfoSetWork.OthrSlipCompanyNmCd)
                //			{
                //				case 0:
                //				{
                //					secInfoSet.OthrSlipCompanyNm = "他拠点情報";
                //					break;
                //				}
                //				case 1:
                //				{
                //					secInfoSet.OthrSlipCompanyNm = "自拠点情報";
                //					break;
                //				}
                //			}
                //			switch (secInfoSetWork.MainOfficeFuncFlag)
                //			{
                //				case 0:
                //				{
                //					secInfoSet.MainOfficeFuncNm = "拠点";
                //					break;
                //				}
                //				case 1:
                //				{
                //					secInfoSet.MainOfficeFuncNm = "本社";
                //					break;
                //				}
                //			}
                //			switch (secInfoSetWork.BillCompanyNmPrtCd)
                //			{
                //				case 0:
                //				{
                //					secInfoSet.BillCompanyNmPrtNm = "拠点設定";
                //					break;
                //				}
                //				case 1:
                //				{
                //					secInfoSet.BillCompanyNmPrtNm = "自社設定";
                //					break;
                //				}
                //			}
                //			// ↑ 要変更 /////////////////////////////////////////////////////////////////
                // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

                return secInfoSet;
		}

		/// <summary>
		/// クラスメンバーコピー処理（拠点情報クラス⇒拠点情報ワーククラス）
		/// </summary>
		/// <param name="secInfoSet">拠点情報ワーククラス</param>
		/// <returns>拠点情報クラス</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報クラスから拠点情報ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private SecInfoSetWork CopyToSecInfoSetWorkFromSecInfoSet(SecInfoSet secInfoSet)
		{

			SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
			
			secInfoSetWork.CreateDateTime		= secInfoSet.CreateDateTime;
			secInfoSetWork.UpdateDateTime		= secInfoSet.UpdateDateTime;
			secInfoSetWork.EnterpriseCode		= secInfoSet.EnterpriseCode.Trim();
			secInfoSetWork.FileHeaderGuid		= secInfoSet.FileHeaderGuid;
			secInfoSetWork.UpdEmployeeCode		= secInfoSet.UpdEmployeeCode;
			secInfoSetWork.UpdAssemblyId1		= secInfoSet.UpdAssemblyId1;
			secInfoSetWork.UpdAssemblyId2		= secInfoSet.UpdAssemblyId2;
			secInfoSetWork.LogicalDeleteCode	= secInfoSet.LogicalDeleteCode;

			secInfoSetWork.SectionCode			= secInfoSet.SectionCode;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			secInfoSetWork.CompanyPr			= secInfoSet.CompanyPr.TrimEnd();
//			secInfoSetWork.CompanyName1			= secInfoSet.CompanyName1.TrimEnd();
//			secInfoSetWork.CompanyName2			= secInfoSet.CompanyName2.TrimEnd();
//			secInfoSetWork.PostNo				= secInfoSet.PostNo;
//			secInfoSetWork.Address1				= secInfoSet.Address1.TrimEnd();
//			secInfoSetWork.Address2				= secInfoSet.Address2;
//			secInfoSetWork.Address3				= secInfoSet.Address3.TrimEnd();
//			secInfoSetWork.Address4				= secInfoSet.Address4.TrimEnd();
//			secInfoSetWork.CompanyTelNo1		= secInfoSet.CompanyTelNo1.Trim();
//			secInfoSetWork.CompanyTelNo2		= secInfoSet.CompanyTelNo2.Trim();
//			secInfoSetWork.CompanyTelNo3		= secInfoSet.CompanyTelNo3.Trim();
//			secInfoSetWork.CompanyTelTitle1		= secInfoSet.CompanyTelTitle1.TrimEnd();
//			secInfoSetWork.CompanyTelTitle2		= secInfoSet.CompanyTelTitle2.TrimEnd();
//			secInfoSetWork.CompanyTelTitle3		= secInfoSet.CompanyTelTitle3.TrimEnd();
//			secInfoSetWork.TransferGuidance		= secInfoSet.TransferGuidance.TrimEnd();
//			secInfoSetWork.AccountNoInfo1		= secInfoSet.AccountNoInfo1.TrimEnd();
//			secInfoSetWork.AccountNoInfo2		= secInfoSet.AccountNoInfo2.TrimEnd();
//			secInfoSetWork.AccountNoInfo3		= secInfoSet.AccountNoInfo3.TrimEnd();
//			secInfoSetWork.CompanySetNote1		= secInfoSet.CompanySetNote1.TrimEnd();
//			secInfoSetWork.CompanySetNote2		= secInfoSet.CompanySetNote2.TrimEnd();
//			secInfoSetWork.SlipCompanyNmCd		= secInfoSet.SlipCompanyNmCd;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            //secInfoSetWork.OthrSlipCompanyNmCd	= secInfoSet.OthrSlipCompanyNmCd;  // DEL 2008/06/03
			secInfoSetWork.SectionGuideNm		= secInfoSet.SectionGuideNm.TrimEnd();
			secInfoSetWork.MainOfficeFuncFlag	= secInfoSet.MainOfficeFuncFlag;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //secInfoSetWork.SecCdForNumbering	= secInfoSet.SecCdForNumbering;  // DEL 2008/06/03
			secInfoSetWork.CompanyNameCd1		= secInfoSet.CompanyNameCd1;
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			secInfoSetWork.CompanyNameCd2		= secInfoSet.CompanyNameCd2;
			secInfoSetWork.CompanyNameCd3		= secInfoSet.CompanyNameCd3;
			secInfoSetWork.CompanyNameCd4		= secInfoSet.CompanyNameCd4;
			secInfoSetWork.CompanyNameCd5		= secInfoSet.CompanyNameCd5;
			secInfoSetWork.CompanyNameCd6		= secInfoSet.CompanyNameCd6;
			secInfoSetWork.CompanyNameCd7		= secInfoSet.CompanyNameCd7;
			secInfoSetWork.CompanyNameCd8		= secInfoSet.CompanyNameCd8;
			secInfoSetWork.CompanyNameCd9		= secInfoSet.CompanyNameCd9;
			secInfoSetWork.CompanyNameCd10		= secInfoSet.CompanyNameCd10;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // ↓ 2007.10.5 add//////////////////////////////////////////////////
            secInfoSetWork.SectWarehouseCd1		= secInfoSet.SectWarehouseCd1;
            secInfoSetWork.SectWarehouseCd2     = secInfoSet.SectWarehouseCd2;
            secInfoSetWork.SectWarehouseCd3     = secInfoSet.SectWarehouseCd3;
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            secInfoSetWork.SectWarehouseNm1     = secInfoSet.SectWarehouseNm1;
            secInfoSetWork.SectWarehouseNm2     = secInfoSet.SectWarehouseNm2;
            secInfoSetWork.SectWarehouseNm3     = secInfoSet.SectWarehouseNm3;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // ↑ 2007.10.5 add/////////////////////////////////////////////////

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            secInfoSetWork.SectionGuideSnm = secInfoSet.SectionGuideSnm;
            secInfoSetWork.IntroductionDate = secInfoSet.IntroductionDate;
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			secInfoSetWork.BillCompanyNmPrtCd	= secInfoSet.BillCompanyNmPrtCd;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			return secInfoSetWork;
		}
        /// <summary>
        /// 拠点情報ガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="dispAllSecInfo">"全社"設定有無[true:設定,false:未設定]</param>
        /// <param name="secInfoSet">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: 拠点情報設定マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2005.05.07</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, bool dispAllSecInfo, out SecInfoSet secInfoSet)
        {
            int status = -1;
            secInfoSet = new SecInfoSet();

            TableGuideParent tableGuideParent = new TableGuideParent("SECINFOSETGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();
 
            // 企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);
            // "全社"表示制御フラグ
            inObj.Add("DispAllSecInfo", dispAllSecInfo);
            
            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                secInfoSet.EnterpriseCode       = retObj["EnterpriseCode"].ToString(); 
                secInfoSet.SectionCode          = retObj["SectionCode"].ToString();
                secInfoSet.SectionGuideNm       = retObj["SectionGuideNm"].ToString();

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
				secInfoSet.CompanyNameCd1		= Convert.ToInt32( retObj["CompanyNameCd1"] );
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
				secInfoSet.CompanyNameCd2		= Convert.ToInt32( retObj["CompanyNameCd2"] );
				secInfoSet.CompanyNameCd3		= Convert.ToInt32( retObj["CompanyNameCd3"] );
				secInfoSet.CompanyNameCd4		= Convert.ToInt32( retObj["CompanyNameCd4"] );
				secInfoSet.CompanyNameCd5		= Convert.ToInt32( retObj["CompanyNameCd5"] );
				secInfoSet.CompanyNameCd6		= Convert.ToInt32( retObj["CompanyNameCd6"] );
				secInfoSet.CompanyNameCd7		= Convert.ToInt32( retObj["CompanyNameCd7"] );
				secInfoSet.CompanyNameCd8		= Convert.ToInt32( retObj["CompanyNameCd8"] );
				secInfoSet.CompanyNameCd9		= Convert.ToInt32( retObj["CompanyNameCd9"] );
				secInfoSet.CompanyNameCd10		= Convert.ToInt32( retObj["CompanyNameCd10"] );
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//				secInfoSet.CompanyName1         = retObj["CompanyName1"].ToString();
//				secInfoSet.CompanyName2         = retObj["CompanyName2"].ToString();
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

                // ↓ 2007.10.5 add/////////////////////////////////////////////////////////
                secInfoSet.SectWarehouseCd1     = retObj["SectWarehouseCd1"].ToString();
                secInfoSet.SectWarehouseCd2     = retObj["SectWarehouseCd2"].ToString();
                secInfoSet.SectWarehouseCd3     = retObj["SectWarehouseCd3"].ToString();
                secInfoSet.SectWarehouseNm1     = retObj["SectWarehouseNm1"].ToString();
                secInfoSet.SectWarehouseNm2     = retObj["SectWarehouseNm2"].ToString();
                secInfoSet.SectWarehouseNm3     = retObj["SectWarehouseNm3"].ToString();
                // ↑ 2007.10.5 add////////////////////////////////////////////////////////

                status = 0;
            } 
                // キャンセル
            else 
            {
                status = 1;
            }
            
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
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2005.05.07</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status   = -1;
            string enterpriseCode = "";
            bool dispAllSecInfo = false;
            
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
            
            // "全社"表示制御フラグ
            if (inParm.ContainsKey("DispAllSecInfo"))
            {
                dispAllSecInfo = (bool)inParm["DispAllSecInfo"];
            } 
            else 
            {
            }
            
            // 拠点情報設定テーブル読込み
            status = Search(ref guideList, enterpriseCode, dispAllSecInfo);
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
    }
}
