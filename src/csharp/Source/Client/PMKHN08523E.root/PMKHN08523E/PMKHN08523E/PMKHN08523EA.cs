﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
//using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.UIData
{

    /// <summary>
    /// 従業員マスタ（印刷）クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 従業員マスタ（印刷）UIフォームクラス</br>
    /// <br>Programmer : 30462 行澤 仁美</br>
    /// <br>Date       : 2008.10.30</br>
    /// <br></br>
    /// <br>UpdateNote : </br>
    /// <br>           : </br>
    /// </remarks>
    public class PMKHN08523EA : IExtrProc
    {
        #region ■ Constructor
		/// <summary>
		/// 従業員マスタ（印刷）クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 従業員マスタ（印刷）UIクラス</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.30</br>
		/// <br></br>
		/// </remarks>
        public PMKHN08523EA( object printInfo )
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
        }
        #endregion ■ Constructor

        #region ■ private member
        private SFCMN06002C _printInfo = null;			                        // 印刷情報クラス
        #endregion ■ private member

        #region ■ private const
        private const string ct_PGID = "PMKHN08523E";
        #endregion ■ private const


        #region ■ IExtrProc メンバ
		#region ◆ Public Property
		/// <summary>
		/// 印刷情報クラスプロパティ
		/// </summary>
		public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
		}
		#endregion ◆ Public Property

		#region ◆ Public Method
		#region ◎ 抽出処理
		/// <summary>
        /// 抽出処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷のメイン処理を行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.30</br>
        /// </remarks>
        public int ExtrPrintData()
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // 抽出中画面部品のインスタンスを作成
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "抽出中";
            form.Message = "現在、データを抽出中です。";
            
			try
			{
                form.Show();			    // ダイアログ表示
                status = this.ExtraProc();	// 抽出処理実行
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
                this._printInfo.status = status;
            }

            return status;
		}
		#endregion
		#endregion ◆ Public Method
		#endregion ■ IExtrProc メンバ

		#region ■ Private Method
		#region ◆ 抽出メイン処理
		/// <summary>
        /// 抽出メイン処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出のメイン処理を行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.30</br>
        /// </remarks>
        private int ExtraProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if ((this._printInfo.rdData as DataView).Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }


            return status;
		}
		#endregion ◆ 抽出メイン処理

		#region ◆ エラーメッセージ表示
		/// <summary>
        /// エラーメッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">エラーステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">初期フォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージを表示します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.30</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
		#endregion ◆ エラーメッセージ表示
        #endregion
	}
}
