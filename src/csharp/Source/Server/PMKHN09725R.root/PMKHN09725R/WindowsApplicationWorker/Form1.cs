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

namespace WindowsApplicationWorker
{
    /// <summary>
    /// Form1 の概要の説明です。
    /// このFromはリモートテストの為だけのFromです
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.TextBox textEnterpriseCode;
        private System.Windows.Forms.DataGrid dataGrid1;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button buttonClear;

        private RoleGroupNameStWork _roleGroupNameStWork = null;

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonWriteGrid;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.Button buttonLogDelGrid;
        private System.Windows.Forms.Button buttonRevGrid;
        private System.Windows.Forms.Button buttonDelGrid;

        private IRoleGroupNameStDB IroleGroupNameStDB = null;

        private static string[] _parameter;
        private DataGrid dataGrid2;
        private static System.Windows.Forms.Form _form = null;

        public Form1()
        {
            //
            // Windows フォーム デザイナ サポートに必要です。
            //
            InitializeComponent();

            //
            // TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
            //
        }

        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonRead = new System.Windows.Forms.Button();
            this.textEnterpriseCode = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonWriteGrid = new System.Windows.Forms.Button();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.buttonLogDelGrid = new System.Windows.Forms.Button();
            this.buttonRevGrid = new System.Windows.Forms.Button();
            this.buttonDelGrid = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(312, 16);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(75, 23);
            this.buttonRead.TabIndex = 0;
            this.buttonRead.Text = "Read";
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // textEnterpriseCode
            // 
            this.textEnterpriseCode.Location = new System.Drawing.Point(16, 16);
            this.textEnterpriseCode.Name = "textEnterpriseCode";
            this.textEnterpriseCode.Size = new System.Drawing.Size(288, 19);
            this.textEnterpriseCode.TabIndex = 1;
            this.textEnterpriseCode.Text = "0101150842020000";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 284);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(909, 252);
            this.dataGrid1.TabIndex = 13;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(17, 139);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 20;
            this.buttonClear.Text = "Clear";
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(83, 255);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(88, 23);
            this.buttonSearch.TabIndex = 33;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonWriteGrid
            // 
            this.buttonWriteGrid.Location = new System.Drawing.Point(289, 255);
            this.buttonWriteGrid.Name = "buttonWriteGrid";
            this.buttonWriteGrid.Size = new System.Drawing.Size(72, 23);
            this.buttonWriteGrid.TabIndex = 34;
            this.buttonWriteGrid.Text = "WriteGrid";
            this.buttonWriteGrid.Click += new System.EventHandler(this.buttonWriteGrid_Click);
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Location = new System.Drawing.Point(17, 255);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(60, 23);
            this.buttonAddRow.TabIndex = 35;
            this.buttonAddRow.Text = "AddRow";
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // buttonLogDelGrid
            // 
            this.buttonLogDelGrid.Location = new System.Drawing.Point(361, 255);
            this.buttonLogDelGrid.Name = "buttonLogDelGrid";
            this.buttonLogDelGrid.Size = new System.Drawing.Size(72, 23);
            this.buttonLogDelGrid.TabIndex = 36;
            this.buttonLogDelGrid.Text = "LogDelGrid";
            this.buttonLogDelGrid.Click += new System.EventHandler(this.buttonLogDelGrid_Click);
            // 
            // buttonRevGrid
            // 
            this.buttonRevGrid.Location = new System.Drawing.Point(433, 255);
            this.buttonRevGrid.Name = "buttonRevGrid";
            this.buttonRevGrid.Size = new System.Drawing.Size(72, 23);
            this.buttonRevGrid.TabIndex = 37;
            this.buttonRevGrid.Text = "RevGrid";
            this.buttonRevGrid.Click += new System.EventHandler(this.buttonRevGrid_Click);
            // 
            // buttonDelGrid
            // 
            this.buttonDelGrid.Location = new System.Drawing.Point(505, 255);
            this.buttonDelGrid.Name = "buttonDelGrid";
            this.buttonDelGrid.Size = new System.Drawing.Size(72, 23);
            this.buttonDelGrid.TabIndex = 38;
            this.buttonDelGrid.Text = "DelGrid";
            this.buttonDelGrid.Click += new System.EventHandler(this.buttonDelGrid_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(16, 168);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(909, 81);
            this.dataGrid2.TabIndex = 39;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.buttonDelGrid);
            this.Controls.Add(this.buttonRevGrid);
            this.Controls.Add(this.buttonLogDelGrid);
            this.Controls.Add(this.buttonAddRow);
            this.Controls.Add(this.buttonWriteGrid);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textEnterpriseCode);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.buttonRead);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            try
            {
                string msg = "";
                _parameter = args;
                //アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    _form = new Form1();
                    System.Windows.Forms.Application.Run(_form);
                }
                if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// アプリケーション終了イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">メッセージ</param>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();
            //従業員ログオフのメッセージを表示
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", e.ToString(), 0, MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// 1件読み込み処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRead_Click(object sender, EventArgs e)
        {
            _roleGroupNameStWork = new RoleGroupNameStWork();
            _roleGroupNameStWork.EnterpriseCode = "0101150842020000";
            _roleGroupNameStWork.RoleGroupCode = 1;

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(_roleGroupNameStWork);

            int status = IroleGroupNameStDB.Read(ref parabyte, 0);
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                // XMLの読み込み
                _roleGroupNameStWork = (RoleGroupNameStWork)XmlByteSerializer.Deserialize(parabyte, typeof(RoleGroupNameStWork));

                Text = "該当データ有り";
                ArrayList al = new ArrayList();
                al.Add(_roleGroupNameStWork);
                dataGrid1.DataSource = al;
            }
        }

        /// <summary>
        /// FromLoad時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            IroleGroupNameStDB = MediationRoleGroupNameStDB.GetRoleGroupNameStDB();
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, System.EventArgs e)
        {
            dataGrid1.DataSource = null;
            dataGrid2.DataSource = null;
            ArrayList al = new ArrayList();
            RoleGroupNameStWork work = new RoleGroupNameStWork();
            work.EnterpriseCode = textEnterpriseCode.Text;
            al.Add(work);
            dataGrid2.DataSource = al;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearch_Click(object sender, System.EventArgs e)
        {
            string ent = "0101150842020000";

            RoleGroupNameStWork work = new RoleGroupNameStWork();
            work.EnterpriseCode = ent;

            ArrayList al = new ArrayList();
            al.Add(work);

            object parabyte = al;
            object objRoleGroupNameLst;

            int status = IroleGroupNameStDB.Search(out objRoleGroupNameLst, parabyte, 0, 0);

            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {

                Text = "該当データ有り  HIT " + ((ArrayList)objRoleGroupNameLst).Count.ToString() + "件";

                dataGrid1.DataSource = objRoleGroupNameLst;
            }
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWriteGrid_Click(object sender, System.EventArgs e)
        {
            object objRoleGroupNameStWork = null;

            RoleGroupNameStWork cam = new RoleGroupNameStWork();

            cam.EnterpriseCode = "0101150842020000";
            cam.RoleGroupCode = 1;
            cam.RoleGroupName = "グループ名称１";

            objRoleGroupNameStWork = cam;


            int status = IroleGroupNameStDB.Write(ref objRoleGroupNameStWork);
            if (status != 0)
            {
                Text = "更新失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
                }
            }
            else
            {
                Text = "更新成功";
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = objRoleGroupNameStWork;
            }
        }

        /// <summary>
        /// 行追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddRow_Click(object sender, System.EventArgs e)
        {
            RoleGroupNameStWork roleGroupNameStWork = new RoleGroupNameStWork();
            roleGroupNameStWork.EnterpriseCode = textEnterpriseCode.Text;
            ArrayList al = dataGrid1.DataSource as ArrayList;
            if (al == null) al = new ArrayList();
            al.Add(roleGroupNameStWork);
            dataGrid1.DataSource = null;
            dataGrid1.DataSource = al;
        }

        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogDelGrid_Click(object sender, System.EventArgs e)
        {
            object objRoleGroupNameLstWork = dataGrid1.DataSource;

            int status = IroleGroupNameStDB.LogicalDelete(ref objRoleGroupNameLstWork);
            if (status != 0)
            {
                Text = "論理削除失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
                }
            }
            else
            {
                Text = "論理削除成功";
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = objRoleGroupNameLstWork;
            }
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelGrid_Click(object sender, System.EventArgs e)
        {
            object objRoleGroupNameLstWork = dataGrid1.DataSource;

            RoleGroupNameStWork[] trarray = (RoleGroupNameStWork[])((ArrayList)dataGrid1.DataSource).ToArray(typeof(RoleGroupNameStWork));
            byte[] parabyte = XmlByteSerializer.Serialize(trarray);

            int status = IroleGroupNameStDB.Delete(parabyte);
            if (status != 0)
            {
                Text = "削除失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再削除してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                }
            }
            else
            {
                Text = "削除成功";
                dataGrid1.DataSource = null;
            }
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRevGrid_Click(object sender, EventArgs e)
        {
            object objRoleGroupNameLstWork = dataGrid1.DataSource;

            int status = IroleGroupNameStDB.RevivalLogicalDelete(ref objRoleGroupNameLstWork);
            if (status != 0)
            {
                Text = "復活失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
                }
            }
            else
            {
                Text = "復活成功";
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = objRoleGroupNameLstWork;
            }
        }
    }
}