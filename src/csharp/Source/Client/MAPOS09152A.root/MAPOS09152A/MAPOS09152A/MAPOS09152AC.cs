//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 端末管理設定マスタ
// プログラム概要   : 端末管理設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/05  修正内容 : SCMオプション対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Common; // ADD 2009/06/05
using Broadleaf.Application.Remoting;   // ADD 2009/06/05
using Broadleaf.Application.Remoting.Adapter;   // ADD 2009/06/05
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using System.Net.NetworkInformation;

using Broadleaf.Application.Resources;// 2010/06/29 Add
namespace Broadleaf.Application.Controller
{
	/// <summary>端末管理テーブル(ローカルDB専用)アクセスクラス</summary>
	/// <remarks>
	/// <br>Note       : 端末管理テーブル(ローカルDB)のアクセス制御を行います。</br>
    /// <br>             存在するデータは、ローカルDB内では常に1レコードのみとします。</br>
    /// <br>Programmer : 古賀　小百合</br>
	/// <br>Date       : 2007.04.13</br>
    /// <br></br>
    /// <br>UpdateNote : 2007.06.11　古賀小百合　項目追加対応</br>
    /// <br>UpdateNote : 2007.07.03　古賀小百合　シンク処理対応(XML作成機能追加)</br>
    /// <br>UpdateNote : 2007.07.05  古賀小百合　拠点を自拠点から端末設置拠点に変更</br>
    /// <br>UpdateNote : 2007.07.09  古賀小百合　シンクバックアップ処理対応</br>
    /// <br>UpdateNote : 2008.01.31  上野　弘貴　ローカルＤＢ対応（拠点）</br>
    /// <br>UpdateNote : 2009.07.14 20056 對馬 大輔 サーバーへ配置するクライアントアセンブリ対応</br>
    /// <br>             ①拠点情報マスタアクセスクラスを使用しない</br>
    /// <br>             ②BkPosTerminalMgAcsのインスタンス生成を行わない</br>
    /// <br>UpdateNote : 2010/06/29 30517 夏野 駿希 Mantis.15667　仕様変更</br>
    /// </remarks>
	public class PosTerminalMgAcs
    {

        # region private 定数
        /// <summary>ローカルDBアクセスオブジェクト格納バッファ</summary>
		private PosTerminalMgLcDB _posTerminalMgLcDB = null;
        //private SecInfoAcs _secInfoAcs = null; // 2009.07.14
        // 2007.07.03  S.Koga  ADD --------------------------------------------
        private PosTerminalMgXMLDataAcs _posTerminalMgXMLDataAcs = null;
        // --------------------------------------------------------------------
        // 2007.07.09  S.Koga  ADD --------------------------------------------
        //private BkPosTerminalMgAcs _bkPosTerminalMgAcs = null; // 2009.07.14
        // --------------------------------------------------------------------

        // ADD 2009/06/05 ------>>>
        /// <summary>リモートDBアクセスオブジェクト格納バッファ</summary>
        private IPosTerminalMgDB _iPosTerminalMgDB = null;

        private Employee _employee;
        // ADD 2009/06/05 ------<<<

        private bool _scmFlg = false;   // 2010/06/29 Add
        # endregion

        # region コンストラクタ
        /// <summary>端末管理テーブルアクセスクラスコンストラクタ</summary>
		/// <remarks>
		/// <br>Note       : 端末管理テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 古賀　小百合</br>
		/// <br>Date       : 2007.04.13</br>
		/// </remarks>
		public PosTerminalMgAcs()
		{
            // ローカルDBアクセスオブジェクト取得
            this._posTerminalMgLcDB = new PosTerminalMgLcDB();

            // 2009.07.14 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            ////----- ueno upd ---------- start 2008.01.31        
            //// 明示的にローカル呼び出しを行う
            //this._secInfoAcs = new SecInfoAcs(0);
            ////----- ueno upd ---------- end 2008.01.31
            // 2009.07.14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            
            // 2007.07.03  S.Koga  ADD ----------------------------------------
            this._posTerminalMgXMLDataAcs = new PosTerminalMgXMLDataAcs();
            // ----------------------------------------------------------------
            // 2007.07.09  S.Koga  ADD ----------------------------------------
            //this._bkPosTerminalMgAcs = BkPosTerminalMgAcs.GetInstance(); // 2009.07.14
            // ----------------------------------------------------------------

            // ADD 2009/06/05 ------>>>
            // リモートDBアクセスオブジェクト取得
            this._iPosTerminalMgDB = (IPosTerminalMgDB)MediationPosTerminalMgDB.GetPosTerminalMgDB();

            this._employee = LoginInfoAcquisition.Employee;
            // ADD 2009/06/05 ------<<<

            // 2010/06/29 Add >>>
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus scmPs;
            scmPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
            if (scmPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                _scmFlg = true;
            }
            else
            {
                _scmFlg = false;
            }
            // 2010/06/29 Add <<<

        }
        # endregion

        /// <summary>レジ番号取得処理</summary>
        /// <param name="cashRegisterNo">レジ番号</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>読込結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 端末に登録されているレジ番号を取得します。(※1レコードのみ)</br>
        /// <br>Programmer : 古賀　小百合</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        public int GetCashRegisterNo(out int cashRegisterNo, string enterpriseCode)
        {
            cashRegisterNo = 0;
            int status = 0;
            PosTerminalMgWork posTerminalMgWork = new PosTerminalMgWork();
            List<PosTerminalMgWork> resList = new List<PosTerminalMgWork>();
            try
            {
                posTerminalMgWork.EnterpriseCode = enterpriseCode;

                //自賠責設定読み込み
                status = this._posTerminalMgLcDB.Search(out resList, posTerminalMgWork, 0, 0);

                if (status == 0)
                {
                    PosTerminalMgWork resWork = (PosTerminalMgWork)resList[0];
                    // クラス内メンバコピー
                    cashRegisterNo = resWork.CashRegisterNo;
                }

            }
            catch (Exception)
            {
                status = -1;
            }
            return status;
        }

        /// <summary>端末管理XML取得処理</summary>
        /// <returns>端末管理設定XML情報</returns>
        /// <remarks>
        /// <br>Note        : XMLに登録されている端末管理情報を返します。</br>
        /// <br>Programmer  : 20031 古賀　小百合</br>
        /// <br>Date        : 2007.07.03</br>
        /// </remarks>
        public int GetCashRegisterNoFromXML(out PosTerminalMgXMLData data)
        {
            int status = 0;
            //data = new PosTerminalMgXMLData();

            this._posTerminalMgXMLDataAcs.Deserialize();
            data = this._posTerminalMgXMLDataAcs.GetData();

            if (data == null)
                status = 4;

            return status;
        }

        /// <summary>端末管理読み込み処理</summary>
		/// <param name="posTerminalMg">端末管理オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>読込結果ステータス</returns>
		/// <remarks>
		/// <br>Note       : 端末管理を読み込みます。</br>
		/// <br>Programmer : 古賀　小百合</br>
		/// <br>Date       : 2007.04.13</br>
		/// </remarks>
		public int Search(out PosTerminalMg posTerminalMg, string enterpriseCode)
		{
            posTerminalMg = null;
            PosTerminalMgWork posTerminalMgWork = new PosTerminalMgWork();
            List<PosTerminalMgWork> resList = new List<PosTerminalMgWork>();
            try
			{
				posTerminalMgWork.EnterpriseCode	= enterpriseCode;

				//自賠責設定読み込み
				int status = this._posTerminalMgLcDB.Search(out resList, posTerminalMgWork,0,0);

				if (status == 0)
				{
                    PosTerminalMgWork resWork = (PosTerminalMgWork)resList[0];
					// クラス内メンバコピー
                    posTerminalMg = CopyToPosTerminalMgFromPosTerminalMgWork(resWork);
				}

				return status;
			}
			catch (Exception)
			{
				return -1;
			}
		}

        // ADD 2009/06/05 ------>>>
        /// <summary>端末管理読み込み処理(論理削除を含む全検索)</summary>
        /// <param name="retList">検索結果オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>読込結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 端末管理を読み込みます。</br>
        /// <br></br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            if (this._employee.UserAdminFlag == 1)
            {
                if (_scmFlg == true)   // 2010/06/29 SCMオプションが有効なら管理者モードで実行 Add
                    // 管理者モード
                    return SearchServer(out retList, enterpriseCode);
                // 2010/06/29 Add >>>
                else
                {
                    // 一般ユーザーモード
                    return SearchLocal(out retList, enterpriseCode);
                }
            // 2010/06/29 Add <<<
            }
            else
            {
                // 一般ユーザーモード
                return SearchLocal(out retList, enterpriseCode);
            }
        }

        /// <summary>端末管理読み込み処理(サーバー)</summary>
        /// <param name="retList">検索結果オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>読込結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 端末管理を読み込みます。</br>
        /// <br></br>
        /// </remarks>
        public int SearchServer(out ArrayList retList, string enterpriseCode)
        {
            PosTerminalMgServerWork posTerminalMgServerWork = new PosTerminalMgServerWork();
            posTerminalMgServerWork.EnterpriseCode = enterpriseCode;

            retList = new ArrayList();

            object paraobj = posTerminalMgServerWork;
			object retobj = null;

            // 端末管理設定の全検索
            int status = this._iPosTerminalMgDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetDataAll);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (PosTerminalMgServerWork wkPosTerminalMgServerWork in workList)
                {
                    retList.Add(CopyToPosTerminalMgFromPosTerminalMgServerWork(wkPosTerminalMgServerWork));
                }
            }

            return status;
        }

        /// <summary>端末管理読み込み処理(ローカル)</summary>
        /// <param name="retList">検索結果オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>読込結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 端末管理を読み込みます。</br>
        /// <br></br>
        /// </remarks>
        public int SearchLocal(out ArrayList retList, string enterpriseCode)
        {
            PosTerminalMgWork posTerminalMgWork = new PosTerminalMgWork();
            posTerminalMgWork.EnterpriseCode = enterpriseCode;
            
            retList = new ArrayList();

            List<PosTerminalMgWork> resList = new List<PosTerminalMgWork>();

            // ローカルDBの検索
            int status = this._posTerminalMgLcDB.Search(out resList, posTerminalMgWork, 0, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                PosTerminalMgWork resWork = (PosTerminalMgWork)resList[0];
                // クラス内メンバコピー
                retList.Add(CopyToPosTerminalMgFromPosTerminalMgWork(resWork));
            }
            else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                     (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                PosTerminalMg posTerminalMg = new PosTerminalMg();
                retList.Add(posTerminalMg);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }
        // ADD 2009/06/05 ------<<<
        
        /// <summary>端末管理読み込み処理</summary>
        /// <param name="posTerminalMg">端末管理オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>読込結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 端末管理を読み込みます。</br>
        /// <br>Programmer : 古賀　小百合</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        public string GetSecInfo(string sectionCode)
        {
            string sectionGuideName = "";
            // 2009.07.14 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            //{
            //    if (secInfoSet.SectionCode.Equals(sectionCode))
            //    {
            //        sectionGuideName = secInfoSet.SectionGuideNm;
            //    }
            //}
            // 2009.07.14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            return sectionGuideName;
        }

        /// <summary>拠点名称取得処理</summary>
        /// <param name="sectionName">拠点ガイド名称</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>取得結果ステータス(true:OK, false:NG)</returns>
        /// <remarks>
        /// <br>Note        : 指定した拠点コードの拠点ガイド名称を取得し、結果をbool型で返します。</br>
        /// <br>Programmer  : 20031 古賀　小百合</br>
        /// <br>Date        : 2007.07.05</br>
        /// </remarks>
        public bool GetSectionName(out string sectionName, string sectionCode)
        {
            sectionName = GetSecInfo(sectionCode);

            if (sectionName.Equals(""))
                return false;
            else
                return true;
        }

        /// <summary>拠点情報一覧取得処理</summary>
        /// <returns>拠点コード/拠点ガイド名称のキーと値の一覧</returns>
        /// <remarks>
        /// <br>Note        : 拠点情報の一覧を取得し、コードとガイド名称のみのコレクションを返します。</br>
        /// <br>Programmer  : 20031 古賀　小百合</br>
        /// <br>Date        : 2007.07.05</br>
        /// </remarks>
        public Hashtable GetSecInfoList()
        {
            Hashtable secInfoList = new Hashtable();

            // 2009.07.14 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            //{
            //    secInfoList.Add(secInfoSet.SectionCode, secInfoSet.SectionGuideNm);
            //}
            // 2009.07.14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return secInfoList;
        }

        /// <summary>端末管理登録・更新処理</summary>
		/// <param name="posTerminalMg">端末管理クラス</param>
		/// <returns>更新結果ステータス</returns>
		/// <remarks>
		/// <br>Note       : 端末管理の登録・更新を行います。</br>
		/// <br>Programmer : 古賀　小百合</br>
		/// <br>Date       : 2007.04.13</br>
		/// </remarks>
		public int Write(ref PosTerminalMg posTerminalMg, PosTerminalMg delTerminalMg)
		{
			//クラスからワーカークラスにメンバコピー
            //PosTerminalMgWork delTerminalMgWork = CopyToPosTerminalMgWorkFromPosTerminalMg(delTerminalMg);
            PosTerminalMgWork posTerminalMgWork = CopyToPosTerminalMgWorkFromPosTerminalMg(posTerminalMg);

            // 検索結果格納List
            List<PosTerminalMgWork> posList = new List<PosTerminalMgWork>();
            // 検索パラメータ格納Work
            PosTerminalMgWork paraWork = new PosTerminalMgWork();
            paraWork.EnterpriseCode = delTerminalMg.EnterpriseCode;
            // 削除パラメータ格納List
            List<PosTerminalMgWork> delParaList = new List<PosTerminalMgWork>();
            // 更新パラメータ格納List
            List<PosTerminalMgWork> wriParaList = new List<PosTerminalMgWork>();
            wriParaList.Add(posTerminalMgWork);

			int status = 0;
			try
			{
                status = this._posTerminalMgLcDB.Search(out posList, paraWork, 0, 0);
                if (status == 0)
                {
                    foreach (PosTerminalMgWork delPara in posList)
                    {
                        delParaList.Add(delPara);
                        status = this._posTerminalMgLcDB.Delete(delParaList);
                        if (status != 0)
                            return status;
                    }
                }
                else if(status != 4 && status != 9)
                    return status;

                //書き込み
                status = this._posTerminalMgLcDB.Write(ref wriParaList);
                if (status == 0)
                {
                    // ファイル名を渡してワーククラスをデシリアライズする
                    posTerminalMgWork = (PosTerminalMgWork)wriParaList[0];
                    // クラス内メンバコピー
                    posTerminalMg = CopyToPosTerminalMgFromPosTerminalMgWork(posTerminalMgWork);

                    // 2007.07.03  S.Koga  ADD --------------------------------
                    PosTerminalMgXMLData data = new PosTerminalMgXMLData();
                    data.EnterpriseCode = posTerminalMg.EnterpriseCode;
                    //data.SectionCode = posTerminalMg.SectionCode;                 // DEL 2008/06/18
                    data.CashRegisterNo = posTerminalMg.CashRegisterNo;
                    this._posTerminalMgXMLDataAcs.Cache(data);
                    this._posTerminalMgXMLDataAcs.Serialize();
                    // --------------------------------------------------------

                    //--- DEL 2008/06/19 --------->>>>>
                    // 2007.07.09  S.Koga  ADD --------------------------------
                    // バックアップ処理エラーの場合は現時点ではスルーします。
                    // --------------------------------------------------------
                    //int onlinestatus = 0;
                    //if(CheckOnline())
                    //    onlinestatus = this._bkPosTerminalMgAcs.BackUpExec();
                    // --------------------------------------------------------
                    //--- DEL 2008/06/19 ---------<<<<<
                }

			}
			catch (Exception)
			{
				//エラー発生時は-1を返す
				status = -1;
			}
			return status;
		}

		/// <summary>端末管理シリアライズ処理</summary>
		/// <param name="PosTerminalMg">シリアライズ対象端末管理クラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 端末管理のシリアライズを行います。</br>
		/// <br>Programmer : 古賀　小百合</br>
		/// <br>Date       : 2007.04.13</br>
		/// </remarks>
		public void PosTerminalMgSerialize(PosTerminalMg posTerminalMg,string fileName)
		{
			//プリンタ管理ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(posTerminalMg,fileName);
		}

		/// <summary>端末管理Listシリアライズ処理</summary>
		/// <param name="PosTerminalMgList">シリアライズ対象端末管理Listクラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 端末管理List情報のシリアライズを行います。</br>
		/// <br>Programmer : 古賀　小百合</br>
		/// <br>Date       : 2007.04.13</br>
		/// </remarks>
		public void PosTerminalMgListSerialize(ArrayList posTerminalMgList,string fileName)
		{
			// ArrayListから配列を生成
			PosTerminalMg[] posTerminalMgs = (PosTerminalMg[])posTerminalMgList.ToArray(typeof(PosTerminalMg));
			// プリンタ管理ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(posTerminalMgs,fileName);

		}

		/// <summary>クラスメンバーコピー処理（端末管理ワーククラス⇒端末管理クラス）</summary>
		/// <param name="PosTerminalMgWork">端末管理ワーククラス</param>
		/// <returns>端末管理クラス</returns>
		/// <remarks>
		/// <br>Note       : 端末管理ワーククラスから端末管理クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 古賀　小百合</br>
		/// <br>Date       : 2007.04.13</br>
		/// </remarks>
		private PosTerminalMg CopyToPosTerminalMgFromPosTerminalMgWork(PosTerminalMgWork posTerminalMgWork)
		{
			PosTerminalMg posTerminalMg = new PosTerminalMg();

			//ファイルヘッダ部分
			posTerminalMg.CreateDateTime    = posTerminalMgWork.CreateDateTime;
			posTerminalMg.UpdateDateTime    = posTerminalMgWork.UpdateDateTime;
			posTerminalMg.EnterpriseCode    = posTerminalMgWork.EnterpriseCode;
			posTerminalMg.FileHeaderGuid    = posTerminalMgWork.FileHeaderGuid;
			posTerminalMg.UpdEmployeeCode   = posTerminalMgWork.UpdEmployeeCode;
			posTerminalMg.UpdAssemblyId1    = posTerminalMgWork.UpdAssemblyId1;
			posTerminalMg.UpdAssemblyId2    = posTerminalMgWork.UpdAssemblyId2;
			posTerminalMg.LogicalDeleteCode = posTerminalMgWork.LogicalDeleteCode;

            //posTerminalMg.SectionCode       = posTerminalMgWork.SectionCode;          // DEL 2008/06/18
            posTerminalMg.CashRegisterNo    = posTerminalMgWork.CashRegisterNo;

            // 2007.06.11  S.Koga  ADD ----------------------------------------
            // POS/PC端末区分
            posTerminalMg.PosPCTermCd = posTerminalMgWork.PosPCTermCd;
            // ----------------------------------------------------------------

            //--- ADD 2008/06/18 ---------->>>>>
            posTerminalMg.UseLanguageDivCd = posTerminalMgWork.UseLanguageDivCd;
            posTerminalMg.UseCultureDivCd = posTerminalMgWork.UseCultureDivCd;
            //--- ADD 2008/06/18 ---------->>>>>

            // ADD 2009/06/05 ------>>>
            posTerminalMg.MachineIpAddr = posTerminalMgWork.MachineIpAddr;
            posTerminalMg.MachineName = posTerminalMgWork.MachineName;
            // ADD 2009/06/05 ------<<<
            
            return posTerminalMg;
		}

		/// <summary>クラスメンバーコピー処理（端末管理クラス⇒端末管理ワーククラス）</summary>
		/// <param name="PosTerminalMg">端末管理ワーククラス</param>
		/// <returns>端末管理クラス</returns>
		/// <remarks>
		/// <br>Note       : 端末管理クラスから端末管理ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 古賀　小百合</br>
		/// <br>Date       : 2007.04.13</br>
		/// </remarks>
		private PosTerminalMgWork CopyToPosTerminalMgWorkFromPosTerminalMg(PosTerminalMg posTerminalMg)
		{
			PosTerminalMgWork posTerminalMgWork = new PosTerminalMgWork();

			posTerminalMgWork.CreateDateTime    = posTerminalMg.CreateDateTime;
			posTerminalMgWork.UpdateDateTime    = posTerminalMg.UpdateDateTime;
			posTerminalMgWork.EnterpriseCode    = posTerminalMg.EnterpriseCode.Trim();
			posTerminalMgWork.FileHeaderGuid    = posTerminalMg.FileHeaderGuid;
			posTerminalMgWork.UpdEmployeeCode   = posTerminalMg.UpdEmployeeCode;
			posTerminalMgWork.UpdAssemblyId1    = posTerminalMg.UpdAssemblyId1;
			posTerminalMgWork.UpdAssemblyId2    = posTerminalMg.UpdAssemblyId2;
			posTerminalMgWork.LogicalDeleteCode = posTerminalMg.LogicalDeleteCode;

            //posTerminalMgWork.SectionCode       = posTerminalMg.SectionCode;          // DEL 2008/06/18
            posTerminalMgWork.CashRegisterNo    = posTerminalMg.CashRegisterNo;

            // 2007.06.11  S.Koga  ADD ----------------------------------------
            // POS/PC端末区分
            posTerminalMgWork.PosPCTermCd = posTerminalMg.PosPCTermCd;
            // ----------------------------------------------------------------

            //--- ADD 2008/06/18 ---------->>>>>
            posTerminalMgWork.UseLanguageDivCd = posTerminalMg.UseLanguageDivCd;
            posTerminalMgWork.UseCultureDivCd = posTerminalMg.UseCultureDivCd;
            //--- ADD 2008/06/18 ---------->>>>>

            // ADD 2009/06/05 ------>>>
            posTerminalMgWork.MachineIpAddr = posTerminalMg.MachineIpAddr;
            posTerminalMgWork.MachineName = posTerminalMg.MachineName;
            // ADD 2009/06/05 ------<<<

            return posTerminalMgWork;
		}

        /// <summary>クラスメンバーコピー処理（端末管理リモートワーククラス⇒端末管理クラス）</summary>
        /// <param name="posTerminalMgServerWork">端末管理リモートワーククラス</param>
        /// <returns>端末管理クラス</returns>
        /// <remarks>
        /// <br>Note       : 端末管理リモートワーククラスから端末管理クラスへメンバーのコピーを行います。</br>
        /// <br></br>
        /// </remarks>
        private PosTerminalMg CopyToPosTerminalMgFromPosTerminalMgServerWork(PosTerminalMgServerWork posTerminalMgServerWork)
        {
            PosTerminalMg posTerminalMg = new PosTerminalMg();

            //ファイルヘッダ部分
            posTerminalMg.CreateDateTime = posTerminalMgServerWork.CreateDateTime;
            posTerminalMg.UpdateDateTime = posTerminalMgServerWork.UpdateDateTime;
            posTerminalMg.EnterpriseCode = posTerminalMgServerWork.EnterpriseCode;
            posTerminalMg.FileHeaderGuid = posTerminalMgServerWork.FileHeaderGuid;
            posTerminalMg.UpdEmployeeCode = posTerminalMgServerWork.UpdEmployeeCode;
            posTerminalMg.UpdAssemblyId1 = posTerminalMgServerWork.UpdAssemblyId1;
            posTerminalMg.UpdAssemblyId2 = posTerminalMgServerWork.UpdAssemblyId2;
            posTerminalMg.LogicalDeleteCode = posTerminalMgServerWork.LogicalDeleteCode;

            posTerminalMg.CashRegisterNo = posTerminalMgServerWork.CashRegisterNo;

            // POS/PC端末区分
            posTerminalMg.PosPCTermCd = posTerminalMgServerWork.PosPCTermCd;
            
            posTerminalMg.UseLanguageDivCd = posTerminalMgServerWork.UseLanguageDivCd;
            posTerminalMg.UseCultureDivCd = posTerminalMgServerWork.UseCultureDivCd;
            
            posTerminalMg.MachineIpAddr = posTerminalMgServerWork.MachineIpAddr;
            posTerminalMg.MachineName = posTerminalMgServerWork.MachineName;
            
            return posTerminalMg;
        }

        /// <summary>クラスメンバーコピー処理（端末管理クラス⇒端末管理リモートワーククラス）</summary>
        /// <param name="PosTerminalMg">端末管理ワーククラス</param>
        /// <returns>端末管理クラス</returns>
        /// <remarks>
        /// <br>Note       : 端末管理クラスから端末管理リモートワーククラスへメンバーのコピーを行います。</br>
        /// <br></br>
        /// </remarks>
        private PosTerminalMgServerWork CopyToPosTerminalMgServerWorkFromPosTerminalMg(PosTerminalMg posTerminalMg)
        {
            PosTerminalMgServerWork posTerminalMgServerWork = new PosTerminalMgServerWork();

            posTerminalMgServerWork.CreateDateTime = posTerminalMg.CreateDateTime;
            posTerminalMgServerWork.UpdateDateTime = posTerminalMg.UpdateDateTime;
            posTerminalMgServerWork.EnterpriseCode = posTerminalMg.EnterpriseCode.Trim();
            posTerminalMgServerWork.FileHeaderGuid = posTerminalMg.FileHeaderGuid;
            posTerminalMgServerWork.UpdEmployeeCode = posTerminalMg.UpdEmployeeCode;
            posTerminalMgServerWork.UpdAssemblyId1 = posTerminalMg.UpdAssemblyId1;
            posTerminalMgServerWork.UpdAssemblyId2 = posTerminalMg.UpdAssemblyId2;
            posTerminalMgServerWork.LogicalDeleteCode = posTerminalMg.LogicalDeleteCode;

            posTerminalMgServerWork.CashRegisterNo = posTerminalMg.CashRegisterNo;

            // POS/PC端末区分
            posTerminalMgServerWork.PosPCTermCd = posTerminalMg.PosPCTermCd;
            
            posTerminalMgServerWork.UseLanguageDivCd = posTerminalMg.UseLanguageDivCd;
            posTerminalMgServerWork.UseCultureDivCd = posTerminalMg.UseCultureDivCd;
            
            posTerminalMgServerWork.MachineIpAddr = posTerminalMg.MachineIpAddr;
            posTerminalMgServerWork.MachineName = posTerminalMg.MachineName;
            
            return posTerminalMgServerWork;
        }

        /// <summary>ログオン時オンライン状態チェック処理</summary>
        /// <returns>オンライン状態チェック結果</returns>
        /// <remarks>
        /// <br>Note        : オンライン状態をチェックし、結果を返します。</br>
        /// <br>Programmer  : 20031 古賀　小百合</br>
        /// <br>Date        : 2007.07.09</br>
        /// </remarks>
        private bool CheckOnline()
        {
            // オンラインフラグによる判定
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>リモート接続可能判定</summary>
        /// <returns>リモート接続可能判定結果</returns>
        /// <remarks>
        /// <br>Note        : リモート接続からインターネット接続状態を判定し、結果を返します。</br>
        /// <br>Programmer  : 20031 古賀　小百合</br>
        /// <br>Date        : 2007.07.09</br>
        /// </remarks>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();
            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態
                return false;
            }
            else
            {
                return true;
            }
        }

        // ADD 2009/06/05 ------>>>
        #region -- 読み込み処理 --
        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="posTerminalMg">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param> 
        /// <param name="cashRegisterNo">端末番号</param>  
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        public int Read(out PosTerminalMg posTerminalMg, string enterpriseCode, int cashRegisterNo)
        {
            return ReadProc(out posTerminalMg, enterpriseCode, cashRegisterNo);
        }

        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="posTerminalMg">UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param> 
        /// <param name="cashRegisterNo">端末番号</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out PosTerminalMg posTerminalMg, string enterpriseCode, int cashRegisterNo)
        {
            int status = 0;

            posTerminalMg = null;

            try
            {
                PosTerminalMgServerWork posTerminalMgServerWork = new PosTerminalMgServerWork();
                posTerminalMgServerWork.EnterpriseCode = enterpriseCode;
                posTerminalMgServerWork.CashRegisterNo = cashRegisterNo;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(posTerminalMgServerWork);

                status = this._iPosTerminalMgDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLの読み込み
                    posTerminalMgServerWork = (PosTerminalMgServerWork)XmlByteSerializer.Deserialize(parabyte, typeof(PosTerminalMgServerWork));
                    // ワーク→UIデータクラス
                    posTerminalMg = CopyToPosTerminalMgFromPosTerminalMgServerWork(posTerminalMgServerWork);
                }

                return status;
            }
            catch (Exception)
            {
                posTerminalMg = null;
                // オフライン時はnullをセット
                this._iPosTerminalMgDB = null;
                // 通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 登録･更新処理 --
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="posTerminalMg">UIデータクラス</param>
        /// <param name="delTerminalMg">UIデータクラス(削除用)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br></br>
        /// </remarks>
        public int WriteAll(ref PosTerminalMg posTerminalMg, PosTerminalMg delTerminalMg)
        {
            if (this._employee.UserAdminFlag == 1)
            {
                if (_scmFlg == true)   // 2010/06/29 SCMオプションが有効なら管理者モードで実行 Add
                    // 管理者モード
                    return WriteServer(ref posTerminalMg, delTerminalMg);
                // 2010/06/29 Add >>>
                else
                {
                    // 一般ユーザーモード
                    PosTerminalMg posTerminalMgClone = posTerminalMg.Clone();
                    // ローカルDB登録
                    int status = Write(ref posTerminalMg, delTerminalMg);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    // サーバー登録
                    return WriteServer(ref posTerminalMgClone, delTerminalMg);
                }
            // 2010/06/29 Add <<<
            }
            else
            {
                // 一般ユーザーモード
                PosTerminalMg posTerminalMgClone = posTerminalMg.Clone();
                // ローカルDB登録
                int status = Write(ref posTerminalMg, delTerminalMg);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                // サーバー登録
                return WriteServer(ref posTerminalMgClone, delTerminalMg);
            }
        }

        /// <summary>端末管理登録・更新処理(サーバー)</summary>
        /// <param name="posTerminalMg">端末管理クラス</param>
        /// <param name="delTerminalMg">UIデータクラス(削除用)</param>
        /// <returns>更新結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 端末管理の登録・更新を行います。</br>
        /// <br></br>
        /// </remarks>
        public int WriteServer(ref PosTerminalMg posTerminalMg, PosTerminalMg delTerminalMg)
        {
            int status = 0;

            try
            {
                if (delTerminalMg != null)
                {
                    // 削除対象の端末番号を検索
                    PosTerminalMg readPosTerminalMg;
                    status = Read(out readPosTerminalMg, delTerminalMg.EnterpriseCode, delTerminalMg.CashRegisterNo);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 既存データの削除処理
                        status = Delete(readPosTerminalMg);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                    }
                    else if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                             (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        return status;
                    }
                }

                // UIデータクラス→ワーク
                PosTerminalMgServerWork posTerminalMgServerWork = CopyToPosTerminalMgServerWorkFromPosTerminalMg(posTerminalMg);
                object obj = posTerminalMgServerWork;

                // 書き込み処理
                status = this._iPosTerminalMgDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (obj is ArrayList)
                    {
                        posTerminalMgServerWork = (PosTerminalMgServerWork)((ArrayList)obj)[0];
                        // ワーク→UIデータクラス
                        posTerminalMg = CopyToPosTerminalMgFromPosTerminalMgServerWork(posTerminalMgServerWork);
                    }
                }

                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iPosTerminalMgDB = null;
                // 通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }
        #endregion

        #region -- 削除処理 --
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="posTerminalMg">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 端末管理リモートの論理削除を行います。</br>
        /// <br></br>
        /// </remarks>
        public int LogicalDelete(ref PosTerminalMg posTerminalMg)
        {
            int status = 0;

            // UIデータクラス→ワーク
            PosTerminalMgServerWork posTerminalMgServerWork = CopyToPosTerminalMgServerWorkFromPosTerminalMg(posTerminalMg);

            object obj = posTerminalMgServerWork;

            try
            {
                // 論理削除
                status = this._iPosTerminalMgDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    posTerminalMgServerWork = (PosTerminalMgServerWork)obj;
                    // ワーク→UIデータクラス
                    posTerminalMg = CopyToPosTerminalMgFromPosTerminalMgServerWork(posTerminalMgServerWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iPosTerminalMgDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="posTerminalMg">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 端末管理リモートの物理削除を行います。</br>
        /// <br></br>
        /// </remarks>
        public int Delete(PosTerminalMg posTerminalMg)
        {
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                PosTerminalMgServerWork posTerminalMgServerWork = CopyToPosTerminalMgServerWorkFromPosTerminalMg(posTerminalMg);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(posTerminalMgServerWork);

                // 物理削除
                status = this._iPosTerminalMgDB.Delete(parabyte);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iPosTerminalMgDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion

        #region -- 復活処理 --
        /// <summary>
        /// 端末管理リモート復活処理
        /// </summary>
        /// <param name="posTerminalMg">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 端末管理リモートの復活を行います</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref PosTerminalMg posTerminalMg)
        {
            int status = 0;

            try
            {
                // UIデータクラス→ワーク
                PosTerminalMgServerWork posTerminalMgServerWork = CopyToPosTerminalMgServerWorkFromPosTerminalMg(posTerminalMg);

                object obj = posTerminalMgServerWork;

                // 復活処理
                status = this._iPosTerminalMgDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    posTerminalMgServerWork = (PosTerminalMgServerWork)obj;
                    // ワーク→UIデータクラス
                    posTerminalMg = CopyToPosTerminalMgFromPosTerminalMgServerWork(posTerminalMgServerWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iPosTerminalMgDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }
        #endregion
        // ADD 2009/06/05 ------<<<
    }
}
