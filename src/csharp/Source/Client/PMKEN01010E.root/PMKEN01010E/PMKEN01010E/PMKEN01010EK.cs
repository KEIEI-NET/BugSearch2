using System;
using System.Data;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.UIData
{
    public partial class PMKEN01010E
    {
        /// <summary>
        /// 画面用型式情報クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面用型式情報を格納するデータテーブルです。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.05.15</br>
        /// <br></br>
        /// <br>Update Note: 車台番号⇒車台番号、車台番号（検索用）に修正</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.01.28</br>    
        /// <br></br>
        /// <br>Update Note: 10900269-00 SPK車台番号文字列対応</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2013/03/19</br>
        /// </remarks>
        public class CarModelUIDataTable : DataTable, IEnumerable
        {
            #region [DataColumn 定義]
            private DataColumn columnMakerCode;

            private DataColumn columnMakerFullName;

            private DataColumn columnModelCode;

            private DataColumn columnModelSubCode;

            private DataColumn columnModelFullName;

            private DataColumn columnProduceTypeOfYearInput;

            private DataColumn columnStProduceTypeOfYear;

            private DataColumn columnEdProduceTypeOfYear;

            private DataColumn columnFullModel;

            // 2009.01.28 >>>
            //private DataColumn columnProduceFrameNoInput;

            private DataColumn columnFrameNo;

            private DataColumn columnSearchFrameNo;
            // 2009.01.28 <<<

            private DataColumn columnStProduceFrameNo;

            private DataColumn columnEdProduceFrameNo;

            private DataColumn columnModelGradeNm;

            private DataColumn columnBodyName;

            private DataColumn columnDoorCount;

            private DataColumn columnEngineModelNm;

            private DataColumn columnEngineDisplaceNm;

            private DataColumn columnEDivNm;

            private DataColumn columnTransmissionNm;

            private DataColumn columnWheelDriveMethodNm;

            private DataColumn columnShiftNm;

            private DataColumn columnAddiCarSpec1;

            private DataColumn columnAddiCarSpec2;

            private DataColumn columnAddiCarSpec3;

            private DataColumn columnAddiCarSpec4;

            private DataColumn columnAddiCarSpec5;

            private DataColumn columnAddiCarSpec6;

            private DataColumn columnModelDesignationNo;

            private DataColumn columnCategoryNo;

            // --- ADD 2013/03/19 ---------->>>>>
            private DataColumn columnDomesticForeignCode;   // 国産/外車区分
            private DataColumn columnDomesticForeignName;   // 国産/外車区分名称
            private DataColumn columnHandleInfoCd;     // ハンドル位置
            private DataColumn columnHandleInfoNm;    // ハンドル位置名称
            // --- ADD 2013/03/19 ----------<<<<<
            #endregion

            /// <summary>
            /// 
            /// </summary>
            public CarModelUIDataTable()
            {
                this.TableName = "CarModelUIData";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal CarModelUIDataTable(DataTable table)
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
            protected CarModelUIDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
                :
                    base(info, context)
            {
                this.InitVars();
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn MakerCodeColumn
            {
                get
                {
                    return this.columnMakerCode;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn MakerFullNameColumn
            {
                get
                {
                    return this.columnMakerFullName;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn ModelCodeColumn
            {
                get
                {
                    return this.columnModelCode;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn ModelSubCodeColumn
            {
                get
                {
                    return this.columnModelSubCode;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn ModelFullNameColumn
            {
                get
                {
                    return this.columnModelFullName;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn ProduceTypeOfYearInputColumn
            {
                get
                {
                    return this.columnProduceTypeOfYearInput;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn StProduceTypeOfYearColumn
            {
                get
                {
                    return this.columnStProduceTypeOfYear;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn EdProduceTypeOfYearColumn
            {
                get
                {
                    return this.columnEdProduceTypeOfYear;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn DoorCountColumn
            {
                get
                {
                    return this.columnDoorCount;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn BodyNameColumn
            {
                get
                {
                    return this.columnBodyName;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn FullModelColumn
            {
                get
                {
                    return this.columnFullModel;
                }
            }
            // 2009.01.28 >>>
            ///// <summary>
            ///// 
            ///// </summary>
            //public DataColumn ProduceFrameNoInputColumn
            //{
            //    get
            //    {
            //        return this.columnProduceFrameNoInput;
            //    }
            //}

            /// <summary>
            /// 
            /// </summary>
            public DataColumn FrameNoColumn
            {
                get
                {
                    return this.columnFrameNo;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn SearchFrameNoColumn
            {
                get
                {
                    return this.columnSearchFrameNo;
                }
            }
            // 2009.01.28 <<<
            /// <summary>
            /// 
            /// </summary>
            public DataColumn StProduceFrameNoColumn
            {
                get
                {
                    return this.columnStProduceFrameNo;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn EdProduceFrameNoColumn
            {
                get
                {
                    return this.columnEdProduceFrameNo;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn ModelGradeNmColumn
            {
                get
                {
                    return this.columnModelGradeNm;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn EngineModelNmColumn
            {
                get
                {
                    return this.columnEngineModelNm;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn EngineDisplaceNmColumn
            {
                get
                {
                    return this.columnEngineDisplaceNm;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn EDivNmColumn
            {
                get
                {
                    return this.columnEDivNm;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn TransmissionNmColumn
            {
                get
                {
                    return this.columnTransmissionNm;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn WheelDriveMethodNmColumn
            {
                get
                {
                    return this.columnWheelDriveMethodNm;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn ShiftNmColumn
            {
                get
                {
                    return this.columnShiftNm;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpec1Column
            {
                get
                {
                    return this.columnAddiCarSpec1;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpec2Column
            {
                get
                {
                    return this.columnAddiCarSpec2;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpec3Column
            {
                get
                {
                    return this.columnAddiCarSpec3;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpec4Column
            {
                get
                {
                    return this.columnAddiCarSpec4;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpec5Column
            {
                get
                {
                    return this.columnAddiCarSpec5;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpec6Column
            {
                get
                {
                    return this.columnAddiCarSpec6;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn ModelDesignationNoColumn
            {
                get
                {
                    return this.columnModelDesignationNo;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn CategoryNoColumn
            {
                get
                {
                    return this.columnCategoryNo;
                }
            }

            // --- ADD 2013/03/19 ---------->>>>>
            /// <summary> 国産/外車区分 </summary>
            public DataColumn DomesticForeignCodeColumn
            {
                get
                {
                    return this.columnDomesticForeignCode;
                }
            }

            /// <summary> 国産/外車区分名称 </summary>
            public DataColumn DomesticForeignNameColumn
            {
                get
                {
                    return this.columnDomesticForeignName;
                }
            }

            /// <summary> ハンドル位置 </summary>
            public DataColumn HandleInfoCdColumn
            {
                get
                {
                    return this.columnHandleInfoCd;
                }
            }

            /// <summary> ハンドル位置名称 </summary>
            public DataColumn HandleInfoNmColumn
            {
                get
                {
                    return this.columnHandleInfoNm;
                }
            }
            // --- ADD 2013/03/19 ----------<<<<<

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
            public CarModelUIRow this[int index]
            {
                get
                {
                    return ((CarModelUIRow)(this.Rows[index]));
                }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void AddCarModelInfoRow(CarModelUIRow row)
            {
                this.Rows.Add(row);
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public CarModelUIRow AddCarModelInfoRowCopy(CarModelInfoRow row)
            {
                CarModelUIRow rowCarModelUIRow = AddCarModelInfoRow(row.MakerCode,
                    row.MakerFullName, row.ModelCode, row.ModelSubCode, row.ModelFullName, 0,
                    row.StProduceTypeOfYear, row.EdProduceTypeOfYear,
                    // 2009.01.28 >>>
                    row.FullModel, string.Empty, 0, row.StProduceFrameNo, row.EdProduceFrameNo,
                    //row.FullModel, 0, row.StProduceFrameNo, row.EdProduceFrameNo,
                    // 2009.01.28 <<<
                    row.ModelGradeNm, row.BodyName, row.DoorCount, row.EngineModelNm,
                    row.EngineDisplaceNm, row.EDivNm, row.TransmissionNm, row.WheelDriveMethodNm, row.ShiftNm, row.AddiCarSpec1,
                    row.AddiCarSpec2, row.AddiCarSpec3, row.AddiCarSpec4, row.AddiCarSpec5, row.AddiCarSpec6, 0, 0,                    
                    // --- ADD 2013/03/19 ---------->>>>>
                    row.DomesticForeignCode,
                    row.DomesticForeignName,
                    row.HandleInfoCd,
                    row.HandleInfoNm
                    // --- ADD 2013/03/19 ----------<<<<<
                    );
                return rowCarModelUIRow;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="MakerCode"></param>
            /// <param name="MakerFullName"></param>
            /// <param name="ModelCode"></param>
            /// <param name="ModelSubCode"></param>
            /// <param name="ModelFullName"></param>
            /// <param name="ProduceTypeOfYearInput"></param>
            /// <param name="StProduceTypeOfYear"></param>
            /// <param name="EdProduceTypeOfYear"></param>
            /// <param name="DoorCount"></param>
            /// <param name="BodyName"></param>
            /// <param name="FullModel"></param>
            /// <param name="FrameNo"></param>
            /// <param name="SearchFrameNo"></param>
            /// <param name="StProduceFrameNo"></param>
            /// <param name="EdProduceFrameNo"></param>
            /// <param name="ModelGradeNm"></param>
            /// <param name="EngineModelNm"></param>
            /// <param name="EngineDisplaceNm"></param>
            /// <param name="EDivNm"></param>
            /// <param name="TransmissionNm"></param>
            /// <param name="WheelDriveMethodNm"></param>
            /// <param name="ShiftNm"></param>
            /// <param name="AddiCarSpec1"></param>
            /// <param name="AddiCarSpec2"></param>
            /// <param name="AddiCarSpec3"></param>
            /// <param name="AddiCarSpec4"></param>
            /// <param name="AddiCarSpec5"></param>
            /// <param name="AddiCarSpec6"></param>
            /// <param name="ModelDesignationNo"></param>
            /// <param name="CategoryNo"></param>
            /// <param name="DomesticForeignCode"></param>
            /// <param name="DomesticForeignName"></param>
            /// <param name="HandleInfoCd"></param>
            /// <param name="HandleInfoNm"></param>
            /// <returns></returns>
            public CarModelUIRow AddCarModelInfoRow(
                        int MakerCode,
                        string MakerFullName,
                        int ModelCode,
                        int ModelSubCode,
                        string ModelFullName,
                        int ProduceTypeOfYearInput,
                        int StProduceTypeOfYear,
                        int EdProduceTypeOfYear,
                        string FullModel,
                        // 2009.01.28 >>>
                        //int ProduceFrameNoInput,
                        string FrameNo,
                        int SearchFrameNo,
                        // 2009.01.28 <<<
                        int StProduceFrameNo,
                        int EdProduceFrameNo,
                        string ModelGradeNm,
                        string BodyName,
                        int DoorCount,
                        string EngineModelNm,
                        string EngineDisplaceNm,
                        string EDivNm,
                        string TransmissionNm,
                        string WheelDriveMethodNm,
                        string ShiftNm,
                        string AddiCarSpec1,
                        string AddiCarSpec2,
                        string AddiCarSpec3,
                        string AddiCarSpec4,
                        string AddiCarSpec5,
                        string AddiCarSpec6,
                        int ModelDesignationNo, 
                        int CategoryNo,
                        // --- ADD 2013/03/19 ---------->>>>>
                        int DomesticForeignCode,
                        string DomesticForeignName,
                        int HandleInfoCd,
                        string HandleInfoNm)
                        // --- ADD 2013/03/19 ----------<<<<<
            {
                CarModelUIRow rowCarModelInfoRow = ((CarModelUIRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        MakerCode,
                        MakerFullName,
                        ModelCode,
                        ModelSubCode,
                        ModelFullName,
                        ProduceTypeOfYearInput,
                        StProduceTypeOfYear,
                        EdProduceTypeOfYear,                        
                        FullModel,
                        // 2009.01.28 >>>
                        //ProduceFrameNoInput,
                        FrameNo,
                        SearchFrameNo,
                        // 2009.01.28 <<<
                        StProduceFrameNo,
                        EdProduceFrameNo,
                        ModelGradeNm,
                        BodyName,
                        DoorCount,
                        EngineModelNm,
                        EngineDisplaceNm,
                        EDivNm,
                        TransmissionNm,
                        WheelDriveMethodNm,
                        ShiftNm,
                        AddiCarSpec1,
                        AddiCarSpec2,
                        AddiCarSpec3,
                        AddiCarSpec4,
                        AddiCarSpec5,
                        AddiCarSpec6,
                        ModelDesignationNo, 
                        CategoryNo,
                        // --- ADD 2013/03/19 ---------->>>>>
                        DomesticForeignCode,
                        DomesticForeignName,
                        HandleInfoCd,
                        HandleInfoNm
                        // --- ADD 2013/03/19 ----------<<<<<
                };
                rowCarModelInfoRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowCarModelInfoRow);
                return rowCarModelInfoRow;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public virtual IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override DataTable Clone()
            {
                CarModelUIDataTable cln = ((CarModelUIDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override DataTable CreateInstance()
            {
                return new CarModelUIDataTable();
            }

            internal void InitVars()
            {
                this.columnMakerCode = base.Columns["MakerCode"];
                this.columnMakerFullName = base.Columns["MakerFullName"];
                this.columnModelCode = base.Columns["ModelCode"];
                this.columnModelSubCode = base.Columns["ModelSubCode"];
                this.columnModelFullName = base.Columns["ModelFullName"];
                this.columnProduceTypeOfYearInput = base.Columns["ProduceTypeOfYearInput"];
                this.columnStProduceTypeOfYear = base.Columns["StProduceTypeOfYear"];
                this.columnEdProduceTypeOfYear = base.Columns["EdProduceTypeOfYear"];
                this.columnFullModel = base.Columns["FullModel"];
                // 2009.01.28 >>>
                //this.columnProduceFrameNoInput = base.Columns["ProduceFrameNoInput"];
                this.columnFrameNo= base.Columns["FrameNo"];
                this.columnSearchFrameNo = base.Columns["SearchFrameNo"];
                // 2009.01.28 <<<
                this.columnStProduceFrameNo = base.Columns["StProduceFrameNo"];
                this.columnEdProduceFrameNo = base.Columns["EdProduceFrameNo"];
                this.columnModelGradeNm = base.Columns["ModelGradeNm"];
                this.columnBodyName = base.Columns["BodyName"];
                this.columnDoorCount = base.Columns["DoorCount"];
                this.columnEngineModelNm = base.Columns["EngineModelNm"];
                this.columnEngineDisplaceNm = base.Columns["EngineDisplaceNm"];
                this.columnEDivNm = base.Columns["EDivNm"];
                this.columnTransmissionNm = base.Columns["TransmissionNm"];
                this.columnWheelDriveMethodNm = base.Columns["WheelDriveMethodNm"];
                this.columnShiftNm = base.Columns["ShiftNm"];
                this.columnAddiCarSpec1 = base.Columns["AddiCarSpec1"];
                this.columnAddiCarSpec2 = base.Columns["AddiCarSpec2"];
                this.columnAddiCarSpec3 = base.Columns["AddiCarSpec3"];
                this.columnAddiCarSpec4 = base.Columns["AddiCarSpec4"];
                this.columnAddiCarSpec5 = base.Columns["AddiCarSpec5"];
                this.columnAddiCarSpec6 = base.Columns["AddiCarSpec6"];
                this.columnModelDesignationNo = base.Columns["ModelDesignationNo"];
                this.columnCategoryNo = base.Columns["CategoryNo"];
                // --- ADD 2013/03/19 ---------->>>>>
                this.columnDomesticForeignCode = base.Columns["DomesticForeignCode"];
                this.columnDomesticForeignName = base.Columns["DomesticForeignName"];
                this.columnHandleInfoCd = base.Columns["HandleInfoCd"];
                this.columnHandleInfoNm = base.Columns["HandleInfoNm"];
                // --- ADD 2013/03/19 ----------<<<<<
            }

            private void InitClass()
            {
                this.columnMakerCode = new DataColumn("MakerCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMakerCode);
                this.columnMakerFullName = new DataColumn("MakerFullName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMakerFullName);
                this.columnModelCode = new DataColumn("ModelCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnModelCode);
                this.columnModelSubCode = new DataColumn("ModelSubCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnModelSubCode);
                this.columnModelFullName = new DataColumn("ModelFullName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnModelFullName);
                this.columnProduceTypeOfYearInput = new DataColumn("ProduceTypeOfYearInput", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnProduceTypeOfYearInput);
                this.columnStProduceTypeOfYear = new DataColumn("StProduceTypeOfYear", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnStProduceTypeOfYear);
                this.columnEdProduceTypeOfYear = new DataColumn("EdProduceTypeOfYear", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEdProduceTypeOfYear);
                this.columnFullModel = new DataColumn("FullModel", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnFullModel);
                // 2009.01.28 >>>
                //this.columnProduceFrameNoInput = new DataColumn("ProduceFrameNoInput", typeof(int), null, MappingType.Element);
                //base.Columns.Add(this.columnProduceFrameNoInput);
                this.columnFrameNo = new DataColumn("FrameNo", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnFrameNo);
                this.columnSearchFrameNo = new DataColumn("SearchFrameNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSearchFrameNo);
                // 2009.01.28 <<<
                this.columnStProduceFrameNo = new DataColumn("StProduceFrameNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnStProduceFrameNo);
                this.columnEdProduceFrameNo = new DataColumn("EdProduceFrameNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEdProduceFrameNo);
                this.columnModelGradeNm = new DataColumn("ModelGradeNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnModelGradeNm);
                this.columnBodyName = new DataColumn("BodyName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBodyName);
                this.columnDoorCount = new DataColumn("DoorCount", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnDoorCount);
                this.columnEngineModelNm = new DataColumn("EngineModelNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEngineModelNm);
                this.columnEngineDisplaceNm = new DataColumn("EngineDisplaceNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEngineDisplaceNm);
                this.columnEDivNm = new DataColumn("EDivNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnEDivNm);
                this.columnTransmissionNm = new DataColumn("TransmissionNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTransmissionNm);
                this.columnWheelDriveMethodNm = new DataColumn("WheelDriveMethodNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnWheelDriveMethodNm);
                this.columnShiftNm = new DataColumn("ShiftNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnShiftNm);
                this.columnAddiCarSpec1 = new DataColumn("AddiCarSpec1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpec1);
                this.columnAddiCarSpec2 = new DataColumn("AddiCarSpec2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpec2);
                this.columnAddiCarSpec3 = new DataColumn("AddiCarSpec3", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpec3);
                this.columnAddiCarSpec4 = new DataColumn("AddiCarSpec4", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpec4);
                this.columnAddiCarSpec5 = new DataColumn("AddiCarSpec5", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpec5);
                this.columnAddiCarSpec6 = new DataColumn("AddiCarSpec6", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpec6);
                this.columnModelDesignationNo = new DataColumn("ModelDesignationNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnModelDesignationNo);
                this.columnCategoryNo = new DataColumn("CategoryNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCategoryNo);
                // --- ADD 2013/03/19 ---------->>>>>
                this.columnDomesticForeignCode = new DataColumn("DomesticForeignCode", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnDomesticForeignCode);
                this.columnDomesticForeignName = new DataColumn("DomesticForeignName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDomesticForeignName);
                this.columnHandleInfoCd = new DataColumn("HandleInfoCd", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnHandleInfoCd);
                this.columnHandleInfoNm = new DataColumn("HandleInfoNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnHandleInfoNm);
                // --- ADD 2013/03/19 ----------<<<<<

                this.columnMakerCode.AllowDBNull = false;
                this.columnMakerCode.Caption = "メーカーコード";
                this.columnMakerFullName.Caption = "メーカー全角名称";
                this.columnMakerFullName.MaxLength = 15;
                this.columnMakerFullName.DefaultValue = string.Empty;
                this.columnModelCode.AllowDBNull = false;
                this.columnModelCode.Caption = "車種コード";
                this.columnModelSubCode.AllowDBNull = false;
                this.columnModelSubCode.Caption = "車種サブコード";
                this.columnModelFullName.Caption = "車種全角名称";
                this.columnModelFullName.MaxLength = 15;
                this.columnModelFullName.DefaultValue = string.Empty;
                this.columnProduceTypeOfYearInput.DefaultValue = 0;
                this.columnStProduceTypeOfYear.Caption = "生産年式(開始)";
                this.columnStProduceTypeOfYear.DefaultValue = 0;
                this.columnEdProduceTypeOfYear.Caption = "生産年式(終了)";
                this.columnEdProduceTypeOfYear.DefaultValue = 0;
                this.columnFullModel.AllowDBNull = false;
                this.columnFullModel.Caption = "型式";
                this.columnFullModel.MaxLength = 44;
                // 2009.01.28 >>>
                //this.ProduceFrameNoInputColumn.DefaultValue = 0;
                this.columnFrameNo.AllowDBNull = false;
                this.columnFrameNo.Caption = "車台番号";
                this.columnFrameNo.MaxLength = 30;
                this.columnFrameNo.DefaultValue = string.Empty; ;
                this.columnSearchFrameNo.AllowDBNull = false;
                this.columnSearchFrameNo.Caption = "車台番号（検索用）";
                this.columnSearchFrameNo.DefaultValue = 0;
                // 2009.01.28 <<<
                this.columnStProduceFrameNo.Caption = "車台番号(開始)";
                this.columnStProduceFrameNo.DefaultValue = 0;
                this.columnEdProduceFrameNo.Caption = "車台番号(終了)";
                this.columnEdProduceFrameNo.DefaultValue = 0;
                this.columnModelGradeNm.Caption = "グレード";
                this.columnModelGradeNm.MaxLength = 20;
                this.columnModelGradeNm.DefaultValue = string.Empty;
                this.columnBodyName.Caption = "ボディー";
                this.columnBodyName.MaxLength = 10;
                this.columnBodyName.DefaultValue = string.Empty;
                this.columnDoorCount.AllowDBNull = false;
                this.columnDoorCount.Caption = "ドア"; this.columnEngineModelNm.Caption = "エンジン";
                this.columnEngineModelNm.MaxLength = 12;
                this.columnEngineModelNm.DefaultValue = string.Empty;
                this.columnEngineDisplaceNm.Caption = "排気量";
                this.columnEngineDisplaceNm.MaxLength = 8;
                this.columnEngineDisplaceNm.DefaultValue = string.Empty;
                this.columnEDivNm.Caption = "E区分";
                this.columnEDivNm.MaxLength = 8;
                this.columnEDivNm.DefaultValue = string.Empty;
                this.columnTransmissionNm.Caption = "ミッション";
                this.columnTransmissionNm.MaxLength = 8;
                this.columnTransmissionNm.DefaultValue = string.Empty;
                this.columnWheelDriveMethodNm.Caption = "駆動方式";
                this.columnWheelDriveMethodNm.MaxLength = 15;
                this.columnWheelDriveMethodNm.DefaultValue = string.Empty;
                this.columnShiftNm.Caption = "シフト";
                this.columnShiftNm.MaxLength = 8;
                this.columnShiftNm.DefaultValue = string.Empty;
                this.columnAddiCarSpec1.Caption = "追加諸元1";
                this.columnAddiCarSpec1.MaxLength = 8;
                this.columnAddiCarSpec1.DefaultValue = string.Empty;
                this.columnAddiCarSpec2.Caption = "追加諸元2";
                this.columnAddiCarSpec2.MaxLength = 8;
                this.columnAddiCarSpec2.DefaultValue = string.Empty;
                this.columnAddiCarSpec3.Caption = "追加諸元3";
                this.columnAddiCarSpec3.MaxLength = 8;
                this.columnAddiCarSpec3.DefaultValue = string.Empty;
                this.columnAddiCarSpec4.Caption = "追加諸元4";
                this.columnAddiCarSpec4.MaxLength = 8;
                this.columnAddiCarSpec4.DefaultValue = string.Empty;
                this.columnAddiCarSpec5.Caption = "追加諸元5";
                this.columnAddiCarSpec5.MaxLength = 8;
                this.columnAddiCarSpec5.DefaultValue = string.Empty;
                this.columnAddiCarSpec6.Caption = "追加諸元6";
                this.columnAddiCarSpec6.MaxLength = 8;
                this.columnAddiCarSpec6.DefaultValue = string.Empty;
                this.columnModelDesignationNo.Caption = "型式指定番号";
                this.columnModelDesignationNo.DefaultValue = 0;
                this.columnCategoryNo.Caption = "類別番号";
                this.columnCategoryNo.DefaultValue = 0;
                // --- ADD 2013/03/19 ---------->>>>>
                this.columnDomesticForeignCode.AllowDBNull = true;
                this.columnDomesticForeignCode.Caption = "国産/外車区分";
                this.columnDomesticForeignName.AllowDBNull = true;
                this.columnDomesticForeignName.Caption = "国産/外車区分名称";
                this.columnDomesticForeignName.MaxLength = 6;
                this.columnHandleInfoCd.AllowDBNull = true;
                this.columnHandleInfoCd.Caption = "ハンドル位置";
                this.columnHandleInfoNm.AllowDBNull = true;
                this.columnHandleInfoNm.Caption = "ハンドル位置名称";
                this.columnHandleInfoNm.MaxLength = 12;
                // --- ADD 2013/03/19 ----------<<<<<

                this.CaseSensitive = true;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public CarModelUIRow NewCarModelInfoRow()
            {
                return ((CarModelUIRow)(this.NewRow()));
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="builder"></param>
            /// <returns></returns>
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new CarModelUIRow(builder);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            protected override global::System.Type GetRowType()
            {
                return typeof(CarModelUIRow);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            public void RemoveCarModelInfoRow(CarModelUIRow row)
            {
                this.Rows.Remove(row);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public class CarModelUIRow : DataRow
        {

            private CarModelUIDataTable tableCarModelInfo;

            internal CarModelUIRow(DataRowBuilder rb)
                :
                    base(rb)
            {
                this.tableCarModelInfo = ((CarModelUIDataTable)(this.Table));
            }
            /// <summary>
            /// 
            /// </summary>
            public int MakerCode
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.MakerCodeColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.MakerCodeColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string MakerFullName
            {
                get
                {
                    if (this.IsMakerFullNameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.MakerFullNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.MakerFullNameColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int ModelCode
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.ModelCodeColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.ModelCodeColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int ModelSubCode
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.ModelSubCodeColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.ModelSubCodeColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string ModelFullName
            {
                get
                {
                    if (this.IsModelFullNameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.ModelFullNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.ModelFullNameColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int ProduceTypeOfYearInput
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelInfo.ProduceTypeOfYearInputColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelUI\' にある列 \'ProduceTypeOfYearInput\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.ProduceTypeOfYearInputColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int StProduceTypeOfYear
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelInfo.StProduceTypeOfYearColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelUI\' にある列 \'StProduceTypeOfYear\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.StProduceTypeOfYearColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int EdProduceTypeOfYear
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelInfo.EdProduceTypeOfYearColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelUI\' にある列 \'EdProduceTypeOfYear\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.EdProduceTypeOfYearColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string FullModel
            {
                get
                {
                    return ((string)(this[this.tableCarModelInfo.FullModelColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.FullModelColumn] = value;
                }
            }
            // 2009.01.28 >>>
            ///// <summary>
            ///// 
            ///// </summary>
            //public int ProduceFrameNoInput
            //{
            //    get
            //    {
            //        try
            //        {
            //            return ((int)(this[this.tableCarModelInfo.ProduceFrameNoInputColumn]));
            //        }
            //        catch (global::System.InvalidCastException e)
            //        {
            //            throw new StrongTypingException("テーブル \'CarModelUI\' にある列 \'ProduceFrameNoInput\' の値は DBNull です。", e);
            //        }
            //    }
            //    set
            //    {
            //        this[this.tableCarModelInfo.ProduceFrameNoInputColumn] = value;
            //    }
            //}
            /// <summary>
            /// 
            /// </summary>
            public string FrameNo
            {
                get
                {
                    try
                    {
                        return ( (string)( this[this.tableCarModelInfo.FrameNoColumn] ) );
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelUI\' にある列 \'FrameNo\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.FrameNoColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int SearchFrameNo
            {
                get
                {
                    try
                    {
                        return ( (int)( this[this.tableCarModelInfo.SearchFrameNoColumn] ) );
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelUI\' にある列 \'SearchFrameNo\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.SearchFrameNoColumn] = value;
                }
            }
            // 2009.01.28 <<<
            /// <summary>
            /// 
            /// </summary>
            public int StProduceFrameNo
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelInfo.StProduceFrameNoColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelUI\' にある列 \'StProduceFrameNo\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.StProduceFrameNoColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int EdProduceFrameNo
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelInfo.EdProduceFrameNoColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelUI\' にある列 \'EdProduceFrameNo\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.EdProduceFrameNoColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string ModelGradeNm
            {
                get
                {
                    if (this.IsModelGradeNmNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.ModelGradeNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.ModelGradeNmColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string BodyName
            {
                get
                {
                    if (this.IsBodyNameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.BodyNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.BodyNameColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int DoorCount
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.DoorCountColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.DoorCountColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string EngineModelNm
            {
                get
                {
                    if (this.IsEngineModelNmNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.EngineModelNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.EngineModelNmColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string EngineDisplaceNm
            {
                get
                {
                    if (this.IsEngineDisplaceNmNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.EngineDisplaceNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.EngineDisplaceNmColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string EDivNm
            {
                get
                {
                    if (this.IsEDivNmNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.EDivNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.EDivNmColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string TransmissionNm
            {
                get
                {
                    if (this.IsTransmissionNmNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.TransmissionNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.TransmissionNmColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string WheelDriveMethodNm
            {
                get
                {
                    if (this.IsWheelDriveMethodNm())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.WheelDriveMethodNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.WheelDriveMethodNmColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string ShiftNm
            {
                get
                {
                    if (this.IsShiftNmNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.ShiftNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.ShiftNmColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpec1
            {
                get
                {
                    if (this.IsAddiCarSpec1Null())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.AddiCarSpec1Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpec1Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpec2
            {
                get
                {
                    if (this.IsAddiCarSpec2Null())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.AddiCarSpec2Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpec2Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpec3
            {
                get
                {
                    if (this.IsAddiCarSpec3Null())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.AddiCarSpec3Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpec3Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpec4
            {
                get
                {
                    if (this.IsAddiCarSpec4Null())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.AddiCarSpec4Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpec4Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpec5
            {
                get
                {
                    if (this.IsAddiCarSpec5Null())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.AddiCarSpec5Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpec5Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpec6
            {
                get
                {
                    if (this.IsAddiCarSpec6Null())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.AddiCarSpec6Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.AddiCarSpec6Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int ModelDesignationNo
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.ModelDesignationNoColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.ModelDesignationNoColumn] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public int CategoryNo
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.CategoryNoColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.CategoryNoColumn] = value;
                }
            }

            // --- ADD 2013/03/19 ---------->>>>>
            /// <summary> 国産/外車区分 </summary>
            public int DomesticForeignCode
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.DomesticForeignCodeColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.DomesticForeignCodeColumn] = value;
                }
            }

            /// <summary> 国産/外車区分名称 </summary>
            public string DomesticForeignName
            {
                get
                {
                    if (this.IsDomesticForeignNameNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.DomesticForeignNameColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.DomesticForeignNameColumn] = value;
                }
            }

            /// <summary> ハンドル位置 </summary>
            public int HandleInfoCd
            {
                get
                {
                    return ((int)(this[this.tableCarModelInfo.HandleInfoCdColumn]));
                }
                set
                {
                    this[this.tableCarModelInfo.HandleInfoCdColumn] = value;
                }
            }

            /// <summary> ハンドル位置名称 </summary>
            public string HandleInfoNm
            {
                get
                {
                    if (this.IsHandleInfoNmNull())
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return ((string)(this[this.tableCarModelInfo.HandleInfoNmColumn]));
                    }
                }
                set
                {
                    this[this.tableCarModelInfo.HandleInfoNmColumn] = value;
                }
            }
            // --- ADD 2013/03/19 ----------<<<<<

            /// <summary>
            /// 
            /// </summary>
            public bool IsMakerFullNameNull()
            {
                return this.IsNull(this.tableCarModelInfo.MakerFullNameColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetMakerFullNameNull()
            {
                this[this.tableCarModelInfo.MakerFullNameColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsModelFullNameNull()
            {
                return this.IsNull(this.tableCarModelInfo.ModelFullNameColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetModelFullNameNull()
            {
                this[this.tableCarModelInfo.ModelFullNameColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsStProduceTypeOfYearNull()
            {
                return this.IsNull(this.tableCarModelInfo.StProduceTypeOfYearColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetStProduceTypeOfYearNull()
            {
                this[this.tableCarModelInfo.StProduceTypeOfYearColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsEdProduceTypeOfYearNull()
            {
                return this.IsNull(this.tableCarModelInfo.EdProduceTypeOfYearColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetEdProduceTypeOfYearNull()
            {
                this[this.tableCarModelInfo.EdProduceTypeOfYearColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsBodyNameNull()
            {
                return this.IsNull(this.tableCarModelInfo.BodyNameColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetBodyNameNull()
            {
                this[this.tableCarModelInfo.BodyNameColumn] = global::System.Convert.DBNull;
            }
            // 2009.01.28 >>>
            ///// <summary>
            ///// 
            ///// </summary>
            //public bool IsProduceFrameNoInputNull()
            //{
            //    return this.IsNull(this.tableCarModelInfo.ProduceFrameNoInputColumn);
            //}
            ///// <summary>
            ///// 
            ///// </summary>
            //public void SetProduceFrameNoInputNull()
            //{
            //    this[this.tableCarModelInfo.ProduceFrameNoInputColumn] = global::System.Convert.DBNull;
            //}
            /// <summary>
            /// 
            /// </summary>
            public bool IsFrameNoNull()
            {
                return this.IsNull(this.tableCarModelInfo.FrameNoColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetFrameNoNull()
            {
                this[this.tableCarModelInfo.FrameNoColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsSearchFrameNoNull()
            {
                return this.IsNull(this.tableCarModelInfo.SearchFrameNoColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetSearchFrameNoNull()
            {
                this[this.tableCarModelInfo.SearchFrameNoColumn] = global::System.Convert.DBNull;
            }
            // 2009.01.28 <<<
            /// <summary>
            /// 
            /// </summary>
            public bool IsStProduceFrameNoNull()
            {
                return this.IsNull(this.tableCarModelInfo.StProduceFrameNoColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetStProduceFrameNoNull()
            {
                this[this.tableCarModelInfo.StProduceFrameNoColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsEdProduceFrameNoNull()
            {
                return this.IsNull(this.tableCarModelInfo.EdProduceFrameNoColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetEdProduceFrameNoNull()
            {
                this[this.tableCarModelInfo.EdProduceFrameNoColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsModelGradeNmNull()
            {
                return this.IsNull(this.tableCarModelInfo.ModelGradeNmColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetModelGradeNmNull()
            {
                this[this.tableCarModelInfo.ModelGradeNmColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsEngineModelNmNull()
            {
                return this.IsNull(this.tableCarModelInfo.EngineModelNmColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetEngineModelNmNull()
            {
                this[this.tableCarModelInfo.EngineModelNmColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsEngineDisplaceNmNull()
            {
                return this.IsNull(this.tableCarModelInfo.EngineDisplaceNmColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetEngineDisplaceNmNull()
            {
                this[this.tableCarModelInfo.EngineDisplaceNmColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsEDivNmNull()
            {
                return this.IsNull(this.tableCarModelInfo.EDivNmColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetEDivNmNull()
            {
                this[this.tableCarModelInfo.EDivNmColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsTransmissionNmNull()
            {
                return this.IsNull(this.tableCarModelInfo.TransmissionNmColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetTransmissionNmNull()
            {
                this[this.tableCarModelInfo.TransmissionNmColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsWheelDriveMethodNm()
            {
                return this.IsNull(this.tableCarModelInfo.WheelDriveMethodNmColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetWheelDriveMethodNmNull()
            {
                this[this.tableCarModelInfo.WheelDriveMethodNmColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsShiftNmNull()
            {
                return this.IsNull(this.tableCarModelInfo.ShiftNmColumn);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetShiftNmNull()
            {
                this[this.tableCarModelInfo.ShiftNmColumn] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec1Null()
            {
                return this.IsNull(this.tableCarModelInfo.AddiCarSpec1Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec1Null()
            {
                this[this.tableCarModelInfo.AddiCarSpec1Column] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec2Null()
            {
                return this.IsNull(this.tableCarModelInfo.AddiCarSpec2Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec2Null()
            {
                this[this.tableCarModelInfo.AddiCarSpec2Column] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec3Null()
            {
                return this.IsNull(this.tableCarModelInfo.AddiCarSpec3Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec3Null()
            {
                this[this.tableCarModelInfo.AddiCarSpec3Column] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec4Null()
            {
                return this.IsNull(this.tableCarModelInfo.AddiCarSpec4Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec4Null()
            {
                this[this.tableCarModelInfo.AddiCarSpec4Column] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec5Null()
            {
                return this.IsNull(this.tableCarModelInfo.AddiCarSpec5Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec5Null()
            {
                this[this.tableCarModelInfo.AddiCarSpec5Column] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec6Null()
            {
                return this.IsNull(this.tableCarModelInfo.AddiCarSpec6Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec6Null()
            {
                this[this.tableCarModelInfo.AddiCarSpec6Column] = global::System.Convert.DBNull;
            }
            // --- ADD 2013/03/19 ---------->>>>>
            /// <summary> 国産/外車区分名称NULLチェック </summary>
            public bool IsDomesticForeignNameNull()
            {
                return this.IsNull(this.tableCarModelInfo.DomesticForeignNameColumn);
            }

            /// <summary> ハンドル位置名称NULLチェック </summary>
            public bool IsHandleInfoNmNull()
            {
                return this.IsNull(this.tableCarModelInfo.HandleInfoNmColumn);
            }
            // --- ADD 2013/03/19 ----------<<<<<
        }
    }
}
