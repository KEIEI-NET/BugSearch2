//****************************************************************************//
// システム         : プリンタ設定マスタ（サーバ用）
// プログラム名称   : プリンタ設定マスタ（サーバ用）コントローラ
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/09/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using Broadleaf.Application.Controller.Other;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Other;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller
{
    using DataSetType= ServerPrinterSettingDataSet;
    using RecordType = PrtManage;

    /// <summary>
    /// プリンタ設定マスタ（サーバ用）コントローラクラス
    /// </summary>
    public sealed class ServerPrinterSettingController : ServerConfiguratorController<DataSetType>
    {
        #region <プリンタ設定マスタ（サーバ用）>

        /// <summary>ロードしたプリンタ設定マスタ（サーバ用）データのリスト</summary>
        private List<RecordType> _loadedServerPrinterSettingList;
        /// <summary>ロードしたプリンタ設定マスタ（サーバ用）データのリストを取得または設定します。</summary>
        private List<RecordType> LoadedServerPrinterSettingList
        {
            get
            {
                if (_loadedServerPrinterSettingList == null)
                {
                    _loadedServerPrinterSettingList = new List<PrtManage>();
                }
                return _loadedServerPrinterSettingList;
            }
            set { _loadedServerPrinterSettingList = value; }
        }

        #endregion // </プリンタ設定マスタ（サーバ用）>

        #region <Override>

        /// <summary>
        /// 自身のDBをロードします。
        /// </summary>
        protected override DataSetType LoadOwnDB()
        {
            return LoadServerPrinterSettingMaster();
        }

        /// <summary>
        /// 選択しているレコードを書込みます。
        /// </summary>
        protected override void WriteSelectedRecord()
        {
            WriteSelectedServerPrinterSettingRecord();
        }

        /// <summary>
        /// 選択しているレコードを論理削除します。
        /// </summary>
        protected override void DeleteSelectedRecord()
        {
            DeleteSelectedServerPrinterSettingRecord();
        }

        /// <summary>
        /// 選択しているレコードを復活させます。
        /// </summary>
        protected override void ReviveSelectedRecord()
        {
            ReviveSelectedServerPrinterSettingRecord();
        }

        /// <summary>
        /// 選択しているレコードを物理削除します。
        /// </summary>
        protected override void DestroySelectedRecord()
        {
            DestroySelectedServerPrinterSettingRecord();
        }

        /// <summary>
        /// 他のDBをインポートします。
        /// </summary>
        protected override DataSetType ImportOtherDB()
        {
            return ImportPrtManageMaser();
        }

        #endregion // </Override>

        #region <処理条件>

        /// <summary>nullとみなすプリンタ管理No</summary>
        public const int NULL_PRINTER_MNG_NO = -1;

        /// <summary>処理するレコード</summary>
        private RecordType _doingRecord;
        /// <summary>処理するレコードを取得または設定します。</summary>
        public RecordType DoingRecord
        {
            get { return _doingRecord; }
            set { _doingRecord = value; }
        }

        /// <summary>
        /// 処理するレコードを設定します。
        /// </summary>
        /// <param name="printerMngNo">プリンタ管理No</param>
        public void SetDoingRecord(int printerMngNo)
        {
            DoingRecord = Find(printerMngNo);
        }

        /// <summary>処理結果コード</summary>
        private int _doneStatus;
        /// <summary>処理結果コードを取得または設定します。</summary>
        public int DoneStatus
        {
            get { return _doneStatus; }
            set { _doneStatus = value; }
        }

        /// <summary>
        /// 処理条件をリセットします。
        /// </summary>
        private void ResetDoing()
        {
            DoingRecord = null;
        }

        #endregion // </処理条件>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public ServerPrinterSettingController() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="printerMngNo">プリンタ管理No</param>
        /// <returns>該当するプリンタ設定マスタデータ ※該当するものがない場合、<c>null</c>を返します。</returns>
        public RecordType Find(int printerMngNo)
        {
            RecordType foundRecord = LoadedServerPrinterSettingList.Find(
                delegate(RecordType item)
                {
                    return item.PrinterMngNo.Equals(printerMngNo);
                }
            );
            if (foundRecord != null)
            {
                return foundRecord;
            }
            return null;
        }

        /// <summary>
        /// 存在するか判断します。
        /// </summary>
        /// <param name="printerName">プリンタ名</param>
        /// <param name="foundPrinterMngNo">検索されたプリンタ管理No ※存在しない場合、<c>0</c>を返します。</param>
        /// <returns>
        /// <c>true</c> :存在します。<br/>
        /// <c>false</c>:存在しません。
        /// </returns>
        public bool Exists(
            string printerName,
            out int foundPrinterMngNo
        )
        {
            foundPrinterMngNo = 0;

            int foundIndex = LoadedServerPrinterSettingList.FindIndex(
                delegate(RecordType item)
                {
                    return item.PrinterName.Trim().Equals(printerName.Trim());
                }
            );
            if (foundIndex >= 0)
            {
                foundPrinterMngNo = LoadedServerPrinterSettingList[foundIndex].PrinterMngNo;
                return true;
            }

            return false;
        }

        #region <読み>

        /// <summary>
        /// プリンタ設定マスタ（サーバ用）をロードします。
        /// </summary>
        /// <returns>ロードしたデータセット</returns>
        private DataSetType LoadServerPrinterSettingMaster()
        {
            // 従来のプリンタ設定マスタ（クライアント用）と同じマスタ（XMLファイル）を扱う
            return ImportPrtManageMaser();
        }

        /// <summary>
        /// プリンタ設定マスタをインポートします。
        /// </summary>
        /// <returns>インポートしたしたデータセット</returns>
        private DataSetType ImportPrtManageMaser()
        {
            DataSetType db = new DataSetType();
            {
                LoadedServerPrinterSettingList = PrtManageAcs.SearchFromPrtManageMaster(EnterpriseCode);
                {
                    foreach (PrtManage prtManage in LoadedServerPrinterSettingList)
                    {
                        db.AddPrtManage(prtManage);
                    }
                }
            }
            return db;
        }

        /// <summary>
        /// リロードします。
        /// </summary>
        private void ReLoad()
        {
            Load();
        }

        #endregion // </読み>

        #region <書き>

        /// <summary>
        /// 選択しているプリンタ設定マスタ（サーバ用）のレコードを書込みます。
        /// </summary>
        /// <remarks>
        /// 処理後、<c>DoingRecord</c>はクリアされます。
        /// </remarks>
        private void WriteSelectedServerPrinterSettingRecord()
        {
            if (DoingRecord == null) return;

            try
            {
                DoneStatus = PrtManageAcs.WriteToPrtManageMaster(ref _doingRecord);
                if (DoneStatus.Equals((int)ResultCode.Normal))
                {
                    ReLoad();   // マスタが変化したので、再読込み
                    RaiseUpdateViewEvent(this, CreateUpdateViewEventArgs());
                }
                else
                {
                    Debug.Assert(DoneStatus.Equals((int)ResultCode.Normal), DoneStatus.ToString());
                }
            }
            finally
            {
                ResetDoing();
            }
        }

        #endregion // </書き>

        #region <消し>

        /// <summary>
        /// 選択しているプリンタ設定マスタ（サーバ用）のレコードを論理削除します。
        /// </summary>
        /// <remarks>
        /// 処理後、<c>DoingRecord</c>はクリアされます。
        /// </remarks>
        private void DeleteSelectedServerPrinterSettingRecord()
        {
            if (DoingRecord == null) return;

            try
            {   
                DoneStatus = PrtManageAcs.DeleteLogicallyFromPrtManageMaster(ref _doingRecord);
                if (DoneStatus.Equals((int)ResultCode.Normal))
                {
                    ReLoad();   // マスタが変化したので、再読込み
                    RaiseUpdateViewEvent(this, CreateUpdateViewEventArgs());
                }
                else
                {
                    Debug.Assert(DoneStatus.Equals((int)ResultCode.Normal), DoneStatus.ToString());
                }
            }
            finally
            {
                ResetDoing();
            }
        }

        /// <summary>
        /// 選択しているプリンタ設定マスタ（サーバ用）のレコードを物理削除します。
        /// </summary>
        /// <remarks>
        /// 処理後、<c>DoingRecord</c>はクリアされます。
        /// </remarks>
        private void DestroySelectedServerPrinterSettingRecord()
        {
            if (DoingRecord == null) return;

            try
            {
                DoneStatus = PrtManageAcs.DeletePhysicallyFromPrtManageMaster(_doingRecord);
                if (DoneStatus.Equals((int)ResultCode.Normal))
                {
                    ReLoad();   // マスタが変化したので、再読込み
                    RaiseUpdateViewEvent(this, CreateUpdateViewEventArgs());
                }
                else
                {
                    Debug.Assert(DoneStatus.Equals((int)ResultCode.Normal), DoneStatus.ToString());
                }
            }
            finally
            {
                ResetDoing();
            }
        }

        #endregion // </消し>

        #region <戻し>

        /// <summary>
        /// 選択しているプリンタ設定マスタ（サーバ用）のレコードを復活させます。
        /// </summary>
        /// <remarks>
        /// 処理後、<c>DoingRecord</c>はクリアされます。
        /// </remarks>
        private void ReviveSelectedServerPrinterSettingRecord()
        {
            if (DoingRecord == null) return;

            try
            {
                DoneStatus = PrtManageAcs.ReviveIntoPrtManageMaster(ref _doingRecord);
                if (DoneStatus.Equals((int)ResultCode.Normal))
                {
                    ReLoad();   // マスタが変化したので、再読込み
                    RaiseUpdateViewEvent(this, CreateUpdateViewEventArgs());
                }
                else
                {
                    Debug.Assert(DoneStatus.Equals((int)ResultCode.Normal), DoneStatus.ToString());
                }
            }
            finally
            {
                ResetDoing();
            }
        }

        #endregion // <戻し>

        #region <表示更新>

        /// <summary>
        /// 表示更新イベントパラメータを生成します。
        /// </summary>
        /// <returns>表示更新イベントパラメータ</returns>
        private static UpdateViewEventArgs CreateUpdateViewEventArgs()
        {
            return new UpdateViewEventArgs();
        }

        #endregion // </表示更新>
    }
}
