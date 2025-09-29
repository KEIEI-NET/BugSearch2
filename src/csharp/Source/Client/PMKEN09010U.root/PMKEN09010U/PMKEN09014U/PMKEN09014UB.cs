using System;

namespace Broadleaf.Windows.Forms
{
    using GridRowType= Infragistics.Win.UltraWinGrid.UltraGridRow;
    using ColumnName = Broadleaf.Application.UIData.PrimeSettingInfo;

    /// <summary>
    /// グリッド行のヘルパクラス
    /// </summary>
    public class GridRowHelper
    {
        #region <ラップするグリッド行/>

        /// <summary>ラップするグリッド行</summary>
        private readonly GridRowType _myGridRow;
        /// <summary>
        /// ラップするグリッド行を取得します。
        /// </summary>
        /// <value>ラップするグリッド行</value>
        public GridRowType MyGridRow { get { return _myGridRow; } }

        #endregion  // <ラップするグリッド行/>

        #region <中分類コード/>

        /// <summary>中分類コードのカラム名</summary>
        private const string MIDDLE_CODE_COLUMN_NAME = ColumnName.COL_MIDDLEGENRECODE;
        /// <summary>
        /// 中分類コードを取得します。
        /// </summary>
        /// <value>中分類コード</value>
        public int MiddleCode
        {
            get { return (int)MyGridRow.Cells[MIDDLE_CODE_COLUMN_NAME].Value; }
        }

        #endregion  // <中分類コード/>

        #region <BLコード/>

        /// <summary>BLコードのカラム名</summary>
        private const string BL_CODE_COLUMN_NAME = ColumnName.COL_TBSPARTSCODE;
        /// <summary>
        /// BLコードを取得します。
        /// </summary>
        /// <value>BLコード</value>
        public int BLCode
        {
            get { return (int)MyGridRow.Cells[BL_CODE_COLUMN_NAME].Value; }
        }

        #endregion  // <BLコード/>

        #region <メーカーコード/>

        /// <summary>メーカーコードのカラム名</summary>
        private const string MAKER_CODE_COLUMN_NAME = ColumnName.COL_PARTSMAKERCD;
        /// <summary>
        /// メーカーコードを取得します。
        /// </summary>
        /// <value>メーカーコード</value>
        public int MakerCode
        {
            get { return (int)MyGridRow.Cells[MAKER_CODE_COLUMN_NAME].Value; }
        }

        #endregion  // <メーカーコード/>

        #region <表示順/>

        /// <summary>表示順のカラム名</summary>
        //private const string MAKER_DISP_ORDER_COLUMN_NAME = ColumnName.COL_MAKERDISPORDER;
        private const string MAKER_DISP_ORDER_COLUMN_NAME = "UserMakerDispOrder";
        /// <summary>
        /// 表示順のアクセサ
        /// </summary>
        /// <value>表示順</value>
        public int MakerDispOrder
        {
            get { return (int)MyGridRow.Cells[MAKER_DISP_ORDER_COLUMN_NAME].Value; }
            set { MyGridRow.Cells[MAKER_DISP_ORDER_COLUMN_NAME].Value = value; }
        }

        #endregion  // <表示順/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="gridRowAdaptee">ラップするグリッド行</param>
        public GridRowHelper(GridRowType gridRow)
        {
            _myGridRow = gridRow;
        }

        #endregion  // <Constractor/>
    }



    /// <summary>
    /// ソートされたグリッド行のヘルパクラス
    /// </summary>
    public abstract class SortedGridRowHelper
    {
        #region <本物のグリッド行/>

        /// <summary>本物のグリッド行</summary>
        private readonly GridRowHelper _realGridRow;
        /// <summary>
        /// 本物のグリッド行を取得します。
        /// </summary>
        /// <value>本物のグリッド行</value>
        protected GridRowHelper RealGridRow { get { return _realGridRow; } }

        /// <summary>
        /// 中分類コードを取得します。
        /// </summary>
        /// <value>中分類コード</value>
        public int MiddleCode
        {
            get { return RealGridRow.MiddleCode; }
        }

        /// <summary>
        /// BLコードを取得します。
        /// </summary>
        /// <value>BLコード</value>
        public int BLCode
        {
            get { return RealGridRow.BLCode; }
        }

        /// <summary>
        /// メーカーコードを取得します。
        /// </summary>
        /// <value>メーカーコード</value>
        public int MakerCode
        {
            get { return RealGridRow.MakerCode; }
        }

        #endregion  // <本物のグリッド行/>

        #region <直前のグリッド行/>

        /// <summary>直前のグリッド行</summary>
        private readonly SortedGridRowHelper _previous;
        /// <summary>
        /// 直前のグリッド行を取得します。
        /// </summary>
        /// <value>直前のグリッド行</value>
        protected SortedGridRowHelper Previous { get { return _previous; } }

        #endregion  // <直前のグリッド行/>

        #region <次のグリッド行/>

        /// <summary>次のグリッド行</summary>
        protected SortedGridRowHelper _next;
        /// <summary>
        /// 次のグリッド行のアクセサ
        /// </summary>
        /// <value>次のグリッド行</value>
        protected SortedGridRowHelper Next { get { return _next; } }

        #endregion  // <次のグリッド行/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realGridRow">本物のグリッド行</param>
        /// <param name="previous">直前のグリッド行</param>
        protected SortedGridRowHelper(
            GridRowHelper realGridRow,
            SortedGridRowHelper previous
        )
        {
            _realGridRow = realGridRow;
            _previous = previous;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// 次のグリッド行を設定します。
        /// </summary>
        /// <param name="realGridRow">本物の次のグリッド行</param>
        public abstract void SetNext(GridRowHelper realNextGridRow);

        /// <summary>
        /// 表示順のアクセサ
        /// </summary>
        /// <value>表示順</value>
        public int MakerDispOrder
        {
            get { return RealGridRow.MakerDispOrder; }
            set
            {
                RealGridRow.MakerDispOrder = value;

                if (Next != null)
                {
                    Next.IncrementMakerDispOrder(value);
                }
                if (Previous != null)
                {
                    Previous.DecrementMakerDispOrder(value);
                }
            }
        }

        /// <summary>
        /// 表示順をインクリメントします。
        /// </summary>
        /// <param name="previousMakerDispOrder">直前の表示順</param>
        protected virtual void IncrementMakerDispOrder(int previousMakerDispOrder)
        {
            // 何もしない
        }

        /// <summary>
        /// 表示順をデクリメントします。
        /// </summary>
        /// <param name="nextMakerDispOrder">次の表示順</param>
        protected virtual void DecrementMakerDispOrder(int nextMakerDispOrder)
        {
            // 何しない
        }

        /// <summary>
        /// グリッド行を検索します。
        /// </summary>
        /// <param name="middleCode">中分類コード</param>
        /// <param name="blCode">BLコード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns></returns>
        public SortedGridRowHelper Find(
            int middleCode,
            int blCode,
            int makerCode
        )
        {
            SortedGridRowHelper foundGridRow = null;

            // 自身を比較
            if (
                MiddleCode.Equals(middleCode)
                    &&
                BLCode.Equals(blCode)
                    &&
                MakerCode.Equals(makerCode)
            )
            {
                foundGridRow = this;
            }

            // 次を比較
            if (foundGridRow == null)
            {
                foundGridRow = Next.Find(middleCode, blCode, makerCode);
            }

            // 前を比較
            if (foundGridRow == null)
            {
                foundGridRow = Previous.Find(middleCode, blCode, makerCode);
            }

            return foundGridRow;
        }
    }



    /// <summary>
    /// 直前のグリッド行のヘルパクラス
    /// </summary>
    public sealed class PreviousGridRowHelper : SortedGridRowHelper
    {
        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realGridRow">本物のグリッド行</param>
        /// <param name="previous">直前のグリッド行</param>
        public PreviousGridRowHelper(
            GridRowHelper realGridRow,
            SortedGridRowHelper previous
        ) : base(realGridRow, previous) { }

        #endregion  // <Constructor/>

        /// <summary>
        /// 次のグリッド行を設定します。
        /// </summary>
        /// <param name="realGridRow">本物の次のグリッド行</param>
        /// <exception cref="NotImplementedException">本メソッドは実装されていません。</exception>
        public override void SetNext(GridRowHelper realNextGridRow)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 表示順をデクリメントします。
        /// </summary>
        /// <param name="nextMakerDispOrder">次の表示順</param>
        protected override void DecrementMakerDispOrder(int nextMakerDispOrder)
        {
            int previousMakerDispOrder = nextMakerDispOrder - 1;
            if (MakerDispOrder >= previousMakerDispOrder)
            {
                MakerDispOrder = previousMakerDispOrder;
            }
        }
    }



    /// <summary>
    /// 次のグリッド行のヘルパクラス
    /// </summary>
    public sealed class NextGridRowHelper : SortedGridRowHelper
    {
        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realGrid">本物のグリッド行</param>
        /// <param name="previous">直前のグリッド行</param>
        public NextGridRowHelper(
            GridRowHelper realGrid,
            SortedGridRowHelper previous
        ) : base(realGrid, previous) { }

        #endregion  // <Constructor/>

        /// <summary>
        /// 次のグリッド行を設定します。
        /// </summary>
        /// <param name="realGridRow">本物の次のグリッド行</param>
        public override void SetNext(GridRowHelper realNextGridRow)
        {
            if (Next == null)
            {
                _next = new NextGridRowHelper(realNextGridRow, new PreviousGridRowHelper(RealGridRow, Previous));
            }
            else
            {
                Next.SetNext(realNextGridRow);
            }
        }

        /// <summary>
        /// 表示順をインクリメントします。
        /// </summary>
        /// <param name="previousMakerDispOrder">直前の表示順</param>
        protected override void IncrementMakerDispOrder(int previousMakerDispOrder)
        {
            int nextMakerDispOrder = previousMakerDispOrder + 1;
            if (MakerDispOrder <= nextMakerDispOrder)
            {
                MakerDispOrder = nextMakerDispOrder;
            }
        }
    }
}
