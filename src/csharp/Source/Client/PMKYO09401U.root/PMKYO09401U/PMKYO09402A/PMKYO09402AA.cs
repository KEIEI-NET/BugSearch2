//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送信履歴ログメンテ画面アクセスクラス
// プログラム概要   : 送信履歴ログメンテ画面アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 丁建雄
// 作 成 日  2011/08/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2011/08/24  修正内容 : Redmine #23930　ソースレビュー結果対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 送信履歴ログメンテ画面アクセスクラス
    /// </summary>
    /// <remarks>
    /// Note       : 送信履歴ログメンテ画面アクセスクラス<br />
    /// Programmer : 丁建雄<br />
    /// Date       : 2011/08/01<br />
    /// Update     : <br />
    /// </remarks>
    public partial class SndRcvHisAcs
    {
        # region ■ Constructor ■
        public SndRcvHisAcs()
        {
            _ISndRcvHisRFDB = (ISndRcvHisDB)MediationSndRcvHisRFDB.GetSndRcvHisRFDB();
        }
        #endregion ■ Constructor ■

        #region ■ Private Field ■
        private ISndRcvHisDB _ISndRcvHisRFDB = null;
        #endregion ■ Private Field ■

        #region ■ Public Method ■
        /// <summary>
        /// 送受信履歴ログ戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="sndRcvHisCondWork">送受信履歴ログデータワーク</param>
        /// <param name="searchResult">情報LIST</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送受信履歴ログ戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        public int Serch(SndRcvHisCondWork sndRcvHisCondWork, out object searchResult)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            searchResult = new object(); //searchResult1 as object;

            try
            {
                status = this._ISndRcvHisRFDB.Search(sndRcvHisCondWork, out searchResult);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            }
            catch (Exception ex)
            {
				//MessageBox.Show(ex.ToString());// DEL 2011.08.24
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 送受信履歴ログデータを物理削除します
        /// </summary>
        /// <param name="sndRcvHisWorkList">削除する送受信履歴ログデータを含むArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 送受信履歴ログデータを物理削除します</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/08/01</br>
        public int Delete(ref object sndRcvHisWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                status = this._ISndRcvHisRFDB.Delete(ref sndRcvHisWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            }
            catch (Exception ex)
            {
				//MessageBox.Show(ex.ToString());// DEL 2011.08.24
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

		// ADD 2011.08.24 ------------->>>>>
		/// <summary>
		/// 拠点情報を取得
		/// </summary>
		/// <param name="sectionCode"></param>
		/// <returns></returns>
		public string GetSetctionName(string sectionCode)
		{
			string sectionName = null;

			SecInfoAcs secInfoAcs = new SecInfoAcs();
			try
			{
				foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
				{
					if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
					{
						sectionName = secInfoSet.SectionGuideNm.Trim();
						break;
					}
				}
			}
			catch
			{
				sectionName = string.Empty;
			}

			return sectionName;
		}

		/// <summary>
		/// DateTimeの日時はStringにする
		/// </summary>
		/// <param name="dateTime">DateTimeの日時</param>
		/// <returns>Stringの日時</returns>
		/// <remarks>
		/// <br>Note       : DateTimeの日時はStringにする</br>
		/// <br>Programmer : 丁建雄</br>
		/// <br>Date       : 2011/08/01</br>
		/// </remarks>
		public string DateTimeFormatToString(DateTime dateTime)
		{
			string time = null;
			time += dateTime.Year + "年";
			time += dateTime.Month + "月";
			time += dateTime.Day + "日";
			time += dateTime.Hour + "時";
			time += dateTime.Minute + "分";
			time += dateTime.Second + "秒";

			return time;
		}
		// ADD 2011.08.24 -------------<<<<<
        #endregion ■ Public Method ■
    }
}