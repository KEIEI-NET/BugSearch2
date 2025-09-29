using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 選択UIで選択した商品や倉庫情報を格納します。
    /// </summary>
    /// <remarks>
    /// <br>Update Note	: プロパティに選択品番を追加</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009/12/14</br>
    /// <br></br>
    /// <br>Update Note	: プロパティに「自由検索部品でセット親を登録した場合」を判断するフラグを追加</br>
    /// <br>Programmer	: 22018　鈴木 正臣</br>
    /// <br>Date		: 2010/10/01</br>
    /// </remarks>
    public class SelectionInfo
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SelectionInfo()
        {

        }

        ///// <summary>
        ///// コンストラクタ
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="selected"></param>
        ///// <param name="rowGoods"></param>
        ///// <param name="rowStock"></param>
        //public SelectionInfo(int key, bool selected, PartsInfoDataSet.UsrGoodsInfoRow rowGoods, PartsInfoDataSet.StockRow rowStock)
        //{
        //    _key = key;
        //    _selected = selected;
        //    _rowGoods = rowGoods;
        //    _rowStock = rowStock;
        //}

        /// <summary>0:同一品番選択UI／部品選択UI 1:結合選択UI 2:セット選択UI</summary>
        private int _depth;
        /// <summary>スレッドキー</summary>
        private int _key;
        /// <summary>選択状態</summary>
        private bool _selected = false;
        /// <summary>結合→セット時の結合元のセット選択</summary>
        private bool _joinSet = false;
        /// <summary></summary>
        private PartsInfoDataSet.UsrGoodsInfoRow _rowGoods;
        /// <summary></summary>
        private string _warehouseCd;
        /// <summary>子部品リスト1</summary>
        private Dictionary<int, SelectionInfo> _lst = new Dictionary<int, SelectionInfo>();
        /// <summary>子部品リスト2</summary>
        private Dictionary<int, SelectionInfo> _lst2 = new Dictionary<int, SelectionInfo>();
        /// <summary>互換リスト</summary>
        private List<SelectionInfo> _lstPlrlSubst = new List<SelectionInfo>();
        // 2009/12/14 Add >>>
        /// <summary>選択品番</summary>
        private string _selectedPartsNo = string.Empty;
        // 2009/12/14 Add <<<
        // --- ADD m.suzuki 2010/10/01 ---------->>>>>
        /// <summary>BLコード検索時に部品選択の時点でセット親だった場合(自由検索部品にセット親を登録した場合)</summary>
        private bool _extractSetParent = false;
        // --- ADD m.suzuki 2010/10/01 ----------<<<<<

        /// <summary>元画面表示ステップ 0:同一品番選択UI／部品選択UI 1:結合選択UI 2:セット選択UI</summary>
        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        /// <summary>スレッドキー</summary>
        public int Key
        {
            get { return _key; }
            set { _key = value; }
        }

        /// <summary>選択状態</summary>
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        /// <summary>結合→セット時の結合元のセット選択</summary>
        public bool JoinSet
        {
            get { return _joinSet; }
            set { _joinSet = value; }
        }

        /// <summary>商品情報</summary>
        public PartsInfoDataSet.UsrGoodsInfoRow RowGoods
        {
            get { return _rowGoods; }
            set { _rowGoods = value; }
        }

        /// <summary>倉庫コード</summary>
        public string WarehouseCode
        {
            get { return _warehouseCd; }
            set { _warehouseCd = value; }
        }

        /// <summary>子部品リスト</summary>
        public Dictionary<int, SelectionInfo> ListChildGoods
        {
            get { return _lst; }
            set { _lst = value; }
        }

        /// <summary>子部品リスト2(純正部品が結合・セット両方ある場合セットの子のリストを格納)</summary>
        public Dictionary<int, SelectionInfo> ListChildGoods2
        {
            get { return _lst2; }
            set { _lst2 = value; }
        }

        /// <summary>互換リスト</summary>
        public List<SelectionInfo> ListPlrlSubst
        {
            get { return _lstPlrlSubst; }
            set { _lstPlrlSubst = value; }
        }
        // 2009/12/14 Add >>>
        /// <summary>選択品番</summary>
        public string SelectedPartsNo
        {
            get { return _selectedPartsNo; }
            set { _selectedPartsNo = value; }
        }
        // 2009/12/14 Add <<<
        // --- ADD m.suzuki 2010/10/01 ---------->>>>>
        /// <summary>BLコード検索時に部品選択の時点でセット親だった場合(自由検索部品にセット親を登録した場合)</summary>
        public bool ExtractSetParent
        {
            get { return _extractSetParent; }
            set { _extractSetParent = value; }
        }
        // --- ADD m.suzuki 2010/10/01 ----------<<<<<

        /// <summary>
        /// 自分自身又は子リストに選択されたのがあるかチェック
        /// true : 選択あり／false：選択なし
        /// </summary>        
        public bool IsThereSelection
        {
            get
            {
                if (_selected)
                    return _selected;
                else
                {
                    foreach (SelectionInfo sel in _lst.Values)
                    {
                        if (sel.IsThereSelection)
                            return true;
                    }
                    foreach (SelectionInfo sel in _lst2.Values)
                    {
                        if (sel.IsThereSelection)
                            return true;
                    }
                    //foreach (SelectionInfo sel in _lstPlrlSubst)
                    //{
                    //    if (sel.IsThereSelection)
                    //        return true;
                    //}
                }
                return false;
            }
        }
    }
}
