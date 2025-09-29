using System;
using System.Collections;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Xml;
using System.Windows.Forms;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Common
{
	
	/// <summary>
	/// AddressWorkのディスクキャッシュ入出力をやるクラス
	/// </summary>
	/// <remarks>
	/// <br>Programmer : 23011　野口　暢朗</br>
	/// <br>Date       : 2005.06.03</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	internal class AddressInfoCacheAcs
	{
		
		private readonly static string classID = "Broadleaf.Application.Common.OfferAddressInfoAcs";
		
		private static OfflineDataSerializer serializer = null;
		
		/// <summary>
		/// 更新日付を保存するヘッダ
		/// キーに住所連結コード１、値にAddressWork
		/// </summary>
		private static Hashtable headerCache = null;
		
		/// <summary>
		/// スタティックコンストラクタ
		/// </summary>
		static AddressInfoCacheAcs()
		{
			serializer = new OfflineDataSerializer();

            headerCache = new Hashtable();

            //キャッシュのヘッダ部分はここで読み出しておく
            DeSerializeAddressWorkHeader(out headerCache);
		}
		
		#region 管区入出力メソッド
		
		#region Work←→UIData変換メソッド
		
		private static AreaGroup CopyWorkToData( AreaGroupWork work )
		{
			AreaGroup data = new AreaGroup();
			
			data.CreateDateTime			 = work.CreateDateTime;
			data.UpdateDateTime			 = work.UpdateDateTime;
			data.EnterpriseCode			 = work.EnterpriseCode;
			data.FileHeaderGuid			 = work.FileHeaderGuid;
			data.UpdEmployeeCode			 = work.UpdEmployeeCode;
			data.UpdAssemblyId1			 = work.UpdAssemblyId1;
			data.UpdAssemblyId2			 = work.UpdAssemblyId2;
			data.LogicalDeleteCode			 = work.LogicalDeleteCode;
			data.AreaKind			 = work.AreaKind;
			data.AreaGroupCode			 = work.AreaGroupCode;
			data.AreaCode			 = work.AreaCode;
			data.AreaName			 = work.AreaName;
			
			return data;
		}
		
		private static AreaGroupWork CopyDataToWork( AreaGroup data )
		{
			AreaGroupWork work = new AreaGroupWork();
			
			work.CreateDateTime			 = data.CreateDateTime;
			work.UpdateDateTime			 = data.UpdateDateTime;
			work.EnterpriseCode			 = data.EnterpriseCode;
			work.FileHeaderGuid			 = data.FileHeaderGuid;
			work.UpdEmployeeCode			 = data.UpdEmployeeCode;
			work.UpdAssemblyId1			 = data.UpdAssemblyId1;
			work.UpdAssemblyId2			 = data.UpdAssemblyId2;
			work.LogicalDeleteCode			 = data.LogicalDeleteCode;
			work.AreaKind			 = data.AreaKind;
			work.AreaGroupCode			 = data.AreaGroupCode;
			work.AreaCode			 = data.AreaCode;
			work.AreaName			 = data.AreaName;
			
			return work;
		}
		
		#endregion
		
		/// <summary>
		/// 管区を書き込む
		/// </summary>
		/// <returns></returns>
		public static int SerializeAreaGroup( ArrayList alAreaGroup )
		{
			ArrayList alWork = new ArrayList();
			
			foreach( AreaGroup ag in alAreaGroup )
			{
				alWork.Add( CopyDataToWork( ag ) );
			}
			
			int status = serializer.Serialize( classID, new string[]{ "AREAGROUP", LoginInfoAcquisition.EnterpriseCode }, alWork );
			
			return status;
		}
		
		/// <summary>
		/// 管区をロードする
		/// </summary>
		/// <returns></returns>
		public static ArrayList DeSerializeAreaGroup()
		{
			object obj = serializer.DeSerialize( classID, new string[]{ "AREAGROUP", LoginInfoAcquisition.EnterpriseCode } );
			
			ArrayList alData = new ArrayList();
			
			ArrayList alWork = obj as ArrayList;
			
			if( alWork == null )
			{
				return null;
			}
			
			foreach( AreaGroupWork ag in alWork )
			{
				alData.Add( CopyWorkToData( ag ) );
			}
			
			return alData;
			
		}
		
		#endregion
		
		#region 更新日付管理用ヘッダ入出力メソッド

        /// <summary>
        /// キャッシュ用ハッシュテーブルからヘッダを書き出す
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        private static int SerializeAddressWorkHeader(Hashtable header)
        {
            //データなしなら戻る
            if (header == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            ArrayList alTmp = new ArrayList();

            //HashtableからArrayListに変換
            foreach (AddressWork work in header.Values)
            {
                alTmp.Add(work);
            }

            //データなしなら戻る
            if (alTmp.Count <= 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            //書き込む
            return serializer.Serialize(classID, new string[] { "ADDRESS", "HEADER" }, alTmp);
        }

        /// <summary>
        /// キャッシュ用ハッシュテーブルにヘッダを読み込む
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        private static int DeSerializeAddressWorkHeader(out Hashtable header)
        {
            ArrayList alTmp = null;
            header = new Hashtable();

            alTmp = serializer.DeSerialize(classID, new string[] { "ADDRESS", "HEADER" }) as ArrayList;

            if (alTmp != null)
            {
                //ArrayListからHashtableに変換
                foreach (AddressWork work in alTmp)
                {
                    //重複するキーははじく
                    if (header.ContainsKey(work.AddrConnectCd1))
                    {
                        continue;
                    }
                    header.Add(work.AddrConnectCd1, work);
                }
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// キャッシュの更新日を取得する
        /// 更新日付の管理はこのクラス内部に隠蔽しとく
        /// </summary>
        /// <param name="addrConnectCd1"></param>
        /// <param name="lastUpdate"></param>
        /// <returns></returns>
        public static int GetCacheUpdateTime(int addrConnectCd1, out long lastUpdate)
        {
            lastUpdate = DateTime.MinValue.Ticks;

            if (!headerCache.ContainsKey(addrConnectCd1))
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            AddressWork work = headerCache[addrConnectCd1] as AddressWork;

            if (work == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            lastUpdate = work.UpdateDateTime.Ticks;

            //try
            //{
            //    lastUpdate = long.Parse(work.PostNo);
            //}
            //catch
            //{
            //    return (int)ConstantManagement.DB_Status.ctDB_EOF;
            //}
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
		
		#endregion
		
		#region 県のAddressWork入出力メソッド
		
		/// <summary>
		/// 指定地区コードのデータを書き出す
		/// </summary>
        /// <param name="addrConnectCd1"></param>
        /// <param name="lastUpdateTicks"></param>
        /// <param name="alWork"></param>
		/// <returns></returns>
		public static int SerializeAddressWork( int addrConnectCd1, long lastUpdateTicks, ArrayList alWork )
		{
			int status = 0;
			
			//データが無いなら戻る
			if( alWork == null || alWork.Count <= 0 )
			{
				return (int)ConstantManagement.DB_Status.ctDB_EOF;
			}
			
			status = serializer.Serialize( classID, new string[]{ "ADDRESS", addrConnectCd1.ToString() }, alWork );
			
			//書き込みに失敗したら戻る
			if( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				return (int)ConstantManagement.DB_Status.ctDB_EOF;
			}

            AddressWork work = null;

            //ヘッダが存在するか確認
            if (headerCache.ContainsKey(addrConnectCd1))
            {
                work = headerCache[addrConnectCd1] as AddressWork;
            }
            else
            {
                work = new AddressWork();
                work.AddrConnectCd1 = addrConnectCd1;

                //ヘッダに追加しとく
                headerCache.Add(addrConnectCd1, work);
            }

            //更新日付を入れるとこがないので郵便番号のとこに入れとく
            //work.PostNo = lastUpdateTicks.ToString();
            work.UpdateDateTime = new DateTime(lastUpdateTicks);

            //ヘッダ書き込み
            SerializeAddressWorkHeader(headerCache);
			
			return status;
		}
		
		/// <summary>
		/// 指定地区コードのデータを読み出す
		/// </summary>
        /// <param name="addrConnectCd1"></param>
		/// <returns></returns>
		public static ArrayList DeSerializeAddressWork( int addrConnectCd1 )
		{
			return serializer.DeSerialize( classID, new string[]{ "ADDRESS", addrConnectCd1.ToString() } ) as ArrayList;
		}
		
		#endregion
		
		#region リードのキャッシュ関連のメソッド
		
        ///// <summary>
        ///// リードのキャッシュを保存する
        ///// </summary>
        ///// <param name="htAddressWork"></param>
        ///// <returns></returns>
        //public static int SerializeAddressWorkReadCache( Hashtable htAddressWork )
        //{
        //    ArrayList alTmp = new ArrayList();
			
        //    if( htAddressWork != null )
        //    {
        //        foreach( AddressWork awTmp in htAddressWork.Values )
        //        {
        //            alTmp.Add( awTmp );
        //        }
        //    }
        //    return serializer.Serialize( classID, new string[]{ "READCACHE" }, alTmp );
        //}
		
        ///// <summary>
        ///// リードのキャッシュを取り出す
        ///// </summary>
        ///// <returns></returns>
        //public static Hashtable DeSerializeAddressWorkReadCache()
        //{
        //    Hashtable htTmp = new Hashtable();
			
        //    ArrayList alTmp = serializer.DeSerialize( classID, new string[]{ "READCACHE" } ) as ArrayList;
			
        //    if( alTmp == null )
        //    {
        //        return htTmp;
        //    }
			
        //    foreach( AddressWork awTmp in alTmp )
        //    {
        //        htTmp.Add( AddressInfoCacheAcs.CreateReadCacheHashKey( awTmp ), awTmp );
        //    }
			
        //    return htTmp;
        //}
		
        ///// <summary>
        ///// リードのキャッシュ用キー作成メソッド
        ///// </summary>
        ///// <param name="addressCode1"></param>
        ///// <param name="addressCode2"></param>
        ///// <param name="addressCode3"></param>
        ///// <returns></returns>
        //public static string CreateReadCacheHashKey( AddressWork awTmp )
        //{
        //    return CreateReadCacheHashKey( int.Parse( String.Format("{0:D2}{1:D3}", awTmp.AddressCode1Upper, awTmp.AddressCode1Lower ) ), awTmp.AddressCode2, awTmp.AddressCode3 );
        //}
		
        //public static string CreateReadCacheHashKey( int addressCode1, int addressCode2, int addressCode3 )
        //{
        //    return addressCode1.ToString()
        //        + "_"
        //        + addressCode2.ToString()
        //        + "_"
        //        + addressCode3.ToString();
        //}
		
		#endregion
		
	}
}
