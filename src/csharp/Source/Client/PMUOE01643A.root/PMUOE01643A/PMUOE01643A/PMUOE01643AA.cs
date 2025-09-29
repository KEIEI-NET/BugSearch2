//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マツダ回答データ取込処理
// プログラム概要   : UOE発注データと発注回答データのつけ合わせを行い、
//                    売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10702591-00 作成担当 : 曹文傑
// 作 成 日  2011/05/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using System.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// マツダ回答データ取込処理アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : マツダ回答データ取込処理のアクセス制御を行います。</br>
    /// <br>Programmer : 曹文傑</br>
    /// <br>Date       : 2011/05/18</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class UOEOrderDtlMazdaAcs
    {
        # region -- プライベート変数 --
        /*----------------------------------------------------------------------------------*/
        private MazdaWebUOEOrderDtlInfoBuilder _mazdaWebUOEOrderDtlInfoBuilder;
        # endregion

        # region -- プライベート定数 --
        /*----------------------------------------------------------------------------------*/
        private const string COMMASSEMBLY_ID = "0403";
        # endregion

        # region -- コンストラクタ --
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オフライン対応</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public UOEOrderDtlMazdaAcs()
        {
            this._mazdaWebUOEOrderDtlInfoBuilder = new MazdaWebUOEOrderDtlInfoBuilder();
        }
        # endregion

        # region -- 検索処理 --
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="answerDateMazdaPara">画面情報</param>
        /// <param name="errMessage">メッセージ</param>
        /// <returns>チェック結果。　0：正常；　-1：異常</returns>
        /// <remarks>
        /// <br>Note       : MLG情報を取得処理する。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public int DoSearch(AnswerDateMazdaPara answerDateMazdaPara, out string errMessage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // 検索処理
            status = this._mazdaWebUOEOrderDtlInfoBuilder.DoSearch(answerDateMazdaPara, out errMessage);

            return status;
        }
        # endregion

        # region -- 確定処理 --
        /// <summary>
        /// 確定処理
        /// </summary>
        /// <param name="answerDateMazdaPara">画面情報</param>
        /// <param name="errMessage">メッセージ</param>
        /// <returns>チェック結果。　0：正常；　-1：異常</returns>
        /// <remarks>
        /// <br>Note       : 確定処理する。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public int DoConfirm(AnswerDateMazdaPara answerDateMazdaPara, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 確定処理
            status = this._mazdaWebUOEOrderDtlInfoBuilder.DoConfirm(answerDateMazdaPara, out errMessage);

            // 確定処理後に発注回答ファイルを削除
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // 指定したファイルを削除します。指定したファイルが存在しない場合、例外はスローされません。
                File.Delete(answerDateMazdaPara.AnswerSaveFolder + "\\HATTU.MLG");
            }

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
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public int GetUOESupplier(out ArrayList outUOESupplierlilst, string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // 発注先の算出
            status = this._mazdaWebUOEOrderDtlInfoBuilder.GetUOESupplier(out outUOESupplierlilst, enterpriseCode, sectionCode, COMMASSEMBLY_ID);

            return status;
        }
        # endregion

        #region -- 進捗表示 --
        /// <summary>進捗表示用フォームを取得または設定します。</summary>
        public SFCMN00299CA ProgressForm
        {
            get { return _mazdaWebUOEOrderDtlInfoBuilder.ProgressForm; }
            set { _mazdaWebUOEOrderDtlInfoBuilder.ProgressForm = value; }
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
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public DataTable DetailDataTable
        {
            get { return this._mazdaWebUOEOrderDtlInfoBuilder.DetailDataTable; }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データセットクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットクリア処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void DataTableClear()
        {
            this._mazdaWebUOEOrderDtlInfoBuilder.DataTableClear();
        }
        # endregion
    }
}
