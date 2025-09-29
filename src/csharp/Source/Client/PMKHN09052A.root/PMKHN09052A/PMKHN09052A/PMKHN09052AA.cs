using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Windows.Forms;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 部位コードマスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部位コードマスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2008.06.17</br>
    /// <br></br>
    /// </remarks>
    public class PartsPosCodeUAcs : IGeneralGuideData
    {
        #region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        // 部位コードマスタ（ユーザー）
        private IPartsPosCodeUDB _iPartsPosCodeUDB = null;
        // 部位コードマスタ（提供）
        private IPartsPosCodeDB _iPartsPosCodeDB = null;

        // BLコードマスタのリスト
        private ArrayList _blGoodsList;

        // 2008.10.20 30413 犬飼 得意先情報のキャッシュ追加 >>>>>>START
        // 得意先情報のキャッシュ
        private ArrayList _customerList;
        // 2008.10.20 30413 犬飼 得意先情報のキャッシュ追加 <<<<<<END

        #endregion

        #region Constructor

        /// <summary>
        /// 部位コードマスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 部位コードマスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public PartsPosCodeUAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iPartsPosCodeUDB = (IPartsPosCodeUDB)MediationPartsPosCodeUDB.GetPartsPosCodeUDB();
                this._iPartsPosCodeDB = (IPartsPosCodeDB)MediationPartsPosCodeDB.GetPartsPosCodeDB();

                // リスト初期化
                this._blGoodsList = new ArrayList();

                // 2008.10.20 30413 犬飼 得意先情報のキャッシュ追加 >>>>>>START
                this._customerList = new ArrayList();
                // 2008.10.20 30413 犬飼 得意先情報のキャッシュ追加 <<<<<<END                
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iPartsPosCodeUDB = null;
                this._iPartsPosCodeDB = null;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iPartsPosCodeUDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// 部位コード読み込み処理
        /// </summary>
        /// <param name="partsPosCodeU">部位コードオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="partsPosCode">部位コード</param>
        /// <param name="tbsPartsCode">BLコード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 部位コード情報を読み込みます。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public int Read(out PartsPosCodeU partsPosCodeU, string enterpriseCode, int partsPosCode, int tbsPartsCode)
        {
            try
            {
                // キー情報の設定
                partsPosCodeU = null;
                PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();
                partsPosCodeUWork.EnterpriseCode = enterpriseCode;
                partsPosCodeUWork.SearchPartsPosCode = partsPosCode;
                partsPosCodeUWork.TbsPartsCode = tbsPartsCode;

                // 部位コードワーカークラスをオブジェクトに設定
                object paraObj = (object)partsPosCodeUWork;

                //部位コード読み込み
                int status = this._iPartsPosCodeUDB.Read(ref paraObj, 0);

                if (status == 0)
                {
                    // 読み込み結果を部位コードワーカークラスに設定
                    PartsPosCodeUWork wkPartsPosCodeUWork = (PartsPosCodeUWork)paraObj;
                    // 部位コードワーカークラスから部位コードクラスにコピー
                    partsPosCodeU = CopyToPartsPosCodeUFromPartsPosCodeUWork(wkPartsPosCodeUWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iPartsPosCodeUDB = null;
                this._iPartsPosCodeDB = null;
                //通信エラーは-1を戻す
                partsPosCodeU = null;
                return -1;
            }
        }

        /// <summary>
        /// 部位コード読み込み処理
        /// </summary>
        /// <param name="partsPosCodeU">部位コードオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="partsPosCode">部位コード</param>
        /// <param name="tbsPartsCode">BLコード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 部位コード情報を読み込みます。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public int Read(out PartsPosCodeU partsPosCodeU, string enterpriseCode,int customerCode, int partsPosCode, int tbsPartsCode)
        {
            try
            {
                // キー情報の設定
                partsPosCodeU = null;
                PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();
                partsPosCodeUWork.EnterpriseCode = enterpriseCode;
                partsPosCodeUWork.CustomerCode = customerCode;
                partsPosCodeUWork.SearchPartsPosCode = partsPosCode;
                partsPosCodeUWork.TbsPartsCode = tbsPartsCode;

                // 部位コードワーカークラスをオブジェクトに設定
                object paraObj = (object)partsPosCodeUWork;

                //部位コード読み込み
                int status = this._iPartsPosCodeUDB.Read(ref paraObj, 0);

                if (status == 0)
                {
                    // 読み込み結果を部位コードワーカークラスに設定
                    PartsPosCodeUWork wkPartsPosCodeUWork = (PartsPosCodeUWork)paraObj;
                    // 部位コードワーカークラスから部位コードクラスにコピー
                    partsPosCodeU = CopyToPartsPosCodeUFromPartsPosCodeUWork(wkPartsPosCodeUWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iPartsPosCodeUDB = null;
                this._iPartsPosCodeDB = null;
                //通信エラーは-1を戻す
                partsPosCodeU = null;
                return -1;
            }
        }

        /// <summary>
        /// 部位コードシリアライズ処理
        /// </summary>
        /// <param name="partsPosCodeU">シリアライズ対象部位コードクラス</param>
        /// <param name="fileName">シリアライズファイル名</param>
        /// <remarks>
        /// <br>Note       : 部位コードのシリアライズを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public void Serialize(PartsPosCodeU partsPosCodeU, string fileName)
        {
            // 部位コードクラスから部位コードワーカークラスにメンバコピー
            PartsPosCodeUWork partsPosCodeUWork = CopyToPartsPosCodeUWorkFromPartsPosCodeU(partsPosCodeU);

            // 部位コードワーカークラスをシリアライズ
            XmlByteSerializer.Serialize(partsPosCodeUWork, fileName);
        }

        /// <summary>
        /// 部位コードListシリアライズ処理
        /// </summary>
        /// <param name="arrPartsPosCodeU">シリアライズ対象部位コードListクラス</param>
        /// <param name="fileName">シリアライズファイル名</param>
        /// <remarks>
        /// <br>Note       : 部位コードList情報のシリアライズを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public void ListSerialize(ArrayList arrPartsPosCodeU, string fileName)
        {
            PartsPosCodeUWork[] partsPosCodeUWorks = new PartsPosCodeUWork[arrPartsPosCodeU.Count];

            for (int i = 0; i < arrPartsPosCodeU.Count; i++)
            {
                partsPosCodeUWorks[i] = CopyToPartsPosCodeUWorkFromPartsPosCodeU((PartsPosCodeU)arrPartsPosCodeU[i]);
            }

            // 部位コードワーカークラスをシリアライズ
            XmlByteSerializer.Serialize(partsPosCodeUWorks, fileName);
        }

        /// <summary>
        /// 部位コードクラスデシリアライズ処理
        /// </summary>
        /// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
        /// <returns>部位コードクラス</returns>
        /// <remarks>
        /// <br>Note       : 部位コードクラスをデシリアライズします。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public PartsPosCodeU Deserialize(string fileName)
        {
            PartsPosCodeU partsPosCodeU = null;

            // ファイル名を渡して部位コードワーククラスをデシリアライズする
            PartsPosCodeUWork partsPosCodeUWork = (PartsPosCodeUWork)XmlByteSerializer.Deserialize(fileName, typeof(PartsPosCodeUWork));

            // デシリアライズ結果を部位コードクラスへコピー
            if (partsPosCodeUWork != null) partsPosCodeU = CopyToPartsPosCodeUFromPartsPosCodeUWork(partsPosCodeUWork);

            return partsPosCodeU;
        }

        /// <summary>
        /// 部位コード登録・更新処理
        /// </summary>
        /// <param name="partsPosCodeUList">部位コードクラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部位コードの登録・更新を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public int Write(ref ArrayList partsPosCodeUList)
        {
            PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();
            ArrayList paraList = new ArrayList();
                
            foreach (PartsPosCodeU wkPartsPosCodeU in partsPosCodeUList)
            {
                // 部位コードクラスから部位コードワーククラスにメンバコピー
                partsPosCodeUWork = CopyToPartsPosCodeUWorkFromPartsPosCodeU(wkPartsPosCodeU);

                // 部位コードの登録・更新情報を設定
                paraList.Add(partsPosCodeUWork);            
            }
            
            object paraObj = paraList;

            int status = 0;
            try
            {
                // 部位コード書き込み
                status = this._iPartsPosCodeUDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    partsPosCodeUList.Clear();

                    foreach (PartsPosCodeUWork wkPartsPosCodeUWork in paraList)
                    {
                        PartsPosCodeU partsPosCodeU = new PartsPosCodeU();
                        // 部位コードワーククラスから部位コードクラスにメンバコピー
                        partsPosCodeU = this.CopyToPartsPosCodeUFromPartsPosCodeUWork((PartsPosCodeUWork)wkPartsPosCodeUWork);
                        partsPosCodeUList.Add(partsPosCodeU);
                    }
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iPartsPosCodeUDB = null;
                this._iPartsPosCodeDB = null;
                // 通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 部位コード名称論理削除処理
        /// </summary>
        /// <param name="partsPosCodeUList">部位コードオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部位コード情報の論理削除を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.20</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList partsPosCodeUList)
        {
            int status = 0;

            try
            {
                PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();
                ArrayList paraList = new ArrayList();

                foreach (PartsPosCodeU wkPartsPosCodeU in partsPosCodeUList)
                {
                    // 部位コードクラスから部位コードワーククラスにメンバコピー
                    partsPosCodeUWork = CopyToPartsPosCodeUWorkFromPartsPosCodeU(wkPartsPosCodeU);
                    // 部位コードの論理削除情報を設定
                    paraList.Add(partsPosCodeUWork);
                }

                object paraObj = paraList;

                // 部位コードクラス論理削除
                status = this._iPartsPosCodeUDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    partsPosCodeUList.Clear();

                    foreach (PartsPosCodeUWork wkPartsPosCodeUWork in paraList)
                    {
                        PartsPosCodeU partsPosCodeU = new PartsPosCodeU();
                        // 部位コードワーククラスから部位コードクラスにメンバコピー
                        partsPosCodeU = this.CopyToPartsPosCodeUFromPartsPosCodeUWork((PartsPosCodeUWork)wkPartsPosCodeUWork);
                        partsPosCodeUList.Add(partsPosCodeU);
                    }
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iPartsPosCodeUDB = null;
                this._iPartsPosCodeDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 部位コード物理削除処理
        /// </summary>
        /// <param name="partsPosCodeUList">部位コードオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部位コード情報の物理削除を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.20</br>
        /// </remarks>
        public int Delete(ArrayList partsPosCodeUList)
        {
            try
            {
                PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();
                ArrayList paraList = new ArrayList();

                foreach (PartsPosCodeU wkPartsPosCodeU in partsPosCodeUList)
                {
                    // 部位コードクラスから部位コードワーククラスにメンバコピー
                    partsPosCodeUWork = CopyToPartsPosCodeUWorkFromPartsPosCodeU(wkPartsPosCodeU);

                    // 部位コードの登録・更新情報を設定
                    paraList.Add(partsPosCodeUWork);
                }

                object paraObj = paraList;

                // 部位コード物理削除
                int status = this._iPartsPosCodeUDB.Delete(paraObj);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iPartsPosCodeUDB = null;
                this._iPartsPosCodeDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 部位コード論理削除復活処理
        /// </summary>
        /// <param name="partsPosCodeUList">部位コード名称オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部位コード情報の復活を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.20</br>
        /// </remarks>
        public int Revival(ref ArrayList partsPosCodeUList)
        {
            try
            {
                PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();
                ArrayList paraList = new ArrayList();

                foreach (PartsPosCodeU wkPartsPosCodeU in partsPosCodeUList)
                {
                    // 部位コードクラスから部位コードワーククラスにメンバコピー
                    partsPosCodeUWork = CopyToPartsPosCodeUWorkFromPartsPosCodeU(wkPartsPosCodeU);
                    // 部位コードの復活情報を設定
                    paraList.Add(partsPosCodeUWork);
                }

                object paraobj = paraList;

                // 復活処理
                int status = this._iPartsPosCodeUDB.RevivalLogicalDelete(ref paraobj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraobj;
                    partsPosCodeUList.Clear();

                    foreach (PartsPosCodeUWork wkPartsPosCodeUWork in paraList)
                    {
                        PartsPosCodeU partsPosCodeU = new PartsPosCodeU();
                        // 部位コードワーククラスから部位コードクラスにメンバコピー
                        partsPosCodeU = this.CopyToPartsPosCodeUFromPartsPosCodeUWork((PartsPosCodeUWork)wkPartsPosCodeUWork);
                        partsPosCodeUList.Add(partsPosCodeU);
                    }
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iPartsPosCodeUDB = null;
                this._iPartsPosCodeDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// 部位コードマスタ検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="belongPartsPosCode">部位コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 取得結果をDataSetで返します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.06.17</br>
        /// </remarks>
        public int Search(ref DataSet ds,int belongPartsPosCode, string enterpriseCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;
            int retTotalCnt;
            bool nextData;
            // 部位コードマスタ（提供）サーチ
            status = SearchPartsPosCodeOfrProc(belongPartsPosCode, ref retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, 0, null);
            if (status != 0)
            {
                return status;
            }

            ArrayList wkList = retList.Clone() as ArrayList;
            SortedList wkSort = new SortedList();

            // --- [全て] --- //
            // そのまま全件返す
            foreach (PartsPosCodeU wkPartsPosCodeU in wkList)
            {
                // 論理削除データとBLコードがゼロは対象外
                if ((wkPartsPosCodeU.LogicalDeleteCode == 0) && (wkPartsPosCodeU.TbsPartsCode != 0))
                {
                    string key = wkPartsPosCodeU.SearchPartsPosCode.ToString("d2") + wkPartsPosCodeU.PosDispOrder.ToString("d4") + wkPartsPosCodeU.TbsPartsCode.ToString("d8");
                    wkSort.Add(key, wkPartsPosCodeU);
                }
            }

            PartsPosCodeU[] partsPosCodeUs = new PartsPosCodeU[wkSort.Count];

            // データを元に戻す
            for (int i = 0; i < wkSort.Count; i++)
            {
                partsPosCodeUs[i] = (PartsPosCodeU)wkSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(partsPosCodeUs);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

        /// <summary>
        /// 部位コード全検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部位コードの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            int customerCode = 0;
            int partsPosCode = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retList.Clear();
            retTotalCnt = 0;

            // ユーザー
            status = SearchPartsPosCodeUProc(customerCode, partsPosCode, ref list, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, 0, null);

            // 2008.10.20 30413 犬飼 提供データは読み込まない >>>>>>START
            //switch (status)
            //{
            //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
            //    case (int)ConstantManagement.DB_Status.ctDB_EOF:
            //        break;
            //    default:
            //        return status;
            //}

            //// 提供
            //status = SearchPartsPosCodeOfrProc(partsPosCode, ref list, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, 0, null);

            //// 検索結果件数が0件以外であればステータスを0(正常)に設定
            //if (retTotalCnt != 0)
            //{
            //    status = 0;
            //}
            // 2008.10.20 30413 犬飼 提供データは読み込まない <<<<<<END
            
            retList = list;

            return status;
        }

        /// <summary>
        /// 部位コード検索処理（論理削除含む）
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="partsPosCode">部位コード</param>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部位コードの検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.20</br>
        /// </remarks>
        public int SearchSelect(int customerCode, int partsPosCode, out ArrayList retList, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retList.Clear();
            retTotalCnt = 0;

            // ユーザー
            status = SearchPartsPosCodeUProc(customerCode, partsPosCode, ref list, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, 0, null);

            retList = list;

            return status;
        }

        /// <summary>
        /// 得意先略称取得処理(Public Methods)
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>得意先略称</returns>
        /// <remarks>
        /// <br>Note       : 得意先略称を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/10/21</br>
        /// </remarks>
        public void SerachCustomerInfo(int customerCode, string enterpriseCode, out string customerSnm)
        {
            // 得意先略称の取得
            customerSnm = this.GetCustomerSnm(customerCode, enterpriseCode);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// クラスメンバーコピー処理（部位コードワーククラス⇒部位コードクラス）
        /// </summary>
        /// <param name="partsPosCodeUWork">部位コードワーククラス</param>
        /// <returns>部位コードクラス</returns>
        /// <remarks>
        /// <br>Note       : 部位コードワーククラスから部位コードクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private PartsPosCodeU CopyToPartsPosCodeUFromPartsPosCodeUWork(PartsPosCodeUWork partsPosCodeUWork)
        {
            PartsPosCodeU partsPosCodeU = new PartsPosCodeU();

            partsPosCodeU.CreateDateTime = partsPosCodeUWork.CreateDateTime;
            partsPosCodeU.UpdateDateTime = partsPosCodeUWork.UpdateDateTime;
            partsPosCodeU.EnterpriseCode = partsPosCodeUWork.EnterpriseCode;
            partsPosCodeU.FileHeaderGuid = partsPosCodeUWork.FileHeaderGuid;
            partsPosCodeU.UpdEmployeeCode = partsPosCodeUWork.UpdEmployeeCode;
            partsPosCodeU.UpdAssemblyId1 = partsPosCodeUWork.UpdAssemblyId1;
            partsPosCodeU.UpdAssemblyId2 = partsPosCodeUWork.UpdAssemblyId2;
            partsPosCodeU.LogicalDeleteCode = partsPosCodeUWork.LogicalDeleteCode;

            // 2008.10.20 30413 犬飼 得意先の追加 >>>>>>START
            partsPosCodeU.SectionCode = partsPosCodeUWork.SectionCode;                      // 拠点コード(未使用)
            partsPosCodeU.CustomerCode = partsPosCodeUWork.CustomerCode;                    // 得意先コード
            partsPosCodeU.CustomerSnm = GetCustomerSnm(partsPosCodeUWork.CustomerCode, partsPosCodeUWork.EnterpriseCode);   // 得意先略称
            // 2008.10.20 30413 犬飼 得意先の追加 <<<<<<END
            partsPosCodeU.SearchPartsPosCode = partsPosCodeUWork.SearchPartsPosCode;        // 検索部位コード
            partsPosCodeU.SearchPartsPosName = partsPosCodeUWork.SearchPartsPosName;        // 検索部位コード名称
            partsPosCodeU.PosDispOrder = partsPosCodeUWork.PosDispOrder;                    // 検索部位表示順位
            partsPosCodeU.TbsPartsCode = partsPosCodeUWork.TbsPartsCode;                    // BLコード
            partsPosCodeU.TbsPartsCdDerivedNo = partsPosCodeUWork.TbsPartsCdDerivedNo;      // BLコード枝番
            partsPosCodeU.TbsPartsName = GetTbsPartsName(partsPosCodeUWork.TbsPartsCode, partsPosCodeUWork.EnterpriseCode);   // BL名称
            partsPosCodeU.Division = 0;
            partsPosCodeU.DivisionName = "ユーザー";

            return partsPosCodeU;
        }

        /// <summary>
        /// クラスメンバーコピー処理（部位コードクラス⇒部位コードワーククラス）
        /// </summary>
        /// <param name="partsPosCodeU">部位コードワーククラス</param>
        /// <returns>部位コードクラス</returns>
        /// <remarks>
        /// <br>Note       : 部位コードクラスから部位コードワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private PartsPosCodeUWork CopyToPartsPosCodeUWorkFromPartsPosCodeU(PartsPosCodeU partsPosCodeU)
        {
            PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();

            partsPosCodeUWork.CreateDateTime = partsPosCodeU.CreateDateTime;
            partsPosCodeUWork.UpdateDateTime = partsPosCodeU.UpdateDateTime;
            partsPosCodeUWork.EnterpriseCode = partsPosCodeU.EnterpriseCode;
            partsPosCodeUWork.FileHeaderGuid = partsPosCodeU.FileHeaderGuid;
            partsPosCodeUWork.UpdEmployeeCode = partsPosCodeU.UpdEmployeeCode;
            partsPosCodeUWork.UpdAssemblyId1 = partsPosCodeU.UpdAssemblyId1;
            partsPosCodeUWork.UpdAssemblyId2 = partsPosCodeU.UpdAssemblyId2;
            partsPosCodeUWork.LogicalDeleteCode = partsPosCodeU.LogicalDeleteCode;

            // 2008.10.20 30413 犬飼 得意先の追加 >>>>>>START
            partsPosCodeUWork.CustomerCode = partsPosCodeU.CustomerCode;                    // 得意先コード
            // 2008.10.20 30413 犬飼 得意先の追加 <<<<<<END
            partsPosCodeUWork.SearchPartsPosCode = partsPosCodeU.SearchPartsPosCode;        // 検索部位コード
            partsPosCodeUWork.SearchPartsPosName = partsPosCodeU.SearchPartsPosName;        // 検索部位コード名称
            partsPosCodeUWork.PosDispOrder = partsPosCodeU.PosDispOrder;                    // 検索部位表示順位
            partsPosCodeUWork.TbsPartsCode = partsPosCodeU.TbsPartsCode;                    // BLコード
            partsPosCodeUWork.TbsPartsCdDerivedNo = partsPosCodeU.TbsPartsCdDerivedNo;      // BLコード枝番
            
            return partsPosCodeUWork;
        }

        /// <summary>
        /// クラスメンバーコピー処理（部位コード（提供）ワーククラス⇒部位コードクラス）
        /// </summary>
        /// <param name="partsPosCodeWork">部位コード（提供）ワーククラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>部位コードクラス</returns>
        /// <remarks>
        /// <br>Note       : 部位コード（提供）ワーククラスから部位コードクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private PartsPosCodeU CopyToPartsPosCodeUFromPartsPosCodeWork(PartsPosCodeWork partsPosCodeWork, string enterpriseCode)
        {
            PartsPosCodeU partsPosCodeU = new PartsPosCodeU();

            partsPosCodeU.SearchPartsPosCode = partsPosCodeWork.SearchPartsPosCode;         // 検索部位コード
            partsPosCodeU.SearchPartsPosName = partsPosCodeWork.SearchPartsPosName;         // 検索部位コード名称
            partsPosCodeU.PosDispOrder = partsPosCodeWork.PosDispOrder;                     // 検索部位表示順位
            partsPosCodeU.TbsPartsCode = partsPosCodeWork.TbsPartsCode;                     // BLコード
            partsPosCodeU.TbsPartsCdDerivedNo = partsPosCodeWork.TbsPartsCdDerivedNo;       // BLコード枝番
            partsPosCodeU.TbsPartsName = GetTbsPartsName(partsPosCodeWork.TbsPartsCode, enterpriseCode);    // BL名称
            partsPosCodeU.Division = 1;
            partsPosCodeU.DivisionName = "提供";

            return partsPosCodeU;
        }

        /// <summary>
        /// クラスメンバーコピー処理（部位コードクラス⇒部位コード（提供）ワーククラス）
        /// </summary>
        /// <param name="partsPosCodeU">部位コードワーククラス</param>
        /// <returns>部位コード（提供）クラス</returns>
        /// <remarks>
        /// <br>Note       : 部位コードクラスから部位コード（提供）ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private PartsPosCodeWork CopyToPartsPosCodeWorkFromPartsPosCodeU(PartsPosCodeU partsPosCodeU)
        {
            PartsPosCodeWork partsPosCodeWork = new PartsPosCodeWork();

            partsPosCodeWork.SearchPartsPosCode = partsPosCodeU.SearchPartsPosCode;         // 検索部位コード
            partsPosCodeWork.SearchPartsPosName = partsPosCodeU.SearchPartsPosName;         // 検索部位コード名称
            partsPosCodeWork.PosDispOrder = partsPosCodeU.PosDispOrder;                     // 検索部位表示順位
            partsPosCodeWork.TbsPartsCode = partsPosCodeU.TbsPartsCode;                     // BLコード
            partsPosCodeWork.TbsPartsCdDerivedNo = partsPosCodeU.TbsPartsCdDerivedNo;       // BLコード枝番
            
            return partsPosCodeWork;
        }

        /// <summary>
        /// 部位コード検索処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="partsPosCode">部位コード</param>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevPartsPosCodeU">前回最終部位コードデータオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部位コードの検索処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private int SearchPartsPosCodeUProc(Int32 customerCode, Int32 partsPosCode, ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, PartsPosCodeU prevPartsPosCodeU)
        {
            PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();

            // 次データ有無初期化
            nextData = false;
            // 読込対象データ総件数0で初期化
            retTotalCnt = 0;

            int status = 0;

            ArrayList workList = new ArrayList();
            object retObj = workList;

            if (retList.Count == 0)
            {
                // 抽出条件設定
                partsPosCodeUWork.CustomerCode = customerCode;
                partsPosCodeUWork.SearchPartsPosCode = partsPosCode;
                partsPosCodeUWork.EnterpriseCode = enterpriseCode;

                // 部位コードワーカークラスをオブジェクトに設定
                object paraObj = (object)partsPosCodeUWork;

                // 全件読込
                status = this._iPartsPosCodeUDB.Search(ref retObj, paraObj, 0, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        workList = retObj as ArrayList;
                        if (workList != null)
                        {
                            foreach (PartsPosCodeUWork wkPartsPosCodeUWork in workList)
                            {
                                // リモートパラメータデータ ⇒ データクラス
                                PartsPosCodeU wkPartsPosCodeU = CopyToPartsPosCodeUFromPartsPosCodeUWork(wkPartsPosCodeUWork);
                                // データクラスを読込結果へコピー
                                retList.Add(wkPartsPosCodeU);
                                
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        return status;
                }
            }

            // 全件リードの場合は戻り値の件数をセット
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        /// <summary>
        /// 部位コード（提供）検索処理
        /// </summary>
        /// <param name="partsPosCode">部位コード</param>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevPartsPosCodeU">前回最終部位コードマスタ（提供）データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部位コードマスタ（提供）の検索処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private int SearchPartsPosCodeOfrProc(Int32 partsPosCode, ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, PartsPosCodeU prevPartsPosCodeU)
        {
            PartsPosCodeWork partsPosCodeWork = new PartsPosCodeWork();

            // 次データ有無初期化
            nextData = false;
            // 読込対象データ総件数0で初期化
            retTotalCnt = 0;

            int status = 0;

            ArrayList workList = new ArrayList();
            object retObj = workList;
            SortedList sortWk = new SortedList();

            // セキュリティレベルキー指定
            partsPosCodeWork.SearchPartsPosCode = partsPosCode;

            // USB確認
            // 大型提供区分
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BigCarOfferData) > 0)
            {
                partsPosCodeWork.BigCarOfferDiv = 1;
            }
            else
            {
                partsPosCodeWork.BigCarOfferDiv = 0;
            }

            // 検索タイプ
            // 初期値は-1
            partsPosCodeWork.SearchPartsType = -1;
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BasicOfferData) > 0)
            {
                // 基本
                partsPosCodeWork.SearchPartsType = 0;
            }
            //if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_ExtOfferData) > 0)
            //{
            //    // 拡張
            //    partsPosCodeWork.SearchPartsType = 10;
            //}
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_OutsideOfferData) > 0)
            {
                // 外装
                partsPosCodeWork.SearchPartsType = 20;
            }

            // 検索タイプが-1の場合、提供マスタを読み込まないで終了
            if (partsPosCodeWork.SearchPartsType == -1)
            {
                return status;
            }

            // 部位コード（提供）ワーカークラスをオブジェクトに設定
            object paraObj = (object)partsPosCodeWork;

            // 全件読込
            status = this._iPartsPosCodeDB.Search(out retObj, paraObj);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    workList = retObj as ArrayList;
                    if (workList != null)
                    {
                        foreach (PartsPosCodeWork wkPartsPosCodeWork in workList)
                        {
                            // リモートパラメータデータ ⇒ データクラス
                            PartsPosCodeU wkPartsPosCodeU = CopyToPartsPosCodeUFromPartsPosCodeWork(wkPartsPosCodeWork, enterpriseCode);
                            // データクラスを読込結果へコピー
                            retList.Add(wkPartsPosCodeU);
                        }
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    return status;
            }

            // 全件リードの場合は戻り値の件数をセット
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        /// <summary>
        /// ＢＬ名称取得処理
        /// </summary>
        /// <param name="tbsPartsCode">ＢＬコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ＢＬ名称</returns>
        /// <remarks>
        /// <br>Note       : ＢＬ名称を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/06/20</br>
        /// </remarks>
        private string GetTbsPartsName(int tbsPartsCode, string enterpriseCode)
        {
            string tbsPartsName = "";

            int status;
            ArrayList retList;
            BLGoodsCdAcs blGoodsCdAcs = new BLGoodsCdAcs();

            try
            {
                if (this._blGoodsList.Count == 0)
                {
                    status = blGoodsCdAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        if (retList.Count <= 0)
                        {
                            return tbsPartsName;
                        }

                        foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                        {
                            this._blGoodsList.Add(blGoodsCdUMnt);
                        }
                    }
                }

                foreach (BLGoodsCdUMnt blGoodsCdUMnt in this._blGoodsList)
                {
                    if (blGoodsCdUMnt.BLGoodsCode == tbsPartsCode)
                    {
                        tbsPartsName = blGoodsCdUMnt.BLGoodsFullName.Trim();
                        return tbsPartsName;
                    }
                }
            }
            catch
            {
                tbsPartsName = "";
            }

            return tbsPartsName;
        }

        /// <summary>
        /// 得意先略称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>得意先略称</returns>
        /// <remarks>
        /// <br>Note       : 得意先略称を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/10/20</br>
        /// </remarks>
        private string GetCustomerSnm(int customerCode, string enterpriseCode)
        {
            string customerSnm = "";

            int status;
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();

            CustomerSearchRet[] customerSearchRetArray;
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = enterpriseCode;

            try
            {
                if (this._customerList.Count == 0)
                {
                    status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);
                    if (status == 0)
                    {
                        if (customerSearchRetArray.Length <= 0)
                        {
                            return customerSnm;
                        }

                        foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
                        {
                            // 論理削除データは読み込まない
                            if (customerSearchRet.LogicalDeleteCode != 1)
                            {
                                this._customerList.Add(customerSearchRet);
                            }
                        }
                    }
                }

                foreach (CustomerSearchRet customerSearchRet in this._customerList)
                {
                    if (customerSearchRet.CustomerCode == customerCode)
                    {
                        customerSnm = customerSearchRet.Snm.Trim();
                        return customerSnm;
                    }
                }
            }
            catch
            {
                customerSnm = "";
            }

            return customerSnm;
        }

        #endregion

        #region Guid Methods

        /// <summary>
        /// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note		: 汎用ガイド設定用データを取得します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.06.17</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            int partsPosCode = 0;
            string enterpriseCode = "";

            // 部位コード、企業コード設定有り
            if ((inParm.ContainsKey("SearchPartsPosCode")) && (inParm.ContainsKey("EnterpriseCode")))
            {
                partsPosCode = (int)inParm["SearchPartsPosCode"];
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            // 部位コード、企業コード設定無し
            else
            {
                // 有り得ないのでエラー
                return status;
            }

            // 部位コードマスタテーブル読込み
            status = Search(ref guideList, partsPosCode, enterpriseCode);

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

        /// <summary>
        /// 部位コードマスタガイド起動処理
        /// </summary>
        /// <param name="partsPosCode">部位コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="partsPosCodeU">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: 部位コードマスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.06.17</br>
        /// </remarks>
        public int ExecuteGuid(int partsPosCode, string enterpriseCode, out PartsPosCodeU partsPosCodeU)
        {
            int status = -1;
            partsPosCodeU = new PartsPosCodeU();

            TableGuideParent tableGuideParent = new TableGuideParent("PARTPOSCODEGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 部位コード
            inObj.Add("SearchPartsPosCode", partsPosCode);
            // 企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                // 検索部位コード
                string strCode = retObj["SearchPartsPosCode"].ToString();
                partsPosCodeU.SearchPartsPosCode = int.Parse(strCode);

                // 検索部位コード名称
                partsPosCodeU.SearchPartsPosName = retObj["SearchPartsPosName"].ToString();

                // 検索部位表示順位
                strCode = retObj["PosDispOrder"].ToString();
                partsPosCodeU.PosDispOrder = int.Parse(strCode);

                // BLコード
                strCode = retObj["TbsPartsCode"].ToString();
                partsPosCodeU.TbsPartsCode = int.Parse(strCode);
                
                // BLコード枝番
                strCode = retObj["TbsPartsCdDerivedNo"].ToString();
                partsPosCodeU.TbsPartsCdDerivedNo = int.Parse(strCode);

                // BL名称
                partsPosCodeU.TbsPartsName = retObj["TbsPartsName"].ToString();
                status = 0;
            }
            // キャンセル
            else
            {
                status = 1;
            }

            return status;
        }

        #endregion
    }
}
