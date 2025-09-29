# region ※using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

using Broadleaf.Application.LocalAccess;
# endregion

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 従業員テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 従業員テーブルのアクセス制御を行います。</br>
	/// <br>Programmer	: 980076 妻鳥　謙一郎</br>
	/// <br>Date		: 2004.03.19</br>
	/// <br>Update Note	: 2005.11.16 23002 上野　耕平</br>
	/// <br>			  ・参照されている従業員の削除防止</br>
	/// <br>Update Note	: 2005.11.17 22011 柏原　頼人</br>
	/// <br>			  ・参照されている従業員の削除防止の対応をコメントアウト</br>
	/// <br>Update Note	: 2006.06.20 23001 秋山　亮介</br>
	/// <br>              1.レバレート原価類のDDの変更対応</br>
    /// <br>Update Note	: 2006.12.11 20031 古賀　小百合</br>
    /// <br>              1.SFからMobile用に項目変更(削除のみ)</br>
	/// <br>Update Note	: 2007.03.29 980076 妻鳥　謙一郎</br>
	/// <br>              1.ガイド時にデータが表示されない現象を解除</br>
	/// <br>Update Note	: 2007.05.21 18322 木村 武正</br>
	/// <br>              1.ローカルDB対応(変更点は"_employeeLcDB"で検索)</br>
    /// <br>Update Note : 2007.05.23 20008 伊藤 豊</br>br>
    /// <br>              1.登録情報に職種(権限レベル1)、雇用形態(権限レベル2)を追加</br>
    /// <br>Update Note : 2007.05.26 980023 飯谷 耕平</br>
    /// <br>              1.ガイドに拠点の絞込機能を追加</br>
    /// <br>Update Note : 2007.05.29 980023 飯谷 耕平</br>
    /// <br>              1.結果をソートして返すように修正</br>
    /// <br>Update Note : 2007.08.14 980035 金沢 貞義</br>
    /// <br>              1.従業員詳細マスタの追加正</br>
	/// <br>Update Note:  2008.01.31 30167 上野　弘貴</br>
	/// <br>			  1.ローカルＤＢ対応</br>
    /// <br>Update Note : 2008.02.08 980035 金沢 貞義</br>
    /// <br>              1.不要な読み込み処理を削除</br>
	/// <br>Update Note:  2008.02.12 30167 上野　弘貴</br>
	/// <br>			  1.ローカルＤＢ対応（拠点）</br>
	/// <br>			  2.必要な処理をコメントから戻す</br>
    /// <br>Update Note : 2008/06/04 30414 忍　幸史</br>
    /// <br>              ・「所属課」「所属部署変更日」「旧所属拠点」「旧所属部門」「旧所属課」削除</br>
    /// <br>Update Note : 2008.11.10 30009 渋谷 大輔</br>
    /// <br>              ・UOE略称区分追加</br>
    /// <br>Update Note : 2008.11.17 21024 佐々木 健</br>
    /// <br>              ・業務区分名称の取得部分を削除</br>
    /// <br>Update Note : 2009.02.25 20056 對馬 大輔</br>
    /// <br>              ・従業員情報のみ取得するSearchメソッド追加</br>
    /// <br>Update Note : 2009.03.02 20056 對馬 大輔</br>
    /// <br>              ・メール項目追加</br>
    /// <br>Update Note : 2009.08.07 20056 對馬 大輔</br>
    /// <br>              ・サーバーへ配置するクライアントアセンブリ対応</br>
    /// <br>                LoginInfoAcquisition.OnlineFlagを参照して制御切替を行わない(常にOnline)</br>
    /// <br>Update Note : 2010/02/18 30517 夏野 駿希</br>
    /// <br>              ・felica対応・デモ用にfelicaオプションチェック（_optFeliCaAcs）にはtrueをセットしています</br>
	/// <br>Update Note : 2012.05.29 30182 立谷　亮介</br>
	/// <br>              ・「売上伝票入力起動枚数」「得意先電子元帳起動枚数」項目追加</br>
	/// </remarks>
	public class EmployeeAcs : IGeneralGuideData 
	{
		# region ■Private Member
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private IEmployeeDB _iEmployeeDB = null;
        private IEmployeeDtlDB _iEmployeeDtlDB = null;

		/// <summary>拠点情報部品</summary>
		private SecInfoAcs _secInfoAcs;

		//----- ueno rev ---------- start 2008.02.12
		/// <summary>ユーザーガイドアクセスクラス</summary>
        private UserGuideAcs _userGuideAcs;     
		//----- ueno rev ---------- end 2008.02.12
		// 2008.02.08 削除 >>>>>>>>>>
        ///// <summary>ユーザーガイドオブジェクト格納バッファ(HashTable)</summary>
        //private Hashtable _userGdBdTable;
        ///// <summary>ユーザーガイドオブジェクト格納バッファ(ArrayList)</summary>
        //private ArrayList _userGdBdList;
        // 2008.02.08 削除 <<<<<<<<<<
        /// <summary>従業員マスタクラスStatic</summary>
		private static Hashtable _employeeTable_Stc = null;
		/// <summary>従業員マスタクラスSearchフラグ</summary>
		private static bool _searchFlg;
		/// <summary>拠点オプションフラグ</summary>
		private bool _optSection;

		/// <summary>従業員ローカルDBアクセス</summary>
		private EmployeeLcDB _employeeLcDB      = null;
		//----- ueno add ---------- start 2008.01.31
		/// <summary>従業員詳細ローカルDBアクセス</summary>
		private EmployeeDtlLcDB _employeeDtlLcDB = null;
		//----- ueno add ---------- end 2008.01.31

        /// <summary>キャッシュ</summary>
        private static DataSet _localDataSet    =  null;

        private const string  LOCAL_EMPLOYEE_TABLE  = "localEmployeeTable";
        private const string  LOCAL_SECTIONCODE     = "拠点コード";
        private const string  LOCAL_EMPLOYEECODE    = "コード";
        private const string  LOCAL_EMPLOYEE_RECORD = "record";

        /// <summary>ローカルＤＢモード</summary>
		//----- ueno upd ---------- start 2008.01.31
		private static bool _isLocalDBRead = false;	// デフォルトはリモート
		//----- ueno upd ---------- end 2008.01.31

        // 2010/02/18 Add >>>
        /// <summary>フェリカ管理リモートオブジェクト格納バッファ</summary>
        private IFeliCaMngDB _iFeliCaMngDB = null;
        /// <summary>フェリカアクセスオプションフラグ</summary>
        private bool _optFeliCaAcs = false;
        /// <summary>フェリカ管理クラスリストStatic</summary>
        private static List<FeliCaMngWork> _felicaMngWkList_Stc = null;
        // 2010/02/18 Add <<<

		# endregion				    
		  
		# region ■Constracter
		/// <summary>
		/// 従業員テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 従業員テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public EmployeeAcs()
		{
			// メモリ生成処理
			MemoryCreate();
			// 拠点OPの判定
			this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // 2010/02/18 Add felicaオプションチェック >>>
            //this._optFeliCaAcs = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_FelicaAccessService) > 0);
            this._optFeliCaAcs = true;
            // 2010/02/18 Add <<<

            // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ログイン部品で通信状態を確認
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    try
            //    {
            //        // リモートオブジェクト取得
            //        this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();
            //        this._iEmployeeDtlDB = (IEmployeeDtlDB)MediationEmployeeDtlDB.GetEmployeeDtlDB();   // 2007.08.14 追加
            //    }
            //    catch (Exception)
            //    {				
            //        //オフライン時はnullをセット
            //        this._iEmployeeDB = null;
            //        this._iEmployeeDtlDB = null;    // 2007.08.14 追加
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
                this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();
                this._iEmployeeDtlDB = (IEmployeeDtlDB)MediationEmployeeDtlDB.GetEmployeeDtlDB();   // 2007.08.14 追加
                this._iFeliCaMngDB = (IFeliCaMngDB)MediationFeliCaMngDB.GetFeliCaMngDB();   // 2010/02/18 Add
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iEmployeeDB = null;
                this._iEmployeeDtlDB = null;    // 2007.08.14 追加
            }
            // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // ローカルDBアクセスオブジェクト
            this._employeeLcDB = new EmployeeLcDB();

			//----- ueno add ---------- start 2008.01.31
			// 従業員詳細ローカルDBアクセスオブジェクト
			this._employeeDtlLcDB = new EmployeeDtlLcDB();
			//----- ueno add ---------- end 2008.01.31

            if (_localDataSet == null)
            {
                _localDataSet = new DataSet();
                DataTable dt = new DataTable(LOCAL_EMPLOYEE_TABLE);
                dt.Columns.Add(LOCAL_SECTIONCODE    , typeof(string));
                dt.Columns.Add(LOCAL_EMPLOYEECODE   , typeof(string));
                dt.Columns.Add(LOCAL_EMPLOYEE_RECORD, typeof(EmployeeWork));
                _localDataSet.Tables.Add(dt);
            }
		}
		# endregion

        // ----- iitani a ---------- start 2007.05.26 
        //================================================================================
        //  プロパティ
        //================================================================================
        #region Public Property

        /// <summary>
        /// ローカルＤＢReadモード
        /// </summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        #endregion
        // ----- iitani a ---------- end 2007.05.25 

		# region ◆public int GetOnlineMode()
		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iEmployeeDB == null)
			{
				return (int)ConstantManagement.OnlineMode.Offline;
			}
			else
			{
				return (int)ConstantManagement.OnlineMode.Online;
			}
		}
		# endregion

		#region ■Public Method
		/// <summary>
		/// 従業員マスタStaticメモリ全件取得処理
		/// </summary>
		/// <param name="retList">従業員クラスList</param>
		/// <returns>ステータス(0:正常終了, -1:エラー, 9:データ無し)</returns>
		/// <remarks>
		/// <br>Note       : 従業員マスタStaticメモリの全件を取得します。</br>
		/// <br>Programer  : 22033  三崎  貴史</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		public int SearchStaticMemory(out ArrayList retList)
		{
			retList = new ArrayList();
			retList.Clear();
			SortedList sortedList = new SortedList();

			if (_employeeTable_Stc == null)
			{
				return -1;
			}
			else if (_employeeTable_Stc.Count == 0)
			{
				return 9;
			}

			foreach (Employee employee in _employeeTable_Stc.Values)
			{
				sortedList.Add(employee.EmployeeCode, employee);
			}

			retList.AddRange(sortedList.Values);

			return 0;
		}

		/// <summary>
		/// 従業員マスタStaticメモリ取得処理
		/// </summary>
		/// <param name="employee">従業員クラス</param>
		/// <param name="employeeCode">従業員コード</param>
		/// <returns>ステータス(0:正常終了, -1:エラー, 4:データ無し)</returns>
		/// <remarks>
		/// <br>Note       : 従業員マスタStaticメモリを検索します。</br>
		/// <br>Programer  : 22033  三崎  貴史</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		public int ReadStaticMemory(out Employee employee, string employeeCode)
		{
			employee = new Employee();

			if (_employeeTable_Stc == null)
			{
				return -1;
			}

			// Staticから検索
			if (_employeeTable_Stc[employeeCode.TrimEnd()] == null)
			{
				return 4;
			}
			else
			{
				employee = (Employee)_employeeTable_Stc[employeeCode.TrimEnd()];
			}
			
			return 0;
		}

		/// <summary>
		/// 従業員マスタStaticメモリ情報オフライン書き込み処理
		/// </summary>
		/// <param name="sender">object（呼出元オブジェクト）</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 従業員マスタStaticメモリの情報をローカルファイルに保存します。</br>
		/// <br>Programer  : 22033  三崎  貴史</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		public int WriteOfflineData(object sender)
		{
			// オフラインシリアライズデータ作成部品I/O
			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
			int status;

			// KeyList設定
			string[] employeeKeys = new string[1];
			employeeKeys[0] = LoginInfoAcquisition.EnterpriseCode;

			SortedList sortedList = new SortedList();
			EmployeeWork employeeWork = new EmployeeWork();
			foreach (Employee employee in _employeeTable_Stc.Values)
			{
				// クラス ⇒ ワーカークラス
				employeeWork = CopyToEmployeeWorkFromEmployee(employee);

				// Sort
				sortedList.Add(employee.EmployeeCode, employeeWork);
			}

			ArrayList employeeWorkList = new ArrayList();  
			employeeWorkList.AddRange(sortedList.Values);
				
			status = offlineDataSerializer.Serialize("EmployeeAcs", employeeKeys, employeeWorkList);

            // 2010/02/18 Add >>>
            if ((status == 0) && (_optFeliCaAcs))
            {
                ArrayList felicaAL = new ArrayList();
                if (_felicaMngWkList_Stc == null)
                {
                    SearchAll_FeliCa(out _felicaMngWkList_Stc, LoginInfoAcquisition.EnterpriseCode);
                }

                if (_felicaMngWkList_Stc != null)
                {
                    foreach (FeliCaMngWork wk in _felicaMngWkList_Stc)
                    {
                        felicaAL.Add(wk);
                    }
                    employeeKeys[0] += "_felica";
                    status = offlineDataSerializer.Serialize("EmployeeAcs", employeeKeys, felicaAL);
                }
            }
            // 2010/02/18 Add <<<

			return status;
		}

		/// <summary>
		/// 従業員読み込み処理
		/// </summary>
		/// <param name="employee">従業員オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="employeeCode">従業員コード</param>
		/// <returns>従業員クラス</returns>
		/// <remarks>
		/// <br>Note       : 従業員情報を読み込みます。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int Read(out Employee employee, string enterpriseCode, string employeeCode)
		{			
			try
			{
				int status;
				employee = null;
				EmployeeWork employeeWork = new EmployeeWork();
				employeeWork.EnterpriseCode = enterpriseCode;
				employeeWork.EmployeeCode = employeeCode;

                // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// オンラインの場合リモート取得
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    // XMLへ変換し、文字列のバイナリ化
					byte[] parabyte = XmlByteSerializer.Serialize(employeeWork);

					//従業員読み込み
					// ----- iitani c ---------- start 2007.05.26
                    //status = this._iEmployeeDB.Read(ref parabyte,0);
                    if (_isLocalDBRead == true)
                    {
                        // ローカル
                        status = this._employeeLcDB.Read(ref employeeWork, 0);
                    }
                    else
                    {
                        // リモート
                        status = this._iEmployeeDB.Read(ref parabyte, 0);
                    }
                    // ----- iitani c ---------- end 2007.05.26

					if (status == 0)
					{
    					// ----- iitani a ---------- start 2007.05.26
                        //employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));
                        if (_isLocalDBRead == false)
                        {
                            // XMLの読み込み
                            employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));
                        }
                        // ----- iitani c ---------- end 2007.05.26

                        // クラス内メンバコピー
						employee = CopyToEmployeeFromEmployeeWork(employeeWork);
						// Read用Staticに保持
						_employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employee;
					}
                // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //}
                //else	// オフラインの場合キャッシュから取得
                //{
                //    status = ReadStaticMemory(out employee, employeeCode);
                //}
                // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				return status;
			}
			catch (Exception)
			{				
				//通信エラーは-1を戻す
				employee = null;
				//オフライン時はnullをセット
				this._iEmployeeDB = null;
				return -1;
			}
		}

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        ///// <summary>
        ///// 従業員読み込み処理
        ///// </summary>
        ///// <param name="employee">従業員オブジェクト</param>
        ///// <param name="employeeDtl">従業員詳細オブジェクト</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="employeeCode">従業員コード</param>
        ///// <returns>従業員クラス</returns>
        ///// <remarks>
        ///// <br>Note       : 従業員情報を読み込みます。</br>
        ///// <br>Programmer : 30414 忍 幸史</br>
        ///// <br>Date       : 2008/06/04</br>
        ///// </remarks>
        //public int Read(out Employee employee, out EmployeeDtl employeeDtl, string enterpriseCode, string employeeCode)
        //{
        //    try
        //    {
        //        int status;
        //        employee = null;
        //        employeeDtl = null;
        //        EmployeeWork employeeWork = new EmployeeWork();
        //        employeeWork.EnterpriseCode = enterpriseCode;
        //        employeeWork.EmployeeCode = employeeCode;

        //        EmployeeDtlWork employeeDtlWork = new EmployeeDtlWork();
        //        employeeDtlWork.EnterpriseCode = enterpriseCode;
        //        employeeDtlWork.EmployeeCode = employeeCode;

        //        // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //        //// オンラインの場合リモート取得
        //        //if (LoginInfoAcquisition.OnlineFlag)
        //        //{
        //        // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //            // XMLへ変換し、文字列のバイナリ化
        //            byte[] parabyte = XmlByteSerializer.Serialize(employeeWork);

        //            //従業員読み込み
        //            if (_isLocalDBRead == true)
        //            {
        //                // ローカル
        //                status = this._employeeLcDB.Read(ref employeeWork, 0);
        //            }
        //            else
        //            {
        //                // リモート
        //                status = this._iEmployeeDB.Read(ref parabyte, 0);
        //            }

        //            if (status == 0)
        //            {
        //                if (_isLocalDBRead == false)
        //                {
        //                    // XMLの読み込み
        //                    employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));
        //                }

        //                // クラス内メンバコピー
        //                employee = CopyToEmployeeFromEmployeeWork(employeeWork);
        //                // Read用Staticに保持
        //                _employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employee;
        //            }

        //            // 従業員詳細検索
        //            object objectEmployeeDtlWork = null;
        //            ArrayList paraList2;

        //            // ローカル
        //            if (_isLocalDBRead)
        //            {
        //                List<EmployeeDtlWork> employeeDtlWorkList = new List<EmployeeDtlWork>();
        //                status = this._employeeDtlLcDB.Search(out employeeDtlWorkList, employeeDtlWork, 0, 0);

        //                if (status == 0)
        //                {
        //                    ArrayList al = new ArrayList();
        //                    al.AddRange(employeeDtlWorkList);
        //                    objectEmployeeDtlWork = (object)al;
        //                }
        //            }
        //            // リモート
        //            else
        //            {
        //                status = this._iEmployeeDtlDB.Search(out objectEmployeeDtlWork, employeeDtlWork, 0, 0);
        //            }

        //            if (status == 0)
        //            {
        //                // 従業員詳細ワーカークラス⇒UIクラスStatic転記処理
        //                CopyToStaticFromWorker2(objectEmployeeDtlWork as ArrayList);
                        
        //                // パラメータが渡って来ているか確認
        //                paraList2 = objectEmployeeDtlWork as ArrayList;
        //                EmployeeDtlWork[] wkEmployeeDtlWork = new EmployeeDtlWork[paraList2.Count];

        //                // データを元に戻す
        //                for (int i = 0; i < paraList2.Count; i++)
        //                {
        //                    employeeDtlWork = (EmployeeDtlWork)paraList2[i];
        //                    if ((employeeDtlWork.LogicalDeleteCode == 0) && (employeeDtlWork.EmployeeCode.Trim() == employeeCode.Trim()))
        //                    {
        //                        employeeDtl = CopyToEmployeeDtlFromEmployeeDtlWork(employeeDtlWork);
        //                    }
        //                }
        //            }
        //        // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //        //}
        //        //else	// オフラインの場合キャッシュから取得
        //        //{
        //        //    status = ReadStaticMemory(out employee, employeeCode);
        //        //}
        //        // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        //        return status;
        //    }
        //    catch (Exception)
        //    {
        //        //通信エラーは-1を戻す
        //        employee = null;
        //        employeeDtl = null;
        //        //オフライン時はnullをセット
        //        this._iEmployeeDB = null;
        //        return -1;
        //    }
        //}


        /// <summary>
        /// 従業員読み込み処理
        /// </summary>
        /// <param name="employee">従業員オブジェクト</param>
        /// <param name="employeeDtl">従業員詳細オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>従業員クラス</returns>
        /// <remarks>
        /// <br>Note       : 従業員情報を読み込みます。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        public int Read(out Employee employee, out EmployeeDtl employeeDtl, string enterpriseCode, string employeeCode)
        {
            try
            {
                int status;
                employee = null;
                employeeDtl = null;
                EmployeeWork employeeWork = new EmployeeWork();
                employeeWork.EnterpriseCode = enterpriseCode;
                employeeWork.EmployeeCode = employeeCode;

                EmployeeDtlWork employeeDtlWork = new EmployeeDtlWork();
                employeeDtlWork.EnterpriseCode = enterpriseCode;
                employeeDtlWork.EmployeeCode = employeeCode;

                // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// オンラインの場合リモート取得
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(employeeWork);

                //従業員読み込み
                if (_isLocalDBRead == true)
                {
                    // ローカル
                    status = this._employeeLcDB.Read(ref employeeWork, 0);
                }
                else
                {
                    // リモート
                    status = this._iEmployeeDB.Read(ref parabyte, 0);
                }

                if (status == 0)
                {
                    if (_isLocalDBRead == false)
                    {
                        // XMLの読み込み
                        employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));
                    }

                    // クラス内メンバコピー
                    employee = CopyToEmployeeFromEmployeeWork(employeeWork);
                    // Read用Staticに保持
                    _employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employee;
                }

                // 従業員詳細検索
                object objectEmployeeDtlWork = null;
                ArrayList paraList2;

                // ローカル
                if (_isLocalDBRead)
                {
                    List<EmployeeDtlWork> employeeDtlWorkList = new List<EmployeeDtlWork>();
                    status = this._employeeDtlLcDB.Search(out employeeDtlWorkList, employeeDtlWork, 0, 0);

                    if (status == 0)
                    {
                        ArrayList al = new ArrayList();
                        al.AddRange(employeeDtlWorkList);
                        objectEmployeeDtlWork = (object)al;
                    }
                }
                // リモート
                else
                {
                    status = this._iEmployeeDtlDB.Search(out objectEmployeeDtlWork, employeeDtlWork, 0, 0);
                }

                if (status == 0)
                {
                    // 従業員詳細ワーカークラス⇒UIクラスStatic転記処理
                    CopyToStaticFromWorker2(objectEmployeeDtlWork as ArrayList);

                    // パラメータが渡って来ているか確認
                    paraList2 = objectEmployeeDtlWork as ArrayList;
                    EmployeeDtlWork[] wkEmployeeDtlWork = new EmployeeDtlWork[paraList2.Count];

                    // データを元に戻す
                    for (int i = 0; i < paraList2.Count; i++)
                    {
                        employeeDtlWork = (EmployeeDtlWork)paraList2[i];
                        if ((employeeDtlWork.LogicalDeleteCode == 0) && (employeeDtlWork.EmployeeCode.Trim() == employeeCode.Trim()))
                        {
                            employeeDtl = CopyToEmployeeDtlFromEmployeeDtlWork(employeeDtlWork);
                        }
                    }
                }
                // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //}
                //else	// オフラインの場合キャッシュから取得
                //{
                //    status = ReadStaticMemory(out employee, employeeCode);
                //}
                // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                employee = null;
                employeeDtl = null;
                //オフライン時はnullをセット
                this._iEmployeeDB = null;
                return -1;
            }
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// 従業員クラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>従業員クラス</returns>
		/// <remarks>
		/// <br>Note       : 従業員クラスをデシリアライズします。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public Employee Deserialize(string fileName)
		{
			Employee employee = null;

			// ファイル名を渡して従業員ワーククラスをデシリアライズする
			EmployeeWork employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(fileName,typeof(EmployeeWork));

			//デシリアライズ結果を従業員クラスへコピー
			if (employeeWork != null) employee = CopyToEmployeeFromEmployeeWork(employeeWork);

			return employee;
		}

        /// <summary>
		/// 従業員Listクラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>従業員クラスLIST</returns>
		/// <remarks>
		/// <br>Note       : 従業員リストクラスをデシリアライズします。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();

			// ファイル名を渡して従業員ワーククラスをデシリアライズする
			EmployeeWork[] employeeWorks = (EmployeeWork[])XmlByteSerializer.Deserialize(fileName,typeof(EmployeeWork[]));

			//デシリアライズ結果を従業員クラスへコピー
			if (employeeWorks != null) 
			{
				al.Capacity = employeeWorks.Length;
				for(int i=0; i < employeeWorks.Length; i++)
				{
					al.Add(CopyToEmployeeFromEmployeeWork(employeeWorks[i]));
				}
			}

			return al;
		}

		/// <summary>
		/// 従業員登録・更新処理
		/// </summary>
		/// <param name="employee">従業員クラス</param>
        /// <param name="employeeDtl">従業員詳細クラス</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 従業員情報の登録・更新を行います。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 修正 >>>>>>>>>>
        //public int Write(ref Employee employee)
        public int Write(ref Employee employee, ref EmployeeDtl employeeDtl)
        // 2007.08.14 修正 <<<<<<<<<<
        {
			//従業員クラスから従業員ワーカークラスにメンバコピー
			EmployeeWork employeeWork = CopyToEmployeeWorkFromEmployee(employee);
            EmployeeDtlWork employeeDtlWork = CopyToEmployeeDtlWorkFromEmployeeDtl(employeeDtl);

            // XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(employeeWork);

			int status = 0;
			try
			{
				//従業員書き込み
				status = this._iEmployeeDB.Write(ref parabyte);
				if (status == 0)
				{
					// ファイル名を渡して従業員ワーククラスをデシリアライズする
					employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));
					// クラス内メンバコピー
					employee = CopyToEmployeeFromEmployeeWork(employeeWork);
					// Staticデータ更新
					_employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employee;
                    
                    // 2007.08.14 追加 >>>>>>>>>>
                    //従業員詳細書き込み
                    ArrayList wklist = new ArrayList();
                    wklist.Add(employeeDtlWork);
                    Object listobj = wklist;
                    status = this._iEmployeeDtlDB.Write(ref listobj);
                    if (status == 0)
                    {
                        // クラス内メンバコピー
                        wklist = (ArrayList)listobj;
                        //employeeDtlWork = (EmployeeDtlWork)listobj;
                        employeeDtlWork = wklist[0] as EmployeeDtlWork;
                        employeeDtl = CopyToEmployeeDtlFromEmployeeDtlWork(employeeDtlWork);
                        // Staticデータ更新
                        //_employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employeeDtl;
                    }
                    // 2007.08.14 追加 <<<<<<<<<<
                }
            }
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iEmployeeDB = null;
                //通信エラーは-1を戻す
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// 従業員シリアライズ処理
		/// </summary>
		/// <param name="employee">シリアライズ対象従業員クラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 従業員情報のシリアライズを行います。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public void Serialize(Employee employee,string fileName)
		{
			//従業員クラスから従業員ワーカークラスにメンバコピー
			EmployeeWork employeeWork = CopyToEmployeeWorkFromEmployee(employee);
			//従業員ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(employeeWork,fileName);
		}

        /// <summary>
		/// 従業員Listシリアライズ処理
		/// </summary>
		/// <param name="employees">シリアライズ対象従業員Listクラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 従業員List情報のシリアライズを行います。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public void ListSerialize(ArrayList employees,string fileName)
		{
			EmployeeWork[] employeeWorks = new EmployeeWork[employees.Count];
			for(int i= 0; i < employees.Count; i++)
			{
				employeeWorks[i] = CopyToEmployeeWorkFromEmployee((Employee)employees[i]);
			}
			//従業員ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(employeeWorks,fileName);
		}

		/// <summary>
		/// 従業員論理削除処理
		/// </summary>
		/// <param name="employee">従業員オブジェクト</param>
        /// <param name="employeeDtl">従業員詳細クラス</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 従業員情報の論理削除を行います。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 修正 >>>>>>>>>>
		//public int LogicalDelete(ref Employee employee)
        public int LogicalDelete(ref Employee employee, ref EmployeeDtl employeeDtl)
        // 2007.08.14 修正 <<<<<<<<<<
        {
			try
			{
				// 2005.11.16 ADD UENO////////////////////////////////////////////////////////////
                //// 主作業設定にてセット作業が使われていないか検索
                //ArrayList mainWorkList = null;
                //MainworkAcs mainworkAcs = new MainworkAcs();
                //mainworkAcs.SearchAllMainwork( out mainWorkList, employee.EnterpriseCode);
                //foreach(MainWork mainWork in mainWorkList)
                //{
                //    if (mainWork.EmployeeCode.TrimEnd() == employee.EmployeeCode.TrimEnd())
                //    {
                //        return -2;
                //    }
                //}
				// 2005.11.16 END UENO////////////////////////////////////////////////////////////

				EmployeeWork employeeWork = CopyToEmployeeWorkFromEmployee(employee);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(employeeWork);
				// 従業員論理削除
				int status = this._iEmployeeDB.LogicalDelete(ref parabyte);

				if (status == 0)
				{
					// ファイル名を渡して従業員ワーククラスをデシリアライズする
					employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));
					// クラス内メンバコピー
					employee = CopyToEmployeeFromEmployeeWork(employeeWork);
					// Static更新
					_employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employee.Clone();


                    // 2007.08.14 追加 >>>>>>>>>>
                    EmployeeDtlWork employeeDtlWork = CopyToEmployeeDtlWorkFromEmployeeDtl(employeeDtl);
                    ArrayList wklist = new ArrayList();
                    wklist.Add(employeeDtlWork);
                    Object listobj = wklist;
                    // 従業員論理削除
                    int status2 = this._iEmployeeDtlDB.LogicalDelete(ref listobj);

                    if (status2 == 0)
                    {
                        // クラス内メンバコピー
                        wklist = (ArrayList)listobj;
                        //employeeDtlWork = (EmployeeDtlWork)listobj;
                        employeeDtlWork = wklist[0] as EmployeeDtlWork;
                        employeeDtl = CopyToEmployeeDtlFromEmployeeDtlWork(employeeDtlWork);
                        // Static更新
                        //_employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employee.Clone();
                    }
                    // 2007.08.14 追加 <<<<<<<<<<
                }

                return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iEmployeeDB = null;
                //通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 従業員物理削除処理
		/// </summary>
		/// <param name="employee">従業員オブジェクト</param>
        /// <param name="employeeDtl">従業員詳細クラス</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 従業員情報の物理削除を行います。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 修正 >>>>>>>>>>
        //public int Delete(Employee employee)
        public int Delete(Employee employee, EmployeeDtl employeeDtl)
        // 2007.08.14 修正 <<<<<<<<<<
        {
			try
			{
				EmployeeWork employeeWork = CopyToEmployeeWorkFromEmployee(employee);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(employeeWork);
				// 従業員物理削除
				int status = this._iEmployeeDB.Delete(parabyte);

				if (status == 0)
				{
					// ファイル名を渡して従業員ワーククラスをデシリアライズする
					employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));
					// クラス内メンバコピー
					employee = CopyToEmployeeFromEmployeeWork(employeeWork);
					// Static更新
					_employeeTable_Stc.Remove(employee.EmployeeCode.TrimEnd());


                    // 2007.08.14 追加 >>>>>>>>>>
                    EmployeeDtlWork employeeDtlWork = CopyToEmployeeDtlWorkFromEmployeeDtl(employeeDtl);
	    			// XMLへ変換し、文字列のバイナリ化
                    byte[] parabyte2 = XmlByteSerializer.Serialize(employeeDtlWork);
                    // 従業員物理削除
                    int status2 = this._iEmployeeDtlDB.Delete(parabyte2);

    				if (status2 == 0)
	    			{
			    		// ファイル名を渡して従業員ワーククラスをデシリアライズする
                        employeeDtlWork = (EmployeeDtlWork)XmlByteSerializer.Deserialize(parabyte2, typeof(EmployeeDtlWork));
                        // クラス内メンバコピー
                        employeeDtl = CopyToEmployeeDtlFromEmployeeDtlWork(employeeDtlWork);
    					// Static更新
	    				//_employeeTable_Stc.Remove(employee.EmployeeCode.TrimEnd());
                    }
                    // 2007.08.14 追加 <<<<<<<<<<
                }

				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iEmployeeDB = null;
                //通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 従業員検索処理（論理削除除く）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : 従業員検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int GetCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt,enterpriseCode,0);
		}

		/// <summary>
		/// 従業員検索処理（論理削除含む）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : 従業員検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int GetAllCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt,enterpriseCode,ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// 従業員数検索処理
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:全ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 従業員数の検索を行います。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private int GetCntProc(out int retTotalCnt,string enterpriseCode,ConstantManagement.LogicalMode logicalMode)
		{
			EmployeeWork employeeWork = new EmployeeWork();
			employeeWork.EnterpriseCode = enterpriseCode;
			
			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(employeeWork);

			// 従業員検索
            // ----- iitani c ---------- start 2007.05.26
			//int status = this._iEmployeeDB.SearchCnt(out retTotalCnt,parabyte,0,logicalMode);
            int status = 0;
            if (_isLocalDBRead)
            {
                status = this._employeeLcDB.SearchCnt(out retTotalCnt, employeeWork, 0, logicalMode);
            }
            else
            {
                status = this._iEmployeeDB.SearchCnt(out retTotalCnt,parabyte,0,logicalMode);
            }
            // ----- iitani c ---------- end 2007.05.26

			if (status != 0) retTotalCnt = 0;
				
			return status;
		}

		/// <summary>
		/// 従業員全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
        /// <param name="retList2">読込結果コレクション(詳細)</param>
        /// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 従業員の全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 修正 >>>>>>>>>>
        //public int Search(out ArrayList retList, string enterpriseCode)
        public int Search(out ArrayList retList, out ArrayList retList2, string enterpriseCode)
        // 2007.08.14 修正 <<<<<<<<<<
        {
			bool nextData;
			int  retTotalCnt;
            // 2007.08.14 修正 >>>>>>>>>>
            //return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, null);
            return SearchProc(out retList, out retList2, out retTotalCnt, out nextData, enterpriseCode, 0, 0, null, null);
            // 2007.08.14 修正 <<<<<<<<<<
        }

		/// <summary>
		/// 従業員検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
        /// <param name="retList2">読込結果コレクション(詳細)</param>
        /// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 従業員の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 修正 >>>>>>>>>>
        //public int SearchAll(out ArrayList retList, string enterpriseCode)
        public int SearchAll(out ArrayList retList, out ArrayList retList2, string enterpriseCode)
        // 2007.08.14 修正 <<<<<<<<<<
        {
			bool nextData;
			int	 retTotalCnt;
            // 2007.08.14 修正 >>>>>>>>>>
            //return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null);
            return SearchProc(out retList, out retList2, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, null);
            // 2007.08.14 修正 <<<<<<<<<<
        }

		/// <summary>
		/// 件数指定従業員検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
        /// <param name="retList2">読込結果コレクション(詳細)</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevEmployee">前回最終担当者データオブジェクト（初回はnull指定必須）</param>			
        /// <param name="prevEmployeeDtl">前回最終担当者詳細データオブジェクト（初回はnull指定必須）</param>			
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して従業員の検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 修正 >>>>>>>>>>
        //public int Search(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, Employee prevEmployee)
        public int Search(out ArrayList retList, out ArrayList retList2, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, Employee prevEmployee, EmployeeDtl prevEmployeeDtl)
        // 2007.08.14 修正 <<<<<<<<<<
        {
            // 2007.08.14 修正 >>>>>>>>>>
            //return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, readCnt, prevEmployee);
            return SearchProc(out retList, out retList2, out retTotalCnt, out nextData, enterpriseCode, 0, readCnt, prevEmployee, prevEmployeeDtl);
            // 2007.08.14 修正 <<<<<<<<<<
        }

		/// <summary>
		/// 件数指定従業員検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
        /// <param name="retList2">読込結果コレクション(詳細)</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevEmployee">前回最終担当者データオブジェクト（初回はnull指定必須）</param>			
        /// <param name="prevEmployeeDtl">前回最終担当者詳細データオブジェクト（初回はnull指定必須）</param>			
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して従業員の検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 修正 >>>>>>>>>>
        //public int SearchAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, Employee prevEmployee)
        public int SearchAll(out ArrayList retList, out ArrayList retList2, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, Employee prevEmployee, EmployeeDtl prevEmployeeDtl)
        // 2007.08.14 修正 <<<<<<<<<<
        {
            // 2007.08.14 修正 >>>>>>>>>>
            //return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, readCnt, prevEmployee);
            return SearchProc(out retList, out retList2, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, readCnt, prevEmployee, prevEmployeeDtl);
            // 2007.08.14 修正 <<<<<<<<<<
        }

		/// <summary>
		/// 従業員論理削除復活処理
		/// </summary>
		/// <param name="employee">従業員オブジェクト</param>
        /// <param name="employeeDtl">従業員詳細オブジェクト</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 従業員情報の復活を行います。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 修正 >>>>>>>>>>
        //public int Revival(ref Employee employee)
        public int Revival(ref Employee employee, ref EmployeeDtl employeeDtl)
        // 2007.08.14 修正 <<<<<<<<<<
        {
			try
			{
				EmployeeWork employeeWork = CopyToEmployeeWorkFromEmployee(employee);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(employeeWork);
				// 復活処理
				int status = this._iEmployeeDB.RevivalLogicalDelete(ref parabyte);

				if (status == 0)
				{
					// ファイル名を渡して従業員ワーククラスをデシリアライズする
					employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));
					// クラス内メンバコピー
					employee = CopyToEmployeeFromEmployeeWork(employeeWork);
					// Static更新
					_employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employee;


                    // 2007.08.14 追加 >>>>>>>>>>
                    EmployeeDtlWork employeeDtlWork = CopyToEmployeeDtlWorkFromEmployeeDtl(employeeDtl);
	    			// XMLへ変換し、文字列のバイナリ化
                    byte[] parabyte2 = XmlByteSerializer.Serialize(employeeDtlWork);
			    	// 復活処理
                    ArrayList wklist = new ArrayList();
                    wklist.Add(employeeDtlWork);
                    Object listobj = wklist;
                    int status2 = this._iEmployeeDtlDB.RevivalLogicalDelete(ref listobj);

    				if (status2 == 0)
	    			{
				    	// クラス内メンバコピー
                        wklist = (ArrayList)listobj;
                        //employeeDtlWork = (EmployeeDtlWork)listobj;
                        employeeDtlWork = wklist[0] as EmployeeDtlWork;
                        employeeDtl = CopyToEmployeeDtlFromEmployeeDtlWork(employeeDtlWork);
    					// Static更新
	    				//_employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employee;
                        // 2007.08.14 追加 <<<<<<<<<<
			    	}
                }

				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iEmployeeDB = null;
                //通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 従業員検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <param name="belongSectionCode">拠点コード</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="frontMechaCode">受付・メカ区分[-1:全て,0:受付,1:メカ,2:営業]</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 従業員の検索処理を行い、取得結果をDataSetで返します。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int Search(ref DataSet ds, string enterpriseCode, string belongSectionCode, int frontMechaCode)
		{
			EmployeeWork employeeWork = new EmployeeWork();
			employeeWork.EnterpriseCode = enterpriseCode;

			ArrayList ar = new ArrayList();

			int status = 0;
			object objectEmployeeWork;

            //// オンライン且つ、Searchが行われていない場合（オフラインの場合はコンストラクタでStatic展開済み）
            //if ((!_searchFlg) && (LoginInfoAcquisition.OnlineFlag))
            //{
            //    // 従業員サーチ
            //    // ----- iitani c ---------- start 2007.05.26
            //    //status = this._iEmployeeDB.Search(out objectEmployeeWork, employeeWork, 0, ConstantManagement.LogicalMode.GetData01);
            //    if (_isLocalDBRead)
            //    {
            //        List<EmployeeWork> employeeList;
            //        EmployeeWork paraEmp = new EmployeeWork();
            //        paraEmp.EnterpriseCode = enterpriseCode;
            //        paraEmp.BelongSectionCode = belongSectionCode;

            //        status = this._employeeLcDB.Search(out employeeList, paraEmp, 0, ConstantManagement.LogicalMode.GetData0);
            //        ArrayList convList = new ArrayList();
            //        convList.AddRange(employeeList);
            //        objectEmployeeWork = (object)convList;
            //    }
            //    else
            //    {
            //        status = this._iEmployeeDB.Search(out objectEmployeeWork, employeeWork, 0, ConstantManagement.LogicalMode.GetData0);
            //    }
            //    // ----- iitani c ---------- end 2007.05.26
            //    if (status == 0)
            //    {
            //        // 従業員ワーカークラス⇒UIクラスStatic転記処理
            //        CopyToStaticFromWorker(objectEmployeeWork as ArrayList);
            //        // SearchFlg ON
            //        _searchFlg = true;
            //    }
            //    else
            //    {
            //        return status;
            //    }
            //}

            // 従業員サーチ
            // ----- iitani c ---------- start 2007.05.26
            //status = this._iEmployeeDB.Search(out objectEmployeeWork, employeeWork, 0, ConstantManagement.LogicalMode.GetData01);
            if (_isLocalDBRead)
            {
                List<EmployeeWork> employeeList;
                EmployeeWork paraEmp = new EmployeeWork();
                paraEmp.EnterpriseCode = enterpriseCode;
                paraEmp.BelongSectionCode = belongSectionCode;

                status = this._employeeLcDB.Search(out employeeList, paraEmp, 0, ConstantManagement.LogicalMode.GetData0);
                ArrayList convList = new ArrayList();
                convList.AddRange(employeeList);
                objectEmployeeWork = (object)convList;
            }
            else
            {
                status = this._iEmployeeDB.Search(out objectEmployeeWork, employeeWork, 0, ConstantManagement.LogicalMode.GetData0);
            }
            ArrayList retWorkList; 
            // ----- iitani c ---------- end 2007.05.26
            if (status == 0)
            {
                retWorkList = objectEmployeeWork as ArrayList;
                // 従業員ワーカークラス⇒UIクラスStatic転記処理
                CopyToStaticFromWorker(retWorkList);
                // SearchFlg ON
                _searchFlg = true;
            }
            else
            {
                return status;
            }

            ArrayList retList = new ArrayList();
            foreach (EmployeeWork work in retWorkList)
            {
                // ユーザー管理者区分が0の従業員をガイド表示
                if (work.UserAdminFlag == 0)
                {
                    retList.Add(CopyToEmployeeFromEmployeeWork(work));
                }
            }
            foreach (EmployeeWork work in retWorkList)
            {
                // ユーザー管理者区分が0の従業員をガイド表示
                if (work.UserAdminFlag == 0)
                {
                    Employee employee = CopyToEmployeeFromEmployeeWork(work);
                    employee.BelongSectionCode = "00";
                    employee.BelongSectionName = "";
                    retList.Add(employee);
                }
            }

            SortedList sl = new SortedList();  // iitani a 2007.05.29

			// Staticからガイド表示（オン/オフ共通）	
            foreach (Employee employeeWk in retList)
			{
				// ArrayListへメンバコピー
				if (belongSectionCode.Trim() == "")
				{
					// 全社表示
                    // ----- iitani c ---------- start 2007.05.29
                    //ar.Add(employeeWk.Clone());
                    sl.Add(employeeWk.Clone().EmployeeCode, employeeWk.Clone());
                    // ----- iitani c ---------- end 2007.05.29
				}
				else if (belongSectionCode.TrimEnd().Equals(employeeWk.BelongSectionCode.TrimEnd()))
				{
					// 該当拠点の担当者
                    // ----- iitani c ---------- start 2007.05.29
                    //ar.Add(employeeWk.Clone());
                    sl.Add(employeeWk.Clone().EmployeeCode, employeeWk.Clone());
                    // ----- iitani c ---------- end 2007.05.29
				}
			}

            ar.AddRange(sl.Values);  // iitani a 2007.05.29

			// --- 2007.03.29 men add sta ------------------------------------------- //
			Employee[] employees = new Employee[ar.Count];

			// データを元に戻す
			for (int i = 0; i < ar.Count; i++)
			{
				employees[i] = (Employee)ar[i];
			}

			byte[] retbyte = XmlByteSerializer.Serialize(employees);
			XmlByteSerializer.ReadXml(ref ds, retbyte);
			// --- 2007.03.29 men add end ------------------------------------------- //

			//ArrayList wkList = ar.Clone() as ArrayList;
			//SortedList wkSort = new SortedList();

			// --- ここからデータ選別 --- //
			// 受付・メカ区分[-1:全て,0:受付,1:メカ,2:営業]判定
			//switch (frontMechaCode)
			//{
			//    case 0:
			//    {
			//        // --- [受付]のみ --- //
			//        foreach (Employee wkEmployee in wkList)
			//        {
			//            if ((wkEmployee.FrontMechaCode == 0) &&
			//                    (wkEmployee.LogicalDeleteCode == 0))
			//            {
			//                wkSort.Add(wkEmployee.EmployeeCode, wkEmployee);
			//            }
			//        }

			//        break;
			//    }
			//    case 1:
			//    {
			//        // --- [メカ]のみ --- //
			//        foreach (Employee wkEmployee in wkList)
			//        {
			//            if ((wkEmployee.FrontMechaCode == 1) &&
			//                    (wkEmployee.LogicalDeleteCode == 0))
			//            {
			//                wkSort.Add(wkEmployee.EmployeeCode, wkEmployee);
			//            }
			//        }

			//        break;
			//    }
			//    case 2:
			//    {
			//        // --- [営業]のみ --- //
			//        foreach (Employee wkEmployee in wkList)
			//        {
			//            if ((wkEmployee.FrontMechaCode == 2) &&
			//                    (wkEmployee.LogicalDeleteCode == 0))
			//            {
			//                wkSort.Add(wkEmployee.EmployeeCode, wkEmployee);
			//            }
			//        }

			//        break;
			//    }
			//    default:
			//    {
			//        // --- [全て] --- //
			//        // そのまま全件返す
			//        foreach (Employee wkEmployee in wkList)
			//        {
			//            if (wkEmployee.LogicalDeleteCode == 0)
			//            {
			//                wkSort.Add(wkEmployee.EmployeeCode, wkEmployee);
			//            }
			//        }

			//        break;
			//    }
			//}

			//Employee[] employees = new Employee[wkSort.Count];

			// データを元に戻す
			//for (int i=0; i < wkSort.Count; i++)
			//{
			//    employees[i] = (Employee)wkSort.GetByIndex(i);
			//}

			//byte[] retbyte = XmlByteSerializer.Serialize(employees);
			//XmlByteSerializer.ReadXml(ref ds, retbyte);

			return status;
		}

        // 2010/02/18 Add >>>
        /// <summary>
        /// フェリカ管理スタティックキャッシュ更新
        /// </summary>
        /// <param name="item">更新するデータ</param>
        /// <remarks>
        /// <br>Note       : フェリカ管理スタティックキャッシュを更新します</br>
        /// <br>Programer  : 30517 夏野 駿希</br>
        /// <br>Date       : 2010/02/18</br>
        /// </remarks>
        private bool Remove_felicaMngWkList_Stc(FeliCaMngWork item)
        {
            FeliCaMngWork target;
            target = _felicaMngWkList_Stc.Find(delegate(FeliCaMngWork felicaMngWk)
            {
                return ((felicaMngWk.FeliCaMngKind == item.FeliCaMngKind) && (felicaMngWk.FeliCaIDm == item.FeliCaIDm));
            });
            if (target == null) return true;
            return _felicaMngWkList_Stc.Remove(target);
        }

        /// <summary>
        /// フェリカ管理検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : フェリカ管理の検索処理を行います。</br>
        /// <br>Programmer : 30517 夏野 駿希</br>
        /// <br>Date       : 2010/02/18</br>
        /// </remarks>
        private int SearchProc_Felica(out List<FeliCaMngWork> retList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            FeliCaMngWork feliCaMngWork = new FeliCaMngWork();
            feliCaMngWork.EnterpriseCode = enterpriseCode;  // 企業コード
            feliCaMngWork.FeliCaMngKind = 1;                // 従業員のみ
            retList = new List<FeliCaMngWork>();

            int status;
            object paraobj = (object)feliCaMngWork;

            // オフラインの場合はキャッシュから読む
            if (!LoginInfoAcquisition.OnlineFlag)
            {
                status = SearchStaticMemory_FeliCa(out retList);
            }
            else
            {
                object objectFeliCaMngWork = null;

                // フェリカ管理検索
                status = this._iFeliCaMngDB.Search(out objectFeliCaMngWork, paraobj, logicalMode);

                if (objectFeliCaMngWork == null) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                if (status == 0)
                {
                    // パラメータが渡って来ているか確認
                    _felicaMngWkList_Stc = new List<FeliCaMngWork>();
                    foreach (FeliCaMngWork felicaMngWk in (ArrayList)objectFeliCaMngWork)
                    {
                        retList.Add(felicaMngWk);
                    }
                }
            }
            return status;
        }
        // 2010/02/18 Add <<<

		/// <summary>
		/// クラスメンバーコピー処理（従業員ワーククラス⇒従業員クラス）
		/// </summary>
		/// <param name="employeeWork">従業員ワーククラス</param>
		/// <returns>従業員クラス</returns>
		/// <remarks>
		/// <br>Note       : 従業員ワーククラスから従業員クラスへメンバーのコピーを行います。（レイアウト分のみ）</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.15</br>
		/// </remarks>
		public static Employee CopyToEmployee(EmployeeWork employeeWork)
		{
			Employee employee = new Employee();

			employee.CreateDateTime			= employeeWork.CreateDateTime;
			employee.UpdateDateTime			= employeeWork.UpdateDateTime;
			employee.EnterpriseCode			= employeeWork.EnterpriseCode;
			employee.FileHeaderGuid			= employeeWork.FileHeaderGuid;
			employee.UpdEmployeeCode		= employeeWork.UpdEmployeeCode;
			employee.UpdAssemblyId1			= employeeWork.UpdAssemblyId1;
			employee.UpdAssemblyId2			= employeeWork.UpdAssemblyId2;
			employee.LogicalDeleteCode		= employeeWork.LogicalDeleteCode;

			employee.EmployeeCode			= employeeWork.EmployeeCode;
			employee.Name					= employeeWork.Name;
			employee.Kana					= employeeWork.Kana;
			employee.ShortName				= employeeWork.ShortName;
			employee.SexCode				= employeeWork.SexCode;
			employee.SexName				= employeeWork.SexName;
			employee.Birthday				= employeeWork.Birthday;
			employee.CompanyTelNo			= employeeWork.CompanyTelNo;
			employee.PortableTelNo			= employeeWork.PortableTelNo;
			employee.PostCode				= employeeWork.PostCode;
			employee.BusinessCode			= employeeWork.BusinessCode;
            //employee.FrontMechaCode			= employeeWork.FrontMechaCode;
			employee.InOutsideCompanyCode	= employeeWork.InOutsideCompanyCode;
			employee.BelongSectionCode		= employeeWork.BelongSectionCode;
            //employee.LvrRtCstGeneral		= employeeWork.LvrRtCstGeneral;
            //employee.LvrRtCstCarInspect		= employeeWork.LvrRtCstCarInspect;
            //employee.LvrRtCstBodyRepair		= employeeWork.LvrRtCstBodyRepair;
            //employee.LvrRtCstBodyPaint		= employeeWork.LvrRtCstBodyPaint;
			employee.LoginId				= employeeWork.LoginId;
			employee.LoginPassword			= employeeWork.LoginPassword;
			employee.UserAdminFlag			= employeeWork.UserAdminFlag;
			employee.EnterCompanyDate		= employeeWork.EnterCompanyDate;
			employee.RetirementDate			= employeeWork.RetirementDate;

            employee.AuthorityLevel1        = employeeWork.AuthorityLevel1;
            employee.AuthorityLevel2        = employeeWork.AuthorityLevel2;

			// -- Add St 2012.05.29 30182 R.Tachiya --
			employee.SalSlipInpBootCnt = employeeWork.SalSlipInpBootCnt;
			employee.CustLedgerBootCnt = employeeWork.CustLedgerBootCnt;
			// -- Add Ed 2012.05.29 30182 R.Tachiya --

			return employee;
		}

        // 2007.08.14 追加 >>>>>>>>>>
        /// <summary>
        /// クラスメンバーコピー処理（従業員詳細ワーククラス⇒従業員詳細クラス）
        /// </summary>
        /// <param name="employeeDtlWork">従業員詳細ワーククラス</param>
        /// <returns>従業員詳細クラス</returns>
        /// <remarks>
        /// <br>Note       : 従業員詳細ワーククラスから従業員詳細クラスへメンバーのコピーを行います。（レイアウト分のみ）</br>
        /// <br>Programmer : 980035 金沢  貞義</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        public static EmployeeDtl CopyToEmployeeDtl(EmployeeDtlWork employeeDtlWork)
        {
            EmployeeDtl employeeDtl = new EmployeeDtl();

            employeeDtl.CreateDateTime = employeeDtlWork.CreateDateTime;
            employeeDtl.UpdateDateTime = employeeDtlWork.UpdateDateTime;
            employeeDtl.EnterpriseCode = employeeDtlWork.EnterpriseCode;
            employeeDtl.FileHeaderGuid = employeeDtlWork.FileHeaderGuid;
            employeeDtl.UpdEmployeeCode = employeeDtlWork.UpdEmployeeCode;
            employeeDtl.UpdAssemblyId1 = employeeDtlWork.UpdAssemblyId1;
            employeeDtl.UpdAssemblyId2 = employeeDtlWork.UpdAssemblyId2;
            employeeDtl.LogicalDeleteCode = employeeDtlWork.LogicalDeleteCode;

            employeeDtl.EmployeeCode = employeeDtlWork.EmployeeCode;
            employeeDtl.BelongSubSectionCode = employeeDtlWork.BelongSubSectionCode;
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            employeeDtl.BelongSubSectionName = employeeDtlWork.BelongSubSectionName;
            employeeDtl.BelongMinSectionCode = employeeDtlWork.BelongMinSectionCode;
            employeeDtl.BelongMinSectionName = employeeDtlWork.BelongMinSectionName;
            employeeDtl.BelongSalesAreaCode  = employeeDtlWork.BelongSalesAreaCode;
            employeeDtl.BelongSalesAreaName  = employeeDtlWork.BelongSalesAreaName;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            employeeDtl.EmployAnalysCode1 = employeeDtlWork.EmployAnalysCode1;
            employeeDtl.EmployAnalysCode2 = employeeDtlWork.EmployAnalysCode2;
            employeeDtl.EmployAnalysCode3 = employeeDtlWork.EmployAnalysCode3;
            employeeDtl.EmployAnalysCode4 = employeeDtlWork.EmployAnalysCode4;
            employeeDtl.EmployAnalysCode5 = employeeDtlWork.EmployAnalysCode5;
            employeeDtl.EmployAnalysCode6 = employeeDtlWork.EmployAnalysCode6;

            // 2008.11.10 add start --------------------------------------------->>
            employeeDtl.UOESnmDiv = employeeDtlWork.UOESnmDiv;
            // 2008.11.10 add end -----------------------------------------------<<
            
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            employeeDtl.OldBelongSectionCd = employeeDtlWork.OldBelongSectionCd;
            employeeDtl.OldBelongSectionNm = employeeDtlWork.OldBelongSectionNm;
            employeeDtl.OldBelongSubSecCd = employeeDtlWork.OldBelongSubSecCd;
            employeeDtl.OldBelongSubSecNm = employeeDtlWork.OldBelongSubSecNm;
            employeeDtl.OldBelongMinSecCd = employeeDtlWork.OldBelongMinSecCd;
            employeeDtl.OldBelongMinSecNm = employeeDtlWork.OldBelongMinSecNm;
            employeeDtl.SectionChgDate = employeeDtlWork.SectionChgDate;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            employeeDtl.MailAddrKindCode1 = employeeDtlWork.MailAddrKindCode1;
            employeeDtl.MailAddrKindName1 = employeeDtlWork.MailAddrKindName1;
            employeeDtl.MailAddress1 = employeeDtlWork.MailAddress1;
            employeeDtl.MailSendCode1 = employeeDtlWork.MailSendCode1;
            employeeDtl.MailAddrKindCode2 = employeeDtlWork.MailAddrKindCode2;
            employeeDtl.MailAddrKindName2 = employeeDtlWork.MailAddrKindName2;
            employeeDtl.MailAddress2 = employeeDtlWork.MailAddress2;
            employeeDtl.MailSendCode2 = employeeDtlWork.MailSendCode2;
            // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return employeeDtl;
        }
        // 2007.08.14 追加 <<<<<<<<<<

		#region ▼マスメンUIクラス用参照処理
		/// <summary>
		/// 拠点名称取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>拠点名称</returns>
		/// <remarks>
		/// <br>Note       : 拠点名称を返します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.09.20</br>
		/// </remarks>
		public string GetSectionName(string enterpriseCode, string sectionCode)
		{
			//----- ueno add ---------- start 2008.02.12
			// ローカルＤＢ拠点対応
			ConstructSecInfoAcs();
			//----- ueno add ---------- end 2008.02.12

			foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
			{
				if (secInfoSet.SectionCode.TrimEnd() == "0")
				{
					return "未登録";
				}
				else if ((secInfoSet.SectionCode.TrimEnd() == sectionCode.TrimEnd()) &&
					(secInfoSet.LogicalDeleteCode == 0))
				{
					return secInfoSet.SectionGuideNm;
				}
			}
			return "未登録";
		}
		#endregion

		#region ▼ガイド起動処理
        // ----- iitani a ---------- start 2007.05.26
        /// <summary>
		/// 従業員ガイド起動処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="dispAllSecInfo">"全社"設定有無[true:設定,false:未設定]</param>
		/// <param name="employee">取得データ</param>
		/// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
		/// <remarks>
		/// <br>Note		: 従業員マスタの一覧表示機能を持つガイドを起動します。</br>
		/// <br>Programmer	: 980023 飯谷 耕平</br>
		/// <br>Date		: 2005.05.26</br>
		/// </remarks>
        public int ExecuteGuid(string enterpriseCode, bool dispAllSecInfo, out Employee employee)
        {
            return this.ExecuteGuid(enterpriseCode, dispAllSecInfo, "", out employee);
        }
        // ----- iitani a ---------- end 2007.05.26
        
        /// <summary>
		/// 従業員ガイド起動処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="dispAllSecInfo">"全社"設定有無[true:設定,false:未設定]</param>
		/// <param name="sectionCode">拠点コード</param>
        /// <param name="employee">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
		/// <remarks>
		/// <br>Note		: 従業員マスタの一覧表示機能を持つガイドを起動します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.05.06</br>
		/// </remarks>
        //public int ExecuteGuid(string enterpriseCode, bool dispAllSecInfo, int frontMechaCode, out Employee employee)
        // ----- iitani c ---------- start 2007.05.26
        //public int ExecuteGuid(string enterpriseCode, bool dispAllSecInfo, out Employee employee)
        public int ExecuteGuid(string enterpriseCode, bool dispAllSecInfo, string sectionCode, out Employee employee)
        // ----- iitani c ---------- end 2007.05.26
        {
			int status = -1;
			employee = new Employee();

            // ----- iitani c ---------- start 2007.05.26
            //TableGuideParent tableGuideParent = new TableGuideParent("EMPLOYEEKTNGUIDEPARENT.XML");
            string xmlName = "";
            if (sectionCode == "")
            {
                xmlName = "EMPLOYEEKTNGUIDEPARENT.XML";
            }
            else
            {
                xmlName = "EMPLOYEEGUIDEPARENT.XML";
            }
            TableGuideParent tableGuideParent = new TableGuideParent(xmlName);
            // ----- iitani c ---------- end 2007.05.26

			Hashtable inObj = new Hashtable();
			Hashtable retObj = new Hashtable();

			// 企業コード
			inObj.Add("EnterpriseCode", enterpriseCode);
            inObj.Add("SectionCode", sectionCode);       // iitani a 2007.05.26
			// 受付・メカ区分
            //inObj.Add("FrontMechaCode", frontMechaCode);
            // 2007.08.14 修正 >>>>>>>>>>
            // "全社"設定制御
			//if (_optSection)
			//	inObj.Add("DispAllSecInfo", dispAllSecInfo);
			//else
			//	inObj.Add("DispAllSecInfo", false);
            inObj.Add("DispAllSecInfo", dispAllSecInfo);
            // 2007.08.14 修正 <<<<<<<<<<

			if (tableGuideParent.Execute(0, inObj, ref retObj))
			{
				employee.EmployeeCode			= retObj["EmployeeCode"].ToString();
				employee.Name					= retObj["Name"].ToString();
				employee.Kana					= retObj["Kana"].ToString();
				employee.ShortName				= retObj["ShortName"].ToString();
				employee.SexCode				= Convert.ToInt32(retObj["SexCode"]);
				employee.SexName				= retObj["SexName"].ToString();
				employee.Birthday				= Convert.ToDateTime(retObj["Birthday"]);
				employee.CompanyTelNo			= retObj["CompanyTelNo"].ToString();
				employee.PortableTelNo			= retObj["PortableTelNo"].ToString();
				employee.PostCode				= Convert.ToInt32(retObj["PostCode"]);
				employee.BusinessCode			= Convert.ToInt32(retObj["BusinessCode"]);
                //employee.FrontMechaCode			= Convert.ToInt32(retObj["FrontMechaCode"]);
				employee.InOutsideCompanyCode	= Convert.ToInt32(retObj["InOutsideCompanyCode"]);
				
                Employee emp = (Employee)_employeeTable_Stc[employee.EmployeeCode.Trim()];
                
                //employee.BelongSectionCode		= retObj["BelongSectionCode"].ToString();
                employee.BelongSectionCode = emp.BelongSectionCode.Trim();
                //employee.LvrRtCstGeneral		= Convert.ToInt64(retObj["LvrRtCstGeneral"]);
                //employee.LvrRtCstCarInspect		= Convert.ToInt64(retObj["LvrRtCstCarInspect"]);
                //employee.LvrRtCstBodyRepair		= Convert.ToInt64(retObj["LvrRtCstBodyRepair"]);
                //employee.LvrRtCstBodyPaint		= Convert.ToInt64(retObj["LvrRtCstBodyPaint"]);
				employee.LoginId				= retObj["LoginId"].ToString();
				employee.LoginPassword			= retObj["LoginPassword"].ToString();
				employee.EnterCompanyDate		= Convert.ToDateTime(retObj["EnterCompanyDate"]);
				employee.RetirementDate			= Convert.ToDateTime(retObj["RetirementDate"]);
                //employee.FrontMechaName         = retObj["FrontMechaName"].ToString();
				employee.InOutsideCompanyName   = retObj["InOutsideCompanyName"].ToString();
				//                employee.PostName               = retObj["PostName"].ToString();
				//                employee.BusinessName           = retObj["BusinessName"].ToString();
				//                employee.BelongSectionName      = retObj["BelongSectionName"].ToString();

                employee.AuthorityLevel1 = Convert.ToInt32(retObj["AuthorityLevel1"]);
                employee.AuthorityLevel2 = Convert.ToInt32(retObj["AuthorityLevel2"]);

				// -- Add St 2012.05.29 30182 R.Tachiya --
				employee.SalSlipInpBootCnt = Convert.ToInt32(retObj["SalSlipInpBootCnt"]);
				employee.CustLedgerBootCnt = Convert.ToInt32(retObj["CustLedgerBootCnt"]);
				// -- Add Ed 2012.05.29 30182 R.Tachiya --

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
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.05.06</br>
		/// </remarks>
		public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
		{
			int status   = -1;
			string enterpriseCode = "";
			string sectionCode    = "";
			int frontMechaCode = -1;


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

			// 拠点コード
			if (inParm.ContainsKey("SectionCode"))
			{
				sectionCode = inParm["SectionCode"].ToString();
			}

			// 受付・メカ区分[-1:全て,0:受付,1:メカ,2:営業]
            //if (inParm.ContainsKey("FrontMechaCode"))
            //{
            //    frontMechaCode = (int)inParm["FrontMechaCode"];
            //}

			// 従業員テーブル読込み
            // ----- iitani c ---------- start 2007.05.26
			//status = Search(ref guideList, enterpriseCode, sectionCode, frontMechaCode);
            // 2007.08.14 修正 >>>>>>>>>>
            //status = SearchLocal(ref guideList, enterpriseCode, sectionCode, frontMechaCode);
            status = Search(ref guideList, enterpriseCode, sectionCode, frontMechaCode);
            // 2007.08.14 修正 <<<<<<<<<<
            // ----- iitani c ---------- end 2007.05.26
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

        #region ローカルＤＢ対応
        /// <summary>
        /// 指定された検索条件で従業員を検索します。（ローカル読み）
        /// </summary>
        /// <param name="retList">検索結果List</param>
        /// <param name="paraEmployee">検索条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 指定された検索条件で従業員マスタを検索します。</br>
        /// <br>Programmer	: 18322 木村 武正</br>
        /// <br>Date		: 2007.05.21</br>
        /// </remarks>
        public int SearchLocal(out ArrayList retList, Employee paraEmployee)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            retList = new ArrayList();

            try
            {
                if (_localDataSet.Tables[LOCAL_EMPLOYEE_TABLE].Rows.Count > 0)
                {
                    string where = LOCAL_SECTIONCODE + " = '" + paraEmployee.BelongSectionCode + "'";
                    if (paraEmployee.EmployeeCode != "")
                    {
                        where += " AND " + LOCAL_EMPLOYEECODE + " = '"+ paraEmployee.EmployeeCode +"'";
                    }
                    DataRow[] drList = _localDataSet.Tables[LOCAL_EMPLOYEE_TABLE].Select(where, LOCAL_EMPLOYEECODE + " ASC");
                    int maxIndex2 = drList.Length;

                    if (maxIndex2 > 0)
                    {
                        for (int index = 0; maxIndex2 > index; index++)
                        {
                            Employee employee = this.CopyToEmployeeFromEmployeeWork((EmployeeWork)drList[index][LOCAL_EMPLOYEE_RECORD]);
                            retList.Add(employee);
                        }

                        return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                
                // データなし -> ローカルＤＢよりデータを取得
                EmployeeWork paraEmp = new EmployeeWork();
                paraEmp.EnterpriseCode    = paraEmployee.EnterpriseCode;
                paraEmp.BelongSectionCode = paraEmployee.BelongSectionCode;

                List<EmployeeWork> employeeList;
                status = this._employeeLcDB.Search(out employeeList, paraEmp, 0, ConstantManagement.LogicalMode.GetData0);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // データを格納
                retList.Clear();
                _localDataSet.Tables[LOCAL_EMPLOYEE_TABLE].Rows.Clear();
                int maxIndex = employeeList.Count;
                for (int index = 0; maxIndex > index; index++)
                {
                    if ((paraEmployee.BelongSectionCode.TrimEnd() == "") ||
                        (paraEmployee.BelongSectionCode.TrimEnd() == employeeList[index].BelongSectionCode.TrimEnd())) 
                    {
                        DataRow dr = _localDataSet.Tables[LOCAL_EMPLOYEE_TABLE].NewRow();
                        dr[LOCAL_SECTIONCODE] = employeeList[index].BelongSectionCode;
                        dr[LOCAL_EMPLOYEECODE] = employeeList[index].EmployeeCode;

                        dr[LOCAL_EMPLOYEE_RECORD] = employeeList[index];

                        _localDataSet.Tables[LOCAL_EMPLOYEE_TABLE].Rows.Add(dr);
                        retList.Add(this.CopyToEmployeeFromEmployeeWork(employeeList[index]));
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        // ----- iitani a ---------- start 2007.05.26
        /// <summary>
        /// 従業員検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="belongSectionCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="frontMechaCode">受付・メカ区分[-1:全て,0:受付,1:メカ,2:営業]</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 従業員の検索処理を行い、取得結果をDataSetで返します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2005.05.26</br>
        /// </remarks>
        public int SearchLocal(ref DataSet ds, string enterpriseCode, string belongSectionCode, int frontMechaCode)
        {
            EmployeeWork employeeWork = new EmployeeWork();
            employeeWork.EnterpriseCode = enterpriseCode;

            ArrayList ar = new ArrayList();

            int status = 0;
            List<EmployeeWork> employeeWorkList;

            // オンライン且つ、Searchが行われていない場合（オフラインの場合はコンストラクタでStatic展開済み）
            //if ((!_searchFlg) && (LoginInfoAcquisition.OnlineFlag)) // 2009.08.07
            if (!_searchFlg) // 2009.08.07
            {
                // 従業員サーチ
                status = this._employeeLcDB.Search(out employeeWorkList, employeeWork, 0, ConstantManagement.LogicalMode.GetData0);

                if (status == 0)
                {
                    ArrayList al = new ArrayList();
                    al.AddRange(employeeWorkList);
                    // 従業員ワーカークラス⇒UIクラスStatic転記処理
                    CopyToStaticFromWorker(al);
                    // SearchFlg ON
                    _searchFlg = true;
                }
                else
                {
                    return status;
                }
            }

            SortedList sl = new SortedList();  // iitani a 2007.05.29

            // Staticからガイド表示（オン/オフ共通）	
            foreach (Employee employeeWk in _employeeTable_Stc.Values)
            {
                // ArrayListへメンバコピー
                if (belongSectionCode.Trim() == "")
                {
                    // 全社表示
                    // ----- iitani c ---------- start 2007.05.29
                    //ar.Add(employeeWk.Clone());
                    sl.Add(employeeWk.Clone().EmployeeCode, employeeWk.Clone());
                    // ----- iitani c ---------- end 2007.05.29
                }
                else if (belongSectionCode.TrimEnd().Equals(employeeWk.BelongSectionCode.TrimEnd()))
                {
                    // 該当拠点の担当者
                    // ----- iitani c ---------- start 2007.05.29
                    //ar.Add(employeeWk.Clone());
                    sl.Add(employeeWk.Clone().EmployeeCode, employeeWk.Clone());
                    // ----- iitani c ---------- end 2007.05.29
                }
            }

            ar.AddRange(sl.Values);  // iitani a 2007.05.29

            Employee[] employees = new Employee[ar.Count];

            // データを元に戻す
            for (int i = 0; i < ar.Count; i++)
            {
                employees[i] = (Employee)ar[i];
            }

            byte[] retbyte = XmlByteSerializer.Serialize(employees);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }
        // ----- iitani a ---------- end 2007.05.26
        #endregion

        // 2010/02/18 Add >>>
        #region FeliCaMngアクセス分
        /// <summary>
        /// フェリカ管理マスタStaticメモリ全件取得処理
        /// </summary>
        /// <param name="retList">フェリカ管理クラスList</param>
        /// <returns>ステータス(0:正常終了, -1:エラー, 9:データ無し)</returns>
        /// <remarks>
        /// <br>Note       : フェリカ管理マスタStaticメモリの全件を取得します。</br>
        /// <br>Programer  : 22011 柏原　頼人</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        public int SearchStaticMemory_FeliCa(out List<FeliCaMngWork> retList)
        {
            retList = new List<FeliCaMngWork>();
            retList.Clear();

            if (_felicaMngWkList_Stc == null)
            {
                SearchAll_FeliCa(out _felicaMngWkList_Stc, LoginInfoAcquisition.EnterpriseCode);
            }
            else if (_felicaMngWkList_Stc.Count == 0)
            {
                return 9;
            }

            retList = _felicaMngWkList_Stc;
            return 0;
        }

        /// <summary>
        /// フェリカ管理マスタStaticメモリ取得処理
        /// </summary>
        /// <param name="feliCaMng">フェリカ管理マスタ</param>
        /// <param name="feliCaIdm">フェリカIDm</param>
        /// <param name="felicaMngKind">フェリカ管理種別</param>
        /// <returns>ステータス(0:正常終了, -1:エラー, 4:データ無し)</returns>
        /// <remarks>
        /// <br>Note       : フェリカ管理マスタStaticメモリを検索します。</br>
        /// <br>Programer  : 22011 柏原　頼人</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        public int ReadStaticMemory_FeliCa(out FeliCaMngWork feliCaMng, string feliCaIdm, Int32 felicaMngKind)
        {
            feliCaMng = null;

            if (_felicaMngWkList_Stc == null)
            {
                SearchAll_FeliCa(out _felicaMngWkList_Stc, LoginInfoAcquisition.EnterpriseCode);
            }
            if (_felicaMngWkList_Stc.Count == 0) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            feliCaMng = _felicaMngWkList_Stc.Find(delegate(FeliCaMngWork target)
            {
                return ((target.FeliCaIDm == feliCaIdm) && (target.FeliCaMngKind == felicaMngKind));
            });

            // Staticから検索
            if (feliCaMng == null)
            {
                feliCaMng = null;
                return 4;
            }

            return 0;
        }

        /// <summary>
        /// フェリカ管理リストStaticセット処理
        /// </summary>
        /// <param name="feliCaMngList">セットするフェリカ管理情報リスト</param>
        /// <remarks>
        /// <br>Note		: フェリカ管理リストをStatic領域にセットします。</br>
        /// <br>Programmer	: 22011 柏原　頼人</br>
        /// <br>Date		: 2008.11.06</br>
        /// </remarks>
        public void SetStaticMemory_FeliCa(List<FeliCaMngWork> feliCaMngList)
        {
            // オフラインモードの場合 → 既に取得済み（コンストラクタにて取得）なので、処理しない
            if (!LoginInfoAcquisition.OnlineFlag) return;
            if (feliCaMngList == null) return;
            // スタティックキャッシュを上書き
            _felicaMngWkList_Stc = feliCaMngList;
        }

        /// <summary>
        /// フェリカ管理登録・更新処理
        /// </summary>
        /// <param name="feliCaMng">フェリカ管理クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : フェリカ管理情報の登録・更新を行います。</br>
        /// <br>Programmer : 22011 柏原　頼人</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        public int Write_Felica(ref FeliCaMngWork feliCaMng)
        {
            int status = 0;
            try
            {
                List<FeliCaMngWork> paraLst = new List<FeliCaMngWork>();
                paraLst.Add(feliCaMng);
                object paraObj = (object)paraLst;

                //フェリカ管理書き込み
                status = this._iFeliCaMngDB.Write(ref paraObj);
                if ((status == 0) && (((List<FeliCaMngWork>)paraObj).Count > 0))
                {
                    feliCaMng = ((List<FeliCaMngWork>)paraObj)[0];
                    // Staticデータ更新
                    Update_felicaMngWkList_Stc(feliCaMng);
                }
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iFeliCaMngDB = null;
                //通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// フェリカ管理論理削除処理
        /// </summary>
        /// <param name="feliCaMng">フェリカ管理オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : フェリカ管理情報の論理削除を行います。</br>
        /// <br>Programmer : 22011 柏原　頼人</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        public int LogicalDelete_FeliCa(ref FeliCaMngWork feliCaMng)
        {
            try
            {
                object paraObj = (object)feliCaMng;
                // フェリカ管理論理削除
                int status = this._iFeliCaMngDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    // Static更新
                    feliCaMng = paraObj as FeliCaMngWork;
                    Update_felicaMngWkList_Stc(feliCaMng);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iFeliCaMngDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// フェリカ管理物理削除処理
        /// </summary>
        /// <param name="feliCaMng">フェリカ管理オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : フェリカ管理情報の物理削除を行います。</br>
        /// <br>Programmer : 22011 柏原　頼人</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        public int Delete_FeliCa(FeliCaMngWork feliCaMng)
        {
            try
            {
                // フェリカ管理物理削除
                int status = this._iFeliCaMngDB.Delete(feliCaMng);

                if (status == 0)
                {
                    // Static更新
                    Remove_felicaMngWkList_Stc(feliCaMng);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iFeliCaMngDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// フェリカ管理検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : フェリカ管理の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 22011 柏原　頼人</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        public int SearchAll_FeliCa(out List<FeliCaMngWork> retList, string enterpriseCode)
        {
            return SearchProc_Felica(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        /// フェリカ管理論理削除復活処理
        /// </summary>
        /// <param name="feliCaMng">フェリカ管理オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : フェリカ管理情報の復活を行います。</br>
        /// <br>Programmer : 22011 柏原　頼人</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        public int Revival_FeliCa(ref FeliCaMngWork feliCaMng)
        {
            try
            {
                object paraObj = (object)feliCaMng;
                int status = this._iFeliCaMngDB.RevivalLogicalDelete(ref paraObj);

                if (status == 0)
                {
                    // Static更新
                    feliCaMng = paraObj as FeliCaMngWork;
                    Update_felicaMngWkList_Stc(feliCaMng);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iFeliCaMngDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// フェリカ管理スタティックキャッシュ更新
        /// </summary>
        /// <param name="item">更新するデータ</param>
        /// <remarks>
        /// <br>Note       : フェリカ管理スタティックキャッシュを更新します</br>
        /// <br>Programer  : 22011 柏原　頼人</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        public void Update_felicaMngWkList_Stc(FeliCaMngWork item)
        {
            if (Remove_felicaMngWkList_Stc(item))
                _felicaMngWkList_Stc.Add(item);
        }
        #endregion
        // 2010/02/18 Add <<<

        #endregion

        #region ■Private Method
        /// <summary>
		/// 従業員検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
        /// <param name="retList2">読込結果コレクション(詳細)</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
		/// <param name="prevEmployee">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
        /// <param name="prevEmployeeDtl">前回最終担当者詳細データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 従業員の検索処理を行います。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 修正 >>>>>>>>>>
        //private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, Employee prevEmployee)
        private int SearchProc(out ArrayList retList, out ArrayList retList2, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, Employee prevEmployee, EmployeeDtl prevEmployeeDtl)
        // 2007.08.14 修正 <<<<<<<<<<
        {
			EmployeeWork employeeWork = new EmployeeWork();
            // 2007.08.14 修正 >>>>>>>>>>
            //if (prevEmployee != null) employeeWork = CopyToEmployeeWorkFromEmployee(prevEmployee);
            EmployeeDtlWork employeeDtlWork = new EmployeeDtlWork();
            if (prevEmployee != null)
            {
                employeeWork = CopyToEmployeeWorkFromEmployee(prevEmployee);
                employeeDtlWork = CopyToEmployeeDtlWorkFromEmployeeDtl(prevEmployeeDtl);
            }
            // 2007.08.14 修正 <<<<<<<<<<
            employeeWork.EnterpriseCode = enterpriseCode;
            employeeDtlWork.EnterpriseCode = enterpriseCode;    // 2007.08.14 追加
			
			int status;

			//次データ有無初期化
			nextData = false;
			//0で初期化
			retTotalCnt = 0;

			retList = new ArrayList();
            retList2 = new ArrayList();             // 2007.08.14 追加
            retList.Clear();
            retList2.Clear();                       // 2007.08.14 追加
            ArrayList paraList = new ArrayList();
            ArrayList paraList2 = new ArrayList();  // 2007.08.14 追加

			// オフラインの場合はキャッシュから読む
            // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    status = SearchStaticMemory(out retList);

            //}
            //else
            //{
            // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                object objectEmployeeWork = null; 
				
				// 従業員検索
				if (readCnt == 0)
				{
					//----- ueno upd ---------- start 2008.01.31
					if (_isLocalDBRead)
					{
						List<EmployeeWork> employeeWorkList = new List<EmployeeWork>();
						status = this._employeeLcDB.Search(out employeeWorkList, employeeWork, 0, logicalMode);

						ArrayList convList = new ArrayList();
						convList.AddRange(employeeWorkList);
						objectEmployeeWork = (object)convList;
					}
					else
					{
						status = this._iEmployeeDB.Search(out objectEmployeeWork,employeeWork,0,logicalMode);
					}
					//----- ueno upd ---------- end 2008.01.31
				}
				else
				{
					//----- ueno upd ---------- start 2008.01.31
					if (_isLocalDBRead)
					{
						List<EmployeeWork> employeeWorkList = new List<EmployeeWork>();
						status = this._employeeLcDB.SearchSpecification(out employeeWorkList, out retTotalCnt, out nextData, employeeWork, 0, logicalMode, readCnt);

						ArrayList convList = new ArrayList();
						convList.AddRange(employeeWorkList);
						objectEmployeeWork = (object)convList;
					}
					else
					{
						status = this._iEmployeeDB.SearchSpecification(out objectEmployeeWork,out retTotalCnt,out nextData,employeeWork,0,logicalMode,readCnt);
					}
					//----- ueno upd ---------- end 2008.01.31
				}
				
				if (status == 0)
				{
					// 従業員ワーカークラス⇒UIクラスStatic転記処理
					CopyToStaticFromWorker(objectEmployeeWork as ArrayList);
					// パラメータが渡って来ているか確認
					paraList = objectEmployeeWork as ArrayList;
					EmployeeWork[] wkEmployeeWork = new EmployeeWork[paraList.Count];

					// データを元に戻す
					for(int i=0; i < paraList.Count; i++)
					{
						wkEmployeeWork[i] = (EmployeeWork)paraList[i];
					}
					for(int i=0; i < wkEmployeeWork.Length; i++)
					{
						// サーチ結果取得
						retList.Add(CopyToEmployeeFromEmployeeWork(wkEmployeeWork[i]));
					}

					// SearchFlg ON
					_searchFlg = true;
				}

                // 2007.08.14 追加 >>>>>>>>>>
                // 従業員詳細検索
                object objectEmployeeDtlWork = null;
                paraList.Clear();

				//----- ueno upd ---------- start 2008.01.31
				// ローカル
				if (_isLocalDBRead)
				{
					List<EmployeeDtlWork> employeeDtlWorkList = new List<EmployeeDtlWork>();
					status = this._employeeDtlLcDB.Search(out employeeDtlWorkList, employeeDtlWork, 0, logicalMode);
					
					if(status == 0)
					{
						ArrayList al = new ArrayList();
						al.AddRange(employeeDtlWorkList);
						objectEmployeeDtlWork = (object)al;
					}
				}
				// リモート
				else
				{
	                status = this._iEmployeeDtlDB.Search(out objectEmployeeDtlWork, employeeDtlWork, 0, logicalMode);
				}
				//----- ueno upd ---------- end 2008.01.31

                if (status == 0)
                {
                    // 従業員詳細ワーカークラス⇒UIクラスStatic転記処理
                    CopyToStaticFromWorker2(objectEmployeeDtlWork as ArrayList);
                    // パラメータが渡って来ているか確認
                    paraList2 = objectEmployeeDtlWork as ArrayList;
                    EmployeeDtlWork[] wkEmployeeDtlWork = new EmployeeDtlWork[paraList2.Count];

                    // データを元に戻す
                    for (int i = 0; i < paraList2.Count; i++)
                    {
                        wkEmployeeDtlWork[i] = (EmployeeDtlWork)paraList2[i];
                    }
                    for (int i = 0; i < wkEmployeeDtlWork.Length; i++)
                    {
                        // サーチ結果取得
                        retList2.Add(CopyToEmployeeDtlFromEmployeeDtlWork(wkEmployeeDtlWork[i]));
                    }

                    // SearchFlg ON
                    _searchFlg = true;
                }
                // 2007.08.14 追加 <<<<<<<<<<

            //} // 2009.08.07
			//全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        // 2009.02.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 従業員全検索処理（論理削除除き、従業員情報のみ取得）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retList2">読込結果コレクション(詳細)</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>従業員情報の取得のみを行い、余計なセット等は行わない</remarks>
        public int SearchOnlyEmployeeInfo(out ArrayList retList, out ArrayList retList2, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchOnlyEmployeeInfoProc(out retList, out retList2, out retTotalCnt, out nextData, enterpriseCode, 0);
        }

        /// <summary>
        /// 従業員検索処理（従業員情報のみ取得）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retList2">読込結果コレクション(詳細)</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>従業員情報の取得のみを行い、余計なセット等は行わない</remarks>
        private int SearchOnlyEmployeeInfoProc(out ArrayList retList, out ArrayList retList2, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            EmployeeWork employeeWork = new EmployeeWork();
            EmployeeDtlWork employeeDtlWork = new EmployeeDtlWork();
            employeeWork.EnterpriseCode = enterpriseCode;
            employeeDtlWork.EnterpriseCode = enterpriseCode;

            int status;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList2 = new ArrayList();
            retList.Clear();
            retList2.Clear();
            ArrayList paraList = new ArrayList();
            ArrayList paraList2 = new ArrayList();

            // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// オフラインの場合はキャッシュから読む
            //if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    status = SearchStaticMemory(out retList);

            //}
            //else
            //{
            // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                object objectEmployeeWork = null;

                #region 従業員検索
                if (_isLocalDBRead)
                {
                    List<EmployeeWork> employeeWorkList = new List<EmployeeWork>();
                    status = this._employeeLcDB.Search(out employeeWorkList, employeeWork, 0, logicalMode);

                    ArrayList convList = new ArrayList();
                    convList.AddRange(employeeWorkList);
                    objectEmployeeWork = (object)convList;
                }
                else
                {
                    status = this._iEmployeeDB.Search(out objectEmployeeWork, employeeWork, 0, logicalMode);
                }

                if (status == 0)
                {
                    ArrayList al = (ArrayList)objectEmployeeWork;
                    for (int i = 0; i < al.Count; i++)
                    {
                        // サーチ結果取得
                        retList.Add(CopyToEmployeeFromEmployeeWork((EmployeeWork)al[i]));
                    }

                    _searchFlg = true;
                }
                #endregion

                #region 従業員詳細検索
                object objectEmployeeDtlWork = null;
                paraList.Clear();

                // ローカル
                if (_isLocalDBRead)
                {
                    List<EmployeeDtlWork> employeeDtlWorkList = new List<EmployeeDtlWork>();
                    status = this._employeeDtlLcDB.Search(out employeeDtlWorkList, employeeDtlWork, 0, logicalMode);

                    if (status == 0)
                    {
                        ArrayList al = new ArrayList();
                        al.AddRange(employeeDtlWorkList);
                        objectEmployeeDtlWork = (object)al;
                    }
                }
                // リモート
                else
                {
                    status = this._iEmployeeDtlDB.Search(out objectEmployeeDtlWork, employeeDtlWork, 0, logicalMode);
                }

                if (status == 0)
                {
                    ArrayList al = (ArrayList)objectEmployeeDtlWork;
                    for (int i = 0; i < al.Count; i++)
                    {
                        // サーチ結果取得
                        retList2.Add(CopyToEmployeeDtlFromEmployeeDtlWork((EmployeeDtlWork)al[i]));
                    }
                    _searchFlg = true;
                }
                #endregion
            //} // 2009.08.07
            //全件リードの場合は戻り値の件数をセット
            retTotalCnt = retList.Count;

            return status;
        }
        // 2009.02.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// クラスメンバーコピー処理（従業員ワーククラス⇒従業員クラス）
		/// </summary>
		/// <param name="employeeWork">従業員ワーククラス</param>
		/// <returns>従業員クラス</returns>
		/// <remarks>
		/// <br>Note       : 従業員ワーククラスから従業員クラスへメンバーのコピーを行います。</br>
		/// <br>		   : 自動生成に追加したプロパティ分もセットします。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private Employee CopyToEmployeeFromEmployeeWork(EmployeeWork employeeWork)
		{
			Employee employee = new Employee();
			//----- ueno rev ---------- start 2008.02.12
            //string wkString;        2008.11.17 Del 
			//----- ueno rev ---------- end 2008.02.12
			
			employee = (CopyToEmployee(employeeWork));

            //switch (employeeWork.FrontMechaCode)
            //{
            //    case 0:
            //    {
            //        employee.FrontMechaName = "受付";							
            //        break;
            //    }
            //    case 1:
            //    {
            //        employee.FrontMechaName = "メカ";							
            //        break;
            //    }
            //    case 2:
            //    {
            //        employee.FrontMechaName = "営業";
            //        break;
            //    }
            //    default:
            //    {
            //        employee.FrontMechaName = "";							
            //        break;
            //    }
            //}

			switch (employeeWork.InOutsideCompanyCode)
			{
				case 0:
				{
					employee.InOutsideCompanyName = "社内";
					break;
				}
				case 1:
				{
					employee.InOutsideCompanyName = "社外";
					break;
				}
				default:
				{
					employee.InOutsideCompanyName = "";
					break;
				}
			}

			if (employee.UserAdminFlag == 0)
			{
				employee.UserAdminName = "一般";
			}
			else
			{
				employee.UserAdminName = "ユーザー管理者";
			}

            // DEL 2008/11/04 不具合対応[7289] ---------->>>>>
            ////----- ueno rev ---------- start 2008.02.12
            //this._userGuideAcs.GetGuideName(out wkString, employee.EnterpriseCode, (int)UserGdGuideDivCodeAcsData.PostCode, employeeWork.PostCode);
            //employee.PostName = wkString;
            // DEL 2008/11/04 不具合対応[7289] ----------<<<<<
            // 2008.11.17 Del >>>
            //this._userGuideAcs.GetGuideName(out wkString, employee.EnterpriseCode, (int)UserGdGuideDivCodeAcsData.BusinessCode, employeeWork.BusinessCode);
            //employee.BusinessName = wkString;
            //employee.BelongSectionName = GetSectionName(employeeWork.EnterpriseCode, employeeWork.BelongSectionCode);
            // 2008.11.17 Del <<<
            ////----- ueno rev ---------- end 2008.02.12
            
			return employee;
		}

        // 2007.08.14 追加 >>>>>>>>>>
        /// <summary>
        /// クラスメンバーコピー処理（従業員詳細ワーククラス⇒従業員詳細クラス）
        /// </summary>
        /// <param name="employeeDtlWork">従業員詳細ワーククラス</param>
        /// <returns>従業員詳細クラス</returns>
        /// <remarks>
        /// <br>Note       : 従業員詳細ワーククラスから従業員詳細クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 980035 金沢  貞義</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private EmployeeDtl CopyToEmployeeDtlFromEmployeeDtlWork(EmployeeDtlWork employeeDtlWork)
        {
            EmployeeDtl employeeDtl = new EmployeeDtl();
            employeeDtl = (CopyToEmployeeDtl(employeeDtlWork));

            return employeeDtl;
        }
        // 2007.08.14 追加 <<<<<<<<<<

        /// <summary>
		/// クラスメンバーコピー処理（従業員クラス⇒従業員ワーククラス）
		/// </summary>
		/// <param name="employee">従業員ワーククラス</param>
		/// <returns>従業員クラス</returns>
		/// <remarks>
		/// <br>Note       : 従業員クラスから従業員ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private EmployeeWork CopyToEmployeeWorkFromEmployee(Employee employee)
		{
			EmployeeWork employeeWork = new EmployeeWork();

			employeeWork.CreateDateTime			= employee.CreateDateTime;
			employeeWork.UpdateDateTime			= employee.UpdateDateTime;
			employeeWork.EnterpriseCode			= employee.EnterpriseCode;
			employeeWork.FileHeaderGuid			= employee.FileHeaderGuid;
			employeeWork.UpdEmployeeCode		= employee.UpdEmployeeCode;
			employeeWork.UpdAssemblyId1			= employee.UpdAssemblyId1;
			employeeWork.UpdAssemblyId2			= employee.UpdAssemblyId2;
			employeeWork.LogicalDeleteCode		= employee.LogicalDeleteCode;

			employeeWork.EmployeeCode			= employee.EmployeeCode.Trim();
			employeeWork.Name					= employee.Name.TrimEnd();
			employeeWork.Kana					= employee.Kana.TrimEnd();
			employeeWork.ShortName				= employee.ShortName.TrimEnd();
			employeeWork.SexCode				= employee.SexCode;
			employeeWork.SexName				= employee.SexName;
			employeeWork.Birthday				= employee.Birthday;
			employeeWork.CompanyTelNo			= employee.CompanyTelNo.Trim();
			employeeWork.PortableTelNo			= employee.PortableTelNo.Trim();
			employeeWork.PostCode				= employee.PostCode;
			employeeWork.BusinessCode			= employee.BusinessCode;
            //employeeWork.FrontMechaCode			= employee.FrontMechaCode;
			employeeWork.InOutsideCompanyCode	= employee.InOutsideCompanyCode;
			employeeWork.BelongSectionCode		= employee.BelongSectionCode.Trim();
            //employeeWork.LvrRtCstGeneral		= employee.LvrRtCstGeneral;
            //employeeWork.LvrRtCstCarInspect		= employee.LvrRtCstCarInspect;
            //employeeWork.LvrRtCstBodyRepair		= employee.LvrRtCstBodyRepair;
            //employeeWork.LvrRtCstBodyPaint		= employee.LvrRtCstBodyPaint;
			employeeWork.LoginId				= employee.LoginId.Trim();
			employeeWork.LoginPassword			= employee.LoginPassword.Trim();
			employeeWork.UserAdminFlag			= employee.UserAdminFlag;
			employeeWork.EnterCompanyDate		= employee.EnterCompanyDate;
			employeeWork.RetirementDate			= employee.RetirementDate;

            employeeWork.AuthorityLevel1        = employee.AuthorityLevel1;
            employeeWork.AuthorityLevel2        = employee.AuthorityLevel2;

			// -- Add St 2012.05.29 30182 R.Tachiya --
			employeeWork.SalSlipInpBootCnt		= employee.SalSlipInpBootCnt;
			employeeWork.CustLedgerBootCnt		= employee.CustLedgerBootCnt;
			// -- Add Ed 2012.05.29 30182 R.Tachiya --

			return employeeWork;
		}

        // 2007.08.14 追加 >>>>>>>>>>
        /// <summary>
        /// クラスメンバーコピー処理（従業員詳細クラス⇒従業員詳細ワーククラス）
        /// </summary>
        /// <param name="employeeDtl">従業員詳細ワーククラス</param>
        /// <returns>従業員詳細クラス</returns>
        /// <remarks>
        /// <br>Note       : 従業員詳細クラスから従業員詳細ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 980035 金沢  貞義</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private EmployeeDtlWork CopyToEmployeeDtlWorkFromEmployeeDtl(EmployeeDtl employeeDtl)
        {
            EmployeeDtlWork employeeDtlWork = new EmployeeDtlWork();

            employeeDtlWork.CreateDateTime = employeeDtl.CreateDateTime;
            employeeDtlWork.UpdateDateTime = employeeDtl.UpdateDateTime;
            employeeDtlWork.EnterpriseCode = employeeDtl.EnterpriseCode;
            employeeDtlWork.FileHeaderGuid = employeeDtl.FileHeaderGuid;
            employeeDtlWork.UpdEmployeeCode = employeeDtl.UpdEmployeeCode;
            employeeDtlWork.UpdAssemblyId1 = employeeDtl.UpdAssemblyId1;
            employeeDtlWork.UpdAssemblyId2 = employeeDtl.UpdAssemblyId2;
            employeeDtlWork.LogicalDeleteCode = employeeDtl.LogicalDeleteCode;
            
            employeeDtlWork.EmployeeCode = employeeDtl.EmployeeCode.Trim();
            employeeDtlWork.BelongSubSectionCode = employeeDtl.BelongSubSectionCode;
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            employeeDtlWork.BelongSubSectionName = employeeDtl.BelongSubSectionName;
            employeeDtlWork.BelongMinSectionCode = employeeDtl.BelongMinSectionCode;
            employeeDtlWork.BelongMinSectionName = employeeDtl.BelongMinSectionName;
            employeeDtlWork.BelongSalesAreaCode = employeeDtl.BelongSalesAreaCode;
            employeeDtlWork.BelongSalesAreaName = employeeDtl.BelongSalesAreaName;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            employeeDtlWork.EmployAnalysCode1 = employeeDtl.EmployAnalysCode1;
            employeeDtlWork.EmployAnalysCode2 = employeeDtl.EmployAnalysCode2;
            employeeDtlWork.EmployAnalysCode3 = employeeDtl.EmployAnalysCode3;
            employeeDtlWork.EmployAnalysCode4 = employeeDtl.EmployAnalysCode4;
            employeeDtlWork.EmployAnalysCode5 = employeeDtl.EmployAnalysCode5;
            employeeDtlWork.EmployAnalysCode6 = employeeDtl.EmployAnalysCode6;
            // 2008.11.10 add start --------------------------------------------->>
            employeeDtlWork.UOESnmDiv = employeeDtl.UOESnmDiv;
            // 2008.11.10 add end -----------------------------------------------<<
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            employeeDtlWork.OldBelongSectionCd = employeeDtl.OldBelongSectionCd;
            employeeDtlWork.OldBelongSectionNm = employeeDtl.OldBelongSectionNm;
            employeeDtlWork.OldBelongSubSecCd = employeeDtl.OldBelongSubSecCd;
            employeeDtlWork.OldBelongSubSecNm = employeeDtl.OldBelongSubSecNm;
            employeeDtlWork.OldBelongMinSecCd = employeeDtl.OldBelongMinSecCd;
            employeeDtlWork.OldBelongMinSecNm = employeeDtl.OldBelongMinSecNm;
            employeeDtlWork.SectionChgDate = employeeDtl.SectionChgDate;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            employeeDtlWork.MailAddrKindCode1 = employeeDtl.MailAddrKindCode1;
            employeeDtlWork.MailAddrKindName1 = employeeDtl.MailAddrKindName1;
            employeeDtlWork.MailAddress1 = employeeDtl.MailAddress1;
            employeeDtlWork.MailSendCode1 = employeeDtl.MailSendCode1;
            employeeDtlWork.MailAddrKindCode2 = employeeDtl.MailAddrKindCode2;
            employeeDtlWork.MailAddrKindName2 = employeeDtl.MailAddrKindName2;
            employeeDtlWork.MailAddress2 = employeeDtl.MailAddress2;
            employeeDtlWork.MailSendCode2 = employeeDtl.MailSendCode2;
            // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return employeeDtlWork;
        }
        // 2007.08.14 追加 <<<<<<<<<<

        /// <summary>
		/// メモリ生成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 従業員設定アクセスクラスが保持するメモリを生成します。</br>
		/// <br>Programer  : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		private void MemoryCreate()
		{
			// オンラインの場合
			if (LoginInfoAcquisition.OnlineFlag)
			{
				//----- ueno del ---------- start 2008.02.12				
				//---拠点情報取得部品インスタンス化---//
				//this._secInfoAcs = new SecInfoAcs(1);
				//----- ueno del ---------- start 2008.02.12				
                
                // 2008.02.08 削除 >>>>>>>>>>
                //// ユーザーガイドボディ（HashTable）
                //if (this._userGdBdTable == null)
                //{
                //    this._userGdBdTable = new Hashtable();
                //}
                //// ユーザーガイドボディ（ArrayList）
                //if (this._userGdBdList == null)
                //{
                //    this._userGdBdList = new ArrayList();
                //}
                // 2008.02.08 削除 <<<<<<<<<<
            }

			// 従業員マスタクラスStatic
			if (_employeeTable_Stc == null)
			{
				_employeeTable_Stc = new Hashtable();
			}

            ////----- ueno rev ---------- start 2008.02.12
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }
            ////----- ueno rev ---------- end 2008.02.12

            // 2010/02/18 Add >>>
            if (_optFeliCaAcs)
            {
                if (_felicaMngWkList_Stc == null)
                {
                    _felicaMngWkList_Stc = new List<FeliCaMngWork>();
                }
            }
            // 2010/02/18 Add <<<
        }

		/// <summary>
		/// 従業員クラスワーカークラス（ArrayList） ⇒ UIクラス変換処理
		/// </summary>
		/// <param name="employeeWorkList">従業員ワーカークラスのArrayList</param>
		/// <remarks>
		/// <br>Note       : 従業員ワーカークラスをUIの部位部品クラスに変換して、
		///					 Search用Staticメモリに保持します。</br>
		/// <br>Programer  : 22033  三崎  貴史</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		private void CopyToStaticFromWorker(ArrayList employeeWorkList)
		{
			string hashKey;
			foreach (EmployeeWork wkEmployeeWork in employeeWorkList)
			{
				Employee wkEmployee = new Employee();

				// HashKey:従業員コード
				hashKey = wkEmployeeWork.EmployeeCode.TrimEnd();

				wkEmployee.CreateDateTime		= wkEmployeeWork.CreateDateTime;
				wkEmployee.UpdateDateTime		= wkEmployeeWork.UpdateDateTime;
				wkEmployee.EnterpriseCode		= wkEmployeeWork.EnterpriseCode;
				wkEmployee.FileHeaderGuid		= wkEmployeeWork.FileHeaderGuid;
				wkEmployee.UpdEmployeeCode		= wkEmployeeWork.UpdEmployeeCode;
				wkEmployee.UpdAssemblyId1		= wkEmployeeWork.UpdAssemblyId1;
				wkEmployee.UpdAssemblyId2		= wkEmployeeWork.UpdAssemblyId2;
				wkEmployee.LogicalDeleteCode	= wkEmployeeWork.LogicalDeleteCode;

				wkEmployee.EmployeeCode			= wkEmployeeWork.EmployeeCode;		
				wkEmployee.Name					= wkEmployeeWork.Name;				
				wkEmployee.Kana					= wkEmployeeWork.Kana;				
				wkEmployee.ShortName			= wkEmployeeWork.ShortName;			
				wkEmployee.SexCode				= wkEmployeeWork.SexCode;				
				wkEmployee.SexName				= wkEmployeeWork.SexName;				
				wkEmployee.Birthday				= wkEmployeeWork.Birthday;			
				wkEmployee.CompanyTelNo			= wkEmployeeWork.CompanyTelNo;		
				wkEmployee.PortableTelNo		= wkEmployeeWork.PortableTelNo;		
				wkEmployee.PostCode				= wkEmployeeWork.PostCode;			
				wkEmployee.BusinessCode			= wkEmployeeWork.BusinessCode;		
                //wkEmployee.FrontMechaCode		= wkEmployeeWork.FrontMechaCode;		
				wkEmployee.InOutsideCompanyCode	= wkEmployeeWork.InOutsideCompanyCode;
				wkEmployee.BelongSectionCode	= wkEmployeeWork.BelongSectionCode;	
                //wkEmployee.LvrRtCstGeneral		= wkEmployeeWork.LvrRtCstGeneral;		
                //wkEmployee.LvrRtCstCarInspect		= wkEmployeeWork.LvrRtCstCarInspect;		
                //wkEmployee.LvrRtCstBodyRepair		= wkEmployeeWork.LvrRtCstBodyRepair;		
                //wkEmployee.LvrRtCstBodyPaint		= wkEmployeeWork.LvrRtCstBodyPaint;		
				wkEmployee.LoginId				= wkEmployeeWork.LoginId;				
				wkEmployee.LoginPassword		= wkEmployeeWork.LoginPassword;		
				wkEmployee.UserAdminFlag		= wkEmployeeWork.UserAdminFlag;		
				wkEmployee.EnterCompanyDate		= wkEmployeeWork.EnterCompanyDate;	
				wkEmployee.RetirementDate		= wkEmployeeWork.RetirementDate;		
				
                wkEmployee.AuthorityLevel1      = wkEmployeeWork.AuthorityLevel1;
                wkEmployee.AuthorityLevel2      = wkEmployeeWork.AuthorityLevel2;

				// -- Add St 2012.05.29 30182 R.Tachiya --
				wkEmployee.SalSlipInpBootCnt	= wkEmployeeWork.SalSlipInpBootCnt;
				wkEmployee.CustLedgerBootCnt	= wkEmployeeWork.CustLedgerBootCnt;
				// -- Add Ed 2012.05.29 30182 R.Tachiya --

                //switch (wkEmployeeWork.FrontMechaCode)
                //{
                //    case 0:
                //    {
                //        wkEmployee.FrontMechaName = "受付";							
                //        break;
                //    }
                //    case 1:
                //    {
                //        wkEmployee.FrontMechaName = "メカ";							
                //        break;
                //    }
                //    case 2:
                //    {
                //        wkEmployee.FrontMechaName = "営業";
                //        break;
                //    }
                //    default:
                //    {
                //        wkEmployee.FrontMechaName = "";							
                //        break;
                //    }
                //}

				switch (wkEmployeeWork.InOutsideCompanyCode)
				{
					case 0:
					{
						wkEmployee.InOutsideCompanyName = "社内";							
						break;
					}
					case 1:
					{
						wkEmployee.InOutsideCompanyName = "社外";							
						break;
					}
					default:
					{
						wkEmployee.InOutsideCompanyName = "";							
						break;
					}
				}

				_employeeTable_Stc[hashKey] = wkEmployee;
			}
		}

        // 2007.08.14 追加 >>>>>>>>>>
        /// <summary>
        /// 従業員詳細クラスワーカークラス（ArrayList） ⇒ UIクラス変換処理
        /// </summary>
        /// <param name="employeeDtlWorkList">従業員詳細ワーカークラスのArrayList</param>
        /// <remarks>
        /// <br>Note       : 従業員詳細ワーカークラスをUIの部位部品クラスに変換して、
        ///					 Search用Staticメモリに保持します。</br>
        /// <br>Programer  : 980035  金沢  貞義</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private void CopyToStaticFromWorker2(ArrayList employeeDtlWorkList)
        {
            string hashKey;
            foreach (EmployeeDtlWork wkEmployeeDtlWork in employeeDtlWorkList)
            {
                EmployeeDtl wkEmployeeDtl = new EmployeeDtl();

                // HashKey:従業員コード
                hashKey = wkEmployeeDtlWork.EmployeeCode.TrimEnd();

                wkEmployeeDtl.CreateDateTime = wkEmployeeDtlWork.CreateDateTime;
                wkEmployeeDtl.UpdateDateTime = wkEmployeeDtlWork.UpdateDateTime;
                wkEmployeeDtl.EnterpriseCode = wkEmployeeDtlWork.EnterpriseCode;
                wkEmployeeDtl.FileHeaderGuid = wkEmployeeDtlWork.FileHeaderGuid;
                wkEmployeeDtl.UpdEmployeeCode = wkEmployeeDtlWork.UpdEmployeeCode;
                wkEmployeeDtl.UpdAssemblyId1 = wkEmployeeDtlWork.UpdAssemblyId1;
                wkEmployeeDtl.UpdAssemblyId2 = wkEmployeeDtlWork.UpdAssemblyId2;
                wkEmployeeDtl.LogicalDeleteCode = wkEmployeeDtlWork.LogicalDeleteCode;

                wkEmployeeDtl.EmployeeCode = wkEmployeeDtlWork.EmployeeCode;
                wkEmployeeDtl.BelongSubSectionCode = wkEmployeeDtlWork.BelongSubSectionCode;
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                wkEmployeeDtl.BelongSubSectionName = wkEmployeeDtlWork.BelongSubSectionName;
                wkEmployeeDtl.BelongMinSectionCode = wkEmployeeDtlWork.BelongMinSectionCode;
                wkEmployeeDtl.BelongMinSectionName = wkEmployeeDtlWork.BelongMinSectionName;
                wkEmployeeDtl.BelongSalesAreaCode  = wkEmployeeDtlWork.BelongSalesAreaCode;
                wkEmployeeDtl.BelongSalesAreaName  = wkEmployeeDtlWork.BelongSalesAreaName;
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                wkEmployeeDtl.EmployAnalysCode1 = wkEmployeeDtlWork.EmployAnalysCode1;
                wkEmployeeDtl.EmployAnalysCode2 = wkEmployeeDtlWork.EmployAnalysCode2;
                wkEmployeeDtl.EmployAnalysCode3 = wkEmployeeDtlWork.EmployAnalysCode3;
                wkEmployeeDtl.EmployAnalysCode4 = wkEmployeeDtlWork.EmployAnalysCode4;
                wkEmployeeDtl.EmployAnalysCode5 = wkEmployeeDtlWork.EmployAnalysCode5;
                wkEmployeeDtl.EmployAnalysCode6 = wkEmployeeDtlWork.EmployAnalysCode6;
                // 2008.11.10 add start --------------------------------------------->>
                wkEmployeeDtl.UOESnmDiv = wkEmployeeDtlWork.UOESnmDiv;
                // 2008.11.10 add end -----------------------------------------------<<

                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                wkEmployeeDtl.OldBelongSectionCd = wkEmployeeDtlWork.OldBelongSectionCd;
                wkEmployeeDtl.OldBelongSectionNm = wkEmployeeDtlWork.OldBelongSectionNm;
                wkEmployeeDtl.OldBelongSubSecCd = wkEmployeeDtlWork.OldBelongSubSecCd;
                wkEmployeeDtl.OldBelongSubSecNm = wkEmployeeDtlWork.OldBelongSubSecNm;
                wkEmployeeDtl.OldBelongMinSecCd = wkEmployeeDtlWork.OldBelongMinSecCd;
                wkEmployeeDtl.OldBelongMinSecNm = wkEmployeeDtlWork.OldBelongMinSecNm;
                wkEmployeeDtl.SectionChgDate = wkEmployeeDtlWork.SectionChgDate;
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

                // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                wkEmployeeDtl.MailAddrKindCode1 = wkEmployeeDtlWork.MailAddrKindCode1;
                wkEmployeeDtl.MailAddrKindName1 = wkEmployeeDtlWork.MailAddrKindName1;
                wkEmployeeDtl.MailAddress1 = wkEmployeeDtlWork.MailAddress1;
                wkEmployeeDtl.MailSendCode1 = wkEmployeeDtlWork.MailSendCode1;
                wkEmployeeDtl.MailAddrKindCode2 = wkEmployeeDtlWork.MailAddrKindCode2;
                wkEmployeeDtl.MailAddrKindName2 = wkEmployeeDtlWork.MailAddrKindName2;
                wkEmployeeDtl.MailAddress2 = wkEmployeeDtlWork.MailAddress2;
                wkEmployeeDtl.MailSendCode2 = wkEmployeeDtlWork.MailSendCode2;
                // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                //_employeeDtlTable_Stc[hashKey] = wkEmployeeDtl;
            }
        }
        // 2007.08.14 追加 <<<<<<<<<<

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

			// --- Search用 --- //
			// KeyList設定
			string[] employeeKeys = new string[1];
			employeeKeys[0] = LoginInfoAcquisition.EnterpriseCode;
			// ローカルファイル読込み処理
			object wkObj = offlineDataSerializer.DeSerialize("EmployeeAcs", employeeKeys);
			// ArrayListにセット
			ArrayList wkList = wkObj as ArrayList;
			
			if ((wkList != null) &&
				(wkList.Count != 0))
			{
				// 従業員クラスワーカークラス（ArrayList） ⇒ UIクラス（Static）変換処理
				CopyToStaticFromWorker(wkList);
			}

            // 2010/02/18 Add >>>
            if (!_optFeliCaAcs) return;
            // ローカルファイル読み込み
            employeeKeys[0] += "_felica";
            object wkObj2 = offlineDataSerializer.DeSerialize("EmployeeAcs", employeeKeys);
            if (wkObj2 == null) return;

            ArrayList wkList2 = wkObj2 as ArrayList;
            _felicaMngWkList_Stc = new List<FeliCaMngWork>();
            foreach (FeliCaMngWork wk in wkList2)
                _felicaMngWkList_Stc.Add(wk);
            // 2010/02/18 Add <<<
		}

		//----- ueno add ---------- start 2008.02.12
		/// <summary>
		/// ローカルＤＢ対応拠点情報クラス作成処理
		/// </summary>
		/// <returns>Boolean</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報クラス作成を未作成時に作成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.02.12</br>
		/// </remarks>
		private Boolean ConstructSecInfoAcs()
		{
			if (this._secInfoAcs == null)
			{
				this._secInfoAcs = new SecInfoAcs(_isLocalDBRead ? 0 : 1);
				if (this._secInfoAcs != null)
				{
					return true;
				}
			}
			return false;
		}
		//----- ueno add ---------- end 2008.02.12
		
		#endregion
    }
}
