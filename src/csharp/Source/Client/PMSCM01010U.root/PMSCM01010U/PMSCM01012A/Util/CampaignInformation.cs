//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/08/15  修正内容 : Redmine#23554 掛率マスタの売価率設定ありで且つ、キャンペーンの売価額設定ありの場合、売価率はクリアの対応
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// キャンペーン情報クラス
    /// </summary>
    public sealed class CampaignInformation
    {
        #region <キャンペーン管理データ>

        /// <summary>キャンペーン管理データ</summary>
        private CampaignMng _campaignMng;
        /// <summary>キャンペーン管理データを取得します。</summary>
        private CampaignMng CampaignMng { get { return _campaignMng; } }

        #endregion // </キャンペーン管理データ>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public CampaignInformation() : this(null) { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="campaignMng">キャンペーン管理データ</param>
        public CampaignInformation(CampaignMng campaignMng)
        {
            _campaignMng = campaignMng;
        }

        #endregion // </Constructor>

        /// <summary>
        /// 有効フラグを取得します。
        /// </summary>
        public bool Enabled
        {
            get { return CampaignMng != null; }
        }

        /// <summary>
        /// キャンペーンコードを取得します。
        /// </summary>
        public int CampaignCode
        {
            get
            {
                if (CampaignMng == null)
                {
                    return 0;
                }
                return CampaignMng.CampaignCode;
            }
        }

        // ADD 2011/08/15 ---- >>>>>
        /// <summary>
        /// キャンペーン率を取得します。
        /// </summary>
        public double RateVal
        {
            get
            {
                if (CampaignMng == null)
                {
                    return 0;
                }
                return CampaignMng.RateVal;
            }
        }
        // ADD 2011/08/15 ---- <<<<<
    }
}
