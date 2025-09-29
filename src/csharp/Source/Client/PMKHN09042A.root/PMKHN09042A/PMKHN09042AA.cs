using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    ///離島価格マスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 離島価格マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 30416 長沼 賢二</br>
    /// <br>Date       : 2008.06.27</br>
    /// <br>UpdateNote : 2008/10/07 30462 行澤 仁美　バグ修正</br>
    /// <br>           : 2008/11/13       照田 貴志  バグ修正、仕様変更対応</br>
    /// <br>           : 2009.02.23 20056 對馬 大輔  Searchメソッドでキャッシュ指定可能なメソッドをオーバーロード</br>
    /// </remarks>
    public class IsolIslandPrcAcs
    {
        // --------------------------------------------------
        #region Private Members

        // 企業コード
        private string _enterpriseCode = "";

        /// <summary>離島価格マスタリモートオブジェクト格納バッファ</summary>
        private IIsolIslandPrcDB _iIsolIslandPrcDB = null;

        // データセット
        private DataSet _bindDataSet = null;
        private DataTable _isolIslandPrcTable = null;

        // マスタクラス格納リスト
        private Dictionary<Guid, IsolIslandPrcWork> _isolIslandPrcDic = null;  // 離島価格マスタ格納用

        // マスタ取得用リスト
        private ArrayList _isolIslandPrcList = null;                  // 離島価格マスタ取得用

        #endregion

        // --------------------------------------------------
        #region Public Members
        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        public static readonly string TBL_ISOLISLANDPRC_TITLE       = "ISOLISLANDPRC_TABLE";
        public static readonly string COL_DELETEDATE_TITLE          = "削除日";
        public static readonly string COL_SECTIONCODE_TITLE         = "拠点";
        //--- DEL 2008/10/07 不具合対応[6323] ↓
        //public static readonly string COL_SECTIONNAME_TITLE         = "拠点名称"; // ADD 2008/09/24
        public static readonly string COL_SECTIONNAME_TITLE         = "拠点名";     // ADD 2008/10/07 不具合対応[6323]
        public static readonly string COL_MAKERCODE_TITLE           = "メーカーコード";
        //--- DEL 2008/10/07 不具合対応[6323] ↓
        //public static readonly string COL_MAKERNAME_TITLE           = "メーカー名称";
        public static readonly string COL_MAKERNAME_TITLE           = "メーカー名";   // ADD 2008/10/07 不具合対応[6323]
        public static readonly string COL_UPPERLIMITPRICE_TITLE     = "価格上限";
        public static readonly string COL_UPRATE_TITLE              = "価格UP率";
        public static readonly string COL_FRACTIONPROCUNIT_TITLE    = "端数処理単位";
        public static readonly string COL_FRACTIONPROCCD_TITLE      = "端数処理区分";
        public static readonly string COL_GUID_TITLE                = "GUID";

        // 端数処理区分
        /* --- DEL 2008/11/13 表示位置変更の為 ---------------->>>>>
        private const string FRACTIONPROCCD_KIND1 = "四捨五入";
        private const string FRACTIONPROCCD_KIND2 = "切り上げ";
        private const string FRACTIONPROCCD_KIND3 = "切り捨て";
           --- DEL 2008/11/13 ---------------------------------<<<<< */
        // --- ADD 2008/11/13 --------------------------------->>>>>
        private const string FRACTIONPROCCD_KIND1 = "切り捨て";
        private const string FRACTIONPROCCD_KIND2 = "四捨五入";
        private const string FRACTIONPROCCD_KIND3 = "切り上げ";
        // --- ADD 2008/11/13 ---------------------------------<<<<<
        #endregion
        // --------------------------------------------------
        #region Constructor

        /// <summary>
        ///離島価格マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 離島価格マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public IsolIslandPrcAcs()
        {
            try
            {
                // 企業コード取得
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                // リモートオブジェクト取得
                this._iIsolIslandPrcDB = (IIsolIslandPrcDB)MediationIsolIslandPrcDB.GetIsolIslandPrcDB();

                // マスタクラス格納リスト初期化
                this._isolIslandPrcDic = new Dictionary<Guid, IsolIslandPrcWork>();

                // マスタ取得用リスト初期化
                this._isolIslandPrcList = new ArrayList();

                // データセット初期化
                this._bindDataSet = new DataSet();
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).BeginInit();
                this._bindDataSet.DataSetName = "NewDataSet";
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).EndInit();

                // データセット列情報構築
                this.DataSetColumnConstruction();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iIsolIslandPrcDB = null;
            }
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///                  データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            // 離島価格マスタテーブル
            this._isolIslandPrcTable = new DataTable(TBL_ISOLISLANDPRC_TITLE);

            // Addを行う順番が、列の表示順位となります。
            this._isolIslandPrcTable.Columns.Add(COL_DELETEDATE_TITLE, typeof(string));         // 削除日
            this._isolIslandPrcTable.Columns.Add(COL_SECTIONCODE_TITLE, typeof(string));        // 拠点コード
            // --- ADD 2008/09/25 -------------------------------->>>>>
            this._isolIslandPrcTable.Columns.Add(COL_SECTIONNAME_TITLE, typeof(string));        // 拠点名称
            // --- ADD 2008/09/25 --------------------------------<<<<<
            this._isolIslandPrcTable.Columns.Add(COL_MAKERCODE_TITLE, typeof(Int32));           // メーカーコード
            this._isolIslandPrcTable.Columns.Add(COL_MAKERNAME_TITLE, typeof(string));          // メーカー名称
            this._isolIslandPrcTable.Columns.Add(COL_UPPERLIMITPRICE_TITLE, typeof(Double));    // 価格上限
            this._isolIslandPrcTable.Columns.Add(COL_UPRATE_TITLE, typeof(Double));             // 価格UP率
            this._isolIslandPrcTable.Columns.Add(COL_FRACTIONPROCUNIT_TITLE, typeof(Double));   // 端数処理単位
            this._isolIslandPrcTable.Columns.Add(COL_FRACTIONPROCCD_TITLE, typeof(string));     // 端数処理区分
            this._isolIslandPrcTable.Columns.Add(COL_GUID_TITLE, typeof(Guid));                 // GUID
            // PrimaryKey設定
            this._isolIslandPrcTable.PrimaryKey = new DataColumn[] { this._isolIslandPrcTable.Columns[COL_SECTIONCODE_TITLE],        // 拠点コード
                                                                     this._isolIslandPrcTable.Columns[COL_MAKERCODE_TITLE],          // メーカーコード
                                                                     this._isolIslandPrcTable.Columns[COL_UPPERLIMITPRICE_TITLE] };  // 価格上限

            this._bindDataSet.Tables.Add(this._isolIslandPrcTable);
        }

        #endregion

        // --------------------------------------------------
        #region Properties

        /// <summary>データセットプロパティ</summary>
        /// <value>データセットを取得します。</value>
        public DataSet BindDataSet
        {
            get
            {
                return this._bindDataSet;
            }
        }

        #endregion

        // --------------------------------------------------
        #region GetOnlineMode

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードの取得を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            // オンラインモードを取得
            if (this._iIsolIslandPrcDB == null)
            {
                // オフライン
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                // オンライン
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        #endregion

        // --------------------------------------------------
        #region Read Methods

        /// <summary>
        ///読み込み処理
        /// </summary>
        /// <param name="IsolIslandPrc">離島価格マスタオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の読み込み処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Read(out IsolIslandPrc isolIslandPrc, string enterpriseCode, Int32 makerCode)
        {
            return this.ReadProc(out isolIslandPrc, enterpriseCode, makerCode);
        }

        /// <summary>
        ///離島価格マスタ読み込み処理
        /// </summary>
        /// <param name="IsolIslandPrc">離島価格マスタオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 離島価格マスタの読み込み処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private int ReadProc(out IsolIslandPrc isolIslandPrc, string enterpriseCode, Int32 makerCode)
        {
            int status1 = 0;

            isolIslandPrc = null;

            try
            {
                // キー情報をセット
                IsolIslandPrcWork isolIslandPrcWork = new IsolIslandPrcWork();
                isolIslandPrcWork.EnterpriseCode = enterpriseCode;   // 企業コード
                isolIslandPrcWork.MakerCode = makerCode;             // メーカーコード

                object refobj = null;

                //離島価格マスタ読み込み
                status1 = this._iIsolIslandPrcDB.Read(ref refobj, 0);

                if (status1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    IsolIslandPrcWork isolIslandPrcWorkRef = (IsolIslandPrcWork)refobj;

                    // 結果をメンバコピー
                    isolIslandPrc = this.CopyToIsolIslandPrcFromIsolIslandPrcWork(isolIslandPrcWorkRef);
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                isolIslandPrc = null;
                this._iIsolIslandPrcDB = null;

                // 通信エラーは-1を返す
                status1 = -1;
            }
            return status1;
        }

        #endregion

        // --------------------------------------------------
        #region Write Methods

        /// <summary>
        ///書き込み処理
        /// </summary>
        /// <param name="isolIslandPrc">離島価格マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタの書き込み処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Write(IsolIslandPrc isolIslandPrc)
        {
            // 離島価格マスタ更新
            return this.WriteProc(isolIslandPrc);
        }

        /// <summary>
        ///離島価格マスタ書き込み処理
        /// </summary>
        /// <param name="isolIslandPrc">離島価格マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 離島価格マスタの書き込み処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private int WriteProc(IsolIslandPrc isolIslandPrc)
        {
            int status = 0;

            try
            {

                IsolIslandPrcWork isolIslandPrcWork = new IsolIslandPrcWork();

                // 編集前情報取得
                if (this._isolIslandPrcDic.ContainsKey(isolIslandPrc.FileHeaderGuid) == true)
                {
                    isolIslandPrcWork = (this._isolIslandPrcDic[isolIslandPrc.FileHeaderGuid] as IsolIslandPrcWork);
                }

                // 編集情報取得
                CopyToIsolIslandPrcWorkFromDispIsolIslandPrc(ref isolIslandPrcWork, isolIslandPrc);

                ArrayList retParaArray = new ArrayList();
                retParaArray.Add(isolIslandPrcWork);

                object retObj = (object)retParaArray;

                // 離島価格マスタ書き込み
                status = this._iIsolIslandPrcDB.Write(ref retObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // データセットに追加
                    ArrayList retArray = new ArrayList();
                    retArray = (ArrayList)retObj;
                    isolIslandPrcWork = (IsolIslandPrcWork)retArray[0];
                    this.IsolIslandPrcWorkToDataSet(isolIslandPrcWork);
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iIsolIslandPrcDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region LogicalDelete Methods

        /// <summary>
        ///論理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">離島価格マスタGuid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の論理削除処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int LogicalDelete(Guid fileHeaderGuid)
        {
            // 離島価格マスタ論理削除
            return this.LogicalDeleteProc(fileHeaderGuid);
        }

        /// <summary>
        ///離島価格マスタ論理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">離島価格マスタGuid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 離島価格マスタの論理削除処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private int LogicalDeleteProc(Guid fileHeaderGuid)
        {
            int status = 0;

            try
            {
                // 編集前情報取得
                IsolIslandPrcWork isolIslandPrcWork = (this._isolIslandPrcDic[fileHeaderGuid] as IsolIslandPrcWork);

                ArrayList retArray = new ArrayList();
                retArray.Add(isolIslandPrcWork);

                object retObj = (object)retArray;

                // 離島価格マスタ論理削除
                status = this._iIsolIslandPrcDB.LogicalDelete(ref retObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList refArray = (ArrayList)retObj;
                    isolIslandPrcWork = (IsolIslandPrcWork)refArray[0];
                    // データセットに追加
                    this.IsolIslandPrcWorkToDataSet(isolIslandPrcWork);
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iIsolIslandPrcDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region Revival Methods

        /// <summary>
        ///論理削除復活処理
        /// </summary>
        /// <param name="fileHeaderGuid">離島価格マスタGuid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の論理削除復活処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public int Revival(Guid fileHeaderGuid)
        {
            // 離島価格マスタ復活
            return this.RevivalProc(fileHeaderGuid);
        }

        /// <summary>
        ///離島価格マスタ論理削除復活処理
        /// </summary>
        /// <param name="fileHeaderGuid">離島価格マスタGuid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 離島価格マスタの論理削除復活処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private int RevivalProc(Guid fileHeaderGuid)
        {
            int status = 0;

            try
            {
                // 編集前情報取得
                IsolIslandPrcWork isolIslandPrcWork = (this._isolIslandPrcDic[fileHeaderGuid] as IsolIslandPrcWork);

                ArrayList retArray = new ArrayList();
                retArray.Add(isolIslandPrcWork);

                object retObj = (object)retArray;

                // 離島価格マスタ論理削除復活
                status = this._iIsolIslandPrcDB.RevivalLogicalDelete(ref retObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList refArray = (ArrayList)retObj;
                    isolIslandPrcWork = (IsolIslandPrcWork)refArray[0];
                    // データセットに追加
                    this.IsolIslandPrcWorkToDataSet(isolIslandPrcWork);
                }
            }

            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iIsolIslandPrcDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region Delete Methods

        /// <summary>
        ///物理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">離島価格マスタGuid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の物理削除処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Delete(Guid fileHeaderGuid)
        {
            // 離島価格マスタ物理削除
            return this.DeleteProc(fileHeaderGuid);
        }

        /// <summary>
        ///離島価格マスタ物理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">離島価格マスタGuid</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 離島価格マスタの物理削除処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private int DeleteProc(Guid fileHeaderGuid)
        {
            int status = 0;

            try
            {
                // 編集前情報取得
                IsolIslandPrcWork isolIslandPrcWork = (this._isolIslandPrcDic[fileHeaderGuid] as IsolIslandPrcWork);
             
                ArrayList retArray = new ArrayList();
                retArray.Add(isolIslandPrcWork);

                object retObj = (object)retArray;

                // 離島価格マスタ物理削除
                status = this._iIsolIslandPrcDB.Delete(retObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 詳細グリッド用キャッシュテーブルから削除
                    this._isolIslandPrcDic.Remove(isolIslandPrcWork.FileHeaderGuid);
                    // データテーブルから削除
                    DataRow dr = this._isolIslandPrcTable.Rows.Find(new object[] { isolIslandPrcWork.SectionCode,
                                                                                   isolIslandPrcWork.MakerCode,
                                                                                   isolIslandPrcWork.UpperLimitPrice } );

                    dr.Delete();
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iIsolIslandPrcDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region Search Methods

        // 2009.02.23 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 検索処理(論理削除除く)（オーバーロード)
        ///// </summary>
        ///// <param name="isolIslandPrcList">離島価格リスト(ArrayList)</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : マスタ情報の検索処理を行います。論理削除データは検索対象外です。</br>
        ///// <br>Programmer : 30416 長沼 賢二</br>
        ///// <br>Date       : 2008.06.27</br>
        ///// </remarks>
        //public int Search(out List<IsolIslandPrc> isolIslandPrcList, string enterpriseCode)
        //{
        //    int totalCount;
        //    isolIslandPrcList = new List<IsolIslandPrc>();
        //    int status = this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        foreach (IsolIslandPrcWork isolIslandPrcWork in (ArrayList)this._isolIslandPrcList)
        //        {
        //            isolIslandPrcList.Add(this.CopyToIsolIslandPrcFromIsolIslandPrcWork(isolIslandPrcWork));
        //        }
        //    }

        //    return status;
        //}

        /// <summary>
        /// 検索処理(論理削除除く)（オーバーロード)
        /// </summary>
        /// <param name="isolIslandPrcList">離島価格リスト(ArrayList)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データは検索対象外です。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Search(out List<IsolIslandPrc> isolIslandPrcList, string enterpriseCode)
        {
            return this.Search(out isolIslandPrcList, enterpriseCode, true);
        }

        /// <summary>
        /// 検索処理(論理削除除く)（オーバーロード)
        /// </summary>
        /// <param name="isolIslandPrcList"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        public int Search(out List<IsolIslandPrc> isolIslandPrcList, string enterpriseCode, bool isCache)
        {
            int totalCount;
            isolIslandPrcList = new List<IsolIslandPrc>();
            int status = this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData0, isCache);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (IsolIslandPrcWork isolIslandPrcWork in (ArrayList)this._isolIslandPrcList)
                {
                    isolIslandPrcList.Add(this.CopyToIsolIslandPrcFromIsolIslandPrcWork(isolIslandPrcWork));
                }
            }

            return status;
        }
        // 2009.02.23 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        ///検索処理(論理削除除く)
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データは検索対象外です。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Search(out int totalCount, string enterpriseCode)
        {
            // 離島価格マスタ検索
            // 2009.02.23 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //return this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
            return this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData0, true);
            // 2009.02.23 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        ///検索処理(論理削除含む)
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データも検索対象に含みます。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int SearchAll(out int totalCount, string enterpriseCode)
        {
            // 離島価格マスタ検索
            // 2009.02.23 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //return this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
            return this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData01, true);
            // 2009.02.23 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        // 2009.02.23 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        /////検索処理
        ///// </summary>
        ///// <param name="totalCount">取得件数</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="logicalMode">論理削除区分</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : マスタ情報の検索処理を行います。</br>
        ///// <br>Programmer : 30416 長沼 賢二</br>
        ///// <br>Date       : 2008.06.27</br>
        ///// </remarks>
        //private int SearchProc(out int totalCount, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        /// <summary>
        ///検索処理
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="isCache">キャッシュ区分</param>
        /// <returns>STATUS</returns>
        private int SearchProc(out int totalCount, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, bool isCache)
        // 2009.02.23 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            int status1 = 0;
            int status2 = 0;

            // 離島価格マスタ検索
            status1 = this.SearchIsolIslandPrcProc(out totalCount, enterpriseCode, logicalMode);
            if ((status1 != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                (status1 != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) && // ADD 2008/09/25
                (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                return status1;
            }

            // 2009.02.23 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// キャッシュ処理
            //status2 = this.Cache(this._isolIslandPrcList);
            //if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    return status2;
            //}
            if (isCache)
            {
                // キャッシュ処理
                status2 = this.Cache(this._isolIslandPrcList);
                if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status2;
                }
            }
            // 2009.02.23 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // ステータス判断
            if ((status1 == (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                (status2 == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        ///離島価格マスタ検索処理
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 離島価格マスタの検索処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private int SearchIsolIslandPrcProc(out int totalCount, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;
            totalCount = 0;

            try
            {
                // 取得リスト初期化
                this._isolIslandPrcList.Clear();

                // キャッシュ用テーブルをクリア
                this._isolIslandPrcDic.Clear();

                // キー情報をセット
                IsolIslandPrcWork paramIsolIslandPrcWork = new IsolIslandPrcWork();
                paramIsolIslandPrcWork.EnterpriseCode = enterpriseCode;    // 企業コード

                ArrayList retArray = new ArrayList();
                object retobj = (object)retArray;

                // 離島価格マスタ検索
                status = this._iIsolIslandPrcDB.Search(ref retobj, paramIsolIslandPrcWork, 0, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._isolIslandPrcList = retobj as ArrayList;

                    // 該当件数格納
                    totalCount = this._isolIslandPrcList.Count;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iIsolIslandPrcDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }
        #endregion

        // --------------------------------------------------
        #region Cache Methods

        /// <summary>
        /// マスタキャッシュ処理
        /// </summary>
        /// <param name="isolIslandPrcList">マスタ取得結果リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報のキャッシュ処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public int Cache(ArrayList isolIslandPrcList)
        {
            try
            {
                try
                {
                    // 更新処理開始
                    this._isolIslandPrcTable.BeginLoadData();

                    // テーブルをクリア
                    this._isolIslandPrcTable.Clear();

                    // 伝票管理データをDataSetに格納
                    foreach (IsolIslandPrcWork isolIslandPrcWork in isolIslandPrcList)
                    {
                        // 未登録の時
                        if (this._isolIslandPrcDic.ContainsKey(isolIslandPrcWork.FileHeaderGuid) == false)
                        {
                            // データセットに追加
                            this.IsolIslandPrcWorkToDataSet(isolIslandPrcWork);
                        }
                    }
                }
                finally
                {
                    // 更新処理終了
                    this._isolIslandPrcTable.EndLoadData();

                    // ソート
                    this._isolIslandPrcTable.DefaultView.Sort = COL_SECTIONCODE_TITLE + " ASC";       // 拠点コード
                    this._isolIslandPrcTable.AcceptChanges();
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return 0;
        }

        #endregion

        // --------------------------------------------------
        #region MemberCopy Methods

        /// <summary>
        /// クラスメンバコピー処理 (画面変更離島価格マスタクラス⇒離島価格マスタワーククラス)
        /// </summary>
        /// <param name="isolIslandPrcWork">離島価格マスタワーククラス</param>
        /// <param name="IsolIslandPrc">離島価格マスタクラス</param>
        /// <remarks>
        /// <br>Note       : 画面変更離島価格マスタクラスから
        ///                  離島価格マスタワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void CopyToIsolIslandPrcWorkFromDispIsolIslandPrc(ref IsolIslandPrcWork isolIslandPrcWork, IsolIslandPrc isolIslandPrc)
        {
            isolIslandPrcWork.EnterpriseCode = isolIslandPrc.EnterpriseCode;          // 企業コード
            isolIslandPrcWork.SectionCode = isolIslandPrc.SectionCode;                // 拠点コード
            isolIslandPrcWork.SectionGuideNm = this.GetSectionName(isolIslandPrc.SectionCode); // 拠点名称  // ADD 2008/09/26
            isolIslandPrcWork.MakerCode = isolIslandPrc.MakerCode;                    // メーカーコード
 
            isolIslandPrcWork.UpperLimitPrice = isolIslandPrc.UpperLimitPrice;        // 価格上限
            isolIslandPrcWork.UpRate = isolIslandPrc.UpRate;                          // 価格UP率
            isolIslandPrcWork.FractionProcUnit = isolIslandPrc.FractionProcUnit;      // 端数処理単位
            isolIslandPrcWork.FractionProcCd = isolIslandPrc.FractionProcCd;          // 端数処理区分
        }

        /// <summary>
        /// クラスメンバコピー処理 (離島価格マスタワーククラス⇒離島価格マスタクラス)
        /// </summary>
        /// <param name="isolIslandPrcWork">離島価格マスタワーククラス</param>
        /// <returns>離島価格マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 離島価格マスタワーククラスから
        ///                  離島価格マスタクラスへメンバコピーを行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private IsolIslandPrc CopyToIsolIslandPrcFromIsolIslandPrcWork(IsolIslandPrcWork isolIslandPrcWork)
        {
            IsolIslandPrc isolIslandPrc = new IsolIslandPrc();

            isolIslandPrc.CreateDateTime = isolIslandPrcWork.CreateDateTime;            // 作成日時
            isolIslandPrc.UpdateDateTime = isolIslandPrcWork.UpdateDateTime;            // 更新日時
            isolIslandPrc.EnterpriseCode = isolIslandPrcWork.EnterpriseCode;            // 企業コード
            isolIslandPrc.FileHeaderGuid = isolIslandPrcWork.FileHeaderGuid;            // GUID
            isolIslandPrc.UpdEmployeeCode = isolIslandPrcWork.UpdEmployeeCode;          // 更新従業員コード
            isolIslandPrc.UpdAssemblyId1 = isolIslandPrcWork.UpdAssemblyId1;            // 更新アセンブリID1
            isolIslandPrc.UpdAssemblyId2 = isolIslandPrcWork.UpdAssemblyId2;            // 更新アセンブリID2
            isolIslandPrc.LogicalDeleteCode = isolIslandPrcWork.LogicalDeleteCode;      // 論理削除区分
            isolIslandPrc.SectionCode = isolIslandPrcWork.SectionCode;                  // 拠点コード
            isolIslandPrc.MakerCode = isolIslandPrcWork.MakerCode;                      // メーカーコード

            isolIslandPrc.UpperLimitPrice = isolIslandPrcWork.UpperLimitPrice;          // 価格上限
            isolIslandPrc.UpRate = isolIslandPrcWork.UpRate;                            // 価格UP率
            isolIslandPrc.FractionProcUnit = isolIslandPrcWork.FractionProcUnit;        // 端数処理単位
            isolIslandPrc.FractionProcCd = isolIslandPrcWork.FractionProcCd;            // 端数処理区分

            // テーブル更新
            _isolIslandPrcDic[isolIslandPrcWork.FileHeaderGuid] = isolIslandPrcWork;

            return isolIslandPrc;
        }

        /// <summary>
        /// 離島価格マスタオブジェクトメインDataSet展開処理
        /// </summary>
        /// <param name="isolIslandPrcWork">離島価格マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 離島価格マスタオブジェクトを、メインDataSetに格納します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        private void IsolIslandPrcWorkToDataSet(IsolIslandPrcWork isolIslandPrcWork)
        {
            bool newFlg = false;    // 新規・既存フラグ

            // 更新対象行の取得
            DataRow dr = this._isolIslandPrcTable.Rows.Find(new object[] { isolIslandPrcWork.SectionCode, isolIslandPrcWork.MakerCode, isolIslandPrcWork.UpperLimitPrice });
            if (dr == null)
            {
                // 新規に行を作成
                dr = this._isolIslandPrcTable.NewRow();

                // 新規レコードチェック
                newFlg = true;
            }

            // 削除日
            if (isolIslandPrcWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", isolIslandPrcWork.UpdateDateTime);
            }

            // 拠点コード
            dr[COL_SECTIONCODE_TITLE] = isolIslandPrcWork.SectionCode;
            // --- ADD 2008/09/24 -------------------------------->>>>>
            // 拠点名称
            dr[COL_SECTIONNAME_TITLE] = isolIslandPrcWork.SectionGuideNm;
            // --- ADD 2008/09/24 --------------------------------<<<<<
            // メーカーコード
            dr[COL_MAKERCODE_TITLE] = isolIslandPrcWork.MakerCode;
            // メーカー名称
            dr[COL_MAKERNAME_TITLE] = GetMakerName(isolIslandPrcWork.MakerCode);

            // 価格上限
            dr[COL_UPPERLIMITPRICE_TITLE] = isolIslandPrcWork.UpperLimitPrice;
            // 価格UP率
            dr[COL_UPRATE_TITLE] = isolIslandPrcWork.UpRate;
            // 端数処理単位
            dr[COL_FRACTIONPROCUNIT_TITLE] = isolIslandPrcWork.FractionProcUnit;

            // 端数処理区分
            /* --- DEL 2008/11/13 値変更の為 ----------------------->>>>>
            if (isolIslandPrcWork.FractionProcCd == 0)
            {
                dr[COL_FRACTIONPROCCD_TITLE] = FRACTIONPROCCD_KIND1;
            }
            if (isolIslandPrcWork.FractionProcCd == 1)
            {
                dr[COL_FRACTIONPROCCD_TITLE] = FRACTIONPROCCD_KIND2;
            }
            if (isolIslandPrcWork.FractionProcCd == 2)
            {
                dr[COL_FRACTIONPROCCD_TITLE] = FRACTIONPROCCD_KIND3;
            }
               --- DEL 2008/11/13 ----------------------------------<<<<< */
            if (isolIslandPrcWork.FractionProcCd == 1)
            {
                dr[COL_FRACTIONPROCCD_TITLE] = FRACTIONPROCCD_KIND1;        // 切り捨て
            }
            if (isolIslandPrcWork.FractionProcCd == 2)
            {
                dr[COL_FRACTIONPROCCD_TITLE] = FRACTIONPROCCD_KIND2;        // 四捨五入
            }
            if (isolIslandPrcWork.FractionProcCd == 3)
            {
                dr[COL_FRACTIONPROCCD_TITLE] = FRACTIONPROCCD_KIND3;        // 切り上げ
            }

            // GUID
            dr[COL_GUID_TITLE] = isolIslandPrcWork.FileHeaderGuid;

            // 新規レコードの場合のみ
            if (newFlg == true)
            {
                // 新規行の追加
                this._isolIslandPrcTable.Rows.Add(dr);
            }

            // テーブルに格納
            if (this._isolIslandPrcDic.ContainsKey(isolIslandPrcWork.FileHeaderGuid) == true)
            {
                this._isolIslandPrcDic.Remove(isolIslandPrcWork.FileHeaderGuid);
            }
            this._isolIslandPrcDic.Add(isolIslandPrcWork.FileHeaderGuid, isolIslandPrcWork);
        }
        #endregion

        // --------------------------------------------------
        #region 比較用クラス

        /// <summary>
        ///離島価格マスタ比較クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 離島価格マスタオブジェクトの比較を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.27</br>
        /// </remarks>
        public class IsolIslandPrcCompare : IComparer
        {
            #region IComparer メンバ

            /// <summary>
            /// 比較用メソッド
            /// </summary>
            /// <param name="x">比較対象オブジェクト</param>
            /// <param name="y">比較対象オブジェクト</param>
            /// <returns>比較結果(x ＞ y : 0より大きい整数, x ＜ y : 0より小さい整数, x ＝ y : 0)</returns>
            /// <remarks>
            /// <br>Note       : 離島価格マスタオブジェクトの比較を行います。</br>
            /// <br>Programmer : 30416 長沼 賢二</br>
            /// <br>Date       : 2008.06.27</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                IsolIslandPrc obj1 = x as IsolIslandPrc;
                IsolIslandPrc obj2 = y as IsolIslandPrc;

                // 離島価格コードで比較
                return obj1.SectionCode.CompareTo(obj2.SectionCode);
            }

            #endregion
        }

        #endregion

        #region 各種変換
        /// <summary>
        /// NULL文字変換処理
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <returns>string型データ</returns>
        /// <remarks>
        /// <br>Note       : NULL文字が含まれている場合ダブルクォートへ変換する</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public static string NullChgStr(object obj)
        {
            string ret;
            try
            {
                if (obj == null)
                {
                    ret = "";
                }
                else
                {
                    ret = obj.ToString();
                }
            }
            catch
            {
                ret = "";
            }
            return ret;
        }

        /// <summary>
        /// NULL文字変換処理
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <returns>int型データ</returns>
        /// <remarks>
        /// <br>Note       : NULL文字が含まれている場合「0」へ変換する</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public static int NullChgInt(object obj)
        {
            int ret;
            try
            {
                if ((obj == null) || (string.Equals(obj.ToString(), "") == true))
                {
                    ret = 0;
                }
                else
                {
                    ret = Convert.ToInt32(obj);
                }
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
        #endregion

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称を取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            int status;

            MakerUMnt makerUMnt = new MakerUMnt();
            MakerAcs makerAcs = new MakerAcs();

            try
            {
                status = makerAcs.Read(out makerUMnt, this._enterpriseCode, makerCode);

                if (status == 0)
                {
                    makerName = makerUMnt.MakerName.Trim();
                }
            }
            catch
            {
                makerName = "";
            }

            return makerName;
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }
    }
}
