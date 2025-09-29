using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Library.Runtime.InteropServices
{
    /// <summary>
    /// フェリカアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : フェリカのリーダ／ライタにアクセスします。</br>
    /// <br>           : felica.dll,rw.dll,及びプラグインはカレントディレクトリに</br>
    /// <br>           : 配置されている事を前提としています。</br>
    /// <br>Programmer : 22011 Kashihara</br>
    /// <br>Date       : 2008.10.30</br>
    /// <br>Update Note: 22011 Kashihara</br>
    /// <br>           : 2009.02.16 カードが抜かれたあとも連続ポーリングのステータスがtrueで戻る現象に対応</br>
    /// </remarks>
    public class FelicaAcs : IDisposable
    {
        #region delegate定義
        /// <summary>連続ポーリングのコールバックデリゲート</summary>
        public delegate bool PollingCallBackDelegate(UInt64 idm, UInt64 pmm, bool result);
        #endregion

        #region private member
        /// <summary>FeliCa.DLLラッパークラス</summary>
        private Wrapper FeliCaDllWrapper = new Wrapper();
        /// <summary>連続ポーリング用タイマー</summary>
        private System.Threading.Timer _pollingTimer;
        /// <summary>連続ポーリングの最大リトライ回数</summary>
        private int _pollingRetryMax;
        /// <summary>連続ポーリングの現リトライ回数</summary>
        private int _pollingRetryCnt;
        /// <summary>最終エラーメッセージ</summary>
        private string _lastErrMsg = string.Empty;
        /// <summary>最終エラータイプ(rw.dll)</summary>
        private RwErrorType _rwLastErrType = RwErrorType.RW_ERROR_NOT_OCCURRED;
        /// <summary>最終エラータイプ(Felica.dll)</summary>
        private FeliCaErrorType _felicaLastErrType = FeliCaErrorType.FELICA_ERROR_NOT_OCCURRED;
        /// <summary>felica.dll存在判定フラグ</summary>
        private bool _felicaDllExists = false;
        ///// <summary>ポーリング処理中フラグ</summary>
        //private bool _pollingFlg = false;
        #endregion

        #region public member
        /// <summary>連続ポーリング成功時のコールバックデリゲート</summary>
        public PollingCallBackDelegate CallBackDelegate;
        #endregion

        #region propaty
        /// <summary>最終エラーメッセージ</summary>
        public string LastErrMsg
        {
            get
            {
                return _lastErrMsg;
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

        #region constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FelicaAcs()
        {
            // felica.dll 存在チェック
            _felicaDllExists = FelicaDllExists();
        }
        #endregion

        #region destructor
        /// <summary>
        /// デストラクタ
        /// </summary>
        ~FelicaAcs()
        {
            Dispose();
        }

        /// <summary>
        /// ディスポーズ処理
        /// </summary>
        public void Dispose()
        {
            try
            {
                if (_felicaDllExists)
                {
                    // ポーリング中で有れば待機
                    if (_pollingTimer != null)
                        System.Threading.Thread.Sleep(800);

                    if (_pollingTimer != null)
                        StopPolling();
                    // リーダー／ライターのクローズ
                    FeliCaDllWrapper.CloseReaderWriter();
                    // ライブラリ,ハンドルの開放
                    FeliCaDllWrapper.DisposeLibrary();
                }
                HandleContainer.FreeHandle();
            }
            catch
            {
            }
        }
        #endregion

        #region InitializeLibrary /ライブラリの初期化
        /// <summary>
        /// ライブラリの初期化
        /// </summary>
        /// <returns></returns>
        public bool InitializeLibrary()
        {
            // felica.dllがなければ終了
            if (!_felicaDllExists) return false;
            bool result = true;
    
            if (!FeliCaDllWrapper.InitializeLibrary())
            {
                GetLastErrorTypes(out _felicaLastErrType, out _rwLastErrType);
                if(_felicaLastErrType != FeliCaErrorType.FELICA_LIBRARY_ALREADY_INITIALIZED)
                    result = false;
            }
            return result;
        }
        #endregion

        #region OpenReaderWriterAuto /リーダー／ライターの自動認証とオープン
        /// <summary>
        /// リーダー／ライターの自動認証とオープン
        /// </summary>
        /// <returns></returns>
        public bool OpenReaderWriterAuto()
        {
            // felica.dllがなければ終了
            if (!_felicaDllExists) return false;
            bool result = true;

            if (!FeliCaDllWrapper.OpenReaderWriterAuto())
            {
                GetLastErrorTypes(out _felicaLastErrType, out _rwLastErrType);
                if (_felicaLastErrType != FeliCaErrorType.FELICA_READER_WRITER_ALREADY_OPENED)
                    result = false;
            }
            return result;
        }
        #endregion

        #region CloseReaderWriter /リーダー／ライターのクローズ
        /// <summary>
        /// リーダー／ライターのクローズ
        /// </summary>
        /// <returns></returns>
        public bool CloseReaderWriter()
        {
            // felica.dllがなければ終了
            if (!_felicaDllExists) return false;

            bool result = true;
            if (!FeliCaDllWrapper.CloseReaderWriter())
            {
                GetLastErrorTypes(out _felicaLastErrType, out _rwLastErrType);
                result = false;
            }
            return result;
        }
        #endregion

        #region DisposeLibrary /ライブラリの開放
        /// <summary>
        /// ライブラリの開放
        /// </summary>
        /// <returns></returns>
        public bool DisposeLibrary()
        {
            bool result = true;
            if (!FeliCaDllWrapper.DisposeLibrary())
            {
                GetLastErrorTypes(out _felicaLastErrType, out _rwLastErrType);
                result = false;
            }
            return result;
        }
        #endregion

        #region GetLastErrorTypes /最終エラー取得
        /// <summary>
        /// 最終エラー取得
        /// </summary>
        /// <param name="feliCaErrorType">felica.dllのエラータイプ</param>
        /// <param name="rwErrorType">rw.dllのエラータイプ</param>
        /// <returns></returns>
        public bool GetLastErrorTypes(out FeliCaErrorType feliCaErrorType, out RwErrorType rwErrorType)
        {
            // felica.dllがなければ終了
            if (!_felicaDllExists)
            {
                feliCaErrorType = _felicaLastErrType;
                rwErrorType = _rwLastErrType;
                return false;
            }

            bool result;
            feliCaErrorType = FeliCaErrorType.FELICA_ERROR_NOT_OCCURRED;
            rwErrorType = RwErrorType.RW_ERROR_NOT_OCCURRED;
            _lastErrMsg = string.Empty;

            // 最終エラーを取得
            result = FeliCaDllWrapper.GetLastErrorTypes(ref _felicaLastErrType, ref _rwLastErrType);
            // FeliCa.dllのエラー
            if (_felicaLastErrType != FeliCaErrorType.FELICA_ERROR_NOT_OCCURRED)
                _lastErrMsg = (Enum.Parse(Type.GetType("Broadleaf.Library.Runtime.InteropServices.FeliCaErrorTypeMsg"), ((int)_felicaLastErrType).ToString())).ToString();
            // rw.dllのエラー
            if (_rwLastErrType != RwErrorType.RW_ERROR_NOT_OCCURRED)
                _lastErrMsg += ("\n" + (Enum.Parse(Type.GetType("Broadleaf.Library.Runtime.InteropServices.RwErrorTypeMsg"), ((int)_rwLastErrType).ToString())).ToString());

            // カードが見つからない以外のエラーはLogを書き出す
            if (((feliCaErrorType != FeliCaErrorType.FELICA_ERROR_NOT_OCCURRED) || (rwErrorType != RwErrorType.RW_ERROR_NOT_OCCURRED)) &&
                 (rwErrorType != RwErrorType.RW_CARD_NOT_FOUND))
                TMsgDisp.Show(
                               emErrorLevel.ERR_LEVEL_NODISP,	      // エラーレベル
                               "SFCMN03505CA",						  // アセンブリＩＤまたはクラスＩＤ
                               "FeliCaAcs",							  // プログラム名称
                               "GetLastErrorTypes",			          // 処理名称
                               TMsgDisp.OPE_CALL,					  // オペレーション
                               _felicaLastErrType.ToString() + "," +
                               _rwLastErrType.ToString() + " :" + _lastErrMsg,
                               -1,                                    // ステータス
                               this,	            				  // エラーが発生したオブジェクト
                               MessageBoxButtons.OK,				  // 表示するボタン
                               MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

            feliCaErrorType = _felicaLastErrType;
            rwErrorType = _rwLastErrType;
            return result;
        }
        #endregion

        #region PollingAndGetCardInformation /ポーリングとカード情報の取得
        /// <summary>
        /// ポーリングとカード情報の取得
        /// </summary>
        /// <param name="felicaSystemCode">フェリカシステムコード</param>
        /// <param name="cardIdm">FeliCaのIDm</param>
        /// <param name="cardPmm">FeliCaのPmm</param>
        /// <returns></returns>
        public bool PollingAndGetCardInformation(UInt16 felicaSystemCode, out UInt64 cardIdm, out UInt64 cardPmm)
        { 
            cardIdm = 0;
            cardPmm = 0;
            
            // felica.dllがなければ終了
            if (!_felicaDllExists) return false;

            // ポーリング情報構造体,カード情報構造体
            StructurePolling polling = new StructurePolling();
            StructureCardInformation cardInformation = new StructureCardInformation();

            byte[] bytSystemCode = BitConverter.GetBytes(felicaSystemCode);
            // BitConverter.GetBytesはバイトの並びが逆になるのでリバースする
            Array.Reverse(bytSystemCode);
            HandleContainer.FeliCaSystemCode = GCHandle.Alloc(bytSystemCode, GCHandleType.Pinned);
            polling.FelicaSystemCode = HandleContainer.FeliCaSystemCode.AddrOfPinnedObject().ToInt32();
            
            byte[] bytCardIdm = new byte[8];
            byte[] bytCardPmm = new byte[8];

            // パラメータセット
            polling.TimeSlot = 0x00;
            HandleContainer.CardIdm = GCHandle.Alloc(bytCardIdm, GCHandleType.Pinned);
            cardInformation.CardIdm = Convert.ToUInt32(HandleContainer.CardIdm.AddrOfPinnedObject().ToInt32());

            HandleContainer.CardPmm = GCHandle.Alloc(bytCardPmm, GCHandleType.Pinned);
            cardInformation.CardPmm = Convert.ToUInt32(HandleContainer.CardPmm.AddrOfPinnedObject().ToInt32());

            byte[] bytNumberOfCards = new byte[1] { 0x00 };
            HandleContainer.NumberOfCards = GCHandle.Alloc(bytNumberOfCards, GCHandleType.Pinned);

            bool result = true;
            if (!FeliCaDllWrapper.PollingAndGetCardInformation(ref polling, ref bytNumberOfCards[0], ref cardInformation))
            {
                GetLastErrorTypes(out _felicaLastErrType, out _rwLastErrType);
                result = false;
            }
            else
            {
                // 結果がtrueでも、エラーステータスで再判定(ドライババージョンによってはこれが必用)
                GetLastErrorTypes(out _felicaLastErrType, out _rwLastErrType);
                if (_felicaLastErrType == FeliCaErrorType.FELICA_POLLING_ERROR)
                {
                    if (_rwLastErrType == RwErrorType.RW_CARD_NOT_FOUND)
                    {
                        return false;
                    }
                    // 2009.02.16 ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>S
                    if (_rwLastErrType == RwErrorType.RW_READER_WRITER_DISCONNECTED)
                    {
                        return false;
                    }
                    // 2009.02.16 ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<E
                }

                // 2009.02.16 ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>S
                if (_felicaLastErrType == FeliCaErrorType.FELICA_LIBRARY_NOT_INITIALIZED)
                {
                    return false;
                }
                // 2009.02.16 ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<E
            }
            Array.Reverse(bytCardIdm);
            Array.Reverse(bytCardPmm);
            cardIdm = BitConverter.ToUInt64(bytCardIdm, 0);
            cardPmm = BitConverter.ToUInt64(bytCardPmm, 0);
            return result;
        }
        #endregion

        #region StartPolling・StopPolling /連続ポーリング開始・終了
        /// <summary>
        /// 連続ポーリング開始
        /// </summary>
        /// <param name="interval">ポーリング間隔(ms)</param>
        /// <param name="retryCount">ポーリングのリトライ回数(0指定で無限リトライ)</param>
        public void StartPolling(int interval, int retryCount)
        {
            _pollingRetryCnt = 0;
            _pollingRetryMax = retryCount;
            //_pollingFlg = true;
            _pollingTimer = new System.Threading.Timer(pollingTimer_Tick, null, 0, interval);
        }

        /// <summary>
        /// 連続ポーリングを終了します
        /// </summary>
        public void StopPolling()
        {
            if (_pollingTimer != null)
            {
                _pollingTimer.Dispose();
                _pollingTimer = null;
                //_pollingFlg = false;
            }
        }

        /// <summary>
        /// 連続ポーリングメイン処理(一定間隔で呼び出されます)
        /// </summary>
        /// <param name="state">null</param>
        private void pollingTimer_Tick(object state)
        {
            UInt64 cardIdm, cardPmm;
            _pollingRetryCnt++;

            if (_pollingTimer == null)
                return;

            lock (FeliCaDllWrapper)
            {

                if ((_pollingRetryMax != 0) && (_pollingRetryMax < _pollingRetryCnt))
                {
                    // 指定回数内にカードが見つからなかったとき
                    StopPolling();
                    CallBackDelegate(0, 0, false);
                }
                else
                {
                    if (_pollingTimer == null)
                        return;

                    if (this.PollingAndGetCardInformation(Convert.ToUInt16(FelicaSystemCodes.Any), out cardIdm, out cardPmm))
                    {   // 成功
                        if (_pollingTimer != null)
                        {
                            StopPolling();
                            CallBackDelegate(cardIdm, cardPmm, true);
                        }
                    }
                    else
                    {
                        if (_pollingTimer == null)
                            return;
                        // エラー発生(カードが見つからない以外)
                        if (_rwLastErrType != RwErrorType.RW_CARD_NOT_FOUND)
                        {
                            if (_pollingTimer != null)
                            {
                                StopPolling();
                                CallBackDelegate(0, 0, false);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region felica.dll存在チェック
        /// <summary>
        /// felica.dllを検索
        /// </summary>
        /// <returns></returns>
        private bool FelicaDllExists()
        {
            string directory;
            // 環境変数配下を検査
            foreach (System.Collections.DictionaryEntry de in System.Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine))
            {
                string[] paths = de.Value.ToString().Split(';');
                foreach (string psth in paths)
                {
                    try
                    {
                        directory = psth;
                        // ダブルクォーテーションは取り除く
                        if (directory[0] == '"') directory = directory.Substring(1, directory.Length - 2);
                        if (File.Exists(Path.Combine(directory, "felica.dll")))
                        {
                            _felicaDllExists = true;
                            break;
                        }
                    }
                    catch(Exception ex)
                    {
                        // パスが不正な時はログを落とす
                        TMsgDisp.Show(
                               emErrorLevel.ERR_LEVEL_NODISP,	      // エラーレベル
                               "SFCMN03505CA",						  // アセンブリＩＤまたはクラスＩＤ
                               "FeliCaAcs",							  // プログラム名称
                               "FelicaDllExists",			          // 処理名称
                               TMsgDisp.OPE_CALL,					  // オペレーション
                               ex.Message + " : " + psth,             // メッセージ
                               -1,                                    // ステータス
                               this,	            				  // エラーが発生したオブジェクト
                               MessageBoxButtons.OK,				  // 表示するボタン
                               MessageBoxDefaultButton.Button1);	  // 初期表示ボタン
                    }
                }
            }
            
            if (_felicaDllExists == false)
            {
                _felicaLastErrType = FeliCaErrorType.FELICA_FILE_NOT_FOUND;
                _rwLastErrType = RwErrorType.RW_FILE_NOT_FOUND;
                _lastErrMsg = "felica.dllが見つかりません";
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }

    #region フェリカハンドルコンテナ
    /// <summary>
    /// フェリカハンドルオブジェクト群
    /// </summary>
    class HandleContainer
    {
        public static GCHandle FeliCaSystemCode;
        public static GCHandle CardIdm;
        public static GCHandle CardPmm;
        public static GCHandle NumberOfCards;
        public static GCHandle NumberOfServices;
        public static GCHandle ServiceCodeList;
        public static GCHandle ServiceKeyVersionList;
        public static GCHandle Kar;
        public static GCHandle Kbr;
        public static GCHandle BlockList;
        public static GCHandle WriteBlockData;
        public static GCHandle StatusFlag1;
        public static GCHandle StatusFlag2;
        public static GCHandle ResultNumberOfBlocks;
        public static GCHandle ReadBlockData;
        public static GCHandle AreaCodeList;
        public static GCHandle EndServiceCodeList;
        public static GCHandle CardCommandPacketData;
        public static GCHandle CardResponsePacketData;
        public static GCHandle ResponsePacketLength;
       
        public static void FreeHandle()
        {
            //free handle objects.
            if (FeliCaSystemCode.IsAllocated == true)
            {
                FeliCaSystemCode.Free();
            }
            if (CardIdm.IsAllocated == true)
            {
                CardIdm.Free();
            }
            if (CardPmm.IsAllocated == true)
            {
                CardPmm.Free();
            }
            if (NumberOfCards.IsAllocated == true)
            {
                NumberOfCards.Free();
            }
            if (NumberOfServices.IsAllocated == true)
            {
                NumberOfServices.Free();
            }
            if (ServiceKeyVersionList.IsAllocated == true)
            {
                ServiceKeyVersionList.Free();
            }
            if (ServiceCodeList.IsAllocated == true)
            {
                ServiceCodeList.Free();
            }
            if (Kar.IsAllocated == true)
            {
                Kar.Free();
            }
            if (Kbr.IsAllocated == true)
            {
                Kbr.Free();
            }
            if (BlockList.IsAllocated == true)
            {
                BlockList.Free();
            }
            if (WriteBlockData.IsAllocated == true)
            {
                WriteBlockData.Free();
            }
            if (StatusFlag1.IsAllocated == true)
            {
                StatusFlag1.Free();
            }
            if (StatusFlag2.IsAllocated == true)
            {
                StatusFlag2.Free();
            }
            if (ResultNumberOfBlocks.IsAllocated == true)
            {
                ResultNumberOfBlocks.Free();
            }
            if (ReadBlockData.IsAllocated == true)
            {
                ReadBlockData.Free();
            }
            if (AreaCodeList.IsAllocated == true)
            {
                AreaCodeList.Free();
            }
            if (EndServiceCodeList.IsAllocated == true)
            {
                EndServiceCodeList.Free();
            }
            if (CardCommandPacketData.IsAllocated == true)
            {
                CardCommandPacketData.Free();
            }
            if (CardResponsePacketData.IsAllocated == true)
            {
                CardResponsePacketData.Free();
            }
            if (ResponsePacketLength.IsAllocated == true)
            {
                ResponsePacketLength.Free();
            }
        }
    }
    #endregion
}