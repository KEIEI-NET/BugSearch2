using System.Collections;
using System.Data;
using System.Threading;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Common
{
	
	/// <summary>
	/// 住所ガイド用地区グループアクセスクラス
	/// キャッシュも管理する
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011　野口　暢朗</br>
	/// <br>Date       : 2006.01.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class AddressInfoAreaGroupCacheAcs
	{
		/// <summary>
		/// 地区グループアクセスクラス(SFTOK09002A)
		/// </summary>
		private static AreaGroupAcs areaGroupAcs = null;
		
		/// <summary>
		/// 管区をキャッシュしておくためのArrayList
        /// 初期化チェック用のロックオブジェクトとしても使用する
		/// </summary>
		private static DataTable areaGroupTable = null;

        /// <summary>
        /// 読書きロッククラス
        /// </summary>
        private static ReaderWriterLock _readerWriterLock = null;

        /// <summary>
        /// 初期化フラグ
        /// </summary>
        private static bool _initialized = false;

		/// <summary>
		/// スタティックコンストラクタ
		/// </summary>
		static AddressInfoAreaGroupCacheAcs()
		{
            _readerWriterLock = new ReaderWriterLock();

			areaGroupAcs = new AreaGroupAcs();
			
			//キャッシュ用テーブル
			areaGroupTable = new DataTable();
			areaGroupTable.Columns.Add( "AreaGroupCode", typeof( int ) );
			areaGroupTable.Columns.Add( "AreaCode", typeof( int ) );
			areaGroupTable.Columns.Add( "AreaKind", typeof( int ) );
			areaGroupTable.Columns.Add( "AreaGroup", typeof( AreaGroup ) );
		}

		/// <summary>
		/// メモリに地区グループデータをロードする
		/// スレッドセーフ
		/// </summary>
		private static void LoadAreaGroup()
		{
            ArrayList alTmp = null;

            //----------------------- 書込みロック開始 ------------------------
            //書込みロック取得
            _readerWriterLock.AcquireWriterLock(Timeout.Infinite);
			
			try
			{
                //すでにロード済みならロードしない。
                if (_initialized)
                {
                    return;
                }

                //オンラインならリモートから取得を試みる
				if( LoginInfoAcquisition.OnlineFlag )
				{
					int status;

					try
					{
                        //throw new System.Exception("管区のデータとりにいこうとした");
						status = areaGroupAcs.SearchAll( out alTmp, LoginInfoAcquisition.EnterpriseCode );
						
						//データを取得できたらオフライン時のためにキャッシュしとく
						if( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
						{
							AddressInfoCacheAcs.SerializeAreaGroup( alTmp );
						}
					}
					catch( System.Net.WebException)
					{
					}

				}
			    
				//データが無いならキャッシュから読み込む
				if( alTmp == null || alTmp.Count <= 0 )
				{
					//ディスクキャッシュをロードする
					alTmp = AddressInfoCacheAcs.DeSerializeAreaGroup();
				}

                //スタティックメモリに展開する
                SetAreaGroupStaticMemoryInner(alTmp);
            }
            finally
            {
                //読書きロックを開放する
                _readerWriterLock.ReleaseWriterLock();
            }
            //----------------------- 書込みロック終了 ------------------------
        }
        /// <summary>
        /// AreaGroupセット
        /// </summary>
        /// <param name="areaGroupList"></param>
        public static void SetAreaGroupStaticMemory(ArrayList areaGroupList)
        {
            //----------------------- 書込みロック開始 ------------------------
            //書込みロック取得
            _readerWriterLock.AcquireWriterLock(Timeout.Infinite);

            try
            {
                SetAreaGroupStaticMemoryInner(areaGroupList);
            }
            finally
            {
                //書込みロックを解除する
                _readerWriterLock.ReleaseWriterLock();
            }
            //----------------------- 書込みロック終了 ------------------------
        }

        /// <summary>
        /// AreaGroupのデータをスタティックメモリに設定する
        /// 呼び出しはロック内で行ってください
        /// </summary>
        /// <param name="areaGroupList"></param>
        /// <returns></returns>
        private static void SetAreaGroupStaticMemoryInner( ArrayList areaGroupList )
        {
            if (areaGroupList == null)
            {
                return;
            }

            //データクリア
            areaGroupTable.Rows.Clear();

            //ArrayListからDataTableに展開
            foreach (AreaGroup data in areaGroupList)
            {
                DataRow drData = areaGroupTable.NewRow();

                drData["AreaGroupCode"] = data.AreaGroupCode;
                drData["AreaCode"] = data.AreaCode;
                drData["AreaKind"] = data.AreaKind;
                drData["AreaGroup"] = data;

                areaGroupTable.Rows.Add(drData);
            }

            //初期化済みのフラグを立てる
            _initialized = true;
        }

		/// <summary>
		/// 指定管区の県を取得する
		/// </summary>
        /// <param name="areaGroupCode"></param>
        /// <param name="areaGroupList"></param>
		/// <returns></returns>
		public static int GetAreaGroupPref( int areaGroupCode, out List<AreaGroup> areaGroupList )
		{
            areaGroupList = new List<AreaGroup>();
            DataRow[] drSelect = null;

            //----------------------- 書込みロック開始 ------------------------
            //管区データをメモリにロードする
			LoadAreaGroup();
            //----------------------- 書込みロック終了 ------------------------

            //----------------------- 読込みロック開始 ------------------------
            //読込ロックを獲得
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {
                //コード指定の場合はそのコードだけ
                if (areaGroupCode != 0)
                {
                    drSelect = areaGroupTable.Select(" AreaGroupCode = " + areaGroupCode.ToString() + " AND AreaKind = 1");
                }
                else
                {
                    //未指定ならば全ての県
                    drSelect = areaGroupTable.Select("AreaKind = 1");
                }

                //DataRowからAreaGroupを取り出す
                for (int i = 0; i < drSelect.Length; i++)
                {
                    areaGroupList.Add(drSelect[i]["AreaGroup"] as AreaGroup);
                }
            }
            finally
            {
                //読込ロック開放
                _readerWriterLock.ReleaseReaderLock();
            }
            //----------------------- 読込みロック終了 ------------------------

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		
		/// <summary>
		/// 地区グループを取得する
		/// </summary>
		/// <param name="areaGroupList"></param>
		/// <returns></returns>
		public static int GetAreaGroup( out List<AreaGroup> areaGroupList )
		{
            areaGroupList = new List<AreaGroup>();

            //----------------------- 書込みロック開始 ------------------------
            //管区データをメモリにロードする
			LoadAreaGroup();
            //----------------------- 書込みロック終了 ------------------------

            //----------------------- 読込みロック開始 ------------------------
            //読込ロックを獲得
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {
                //管区だけ取得
                DataRow[] drSelect = areaGroupTable.Select(" AreaKind = 0 ");

                if (drSelect.Length <= 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                //DataRowからArrayListに展開
                for (int i = 0; i < drSelect.Length; i++)
                {
                    areaGroupList.Add(drSelect[i]["AreaGroup"] as AreaGroup);
                }
            }
            finally
            {
                //読込ロック開放
                _readerWriterLock.ReleaseReaderLock();
            }
            //----------------------- 読込みロック終了 ------------------------

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		
		/// <summary>
		/// 地区コードから地区グループを取得する
		/// </summary>
		/// <param name="areaCode"></param>
        /// <param name="areaGroup"></param>
		/// <returns></returns>
		public static int GetAreaGroupFromAreaCode( int areaCode, out AreaGroup areaGroup )
		{
            areaGroup = null;

            //----------------------- 読書きロック開始 ------------------------
            int areaGroupCode = GetAreaGroupCodeFromAreaCode(areaCode);
            //----------------------- 読書きロック終了 ------------------------

            //----------------------- 読込みロック開始 ------------------------
            //読込ロックを獲得
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {
                //該当がない場合は戻る
                if (areaGroupCode == 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                DataRow[] drSelect = areaGroupTable.Select("AreaGroupCode = " + areaGroupCode.ToString());

                if (drSelect.Length <= 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                areaGroup = drSelect[0]["AreaGroup"] as AreaGroup;
            }
            finally
            {
                //読込ロック開放
                _readerWriterLock.ReleaseReaderLock();
            }
            //----------------------- 読込みロック終了 ------------------------

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		
		/// <summary>
		/// 地区コードから地区グループコードを取得する
		/// </summary>
		/// <param name="areaCode"></param>
		/// <returns></returns>
		public static int GetAreaGroupCodeFromAreaCode( int areaCode )
		{
			int areaGroupCode = 0;

            //----------------------- 書込みロック開始 ------------------------
            //管区データをメモリにロードする
			LoadAreaGroup();
            //----------------------- 書込みロック終了 ------------------------

            //----------------------- 読込みロック開始 ------------------------
            //読込ロックを獲得
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                DataRow[] drSelect = areaGroupTable.Select("AreaCode = " + areaCode.ToString());

                if (drSelect.Length <= 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                areaGroupCode = (int)drSelect[0]["AreaGroupCode"];
            }
            finally
            {
                //読込ロック開放
                _readerWriterLock.ReleaseReaderLock();
            }
            //----------------------- 読込みロック終了 ------------------------

			return areaGroupCode;
		}
		
	}
	
}