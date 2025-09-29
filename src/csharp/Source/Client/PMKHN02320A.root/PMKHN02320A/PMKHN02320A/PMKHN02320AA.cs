//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : テキスト出力操作ログ登録及び出力時アラートメッセージ表示処理
// プログラム概要   : テキスト出力操作ログ登録及び出力時アラートメッセージ表示処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570163-00  作成担当 : 田建委
// 作 成 日  K2019/08/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11570217-00  作成担当 : 寺田義啓
// 作 成 日  2019/11/15   修正内容 : （修正内容一覧No.1）テキスト出力メッセージ改良
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Data;
using System.Text;
using Microsoft.Win32;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Net.NetworkInformation;

using Broadleaf.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// テキスト出力操作ログ登録及び出力時アラートメッセージ表示処理スクラス
    /// </summary>
    /// <remarks>
    /// Note       : テキスト出力操作ログ登録及び出力時アラートメッセージ表示処理です。<br/>
    /// Programmer : 田建委<br/>
    /// Date       : K2019/08/12<br/>
    /// </remarks>
    public class TextOutPutOprtnHisLogAcs
    {
        # region ■ Constructor ■
        /// <summary>
        /// デフォルトラクタ
        /// </summary>
        /// <remarks>
        /// Note       : デフォルトラクタ<br/>
        /// Programmer : 田建委<br/>
        /// Date       : K2019/08/12<br/>
        /// </remarks>
        public TextOutPutOprtnHisLogAcs()
        {
            // 変数初期化
            this.ITextOutPutOprtnHisLogDBObj = (ITextOutPutOprtnHisLogDB)MediationTextOutPutOprtnHisLogDB.GetDataCopyDB();
        }
        # endregion ■ Constructor ■

        # region ■ Private Members ■
        private ITextOutPutOprtnHisLogDB ITextOutPutOprtnHisLogDBObj;

        /// <summary>
        /// 呼び出し元オブジェクトのアセンブリ情報インデックス列挙体
        /// </summary>
        private enum SenderInfoIdx : int
        {
            /// <summary>ログデータ対象アセンブリID</summary>
            LogDataObjAssemblyID,
            /// <summary>ログデータ対象クラスID</summary>
            LogDataObjClassID,
            /// <summary>ログデータシステムバージョン</summary>
            LogDataSystemVersion
        }
        # endregion ■ Private Members ■

        # region ■ Const Members ■
        /// <summary>最大処理レベル</summary>
        private const int MAX_LEVEL = 99;

        # endregion ■ Const Members ■

        #region ■ テキスト出力操作ログ登録及び出力時アラートメッセージ表示処理 ■

        /// <summary>
        /// アラートメッセージ表示処理
        /// </summary>
        /// <param name="sender">呼び出し元オブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>実行結果状態</returns>
        /// <remarks>
        /// <br>Note       : アラートメッセージ表示処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2019/08/12</br>
        /// </remarks>
        public int ShowTextOutPut(object sender,out string errMsg)
        {
            // 初期ステータス
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // エラーメッセージ
            errMsg = string.Empty;

            try
            {
                // アラート表示
                DialogResult dialogResult = BeforeTextOutput.ShowDialog((IWin32Window)sender);

                // OKボタンを押下す場合
                if (dialogResult == DialogResult.Yes)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMsg = ex.Message;
                this.WriteErrorLog(ex, "TextOutPutOprtnHisLogAcs.ShowTextOutput", status);
            }
            return status;
        }

        /// <summary>
        /// テキスト出力操作ログ登録及び出力時アラートメッセージ表示処理
        /// </summary>
        /// <param name="sender">呼び出し元オブジェクト</param>
        /// <param name="textOutPutOprtnHisLogWorkObj">登録用ワーククラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>実行結果状態</returns>
        /// <remarks>
        /// <br>Note       : テキスト出力操作ログ登録及び出力時アラートメッセージ表示処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2019/08/12</br>
        /// </remarks>
        public int Write(object sender, ref TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj, out string errMsg)
        {
            // 初期ステータス
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // テキスト出力操作ログ登録用ワーク作成
                this.SetTextOutPutOprtnHisLogWork(sender, ref textOutPutOprtnHisLogWorkObj);

                object textOutPutObj = (object)textOutPutOprtnHisLogWorkObj;
                // テキスト出力操作ログ登録
                status = this.ITextOutPutOprtnHisLogDBObj.Write(ref textOutPutObj, out errMsg);

                // アラートメッセージ表示
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    textOutPutOprtnHisLogWorkObj = textOutPutObj as TextOutPutOprtnHisLogWork;
                }
                else
                {
                    // なし
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                this.WriteErrorLog(ex, "TextOutPutOprtnHisLogAcs.Write", status);
                errMsg = ex.Message;
            }
            return status;
        }

        /// <summary>
        /// テキスト出力操作ログ登録用ワークセット
        /// </summary>
        /// <param name="sender">呼び出し元オブジェクト</param>
        /// <param name="textOutPutOprtnHisLogWork">登録用ワーククラス</param>
        /// <remarks>
        /// <br>Note       : テキスト出力操作ログ登録用ワークセット処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2019/08/12</br>
        /// </remarks>
        private void SetTextOutPutOprtnHisLogWork(object sender, ref TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWork)
        {
            try
            {
                // 企業コード
                textOutPutOprtnHisLogWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                // ログデータ作成日時
                if (textOutPutOprtnHisLogWork.LogDataCreateDateTime == DateTime.MinValue)
                {
                    textOutPutOprtnHisLogWork.LogDataCreateDateTime = DateTime.Now;
                }
                // ログイン拠点コード
                textOutPutOprtnHisLogWork.LoginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;
                // ログデータ種別区分コード
                textOutPutOprtnHisLogWork.LogDataKindCd = 0;
                // ログデータ端末名
                textOutPutOprtnHisLogWork.LogDataMachineName = Environment.MachineName;
                // ログデータ担当者コード
                textOutPutOprtnHisLogWork.LogDataAgentCd = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
                // ログデータ担当者名
                textOutPutOprtnHisLogWork.LogDataAgentNm = LoginInfoAcquisition.Employee.Name;
                // ログデータオペレーションコード
                textOutPutOprtnHisLogWork.LogDataOperationCd = 8;

                string[] senderInfos = GetSenderInfo(sender);
                {
                    // ログデータ対象クラスID
                    textOutPutOprtnHisLogWork.LogDataObjClassID = senderInfos[(int)SenderInfoIdx.LogDataObjClassID];

                    // ログデータオペレーターデータ処理レベル
                    if (LoginInfoAcquisition.Employee.AuthorityLevel1 <= MAX_LEVEL)
                    {
                        textOutPutOprtnHisLogWork.LogOperaterDtProcLvl = LoginInfoAcquisition.Employee.AuthorityLevel1.ToString();
                    }
                    else
                    {
                        textOutPutOprtnHisLogWork.LogOperaterDtProcLvl = MAX_LEVEL.ToString();
                    }
                    // ログデータオペレーター機能処理レベル
                    if (LoginInfoAcquisition.Employee.AuthorityLevel2 <= MAX_LEVEL)
                    {
                        textOutPutOprtnHisLogWork.LogOperaterFuncLvl = LoginInfoAcquisition.Employee.AuthorityLevel2.ToString();
                    }
                    else
                    {
                        textOutPutOprtnHisLogWork.LogOperaterFuncLvl = MAX_LEVEL.ToString();
                    }
                    // ログデータシステムバージョン
                    textOutPutOprtnHisLogWork.LogDataSystemVersion = senderInfos[(int)SenderInfoIdx.LogDataSystemVersion];
                }

                // ログオペレーションステータス
                textOutPutOprtnHisLogWork.LogOperationStatus = 0;
            }
            catch (Exception ex)
            {
                this.WriteErrorLog(ex, "TextOutPutOprtnHisLogAcs.SetTextOutPutOprtnHisLogWork", 1000);
            }
        }

        /// <summary>
        /// 呼び出し元オブジェクト情報取得
        /// </summary>
        /// <param name="sender">呼び出し元オブジェクト</param>
        /// <returns>
        /// 呼び出し元オブジェクト情報<br/>
        /// [0]:ログデータ対象アセンブリID<br/>
        /// [1]:ログデータ対象クラスID<br/>
        /// [2]:ログデータシステムバージョン
        /// </returns>
        /// <remarks>
        /// <br>Note       : 呼び出し元オブジェクト情報取得処理を行う</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2019/08/12</br>
        /// </remarks>
        private static string[] GetSenderInfo(object sender)
        {
            string[] senderInfoArray = new string[3] { string.Empty, string.Empty, string.Empty };

            if (sender != null)
            {
                Type senderType = sender.GetType();
                AssemblyName assemblyName = senderType.Assembly.GetName();

                if (assemblyName != null)
                {
                    senderInfoArray[(int)SenderInfoIdx.LogDataObjAssemblyID] = assemblyName.Name;
                    senderInfoArray[(int)SenderInfoIdx.LogDataSystemVersion] = assemblyName.Version.ToString();
                }

                if (senderType != null) senderInfoArray[(int)SenderInfoIdx.LogDataObjClassID] = senderType.Name;
            }

            return senderInfoArray;
        }
        #endregion

        #region ■ エラーログ出力処理 ■
        /// <summary>
        /// エラーログ出力処理
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="errorText">エラー内容</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーログ出力を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2019/08/12</br>
        /// </remarks>
        private void WriteErrorLog(Exception ex, string errorText, int status)
        {
            string message = string.Empty;

            if (ex != null)
            {
                message = string.Concat(new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" });
                new ClientLogTextOut().Output(ex.Source, message, status, ex);
            }
            else
            {
                new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, errorText, status);
            }
        }
        #endregion

    }

    /// <summary>
    /// テキスト出力の確認ダイアログフォームクラス
    /// </summary>
    /// <remarks>
    /// Note       : テキスト出力の確認ダイアログフォーム表示処理<br/>
    /// Programmer : 田建委<br/>
    /// Date       : K2019/08/12<br/>
    /// </remarks>
    public class BeforeTextOutput
    {
        /// <summary>
        /// テキスト出力の確認ダイアログフォームクラスを表示する
        /// </summary>
        /// <param name="owner">親画面対象</param>
        /// <returns>選択結果</returns>
        /// <remarks>
        /// <br>Note       : テキスト出力の確認ダイアログフォームクラスを表示する処理を行う</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2019/08/12</br>
        /// </remarks>
        public static DialogResult ShowDialog(IWin32Window owner)
        {
            DialogResult dlgResult = DialogResult.Cancel;

            try
            {
                // データが複数件存在する場合は選択画面を表示する
                BeforeTextOutputDialog form = new BeforeTextOutputDialog();
                try
                {
                    dlgResult = form.ShowDialog(owner);
                }
                finally
                {
                    form.Dispose();
                    form = null;
                }

            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }

            return dlgResult;
        }
    }
}
