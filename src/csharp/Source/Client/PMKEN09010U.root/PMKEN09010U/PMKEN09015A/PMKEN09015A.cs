//****************************************************************************//
// System           : .NS Series
// Program name     : 優良設定マスタ
// Note             : 優良設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 杉村 利彦
// 作 成 日  2006/02/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30415 柴田 倫幸
// 更 新 日  2008/07/01  修正内容 : 流用/機能の為、修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 更 新 日  2008/11/27  修正内容 : 障害8350
//                                  優良設定情報取得時の商品管理情報チェックを削除
//----------------------------------------------------------------------------//
// 管理番号  10402071-01 作成担当 : 20056 對馬 大輔
// 更 新 日  2009.04.06  修正内容 : №13066 拠点ｺｰﾄﾞ追加対応
//----------------------------------------------------------------------------//
// 管理番号  10402071-01 作成担当 : 20056 對馬 大輔
// 更 新 日  2009.05.25  修正内容 : №12060 設定内容が登録されない
//                                : №13148 不正データが登録される
//                                : №13374 設定内容が削除されない
//                                : №13375 設定内容が表示されない
//                                : №13380 ST=5で保存できない
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 30517 夏野 駿希
// 更 新 日  2010/03/02  修正内容 : №15083 結合マスタで表示順が一桁で表示されてしまうデータがある件の修正
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 許培珠
// 更 新 日  2012/09/25　修正内容 : 2012/10/17配信分、Redmine#32367 
//                                  商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応                             
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 許培珠
// 更 新 日  2012/10/08　修正内容 : 2012/11/14配信分、Redmine#32367 
//                                  商品管理情報マスタに入力パターンを追加したと伴い、障害対応                            
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30757 佐々木　貴英 							
// 修 正 日  2015/02/24  修正内容 : SCM高速化 Ｃ向け種別対応
//                                  ①追加項目の取得と更新
//                                    ・優良設定詳細名称２(工場向け)
//                                    ・優良設定詳細名称２(カーオーナー向け)
//----------------------------------------------------------------------------//
// 管理番号  11370033-00 作成担当 : 田建委
// 更 新 日  2018/10/25　修正内容 : Redmine#49731 優良設定マスタ更新処理の障害対応
//                                  商品管理情報マスタ（仕入先）を削除しないように変更                       
//----------------------------------------------------------------------------//
// TODO:優良設定グループ=0を有効なグループとする場合、定義↓を有効にする ※ただし、リリース時は無効とすること
//#define _EXISTS_GROUP0_
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
//using Broadleaf.Library.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;  // ADD 2008/07/01
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;    // ADD 2009/01/14 仕様変更：中分類のくくりも表示する

namespace Broadleaf.Application.Controller
{
    /// <summary>
	/// 優良設定コントローラ
    /// </summary>
    /// <remarks>
    /// <br>UpdateNote : 2008/07/01 30415 柴田 倫幸 流用/機能追加の為、修正</br>
    /// <br>UpdateNote : 2009.04.06 20056 對馬 大輔 №13066 拠点ｺｰﾄﾞ追加対応</br>
    /// <br>UpdateNote : 2009.05.25 20056 對馬 大輔 №12060 設定内容が登録されない</br>
    /// <br>                                        №13148 不正データが登録される</br>
    /// <br>                                        №13374 設定内容が削除されない</br>
    /// <br>                                        №13375 設定内容が表示されない</br>
    /// <br>                                        №13380 ST=5で保存できない</br>
    /// <br></br>
    /// <br>Update Note: 11070266-00　SCM高速化 Ｃ向け種別対応 </br>
    /// <br>Programmer : 30757 佐々木 貴英</br>
    /// <br>Date       : 2015/02/24</br>
    /// <br></br>
    /// </remarks>
    //public class PrimeSettingController  // DEL 2008/07/01
    public class PrimeSettingAcs           // ADD 2008/07/01
	{
        # region Constracter
        public PrimeSettingAcs()
		{
            try
            {
                this._dataSet = new DataSet();
                /// <summary>中分類-品目-メーカーリスト</summary>
                this._dataSet.Tables.Add(CreateTable(MG_BL_MK_TABLENAME));
                /// <summary>優良設定リスト</summary>
                this._dataSet.Tables.Add(CreateTable(PrimeSettingInfo.TABLENAME_PRIMESETTING));
                /// <summary>提供優良設定リスト</summary>
                this._dataSet.Tables.Add(CreateTable(PrimeSettingInfo.TABLENAME_OFFER_PRIMESETTING));
                /// <summary>ユーザー優良設定リスト</summary>
                this._dataSet.Tables.Add(CreateTable(PrimeSettingInfo.TABLENAME_USER_PRIMESETTING));

                //ユーザー削除リスト(提供と矛盾が出たレコードの削除）
                _UserDeleteList = new ArrayList();
                //ユーザー更新リスト
                _UserPrimeSettingList = new ArrayList();
                //優良設定リスト
                _PrimeSettingList = new Hashtable();
                //部品メーカーリスト
                _PartsMakerList = new Hashtable();
                //BL部品リスト
                _TbsPartsCodeList = new Hashtable();
                //中分類リスト
                _MiddleGenreList = new Hashtable();
                //中分類-品目-メーカーリスト
                _Mg_Bl_Mk_List = new Hashtable();
                //優良設定備考リスト
                _PrimeSettingNoteList = new Hashtable();

                // --- ADD 2008/07/01 -------------------------------->>>>>
                _SupplierList = new Hashtable();
                _GoodsMngList = new Hashtable();
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                // リモートオブジェクト取得
                /* --- DEL 2008/07/01 -------------------------------->>>>>
                //primeSettingSearchDB = (IPrimeSettingDB)MediationPrimeSettingDB.GetPrimeSettingDB();
                //offerPrimeSettingSearchDB = (IOfferPrimeSettingDB)MediationOfferPrimeSettingDB.GetOfferPrimeSettingDB();
                //offerTbsPartsCodeDB = (IOfferTbsPartsCodeDB)MediationOfferTbsPartsCodeDB.GetTbsPartsCodeDB();
                //offerMiddleGenreDB = (IOfferMiddleGenreDB)MediationOfferMiddleGenreDB.GetOfferMiddleGenreDB();
                   --- DEL 2008/07/01 --------------------------------<<<<< */

                // --- ADD 2008/07/01 -------------------------------->>>>>
                goodsMngDB = (IGoodsMngDB)MediationGoodsMngDB.GetGoodsMngDB();
                primeSettingSearchDB = (IPrmSettingUDB)MediationPrmSettingUDB.GetPrmSettingUDB();
                offerPrimeSettingSearchDB = (IPrimeSettingDB)MediationPrimeSettingDB.GetPrimeSettingDB();
                offerTbsPartsCodeDB = (ITbsPartsCodeDB)MediationTbsPartsCodeDB.GetTbsPartsCodeDB();
                offerMiddleGenreDB = (IGoodsMGroupDB)MediationGoodsMGroupDB.GetGoodsMGroupDB();
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                pMakerNmDB = (IPMakerNmDB)MediationPMakerNmDB.GetPMakerNmDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                //this._iCutomerInfoSetDB = null;
                //this._iTxtOutCarInfoSetDB = null;
            }
        }
        # endregion

        # region Private Buffers
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>拠点コード</summary>
        private string _sectionCode;
        // --- ADD 2008/07/01 --------------------------------<<<<< 
        /// <summary>基本設定のタブID</summary>
        private int _navigeteIndex;//0:MK_BL 1:MG_BL 
        /// <summary>シークレットモード</summary>
        private bool _secretMode=true;
        /// <summary>ユーザー優良設定リモート</summary>
        //private IPrimeSettingDB primeSettingSearchDB = null;  // DEL 2008/07/01
        private IPrmSettingUDB primeSettingSearchDB = null;     // ADD 2008/07/01

        /// <summary>提供優良設定リモート</summary>
        //private IOfferPrimeSettingDB offerPrimeSettingSearchDB = null;  // DEL 2008/07/01
        private IPrimeSettingDB offerPrimeSettingSearchDB = null;         // ADD 2008/07/01

        /// <summary>メーカー名称取得リモート</summary>
        private IPMakerNmDB pMakerNmDB = null;

        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>商品管理情報取得リモート</summary>
        private IGoodsMngDB goodsMngDB = null;
        // --- ADD 2008/07/01 --------------------------------<<<<< 

        /// <summary>BLコードリスト取得リモート</summary>
        //private IOfferTbsPartsCodeDB offerTbsPartsCodeDB = null;  // DEL 2008/07/01
        private ITbsPartsCodeDB offerTbsPartsCodeDB = null;         // ADD 2008/07/01

        /// <summary>中分類コードリスト取得リモート</summary>
        //private IOfferMiddleGenreDB offerMiddleGenreDB = null;
        private IGoodsMGroupDB offerMiddleGenreDB = null;

        /// <summary>データセット</summary>
        private DataSet _dataSet = null;

        /// <summary>提供更新リスト</summary>
        private ArrayList _UserDeleteList = null;
        /// <summary>ユーザー更新リスト</summary>
        private ArrayList _UserPrimeSettingList = null;
        /// <summary>優良設定リスト</summary>
        private Hashtable _PrimeSettingList = null;
        /// <summary>部品メーカーリスト</summary>
        private Hashtable _PartsMakerList = null;
        /// <summary>BL部品リスト</summary>
        private Hashtable _TbsPartsCodeList = null;
        /// <summary>部品メーカーリスト</summary>
        private Hashtable _MiddleGenreList = null;
        /// <summary>中分類-品目-メーカーリスト</summary>
        private Hashtable _Mg_Bl_Mk_List = null;
        /// <summary>優良設定備考リスト</summary>
        private Hashtable _PrimeSettingNoteList = null;

        private DataTable _originalPrimeSettingTable;

        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>商品管理情報リスト</summary>
        private Hashtable _GoodsMngList = null;

        struct F_KEY_GOODSMNGLIST
        {
            public int goodsMGroup; // ADD 2009/01/26 仕様変更：商品管理情報に中分類コードを追加
            public int goodsMakerCd;  // 商品メーカーコード
            public int blGoodsCode;   // BL商品コード
            //public string goodsNo;    // 商品番号
        }

        /// <summary>仕入先リスト</summary>
        private Hashtable _SupplierList = null;
        // --- ADD 2008/07/01 --------------------------------<<<<< 

        // ADD 2009/01/14 仕様変更 中分類コードのくくりも表示 ---------->>>>>
        /// <summary>メーカーリスト</summary>
        private readonly MakerAgreegate _makerList = new MakerAgreegate();
        /// <summary>
        /// メーカーリストを取得します。
        /// </summary>
        /// <value>メーカーリスト</value>
        private MakerAgreegate MakerList { get { return _makerList; } }
        // ADD 2009/01/14 仕様変更 中分類コードのくくりも表示 ----------<<<<<
        // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
        /// <summary>関連BLコード</summary>
        private readonly RelatedBLCodeAgreegate _relatedBLCode = new RelatedBLCodeAgreegate();
        /// <summary>
        /// 関連BLコードを取得します。
        /// </summary>
        /// <value>関連BLコード</value>
        private RelatedBLCodeAgreegate RelatedBLCode { get { return _relatedBLCode; } }
        // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<

        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterPriseCode
        {
            get { return this._enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>
        /// 拠点コード
        /// </summary>
        public string SectionCode
        {
            get { return this._sectionCode; }
            set { _sectionCode = value; }
        }
        // --- ADD 2008/07/01 --------------------------------<<<<< 

        /// <summary>
        /// 設定タブインデックス
        /// </summary>
        public int NavigeteIndex
        {
            get { return this._navigeteIndex; }
            set { _navigeteIndex = value; }
        }

        /// <summary>
        /// 中分類-品目-メーカーテーブル
        /// </summary>
        public DataTable Mg_Bl_MkTable
        {
            get { return this._dataSet.Tables[MG_BL_MK_TABLENAME]; }
        }
        /// <summary>
        /// 中分類-品目-メーカーView
        /// </summary>
        public DataView Mg_Bl_MkView
        {
            get { return this._dataSet.Tables[MG_BL_MK_TABLENAME].DefaultView; }
        }

        /// <summary>
        /// 優良設定テーブル(提供、ユーザーをマージ）
        /// </summary>
        public DataTable PrimeSettingTable
        {
            get { return this._dataSet.Tables[PrimeSettingInfo.TABLENAME_PRIMESETTING]; }
        }

        /// <summary>
        /// 優良設定View
        /// </summary>
        public DataView PrimeSettingView
        {
            get { return this._dataSet.Tables[PrimeSettingInfo.TABLENAME_PRIMESETTING].DefaultView; }
        }

        /// <summary>
        /// 提供優良設定テーブル
        /// </summary>
        public DataTable OfferPrimeSettingTable
        {
            get { return this._dataSet.Tables[PrimeSettingInfo.TABLENAME_OFFER_PRIMESETTING]; }
        }

        /// <summary>
        /// ﾕｰｻﾞｰ優良設定テーブル
        /// </summary>
        public DataTable UserPrimeSettingTable
        {
            get { return this._dataSet.Tables[PrimeSettingInfo.TABLENAME_USER_PRIMESETTING]; }
        }

        public DataTable OriginalPrimeSettingTable
        {
            get { return this._originalPrimeSettingTable; }
        }

        public DataView OriginalPrimeSettingView
        {
            get { return this._originalPrimeSettingTable.DefaultView; }
        }

        /// <summary>
        /// 中分類-品目-メーカーリスト
        /// </summary>
        /// <remarks>
        /// キー：中分類コード("0000") + メーカーコード("0000") + BLコード("00000000")
        /// </remarks>
        public Hashtable Mg_Bl_Mk_List
        {
            get { return _Mg_Bl_Mk_List; }
        }

        public Hashtable OfferPrimeSettingNote
        {
            get { return _PrimeSettingNoteList; }
        }

        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>
        /// 商品管理情報リスト
        /// </summary>
        public Hashtable GoodsMng
        {
            get { return _GoodsMngList; }
        }
        // --- ADD 2008/07/01 --------------------------------<<<<< 


        public bool SecretMode
        {
            get { return _secretMode; }
            set { _secretMode = value; }
        }   

        public string SecretCode
        {
            get {
                if (SecretMode)
                {
                    return SECRETFILTER;
                }
                else 
                {
                    return "";
                }
            }
        }

        // ADD 2009/01/21 不具合対応[6970] ---------->>>>>
        /// <summary>優良設定マスタ（ユーザー登録分）レコードの集合体</summary>
        private readonly UserPrimeSettingAgreegate _userPrimeSettingRecords = new UserPrimeSettingAgreegate();
        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）レコードの集合体を取得します。
        /// </summary>
        /// <value>優良設定マスタ（ユーザー登録分）レコードの集合体</value>
        private UserPrimeSettingAgreegate UserPrimeSettingRecords { get { return _userPrimeSettingRecords; } }
        // ADD 2009/01/21 不具合対応[6970] ----------<<<<<

        # endregion // [Private Buffer]

        # region Public Method
        //public void DataSearch()  // DEL 2008/07/01
        public int DataSearch()     // ADD 2008/07/01
        {
            int status = -1;  // ADD 2008/07/01

            try
            {
                //ここでリモートからデータを読み込む
                //先に各種マスタ読み込み

                // --- ADD 2008/07/01 -------------------------------->>>>>
                // 仕入先読込み
                status = getSupplierList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && 
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) && 
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // 商品管理情報マスタ読込み
                status = getGoodsMngList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                // 部品メーカー名称読み込み
                status = getPartsMakerList();

                // --- ADD 2008/07/01 -------------------------------->>>>>
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                // 提供BLコード読み込み
                status = getOfferTbsPartsList();

                // --- ADD 2008/07/01 -------------------------------->>>>>
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                // 提供中分類読み込み
                status = getOfferMiddleGenreList();

                // --- ADD 2008/07/01 -------------------------------->>>>>
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                // 提供優良設定読み込み
                status = getOfferPrimesettingList();

                // --- ADD 2008/07/01 -------------------------------->>>>>
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                // 提供優良設定備考読み込み
                status = getOfferPrimeSettingNoteList();

                // --- ADD 2008/07/01 -------------------------------->>>>>
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                // ﾕｰｻﾞｰ優良設定読み込み
                status = getUserPrimesettingList();

                // --- ADD 2008/07/01 -------------------------------->>>>>
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                // リスト作成
                status = getMG_BL_MKCdList();

                // --- ADD 2008/07/01 -------------------------------->>>>>
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<<

                Debug.WriteLine("優良設定レコード数：" + this.PrimeSettingTable.Rows.Count.ToString() + "(" + this._PrimeSettingList.Count.ToString() + ")");
                Debug.WriteLine("削除リスト数(ユーザーにあって、提供にない数)：" + this._UserDeleteList.Count.ToString());
                Debug.WriteLine("商品管理情報数：" + this.GoodsMng.Count.ToString());
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }

        // 2009.04.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 優良設定再取得
        /// </summary>
        /// <returns></returns>
        public int DataSearchOnlyPrmInfo()
        {
            int status = -1;

            this._dataSet = new DataSet();
            this._dataSet.Tables.Add(CreateTable(MG_BL_MK_TABLENAME));
            this._dataSet.Tables.Add(CreateTable(PrimeSettingInfo.TABLENAME_PRIMESETTING));
            this._dataSet.Tables.Add(CreateTable(PrimeSettingInfo.TABLENAME_OFFER_PRIMESETTING));
            this._dataSet.Tables.Add(CreateTable(PrimeSettingInfo.TABLENAME_USER_PRIMESETTING));

            //ユーザー削除リスト(提供と矛盾が出たレコードの削除）
            _UserDeleteList = new ArrayList();
            //ユーザー更新リスト
            _UserPrimeSettingList = new ArrayList();
            //優良設定リスト
            _PrimeSettingList = new Hashtable();
            //部品メーカーリスト
            _PartsMakerList = new Hashtable();
            //BL部品リスト
            _TbsPartsCodeList = new Hashtable();
            //中分類リスト
            _MiddleGenreList = new Hashtable();
            //中分類-品目-メーカーリスト
            _Mg_Bl_Mk_List = new Hashtable();
            //優良設定備考リスト
            _PrimeSettingNoteList = new Hashtable();

            _SupplierList = new Hashtable();
            _GoodsMngList = new Hashtable();

            try
            {
                //ここでリモートからデータを読み込む
                //先に各種マスタ読み込み

                // 仕入先読込み
                status = getSupplierList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // 商品管理情報マスタ読込み
                status = getGoodsMngList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // 部品メーカー名称読み込み
                status = getPartsMakerList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // 提供BLコード読み込み
                status = getOfferTbsPartsList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // 提供中分類読み込み
                status = getOfferMiddleGenreList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // 提供優良設定読み込み
                status = getOfferPrimesettingList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // 提供優良設定備考読み込み
                status = getOfferPrimeSettingNoteList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // ﾕｰｻﾞｰ優良設定読み込み
                status = getUserPrimesettingList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // リスト作成
                status = getMG_BL_MKCdList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                Debug.WriteLine("優良設定レコード数：" + this.PrimeSettingTable.Rows.Count.ToString() + "(" + this._PrimeSettingList.Count.ToString() + ")");
                Debug.WriteLine("削除リスト数(ユーザーにあって、提供にない数)：" + this._UserDeleteList.Count.ToString());
                Debug.WriteLine("商品管理情報数：" + this.GoodsMng.Count.ToString());
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }
        // 2009.04.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 提供データが変更されていないかをチェックする
        /// </summary>
        /// <returns>エラー件数</returns>
        public int chekcOfferPrimeSettingList()
        {
            string rowfilter = PrimeSettingView.RowFilter;
            string sort = PrimeSettingView.Sort;

            PrimeSettingView.RowFilter = String.Format("{0}>0", PrimeSettingInfo.COL_PRIMEDISPLAYCODE);
            foreach (DataRowView drv in PrimeSettingView)
            {
                /* --- DEL 2008/07/01 -------------------------------->>>>>
                //OfferPrimeSettingWork offerdrv = (OfferPrimeSettingWork)drv[COL_OFFERPRIMESETTING];

                //if ((PrimeSettingWork)drv[COL_USERPRIMESETTING] == null) continue;

                //PrimeSettingWork userdrv = (PrimeSettingWork)drv[COL_USERPRIMESETTING];
                   --- DEL 2008/07/01 --------------------------------<<<<< */

                // --- ADD 2008/07/01 -------------------------------->>>>>
                PrmSettingWork offerdrv = (PrmSettingWork)drv[COL_OFFERPRIMESETTING];
                
                if ((PrmSettingUWork)drv[COL_USERPRIMESETTING] == null) continue;
                
                PrmSettingUWork userdrv = (PrmSettingUWork)drv[COL_USERPRIMESETTING];
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                /* --- DEL 2008/07/01 -------------------------------->>>>>
                //優良種別名称が変更されている場合。
                if ( offerdrv.Prm .PrimeKindName != userdrv.PrimeKindName)
                {
                    //今は何もしない(変更リストを表示する？）
                }
                //提供が削除された場合、ユーザーデータは無効になるのでリストアップして削除にする(提供が無いので画面には出ない)
                if ((offerdrv.LogicalDeleteCode != 0) && (userdrv.LogicalDeleteCode == 0))
                {
                    //今は何もしない
                }
                   --- DEL 2008/07/01 --------------------------------<<<<< */
            }
            PrimeSettingView.RowFilter = rowfilter;
            PrimeSettingView.Sort = sort;
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prmSettingUWork"></param>
        /// <remarks>
        /// <br></br>
        /// <br>Update Note: 11070266-00　SCM高速化 Ｃ向け種別対応 </br>
        /// <br>             項目追加（優良設定詳細名称２(工場向け)、優良設定詳細名称２(カーオーナー向け)）</br>
        /// <br>Programmer : 30757 佐々木 貴英</br>
        /// <br>Date       : 2015/02/24</br>
        /// <br></br>
        /// </remarks>
        private PrmSettingUWork CreatePrmSettingUWorkWhatBLCodeIs0(PrmSettingUWork prmSettingUWork)
        {
            PrmSettingUWork blCodeIs0 = UserPrimeSettingRecords.Find(
                prmSettingUWork.GoodsMGroup,
                0,
                prmSettingUWork.PartsMakerCd,
                0,
                0
            );
            
            if (blCodeIs0 == null)
            {
                blCodeIs0 = new PrmSettingUWork();

                if (prmSettingUWork.TbsPartsCode.Equals(0))
                {
                    blCodeIs0.CreateDateTime = prmSettingUWork.CreateDateTime;
                    blCodeIs0.FileHeaderGuid = prmSettingUWork.FileHeaderGuid;
                    blCodeIs0.LogicalDeleteCode = prmSettingUWork.LogicalDeleteCode;
                    blCodeIs0.UpdAssemblyId1 = prmSettingUWork.UpdAssemblyId1;
                    blCodeIs0.UpdAssemblyId2 = prmSettingUWork.UpdAssemblyId2;
                    blCodeIs0.UpdateDateTime = prmSettingUWork.UpdateDateTime;
                    blCodeIs0.UpdEmployeeCode = prmSettingUWork.UpdEmployeeCode;
                }
                blCodeIs0.EnterpriseCode = prmSettingUWork.EnterpriseCode;
                blCodeIs0.GoodsMGroup = prmSettingUWork.GoodsMGroup;
                blCodeIs0.MakerDispOrder = prmSettingUWork.MakerDispOrder;
                blCodeIs0.OfferDate = prmSettingUWork.OfferDate;
                blCodeIs0.PartsMakerCd = prmSettingUWork.PartsMakerCd;
                blCodeIs0.PrimeDisplayCode = prmSettingUWork.PrimeDisplayCode;
                blCodeIs0.PrimeDispOrder = prmSettingUWork.PrimeDispOrder;
                blCodeIs0.PrmSetDtlName1 = prmSettingUWork.PrmSetDtlName1;
                blCodeIs0.PrmSetDtlName2 = prmSettingUWork.PrmSetDtlName2;
                blCodeIs0.PrmSetDtlNo1 = prmSettingUWork.PrmSetDtlNo1;
                blCodeIs0.PrmSetDtlNo2 = prmSettingUWork.PrmSetDtlNo2;
                blCodeIs0.SectionCode = prmSettingUWork.SectionCode;
                blCodeIs0.TbsPartsCdDerivedNo = prmSettingUWork.TbsPartsCdDerivedNo;
                blCodeIs0.TbsPartsCode = prmSettingUWork.TbsPartsCode;

                blCodeIs0.TbsPartsCode = 0;
                blCodeIs0.TbsPartsCdDerivedNo = 0;
                blCodeIs0.PrimeDispOrder = 0;
                blCodeIs0.PrmSetDtlNo1 = 0;
                blCodeIs0.PrmSetDtlName1 = string.Empty;
                blCodeIs0.PrmSetDtlNo2 = 0;
                blCodeIs0.PrmSetDtlName2 = string.Empty;
                //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                blCodeIs0.PrmSetDtlName2ForFac = string.Empty;
                blCodeIs0.PrmSetDtlName2ForCOw = string.Empty;
                //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<
            }

            blCodeIs0.PrimeDisplayCode = 2; // リモート側で0にしてくれる
            return blCodeIs0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prmSettingUWork"></param>
        /// <returns></returns>
        private GoodsMngWork CreateGoodsMngWorkWhatBLCodeIs0(PrmSettingUWork prmSettingUWork)
        {
            GoodsMngWork goodsMngWork = null;

            F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();
            {
                keyGoodsMngList.goodsMGroup = prmSettingUWork.GoodsMGroup;
                keyGoodsMngList.goodsMakerCd = prmSettingUWork.PartsMakerCd;
                keyGoodsMngList.blGoodsCode = 0;
            }
            if (this._GoodsMngList[keyGoodsMngList] != null)
            {
                goodsMngWork = (GoodsMngWork)this._GoodsMngList[keyGoodsMngList];
            }
            else
            {
                goodsMngWork = new GoodsMngWork();
                {
                    goodsMngWork.EnterpriseCode = prmSettingUWork.EnterpriseCode;
                    goodsMngWork.SectionCode    = prmSettingUWork.SectionCode;
                    goodsMngWork.GoodsMGroup    = prmSettingUWork.GoodsMGroup;
                    goodsMngWork.GoodsMakerCd   = prmSettingUWork.PartsMakerCd;
                    goodsMngWork.BLGoodsCode    = 0;
                    goodsMngWork.GoodsNo        = string.Empty;
                    goodsMngWork.SupplierCd     = 0;
                    goodsMngWork.SupplierLot    = 0;
                }
            }

            goodsMngWork.SupplierCd = GetSupplierCodeWhatBLCodeIs0(goodsMngWork.GoodsMGroup, goodsMngWork.GoodsMakerCd);

            return goodsMngWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 11070266-00　SCM高速化 Ｃ向け種別対応 </br>
        /// <br>             項目追加（優良設定詳細名称２(工場向け)、優良設定詳細名称２(カーオーナー向け)）</br>
        /// <br>Programmer : 30757 佐々木 貴英</br>
        /// <br>Date       : 2015/02/24</br>
        /// <br></br>
        /// </remarks>
        public int updatePrimeSettingList(out string errorMessage)
        {
            // 【保存】仕入先コードの入力チェック
            if (!HasSupplierCodeOfAllMg_Bl_MkView(out errorMessage))
            {
                return UPDATE_CHECK_ERROR;
            }

            string rowfilter = PrimeSettingView.RowFilter;
            string sort = PrimeSettingView.Sort;

            PrimeSettingView.RowFilter = "";
            PrimeSettingView.Sort = "";

            // 表示順位、変更フラグ、チェック状態を優良設定リストにセット
            updateCheckPrimeSettingList();

            Dictionary<String, PrmSettingUWork> prmSettingUWorkDic = new Dictionary<String, PrmSettingUWork>();
            Dictionary<String, Int32> supplierCodeDic = new Dictionary<String, Int32>();
            ArrayList deleteList = new ArrayList();

            //---------------------------------------------
            // 入力仕入先コード一覧を取得
            //---------------------------------------------
            foreach (DataRowView mgBLMkRow in Mg_Bl_MkView)
            {
                // 共通設定レコードは無視
                if (IsCommonRowOfMiddleGBLMakerDataTable(mgBLMkRow)) continue;

                if (((CheckState)mgBLMkRow[COL_CHECKSTATE]).Equals(CheckState.Unchecked) &&
                    !((Int32)mgBLMkRow[PrimeSettingInfo.COL_TBSPARTSCODE]).Equals(0))
                {
                    continue;
                }

                int goodsMGroup = (Int32)mgBLMkRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                int goodsMakerCd = (Int32)mgBLMkRow[PrimeSettingInfo.COL_PARTSMAKERCD];
                int blGoodsCode = (Int32)mgBLMkRow[PrimeSettingInfo.COL_TBSPARTSCODE];

                int supplierCd = 0;
                if (mgBLMkRow[PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
                {
                    supplierCd = (Int32)mgBLMkRow[PrimeSettingInfo.COL_SUPPLIERCD];
                }

                string key = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(goodsMGroup, blGoodsCode, goodsMakerCd);

                if (!supplierCodeDic.ContainsKey(key))
                {
                    supplierCodeDic.Add(key, supplierCd);
                }
                else
                {
                    if (supplierCd != 0)
                    {
                        supplierCodeDic[key] = supplierCd;
                    }
                }
            }

            //---------------------------------------------
            // 保存対象、削除対象の優良設定マスタ取得
            //---------------------------------------------
            foreach (DataRowView primeSettingRow in PrimeSettingView)
            {
                int middleGenreCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                int makerCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];
                int blCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE];
                int selectCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE];
                int prmSetDtl = (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE];

                string key = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(middleGenreCode, blCode, makerCode, selectCode, prmSetDtl);

                if (primeSettingRow[COL_USERPRIMESETTING] == System.DBNull.Value &&
                    UserPrimeSettingRecords.Find(middleGenreCode, blCode, makerCode, selectCode, prmSetDtl) == null)
                {
                    //----------------------------
                    // 提供データ
                    //----------------------------

                    // チェックがついていない場合は処理しない
                    if ((CheckState)primeSettingRow[COL_CHECKSTATE] == CheckState.Unchecked)
                    {
                        continue;
                    }

                    // 表示なしの場合は処理しない
                    if ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] == 0)
                    {
                        continue;
                    }

                    PrmSettingUWork prmSettingUWork = new PrmSettingUWork();
                    prmSettingUWork.EnterpriseCode = this._enterpriseCode;                                          // 企業コード
                    prmSettingUWork.SectionCode = this._sectionCode;                                                // 拠点コード
                    prmSettingUWork.MakerDispOrder = (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER];
                    prmSettingUWork.PrimeDisplayCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
                    prmSettingUWork.PrimeDispOrder = (Int32)primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER];     // 優良表示順位
                    prmSettingUWork.GoodsMGroup = (Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];     // 商品中分類コード
                    prmSettingUWork.PartsMakerCd = (Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];
                    prmSettingUWork.TbsPartsCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE];
                    prmSettingUWork.TbsPartsCdDerivedNo = (Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO];
                    prmSettingUWork.PrmSetDtlNo1 = (Int32)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE];         // セレクトコード
                    prmSettingUWork.PrmSetDtlName1 = (String)primeSettingRow[PrimeSettingInfo.COL_SELECTNAME];      // 優良設定詳細名称１
                    prmSettingUWork.PrmSetDtlNo2 = (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE];      // 種別コード
                    prmSettingUWork.PrmSetDtlName2 = (String)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME];   // 優良設定詳細名称２
                    //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                    PrmSettingWork offerPrmSettingWork = (PrmSettingWork)primeSettingRow[COL_OFFERPRIMESETTING];
                    prmSettingUWork.PrmSetDtlName2ForFac = offerPrmSettingWork.PrmSetDtlName2ForFac;   // 優良設定詳細名称２(工場向け)
                    prmSettingUWork.PrmSetDtlName2ForCOw = offerPrmSettingWork.PrmSetDtlName2ForCOw;   // 優良設定詳細名称２(カーオーナー向け)
                    //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<

                    // BLコードが0の場合、優良表示区分を2に細工　※リモート側で書き込む際に、強制的に0にする
                    if (prmSettingUWork.TbsPartsCode.Equals(0))
                    {
                        prmSettingUWork.PrimeDisplayCode = 2;
                    }

                    if (!prmSettingUWorkDic.ContainsKey(key))
                    {
                        prmSettingUWorkDic.Add(key, prmSettingUWork);
                    }

                    // BLコードが0のデータも作成
                    if (!prmSettingUWork.TbsPartsCode.Equals(0))
                    {
                        PrmSettingUWork bl0PrmSettingUWork = CreatePrmSettingUWorkWhatBLCodeIs0(prmSettingUWork);
                        key = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(middleGenreCode, 0, makerCode, 0, 0);

                        if (!prmSettingUWorkDic.ContainsKey(key))
                        {
                            prmSettingUWorkDic.Add(key, bl0PrmSettingUWork);
                        }
                    }
                }
                else
                {
                    //----------------------------
                    // ユーザーデータ
                    //----------------------------

                    if ((primeSettingRow[COL_USERPRIMESETTING] == DBNull.Value) ||
                        (UserPrimeSettingRecords.Find(middleGenreCode, blCode, makerCode, selectCode, prmSetDtl) == null))
                    {
                        continue;
                    }

                    PrmSettingWork offerPrmSettingWork = (PrmSettingWork)primeSettingRow[COL_OFFERPRIMESETTING];
                    PrmSettingUWork userPrmSettingUWork = (PrmSettingUWork)primeSettingRow[COL_USERPRIMESETTING];

                    // チェックがついていない場合は削除対象
                    if ((CheckState)primeSettingRow[COL_CHECKSTATE] == CheckState.Unchecked)
                    {
                        // BLコードが0以外のデータ
                        if (!userPrmSettingUWork.TbsPartsCode.Equals(0))
                        {
                            deleteList.Add(userPrmSettingUWork);
                        }
                    }
                    else
                    {
                        if ((userPrmSettingUWork.MakerDispOrder == (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER]) &&
                            (userPrmSettingUWork.PrimeDispOrder == (Int32)primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER]) &&
                            (userPrmSettingUWork.PrimeDisplayCode == (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]))
                        {
                            // 変更されていない場合

                            // 仕入先コードも変更の判定に加える
                            string where = GetWhere(userPrmSettingUWork.PartsMakerCd, userPrmSettingUWork.GoodsMGroup, userPrmSettingUWork.TbsPartsCode);
                            DataRow[] foundDataRows = this.PrimeSettingTable.Select(where);
                            if (!(bool)foundDataRows[0][COL_CHANGEFLAG])
                            {
                                continue;
                            }
                        }

                        // 変更されている場合

                        // 優良表示区分が「表示無し」に変更された場合、削除対象
                        if (((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]).Equals(0))
                        {
                            // BLコードが0以外のデータ
                            if (!userPrmSettingUWork.TbsPartsCode.Equals(0))
                            {
                                deleteList.Add(userPrmSettingUWork);
                            }

                            continue;
                        }

                        userPrmSettingUWork.MakerDispOrder = (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER];
                        userPrmSettingUWork.PrimeDispOrder = (Int32)primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER];
                        userPrmSettingUWork.PrimeDisplayCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
                        userPrmSettingUWork.PrmSetDtlName2 = (String)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME];
                        
                        if (userPrmSettingUWork.TbsPartsCode.Equals(0))
                        {
                            // BLコードが0の場合、優良表示区分を2に細工　※リモート側で書き込む際に、強制的に0にする
                            userPrmSettingUWork.PrimeDisplayCode = 2;
                        }

                        if (!prmSettingUWorkDic.ContainsKey(key))
                        {
                            prmSettingUWorkDic.Add(key, userPrmSettingUWork);
                        }

                        //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ---------------->>>>>
                        userPrmSettingUWork.PrmSetDtlName2ForFac = offerPrmSettingWork.PrmSetDtlName2ForFac;   // 優良設定詳細名称２(工場向け)
                        userPrmSettingUWork.PrmSetDtlName2ForCOw = offerPrmSettingWork.PrmSetDtlName2ForCOw;   // 優良設定詳細名称２(カーオーナー向け)
                        //---ADD　30757 佐々木　貴英　2015/02/24 11070266-00　SCM高速化 Ｃ向け種別対応 ----------------<<<<<

                        // BLコードが0のデータも作成
                        if (!userPrmSettingUWork.TbsPartsCode.Equals(0))
                        {
                            PrmSettingUWork bl0PrmSettingUWork = CreatePrmSettingUWorkWhatBLCodeIs0(userPrmSettingUWork);
                            key = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(middleGenreCode, 0, makerCode, 0, 0);

                            if (!prmSettingUWorkDic.ContainsKey(key))
                            {
                                prmSettingUWorkDic.Add(key, bl0PrmSettingUWork);
                            }
                        }
                    }
                }
            }

            //---------------------------------------------
            // 保存対象の商品管理情報マスタ取得
            //---------------------------------------------
            Dictionary<String, GoodsMngWork> goodsMngWorkDic = new Dictionary<string, GoodsMngWork>();
            foreach (PrmSettingUWork work in prmSettingUWorkDic.Values)
            {
                F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();
                keyGoodsMngList.goodsMGroup = work.GoodsMGroup;
                keyGoodsMngList.goodsMakerCd = work.PartsMakerCd;
                keyGoodsMngList.blGoodsCode = work.TbsPartsCode;

                string key = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(work.GoodsMGroup, work.TbsPartsCode, work.PartsMakerCd);

                if (_GoodsMngList[keyGoodsMngList] == null)
                {
                    // 商品管理情報リストにデータなし→新規作成

                    GoodsMngWork goodsMngWork = new GoodsMngWork();
                    goodsMngWork.EnterpriseCode = this._enterpriseCode;
                    goodsMngWork.SectionCode = this._sectionCode;
                    goodsMngWork.GoodsMakerCd = work.PartsMakerCd;
                    goodsMngWork.BLGoodsCode = work.TbsPartsCode;
                    goodsMngWork.GoodsMGroup = work.GoodsMGroup;

                    if (supplierCodeDic.ContainsKey(key))
                    {
                        goodsMngWork.SupplierCd = supplierCodeDic[key];
                    }

                    
                    if (goodsMngWork.BLGoodsCode.Equals(0))
                    {
                        goodsMngWork.GoodsNo = string.Empty;
                        goodsMngWork.SupplierLot = 0;

                        // ----- DEL 2012/09/25 xupz for redmine#32367----->>>>>
                        // BLコード=0の仕入先コード
                        //goodsMngWork.SupplierCd = GetSupplierCodeWhatBLCodeIs0(work.GoodsMGroup, work.PartsMakerCd);
                        // ----- DEL 2012/09/25 xupz for redmine#32367-----<<<<<
                    }
                    

                    if (!goodsMngWorkDic.ContainsKey(key))
                    {
                        goodsMngWorkDic.Add(key, goodsMngWork);
                    }
                }
                else
                {
                    // 商品管理情報リストにデータあり→更新

                    // 商品管理情報リストから該当データ取得
                    GoodsMngWork goodsMngWork = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];

                    GoodsMngWork tempGoodsMngWork = goodsMngWork.Clone(); // ADD 2012/10/08 xupz for redmine#32367

                    if ((supplierCodeDic.ContainsKey(key)) &&
                        (goodsMngWork.SupplierCd != supplierCodeDic[key]))
                    {
                        //goodsMngWork.SupplierCd = supplierCodeDic[key]; // DEL 2012/10/08 xupz for redmine#32367

                        tempGoodsMngWork.SupplierCd = supplierCodeDic[key]; // ADD 2012/10/08 xupz for redmine#32367

                        if (!goodsMngWorkDic.ContainsKey(key))
                        {
                            //goodsMngWorkDic.Add(key, goodsMngWork); // DEL 2012/10/08 xupz for redmine#32367

                            goodsMngWorkDic.Add(key, tempGoodsMngWork); // ADD 2012/10/08 xupz for redmine#32367
                        }
                    }
                }
            }

            //---------------------------------------------
            // 削除対象の商品管理情報マスタ取得
            //---------------------------------------------
            Dictionary<string, GoodsMngWork> delGoodsMngWorkDic = new Dictionary<string, GoodsMngWork>();
            foreach (PrmSettingUWork work in deleteList)
            {
                F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();
                keyGoodsMngList.goodsMGroup = work.GoodsMGroup;
                keyGoodsMngList.goodsMakerCd = work.PartsMakerCd;
                keyGoodsMngList.blGoodsCode = work.TbsPartsCode;

                string key = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(work.GoodsMGroup, work.TbsPartsCode, work.PartsMakerCd);

                // 複数種別ある場合、全種別が削除対象の時のみ商品管理情報マスタを削除
                ArrayList workList = UserPrimeSettingRecords.FindAll(work.GoodsMGroup, work.TbsPartsCode, work.PartsMakerCd);
                if (workList != null)
                {
                    int totalCount = workList.Count;
                    int count = 0;
                    foreach (PrmSettingUWork temp in deleteList)
                    {
                        if ((work.GoodsMGroup == temp.GoodsMGroup) &&
                            (work.PartsMakerCd == temp.PartsMakerCd) &&
                            (work.TbsPartsCode == temp.TbsPartsCode))
                        {
                            count++;
                        }
                    }
                    if (totalCount != count)
                    {
                        continue;
                    }
                }

                if (_GoodsMngList[keyGoodsMngList] != null)
                {
                    // 商品管理情報リストにデータあり→削除

                    // 商品管理情報リストから該当データ取得
                    GoodsMngWork goodsMngWork = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];

                    if (!delGoodsMngWorkDic.ContainsKey(key))
                    {
                        delGoodsMngWorkDic.Add(key, goodsMngWork);
                    }
                }
            }

            //---------------------------------------------
            // 削除対象の商品管理情報マスタ(BLコード=0)取得
            //---------------------------------------------
            ArrayList bl0GoodsMngWorkList = new ArrayList();
            foreach (GoodsMngWork work in delGoodsMngWorkDic.Values)
            {
                string sectionCd = work.SectionCode.Trim();
                int goodsMGroup = work.GoodsMGroup;
                int makerCd = work.GoodsMakerCd;

                GoodsMngWork bl0GoodsMngWork = new GoodsMngWork();

                int totalCount = 0;
                foreach (GoodsMngWork temp in _GoodsMngList.Values)
                {
                    if ((sectionCd == temp.SectionCode.Trim()) &&
                        (goodsMGroup == temp.GoodsMGroup) &&
                        (makerCd == temp.GoodsMakerCd))
                    {
                        if (temp.BLGoodsCode != 0)
                        {
                            totalCount++;
                        }
                        else
                        {
                            bl0GoodsMngWork = temp;
                        }
                    }
                }

                int count = 0;
                foreach (GoodsMngWork work2 in delGoodsMngWorkDic.Values)
                {
                    if ((sectionCd == work2.SectionCode.Trim()) &&
                        (goodsMGroup == work2.GoodsMGroup) &&
                        (makerCd == work2.GoodsMakerCd) &&
                        (work2.BLGoodsCode != 0))
                    {
                        count++;
                    }
                }

                if (totalCount == count)
                {
                    bl0GoodsMngWorkList.Add(bl0GoodsMngWork);
                }
            }
            foreach (GoodsMngWork work in bl0GoodsMngWorkList)
            {
                string key = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(work.GoodsMGroup, work.BLGoodsCode, work.GoodsMakerCd);

                if (!delGoodsMngWorkDic.ContainsKey(key))
                {
                    delGoodsMngWorkDic.Add(key, work);
                }
            }

            //---------------------------------------------
            // 削除対象の優良設定マスタ(BLコード=0)取得
            //---------------------------------------------
            Dictionary<string, PrmSettingUWork> bl0PrmSettingUWorkDic = new Dictionary<string, PrmSettingUWork>();
            foreach (PrmSettingUWork work in deleteList)
            {
                string sectionCd = work.SectionCode.Trim();
                int goodsMGroup = work.GoodsMGroup;
                int makerCd = work.PartsMakerCd;

                ArrayList bl0PrmSettingUWorkList = UserPrimeSettingRecords.FindAll(sectionCd, goodsMGroup, makerCd);
                if (bl0PrmSettingUWorkList == null)
                {
                    continue;
                }

                int totalCount = bl0PrmSettingUWorkList.Count - 1;

                int count = 0;
                foreach (PrmSettingUWork temp in deleteList)
                {
                    if ((sectionCd == temp.SectionCode.Trim()) &&
                        (goodsMGroup == temp.GoodsMGroup) &&
                        (makerCd == temp.PartsMakerCd) &&
                        (temp.TbsPartsCode != 0))
                    {
                        count++;
                    }
                }

                if (totalCount == count)
                {
                    PrmSettingUWork work2 = UserPrimeSettingRecords.Find(goodsMGroup, 0, makerCd, 0, 0);
                    if (work2 == null)
                    {
                        continue;
                    }

                    string key = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(work2.GoodsMGroup, 0, work2.PartsMakerCd);
                    if (!bl0PrmSettingUWorkDic.ContainsKey(key))
                    {
                        bl0PrmSettingUWorkDic.Add(key, work2);
                    }
                }
            }
            foreach (PrmSettingUWork work in bl0PrmSettingUWorkDic.Values)
            {
                deleteList.Add(work);
            }

            int status = -1;

            //---------------------------------------------
            // 削除処理
            //---------------------------------------------
            if (deleteList.Count > 0)
            {
                ArrayList primeSettingIndexList = new ArrayList();
                for (int index = 0; index < deleteList.Count; index++)
                {
                    PrmSettingUWork work = (PrmSettingUWork)deleteList[index];

                    string goodsKey = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(work.GoodsMGroup, 
                                                                                       work.TbsPartsCode, 
                                                                                       work.PartsMakerCd);

                    foreach (PrmSettingUWork work2 in prmSettingUWorkDic.Values)
                    {
                        if ((work.GoodsMGroup == work2.GoodsMGroup) &&
                            (work.TbsPartsCode == work2.TbsPartsCode) &&
                            (work.PartsMakerCd == work2.PartsMakerCd))
                        {
                            string primeKey = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(work.GoodsMGroup,
                                                                                               work.TbsPartsCode,
                                                                                               work.PartsMakerCd,
                                                                                               work.PrmSetDtlNo1,
                                                                                               work.PrmSetDtlNo2);
                            if (prmSettingUWorkDic.ContainsKey(primeKey))
                            {
                                primeSettingIndexList.Add(index);
                            }

                            if (delGoodsMngWorkDic.ContainsKey(goodsKey))
                            {
                                delGoodsMngWorkDic.Remove(goodsKey);
                            }
                        }
                    }
                }

                if (primeSettingIndexList.Count > 0)
                {
                    for (int index = primeSettingIndexList.Count - 1; index >= 0; index--)
                    {
                        int deleteIndex = (int)primeSettingIndexList[index];
                        deleteList.RemoveAt(deleteIndex);
                    }
                }

                object primeSettingObj = deleteList;
                ArrayList goodsMngList = new ArrayList();
                foreach (GoodsMngWork work in delGoodsMngWorkDic.Values)
                {
                    goodsMngList.Add(work);
                }
                object goodsMngObj = goodsMngList;

                status = primeSettingSearchDB.Delete(primeSettingObj, goodsMngObj);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // 削除したレコードの優良設定マスタ列にDBNullをセット
                foreach (PrmSettingUWork work in deleteList)
                {
                    foreach (DataRowView view in PrimeSettingView)
                    {
                        if (((Int32)view[PrimeSettingInfo.COL_PARTSMAKERCD] == work.PartsMakerCd) &&
                            ((Int32)view[PrimeSettingInfo.COL_MIDDLEGENRECODE] == work.GoodsMGroup) &&
                            ((Int32)view[PrimeSettingInfo.COL_TBSPARTSCODE] == work.TbsPartsCode) &&
                            ((Int32)view[PrimeSettingInfo.COL_SELECTCODE] == work.PrmSetDtlNo1) &&
                            ((Int32)view[PrimeSettingInfo.COL_PRIMEKINDCODE] == work.PrmSetDtlNo2))
                        {
                            view[COL_USERPRIMESETTING] = DBNull.Value;
                            break;
                        }
                    }
                }
            }

            //---------------------------------------------
            // 更新処理
            //---------------------------------------------
            if (prmSettingUWorkDic.Values.Count > 0)
            {
                ArrayList primeSettingList = new ArrayList();
                foreach (PrmSettingUWork work in prmSettingUWorkDic.Values)
                {
                    primeSettingList.Add(work);
                }
                object primeSettingObj = primeSettingList;

                ArrayList goodsMngList = new ArrayList();
                foreach (GoodsMngWork work in goodsMngWorkDic.Values)
                {
                    goodsMngList.Add(work);
                }
                object goodsMngObj = goodsMngList;

                status = primeSettingSearchDB.Write(ref primeSettingObj, ref goodsMngObj);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            }

            // 商品管理情報リスト更新
            status = getGoodsMngList();
            if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                return status;
            }

            // 優良設定(ユーザ)リスト更新
            status = getUserPrimesettingList();

            //PrimeSettingView.RowFilter = rowfilter;
            //PrimeSettingView.Sort = sort;

            return (status);
        }

        #region 仕様が大幅に変更したため削除
        ///// <summary>
        ///// データ更新
        ///// </summary>
        ///// <returns>エラー件数</returns>
        //public int updatePrimeSettingList(out string errorMessage) // TODO:【保存】処理はこのメソッドに集約
        //{
        //    // ADD 2008/11/25 不具合対応[6962] 仕様変更 仕入先コードは全体で必須入力 ---------->>>>>
        //    // 【保存】仕入先コードの入力チェック
        //    if (!HasSupplierCodeOfAllMg_Bl_MkView(out errorMessage))
        //    {
        //        return UPDATE_CHECK_ERROR;
        //    }
        //    // ADD 2008/11/25 不具合対応[6962] 仕様変更 仕入先コードは全体で必須入力 ----------<<<<<

        //    string rowfilter = PrimeSettingView.RowFilter;
        //    string sort = PrimeSettingView.Sort;

        //    // --- ADD 2008/07/01 -------------------------------->>>>>
        //    ArrayList userPrmSettingDelList = new ArrayList();
        //    int status = -1;
        //    // --- ADD 2008/07/01 --------------------------------<<<<< 

        //    try
        //    {
        //        PrimeSettingView.RowFilter = "";
        //        PrimeSettingView.Sort = "";

        //        updateCheckPrimeSettingList();

        //        #region 優良設定マスタ（ユーザー登録分）のパラメータ構築

        //        _UserPrimeSettingList.Clear();
        //        // ADD 2009/01/27 仕様変更↓
        //        IDictionary<string, PrmSettingUWork> writingPrmSettingUWorkMap = new Dictionary<string, PrmSettingUWork>();

        //        // 非表示に変更されたレコードをマークするリスト
        //        IList<int[]> notVisibledMakerBLCodeList = new List<int[]>();  // ADD 2009/01/21 不具合対応[6970]

        //        foreach (DataRowView primeSettingRow in PrimeSettingView)
        //        {
        //            int middleGenreCode = (int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];
        //            int makerCode = (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];
        //            int blCode = (int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE];
        //            int selectCode = (int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE];
        //            int prmSetDtl = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE];
        //            string writingKey = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(middleGenreCode, makerCode, blCode, selectCode, prmSetDtl);
        //            Debug.WriteLine("優良設定マスタ（ユーザー）のパラメータを構築中：" + middleGenreCode.ToString() + ", " + makerCode.ToString() + ", " + blCode.ToString());

        //            // 提供分があってユーザー登録分が無いのは新規
        //            // DEL 2009/01/27 仕様変更↓
        //            // if (primeSettingRow[COL_USERPRIMESETTING] == System.DBNull.Value)
        //            // ADD 2009/01/27 仕様変更 ---------->>>>>
        //            if (
        //                primeSettingRow[COL_USERPRIMESETTING] == System.DBNull.Value
        //                    &&
        //                //UserPrimeSettingRecords.Find(middleGenreCode, blCode, makerCode) == null
        //                UserPrimeSettingRecords.Find(middleGenreCode, blCode, makerCode, selectCode, prmSetDtl) == null
        //            )
        //            // ADD 2008/01/27 仕様変更 ----------<<<<<
        //            {
        //                if ((CheckState)primeSettingRow[COL_CHECKSTATE] == CheckState.Unchecked) continue;  // ADD 2008/07/01
                        
        //                // FIXME:[ゴミ掃除]：BLコード=0のレコードを新規登録
        //                #region 削除コード
        //                //if (
        //                //    ((CheckState)primeSettingRow[COL_CHECKSTATE]).Equals(CheckState.Unchecked)
        //                //        &&
        //                //    !((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]).Equals(0)
        //                //)
        //                //{
        //                //    continue;
        //                //}
        //                #endregion

        //                // 表示区分が"表示無し"のデータは対象外
        //                if ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] == 0)
        //                {
        //                    if (((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]).Equals(0))
        //                    {
        //                        // MEMO:BLコードが0の場合、優良表示区分を2に細工　※リモート側で書き込む際に、強制的に0にする
        //                        Debug.Assert(false, "設計的にありえない");
        //                    }
        //                    else
        //                    {
        //                        continue;
        //                    }
        //                }

        //                //PrimeSettingWork wkPrimeSettingWork = new PrimeSettingWork();  // DEL 2008/07/01
        //                PrmSettingUWork prmSettingUWork = new PrmSettingUWork();      // ADD 2008/07/01

        //                prmSettingUWork.CreateDateTime = DateTime.MinValue;           // 作成日時
        //                prmSettingUWork.UpdateDateTime = DateTime.MinValue;           // 更新日時
        //                prmSettingUWork.EnterpriseCode = this._enterpriseCode;        // 企業コード
        //                prmSettingUWork.FileHeaderGuid = Guid.Empty;                  // GUID
        //                prmSettingUWork.UpdEmployeeCode = "";                         // 更新従業員コード
        //                prmSettingUWork.UpdAssemblyId1 = "";                          // 更新アセンブリID1
        //                prmSettingUWork.UpdAssemblyId2 = "";                          // 更新アセンブリID2
        //                prmSettingUWork.LogicalDeleteCode = 0;                        // 論理削除区分
        //                prmSettingUWork.MakerDispOrder = (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER];
        //                prmSettingUWork.PrimeDisplayCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];

        //                // --- DEL 2008/07/01 -------------------------------->>>>>
        //                #region 削除コード
        //                //wkPrimeSettingWork.DisplayOrder = (Int32)drv[PrimeSettingInfo.COL_DISPLAYORDER];
        //                //wkPrimeSettingWork.MiddleGenreCode = (Int32)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE];
        //                #endregion
        //                //   --- DEL 2008/07/01 --------------------------------<<<<<

        //                // --- ADD 2008/07/01 -------------------------------->>>>>
        //                prmSettingUWork.SectionCode = this._sectionCode;                                 // 拠点コード
        //                prmSettingUWork.PrimeDispOrder = (Int32)primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER];  // 優良表示順位
        //                prmSettingUWork.GoodsMGroup = (Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];  // 商品中分類コード
        //                // --- ADD 2008/07/01 --------------------------------<<<<< 

        //                prmSettingUWork.PartsMakerCd = (Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];
        //                prmSettingUWork.TbsPartsCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE];
        //                prmSettingUWork.TbsPartsCdDerivedNo = (Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO];

        //                // MEMO:BLコードが0の場合、優良表示区分を2に細工　※リモート側で書き込む際に、強制的に0にする
        //                if (prmSettingUWork.TbsPartsCode.Equals(0))
        //                {   
        //                    Debug.WriteLine(prmSettingUWork.GoodsMGroup.ToString() + ", " + prmSettingUWork.PartsMakerCd.ToString());
        //                    prmSettingUWork.PrimeDisplayCode = 2;
        //                }
                        
        //                // --- DEL 2008/07/01 -------------------------------->>>>>
        //                #region 削除コード
        //                //wkPrimeSettingWork.SelectCode = (Int32)drv[PrimeSettingInfo.COL_SELECTCODE];
        //                //wkPrimeSettingWork.PrimeKindCode = (Int32)drv[PrimeSettingInfo.COL_PRIMEKINDCODE];
        //                //wkPrimeSettingWork.PrimeKindName = (string)drv[PrimeSettingInfo.COL_PRIMEKINDNAME];
        //                #endregion
        //                //   --- DEL 2008/07/01 --------------------------------<<<<<

        //                // --- ADD 2008/07/01 -------------------------------->>>>>
        //                prmSettingUWork.PrmSetDtlNo1 = (Int32)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE];        // セレクトコード
        //                prmSettingUWork.PrmSetDtlName1 = (string)primeSettingRow[PrimeSettingInfo.COL_SELECTNAME];     // 優良設定詳細名称１
        //                prmSettingUWork.PrmSetDtlNo2 = (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE];     // 種別コード
        //                prmSettingUWork.PrmSetDtlName2 = (string)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME];  // 優良設定詳細名称２
        //                // --- ADD 2008/07/01 --------------------------------<<<<< 

        //                // FIXME:重複した情報は無視
        //                // ※提供側には拠点コードがないため、同じ中分類+メーカー+BLのレコードが複数ある
        //                if (!writingPrmSettingUWorkMap.ContainsKey(writingKey))
        //                {
        //                    writingPrmSettingUWorkMap.Add(writingKey, prmSettingUWork);
        //                    _UserPrimeSettingList.Add(prmSettingUWork);

        //                    string writingKeyWhatBLCodeIs0 = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(
        //                        middleGenreCode,
        //                        makerCode,
        //                        0,
        //                        0,
        //                        0
        //                    );
        //                    if (!writingPrmSettingUWorkMap.ContainsKey(writingKeyWhatBLCodeIs0))
        //                    {
        //                        PrmSettingUWork bl0PrmSettingUWork = CreatePrmSettingUWorkWhatBLCodeIs0(prmSettingUWork);
        //                        writingPrmSettingUWorkMap.Add(writingKeyWhatBLCodeIs0, bl0PrmSettingUWork);
        //                        _UserPrimeSettingList.Add(bl0PrmSettingUWork);
        //                    }
        //                }
        //                else
        //                {
        //                    PrmSettingUWork temp = (PrmSettingUWork)writingPrmSettingUWorkMap[writingKey];
        //                    if ((temp.PrmSetDtlNo1 != prmSettingUWork.PrmSetDtlNo1) ||
        //                        (temp.PrmSetDtlNo2 != prmSettingUWork.PrmSetDtlNo2))
        //                    {
        //                        _UserPrimeSettingList.Add(prmSettingUWork);

        //                        string writingKeyWhatBLCodeIs0 = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(
        //                        middleGenreCode,
        //                        makerCode,
        //                        0,
        //                        0,
        //                        0
        //                    );
        //                        if (!writingPrmSettingUWorkMap.ContainsKey(writingKeyWhatBLCodeIs0))
        //                        {
        //                            PrmSettingUWork bl0PrmSettingUWork = CreatePrmSettingUWorkWhatBLCodeIs0(prmSettingUWork);
        //                            writingPrmSettingUWorkMap.Add(writingKeyWhatBLCodeIs0, bl0PrmSettingUWork);
        //                            _UserPrimeSettingList.Add(bl0PrmSettingUWork);
        //                        }
        //                    }
        //                }
        //            }
        //            // ユーザー登録分がある
        //            else
        //            {
        //                // ADD 2009/01/27 仕様変更 ---------->>>>>
        //                if (
        //                    primeSettingRow[COL_USERPRIMESETTING] == DBNull.Value
        //                        ||
        //                    //UserPrimeSettingRecords.Find(middleGenreCode, blCode, makerCode) == null
        //                    UserPrimeSettingRecords.Find(middleGenreCode, blCode, makerCode, selectCode, prmSetDtl) == null
        //                )
        //                {
        //                    continue;
        //                }
        //                // ADD 2008/01/27 仕様変更 ----------<<<<<
        //                // --- DEL 2008/07/01 -------------------------------->>>>>
        //                #region 削除コード
        //                //OfferPrimeSettingWork offerdrv = (OfferPrimeSettingWork)drv[COL_OFFERPRIMESETTING];
        //                //PrimeSettingWork userdrv = (PrimeSettingWork)drv[COL_USERPRIMESETTING];
        //                #endregion
        //                //   --- DEL 2008/07/01 --------------------------------<<<<<

        //                // --- ADD 2008/07/01 -------------------------------->>>>>
        //                PrmSettingWork offerPrmSettingWork = (PrmSettingWork)primeSettingRow[COL_OFFERPRIMESETTING];
        //                PrmSettingUWork userPrmSettingUWork = (PrmSettingUWork)primeSettingRow[COL_USERPRIMESETTING];
        //                // --- ADD 2008/07/01 --------------------------------<<<<< 

        //                ////削除された場合（表示無しに変更）
        //                //if ((Int32)drv[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] == 0)  // DEL 2008/07/01

        //                //if (((Int32)drv[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] == 0) || ((CheckState)drv[COL_CHECKSTATE] == CheckState.Unchecked))  // ADD 2008/07/01
        //                if ((CheckState)primeSettingRow[COL_CHECKSTATE] == CheckState.Unchecked)
        //                {
        //                    // --- DEL 2008/07/01 -------------------------------->>>>>
        //                    #region 削除コード
        //                    //userdrv.LogicalDeleteCode = 3;       // 論理削除区分（削除なので内容はチェックしない）
        //                    //_UserPrimeSettingList.Add(userdrv);
        //                    #endregion
        //                    // --- DEL 2008/07/01 --------------------------------<<<<< 

        //                    // FIXME:BLコード=0は無視
        //                    if (!userPrmSettingUWork.TbsPartsCode.Equals(0))
        //                    {
        //                        // 削除リストに追加
        //                        userPrmSettingDelList.Add(userPrmSettingUWork);  // ADD 2008/07/01

        //                        // 優良設定情報クリア
        //                        primeSettingRow[COL_USERPRIMESETTING] = System.DBNull.Value;
        //                    }
        //                }
        //                else
        //                {
        //                    //変更されていない場合は何もしない
        //                    if (
        //                        //メーカー表示順位
        //                        userPrmSettingUWork.MakerDispOrder == (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER]   
        //                            &&           
        //                        //userdrv.DisplayOrder == (Int32)drv[PrimeSettingInfo.COL_DISPLAYORDER] &&             //表示順位          // DEL 2008/07/01
        //                        //表示順位
        //                        userPrmSettingUWork.PrimeDispOrder == (Int32)primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] // ADD 2008/07/01
        //                            &&          // ADD 2008/07/01
        //                        //優良表示区分
        //                        userPrmSettingUWork.PrimeDisplayCode == (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]
        //                            &&       
        //                        //userdrv.PrimeKindName == (string)drv[PrimeSettingInfo.COL_PRIMEKINDNAME]) continue;  //種別名称          // DEL 2008/07/01
        //                        //種別名称          
        //                        userPrmSettingUWork.PrmSetDtlName2 == (string)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME]   // ADD 2008/07/01  
        //                    )
        //                    {
        //                        // ADD 2008/11/25 不具合対応[6962] 仕様変更 仕入先コードは全体で必須入力 ---------->>>>>
        //                        // TODO:仕入先コードも変更の判定に加える
        //                        DataRow[] foundDataRows = this.PrimeSettingTable.Select(
        //                            GetWhere(userPrmSettingUWork.PartsMakerCd, userPrmSettingUWork.GoodsMGroup, userPrmSettingUWork.TbsPartsCode)
        //                        );
        //                        if (!(bool)foundDataRows[0][COL_CHANGEFLAG])
        //                        // ADD 2008/11/25 不具合対応[6962] 仕様変更 仕入先コードは全体で必須入力 ----------<<<<<
        //                        {
        //                            continue;
        //                        }
        //                    }
        //                    // 以後、変更されている場合の処理

        //                    userPrmSettingUWork.MakerDispOrder = (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER];
        //                    //userdrv.DisplayOrder = (Int32)drv[PrimeSettingInfo.COL_DISPLAYORDER];        // DEL 2008/07/01
        //                    userPrmSettingUWork.PrimeDispOrder = (Int32)primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER];        // ADD 2008/07/01
                            
        //                    // ADD 2009/01/21 不具合対応[6970] ---------->>>>>
        //                    // 優良表示区分が「表示無し」に変更された場合、該当する商品管理情報を削除
        //                    if (((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]).Equals(0))
        //                    {
        //                        PrmSettingUWork userPrimeSettingRecord = UserPrimeSettingRecords.Find(
        //                            userPrmSettingUWork.GoodsMGroup,
        //                            userPrmSettingUWork.TbsPartsCode,
        //                            userPrmSettingUWork.PartsMakerCd,
        //                            userPrmSettingUWork.PrmSetDtlNo1,
        //                            userPrmSettingUWork.PrmSetDtlNo2
        //                        );
        //                        if (userPrimeSettingRecord != null)
        //                        {
        //                            if (!userPrimeSettingRecord.PrimeDisplayCode.Equals(0))
        //                            {
        //                                int[] hoges = new int[3];
        //                                hoges[0] = userPrimeSettingRecord.GoodsMGroup;
        //                                hoges[1] = userPrimeSettingRecord.PartsMakerCd;
        //                                hoges[2] = userPrimeSettingRecord.TbsPartsCode;
        //                                notVisibledMakerBLCodeList.Add(hoges);
        //                            }
        //                        }
        //                    }
        //                    // ADD 2009/01/21 不具合対応[6970] ----------<<<<<
                            
        //                    userPrmSettingUWork.PrimeDisplayCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
        //                    //userdrv.PrimeKindName = (string)drv[PrimeSettingInfo.COL_PRIMEKINDNAME];     // DEL 2008/07/01

        //                    // MEMO:BLコードが0の場合、優良表示区分を2に細工　※リモート側で書き込む際に、強制的に0にする
        //                    if (userPrmSettingUWork.TbsPartsCode.Equals(0))
        //                    {
        //                        userPrmSettingUWork.PrimeDisplayCode = 2;
        //                    }

        //                    userPrmSettingUWork.PrmSetDtlName2 = (string)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME];      // ADD 2008/07/01

        //                    // FIXME:重複した情報は無視
        //                    // ※提供側には拠点コードがないため、同じ中分類+メーカー+BLのレコードが複数ある
        //                    if (!writingPrmSettingUWorkMap.ContainsKey(writingKey))
        //                    {
        //                        writingPrmSettingUWorkMap.Add(writingKey, userPrmSettingUWork);
        //                        _UserPrimeSettingList.Add(userPrmSettingUWork);

        //                        string writingKeyWhatBLCodeIs0 = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(
        //                            middleGenreCode,
        //                            makerCode,
        //                            0,
        //                            0,
        //                            0
        //                        );
        //                        if (!writingPrmSettingUWorkMap.ContainsKey(writingKeyWhatBLCodeIs0))
        //                        {
        //                            PrmSettingUWork bl0PrmSettingUWork = CreatePrmSettingUWorkWhatBLCodeIs0(userPrmSettingUWork);
        //                            writingPrmSettingUWorkMap.Add(writingKeyWhatBLCodeIs0, bl0PrmSettingUWork);
        //                            _UserPrimeSettingList.Add(bl0PrmSettingUWork);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        PrmSettingUWork temp = (PrmSettingUWork)writingPrmSettingUWorkMap[writingKey];
        //                        if ((temp.PrmSetDtlNo1 != userPrmSettingUWork.PrmSetDtlNo1) ||
        //                            (temp.PrmSetDtlNo2 != userPrmSettingUWork.PrmSetDtlNo2))
        //                        {
        //                            _UserPrimeSettingList.Add(userPrmSettingUWork);

        //                            string writingKeyWhatBLCodeIs0 = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(
        //                            middleGenreCode,
        //                            makerCode,
        //                            0,
        //                            0,
        //                            0
        //                        );
        //                            if (!writingPrmSettingUWorkMap.ContainsKey(writingKeyWhatBLCodeIs0))
        //                            {
        //                                PrmSettingUWork bl0PrmSettingUWork = CreatePrmSettingUWorkWhatBLCodeIs0(userPrmSettingUWork);
        //                                writingPrmSettingUWorkMap.Add(writingKeyWhatBLCodeIs0, bl0PrmSettingUWork);
        //                                _UserPrimeSettingList.Add(bl0PrmSettingUWork);
        //                            }
        //                        }
        //                    }

        //                }   // if ((CheckState)primeSettingRow[COL_CHECKSTATE] == CheckState.Unchecked)
        //            }   // if (primeSettingRow[COL_USERPRIMESETTING] == System.DBNull.Value)
        //        }   // foreach (DataRowView primeSettingRow in PrimeSettingView)

        //        #endregion  // 優良設定マスタ（ユーザー登録分）のパラメータ構築

        //        #region 商品管理情報のパラメータ構築

        //        // --- ADD 2008/07/01 -------------------------------->>>>>
        //        ArrayList goodsMngList = new ArrayList();
        //        F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();

        //        IDictionary<string, GoodsMngWork> entryGoodsMngWorkMap = new Dictionary<string, GoodsMngWork>();

        //        // [保存]…中分類/BL/メーカー データテーブルの内容を展開
        //        foreach (DataRowView mgBLMkRow in Mg_Bl_MkView)
        //        {
        //            // 共通設定レコードは無視
        //            if (IsCommonRowOfMiddleGBLMakerDataTable(mgBLMkRow)) continue;   // ADD 2008/10/29 不具合対応[6969] 仕様変更

        //            //if ((CheckState)mgBLMkRow[COL_CHECKSTATE] == CheckState.Unchecked) continue;
        //            // FIXME:BLコード=0に対応する商品管理情報を更新（基本設定のチェックなし && BLコード≠0 は無視）
        //            if (
        //                ((CheckState)mgBLMkRow[COL_CHECKSTATE]).Equals(CheckState.Unchecked)
        //                    &&
        //                !((int)mgBLMkRow[PrimeSettingInfo.COL_TBSPARTSCODE]).Equals(0)
        //            )
        //            {
        //                continue;
        //            }

        //            keyGoodsMngList.goodsMGroup = (int)mgBLMkRow[PrimeSettingInfo.COL_MIDDLEGENRECODE]; // ADD 2009/01/26 仕様変更：商品管理情報に中分類コードを追加
        //            keyGoodsMngList.goodsMakerCd = (int)mgBLMkRow[PrimeSettingInfo.COL_PARTSMAKERCD];  // 部品メーカーコード
        //            keyGoodsMngList.blGoodsCode = (int)mgBLMkRow[PrimeSettingInfo.COL_TBSPARTSCODE];   // BL商品コード
        //            // FIXME:
        //            string writingKey = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(
        //                keyGoodsMngList.goodsMGroup,
        //                keyGoodsMngList.goodsMakerCd,
        //                keyGoodsMngList.blGoodsCode
        //            );
        //            Debug.WriteLine("商品管理情報のパラメータを構築中：" + keyGoodsMngList.goodsMGroup.ToString() + ", " + keyGoodsMngList.goodsMakerCd.ToString() + ", " + keyGoodsMngList.blGoodsCode.ToString());

        //            // 商品管理情報リストにデータなし→商品管理情報へ新規登録
        //            if (_GoodsMngList[keyGoodsMngList] == null)
        //            {
        //                // 仕入先コード設定あり？
        //                if (mgBLMkRow[PrimeSettingInfo.COL_SUPPLIERCD] != System.DBNull.Value)
        //                {
        //                    GoodsMngWork goodsMngWork = new GoodsMngWork();
        //                    goodsMngWork.EnterpriseCode = this._enterpriseCode;                       // 企業コード
        //                    goodsMngWork.SectionCode = this._sectionCode;                             // 拠点コード
        //                    goodsMngWork.GoodsMakerCd = (int)mgBLMkRow[PrimeSettingInfo.COL_PARTSMAKERCD];  // 部品メーカーコード
        //                    goodsMngWork.BLGoodsCode = (int)mgBLMkRow[PrimeSettingInfo.COL_TBSPARTSCODE];   // BL商品コード
        //                    goodsMngWork.SupplierCd = (int)mgBLMkRow[PrimeSettingInfo.COL_SUPPLIERCD];      // 仕入先コード

        //                    // ADD 2009/01/26 仕様変更↓：商品管理情報に中分類コードを追加
        //                    goodsMngWork.GoodsMGroup = (int)mgBLMkRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];    // 中分類コード

        //                    if (goodsMngWork.BLGoodsCode.Equals(0))
        //                    {
        //                        goodsMngWork.GoodsNo = string.Empty;
        //                        goodsMngWork.SupplierLot = 0;
        //                        // UNDONE:BLコード=0の仕入先コード
        //                        goodsMngWork.SupplierCd = GetSupplierCodeWhatBLCodeIs0(
        //                            goodsMngWork.GoodsMGroup,
        //                            goodsMngWork.GoodsMakerCd
        //                        );
        //                    }

        //                    // FIXME:商品管理情報マスタ更新リストへ追加
        //                    if (!entryGoodsMngWorkMap.ContainsKey(writingKey))
        //                    {
        //                        goodsMngList.Add(goodsMngWork);
        //                        entryGoodsMngWorkMap.Add(writingKey, goodsMngWork);
        //                    }
        //                }
        //                // FIXME:[ゴミ掃除]
        //                #region 削除コード
        //                // ADD 2009/01/27 仕様変更：BLコード=0の商品管理情報を登録 ---------->>>>>
        //                //else if (keyGoodsMngList.blGoodsCode.Equals(0)) // MEMO:仕入先コードの設定なし && BLコード=0
        //                //{
        //                //    GoodsMngWork goodsMngWork = new GoodsMngWork();
        //                //    {
        //                //        goodsMngWork.EnterpriseCode = this._enterpriseCode;                       // 企業コード
        //                //        goodsMngWork.SectionCode = this._sectionCode;                             // 拠点コード
        //                //        goodsMngWork.GoodsMakerCd = (int)mgBLMkRow[PrimeSettingInfo.COL_PARTSMAKERCD];  // 部品メーカーコード
        //                //        goodsMngWork.BLGoodsCode = (int)mgBLMkRow[PrimeSettingInfo.COL_TBSPARTSCODE];   // BL商品コード
        //                //        goodsMngWork.GoodsMGroup = (int)mgBLMkRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];    // 中分類コード
        //                //        goodsMngWork.GoodsNo = string.Empty;
        //                //        goodsMngWork.SupplierLot = 0;
        //                //        // UNDONE:BLコード=0の仕入先コード
        //                //        goodsMngWork.SupplierCd = GetSupplierCodeWhatBLCodeIs0(
        //                //            goodsMngWork.GoodsMGroup,
        //                //            goodsMngWork.GoodsMakerCd
        //                //        );
        //                //    }
        //                //    // FIXME:商品管理情報マスタ更新リストへ追加
        //                //    if (!entryGoodsMngWorkMap.ContainsKey(writingKey))
        //                //    {
        //                //        goodsMngList.Add(goodsMngWork);
        //                //        entryGoodsMngWorkMap.Add(writingKey, goodsMngWork);
        //                //    }
        //                //}
        //                // ADD 2008/01/27 仕様変更：BLコード=0の商品管理情報を登録 ----------<<<<<
        //                #endregion
        //            }
        //            // 商品管理情報リストにデータあり→商品管理情報を更新
        //            else
        //            {
        //                // 商品管理情報リストから該当データ取得
        //                GoodsMngWork goodsMngWork = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];

        //                // 仕入先コードは設定されている？
        //                if (mgBLMkRow[PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
        //                {
        //                    // 【保存】仕入先コード変更あり→商品管理情報を更新
        //                    if ((int)mgBLMkRow[PrimeSettingInfo.COL_SUPPLIERCD] != goodsMngWork.SupplierCd)
        //                    {
        //                        // 仕入先コード更新
        //                        goodsMngWork.SupplierCd = (int)mgBLMkRow[PrimeSettingInfo.COL_SUPPLIERCD];

        //                        // FIXME:商品管理情報マスタ更新リストへ追加
        //                        if (!entryGoodsMngWorkMap.ContainsKey(writingKey))
        //                        {
        //                            goodsMngList.Add(goodsMngWork);
        //                            entryGoodsMngWorkMap.Add(writingKey, goodsMngWork);
        //                        }
        //                    }
        //                    // DEL 2009/01/21 不具合対応[6970] ---------->>>>>
        //                    #region 削除コード
        //                    //// 優良表示区分が「表示無」のときは商品管理情報を削除
        //                    //else if (((int)mgBLMkRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]).Equals(0))   // 優良表示区分==表示無
        //                    //{
        //                    //    // 商品管理情報マスタ更新リストへ追加
        //                    //    goodsMngList.Add(goodsMngWork);
        //                    //}
        //                    #endregion  // 削除コード
        //                    // DEL 2009/01/21 不具合対応[6970] ----------<<<<<
        //                }
        //                else // 仕入先コードのレコード存在しない≡対応する商品管理情報が存在しないかその仕入先コードが0
        //                {
        //                    if (goodsMngWork.SupplierCd != 0)
        //                    {
        //                        // 仕入先コード更新
        //                        goodsMngWork.SupplierCd = 0;

        //                        // FIXME:商品管理情報マスタ更新リストへ追加
        //                        if (!entryGoodsMngWorkMap.ContainsKey(writingKey))
        //                        {
        //                            goodsMngList.Add(goodsMngWork);
        //                            entryGoodsMngWorkMap.Add(writingKey, goodsMngWork);
        //                        }

        //                        if (goodsMngWork.BLGoodsCode.Equals(0))
        //                        {
        //                            Debug.WriteLine(goodsMngWork.GoodsMakerCd.ToString() + ", " + goodsMngWork.SupplierCd.ToString());
        //                        }
        //                    }
        //                }   // if (mgBLMkRow[PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
        //            }   // if (_GoodsMngList[keyGoodsMngList] == null)
        //        }   // foreach (DataRowView mgBLMkRow in Mg_Bl_MkView)

        //        // FIXME:
        //        foreach (string writingKey in writingPrmSettingUWorkMap.Keys)
        //        {
        //            if (entryGoodsMngWorkMap.ContainsKey(writingKey)) continue;

        //            PrmSettingUWork userPrimeSetting = writingPrmSettingUWorkMap[writingKey];
        //            if (!userPrimeSetting.TbsPartsCode.Equals(0)) continue;

        //            GoodsMngWork goodsMngWork = CreateGoodsMngWorkWhatBLCodeIs0(userPrimeSetting);
        //            goodsMngList.Add(goodsMngWork);
        //            entryGoodsMngWorkMap.Add(writingKey, goodsMngWork);
        //        }

        //        // ADD 2009/01/21 不具合対応[6970] 優良設定マスタ（ユーザー登録分）を削除するときは商品管理情報も削除 ---------->>>>>
        //        // 「表示無し」に変更された優良設定マスタ（ユーザー登録分）レコードに対応する商品管理情報を追加
        //        if (notVisibledMakerBLCodeList.Count > 0)
        //        {
        //            foreach (int[] makerBLCode in notVisibledMakerBLCodeList)
        //            {
        //                keyGoodsMngList.goodsMGroup = makerBLCode[0];
        //                keyGoodsMngList.goodsMakerCd= makerBLCode[1];
        //                keyGoodsMngList.blGoodsCode = makerBLCode[2];
        //                if (_GoodsMngList[keyGoodsMngList] != null)
        //                {
        //                    GoodsMngWork deletingGoodsMng = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];
        //                    bool found = false;
        //                    foreach (GoodsMngWork goodsMngWork in goodsMngList)
        //                    {
        //                        // 同じ商品管理情報は追加しない
        //                        if (
        //                            goodsMngWork.GoodsMakerCd.Equals(deletingGoodsMng.GoodsMakerCd)
        //                                &&
        //                            goodsMngWork.BLGoodsCode.Equals(deletingGoodsMng.BLGoodsCode)
        //                        )
        //                        {
        //                            found = true;
        //                            continue;
        //                        }
        //                    }
        //                    if (!found)
        //                    {
        //                        string writingKey = UserPrimeSettingAgreegate.GetKey(
        //                            keyGoodsMngList.goodsMGroup,
        //                            keyGoodsMngList.goodsMakerCd,   // FIXME:
        //                            keyGoodsMngList.blGoodsCode     // FIXME:
        //                        );
        //                        if (!entryGoodsMngWorkMap.ContainsKey(writingKey))
        //                        {
        //                            goodsMngList.Add(deletingGoodsMng);
        //                            entryGoodsMngWorkMap.Add(writingKey, deletingGoodsMng);
        //                        }
        //                    }
        //                }   // if (_GoodsMngList[keyGoodsMngList] != null)
        //            }   // foreach (int[] makerBLCode in notVisibledMakerBLCodeList)
        //        }   // if (notVisibledMakerBLCodeList.Count > 0)
                
        //        // 商品管理情報の削除リストを構築
        //        ArrayList deletingGoodsMngList = new ArrayList();
        //        if (userPrmSettingDelList.Count > 0)
        //        {
        //            foreach (PrmSettingUWork deletingPrmSettingUWork in userPrmSettingDelList)
        //            {
        //                keyGoodsMngList.goodsMGroup = deletingPrmSettingUWork.GoodsMGroup;  // ADD 2009/01/26 仕様変更：商品管理情報に中分類コードを追加
        //                keyGoodsMngList.goodsMakerCd= deletingPrmSettingUWork.PartsMakerCd; // 部品メーカーコード
        //                keyGoodsMngList.blGoodsCode = deletingPrmSettingUWork.TbsPartsCode; // BL商品コード
        //                if (_GoodsMngList[keyGoodsMngList] != null)
        //                {
        //                    GoodsMngWork deletingGoodsMng = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];
        //                    deletingGoodsMngList.Add(deletingGoodsMng);
        //                }
        //            }
        //        }
        //        // ADD 2009/01/21 不具合対応[6970] 優良設定マスタ（ユーザー登録分）を削除するときは商品管理情報も削除 ----------<<<<<
        //        #endregion  // 商品管理情報のパラメータ構築

        //        // ADD 2009/02/17 不具合対応[11241] ---------->>>>>
        //        #region BLコード=0の優良設定マスタ（ユーザー登録分）レコードの削除パラメータを構築

        //        ArrayList deletingPrmSettingUListOfBL0 = new ArrayList();   // BLコード=0の優良設定マスタ（ユーザー登録分）の削除リスト
        //        ArrayList deletingGoodsMngListOfBL0 = new ArrayList();      // BLコード=0の商品管理マスタの削除リスト

        //        // 「表示無し」に変更された優良設定マスタ（ユーザー登録分）レコードに対応するBLコード=0情報を追加
        //        if (notVisibledMakerBLCodeList.Count > 0)
        //        {
        //            foreach (int[] makerBLCode in notVisibledMakerBLCodeList)
        //            {
        //                int targetMiddleGroup   = makerBLCode[0];   // 中分類コード
        //                int targetMakerCode     = makerBLCode[1];   // メーカーコード
        //                int targetBLCode        = makerBLCode[2];   // BLコード

        //                // 基本設定で表示対象となっているものを抽出
        //                StringBuilder where = new StringBuilder();
        //                {
        //                    where.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(targetMiddleGroup);
        //                    where.Append(ADOUtil.AND);
        //                    where.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append(ADOUtil.EQ).Append(targetMakerCode);
        //                    where.Append(ADOUtil.AND);
        //                    where.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
        //                }
        //                DataRow[] foundRows = Mg_Bl_MkTable.Select(where.ToString());

        //                // 同一の中分類 + メーカーに属するBL群が表示設定となっている場合は削除しない
        //                if (foundRows.Length > 1) continue;

        //                if (foundRows.Length.Equals(1))
        //                {
        //                    int foundBLCode = (int)foundRows[0][PrimeSettingInfo.COL_TBSPARTSCODE];
        //                    if (foundBLCode.Equals(targetBLCode))
        //                    {
        //                        // 「表示無し」に変更された優良設定マスタ（ユーザー登録分）レコード自身だったら削除
        //                        #region 「表示無し」に変更された優レコード自身だったら削除

        //                        // 優良設定マスタ（ユーザー登録分）の削除リストに既に追加されているかチェック
        //                        bool isAddedUserList = false;
        //                        foreach (PrmSettingUWork deletingRecord in userPrmSettingDelList)
        //                        {
        //                            if (
        //                                deletingRecord.GoodsMGroup.Equals(targetMiddleGroup)
        //                                    &&
        //                                deletingRecord.PartsMakerCd.Equals(targetMakerCode)
        //                                    &&
        //                                deletingRecord.TbsPartsCode.Equals(0)
        //                            )
        //                            {
        //                                isAddedUserList = true;
        //                                break;
        //                            }
        //                        }
        //                        // 優良設定マスタ（ユーザー登録分）の削除リストに追加されていなければ追加
        //                        if (!isAddedUserList)
        //                        {
        //                            PrmSettingUWork bl0Record = UserPrimeSettingRecords.Find(
        //                                targetMiddleGroup,
        //                                0,
        //                                targetMakerCode,
        //                                0,
        //                                0
        //                            );
        //                            if (bl0Record != null)
        //                            {
        //                                deletingPrmSettingUListOfBL0.Add(bl0Record);
        //                                //userPrmSettingDelList.Add(bl0Record);
        //                            }
        //                        }
        //                        else
        //                        {
        //                            continue;  // 既に追加されていれば、商品管理情報も追加されているはず
        //                        }

        //                        // 商品管理情報の削除リストに既に追加されているかチェック
        //                        bool isAddedGoodsList = false;
        //                        foreach (GoodsMngWork deletingRecord in deletingGoodsMngList)
        //                        {
        //                            if (
        //                                deletingRecord.GoodsMGroup.Equals(targetMiddleGroup)
        //                                    &&
        //                                deletingRecord.GoodsMakerCd.Equals(targetMakerCode)
        //                                    &&
        //                                deletingRecord.BLGoodsCode.Equals(0)
        //                            )
        //                            {
        //                                isAddedGoodsList = true;
        //                                break;
        //                            }
        //                        }
        //                        // 商品管理情報の削除リストに追加されていなければ追加
        //                        if (!isAddedGoodsList)
        //                        {
        //                            F_KEY_GOODSMNGLIST goodsMngKey = new F_KEY_GOODSMNGLIST();
        //                            {
        //                                goodsMngKey.goodsMGroup = targetMiddleGroup;
        //                                goodsMngKey.goodsMakerCd= targetMakerCode;
        //                                goodsMngKey.blGoodsCode = 0;
        //                            }
        //                            GoodsMngWork bl0GoodsMngWork = (GoodsMngWork)_GoodsMngList[goodsMngKey];
        //                            if (bl0GoodsMngWork != null)
        //                            {
        //                                deletingGoodsMngListOfBL0.Add(bl0GoodsMngWork);
        //                                //deletingGoodsMngList.Add(bl0GoodsMngWork);
        //                            }
        //                        }

        //                        // 更新対象となっていれば、優良設定マスタ（ユーザー登録分）の更新リストより削除
        //                        foreach (PrmSettingUWork writingRecord in _UserPrimeSettingList)
        //                        {
        //                            if (
        //                                writingRecord.GoodsMGroup.Equals(targetMiddleGroup)
        //                                    &&
        //                                writingRecord.PartsMakerCd.Equals(targetMakerCode)
        //                                    &&
        //                                writingRecord.TbsPartsCode.Equals(0)
        //                            )
        //                            {
        //                                _UserPrimeSettingList.Remove(writingRecord);
        //                                break;
        //                            }
        //                        }

        //                        // 更新対象となっていれば、商品管理情報の更新リストより削除
        //                        foreach (GoodsMngWork writingRecord in goodsMngList)
        //                        {
        //                            if (
        //                                writingRecord.GoodsMGroup.Equals(targetMiddleGroup)
        //                                    &&
        //                                writingRecord.GoodsMakerCd.Equals(targetMakerCode)
        //                                    &&
        //                                writingRecord.BLGoodsCode.Equals(0)
        //                            )
        //                            {
        //                                goodsMngList.Remove(writingRecord);
        //                                break;
        //                            }
        //                        }

        //                        #endregion  // 「表示無し」に変更された優レコード自身だったら削除
        //                    }   // if (foundBLCode.Equals(targetBLCode))
        //                }   // if (foundRows.Length.Equals(1))
        //                else
        //                {
        //                    // 同一の中分類 + メーカーに属するBLが何も無ければ削除
        //                    #region 同一の中分類 + メーカーに属するBLが何も無ければ削除

        //                    // 優良設定マスタ（ユーザー登録分）の削除リストに既に追加されているかチェック
        //                    bool isAddedUserList = false;
        //                    foreach (PrmSettingUWork deletingRecord in userPrmSettingDelList)
        //                    {
        //                        if (
        //                            deletingRecord.GoodsMGroup.Equals(targetMiddleGroup)
        //                                &&
        //                            deletingRecord.PartsMakerCd.Equals(targetMakerCode)
        //                                &&
        //                            deletingRecord.TbsPartsCode.Equals(0)
        //                        )
        //                        {
        //                            isAddedUserList = true;
        //                            break;
        //                        }
        //                    }
        //                    // 優良設定マスタ（ユーザー登録分）の削除リストに追加されていなければ追加
        //                    if (!isAddedUserList)
        //                    {
        //                        PrmSettingUWork bl0Record = UserPrimeSettingRecords.Find(
        //                            targetMiddleGroup,
        //                            0,
        //                            targetMakerCode,
        //                            0,
        //                            0
        //                        );
        //                        if (bl0Record != null)
        //                        {
        //                            deletingPrmSettingUListOfBL0.Add(bl0Record);
        //                            //userPrmSettingDelList.Add(bl0Record);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        continue;  // 既に追加されていれば、商品管理情報も追加されているはず
        //                    }

        //                    // 商品管理情報の削除リストに既に追加されているかチェック
        //                    bool isAddedGoodsList = false;
        //                    foreach (GoodsMngWork deletingRecord in deletingGoodsMngList)
        //                    {
        //                        if (
        //                            deletingRecord.GoodsMGroup.Equals(targetMiddleGroup)
        //                                &&
        //                            deletingRecord.GoodsMakerCd.Equals(targetMakerCode)
        //                                &&
        //                            deletingRecord.BLGoodsCode.Equals(0)
        //                        )
        //                        {
        //                            isAddedGoodsList = true;
        //                            break;
        //                        }
        //                    }
        //                    // 商品管理情報の削除リストに追加されていなければ追加
        //                    if (!isAddedGoodsList)
        //                    {
        //                        F_KEY_GOODSMNGLIST goodsMngKey = new F_KEY_GOODSMNGLIST();
        //                        {
        //                            goodsMngKey.goodsMGroup = targetMiddleGroup;
        //                            goodsMngKey.goodsMakerCd = targetMakerCode;
        //                            goodsMngKey.blGoodsCode = 0;
        //                        }
        //                        GoodsMngWork bl0GoodsMngWork = (GoodsMngWork)_GoodsMngList[goodsMngKey];
        //                        if (bl0GoodsMngWork != null)
        //                        {
        //                            deletingGoodsMngListOfBL0.Add(bl0GoodsMngWork);
        //                            //deletingGoodsMngList.Add(bl0GoodsMngWork);
        //                        }
        //                    }

        //                    // 更新対象となっていれば、優良設定マスタ（ユーザー登録分）の更新リストより削除
        //                    foreach (PrmSettingUWork writingRecord in _UserPrimeSettingList)
        //                    {
        //                        if (
        //                            writingRecord.GoodsMGroup.Equals(targetMiddleGroup)
        //                                &&
        //                            writingRecord.PartsMakerCd.Equals(targetMakerCode)
        //                                &&
        //                            writingRecord.TbsPartsCode.Equals(0)
        //                        )
        //                        {
        //                            _UserPrimeSettingList.Remove(writingRecord);
        //                            break;
        //                        }
        //                    }

        //                    // 更新対象となっていれば、商品管理情報の更新リストより削除
        //                    foreach (GoodsMngWork writingRecord in goodsMngList)
        //                    {
        //                        if (
        //                            writingRecord.GoodsMGroup.Equals(targetMiddleGroup)
        //                                &&
        //                            writingRecord.GoodsMakerCd.Equals(targetMakerCode)
        //                                &&
        //                            writingRecord.BLGoodsCode.Equals(0)
        //                        )
        //                        {
        //                            goodsMngList.Remove(writingRecord);
        //                            break;
        //                        }
        //                    }

        //                    #endregion  // 同一の中分類 + メーカーに属するBLが何も無ければ削除
        //                }   // if (foundRows.Length.Equals(1))
        //            }   // foreach (int[] makerBLCode in notVisibledMakerBLCodeList)
        //        }   // if (notVisibledMakerBLCodeList.Count > 0)

        //        #endregion  // BLコード=0の優良設定マスタ（ユーザー登録分）レコードの削除パラメータを構築
        //        // ADD 2008/02/17 不具合対応[11241] ----------<<<<<

        //        #region リモート呼び出し

        //        #region 優良設定マスタ（ユーザー登録分）と商品管理情報の削除

        //        if (userPrmSettingDelList.Count > 0)
        //        {
        //            // DEL 2008/11/21 不具合対応[6970] 「表示無」のときは削除する必要はない ---------->>>>>
        //            #region 削除コード
        //            //// ADD 2008/11/04 不具合対応[6970] 仕様変更 ---------->>>>>
        //            //// 削除する商品管理情報
        //            //ArrayList deletingGoodsMngList = new ArrayList();
        //            //foreach (PrmSettingUWork deleteingPrmSettingUWork in userPrmSettingDelList)
        //            //{
        //            //    deletingGoodsMngList.Add(CreateGoodsMngWorkFromMiddleBLMakerTbl(deleteingPrmSettingUWork));
        //            //}
        //            //object objDeletingGoodsMngList = (object)deletingGoodsMngList;
        //            //status = primeSettingSearchDB.Delete(userPrmSettingDelList, objDeletingGoodsMngList);
        //            //// ADD 2008/11/04 不具合対応[6970] 仕様変更 ----------<<<<<
        //            #endregion
        //            // DEL 2008/11/21 不具合対応[6970] 「表示無」のときは削除する必要はない ----------<<<<<

        //            // DEL 2008/11/04 不具合対応[6970]↓
        //            //status = primeSettingSearchDB.Delete(userPrmSettingDelList);

        //            // MEMO:【データベース削除】
        //            // ADD 2009/01/21 不具合対応[6970] 優良設定マスタ（ユーザー登録分）を削除するときは商品管理情報も削除 ---------->>>>>

        //            // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
        //            //object objDeletingPrimeSettingUList = (object)userPrmSettingDelList;
        //            //object objDeletingGoodsMngList = (object)deletingGoodsMngList;

        //            Dictionary<string, PrmSettingUWork> userPrmSettingDic = new Dictionary<string, PrmSettingUWork>();
        //            foreach (PrmSettingUWork work in userPrmSettingDelList)
        //            {
        //                string key = UserPrimeSettingAgreegate.GetKey(work.GoodsMGroup, work.TbsPartsCode, work.PartsMakerCd,
        //                                                              work.PrmSetDtlNo1, work.PrmSetDtlNo2);

        //                if (!userPrmSettingDic.ContainsKey(key))
        //                {
        //                    userPrmSettingDic.Add(key, work);
        //                }
        //            }

        //            ArrayList addList = new ArrayList();
        //            foreach (PrmSettingUWork work in userPrmSettingDic.Values)
        //            {
        //                addList.Add(work);

        //                ArrayList retList = UserPrimeSettingRecords.FindAll(work.GoodsMGroup, work.TbsPartsCode, work.PartsMakerCd);
        //                if (retList == null)
        //                {
        //                    continue;
        //                }

        //                foreach (PrmSettingUWork work2 in retList)
        //                {
        //                    if (work2.TbsPartsCode == 0)
        //                    {
        //                        continue;
        //                    }

        //                    string key = UserPrimeSettingAgreegate.GetKey(work2.GoodsMGroup, work2.TbsPartsCode, work2.PartsMakerCd,
        //                                                              work2.PrmSetDtlNo1, work2.PrmSetDtlNo2);

        //                    if (!userPrmSettingDic.ContainsKey(key))
        //                    {
        //                        addList.Add(work2);
        //                    }
        //                }
        //            }

        //            object objDeletingPrimeSettingUList = (object)addList;

        //            Dictionary<string, GoodsMngWork> goodsMngWorkDic = new Dictionary<string, GoodsMngWork>();
        //            foreach (GoodsMngWork work in deletingGoodsMngList)
        //            {
        //                string key = work.GoodsMakerCd.ToString("0000") + work.GoodsMGroup.ToString("0000") + work.BLGoodsCode.ToString("00000");
        //                if (!goodsMngWorkDic.ContainsKey(key))
        //                {
        //                    goodsMngWorkDic.Add(key, work);
        //                }
        //            }

        //            ArrayList deleteGoodsMngList = new ArrayList();
        //            foreach (GoodsMngWork work in goodsMngWorkDic.Values)
        //            {
        //                deleteGoodsMngList.Add(work);
        //            }

        //            object objDeletingGoodsMngList = (object)deleteGoodsMngList;
        //            // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

        //            status = primeSettingSearchDB.Delete(objDeletingPrimeSettingUList, objDeletingGoodsMngList);
        //            // ADD 2009/01/21 不具合対応[6970] 優良設定マスタ（ユーザー登録分）を削除するときは商品管理情報も削除 ----------<<<<<
        //            // DEL 2009/01/21 不具合対応[6970]↓ 優良設定マスタ（ユーザー登録分）を削除するときは商品管理情報も削除
        //            //status = primeSettingSearchDB.Delete(userPrmSettingDelList, deletingGoodsMngList);
        //            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //            {
        //                return status;
        //            }
        //        }

        //        #endregion  // 優良設定マスタ（ユーザー登録分）と商品管理情報の削除

        //        for (int index = 0; index < notVisibledMakerBLCodeList.Count; index++)
        //        {
        //            int[] hoges = notVisibledMakerBLCodeList[index];

        //            ArrayList dataRowViewList = new ArrayList();
        //            foreach (DataRowView primeSettingRow in PrimeSettingView)
        //            {
        //                if ((hoges[0] == (Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE]) &&
        //                    (hoges[1] == (Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD]) &&
        //                    (hoges[2] == (Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]))
        //                {
        //                    dataRowViewList.Add(primeSettingRow);
        //                }
        //            }

        //            if (dataRowViewList.Count > 1)
        //            {
        //                bool existFlg = false;
        //                foreach (DataRowView drv in dataRowViewList)
        //                {
        //                    if ((Int32)drv[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)
        //                    {
        //                        existFlg = true;
        //                        break;
        //                    }
        //                }

        //                if (!existFlg)
        //                {
        //                    continue;
        //                }

        //                DataRowView dr = (DataRowView)dataRowViewList[0];

        //                for (int listIndex = goodsMngList.Count - 1; listIndex >= 0; listIndex--)
        //                {
        //                    GoodsMngWork work = (GoodsMngWork)goodsMngList[listIndex];

        //                    if ((work.GoodsMGroup == (Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]) &&
        //                        (work.GoodsMakerCd == (Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]) &&
        //                        (work.BLGoodsCode == (Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]))
        //                    {
        //                        goodsMngList.RemoveAt(listIndex);
        //                    }
        //                }
        //            }
        //        }

        //        foreach (PrmSettingUWork work in _UserPrimeSettingList)
        //        {
        //            if (work.PrimeDisplayCode == 0)
        //            {
        //                for (int index = goodsMngList.Count - 1; index >= 0; index--)
        //                {
        //                    GoodsMngWork gmWork = (GoodsMngWork)goodsMngList[index];

        //                    if (gmWork.FileHeaderGuid != Guid.Empty)
        //                    {
        //                        continue;
        //                    }

        //                    if ((work.PartsMakerCd == gmWork.GoodsMakerCd) &&
        //                        (work.GoodsMGroup == gmWork.GoodsMGroup) &&
        //                        (work.TbsPartsCode == gmWork.BLGoodsCode))
        //                    {
        //                        goodsMngList.RemoveAt(index);
        //                        break;
        //                    }
        //                }
        //            }
        //        }

        //        // MEMO:【データベース更新】
        //        object objUserPrimeSetting = (object)_UserPrimeSettingList;  // 優良設定マスタ更新リスト
        //        object objGoodsMng = (object)goodsMngList;                   // 商品管理情報マスタ更新リスト
        //        status = primeSettingSearchDB.Write(ref objUserPrimeSetting, ref objGoodsMng);
        //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            return status;
        //        }

        //        //// ADD 2009/02/17 不具合対応[11241] ---------->>>>>
        //        //// BLコード=0分を削除
        //        //if (deletingPrmSettingUListOfBL0.Count > 0)
        //        //{
        //        //    object objDeletingPrimeSettingUListOfBL0 = (object)deletingPrmSettingUListOfBL0;

        //        //    // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
        //        //    //object objDeletingGoodsMngListOfBL0 = (object)deletingGoodsMngListOfBL0;

        //        //    Dictionary<string, GoodsMngWork> goodsMngWorkDic = new Dictionary<string, GoodsMngWork>();
        //        //    foreach (GoodsMngWork work in deletingGoodsMngList)
        //        //    {
        //        //        string key = work.GoodsMakerCd.ToString("0000") + work.GoodsMGroup.ToString("0000") + work.BLGoodsCode.ToString("00000");
        //        //        if (!goodsMngWorkDic.ContainsKey(key))
        //        //        {
        //        //            goodsMngWorkDic.Add(key, work);
        //        //        }
        //        //    }

        //        //    ArrayList deleteGoodsMngList = new ArrayList();
        //        //    foreach (GoodsMngWork work in goodsMngWorkDic.Values)
        //        //    {
        //        //        deleteGoodsMngList.Add(work);
        //        //    }

        //        //    object objDeletingGoodsMngListOfBL0 = (object)deleteGoodsMngList;
        //        //    // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

        //        //    status = primeSettingSearchDB.Delete(objDeletingPrimeSettingUListOfBL0, objDeletingGoodsMngListOfBL0);
        //        //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        //    {
        //        //        return status;
        //        //    }
        //        //}
        //        //// ADD 2008/02/17 不具合対応[11241] ----------<<<<<

        //        #endregion  // リモート呼び出し

        //        #region 現在の状態を更新

        //        // 商品管理情報リスト更新
        //        status = getGoodsMngList();
        //        if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
        //            (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
        //            (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
        //        {
        //            return status;
        //        }

        //        // 優良設定(ユーザ)リスト更新
        //        status = getUserPrimesettingList();
        //        // --- ADD 2008/07/01 --------------------------------<<<<< 

        //        #endregion  // 現在の状態を更新

        //        PrimeSettingView.RowFilter = rowfilter;
        //        PrimeSettingView.Sort = sort;
        //    }
        //    catch (Exception)
        //    {
        //        status = -1;
        //    }

        //    return status;
        //}
        #endregion 仕様が大幅に変更したため削除

        // ADD 2009/01/27 仕様変更 中分類コードのくくりも表示 ---------->>>>>
        /// <summary>
        /// BLコードが<c>0</c>の場合の仕入先コードを取得します。
        /// </summary>
        /// <param name="middleGanreCode">中分類コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns></returns>
        private int GetSupplierCodeWhatBLCodeIs0(
            int middleGanreCode,
            int makerCode
        )
        {
            StringBuilder where = new StringBuilder();
            {
                where.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(middleGanreCode);
                where.Append(ADOUtil.AND);
                where.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append(ADOUtil.EQ).Append(makerCode);
                where.Append(ADOUtil.AND);
                where.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.NOT_EQ).Append(0);
            }
            DataRow[] foundRows = this.Mg_Bl_MkTable.Select(where.ToString());

            if (foundRows.Length.Equals(0)) return 0;

            int currentSupplierCode = 0;
            {
                if (foundRows[0][PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
                {
                    currentSupplierCode = (int)foundRows[0][PrimeSettingInfo.COL_SUPPLIERCD];
                }

                if (foundRows.Length.Equals(1)) return currentSupplierCode;

                foreach (DataRow foundRow in foundRows)
                {
                    if (foundRow[PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
                    {
                        int foundSupplierCode = (int)foundRow[PrimeSettingInfo.COL_SUPPLIERCD];
                        if (!foundSupplierCode.Equals(currentSupplierCode))
                        {
                            return 0;
                        }
                    }
                }
            }
            return currentSupplierCode;
        }
        // ADD 2009/01/27 仕様変更 中分類コードのくくりも表示 ----------<<<<<

        /// <summary>更新前チェックエラー定数</summary>
        public const int UPDATE_CHECK_ERROR = -1;

        /// <summary>
        /// 全ての中分類/BL/メーカーレコードに仕入先コードが設定されているか判定します。
        /// </summary>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>
        /// <c>true</c> :仕入先コードが設定されている。<br/>
        /// <c>false</c>:仕入先コードが設定されていない。
        /// </returns>
        private bool HasSupplierCodeOfAllMg_Bl_MkView(out string errorMessage)
        {
            errorMessage = string.Empty;

            string currentRowFilter = this.Mg_Bl_MkView.RowFilter;
            try
            {
                this.Mg_Bl_MkView.RowFilter = string.Empty;

                foreach (DataRowView record in this.Mg_Bl_MkView)
                {
                    if ((CheckState)record[COL_CHECKSTATE] == CheckState.Unchecked) continue;
                    if (IsCommonRowOfMiddleGBLMakerDataTable(record)) continue; // 共通レコードは無視

                    if (
                        string.IsNullOrEmpty(record[PrimeSettingInfo.COL_SUPPLIERCD].ToString())
                            ||
                        ((int)record[PrimeSettingInfo.COL_SUPPLIERCD]) <= 0
                    )
                    {
                        int makerCode   = (int)record[PrimeSettingInfo.COL_PARTSMAKERCD];
                        int middleCode  = (int)record[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                        int blCode      = (int)record[PrimeSettingInfo.COL_TBSPARTSCODE];

                        if (blCode == 0)
                        {
                            continue;
                        }

                        NoteChangedEventArgs errMsg = new NoteChangedEventArgs(middleCode, blCode, makerCode, string.Empty);

                        errorMessage = "仕入先コードが未入力です。( " + errMsg.ToString() + " )";

                        return false;
                    }
                }
            }
            finally
            {
                this.Mg_Bl_MkView.RowFilter = currentRowFilter;
            }

            return true;
        }

        /// <summary>
        /// 中分類/BL/メーカーデータテーブルのフィルタ文字列を取得します。
        /// </summary>
        /// <param name="maker">メーカーコード</param>
        /// <param name="middle">中分類コード</param>
        /// <param name="bl">BLコード</param>
        /// <returns>中分類/BL/メーカーデータテーブルのフィルタ文字列</returns>
        public static string GetWhere(int maker, int middle, int bl)
        {
            StringBuilder where = new StringBuilder();

            where.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append("=").Append(maker);
            where.Append(" and ");
            where.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append("=").Append(middle);
            where.Append(" and ");
            where.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append("=").Append(bl);

            return where.ToString();
        }

        private static ArrayList CreateArrayList(Hashtable hashTable)
        {
            ArrayList arrayList = new ArrayList();
            foreach (object val in hashTable.Values)
            {
                arrayList.Add(val);

                GoodsMngWork work = (GoodsMngWork)val;
                if (work.GoodsMakerCd.Equals(1002) && work.BLGoodsCode.Equals(92))
                {
                    Debug.WriteLine(work.GoodsMakerCd.ToString() + ", " + work.BLGoodsCode.ToString());
                }
            }
            return arrayList;
        }

        // ADD 2008/11/04 不具合対応[6970] 仕様変更 ---------->>>>>
        /// <summary>
        /// 中分類/BL/メーカーテーブルより商品管理情報を生成します。
        /// </summary>
        /// <param name="prmSettingUWork">優良設定マスタ（ユーザー登録分）情報</param>
        /// <returns>商品管理情報</returns>
        [Obsolete("削除予定")]
        private GoodsMngWork CreateGoodsMngWorkFromMiddleBLMakerTbl(PrmSettingUWork prmSettingUWork)
        {
            GoodsMngWork goodsMngWork = new GoodsMngWork();

            goodsMngWork.EnterpriseCode = this._enterpriseCode; // 企業コード
            goodsMngWork.SectionCode    = this._sectionCode;    // 拠点コード


            StringBuilder where = new StringBuilder();
            where.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append("=").Append(prmSettingUWork.GoodsMGroup);
            where.Append(" AND ");
            where.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append("=").Append(prmSettingUWork.TbsPartsCode);
            where.Append(" AND ");
            where.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append("=").Append(prmSettingUWork.PartsMakerCd);

            DataRow[] foundMiddleBLMakerDataRows = Mg_Bl_MkTable.Select(where.ToString());
            goodsMngWork.GoodsMakerCd   = (int)foundMiddleBLMakerDataRows[0][PrimeSettingInfo.COL_PARTSMAKERCD];    // 部品メーカーコード
            goodsMngWork.BLGoodsCode    = (int)foundMiddleBLMakerDataRows[0][PrimeSettingInfo.COL_TBSPARTSCODE];    // BL商品コード
            goodsMngWork.SupplierCd     = (int)foundMiddleBLMakerDataRows[0][PrimeSettingInfo.COL_SUPPLIERCD];      // 仕入先コード


            // 商品管理情報の更新日時
            F_KEY_GOODSMNGLIST keyOfGoodMngList = new F_KEY_GOODSMNGLIST();
            keyOfGoodMngList.goodsMGroup    = goodsMngWork.GoodsMGroup; // ADD 2009/01/26 仕様変更：商品管理情報に中分類コードを追加
            keyOfGoodMngList.goodsMakerCd   = goodsMngWork.GoodsMakerCd;// 商品メーカーコード
            keyOfGoodMngList.blGoodsCode    = goodsMngWork.BLGoodsCode; // BL商品コード

            goodsMngWork.UpdateDateTime = ((GoodsMngWork)_GoodsMngList[keyOfGoodMngList]).UpdateDateTime;

            return goodsMngWork;
        }
        // ADD 2008/11/04 不具合対応[6970] 仕様変更 ----------<<<<<

        /// <summary>
        /// 商品管理情報リスト更新
        /// </summary>
        [Obsolete("使用されていないと思われるため、廃止予定")]
        public void updateGoodsMngList(int goodsMGroup, int goodsMakerCd, int blGoodsCode, int supplierCd)   // TODO:商品管理情報リストの更新
        {
            F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();
            GoodsMngWork goodsMngWork;

            keyGoodsMngList.blGoodsCode = blGoodsCode;
            keyGoodsMngList.goodsMakerCd = goodsMakerCd;
            keyGoodsMngList.goodsMGroup = goodsMGroup;  // ADD 2009/01/26 仕様変更：商品管理情報に中分類コードを追加

            if (_GoodsMngList[keyGoodsMngList] != null)
            {
                goodsMngWork = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];

                goodsMngWork.SupplierCd = supplierCd;
            }
            else
            {
                goodsMngWork = new GoodsMngWork();
                goodsMngWork.EnterpriseCode = this._enterpriseCode;
                goodsMngWork.SectionCode = this._sectionCode;
                goodsMngWork.GoodsMakerCd = goodsMakerCd;
                goodsMngWork.BLGoodsCode = blGoodsCode;
                goodsMngWork.SupplierCd = supplierCd;

                // 商品管理情報リストに追加
                _GoodsMngList.Add(keyGoodsMngList, goodsMngWork);
            }
        }

        /// <summary>
        /// データ更新(提供が削除された分のリスト）
        /// </summary>
        /// <returns>エラーコード 正常時０</returns>
        /// <remarks>
        /// <br>Update Note: 2018/10/25 田建委</br>
        /// <br>　　　　　 : Redmine#49731の障害対応</br>
        /// </remarks>
        public int updateUserDeleteList()
        {
            int status = -1;

            /* --- DEL 2008/07/01 -------------------------------->>>>>
            object obj = (object)_UserDeleteList;
            return primeSettingSearchDB.Update(ref obj);  
               --- DEL 2008/07/01 --------------------------------<<<<< */

            // --- ADD 2008/07/01 -------------------------------->>>>>
            try
            {
                // DEL 2008/11/04 不具合対応[6970]↓
                //status = primeSettingSearchDB.Delete(objUserDeleteList);

                object objUserDeleteList = (object)_UserDeleteList;

                // ADD 2008/11/04 不具合対応[6970] 仕様変更 ---------->>>>>
                // --- DEL 田建委 2018/10/25 Redmine#49731の障害対応---------->>>>>
                //ArrayList deletingGoodsMngList = new ArrayList();
                //foreach (PrmSettingUWork prmSettingUWork in _UserDeleteList)
                //{
                //    // TODO:商品管理情報の構築（削除用）
                //    if (ContainsGoodsMng(prmSettingUWork.GoodsMGroup, prmSettingUWork.PartsMakerCd, prmSettingUWork.TbsPartsCode))
                //    {
                //        deletingGoodsMngList.Add(GetGoodsMngWork(prmSettingUWork.GoodsMGroup, prmSettingUWork.PartsMakerCd, prmSettingUWork.TbsPartsCode));
                //    }
                //}
                // --- DEL 田建委 2018/10/25 Redmine#49731の障害対応----------<<<<<

                // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                //object objDeletingGoodsMngList = (object)deletingGoodsMngList;

                // --- DEL 田建委 2018/10/25 Redmine#49731の障害対応---------->>>>>
                //Dictionary<string, GoodsMngWork> goodsMngWorkDic = new Dictionary<string, GoodsMngWork>();
                //foreach (GoodsMngWork work in deletingGoodsMngList)
                //{
                //    string key = work.GoodsMakerCd.ToString("0000") + work.GoodsMGroup.ToString("0000") + work.BLGoodsCode.ToString("00000");
                //    if (!goodsMngWorkDic.ContainsKey(key))
                //    {
                //        goodsMngWorkDic.Add(key, work);
                //    }
                //}
                // --- DEL 田建委 2018/10/25 Redmine#49731の障害対応----------<<<<<

                ArrayList deleteGoodsMngList = new ArrayList();
                // --- DEL 田建委 2018/10/25 Redmine#49731の障害対応---------->>>>>
                //foreach (GoodsMngWork work in goodsMngWorkDic.Values)
                //{
                //    deleteGoodsMngList.Add(work);
                //}
                // --- DEL 田建委 2018/10/25 Redmine#49731の障害対応----------<<<<<
                object objDeletingGoodsMngList = (object)deleteGoodsMngList;
                // --- CHG 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

                status = primeSettingSearchDB.Delete(objUserDeleteList, objDeletingGoodsMngList);   // TODO:削除メソッド呼
                // ADD 2008/11/04 不具合対応[6970] 仕様変更 ----------<<<<<
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
            // --- ADD 2008/07/01 --------------------------------<<<<< 
        }

        /// <summary>
        /// チェックしたメーカーの表示順位を中分類/品目/メーカービューにセット
        /// </summary>
        [Obsolete("表示順を強制的に連番に設定し直します。")]
        public void setMakerDispOrderView()
        {
            // HACK:表示順を強制書き換え
            string rowfilter = Mg_Bl_MkView.RowFilter;
            string sort = Mg_Bl_MkView.Sort;

            Hashtable MgBlht = new Hashtable();
            int order = 1;
            Mg_Bl_MkView.RowFilter = String.Format("{0}=1", COL_CHECKSTATE);
            Mg_Bl_MkView.Sort = (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);
            foreach (DataRowView dr in Mg_Bl_MkView)
            {
                string skey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4") + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8");
                if (MgBlht[skey] == null)
                {
                    MgBlht.Add(skey, dr);
                    order = 1;
                }
                else
                {
                    order++;
                }
                dr[PrimeSettingInfo.COL_MAKERDISPORDER] = order;
            }
            Mg_Bl_MkView.RowFilter = rowfilter;
            Mg_Bl_MkView.Sort = sort;
        }


        /// <summary>
        /// メーカー表示順位、変更フラグ、チェックボックスの状態を優良設定リストにセット
        /// </summary>
        public void updateCheckPrimeSettingList()
        {
            string rowfilter = PrimeSettingView.RowFilter;
            PrimeSettingView.RowFilter = "";

            //キーを作成
            foreach (DataRowView primeSettingRow in PrimeSettingView)
            {
                //キーを作成
                string str = ((Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                            + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4")
                            + ((Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                            + ((Int32)primeSettingRow[PrimeSettingInfo.COL_SECRETCODE]).ToString("d4")
                            + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE]).ToString("d4")
                            ;

                bool changeFlg = false;

                if (_Mg_Bl_Mk_List[str] != null)
                {
                    DataRow MgBlMkdr = (DataRow)_Mg_Bl_Mk_List[str];
                    if (MgBlMkdr[COL_CHECKSTATE] == (object)CheckState.Unchecked)
                    {
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 0;
                    }
                    //primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER] = MgBlMkdr[PrimeSettingInfo.COL_MAKERDISPORDER];
                    primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER] = MgBlMkdr[PrimeSettingAcs.COL_USER_MAKERDISPORDER];
                    primeSettingRow[COL_CHECKSTATE] = MgBlMkdr[COL_CHECKSTATE];
                    if ((CheckState)primeSettingRow[COL_ORIGINAL_CHECKSTATE] != (CheckState)MgBlMkdr[COL_CHECKSTATE])
                    {
                        changeFlg = true;
                    }
                }

                //ユーザー登録分が無い場合は何もしない
                if (primeSettingRow[COL_USERPRIMESETTING] == System.DBNull.Value) continue;

                //変更されていない場合は何もしない
                PrmSettingUWork userdrv = (PrmSettingUWork)primeSettingRow[COL_USERPRIMESETTING];

                primeSettingRow[COL_CHANGEFLAG] = true;

                if (userdrv.MakerDispOrder == (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER] &&       //メーカー表示順位
                    //userdrv.DisplayOrder == (Int32)drv[PrimeSettingInfo.COL_DISPLAYORDER] &&         //表示順位          // DEL 2008/07/01
                    userdrv.PrimeDispOrder == (Int32)primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] &&         //表示順位          // ADD 2008/07/01
                    userdrv.PrimeDisplayCode == (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] &&   //優良表示区分
                    //userdrv.PrimeKindName == (string)drv[PrimeSettingInfo.COL_PRIMEKINDNAME])        //種別名称          // DEL 2008/07/01
                    userdrv.PrmSetDtlName2 == (string)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME] &&    //種別名称          // ADD 2008/07/01
                    changeFlg == false)         
                {
                    primeSettingRow[COL_CHANGEFLAG] = false; 
                }

                
                // --- ADD 2008/07/01 -------------------------------->>>>>
                F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();
                GoodsMngWork goodsMngWork;
                bool supplierChange = false;

                keyGoodsMngList.blGoodsCode = (int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE];   // BLコード
                keyGoodsMngList.goodsMakerCd = (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];  // 部品メーカーコード
                keyGoodsMngList.goodsMGroup = (int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];// 中分類コード

                // 商品管理情報リストにデータあり？
                if (_GoodsMngList[keyGoodsMngList] != null)
                {
                    // 商品管理情報リストから該当データ取得
                    goodsMngWork = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];

                    // 仕入先は設定されている？
                    if (primeSettingRow[PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
                    {
                        // 仕入先コードが異なる場合
                        if (goodsMngWork.SupplierCd != (int)primeSettingRow[PrimeSettingInfo.COL_SUPPLIERCD])
                        {
                            supplierChange = true;
                        }
                    }
                    else
                    {
                        // 仕入先がクリアされた場合
                        if (goodsMngWork.SupplierCd != 0)
                        {
                            supplierChange = true;
                        }
                    }
                }
                else
                {
                    // 新規に仕入先が設定された場合
                    if (primeSettingRow[PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
                    {
                        supplierChange = true;
                    }
                }

                // 仕入先以外が変更ない場合
                if ((bool)primeSettingRow[COL_CHANGEFLAG] == false)
                {
                    // 変更フラグ設定
                    primeSettingRow[COL_CHANGEFLAG] = supplierChange;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 
            }   // foreach (DataRowView primeSettingRow in PrimeSettingView)

            PrimeSettingView.RowFilter = rowfilter;
        }

        /// <summary>
        /// 仕入先コード変更時に変更フラグを更新する
        /// </summary>
        public void ChangeSupplierCd(int goodsMGroup, int partsMakerCd, int tbsPartsCode, int supplierCd)
        {
            foreach (DataRowView drv in PrimeSettingView)
            {
                if (((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                    ((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] == partsMakerCd) &&
                   ((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] == tbsPartsCode))
                {
                    // 仕入先コード更新
                    drv[PrimeSettingInfo.COL_SUPPLIERCD] = supplierCd;

                    break;
                }
            }
        }

        // ADD 2008/10/30 不具合対応[6961] 仕様変更 ---------->>>>>
        /// <summary>
        /// 優良設定備考ハッシュテーブルのキーを取得します。
        /// </summary>
        /// <param name="middleCode">中分類コード</param>
        /// <param name="blCode">BLコード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>中分類コード(4桁)+BLコード(8桁)+メーカーコード(4桁)</returns>
        public static string GetKeyOfOfferPrimeSettingNote(
            int middleCode,
            int blCode,
            int makerCode
        )
        {
            Debug.WriteLine("中分類：" + middleCode.ToString() + ", BL：" + blCode.ToString() + ", メーカー：" + makerCode.ToString());
            return middleCode.ToString("d4") + blCode.ToString("d8") + makerCode.ToString("d4");
        }
        // ADD 2008/10/30 不具合対応[6961] 仕様変更 ----------<<<<<

        // ADD 2009/01/14 仕様変更：中分類コードのくくりも表示 ---------->>>>>
        /// <summary>
        /// 指定したメーカーコードが指定した中分類コードに関連付くか判定します。
        /// </summary>
        /// <param name="middleGenreCode">中分類コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns></returns>
        public bool ContainsMakerCode(
            int middleGenreCode,
            int makerCode
        )
        {
            return MakerList.ContainsMakerCode(middleGenreCode, makerCode);
        }

        /// <summary>
        /// 中分類コードに関連付くメーカーコードを検索します。
        /// </summary>
        /// <param name="middleGenreCode">中分類コード</param>
        /// <returns>中分類コードに関連付くメーカーコード</returns>
        public IList<int> FindMakerCode(int middleGenreCode)
        {
            return MakerList.FindMakerCode(middleGenreCode);
        }
        // ADD 2009/01/14 仕様変更：中分類コードのくくりも表示 ----------<<<<<

        // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
        /// <summary>
        /// 関連BLコードの文字列を取得します。
        /// </summary>
        /// <param name="blCode">BLコード</param>
        /// <returns>BLコード("0000") + ":" + 名称</returns>
        public string GetRelatedBLCodeName(int blCode)
        {
            string blName = string.Empty;
            if (this._TbsPartsCodeList.ContainsKey(blCode.ToString("d8")))
            {
                blName = ((TbsPartsCodeWork)this._TbsPartsCodeList[blCode.ToString("d8")]).TbsPartsFullName;
            }
            return blCode.ToString("d4") + ":" + blName;
        }
        // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<

        # endregion

        #region Private method

        /// <summary>
        /// 中分類リスト取得
        /// </summary>
        //private void getOfferMiddleGenreList()  // DEL 2008/07/01
        private int getOfferMiddleGenreList()     // ADD 2008/07/01
        {
            PrmSettingWork offerMiddleGenreWork = new PrmSettingWork();
            ArrayList al = new ArrayList();
            al.Add(offerMiddleGenreWork);
            object objret = null;
            int status = -1;  // ADD 2008/07/01

            try
            {
                //int status = offerMiddleGenreDB.Search(ref objret, (object)offerMiddleGenreWork, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);  // DEL 2008/07/01
                status = offerMiddleGenreDB.Search(out objret, (object)offerMiddleGenreWork);  // ADD 2008/07/01

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)  // ADD 2008/07/01
                {
                    //foreach (OfferMiddleGenreWork wkOfferMiddleGenreWork in (ArrayList)objret)
                    foreach (GoodsMGroupWork wkOfferMiddleGenreWork in (ArrayList)objret)
                    //部品メーカー結果クラス
                    {
                        //_MiddleGenreList.Add(((Int32)wkOfferMiddleGenreWork.MiddleGenreCode).ToString("d4"), wkOfferMiddleGenreWork);
                        _MiddleGenreList.Add(((Int32)wkOfferMiddleGenreWork.GoodsMGroup).ToString("d4"), wkOfferMiddleGenreWork);
                    }
                }
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }

　      /// <summary>
        /// 部品メーカーリスト取得
        /// </summary>
        //private void getPartsMakerList()  // DEL 2008/07/01
        private int getPartsMakerList()    // ADD 2008/07/01 
        {
            /* --- DEL 2008/07/01 -------------------------------->>>>>
            PMakerNmWork pMakerNmWork = new PMakerNmWork();

			ArrayList al = new ArrayList();
            al.Add(pMakerNmWork);
               --- DEL 2008/07/01 --------------------------------<<<<< */

            object objret = null;
            int status = -1;  // ADD 2008/07/01 

            try
            {
                //int status = pMakerNmDB.Search(out objret,(object)pMakerNmWork,0,Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
                status = pMakerNmDB.Search(out objret, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)  // ADD 2008/07/01
                {
                    foreach (PMakerNmWork wkPMakerNmWork in (ArrayList)objret)
                    //部品メーカー結果クラス
                    {
                        _PartsMakerList.Add(((Int32)wkPMakerNmWork.PartsMakerCode).ToString("d4"), wkPMakerNmWork);
                    }
                }
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }

        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>
        /// 仕入先リスト取得
        /// </summary>
        private int getSupplierList()
        {
            SupplierAcs _supplierAcs = new SupplierAcs();
            Supplier supplier = new Supplier();
            ArrayList supplierList = new ArrayList();
            int status = -1;

            try
            {
                _SupplierList.Clear();

                // 仕入先情報取得
                status = _supplierAcs.Search(out supplierList, this._enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (Supplier wkSupplier in supplierList)
                    {
                        // 仕入先リストに追加
                        _SupplierList.Add(wkSupplier.SupplierCd, wkSupplier);
                    }
                }
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 商品管理情報リスト取得
        /// </summary>
        private int getGoodsMngList()
        {
            object objret = null;
            object paraObjret = null;
            GoodsMngWork paraGoodsMngWork = new GoodsMngWork();
            F_KEY_GOODSMNGLIST keyGoodMngList = new F_KEY_GOODSMNGLIST();
            int status = -1; 

            try
            {
                // 商品管理情報リストクリア
                _GoodsMngList.Clear();

                if (this.EnterPriseCode != null)
                {
                    // 企業コード
                    paraGoodsMngWork.EnterpriseCode = this.EnterPriseCode;
                }
                if (this._sectionCode != null)
                {
                    // 拠点コード
                    paraGoodsMngWork.SectionCode = this._sectionCode;
                }

                paraObjret = paraGoodsMngWork;

                // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// 商品管理情報取得
                //status = goodsMngDB.Search(out objret, paraObjret, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
                // 商品管理情報取得
                status = goodsMngDB.Search(out objret, paraObjret, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetDataAll);
                // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (GoodsMngWork wkGoodsMng in (ArrayList)objret)
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/12 ADD
                        // 品番単位で設定されているレコードは無視する。
                        if ( wkGoodsMng.GoodsNo.TrimEnd() != string.Empty ) continue;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/12 ADD

                        //キーを作成
                        keyGoodMngList.goodsMGroup = wkGoodsMng.GoodsMGroup;    // ADD 2009/01/26 仕様変更：商品管理情報に中分類コードを追加
                        keyGoodMngList.goodsMakerCd = wkGoodsMng.GoodsMakerCd;  // 商品メーカーコード
                        keyGoodMngList.blGoodsCode = wkGoodsMng.BLGoodsCode;    // BL商品コード
                        //keyGoodMngList.goodsNo = wkGoodsMng.GoodsNo;            // 商品番号

                        //DataRowをHashTableに登録しておく
                        _GoodsMngList.Add(keyGoodMngList, wkGoodsMng);  // 商品管理情報のキャッシュ登録
                    }
                }
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }
        // --- ADD 2008/07/01 --------------------------------<<<<< 

        /// <summary>
        /// BLコードリスト取得
        /// </summary>
        //private void getOfferTbsPartsList()  // DEL 2008/07/01
        private int getOfferTbsPartsList()     // ADD 2008/07/01
        {
            TbsPartsCodeWork tbsPartsCodeWork = new TbsPartsCodeWork();
            
            /* --- DEL 2008/07/01 -------------------------------->>>>>
            ArrayList al = new ArrayList();
            al.Add(tbsPartsCodeWork);
            if (this.EnterPriseCode != null)
            {
                tbsPartsCodeWork.EnterpriseCode = this.EnterPriseCode; 
            }
               --- DEL 2008/07/01 --------------------------------<<<<< */

            object objret = null;
            // --- ADD 2008/07/01 -------------------------------->>>>>
            object paraobj = tbsPartsCodeWork;  
            int status = -1;
            // --- ADD 2008/07/01 --------------------------------<<<<< 

            try
            {
                //int status = offerTbsPartsCodeDB.Search(ref objret, (object)al, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);  // DEL 2008/07/01
                status = offerTbsPartsCodeDB.Search(out objret, paraobj);  // ADD 2008/07/01

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (TbsPartsCodeWork wktbsPartsCodeWork in (ArrayList)objret)
                    //BL部品コード結果クラス
                    {
                        //枝番付きは重複するので読み飛ばす
                        //例：1232 0 フロントワイパーアーム
                        //　　1232 1 フロントワイパーアーム　右
                        //　　1232 2 フロントワイパーアーム　左
                        if (wktbsPartsCodeWork.TbsPartsCdDerivedNo != 0) continue;
                        _TbsPartsCodeList.Add(((Int32)wktbsPartsCodeWork.TbsPartsCode).ToString("d8"), wktbsPartsCodeWork);
                    }
                }
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// ユーザー優良設定リスト取得
        /// </summary>
        //private void getUserPrimesettingList()  // DEL 2008/07/01
        private int getUserPrimesettingList()     // ADD 2008/07/01
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            //PrimeSettingParaWork primeSettingParaWork = new PrimeSettingParaWork();  // DEL 2008/07/01
            PrmSettingUWork primeSettingParaWork = new PrmSettingUWork();              // ADD 2008/07/01

            /* --- DEL 2008/07/01 -------------------------------->>>>>
            ArrayList al = new ArrayList();
            al.Add(primeSettingParaWork);
            object objret = null;
               --- DEL 2008/07/01 --------------------------------<<<<< */

            ArrayList wkList = new ArrayList();
            object objret = wkList;

            UserPrimeSettingRecords.Clear();    // ADD 2009/01/21 不具合対応[6970]

            int status = -1;  // ADD 2008/07/01

            try
            {
                if (this._enterpriseCode != null)
                {
                    // 企業コード
                    primeSettingParaWork.EnterpriseCode = this._enterpriseCode;
                }

                if (this._sectionCode != null)
                {
                    // 拠点コード
                    primeSettingParaWork.SectionCode = this._sectionCode;
                }

                // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                primeSettingParaWork.PrimeDisplayCode = -1;
                // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<

                //int status = primeSettingSearchDB.Search(ref objret, primeSettingParaWork);
                status = primeSettingSearchDB.Search(ref objret, primeSettingParaWork, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    DefaultMakerDispOrderManagaer defaultMakerDispOrderMng = new DefaultMakerDispOrderManagaer();   // ADD 2008/12/05 不具合対応[8524] 仕様変更 表示順が設定されていない場合、1～自動で採番

                    Debug.WriteLine("優良設定マスタ（ユーザー）を読込中：");
                    //foreach (PrimeSettingWork wkPrimeSettingWork in (ArrayList)objret)  // DEL 2008/07/01
                    foreach (PrmSettingUWork userPrimeSettingUWork in (ArrayList)objret)     // ADD 2008/07/01
                    {
                        //キーを作成
                        //string str = (wkPrimeSettingWork.MiddleGenreCode.ToString("d4")  // DEL 2008/07/01
                        string str = (userPrimeSettingUWork.GoodsMGroup.ToString("d4")        // ADD 2008/07/01 
                                    + userPrimeSettingUWork.PartsMakerCd.ToString("d4")
                                    + userPrimeSettingUWork.TbsPartsCode.ToString("d8")
                                    + userPrimeSettingUWork.TbsPartsCdDerivedNo.ToString("d2")
                            /* --- DEL 2008/07/01 -------------------------------->>>>>
                            + wkPrimeSettingWork.SelectCode.ToString("d4")
                            + wkPrimeSettingWork.PrimeKindCode.ToString("d2"));
                               --- DEL 2008/07/01 --------------------------------<<<<< */

                                    // --- ADD 2008/07/01 -------------------------------->>>>>
                                    + userPrimeSettingUWork.PrmSetDtlNo1.ToString("d4")
                                    + userPrimeSettingUWork.PrmSetDtlNo2.ToString("d2"));
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        if (userPrimeSettingUWork.TbsPartsCode.Equals(0))
                        {
                            if (userPrimeSettingUWork.GoodsMGroup.Equals(10) && userPrimeSettingUWork.PartsMakerCd.Equals(1185))
                            {
                                // HACK:????
                                Debug.WriteLine("中分類：" + userPrimeSettingUWork.GoodsMGroup.ToString() + ", メーカー：" + userPrimeSettingUWork.PartsMakerCd.ToString());
                            }
                        }

                        if (_PrimeSettingList[str] != null) // MEMO:本メソッドはDataSearch()で呼ばれる。その際、先に提供分の読み込みが行われ、左記Hashtableが構築されている
                        {
                            // MEMO:該当するユーザー優良設定データが有効
                            if (userPrimeSettingUWork.LogicalDeleteCode == 0)
                            {
                                DataRow primedr = (DataRow)_PrimeSettingList[str];
                                //DataRowに取得したワークをセット
                                primedr[COL_USERPRIMESETTING] = userPrimeSettingUWork;

                                //カラムにデータをセット
                                primedr[PrimeSettingInfo.COL_MAKERDISPORDER] = userPrimeSettingUWork.MakerDispOrder;
                                
                                // ADD 2008/12/05 不具合対応[8524] 仕様変更 表示順が設定されていない場合、1～自動で採番 ---------->>>>>
                                // デフォルトの表示順を設定用に一時的に保持
                                if (userPrimeSettingUWork.MakerDispOrder > 0)
                                {
                                    defaultMakerDispOrderMng.Reserve(
                                        userPrimeSettingUWork.GoodsMGroup,
                                        userPrimeSettingUWork.TbsPartsCode,
                                        userPrimeSettingUWork.MakerDispOrder
                                    );
                                }
                                else
                                {
                                    defaultMakerDispOrderMng.Add(
                                        userPrimeSettingUWork.GoodsMGroup,
                                        userPrimeSettingUWork.TbsPartsCode,
                                        primedr
                                    );
                                }
                                // ADD 2008/12/05 不具合対応[8524] 仕様変更 表示順が設定されていない場合、1～自動で採番 ----------<<<<<

                                //primedr[PrimeSettingInfo.COL_DISPLAYORDER] = wkPrimeSettingWork.DisplayOrder;
                                primedr[PrimeSettingInfo.COL_DISPLAYORDER] = userPrimeSettingUWork.PrimeDispOrder;
                                //primedr[COL_CHECKSTATE] = CheckState.Checked;
                                primedr[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = userPrimeSettingUWork.PrimeDisplayCode;   // TODO:優良表示区分

                                UserPrimeSettingRecords.Add(userPrimeSettingUWork); // ADD 2009/01/21 不具合対応[6970]
                            }
                        }
                        //提供が無いのは削除されているデータなので削除リストに登録する（提供が論理削除ではなくレコード削除された）
                        else
                        {
                            userPrimeSettingUWork.LogicalDeleteCode = 3; // 論理削除区分（物理削除なので内容はチェックしない）
                            //リストに削除で追加(作っておくとリモート呼ぶだけでいいので楽）
                            _UserDeleteList.Add(userPrimeSettingUWork);

                            DataRow primeSettingRow = UserPrimeSettingTable.NewRow();
                            UserPrimeSettingTable.Rows.Add(primeSettingRow);

                            /* --- DEL 2008/07/01 -------------------------------->>>>>
                            primedr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] = wkPrimeSettingWork.PartsMakerFullName;
                            primedr[PrimeSettingInfo.COL_TBSPARTSCODE] = wkPrimeSettingWork.TbsPartsCode;
                            primedr[PrimeSettingInfo.COL_TBSPARTSFULLNAME] = wkPrimeSettingWork.TbsPartsFullName;
                            primedr[PrimeSettingInfo.COL_SELECTNAME] = wkPrimeSettingWork.SelectCode.ToString();
                            primedr[PrimeSettingInfo.COL_PRIMEKINDNAME] = wkPrimeSettingWork.PrimeKindName;
                               --- DEL 2008/07/01 --------------------------------<<<<< */

                            // --- ADD 2008/07/01 -------------------------------->>>>> 
                            PMakerNmWork pMakerNmWork;

                            if (_PartsMakerList[userPrimeSettingUWork.PartsMakerCd.ToString("d4")] != null)
                            {
                                pMakerNmWork = (PMakerNmWork)_PartsMakerList[userPrimeSettingUWork.PartsMakerCd.ToString("d4")];

                                // メーカー名称設定
                                primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] = pMakerNmWork.PartsMakerFullName;
                            }

                            TbsPartsCodeWork tbsPartsCodeWork;

                            if (_TbsPartsCodeList[userPrimeSettingUWork.TbsPartsCode.ToString("d8")] != null)
                            {
                                tbsPartsCodeWork = (TbsPartsCodeWork)_TbsPartsCodeList[userPrimeSettingUWork.TbsPartsCode.ToString("d8")];

                                // 品目名設定
                                primeSettingRow[PrimeSettingInfo.COL_TBSPARTSFULLNAME] = tbsPartsCodeWork.TbsPartsFullName;
                            }

                            primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] = userPrimeSettingUWork.TbsPartsCode;
                            primeSettingRow[PrimeSettingInfo.COL_SELECTNAME] = userPrimeSettingUWork.PrmSetDtlName1;
                            primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME] = userPrimeSettingUWork.PrmSetDtlName2;
                            // --- ADD 2008/07/01 --------------------------------<<<<< 
                        }
                    }

                    //defaultMakerDispOrderMng.SetDefaultMakerDispOrder();    // ADD 2008/12/05 不具合対応[8524] 仕様変更 表示順が設定されていない場合、1～自動で採番
                }
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 提供優良設定リスト取得
        /// </summary>
        //private void getOfferPrimesettingList()  // DEL 2008/07/01
        private int getOfferPrimesettingList()     // ADD 2008/07/01
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            object objret = null;
            int status = -1;

            try
            {
                // 提供優良設定取得
                status = offerPrimeSettingSearchDB.Search(out objret);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //foreach (OfferPrimeSettingWork wkPrimeSettingWork in (ArrayList)objret)  // DEL 2008/07/01
                    foreach (PrmSettingWork wkPrimeSettingWork in (ArrayList)objret)           // ADD 2008/07/01
                    //優良設定結果クラス
                    {
                        // --- DEL 2008/11/27 -------------------------------->>>>>
                        #region 削除コード
                        //// UNDONE:拠点違いは対象としない
                        //if (!ContainsGoodsMng(wkPrimeSettingWork.PartsMakerCd, wkPrimeSettingWork.TbsPartsCode))
                        //{
                        //    Debug.WriteLine("[拠点違い]メーカー：" + wkPrimeSettingWork.PartsMakerCd.ToString() + ", BL：" + wkPrimeSettingWork.TbsPartsCode.ToString());
                        //    continue;
                        //}
                        #endregion
                        // --- DEL 2008/11/27 --------------------------------<<<<<
                        DataRow primeSettingRow = PrimeSettingTable.NewRow();
                        PrimeSettingTable.Rows.Add(primeSettingRow);
                        //DataRowに取得したワークをセット
                        {   // TODO:【提供とユーザーを区別するカラム】
                            primeSettingRow[COL_OFFERPRIMESETTING] = wkPrimeSettingWork;
                            primeSettingRow[COL_USERPRIMESETTING] = null;
                            primeSettingRow[COL_CHANGEFLAG] = false;                // 提供は変更不可
                            primeSettingRow[COL_CHECKSTATE] = CheckState.Unchecked; // 提供は未チェック（デフォルト）
                            primeSettingRow[COL_ORIGINAL_CHECKSTATE] = CheckState.Unchecked; // 提供は未チェック（デフォルト）
                        }
                        //カラムにデータをセット
                        //デフォルト表示順位はメーカーコード順
                        primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER] = 0;   // MOD 2009/01/14 仕様変更 wkPrimeSettingWork.PartsMakerCd;→0;

                        //表示区分は０固定(提供の場合）
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 0;
                        primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] = wkPrimeSettingWork.DisplayOrder;
                        //primedr[PrimeSettingInfo.COL_MIDDLEGENRECODE] = wkPrimeSettingWork.MiddleGenreCode;  // DEL 2008/07/01
                        primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] = wkPrimeSettingWork.GoodsMGroup;        // ADD 2008/07/01
                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] = wkPrimeSettingWork.PartsMakerCd;
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] = wkPrimeSettingWork.TbsPartsCode;
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO] = wkPrimeSettingWork.TbsPartsCdDerivedNo;
                        /* --- DEL 2008/07/01 -------------------------------->>>>>
                        primedr[PrimeSettingInfo.COL_SELECTCODE] = wkPrimeSettingWork.SelectCode;
                        primedr[PrimeSettingInfo.COL_PRIMEKINDCODE] = wkPrimeSettingWork.PrimeKindCode;
                           --- DEL 2008/07/01 --------------------------------<<<<< */
                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        primeSettingRow[PrimeSettingInfo.COL_SELECTCODE] = wkPrimeSettingWork.PrmSetDtlNo1;
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE] = wkPrimeSettingWork.PrmSetDtlNo2;
                        // --- ADD 2008/07/01 --------------------------------<<<<< 
                        primeSettingRow[PrimeSettingInfo.COL_SECRETCODE] = wkPrimeSettingWork.SecretCode;

                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] = "";
                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERHALFNAME] = "";
                        //Hashにメーカーがあれば名称取得
                        if (_PartsMakerList[((Int32)wkPrimeSettingWork.PartsMakerCd).ToString("d4")] != null)
                        {
                            primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] = ((PMakerNmWork)_PartsMakerList[((Int32)wkPrimeSettingWork.PartsMakerCd).ToString("d4")]).PartsMakerFullName;
                            primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERHALFNAME] = ((PMakerNmWork)_PartsMakerList[((Int32)wkPrimeSettingWork.PartsMakerCd).ToString("d4")]).PartsMakerHalfName;
                        }
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSFULLNAME] = "";
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSHALFNAME] = "";
                        //HashにBLコードがあれば名称取得
                        if (_TbsPartsCodeList[((Int32)wkPrimeSettingWork.TbsPartsCode).ToString("d8")] != null)
                        {
                            primeSettingRow[PrimeSettingInfo.COL_TBSPARTSFULLNAME] = ((TbsPartsCodeWork)_TbsPartsCodeList[((Int32)wkPrimeSettingWork.TbsPartsCode).ToString("d8")]).TbsPartsFullName;
                            primeSettingRow[PrimeSettingInfo.COL_TBSPARTSHALFNAME] = ((TbsPartsCodeWork)_TbsPartsCodeList[((Int32)wkPrimeSettingWork.TbsPartsCode).ToString("d8")]).TbsPartsHalfName;
                        }

                        primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRENAME] = "";
                        //Hashに中分類コードがあれば名称取得
                        //if (_MiddleGenreList[((Int32)wkPrimeSettingWork.MiddleGenreCode).ToString("d4")] != null)  // DEL 2008/07/01
                        if (_MiddleGenreList[((Int32)wkPrimeSettingWork.GoodsMGroup).ToString("d4")] != null)        // ADD 2008/07/01
                        {
                            //primedr[PrimeSettingInfo.COL_MIDDLEGENRENAME] = ((OfferMiddleGenreWork)_MiddleGenreList[((Int32)wkPrimeSettingWork.MiddleGenreCode).ToString("d4")]).MiddleGenreName;  // DEL 2008/07/01
                            primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRENAME] = ((GoodsMGroupWork)_MiddleGenreList[((Int32)wkPrimeSettingWork.GoodsMGroup).ToString("d4")]).GoodsMGroupName;             // ADD 2008/07/01
                        }

                        /* --- DEL 2008/07/01 -------------------------------->>>>>
                        primedr[PrimeSettingInfo.COL_SELECTNAME] = wkPrimeSettingWork.SelectName;
                        primedr[PrimeSettingInfo.COL_PRIMEKINDNAME] = wkPrimeSettingWork.PrimeKindName;
                           --- DEL 2008/07/01 --------------------------------<<<<< */
                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        primeSettingRow[PrimeSettingInfo.COL_SELECTNAME] = wkPrimeSettingWork.PrmSetDtlName1;
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME] = wkPrimeSettingWork.PrmSetDtlName2;
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();

                        keyGoodsMngList.blGoodsCode = wkPrimeSettingWork.TbsPartsCode;   // BLコード
                        keyGoodsMngList.goodsMakerCd = wkPrimeSettingWork.PartsMakerCd;  // 部品メーカーコード
                        keyGoodsMngList.goodsMGroup = wkPrimeSettingWork.GoodsMGroup;   // ADD 2009/01/26 仕様変更：商品管理情報に中分類コードを追加

                        // 商品管理情報リストにデータあり？
                        if (_GoodsMngList[keyGoodsMngList] != null)
                        {
                            // 商品管理情報取得
                            GoodsMngWork paraGoodsMngWork = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];

                            // TODO:仕入先コードあり？
                            if (paraGoodsMngWork.SupplierCd != 0)
                            {
                                // TODO:仕入先コードをPrimeSettingTableに設定
                                primeSettingRow[PrimeSettingInfo.COL_SUPPLIERCD] = paraGoodsMngWork.SupplierCd;

                                // 仕入先情報リストにデータあり？
                                if (_SupplierList[paraGoodsMngWork.SupplierCd] != null)
                                {
                                    // 仕入先情報取得
                                    Supplier supplier = (Supplier)_SupplierList[paraGoodsMngWork.SupplierCd];

                                    // 仕入先名称設定
                                    primeSettingRow[PrimeSettingInfo.COL_SUPPLIERNAME] = supplier.SupplierNm1;
                                }
                            }
                        }
                        else
                        {
                            primeSettingRow[PrimeSettingInfo.COL_SUPPLIERCD] = int.MinValue;    // UNDONE:拠点違いは対象としない
                        }
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
                        primeSettingRow[PrimeSettingInfo.COL_PRMSETGROUP] = wkPrimeSettingWork.PrmSetGroup;
                        if (!wkPrimeSettingWork.PrmSetGroup.Equals(0))
                        {
                            Debug.WriteLine("優良設定グループ：" + ((int)primeSettingRow[PrimeSettingInfo.COL_PRMSETGROUP]).ToString() + " <- " + wkPrimeSettingWork.PrmSetGroup.ToString());
                            Debug.WriteLine("中：" + wkPrimeSettingWork.GoodsMGroup.ToString() + ", M：" + wkPrimeSettingWork.PartsMakerCd.ToString() + ", B：" + wkPrimeSettingWork.TbsPartsCode.ToString());
                        }
                        // FIXME:2009/01/15 仕様変更 ※関連BLコード用コレクションの構築（たぶん必要ない）
                        //RelatedBLCode.Add(primeSettingRow);
                        // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<

                        //キーを作成
                        string str = ((Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO]).ToString("d2")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE]).ToString("d2");

                        //DataRowをHashTableに登録しておく
                        _PrimeSettingList.Add(str, primeSettingRow);

                        // Add 2009/01/14 仕様変更↓：中分類コードのくくりも表示
                        MakerList.Add(primeSettingRow);
                    }   // foreach (PrmSettingWork wkPrimeSettingWork in (ArrayList)objret)

                    // ADD 2009/01/26 機能追加：中分類+メーカー+BLコード=0のデータを登録 ---------->>>>>
                    #region <中分類+メーカー+0(BL)/>

                    foreach (PrmSettingWork offerPrimeSettingWork in (ArrayList)objret)
                    {
                        if (offerPrimeSettingWork.TbsPartsCode.Equals(0)) continue;

                        PrmSettingWork wkPrimeSettingWork = new PrmSettingWork();
                        {
                            wkPrimeSettingWork.GoodsMGroup = offerPrimeSettingWork.GoodsMGroup;     // 中分類コード
                            wkPrimeSettingWork.TbsPartsCode = 0;                                    // BLコード
                            wkPrimeSettingWork.TbsPartsCdDerivedNo = 0;                             // BLコード枝番
                            wkPrimeSettingWork.PartsMakerCd = offerPrimeSettingWork.PartsMakerCd;   // 部品メーカーコード
                            wkPrimeSettingWork.DisplayOrder = 0;                                    // 表示順位
                            wkPrimeSettingWork.PrmSetDtlNo1 = 0;                                    // 優良設定詳細コード1
                            wkPrimeSettingWork.PrmSetDtlName1 = string.Empty;                       // 優良設定詳細名称1
                            wkPrimeSettingWork.PrmSetDtlNo2 = 0;                                    // 優良設定詳細コード2
                            wkPrimeSettingWork.PrmSetDtlName2 = string.Empty;                       // 優良設定詳細名称2
                            // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------>>>>>
                            wkPrimeSettingWork.SecretCode = offerPrimeSettingWork.SecretCode;       // シークレット区分
                            // --- ADD 2009/02/19 障害ID:11684対応------------------------------------------------------<<<<<
                        }

                        DataRow primeSettingRow = PrimeSettingTable.NewRow();
                        PrimeSettingTable.Rows.Add(primeSettingRow);
                        // DataRowに取得したワークをセット
                        {   //【提供とユーザーを区別するカラム】
                            primeSettingRow[COL_OFFERPRIMESETTING] = wkPrimeSettingWork;
                            primeSettingRow[COL_USERPRIMESETTING] = null;
                            primeSettingRow[COL_CHANGEFLAG] = false;                // 提供は変更不可
                            primeSettingRow[COL_CHECKSTATE] = CheckState.Checked;   // TODO:提供は未チェック（デフォルト）？
                            primeSettingRow[COL_ORIGINAL_CHECKSTATE] = CheckState.Checked;   // TODO:提供は未チェック（デフォルト）？
                        }
                        // カラムにデータをセット
                        // デフォルト表示順位はメーカーコード順
                        primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER] = 0;

                        // 表示区分は０固定(提供の場合）
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 0;
                        primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] = wkPrimeSettingWork.DisplayOrder;
                        primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] = wkPrimeSettingWork.GoodsMGroup;
                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] = wkPrimeSettingWork.PartsMakerCd;
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] = wkPrimeSettingWork.TbsPartsCode;
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO] = wkPrimeSettingWork.TbsPartsCdDerivedNo;
                        primeSettingRow[PrimeSettingInfo.COL_SELECTCODE] = wkPrimeSettingWork.PrmSetDtlNo1;
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE] = wkPrimeSettingWork.PrmSetDtlNo2;
                        primeSettingRow[PrimeSettingInfo.COL_SECRETCODE] = wkPrimeSettingWork.SecretCode;
                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] = string.Empty;
                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERHALFNAME] = string.Empty;
                        // Hashにメーカーがあれば名称取得
                        if (_PartsMakerList[((Int32)wkPrimeSettingWork.PartsMakerCd).ToString("d4")] != null)
                        {
                            primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] = ((PMakerNmWork)_PartsMakerList[((Int32)wkPrimeSettingWork.PartsMakerCd).ToString("d4")]).PartsMakerFullName;
                            primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERHALFNAME] = ((PMakerNmWork)_PartsMakerList[((Int32)wkPrimeSettingWork.PartsMakerCd).ToString("d4")]).PartsMakerHalfName;
                        }
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSFULLNAME] = "";
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSHALFNAME] = "";
                        // HashにBLコードがあれば名称取得
                        if (_TbsPartsCodeList[((Int32)wkPrimeSettingWork.TbsPartsCode).ToString("d8")] != null)
                        {
                            primeSettingRow[PrimeSettingInfo.COL_TBSPARTSFULLNAME] = ((TbsPartsCodeWork)_TbsPartsCodeList[((Int32)wkPrimeSettingWork.TbsPartsCode).ToString("d8")]).TbsPartsFullName;
                            primeSettingRow[PrimeSettingInfo.COL_TBSPARTSHALFNAME] = ((TbsPartsCodeWork)_TbsPartsCodeList[((Int32)wkPrimeSettingWork.TbsPartsCode).ToString("d8")]).TbsPartsHalfName;
                        }

                        primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRENAME] = string.Empty;
                        // Hashに中分類コードがあれば名称取得
                        if (_MiddleGenreList[((Int32)wkPrimeSettingWork.GoodsMGroup).ToString("d4")] != null)
                        {
                            primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRENAME] = ((GoodsMGroupWork)_MiddleGenreList[((Int32)wkPrimeSettingWork.GoodsMGroup).ToString("d4")]).GoodsMGroupName;
                        }

                        primeSettingRow[PrimeSettingInfo.COL_SELECTNAME] = wkPrimeSettingWork.PrmSetDtlName1;
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME] = wkPrimeSettingWork.PrmSetDtlName2;

                        F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();

                        keyGoodsMngList.blGoodsCode = wkPrimeSettingWork.TbsPartsCode;   // BLコード
                        keyGoodsMngList.goodsMakerCd = wkPrimeSettingWork.PartsMakerCd;  // 部品メーカーコード
                        keyGoodsMngList.goodsMGroup = wkPrimeSettingWork.GoodsMGroup;   // ADD 2009/01/26 仕様変更：商品管理情報に中分類コードを追加

                        // 商品管理情報リストにデータあり？
                        if (_GoodsMngList[keyGoodsMngList] != null)
                        {
                            // 商品管理情報取得
                            GoodsMngWork paraGoodsMngWork = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];

                            // 仕入先コードあり？
                            if (paraGoodsMngWork.SupplierCd != 0)
                            {
                                // 仕入先コードをPrimeSettingTableに設定
                                primeSettingRow[PrimeSettingInfo.COL_SUPPLIERCD] = paraGoodsMngWork.SupplierCd;

                                // 仕入先情報リストにデータあり？
                                if (_SupplierList[paraGoodsMngWork.SupplierCd] != null)
                                {
                                    // 仕入先情報取得
                                    Supplier supplier = (Supplier)_SupplierList[paraGoodsMngWork.SupplierCd];

                                    // 仕入先名称設定
                                    primeSettingRow[PrimeSettingInfo.COL_SUPPLIERNAME] = supplier.SupplierNm1;
                                }
                            }
                        }
                        else
                        {
                            primeSettingRow[PrimeSettingInfo.COL_SUPPLIERCD] = int.MinValue;
                        }

                        // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
                        primeSettingRow[PrimeSettingInfo.COL_PRMSETGROUP] = wkPrimeSettingWork.PrmSetGroup;
                        // FIXME:2009/01/15 仕様変更 ※関連BLコード用コレクションの構築（たぶん必要ない）
                        //RelatedBLCode.Add(primeSettingRow);
                        // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<

                        //キーを作成
                        string str = ((Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO]).ToString("d2")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE]).ToString("d2");

                        // DataRowをHashTableに登録しておく
                        if (!_PrimeSettingList.ContainsKey(str))
                        {
                            _PrimeSettingList.Add(str, primeSettingRow);
                        }

                        // Add 2009/01/14 仕様変更↓：中分類コードのくくりも表示
                        MakerList.Add(primeSettingRow);
                    }   // foreach (PrmSettingWork offerPrimeSettingWork in (ArrayList)objret)

                    #endregion  // <中分類+メーカー+0(BL)/>
                    // ADD 2008/01/26 機能追加：中分類+メーカー+BLコード=0のデータを登録 ----------<<<<<
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                status = -1;
            }

            return status;
        }

        // ADD 2008/11/21 不具合対応[8176] 仕様変更 選択グリッド列の備考表示 ---------->>>>>
        /// <summary>
        /// 商品管理情報に該当するものがあるか判定します。
        /// </summary>
        /// <param name="goodsMGroup">中分類コード</param>
        /// <param name="goodsMakerCode">商品メーカーコード</param>
        /// <param name="blGoodsCode">BL商品コード</param>
        /// <returns>
        /// <c>true</c> :あり<br/>
        /// <c>false</c>:なし
        /// </returns>
        private bool ContainsGoodsMng(
            int goodsMGroup,
            int goodsMakerCode,
            int blGoodsCode
        )
        {
            F_KEY_GOODSMNGLIST keyGoodMngList = new F_KEY_GOODSMNGLIST();
            keyGoodMngList.goodsMGroup = goodsMGroup;   // ADD 2009/01/26 仕様変更：商品管理情報に中分類コードを追加
            keyGoodMngList.goodsMakerCd = goodsMakerCode;
            keyGoodMngList.blGoodsCode = blGoodsCode;
            return GoodsMng.Contains(keyGoodMngList);
        }

        /// <summary>
        /// 商品管理情報ハッシュテーブルからに該当する商品管理情報を取得します。
        /// </summary>
        /// <param name="goodsMGroup">中分類コード</param>
        /// <param name="goodsMakerCode">商品メーカーコード</param>
        /// <param name="blGoodsCode">BL商品コード</param>
        /// <returns>商品管理情報</returns>
        private GoodsMngWork GetGoodsMngWork(
            int goodsMGroup,
            int goodsMakerCode,
            int blGoodsCode
        )
        {
            F_KEY_GOODSMNGLIST keyGoodMngList = new F_KEY_GOODSMNGLIST();
            keyGoodMngList.goodsMGroup = goodsMGroup;   // ADD 2009/01/26 仕様変更：商品管理情報に中分類コードを追加
            keyGoodMngList.goodsMakerCd = goodsMakerCode;
            keyGoodMngList.blGoodsCode = blGoodsCode;
            return GoodsMng[keyGoodMngList] as GoodsMngWork;
        }
        // ADD 2008/11/21 不具合対応[8176] 仕様変更 選択グリッド列の備考表示 ----------<<<<<

        /// <summary>
        /// 優良設定備考リスト取得
        /// </summary>
        //private void getOfferPrimeSettingNoteList()  // DEL 2008/07/01
        private int getOfferPrimeSettingNoteList()     // ADD 2008/07/01
        {
            object objret = null;
            int status = -1;  // ADD 2008/07/01

            try
            {
                // 優良設定備考取得
                status = offerPrimeSettingSearchDB.SearchNote(out objret);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //foreach (OfferPrimeSettingNoteWork wkOfferPrimeSettingNote in (ArrayList)objret)
                    foreach (PrmSetNoteWork wkOfferPrimeSettingNote in (ArrayList)objret)
                    //BL部品コード結果クラス
                    {
                        //キーを作成
                        //string str = (wkOfferPrimeSettingNote.MiddleGenreCode.ToString("d4")  // DEL 2008/07/01
                        string str = (wkOfferPrimeSettingNote.GoodsMGroup.ToString("d4")        // ADD 2008/07/01
                                    + wkOfferPrimeSettingNote.TbsPartsCode.ToString("d8")
                                    + wkOfferPrimeSettingNote.PartsMakerCd.ToString("d4"));

                        //DataRowをHashTableに登録しておく
                        _PrimeSettingNoteList.Add(str, wkOfferPrimeSettingNote);
                    }
                }
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// テーブル作成
        /// </summary>
        private DataTable CreateTable(string TableName)
        {
            DataTable table = new DataTable(TableName);

            // TODO:各テーブルの構成
            if (TableName == PrimeSettingInfo.TABLENAME_PRIMESETTING)
            {
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERCD, typeof(int), "メーカーコード"));	//メーカーコード
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERFULLNAME, typeof(string), "メーカー"));	//全角メーカー名
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERHALFNAME, typeof(string), "ﾒｰｶｰ"));	//半角メーカー名
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSCODE, typeof(int), "BLｺｰﾄﾞ"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO, typeof(int), "BLコード枝番"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSFULLNAME, typeof(string), "品目名"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSHALFNAME, typeof(string), "品目名(半角)"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MIDDLEGENRECODE, typeof(int), "中分類"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MIDDLEGENRENAME, typeof(string), "中分類名"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SECRETCODE, typeof(int), "シークレットコード"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SELECTCODE, typeof(int), "セレクトコード"));
                //table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SELECTNAME, typeof(string), "セレクト名称"));     // DEL 2008/07/01
                // MOD 2008/10/30 不具合対応[6961]↓ 仕様変更 "詳細１"→"セレクト"
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SELECTNAME, typeof(string), "セレクト"));           // ADD 2008/07/01
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEKINDCODE, typeof(int), "優良種別コード"));
                //table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEKINDNAME, typeof(string), "優良種別名称"));  // DEL 2008/07/01
                // MOD 2008/10/30 不具合対応[6961]↓ 仕様変更 "詳細２"→"種別"
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEKINDNAME, typeof(string), "種別"));            // ADD 2008/07/01 
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERCD, typeof(int), "仕入先コード"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERCDDERIVEDNO, typeof(int), "仕入先コード枝番"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERNAME, typeof(string), "仕入先名称"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MAKERDISPORDER, typeof(int), "表示順位"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_DISPLAYORDER, typeof(int), "表示順"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEDISPLAYCODE, typeof(int), ""));	//表示区分

                table.Columns.Add(CreateColumn(COL_CHANGEFLAG, typeof(bool), ""));	//変更フラグ
                table.Columns.Add(CreateColumn(COL_CHECKSTATE, typeof(CheckState), ""));	//チェック
                table.Columns.Add(CreateColumn(COL_ORIGINAL_CHECKSTATE, typeof(CheckState), ""));	//チェック
                table.Columns.Add(CreateColumn(COL_OFFERPRIMESETTING, typeof(object), ""));	//提供優良設定クラス
                table.Columns.Add(CreateColumn(COL_USERPRIMESETTING, typeof(object), ""));	//ユーザー優良設定クラス

                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRMSETGROUP, typeof(int), "優良設定グループ")); // ADD 2009/01/15 仕様変更：関連BLコードの表示
            }
            else if (TableName == PrimeSettingInfo.TABLENAME_USER_PRIMESETTING)
            {
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERFULLNAME, typeof(string), "メーカー"));	//全角メーカー名
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSCODE, typeof(int), "BLｺｰﾄﾞ"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSFULLNAME, typeof(string), "品目名"));

                // --- DEL 2008/07/01 -------------------------------->>>>>
                //table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SELECTNAME, typeof(string), "セレクト名称"));
                //table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEKINDNAME, typeof(string), "優良種別名称"));
                // --- DEL 2008/07/01 --------------------------------<<<<< 

                // --- ADD 2008/07/01 -------------------------------->>>>>
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SELECTNAME, typeof(string), "詳細１"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEKINDNAME, typeof(string), "詳細２"));
                // --- ADD 2008/07/01 --------------------------------<<<<< 
            }
            else if (TableName == MG_BL_MK_TABLENAME)   // MEMO:中分類/BL/メーカーのカラム名
            {
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MIDDLEGENRECODE, typeof(int), "中分類コード"));	  //中分類コード
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MIDDLEGENRENAME, typeof(string), "中分類名"));	  //中分類名
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSCODE, typeof(int), "BLコード"));	      //BLコード

                // BL部品名
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSFULLNAME, typeof(string), "品目名"));   // MOD 2008/10/28 不具合対応[6967] "BL名"→"品目名"

                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERCD, typeof(int), "メーカーコード"));	  //メーカーコード
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERHALFNAME, typeof(string), "ﾒｰｶｰ"));	  //半角メーカー名
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERFULLNAME, typeof(string), "メーカー")); //全角メーカー名
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MAKERDISPORDER, typeof(int), "表示順"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SECRETCODE, typeof(int), "シークレットコード"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEDISPLAYCODE, typeof(int), ""));	          //表示区分
                table.Columns.Add(CreateColumn(COL_CHECKSTATE, typeof(CheckState), ""));	                          //チェックボックスステータス
                table.Columns.Add(CreateColumn(COL_ORIGINAL_CHECKSTATE, typeof(CheckState), ""));	                          //チェックボックスステータス
                table.Columns.Add(CreateColumn(COL_MG_BL_MKDATAROW, typeof(object), ""));	                          //ノード

                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_IMPORTANTCODE, typeof(int), ""));	//重要区分(-1は備考無し）

                // --- ADD 2008/07/01 -------------------------------->>>>>
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERGUIDE, typeof(Button), ""));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERCD, typeof(int), "仕入先コード"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERNAME, typeof(String), "仕入先"));
                // --- ADD 2008/07/01 --------------------------------<<<<<

                // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRMSETGROUP, typeof(int), "優良設定グループ"));
                table.Columns.Add(CreateColumn(COL_RELATEDBLCODE, typeof(string), "関連BLコード"));
                table.Columns.Add(CreateColumn(COL_GRIDSORTORDER, typeof(int), "グリッド用ソート順"));
                table.Columns.Add(CreateColumn(COL_USER_MAKERDISPORDER, typeof(int), "ユーザーが設定した表示順"));
                table.Columns.Add(CreateColumn(COL_USER_STATUS, typeof(int), "ユーザー登録分の状態"));
                // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<
            }

            return table;
        }
        
        /// <summary>
        /// データテーブルの列を作成する
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="type">型</param>
        /// <param name="caption">キャプション</param>
        /// <returns></returns>
        private DataColumn CreateColumn(string columnName, Type type, string caption)
        {
            DataColumn dc = new DataColumn();

            dc.ColumnName = columnName;
            dc.DataType = type;
            dc.Caption = caption;

            return dc;
        }
        
        // ADD 2008/10/29 不具合対応[6969] 仕様変更 ---------->>>>>
        /// <summary>
        /// 中分類/品目/メーカー順データテーブルを初期化します。
        /// </summary>
        private void InitializeMiddleGBLMakerDataTable()
        {
            Mg_Bl_MkTable.Clear();

            // 仕入先コードの一括設定用の共通レコードを追加
            DataRow commonDataRow = Mg_Bl_MkTable.NewRow();

            commonDataRow[PrimeSettingInfo.COL_MIDDLEGENRECODE]     = -1;                   // TODO:共通設定：中分類コード
            commonDataRow[PrimeSettingInfo.COL_MIDDLEGENRENAME]     = "共通";               // 中分類名
            commonDataRow[PrimeSettingInfo.COL_TBSPARTSCODE]        = 0;	                // BLコード
            commonDataRow[PrimeSettingInfo.COL_TBSPARTSFULLNAME]    = "共通";               // BL部品名
            commonDataRow[PrimeSettingInfo.COL_PARTSMAKERCD]        = COMMON_MAKER_CODE;    // TODO:共通設定：メーカーコード
            commonDataRow[PrimeSettingInfo.COL_PARTSMAKERHALFNAME]  = "共通";               // 半角メーカー名
            commonDataRow[PrimeSettingInfo.COL_PARTSMAKERFULLNAME]  = "共通";               // 全角メーカー名
            commonDataRow[PrimeSettingInfo.COL_MAKERDISPORDER]      = 0;                    // 表示順
            commonDataRow[PrimeSettingInfo.COL_SECRETCODE]          = 0;                    // シークレットコード
            commonDataRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]    = 0;                    // 表示区分
            commonDataRow[COL_CHECKSTATE] = CheckState.Checked;   // チェックボックスステータス
            commonDataRow[COL_ORIGINAL_CHECKSTATE] = CheckState.Checked;   // チェックボックスステータス
            commonDataRow[COL_MG_BL_MKDATAROW]                      = null;	                // ノード
            commonDataRow[PrimeSettingInfo.COL_IMPORTANTCODE]       = -1;	                // 重要区分(-1は備考無し）

            #region 仕入先は特に何も設定しない

            //commonDataRow[PrimeSettingInfo.COL_SUPPLIERGUIDE]       = null;                 // 仕入先コード
            //commonDataRow[PrimeSettingInfo.COL_SUPPLIERCD]          = 0;                    // 仕入先ガイドボタン
            //commonDataRow[PrimeSettingInfo.COL_SUPPLIERNAME]        = string.Empty;         // 仕入先名

            #endregion

            Mg_Bl_MkTable.Rows.Add(commonDataRow);
        }

        /// <summary>
        /// 中分類/品目/メーカー順データテーブルの一括設定用共通レコードであるか判定します。
        /// </summary>
        /// <param name="dataRowView">レコード</param>
        /// <returns>
        /// <c>true</c> :一括設定用共通レコードである。<br/>
        /// <c>false</c>:一括設定用共通レコードではない。
        /// </returns>
        public static bool IsCommonRowOfMiddleGBLMakerDataTable(DataRowView dataRowView)
        {
            return IsCommonRowOfMiddleGBLMakerDataTableByMakerCode((int)dataRowView[PrimeSettingInfo.COL_PARTSMAKERCD]);
        }

        /// <summary>
        /// 中分類/品目/メーカー順データテーブルの一括設定用共通レコードであるか判定します。
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>
        /// <c>true</c> :一括設定用共通レコードである。<br/>
        /// <c>false</c>:一括設定用共通レコードではない。
        /// </returns>
        public static bool IsCommonRowOfMiddleGBLMakerDataTableByMakerCode(int makerCode)
        {
            return makerCode.Equals(COMMON_MAKER_CODE);
        }
        // ADD 2008/10/29 不具合対応[6969] 仕様変更 ----------<<<<<

        /// <summary>
        /// 中分類/品目/メーカー順
        /// </summary>
        /// <param name="displaycode"></param>
        //private void getMG_BL_MKCdList()  // DEL 2008/07/01
        private int getMG_BL_MKCdList()     // ADD 2008/07/01
        {
            string rowfilter = PrimeSettingView.RowFilter;
            PrimeSettingView.RowFilter = "";
            string sort = PrimeSettingView.Sort;
            int wkMK = -1;
            int wkBL = -1;
            int prmSetDtlNo = -1;
            DataRow priorRow = null;
            CheckState cs = CheckState.Unchecked;
            Hashtable hashTable = new Hashtable();
            int status = 0;  // ADD 2008/07/01

            // TODO:中分類/BL/メーカー データテーブルを初期化
            InitializeMiddleGBLMakerDataTable();    // ADD 2008/10/29 不具合対応[6969] 仕様変更

            try
            {
                // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //PrimeSettingView.Sort = (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD);
                PrimeSettingView.Sort = (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_SECRETCODE + "," + PrimeSettingInfo.COL_PRIMEKINDCODE);
                // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                foreach (DataRowView primeSettingRow in PrimeSettingView)
                {
                    //if (wkBL == -1) { wkBL = (int)primedrv[PrimeSettingInfo.COL_TBSPARTSCODE]; }
                    //if (wkMK == -1) { wkMK = (int)primedrv[PrimeSettingInfo.COL_PARTSMAKERCD]; }

                    //BLコード（またはメーカーコード）が変わったらテーブルに追加
                    if ((wkBL != (int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]) || (wkMK != (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD]))
                    {
                        cs = CheckState.Unchecked; // 2009.05.25

                        if ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)    // 提供分のデフォルトは0
                        {
                            cs = CheckState.Checked;
                        }
                        //else
                        //{
                        //    primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 1;
                        //    primeSettingRow[COL_CHANGEFLAG] = true;
                        //}

                        // FIXME:BLコード=0のレコードがユーザー登録分にある場合、チェック（∵優良表示区分は0:非表示固定）
                        //if (((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]).Equals(0) && primeSettingRow[COL_USERPRIMESETTING] != DBNull.Value)
                        //{
                        //    cs = CheckState.Checked;
                        //}

                        // mgbldr[COL_PRIMEDISPLAYCODE] = displaycode;
                        DataRow mgbldr = _dataSet.Tables[MG_BL_MK_TABLENAME].NewRow();
                        mgbldr[COL_CHECKSTATE] = cs;
                        mgbldr[COL_ORIGINAL_CHECKSTATE] = cs;
                        _dataSet.Tables[MG_BL_MK_TABLENAME].Rows.Add(setMG_BL_MKrow(primeSettingRow, mgbldr));

                        wkBL = (int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE];
                        wkMK = (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];
                        prmSetDtlNo = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE];

                        //キーを作成
                        string str = ((Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_SECRETCODE]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE]).ToString("d4")
                                    ;
                        _Mg_Bl_Mk_List.Add(str, mgbldr);
                        // if ((int)primedrv[COL_PARTSMAKERCD] == 1002) MessageBox.Show("");

                        // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        ////チェック状態をリセット
                        //cs = CheckState.Unchecked;
                        // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        //覚えておく
                        priorRow = mgbldr;
                    }
                    else
                    {
                        if (prmSetDtlNo != (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE])
                        {
                            if ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)    // 提供分のデフォルトは0
                            {
                                cs = CheckState.Checked;
                            }
                            //else
                            //{
                            //    primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 1;
                            //    primeSettingRow[COL_CHANGEFLAG] = true;
                            //}

                            DataRow mgbldr = _dataSet.Tables[MG_BL_MK_TABLENAME].NewRow();
                            mgbldr[COL_CHECKSTATE] = cs;
                            mgbldr[COL_ORIGINAL_CHECKSTATE] = cs;
                            _dataSet.Tables[MG_BL_MK_TABLENAME].Rows.Add(setMG_BL_MKrow(primeSettingRow, mgbldr));

                            wkBL = (int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE];
                            wkMK = (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];
                            prmSetDtlNo = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE];
                            //キーを作成
                            string str = ((Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_SECRETCODE]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE]).ToString("d4")
                                    ;

                            if (!_Mg_Bl_Mk_List.ContainsKey(str))
                            {
                                _Mg_Bl_Mk_List.Add(str, mgbldr);
                                // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                ////チェック状態をリセット
                                //cs = CheckState.Unchecked;
                                // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                //覚えておく
                                priorRow = mgbldr;
                            }
                        }
                        else
                        {
                            if ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)
                            {
                                //覚えておいたRowに更新
                                priorRow[COL_CHECKSTATE] = CheckState.Checked;
                                priorRow[COL_ORIGINAL_CHECKSTATE] = CheckState.Checked;
                                priorRow[PrimeSettingInfo.COL_SECRETCODE] = 0;
                                // 2010/03/02 Add >>>
                                priorRow[PrimeSettingInfo.COL_MAKERDISPORDER] = (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER];
                                priorRow[COL_USER_MAKERDISPORDER] = (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER];
                                // 2010/03/02 Add <<<
                            }
                        }
                    }

                    if (wkBL == -1) { wkBL = (int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]; }
                    if (wkMK == -1) { wkMK = (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD]; }
                    if (prmSetDtlNo == -1) { prmSetDtlNo = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE]; }
                }
                PrimeSettingView.RowFilter = rowfilter;
                PrimeSettingView.Sort = sort;

                this._originalPrimeSettingTable = PrimeSettingTable.Copy();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                status = -1;
            }

            return status;
        }

        public void Copy()
        {
            foreach (DataRowView primeSettingRow in PrimeSettingView)
            {
                primeSettingRow[COL_ORIGINAL_CHECKSTATE] = primeSettingRow[COL_CHECKSTATE];
            }
        }

        /// <summary>
        /// 指定の行にデータをセット
        /// </summary>
        /// <returns>セット後のデータ行</returns>
        private DataRow setMG_BL_MKrow(DataRowView sourcedr, DataRow dr)
        {
            if (IsCommonRowOfMiddleGBLMakerDataTable(sourcedr)) Debug.Assert(false, "共通設定レコードを初期化処理以外で追加");

            dr[PrimeSettingInfo.COL_MIDDLEGENRECODE] = sourcedr[PrimeSettingInfo.COL_MIDDLEGENRECODE];//key
            dr[PrimeSettingInfo.COL_TBSPARTSCODE] = sourcedr[PrimeSettingInfo.COL_TBSPARTSCODE];//key
            dr[PrimeSettingInfo.COL_PARTSMAKERCD] = sourcedr[PrimeSettingInfo.COL_PARTSMAKERCD];//key
            dr[PrimeSettingInfo.COL_MIDDLEGENRENAME] = sourcedr[PrimeSettingInfo.COL_MIDDLEGENRENAME];
            dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME] = sourcedr[PrimeSettingInfo.COL_TBSPARTSFULLNAME];
            dr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] = sourcedr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME];
            dr[PrimeSettingInfo.COL_PARTSMAKERHALFNAME] = sourcedr[PrimeSettingInfo.COL_PARTSMAKERHALFNAME];
            //データのシークレット区分をセット
            dr[PrimeSettingInfo.COL_SECRETCODE] = sourcedr[PrimeSettingInfo.COL_SECRETCODE];
            //チェックＯＮのデータはシークレットを外す
            if (dr[COL_CHECKSTATE] == (object)CheckState.Checked)
                dr[PrimeSettingInfo.COL_SECRETCODE] = 0;

            dr[PrimeSettingInfo.COL_MAKERDISPORDER] = sourcedr[PrimeSettingInfo.COL_MAKERDISPORDER];
            dr[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = sourcedr[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
            //dr[COL_TREENODE] = null;
            dr[COL_MG_BL_MKDATAROW] = (object)dr;
            dr[PrimeSettingInfo.COL_IMPORTANTCODE] = -1;

            // --- ADD 2008/07/01 -------------------------------->>>>>
            F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();

            keyGoodsMngList.blGoodsCode = (int)sourcedr[PrimeSettingInfo.COL_TBSPARTSCODE];   // BLコード
            keyGoodsMngList.goodsMakerCd = (int)sourcedr[PrimeSettingInfo.COL_PARTSMAKERCD];  // 部品メーカーコード
            keyGoodsMngList.goodsMGroup = (int)sourcedr[PrimeSettingInfo.COL_MIDDLEGENRECODE];// ADD 2009/01/26 仕様変更：商品管理情報に中分類コードを追加

            // 商品管理情報リストにデータあり？
            if (_GoodsMngList[keyGoodsMngList] != null)
            {
                // 商品管理情報取得
                GoodsMngWork paraGoodsMngWork = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];

                // TODO:仕入先コードあり？
                if (paraGoodsMngWork.SupplierCd != 0)
                {
                    // 仕入先コード設定
                    dr[PrimeSettingInfo.COL_SUPPLIERCD] = paraGoodsMngWork.SupplierCd;

                    // 仕入先情報リストにデータあり？
                    if (_SupplierList[paraGoodsMngWork.SupplierCd] != null)
                    {
                        // 仕入先情報取得
                        Supplier supplier = (Supplier)_SupplierList[paraGoodsMngWork.SupplierCd];

                        // 仕入先名称設定
                        dr[PrimeSettingInfo.COL_SUPPLIERNAME] = supplier.SupplierNm1;
                    }
                }
             }
             // --- ADD 2008/07/01 --------------------------------<<<<< 

            // ADD 2009/01/14 仕様変更：中分類のくくりも表示する ---------->>>>>
            // 仕入先コードのデフォルト設定
            int supplierCode = 0;
            try
            {
                supplierCode = (int)dr[PrimeSettingInfo.COL_SUPPLIERCD];
            }
            catch (InvalidCastException)  // DBNullの場合
            {
                supplierCode = 0;
            }
            if (supplierCode.Equals(0))
            {
                // 中分類+メーカーで仕入先コードが1つの場合、それをデフォルト値とする
                CodeNamePair<int> supplierPair = MakerList.FindSupplierCodeName(
                    (int)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE],  // 中分類コード
                    (int)dr[PrimeSettingInfo.COL_PARTSMAKERCD]      // メーカーコード
                );
                if (supplierPair.Code > 0)
                {
                    dr[PrimeSettingInfo.COL_SUPPLIERCD]     = supplierPair.Code;
                    dr[PrimeSettingInfo.COL_SUPPLIERNAME]   = supplierPair.Name;
                }
            }
            // ADD 2009/01/14 仕様変更：中分類のくくりも表示する ----------<<<<<
            // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
            // 優良設定グループ
            dr[PrimeSettingInfo.COL_PRMSETGROUP] = sourcedr[PrimeSettingInfo.COL_PRMSETGROUP];

            // 関連BLコード
            int blCode = (int)sourcedr[PrimeSettingInfo.COL_TBSPARTSCODE];
            dr[COL_RELATEDBLCODE] = GetRelatedBLCodeName(blCode);

            // グリッド用ソート順
            dr[COL_GRIDSORTORDER] = int.MaxValue;

            // ユーザー登録分の表示順
            dr[COL_USER_MAKERDISPORDER] = (int)sourcedr[PrimeSettingInfo.COL_MAKERDISPORDER];
            // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<

            // ユーザー登録分の状態
            dr[COL_USER_STATUS] = (int)UserStatus.None;

            return dr;
        }

        # endregion

        # region Const

        private const string SECRETFILTER = "SecretCode=0";
        public const string MG_BL_MK_TABLENAME = "Mg_Bl_Mk_Table";
        //public const string PRIMESETTING_TABLENAME = "PrimeSetting_Table";
        //public const string OFFER_PRIMESETTING_TABLENAME = "Offer_PrimeSetting_Table";
        //public const string USER_PRIMESETTING_TABLENAME = "User_PrimeSetting_Table";

        # region Const：共通ヘッダ
        /// <summary>作成日時</summary>
        public const string COL_FILEHEADER_CREATEDATETIME = "CreateDateTime";
        /// <summary>更新日時</summary>
        public const string COL_FILEHEADER_UPDATEDATETIME = "UpdateDateTime";
        /// <summary>企業コード</summary>
        public const string COL_FILEHEADER_ENTERPRISECODE = "EnterpriseCode";
        /// <summary>GUID</summary>
        public const string COL_FILEHEADER_FILEHEADERGUID = "FileHeaderGuid";
        /// <summary>更新従業員コード</summary>
        public const string COL_FILEHEADER_UPDEMPLOYEECODE = "UpdEmployeeCode";
        /// <summary>更新アセンブリID1</summary>
        public const string COL_FILEHEADER_UPDASSEMBLYID1 = "UpdAssemblyId1";
        /// <summary>更新アセンブリID2</summary>
        public const string COL_FILEHEADER_UPDASSEMBLYID2 = "UpdAssemblyId2";
        /// <summary>論理削除区分</summary>
        public const string COL_FILEHEADER_LOGICALDELETECODE = "LogicalDeleteCode";
        # endregion

        /// <summary>チェックボックスステータス </summary>
        public const string COL_CHECKSTATE = "CheckState";
        /// <summary>変更フラグ </summary>
        public const string COL_CHANGEFLAG = "ChangeFlag";
        /// <summary>チェックボックスステータス </summary>
        public const string COL_ORIGINAL_CHECKSTATE = "Original_CheckState";

        /// <summary>提供優良設定クラス </summary>
        public const string COL_OFFERPRIMESETTING = "OfferPrimeSetting";
        /// <summary>ﾕｰｻﾞｰ優良設定クラス </summary>
        public const string COL_USERPRIMESETTING = "UserPrimeSetting";
        /// <summary>中分類/品目/メーカーリスト </summary>
        public const string COL_MG_BL_MKDATAROW = "Mg_Bl_Mk_DataRow";
        // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
        /// <summary>関連BLコード</summary>
        public const string COL_RELATEDBLCODE = "RelatedBLCode";
        /// <summary>グリッド用ソート順</summary>
        public const string COL_GRIDSORTORDER = "GridSortOrder";
        /// <summary>ユーザーが設定した表示順</summary>
        public const string COL_USER_MAKERDISPORDER = "UserMakerDispOrder";
        /// <summary>ユーザー登録分の状態</summary>
        public const string COL_USER_STATUS = "UserStatus";
        // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<

        #region 削除コード
        /*
        /// <summary>中分類コード </summary>
        public const string COL_MIDDLEGENRECODE = "MiddleGenreCode";
        /// <summary>メーカーコード </summary>
        public const string COL_PARTSMAKERCD = "PartsMakerCd";
        /// <summary>BLコード </summary>
        public const string COL_TBSPARTSCODE = "TbsPartsCode";
        /// <summary>BLコード枝番</summary>
        public const string COL_TBSPARTSCDDERIVEDNO = "TbsPartsCdDerivedNo";

        /// <summary>中分類名称 </summary>
        public const string COL_MIDDLEGENRENAME = "MiddleGenreName";
        /// <summary>メーカー名称(全角) </summary>
        public const string COL_PARTSMAKERFULLNAME = "PartsMakerFullName";
        /// <summary>メーカー名称(半角) </summary>
        public const string COL_PARTSMAKERHALFNAME = "PartsMakerHalfName";
        /// <summary>BL部品名称 </summary>
        public const string COL_TBSPARTSFULLNAME = "TbsPartsFullName";
        /// <summary>BL部品名称(半角)</summary>
        public const string COL_TBSPARTSHALFNAME = "TbsPartsHalfName";
		/// <summary>シークレット区分</summary>
		/// <remarks>0:通常　1:シークレット</remarks>
		public const string COL_SECRETCODE =  "SecretCode";
		/// <summary>表示順位</summary>
		public const string COL_DISPLAYORDER =  "DisplayOrder";
		/// <summary>メーカー表示順位</summary>
        public const string COL_MAKERDISPORDER = "MakerDisplayOrder";
		/// <summary>セレクトコード</summary>
		public const string COL_SELECTCODE =  "SelectCode";
		/// <summary>セレクト名称</summary>
		public const string COL_SELECTNAME =  "SelectName";
		/// <summary>優良種別コード</summary>
		public const string COL_PRIMEKINDCODE =  "PrimeKindCode";
		/// <summary>優良種別名称</summary>
		public const string COL_PRIMEKINDNAME =  "PrimeKindName";
        /// <summary>仕入先コード</summary>
        public const string COL_SUPPLIERCD = "SupplierCd";
        /// <summary>仕入先コード</summary>
        public const string COL_SUPPLIERNAME = "SupplierName";
        /// <summary>仕入先コード枝番</summary>
        public const string COL_SUPPLIERCDDERIVEDNO = "SupplierCdDerivedNo";
        /// <summary>表示区分</summary>
        /// <remarks>0:無し　1:商品&結合　2:商品</remarks>
        public const string COL_PRIMEDISPLAYCODE = "PrimeDisplayCode";
        /// <summary>ツリーノード </summary>
      　//  public const string COL_TREENODE = "TreeNode";
        /// <summary>チェックボックスステータス </summary>
        public const string COL_CHECKSTATE = "CheckState";
        /// <summary>提供優良設定クラス </summary>
        public const string COL_OFFERPRIMESETTING = "OfferPrimeSetting";
        /// <summary>ﾕｰｻﾞｰ優良設定クラス </summary>
        public const string COL_USERPRIMESETTING = "UserPrimeSetting";
        /// <summary>中分類/品目/メーカーリスト </summary>
        public const string COL_MG_BL_MKDATAROW = "Mg_Bl_Mk_DataRow";
        /// <summary>変更フラグ </summary>
        public const string COL_CHANGEFLAG = "ChangeFlag";

        /// <summary>重要区分 </summary>
        public const string COL_IMPORTANTCODE = "ImportantCode";
        /// <summary>優良設定備考 </summary>
        public const string COL_PRIMESETTINGNOTE = "PrimeSettingNote";
        */
        #endregion  // 削除コード

        /// <summary>共通設定となるメーカーコード</summary>
        public const int COMMON_MAKER_CODE = 0; // ADD 2008/10/29 不具合対応[6969] 仕様変更

        /// <summary>
        /// ユーザー登録分の状態の列挙体
        /// </summary>
        public enum UserStatus : int
        {
            /// <summary>なし</summary>
            None,
            /// <summary>表示対象</summary>
            ViewingRecord,
            /// <summary>削除対象</summary>
            DeletingRecord
        }

        # endregion

        // ADD 2008/12/05 不具合対応[8524] 仕様変更 表示順が設定されていない場合、1～自動で採番 ---------->>>>>
        #region デフォルト表示順

        /// <summary>
        /// デフォルト表示順の管理者クラス
        /// </summary>
        private sealed class DefaultMakerDispOrderManagaer
        {
            #region <優良設定DataRow/>

            /// <summary>優良設定DataRowのマップ</summary>
            private readonly IDictionary<string, IList<DataRow>> _primeSettingDataRowMap = new Dictionary<string, IList<DataRow>>();
            /// <summary>
            /// 優良設定DataRowのマップを取得します。
            /// </summary>
            /// <value>優良設定DataRowのマップ</value>
            private IDictionary<string, IList<DataRow>> PrimeSettingDataRowMap { get { return _primeSettingDataRowMap; } }

            #endregion  // <<優良設定DataRow/>

            #region <予約済み表示順/>

            /// <summary>予約済み表示順のマップ</summary>
            private readonly IDictionary<string, IList<int>> _reservedMakerDispOrderMap = new Dictionary<string, IList<int>>();
            /// <summary>
            /// 予約済み表示順のマップを取得します。
            /// </summary>
            /// <value>予約済み表示順のマップ</value>
            private IDictionary<string, IList<int>> ReservedMakerDispOrderMap { get { return _reservedMakerDispOrderMap; } } 

            #endregion  // <予約済み表示順/>

            #region <Constructor/>

            /// <summary>
            /// デフォルトコンストラクタ
            /// </summary>
            public DefaultMakerDispOrderManagaer() { }

            #endregion  // <Constructor/>

            /// <summary>
            /// 予約済み表示順を設定します。
            /// </summary>
            /// <param name="goodsMGroup">中分類コード</param>
            /// <param name="tbsPartsCode">BLコード</param>
            /// <param name="makerDispOrder">予約する表示順番号</param>
            public void Reserve(
                int goodsMGroup,
                int tbsPartsCode,
                int makerDispOrder
            )
            {
                string key = GetKey(goodsMGroup, tbsPartsCode);
                if (!ReservedMakerDispOrderMap.ContainsKey(key))
                {
                    ReservedMakerDispOrderMap.Add(key, new List<int>());
                }
                ReservedMakerDispOrderMap[key].Add(makerDispOrder);
            }

            /// <summary>
            /// 管理する優良設定DataRowを追加します。
            /// </summary>
            /// <param name="goodsMGroup">中分類コード</param>
            /// <param name="tbsPartsCode">BLコード</param>
            /// <param name="primeSettingDataRow">管理する優良設定DataRow</param>
            public void Add(
                int goodsMGroup,
                int tbsPartsCode,
                DataRow primeSettingDataRow
            )
            {
                string key = GetKey(goodsMGroup, tbsPartsCode);
                if (!PrimeSettingDataRowMap.ContainsKey(key))
                {
                    PrimeSettingDataRowMap.Add(key, new List<DataRow>());
                }
                PrimeSettingDataRowMap[key].Add(primeSettingDataRow);
            }

            /// <summary>
            /// デフォルトの表示順を設定します。
            /// </summary>
            public void SetDefaultMakerDispOrder()
            {
                if (PrimeSettingDataRowMap.Count.Equals(0)) return;

                foreach (string key in PrimeSettingDataRowMap.Keys)
                {
                    int makerDispOrder = 1; // デフォルト表示順は1～連番
                    foreach (DataRow settingDataRow in PrimeSettingDataRowMap[key])
                    {
                        makerDispOrder = GetDefaultMakerDispOrder(key, makerDispOrder);
                        
                        settingDataRow[PrimeSettingInfo.COL_MAKERDISPORDER] = makerDispOrder;
                        settingDataRow[COL_CHANGEFLAG] = true;  // 保存時にDB展開されるように変更フラグをON

                        makerDispOrder++;
                    }
                }
            }

            /// <summary>
            /// デフォルト表示順番号を取得します。
            /// </summary>
            /// <param name="reservedMapKey">予約済み表示順番号マップのキー</param>
            /// <param name="makerDispOrderSeed">表示順を演算するシード</param>
            /// <returns>デフォルト表示順番号</returns>
            private int GetDefaultMakerDispOrder(
                string reservedMapKey,
                int makerDispOrderSeed
            )
            {
                if (!Reserved(reservedMapKey, makerDispOrderSeed))
                {
                    return makerDispOrderSeed;
                }
                else
                {
                    return GetDefaultMakerDispOrder(reservedMapKey, makerDispOrderSeed + 1);
                }
            }

            /// <summary>
            /// 予約済み表示順番号か判定します。
            /// </summary>
            /// <param name="key">マップのキー</param>
            /// <param name="makerDispOrder">表示順</param>
            /// <returns>
            /// <c>true</c> :予約済みである。
            /// <c>false</c>:予約済みではない。
            /// </returns>
            private bool Reserved(
                string key,
                int makerDispOrder
            )
            {
                if (!ReservedMakerDispOrderMap.ContainsKey(key)) return false;
                return ReservedMakerDispOrderMap[key].IndexOf(makerDispOrder) >= 0;
            }

            /// <summary>
            /// マップのキーを取得します。
            /// </summary>
            /// <param name="goodsMGroup">中分類コード</param>
            /// <param name="tbsPartsCode">BLコード</param>
            /// <returns>中分類コード("0000") + BLコード("0000")</returns>
            private static string GetKey(
                int goodsMGroup,
                int tbsPartsCode
            )
            {
                return goodsMGroup.ToString("0000") + tbsPartsCode.ToString("0000");
            }
        }

        #endregion  // デフォルト表示順
        // ADD 2008/12/05 不具合対応[8524] 仕様変更 表示順が設定されていない場合、1～自動で採番 ----------<<<<<

        // ADD 2009/01/14 仕様変更：中分類のくくりも表示する ---------->>>>>
        #region <メーカーリスト/>

        /// <summary>
        /// メーカーの集合体クラス
        /// </summary>
        private sealed class MakerAgreegate
        {
            #region <メーカーのコレクション/>

            /// <summary>中分類コードでグループ化したメーカーのマップ</summary>
            private readonly IDictionary<int, IDictionary<int, string>> _makerListMap = new Dictionary<int, IDictionary<int, string>>();
            /// <summary>
            /// 中分類コードでグループ化したメーカーのマップを取得します。
            /// </summary>
            /// <value>中分類コードでグループ化したメーカーのマップ</value>
            private IDictionary<int, IDictionary<int, string>> MakerListMap { get { return _makerListMap; } }

            /// <summary>中分類コード+メーカーコードでグループ化したマップ</summary>
            private readonly IDictionary<string, IDictionary<int, string>> _middleMakerMap = new Dictionary<string, IDictionary<int, string>>();
            /// <summary>
            /// 中分類コード+メーカーコードでグループ化したマップを取得します。
            /// </summary>
            /// <value>中分類コード+メーカーコードでグループ化したマップ</value>
            private IDictionary<string, IDictionary<int, string>> MiddleMakerMap { get { return _middleMakerMap; } }

            #endregion  // <メーカーのコレクション/>

            #region <Constructor/>

            /// <summary>
            /// デフォルトコンストラクタ
            /// </summary>
            public MakerAgreegate() { }

            #endregion  // <Constructor/>

            /// <summary>
            /// メーカーを追加します。
            /// </summary>
            /// <param name="primeSettingRow">優良設定テーブルのレコード</param>
            public void Add(DataRow primeSettingRow)
            {
                int middleGenreCode = (int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                int makerCode       = (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];

                // 中分類コードでグループ化
                if (!MakerListMap.ContainsKey(middleGenreCode))
                {
                    MakerListMap.Add(middleGenreCode, new Dictionary<int, string>());
                }
                IDictionary<int, string> makerMap = MakerListMap[middleGenreCode];
                if (!makerMap.ContainsKey(makerCode))
                {
                    makerMap.Add(makerCode, (string)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERFULLNAME]);
                }

                // 中分類コード+メーカーコードで管理
                string middleGenreCodeKey = ConvertMiddleGenreCodeToKey(middleGenreCode);
                string key = middleGenreCodeKey + ConvertPartsMakerCdToKey(makerCode);
                {
                    if (!MiddleMakerMap.ContainsKey(key))
                    {
                        MiddleMakerMap.Add(key, new Dictionary<int, string>());
                    }
                    IDictionary<int, string> supplierMap = MiddleMakerMap[key];

                    // 仕入先を管理
                    int supplierCode = 0;
                    string supplierName = string.Empty;
                    try
                    {
                        supplierCode = (int)primeSettingRow[PrimeSettingInfo.COL_SUPPLIERCD];
                        supplierName = (string)primeSettingRow[PrimeSettingInfo.COL_SUPPLIERNAME];
                    }
                    catch (InvalidCastException)    // DBNullの場合
                    {
                        supplierCode = 0;
                        supplierName = string.Empty;
                    }
                    if (!supplierMap.ContainsKey(supplierCode))
                    {
                        supplierMap.Add(supplierCode, supplierName);
                    }
                }
            }

            /// <summary>
            /// 仕入先コードと名称を取得します
            /// </summary>
            /// <param name="middleGenreCode">中分類コード</param>
            /// <param name="makerCode">メーカーコード</param>
            /// <returns>
            /// 指定された中分類コード+メーカーコードに関連する仕入先コードが全て同一であれば、
            /// その仕入先コードと名称を返します。
            /// （それ以外は空の仕入先を返します）
            /// </returns>
            public CodeNamePair<int> FindSupplierCodeName(
                int middleGenreCode,
                int makerCode
            )
            {
                CodeNamePair<int> emptySupplier = new CodeNamePair<int>(0, string.Empty);
                {
                    string middleGenreCodeKey   = ConvertMiddleGenreCodeToKey(middleGenreCode);
                    string makerCodeKey         = ConvertPartsMakerCdToKey(makerCode);
                    string key = middleGenreCodeKey + makerCodeKey;
                    if (MiddleMakerMap.ContainsKey(key))
                    {
                        IDictionary<int, string> supplierMap = MiddleMakerMap[key];
                        // 中分類とメーカーのまとまりで仕入先コードが1件の場合
                        if (supplierMap.Count.Equals(1))
                        {
                            foreach (int supplierCode in supplierMap.Keys)
                            {
                                return new CodeNamePair<int>(supplierCode, supplierMap[supplierCode]);
                            }
                        }
                    }
                }
                return emptySupplier;
            }

            /// <summary>
            /// 指定したメーカーコードが指定した中分類コードに関連付くか判定します。
            /// </summary>
            /// <param name="middleGenreCode">中分類コード</param>
            /// <param name="makerCode">メーカーコード</param>
            /// <returns></returns>
            public bool ContainsMakerCode(
                int middleGenreCode,
                int makerCode
            )
            {
                if (!MakerListMap.ContainsKey(middleGenreCode)) return false;

                return MakerListMap[middleGenreCode].ContainsKey(makerCode);
            }

            /// <summary>
            /// 中分類コードに関連付くメーカーコードを検索します。
            /// </summary>
            /// <param name="middleGenreCode">中分類コード</param>
            /// <returns>中分類コードに関連付くメーカーコード</returns>
            public IList<int> FindMakerCode(int middleGenreCode)
            {
                IList<int> foundMakerCodeList = new List<int>();
                {
                    if (MakerListMap.ContainsKey(middleGenreCode))
                    {
                        IDictionary<int, string> makerMap = MakerListMap[middleGenreCode];
                        foreach (int makerCode in makerMap.Keys)
                        {
                            foundMakerCodeList.Add(makerCode);
                        }
                    }
                }
                return foundMakerCodeList;
            }

            #region <マップのキー/>

            /// <summary>
            /// 中分類コードをキーに変換します。
            /// </summary>
            /// <param name="middleGenreCode">中分類コード</param>
            /// <returns>キー：中分類コード（"0000"）</returns>
            private static string ConvertMiddleGenreCodeToKey(int middleGenreCode)
            {
                return middleGenreCode.ToString("0000");
            }

            /// <summary>
            /// BLコードをキーに変換します。
            /// </summary>
            /// <param name="tbsPartsCode">BLコード</param>
            /// <returns>キー：BLコード（"0000"）</returns>
            private static string ConvertTbsPartsCodeToKey(int tbsPartsCode)
            {
                return tbsPartsCode.ToString("0000");
            }

            /// <summary>
            /// メーカーコードをキーに変換します。
            /// </summary>
            /// <param name="partsMakerCd">メーカーコード</param>
            /// <returns>キー：メーカーコード（"0000"）</returns>
            private static string ConvertPartsMakerCdToKey(int partsMakerCd)
            {
                return partsMakerCd.ToString("0000");
            }

            #endregion  // <マップのキー/>
        }

        #endregion  // <メーカーリスト/>
        // ADD 2009/01/14 仕様変更：中分類のくくりも表示する ----------<<<<<

        // ADD 2009/01/15 仕様変更：関連BLコードの表示 ---------->>>>>
        #region <関連BLコード/>

        /// <summary>
        /// 優良設定グループ=0が有効か判定します。
        /// </summary>
        /// <value><c>false</c>：無効</value>
        public static bool ExistsGroup0
        {
            get
            {
#if _EXISTS_GROUP0_
                return true;
#else
                return false;
#endif
            }
        }

        /// <summary>
        /// 関連BLコードの集合体クラス
        /// </summary>
        private sealed class RelatedBLCodeAgreegate
        {
            #region <優良設定グループのマップ/>

            /// <summary>優良設定グループのマップ</summary>
            /// <remarks>
            /// キー：優良設定グループ
            /// 値：優良設定レコードのリスト
            /// </remarks>
            private readonly IDictionary<int, IList<DataRow>> _groupedPrimeSettingMap = new Dictionary<int, IList<DataRow>>();
            /// <summary>
            /// 優良設定グループのマップを取得します。
            /// </summary>
            /// <remarks>
            /// キー：優良設定グループ
            /// 値：優良設定レコードのリスト
            /// </remarks>
            /// <value>優良設定グループのマップ</value>
            private IDictionary<int, IList<DataRow>> GroupedPrimeSettingMap { get { return _groupedPrimeSettingMap; } }

            #endregion  // <優良設定グループのマップ/>

            #region <Constructor/>

            /// <summary>
            /// デフォルトコンストラクタ
            /// </summary>
            public RelatedBLCodeAgreegate() { }

            #endregion  // <Constructor/>

            /// <summary>
            /// 関連BLコードを追加します。
            /// </summary>
            /// <param name="primeSettingRow">優良設定テーブルのレコード</param>
            public void Add(DataRow primeSettingRow)
            {
                int prmSetGroup = (int)primeSettingRow[PrimeSettingInfo.COL_PRMSETGROUP];

#if _EXISTS_GROUP0_
#else
                if (prmSetGroup.Equals(0)) return;
#endif

                if (!GroupedPrimeSettingMap.ContainsKey(prmSetGroup))
                {
                    GroupedPrimeSettingMap.Add(prmSetGroup, new List<DataRow>());
                }
                GroupedPrimeSettingMap[prmSetGroup].Add(primeSettingRow);
            }
        }

        #endregion  // <関連BLコード/>
        // ADD 2009/01/15 仕様変更：関連BLコードの表示 ----------<<<<<

        // ADD 2009/01/21 不具合対応[6970] ---------->>>>>
        #region <優良設定マスタ（ユーザー登録分）のヘルパクラス/>

        /// <summary>
        /// 優良設定マスタ（ユーザー登録分）の集合体クラス
        /// </summary>
        private sealed class UserPrimeSettingAgreegate
        {
            #region <優良設定マスタ（ユーザー登録分）のコレクション/>

            /// <summary>優良設定マスタ（ユーザー登録分）レコードのマップ</summary>
            private readonly IDictionary<string, PrmSettingUWork> _userPrimeSettingRecordMap = new Dictionary<string, PrmSettingUWork>();
            /// <summary>
            /// 優良設定マスタ(ユーザー登録分）レコードのマップを取得します。
            /// </summary>
            /// <value>優良設定マスタ（ユーザー登録分）レコードのマップ</value>
            private IDictionary<string, PrmSettingUWork> UserPrimeSettingRecordMap { get { return _userPrimeSettingRecordMap; } }

            #endregion  // <優良設定マスタ（ユーザー登録分）のコレクション/>

            #region <Constrcutor/>

            /// <summary>
            /// デフォルトコンストラクタ
            /// </summary>
            public UserPrimeSettingAgreegate() { }

            #endregion  // <Constructor/>

            /// <summary>
            /// コレクションをクリアします。
            /// </summary>
            public void Clear()
            {
                UserPrimeSettingRecordMap.Clear();
            }

            /// <summary>
            /// 優良設定マスタ（ユーザー登録分）レコードを追加します。
            /// </summary>
            /// <param name="prmSettingUWork">優良設定マスタ（ユーザー登録分）レコード</param>
            public void Add(PrmSettingUWork prmSettingUWork)
            {
                string key = GetKey(prmSettingUWork);
                if (UserPrimeSettingRecordMap.ContainsKey(key))
                {
                    UserPrimeSettingRecordMap.Remove(key);
                }
                UserPrimeSettingRecordMap.Add(key, prmSettingUWork);
            }

            /// <summary>
            /// 検索します。
            /// </summary>
            /// <param name="middleGenreCode">中分類コード</param>
            /// <param name="blCode">BLコード</param>
            /// <param name="makerCode">メーカーコード</param>
            /// <returns>該当するレコードが無い場合、<c>null</c>を返します。</returns>
            public PrmSettingUWork Find(
                int middleGenreCode,
                int blCode,
                int makerCode,
                int selectCode,
                int prmSetDtl
            )
            {
                string key = GetKey(middleGenreCode, blCode, makerCode, selectCode, prmSetDtl);
                if (UserPrimeSettingRecordMap.ContainsKey(key))
                {
                    return UserPrimeSettingRecordMap[key];
                }
                return null;
            }

            /// <summary>
            /// 検索します。
            /// </summary>
            /// <param name="middleGenreCode">中分類コード</param>
            /// <param name="blCode">BLコード</param>
            /// <param name="makerCode">メーカーコード</param>
            /// <returns>該当するレコードが無い場合、<c>null</c>を返します。</returns>
            public ArrayList FindAll(
                int middleGenreCode,
                int blCode,
                int makerCode
            )
            {
                ArrayList retList = new ArrayList();
                foreach (PrmSettingUWork work in UserPrimeSettingRecordMap.Values)
                {
                    if ((work.GoodsMGroup == middleGenreCode) && (work.TbsPartsCode == blCode) && (work.PartsMakerCd == makerCode))
                    {
                        retList.Add(work);
                    }
                }

                if (retList.Count == 0)
                {
                    return null;
                }
                else
                {
                    return retList;
                }
            }

            /// <summary>
            /// 検索します。
            /// </summary>
            /// <param name="middleGenreCode">中分類コード</param>
            /// <param name="blCode">BLコード</param>
            /// <param name="makerCode">メーカーコード</param>
            /// <returns>該当するレコードが無い場合、<c>null</c>を返します。</returns>
            public ArrayList FindAll(
                string sectionCode,
                int middleGenreCode,
                int makerCode
            )
            {
                ArrayList retList = new ArrayList();
                foreach (PrmSettingUWork work in UserPrimeSettingRecordMap.Values)
                {
                    if ((work.SectionCode.Trim() == sectionCode.Trim()) && (work.GoodsMGroup == middleGenreCode) && (work.PartsMakerCd == makerCode))
                    {
                        retList.Add(work);
                    }
                }

                if (retList.Count == 0)
                {
                    return null;
                }
                else
                {
                    return retList;
                }
            }

            #region <キー/>

            /// <summary>
            /// キーを取得します。
            /// </summary>
            /// <param name="prmSettingUWork">優良設定マスタ（ユーザー登録分）レコード</param>
            /// <returns>middleGenreCode.ToString("0000") + blCode.ToString("0000") + makerCode.ToString("0000")</returns>
            private static string GetKey(PrmSettingUWork prmSettingUWork)
            {
                int middleGenreCode = prmSettingUWork.GoodsMGroup;
                int blCode          = prmSettingUWork.TbsPartsCode;
                int makerCode       = prmSettingUWork.PartsMakerCd;
                int selectCode = prmSettingUWork.PrmSetDtlNo1;
                int prmSetDtlNo = prmSettingUWork.PrmSetDtlNo2;
                return GetKey(middleGenreCode, blCode, makerCode, selectCode, prmSetDtlNo);
            }

            /// <summary>
            /// キーを取得します。
            /// </summary>
            /// <param name="middleGenreCode">中分類コード</param>
            /// <param name="blCode">BLコード</param>
            /// <param name="makerCode">メーカーコード</param>
            /// <returns>middleGenreCode.ToString("0000") + blCode.ToString("0000") + makerCode.ToString("0000")</returns>
            public static string GetKey(
                int middleGenreCode,
                int blCode,
                int makerCode
            )
            {
                return middleGenreCode.ToString("0000") + blCode.ToString("0000") + makerCode.ToString("0000");
            }

            public static string GetKey(
                int middleGenreCode,
                int blCode,
                int makerCode,
                int selectCode,
                int prmSetDtlNo
            )
            {
                return middleGenreCode.ToString("0000") + blCode.ToString("0000") + makerCode.ToString("0000") +
                        selectCode.ToString("0000") + prmSetDtlNo.ToString("0000");
            }

            #endregion  // <キー/>
        }

        #endregion  // <優良設定マスタ（ユーザー登録分）のヘルパクラス/>
        // ADD 2009/01/21 不具合対応[6970] ----------<<<<<
    }
}
