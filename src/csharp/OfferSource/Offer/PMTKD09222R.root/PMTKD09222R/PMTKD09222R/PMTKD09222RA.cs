
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using System.Collections.Generic;
using Microsoft.Win32;

using System.Threading;  // ADD 2010/07/02
using System.Xml.Serialization; // ADD 2010/07/02

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// �񋟃}�[�W�Ώی��������[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �񋟃}�[�W�Ώی��������[�g�I�u�W�F�N�g</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.08</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note: �D�ǉ��i�擾���ɁA�D�Ǖ��i���璆���ށABL�R�[�h���擾����(MANTIS[0015332])</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/04/26</br>    
    /// <br></br>
    /// <br>Update Note: ���׌y���Ή�</br>
    /// <br>Programmer : 22008�@���� ���n</br>
    /// <br>Date       : 2010/05/20</br>    
    /// <br></br>
    /// <br>Update Note: ��DB�����Ή�</br>
    /// <br>Programmer : 22008�@���� ���n</br>
    /// <br>Date       : 2010/06/14</br>    
    /// <br></br>
    /// <br>Update Note: �ڑ������Ή�</br>
    /// <br>Programmer : 22008�@���� ���n</br>
    /// <br>Date       : 2010/07/02</br>    
    /// <br></br>
    /// <br>Update Note: �D�Ǖ��i�A�D�ǉ��i�擾���ɁA�D�ǃ��[�J�[�̂ݎ擾����</br>
    /// <br>Programmer : �e�c ���V</br>
    /// <br>Date       : 2013/04/02</br>    
    /// <br></br>
    /// <br>Update Note: SCM������ C������ʓ��L�Ή�</br>
    /// <br>Programmer : ���� ��</br>
    /// <br>Date       : 2015/02/23</br>
    /// <br></br>
    /// <br>Update Note: 11370006-00 �n���f�B�^�[�~�i���Ή�</br>
    /// <br>             �o�[�R�[�h�}�X�^�X�V�ǉ��Ή�</br>
    /// <br>Programmer : �e�c ���V</br>
    /// <br>Date       : 2017/08/01</br>
    /// </remarks>
    [Serializable]
    public class MergeDataGetDB : RemoteDB, IMergeDataGet
    {
        // -- ADD 2010/07/02 -------------------------------------->>>
        private Semaphore _pool = null;
        private SemaphoreSt sem = null;
        private const string ctSemaphoreFileNm = "SemaphoreSt.xml";
        private const int ctPrimeMaker = 1000;  // ADD 2013/04/02 Y.Wakita
        
        /// <summary>
        ///  �R���X�g���N�^
        /// </summary>
        public MergeDataGetDB()
            : base("PMTKD09224D", "Broadleaf.Application.Remoting.ParamData.PtMkrPriceWork", "MergeDataGet")
        {
            sem = ReadSemaphoreStXml();

            //�Z�}�t�H���L���ɂȂ��Ă����ꍇ
            if (sem.SemaphoreFlg == 1)
            {
                if (_pool == null)
                {
                    //���[�J���Z�}�t�H�̐���
                    _pool = new Semaphore(sem.SemaphoreCnt, sem.SemaphoreCnt);
                }
            }
            else
            {
                _pool = null;
            }

        }

        /// <summary>
        /// �f�X�g���N�^
        /// </summary>
        ~MergeDataGetDB()
        {
            if (_pool != null)
            {
                _pool.Close();
                _pool = null;
            }

        }
        /// <summary>
        /// SemaphoreSt
        /// </summary>
        public class SemaphoreSt
        {
            private int _timeOut;
            private int _semaphoreCnt;
            private int _semaphoreFlg;

            /// <summary>
            /// ���b�N�������̃^�C���A�E�g����
            /// </summary>
            public int TimeOut
            {
                get { return _timeOut; }
                set { _timeOut = value; }
            }


            /// <summary>
            /// �Z�}�t�H�v������l
            /// </summary>
            public int SemaphoreCnt
            {
                get { return _semaphoreCnt; }
                set { _semaphoreCnt = value; }
            }

            /// <summary>
            /// �Z�}�t�H���s�t���O 0:���Ȃ� 1:����
            /// </summary>
            public int SemaphoreFlg
            {
                get { return _semaphoreFlg; }
                set { _semaphoreFlg = value; }
            }

        }

        /// <summary>
        /// xml�擾���\�b�h
        /// </summary>
        private SemaphoreSt ReadSemaphoreStXml()
        {
            FileStream fs = null;
            SemaphoreSt sem = null;

            try
            {

                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\OFFER_AP");
                string path = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\Server002").ToString();
                                            
                fs = new FileStream(Path.Combine(path, ctSemaphoreFileNm), FileMode.Open);
                XmlSerializer xml = new XmlSerializer(typeof(SemaphoreSt));
                sem = (SemaphoreSt)xml.Deserialize(fs);

            }
            catch (Exception)
            {
                //��O����
                sem = new SemaphoreSt();
                sem.TimeOut = 30000;
                sem.SemaphoreCnt = 300;
                sem.SemaphoreFlg = 0;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }

            return sem;

        }
        // -- ADD 2010/07/02 --------------------------------------<<<

        /// <summary>
        /// �񋟂̃}�[�W�f�[�^�擾
        /// </summary>
        /// <param name="offerDate">�擾����񋟃f�[�^�̒񋟓��t</param>
        /// <param name="cond">�擾����</param>
        /// <param name="bigCarOfferDiv">��^�敪</param>
        /// <param name="searchPartsType">�����^�C�v</param>
        /// <param name="retList">�擾���ʂ̃��X�g�iCustomSerializeArrayList�j</param>
        /// <returns>��������</returns>
        public int GetMergeData(int offerDate, MergeInfoGetCond cond, out object retList, int searchPartsType, int bigCarOfferDiv)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retList = null;
            
            status = GetMergeDataProc(offerDate, cond, out retList, searchPartsType, bigCarOfferDiv);

            if (retList == null)
            {
                retList = new ArrayList();
            }
            return status;
        }

        /// <summary>
        /// �񋟂̃}�[�W�f�[�^�擾
        /// </summary>
        /// <param name="offerDate">�擾����񋟃f�[�^�̒񋟓��t</param>
        /// <param name="retList">�擾���ʂ̃��X�g�iCustomSerializeArrayList�j</param>
        /// <param name="cond">�}�[�W�Ώۏ���</param>
        /// <param name="bigCarOfferDiv">��^�敪</param>
        /// <param name="searchPartsType">�����^�C�v</param>
        /// <returns>��������</returns>
        private int GetMergeDataProc(int offerDate, MergeInfoGetCond cond, out object retList, int searchPartsType, int bigCarOfferDiv)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            CustomSerializeArrayList lst = new CustomSerializeArrayList();
            retList = null;

            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }

            ArrayList retPMakerLst = null;
            ArrayList retModelNameLst =null;
            ArrayList objGoodsMGrpLst = null;
            ArrayList objBLGroupLst = null;
            ArrayList retTbsPartsCodeLst = null;
            //object objSupplierLst = null;
            object objPartsPosLst = null;
            // --- ADD 2017/08/01 Y.Wakita ---------->>>>>
            ArrayList objPrmPrtBarcodeLst = null;
            // --- ADD 2017/08/01 Y.Wakita ----------<<<<<

            sqlConnection.Open();
            try
            {
                if (cond.PMakerFlg == 1) // ���[�J�[�}�X�^�}�[�W�u����v��
                {
                    //PMakerNmDB PMakerNmDB = new PMakerNmDB();
                    //status = PMakerNmDB.Search(out retPMakerLst, offerDate);
                    //status = PMakerNmDB.Search(out retPMakerLst, offerDate, sqlConnection, null);
                    status = SearchPmaker(out retPMakerLst, offerDate, sqlConnection);
                    if (status == 0 || status == 4)
                    // ���햔�̓f�[�^���Ȃ������ꍇ
                    {
                        lst.Add(retPMakerLst);
                    }

                }
                if (cond.ModelNameFlg == 1) // �Ԏ�}�X�^�}�[�W�u����v��
                {
                    //ModelNameDB ModelNameDB = new ModelNameDB();
                    //ModelNameWork ModelNameWork = new ModelNameWork();
                    //ModelNameWork.OfferDate = offerDate;
                    //status = ModelNameDB.Search(retModelNameLst, ModelNameWork, sqlConnection, null);
                    status = SearchModelName(out retModelNameLst, offerDate, sqlConnection);
                    if (status == 0 || status == 4) // ���햔�̓f�[�^���Ȃ������ꍇ
                    {
                        lst.Add(retModelNameLst);
                    }
                }


                if (cond.GoodsMGroupFlg == 1) // �����ރ}�X�^�}�[�W�u����v��
                {
                    //GoodsMGroupDB GoodsMGroupDB = new GoodsMGroupDB();
                    //GoodsMGroupWork GoodsMGroupWork = new GoodsMGroupWork();
                    //GoodsMGroupWork.OfferDate = offerDate;
                    //status = GoodsMGroupDB.SearchGoodsMGroupProc(out objGoodsMGrpLst, (object)GoodsMGroupWork, sqlConnection, null);
                    status = SearchGMGroup(out objGoodsMGrpLst, offerDate, sqlConnection);
                    if (status == 0 || status == 4) // ���햔�̓f�[�^���Ȃ������ꍇ
                    {
                        lst.Add(objGoodsMGrpLst);
                    }
                }
                if (cond.BLGroupFlg == 1) // BL�O���[�v�}�X�^�}�[�W�u����v��
                {
                    //BLGroupDB BLGroupDB = new BLGroupDB();
                    //BLGroupWork BLGroupWork = new BLGroupWork();
                    //BLGroupWork.OfferDate = offerDate;
                    //status = BLGroupDB.SearchBLGroupCdProc(out objBLGroupLst, BLGroupWork, sqlConnection, null);
                    status = SearchBLGroup(out objBLGroupLst, offerDate, sqlConnection);
                    if (status == 0 || status == 4) // ���햔�̓f�[�^���Ȃ������ꍇ
                    {
                        lst.Add(objBLGroupLst);
                    }
                }
                if (cond.BLFlg == 1) // BL�R�[�h�}�X�^�}�[�W�u����v��
                {
                    //TbsPartsCodeDB TbsPartsCodeDB = new TbsPartsCodeDB();
                    //TbsPartsCodeWork TbsPartsCodeWork = new TbsPartsCodeWork();
                    //TbsPartsCodeWork.OfferDate = offerDate;
                    //status = TbsPartsCodeDB.SearchTbsPartsCodeProc(out retTbsPartsCodeLst, TbsPartsCodeWork, ref sqlConnection);
                    status = SearchBLcd(out retTbsPartsCodeLst, offerDate, ref sqlConnection);
                    if (status == 0 || status == 4) // ���햔�̓f�[�^���Ȃ������ꍇ
                    {
                        lst.Add(retTbsPartsCodeLst);
                    }
                }
                if (cond.PrmSetFlg == 1) // �D�ǐݒ�}�X�^�}�[�W�u����v��
                {
                    PrmSettingWork PrmSettingWork = new PrmSettingWork();
                    PrmSettingWork.OfferDate = offerDate;
                    ArrayList retPrmSettingLst = new ArrayList();
                    status = this.PrmSettingWorkSerch(out retPrmSettingLst, PrmSettingWork, ref sqlConnection);
                    if (status == 0 || status == 4) // ���햔�̓f�[�^���Ȃ������ꍇ
                    {
                        lst.Add(retPrmSettingLst);
                    }
                }
                if (cond.PrmSetChgFlg == 1) //�D�ǐݒ�ύX�}�X�^�}�[�W�u����v��
                {
                    PrmSettingChgWork PrmSettingChgWork = new PrmSettingChgWork();
                    PrmSettingChgWork.OfferDate = offerDate;
                    ArrayList retPrmSettingChgLst = new ArrayList();
                    status = this.PrmSettingChgWorkSerch(out retPrmSettingChgLst, PrmSettingChgWork, ref sqlConnection);
                    if (status == 0 || status == 4) // ���햔�̓f�[�^���Ȃ������ꍇ
                    {
                        lst.Add(retPrmSettingChgLst);
                    }
                }

                //if (offerDate == 0 && // �����}�[�W
                //    (status == 0 || status == 4)) // ���햔�̓f�[�^���Ȃ������ꍇ
                //{
                //    lst.Add(retTbsPartsCodeLst);

                //    OfrSupplierDB OfrSupplierDB = new OfrSupplierDB();
                //    status = OfrSupplierDB.SearchProc(out objSupplierLst, null, sqlConnection, null);
                //    lst.Add(objSupplierLst);
                //}

                //if (offerDate == 0 && // �����}�[�W
                //    (status == 0 || status == 4)) // ���햔�̓f�[�^���Ȃ������ꍇ
                if (cond.PartsPosFlg == 1) // ���ʃ}�X�^�}�[�W�u����v��
                {
                    PartsPosCodeDB PartsPosCodeDB = new PartsPosCodeDB();
                    PartsPosCodeWork partsPosCodeWork = new PartsPosCodeWork();
                    //partsPosCodeWork.OfferDate = offerDate;
                    partsPosCodeWork.BigCarOfferDiv = bigCarOfferDiv;
                    partsPosCodeWork.SearchPartsType = searchPartsType;
                    status = PartsPosCodeDB.SearchProc(out objPartsPosLst, partsPosCodeWork, sqlConnection, null);
                    if (status == 0 || status == 4) // ���햔�̓f�[�^���Ȃ������ꍇ
                    {
                        lst.Add(objPartsPosLst);
                    }
                }

                // --- ADD 2017/08/01 Y.Wakita ---------->>>>>
                if (cond.PrmPrtBarcodeFlg == 1) // �D�Ǖ��i�o�[�R�[�h�}�X�^�}�[�W�u����v��
                {
                    status = SearchBLGroup(out objPrmPrtBarcodeLst, offerDate, sqlConnection);
                    if (status == 0 || status == 4) // ���햔�̓f�[�^���Ȃ������ꍇ
                    {
                        lst.Add(objPrmPrtBarcodeLst);
                    }
                }
                // --- ADD 2017/08/01 Y.Wakita ----------<<<<<

                if (status == 0 || status == 4) // ���햔�̓f�[�^���Ȃ������ꍇ
                {
                    retList = lst;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    retList = new ArrayList();
                }
            }
            catch
            {
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        #region BL�R�[�h
        private int SearchBLcd(out ArrayList retTbsPartsCodeLst, int offerDate, ref SqlConnection sqlConnection)
        {
            int status = 4;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = string.Empty;
            retTbsPartsCodeLst = new ArrayList();
            try
            {
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "	 OFFERDATERF" + Environment.NewLine;
                sqlText += "	,GOODSMGROUPRF" + Environment.NewLine;
                sqlText += "	,BLGROUPCODERF" + Environment.NewLine;
                sqlText += "	,TBSPARTSCODERF" + Environment.NewLine;
                sqlText += "	,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                sqlText += "	,TBSPARTSFULLNAMERF" + Environment.NewLine;
                sqlText += "	,TBSPARTSHALFNAMERF" + Environment.NewLine;
                sqlText += "	,EQUIPGENRERF" + Environment.NewLine;
                sqlText += "	,PRIMESEARCHFLGRF" + Environment.NewLine;
                sqlText += " FROM TBSPARTSCODERF" + Environment.NewLine;
                sqlText += " WHERE OFFERDATERF = @OFFERDATE" + Environment.NewLine;
                sqlText += " AND (TBSPARTSCDDERIVEDNORF IS NULL OR TBSPARTSCDDERIVEDNORF = 0)" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                SqlParameter findOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                findOfferDate.Value = SqlDataMediator.SqlSetInt32(offerDate);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    TbsPartsCodeWork tbsPartsCodeWork = new TbsPartsCodeWork();
                    tbsPartsCodeWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    tbsPartsCodeWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    tbsPartsCodeWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    tbsPartsCodeWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    tbsPartsCodeWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    tbsPartsCodeWork.TbsPartsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSFULLNAMERF"));
                    tbsPartsCodeWork.TbsPartsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TBSPARTSHALFNAMERF"));
                    tbsPartsCodeWork.EquipGenre = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRERF"));
                    tbsPartsCodeWork.PrimeSearchFlg = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMESEARCHFLGRF"));
                    retTbsPartsCodeLst.Add(tbsPartsCodeWork);
                }
                if (retTbsPartsCodeLst.Count > 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                else
                    status = 4;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && myReader.IsClosed == false) myReader.Close();
            }
            return status;
        }
        #endregion

        #region BL�O���[�v�R�[�h
        private int SearchBLGroup(out ArrayList objBLGroupLst, int offerDate, SqlConnection sqlConnection)
        {
            int status = 4;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = string.Empty;
            objBLGroupLst = new ArrayList();
            try
            {
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "     OFFERDATERF" + Environment.NewLine;
                sqlText += "    ,GOODSMGROUPRF" + Environment.NewLine;
                sqlText += "    ,BLGROUPCODERF" + Environment.NewLine;
                sqlText += "    ,BLGROUPNAMERF" + Environment.NewLine;
                sqlText += "    ,BLGROUPKANANAMERF" + Environment.NewLine;
                sqlText += " FROM BLGROUPRF" + Environment.NewLine;
                sqlText += " WHERE OFFERDATERF = @OFFERDATE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                SqlParameter findOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                findOfferDate.Value = SqlDataMediator.SqlSetInt32(offerDate);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    BLGroupWork bLGroupWork = new BLGroupWork();
                    bLGroupWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    bLGroupWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    bLGroupWork.BLGroupCode= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    bLGroupWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
                    bLGroupWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
                    objBLGroupLst.Add(bLGroupWork);
                }
                if (objBLGroupLst.Count > 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                else
                    status = 4;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && myReader.IsClosed == false) myReader.Close();
            }
            return status;
        }
        #endregion

        #region ���i������
        private int SearchGMGroup(out ArrayList objGoodsMGrpLst, int offerDate, SqlConnection sqlConnection)
        {
            int status = 4;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = string.Empty;
            objGoodsMGrpLst = new ArrayList();
            try
            {
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "     OFFERDATERF" + Environment.NewLine;
                sqlText += "    ,GOODSMGROUPRF" + Environment.NewLine;
                sqlText += "    ,GOODSMGROUPNAMERF" + Environment.NewLine;
                sqlText += " FROM GOODSMGROUPRF" + Environment.NewLine;
                sqlText += " WHERE OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                SqlParameter findOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                findOfferDate.Value = SqlDataMediator.SqlSetInt32(offerDate);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    GoodsMGroupWork goodsMGroupWork = new GoodsMGroupWork();
                    goodsMGroupWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    goodsMGroupWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    goodsMGroupWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
                    objGoodsMGrpLst.Add(goodsMGroupWork);
                }
                if (objGoodsMGrpLst.Count > 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                else
                    status = 4;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && myReader.IsClosed == false) myReader.Close();
            }
            return status;
        }
        #endregion

        #region �Ԏ���擾
        private int SearchModelName(out ArrayList retModelNameLst, int offerDate, SqlConnection sqlConnection)
        {
            int status = 4;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = string.Empty;
            retModelNameLst = new ArrayList();
            try
            {
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "OFFERDATERF, " + Environment.NewLine;
                sqlText += "MODELUNIQUECODERF, " + Environment.NewLine;
                sqlText += "MAKERCODERF, " + Environment.NewLine;
                sqlText += "MODELCODERF, " + Environment.NewLine;
                sqlText += "MODELSUBCODERF, " + Environment.NewLine;
                sqlText += "MODELFULLNAMERF, " + Environment.NewLine;
                sqlText += "MODELHALFNAMERF, " + Environment.NewLine;
                sqlText += "MODELALIASNAMERF " + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  MODELNAMERF " + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += " OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                
                SqlParameter findOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                findOfferDate.Value = SqlDataMediator.SqlSetInt32(offerDate);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    ModelNameWork modelNameWork = new ModelNameWork();
                    modelNameWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    modelNameWork.ModelUniqueCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELUNIQUECODERF"));
                    modelNameWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                    modelNameWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                    modelNameWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                    modelNameWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                    modelNameWork.ModelAliasName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELALIASNAMERF"));
                    modelNameWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    retModelNameLst.Add(modelNameWork);
                }
                if (retModelNameLst.Count > 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                else
                    status = 4;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && myReader.IsClosed == false) myReader.Close();
            }
            return status;
        }
        #endregion

        #region ���[�J�[���擾
        private int SearchPmaker(out ArrayList retPMakerLst, int offerDate, SqlConnection sqlConnection)
        {
            int status = 4;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = string.Empty;
            retPMakerLst = new ArrayList();
            try
            {
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "     OFFERDATERF" + Environment.NewLine;
                sqlText += "    ,PARTSMAKERCODERF" + Environment.NewLine;
                sqlText += "    ,PARTSMAKERFULLNAMERF" + Environment.NewLine;
                sqlText += "    ,PARTSMAKERHALFNAMERF" + Environment.NewLine;
                sqlText += " FROM PMAKERNMRF" + Environment.NewLine;
                sqlText += " WHERE OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                SqlParameter findOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                findOfferDate.Value = SqlDataMediator.SqlSetInt32(offerDate);
                
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    PMakerNmWork pMakerNmWork = new PMakerNmWork();
                    pMakerNmWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    pMakerNmWork.PartsMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCODERF"));
                    pMakerNmWork.PartsMakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMAKERFULLNAMERF"));
                    pMakerNmWork.PartsMakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMAKERHALFNAMERF"));
                    retPMakerLst.Add(pMakerNmWork);
                }
                if (retPMakerLst.Count > 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                else
                    status = 4;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && myReader.IsClosed == false) myReader.Close();
            }
            return status;
        }
        #endregion

        /// <summary>
        /// �񋟂̕��i���擾
        /// </summary>
        /// <param name="offerDate">�擾����񋟃f�[�^�̒񋟓��t</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">(�������i,�D�Ǖ��i�p)�O��i��</param>
        /// <param name="goodsPriceNo">(�D�ǉ��i�p)�i��</param>
        /// <param name="retList">�擾���ʂ̃��X�g�iCustomSerializeArrayList�j</param>
        /// <returns>��������</returns>
        public int GetGoodsInfo(int offerDate, int makerCode, string goodsNo, string goodsPriceNo, out object retList)
        {
            // -- UPD 2010/07/02 ---------------------------------->>>
            //return GetGoodsInfoProc(offerDate, makerCode, goodsNo, goodsPriceNo, out retList);

            //�Z�}�t�H���L���ɂȂ��Ă����ꍇ
            if (_pool == null)
            {
                sem = ReadSemaphoreStXml();

                if (sem.SemaphoreFlg == 1)
                {
                    //���[�J���Z�}�t�H�̐���
                    _pool = new Semaphore(sem.SemaphoreCnt, sem.SemaphoreCnt);
                }
                else
                {
                    _pool = null;
                }
            }

            if (_pool != null)
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                bool flg = false;
                retList = new CustomSerializeArrayList();

                try
                {
                    flg = _pool.WaitOne(sem.TimeOut,false);

                    if (flg)
                    {
                        status = GetGoodsInfoProc(offerDate, makerCode, goodsNo, goodsPriceNo, out retList);
                    }
                    else
                    {
                        //�^�C���A�E�g
                        base.WriteErrorLog("MergeDataGetDB.GetGoodsInfo Semaphore�Ń��b�N�^�C���A�E�g����");
                    }
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "MergeDataGetDB.GetGoodsInfo ��O����");
                }
                finally
                {
                    if (flg)
                    {
                        //�Z�}�t�H�̃��b�N�ɐ������Ă����ꍇ�͉������B
                        try
                        {
                            _pool.Release();
                        }
                        catch (SemaphoreFullException ex)
                        {
                            //�S�ĉ������Ă����ꍇ�̗�O
                            base.WriteErrorLog(ex, "MergeDataGetDB.GetGoodsInfo Semaphore����G���[");
                        }
                        catch (Exception ex)
                        {
                            base.WriteErrorLog(ex, "MergeDataGetDB.GetGoodsInfo Semaphore����G���[");
                        }
                    }
                }

                return status;
            }
            else
            {
                //�Z�}�t�H�������̏ꍇ�͊�������
                return GetGoodsInfoProc(offerDate, makerCode, goodsNo, goodsPriceNo, out retList);
            }
            // -- UPD 2010/07/02 ----------------------------------<<<
        }

        /// <summary>
        /// �񋟂̕��i���擾
        /// </summary>
        /// <param name="offerDate">�擾����񋟃f�[�^�̒񋟓��t</param>
        /// <param name="retList">�擾���ʂ̃��X�g�iCustomSerializeArrayList�j</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�O��i��</param>
        /// <param name="goodsPriceNo"></param>
        /// <returns>��������</returns>
        private int GetGoodsInfoProc(int offerDate, int makerCode, string goodsNo , string goodsPriceNo, out object retList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            CustomSerializeArrayList lst = new CustomSerializeArrayList();
            //retList = null;
            retList = new ArrayList();

            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            ArrayList lstPtMkrPrice = null;
            ArrayList lstPrimParts = null;
            ArrayList lstPrimPrice = null;
            sqlConnection.Open();
            try
            {
                status = GetPartsPrice(offerDate, makerCode, goodsNo, out lstPtMkrPrice, sqlConnection);
                if (status == 0 || status == 4)
                {
                    lst.Add(lstPtMkrPrice);
                    status = GetPrimeParts(offerDate, makerCode, goodsNo, out lstPrimParts, sqlConnection);
                }
                if (status == 0 || status == 4)
                {
                    lst.Add(lstPrimParts);
                    status = GetPrimePrice(offerDate, makerCode, goodsPriceNo, out lstPrimPrice, sqlConnection);
                }
                if (status == 0 || status == 4)
                {
                    lst.Add(lstPrimPrice);
                }
                retList = lst;
                if (lst.Count > 0)
                    status = 0;
                else
                    retList = new ArrayList();
            }
            catch
            {
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// �������i���̎擾
        /// </summary>
        /// <param name="offerDate"></param>
        /// <param name="lstPtMkrPrice"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�O��i��</param>
        /// <returns></returns>
        private int GetPartsPrice(int offerDate, int makerCode, string goodsNo, out ArrayList lstPtMkrPrice, SqlConnection sqlConnection)
        {
            int status = 4;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string selectstr = string.Empty;

            lstPtMkrPrice = new ArrayList();
            try
            {
                // -- UPD 2010/05/20 ------------------>>>
                //selectstr += "SELECT TOP 100000 ";
                selectstr += "SELECT TOP 10000 ";
                // -- UPD 2010/05/20 ------------------<<<
                selectstr += "PTMKRPRICERF.OFFERDATERF, ";
                selectstr += "PTMKRPRICERF.PARTSPRICEREVCDRF, ";
                selectstr += "PTMKRPRICERF.MAKERCODERF, ";
                selectstr += "PTMKRPRICERF.NEWPRTSNOWITHHYPHENRF, ";
                selectstr += "PTMKRPRICERF.NEWPRTSNONONEHYPHENRF, ";
                selectstr += "PTMKRPRICERF.PARTSPRICESTDATERF, ";
                selectstr += "PTMKRPRICERF.TBSPARTSCODERF, ";
                selectstr += "PTMKRPRICERF.TBSPARTSCDDERIVEDNORF, ";
                selectstr += "PTMKRPRICERF.MAKEROFFERPARTSNAMERF, ";
                selectstr += "PTMKRPRICERF.MAKEROFFERPARTSKANARF, ";
                selectstr += "PTMKRPRICERF.PARTSPRICERF, ";
                selectstr += "PTMKRPRICERF.PARTSLAYERCDRF, ";
                selectstr += "PTMKRPRICERF.OPENPRICEDIVRF  ";
                // -- UPD 2010/06/14 ---------------------------->>>
                //selectstr += "FROM PTMKRPRICERF ";
                selectstr += "FROM PTMKRPRICEPMRF AS PTMKRPRICERF ";
                // -- UPD 2010/06/14 ----------------------------<<<
                selectstr += "WHERE OFFERDATERF = " + offerDate.ToString();
                selectstr += " AND MAKERCODERF = " + makerCode;
                selectstr += " AND NEWPRTSNOWITHHYPHENRF > " + "'" +goodsNo + "' ";
                selectstr += "ORDER BY NEWPRTSNOWITHHYPHENRF ";

                sqlCommand = new SqlCommand(selectstr, sqlConnection);
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())

                {
                    PtMkrPriceWork PtMkrPriceWork = new PtMkrPriceWork();

                    PtMkrPriceWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    PtMkrPriceWork.PartsPriceRevCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSPRICEREVCDRF"));
                    PtMkrPriceWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    PtMkrPriceWork.NewPrtsNoWithHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNOWITHHYPHENRF"));
                    PtMkrPriceWork.NewPrtsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NEWPRTSNONONEHYPHENRF"));
                    PtMkrPriceWork.PartsPriceStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSPRICESTDATERF"));
                    PtMkrPriceWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    PtMkrPriceWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    PtMkrPriceWork.MakerOfferPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSNAMERF"));
                    PtMkrPriceWork.MakerOfferPartsKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKEROFFERPARTSKANARF"));
                    PtMkrPriceWork.PartsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PARTSPRICERF"));
                    PtMkrPriceWork.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    PtMkrPriceWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

                    lstPtMkrPrice.Add(PtMkrPriceWork);
                }
                if (lstPtMkrPrice.Count > 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                else
                    status = 4;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (myReader != null && myReader.IsClosed == false)
                    myReader.Close();
            }
            return status;
        }

        private int GetPrimeParts(int offerDate, int makerCode, string goodsNo, out ArrayList lstPrimParts, SqlConnection sqlConnection)
        {
            int status = 4;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string selectstr = string.Empty;

            lstPrimParts = new ArrayList();
            try
            {
                // -- UPD 2010/05/20 ------------------>>>
                //selectstr += "SELECT TOP 100000 ";
                selectstr += "SELECT TOP 10000 ";
                // -- UPD 2010/05/20 ------------------<<<
                selectstr += "PRIMEPARTSRF.OFFERDATERF, ";
                selectstr += "PRIMEPARTSRF.GOODSMGROUPRF, ";
                selectstr += "PRIMEPARTSRF.TBSPARTSCODERF, ";
                selectstr += "PRIMEPARTSRF.TBSPARTSCDDERIVEDNORF, ";
                selectstr += "PRIMEPARTSRF.PRMSETDTLNO1RF, ";
                selectstr += "PRIMEPARTSRF.PARTSMAKERCDRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNONONEHRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSNAMERF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSKANANMRF, ";
                selectstr += "PRIMEPARTSRF.PARTSLAYERCDRF, ";
                selectstr += "PRIMEPARTSRF.PRIMEPARTSSPECIALNOTERF, ";
                selectstr += "PRIMEPARTSRF.PARTSATTRIBUTERF, ";
                selectstr += "PRIMEPARTSRF.CATALOGDELETEFLAGRF, ";
                selectstr += "PRIMEPARTSRF.PRMPARTSILLUSTCRF ";
                selectstr += "FROM PRIMEPARTSRF ";
                selectstr += "WHERE OFFERDATERF = " + offerDate.ToString();
                selectstr += " AND PARTSMAKERCDRF = " + makerCode;
                selectstr += " AND PARTSMAKERCDRF >= " + ctPrimeMaker;     // ADD 2013/04/02 Y.Wakita
                selectstr += " AND PRIMEPARTSNOWITHHRF > " + "'" + goodsNo + "' ";
                selectstr += "ORDER BY PRIMEPARTSNOWITHHRF ";

                sqlCommand = new SqlCommand(selectstr, sqlConnection);
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    PrimePartsWork PrimePartsWork = new PrimePartsWork();

                    PrimePartsWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    PrimePartsWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    PrimePartsWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    PrimePartsWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    PrimePartsWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    PrimePartsWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    PrimePartsWork.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    PrimePartsWork.PrimePartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNONONEHRF"));
                    PrimePartsWork.PrimePartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNAMERF"));
                    PrimePartsWork.PrimePartsKanaNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSKANANMRF"));
                    PrimePartsWork.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    PrimePartsWork.PrimePartsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSSPECIALNOTERF"));
                    PrimePartsWork.PartsAttribute = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSATTRIBUTERF"));
                    PrimePartsWork.CatalogDeleteFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATALOGDELETEFLAGRF"));
                    PrimePartsWork.PrmPartsIllustC = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMPARTSILLUSTCRF"));

                    lstPrimParts.Add(PrimePartsWork);
                }
                if (lstPrimParts.Count > 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                else
                    status = 4;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (myReader != null && myReader.IsClosed == false)
                    myReader.Close();
            }
            return status;
        }

        private int GetPrimePrice(int offerDate, int makerCode, string goodsPriceNo, out ArrayList lstPrimPrice, SqlConnection sqlConnection)
        {
            int status = 4;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string selectstr = string.Empty;

            lstPrimPrice = new ArrayList();
            try
            {
                // -- UPD 2010/05/20 ------------------>>>
                //selectstr += "SELECT TOP 100000 ";
                selectstr += "SELECT TOP 10000 ";
                // -- UPD 2010/05/20 ------------------<<<
                selectstr += "PRMPRTPRICERF.OFFERDATERF, ";
                selectstr += "PRMPRTPRICERF.PRMSETDTLNO1RF, ";
                selectstr += "PRMPRTPRICERF.PARTSMAKERCDRF, ";
                selectstr += "PRMPRTPRICERF.PRIMEPARTSNOWITHHRF, ";
                selectstr += "PRMPRTPRICERF.PRICESTARTDATERF, ";
                selectstr += "PRMPRTPRICERF.NEWPRICERF, ";
                selectstr += "PRMPRTPRICERF.OPENPRICEDIVRF ";
                // 2010/04/26 Add >>>
                selectstr += ",PARTS.GOODSMGROUPRF ";
                selectstr += ",PARTS.TBSPARTSCODERF ";
                // 2010/04/26 Add <<<
                selectstr += "FROM PRMPRTPRICERF ";
                // 2010/04/26 >>>
                //selectstr += "WHERE OFFERDATERF = " + offerDate.ToString();
                //selectstr += " AND PARTSMAKERCDRF = " + makerCode;
                //selectstr += " AND PRIMEPARTSNOWITHHRF > " + "'" + goodsPriceNo + "' ";
                //selectstr += "ORDER BY PRIMEPARTSNOWITHHRF ";
                selectstr += "LEFT JOIN PRIMEPARTSRF AS PARTS ON ";
                selectstr += "PARTS.PARTSMAKERCDRF = PRMPRTPRICERF.PARTSMAKERCDRF ";
                selectstr += "AND PARTS.PRIMEPARTSNOWITHHRF = PRMPRTPRICERF.PRIMEPARTSNOWITHHRF ";
                selectstr += "AND PARTS.PRMSETDTLNO1RF = PRMPRTPRICERF.PRMSETDTLNO1RF ";
                selectstr += "WHERE PRMPRTPRICERF.OFFERDATERF = " + offerDate.ToString();
                selectstr += " AND PRMPRTPRICERF.PARTSMAKERCDRF = " + makerCode;
                selectstr += " AND PRMPRTPRICERF.PARTSMAKERCDRF >= " + ctPrimeMaker;     // ADD 2013/04/02 Y.Wakita
                selectstr += " AND PRMPRTPRICERF.PRIMEPARTSNOWITHHRF > " + "'" + goodsPriceNo + "' ";
                selectstr += "ORDER BY PRMPRTPRICERF.PRIMEPARTSNOWITHHRF ";
                // 2010/04/26 <<<

                sqlCommand = new SqlCommand(selectstr, sqlConnection);
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    PrmPrtPriceWork PrmPrtPriceWork = new PrmPrtPriceWork();

                    PrmPrtPriceWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    PrmPrtPriceWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    PrmPrtPriceWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    PrmPrtPriceWork.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    PrmPrtPriceWork.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
                    PrmPrtPriceWork.NewPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NEWPRICERF"));
                    PrmPrtPriceWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    // 2010/04/23 Add >>>
                    PrmPrtPriceWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    PrmPrtPriceWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    // 2010/04/23 Add <<<

                    lstPrimPrice.Add(PrmPrtPriceWork);
                }
                if (lstPrimPrice.Count > 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                else
                    status = 4;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();
                if (myReader != null && myReader.IsClosed == false)
                    myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// ���i���������̍ŐV�񋟓��t�擾
        /// </summary>
        /// <param name="blDate">BL�R�[�h</param>
        /// <param name="goodsMDate">������</param>
        /// <param name="groupDate">BL�O���[�v</param>
        /// <param name="makerDate">���i���[�J�[</param>
        /// <param name="modelNmDate">�Ԏ�</param>
        /// <param name="partsPosDate">����</param>
        /// <param name="priceDate">���i���i</param>
        /// <param name="primPartsDate">�D�ǉ��i</param>
        /// <param name="prmSetChgDate">�D�ǐݒ�ύX</param>
        /// <param name="prmSetDate">�D��</param>
        /// <param name="offerDateList">�񋟓��t���X�g</param>
        /// <param name="bigCarOfferDiv">��^�񋟋敪</param>
        /// <param name="searchPartsType">�����^�C�v</param>
        /// <returns></returns>
        public int GetOfferDate(int blDate, int groupDate, int goodsMDate, int modelNmDate, int makerDate, int partsPosDate,
            int priceDate, int primPartsDate, int prmSetDate, int prmSetChgDate, int searchPartsType, int bigCarOfferDiv, out object offerDateList)
        //public int GetOfferDate(PriceUpdManualDataWork st, out object offerDateList)
        {
            return GetOfferDateProc(blDate, groupDate, goodsMDate, modelNmDate, makerDate, partsPosDate,
            priceDate, primPartsDate, prmSetDate, prmSetChgDate, searchPartsType, bigCarOfferDiv, out offerDateList);
        }

        /// <summary>
        /// ���i���������̍ŐV�񋟓��t�擾
        /// </summary>
        /// <param name="blDate">BL�R�[�h</param>
        /// <param name="goodsMDate">������</param>
        /// <param name="groupDate">BL�O���[�v</param>
        /// <param name="makerDate">���i���[�J�[</param>
        /// <param name="modelNmDate">�Ԏ�</param>
        /// <param name="partsPosDate">����</param>
        /// <param name="priceDate">���i���i</param>
        /// <param name="primPartsDate">�D�ǉ��i</param>
        /// <param name="prmSetChgDate">�D�ǐݒ�ύX</param>
        /// <param name="prmSetDate">�D��</param>
        /// <param name="offerDataList">�񋟓��t���X�g</param>
        /// <param name="bigCarOfferDiv">��^�񋟋敪</param>
        /// <param name="searchPartsType">�����^�C�v</param>
        /// <returns></returns>
        public int GetOfferDateProc(int blDate, int groupDate, int goodsMDate, int modelNmDate, int makerDate, int partsPosDate,
            int priceDate, int primPartsDate, int prmSetDate, int prmSetChgDate, int searchPartsType, int bigCarOfferDiv, out object offerDataList)
        //public int GetOfferDateProc(PriceUpdManualDataWork st, out object offerDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //CustomSerializeArrayList offerList = new CustomSerializeArrayList();
            offerDataList = null;

            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }

            ArrayList offerList = null;
            sqlConnection.Open();
            try
            {
                status = GetOfferDateProcProc(blDate, groupDate, goodsMDate, modelNmDate, makerDate, partsPosDate,
                priceDate, primPartsDate, prmSetDate, prmSetChgDate, searchPartsType, bigCarOfferDiv, out offerList, ref  sqlConnection);
                //status = GetOfferDateProcProc(st, out offerList, ref  sqlConnection);

                offerDataList = offerList;
                if (offerList.Count > 0)
                {
                    status = 0;
                }
            }
            catch
            {
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// ���i���������̍ŐV�񋟓��t�擾
        /// </summary>
        /// <param name="blDate">BL�R�[�h</param>
        /// <param name="goodsMDate">������</param>
        /// <param name="groupDate">BL�O���[�v</param>
        /// <param name="makerDate">���i���[�J�[</param>
        /// <param name="modelNmDate">�Ԏ�</param>
        /// <param name="partsPosDate">����</param>
        /// <param name="priceDate">���i���i</param>
        /// <param name="primPartsDate">�D�ǉ��i</param>
        /// <param name="prmSetChgDate">�D�ǐݒ�ύX</param>
        /// <param name="prmSetDate">�D��</param>
        /// <param name="offerList">�񋟓��t���X�g</param>
        /// <param name="bigCarOfferDiv">��^�񋟋敪</param>
        /// <param name="searchPartsType">�����^�C�v</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns></returns>
        private int GetOfferDateProcProc(int blDate, int groupDate, int goodsMDate, int modelNmDate, int makerDate, int partsPosDate,
            int priceDate, int primPartsDate, int prmSetDate, int prmSetChgDate, int searchPartsType, int bigCarOfferDiv
            , out ArrayList offerList, ref SqlConnection sqlConnection)
        //private int GetOfferDateProcProc(PriceUpdManualDataWork st, out ArrayList offerList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;


            string sqlText = string.Empty;

            Dictionary<DateTime, PriceUpdManualDataWork> PrmList = new Dictionary<DateTime, PriceUpdManualDataWork>(); 

            offerList = new ArrayList();
            try
            {
                #region BL�R�[�h
                sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM TBSPARTSCODERF WHERE OFFERDATERF > @OFFERDATE AND (TBSPARTSCDDERIVEDNORF IS NULL OR TBSPARTSCDDERIVEDNORF = 0)) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM TBSPARTSCODERF WHERE OFFERDATERF > @OFFERDATE AND (TBSPARTSCDDERIVEDNORF IS NULL OR TBSPARTSCDDERIVEDNORF = 0)) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM TBSPARTSCODERF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += " AND (TBSPARTSCDDERIVEDNORF IS NULL OR TBSPARTSCDDERIVEDNORF = 0)" + Environment.NewLine;
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                SqlParameter findOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                findOfferDate.Value = SqlDataMediator.SqlSetInt32(blDate);

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 0));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region BL�O���[�v
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM BLGROUPRF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM BLGROUPRF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM BLGROUPRF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(groupDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 1));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region ���i������
                 sqlText = string.Empty;

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM GOODSMGROUPRF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM GOODSMGROUPRF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM GOODSMGROUPRF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(goodsMDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 2));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region �Ԏ�
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM MODELNAMERF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM MODELNAMERF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM MODELNAMERF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(modelNmDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 3));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region ���i���[�J�[����
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM PMAKERNMRF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM PMAKERNMRF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM PMAKERNMRF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(makerDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 4));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region �D�ǐݒ�ύX�}�X�^
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM PRMSETTINGCHGRF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM PRMSETTINGCHGRF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM PRMSETTINGCHGRF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(prmSetChgDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 5));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region �D�ǐݒ�}�X�^
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM PRMSETTINGRF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM PRMSETTINGRF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM PRMSETTINGRF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(prmSetDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 6));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region ���ʃ}�X�^
                sqlText = string.Empty;
                //sqlText += "SELECT" + Environment.NewLine;
                //sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                //sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                //sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM PARTSPOSCODERF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                //sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM PARTSPOSCODERF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                //sqlText += "FROM PARTSPOSCODERF" + Environment.NewLine;
                //sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                //sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                //findOfferDate.Value = SqlDataMediator.SqlSetInt32(partsPosDate);

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "     OFFERDATERF" + Environment.NewLine;
                sqlText += "    ,COUNT(OFFERDATERF) AS SUMCNT" + Environment.NewLine;
                sqlText += " FROM PARTSPOSCODERF" + Environment.NewLine;
                sqlText += " WHERE SEARCHPARTSTYPERF=@SEARCHPARTSTYPE" + Environment.NewLine;
                sqlText += "   AND BIGCAROFFERDIVRF=@BIGCAROFFERDIV" + Environment.NewLine;
                sqlText += " GROUP BY OFFERDATERF" + Environment.NewLine;

                SqlParameter findsearchPartsType = sqlCommand.Parameters.Add("@SEARCHPARTSTYPE", SqlDbType.Int);
                SqlParameter findbigCarOfferDiv = sqlCommand.Parameters.Add("@BIGCAROFFERDIV", SqlDbType.Int);
                findsearchPartsType.Value = SqlDataMediator.SqlSetInt32(searchPartsType);
                findbigCarOfferDiv.Value = SqlDataMediator.SqlSetInt32(bigCarOfferDiv);

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    PriceUpdManualDataWork wkofferDatework = new PriceUpdManualDataWork();
                    wkofferDatework.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    wkofferDatework.allDatacnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMCNT"));
                    wkofferDatework.ReNewOfferDate = wkofferDatework.OfferDate;
                    wkofferDatework.dataCnt = wkofferDatework.dataCnt;
                    wkofferDatework.dataDiv = 7;
                    offerList.Add(wkofferDatework);
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region �D�ǉ��i�}�X�^(���i�}�X�^�Fհ�ް)
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM PRIMEPARTSRF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM PRIMEPARTSRF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM PRIMEPARTSRF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += "  AND PARTSMAKERCDRF >= " + ctPrimeMaker + Environment.NewLine;     // ADD 2013/04/02 Y.Wakita
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(priceDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //offerList.Add(copyPriceUpdManualDataWork(ref myReader, 8));

                    PriceUpdManualDataWork wkofferDatework = new PriceUpdManualDataWork();

                    wkofferDatework.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    wkofferDatework.ReNewOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RENEWOFFERDATE"));
                    wkofferDatework.dataCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATACNT"));
                    wkofferDatework.allDatacnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMCNT"));
                    wkofferDatework.dataDiv = 8;

                    PrmList.Add(wkofferDatework.OfferDate, wkofferDatework);

                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region �D�Ǖ��i�}�X�^

                // �D�ǉ��i�}�X�^�̍ŐV���t
                DateTime  BeforOfferDate = DateTime.MinValue;
                // �D�ǉ��i�}�X�^�̑���
                int BeforAllCount = 0;
                // ����̂�
                bool flg = false;

                sqlText = string.Empty;
                sqlText += " SELECT " + Environment.NewLine;
                sqlText += "    COUNT(OFFERDATERF) AS DATACNT " + Environment.NewLine;
                sqlText += "   ,OFFERDATERF " + Environment.NewLine;
                sqlText += "   ,(SELECT MAX (OFFERDATERF) FROM PRMPRTPRICERF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE " + Environment.NewLine;
                sqlText += "   ,(SELECT COUNT(OFFERDATERF) FROM PRMPRTPRICERF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT " + Environment.NewLine;
                sqlText += " FROM PRMPRTPRICERF " + Environment.NewLine;
                sqlText += " WHERE OFFERDATERF > @OFFERDATE " + Environment.NewLine;
                sqlText += " AND   PARTSMAKERCDRF >= " + ctPrimeMaker + Environment.NewLine;     // ADD 2013/04/02 Y.Wakita
                sqlText += " GROUP BY OFFERDATERF " + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(priceDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // ���t�̎擾
                    DateTime ofDate   = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    // �ŐV���t�̎擾
                    DateTime reNewOfDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RENEWOFFERDATE"));
                    // ���Ώی����̎擾
                    int SUMcount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMCNT"));

                    int prmStatus = 0;
                    // ���i�}�X�^�̍ŐV���t�̕����V����������
                    if (PrmList.ContainsKey(ofDate))
                    {
                        prmStatus = (PrmList[ofDate].ReNewOfferDate).CompareTo(reNewOfDate);

                        // ���ʕ���
                        foreach (DateTime date in PrmList.Keys)
                        {
                            if (prmStatus <= 0)
                            {
                                // �ŐV���t�̑�����ւ�
                                PrmList[date].ReNewOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RENEWOFFERDATE"));
                                BeforOfferDate = PrmList[date].ReNewOfferDate;
                            }

                            if (flg == false)
                            {
                                // �Ώۑ����𑫂�
                                PrmList[date].allDatacnt += SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMCNT"));
                                BeforAllCount = PrmList[date].allDatacnt;
                            }
                        }
                        flg = true;
                        // �����𑫂�
                        PrmList[ofDate].dataCnt += SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATACNT"));
                    }
                    else
                    {
                        PriceUpdManualDataWork wkofferDatework = new PriceUpdManualDataWork();

                        wkofferDatework.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        
                        if (BeforOfferDate == DateTime.MinValue)
                        {
                            wkofferDatework.ReNewOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RENEWOFFERDATE"));
                        }
                        else
                        {
                            wkofferDatework.ReNewOfferDate = BeforOfferDate;
                        }

                        if (BeforAllCount == 0)
                        {
                            wkofferDatework.dataCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMCNT"));
                        }
                        else
                        {
                            wkofferDatework.allDatacnt = BeforAllCount;
                        }

                        wkofferDatework.dataCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATACNT"));

                        wkofferDatework.dataDiv = 8;

                        PrmList.Add(wkofferDatework.OfferDate, wkofferDatework);
                    }


                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();

                if (PrmList.Count != 0)
                {
                    foreach (PriceUpdManualDataWork _priceUpdManualDataWork in PrmList.Values)
                    {
                        offerList.Add(_priceUpdManualDataWork);
                    }
                }

                #endregion

                #region ���i���i�}�X�^�i���i�}�X�^:հ�ް�j
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                // -- UPD 2010/06/14 ---------------------------------->>>
                //sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM PTMKRPRICERF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                //sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM PTMKRPRICERF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                //sqlText += "FROM PTMKRPRICERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM PTMKRPRICEPMRF AS PTMKRPRICERF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM PTMKRPRICEPMRF AS PTMKRPRICERF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM PTMKRPRICEPMRF AS PTMKRPRICERF" + Environment.NewLine;
                // -- UPD 2010/06/14 ----------------------------------<<<
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(priceDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 9));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "OfferMergeDB.GetUpdateHistoryProc", ex.Number);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (!myReader.IsClosed)
                    myReader.Close();
            }
            return status;
        }

        // �N���X�i�[����
        private PriceUpdManualDataWork copyPriceUpdManualDataWork(ref SqlDataReader myReader, int i)
        {

            PriceUpdManualDataWork wkofferDatework = new PriceUpdManualDataWork();

            wkofferDatework.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkofferDatework.ReNewOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RENEWOFFERDATE"));
            wkofferDatework.dataCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATACNT"));
            wkofferDatework.allDatacnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMCNT"));
            wkofferDatework.dataDiv = i;

            return wkofferDatework;
        }


        // �D�ǐݒ�}�X�^�Ώۃf�[�^���o
        # region
        private int PrmSettingWorkSerch(out ArrayList retPrmSettingLst, PrmSettingWork PrmSettingWork, ref SqlConnection sqlConnection)
        {
            int status = 4;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            retPrmSettingLst = new ArrayList();

            string sqlText = string.Empty;
            try
            {

                sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlText += "SELECT TOP 20000 " + Environment.NewLine;
                sqlText += " OFFERDATERF," + Environment.NewLine;
                sqlText += " GOODSMGROUPRF," + Environment.NewLine;
                sqlText += " PARTSMAKERCDRF," + Environment.NewLine;
                sqlText += " TBSPARTSCODERF," + Environment.NewLine;
                sqlText += " TBSPARTSCDDERIVEDNORF," + Environment.NewLine;
                sqlText += " SECRETCODERF," + Environment.NewLine;
                sqlText += " DISPLAYORDERRF, " + Environment.NewLine;
                sqlText += " PRMSETDTLNO1RF, " + Environment.NewLine;
                sqlText += " PRMSETDTLNAME1RF, " + Environment.NewLine;
                sqlText += " PRMSETDTLNO2RF, " + Environment.NewLine;
                sqlText += " PRMSETDTLNAME2RF, " + Environment.NewLine;
                sqlText += " PRMSETGROUPRF " + Environment.NewLine;
                // 2015/02/23 ADD TAKAGAWA C������ʓ��L�Ή� ---------->>>>>>>>>>
                sqlText += " ,PRMSETDTLNAME2FORFACRF " + Environment.NewLine;
                sqlText += " ,PRMSETDTLNAME2FORCOWRF " + Environment.NewLine;
                // 2015/02/23 ADD TAKAGAWA C������ʓ��L�Ή� ----------<<<<<<<<<<
                sqlText += "FROM PRMSETTINGRF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF=@OFFERDATE" + Environment.NewLine;

                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(PrmSettingWork.OfferDate);

                sqlCommand.CommandText = sqlText;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //�D�ǐݒ茋�ʃN���X
                    PrmSettingWork wkPrimeSettingWork = new PrmSettingWork();

                    #region ���ʃN���X�֊i�[
                    wkPrimeSettingWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    wkPrimeSettingWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    wkPrimeSettingWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    wkPrimeSettingWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    wkPrimeSettingWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    wkPrimeSettingWork.SecretCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECRETCODERF"));
                    wkPrimeSettingWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
                    wkPrimeSettingWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    wkPrimeSettingWork.PrmSetDtlName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME1RF"));
                    wkPrimeSettingWork.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));
                    wkPrimeSettingWork.PrmSetDtlName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2RF"));
                    wkPrimeSettingWork.PrmSetGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETGROUPRF"));
                    // 2015/02/23 ADD TAKAGAWA C������ʓ��L�Ή� ---------->>>>>>>>>>
                    wkPrimeSettingWork.PrmSetDtlName2ForFac = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORFACRF"));
                    wkPrimeSettingWork.PrmSetDtlName2ForCOw = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORCOWRF"));
                    // 2015/02/23 ADD TAKAGAWA C������ʓ��L�Ή� ----------<<<<<<<<<<
                    #endregion

                    retPrmSettingLst.Add(wkPrimeSettingWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "OfferMergeDB.PrmSettingWorkSerch", ex.Number);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (!myReader.IsClosed) 
                    myReader.Close();
            }
            return status;
        }
        #endregion

        //�D�ǐݒ�ύX�}�X�^�Ώۃf�[�^���o
        # region
        private int PrmSettingChgWorkSerch(out ArrayList retPrmSettingChgLst, PrmSettingChgWork PrmSettingChgWork, ref SqlConnection sqlConnection)
        {
            int status = 4;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            retPrmSettingChgLst = new ArrayList();

            string sqlText = string.Empty;
            try
            {

                sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlText += "SELECT TOP 20000 OFFERDATERF" + Environment.NewLine;
                sqlText += "        ,GOODSMGROUPRF" + Environment.NewLine;
                sqlText += "        ,PARTSMAKERCDRF" + Environment.NewLine;
                sqlText += "        ,TBSPARTSCODERF" + Environment.NewLine;
                sqlText += "        ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                sqlText += "        ,PRMSETDTLNO1RF" + Environment.NewLine;
                sqlText += "        ,PRMSETDTLNO2RF" + Environment.NewLine;
                sqlText += "        ,AFPRMSETDTLNO1RF" + Environment.NewLine;
                sqlText += "        ,AFPRMSETDTLNO2RF" + Environment.NewLine;
                sqlText += "        ,AFPRIMEDISPLAYCODERF" + Environment.NewLine;
                sqlText += "        ,PROCDIVCDRF" + Environment.NewLine;
                sqlText += " FROM PRMSETTINGCHGRF" + Environment.NewLine;
                sqlText += " WHERE OFFERDATERF=@OFFERDATE" + Environment.NewLine;

                SqlParameter findOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                findOfferDate.Value = SqlDataMediator.SqlSetInt32(PrmSettingChgWork.OfferDate);

                sqlCommand.CommandText = sqlText;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //�D�ǐݒ茋�ʃN���X
                    PrmSettingChgWork wkPrimeSettingChgWork = new PrmSettingChgWork();

                    #region ���ʃN���X�֊i�[
                    wkPrimeSettingChgWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    wkPrimeSettingChgWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    wkPrimeSettingChgWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    wkPrimeSettingChgWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    wkPrimeSettingChgWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                    wkPrimeSettingChgWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                    wkPrimeSettingChgWork.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));
                    wkPrimeSettingChgWork.AfPrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AFPRMSETDTLNO1RF"));
                    wkPrimeSettingChgWork.AfPrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AFPRMSETDTLNO2RF"));
                    wkPrimeSettingChgWork.AfPrimeDisplayCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AFPRIMEDISPLAYCODERF"));
                    wkPrimeSettingChgWork.ProcDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROCDIVCDRF"));

                    #endregion

                    retPrmSettingChgLst.Add(wkPrimeSettingChgWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "OfferMergeDB.PrmSettingChgWorkSerch", ex.Number);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (!myReader.IsClosed) 
                    myReader.Close();
            }
            return status;
        }
        #endregion

        /// <summary>
        /// 
        /// ���i�����p�X�V���[�J�[�擾
        /// </summary>
        /// <param name="offerDate">�񋟓��t</param>
        /// <param name="makerObj">���[�J�[���X�g</param>
        /// <returns></returns>
        public int GetMakerInfo(int offerDate, out object makerObj)
        {
            return GetMakerInfoProc(offerDate, out makerObj);
        }

        /// <summary>
        /// ���i�����p�X�V���[�J�[�擾
        /// </summary>
        /// <param name="offerDate">�񋟓��t</param>
        /// <param name="makerObj">���[�J�[���X�g</param>
        /// <returns></returns>
        private int GetMakerInfoProc(int offerDate, out object makerObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            makerObj = null;
            Dictionary<int, int> makerList = new Dictionary<int, int>();

            // �R�l�N�V��������
            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null) return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;

            try
            {
                sqlConnection.Open();
                
                // ���i���i�}�X�^
                status = GetMakerPtmkPrice(offerDate, ref makerList, ref sqlConnection);
                if(status != 0 && status != 4) return status;
                if (makerList.Count > 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            makerObj = makerList;
            return status;
        }

        /// <summary>
        /// ���i�����p�X�V���[�J�[�擾
        /// </summary>
        /// <param name="offerDate">�񋟓��t</param>
        /// <param name="makerList">���[�J�[���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns></returns>
        private int GetMakerPtmkPrice(int offerDate, ref  Dictionary<int, int> makerList, ref SqlConnection sqlConnection)
        {
            int status = 4;
            SqlDataReader myReader = null;
            SqlCommand  sqlCommand = null;

            string selectstr = string.Empty;
            int makerCode = 0;
            int Count = 0;

            try
            {
                #region ���i���i�}�X�^
                selectstr += "SELECT ";
                selectstr += " MAKERCODERF ";
                selectstr += ",COUNT(MAKERCODERF) AS CNT ";
                // -- UPD 2010/06/14 ----------------------->>>
                //selectstr += "FROM PTMKRPRICERF ";
                selectstr += "FROM PTMKRPRICEPMRF AS PTMKRPRICERF ";
                // -- UPD 2010/06/14 -----------------------<<<
                selectstr += "WHERE OFFERDATERF = " + offerDate.ToString();
                selectstr += " GROUP BY MAKERCODERF ";

                sqlCommand = new SqlCommand(selectstr, sqlConnection);
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    makerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    Count = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNT"));
                    if (!(makerList.ContainsKey(makerCode))) makerList.Add(makerCode, Count);
                }

                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region �D�Ǖ��i�}�X�^
                selectstr = string.Empty;
                selectstr += "SELECT ";
                selectstr += " PARTSMAKERCDRF ";
                selectstr += ",COUNT(PARTSMAKERCDRF) AS CNT ";
                selectstr += "FROM PRIMEPARTSRF ";
                selectstr += "WHERE OFFERDATERF = " + offerDate.ToString();
                selectstr += "  AND PARTSMAKERCDRF >= " + ctPrimeMaker;     // ADD 2013/04/02 Y.Wakita
                selectstr += " GROUP BY PARTSMAKERCDRF ";

                sqlCommand = new SqlCommand(selectstr, sqlConnection);
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    makerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    Count = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNT"));
                    if (!(makerList.ContainsKey(makerCode))) makerList.Add(makerCode, Count);
                }

                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                // --- UPD 2013/04/02 Y.Wakita ---------->>>>>
                //#region �D�Ǖ��i�}�X�^
                #region �D�ǉ��i�}�X�^
                // --- UPD 2013/04/02 Y.Wakita ----------<<<<<
                selectstr = string.Empty;
                selectstr += "SELECT ";
                selectstr += " PARTSMAKERCDRF ";
                selectstr += ",COUNT(PARTSMAKERCDRF) AS CNT ";
                selectstr += "FROM PRMPRTPRICERF ";
                selectstr += "WHERE OFFERDATERF = " + offerDate.ToString();
                selectstr += "  AND PARTSMAKERCDRF >= " + ctPrimeMaker;     // ADD 2013/04/02 Y.Wakita
                selectstr += " GROUP BY PARTSMAKERCDRF ";

                sqlCommand = new SqlCommand(selectstr, sqlConnection);
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    makerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                    Count = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNT"));
                    if (!(makerList.ContainsKey(makerCode))) makerList.Add(makerCode, Count);
                }

                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion
                if (makerList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                else status = 4;
            }

            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && myReader.IsClosed == false) myReader.Close();
            }
            return status;
        }


        // -- DEL 2010/06/14 ------------------------------------------>>>
        ///// <summary>
        ///// ���i�����p�X�V���[�J�[�擾
        ///// </summary>
        ///// <param name="instalOfferDate">�C���X�g�[�����t�擾</param>
        ///// <returns></returns>
        //public int GetInstalDate(ref DateTime instalOfferDate)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    // ���W�X�g���̎擾
        //    try
        //    {
        //        RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\OFFER_AP\localhost\OFFER_DB");
        //        if (key == null)
        //        {
        //            return status;
        //        }
        //        string InstalOfferDate = key.GetValue("InstallOfferDate").ToString();
        //        int InstDateint = Int32.Parse(InstalOfferDate.Trim());

        //        instalOfferDate = DateTime.Parse(InstDateint.ToString("0000/00/00"));
        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (NullReferenceException)
        //    {
        //        return status;
        //    }
        //    return status;
        //}
        // -- DEL 2010/06/14 ------------------------------------------<<<

        // --- ADD 2017/08/01 Y.Wakita ---------->>>>>
        /// <summary>
        /// ���i���������̍ŐV�񋟓��t�擾
        /// </summary>
        /// <param name="blDate">BL�R�[�h</param>
        /// <param name="goodsMDate">������</param>
        /// <param name="groupDate">BL�O���[�v</param>
        /// <param name="makerDate">���i���[�J�[</param>
        /// <param name="modelNmDate">�Ԏ�</param>
        /// <param name="partsPosDate">����</param>
        /// <param name="priceDate">���i���i</param>
        /// <param name="primPartsDate">�D�ǉ��i</param>
        /// <param name="prmSetChgDate">�D�ǐݒ�ύX</param>
        /// <param name="prmSetDate">�D��</param>
        /// <param name="goodsBarcodeRevnDate">�D�Ǖ��i�o�[�R�[�h</param>
        /// <param name="offerDateList">�񋟓��t���X�g</param>
        /// <param name="bigCarOfferDiv">��^�񋟋敪</param>
        /// <param name="searchPartsType">�����^�C�v</param>
        /// <returns></returns>
        public int GetOfferDate(int blDate, int groupDate, int goodsMDate, int modelNmDate, int makerDate, int partsPosDate,
            int priceDate, int primPartsDate, int prmSetDate, int prmSetChgDate, int goodsBarcodeRevnDate, int searchPartsType, int bigCarOfferDiv, out object offerDateList)
        {
            return GetOfferDateProc(blDate, groupDate, goodsMDate, modelNmDate, makerDate, partsPosDate,
            priceDate, primPartsDate, prmSetDate, prmSetChgDate, goodsBarcodeRevnDate, searchPartsType, bigCarOfferDiv, out offerDateList);
        }

        /// <summary>
        /// ���i���������̍ŐV�񋟓��t�擾
        /// </summary>
        /// <param name="blDate">BL�R�[�h</param>
        /// <param name="goodsMDate">������</param>
        /// <param name="groupDate">BL�O���[�v</param>
        /// <param name="makerDate">���i���[�J�[</param>
        /// <param name="modelNmDate">�Ԏ�</param>
        /// <param name="partsPosDate">����</param>
        /// <param name="priceDate">���i���i</param>
        /// <param name="primPartsDate">�D�ǉ��i</param>
        /// <param name="prmSetChgDate">�D�ǐݒ�ύX</param>
        /// <param name="prmSetDate">�D��</param>
        /// <param name="goodsBarcodeRevnDate">�D�Ǖ��i�o�[�R�[�h</param>
        /// <param name="offerDataList">�񋟓��t���X�g</param>
        /// <param name="bigCarOfferDiv">��^�񋟋敪</param>
        /// <param name="searchPartsType">�����^�C�v</param>
        /// <returns></returns>
        public int GetOfferDateProc(int blDate, int groupDate, int goodsMDate, int modelNmDate, int makerDate, int partsPosDate,
            int priceDate, int primPartsDate, int prmSetDate, int prmSetChgDate, int goodsBarcodeRevnDate, int searchPartsType, int bigCarOfferDiv, out object offerDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            offerDataList = null;

            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }

            ArrayList offerList = null;
            sqlConnection.Open();
            try
            {
                status = GetOfferDateProcProc(blDate, groupDate, goodsMDate, modelNmDate, makerDate, partsPosDate,
                priceDate, primPartsDate, prmSetDate, prmSetChgDate, goodsBarcodeRevnDate, searchPartsType, bigCarOfferDiv, out offerList, ref  sqlConnection);

                offerDataList = offerList;
                if (offerList.Count > 0)
                {
                    status = 0;
                }
            }
            catch
            {
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// ���i���������̍ŐV�񋟓��t�擾
        /// </summary>
        /// <param name="blDate">BL�R�[�h</param>
        /// <param name="goodsMDate">������</param>
        /// <param name="groupDate">BL�O���[�v</param>
        /// <param name="makerDate">���i���[�J�[</param>
        /// <param name="modelNmDate">�Ԏ�</param>
        /// <param name="partsPosDate">����</param>
        /// <param name="priceDate">���i���i</param>
        /// <param name="primPartsDate">�D�ǉ��i</param>
        /// <param name="prmSetChgDate">�D�ǐݒ�ύX</param>
        /// <param name="prmSetDate">�D��</param>
        /// <param name="goodsBarcodeRevnDate">�D�Ǖ��i�o�[�R�[�h</param>
        /// <param name="offerList">�񋟓��t���X�g</param>
        /// <param name="bigCarOfferDiv">��^�񋟋敪</param>
        /// <param name="searchPartsType">�����^�C�v</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns></returns>
        private int GetOfferDateProcProc(int blDate, int groupDate, int goodsMDate, int modelNmDate, int makerDate, int partsPosDate,
            int priceDate, int primPartsDate, int prmSetDate, int prmSetChgDate, int searchPartsType, int goodsBarcodeRevnDate, int bigCarOfferDiv,
            out ArrayList offerList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;

            Dictionary<DateTime, PriceUpdManualDataWork> PrmList = new Dictionary<DateTime, PriceUpdManualDataWork>();

            offerList = new ArrayList();
            try
            {
                #region BL�R�[�h
                sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM TBSPARTSCODERF WHERE OFFERDATERF > @OFFERDATE AND (TBSPARTSCDDERIVEDNORF IS NULL OR TBSPARTSCDDERIVEDNORF = 0)) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM TBSPARTSCODERF WHERE OFFERDATERF > @OFFERDATE AND (TBSPARTSCDDERIVEDNORF IS NULL OR TBSPARTSCDDERIVEDNORF = 0)) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM TBSPARTSCODERF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += " AND (TBSPARTSCDDERIVEDNORF IS NULL OR TBSPARTSCDDERIVEDNORF = 0)" + Environment.NewLine;
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                SqlParameter findOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                findOfferDate.Value = SqlDataMediator.SqlSetInt32(blDate);

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 0));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region BL�O���[�v
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM BLGROUPRF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM BLGROUPRF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM BLGROUPRF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(groupDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 1));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region ���i������
                sqlText = string.Empty;

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM GOODSMGROUPRF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM GOODSMGROUPRF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM GOODSMGROUPRF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(goodsMDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 2));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region �Ԏ�
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM MODELNAMERF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM MODELNAMERF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM MODELNAMERF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(modelNmDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 3));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region ���i���[�J�[����
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM PMAKERNMRF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM PMAKERNMRF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM PMAKERNMRF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(makerDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 4));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region �D�ǐݒ�ύX�}�X�^
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM PRMSETTINGCHGRF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM PRMSETTINGCHGRF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM PRMSETTINGCHGRF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(prmSetChgDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 5));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region �D�ǐݒ�}�X�^
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM PRMSETTINGRF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM PRMSETTINGRF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM PRMSETTINGRF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(prmSetDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 6));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region ���ʃ}�X�^
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "     OFFERDATERF" + Environment.NewLine;
                sqlText += "    ,COUNT(OFFERDATERF) AS SUMCNT" + Environment.NewLine;
                sqlText += " FROM PARTSPOSCODERF" + Environment.NewLine;
                sqlText += " WHERE SEARCHPARTSTYPERF=@SEARCHPARTSTYPE" + Environment.NewLine;
                sqlText += "   AND BIGCAROFFERDIVRF=@BIGCAROFFERDIV" + Environment.NewLine;
                sqlText += " GROUP BY OFFERDATERF" + Environment.NewLine;

                SqlParameter findsearchPartsType = sqlCommand.Parameters.Add("@SEARCHPARTSTYPE", SqlDbType.Int);
                SqlParameter findbigCarOfferDiv = sqlCommand.Parameters.Add("@BIGCAROFFERDIV", SqlDbType.Int);
                findsearchPartsType.Value = SqlDataMediator.SqlSetInt32(searchPartsType);
                findbigCarOfferDiv.Value = SqlDataMediator.SqlSetInt32(bigCarOfferDiv);

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    PriceUpdManualDataWork wkofferDatework = new PriceUpdManualDataWork();
                    wkofferDatework.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    wkofferDatework.allDatacnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMCNT"));
                    wkofferDatework.ReNewOfferDate = wkofferDatework.OfferDate;
                    wkofferDatework.dataCnt = wkofferDatework.dataCnt;
                    wkofferDatework.dataDiv = 7;
                    offerList.Add(wkofferDatework);
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region �D�ǉ��i�}�X�^(���i�}�X�^�Fհ�ް)
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM PRIMEPARTSRF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM PRIMEPARTSRF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM PRIMEPARTSRF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += "  AND PARTSMAKERCDRF >= " + ctPrimeMaker + Environment.NewLine;     // ADD 2013/04/02 Y.Wakita
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(priceDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    PriceUpdManualDataWork wkofferDatework = new PriceUpdManualDataWork();

                    wkofferDatework.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    wkofferDatework.ReNewOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RENEWOFFERDATE"));
                    wkofferDatework.dataCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATACNT"));
                    wkofferDatework.allDatacnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMCNT"));
                    wkofferDatework.dataDiv = 8;

                    PrmList.Add(wkofferDatework.OfferDate, wkofferDatework);

                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region �D�Ǖ��i�}�X�^

                // �D�ǉ��i�}�X�^�̍ŐV���t
                DateTime BeforOfferDate = DateTime.MinValue;
                // �D�ǉ��i�}�X�^�̑���
                int BeforAllCount = 0;
                // ����̂�
                bool flg = false;

                sqlText = string.Empty;
                sqlText += " SELECT " + Environment.NewLine;
                sqlText += "    COUNT(OFFERDATERF) AS DATACNT " + Environment.NewLine;
                sqlText += "   ,OFFERDATERF " + Environment.NewLine;
                sqlText += "   ,(SELECT MAX (OFFERDATERF) FROM PRMPRTPRICERF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE " + Environment.NewLine;
                sqlText += "   ,(SELECT COUNT(OFFERDATERF) FROM PRMPRTPRICERF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT " + Environment.NewLine;
                sqlText += " FROM PRMPRTPRICERF " + Environment.NewLine;
                sqlText += " WHERE OFFERDATERF > @OFFERDATE " + Environment.NewLine;
                sqlText += " AND   PARTSMAKERCDRF >= " + ctPrimeMaker + Environment.NewLine;     // ADD 2013/04/02 Y.Wakita
                sqlText += " GROUP BY OFFERDATERF " + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(priceDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // ���t�̎擾
                    DateTime ofDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    // �ŐV���t�̎擾
                    DateTime reNewOfDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RENEWOFFERDATE"));
                    // ���Ώی����̎擾
                    int SUMcount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMCNT"));

                    int prmStatus = 0;
                    // ���i�}�X�^�̍ŐV���t�̕����V����������
                    if (PrmList.ContainsKey(ofDate))
                    {
                        prmStatus = (PrmList[ofDate].ReNewOfferDate).CompareTo(reNewOfDate);

                        // ���ʕ���
                        foreach (DateTime date in PrmList.Keys)
                        {
                            if (prmStatus <= 0)
                            {
                                // �ŐV���t�̑�����ւ�
                                PrmList[date].ReNewOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RENEWOFFERDATE"));
                                BeforOfferDate = PrmList[date].ReNewOfferDate;
                            }

                            if (flg == false)
                            {
                                // �Ώۑ����𑫂�
                                PrmList[date].allDatacnt += SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMCNT"));
                                BeforAllCount = PrmList[date].allDatacnt;
                            }
                        }
                        flg = true;
                        // �����𑫂�
                        PrmList[ofDate].dataCnt += SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATACNT"));
                    }
                    else
                    {
                        PriceUpdManualDataWork wkofferDatework = new PriceUpdManualDataWork();

                        wkofferDatework.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));

                        if (BeforOfferDate == DateTime.MinValue)
                        {
                            wkofferDatework.ReNewOfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RENEWOFFERDATE"));
                        }
                        else
                        {
                            wkofferDatework.ReNewOfferDate = BeforOfferDate;
                        }

                        if (BeforAllCount == 0)
                        {
                            wkofferDatework.dataCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMCNT"));
                        }
                        else
                        {
                            wkofferDatework.allDatacnt = BeforAllCount;
                        }

                        wkofferDatework.dataCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATACNT"));

                        wkofferDatework.dataDiv = 8;

                        PrmList.Add(wkofferDatework.OfferDate, wkofferDatework);
                    }


                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();

                if (PrmList.Count != 0)
                {
                    foreach (PriceUpdManualDataWork _priceUpdManualDataWork in PrmList.Values)
                    {
                        offerList.Add(_priceUpdManualDataWork);
                    }
                }

                #endregion

                #region ���i���i�}�X�^�i���i�}�X�^:հ�ް�j
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   COUNT(OFFERDATERF) AS DATACNT" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,(SELECT MAX (OFFERDATERF) FROM PTMKRPRICEPMRF AS PTMKRPRICERF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE" + Environment.NewLine;
                sqlText += "  ,(SELECT COUNT(OFFERDATERF) FROM PTMKRPRICEPMRF AS PTMKRPRICERF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT" + Environment.NewLine;
                sqlText += "FROM PTMKRPRICEPMRF AS PTMKRPRICERF" + Environment.NewLine;
                sqlText += "WHERE OFFERDATERF > @OFFERDATE" + Environment.NewLine;
                sqlText += "GROUP BY OFFERDATERF" + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(priceDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 9));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                #region �D�Ǖ��i�o�[�R�[�h�}�X�^
                sqlText = string.Empty;
                sqlText += " SELECT " + Environment.NewLine;
                sqlText += "    COUNT(OFFERDATERF) AS DATACNT " + Environment.NewLine;
                sqlText += "   ,OFFERDATERF " + Environment.NewLine;
                sqlText += "   ,(SELECT MAX  (OFFERDATERF) FROM PRMPRTBRCDRF WHERE OFFERDATERF > @OFFERDATE) AS RENEWOFFERDATE " + Environment.NewLine;
                sqlText += "   ,(SELECT COUNT(OFFERDATERF) FROM PRMPRTBRCDRF WHERE OFFERDATERF > @OFFERDATE) AS SUMCNT " + Environment.NewLine;
                sqlText += " FROM PRMPRTBRCDRF " + Environment.NewLine;
                sqlText += " WHERE OFFERDATERF > @OFFERDATE " + Environment.NewLine;
                sqlText += " AND   PARTSMAKERCODERF >= " + ctPrimeMaker + Environment.NewLine;
                sqlText += " GROUP BY OFFERDATERF " + Environment.NewLine;

                findOfferDate.Value = SqlDataMediator.SqlSetInt32(goodsBarcodeRevnDate);
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    offerList.Add(copyPriceUpdManualDataWork(ref myReader, 10));
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

            }
            catch (SqlException ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "OfferMergeDB.GetUpdateHistoryProc", ex.Number);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (!myReader.IsClosed)
                    myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h�}�X�^�̕��i���[�J�[�擾
        /// </summary>
        /// <param name="offerDate">�񋟓��t</param>
        /// <param name="partsMakerObj">���i���[�J�[���X�g</param>
        /// <returns></returns>
        public int GetPartsMakerInfo(int offerDate, out object partsMakerObj)
        {
            return GetPartsMakerInfoProc(offerDate, out partsMakerObj);
        }

        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h�}�X�^�̕��i���[�J�[�擾
        /// </summary>
        /// <param name="offerDate">�񋟓��t</param>
        /// <param name="partsMakerObj">���i���[�J�[���X�g</param>
        /// <returns></returns>
        private int GetPartsMakerInfoProc(int offerDate, out object partsMakerObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            partsMakerObj = null;
            Dictionary<int, int> partsMakerList = new Dictionary<int, int>();

            // �R�l�N�V��������
            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null) return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;

            try
            {
                sqlConnection.Open();

                // �D�Ǖ��i�o�[�R�[�h�}�X�^
                status = GetPrmPrtBarcd(offerDate, ref partsMakerList, ref sqlConnection);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && 
                    status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    return status;
                if (partsMakerList.Count > 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            partsMakerObj = partsMakerList;
            return status;
        }

        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h�}�X�^�̕��i���[�J�[�擾
        /// </summary>
        /// <param name="offerDate">�񋟓��t</param>
        /// <param name="partsMakerList">���i���[�J�[���X�g</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns></returns>
        private int GetPrmPrtBarcd(int offerDate, ref  Dictionary<int, int> partsMakerList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string selectstr = string.Empty;
            int partsMakerCode = 0;
            int Count = 0;

            try
            {
                #region �D�Ǖ��i�o�[�R�[�h�}�X�^
                selectstr += "SELECT ";
                selectstr += " PARTSMAKERCODERF ";
                selectstr += ",COUNT(PARTSMAKERCODERF) AS CNT ";
                selectstr += "FROM PRMPRTBRCDRF ";
                selectstr += "WHERE OFFERDATERF = " + offerDate.ToString();
                selectstr += " GROUP BY PARTSMAKERCODERF ";

                sqlCommand = new SqlCommand(selectstr, sqlConnection);
                sqlCommand.CommandTimeout = 6000;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    partsMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCODERF"));
                    Count = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNT"));
                    if (!(partsMakerList.ContainsKey(partsMakerCode))) partsMakerList.Add(partsMakerCode, Count);
                }

                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
                #endregion

                if (partsMakerList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && myReader.IsClosed == false) myReader.Close();
            }
            return status;
        }

        #region �D�Ǖ��i�o�[�R�[�h�}�X�^
        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h�}�X�^���擾
        /// </summary>
        /// <param name="offerDate">�擾����񋟃f�[�^�̒񋟓��t</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�O��i��</param>
        /// <param name="retList">�擾���ʂ̃��X�g�iCustomSerializeArrayList�j</param>
        /// <returns>��������</returns>
        public int GetPrmPrtBrcdInfo(int offerDate, int makerCode, string goodsNo, out object retList)
        {
            //�Z�}�t�H���L���ɂȂ��Ă����ꍇ
            if (_pool == null)
            {
                sem = ReadSemaphoreStXml();

                if (sem.SemaphoreFlg == 1)
                {
                    //���[�J���Z�}�t�H�̐���
                    _pool = new Semaphore(sem.SemaphoreCnt, sem.SemaphoreCnt);
                }
                else
                {
                    _pool = null;
                }
            }

            if (_pool != null)
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                bool flg = false;
                retList = new CustomSerializeArrayList();

                try
                {
                    flg = _pool.WaitOne(sem.TimeOut, false);

                    if (flg)
                    {
                        status = GetPrmPrtBrcdInfoProc(offerDate, makerCode, goodsNo, out retList);
                    }
                    else
                    {
                        //�^�C���A�E�g
                        base.WriteErrorLog("MergeDataGetDB.GetPrmPrtBrcdInfo Semaphore�Ń��b�N�^�C���A�E�g����");
                    }
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "MergeDataGetDB.GetPrmPrtBrcdInfo ��O����");
                }
                finally
                {
                    if (flg)
                    {
                        //�Z�}�t�H�̃��b�N�ɐ������Ă����ꍇ�͉������B
                        try
                        {
                            _pool.Release();
                        }
                        catch (SemaphoreFullException ex)
                        {
                            //�S�ĉ������Ă����ꍇ�̗�O
                            base.WriteErrorLog(ex, "MergeDataGetDB.GetPrmPrtBrcdInfo Semaphore����G���[");
                        }
                        catch (Exception ex)
                        {
                            base.WriteErrorLog(ex, "MergeDataGetDB.GetPrmPrtBrcdInfo Semaphore����G���[");
                        }
                    }
                }

                return status;
            }
            else
            {
                //�Z�}�t�H�������̏ꍇ�͊�������
                return GetPrmPrtBrcdInfoProc(offerDate, makerCode, goodsNo, out retList);
            }
        }

        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h�}�X�^�擾����
        /// </summary>
        /// <param name="offerDate">�擾����񋟃f�[�^�̒񋟓��t</param>
        /// <param name="retList">�擾���ʂ̃��X�g�iCustomSerializeArrayList�j</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�O��i��</param>
        /// <returns>��������</returns>
        private int GetPrmPrtBrcdInfoProc(int offerDate, int makerCode, string goodsNo, out object retList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            CustomSerializeArrayList lst = new CustomSerializeArrayList();

            retList = new ArrayList();

            SqlConnection sqlConnection = CreateSqlConnection();
            if (sqlConnection == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            ArrayList lstPrmPrtBrcd = null;
            sqlConnection.Open();
            try
            {
                // �D�Ǖ��i�o�[�R�[�h�}�X�^�擾����
                status = SearchPrmPrtBrcd(offerDate, makerCode, goodsNo, out lstPrmPrtBrcd, sqlConnection);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || 
                    status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    lst.Add(lstPrmPrtBrcd);
                }
                retList = lst;
                if (lst.Count > 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                else
                    retList = new ArrayList();
            }
            catch
            {
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h�}�X�^�擾����
        /// </summary>
        /// <param name="offerDate">�擾����񋟃f�[�^�̒񋟓��t</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="lstPrmPrtBrcd">�擾���ʂ̃��X�g</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns></returns>
        private int SearchPrmPrtBrcd(int offerDate, int makerCode, string goodsNo, out ArrayList lstPrmPrtBrcd, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = string.Empty;

            lstPrmPrtBrcd = new ArrayList();

            try
            {
                sqlText += "SELECT TOP 10000 " +Environment.NewLine;
                sqlText += "     OFFERDATERF" + Environment.NewLine;
                sqlText += "    ,PARTSMAKERCODERF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSCODERF" + Environment.NewLine;
                sqlText += "    ,PRIMEPARTSNOWITHHRF" + Environment.NewLine;
                sqlText += "    ,PRIMEPRTSBARCDKNDDIVRF" + Environment.NewLine;
                sqlText += "    ,PRIMEPARTSBARCODERF" + Environment.NewLine;
                sqlText += " FROM PRMPRTBRCDRF" + Environment.NewLine;
                sqlText += " WHERE OFFERDATERF = " + offerDate.ToString();
                sqlText += " AND PARTSMAKERCODERF = " + makerCode;
                sqlText += " AND PRIMEPARTSNOWITHHRF > " + "'" + goodsNo + "' ";

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                SqlParameter findOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                findOfferDate.Value = SqlDataMediator.SqlSetInt32(offerDate);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    PrmPrtBrcdWork prmPrtBrcdWork = new PrmPrtBrcdWork();
                    prmPrtBrcdWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    prmPrtBrcdWork.PartsMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCODERF"));
                    prmPrtBrcdWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                    prmPrtBrcdWork.PrimePartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSNOWITHHRF"));
                    prmPrtBrcdWork.PrimePrtsBarCdKndDiv = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("PRIMEPRTSBARCDKNDDIVRF"));
                    prmPrtBrcdWork.PrimePartsBarCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRIMEPARTSBARCODERF"));

                    lstPrmPrtBrcd.Add(prmPrtBrcdWork);
                }
                if (lstPrmPrtBrcd.Count > 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                else
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null && myReader.IsClosed == false) myReader.Close();
            }
            return status;
        }
        #endregion

        // --- ADD 2017/08/01 Y.Wakita ----------<<<<<

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;


            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
//#if true
            //connectionText = @"workstation id=OSANAI2;packet size=4096; User id=pmoffer; Pwd=pmoffer001; data source=10.30.20.228; persist security info=False; initial catalog=PM_OFFER_DB_NEW";
//#else
            if (string.IsNullOrEmpty(connectionText))
                return null;

//#endif
            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
