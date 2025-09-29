using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Controller;
using System.Collections;
using Broadleaf.Application.UIData;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Broadleaf.Library.Data;
using System.IO;
using System.Xml.Serialization;
using System.Text;

using Broadleaf.Library.Resources;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using Broadleaf.Library.Collections;
using System.Threading;

namespace Broadleaf.Application.Common
{
	
	/// <summary>
	/// キャッシュとオンラインオフライン状態を管理するクラス
    /// スレッドセーフ
	/// </summary>
	/// <remarks>
	/// <br>Programmer : 23011　野口　暢朗</br>
	/// <br>Date       : 2005.06.03</br>
	/// <br></br>
	/// <br>Update Note: 2006.12.04 23011 スレッドセーフ対応</br>
	/// </remarks>
	internal class AddressGuideCacheManager
	{
		/// <summary>
		/// リモーティングアクセス用インターフェイス
		/// </summary>
		private static IOfferAddressInfo AddressInfo = null;
		
		/// <summary>
		/// 住所マスタのキャッシュを入れるためのHashtable
		/// 住所連結コード１をインデックスにしてそれに対応する
		/// 情報を持ったArrayListが入ってる
		/// </summary>
		private static Hashtable htAddressMasterCache = null;
		
        /// <summary>
        /// 読書きのロック
        /// </summary>
        private static ReaderWriterLock _readerWriterLock = null;

		/// <summary>
		/// staticコンストラクタ
		/// </summary>
		static AddressGuideCacheManager()
		{
			//住所リモートオブジェクトを取得
			AddressGuideCacheManager.AddressInfo = MediationOfferAddressInfo.GetOfferAddressInfo();
			
			//住所マスタのキャッシュ用ハッシュテーブル
			AddressGuideCacheManager.htAddressMasterCache = new Hashtable();

            //ロッククラスのインスタンス作成
            _readerWriterLock = new ReaderWriterLock();
		}

        /// <summary>
        /// 地区グループコードで住所データをロードする
        /// </summary>
        /// <param name="areaGroupCode"></param>
        public void LoadAreaGroupFromAreaGroupCode(int areaGroupCode)
        {
            List<int> findTargetAreaList = new List<int>();

            //管区指定の場合
            //コードが０でも対応可能
            List<AreaGroup> areaList = null;
            AddressInfoAreaGroupCacheAcs.GetAreaGroupPref(areaGroupCode, out areaList);

            for (int i = 0; i < areaList.Count; i++)
            {
                findTargetAreaList.Add(areaList[i].AreaCode);
            }

            long[] prefUpdateList = new long[findTargetAreaList.Count];

            for (int i = 0; i < findTargetAreaList.Count; i++)
            {
                AddressIndexManageAcs.GetLastUpdateTime(findTargetAreaList[i], out prefUpdateList[i]);
            }

            //全ての県をロードする
            for (int index = 0; index < findTargetAreaList.Count; index++)
            {
                LoadArea(findTargetAreaList[index], prefUpdateList[index]);
            }

        }

        /// <summary>
        /// 地区コード指定で同じ管区に所属する地区を全てロードする
        /// </summary>
        /// <param name="addrConnectCd1"></param>
        public void LoadAreaGroupFromAreaCode(int addrConnectCd1)
        {

            int areaGroupCode = 0;

            //不正な住所連結コードの場合
            if (addrConnectCd1 <= 0)
            {
                return;
            }

            //TODO : ここの処理を抜かすとおそくないかな？そうでもない？
            ////指定管区の住所データがキャッシュにある場合はなにもしない
            //if (AddressGuideCacheManager.htAddressMasterCache[addrConnectCd1] != null)
            //{
            //    return;
            //}

            //地区グループコードを取得
            if ((areaGroupCode = AddressInfoAreaGroupCacheAcs.GetAreaGroupCodeFromAreaCode(addrConnectCd1)) == 0)
            {
                return;
            }

            List<AreaGroup> alPref;

            //管区の県一覧を取得
            AddressInfoAreaGroupCacheAcs.GetAreaGroupPref(areaGroupCode, out alPref);

            //県のコード一覧を取得
            List<int> prefAddrConnectCd1List = new List<int>();

            foreach (AreaGroup pref in alPref)
            {
                prefAddrConnectCd1List.Add(pref.AreaCode);
            }

            //更新リスト取得
            long[] prefUpdateList = null;

            //ローカルリソースで高速化
            prefUpdateList = new long[prefAddrConnectCd1List.Count];

            for (int i = 0; i < prefAddrConnectCd1List.Count; i++)
            {
                AddressIndexManageAcs.GetLastUpdateTime(prefAddrConnectCd1List[i], out prefUpdateList[i]);
            }

            //すべての県をロードする
            for (int index = 0; index < prefAddrConnectCd1List.Count; index++)
            {
                LoadArea(prefAddrConnectCd1List[index], prefUpdateList[index]);
            }

        }

        /// <summary>
        /// 指定住所コードでキャッシュをロードする
        /// </summary>
        /// <param name="addressCode1"></param>
        public void LoadAreaFromAddressCode1(int addressCode1)
        {
            //指定キーワードの郵便番号が所属する可能性のある県情報を取得
            int[] prefAddrConnectCd1List = null;

            AddressIndexManageAcs.GetAddrConnectCd1(addressCode1, out prefAddrConnectCd1List);

            //更新リスト取得
            long[] prefUpdateList = null;

            //ローカルリソースで高速化
            prefUpdateList = new long[prefAddrConnectCd1List.Length];

            //更新日付取得
            for (int i = 0; i < prefAddrConnectCd1List.Length; i++)
            {
                AddressIndexManageAcs.GetLastUpdateTime(prefAddrConnectCd1List[i], out prefUpdateList[i]);
            }

            //全ての県をメモリにロードする
            for (int index = 0; index < prefAddrConnectCd1List.Length; index++)
            {
                LoadArea(prefAddrConnectCd1List[index], prefUpdateList[index]);
            }

        }

        /// <summary>
        /// 指定県のがある管区の住所マスタをすべてロードする。
        /// キャッシュがある場合はそれを使う
        /// </summary>
        /// <param name="postNo"></param>
        public void LoadAreaFromPostNo(string postNo)
        {
            //指定キーワードの郵便番号が所属する可能性のある県情報を取得
            int[] prefAddrConnectCd1List = null;

            AddressIndexManageAcs.GetAddrConnectCd1(postNo, out prefAddrConnectCd1List);

            //更新リスト取得
            long[] prefUpdateList = null;

            //ローカルリソースで高速化
            prefUpdateList = new long[prefAddrConnectCd1List.Length];

            //更新日付取得
            for (int i = 0; i < prefAddrConnectCd1List.Length; i++)
            {
                AddressIndexManageAcs.GetLastUpdateTime(prefAddrConnectCd1List[i], out prefUpdateList[i]);
            }

            //県をメモリにロードする
            for (int index = 0; index < prefAddrConnectCd1List.Length; index++)
            {
                LoadArea(prefAddrConnectCd1List[index], prefUpdateList[index]);
            }
        }

        /// <summary>
        /// 県を取得する
        /// サーバのデータ更新も確認する
        /// </summary>
        /// <param name="addressConnectCd1"></param>
        /// <param name="lastUpdate"></param>
        /// <returns></returns>
        private static void LoadArea(int addressConnectCd1, long lastUpdate)
        {
            object objMaster;
            ArrayList alMaster = null;
            AddressWork awIndex1 = new AddressWork();

            awIndex1.AddrConnectCd1 = addressConnectCd1;

            long cacheUpdate = 0;

            //書込みロック獲得
            _readerWriterLock.AcquireWriterLock(Timeout.Infinite);

            try
            {
                //既にロードされているならば戻る
                if (AddressGuideCacheManager.htAddressMasterCache.ContainsKey(addressConnectCd1))
                {
                    return;
                }

                //キャッシュの最終更新を取得する
                AddressInfoCacheAcs.GetCacheUpdateTime(addressConnectCd1, out cacheUpdate);

                if (LoginInfoAcquisition.OnlineFlag)
                {

                    //キャッシュの日付とサーバの更新日付を比較
                    if (lastUpdate > cacheUpdate
                        || cacheUpdate == 0)
                    {
                        //--キャッシュ更新--
                        int status;

                        if ((status = AddressGuideCacheManager.AddressInfo.SearchAddressWork(awIndex1, out objMaster)) == (int)ConstantManagement.DB_Status.ctDB_NORMAL && objMaster != null)
                        {
                            CustomSerializeArrayList customSerializeArrayList = objMaster as CustomSerializeArrayList;

                            if (customSerializeArrayList != null && customSerializeArrayList.Count > 0)
                            {
                                alMaster = customSerializeArrayList[0] as ArrayList;

                                if (alMaster != null)
                                {
                                    //AddressWork書き出し
                                    AddressInfoCacheAcs.SerializeAddressWork(addressConnectCd1, lastUpdate, alMaster);
                                }
                            }
                        }
                        //-----------------
                    }
                }

                //まだデータが取得できていなかったらキャッシュから取得
                if (alMaster == null || alMaster.Count <= 0)
                {
                    alMaster = AddressInfoCacheAcs.DeSerializeAddressWork(addressConnectCd1);
                }

                //データが取れたらメモリのキャッシュに追加
                if (alMaster != null)
                {
                    //県をキーにしてキャッシュをHashtableに保存
                    AddressGuideCacheManager.htAddressMasterCache.Add(addressConnectCd1, alMaster);
                }
            }
            finally
            {
                //書込みロック開放
                _readerWriterLock.ReleaseWriterLock();
            }

        }
		
		#region 住所マスタのキャッシュから指定AddressWorkを検索する関数
		
		/// <summary>
		/// 指定の住所連結コードに
		/// 該当する住所マスタの情報を取得する。
		/// </summary>
		/// <param name="addrIndex">住所情報</param>
		/// <param name="alResult">結果を入れるArrayList</param>
		public int GetAddressWork(AddressWork addrIndex, out ArrayList alResult)
		{
			alResult = new ArrayList();
			
			//住所連結コード１の指定がない場合は何もしない
			if( addrIndex.AddrConnectCd1 <= 0 )
			{
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			
			//該当する管区のデータをすべてロードする
			this.LoadAreaGroupFromAreaCode( addrIndex.AddrConnectCd1 );
			
            //読込ロック獲得
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);
            try
            {
                ArrayList alTarget = AddressGuideCacheManager.htAddressMasterCache[addrIndex.AddrConnectCd1] as ArrayList;

                if (alTarget == null)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                //少しでも速いようにこんな感じに書いてます

                //検索
                if (addrIndex.AddrConnectCd2 <= 0)
                {
                    //住所マスタ１ならOK
                    foreach (AddressWork aw in alTarget)
                    {
                        if ((aw.AddrConnectCd1 == addrIndex.AddrConnectCd1 && aw.AddrConnectCd1 > 0)
                            && aw.AddrConnectCd2 <= 0)
                        {
                            alResult.Add(aw);
                        }
                    }
                }
                else if (addrIndex.AddrConnectCd3 <= 0)
                {
                    foreach (AddressWork aw in alTarget)
                    {
                        if ((aw.AddrConnectCd1 == addrIndex.AddrConnectCd1 && aw.AddrConnectCd1 > 0)
                            && (aw.AddrConnectCd2 == addrIndex.AddrConnectCd2 && aw.AddrConnectCd2 > 0)
                            && aw.AddrConnectCd3 <= 0)
                        {
                            alResult.Add(aw);
                        }
                    }
                }
                else if (addrIndex.AddrConnectCd4 <= 0)
                {
                    foreach (AddressWork aw in alTarget)
                    {
                        if ((aw.AddrConnectCd1 == addrIndex.AddrConnectCd1 && aw.AddrConnectCd1 > 0)
                            && (aw.AddrConnectCd2 == addrIndex.AddrConnectCd2 && aw.AddrConnectCd2 > 0)
                            && (aw.AddrConnectCd3 == addrIndex.AddrConnectCd3 && aw.AddrConnectCd3 > 0)
                            && aw.AddrConnectCd4 <= 0)
                        {
                            alResult.Add(aw);
                        }
                    }
                }
                else if (addrIndex.AddrConnectCd5 <= 0)
                {
                    foreach (AddressWork aw in alTarget)
                    {
                        if ((aw.AddrConnectCd1 == addrIndex.AddrConnectCd1 && aw.AddrConnectCd1 > 0)
                            && (aw.AddrConnectCd2 == addrIndex.AddrConnectCd2 && aw.AddrConnectCd2 > 0)
                            && (aw.AddrConnectCd3 == addrIndex.AddrConnectCd3 && aw.AddrConnectCd3 > 0)
                            && (aw.AddrConnectCd4 == addrIndex.AddrConnectCd4 && aw.AddrConnectCd4 > 0)
                            && aw.AddrConnectCd5 <= 0)
                        {
                            alResult.Add(aw);
                        }
                    }
                }
                else
                {
                    foreach (AddressWork aw in alTarget)
                    {
                        if ((aw.AddrConnectCd1 == addrIndex.AddrConnectCd1 && aw.AddrConnectCd1 > 0)
                            && (aw.AddrConnectCd2 == addrIndex.AddrConnectCd2 && aw.AddrConnectCd2 > 0)
                            && (aw.AddrConnectCd3 == addrIndex.AddrConnectCd3 && aw.AddrConnectCd3 > 0)
                            && (aw.AddrConnectCd4 == addrIndex.AddrConnectCd4 && aw.AddrConnectCd4 > 0)
                            && (aw.AddrConnectCd5 == addrIndex.AddrConnectCd5 && aw.AddrConnectCd5 > 0))
                        {
                            alResult.Add(aw);
                        }
                    }
                }
            }
            finally
            {
                //読込ロック開放
                _readerWriterLock.ReleaseReaderLock();
            }

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		
		
		/// <summary>
		/// 該当する住所インデックスマスタ2の情報を取得する
		/// </summary>
        /// <param name="intAddrConnectCd1"></param>
        /// <param name="alResult"></param>
		public int GetAddrIndexWork2( int intAddrConnectCd1, out ArrayList alResult)
		{
			alResult = null;
			
			AddressIndex2WorkComparer comp = new AddressIndex2WorkComparer();
			
			//住所連結コード１の指定がない場合は何もしない
			if( intAddrConnectCd1 <= 0 )
			{
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			
			//該当する管区のデータをすべてロードする
			this.LoadAreaGroupFromAreaCode( intAddrConnectCd1 );
			
            //読込ロック獲得
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                ArrayList alTarget = AddressGuideCacheManager.htAddressMasterCache[intAddrConnectCd1] as ArrayList;

                if (alTarget == null)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                alResult = new ArrayList();

                //検索
                foreach (AddressWork aw in alTarget)
                {
                    if ((intAddrConnectCd1 == aw.AddrConnectCd1)
                        && aw.AddrConnectCd2 > 0)
                    {
                        if (alResult.BinarySearch(aw, comp) >= 0)
                        {
                            continue;
                        }
                        //TODO : クローンする？
                        alResult.Add(aw);
                    }
                }
            }
            finally
            {
                //読込ロック開放
                _readerWriterLock.ReleaseReaderLock();
            }

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		
		/// <summary>
		/// 該当する住所インデックスマスタ3の情報を取得する
		/// </summary>
        /// <param name="intAddrConnectCd1"></param>
        /// <param name="intAddrConnectCd2"></param>
        /// <param name="alResult"></param>
		public int GetAddrIndexWork3( int intAddrConnectCd1, int intAddrConnectCd2, out ArrayList alResult)
		{
			AddressIndex3WorkComparer comp = new AddressIndex3WorkComparer();

			alResult = null;
			
			//住所連結コード１の指定がない場合は何もしない
			if( intAddrConnectCd1 <= 0 )
			{
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			
			//該当する管区のデータをすべてロードする
			this.LoadAreaGroupFromAreaCode( intAddrConnectCd1 );
			
            //読込ロック獲得
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                ArrayList alTarget = AddressGuideCacheManager.htAddressMasterCache[intAddrConnectCd1] as ArrayList;

                if (alTarget == null)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                alResult = new ArrayList();

                //検索
                foreach (AddressWork aw in alTarget)
                {
                    if ((aw.AddrConnectCd1 == intAddrConnectCd1)
                        && (aw.AddrConnectCd2 > 0 && aw.AddrConnectCd2 == intAddrConnectCd2)
                        && aw.AddrConnectCd3 > 0)
                    {
                        if (alResult.BinarySearch(aw, comp) >= 0)
                        {
                            continue;
                        }
                        //TODO : クローンする？
                        alResult.Add(aw);
                    }
                }
            }
            finally
            {
                //読込ロック開放
                _readerWriterLock.ReleaseReaderLock();
            }

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		
		
		/// <summary>
		/// 該当する住所インデックスマスタ4の情報を取得する
		/// </summary>
        /// <param name="intAddrConnectCd1"></param>
        /// <param name="intAddrConnectCd2"></param>
        /// <param name="intAddrConnectCd3"></param>
        /// <param name="alResult"></param>
		public int GetAddrIndexWork4( int intAddrConnectCd1, int intAddrConnectCd2, int intAddrConnectCd3, out ArrayList alResult)
		{
			AddressIndex4WorkComparer comp = new AddressIndex4WorkComparer();
			alResult = null;
			
			//住所連結コード１の指定がない場合は何もしない
			if( intAddrConnectCd1 <= 0 )
			{
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			
			//該当する管区のデータをすべてロードする
			this.LoadAreaGroupFromAreaCode( intAddrConnectCd1 );
			
                        //読込ロック獲得
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                ArrayList alTarget = AddressGuideCacheManager.htAddressMasterCache[intAddrConnectCd1] as ArrayList;

                if (alTarget == null)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                alResult = new ArrayList();

                //検索
                foreach (AddressWork aw in alTarget)
                {
                    if ((aw.AddrConnectCd1 == intAddrConnectCd1)
                        && (aw.AddrConnectCd2 > 0 && aw.AddrConnectCd2 == intAddrConnectCd2)
                        && (aw.AddrConnectCd3 > 0 && aw.AddrConnectCd3 == intAddrConnectCd3)
                        && aw.AddrConnectCd4 > 0)
                    {
                        if (alResult.BinarySearch(aw, comp) >= 0)
                        {
                            continue;
                        }
                        alResult.Add(aw);
                    }
                }
            }
            finally
            {
                //読込ロック開放
                _readerWriterLock.ReleaseReaderLock();
            }

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		
		
		/// <summary>
		/// 該当する住所インデックスマスタの情報を取得する
		/// </summary>
        /// <param name="intAddrConnectCd1"></param>
        /// <param name="intAddrConnectCd2"></param>
        /// <param name="intAddrConnectCd3"></param>
        /// <param name="intAddrConnectCd4"></param>
        /// <param name="alResult"></param>
		public int GetAddrIndexWork5( int intAddrConnectCd1, int intAddrConnectCd2, int intAddrConnectCd3, int intAddrConnectCd4, out ArrayList alResult)
		{
			AddressIndex5WorkComparer comp = new AddressIndex5WorkComparer();
			alResult = null;
			
			//住所連結コード１の指定がない場合は何もしない
			if( intAddrConnectCd1 <= 0 )
			{
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			
			//該当する管区のデータをすべてロードする
			this.LoadAreaGroupFromAreaCode( intAddrConnectCd1 );
			
            //読込ロック獲得
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {
                ArrayList alTarget = AddressGuideCacheManager.htAddressMasterCache[intAddrConnectCd1] as ArrayList;

                if (alTarget == null)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                alResult = new ArrayList();

                //検索
                foreach (AddressWork aw in alTarget)
                {
                    if ((aw.AddrConnectCd1 == intAddrConnectCd1)
                        && (aw.AddrConnectCd2 > 0 && aw.AddrConnectCd2 == intAddrConnectCd2)
                        && (aw.AddrConnectCd3 > 0 && aw.AddrConnectCd3 == intAddrConnectCd3)
                        && (aw.AddrConnectCd4 > 0 && aw.AddrConnectCd4 == intAddrConnectCd4)
                        && aw.AddrConnectCd5 > 0)
                    {
                        if (alResult.BinarySearch(aw, comp) >= 0)
                        {
                            continue;
                        }
                        alResult.Add(aw);
                    }
                }
            }
            finally
            {
                //読込ロック開放
                _readerWriterLock.ReleaseReaderLock();
            }

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		
		#endregion
		
		#region 非キャッシュ処理関数

		/// <summary>
		/// 郵便番号キーワード検索用関数
		/// キャッシュ非対応
		/// </summary>
        /// <param name="postNoKeyword">郵便番号のキーワード</param>
        /// <param name="resultList">結果を入れるArrayList</param>
		/// <returns>エラーコード</returns>
        //[Obsolete("郵便番号検索はサーバへの負担とタイムアウトのため使用しないでください。", true )]
        public int GetAddressWorkFromZipCd(string postNoKeyword, ref ArrayList resultList)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string searchKeyword = Strings.StrConv(postNoKeyword, VbStrConv.Narrow, 0);

            //指定郵便番号が所属する県をロードする
            LoadAreaFromPostNo(searchKeyword);

            //読込ロック獲得
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                resultList = new ArrayList();

                int[] targetAddrConnectCd1 = null;

                //指定郵便番号が存在する住所の住所連結コードを取得
                status = AddressIndexManageAcs.GetAddrConnectCd1(searchKeyword, out targetAddrConnectCd1);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //検索対象は存在する可能性がある場所のみ
                for (int i = 0; i < targetAddrConnectCd1.Length; i++)
                {
                    ArrayList list = htAddressMasterCache[targetAddrConnectCd1[i]] as ArrayList;

                    for (int j = 0; j < list.Count; j++)
                    {
                        AddressWork work = list[j] as AddressWork;

                        //前方一致検索
                        if (work.PostNo.IndexOf(searchKeyword) == 0)
                        {
                            resultList.Add(work);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }

                ////キャッシュから直検索
                //foreach (ArrayList list in htAddressMasterCache.Values)
                //{
                //    for (int j = 0; j < list.Count; j++)
                //    {
                //        AddressWork work = list[j] as AddressWork;

                //        //前方一致検索
                //        if (work.PostNo.IndexOf(keyword) == 0)
                //        {
                //            resultList.Add(work);
                //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //        }
                //    }
                //}
            }
            finally
            {
                //読込ロック開放
                _readerWriterLock.ReleaseReaderLock();
            }

            return status;
		}
		
        #region チャート用メソッド

        /// <summary>
        /// 住所を取得する
        /// </summary>
        /// <param name="postNoList"></param>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public int ReadAddress(string[] postNoList, out AddressWork[] resultList)
        {
            resultList = null;

            if (postNoList == null || postNoList.Length <= 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            resultList = new AddressWork[postNoList.Length];

            for (int i = 0; i < postNoList.Length; i++)
            {
                AddressWork singleResult = null;

                ReadSingleAddress(postNoList[i], out singleResult);

                resultList[i] = singleResult;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// 郵便番号に一致する住所を一件取得する
        /// </summary>
        /// <param name="postNoKeyword"></param>
        /// <param name="addressWork"></param>
        /// <returns></returns>
        public int ReadSingleAddress(string postNoKeyword, out AddressWork addressWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            addressWork = null;

            //指定郵便番号の住所で該当する可能性があるものをロードする
            LoadAreaFromPostNo(postNoKeyword);

            //読込ロック獲得
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                //指定住所から検索
                int[] targetAddrConnectCd1 = null;

                //指定郵便番号が存在する住所の住所連結コードを取得
                status = AddressIndexManageAcs.GetAddrConnectCd1(postNoKeyword, out targetAddrConnectCd1);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //検索対象は存在する可能性がある場所のみ
                for (int i = 0; i < targetAddrConnectCd1.Length; i++)
                {
                    ArrayList list = htAddressMasterCache[targetAddrConnectCd1[i]] as ArrayList;

                    for (int j = 0; j < list.Count; j++)
                    {
                        AddressWork work = list[j] as AddressWork;

                        if (work.PostNo.IndexOf(postNoKeyword) >= 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            addressWork = work.Clone() as AddressWork;

                            return status;
                        }
                    }
                }
            }
            finally
            {
                //読込ロック開放
                _readerWriterLock.ReleaseReaderLock();
            }

            return status;

        }

        #endregion

        /// <summary>
        /// 住所を取得
        /// </summary>
        /// <param name="areaGroupCode"></param>
        /// <param name="addrkey"></param>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public int GetAddrFromName(int areaGroupCode, string addrkey, out List<AddressWork> resultList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            resultList = new List<AddressWork>();

            //指定の地区をロードする
            LoadAreaGroupFromAreaGroupCode(areaGroupCode);

            //読込ロック獲得
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                string searchKeyword = Strings.StrConv(addrkey, VbStrConv.Katakana | VbStrConv.Narrow, 0);

                List<AreaGroup> findTargetList = null;

                AddressInfoAreaGroupCacheAcs.GetAreaGroupPref(areaGroupCode, out findTargetList);

                for (int i = 0; i < findTargetList.Count; i++)
                {
                    ArrayList list = htAddressMasterCache[findTargetList[i].AreaCode] as ArrayList;

                    for (int j = 0; j < list.Count; j++)
                    {
                        AddressWork work = list[j] as AddressWork;

                        if (work.AddressKana.IndexOf(searchKeyword) >= 0
                            || work.AddressName.IndexOf(searchKeyword) >= 0)
                        {

                            resultList.Add(work);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
            }
            finally
            {
                //読込ロック開放
                _readerWriterLock.ReleaseReaderLock();
            }

            return status;
        }

		/// <summary>
		/// 住所コードから住所を検索する
		/// オフライン対応
		/// </summary>
		/// <param name="addressCode1">住所コード１</param>
		/// <param name="addressCode2">住所コード２</param>
		/// <param name="addressCode3">住所コード３</param>
		/// <param name="alResult">住所コード４</param>
		/// <returns>エラーコード</returns>
		public int GetAddressWorkFromAddressCode(int addressCode1, int addressCode2, int addressCode3, ref ArrayList alResult)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            alResult = new ArrayList();

            //指定住所コードをロードする
            LoadAreaFromAddressCode1(addressCode1);

            //読込ロック獲得
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                int[] targetAddrConnectCd1 = null;

                //指定郵便番号が存在する住所の住所連結コードを取得
                status = AddressIndexManageAcs.GetAddrConnectCd1(addressCode1, out targetAddrConnectCd1);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //キャッシュから直検索
                for (int i = 0; i < targetAddrConnectCd1.Length; i++)
                {
                    ArrayList list = htAddressMasterCache[targetAddrConnectCd1[i]] as ArrayList;

                    for (int j = 0; j < list.Count; j++)
                    {
                        AddressWork work = list[j] as AddressWork;

                        if ((work.AddressCode1Upper * 1000 + work.AddressCode1Lower) == addressCode1
                            && work.AddressCode2 == addressCode2
                            && work.AddressCode3 == addressCode3)
                        {

                            alResult.Add(work);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
            }
            finally
            {
                //読込ロック開放
                _readerWriterLock.ReleaseReaderLock();
            }

            return status;
		}
		
		#endregion
		
		#region 住所データクラス用コンパレータ
		
		class AddressIndex2WorkComparer : IComparer
		{
			
			#region IComparer メンバ
			
			public int Compare(object x, object y)
			{
				AddressWork a1 = x as AddressWork;
				AddressWork a2 = y as AddressWork;

				if( a1.AddrConnectCd1 > a2.AddrConnectCd1 )
				{
					return 1;
				}
				if( a1.AddrConnectCd1 < a2.AddrConnectCd1 )
				{
					return -1;
				}
				if( a1.AddrConnectCd2 > a2.AddrConnectCd2 )
				{
					return 1;
				}
				if( a1.AddrConnectCd2 < a2.AddrConnectCd2 )
				{
					return -1;
				}
				return 0;
			}
			
			#endregion
			
		}
		
		
		class AddressIndex3WorkComparer : IComparer
		{
			
			#region IComparer メンバ
			
			public int Compare(object x, object y)
			{
				AddressWork a1 = x as AddressWork;
				AddressWork a2 = y as AddressWork;
				
				if( a1.AddrConnectCd1 > a2.AddrConnectCd1 )
				{
					return 1;
				}
				if( a1.AddrConnectCd1 < a2.AddrConnectCd1 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd2 > a2.AddrConnectCd2 )
				{
					return 1;
				}
				if( a1.AddrConnectCd2 < a2.AddrConnectCd2 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd3 > a2.AddrConnectCd3 )
				{
					return 1;
				}
				if( a1.AddrConnectCd3 < a2.AddrConnectCd3 )
				{
					return -1;
				}
				
				return 0;
			}
			
			#endregion
			
		}
		
		class AddressIndex4WorkComparer : IComparer
		{
			
			#region IComparer メンバ
			
			public int Compare(object x, object y)
			{
				AddressWork a1 = x as AddressWork;
				AddressWork a2 = y as AddressWork;
				
				if( a1.AddrConnectCd1 > a2.AddrConnectCd1 )
				{
					return 1;
				}
				if( a1.AddrConnectCd1 < a2.AddrConnectCd1 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd2 > a2.AddrConnectCd2 )
				{
					return 1;
				}
				if( a1.AddrConnectCd2 < a2.AddrConnectCd2 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd3 > a2.AddrConnectCd3 )
				{
					return 1;
				}
				if( a1.AddrConnectCd3 < a2.AddrConnectCd3 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd4 > a2.AddrConnectCd4 )
				{
					return 1;
				}
				if( a1.AddrConnectCd4 < a2.AddrConnectCd4 )
				{
					return -1;
				}
				
				return 0;
			}
			
			#endregion
			
		}

		class AddressIndex5WorkComparer : IComparer
		{
			
			#region IComparer メンバ
			
			public int Compare(object x, object y)
			{
				AddressWork a1 = x as AddressWork;
				AddressWork a2 = y as AddressWork;
				
				if( a1.AddrConnectCd1 > a2.AddrConnectCd1 )
				{
					return 1;
				}
				if( a1.AddrConnectCd1 < a2.AddrConnectCd1 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd2 > a2.AddrConnectCd2 )
				{
					return 1;
				}
				if( a1.AddrConnectCd2 < a2.AddrConnectCd2 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd3 > a2.AddrConnectCd3 )
				{
					return 1;
				}
				if( a1.AddrConnectCd3 < a2.AddrConnectCd3 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd4 > a2.AddrConnectCd4 )
				{
					return 1;
				}
				if( a1.AddrConnectCd4 < a2.AddrConnectCd4 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd5 > a2.AddrConnectCd5 )
				{
					return 1;
				}
				if( a1.AddrConnectCd5 < a2.AddrConnectCd5 )
				{
					return -1;
				}
				
				return 0;
			}
			
			#endregion
			
		}

		#endregion
		
	}

}
