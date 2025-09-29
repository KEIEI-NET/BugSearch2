using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// AddressGuideクラス。内部で住所ガイドのダイアログクラスを呼び出す。
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011　野口　暢朗</br>
	/// <br>Date       : 2005.05.28</br>
	/// <br></br>
	/// <br>Update Note: 2007.03.15 980076 妻鳥　謙一郎</br>
	/// <br>		   : 郵便番号ガイドが基準となるように変更</br>
	/// </remarks>
	public class AddressGuide
	{
        /// <summary>
        /// マージしたアクセスクラス
        /// </summary>
		private MergedAddressAcs mergedAddressAcs = null;
		
        /// <summary>
        /// 住所アクセスクラス
        /// </summary>
        private OfferAddressInfoAcs offerAddressInfoAcs = null;

        /// <summary>
        /// キャッシュの全体初期
        /// </summary>
        private static AllDefSet[] cacheAllDefSet = null;

        /// <summary>
		/// 非同期ロード可能か。
		/// SearchAddress()が呼ばれている間は非同期ロードできない
        /// AreaGroupを外部から取得できるように変更
		/// </summary>
		public AddressGuide()
		{
			this.mergedAddressAcs = new MergedAddressAcs();
			this.offerAddressInfoAcs = new OfferAddressInfoAcs();

            ////TODO : Debug
            //AreaGroupAcs acs = new AreaGroupAcs();
            //ArrayList list = null;

            //acs.SearchAll(out list, LoginInfoAcquisition.EnterpriseCode);

            //this.offerAddressInfoAcs.SetAreaGroupStaticMemory(list);
		}

        /// <summary>
        /// AreaGroup, AllDefSetを外部から取得できるように変更
        /// </summary>
        public AddressGuide(AreaGroup[] areaGroupList, AllDefSet[] allDefSet ) : this()
        {
            this.offerAddressInfoAcs.SetAreaGroupStaticMemory( new ArrayList( areaGroupList) );

            cacheAllDefSet = allDefSet;
        }

        #region 時代遅れのメソッド達

        /// <summary>
		/// 企業コードを指定して住所ガイド窓を開く
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="agResult">結果</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23011　野口　暢朗</br>
		/// <br>Date       : 2005.06.02</br>
		/// <br></br>
		/// <br>Update Note: </br>
		/// </remarks>
        [Obsolete("申し訳ありませんが public DialogResult ShowAddressGuide(out AddressGuideResult result) を使用してください。対応よろしくお願いします。野口", false)]
        public DialogResult SearchAddress(string enterpriseCode, ref AddressGuideResult agResult)
		{
            return this.ShowAddressGuide(out agResult);
		}

        /// <summary>
        /// 指定の住所コードをデフォルト位置にしてガイドをひらく
        /// </summary>
        /// <param name="addressCode1"></param>
        /// <param name="addressCode2"></param>
        /// <param name="addressCode3"></param>
        /// <param name="agResult"></param>
        /// <returns></returns>
        [Obsolete("申し訳ありませんが public DialogResult ShowAddressGuide(int addressCode1, int addressCode2, int addressCode3, out AddressGuideResult result) を使用してください。対応よろしくお願いします。野口", false)]
        public DialogResult SearchAddress(int addressCode1, int addressCode2, int addressCode3, ref AddressGuideResult agResult)
        {
            return ShowAddressGuide(addressCode1, addressCode2, addressCode3, out agResult);
        }

        /// <summary>
        /// 郵便番号を指定して住所を検索する
        /// </summary>
        /// <param name="strPostNo">郵便番号のキーワード</param>
        /// <param name="agResult">結果</param>
        /// <returns>DialogResult</returns>
        [Obsolete("申し訳ありませんが public DialogResult ShowPostNoSearchGuide(string postNoKeyword, out AddressGuideResult result) を使用してください。対応よろしくお願いします。野口", false)]
        public DialogResult SearchAddressFromPostNo(string strPostNo, ref AddressGuideResult agResult)
        {
            return this.ShowPostNoSearchGuide(strPostNo, out agResult);
        }

        /// <summary>
        /// 非同期ロード用関数
        /// </summary>
        /// <param name="strEnterpriseCode">企業コード</param>
        [Obsolete("申し訳ありませんが public void LoadAddress() を使用してください。対応よろしくお願いします。野口", false)]
        public void LoadAddress(string strEnterpriseCode)
        {
            this.LoadAddress();
        }

        #endregion

        private int GetAllDefSetFromCache(string sectionCode, out AllDefSet allDefSet)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            allDefSet = null;

            if (cacheAllDefSet == null)
            {
                return status;
            }

            for (int i = 0; i < cacheAllDefSet.Length; i++)
            {
                if (cacheAllDefSet[i].SectionCode == sectionCode)
                {
                    allDefSet = cacheAllDefSet[i];
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }

            return status;
        }

        /// <summary>
        /// 全体設定マスタから初期表示情報を読む
        /// </summary>
        /// <param name="strEnterpriseCode"></param>
        /// <param name="allDefSet"></param>
        /// <returns></returns>
        private int GetAllDefSetFromRemote(string strEnterpriseCode, out AllDefSet allDefSet)
        {
            allDefSet = null;

            AllDefSetAcs allDefSetAcs;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            allDefSetAcs = new AllDefSetAcs();
            //throw new System.Exception("全体初期表示のデータとりにいこうとした");

            //status = allDefSetAcs.Read( out allDefSet, strEnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode );
            status = allDefSetAcs.Read(out allDefSet, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

            return status;
        }

        /// <summary>
        /// 住所情報を取得する
        /// </summary>
        /// <param name="addressCode1"></param>
        /// <param name="addressCode2"></param>
        /// <param name="addressCode3"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private int GetAddressWork( int addressCode1, int addressCode2, int addressCode3, out AddressWork result )
        {
            result = null;
            ArrayList resultList = new ArrayList();

            int status = this.offerAddressInfoAcs.GetAddressWorkFromAddressCode(addressCode1, addressCode2, addressCode3, ref resultList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            if (resultList == null || resultList.Count <= 0)
            {
                return status;
            }

            result = resultList[0] as AddressWork;
            return status;
        }

        /// <summary>
        /// ガイド表示内部処理
        /// </summary>
        /// <param name="addressConnectCd1"></param>
        /// <param name="addressConnectCd2"></param>
        /// <param name="addressConnectCd3"></param>
        /// <param name="addressConnectCd4"></param>
        /// <param name="addressConnectCd5"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private DialogResult ShowAddressGuideInner(int addressConnectCd1, int addressConnectCd2, int addressConnectCd3, int addressConnectCd4, int addressConnectCd5, out AddressGuideResult result)
        {
            result = null;

            //デフォルト選択位置を指定して窓作成
            AddressGuideWindow agDialog = new AddressGuideWindow(addressConnectCd1,
                addressConnectCd2, addressConnectCd3, addressConnectCd4,
                addressConnectCd5);

            //OK以外が選択されたら
            if (agDialog.ShowDialog() != DialogResult.OK)
            {
                return DialogResult.Cancel;
            }

            AddressData addressWorkResult = agDialog.GetResult();

            //選択されていなかった場合
            if (addressWorkResult == null)
            {
                return DialogResult.Cancel;
            }

            result = new AddressGuideResult(addressWorkResult);

            return DialogResult.OK;
        }

        /// <summary>
        /// デフォルト表示を使用してガイドを開きます
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public DialogResult ShowAddressGuide(out AddressGuideResult result)
        {
			/* --- 2007.03.15 men del sta ---------------------------------- //
            AllDefSet allDefSet = null;

            //デフォルト選択位置を取得
            int status = 0;

            //まずはキャッシュからデータ取得
            status = GetAllDefSetFromCache(LoginInfoAcquisition.Employee.BelongSectionCode, out allDefSet);

            //キャッシュにデータが無ければ
            if( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ){
                status = this.GetAllDefSetFromRemote(LoginInfoAcquisition.EnterpriseCode, out allDefSet);
            }

            //全体初期が取れないならデフォルト表示
            if ( status != 0 || allDefSet == null)
            {
                return this.ShowAddressGuideInner(0, 0, 0, 0, 0, out result);
            }

            AddressWork defaultAddress = null;

            //全体初期の住所コードで住所を取得
            status = this.GetAddressWork(allDefSet.DefDispAddrCd1, allDefSet.DefDispAddrCd2, allDefSet.DefDispAddrCd3, out defaultAddress );

            //不正な住所コードならデフォルト表示
            if (status != 0 || defaultAddress == null)
            {
                return ShowAddressGuideInner(0, 0, 0, 0, 0, out result);
            }

            return ShowAddressGuideInner(defaultAddress.AddrConnectCd1, defaultAddress.AddrConnectCd2, defaultAddress.AddrConnectCd3, defaultAddress.AddrConnectCd4, defaultAddress.AddrConnectCd5, out result);
			// --- 2007.03.15 men del end ----------------------------------- */

			// --- 2007.03.15 men add sta ----------------------------------- //
			result = null;
			return DialogResult.Cancel;
			// --- 2007.03.15 men add end ----------------------------------- //
		}

        /// <summary>
        /// 住所コードを指定してガイドを表示します
        /// </summary>
        /// <param name="addressCode1"></param>
        /// <param name="addressCode2"></param>
        /// <param name="addressCode3"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public DialogResult ShowAddressGuide(int addressCode1, int addressCode2, int addressCode3, out AddressGuideResult result)
        {
			/* --- 2007.03.15 men del sta ---------------------------------- //
            int status;
            result = null;

            AddressWork defaultAddress = null;

            status = GetAddressWork(addressCode1, addressCode2, addressCode3, out defaultAddress);

            //不正な住所コードの場合
            if (status != 0 || defaultAddress == null)
            {
                //全体初期表示設定を取得
                AllDefSet allDefSet = null;

                //全体初期からデータ取得。キャッシュのデータがあるときはそれを使う
                status = GetAllDefSetFromCache(LoginInfoAcquisition.Employee.BelongSectionCode, out allDefSet);

                //キャッシュにデータが無い場合はリモートから取得
                if( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ){
                    status = GetAllDefSetFromRemote(LoginInfoAcquisition.EnterpriseCode, out allDefSet);
                }

                //それでも全体初期もとれなかったら
                if (allDefSet == null)
                {
                    return ShowAddressGuideInner(0, 0, 0, 0, 0, out result);
                }

                status = GetAddressWork(allDefSet.DefDispAddrCd1, allDefSet.DefDispAddrCd2, allDefSet.DefDispAddrCd3, out defaultAddress);

                //全体初期の住所がとれないならデフォルト表示
                if (status != 0 || defaultAddress == null)
                {
                    return ShowAddressGuideInner(0, 0, 0, 0, 0, out result);
                }

                return ShowAddressGuideInner(defaultAddress.AddrConnectCd1, defaultAddress.AddrConnectCd2, defaultAddress.AddrConnectCd3, defaultAddress.AddrConnectCd4, defaultAddress.AddrConnectCd5, out result);
            }
            else
            {
                return ShowAddressGuideInner(defaultAddress.AddrConnectCd1, defaultAddress.AddrConnectCd2, defaultAddress.AddrConnectCd3, defaultAddress.AddrConnectCd4, defaultAddress.AddrConnectCd5, out result);
            }
			// --- 2007.03.15 men del end ----------------------------------- */

			// --- 2007.03.15 men add sta ----------------------------------- //
			result = null;					
			return DialogResult.Cancel;
			// --- 2007.03.15 men add end ----------------------------------- //
		}

        /// <summary>
        /// 郵便番号検索ガイドを表示する
        /// </summary>
        /// <param name="postNoKeyword"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public DialogResult ShowPostNoSearchGuide(string postNoKeyword, out AddressGuideResult result)
        {
            result = null;

            if (!LoginInfoAcquisition.OnlineFlag)
            {
                return DialogResult.Cancel;
            }

            //郵便番号検索ダイアログ作成
            PostCodeSearchWindow pcswDialog = new PostCodeSearchWindow(postNoKeyword, this.mergedAddressAcs);

            //確定がおされなかった時
            if (pcswDialog.ShowDialog() != DialogResult.OK)
            {
                return DialogResult.Cancel;
            }

            AddressData awTmp = pcswDialog.GetResult();

            //なにも選択されていなかった場合
            if (awTmp == null)
            {
                return DialogResult.Cancel;
            }

            result = new AddressGuideResult(awTmp);

            return DialogResult.OK;
        }

		/// <summary>
		/// 住所コードから情報を検索
		/// </summary>
		/// <param name="addressCode1">都道府県市区郡コード</param>
		/// <param name="addressCode2">町村コード</param>
		/// <param name="addressCode3">字コード</param>
		/// <param name="agResult">結果</param>
		/// <returns>DialogResult</returns>
		public DialogResult SearchAddressFromAddressCode(int addressCode1, int addressCode2, int addressCode3, ref AddressGuideResult agResult )
		{
			if( !LoginInfoAcquisition.OnlineFlag )
			{
				return DialogResult.Cancel;
			}
			
			ArrayList alResult = new ArrayList();
			
			//住所コードで検索
			if( this.offerAddressInfoAcs.GetAddressWorkFromAddressCode( addressCode1, addressCode2, addressCode3, ref alResult ) != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				return DialogResult.Cancel;
			}
			
			//住所コードに該当する住所マスタが一件もなかった場合
			if( alResult == null || alResult.Count <= 0 )
			{
				return DialogResult.Cancel;
			}
			
			//複数郵便番号があった場合の処理
			if( alResult.Count > 1 )
			{
				ArrayList alTmp = null;
				
				MergedAddressAcs.CreateData( alResult, out alTmp );
				PostNoSelectWindow posSelectWin = new PostNoSelectWindow( alTmp );
				
				//複数郵便番号選択窓がキャンセルされたら戻る
				if( posSelectWin.ShowDialog() != DialogResult.OK )
				{
					return DialogResult.Cancel;
				}
				
				AddressData adResult = posSelectWin.GetResult();
				
				//結果が無いなら戻る
				if( adResult == null )
				{
					return DialogResult.Cancel;
				}
				
				agResult.AddressCode1Lower = adResult.AddressCode1Lower;
				agResult.AddressCode1Upper = adResult.AddressCode1Upper;
				agResult.AddressCode2 = adResult.AddressCode2;
				agResult.AddressCode3 = adResult.AddressCode3;
				agResult.AddressName = adResult.AddressName;
				agResult.PostNo = adResult.PostNo;
			}
			else
			{
				agResult.AddressCode1Lower = ((AddressWork)alResult[0]).AddressCode1Lower;
				agResult.AddressCode1Upper = ((AddressWork)alResult[0]).AddressCode1Upper;
				agResult.AddressCode2 = ((AddressWork)alResult[0]).AddressCode2;
				agResult.AddressCode3 = ((AddressWork)alResult[0]).AddressCode3;
				agResult.AddressName = ((AddressWork)alResult[0]).AddressName;
				agResult.PostNo = ((AddressWork)alResult[0]).PostNo;
			}
			
			return DialogResult.OK;
		}

        /// <summary>
        /// 住所情報をロードする
        /// </summary>
        public void LoadAddress()
        {
			/* --- 2007.03.15 men del sta ----------------------------------- //
			//if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    return;
            //}

            AllDefSet allDefSet = null;
            int status = 0;

            //まずはキャッシュから取る
            status = GetAllDefSetFromCache(LoginInfoAcquisition.Employee.BelongSectionCode, out allDefSet );

            //取れなかったらリモート
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = GetAllDefSetFromRemote(LoginInfoAcquisition.EnterpriseCode, out allDefSet);
            }

            //データが無い場合は空のデータで
            if ( status != 0 || allDefSet == null)
            {
                allDefSet = new AllDefSet();
            }

            this.offerAddressInfoAcs.LoadAreaGroupMaster(allDefSet.DefDispAddrCd1, allDefSet.DefDispAddrCd2, allDefSet.DefDispAddrCd3);
			// --- 2007.03.15 men del end ----------------------------------- */

		}

	}
	
	/// <summary>
	/// AddressGuideの処理結果格納用パラメータクラス
	/// </summary>
	public class AddressGuideResult
	{
        /// <summary>
        /// コンストラクタ
        /// </summary>
		public AddressGuideResult()
		{
			this.Clear();
		}
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="aw"></param>
		public AddressGuideResult( AddressData aw )
		{
			this._AddressCode1Lower = aw.AddressCode1Lower;
			this._AddressCode1Upper = aw.AddressCode1Upper;
			this._AddressCode2 = aw.AddressCode2;
			this._AddressCode3 = aw.AddressCode3;
			this._AddressName = aw.AddressName;
			this._PostNo = aw.PostNo;
		}
		/// <summary>
		/// クリア
		/// </summary>
		public void Clear()
		{
			this._AddressCode1Lower = 0;
			this._AddressCode1Upper = 0;
			this._AddressCode2 = 0;
			this._AddressCode3 = 0;
			this._AddressName = "";
			this._PostNo = "";
		}
		
		#region フィールド
		
		private string _PostNo;

		private int _AddressCode1Upper;

		private int _AddressCode1Lower;

		private int _AddressCode2;

		private int _AddressCode3;

		private string _AddressName;

		#endregion
		
		#region プロパティ
        /// <summary>
        /// 郵便番号
        /// </summary>
		public string PostNo
		{
			get
			{
				return this._PostNo;
			}
			set
			{
				this._PostNo = value;
			}
		}
		/// <summary>
        /// AddressCode1
		/// </summary>
		public int AddressCode1
		{
			get
			{
				return int.Parse( String.Format("{0:D2}{1:D3}", this.AddressCode1Upper, this.AddressCode1Lower ) );
			}
		}
		/// <summary>
        /// AddressCode1
		/// </summary>
		public int AddressCode1Upper
		{
			get
			{
				return this._AddressCode1Upper;
			}
			set
			{
				this._AddressCode1Upper = value;
			}
		}
        /// <summary>
        /// AddressCode1
        /// </summary>
		public int AddressCode1Lower
		{
			get
			{
				return this._AddressCode1Lower;
			}
			set
			{
				this._AddressCode1Lower = value;
			}
		}
        /// <summary>
        /// AddressCode2
        /// </summary>
		public int AddressCode2
		{
			get
			{
				return this._AddressCode2;
			}
			set
			{
				this._AddressCode2 = value;
			}
		}
		/// <summary>
        /// AddressCode3
		/// </summary>
		public int AddressCode3
		{
			get
			{
				return this._AddressCode3;
			}
			set
			{
				this._AddressCode3 = value;
			}
		}
		/// <summary>
        /// AddressName
		/// </summary>
		public string AddressName
		{
			get
			{
				return this._AddressName;
			}
			set
			{
				this._AddressName = value;
			}
		}
		
		#endregion
		
	}
	

}
