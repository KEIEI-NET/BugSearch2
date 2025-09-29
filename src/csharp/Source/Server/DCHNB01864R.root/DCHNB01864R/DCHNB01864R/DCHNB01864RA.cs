using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����E�d�����䃊���[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����E�d�����䃊���[�g�I�u�W�F�N�g�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc�@��</br>
    /// <br>Date       : 2008.02.13</br>
    /// <br></br>
    /// <br>Update Note: 2008.05.30 PM.NS�p�ɏC��</br>
    /// <br>           : 1.�r������̑g�ݍ��� �� ��</br>
    /// <br>           : 2.�ԍ��̔Ԏ��̃��g���C�g�ݍ��� �� ��</br>
    /// <br>           : 3.���i�}�X�^�����o�^</br>
    /// <br>           : 4.���i�}�X�^�����X�V</br>
    /// <br>           : 5.�����W�v�f�[�^���A���X�V</br>
    /// <br>           : 6.���|�c���X�V(�^�M�Ǘ�) �� ��</br>
    /// <br>           : 7.���p�Ǘ��o�^ �� ��</br>
    /// <br>           : 8.�󒍃}�X�^(�ԗ�)�o�^ �� ��</br>
    /// <br>           : 9.�����E�x�����דo�^</br>
    /// <br>           : A.�������ϑΉ�</br>
    /// <br>           : B.�t�n�d�Ή�</br>
    /// <br>           : C.�d�����㓯���v��@�\�̓��� �� ��</br>
    /// <br></br>
    /// <br>Update Note: READUNCOMMITTED�Ή�</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/06/11</br>
    /// <br></br>
    /// <br>Update Note: �������b�N�Ή�</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2010/08/17</br>
    /// <br></br>
    /// <br>Update Note: �q�ɂO���b�N��������s��̏C��</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2011/02/21</br>
    /// <br></br>
    /// <br>Update Note: ��Q���ǑΉ��@�v�サ�ēo�^��������`�[���폜���ɃG���[���O�o�͂���錏�̏C��</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2011/04/21</br>
    /// <br></br>
    /// <br>Update Note: Redmine#23737 �A��847�@�d���`�[���͂ŁA������������̂��ߓo�^�ł��܂���̂��C������</br>
    /// <br>Programmer : XUJS</br>
    /// <br>Date       : 2011/08/18</br>
    /// <br>Note       : �A��966 �d�����׃}�X�^�̓�����������N���A����B</br>
    /// <br>Programmer : ����g</br>
    /// <br>Date       : 2011/08/16</br>
    /// <br></br>
    /// <br>Update Note: ��Q�Ή�(�v��c�敪�F�c���Ȃ��œ�������(�󒍔���)���s����2�d�ō݌ɂ��X�V�����)</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2011/12/08</br>
    /// <br>UpdateNote : K2011/12/09 ���N�n��</br>
    /// <br>�Ǘ��ԍ�   : 10703874-00</br>
    /// <br>�쐬���e   : �C�X�R�ʑΉ�</br>
    /// <br>Update Note: 2012/05/10  yangmj</br>
    /// <br>           : ��������W�v�������ɓ`�[���s�s�̏C��</br>
    /// <br></br>
    /// <br>Update Note: ��Q�Ή�(�u�󒍌v��c�敪�F�c���Ȃ��v�Ōv�サ������`�[���`�[�C���Ōďo���Ȃ���Q�̏C��)</br>
    /// <br>Programmer : �e�c ���V</br>
    /// <br>Date       : 2012/09/27</br>
    /// <br>Update Note: 2012/11/09 wangf </br>
    /// <br>           : 10801804-00�A12��12���z�M���ARedmine#33215 PM.NS��Q�ꗗNo.1582�̑Ή�</br>
    /// <br>           : ����`�[���� ���������̎�����̔r���̑Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2012/11/30 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>             ����d���������͂Ŕ���`�[��ʁX�œ��͂��d���`�[�ԍ��𓯈�ō쐬���A</br>
    /// <br>             �쐬��������`�[�̕Е���`�[�폜�����ꍇ�A�d���`�[���Ăяo���Ȃ��Ȃ錏�̏C��</br>
    /// <br></br>
    /// <br>Update Note: 2014/05/01 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�   : 11070071-00�@�d�|�ꗗ ��2257</br>
    /// <br>             �v����܂ޑݏo�f�[�^�̓`�[�폜���\�ɂ���</br>
    /// <br>Update Note: 2017/03/30 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11370016-00 Redmine#49164�Ή�</br>
    /// <br>             Tablet�`�[������Z�b�V����ID�̏ꍇ�ɏd���o�^���Ȃ��悤�ɏC��</br>
    /// <br>Update Note: 2020/03/25 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11600006-00 PMKOBETSU-3622�Ή�</br>
    /// <br>             UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
    /// </remarks>
    [Serializable]
    public class IOWriteControlDB : RemoteWithAppLockDB, IIOWriteControlDB
    {
        // �v���O����ID
        //private string _origin = "IOWriteControlDB";

        /// <summary>
        /// ����E�d������I�v�V����
        /// </summary>
        private IOWriteCtrlOptWork _CtrlOptWork = null;

        /// <summary>
        /// ����E�d������I�v�V���� �v���p�e�B
        /// </summary>
        private IOWriteCtrlOptWork CtrlOptWork
        {
            get { return this._CtrlOptWork; }

            set
            {
                this._CtrlOptWork = value;
                this._ResourceName = this.GetResourceName(this._CtrlOptWork.EnterpriseCode);
            }
        }
        
        /// <summary>
        /// �A�v���P�[�V���� ���b�N ���\�[�X��
        /// </summary>
        private string _ResourceName = "";

        /// <summary>
        /// �A�v���P�[�V���� ���b�N ���\�[�X�� �v���p�e�B
        /// </summary>
        private string ResourceName
        {
            get { return this._ResourceName; }
        }

        # region [�g�p�����[�g]
        private IOWriteMASIRDB _purchaseIOWriteDB = null;    // �d��IOWriter
        private IOWriteMAHNBDB _salesIOWriteDB = null;       // ����IOWriter
        private IOWriteUOEOdrDtlDB _uoeIOWriteDB = null;     // UOEIOWriter

        # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
        //private SalesTempDB _salesTempDB = null;             // ����ꎞ�f�[�^�����[�g
        # endregion

        private StockSlipDB _stockSlipDB = null;             // �d�������[�g
        private SalesSlipDB _salesSlipDB = null;             // ���ナ���[�g
        private StockAdjustDB _stcAdjustDb = null;           // �݌ɒ��������[�g
        private PmTabSessionMngDB _pmTabSessionMngDB = null;   // PMTAB�Z�b�V�����Ǘ���񃊃��[�g // ADD 2017/03/30 ���O Redmine#49164�Ή�
        /// <summary>
        /// �d��IOWriter�v���p�e�B
        /// </summary>
        private IOWriteMASIRDB purchaseIOWriteDB
        {
            get
            {
                if (this._purchaseIOWriteDB == null)
                {
                    // �d�������[�g �𐶐�
                    this._purchaseIOWriteDB = new IOWriteMASIRDB();
                }

                this._purchaseIOWriteDB.IOWriteCtrlOptWork = this.CtrlOptWork;

                return this._purchaseIOWriteDB;
            }
        }

        /// <summary>
        /// ����IOWriter�v���p�e�B
        /// </summary>
        private IOWriteMAHNBDB salesIOWriteDB
        {
            get
            {
                if (this._salesIOWriteDB == null)
                {
                    // ���ナ���[�g �𐶐�
                    this._salesIOWriteDB = new IOWriteMAHNBDB();
                }

                this._salesIOWriteDB.IOWriteCtrlOptWork = this.CtrlOptWork;

                return this._salesIOWriteDB;
            }
        }

        /// <summary>
        /// UOE I/O Write �����[�g�v���p�e�B
        /// </summary>
        private IOWriteUOEOdrDtlDB uoeIOWriteDB
        {
            get
            {
                if (this._uoeIOWriteDB == null)
                {
                    this._uoeIOWriteDB = new IOWriteUOEOdrDtlDB();
                }

                return this._uoeIOWriteDB;
            }
        }

        #region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
        #if false
        /// <summary>
        /// ����ꎞ�����[�g�v���p�e�B
        /// </summary>
        private SalesTempDB salesTempDB
        {
            get
            {
                if (this._salesTempDB == null)
                {
                    // ����ꎞ�f�[�^�����[�g �𐶐�
                    this._salesTempDB = new SalesTempDB();
                }

                return this._salesTempDB;
            }
        }
        #endif
        #endregion

        /// <summary>
        /// �d�������[�g�v���p�e�B
        /// </summary>
        private StockSlipDB stockSlipDB
        {
            get
            {
                if (this._stockSlipDB == null)
                {
                    // �d�������[�g�𐶐�
                    this._stockSlipDB = new StockSlipDB();
                }

                return this._stockSlipDB;
            }
        }

        /// <summary>
        /// ���ナ���[�g�v���p�e�B
        /// </summary>
        private SalesSlipDB salesSlipDB
        {
            get
            {
                if (this._salesSlipDB == null)
                {
                    // ���ナ���[�g�𐶐�
                    this._salesSlipDB = new SalesSlipDB();
                }

                return this._salesSlipDB;
            }
        }

        /// <summary>
        /// �݌ɒ��������[�g �v���p�e�B
        /// </summary>
        private StockAdjustDB stcAdjustDb
        {
            get
            {
                if (this._stcAdjustDb == null)
                {
                    this._stcAdjustDb = new StockAdjustDB();
                }

                return this._stcAdjustDb;
            }
        }

        // ----------- ADD 2017/03/30 ���O Redmine#49164 ---------------- >>>>
        /// <summary>
        /// PMTAB�Z�b�V�����Ǘ���񃊃��[�g�v���p�e�B
        /// </summary>
        private PmTabSessionMngDB pmTabSessionMngDB
        {
            get
            {
                if (this._pmTabSessionMngDB == null)
                {
                    // PMTAB�Z�b�V�����Ǘ���񃊃��[�g�𐶐�
                    this._pmTabSessionMngDB = new PmTabSessionMngDB();
                }

                return this._pmTabSessionMngDB;
            }
        }
        // ----------- ADD 2017/03/30 ���O Redmine#49164 ---------------- <<<<<

        # endregion

        /// <summary>
        /// ����E�d�����䃊���[�g�I�u�W�F�N�gDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.02.13</br>
        /// </remarks>
        public IOWriteControlDB()
            :
            base("DCHNB01866D", "Broadleaf.Application.Remoting.ParamData.IOWriteControlDBWork", "IOWRITECONTROLDBRF")
        {
            #if DEBUG
            Console.WriteLine("����E�d�����䃊���[�g�I�u�W�F�N�g");
            #endif
        }

        //--- ADD 2008/06/06 M.Kubota --->>>
        /// <summary>
        /// ����E�d���o�^���̃��b�N���\�[�X���݂̂��擾���܂��B
        /// </summary>
        /// <param name="enterprisecode">��ƃR�[�h</param>
        /// <returns>���b�N���\�[�X��</returns>
        public string GetLockResourceName(string enterprisecode)
        {
            return this.GetResourceName(enterprisecode);
        }
        //--- ADD 2008/06/06 M.Kubota ---<<<

        # region [�Ǎ�����]

        /// <summary>
        /// �G���g���Ǎ�
        /// </summary>
        /// <param name="paramlist">�Ǎ����I�u�W�F�N�g���X�g</param>
        /// <param name="retsliplist">�Ǎ����ʃI�u�W�F�N�g</param>
        /// <param name="retrelationsliplist">�֘A�f�[�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int Read(ref object paramlist, out object retsliplist, out object retrelationsliplist)
        {
            // �߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retsliplist = null;
            retrelationsliplist = null;

            SqlConnection connection = null;
            SqlEncryptInfo encryptinfo = null;

            if (SlipListUtils.IsEmpty(paramlist as ArrayList))
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": �ǂݍ��ݏ�񃊃X�g�����o�^�ł��B";
                base.WriteErrorLog(errmsg, status);
            }
            else
            {
                try
                {
                    ArrayList list = paramlist as ArrayList;

                    ArrayList retslips = null;
                    ArrayList retrelationslips = null;

                    status = this.ReadProc(ref list, out retslips, out retrelationslips, ref connection, ref encryptinfo, true);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retsliplist = new CustomSerializeArrayList();
                        (retsliplist as CustomSerializeArrayList).AddRange(retslips);

                        retrelationsliplist = new CustomSerializeArrayList();
                        (retrelationsliplist as CustomSerializeArrayList).AddRange(retrelationslips);
                    }
                }
                catch (Exception ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);
                }
                finally
                {
                    # region [�Í����L�[�̃N���[�Y(�ۗ�)]
                    // �Í����L�[�̃N���[�Y
                    //if (encryptinfo != null && encryptinfo.IsOpen)
                    //{
                    //    encryptinfo.CloseSymKey(ref connection);
                    //}
                    # endregion

                    // �R�l�N�V�����̔j��
                    if (connection != null)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// �����`�[�ǂݍ���
        /// </summary>
        /// <param name="paramList">�Ǎ����I�u�W�F�N�g���X�g</param>
        /// <param name="retsliplist">�Ǎ����ʃI�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int ReadMore(ref object paramList, out object retsliplist)
        {
            // �߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            retsliplist = retList;

            SqlConnection connection = null;
            SqlEncryptInfo encryptinfo = null;

            string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            # region [�p�����[�^�`�F�b�N]

            if (SlipListUtils.IsEmpty(paramList as ArrayList))
            {
                errmsg += ": �ǂݍ��ݏ�񃊃X�g�����o�^�ł��B";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            IOWriteCtrlOptWork optWrk = ListUtils.Find((paramList as ArrayList), typeof(IOWriteCtrlOptWork), ListUtils.FindType.Class) as IOWriteCtrlOptWork;

            if (optWrk == null)
            {
                errmsg += ": ����E�d������I�v�V���������ݒ�ł�.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            int orgStartingPoint =  optWrk.CtrlStartingPoint;

            # endregion

            try
            {
                object readWork = null;
                ArrayList readParam = new ArrayList();

                foreach (object item in paramList as ArrayList)
                {
                    readParam.Clear();
                    readParam.Add(optWrk);
                    readWork = null;

                    if (item is IOWriteMAHNBReadWork)
                    {
                        readWork = item;
                        optWrk.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;
                    }
                    else if (item is IOWriteMASIRReadWork)
                    {
                        readWork = item;                        
                        optWrk.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Purchase;
                    }

                    if (readWork != null)
                    {
                        readParam.Add(readWork);
                        ArrayList retSlipList = null;
                        ArrayList retRelationList = null;
                        
                        status = this.ReadProc(ref readParam, out retSlipList, out retRelationList, ref connection, ref encryptinfo, false);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustomSerializeArrayList retCustomList = new CustomSerializeArrayList();
                            retCustomList.AddRange(retSlipList);
                            retList.Add(retCustomList);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                optWrk.CtrlStartingPoint = orgStartingPoint;

                # region [�Í����L�[�̃N���[�Y(�ۗ�)]
                // �Í����L�[�̃N���[�Y
                //if (encryptinfo != null && encryptinfo.IsOpen)
                //{
                //    encryptinfo.CloseSymKey(ref connection);
                //}
                # endregion

                // �R�l�N�V�����̔j��
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramlist"></param>
        /// <param name="retsliplist"></param>
        /// <param name="retrelationsliplist"></param>
        /// <param name="connection"></param>
        /// <param name="encryptinfo"></param>
        /// <param name="readrelation"></param>
        /// <returns></returns>
        private int ReadProc(ref ArrayList paramlist, out ArrayList retsliplist, out ArrayList retrelationsliplist, ref SqlConnection connection, ref SqlEncryptInfo encryptinfo, bool readrelation)
        {
            // �߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retsliplist = new ArrayList();
            retrelationsliplist = new ArrayList();

            SqlCommand command = null;

            try
            {
                # region [�p�����[�^�[�`�F�b�N]
                
                //���Ǎ���񃊃X�g�`�F�b�N
                if (SlipListUtils.IsEmpty(paramlist))
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": �Ǎ���񃊃X�g�����o�^�ł��B";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //������E�d������I�v�V�����`�F�b�N
                this.CtrlOptWork = SlipListUtils.Find(paramlist, typeof(IOWriteCtrlOptWork), SlipListUtils.FindType.Class) as IOWriteCtrlOptWork;
               
                if (this.CtrlOptWork == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": ����E�d������I�v�V������������܂���B";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //���R�l�N�V�����`�F�b�N
                if (connection == null)
                {
                    connection = this.CreateSqlConnection(true);
                }

                if (connection == null)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": �f�[�^�x�[�X�֐ڑ��o���܂���B";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # region �Í������� �ۗ�
                //���Í����L�[�`�F�b�N�@(�ۗ�)
                //if (encryptinfo == null)
                //{
                //    List<string> ConcatArray = new List<string>();

                //    // �Í����Ώۂ̔���f�[�^�n�e�[�u�����X�g���擾
                //    ConcatArray.AddRange(IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
                    
                //    // �Í����Ώۂ̎d���f�[�^�n�e�[�u�����X�g���擾
                //    ConcatArray.AddRange(IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
                    
                //    // �e�[�u�����X�g�̌���
                //    string[] tablenames = ConcatArray.ToArray();

                //    encryptinfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, tablenames);
                //}

                //if (encryptinfo == null)
                //{
                //    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                //    errmsg += ": �Í����L�[���쐬�o���܂���B";
                //    base.WriteErrorLog(errmsg, status);
                //    return status;
                //}

                //encryptinfo.OpenSymKey(ref connection);

                //if (!encryptinfo.IsOpen)
                //{
                //    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                //    errmsg += ": �Í����L�[���I�[�v���o���܂���B";
                //    base.WriteErrorLog(errmsg, status);
                //    return status;
                //}
                # endregion

                //������N�_�ɉ����ēǍ��I�u�W�F�N�g�����X�g���擾����
                IOWriteMAHNBReadWork salesReadWork = null;
                IOWriteMASIRReadWork stockReadWork = null;

                if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales)
                {
                    salesReadWork = SlipListUtils.Find(paramlist, typeof(IOWriteMAHNBReadWork), SlipListUtils.FindType.Class) as IOWriteMAHNBReadWork;
                    
                    if (salesReadWork == null)
                    {
                        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                        errmsg += ": ����f�[�^�Ǎ��I�u�W�F�N�g���o�^����Ă��܂���B";
                        base.WriteErrorLog(errmsg, status);
                        return status;
                    }
                }
                else if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Purchase)
                {

                    stockReadWork = SlipListUtils.Find(paramlist, typeof(IOWriteMASIRReadWork), SlipListUtils.FindType.Class) as IOWriteMASIRReadWork;
                    
                    if (stockReadWork == null)
                    {
                        string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                        errmsg += ": �d���f�[�^�Ǎ��I�u�W�F�N�g���o�^����Ă��܂���B";
                        base.WriteErrorLog(errmsg, status);
                        return status;
                    }
                }
                else
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    errmsg += ": ����E�d������I�v�V�����̐���N�_�Ɍ�肪����܂��B";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }
                # endregion

                # region [�w��`�[�f�[�^�̓Ǎ�]
                CustomSerializeArrayList readparam = new CustomSerializeArrayList();
                readparam.AddRange(paramlist);

                CustomSerializeArrayList readresult = null;

                //���Ǎ��Ώۂ̓`�[�f�[�^���擾����
                if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales)
                {
                    // ����`�[�f�[�^��ǂݍ���
                    status = this.salesIOWriteDB.Read(ref readparam, out readresult, ref connection);
                }
                else
                {
                    // �d���`�[�f�[�^��ǂݍ���
                    status = this.purchaseIOWriteDB.Read(ref readparam, out readresult, ref connection);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �Ǎ����ʂ��i�[
                    retsliplist.AddRange(readresult);
                }
                else
                {
                    return status;
                }
                # endregion

                if (readrelation)
                {
                    # region [�󒍃}�X�^����]
                    // ����f�[�^�̎󒍃X�e�[�^�X��d���f�[�^�̎d���`�����󒍃}�X�^�̎󒍃X�e�[�^�X�ɕϊ����鎫��
                    Dictionary<int, int> SlipToAodrDic = new Dictionary<int, int>();
                    SlipToAodrDic.Add(10, 1);  // ����
                    SlipToAodrDic.Add(20, 3);  // ��
                    SlipToAodrDic.Add(30, 7);  // ����
                    SlipToAodrDic.Add(40, 5);  // �o��
                    SlipToAodrDic.Add(0, 6);   // �d��
                    SlipToAodrDic.Add(1, 4);   // ����
                    SlipToAodrDic.Add(2, 2);   // ����

                    #region [������ɂ���SQL]
                    string sqlText = string.Empty;
                    command = new SqlCommand(sqlText, connection);

                    // �Ǎ��Ώۂ̓`�[�ԍ��ɕR�t�����ʒʔԂ��擾���A���̋��ʒʔԂŕR�t�����`�[�ԍ����擾����
                    // �A�������s�����f�[�^�Ɋւ��Ă͓`�[�ԍ������݂��Ȃ����߁A��q�̏����ŕʓr�擾����B
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  CASE AODR.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "    WHEN 1 THEN  1 + @ORDERWAIT" + Environment.NewLine;
                    sqlText += "    WHEN 3 THEN  2 + @ORDERWAIT" + Environment.NewLine;
                    sqlText += "    WHEN 5 THEN  3 + @ORDERWAIT" + Environment.NewLine;
                    sqlText += "    WHEN 7 THEN  4 + @ORDERWAIT" + Environment.NewLine;
                    sqlText += "    WHEN 8 THEN  5 + @ORDERWAIT" + Environment.NewLine;
                    sqlText += "    WHEN 2 THEN  6" + Environment.NewLine;
                    sqlText += "    WHEN 4 THEN  7" + Environment.NewLine;
                    sqlText += "    WHEN 6 THEN  8" + Environment.NewLine;
                    sqlText += "    WHEN 9 THEN  9" + Environment.NewLine;
                    sqlText += "  END AS ORDERVALUE" + Environment.NewLine;
                    sqlText += " ,CASE AODR.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "    WHEN 1 THEN  0" + Environment.NewLine;
                    sqlText += "    WHEN 3 THEN  0" + Environment.NewLine;
                    sqlText += "    WHEN 5 THEN  0" + Environment.NewLine;
                    sqlText += "    WHEN 7 THEN  0" + Environment.NewLine;
                    sqlText += "    WHEN 8 THEN -1" + Environment.NewLine;
                    sqlText += "    WHEN 2 THEN  1" + Environment.NewLine;
                    sqlText += "    WHEN 4 THEN  1" + Environment.NewLine;
                    sqlText += "    WHEN 6 THEN  1" + Environment.NewLine;
                    sqlText += "    WHEN 9 THEN -1" + Environment.NewLine;
                    sqlText += "  END AS SLIPTYPE" + Environment.NewLine;
                    sqlText += " ,AODR.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,AODR.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,AODR.SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    // -- UPD 2010/06/11 -------------------------------->>>
                    //sqlText += "  ACCEPTODRRF AS AODR" + Environment.NewLine;
                    sqlText += "  ACCEPTODRRF AS AODR WITH (READUNCOMMITTED)" + Environment.NewLine;
                    // -- UPD 2010/06/11 --------------------------------<<<
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  AODR.ENTERPRISECODERF        = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND AODR.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "  AND AODR.SECTIONCODERF       = @FINDSECTIONCODE" + Environment.NewLine;
                    sqlText += "  AND AODR.ACPTANODRSTATUSRF  <> @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND AODR.COMMONSEQNORF IN (SELECT" + Environment.NewLine;
                    sqlText += "                               ACC1.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += "                             FROM" + Environment.NewLine;
                    // -- UPD 2010/06/11 -------------------------------->>>
                    //sqlText += "                               ACCEPTODRRF AS ACC1 INNER JOIN (SELECT" + Environment.NewLine;
                    sqlText += "                               ACCEPTODRRF AS ACC1 WITH (READUNCOMMITTED) INNER JOIN (SELECT" + Environment.NewLine;
                    // -- UPD 2010/06/11 --------------------------------<<<
                    sqlText += "                                                                 SUB.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.SECTIONCODERF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.SLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "                                                                ,MAX(SUB.SLIPDTLNUMDERIVNORF) AS SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                    sqlText += "                                                               FROM" + Environment.NewLine;
                    // -- UPD 2010/06/11 ------------------------------------------------------------------------->>>
                    //sqlText += "                                                                 ACCEPTODRRF AS SUB" + Environment.NewLine;
                    sqlText += "                                                                 ACCEPTODRRF AS SUB WITH (READUNCOMMITTED)" + Environment.NewLine;
                    // -- UPD 2010/06/11 -------------------------------------------------------------------------<<<
                    sqlText += "                                                               WHERE" + Environment.NewLine;
                    sqlText += "                                                                 SUB.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "                                                               GROUP BY" + Environment.NewLine;
                    sqlText += "                                                                 SUB.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.SECTIONCODERF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += "                                                                ,SUB.SLIPDTLNUMRF) AS ACC2" + Environment.NewLine;
                    sqlText += "                               ON  ACC1.ENTERPRISECODERF    = ACC2.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "                               AND ACC1.SECTIONCODERF       = ACC2.SECTIONCODERF" + Environment.NewLine;
                    sqlText += "                               AND ACC1.ACPTANODRSTATUSRF   = ACC2.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "                               AND ACC1.DATAINPUTSYSTEMRF   = ACC2.DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlText += "                               AND ACC1.COMMONSEQNORF       = ACC2.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += "                               AND ACC1.SLIPDTLNUMRF        = ACC2.SLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "                               AND ACC1.SLIPDTLNUMDERIVNORF = ACC2.SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                    sqlText += "                            WHERE" + Environment.NewLine;
                    sqlText += "                              ACC1.ENTERPRISECODERF        = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "                              AND ACC1.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    sqlText += "                              AND ACC1.SECTIONCODERF       = @FINDSECTIONCODE" + Environment.NewLine;
                    sqlText += "                              AND ACC1.ACPTANODRSTATUSRF   = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "                              AND ACC1.SALESSLIPNUMRF      = @FINDSALESSLIPNUM" + Environment.NewLine;
                    sqlText += "                              AND ACC1.DATAINPUTSYSTEMRF   = @FINDDATAINPUTSYSTEM)" + Environment.NewLine;
                    sqlText += "GROUP BY" + Environment.NewLine;
                    sqlText += "  AODR.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,AODR.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,AODR.SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += "ORDER BY" + Environment.NewLine;
                    sqlText += "  ORDERVALUE" + Environment.NewLine;
                    command.CommandText = sqlText;
                    # endregion

                    SqlParameter findEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);      // ��ƃR�[�h
                    SqlParameter findLogicalDeleteCode = command.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);  // �_���폜�敪
                    SqlParameter findSectionCode = command.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);            // ���_�R�[�h
                    SqlParameter findAcptAnOdrStatus = command.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);      // �󒍃X�e�[�^�X
                    SqlParameter findSalesSlipNum = command.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);          // �`�[�ԍ�
                    SqlParameter findDataInputSystem = command.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);      // �f�[�^���̓V�X�e��
                    SqlParameter paraOrderwait = command.Parameters.Add("@ORDERWAIT", SqlDbType.Int);                      // ���я��̉σE�F�C�g

                    AcceptOdrWork aodrWrk = new AcceptOdrWork();

                    if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales)
                    {
                        SalesSlipWork slip = SlipListUtils.Find(retsliplist, typeof(SalesSlipWork), SlipListUtils.FindType.Class) as SalesSlipWork;

                        if (slip != null)
                        {
                            aodrWrk.EnterpriseCode = slip.EnterpriseCode;                              // ��ƃR�[�h
                            aodrWrk.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;  // �_���폜�敪
                            aodrWrk.SectionCode = slip.SectionCode;                                    // ���_�R�[�h
                            aodrWrk.AcptAnOdrStatus = SlipToAodrDic[slip.AcptAnOdrStatus];             // �󒍃X�e�[�^�X
                            aodrWrk.SalesSlipNum = slip.SalesSlipNum;                                  // �`�[�ԍ�
                            aodrWrk.DataInputSystem = (int)DataInputSystem.PM;                         // �f�[�^���̓V�X�e��
                        }
                        else
                        {
                            return status;
                        }
                    }
                    else
                    {
                        StockSlipWork slip = SlipListUtils.Find(retsliplist, typeof(StockSlipWork), SlipListUtils.FindType.Class) as StockSlipWork;

                        if (slip != null)
                        {
                            aodrWrk.EnterpriseCode = slip.EnterpriseCode;                              // ��ƃR�[�h
                            aodrWrk.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;  // �_���폜�敪
                            aodrWrk.SectionCode = slip.SectionCode;                                    // ���_�R�[�h
                            aodrWrk.AcptAnOdrStatus = SlipToAodrDic[slip.SupplierFormal];              // �d���`��
                            aodrWrk.SalesSlipNum = slip.SupplierSlipNo.ToString();                     // �`�[�ԍ�
                            aodrWrk.DataInputSystem = (int)DataInputSystem.PM;                         // �f�[�^���̓V�X�e��
                        }
                        else
                        {
                            return status;
                        }
                    }

                    // SQL�p�����[�^�̐ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(aodrWrk.EnterpriseCode);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(aodrWrk.LogicalDeleteCode);
                    findSectionCode.Value = SqlDataMediator.SqlSetString(aodrWrk.SectionCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(aodrWrk.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(aodrWrk.SalesSlipNum);
                    findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(aodrWrk.DataInputSystem);
                    paraOrderwait.Value = this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales ? 0 : 10;

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(command));
#endif

                    DataTable aodrtable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                    try
                    {
                        dataAdapter.Fill(aodrtable);

                        // �󒍃}�X�^�̎󒍃X�e�[�^�X�𔄏�f�[�^�̎󒍃X�e�[�^�X��d���f�[�^�̎d���`���ɕϊ����鎫��
                        Dictionary<int, int> AodrToSlipDic = new Dictionary<int, int>();
                        AodrToSlipDic.Add(1, 10);  // ����
                        AodrToSlipDic.Add(3, 20);  // ��
                        AodrToSlipDic.Add(7, 30);  // ����
                        AodrToSlipDic.Add(5, 40);  // �o��
                        AodrToSlipDic.Add(6, 0);   // �d��
                        AodrToSlipDic.Add(4, 1);   // ����
                        AodrToSlipDic.Add(2, 2);   // ����

                        foreach (DataRow row in aodrtable.Rows)
                        {
                            readparam = new CustomSerializeArrayList();
                            readresult = new CustomSerializeArrayList();

                            switch ((int)row["SLIPTYPE"])
                            {
                                case 0:
                                    {
                                        # region [����n�f�[�^�̓Ǎ�]
                                        // ����n�̃f�[�^�Ƃ��ēǂݍ���
                                        salesReadWork = new IOWriteMAHNBReadWork();
                                        salesReadWork.EnterpriseCode = (string)row["ENTERPRISECODERF"];
                                        salesReadWork.AcptAnOdrStatus = AodrToSlipDic[(int)row["ACPTANODRSTATUSRF"]];
                                        salesReadWork.SalesSlipNum = (string)row["SALESSLIPNUMRF"];
                                        // --- ADD 2012/09/27 y.wakita ----->>>>>
                                        salesReadWork.LogicalDeleteCodeFlg = 1;
                                        // --- ADD 2012/09/27 y.wakita -----<<<<<

                                        readparam.Add(salesReadWork);

                                        // ����`�[�f�[�^��ǂݍ���
                                        status = this.salesIOWriteDB.Read(ref readparam, out readresult, ref connection);

                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            // �Ǎ����ʂ��i�[
                                            retrelationsliplist.Add(readresult);
                                        }
                                        else
                                        {
                                            return status;
                                        }

                                        break;
                                        # endregion
                                    }
                                case 1:
                                    {
                                        # region [�d���n�f�[�^�̓Ǎ�]
                                        // �d���n�̃f�[�^�Ƃ��ēǂݍ���
                                        stockReadWork = new IOWriteMASIRReadWork();
                                        stockReadWork.EnterpriseCode = (string)row["ENTERPRISECODERF"];
                                        stockReadWork.SupplierFormal = AodrToSlipDic[(int)row["ACPTANODRSTATUSRF"]];
                                        stockReadWork.SupplierSlipNo = int.Parse((string)row["SALESSLIPNUMRF"]);

                                        # region [if (stockReadWork.SupplierFormal == 2 && stockReadWork.SupplierSlipNo == 0)]
                                        if (stockReadWork.SupplierFormal == 2 && stockReadWork.SupplierSlipNo == 0)
                                        {
                                            // �Ǎ��Ώۂ̓`�[�ԍ��ɕR�t�����ʒʔԂ��擾���A���̋��ʒʔԂŕR�t���������׃f�[�^���擾����B
                                            # region [SELECT��]
                                            sqlText = string.Empty;
                                            sqlText += "SELECT" + Environment.NewLine;
                                            sqlText += "  AODR.SLIPDTLNUMRF" + Environment.NewLine;
                                            sqlText += "FROM" + Environment.NewLine;
                                            // -- UPD 2010/06/11 ---------------------------------->>>
                                            //sqlText += "  ACCEPTODRRF AS AODR" + Environment.NewLine;
                                            sqlText += "  ACCEPTODRRF AS AODR WITH (READUNCOMMITTED)" + Environment.NewLine;
                                            // -- UPD 2010/06/11 ----------------------------------<<<
                                            sqlText += "WHERE" + Environment.NewLine;
                                            sqlText += "  AODR.ENTERPRISECODERF        = @FINDENTERPRISECODE" + Environment.NewLine;
                                            sqlText += "  AND AODR.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                                            sqlText += "  AND AODR.SECTIONCODERF       = @FINDSECTIONCODE" + Environment.NewLine;
                                            sqlText += "  AND AODR.ACPTANODRSTATUSRF   = 2" + Environment.NewLine;
                                            sqlText += "  AND AODR.COMMONSEQNORF IN (SELECT" + Environment.NewLine;
                                            sqlText += "                               ACC1.COMMONSEQNORF" + Environment.NewLine;
                                            sqlText += "                             FROM" + Environment.NewLine;
                                            // -- UPD 2010/06/11 ----------------------------------------------->>>
                                            //sqlText += "                               ACCEPTODRRF AS ACC1 INNER JOIN (SELECT" + Environment.NewLine;
                                            sqlText += "                               ACCEPTODRRF AS ACC1 WITH (READUNCOMMITTED) INNER JOIN (SELECT" + Environment.NewLine;
                                            // -- UPD 2010/06/11 -----------------------------------------------<<<
                                            sqlText += "                                                                 SUB.ENTERPRISECODERF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.SECTIONCODERF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.COMMONSEQNORF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.SLIPDTLNUMRF" + Environment.NewLine;
                                            sqlText += "                                                                ,MAX(SUB.SLIPDTLNUMDERIVNORF) AS SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                                            sqlText += "                                                               FROM" + Environment.NewLine;
                                            // -- UPD 2010/06/11 ------------------------------------------------------------->>>
                                            //sqlText += "                                                                 ACCEPTODRRF AS SUB" + Environment.NewLine;
                                            sqlText += "                                                                 ACCEPTODRRF AS SUB WITH (READUNCOMMITTED)" + Environment.NewLine;
                                            // -- UPD 2010/06/11 -------------------------------------------------------------<<<
                                            sqlText += "                                                               WHERE" + Environment.NewLine;
                                            sqlText += "                                                                 SUB.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                                            sqlText += "                                                               GROUP BY" + Environment.NewLine;
                                            sqlText += "                                                                 SUB.ENTERPRISECODERF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.SECTIONCODERF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.COMMONSEQNORF" + Environment.NewLine;
                                            sqlText += "                                                                ,SUB.SLIPDTLNUMRF) AS ACC2" + Environment.NewLine;
                                            sqlText += "                               ON  ACC1.ENTERPRISECODERF    = ACC2.ENTERPRISECODERF" + Environment.NewLine;
                                            sqlText += "                               AND ACC1.SECTIONCODERF       = ACC2.SECTIONCODERF" + Environment.NewLine;
                                            sqlText += "                               AND ACC1.ACPTANODRSTATUSRF   = ACC2.ACPTANODRSTATUSRF" + Environment.NewLine;
                                            sqlText += "                               AND ACC1.DATAINPUTSYSTEMRF   = ACC2.DATAINPUTSYSTEMRF" + Environment.NewLine;
                                            sqlText += "                               AND ACC1.COMMONSEQNORF       = ACC2.COMMONSEQNORF" + Environment.NewLine;
                                            sqlText += "                               AND ACC1.SLIPDTLNUMRF        = ACC2.SLIPDTLNUMRF" + Environment.NewLine;
                                            sqlText += "                               AND ACC1.SLIPDTLNUMDERIVNORF = ACC2.SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                                            sqlText += "                            WHERE" + Environment.NewLine;
                                            sqlText += "                              ACC1.ENTERPRISECODERF        = @FINDENTERPRISECODE" + Environment.NewLine;
                                            sqlText += "                              AND ACC1.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                                            sqlText += "                              AND ACC1.SECTIONCODERF       = @FINDSECTIONCODE" + Environment.NewLine;
                                            sqlText += "                              AND ACC1.ACPTANODRSTATUSRF   = @FINDACPTANODRSTATUS" + Environment.NewLine;
                                            sqlText += "                              AND ACC1.SALESSLIPNUMRF      = @FINDSALESSLIPNUM" + Environment.NewLine;
                                            sqlText += "                              AND ACC1.DATAINPUTSYSTEMRF   = @FINDDATAINPUTSYSTEM)" + Environment.NewLine;
                                            command.CommandText = sqlText;
                                            # endregion

                                            DataTable orderDtlTable = new DataTable();
                                            SqlDataAdapter orderAdapter = new SqlDataAdapter(command);
                                            try
                                            {
                                                orderAdapter.Fill(orderDtlTable);

                                                ArrayList orderdtllist = new ArrayList();

                                                foreach (DataRow orderdtlrow in orderDtlTable.Rows)
                                                {
                                                    StockDetailWork dtl = new StockDetailWork();
                                                    dtl.EnterpriseCode = aodrWrk.EnterpriseCode;
                                                    dtl.SupplierFormal = 2;
                                                    dtl.StockSlipDtlNum = (long)orderdtlrow["SLIPDTLNUMRF"];
                                                    orderdtllist.Add(dtl);
                                                }

                                                if (orderdtllist.Count > 0)
                                                {
                                                    SqlTransaction dummyTran = null;
                                                    ArrayList retOrderDtlList;

                                                    status = this.stockSlipDB.ReadStockDetailWork(out retOrderDtlList, orderdtllist, ref connection, ref dummyTran);

                                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                                    {
                                                        StockSlipWork dummySlip = new StockSlipWork();

                                                        // �_�~�[�d���f�[�^�ɕK�v�ȍ��ڂ�ݒ肷��
                                                        dummySlip.SupplierFormal = 2;                        // �d���`�� = 2:����      �Œ�
                                                        dummySlip.SupplierSlipCd = 10;                       // �d���`�[�敪 = 10:�d�� �Œ�

                                                        if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales)
                                                        {
                                                            SalesSlipWork slip = SlipListUtils.Find(retsliplist, typeof(SalesSlipWork), SlipListUtils.FindType.Class) as SalesSlipWork;
                                                            dummySlip.EnterpriseCode = slip.EnterpriseCode;  // ��ƃR�[�h
                                                            dummySlip.SectionCode = slip.SectionCode;        // ���_�R�[�h
                                                            dummySlip.SubSectionCode = slip.SubSectionCode;  // ����R�[�h
                                                        }
                                                        else
                                                        {
                                                            StockSlipWork slip = SlipListUtils.Find(retsliplist, typeof(StockSlipWork), SlipListUtils.FindType.Class) as StockSlipWork;
                                                            dummySlip.EnterpriseCode = slip.EnterpriseCode;  // ��ƃR�[�h
                                                            dummySlip.SectionCode = slip.SectionCode;        // ���_�R�[�h
                                                            dummySlip.SubSectionCode = slip.SubSectionCode;  // ����R�[�h
                                                        }

                                                        readresult = new CustomSerializeArrayList();
                                                        readresult.Add(dummySlip);
                                                        readresult.Add(retOrderDtlList);
                                                        retrelationsliplist.Add(readresult);
                                                    }
                                                    else
                                                    {
                                                        return status;
                                                    }
                                                }
                                            }
                                            finally
                                            {
                                                orderAdapter.Dispose();
                                                orderDtlTable.Dispose();
                                            }
                                        }
                                        # endregion
                                        # region [else]
                                        else
                                        {
                                            readparam.Add(stockReadWork);

                                            // �d���`�[�f�[�^��ǂݍ���
                                            status = this.purchaseIOWriteDB.Read(ref readparam, out readresult, ref connection);

                                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                            {
                                                // �Ǎ����ʂ��i�[
                                                retrelationsliplist.Add(readresult);
                                            }
                                            else
                                            {
                                                return status;
                                            }
                                        }
                                        # endregion
                                        # endregion

                                        # region [UOE�����f�[�^�̓Ǎ�]

                                        ArrayList stcDtlList = ListUtils.Find(readresult, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                                        if (ListUtils.IsNotEmpty(stcDtlList))
                                        {
                                            ArrayList prmList = new ArrayList();
                                            
                                            // �d���`���� 2:���� �̏ꍇ�ɂ̂�UOE�����f�[�^��Ǎ���
                                            foreach (StockDetailWork stcDtlItem in stcDtlList)
                                            {
                                                // 2009/02/17 MANTIS 11585�Ή�>>>>>>>>>>
                                                //if (stcDtlItem.SupplierFormal == 2)
                                                //�I�����C�����̏ꍇ�݂̂t�n�d�����f�[�^�̓ǂݍ��݂��s��
                                                if (stcDtlItem.SupplierFormal == 2 && stcDtlItem.WayToOrder == 2)
                                                // 2009/02/17 <<<<<<<<<<<<<<<<<<<<<<<<<<
                                                {
                                                    UOEOrderDtlWork uoeOdrDtl = new UOEOrderDtlWork();
                                                    uoeOdrDtl.EnterpriseCode = stcDtlItem.EnterpriseCode;    // ��ƃR�[�h
                                                    uoeOdrDtl.SupplierFormal = stcDtlItem.SupplierFormal;    // �d���`��
                                                    uoeOdrDtl.StockSlipDtlNum = stcDtlItem.StockSlipDtlNum;  // �d�����גʔ�
                                                    uoeOdrDtl.UOEKind = -1;  // 2009/02/24 MANTIS 11789
                                                    prmList.Add(uoeOdrDtl);
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            
                                            if (ListUtils.IsNotEmpty(prmList))
                                            {
                                                ArrayList retList = null;
                                                SqlTransaction dummy = null;
                                                status = this.uoeIOWriteDB.Search(prmList, out retList, ref connection, ref dummy);

                                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                                {
                                                    retrelationsliplist.Add(retList);
                                                }

                                            }
                                        }

                                        # endregion

                                        break;
                                    }
                            }
                        }
                    }
                    finally
                    {
                        aodrtable.Dispose();
                        dataAdapter.Dispose();
                    }

                    #endregion

                    #region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
#if false
                    # region [����ꎞ�f�[�^�̓Ǎ�(����N�_�� 1:�d�� �̏ꍇ�̂�)]
                if (this._CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Purchase)
                {
                    ArrayList stockdtllist = SlipListUtils.Find(retsliplist, typeof(StockDetailWork), SlipListUtils.FindType.Array) as ArrayList;

                    if (stockdtllist != null)
                    {
                        ArrayList salestmplist = new ArrayList();

                        foreach (StockDetailWork item in stockdtllist)
                        {
                            if (item != null && item.SalesSlipDtlNumSync != 0)
                            {
                                int index = salestmplist.Add(new SalesTempWork());

                                // �d�����ׂ̔��㖾�גʔ�(����)�ɓo�^����Ă���l���L�[�Ƃ��ăZ�b�g����
                                (salestmplist[index] as SalesTempWork).SalesSlipDtlNum = item.SalesSlipDtlNumSync;
                            }
                        }

                        if (salestmplist.Count > 0)
                        {
                            SqlTransaction dummytran = null;
                            status = this.salesTempDB.Search(ref salestmplist, 0, ConstantManagement.LogicalMode.GetData0, ref connection, ref dummytran);

                            // ����ꎞ�f�[�^��������Ȃ��ꍇ������̂ŃG���[�Ƃ͂��Ȃ�
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                salestmplist.Clear();
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && salestmplist.Count > 0)
                            {
                                int index = retrelationsliplist.Add(new CustomSerializeArrayList());
                                (retrelationsliplist[index] as CustomSerializeArrayList).AddRange(salestmplist);
                            }
                        }
                    }
                }
                # endregion
#endif
                    #endregion
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �`�[���׃f�[�^�̓ǂݍ��݂��s���܂��B
        /// </summary>
        /// <param name="paraList">�`�[���׃f�[�^��ǂݍ��ވׂ̏���(�`�[���׃N���X)���܂ރ��X�g</param>
        /// <param name="retList">�ǂݍ��񂾓`�[���׃N���X���܂ރ��X�g</param>
        /// <param name="retSynchroList">�����v�コ��Ă��鑊��斾�׃f�[�^���܂ރ��X�g</param>
        /// <returns>STATUS</returns>
        public int ReadDetail(ref object paraList, out object retList, out object retSynchroList)
        {
            // �߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retList = null;
            retSynchroList = null;

            SqlConnection connection = null;
            SqlEncryptInfo encryptinfo = null;
            SqlTransaction transaction = null;

            if (SlipListUtils.IsEmpty(paraList as ArrayList))
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                errmsg += ": �`�[���דǂݍ��ݏ�񃊃X�g�����o�^�ł��B";
                base.WriteErrorLog(errmsg, status);
            }
            else
            {
                try
                {
                    ArrayList paraArrayList = paraList as ArrayList;
                    ArrayList retArrayList = null;
                    ArrayList retArraySynchroList = null;

                    status = this.ReadDetailProc(ref paraArrayList, out retArrayList, out retArraySynchroList, ref connection, ref transaction, ref encryptinfo);

                    if (retArrayList != null && retArrayList.Count > 0)
                    {
                        retList = new CustomSerializeArrayList();
                        (retList as CustomSerializeArrayList).AddRange(retArrayList);
                    }

                    if (retArraySynchroList != null && retArraySynchroList.Count > 0)
                    {
                        retSynchroList = new CustomSerializeArrayList();
                        (retSynchroList as CustomSerializeArrayList).AddRange(retArraySynchroList);
                    }
                }
                catch (Exception ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);
                }
                finally
                {
                    // �Í����L�[�̃N���[�Y (�ۗ�9
                    //if (encryptinfo != null && encryptinfo.IsOpen)
                    //{
                    //    encryptinfo.CloseSymKey(ref connection);
                    //}

                    // �g�����U�N�V�����̔j��
                    if (transaction != null)
                    {
                        transaction.Dispose();
                    }

                    // �R�l�N�V�����̔j��
                    if (connection != null)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// �`�[���׃f�[�^�̓ǂݍ��݂��s���܂��B
        /// </summary>
        /// <param name="paraList">�`�[���׃f�[�^��ǂݍ��ވׂ̏���(�`�[���׃N���X)���܂ރ��X�g</param>
        /// <param name="retList">�ǂݍ��񂾓`�[���׃N���X���܂ރ��X�g</param>
        /// <param name="retSynchroList">�����v�コ��Ă��鑊��斾�׃f�[�^���܂ރ��X�g</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�������I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[���I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        private int ReadDetailProc(ref ArrayList paraList, out ArrayList retList, out ArrayList retSynchroList, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            // �߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            retList = new ArrayList();
            retSynchroList = new ArrayList();

            SqlCommand command = null;

            try
            {
                # region [�p�����[�^�[�`�F�b�N]

                //���Ǎ���񃊃X�g�`�F�b�N
                if (SlipListUtils.IsEmpty(paraList))
                {
                    errmsg += ": �`�[���דǍ���񃊃X�g�����o�^�ł��B";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //������E�d������I�v�V�����`�F�b�N
                this.CtrlOptWork = SlipListUtils.Find(paraList, typeof(IOWriteCtrlOptWork), SlipListUtils.FindType.Class) as IOWriteCtrlOptWork;

                if (this.CtrlOptWork == null)
                {
                    errmsg += ": ����E�d������I�v�V������������܂���B";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                //���R�l�N�V�����`�F�b�N
                if (connection == null)
                {
                    connection = this.CreateSqlConnection(true);
                }

                if (connection == null)
                {
                    errmsg += ": �f�[�^�x�[�X�֐ڑ��o���܂���B";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # region [�Í����L�[�`�F�b�N �ۗ�]
                //���Í����L�[�`�F�b�N
                //if (encryptinfo == null)
                //{
                //    List<string> ConcatArray = new List<string>();

                //    // �Í����Ώۂ̔���f�[�^�n�e�[�u�����X�g���擾
                //    ConcatArray.AddRange(IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));

                //    // �Í����Ώۂ̎d���f�[�^�n�e�[�u�����X�g���擾
                //    ConcatArray.AddRange(IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));

                //    // �e�[�u�����X�g�̌���
                //    string[] tablenames = ConcatArray.ToArray();

                //    encryptinfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, tablenames);
                //}

                //if (encryptinfo == null)
                //{
                //    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                //    errmsg += ": �Í����L�[���쐬�o���܂���B";
                //    base.WriteErrorLog(errmsg, status);
                //    return status;
                //}

                //encryptinfo.OpenSymKey(ref connection);

                //if (!encryptinfo.IsOpen)
                //{
                //    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                //    errmsg += ": �Í����L�[���I�[�v���o���܂���B";
                //    base.WriteErrorLog(errmsg, status);
                //    return status;
                //}

                //���g�����U�N�V�����`�F�b�N
                /*
                if (transaction == null)
                {
                    transaction = this.CreateTransaction(ref connection);
                }

                if (transaction == null)
                {
                    retMsg = "�g�����U�N�V�������J�n�ł��܂���B";
                    return status;
                }
                */
                # endregion
                # endregion

                # region [�傽��`�[���׃f�[�^�Ǎ�]

                //������N�_�ɉ����Ďd���E���ナ���[�g�̓`�[���דǂݍ��݃��\�b�h�����s����
                if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales)
                {
                    status = this.salesSlipDB.ReadSalesDetailWork(out retList, paraList, ref connection, ref transaction);
                }
                else if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Purchase)
                {
                    ArrayList stcDtlList = null;
                    status = this.stockSlipDB.ReadStockDetailWork(out stcDtlList, paraList, ref connection, ref transaction);
                    retList.Add(stcDtlList);
                }
                else
                {
                    errmsg += ": ����E�d������I�v�V�����̐���N�_�Ɍ�肪����܂��B";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # endregion

                # region [�����v��`�[���׃f�[�^�ǂݍ���]
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList prmSynchroDtlList = new ArrayList();
                    ArrayList retSynchroDtlList = null;

                    ArrayList slpDtlList = null;

                    SalesDetailWork slsDtlWrk = null;
                    StockDetailWork stcDtlWrk = null;

                    //--- ADD 2009/02/05 M.Kubota --->>>
                    UOEOrderDtlWork uoeDtlWrk = null;
                    ArrayList prmUOEOrderDtlList = new ArrayList();
                    //--- ADD 2009/02/05 M.Kubota ---<<<

                    # region [�p�����[�^�쐬]
                    // ����N�_������̏ꍇ
                    if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales)
                    {
                        // ���㖾�׃f�[�^���i�[���Ă���ArrayList�𕪗�����
                        slpDtlList = ListUtils.Find(retList, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                        // --- ADD m.suzuki 2011/04/21 ---------->>>>>
                        if ( slpDtlList != null )
                        {
                        // --- ADD m.suzuki 2011/04/21 ----------<<<<<
                            foreach ( object slipdtl in slpDtlList )
                            {
                                slsDtlWrk = slipdtl as SalesDetailWork;
                                if ( slsDtlWrk == null ) continue;

                                // �����v�㌳�̎d���f�[�^�����݂��Ă���ꍇ�ɂ̂ݐݒ�
                                if ( slsDtlWrk.SupplierFormalSync != -1 && slsDtlWrk.StockSlipDtlNumSync != 0 )
                                {
                                    // ���㖾�׃f�[�^���瓯���v�コ�ꂽ�d�����׃f�[�^�̓ǂݍ��ݏ����쐬
                                    stcDtlWrk = new StockDetailWork();
                                    stcDtlWrk.EnterpriseCode = slsDtlWrk.EnterpriseCode;
                                    stcDtlWrk.SupplierFormal = slsDtlWrk.SupplierFormalSync;
                                    stcDtlWrk.StockSlipDtlNum = slsDtlWrk.StockSlipDtlNumSync;
                                }

                                if ( stcDtlWrk != null )
                                {
                                    prmSynchroDtlList.Add( stcDtlWrk );
                                    stcDtlWrk = null;
                                }
                            }
                        // --- ADD m.suzuki 2011/04/21 ---------->>>>>
                        }
                        // --- ADD m.suzuki 2011/04/21 ----------<<<<<
                    }
                    // ����N�_���d���̏ꍇ
                    else if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Purchase)
                    {
                        // �d�����׃f�[�^���i�[���Ă���ArrayList�𕪗�����
                        slpDtlList = ListUtils.Find(retList, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                        foreach (object slipdtl in slpDtlList)
                        {
                            stcDtlWrk = slipdtl as StockDetailWork;
                            if (stcDtlWrk == null) continue;

                            // �����v�㌳�̔���f�[�^�����݂��Ă���ꍇ�ɂ̂ݐݒ�
                            if (stcDtlWrk.AcptAnOdrStatusSync != 0 && stcDtlWrk.SalesSlipDtlNumSync != 0)
                            {
                                // �d�����׃f�[�^���瓯���v�コ�ꂽ���㖾�׃f�[�^�̓ǂݍ��ݏ����쐬
                                slsDtlWrk = new SalesDetailWork();
                                slsDtlWrk.EnterpriseCode = stcDtlWrk.EnterpriseCode;
                                slsDtlWrk.AcptAnOdrStatus = stcDtlWrk.AcptAnOdrStatusSync;
                                slsDtlWrk.SalesSlipDtlNum = stcDtlWrk.SalesSlipDtlNumSync;
                            }

                            if (slsDtlWrk != null)
                            {
                                prmSynchroDtlList.Add(slsDtlWrk);
                                slsDtlWrk = null;
                            }
                        }
                    }
                    # endregion

                    # region [���דǂݍ���]
                    if (prmSynchroDtlList.Count > 0)
                    {
                        if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales)
                        {
                            status = this.stockSlipDB.ReadStockDetailWork(out retSynchroDtlList, prmSynchroDtlList, ref connection, ref transaction);
                        }
                        else if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Purchase)
                        {
                            status = this.salesSlipDB.ReadSalesDetailWork(out retSynchroDtlList, prmSynchroDtlList, ref connection, ref transaction);
                        }
                    }
                    # endregion

                    # region [�w�b�_�ǂݍ���]
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retSynchroDtlList != null && retSynchroDtlList.Count > 0)
                    {
                        foreach (object synchroDtl in retSynchroDtlList)
                        {
                            object synchroSlip = null;

                            if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Sales)
                            {
                                if (synchroDtl is StockDetailWork)
                                {
                                    StockSlipReadWork stockread = new StockSlipReadWork();
                                    stockread.EnterpriseCode = (synchroDtl as StockDetailWork).EnterpriseCode;
                                    stockread.SupplierFormal = (synchroDtl as StockDetailWork).SupplierFormal;
                                    stockread.SupplierSlipNo = (synchroDtl as StockDetailWork).SupplierSlipNo;

                                    // �����s �����f�[�^�̏ꍇ�̓w�b�_��񂪑��݂��Ȃ��� ReadStockSlipWork �͎��s���Ȃ�
                                    if (stockread.SupplierFormal != 2 || stockread.SupplierSlipNo != 0)
                                    {
                                        StockSlipWork stockslip;
                                        status = this.stockSlipDB.ReadStockSlipWork(out stockslip, stockread, ref connection);
                                        synchroSlip = stockslip;
                                    }
                                    else
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                    }

                                    //--- ADD 2009/02/05 M.Kubota --->>>
                                    if ((synchroDtl as StockDetailWork).SupplierFormal == 2)
                                    {
                                        // �������ׂ̏ꍇ��UOE�������׃f�[�^�̓Ǎ��ݏ���������
                                        uoeDtlWrk = new UOEOrderDtlWork();
                                        uoeDtlWrk.EnterpriseCode = (synchroDtl as StockDetailWork).EnterpriseCode;    // ��ƃR�[�h
                                        uoeDtlWrk.SupplierFormal = (synchroDtl as StockDetailWork).SupplierFormal;    // �d���`��
                                        uoeDtlWrk.StockSlipDtlNum = (synchroDtl as StockDetailWork).StockSlipDtlNum;  // �d�����גʔ�
                                        
                                        prmUOEOrderDtlList.Add(uoeDtlWrk);
                                    }
                                    //--- ADD 2009/02/05 M.Kubota ---<<<
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else if (this.CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.Purchase)
                            {
                                if (synchroDtl is SalesDetailWork)
                                {

                                    SalesSlipReadWork salesread = new SalesSlipReadWork();
                                    salesread.EnterpriseCode = (synchroDtl as SalesDetailWork).EnterpriseCode;
                                    salesread.AcptAnOdrStatus = (synchroDtl as SalesDetailWork).AcptAnOdrStatus;
                                    salesread.SalesSlipNum = (synchroDtl as SalesDetailWork).SalesSlipNum;

                                    SalesSlipWork salesslip;

                                    status = this.salesSlipDB.ReadSalesSlipWork(out salesslip, salesread, ref connection);
                                    synchroSlip = salesslip;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                CustomSerializeArrayList baseList = new CustomSerializeArrayList();

                                if (synchroSlip != null)
                                {
                                    baseList.Add(synchroSlip);
                                }

                                if (synchroDtl != null)
                                {
                                    (baseList[baseList.Add(new ArrayList())] as ArrayList).Add(synchroDtl);
                                    retSynchroList.Add(baseList);
                                }
                            }
                            else
                            {
                                return status;
                            }
                        }
                    }

                    #endregion

                    # region [UOE�����f�[�^�ǂݍ���]
                    //--- ADD 2009/02/05 M.Kubota --->>>
                    if (ListUtils.IsNotEmpty(prmUOEOrderDtlList))
                    {
                        ArrayList retUOEList = null;
                        status = this.uoeIOWriteDB.Search(prmUOEOrderDtlList, out retUOEList, ref connection, ref transaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            retSynchroList.Add(retUOEList);
                        }
                    }
                    //--- ADD 2009/02/05 M.Kubota ---<<<
                    # endregion
                }
                # endregion
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                }
            }

            return status;
        }

        # endregion

        # region [��������]

        /// <summary>
        /// �`�[�f�[�^�o�^����
        /// </summary>
        /// <param name="paraList">�X�V���I�u�W�F�N�g���X�g</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <returns>STATUS</returns>
        public int Write(ref object paraList, out string retMsg, out string retItemInfo)
        {
            // �߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlEncryptInfo encryptinfo = null;
            
            if (SlipListUtils.IsEmpty(paraList as ArrayList))
            {
                retMsg = "�X�V��񃊃X�g�����o�^�ł��B"; // �� �I��
            }
            else
            {
                try
                {
                    ArrayList list = paraList as ArrayList;
                    status = this.WriteProc(ref list, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                    
                    if (transaction != null && transaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);

                    retMsg += (string.IsNullOrEmpty(retMsg) ? "" : "\n") + ex.Message;

                    if (transaction != null && transaction.Connection != null)
                    {
                        transaction.Rollback();
                    }
                }
                finally
                {
                    // �g�����U�N�V�����̔j��
                    if (transaction != null)
                    {
                        transaction.Dispose();
                    }

                    // �Í����L�[�̃N���[�Y
                    //if (encryptinfo != null && encryptinfo.IsOpen)
                    //{
                    //    encryptinfo.CloseSymKey(ref connection);
                    //}

                    // �R�l�N�V�����̔j��
                    if (connection != null)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// �`�[�f�[�^�o�^����
        /// </summary>
        /// <param name="paramlist"></param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int WriteProc(ref ArrayList paramlist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {   
            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;
            // -------- ADD 2017/03/30 ���O Redmine#49164 ---------------- >>>>>
            ArrayList pmTabSessionMngList = null;
            PmTabSessionMngWork pmTabSessionMngWork = null;
            object resultPmTabSeesionMngObj = null;
            // ------- ADD 2017/03/30 ���O Redmine#49164 ---------------- <<<<<

            //���e��p�����[�^�̊m�F���s��
            # region [�p�����[�^�`�F�b�N]
            
            //���X�V��񃊃X�g�`�F�b�N
            if (SlipListUtils.IsEmpty(paramlist))
            {
                retMsg = "�X�V��񃊃X�g�����o�^�ł��B";
                return status;
            }

            //������E�d������I�v�V�����`�F�b�N
            this.CtrlOptWork = SlipListUtils.Find(paramlist, typeof(IOWriteCtrlOptWork), SlipListUtils.FindType.Class) as IOWriteCtrlOptWork;

            if (this.CtrlOptWork == null)
            {
                retMsg = "����E�d������I�v�V������������܂���B";
                return status;
            }

            // --- ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
            string enterpriseCode = this.CtrlOptWork.EnterpriseCode;

            // ��ƃR�[�h���󗓂̏ꍇ
            if (string.IsNullOrEmpty(enterpriseCode))
            {
                try
                {
                    ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                    enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                    // �T�[�o�[�����ʕ��i�ŋ󗓂̊�ƃR�[�h���擾�����ꍇ
                    if (string.IsNullOrEmpty(enterpriseCode))
                    {
                        base.WriteErrorLog("IOWriteControlDB.WriteProc:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                    }
                }
                catch
                {
                    base.WriteErrorLog("IOWriteControlDB.WriteProc:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                }
            }
            // ���b�N���\�[�X��
            string resNm = this.GetResourceName(enterpriseCode);
            // --- ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<

            //���R�l�N�V�����`�F�b�N
            if (connection == null)
            {
                connection = this.CreateSqlConnection(true);
            }

            if (connection == null)
            {
                retMsg = "�f�[�^�x�[�X�֐ڑ��o���܂���B";
                base.WriteErrorLog(string.Format("IOWriteControlDB.WriteProc_connection:{0}", retMsg), status);  // ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                return status;
            }

            # region [--- �Í��� �ۗ� ---]
            /* --- �ۗ� ---
            //���Í����L�[�`�F�b�N
            if (encryptinfo == null)
            {
                List<string> ConcatArray = new List<string>();
                
                // �Í����Ώۂ̔���f�[�^�n�e�[�u�����X�g���擾
                ConcatArray.AddRange(IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
                
                // �Í����Ώۂ̎d���f�[�^�n�e�[�u�����X�g���擾
                ConcatArray.AddRange(IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
                
                // �e�[�u�����X�g�̌���
                string[] tablenames = ConcatArray.ToArray();

                encryptinfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, tablenames);
            }

            if (encryptinfo == null)
            {
                retMsg = "�Í����L�[���쐬�o���܂���B";
                return status;
            }

            encryptinfo.OpenSymKey(ref connection);

            if (!encryptinfo.IsOpen)
            {
                retMsg = "�Í����L�[���I�[�v���o���܂���B";
                return status;
            }
            */
            # endregion

            //���g�����U�N�V�����`�F�b�N
            if (transaction == null)
            {
                transaction = this.CreateTransaction(ref connection);
            }

            if (transaction == null)
            {
                retMsg = "�g�����U�N�V�������J�n�ł��܂���B";
                base.WriteErrorLog(string.Format("IOWriteControlDB.WriteProc_transaction:{0}", retMsg), status);  // ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                return status;
            }

            # endregion

            //������N�_�ɉ����čX�V��񃊃X�g���Ɋi�[����Ă���`�[�f�[�^����ѕς���                
            SlipTypeComparer sliptypecomparer = new SlipTypeComparer();

            sliptypecomparer.SortType = (this.CtrlOptWork.CtrlStartingPoint == 0) ? SlipTypeComparer.SlipSortType.Sales : SlipTypeComparer.SlipSortType.Purchase;
            paramlist.Sort(sliptypecomparer);

            Hashtable new2org = new Hashtable();

            //���r�����b�N���J�n����
            #if !DEBUG // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
            ShareCheckInfo info = null;
            // --- UPD m.suzuki 2010/08/17 ---------->>>>>
            //this.ShareCheckInitialize(paramlist, ref info);
            this.ShareCheckInitialize(paramlist, ref info, ref connection, ref transaction);
            // --- UPD m.suzuki 2010/08/17 ----------<<<<<
            // --- ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
            try
            {
            // --- ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                status = this.ShareCheck(info, LockControl.Locke, connection, transaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            // --- ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteControlDB.WriteProc_ShareCheckLocke:" + ex.ToString());
                throw ex;
            }
            // --- ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<

            // --- ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
            //status = this.Lock(this.ResourceName, connection, transaction);
            // �O���[�o���ϐ��̑���Ƀ��[�J���̃��\�[�X�����g�p����
            status = this.Lock(resNm, connection, transaction);
            // --- ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    retMsg = "���b�N�^�C���A�E�g���������܂����B";
                }
                else
                {
                    retMsg = "�r�����b�N�Ɏ��s���܂����B";
                }
                base.WriteErrorLog(string.Format("IOWriteControlDB.WriteProc_Lock:{0}", retMsg), status);  // ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                return status;
            }
# endif

            try
            {
                // ----------- ADD 2017/03/30 ���O Redmine#49164 ---------------- >>>>
                // ��n��������paramlist��������
                status = GetPmtabSessionMng(ref paramlist, ref pmTabSessionMngList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                {
                    retMsg += "IOWriteControlDB.WriteProc: �`�[�f�[�^�̓o�^���������Ɏ��s���܂����B(SessionMng)";
                    return status;
                }
                else if (pmTabSessionMngList != null && pmTabSessionMngList.Count > 0)
                {
                    pmTabSessionMngWork = pmTabSessionMngList[0] as PmTabSessionMngWork;
                    // ����Z�b�V����ID�̑��݃`�F�b�N
                    status = this.pmTabSessionMngDB.SearchSessionIdProc(pmTabSessionMngWork, out resultPmTabSeesionMngObj, ref connection, ref transaction, out retMsg);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        pmTabSessionMngList.Clear();
                        foreach(PmTabSessionMngWork pmTabWork in (resultPmTabSeesionMngObj as ArrayList))
                        {
                            pmTabSessionMngList.Add(pmTabWork);
                        }
                        retMsg += (!string.IsNullOrEmpty(retMsg) ? "\n" : "") + "IOWriteControlDB.WriteProc: ����Z�b�V����ID�����݂��܂��B";
                        return status;
                    }
                    else
                    {
                        retMsg += "IOWriteControlDB.WriteProc: �`�[�f�[�^�̓o�^���������Ɏ��s���܂����B(SessionId)";
                        return status;
                    }
                }

                // ----------- ADD 2017/03/30 ���O Redmine#49164 ---------------- <<<<

                //���X�V��񃊃X�g���Ɋi�[����Ă���`�[�f�[�^�̓`�[��ނ����ɔ���E�d���̓`�[�o�^�����������Ăяo��
                # region [�o�^�f�[�^��������]

                foreach (object item in paramlist)
                {
                    if (item is IOWriteCtrlOptWork)
                    {
                        continue;
                    }
                    else
                    {
                        SlipType slipType = SlipListUtils.GetSlipType(item);
                        

                        ArrayList newSliplist = item as ArrayList;
                        ArrayList orgSliplist = null;

                        switch (slipType)
                        {
                            case SlipType.Estimation:
                            case SlipType.AcceptAnOrder:
                            case SlipType.Shipment:
                            case SlipType.Sales:
                                {
                                    // ����n�f�[�^�o�^��������
                                    status = this.SalesWriteInitialize(out orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        new2org.Add(newSliplist, orgSliplist);
                                    }
                                    break;
                                }
                            case SlipType.Order:
                            case SlipType.Arrival:
                            case SlipType.Purchase:
                                {
                                    // �d���n�f�[�^�o�^��������
                                    status = this.PurchaseWriteInitialize(out orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        new2org.Add(newSliplist, orgSliplist);
                                    }
                                    break;
                                }
                            case SlipType.UoeOrder:
                                {
                                    // UOE�������׃f�[�^�o�^��������
                                    status = this.UoeOrderWriteInitialize(out orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        new2org.Add(newSliplist, orgSliplist);
                                    }
                                    break;
                                }
                            case SlipType.StockAdjust:
                                {
                                    // �݌ɒ����f�[�^�o�^��������
                                    // �����ɖ���
                                    break;
                                }
                            case SlipType.PurchaseDel:
                            case SlipType.SalesDel:                        
                                {
                                    // �d���E����폜����
                                    // ���o�^���������̒��œo�^�ςݓ`�[�f�[�^��Ǎ���ł���ׁA�폜�����͍ŏ��ɍs���K�v������

                                    int orgCtrlStartingPoint = this.CtrlOptWork.CtrlStartingPoint;

                                    // �`�[�폜�p�p�����[�^���X�g�̍쐬
                                    ArrayList delPrm = new ArrayList();
                                    delPrm.Add(this.CtrlOptWork);
                                    delPrm.Add(item);

                                    if (slipType == SlipType.PurchaseDel)
                                    {
                                        // �d���폜�̏ꍇ�͋����I�ɐ���N�_���d���ɂ���
                                        this.CtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Purchase;
                                    }
                                    else
                                    {
                                        // ����폜�̏ꍇ�͋����I�ɐ���N�_�𔄏�ɂ���
                                        this.CtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;
                                    }

                                    try
                                    {
                                        status = this.DeleteProc(ref delPrm, 1, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                    }
                                    finally
                                    {
                                        this.CtrlOptWork.CtrlStartingPoint = orgCtrlStartingPoint;
                                    }

                                    break;
                                }
                            #region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
                            //case SlipType.SalesTemp:
                            //    {
                            //        // ����ꎞ�f�[�^�o�^��������
                            //        status = this.SalesTempWriteInitialize(ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                            //        break;
                            //    }
                            #endregion
                        }

                        // �o�^���������Ɏ��s�����ꍇ�͏����𒆒f����
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            retMsg += (!string.IsNullOrEmpty(retMsg) ? "\n" : "") + string.Format("IOWriteControlDB.WriteProc: �`�[�f�[�^�̓o�^���������Ɏ��s���܂����B(SlipType = {0})", Enum.GetName(typeof(SlipType), slipType));
                            break;
                        }
                    }
                }
                # endregion

                //���X�V��񃊃X�g���Ɋi�[����Ă���`�[�f�[�^�̓`�[��ނ����ɔ���E�d���̓`�[�o�^�������Ăяo��
                # region [�f�[�^�o�^����]
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (object item in paramlist)
                    {
                        if (item is IOWriteCtrlOptWork)
                        {
                            continue;
                        }

                        if (item is ArrayList)
                        {
                            ArrayList newSliplist = item as ArrayList;
                            ArrayList orgSliplist = null;

                            SlipType slipType = SlipListUtils.GetSlipType(newSliplist);

                            switch (slipType)
                            {
                                case SlipType.Estimation:
                                case SlipType.AcceptAnOrder:
                                case SlipType.Shipment:
                                case SlipType.Sales:
                                    {
                                        // ����n�f�[�^�o�^����
                                        orgSliplist = new2org[newSliplist] as ArrayList;
                                        status = this.SalesWrite(orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                                        // --------------------- ADD 2017/03/30 ���O Redmine#49164 ---------------- >>>>
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && pmTabSessionMngWork != null)
                                        {
                                            SalesSlipWork slipTab = SlipListUtils.Find(newSliplist, typeof(SalesSlipWork), SlipListUtils.FindType.Class) as SalesSlipWork;

                                            if (slipTab != null)
                                            {
                                                // PMTAB�Z�b�V�����Ǘ��f�[�^�̐V�K�ǉ�����
                                                pmTabSessionMngWork.SalesSlipNum = slipTab.SalesSlipNum;
                                                status = this.pmTabSessionMngDB.WriteSessionMngProc(ref pmTabSessionMngWork, ref connection, ref transaction, out retMsg);
                                                break;
                                            }
                                        }
                                        // --------------------- ADD 2017/03/30 ���O Redmine#49164 ---------------- <<<<

                                        #region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
                                        #if false
                                        // �d�����㓯���o�^���w�肳��Ă���ۂɔ���f�[�^�̓o�^�����������ꍇ
                                        // ����ꎞ�f�[�^�̍폜���s���B
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                                            this._CtrlOptWork.CtrlStartingPoint == (int)IOWriteCtrlOptCtrlStartingPoint.PurchaseAndSales)
                                        {
                                            ArrayList salestmplist = SlipListUtils.Find(newSliplist, typeof(SalesTempWork), SlipListUtils.FindType.Array) as ArrayList;

                                            if (SlipListUtils.IsNotEmpty(salestmplist))
                                            {
                                                status = this.salesTempDB.Delete(salestmplist, ref connection, ref transaction);
                                            }
                                        }
                                        #endif
                                        #endregion

                                        break;
                                    }
                                case SlipType.Order:
                                case SlipType.Arrival:
                                case SlipType.Purchase:
                                    {
                                        // �d���n�f�[�^�o�^����
                                        orgSliplist = new2org[newSliplist] as ArrayList;
                                        status = this.PurchaseWrite(orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                        break;
                                    }
                                case SlipType.StockAdjust:
                                    {
                                        // �݌ɒ����f�[�^�o�^����
                                        object obj = newSliplist;
                                        // 2009/02/25 MANTIS 11807 >>>>>>>>>>>>>>>>
                                        //status = this.stcAdjustDb.Write(ref obj, out retMsg, ref connection, ref transaction);
                                        //IOWriter�ŃV�F�A�`�F�b�N�������邽�߁A�݌Ɏd���ł̓V�F�A�`�F�b�N�Ȃ����\�b�h�̌Ăяo�����s��
                                        status = this.stcAdjustDb.WriteStockAdjustSlipDtl(ref obj, out retMsg, ref connection, ref transaction);
                                        // 2009/02/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                        break;
                                    }
                                case SlipType.UoeOrder:
                                    {
                                        // UOE�����f�[�^�o�^����    
                                        orgSliplist = new2org[newSliplist] as ArrayList;
                                        status = this.UoeOrderWrite(orgSliplist, ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                        break;
                                    }
                                #region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
                                #if false
                                case SlipType.SalesTemp:
                                    {
                                        // ����ꎞ�f�[�^�o�^����
                                        status = this.SalesTempWrite(ref newSliplist, ref paramlist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                        break;
                                    }
                                #endif
                                #endregion
                            }

                            // �o�^�����Ɏ��s�����ꍇ�͏����𒆒f����
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg += (!string.IsNullOrEmpty(retMsg) ? "\n" : "") + string.Format("IOWriteControlDB.WriteProc: �`�[�f�[�^�̓o�^�����Ɏ��s���܂����B(SlipType = {0})", Enum.GetName(typeof(SlipType), slipType));
                                break;
                            }
                        }
                    }
                }
                
                # endregion
            }
            finally
            {
                #if !DEBUG // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
                // --- UPD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                //���r�����b�N����������
                //this.Release(this.ResourceName, connection, transaction);
                //this.ShareCheck(info, LockControl.Release, connection, transaction);
                int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                if (connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.WriteProc_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                }
                else if (transaction == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.WriteProc_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                }
                else if (transaction.Connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.WriteProc_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                }
                else
                {
                    //���r�����b�N����������
                    releaseStatus = this.Release(resNm, connection, transaction);
                    if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        base.WriteErrorLog("IOWriteControlDB.WriteProc_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                    }
                }
                // �V�F�A�`�F�b�N
                if (connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.WriteProc_ShareCheckRelease: �V�F�A�`�F�b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                }
                else if (transaction == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.WriteProc_ShareCheckRelease: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                }
                else if (transaction.Connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.WriteProc_ShareCheckRelease: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                }
                else
                {
                    // �V�F�A�`�F�b�N����
                    releaseStatus = this.ShareCheck(info, LockControl.Release, connection, transaction);
                    if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        base.WriteErrorLog("IOWriteControlDB.WriteProc_ShareCheckRelease: �V�F�A�`�F�b�N���������Ɏ��s���܂����B", releaseStatus);
                    }
                }
                // --- UPD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
#endif
                //���o�^���������ɂă_�~�[�̔����f�[�^�����X�g�ɒǉ�����Ă���ꍇ�͍폜����
                foreach (object item in paramlist)
                {
                    ArrayList list = item as ArrayList;
                    if (SlipListUtils.IsNotEmpty(list))
                    {
                        OrderSlipWork orderSlip = SlipListUtils.Find(list, typeof(OrderSlipWork), ListUtils.FindType.Class) as OrderSlipWork;

                        if (orderSlip != null)
                        {
                            list.Remove(orderSlip);
                        }
                    }
                }
                // ------- ADD 2017/03/30 ���O Redmine#49164 ---------------- >>>>>
                // PMTAB�Z�b�V�����Ǘ��f�[�^���������J������
                pmTabSessionMngWork = null;
                resultPmTabSeesionMngObj = null;
                // ------- ADD 2017/03/30 ���O Redmine#49164 ---------------- <<<<<
            }

            return status;
        }

        # region [����f�[�^�̓o�^����]
        /// <summary>
        /// ����n�`�[�f�[�^�o�^����������
        /// </summary>
        /// <param name="orgsliplist">�o�^�Ώۂ̍X�V�O�`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="newsliplist">�o�^�Ώۂ̓`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="otherdatalist">���̑��̊֘A�`�[�f�[�^���܂ރ��X�g(�o�^�Ώۃf�[�^���܂�)</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        private int SalesWriteInitialize(out ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //>>>2011/12/08
            #region �v�㌳����ݒ�
            SlipType slipType = SlipListUtils.GetSlipType(newsliplist);
            if (slipType == SlipType.AcceptAnOrder)
            {
                if (this.salesIOWriteDB.SameInputAcptList == null)
                {
                    ArrayList al = new ArrayList();
                    this.salesIOWriteDB.SameInputAcptList = al;
                    ((ArrayList)this.salesIOWriteDB.SameInputAcptList).Add((ArrayList)newsliplist.Clone());
                }
                else
                {
                    ((ArrayList)this.salesIOWriteDB.SameInputAcptList).Add((ArrayList)newsliplist.Clone());
                }
            }
            #endregion
            //<<<2011/12/08

            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //�����ナ���[�g�̓o�^�������������s����
            status = this.salesIOWriteDB.WriteInitialize(out orgsliplist, ref newsliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            //�����ʒʔԁE�󒍔ԍ��E���㖾�גʔԂ��v���E�����v���̖��גʔԂ֐ݒ肷��
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SalesSlipWork slip = SlipListUtils.Find(newsliplist, typeof(SalesSlipWork), SlipListUtils.FindType.Class) as SalesSlipWork;
                ArrayList slipdtls = SlipListUtils.Find(newsliplist, typeof(SalesDetailWork), SlipListUtils.FindType.Array) as ArrayList;

                if (slip != null && slipdtls != null)
                {
                    //// �ԓ`��ԕi�`�[�̏ꍇ�͊֘A���ׂɒʔԂ�ݒ肵�Ȃ�
                    //if (slip.DebitNoteDiv != 1 && slip.SalesSlipCd != 1)
                    
                    // �ԓ`�̏ꍇ�͊֘A���ׂɒʔԂ�ݒ肵�Ȃ�
                    if (slip.DebitNoteDiv != 1)
                    {
                        // ���גP�ʂŏ������s��
                        foreach (SalesDetailWork salesdtl in slipdtls)
                        {
                            object dtlrelation = null;

                            // �󒍃X�e�[�^�X(�v�㌳)�Ń����N���Ă��閾�׃f�[�^���擾����
                            dtlrelation = SlipListUtils.FindSlipDetail(otherdatalist, SlipListUtils.FindItem.Source, (SlipType)Enum.Parse(typeof(SlipType), salesdtl.AcptAnOdrStatus.ToString()), salesdtl.DtlRelationGuid, salesdtl);

                            if (dtlrelation != null)
                            {
                                (dtlrelation as SalesDetailWork).CommonSeqNo = salesdtl.CommonSeqNo;             // ���ʒʔ�
                                (dtlrelation as SalesDetailWork).AcceptAnOrderNo = salesdtl.AcceptAnOrderNo;     // �󒍔ԍ�
                                (dtlrelation as SalesDetailWork).SalesSlipDtlNumSrc = salesdtl.SalesSlipDtlNum;  // ���㖾�גʔ�(�v�㌳)
                            }

                            // �󒍃X�e�[�^�X�Ń����N���Ă���UOE�������׃f�[�^���擾����
                            dtlrelation = SlipListUtils.FindSlipDetail(otherdatalist, SlipListUtils.FindItem.UoeOrder, (SlipType)Enum.Parse(typeof(SlipType), salesdtl.AcptAnOdrStatus.ToString()), salesdtl.DtlRelationGuid, salesdtl);

                            if (dtlrelation != null)
                            {
                                (dtlrelation as UOEOrderDtlWork).CommonSeqNo = salesdtl.CommonSeqNo;             // ���ʒʔ�
                                (dtlrelation as UOEOrderDtlWork).SalesSlipNum = salesdtl.SalesSlipNum;           // ����`�[�ԍ�(�󒍓`�[�ԍ�)
                                (dtlrelation as UOEOrderDtlWork).AcptAnOdrStatus = salesdtl.AcptAnOdrStatus;     // �󒍃X�e�[�^�X(20:��)
                                (dtlrelation as UOEOrderDtlWork).SalesSlipDtlNum = salesdtl.SalesSlipDtlNum;     // ���㖾�גʔ�
                            }

                            // �d���`��(�����v��)�Ń����N���Ă��閾�׃f�[�^���擾����
                            dtlrelation = SlipListUtils.FindSlipDetail(otherdatalist, SlipListUtils.FindItem.Synchronize, (SlipType)Enum.Parse(typeof(SlipType), salesdtl.AcptAnOdrStatus.ToString()), salesdtl.DtlRelationGuid, salesdtl);

                            if (dtlrelation != null)
                            {
                                (dtlrelation as StockDetailWork).CommonSeqNo = salesdtl.CommonSeqNo;             // ���ʒʔ�
                                (dtlrelation as StockDetailWork).AcceptAnOrderNo = salesdtl.AcceptAnOrderNo;     // �󒍔ԍ�
                                (dtlrelation as StockDetailWork).SalesSlipDtlNumSync = salesdtl.SalesSlipDtlNum; // ���㖾�גʔ�(����)
                            }
                        }
                    }
                }
                else
                {
                    retMsg += (string.IsNullOrEmpty(retMsg) ? "" : "\n") + "IOWriteControlDB.SalesWriteInitialize: ���㖾�׃f�[�^���ݒ肳��Ă��܂���B";
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }

            return status;
        }

        /// <summary>
        /// ����n�`�[�f�[�^�o�^
        /// </summary>
        /// <param name="orgsliplist">�o�^�Ώۂ̍X�V�O�`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="newsliplist">�o�^�Ώۂ̓`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="otherdatalist">���̑��̊֘A�`�[�f�[�^���܂ރ��X�g(�o�^�Ώۃf�[�^���܂�)</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        private int SalesWrite(ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //�����ナ���[�g�̓o�^���������s����
            status = this.salesIOWriteDB.WriteA(orgsliplist, ref newsliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            return status;
        }
        # endregion

        # region [�d���f�[�^�̓o�^����]
        /// <summary>
        /// �d���n�`�[�f�[�^�o�^����������
        /// </summary>
        /// <param name="orgsliplist">�o�^�Ώۂ̍X�V�O�`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="newsliplist">�o�^�Ώۂ̓`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="otherdatalist">���̑��̊֘A�`�[�f�[�^���܂ރ��X�g(�o�^�Ώۃf�[�^���܂�)</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        private int PurchaseWriteInitialize(out ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            StockSlipWork slip = SlipListUtils.Find(newsliplist, typeof(StockSlipWork), SlipListUtils.FindType.Class) as StockSlipWork;
            ArrayList slipdtls = SlipListUtils.Find(newsliplist, typeof(StockDetailWork), SlipListUtils.FindType.Array) as ArrayList;

            if (slip == null)
            {
                if (SlipListUtils.IsNotEmpty(slipdtls))
                {
                    StockDetailWork orderDetail = (slipdtls[0] as StockDetailWork);

                    // 2009/02/12 >>>>>>>>>>>>>>>>>>>>>> 
                    //�����d����M�����A�d�b�����̏ꍇ�̑Ή�
                    //if (orderDetail != null && orderDetail.SupplierFormal == (int)SlipType.Order)
                    if (orderDetail != null && orderDetail.SupplierFormal == (int)SlipType.Order && slip == null)
                    // 2009/02/12 <<<<<<<<<<<<<<<<<<<<<<
                    {
                        // �d�����׃f�[�^�̎d���`���� 2:���� �ŁA���d���f�[�^�����݂��Ȃ��ꍇ�͔������͂Ƃ݂Ȃ�
                        slip = new OrderSlipWork();

                        slip.EnterpriseCode = orderDetail.EnterpriseCode;  // ��ƃR�[�h
                        slip.SupplierFormal = 2;                           // �d���`�� = 2:����      �Œ�
                        slip.SupplierSlipCd = 10;                          // �d���`�[�敪 = 10:�d�� �Œ�
                        slip.SectionCode = orderDetail.SectionCode;        // ���_�R�[�h
                        slip.SubSectionCode = orderDetail.SubSectionCode;  // ����R�[�h

                        newsliplist.Add(slip);  // �_�~�[�̔����f�[�^��o�^����
                    }
                }
            }

            //���d�������[�g�̓o�^�������������s����
            status = this.purchaseIOWriteDB.WriteInitialize(out orgsliplist, ref newsliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            //�����ʒʔԁE�󒍔ԍ��E�d�����גʔԂ��v���E�����v���̖��גʔԂ֐ݒ肷��
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                if (slip != null && slipdtls != null)
                {
                    //// �ԓ`��ԕi�`�[�̏ꍇ�͊֘A���ׂɒʔԂ�ݒ肵�Ȃ�
                    //if (slip.DebitNoteDiv != 1 && slip.SupplierSlipCd != 20)
                    
                    // �ԓ`�̏ꍇ�͊֘A���ׂɒʔԂ�ݒ肵�Ȃ�
                    if (slip.DebitNoteDiv != 1)
                    {
                        // ���גP�ʂŏ������s��
                        foreach (StockDetailWork stockdtl in slipdtls)
                        {
                            object dtlrelation = null;

                            // �d���`��(�v�㌳)�Ń����N���Ă��閾�׃f�[�^���擾����
                            dtlrelation = SlipListUtils.FindSlipDetail(otherdatalist, SlipListUtils.FindItem.Source, (SlipType)Enum.Parse(typeof(SlipType), stockdtl.SupplierFormal.ToString()), stockdtl.DtlRelationGuid, stockdtl);

                            if (dtlrelation != null)
                            {
                                (dtlrelation as StockDetailWork).CommonSeqNo = stockdtl.CommonSeqNo;             // ���ʒʔ�
                                (dtlrelation as StockDetailWork).AcceptAnOrderNo = stockdtl.AcceptAnOrderNo;     // �󒍔ԍ�
                                (dtlrelation as StockDetailWork).StockSlipDtlNumSrc = stockdtl.StockSlipDtlNum;  // �d�����גʔ�(�v�㌳)
                            }

                            // �󒍃X�e�[�^�X(�����v��)�Ń����N���Ă��閾�׃f�[�^���擾����
                            dtlrelation = SlipListUtils.FindSlipDetail(otherdatalist, SlipListUtils.FindItem.Synchronize, (SlipType)Enum.Parse(typeof(SlipType), stockdtl.SupplierFormal.ToString()), stockdtl.DtlRelationGuid, stockdtl);

                            if (dtlrelation != null)
                            {
                                (dtlrelation as SalesDetailWork).CommonSeqNo = stockdtl.CommonSeqNo;             // ���ʒʔ�
                                (dtlrelation as SalesDetailWork).AcceptAnOrderNo = stockdtl.AcceptAnOrderNo;     // �󒍔ԍ�
                                (dtlrelation as SalesDetailWork).StockSlipDtlNumSync = stockdtl.StockSlipDtlNum; // �d�����גʔ�(����)
                            }

                            // �d���`���Ń����N���Ă���UOE�������׃f�[�^���擾����
                            dtlrelation = SlipListUtils.FindSlipDetail(otherdatalist, SlipListUtils.FindItem.UoeOrder, (SlipType)Enum.Parse(typeof(SlipType), stockdtl.SupplierFormal.ToString()), stockdtl.DtlRelationGuid, stockdtl);

                            // 2008/02/18 ���ɍX�V�Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //if (dtlrelation != null)
                            if (dtlrelation != null && (dtlrelation as UOEOrderDtlWork).StockSlipDtlNum == 0)
                            // 2008/02/18 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            {
                                (dtlrelation as UOEOrderDtlWork).CommonSeqNo = stockdtl.CommonSeqNo;             // ���ʒʔ�
                                (dtlrelation as UOEOrderDtlWork).SupplierFormal = stockdtl.SupplierFormal;       // �d���`��
                                (dtlrelation as UOEOrderDtlWork).SupplierSlipNo = stockdtl.SupplierSlipNo;       // �d���`�[�ԍ�
                                (dtlrelation as UOEOrderDtlWork).StockSlipDtlNum = stockdtl.StockSlipDtlNum;     // �d�����גʔ�
                            }

                            #region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
#if false                            
                            // ���׊֘A�t��GUID�Ń����N���Ă��锄��ꎞ�f�[�^���擾����
                            dtlrelation = SlipListUtils.FindSlipDetail(otherdatalist, SlipListUtils.FindItem.SalesTemp, (SlipType)Enum.Parse(typeof(SlipType), stockdtl.SupplierFormal.ToString()), stockdtl.DtlRelationGuid, stockdtl);

                            if (dtlrelation != null)
                            {
                                (dtlrelation as SalesTempWork).CommonSeqNo = stockdtl.CommonSeqNo;             // ���ʒʔ�
                                (dtlrelation as SalesTempWork).AcceptAnOrderNo = stockdtl.AcceptAnOrderNo;     // �󒍔ԍ�
                                (dtlrelation as SalesTempWork).StockSlipDtlNumSync = stockdtl.StockSlipDtlNum; // �d�����גʔ�(����)
                                (dtlrelation as SalesTempWork).StockUpdateSecCd = slip.StockUpdateSecCd;       // �݌ɍX�V���_�R�[�h
                            }
#endif
                            #endregion
                        }
                    }
                }
                else
                {
                    retMsg += (string.IsNullOrEmpty(retMsg) ? "" : "\n") + "IOWriteControlDB.PurchaseWriteInitialize: �d�����׃f�[�^���ݒ肳��Ă��܂���B";
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }

            return status;
        }

        /// <summary>
        /// �d���n�`�[�f�[�^�o�^
        /// </summary>
        /// <param name="orgsliplist">�o�^�Ώۂ̍X�V�O�`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="newsliplist">�o�^�Ώۂ̓`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="otherdatalist">���̑��̊֘A�`�[�f�[�^���܂ރ��X�g(�o�^�Ώۃf�[�^���܂�)</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        private int PurchaseWrite(ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //���d�������[�g�̓o�^���������s����
            status = this.purchaseIOWriteDB.WriteA(orgsliplist, ref newsliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            //���o�^���������ɂă_�~�[�̔����f�[�^�����X�g�ɒǉ�����Ă���ꍇ�͍폜����
            OrderSlipWork orderSlip = SlipListUtils.Find(newsliplist, typeof(OrderSlipWork), ListUtils.FindType.Class) as OrderSlipWork;
            
            if (orderSlip != null)
            {
                newsliplist.Remove(orderSlip);
            }

            return status;
        }
        # endregion

        # region [UOE�����f�[�^�̓o�^����]

        /// <summary>
        /// UOE�����f�[�^�o�^����������
        /// </summary>
        /// <param name="orgsliplist">�o�^�Ώۂ̍X�V�O�`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="newsliplist">�o�^�Ώۂ̓`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="otherdatalist">���̑��̊֘A�`�[�f�[�^���܂ރ��X�g(�o�^�Ώۃf�[�^���܂�)</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        private int UoeOrderWriteInitialize(out ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            orgsliplist = null;

            ArrayList UOEOrderDtlList = ListUtils.Find(newsliplist, typeof(UOEOrderDtlWork), ListUtils.FindType.Array) as ArrayList;

            if (ListUtils.IsNotEmpty(UOEOrderDtlList))
            {
                // UOE�����f�[�^�̃V�X�e���敪�ɉ����āA�I�����C���ԍ���UOE�����ԍ��̍̔ԏ������s��
                status = this.uoeIOWriteDB.WriteInitial(ref UOEOrderDtlList, ref connection, ref transaction);
            }

            return status;
        }

        /// <summary>
        /// UOE�����f�[�^�o�^����
        /// </summary>
        /// <param name="orgsliplist">�o�^�Ώۂ̍X�V�O�`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="newsliplist">�o�^�Ώۂ̓`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="otherdatalist">���̑��̊֘A�`�[�f�[�^���܂ރ��X�g(�o�^�Ώۃf�[�^���܂�)</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        private int UoeOrderWrite(ArrayList orgsliplist, ref ArrayList newsliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            ArrayList uoeOrderDtlList = SlipListUtils.Find(newsliplist, typeof(UOEOrderDtlWork), ListUtils.FindType.Array) as ArrayList;

            if (SlipListUtils.IsNotEmpty(uoeOrderDtlList))
            {
                status = this.uoeIOWriteDB.WriteProc(ref uoeOrderDtlList, ref connection, ref transaction);
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            return status;
        }

        # endregion

        # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
#if false
        # region [����ꎞ�f�[�^�̓o�^����]
        /// <summary>
        /// ����ꎞ�f�[�^�o�^����������
        /// </summary>
        /// <param name="sliplist">�o�^�Ώۂ̓`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="otherdatalist">���̑��̊֘A�`�[�f�[�^���܂ރ��X�g(�o�^�Ώۃf�[�^���܂�)</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        private int SalesTempWriteInitialize(ref ArrayList sliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //������ꎞ�f�[�^�����[�g�̓o�^�������������s����
            status = this.salesTempDB.WriteInitialize(ref sliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            //�����㖾�גʔԂ𓯎��v���̖��גʔԂ֐ݒ肷��
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���גP�ʂŏ������s��
                foreach (object item in sliplist)
                {
                    SalesTempWork slstmpdtl = item as SalesTempWork;
                    
                    if (slstmpdtl != null)
                    {
                        // �d���`��(�����v��)�Ń����N���Ă��閾�׃f�[�^���擾����
                        object dtlrelation = SlipListUtils.FindSlipDetail(otherdatalist, SlipListUtils.FindItem.Synchronize, (SlipType)Enum.Parse(typeof(SlipType), slstmpdtl.AcptAnOdrStatus.ToString()), slstmpdtl.DtlRelationGuid, slstmpdtl);

                        if (dtlrelation != null)
                        {
                            (dtlrelation as StockDetailWork).SalesSlipDtlNumSync = slstmpdtl.SalesSlipDtlNum;  // ���㖾�גʔ�(����)
                        }
                    }
                }
            }

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retMsg += (string.IsNullOrEmpty(retMsg) ? "" : "\n") + "IOWriteControlDB.SalesTempWriteInitialize: ����ꎞ�f�[�^���ݒ肳��Ă��܂���B";
            }

            return status;
        }

        /// <summary>
        /// ����ꎞ�f�[�^�o�^����
        /// </summary>
        /// <param name="sliplist">�o�^�Ώۂ̓`�[�w�b�_�Ɩ��ׂ��܂ރ��X�g</param>
        /// <param name="otherdatalist">���̑��̊֘A�`�[�f�[�^���܂ރ��X�g(�o�^�Ώۃf�[�^���܂�)</param>
        /// <param name="retMsg">���b�Z�[�W(��ɃG���[���b�Z�[�W)</param>
        /// <param name="retItemInfo">���ڏ��(���g�p)</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <param name="encryptinfo">�Í����L�[�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        private int SalesTempWrite(ref ArrayList sliplist, ref ArrayList otherdatalist, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //������ꎞ�����[�g�̓o�^�������������s����
            status = this.salesTempDB.Write(ref sliplist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

            return status;
        }
        # endregion
#endif
        # endregion

        // --------------------- ADD 2017/03/30 ���O Redmine#49164 ---------------- >>>>
        # region [PM�^�u���b�g���f]
        /// <summary>
        /// ����paramlist��������
        /// </summary>
        /// <param name="paramlist">�X�V��񃊃X�g</param>
        /// <param name="pmTabSeesinMngList">PMTAB�Z�b�V�����Ǘ��f�[�^���X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ��n��������paramlist������������B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/03/30</br>
        /// </remarks>
        private int GetPmtabSessionMng(ref ArrayList paramlist, ref ArrayList pmTabSeesinMngList)
        {
            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            PmTabSessionMngWork pmTabSeesinMngWork = null;
            pmTabSeesinMngList = null;

            try
            {
                //paramlist��������
                foreach (object item in paramlist)
                {
                    if (item is IOWriteCtrlOptWork)
                    {
                        continue;
                    }
                    else
                    {
                        if (item is ArrayList)
                        {
                            ArrayList slips = item as ArrayList;
                            if (SlipListUtils.IsNotEmpty(slips))
                            {
                                foreach (object subItem in slips)
                                {
                                    if (subItem is ArrayList)
                                    {
                                        ArrayList subSlips = subItem as ArrayList;
                                        if (SlipListUtils.IsNotEmpty(subSlips))
                                        {
                                            // PMTAB�Z�b�V�����Ǘ��f�[�^����������
                                            pmTabSeesinMngWork = SlipListUtils.Find(subSlips, typeof(PmTabSessionMngWork), SlipListUtils.FindType.Class) as PmTabSessionMngWork;

                                            if (pmTabSeesinMngWork != null)
                                            {
                                                pmTabSeesinMngList = subSlips;
                                                break;
                                            }
                                        }
                                    }
                                }

                                if (pmTabSeesinMngList != null)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion
        // --------------------- ADD 2017/03/30 ���O Redmine#49164 ---------------- <<<<
        # endregion

        # region [�폜����]

        /// <summary>
        /// �G���g�������폜
        /// </summary>
        /// <param name="paraList">�����폜���I�u�W�F�N�g���X�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <returns>STATUS</returns>
        public int Delete(ref object paraList, out string retMsg, out string retItemInfo)
        {
            // �߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlEncryptInfo encryptinfo = null;

            try
            {
                ArrayList paraArraylist = paraList as ArrayList;

                status = this.DeleteProc(ref paraArraylist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                if (transaction != null && transaction.Connection != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);

                retMsg += (string.IsNullOrEmpty(retMsg) ? "" : "\n") + ex.Message;

                if (transaction != null && transaction.Connection != null)
                {
                    transaction.Rollback();
                }
            }
            finally
            {
                // �g�����U�N�V�����̔j��
                if (transaction != null)
                {
                    transaction.Dispose();
                }

                // �Í����L�[�̃N���[�Y (�ۗ�)
                //if (encryptinfo != null && encryptinfo.IsOpen)
                //{
                //    encryptinfo.CloseSymKey(ref connection);
                //}

                // �R�l�N�V�����̔j��
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return status;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="encryptinfo"></param>
        /// <returns></returns>
        public int DeleteProc(ref ArrayList paraList, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            return this.DeleteProc(ref paraList, 0, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="lockMode">0:�ʏ� 0�ȊO:���b�N���Ȃ�</param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="encryptinfo"></param>
        /// <br>Note             :   �A��966 �d�����׃}�X�^�̓�����������N���A����B</br>
        /// <br>Programmer       :   ����g</br>
        /// <br>Date             :   2011/08/16</br>
        /// </remarks>
        /// <returns></returns>
        private int DeleteProc(ref ArrayList paraList, int lockMode, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            # region [�p�����[�^�`�F�b�N]

            //������E�d������I�v�V�����`�F�b�N
            this.CtrlOptWork = SlipListUtils.Find(paraList, typeof(IOWriteCtrlOptWork), SlipListUtils.FindType.Class) as IOWriteCtrlOptWork;

            if (this.CtrlOptWork == null)
            {
                retMsg = "����E�d������I�v�V������������܂���B";
                return status;
            }

            //���R�l�N�V�����`�F�b�N
            if (connection == null)
            {
                connection = this.CreateSqlConnection(true);
            }

            if (connection == null)
            {
                retMsg = "�f�[�^�x�[�X�֐ڑ��o���܂���B";
                return status;
            }

            # region [���Í����L�[�`�F�b�N  (�ۗ�)]
            //���Í����L�[�`�F�b�N  (�ۗ�)
            //if (encryptinfo == null)
            //{
            //    List<string> ConcatArray = new List<string>();

            //    // �Í����Ώۂ̔���f�[�^�n�e�[�u�����X�g���擾
            //    ConcatArray.AddRange(IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));

            //    // �Í����Ώۂ̎d���f�[�^�n�e�[�u�����X�g���擾
            //    ConcatArray.AddRange(IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));

            //    // �e�[�u�����X�g�̌���
            //    string[] tablenames = ConcatArray.ToArray();

            //    encryptinfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, tablenames);
            //}

            //if (encryptinfo == null)
            //{
            //    retMsg = "�Í����L�[���쐬�o���܂���B";
            //    return status;
            //}

            //encryptinfo.OpenSymKey(ref connection);

            //if (!encryptinfo.IsOpen)
            //{
            //    retMsg = "�Í����L�[���I�[�v���o���܂���B";
            //    return status;
            //}
            # endregion

            //���g�����U�N�V�����`�F�b�N
            if (transaction == null)
            {
                transaction = this.CreateTransaction(ref connection);
            }

            if (transaction == null)
            {
                retMsg = "�g�����U�N�V�������J�n�ł��܂���B";
                return status;
            }

            # endregion

            //���r�����b�N���J�n����
            #if DEBUG // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
            ShareCheckInfo info = null;
            // --- UPD m.suzuki 2010/08/17 ---------->>>>>
            //this.ShareCheckInitialize(paraList, ref info);
            this.ShareCheckInitialize( paraList, ref info, ref connection, ref transaction );
            // --- UPD m.suzuki 2010/08/17 ----------<<<<<

            if (info.Keys.Count != 0)
            {
                status = this.ShareCheck(info, LockControl.Locke, connection, transaction);
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            if (lockMode == 0)
            {
                status = this.Lock(this.ResourceName, connection, transaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        retMsg = "���b�N�^�C���A�E�g���������܂����B";
                    }
                    else
                    {
                        retMsg = "�r�����b�N�Ɏ��s���܂����B";
                    }

                    return status;
                }
            }
            # endif

            try
            {
                # region [�f�[�^�폜����]
                //���X�V��񃊃X�g���Ɋi�[����Ă���`�[�f�[�^�̓`�[��ނ����ɔ���E�d���̓`�[�폜�������Ăяo��
                CustomSerializeArrayList paracuslist = new CustomSerializeArrayList();

                switch (this.CtrlOptWork.CtrlStartingPoint)
                {
                    case (int)IOWriteCtrlOptCtrlStartingPoint.Sales:
                        {
                            foreach (object listItem in paraList)
                            {
                                int findObjPos = -1;
                                paracuslist.Clear();

                                if (listItem is ArrayList)
                                {
                                    // ����f�[�^�폜�p�I�u�W�F�N�g�̑��݃`�F�b�N
                                    SlipListUtils.Find((listItem as ArrayList), typeof(IOWriteMAHNBDeleteWork), SlipListUtils.FindType.Class, out findObjPos);

                                    if (findObjPos >= 0)
                                    {
                                        // ����f�[�^�̍폜����
                                        paracuslist.AddRange(listItem as ArrayList);
                                        status = this.salesIOWriteDB.Delete(ref paracuslist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                    }
                                    # region [--- DEL 2008/12/02 ---]
                                    //else if (this.CtrlOptWork.SupplierSlipDelDiv != 0)
                                    //{
                                    //    // �d���`�[�폜�敪���ݒ肳��Ă���ꍇ�A����f�[�^�̍폜�Ɠ����Ɏd���f�[�^�̍폜���s��
                                    //    SlipListUtils.Find((listItem as ArrayList), typeof(IOWriteMASIRDeleteWork), SlipListUtils.FindType.Class, out findObjPos);

                                    //    if (findObjPos >= 0)
                                    //    {
                                    //        // ���ׁE�d���f�[�^�̍폜�p�����[�^��ݒ�
                                    //        paracuslist.AddRange(listItem as ArrayList);
                                    //    }
                                    //    else
                                    //    {
                                    //        SlipListUtils.Find((listItem as ArrayList), typeof(StockDetailWork), SlipListUtils.FindType.Class, out findObjPos);

                                    //        if (findObjPos >= 0 && ((listItem as ArrayList)[findObjPos] as StockDetailWork).SupplierFormal == 2)
                                    //        {
                                    //            IOWriteMASIRDeleteWork dummyIOWriteMASIRDelete = new IOWriteMASIRDeleteWork();

                                    //            // �_�~�[�d���f�[�^�ɕK�v�ȍ��ڂ�ݒ肷��
                                    //            dummyIOWriteMASIRDelete.EnterpriseCode = ((listItem as ArrayList)[findObjPos] as StockDetailWork).EnterpriseCode;  // ��ƃR�[�h
                                    //            dummyIOWriteMASIRDelete.SupplierFormal = 2;                        // �d���`�� = 2:���� �Œ�
                                    //            dummyIOWriteMASIRDelete.SupplierSlipNo = 0;                        // �d���`�[�ԍ� = 0  �Œ�
                                    //            dummyIOWriteMASIRDelete.DebitNoteDiv = 0;                          // �ԓ`�敪 = 0:���` �Œ�
                                    //            dummyIOWriteMASIRDelete.UpdateDateTime = DateTime.MinValue;        // �X�V���t = �ŏ��l �Œ�

                                    //            paracuslist.Add(dummyIOWriteMASIRDelete);
                                    //            paracuslist.Add(listItem as ArrayList);
                                    //        }
                                    //    }

                                    //    if (paracuslist.Count > 0)
                                    //    {
                                    //        status = this.purchaseIOWriteDB.Delete(ref paracuslist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                    //    }
                                    //}
                                    # endregion
                                    //--- ADD 2008/12/02 --->>>
                                    else
                                    {
                                        // �d���`�[�폜�敪���ݒ肳��Ă���ꍇ�A����f�[�^�̍폜�Ɠ����Ɏd���f�[�^�̍폜���s��
                                        // �A���폜�Ώۂ������f�[�^(UOE)�̏ꍇ�͎d���`�[�폜�敪�̒l�Ɋւ�炸�폜����B

                                        bool uoeOrder = false;

                                        SlipListUtils.Find((listItem as ArrayList), typeof(IOWriteMASIRDeleteWork), SlipListUtils.FindType.Class, out findObjPos);

                                        if (findObjPos >= 0)
                                        {
                                            // ���ׁE�d���f�[�^�̍폜�p�����[�^��ݒ�
                                            paracuslist.AddRange(listItem as ArrayList);
                                        }
                                        else
                                        {
                                            SlipListUtils.Find((listItem as ArrayList), typeof(StockDetailWork), SlipListUtils.FindType.Class, out findObjPos);

                                            if (findObjPos >= 0 && ((listItem as ArrayList)[findObjPos] as StockDetailWork).SupplierFormal == 2)
                                            {
                                                // �������@ = 2:�I�����C���� �ɂ� UOE�����f�[�^ �Ƃ݂Ȃ�
                                                uoeOrder = ((listItem as ArrayList)[findObjPos] as StockDetailWork).WayToOrder == 2;

                                                IOWriteMASIRDeleteWork dummyIOWriteMASIRDelete = new IOWriteMASIRDeleteWork();

                                                // �_�~�[�d���f�[�^�ɕK�v�ȍ��ڂ�ݒ肷��
                                                dummyIOWriteMASIRDelete.EnterpriseCode = ((listItem as ArrayList)[findObjPos] as StockDetailWork).EnterpriseCode;  // ��ƃR�[�h
                                                dummyIOWriteMASIRDelete.SupplierFormal = 2;                        // �d���`�� = 2:���� �Œ�
                                                dummyIOWriteMASIRDelete.SupplierSlipNo = 0;                        // �d���`�[�ԍ� = 0  �Œ�
                                                dummyIOWriteMASIRDelete.DebitNoteDiv = 0;                          // �ԓ`�敪 = 0:���` �Œ�
                                                dummyIOWriteMASIRDelete.UpdateDateTime = DateTime.MinValue;        // �X�V���t = �ŏ��l �Œ�

                                                paracuslist.Add(dummyIOWriteMASIRDelete);
                                                paracuslist.Add(listItem as ArrayList);
                                            }
                                        }

                                        // �폜�p�����[�^�����݂��Ă��āA����UOE�����f�[�^����
                                        if (paracuslist.Count > 0 && (uoeOrder || this.CtrlOptWork.SupplierSlipDelDiv != 0))
                                        {
                                            status = this.purchaseIOWriteDB.Delete(ref paracuslist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                        }
                                        // -------------- ADD �A��966 2011/08/16 ----------------->>>>>
                                        if (paracuslist.Count > 0 && (!uoeOrder && this.CtrlOptWork.SupplierSlipDelDiv == 0))
                                        {
                                            status = this.purchaseIOWriteDB.UpdateStockDetailSync(ref paracuslist, ref connection, ref transaction);
                                        }
                                        // -------------- ADD �A��966 2011/08/16 -----------------<<<<<
                                    }
                                    //--- ADD 2008/12/02 ---<<<

                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        break;
                                    }
                                }
                            }

                            break;
                        }
                    case (int)IOWriteCtrlOptCtrlStartingPoint.Purchase:
                        {
                            paracuslist.AddRange(paraList);
                            status = this.purchaseIOWriteDB.Delete(ref paracuslist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                            break;
                        }
                    default:
                        {
                            retMsg = "����E�d������I�v�V�����̐���N�_�Ɍ�肪����܂��B";
                            break;
                        }
                }

                // �o�^���������Ɏ��s�����ꍇ�͏����𒆒f����
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retMsg += (!string.IsNullOrEmpty(retMsg) ? "\n" : "") + "IOWriteControlDB.DeleteProc: �`�[�f�[�^�̍폜�����Ɏ��s���܂����B";
                }
                # endregion
            }
            finally
            {
                //���r�����b�N����������
                #if DEBUG // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc

                if (lockMode == 0)
                {
                    this.Release(this.ResourceName, connection, transaction);
                }


                if (info.Keys.Count != 0)
                {
                    this.ShareCheck(info, LockControl.Release, connection, transaction);
                }
                #endif
            }

            return status;
        }

        # endregion

        # region [�ԓ`����]

        /// <summary>
        /// �ԓ`�쐬(�ԓ`�쐬�f�[�^��S�ăp�����[�^�ŖႤ)
        /// </summary>
        /// <param name="orgList">����List</param>
        /// <param name="redList">�ԓ`List</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <returns>STATUS</returns>
        public int RedWrite(ref object orgList, ref object redList, out string retMsg, out string retItemInfo)
        {
            // �߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlEncryptInfo encryptinfo = null;

            try
            {
                ArrayList orgArraylist = orgList as ArrayList;
                ArrayList redArraylist = redList as ArrayList;

                status = this.RedWriteProc(ref orgArraylist, ref redArraylist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                if (transaction != null && transaction.Connection != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);

                retMsg += (string.IsNullOrEmpty(retMsg) ? "" : "\n") + ex.Message;

                if (transaction != null && transaction.Connection != null)
                {
                    transaction.Rollback();
                }
            }
            finally
            {
                // �g�����U�N�V�����̔j��
                if (transaction != null)
                {
                    transaction.Dispose();
                }

                // �Í����L�[�̃N���[�Y (�ۗ�)
                //if (encryptinfo != null && encryptinfo.IsOpen)
                //{
                //    encryptinfo.CloseSymKey(ref connection);
                //}

                // �R�l�N�V�����̔j��
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgList"></param>
        /// <param name="redList"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="encryptinfo"></param>
        /// <returns></returns>
        public int RedWriteProc(ref ArrayList orgList, ref ArrayList redList, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            # region [�p�����[�^�`�F�b�N]

            //������E�d������I�v�V�����`�F�b�N
            this.CtrlOptWork = SlipListUtils.Find(redList, typeof(IOWriteCtrlOptWork), SlipListUtils.FindType.Class) as IOWriteCtrlOptWork;

            if (this.CtrlOptWork == null)
            {
                retMsg = "����E�d������I�v�V������������܂���B";
                return status;
            }

            // --- ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
            string enterpriseCode = this.CtrlOptWork.EnterpriseCode;

            // ��ƃR�[�h���󗓂̏ꍇ
            if (string.IsNullOrEmpty(enterpriseCode))
            {
                try
                {
                    ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                    enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                    // �T�[�o�[�����ʕ��i�ŋ󗓂̊�ƃR�[�h���擾�����ꍇ
                    if (string.IsNullOrEmpty(enterpriseCode))
                    {
                        base.WriteErrorLog("IOWriteControlDB.RedWriteProc:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                    }
                }
                catch
                {
                    base.WriteErrorLog("IOWriteControlDB.RedWriteProc:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                }
            }
            // ���b�N���\�[�X��
            string resNm = this.GetResourceName(enterpriseCode);
            // --- ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<

            CustomSerializeArrayList orgcslist = new CustomSerializeArrayList();
            orgcslist.AddRange(orgList);

            //�������`�[��񃊃X�g�`�F�b�N
            if (SlipListUtils.IsEmpty(orgcslist))
            {
                retMsg = "�����`�[��񃊃X�g�����o�^�ł��B";
                return status;
            }

            CustomSerializeArrayList redcslist = new CustomSerializeArrayList();

            switch (this.CtrlOptWork.CtrlStartingPoint)
            {
                case (int)IOWriteCtrlOptCtrlStartingPoint.Sales:
                    {
                        redcslist = SlipListUtils.Find(redList, typeof(SalesSlipWork), SlipListUtils.FindType.Array) as CustomSerializeArrayList;
                        break;
                    }
                case (int)IOWriteCtrlOptCtrlStartingPoint.Purchase:
                    {
                        redcslist = SlipListUtils.Find(redList, typeof(StockSlipWork), SlipListUtils.FindType.Array) as CustomSerializeArrayList;
                        break;
                    }
                default:
                    {
                        retMsg = "����E�d������I�v�V�����̐���N�_�Ɍ�肪����܂��B";
                        return status;
                    }
            }

            //���ԓ`�[��񃊃X�g�`�F�b�N
            if (SlipListUtils.IsEmpty(redcslist))
            {
                retMsg = "�ԓ`�[��񃊃X�g�����o�^�ł��B";
                return status;
            }

            //���R�l�N�V�����`�F�b�N
            if (connection == null)
            {
                connection = this.CreateSqlConnection(true);
            }

            if (connection == null)
            {
                retMsg = "�f�[�^�x�[�X�֐ڑ��o���܂���B";
                base.WriteErrorLog(string.Format("IOWriteControlDB.RedWriteProc_connection:{0}", retMsg), status);  // ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                return status;
            }

            //���Í����L�[�`�F�b�N  (�ۗ�)
            //if (encryptinfo == null)
            //{
            //    List<string> ConcatArray = new List<string>();

            //    // �Í����Ώۂ̔���f�[�^�n�e�[�u�����X�g���擾
            //    ConcatArray.AddRange(IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));

            //    // �Í����Ώۂ̎d���f�[�^�n�e�[�u�����X�g���擾
            //    ConcatArray.AddRange(IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));

            //    // �e�[�u�����X�g�̌���
            //    string[] tablenames = ConcatArray.ToArray();

            //    encryptinfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, tablenames);
            //}

            //if (encryptinfo == null)
            //{
            //    retMsg = "�Í����L�[���쐬�o���܂���B";
            //    return status;
            //}

            //encryptinfo.OpenSymKey(ref connection);

            //if (!encryptinfo.IsOpen)
            //{
            //    retMsg = "�Í����L�[���I�[�v���o���܂���B";
            //    return status;
            //}

            //���g�����U�N�V�����`�F�b�N
            if (transaction == null)
            {
                transaction = this.CreateTransaction(ref connection);
            }

            if (transaction == null)
            {
                retMsg = "�g�����U�N�V�������J�n�ł��܂���B";
                base.WriteErrorLog(string.Format("IOWriteControlDB.RedWriteProc_transaction:{0}", retMsg), status);  // ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                return status;
            }

            # endregion

            //���r�����b�N���J�n����
            #if !DEBUG // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
            ShareCheckInfo info = null;
            // --- UPD m.suzuki 2010/08/17 ---------->>>>>
            //this.ShareCheckInitialize(redList, ref info);
            this.ShareCheckInitialize(redList, ref info, ref connection, ref transaction);
            // --- UPD m.suzuki 2010/08/17 ----------<<<<<
            // --- ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
            try
            {
            // --- ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                status = this.ShareCheck(info, LockControl.Locke, connection, transaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            // --- UPD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteControlDB.RedWriteProc_ShareCheckLocke:" + ex.ToString());
                throw ex;
            }

            //status = this.Lock(this.ResourceName, connection, transaction);
            // �O���[�o���ϐ��̑���Ƀ��[�J���̃��\�[�X�����g�p����
            status = this.Lock(resNm, connection, transaction);
            // --- UPD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    retMsg = "���b�N�^�C���A�E�g���������܂����B";
                }
                else
                {
                    retMsg = "�r�����b�N�Ɏ��s���܂����B";
                }
                base.WriteErrorLog(string.Format("IOWriteControlDB.RedWriteProc_Lock:{0}", retMsg), status);  // ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�

                return status;
            }
# endif

            try
            {
                # region [�ԓ`�o�^����]
                //���X�V��񃊃X�g���Ɋi�[����Ă���`�[�f�[�^�̓`�[��ނ����ɔ���E�d���̐ԓ`�[�o�^�������Ăяo��
                switch (this.CtrlOptWork.CtrlStartingPoint)
                {
                    case (int)IOWriteCtrlOptCtrlStartingPoint.Sales:
                        {
                            status = this.salesIOWriteDB.RedWrite(ref orgcslist, ref redcslist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                            break;
                        }
                    case (int)IOWriteCtrlOptCtrlStartingPoint.Purchase:
                        {
                            status = this.purchaseIOWriteDB.RedWrite(ref orgcslist, ref redcslist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                            break;
                        }
                }

                // �o�^���������Ɏ��s�����ꍇ�͏����𒆒f����
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retMsg += (!string.IsNullOrEmpty(retMsg) ? "\n" : "") + "IOWriteControlDB.RedWriteProc: �ԓ`�[�f�[�^�̓o�^�����Ɏ��s���܂����B";
                }
                # endregion
            }
            finally
            {
                //���r�����b�N����������
                #if !DEBUG // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
                // --- UPD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                //���r�����b�N����������
                //this.Release(this.ResourceName, connection, transaction);
                //this.ShareCheck(info, LockControl.Release, connection, transaction);
                int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                if (connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.RedWriteProc_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                }
                else if (transaction == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.RedWriteProc_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                }
                else if (transaction.Connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.RedWriteProc_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                }
                else
                {
                    // �A�v���P�[�V�������b�N����
                    releaseStatus = this.Release(resNm, connection, transaction);
                    if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        base.WriteErrorLog("IOWriteControlDB.RedWriteProc_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                    }
                }
                // �V�F�A�`�F�b�N
                if (connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.RedWriteProc_ShareCheckRelease: �V�F�A�`�F�b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                }
                else if (transaction == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.RedWriteProc_ShareCheckRelease: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                }
                else if (transaction.Connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.RedWriteProc_ShareCheckRelease: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                }
                else
                {
                    // �V�F�A�`�F�b�N����
                    releaseStatus = this.ShareCheck(info, LockControl.Release, connection, transaction);
                    if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        base.WriteErrorLog("IOWriteControlDB.RedWriteProc_ShareCheckRelease: �V�F�A�`�F�b�N���������Ɏ��s���܂����B", releaseStatus);
                    }
                }
                // --- UPD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                # endif
            }

            return status;
        }
        
        # endregion

        # region [�`�[�p�����[�^���X�g���쏈��]
        /// <summary>
        /// List ���[�e�B���e�B�N���X
        /// </summary>
        private class SlipListUtils : ListUtils
        {
            /*
            /// <summary>�����p�^�[�� Find() �Ŏg�p</summary>
            public enum FindType
            {
                /// <summary>�N���X</summary>
                Class,
                /// <summary>Array</summary>
                Array
            }
            */
            /// <summary>�����Ώۍ��� FindSlipDetail() �Ŏg�p</summary>
            public enum FindItem
            {
                /// <summary>�ʏ�</summary>
                Normal,
                /// <summary>�v�㌳</summary>
                Source,
                /// <summary>�����v��</summary>
                Synchronize,
                /// <summary>UOE����</summary>
                UoeOrder
                # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
#if false
            /// <summary>����ꎞ</summary>
            SalesTemp
#endif
                # endregion
            }

            /// <summary>
            /// �p�����[�^�Ɏw�肳�ꂽ�N���X�ɉ������`�[�^�C�v���擾���܂��B
            /// </summary>
            /// <returns>SlipType</returns>
            public static SlipType GetSlipType(object obj)
            {
                SlipType result = SlipType.None;

                if (obj is ArrayList)
                {
                    ArrayList slips = obj as ArrayList;

                    if (SlipListUtils.IsNotEmpty(slips))
                    {
                        object findObj = null;

                        // ���㖾�׃f�[�^����������
                        findObj = SlipListUtils.Find(slips, typeof(SalesDetailWork), FindType.Array);

                        if (findObj == null)
                        {
                            // �d�����׃f�[�^����������(���ׂŌ�������͔̂����f�[�^���܂܂�邽��)
                            findObj = SlipListUtils.Find(slips, typeof(StockDetailWork), FindType.Array);
                        }

                        if (findObj == null)
                        {
                            // UOE�������׃f�[�^����������
                            findObj = SlipListUtils.Find(slips, typeof(UOEOrderDtlWork), FindType.Array);
                        }

                        if (findObj == null)
                        {
                            // �d���폜�p�����[�^
                            findObj = SlipListUtils.Find(slips, typeof(IOWriteMASIRDeleteWork), FindType.Class);
                        }

                        if (findObj == null)
                        {
                            // ����폜�p�����[�^
                            findObj = SlipListUtils.Find(slips, typeof(IOWriteMAHNBDeleteWork), FindType.Class);
                        }

                        if (findObj == null)
                        {
                            // �݌ɒ����f�[�^
                            // 2009/02/26 ���|�����I�v�V�����Ή�>>>>>>>>>>>>>>>
                            //// 2009/02/10 >>>>>>>>
                            ////findObj = SlipListUtils.Find(slips, typeof(StockAdjustWork), FindType.Array); //DEL
                            ////�݌ɒ������׃f�[�^�N���X�̃��X�g���擾����悤�ɏC��
                            //findObj = SlipListUtils.Find(slips, typeof(StockAdjustDtlWork), FindType.Array); //ADD
                            //// 2009/02/10 <<<<<<<<

                            ArrayList adjustcs = slips[0] as ArrayList;
                            findObj = SlipListUtils.Find(adjustcs, typeof(StockAdjustDtlWork), FindType.Array); //ADD

                            // 2009/02/26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }

                        # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
#if false
                if (findObj == null)
                {
                    // ����ꎞ�f�[�^����������
                    findObj = SlipListUtils.Find(slips, typeof(SalesTempWork), SlipListUtils.FindType.Class);
                }
#endif
                        # endregion

                        if (SlipListUtils.IsNotEmpty(findObj as ArrayList))
                        {
                            findObj = (findObj as ArrayList)[0];
                        }

                        if (findObj is SalesDetailWork)
                        {
                            switch ((findObj as SalesDetailWork).AcptAnOdrStatus)
                            {
                                case (int)SlipType.Estimation:     // ����
                                    result = SlipType.Estimation;
                                    break;
                                case (int)SlipType.AcceptAnOrder:  // ��
                                    result = SlipType.AcceptAnOrder;
                                    break;
                                case (int)SlipType.Shipment:       // �o��
                                    result = SlipType.Shipment;
                                    break;
                                case (int)SlipType.Sales:          // ����
                                    result = SlipType.Sales;
                                    break;
                            }
                        }
                        else if (findObj is StockDetailWork)
                        {
                            switch ((findObj as StockDetailWork).SupplierFormal)
                            {
                                case (int)SlipType.Order:     // ����
                                    result = SlipType.Order;
                                    break;
                                case (int)SlipType.Arrival:   // ����
                                    result = SlipType.Arrival;
                                    break;
                                case (int)SlipType.Purchase:  // �d��
                                    result = SlipType.Purchase;
                                    break;
                            }
                        }
                        else if (findObj is UOEOrderDtlWork)
                        {
                            result = SlipType.UoeOrder;  // UOE����
                        }
                        else if (findObj is StockAdjustDtlWork)
                        {
                            result = SlipType.StockAdjust;  // �݌ɒ���
                        }
                        # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
                        //else if (findObj is SalesTempWork)
                        //{
                        //    result = SlipType.SalesTemp;
                        //}
                        # endregion
                    }
                }
                else if (obj is IOWriteMAHNBDeleteWork)
                {
                    result = SlipType.SalesDel;  // ����폜
                }
                else if (obj is IOWriteMASIRDeleteWork)
                {
                    result = SlipType.PurchaseDel;  // �d���폜
                }

                return result;
            }


            /// <summary>
            /// �`�[�^�C�v��GUID�����v���閾�׃f�[�^���擾���܂��B
            /// </summary>
            /// <param name="sliplist">�����Ώۃ��X�g</param>
            /// <param name="finditem">�����Ώۍ���</param>
            /// <param name="sliptype">�`�[�^�C�v</param>
            /// <param name="guid">����GUID</param>
            /// <param name="source">���������׃f�[�^</param>
            /// <returns>�I�u�W�F�N�g</returns>
            public static object FindSlipDetail(ArrayList sliplist, FindItem finditem, SlipType sliptype, Guid guid, object source)
            {
                object retdtil = null;

                foreach (object item in sliplist)
                {
                    if (item is ArrayList)
                    {
                        // �ċA�������s��
                        retdtil = SlipListUtils.FindSlipDetail(item as ArrayList, finditem, sliptype, guid, source);
                    }
                    else
                    {
                        // �������̖��׃f�[�^�ƈقȂ�ꍇ�ɂ̂݃`�F�b�N����
                        if (item != source)
                        {
                            switch (finditem)
                            {
                                case FindItem.Normal:
                                    {
                                        # region [�󒍃X�e�[�^�X or �d���`���������ΏۂƂ���]
                                        switch (sliptype)
                                        {
                                            case SlipType.Estimation:     // ����
                                            case SlipType.AcceptAnOrder:  // ��
                                            case SlipType.Shipment:       // �o��
                                            case SlipType.Sales:          // ����
                                                {
                                                    if (item is SalesDetailWork)
                                                    {
                                                        // �󒍃X�e�[�^�X��GUID���`�F�b�N����
                                                        if ((item as SalesDetailWork).AcptAnOdrStatus == (int)sliptype &&
                                                            (item as SalesDetailWork).DtlRelationGuid == guid)
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                            case SlipType.Order:          // ����
                                            case SlipType.Arrival:        // ����
                                            case SlipType.Purchase:       // �d��
                                                {
                                                    if (item is StockDetailWork)
                                                    {
                                                        // �d���`����GUID���`�F�b�N����
                                                        if ((item as StockDetailWork).SupplierFormal == (int)sliptype &&
                                                            (item as StockDetailWork).DtlRelationGuid == guid)
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                        }
                                        # endregion
                                        break;
                                    }
                                case FindItem.Source:
                                    {
                                        # region [�󒍃X�e�[�^�X(�v�㌳) or �d���`��(�v�㌳)�������ΏۂƂ���]
                                        switch (sliptype)
                                        {
                                            case SlipType.Estimation:     // ����
                                            case SlipType.AcceptAnOrder:  // ��
                                            case SlipType.Shipment:       // �o��
                                            case SlipType.Sales:          // ����
                                                {
                                                    if (item is SalesDetailWork)
                                                    {
                                                        // �󒍃X�e�[�^�X(�v�㌳)��GUID���`�F�b�N����
                                                        if ((item as SalesDetailWork).AcptAnOdrStatusSrc == (int)sliptype &&
                                                            (item as SalesDetailWork).DtlRelationGuid == guid)
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                            case SlipType.Order:          // ����
                                            case SlipType.Arrival:        // ����
                                            case SlipType.Purchase:       // �d��
                                                {
                                                    if (item is StockDetailWork)
                                                    {
                                                        // �d���`��(�v�㌳)��GUID���`�F�b�N����
                                                        if ((item as StockDetailWork).SupplierFormalSrc == (int)sliptype &&
                                                            (item as StockDetailWork).DtlRelationGuid == guid)
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                        }
                                        # endregion
                                        break;
                                    }
                                case FindItem.Synchronize:
                                    {
                                        # region [�󒍃X�e�[�^�X(����) or �d���`��(����)�������ΏۂƂ���]
                                        switch (sliptype)
                                        {
                                            case SlipType.Estimation:     // ����
                                            case SlipType.AcceptAnOrder:  // ��
                                            case SlipType.Shipment:       // �o��
                                            case SlipType.Sales:          // ����
                                                {
                                                    if (item is StockDetailWork)
                                                    {
                                                        // �󒍃X�e�[�^�X(����)��GUID���`�F�b�N����
                                                        if ((item as StockDetailWork).AcptAnOdrStatusSync == (int)sliptype &&
                                                            (item as StockDetailWork).DtlRelationGuid == guid)
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                            case SlipType.Order:          // ����
                                            case SlipType.Arrival:        // ����
                                            case SlipType.Purchase:       // �d��
                                                {
                                                    if (item is SalesDetailWork)
                                                    {
                                                        // �d���`��(����)��GUID���`�F�b�N����
                                                        if ((item as SalesDetailWork).SupplierFormalSync == (int)sliptype &&
                                                            (item as SalesDetailWork).DtlRelationGuid == guid)
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                        }
                                        # endregion
                                        break;
                                    }
                                case FindItem.UoeOrder:
                                    {
                                        #region [�󒍃X�e�[�^�X or �d���`���������ΏۂƂ���]
                                        switch (sliptype)
                                        {
                                            case SlipType.Estimation:     // ����
                                            case SlipType.AcceptAnOrder:  // ��
                                            case SlipType.Shipment:       // �o��
                                            case SlipType.Sales:          // ����
                                                {
                                                    if (item is UOEOrderDtlWork)
                                                    {
                                                        // �󒍃X�e�[�^�X��GUID���`�F�b�N����
                                                        if ((item as UOEOrderDtlWork).AcptAnOdrStatus == (int)sliptype &&
                                                            (item as UOEOrderDtlWork).DtlRelationGuid == guid)
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                            case SlipType.Order:          // ����
                                            case SlipType.Arrival:        // ����
                                            case SlipType.Purchase:       // �d��
                                                {
                                                    if (item is UOEOrderDtlWork)
                                                    {
                                                        // �d���`����GUID���`�F�b�N����
                                                        if ((item as UOEOrderDtlWork).SupplierFormal == (int)sliptype &&
                                                            (item as UOEOrderDtlWork).DtlRelationGuid == guid)
                                                        {
                                                            retdtil = item;
                                                        }
                                                    }

                                                    break;
                                                }
                                        }
                                        # endregion
                                        break;
                                    }
                                # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
                                //case FindItem.SalesTemp:
                                //    {
                                //    # region [����ꎞ�f�[�^�������ΏۂƂ���]
                                //        switch (sliptype)
                                //        {
                                //            case SlipType.Order:          // ����
                                //            case SlipType.Arrival:        // ����
                                //            case SlipType.Purchase:       // �d��
                                //                {
                                //                    if (item is SalesTempWork)
                                //                    {
                                //                        // GUID���`�F�b�N����
                                //                        if ((item as SalesTempWork).DtlRelationGuid == guid)
                                //                        {
                                //                            retdtil = item;
                                //                        }
                                //                    }
                                //                    break;
                                //                }
                                //        }
                                //        # endregion
                                //        break;
                                //    }
                                # endregion
                            }
                        }
                    }

                    // �ŏ��Ɍ������f�[�^��Ԃ�
                    if (retdtil != null)
                    {
                        break;
                    }
                }

                return retdtil;
            }
        }

        /// <summary>
        /// �`�[�^�C�v
        /// </summary>
        internal enum SlipType : int
        {
            /// <summary>���w��</summary>
            None = -1,
            /// <summary>����</summary>
            Estimation = 10,
            /// <summary>��</summary>
            AcceptAnOrder = 20,
            /// <summary>�o��</summary>
            Shipment = 40,
            /// <summary>����</summary>
            Sales = 30,
            /// <summary>����</summary>
            Order = 2,
            /// <summary>����</summary>
            Arrival = 1,
            /// <summary>�d��</summary>
            Purchase = 0,
            /// <summary>UOE����</summary>
            UoeOrder = 98,
            /// <summary>����폜</summary>
            SalesDel = 100,
            /// <summary>�d���폜</summary>
            PurchaseDel = 101,
            /// <summary>�݌ɒ���</summary>
            StockAdjust = 102
            #region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
            ///// <summary>����ꎞ(�d�����㓯���v��)</summary>            
            //SalesTemp = 99
            #endregion
        }

        /// <summary>
        /// �`�[�`���Ń\�[�g���s��
        /// </summary>
        internal class SlipTypeComparer : IComparer
        {
            /// <summary>
            /// �`�[���փ^�C�v
            /// </summary>
            public enum SlipSortType
            {
                /// <summary>����</summary>
                Sales,
                /// <summary>�d��</summary>
                Purchase
            }

            public SlipSortType SortType = SlipSortType.Sales;

            /// <summary>
            /// �d������ɓ`�[�`���Ń\�[�g���s��
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(object x, object y)
            {
                # region [DELETE]
                // SortType �� SlipSortType.Sales(����) �̏ꍇ��
                // 0:����I�v�V������1:���ρ�2:�󒍁�3:�o�ׁ�4:���ぃ5:����(�{6:UOE����)��7:���ׁ�8:�d����9:����ꎞ �̏��ɕ��ѕς���
                
                // SortType �� SlipSortType.Purchase(�d��) �̏ꍇ��
                // 0:����I�v�V������5:����(�{6:UOE����)��7:���ׁ�8:�d����9:����ꎞ��11:���ρ�12:�󒍁�13:�o�ׁ�14:���� �̏��ɕ��ѕς���
                # endregion

                // SortType �� SlipSortType.Sales(����) �̏ꍇ��
                // 0:����I�v�V������1:�d���폜��2:���ρ�3:�󒍁�4:�o�ׁ�5:���ぃ6:����폜��7:����(�{8:UOE����)��9:���ׁ�10:�d����11:�݌ɒ�����12:����ꎞ �̏��ɕ��ѕς���

                // SortType �� SlipSortType.Purchase(�d��) �̏ꍇ��
                // 0:����I�v�V������6:����폜��7:����(�{8:UOE����)��9:���ׁ�10:�d����11:�݌ɒ�����12:����ꎞ��21:�d���폜��22:���ρ�23:�󒍁�24:�o�ׁ�25:���� �̏��ɕ��ѕς���

                int xValue = 0;
                int yValue = 0;
                int zValue = int.MaxValue;

                int xSlipDtlRegOrder = 0;
                int ySlipDtlRegOrder = 0;
                int zSlipDtlRegOrder = 0;

                const int orderWeight = 20;  // ����̎d���ŕς����я��̏d�݂��w��

                object Z = null;

                for (int i = 0; i < 2; i++)
                {
                    Z = (i == 0) ? x : y;

                    if (Z is IOWriteCtrlOptWork)
                    {
                        // ����I�v�V�����͏�ɐ擪�Ƃ���
                        zValue = 0;
                    }
                    else if (Z is IOWriteMASIRDeleteWork)
                    {
                        # region [�d���폜�p�����[�^]

                        // �d���폜�p�����[�^
                        zValue = 1;

                        // ���փ^�C�v�ɉ����ďd�݂�݂���
                        zValue += (this.SortType == SlipSortType.Sales) ? 0 : orderWeight;

                        // �d���폜�p�����[�^�������o�^����Ă���ꍇ�́A�d���`���̋t��(��:�d�������ׁ�����:��)�̏��ɕ��ׂ�
                        zSlipDtlRegOrder = 2 - (Z as IOWriteMASIRDeleteWork).SupplierFormal;

                        # endregion
                    }
                    else if (Z is IOWriteMAHNBDeleteWork)
                    {
                        # region [����폜�p�����[�^]

                        // ����폜�p�����[�^
                        zValue = 6;

                        // ����폜�p�����[�^�������o�^����Ă���ꍇ�́A�󒍃X�e�[�^�X�̋t��(��:�o�ׁ����と�󒍁�����:��)���ɕ��ׂ�
                        zSlipDtlRegOrder = 40 - (Z as IOWriteMAHNBDeleteWork).AcptAnOdrStatus;

                        # endregion
                    }
                    else if (Z is ArrayList)
                    {
                        object findObj = null;
                        ArrayList zList = Z as ArrayList;

                        # region [�����Ώۂ̒��o]
                        // ���㖾�׃f�[�^����������
                        findObj = SlipListUtils.Find(zList, typeof(SalesDetailWork), SlipListUtils.FindType.Array);

                        if (findObj == null)
                        {
                            // �d�����׃f�[�^����������(���ׂŌ�������͔̂����f�[�^���܂܂�邽��)
                            findObj = SlipListUtils.Find(zList, typeof(StockDetailWork), SlipListUtils.FindType.Array);
                        }

                        # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
                        //if (findObj == null)
                        //{
                        //    // ����ꎞ�f�[�^����������
                        //    findObj = SlipListUtils.Find(zList, typeof(SalesTempWork), SlipListUtils.FindType.Class);
                        //}
                        # endregion

                        if (findObj == null)
                        {
                            // UOE�������׃f�[�^����������
                            findObj = SlipListUtils.Find(zList, typeof(UOEOrderDtlWork), SlipListUtils.FindType.Array);
                        }

                        if (findObj == null)
                        {
                            // 2009/02/26 ���|�����I�v�V�����Ή� >>>>>>>>>>>>>>>
                            // �݌ɒ���
                            //findObj = SlipListUtils.Find(zList, typeof(StockAdjustWork), SlipListUtils.FindType.Array);

                            ArrayList adjustList = zList[0] as ArrayList;
                            findObj = SlipListUtils.Find(adjustList, typeof(StockAdjustWork), SlipListUtils.FindType.Array);
                            // 2009/02/26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }

                        if (findObj is ArrayList && SlipListUtils.IsNotEmpty(findObj as ArrayList))
                        {
                            Z = (findObj as ArrayList)[0];
                        }

                        # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
                        //else if (findObj is SalesTempWork)
                        //{
                        //    Z = findObj;
                        //}
                        # endregion
                        # endregion

                        # region [�����ΏۂɊ�Â����d�݂̐ݒ�]

                        if (Z is SalesDetailWork)
                        {
                            # region [���㖾�׃f�[�^]

                            switch ((Z as SalesDetailWork).AcptAnOdrStatus)
                            {
                                case (int)SlipType.Estimation:     // ����
                                    zValue = 2;
                                    break;
                                case (int)SlipType.AcceptAnOrder:  // ��
                                    zValue = 3;
                                    break;
                                case (int)SlipType.Shipment:       // �o��
                                    zValue = 4;
                                    break;
                                case (int)SlipType.Sales:          // ����
                                    zValue = 5;
                                    break;
                            }

                            // ���փ^�C�v�ɉ����ďd�݂�݂���
                            zValue += (this.SortType == SlipSortType.Sales) ? 0 : orderWeight;

                            // ����󒍃X�e�[�^�X�̓`�[���r����ۂɁA�`�[���דo�^���ʂ��r���ڂƂ���
                            ArrayList SlpDtlAddInfList = ListUtils.Find(zList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

                            if (ListUtils.IsNotEmpty(SlpDtlAddInfList))
                            {
                                SlpDtlAddInfList.Sort(new SlipDetailAddInfoRegOrderComparer());
                                zSlipDtlRegOrder = (SlpDtlAddInfList[0] as SlipDetailAddInfoWork).SlipDtlRegOrder;
                            }

                            # endregion
                        }
                        else if (Z is StockDetailWork)
                        {
                            # region [�d�����׃f�[�^]

                            switch ((Z as StockDetailWork).SupplierFormal)
                            {
                                case (int)SlipType.Order:     // ����
                                    zValue = 7;
                                    break;
                                case (int)SlipType.Arrival:   // ����
                                    zValue = 9;
                                    break;
                                case (int)SlipType.Purchase:  // �d��
                                    zValue = 10;
                                    break;
                            }

                            // ���փ^�C�v�ɉ����ďd�݂�݂���
                            //zValue += (this.SortType == SlipSortType.Purchase) ? 0 : 10;

                            // ����d���`���̓`�[���r����ۂɁA�`�[���דo�^���ʂ��r���ڂƂ���
                            ArrayList SlpDtlAddInfList = ListUtils.Find(zList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

                            if (ListUtils.IsNotEmpty(SlpDtlAddInfList))
                            {
                                SlpDtlAddInfList.Sort(new SlipDetailAddInfoRegOrderComparer());
                                zSlipDtlRegOrder = (SlpDtlAddInfList[0] as SlipDetailAddInfoWork).SlipDtlRegOrder;
                            }

                            # endregion
                        }
                        else if (Z is UOEOrderDtlWork)
                        {
                            # region [UOE�����f�[�^]

                            // UOE����
                            zValue = 8;

                            // ���փ^�C�v�ɉ����ďd�݂�݂���
                            //zValue += (this.SortType == SlipSortType.Purchase) ? 0 : 10;

                            ArrayList SlpDtlAddInfList = ListUtils.Find(zList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

                            if (ListUtils.IsNotEmpty(SlpDtlAddInfList))
                            {
                                SlpDtlAddInfList.Sort(new SlipDetailAddInfoRegOrderComparer());
                                zSlipDtlRegOrder = (SlpDtlAddInfList[0] as SlipDetailAddInfoWork).SlipDtlRegOrder;
                            }
                            else
                            {
                                zSlipDtlRegOrder = 0;
                            }

                            # endregion
                        }
                        else if (Z is StockAdjustWork)
                        {
                            # region [�݌ɒ����f�[�^]
                            zValue = 11;
                            zSlipDtlRegOrder = 0;
                            # endregion
                        }
                        
                        # region [2008/06/05 M.Kubota --- PM.NS�ɂ�����d�����㓯���v��̎d�l������Ȃ̂œ�������]
                        //else if (Z is SalesTempWork)  // ����ꎞ�f�[�^
                        //{
                        //    zValue = 9;

                        //    // ���փ^�C�v�ɉ����ďd�݂�݂���
                        //    zValue += (this.SortType == SlipSortType.Purchase) ? 0 : 10;
                        //}
                        # endregion
                        # endregion

                    }

                    if (i == 0)
                    {
                        xValue = zValue;
                        xSlipDtlRegOrder = zSlipDtlRegOrder;
                    }
                    else
                    {
                        yValue = zValue;
                        ySlipDtlRegOrder = zSlipDtlRegOrder;
                    }
                }

                // �󒍃X�e�[�^�X or �d���`�� �Ŕ�r
                int compret = xValue.CompareTo(yValue);

                if (compret == 0)
                {
                    // �`�[���דo�^���ʂŔ�r
                    compret = xSlipDtlRegOrder.CompareTo(ySlipDtlRegOrder);
                }

                return compret;
            }
        }
        # endregion

        # region [�V�F�A�`�F�b�N����]

        /// <br>Update Note: Redmine#23737�@�d���`�[���͂ŁA������������̂��ߓo�^�ł��܂���̂��C������</br>
        /// <br>Programmer : XUJS</br>
        /// <br>Date       : 2011/08/18</br>
        /// <br>Update Note: ��������W�v�������ɓ`�[���s�s�̏C��</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/10</br>
        /// <br>Update Note: 2012/11/09 wangf </br>
        /// <br>           : 10801804-00�A12��12���z�M���ARedmine#33215 PM.NS��Q�ꗗNo.1582�̑Ή�</br>
        /// <br>           : ����`�[���� ���������̎�����̔r���̑Ή�</br>
        // --- UPD m.suzuki 2010/08/17 ---------->>>>>
        //private void ShareCheckInitialize(ArrayList param, ref ShareCheckInfo info)
        private void ShareCheckInitialize( ArrayList param, ref ShareCheckInfo info, ref SqlConnection connection, ref SqlTransaction transaction )
        // --- UPD m.suzuki 2010/08/17 ----------<<<<<
        {
            if (info == null)
            {
                info = new ShareCheckInfo();
            }

            ShareCheckKey dummyKey = new ShareCheckKey();

            foreach (object item in param)
            {
                if (item is ArrayList)
                {
                    // --- UPD m.suzuki 2010/08/17 ---------->>>>>
                    //this.ShareCheckInitialize((item as ArrayList), ref info);
                    this.ShareCheckInitialize( (item as ArrayList), ref info, ref connection, ref transaction );
                    // --- UPD m.suzuki 2010/08/17 ----------<<<<<
                    continue;
                }

                // ���㖾�׃f�[�^
                if (item is SalesDetailWork)
                {
                    dummyKey.EnterpriseCode = (item as SalesDetailWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as SalesDetailWork).SectionCode;
                    
                    // 2009/03/16 MANTIS 11688 >>>>>>>>>>>>>>>>>>>>
                    //���ς̏ꍇ�́A�q�Ƀ��b�N�����Ȃ��悤�ɏC��
                    //dummyKey.WarehouseCode = (item as SalesDetailWork).WarehouseCode;
                    if ((item as SalesDetailWork).AcptAnOdrStatus != 10)
                    {
                        dummyKey.WarehouseCode = (item as SalesDetailWork).WarehouseCode;
                    }
                    // 2009/03/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                // --- ADD m.suzuki 2010/08/17 ---------->>>>>
                // ����f�[�^
                else if (item is SalesSlipWork)
                {
                    // �������b�N
                    dummyKey.EnterpriseCode = (item as SalesSlipWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as SalesSlipWork).SectionCode;
                    //dummyKey.AddUpUpdDate = ToLongDate( (item as SalesSlipWork).AddUpADate ); // DEL wangf 2012/11/09 FOR Redmine#33215
                    // ------------ADD wangf 2012/11/09 FOR Redmine#33215--------->>>>
                    // �󒍃X�e�[�^�X:10:����,20:��,30:����,40:�o��
                    // �������b�N�`�F�b�N�̔�r�p�̓��t�͈ȉ��̓`�[�敪�ɂ��Ⴂ���t���g���悤�ɂȂ�
                    // ����`�[�@�@�@�@�@�@�@=>�@�v����t
                    // �󒍁A���ρA�P�����ρ@=>�@������t
                    // �ݏo�@�@�@�@�@�@�@�@�@=>�@�o�ד��t
                    if ((item as SalesSlipWork).AcptAnOdrStatus == 30)
                    {
                        dummyKey.AddUpUpdDate = ToLongDate((item as SalesSlipWork).AddUpADate);
                    }
                    else if ((item as SalesSlipWork).AcptAnOdrStatus == 40)
                    {
                        dummyKey.AddUpUpdDate = ToLongDate((item as SalesSlipWork).ShipmentDay);
                    }
                    else
                    {
                        dummyKey.AddUpUpdDate = ToLongDate((item as SalesSlipWork).SalesDate);
                    }
                    // ------------ADD wangf 2012/11/09 FOR Redmine#33215---------<<<<
                    dummyKey.TotalDay = 0;

                    // ���Ӑ�̒���(DD)���擾����
                    CustomerDB customerDB = new CustomerDB();
                    if ( customerDB != null )
                    {
                        int customerTotalDay = 0;
                        customerDB.GetCustomerTotalDay( dummyKey.EnterpriseCode, (item as SalesSlipWork).CustomerCode, ref customerTotalDay, ref connection, ref transaction );
                        dummyKey.TotalDay = customerTotalDay;
                    }

                    // ���s�����ꍇ�̓��b�N�̃L�[��ǉ����Ȃ�
                    if ( dummyKey.TotalDay == 0 )
                    {
                        continue;
                    }
                }
                // --- ADD m.suzuki 2010/08/17 ----------<<<<<
                // --- ADD XUJS 2011/08/18 ---------->>>>>
                // �d���f�[�^
                else if (item is StockSlipWork)
                {
                    // �������b�N
                    dummyKey.EnterpriseCode = (item as StockSlipWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as StockSlipWork).SectionCode;
                    dummyKey.AddUpUpdDate = ToLongDate((item as StockSlipWork).StockAddUpADate);
                    dummyKey.TotalDay = 0;

                    // �d����̒���(DD)���擾����
                    SupplierDB supplierDB = new SupplierDB();
                    SupplierWork supplier = new SupplierWork();
                    supplier.EnterpriseCode = (item as StockSlipWork).EnterpriseCode;
                    supplier.SupplierCd = (item as StockSlipWork).SupplierCd;
                    int ret = supplierDB.Read(ref supplier, 0, ref connection, ref transaction);

                    if (ret == 0)
                    {
                        int supplierTotalDay = 0;
                        supplierTotalDay = supplier.PaymentTotalDay;
                        dummyKey.TotalDay = supplierTotalDay;
                    }

                    // ���s�����ꍇ�̓��b�N�̃L�[��ǉ����Ȃ�
                    if (dummyKey.TotalDay == 0)
                    {
                        continue;
                    }
                }
                // --- ADD XUJS 2011/08/17 ----------<<<<< 
                // �d�����׃f�[�^
                else if (item is StockDetailWork)
                {
                    dummyKey.EnterpriseCode = (item as StockDetailWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as StockDetailWork).SectionCode;
                    dummyKey.WarehouseCode = (item as StockDetailWork).WarehouseCode;
                }
                // UOE�������׃f�[�^
                else if (item is UOEOrderDtlWork)
                {
                    dummyKey.EnterpriseCode = (item as UOEOrderDtlWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as UOEOrderDtlWork).SectionCode;

                    // 2009/03/16 MANTIS 11688 >>>>>>>>>>>>>>>>>>>>
                    //�������ςŔ������ꂽ�ꍇ�ɑq�Ƀ��b�N�������Ȃ��悤�ɂ��邽�߁A
                    //�t�n�d�����f�[�^�ł͑q�Ƀ��b�N�͂����Ȃ��B
                    //�݌ɍX�V����������ꍇ�́A���d�����ד��őq�Ƀ��b�N���K�������邽�߁B

                    //dummyKey.WarehouseCode = (item as UOEOrderDtlWork).WarehouseCode;
                    // 2009/03/16 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                // �݌ɒ������׃f�[�^
                else if (item is StockAdjustDtlWork)
                {
                    dummyKey.EnterpriseCode = (item as StockAdjustDtlWork).EnterpriseCode;
                    dummyKey.SectionCode = (item as StockAdjustDtlWork).SectionCode;
                    dummyKey.WarehouseCode = (item as StockAdjustDtlWork).WarehouseCode;
                }
                else
                {
                    continue;
                }

                if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                      {
                                          return key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                                 // --- ADD m.suzuki 2010/08/17 ---------->>>>>
                                                 key.Type == ShareCheckType.Section &&
                                                 // --- ADD m.suzuki 2010/08/17 ----------<<<<<
                                                 key.SectionCode == dummyKey.SectionCode;
                                      }))
                {
                    info.Keys.Add(dummyKey.EnterpriseCode, ShareCheckType.Section, dummyKey.SectionCode, "");
                }

                // -- ADD 2011/02/21 --------------------->>>
                if (dummyKey.WarehouseCode != "")
                {
                // -- ADD 2011/02/21 ---------------------<<<
                    if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                          {
                                              return key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                                     key.WarehouseCode == dummyKey.WarehouseCode;
                                          }))
                    {
                        info.Keys.Add(dummyKey.EnterpriseCode, ShareCheckType.WareHouse, "", dummyKey.WarehouseCode);
                    }
                }  // ADD 2011/02/21

                // --- ADD m.suzuki 2010/08/17 ---------->>>>>
                // �������b�N�L�[�ǉ�
                if ( dummyKey.TotalDay != 0 )
                {
                    //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��----->>>>>
                    // �d���f�[�^
                    if (item is StockSlipWork)
                    {
                        if (!info.Keys.Exists(delegate(ShareCheckKey key)
                        {
                            return key.Type == ShareCheckType.SupUpSlip &&
                                   key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                   key.SectionCode == dummyKey.SectionCode &&
                                   key.TotalDay == dummyKey.TotalDay &&
                                   key.AddUpUpdDate == dummyKey.AddUpUpdDate;
                        }))
                        {
                            info.Keys.Add(new ShareCheckKey(dummyKey.EnterpriseCode, ShareCheckType.SupUpSlip, dummyKey.SectionCode, "", dummyKey.TotalDay, dummyKey.AddUpUpdDate));
                        }

                    }
                    else
                    {
                    //--- ADD yangmj 2012/05/10  ��������W�v�������ɓ`�[���s�s�̏C��-----<<<<<
                        if (!info.Keys.Exists(delegate(ShareCheckKey key)
                                                  {
                                                      return key.Type == ShareCheckType.AddUpSlip &&
                                                             key.EnterpriseCode == dummyKey.EnterpriseCode &&
                                                             key.SectionCode == dummyKey.SectionCode &&
                                                             key.TotalDay == dummyKey.TotalDay &&
                                                             key.AddUpUpdDate == dummyKey.AddUpUpdDate;
                                                  }))
                        {
                            info.Keys.Add(new ShareCheckKey(dummyKey.EnterpriseCode, ShareCheckType.AddUpSlip, dummyKey.SectionCode, "", dummyKey.TotalDay, dummyKey.AddUpUpdDate));
                        }
                    } //ADD yangmj 2012/05/10 ��������W�v�������ɓ`�[���s�s�̏C��
                    
                }
                // --- ADD m.suzuki 2010/08/17 ----------<<<<<
            }
            
        }
        // --- ADD m.suzuki 2010/08/17 ---------->>>>>
        /// <summary>
        /// ���t�ϊ�����
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int ToLongDate( DateTime dateTime )
        {
            try
            {
                return (dateTime.Year * 10000 + dateTime.Month * 100 + dateTime.Day);
            }
            catch
            {
                return 0;
            }
        }
        // --- ADD m.suzuki 2010/08/17 ----------<<<<<

        # endregion

        # region [�V�F�A�`�F�b�N�p�e�X�g���\�b�h]
# if DEBUG
        public int ShLock(ref object param, int timeout, int retry, int interval)
        {
            SqlConnection connection = this.CreateConnection(true);
            SqlTransaction transaction = this.CreateTransaction(ref connection);

            ShareCheckInfo info = new ShareCheckInfo();

            info.Keys.Clear();
            info.Keys.AddRange((ShareCheckKey[])(param as ArrayList).ToArray(typeof(ShareCheckKey)));
            info.RetryCount = retry;
            info.TimeOut = timeout;

            int status = this.ShareCheck(info, LockControl.Locke, connection, transaction);

            ShareCheckKey key = null;

            info.Keys.GetIntegratedResult(out key);

            Console.WriteLine(string.Format("Lock ST={0} & {1} {2} {3} {4}", status, key.EnterpriseCode, key.Type, key.SectionCode, key.WarehouseCode));

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                System.Threading.Thread.Sleep(interval);

                status = this.ShareCheck(info, LockControl.Release, connection, transaction);

                info.Keys.GetIntegratedResult(out key);
                Console.WriteLine(string.Format("Release ST={0} & {1} {2} {3} {4}", status, key.EnterpriseCode, key.Type, key.SectionCode, key.WarehouseCode));
            }

            return status;
        }
# endif
        # endregion

        // ----- ADD K2011/08/12 --------------------------->>>>>
        #region IIOWriteControlDB �����o

        /// <summary>
        /// �T�[�o�[�V�X�e�����t�擾��߂��܂�		
        /// </summary>
        /// <returns>DateTime.now</returns>
        /// <br>Note        : �T�[�o�[�V�X�e�����t�擾��߂��܂�	</br>
        /// <br>Programmer  : ���N�n��</br>
        /// <br>Date        : K2011/12/09</br>
        /// <br>�Ǘ��ԍ�    : 10703874-00 �C�X�R�ʑΉ�</br>
        public DateTime GetServerNowTime()
        {
            return DateTime.Now;
        }
        
        #endregion
        // ----- ADD K2011/08/12 ---------------------------<<<<<

        // --- ADD 2012/11/30 Y.Wakita ---------->>>>>
        # region [�폜����A]

        /// <summary>
        /// �G���g�������폜
        /// </summary>
        /// <param name="paraList">�����폜���I�u�W�F�N�g���X�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <returns>STATUS</returns>
        public int DeleteA(ref object paraList, out string retMsg, out string retItemInfo)
        {
            // �߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlEncryptInfo encryptinfo = null;

            try
            {
                ArrayList paraArraylist = paraList as ArrayList;

                status = this.DeleteProcA(ref paraArraylist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);

                if (transaction != null && transaction.Connection != null)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);

                retMsg += (string.IsNullOrEmpty(retMsg) ? "" : "\n") + ex.Message;

                if (transaction != null && transaction.Connection != null)
                {
                    transaction.Rollback();
                }
            }
            finally
            {
                // �g�����U�N�V�����̔j��
                if (transaction != null)
                {
                    transaction.Dispose();
                }

                // �Í����L�[�̃N���[�Y (�ۗ�)
                //if (encryptinfo != null && encryptinfo.IsOpen)
                //{
                //    encryptinfo.CloseSymKey(ref connection);
                //}

                // �R�l�N�V�����̔j��
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return status;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="retMsg"></param>
        /// <param name="retItemInfo"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="encryptinfo"></param>
        /// <br>Note             :   �d�����׃}�X�^�̓�����������폜����B</br>
        /// <br>Programmer       :   �e�c�@���V</br>
        /// <br>Date             :   2012/11/30</br>
        /// <br>Update Note      :   UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j</br>
        /// <br>Programmer       :   ���O</br>
        /// <br>Date             :   2020/03/25</br>
        /// <returns></returns>
        private int DeleteProcA(ref ArrayList paraList, out string retMsg, out string retItemInfo, ref SqlConnection connection, ref SqlTransaction transaction, ref SqlEncryptInfo encryptinfo)
        {
            //���߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            retItemInfo = string.Empty;

            //���e��p�����[�^�̊m�F���s��
            # region [�p�����[�^�`�F�b�N]

            //���X�V��񃊃X�g�`�F�b�N
            if (SlipListUtils.IsEmpty(paraList))
            {
                retMsg = "�X�V��񃊃X�g�����o�^�ł��B";
                return status;
            }

            //������E�d������I�v�V�����`�F�b�N
            this.CtrlOptWork = SlipListUtils.Find(paraList, typeof(IOWriteCtrlOptWork), SlipListUtils.FindType.Class) as IOWriteCtrlOptWork;

            if (this.CtrlOptWork == null)
            {
                retMsg = "����E�d������I�v�V������������܂���B";
                return status;
            }

            // --- ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
            string enterpriseCode = this.CtrlOptWork.EnterpriseCode;

            // ��ƃR�[�h���󗓂̏ꍇ
            if (string.IsNullOrEmpty(enterpriseCode))
            {
                try
                {
                    ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                    enterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;

                    // �T�[�o�[�����ʕ��i�ŋ󗓂̊�ƃR�[�h���擾�����ꍇ
                    if (string.IsNullOrEmpty(enterpriseCode))
                    {
                        base.WriteErrorLog("IOWriteControlDB.DeleteProcA:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɋ󗓂̊�ƃR�[�h���擾����܂����B", status);
                    }
                }
                catch
                {
                    base.WriteErrorLog("IOWriteControlDB.DeleteProcA:���ʕ��i�Ŋ�ƃR�[�h���擾�����ۂɗ�O���������܂����B", status);
                }
            }
            // ���b�N���\�[�X��
            string resNm = this.GetResourceName(enterpriseCode);
            // --- ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<

            //���R�l�N�V�����`�F�b�N
            if (connection == null)
            {
                connection = this.CreateSqlConnection(true);
            }

            if (connection == null)
            {
                retMsg = "�f�[�^�x�[�X�֐ڑ��o���܂���B";
                base.WriteErrorLog(string.Format("IOWriteControlDB.DeleteProcA_connection:{0}", retMsg), status);  // ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                return status;
            }

            # region [--- �Í��� �ۗ� ---]
            /* --- �ۗ� ---
            //���Í����L�[�`�F�b�N
            if (encryptinfo == null)
            {
                List<string> ConcatArray = new List<string>();
                
                // �Í����Ώۂ̔���f�[�^�n�e�[�u�����X�g���擾
                ConcatArray.AddRange(IOWriteMAHNBDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
                
                // �Í����Ώۂ̎d���f�[�^�n�e�[�u�����X�g���擾
                ConcatArray.AddRange(IOWriteMASIRDBServerRsc.GetAccessEncryptTableList(AssemblyInfo_Function.FuncType.Write));
                
                // �e�[�u�����X�g�̌���
                string[] tablenames = ConcatArray.ToArray();

                encryptinfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, tablenames);
            }

            if (encryptinfo == null)
            {
                retMsg = "�Í����L�[���쐬�o���܂���B";
                return status;
            }

            encryptinfo.OpenSymKey(ref connection);

            if (!encryptinfo.IsOpen)
            {
                retMsg = "�Í����L�[���I�[�v���o���܂���B";
                return status;
            }
            */
            # endregion

            //���g�����U�N�V�����`�F�b�N
            if (transaction == null)
            {
                transaction = this.CreateTransaction(ref connection);
            }

            if (transaction == null)
            {
                retMsg = "�g�����U�N�V�������J�n�ł��܂���B";
                base.WriteErrorLog(string.Format("IOWriteControlDB.DeleteProcA:{0}", retMsg), status);  // ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�
                return status;
            }

            # endregion

            //���r�����b�N���J�n����
#if !DEBUG // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
            ShareCheckInfo info = null;
            this.ShareCheckInitialize(paraList, ref info, ref connection, ref transaction);
            // --- ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
            try
            {
            // --- ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                status = this.ShareCheck(info, LockControl.Locke, connection, transaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

            // --- UPD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IOWriteControlDB.DeleteProcA_ShareCheckLocke:" + ex.ToString());
                throw ex;
            }

            //status = this.Lock(this.ResourceName, connection, transaction);
            // �O���[�o���ϐ��̑���Ƀ��[�J���̃��\�[�X�����g�p����
            status = this.Lock(resNm, connection, transaction);
            // --- UPD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    retMsg = "���b�N�^�C���A�E�g���������܂����B";
                }
                else
                {
                    retMsg = "�r�����b�N�Ɏ��s���܂����B";
                }
                base.WriteErrorLog(string.Format("IOWriteControlDB.DeleteProcA_Lock:{0}" + retMsg), status);  // ADD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή�

                return status;
            }
# endif

            try
            {
                # region [�o�^�f�[�^��������]
                Hashtable new2org = new Hashtable();

                foreach (object item in paraList)
                {
                    if (item is IOWriteCtrlOptWork)
                    {
                        continue;
                    }
                    else
                    {
                        SlipType slipType = SlipListUtils.GetSlipType(item);


                        ArrayList newSliplist = item as ArrayList;
                        ArrayList orgSliplist = null;

                        switch (slipType)
                        {
                            case SlipType.Purchase:
                                {
                                    // �d���n�f�[�^�o�^��������
                                    status = this.PurchaseWriteInitialize(out orgSliplist, ref newSliplist, ref paraList, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        new2org.Add(newSliplist, orgSliplist);
                                    }
                                    break;
                                }
                            case SlipType.PurchaseDel:
                            case SlipType.SalesDel:
                                {
                                    // �d���E����폜����
                                    // ���o�^���������̒��œo�^�ςݓ`�[�f�[�^��Ǎ���ł���ׁA�폜�����͍ŏ��ɍs���K�v������

                                    int orgCtrlStartingPoint = this.CtrlOptWork.CtrlStartingPoint;

                                    // �`�[�폜�p�p�����[�^���X�g�̍쐬
                                    ArrayList delPrm = new ArrayList();
                                    delPrm.Add(this.CtrlOptWork);
                                    delPrm.Add(item);

                                    if (slipType == SlipType.PurchaseDel)
                                    {
                                        // �d���폜�̏ꍇ�͋����I�ɐ���N�_���d���ɂ���
                                        this.CtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Purchase;
                                    }
                                    else
                                    {
                                        // ����폜�̏ꍇ�͋����I�ɐ���N�_�𔄏�ɂ���
                                        this.CtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;
                                    }

                                    try
                                    {
                                        status = this.DeleteProc(ref delPrm, 1, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                    }
                                    finally
                                    {
                                        this.CtrlOptWork.CtrlStartingPoint = orgCtrlStartingPoint;
                                    }

                                    break;
                                }
                        }

                        // �o�^���������Ɏ��s�����ꍇ�͏����𒆒f����
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            retMsg += (!string.IsNullOrEmpty(retMsg) ? "\n" : "") + string.Format("IOWriteControlDB.WriteProc: �`�[�f�[�^�̓o�^���������Ɏ��s���܂����B(SlipType = {0})", Enum.GetName(typeof(SlipType), slipType));
                            break;
                        }
                    }
                }
                # endregion

                # region [�f�[�^�o�^����]
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    CustomSerializeArrayList paracuslist = new CustomSerializeArrayList();
                    foreach (object listItem in paraList)
                    {
                        if (listItem is IOWriteCtrlOptWork)
                        {
                            continue;
                        }

                        int findObjPos = -1;
                        paracuslist.Clear();

                        if (listItem is ArrayList)
                        {
                            ArrayList newSliplist = listItem as ArrayList;
                            ArrayList orgSliplist = null;

                            SlipType slipType = SlipListUtils.GetSlipType(newSliplist);

                            switch (slipType)
                            {
                                case SlipType.Estimation:
                                case SlipType.AcceptAnOrder:
                                case SlipType.Shipment:
                                case SlipType.Sales:
                                    {
                                        // ����f�[�^�폜�p�I�u�W�F�N�g�̑��݃`�F�b�N
                                        SlipListUtils.Find((listItem as ArrayList), typeof(IOWriteMAHNBDeleteWork), SlipListUtils.FindType.Class, out findObjPos);

                                        if (findObjPos >= 0)
                                        {
                                            // ����f�[�^�̍폜����
                                            paracuslist.AddRange(listItem as ArrayList);
                                            status = this.salesIOWriteDB.Delete(ref paracuslist, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                        }
                                        break;
                                    }
                                case SlipType.Order:
                                case SlipType.Arrival:
                                case SlipType.Purchase:
                                    {
                                        // �d���n�f�[�^�o�^����
                                        orgSliplist = new2org[newSliplist] as ArrayList;
                                        status = this.PurchaseWrite(orgSliplist, ref newSliplist, ref paraList, out retMsg, out retItemInfo, ref connection, ref transaction, ref encryptinfo);
                                        break;
                                    }
                            }

                            // �o�^�����Ɏ��s�����ꍇ�͏����𒆒f����
                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                retMsg += (!string.IsNullOrEmpty(retMsg) ? "\n" : "") + string.Format("IOWriteControlDB.WriteProc: �`�[�f�[�^�̓o�^�����Ɏ��s���܂����B(SlipType = {0})", Enum.GetName(typeof(SlipType), slipType));
                                break;
                            }
                        }
                    }
                }
                # endregion
            }
            finally
            {
                //���r�����b�N����������
#if !DEBUG // Debug���ɑ��̐l�̖��f�ɂȂ�Ȃ��l�Ɂc
                // --- UPD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ---------->>>>>
                //���r�����b�N����������
                //this.Release(this.ResourceName, connection, transaction);
                //this.ShareCheck(info, LockControl.Release, connection, transaction);
                int releaseStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                if (connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.DeleteProcA_Release: �A�v���P�[�V�������b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                }
                else if (transaction == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.DeleteProcA_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                }
                else if (transaction.Connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.DeleteProcA_Release: �A�v���P�[�V�������b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                }
                else
                {
                    // �A�v���P�[�V�������b�N����
                    releaseStatus = this.Release(resNm, connection, transaction);
                    if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        base.WriteErrorLog("IOWriteControlDB.DeleteProcA_Release: �A�v���P�[�V�������b�N���������Ɏ��s���܂����B", releaseStatus);
                    }
                }

                if (connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.DeleteProcA_ShareCheckRelease: �V�F�A�`�F�b�N�����O�Ƀf�[�^�x�[�X�ɐڑ��ł��܂���B", releaseStatus);
                }
                else if (transaction == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.DeleteProcA_ShareCheckRelease: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�������I�����Ă��܂��B", releaseStatus);
                }
                else if (transaction.Connection == null)
                {
                    base.WriteErrorLog("IOWriteControlDB.DeleteProcA_ShareCheckRelease: �V�F�A�`�F�b�N�����O�Ƀg�����U�N�V�����ɗ�O���������܂����B", releaseStatus);
                }
                else
                {
                    // �V�F�A�`�F�b�N����
                    releaseStatus = this.ShareCheck(info, LockControl.Release, connection, transaction);
                    if (releaseStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        base.WriteErrorLog("IOWriteControlDB.DeleteProcA_ShareCheckRelease: �V�F�A�`�F�b�N���������Ɏ��s���܂����B", releaseStatus);
                    }
                }
                // --- UPD 2020/03/25 ���O�@�A�v���P�[�V�������b�N�s��Ή� ----------<<<<<
                
#endif
            }

            return status;

        }
        # endregion
        // --- ADD 2012/11/30 Y.Wakita ----------<<<<<

        // --- ADD 2014/05/01 T.Miyamoto �d�|�ꗗ��2257 ------------------------------>>>>>
        # region [�ԕi���݃`�F�b�N]
        /// <summary>
        /// �w�肳�ꂽ���׃f�[�^�ɑ΂��ĕԕi�����݂��邩�m�F
        /// </summary>
        /// <param name="paraList"></param>
        /// <returns>STATUS</returns>
        public bool CheckReturnData(object paraList)
        {
            SalesDetailWork paraSalesDetailWork = (SalesDetailWork)(paraList as ArrayList)[0];

            //�Ăяo���p�����[�^�ݒ�
            SqlConnection sqlConnection = this.CreateSqlConnection(true);
            SqlTransaction sqlTransaction = null;

            bool status = this.CheckReturnData(paraSalesDetailWork, ref sqlConnection, ref sqlTransaction);

            return status;
        }
        /// <summary>
        /// �w�肳�ꂽ���׃f�[�^�ɑ΂��ĕԕi�����݂��邩�m�F
        /// </summary>
        /// <param name="parasalesDetailWorks">�Ǎ��p�����[�^</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        private bool CheckReturnData(SalesDetailWork parasalesDetailWorks, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            bool status = false;

            if (parasalesDetailWorks != null)
            {
                SqlCommand command = null;
                try
                {
                    //Select�R�}���h�̐���
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        SqlDataReader myReader = null;
                        sqlCommand.Connection = sqlConnection;
                        if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                        string sqlText = string.Empty;

                        sqlText += "SELECT COUNT(SALESSLIPNUMRF) AS RETCNT" + Environment.NewLine;
                        sqlText += "  FROM SALESDETAILRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                        sqlText += "  WHERE LOGICALDELETECODERF = 0" + Environment.NewLine;
                        sqlText += "    AND ACPTANODRSTATUSSRCRF = @FINDACPTANODRSTATUSSRC" + Environment.NewLine;
                        sqlText += "    AND SALESSLIPDTLNUMSRCRF = @FINDSALESSLIPDTLNUMSRC" + Environment.NewLine;
                        sqlText += "    AND SALESSLIPCDDTLRF = 1";
                        sqlCommand.CommandText = sqlText;

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findAcptAnOdrStatusSrc = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUSSRC", SqlDbType.Int);
                        SqlParameter findSalesSlipDtlNumSrc = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUMSRC", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findAcptAnOdrStatusSrc.Value = parasalesDetailWorks.AcptAnOdrStatus; //�󒍃X�e�[�^�X
                        findSalesSlipDtlNumSrc.Value = parasalesDetailWorks.SalesSlipDtlNum; //���㖾�גʔ�

                        try
                        {
                            myReader = sqlCommand.ExecuteReader();
                            if (myReader.Read())
                            {
                                int retCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETCNT"));
                                if (retCnt > 0)
                                {
                                    status = true;
                                }
                            }
                        }
                        finally
                        {
                            if (myReader != null)
                            {
                                if (!myReader.IsClosed) myReader.Close();
                                myReader.Dispose();
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    base.WriteSQLErrorLog(ex, "SalesSlipDB.CheckSalesAddUpDate�ɂ�SQL��O�����BMSG=" + ex.Message, 0);
                }
                catch (Exception ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    base.WriteErrorLog(ex, "SalesSlipDB.CheckSalesAddUpDate�ɂė�O�����BMSG=" + ex.Message, 0);
                }
            }
            return status;
        }
        # endregion
        // --- ADD 2014/05/01 T.Miyamoto �d�|�ꗗ��2257 ------------------------------<<<<<
    }
}
