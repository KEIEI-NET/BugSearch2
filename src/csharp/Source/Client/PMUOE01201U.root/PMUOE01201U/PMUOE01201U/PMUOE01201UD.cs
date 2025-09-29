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
    /// 列表示状態クラスコレクション
    /// </summary>
    /// <remarks>
    /// <br>Note       : 列表示状態クラスのコレクションクラスです。</br>
    /// <br>Programmer : 照田 貴志</br>
    /// <br>Date       : 2008/09/04</br>
    /// </remarks>
    internal class ColDisplayStatusList
    {
        // ===================================================================================== //
        // パブリック変数
        // ===================================================================================== //
        public static readonly int KBN_HEADER = 1;
        public static readonly int KBN_DETAIL = 2;

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        private List<ColDisplayStatus> _colDisplayStatusList = null;                            // 列表示状態クラスリスト
        private List<string> _colDisplayStatusKeyList = null;                                   // 列表示状態キーリスト
        private Dictionary<string, ColDisplayStatus> _colDisplayStatusDictionary = null;        // 列表示状態クラス格納Dictionary
        private Dictionary<string, ColDisplayStatus> _colDisplayStatusInitDictionary = null;    // 初期列表示状態クラス格納Dictionary

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ▼Constructor
        /// <summary>
        /// 列表示状態クラスコレクションクラスコンストラクタ
        /// </summary>
        /// <param name="colDisplayStatusList">ColDisplayStatusクラスリストのインスタンス</param>
        /// <param name="kbn">1：ヘッダーグリッド用、2：明細グリッド用</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスコレクションクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public ColDisplayStatusList(List<ColDisplayStatus> colDisplayStatusList,int kbn)
        {
            int visiblePosition = 0;
            
            // 各種インスタンス化
            this._colDisplayStatusList = colDisplayStatusList;
            this._colDisplayStatusDictionary = new Dictionary<string, ColDisplayStatus>();
            this._colDisplayStatusInitDictionary = new Dictionary<string, ColDisplayStatus>();
            this._colDisplayStatusKeyList = new List<string>();

            // 初期列表示状態リスト生成
            List<ColDisplayStatus> initStatusList = new List<ColDisplayStatus>();

            if (kbn == 1)
            {
                // ヘッダーグリッド用
                HeaderGridDataSet.HeaderTableDataTable headerTable = new HeaderGridDataSet.HeaderTableDataTable();
                initStatusList.Add(new ColDisplayStatus(headerTable.NoColumn.ColumnName, visiblePosition++, false, 10));                    // No(非表示項目)
                initStatusList.Add(new ColDisplayStatus(headerTable.DivCdColumn.ColumnName, visiblePosition++, true, 56));                  // 区分
                initStatusList.Add(new ColDisplayStatus(headerTable.SlipNoColumn.ColumnName, visiblePosition++, false, 112));               // 伝票番号
                initStatusList.Add(new ColDisplayStatus(headerTable.RemarkColumn.ColumnName, visiblePosition++, false, 88));                // リマーク
                initStatusList.Add(new ColDisplayStatus(headerTable.TotalColumn.ColumnName, visiblePosition++, false, 104));                // 合計
            }
            else if (kbn == 2)
            {
                // 明細グリッド用
                DetailGridDataSet.DetailTableDataTable detailTable = new DetailGridDataSet.DetailTableDataTable();
                initStatusList.Add(new ColDisplayStatus(detailTable.NoColumn.ColumnName, visiblePosition++, false, 10));                        // No(非表示項目)
                initStatusList.Add(new ColDisplayStatus(detailTable.DivCdColumn.ColumnName, visiblePosition++, true, 56));                      // 区分
                initStatusList.Add(new ColDisplayStatus(detailTable.InputEnterCntColumn.ColumnName, visiblePosition++, false, 42));             // 入庫
                initStatusList.Add(new ColDisplayStatus(detailTable.InputAnswerSalesUnitCostColumn.ColumnName, visiblePosition++, false, 88));  // 回答原価単価
                initStatusList.Add(new ColDisplayStatus(detailTable.GoodsNameColumn.ColumnName, visiblePosition++, false, 126));                // 品名
                initStatusList.Add(new ColDisplayStatus(detailTable.GoodsNoColumn.ColumnName, visiblePosition++, false, 126));                  // 品番
                initStatusList.Add(new ColDisplayStatus(detailTable.WarehouseCodeColumn.ColumnName, visiblePosition++, false, 58));             // 倉庫
                initStatusList.Add(new ColDisplayStatus(detailTable.WarehouseShelfNoColumn.ColumnName, visiblePosition++, false, 72));          // 棚番
                initStatusList.Add(new ColDisplayStatus(detailTable.SectionCntColumn.ColumnName, visiblePosition++, false, 40));                // 回答
                initStatusList.Add(new ColDisplayStatus(detailTable.BOCntColumn.ColumnName, visiblePosition++, false, 40));                     // BO数
                initStatusList.Add(new ColDisplayStatus(detailTable.EnterCntColumn.ColumnName, visiblePosition++, false, 10));                  // 入庫数(非表示項目)
                initStatusList.Add(new ColDisplayStatus(detailTable.AnswerSalesUnitCostColumn.ColumnName, visiblePosition++, false, 88));       // 回答原単価(非表示項目)
                initStatusList.Add(new ColDisplayStatus(detailTable.SalesUnitCostColumn.ColumnName, visiblePosition++, false, 88));             // 原単価(非表示項目)
                initStatusList.Add(new ColDisplayStatus(detailTable.SubstPartsNoColumn.ColumnName, visiblePosition++, false, 10));              // 代替品番(非表示項目)
                initStatusList.Add(new ColDisplayStatus(detailTable.AnswerPartsNoColumn.ColumnName, visiblePosition++, false, 10));             // 回答品番(非表示項目)
                initStatusList.Add(new ColDisplayStatus(detailTable.SupplierCdColumn.ColumnName, visiblePosition++, false, 10));                // 仕入先コード(非表示項目)
                initStatusList.Add(new ColDisplayStatus(detailTable.SlipNoColumn.ColumnName, visiblePosition++, false, 10));                    // 伝票番号(非表示項目)
                initStatusList.Add(new ColDisplayStatus(detailTable.OnlineNoColumn.ColumnName, visiblePosition++, false, 10));                  // オンライン番号(非表示項目)
                initStatusList.Add(new ColDisplayStatus(detailTable.OnlineRowNoColumn.ColumnName, visiblePosition++, false, 10));               // オンライン行番号(非表示項目)
                initStatusList.Add(new ColDisplayStatus(detailTable.StockExistsColumn.ColumnName, visiblePosition++, false, 10));               // 在庫有無(非表示項目)
            }

            // 初期列表示状態リスト格納処理
            foreach (ColDisplayStatus initStatus in initStatusList)
            {
                this._colDisplayStatusKeyList.Add(initStatus.Key);
                this._colDisplayStatusInitDictionary.Add(initStatus.Key, initStatus);
            }

            // 列表示状態クラスリストが無効の場合は、初期列表示状態リストを設定
            if ((this._colDisplayStatusList == null) || (this._colDisplayStatusList.Count == 0))
            {
                foreach (string colKey in this._colDisplayStatusKeyList)
                {
                    if (this._colDisplayStatusInitDictionary.ContainsKey(colKey))
                    {
                        this._colDisplayStatusList.Add(this._colDisplayStatusInitDictionary[colKey]);
                    }
                }

                // 列表示状態クラス格納Dictionaryの値を最新情報にて再生成
                this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);
            }
            else
            {
                // 列表示状態クラス格納Dictionaryの値を最新情報にて再生成
                this._colDisplayStatusDictionary = this.ToColStatusDictionaryFromColStatusList(this._colDisplayStatusList);

                // 初期列表示状態リストと列表示状態クラス格納Dictionaryの値を比較し、不足分を補充する
                foreach (string colKey in this._colDisplayStatusKeyList)
                {
                    if (!this.ContainsKey(colKey))
                    {
                        if (this._colDisplayStatusInitDictionary.ContainsKey(colKey))
                        {
                            ColDisplayStatus colDisplayStatus = null;
                            colDisplayStatus = this._colDisplayStatusInitDictionary[colKey];

                            colDisplayStatus.VisiblePosition = this._colDisplayStatusList.Count + 1;
                            this.Add(colDisplayStatus);
                        }
                    }
                }
            }

            // 表示位置によるソート処理
            this.Sort();
        }
        #endregion

        // ===================================================================================== //
        // パブリック
        // ===================================================================================== //
        #region ▼GetColDisplayStatusList(列表示状態クラスリスト-取得)
        /// <summary>
        /// 列表示状態クラスリスト取得処理
        /// </summary>
        /// <returns>ColDisplayStatusクラスリストのインスタンス</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストを取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public List<ColDisplayStatus> GetColDisplayStatusList()
        {
            // 表示位置によるソート処理
            this.Sort();

            return this._colDisplayStatusList;
        }
        #endregion

        #region ▼SetColDisplayStatusList(列表示状態クラスリスト-設定)
        /// <summary>
        /// 列表示状態クラスリスト設定処理
        /// </summary>
        /// <param name="colDisplayStatusList">設定するColDisplayStatusクラスリストのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストを設定します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void SetColDisplayStatusList(List<ColDisplayStatus> colDisplayStatusList)
        {
            this._colDisplayStatusList = colDisplayStatusList;

            // 表示位置によるソート処理
            this.Sort();
        }
        #endregion

        #region ▼Serialize(列表示状態クラスリスト-シリアライズ)
        /// <summary>
        /// 列表示状態クラスリストシリアライズ処理
        /// </summary>
        /// <param name="displayStatusList">シリアライズ対象ColDisplayStatusクラスリストのインスタンス</param>
        /// <param name="fileName">シリアライズ先ファイル名称</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストをシリアライズします。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public static void Serialize(List<ColDisplayStatus> colDisplayStatusList, string fileName)
        {
            ColDisplayStatus[] colDisplayStatusArray = new ColDisplayStatus[colDisplayStatusList.Count];
            colDisplayStatusList.CopyTo(colDisplayStatusArray);

            UserSettingController.ByteSerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
        }
        #endregion

        #region ▼Deserialize(列表示状態クラスリスト-デシリアライズ)
        /// <summary>
        /// 列表示状態クラスリストデシリアライズ処理
        /// </summary>
        /// <param name="fileName">デシリアライズ元ファイル名称</param>
        /// <returns>デシリアライズされたColDisplayStatusクラスリストのインスタンス</returns>
        /// <remarks>
        /// <br>Note       : デシリアライズした列表示状態クラスリストを返します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public static List<ColDisplayStatus> Deserialize(string fileName)
        {
            List<ColDisplayStatus> retList = new List<ColDisplayStatus>();

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName)))
            {
                try
                {
                    ColDisplayStatus[] retArray = UserSettingController.ByteDeserializeUserSetting<ColDisplayStatus[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

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

        // ===================================================================================== //
        // プライベート
        // ===================================================================================== //
        #region ▼Add(列表示状態クラス→列表示状態クラス格納Dicrionary追加)
        /// <summary>
        /// 列表示状態クラス追加処理
        /// </summary>
        /// <param name="colDisplayStatus">追加するColDisplayStatusクラスのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスを列表示状態クラス格納Dictionaryに追加します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void Add(ColDisplayStatus colDisplayStatus)
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
        #endregion

        #region ▼ContainsKey(列表示状態クラス格納Dictionary-対象キー有無判定)
        /// <summary>
        /// 列表示状態キー格納判断処理
        /// </summary>
        /// <param name="key">対象列表示状態キー</param>
        /// <returns>列表示状態の有無(true:有,false:無)</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラス格納Dictionaryに対象のキーが格納されているかどうかを判断します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private bool ContainsKey(string key)
        {
            return this._colDisplayStatusDictionary.ContainsKey(key);
        }
        #endregion

        #region ▼Sort(列表示状態クラスリスト-並べ替え)
        /// <summary>
        /// 並べ替え処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストを表示位置より並べ替えます。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void Sort()
        {
            this._colDisplayStatusList.Sort();
        }
        #endregion

        #region ▼ToColStatusDictionaryFromColStatusList(列表示状態クラスリスト→Dictionaryデータコピー)
        /// <summary>
        /// 列表示状態クラスリスト→Dictionaryコピー処理
        /// </summary>
        /// <param name="colDisplayStatusList">格納するColDisplayStatusクラスのリストのインスタンス</param>
        /// <returns>列表示状態クラス格納Dictionaryのインスタンス</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストのデータをDictionaryにコピーします。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private Dictionary<string, ColDisplayStatus> ToColStatusDictionaryFromColStatusList(List<ColDisplayStatus> colDisplayStatusList)
        {
            Dictionary<string, ColDisplayStatus> retDictionary = new Dictionary<string, ColDisplayStatus>();

            foreach (ColDisplayStatus status in colDisplayStatusList)
            {
                retDictionary.Add(status.Key, status);
            }

            return retDictionary;
        }
        #endregion
    }
}
