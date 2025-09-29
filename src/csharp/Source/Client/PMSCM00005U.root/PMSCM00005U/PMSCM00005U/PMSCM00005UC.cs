using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller.Util;// ADD 2020/10/30 陳艶丹 PMKOBETSU-4088

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
    public class ScmLocalSetAcs
    {
        // SCMローカル設定アクセスクラスとデータクラスを記述します。
        // SCMローカル設定用ファイルパス
        private const string CTFILE_UISETTING = "PMSCM00005U_UserSetting.xml";

        private ScmLocalSet _scmLocal;

        internal ScmLocalSet ScmLocal
        {
            get { return _scmLocal; }
            set { _scmLocal = value; }
        }


        /// <summary>
        /// SCMローカル設定読込処理
        /// </summary>
        /// <returns>SCMローカル設定</returns>
        /// <remarks>
        /// <br>Note		: SCMローカル設定情報を読み込みます。</br>
        /// <br>Programmer	: 21024　佐々木 健</br>
        /// <br>Date		: 2010.03.03</br>
        /// </remarks>
        public ScmLocalSet ReadScmLocalSet()
        {
            ScmLocalSet info = null;

            if (UserSettingController.ExistUserSetting(System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, CTFILE_UISETTING)))
            {
                try
                {
                    // XMLから抽出条件アイテムクラス配列にデシリアライズする
                    info = UserSettingController.DeserializeUserSetting<ScmLocalSet>(System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, CTFILE_UISETTING));
                }
                catch (InvalidOperationException)
                {
                    LogWriter.LogWrite("SCMローカル設定用ファイルから最終取得日付と最終取得時間を取得失敗しました。");// ADD 2020/10/30 陳艶丹 PMKOBETSU-4088
                }
            }

            if (info == null)
            {
                info = new ScmLocalSet();
            }

            return info;
        }

        /// <summary>
        /// SCMローカル設定保存処理
        /// </summary>
        /// <param name="info">SCMローカル設定</param>
        /// <remarks>
        /// <br>Note		: SCMローカル設定を保存します。</br>
        /// <br>Programmer	: 30015 橋本　裕毅</br>
        /// <br>Date		: 2009.05.22</br>
        /// </remarks>
        public void WriteScmLocalSet()
        {
            try
            {
                // 抽出条件アイテムクラス配列をXMLにシリアライズする
                UserSettingController.SerializeUserSetting(_scmLocal, System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, CTFILE_UISETTING));
            }
            catch (Exception)
            {
            }
        }

    }


    /// public class name:   ScmLocalSet
    /// <summary>
    ///                      SCMローカル設定
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCMローカル設定ヘッダファイル</br>
    /// <br>Programmer       :   佐々木　健</br>
    /// <br>Date             :   2010/03/03</br>
    /// </remarks>
    public class ScmLocalSet
    {
        /// <summary>ポップアップ表示区分</summary>
        /// <remarks>0:表示する,1:表示しない</remarks>
        private Int32 _popupDspDiv;

        /// <summary>ポップアップ表示時間</summary>
        /// <remarks>秒単位(0:ずっと表示)</remarks>
        private Int32 _popUpDspTime;

        /// <summary>最終取得日付</summary>
        /// <remarks>YYYYMMDD(DATETIME)</remarks>
        private DateTime _lastGetDate;

        /// <summary>最終取得時間</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _lastGetTime;

        /// public propaty name  :  PopupDspDiv
        /// <summary>ポップアップ表示区分プロパティ</summary>
        /// <value>0:表示する,1:表示しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ポップアップ表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PopupDspDiv
        {
            get { return _popupDspDiv; }
            set { _popupDspDiv = value; }
        }

        /// public propaty name  :  PopUpDspTime
        /// <summary>ポップアップ表示時間プロパティ</summary>
        /// <value>秒単位(0:ずっと表示)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ポップアップ表示時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PopUpDspTime
        {
            get { return _popUpDspTime; }
            set { _popUpDspTime = value; }
        }

        /// public propaty name  :  LastGetDate
        /// <summary>最終取得日付プロパティ</summary>
        /// <value>YYYYMMDD(DATETIME)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終取得日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LastGetDate
        {
            get { return _lastGetDate; }
            set { _lastGetDate = value; }
        }

        /// public propaty name  :  LastGetTime
        /// <summary>最終取得時間プロパティ</summary>
        /// <value>HHMMSSXXX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終取得時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LastGetTime
        {
            get { return _lastGetTime; }
            set { _lastGetTime = value; }
        }

        /// <summary>
        /// SCMローカル設定コンストラクタ
        /// </summary>
        /// <returns>ScmLocalSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmLocalSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ScmLocalSet()
        {
        }


        /// <summary>
        /// SCMローカル設定マスタコンストラクタ
        /// </summary>
        /// <param name="popupDspDiv">ポップアップ表示区分(0:表示する,1:表示しない)</param>
        /// <param name="popUpDspTime">ポップアップ表示時間(秒単位(0:ずっと表示))</param>
        /// <param name="lastGetDate">最終取得日付(YYYYMMDD(DATETIME))</param>
        /// <param name="lastGetTime">最終取得時間(HHMMSSXXX)</param>
        /// <returns>ScmLocalSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmLocalSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ScmLocalSet(Int32 popupDspDiv, Int32 popUpDspTime, DateTime lastGetDate, Int32 lastGetTime)
        {
            this._popupDspDiv = popupDspDiv;
            this._popUpDspTime = popUpDspTime;
            this._lastGetDate = lastGetDate;
            this._lastGetTime = lastGetTime;

        }

        /// <summary>
        /// SCMローカル設定マスタ複製処理
        /// </summary>
        /// <returns>ScmLocalSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいScmLocalSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ScmLocalSet Clone()
        {
            return new ScmLocalSet(this._popupDspDiv, this._popUpDspTime, this._lastGetDate, this._lastGetTime);
        }

        /// <summary>
        /// SCMローカル設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のScmLocalSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmLocalSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(ScmLocalSet target)
        {
            return ( ( this.PopupDspDiv == target.PopupDspDiv )
                && ( this.PopUpDspTime == target.PopUpDspTime )
                && ( this.LastGetDate == target.LastGetDate )
                && ( this.LastGetTime == target.LastGetTime ) );
        }
    }

}
