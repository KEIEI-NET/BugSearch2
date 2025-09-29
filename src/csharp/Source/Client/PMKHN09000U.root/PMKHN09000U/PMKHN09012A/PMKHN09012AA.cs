//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先マスタ
// プログラム概要   ：得意先の登録・変更・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22018 鈴木 正臣
// 修正日    2008/04/23     修正内容：Partsman用に修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30462 行澤仁美
// 修正日    2008/12/02     修正内容：バグ修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2009/02/03     修正内容：障害ID:9391対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：20056 對馬 大輔
// 修正日    2009.02.17     修正内容：Read時の名称設定区分追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22018 鈴木 正臣
// 修正日    2009.04.03     修正内容：売上金額端数処理取得でキャッシュに該当なければR呼び出しするよう修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/07     修正内容：Mantis【12493】領収書出力区分の追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/03     修正内容：SCMオプション項目追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/26     修正内容：Mantis【13295】得意先名称と略称の必須チェックから除外
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：20056 對馬 大輔
// 修正日    2009/07/30     修正内容：LoginInfoAcquisition.OnlineFlagを参照して処理を行わない。
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22008 長内
// 修正日    2010/04/06     修正内容：品番検索速度アップ対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 区小津
// 修正日    2010/06/26     修正内容：SCM：簡単問合せアカウントグループIDを追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当: 李占川
// 作 成 日  2010/09/26     修正内容: Redmine障害報告 #14483の修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：21024　佐々木 健
// 修正日    2010/10/28     修正内容：MANTIS[0016523]対応
//                                   ①管理拠点名称はリモートから取得したデータをそのまま使用する
//                                   ②地区、職種、業種の論理削除チェックの削除（リモート側で対応）
//----------------------------------------------------------------------------//
// 管理番号  10970681-00    作成担当：陳健
// 修正日    K2014/02/06    修正内容：前橋京和商会個別 得意先マスタ改良対応
// ------------------------------------------------------------------------//
// 管理番号  11770021-00    作成担当：梶谷貴士
// 修正日    2021/05/10     修正内容：得意先情報ガイド表示PKG対応
// ------------------------------------------------------------------------//
using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Resources;  // ADD 陳健 K2014/02/06

namespace Broadleaf.Application.Controller
{
	// ========================================================================================= //
	// デリゲート
	// ========================================================================================= //
	# region Delegate
	/// <summary>得意先情報変更デリゲート</summary>
	public delegate void CustomerInfoChangeEventHandler(object sender, string frameKey, ref CustomerInfo customerInfo);

	/// <summary>得意先情報削除デリゲート</summary>
	public delegate void CustomerInfoDeleteEventHandler(object sender, string frameKey, ref CustomerInfo customerInfo);
	# endregion

	/// <summary>
	/// 得意先テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 22018 鈴木正臣</br>
	/// <br>Date       : 2008.04.23</br>
    /// <br>UpdateNote  : 2008/12/02 30462 行澤仁美　バグ修正</br>
    /// <br>UpdateNote  : 2009/02/03 30414 忍幸史　障害ID:9391対応</br>
    /// <br>UpdateNote  : 2009.02.17 20056 對馬 大輔　Read時の名称設定区分追加</br>
    /// <br>UpdateNote  : 2009.04.03 22018 鈴木 正臣　売上金額端数処理取得でキャッシュに該当なければR呼び出しするよう修正</br>
    /// <br>UpdateNote  : 2021/05/10 32653 梶谷 貴士　得意先情報ガイド表示PKG対応にて得意先情報ガイド表示区分を追加</br>
    /// </remarks>
	public class CustomerInfoAcs
	{
		// ===================================================================================== //
		// スタティックな変数群
		// ===================================================================================== //
		#region Static Informain
		private static int  _uniqidCounter;										// アクセスコントロール識別ID発行用
		private static Hashtable _infoChange;									// 得意先情報変更デリゲート用
		private static Hashtable _infoDelete;									// 得意先情報削除情報デリゲート用
		private static Dictionary<string, CustomerInfo> _customerDictionary;	// 得意先情報バッファ(MainMemory)格納用Dictionary
		private static Dictionary<string, CustomerInfo> __customerDictionary;	// 得意先情報バッファ(UndoMemory)格納用Dictionary
		# endregion

		// ===================================================================================== //
		// 内部で使用する定数群
		// ===================================================================================== //
		# region Const
        private const string OFFLINE_DATA_IDENTIFIER = "CUSTOMER";
		# endregion

        // ===================================================================================== //
        // パブリック Enum
        // ===================================================================================== //
        # region [public Enum]
        /// <summary>
        /// 金額端数処理区分
        /// </summary>
        public enum FracProcMoneyDiv
        {
            /// <summary>単価</summary>
            UnPrcFrcProcCd = 0,
            /// <summary>金額</summary>
            MoneyFrcProcCd = 1,
            /// <summary>消費税</summary>
            CnsTaxFrcProcCd = 2,
        }

        // ADD 梶谷貴士 2021/05/10 -------------------------------------------------->>>>>
        /// <summary>
        /// 得意先情報ガイド表示区分
        /// </summary>
        public enum DisplayDivCode
        {
            /// <summary>表示</summary>
            ShowDisplayDivCode = 0,
            /// <summary>非表示</summary>
            HideDisplayDivCode = 1,
        }
        // ADD 梶谷貴士 2021/05/10 --------------------------------------------------<<<<<
        # endregion

        // ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private int _uniqid;													// アクセスコントロール識別ID
		private string _key = string.Empty;												// キーバッファ
		private ICustomerInfoDB _iCustomerInfoDB = null;
		private string _enterpriseCode = string.Empty;									// 企業コード
        private CustomerLcDB _customerInfoLcDB = null;
        private static bool _isLocalDBRead = false;
        // DEL 梶谷貴士 2021/05/10 ------------------------------------->>>>>
        // ADD 陳健 K2014/02/06 -------------------------->>>>>
        //private int _opt_Maehashi;
        // ADD 陳健 K2014/02/06 --------------------------<<<<<
        // DEL 梶谷貴士 2021/05/10 -------------------------------------<<<<<

        // 2010/10/28 Del >>>
        //// --- ADD 2010/08/10 ------------------------------------>>>>>
        //// ユーザマスタアクセスクラス
        //private UserGuideAcs _userGuideAcs;
        //// --- ADD 2010/08/10 ------------------------------------<<<<<
        //// 2010/10/28 Del <<<
        # endregion

        // ===================================================================================== //
        // パブリック　プロパティ
        // ===================================================================================== //
        # region [public Propaties]
        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        // ADD 陳健 K2014/02/06 -------------------------------------->>>>>
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効</summary>
            OFF = 0,
            /// <summary>有効</summary>
            ON = 1,
        }
        // ADD 陳健 K2014/02/06 --------------------------------------<<<<<
        # endregion

        // ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// 得意先情報アクセスクラスのコンストラクタ
		/// </summary>
		public CustomerInfoAcs()
		{
            // ユニークなIDをthisに設定
			this._uniqid = ++_uniqidCounter;

			// 変数初期化
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			if (_customerDictionary == null)
			{
				_customerDictionary = new Dictionary<string, CustomerInfo>();
			}

			if (__customerDictionary == null)
			{
				__customerDictionary = new Dictionary<string, CustomerInfo>();
			}

			// リモートオブジェクト取得
			this._iCustomerInfoDB = (ICustomerInfoDB)MediationCustomerInfoDB.GetCustomerInfoDB();
            this._customerInfoLcDB = new CustomerLcDB();

            // 情報変更デリゲート用
			if (_infoChange == null)
			{
				_infoChange = new Hashtable();
			}

			// 得意先情報削除デリゲート用
			if (_infoDelete == null)
			{
				_infoDelete = new Hashtable();
			}

            // 2010/10/28 Del >>>
            //// --- ADD 2010/08/10 ------------------------------------>>>>>
            //// ユーザマスタアクセスクラス
            //if (_userGuideAcs == null)
            //{
            //    _userGuideAcs = new UserGuideAcs();
            //}
            //// --- ADD 2010/08/10 ------------------------------------<<<<<
            // 2010/10/28 Del <<<
            // ADD 陳健 K2014/02/06 ------------------------------------->>>>>
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            #region ●
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MaehashiKyowaGuideCtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                // DEL 梶谷貴士 2021/05/10 ------------------------------------->>>>>
                //this._opt_Maehashi = (int)Option.ON;
                // DEL 梶谷貴士 2021/05/10 -------------------------------------<<<<<
            }
            else
            {
                // DEL 梶谷貴士 2021/05/10 ------------------------------------->>>>>
                //this._opt_Maehashi = (int)Option.OFF;
                // DEL 梶谷貴士 2021/05/10 -------------------------------------<<<<<
            }
            #endregion
            // ADD 陳健 K2014/02/06 -------------------------------------<<<<<
        }

        /// <summary>
		/// 得意先マスタアクセスクラス コンストラクタ
		/// </summary>
		public CustomerInfoAcs(string key): this()
		{
			this._key = key;
		}
		# endregion

		// ===================================================================================== //
		// デリゲート関連メソッド
		// ===================================================================================== //
		#region 得意先情報変更デリゲート関連メソッド定義
		/// <summary>
		/// 得意先情報変更通知登録処理
		/// </summary>
		/// <param name="handler">登録するデリゲート</param>
		/// <remarks>
		/// <br>Note       : 得意先情報を変更した際に発生するイベントを登録します</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public void AddInfoCustomerChangeEvent(CustomerInfoChangeEventHandler handler)
		{
            // ハッシュテーブルより、該当デリゲートを取得
			CustomerInfoChangeEventHandler pstHandler = (CustomerInfoChangeEventHandler)_infoChange[this._uniqid];
			
			// 存在しない？
			if (pstHandler == null)
			{
				// ハッシュテーブルに存在するか？
				pstHandler = handler;
				if (_infoChange.ContainsKey(this._uniqid) == true)
				{
					// 存在すれば更新
					_infoChange[this._uniqid] = pstHandler;
				}
				else
				{
					// 存在しなければ追加
					_infoChange.Add(this._uniqid, pstHandler);
				}
			}
			else
			{
				// 存在すれば追加
				pstHandler  += handler;
				_infoChange[this._uniqid] = pstHandler;
			}
		}

		/// <summary>
		/// 得意先情報変更通知削除処理
		/// </summary>
		/// <param name="handler">削除するデリゲート</param>
		/// <remarks>
		/// <br>Note       : 得意先情報を取得した際に発生するイベントを削除します</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public void RemoveInfoCustomerChange(CustomerInfoChangeEventHandler handler)
		{
            CustomerInfoChangeEventHandler pstHandler = (CustomerInfoChangeEventHandler)_infoChange[this._uniqid];
			if (pstHandler != null)
			{
				pstHandler  -= handler;
				if (pstHandler == null)
				{
					_infoChange.Remove(this._uniqid);
				}
				else
				{
					_infoChange[this._uniqid] = pstHandler;
				}
			}
		}

		/// <summary>
		/// 得意先情報変更指示
		/// </summary>
		/// <param name="sender">変更指示飛ばし元のクラス</param>
		/// <param name="forceEvent">true:自分自身にもイベントを発生させる,false:自分自身にはイベントを発生させない</param>
		/// <param name="customerInfo">得意先情報</param>
		/// <returns>true=成功,false=失敗</returns>
		/// <remarks>
		/// <br>Note       : 得意先情報が変更された旨を通知します</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private bool InstructionInfoCustomerChange(object sender, bool forceEvent, ref CustomerInfo customerInfo)
		{
			// 情報変更通知処理
			foreach(int key in _infoChange.Keys)
			{
				// 同一のキーの場合は、処理しない! (但し、強制イベントの場合は、コール元にもイベントを発生させる）
				if ((forceEvent) || (key != this._uniqid))
				{
					CustomerInfo ci = customerInfo.Clone();

					CustomerInfoChangeEventHandler dlghandler = (CustomerInfoChangeEventHandler)_infoChange[key];
					dlghandler(sender, this._key, ref customerInfo);
				}
			}
			return true;
		}

		/// <summary>
		/// 得意先情報削除指示
		/// </summary>
		/// <param name="sender">指示飛ばし元のクラス</param>
		/// <param name="forceEvent">true:自分自身にもイベントを発生させる,false:自分自身にはイベントを発生させない</param>
		/// <param name="customerInfo">得意先情報</param>
		/// <returns>true=成功,false=失敗</returns>
        /// <remarks>
        /// <br>Note       : 得意先情報が削除された旨を通知します</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
        private bool InstructionCustomerInfoDelete ( object sender, bool forceEvent, ref CustomerInfo customerInfo )
		{
			// 削除通知処理
			foreach (int key in _infoDelete.Keys)
			{
				// 同一のキーの場合は、処理しない! (但し、強制イベントの場合は、コール元にもイベントを発生させる）
				if ((forceEvent) || (key != _uniqid))
				{
					CustomerInfoDeleteEventHandler dlghandler = (CustomerInfoDeleteEventHandler)_infoDelete[key];
					dlghandler(sender, this._key, ref customerInfo);
				}
			}
			return true;
		}
		# endregion

		#region 得意先情報削除 デリゲート関連メソッド定義
		/// <summary>
		/// 得意先情報削除通知登録処理
		/// </summary>
		/// <param name="handler">登録するデリゲート</param>
		/// <remarks>
		/// <br>Note       : 得意先情報を削除する際に発生するイベントを登録します</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public void AddInfoDeleteCustomerEvent(CustomerInfoDeleteEventHandler handler)
		{
            // ハッシュテーブルより、該当デリゲートを取得
			CustomerInfoDeleteEventHandler pstHandler = (CustomerInfoDeleteEventHandler)_infoDelete[this._uniqid];
			// 存在しない？
			if (pstHandler == null)
			{
				// ハッシュテーブルに存在するか？
				pstHandler = handler;
				if (_infoDelete.ContainsKey(this._uniqid) == true)
				{
					// 存在すれば更新
					_infoDelete[this._uniqid] = pstHandler;
				}
				else
				{
					// 存在しなければ追加
					_infoDelete.Add(this._uniqid, pstHandler);
				}
			}
			else
			{
				// 存在すれば追加
				pstHandler  += handler;
				_infoDelete[this._uniqid] = pstHandler;
			}
		}

		/// <summary>
		/// 得意先情報削除通知削除処理
		/// </summary>
		/// <param name="handler">削除するデリゲート</param>
		/// <remarks>
		/// <br>Note       : 得意先情報を登録する際に発生するイベントを削除します</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public void RemoveInfoDeleteCustomerEvent(CustomerInfoDeleteEventHandler handler)
		{
            CustomerInfoDeleteEventHandler pstHandler = (CustomerInfoDeleteEventHandler)_infoDelete[this._uniqid];
			if (pstHandler != null)
			{
				pstHandler  -= handler;
				if (pstHandler == null)
				{
					_infoDelete.Remove(this._uniqid);
				}
				else
				{
					_infoDelete[this._uniqid] = pstHandler;
				}
			}
		}
	
		/// <summary>
		/// 得意先情報削除指示
		/// </summary>
		/// <param name="sender">指示飛ばし元のクラス</param>
		/// <param name="forceEvent">true:自分自身にもイベントを発生させる,false:自分自身にはイベントを発生させない</param>
		/// <param name="customerInfo">得意先情報</param>
		/// <returns>true=成功,false=失敗</returns>
		/// <remarks>
		/// <br>Note       : 得意先情報をDBに削除する旨を通知します</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private bool InstructionInfoDeleteCustomerInfo(object sender, bool forceEvent, ref CustomerInfo customerInfo)
		{
			// 削除通知処理
			foreach (int key in _infoDelete.Keys)
			{
				// 同一のキーの場合は、処理しない! (但し、強制イベントの場合は、コール元にもイベントを発生させる）
				if ((forceEvent) || (key != _uniqid))
				{
					CustomerInfoDeleteEventHandler dlghandler = (CustomerInfoDeleteEventHandler)_infoDelete[key];
					dlghandler(sender, this._key, ref customerInfo);
				}
			}
			return true;
		}
		#endregion

		// ===================================================================================== //
		// Static領域操作
		// ===================================================================================== //
		# region StaticMemory Control
		/// <summary>
		/// Static情報の変更処理
		/// </summary>
		/// <param name="sender">変更する元のクラス（誰が変更するか）</param>
		/// <param name="customerInfo">変更するデータ（戻り値として変更後のデータ）</param>
		/// <returns>STATUS[0:更新成功,1:更新せず終了]</returns>
		/// <remarks>
		/// <br>Note		: Staticなエリアに情報を設定します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int WriteStaticMemoryData(object sender, CustomerInfo customerInfo)
		{
            if ((_customerDictionary == null) || (customerInfo == null))
			{
				return 1;
			}

			// 得意先情報バッファ(MainMemory)格納用ハッシュテーブル追加処理
			this.AddMainMemoryDictionary(customerInfo);

			// 得意先情報変更通知を発令する
			this.InstructionInfoCustomerChange(sender, false, ref customerInfo);

			return 0;
		}

		/// <summary>
		/// Static情報の論理削除処理
		/// </summary>
		/// <param name="sender">変更する元のクラス（誰が変更するか）</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>STATUS[0:更新成功,0以外:更新せず終了]</returns>
		public int DeleteStaticMemoryData(object sender, string enterpriseCode, int customerCode)
		{
            CustomerInfo customerInfo;
			int status = this.ReadStaticMemoryData(out customerInfo, enterpriseCode, customerCode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				if ((_customerDictionary == null) || (customerInfo == null))
				{
					return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}

				// 得意先情報バッファ(MainMemory)格納用ハッシュテーブル追加処理
				this.RemoveMainMemoryTable(customerInfo);

				// 得意先情報バッファ(UndoMemory)格納用ハッシュテーブル追加処理
				this.RemoveUndoMemoryTable(customerInfo);

				// 得意先情報削除通知を発令する
				this.InstructionCustomerInfoDelete(this, true, ref customerInfo);

				return status;
			}
			else
			{
				return status;
			}
		}

        // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// Static情報の削除処理
        /// </summary>
        /// <returns></returns>
        public int DeleteStaticMemoryData()
        {
            if ((_customerDictionary == null) || (__customerDictionary == null))
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            _customerDictionary.Clear();
            __customerDictionary.Clear();

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// Static情報の取得処理
		/// </summary>
		/// <param name="customerInfo">取得したデータ</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>STATUS[0:取得成功,4:StaticData存在せず]</returns>
		public int ReadStaticMemoryData(out CustomerInfo customerInfo, string enterpriseCode, int customerCode)
		{
            // キー情報生成処理
			string key = this.ConstructionKey(enterpriseCode, customerCode);

			if (_customerDictionary == null)
			{
				customerInfo = null;
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			else if (_customerDictionary.ContainsKey(key))
			{
				customerInfo = (_customerDictionary[key]).Clone();
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			else
			{
				customerInfo = null;
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
		}

		/// <summary>
		/// Static情報の取得処理
		/// </summary>
		/// <param name="customerInfo">取得したデータ</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>STATUS[0:取得成功,4:StaticData存在せず]</returns>
		public int ReadCacheMemoryData(out CustomerInfo customerInfo, string enterpriseCode, int customerCode)
		{
            // キー情報生成処理
			string key = this.ConstructionKey(enterpriseCode, customerCode);

			if (__customerDictionary == null)
			{
				customerInfo = null;
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			else if (__customerDictionary.ContainsKey(key))
			{
				customerInfo = (__customerDictionary[key]).Clone();
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			else
			{
				customerInfo = null;
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
		}

		/// <summary>
		/// StaticMemory初期化情報保存処理
		/// </summary>
		/// <param name="mode">モード[0:両方,1:MainStaticMemory,2:UndoStaticMemory]</param>
		/// <param name="customerInfo">得意先情報クラス</param>
		/// <returns>0:成功</returns>
		public int WriteInitStaticMemory(int mode, CustomerInfo customerInfo)
		{
            // リアルstatic領域の初期化
			if (mode == 0 || mode == 1)
			{
				// 得意先情報バッファ(MainMemory)格納用ハッシュテーブル追加処理
				this.AddMainMemoryDictionary(customerInfo);
			}

			// 元static領域の初期化
			if (mode == 0 || mode == 2)
			{
				// 得意先情報バッファ(UndoMemory)格納用ハッシュテーブル追加処理
				this.AddUndoMemoryDictionary(customerInfo);
			}

			// 得意先情報変更通知を発令する
			this.InstructionInfoCustomerChange(this, false, ref customerInfo);

			return 0;
		}

		/// <summary>
		/// StaticMemory変更有無チェック
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>比較結果 [0:一致する 0以外:一致しない]</returns>
		public int CompareStaticMemory(string enterpriseCode, int customerCode)
		{
            // キー情報生成処理
			string key = this.ConstructionKey(enterpriseCode, customerCode);

			// 得意先情報バッファ(MainMemory)格納用ハッシュテーブルに該当データが存在しない場合は一致しない
			if (!_customerDictionary.ContainsKey(key))
			{
				return 2;
			}

			// 得意先情報バッファ(UndoMemory)格納用ハッシュテーブルに該当データが存在しない場合は一致しない
			if (!__customerDictionary.ContainsKey(key))
			{
				return 3;
			}

			CustomerInfo _customerInfo  = (_customerDictionary[key]).Clone();
			CustomerInfo __customerInfo = (__customerDictionary[key]).Clone();

			if (_customerInfo.Equals(__customerInfo))
			{
				return 0;
			}
			else
			{
				return 1;
			}
		}

		/// <summary>
		/// StaticMemory変更項目画面表示処理（デバッグ用）
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>比較結果 [0:一致する 0以外:一致しない]</returns>
		public int ShowCompareStaticMemory(string enterpriseCode, int customerCode)
		{
            // キー情報生成処理
			string key = this.ConstructionKey(enterpriseCode, customerCode);

			// 得意先情報バッファ(MainMemory)格納用ハッシュテーブルに該当データが存在しない場合は一致しない
			if (!_customerDictionary.ContainsKey(key))
			{
				return 2;
			}

			// 得意先情報バッファ(UndoMemory)格納用ハッシュテーブルに該当データが存在しない場合は一致しない
			if (!__customerDictionary.ContainsKey(key))
			{
				return 3;
			}

			CustomerInfo _customerInfo  = (_customerDictionary[key]).Clone();
			CustomerInfo __customerInfo = (__customerDictionary[key]).Clone();

			if (_customerInfo.Equals(__customerInfo))
			{
				return 0;
			}
			else
			{
				return 1;
			}
		}

		/// <summary>
		/// StaticMemoryの内容を別のStaticMemoryにコピー
		/// </summary>
		/// <param name="mode">モード[0:MainStaticMemory⇒UndoStaticMemory,1:UndoStaticMemory⇒MainStaticMemory]</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>STATUS[0:成功]</returns>
		public int CopyStaticMemory(int mode, string enterpriseCode, int customerCode)
		{
            // キー情報生成処理
			string key = this.ConstructionKey(enterpriseCode, customerCode);

			switch(mode)
			{
				case 0: // MainStaticMemory ⇒ UndoStaticMemory
				{
					// 得意先情報バッファ(MainMemory)格納用ハッシュテーブルに該当データが存在しない場合は処理不能
					if (!_customerDictionary.ContainsKey(key))
					{
						return 1;
					}

					CustomerInfo _customerInfo  = _customerDictionary[key].Clone();

					// 得意先情報バッファ(UndoMemory)格納用ハッシュテーブル追加処理
					this.AddUndoMemoryDictionary(_customerInfo);

					// 得意先情報変更通知を発令する
					this.InstructionInfoCustomerChange(this, false, ref _customerInfo);

					break;
				}
				case 1: // UndoStaticMemory ⇒ MainStaticMemory
				{				
					// 得意先情報バッファ(UndoMemory)格納用ハッシュテーブルに該当データが存在しない場合は一致しない
					if (!__customerDictionary.ContainsKey(key))
					{
						return 1;
					}

					CustomerInfo __customerInfo = __customerDictionary[key].Clone();

					// 得意先情報バッファ(MainMemory)格納用ハッシュテーブル追加処理
					this.AddMainMemoryDictionary(__customerInfo);

					// 得意先情報変更通知を発令する
					this.InstructionInfoCustomerChange(this, false, ref __customerInfo);

					break;
				}
			}

			return 0;
		}

        // 2010/10/28 Add >>>
        /// <summary>
        /// 得意先情報バッファ(MainMemory)格納用Dictionary追加処理
        /// </summary>
        /// <param name="customerInfo">得意先オブジェクト</param>
        private void AddMainMemoryDictionary(CustomerInfo customerInfo)
        {
            this.AddMainMemoryDictionary(customerInfo, true);
        }
        // 2010/10/28 Add <<<

		/// <summary>
		/// 得意先情報バッファ(MainMemory)格納用Dictionary追加処理
		/// </summary>
		/// <param name="customerInfo">得意先オブジェクト</param>
        /// <param name="getMngSectionName">True:管理拠点名称を取得する</param>
        // 2010/10/28 >>>
		//private void AddMainMemoryDictionary(CustomerInfo customerInfo)
        private void AddMainMemoryDictionary(CustomerInfo customerInfo, bool getMngSectionName)
        // 2010/10/28 <<<
        {
			this.RemoveMainMemoryTable(customerInfo);

            if (getMngSectionName)   // 2010/10/28 Add
            {                       // 2010/10/28 Add
                // 管理拠点名称取得
                SecInfoSet secInfoSet;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                secInfoSetAcs.IsLocalDBRead = _isLocalDBRead;

                if (secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, customerInfo.MngSectionCode) == 0)
                {
                    customerInfo.MngSectionName = secInfoSet.SectionGuideNm;
                }
            }                       // 2010/10/28 Add


			string key = this.ConstructionKey(customerInfo.EnterpriseCode, customerInfo.CustomerCode);

			_customerDictionary.Add(key, customerInfo.Clone());
		}

		/// <summary>
		/// 得意先情報バッファ(UndoMemory)格納用ハッシュテーブル追加処理
		/// </summary>
		/// <param name="customerInfo">得意先オブジェクト</param>
		private void AddUndoMemoryDictionary(CustomerInfo customerInfo)
		{
			this.RemoveUndoMemoryTable(customerInfo);

			string key = this.ConstructionKey(customerInfo.EnterpriseCode, customerInfo.CustomerCode);
			__customerDictionary.Add(key, customerInfo.Clone());
		}

		/// <summary>
		/// 得意先情報バッファ(MainMemory)格納用ハッシュテーブル削除処理
		/// </summary>
		/// <param name="customerInfo">得意先情報オブジェクト</param>
		private void RemoveMainMemoryTable(CustomerInfo customerInfo)
		{
			string key = this.ConstructionKey(customerInfo.EnterpriseCode, customerInfo.CustomerCode);
			CustomerInfo customerInfoBuff = customerInfo.Clone();

			if (_customerDictionary.ContainsKey(key))
			{
				_customerDictionary.Remove(key);
			}
		}

		/// <summary>
		/// 得意先情報バッファ(UndoMemory)格納用ハッシュテーブル削除処理
		/// </summary>
		/// <param name="customerInfo">得意先情報オブジェクト</param>
		private void RemoveUndoMemoryTable(CustomerInfo customerInfo)
		{
			string key = this.ConstructionKey(customerInfo.EnterpriseCode, customerInfo.CustomerCode);
			CustomerInfo customerInfoBuff = customerInfo.Clone();

			if (__customerDictionary.ContainsKey(key))
			{
				__customerDictionary.Remove(key);
			}
		}

		/// <summary>
		/// キー情報生成処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">受託契約管理コード</param>
		/// <returns>生成したキー情報</returns>
		public string ConstructionKey(string enterpriseCode, int customerCode)
		{
            string key = string.Empty;
			if (customerCode == 0)
			{
				key = enterpriseCode.Trim() + "-" + this._key.ToString();
			}
			else
			{
				key = enterpriseCode.Trim() + "-" + customerCode.ToString();
			}
			return key;
		}
		# endregion

		// ===================================================================================== //
		// DB操作
		// ===================================================================================== //
		# region DataBase Control
		/// <summary>
		/// DBからStaticMemoryに最新データを設定
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="customerInfo">得意先情報クラス</param>
		/// <returns>STATUS</returns>
		public int ReadDBData(string enterpriseCode, int customerCode, out CustomerInfo customerInfo)
		{
            return this.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, customerCode, true, out customerInfo);
		}

		/// <summary>
		/// DBから得意先データを取得
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="cacheFlg">キャッシュフラグ[true:キャッシュする false:キャッシュしない]</param>
		/// <param name="customerInfo">得意先情報クラス</param>
		/// <returns>STATUS</returns>
		public int ReadDBData(string enterpriseCode, int customerCode,  bool cacheFlg, out CustomerInfo customerInfo)
		{
            return this.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, customerCode, true, out customerInfo);
		}

		/// <summary>
		/// DBから得意先データを取得
		/// </summary>
		/// <param name="logicalMode">論理削除区分</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="customerInfo">得意先情報</param>
		public int ReadDBData(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int customerCode, out CustomerInfo customerInfo)
		{
            return this.ReadDBData(logicalMode, enterpriseCode, customerCode, true, out customerInfo);
		}

        // 2009.02.17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region 削除
        ///// <summary>
        ///// DBから得意先データを取得
        ///// </summary>
        ///// <param name="logicalMode">論理削除区分</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="customerCode">得意先コード</param>
        ///// <param name="cacheFlg">キャッシュフラグ[true:キャッシュする false:キャッシュしない]</param>
        ///// <param name="customerInfo">得意先情報</param>
        ///// <returns>STATUS</returns>
        //public int ReadDBData(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int customerCode,  bool cacheFlg, out CustomerInfo customerInfo)
        //{
        //    // 得意先データ取得（リモートティングを起動する）
        //    customerInfo = null;
        //    //CustSuppli custSuppli = null;
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //    if (LoginInfoAcquisition.OnlineFlag)
        //    {
        //        status = this.Read(logicalMode, enterpriseCode, customerCode, out customerInfo);
        //    }
        //    else
        //    {
        //        status = this.ReadOfflineData(enterpriseCode, customerCode, out customerInfo, this);
        //    }

        //    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo != null)
        //    {
        //        // 管理拠点名称取得
        //        SecInfoSet secInfoSet;
        //        SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
        //        secInfoSetAcs.IsLocalDBRead = _isLocalDBRead;
        //        if (secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, customerInfo.MngSectionCode) == 0)
        //        {
        //            customerInfo.MngSectionName = secInfoSet.SectionGuideNm;
        //        }

        //        // キー情報生成処理
        //        string key = this.ConstructionKey(enterpriseCode, customerCode);

        //        // すでに得意先情報がキャッシングされている場合は更新日の比較を行い、同一日時の場合は
        //        // 再キャッシングは行わない
        //        if ((_customerDictionary.ContainsKey(key)) && ((_customerDictionary[key]).UpdateDateTime == customerInfo.UpdateDateTime))
        //        {
        //            customerInfo = (_customerDictionary[key]).Clone();
        //        }
        //        else
        //        {
        //            if (cacheFlg)
        //            {
        //                // 得意先情報バッファ(MainMemory)格納用ハッシュテーブル追加処理
        //                this.AddMainMemoryDictionary(customerInfo);

        //                // リアル更新にコピー⇒Undoバッファ
        //                this.CopyStaticMemory(0, enterpriseCode, customerCode);
        //            }
        //        }
        //    }
        //    return status;
        //}

        ///// <summary>
        ///// 得意先情報読み込み処理(DBより読み込みなおします)
        ///// </summary>
        ///// <param name="logicalMode">論理削除区分</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="customerCode">得意先コード</param>
        ///// <param name="customerInfo">得意先情報クラス</param>
        ///// <returns>ステータス</returns>
        //private int Read( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int customerCode, out CustomerInfo customerInfo )
        //{
        //    customerInfo = null;
        //    //custSuppli = null;

        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //    // 通常の得意先情報取得の場合は、キャッシュ情報とＤＢ情報の更新日を比較し、
        //    // 更新日が同一の場合はキャッシュ情報を戻す。
        //    if ( (logicalMode == ConstantManagement.LogicalMode.GetData0) && (LoginInfoAcquisition.OnlineFlag) )
        //    {
        //        CustomerInfo customerInfoBuff;
        //        //CustSuppli custSuppliBuff;
        //        status = this.ReadStaticMemoryData( out customerInfoBuff, enterpriseCode, customerCode );

        //        if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
        //        {
        //            if ( _isLocalDBRead )
        //            {
        //                //  更新日変更チェック処理
        //                if ( !(this._customerInfoLcDB.IsUpdateDateTimeChange( customerInfoBuff.UpdateDateTime, enterpriseCode, customerCode )) )
        //                {
        //                    if ( customerInfoBuff != null )
        //                    {
        //                        customerInfo = customerInfoBuff.Clone();
        //                    }
        //                    return status;
        //                }
        //            }
        //            else
        //            {
        //                //  更新日変更チェック処理
        //                if ( !(this._iCustomerInfoDB.IsUpdateDateTimeChange( customerInfoBuff.UpdateDateTime, enterpriseCode, customerCode )) )
        //                {
        //                    if ( customerInfoBuff != null )
        //                    {
        //                        customerInfo = customerInfoBuff.Clone();
        //                    }
        //                    return status;
        //                }
        //            }
        //        }
        //    }

        //    // 得意先マスタパラメータ設定
        //    CustomerWork customerWork = new CustomerWork();
        //    customerWork.EnterpriseCode = enterpriseCode;
        //    customerWork.CustomerCode = customerCode;

        //    // CustomeSerializeArrayListにパラメータを設定
        //    CustomSerializeArrayList paraCustomerArray = new CustomSerializeArrayList();
        //    paraCustomerArray.Add( customerWork );

        //    object paraList = paraCustomerArray;

        //    //得意先読み込み
        //    status = this._iCustomerInfoDB.Read( logicalMode, ref paraList );

        //    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
        //    {
        //        customerInfo = null;

        //        CustomSerializeArrayList retCustomerArrayList = paraList as CustomSerializeArrayList;
        //        foreach ( object obj in retCustomerArrayList )
        //        {
        //            if ( obj is CustomerWork )
        //            {
        //                customerWork = (CustomerWork)obj;

        //                // クラス内メンバコピー
        //                customerInfo = CustomerInfoAcs.CopyToCustomerInfoFromCustomerWork( customerWork );

        //                // 各マスタ名称設定
        //                ReflectDisplayName( ref customerInfo );

        //                // 表示名称設定処理
        //                this.SetDspName( ref customerInfo );
        //            }
        //        }
        //    }

        //    return status;
        //}
        #endregion

        /// <summary>
        /// DBから得意先データを取得
        /// </summary>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="cacheFlg">キャッシュフラグ[true:キャッシュする false:キャッシュしない]</param>
        /// <param name="customerInfo">得意先情報</param>
        /// <returns>STATUS</returns>
        public int ReadDBData(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int customerCode, bool cacheFlg, out CustomerInfo customerInfo)
        {
            return this.ReadDBData(logicalMode, enterpriseCode, customerCode, cacheFlg, true, out customerInfo);
        }
            
        /// <summary>
        /// DBから得意先データを取得
        /// </summary>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="cacheFlg">キャッシュフラグ[true:キャッシュする false:キャッシュしない]</param>
        /// <param name="isSettingName">名称設定区分(ture:設定あり false:設定無し)</param>
        /// <param name="customerInfo">得意先情報</param>
        /// <returns></returns>
        public int ReadDBData(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int customerCode, bool cacheFlg, bool isSettingName, out CustomerInfo customerInfo)
        {
            // 得意先データ取得（リモートティングを起動する）
            customerInfo = null;
            //CustSuppli custSuppli = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 2009/07/30 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    status = this.Read(logicalMode, enterpriseCode, customerCode, isSettingName, out customerInfo);
            //}
            //else
            //{
            //    status = this.ReadOfflineData(enterpriseCode, customerCode, isSettingName, out customerInfo, this);
            //}

            status = this.Read(logicalMode, enterpriseCode, customerCode, isSettingName, out customerInfo);
            // 2009/07/30 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo != null)
            {
                if (isSettingName)
                {
                    // 2010/10/28 Del 管理拠点名称は、リモートでJOINするので削除 >>>
                    //// 管理拠点名称取得
                    //SecInfoSet secInfoSet;
                    //SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                    //secInfoSetAcs.IsLocalDBRead = _isLocalDBRead;
                    //if (secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, customerInfo.MngSectionCode) == 0)
                    //{
                    //    customerInfo.MngSectionName = secInfoSet.SectionGuideNm;
                    //}
                    // 2010/10/28 Del <<<
                }

                // キー情報生成処理
                string key = this.ConstructionKey(enterpriseCode, customerCode);

                // すでに得意先情報がキャッシングされている場合は更新日の比較を行い、同一日時の場合は
                // 再キャッシングは行わない
                if ((_customerDictionary.ContainsKey(key)) && ((_customerDictionary[key]).UpdateDateTime == customerInfo.UpdateDateTime))
                {
                    customerInfo = (_customerDictionary[key]).Clone();
                }
                else
                {
                    if (cacheFlg)
                    {
                        // 得意先情報バッファ(MainMemory)格納用ハッシュテーブル追加処理
                        // 2010/10/28 >>>
                        //this.AddMainMemoryDictionary(customerInfo);
                        this.AddMainMemoryDictionary(customerInfo, false);
                        // 2010/10/28 <<<

                        // リアル更新にコピー⇒Undoバッファ
                        this.CopyStaticMemory(0, enterpriseCode, customerCode);
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// 得意先情報読み込み処理(DBより読み込みなおします)
        /// </summary>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="isSettingName">名称設定区分(ture:設定あり false:設定無し)</param>
        /// <param name="customerInfo">得意先情報クラス</param>
        /// <returns></returns>
        /// <br>UpdateNote  : 2010/08/10 caowj</br>
        /// <br>              得意先マスタ障害改良対応</br>
        private int Read(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int customerCode, bool isSettingName, out CustomerInfo customerInfo)
        {
            customerInfo = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 通常の得意先情報取得の場合は、キャッシュ情報とＤＢ情報の更新日を比較し、
            // 更新日が同一の場合はキャッシュ情報を戻す。
            //if ((logicalMode == ConstantManagement.LogicalMode.GetData0) && (LoginInfoAcquisition.OnlineFlag)) // 2009/07/30
            if (logicalMode == ConstantManagement.LogicalMode.GetData0) // 2009/07/30
            {
                CustomerInfo customerInfoBuff;
                status = this.ReadStaticMemoryData(out customerInfoBuff, enterpriseCode, customerCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (_isLocalDBRead)
                    {
                        //  更新日変更チェック処理
                        if (!(this._customerInfoLcDB.IsUpdateDateTimeChange(customerInfoBuff.UpdateDateTime, enterpriseCode, customerCode)))
                        {
                            if (customerInfoBuff != null)
                            {
                                customerInfo = customerInfoBuff.Clone();
                            }
                            return status;
                        }
                    }
                    else
                    {
                        //  更新日変更チェック処理
                        if (!(this._iCustomerInfoDB.IsUpdateDateTimeChange(customerInfoBuff.UpdateDateTime, enterpriseCode, customerCode)))
                        {
                            if (customerInfoBuff != null)
                            {
                                customerInfo = customerInfoBuff.Clone();
                            }
                            return status;
                        }
                    }
                }
            }

            // 得意先マスタパラメータ設定
            CustomerWork customerWork = new CustomerWork();
            customerWork.EnterpriseCode = enterpriseCode;
            customerWork.CustomerCode = customerCode;

            // CustomeSerializeArrayListにパラメータを設定
            CustomSerializeArrayList paraCustomerArray = new CustomSerializeArrayList();
            paraCustomerArray.Add(customerWork);

            object paraList = paraCustomerArray;

            // UPD 陳健 K2014/02/06 -------------------------------------------------->>>>>
            //得意先読み込み
            // UPD 梶谷貴士 2021/05/10 -------------------------------------------------->>>>>
            //if (_opt_Maehashi == (int)Option.ON)
            //{
            // UPD 梶谷貴士 2021/05/10 --------------------------------------------------<<<<<
                status = this._iCustomerInfoDB.MaehashiRead(logicalMode, ref paraList);
            // UPD 梶谷貴士 2021/05/10 -------------------------------------------------->>>>>
            //}
            //else
            //{
                //status = this._iCustomerInfoDB.Read(logicalMode, ref paraList);
            //}
                // UPD 梶谷貴士 2021/05/10 --------------------------------------------------<<<<<
            // UPD 陳健 K2014/02/06 --------------------------------------------------<<<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                customerInfo = null;

                CustomSerializeArrayList retCustomerArrayList = paraList as CustomSerializeArrayList;
                foreach (object obj in retCustomerArrayList)
                {
                    if (obj is CustomerWork)
                    {
                        customerWork = (CustomerWork)obj;

                        // 2010/10/28 Del >>>
                        //// --- ADD 2010/08/10 ------------------------------------>>>>>
                        //UserGdBd userGdBd = null;
                        //UserGuideAcsData acsDataType = UserGuideAcsData.UserBodyData;
                        //int statusFlag1 = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 33, customerWork.BusinessTypeCode, ref acsDataType);
                        //if ((statusFlag1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL && userGdBd != null && userGdBd.LogicalDeleteCode != 0) || statusFlag1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    customerWork.BusinessTypeName = string.Empty;
                        //}

                        //int statusFlag2 = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 34, customerWork.JobTypeCode, ref acsDataType);
                        //if ((statusFlag2 == (int)ConstantManagement.DB_Status.ctDB_NORMAL && userGdBd != null && userGdBd.LogicalDeleteCode != 0) || statusFlag2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    customerWork.JobTypeName = string.Empty;
                        //}

                        //int statusFlag3 = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 21, customerWork.SalesAreaCode, ref acsDataType);
                        //if ((statusFlag3 == (int)ConstantManagement.DB_Status.ctDB_NORMAL && userGdBd != null && userGdBd.LogicalDeleteCode != 0) || statusFlag3 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    customerWork.SalesAreaName = string.Empty;
                        //}
                        //// --- ADD 2010/08/10 ------------------------------------<<<<<
                        // 2010/10/28 Del <<<

                        // クラス内メンバコピー
                        customerInfo = CustomerInfoAcs.CopyToCustomerInfoFromCustomerWork(customerWork);

                        if (isSettingName)
                        {
                            // 各マスタ名称設定
                            ReflectDisplayName(ref customerInfo);

                            // 表示名称設定処理
                            this.SetDspName(ref customerInfo);
                        }
                    }
                }
            }

            return status;
        }
        // 2009.02.17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// 各マスタ名称適用処理
        /// </summary>
        /// <param name="customerInfo"></param>
        private void ReflectDisplayName( ref CustomerInfo customerInfo )
        {
            //-------------------------------------------------
            // 管理拠点名称取得
            //-------------------------------------------------
            if ( _secInfoSetAcs == null )
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }
            SecInfoSet secInfoSet;
            _secInfoSetAcs.IsLocalDBRead = _isLocalDBRead;
            if ( _secInfoSetAcs.Read( out secInfoSet, this._enterpriseCode, customerInfo.MngSectionCode.TrimEnd() ) == 0 )
            {
                customerInfo.MngSectionName = secInfoSet.SectionGuideNm;
            }

            //-------------------------------------------------
            // 集金担当者名称取得
            //-------------------------------------------------
            if ( _employeeAcs == null )
            {
                _employeeAcs = new EmployeeAcs();
            }
            Employee employee;
            _employeeAcs.IsLocalDBRead = _isLocalDBRead;
            if ( _employeeAcs.Read( out employee, this._enterpriseCode, customerInfo.BillCollecterCd.TrimEnd() ) == 0 )
            {
                customerInfo.BillCollecterNm = employee.Name;
            }
        }
        private SecInfoSetAcs _secInfoSetAcs;
        private EmployeeAcs _employeeAcs;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		/// <summary>
		/// StaticMemoryの内容をＤＢに書き込み
		/// </summary>
		/// <param name="sender">書き込み指令を発行したクラス</param>
		/// <param name="forceEvent">true:自分自身にもイベントを発生させる,false:自分自身にはイベントを発生させない</param>
		/// <param name="customerInfo">得意先情報クラス</param>
		/// <param name="duplicationItemList">エラーメッセージクラス</param>
		/// <returns>STATUS</returns>
		public int WriteDBData(object sender, bool forceEvent, ref CustomerInfo customerInfo, out ArrayList duplicationItemList)
		{
            return this.WriteDBData(sender, forceEvent, ref customerInfo, out duplicationItemList, 0);
		}

		/// <summary>
		/// StaticMemoryの内容をＤＢに書き込み
		/// </summary>
		/// <param name="sender">書き込み指令を発行したクラス</param>
		/// <param name="forceEvent">true:自分自身にもイベントを発生させる,false:自分自身にはイベントを発生させない</param>
		/// <param name="customerInfo">得意先情報クラス</param>
		/// <param name="duplicationItemList">エラーメッセージクラス</param>
		/// <param name="carMngNo">得意先と車輌を同時登録する際の車輌管理番号</param>
		/// <returns>STATUS</returns>
		public int WriteDBData(object sender, bool forceEvent, ref CustomerInfo customerInfo, out ArrayList duplicationItemList, int carMngNo)
		{
            int status;

			ArrayList dupList = new ArrayList();
			duplicationItemList = new ArrayList();

			CustomerInfo _customerInfo = null;
			CustomerInfo __customerInfo = null;

			string key = this.ConstructionKey(customerInfo.EnterpriseCode, customerInfo.CustomerCode);

			if (_customerDictionary.ContainsKey(key))
			{
				_customerInfo = ((CustomerInfo)_customerDictionary[key]).Clone();
			}
			else
			{
				return -1;
			}

			if (__customerDictionary.ContainsKey(key))
			{
				__customerInfo = __customerDictionary[key].Clone();
			}

			status = this.Write(ref _customerInfo, out dupList, carMngNo);

			if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 得意先情報バッファ(MainMemory)格納用ハッシュテーブル追加処理
				this.AddMainMemoryDictionary(_customerInfo);

				// リアル更新にコピー⇒Undoバッファ（得意先情報変更通知）
				this.CopyStaticMemory(0, _customerInfo.EnterpriseCode, _customerInfo.CustomerCode);

				customerInfo = _customerInfo.Clone();
			}
			
			if (dupList.Count > 0 )
			{
				foreach(string strItem in dupList)
				{
					duplicationItemList.Add(strItem);
				}
			}
			return status;
		}

		/// <summary>
		/// 引数の得意先情報をＤＢに書き込み
		/// </summary>
		/// <param name="customerInfo">得意先情報</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note　	  : 引数の得意先情報をDBに書き込む（データのチェックは行わないので必ず先にチェックを行っておくこと）</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int WriteDBData(ref CustomerInfo customerInfo)
		{
            int status;
			ArrayList dupList;

			status = this.Write(ref customerInfo, out dupList, 0);
			return status;
		}

		/// <summary>
		/// 得意先登録・更新処理
		/// </summary>
		/// <param name="customerInfo">得意先クラス</param>
		/// <param name="duplicationItemList">重複エラー時のエラー項目</param>
		/// <param name="carMngNo">得意先と車輌を同時登録する際の車輌管理番号</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 得意先情報の登録・更新を行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private int Write(ref CustomerInfo customerInfo,  out ArrayList duplicationItemList, int carMngNo)
		{
			duplicationItemList = new ArrayList();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
            int targetCustomerCode = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD

			try
			{
				// 重複エラー情報リストをクリア
				duplicationItemList.Clear();

				// 得意先クラスから得意先ワーカークラスにメンバコピー
				CustomerWork customerWork = CustomerInfoAcs.CopyToCustomerWorkFromCustomerInfo(customerInfo);

                // CustomeSerializeArrayListにパラメータを設定
                CustomSerializeArrayList paraCustomerArray = new CustomSerializeArrayList();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 DEL
                //paraCustomerArray.Add( customerWork );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD

                if ( customerWork.CustomerCode == customerWork.ClaimCode )
                {
                    //---------------------------------------------------
                    // 親得意先→親と全ての子を更新
                    //---------------------------------------------------
                    # region [親得意先]
                    Dictionary<int, CustomerWork> customerDic = new Dictionary<int, CustomerWork>();
                    ArrayList searchParaList = new ArrayList();
                    searchParaList.Add( customerWork );
                    object searchObj = searchParaList;

                    // 得意先→親と全ての子検索
                    int searchStatus = this._iCustomerInfoDB.Search( ConstantManagement.LogicalMode.GetDataAll, ref searchObj );
                    //if ( searchObj == null || (searchObj is ArrayList) == false || (searchObj as ArrayList).Count == 0 )
                    //{
                    //    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    //}
                    searchParaList = (ArrayList)searchObj;


                    // 親得意先を格納
                    paraCustomerArray.Add( customerWork );
                    customerDic.Add( customerWork.CustomerCode, customerWork );
                    targetCustomerCode = customerWork.CustomerCode;


                    // 親→全ての子書き換え
                    //foreach ( CustomerWork childCustomer in searchParaList )
                    for ( int index = 0; index < searchParaList.Count; index++ )
                    {
                        CustomerWork childCustomer = (CustomerWork)searchParaList[index];

                        if ( childCustomer.CustomerCode == customerWork.CustomerCode )
                        {
                            continue;
                        }
                        else
                        {
                            if ( !customerDic.ContainsKey( childCustomer.CustomerCode ) )
                            {
                                // 子→親の情報をcopy
                                ReflectChildCustomerFromParent( ref childCustomer, customerWork );

                                // CustomeSerializeArrayListにパラメータを設定
                                paraCustomerArray.Add( childCustomer );
                                customerDic.Add( childCustomer.CustomerCode, childCustomer );
                            }
                        }
                    }
                    # endregion
                }
                else
                {
                    //---------------------------------------------------
                    // 子得意先→子のみ更新
                    //---------------------------------------------------
                    # region [子得意先]
                    // CustomeSerializeArrayListにパラメータを設定
                    paraCustomerArray.Add( customerWork );
                    # endregion
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD

                object paraList = paraCustomerArray;

                // UPD 陳健 K2014/02/06 ------------------------------------------------------------------->>>>>
				// 得意先書き込み
                int status;
                // DEL 梶谷貴士 2021/05/10 ------------------------------------------------------------------->>>>>
                //if (_opt_Maehashi == (int)Option.ON)
                //{
                // DEL 梶谷貴士 2021/05/10 -------------------------------------------------------------------<<<<<
                    status = this._iCustomerInfoDB.MaehashiWrite(ref paraList, out duplicationItemList, carMngNo);
                // DEL 梶谷貴士 2021/05/10 ------------------------------------------------------------------->>>>>
                //}
                //else
                //{
                //    status = this._iCustomerInfoDB.Write(ref paraList, out duplicationItemList, carMngNo);
                //}
                // DEL 梶谷貴士 2021/05/10 -------------------------------------------------------------------<<<<<
                // UPD 陳健 K2014/02/06 -------------------------------------------------------------------<<<<<

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					CustomSerializeArrayList retCustomerArrayList = paraList as CustomSerializeArrayList;
					foreach(object obj in retCustomerArrayList)
					{
						if(obj is CustomerWork)
						{
    						customerWork = (CustomerWork)obj;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
                            if ( customerWork.CustomerCode != targetCustomerCode ) continue;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD

							// クラス内メンバコピー
							customerInfo = CustomerInfoAcs.CopyToCustomerInfoFromCustomerWork(customerWork);

                            // 各マスタ名称設定
                            ReflectDisplayName( ref customerInfo );

							// 表示名称設定処理
							this.SetDspName(ref customerInfo);
						}
					}
				}
				return status;
			}
			catch (Exception e)
			{
				// ログ吐き出し
				System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();
				eventLog.Source = "Customer Write";
				eventLog.WriteEntry("得意先情報の登録に失敗しました。" + "\r\n" + this.ToString() + "\r\n" + e.Message,
					System.Diagnostics.EventLogEntryType.Error,
					1);

				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
        /// <summary>
        /// 親得意先情報に基づく子得意先情報の更新
        /// </summary>
        /// <param name="child"></param>
        /// <param name="parent"></param>
        private void ReflectChildCustomerFromParent( ref CustomerWork child, CustomerWork parent )
        {
            child.TotalDay = parent.TotalDay; // 締日
            child.CollectMoneyCode = parent.CollectMoneyCode; // 集金月区分コード
            child.CollectMoneyName = parent.CollectMoneyName; // 集金月区分名称
            child.CollectMoneyDay = parent.CollectMoneyDay; // 集金日
            child.CollectCond = parent.CollectCond; // 回収条件
            child.CollectSight = parent.CollectSight; // 回収サイト
            child.NTimeCalcStDate = parent.NTimeCalcStDate; // 次回勘定開始日
            child.CustCTaXLayRefCd = parent.CustCTaXLayRefCd; // 得意先消費税転嫁方式参照区分
            child.ConsTaxLayMethod = parent.ConsTaxLayMethod; // 消費税転嫁方式
            child.CreditMngCode = parent.CreditMngCode; // 与信管理区分
            child.DepoDelCode = parent.DepoDelCode; // 入金消込区分
            child.SalesCnsTaxFrcProcCd = parent.SalesCnsTaxFrcProcCd; // 売上消費税端数処理コード
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD

		/// <summary>
		/// 得意先マスタ論理削除処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="carDeleteFlg">車輌削除フラグ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: 引数の企業コード、得意先コードに該当する得意先を得意先マスタから論理削除します。
		///					　車輌削除フラグがtrueの場合は、車輌も同時に削除します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int LogicalDeleteDBData(string enterpriseCode, int customerCode, bool carDeleteFlg)
		{
            int status;

			if ((enterpriseCode.Trim() == "") || (customerCode == 0)) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			string key = this.ConstructionKey(enterpriseCode, customerCode);
			CustomerInfo customerInfo;

			if (!_customerDictionary.ContainsKey(key))
			{
				status = this.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, customerCode, out customerInfo);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
			}
			else
			{
				customerInfo = ((CustomerInfo)_customerDictionary[key]).Clone();
			}

			status = this.LogicalDelete(ref customerInfo, carDeleteFlg);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				customerInfo = customerInfo.Clone();

				// Hashtableからデータをキャッシュ情報を削除する
				if (_customerDictionary.ContainsKey(key))
				{
					_customerDictionary.Remove(key);
				}

				if (__customerDictionary.ContainsKey(key))
				{
					__customerDictionary.Remove(key);
				}

				// 得意先削除通知を発令する
				this.InstructionInfoDeleteCustomerInfo(this, false, ref customerInfo);
			}
			return status;
		}

		/// <summary>
		/// StaticMemoryの内容をＤＢから削除（論理削除）
		/// </summary>
		/// <param name="sender">書き込み指令を発行したクラス</param>
		/// <param name="forceEvent">true:自分自身にもイベントを発生させる,false:自分自身にはイベントを発生させない</param>
		/// <param name="customerInfo">得意先情報クラス</param>
		/// <param name="carDeleteFlg">車輌削除フラグ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: StaticMemoryの内容同一のデータをＤＢから論理削除します。
		///					　車輌削除フラグがtrueの場合は、車輌も同時に削除します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int LogicalDeleteDBData(object sender, bool forceEvent, ref CustomerInfo customerInfo, bool carDeleteFlg)
		{
            int status;

			string key = this.ConstructionKey(customerInfo.EnterpriseCode, customerInfo.CustomerCode);

			if (!_customerDictionary.ContainsKey(key))
			{
				return 1;
			}

			CustomerInfo _customerInfo = ((CustomerInfo)_customerDictionary[key]).Clone();

			status = this.LogicalDelete(ref _customerInfo, carDeleteFlg);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				customerInfo = _customerInfo.Clone();

				// Hashtableからデータをキャッシュ情報を削除する
				_customerDictionary.Remove(key);

				if (__customerDictionary.ContainsKey(key))
				{
					__customerDictionary.Remove(key);
				}

				// 得意先削除通知を発令する
				this.InstructionInfoDeleteCustomerInfo(this, forceEvent, ref customerInfo);
			}
			return status;
		}

		/// <summary>
		/// 得意先論理削除処理
		/// </summary>
		/// <param name="customerInfo">得意先オブジェクト</param>
		/// <param name="carDeleteFlg">車輌削除フラグ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 得意先情報の論理削除を行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		private int LogicalDelete(ref CustomerInfo customerInfo, bool carDeleteFlg)
		{
			try
			{
				// 得意先クラスから得意先ワーカークラスにメンバコピー
				CustomerWork customerWork = CustomerInfoAcs.CopyToCustomerWorkFromCustomerInfo(customerInfo);

				// CustomeSerializeArrayListにパラメータを設定
				CustomSerializeArrayList paraCustomerArray = new CustomSerializeArrayList();
				paraCustomerArray.Add(customerWork);

				object paraList = paraCustomerArray;

                // UPD 陳健 K2014/02/06 ------------------------------------------------------------------->>>>>
                int status;
				// 得意先情報論理削除
                // DEL 梶谷貴士 2021/05/10 ------------------------------------------------------------------->>>>>
                //if (_opt_Maehashi == (int)Option.ON)
                //{
                // DEL 梶谷貴士 2021/05/10 -------------------------------------------------------------------<<<<<
                    status = this._iCustomerInfoDB.MaehashiLogicalDelete(ref paraList, carDeleteFlg);
                // DEL 梶谷貴士 2021/05/10 ------------------------------------------------------------------->>>>>
                //}
                //else
                //{
                //    status = this._iCustomerInfoDB.LogicalDelete(ref paraList, carDeleteFlg);
                //}
                // UPD 陳健 K2014/02/06 -------------------------------------------------------------------<<<<<
                // DEL 梶谷貴士 2021/05/10 -------------------------------------------------------------------<<<<<
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						CustomSerializeArrayList retCustomerArrayList = paraList as CustomSerializeArrayList;
						foreach(object obj in retCustomerArrayList)
						{
							if(obj is CustomerWork)
							{
								customerWork = (CustomerWork)obj;

								// クラス内メンバコピー
								customerInfo = CustomerInfoAcs.CopyToCustomerInfoFromCustomerWork(customerWork);

                                // 各マスタ名称設定
                                ReflectDisplayName( ref customerInfo );

								// 表示名称設定処理
								this.SetDspName(ref customerInfo);
							}
						}
					}
				}

				return status;
			}
			catch (Exception e)
			{
				// ログ吐き出し
				System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();
				eventLog.Source = "Customer LogicalDelete";
				eventLog.WriteEntry("得意先情報の論理削除に失敗しました。" + "\r\n" + this.ToString() + "\r\n" + e.Message,
					System.Diagnostics.EventLogEntryType.Error, 1, 0);

				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}

		/// <summary>
		/// 得意先マスタ削除チェック処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="message">メッセージ</param>
		/// <param name="checkFlg">チェック結果[true:削除ＯＫ][false:削除ＮＧ]</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 得意先マスタの削除チェック処理を行います</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int DeleteCheck(string enterpriseCode, int customerCode, out string message, out bool checkFlg)
		{
            CustomerInfo customerInfo;
			int status = this.ReadDBData(enterpriseCode, customerCode, true, out customerInfo);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				bool showDialog = false;
				string name = string.Empty;

				if (showDialog)
				{
					DialogResult dialogResult = TMsgDisp.Show(
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						"PMKHN09012A",
						"削除対象得意先は「" + name + "」です。" + "\r\n" + "削除してもよろしいですか？",
						0,
						MessageBoxButtons.YesNo,
						MessageBoxDefaultButton.Button1);

					if (dialogResult != DialogResult.Yes)
					{
						checkFlg = false;
						message = string.Empty;
						return -1;
					}
				}
			}

			checkFlg = true;
			message = string.Empty;

			try
			{
				// 得意先削除チェック処理
				return this._iCustomerInfoDB.DeleteCheck(enterpriseCode, customerCode, out message, out checkFlg);
			}
			catch (Exception e)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_STOPDISP,
					"PMKHN09012A",
					"得意先情報の削除チェックに失敗しました。" + "\r\n" + this.ToString() + "\r\n" + e.Message,
					(int)ConstantManagement.DB_Status.ctDB_ERROR,
					e,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);

				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
		}

        // --- ADD 2008/09/04 -------------------------------->>>>>
        /// <summary>
        /// StaticMemoryの内容をＤＢから削除（完全削除）
        /// </summary>
        /// <param name="sender">書き込み指令を発行したクラス</param>
        /// <param name="forceEvent">true:自分自身にもイベントを発生させる,false:自分自身にはイベントを発生させない</param>
        /// <param name="customerInfo">得意先情報クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note		: StaticMemoryの内容同一のデータをＤＢから論理削除します。</br>
        /// <br>Programmer : 30452 上野俊治</br>
        /// <br>Date       : 2008.09.04</br>
        /// </remarks>
        public int CompleteDeleteDBData(object sender, bool forceEvent, ref CustomerInfo customerInfo)
        {
            int status;

            string key = this.ConstructionKey(customerInfo.EnterpriseCode, customerInfo.CustomerCode);

            if (!_customerDictionary.ContainsKey(key))
            {
                return 1;
            }

            CustomerInfo _customerInfo = ((CustomerInfo)_customerDictionary[key]).Clone();

            status = this.CompleteDelete(ref _customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                customerInfo = _customerInfo.Clone();

                // Hashtableからデータをキャッシュ情報を削除する
                _customerDictionary.Remove(key);

                if (__customerDictionary.ContainsKey(key))
                {
                    __customerDictionary.Remove(key);
                }

                // 得意先削除通知を発令する
                this.InstructionInfoDeleteCustomerInfo(this, forceEvent, ref customerInfo);
            }
            return status;
        }

        /// <summary>
        /// 得意先削除処理(完全削除)
        /// </summary>
        /// <param name="customerInfo">得意先オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先情報の完全削除を行います。</br>
        /// <br>Programmer : 30452 上野俊治</br>
        /// <br>Date       : 2008.09.04</br>
        /// </remarks>
        private int CompleteDelete(ref CustomerInfo customerInfo)
        {
            try
            {
                // 得意先クラスから得意先ワーカークラスにメンバコピー
                CustomerWork customerWork = CustomerInfoAcs.CopyToCustomerWorkFromCustomerInfo(customerInfo);

                // CustomeSerializeArrayListにパラメータを設定
                CustomSerializeArrayList paraCustomerArray = new CustomSerializeArrayList();
                paraCustomerArray.Add(customerWork);

                object paraList = paraCustomerArray;

                // 得意先情報論理削除
                // UPD 陳健 K2014/02/06 ------------------------------------------------------------------->>>>>
                int status;
                // DEL 梶谷貴士 2021/05/10 ------------------------------------------------------------------->>>>>
                //if (_opt_Maehashi == (int)Option.ON)
                //{
                // DEL 梶谷貴士 2021/05/10 -------------------------------------------------------------------<<<<<
                    status = this._iCustomerInfoDB.MaehashiDelete(ref paraList);
                // DEL 梶谷貴士 2021/05/10 ------------------------------------------------------------------->>>>>
                //}
                //else
                //{
                //    status = this._iCustomerInfoDB.Delete(ref paraList);
                //}
                // DEL 梶谷貴士 2021/05/10 -------------------------------------------------------------------<<<<<
                // UPD 陳健 K2014/02/06 -------------------------------------------------------------------<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    CustomSerializeArrayList retCustomerArrayList = paraList as CustomSerializeArrayList;
                    foreach (object obj in retCustomerArrayList)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = (CustomerWork)obj;

                            // クラス内メンバコピー
                            customerInfo = CustomerInfoAcs.CopyToCustomerInfoFromCustomerWork(customerWork);

                            // 各マスタ名称設定
                            ReflectDisplayName( ref customerInfo );

                            // 表示名称設定処理
                            this.SetDspName(ref customerInfo);
                        }
                    }
                }

                return status;
            }
            catch (Exception e)
            {
                // ログ吐き出し
                System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();
                eventLog.Source = "Customer LogicalDelete";
                eventLog.WriteEntry("得意先情報の完全削除に失敗しました。" + "\r\n" + this.ToString() + "\r\n" + e.Message,
                    System.Diagnostics.EventLogEntryType.Error, 1, 0);

                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }

        /// <summary>
        /// 得意先マスタ完全削除チェック処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="message">メッセージ</param>
        /// <param name="checkFlg">チェック結果[true:削除ＯＫ][false:削除ＮＧ]</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタの完全削除チェック処理を行います</br>
        /// <br>Programmer : 30452 上野俊治</br>
        /// <br>Date       : 2008.09.04</br>
        /// </remarks>
        public int CompleteDeleteCheck(string enterpriseCode, int customerCode, out string message, out bool checkFlg)
        {
            CustomerInfo customerInfo;

            // 完全削除対象になるのは論理削除行のみ
            int status = this.ReadDBData(ConstantManagement.LogicalMode.GetData1, enterpriseCode, customerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                bool showDialog = false;
                string name = string.Empty;

                if (showDialog)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        "PMKHN09012A",
                        "削除対象得意先は「" + name + "」です。" + "\r\n" + "削除してもよろしいですか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult != DialogResult.Yes)
                    {
                        checkFlg = false;
                        message = string.Empty;
                        return -1;
                    }
                }
            }

            // 完全削除の場合はDeleteCheckを呼ばなくて良い。
            checkFlg = true;
            message = string.Empty;

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        // --- ADD 2008/09/04 --------------------------------<<<<< 

		/// <summary>
		/// 得意先マスタ復元処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: 引数の企業コード、得意先コードに該当する得意先を得意先マスタから復元します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int RevivalDBData(string enterpriseCode, int customerCode)
		{
            int status;

			if ((enterpriseCode.Trim() == "") || (customerCode == 0)) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // UPD 陳健 K2014/02/06 ------------------------------------------------------------------->>>>>
            // DEL 梶谷貴士 2021/05/10 ------------------------------------------------------------------->>>>>
            //if (_opt_Maehashi == (int)Option.ON)
            //{
            // DEL 梶谷貴士 2021/05/10 -------------------------------------------------------------------<<<<<
                status = this._iCustomerInfoDB.MaehashiRevivalLogicalDelete(enterpriseCode, customerCode);
            // DEL 梶谷貴士 2021/05/10 ------------------------------------------------------------------->>>>>
            //}
            //else
            //{
            //    status = this._iCustomerInfoDB.RevivalLogicalDelete(enterpriseCode, customerCode);
            //}
            // DEL 梶谷貴士 2021/05/10 -------------------------------------------------------------------<<<<<
            // UPD 陳健 K2014/02/06 -------------------------------------------------------------------<<<<<

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				string key = this.ConstructionKey(enterpriseCode, customerCode);

				// Hashtableからデータをキャッシュ情報を削除する
				if (_customerDictionary.ContainsKey(key))
				{
					_customerDictionary.Remove(key);
				}

				if (__customerDictionary.ContainsKey(key))
				{
					__customerDictionary.Remove(key);
				}
			}
			return status;
		}

		/// <summary>
		/// 得意先名称取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCodeArray">得意先コード配列</param>
		/// <param name="nameTable">名称Hashtable</param>
		/// <param name="name2Table">名称2Hashtable</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 得意先コードを複数指定し、名称と名称２をHashtableで取得します</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int GetName(string enterpriseCode, int[] customerCodeArray, out Hashtable nameTable, out Hashtable name2Table)
		{
            if (_isLocalDBRead)
            {
                return this._customerInfoLcDB.GetName(enterpriseCode, customerCodeArray, out nameTable, out name2Table);
            }
            else
            {
                return this._iCustomerInfoDB.GetName(enterpriseCode, customerCodeArray, out nameTable, out name2Table);
            }
        }
		# endregion

		// ===================================================================================== //
		// オフラインデータ操作
		// ===================================================================================== //
		# region Offline Data Control
		/// <summary>
		/// オフラインデータ保存処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="sender">呼び出し元オブジェクト</param>
		/// <returns>STATUS</returns>
		public int WriteOfflineData(string enterpriseCode, int customerCode, object sender)
		{
            CustomerInfo customerInfo;
			int status = this.ReadStaticMemoryData(out customerInfo, enterpriseCode, customerCode);

			// Static領域に得意先情報が存在しない場合は再度取得
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				status = this.ReadDBData(enterpriseCode, customerCode, out customerInfo);
			}

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 得意先クラスから得意先ワーカークラスにメンバコピー
				CustomerWork customerWork = CustomerInfoAcs.CopyToCustomerWorkFromCustomerInfo(customerInfo);

				// CustomeSerializeArrayListにパラメータを設定
				CustomSerializeArrayList paraCustomerArray = new CustomSerializeArrayList();
				paraCustomerArray.Add(customerWork);

				// オフラインデータ保存処理
				status = this.WriteOfflineData(paraCustomerArray, sender);
			}

			return status;
		}

		/// <summary>
		/// オフラインデータ保存処理
		/// </summary>
		/// <param name="customSerializeArrayList">カスタムシリアライズArrayList</param>
		/// <param name="sender">呼び出し元オブジェクト</param>
		/// <returns>STATUS</returns>
		public int WriteOfflineData(CustomSerializeArrayList customSerializeArrayList, object sender)
		{
            CustomerWork customerWork;
            //CusCarNoteWork cusCarNoteWork;
            //ArrayList familyWorkList;
            this.DivisionCustomSerializeArrayList( customSerializeArrayList, out customerWork );

			if (customerWork == null) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			// 得意先オフライン情報識別子取得処理
			string identifier = GetOfflineDataIdentifier(customerWork.EnterpriseCode, customerWork.CustomerCode);

			if (identifier == "") return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			// 得意先ローカルインデックスKeyList設定
			string[] keys = new string[2];
			keys[0] = customerWork.EnterpriseCode;
			keys[1] = customerWork.CustomerCode.ToString();

			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

			return offlineDataSerializer.Serialize(identifier, keys, customSerializeArrayList);
		}

        // 2009.02.17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// オフラインデータ読込処理
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="customerCode">得意先コード</param>
        ///// <param name="customerInfo">得意先情報クラス</param>
        ///// <param name="sender">呼び出し元オブジェクト</param>
        ///// <returns>STATUS</returns>
        //public int ReadOfflineData(string enterpriseCode, int customerCode, out CustomerInfo customerInfo, object sender)
        /// <summary>
        /// オフラインデータ読込処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="isSettingName">名称設定区分(ture:設定あり false:設定無し)</param>
        /// <param name="customerInfo">得意先情報クラス</param>
        /// <param name="sender">呼び出し元オブジェクト</param>
        /// <returns></returns>
        public int ReadOfflineData(string enterpriseCode, int customerCode, bool isSettingName, out CustomerInfo customerInfo, object sender)
        // 2009.02.17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            CustomSerializeArrayList retCustomerArrayList;
			customerInfo = null;

			// オフラインデータ読込処理
			int status = this.ReadOfflineData(enterpriseCode, customerCode, out retCustomerArrayList, sender);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (object obj in retCustomerArrayList)
				{
					if (obj is CustomerWork)
					{
						CustomerWork customerWork = (CustomerWork)obj;

						// クラス内メンバコピー
						customerInfo = CustomerInfoAcs.CopyToCustomerInfoFromCustomerWork(customerWork);

                        // 2009.02.17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //// 各マスタ名称設定
                        //ReflectDisplayName(ref customerInfo);

                        //// 表示名称設定処理
                        //this.SetDspName(ref customerInfo);
                        if (isSettingName)
                        {
                            // 各マスタ名称設定
                            ReflectDisplayName(ref customerInfo);

                            // 表示名称設定処理
                            this.SetDspName(ref customerInfo);
                        }
                        // 2009.02.17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
				}
			}

			return status;
		}

		/// <summary>
		/// オフラインデータ読込処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="customSerializeArrayList">カスタムシリアライズArrayList</param>
		/// <param name="sender">呼び出し元オブジェクト</param>
		/// <returns>STATUS</returns>
		public int ReadOfflineData(string enterpriseCode, int customerCode, out CustomSerializeArrayList customSerializeArrayList, object sender)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			customSerializeArrayList = null;

			// 得意先オフライン情報識別子取得処理
			string identifier = GetOfflineDataIdentifier(enterpriseCode, customerCode);

			if (identifier == "") return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			// 得意先ローカルインデックスKeyList設定
			string[] keys = new string[2];
			keys[0] = enterpriseCode;
			keys[1] = customerCode.ToString();

			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
			object retObject = offlineDataSerializer.DeSerialize(identifier, keys);

			customSerializeArrayList = retObject as CustomSerializeArrayList;

			if ((customSerializeArrayList == null) || (customSerializeArrayList.Count == 0))
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			else
			{
				CustomerWork customerWork;
                this.DivisionCustomSerializeArrayList( customSerializeArrayList, out customerWork );

				if (customerWork == null)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
				else
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}

			return status;
		}

		/// <summary>
		/// オフラインデータ削除処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="sender">呼び出し元オブジェクト</param>
		/// <returns>STATUS</returns>
		public int DeleteOfflineData(string enterpriseCode, int customerCode, object sender)
		{
            // 得意先オフライン情報識別子取得処理
			string identifier = GetOfflineDataIdentifier(enterpriseCode, customerCode);

			if (identifier == "") return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			// 得意先ローカルインデックスKeyList設定
			string[] keys = new string[2];
			keys[0] = enterpriseCode;
			keys[1] = customerCode.ToString();

			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
			return offlineDataSerializer.Delete(identifier, keys);
		}

		/// <summary>
		/// 得意先オフライン情報識別子取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先管理番号</param>
		/// <returns>得意先オフライン情報識別子</returns>
		public static string GetOfflineDataIdentifier(string enterpriseCode, int customerCode)
		{
            if ((enterpriseCode == "") || (customerCode == 0))
			{
				return string.Empty;
			}

			return OFFLINE_DATA_IDENTIFIER + enterpriseCode + "-" + customerCode;
		}

		/// <summary>
		/// CustomSerializeArrayList分割処理
		/// </summary>
		/// <param name="paraList">カスタムシリアライズリスト</param>
		/// <param name="customerWork">得意先マスタワーククラス配列</param>
		private void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out CustomerWork customerWork)
		{
			customerWork = null;

			for (int i = 0; i < paraList.Count; i++)
			{
				if (paraList[i] is CustomerWork)
				{
					customerWork = (CustomerWork)paraList[i];
				}
			}
		}
		# endregion

		// ===================================================================================== //
		// その他 パブリックメソッド
		// ===================================================================================== //
		# region 得意先クラス未入力データチェック処理
		/// <summary>
		/// 得意先クラス未入力データチェック処理
		/// </summary>
		/// <param name="customerInfo">得意先情報クラス</param>
		/// <param name="messageList">メッセージリスト</param>
		/// <param name="itemList">アイテムリスト</param>
		/// <returns>true:チェックＯＫ false:チェックＮＧ</returns>
		public bool CustomerInputDataCheck(CustomerInfo customerInfo, out ArrayList messageList, out ArrayList itemList)
		{
            messageList = new ArrayList();
			itemList = new ArrayList();

            if ( customerInfo.CustomerCode == 0 )
            {
                messageList.Add( "得意先コード" );
                itemList.Add( "CustomerCode" );
            }
            // DEL 2009/06/26 ------>>>
            //if (customerInfo.Name.Trim() == "")
            //{
            //    messageList.Add("得意先名");
            //    itemList.Add("Name");
            //}
            // DEL 2009/06/26 ------<<<
            
            // 納入先でない場合チェックする項目
            if ( !customerInfo.IsReceiver )
            {
                // DEL 2009/06/26 ------>>>
                //if ( customerInfo.CustomerSnm.Trim() == "" )
                //{
                //    messageList.Add( "得意先略称" );
                //    itemList.Add( "CustomerSnm" );
                //}
                // DEL 2009/06/26 ------<<<
                if (customerInfo.Kana.Trim() == "")
                {
                    messageList.Add( "得意先(ｶﾅ)" );
                    itemList.Add( "Kana" );
                }
                if ( customerInfo.MngSectionCode == "" )
                {
                    messageList.Add( "管理拠点" );
                    itemList.Add( "MngSectionCode" );
                }
                // ADD 2008/12/02 不具合対応[8548] ---------->>>>>
                if (customerInfo.MngSectionCode != "" &&
                    customerInfo.MngSectionName.Trim() == "")
                {
                    messageList.Add("管理拠点");
                    itemList.Add("MngSectionCode");
                }
                // ADD 2008/12/02 不具合対応[8548] ----------<<<<<

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
                //if ( customerInfo.CustomerAgentCd.TrimEnd() == string.Empty )
                //{
                //    messageList.Add( "得意先担当" );
                //    itemList.Add( "CustomerAgentNm" );
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
                if ( customerInfo.ClaimSectionCode == "" )
                {
                    messageList.Add( "請求拠点" );
                    itemList.Add( "ClaimSectionCode" );
                }

                // ADD 2008/12/02 不具合対応[8548] ---------->>>>>
                if (customerInfo.ClaimSectionCode != "" &&
                    customerInfo.ClaimSectionName.Trim() == "")
                {
                    messageList.Add("請求拠点");
                    itemList.Add("ClaimSectionCode");
                }
                // ADD 2008/12/02 不具合対応[8548] ----------<<<<<
                //if ( customerInfo.ClaimName.Trim() == "" )    // DEL 2009/06/26
                if (customerInfo.ClaimCode == 0)    // ADD 2009/06/26
                {
                    messageList.Add("請求先コード");
                    //itemList.Add( "ClaimName" );  // DEL 2009/06/26
                    itemList.Add("ClaimCode");  // ADD 2009/06/26
                }
                if ( customerInfo.TotalDay == 0 )
                {
                    messageList.Add( "締日" );
                    itemList.Add( "TotalDay" );
                }
                if ( customerInfo.CollectMoneyDay == 0 )
                {
                    messageList.Add( "集金日" );
                    itemList.Add( "CollectMoneyDay" );
                }
            }

			if (messageList.Count > 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// 得意先クラス未入力データチェック処理
		/// </summary>
		/// <param name="customerCodeCheck">得意先コードチェックフラグ</param>
		/// <param name="customerInfo">得意先情報クラス</param>
		/// <param name="messageList">メッセージリスト</param>
		/// <param name="itemList">アイテムリスト</param>
		/// <returns>true:チェックＯＫ false:チェックＮＧ</returns>
		public bool CustomerInputDataCheck(bool customerCodeCheck, CustomerInfo customerInfo, out ArrayList messageList, out ArrayList itemList)
		{
            messageList = new ArrayList();
			itemList = new ArrayList();

			if ((customerCodeCheck) && (customerInfo.CustomerCode == 0))
			{
				messageList.Add("得意先コード");
				itemList.Add("CustomerCode");

				ArrayList messageList2 = new ArrayList();
				ArrayList itemList2 = new ArrayList();

				this.CustomerInputDataCheck(customerInfo, out messageList2, out itemList2);

				foreach(string message in messageList2)
				{
					messageList.Add(message);
				}

				foreach(string item in itemList2)
				{
					itemList.Add(item);
				}
			}
			else
			{
				this.CustomerInputDataCheck(customerInfo, out messageList, out itemList);
			}

			if (messageList.Count > 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// 得意先マスタ存在チェック処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="logicalMode">論理削除区分</param>
		/// <returns>ステータス</returns>
		public int ExistData(string enterpriseCode, int customerCode, ConstantManagement.LogicalMode logicalMode)
		{
            if (_isLocalDBRead)
            {
                return this._customerInfoLcDB.ExistData(enterpriseCode, customerCode, logicalMode);
            }
            else
            {
                return this._iCustomerInfoDB.ExistData(enterpriseCode, customerCode, logicalMode);
            }
        }
		# endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 DEL
        //# region 得意先クラスデータ不正チェック処理
        ///// <summary>
        ///// 得意先クラスデータ不正チェック処理
        ///// </summary>
        ///// <param name="customerInfo">得意先情報クラス</param>
        ///// <param name="messageList">メッセージリスト</param>
        ///// <param name="itemList">アイテムリスト</param>
        ///// <returns>true:チェックＯＫ false:チェックＮＧ</returns>
        //public bool CustomerUnJustDataCheck(CustomerInfo customerInfo, out ArrayList messageList, out ArrayList itemList)
        //{
        //    messageList = new ArrayList();
        //    itemList = new ArrayList();

        //    if (customerInfo.TotalDay > 31)
        //    {
        //        messageList.Add("締日");
        //        itemList.Add("TotalDay");
        //    }

        //    if (customerInfo.CollectMoneyDay > 31)
        //    {
        //        messageList.Add("集金日");
        //        itemList.Add("CollectMoneyDay");
        //    }

        //    if ( customerInfo.NTimeCalcStDate > 31 )
        //    {
        //        messageList.Add( "次回勘定開始日" );
        //        itemList.Add( "NTimeCalcStDate" );
        //    }
        //    if (messageList.Count > 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        //# endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 DEL

		# region 得意先ワーククラス⇒得意先情報クラス
		/// <summary>
		/// クラスメンバーコピー処理（得意先ワーククラス⇒得意先情報クラス）
		/// </summary>
		/// <param name="customerWork">得意先ワーククラス</param>
		/// <returns>得意先情報クラス</returns>
		/// <remarks>
		/// <br>Note       : 得意先ワーククラスから得意先クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// <br>Update Note: 2010/08/10 caowj</br>
        /// <br>             得意先マスタ障害改良対応</br>
        /// <br>Update Note: 2021/05/10 梶谷貴士</br>
        /// <br>             得意先情報ガイド表示PKG対応</br>
        /// </remarks>
		public static CustomerInfo CopyToCustomerInfoFromCustomerWork(CustomerWork customerWork)
		{
			CustomerInfo customerInfo = new CustomerInfo();

            # region [メンバコピー（自動生成）]
            customerInfo.CreateDateTime = customerWork.CreateDateTime; // 作成日時
            customerInfo.UpdateDateTime = customerWork.UpdateDateTime; // 更新日時
            customerInfo.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
            customerInfo.FileHeaderGuid = customerWork.FileHeaderGuid; // GUID
            customerInfo.UpdEmployeeCode = customerWork.UpdEmployeeCode; // 更新従業員コード
            customerInfo.UpdAssemblyId1 = customerWork.UpdAssemblyId1; // 更新アセンブリID1
            customerInfo.UpdAssemblyId2 = customerWork.UpdAssemblyId2; // 更新アセンブリID2
            customerInfo.LogicalDeleteCode = customerWork.LogicalDeleteCode; // 論理削除区分
            customerInfo.CustomerCode = customerWork.CustomerCode; // 得意先コード
            customerInfo.CustomerSubCode = customerWork.CustomerSubCode; // 得意先サブコード
            customerInfo.Name = customerWork.Name; // 名称
            customerInfo.Name2 = customerWork.Name2; // 名称2
            customerInfo.HonorificTitle = customerWork.HonorificTitle; // 敬称
            customerInfo.Kana = customerWork.Kana; // カナ
            customerInfo.CustomerSnm = customerWork.CustomerSnm; // 得意先略称
            customerInfo.OutputNameCode = customerWork.OutputNameCode; // 諸口コード
            customerInfo.OutputName = customerWork.OutputName; // 諸口名称
            customerInfo.CorporateDivCode = customerWork.CorporateDivCode; // 個人・法人区分
            customerInfo.CustomerAttributeDiv = customerWork.CustomerAttributeDiv; // 得意先属性区分
            customerInfo.JobTypeCode = customerWork.JobTypeCode; // 職種コード
            customerInfo.BusinessTypeCode = customerWork.BusinessTypeCode; // 業種コード
            customerInfo.SalesAreaCode = customerWork.SalesAreaCode; // 販売エリアコード
            customerInfo.PostNo = customerWork.PostNo; // 郵便番号
            customerInfo.Address1 = customerWork.Address1; // 住所1（都道府県市区郡・町村・字）
            customerInfo.Address3 = customerWork.Address3; // 住所3（番地）
            customerInfo.Address4 = customerWork.Address4; // 住所4（アパート名称）
            customerInfo.HomeTelNo = customerWork.HomeTelNo; // 電話番号（自宅）
            customerInfo.OfficeTelNo = customerWork.OfficeTelNo; // 電話番号（勤務先）
            customerInfo.PortableTelNo = customerWork.PortableTelNo; // 電話番号（携帯）
            customerInfo.HomeFaxNo = customerWork.HomeFaxNo; // FAX番号（自宅）
            customerInfo.OfficeFaxNo = customerWork.OfficeFaxNo; // FAX番号（勤務先）
            customerInfo.OthersTelNo = customerWork.OthersTelNo; // 電話番号（その他）
            customerInfo.MainContactCode = customerWork.MainContactCode; // 主連絡先区分
            customerInfo.SearchTelNo = customerWork.SearchTelNo; // 電話番号（検索用下4桁）
            customerInfo.MngSectionCode = customerWork.MngSectionCode; // 管理拠点コード
            customerInfo.InpSectionCode = customerWork.InpSectionCode; // 入力拠点コード
            customerInfo.CustAnalysCode1 = customerWork.CustAnalysCode1; // 得意先分析コード1
            customerInfo.CustAnalysCode2 = customerWork.CustAnalysCode2; // 得意先分析コード2
            customerInfo.CustAnalysCode3 = customerWork.CustAnalysCode3; // 得意先分析コード3
            customerInfo.CustAnalysCode4 = customerWork.CustAnalysCode4; // 得意先分析コード4
            customerInfo.CustAnalysCode5 = customerWork.CustAnalysCode5; // 得意先分析コード5
            customerInfo.CustAnalysCode6 = customerWork.CustAnalysCode6; // 得意先分析コード6
            customerInfo.BillOutputCode = customerWork.BillOutputCode; // 請求書出力区分コード
            customerInfo.BillOutputName = customerWork.BillOutputName; // 請求書出力区分名称
            customerInfo.TotalDay = customerWork.TotalDay; // 締日
            customerInfo.CollectMoneyCode = customerWork.CollectMoneyCode; // 集金月区分コード
            customerInfo.CollectMoneyName = customerWork.CollectMoneyName; // 集金月区分名称
            customerInfo.CollectMoneyDay = customerWork.CollectMoneyDay; // 集金日
            customerInfo.CollectCond = customerWork.CollectCond; // 回収条件
            customerInfo.CollectSight = customerWork.CollectSight; // 回収サイト
            customerInfo.ClaimCode = customerWork.ClaimCode; // 請求先コード
            customerInfo.TransStopDate = customerWork.TransStopDate; // 取引中止日
            customerInfo.DmOutCode = customerWork.DmOutCode; // DM出力区分
            customerInfo.DmOutName = customerWork.DmOutName; // DM出力区分名称
            customerInfo.MainSendMailAddrCd = customerWork.MainSendMailAddrCd; // 主送信先メールアドレス区分
            customerInfo.MailAddrKindCode1 = customerWork.MailAddrKindCode1; // メールアドレス種別コード1
            customerInfo.MailAddrKindName1 = customerWork.MailAddrKindName1; // メールアドレス種別名称1
            customerInfo.MailAddress1 = customerWork.MailAddress1; // メールアドレス1
            customerInfo.MailSendCode1 = customerWork.MailSendCode1; // メール送信区分コード1
            customerInfo.MailSendName1 = customerWork.MailSendName1; // メール送信区分名称1
            customerInfo.MailAddrKindCode2 = customerWork.MailAddrKindCode2; // メールアドレス種別コード2
            customerInfo.MailAddrKindName2 = customerWork.MailAddrKindName2; // メールアドレス種別名称2
            customerInfo.MailAddress2 = customerWork.MailAddress2; // メールアドレス2
            customerInfo.MailSendCode2 = customerWork.MailSendCode2; // メール送信区分コード2
            customerInfo.MailSendName2 = customerWork.MailSendName2; // メール送信区分名称2
            customerInfo.CustomerAgentCd = customerWork.CustomerAgentCd; // 顧客担当従業員コード
            customerInfo.BillCollecterCd = customerWork.BillCollecterCd; // 集金担当従業員コード
            customerInfo.OldCustomerAgentCd = customerWork.OldCustomerAgentCd; // 旧顧客担当従業員コード
            customerInfo.CustAgentChgDate = customerWork.CustAgentChgDate; // 顧客担当変更日
            customerInfo.AcceptWholeSale = customerWork.AcceptWholeSale; // 業販先区分
            customerInfo.CreditMngCode = customerWork.CreditMngCode; // 与信管理区分
            customerInfo.DepoDelCode = customerWork.DepoDelCode; // 入金消込区分
            customerInfo.AccRecDivCd = customerWork.AccRecDivCd; // 売掛区分
            customerInfo.CustSlipNoMngCd = customerWork.CustSlipNoMngCd; // 相手伝票番号管理区分
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
            //customerInfo.PureCode = customerWork.PureCode; // 純正区分
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
            customerInfo.CustCTaXLayRefCd = customerWork.CustCTaXLayRefCd; // 得意先消費税転嫁方式参照区分
            customerInfo.ConsTaxLayMethod = customerWork.ConsTaxLayMethod; // 消費税転嫁方式
            customerInfo.TotalAmountDispWayCd = customerWork.TotalAmountDispWayCd; // 総額表示方法区分
            customerInfo.TotalAmntDspWayRef = customerWork.TotalAmntDspWayRef; // 総額表示方法参照区分
            customerInfo.AccountNoInfo1 = customerWork.AccountNoInfo1; // 銀行口座1
            customerInfo.AccountNoInfo2 = customerWork.AccountNoInfo2; // 銀行口座2
            customerInfo.AccountNoInfo3 = customerWork.AccountNoInfo3; // 銀行口座3
            customerInfo.SalesUnPrcFrcProcCd = customerWork.SalesUnPrcFrcProcCd; // 売上単価端数処理コード
            customerInfo.SalesMoneyFrcProcCd = customerWork.SalesMoneyFrcProcCd; // 売上金額端数処理コード
            customerInfo.SalesCnsTaxFrcProcCd = customerWork.SalesCnsTaxFrcProcCd; // 売上消費税端数処理コード
            customerInfo.CustomerSlipNoDiv = customerWork.CustomerSlipNoDiv; // 得意先伝票番号区分
            customerInfo.NTimeCalcStDate = customerWork.NTimeCalcStDate; // 次回勘定開始日
            customerInfo.CustomerAgent = customerWork.CustomerAgent; // 得意先担当者
            customerInfo.ClaimSectionCode = customerWork.ClaimSectionCode; // 請求拠点コード
            customerInfo.CarMngDivCd = customerWork.CarMngDivCd; // 車輌管理区分
            customerInfo.BillPartsNoPrtCd = customerWork.BillPartsNoPrtCd; // 品番印字区分(請求書)
            customerInfo.DeliPartsNoPrtCd = customerWork.DeliPartsNoPrtCd; // 品番印字区分(納品書）
            customerInfo.DefSalesSlipCd = customerWork.DefSalesSlipCd; // 伝票区分初期値
            customerInfo.LavorRateRank = customerWork.LavorRateRank; // 工賃レバレートランク
            customerInfo.SlipTtlPrn = customerWork.SlipTtlPrn; // 伝票タイトルパターン
            customerInfo.DepoBankCode = customerWork.DepoBankCode; // 入金銀行コード
            customerInfo.CustWarehouseCd = customerWork.CustWarehouseCd; // 得意先優先倉庫コード
            customerInfo.QrcodePrtCd = customerWork.QrcodePrtCd; // QRコード印刷
            customerInfo.DeliHonorificTtl = customerWork.DeliHonorificTtl; // 納品書敬称
            customerInfo.BillHonorificTtl = customerWork.BillHonorificTtl; // 請求書敬称
            customerInfo.EstmHonorificTtl = customerWork.EstmHonorificTtl; // 見積書敬称
            customerInfo.RectHonorificTtl = customerWork.RectHonorificTtl; // 領収書敬称
            customerInfo.DeliHonorTtlPrtDiv = customerWork.DeliHonorTtlPrtDiv; // 納品書敬称印字区分
            customerInfo.BillHonorTtlPrtDiv = customerWork.BillHonorTtlPrtDiv; // 請求書敬称印字区分
            customerInfo.EstmHonorTtlPrtDiv = customerWork.EstmHonorTtlPrtDiv; // 見積書敬称印字区分
            customerInfo.RectHonorTtlPrtDiv = customerWork.RectHonorTtlPrtDiv; // 領収書敬称印字区分
            customerInfo.Note1 = customerWork.Note1; // 備考1
            customerInfo.Note2 = customerWork.Note2; // 備考2
            customerInfo.Note3 = customerWork.Note3; // 備考3
            customerInfo.Note4 = customerWork.Note4; // 備考4
            customerInfo.Note5 = customerWork.Note5; // 備考5
            customerInfo.Note6 = customerWork.Note6; // 備考6
            customerInfo.Note7 = customerWork.Note7; // 備考7
            customerInfo.Note8 = customerWork.Note8; // 備考8
            customerInfo.Note9 = customerWork.Note9; // 備考9
            customerInfo.Note10 = customerWork.Note10; // 備考10
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            customerInfo.JobTypeName = customerWork.JobTypeName; // 職種名称
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            customerInfo.SalesAreaName = customerWork.SalesAreaName; // 販売エリア名称
            customerInfo.ClaimName = customerWork.ClaimName; // 請求先名称
            customerInfo.ClaimName2 = customerWork.ClaimName2; // 請求先名称２
            customerInfo.ClaimSnm = customerWork.ClaimSnm; // 請求先略称
            customerInfo.CustomerAgentNm = customerWork.CustomerAgentNm; // 顧客担当従業員名称
            customerInfo.OldCustomerAgentNm = customerWork.OldCustomerAgentNm; // 旧顧客担当従業員名称
            customerInfo.ClaimSectionName = customerWork.ClaimSectionName; // 請求拠点名称
            customerInfo.DepoBankName = customerWork.DepoBankName; // 入金銀行名称
            customerInfo.CustWarehouseName = customerWork.CustWarehouseName; // 得意先優先倉庫名称
            customerInfo.MngSectionName = customerWork.MngSectionName; // 管理拠点名称
            customerInfo.BusinessTypeName = customerWork.BusinessTypeName; // 業種名称

            // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------>>>>>
            customerInfo.SalesSlipPrtDiv = customerWork.SalesSlipPrtDiv;
            customerInfo.AcpOdrrSlipPrtDiv = customerWork.AcpOdrrSlipPrtDiv;
            customerInfo.ShipmSlipPrtDiv = customerWork.ShipmSlipPrtDiv;
            customerInfo.EstimatePrtDiv = customerWork.EstimatePrtDiv;
            customerInfo.UOESlipPrtDiv = customerWork.UOESlipPrtDiv;
            // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------<<<<<

            // ADD 2009/04/07 ------>>>
            customerInfo.ReceiptOutputCode = customerWork.ReceiptOutputCode; // 領収書出力区分コード
            // ADD 2009/04/07 ------<<<

            // ADD 2009/06/03 ------>>>
            customerInfo.CustomerEpCode = customerWork.CustomerEpCode;      // 得意先企業コード
            customerInfo.CustomerSecCode = customerWork.CustomerSecCode;    // 得意先拠点コード
            // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
            customerInfo.SimplInqAcntAcntGrId = customerWork.SimplInqAcntAcntGrId;  // 簡単問合せアカウントグループID
            // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<
            customerInfo.OnlineKindDiv = customerWork.OnlineKindDiv;        // オンライン種別区分
            // ADD 2009/06/03 ------<<<
            // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
            customerInfo.TotalBillOutputDiv = customerWork.TotalBillOutputDiv;  // 合計請求書出力区分
            customerInfo.DetailBillOutputCode = customerWork.DetailBillOutputCode;  // 明細請求書出力区分
            customerInfo.SlipTtlBillOutputDiv = customerWork.SlipTtlBillOutputDiv;  // 伝票合計請求書出力区分
            // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
            // ADD 陳健 K2014/02/06 ---------------------------------->>>>>
            customerInfo.NoteInfo = customerWork.NoteInfo;  // メモ
            // ADD 陳健 K2014/02/06 ----------------------------------<<<<<
            // ADD 梶谷貴士 2021/05/10 ---------------------------------->>>>>
            customerInfo.DisplayDivCode = customerWork.DisplayDivCode;  //得意先情報ガイド表示区分
            // ADD 梶谷貴士 2021/05/10 ----------------------------------<<<<<
            # endregion

            return customerInfo;
		}
		# endregion

		# region 得意先クラス⇒得意先ワーククラス
		/// <summary>
		/// クラスメンバーコピー処理（得意先クラス⇒得意先ワーククラス）
		/// </summary>
		/// <param name="customerInfo">得意先ワーククラス</param>
		/// <returns>得意先クラス</returns>
		/// <remarks>
		/// <br>Note       : 得意先クラスから得意先ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// <br>Update Note: 2010/08/10 caowj</br>
        /// <br>             得意先マスタ障害改良対応</br>
        /// <br>Update Note: 2021/05/10 梶谷貴士</br>
        /// <br>             得意先情報ガイド表示PKG対応</br>
        /// </remarks>
		public static CustomerWork CopyToCustomerWorkFromCustomerInfo(CustomerInfo customerInfo)
		{
			CustomerWork customerWork = new CustomerWork();

            # region [メンバコピー（自動生成）]
            customerWork.CreateDateTime = customerInfo.CreateDateTime; // 作成日時
            customerWork.UpdateDateTime = customerInfo.UpdateDateTime; // 更新日時
            customerWork.EnterpriseCode = customerInfo.EnterpriseCode; // 企業コード
            customerWork.FileHeaderGuid = customerInfo.FileHeaderGuid; // GUID
            customerWork.UpdEmployeeCode = customerInfo.UpdEmployeeCode; // 更新従業員コード
            customerWork.UpdAssemblyId1 = customerInfo.UpdAssemblyId1; // 更新アセンブリID1
            customerWork.UpdAssemblyId2 = customerInfo.UpdAssemblyId2; // 更新アセンブリID2
            customerWork.LogicalDeleteCode = customerInfo.LogicalDeleteCode; // 論理削除区分
            customerWork.CustomerCode = customerInfo.CustomerCode; // 得意先コード
            customerWork.CustomerSubCode = customerInfo.CustomerSubCode; // 得意先サブコード
            customerWork.Name = customerInfo.Name; // 名称
            customerWork.Name2 = customerInfo.Name2; // 名称2
            customerWork.HonorificTitle = customerInfo.HonorificTitle; // 敬称
            customerWork.Kana = customerInfo.Kana; // カナ
            customerWork.CustomerSnm = customerInfo.CustomerSnm; // 得意先略称
            customerWork.OutputNameCode = customerInfo.OutputNameCode; // 諸口コード
            customerWork.OutputName = customerInfo.OutputName; // 諸口名称
            customerWork.CorporateDivCode = customerInfo.CorporateDivCode; // 個人・法人区分
            customerWork.CustomerAttributeDiv = customerInfo.CustomerAttributeDiv; // 得意先属性区分
            customerWork.JobTypeCode = customerInfo.JobTypeCode; // 職種コード
            customerWork.BusinessTypeCode = customerInfo.BusinessTypeCode; // 業種コード
            customerWork.SalesAreaCode = customerInfo.SalesAreaCode; // 販売エリアコード
            customerWork.PostNo = customerInfo.PostNo; // 郵便番号
            customerWork.Address1 = customerInfo.Address1; // 住所1（都道府県市区郡・町村・字）
            customerWork.Address3 = customerInfo.Address3; // 住所3（番地）
            customerWork.Address4 = customerInfo.Address4; // 住所4（アパート名称）
            customerWork.HomeTelNo = customerInfo.HomeTelNo; // 電話番号（自宅）
            customerWork.OfficeTelNo = customerInfo.OfficeTelNo; // 電話番号（勤務先）
            customerWork.PortableTelNo = customerInfo.PortableTelNo; // 電話番号（携帯）
            customerWork.HomeFaxNo = customerInfo.HomeFaxNo; // FAX番号（自宅）
            customerWork.OfficeFaxNo = customerInfo.OfficeFaxNo; // FAX番号（勤務先）
            customerWork.OthersTelNo = customerInfo.OthersTelNo; // 電話番号（その他）
            customerWork.MainContactCode = customerInfo.MainContactCode; // 主連絡先区分
            customerWork.SearchTelNo = customerInfo.SearchTelNo; // 電話番号（検索用下4桁）
            customerWork.MngSectionCode = customerInfo.MngSectionCode; // 管理拠点コード
            customerWork.InpSectionCode = customerInfo.InpSectionCode; // 入力拠点コード
            customerWork.CustAnalysCode1 = customerInfo.CustAnalysCode1; // 得意先分析コード1
            customerWork.CustAnalysCode2 = customerInfo.CustAnalysCode2; // 得意先分析コード2
            customerWork.CustAnalysCode3 = customerInfo.CustAnalysCode3; // 得意先分析コード3
            customerWork.CustAnalysCode4 = customerInfo.CustAnalysCode4; // 得意先分析コード4
            customerWork.CustAnalysCode5 = customerInfo.CustAnalysCode5; // 得意先分析コード5
            customerWork.CustAnalysCode6 = customerInfo.CustAnalysCode6; // 得意先分析コード6
            customerWork.BillOutputCode = customerInfo.BillOutputCode; // 請求書出力区分コード
            customerWork.BillOutputName = customerInfo.BillOutputName; // 請求書出力区分名称
            customerWork.TotalDay = customerInfo.TotalDay; // 締日
            customerWork.CollectMoneyCode = customerInfo.CollectMoneyCode; // 集金月区分コード
            customerWork.CollectMoneyName = customerInfo.CollectMoneyName; // 集金月区分名称
            customerWork.CollectMoneyDay = customerInfo.CollectMoneyDay; // 集金日
            customerWork.CollectCond = customerInfo.CollectCond; // 回収条件
            customerWork.CollectSight = customerInfo.CollectSight; // 回収サイト
            customerWork.ClaimCode = customerInfo.ClaimCode; // 請求先コード
            customerWork.TransStopDate = customerInfo.TransStopDate; // 取引中止日
            customerWork.DmOutCode = customerInfo.DmOutCode; // DM出力区分
            customerWork.DmOutName = customerInfo.DmOutName; // DM出力区分名称
            customerWork.MainSendMailAddrCd = customerInfo.MainSendMailAddrCd; // 主送信先メールアドレス区分
            customerWork.MailAddrKindCode1 = customerInfo.MailAddrKindCode1; // メールアドレス種別コード1
            customerWork.MailAddrKindName1 = customerInfo.MailAddrKindName1; // メールアドレス種別名称1
            customerWork.MailAddress1 = customerInfo.MailAddress1; // メールアドレス1
            customerWork.MailSendCode1 = customerInfo.MailSendCode1; // メール送信区分コード1
            customerWork.MailSendName1 = customerInfo.MailSendName1; // メール送信区分名称1
            customerWork.MailAddrKindCode2 = customerInfo.MailAddrKindCode2; // メールアドレス種別コード2
            customerWork.MailAddrKindName2 = customerInfo.MailAddrKindName2; // メールアドレス種別名称2
            customerWork.MailAddress2 = customerInfo.MailAddress2; // メールアドレス2
            customerWork.MailSendCode2 = customerInfo.MailSendCode2; // メール送信区分コード2
            customerWork.MailSendName2 = customerInfo.MailSendName2; // メール送信区分名称2
            customerWork.CustomerAgentCd = customerInfo.CustomerAgentCd; // 顧客担当従業員コード
            customerWork.BillCollecterCd = customerInfo.BillCollecterCd; // 集金担当従業員コード
            customerWork.OldCustomerAgentCd = customerInfo.OldCustomerAgentCd; // 旧顧客担当従業員コード
            customerWork.CustAgentChgDate = customerInfo.CustAgentChgDate; // 顧客担当変更日
            customerWork.AcceptWholeSale = customerInfo.AcceptWholeSale; // 業販先区分
            customerWork.CreditMngCode = customerInfo.CreditMngCode; // 与信管理区分
            customerWork.DepoDelCode = customerInfo.DepoDelCode; // 入金消込区分
            customerWork.AccRecDivCd = customerInfo.AccRecDivCd; // 売掛区分
            customerWork.CustSlipNoMngCd = customerInfo.CustSlipNoMngCd; // 相手伝票番号管理区分
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
            //customerWork.PureCode = customerInfo.PureCode; // 純正区分
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
            customerWork.CustCTaXLayRefCd = customerInfo.CustCTaXLayRefCd; // 得意先消費税転嫁方式参照区分
            customerWork.ConsTaxLayMethod = customerInfo.ConsTaxLayMethod; // 消費税転嫁方式
            customerWork.TotalAmountDispWayCd = customerInfo.TotalAmountDispWayCd; // 総額表示方法区分
            customerWork.TotalAmntDspWayRef = customerInfo.TotalAmntDspWayRef; // 総額表示方法参照区分
            customerWork.AccountNoInfo1 = customerInfo.AccountNoInfo1; // 銀行口座1
            customerWork.AccountNoInfo2 = customerInfo.AccountNoInfo2; // 銀行口座2
            customerWork.AccountNoInfo3 = customerInfo.AccountNoInfo3; // 銀行口座3
            customerWork.SalesUnPrcFrcProcCd = customerInfo.SalesUnPrcFrcProcCd; // 売上単価端数処理コード
            customerWork.SalesMoneyFrcProcCd = customerInfo.SalesMoneyFrcProcCd; // 売上金額端数処理コード
            customerWork.SalesCnsTaxFrcProcCd = customerInfo.SalesCnsTaxFrcProcCd; // 売上消費税端数処理コード
            customerWork.CustomerSlipNoDiv = customerInfo.CustomerSlipNoDiv; // 得意先伝票番号区分
            customerWork.NTimeCalcStDate = customerInfo.NTimeCalcStDate; // 次回勘定開始日
            customerWork.CustomerAgent = customerInfo.CustomerAgent; // 得意先担当者
            customerWork.ClaimSectionCode = customerInfo.ClaimSectionCode; // 請求拠点コード
            customerWork.CarMngDivCd = customerInfo.CarMngDivCd; // 車輌管理区分
            customerWork.BillPartsNoPrtCd = customerInfo.BillPartsNoPrtCd; // 品番印字区分(請求書)
            customerWork.DeliPartsNoPrtCd = customerInfo.DeliPartsNoPrtCd; // 品番印字区分(納品書）
            customerWork.DefSalesSlipCd = customerInfo.DefSalesSlipCd; // 伝票区分初期値
            customerWork.LavorRateRank = customerInfo.LavorRateRank; // 工賃レバレートランク
            customerWork.SlipTtlPrn = customerInfo.SlipTtlPrn; // 伝票タイトルパターン
            customerWork.DepoBankCode = customerInfo.DepoBankCode; // 入金銀行コード
            customerWork.CustWarehouseCd = customerInfo.CustWarehouseCd; // 得意先優先倉庫コード
            customerWork.QrcodePrtCd = customerInfo.QrcodePrtCd; // QRコード印刷
            customerWork.DeliHonorificTtl = customerInfo.DeliHonorificTtl; // 納品書敬称
            customerWork.BillHonorificTtl = customerInfo.BillHonorificTtl; // 請求書敬称
            customerWork.EstmHonorificTtl = customerInfo.EstmHonorificTtl; // 見積書敬称
            customerWork.RectHonorificTtl = customerInfo.RectHonorificTtl; // 領収書敬称
            customerWork.DeliHonorTtlPrtDiv = customerInfo.DeliHonorTtlPrtDiv; // 納品書敬称印字区分
            customerWork.BillHonorTtlPrtDiv = customerInfo.BillHonorTtlPrtDiv; // 請求書敬称印字区分
            customerWork.EstmHonorTtlPrtDiv = customerInfo.EstmHonorTtlPrtDiv; // 見積書敬称印字区分
            customerWork.RectHonorTtlPrtDiv = customerInfo.RectHonorTtlPrtDiv; // 領収書敬称印字区分
            customerWork.Note1 = customerInfo.Note1; // 備考1
            customerWork.Note2 = customerInfo.Note2; // 備考2
            customerWork.Note3 = customerInfo.Note3; // 備考3
            customerWork.Note4 = customerInfo.Note4; // 備考4
            customerWork.Note5 = customerInfo.Note5; // 備考5
            customerWork.Note6 = customerInfo.Note6; // 備考6
            customerWork.Note7 = customerInfo.Note7; // 備考7
            customerWork.Note8 = customerInfo.Note8; // 備考8
            customerWork.Note9 = customerInfo.Note9; // 備考9
            customerWork.Note10 = customerInfo.Note10; // 備考10
            // --- ADD 2010/08/10 ------------------------------------>>>>>
            customerWork.JobTypeName = customerInfo.JobTypeName; // 職種名称
            // --- ADD 2010/08/10 ------------------------------------<<<<<
            customerWork.SalesAreaName = customerInfo.SalesAreaName; // 販売エリア名称
            customerWork.ClaimName = customerInfo.ClaimName; // 請求先名称
            customerWork.ClaimName2 = customerInfo.ClaimName2; // 請求先名称２
            customerWork.ClaimSnm = customerInfo.ClaimSnm; // 請求先略称
            customerWork.CustomerAgentNm = customerInfo.CustomerAgentNm; // 顧客担当従業員名称
            customerWork.OldCustomerAgentNm = customerInfo.OldCustomerAgentNm; // 旧顧客担当従業員名称
            customerWork.ClaimSectionName = customerInfo.ClaimSectionName; // 請求拠点名称
            customerWork.DepoBankName = customerInfo.DepoBankName; // 入金銀行名称
            customerWork.CustWarehouseName = customerInfo.CustWarehouseName; // 得意先優先倉庫名称
            customerWork.MngSectionName = customerInfo.MngSectionName; // 管理拠点名称
            customerWork.BusinessTypeName = customerInfo.BusinessTypeName; // 業種名称

            // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------>>>>>
            customerWork.SalesSlipPrtDiv = customerInfo.SalesSlipPrtDiv;
            customerWork.AcpOdrrSlipPrtDiv = customerInfo.AcpOdrrSlipPrtDiv;
            customerWork.ShipmSlipPrtDiv = customerInfo.ShipmSlipPrtDiv;
            customerWork.EstimatePrtDiv = customerInfo.EstimatePrtDiv;
            customerWork.UOESlipPrtDiv = customerInfo.UOESlipPrtDiv;
            // --- ADD 2009/02/03 障害ID:9391対応------------------------------------------------------<<<<<

            // ADD 2009/04/07 ------>>>
            customerWork.ReceiptOutputCode = customerInfo.ReceiptOutputCode; // 領収書出力区分コード
            // ADD 2009/04/07 ------<<<

            // ADD 2009/06/03 ------>>>
            customerWork.CustomerEpCode = customerInfo.CustomerEpCode;      // 得意先企業コード
            // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ---------->>>>>
            customerWork.SimplInqAcntAcntGrId = customerInfo.SimplInqAcntAcntGrId;  // 簡単問合せアカウントグループID
            // ADD 2010/06/26 SCM：簡単問合せアカウントグループIDを追加 ----------<<<<<
            customerWork.CustomerSecCode = customerInfo.CustomerSecCode;    // 得意先拠点コード
            customerWork.OnlineKindDiv = customerInfo.OnlineKindDiv;        // オンライン種別区分
            // ADD 2009/06/03 ------<<<
            // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
            customerWork.TotalBillOutputDiv = customerInfo.TotalBillOutputDiv;  // 合計請求書出力区分
            customerWork.DetailBillOutputCode = customerInfo.DetailBillOutputCode;  // 明細請求書出力区分
            customerWork.SlipTtlBillOutputDiv = customerInfo.SlipTtlBillOutputDiv;  // 伝票合計請求書出力区分

            // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
            // ADD 梶谷貴士 2021/05/10 ----------------------------->>>>>
            customerWork.DisplayDivCode = customerInfo.DisplayDivCode;  // 得意先情報ガイド表示区分
            // ADD 梶谷貴士 2021/05/10 -----------------------------<<<<<
            // ADD 陳健 K2014/02/06 ----------------------------->>>>>
            customerWork.NoteInfo = customerInfo.NoteInfo;  // メモ
            // ADD 陳健 K2014/02/06 -----------------------------<<<<<
            # endregion

            return customerWork;
		}
		# endregion

		# region 全体項目表示名称マスタ取得処理
		/// <summary>
		/// 全体項目表示名称マスタ取得処理
		/// </summary>
		/// <param name="alItmDspNm">全体項目表示名称マスタ</param>
		/// <returns>ステータス</returns>
		public int GetAlItmDspNm(out AlItmDspNm alItmDspNm)
		{
			// 表示名称設定
			AlItmDspNmAcs alItmDspNmAcs = new AlItmDspNmAcs();
            int status = alItmDspNmAcs.ReadStatic(out alItmDspNm, this._enterpriseCode);

			if (alItmDspNm == null) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			return status;
		}
		# endregion

		# region 表示名称設定処理
		/// <summary>
		/// 表示名称設定処理
		/// </summary>
		/// <param name="customerInfo">得意先情報クラス</param>
		public void SetDspName(ref CustomerInfo customerInfo)
		{
			AlItmDspNm alItmDspNm;
			if (this.GetAlItmDspNm(out alItmDspNm) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				customerInfo.HomeTelNoDspName = alItmDspNm.HomeTelNoDspName;
				customerInfo.OfficeTelNoDspName = alItmDspNm.OfficeTelNoDspName;
				customerInfo.MobileTelNoDspName = alItmDspNm.MobileTelNoDspName;
				customerInfo.OtherTelNoDspName = alItmDspNm.OtherTelNoDspName;
				customerInfo.HomeFaxNoDspName = alItmDspNm.HomeFaxNoDspName;
				customerInfo.OfficeFaxNoDspName = alItmDspNm.OfficeFaxNoDspName;
			}
		}
		# endregion

        # region 金額端数処理区分取得処理
        /// <summary>
        /// 売上金額端数処理区分取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="fracProcMoneyDiv">0:売上単価,1:売上金額,2:売上消費税</param>
        /// <returns>端数処理区分</returns>
        public int GetSalesFractionProcCd ( string enterpriseCode, int customerCode, FracProcMoneyDiv fracProcMoneyDiv )
        {
            int fractionProcCd = 0;
            // -- ADD 2010/04/06 ---------------------------------->>>
            //パラメータが不正な場合は、得意先マスタの取得処理を行わない。
            if (string.IsNullOrEmpty(enterpriseCode) || customerCode == 0)
            {
                return fractionProcCd;
            }
            // -- ADD 2010/04/06 ---------------------------------->>>

            CustomerInfo customerInfo;
            int status = this.ReadStaticMemoryData(out customerInfo, enterpriseCode, customerCode);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/03 ADD
            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                status = this.ReadDBData( enterpriseCode, customerCode, out customerInfo );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/03 ADD

            if ( ( status == ( int ) ConstantManagement.DB_Status.ctDB_NORMAL ) && ( customerInfo != null ) && ( customerInfo.CustomerCode != 0 ) ) {
                switch ( fracProcMoneyDiv ) {
                    case FracProcMoneyDiv.UnPrcFrcProcCd :
                        fractionProcCd = customerInfo.SalesUnPrcFrcProcCd;
                        break;
                    case FracProcMoneyDiv.MoneyFrcProcCd :
                        fractionProcCd = customerInfo.SalesMoneyFrcProcCd;
                        break;
                    case FracProcMoneyDiv.CnsTaxFrcProcCd :
                        fractionProcCd = customerInfo.SalesCnsTaxFrcProcCd;
                        break;
                }
            }
            return fractionProcCd;
        }
        # endregion

        // --- ADD 2010/09/26 ---------->>>>>
        /// <summary>
        /// DBから得意先データを取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="cacheFlg">キャッシュフラグ[true:キャッシュする false:キャッシュしない]</param>
        /// <param name="isSettingName">名称設定区分(ture:設定あり false:設定無し)</param>
        /// <param name="customerInfoList">得意先情報リスト</param>
        /// <returns></returns>
        public int Search(string enterpriseCode, bool cacheFlg, bool isSettingName, out List<CustomerInfo> customerInfoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            customerInfoList = new List<CustomerInfo>();

            object retList = null;
            
            CustomerWork customerWorkPra = new CustomerWork();
            customerWorkPra.EnterpriseCode = enterpriseCode;

            object customerWorkObj = customerWorkPra;

            //得意先読み込み
            status = this._iCustomerInfoDB.Search(customerWorkObj, out retList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList list = retList as ArrayList;

                foreach (CustomerWork customerWork in list)
                {
                    // クラス内メンバコピー
                    CustomerInfo customerInfo = CustomerInfoAcs.CopyToCustomerInfoFromCustomerWork(customerWork);

                    int customerCode = customerInfo.CustomerCode;

                    if (isSettingName)
                    {
                        // 2010/10/28 Del >>>
                        //// 管理拠点名称取得
                        //SecInfoSet secInfoSet;
                        //SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                        //secInfoSetAcs.IsLocalDBRead = _isLocalDBRead;
                        //if (secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, customerInfo.MngSectionCode) == 0)
                        //{
                        //    customerInfo.MngSectionName = secInfoSet.SectionGuideNm;
                        //}
                        // 2010/10/28 Del <<<
                    }

                    // キー情報生成処理
                    string key = this.ConstructionKey(enterpriseCode, customerCode);

                    // すでに得意先情報がキャッシングされている場合は更新日の比較を行い、同一日時の場合は
                    // 再キャッシングは行わない
                    if ((_customerDictionary.ContainsKey(key)) && ((_customerDictionary[key]).UpdateDateTime == customerInfo.UpdateDateTime))
                    {
                        customerInfo = (_customerDictionary[key]).Clone();
                    }
                    else
                    {
                        if (cacheFlg)
                        {
                            // 得意先情報バッファ(MainMemory)格納用ハッシュテーブル追加処理
                            // 2010/10/28 >>>
                            //this.AddMainMemoryDictionary(customerInfo);
                            this.AddMainMemoryDictionary(customerInfo, false);
                            // 2010/10/28 <<<

                            // リアル更新にコピー⇒Undoバッファ
                            this.CopyStaticMemory(0, enterpriseCode, customerCode);
                        }
                    }

                    customerInfoList.Add(customerInfo);
                }
            }

            return status;
        }
        // --- ADD 2010/09/26 ----------<<<<<
	}
}
