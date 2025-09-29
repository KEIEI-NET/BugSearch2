using System;
using System.Collections;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections.Generic;

namespace Broadleaf.Application.Common
{

	/// <summary>
	/// OfferAddressInfoDBアクセスクラス。
	/// 非同期ロードを提供する
	/// </summary>
	/// <remarks>
	/// <br>Programmer : 23011　野口　暢朗</br>
	/// <br>Date       : 2005.05.28</br>
	/// <br></br>
	/// <br>Update Note: 2008.05.07 鈴木正臣</br>
    /// <br>             ①DC.NS向けNetAdvantageバージョンアップ対応</br>
    /// </remarks>
	public class OfferAddressInfoAcs : IMergeableAddressAcs
	{
		
		/// <summary>
		/// リモーティングアクセス用インターフェイス
		/// </summary>
		private static IOfferAddressInfo AddressInfo = null;
		
		
		private AddressGuideCacheManager cacheManager = null;
		
		/// <summary>
		/// staticコンストラクタ
		/// </summary>
		static OfferAddressInfoAcs()
		{
			OfferAddressInfoAcs.AddressInfo = MediationOfferAddressInfo.GetOfferAddressInfo();
		}
		
        /// <summary>
        /// コンストラクタ
        /// </summary>
		public OfferAddressInfoAcs()
		{
			cacheManager = new AddressGuideCacheManager();
		}
		
		/// <summary>
		/// オフラインデータの書き込み
		/// </summary>
		/// <param name="sender">object</param>
		/// <returns>STATUS</returns>
		public int WriteOfflineData(object sender)
		{
            return 0;
			//return AddressGuideCacheManager.WriteOfflineCache();
		}
		
		#region 非同期ロード用メソッド
		
        ////非同期ロード中かどうか
        //public bool NowLoading
        //{
        //    get
        //    {
        //        return this.cacheManager.NowLoading;
        //    }
        //}

		/// <summary>
		/// 非同期ロードに使うためのデリゲート
		/// </summary>
		private delegate bool AsyncLoadFromEnterpriseCode( string strEnterpriseCode );

        /// <summary>
        /// 全体初期表示設定をしようして非同期ロードするためのデリゲート
        /// </summary>
        /// <param name="addressCode1"></param>
        /// <param name="addressCode2"></param>
        /// <param name="addressCode3"></param>
        /// <returns></returns>
        private delegate bool AsyncLoadFromAllAddressCode(int addressCode1, int addressCode2, int addressCode3);
        

		/// <summary>
		/// 非同期処理用コーバックメソッド
		/// </summary>
		/// <param name="iAsyncResult"></param>
		private void AsyncLoadCallbackFromEnterpriseCode(IAsyncResult iAsyncResult)
		{
			AsyncLoadFromEnterpriseCode asyncState = (AsyncLoadFromEnterpriseCode)iAsyncResult.AsyncState;
			
			asyncState.EndInvoke(iAsyncResult);
		}

        /// <summary>
        /// 非同期処理用コーバックメソッド
        /// </summary>
        /// <param name="iAsyncResult"></param>
        private void AsyncLoadCallbackFromAddressCode(IAsyncResult iAsyncResult)
        {
            AsyncLoadFromAllAddressCode asyncState = (AsyncLoadFromAllAddressCode)iAsyncResult.AsyncState;

            asyncState.EndInvoke(iAsyncResult);
        }

        private bool LoadAreaGroupMasterInner(int addressCode1, int addressCode2, int addressCode3)
        {
            ArrayList alAddressWork = new ArrayList();

            try
            {

                //住所コードから住所連結コードを取得
                this.GetAddressWorkFromAddressCode(addressCode1, addressCode2, addressCode3, ref alAddressWork);

                if (alAddressWork == null
                    || alAddressWork.Count <= 0)
                {
                    return false;
                }

                cacheManager.LoadAreaGroupFromAreaCode(((AddressWork)alAddressWork[0]).AddrConnectCd1);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 全体初期データを設定して住所情報をロードする
        /// </summary>
        /// <param name="addressCode1"></param>
        /// <param name="addressCode2"></param>
        /// <param name="addressCode3"></param>
        /// <returns></returns>
        public bool LoadAreaGroupMaster(int addressCode1, int addressCode2, int addressCode3)
        {
            AsyncLoadFromAllAddressCode asyncLoad = new AsyncLoadFromAllAddressCode(this.LoadAreaGroupMasterInner);

            asyncLoad.BeginInvoke(addressCode1, addressCode2, addressCode3, new AsyncCallback(this.AsyncLoadCallbackFromAddressCode), asyncLoad);

            return true;
        }

        /// <summary>
        /// 住所をロードする
        /// </summary>
        public bool LoadAreaGroupMaster(string strEnterpriseCode)
        {
            //非同期ロード処理
            AsyncLoadFromEnterpriseCode asyncLoad = new AsyncLoadFromEnterpriseCode(this.LoadAreaGroupMasterInner);

            asyncLoad.BeginInvoke(strEnterpriseCode, new AsyncCallback(this.AsyncLoadCallbackFromEnterpriseCode), asyncLoad);
            return true;
        }

        /// <summary>
        /// 郵便番号に一致する住所を複数取得する
        /// </summary>
        /// <param name="postNoList"></param>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public int ReadAddress(string[] postNoList, out AddressWork[] resultList)
        {
            resultList = null;

            return this.cacheManager.ReadAddress(postNoList, out resultList);
        }

		#region ダウンロード完了通知対応

        /// <summary>
        /// 全体設定マスタから初期表示情報を読む
        /// </summary>
        /// <param name="strEnterpriseCode"></param>
        /// <param name="allDefSet"></param>
        /// <returns></returns>
        private int GetAllDefSet(string strEnterpriseCode, out AllDefSet allDefSet)
        {
            allDefSet = null;

            AllDefSetAcs allDefSetAcs;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                allDefSetAcs = new AllDefSetAcs();

                //throw new System.Exception("全体初期表示のデータとりにいこうとした");

                //status = allDefSetAcs.Read( out allDefSet, strEnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode );
                status = allDefSetAcs.Read(out allDefSet, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            }
            catch (Exception)
            {
                return -1;
            }

            return status;
        }

        /// <summary>
        /// 非同期で住所マスタをロードする
        /// 他の非同期ロード処理が行われている場合はロードに失敗する。
        /// </summary>
        /// <param name="strEnterpriseCode">企業コード</param>
        private bool LoadAreaGroupMasterInner(string strEnterpriseCode)
        {
			/*
            try
            {
                AllDefSet allDefSet = new AllDefSet();

                //指定の企業コードの情報に該当する住所マスタがなかった
                if (this.GetAllDefSet(strEnterpriseCode, out allDefSet) != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || allDefSet == null
                    || allDefSet.DefDispAddrCd1 <= 0)
                {
                    return false;
                }

                return LoadAreaGroupMasterInner(allDefSet.DefDispAddrCd1, allDefSet.DefDispAddrCd2, allDefSet.DefDispAddrCd3);
            }
            catch
            {
                return false;
            }
			*/
			return false;
        }

		//完了通知用イベント
		private EventHandler dlFinishCallBack = null;
		
		/// <summary>
		/// ダウンロード完了通知対応
		/// </summary>
		/// <param name="strEnterpriseCode"></param>
		/// <param name="dlFinishCallBack"></param>
		/// <returns></returns>
		public bool LoadAreaGroupMaster( string strEnterpriseCode, EventHandler dlFinishCallBack )
		{
			this.dlFinishCallBack = dlFinishCallBack;
			
			//非同期ロード処理
            AsyncLoadFromEnterpriseCode asyncLoad = new AsyncLoadFromEnterpriseCode(this.LoadAreaGroupMasterInner);
			
			asyncLoad.BeginInvoke( strEnterpriseCode, new AsyncCallback( this.DlFinishAsyncCallBack ), asyncLoad );
			return true;
		}
		
		/// <summary>
		/// 非同期コールバック関数
		/// </summary>
		/// <param name="iAsyncResult"></param>
		private void DlFinishAsyncCallBack( IAsyncResult iAsyncResult )
		{
			/*
			AsyncLoadFromEnterpriseCode asyncState = (AsyncLoadFromEnterpriseCode)iAsyncResult.AsyncState;
			
			asyncState.EndInvoke(iAsyncResult);
			
			OfflineDataDownloadEventArgs args = new OfflineDataDownloadEventArgs();
			
			//住所の管理コードは20001
			args.OfflineDataManageCode = 20001;
			
			//完了を通知
			this.dlFinishCallBack( this, args );
			*/
		}
		
		#endregion
		
		#endregion
		
		#region 住所マスタ読み込み関数
		
		/// <summary>
		/// 指定住所コードの住所を取得する
		/// 共通インターフェイスメソッド
		/// </summary>
		/// <param name="code1"></param>
		/// <param name="code2"></param>
		/// <param name="code3"></param>
		/// <param name="code4"></param>
		/// <param name="code5"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		public int GetAddressWork( int code1, long code2, int code3, int code4, int code5, out ArrayList alResult )
		{
			alResult = null;

			//パラメータ作成
			AddressWork awParam = new AddressWork();
			awParam.AddrConnectCd1 = code1;
			awParam.AddrConnectCd2 = (int)code2;
			awParam.AddrConnectCd3 = code3;
			awParam.AddrConnectCd4 = code4;
			awParam.AddrConnectCd5 = code5;
			
			int status = this.cacheManager.GetAddressWork( awParam, out alResult );

			return status;
		}
		
        /// <summary>
        /// 指定住所コードの住所を取得する
        /// 共通インターフェイスメソッド
        /// </summary>
        /// <param name="addrIndex"></param>
        /// <param name="alResult"></param>
        /// <returns></returns>
		public int GetAddressWork(AddressWork addrIndex, out ArrayList alResult)
		{
			alResult = null;
			int status = this.cacheManager.GetAddressWork( addrIndex, out alResult );
			
			return status;
		}
		
		/// <summary>
		/// 共通インターフェイスメソッド
		/// </summary>
		/// <param name="intAddrConnectCd1"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		public int GetAddrIndexWork2( int intAddrConnectCd1, out ArrayList alResult)
		{
			alResult = null;
			int status = this.cacheManager.GetAddrIndexWork2( intAddrConnectCd1, out alResult );
			
			return status;
		}
		
		/// <summary>
		/// 共通インターフェイスメソッド
		/// </summary>
		/// <param name="intAddrConnectCd1"></param>
		/// <param name="intAddrConnectCd2"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		public int GetAddrIndexWork3( int intAddrConnectCd1, long intAddrConnectCd2, out ArrayList alResult)
		{
			alResult = null;
			int status = this.cacheManager.GetAddrIndexWork3( intAddrConnectCd1, (int)intAddrConnectCd2, out alResult );

			return status;
		}
		
		/// <summary>
		/// 共通インターフェイスメソッド
		/// </summary>
		/// <param name="intAddrConnectCd1"></param>
		/// <param name="intAddrConnectCd2"></param>
		/// <param name="intAddrConnectCd3"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		public int GetAddrIndexWork4( int intAddrConnectCd1, long intAddrConnectCd2, int intAddrConnectCd3, out ArrayList alResult)
		{
			alResult = null;
			int status = this.cacheManager.GetAddrIndexWork4( intAddrConnectCd1, (int)intAddrConnectCd2, intAddrConnectCd3, out alResult );

			return status;
		}
		
		/// <summary>
		/// 共通インターフェイスメソッド
		/// </summary>
		/// <param name="intAddrConnectCd1"></param>
		/// <param name="intAddrConnectCd2"></param>
		/// <param name="intAddrConnectCd3"></param>
		/// <param name="intAddrConnectCd4"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		public int GetAddrIndexWork5( int intAddrConnectCd1, long intAddrConnectCd2, int intAddrConnectCd3, int intAddrConnectCd4, out ArrayList alResult)
		{
			alResult = null;
			int status = this.cacheManager.GetAddrIndexWork5( intAddrConnectCd1, (int)intAddrConnectCd2, intAddrConnectCd3, intAddrConnectCd4, out alResult );

			return status;
		}
		
		#endregion
				
		#region その他非キャッシュ処理関数
		
		#region 郵便番号検索メソッド
        /// <summary>
        /// 郵便番号検索メソッド
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="alResult"></param>
        /// <returns></returns>
        public int GetAddressWorkFromZipCd(string keyword, ref ArrayList alResult)
        {
            return this.cacheManager.GetAddressWorkFromZipCd( keyword, ref alResult );
        }
        /// <summary>
        /// 郵便番号検索メソッド
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="alResult"></param>
        /// <returns></returns>
		public int GetAddressWorkFromZipCd(string keyword, out ICollection alResult)
		{
            ArrayList result = null;

            int status = this.cacheManager.GetAddressWorkFromZipCd(keyword, ref result);

            alResult = result;

            return status;
		}
		
		#endregion
		
		#region キーワード検索メソッド
        /// <summary>
        /// キーワード検索メソッド
        /// </summary>
        /// <param name="areaGroupCode"></param>
        /// <param name="addrkey"></param>
        /// <param name="resultList"></param>
        /// <returns></returns>
		public int GetAddrFromName( int areaGroupCode, string addrkey, out ICollection resultList )
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            List<AddressWork> addressList = null;
            status = this.cacheManager.GetAddrFromName(areaGroupCode, addrkey, out addressList);

            resultList = addressList;

            return status;
		}
		
		#endregion
		/// <summary>
		/// 住所検索
		/// </summary>
		/// <param name="addressCode1"></param>
		/// <param name="addressCode2"></param>
		/// <param name="addressCode3"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		public int GetAddressWorkFromAddressCode(int addressCode1, int addressCode2, int addressCode3, ref ArrayList alResult)
		{
			return this.cacheManager.GetAddressWorkFromAddressCode( addressCode1, addressCode2, addressCode3, ref alResult );
		}
		
		#endregion
		
		#region その他インターフェイスメソッド
		
		/// <summary>
		/// 表示グリッド数を取得する
		/// </summary>
		public int DisplayGridCount
		{
			get
			{
				return 5;
			}
		}
		
		/// <summary>
		/// ステータスバー表示文字列を取得する
		/// </summary>
		public string StatusBarString
		{
			get
			{
				return "お探しの住所は見つかりましたか？\r\n市町村合併に伴い、お探しの住所が見つからない場合には別の住所情報ボタンをクリックしてください。\r\n別の住所情報にて、お探しの住所を検索します。　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　";
			}
		}
		
		#endregion

        /// <summary>
        /// 地区グループのスタティックメモリを設定する
        /// </summary>
        /// <param name="areaGroupList"></param>
        public void SetAreaGroupStaticMemory(ArrayList areaGroupList)
        {
            //他のクラスがInternalなのでここでやります。
            AddressInfoAreaGroupCacheAcs.SetAreaGroupStaticMemory(areaGroupList);
        }

	}
}
