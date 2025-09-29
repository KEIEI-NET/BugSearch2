using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Windows.Forms;
using System.Configuration;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    public partial class SFNETMENU1CF : Form
    {
        #region 定数
        private const string xmlName = "menusetting.xml";
        #endregion 

        public static Dictionary<string, MainMenuItem> menuList = new Dictionary<string, MainMenuItem>();
        public static MainMenuItem SelectItem = null;
        public static MainMenuItem SelectItemDef = null;

        /// <summary>
        /// 初期処理
        /// </summary>
        public static bool Initialize(out string msg)
        {
            // --- UPD m.suzuki 2010/04/06 ---------->>>>>
            //msg = "";
            //bool ret = false;
            ////メニューイメージ情報取得
            //try
            //{
            //    menuList.Clear();
            //    //構成ファイルからコンボボックスを生成
            //    Int32 menuImageCount = System.Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MenuImageCount"]);
            //    for (int i=1;i<=menuImageCount;i++)
            //    {
            //        MainMenuItem mainMenuItem = new MainMenuItem();
            //        mainMenuItem.Path = System.Configuration.ConfigurationManager.AppSettings[string.Format("MenuImagePath_{0}",i)];
            //        mainMenuItem.Name = System.Configuration.ConfigurationManager.AppSettings[string.Format("MenuImageName_{0}",i)];
            //        if (mainMenuItem.Path != null && mainMenuItem.Name != null && mainMenuItem.Path.Length > 0 && mainMenuItem.Name.Length > 0)
            //        {
            //            menuList.Add(mainMenuItem.Path, mainMenuItem);
            //            //先頭をデフォルト値として入れておく
            //            if (SelectItem == null)
            //            {
            //                SelectItem = mainMenuItem;
            //                SelectItemDef = mainMenuItem;
            //            }
            //        }
            //    }
            //}
            //catch(Exception ex)
            //{
            //    //途中読込できなくなった場合は読込処理を終了
            //}
            ////１つも読み込めない場合にはエラー
            //if (menuList.Count == 0)
            //{
            //    msg = "メニューイメージ情報が取得出来ません";
            //    return ret;
            //}

            //ret = true;

            //return ret;

            msg = "";
            bool flag = false;
            try
            {
                menuList.Clear();
                new MainMenuItem();
                string str = ConfigurationManager.AppSettings[string.Format( "MenuImageUrl", new object[0] )];
                string str2 = ConfigurationManager.AppSettings[string.Format( "MenuImageXml", new object[0] )];
                foreach ( MainMenuItem item in UserSettingController.DeserializeUserSetting<List<MainMenuItem>>( Path.Combine( str, str2 ) ) )
                {
                    MainMenuItem item2 = new MainMenuItem();
                    item2.Path = item.Path;
                    item2.Name = item.Name;
                    if ( ((item2.Path != null) && (item2.Name != null)) && ((item2.Path.Length > 0) && (item2.Name.Length > 0)) )
                    {
                        menuList.Add( item2.Path, item2 );
                        if ( SelectItem == null )
                        {
                            SelectItem = item2;
                            SelectItemDef = item2;
                        }
                    }
                }
            }
            catch ( Exception )
            {
            }
            if ( menuList.Count == 0 )
            {
                msg = "メニューイメージ情報が取得出来ません";
                return flag;
            }
            return true;

            // --- UPD m.suzuki 2010/04/06 ----------<<<<<
        }

        public SFNETMENU1CF()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期処理
        /// </summary>
        /// <param rKeyName="sender"></param>
        /// <param rKeyName="e"></param>
        private void SFNETMENU1C_Load(object sender, EventArgs e)
        {
            comboBox_Image.BeginUpdate();
            comboBox_Image.Items.Clear();
            foreach (MainMenuItem mainMenuItem in menuList.Values)
            {
                comboBox_Image.Items.Add(mainMenuItem);
                if (mainMenuItem.Equals(SelectItem))
                {
                    comboBox_Image.SelectedItem = mainMenuItem;
                }
            }
            comboBox_Image.EndUpdate();
        }

        /// <summary>
        /// 従業員選択イメージ取得
        /// </summary>
        /// <param rKeyName="employeeCode">従業員コード</param>
        /// <param rKeyName="form">親画面</param>
        /// <returns>メニューItem</returns>
        public static MainMenuItem GetSelectMainMenuItem(string employeeCode, Form form)
        {
            string fullPath = GetSelectMainMenuItemPath(employeeCode, form);
            if (fullPath != null && fullPath.Length > 0)
            {
                //設定ファイルを読み込み
                MainMenuItem mainMenuItem = XmlByteSerializer.Deserialize(fullPath, typeof(MainMenuItem)) as MainMenuItem;
                if (mainMenuItem != null)
                {
                    SelectItem = mainMenuItem;
                    return mainMenuItem;
                }
                else
                {
                    SelectItem = SelectItemDef;
                    return SelectItemDef;
                }
            }
            else
            {
                //無ければデフォルトを戻す
                return SelectItemDef;
            }
        }

        /// <summary>
        /// XMLパス取得
        /// </summary>
        /// <param rKeyName="form"></param>
        /// <returns></returns>
        public static string GetXmlPath(Form form, string path)
        {
            string currentPath = Path.GetDirectoryName(form.GetType().Assembly.Location);
            string pathXml = Path.Combine(currentPath, path);
            string selectXml = System.IO.Path.Combine(pathXml, xmlName);
            return selectXml;
        }

        /// <summary>
        /// 設定ファイルパス取得
        /// </summary>
        /// <param rKeyName="employeeCode">従業員コード</param>
        /// <param rKeyName="form">親画面</param>
        /// <returns>設定ファイルパス</returns>
        public static string GetSelectMainMenuItemPath(string employeeCode, System.Windows.Forms.Form form)
        {
            if (employeeCode == null || employeeCode.Length == 0) return "";

            //設定ファイルのパスを生成
            string path = Path.Combine(Path.GetDirectoryName(form.GetType().Assembly.Location), ConstantManagement_ClientDirectory.MenuSettings_AppSettingData);
                
            //従業員コードからファイル名を生成
            string fileName = string.Format("MeinMenuSetting_{0}.xml",employeeCode.Trim());

            //従業員別の設定があるかチェック
            string fullPath = Path.Combine(path, fileName);

            if (File.Exists(fullPath)) return fullPath;
            else return "";
        }

        /// <summary>
        /// 設定保存
        /// </summary>
        /// <param rKeyName="employeeCode">従業員コード</param>
        /// <param rKeyName="form">画面</param>
        /// <returns></returns>
        public bool SaveSettingFile(string employeeCode, System.Windows.Forms.Form form)
        {
            if (employeeCode == null || employeeCode.Length == 0)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Program.pgId, "従業員ログインしてください", 0, MessageBoxButtons.OK);
                return false;
            }
            if (comboBox_Image.SelectedItem == null)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Program.pgId, "イメージを選択してください", 0, MessageBoxButtons.OK);
                comboBox_Image.Focus();
                return false;
            }

            try
            {
                //設定ファイルのパスを生成
                string path = Path.Combine(Path.GetDirectoryName(form.GetType().Assembly.Location), ConstantManagement_ClientDirectory.MenuSettings_AppSettingData);

                //従業員コードからファイル名を生成
                string fileName = string.Format("MeinMenuSetting_{0}.xml",employeeCode.Trim());

                //ディレクトリが無ければ作成
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                //従業員別の設定パス生成
                string fullPath = Path.Combine(path, fileName);

                XmlByteSerializer.Serialize(comboBox_Image.SelectedItem, fullPath);

                return true;
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, Program.pgId, string.Format("設定ファイルの保存に失敗しました[{0}]",ex.Message), 0, MessageBoxButtons.OK);
                return false;
            }
        }

        /// <summary>
        /// 摘要
        /// </summary>
        /// <param rKeyName="sender"></param>
        /// <param rKeyName="e"></param>
        private void button_Save_Click(object sender, EventArgs e)
        {
            //ファイル保存
            if (!SaveSettingFile(Program._sfNetMenuServerInfo.EmployeeCode,Program._form)) return;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// キャンセル
        /// </summary>
        /// <param rKeyName="sender"></param>
        /// <param rKeyName="e"></param>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    /// <summary>
    /// メニューItem情報
    /// </summary>
    [Serializable]
    public class MainMenuItem
    {
        public string Path = "";
        public string Name = "";

        public MainMenuItem()
        {
            Path = "";
            Name = "";
        }

        /// <summary>
        /// 文字変換
        /// </summary>
        /// <returns>名称</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// 比較
        /// </summary>
        /// <param rKeyName="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is MainMenuItem)) return false;
            if (((MainMenuItem)obj).Path == this.Path) return true;
            else return false;
        }
    }

}