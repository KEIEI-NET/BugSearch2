using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �ԗ��^�����f�[�^�Z�b�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԗ��^�����f�[�^�Z�b�g�N���X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>2009.06.08 20056 ���n ��� �S�I�������ǉ�</br>
    /// <br>----------------------------------------------------------------------------------</br>
    /// <br>Update Note: �r�b�l�Ή��ňȉ��̏�����ǉ�</br>
    /// <br>             �E�ԑ�ԍ�����N���擾����</br>
    /// <br>             �E�N���ōi�荞��</br>
    /// <br>             �E�ԑ�ԍ��ōi�荞��</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2011/03/09</br>
    /// <br></br>
    /// <br>Update Note: 10900269-00 SPK�ԑ�ԍ�������Ή�</br>
    /// <br>Programmer : FSI�֓� �a�G</br>
    /// <br>Date       : 2013/03/19</br>
    /// </remarks>
    public partial class PMKEN01010E : global::System.Data.DataSet
    {
        #region [ Private Member ]
        private CarSearchCondition _carSearchCondition;

        private CarKindInfoDataTable tableCarKindInfo;

        private CarModelInfoDataTable tableCarModelInfo;

        private CarModelInfoDataTable tableCarModelInfoSummarized;

        private CarModelUIDataTable tableCarModelUIData;

        private ColorCdInfoDataTable tableColorCdInfo;

        private TrimCdInfoDataTable tableTrimCdInfo;

        private CEqpDefDspInfoDataTable tableCEqpDefDspInfo;

        private CtgyMdlLnkInfoDataTable tableCtgyMdlLnkInfo;

        private PrdTypYearInfoDataTable tablePrdTypYearInfo;

        private CategoryEquipmentInfoDataTable tableCategoryEquipmentInfo;

        private global::System.Data.SchemaSerializationMode _schemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
        #endregion

        #region [ �R���X�g���N�^ ]
        /// <summary>
        /// 
        /// </summary>
        public PMKEN01010E()
        {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected PMKEN01010E(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
            :
                base(info, context, false)
        {
            if ((this.IsBinarySerialized(info, context) == true))
            {
                this.InitVars(false);

                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((this.DetermineSchemaSerializationMode(info, context) == global::System.Data.SchemaSerializationMode.IncludeSchema))
            {
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
                if ((ds.Tables["CarKindInfo"] != null))
                {
                    base.Tables.Add(new CarKindInfoDataTable(ds.Tables["CarKindInfo"]));
                }
                if ((ds.Tables["CarModelInfo"] != null))
                {
                    base.Tables.Add(new CarModelInfoDataTable(ds.Tables["CarModelInfo"]));
                }
                if ((ds.Tables["ColorCdInfo"] != null))
                {
                    base.Tables.Add(new ColorCdInfoDataTable(ds.Tables["ColorCdInfo"]));
                }
                if ((ds.Tables["TrimCdInfo"] != null))
                {
                    base.Tables.Add(new TrimCdInfoDataTable(ds.Tables["TrimCdInfo"]));
                }
                if ((ds.Tables["CEqpDefDspInfo"] != null))
                {
                    base.Tables.Add(new CEqpDefDspInfoDataTable(ds.Tables["CEqpDefDspInfo"]));
                }
                if ((ds.Tables["CtgyMdlLnkInfo"] != null))
                {
                    base.Tables.Add(new CtgyMdlLnkInfoDataTable(ds.Tables["CtgyMdlLnkInfo"]));
                }
                if ((ds.Tables["PrdTypYearInfo"] != null))
                {
                    base.Tables.Add(new PrdTypYearInfoDataTable(ds.Tables["PrdTypYearInfo"]));
                }
                if ((ds.Tables["CategoryEquipmentInfo"] != null))
                {
                    base.Tables.Add(new CategoryEquipmentInfoDataTable(ds.Tables["CategoryEquipmentInfo"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                this.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
            }
            this.GetSerializationData(info, context);
        }
        #endregion

        #region [ Public Property ]

        /// <summary>
        /// �ԗ���������
        /// </summary>
        public CarSearchCondition CarSearchCondition
        {
            get { return _carSearchCondition; }
            set { _carSearchCondition = value; }
        }

        /// <summary>
        /// �Ԏ���e�[�u��
        /// </summary>
        public CarKindInfoDataTable CarKindInfo
        {
            get
            {
                return this.tableCarKindInfo;
            }
            set // �����Ƀ��C�g�\�Ƃ���B
            {
                foreach (PMKEN01010E.CarKindInfoRow row in value.Rows)
                {
                    PMKEN01010E.CarKindInfoRow nrow = this.tableCarKindInfo.NewCarKindInfoRow();
                    nrow.MakerCode = row.MakerCode;
                    nrow.MakerFullName = row.MakerFullName;
                    nrow.ModelCode = row.ModelCode;
                    nrow.ModelSubCode = row.ModelSubCode;
                    nrow.ModelFullName = row.ModelFullName;
                    nrow.EngineModelNm = row.EngineModelNm;
                    nrow.SelectionState = row.SelectionState;

                    this.tableCarKindInfo.AddCarKindInfoRow(nrow);
                }
            }
        }

        /// <summary>
        /// �^�����e�[�u��
        /// </summary>
        public CarModelInfoDataTable CarModelInfo
        {
            get
            {
                return this.tableCarModelInfo;
            }
            set
            {
                foreach (PMKEN01010E.CarModelInfoRow row in value.Rows)
                {
                    this.tableCarModelInfo.AddCarModelInfoRowCopy(row);
                }
            }
        }

        /// <summary>
        /// �^�����v��e�[�u��[�^���𕡐��I�񂾂Ƃ��A�����I�Ɏg�p���܂�]
        /// </summary>
        public CarModelInfoDataTable CarModelInfoSummarized
        {
            get
            {
                return this.tableCarModelInfoSummarized;
            }
        }

        /// <summary>
        /// UI�p�^�����e�[�u��
        /// </summary>
        public CarModelUIDataTable CarModelUIData
        {
            get
            {
                return this.tableCarModelUIData;
            }
        }

        /// <summary>
        /// �J���[���e�[�u��
        /// </summary>
        public ColorCdInfoDataTable ColorCdInfo
        {
            get
            {
                return this.tableColorCdInfo;
            }
        }

        /// <summary>
        /// �g�������e�[�u��
        /// </summary>
        public TrimCdInfoDataTable TrimCdInfo
        {
            get
            {
                return this.tableTrimCdInfo;
            }
        }

        /// <summary>
        /// �������e�[�u��
        /// </summary>
        public CEqpDefDspInfoDataTable CEqpDefDspInfo
        {
            get
            {
                return this.tableCEqpDefDspInfo;
            }
        }

        /// <summary>
        /// �ޕʏ��e�[�u��
        /// </summary>
        public CtgyMdlLnkInfoDataTable CtgyMdlLnkInfo
        {
            get
            {
                return this.tableCtgyMdlLnkInfo;
            }
        }

        /// <summary>
        /// �N�����e�[�u��
        /// </summary>
        public PrdTypYearInfoDataTable PrdTypYearInfo
        {
            get
            {
                return this.tablePrdTypYearInfo;
            }
            set
            {
                foreach (PMKEN01010E.PrdTypYearInfoRow row in value.Rows)
                {
                    PMKEN01010E.PrdTypYearInfoRow newRow = tablePrdTypYearInfo.NewPrdTypYearInfoRow();
                    newRow.MakerCode = row.MakerCode;
                    newRow.FrameModel = row.FrameModel;
                    newRow.ProduceTypeOfYear = row.ProduceTypeOfYear;
                    newRow.StProduceFrameNo = row.StProduceFrameNo;
                    newRow.EdProduceFrameNo = row.EdProduceFrameNo;
                    tablePrdTypYearInfo.AddPrdTypYearInfoRow(newRow);
                }
            }
        }

        /// <summary>
        /// �ޕʑ������i���e�[�u��[�ޕʌ����ɂ��^�����ɕt���Ă��鑕�����]
        /// </summary>
        public CategoryEquipmentInfoDataTable CategoryEquipmentInfo
        {
            get
            {
                return this.tableCategoryEquipmentInfo;
            }
        }
        #endregion

        #region [ Public Method ]
        /// <summary>
        /// 
        /// </summary>
        public override global::System.Data.SchemaSerializationMode SchemaSerializationMode
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

        /// <summary>
        /// 
        /// </summary>
        public new global::System.Data.DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public new global::System.Data.DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void InitializeDerivedDataSet()
        {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override global::System.Data.DataSet Clone()
        {
            PMKEN01010E cln = ((PMKEN01010E)(base.Clone()));
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        protected override void ReadXmlSerializable(global::System.Xml.XmlReader reader)
        {
            if ((this.DetermineSchemaSerializationMode(reader) == global::System.Data.SchemaSerializationMode.IncludeSchema))
            {
                this.Reset();
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXml(reader);
                if ((ds.Tables["CarKindInfo"] != null))
                {
                    base.Tables.Add(new CarKindInfoDataTable(ds.Tables["CarKindInfo"]));
                }
                if ((ds.Tables["CarModelInfo"] != null))
                {
                    base.Tables.Add(new CarModelInfoDataTable(ds.Tables["CarModelInfo"]));
                }
                if ((ds.Tables["CarModelUIData"] != null))
                {
                    base.Tables.Add(new CarModelUIDataTable(ds.Tables["CarModelUIData"]));
                }
                if ((ds.Tables["ColorCdInfo"] != null))
                {
                    base.Tables.Add(new ColorCdInfoDataTable(ds.Tables["ColorCdInfo"]));
                }
                if ((ds.Tables["TrimCdInfo"] != null))
                {
                    base.Tables.Add(new TrimCdInfoDataTable(ds.Tables["TrimCdInfo"]));
                }
                if ((ds.Tables["CEqpDefDspInfo"] != null))
                {
                    base.Tables.Add(new CEqpDefDspInfoDataTable(ds.Tables["CEqpDefDspInfo"]));
                }
                if ((ds.Tables["CtgyMdlLnkInfo"] != null))
                {
                    base.Tables.Add(new CtgyMdlLnkInfoDataTable(ds.Tables["CtgyMdlLnkInfo"]));
                }
                if ((ds.Tables["PrdTypYearInfo"] != null))
                {
                    base.Tables.Add(new PrdTypYearInfoDataTable(ds.Tables["PrdTypYearInfo"]));
                }
                if ((ds.Tables["CategoryEquipmentInfo"] != null))
                {
                    base.Tables.Add(new CategoryEquipmentInfoDataTable(ds.Tables["CategoryEquipmentInfo"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                this.ReadXml(reader);
                this.InitVars();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override global::System.Xml.Schema.XmlSchema GetSchemaSerializable()
        {
            global::System.IO.MemoryStream stream = new global::System.IO.MemoryStream();
            this.WriteXmlSchema(new global::System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return global::System.Xml.Schema.XmlSchema.Read(new global::System.Xml.XmlTextReader(stream), null);
        }

        // 2009.06.08 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �S�I������
        /// </summary>
        public void AllSelect()
        {
            foreach (CarModelInfoRow row in this.CarModelInfo)
            {
                row.SelectionState = true;
            }
        }
        // 2009.06.08 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2011/03/09 Add >>>
        /// <summary>
        /// �ԑ�ԍ���萶�Y�N�����擾���܂�
        /// </summary>
        /// <param name="searchFrameNo"></param>
        /// <returns></returns>
        public int GetProduceTypeOfYear(int searchFrameNo)
        {
            if (this.PrdTypYearInfo == null || this.PrdTypYearInfo.Rows.Count == 0) return -1;
            string filter = string.Format("{0}<={1} AND {2}>={3}",
                this.PrdTypYearInfo.StProduceFrameNoColumn.ColumnName, searchFrameNo,
                this.PrdTypYearInfo.EdProduceFrameNoColumn.ColumnName, searchFrameNo);
            PMKEN01010E.PrdTypYearInfoRow[] row =
                (PMKEN01010E.PrdTypYearInfoRow[])this.PrdTypYearInfo.Select(filter);

            if (row == null || row.Length == 0) return 0;

            return row[0].ProduceTypeOfYear;
        }

        /// <summary>
        /// �ԗ��e�[�u����N���ōi�荞�݂܂�
        /// </summary>
        /// <param name="produceTypeOfYear"></param>
        /// <returns></returns>
        public int SelectCarModelProduceTypeOfYear(int produceTypeOfYear)
        {
            if (produceTypeOfYear == 0) return 0;

            string filter = string.Format("StProduceTypeOfYear <= {0} AND {1} <= EdProduceTypeOfYear", produceTypeOfYear, produceTypeOfYear);

            CarModelInfoRow[] rows = (CarModelInfoRow[])this.CarModelInfo.Select(filter);

            if (rows != null && rows.Length > 0)
            {
                foreach (CarModelInfoRow row in rows)
                {
                    row.SelectionState = true;
                }
                return rows.Length;
            }
            return 0;
        }

        /// <summary>
        /// �ԗ��e�[�u�����ԑ�ԍ��ōi�荞�݂܂�
        /// </summary>
        /// <param name="searchFrameNo"></param>
        /// <returns></returns>
        public int SelectCarModelSearchFrameNo(int searchFrameNo)
        {
            if (searchFrameNo == 0) return 0;

            string filter = string.Format("StProduceFrameNo <= {0} AND {1} <= EdProduceFrameNo", searchFrameNo, searchFrameNo);

            CarModelInfoRow[] rows = (CarModelInfoRow[])this.CarModelInfo.Select(filter);

            if (rows != null && rows.Length > 0)
            {
                foreach (CarModelInfoRow row in rows)
                {
                    row.SelectionState = true;
                }
                return rows.Length;
            }
            return 0;
        }
        // 2011/03/09 Add <<<
        #endregion

        #region [ Private Method ]
        internal void InitVars()
        {
            this.InitVars(true);
        }

        internal void InitVars(bool initTable)
        {
            this.tableCarKindInfo = ((CarKindInfoDataTable)(base.Tables["CarKindInfo"]));
            if ((initTable == true))
            {
                if ((this.tableCarKindInfo != null))
                {
                    this.tableCarKindInfo.InitVars();
                }
            }
            this.tableCarModelInfo = ((CarModelInfoDataTable)(base.Tables["CarModelInfo"]));
            if ((initTable == true))
            {
                if ((this.tableCarModelInfo != null))
                {
                    this.tableCarModelInfo.InitVars();
                }
            }
            this.tableCarModelInfoSummarized = ((CarModelInfoDataTable)(base.Tables["CarModelInfoSummarized"]));
            if ((initTable == true))
            {
                if ((this.tableCarModelInfoSummarized != null))
                {
                    this.tableCarModelInfoSummarized.InitVars();
                }
            }
            this.tableCarModelUIData = ((CarModelUIDataTable)(base.Tables["CarModelUIData"]));
            if ((initTable == true))
            {
                if ((this.tableCarModelUIData != null))
                {
                    this.tableCarModelUIData.InitVars();
                }
            }
            this.tableColorCdInfo = ((ColorCdInfoDataTable)(base.Tables["ColorCdInfo"]));
            if ((initTable == true))
            {
                if ((this.tableColorCdInfo != null))
                {
                    this.tableColorCdInfo.InitVars();
                }
            }
            this.tableTrimCdInfo = ((TrimCdInfoDataTable)(base.Tables["TrimCdInfo"]));
            if ((initTable == true))
            {
                if ((this.tableTrimCdInfo != null))
                {
                    this.tableTrimCdInfo.InitVars();
                }
            }
            this.tableCEqpDefDspInfo = ((CEqpDefDspInfoDataTable)(base.Tables["CEqpDefDspInfo"]));
            if ((initTable == true))
            {
                if ((this.tableCEqpDefDspInfo != null))
                {
                    this.tableCEqpDefDspInfo.InitVars();
                }
            }
            this.tableCtgyMdlLnkInfo = ((CtgyMdlLnkInfoDataTable)(base.Tables["CtgyMdlLnkInfo"]));
            if ((initTable == true))
            {
                if ((this.tableCtgyMdlLnkInfo != null))
                {
                    this.tableCtgyMdlLnkInfo.InitVars();
                }
            }
            this.tablePrdTypYearInfo = ((PrdTypYearInfoDataTable)(base.Tables["PrdTypYearInfo"]));
            if ((initTable == true))
            {
                if ((this.tablePrdTypYearInfo != null))
                {
                    this.tablePrdTypYearInfo.InitVars();
                }
            }
            this.tableCategoryEquipmentInfo = ((CategoryEquipmentInfoDataTable)(base.Tables["CategoryEquipmentInfo"]));
            if ((initTable == true))
            {
                if ((this.tableCategoryEquipmentInfo != null))
                {
                    this.tableCategoryEquipmentInfo.InitVars();
                }
            }
        }

        private void InitClass()
        {
            this.DataSetName = "PMKEN01010E";
            this.Prefix = "";
            //this.Namespace = "http://tempuri.org/PMKEN01010E.xsd";
            this.CaseSensitive = true;
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableCarKindInfo = new CarKindInfoDataTable();
            base.Tables.Add(this.tableCarKindInfo);
            this.tableCarModelInfo = new CarModelInfoDataTable();
            base.Tables.Add(this.tableCarModelInfo);
            this.tableCarModelInfoSummarized = new CarModelInfoDataTable();
            this.tableCarModelInfoSummarized.TableName = "CarModelInfoSummarized";
            base.Tables.Add(this.tableCarModelInfoSummarized);
            this.tableCarModelUIData = new CarModelUIDataTable();
            base.Tables.Add(this.tableCarModelUIData);
            this.tableColorCdInfo = new ColorCdInfoDataTable();
            base.Tables.Add(this.tableColorCdInfo);
            this.tableTrimCdInfo = new TrimCdInfoDataTable();
            base.Tables.Add(this.tableTrimCdInfo);
            this.tableCEqpDefDspInfo = new CEqpDefDspInfoDataTable();
            base.Tables.Add(this.tableCEqpDefDspInfo);
            this.tableCtgyMdlLnkInfo = new CtgyMdlLnkInfoDataTable();
            base.Tables.Add(this.tableCtgyMdlLnkInfo);
            this.tablePrdTypYearInfo = new PrdTypYearInfoDataTable();
            base.Tables.Add(this.tablePrdTypYearInfo);
            this.tableCategoryEquipmentInfo = new CategoryEquipmentInfoDataTable();
            base.Tables.Add(this.tableCategoryEquipmentInfo);
        }

        private bool ShouldSerializeCarKindInfo()
        {
            return false;
        }

        private bool ShouldSerializeCarModelInfo()
        {
            return false;
        }

        private bool ShouldSerializeCarModelUIData()
        {
            return false;
        }

        private bool ShouldSerializeColorCdInfo()
        {
            return false;
        }

        private bool ShouldSerializeTrimCdInfo()
        {
            return false;
        }

        private bool ShouldSerializeCEqpDefDspInfo()
        {
            return false;
        }

        private bool ShouldSerializeCtgyMdlLnkInfo()
        {
            return false;
        }

        private bool ShouldSerializePrdTypYearInfo()
        {
            return false;
        }

        private bool ShouldSerializeCategoryEquipmentInfo()
        {
            return false;
        }
        #endregion
    }

}