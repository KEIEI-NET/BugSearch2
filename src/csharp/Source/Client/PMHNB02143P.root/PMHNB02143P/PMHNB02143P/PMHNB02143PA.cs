using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// �o�׏��i�D�ǑΉ��\�@����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�׏��i�D�ǑΉ��\�̈�����s���B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2008.11.14</br>
    /// <br>Update Note: 2009/03/17 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12701</br>
    /// <br>Update Note: 2014/12/16 ����</br>
    /// <br>�Ǘ��ԍ�   : 11070263-00</br>
    /// <br>           :�E�����Y�ƗlSeiken�i�ԕύX</br>
    /// </remarks>
    public class PMHNB02143PA : IPrintProc
    {
        #region �� �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMHNB02143PA()
        {
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="printInfo"></param>
        public PMHNB02143PA(object printInfo)
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._shipGdsPrimeListCndtn = this._printInfo.jyoken as ShipGdsPrimeListCndtn;
        }
        #endregion
        
        #region �� Private�萔
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "�@";
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
        private const string ct_RangeConst = "�F{0} �` {1}";
        #endregion �� Pricate Const

        #region �� Private�ϐ�
        private SFCMN06002C _printInfo;					// ������N���X
        private ShipGdsPrimeListCndtn _shipGdsPrimeListCndtn;		// ���o�����N���X
        #endregion �� Private Member

        #region �� Exception Class
        /// <summary> ��O�N���X </summary>
        private class StockMoveException : ApplicationException
        {
            private int _status;
            #region �� Constructor
            /// <summary>
            /// ��O�N���X�R���X�g���N�^
            /// </summary>
            /// <param name="message">���b�Z�[�W</param>
            /// <param name="status">�X�e�[�^�X</param>
            public StockMoveException(string message, int status)
                : base(message)
            {
                this._status = status;
            }
            #endregion

            #region �� Public Property
            /// <summary> �X�e�[�^�X�v���p�e�B </summary>
            public int Status
            {
                get { return this._status; }
            }
            #endregion
        }
        #endregion �� Exception Class

        #region �� IPrintProc �����o
        #region �� Public Property
        /// <summary>
        /// ������擾�v���p�e�B
        /// </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� ��������J�n
        /// <summary>
        /// ��������J�n
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ������J�n����B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.14</br>
        /// </remarks>
        public int StartPrint()
        {
            return PrintMain();
        }
        #endregion
        #endregion �� Public Method
        #endregion �� IPrintProc �����o

        #region �� private���\�b�h
        private int PrintMain()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // ����t�H�[���N���X�C���X�^���X�쐬
            DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;

            try
            {
                // ���|�[�g�C���X�^���X�쐬
                this.CreateReport(out prtRpt, this._printInfo.prpid);
                if (prtRpt == null) return status;

                // �e��v���p�e�B�ݒ�
                status = this.SettingProperty(ref prtRpt);
                if (status != 0) return status;

                // �f�[�^�\�[�X�ݒ�
                prtRpt.DataSource = this._printInfo.rdData;
                prtRpt.DataMember = PMHNB02145EB.ct_Tbl_ShipGdsPrimeListResultForPrint;

                // ������ʏ��v���p�e�B�ݒ�
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                //this.SetPrintCommonInfo(out commonInfo); // DEL 2009/03/17
                this.SetPrintCommonInfo(ref prtRpt, out commonInfo); // ADD 2009/03/17

                // �v���r���[�L��				
                int mode = this._printInfo.prevkbn;

                // �o�̓��[�h���o�c�e�̏ꍇ�A�������Ńv���r���[��
                if (this._printInfo.printmode == 2)
                {
                    mode = 0;
                }

                switch (mode)
                {
                    case 0:		// �v���r����
                        {
                            Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();

                            // ���ʏ����ݒ�
                            processForm.CommonInfo = commonInfo;

                            // �v���O���X�o�[UP�C�x���g�ǉ�
                            if (prtRpt is IPrintActiveReportTypeCommon)
                            {
                                ((IPrintActiveReportTypeCommon)prtRpt).ProgressBarUpEvent +=
                                    new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
                            }

                            // ������s
                            status = processForm.Run(prtRpt);

                            // �߂�l�ݒ�
                            this._printInfo.status = status;

                            break;
                        }
                    case 1:		// �v���r���L
                        {
                            Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

                            // ���ʏ����ݒ�
                            viewForm.CommonInfo = commonInfo;

                            // �v���r���[���s
                            status = viewForm.Run(prtRpt);

                            // �߂�l�ݒ�
                            this._printInfo.status = status;

                            break;
                        }
                }

                // �o�c�e�o�͂̏ꍇ
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    switch (this._printInfo.printmode)
                    {
                        case 1:  // �v�����^
                            break;
                        case 2:  // �o�c�e
                        case 3:  // ����(�v�����^ + �o�c�e)
                            {
                                // �o�c�e�\���t���OON
                                this._printInfo.pdfopen = true;

                                // ����������̂ݗ���ۑ�
                                if (this._printInfo.printmode == 3)
                                {
                                    // �o�͗����Ǘ��ɒǉ�
                                    Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                                    pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
                                        this._printInfo.pdftemppath);
                                }
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (prtRpt != null)
                {
                    prtRpt.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// �e��ActiveReport���[�C���X�^���X�쐬
        /// </summary>
        /// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <param name="prpid">���[�t�H�[��ID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.14</br>
        /// </remarks>
        private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid)
        {
            // ����t�H�[���N���X�C���X�^���X�쐬
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(),
                typeof(DataDynamics.ActiveReports.ActiveReport3));
        }

        /// <summary>
        /// ���|�[�g�A�Z���u���C���X�^���X��
        /// </summary>
        /// <param name="asmname">�A�Z���u������</param>
        /// <param name="classname">�N���X����</param>
        /// <param name="type">��������N���X�^</param>
        /// <returns>�C���X�^���X�����ꂽ�N���X</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.14</br>
        /// </remarks>
        private object LoadAssemblyReport(string asmname, string classname, Type type)
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
                    {
                        obj = Activator.CreateInstance(objType);
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new StockMoveException(asmname + "�����݂��܂���B", -1);
            }
            catch (System.Exception er)
            {
                throw new StockMoveException(er.Message, -1);
            }
            return obj;
        }

        /// <summary>
        /// �����ʋ��ʏ��ݒ�
        /// </summary>
        /// <param name="commonInfo"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.14</br>
        /// </remarks>
        //private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo) // DEL 2009/03/17
        private void SetPrintCommonInfo(ref DataDynamics.ActiveReports.ActiveReport3 rptObj, out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo) // ADD 2009/03/17
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();

            // ���[�`���[�g���ʕ��i�N���X
            SFCMN00331C cmnCommon = new SFCMN00331C();

            // PDF�p�X�擾
            string pdfPath = "";
            string pdfName = "";

            // �v�����^��
            commonInfo.PrinterName = this._printInfo.prinm;
            // ���[��
            commonInfo.PrintName = this._printInfo.prpnm;
            // ������[�h
            commonInfo.PrintMode = this.Printinfo.printmode;
            // �������
            commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;

            status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
            this._printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = this._printInfo.pdftemppath;

            // ��]��
            commonInfo.MarginsTop = this._printInfo.py;
            // ���]��
            commonInfo.MarginsLeft = this._printInfo.px;

            // --- ADD 2009/03/17 -------------------------------->>>>>
            rptObj.Document.CacheToDisk = true;
            rptObj.Document.CacheToDiskLocation = pdfPath;
            // --- ADD 2009/03/17 --------------------------------<<<<<
        }

        /// <summary>
        /// �e��v���p�e�B�ݒ�
        /// </summary>
        /// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.14</br>
        /// </remarks>
        private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ��������擾
            ShipGdsPrimeListCndtn extraInfo = (ShipGdsPrimeListCndtn)this._printInfo.jyoken;

            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;
            int st = ShipGdsPrimeListAsc.ReadPrtOutSet(out prtOutSet, out message);
            if (st != 0)
            {
                throw new StockMoveException(message, status);
            }

            // ���o�����w�b�_�o�͋敪
            instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

            // ���o�����ҏW����
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;

            // �t�b�^�o�͋敪
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // �t�b�^�o�̓��b�Z�[�W
            StringCollection footers = new StringCollection();
            footers.Add(prtOutSet.PrintFooter1);
            footers.Add(prtOutSet.PrintFooter2);

            instance.PageFooters = footers;

            // ������I�u�W�F�N�g
            instance.PrintInfo = this._printInfo;

            string printTypeTitle = string.Empty;

            // �w�b�_�[�T�u�^�C�g��
            instance.PageHeaderSubtitle = "�o�׏��i�D�ǑΉ��\";

            // ���̑��f�[�^
            // Todo:�ړ����Ƃ��n���H���o�����n�邩�炢�����H
            instance.OtherDataList = null;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
        }

        /// <summary>
        /// ���o�����o�͏��쐬
        /// </summary>
        /// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o������������쐬����B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.14</br>
        /// <br>Update Note: 2014/12/16 ����</br>
        /// <br>�Ǘ��ԍ�   : 11070263-00</br>
        /// <br>           :�E�����Y�ƗlSeiken�i�ԕύX</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            string stCode;
            string edCode;

            // �Ώ۔N��
            this.EditCondition(ref addConditions, string.Format("�Ώ۔N��" + ct_RangeConst,
                                              this._shipGdsPrimeListCndtn.St_AddUpYearMonth.ToString("yyyy/MM"),
                                              this._shipGdsPrimeListCndtn.Ed_AddUpYearMonth.ToString("yyyy/MM")));

            // �����敪
            this.EditCondition(ref addConditions, string.Format("�����敪�F{0}",
                                                this._shipGdsPrimeListCndtn.ComvDivStateTitle));


            // ����^�C�v
            this.EditCondition(ref addConditions, string.Format("����^�C�v�F{0}",
                                                            this._shipGdsPrimeListCndtn.PrintTypeStateTitle));

            // ����
            this.EditCondition(ref addConditions, string.Format("���ŁF{0}",
                                                            this._shipGdsPrimeListCndtn.NewPageDivStateTitle));

            // ���ʕt�ݒ�
            this.EditCondition(ref addConditions,
                string.Format("���ʕt���ݒ�F{0} {1} {2}�ʂ܂�", this._shipGdsPrimeListCndtn.RankSectionStateTitle, this._shipGdsPrimeListCndtn.RankHighLowStateTitle, this._shipGdsPrimeListCndtn.RankOrderMax)
            );

            //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------>>>>>
            // �i�ԏW�v�敪
            this.EditCondition(ref addConditions, string.Format("�i�ԏW�v�敪�F{0}",
                                                            this._shipGdsPrimeListCndtn.GoodsNoTtlDivStateTitle));

            // �i�ԏW�v�敪���u���Z�v��
            if (this._shipGdsPrimeListCndtn.GoodsNoTtlDiv == ShipGdsPrimeListCndtn.GoodsNoTtlDivState.Together)
            {
                // �i�ԕ\���敪
                this.EditCondition(ref addConditions, string.Format("�i�ԕ\���敪�F{0}",
                                                                this._shipGdsPrimeListCndtn.GoodsNoShowDivStateTitle));
            }
            //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------<<<<<

            // ���s
            this.EditConditionLetRight(ref addConditions, " ");

            // �������[�J�[
            if ((this._shipGdsPrimeListCndtn.St_GoodsMakerCd != 0) ||
                ((this._shipGdsPrimeListCndtn.Ed_GoodsMakerCd != 0) &&
                 (!string.IsNullOrEmpty(this._shipGdsPrimeListCndtn.Ed_GoodsMakerCd.ToString()))))
            {
                stCode = this._shipGdsPrimeListCndtn.St_GoodsMakerCd.ToString("00");
                edCode = this._shipGdsPrimeListCndtn.Ed_GoodsMakerCd.ToString("00");

                if (this._shipGdsPrimeListCndtn.St_GoodsMakerCd == 0) stCode = ct_Extr_Top;

                if ((this._shipGdsPrimeListCndtn.Ed_GoodsMakerCd == 0) ||
                    (string.IsNullOrEmpty(this._shipGdsPrimeListCndtn.Ed_GoodsMakerCd.ToString())))
                {
                    edCode = ct_Extr_End;
                }

                this.EditCondition(ref addConditions, string.Format("�������[�J�[" + ct_RangeConst, stCode, edCode));
            }

            // ���i�啪��
            if ((this._shipGdsPrimeListCndtn.St_GoodsLGroup != 0) ||
                ((this._shipGdsPrimeListCndtn.Ed_GoodsLGroup != 0) &&
                 (!string.IsNullOrEmpty(this._shipGdsPrimeListCndtn.Ed_GoodsLGroup.ToString()))))
            {
                stCode = this._shipGdsPrimeListCndtn.St_GoodsLGroup.ToString("0000");
                edCode = this._shipGdsPrimeListCndtn.Ed_GoodsLGroup.ToString("0000");

                if (this._shipGdsPrimeListCndtn.St_GoodsLGroup == 0) stCode = ct_Extr_Top;

                if ((this._shipGdsPrimeListCndtn.Ed_GoodsLGroup == 0) ||
                    (string.IsNullOrEmpty(this._shipGdsPrimeListCndtn.Ed_GoodsLGroup.ToString())))
                {
                    edCode = ct_Extr_End;
                }

                this.EditCondition(ref addConditions, string.Format("���i�啪��" + ct_RangeConst, stCode, edCode));
            }

            // ���i������
            if ((this._shipGdsPrimeListCndtn.St_GoodsMGroup != 0) ||
                ((this._shipGdsPrimeListCndtn.Ed_GoodsMGroup != 0) &&
                 (!string.IsNullOrEmpty(this._shipGdsPrimeListCndtn.Ed_GoodsMGroup.ToString()))))
            {
                stCode = this._shipGdsPrimeListCndtn.St_GoodsMGroup.ToString("0000");
                edCode = this._shipGdsPrimeListCndtn.Ed_GoodsMGroup.ToString("0000");

                if (this._shipGdsPrimeListCndtn.St_GoodsMGroup == 0) stCode = ct_Extr_Top;

                if ((this._shipGdsPrimeListCndtn.Ed_GoodsMGroup == 0) ||
                    (string.IsNullOrEmpty(this._shipGdsPrimeListCndtn.Ed_GoodsMGroup.ToString())))
                {
                    edCode = ct_Extr_End;
                }

                this.EditCondition(ref addConditions, string.Format("���i������" + ct_RangeConst, stCode, edCode));
            }
            
            // �O���[�v�R�[�h
            if ((this._shipGdsPrimeListCndtn.St_BLGroupCode != 0) ||
                ((this._shipGdsPrimeListCndtn.Ed_BLGroupCode != 0) &&
                 (!string.IsNullOrEmpty(this._shipGdsPrimeListCndtn.Ed_BLGroupCode.ToString()))))
            {
                stCode = this._shipGdsPrimeListCndtn.St_BLGroupCode.ToString("00000");
                edCode = this._shipGdsPrimeListCndtn.Ed_BLGroupCode.ToString("00000");

                if (this._shipGdsPrimeListCndtn.St_BLGroupCode == 0) stCode = ct_Extr_Top;

                if ((this._shipGdsPrimeListCndtn.Ed_BLGroupCode == 0) ||
                    (string.IsNullOrEmpty(this._shipGdsPrimeListCndtn.Ed_BLGroupCode.ToString())))
                {
                    edCode = ct_Extr_End;
                }

                this.EditCondition(ref addConditions, string.Format("�O���[�v�R�[�h" + ct_RangeConst, stCode, edCode));
            }

            // �a�k�R�[�h
            if ((this._shipGdsPrimeListCndtn.St_BLGoodsCode != 0) ||
                ((this._shipGdsPrimeListCndtn.Ed_BLGoodsCode != 0) &&
                 (!string.IsNullOrEmpty(this._shipGdsPrimeListCndtn.Ed_BLGoodsCode.ToString()))))
            {
                stCode = this._shipGdsPrimeListCndtn.St_BLGoodsCode.ToString("00000");
                edCode = this._shipGdsPrimeListCndtn.Ed_BLGoodsCode.ToString("00000");

                if (this._shipGdsPrimeListCndtn.St_BLGoodsCode == 0) stCode = ct_Extr_Top;

                if ((this._shipGdsPrimeListCndtn.Ed_BLGoodsCode == 0) ||
                    (string.IsNullOrEmpty(this._shipGdsPrimeListCndtn.Ed_BLGoodsCode.ToString())))
                {
                    edCode = ct_Extr_End;
                }

                this.EditCondition(ref addConditions, string.Format("�a�k�R�[�h" + ct_RangeConst, stCode, edCode));
            }

            // �ǉ�
            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }
        }

        /// <summary>
        /// ���o����������ҏW
        /// </summary>
        /// <param name="editArea">�i�[�G���A</param>
        /// <param name="target">�Ώە�����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.14</br>
        /// </remarks>
        private void EditCondition(ref StringCollection editArea, string target)
        {
            bool isEdit = false;

            // �ҏW�Ώە����o�C�g���Z�o
            int targetByte = TStrConv.SizeCountSJIS(target);

            for (int i = 0; i < editArea.Count; i++)
            {
                int areaByte = 0;

                // �i�[�G���A�̃o�C�g���Z�o
                if (editArea[i] != null)
                {
                    areaByte = TStrConv.SizeCountSJIS(editArea[i]);
                }

                if ((areaByte + targetByte + 2) <= 190)
                {
                    isEdit = true;

                    // �S�p�X�y�[�X��}��
                    if (editArea[i] != null) editArea[i] += ct_Space;

                    editArea[i] += target;
                    break;
                }
            }
            // �V�K�ҏW�G���A�쐬
            if (!isEdit)
            {
                editArea.Add(target);
            }
        }

        /// <summary>
        /// �i�[�G���A�ɕ�������E�񂹂Őݒ肷��
        /// </summary>
        /// <param name="editArea"></param>
        /// <param name="target"></param>
        private void EditConditionLetRight(ref StringCollection editArea, string target)
        {
            // �ҏW�Ώە����o�C�g���Z�o
            int targetByte = TStrConv.SizeCountSJIS(target);

            // ���݂�StringCollection�̃o�C�g�����擾
            int areaByte = TStrConv.SizeCountSJIS(editArea[editArea.Count - 1]);

            // �E�񂹂ɂȂ�܂�" "��ǉ�
            while (areaByte + targetByte <= 190)
            {
                editArea[editArea.Count - 1] += " ";
                areaByte = TStrConv.SizeCountSJIS(editArea[editArea.Count - 1]);
            }

            editArea[editArea.Count - 1] += target;
        }

        /// <summary>
        /// ���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�f�t�H���g�t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.14</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "PMHNB02143P", iMsg, iSt, iButton, iDefButton);
        }
        #endregion
    }
}
