//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ロールグループ権限設定マスタ                    //
//                      アクセスクラス                                  //
//                  :   PMKHN09732A.DLL                                 //
// Name Space       :   Broadleaf.Application.Controller                //
// Programmer       :   30746 高川 悟                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

// 業務メニュープログラム(SFNETMENU2)のソースを一部流用して作成
// 上記プログラム同様、セキュリティ上コメントは書かない

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    public class ReadSfNetMenuNavigator
    {
        RijndaelManaged aes;

        public int ReadSfNetMenuNavigatorXML(out DataSet dsSystemProducts)
        {
            aes = new RijndaelManaged();

            string PassKey = "z8G6j53c3bg2o76das";

            byte[] bKey = Encoding.UTF8.GetBytes(PassKey);

            aes.Key = ResizeBytesArray(bKey, aes.Key.Length);
            aes.IV = ResizeBytesArray(bKey, aes.IV.Length);

            int status = 0;
            dsSystemProducts = new DataSet();

            string CurrentDir = Directory.GetCurrentDirectory();
            string MenuDir = "MenuSettings\\NavigationData";
            string DefaultSystemXML = "SfNetMenuNavigator.xml";

            if (File.Exists(Path.Combine(Path.Combine(CurrentDir, MenuDir), DefaultSystemXML)) == false)
            {
                MessageBox.Show("メニュー定義ファイルが見つかりません。\n起動できません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                status = -1;
            }
            else
            {
                MemoryStream ms = DecryptFile(Path.Combine(Path.Combine(CurrentDir, MenuDir), DefaultSystemXML));
                if (ms == null)
                {
                    MessageBox.Show("メニュー定義ファイルが壊れています。\n起動できません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = -1;
                }
                else
                {
                    status = SetSystemConfig(ms, out dsSystemProducts);
                    if (status == -1)
                    {
                        MessageBox.Show("メニュー定義ファイルが壊れています。\n起動できません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            return status;
        }

        public byte[] ResizeBytesArray(byte[] bytes, int newSize)
        {
            byte[] newBytes = new byte[newSize];
            if (bytes.Length <= newSize)
            {
                for (int i = 0; i < bytes.Length; i++)
                    newBytes[i] = bytes[i];
            }
            else
            {
                int pos = 0;
                for (int i = 0; i < bytes.Length; i++)
                {
                    newBytes[pos++] ^= bytes[i];
                    if (pos >= newBytes.Length)
                        pos = 0;
                }
            }
            return newBytes;
        }

        public MemoryStream DecryptFile(string sFileName)
        {
            if (File.Exists(sFileName) == false)
            {
                return null;
            }

            try
            {
                MemoryStream ms = new MemoryStream();

                using (FileStream streamRead = new FileStream(sFileName, FileMode.Open, FileAccess.Read))
                {
                    using (CryptoStream cs = new CryptoStream(streamRead, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] source = new byte[256];
                        int readLen;
                        while ((readLen = cs.Read(source, 0, source.Length)) > 0)
                        {
                            ms.Write(source, 0, readLen);
                        }
                    }
                }

                ms.Position = 0;

                return ms;
            }
            catch (Exception er)
            {

                return null;

            }
            
        }

        public int SetSystemConfig(MemoryStream xmlConfig, out  DataSet dsSystemProducts)
        {
            dsSystemProducts = new DataSet();

            try
            {
                dsSystemProducts.ReadXml(xmlConfig, XmlReadMode.Auto);
            }
            catch (Exception er)
            {
                return -1;
            }

            return 0;
        }

        public int GetClassAndName(int roleCategoryID, int roleCategorySubID, int roleItemID, out string[] ClassAndName)
        {
            string[] wkClassAndName = new string[3];
            string RoleClass = string.Empty;
            string RoleName = string.Empty;
            string SortKeyClass = "0";
            string SortKeyCategoryID = "000";
            string SortKeyCategorySubID = "00";
            string SortKeyItemID = "0";
            DataSet dsSystemProducts = new DataSet();

            int status = ReadSfNetMenuNavigatorXML(out   dsSystemProducts);

            if (roleCategoryID != 0)
            {
                RoleClass = "カテゴリ";

                if (dsSystemProducts.Tables["ProductCategory"].Rows.Count != 0)
                {
                    DataRow[] wkSystemProducts = dsSystemProducts.Tables["ProductCategory"].Select("CategoryID = " + roleCategoryID);

                    if (wkSystemProducts.Length > 0)
                    {
                        RoleName += wkSystemProducts[0].ItemArray[3];
                        SortKeyClass = "1";
                        SortKeyCategoryID = string.Format("{0:D3}", wkSystemProducts[0].ItemArray[2]);
                    }
                }

                if (roleCategorySubID != 0)
                {
                    RoleClass = "サブカテゴリ";

                    if (dsSystemProducts.Tables["ProductSubCategory"].Rows.Count != 0)
                    {
                        DataRow[] wkSystemProducts = dsSystemProducts.Tables["ProductSubCategory"].Select("CategoryID = " + roleCategoryID + " AND CategorySubID = " + roleCategorySubID);

                        if (wkSystemProducts.Length > 0)
                        {
                            RoleName += " - " + wkSystemProducts[0].ItemArray[4];
                            SortKeyClass = "2";
                            SortKeyCategorySubID = string.Format("{0:D2}", wkSystemProducts[0].ItemArray[2]);
                        }
                    }


                    if (roleItemID != 0)
                    {
                        RoleClass = "アイテム";

                        if (dsSystemProducts.Tables["ProductItem"].Rows.Count != 0)
                        {
                            DataRow[] wkSystemProducts = dsSystemProducts.Tables["ProductItem"].Select("CategoryID = " + roleCategoryID + " AND CategorySubID = " + roleCategorySubID + " AND ItemID = " + roleItemID);

                            if (wkSystemProducts.Length > 0)
                            {
                                RoleName += " - " + wkSystemProducts[0].ItemArray[8];
                                SortKeyClass = "3";
                                SortKeyItemID = string.Format("{0:D1}", wkSystemProducts[0].ItemArray[3]);
                            }
                        }
                    }

                }

            }

            RoleName = RoleName.Replace("\\n", "");

            wkClassAndName[0] = RoleClass;
            wkClassAndName[1] = RoleName;
            wkClassAndName[2] = SortKeyClass + SortKeyCategoryID + SortKeyCategorySubID + SortKeyItemID;
            ClassAndName = wkClassAndName;

            return 0;

        }

    }

}