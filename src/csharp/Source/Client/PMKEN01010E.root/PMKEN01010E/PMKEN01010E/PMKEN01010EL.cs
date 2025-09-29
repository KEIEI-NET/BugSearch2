using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 表示用類別情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 表示用類別情報を格納するデータテーブルです。</br>
    /// <br>             型式選択画面の類別表示機能がなくなったため、要らなくなりましたが</br>
    /// <br>             念のため、残しておく。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public partial class CategoryDataDataTable : global::System.Data.DataTable, global::System.Collections.IEnumerable
    {

        private global::System.Data.DataColumn _columnModel_Category;
        /// <summary>
        /// 
        /// </summary>
        public CategoryDataDataTable()
        {
            this.TableName = "CategoryData";
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        public CategoryDataDataTable(global::System.Data.DataTable table)
        {
            this.TableName = table.TableName;
            if ((table.CaseSensitive != table.DataSet.CaseSensitive))
            {
                this.CaseSensitive = table.CaseSensitive;
            }
            if ((table.Locale.ToString() != table.DataSet.Locale.ToString()))
            {
                this.Locale = table.Locale;
            }
            if ((table.Namespace != table.DataSet.Namespace))
            {
                this.Namespace = table.Namespace;
            }
            this.Prefix = table.Prefix;
            this.MinimumCapacity = table.MinimumCapacity;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected CategoryDataDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
            :
                base(info, context)
        {
            this.InitVars();
        }
        /// <summary>
        /// 
        /// </summary>
        public global::System.Data.DataColumn _Model_CategoryColumn
        {
            get
            {
                return this._columnModel_Category;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get
            {
                return this.Rows.Count;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CategoryDataRow this[int index]
        {
            get
            {
                return ((CategoryDataRow)(this.Rows[index]));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public void AddCategoryDataRow(CategoryDataRow row)
        {
            this.Rows.Add(row);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Model_Category"></param>
        /// <returns></returns>
        public CategoryDataRow AddCategoryDataRow(string _Model_Category)
        {
            CategoryDataRow rowCategoryDataRow = ((CategoryDataRow)(this.NewRow()));
            object[] columnValuesArray = new object[] {
                        _Model_Category};
            rowCategoryDataRow.ItemArray = columnValuesArray;
            this.Rows.Add(rowCategoryDataRow);
            return rowCategoryDataRow;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual global::System.Collections.IEnumerator GetEnumerator()
        {
            return this.Rows.GetEnumerator();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override global::System.Data.DataTable Clone()
        {
            CategoryDataDataTable cln = ((CategoryDataDataTable)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override global::System.Data.DataTable CreateInstance()
        {
            return new CategoryDataDataTable();
        }
        /// <summary>
        /// 
        /// </summary>
        public void InitVars()
        {
            this._columnModel_Category = base.Columns["Model-Category"];
        }
        /// <summary>
        /// 
        /// </summary>
        private void InitClass()
        {
            this._columnModel_Category = new global::System.Data.DataColumn("Model-Category", typeof(string), null, global::System.Data.MappingType.Element);
            this._columnModel_Category.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_columnModel_Category");
            this._columnModel_Category.ExtendedProperties.Add("Generator_UserColumnName", "Model-Category");
            base.Columns.Add(this._columnModel_Category);
            this._columnModel_Category.AllowDBNull = false;
            this._columnModel_Category.Caption = "    型式指定 - 類別区分";
            this.ExtendedProperties.Add("Generator_TablePropName", "_CategoryData");
            this.ExtendedProperties.Add("Generator_UserTableName", "CategoryData");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CategoryDataRow NewCategoryDataRow()
        {
            return ((CategoryDataRow)(this.NewRow()));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        protected override global::System.Data.DataRow NewRowFromBuilder(global::System.Data.DataRowBuilder builder)
        {
            return new CategoryDataRow(builder);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override global::System.Type GetRowType()
        {
            return typeof(CategoryDataRow);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public void RemoveCategoryDataRow(CategoryDataRow row)
        {
            this.Rows.Remove(row);
        }

    }

    /// <summary>
    ///Represents strongly named DataRow class.
    ///</summary>
    public partial class CategoryDataRow : global::System.Data.DataRow
    {

        private CategoryDataDataTable tableCategoryData;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rb"></param>
        public CategoryDataRow(global::System.Data.DataRowBuilder rb)
            :
                base(rb)
        {
            this.tableCategoryData = ((CategoryDataDataTable)(this.Table));
        }
        /// <summary>
        /// 
        /// </summary>
        public string _Model_Category
        {
            get
            {
                return ((string)(this[this.tableCategoryData._Model_CategoryColumn]));
            }
            set
            {
                this[this.tableCategoryData._Model_CategoryColumn] = value;
            }
        }
    }

}
