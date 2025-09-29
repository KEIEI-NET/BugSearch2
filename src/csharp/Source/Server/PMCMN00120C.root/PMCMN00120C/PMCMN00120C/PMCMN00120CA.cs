using System;
using Broadleaf.Application.Remoting;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// コンバート対象バージョン管理部品
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象バージョンよって変換処理するクラスです。</br>
    /// <br>Programmer : </br>
    /// <br>Date       : 2020/06/15</br>
    /// </remarks>
    public class ConvertVersionSetting : RemoteDB
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

        /// <summary>変換後パラメータ</summary>
        private double _convertGetParam;

        /// <summary>変換バージョン</summary>
        private int _convertSetVersion;

        #endregion // プロパティで使用

        /// <summary>変換解除実行クラス</summary>
        private ExeConvert _exeConvert;

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

        /// <summary>
        /// 変換バージョン
        /// </summary>
        public enum ConvertVersion
        {
            CT_CONVERT_VERSION_NONE = 0,
            CT_CONVERT_VERSION_1 = 1,
            CT_CONVERT_VERSION_2 = 2,
            CT_CONVERT_VERSION_3 = 3
        }

        /// <summary>
        /// 処理種別
        /// 0:解除、1:変換
        /// </summary>
        public enum ProcCls
        {
            CT_PROC_RELEASE = 0,
            CT_PROC_CONVERT = 1
        }

        #endregion // 定数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConvertVersionSetting()
        {
            //// 初期値セット
            _enterpriseCode = string.Empty;
            _goodsNo = string.Empty;
            _goodsMakerCd = int.MinValue;
            _convertSetParam = int.MinValue;
            _convertGetParam = int.MinValue;
            _convertSetVersion = (int)ConvertVersion.CT_CONVERT_VERSION_NONE;
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
        /// 変換前パラメータ
        /// </summary>
        public double ConvertSetParam
        {
            get { return this._convertSetParam; }
            set { this._convertSetParam = value; }
        }

        /// <summary>
        /// 変換後パラメータ
        /// </summary>
        public double ConvertGetParam
        {
            get { return this._convertGetParam; }
            set { this._convertGetParam = value; }
        }

        /// <summary>
        /// 変換バージョン
        /// </summary>
        public int ConvertSetVersion
        {
            get { return this._convertSetVersion; }
            set { this._convertSetVersion = value; }
        }

        #endregion

        #region publicメソッド
        /// <summary>
        /// 初期処理
        /// </summary>
        /// <returns>実行ステータス</returns>
        /// <remarks>
        /// <br>Note       : 初期処理を行います。</br>
        /// <br>Programmer : </br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int VersionInitLib()
        {
            int status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR;

            try
            {
                // 変換部品の初期化
                switch (_convertSetVersion)
                {
                    case (int)ConvertVersion.CT_CONVERT_VERSION_1:
                        _exeConvert = new ExeConvert();
                        break;

                    case (int)ConvertVersion.CT_CONVERT_VERSION_2:
                        // 未実装
                        break;

                    case (int)ConvertVersion.CT_CONVERT_VERSION_3:
                        // 未実装
                        break;

                    default:
                        break;
                }

                status = (int)ReturnStatus.CT_RETURN_STATUS_OK;
            }
            catch (Exception ex)
            {
                //ログ出力
                WriteErrorLogProc(ex, "ConvertVersionSetting.VersionInitLib");
                status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;
            }

            return status;
        }

        /// <summary>
        /// 解除処理
        /// </summary>
        /// <returns>実行ステータス</returns>
        /// <remarks>
        /// <br>Note       : 数値変換解除処理を行います。</br>
        /// <br>Programmer : </br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ReleaseProc()
        {
            int status = (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_OK;

            // 自変換後値の初期化
            _convertGetParam = int.MinValue;

            try
            {
                // バージョンで解除方式を分岐する
                switch (_convertSetVersion)
                {
                    case (int)ConvertVersion.CT_CONVERT_VERSION_NONE:
                        // 変換を行っていないため、受け取った値を返却
                        _convertGetParam = _convertSetParam;
                        break;

                    case (int)ConvertVersion.CT_CONVERT_VERSION_1:
                        // バージョン１の解除処理
                        // パラメータ設定
                        _exeConvert.EnterpriseCode = _enterpriseCode;
                        _exeConvert.GoodsMakerCd = _goodsMakerCd;
                        _exeConvert.GoodsNo = _goodsNo;
                        _exeConvert.ConvertSetParam = _convertSetParam;

                        _exeConvert.ConvertGetParam = int.MinValue;

                        // 解除処理
                        status = _exeConvert.ExecuteConvert((int)ProcCls.CT_PROC_RELEASE);

                        if (status == (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_ERROR_EXP)
                        {
                            // パラメータ再設定
                            _exeConvert.EnterpriseCode = _enterpriseCode;
                            _exeConvert.GoodsMakerCd = _goodsMakerCd;
                            _exeConvert.GoodsNo = _goodsNo;
                            _exeConvert.ConvertSetParam = _convertSetParam;

                            _exeConvert.ConvertGetParam = int.MinValue;

                            // 価格変換されてない場合直接呼出し
                            status = _exeConvert.ExecuteConvertDirect((int)ProcCls.CT_PROC_RELEASE);
                        }

                        if (status == (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_OK)
                        {
                            // 解除値設定
                            _convertGetParam = _exeConvert.ConvertGetParam;
                        }

                        break;

                    case (int)ConvertVersion.CT_CONVERT_VERSION_2:
                        // バージョン２の解除処理

                        // 未実装のため、受け取った値を返却
                        _convertGetParam = _convertSetParam;

                        break;

                    case (int)ConvertVersion.CT_CONVERT_VERSION_3:
                        // バージョン３の解除処理

                        // 未実装のため、受け取った値を返却
                        _convertGetParam = _convertSetParam;

                        break;

                    default:
                        status = (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_ERROR;
                        _exeConvert.WriteErrorLogProc("ERR ConvertVersionSetting.ReleaseProc _convertSetVersion:" + _convertSetVersion.ToString());
                        _convertGetParam = _convertSetParam;
                        break;
                }
            }
            catch (Exception ex)
            {
                //ログ出力
                _exeConvert.WriteErrorLogProc(ex, "EXP ConvertVersionSetting.ReleaseProc _convertSetVersion:" + _convertSetVersion.ToString());

                status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;
            }

            // 返り値は必要
            return status;
        }

        /// <summary>
        /// 変換処理
        /// </summary>
        /// <returns>実行ステータス</returns>
        /// <remarks>
        /// <br>Note       : 数値変換解除処理を行います。</br>
        /// <br>Programmer : </br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public int ConvertProc()
        {
            int status = (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_OK;

            // 自変換後値の初期化
            _convertGetParam = int.MinValue;

            try
            {
                // バージョンで変換方式を分岐する
                switch (_convertSetVersion)
                {
                    case (int)ConvertVersion.CT_CONVERT_VERSION_NONE:
                        // 変換を行っていないため、受け取った値を返却
                        _convertGetParam = _convertSetParam;
                        break;

                    case (int)ConvertVersion.CT_CONVERT_VERSION_1:
                        // バージョン１の変換処理
                        // パラメータ設定
                        _exeConvert.EnterpriseCode = _enterpriseCode;
                        _exeConvert.GoodsMakerCd = _goodsMakerCd;
                        _exeConvert.GoodsNo = _goodsNo;
                        _exeConvert.ConvertSetParam = _convertSetParam;

                        _exeConvert.ConvertGetParam = int.MinValue;

                        // 変換処理
                        status = _exeConvert.ExecuteConvert((int)ProcCls.CT_PROC_CONVERT);

                        if (status == (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_ERROR_EXP)
                        {
                            // パラメータ再設定
                            _exeConvert.EnterpriseCode = _enterpriseCode;
                            _exeConvert.GoodsMakerCd = _goodsMakerCd;
                            _exeConvert.GoodsNo = _goodsNo;
                            _exeConvert.ConvertSetParam = _convertSetParam;

                            _exeConvert.ConvertGetParam = int.MinValue;

                            // 価格変換されてない場合直接呼出し
                            _exeConvert.ExecuteConvertDirect((int)ProcCls.CT_PROC_CONVERT);
                        }

                        if (status == (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_OK)
                        {
                            // 変換値設定
                            _convertGetParam = _exeConvert.ConvertGetParam;
                        }

                        break;

                    case (int)ConvertVersion.CT_CONVERT_VERSION_2:
                        // バージョン２の変換処理

                        // 未実装のため、受け取った値を返却
                        _convertGetParam = _convertSetParam;

                        break;

                    case (int)ConvertVersion.CT_CONVERT_VERSION_3:
                        // バージョン３の変換処理

                        // 未実装のため、受け取った値を返却
                        _convertGetParam = _convertSetParam;

                        break;

                    default:
                        status = (int)ConvertVersionSettingOne.ReturnStatus.CT_RETURN_STATUS_ERROR;
                        _exeConvert.WriteErrorLogProc("ERR ConvertVersionSetting.ConvertProc _convertSetVersion:" + _convertSetVersion.ToString());
                        _convertGetParam = _convertSetParam;
                        break;
                }
            }
            catch (Exception ex)
            {
                //ログ出力
                _exeConvert.WriteErrorLogProc(ex, "EXP ConvertVersionSetting.ConvertProc _convertSetVersion:" + _convertSetVersion.ToString());

                status = (int)ReturnStatus.CT_RETURN_STATUS_ERROR_EXP;
            }

            return status;
        }
        
        #endregion // publicメソッド

        #region privateメソッド
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
        #endregion // privateメソッド
    }
}
