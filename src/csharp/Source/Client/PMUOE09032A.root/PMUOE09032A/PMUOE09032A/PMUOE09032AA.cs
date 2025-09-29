using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// UOEガイド名称マスタ アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOEガイド名称マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2008.06.30</br>
    /// <br></br>
    /// </remarks>
    public class UOEGuideNameAcs : IGeneralGuideData
    {
        #region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        // UOEガイド名称マスタ
        private IUOEGuideNameDB _iUOEGuideNameDB = null;

        #endregion

        #region Constructor

        /// <summary>
        /// UOEガイド名称マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOEガイド名称マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public UOEGuideNameAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iUOEGuideNameDB = (IUOEGuideNameDB)MediationUOEGuideNameDB.GetUOEGuideNameDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOEGuideNameDB = null;
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
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iUOEGuideNameDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// UOEガイド名称マスタ読み込み処理
        /// </summary>
        /// <param name="uoeGuideName">UOEガイド名称オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="uoeGuideDivCd">UOEガイド区分</param>
        /// <param name="uoeSupplierCd">UOE発注先コード</param>
        /// <param name="uoeGuideCode">UOEガイドコード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : UOEガイド名称情報を読み込みます。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int Read(out UOEGuideName uoeGuideName, string enterpriseCode, int uoeGuideDivCd, int uoeSupplierCd, string uoeGuideCode, string sectionCode)
        {
            try
            {
                // キー情報の設定
                uoeGuideName = null;
                UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();
                uoeGuideNameWork.EnterpriseCode = enterpriseCode;
                uoeGuideNameWork.UOEGuideDivCd = uoeGuideDivCd;
                uoeGuideNameWork.UOESupplierCd = uoeSupplierCd;
                uoeGuideNameWork.UOEGuideCode = uoeGuideCode;
                uoeGuideNameWork.SectionCode = sectionCode;
                // UOEガイド名称ワーカークラスをオブジェクトに設定
                object paraObj = (object)uoeGuideNameWork;

                //UOEガイド名称マスタ読み込み
                int status = this._iUOEGuideNameDB.Read(ref paraObj, 0);

                if (status == 0)
                {
                    // 読み込み結果をUOEガイド名称ワーカークラスに設定
                    UOEGuideNameWork wkUOEGuideNameWork = (UOEGuideNameWork)paraObj;
                    // UOEガイド名称ワーカークラスからUOEガイド名称クラスにコピー
                    uoeGuideName = CopyToUOEGuideNameFromUOEGuideNameWork(wkUOEGuideNameWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOEGuideNameDB = null;
                //通信エラーは-1を戻す
                uoeGuideName = null;
                return -1;
            }
        }

        /// <summary>
        /// UOEガイド名称シリアライズ処理
        /// </summary>
        /// <param name="uoeGuideName">シリアライズ対象UOEガイド名称クラス</param>
        /// <param name="fileName">シリアライズファイル名</param>
        /// <remarks>
        /// <br>Note       : UOEガイド名称のシリアライズを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public void Serialize(UOEGuideName uoeGuideName, string fileName)
        {
            // UOEガイド名称クラスからUOEガイド名称ワーカークラスにメンバコピー
            UOEGuideNameWork uoeGuideNameWork = CopyToUOEGuideNameWorkFromUOEGuideName(uoeGuideName);

            // UOEガイド名称ワーカークラスをシリアライズ
            XmlByteSerializer.Serialize(uoeGuideNameWork, fileName);
        }

        /// <summary>
        /// UOEガイド名称Listシリアライズ処理
        /// </summary>
        /// <param name="uoeGuideNameList">シリアライズ対象UOEガイド名称Listクラス</param>
        /// <param name="fileName">シリアライズファイル名</param>
        /// <remarks>
        /// <br>Note       : UOEガイド名称List情報のシリアライズを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public void ListSerialize(ArrayList uoeGuideNameList, string fileName)
        {
            UOEGuideNameWork[] uoeGuideNameWorks = new UOEGuideNameWork[uoeGuideNameList.Count];

            for (int i = 0; i < uoeGuideNameList.Count; i++)
            {
                uoeGuideNameWorks[i] = CopyToUOEGuideNameWorkFromUOEGuideName((UOEGuideName)uoeGuideNameList[i]);
            }

            // UOEガイド名称ワーカークラスをシリアライズ
            XmlByteSerializer.Serialize(uoeGuideNameWorks, fileName);
        }

        /// <summary>
        /// UOEガイド名称クラスデシリアライズ処理
        /// </summary>
        /// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
        /// <returns>UOEガイド名称クラス</returns>
        /// <remarks>
        /// <br>Note       : UOEガイド名称クラスをデシリアライズします。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public UOEGuideName Deserialize(string fileName)
        {
            UOEGuideName uoeGuideName = null;

            // ファイル名を渡してUOEガイド名称ワーククラスをデシリアライズする
            UOEGuideNameWork uoeGuideNameWork = (UOEGuideNameWork)XmlByteSerializer.Deserialize(fileName, typeof(UOEGuideNameWork));

            // デシリアライズ結果をUOEガイド名称クラスへコピー
            if (uoeGuideNameWork != null) uoeGuideName = CopyToUOEGuideNameFromUOEGuideNameWork(uoeGuideNameWork);

            return uoeGuideName;
        }

        /// <summary>
        /// UOEガイド名称登録・更新処理
        /// </summary>
        /// <param name="uoeGuideName">UOEガイド名称クラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOEガイド名称の登録・更新を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int Write(ref UOEGuideName uoeGuideName)
        {
            UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();
            ArrayList paraList = new ArrayList();

            // UOEガイド名称クラスからUOEガイド名称ワーククラスにメンバコピー
            uoeGuideNameWork = CopyToUOEGuideNameWorkFromUOEGuideName(uoeGuideName);

            // UOEガイド名称の登録・更新情報を設定
            paraList.Add(uoeGuideNameWork);

            object paraObj = paraList;

            int status = 0;
            try
            {
                // UOEガイド名称書き込み
                status = this._iUOEGuideNameDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;

                    uoeGuideName = new UOEGuideName();

                    // UOEガイド名称ワーククラスからUOEガイド名称クラスにメンバコピー
                    uoeGuideName = this.CopyToUOEGuideNameFromUOEGuideNameWork((UOEGuideNameWork)paraList[0]);
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iUOEGuideNameDB = null;
                // 通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// UOEガイド名称論理削除処理
        /// </summary>
        /// <param name="uoeGuideName">UOEガイド名称オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOEガイド名称情報の論理削除を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int LogicalDelete(ref UOEGuideName uoeGuideName)
        {
            int status = 0;

            try
            {
                UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();
                ArrayList paraList = new ArrayList();

                // UOEガイド名称クラスからUOEガイド名称ワーククラスにメンバコピー
                uoeGuideNameWork = CopyToUOEGuideNameWorkFromUOEGuideName(uoeGuideName);
                // UOEガイド名称の論理削除情報を設定
                paraList.Add(uoeGuideNameWork);

                object paraObj = paraList;

                // UOEガイド名称クラス論理削除
                status = this._iUOEGuideNameDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;

                    uoeGuideName = new UOEGuideName();
                    // UOEガイド名称ワーククラスからUOEガイド名称クラスにメンバコピー
                    uoeGuideName = this.CopyToUOEGuideNameFromUOEGuideNameWork((UOEGuideNameWork)paraList[0]);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOEGuideNameDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// UOEガイド名称物理削除処理
        /// </summary>
        /// <param name="uoeGuideName">UOEガイド名称オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOEガイド名称情報の物理削除を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int Delete(UOEGuideName uoeGuideName)
        {
            try
            {
                UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();
                ArrayList paraList = new ArrayList();

                // UOEガイド名称クラスからUOEガイド名称ワーククラスにメンバコピー
                uoeGuideNameWork = CopyToUOEGuideNameWorkFromUOEGuideName(uoeGuideName);
                // UOEガイド名称の物理削除情報を設定
                paraList.Add(uoeGuideNameWork);

                object paraObj = paraList;

                // UOEガイド名称物理削除
                int status = this._iUOEGuideNameDB.Delete(paraObj);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOEGuideNameDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// UOEガイド名称論理削除復活処理
        /// </summary>
        /// <param name="uoeGuideName">UOEガイド名称名称オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOEガイド名称情報の復活を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int Revival(ref UOEGuideName uoeGuideName)
        {
            try
            {
                UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();
                ArrayList paraList = new ArrayList();

                // UOEガイド名称クラスからUOEガイド名称ワーククラスにメンバコピー
                uoeGuideNameWork = CopyToUOEGuideNameWorkFromUOEGuideName(uoeGuideName);
                // UOEガイド名称の復活情報を設定
                paraList.Add(uoeGuideNameWork);

                object paraobj = paraList;

                // 復活処理
                int status = this._iUOEGuideNameDB.RevivalLogicalDelete(ref paraobj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraobj;

                    uoeGuideName = new UOEGuideName();
                    // UOEガイド名称ワーククラスからUOEガイド名称クラスにメンバコピー
                    uoeGuideName = this.CopyToUOEGuideNameFromUOEGuideNameWork((UOEGuideNameWork)paraList[0]);
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOEGuideNameDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// UOEガイド名称マスタ検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="inUOEGuideName">検索条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 取得結果をDataSetで返します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.06.30</br>
        /// </remarks>
        public int Search(ref DataSet ds, UOEGuideName inUOEGuideName)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // UOEガイド名称マスタサーチ
            status = SearchAll(out retList, inUOEGuideName);
            if (status != 0)
            {
                return status;
            }

            ArrayList wkList = retList.Clone() as ArrayList;
            SortedList wkSort = new SortedList();

            // --- [全て] --- //
            // そのまま全件返す
            foreach (UOEGuideName wkUOEGuideName in wkList)
            {
                if (wkUOEGuideName.LogicalDeleteCode == 0)
                {
                    string key = wkUOEGuideName.SectionCode.Trim() +wkUOEGuideName.UOESupplierCd.ToString("d06") + wkUOEGuideName.UOEGuideDivCd.ToString("d02") + wkUOEGuideName.UOEGuideCode;
                    wkSort.Add(key, wkUOEGuideName);
                }
            }

            UOEGuideName[] uoeGuideNames = new UOEGuideName[wkSort.Count];

            // データを元に戻す
            for (int i = 0; i < wkSort.Count; i++)
            {
                uoeGuideNames[i] = (UOEGuideName)wkSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(uoeGuideNames);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

        /// <summary>
        /// UOEガイド名称検索処理（論理削除含まない）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="inUOEGuideName">検索条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : UOEガイド名称の検索処理を行います。論理削除データは抽出対象に含まれません。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.07.17</br>
        /// </remarks>
        public int Search(out ArrayList retList, UOEGuideName inUOEGuideName)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retTotalCnt = 0;

            // UOEガイド名称マスタ（論理削除含まない）
            status = SearchUOEGuideName(ref list, out retTotalCnt, out nextData, inUOEGuideName, ConstantManagement.LogicalMode.GetData0, 0);

            retList = list;

            return status;
        }

        /// <summary>
        /// UOEガイド名称検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="inUOEGuideName">検索条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOEガイド名称の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, UOEGuideName inUOEGuideName)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retTotalCnt = 0;

            // UOEガイド名称マスタ
            status = SearchUOEGuideName(ref list, out retTotalCnt, out nextData, inUOEGuideName, ConstantManagement.LogicalMode.GetDataAll, 0);

            retList = list;

            return status;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// クラスメンバーコピー処理（UOEガイド名称ワーククラス⇒UOEガイド名称クラス）
        /// </summary>
        /// <param name="uoeGuideNameWork">UOEガイド名称ワーククラス</param>
        /// <returns>UOEガイド名称クラス</returns>
        /// <remarks>
        /// <br>Note       : UOEガイド名称ワーククラスからUOEガイド名称クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private UOEGuideName CopyToUOEGuideNameFromUOEGuideNameWork(UOEGuideNameWork uoeGuideNameWork)
        {
            UOEGuideName uoeGuideName = new UOEGuideName();

            uoeGuideName.CreateDateTime = uoeGuideNameWork.CreateDateTime;
            uoeGuideName.UpdateDateTime = uoeGuideNameWork.UpdateDateTime;
            uoeGuideName.EnterpriseCode = uoeGuideNameWork.EnterpriseCode;
            uoeGuideName.FileHeaderGuid = uoeGuideNameWork.FileHeaderGuid;
            uoeGuideName.UpdEmployeeCode = uoeGuideNameWork.UpdEmployeeCode;
            uoeGuideName.UpdAssemblyId1 = uoeGuideNameWork.UpdAssemblyId1;
            uoeGuideName.UpdAssemblyId2 = uoeGuideNameWork.UpdAssemblyId2;
            uoeGuideName.LogicalDeleteCode = uoeGuideNameWork.LogicalDeleteCode;

            uoeGuideName.UOEGuideDivCd = uoeGuideNameWork.UOEGuideDivCd;                    // UOEガイド区分
            uoeGuideName.UOESupplierCd = uoeGuideNameWork.UOESupplierCd;                    // UOE発注先コード
            uoeGuideName.UOEGuideCode = uoeGuideNameWork.UOEGuideCode;                      // UOEガイドコード
            uoeGuideName.UOEGuideNm = uoeGuideNameWork.UOEGuideName;                        // UOEガイド名称
            uoeGuideName.SectionCode = uoeGuideNameWork.SectionCode;
            
            return uoeGuideName;
        }

        /// <summary>
        /// クラスメンバーコピー処理（UOEガイド名称クラス⇒UOEガイド名称ワーククラス）
        /// </summary>
        /// <param name="uoeGuideName">UOEガイド名称ワーククラス</param>
        /// <returns>UOEガイド名称クラス</returns>
        /// <remarks>
        /// <br>Note       : UOEガイド名称クラスからUOEガイド名称ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private UOEGuideNameWork CopyToUOEGuideNameWorkFromUOEGuideName(UOEGuideName uoeGuideName)
        {
            UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();

            uoeGuideNameWork.CreateDateTime = uoeGuideName.CreateDateTime;
            uoeGuideNameWork.UpdateDateTime = uoeGuideName.UpdateDateTime;
            uoeGuideNameWork.EnterpriseCode = uoeGuideName.EnterpriseCode;
            uoeGuideNameWork.FileHeaderGuid = uoeGuideName.FileHeaderGuid;
            uoeGuideNameWork.UpdEmployeeCode = uoeGuideName.UpdEmployeeCode;
            uoeGuideNameWork.UpdAssemblyId1 = uoeGuideName.UpdAssemblyId1;
            uoeGuideNameWork.UpdAssemblyId2 = uoeGuideName.UpdAssemblyId2;
            uoeGuideNameWork.LogicalDeleteCode = uoeGuideName.LogicalDeleteCode;

            uoeGuideNameWork.UOEGuideDivCd = uoeGuideName.UOEGuideDivCd;                    // UOEガイド区分
            uoeGuideNameWork.UOESupplierCd = uoeGuideName.UOESupplierCd;                    // UOE発注先コード
            uoeGuideNameWork.UOEGuideCode = uoeGuideName.UOEGuideCode;                      // UOEガイドコード
            uoeGuideNameWork.UOEGuideName = uoeGuideName.UOEGuideNm;                        // UOEガイド名称
            uoeGuideNameWork.SectionCode = uoeGuideName.SectionCode;

            return uoeGuideNameWork;
        }

        /// <summary>
        /// UOEガイド名称検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOEガイド名称の検索処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private int SearchUOEGuideName(ref ArrayList retList, out int retTotalCnt, out bool nextData, UOEGuideName inUOEGuideName, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();

            // 次データ有無初期化
            nextData = false;
            // 読込対象データ総件数0で初期化
            retTotalCnt = 0;

            int status = 0;

            ArrayList workList = new ArrayList();
            object retObj = workList;

            if (retList.Count == 0)
            {
                // セキュリティレベルキー指定
                uoeGuideNameWork.EnterpriseCode = inUOEGuideName.EnterpriseCode;
                uoeGuideNameWork.SectionCode = inUOEGuideName.SectionCode;
                uoeGuideNameWork.UOEGuideDivCd = inUOEGuideName.UOEGuideDivCd;
                uoeGuideNameWork.UOESupplierCd = inUOEGuideName.UOESupplierCd;


                // UOEガイド名称ワーカークラスをオブジェクトに設定
                object paraObj = (object)uoeGuideNameWork;
                
                // 全件読込
                status = this._iUOEGuideNameDB.Search(ref retObj, paraObj, 0, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            workList = retObj as ArrayList;
                            if (workList != null)
                            {
                                foreach (UOEGuideNameWork wkUOESupplierWork in workList)
                                {
                                    // リモートパラメータデータ ⇒ データクラス
                                    UOEGuideName wkUOEGuideName = CopyToUOEGuideNameFromUOEGuideNameWork(wkUOESupplierWork);
                                    // データクラスを読込結果へコピー
                                    retList.Add(wkUOEGuideName);
                                }
                            }
                            break;
                        }
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
        /// <br>Date		: 2008.06.30</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            UOEGuideName uoeGuideName = new UOEGuideName();

            // 企業コード／ガイド区分／発注先コード設定有り
            if ((inParm.ContainsKey("EnterpriseCode")) && (inParm.ContainsKey("UOEGuideDivCd")) && (inParm.ContainsKey("UOESupplierCd")) && (inParm.ContainsKey("SectionCode")))
            {
                uoeGuideName.EnterpriseCode = inParm["EnterpriseCode"].ToString();
                uoeGuideName.UOEGuideDivCd = int.Parse(inParm["UOEGuideDivCd"].ToString());
                uoeGuideName.UOESupplierCd = int.Parse(inParm["UOESupplierCd"].ToString());
                uoeGuideName.SectionCode = inParm["SectionCode"].ToString();
            }
            // 企業コード／ガイド区分／発注先コード設定無し
            else
            {
                // 有り得ないのでエラー
                return status;
            }

            // UOEガイド名称マスタテーブル読込み
            status = Search(ref guideList, uoeGuideName);

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
        /// UOEガイド名称マスタガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="uoeGuideName">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: UOEガイド名称マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.06.30</br>
        /// </remarks>
        public int ExecuteGuid(UOEGuideName inUOEGuideName, out UOEGuideName uoeGuideName)
        {
            int status = -1;
            uoeGuideName = new UOEGuideName();

            TableGuideParent tableGuideParent = new TableGuideParent("UOEGUIDENAMEGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add("EnterpriseCode", inUOEGuideName.EnterpriseCode);
            // UOEガイド区分
            inObj.Add("UOEGuideDivCd", inUOEGuideName.UOEGuideDivCd);
            // UOE発注先コード
            inObj.Add("UOESupplierCd", inUOEGuideName.UOESupplierCd);
            // 拠点コード
            inObj.Add("SectionCode", inUOEGuideName.SectionCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                // 拠点コード
                uoeGuideName.SectionCode = retObj["SectionCode"].ToString();
                // UOEガイド区分
                string strCode = retObj["UOEGuideDivCd"].ToString();
                uoeGuideName.UOEGuideDivCd = int.Parse(strCode);
                // UOE発注先コード
                strCode = retObj["UOESupplierCd"].ToString();
                uoeGuideName.UOESupplierCd = int.Parse(strCode);
                // UOEガイドコード
                uoeGuideName.UOEGuideCode = retObj["UOEGuideCode"].ToString();
                // UOEガイド名称
                uoeGuideName.UOEGuideNm = retObj["UOEGuideNm"].ToString();

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
