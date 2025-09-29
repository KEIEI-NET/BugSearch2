using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 列表示状態クラスコレクションクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 列表示状態クラスのコレクションクラスです。</br>
    /// <br>Programmer : 肖緒徳</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2010.04.26 肖緒徳 新規作成</br>
    /// <br>2010.05.20 葛軍 RedMine#8049</br>
    /// </remarks>
    internal class ColDisplayStatusList
    {

        #region Constructor
        /// <summary>
        /// 列表示状態クラスコレクションクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスコレクションクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public ColDisplayStatusList()
        {
            // 各種インスタンス化
            this._colDisplayStatusList = new List<ColDisplayStatusExp>();
            this._colDisplayStatusDictionary = new Dictionary<string, ColDisplayStatusExp>();
            this._colDisplayStatusInitDictionary = new Dictionary<string, ColDisplayStatusExp>();
            this._colDisplayStatusKeyList = new List<string>();
            PMJKN09011UC detailTable = new PMJKN09011UC();
            // 初期列表示状態リスト生成
            List<ColDisplayStatusExp> initStatusList = new List<ColDisplayStatusExp>();

            int visiblePosition = 0;

            // 上下１段
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_NO_TITLE, visiblePosition++, true, 84, 2, 0, 0, 44, 4, "", "", false, false, false));
            //-------START MODIFY 2010.05.20 GEJUN FOR Redmine 8049--------------->>>>>>>
            // 上段
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_GOODSNO_TITLE, visiblePosition++, true, 540, 2, 44, 0, 100, 2, "GoodsNo", "GoodsNo", true, false, false));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_MAKER_TITLE, visiblePosition++, true, 260, 2, 144, 0, 40, 2, "Maker", "Maker", true, false, false));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_BLCODE_TITLE, visiblePosition++, true, 200, 2, 184, 0, 50, 2, "BlCode", "BlCode", true, false, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_GOODSNM_TITLE, visiblePosition++, true, 520, 2, 234, 0, 100, 2, "GoodsNm", "GoodsNm", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_PARTSQTY_TITLE, visiblePosition++, true, 80, 2, 334, 0, 30, 2, "PartsQty", "PartsQty", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_COSTRATE_TITLE, visiblePosition++, true, 280, 2, 364, 0, 60, 2, "CostRate", "CostRate", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_CREATEYEAR_TITLE, visiblePosition++, true, 580, 2, 424, 0, 90, 2, "CreateYear", "CreateYear", true, false, false));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_CREATECARNO_TITLE, visiblePosition++, true, 600, 2, 514, 0, 100, 2, "CreateCarNo", "CreateCarNo", true, true, true));

            // 下段
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_MODELGRADENM_TITLE, visiblePosition++, true, 340, 2, 44, 2, 40, 2, "ModelGradeNm", "ModelGradeNm", true, false, false));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_BODYNAME_TITLE, visiblePosition++, true, 200, 2, 84, 2, 30, 2, "BodyName", "BodyName", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_DOORCOUNT_TITLE, visiblePosition++, true, 100, 2, 114, 2, 30, 2, "DoorCount", "DoorCount", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_ENGINEMODELNM_TITLE, visiblePosition++, true, 160, 2, 144, 2, 50, 2, "EngineModelNm", "EngineModelNm", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_ENGINEDISPLACENM_TITLE, visiblePosition++, true, 200, 2, 194, 2, 35, 2, "EngineDisplaceNm", "EngineDisplaceNm", true, false, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_EDIVNM_TITLE, visiblePosition++, true, 160, 2, 229, 2, 35, 2, "EdivNm", "EdivNm", true, true, true));
			initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_TRANSMISSIONNM_TITLE, visiblePosition++, true, 260, 2, 264, 2, 50, 2, "TransmissionNm", "TransmissionNm", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_WHEELDRIVEMETHODNM_TITLE, visiblePosition++, true, 240, 2, 314, 2, 50, 2, "WheelDriveMethodNm", "WheelDriveMethodNm", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_SHIFTNM_TITLE, visiblePosition++, true, 280, 2, 364, 2, 40, 2, "ShiftNm", "ShiftNm", true, true, true));
            initStatusList.Add(new ColDisplayStatusExp(PMJKN09011UC.COL_ADDICARSPEC_TITLE, visiblePosition++, true, 850, 2, 404, 2, 210, 2, "AddiCarSpec", "AddiCarSpec", true, true, true));
            //-------END MODIFY 2010.05.20 GEJUN FOR Redmine 8049---------------<<<<<<<<
            // 初期列表示状態リスト格納処理
            foreach (ColDisplayStatusExp initStatus in initStatusList)
            {
                this._colDisplayStatusKeyList.Add(initStatus.Key);
                this._colDisplayStatusInitDictionary.Add(initStatus.Key, initStatus);
            }

            // 列表示状態クラスリストが無効の場合は、初期列表示状態リストを設定
            if ((this._colDisplayStatusList == null) || (this._colDisplayStatusList.Count == 0))
            {
                foreach (string colKey in this._colDisplayStatusKeyList)
                {
                    ColDisplayStatusExp colDisplayStatus = null;

                    try
                    {
                        colDisplayStatus = this._colDisplayStatusInitDictionary[colKey];
                    }
                    catch (KeyNotFoundException)
                    {
                        //
                    }

                    if (colDisplayStatus != null)
                    {
                        this._colDisplayStatusList.Add(colDisplayStatus);
                    }
                }

                // 列表示状態クラス格納Dictionaryの値を最新情報にて再生成
                this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);
            }
            //else
            //{
            //    // 列表示状態クラス格納Dictionaryの値を最新情報にて再生成
            //    this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);

            //    // 初期列表示状態リストと列表示状態クラス格納Dictionaryの値を比較し、不足分を補充する
            //    foreach (string colKey in this._colDisplayStatusKeyList)
            //    {
            //        if (!this.ContainsKey(colKey))
            //        {
            //            // 存在しなければ追加
            //            ColDisplayStatusExp colDisplayStatus = null;

            //            try
            //            {
            //                colDisplayStatus = this._colDisplayStatusInitDictionary[colKey]; // 初期列表示状態クラス格納Dicより取得
            //            }
            //            catch (KeyNotFoundException)
            //            {
            //                //
            //            }

            //            if (colDisplayStatus != null)
            //            {
            //                colDisplayStatus.VisiblePosition = this._colDisplayStatusList.Count + 1;
            //                this.Add(colDisplayStatus);
            //            }
            //        }
            //        else
            //        {
            //            // 存在していれば初期列表示状態リストの内容で更新
            //            ColDisplayStatusExp colDisplayStatusInit = null;
            //            ColDisplayStatusExp colDisplayStatus = null;
            //            try
            //            {
            //                colDisplayStatus = this._colDisplayStatusDictionary[colKey]; // 列表示状態クラス格納Dicより取得
            //                colDisplayStatusInit = this._colDisplayStatusInitDictionary[colKey]; // 初期列表示状態クラス格納Dicより取得
            //            }
            //            catch (KeyNotFoundException)
            //            {
            //                //
            //            }

            //            if (colDisplayStatus != null)
            //            {
            //                colDisplayStatus.OriginX = colDisplayStatusInit.OriginX;
            //                colDisplayStatus.OriginY = colDisplayStatusInit.OriginY;
            //                colDisplayStatus.SpanX = colDisplayStatusInit.SpanX;
            //                colDisplayStatus.SpanY = colDisplayStatusInit.SpanY;
            //                colDisplayStatus.Width = colDisplayStatusInit.Width;
            //            }

            //        }
            //    }
            //}

            // 表示位置によるソート処理
            this.Sort();
        }
        #endregion

        #region Private Members
        /// <summary>列表示状態クラスリスト</summary>
        private List<ColDisplayStatusExp> _colDisplayStatusList = null;

        /// <summary>列表示状態クラス格納Dictionary</summary>
        private Dictionary<string, ColDisplayStatusExp> _colDisplayStatusDictionary = null;

        /// <summary>初期列表示状態クラス格納Dictionary</summary>
        private Dictionary<string, ColDisplayStatusExp> _colDisplayStatusInitDictionary = null;

        /// <summary>列表示状態キーリスト</summary>
        private List<string> _colDisplayStatusKeyList = null;

        /// <summary>明細データテーブル</summary>
        //PMJKN09011UC _detailDataTable;
        #endregion

        #region Public Methods
        /// <summary>
        /// 列表示状態キー格納判断処理
        /// </summary>
        /// <param name="key">対象列表示状態キー</param>
        /// <returns>列表示状態の有無(true:有,false:無)</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラス格納Dictionaryに対象のキーが格納されているかどうかを判断します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public bool ContainsKey(string key)
        {
            return this._colDisplayStatusDictionary.ContainsKey(key);
        }

        /// <summary>
        /// 並べ替え処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストを表示位置より並べ替えます。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public void Sort()
        {
            this._colDisplayStatusList.Sort();
        }

        /// <summary>
        /// 列表示状態クラスリスト取得処理
        /// </summary>
        /// <returns>ColDisplayStatusクラスリストのインスタンス</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストを取得します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public List<ColDisplayStatusExp> GetColDisplayStatusList()
        {
            // 表示位置によるソート処理
            this.Sort();

            return this._colDisplayStatusList;
        }

        /// <summary>
        /// 初期列表示状態クラス格納Dictionary取得処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 初期列表示状態クラス格納Dictionaryを取得します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public Dictionary<string, ColDisplayStatusExp> GetColDisplayInitDictionary()
        {
            return this._colDisplayStatusInitDictionary;
        }

        /// <summary>
        /// 列表示状態クラスリスト設定処理
        /// </summary>
        /// <param name="colDisplayStatusList">設定するColDisplayStatusクラスリストのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストを設定します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public void SetColDisplayStatusList(List<ColDisplayStatusExp> colDisplayStatusList)
        {
            this._colDisplayStatusList = colDisplayStatusList;

            // 表示位置によるソート処理
            this.Sort();
        }

        /// <summary>
        /// 列表示状態クラスリストシリアライズ処理
        /// </summary>
        /// <param name="displayStatusList">シリアライズ対象ColDisplayStatusクラスリストのインスタンス</param>
        /// <param name="fileName">シリアライズ先ファイル名称</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストをシリアライズします。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public static void Serialize(List<ColDisplayStatusExp> colDisplayStatusList, string fileName)
        {
            ColDisplayStatusExp[] colDisplayStatusArray = new ColDisplayStatusExp[colDisplayStatusList.Count];
            colDisplayStatusList.CopyTo(colDisplayStatusArray);

            UserSettingController.ByteSerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
        }

        /// <summary>
        /// 列表示状態クラスリストデシリアライズ処理
        /// </summary>
        /// <param name="fileName">デシリアライズ元ファイル名称</param>
        /// <returns>デシリアライズされたColDisplayStatusクラスリストのインスタンス</returns>
        /// <remarks>
        /// <br>Note       : デシリアライズした列表示状態クラスリストを返します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public static List<ColDisplayStatusExp> Deserialize(string fileName)
        {
            List<ColDisplayStatusExp> retList = new List<ColDisplayStatusExp>();

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName)))
            {
                try
                {
                    ColDisplayStatusExp[] retArray = UserSettingController.ByteDeserializeUserSetting<ColDisplayStatusExp[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

                    foreach (ColDisplayStatusExp colDisplayStatus in retArray)
                    {
                        retList.Add(colDisplayStatus);
                    }
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
                }
            }

            return retList;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 列表示状態クラス追加処理
        /// </summary>
        /// <param name="colDisplayStatus">追加するColDisplayStatusクラスのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスを列表示状態クラス格納Dictionaryに追加します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        private void Add(ColDisplayStatusExp colDisplayStatus)
        {
            // 既に同一キーが存在する場合は処理しない
            if (this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key))
            {
                return;
            }

            this._colDisplayStatusList.Add(colDisplayStatus);
            this._colDisplayStatusDictionary.Add(colDisplayStatus.Key, colDisplayStatus);

            // 表示位置によるソート処理
            this.Sort();
        }

        /// <summary>
        /// 列表示状態クラス削除処理
        /// </summary>
        /// <param name="colDisplayStatus">削除するColDisplayStatusクラスのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスを列表示状態クラス格納Dictionaryから削除します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        private void Remove(ColDisplayStatusExp colDisplayStatus)
        {
            // 同一キーが存在しない場合は処理しない
            if (!(this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key)))
            {
                return;
            }

            ColDisplayStatusExp status = null;

            try
            {
                status = this._colDisplayStatusDictionary[colDisplayStatus.Key];
            }
            catch (KeyNotFoundException)
            {
                //
            }

            if (status == null)
            {
                return;
            }

            this._colDisplayStatusList.Remove(status);
            this._colDisplayStatusDictionary.Remove(colDisplayStatus.Key);

            // 表示位置によるソート処理
            this.Sort();
        }

        /// <summary>
        /// 列表示状態クラスリスト⇒Dictionary格納処理
        /// </summary>
        /// <param name="colDisplayStatusList">格納するColDisplayStatusクラスのリストのインスタンス</param>
        /// <returns>列表示状態クラス格納Dictionaryのインスタンス</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスを列表示状態クラス格納Dictionaryから削除します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        private Dictionary<string, ColDisplayStatusExp> ToColStatusDictionaryFromColStatusList(List<ColDisplayStatusExp> colDisplayStatusList)
        {
            Dictionary<string, ColDisplayStatusExp> retDictionary = new Dictionary<string, ColDisplayStatusExp>();

            foreach (ColDisplayStatusExp status in colDisplayStatusList)
            {
                retDictionary.Add(status.Key, status);
            }

            return retDictionary;
        }
        #endregion
    }
}