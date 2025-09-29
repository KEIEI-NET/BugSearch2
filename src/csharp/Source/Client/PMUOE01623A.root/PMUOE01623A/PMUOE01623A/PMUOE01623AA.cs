//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 日産回答データ取込処理
// プログラム概要   : UOE発注データと発注回答データのつけ合わせを行い、
//                    売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 李占川
// 作 成 日  2010/03/08  修正内容 : 新規作成
//                                 【要件No.6】UOE発注データと発注回答データのつけ合わせを行い、売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using System.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 日産回答データ取込処理アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 日産回答データ取込処理のアクセス制御を行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2010/03/08</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class UOEOrderDtlNissanAcs
    {
        # region -- プライベート変数 --
        /*----------------------------------------------------------------------------------*/
        private NissanWebUOEOrderDtlInfoBuilder _nissanWebUOEOrderDtlInfoBuilder;
        # endregion

        # region -- プライベート定数 --
        /*----------------------------------------------------------------------------------*/
        private const string COMMASSEMBLY_ID = "0203";
        # endregion

        # region -- コンストラクタ --
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オフライン対応</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public UOEOrderDtlNissanAcs()
        {
            this._nissanWebUOEOrderDtlInfoBuilder = new NissanWebUOEOrderDtlInfoBuilder();
        }
        # endregion

        # region -- 検索処理 --
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="answerDateNissanPara">画面情報</param>
        /// <param name="errMessage">メッセージ</param>
        /// <returns>チェック結果。　0：正常；　-1：異常</returns>
        /// <remarks>
        /// <br>Note       : RCV情報を取得処理する。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public int DoSearch(AnswerDateNissanPara answerDateNissanPara, out string errMessage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // 検索処理
            status = this._nissanWebUOEOrderDtlInfoBuilder.DoSearch(answerDateNissanPara, out errMessage);

            return status;
        }
        # endregion

        # region -- 確定処理 --
        /// <summary>
        /// 確定処理
        /// </summary>
        /// <param name="answerDateNissanPara">画面情報</param>
        /// <param name="errMessage">メッセージ</param>
        /// <returns>チェック結果。　0：正常；　-1：異常</returns>
        /// <remarks>
        /// <br>Note       : 確定処理する。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public int DoConfirm(AnswerDateNissanPara answerDateNissanPara, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 確定処理
            status = this._nissanWebUOEOrderDtlInfoBuilder.DoConfirm(answerDateNissanPara, out errMessage);

            return status;
        }
        # endregion 確定処理

        # region -- キャッシュ処理 --
        /// <summary>
        /// 発注先の算出
        /// </summary>
        /// <param name="outUOESupplierlilst">UOE発注先マスタInfo</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">ログイン拠点</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 発注先の算出処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        public int GetUOESupplier(out ArrayList outUOESupplierlilst, string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // 発注先の算出
            status = this._nissanWebUOEOrderDtlInfoBuilder.GetUOESupplier(out outUOESupplierlilst, enterpriseCode, sectionCode, COMMASSEMBLY_ID);

            return status;
        }
        # endregion

        #region -- 進捗表示 --
        /// <summary>進捗表示用フォームを取得または設定します。</summary>
        public SFCMN00299CA ProgressForm
        {
            get { return _nissanWebUOEOrderDtlInfoBuilder.ProgressForm; }
            set { _nissanWebUOEOrderDtlInfoBuilder.ProgressForm = value; }
        }
        #endregion

        # region -- DataTableの処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 処理結果
        /// </summary>
        /// <value>DetailDataTable</value>
        /// <remarks>
        /// <br>Note       : 処理結果をを取得。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        public DataTable DetailDataTable
        {
            get { return this._nissanWebUOEOrderDtlInfoBuilder.DetailDataTable; }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データセットクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットクリア処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        public void DataTableClear()
        {
            this._nissanWebUOEOrderDtlInfoBuilder.DataTableClear();
        }
        # endregion
    }
}
