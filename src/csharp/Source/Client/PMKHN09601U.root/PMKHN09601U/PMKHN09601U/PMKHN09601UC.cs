//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン管理マスタ
// プログラム概要   : キャンペーン管理の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// キャンペーン管理マスメンガイドコントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン管理マスメンで使用する各種アクセスクラスを制御するクラスです。</br>
    /// <br>           : （検索ＵＩと編集ＵＩで共有します。）</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2009/05/28</br>
    /// <br></br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class CampaignMngGuideControl
    {
        # region [フィールド]
        // 企業コード
        private string _enterpriseCode;
        // 拠点コード
        private string _sectionCode;

        // 拠点情報設定アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs;
        // 拠点情報アクセスクラス
        private SecInfoAcs _secInfoAcs;
        // 拠点情報ディクショナリ
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        // BLコードアクセスクラス
        private BLGoodsCdAcs _bLGoodsCdAcs;
        // メーカーアクセスクラス
        private MakerAcs _makerAcs;
        //// 得意先情報アクセスクラス
        //private CustomerSearchAcs _customerSearchAcs;
        //// 得意先ガイド結果クラス
        //private CustomerSearchRet _customerGuideRet;
        //// 得意先ガイドＵＩ
        //private PMKHN04005UA _customerSearchForm;
        //// 仕入先アクセスクラス
        //private SupplierAcs _supplierAcs;
        //// 商品アクセスクラス
        private GoodsAcs _goodsAcs;
        // キャンペーン設定アクセスクラス
        private CampaignStAcs _campaignStAcs;
        # endregion

        # region [プロパティ]
        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// 拠点コード
        /// </summary>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// <summary>
        /// 拠点アクセス
        /// </summary>
        public SecInfoSetAcs SecInfoSetAcs
        {
            get
            {
                if ( _secInfoSetAcs == null )
                {
                    _secInfoSetAcs = new SecInfoSetAcs();
                }
                return _secInfoSetAcs;
            }
        }

        /// <summary>
        /// 拠点ディクショナリ
        /// </summary>
        public Dictionary<string, SecInfoSet> SecInfoSetDic
        {
            get
            {
                if ( _secInfoSetDic == null )
                {
                    ReadSecInfoSet();
                }
                return _secInfoSetDic;
            }
        }

        /// <summary>
        /// ＢＬコードアクセス
        /// </summary>
        public BLGoodsCdAcs BLGoodsCdAcs
        {
            get
            {
                if ( _bLGoodsCdAcs == null )
                {
                    _bLGoodsCdAcs = new BLGoodsCdAcs();
                }
                return _bLGoodsCdAcs;
            }
        }

        /// <summary>
        /// メーカーアクセス
        /// </summary>
        public MakerAcs MakerAcs
        {
            get
            {
                if ( _makerAcs == null )
                {
                    _makerAcs = new MakerAcs();
                }
                return _makerAcs;
            }
        }

        ///// <summary>
        ///// 得意先検索アクセス
        ///// </summary>
        //public CustomerSearchAcs CustomerSearchAcs
        //{
        //    get
        //    {
        //        if ( _customerSearchAcs == null )
        //        {
        //            _customerSearchAcs = new CustomerSearchAcs();
        //        }
        //        return _customerSearchAcs;
        //    }
        //}

        ///// <summary>
        ///// 得意先検索ガイドＵＩ
        ///// </summary>
        //public PMKHN04005UA CustomerSearchForm
        //{
        //    get
        //    {
        //        _customerSearchForm = new PMKHN04005UA( PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY );
        //        _customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler( this.CustomerSearchForm_CustomerSelect );

        //        _customerGuideRet = null;
        //        return _customerSearchForm;
        //    }
        //}

        ///// <summary>
        ///// 得意先検索ガイド結果
        ///// </summary>
        //public CustomerSearchRet CustomerGuideRet
        //{
        //    get { return _customerGuideRet; }
        //}

        ///// <summary>
        ///// 仕入先アクセス
        ///// </summary>
        //public SupplierAcs SupplierAcs
        //{
        //    get
        //    {
        //        if ( _supplierAcs == null )
        //        {
        //            _supplierAcs = new SupplierAcs();
        //        }
        //        return _supplierAcs;
        //    }
        //}

        /// <summary>
        /// 商品アクセス
        /// </summary>
        public GoodsAcs GoodsAcs
        {
            get
            {
                if ( _goodsAcs == null )
                {
                    _goodsAcs = new GoodsAcs();
                }
                return _goodsAcs;
            }
        }

        /// <summary>
        /// キャンペーン設定アクセスクラス
        /// </summary>
        public CampaignStAcs CampaignStAcs
        {
            get
            {
                if (_campaignStAcs == null)
                {
                    _campaignStAcs = new CampaignStAcs();
                }
                return _campaignStAcs;
            }
        }

        # endregion

        # region [イベント]
        /// <summary>
        /// 最新情報取得後イベント
        /// </summary>
        public event EventHandler AfterRenewal;
        # endregion

        # region [コンストラクタ]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CampaignMngGuideControl( string enterpriseCode, string sectionCode )
        {
            _enterpriseCode = enterpriseCode;
            _sectionCode = sectionCode;

            // 最新情報取得
            RenewalProc();

            // ※最新情報取得イベントを発行しない
        }
        # endregion

        # region [publicメソッド]
        /// <summary>
        /// 最新情報取得
        /// </summary>
        public void Renewal()
        {
            // 最新情報取得
            RenewalProc();

            // 最新情報取得後イベント発行
            if ( this.AfterRenewal != null )
            {
                AfterRenewal( this, new EventArgs() );
            }
        }
        # endregion

        # region [privateメソッド]
        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 拠点情報マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            if ( _secInfoAcs == null )
            {
                _secInfoAcs = new SecInfoAcs();
            }
            this._secInfoAcs.ResetSectionInfo();

            foreach ( SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList )
            {
                if ( secInfoSet.LogicalDeleteCode == 0 )
                {
                    this._secInfoSetDic.Add( secInfoSet.SectionCode.Trim(), secInfoSet );
                }
            }
        }
        
        ///// <summary>
        ///// 得意先選択ガイドボタンクリック
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先情報戻り値クラス(PMKHN4002E)</param>
        //private void CustomerSearchForm_CustomerSelect( object sender, CustomerSearchRet customerSearchRet )
        //{
        //    // イベントハンドラを渡した相手から戻り値クラスを受け取れなければ終了
        //    if ( customerSearchRet == null ) return;
        //    // ガイド結果をprivateフィールドに退避
        //    _customerGuideRet = customerSearchRet;
        //}
        /// <summary>
        /// 最新情報取得
        /// </summary>
        private void RenewalProc()
        {
            // メンバ初期化
            _secInfoSetAcs = null;
            _secInfoAcs = null;
            _secInfoSetDic = null;
            _bLGoodsCdAcs = null;
            _makerAcs = null;
            //_customerSearchAcs = null;
            //_customerGuideRet = null;
            //_customerSearchForm = null;
            //_supplierAcs = null;
            _goodsAcs = null;
            _campaignStAcs = null;
            
            // 拠点ディクショナリ生成
            ReadSecInfoSet();

            // 商品アクセスクラス初期検索
            string msg;
            GoodsAcs.SearchInitial( _enterpriseCode, _sectionCode, out msg );
        }
        # endregion
    }
}
