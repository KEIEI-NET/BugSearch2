using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
//----- ueno add---------- start 2008.01.31
using Broadleaf.Application.LocalAccess;
//----- ueno add---------- end 2008.01.31

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 部門テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部門テーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.08.09</br>
	/// <br>Update Note: 2008.01.31 30167 上野　弘貴</br>
	/// <br>			 ローカルＤＢ対応</br>
    /// <br>Update Note: 2008/06/04 30414 忍　幸史</br>
    /// <br>			 拠点テーブル削除</br>
    /// <br>Update Note: 2008/09/16 30452 上野　俊治</br>
    /// <br>			 拠点名称取得処理追加</br>
    /// <br>			 部門ガイドの部門コードの0埋め処理を追加</br>
    /// </remarks>
    public class SubSectionAcs : IGeneralGuideData
    {
        # region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        ISubSectionDB _isubsectionDB = null;

		//----- ueno add ---------- start 2008.01.31
		private SubSectionLcDB _subSectionLcDB = null;
		//----- ueno add ---------- end 2008.01.31

        // キャッシュ用ハッシュテーブル
        static private Hashtable _SubSectionTable = null;

        // ガイド設定ファイル名
        private const string GUIDE_XML_FILENAME = "SUBSECTIONGUIDEPARENT.XML";   // XMLファイル名

        // ガイドパラメータ
        private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";             // 企業コード

        // ガイド項目タイプ
        private const string GUIDE_TYPE_STR = "System.String";              // String型

        // ガイド項目名
        private const string GUIDE_SECTIONCODE_TITLE = "SectionCode";                // 拠点コード
        private const string GUIDE_SECTIONNM_TITLE = "SectionGuideNm";                // 拠点名称
        private const string GUIDE_SUBSECTIONCODE_TITLE = "SubSectionCode";              // 部門コード
        private const string GUIDE_SUBSECTIONNAME_TITLE = "SubSectionName";              // 部門名称

		//----- ueno add ---------- start 2008.01.31
		private static bool _isLocalDBRead = false;	// デフォルトはリモート
		//----- ueno add ---------- end 2008.01.31

        // --- ADD 2008/09/16 -------------------------------->>>>>
        private SecInfoAcs   _secInfoAcs; // 拠点情報アクセスクラス
        // --- ADD 2008/09/16 --------------------------------<<<<<
        
        # endregion

        # region Constructor

        /// <summary>
        /// 部門テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 部門テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public SubSectionAcs()
        {
            _SubSectionTable = null;
            try
            {
                // リモートオブジェクト取得
                this._isubsectionDB = (ISubSectionDB)MediationSubSectionDB.GetSubSectionDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._isubsectionDB = null;
            }
            
			//----- ueno add ---------- start 2008.01.31
			// ローカルDBアクセスオブジェクト取得
			this._subSectionLcDB = new SubSectionLcDB();
			//----- ueno add ---------- end 2008.01.31

            // --- ADD 2008/09/16 -------------------------------->>>>>
            this._secInfoAcs = new SecInfoAcs(1); // リモート
            this._secInfoAcs.ResetSectionInfo();
            // --- ADD 2008/09/16 --------------------------------<<<<<
        }

        # endregion

		//----- ueno add ---------- start 2008.01.31
		#region Public Property

		//================================================================================
		//  プロパティ
		//================================================================================
		/// <summary>
		/// ローカルＤＢReadモード
		/// </summary>
		public bool IsLocalDBRead
		{
			get { return _isLocalDBRead; }
			set { _isLocalDBRead = value; }
		}
		#endregion
		//----- ueno add ---------- end 2008.01.31

        #region GetOnlineMode

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._isubsectionDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        #endregion

        #region Read Methods

        /// <summary>
        /// 部門読み込み処理
        /// </summary>
        /// <param name="subsection">部門オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="subsectionCode">部門コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部門情報を読み込みます。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Read(out SubSection subsection, string enterpriseCode, string sectionCode, int subsectionCode)
        {
            try
            {
                subsection = null;
                int status = 0;
                SubSectionWork subsectionWork = new SubSectionWork();
                subsectionWork.EnterpriseCode = enterpriseCode;
                subsectionWork.SectionCode = sectionCode;
                subsectionWork.SubSectionCode = subsectionCode;

				//----- ueno upd ---------- start 2008.01.31
				if (_isLocalDBRead)
				{
					status = this._subSectionLcDB.Read(ref subsectionWork, 0);
				}
				else
				{
					// XMLへ変換し、文字列のバイナリ化
					byte[] parabyte = XmlByteSerializer.Serialize(subsectionWork);
					status = this._isubsectionDB.Read(ref parabyte, 0);

					if (status == 0)
					{
						// XMLの読み込み
						subsectionWork = ( SubSectionWork ) XmlByteSerializer.Deserialize(parabyte, typeof(SubSectionWork));
						//// クラス内メンバコピー
						//subsection = CopyToSubSectionFromSubSectionWork(subsectionWork);
					}
				}
				
				if (status == 0)
				{
					// クラス内メンバコピー
					subsection = CopyToSubSectionFromSubSectionWork(subsectionWork);
				}
				//----- ueno upd ---------- end 2008.01.31

                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                subsection = null;
                //オフライン時はnullをセット
                this._isubsectionDB = null;
                return -1;
            }
        }

        #endregion

        #region Write Methods

        /// <summary>
        /// 部門登録・更新処理
        /// </summary>
        /// <param name="subsection">部門</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部門情報の登録・更新を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Write(ref SubSection subsection)
        {
            // 部門クラスから部門ワーカークラスにメンバコピー
            SubSectionWork subsectionWork = CopyToSubSectionWorkFromSubSection(subsection);

            ArrayList paraList = new ArrayList();

            paraList.Add(subsectionWork);

            object paraObj = paraList;
            int status = 0;
            try
            {
                //部門書き込み
                status = this._isubsectionDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    subsectionWork = (SubSectionWork)paraList[0];

                    // クラス内メンバコピー
                    subsection = CopyToSubSectionFromSubSectionWork(subsectionWork);

                    // キャッシュ更新
                    UpdateCache(subsection);

                }
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                status = -1;
            }
            return status;
        }

        #endregion

        #region LogicalDelete Methods

        /// <summary>
        /// 部門論理削除処理
        /// </summary>
        /// <param name="subsection">部門オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部門情報の論理削除を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int LogicalDelete(ref SubSection subsection)
        {
            int status = 0;

            try
            {
                // 部門変換
                ArrayList paraLst = new ArrayList();
                SubSectionWork subsectionWork = CopyToSubSectionWorkFromSubSection(subsection);
                paraLst.Add(subsectionWork);
                object paraObj = paraLst;

                // 論理削除
                status = this._isubsectionDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraLst = (ArrayList)paraObj;
                    subsectionWork = (SubSectionWork)paraLst[0];
                    // クラス内メンバコピー
                    subsection = CopyToSubSectionFromSubSectionWork(subsectionWork);

                    // キャッシュ更新
                    UpdateCache(subsection);

                    //SubSection deleteLineup = new SubSection();
                    //deleteLineup.EnterpriseCode = subsection.EnterpriseCode;
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._isubsectionDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion

        #region Revival Methods

        /// <summary>
        /// 部門論理削除復活処理
        /// </summary>
        /// <param name="subsection">部門オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部門情報の復活を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Revival(ref SubSection subsection)
        {
            try
            {
                SubSectionWork subsectionWork = CopyToSubSectionWorkFromSubSection(subsection);
                ArrayList paraLst = new ArrayList();

                paraLst.Add(subsectionWork);

                object paraObj = paraLst;

                // 復活処理
                int status = this._isubsectionDB.RevivalLogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraLst = (ArrayList)paraObj;
                    subsectionWork = (SubSectionWork)paraLst[0];
                    // クラス内メンバコピー
                    subsection = CopyToSubSectionFromSubSectionWork(subsectionWork);

                    UpdateCache(subsection);
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._isubsectionDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// 部門物理削除処理
        /// </summary>
        /// <param name="subsection">部門オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部門情報の物理削除を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Delete(SubSection subsection)
        {
            try
            {
                SubSectionWork subsectionWork = CopyToSubSectionWorkFromSubSection(subsection);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(subsectionWork);

                // 部門物理削除
                int status = this._isubsectionDB.Delete(parabyte);

                if (status == 0)
                {
                    RemoveCache(subsection);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._isubsectionDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        #endregion

        #region Search Methods

        /// <summary>
        /// 部門全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部門の全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, "", 0, null);
        }

        /// <summary>
        /// 部門全検索処理(拠点絞込み)（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="sectionCode">拠点コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 該当拠点での全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, sectionCode, 0, null);
        }

        /// <summary>
        /// 部門検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部門の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, "", ConstantManagement.LogicalMode.GetData01, null);
        }

        /// <summary>
        /// 部門検索処理(拠点絞り込み)（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="sectionCode">部門コード</param>		        
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 該当拠点での全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetData01, null);
        }

        /// <summary>
        /// 部門検索処理(拠点絞込み)
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevSubSectionがnullの場合のみ戻る)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="prevSubSection">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部門の検索処理を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, string enterpriseCode, string sectionCode, ConstantManagement.LogicalMode logicalMode, SubSection prevSubSection)
        {
            // 初期化
            retList = new ArrayList();
            retTotalCnt = 0;

            // 戻り値リスト
            ArrayList wkList = new ArrayList();
            
            // 検索条件セット
            SubSectionWork subsectionWork = new SubSectionWork();
            if (prevSubSection != null) subsectionWork = CopyToSubSectionWorkFromSubSection(prevSubSection);

            subsectionWork.EnterpriseCode = enterpriseCode;
            subsectionWork.SectionCode = sectionCode;

            // Searchパラメータ
            ArrayList paraList = new ArrayList();
            paraList.Add( subsectionWork );
            object paraobj = paraList;

            // 検索
            object retobj = null;

			//----- ueno upd ---------- start 2008.01.31
			int status_o = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			
			if (_isLocalDBRead)
			{
				// ローカル
				List<SubSectionWork> subSectionWorkList = new List<SubSectionWork>();
				status_o = this._subSectionLcDB.Search(out subSectionWorkList, subsectionWork, 0, logicalMode);
				
				if(status_o == 0)
				{
					ArrayList al = new ArrayList();
					al.AddRange(subSectionWorkList);
					retobj = (object)al;
				}
			}
			else
			{
				// リモート
	            status_o = this._isubsectionDB.Search(out retobj, paraobj, 0, logicalMode);
			}
			//----- ueno upd ---------- end 2008.01.31

            // 検索結果判定
            switch (status_o) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL: 
                    wkList = retobj as ArrayList;

                    if (wkList != null) {
                        foreach (SubSectionWork wkLineupWork in wkList) {
                            if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                ((sectionCode == "") || (wkLineupWork.SectionCode.TrimEnd() == sectionCode.TrimEnd()) || (wkLineupWork.SectionCode.TrimEnd() == ""))) 
                            {
                                //メンバコピー
                                retList.Add(CopyToSubSectionFromSubSectionWork(wkLineupWork));
                            }
                        }

                        retTotalCnt = retList.Count;
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF: 
                    break;
                default: 
                    return status_o;
            }

            return status_o;
        }


        /// <summary>
        /// 部門マスタ検索処理（ローカルDB(ガイド)用）
        /// </summary>
        /// <param name="retList">取得結果格納用ArrayList</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部門マスタのローカルDB検索処理を行い、取得結果をArryListで返します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int SearchLocalDB(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            SubSectionWork subsectionWork = new SubSectionWork();
            subsectionWork.EnterpriseCode = enterpriseCode;
            subsectionWork.SectionCode = sectionCode;

            retList = new ArrayList();
            retList.Clear();

            int status = 0;

            List<SubSectionWork> subsectionWorkList = null;

            status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    if (subsectionWorkList != null) {
                        foreach (SubSectionWork wkLineupWork in subsectionWorkList) {
                            if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                ((sectionCode == "") || (wkLineupWork.SectionCode.TrimEnd() == sectionCode.TrimEnd()) || (wkLineupWork.SectionCode.TrimEnd() == "")))
                            {
                                //メンバコピー
                                retList.Add(CopyToSubSectionFromSubSectionWork(wkLineupWork));
                            }
                        }
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    return status;
            }

            return status;
        }


        #endregion

        // --- ADD 2008/09/16 -------------------------------->>>>>
        #region 拠点名称取得 Methods
        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008/09/16</br>
        /// </remarks>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                        {
                            sectionName = secInfoSet.SectionGuideNm.Trim();
                            return sectionName;
                        }
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        #endregion
        // --- ADD 2008/09/16 --------------------------------<<<<<

        #region Cache Methods

        /// <summary>
        /// キャッシュ内データ登録更新処理
        /// </summary>
        /// <param name="subsection">部門オブジェクト</param>
        /// <remarks>
        /// <br>Note       : キャッシュ内のデータの登録・更新を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void UpdateCache(SubSection subsection)
        {
            if (_SubSectionTable == null) {
                _SubSectionTable = new Hashtable();
            }

            Hashtable subsectionTable = null;		// 部門コード別ハッシュテーブル

            // ハッシュテーブルに拠点が登録されている
            if (_SubSectionTable.ContainsKey(subsection.SectionCode) == true) {
                // 部門コード別ハッシュテーブル取得
                subsectionTable = (Hashtable)_SubSectionTable[subsection.SectionCode];
            }
            // ハッシュテーブルに拠点が登録されていない
            else {
                // 部門コード別ハッシュテーブルを生成
                subsectionTable = new Hashtable();
                // 拠点別ハッシュテーブルに追加
                _SubSectionTable.Add(subsection.SectionCode, subsectionTable);
            }
        }

        /// <summary>
        /// キャッシュ内データ削除処理
        /// </summary>
        /// <param name="SubSection">ラ部門オブジェクト</param>
        /// <remarks>
        /// <br>Note       : キャッシュ内データから指定された部門オブジェクトを削除します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void RemoveCache(SubSection SubSection)
        {
            if (_SubSectionTable == null) {
                // データが存在していない
                return;
            }

            Hashtable subsectionTable = null;		// 部門コード別ハッシュテーブル

            // ハッシュテーブルに拠点が登録されている
            if (_SubSectionTable.ContainsKey(SubSection.SectionCode) == false) {
                // データが存在していない
                return;
            }
            // 部門コード別ハッシュテーブル取得
            subsectionTable = (Hashtable)_SubSectionTable[SubSection.SectionCode];
        }

        # endregion

        #region MemberCopy Methods

        /// <summary>
        /// クラスメンバーコピー処理（部門ワーククラス⇒部門）
        /// </summary>
        /// <param name="subsectionWork">部門ワーククラス</param>
        /// <returns>部門</returns>
        /// <remarks>
        /// <br>Note       : 部門ワーククラスから部門へメンバーのコピーを行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private SubSection CopyToSubSectionFromSubSectionWork(SubSectionWork subsectionWork)
        {
            SubSection subsection = new SubSection();

            subsection.CreateDateTime = subsectionWork.CreateDateTime;
            subsection.UpdateDateTime = subsectionWork.UpdateDateTime;
            subsection.FileHeaderGuid = subsectionWork.FileHeaderGuid;
            subsection.LogicalDeleteCode = subsectionWork.LogicalDeleteCode;
            subsection.EnterpriseCode = subsectionWork.EnterpriseCode;

            subsection.LogicalDeleteCode = subsectionWork.LogicalDeleteCode;
            subsection.SectionCode = subsectionWork.SectionCode;
            //subsection.SectionGuideNm = subsectionWork.SectionGuideNm;  // DEL 2008/06/04
            subsection.SubSectionCode = subsectionWork.SubSectionCode;
            subsection.SubSectionName = subsectionWork.SubSectionName;

            return subsection;
        }

        /// <summary>
        /// クラスメンバーコピー処理（部門⇒部門ワーククラス）
        /// </summary>
        /// <param name="subsection">部門クラス</param>
        /// <returns>部門ワーク</returns>
        /// <remarks>
        /// <br>Note       : 部門から部門ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private SubSectionWork CopyToSubSectionWorkFromSubSection(SubSection subsection)
        {
            SubSectionWork subsectionWork = new SubSectionWork();

            subsectionWork.CreateDateTime = subsection.CreateDateTime;
            subsectionWork.UpdateDateTime = subsection.UpdateDateTime;
            subsectionWork.EnterpriseCode = subsection.EnterpriseCode;
            subsectionWork.FileHeaderGuid = subsection.FileHeaderGuid;

            subsectionWork.LogicalDeleteCode = subsection.LogicalDeleteCode;
            subsectionWork.SectionCode = subsection.SectionCode;
            //subsectionWork.SectionGuideNm = subsection.SectionGuideNm;  // DEL 2008/06/04
            subsectionWork.SubSectionCode = subsection.SubSectionCode;
            subsectionWork.SubSectionName = subsection.SubSectionName;

            return subsectionWork;
        }

        /// <summary>
        /// クラスメンバコピー処理 (ガイド選択データ⇒仕訳科目設定マスタクラス)
        /// </summary>
        /// <param name="guideData">ガイド選択データ</param>
        /// <returns>仕訳科目設定マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : ガイド選択データから仕訳科目設定マスタクラスへメンバコピーを行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private SubSection CopyToSubSectionFromGuideData(Hashtable guideData)
        {
            SubSection subsection = new SubSection();

            subsection.SectionCode = (string)guideData[GUIDE_SECTIONCODE_TITLE];                     // 拠点コード
            //subsection.SectionGuideNm = ( string ) guideData[GUIDE_SECTIONNM_TITLE];                      // 拠点名称  // DEL 2008/06/04
            subsection.SubSectionCode = ToInt(guideData[GUIDE_SUBSECTIONCODE_TITLE].ToString());     // 部門コード
            subsection.SubSectionName = (string) guideData[GUIDE_SUBSECTIONNAME_TITLE];              // 部門名称

            return subsection;
        }

        /// <summary>
        /// DataRowコピー処理（部門クラス⇒ガイド用DataRow）
        /// </summary>
        /// <param name="guideRow">ガイド用DataRow</param>
        /// <param name="subsection">部門クラス</param>
        /// <remarks>
        /// <br>Note       : 部門クラスからガイド用DataRowへコピーを行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void CopyToGuideRowFromSubSection(ref DataRow guideRow, SubSection subsection)
        {
            guideRow[GUIDE_SECTIONCODE_TITLE] = subsection.SectionCode;            // 拠点コード
            //guideRow[GUIDE_SECTIONNM_TITLE] = subsection.SectionGuideNm;                // 拠点名称  // DEL 2008/06/04
            // --- ADD 2008/09/16 -------------------------------->>>>>
            guideRow[GUIDE_SECTIONNM_TITLE] = this.GetSectionName(subsection.SectionCode);
            // --- ADD 2008/09/16 --------------------------------<<<<<
            // --- DEL 2008/09/16 -------------------------------->>>>>
            //guideRow[GUIDE_SUBSECTIONCODE_TITLE] = subsection.SubSectionCode.ToString();
            // --- DEL 2008/09/16 --------------------------------<<<<< 
            // --- ADD 2008/09/16 -------------------------------->>>>>
            guideRow[GUIDE_SUBSECTIONCODE_TITLE] = subsection.SubSectionCode.ToString("00");      // 部門コード
            // --- ADD 2008/09/16 --------------------------------<<<<<
            guideRow[GUIDE_SUBSECTIONNAME_TITLE] = subsection.SubSectionName;      // 部門名称
        }

        #endregion

        #region Guide Methods

        /// <summary>
        /// マスタガイド起動処理
        /// </summary>
		/// <param name="subsection">取得データ</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note       : マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int ExecuteGuid(out SubSection subsection, string enterpriseCode, string sectionCode)
        {
            int status = -1;
            subsection = new SubSection();

            TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            inObj.Add(GUIDE_ENTERPRISECODE_PARA, enterpriseCode);   // 企業コード
            //inObj.Add(GUIDE_SECTIONCODE_TITLE, sectionCode);        // 拠点コード  // DEL 2008/06/04

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            if (sectionCode != "")
            {
                inObj.Add(GUIDE_SECTIONCODE_TITLE, sectionCode);
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            // ガイド起動
            if (tableGuideParent.Execute(0, inObj, ref retObj)) {
                // 選択データの取得
                subsection = CopyToSubSectionFromGuideData(retObj);
                status = 0;
            }
            else {
                // キャンセル
                status = 1;
            }

            return status;
        }

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// マスタガイド起動処理
        /// </summary>
        /// <param name="subsection">取得データ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note       : マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        public int ExecuteGuid(out SubSection subsection, string enterpriseCode)
        {
            int status = -1;
            status = ExecuteGuid(out subsection, enterpriseCode, "");

            return status;
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note	   : 汎用ガイド設定用データを取得します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";
            string sectionCode = "";

            if (inParm.ContainsKey(GUIDE_ENTERPRISECODE_PARA)) {
                // 企業コード設定有り
                enterpriseCode = inParm[GUIDE_ENTERPRISECODE_PARA].ToString();
            }
            else {
                // 企業コード設定無し
                // 有り得ないのでエラー
                return status;
            }

            // 拠点コード設定有り
            if (inParm.ContainsKey(GUIDE_SECTIONCODE_TITLE)) {
                sectionCode = inParm[GUIDE_SECTIONCODE_TITLE].ToString();
            }

            // マスタテーブル読込み(ローカルDBに変更)
            ArrayList retList;
            status = this.SearchAll( out retList, enterpriseCode, sectionCode );

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                    List<SubSection> subSectionList = new List<SubSection>();
                    foreach (SubSection subSection in retList)
                    {
                        if (subSection.LogicalDeleteCode == 0)
                        {
                            subSectionList.Add(subSection.Clone());
                        }
                    }

                    subSectionList.Sort(delegate(SubSection x, SubSection y)
                    {
                        if (x.SectionCode.Trim().CompareTo(y.SectionCode.Trim()) == 0)
                        {
                            return x.SubSectionCode - y.SubSectionCode;
                        }
                        else
                        {
                            return x.SectionCode.Trim().CompareTo(y.SectionCode.Trim());
                        }

                    });

                    retList = new ArrayList();
                    foreach (SubSection subSection in subSectionList)
                    {
                        retList.Add(subSection.Clone());
                    }

                    // ガイド初期起動時
                    if (guideList.Tables.Count == 0) {
                        // ガイド用データセット列情報構築
                        this.GuideDataSetColumnConstruction(ref guideList);
                    }

                    // ガイド用データセットの作成
                    this.GetGuideDataSet(ref guideList, retList, inParm);

                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    status = 4;
                    break;
                default:
                    status = -1;
                    break;
            }

            return status;
        }

        /// <summary>
        /// ガイド用データセット作成処理
        /// </summary>
        /// <param name="retDataSet">結果取得データセット</param>>
		/// <param name="retList">結果取得アレイリスト</param>>
		/// <param name="inParm">絞込条件</param>>
        /// <remarks>
        /// <br>Note	   : ガイド用データセット処理を行なう</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void GetGuideDataSet(ref DataSet retDataSet, ArrayList retList, Hashtable inParm)
        {
            SubSection subsection = null;
            DataRow guideRow = null;

            // 行を初期化して新しいデータを追加
            retDataSet.Tables[0].Rows.Clear();
            retDataSet.Tables[0].BeginLoadData();

            int dataCnt = 0;
            while (dataCnt < retList.Count)
            {
                subsection = (SubSection)retList[dataCnt];
                guideRow = retDataSet.Tables[0].NewRow();
                // データコピー処理
                CopyToGuideRowFromSubSection(ref guideRow, subsection);
                // データ追加
                retDataSet.Tables[0].Rows.Add(guideRow);

                dataCnt++;
            }

            retDataSet.Tables[0].EndLoadData();
        }

        /// <summary>
        /// ガイド用データセット列情報構築処理
        /// </summary>
        /// <param name="guideList">ガイド用データセット</param>>
        /// <remarks>
        /// <br>Note       : ガイド用データセットの列情報を構築します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void GuideDataSetColumnConstruction(ref DataSet guideList)
        {
            DataTable table = new DataTable();
            DataColumn column;

            // 拠点コード
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = GUIDE_SECTIONCODE_TITLE;
            table.Columns.Add(column);

            // 拠点コード
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = GUIDE_SECTIONNM_TITLE;
            table.Columns.Add(column);
            
            // 部門コード
            column = new DataColumn();
            // --- DEL 2008/09/16 -------------------------------->>>>>
            //column.DataType = typeof(int);
            // --- DEL 2008/09/16 --------------------------------<<<<<
            // --- ADD 2008/09/16 -------------------------------->>>>>
            column.DataType = typeof(string);
            // --- ADD 2008/09/16 --------------------------------<<<<<
            column.ColumnName = GUIDE_SUBSECTIONCODE_TITLE;
            table.Columns.Add(column);

            // 部門名称
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = GUIDE_SUBSECTIONNAME_TITLE;
            table.Columns.Add(column);


            // テーブルコピー
            guideList.Tables.Add(table.Clone());
        }

        #endregion

        /// <summary>
        /// 文字列→数値　変換
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private int ToInt( string text ) 
        {
            try {
                return Convert.ToInt32( text );
            }
            catch {
                return 0;
            }
        }
    }
}
