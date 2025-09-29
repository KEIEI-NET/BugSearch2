//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自動起動サービス処理
// プログラム概要   : 自動起動サービスのファイルを更新する
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/09/01  修正内容 : #24278 データ自動受信処理が起動しません
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2014/10/02  修正内容 : ツールチェックの修正
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Microsoft.Win32;
using System.IO;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 受信データフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : なし。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.04.29</br>
    /// </remarks>
    public class ServiceFilesInputAcs
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private ServiceFilesInputAcs()
        {
            _conf = new conf();
            _commConf = new conf(); // ADD 譚洪 2014/10/02 
            _secInfo = new secInfo();//ADD 2011/09/01 #24278
        }
        
        /// <summary>
        /// アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>アクセスクラス インスタンス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public static ServiceFilesInputAcs GetInstance()
        {
            if (_serviceFilesInputAcs == null)
            {
                _serviceFilesInputAcs = new ServiceFilesInputAcs();
            }

            return _serviceFilesInputAcs;
        }
        #endregion


        // ===================================================================================== //
        // プライベート変数2
        // ===================================================================================== //
        # region ■Private Members
        private conf _conf = null;
        private conf _commConf = null; // ADD 譚洪 2014/10/02 
        private static ServiceFilesInputAcs _serviceFilesInputAcs = null;
        private IServiceFilesDB _serviceFilesDB = null;
        private secInfo _secInfo = null;//ADD 2011/09/01 #24278
        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region ■Properties
        /// <summary>
        /// テーブルオブジェクトを取得します。
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public conf Conf
        {
            get
            {
                return this._conf;
            }
        }

        // ---- ADD 譚洪 2014/10/02 ---------------------------->>>>>
        /// <summary>
        /// テーブルオブジェクトを取得します。
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public conf CommConf
        {
            get
            {
                return this._commConf;
            }
        }
        // ---- ADD 譚洪 2014/10/02 ----------------------------<<<<<

        //ADD 2011/09/01 #24278-------------->>>>>
        /// <summary>
        /// テーブルオブジェクトを取得します。
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.09.01</br>
        /// </remarks>
        public secInfo SecInfo
        {
            get
            {
                return this._secInfo;
            }
        }
        //ADD 2011/09/01 #24278--------------<<<<<
        #endregion


        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region ■Private Methods
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <param name="fileFlg">ファイルフラグ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public int Search(ref string msg, ref int fileFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (_serviceFilesDB == null)
            {
                _serviceFilesDB = MediationServiceFilesDB.GetServiceFilesDB();
            }

            // ファイル
            object serviceFilesWork = (object)new ServiceFilesWork();


            status = _serviceFilesDB.Read(ref serviceFilesWork, ref msg, ref fileFlg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ServiceFilesWork serviceWork = (ServiceFilesWork)serviceFilesWork;

                try
                {
                    MemoryStream ms = new MemoryStream(serviceWork.FileContent);
                    _conf.ReadXml(ms);
                }
                catch
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    msg = "XMLファイルの内容が不正です。";
                    return status;
                }

                // 情報を変更
                foreach (conf.ConfRow row in _conf.Conf)
                {
                    row.ChkStTime = GetFormatDate(row.ChkStTime);
                    row.ChkEdTime = GetFormatDate(row.ChkEdTime);
                }
            }

            return status;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <param name="fileFlg">ファイルフラグ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.09.01</br>
        /// </remarks>
        public int SearchForAutoSendRecv(ref string msg, ref int fileFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (_serviceFilesDB == null)
            {
                _serviceFilesDB = MediationServiceFilesDB.GetServiceFilesDB();
            }

            // ファイル
            object serviceFilesWork = (object)new ServiceFilesWork();


            status = _serviceFilesDB.Read(ref serviceFilesWork, ref msg, ref fileFlg, 1);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ServiceFilesWork serviceWork = (ServiceFilesWork)serviceFilesWork;

                try
                {
                    _secInfo.Clear();
                    MemoryStream ms = new MemoryStream(serviceWork.FileContent);
                    _secInfo.ReadXml(ms);
                }
                catch
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    msg = "XMLファイルの内容が不正です。";
                    return status;
                }
            }

            return status;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public int SaveData()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 空白行を削除する
            ArrayList confRows = new ArrayList();
            //conf.ConfRow[] confRows = new conf.ConfRow[];
                //this.SelectConfRows(this._conf.Conf.PgIdColumn.ColumnName
                //+ "= '" + string.Empty + "'", this._conf.Conf);

            foreach (conf.ConfRow row in this._conf.Conf)
            {
                if (string.IsNullOrEmpty(row.PgId))
                {
                    confRows.Add(row);
                }
            }

            // 情報を準備します
            foreach(conf.ConfRow row in confRows)
            {
                this._conf.Conf.RemoveConfRow(row);
            }

            // 日時フォーマット
            foreach (conf.ConfRow row in _conf.Conf)
            {
                if (!string.IsNullOrEmpty(row.ChkStTime))
                {
                    row.ChkStTime = SetFormatDate(row.ChkStTime);
                    row.ChkEdTime = SetFormatDate(row.ChkEdTime);
                }
            }
            //ADD 2011/09/01 #24278 データ自動受信処理が起動しません---------->>>>>
            _secInfo.SecInfo.Clear();
            secInfo.SecInfoRow secRow = _secInfo.SecInfo.NewSecInfoRow();
            secRow.BelongSec = LoginInfoAcquisition.Employee.BelongSectionCode;
            _secInfo.SecInfo.Rows.Add(secRow);
            string secXml = _secInfo.GetXml();
            byte[] secTmp = Encoding.Default.GetBytes(secXml);
            //ADD 2011/09/01 #24278 データ自動受信処理が起動しません----------<<<<<
            // ファイルを保存する
            string xml = _conf.GetXml();
            byte[] tmp = Encoding.Default.GetBytes(xml);

            if (_serviceFilesDB == null)
            {
                _serviceFilesDB = MediationServiceFilesDB.GetServiceFilesDB();
            }

            ServiceFilesWork serviceFilesWork = new ServiceFilesWork();
            serviceFilesWork.FileContent = tmp;
            object file = (object)serviceFilesWork;

            status = _serviceFilesDB.Write(file);

            //ADD 2011/09/01 #24278 データ自動受信処理が起動しません---------->>>>>
            serviceFilesWork.FileContent = secTmp;
            object secFile = (object)serviceFilesWork;
            status = _serviceFilesDB.Write(secFile, 1);
            //ADD 2011/09/01 #24278 データ自動受信処理が起動しません----------<<<<<

            // 日時フォーマット
            foreach (conf.ConfRow row in _conf.Conf)
            {
                if (!string.IsNullOrEmpty(row.ChkStTime))
                {
                    row.ChkStTime = GetFormatDate(row.ChkStTime);
                    row.ChkEdTime = GetFormatDate(row.ChkEdTime);
                }
            }

            return status;
        }

        /// <summary>
        /// DateTimeフォーマット
        /// </summary>
        /// <param name="value">日時</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private string GetFormatDate(string value)
        {
            string result = "";

            // length判断
            if (value.Length == 4)
            {
                result = value.Substring(0, 2) + ":" + value.Substring(2, 2);
            }
            else if (value.Length == 3)
            {
                result = "0" + value.Substring(0, 1) + ":" + value.Substring(1, 2);
            }
            else if (value.Length == 2)
            {
                result = "00:" + value;
            }
            else if (value.Length == 1)
            {
                result = "00:0" + value;
            }
            else
            {
                result = "00:00";
            }

            // 日時範囲不正
            if (Convert.ToInt32(result.Substring(0, 2)) > 23 || Convert.ToInt32(result.Substring(3, 2)) > 59)
            {
                result = "00:00";
            }

            return result;
        }

        /// <summary>
        /// DateTimeフォーマット
        /// </summary>
        /// <param name="value">日時</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private string SetFormatDate(string value)
        {
            string result = "";

            // フォーマット
            if (value.Length == 4)
            {
                int i = 0;
                for (i = 0; i < 4; i++)
                {
                    if (!"0".Equals(value.Substring(i, 1)))
                    {
                        break;
                    }
                }

                // 結果を戻す
                if (i == 4)
                {
                    result = "0";
                }
                else
                {
                    result = value.Substring(i);
                }
            }
            else
            {
                result = "0";
            }

            return result;
        }

        /// <summary>
        /// 比較関数
        /// </summary>
        /// <typeparam name="T">型指定</typeparam>
        /// <param name="condition">条件</param>
        /// <param name="valueOnTrue">Trueの時の値</param>
        /// <param name="valueOnFalse">Falseの時の値</param>
        /// <returns>条件により選択された値</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        static public T diverge<T>(bool condition, T valueOnTrue, T valueOnFalse)
        {
            if (condition)
            {
                return valueOnTrue;
            }
            else
            {
                return valueOnFalse;
            }
        }

        /// <summary>
        /// 指定したフィルタ文字列を使用してデータテーブルの選択を行い、該当する行オブジェクト配列を取得します。
        /// </summary>
        /// <param name="filterExpression">フィルタをかけるための基準となる文字列</param>
        /// <param name="confTable">データテーブルオブジェクト</param>
        /// <returns>売上明細行オブジェクト配列</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public conf.ConfRow[] SelectConfRows(string filterExpression, conf.ConfDataTable confTable)
        {
            conf.ConfRow[] confRowArray = null;

            try
            {
                DataRow[] rowArray = confTable.Select(filterExpression);

                if (rowArray != null)
                {
                    confRowArray = (conf.ConfRow[])rowArray;
                }
            }
            catch { }

            return confRowArray;
        }

        /// <summary>
        /// 自拠点名称取得得処理
        /// </summary>
        /// <returns>自拠点名称</returns>
        public string GetOwnSectionName(string loginSectionCode)
        {
            string ownSectionName = string.Empty;

            // 自拠点の取得
            SecInfoAcs _secInfoAcs = new SecInfoAcs();
            SecInfoSet secInfoSet;
            _secInfoAcs.GetSecInfo(loginSectionCode, out secInfoSet);
            if (secInfoSet != null)
            {
                // 自拠点コードの保存
                ownSectionName = secInfoSet.SectionGuideNm;
            }

            return ownSectionName;
        }
        #endregion

        // ---- ADD 譚洪 2014/10/02 ---------------------------->>>>>
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <param name="fileFlg">ファイルフラグ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public int SearchAll(ref string msg, ref int fileFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (_serviceFilesDB == null)
            {
                _serviceFilesDB = MediationServiceFilesDB.GetServiceFilesDB();
            }

            // ファイル
            object userServiceFilesWork = (object)new ServiceFilesWork();
            object commServiceFilesWork = (object)new ServiceFilesWork();


            status = _serviceFilesDB.Read(ref userServiceFilesWork, ref commServiceFilesWork, ref msg, ref fileFlg);
            
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ServiceFilesWork userServiceWork = (ServiceFilesWork)userServiceFilesWork;
                ServiceFilesWork commServiceWork = (ServiceFilesWork)commServiceFilesWork;
                try
                {
                    MemoryStream ms = new MemoryStream(userServiceWork.FileContent);
                    _conf.ReadXml(ms);

                    MemoryStream commMs = new MemoryStream(commServiceWork.FileContent);
                    _commConf.ReadXml(commMs);
                }
                catch
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    msg = "XMLファイルの内容が不正です。";
                    return status;
                }

                // 情報を変更
                foreach (conf.ConfRow row in _conf.Conf)
                {
                    row.ChkStTime = GetFormatDate(row.ChkStTime);
                    row.ChkEdTime = GetFormatDate(row.ChkEdTime);
                }
            }

            return status;
        }
        // ---- ADD 譚洪 2014/10/02 ----------------------------<<<<<
    }
}
