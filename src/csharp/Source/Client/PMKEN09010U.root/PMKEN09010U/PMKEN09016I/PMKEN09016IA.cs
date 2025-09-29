using System;
using System.Text;

namespace Broadleaf.Application.Common
{
    # region Delegate
    /// <summary>タブ切り替えイベント用デリゲート</summary>
    public delegate void MainTabChangeEventHandler(object sender, int TabIndex);
    /// <summary>メインフレーム通知イベント用デリゲート</summary>
    public delegate void FrameNotifyEventHandler(object sender, int TabIndex, string key);
    # endregion

    #region 　共通インターフェース
    /// <summary>
    ///  　共通インターフェース
    /// </summary>
    public interface IPrimeSettingController
    {
        object objPrimeSettingController { get; set;}
        void MainTabIndexChange(object sender, int TabIndex);
        void FrameNotifyEvent(object sender, int TabIndex, string key);
    }
    #endregion

    // ADD 2008/10/29 不具合対応[6962] 仕様変更 ---------->>>>>
    /// <summary>
    /// 保存可能か判定するインターフェース
    /// </summary>
    public interface IPrimeSettingCheckable
    {
        /// <summary>
        /// 保存可能か判定します。
        /// </summary>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>
        /// <c>true</c> :保存可能<br/>
        /// <c>false</c>:保存不可能
        /// </returns>
        bool CanSave(out string errorMessage);
    }

    #region <優良設定用備考/>

    /// <summary>
    /// 優良設定用備考の値が変化したときのイベントパラメータクラス
    /// </summary>
    public sealed class NoteChangedEventArgs : EventArgs
    {
        #region <中分類コード/>

        /// <summary>中分類コード</summary>
        private readonly int _middleCode;
        /// <summary>
        /// 中分類コードを取得します。
        /// </summary>
        /// <value>中分類コード</value>
        public int MiddleCode
        {
            get { return _middleCode; }
        }

        #endregion  // <中分類コード/>

        #region <BLコード/>

        /// <summary>BLコード</summary>
        private readonly int _blCode;
        /// <summary>
        /// BLコードを取得します。
        /// </summary>
        /// <value>BLコード</value>
        public int BLCode
        {
            get { return _blCode; }
        }

        #endregion  // <BLコード/>

        #region <メーカーコード/>

        /// <summary>メーカーコード</summary>
        private readonly int _makerCode;
        /// <summary>
        /// メーカーコードを取得します。
        /// </summary>
        /// <value>メーカーコード</value>
        public int MakerCode
        {
            get { return _makerCode; }
        }

        #endregion  // <メーカーコード/>

        #region <優良設定用備考/>

        /// <summary>優良設定用備考のテキスト</summary>
        private readonly string _noteText;
        /// <summary>
        /// 優良設定用備考のテキストを取得します。
        /// </summary>
        /// <value>優良設定用備考のテキスト</value>
        public string NoteText
        {
            get { return _noteText; }
        }

        #endregion  // <優良設定用備考/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="middleCode">中分類コード</param>
        /// <param name="blCode">BLコード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="noteText">優良設定用備考のテキスト</param>
        public NoteChangedEventArgs(
            int middleCode,
            int blCode,
            int makerCode,
            string noteText
        )
        {
            _middleCode = middleCode;
            _blCode     = blCode;
            _makerCode  = makerCode;
            _noteText   = noteText;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// 文字列に変換します。
        /// </summary>
        /// <returns>メーカー：0000/中分類：0000/BL：0000</returns>
        public override string ToString()
        {
            const string SEPARATOR = "/";

            StringBuilder ret = new StringBuilder();

            ret.Append("メーカー:").Append(MakerCode.ToString("0000"));
            ret.Append(SEPARATOR);
            ret.Append("中分類:").Append(MiddleCode.ToString("0000"));
            ret.Append(SEPARATOR);
            ret.Append("BL:").Append(BLCode.ToString("0000"));

            return ret.ToString();
        }
    }

    /// <summary>
    /// 優良設定用備考の値が変化したときのイベントハンドラ
    /// </summary>
    /// <param name="sender">イベントソース</param>
    /// <param name="e">イベントパラメータ</param>
    public delegate void NoteChangedEventHandler(
        object sender,
        NoteChangedEventArgs e
    );

    /// <summary>
    /// 優良設定用備考の管理インターフェース
    /// </summary>
    public interface IPrimeSettingNoteChanger
    {
        /// <summary>優良設定用備考が変化したときのイベント</summary>
        event NoteChangedEventHandler NoteChanged;
    }

    /// <summary>
    /// 優良設定用備考の値が変化したときのイベントハンドラインターフェース
    /// </summary>
    public interface IPrimeSettingNoteChangedEventHandler
    {
        /// <summary>
        /// 優良設定用備考の値が変化したときのイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        void PrimeSettingNoteChanged(
            object sender,
            NoteChangedEventArgs e
        );
    }

    #endregion  // <優良設定用備考/>
    // ADD 2008/10/29 不具合対応[6962] 仕様変更 ----------<<<<<
}