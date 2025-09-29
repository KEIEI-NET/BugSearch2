//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコード関連付け　取込アクセスクラス
// プログラム概要   : 商品バーコード関連付けデータに対して取込処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊
// 作 成 日  2017/06/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Resources;
using System.IO;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using System.Data;
using Broadleaf.Library.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品バーコード関連付け情報取込アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード関連付け情報取込アクセス制御を行います。</br>
    /// <br>Programmer : 3H 張小磊</br>
    /// <br>Date       : 2017/06/12</br>
    /// </remarks>
    public class GoodsBarCodeRevnImportAcs
    {
        // エラーメッセージ
        private const string ct_ERR_NOINPUT = "未入力･";
        private const string ct_ERR_INVALID_VALUE = "値不正･";
        private const string ct_ERR_INVALID_LENGTH = "桁数･";
        private const string ct_ERR_INVALID_HYPHEN = "ﾊｲﾌﾝ個数･";
        private const string ct_ERR_MINUS = "ﾏｲﾅｽ･";
        private const string ct_ERR_DUPLICATE = "重複データがあるため登録できません。";
        private const string ct_ERROR_LOG_FILENAME = "PMHND09210U_ERRORLOG.xml";

        /// <summary>リモートオブジェクト</summary>
        private IGoodsBarCodeRevnDB _iGoodsBarCodeRevnDB = null;

        /// <summary>エラーデータテーブル</summary>
        private DataTable _errOutputDataTable = null;

        /// <summary>
        /// 商品バーコード関連付け情報取込アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付け情報取込アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public GoodsBarCodeRevnImportAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iGoodsBarCodeRevnDB = MediationGoodsBarCodeRevnDB.GetGoodsBarCodeRevnDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iGoodsBarCodeRevnDB = null;
            }
        }

        #region ◎ インポート処理
        /// <summary>
        /// インポート処理
        /// </summary>
        /// <param name="fileWorkList">ファイルデータList</param>
        /// <param name="errLogFilePath">エラーログファイルパス</param>
        /// <param name="processKbn">処理区分</param>
        /// <param name="dataCheckKbn">チェック区分</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">更新件数</param>
        /// <param name="errCnt">エラー件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>インポート処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付け情報の読込を行います。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br></br>
        /// </remarks>
        public int Import(List<GoodsBarCodeRevnFileWork> fileWorkList, string errLogFilePath, int processKbn, int dataCheckKbn, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 errCnt, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            readCnt = 0; // 読込件数
            addCnt = 0; // 追加件数
            updCnt = 0; // 更新件数
            errCnt = 0; // エラー件数
            errMsg = string.Empty; //エラーメッセージ
            try
            {
                // 既存の商品バーコード関連付け情報
                List<GoodsBarCodeRevnWork> existWorkList = null;
                // ファイルデータのエラーデータ
                List<GoodsBarCodeRevnFileWork> errFileWorkList = null;
                // 商品バーコード関連付け情報
                ArrayList importWorkList = null;

                if (fileWorkList != null && fileWorkList.Count > 0)
                {
                    // 読込件数
                    readCnt = fileWorkList.Count;
                    // 既存の商品バーコードデータ検索処理
                    status = SearchGoodsBarCodeRevnWorkList(out existWorkList);
                    // 既存の商品バーコードデータ検索処理失敗
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                        && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) return status;
                    // ファイルデータを登録データに変換処理
                    status = ConvertFileWorkToImportWorkList(fileWorkList, existWorkList, processKbn, dataCheckKbn, out addCnt, out updCnt, out importWorkList, out errFileWorkList);
                    // ファイルデータを登録データに変換失敗
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                    if (importWorkList != null && importWorkList.Count > 0)
                    {
                        // 商品バーコード関連付け情報(obj) 
                        object objGoodsBarCodeRevnWorkList = (object)importWorkList;
                        // 商品バーコード関連付け情報登録処理 
                        status = this._iGoodsBarCodeRevnDB.WriteByInput(ref objGoodsBarCodeRevnWorkList);
                    }
                    if (errFileWorkList != null && errFileWorkList.Count > 0)
                    {
                        // エラー件数
                        errCnt = errFileWorkList.Count;
                        // エラーログデータをセット
                        SetDataToErrDataTable(errFileWorkList);
                        // エラーログファイルを出力
                        DoOutPut(errLogFilePath);
                    }
                }
            }
            catch (IOException)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 商品バーコード関連付け検索処理
        /// </summary>
        /// <param name="goodsBarCodeRevnWorkList">検索結果List</param>
        /// <returns>検索処理結果</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けの検索処理を行います。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int SearchGoodsBarCodeRevnWorkList(out List<GoodsBarCodeRevnWork> goodsBarCodeRevnWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            goodsBarCodeRevnWorkList = new List<GoodsBarCodeRevnWork>();
            try
            {
                GoodsBarCodeRevnSearchParaWork goodsBarCodeRevnSearchParaWork = new GoodsBarCodeRevnSearchParaWork();
                goodsBarCodeRevnSearchParaWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                // 商品バーコード関連付け検索条件ワーククラス ⇒ obj
                object paraobj = goodsBarCodeRevnSearchParaWork;
                object retobj = null;

                // 商品バーコード関連付けデータ検索
                status = this._iGoodsBarCodeRevnDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 商品バーコード関連付けワークList
                    ArrayList wkList = retobj as ArrayList;
                    if (wkList != null && wkList.Count > 0)
                    {
                        for (int i = 0; i < wkList.Count; i++)
                        {
                            goodsBarCodeRevnWorkList.Add((GoodsBarCodeRevnWork)wkList[i]);
                        }
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// ファイルデータを登録データに変換処理
        /// </summary>
        /// <param name="fileWorkList">ファイルデータ</param>
        /// <param name="existWorkList">既存の商品バーコード関連付けワークList</param>
        /// <param name="processKbn">処理区分</param>
        /// <param name="dataCheckKbn">チェック区分</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">更新件数</param>
        /// <param name="importWorkList">商品バーコード関連付けワークList</param>
        /// <param name="errFileWorkList">エラーデータList</param>
        /// <returns>変換処理結果</returns>
        /// <remarks>
        /// <br>Note       : ファイルデータを登録データに変換処理。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br></br>
        /// </remarks>
        private int ConvertFileWorkToImportWorkList(List<GoodsBarCodeRevnFileWork> fileWorkList, List<GoodsBarCodeRevnWork> existWorkList, int processKbn, int dataCheckKbn, out int addCnt, out int updCnt, out ArrayList importWorkList, out List<GoodsBarCodeRevnFileWork> errFileWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // 追加件数
            addCnt = 0;
            // 更新件数
            updCnt = 0;
            // 商品バーコード関連付けワークList
            importWorkList = new ArrayList();
            // ファイルデータのエラーデータList
            errFileWorkList = new List<GoodsBarCodeRevnFileWork>();
            try
            {
                if (fileWorkList != null && fileWorkList.Count > 0)
                {
                    // 商品バーコード関連付けディクショナリ
                    Dictionary<string, GoodsBarCodeRevnWork> _goodsBarCodeRevnWorkDic = new Dictionary<string, GoodsBarCodeRevnWork>();

                    if (existWorkList != null && existWorkList.Count > 0)
                    {
                        for (int i = 0; i < existWorkList.Count; i++)
                        {
                            // キー: 商品メーカーコード(4桁) + "_" + 商品番号
                            string dicKey = existWorkList[i].GoodsMakerCd.ToString("0000") + "_" + existWorkList[i].GoodsNo;
                            if (!_goodsBarCodeRevnWorkDic.ContainsKey(dicKey))
                            {
                                // 既存のデータをディクショナリにセット
                                _goodsBarCodeRevnWorkDic.Add(dicKey, existWorkList[i]);
                            }
                        }
                    }

                    for (int i = 0; i < fileWorkList.Count; i++)
                    {
                        string errMsg = String.Empty;
                        // キー: 商品メーカーコード + "_" + 商品番号
                        string dicKey = fileWorkList[i].GoodsMakerCd.PadLeft(4, '0') + "_" + fileWorkList[i].GoodsNo;
                        // データは登録しない
                        if (!_goodsBarCodeRevnWorkDic.ContainsKey(dicKey))
                        {
                            // 画面.処理区分：追加、追加更新すると、チェック行う
                            if (processKbn == 0 || processKbn == 1)
                            {
                                // データの有効性チェック
                                if (!FileWorKDataCheck(fileWorkList[i], fileWorkList, dataCheckKbn, out errMsg))
                                {
                                    fileWorkList[i].ErrMessage = errMsg;
                                    errFileWorkList.Add(fileWorkList[i]);
                                }
                                else
                                {
                                    GoodsBarCodeRevnWork temp = new GoodsBarCodeRevnWork();
                                    // 企業コード
                                    temp.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                                    // 商品メーカーコード
                                    temp.GoodsMakerCd = int.Parse((fileWorkList[i].GoodsMakerCd.Trim()));
                                    // 商品番号
                                    temp.GoodsNo = fileWorkList[i].GoodsNo.Trim();
                                    // 商品バーコード
                                    temp.GoodsBarCode = fileWorkList[i].GoodsBarCode.Trim();
                                    // 商品バーコード種別
                                    temp.GoodsBarCodeKind = int.Parse((fileWorkList[i].GoodsBarCodeKind.Trim()));
                                    // チェックデジット区分
                                    temp.CheckdigitCode = 0;
                                    // 提供データ区分  0:ユーザデータ
                                    temp.OfferDataDiv = 0;
                                    importWorkList.Add(temp);
                                    addCnt++;
                                }
                            }
                        }
                        // データは登録済み
                        else
                        {
                            // 画面.処理区分：更新、追加更新すると、チェック行う
                            if (processKbn == 0 || processKbn == 2)
                            {
                                // データの有効性チェック
                                if (!FileWorKDataCheck(fileWorkList[i], fileWorkList, dataCheckKbn, out errMsg))
                                {
                                    fileWorkList[i].ErrMessage = errMsg;
                                    errFileWorkList.Add(fileWorkList[i]);
                                }
                                else
                                {
                                    GoodsBarCodeRevnWork temp = new GoodsBarCodeRevnWork();
                                    temp = _goodsBarCodeRevnWorkDic[dicKey];
                                    // 商品バーコード
                                    temp.GoodsBarCode = fileWorkList[i].GoodsBarCode;
                                    // 商品バーコード種別
                                    temp.GoodsBarCodeKind = int.Parse(fileWorkList[i].GoodsBarCodeKind);
                                    importWorkList.Add(temp);
                                    updCnt++;
                                }
                            }
                        }
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        #endregion ◎ インポート処理

        #region ◆ データチェック処理
        /// <summary>
        /// データチェック
        /// </summary>
        /// <param name="fileWork">商品バーコードのファイルクラスワーク</param>
        /// <param name="fileWorkList">ファイルデータ</param>
        /// <param name="dataCheckKbn">チェック区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>true:チェックOK false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : データチェックを実行します。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private bool FileWorKDataCheck(GoodsBarCodeRevnFileWork fileWork, List<GoodsBarCodeRevnFileWork> fileWorkList, int dataCheckKbn, out string errMsg)
        {
            errMsg = string.Empty;

            // チェック区分:あり
            if (dataCheckKbn == 0)
            {
                string sWkMsg = string.Empty;

                // メーカーコード
                sWkMsg = CheckGoodsMakerCd(fileWork.GoodsMakerCd.Trim());
                if (!string.IsNullOrEmpty(sWkMsg))
                {
                    errMsg = String.Format("ﾒｰｶｰ({0})", sWkMsg);
                    return false;
                }

                // 品番
                sWkMsg = CheckGoodsNo(fileWork.GoodsNo.Trim());
                if (!string.IsNullOrEmpty(sWkMsg))
                {
                    errMsg = String.Format("品番({0})", sWkMsg);
                    return false;
                }

                // バーコード
                sWkMsg = CheckGoodsBarCode(fileWork.GoodsBarCode.Trim());
                if (!string.IsNullOrEmpty(sWkMsg))
                {
                    errMsg = String.Format("バーコード({0})", sWkMsg);
                    return false;
                }

                // バーコード種別
                sWkMsg = CheckGoodsBarCodeKind(fileWork.GoodsBarCodeKind.Trim());
                if (!string.IsNullOrEmpty(sWkMsg))
                {
                    errMsg = String.Format("バーコード種別({0})", sWkMsg);
                    return false;
                }
            }

            // 商品バーコードキー重複チェック
            int countGoodU = fileWorkList.FindAll(
                delegate(GoodsBarCodeRevnFileWork p)
                {
                    return (p.GoodsNo == fileWork.GoodsNo
                           && p.GoodsMakerCd.PadLeft(4, '0') == fileWork.GoodsMakerCd.PadLeft(4, '0')
                          );
                }).Count;
            if (countGoodU > 1)
            {
                errMsg = ct_ERR_DUPLICATE;
                return false;
            }

            return true;
        }

        #region ◎ メーカーコード
        /// <summary>
        /// メーカーコードチェック
        /// </summary>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : メーカーコードチェックを実行します。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private string CheckGoodsMakerCd(string goodsMakerCd)
        {
            string sResult = string.Empty;

            // 未入力ﾁｪｯｸ
            if (string.IsNullOrEmpty(goodsMakerCd))
            {
                sResult += ct_ERR_NOINPUT;
            }
            else
            {
                //数値ﾁｪｯｸ 
                int num = 0;
                if (!Int32.TryParse(goodsMakerCd, out num))
                {
                    sResult += ct_ERR_INVALID_VALUE;
                }

                // 値不正(負値)ﾁｪｯｸ
                if (num < 0)
                {
                    sResult += ct_ERR_MINUS;
                }

                // 桁数ﾁｪｯｸ
                if (goodsMakerCd.Length > 4)
                {
                    sResult += ct_ERR_INVALID_LENGTH;
                }

            }

            // ﾒｯｾｰｼﾞ編集
            if (!string.IsNullOrEmpty(sResult))
            {
                sResult = sResult.Substring(0, sResult.Length - 1);
            }

            return sResult;
        }
        #endregion ◎ メーカーコード

        #region ◎ 品番
        /// <summary>
        /// 品番チェック
        /// </summary>
        /// <param name="goodsNo">品番</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : 品番チェックを実行します。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private string CheckGoodsNo(string goodsNo)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            string sResult = string.Empty;

            // 未入力ﾁｪｯｸ
            if (string.IsNullOrEmpty(goodsNo))
            {
                sResult += ct_ERR_NOINPUT;
            }
            else
            {
                // 桁数ﾁｪｯｸ
                int byteCount = sjisEnc.GetByteCount(goodsNo);
                if (byteCount > 24)
                {
                    sResult += ct_ERR_INVALID_LENGTH;
                }

                // ﾊｲﾌﾝが6個以上存在
                if (goodsNo.Split('-').Length > 6)
                {
                    sResult += ct_ERR_INVALID_HYPHEN;
                }

                // 品番不正
                if ((byteCount != goodsNo.Length) ||
                    goodsNo.Contains("*") ||
                    goodsNo.StartsWith("-") ||
                    goodsNo.EndsWith("+") ||
                    goodsNo.EndsWith("."))
                {
                    sResult += ct_ERR_INVALID_VALUE;
                }
            }

            // ﾒｯｾｰｼﾞ編集
            if (!string.IsNullOrEmpty(sResult))
            {
                sResult = sResult.Substring(0, sResult.Length - 1);
            }

            return sResult;
        }

        #endregion ◎ 品番

        #region ◎ バーコード
        /// <summary>
        /// バーコードチェック
        /// </summary>
        /// <param name="goodsBarCode">バーコード</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : バーコードチェックを実行します。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private string CheckGoodsBarCode(string goodsBarCode)
        {
            string sResult = string.Empty;

            // 未入力ﾁｪｯｸ
            if (string.IsNullOrEmpty(goodsBarCode))
            {
                sResult += ct_ERR_NOINPUT;
            }
            else
            {
                // 桁数ﾁｪｯｸ
                if (goodsBarCode.Length > 128)
                {
                    sResult += ct_ERR_INVALID_LENGTH;
                }
            }

            // ﾒｯｾｰｼﾞ編集
            if (!string.IsNullOrEmpty(sResult))
            {
                sResult = sResult.Substring(0, sResult.Length - 1);
            }

            return sResult;
        }
        #endregion ◎ バーコード

        #region ◎ バーコード種別
        /// <summary>
        /// バーコード種別チェック
        /// </summary>
        /// <param name="goodsBarCodeKind">バーコード種別</param>
        /// <returns>チェック結果</returns>
        /// <remarks>
        /// <br>Note       : バーコード種別チェックを実行します。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private string CheckGoodsBarCodeKind(string goodsBarCodeKind)
        {
            string sResult = string.Empty;
            // 未入力ﾁｪｯｸ
            if (string.IsNullOrEmpty(goodsBarCodeKind))
            {
                sResult += ct_ERR_NOINPUT;
            }
            else
            {
                // バーコード種別(0と1)
                if (!goodsBarCodeKind.Equals("0") && !goodsBarCodeKind.Equals("1"))
                {
                    sResult = ct_ERR_INVALID_VALUE;
                }
            }
            // ﾒｯｾｰｼﾞ編集
            if (!string.IsNullOrEmpty(sResult))
            {
                sResult = sResult.Substring(0, sResult.Length - 1);
            }

            return sResult;
        }
        #endregion ◎ バーコード種別

        #endregion ◆ データチェック処理

        #region エラーログファイル出力処理

        /// <summary>
        /// エラーデータテーブル初期設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : エラーデータテーブル初期設定。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void InitErrDataTable()
        {
            this._errOutputDataTable = new DataTable();
            // 商品メーカーコード
            this._errOutputDataTable.Columns.Add("GoodsMakerCd_Err", typeof(string));
            // 商品番号
            this._errOutputDataTable.Columns.Add("GoodsNo_Err", typeof(string));
            // 商品バーコード
            this._errOutputDataTable.Columns.Add("GoodsBarCode_Err", typeof(string));
            // 商品バーコード種別
            this._errOutputDataTable.Columns.Add("GoodsBarCodeKind_Err", typeof(string));
            // エラーメッセージ
            this._errOutputDataTable.Columns.Add("Message_Err", typeof(string));
        }

        /// <summary>
        /// エラーデータテーブルに値をセット
        /// </summary>
        /// <param name="errFileWorkList">エラーデータ</param>
        /// <remarks>
        /// <br>Note       : エラーデータテーブルに値をセット。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetDataToErrDataTable(List<GoodsBarCodeRevnFileWork> errFileWorkList)
        {
            if (this._errOutputDataTable == null)
            {
                // エラーデータテーブル初期設定
                InitErrDataTable();
            }
            // エラーデータテーブルクリア
            this._errOutputDataTable.Clear();
            if (errFileWorkList != null && errFileWorkList.Count > 0)
            {
                for (int i = 0; i < errFileWorkList.Count; i++)
                {
                    DataRow dataRow = this._errOutputDataTable.NewRow();
                    // 商品メーカーコード
                    dataRow["GoodsMakerCd_Err"] = errFileWorkList[i].GoodsMakerCd;
                    // 商品番号
                    dataRow["GoodsNo_Err"] = errFileWorkList[i].GoodsNo;
                    // 商品バーコード
                    dataRow["GoodsBarCode_Err"] = errFileWorkList[i].GoodsBarCode;
                    // 商品バーコード種別
                    dataRow["GoodsBarCodeKind_Err"] = errFileWorkList[i].GoodsBarCodeKind;
                    // エラーメッセージ
                    dataRow["Message_Err"] = errFileWorkList[i].ErrMessage;
                    this._errOutputDataTable.Rows.Add(dataRow);
                }
            }
        }

        /// <summary>
        /// エラーログファイル出力処理
        /// </summary>
        /// <param name="errorLogFileName">エラーログ出力ファイルバス</param>
        /// <returns>出力処理状況</returns>
        /// <remarks>
        /// <br>Note	   : エラーログファイル出力処理を行う。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int DoOutPut(string errorLogFileName)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // テキスト出力サービスパラメータ
            CustomTextProviderInfo customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            // テキスト入出力クラス
            CustomTextWriter customTextWriter = new CustomTextWriter();

            // 出力パスと名前
            customTextProviderInfo.OutPutFileName = errorLogFileName;
            // 上書き／追加フラグをセット(true:追加する、false:上書きする)
            customTextProviderInfo.AppendMode = false;
            // スキーマ取得
            customTextProviderInfo.SchemaFileName = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema, ct_ERROR_LOG_FILENAME);

            try
            {
                // エラーログファイル出力処理
                status = customTextWriter.WriteText(this._errOutputDataTable, customTextProviderInfo.SchemaFileName, customTextProviderInfo.OutPutFileName, customTextProviderInfo);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion
    }
    
}
