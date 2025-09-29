using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Remoting
{
    public class EmployeeLogin2DB :RemoteDB, IEmployeeLogin2DB
    {
        private FeliCaMngDB _feliCaMngDB = null;
        private EmployeeLoginDB _employeeLoginDB = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EmployeeLogin2DB()
        {
            
        }

        /// <summary>
        /// 従業員ログイン
        /// </summary>
        /// <param name="accessTicket">アクセスチケット</param>
        /// <param name="iD">FelicaログインID</param>
        /// <param name="password">従業員ログインパスワード</param>
        /// <param name="felicaMode">Felicaログインタイプ</param>
        /// <param name="retCmpObj">企業ログイン情報</param>
        /// <param name="retEmpObj">従業員ログイン情報</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>STATUS</returns>
        public int Login(string accessTicket, string iD, string password, bool felicaMode, ref object retCmpObj, out object retEmpObj, out string retMsg)
        {
            if( _employeeLoginDB == null )
            {
                _employeeLoginDB = new EmployeeLoginDB();
            }
            if( !felicaMode )
            {
                //通常の従業員ログインの場合
                return _employeeLoginDB.Login(accessTicket, iD, password, ref retCmpObj, out retEmpObj, out retMsg);
            }

            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //空クラスで初期化（未ログイン時のシリアライズエラーを回避するため）
            retEmpObj = (object)new EmployeeAuthInfoWork();
            retMsg = "";

            //●パラメータチェック
            if( accessTicket == null || accessTicket.Trim() == "" || retCmpObj == null )
            {
                retMsg = "企業認証されていません。企業認証後、従業員認証を行ってください。";
                return status;
            }
            //従業員ログイン情報のログインIDは指定されているか？
            if( iD == null || iD.Trim() == "" )
            {
                retMsg = "従業員IDを指定してください。";
                return status;
            }

            //●AccessTicketのチェックを行う
            //webサービスオブジェクト生成
            Broadleaf.Application.Remoting.WebReference.UBAWebService uba = null;
            CompanyAuthInfoWork companyAuthInfoWork = (CompanyAuthInfoWork)retCmpObj;
            try
            {
                uba = new Broadleaf.Application.Remoting.WebReference.UBAWebService();

                if( !uba.VerifyAccessTicket(accessTicket) )
                {
                    retMsg = "企業認証されていないか、企業認証が無効になっています。再度企業認証を行ってください。";
                    return status;
                }
            }
            catch( Exception ex )
            {
                if( uba != null )
                    uba.Dispose();
                retMsg = "認証サーバーにてエラーが発生しました。[" + ex.Message + "]";
                base.WriteErrorLog(ex, retMsg);
                status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
                return status;
            }
            finally
            {
                uba.Dispose();
            }
            //ログイン企業情報取得
            if( companyAuthInfoWork == null || companyAuthInfoWork.EnterpriseInfoWork == null ||
                companyAuthInfoWork.EnterpriseInfoWork.EnterpriseCode == null ||
                companyAuthInfoWork.EnterpriseInfoWork.EnterpriseCode.Trim() == "" )
            {
                retMsg = "企業認証されていないか、企業認証が無効になっています。再度企業認証を行ってください。";
                return status;
            }
            //●ログインチェック用DBコネクション作成
            //※ログイン処理の為サーバーログイン部品でコネクションの取得が不可。
            //　その為直接コネクション情報を取得し、コネクションオブジェクトを生成。
            //　従業員ROへコネクションを渡しデータリードしてもらう
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = GetSqlConnection(companyAuthInfoWork);

                if( sqlConnection == null )
                {
                    retMsg = "従業員認証用のDBサーバー接続情報が登録されていません。認証情報の確認が必要です。";
                    Exception ex = new Exception(retMsg, null);
                    base.WriteErrorLog(ex, retMsg);
                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
            }
            catch( Exception ex )
            {
                retMsg = "従業員認証用のDBサーバーコネクション時にエラーが発生しました。[" + ex.Message + "]";
                base.WriteErrorLog(ex, retMsg);
                status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
                return status;
            }

            //20081112 ADD
            if( _feliCaMngDB == null )
            {
                _feliCaMngDB = new FeliCaMngDB();
            }

            FeliCaMngWork feliCaMngWork = new FeliCaMngWork();
            feliCaMngWork.EnterpriseCode = companyAuthInfoWork.EnterpriseInfoWork.EnterpriseCode;
            feliCaMngWork.FeliCaMngKind = 1;
            feliCaMngWork.FeliCaIDm = iD;

            status = _feliCaMngDB.Read(ref feliCaMngWork, ref sqlConnection);
            //正常に読み込みされなかった場合終了
            if( status != (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL || feliCaMngWork == null )
            {
                if( status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                    retMsg = "該当する従業員が見つかりません。";
                return status;
            }



            //●従業員読み込み
            EmployeeAuthInfoWork employeeAuthInfoWork = null;
            try
            {
                //RemoteObjectインスタンス化
                EmployeeDB employeeDB = new EmployeeDB();
                EmployeeWork employeeWork = new EmployeeWork();
                employeeWork.EnterpriseCode = companyAuthInfoWork.EnterpriseInfoWork.EnterpriseCode;
                //FeliCaMngDBのリード結果のEmployeeCodeをセットする。
                employeeWork.EmployeeCode = feliCaMngWork.EmployeeCode;

                status = employeeDB.Read(ref employeeWork, 0, ref sqlConnection);
                //正常に読み込みされなかった場合終了
                if( status != (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL || employeeWork == null )
                {
                    if( status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                        retMsg = "該当する従業員が見つかりません。";
                    return status;
                }
                //読み込まれた場合にはEmployeeCodeがFeliCaMngDBのリード結果と一致しているかチェック
                if( employeeWork.EmployeeCode != feliCaMngWork.EmployeeCode )
                {
                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND; //2006.12.07 ADD 上野 
                    retMsg = "該当する従業員が見つかりません。";
                    return status;
                }

                //従業員チェックがOKの場合は、従業員の情報を戻り値にセットする
                employeeAuthInfoWork = new EmployeeAuthInfoWork();
                employeeAuthInfoWork.EmployeeWork = employeeWork;
            }
            catch( Exception ex )
            {
                retMsg = "認証用従業員読み込み時にエラーが発生しました。[" + ex.Message + "]";
                base.WriteErrorLog(ex, retMsg);
                status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
                return status;
            }
            finally
            {
                if( sqlConnection != null )
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            //従業員オブジェクトに戻り値設定
            retEmpObj = employeeAuthInfoWork as object;

            //正常戻り値を戻す
            status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;

            //戻り値設定
            return status;
        }


        /// <summary>
        /// データコネクション取得
        /// </summary>
        /// <param name="companyAuthInfoWork"></param>
        /// <returns></returns>
        private SqlConnection GetSqlConnection(CompanyAuthInfoWork companyAuthInfoWork)
        {
            SqlConnection sqlConnection = null;

            //接続情報が無ければnullを戻す
            if( companyAuthInfoWork == null ||
                companyAuthInfoWork.ProductInfoWork == null ||
                companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray == null ||
                companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray.Length == 0 )
                return sqlConnection;

            //リモートサーバー情報からIsLoginServiceのリモート接続先を検索
            foreach( RemoteServiceInfoWork remoteServiceInfoWork in companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray )
            {
                //ログインサービスでは無い場合次へ
                if( !remoteServiceInfoWork.IsLoginService )
                    continue;

                //接続情報が無い場合ループ終了（接続情報無し）
                if( remoteServiceInfoWork.ConnectionInfoWorkArray == null ||
                    remoteServiceInfoWork.ConnectionInfoWorkArray.Length == 0 )
                    break;

                //接続情報がある場合、ユーザーDB接続情報を検索
                foreach( ConnectionInfoWork connectionInfoWork in remoteServiceInfoWork.ConnectionInfoWorkArray )
                {
                    //ユーザーデータDBコネクションがある場合
                    if( connectionInfoWork.IndexCode == "USER_DB" )
                    {
                        //debug end
                        //接続文字列を生成
                        sqlConnection = new SqlConnection(string.Format("workstation id={0}; {1}", SqlConnectionInfo.GetWorkstationID(), ServerLoginInfoAcquisition.Decrypt(connectionInfoWork.ConnectionText, companyAuthInfoWork)));
                        sqlConnection.Open();
                        break;
                    }
                }
                if( sqlConnection != null )
                    break;
            }

            return sqlConnection;
        }

        /// <summary>
        /// 企業認証情報取得
        /// </summary>
        /// <param name="token">取得認証情報</param>
        /// <returns>企業認証情報</returns>
        private CompanyAuthInfoWork MakeCompanyAuthInfoWork(Broadleaf.Application.Remoting.WebReference.AccessToken token)
        {
            //企業情報が無い場合にはnullを戻す
            if( token == null )
                return null;

            //企業情報がある場合には企業ログイン情報を生成
            CompanyAuthInfoWork companyAuthInfoWork = new CompanyAuthInfoWork();
            companyAuthInfoWork.AccessTicket = token.AccessTicket;
            companyAuthInfoWork.LoginFlag = token.LoginFlag;
            companyAuthInfoWork.OnlineMode = true;
            //ログイン企業情報を取得
            companyAuthInfoWork.EnterpriseInfoWork = new EnterpriseInfoWork();
            companyAuthInfoWork.EnterpriseInfoWork.EnterpriseCode = token.Company.CompanyCode;
            companyAuthInfoWork.EnterpriseInfoWork.EnterpriseName = token.Company.CompanyName;
            companyAuthInfoWork.EnterpriseInfoWork.EnterpriseDescription = token.Company.CompanyDescription;
            //ログイン企業契約ソフトウェア情報を取得
            companyAuthInfoWork.ProductInfoWork = new ProductInfoWork();
            companyAuthInfoWork.ProductInfoWork.ProductCode = token.Product.ProductCode;
            companyAuthInfoWork.ProductInfoWork.ProductName = token.Product.ProductName;
            companyAuthInfoWork.ProductInfoWork.ProductDescription = token.Product.ProductDescription;
            //サービスコネクション情報
            if( token.Product.RemoteServiceInfoArray == null || token.Product.RemoteServiceInfoArray.Length == 0 )
            {
                companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray = new RemoteServiceInfoWork[0];
            }
            else
            {
                companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray = new RemoteServiceInfoWork[token.Product.RemoteServiceInfoArray.Length];
                for( int i = 0; i < token.Product.RemoteServiceInfoArray.Length; i++ )
                {
                    companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i] = new RemoteServiceInfoWork();
                    companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ServiceCode = token.Product.RemoteServiceInfoArray[i].ServiceCode;
                    companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ServiceName = token.Product.RemoteServiceInfoArray[i].ServiceName;
                    companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ServiceTargetName = token.Product.RemoteServiceInfoArray[i].ServiceTargetName;
                    companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].Protocol = token.Product.RemoteServiceInfoArray[i].Protocol;
                    companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].Domain = token.Product.RemoteServiceInfoArray[i].Domain;
                    companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].Port = token.Product.RemoteServiceInfoArray[i].Port;
                    companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].IsLoginService = token.Product.RemoteServiceInfoArray[i].IsLoginService;
                    //コネクション情報
                    if( token.Product.RemoteServiceInfoArray[i].ConnectionInfo == null || token.Product.RemoteServiceInfoArray[i].ConnectionInfo.Length == 0 )
                    {
                        companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray = new ConnectionInfoWork[0];
                    }
                    else
                    {
                        companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray = new ConnectionInfoWork[token.Product.RemoteServiceInfoArray[i].ConnectionInfo.Length];
                        for( int ii = 0; ii < token.Product.RemoteServiceInfoArray[i].ConnectionInfo.Length; ii++ )
                        {
                            companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii] = new ConnectionInfoWork();
                            companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].IndexCode = token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].IndexCode;
                            companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].IndexName = token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].IndexName;
                            companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].TypeCode = token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].TypeCode;
                            companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].ConnectionText = token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].ConnectionText;
                            companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].ConnectionName = token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].ConnectionName;

                        }
                    }
                }
            }

            //ソフトウェア情報
            if( token.Product.SoftwareInfoArray == null || token.Product.SoftwareInfoArray.Length == 0 )
            {
                companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray = new SoftwareInfoWork[0];
            }
            else
            {
                companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray = new SoftwareInfoWork[token.Product.SoftwareInfoArray.Length];
                for( int i = 0; i < token.Product.SoftwareInfoArray.Length; i++ )
                {
                    companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i] = new SoftwareInfoWork();
                    companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].SoftwareCode = token.Product.SoftwareInfoArray[i].SoftwareCode;
                    companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].SoftwareName = token.Product.SoftwareInfoArray[i].SoftwareName;
                    companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].SoftwareType = token.Product.SoftwareInfoArray[i].SoftwareType;
                    companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].SoftwareDescription = token.Product.SoftwareInfoArray[i].SoftwareDescription;
                    companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].ProductCode = token.Product.SoftwareInfoArray[i].ProductCode;
                    companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].RemainingDays = token.Product.SoftwareInfoArray[i].RemainingDays;
                    companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].PurchaseStatus = (Int32)token.Product.SoftwareInfoArray[i].PurchaseStatus;
                    companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].IsUSBAccessPermitted = token.Product.SoftwareInfoArray[i].IsUSBAccessPermitted;
                }
            }
            //ロール情報
            if( token.Product.RoleInfoArray == null || token.Product.RoleInfoArray.Length == 0 )
            {
                companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray = new RoleInfoWork[0];
            }
            else
            {
                companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray = new RoleInfoWork[token.Product.RoleInfoArray.Length];
                for( int i = 0; i < token.Product.RoleInfoArray.Length; i++ )
                {
                    companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i] = new RoleInfoWork();
                    companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].RoleCode = token.Product.RoleInfoArray[i].RoleCode;
                    companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].RoleName = token.Product.RoleInfoArray[i].RoleName;
                    companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].RoleDescription = token.Product.RoleInfoArray[i].RoleDescription;
                    if( token.Product.RoleInfoArray[i].FunctionInfoArray == null || token.Product.RoleInfoArray[i].FunctionInfoArray.Length == 0 )
                    {
                        companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray = new FunctionInfoWork[0];
                    }
                    else
                    {
                        companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray = new FunctionInfoWork[token.Product.RoleInfoArray[i].FunctionInfoArray.Length];
                        for( int ii = 0; ii < token.Product.RoleInfoArray[i].FunctionInfoArray.Length; ii++ )
                        {
                            companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray[ii] = new FunctionInfoWork();
                            companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray[ii].FunctionCode = token.Product.RoleInfoArray[i].FunctionInfoArray[ii].FunctionCode;
                            companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray[ii].FunctionName = token.Product.RoleInfoArray[i].FunctionInfoArray[ii].FunctionName;
                            companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray[ii].FunctionDescription = token.Product.RoleInfoArray[i].FunctionInfoArray[ii].FunctionDescription;
                        }
                    }
                }
            }

            return companyAuthInfoWork;
        }
    }
}
