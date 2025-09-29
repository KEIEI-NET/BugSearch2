using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Microsoft.VisualBasic;
using System.Threading;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 住所リソースクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : </br>
    /// <br>Programmer : 23011　野口　暢朗</br>
    /// <br>Date       : 2006.09.07</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    internal static class AddressIndexManageAcs
    {

        /// <summary>
        /// スタティックコンストラクタ
        /// </summary>
        static AddressIndexManageAcs()
        {
            _readerWriterLock = new ReaderWriterLock();

            iOfferAddressInfo = MediationOfferAddressInfo.GetOfferAddressInfo();
        }
        
        /// <summary>
		/// リモーティングアクセス用インターフェイス
		/// </summary>
		private static IOfferAddressInfo iOfferAddressInfo = null;

        /// <summary>
        /// 住所マスタ更新管理マスタのキャッシュ
        /// </summary>
        private static DataTable addrUpdMngTable = null;

        /// <summary>
        /// 住所マスタ住所コードインデックスマスタのキャッシュ
        /// </summary>
        private static DataTable addrCdIndxTable = null;

        /// <summary>
        /// 住所マスタ郵便番号インデックスマスタのキャッシュ
        /// </summary>
        private static DataTable postNoIndxTable = null;

        /// <summary>
        /// クラスIDはパブリックなクラスの名前にしとく
        /// </summary>
        private readonly static string classID = "Broadleaf.Application.Common.OfferAddressInfoAcs";

        /// <summary>
        /// 読書きロッククラス
        /// </summary>
        private static ReaderWriterLock _readerWriterLock = null;

        /// <summary>
        /// 初期化されたかどうか
        /// </summary>
        private static bool _initialized = false;

        /// <summary>
        /// 更新管理マスタのテーブル展開処理
        /// </summary>
        /// <param name="list"></param>
        /// <param name="table"></param>
        private static void ExpandAddrUpdMngWorkList(ArrayList list, DataTable table)
        {
            if (list == null)
            {
                return;
            }
            //管理マスタ展開
            foreach (AddrUpdMngWork mngWork in list)
            {
                DataRow row = table.NewRow();

                row[COLUMN_AddrConnectCd1] = mngWork.AddrConnectCd1;
                row[COLUMN_AddrUpdateDateTime] = mngWork.AddrUpdateDateTime.Ticks;

                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// 住所コードインデックスマスタのテーブル展開処理
        /// </summary>
        /// <param name="list"></param>
        /// <param name="table"></param>
        private static void ExpandAddrCdIndxWorkList(ArrayList list, DataTable table)
        {
            if (list == null)
            {
                return;
            }
            //住所コードインデックスマスタ展開
            foreach (AddrCdIndxWork indxWork in list)
            {
                DataRow row = table.NewRow();

                row[COLUMN_AddrConnectCd1] = indxWork.AddrConnectCd1;
                row[COLUMN_AddressCode1Upper] = indxWork.AddressCode1Upper;

                table.Rows.Add(row);
            }

        }

        /// <summary>
        /// 郵便番号インデックスマスタのテーブル展開処理
        /// </summary>
        /// <param name="list"></param>
        /// <param name="table"></param>
        private static void ExpandPostNoIndxWorkList(ArrayList list, DataTable table)
        {
            if (list == null)
            {
                return;
            }
            //郵便番号インデックスマスタ展開
            foreach (PostNoIndxWork postWork in list)
            {
                DataRow row = table.NewRow();

                row[COLUMN_AddrConnectCd1] = postWork.AddrConnectCd1;
                row[COLUMN_PostNoInitialChar] = postWork.PostNoInitialChar;

                table.Rows.Add(row);
            }

        }

        /// <summary>
        /// リモートからインデックス情報取得後ディスクにキャッシュします
        /// </summary>
        /// <param name="addrCdIndxList"></param>
        /// <param name="postNoIndxList"></param>
        /// <returns></returns>
        private static int SearchIndex(out ArrayList addrCdIndxList, out ArrayList postNoIndxList)
        {
            addrCdIndxList = null;
            postNoIndxList = null;

            object objAddrCdIndxList = null;
            object objPostNoIndxList = null;

            //読込ロック確保
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                //インデックスマスタを取得
                int status = iOfferAddressInfo.SearchAddrCdIndxAndPostNoIndx(out objAddrCdIndxList, out objPostNoIndxList);

                //失敗したら戻る
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //採用リストに入れとく
                addrCdIndxList = objAddrCdIndxList as ArrayList;
                postNoIndxList = objPostNoIndxList as ArrayList;

                OfflineDataSerializer serializer = new OfflineDataSerializer();

                //ディスク保存
                serializer.Serialize(classID, new string[] { "AddrCdIndxWork" }, objAddrCdIndxList);
                serializer.Serialize(classID, new string[] { "PostNoIndxWork" }, objPostNoIndxList);
            }
            finally
            {
                //読込ロック開放
                _readerWriterLock.ReleaseReaderLock();
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }


        /// <summary>
        /// 更新マスタ比較用メソッド
        /// </summary>
        /// <param name="oldList"></param>
        /// <param name="newList"></param>
        /// <returns></returns>
        private static bool CompareAddrUpdMngWorkList( ArrayList oldList, ArrayList newList )
        {
            if (oldList == null)
            {
                return false;
            }

            if (newList == null)
            {
                return false;
            }

            Dictionary<string, int> compareList = new Dictionary<string, int>();

            //まずは旧リストを辞書に展開
            for (int i = 0; i < oldList.Count; i++)
            {
                AddrUpdMngWork mngWork = oldList[i] as AddrUpdMngWork;

                compareList.Add(mngWork.AddrConnectCd1.ToString() + ":" + mngWork.AddrUpdateDateTime.ToString(), 0);
            }

            //新リストの中身を旧リストから削除
            for (int i = 0; i < newList.Count; i++)
            {
                AddrUpdMngWork mngWork = newList[i] as AddrUpdMngWork;

                string key = mngWork.AddrConnectCd1.ToString() + ":" + mngWork.AddrUpdateDateTime.ToString();
                //含まれて居ないなら追加されてる
                if (!compareList.ContainsKey(key))
                {
                    return false;
                }

                compareList.Remove(key);
            }

            //最後に何か残ってたら消されてる
            if (compareList.Count > 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// インデックス情報をロードする
        /// </summary>
        private static int LoadIndex()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //書込みロック獲得
            _readerWriterLock.AcquireWriterLock(Timeout.Infinite);

            try
            {
                //初期化済みなら戻る
                if (_initialized)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                try
                {
                    OfflineDataSerializer serializer = new OfflineDataSerializer();

                    //まずは更新管理マスタをキャッシュから引っ張り出す
                    ArrayList addrUpdMngList = serializer.DeSerialize(classID, new string[] { "AddrUpdMngWork" }) as ArrayList;

                    ArrayList addrCdIndxList = serializer.DeSerialize(classID, new string[] { "AddrCdIndxWork" }) as ArrayList;

                    ArrayList postNoIndxList = serializer.DeSerialize(classID, new string[] { "PostNoIndxWork" }) as ArrayList;

                    //オンライン時の処理
                    if (LoginInfoAcquisition.OnlineFlag)
                    {
                        //次はリモートから取得
                        object objAddrUpdMngList = null;
                        status = iOfferAddressInfo.SearchAddrUpdMng(out objAddrUpdMngList);

                        //リモートから取れなかったら戻る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }

                        //キャッシュがないなら新しいものを採用する
                        if (!CompareAddrUpdMngWorkList(addrUpdMngList, objAddrUpdMngList as ArrayList))
                        {
                            //採用リストに入れとく
                            addrUpdMngList = objAddrUpdMngList as ArrayList;
                            //ディスク保存
                            serializer.Serialize(classID, new string[] { "AddrUpdMngWork" }, objAddrUpdMngList);

                            //リモートからデータ取得
                            status = SearchIndex(out addrCdIndxList, out postNoIndxList);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return status;
                            }
                        }

                        //キャッシュがなかった場合
                        if (addrCdIndxList == null || postNoIndxList == null)
                        {
                            status = SearchIndex(out addrCdIndxList, out postNoIndxList);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return status;
                            }
                        }
                    }

                    //カラム作成
                    addrUpdMngTable = new DataTable();
                    CreateAddrUpdMngTableColumn(addrUpdMngTable);

                    addrCdIndxTable = new DataTable();
                    CreateAddrCdIndxTableColumn(addrCdIndxTable);

                    postNoIndxTable = new DataTable();
                    CreatePostNoIndxTableColumn(postNoIndxTable);

                    //データ展開
                    ExpandAddrUpdMngWorkList(addrUpdMngList, addrUpdMngTable);
                    ExpandAddrCdIndxWorkList(addrCdIndxList, addrCdIndxTable);
                    ExpandPostNoIndxWorkList(postNoIndxList, postNoIndxTable);

                }
                finally
                {
                    if (LoginInfoAcquisition.OnlineFlag)
                    {
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //ロードできてないなら消す
                            addrUpdMngTable = null;
                            addrCdIndxTable = null;
                            postNoIndxTable = null;
                        }
                    }
                    else
                    {
                        //オフラインの場合はNORMAL
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                }

                //初期化完了
                _initialized = true;
            }
            finally
            {
                //書込みロック開放
                _readerWriterLock.ReleaseWriterLock();
            }

            return status;
        }

        private readonly static string COLUMN_AddrConnectCd1 = "住所連結コード１";

        private readonly static string COLUMN_AddrUpdateDateTime = "住所更新日時";

        private readonly static string COLUMN_AddressCode1Upper = "都道府県コード";

        private readonly static string COLUMN_PostNoInitialChar = "郵便番号頭文字";

        /// <summary>
        /// 更新管理用テーブル
        /// </summary>
        /// <param name="table"></param>
        private static void CreateAddrUpdMngTableColumn( DataTable table )
        {
            table.Columns.Add(COLUMN_AddrUpdateDateTime, typeof(long));
            table.Columns.Add(COLUMN_AddrConnectCd1, typeof(int));
        }

        /// <summary>
        /// 住所マスタ住所コードインデックスマスタ
        /// </summary>
        /// <param name="table"></param>
        private static void CreateAddrCdIndxTableColumn(DataTable table)
        {
            table.Columns.Add(COLUMN_AddrConnectCd1, typeof(int));
            table.Columns.Add(COLUMN_AddressCode1Upper, typeof(int));
        }

        /// <summary>
        /// 住所マスタ郵便番号インデックスマスタ
        /// </summary>
        /// <param name="table"></param>
        private static void CreatePostNoIndxTableColumn(DataTable table)
        {
            table.Columns.Add(COLUMN_AddrConnectCd1, typeof(int));
            table.Columns.Add(COLUMN_PostNoInitialChar, typeof(int));
        }

        /// <summary>
        /// 郵便番号から住所連結コード１を取得する
        /// </summary>
        /// <param name="postNo"></param>
        /// <param name="addrConnectCd1"></param>
        /// <returns></returns>
        public static int GetAddrConnectCd1(string postNo, out int[] addrConnectCd1)
        {
            addrConnectCd1 = new int[0];
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            if (postNo == null || postNo.Length <= 0 || !Char.IsDigit(postNo[0]))
            {
                return status;
            }

            status = LoadIndex();

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            //読込ロック確保
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                string selectBaseString = "{0}='{1}'";

                string selectString = String.Format(selectBaseString, COLUMN_PostNoInitialChar, postNo[0].ToString());

                DataRow[] rows = postNoIndxTable.Select(selectString);

                addrConnectCd1 = new int[rows.Length];

                //結果取得
                for (int i = 0; i < rows.Length; i++)
                {
                    addrConnectCd1[i] = (int)rows[i][COLUMN_AddrConnectCd1];
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
        /// 住所コード１から住所連結コード１を取得する
        /// </summary>
        /// <param name="addressCode1"></param>
        /// <param name="addrConnectCd1"></param>
        /// <returns></returns>
        public static int GetAddrConnectCd1( int addressCode1, out int[] addrConnectCd1 )
        {
            addrConnectCd1 = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            string strAddressCode1 = String.Format("{0:D5}", addressCode1);
            string strAddressCode1Upper = strAddressCode1.ToString().Substring(0, 2);
            int addressCode1Upper = int.Parse(strAddressCode1Upper);

            status = LoadIndex();

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            //読込みロック開放
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                string selectBaseString = "{0}={1}";
                string selectString = String.Format(selectBaseString, COLUMN_AddressCode1Upper, addressCode1Upper);

                DataRow[] rows = addrCdIndxTable.Select(selectString);

                addrConnectCd1 = new int[rows.Length];

                //結果取得
                for (int i = 0; i < rows.Length; i++)
                {
                    addrConnectCd1[i] = (int)rows[i][COLUMN_AddrConnectCd1];
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
        /// 指定住所連結コード１の更新日付を取得する
        /// </summary>
        /// <param name="addrConnectCd1"></param>
        /// <param name="lastUpdate"></param>
        /// <returns></returns>
        public static int GetLastUpdateTime(int addrConnectCd1, out long lastUpdate)
        {
            lastUpdate = 0;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            if (addrConnectCd1 == 0)
            {
                return status;
            }

            status = LoadIndex();

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            //読込ロック確保
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                string selectBaseString = "{0}={1}";
                string selectString = String.Format(selectBaseString, COLUMN_AddrConnectCd1, addrConnectCd1);

                DataRow[] rows = addrUpdMngTable.Select(selectString);

                //結果取得
                if (rows.Length > 0)
                {
                    lastUpdate = (long)rows[0][COLUMN_AddrUpdateDateTime];
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            finally
            {
                //書込みロック開放
                _readerWriterLock.ReleaseReaderLock();
            }

            return status;
        }

    }

}
