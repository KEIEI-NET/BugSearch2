using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;

using Broadleaf.Library.Text;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 自由帳票ローカルデータアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 自由帳票のローカルデータへのアクセス制御を行います。</br>
    /// <br>Programmer	: 22024 寺坂　誉志</br>
    /// <br>Date		: 2007.04.12</br>
    /// <br></br>
    /// <br>Update Note	: 2008.03.17 22024 寺坂誉志</br>
    /// <br>			: １．ローカルデータ存在チェックメソッドを追加</br>
    /// </remarks>
    public class FrePrtPosLocalAcs
    {
        #region Const
        private const string ctSave_Key = "66f05f0d-030a-491a-8009-782e46a1eb3e";
        private const string ctExtension = ".DAT";
        // ローカルファイル共通ファイルヘッダー名称
        private const string ctFileID_FrePrtPSet = "FrePrtPSet";		// 自由帳票印字位置設定マスタ
        private const string ctFileID_PrtItemGrpWork = "PrtItemGrpWork";	// 印字項目グループマスタ
        private const string ctFileID_FPprSchmGrWork = "FPprSchmGrWork";	// 自由帳票スキーマグループマスタ
        #endregion

        #region PrivateMember
        // エラーメッセージ
        private string _errorStr;
        #endregion

        #region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FrePrtPosLocalAcs()
        {
        }
        #endregion

        #region Property
        /// <summary>エラーメッセージ</summary>
        /// <remarks>読み取り専用</remarks>
        public string ErrorMessage
        {
            get { return _errorStr; }
        }
        #endregion

        #region PublicMethod
        /// <summary>
        /// 自由帳票印字位置設定保存処理（ローカルデータ）
        /// </summary>
        /// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
        /// <param name="frePprECndList">自由帳票抽出条件設定マスタリスト</param>
        /// <param name="frePprSrtOList">自由帳票ソート順位マスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された自由帳票印字位置情報をローカルに保存します。</br>
        /// <br>Programmer : 22024 寺坂誉志</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int WriteLocalFrePrtPSet( FrePrtPSet frePrtPSet, List<FrePprECnd> frePprECndList, List<FrePprSrtO> frePprSrtOList )
        {
            // ファイルパス生成
            string filePath = CreateFilePathForFrePrtPSet( frePrtPSet.OutputFormFileName, frePrtPSet.UserPrtPprIdDerivNo );

            return WriteLocalFrePrtPSet( frePrtPSet, frePprECndList, frePprSrtOList, filePath );
        }

        /// <summary>
        /// 自由帳票印字位置設定保存処理（ローカルデータ）
        /// </summary>
        /// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
        /// <param name="frePprECndList">自由帳票抽出条件設定マスタリスト</param>
        /// <param name="frePprSrtOList">自由帳票ソート順位マスタリスト</param>
        /// <param name="filePath">保存先ファイルパス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された自由帳票印字位置情報をローカルに保存します。</br>
        /// <br>Programmer : 22024 寺坂誉志</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int WriteLocalFrePrtPSet( FrePrtPSet frePrtPSet, List<FrePprECnd> frePprECndList, List<FrePprSrtO> frePprSrtOList, string filePath )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                ArrayList writeList = new ArrayList();
                writeList.Add( frePrtPSet );
                writeList.Add( frePprECndList );
                writeList.Add( frePprSrtOList );

                // XmlSerializerのコンストラクタで型を指定（これでArrayList内の独自クラスのシリアライズ可能）
                Type[] typeArray = new Type[] { typeof( FrePrtPSet ), typeof( List<FrePprECnd> ), typeof( List<FrePprSrtO> ) };
                XmlSerializer serializer = new XmlSerializer( typeof( ArrayList ), typeArray );

                using ( MemoryStream stream = new MemoryStream() )
                {
                    serializer.Serialize( stream, writeList );
                    UserSettingController.EncryptionBytes( stream.ToArray(), filePath, new string[] { ctSave_Key } );

                    stream.Close();
                }
            }
            catch ( Exception ex )
            {
                _errorStr = "自由帳票印字位置設定のローカルデータ保存処理にて例外が発生しました。";
                _errorStr += "\r\n" + ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 自由帳票印字位置設定読込処理（ローカルデータ）
        /// </summary>
        /// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
        /// <param name="frePprECndList">自由帳票抽出条件設定マスタリスト</param>
        /// <param name="frePprSrtOList">自由帳票ソート順位マスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された自由帳票印字位置情報をローカルより取得します。</br>
        /// <br>Programmer : 22024 寺坂誉志</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int ReadLocalFrePrtPSet( ref FrePrtPSet frePrtPSet, out List<FrePprECnd> frePprECndList, out List<FrePprSrtO> frePprSrtOList )
        {
            // ファイルパス生成
            string filePath = CreateFilePathForFrePrtPSet( frePrtPSet.OutputFormFileName, frePrtPSet.UserPrtPprIdDerivNo );

            FrePrtPSet wkFrePrtPSet;
            int status = ReadLocalFrePrtPSet( out wkFrePrtPSet, out frePprECndList, out frePprSrtOList, filePath );
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                if ( frePrtPSet.EnterpriseCode == wkFrePrtPSet.EnterpriseCode )
                    frePrtPSet = wkFrePrtPSet;
                else
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            return status;
        }

        /// <summary>
        /// 自由帳票印字位置設定読込処理（ローカルデータ）
        /// </summary>
        /// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
        /// <param name="frePprECndList">自由帳票抽出条件設定マスタリスト</param>
        /// <param name="frePprSrtOList">自由帳票ソート順位マスタリスト</param>
        /// <param name="filePath">読込ファイルパス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された自由帳票印字位置情報をローカルより取得します。</br>
        /// <br>Programmer : 22024 寺坂誉志</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int ReadLocalFrePrtPSet( out FrePrtPSet frePrtPSet, out List<FrePprECnd> frePprECndList, out List<FrePprSrtO> frePprSrtOList, string filePath )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            frePrtPSet = null;
            frePprECndList = null;
            frePprSrtOList = null;

            FrePrtPSet wkFrePrtPSet;
            List<FrePprECnd> wkFrePprECndList;
            List<FrePprSrtO> wkFrePprSrtOList;
            status = ReadLocalFrePrtPSetProc( filePath, out wkFrePrtPSet, out wkFrePprECndList, out wkFrePprSrtOList );
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                frePrtPSet = wkFrePrtPSet;
                frePprECndList = wkFrePprECndList;
                frePprSrtOList = wkFrePprSrtOList;
            }

            return status;
        }

        /// <summary>
        /// 自由帳票印字位置設定削除処理（ローカルデータ）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="outputFormFileName">出力ファイル名</param>
        /// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番号</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された自由帳票印字位置情報をローカルより削除します。</br>
        /// <br>Programmer : 22024 寺坂誉志</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int DeleteLocalFrePrtPSet( string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                // ファイルパス生成
                string fileName = CreateFilePathForFrePrtPSet( outputFormFileName, userPrtPprIdDerivNo );
                if ( File.Exists( fileName ) )
                {
                    FrePrtPSet frePrtPSet;
                    List<FrePprECnd> frePprECndList;
                    List<FrePprSrtO> frePprSrtOList;
                    status = ReadLocalFrePrtPSet( out frePrtPSet, out frePprECndList, out frePprSrtOList, fileName );
                    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        if ( frePrtPSet.EnterpriseCode == enterpriseCode )
                            File.Delete( fileName );
                    }
                }
            }
            catch ( Exception ex )
            {
                _errorStr = "自由帳票印字位置設定のローカルデータ削除処理にて例外が発生しました。";
                _errorStr += "\r\n" + ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 自由帳票印字位置設定検索処理（ローカルデータ）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="printPaperUseDivcd">帳票使用区分</param>
        /// <param name="frePrtPSetList">自由帳票印字位置設定マスタリスト</param>
        /// <param name="frePprECndList">自由帳票抽出条件設定マスタリスト</param>
        /// <param name="frePprSrtOList">自由帳票ソート順位マスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ローカルにある自由帳票印字位置情報を全件取得します。</br>
        /// <br>Programmer : 22024 寺坂誉志</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int SearchLocalFrePrtPSet( string enterpriseCode, int printPaperUseDivcd, out List<FrePrtPSet> frePrtPSetList, out List<FrePprECnd> frePprECndList, out List<FrePprSrtO> frePprSrtOList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            frePrtPSetList = new List<FrePrtPSet>();
            frePprECndList = new List<FrePprECnd>();
            frePprSrtOList = new List<FrePprSrtO>();

            try
            {
                string targetDirectory = Path.Combine( Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.FREEPOS_PRTPOS );
                if ( Directory.Exists( targetDirectory ) )
                {
                    string[] fileNames = Directory.GetFiles( targetDirectory, ctFileID_FrePrtPSet + "*" + ctExtension );
                    foreach ( string filePath in fileNames )
                    {
                        FrePrtPSet wkFrePrtPSet;
                        List<FrePprECnd> wkFrePprECndList = new List<FrePprECnd>();
                        List<FrePprSrtO> wkFrePprSrtOList = new List<FrePprSrtO>();
                        status = ReadLocalFrePrtPSetProc( filePath, out wkFrePrtPSet, out wkFrePprECndList, out wkFrePprSrtOList );
                        if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                        {
                            if ( wkFrePrtPSet.EnterpriseCode == enterpriseCode )
                            {
                                if ( printPaperUseDivcd == 0 || wkFrePrtPSet.PrintPaperUseDivcd == printPaperUseDivcd )
                                {
                                    frePrtPSetList.Add( wkFrePrtPSet );
                                    frePprECndList.AddRange( wkFrePprECndList );
                                    frePprSrtOList.AddRange( wkFrePprSrtOList );
                                }
                            }
                        }
                    }
                }

                if ( frePrtPSetList.Count == 0 )
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch ( Exception ex )
            {
                _errorStr = "自由帳票印字位置設定のローカルデータ検索処理にて例外が発生しました。";
                _errorStr += "\r\n" + ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 印字項目グループ保存処理（ローカルデータ）
        /// </summary>
        /// <param name="prtItemGrp">印字項目グループマスタ</param>
        /// <param name="prtItemSetList">印字項目設定マスタリスト</param>
        /// <param name="fPSortInitList">自由帳票ソート順位初期値マスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された印字項目グループをローカルに保存します。</br>
        /// <br>Programmer : 22024 寺坂誉志</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int WriteLocalPrtItemGrpWork( PrtItemGrpWork prtItemGrp, List<PrtItemSetWork> prtItemSetList, List<FPSortInitWork> fPSortInitList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                ArrayList writeList = new ArrayList();
                writeList.Add( prtItemGrp );
                writeList.Add( prtItemSetList );
                if ( fPSortInitList == null ) fPSortInitList = new List<FPSortInitWork>();
                writeList.Add( fPSortInitList );

                // XmlSerializerのコンストラクタで型を指定（これでArrayList内の独自クラスのシリアライズ可能）
                Type[] typeArray = new Type[] { typeof( PrtItemGrpWork ), typeof( List<PrtItemSetWork> ), typeof( List<FPSortInitWork> ) };
                XmlSerializer serializer = new XmlSerializer( typeof( ArrayList ), typeArray );

                // ファイルパス生成
                string fileName = CreateFilePathForPrtItemGrp( prtItemGrp.FreePrtPprItemGrpCd );

                using ( MemoryStream stream = new MemoryStream() )
                {
                    serializer.Serialize( stream, writeList );
                    UserSettingController.EncryptionBytes( stream.ToArray(), fileName, new string[] { ctSave_Key } );

                    stream.Close();
                }
            }
            catch ( Exception ex )
            {
                _errorStr = "印字項目設定のローカルデータ保存処理にて例外が発生しました。";
                _errorStr += "\r\n" + ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 印字項目グループ読込処理（ローカルデータ）
        /// </summary>
        /// <param name="freePrtPprItemGrpCd">印字項目グループコード</param>
        /// <param name="prtItemGrp">印字項目グループマスタ</param>
        /// <param name="prtItemSetList">印字項目設定マスタLIST</param>
        /// <param name="fPSortInitList">自由帳票ソート順位初期値マスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された印字項目グループをローカルより取得します。</br>
        /// <br>Programmer : 22024 寺坂誉志</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int ReadLocalPrtItemGrpWork( int freePrtPprItemGrpCd, out PrtItemGrpWork prtItemGrp, out List<PrtItemSetWork> prtItemSetList, out List<FPSortInitWork> fPSortInitList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            prtItemGrp = null;
            prtItemSetList = new List<PrtItemSetWork>();
            fPSortInitList = new List<FPSortInitWork>();

            try
            {
                // ファイルパス生成
                string fileName = CreateFilePathForPrtItemGrp( freePrtPprItemGrpCd );

                if ( File.Exists( fileName ) )
                {
                    byte[] byteData = UserSettingController.DecryptionBytes( fileName, new string[] { ctSave_Key } );

                    // XmlSerializerのコンストラクタで型を指定（これでArrayList内の独自クラスのデシリアライズ可能）
                    Type[] typeArray = new Type[] { typeof( PrtItemGrpWork ), typeof( List<PrtItemSetWork> ), typeof( List<FPSortInitWork> ) };
                    XmlSerializer serializer = new XmlSerializer( typeof( ArrayList ), typeArray );

                    using ( MemoryStream stream = new MemoryStream( byteData ) )
                    {
                        ArrayList readList = (ArrayList)serializer.Deserialize( stream );
                        for ( int ix = 0; ix != readList.Count; ix++ )
                        {
                            if ( readList[ix] is PrtItemGrpWork )
                                prtItemGrp = (PrtItemGrpWork)readList[ix];
                            else if ( readList[ix] is List<PrtItemSetWork> )
                                prtItemSetList = (List<PrtItemSetWork>)readList[ix];
                            else if ( readList[ix] is List<FPSortInitWork> )
                                fPSortInitList = (List<FPSortInitWork>)readList[ix];
                        }

                        stream.Close();
                    }

                    if ( prtItemGrp == null || prtItemSetList.Count == 0 )
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch ( Exception ex )
            {
                _errorStr = "印字項目グループのローカルデータ読込処理にて例外が発生しました。";
                _errorStr += "\r\n" + ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 自由帳票スキーマグループ保存処理（ローカルデータ）
        /// </summary>
        /// <param name="fPprSchmGr">自由帳票スキーマグループマスタ</param>
        /// <param name="fPprSchmCvList">自由帳票スキーマコンバートマスタ</param>
        /// <param name="fPSortInitList">自由帳票ソート順位初期値マスタリスト</param>
        /// <param name="fPECndInitList">自由帳票抽出条件初期値マスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された印字項目グループをローカルより取得します。</br>
        /// <br>Programmer : 22024 寺坂誉志</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int WriteLocalFPprSchmGrWork( FPprSchmGrWork fPprSchmGr, List<FPprSchmCvWork> fPprSchmCvList, List<FPSortInitWork> fPSortInitList, List<FPECndInitWork> fPECndInitList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                ArrayList writeList = new ArrayList();
                writeList.Add( fPprSchmGr );
                writeList.Add( fPprSchmCvList );
                if ( fPSortInitList == null ) fPSortInitList = new List<FPSortInitWork>();
                writeList.Add( fPSortInitList );
                if ( fPECndInitList == null ) fPECndInitList = new List<FPECndInitWork>();
                writeList.Add( fPECndInitList );

                // XmlSerializerのコンストラクタで型を指定（これでArrayList内の独自クラスのシリアライズ可能）
                Type[] typeArray = new Type[] { typeof( FPprSchmGrWork ), typeof( List<FPprSchmCvWork> ), typeof( List<FPSortInitWork> ), typeof( List<FPECndInitWork> ) };
                XmlSerializer serializer = new XmlSerializer( typeof( ArrayList ), typeArray );

                // ファイルパス生成
                string fileName = CreateFilePathForFPprSchmGr( fPprSchmGr.FreePrtPprSchmGrpCd );

                using ( MemoryStream stream = new MemoryStream() )
                {
                    serializer.Serialize( stream, writeList );
                    UserSettingController.EncryptionBytes( stream.ToArray(), fileName, new string[] { ctSave_Key } );

                    stream.Close();
                }
            }
            catch ( Exception ex )
            {
                _errorStr = "自由帳票スキーマグループのローカルデータ保存処理にて例外が発生しました。";
                _errorStr += "\r\n" + ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 自由帳票スキーマグループ読込処理（ローカルデータ）
        /// </summary>
        /// <param name="freePrtPprSchmGrpCd">自由帳票スキーマグループコード</param>
        /// <param name="fPprSchmGr">自由帳票スキーマグループマスタ</param>
        /// <param name="fPprSchmCvList">自由帳票スキーマコンバートマスタリスト</param>
        /// <param name="fPSortInitList">自由帳票ソート順位初期値マスタリスト</param>
        /// <param name="fPECndInitList">自由帳票抽出条件初期値マスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された自由帳票スキーマグループをローカルより取得します。</br>
        /// <br>Programmer : 22024 寺坂誉志</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        public int ReadLocalFPprSchmGrWork( int freePrtPprSchmGrpCd, out FPprSchmGrWork fPprSchmGr, out List<FPprSchmCvWork> fPprSchmCvList, out List<FPSortInitWork> fPSortInitList, out List<FPECndInitWork> fPECndInitList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            fPprSchmGr = null;
            fPprSchmCvList = new List<FPprSchmCvWork>();
            fPSortInitList = new List<FPSortInitWork>();
            fPECndInitList = new List<FPECndInitWork>();

            try
            {
                // ファイルパス生成
                string fileName = CreateFilePathForFPprSchmGr( freePrtPprSchmGrpCd );

                if ( File.Exists( fileName ) )
                {
                    byte[] byteData = UserSettingController.DecryptionBytes( fileName, new string[] { ctSave_Key } );

                    // XmlSerializerのコンストラクタで型を指定（これでArrayList内の独自クラスのデシリアライズ可能）
                    Type[] typeArray = new Type[] { typeof( FPprSchmGrWork ), typeof( List<FPprSchmCvWork> ), typeof( List<FPSortInitWork> ), typeof( List<FPECndInitWork> ) };
                    XmlSerializer serializer = new XmlSerializer( typeof( ArrayList ), typeArray );

                    using ( MemoryStream stream = new MemoryStream( byteData ) )
                    {
                        ArrayList readList = (ArrayList)serializer.Deserialize( stream );
                        for ( int ix = 0; ix != readList.Count; ix++ )
                        {
                            if ( readList[ix] is FPprSchmGrWork )
                                fPprSchmGr = (FPprSchmGrWork)readList[ix];
                            else if ( readList[ix] is List<FPprSchmCvWork> )
                                fPprSchmCvList = (List<FPprSchmCvWork>)readList[ix];
                            else if ( readList[ix] is List<FPSortInitWork> )
                                fPSortInitList = (List<FPSortInitWork>)readList[ix];
                            else if ( readList[ix] is List<FPECndInitWork> )
                                fPECndInitList = (List<FPECndInitWork>)readList[ix];
                        }

                        stream.Close();
                    }

                    if ( fPprSchmGr == null || fPprSchmCvList.Count == 0 )
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch ( Exception ex )
            {
                _errorStr = "印字項目グループのローカルデータ読込処理にて例外が発生しました。";
                _errorStr += "\r\n" + ex.Message;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ローカルデータ存在チェック
        /// </summary>
        /// <param name="frePrtPSetList">自由帳票印字位置設定マスタリスト</param>
        /// <returns>フィルター結果リスト</returns>
        /// <remarks>
        /// <br>Note       : 渡されたデータのうちローカルデータが存在するデータ全てを取得します。</br>
        /// <br>Programmer : 22024 寺坂誉志</br>
        /// <br>Date       : 2008.03.17</br>
        /// </remarks>
        public List<FrePrtPSet> FindAllLocalDataExists( List<FrePrtPSet> frePrtPSetList )
        {
            List<FrePrtPSet> retList = new List<FrePrtPSet>();

            if ( frePrtPSetList != null && frePrtPSetList.Count > 0 )
            {
                foreach ( FrePrtPSet frePrtPSet in frePrtPSetList )
                {
                    string fileName = CreateFilePathForFrePrtPSet( frePrtPSet.OutputFormFileName, frePrtPSet.UserPrtPprIdDerivNo );
                    if ( File.Exists( fileName ) )
                        retList.Add( frePrtPSet.Clone() );
                }
            }

            return retList;
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        /// ファイルパス作成処理
        /// </summary>
        /// <param name="outputFormFileName">出力ファイル名</param>
        /// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番号</param>
        /// <returns>ファイルパス</returns>
        /// <remarks>
        /// <br>Note       : キー情報を付与したファイルパスを作成します。</br>
        /// <br>Programmer : 22024 寺坂誉志</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        private string CreateFilePathForFrePrtPSet( string outputFormFileName, int userPrtPprIdDerivNo )
        {
            // ファイルパス生成
            string fileName = ctFileID_FrePrtPSet + "_" + outputFormFileName + "_" + userPrtPprIdDerivNo.ToString( "000" ) + ctExtension;
            string directory = Path.Combine( Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.FREEPOS_PRTPOS );
            fileName = Path.Combine( directory, fileName );

            if ( !Directory.Exists( directory ) ) Directory.CreateDirectory( directory );

            return fileName;
        }

        /// <summary>
        /// 自由帳票印字位置設定読込処理（メイン部）
        /// </summary>
        /// <param name="filePath">ファイル名</param>
        /// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
        /// <param name="frePprECndList">自由帳票抽出条件設定マスタリスト</param>
        /// <param name="frePprSrtOList">自由帳票ソート順位マスタリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された自由帳票印字位置情報をローカルより取得します。</br>
        /// <br>Programmer : 22024 寺坂誉志</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        private int ReadLocalFrePrtPSetProc( string filePath, out FrePrtPSet frePrtPSet, out List<FrePprECnd> frePprECndList, out List<FrePprSrtO> frePprSrtOList )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            frePrtPSet = null;
            frePprECndList = new List<FrePprECnd>();
            frePprSrtOList = new List<FrePprSrtO>();

            try
            {
                if ( File.Exists( filePath ) )
                {
                    byte[] byteData = UserSettingController.DecryptionBytes( filePath, new string[] { ctSave_Key } );

                    // XmlSerializerのコンストラクタで型を指定（これでArrayList内の独自クラスのデシリアライズ可能）
                    Type[] typeArray = new Type[] { typeof( FrePrtPSet ), typeof( List<FrePprECnd> ), typeof( List<FrePprSrtO> ) };
                    XmlSerializer serializer = new XmlSerializer( typeof( ArrayList ), typeArray );

                    using ( MemoryStream stream = new MemoryStream( byteData ) )
                    {
                        ArrayList readList = (ArrayList)serializer.Deserialize( stream );
                        for ( int ix = 0; ix != readList.Count; ix++ )
                        {
                            if ( readList[ix] is FrePrtPSet )
                                frePrtPSet = (FrePrtPSet)readList[ix];
                            else if ( readList[ix] is List<FrePprECnd> )
                                frePprECndList = (List<FrePprECnd>)readList[ix];
                            else if ( readList[ix] is List<FrePprSrtO> )
                                frePprSrtOList = (List<FrePprSrtO>)readList[ix];
                        }

                        stream.Close();
                    }

                    if ( frePrtPSet == null )
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    _errorStr = "自由帳票印字位置設定ローカルデータがありません。";
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch ( Exception ex )
            {
                _errorStr = "自由帳票印字位置設定のローカルデータ読込処理にて例外が発生しました。";
                _errorStr += "\r\n" + ex.Message;

                frePrtPSet = null;
                frePprECndList.Clear();
                frePprSrtOList.Clear();

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ファイルパス作成処理
        /// </summary>
        /// <param name="freePrtPprItemGrpCd">印字項目グループコード</param>
        /// <returns>ファイルパス</returns>
        /// <remarks>
        /// <br>Note       : キー情報を付与したファイルパスを作成します。</br>
        /// <br>Programmer : 22024 寺坂誉志</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        private string CreateFilePathForPrtItemGrp( int freePrtPprItemGrpCd )
        {
            // ファイルパス生成
            string fileName = ctFileID_PrtItemGrpWork + "_" + freePrtPprItemGrpCd.ToString( "0000" ) + ctExtension;
            string directory = Path.Combine( Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.FREEPOS_PRTITEM );
            fileName = Path.Combine( directory, fileName );

            if ( !Directory.Exists( directory ) ) Directory.CreateDirectory( directory );

            return fileName;
        }

        /// <summary>
        /// ファイルパス作成処理
        /// </summary>
        /// <param name="freePrtPprSchmGrpCd">自由帳票スキーマグループコード</param>
        /// <returns>ファイルパス</returns>
        /// <remarks>
        /// <br>Note       : キー情報を付与したファイルパスを作成します。</br>
        /// <br>Programmer : 22024 寺坂誉志</br>
        /// <br>Date       : 2007.04.12</br>
        /// </remarks>
        private string CreateFilePathForFPprSchmGr( int freePrtPprSchmGrpCd )
        {
            // ファイルパス生成
            string fileName = ctFileID_FPprSchmGrWork + "_" + freePrtPprSchmGrpCd.ToString( "0000" ) + ctExtension;
            string directory = Path.Combine( Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.FREEPOS_PRTSCHEMA );
            fileName = Path.Combine( directory, fileName );

            if ( !Directory.Exists( directory ) ) Directory.CreateDirectory( directory );

            return fileName;
        }
        #endregion
    }
}
