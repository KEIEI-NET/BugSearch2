using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上入力用初期値取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上入力の初期値取得データ制御を行います。</br>
    /// <br>Update Note: 2012/12/19 西 毅</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             MAHNB01001U.Logが存在する場合ログを出力するように変更</br>
    /// </remarks>
    public class DelphiSalesSlipInputInitDataFourthAcs
    {
        # region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private DelphiSalesSlipInputInitDataFourthAcs()
        {
        }

        /// <summary>
        /// 売上入力用初期値取得アクセスクラス インスタンス取得処理
        /// </summary>
        public static DelphiSalesSlipInputInitDataFourthAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataFourthAcs == null)
            {
                _delphiSalesSlipInputInitDataFourthAcs = new DelphiSalesSlipInputInitDataFourthAcs();
            }
            return _delphiSalesSlipInputInitDataFourthAcs;
        }
        # endregion

        #region ■プライベート変数
        private static DelphiSalesSlipInputInitDataFourthAcs _delphiSalesSlipInputInitDataFourthAcs;

        private List<RateProtyMng> _rateProtyMngList = null;
        private List<Warehouse> _warehouseList = null;         // 倉庫コードマスタリスト
        private List<SlipPrtSet> _slipPrtSetList = null;       // 伝票印刷設定マスタリスト
        private List<CustSlipMng> _custSlipMngList = null;     // 得意先マスタ（伝票管理）リスト


        #endregion

        #region ■パブリック変数
        /// <summary>ローカルDB読み込み判定</summary>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#else
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#endif
        private List<UOEGuideName> _uoeGuideNameList = null;   // ＵＯＥガイド名称マスタリスト

        private UOESetting _uoeSetting = null;                 // UOE自社マスタ

        /// <summary>掛率優先管理マスタキャッシュデリゲート</summary>
        public delegate void CacheRateProtyMngListEventHandler(List<RateProtyMng> rateProtyMngList);

        # endregion

        /// <summary>掛率優先管理マスタセットイベント</summary>
        public event CacheRateProtyMngListEventHandler CacheRateProtyMngList;

        # region ■パブリックメソッド
        /// <summary>
        /// 売上入力で使用する初期データをＤＢより取得します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitDataFourth(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage;

            #region ●ＵＯＥガイド名称マスタ PMUOE09032A
            LogWrite("２ UOEガイド名称マスタリストを取得");
            UOEGuideName uOEGuideName = new UOEGuideName();
            uOEGuideName.EnterpriseCode = enterpriseCode;
            uOEGuideName.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            UOEGuideNameAcs uOEGuideNameAcs = new UOEGuideNameAcs();
            status = uOEGuideNameAcs.Search(out aList, uOEGuideName);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._uoeGuideNameList = new List<UOEGuideName>((UOEGuideName[])aList.ToArray(typeof(UOEGuideName)));
            }
            #endregion

            #region ●ＵＯＥ自社マスタ PMUOE09042A
            LogWrite("２ UOE自社マスタを取得");
            UOESettingAcs uoeSettingAcs = new UOESettingAcs();
            uoeSettingAcs.Read(out this._uoeSetting, enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            #endregion

            #region ●倉庫情報取得 MAKHN09332A
            LogWrite("２ 倉庫情報を取得");
            WarehouseAcs warehouseAcs = new WarehouseAcs();
            warehouseAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = warehouseAcs.Search(out aList, enterpriseCode, sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._warehouseList = new List<Warehouse>((Warehouse[])aList.ToArray(typeof(Warehouse)));
            }
            #endregion


            #region ●掛率優先管理マスタ DCKHN09102A
            LogWrite("掛率優先管理マスタを取得");
            RateProtyMngAcs rateProtyMngAcs = new RateProtyMngAcs();
            int retTotalCnt;
            bool nextDat;
            status = rateProtyMngAcs.Search(out aList, out retTotalCnt, out nextDat, enterpriseCode, string.Empty, out retMessage);
            this._rateProtyMngList = new List<RateProtyMng>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._rateProtyMngList = new List<RateProtyMng>((RateProtyMng[])aList.ToArray(typeof(RateProtyMng)));
            }
            this.CacheRateProtyMngListCall();
            #endregion

            #region ●伝票印刷設定マスタ SFURI09022A
            LogWrite("２ 伝票印刷設定マスタリストを取得");
            SlipPrtSetAcs slipPrtSetAcs = new SlipPrtSetAcs();
            slipPrtSetAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = slipPrtSetAcs.SearchSlipPrtSet(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._slipPrtSetList = new List<SlipPrtSet>((SlipPrtSet[])aList.ToArray(typeof(SlipPrtSet)));
            }
            #endregion

            #region ●得意先マスタ（伝票管理） SFURI09022A
            LogWrite("２ 得意先マスタ（伝票管理）リストを取得");
            int count = 0;
            CustSlipMngAcs custSlipMngAcs = new CustSlipMngAcs();
            custSlipMngAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = custSlipMngAcs.SearchOnlyCustSlipMng(out count, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._custSlipMngList = new List<CustSlipMng>((CustSlipMng[])custSlipMngAcs.CustSlipMngList.ToArray(typeof(CustSlipMng)));
            }
            #endregion

            return 0;
        }
        #endregion


        public List<Warehouse> GetWarehouseList()
        {
            return this._warehouseList;
        }
        public List<SlipPrtSet> GetSlipPrtSetList()
        {
            return this._slipPrtSetList;
        }
        public List<CustSlipMng> GetCustSlipMngList()
        {
            return this._custSlipMngList;
        }
                /// <summary>
        /// 掛率優先管理マスタキャッシュデリゲート コール処理
        /// </summary>
        public void CacheRateProtyMngListCall()
        {
            if (this.CacheRateProtyMngList != null) this.CacheRateProtyMngList(this._rateProtyMngList);
        }

        public List<RateProtyMng> GetRateProtyMngList()
        {
            return this._rateProtyMngList;
        }


        public List<UOEGuideName> GetUoeGuideNameList()
        {
            return this._uoeGuideNameList;
        }
        public UOESetting GetUoeSetting()
        {
            return this._uoeSetting;
        }

        #region ■DEBUGログ出力
        /// <summary>
        /// ログ出力(DEBUG)処理
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#if DEBUG
            if (SalesSlipInputInitDataAcs._Log_Check == 0)
            {
                if (System.IO.File.Exists("MAHNB01001U.Log"))
                {
                    SalesSlipInputInitDataAcs._Log_Check = 1;
                }
                else
                {
                    SalesSlipInputInitDataAcs._Log_Check = 2;
                }

            }

            if (SalesSlipInputInitDataAcs._Log_Check == 1)
            {
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
            System.IO.FileStream _fs;										// ファイルストリーム
            System.IO.StreamWriter _sw;										// ストリームwriter
            _fs = new FileStream("MAHNB01001U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#endif
        }
        // --- UPD T.Nishi 2012/12/19 ----------<<<<<
    }

        #endregion
    }
}
