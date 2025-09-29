using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 動作設定メインクラス
    /// </summary>
    public class Settings_MAIN
    {
        public Settings[] settings;
    }

    /// <summary>
    /// 動作設定クラス
    /// </summary>
    public class Settings
    {
        /// <summary>UUID</summary>
        public string uuid;

        /// <summary>作成日</summary>
        public long insDtTime;

        /// <summary>更新日</summary>
        public long updDtTime;

        /// <summary>アカウントID</summary>
        public int insAccountId;

        /// <summary>更新アカウントID</summary>
        public int updAccountId;

        /// <summary>論理削除区分</summary>
        public int logicalDelDiv;

        /// <summary>企業コード</summary>
        public string enterpriseCode;

         /// <summary>拠点コード</summary>
        public string sectionCode;

        /// <summary>動作設定ID</summary>
        public long settingId;

        /// <summary>問合せ利用フラグ</summary>
        public bool inquiryUseFlag;

        /// <summary>発売日表示フラグ</summary>
        public bool releaseDateDisplayFlag;

        /// <summary>在庫通知フラグ</summary>
        public bool stockDisplayFlag;


        /// <summary>
        /// 動作設定クラス 複製処理
        /// </summary>
        /// <returns>Settingsクラスのインスタンス</returns>
        /// <remarks>
        /// </remarks>
        public Settings Clone()
        {
            return new Settings(this.uuid, this.insDtTime, this.updDtTime, this.insAccountId, this.updAccountId, this.logicalDelDiv,
                this.enterpriseCode, this.sectionCode, this.settingId, this.inquiryUseFlag, this.releaseDateDisplayFlag, this.stockDisplayFlag);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Settings()
        {

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Settings(string uuid, long insDtTime, long updDtTime, int insAccountId, int updAccountId, int logicalDelDiv,
            string enterpriseCode, string sectionCode, long settingId, bool inquiryUseFlag, bool releaseDateDisplayFlag, bool stockDisplayFlag)
        {
            this.uuid = uuid;
            this.insDtTime = insDtTime;
            this.updDtTime = updDtTime;
            this.insAccountId = insAccountId;
            this.updAccountId = updAccountId;
            this.logicalDelDiv = logicalDelDiv;
            this.enterpriseCode = enterpriseCode;
            this.sectionCode = sectionCode;
            this.settingId = settingId;
            this.inquiryUseFlag = inquiryUseFlag;
            this.releaseDateDisplayFlag = releaseDateDisplayFlag;
            this.stockDisplayFlag = stockDisplayFlag;
        }
    }
}
