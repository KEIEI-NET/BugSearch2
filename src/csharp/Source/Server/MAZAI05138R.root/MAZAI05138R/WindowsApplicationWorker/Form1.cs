using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace WindowsApplicationWorker
{
	/// <summary>
	/// Form1 �̊T�v�̐����ł��B
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.ComponentModel.Container components = null;

        private IInventoryDataUpdateDB IstockInventoryWriteDB = null;
        //private IInventoryDataUpdateDB InventoryDataUpdateDB = null; 
		private static string[] _parameter;
        private DataGrid dataGrid2;
        private Button button3;
		private static System.Windows.Forms.Form _form = null;

		public Form1()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent �Ăяo���̌�ɁA�R���X�g���N�^ �R�[�h��ǉ����Ă��������B
			//
		}

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 28);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(816, 144);
            this.dataGrid1.TabIndex = 33;
            // 
            // dataGrid2
            // 
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(16, 203);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(816, 144);
            this.dataGrid2.TabIndex = 42;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(757, 363);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 44;
            this.button3.Text = "Write";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(881, 414);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.dataGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);

		}
        #endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main(String[] args) 
		{
			try
			{
				string msg = "";
				_parameter = args;
				//�A�v���P�[�V�����J�n���������B���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��o����ꍇ�͎w��B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
				int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
				if (status == 0)
				{
					_form = new Form1();
					System.Windows.Forms.Application.Run(_form);
				}
				if (status != 0)	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,"Form1",msg,0,MessageBoxButtons.OK);
			}
			catch(Exception ex)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,"Form1",ex.Message,0,MessageBoxButtons.OK);
			}
			finally
			{
				ApplicationStartControl.EndApplication();
			}
		}

		/// <summary>
		/// �A�v���P�[�V�����I���C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">���b�Z�[�W</param>
		private static void ApplicationReleased(object sender, EventArgs e)
		{
			//���b�Z�[�W���o���O�ɑS�ĊJ��
			ApplicationStartControl.EndApplication();
			//�]�ƈ����O�I�t�̃��b�Z�[�W��\��
			if (_form != null)	TMsgDisp.Show(_form.Owner,	emErrorLevel.ERR_LEVEL_INFO,"Form1",e.ToString(),0,MessageBoxButtons.OK);
			else				TMsgDisp.Show(				emErrorLevel.ERR_LEVEL_INFO,"Form1",e.ToString(),0,MessageBoxButtons.OK);
			//�A�v���P�[�V�����I��
			System.Windows.Forms.Application.Exit();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);
            IstockInventoryWriteDB = MediationInventoryDataUpdateDB.GetInventoryDataUpdateDB();
            //InventoryDataUpdateDB = MediationInventoryDataUpdateDB.GetInventoryDataUpdateDB();

            InventoryDataUpdateWork inventoryDataUpdateWork = new InventoryDataUpdateWork();
            //inventoryDataUpdateWork.EnterpriseCode = "0113180842031000";
            inventoryDataUpdateWork.EnterpriseCode = "0101150842020000";
            inventoryDataUpdateWork.SectionCode = "000001";
            //inventoryDataUpdateWork.InventorySeqNo = 1;
            
            //inventoryDataUpdateWork.EnterpriseCode = "0140150842030000";
            //inventoryDataUpdateWork.SectionCode = "303";
            //inventoryDataUpdateWork.LogicalDeleteCode = 3;
            //inventoryDataUpdateWork.ProductStockGuid = new Guid("fee3ed3e-b74f-4e7e-ad8b-fff8159bfb9b");
            //inventoryDataUpdateWork.MakerCode = 1;
            //inventoryDataUpdateWork.GoodsCode = "200";
            /*
            InventoryDataUpdateWork inventoryDataUpdateWork2 = new InventoryDataUpdateWork();
            inventoryDataUpdateWork2.EnterpriseCode = "0140150842030000";
            inventoryDataUpdateWork2.SectionCode = "TEST1";
            inventoryDataUpdateWork2.ProductStockGuid = new Guid("c1f8382e-25bb-4150-aa99-6b4ca991871d");
            inventoryDataUpdateWork2.MakerCode = 2;
            inventoryDataUpdateWork2.GoodsCode = "100";

            InventoryDataUpdateWork inventoryDataUpdateWork3 = new InventoryDataUpdateWork();
            inventoryDataUpdateWork3.EnterpriseCode = "0140150842030000";
            inventoryDataUpdateWork3.SectionCode = "TEST1";
            inventoryDataUpdateWork3.SectionGuideNm = "�e�X�g";
            inventoryDataUpdateWork3.ProductStockGuid = new Guid("c1f8382e-25bb-4150-aa99-6b4ca991871e");
            inventoryDataUpdateWork3.WarehouseCode = "TestW";
            inventoryDataUpdateWork3.WarehouseName = "�q��";
            inventoryDataUpdateWork3.MakerCode = 2;
            inventoryDataUpdateWork3.MakerName = "���[�J�[";
            inventoryDataUpdateWork3.GoodsCode = "100";
            inventoryDataUpdateWork3.GoodsName = "���i";
            inventoryDataUpdateWork3.CellphoneModelCode = "100";
            inventoryDataUpdateWork3.CellphoneModelName = "�@��";
            inventoryDataUpdateWork3.CarrierCode = 1;
            inventoryDataUpdateWork3.CarrierName = "�L�����A";
            inventoryDataUpdateWork3.SystematicColorCd = 1;
            inventoryDataUpdateWork3.SystematicColorNm = "�n���F";
            inventoryDataUpdateWork3.LargeGoodsGanreCode = 1;
            inventoryDataUpdateWork3.LargeGoodsGanreName = "���i�啪��";
            inventoryDataUpdateWork3.MediumGoodsGanreCode = 1;
            inventoryDataUpdateWork3.MediumGoodsGanreName = "���i������";
            inventoryDataUpdateWork3.CarrierEpCode = 1;
            inventoryDataUpdateWork3.CarrierEpName = "���Ǝ�";
            inventoryDataUpdateWork3.CustomerCode = 1;
            inventoryDataUpdateWork3.CustomerName = "���Ӑ�P";
            inventoryDataUpdateWork3.CustomerName2="���Ӑ�Q";
            inventoryDataUpdateWork3.StockDate = TDateTime.LongDateToDateTime(20070418);
            inventoryDataUpdateWork3.ArrivalGoodsDay = TDateTime.LongDateToDateTime(20070418);
            inventoryDataUpdateWork3.ProductNumber = "SEI-BAN";
            inventoryDataUpdateWork3.StockTelNo1 = "090-xxxx-xxx1";
            inventoryDataUpdateWork3.BfStockTelNo1 = "090-xxxx-xxx0";
            inventoryDataUpdateWork3.StkTelNo1ChgFlg = 1;
            inventoryDataUpdateWork3.StockTelNo2 = "080-xxxx-xxx1";
            inventoryDataUpdateWork3.BfStockTelNo2 = "080-xxxx-xxx0";
            inventoryDataUpdateWork3.StkTelNo2ChgFlg = 1;
            inventoryDataUpdateWork3.Jan = "JAN1234567890";
            inventoryDataUpdateWork3.StockUnitPrice = 100;
            inventoryDataUpdateWork3.BfStockUnitPrice = 50;
            inventoryDataUpdateWork3.StkUnitPriceChgFlg = 1;
            inventoryDataUpdateWork3.StockDiv = 0;
            inventoryDataUpdateWork3.StockState = 0;
            inventoryDataUpdateWork3.MoveStatus = 9;
            inventoryDataUpdateWork3.GoodsCodeStatus = 0;
            inventoryDataUpdateWork3.PrdNumMngDiv = 1;
            inventoryDataUpdateWork3.LastStockDate = TDateTime.LongDateToDateTime(20070418);
            inventoryDataUpdateWork3.StockTotal = 1;
            inventoryDataUpdateWork3.ShipCustomerCode = 1;
            inventoryDataUpdateWork3.ShipCustomerName = "�o�א�P";
            inventoryDataUpdateWork3.ShipCustomerName2 = "�o�א�Q";
            inventoryDataUpdateWork3.InventoryStockCnt = 1;
            inventoryDataUpdateWork3.InventoryTolerancCnt = 0;
            inventoryDataUpdateWork3.InventoryPreprDay = TDateTime.LongDateToDateTime(20070418);
            inventoryDataUpdateWork3.InventoryPreprTim = 160000;
            inventoryDataUpdateWork3.InventoryDay = TDateTime.LongDateToDateTime(20070418);
            inventoryDataUpdateWork3.LastInventoryUpdate = TDateTime.LongDateToDateTime(20070418);
            inventoryDataUpdateWork3.InventoryNewDiv = 0;
            */
            ArrayList newArray = new ArrayList();
            newArray.Add(inventoryDataUpdateWork);
            /*
            newArray.Add(inventoryDataUpdateWork2);
            newArray.Add(inventoryDataUpdateWork3);
             * */
            dataGrid1.DataSource = newArray;                 
		}

        private void button3_Click(object sender, EventArgs e)
        {

            InventoryDataUpdateWork inventoryDataUpdateWork = new InventoryDataUpdateWork();
            ArrayList array = dataGrid1.DataSource as ArrayList;
            inventoryDataUpdateWork = array[0] as InventoryDataUpdateWork;
            
            object retbyte = array;

            //int status = InventoryDataUpdateDB.Write(ref retbyte);
            int status = IstockInventoryWriteDB.Write(ref retbyte);

            // XML�̓ǂݍ���
            ArrayList retList = retbyte as ArrayList;
            dataGrid2.DataSource = retList;
            Form1._form.Text = "ST=" + Convert.ToString(status);

        }
	}
}

