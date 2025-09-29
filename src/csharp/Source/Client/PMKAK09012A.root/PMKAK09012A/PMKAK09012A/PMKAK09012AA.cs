//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先総括マスタ一覧表アクセスクラス
// プログラム概要   : 仕入先総括マスタ一覧表で使用するデータを取得する
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号             作成担当 : FSI菅原　要
// 作 成 日  2012/09/07 修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 仕入先総括マスタ一覧表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先総括マスタ一覧表で使用するデータを取得する</br>
    /// <br>Programmer : FSI菅原　要</br>
    /// <br>Date       : 2012/09/07</br>
    /// </remarks>
    public class SumSuppStPrintAcs
    {
        #region ■ Constructor
		/// <summary>
		/// 仕入先総括マスタ一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 仕入先総括マスタ一覧表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date	   : 2012/09/07</br>
        /// </remarks>
        public SumSuppStPrintAcs()
		{
            this._iSumSuppStResultDB = (ISumSuppStPrintResultDB)MediationSumSuppStPrintResultDB.GetSumSuppStPrintResultDB();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._secInfoSetAcs = new SecInfoSetAcs();
            this._supplierAcs = new SupplierAcs();

            // キャッシュ初期化
            DeleteAllFromCacheForSecInfoSet();
            DeleteAllFromCacheForSupplier();
		}

        #endregion ■ Constructor

        #region ■ Private Member
        // 仕入先総括マスタ一覧表インタフェース
        private ISumSuppStPrintResultDB _iSumSuppStResultDB;

        // 拠点情報設定マスタアクセスクラス
        private SecInfoSetAcs _secInfoSetAcs;

        // 仕入先マスタアクセスクラス
        private SupplierAcs _supplierAcs;

        // DataSetオブジェクト
        private DataSet _dataSet;

        // 企業コード
        private string _enterpriseCode;

        // staticローカルキャッシュ
        private static Dictionary<string, SecInfoSet> _secInfoSetDic;  // 拠点情報設定マスタ
        private static Dictionary<int, Supplier> _supplierDic;         // 仕入先マスタ

        #endregion ■ Private Member

        #region ■ Public Property
        /// <summary>
        /// データセット(読み取り専用)
        /// </summary>
        public DataSet DataSet
        {
            get { return this._dataSet; }
        }
        #endregion ■ Public Property

        #region ■ Public Method
        #region ◆ 出力データ取得
        #region ◎ 仕入先総括マスタ一覧表データ取得
        /// <summary>
        /// 仕入先総括マスタ一覧表データ取得
        /// </summary>
        /// <param name="sumSuppStPrintParaWork">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する仕入先総括マスタ一覧表データを取得する。</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date	   : 2012/09/07</br>
        /// </remarks>
        public int SearchSumSuppStPrintProcMain(SumSuppStPrintUIParaWork sumSuppStPrintParaWork, out string errMsg)
        {
            return this.SearchSumSuppStPrintProc(sumSuppStPrintParaWork, out errMsg);
        }
        #endregion
        #endregion ◆ 出力データ取得
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ データ取得
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="sumSuppStPrintParaWork"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷する仕入先総括マスタ一覧表データを取得する。</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date	   : 2012/09/07</br>
        /// </remarks>
        private int SearchSumSuppStPrintProc(SumSuppStPrintUIParaWork sumSuppStPrintParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            ArrayList sumSuppStList = null;

            try
            {
                #region [仕入先マスタ（総括設定）検索]

                // DataTableを作成
                PMKAK09015EA.CreateDataTable(ref _dataSet);

                // Rクラスへの抽出条件を設定
                SumSuppStPrintParaWork sumSuppStParaWork = new SumSuppStPrintParaWork();
                status = this.SetCondInfo(ref sumSuppStPrintParaWork, out sumSuppStParaWork, out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // RクラスのSearchメソッドコール用に整形
                object retList = null;
                object paraWorkRef = sumSuppStParaWork;

                // Searchメソッドコール
                status = _iSumSuppStResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        sumSuppStList = (ArrayList)retList;
                        if (sumSuppStList.Count <= 0 )
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        retList = null;
                        break;

                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "仕入総括マスタ一覧の出力データの取得に失敗しました。";
                        break;
                }

                #endregion

                #region [名称編集のためのデータ検索とDataSetへのデータ展開]

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    #region [拠点情報設定マスタデータ取得]

                    // 拠点情報設定マスタ全件検索
                    ArrayList wkRetList = new ArrayList();
                    status = this._secInfoSetAcs.Search(out wkRetList, this._enterpriseCode);

                    // 検索結果判定
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            if (wkRetList != null)
                            {
                                foreach (SecInfoSet wkLineupWork in wkRetList)
                                {
                                    // 取得した拠点情報設定マスタ情報を全件キャッシュ
                                    UpdateCacheForSecInfoSet(wkLineupWork);
                                }
                            }

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                        break;
                    default:
                        return status;
                    }

                    #endregion

                    #region [仕入先マスタデータ取得]

                    // 仕入先マスタ全件検索
                    wkRetList = new ArrayList();
                    status = this._supplierAcs.Search(out wkRetList, this._enterpriseCode);

                    // 検索結果判定
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            if (wkRetList != null)
                            {
                                foreach (Supplier wkLineupWork in wkRetList)
                                {
                                    // 取得した仕入先マスタ情報を全件キャッシュ
                                    UpdateCacheForSupplier(wkLineupWork);
                                }
                            }

                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                            status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                            break;
                        default:
                            return status;
                    }

                    #endregion
                        
                    #region [DatSetへのデータ展開、同時に名称編集]

                    if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ConverToDataSet(_dataSet.Tables[PMKAK09015EA.ct_Tbl_SumSuppStReportData], sumSuppStList);
                    }
                        
                    #endregion
                }

                #endregion

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            finally
            {
                // キャッシュは初期化
                DeleteAllFromCacheForSecInfoSet();
                DeleteAllFromCacheForSupplier();
            }
            return status;
        }
        #endregion
        #endregion ◆ 帳票データ取得

        #region ◆ データ展開処理

        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="sumSuppStPrintUIParaWork">UI抽出条件クラス</param>
        /// <param name="sumSuppStPrintParaWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件展開処理を行う</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date	   : 2012/09/07</br>
        /// </remarks>
        private int SetCondInfo(ref SumSuppStPrintUIParaWork sumSuppStPrintUIParaWork, out SumSuppStPrintParaWork sumSuppStPrintParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            sumSuppStPrintParaWork = new SumSuppStPrintParaWork();

            try
            {
                // 企業コード
                sumSuppStPrintParaWork.EnterpriseCode = sumSuppStPrintUIParaWork.EnterpriseCode;

                // 総括拠点コード開始
                sumSuppStPrintParaWork.SectionCodeSt = sumSuppStPrintUIParaWork.SumSectionCodeSt;

                // 総括拠点コード終了
                sumSuppStPrintParaWork.SectionCodeEd = sumSuppStPrintUIParaWork.SumSectionCodeEd;

                // 総括仕入先コード開始
                sumSuppStPrintParaWork.SupplierCodeSt = sumSuppStPrintUIParaWork.SumSupplierCdSt;

                // 総括仕入先コード終了
                sumSuppStPrintParaWork.SupplierCodeEd = sumSuppStPrintUIParaWork.SumSupplierCdEd;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region ◎キャッシュ制御処理

        /// <summary>
        /// キャッシュ更新処理（拠点情報設定マスタ）
        /// </summary>
        /// <param name="cashData"></param>
        /// <remarks>
        /// <br>キャッシュへ拠点情報データを書き込みます。</br>
        /// <br>Programmer : FSI菅原 要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private void UpdateCacheForSecInfoSet(SecInfoSet cashData)
        {
            // staticディクショナリが無ければ生成
            if (_secInfoSetDic == null)
            {
                _secInfoSetDic = new Dictionary<string, SecInfoSet>();
            }

            // 既存ならば削除
            if (_secInfoSetDic.ContainsKey(cashData.SectionCode))
            {
                _secInfoSetDic.Remove(cashData.SectionCode);
            }
            // 追加
            _secInfoSetDic.Add(cashData.SectionCode, cashData);
        }

        /// <summary>
        /// キャッシュ読込処理（拠点情報設定マスタ）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>キャッシュから拠点情報データを読み込みます。</br>
        /// <br>Programmer : FSI菅原 要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private SecInfoSet GetFromCacheForSecInfoSet(string sectionCode)
        {
            if (_secInfoSetDic != null)
            {
                // キャッシュから取得
                if (_secInfoSetDic.ContainsKey(sectionCode))
                {
                    return _secInfoSetDic[sectionCode];
                }
            }

            return null;
        }

        /// <summary>
        /// キャッシュ全削除処理（拠点情報設定マスタ）
        /// </summary>
        /// <remarks>
        /// <br>キャッシュを初期化することでデータをすべて削除します。</br>
        /// <br>Programmer : FSI菅原 要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        public void DeleteAllFromCacheForSecInfoSet()
        {
            _secInfoSetDic = new Dictionary<string, SecInfoSet>();
        }

        /// <summary>
        /// キャッシュ更新処理（仕入先マスタ）
        /// </summary>
        /// <param name="cashData"></param>
        /// <remarks>
        /// <br>キャッシュへ拠点情報データを書き込みます。</br>
        /// <br>Programmer : FSI菅原 要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private void UpdateCacheForSupplier(Supplier cashData)
        {
            // staticディクショナリが無ければ生成
            if (_supplierDic == null)
            {
                _supplierDic = new Dictionary<int, Supplier>();
            }

            // 既存ならば削除
            if (_supplierDic.ContainsKey(cashData.SupplierCd))
            {
                _supplierDic.Remove(cashData.SupplierCd);
            }
            // 追加
            _supplierDic.Add(cashData.SupplierCd, cashData);
        }

        /// <summary>
        /// キャッシュ読込処理（仕入先マスタ）
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>キャッシュから拠点情報データを読み込みます。</br>
        /// <br>Programmer : FSI菅原 要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private Supplier GetFromCacheForSupplier(int supplierCode)
        {
            if (_supplierDic != null)
            {
                // キャッシュから取得
                if (_supplierDic.ContainsKey(supplierCode))
                {
                    return _supplierDic[supplierCode];
                }
            }

            return null;
        }

        /// <summary>
        /// キャッシュ全削除処理（拠点情報設定マスタ）
        /// </summary>
        /// <remarks>
        /// <br>キャッシュを初期化することでデータをすべて削除します。</br>
        /// <br>Programmer : FSI菅原 要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        public void DeleteAllFromCacheForSupplier()
        {
            _supplierDic = new Dictionary<int, Supplier>();
        }

        #endregion

        #region ◎ 取得データ展開処理
        /// <summary>
        /// DataTableにデータを設定処理
        /// </summary>
        /// <param name="dataTable">帳票用DataTable</param>
        /// <param name="retList">検索情報リスト</param>
        /// <remarks>
        /// <br>Note       : DataTableにデータを設定処理を行う</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private void ConverToDataSet(DataTable dataTable, ArrayList retList)
        {
            DataRow dr = null;
            SumSuppStPrintResultWork rsltInfo = null;
            SecInfoSet secInfoSet = null;
            Supplier supplier = null;

            for (int cnt = 0; cnt < retList.Count; cnt++)
            {
                rsltInfo = (SumSuppStPrintResultWork)retList[cnt];

                dr = dataTable.NewRow();

                // 総括拠点コード
                dr[PMKAK09015EA.ct_Col_SumSectionCd] = rsltInfo.SumSectionCd;

                // 総括拠点名
                // キャッシュから該当するデータを取得
                secInfoSet = GetFromCacheForSecInfoSet(rsltInfo.SumSectionCd);
                if (secInfoSet == null)
                {
                    // データが取得できなかった場合は、空白を設定
                    dr[PMKAK09015EA.ct_Col_SumSectionGuideSnm] = string.Empty;
                }
                else
                {
                    // データが取得できたので略称を設定
                    dr[PMKAK09015EA.ct_Col_SumSectionGuideSnm] = secInfoSet.SectionGuideSnm;
                }

                // 総括仕入先コード
                dr[PMKAK09015EA.ct_Col_SumSupplierCd] = rsltInfo.SumSupplierCd;

                // 総括仕入先名
                // キャッシュから該当するデータを取得
                supplier = GetFromCacheForSupplier(rsltInfo.SumSupplierCd);
                if (supplier == null)
                {
                    // データが取得できなかった場合は、空白を設定
                    dr[PMKAK09015EA.ct_Col_SumSupplierNm1] = string.Empty;
                    dr[PMKAK09015EA.ct_Col_SumSupplierNm2] = string.Empty;
                }
                else
                {
                    // データが取得できたので名称１、名称２を設定
                    dr[PMKAK09015EA.ct_Col_SumSupplierNm1] = supplier.SupplierNm1;
                    dr[PMKAK09015EA.ct_Col_SumSupplierNm2] = supplier.SupplierNm2;
                }

                // 拠点コード
                dr[PMKAK09015EA.ct_Col_SectionCd] = rsltInfo.SectionCode;

                // 拠点名
                // キャッシュから該当するデータを取得
                secInfoSet = GetFromCacheForSecInfoSet(rsltInfo.SectionCode);
                if (secInfoSet == null)
                {
                    // データが取得できなかった場合は、空白を設定
                    dr[PMKAK09015EA.ct_Col_SectionGuideSnm] = string.Empty;
                }
                else
                {
                    // データが取得できたので略称を設定
                    dr[PMKAK09015EA.ct_Col_SectionGuideSnm] = secInfoSet.SectionGuideSnm;
                }

                // 仕入先コード
                dr[PMKAK09015EA.ct_Col_SupplierCd] = rsltInfo.SupplierCode;

                // 仕入先名
                // キャッシュから該当するデータを取得
                supplier = GetFromCacheForSupplier(rsltInfo.SupplierCode);
                if (supplier == null)
                {
                    // データが取得できなかった場合は、空白を設定
                    dr[PMKAK09015EA.ct_Col_SupplierNm1] = string.Empty;
                    dr[PMKAK09015EA.ct_Col_SupplierNm2] = string.Empty;
                }
                else
                {
                    // データが取得できたので名称１、名称２を設定
                    dr[PMKAK09015EA.ct_Col_SupplierNm1] = supplier.SupplierNm1;
                    dr[PMKAK09015EA.ct_Col_SupplierNm2] = supplier.SupplierNm2;
                }

                dataTable.Rows.Add(dr);
            }
        }
        #endregion

        #endregion ◆ データ展開処理

        #endregion ■ Private Method
    }
}
