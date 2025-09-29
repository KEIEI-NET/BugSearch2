using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// SCMローカル設定アクセスクラス
    /// <summary>
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCMローカル設定アクセスクラス</br>
    /// <br>Programmer       :   佐々木　健</br>
    /// <br>Date             :   2010/03/03</br>
    /// </remarks>
    public class CmtLocalSetAcs
    {
        // ローカル設定アクセスクラスとデータクラスを記述します。
        // ローカル設定用ファイルパス
        private const string CTFILE_UISETTING = "PMSCM00008U_UserSetting.xml";

        private CmtLocalSet _cmtLocal;

        internal CmtLocalSet CmtLocal
        {
            get { return _cmtLocal; }
            set { _cmtLocal = value; }
        }

        /// <summary>
        /// ローカル設定読み込み処理
        /// </summary>
        /// <returns>ローカル設定</returns>
        public CmtLocalSet ReadScmLocalSet()
        {
            CmtLocalSet info = null;

            if (UserSettingController.ExistUserSetting(System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, CTFILE_UISETTING)))
            {
                try
                {
                    // XMLから抽出条件アイテムクラス配列にデシリアライズする
                    info = UserSettingController.DeserializeUserSetting<CmtLocalSet>(System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, CTFILE_UISETTING));
                }
                catch (InvalidOperationException)
                {
                }
            }

            if (info == null)
            {
                info = new CmtLocalSet();
            }

            return info;
        }

        /// <summary>
        /// ローカル設定保存処理
        /// </summary>
        /// <param name="info">ローカル設定</param>
        public void WriteLocalSet()
        {
            try
            {
                // 抽出条件アイテムクラス配列をXMLにシリアライズする
                UserSettingController.SerializeUserSetting(_cmtLocal, System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, CTFILE_UISETTING));
            }
            catch (Exception)
            {
            }
        }

    }


    /// public class name:   CmtLocalSet
    /// <summary>
    ///                      CMTローカル設定
    /// </summary>
    /// <remarks>
    /// <br>note             :   CMtローカル設定ヘッダファイル</br>
    /// <br>Programmer       :   佐々木　健</br>
    /// <br>Date             :   2010/03/10</br>
    /// </remarks>
    public class CmtLocalSet
    {
        /// <summary>受信時間</summary>
        /// <remarks>秒</remarks>
        private Int32 _recvTime;

        /// <summary>再試行</summary>
        /// <remarks>0:しない、1:する</remarks>
        private Int32 _retry;

        /// public propaty name  :  RecvTime
        /// <summary>受信時間プロパティ</summary>
        /// <value>秒を設定</value>
        public Int32 RecvTime
        {
            get { return _recvTime; }
            set { _recvTime = value; }
        }

        /// public propaty name  :  Retry
        /// <summary>リトライ</summary>
        /// <value>0:しない、1:する</value>
        public Int32 Retry
        {
            get { return _retry; }
            set { _retry = value; }
        }

        // 2011/03/04 Add >>>
        /// <summary>CTIモード</summary>
        private int _ctiMode = -1;

        /// <summary>
        /// CTI起動モード
        /// <value>0:しない、1:通常モード、2:売上伝票入力</value>
        /// </summary>
        public int CTIMode
        {
            get { return _ctiMode; }
            set { _ctiMode = value; }
        }
        // 2011/03/04 Add <<<


        /// <summary>
        /// ローカル設定コンストラクタ
        /// </summary>
        /// <returns>インスタンス</returns>
        /// </remarks>
        public CmtLocalSet()
        {
        }

        /// <summary>
        /// ローカル設定マスタコンストラクタ
        /// </summary>
        /// <param name="recvTime">受信時間</param>
        /// <param name="retry">再試行</param>
        // 2011/03/04 >>>
        //public CmtLocalSet(Int32 recvTime, Int32 retry)
        public CmtLocalSet(Int32 recvTime, Int32 retry, Int32 ctiMode)
        // 2011/03/04 <<<
        {
            this._recvTime = recvTime;
            this._retry = retry;
            this._ctiMode = ctiMode;  // 2011/03/04 Add
        }

        /// <summary>
        /// ローカル設定マスタ複製処理
        /// </summary>
        /// <returns>ScmLocalSetクラスのインスタンス</returns>
        public CmtLocalSet Clone()
        {
            // 2011/03/04 >>>
            //return new CmtLocalSet(this._recvTime, this._retry);
            return new CmtLocalSet(this._recvTime, this._retry, this._ctiMode);
            // 2011/03/04 <<<
        }

        /// <summary>
        /// ローカル設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のScmLocalSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        public bool Equals(CmtLocalSet target)
        {
            // 2011/03/04 >>>
            //return ( ( this.RecvTime == target.RecvTime )
            //    && ( this.Retry == target.Retry ));

            return ( ( this.RecvTime == target.RecvTime )
                   && ( this.Retry == target.Retry )
                   && ( this.CTIMode == target.CTIMode )
                   );

            // 2011/03/04 <<<
        }
    }

}
