using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{

    //******************************************************************************************
    //
    //  このソースファイルには「メールビューアー」に関連するクラス, 各種パラメータや、
    //  各種定義が実装されています
    //
    //******************************************************************************************

    /// <summary>
    /// メールビューアー操作パラメータ
    /// </summary>
    public class MailViewerOperationInfo
    {
        /// <summary>
        /// ビューアー表示モード 0:Default
        /// </summary>
        static public int ViewMode_Default = 0;

        /// <summary>
        /// ビューアー表示モード 1:ReadOnly
        /// </summary>
        static public int ViewMode_ReadOnly = 1;


        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MailViewerOperationInfo()
        {


        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 表示モード 0:Default,  1:ReadOnlyモード....
        /// 0:Default の場合はメールデータの表示、編集、送信等全ての機能を有効にしてください
        /// </summary>
        public int ViewerMode = 0;

        /// <summary>
        /// 処理ステータス(詳細なステータス)
        /// ※ メール送信成功、プレビュー成功、 プレビュー画面でキャンセル･･･等 
        /// </summary>
        public int Status = 0;

        /// <summary>
        /// 処理メッセージ(エラーメッセージ等と連動するメッセージ 例外をthrowできない場合等、適宜使用してください)
        /// </summary>
        public string message = "";

        #endregion


    }


    /// <summary>
    /// メールデータソース
    /// </summary>
    /// <remarks>
    /// 送信対象のメールデータリストと各種操作を提供するクラスです。
    /// 送信対象のメールデータリストへの操作(初期化、メールデータ追加、削除...等)はこのクラスへ
    /// 実装していくと良いかと思います。
    /// <br></br>
    /// <br></br>
    /// 『何でこのようなクラスが必要なの？』
    /// <br></br>
    /// <br></br>
    /// メールデータソースがDataSetでなくなった場合や、
    /// メールデータソースに対して編集処理が必要になる場合は
    /// このクラス内でコンバータや編集メソッドを準備して吸収するようにします
    /// どのような状態を想定しているかというと、今回は NsMacroConverter --> Preview --> MailSender
    /// の流れでDataSetを使用することになっていますが、
    /// NsMacroConverterは他システムでは専用に作り直すので、必ずしもDataSetが使用できるとは限りません。
    /// このような場合に例えば、xxMacroConverter で生成されたメールデータソースがXMLであれば、
    /// そのXMLをこのクラスで受け取って内部でDataSetへ変換すれば Preview --> MailSender 等の 
    /// 後続処理に変更を加える必要がなくなります。
    /// また、逆に本メールサービスで生成したメールデータを他のサービス(システム)へ投げるようなことが
    /// あればこのクラス内で使用されている MailDataList を、他サービスのインタフェース仕様に合わせて
    /// 変換するメソッドを準備することで本メールサービス内のデータ定義は変えずに連携できると思います。
    /// (もっといろいろあるのですが、続きは後日.... 2006.10.04 R.Sokei)
    /// </remarks>
    public class MailSourceData
    {
        // メールデータソースがDataSetでなくなった場合や、
        // メールデータソースに対して編集処理が必要になる場合は
        // このクラス内でコンバータや編集メソッドを準備して吸収するようにします
        //
        // どのような状態を想定しているかというと、今回は NsMacroConverter --> Preview --> MailSender
        // の流れでDataSetを使用することになっていますが、
        // NsMacroConverterは他システムでは専用に作り直すので、必ずしもDataSetが使用できるとは限りません。
        // このような場合に例えば、xxMacroConverter で生成されたメールデータソースがXMLであれば、
        // そのXMLをこのクラスで受け取って内部でDataSetへ変換すれば Preview --> MailSender 等の 
        // 後続処理に変更を加える必要がなくなります。
        // また、逆に本メールサービスで生成したメールデータを他のサービス(システム)へ投げるようなことが
        // あればこのクラス内で使用されている MailDataList を、他サービスのインタフェース仕様に合わせて
        // 変換するメソッドを準備することで本メールサービス内のデータ定義は変えずに連携できると思います。
        // (続きは後日.... 2006.10.04 R.Sokei)
        //

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MailSourceData()
        {



        }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mailSource">メールデータソース</param>
        public MailSourceData(object mailSource)
        {
            if (mailSource != null)
            {
                if (mailSource is DataSet)
                {
                    // ここでmailSourceがメールデータを表しているかどうかのチェックを
                    // した方が良い

                    this.MailDataList = (DataSet)mailSource;

                }
                else if (mailSource is string)
                {
                    // ストリング型のテキストを表示させるために DataSet内のメール本文にセットする
                    //                    MailDataList = (DataSet)mailSource;

                 
                }
            }
        }

        #endregion


        #region static メンバ

        /// <summary>
        /// メールデータ テーブル名称
        /// </summary>
        static public string TABLE_MailDataList = "TABLE_MailDataList";


        /// <summary>
        /// 作成日時
        /// </summary>
        static public string MEMBER_MailData_CreateDateTime = "CreateDateTime";
        /// <summary>
        /// 更新日時
        /// </summary>
        static public string MEMBER_MailData_UpdateDateTime = "UpdateDateTime";
        /// <summary>
        /// 企業コード
        /// </summary>
        static public string MEMBER_MailData_EnterpriseCode = "EnterpriseCode";
        /// <summary>
        /// GUID
        /// </summary>
        static public string MEMBER_MailData_FileHeaderGuid = "FileHeaderGuid";
        /// <summary>
        /// 更新従業員コード
        /// </summary>
        static public string MEMBER_MailData_UpdEmployeeCode = "UpdEmployeeCode";
        /// <summary>
        /// 更新アセンブリID1
        /// </summary>
        static public string MEMBER_MailData_UpdAssemblyId1 = "UpdAssemblyId1";
        /// <summary>
        /// 更新アセンブリID2
        /// </summary>
        static public string MEMBER_MailData_UpdAssemblyId2 = "UpdAssemblyId2";
        /// <summary>
        /// 論理削除区分
        /// </summary>
        static public string MEMBER_MailData_LogicalDeleteCode = "LogicalDeleteCode";
        /// <summary>
        /// 送信拠点コード
        /// </summary>
        static public string MEMBER_MailData_SendSectionCode = "SendSectionCode";
        /// <summary>
        /// メール管理連番
        /// </summary>
        static public string MEMBER_MailData_MailManagementConsNo = "MailManagementConsNo";
        /// <summary>
        /// メールステータス
        /// </summary>
        static public string MEMBER_MailData_MailStatus = "MailStatus";
        /// <summary>
        /// 送信日時
        /// </summary>
        static public string MEMBER_MailData_SendDateTime = "SendDateTime";
        /// <summary>
        /// 得意先コード
        /// </summary>
        static public string MEMBER_MailData_CustomerCode = "CustomerCode";
        /// <summary>
        /// 名称
        /// </summary>
        static public string MEMBER_MailData_Name = "Name";
        /// <summary>
        /// 名称2
        /// </summary>
        static public string MEMBER_MailData_Name2 = "Name2";
        /// <summary>
        /// 名称1+2(実際のマスタデータには存在しません)
        /// </summary>
        static public string MEMBER_MailData_FullName = "CustomerFullName";
        /// <summary>
        /// 敬称
        /// </summary>
        static public string MEMBER_MailData_HonorificTitle = "HonorificTitle";
        /// <summary>
        /// カナ
        /// </summary>
        static public string MEMBER_MailData_Kana = "Kana";
        /// <summary>
        /// メールアドレス
        /// </summary>
        static public string MEMBER_MailData_MailAddress = "MailAddress";
        /// <summary>
        /// メールアドレス種別コード
        /// </summary>
        static public string MEMBER_MailData_MailAddrKindCode1 = "MailAddrKindCode1";
        /// <summary>
        /// メールアドレス種別名称
        /// </summary>
        static public string MEMBER_MailData_MailAddrKindName1 = "MailAddrKindName1";
        /// <summary>
        /// メール送信区分コード
        /// </summary>
        static public string MEMBER_MailData_MailSendCode1 = "MailSendCode1";
        /// <summary>
        /// メール形式
        /// </summary>
        static public string MEMBER_MailData_MailFormal = "MailFormal";
        /// <summary>
        /// 抽出アセンブリ区分
        /// </summary>
        static public string MEMBER_MailData_ExtraAssemblyDivide = "ExtraAssemblyDivide";
        /// <summary>
        /// メール文書番号
        /// </summary>
        static public string MEMBER_MailData_MailDocumentNo = "MailDocumentNo";
        /// <summary>
        /// メール文書区分
        /// </summary>
        static public string MEMBER_MailData_MailDocCode = "MailDocCode";

        /// <summary>
        /// メールタイトル
        /// </summary>
        static public string MEMBER_MailData_MailTitle = "MailTitle";
        /// <summary>
        /// メール文書
        /// </summary>
        static public string MEMBER_MailData_MailDocumentCnts = "MailDocumentCnts";

        /// <summary>
        /// メール管理Guid
        /// </summary>
        static public string MEMBER_MailData_MailMngGuid = "MailMngGuid";

        /// <summary>
        /// CC
        /// </summary>
        static public string MEMBER_MailData_CarbonCopy = "CarbonCopy";

        /// <summary>
        /// 添付ファイル
        /// </summary>
        static public string MEMBER_MailData_AttachFile = "AttachFile";

        #endregion


        #region プロパティ
        /// <summary>
        /// メールデータソース
        /// </summary>
        public DataSet MailDataList = null;


        private bool _EnableCarInfo = true;
        #endregion



        #region publicメソッド

        /// <summary>
        /// 現在のデータソースの指定された位置のデータをMailBackupクラスの形式で取得します
        /// </summary>
        /// <param name="pos">取得位置</param>
        /// <returns>取得データ</returns>
        public MailBackup GetMailBackupData(int pos)
        {
            MailBackup retObj = null;
            if (this.MailDataList != null)
            {

                if (this.MailDataList.Tables.Contains(TABLE_MailDataList))
                {

                    if(this.MailDataList.Tables[TABLE_MailDataList].Rows.Count >= pos)
                    {
                        // 指定された位置のデータを MailBackupインスタンスへ転記 
                        DataRow dr = this.MailDataList.Tables[TABLE_MailDataList].Rows[pos];
                        retObj = new MailBackup();

                        //  作成日時
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_CreateDateTime))
                        {
                            if ((dr[MailSourceData.MEMBER_MailData_CreateDateTime] != null) && ((dr[MailSourceData.MEMBER_MailData_CreateDateTime] != DBNull.Value)))
                            {
                                retObj.CreateDateTime = (DateTime)dr[MailSourceData.MEMBER_MailData_CreateDateTime];
                            }
                        }

                        // 更新日時
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_UpdateDateTime))
                        {
                            if ((dr[MailSourceData.MEMBER_MailData_UpdateDateTime] != null) && (dr[MailSourceData.MEMBER_MailData_UpdateDateTime] != DBNull.Value))
                            {
                                retObj.UpdateDateTime = (DateTime)dr[MailSourceData.MEMBER_MailData_UpdateDateTime];
                            }
                        }
                        // 企業コード
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_EnterpriseCode))
                        {
                            retObj.EnterpriseCode = (string)dr[MailSourceData.MEMBER_MailData_EnterpriseCode];
                        }
                        // GUID
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_FileHeaderGuid))
                        {
                            if ((dr[MailSourceData.MEMBER_MailData_FileHeaderGuid] != null) && ((dr[MailSourceData.MEMBER_MailData_FileHeaderGuid] != DBNull.Value)))
                            {
                                retObj.FileHeaderGuid = (Guid)dr[MailSourceData.MEMBER_MailData_FileHeaderGuid];
                            }
                        }
                        // 更新従業員コード
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_UpdEmployeeCode))
                        {
                            retObj.UpdEmployeeCode = (string)dr[MailSourceData.MEMBER_MailData_UpdEmployeeCode];
                        }
                        // 更新アセンブリID1
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_UpdAssemblyId1))
                        {
                            retObj.UpdAssemblyId1 = (string)dr[MailSourceData.MEMBER_MailData_UpdAssemblyId1];
                        }
                        // 更新アセンブリID2
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_UpdAssemblyId2))
                        {
                            retObj.UpdAssemblyId2 = (string)dr[MailSourceData.MEMBER_MailData_UpdAssemblyId2];
                        }
                        // 論理削除区分
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_LogicalDeleteCode))
                        {
                            retObj.LogicalDeleteCode = (int)dr[MailSourceData.MEMBER_MailData_LogicalDeleteCode];
                        }
                        // 送信拠点コード
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_SendSectionCode))
                        {
                            retObj.SendSectionCode = (string)dr[MailSourceData.MEMBER_MailData_SendSectionCode];
                        }
                        // メール管理連番
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailManagementConsNo))
                        {
                            retObj.MailManagementConsNo = (int)dr[MailSourceData.MEMBER_MailData_MailManagementConsNo];
                        }
                        // メールステータス
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailStatus))
                        {
                            retObj.MailStatus = (int)dr[MailSourceData.MEMBER_MailData_MailStatus];
                        }
                        // 送信日時
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_SendDateTime))
                        {
                            retObj.SendDateTime = (long)dr[MailSourceData.MEMBER_MailData_SendDateTime];
                        }
                        // 得意先コード
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_CustomerCode))
                        {
                            retObj.CustomerCode = (int)dr[MailSourceData.MEMBER_MailData_CustomerCode];
                        }
                        // 名称
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_Name))
                        {
                            retObj.Name = (string)dr[MailSourceData.MEMBER_MailData_Name];
                        }
                        // 名称2
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_Name2))
                        {
                            retObj.Name2 = (string)dr[MailSourceData.MEMBER_MailData_Name2];
                        }
                        // 敬称
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_HonorificTitle))
                        {
                            retObj.HonorificTitle = (string)dr[MailSourceData.MEMBER_MailData_HonorificTitle];
                        }
                        // カナ
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_Kana))
                        {
                            retObj.Kana = (string)dr[MailSourceData.MEMBER_MailData_Kana];
                        }
                        // メールアドレス
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailAddress))
                        {
                            retObj.MailAddress = (string)dr[MailSourceData.MEMBER_MailData_MailAddress];
                        }

                        // メールアドレス種別コード
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailAddrKindCode1))
                        {
                            retObj.MailAddrKindCode1 = (int)dr[MailSourceData.MEMBER_MailData_MailAddrKindCode1];
                        }
                        // メールアドレス種別名称
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailAddrKindName1))
                        {
                            retObj.MailAddrKindName1 = (string)dr[MailSourceData.MEMBER_MailData_MailAddrKindName1];
                        }
                        // メール送信区分コード
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailSendCode1))
                        {
                            retObj.MailSendCode1 = (int)dr[MailSourceData.MEMBER_MailData_MailSendCode1];
                        }
                        // メール形式
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailFormal))
                        {
                            retObj.MailFormal = (int)dr[MailSourceData.MEMBER_MailData_MailFormal];
                        }
                        // 抽出アセンブリ区分
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_ExtraAssemblyDivide))
                        {
                            retObj.ExtraAssemblyDivide = (string)dr[MailSourceData.MEMBER_MailData_ExtraAssemblyDivide];
                        }
                        // メール文書番号
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailDocumentNo))
                        {
                            retObj.MailDocumentNo = (int)dr[MailSourceData.MEMBER_MailData_MailDocumentNo];
                        }
                        // メール文書区分
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailDocCode))
                        {
                            retObj.MailDocCode = (int)dr[MailSourceData.MEMBER_MailData_MailDocCode];
                        }
                        // メールタイトル
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailTitle))
                        {
                            retObj.MailTitle = (string)dr[MailSourceData.MEMBER_MailData_MailTitle];
                        }
                        // メール文書
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailDocumentCnts))
                        {
                            retObj.MailDocumentCnts = (string)dr[MailSourceData.MEMBER_MailData_MailDocumentCnts];
                        }
                        // メール管理Guid
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailMngGuid))
                        {
                            if ((dr[MailSourceData.MEMBER_MailData_MailMngGuid] != null) && ((dr[MailSourceData.MEMBER_MailData_MailMngGuid] != DBNull.Value)))
                            {
                                retObj.MailMngGuid = (Guid)dr[MailSourceData.MEMBER_MailData_MailMngGuid];
                            }
                        }
                        // CC
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_CarbonCopy))
                        {
                            retObj.CarbonCopy = (string)dr[MailSourceData.MEMBER_MailData_CarbonCopy];
                        }
                        // 添付ファイル
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_AttachFile))
                        {
                            retObj.AttachFile = (string)dr[MailSourceData.MEMBER_MailData_AttachFile];
                        }
                    }
                }

            }

            return retObj;
        }


        /// <summary>
        /// データソースに新しいメールデータを追加します
        /// </summary>
        /// <returns></returns>
        public bool AddNewMailData()
        {

            if (this.MailDataList != null)
            {

                if (this.MailDataList.Tables.Contains(TABLE_MailDataList))
                {

                    DataRow dr = this.MailDataList.Tables[TABLE_MailDataList].NewRow();


                    this.MailDataList.Tables[TABLE_MailDataList].Rows.Add(dr);

                }

            }

            return true;
        }

        /// <summary>
        /// データソースに新しいメールデータを追加します
        /// </summary>
        /// <param name="mailBackup">メールバックアップデータ</param>
        /// <returns>処理結果 true:成功, false:失敗</returns>
        public bool AddNewMailData(MailBackup mailBackup)
        {

            if (this.MailDataList == null)
            {
                this.MailDataList = CreateNewMailDataList();
            }

            if (this.MailDataList.Tables.Contains(TABLE_MailDataList))
            {

                DataRow dr = this.MailDataList.Tables[TABLE_MailDataList].NewRow();

                if (mailBackup != null)
                {
                    dr[MEMBER_MailData_CreateDateTime] = mailBackup.CreateDateTime;
                    dr[MEMBER_MailData_UpdateDateTime] = mailBackup.UpdateDateTime;
                    dr[MEMBER_MailData_EnterpriseCode] = mailBackup.EnterpriseCode;
                    dr[MEMBER_MailData_FileHeaderGuid] = mailBackup.FileHeaderGuid;
                    dr[MEMBER_MailData_UpdEmployeeCode] = mailBackup.UpdEmployeeCode;
                    dr[MEMBER_MailData_UpdAssemblyId1] = mailBackup.UpdAssemblyId1;
                    dr[MEMBER_MailData_UpdAssemblyId2] = mailBackup.UpdAssemblyId2;
                    dr[MEMBER_MailData_LogicalDeleteCode] = mailBackup.LogicalDeleteCode;
                    dr[MEMBER_MailData_SendSectionCode] = mailBackup.SendSectionCode;
                    dr[MEMBER_MailData_MailManagementConsNo] = mailBackup.MailManagementConsNo;
                    dr[MEMBER_MailData_MailStatus] = mailBackup.MailStatus;
                    dr[MEMBER_MailData_SendDateTime] = mailBackup.SendDateTime;
                    dr[MEMBER_MailData_CustomerCode] = mailBackup.CustomerCode;
                    dr[MEMBER_MailData_Name] = mailBackup.Name;
                    dr[MEMBER_MailData_Name2] = mailBackup.Name2;

                    dr[MEMBER_MailData_FullName] = mailBackup.Name + " " + mailBackup.Name2;

                    dr[MEMBER_MailData_HonorificTitle] = mailBackup.HonorificTitle;
                    dr[MEMBER_MailData_Kana] = mailBackup.Kana;
                    dr[MEMBER_MailData_MailAddress] = mailBackup.MailAddress;
                    dr[MEMBER_MailData_MailAddrKindCode1] = mailBackup.MailAddrKindCode1;
                    dr[MEMBER_MailData_MailAddrKindName1] = mailBackup.MailAddrKindName1;
                    dr[MEMBER_MailData_MailSendCode1] = mailBackup.MailSendCode1;
                    dr[MEMBER_MailData_MailFormal] = mailBackup.MailFormal;
                    dr[MEMBER_MailData_ExtraAssemblyDivide] = mailBackup.ExtraAssemblyDivide;
                    dr[MEMBER_MailData_MailDocumentNo] = mailBackup.MailDocumentNo;
                    dr[MEMBER_MailData_MailDocCode] = mailBackup.MailDocCode;
                    dr[MEMBER_MailData_MailTitle] = mailBackup.MailTitle;
                    dr[MEMBER_MailData_MailDocumentCnts] = mailBackup.MailDocumentCnts;
                    dr[MEMBER_MailData_MailMngGuid] = mailBackup.MailMngGuid;
                    dr[MEMBER_MailData_CarbonCopy] = mailBackup.CarbonCopy;
                    dr[MEMBER_MailData_AttachFile] = mailBackup.AttachFile;

                }

                this.MailDataList.Tables[TABLE_MailDataList].Rows.Add(dr);
            }


            return true;
        }



        /// <summary>
        /// データソースの指定された位置に新しいメールデータを挿入します
        /// </summary>
        /// <param name="mailBackup">メールバックアップデータ</param>
        /// <param name="pos">挿入位置</param>
        /// <returns>処理結果 true:成功, false:失敗</returns>
        public bool InsertNewMailData(MailBackup mailBackup, int pos)
        {

            if (this.MailDataList == null)
            {
                this.MailDataList = CreateNewMailDataList();
            }

            if (this.MailDataList.Tables.Contains(TABLE_MailDataList))
            {

                DataRow dr = this.MailDataList.Tables[TABLE_MailDataList].NewRow();

                if (mailBackup != null)
                {
                    dr[MEMBER_MailData_CreateDateTime] = mailBackup.CreateDateTime;
                    dr[MEMBER_MailData_UpdateDateTime] = mailBackup.UpdateDateTime;
                    dr[MEMBER_MailData_EnterpriseCode] = mailBackup.EnterpriseCode;
                    dr[MEMBER_MailData_FileHeaderGuid] = mailBackup.FileHeaderGuid;
                    dr[MEMBER_MailData_UpdEmployeeCode] = mailBackup.UpdEmployeeCode;
                    dr[MEMBER_MailData_UpdAssemblyId1] = mailBackup.UpdAssemblyId1;
                    dr[MEMBER_MailData_UpdAssemblyId2] = mailBackup.UpdAssemblyId2;
                    dr[MEMBER_MailData_LogicalDeleteCode] = mailBackup.LogicalDeleteCode;
                    dr[MEMBER_MailData_SendSectionCode] = mailBackup.SendSectionCode;
                    dr[MEMBER_MailData_MailManagementConsNo] = mailBackup.MailManagementConsNo;
                    dr[MEMBER_MailData_MailStatus] = mailBackup.MailStatus;
                    dr[MEMBER_MailData_SendDateTime] = mailBackup.SendDateTime;
                    dr[MEMBER_MailData_CustomerCode] = mailBackup.CustomerCode;
                    dr[MEMBER_MailData_Name] = mailBackup.Name;
                    dr[MEMBER_MailData_Name2] = mailBackup.Name2;

                    dr[MEMBER_MailData_FullName] = mailBackup.Name + " " + mailBackup.Name2;

                    dr[MEMBER_MailData_HonorificTitle] = mailBackup.HonorificTitle;
                    dr[MEMBER_MailData_Kana] = mailBackup.Kana;
                    dr[MEMBER_MailData_MailAddress] = mailBackup.MailAddress;
                    dr[MEMBER_MailData_MailAddrKindCode1] = mailBackup.MailAddrKindCode1;
                    dr[MEMBER_MailData_MailAddrKindName1] = mailBackup.MailAddrKindName1;
                    dr[MEMBER_MailData_MailSendCode1] = mailBackup.MailSendCode1;
                    dr[MEMBER_MailData_MailFormal] = mailBackup.MailFormal;
                    dr[MEMBER_MailData_ExtraAssemblyDivide] = mailBackup.ExtraAssemblyDivide;
                    dr[MEMBER_MailData_MailDocumentNo] = mailBackup.MailDocumentNo;
                    dr[MEMBER_MailData_MailDocCode] = mailBackup.MailDocCode;
                    dr[MEMBER_MailData_MailTitle] = mailBackup.MailTitle;
                    dr[MEMBER_MailData_MailDocumentCnts] = mailBackup.MailDocumentCnts;
                    dr[MEMBER_MailData_MailMngGuid] = mailBackup.MailMngGuid;
                    dr[MEMBER_MailData_CarbonCopy] = mailBackup.CarbonCopy;
                    dr[MEMBER_MailData_AttachFile] = mailBackup.AttachFile;

                }

                this.MailDataList.Tables[TABLE_MailDataList].Rows.InsertAt(dr, pos);
            }


            return true;
        
        
        }


        /// <summary>
        /// データソースの指定された位置に新しいメールデータを更新します
        /// </summary>
        /// <param name="mailBackup">メールバックアップデータ</param>
        /// <param name="pos">挿入位置</param>
        /// <returns>処理結果 true:成功, false:失敗</returns>
        public bool UpdateNewMailData(MailBackup mailBackup, int pos)
        {

            if (this.MailDataList == null)
            {
                this.MailDataList = CreateNewMailDataList();
            }

            if (this.MailDataList.Tables.Contains(TABLE_MailDataList))
            {
                if (pos < this.MailDataList.Tables[TABLE_MailDataList].Rows.Count)
                {
                    DataRow dr = this.MailDataList.Tables[TABLE_MailDataList].Rows[pos];

                    if (mailBackup != null)
                    {
                        dr[MEMBER_MailData_CreateDateTime] = mailBackup.CreateDateTime;
                        dr[MEMBER_MailData_UpdateDateTime] = mailBackup.UpdateDateTime;
                        dr[MEMBER_MailData_EnterpriseCode] = mailBackup.EnterpriseCode;
                        dr[MEMBER_MailData_FileHeaderGuid] = mailBackup.FileHeaderGuid;
                        dr[MEMBER_MailData_UpdEmployeeCode] = mailBackup.UpdEmployeeCode;
                        dr[MEMBER_MailData_UpdAssemblyId1] = mailBackup.UpdAssemblyId1;
                        dr[MEMBER_MailData_UpdAssemblyId2] = mailBackup.UpdAssemblyId2;
                        dr[MEMBER_MailData_LogicalDeleteCode] = mailBackup.LogicalDeleteCode;
                        dr[MEMBER_MailData_SendSectionCode] = mailBackup.SendSectionCode;
                        dr[MEMBER_MailData_MailManagementConsNo] = mailBackup.MailManagementConsNo;
                        dr[MEMBER_MailData_MailStatus] = mailBackup.MailStatus;
                        dr[MEMBER_MailData_SendDateTime] = mailBackup.SendDateTime;
                        dr[MEMBER_MailData_CustomerCode] = mailBackup.CustomerCode;
                        dr[MEMBER_MailData_Name] = mailBackup.Name;
                        dr[MEMBER_MailData_Name2] = mailBackup.Name2;

                        dr[MEMBER_MailData_FullName] = mailBackup.Name + " " + mailBackup.Name2;

                        dr[MEMBER_MailData_HonorificTitle] = mailBackup.HonorificTitle;
                        dr[MEMBER_MailData_Kana] = mailBackup.Kana;
                        dr[MEMBER_MailData_MailAddress] = mailBackup.MailAddress;
                        dr[MEMBER_MailData_MailAddrKindCode1] = mailBackup.MailAddrKindCode1;
                        dr[MEMBER_MailData_MailAddrKindName1] = mailBackup.MailAddrKindName1;
                        dr[MEMBER_MailData_MailSendCode1] = mailBackup.MailSendCode1;
                        dr[MEMBER_MailData_MailFormal] = mailBackup.MailFormal;
                        dr[MEMBER_MailData_ExtraAssemblyDivide] = mailBackup.ExtraAssemblyDivide;
                        dr[MEMBER_MailData_MailDocumentNo] = mailBackup.MailDocumentNo;
                        dr[MEMBER_MailData_MailDocCode] = mailBackup.MailDocCode;
                        dr[MEMBER_MailData_MailTitle] = mailBackup.MailTitle;
                        dr[MEMBER_MailData_MailDocumentCnts] = mailBackup.MailDocumentCnts;
                        dr[MEMBER_MailData_MailMngGuid] = mailBackup.MailMngGuid;
                        dr[MEMBER_MailData_CarbonCopy] = mailBackup.CarbonCopy;
                        dr[MEMBER_MailData_AttachFile] = mailBackup.AttachFile;
                    }
                }

            }


            return true;
        }


        #region test
        /// <summary>
        /// データソースにTest用のメールデータを追加します
        /// </summary>
        /// <returns></returns>
        public bool AddTestMailData(int no)
        {

            MailBackup mailBackup = new MailBackup();

            //mailBackup.CustomerCode = 1;
            //mailBackup.Name = "加藤工務店";
            //mailBackup.Name2 = "徳山営業所";
            //mailBackup.HonorificTitle = "様";
            //mailBackup.MakerName = "トヨタ";
            //mailBackup.ModelName = "カローラ";
            //mailBackup.NumberPlate1Code = 9120;
            //mailBackup.NumberPlate1Name = "湘南";
            //mailBackup.NumberPlate2 = "500";
            //mailBackup.NumberPlate3 = "な";
            //mailBackup.NumberPlate4 = 7777;
            //mailBackup.MailTitle = "車検のご案内";
            //mailBackup.MailAddress = "misaebon@itxtn.co.jp";
            //mailBackup.MailAddrKindName1 = "自宅";
            //mailBackup.MailDocumentCnts = "加藤工務店 徳山営業所 様 \n車検の時期が近づいています \n\n印鑑と通帳をご持参の上、車検の見積にいらっしゃい。 \n\n ";
            //mailBackup.MailDocumentNo = 100;
            //AddNewMailData(mailBackup);
            //mailBackup = new MailBackup();
            //mailBackup.CustomerCode = 2540;
            //mailBackup.Name = "中村(仁)";
            //mailBackup.Name2 = "Ⅲ";
            //mailBackup.HonorificTitle = "殿";
            //mailBackup.MakerName = "ニッサン";
            //mailBackup.ModelName = "ブルーバード";
            //mailBackup.NumberPlate1Code = 9120;
            //mailBackup.NumberPlate1Name = "竹島";
            //mailBackup.NumberPlate2 = "330";
            //mailBackup.NumberPlate3 = "の";
            //mailBackup.NumberPlate4 = 941;
            //mailBackup.MailTitle = "車検に来んしゃい！！";
            //mailBackup.MailAddress = "xxx_xxxxxx_xxxx@docomo.ne.jp";
            //mailBackup.MailAddrKindCode1 = 2;
            //mailBackup.MailAddrKindName1 = "携帯端末";
            //mailBackup.MailDocumentCnts = "中村(仁) Ⅲ殿 \n車検の時期が過ぎてます(って言うか切れてます) \n\n印鑑と通帳をご持参の上、車検の見積にいらっしゃい(車に乗ってきてはいけません) \n\n 今なら特典が盛りだくさん！ \n なんと今回車検を受けると特選中古車を特別割増価格でご提供！！";
            //mailBackup.MailDocumentNo = 100100;
            //mailBackup.MailDocCode = 1;
            //AddNewMailData(mailBackup);

            return true;
        }

        #endregion
    
        /// <summary>
        /// 新しいメールデータソース(DataSet)を作成します
        /// </summary>
        /// <returns></returns>
        public DataSet CreateNewMailDataList()
        {

            DataSet ds = new DataSet("MailDataList");

            DataTable dt;

            // DataSetに新規テーブルを追加する
            dt = ds.Tables.Add("TABLE_MailDataList");

            // キーは設定しない
            //            DataColumn[] dc = new DataColumn[1];
            // DataSetのテーブルにフィールドを追加して主キーを設定する
            //            dc[0] = dt.Columns.Add("社員番号"
            //                , Type.GetType("System.String"));
            //            dt.PrimaryKey = dc;

            // 列定義
            dt.Columns.Add(MEMBER_MailData_CreateDateTime, Type.GetType("System.DateTime"));
            dt.Columns.Add(MEMBER_MailData_UpdateDateTime, Type.GetType("System.DateTime"));
            dt.Columns.Add(MEMBER_MailData_EnterpriseCode, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_FileHeaderGuid, Type.GetType("System.Guid"));
            dt.Columns.Add(MEMBER_MailData_UpdEmployeeCode, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_UpdAssemblyId1, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_UpdAssemblyId2, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_LogicalDeleteCode, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_SendSectionCode, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_MailManagementConsNo, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_MailStatus, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_SendDateTime, Type.GetType("System.Int64"));
            dt.Columns.Add(MEMBER_MailData_CustomerCode, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_Name, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_Name2, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_FullName, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_HonorificTitle, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_Kana, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_MailAddress, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_MailAddrKindCode1, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_MailAddrKindName1, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_MailSendCode1, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_MailFormal, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_ExtraAssemblyDivide, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_MailDocumentNo, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_MailDocCode, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_MailTitle, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_MailDocumentCnts, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_MailMngGuid, Type.GetType("System.Guid"));
            dt.Columns.Add(MEMBER_MailData_CarbonCopy, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_AttachFile, Type.GetType("System.String"));

            // 列名定義
            dt.Columns[MEMBER_MailData_CreateDateTime].Caption = "作成日時";
            dt.Columns[MEMBER_MailData_UpdateDateTime].Caption = "更新日時";
            dt.Columns[MEMBER_MailData_EnterpriseCode].Caption = "企業コード";
            dt.Columns[MEMBER_MailData_FileHeaderGuid].Caption = "GUID";
            dt.Columns[MEMBER_MailData_UpdEmployeeCode].Caption = "更新従業員コード";
            dt.Columns[MEMBER_MailData_UpdAssemblyId1].Caption = "更新アセンブリID1";
            dt.Columns[MEMBER_MailData_UpdAssemblyId2].Caption = "更新アセンブリID2";
            dt.Columns[MEMBER_MailData_LogicalDeleteCode].Caption = "論理削除区分";
            dt.Columns[MEMBER_MailData_SendSectionCode].Caption = "送信拠点コード";
            dt.Columns[MEMBER_MailData_MailManagementConsNo].Caption = "メール管理連番";
            dt.Columns[MEMBER_MailData_MailStatus].Caption = "メールステータス";
            dt.Columns[MEMBER_MailData_SendDateTime].Caption = "送信日時";
            dt.Columns[MEMBER_MailData_CustomerCode].Caption = "得意先コード";
            dt.Columns[MEMBER_MailData_Name].Caption = "得意先名称";
            dt.Columns[MEMBER_MailData_Name2].Caption = "得意先名称2";
            dt.Columns[MEMBER_MailData_FullName].Caption = "得意先名称";
            dt.Columns[MEMBER_MailData_HonorificTitle].Caption = "敬称";
            dt.Columns[MEMBER_MailData_Kana].Caption = "得意先名称カナ";
            dt.Columns[MEMBER_MailData_MailAddress].Caption = "メールアドレス";
            dt.Columns[MEMBER_MailData_MailAddrKindCode1].Caption = "メールアドレス種別コード";
            dt.Columns[MEMBER_MailData_MailAddrKindName1].Caption = "メールアドレス種別名称";
            dt.Columns[MEMBER_MailData_MailSendCode1].Caption = "メール送信区分コード";
            dt.Columns[MEMBER_MailData_MailFormal].Caption = "メール形式";
            dt.Columns[MEMBER_MailData_ExtraAssemblyDivide].Caption = "抽出アセンブリ区分";
            dt.Columns[MEMBER_MailData_MailDocumentNo].Caption = "メール文書番号";
            dt.Columns[MEMBER_MailData_MailDocCode].Caption = "メール文書区分";
            dt.Columns[MEMBER_MailData_MailTitle].Caption = "メールタイトル";
            dt.Columns[MEMBER_MailData_MailDocumentCnts].Caption = "メール文書";
            dt.Columns[MEMBER_MailData_MailDocumentCnts].Caption = "メール管理Guid";
            dt.Columns[MEMBER_MailData_CarbonCopy].Caption = "CC";
            dt.Columns[MEMBER_MailData_AttachFile].Caption = "添付ファイル";

            // 列 Default Value 定義
            dt.Columns[MEMBER_MailData_CreateDateTime].DefaultValue = DBNull.Value;
            dt.Columns[MEMBER_MailData_UpdateDateTime].DefaultValue = DBNull.Value;
            dt.Columns[MEMBER_MailData_EnterpriseCode].DefaultValue = "";
            dt.Columns[MEMBER_MailData_FileHeaderGuid].DefaultValue = DBNull.Value;
            dt.Columns[MEMBER_MailData_UpdEmployeeCode].DefaultValue = "";
            dt.Columns[MEMBER_MailData_UpdAssemblyId1].DefaultValue = "";
            dt.Columns[MEMBER_MailData_UpdAssemblyId2].DefaultValue = "";
            dt.Columns[MEMBER_MailData_LogicalDeleteCode].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_SendSectionCode].DefaultValue = "";
            dt.Columns[MEMBER_MailData_MailManagementConsNo].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_MailStatus].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_SendDateTime].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_CustomerCode].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_Name].DefaultValue = "";
            dt.Columns[MEMBER_MailData_Name2].DefaultValue = "";
            dt.Columns[MEMBER_MailData_FullName].DefaultValue = "";
            dt.Columns[MEMBER_MailData_HonorificTitle].DefaultValue = "";
            dt.Columns[MEMBER_MailData_Kana].DefaultValue = "";
            dt.Columns[MEMBER_MailData_MailAddress].DefaultValue = "";
            dt.Columns[MEMBER_MailData_MailAddrKindCode1].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_MailAddrKindName1].DefaultValue = "";
            dt.Columns[MEMBER_MailData_MailSendCode1].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_MailFormal].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_ExtraAssemblyDivide].DefaultValue = "";
            dt.Columns[MEMBER_MailData_MailDocumentNo].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_MailDocCode].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_MailTitle].DefaultValue = "";
            dt.Columns[MEMBER_MailData_MailDocumentCnts].DefaultValue = "";
            dt.Columns[MEMBER_MailData_MailMngGuid].DefaultValue = DBNull.Value;
            dt.Columns[MEMBER_MailData_CarbonCopy].DefaultValue = "";
            dt.Columns[MEMBER_MailData_AttachFile].DefaultValue = "";

            return ds;

        }

        /// <summary>
        /// 車両情報有効区分判定
        /// </summary>
        /// <returns>true:車両情報有効 false:車両情報無効</returns>
        public bool EnableCarInfo()
        {
            bool ret = _EnableCarInfo;
            return ret;
        }

        /// <summary>
        /// 車両情報有効区分設定(NsMailFactory以外では使用しないでください)
        /// </summary>
        /// <param name="enableFg"></param>
        public void SetCarInfoStatus(bool enableFg)
        {
            _EnableCarInfo = enableFg;
        }

        #endregion


    }
}
