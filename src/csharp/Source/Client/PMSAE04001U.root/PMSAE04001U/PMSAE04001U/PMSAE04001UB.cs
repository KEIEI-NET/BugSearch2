using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 送信ログ列表示状態コレクションクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 送信ログ列表示状態クラスのコレクションです。</br>
    /// <br>Programmer : zhaimm</br>
    /// <br>Date       : 2013/06/26</br>
    /// </remarks>
    internal class SAndESalSndLogListResultColDisplayStatusCollection : ColDisplayStatusCollectionBase
    {
        #region << Constructor >>

        /// <summary>
        /// 送信ログ列表示状態コレクションクラスコンストラクタ
        /// </summary>
        /// <param name="colDisplayStatusList">列表示状態クラスリスト</param>
        /// <remarks>
        /// <br>Note       : 送信ログ列表示状態コレクションクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public SAndESalSndLogListResultColDisplayStatusCollection(List<ColDisplayStatus> colDisplayStatusList)
            : base(colDisplayStatusList)
        {
        }

        #endregion

        #region << Protected Methods >>

        /// <summary>
        /// 列表示状態リスト初期設定追加処理
        /// </summary>
        /// <param name="initStatusList">列表示状態リスト</param>
        /// <remarks>
        /// <br>Note       : 列表示状態リストに初期設定を追加します。</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        protected override void SetInitColDisplayStatusList(List<ColDisplayStatus> initStatusList)
        {
            int colVisiblePos = 0;

            /// <summary>拠点コード</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SECTIONCODE, colVisiblePos++, true, 0));
            /// <summary>拠点名称</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SECTIONNAME, colVisiblePos++, true, 105));
            /// <summary>自動送信区分コード</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SANDEAUTOSENDDIV, colVisiblePos++, true, 0));
            /// <summary>自動送信区分名称</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SANDEAUTOSENDDIVNAME, colVisiblePos++, true, 122));
            /// <summary>送信日時（開始）</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDDATETIMESTART, colVisiblePos++, true, 175));
            /// <summary>送信日時（終了）</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDDATETIMEEND, colVisiblePos++, true, 175));
            /// <summary>送信対象日付（開始）</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDOBJDATESTART, colVisiblePos++, true, 122));
            /// <summary>送信対象日付（終了）</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDOBJDATEEND, colVisiblePos++, true, 122));
            /// <summary>送信対象得意先（開始）</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDOBJCUSTSTART, colVisiblePos++, true, 107));
            /// <summary>送信対象得意先（終了）</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDOBJCUSTEND, colVisiblePos++, true, 107));
            /// <summary>送信対象区分コード</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDOBJDIV, colVisiblePos++, true, 0));
            /// <summary>送信対象区分名称</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDOBJDIVNAME, colVisiblePos++, true, 122));
            /// <summary>送信結果コード</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDRESULTS, colVisiblePos++, true, 0));
            /// <summary>送信結果名称</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SENDRESULTSNAME, colVisiblePos++, true, 91));
            /// <summary>送信伝票枚数</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SendSlipCount, colVisiblePos++, true, 91));
            /// <summary>送信伝票明細数</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SendSlipDtlCnt, colVisiblePos++, true, 91));
            /// <summary>送信伝票合計金額</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SendSlipTotalMny, colVisiblePos++, true, 128));
            /// <summary>送信エラー内容</summary>
            initStatusList.Add(new ColDisplayStatus(PMSAE04001UA.CT_SendErrorContents, colVisiblePos++, true, 205));
        }

        #endregion
    }

    /// <summary>
    /// 列表示状態コレクション基底クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 列表示状態クラスのコレクションの基底クラスです。</br>
    /// <br>Programmer : zhaimm</br>
    /// <br>Date       : 2013/06/26</br>
    /// </remarks>
    internal class ColDisplayStatusCollectionBase
    {
        #region << Constructor >>

        /// <summary>
        /// 列表示状態コレクション基底クラスコンストラクタ
        /// </summary>
        /// <param name="colDisplayStatusList">列表示状態クラスリスト</param>
        /// <remarks>
        /// <br>Note       : 列表示状態コレクション基底クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.1.11</br>
        /// </remarks>
        public ColDisplayStatusCollectionBase(List<ColDisplayStatus> colDisplayStatusList)
        {
            // インスタンス初期化
            this._colDisplayStatusList = colDisplayStatusList;
            this._colDisplayStatusDictionary = new Dictionary<string, ColDisplayStatus>();
            this._colDisplayStatusInitDictionary = new Dictionary<string, ColDisplayStatus>();
            this._colDisplayStatusKeyList = new List<string>();

            // 列表示状態クラスリスト作成
            List<ColDisplayStatus> initStatusList = new List<ColDisplayStatus>();

            // 列表示状態クラスリストに追加
            this.SetInitColDisplayStatusList(initStatusList);

            foreach (ColDisplayStatus initStatus in initStatusList)
            {
                this._colDisplayStatusKeyList.Add(initStatus.Key);
                this._colDisplayStatusInitDictionary.Add(initStatus.Key, initStatus);
            }

            // 列表示状態クラスリストが無効の場合は、初期値を設定
            if ((this._colDisplayStatusList == null) || (this._colDisplayStatusList.Count == 0))
            {
                foreach (string key in this._colDisplayStatusKeyList)
                {
                    ColDisplayStatus colStatus = null;

                    try
                    {
                        colStatus = this._colDisplayStatusInitDictionary[key];
                    }
                    catch (KeyNotFoundException)
                    {
                        // 
                    }

                    if (colStatus != null)
                    {
                        this._colDisplayStatusList.Add(colStatus);
                    }
                }

                // 列表示状態クラス格納Dictionaryを最新の情報にて再生性
                this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);
            }
            else
            {
                // 列表示状態クラス格納Dictionaryを最新の情報にて再生性
                this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);

                // デフォルト値と引数の値を比較し、不足分を補充する
                foreach (string key in this._colDisplayStatusKeyList)
                {
                    if (this.ContainsKey(key) == false)
                    {
                        ColDisplayStatus colStatus = null;

                        try
                        {
                            colStatus = this._colDisplayStatusInitDictionary[key];
                        }
                        catch (KeyNotFoundException)
                        {
                            // 
                        }

                        if (colStatus != null)
                        {
                            colStatus.VisiblePosition = this._colDisplayStatusList.Count + 1;
                            this.Add(colStatus);
                        }
                    }
                }
            }

            // 表示位置によるソート
            this.Sort();
        }

        #endregion

        #region << Constant >>

        #endregion

        #region << Private Members >>

        /// <summary>列表示状態クラスリスト</summary>
        private List<ColDisplayStatus> _colDisplayStatusList = null;
        private Dictionary<string, ColDisplayStatus> _colDisplayStatusDictionary = null;
        private Dictionary<string, ColDisplayStatus> _colDisplayStatusInitDictionary = null;
        private List<string> _colDisplayStatusKeyList = null;

        #endregion

        #region << Protected Methods >>

        /// <summary>
        /// 列表示状態リスト初期設定追加処理
        /// </summary>
        /// <param name="initStatusList">列表示状態リスト</param>
        /// <remarks>
        /// <br>Note       : 仮想メソッド。列表示状態リストに初期設定を追加します。</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        protected virtual void SetInitColDisplayStatusList(List<ColDisplayStatus> initStatusList)
        {
        }

        #endregion

        #region << Private Methods >>

        /// <summary>
        /// 列表示状態クラスリスト列表示状態クラス格納Dictionaryコピー処理
        /// </summary>
        /// <param name="colDisplayStatusList">列表示状態クラスリスト</param>
        /// <returns>列表示状態クラス格納Dictionary</returns>
        private Dictionary<string, ColDisplayStatus> ToColStatusDictionaryFromColStatusList(List<ColDisplayStatus> colDisplayStatusList)
        {
            // インスタンスを作成
            Dictionary<string, ColDisplayStatus> retDictionary = new Dictionary<string, ColDisplayStatus>();

            // リストの内容を登録
            foreach (ColDisplayStatus colStatus in colDisplayStatusList)
            {
                retDictionary.Add(colStatus.Key, colStatus);
            }

            return retDictionary;
        }

        /// <summary>
        /// 列表示状態クラス追加処理
        /// </summary>
        /// <param name="colDisplayStatus">追加対象列表示状態クラス</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスをコレクションに追加します。</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        private void Add(ColDisplayStatus colDisplayStatus)
        {
            // 既に同一キーが存在する場合は処理しない
            if (this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key) == true)
            {
                return;
            }

            this._colDisplayStatusList.Add(colDisplayStatus);
            this._colDisplayStatusDictionary.Add(colDisplayStatus.Key, colDisplayStatus);

            this.Sort();
        }

        /// <summary>
        /// 列表示状態クラス削除処理
        /// </summary>
        /// <param name="colDisplayStatus">削除対象列表示状態クラス</param>
        /// <remarks>
        /// <br>Note       : 指定されたオブジェクトと一致するオブジェクトをコレクションから削除します。</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        private void Remove(ColDisplayStatus colDisplayStatus)
        {
            // 同一キーが存在しない場合は処理しない
            if (this._colDisplayStatusDictionary.ContainsKey(colDisplayStatus.Key) == false)
            {
                return;
            }

            ColDisplayStatus colStatus = this._colDisplayStatusDictionary[colDisplayStatus.Key];

            if (colStatus == null)
            {
                return;
            }

            this._colDisplayStatusList.Remove(colStatus);
            this._colDisplayStatusDictionary.Remove(colStatus.Key);

            this.Sort();
        }

        #endregion

        #region << Public Methods >>

        /// <summary>
        /// 列表示状態クラスコレクションソート処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスコレクションのソートを行います。</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public void Sort()
        {
            this._colDisplayStatusList.Sort();
        }

        /// <summary>
        /// 列表示状態クラスリスト取得処理
        /// </summary>
        /// <returns>列表示状態クラスリスト</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストの取得を行います。</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public List<ColDisplayStatus> GetColDisplayStatusList()
        {
            return this._colDisplayStatusList;
        }

        /// <summary>
        /// 列表示状態クラスリスト設定処理
        /// </summary>
        /// <param name="colDisplayStatusList">列表示状態クラスリスト</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストの設定を行います。</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public void SetColDisplayStatusList(List<ColDisplayStatus> colDisplayStatusList)
        {
            this._colDisplayStatusList = colDisplayStatusList;
            this._colDisplayStatusList.Sort();
        }

        /// <summary>
        /// キー存在チェック処理
        /// </summary>
        /// <param name="key">コレクション内で検索されるキー</param>
        /// <returns>チェック結果(true:存在する, false:存在しない)</returns>
        /// <remarks>
        /// <br>Note       : 指定されたキーがコレクション内に存在するかどうかを判断します。</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public bool ContainsKey(string key)
        {
            return this._colDisplayStatusDictionary.ContainsKey(key);
        }

        #endregion

        #region << Public Static Methods >>

        /// <summary>
        /// 列表示状態クラスリストシリアライズ処理
        /// </summary>
        /// <param name="colDisplayStatusList">列表示状態クラスリスト</param>
        /// <param name="fileName">ファイル名</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストのシリアライズ処理を行います。</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public static void Serialize(List<ColDisplayStatus> colDisplayStatusList, string fileName)
        {
            ColDisplayStatus[] colDisplayStatusArray = new ColDisplayStatus[colDisplayStatusList.Count];
            colDisplayStatusList.CopyTo(colDisplayStatusArray);

            UserSettingController.SerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
        }

        /// <summary>
        /// 列表示状態クラスリストデシリアライズ処理
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns>列表示状態クラスリスト</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストのデシリアライズ処理を行います。</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public static List<ColDisplayStatus> Deserialize(string fileName)
        {
            List<ColDisplayStatus> retList = new List<ColDisplayStatus>();

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName)) == true)
            {
                try
                {
                    ColDisplayStatus[] retArray = UserSettingController.DeserializeUserSetting<ColDisplayStatus[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

                    foreach (ColDisplayStatus colDisplayStatus in retArray)
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
    }
}
