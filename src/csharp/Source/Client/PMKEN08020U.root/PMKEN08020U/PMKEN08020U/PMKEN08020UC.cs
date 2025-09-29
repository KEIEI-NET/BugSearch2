using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 同一型式表示のためのデータセット定義
    /// </summary>
    /// <remarks>
    /// <br>Note       : 同一型式表示のためのデータセット定義です。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: 2010.05.11  22018  鈴木 正臣</br>
    /// <br>           : 自由検索オプション対応</br>
    /// </remarks>
    internal partial class CarModelRel : DataSet
    {

        private CarModelHdDataTable tableCarModelHd;

        private CarModelDtDataTable tableCarModelDt;

        private DataRelation relationCarModelHd_CARMODELRF;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        public CarModelRel()
        {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        protected CarModelRel(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
            :
                base(info, context, false)
        {
            if ((this.IsBinarySerialized(info, context) == true))
            {
                this.InitVars(false);
                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((this.DetermineSchemaSerializationMode(info, context) == SchemaSerializationMode.IncludeSchema))
            {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
                if ((ds.Tables["CarModelHd"] != null))
                {
                    base.Tables.Add(new CarModelHdDataTable(ds.Tables["CarModelHd"]));
                }
                if ((ds.Tables["CarModelDt"] != null))
                {
                    base.Tables.Add(new CarModelDtDataTable(ds.Tables["CarModelDt"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                this.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
            }
            this.GetSerializationData(info, context);
        }

        public CarModelHdDataTable CarModelHd
        {
            get
            {
                return this.tableCarModelHd;
            }
        }

        public CarModelDtDataTable CarModelDt
        {
            get
            {
                return this.tableCarModelDt;
            }
        }

        public override SchemaSerializationMode SchemaSerializationMode
        {
            get
            {
                return this._schemaSerializationMode;
            }
            set
            {
                this._schemaSerializationMode = value;
            }
        }

        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        public new DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        protected override void InitializeDerivedDataSet()
        {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        public override DataSet Clone()
        {
            CarModelRel cln = ((CarModelRel)(base.Clone()));
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        protected override void ReadXmlSerializable(global::System.Xml.XmlReader reader)
        {
            if ((this.DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema))
            {
                this.Reset();
                DataSet ds = new DataSet();
                ds.ReadXml(reader);
                if ((ds.Tables["CarModelHd"] != null))
                {
                    base.Tables.Add(new CarModelHdDataTable(ds.Tables["CarModelHd"]));
                }
                if ((ds.Tables["CarModelDt"] != null))
                {
                    base.Tables.Add(new CarModelDtDataTable(ds.Tables["CarModelDt"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                this.ReadXml(reader);
                this.InitVars();
            }
        }

        protected override global::System.Xml.Schema.XmlSchema GetSchemaSerializable()
        {
            global::System.IO.MemoryStream stream = new global::System.IO.MemoryStream();
            this.WriteXmlSchema(new global::System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return global::System.Xml.Schema.XmlSchema.Read(new global::System.Xml.XmlTextReader(stream), null);
        }

        internal void InitVars()
        {
            this.InitVars(true);
        }

        internal void InitVars(bool initTable)
        {
            this.tableCarModelHd = ((CarModelHdDataTable)(base.Tables["CarModelHd"]));
            if ((initTable == true))
            {
                if ((this.tableCarModelHd != null))
                {
                    this.tableCarModelHd.InitVars();
                }
            }
            this.tableCarModelDt = ((CarModelDtDataTable)(base.Tables["CarModelDt"]));
            if ((initTable == true))
            {
                if ((this.tableCarModelDt != null))
                {
                    this.tableCarModelDt.InitVars();
                }
            }
            this.relationCarModelHd_CARMODELRF = this.Relations["CarModelHd_CARMODELRF"];
        }

        private void InitClass()
        {
            this.DataSetName = "CarModelRel";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/CarModelRel.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tableCarModelHd = new CarModelHdDataTable();
            base.Tables.Add(this.tableCarModelHd);
            this.tableCarModelDt = new CarModelDtDataTable();
            base.Tables.Add(this.tableCarModelDt);
            // --- UPD m.suzuki 2010/05/11 ---------->>>>>
            //this.relationCarModelHd_CARMODELRF = new DataRelation("CarModelHd_CARMODELRF", new DataColumn[] {
            //            this.tableCarModelHd.FullModelColumn}, new DataColumn[] {
            //            this.tableCarModelDt.FullModelColumn}, false);
            this.relationCarModelHd_CARMODELRF = new DataRelation( "CarModelHd_CARMODELRF", new DataColumn[] {
                        this.tableCarModelHd.FullModelColumn,this.tableCarModelHd.FreeSearchSortDivColumn}, new DataColumn[] {
                        this.tableCarModelDt.FullModelColumn,this.tableCarModelDt.FreeSearchSortDivColumn}, false );
            // --- UPD m.suzuki 2010/05/11 ----------<<<<<
            this.Relations.Add(this.relationCarModelHd_CARMODELRF);
        }

        private bool ShouldSerializeCarModelHd()
        {
            return false;
        }

        private bool ShouldSerializeCarModelDt()
        {
            return false;
        }

        public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(global::System.Xml.Schema.XmlSchemaSet xs)
        {
            CarModelRel ds = new CarModelRel();
            global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
            global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
            global::System.Xml.Schema.XmlSchemaAny any = new global::System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
            if (xs.Contains(dsSchema.TargetNamespace))
            {
                global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                try
                {
                    global::System.Xml.Schema.XmlSchema schema = null;
                    dsSchema.Write(s1);
                    for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); )
                    {
                        schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                        s2.SetLength(0);
                        schema.Write(s2);
                        if ((s1.Length == s2.Length))
                        {
                            s1.Position = 0;
                            s2.Position = 0;
                            for (; ((s1.Position != s1.Length)
                                        && (s1.ReadByte() == s2.ReadByte())); )
                            {
                                ;
                            }
                            if ((s1.Position == s1.Length))
                            {
                                return type;
                            }
                        }
                    }
                }
                finally
                {
                    if ((s1 != null))
                    {
                        s1.Close();
                    }
                    if ((s2 != null))
                    {
                        s2.Close();
                    }
                }
            }
            xs.Add(dsSchema);
            return type;
        }

        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        public partial class CarModelHdDataTable : DataTable, global::System.Collections.IEnumerable
        {

            private DataColumn columnStProduceTypeOfYear;

            private DataColumn columnEdProduceTypeOfYear;

            private DataColumn columnStProduceYear;
            private DataColumn columnEdProduceYear;

            private DataColumn columnStProduceFrameNo;

            private DataColumn columnEdProduceFrameNo;

            private DataColumn columnFullModel;

            // --- ADD m.suzuki 2010/05/11 ---------->>>>>
            private DataColumn columnFreeSearchSortDiv;
            // --- ADD m.suzuki 2010/05/11 ----------<<<<<

            public CarModelHdDataTable()
            {
                this.TableName = "CarModelHd";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal CarModelHdDataTable(DataTable table)
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

            protected CarModelHdDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
                :
                    base(info, context)
            {
                this.InitVars();
            }

            public DataColumn StProduceTypeOfYearColumn
            {
                get
                {
                    return this.columnStProduceTypeOfYear;
                }
            }

            public DataColumn EdProduceTypeOfYearColumn
            {
                get
                {
                    return this.columnEdProduceTypeOfYear;
                }
            }

            /// <summary>
            /// 和暦表示用
            /// </summary>
            public DataColumn StProduceYearColumn
            {
                get
                {
                    return this.columnStProduceYear;
                }
            }

            /// <summary>
            /// 和暦表示用
            /// </summary>
            public DataColumn EdProduceYearColumn
            {
                get
                {
                    return this.columnEdProduceYear;
                }
            }

            public DataColumn StProduceFrameNoColumn
            {
                get
                {
                    return this.columnStProduceFrameNo;
                }
            }

            public DataColumn EdProduceFrameNoColumn
            {
                get
                {
                    return this.columnEdProduceFrameNo;
                }
            }

            public DataColumn FullModelColumn
            {
                get
                {
                    return this.columnFullModel;
                }
            }

            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public CarModelHdRow this[int index]
            {
                get
                {
                    return ((CarModelHdRow)(this.Rows[index]));
                }
            }
            // --- ADD m.suzuki 2010/05/11 ---------->>>>>
            /// <summary>
            /// 
            /// </summary>
            public DataColumn FreeSearchSortDivColumn
            {
                get
                {
                    return this.columnFreeSearchSortDiv;
                }
            }
            // --- ADD m.suzuki 2010/05/11 ----------<<<<<

            public void AddCarModelHdRow(CarModelHdRow row)
            {
                this.Rows.Add(row);
            }

            // --- UPD m.suzuki 2010/05/11 ---------->>>>>
            //public CarModelHdRow AddCarModelHdRow(int StProduceTypeOfYear, int EdProduceTypeOfYear, DateTime StProduceYear, DateTime EdProduceYear, 
            //    int StProduceFrameNo, int EdProduceFrameNo, string FullModel)
            //{
            //    CarModelHdRow rowCarModelHdRow = ((CarModelHdRow)(this.NewRow()));
            //    object[] columnValuesArray = new object[] {
            //            StProduceTypeOfYear,
            //            EdProduceTypeOfYear,
            //            StProduceYear,
            //            EdProduceYear,
            //            StProduceFrameNo,
            //            EdProduceFrameNo,
            //            FullModel};
            //    rowCarModelHdRow.ItemArray = columnValuesArray;
            //    this.Rows.Add(rowCarModelHdRow);
            //    return rowCarModelHdRow;
            //}
            public CarModelHdRow AddCarModelHdRow( int StProduceTypeOfYear, int EdProduceTypeOfYear, DateTime StProduceYear, DateTime EdProduceYear,
                int StProduceFrameNo, int EdProduceFrameNo, string FullModel, int FreeSearchSortDiv )
            {
                CarModelHdRow rowCarModelHdRow = ((CarModelHdRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        StProduceTypeOfYear,
                        EdProduceTypeOfYear,
                        StProduceYear,
                        EdProduceYear,
                        StProduceFrameNo,
                        EdProduceFrameNo,
                        FullModel,
                        FreeSearchSortDiv
                        };
                rowCarModelHdRow.ItemArray = columnValuesArray;
                this.Rows.Add( rowCarModelHdRow );
                return rowCarModelHdRow;
            }
            // --- UPD m.suzuki 2010/05/11 ----------<<<<<

            // --- UPD m.suzuki 2010/05/11 ---------->>>>>
            //public CarModelHdRow FindByFullModel(string FullModel)
            //{
            //    return ((CarModelHdRow)(this.Rows.Find(new object[] {
            //                FullModel})));
            //}
            public CarModelHdRow FindByFullModelFreeSearchSortDiv( string FullModel, int FreeSearchSortDiv )
            {
                return ((CarModelHdRow)(this.Rows.Find( new object[] {
                            FullModel,FreeSearchSortDiv} )));
            }
            // --- UPD m.suzuki 2010/05/11 ----------<<<<<


            public virtual global::System.Collections.IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            public override DataTable Clone()
            {
                CarModelHdDataTable cln = ((CarModelHdDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }

            protected override DataTable CreateInstance()
            {
                return new CarModelHdDataTable();
            }

            internal void InitVars()
            {
                this.columnStProduceTypeOfYear = base.Columns["StProduceTypeOfYear"];
                this.columnEdProduceTypeOfYear = base.Columns["EdProduceTypeOfYear"];
                this.columnStProduceYear = base.Columns["StProduceYear"];
                this.columnEdProduceYear = base.Columns["EdProduceYear"];
                this.columnStProduceFrameNo = base.Columns["StProduceFrameNo"];
                this.columnEdProduceFrameNo = base.Columns["EdProduceFrameNo"];
                this.columnFullModel = base.Columns["FullModel"];
                // --- ADD m.suzuki 2010/05/11 ---------->>>>>
                this.columnFreeSearchSortDiv = base.Columns["FreeSearchSortDiv"];
                // --- ADD m.suzuki 2010/05/11 ----------<<<<<
            }

            private void InitClass()
            {
                this.columnStProduceTypeOfYear = new DataColumn("StProduceTypeOfYear", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnStProduceTypeOfYear);
                this.columnEdProduceTypeOfYear = new DataColumn("EdProduceTypeOfYear", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEdProduceTypeOfYear);
                this.columnStProduceYear = new DataColumn("StProduceYear", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnStProduceYear);
                this.columnEdProduceYear = new DataColumn("EdProduceYear", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnEdProduceYear);
                this.columnStProduceFrameNo = new DataColumn("StProduceFrameNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnStProduceFrameNo);
                this.columnEdProduceFrameNo = new DataColumn("EdProduceFrameNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEdProduceFrameNo);
                this.columnFullModel = new DataColumn("FullModel", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnFullModel);
                // --- ADD m.suzuki 2010/05/11 ---------->>>>>
                this.columnFreeSearchSortDiv = new DataColumn( "FreeSearchSortDiv", typeof( int ), null, MappingType.Element );
                base.Columns.Add( this.columnFreeSearchSortDiv );
                // --- ADD m.suzuki 2010/05/11 ----------<<<<<
                // --- UPD m.suzuki 2010/05/11 ---------->>>>>
                //this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                //                this.columnFullModel}, true));
                this.Constraints.Add( new UniqueConstraint( "Constraint1", new DataColumn[] {
                                this.columnFullModel,this.columnFreeSearchSortDiv}, true ) );
                // --- UPD m.suzuki 2010/05/11 ----------<<<<<
                this.columnStProduceTypeOfYear.Caption = "生産年式(開始)";
                this.columnEdProduceTypeOfYear.Caption = "生産年式(終了)";
                this.columnStProduceYear.Caption = "生産年式(開始)";
                this.columnStProduceYear.DefaultValue = DateTime.MinValue;
                this.columnEdProduceYear.DefaultValue = DateTime.MinValue;
                this.columnStProduceFrameNo.Caption = "車台番号(開始)";
                this.columnEdProduceFrameNo.Caption = "車台番号(終了)";
                this.columnFullModel.AllowDBNull = false;
                // --- DEL m.suzuki 2010/05/11 ---------->>>>>
                //this.columnFullModel.Unique = true;
                // --- DEL m.suzuki 2010/05/11 ----------<<<<<
                this.columnFullModel.Caption = "型式";
                this.columnFullModel.MaxLength = 44;
                // --- ADD m.suzuki 2010/05/11 ---------->>>>>
                this.columnFreeSearchSortDiv.Caption = "自由検索ソート区分";
                // --- ADD m.suzuki 2010/05/11 ----------<<<<<
            }

            public CarModelHdRow NewCarModelHdRow()
            {
                return ((CarModelHdRow)(this.NewRow()));
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new CarModelHdRow(builder);
            }

            protected override global::System.Type GetRowType()
            {
                return typeof(CarModelHdRow);
            }

            public void RemoveCarModelHdRow(CarModelHdRow row)
            {
                this.Rows.Remove(row);
            }

            public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(global::System.Xml.Schema.XmlSchemaSet xs)
            {
                global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
                global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
                CarModelRel ds = new CarModelRel();
                global::System.Xml.Schema.XmlSchemaAny any1 = new global::System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                global::System.Xml.Schema.XmlSchemaAny any2 = new global::System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                global::System.Xml.Schema.XmlSchemaAttribute attribute1 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                global::System.Xml.Schema.XmlSchemaAttribute attribute2 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "CarModelHdDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
                if (xs.Contains(dsSchema.TargetNamespace))
                {
                    global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                    global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                    try
                    {
                        global::System.Xml.Schema.XmlSchema schema = null;
                        dsSchema.Write(s1);
                        for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); )
                        {
                            schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                            s2.SetLength(0);
                            schema.Write(s2);
                            if ((s1.Length == s2.Length))
                            {
                                s1.Position = 0;
                                s2.Position = 0;
                                for (; ((s1.Position != s1.Length)
                                            && (s1.ReadByte() == s2.ReadByte())); )
                                {
                                    ;
                                }
                                if ((s1.Position == s1.Length))
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if ((s1 != null))
                        {
                            s1.Close();
                        }
                        if ((s2 != null))
                        {
                            s2.Close();
                        }
                    }
                }
                xs.Add(dsSchema);
                return type;
            }
        }

        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        public partial class CarModelDtDataTable : DataTable, global::System.Collections.IEnumerable
        {

            private DataColumn columnModelGradeNm;

            private DataColumn columnBodyName;

            private DataColumn columnDoorCount;

            private DataColumn columnEngineModelNm;

            private DataColumn columnEngineDisplaceNm;

            private DataColumn columnEDivNm;

            private DataColumn columnTransmissionNm;

            private DataColumn columnShiftNm;

            private DataColumn columnWheelDriveMethodNm;

            private DataColumn columnPartsOfferFlag;

            private DataColumn columnFullModel;

            private DataColumn columnNo;

            private DataColumn columnAddiCarSpec1;

            private DataColumn columnAddiCarSpec2;

            private DataColumn columnAddiCarSpec3;

            private DataColumn columnAddiCarSpec4;

            private DataColumn columnAddiCarSpec5;

            private DataColumn columnAddiCarSpec6;

            private DataColumn columnAddiCarSpecTitle1;

            private DataColumn columnAddiCarSpecTitle2;

            private DataColumn columnAddiCarSpecTitle3;

            private DataColumn columnAddiCarSpecTitle4;

            private DataColumn columnAddiCarSpecTitle5;

            private DataColumn columnAddiCarSpecTitle6;

            // --- ADD m.suzuki 2010/05/11 ---------->>>>>
            private DataColumn columnFreeSrchMdlFxdNo;
            private DataColumn columnFreeSearchSortDiv;
            // --- ADD m.suzuki 2010/05/11 ----------<<<<<


            public CarModelDtDataTable()
            {
                this.TableName = "CarModelDt";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            internal CarModelDtDataTable(DataTable table)
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

            protected CarModelDtDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
                :
                    base(info, context)
            {
                this.InitVars();
            }

            public DataColumn ModelGradeNmColumn
            {
                get
                {
                    return this.columnModelGradeNm;
                }
            }

            public DataColumn BodyNameColumn
            {
                get
                {
                    return this.columnBodyName;
                }
            }

            public DataColumn DoorCountColumn
            {
                get
                {
                    return this.columnDoorCount;
                }
            }

            public DataColumn EngineModelNmColumn
            {
                get
                {
                    return this.columnEngineModelNm;
                }
            }

            public DataColumn EngineDisplaceNmColumn
            {
                get
                {
                    return this.columnEngineDisplaceNm;
                }
            }

            public DataColumn EDivNmColumn
            {
                get
                {
                    return this.columnEDivNm;
                }
            }

            public DataColumn TransmissionNmColumn
            {
                get
                {
                    return this.columnTransmissionNm;
                }
            }

            public DataColumn ShiftNmColumn
            {
                get
                {
                    return this.columnShiftNm;
                }
            }

            public DataColumn WheelDriveMethodNmColumn
            {
                get
                {
                    return this.columnWheelDriveMethodNm;
                }
            }

            public DataColumn PartsOfferFlagColumn
            {
                get
                {
                    return this.columnPartsOfferFlag;
                }
            }

            public DataColumn FullModelColumn
            {
                get
                {
                    return this.columnFullModel;
                }
            }

            public DataColumn NoColumn
            {
                get
                {
                    return this.columnNo;
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
            public DataColumn AddiCarSpecTitle1Column
            {
                get
                {
                    return this.columnAddiCarSpecTitle1;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpecTitle2Column
            {
                get
                {
                    return this.columnAddiCarSpecTitle2;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpecTitle3Column
            {
                get
                {
                    return this.columnAddiCarSpecTitle3;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpecTitle4Column
            {
                get
                {
                    return this.columnAddiCarSpecTitle4;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpecTitle5Column
            {
                get
                {
                    return this.columnAddiCarSpecTitle5;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn AddiCarSpecTitle6Column
            {
                get
                {
                    return this.columnAddiCarSpecTitle6;
                }
            }
            // --- ADD m.suzuki 2010/05/11 ---------->>>>>
            /// <summary>
            /// 
            /// </summary>
            public DataColumn FreeSrchMdlFxdNoColumn
            {
                get
                {
                    return this.columnFreeSrchMdlFxdNo;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public DataColumn FreeSearchSortDivColumn
            {
                get
                {
                    return this.columnFreeSearchSortDiv;
                }
            }
            // --- ADD m.suzuki 2010/05/11 ----------<<<<<

            public int Count
            {
                get
                {
                    return this.Rows.Count;
                }
            }

            public CarModelDtRow this[int index]
            {
                get
                {
                    return ((CarModelDtRow)(this.Rows[index]));
                }
            }

            public void AddCarModelDtRow(CarModelDtRow row)
            {
                this.Rows.Add(row);
            }

            // --- UPD m.suzuki 2010/05/11 ---------->>>>>
            //public CarModelDtRow AddCarModelDtRow(string ModelGradeNm, string BodyName, int DoorCount, string EngineModelNm, 
            //    string EngineDisplaceNm, string EDivNm, string TransmissionNm, string ShiftNm, string WheelDriveMethodNm, //string FullModel,
            //    string AddiCarSpec1, string AddiCarSpec2, string AddiCarSpec3, string AddiCarSpec4, string AddiCarSpec5,
            //    string AddiCarSpec6, string AddiCarSpecTitle1, string AddiCarSpecTitle2, string AddiCarSpecTitle3,
            //    string AddiCarSpecTitle4, string AddiCarSpecTitle5, string AddiCarSpecTitle6,
            //    CarModelHdRow parentCarModelHdRowByCarModelHd_CARMODELRF)
            //{
            //    CarModelDtRow rowCarModelDtRow = ((CarModelDtRow)(this.NewRow()));
            //    object[] columnValuesArray = new object[] {
            //            ModelGradeNm,
            //            BodyName,
            //            DoorCount,
            //            EngineModelNm,
            //            EngineDisplaceNm,
            //            EDivNm,
            //            TransmissionNm,
            //            ShiftNm,
            //            WheelDriveMethodNm,
            //            null,
            //            null,//FullModel,
            //            null,
            //            AddiCarSpec1,
            //            AddiCarSpec2,
            //            AddiCarSpec3,
            //            AddiCarSpec4,
            //            AddiCarSpec5,
            //            AddiCarSpec6,
            //            AddiCarSpecTitle1,
            //            AddiCarSpecTitle2,
            //            AddiCarSpecTitle3,
            //            AddiCarSpecTitle4,
            //            AddiCarSpecTitle5,
            //            AddiCarSpecTitle6
            //            };
            //    if ((parentCarModelHdRowByCarModelHd_CARMODELRF != null))
            //    {
            //        columnValuesArray[10] = parentCarModelHdRowByCarModelHd_CARMODELRF[6];
            //    }
            //    rowCarModelDtRow.ItemArray = columnValuesArray;
            //    this.Rows.Add(rowCarModelDtRow);
            //    return rowCarModelDtRow;
            //}
            public CarModelDtRow AddCarModelDtRow( string ModelGradeNm, string BodyName, int DoorCount, string EngineModelNm,
                string EngineDisplaceNm, string EDivNm, string TransmissionNm, string ShiftNm, string WheelDriveMethodNm, //string FullModel,
                string AddiCarSpec1, string AddiCarSpec2, string AddiCarSpec3, string AddiCarSpec4, string AddiCarSpec5,
                string AddiCarSpec6, string AddiCarSpecTitle1, string AddiCarSpecTitle2, string AddiCarSpecTitle3,
                string AddiCarSpecTitle4, string AddiCarSpecTitle5, string AddiCarSpecTitle6,
                string FreeSrchMdlFxdNo, int FreeSearchSortDiv,
                CarModelHdRow parentCarModelHdRowByCarModelHd_CARMODELRF )
            {
                CarModelDtRow rowCarModelDtRow = ((CarModelDtRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        ModelGradeNm,
                        BodyName,
                        DoorCount,
                        EngineModelNm,
                        EngineDisplaceNm,
                        EDivNm,
                        TransmissionNm,
                        ShiftNm,
                        WheelDriveMethodNm,
                        null,
                        null,//FullModel,
                        null,
                        AddiCarSpec1,
                        AddiCarSpec2,
                        AddiCarSpec3,
                        AddiCarSpec4,
                        AddiCarSpec5,
                        AddiCarSpec6,
                        AddiCarSpecTitle1,
                        AddiCarSpecTitle2,
                        AddiCarSpecTitle3,
                        AddiCarSpecTitle4,
                        AddiCarSpecTitle5,
                        AddiCarSpecTitle6,
                        FreeSrchMdlFxdNo,
                        FreeSearchSortDiv
                        };
                if ( (parentCarModelHdRowByCarModelHd_CARMODELRF != null) )
                {
                    columnValuesArray[10] = parentCarModelHdRowByCarModelHd_CARMODELRF[6];
                }
                rowCarModelDtRow.ItemArray = columnValuesArray;
                this.Rows.Add( rowCarModelDtRow );
                return rowCarModelDtRow;
            }
            // --- UPD m.suzuki 2010/05/11 ----------<<<<<

            public CarModelDtRow FindByFullModelNo(string FullModel, int No)
            {
                return ((CarModelDtRow)(this.Rows.Find(new object[] {
                            FullModel,
                            No})));
            }

            public virtual global::System.Collections.IEnumerator GetEnumerator()
            {
                return this.Rows.GetEnumerator();
            }

            public override DataTable Clone()
            {
                CarModelDtDataTable cln = ((CarModelDtDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }

            protected override DataTable CreateInstance()
            {
                return new CarModelDtDataTable();
            }

            internal void InitVars()
            {
                this.columnModelGradeNm = base.Columns["ModelGradeNm"];
                this.columnBodyName = base.Columns["BodyName"];
                this.columnDoorCount = base.Columns["DoorCount"];
                this.columnEngineModelNm = base.Columns["EngineModelNm"];
                this.columnEngineDisplaceNm = base.Columns["EngineDisplaceNm"];
                this.columnEDivNm = base.Columns["EDivNm"];
                this.columnTransmissionNm = base.Columns["TransmissionNm"];
                this.columnShiftNm = base.Columns["ShiftNm"];
                this.columnWheelDriveMethodNm = base.Columns["WheelDriveMethodNm"];
                this.columnPartsOfferFlag = base.Columns["PartsExistence"];
                this.columnFullModel = base.Columns["FullModel"];
                this.columnNo = base.Columns["No"];
                this.columnAddiCarSpec1 = base.Columns["AddiCarSpec1"];
                this.columnAddiCarSpec2 = base.Columns["AddiCarSpec2"];
                this.columnAddiCarSpec3 = base.Columns["AddiCarSpec3"];
                this.columnAddiCarSpec4 = base.Columns["AddiCarSpec4"];
                this.columnAddiCarSpec5 = base.Columns["AddiCarSpec5"];
                this.columnAddiCarSpec6 = base.Columns["AddiCarSpec6"];
                this.columnAddiCarSpecTitle1 = base.Columns["AddiCarSpecTitle1"];
                this.columnAddiCarSpecTitle2 = base.Columns["AddiCarSpecTitle2"];
                this.columnAddiCarSpecTitle3 = base.Columns["AddiCarSpecTitle3"];
                this.columnAddiCarSpecTitle4 = base.Columns["AddiCarSpecTitle4"];
                this.columnAddiCarSpecTitle5 = base.Columns["AddiCarSpecTitle5"];
                this.columnAddiCarSpecTitle6 = base.Columns["AddiCarSpecTitle6"];
                // --- ADD m.suzuki 2010/05/11 ---------->>>>>
                this.columnFreeSrchMdlFxdNo = base.Columns["FreeSrchMdlFxdNo"];
                this.columnFreeSearchSortDiv = base.Columns["FreeSearchSortDiv"];
                // --- ADD m.suzuki 2010/05/11 ----------<<<<<
            }

            private void InitClass()
            {
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
                this.columnShiftNm = new DataColumn("ShiftNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnShiftNm);
                this.columnWheelDriveMethodNm = new DataColumn("WheelDriveMethodNm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnWheelDriveMethodNm);
                // --- UPD m.suzuki 2010/05/11 ---------->>>>>
                //this.columnPartsOfferFlag = new DataColumn("PartsExistence", typeof(Image), null, MappingType.Element);
                this.columnPartsOfferFlag = new DataColumn( "PartsExistence", typeof( object ), null, MappingType.Element );
                // --- UPD m.suzuki 2010/05/11 ----------<<<<<
                base.Columns.Add(this.columnPartsOfferFlag);
                this.columnFullModel = new DataColumn("FullModel", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnFullModel);
                this.columnNo = new DataColumn("No", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnNo);
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
                this.columnAddiCarSpecTitle1 = new DataColumn("AddiCarSpecTitle1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpecTitle1);
                this.columnAddiCarSpecTitle2 = new DataColumn("AddiCarSpecTitle2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpecTitle2);
                this.columnAddiCarSpecTitle3 = new DataColumn("AddiCarSpecTitle3", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpecTitle3);
                this.columnAddiCarSpecTitle4 = new DataColumn("AddiCarSpecTitle4", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpecTitle4);
                this.columnAddiCarSpecTitle5 = new DataColumn("AddiCarSpecTitle5", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpecTitle5);
                this.columnAddiCarSpecTitle6 = new DataColumn("AddiCarSpecTitle6", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddiCarSpecTitle6);
                // --- ADD m.suzuki 2010/05/11 ---------->>>>>
                this.columnFreeSrchMdlFxdNo = new DataColumn( "FreeSrchMdlFxdNo", typeof( string ), null, MappingType.Element );
                base.Columns.Add( this.columnFreeSrchMdlFxdNo );
                this.columnFreeSearchSortDiv = new DataColumn( "FreeSearchSortDiv", typeof( int ), null, MappingType.Element );
                base.Columns.Add( this.columnFreeSearchSortDiv );
                // --- ADD m.suzuki 2010/05/11 ----------<<<<<
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnFullModel,
                                this.columnNo}, true));
                this.columnModelGradeNm.Caption = "グレード";
                this.columnModelGradeNm.MaxLength = 20;
                this.columnBodyName.Caption = "ボディー";
                this.columnBodyName.MaxLength = 10;
                this.columnDoorCount.AllowDBNull = false;
                this.columnDoorCount.Caption = "ドア";
                this.columnEngineModelNm.Caption = "エンジン";
                this.columnEngineModelNm.MaxLength = 12;
                this.columnEngineDisplaceNm.Caption = "排気量";
                this.columnEngineDisplaceNm.MaxLength = 8;
                this.columnEDivNm.Caption = "E区分";
                this.columnEDivNm.MaxLength = 8;
                this.columnTransmissionNm.Caption = "ミッション";
                this.columnTransmissionNm.MaxLength = 8;
                this.columnShiftNm.Caption = "ｼﾌﾄ";
                this.columnShiftNm.MaxLength = 8;
                this.columnWheelDriveMethodNm.Caption = "駆動方式";
                this.columnWheelDriveMethodNm.MaxLength = 15;
                this.columnPartsOfferFlag.Caption = "部品収録";
                this.columnFullModel.AllowDBNull = false;
                this.columnFullModel.Caption = "型式";
                this.columnFullModel.MaxLength = 44;
                this.columnNo.AutoIncrement = true;
                this.columnNo.AllowDBNull = false;
                this.columnAddiCarSpec1.Caption = "追加諸元1";
                this.columnAddiCarSpec1.MaxLength = 8;
                this.columnAddiCarSpec2.Caption = "追加諸元2";
                this.columnAddiCarSpec2.MaxLength = 8;
                this.columnAddiCarSpec3.Caption = "追加諸元3";
                this.columnAddiCarSpec3.MaxLength = 8;
                this.columnAddiCarSpec4.Caption = "追加諸元4";
                this.columnAddiCarSpec4.MaxLength = 8;
                this.columnAddiCarSpec5.Caption = "追加諸元5";
                this.columnAddiCarSpec5.MaxLength = 8;
                this.columnAddiCarSpec6.Caption = "追加諸元6";
                this.columnAddiCarSpec6.MaxLength = 8;
                this.columnAddiCarSpecTitle1.AllowDBNull = false;
                this.columnAddiCarSpecTitle1.Caption = "追加諸元タイトル1";
                this.columnAddiCarSpecTitle1.MaxLength = 8;
                this.columnAddiCarSpecTitle2.AllowDBNull = false;
                this.columnAddiCarSpecTitle2.Caption = "追加諸元タイトル2";
                this.columnAddiCarSpecTitle2.MaxLength = 8;
                this.columnAddiCarSpecTitle3.AllowDBNull = false;
                this.columnAddiCarSpecTitle3.Caption = "追加諸元タイトル3";
                this.columnAddiCarSpecTitle3.MaxLength = 8;
                this.columnAddiCarSpecTitle4.AllowDBNull = false;
                this.columnAddiCarSpecTitle4.Caption = "追加諸元タイトル4";
                this.columnAddiCarSpecTitle4.MaxLength = 8;
                this.columnAddiCarSpecTitle5.AllowDBNull = false;
                this.columnAddiCarSpecTitle5.Caption = "追加諸元タイトル5";
                this.columnAddiCarSpecTitle5.MaxLength = 8;
                this.columnAddiCarSpecTitle6.AllowDBNull = false;
                this.columnAddiCarSpecTitle6.Caption = "追加諸元タイトル6";
                this.columnAddiCarSpecTitle6.MaxLength = 8;
                // --- ADD m.suzuki 2010/05/11 ---------->>>>>
                this.columnFreeSrchMdlFxdNo.Caption = "自由検索型式固定番号";
                this.columnFreeSearchSortDiv.Caption = "自由検索ソート区分";
                // --- ADD m.suzuki 2010/05/11 ----------<<<<<
            }

            public CarModelDtRow NewCarModelDtRow()
            {
                return ((CarModelDtRow)(this.NewRow()));
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new CarModelDtRow(builder);
            }

            protected override global::System.Type GetRowType()
            {
                return typeof(CarModelDtRow);
            }

            public void RemoveCarModelDtRow(CarModelDtRow row)
            {
                this.Rows.Remove(row);
            }

            public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(global::System.Xml.Schema.XmlSchemaSet xs)
            {
                global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
                global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
                CarModelRel ds = new CarModelRel();
                global::System.Xml.Schema.XmlSchemaAny any1 = new global::System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                global::System.Xml.Schema.XmlSchemaAny any2 = new global::System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                global::System.Xml.Schema.XmlSchemaAttribute attribute1 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                global::System.Xml.Schema.XmlSchemaAttribute attribute2 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "CarModelDtDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
                if (xs.Contains(dsSchema.TargetNamespace))
                {
                    global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                    global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                    try
                    {
                        global::System.Xml.Schema.XmlSchema schema = null;
                        dsSchema.Write(s1);
                        for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); )
                        {
                            schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                            s2.SetLength(0);
                            schema.Write(s2);
                            if ((s1.Length == s2.Length))
                            {
                                s1.Position = 0;
                                s2.Position = 0;
                                for (; ((s1.Position != s1.Length)
                                            && (s1.ReadByte() == s2.ReadByte())); )
                                {
                                    ;
                                }
                                if ((s1.Position == s1.Length))
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if ((s1 != null))
                        {
                            s1.Close();
                        }
                        if ((s2 != null))
                        {
                            s2.Close();
                        }
                    }
                }
                xs.Add(dsSchema);
                return type;
            }
        }

        /// <summary>
        ///Represents strongly named DataRow class.
        ///</summary>
        public partial class CarModelHdRow : DataRow
        {

            private CarModelHdDataTable tableCarModelHd;

            internal CarModelHdRow(DataRowBuilder rb)
                :
                    base(rb)
            {
                this.tableCarModelHd = ((CarModelHdDataTable)(this.Table));
            }

            public int StProduceTypeOfYear
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelHd.StProduceTypeOfYearColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelHd\' にある列 \'StProduceTypeOfYear\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelHd.StProduceTypeOfYearColumn] = value;
                }
            }

            public int EdProduceTypeOfYear
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelHd.EdProduceTypeOfYearColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelHd\' にある列 \'EdProduceTypeOfYear\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelHd.EdProduceTypeOfYearColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DateTime StProduceYear
            {
                get
                {
                    try
                    {
                        return ((DateTime)(this[this.tableCarModelHd.StProduceYearColumn]));
                    }
                    catch { return DateTime.MinValue; }
                }
                set
                {
                    this[this.tableCarModelHd.StProduceYearColumn] = value;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public DateTime EdProduceYear
            {
                get
                {
                    try
                    {
                        return ((DateTime)(this[this.tableCarModelHd.EdProduceYearColumn]));
                    }
                    catch { return DateTime.MinValue; }
                }
                set
                {
                    this[this.tableCarModelHd.EdProduceYearColumn] = value;
                }
            }

            public int StProduceFrameNo
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelHd.StProduceFrameNoColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelHd\' にある列 \'StProduceFrameNo\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelHd.StProduceFrameNoColumn] = value;
                }
            }

            public int EdProduceFrameNo
            {
                get
                {
                    try
                    {
                        return ((int)(this[this.tableCarModelHd.EdProduceFrameNoColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelHd\' にある列 \'EdProduceFrameNo\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelHd.EdProduceFrameNoColumn] = value;
                }
            }

            public string FullModel
            {
                get
                {
                    return ((string)(this[this.tableCarModelHd.FullModelColumn]));
                }
                set
                {
                    this[this.tableCarModelHd.FullModelColumn] = value;
                }
            }
            // --- ADD m.suzuki 2010/05/11 ---------->>>>>
            public int FreeSearchSortDiv
            {
                get
                {
                    return ((int)(this[this.tableCarModelHd.FreeSearchSortDivColumn]));
                }
                set
                {
                    this[this.tableCarModelHd.FreeSearchSortDivColumn] = value;
                }
            }
            // --- ADD m.suzuki 2010/05/11 ----------<<<<<

            public bool IsStProduceTypeOfYearNull()
            {
                return this.IsNull(this.tableCarModelHd.StProduceTypeOfYearColumn);
            }

            public void SetStProduceTypeOfYearNull()
            {
                this[this.tableCarModelHd.StProduceTypeOfYearColumn] = global::System.Convert.DBNull;
            }

            public bool IsEdProduceTypeOfYearNull()
            {
                return this.IsNull(this.tableCarModelHd.EdProduceTypeOfYearColumn);
            }

            public void SetEdProduceTypeOfYearNull()
            {
                this[this.tableCarModelHd.EdProduceTypeOfYearColumn] = global::System.Convert.DBNull;
            }

            public bool IsStProduceFrameNoNull()
            {
                return this.IsNull(this.tableCarModelHd.StProduceFrameNoColumn);
            }

            public void SetStProduceFrameNoNull()
            {
                this[this.tableCarModelHd.StProduceFrameNoColumn] = global::System.Convert.DBNull;
            }

            public bool IsEdProduceFrameNoNull()
            {
                return this.IsNull(this.tableCarModelHd.EdProduceFrameNoColumn);
            }

            public void SetEdProduceFrameNoNull()
            {
                this[this.tableCarModelHd.EdProduceFrameNoColumn] = global::System.Convert.DBNull;
            }

            public CarModelDtRow[] GetCarModelDtRows()
            {
                if ((this.Table.ChildRelations["CarModelHd_CARMODELRF"] == null))
                {
                    return new CarModelDtRow[0];
                }
                else
                {
                    return ((CarModelDtRow[])(base.GetChildRows(this.Table.ChildRelations["CarModelHd_CARMODELRF"])));
                }
            }
        }

        /// <summary>
        ///Represents strongly named DataRow class.
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class CarModelDtRow : DataRow
        {

            private CarModelDtDataTable tableCarModelDt;

            internal CarModelDtRow(DataRowBuilder rb)
                :
                    base(rb)
            {
                this.tableCarModelDt = ((CarModelDtDataTable)(this.Table));
            }

            public string ModelGradeNm
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableCarModelDt.ModelGradeNmColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelDt\' にある列 \'ModelGradeNm\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelDt.ModelGradeNmColumn] = value;
                }
            }

            public string BodyName
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableCarModelDt.BodyNameColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelDt\' にある列 \'BodyName\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelDt.BodyNameColumn] = value;
                }
            }

            public int DoorCount
            {
                get
                {
                    return ((int)(this[this.tableCarModelDt.DoorCountColumn]));
                }
                set
                {
                    this[this.tableCarModelDt.DoorCountColumn] = value;
                }
            }

            public string EngineModelNm
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableCarModelDt.EngineModelNmColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelDt\' にある列 \'EngineModelNm\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelDt.EngineModelNmColumn] = value;
                }
            }

            public string EngineDisplaceNm
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableCarModelDt.EngineDisplaceNmColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelDt\' にある列 \'EngineDisplaceNm\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelDt.EngineDisplaceNmColumn] = value;
                }
            }

            public string EDivNm
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableCarModelDt.EDivNmColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelDt\' にある列 \'EDivNm\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelDt.EDivNmColumn] = value;
                }
            }

            public string TransmissionNm
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableCarModelDt.TransmissionNmColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelDt\' にある列 \'TransmissionNm\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelDt.TransmissionNmColumn] = value;
                }
            }

            public string ShiftNm
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableCarModelDt.ShiftNmColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelDt\' にある列 \'ShiftNm\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelDt.ShiftNmColumn] = value;
                }
            }

            public string WheelDriveMethodNm
            {
                get
                {
                    try
                    {
                        return ((string)(this[this.tableCarModelDt.WheelDriveMethodNmColumn]));
                    }
                    catch (global::System.InvalidCastException e)
                    {
                        throw new StrongTypingException("テーブル \'CarModelDt\' にある列 \'WheelDriveMethodNm\' の値は DBNull です。", e);
                    }
                }
                set
                {
                    this[this.tableCarModelDt.WheelDriveMethodNmColumn] = value;
                }
            }

            public Image PartsOfferFlag
            {
                get
                {
                    return ((Image)(this[this.tableCarModelDt.PartsOfferFlagColumn]));
                }
                set
                {
                    this[this.tableCarModelDt.PartsOfferFlagColumn] = value;
                }
            }

            public string FullModel
            {
                get
                {
                    return ((string)(this[this.tableCarModelDt.FullModelColumn]));
                }
                set
                {
                    this[this.tableCarModelDt.FullModelColumn] = value;
                }
            }

            public int No
            {
                get
                {
                    return ((int)(this[this.tableCarModelDt.NoColumn]));
                }
                set
                {
                    this[this.tableCarModelDt.NoColumn] = value;
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
                        return ((string)(this[this.tableCarModelDt.AddiCarSpec1Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelDt.AddiCarSpec1Column] = value;
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
                        return ((string)(this[this.tableCarModelDt.AddiCarSpec2Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelDt.AddiCarSpec2Column] = value;
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
                        return ((string)(this[this.tableCarModelDt.AddiCarSpec3Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelDt.AddiCarSpec3Column] = value;
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
                        return ((string)(this[this.tableCarModelDt.AddiCarSpec4Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelDt.AddiCarSpec4Column] = value;
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
                        return ((string)(this[this.tableCarModelDt.AddiCarSpec5Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelDt.AddiCarSpec5Column] = value;
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
                        return ((string)(this[this.tableCarModelDt.AddiCarSpec6Column]));
                    }
                }
                set
                {
                    this[this.tableCarModelDt.AddiCarSpec6Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpecTitle1
            {
                get
                {
                    return ((string)(this[this.tableCarModelDt.AddiCarSpecTitle1Column]));
                }
                set
                {
                    this[this.tableCarModelDt.AddiCarSpecTitle1Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpecTitle2
            {
                get
                {
                    return ((string)(this[this.tableCarModelDt.AddiCarSpecTitle2Column]));
                }
                set
                {
                    this[this.tableCarModelDt.AddiCarSpecTitle2Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpecTitle3
            {
                get
                {
                    return ((string)(this[this.tableCarModelDt.AddiCarSpecTitle3Column]));
                }
                set
                {
                    this[this.tableCarModelDt.AddiCarSpecTitle3Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpecTitle4
            {
                get
                {
                    return ((string)(this[this.tableCarModelDt.AddiCarSpecTitle4Column]));
                }
                set
                {
                    this[this.tableCarModelDt.AddiCarSpecTitle4Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpecTitle5
            {
                get
                {
                    return ((string)(this[this.tableCarModelDt.AddiCarSpecTitle5Column]));
                }
                set
                {
                    this[this.tableCarModelDt.AddiCarSpecTitle5Column] = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public string AddiCarSpecTitle6
            {
                get
                {
                    return ((string)(this[this.tableCarModelDt.AddiCarSpecTitle6Column]));
                }
                set
                {
                    this[this.tableCarModelDt.AddiCarSpecTitle6Column] = value;
                }
            }

            public CarModelHdRow CarModelHdRow
            {
                get
                {
                    return ((CarModelHdRow)(this.GetParentRow(this.Table.ParentRelations["CarModelHd_CARMODELRF"])));
                }
                set
                {
                    this.SetParentRow(value, this.Table.ParentRelations["CarModelHd_CARMODELRF"]);
                }
            }

            public bool IsModelGradeNmNull()
            {
                return this.IsNull(this.tableCarModelDt.ModelGradeNmColumn);
            }

            public void SetModelGradeNmNull()
            {
                this[this.tableCarModelDt.ModelGradeNmColumn] = global::System.Convert.DBNull;
            }

            public bool IsBodyNameNull()
            {
                return this.IsNull(this.tableCarModelDt.BodyNameColumn);
            }

            public void SetBodyNameNull()
            {
                this[this.tableCarModelDt.BodyNameColumn] = global::System.Convert.DBNull;
            }

            public bool IsEngineModelNmNull()
            {
                return this.IsNull(this.tableCarModelDt.EngineModelNmColumn);
            }

            public void SetEngineModelNmNull()
            {
                this[this.tableCarModelDt.EngineModelNmColumn] = global::System.Convert.DBNull;
            }

            public bool IsEngineDisplaceNmNull()
            {
                return this.IsNull(this.tableCarModelDt.EngineDisplaceNmColumn);
            }

            public void SetEngineDisplaceNmNull()
            {
                this[this.tableCarModelDt.EngineDisplaceNmColumn] = global::System.Convert.DBNull;
            }

            public bool IsEDivNmNull()
            {
                return this.IsNull(this.tableCarModelDt.EDivNmColumn);
            }

            public void SetEDivNmNull()
            {
                this[this.tableCarModelDt.EDivNmColumn] = global::System.Convert.DBNull;
            }

            public bool IsTransmissionNmNull()
            {
                return this.IsNull(this.tableCarModelDt.TransmissionNmColumn);
            }

            public void SetTransmissionNmNull()
            {
                this[this.tableCarModelDt.TransmissionNmColumn] = global::System.Convert.DBNull;
            }

            public bool IsShiftNmNull()
            {
                return this.IsNull(this.tableCarModelDt.ShiftNmColumn);
            }

            public void SetShiftNmNull()
            {
                this[this.tableCarModelDt.ShiftNmColumn] = global::System.Convert.DBNull;
            }

            public bool IsWheelDriveMethodNmNull()
            {
                return this.IsNull(this.tableCarModelDt.WheelDriveMethodNmColumn);
            }

            public void SetWheelDriveMethodNmNull()
            {
                this[this.tableCarModelDt.WheelDriveMethodNmColumn] = global::System.Convert.DBNull;
            }

            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec1Null()
            {
                return this.IsNull(this.tableCarModelDt.AddiCarSpec1Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec1Null()
            {
                this[this.tableCarModelDt.AddiCarSpec1Column] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec2Null()
            {
                return this.IsNull(this.tableCarModelDt.AddiCarSpec2Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec2Null()
            {
                this[this.tableCarModelDt.AddiCarSpec2Column] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec3Null()
            {
                return this.IsNull(this.tableCarModelDt.AddiCarSpec3Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec3Null()
            {
                this[this.tableCarModelDt.AddiCarSpec3Column] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec4Null()
            {
                return this.IsNull(this.tableCarModelDt.AddiCarSpec4Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec4Null()
            {
                this[this.tableCarModelDt.AddiCarSpec4Column] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec5Null()
            {
                return this.IsNull(this.tableCarModelDt.AddiCarSpec5Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec5Null()
            {
                this[this.tableCarModelDt.AddiCarSpec5Column] = global::System.Convert.DBNull;
            }
            /// <summary>
            /// 
            /// </summary>
            public bool IsAddiCarSpec6Null()
            {
                return this.IsNull(this.tableCarModelDt.AddiCarSpec6Column);
            }
            /// <summary>
            /// 
            /// </summary>
            public void SetAddiCarSpec6Null()
            {
                this[this.tableCarModelDt.AddiCarSpec6Column] = global::System.Convert.DBNull;
            }
        }

    }

}
