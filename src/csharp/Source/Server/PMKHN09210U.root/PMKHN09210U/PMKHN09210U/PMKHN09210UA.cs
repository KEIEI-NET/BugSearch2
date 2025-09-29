using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
//using System.ServiceProcess;
using Microsoft.Win32;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.UIData;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Controller.Util;    // ADD 2009/01/22 �@�\�ǉ�

namespace Broadleaf.Windows.Forms
{
    using LatestPair = Pair<DateTime, int>;

    /// <summary>
    /// �T�[�o���̉��i�����������s���B
    /// </summary>
    public partial class PMKHN09210UA : Form
    {
        #region [ Private Member ]
        private OfferMergeAcs _OfferMergeAcs;
        private string enterpriseCode;
        private conf _dtHist;
        private const string ct_cfgFile = "PriceUpdCfg.xml";
        private readonly string[] lstCaption = new string[5] { "�����J�n����\r  [HHMM]", "�����I������\r  [HHMM]", 
                                    "���sPg��","�N�����Ұ�", "�����Ԋu\r(���ԁj" };

        private string workDir = string.Empty;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public PMKHN09210UA()
        {
            InitializeComponent();
            _OfferMergeAcs = new OfferMergeAcs();
        }

        private void PMKHN09210UA_Shown(object sender, EventArgs e)
        {
            if (ReadCfgFile() != 0)
            {
                //MessageBox.Show("�ݒ�t�@�C���̓ǂݍ��݂Ɏ��s���܂����B", Text, MessageBoxButtons.OK);
            }
            gridConf.DataSource = _dtHist.Conf;
            for (int i = 0; i < gridConf.Columns.Count; i++)
            {
                gridConf.Columns[i].HeaderText = lstCaption[i];
            }

            gridConf.Columns[0].Width = 125; // �����J�n����
            gridConf.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridConf.Columns[0].ValueType = typeof(int);
            gridConf.Columns[1].Width = 125; // �����I������
            gridConf.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridConf.Columns[2].Width = 200; // ���sPg��
            gridConf.Columns[3].Width = 80;  // �N�����Ұ�
            gridConf.Columns[4].Width = 100; // �����Ԋu
            gridConf.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void PMKHN09210UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteCfgFile();
        }

        #region [ XML���[�h�E���C�g ]
        /// <summary>
        /// �ݒ�t�@�C���Ǎ���
        /// </summary>
        /// <returns></returns>
        private int ReadCfgFile()
        {
            int status = 0;
            _dtHist = new conf();
            try
            {
                FileStream fs = new FileStream(ct_cfgFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                byte[] tmp = new byte[fs.Length];
                int cnt = fs.Read(tmp, 0, (int)fs.Length);
                for (int i = 0; i < cnt; i++)
                {
                    tmp[i] += 8;
                }
                fs.Close();
                MemoryStream ms = new MemoryStream(tmp);
                _dtHist.ReadXml(ms);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// �ݒ�t�@�C��������
        /// </summary>
        /// <returns></returns>
        private int WriteCfgFile()
        {
            int status = 0;
            string xml = _dtHist.GetXml();
            try
            {
                byte[] tmp = Encoding.Default.GetBytes(xml);
                FileStream fs = new FileStream(ct_cfgFile, FileMode.Create);
                for (int i = 0; i < tmp.Length; i++)
                {
                    tmp[i] -= 8;
                }
                fs.Write(tmp, 0, tmp.Length);
                fs.Close();
            }
            catch
            {
                status = -1;
            }

            return status;
        }
        #endregion

        /// <summary>�}�[�W�f�[�^�̎擾��</summary>
        private IMergeDataGet _iMergeDataGetter;
        // ADD 2009/02/02 �@�\�ǉ��F�Ώۓ��t�擾 ---------->>>>>
        /// <summary>
        /// �}�[�W�f�[�^�̎擾�҂��擾���܂��B
        /// </summary>
        private IMergeDataGet MergeDataGetter
        {
            get
            {
                if (_iMergeDataGetter == null)
                {
                    _iMergeDataGetter = MediationMergeDataGetDB.GetRemoteObject();
                }
                return _iMergeDataGetter;
            }
        }
        // ADD 2008/02/02 �@�\�ǉ��F�Ώۓ��t�擾 ----------<<<<<


        /// <summary>�}�[�W�̎��s��</summary>
        private IOfferMerge _iOfferMerger;
        // ADD 2009/02/02 �@�\�ǉ��F�Ώۓ��t�擾 ---------->>>>>
        /// <summary>
        /// �}�[�W�̎��s�҂��擾���܂��B
        /// </summary>
        private IOfferMerge OfferMerger
        {
            get
            {
                if (_iOfferMerger == null)
                {
                    _iOfferMerger = MediationOfferMergeDB.GetRemoteObject();
                }
                return _iOfferMerger;
            }
        }

        /// <summary>
        /// �l�̃y�A�N���X
        /// </summary>
        /// <typeparam name="TFirst">1�Ԗڂ̒l�̌^</typeparam>
        /// <typeparam name="TSecond">2�Ԗڂ̒l�̌^</typeparam>
        public class Pair<TFirst, TSecond>
        {
            /// <summary>1�Ԗڂ̒l</summary>
            private readonly TFirst _first;
            /// <summary>
            /// 1�Ԗڂ̒l���擾���܂��B
            /// </summary>
            /// <value>1�Ԗڂ̒l</value>
            public TFirst First { get { return _first; } }

            /// <summary>2�Ԗڂ̒l���擾���܂��B</summary>
            private readonly TSecond _second;
            /// <summary>
            /// 2�Ԗڂ̒l���擾���܂��B
            /// </summary>
            /// <value>2�Ԗڂ̒l</value>
            public TSecond Second { get { return _second; } }

            /// <summary>
            /// �J�X�^���R���X�g���N�^
            /// </summary>
            /// <param name="first">1�Ԗڂ̒l</param>
            /// <param name="second">2�Ԗڂ̒l</param>
            public Pair(
                TFirst first,
                TSecond second
            )
            {
                _first = first;
                _second = second;
            }

            #region <object override/>

            /// <summary>
            /// ������ɕϊ����܂��B
            /// </summary>
            /// <returns>������</returns>
            public override string ToString()
            {
                return First.ToString() + "," + Second.ToString();
            }

            #endregion  // <object override/>
        }

        #region [ �z�M�A�������}�[�W���� ]
        internal void MergeOfferToUser()
        {
            try
            {
                // ڼ޽�ط��擾
                StreamWriter writer = null;                          // �e�L�X�g���O�p
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (key == null) // �����Ă͂����Ȃ��P�[�X
                {
                    workDir = @"C:\Program Files\Partsman\USER_AP"; // ���W�X�g���ɏ�񂪂Ȃ����߁A���Ƀf�t�H���g�̃t�H���_��ݒ�
                }
                else
                {
                    // ���O��������̫��ގw��
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }

                Directory.CreateDirectory(@"" + workDir + @"\Log\PMCMN06200S");

                // ÷��۸ޏ����� (���������N��)
                writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now + " ���������N�� " + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();

                object objLatestList = null;
                enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                // �e�X�g�p
                //MessageBox.Show("���i����", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);



                int status = OfferMerger.GetLatestHistory(enterpriseCode, out objLatestList);
                ArrayList latestList = objLatestList as ArrayList;

                DateTime InstallOfferDate = DateTime.MinValue;
                _OfferMergeAcs.getInstallDate(ref InstallOfferDate);

                // ÷��۸ޏ����� (���������N��)
                writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now + " �C���X�g�[�����t " + InstallOfferDate + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();

                //****************************************************************
                // Dictionary<ð���ID,<���t(DateTime),�Ώی���(int)>>�ŗp�ӂ���
                //****************************************************************
                if (latestList.Count != 0)
                {
                    IDictionary<string, LatestPair> latestMap = new Dictionary<string, LatestPair>();
                    foreach (PriUpdTblUpdHisWork history in latestList)
                    {
                        string tableId = this.ConvertSyncTableNameToTableId(history.SyncTableName);
                        if (!latestMap.ContainsKey(tableId))
                        {
                            // �O�񏈗���
                            int offerDate = history.OfferDate;
                            DateTime dateTime = DateTime.MinValue;
                            //if (!offerDate.Equals(0))
                            //{
                            //history.OfferDate = 0;
                            if (history.OfferDate == 0)
                            {
                                // �D�ǥ���ʂ�ڼ޽�؂����t�擾
                                if (tableId.Equals(ProcessConfig.PRIME_SETTING_MASTER_ID) || tableId.Equals(ProcessConfig.PARTS_POS_CODE_MASTER_ID) || tableId.Equals(ProcessConfig.GOODS_MASTER_ID))
                                {
                                    dateTime = InstallOfferDate.AddMonths(-1);
                                }
                                // ���̑���Minvalue
                                else
                                {
                                    dateTime = DateTime.MinValue;
                                }
                            }
                            else
                            {
                                // 2��ڈȍ~
                                dateTime = DateTime.Parse(history.OfferDate.ToString("0000/00/00"));
                            }
                            // �e�X�g�p

                            //dateTime = DateTime.MinValue;
                            //}
                            int updatedCount = history.AddUpdateRowsNo;

                            latestMap.Add(tableId, new LatestPair(dateTime, updatedCount));

                            // �D�ǐݒ�ύX�}�X�^�p
                            if (tableId.Equals(ProcessConfig.PRIME_SETTING_MASTER_ID))
                            {
                                latestMap.Add(ProcessConfig.PRIME_SETTING_CHANGE_MASTER_ID, new LatestPair(dateTime, updatedCount));
                            }
                        }
                    }
                    //if (latestList)

                    ConvertPriceSyncTableNameToTableId(ref latestMap, InstallOfferDate);

                    #region Delete
                    //MessageBox.Show(dateTime.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ////}
                    //return;

                    //if (IsNewVersion() == false)
                    //    return;
                    //int offerDate;
                    #endregion

                    _OfferMergeAcs.Initialize(enterpriseCode);
                    if (status == 0)
                    {
                        string msg = string.Empty;
                        bool isMerged = _OfferMergeAcs.Checker.IsMerged(out msg);
                        if (!isMerged)
                        {
                            // ÷��۸ޏ����� (ϰ����������)
                            writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                            writer.Write(DateTime.Now + " ϰ���������ق��� �����X�V�J�n" + "\r\n");
                            writer.Flush();
                            if (writer != null) writer.Close();

                            // DEL 2009/11/11 MANTIS�Ή�[14363]�F�񋟃f�[�^�X�V�����C���^�[���b�N�̒ǉ� ---------->>>>>
                            //// ������MergeOfferToUser���ި����؎����čs���ăA�N�Z�X�N���X��private�ŕۊǂ�����
                            //status = _OfferMergeAcs.MergeOfferToUser(enterpriseCode, 0, latestMap);
                            // DEL 2009/11/11 MANTIS�Ή�[14363]�F�񋟃f�[�^�X�V�����C���^�[���b�N�̒ǉ� ----------<<<<<
                            // ADD 2009/11/11 MANTIS�Ή�[14363]�F�񋟃f�[�^�X�V�����C���^�[���b�N�̒ǉ� ---------->>>>>
                            if (OfferMergeInterlock.CanUpdate())
                            {
                                // ������MergeOfferToUser���ި����؎����čs���ăA�N�Z�X�N���X��private�ŕۊǂ�����
                                status = _OfferMergeAcs.MergeOfferToUser(enterpriseCode, 0, latestMap);
                            }
                            else
                            {
                                // ÷��۸ޏ����� (CurrentVersion �� TargetVersion ���s��v)
                                writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                                writer.Write(DateTime.Now + " CurrentVersion �� TargetVersion ���s��v�̂��ߎ����X�V�𒆎~" + "\r\n");
                                writer.Flush();
                                if (writer != null) writer.Close();
                            }
                            // ADD 2009/11/11 MANTIS�Ή�[14363]�F�񋟃f�[�^�X�V�����C���^�[���b�N�̒ǉ� ----------<<<<<

                            #region Delete
                            //if (status == 0 || status == 4) // �}�[�W���햔�̓}�[�W�ΏۂȂ���
                            //{
                            //    // USER_AP�ɒ񋟃o�[�W������������
                            //    //_VersionCheckAcs.UpdateVersion(ref CurrentVersion);

                            //    //RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\OFFER_AP\localhost\OFFER_DB");
                            //    //object currentVer = key.GetValue("CurrentVersion", "8.10.1.0");
                            //    //key.SetValue("MergedVersion", currentVer, RegistryValueKind.String);
                            //}
                            #endregion
                        }
                        else
                        {
                            // ÷��۸ޏ����� (ϰ�������Ȃ�)
                            writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                            writer.Write(DateTime.Now + " ϰ���������قȂ� �����X�V�Ȃ�" + "\r\n");
                            writer.Flush();
                            if (writer != null) writer.Close();
                        }
                    }
                }
                Close();

                // ÷��۸ޏ����� (�I��)
                writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now + " ���������I�� " + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();
            }
            //}
            catch { }
        }

        // �C���X�g�[�����t�擾
        private DateTime GetInstallDate()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\OFFER_AP\localhost\OFFER_DB");
            if (key == null)
            {
                return DateTime.MinValue;
            }
            string InstalOfferDate = key.GetValue("InstallOfferDate").ToString();
            int InstDateint = Int32.Parse(InstalOfferDate.Trim());

            DateTime instalOfferDate = DateTime.Parse(InstDateint.ToString("0000/00/00"));

            // �C���X�g�[�����t���1�����O����}�[�W�������邽��
            return instalOfferDate.AddMonths(-1);
        }

        // ���i�������X�g�i�[
        private void ConvertPriceSyncTableNameToTableId(ref IDictionary<string, Broadleaf.Application.Controller.Util.Pair<DateTime, int>> latestMap, DateTime InstallOfferDate)
        {
            // ���i�����p
            if (!latestMap.ContainsKey(ProcessConfig.GOODS_MASTER_ID))
            {
                latestMap.Add(ProcessConfig.GOODS_MASTER_ID, new LatestPair(InstallOfferDate.AddMonths(-1), 0));
            }
            //if (!latestMap.ContainsKey(ProcessConfig.GOODS_PRICE_MASTER_ID))
            //{
            //    latestMap.Add(ProcessConfig.GOODS_PRICE_MASTER_ID, new LatestPair(GetInstallDate(), 0));
            //}

            //string key = string.Empty;
            //if (latestMap[ProcessConfig.GOODS_MASTER_ID].First >= latestMap[ProcessConfig.GOODS_PRICE_MASTER_ID].First)
            //{
            //    key = ProcessConfig.GOODS_MASTER_ID;
            //}
            //else
            //{
            //    key = ProcessConfig.GOODS_PRICE_MASTER_ID;
            //}

            //latestMap.Add(ProcessConfig.PRICE_REVISION_ID, new LatestPair(latestMap[key].First, latestMap[key].Second));
        }

        //�e�[�u��ID�ƍ�
        private string ConvertSyncTableNameToTableId(string syncTableName)
        {
            if (syncTableName.Equals("BLGROUPURF"))
            {
                return ProcessConfig.BL_GROUP_MASTER_ID;        // BL�O���[�v�}�X�^
            }
            if (syncTableName.Equals("GOODSGROUPURF"))
            {
                return ProcessConfig.MIDDLE_GENRE_MASTER_ID;    // �����ރ}�X�^
            }
            if (syncTableName.Equals("MODELNAMEURF"))
            {
                return ProcessConfig.MODEL_NAME_MASTER_ID;      // �Ԏ�}�X�^
            }
            if (syncTableName.Equals("PARTSPOSCODEURF"))
            {
                return ProcessConfig.PARTS_POS_CODE_MASTER_ID;  // ���ʃ}�X�^
            }
            if (syncTableName.Equals("BLGOODSCDURF"))
            {
                return ProcessConfig.BL_CODE_MASTER_ID;         // BL�R�[�h�}�X�^
            }
            if (syncTableName.Equals("PRMSETTINGURF"))
            {
                return ProcessConfig.PRIME_SETTING_MASTER_ID;   // �D�ǐݒ�}�X�^
            }
            //if (syncTableName.Equals("GOODSMNGURF"))
            if (syncTableName.Equals("GOODSURF"))
            {
                return ProcessConfig.GOODS_MASTER_ID;           // ���i�}�X�^
            }
            if (syncTableName.Equals("PRICEURF"))
            {
                return ProcessConfig.GOODS_PRICE_MASTER_ID;     // ���i�}�X�^
            }
            if (syncTableName.Equals("MAKERURF"))
            {
                return ProcessConfig.MAKER_MASTER_ID;           // ���[�J�[�}�X�^
            }

            return string.Empty;
        }

        /// <summary>
        /// ���t�ϊ�����(int -> DateTime)
        /// </summary>
        /// <param name="date">�ϊ�������t�f�[�^(YYYYMMDD)</param>
        /// <returns></returns>
        private DateTime ConverIntToDateTime(int date)
        {
            if (date < 0)
                return DateTime.MinValue;
            int year = date / 10000;
            int month = (date % 10000) / 100;
            int day = (date % 10000) % 100;
            if (year == 0 || month == 0 || day == 0)
                return DateTime.MinValue;
            return new DateTime(year, month, day);
        }


        /// <summary>
        /// �V�����z�M�����邩�`�F�b�N
        /// </summary>
        /// <returns>true:�V�����z�M����^false:�V�����z�M�Ȃ�</returns>
        private bool IsNewVersion()
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\OFFER_AP\localhost\OFFER_DB");
                if (key == null) // �z�M�����������Ȃ������H
                {
                    return false;
                }
                string currentVer = key.GetValue("CurrentVersion", "8.10.1.0").ToString();
                object objMergedVer = key.GetValue("MergedVersion");
                if (objMergedVer == null) // �}�[�W�������������ƂȂ����H
                    return true;
                string mergedVer = objMergedVer.ToString();

                if (currentVer.CompareTo(mergedVer) > 0)
                    return true;
            }
            catch
            {
            }
            return false;

        }
        #endregion

        private void gridConf_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            int row = e.RowIndex;
            try
            {
                int st;
                int ed;
                int interval;
                int st_ed_intval;
                if (int.TryParse(gridConf[0, row].Value.ToString(), out st) == false
                    || int.TryParse(gridConf[1, row].Value.ToString(), out ed) == false
                    || int.TryParse(gridConf[4, row].Value.ToString(), out interval) == false)
                {
                    e.Cancel = true;
                    return;
                }
                if (ed > st)
                {
                    st_ed_intval = ((ed / 100) * 60) + (ed % 100) - (((st / 100) * 60) + (st % 100));
                }
                else
                {
                    st_ed_intval = 24 * 60 - (((st / 100) * 60) + (st % 100));
                    st_ed_intval += ((ed / 100) * 60) + (ed % 100);
                }
                if (interval * 60 >= st_ed_intval)
                {
                    //MessageBox.Show("�`�F�b�N�Ԋu���`�F�b�N�J�n�����ƃ`�F�b�N�I�������̊Ԋu��菬���߂ɂ��ĉ������B",
                    //    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
            catch
            {
                e.Cancel = true;
            }

        }

        private void gridConf_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int tmp;
            switch (e.ColumnIndex)
            {
                case 0:
                case 1:
                case 4:
                    if (int.TryParse(e.FormattedValue.ToString(), out tmp) == false)
                    {
                        //MessageBox.Show("�����̂ݓ��͉\�ȍ��ڂł��B", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        break;
                    }
                    if (e.ColumnIndex != 4 && (tmp < 0 || tmp > 2400))
                    {
                        //MessageBox.Show("HHMM�`����0~2400�̊Ԃ̒l����͂��ĉ������B", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        break;
                    }
                    if (e.ColumnIndex == 4 && tmp <= 0)
                    {
                        //MessageBox.Show("0���傫���Ԋu�ɂ��ĉ������B", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        break;
                    }
                    break;

                //case 2:
                //    if (e.FormattedValue.Equals(string.Empty))
                //    {
                //        MessageBox.Show("�K�{���ڂł��B", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        e.Cancel = true;
                //    }
                //    break;
            }
        }
    }

    // ADD 2009/11/11 MANTIS�Ή�[14363]�F�񋟃f�[�^�X�V�����C���^�[���b�N�̒ǉ� ---------->>>>>
    #region �񋟃f�[�^�X�V�����C���^�[���b�N

    /// <summary>
    /// �񋟃f�[�^�X�V�����C���^�[���b�N�N���X
    /// </summary>
    internal static class OfferMergeInterlock
    {
        #region ���W�X�g�����

        /// <summary>�o�[�W�������i�[���Ă��郌�W�X�g���L�[</summary>
        private const string VERSION_REGISTRY_KEY = @"SOFTWARE\Broadleaf\Service\Partsman\OFFER_AP\localhost\OFFER_DB";
        /// <summary>�o�[�W�������i�[���Ă��郌�W�X�g���L�[���擾���܂��B</summary>
        private static string VersionRegistryKey { get { return VERSION_REGISTRY_KEY; } }

        /// <summary>���݂̃o�[�W�����̃��W�X�g���l</summary>
        private const string CURRENT_VERSION_REGISTRY_VALUE = "CurrentVersion";
        /// <summary>���݂̃o�[�W�����̃��W�X�g���l���擾���܂��B</summary>
        private static string CurrentVersionRegistryValue { get { return CURRENT_VERSION_REGISTRY_VALUE; } }

        /// <summary>�Ώۃo�[�W�����̃��W�X�g���l</summary>
        private const string TARGET_VERSION_REGISTRY_VALUE = "TargetVersion";
        /// <summary>�Ώۃo�[�W�����̃��W�X�g���l���擾���܂��B</summary>
        private static string TargetVersionRegistryValue { get { return TARGET_VERSION_REGISTRY_VALUE; } }

        #endregion // ���W�X�g�����

        /// <summary>
        /// �X�V�������s���邩���f���܂��B(�T�[�o�p���W�X�g�����Q�Ƃ��܂�)
        /// </summary>
        /// <remarks>CurrentVersion��TargetVersion�������l�ł����<c>true</c>��Ԃ��܂��B</remarks>
        /// <returns>
        /// <c>true</c> :�X�V�������s���܂��B<br/>
        /// <c>false</c>:�X�V�������s���܂���B
        /// </returns>
        public static bool CanUpdate()
        {
            try
            {
                string currentVersion= string.Empty;
                string targetVersion = string.Empty;
                Microsoft.Win32.RegistryKey versionKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(VersionRegistryKey);
                {
                    currentVersion= (string)versionKey.GetValue(CurrentVersionRegistryValue);
                    targetVersion = (string)versionKey.GetValue(TargetVersionRegistryValue);
                }
                versionKey.Close();

                return currentVersion.Equals(targetVersion);
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }
    }

    #endregion // �񋟃f�[�^�X�V�����C���^�[���b�N
    // ADD 2008/11/11 MANTIS�Ή�[14363]�F�񋟃f�[�^�X�V�����C���^�[���b�N�̒ǉ� ----------<<<<<
}
