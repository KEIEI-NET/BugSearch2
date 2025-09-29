using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Microsoft.Win32;
using System.IO;
using System.Xml;
using Broadleaf.Application.Resources;
using System.Threading;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Diagnostics;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// コンバート対象バージョン管理共通部品
    /// </summary>
    /// <remarks>
    /// <br>Note       : 数値変換解除処理を行うクラスです。</br>
    /// <br>Programmer : 32470 小原 卓也</br>
    /// <br>Date       : 2020/06/15</br>
    /// </remarks>
    public class ConvertDoubleRelease : RemoteDB
    { 
        #region プライベート変数

        #region プロパティで使用

        /// <summary>企業コード</summary>
        private string _enterpriseCode;

        /// <summary>商品コード</summary>
        private string _goodsNo;

        /// <summary>商品メーカーコード</summary>
        private int _goodsMakerCd;

        /// <summary>変換前パラメータ</summary>
        private double _convertSetParam;

        /// <summary>変換情報</summary>
        private ConvertInfoParam _convertInfoParam;

        #endregion // プロパティで使用

        /// <summary>
        /// 設定ファイル名
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00110_Setting.xml";

        /// <summary>
        /// コンバート対象バージョン設定
        /// </summary>
        private ConvertVersionSetting _convertVersionSetting;

        /// <summary>
        /// コンバート対象バージョン管理
        /// </summary>
        private ConvertVersionManager _convertVersionManager;

        /// <summary>
        /// マスタバージョン取得管理
        /// </summary>
        private bool _isGetMstVersion;

        /// <summary>
        /// マスタバージョン変換設定初期化管理
        /// </summary>
        private bool _isMstSettingInit;

        /// <summary>
        /// アセンブリバージョン変換設定初期化管理
        /// </summary>
        private bool _isAsmSettingInit;

        private int _maxRetryCnt;
        private int _waitTime;

        #endregion

        #region 列挙体

        /// <summary>
        /// メソッドの戻りステータス
        /// </summary>
        public enum ReturnStatus
        {
            CT_RETURN_STATUS_OK = 0,
            CT_RETURN_STATUS_ERROR = 9,
            CT_RETURN_STATUS_ERROR_EXP = 1000
        }

        #endregion // 列挙体

        #region 定数
        /// <summary>
        /// リトライ回数初期値
        /// </summary>
        private const int RETRY_DEFAULT_COUNT = 5;

        /// <summary>
        /// リトライ待ち時間初期値
        /// </summary>
        private const int RETRY_DEFAULT_WAIT_TIME = 5000;
        #endregion // 定数

        #region デバッグ用
        /// <summary>
        /// 処理開始（ログ出力）
        /// </summary>
        private const string LOGOUTPUT_INFO_START = "StartProcName:{0},StartTime\t{1}";

        /// <summary>
        /// 処理終了 （ログ出力）
        /// </summary>
        private const string LOGOUTPUT_INFO_END = "ENDProcName:{0},EndTime\t{1}";

        /// <summary>
        /// 処理中 （ログ出力）
        /// </summary>
        private const string LOGOUTPUT_INFO_DETAIL = "ProcName:{0},{1}:{2},ProcTime\t{3}";

        /// <summary>
        /// デバッグログファイル名
        /// </summary>
        private const string logtxt = @"Log\PMCMN00110C.txt";

        /// <summary>
        /// デバッグログ出力パス
        /// </summary>
        private string logpath = string.Empty;

        #endregion // デバッグ用

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConvertDoubleRelease()
        {
            #region デバッグ
            //logpath = Path.Combine(GetCurrentDirectory().TrimEnd('\\'), logtxt);
            //try
            //{
            //    File.AppendAllText(logpath, Environment.NewLine + string.Format(LOGOUTPUT_INFO_START, "ConvertDoubleRelease", DateTime.Now.ToString("HH:mm:ss.fffffff")));
            //}
            //catch
            //{
            //}
            #endregion // デバッグ

            //// 初期値セット
            _enterpriseCode = string.Empty;
            _goodsNo = string.Empty;
            _goodsMakerCd = int.MinValue;
            _convertSetParam = double.MinValue;
            _convertInfoParam = new ConvertInfoParam();
            _convertVersionSetting = new ConvertVersionSetting();
            _convertVersionManager = new ConvertVersionManager();
            _isGetMstVersion = false;
            _isMstSettingInit = false;
            _isAsmSettingInit = false;
            _maxRetryCnt = RETRY_DEFAULT_COUNT;
            _waitTime = RETRY_DEFAULT_WAIT_TIME;
        }

        #endregion // コンストラクタ

        #region プロパティ

        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// 商品メーカーコード
        /// </summary>
        public int GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// <summary>
        /// 商品番号
        /// </summary>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// <summary>
        /// 変換元パラメータ
        /// </summary>
        public double ConvertSetParam
        {
            get { return this._convertSetParam; }
            set { this._convertSetParam = value; }
        }

        /// <summary>
        /// 変換情報
        /// </summary>
        public ConvertInfoParam ConvertInfParam
        {
            get { return this._convertInfoParam; }
            set { this._convertInfoParam = value; }
        }

        #endregion

        #region publicメソッド 既存処理用
        /// <summary>
        /// 初期処理
        /// バージョン情報を取得
        /// 変換判定設定
        /// </summary>
        /// <returns>実行ステータス</returns>
        /// <remarks>
        /// <br>Note       : 初期処理を行います。</br>
        /// <br>Programmer : 32470 小原 卓也</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ReleaseInitLib()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int statusVer = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int retryCnt = 0;

            #region リトライ情報設定

            string fileName = this.InitializeXmlSettings();
            XmlReaderSettings settings = new XmlReaderSettings();

            if (fileName != string.Empty)
            {
                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            if (reader.IsStartElement("RetryCnt"))
                            {
                                _maxRetryCnt = reader.ReadElementContentAsInt();
                            }

                            if (reader.IsStartElement("WaitTime"))
                            {
                                _waitTime = reader.ReadElementContentAsInt();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //ログ出力
                    WriteErrorLogProc(ex, "ConvertDoubleRelease.ReleaseInitLib");
                }
            }
            #endregion // リトライ情報設定

            // 正常終了するまでリトライ回数分リトライする
            while (retryCnt <= _maxRetryCnt)
            {
                // リトライ時waitする
                if (retryCnt > 0)
                {
                    Thread.Sleep(_waitTime);
                }

                try
                {
                    // アセンブリバージョン取得
                    _convertInfoParam.ConvertVersionAsm = _convertVersionManager.ConvertVersionAsm;

                    if (!string.IsNullOrEmpty(_enterpriseCode))
                    {
                        // マスタバージョン情報取得
                        statusVer = this.ConvertVersionRead();
                    }
                    else
                    {
                        // ステータス正常
                        statusVer = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                    }

                    // 各処理正常終了した場合、ステータスを正常終了にする
                    if (statusVer == (int)ReturnStatus.CT_RETURN_STATUS_OK)
                    {
                        status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

                    //ログ出力
                    WriteErrorLogProc(ex, "ConvertDoubleRelease.ReleaseInitLib", status);
                }

                if (status == (int)ReturnStatus.CT_RETURN_STATUS_OK)
                {
                    // 正常終了のためリトライしない
                    break;
                }

                retryCnt += 1;
            }

            return status;
        }

        /// <summary>
        /// 解除処理
        /// </summary>
        /// <returns>実行ステータス</returns>
        /// <remarks>
        /// <br>Note       : 解除処理を行います。</br>
        /// <br>Programmer : 32470 小原 卓也</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ReleaseProc()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;

            // マスタバージョン情報取得
            // 取得済みの場合は再読み込みしない
            this.ConvertVersionRead();

            // 解除処理実行
            status = this.ReleaseProcSetting(_convertInfoParam.ConvertVersionMst);

            return status;
        }

        /// <summary>
        /// 変換処理
        /// </summary>
        /// <returns>実行ステータス</returns>
        /// <remarks>
        /// <br>Note       : 変換処理を行います。</br>
        /// <br>Programmer : 32470 小原 卓也</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ConvertProc()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;

            // マスタバージョン情報取得
            // 取得済みの場合は再読み込みしない
            this.ConvertVersionRead();

            // 変換処理実行
            status = this.ConvertProcSetting(_convertInfoParam.ConvertVersionMst);

            return status;
        }


        /// <summary>
        /// 解除変換処理
        /// </summary>
        /// <returns>実行ステータス</returns>
        /// <remarks>
        /// <br>Note       : 解除変換処理を行います。</br>
        /// <br>             一括更新処理時に呼び出されます。</br>
        /// <br>Programmer : 32470 小原 卓也</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ReleaseConvertProc()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int statusGet = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int statusInit = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;

            try
            {
                // マスタバージョン情報取得
                // 取得済みの場合は再読み込みしない
                statusInit = this.ConvertVersionRead();

                // アセンブリバージョン変換情報初期化
                // 初期化済みの場合は何もしない
                statusGet = this.ConvertVersionSettingInitAsm();

                // 変換パターン
                // ①マスタ、アセンブリバージョンが同一：何もしない
                // ②マスタ、アセンブリバージョンが異なる
                // ②－１マスタバージョン変換済み、アセンブリバージョン未変換：マスタバージョン解除
                // ②－２マスタバージョン変換済み、アセンブリバージョン変換済み：マスタバージョン解除→アセンブリバージョン変換
                // ②－３マスタバージョン未変換、アセンブリバージョン変換済み：アセンブリバージョン変換

                    // マスタ、アセンブリバージョン判定
                    if (_convertInfoParam.ConvertVersionMst != _convertInfoParam.ConvertVersionAsm)
                    {
                        // マスタバージョンとアセンブリバージョンが異なる場合
                        // マスタバージョンが未変換の場合は解除処理実行せず変換前値を返却
                        // ②－１、②－２のマスタバージョン解除にあたる
                        // ②－３の場合は解除処理されず終了する
                        status = this.ReleaseProcSetting(_convertInfoParam.ConvertVersionMst);

                        if (status == (int)ReturnStatus.CT_RETURN_STATUS_OK)
                        {
                            // 解除後の値を変換前値に再設定
                            _convertSetParam = _convertInfoParam.ConvertGetParam;

                            // アセンブリバージョンで変換処理を実行する
                            // アセンブリバージョンが未変換の場合は変換処理実行せず変換前値を返却
                            // ②－２、②－３のアセンブリバージョン変換にあたる
                            // ②－１の場合は変換処理されず終了する
                            status = this.ConvertProcSetting(_convertInfoParam.ConvertVersionAsm);
                        }
                    }

            }
            catch (Exception ex)
            {
                status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

                //ログ出力
                WriteErrorLogProc(ex, "ConvertDoubleRelease.ReleaseConvertProc", status);

                // 例外時は変換前値を返却
                _convertInfoParam.ConvertGetParam = _convertSetParam;
            }

            return status;
        }

        #endregion // publicメソッド

        #region publicメソッド 一括更新用
        /// <summary>
        /// 初期処理
        /// 認証情報、バージョン情報を取得
        /// 一括更新用
        /// </summary>
        /// <returns>実行ステータス</returns>
        /// <remarks>
        /// <br>Note       : 一括更新用初期処理を行います。</br>
        /// <br>Programmer : 32470 小原 卓也</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ReleaseInitLibLump()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int statusVer = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int retryCnt = 0;

            #region リトライ情報設定

            string fileName = this.InitializeXmlSettings();
            XmlReaderSettings settings = new XmlReaderSettings();

            if (fileName != string.Empty)
            {
                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            if (reader.IsStartElement("RetryCnt"))
                            {
                                _maxRetryCnt = reader.ReadElementContentAsInt();
                            }

                            if (reader.IsStartElement("WaitTime"))
                            {
                                _waitTime = reader.ReadElementContentAsInt();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //ログ出力
                    WriteErrorLogProc(ex, "ConvertDoubleRelease.ReleaseInitLib");
                }
            }

            #endregion // リトライ情報設定

            // 正常終了するまでリトライ回数分リトライする
            while (retryCnt <= _maxRetryCnt)
            {
                // リトライ時waitする
                if (retryCnt > 0)
                {
                    Thread.Sleep(_waitTime);
                }

                try
                {
                    Directory.SetCurrentDirectory(this.GetCurrentDirectory());
                    // アセンブリバージョン取得
                    _convertInfoParam.ConvertVersionAsm = _convertVersionManager.ConvertVersionAsm;

                    // マスタバージョン情報取得
                    statusVer = this.ConvertVersionReadLump();

                    // 各処理正常終了した場合、ステータスを正常終了にする
                    if (statusVer == (int)ReturnStatus.CT_RETURN_STATUS_OK)
                    {
                        status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

                    //ログ出力
                    WriteErrorLogProc(ex, "ConvertDoubleRelease.ReleaseInitLibLump", status);
                }

                if (status == (int)ReturnStatus.CT_RETURN_STATUS_OK)
                {
                    // 正常終了のためリトライしない
                    break;
                }

                retryCnt += 1;
            }

            return status;
        }
        #endregion

        #region privateメソッド

        /// <summary>
        /// 解除処理呼び出し
        /// </summary>
        /// <param name="convertSetVersion">解除処理実行バージョン</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 解除処理を呼び出します。</br>
        /// <br>Programmer : 32470 小原 卓也</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private int ReleaseProcSetting(int convertSetVersion)
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;

            try
            {
                // 変換済みバージョンの場合解除処理実施
                if (convertSetVersion != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                {
                    // パラメータ設定
                    _convertVersionSetting.GoodsMakerCd = _goodsMakerCd;
                    _convertVersionSetting.GoodsNo = _goodsNo;
                    _convertVersionSetting.ConvertSetParam = _convertSetParam;
                    _convertVersionSetting.ConvertSetVersion = convertSetVersion;

                    // 解除処理
                    status = _convertVersionSetting.ReleaseProc();

                    if (status == (int)ReturnStatus.CT_RETURN_STATUS_OK)
                    {
                        _convertInfoParam.ConvertGetParam = _convertVersionSetting.ConvertGetParam;

                        status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                    }
                    else
                    {
                        // 変換失敗時は変換前値を返却
                        _convertInfoParam.ConvertGetParam = _convertSetParam;

                        status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
                    }
                }
                else
                {
                    // 変換していないバージョンの場合そのまま返却
                    _convertInfoParam.ConvertGetParam = _convertSetParam;

                    status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                }
            }
            catch (Exception ex)
            {
                //ログ出力
                WriteErrorLogProc(ex, "ConvertDoubleRelease.ReleaseProcSetting");

                // 例外時は変換前値を返却
                _convertInfoParam.ConvertGetParam = _convertSetParam;
                status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;
            }

            return status;
        }

        /// <summary>
        /// 変換処理呼び出し
        /// </summary>
        /// <param name="convertSetVersion">変換処理実行バージョン</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 変換処理を呼び出します。</br>
        /// <br>Programmer : 32470 小原 卓也</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private int ConvertProcSetting(int convertSetVersion)
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;

            try
            {
                // 変換済みバージョンの場合変換処理実施
                if (convertSetVersion != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                {
                    // パラメータ設定
                    _convertVersionSetting.GoodsMakerCd = _goodsMakerCd;
                    _convertVersionSetting.GoodsNo = _goodsNo;
                    _convertVersionSetting.ConvertSetParam = _convertSetParam;
                    _convertVersionSetting.ConvertSetVersion = convertSetVersion;

                    // 変換処理
                    status = _convertVersionSetting.ConvertProc();

                    if (status == (int)ReturnStatus.CT_RETURN_STATUS_OK)
                    {
                        _convertInfoParam.ConvertGetParam = _convertVersionSetting.ConvertGetParam;

                        status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                    }
                    else
                    {
                        // 変換失敗時は変換前値を返却
                        _convertInfoParam.ConvertGetParam = _convertSetParam;

                        status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
                    }
                }
                else
                {
                    // 変換していないバージョンの場合そのまま返却
                    _convertInfoParam.ConvertGetParam = _convertSetParam;

                    status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                }

                status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
            }
            catch (Exception ex)
            {
                //ログ出力
                WriteErrorLogProc(ex, "ConvertDoubleRelease.ConvertProcSetting");

                // 例外時は変換前値を返却
                _convertInfoParam.ConvertGetParam = _convertSetParam;
                status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;
            }

            return status;
        }

        /// <summary>
        /// コンバート対象バージョン取得
        /// リモートクラス呼び出し用
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : リモートクラスから呼び出された場合のコンバート対象バージョンを取得します。</br>
        /// <br>Programmer : 32470 小原 卓也</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private int ConvertVersionRead()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int statusDB = (int)ConstantManagement.DB_Status.ctDB_ERROR; // バージョン情報取得ステータス
            int statusVer = (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_ERROR; // バージョン管理情報初期化ステータス
            ConvObjVerMngDB convObjVerMngDB;
            object outConvObjVerMng;
            ConvObjVerMngWork paraConvObjVerMngWork;

            if (!_isGetMstVersion)
            {
                try
                {
                    // バージョン情報取得未実行時のみ実行
                    // 検索パラメータ設定
                    paraConvObjVerMngWork = new ConvObjVerMngWork();
                    paraConvObjVerMngWork.EnterpriseCode = _enterpriseCode;

                    // 検索処理
                    convObjVerMngDB = new ConvObjVerMngDB();

                    statusDB = convObjVerMngDB.Search(out outConvObjVerMng, (object)paraConvObjVerMngWork);

                    switch (statusDB)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            foreach (ConvObjVerMngWork listConvObjVerMng in (ArrayList)outConvObjVerMng)
                            {
                                if (!string.IsNullOrEmpty(listConvObjVerMng.ConvertObjVer))
                                {
                                    _convertInfoParam.ConvertVersionMst = int.Parse(listConvObjVerMng.ConvertObjVer);
                                }
                            }

                            // 2回目以降は実施しない
                            _isGetMstVersion = true;
                            break;

                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                            // 0件も正常（リリース後初回実行）
                            // 2回目以降は実施しない
                            _isGetMstVersion = true;
                            break;

                        default:
                            // 取得失敗
                            break;
                    }

                    // マスタバージョン管理情報初期化
                    // 初期化済みの場合は何もしない
                    statusVer = this.ConvertVersionSettingInitMst();
                }
                catch (Exception ex)
                {
                    status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

                    //ログ出力
                    WriteErrorLogProc(ex, "ConvertDoubleRelease.ConvertVersionRead", status);
                }

                // 各処理成否判定
                if (_isGetMstVersion && statusVer == (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_OK)
                {
                    status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                }
                else
                {
                    status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
                }
            }
            else
            {
                // 初期化済みの場合は正常
                status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
            }

            return status;
        }

        /// <summary>
        /// マスタコンバート対象バージョン取得
        /// 一括更新用
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 一括更新用コンバート対象バージョンを取得します。</br>
        /// <br>Programmer : 32470 小原 卓也</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private int ConvertVersionReadLump()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int statusDB = (int)ConstantManagement.DB_Status.ctDB_ERROR; // バージョン情報取得ステータス
            IConvObjVerMngDB iConvObjVerMngDB;
            object outConvObjVerMng;
            ConvObjVerMngWork paraConvObjVerMngWork;

            // バージョン情報取得未実行時のみ実行
            if (!_isGetMstVersion)
            {
                try
                {
                    // 検索パラメータ設定
                    paraConvObjVerMngWork = new ConvObjVerMngWork();
                    paraConvObjVerMngWork.EnterpriseCode = _enterpriseCode;

                    // 検索処理
                    iConvObjVerMngDB = MediationConvObjVerMngDB.GetConvObjVerMngDB();

                    statusDB = iConvObjVerMngDB.Search(out outConvObjVerMng, (object)paraConvObjVerMngWork);

                    switch (statusDB)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            foreach (ConvObjVerMngWork listConvObjVerMng in (ArrayList)outConvObjVerMng)
                            {
                                if (!string.IsNullOrEmpty(listConvObjVerMng.ConvertObjVer))
                                {
                                    _convertInfoParam.ConvertVersionMst = int.Parse(listConvObjVerMng.ConvertObjVer);
                                }
                            }

                            // 2回目以降は実施しない
                            _isGetMstVersion = true;
                            break;

                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                            // 0件も正常（リリース後初回実行）
                            // 2回目以降は実施しない
                            _isGetMstVersion = true;
                            break;

                        default:
                            // 取得失敗
                            break;
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

                    //ログ出力
                    WriteErrorLogProc(ex, "ConvertDoubleRelease.ConvertVersionReadLump", status);
                }

                // 各処理成否判定
                if (_isGetMstVersion)
                {
                    status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                }
            }
            else
            {
                // 初期化済みの場合は正常
                status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
            }

            return status;
        }

        /// <summary>
        /// マスタバージョン変換設定初期化
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : マスタバージョン変換設定を初期化します。</br>
        /// <br>Programmer : 32470 小原 卓也</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private int ConvertVersionSettingInitMst()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int statusVer = (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_ERROR;

            try
            {
                if (!_isMstSettingInit)
                {
                    // マスタバージョンが変換済みバージョンの場合のみ実施
                    if (_convertInfoParam.ConvertVersionMst != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                    {
                        // バージョン管理情報初期化
                        _convertVersionSetting.EnterpriseCode = _enterpriseCode;
                        _convertVersionSetting.ConvertSetVersion = _convertInfoParam.ConvertVersionMst;
                        statusVer = _convertVersionSetting.VersionInitLib();
                    }
                    else
                    {
                        // 未変換の場合何もせず正常
                        statusVer = (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_OK;
                    }

                    if (statusVer == (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_OK)
                    {
                        // 正常終了した場合、再取得しない
                        _isMstSettingInit = true;
                        status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

                //ログ出力
                WriteErrorLogProc(ex, "ConvertDoubleRelease.ConvertVersionReadMst", status);
            }

            return status;
        }

        /// <summary>
        /// アセンブリバージョン変換設定初期化
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : アセンブリバージョン変換設定を初期化します。</br>
        /// <br>Programmer : 32470 小原 卓也</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private int ConvertVersionSettingInitAsm()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;
            int statusVer = (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_ERROR;

            try
            {
                // 未初期化の場合
                if (!_isAsmSettingInit)
                {
                    // アセンブリバージョンが変換済みバージョンの場合のみ実施
                    if (_convertInfoParam.ConvertVersionAsm != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                    {
                        // バージョン管理情報初期化
                        _convertVersionSetting.EnterpriseCode = _enterpriseCode;
                        _convertVersionSetting.ConvertSetVersion = _convertInfoParam.ConvertVersionAsm;
                        statusVer = _convertVersionSetting.VersionInitLib();
                    }
                    else
                    {
                        // 未変換の場合何もせず正常
                        statusVer = (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_OK;
                    }

                    if (statusVer == (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_OK)
                    {
                        // 正常終了した場合、再取得しない
                        _isAsmSettingInit = true;
                        status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConvertVersionSetting.ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;

                //ログ出力
                WriteErrorLogProc(ex, "ConvertDoubleRelease.ConvertVersionSettingInitAsm", status);
            }

            return status;
        }

        /// <summary>
        /// XMLファイル設定情報取得処理
        /// ファイルが存在しない場合は空文字を戻す
        /// </summary>
        /// <returns>フルパスファイル名</returns>
        /// <remarks>
        /// <br>Note       : XMLファイル設定情報を取得します。</br>
        /// <br>Programmer : 32470 小原 卓也</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // カレントディレクトリ取得
                homeDir = this.GetCurrentDirectory();

                // ディレクトリ情報にXMLファイル名を連結
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // ファイルが存在しない場合は空白にする
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                //ログ出力
                WriteErrorLogProc(ex, "ConvertDoubleRelease.InitializeXmlSettings");
            }

            return path;
        }

        /// <summary>
        /// カレントフォルダのパス取得
        /// フォルダが存在しない場合は空文字を戻す
        /// </summary>
        /// <returns>フルパスファイル名</returns>
        /// <remarks>
        /// <br>Note       : カレントフォルダのパスを取得します。</br>
        /// <br>Programmer : 32470 小原 卓也</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML格納ディレクトリ取得
            try
            {
                // dll格納パスを初期ディレクトリとする
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'); // 末尾の「\」は常になし

                // レジストリ情報よりUSER_APのキー情報を取得
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // レジストリ情報を取得できない場合は初期ディレクトリ
                        // 運用上ありえないケース
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
                // 運用上ありえないケース
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //ログ出力
                WriteErrorLogProc(ex, "ConvertDoubleRelease.GetCurrentDirectory");

                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }

            return homeDir;
        }

        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="errorText"></param>
        /// <remarks>
        /// <br>Note       : ログ出力を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private void WriteErrorLogProc(string errorText)
        {
            try
            {
                base.WriteErrorLog(errorText);
            }
            catch
            {
            }
            finally
            {
            }
        }

        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="errorText"></param>
        /// <remarks>
        /// <br>Note       : ログ出力を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private void WriteErrorLogProc(Exception ex, string errorText)
        {
            try
            {
                base.WriteErrorLog(ex, errorText);
            }
            catch
            {
            }
            finally
            {
            }
        }

        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="errorText"></param>
        /// <param name="status"></param>
        /// <remarks>
        /// <br>Note       : ログ出力を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private void WriteErrorLogProc(Exception ex, string errorText, int status)
        {
            try
            {
                base.WriteErrorLog(ex, errorText, status);
            }
            catch
            {
            }
            finally
            {
            }
        }

        #endregion // privateメソッド

        # region Dispose
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        public void Dispose()
        {
            // インスタンス化したオブジェクトの初期化
            _convertInfoParam = null;
            _convertVersionSetting = null;
            _convertVersionManager = null;
            _isGetMstVersion = false;
            _isMstSettingInit = false;

            #region デバッグ
            //try
            //{
            //    File.AppendAllText(logpath, Environment.NewLine + string.Format(LOGOUTPUT_INFO_END, "Dispose", DateTime.Now.ToString("HH:mm:ss.fffffff")));
            //}
            //catch
            //{
            //}
            #endregion // デバッグ
        }
        #endregion

    }

    public class ConvertInfoParam
    {
        #region プライベート変数

        #region プロパティで使用

        /// <summary>マスタ変換バージョン</summary>
        private int _convertVersionMst;

        /// <summary>アセンブリ変換バージョン</summary>
        private int _convertVersionAsm;

        /// <summary>変換後パラメータ</summary>
        private double _convertGetParam;

        #endregion // プロパティで使用

        #endregion

        #region コンストラクタ

        /// <summary>
        /// 
        /// </summary>
        public ConvertInfoParam()
        {
            //// 初期値セット
            _convertVersionMst = (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE;
            _convertVersionAsm = (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE;
            _convertGetParam = double.MinValue;
        }

        #endregion // コンストラクタ

        #region プロパティ

        /// <summary>
        /// マスタ変換バージョン
        /// </summary>
        public int ConvertVersionMst
        {
            get { return _convertVersionMst; }
            set { _convertVersionMst = value; }
        }

        /// <summary>
        /// アセンブリ変換バージョン
        /// </summary>
        public int ConvertVersionAsm
        {
            get { return _convertVersionAsm; }
            set { _convertVersionAsm = value; }
        }

        // 変換後パラメータ
        public double ConvertGetParam
        {
            get { return _convertGetParam; }
            set { _convertGetParam = value; }
        }
        #endregion // プロパティ
    }
}
