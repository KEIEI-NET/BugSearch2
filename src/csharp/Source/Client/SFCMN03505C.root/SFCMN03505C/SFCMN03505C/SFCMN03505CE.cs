using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// フェリカ情報入力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: フェリカ情報設定を行います。</br>
    /// <br>Programmer	: 22011 柏原　頼人</br>
    /// <br>Date		: 2008.11.06</br>
    /// <br></br>
    /// <br>Update Note: 2010.02.18  22018 鈴木 正臣</br>
    /// <br>           : PM.NS対応</br>
    /// <br>           : 　・NetAdvantageバージョンアップ対応</br>
    /// <br>           : 　・アイコン変更(SF→NS)</br>
    /// </remarks>
    public partial class SFCMN03505CE : Form
    {
        #region constructer
        /// <summary>
        /// フェリカ情報入力フォームコンストラクタ
        /// </summary>
        public SFCMN03505CE()
        {
            InitializeComponent();
            // ライブラリ初期化
            _felicaAcs.InitializeLibrary();
        }
        #endregion

        #region Private Membar
        private FelicaAcs _felicaAcs = new FelicaAcs();        // フェリカアクセスライブラリ
        private UInt64 _feliCaIDm = 0;                         // フェリカIDｍ
        private Int32 _pollingInterval = 400;                  // ポーリングの間隔(ms)
        private Int32 _pollingRetryCnt = 0;                    // 連続ポーリングの回数 0(ゼロ)で回数指定なし。
        private bool _showErrMsg = true;                      // ポーリングでエラー発生時のメッセージ表示区分
        /// <summary>最終エラータイプ(Felica.dll)</summary>
        private FeliCaErrorType _felicaLastErrType = FeliCaErrorType.FELICA_ERROR_NOT_OCCURRED;
        /// <summary>最終エラータイプ(rw.dll)</summary>
        private RwErrorType _rwLastErrType = RwErrorType.RW_ERROR_NOT_OCCURRED;
        #endregion

        #region Propaty
        /// <summary>
        /// 連続ポーリングの間隔を指定します(ms)　 初期値【400ms】
        /// </summary>
        public int PollingInterval
        {
            get
            {
                return this._pollingInterval;
            }
            set
            {
                this._pollingInterval = value;
            }
        }

        /// <summary>
        /// 連続ポーリングのポーリング回数を指定します。 0(ゼロ)で回数指定なし。
        /// </summary>
        public int PollingRetryCnt
        {
            get
            {
                return this._pollingRetryCnt;
            }
            set
            {
                this._pollingRetryCnt = value;
            }
        }

        /// <summary>
        /// エラー発生時のメッセージ表示有無　true:表示 false:非表示　(初期値:true)　RW_CARD_NOT_FOUNDは表示しません。
        /// </summary>
        public bool ShowErrMsg
        {
            get
            {
                return this._showErrMsg;
            }
            set
            {
                this._showErrMsg = value;
            }
        }

        /// <summary>最終エラータイプ(Felica.dll)</summary>
        public FeliCaErrorType FelicaLastErrType
        {
            get
            {
                return this._felicaLastErrType;
            }
        }

        /// <summary>最終エラータイプ(rw.dll)</summary>
        public RwErrorType RwLastErrType
        {
            get
            {
                return this._rwLastErrType;
            }
        }
        #endregion

        #region delegate
        // メッセージ表示用
        delegate void MsgDispDelegate(emErrorLevel errLvl, string msg);
        #endregion

        #region Public Method
        /// <summary>
        /// フェリカ情報入力フォームを表示します
        /// </summary>
        /// <param name="feliCaIDm">フェリカIDｍ</param>
        /// <param name="ownerForm">オーナーフォーム</param>
        /// <returns>DialogResult 読み取り成功 :OK, 読み取り失敗 :Abort, キャンセル ：Cansel</returns>
        public DialogResult ShowFeliCaReadForm(ref UInt64 feliCaIDm, Form ownerForm)
        {
            if (_felicaAcs == null)            
            {
                _felicaAcs = new FelicaAcs();
                _felicaAcs.InitializeLibrary();
            }
            // リーダー／ライターオープン
            if (!_felicaAcs.OpenReaderWriterAuto())
            {
                //オープンに失敗
                PollingCallBack(0, 0, false);
                return DialogResult.Abort;
            }

            // コールバックデリゲートに登録
            _felicaAcs.CallBackDelegate = new FelicaAcs.PollingCallBackDelegate(PollingCallBack);
            // 連続ポーリング開始
            _felicaAcs.StartPolling(_pollingInterval, _pollingRetryCnt);
            // ダイアログ表示
            this.Owner = ownerForm;
            DialogResult ret = this.ShowDialog();
            feliCaIDm = _feliCaIDm;
            return ret;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// ポーリングコールバック関数
        /// </summary>
        /// <param name="idm">フェリカIDM</param>
        /// <param name="pmm"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool PollingCallBack(UInt64 idm, UInt64 pmm, bool result)
        {
            if (result)
            {
                // --- ADD m.suzuki 2010/02/18 ---------->>>>>
                if ( idm == 0 )
                {
                    // 一度ポーリング成功と認識してもidm=0ならばキャンセルする。
                    // （※未接続の時、誤認識してしまう為）
                    return false;
                }
                // --- ADD m.suzuki 2010/02/18 ----------<<<<<

                // ポーリング成功
                _feliCaIDm = idm;
                this.DialogResult = DialogResult.OK;
                //this.Close();
            }
            else
            {
                // 最終エラータイプ取得
                _felicaAcs.GetLastErrorTypes(out _felicaLastErrType, out _rwLastErrType);

                if (ShowErrMsg)
                {
                    if ((_felicaAcs.FelicaLastErrType == FeliCaErrorType.FELICA_READER_WRITER_OPEN_AUTO_ERROR) ||
                        (_felicaAcs.RwLastErrType == RwErrorType.RW_DEVICE_PLUGIN_NOT_FOUND) ||
                        (_felicaAcs.FelicaLastErrType == FeliCaErrorType.FELICA_FILE_NOT_FOUND))
                    {
                        // ドライバ未導入またはリーダー未接続
                        StringBuilder msg = new StringBuilder();
                        msg.AppendLine("カードリーダーが検出できませんでした。");
                        msg.AppendLine(string.Empty);
                        msg.AppendLine("次のことを確認して再度お試し下さい。");
                        msg.AppendLine("　・フェリカカードのリーダーは接続されていますか");
                        msg.AppendLine("　・リーダーの最新ドライバがインストールされハードウェアが認識されていますか");
                        msg.AppendLine("　・他のプログラムでリーダーを使用中ではないですか");
                        MsgDispInvokeRequired(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg.ToString());
                    }
                    else if((_felicaAcs.RwLastErrType != RwErrorType.RW_CARD_NOT_FOUND) &&
                        (_felicaAcs.RwLastErrType != RwErrorType.RW_ERROR_NOT_OCCURRED))
                    {
                        // カードが見つからない意外でエラーが発生したらメッセージ表示
                        // ポーリング失敗
                        MsgDispInvokeRequired(emErrorLevel.ERR_LEVEL_EXCLAMATION, _felicaAcs.LastErrMsg);
                        _felicaAcs.Dispose();
                        _felicaAcs = null;
                    }
                }
                this.DialogResult = DialogResult.Abort;
            }
            return result;
        }

        /// <summary>
        /// スレッドセーフな方法でメッセージをダイアログ表示します
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        /// <param name="errLvl">エラーレベル</param>
        /// <param name="errMsg">エラーメッセージ</param>
        private void MsgDispInvokeRequired(emErrorLevel errLvl, string msg)
        {
            if (this.InvokeRequired)
            {
                object[] parm = new object[]{(object)errLvl, (object)msg};
                Invoke(new MsgDispDelegate(MsgDispInvokeRequired), parm);
                return;
            }
            TMsgDisp.Show(
               this.Owner,					          // 親ウィンドウフォーム
               errLvl,	                              // エラーレベル
               "SFCMN03505CE",						  // アセンブリＩＤまたはクラスＩＤ
               this.Text,							  // プログラム名称
               "PollingCallBack",			          // 処理名称
               TMsgDisp.OPE_GET,					  // オペレーション
               msg.ToString(),				          // 表示するメッセージ 
               -1,								      // ステータス値
               this._felicaAcs,					      // エラーが発生したオブジェクト
               MessageBoxButtons.OK,				  // 表示するボタン
               MessageBoxDefaultButton.Button1);	  // 初期表示ボタン
        }
        #endregion

        #region Control Event
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFCMN03505CE_Load(object sender, EventArgs e)
        {
            // ボタンのアイコン設定
            this.Cancel_Button.Appearance.Image = IconResourceManagement.ImageList24.Images[(int)Size24_Index.CLOSE];
        }

        /// <summary>
        /// 「戻る」ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 連続ポーリング中止
            _felicaAcs.StopPolling();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion
    }
}