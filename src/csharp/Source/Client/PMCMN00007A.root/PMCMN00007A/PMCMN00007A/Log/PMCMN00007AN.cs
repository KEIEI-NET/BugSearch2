//****************************************************************************//
// システム         : セキュリティ管理
// プログラム名称   : 操作権限取得部品
// プログラム概要   : 以下のクラスのFacade(窓口)となります。
//                  : ・操作履歴リモート
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/08/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Log
{
    using DBRecordType = OprtnHisLogWork;

    /// <summary>
    /// オフライン用ロガークラス
    /// </summary>
    internal sealed class OfflineLogger //: IOprtnHisLogDB ←リモートのインターフェースを実装するのは禁止
    {
        #region <IOprtnHisLogDB メンバ/>

        #region <何もしない/>

        /// <see cref="IOprtnHisLogDB"/>
        public int Delete(object oprtnHisLogWork)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int LogicalDelete(ref object oprtnHisLogWork)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int Read(ref object oprtnHisLogWork, int readMode)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int RevivalLogicalDelete(ref object oprtnHisLogWork)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int Search(
            ref object oprtnHisLogWork,
            object oprtnHisLogSrchWork,
            int readMode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode
        )
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        #endregion  // <何もしない/>

        /// <see cref="IOprtnHisLogDB"/>
        public int Write(ref object oprtnHisLogWork)
        {
            #region <Guard Phrase/>

            if (oprtnHisLogWork == null) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            #endregion  // <Guard Phrase/>

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList workList = oprtnHisLogWork as ArrayList;
            if (workList != null)
            {
                DBRecordType[] oprtnHisLogWorkArray = workList.ToArray(typeof(DBRecordType)) as DBRecordType[];

                string filePath = Path.Combine(Directory.GetCurrentDirectory(), FolderPath);
                string fileName = String.Format("Client{0}{1}.log", DateTime.Now.Ticks, Guid.NewGuid());

                // シリアライズ
                UserSettingController.SerializeUserSetting(oprtnHisLogWorkArray, Path.Combine(filePath, fileName));

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }

        #endregion  // <IOprtnHisLogDB メンバ/>

        /// <summary>オフライン時のデフォルト出力フォルダパス</summary>
        public const string DEFAULT_FOLDER_PATH = "Log\\Operation";

        /// <summary>フォルダパス</summary>
        private readonly string _folderPath;
        /// <summary>
        /// フォルダパスを取得します。
        /// </summary>
        /// <value>フォルダパス</value>
        public string FolderPath
        {
            get { return _folderPath; }
        }

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public OfflineLogger() : this(DEFAULT_FOLDER_PATH) { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="folderPath">フォルダパス</param>
        public OfflineLogger(string folderPath)
        {
            _folderPath = folderPath;
        }

        #endregion  // <Constructor/>

        #region <旧メソッド（オリジナル）/>
        
        /// <summary>
        /// 操作履歴ログオフラインデータ登録
        /// </summary>
        /// <param name="workobj">>対象オブジェクト</param>
        /// <remarks>
        /// <br>Note       : オフラインデータを登録します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.12.18</br>
        /// </remarks>
        [Obsolete("旧メソッド（オリジナル）")]
        private int WriteOffline(object workobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                if (workobj == null) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                ArrayList workList = workobj as ArrayList;
                if (workList != null)
                {
                    OprtnHisLogWork[] oprtnHisLogWorkArray = workList.ToArray(typeof(OprtnHisLogWork)) as OprtnHisLogWork[];

                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), DEFAULT_FOLDER_PATH);
                    string fileName = String.Format("Client{0}{1}.log", DateTime.Now.Ticks, Guid.NewGuid());

                    // シリアライズ
                    UserSettingController.SerializeUserSetting(oprtnHisLogWorkArray,
                        Path.Combine(filePath, fileName));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception)
            {
            }

            return status;
        }

#if DEBUG
        private DateTime _dtime_s, _dtime_e;
        private System.IO.FileStream _fs = null;
        private System.IO.StreamWriter _sw = null;

        [Obsolete("旧メソッド（オリジナル）")]
        private void DebugLogWrite(int mode, string msg)
        {
            this._fs = new System.IO.FileStream("MACMN00110C_Log.txt", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
            this._sw = new System.IO.StreamWriter(this._fs, System.Text.Encoding.GetEncoding("shift_jis"));
            if (mode == 0)
            {

                this._dtime_s = DateTime.Now;
                TimeSpan ts = this._dtime_s.Subtract(this._dtime_s);
                string s = String.Format("{0,-20} {1,-5} ==> {2,-20} [0] {3} \n",
                    this._dtime_s, this._dtime_s.Millisecond, ts.ToString(), msg);
                this._sw.WriteLine(s);
            }
            else if (mode == 1)
            {
                this._dtime_e = DateTime.Now;
                TimeSpan ts = this._dtime_e.Subtract(this._dtime_s);
                string s = string.Format("{0,-20} {1,-5} ==> {2,-20} [1] {3} \n",
                    this._dtime_e, this._dtime_e.Millisecond, ts.ToString(), msg);

                this._sw.WriteLine(s);

                this._dtime_s = this._dtime_e;
            }
            else if (mode == 9)
            {
            }
            this._sw.Close();
            this._fs.Close();
        }
#endif
        #endregion  // <旧メソッド（オリジナル）/>
    }

    /// <summary>
    /// 何もしないオンラインロガークラス
    /// </summary>
    internal sealed class NullOnlineLogger //: IOprtnHisLogDB ←リモートのインターフェースを実装するのは禁止
    {
        #region <IOprtnHisLogDB メンバ/>

        /// <see cref="IOprtnHisLogDB"/>
        public int Delete(object oprtnHisLogWork)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int LogicalDelete(ref object oprtnHisLogWork)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int Read(ref object oprtnHisLogWork, int readMode)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int RevivalLogicalDelete(ref object oprtnHisLogWork)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int Search(
            ref object oprtnHisLogWork,
            object oprtnHisLogSrchWork,
            int readMode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode
        )
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <see cref="IOprtnHisLogDB"/>
        public int Write(ref object oprtnHisLogWork)
        {
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        #endregion  // <IOprtnHisLogDB メンバ/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public NullOnlineLogger() { }
    }
}
