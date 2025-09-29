//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＢＬコード層別変換処理
// プログラム概要   : ＢＬコード層別変換処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2010/01/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 :
// 修 正 日              修正内容 :
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Text;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ＢＬコード層別変換処理クラス
    /// </summary>
    /// <remarks>
    /// Note       : ＢＬコード層別変換処理です。<br />
    /// Programmer : 呉元嘯<br />
    /// Date       : 2010/01/11<br />
    /// </remarks>
    public class BlCodeLevelChangeAcs
    {
        # region ■ Constructor ■
        /// <summary>
        /// ＢＬコード層別変換処理アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : ＢＬコード層別変換処理アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        public BlCodeLevelChangeAcs()
        {
        }
        # endregion ■ Constructor ■

        #region ■ Const Memebers ■
        // 画面機能ID
        private const string PROGRAM_ID = "PMKHN09280UA";
        // 画面機能名称
        private const string PROGRAM_NAME = "ＢＬコード層別変換処理";

        //掛率パラメータファイル
        private const string INI_FILE_RATE = "PMCV1200.INI";
        //掛率パラメータＡセクション名
        private const string INI_FILE_RATE_SECTION_A = "D3018";
        //掛率パラメータＢセクション名
        private const string INI_FILE_RATE_SECTION_B = "D3150";
        //掛率パラメータＣセクション名
        private const string INI_FILE_RATE_SECTION_C = "D3020";

        //商品パラメータファイル
        private const string INI_FILE_GOODS = "PMCV1100.INI";
        //商品パラメータＡセクション名
        private const string INI_FILE_GOODS_SECTION_A = "D3150";
        //商品パラメータＢセクション名
        private const string INI_FILE_GOODS_SECTION_B = "D3010";
        //商品パラメータＣセクション名
        private const string INI_FILE_GOODS_SECTION_C = "D3020";

        //部位パラメータファイル
        private const string INI_FILE_PARTS = "PMCV1160.INI";
        //部位パラメータセクション名
        private const string INI_FILE_PARTS_SECTION_A = "D3020";

        //優良設定パラメータファイル
        private const string INI_FILE_EXCELLENTSET = "PMCV1180.INI";
        //優良設定パラメータＡセクション名
        private const string INI_FILE_EXCELLENTSET_SECTION_A = "D3020";
        //優良設定パラメータＢセクション名
        private const string INI_FILE_EXCELLENTSET_SECTION_B = "PM8660";
        //優良設定パラメータＣセクション名
        private const string INI_FILE_EXCELLENTSET_SECTION_C = "PM0076";

        #endregion ■ Const Memebers ■

        # region ■ Private Members ■

        // ＢＬコード層別変換処理インタフェース
        private IDataBLGoodsRateRankConvertDB _iDataBLGoodsRateRankConvertDB;

        # endregion ■ Private Members ■

        #region ■ Private Method
        #region ■ ＢＬコード層別変換処理
        #region ◎ ＢＬコード層別変換処理
        /// <summary>
        /// ＢＬコード層別変換処理
        /// </summary>
        /// <param name="iniFilePass">INIファイルパス</param>
        /// <param name="logFilePass">LOGファイルパス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        public int Update(string iniFilePass, string logFilePass, out string errMsg)
        {
            errMsg = string.Empty;
            return this.UpdateProc(iniFilePass, logFilePass, ref errMsg);
        }

        /// <summary>
        ///ＢＬコード層別変換処理
        /// </summary>
        /// <param name="iniFilePass">INIファイルパス</param>
        /// <param name="logFilePass">LOGファイルパス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private int UpdateProc(string iniFilePass, string logFilePass,  ref string errMsg)
        {
            // 全てテーブル処理後の状態
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            ArrayList rateFile_A = null;
            ArrayList rateFile_B = null;
            ArrayList rateFile_C = null;
            ArrayList goodsFile_A = null;
            ArrayList goodsFile_B = null;
            ArrayList goodsFile_C = null;
            ArrayList partsFile = null;
            ArrayList excellentSetFile_A = null;
            ArrayList excellentSetFile_B = null;
            ArrayList excellentSetFile_C = null;
            // INIファイル読み込み
            if (!ReadIniFile(iniFilePass, out rateFile_A, out rateFile_B, out rateFile_C, out goodsFile_A, 
                out goodsFile_B, out goodsFile_C, out partsFile, out excellentSetFile_A, out excellentSetFile_B, out excellentSetFile_C))
            {
                return status;
            }
            // 操作履歴ログ定義
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            string logFileName = string.Empty;

            // ＢＬコード層別変換処理インタフェース
            _iDataBLGoodsRateRankConvertDB = (IDataBLGoodsRateRankConvertDB)MediationDataBLGoodsRateRankConvertDB.GetDataBLGoodsRateRankConvertDB();
            object retList = null;

            // Remote:ＢＬコード層別変換処理
            try
            {
                logFileName = logFilePass + "\\LOG" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
 + ".CSV";
                object _rateFile_AObj = rateFile_A as object;
                object _rateFile_BObj = rateFile_B as object;
                object _rateFile_CObj = rateFile_C as object;
                object _goodsFile_AObj = goodsFile_A as object;
                object _goodsFile_BObj = goodsFile_B as object;
                object _goodsFile_CObj = goodsFile_C as object;
                object _partsFileObj = partsFile as object;
                object _excellentSetFile_AObj = excellentSetFile_A as object;
                object _excellentSetFile_BObj = excellentSetFile_B as object;
                object _excellentSetFile_CObj = excellentSetFile_C as object;
                status = _iDataBLGoodsRateRankConvertDB.Update(LoginInfoAcquisition.EnterpriseCode, _rateFile_AObj, _rateFile_BObj, _rateFile_CObj, _goodsFile_AObj, _goodsFile_BObj, _goodsFile_CObj, _partsFileObj, _excellentSetFile_AObj, _excellentSetFile_BObj, _excellentSetFile_CObj, out retList, out errMsg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // 操作履歴ログの書き込み
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "正常終了しました。", string.Empty);
                    // 処理ログファイルの書き込み
                    ArrayList al = retList as ArrayList;
                    if (al == null)
                    {
                        al = new ArrayList();
                    }
                    if (al.Count > 0)
                    {
                        WriteCSV(al, false, logFileName);
                    }
                }
                else
                {
                    // 操作履歴ログの書き込み
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "エラーが発生しました。(" + status.ToString() + ")", string.Empty);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message.ToString();
            }
            return status;
        }
        #endregion

        #region ◎ INIファイル読み込み処理
        /// <summary>
        ///INIファイル読み込み
        /// </summary>
        /// <param name="iniFilePass">INIファイルパス</param>
        /// <param name="excellentSetFile_A">優良設定パラメータリストＡ</param>
        /// <param name="excellentSetFile_B">優良設定パラメータリストＢ</param>
        /// <param name="excellentSetFile_C">優良設定パラメータリストＣ</param>
        /// <param name="goodsFile_A">商品パラメータリストＡ</param>
        /// <param name="goodsFile_B">商品パラメータリストＢ</param>
        /// <param name="goodsFile_C">商品パラメータリストＣ</param>
        /// <param name="partsFile">部位パラメータのリスト</param>
        /// <param name="rateFile_A">掛率パラメータリストＡ</param>
        /// <param name="rateFile_B">掛率パラメータリストＢ</param>
        /// <param name="rateFile_C">掛率パラメータリストＣ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : INIファイル読み込みを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private bool ReadIniFile(string  iniFilePass, out ArrayList rateFile_A, out ArrayList rateFile_B, out ArrayList rateFile_C, out ArrayList goodsFile_A,
            out ArrayList goodsFile_B, out ArrayList goodsFile_C, out ArrayList partsFile, out ArrayList excellentSetFile_A, out ArrayList excellentSetFile_B, out ArrayList excellentSetFile_C)
        {
            //掛率パラメータＡ、Ｂ、Ｃの各リスト
            rateFile_A = new ArrayList();
            rateFile_B = new ArrayList();
            rateFile_C = new ArrayList();
            //商品パラメータＡ、Ｂ、Ｃの各リスト
            goodsFile_A = new ArrayList();
            goodsFile_B = new ArrayList();
            goodsFile_C = new ArrayList();
            //部位パラメータのリスト
            partsFile = new ArrayList();
            //優良設定パラメータＡ、Ｂ、Ｃの各リスト
            excellentSetFile_A = new ArrayList();
            excellentSetFile_B = new ArrayList();
            excellentSetFile_C = new ArrayList();
            string iniRateFile = iniFilePass + "\\" + INI_FILE_RATE;
            string iniGoodsFilee = iniFilePass + "\\" + INI_FILE_GOODS;
            string iniPartsFile = iniFilePass + "\\" + INI_FILE_PARTS;
            string iniExcellentSetFile = iniFilePass + "\\" + INI_FILE_EXCELLENTSET;

            bool status = true;
            // 掛率パラメータ読む
            if (!ReadRateParamFile(iniRateFile, ref rateFile_A, ref rateFile_B, ref rateFile_C))
            {
                status = false;
                return false;
            }
            //商品パラメータ読む
            else if (!ReadGoodsParamFile(iniGoodsFilee, ref goodsFile_A, ref goodsFile_B, ref goodsFile_C))
            {
                status = false;
                return false;
            }
            //部位パラメータ読む
            else if (!ReadPartsParamFile(iniPartsFile, ref partsFile))
            {
                status = false;
                return false;
            }
            //優良設定パラメータ読む
            else if (!ReadExcellentSetParamFile(iniExcellentSetFile, ref excellentSetFile_A, ref excellentSetFile_B, ref excellentSetFile_C))
            {
                status = false;
                return false;
            }
            return status;
        }

        /// <summary>
        ///INIファイル読み込み
        /// </summary>
        /// <param name="file">INIファイルパス</param>
        /// <param name="file_A">掛率パラメータリストＡ</param>
        /// <param name="file_B">掛率パラメータリストＢ</param>
        /// <param name="file_C">掛率パラメータリストＣ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : INIファイル読み込みを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private bool ReadRateParamFile(string file, ref ArrayList file_A, ref ArrayList file_B, ref ArrayList file_C)
        {
            bool status = true;
            StreamReader sr = null;
            string line = string.Empty;
            string tempSection = string.Empty;
            string errMess = string.Empty;
            // VALUEリスト
            ArrayList valueList = new ArrayList();
            try
            {
                sr = new StreamReader(file, Encoding.Default);
                line = sr.ReadLine();
                //INIファイル読み込み
                while (null != line)
                {
                    //半角セミコロン(;)以降は無視する
                    if (line.Equals("") || line.Contains(";"))
                    {
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_RATE_SECTION_A))
                    {
                        //掛率パラメータＡ
                        tempSection = INI_FILE_RATE_SECTION_A;
                        file_A.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_RATE_SECTION_B))
                    {
                        //掛率パラメータＢ
                        tempSection = INI_FILE_RATE_SECTION_B;
                        file_B.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_RATE_SECTION_C))
                    {
                        //掛率パラメータＣ
                        tempSection = INI_FILE_RATE_SECTION_C;
                        file_C.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    // 掛率パラメータＡ、Ｂ、Ｃ以外の処理
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]"))
                    {
                        tempSection = "other";
                        line = sr.ReadLine();
                        continue;
                    }
                    //掛率パラメータＡの読む
                    if (tempSection == INI_FILE_RATE_SECTION_A)
                    {
                        ReadRateParamAFile(line, ref file_A, tempSection);
                    }
                    //掛率パラメータＢの読む
                    if (tempSection == INI_FILE_RATE_SECTION_B)
                    {
                        ReadRateParamBFile(line, ref file_B, tempSection);
                    }
                    //掛率パラメータＣの読む
                    if (tempSection == INI_FILE_RATE_SECTION_C)
                    {
                        ReadRateParamCFile(line, ref file_C, tempSection);
                    }
                    line = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                errMess = e.Message.ToString();
                status = false;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();

                }
            }
            return status;
        }

        /// <summary>
        ///INIファイル読み込み
        /// </summary>
        /// <param name="file">INIファイルパス</param>
        /// <param name="file_A">商品パラメータリストＡ</param>
        /// <param name="file_B">商品パラメータリストＢ</param>
        /// <param name="file_C">商品パラメータリストＣ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : INIファイル読み込みを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private bool ReadGoodsParamFile(string file, ref ArrayList file_A, ref ArrayList file_B, ref ArrayList file_C)
        {
            bool status = true;
            StreamReader sr = null;
            string line = string.Empty;
            string tempSection = string.Empty;
            string errMess = string.Empty;
            // VALUEリスト
            ArrayList valueList = new ArrayList();
            try
            {
                sr = new StreamReader(file, Encoding.Default);
                line = sr.ReadLine();
                //INIファイル読み込み
                while (null != line)
                {
                    //半角セミコロン(;)以降は無視する
                    if (line.Equals("") || line.Contains(";"))
                    {
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_GOODS_SECTION_A))
                    {
                        //商品パラメータＡ
                        tempSection = INI_FILE_GOODS_SECTION_A;
                        file_A.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_GOODS_SECTION_B))
                    {
                        //商品パラメータＢ
                        tempSection = INI_FILE_GOODS_SECTION_B;
                        file_B.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_GOODS_SECTION_C))
                    {
                        //商品パラメータＣ
                        tempSection = INI_FILE_GOODS_SECTION_C;
                        file_C.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    // 商品パラメータＡ、Ｂ、Ｃ以外の処理
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]"))
                    {
                        tempSection = "other";
                        line = sr.ReadLine();
                        continue;
                    }
                    //商品パラメータＡの読む
                    if (tempSection == INI_FILE_GOODS_SECTION_A)
                    {
                        ReadGoodsParamAFile(line, ref file_A, tempSection);
                    }
                    //商品パラメータＢの読む
                    if (tempSection == INI_FILE_GOODS_SECTION_B)
                    {
                        ReadGoodsParamBFile(line, ref file_B, tempSection);
                    }
                    //商品パラメータＣの読む
                    if (tempSection == INI_FILE_GOODS_SECTION_C)
                    {
                        ReadGoodsParamCFile(line, ref file_C, tempSection);
                    }
                    line = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                errMess = e.Message.ToString();
                status = false;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();

                }
            }
            return status;
        }

        /// <summary>
        ///INIファイル読み込み
        /// </summary>
        /// <param name="file">INIファイルパス</param>
        /// <param name="al">部位パラメータリスト</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : INIファイル読み込みを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private bool ReadPartsParamFile(string file, ref ArrayList al)
        {
            bool status = true;
            StreamReader sr = null;
            string line = string.Empty;
            string tempSection = string.Empty;
            string errMess = string.Empty;
            // VALUEリスト
            ArrayList valueList = new ArrayList();
            try
            {
                sr = new StreamReader(file, Encoding.Default);
                line = sr.ReadLine();
                //INIファイル読み込み
                while (null != line)
                {
                    //半角セミコロン(;)以降は無視する
                    if (line.Equals("") || line.Contains(";"))
                    {
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_PARTS_SECTION_A))
                    {
                        //部位パラメータ
                        tempSection = INI_FILE_PARTS_SECTION_A;
                        al.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    // 部位パラメータ以外の処理
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]"))
                    {
                        tempSection = "other";
                        line = sr.ReadLine();
                        continue;
                    }
                    //部位パラメータの読む
                    if (tempSection == INI_FILE_PARTS_SECTION_A)
                    {
                        ReadPartsParamFile(line, ref al, tempSection);
                    }
                    line = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                errMess = e.Message.ToString();
                status = false;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();

                }
            }
            return status;
        }

        /// <summary>
        ///INIファイル読み込み
        /// </summary>
        /// <param name="file">INIファイルパス</param>
        /// <param name="file_A">優良設定パラメータリストＡ</param>
        /// <param name="file_B">優良設定パラメータリストＢ</param>
        /// <param name="file_C">優良設定パラメータリストＣ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : INIファイル読み込みを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private bool ReadExcellentSetParamFile(string file, ref ArrayList file_A, ref ArrayList file_B, ref ArrayList file_C)
        {
            bool status = true;
            StreamReader sr = null;
            string line = string.Empty;
            string tempSection = string.Empty;
            string errMess = string.Empty;
            // VALUEリスト
            ArrayList valueList = new ArrayList();
            try
            {
                sr = new StreamReader(file, Encoding.Default);
                line = sr.ReadLine();
                //INIファイル読み込み
                while (null != line)
                {
                    //半角セミコロン(;)以降は無視する
                    if (line.Equals("") || line.Contains(";"))
                    {
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_EXCELLENTSET_SECTION_A))
                    {
                        //優良設定パラメータＡ
                        tempSection = INI_FILE_EXCELLENTSET_SECTION_A;
                        file_A.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_EXCELLENTSET_SECTION_B))
                    {
                        //優良設定パラメータＢ
                        tempSection = INI_FILE_EXCELLENTSET_SECTION_B;
                        file_B.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]") && line.Contains(INI_FILE_EXCELLENTSET_SECTION_C))
                    {
                        //優良設定パラメータＣ
                        tempSection = INI_FILE_EXCELLENTSET_SECTION_C;
                        file_C.Clear();
                        line = sr.ReadLine();
                        continue;
                    }
                    // 優良設定パラメータ以外の処理
                    else if (line.Trim().Contains("[") && line.Trim().Contains("]"))
                    {
                        tempSection = "other";
                        line = sr.ReadLine();
                        continue;
                    }
                    //優良設定パラメータＡの読む
                    if (tempSection == INI_FILE_EXCELLENTSET_SECTION_A)
                    {
                        ReadExcellentSetParamAFile(line, ref file_A, tempSection);
                    }
                    //優良設定パラメータＢの読む
                    if (tempSection == INI_FILE_EXCELLENTSET_SECTION_B)
                    {
                        ReadExcellentSetParamBFile(line, ref file_B, tempSection);
                    }
                    //優良設定パラメータＣの読む
                    if (tempSection == INI_FILE_EXCELLENTSET_SECTION_C)
                    {
                        ReadExcellentSetParamCFile(line, ref file_C, tempSection);
                    }
                    line = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                errMess = e.Message.ToString();
                status = false;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();

                }
            }
            return status;
        }

        /// <summary>
        ///掛率パラメータＡ読み込み
        /// </summary>
        /// <param name="line">一行</param>
        /// <param name="file_A">掛率パラメータＡリスト</param>
        /// <param name="tempSection">セクション名</param>
        /// <remarks>
        /// <br>Note       : 掛率パラメータＡ読み込みを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadRateParamAFile(string line, ref ArrayList file_A, string tempSection)
        {
            //各行で、半角イコール(=)の左側(KEY)と右側(VALUE)に分ける
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                RateParaAWork work = new RateParaAWork();
                work.FileName = INI_FILE_RATE;
                work.SectionName = tempSection;
                //変換前BLｺｰﾄﾞ
                work.BeforeBlCd = tempLine[0].PadLeft(5, '0').Trim();
                string[] tempList = tempLine[1].Split(',');
                if (tempList != null && tempList.Length > 0)
                {
                    ArrayList al = new ArrayList();
                    foreach (string str in tempList)
                    {
                        al.Add(str.PadLeft(4, '0').Trim());
                    }
                    //ﾒｰｶｰｺｰﾄﾞﾘｽﾄ
                    work.MakerList = al;
                }
                file_A.Add(work);
            }
        }

        /// <summary>
        ///掛率パラメータＢ読み込み
        /// </summary>
        /// <param name="line">一行</param>
        /// <param name="file_B">掛率パラメータＢリスト</param>
        /// <param name="tempSection">セクション名</param>
        /// <remarks>
        /// <br>Note       : 掛率パラメータＢ読み込みを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadRateParamBFile(string line, ref ArrayList file_B, string tempSection)
        {
            //各行で、半角イコール(=)の左側(KEY)と右側(VALUE)に分ける
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                RateParaBWork work = new RateParaBWork();
                work.FileName = INI_FILE_RATE;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 2)
                {
                    work.MakerCd = tempList1[0].PadLeft(4, '0').Trim();
                    work.BeforeBlCd = tempList1[1].PadLeft(5, '0').Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length >= 1)
                {
                    work.AfterBlCd = tempList2[0].PadLeft(5, '0').Trim();
                    if (tempList2.Length > 1)
                    {
                        ArrayList al = new ArrayList();
                        for (int i = 1; i < tempList2.Length; i++)
                        {
                            al.Add(tempList2[i].Trim());
                        }
                        work.LevelList = al;
                    }
                }
                file_B.Add(work);
            }
        }

        /// <summary>
        ///掛率パラメータＣ読み込み
        /// </summary>
        /// <param name="line">一行</param>
        /// <param name="file_C">掛率パラメータＣリスト</param>
        /// <param name="tempSection">セクション名</param>
        /// <remarks>
        /// <br>Note       : 掛率パラメータＣ読み込みを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadRateParamCFile(string line, ref ArrayList file_C, string tempSection)
        {
            //各行で、半角イコール(=)の左側(KEY)と右側(VALUE)に分ける
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                RateParaCWork work = new RateParaCWork();
                work.FileName = INI_FILE_RATE;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 2)
                {
                    work.MakerCd = tempList1[0].PadLeft(4, '0').Trim();
                    work.BeforeBlCd = tempList1[1].PadLeft(5, '0').Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length > 0)
                {
                    ArrayList al = new ArrayList();
                    foreach (string str in tempList2)
                    {
                        al.Add(str.PadLeft(5, '0').Trim());
                    }
                    work.AfterBlList = al;
                }
                file_C.Add(work);
            }
        }

        /// <summary>
        ///商品パラメータＡ読み込み
        /// </summary>
        /// <param name="line">一行</param>
        /// <param name="file_A">商品パラメータＡリスト</param>
        /// <param name="tempSection">セクション名</param>
        /// <remarks>
        /// <br>Note       : 商品パラメータＡ読み込みを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadGoodsParamAFile(string line, ref ArrayList file_A, string tempSection)
        {
            //各行で、半角イコール(=)の左側(KEY)と右側(VALUE)に分ける
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                GoodsParaAWork work = new GoodsParaAWork();
                work.FileName = INI_FILE_GOODS;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 3)
                {
                    work.MakerCd = tempList1[0].PadLeft(4, '0').Trim();
                    work.BeforeBlCd = tempList1[1].PadLeft(5, '0').Trim();
                    work.TopGoodsNo = tempList1[2].Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length > 0 && tempList2.Length == 1)
                {
                    work.AfterLevel = tempList2[0].Trim();
                }
                file_A.Add(work);
            }
        }

        /// <summary>
        ///商品パラメータＢ読み込み
        /// </summary>
        /// <param name="line">一行</param>
        /// <param name="file_B">商品パラメータＢリスト</param>
        /// <param name="tempSection">セクション名</param>
        /// <remarks>
        /// <br>Note       : 商品パラメータＢ読み込みを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadGoodsParamBFile(string line, ref ArrayList file_B, string tempSection)
        {
            //各行で、半角イコール(=)の左側(KEY)と右側(VALUE)に分ける
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                GoodsParaBWork work = new GoodsParaBWork();
                work.FileName = INI_FILE_GOODS;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 2)
                {
                    work.MakerCd = tempList1[0].PadLeft(4, '0').Trim();
                    work.halfGoodsNp = tempList1[1].Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length > 0 && tempList2.Length == 1)
                {
                    work.AfterBlCd = tempList2[0].PadLeft(5, '0').Trim();
                }
                file_B.Add(work);
            }
        }

        /// <summary>
        ///商品パラメータＣ読み込み
        /// </summary>
        /// <param name="line">一行</param>
        /// <param name="file_C">商品パラメータＣリスト</param>
        /// <param name="tempSection">セクション名</param>
        /// <remarks>
        /// <br>Note       : 商品パラメータＣ読み込みを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadGoodsParamCFile(string line, ref ArrayList file_C, string tempSection)
        {
            //各行で、半角イコール(=)の左側(KEY)と右側(VALUE)に分ける
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                GoodsParaCWork work = new GoodsParaCWork();
                work.FileName = INI_FILE_GOODS;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 2)
                {
                    work.MakerCd = tempList1[0].PadLeft(4, '0').Trim();
                    work.BeforeBlCd = tempList1[1].PadLeft(5, '0').Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length > 0 && tempList2.Length == 1)
                {
                    work.AfterBlCd = tempList2[0].PadLeft(5, '0').Trim();
                }
                file_C.Add(work);
            }
        }

        /// <summary>
        ///部位パラメータ読み込み
        /// </summary>
        /// <param name="line">一行</param>
        /// <param name="file">部位パラメータリスト</param>
        /// <param name="tempSection">セクション名</param>
        /// <remarks>
        /// <br>Note       : 部位パラメータ読み込みを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadPartsParamFile(string line, ref ArrayList file, string tempSection)
        {
            //各行で、半角イコール(=)の左側(KEY)と右側(VALUE)に分ける
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                PartsParaWork work = new PartsParaWork();
                work.FileName = INI_FILE_PARTS;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 1)
                {
                    work.BeforeBlCd = tempList1[0].PadLeft(5, '0').Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length > 0 && tempList1.Length == 1)
                {
                    work.AfterBlCd = tempList2[0].PadLeft(5, '0').Trim();
                }
                file.Add(work);
            }
        }

        /// <summary>
        ///優良設定パラメータＡ読み込み
        /// </summary>
        /// <param name="line">一行</param>
        /// <param name="file_A">優良設定パラメータＡリスト</param>
        /// <param name="tempSection">セクション名</param>
        /// <remarks>
        /// <br>Note       : 優良設定パラメータＡ読み込みを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadExcellentSetParamAFile(string line, ref ArrayList file_A, string tempSection)
        {
            //各行で、半角イコール(=)の左側(KEY)と右側(VALUE)に分ける
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                ExcellentSetParaAWork work = new ExcellentSetParaAWork();
                work.FileName = INI_FILE_EXCELLENTSET;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 3)
                {
                    work.MakerCd = tempList1[0].PadLeft(4, '0').Trim();
                    work.BeforeBlCd = tempList1[1].PadLeft(5, '0').Trim();
                    work.BeforeSelectCd = tempList1[2].PadLeft(4, '0').Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length > 0 && tempList2.Length == 1)
                {
                    work.AfterBlCd = tempList2[0].PadLeft(5, '0').Trim();
                }
                file_A.Add(work);
            }
        }

        /// <summary>
        ///優良設定パラメータＢ読み込み
        /// </summary>
        /// <param name="line">一行</param>
        /// <param name="file_B">優良設定パラメータＢリスト</param>
        /// <param name="tempSection">セクション名</param>
        /// <remarks>
        /// <br>Note       : 優良設定パラメータＢ読み込みを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadExcellentSetParamBFile(string line, ref ArrayList file_B, string tempSection)
        {
            //各行で、半角イコール(=)の左側(KEY)と右側(VALUE)に分ける
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                ExcellentSetParaBWork work = new ExcellentSetParaBWork();
                work.FileName = INI_FILE_EXCELLENTSET;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 3)
                {
                    work.MakerCd = tempList1[0].PadLeft(4, '0').Trim();
                    work.BeforeBlCd = tempList1[1].PadLeft(5, '0').Trim();
                    work.BeforeSelectCd = tempList1[2].PadLeft(4, '0').Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length > 0 && tempList2.Length == 1)
                {
                    work.AfterSelectCd = tempList2[0].PadLeft(4, '0').Trim();
                }
                file_B.Add(work);
            }
         }

        /// <summary>
        ///優良設定パラメータＣ読み込み
        /// </summary>
        /// <param name="line">一行</param>
        /// <param name="file_C">優良設定パラメータＣリスト</param>
        /// <param name="tempSection">セクション名</param>
        /// <remarks>
        /// <br>Note       : 優良設定パラメータＣ読み込みを行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void ReadExcellentSetParamCFile(string line, ref ArrayList file_C, string tempSection)
        {
            //各行で、半角イコール(=)の左側(KEY)と右側(VALUE)に分ける
            string[] tempLine = line.Split('=');
            if (tempLine != null && tempLine.Length > 0 && tempLine.Length == 2)
            {
                ExcellentSetParaCWork work = new ExcellentSetParaCWork();
                work.FileName = INI_FILE_EXCELLENTSET;
                work.SectionName = tempSection;
                string[] tempList1 = tempLine[0].Split(',');
                if (tempList1 != null && tempList1.Length > 0 && tempList1.Length == 4)
                {
                    work.MakerCd = tempList1[0].PadLeft(4, '0').Trim();
                    work.BeforeBlCd = tempList1[1].PadLeft(5, '0').Trim();
                    work.BeforeSelectCd = tempList1[2].PadLeft(4, '0').Trim();
                    work.BeforeKindCd = tempList1[3].PadLeft(4, '0').Trim();
                }
                string[] tempList2 = tempLine[1].Split(',');
                if (tempList2 != null && tempList2.Length > 0 && tempList2.Length == 1)
                {
                    work.AfterKindCd = tempList2[0].PadLeft(4, '0').Trim();
                }
                file_C.Add(work);
            }
        }
        #endregion

        #region ◎ 処理ログファイルの書き込み
        /// <summary>
        /// 処理ログファイルの書き込み
        /// </summary>
        /// <param name="list">結果リスト</param>
        /// <param name="append">append</param>
        /// <param name="file">file</param>
        /// <remarks>
        /// <br>Note       : 処理結果リストデータの変換を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/01/11</br>
        /// </remarks>
        private void WriteCSV(ArrayList list, bool append, string file)
        {
            StreamWriter fileWriter = null;
            try
            {
                fileWriter = new StreamWriter(file, append, Encoding.Default);
                // 処理ログファイルの書き込み
                foreach( ResultListWork work in list)
                {
                    fileWriter.WriteLine(work.TableName + "," + work.Key + "," + work.Content + "," + work.Status);
                }
                fileWriter.Flush();
            }
            finally
            {
                if (fileWriter != null)
                {
                    fileWriter.Close();
                }
            }
        }
        #endregion
        #endregion ◆ ＢＬコード層別変換処理
        #endregion ■ Private Method
    }
}
