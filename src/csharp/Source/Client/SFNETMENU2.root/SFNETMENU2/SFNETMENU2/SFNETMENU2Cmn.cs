using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// 製品情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       :製品報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 2006.09.29 鹿野　幸生</br>
    /// </remarks>
    [Serializable()]
    public class ProductsInfomation
    {
        public string ProductID = "";
        public string ProductName = "";
        public string Version = "";
        //public string IconType = "";                                  //  2006.09.29  削除
        public int IconIndex = -1;
        public string IconName = "";
        public Image Icon = null;
        //public string SystemCode = "";                                //  2006.09.29  削除
        //public string OptionCode = "";                                //  2006.09.29  削除
        public string SysOpCode = "";                                   //  2006.09.29  追加
        public string DisplayOption = "";
    }

    /// <summary>
    /// タブメニュー情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : タブメニュー情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    [Serializable()]
    public class TabMenuInfomation
    {
        public int SubMenuItemCount;
        public int SubMenuItemSetType;   //0:サイズ優先,1:ページ内個数優先
        public int SubMenuItemWidth1;
        public int SubMenuItemWidth2;
        public int SubMenuItemMaxWidth1;
        public int SubMenuItemMaxWidth2;
        public int SubMenuItemMaxWidth3;
        public int SubMenuItemDefCount1;
        public int SubMenuItemDefCount2;
        public int SubMenuItemDefCount3;
        public int SubMenuItemMaxItemFig1;//ノーマル
        public int SubMenuItemMaxItemFig2;//マスメン
        public int SubMenuItemMaxItemFig3;//帳票
        public int SubMenuItemMargin;
        public int CategoryID;
        //public string IconType;               //  2006.09.29  削除
        public int IconIndex;
        public string IconName = null;
        public Image Icon;
        public bool NeedRefresh;
        public ArrayList arSubItems;

        public TabMenuInfomation(int iCategoryID)
        {
            CategoryID = iCategoryID;
            arSubItems = new ArrayList();
            arSubItems.Clear();
        }
    }

    /// <summary>
    /// カテゴリ情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : カテゴリ情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    [Serializable()]
    public class CategoryInfomation
    {

        public int CategoryID;
        public int No;
        public string Name;
        public string Description;
        //public string IconType;               //  2006.09.29  削除
        public int IconIndex;
        public string IconName;
        public Image Icon;
        //public string SystemCode;             //  2006.09.29  削除
        //public string OptionCode;             //  2006.09.29  削除
        public string SysOpCode;                //  2006.09.29  追加
        public string DisplayOption;

    }

    /// <summary>
    /// サブカテゴリ情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : サブカテゴリ情報クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    [Serializable()]
    public class SubCategoryInfomation
    {

        public int CategoryID;
        public int CategorySubID;
        public int No;
        public string Name;
        public string Description;
        //public string IconType;               //  2006.09.29  削除
        public int IconIndex;
        public string IconName;
        //public string SystemCode;             //  2006.09.29  削除
        //public string OptionCode;             //  2006.09.29  削除
        public string SysOpCode;                //  2006.09.29  追加
        public string DisplayOption;

    }

    /// <summary>
    /// サブカテゴリ情報クラス(初期デリバリ版)
    /// </summary>
    /// <remarks>
    /// <br>Note       : サブカテゴリ情報クラス(初期デリバリ版-過去バージョンの上位互換の為にある)</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.29</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    [Serializable()]
    public class SubCategoryInfomationOldVer1
    {

        public int CategoryID;
        public int CategorySubID;
        public int No;
        public string Name;
        public string Description;
        public string IconType;
        public int IconIndex;
        public string IconName;
        public string SystemCode;
        public string OptionCode;
        public string DisplayOption;

    }

    /// <summary>
    /// サブメニューアイテム情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : サブメニューアイテムクラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    [Serializable()]
    public class MenuItemInfomation
    {

        public int CategoryID;
        public int CategorySubID;
        public int ItemID;
        public int No;
        public int ItemSubID;                   //  2006.09.29  追加
        public int SubNo;                       //  2006.09.29  追加
        public string Pgid;
        public string Name;
        public string Parameter;
        public string Description;
        //public string IconType;               //  2006.09.29  削除
        public int IconIndex;
        public string IconName;
        //public string SystemCode;             //  2006.09.29  削除
        //public string OptionCode;             //  2006.09.29  削除
        public string SysOpCode;                //  2006.09.29  追加
        public string DisplayOption;
        public string SearchKeyWord;
        public int Rank;

    }


    public class RollSettingInfomation
    {
        public int RollRank;
        public string RollName;
        public int PassWordType;
        public string PassWord;
        public string Result;
    }

    /// <summary>
    /// ユーティリティクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ユーティリティクラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 2007.01.10 鹿野　幸生</br>
    /// <br></br>
    /// <br>Update Note: 2012/11/29 22018 鈴木正臣</br>
    /// <br>             確認ダイアログの追加</br>
    /// </remarks>
    public class SFNETMENU2Utilities
    {

        private static DataSet dsSystemProducts = new DataSet();
        private static DataSet dsUserProducts = new DataSet();

        public  const string DefaultSystemXML = "SfNetMenuNavigator.xml";
        public  const string RollSettingXML = "SfNetNullSet.xml";
        public  static string StatusMessage = "";

        public  const int CallndarTypeFig = 12;

        /// <summary>メッセージレベル</summary>
        /// <remarks>ShowMessageで使用するメッセージレベルの列挙型です</remarks>
        public enum MessageDlgLevel : int
        {
            /// <summary>情報表示</summary>
            msgErrLevelInfo,
            /// <summary>確認１(はい・いいえ)</summary>
            msgErrLevelConfirem1,
            /// <summary>確認２(はい・いいえ・キャンセル)</summary>
            msgErrLevelConfirem2,
            /// <summary>確認３(OK・キャンセル)</summary>
            msgErrLevelConfirem3,
            /// <summary>警告</summary>
            msgErrLevelWarning,
            // --- ADD m.suzuki 2012/11/29 ---------->>>>>
            /// <summary>警告（いいえ・はい）</summary>
            msgErrLevelWarningConfirem,
            // --- ADD m.suzuki 2012/11/29 ----------<<<<<
            /// <summary>エラー</summary>
            msgErrLevelError
        }

        /// <summary>
        /// メッセージ出力処理
        /// </summary>
        /// <param name="ErrLevel">エラーレベル</param>
        /// <param name="Unit">ユニット名</param>
        /// <param name="ErrMainMessage">エラーメッセージ(自由)</param>
        /// <param name="ErrStatusMessage">システムエラーメッセージ</param>
        /// <param name="ErrStatusMessage">システムエラーコード</param>
        /// <returns>ユーザー対応結果</returns>
        /// <remarks>
        /// <br>Note       :メッセージを出力する</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DialogResult ShowMessage(MessageDlgLevel ErrLevel, string Unit, string ErrMainMessage, string ErrStatusMessage, string ErrCode)
        {
            MessageBoxButtons btnType = MessageBoxButtons.OK;
            MessageBoxIcon icoType = MessageBoxIcon.Exclamation;
            // --- ADD m.suzuki 2012/11/29 ---------->>>>>
            MessageBoxDefaultButton defaultBtn = MessageBoxDefaultButton.Button1;
            // --- ADD m.suzuki 2012/11/29 ----------<<<<<
            string errCaption = "";
            string errMsg = "";

            switch (ErrLevel)
            {
                case MessageDlgLevel.msgErrLevelInfo:					//	インフォメーション
                    btnType = MessageBoxButtons.OK;
                    icoType = MessageBoxIcon.Information;
                    //errCaption = "情報 － <SuperFrontman.NS 業務メニュー>";        //  2006.09.29  変更
                    errCaption = "情報 － <.NS 業務メニュー>";
                    break;
                case MessageDlgLevel.msgErrLevelConfirem1:				//	確認１(はい・いいえ)
                    btnType = MessageBoxButtons.YesNo;
                    icoType = MessageBoxIcon.Question;
                    //errCaption = "確認 － <SuperFrontman.NS 業務メニュー>";        //  2006.09.29  変更
                    errCaption = "確認 － <.NS 業務メニュー>";
                    break;
                case MessageDlgLevel.msgErrLevelConfirem2:				//	確認２(はい・いいえ・キャンセル)
                    btnType = MessageBoxButtons.YesNoCancel;
                    icoType = MessageBoxIcon.Question;
                    //errCaption = "確認 － <SuperFrontman.NS 業務メニュー>";        //  2006.09.29  変更
                    errCaption = "確認 － <.NS 業務メニュー>";
                    break;
                case MessageDlgLevel.msgErrLevelConfirem3:				//	確認３(OK・キャンセル)
                    btnType = MessageBoxButtons.OKCancel;
                    icoType = MessageBoxIcon.Question;
                    //errCaption = "確認 － <SuperFrontman.NS 業務メニュー>";        //  2006.09.29  変更
                    errCaption = "確認 － <.NS 業務メニュー>";
                    break;
                case MessageDlgLevel.msgErrLevelWarning:				//	警告
                    btnType = MessageBoxButtons.OK;
                    icoType = MessageBoxIcon.Exclamation;
                    //errCaption = "警告 － <SuperFrontman.NS 業務メニュー>";        //  2006.09.29  変更
                    errCaption = "警告 － <.NS 業務メニュー>";
                    break;
                // --- ADD m.suzuki 2012/11/29 ---------->>>>>
                case MessageDlgLevel.msgErrLevelWarningConfirem:        // 警告（いいえ・はい）
                    btnType = MessageBoxButtons.YesNo;
                    icoType = MessageBoxIcon.Exclamation;
                    errCaption = "警告 － <.NS 業務メニュー>";
                    defaultBtn = MessageBoxDefaultButton.Button2; // デフォルト=いいえ
                    break;
                // --- ADD m.suzuki 2012/11/29 ----------<<<<<
                case MessageDlgLevel.msgErrLevelError:					//	エラー
                    btnType = MessageBoxButtons.OK;
                    icoType = MessageBoxIcon.Stop;
                    //errCaption = "エラー発生 － <SuperFrontman.NS 業務メニュー>";   //  2006.09.29  変更
                    //errMsg = "SuperFrontman.NS 業務メニュー(" + Unit + ")にてエラーが発生しました。\n\n";
                    errCaption = "エラー発生 － <.NS 業務メニュー>";
                    errMsg = ".NS 業務メニュー(" + Unit + ")にてエラーが発生しました。\n\n";
                    break;
            }

            // --- UPD m.suzuki 2012/11/29 ---------->>>>>
            if (ErrLevel != MessageDlgLevel.msgErrLevelWarningConfirem)
            {
                errMsg = errMsg + "[" + ErrMainMessage + "]\n\n" + ErrStatusMessage;
                if (ErrLevel > MessageDlgLevel.msgErrLevelConfirem3)
                    errMsg = errMsg + "\n\n  <ステータス = " + ErrCode + " >";
            }
            else
            {
                errMsg = ErrStatusMessage;
            }
            // --- UPD m.suzuki 2012/11/29 ----------<<<<<

            // --- UPD m.suzuki 2012/11/29 ---------->>>>>
            //return (MessageBox.Show(errMsg, errCaption, btnType, icoType));
            return (MessageBox.Show( errMsg, errCaption, btnType, icoType, defaultBtn ));
            // --- UPD m.suzuki 2012/11/29 ----------<<<<<
        }

        /// <summary>
        /// システムメニュー情報設定処理
        /// </summary>
        /// <param name="xmlConfig">システムメニュー情報</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :システムメニュー情報設定</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static int SetSystemConfig(MemoryStream xmlConfig)
        {
            int nRtnCd = 0;

            StatusMessage = "";

            try
            {
                dsSystemProducts.ReadXml(xmlConfig, XmlReadMode.Auto);
            }
            catch (Exception er)
            {
                nRtnCd = 5;
                StatusMessage = er.Message;
            }

            return nRtnCd;

        }

        /// <summary>
        /// ユーザーメニュー情報設定処理
        /// </summary>
        /// <param name="dsUserData">ユーザーメニュー情報</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :ユーザーメニュー情報設定</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DataSet SetUserConfig(DataSet dsUserData)
        {
            //int nRtnCd = 0;

            StatusMessage = "";

            try
            {
                return dsUserProducts = dsUserData;
            }
            catch (Exception er)
            {
                //nRtnCd = 5;
                StatusMessage = er.Message;
                return null;
            }

        }

        /// <summary>
        /// ユーザーメニュー情報取得処理
        /// </summary>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :ユーザーメニュー情報取得</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DataSet GetUserConfig()
        {
            //int nRtnCd = 0;

            StatusMessage = "";

            try
            {
                return dsUserProducts;
            }
            catch (Exception er)
            {
                //nRtnCd = 5;
                StatusMessage = er.Message;
                return null;
            }

        }

        /// <summary>
        /// 製品情報取得処理(プロダクト指定)
        /// </summary>
        /// <param name="Products">プロダクト名</param>
        /// <returns>検索結果</returns>
        /// <remarks>
        /// <br>Note       :製品情報取得</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.29</br>
        /// </remarks>
        public static DataRow[] GetProducts(string Products)
        {

            try
            {
                //  最上位情報
                DataRow[] foundRows = dsSystemProducts.Tables["ProductCategory"].Select("CategoryID < 0 and Products = '" + Products + "'", "CategoryID");

                return foundRows;
            }
            catch (Exception)
            {
                return new DataRow[0];
            }


        }

        /// <summary>
        /// カテゴリ情報取得処理(プロダクト指定)
        /// </summary>
        /// <param name="Products">プロダクト名</param>
        /// <param name="IncludeAll">共通製品を取得</param>
        /// <returns>検索結果</returns>
        /// <remarks>
        /// <br>Note       :カテゴリ情報取得</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
//        public static DataRow[] GetCategory(string[] Products)                    //  2006.09.29  変更
        public static DataRow[] GetCategory(string[] Products, bool IncludeAll)
        {
            DataRow[] foundRows;

            //                                                                      //  2006.09.29  変更 VV
            /*
            string sWhere = "";
            for (int i = 0; i < Products.Length; i++)
            {
                sWhere = sWhere + "Products = '" + Products[i] + "'";
                if (i < (Products.Length - 1))
                {
                    sWhere = sWhere + " and ";
                }
            }
            sWhere = sWhere + " and CategoryID <> 0"; 
            */
            string sWhere = "";
            if (IncludeAll == true)
            {
                sWhere = "Products = 'All' or ";
            }
            for (int i = 0; i < Products.Length; i++)
            {
                sWhere = sWhere + "Products = '" + Products[i] + "'";
                if (i < (Products.Length - 1))
                {
                    sWhere = sWhere + " or ";
                }
            }
            sWhere = sWhere + " and CategoryID > 0"; 
            //                                                                      //  2006.09.29  変更 AA

            try
            {
                foundRows = dsSystemProducts.Tables["ProductCategory"].Select(sWhere, "No");

                return foundRows;
            }
            catch (Exception)
            {
                return new DataRow[0];
            }


        }

        /// <summary>
        /// カテゴリ情報取得処理(カテゴリ指定-カテゴリIDは製品によらずユニーク)
        /// </summary>
        /// <param name="CategoryID">対象カテゴリID</param>
        /// <param name="SingleRows">一行取得</param>
        /// <returns>検索結果</returns>
        /// <remarks>
        /// <br>Note       :カテゴリ情報取得</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.29</br>
        /// </remarks>
        public static DataRow[] GetCategory(int CategoryID, bool SingleRows)
        {
            DataRow[] foundRows;

            try
            {
                if (SingleRows == true)
                {
                    //  1行取得
                    foundRows = dsSystemProducts.Tables["ProductCategory"].Select("CategoryID = " + CategoryID.ToString(), "No");
                }
                else
                {
                    //  複数取得
                    foundRows = dsSystemProducts.Tables["ProductCategory"].Select("CategoryID >= " + CategoryID.ToString(), "No");
                }

                return foundRows;
            }
            catch (Exception)
            {
                return new DataRow[0];
            }


        }


        /// <summary>
        /// カテゴリ情報取得処理(プロダクト/カテゴリ指定)
        /// </summary>
        /// <param name="Products">プロダクト名</param>
        /// <param name="CategoryID">対象カテゴリID</param>
        /// <param name="SingleRows">一行取得</param>
        /// <returns>検索結果</returns>
        /// <remarks>
        /// <br>Note       :カテゴリ情報取得</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        //                                                                                          //  2006.09.29  削除
        /*
        public static DataRow[] GetCategory(string Products, int CategoryID, bool SingleRows)
        {
            DataRow[] foundRows;

            try
            {
                if (SingleRows == true)
                {
                    foundRows = dsSystemProducts.Tables["ProductCategory"].Select("Products = '" + Products + "' and CategoryID = " + CategoryID.ToString(), "No");
                }
                else
                {
                    foundRows = dsSystemProducts.Tables["ProductCategory"].Select("Products = '" + Products + "' and CategoryID >= " + CategoryID.ToString(), "No");
                }

                return foundRows;
            }
            catch (Exception er)
            {
                return new DataRow[0];
            }


        }
        */

        /// <summary>
        /// サブカテゴリ情報取得処理(指定サブカテゴリ)
        /// </summary>
        /// <param name="CategoryID">対象カテゴリID</param>
        /// <param name="CategorySubID">対象サブカテゴリID</param>
        /// <returns>検索結果</returns>
        /// <remarks>
        /// <br>Note       :サブカテゴリ情報取得(指定サブカテゴリ)</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DataRow[] GetSubCategory(int CategoryID, int CategorySubID)
        {
            DataRow[] foundRows;

            try
            {

                foundRows = dsSystemProducts.Tables["ProductSubCategory"].Select("CategoryID = " + CategoryID.ToString() + " and CategorySubID = " + CategorySubID.ToString(), "No");

                return foundRows;

            }
            catch (Exception)
            {
                return new DataRow[0];
            }


        }

        /// <summary>
        /// サブカテゴリ情報取得処理(カテゴリ内全サブカテゴリ)
        /// </summary>
        /// <param name="CategoryID">対象カテゴリID</param>
        /// <returns>検索結果</returns>
        /// <remarks>
        /// <br>Note       :サブカテゴリ情報取得(カテゴリ内全サブカテゴリ)</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DataRow[] GetSubCategoryGroup(int CategoryID)
        {
            DataRow[] foundRows;

            try
            {

                if (CategoryID != 0)
                {

                    foundRows = dsSystemProducts.Tables["ProductSubCategory"].Select("CategoryID = " + CategoryID.ToString(), "No");
                }
                else
                {

                    foundRows = dsSystemProducts.Tables["ProductSubCategory"].Select("", "No");
                }
                return foundRows;

            }
            catch (Exception)
            {
                return new DataRow[0];
            }


        }

        /// <summary>
        /// メニューアイテム情報取得処理(カテゴリID・サブカテゴリID指定)
        /// </summary>
        /// <param name="CategoryID">対象カテゴリID</param>
        /// <param name="CategorySubID">対象カテゴリサブID</param>
        /// <param name="GetType">取得対象タイプ(0:本体PGのみ,1:子PGのみ,2:本体・子共)</param>
        /// <returns>検索結果</returns>
        /// <remarks>
        /// <br>Note       :メニューアイテム情報取得</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        //public static DataRow[] GetProductItem(int CategoryID, int CategorySubID)                         //  2006.09.29  変更
        public static DataRow[] GetProductItem(int CategoryID, int CategorySubID, int GetType)
        {
            DataRow[] foundRows;

            try
            {
                //  取得タイプで検索文字列を変更する                           // 2006.09.29  追加
                string WhereString = "CategoryID = " + CategoryID + " and CategorySubID = " + CategorySubID;
                if (GetType == 0)
                {
                    WhereString = WhereString + " and ItemSubID = 0";
                }
                else if (GetType == 1)
                {
                    WhereString = WhereString + " and ItemSubID <> 0"; 
                }

                //foundRows = dsSystemProducts.Tables["ProductItem"].Select("CategoryID = " + CategoryID + " and CategorySubID = " + CategorySubID, "No, SubNo");   //  2006.09.29  変更
                foundRows = dsSystemProducts.Tables["ProductItem"].Select(WhereString, "No, SubNo");
                return foundRows;

            }
            catch (Exception)
            {
                return new DataRow[0];
            }

        }

        /// <summary>
        /// メニューアイテム情報取得処理(カテゴリID・サブカテゴリID・アイテムID指定)
        /// </summary>
        /// <param name="CategoryID">対象カテゴリID</param>
        /// <param name="CategorySubID">対象カテゴリサブID</param>
        /// <param name="ItemID">対象カテゴリサブID</param>
        /// <param name="GetType">取得対象タイプ(0:本体PGのみ,1:子PGのみ,2:本体・子共)</param>
        /// <returns>検索結果</returns>
        /// <remarks>
        /// <br>Note       :メニューアイテム情報取得</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DataRow[] GetProductItem(int CategoryID, int CategorySubID, int ItemID, int GetType)
        {
            DataRow[] foundRows;

            try
            {
                //  取得タイプで検索文字列を変更する                           // 2006.09.29  追加
                string WhereString = "CategoryID = " + CategoryID + " and CategorySubID = " + CategorySubID + " and ItemID = " + ItemID.ToString();
                if (GetType == 0)
                {
                    WhereString = WhereString + " and ItemSubID = 0";
                }
                else if (GetType == 1)
                {
                    WhereString = WhereString + " and ItemSubID <> 0";
                }

                //foundRows = dsSystemProducts.Tables["ProductItem"].Select("CategoryID = " + CategoryID + " and CategorySubID = " + CategorySubID, "No, SubNo");   //  2006.09.29  変更
                foundRows = dsSystemProducts.Tables["ProductItem"].Select(WhereString, "No, SubNo");
                return foundRows;

            }
            catch (Exception)
            {
                return new DataRow[0];
            }



        }

        /// <summary>
        /// メニューアイテム情報検索処理
        /// </summary>
        /// <param name="srchTargetProgram">検索文字列</param>
        /// <param name="GetType">取得対象タイプ(0:本体PGのみ,1:子PGのみ,2:本体・子共)</param>
        /// <returns>検索結果</returns>
        /// <remarks>
        /// <br>Note       :メニューアイテム情報検索</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        //public static DataRow[] SearchProductItem(string srchTargetProgram)
        public static DataRow[] SearchProductItem(string srchTargetProgram, int GetType)
        {
            DataRow[] foundRows;

            try
            {
                //  取得タイプで検索文字列を変更する                           // 2006.09.29  追加
                //string WhereString = "Name LIKE '*" + srchTargetProgram + "*' or SearchKeyWord LIKE '*" + srchTargetProgram + "*'";   //  2007.01.10  変更
                string WhereString = "(Name LIKE '*" + srchTargetProgram + "*' or SearchKeyWord LIKE '*" + srchTargetProgram + "*')";
                if (GetType == 0)
                {
                    WhereString = WhereString + " and ItemSubID = 0";
                }
                else if (GetType == 1)
                {
                    WhereString = WhereString + " and ItemSubID <> 0";
                }

                //foundRows = dsSystemProducts.Tables["ProductItem"].Select("Name LIKE '*" + srchTargetProgram + "*' or SearchKeyWord LIKE '*" + srchTargetProgram + "*'", "CategoryID, CategorySubID, No");    //  2006.09.29  変更
                foundRows = dsSystemProducts.Tables["ProductItem"].Select(WhereString, "CategoryID, CategorySubID, No, SubNo");

                return foundRows;
            }
            catch (Exception)
            {
                return new DataRow[0];
            }

        }

        /// <summary>
        /// メニュースキーマ・クローン作成処理
        /// </summary>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :メニュースキーマ・クローン作成</br>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static int CloneSchema()
        {
            try
            {
                dsUserProducts = dsSystemProducts.Clone();
                for (int i = 0; i < dsUserProducts.Tables.Count; i++)
                {
                    dsUserProducts.Tables[i].Clear();
                }

                return 0;
            }
            catch (Exception)
            {
                return 5;
            }

        }

        /// <summary>
        /// ユーザーメニューグループ追加処理
        /// </summary>
        /// <param name="ci">カテゴリ情報</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :ユーザーメニューグループ追加処理</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static int AddUserMenuCategory(CategoryInfomation ci)
        {

            DataRow dr = dsUserProducts.Tables["ProductCategory"].NewRow();
            dr["Products"] = "User";
            dr["CategoryID"] = -101;
            dr["CategorySubID"] = ci.No;
            dr["No"] = ci.No;           //  調整する
            dr["Name"] = ci.Name;
            dr["Description"] = ci.Description;
            //dr["IconType"] = ci.IconType;                                 //  2006.09.29  削除
            dr["IconIndex"] = ci.IconIndex;
            dr["IconName"] = ci.IconName;
            //dr["SystemCode"] = ci.SystemCode;                             //  2006.09.29  削除
            //dr["OptionCode"] = ci.OptionCode;                             //  2006.09.29  削除
            dr["SysOpCode"] = ci.SysOpCode;                                 //  2006.09.29  追加
            dr["DisplayOption"] = ci.DisplayOption;
            dsUserProducts.Tables["ProductCategory"].Rows.Add(dr);

            return 0;

        }

        /// <summary>
        /// ユーザーメニューグループクリア処理
        /// </summary>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :ユーザーメニューグループクリア処理</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static int ClearUserCategory()
        {

            dsUserProducts.Tables["UserCategory"].Rows.Clear();

            return 0;

        }

        /// <summary>
        /// ユーザーメニューアイテムクリア処理
        /// </summary>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :ユーザーメニューアイテムクリア処理</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static int ClearUserItem()
        {

            dsUserProducts.Tables["UserItem"].Clear();

            return 0;

        }

        /// <summary>
        /// ユーザーメニューグループ追加処理
        /// </summary>
        /// <param name="usrCategoryID">ユーザーカテゴリID</param>
        /// <param name="usrName">ユーザーカテゴリ名称</param>
        /// <param name="usrNo">ユーザーカテゴリ表示順</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :ユーザーメニューグループ追加処理</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static int AddUserCategory(int usrCategoryID, string usrName, int usrNo)
        {

            DataRow dr = dsUserProducts.Tables["UserCategory"].NewRow();
            dr["UserCategoryID"] = usrCategoryID;
            dr["Name"] = usrName;
            dr["UserNo"] = usrNo;
            dsUserProducts.Tables["UserCategory"].Rows.Add(dr);

            return 0;

        }

        /// <summary>
        /// ユーザーメニューアイテム追加処理
        /// </summary>
        /// <param name="usrCategoryID">ユーザーカテゴリID</param>
        /// <param name="CategroyID">カテゴリID</param>
        /// <param name="SubCategoryID">サブカテゴリID</param>
        /// <param name="ItemID">アイテムID</param>
        /// <param name="No">表示順</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :ユーザーメニューアイテム追加処理</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static int AddUserItem(int usrCategoryID, int CategroyID, int SubCategoryID, int ItemID, int No)
        {

            DataRow dr = dsUserProducts.Tables["UserItem"].NewRow();
            dr["UserCategoryID"] = usrCategoryID;
            dr["CategoryID"] = CategroyID;
            dr["CategorySubID"] = SubCategoryID;
            dr["ItemID"] = ItemID;
            dr["No"] = No;
            dsUserProducts.Tables["UserItem"].Rows.Add(dr);

            return 0;

        }

        /// <summary>
        /// メニューマージ処理
        /// </summary>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :メニューマージ処理</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static int MergeMenuInfomation()
        {
            try
            {
                dsSystemProducts.Merge(dsUserProducts);

                return 0;
            }
            catch (Exception)
            {
                return 5;
            }

        }

        /// <summary>
        /// ユーザーメニュー情報作成処理
        /// </summary>
        /// <returns>ユーザーメニュー</returns>
        /// <remarks>
        /// <br>Note       :ユーザーメニュー情報作成</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DataSet CreateUserMenuInfomation()
        {

            try
            {
                //  ユーザーサブカテゴリ(グループ)テーブル定義
                DataTable tUserCategory = new DataTable("UserCategory");
                DataColumn cUserCategoryID = new DataColumn();
                DataColumn cUserCategoryName = new DataColumn();
                DataColumn cUserNo = new DataColumn();
                cUserCategoryID.DataType = System.Type.GetType("System.Int32");
                cUserCategoryID.AllowDBNull = false;
                cUserCategoryID.ColumnName = "UserCategoryID";
                cUserCategoryName.DataType = System.Type.GetType("System.String");
                cUserCategoryName.AllowDBNull = false;
                cUserCategoryName.ColumnName = "Name";
                cUserNo.DataType = System.Type.GetType("System.Int32");
                cUserNo.AllowDBNull = false;
                cUserNo.ColumnName = "UserNo";
                tUserCategory.Columns.Add(cUserCategoryID);
                tUserCategory.Columns.Add(cUserCategoryName);
                tUserCategory.Columns.Add(cUserNo);

                //  ユーザーアイテム定義
                DataTable tUserItem = new DataTable("UserItem");
                DataColumn cUserCategoryID2 = new DataColumn();
                DataColumn cCategoryID = new DataColumn();
                DataColumn cCategorySubID = new DataColumn();
                DataColumn cItemID = new DataColumn();
                DataColumn cNo = new DataColumn();
                cUserCategoryID2.DataType = System.Type.GetType("System.Int32");
                cUserCategoryID2.AllowDBNull = false;
                cUserCategoryID2.ColumnName = "UserCategoryID";
                cCategoryID.DataType = System.Type.GetType("System.Int32");
                cCategoryID.AllowDBNull = false;
                cCategoryID.ColumnName = "CategoryID";
                cCategorySubID.DataType = System.Type.GetType("System.Int32");
                cCategorySubID.AllowDBNull = false;
                cCategorySubID.ColumnName = "CategorySubID";
                cItemID.DataType = System.Type.GetType("System.Int32");
                cItemID.AllowDBNull = false;
                cItemID.ColumnName = "ItemID";
                cNo.DataType = System.Type.GetType("System.Int32");
                cNo.AllowDBNull = false;
                cNo.ColumnName = "No";
                tUserItem.Columns.Add(cUserCategoryID2);
                tUserItem.Columns.Add(cCategoryID);
                tUserItem.Columns.Add(cCategorySubID);
                tUserItem.Columns.Add(cItemID);
                tUserItem.Columns.Add(cNo);

                //  データセットに追加
                dsUserProducts = new DataSet();
                dsUserProducts.Tables.Add(tUserCategory);
                dsUserProducts.Tables.Add(tUserItem);


                return dsUserProducts;
            }
            catch(Exception)
            {
                return null;

            }


        }

        /// <summary>
        /// ユーザーメニューカテゴリ情報取得処理
        /// </summary>
        /// <param name="CategroyID">カテゴリID</param>
        /// <returns>取得結果</returns>
        /// <remarks>
        /// <br>Note       :ユーザーメニューカテゴリ情報取得</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DataRow[] GetUserCategoryGroup(int CategoryID)
        {

            try
            {
                DataTable tmpProductCategory = dsSystemProducts.Tables["ProductSubCategory"].Clone();

                //  カテゴリ=-1なら全レコード                                             //  2007.01.10  追加
                string WhereString = "";
                if (CategoryID > -1)
                {
                    WhereString = "UserCategoryID = " + CategoryID.ToString();
                }
                //DataRow[] tmpRows = dsUserProducts.Tables["UserCategory"].Select("", "UserNo");   //  2007.01.10  変更
                DataRow[] tmpRows = dsUserProducts.Tables["UserCategory"].Select(WhereString, "UserNo");

                DataRow[] ret = new DataRow[tmpRows.Length];

                int i = 0;
                foreach (DataRow dr in tmpRows)
                {
                    DataRow foundRows = tmpProductCategory.NewRow();
                    foundRows["Products"] = "User";
                    foundRows["CategoryID"] = -101;
                    foundRows["CategorySubID"] = dr["UserCategoryID"];           //  調整する
                    foundRows["No"] = dr["UserNo"];                                  //  調整する
                    foundRows["Name"] = dr["Name"];
                    foundRows["Description"] = "";
                    //foundRows["IconType"] = "res";                            //  2006.09.29  削除
                    foundRows["IconIndex"] = 0;
                    foundRows["IconName"] = "";
                    //foundRows["SystemCode"] = "";                             //  2006.09.29  削除
                    //foundRows["OptionCode"] = "";                             //  2006.09.29  削除
                    foundRows["SysOpCode"] = "";                                //  2006.09.29  追加
                    foundRows["DisplayOption"] = "0";
                    ret[i++] = foundRows;
                }

                return ret;
            }
            catch (Exception)
            {
                return new DataRow[0];
            }

        }


        /// <summary>
        /// ユーザーメニューアイテム情報取得処理
        /// </summary>
        /// <param name="UserCategoryID">ユーザーカテゴリID</param>
        /// <returns>取得結果</returns>
        /// <remarks>
        /// <br>Note       :ユーザーメニューアイテム情報取得</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DataRow[] GetUserItem(int UserCategoryID)
        {
            DataTable tmpProductItem = dsSystemProducts.Tables["ProductItem"].Clone();
            DataRowCollection foundRows = tmpProductItem.Rows;

            DataRow[] tmpUserItemRow = dsUserProducts.Tables["UserItem"].Select("UserCategoryID = " + UserCategoryID.ToString(), "");

            foreach (DataRow dr in tmpUserItemRow)
            {
                //String strSearch = "CategoryID = " + dr["CategoryID"] + " and CategorySubID = " + dr["CategorySubID"] + " and ItemID = " + dr["ItemID"];      //  2006.09.29  追加
                String strSearch = "CategoryID = " + dr["CategoryID"] + " and CategorySubID = " + dr["CategorySubID"] + " and ItemID = " + dr["ItemID"] + " and ItemSubID = 0";
                DataRow[] tmpRows = dsSystemProducts.Tables["ProductItem"].Select(strSearch, "No");
                if (tmpRows.Length != 0)
                {
                    try
                    {
                        tmpProductItem.ImportRow(tmpRows[0]);
                    }
                    catch(Exception)
                    {
                        //  重複はNULLに
                    }

                }
            }
            DataRow[] ret = new DataRow[tmpProductItem.Rows.Count];
            for (int i = 0; i < tmpProductItem.Rows.Count; i++)
            {
                ret[i] = tmpProductItem.Rows[i];
            }

            return ret;

        }

        /// <summary>
        /// 形式化カレンダー文字列取得処理
        /// </summary>
        /// <param name="FormatType">フォーマットタイプ</param>
        /// <returns>形式化カレンダー文字列</returns>
        /// <remarks>
        /// <br>Note       :形式化カレンダー文字列取得</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static string GetCalendar(ref int FormatType)
        {

            //  日付設定
//            string sWeekJ;
            string sWeekE;
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
            {
//                sWeekJ = "(月)";
                sWeekE = "(Mon)";
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
            {
//                sWeekJ = "(火)";
                sWeekE = "(Tue)";
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Wednesday)
            {
//                sWeekJ = "(水)";
                sWeekE = "(Wed)";
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
            {
//                sWeekJ = "(木)";
                sWeekE = "(Thu)";
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Friday)
            {
//                sWeekJ = "(金y)";
                sWeekE = "(Fri)";
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
            {
//                sWeekJ = "(土)";
                sWeekE = "(Sat)";
            }
            else
            {
//                sWeekJ = "(日)";
                sWeekE = "(Sun)";
            }

            try
            {
                if (FormatType > 11)
                {
                    FormatType = 0;
                }

                switch (FormatType)
                {

                    case 0: return DateTime.Now.ToString("【 yyyy年MM月dd日(ddd) 】");
                    case 1: return DateTime.Now.ToString("【 yyyy年MM月dd日 】");
                    case 2: return DateTime.Now.ToString("【 yyyy/MM/dd") + sWeekE + " 】";
                    case 3: return DateTime.Now.ToString("【 yyyy/MM/dd 】");
                    case 4: return DateTime.Now.ToString("【 MM月dd日(ddd) 】");
                    case 5: return DateTime.Now.ToString("【 MM月dd日 】");
                    case 6: return DateTime.Now.ToString("【 MM/dd") + sWeekE + " 】";
                    case 7: return DateTime.Now.ToString("【 MM/dd 】");
                    case 8: return DateTime.Now.ToString("【 yyyy年MM月dd日(ddd)  HH:mm 】");
                    case 9: return DateTime.Now.ToString("【 yyyy年MM月dd日  HH:mm 】");
                    case 10: return DateTime.Now.ToString("【 yyyy/MM/dd HH:mm  】");
                    case 11: return DateTime.Now.ToString("【 MM/dd HH:mm 】");
                    default: return DateTime.Now.ToString("【 yyyy年MM月dd日(ddd) 】");
                }
            }
            catch
            {
                return "";
            }

        }

    }
}




