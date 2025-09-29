using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;

using ar=DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using System.Drawing;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// ���[������ʕ��i�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note         : PM.NS�̋��ʎd�l�Ɋ�Â��A���[����̈�ʓI�Ȑ�����s���܂��B</br>
	/// <br>Programmer   : 22018 ��؁@���b</br>
	/// <br>Date         : 2009.02.06</br>
	/// <br></br>
	/// <br>Update Note  : 2009.04.22  22018 ��� ���b</br>
    /// <br>             : �@�@�O���[�v�T�v���X�Ή�������ǉ��B</br>
    /// <br>Update Note  : 2009.07.16  22018 ��� ���b</br>
    /// <br>             : �@�@�E�l�ߍ���(���l���ڂ�z��)�ŁA�擪���J���}(,)�̏ꍇ�͎�菜��������ǉ��B(",ZZZ,ZZ9"��"ZZZZ,ZZ9")</br>
    /// <br></br>
    /// <br>Update Note  : 2010/03/24  22018 ��� ���b</br>
    /// <br>             : �p�q�R�[�h�̈���@�\��ǉ��B</br>
    /// <br></br>
    /// <br>Update Note  : 2010/05/17  22018 ��� ���b</br>
    /// <br>             : �T�u���|�[�g�Ή��@�\��ǉ��B</br>
    /// <br></br>
    /// <br>Update Note  : 2010/06/29  22018 ��� ���b</br>
    /// <br>             : �������̃A�E�g�I�u�������G���[�Ή��B</br>
    /// <br></br>
    /// <br>Update Note  : 2010/10/04  22018 ��� ���b</br>
    /// <br>             : �󎚍��ڂ̑O���X�y�[�X���J�b�g����錏�̏C���B</br>
    /// <br></br>
    /// <br>Update Note  : 2011/01/13  30517 �Ė� �x��</br>
    /// <br>             : �䓌���i����l�ʑΉ�</br>
    /// <br>             : ���א������E���ו��ɓ`�[�v�s�̉��֌r���������iar.Control is Line�p�C�x���g���쐬�j</br>
    /// <br></br>
    /// <br>Update Note  : 2011/04/07  22018 ��� ���b</br>
    /// <br>             : ��ʒ��[�ł��g�p�ł���悤�Ή��B(�����ꗗ�\,����\��\�Ŏg�p)</br>
    /// </remarks>
	public class PMCMN02000CA
	{
        // DotPerInch
        private const decimal ct_DPI = 72;

        // static�C���X�^���X
        private static PMCMN02000CA _instance;
        // Shift-JIS�G���R�[�f�B���O
        private static Encoding _sjisEnc;

        // �R���g���[���������L�����Z���t���O
        private bool _initializeCancel;
        // �c�{�p�Ώۃ��X�g�i�O���p�����[�^�p�j
        private List<string> _doubleHeightTargetList;
        // �c�{�p�Ώۃf�B�N�V���i���i���������p�j
        private Dictionary<string, DoubleHeightTarget> _doubleHeightTargetdic;
        // �J�X�^���p���t���O
        private bool _customFormFlag = false;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
        // �O���[�v�T�v���X�敪
        private GroupSuppressDivState _groupSuppressDiv;
        // �O���[�v�T�v���X���[�h
        private GroupSuppressModeState _groupSuppressMode;
        // �O���[�v���ڃ��X�g
        private List<string> _groupingItemList;
        // �O���[�v�����O��l�f�B�N�V���i��
        private Dictionary<string, string> _prevGroupingItemValueDic;
        
        // �Z�N�V�����ʃR���g���[���ꗗ
        private Dictionary<string, List<ar.ARControl>> _arControlListDic;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
        // �p�q�R�[�h����T�C�Y�ꗗ
        private Dictionary<string, float> _qrCodeSizeDic;
        // �p�q�R�[�h����L���t���O
        private bool _qrCodeVisible;
        // --- ADD m.suzuki 2010/03/24 ----------<<<<<
        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
        // �T�u���|�[�g�Ώۃ��X�g(�Q�ƌ�)
        private List<string> _subReportTargetList;
        // �T�u���|�[�g�f�B�N�V���i��(�Q�Ɛ�)
        private Dictionary<string, ar.ActiveReport3> _subReportDic;
        // --- ADD m.suzuki 2010/05/17 ----------<<<<<

        # region [�v���p�e�B]
        /// <summary>
        /// �R���g���[���������L�����Z���t���O
        /// </summary>
        public bool InitializeCancel
        {
            get { return _initializeCancel; }
            set { _initializeCancel = value; }
        }
        /// <summary>
        /// �c�{�p�Ή����X�g
        /// </summary>
        public List<string> DoubleHeightTargetList
        {
            get { return _doubleHeightTargetList; }
            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
            //set { _doubleHeightTargetList = value; }
            set 
            {
                // List�������ς�鎞�ADic���N���A����B
                _doubleHeightTargetdic = null;

                // set
                _doubleHeightTargetList = value;
            }
            // --- UPD m.suzuki 2010/05/17 ----------<<<<<
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
        /// <summary>
        /// �O���[�v�T�v���X�敪
        /// </summary>
        public GroupSuppressDivState GroupSuppressDiv
        {
            get { return _groupSuppressDiv; }
            set { _groupSuppressDiv = value; }
        }
        /// <summary>
        /// �O���[�v�T�v���X���[�h
        /// </summary>
        public GroupSuppressModeState GroupSuppressMode
        {
            get { return _groupSuppressMode; }
            set { _groupSuppressMode = value; }
        }
        /// <summary>
        /// �O���[�v���ڃ��X�g�iGroupSuppressDiv=Normal�܂���FreePrint�̏ꍇ�L���j
        /// </summary>
        public List<string> GroupingItemList
        {
            get { return _groupingItemList; }
            set { _groupingItemList = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
        /// <summary>
        /// �p�q�R�[�h����T�C�Y�ꗗ
        /// </summary>
        public Dictionary<string, float> QrCodeSizeDic
        {
            get { return _qrCodeSizeDic; }
            set { _qrCodeSizeDic = value; }
        }
        /// <summary>
        /// �p�q�R�[�h�󎚗L��
        /// </summary>
        public bool QRCodeVisible
        {
            get { return _qrCodeVisible; }
            set { _qrCodeVisible = value; }
        }
        // --- ADD m.suzuki 2010/03/24 ----------<<<<<
        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
        /// <summary>
        /// �T�u���|�[�g�Ώۃ��X�g(�Q�ƌ�)
        /// </summary>
        /// <remarks>DataField���w��(�� FREEPRINT.SUBREPORT)</remarks>
        public List<string> SubReportTargetList
        {
            get { return _subReportTargetList; }
            set { _subReportTargetList = value; }
        }
        /// <summary>
        /// �T�u���|�[�g�f�B�N�V���i��(�Q�Ɛ�)
        /// </summary>
        /// <remarks>key:�t�H�[����(�� A999_b), value:�Ώۂ̃t�H�[��(�� A999_b�œo�^����Ă���Report)</remarks>
        public Dictionary<string,ar.ActiveReport3> SubReportDic
        {
            get { return _subReportDic; }
            set { _subReportDic = value; }
        }
        // --- ADD m.suzuki 2010/05/17 ----------<<<<<
        # endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
        # region [enum]
        # region [�O���[�v�T�v���X�敪]
        /// <summary>
        /// �O���[�v�T�v���X�敪�i�T�v���X�Ώۂ̎w��j
        /// </summary>
        public enum GroupSuppressDivState
        {
            /// <summary>0:�T�v���X���Ȃ�</summary>
            None = 0,
            /// <summary>1:�ʏ풠�[</summary>
            Normal = 1,
            /// <summary>2:���R���[</summary>
            FreePrint = 2,
        }
        /// <summary>
        /// �O���[�v�T�v���X���[�h�i�T�v���X���@�̎w��j
        /// </summary>
        public enum GroupSuppressModeState
        {
            /// <summary>�P��</summary>
            Single = 1,
            /// <summary>����(���������)</summary>
            Multi = 2,
        }
        # endregion
        // --- ADD m.suzuki 2010/00/00 ---------->>>>>
        /// <summary>
        /// ���|�[�g�v���p�e�B�ݒ���
        /// </summary>
        public enum SetReportPropsKind
        {
            /// <summary>���R���[</summary>
            FreePrint = 0,
            /// <summary>��ʒ��[</summary>
            NormalList = 1,
        }
        // --- ADD m.suzuki 2010/00/00 ----------<<<<<
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD

        # region [BeforePrintEditEventArgs]
        /// <summary>
        /// BeforePrintEditEventArgs
        /// </summary>
        public class BeforePrintEditEventArgs : EventArgs
        {
            private ar.Section _section;
            private ar.ARControl _control;
            private string _adjustedText;
            private bool _cancel;

            public ar.Section Section
            {
                get { return _section; }
            }
            public ar.ARControl Control
            {
                get { return _control; }
            }
            public string AdjustedText
            {
                get { return _adjustedText; }
                set { _adjustedText = value; }
            }
            public bool Cancel
            {
                get { return _cancel; }
                set { _cancel = value; }
            }
            public BeforePrintEditEventArgs( ar.Section section, ar.ARControl control, string adjustedText, bool cancel )
            {
                _section = section;
                _control = control;
                _adjustedText = adjustedText;
                _cancel = cancel;
            }
        }
        # endregion

        // 2011/01/13 Add >>>
        # region [BeforePrintEditLineEventArgs]
        /// <summary>
        /// BeforePrintEditLineEventArgs
        /// </summary>
        public class BeforePrintEditLineEventArgs : EventArgs
        {
            private ar.ARControl _control;
            private List<ar.ARControl> _arControlList;

            public ar.ARControl Control
            {
                get { return _control; }
            }
            public List<ar.ARControl> ControlList
            {
                get { return _arControlList; }
                set { _arControlList = value; }
            }
            public BeforePrintEditLineEventArgs(ar.ARControl control, List<ar.ARControl> controlList)
            {
                _control = control;
                _arControlList = controlList;
            }
        }
        # endregion
        // 2011/01/13 Add <<<

        # region [�C�x���g�f���Q�[�g��`]
        /// <summary>
        /// Edit����O�C�x���g�n���h��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void BeforePrintEditHandler( object sender, BeforePrintEditEventArgs e );

        // 2011/01/13 Add >>>
        /// <summary>
        /// EditLine����O�C�x���g�n���h��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void BeforePrintEditLineHandler( object sender, BeforePrintEditLineEventArgs e );
        // 2011/01/13 Add <<<
        # endregion

        # region [�C�x���g]
        /// <summary>
        /// Edit�󎚑O�C�x���g
        /// </summary>
        public event BeforePrintEditHandler BeforePrintEdit;

        // 2011/01/13 Add >>>
        /// <summary>
        /// EditLine�󎚑O�C�x���g
        /// </summary>
        public event BeforePrintEditLineHandler BeforePrintEditLine;
        // 2011/01/13 Add <<<
        # endregion

        # region [�R���X�g���N�^]
        /// <summary>
        /// private�R���X�g���N�^
        /// </summary>
        private PMCMN02000CA()
        {
            this.InitializeCancel = false;
            this.DoubleHeightTargetList = new List<string>();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
            this.GroupSuppressDiv = GroupSuppressDivState.None;
            this.GroupSuppressMode = GroupSuppressModeState.Multi;
            this.GroupingItemList = new List<string>();
            this._prevGroupingItemValueDic = new Dictionary<string, string>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
            // --- ADD m.suzuki 2010/03/24 ---------->>>>>
            this._qrCodeSizeDic = new Dictionary<string, float>();
            this._qrCodeVisible = true;
            // --- ADD m.suzuki 2010/03/24 ----------<<<<<
            // --- ADD m.suzuki 2010/05/17 ---------->>>>>
            this._subReportTargetList = new List<string>();
            this._subReportDic = new Dictionary<string, DataDynamics.ActiveReports.ActiveReport3>();
            // --- ADD m.suzuki 2010/05/17 ----------<<<<<
        }
        /// <summary>
        /// static �R���X�g���N�^
        /// </summary>
        static PMCMN02000CA()
        {
            // ��static���\�b�h�Ŏg�p����static�t�B�[���h�̏�����
            _sjisEnc = Encoding.GetEncoding( "Shift_JIS" );
        }
        # endregion

        # region [public���\�b�h]
        /// <summary>
        /// �C���X�^���X�擾����
        /// </summary>
        /// <returns></returns>
        public static PMCMN02000CA GetInstance()
        {
            if ( _instance == null )
            {
                _instance = new PMCMN02000CA();
            }
            // --- ADD m.suzuki 2010/06/29 ---------->>>>>
            _instance.Clear();
            // --- ADD m.suzuki 2010/06/29 ----------<<<<<
            return _instance;
        }

        /// <summary>
        /// ���[�ݒ菈��
        /// </summary>
        /// <param name="report"></param>
        public void SetReportProps( ref ar.ActiveReport3 report )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 DEL
            //// �c�{�p�Ώۂ������
            //if ( DoubleHeightTargetList != null && DoubleHeightTargetList.Count > 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 DEL
            {
                // ���|�[�g����J�n�C�x���g�n���h���o�^
                report.ReportStart += new EventHandler( report_ReportStart );

                // �A���p
                if ( report.PageSettings.PaperKind == PaperKind.Custom )
                {
                    _customFormFlag = true;
                }
                else
                {
                    _customFormFlag = false;
                }
            }

            // �S�ẴZ�N�V�����ɑ΂���
            foreach ( ar.Section section in report.Sections )
            {
                // �S�R���g���[���̃v���p�e�B���Z�b�g����
                foreach ( ar.ARControl control in section.Controls )
                {
                    if ( control is ar.TextBox )
                    {
                        ar.TextBox textBox = (control as ar.TextBox);
                        //----------------------------------------------
                        // �������s���Ȃ��̏ꍇ�́A
                        //   �܂�Ԃ����Ȃ��ɂ���B
                        //----------------------------------------------
                        if ( !textBox.MultiLine )
                        {
                            textBox.WordWrap = false;
                        }
                    }
                }

                // ����O�C�x���g�n���h����o�^����B
                section.BeforePrint += new EventHandler( section_BeforePrint );
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
            // �O���[�v�T�v���X����ꍇ�̓T�v���X�����p�ɃC�x���g�n���h���o�^����
            if ( GroupSuppressDiv != GroupSuppressDivState.None )
            {
                report.PageEnd += new EventHandler( report_PageEnd );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
        }
        // --- ADD m.suzuki 2010/00/00 ---------->>>>>
        /// <summary>
        /// ���[�ݒ菈��(ALL)
        /// </summary>
        /// <param name="report"></param>
        public void SetReportProps( ref ar.ActiveReport3 report, SetReportPropsKind kind )
        {
            switch ( kind )
            {
                case SetReportPropsKind.FreePrint:
                    {
                        // ���R���[
                        SetReportProps( ref report );
                    }
                    break;
                case SetReportPropsKind.NormalList:
                    {
                        // ��ʒ��[
                        SetReportPropsForNormalList( ref report );
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// ���[�ݒ菈��(��ʒ��[�p)
        /// </summary>
        /// <param name="report"></param>
        /// <remarks>����ʒ��[�ɕK�v�ȋ@�\�����Ɍ��肵�A�������x�ւ̉e����}���܂��B</remarks>
        private void SetReportPropsForNormalList( ref DataDynamics.ActiveReports.ActiveReport3 report )
        {
            // �S�ẴZ�N�V�����ɑ΂���
            foreach ( ar.Section section in report.Sections )
            {
                // ����O�C�x���g�n���h����o�^����B
                section.BeforePrint += new EventHandler( normalListSection_BeforePrint );
            }
        }
        // --- ADD m.suzuki 2010/00/00 ----------<<<<<
        // --- ADD m.suzuki 2010/06/29 ---------->>>>>
        /// <summary>
        /// �����ێ����̃N���A
        /// </summary>
        public void Clear()
        {
            _prevGroupingItemValueDic = null;
            _arControlListDic = null;
        }
        // --- ADD m.suzuki 2010/06/29 ----------<<<<<

        /// <summary>
        /// ����\�o�C�g���̎擾�i�O�����J�p�j
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="minCount"></param>
        /// <param name="maxCount"></param>
        public static void GetPrintableByteCount( ar.TextBox textBox, out int minCount, out int maxCount )
        {
            if ( textBox.CharacterSpacing == 0 )
            {
                // �����Ԋu���[���̏ꍇ
                int count = (int)(((decimal)textBox.Width) / ((decimal)textBox.Font.SizeInPoints / 2.0m / ct_DPI));
                minCount = count;
                maxCount = count;
            }
            else
            {
                // �����Ԋu���[���̏ꍇ

                // �S�Ĕ��p���o�C�g��������̕��������������]���̐�������������\�o�C�g���F��
                minCount = (int)(((decimal)textBox.Width + (decimal)textBox.CharacterSpacing / ct_DPI) / ((decimal)textBox.Font.SizeInPoints / 2.0m / ct_DPI + (decimal)textBox.CharacterSpacing / ct_DPI));

                // �S�đS�p���o�C�g��������̕����������Ȃ����]���̐������Ȃ�������\�o�C�g���F��
                maxCount = (int)((((decimal)textBox.Width + (decimal)textBox.CharacterSpacing / ct_DPI) / ((decimal)textBox.Font.SizeInPoints / ct_DPI + (decimal)textBox.CharacterSpacing / ct_DPI)) * 2);
            }
        }
        # endregion

        # region [���|�[�g�I�u�W�F�N�g�ɑ΂��č������ރC�x���g�n���h���֘A�i���R���[�p�j]
        /// <summary>
        /// ���|�[�g����J�n�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void report_ReportStart( object sender, EventArgs e )
        {
            // �Ώۃf�B�N�V���i������
            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
            //_doubleHeightTargetdic = new Dictionary<string, DoubleHeightTarget>();
            if ( _doubleHeightTargetdic == null )
            {
                _doubleHeightTargetdic = new Dictionary<string, DoubleHeightTarget>();
            }
            // --- UPD m.suzuki 2010/05/17 ----------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
            _prevGroupingItemValueDic = new Dictionary<string, string>();
            // --- DEL m.suzuki 2010/05/17 ---------->>>>>
            //_arControlListDic = new Dictionary<string, List<DataDynamics.ActiveReports.ARControl>>();
            // --- DEL m.suzuki 2010/05/17 ----------<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
            // --- ADD m.suzuki 2010/05/17 ---------->>>>>
            // �T�u���|�[�g�Ή��p���X�g������
            List<ar.Label> subReportLabelList = new List<ar.Label>();
            List<ar.SubReport> subReportList = new List<ar.SubReport>();
            // --- ADD m.suzuki 2010/05/17 ----------<<<<<

            try
            {
                // �S�ẴZ�N�V�����ɑ΂��ď���
                foreach ( ar.Section section in (sender as ar.ActiveReport3).Sections )
                {
                    # region [�Z�N�V�����ɑ΂��鑀��]
                    // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
                    //// �Z�N�V�������̑ΏۃR���g���[�����X�g����
                    //_arControlListDic.Add( section.Name, new List<DataDynamics.ActiveReports.ARControl>() );
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
                    if ( _arControlListDic == null )
                    {
                        _arControlListDic = new Dictionary<string, List<DataDynamics.ActiveReports.ARControl>>();
                    }
                    // �Z�N�V������GUID��t�^����
                    section.Tag = Guid.NewGuid();
                    string sectionKey = section.Tag.ToString();
                    _arControlListDic.Add( sectionKey, new List<DataDynamics.ActiveReports.ARControl>() );
                    // --- UPD m.suzuki 2010/05/17 ----------<<<<<

                    foreach ( ar.ARControl control in section.Controls )
                    {
                        # region [�Z�N�V�������̃R���g���[���ւ̑���]
                        if ( control is ar.TextBox )
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
                            // ����
                            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                            //_arControlListDic[section.Name].Add( control );
                            _arControlListDic[sectionKey].Add( control );
                            // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD

                            // --- ADD m.suzuki 2010/00/00 ---------->>>>>
                            // �f�[�^�t�B�[���h���ݒ�Ȃ�ΉI��
                            if ( string.IsNullOrEmpty( control.DataField ) ) continue;
                            // --- ADD m.suzuki 2010/00/00 ----------<<<<<

                            // �c�{�p�Ή�
                            # region [�c�{�p�Ή�]
                            if ( _doubleHeightTargetList.Contains( control.DataField.ToUpper() ) )
                            {
                                // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                                //if ( !_doubleHeightTargetdic.ContainsKey( control.Name ) )
                                string doubleHeightTargetKey = CreateDoubleHeightTargetKey( sectionKey, control.Name );
                                if ( !_doubleHeightTargetdic.ContainsKey( doubleHeightTargetKey ) )
                                // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                                {
                                    // �c�{�p�Ή����邽�߂̏��𐶐����đޔ�����
                                    DoubleHeightTarget target = new DoubleHeightTarget();

                                    target.DataField = control.DataField;
                                    target.ParentSection = section;
                                    target.TargetTextBox = (ar.TextBox)control;
                                    
                                    target.DoubleHeightPicture = new DataDynamics.ActiveReports.Picture();
                                    target.DoubleHeightPicture.PictureAlignment = DataDynamics.ActiveReports.PictureAlignment.TopLeft;
                                    target.DoubleHeightPicture.Location = target.TargetTextBox.Location;
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
                                    target.DoubleHeightPicture.Visible = false;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD
                                    
                                    target.DoubleHeightPicture.Size = target.TargetTextBox.Size;
                                    // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                                    //_doubleHeightTargetdic.Add( control.Name, target );
                                    _doubleHeightTargetdic.Add( doubleHeightTargetKey, target );
                                    // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                                }
                            }
                            # endregion

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
                            // �O���[�v�T�v���X�Ή�(���R���[)
                            # region [�O���[�v�T�v���X�Ή�(���R���[)]
                            if ( GroupSuppressDiv == GroupSuppressDivState.FreePrint )
                            {
                                // �T�v���X�Ώۃ��X�g�ɒǉ�����
                                FrePControlTag tag = new FrePControlTag( control.Tag );
                                if ( tag.GroupSuppressCd == 1 && !_groupingItemList.Contains( control.Name ) )
                                {
                                    _groupingItemList.Add( control.Name );
                                }
                            }
                            # endregion
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
                        }
                        // --- ADD m.suzuki 2010/03/24 ---------->>>>>
                        else if ( control is ar.Barcode )
                        {
                            if ( _qrCodeVisible )
                            {
                                control.Visible = true;

                                // PM7�̈�����ʂɍ��킹��ׂɉ��L�̒ʂ�Z�b�g����i�捞�݌��ʂ͕ς��Ȃ��j
                                (control as ar.Barcode).QRCode.ErrorLevel = DataDynamics.ActiveReports.Options.QRCodeErrorLevel.M;
                                (control as ar.Barcode).QRCode.Mask = DataDynamics.ActiveReports.Options.QRCodeMask.Mask101;
                                (control as ar.Barcode).QRCode.Model = DataDynamics.ActiveReports.Options.QRCodeModel.Model2;

                                // QR�R�[�h�̃T�C�Y����
                                string dataField = control.DataField.ToUpper();
                                if ( _qrCodeSizeDic.ContainsKey( dataField ) )
                                {
                                    // X * Y �Ȃ̂ŗ��̓��[�g�����߂�
                                    float sizeRate = (float)Math.Pow( _qrCodeSizeDic[dataField], 0.5 );
                                    control.Size = new SizeF( control.Size.Width * sizeRate, control.Size.Height * sizeRate );
                                }
                            }
                            else
                            {
                                // QR���ނ��󎚂��Ȃ�
                                control.Visible = false;
                            }
                        }
                        // --- ADD m.suzuki 2010/03/24 ----------<<<<<
                        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                        else if ( control is ar.Label )
                        {
                            # region [�T�u���|�[�g�Ή�]
                            if ( _subReportTargetList != null && _subReportDic != null && control.DataField != null )
                            {
                                if ( _subReportTargetList.Contains( control.DataField.ToUpper() ) )
                                {
                                    ar.Label orgLabel = (control as ar.Label);

                                    string[] param = orgLabel.Text.Split( ',' );
                                    if ( param.Length > 0 )
                                    {
                                        string formName = param[0];

                                        if ( _subReportDic.ContainsKey( formName ) )
                                        {
                                            ar.SubReport newSubReport = new ar.SubReport();

                                            // �T�u���|�[�g�Ƀo�C���h���郌�|�[�g���w��
                                            newSubReport.Report = _subReportDic[formName];
                                            // �f�[�^�\�[�X���w��(�e�̃��|�[�g�Ɠ����ɂ���)
                                            newSubReport.Report.DataSource = (sender as ar.ActiveReport3).DataSource;
                                            newSubReport.Report.DataMember = (sender as ar.ActiveReport3).DataMember;

                                            // �T�C�Y���f�U�C���p�̃��x���ɍ��킹��
                                            newSubReport.Width = orgLabel.Width;
                                            newSubReport.Height = orgLabel.Height;
                                            newSubReport.Top = orgLabel.Top;
                                            newSubReport.Left = orgLabel.Left;

                                            // �Œ�ŃZ�b�g�K�v�ȃv���p�e�B
                                            newSubReport.CanGrow = false;
                                            newSubReport.CanShrink = false;

                                            // �ޔ����Ă���
                                            subReportLabelList.Add( orgLabel );
                                            subReportList.Add( newSubReport );
                                        }
                                    }
                                }
                            }
                            # endregion
                        }
                        // --- ADD m.suzuki 2010/05/17 ----------<<<<<
                        // 2011/01/13 Add >>>
                        else if (control is ar.Line)
                        {
                            _arControlListDic[sectionKey].Add(control);
                        }
                        // 2011/01/13 Add <<<
                        # endregion
                    }

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
                    // �Z�N�V�����ʂ̃��X�g���\�[�g
                    if ( GroupSuppressMode != GroupSuppressModeState.Single )
                    {
                        // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                        //_arControlListDic[section.Name].Sort( new ARControlComparer() );
                        _arControlListDic[sectionKey].Sort( new ARControlComparer() );
                        // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
                    # endregion
                }

                # region [�R���N�V�����ɑ΂��Ĉꊇ����]
                // �c�{�p�Ή�
                foreach ( DoubleHeightTarget target in _doubleHeightTargetdic.Values )
                {
                    target.ParentSection.Controls.Add( target.DoubleHeightPicture );
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
                    // �Ŕw�ʂւƈڂ�(PDF�o�͎��ɔw�i�F=�����ɂȂ�Ȃ���)
                    target.DoubleHeightPicture.SendToBack();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
                // �O���[�v�T�v���X�Ή�
                foreach ( string groupingItemName in _groupingItemList )
                {
                    // �T�v���X�p�O��l�ޔ��f�B�N�V���i���ɒǉ�
                    _prevGroupingItemValueDic.Add( groupingItemName, string.Empty );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
                // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                // �T�u���|�[�g�֒u������
                for ( int index = 0; index < subReportLabelList.Count; index++ )
                {
                    ar.Section section = (subReportLabelList[index].Parent as ar.Section);
                    section.Controls.Add( subReportList[index] );
                    section.Controls.Remove( subReportLabelList[index] );
                }
                // --- ADD m.suzuki 2010/05/17 ----------<<<<<
                # endregion
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
        /// <summary>
        /// �c�{�p���ڃL�[��������
        /// </summary>
        /// <param name="sectionKey"></param>
        /// <param name="controlName"></param>
        /// <returns></returns>
        private static string CreateDoubleHeightTargetKey( string sectionKey, string controlName )
        {
            return string.Format( "{0}-{1}", sectionKey, controlName );
        }
        // --- ADD m.suzuki 2010/05/17 ----------<<<<<
        /// <summary>
        /// ���[�Z�N�V��������O�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void section_BeforePrint( object sender, EventArgs e )
        {
            if ( sender == null || (sender is ar.Section) == false ) return;

            ar.Section section = (sender as ar.Section);

            // --- ADD m.suzuki 2010/05/17 ---------->>>>>
            string sectionKey = (sender as ar.Section).Tag.ToString();
            if ( !_arControlListDic.ContainsKey( sectionKey ) ) return;
            // --- ADD m.suzuki 2010/05/17 ----------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 DEL
            //foreach ( ar.ARControl control in section.Controls )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
            bool prevItemSuppress = true;
            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
            //foreach ( ar.ARControl control in _arControlListDic[section.Name] )
            foreach ( ar.ARControl control in _arControlListDic[sectionKey] )
            // --- UPD m.suzuki 2010/05/17 ----------<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
            {
                if ( control is ar.TextBox )
                {
                    try
                    {
                        ar.TextBox textBox = (control as ar.TextBox);

                        string text = textBox.Text;
                        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                        if ( text == null )
                        {
                            text = string.Empty;
                        }
                        // --- ADD m.suzuki 2010/05/17 ----------<<<<<

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
                        bool checkResult = false;

                        # region [�O���[�v�T�v���X�`�F�b�N]
                        // �O���[�v�T�v���X�Ώۂ̏ꍇ�̂݁A�T�v���X�`�F�b�N�Ǝ����ڂׂ̈̃`�F�b�N���ʑޔ����s��
                        if ( _groupingItemList.Contains( textBox.Name ) )
                        {
                            // �T�v���X�`�F�b�N
                            checkResult = (CheckGroupSuppress( textBox ) && (prevItemSuppress));

                            // �T�v���X���[�h���}���`�̏ꍇ�́A�����ڂׂ̈Ƀ`�F�b�N���ʂ�ޔ�
                            if ( GroupSuppressMode == GroupSuppressModeState.Multi )
                            {
                                prevItemSuppress = checkResult;
                            }
                        }
                        # endregion

                        // �T�v���Xor��
                        if ( checkResult )
                        {
                            // �T�v���X
                            textBox.Text = string.Empty;
                        }
                        else
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
                        {
                            # region [�����ӂ�Ή�(Text��������)]
                            string format = textBox.OutputFormat;
                            switch ( format )
                            {
                                # region [�R�[�h�����Ή�]
                                case "0":
                                    text = text.Substring( text.Length - 1, 1 );
                                    break;
                                case "00":
                                    text = text.Substring( text.Length - 2, 2 );
                                    break;
                                case "000":
                                    text = text.Substring( text.Length - 3, 3 );
                                    break;
                                case "0000":
                                    text = text.Substring( text.Length - 4, 4 );
                                    break;
                                case "00000":
                                    text = text.Substring( text.Length - 5, 5 );
                                    break;
                                case "000000":
                                    text = text.Substring( text.Length - 6, 6 );
                                    break;
                                case "0000000":
                                    text = text.Substring( text.Length - 7, 7 );
                                    break;
                                case "00000000":
                                    text = text.Substring( text.Length - 8, 8 );
                                    break;
                                case "000000000":
                                    text = text.Substring( text.Length - 9, 9 );
                                    break;
                                # endregion

                                # region[��ʌ����ӂ�Ή�]
                                default:
                                    {
                                        text = GetPrintableText( textBox );
                                    }
                                    break;
                                # endregion
                            }

                            bool cancel = false;
                            # region [�ύX�O�C�x���g����]
                            if ( this.BeforePrintEdit != null )
                            {
                                // �C�x���g��������
                                BeforePrintEditEventArgs args = new BeforePrintEditEventArgs( section, control, text, false );

                                // �C�x���g����
                                this.BeforePrintEdit( sender, args );

                                // �C�x���g���ʔ��f
                                text = args.AdjustedText;
                                cancel = args.Cancel;
                            }
                            # endregion

                            // �e�L�X�g��������
                            if ( !cancel )
                            {
                                textBox.Text = text;
                            }
                            # endregion

                            // �c�{�p�Ή�
                            # region [�c�{�p�Ή�]
                            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                            //if ( _doubleHeightTargetdic != null && _doubleHeightTargetdic.ContainsKey( control.Name ) )
                            string doubleHeightTargetKey = CreateDoubleHeightTargetKey( sectionKey, control.Name );
                            if ( _doubleHeightTargetdic != null && _doubleHeightTargetdic.ContainsKey( doubleHeightTargetKey ) )
                            // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                            {
                                // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                                //DoubleHeightTarget target = _doubleHeightTargetdic[control.Name];
                                DoubleHeightTarget target = _doubleHeightTargetdic[doubleHeightTargetKey];
                                // --- UPD m.suzuki 2010/05/17 ----------<<<<<

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
                                if ( !string.IsNullOrEmpty( target.TargetTextBox.Text ) )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD
                                {
                                    target.DoubleHeightPicture.Image = GetDoubleHeightImage( target.TargetTextBox );
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                                    target.DoubleHeightPicture.PictureAlignment = GetPictureAlignment( target.TargetTextBox );
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                                    target.DoubleHeightPicture.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom;
                                    target.DoubleHeightPicture.Visible = true;
                                    target.TargetTextBox.Visible = false;
                                }
                            }
                            # endregion
                        }
                    }
                    catch
                    {
                        // �o�C���h�悪DBNull.Value�̍��ڂ�catch
                    }
                }
                // 2011/01/13 Add >>>
                if (control is ar.Line)
                {
                    try
                    {
                        if (this.BeforePrintEditLine != null)
                        {
                            BeforePrintEditLineEventArgs args = new BeforePrintEditLineEventArgs(control, _arControlListDic[sectionKey]);

                            this.BeforePrintEditLine(sender, args);
                        }
                    }
                    catch
                    {
                    }
                }
                // 2011/01/13 Add <<<
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
        /// <summary>
        /// ���|�[�g�y�[�W�I���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void report_PageEnd( object sender, EventArgs e )
        {
            try
            {
                // �S�Ă̑O��l���N���A����(�T�v���X�̉���)
                List<string> keyList = new List<string>();

                foreach ( string key in _prevGroupingItemValueDic.Keys )
                {
                    keyList.Add( key );
                }
                foreach ( string key in keyList )
                {
                    _prevGroupingItemValueDic[key] = string.Empty;
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show( ex.Message );
            }
        }
        /// <summary>
        /// �O���[�v�T�v���X�`�F�b�N����
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>true: �O���[�v������ / false: �O���[�v�����Ȃ�</returns>
        private bool CheckGroupSuppress( DataDynamics.ActiveReports.TextBox textBox )
        {
            if ( _prevGroupingItemValueDic.ContainsKey( textBox.Name ) )
            {
                // �O��l�擾
                string prevText = _prevGroupingItemValueDic[textBox.Name];

                // ���ݒl��O��l�Ƃ��đޔ�
                _prevGroupingItemValueDic[textBox.Name] = textBox.Text;


                // �O��l�Ɣ�r
                return (textBox.Text == prevText);
            }
            else
            {
                // �T�v���X�ΏۊO
                return false;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
        /// <summary>
        /// �C���[�W�z�u�ʒu�擾�i�x�[�X�ɂȂ�e�L�X�g�{�b�N�X�̔z�u�ʒu����ϊ��j
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        private static DataDynamics.ActiveReports.PictureAlignment GetPictureAlignment( DataDynamics.ActiveReports.TextBox textBox )
        {
            switch ( textBox.Alignment )
            {
                // ��
                default:
                case DataDynamics.ActiveReports.TextAlignment.Left:
                    {
                        return DataDynamics.ActiveReports.PictureAlignment.BottomLeft;
                    }
                // �E
                case DataDynamics.ActiveReports.TextAlignment.Right:
                    {
                        return DataDynamics.ActiveReports.PictureAlignment.BottomRight;
                    }
                // ����
                case DataDynamics.ActiveReports.TextAlignment.Center:
                case DataDynamics.ActiveReports.TextAlignment.Justify:
                    {
                        return DataDynamics.ActiveReports.PictureAlignment.Center;
                    }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

        /// <summary>
        /// �c�{�p����pBmp��������
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        private Image GetDoubleHeightImage(ar.TextBox textBox)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
            # region // DEL
            //int size = 8; // �h�b�g���ׂ�������׈���t�H���g��8�{�T�C�Y��bmp�쐬����
            //Font font = new Font( textBox.Font.FontFamily, textBox.Font.SizeInPoints * size ); 

            //decimal sizeRate = 100.0m / ct_DPI;

            //string text = textBox.Text;

            //// ����
            //Bitmap bmp = new Bitmap( (int)((decimal)font.SizeInPoints / 2.0m * (decimal)(_sjisEnc.GetByteCount( text ) + 1) * sizeRate), (int)((decimal)font.SizeInPoints * sizeRate) );
            //Graphics g = Graphics.FromImage( bmp );

            //// �`��
            //g.DrawString( text, font, new SolidBrush( textBox.ForeColor ), new PointF( 0, 0 ) );

            //// �c�{�p
            //Bitmap newBmp = new Bitmap( (int)bmp.Size.Width, (int)(bmp.Size.Height * 2.0m ) );
            //g = Graphics.FromImage( newBmp );
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            //g.DrawImage( bmp, 0, 0, newBmp.Size.Width, newBmp.Size.Height );
            # endregion
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            int size = 8; // �h�b�g���ׂ�������׈���t�H���g��8�{�T�C�Y��bmp�쐬����

            Font font;
            if ( _customFormFlag )
            {
                // �A���̏ꍇ�͋����I��Bold�ɂ���
                font = new Font( textBox.Font.FontFamily, textBox.Font.SizeInPoints * size, textBox.Font.Style | FontStyle.Bold );
            }
            else
            {
                // �ʏ�͂��̂܂�
                font = new Font( textBox.Font.FontFamily, textBox.Font.SizeInPoints * size, textBox.Font.Style );
            }

            decimal sizeRate = 100.0m / ct_DPI;

            string text = textBox.Text;

            // ����
            int bmpWidth = (int)((decimal)font.SizeInPoints / 2.0m * (decimal)(_sjisEnc.GetByteCount( text ) + 1) * sizeRate);
            int bmpHeight = (int)((decimal)font.SizeInPoints * sizeRate);
            Bitmap bmp = new Bitmap( bmpWidth, bmpHeight );
            Graphics g = Graphics.FromImage( bmp );

            // �`��
            g.DrawString( text, font, new SolidBrush( textBox.ForeColor ), new PointF( 0, 0 ) );

            // �c�{�p
            Bitmap newBmp = new Bitmap( (int)bmp.Size.Width, (int)(bmp.Size.Height * 2.0m) );
            g = Graphics.FromImage( newBmp );
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage( bmp, 0, 0, newBmp.Size.Width, newBmp.Size.Height );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

            return newBmp;
        }
        /// <summary>
        /// ����\�e�L�X�g�擾����
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        private static string GetPrintableText( DataDynamics.ActiveReports.TextBox textBox )
        {
            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
            //string originText = textBox.Text.Trim();
            string originText;
            if ( textBox.Text != null )
            {
                // --- UPD m.suzuki 2010/10/04 ---------->>>>>
                //originText = textBox.Text.Trim();
                originText = textBox.Text.TrimEnd();
                // --- UPD m.suzuki 2010/10/04 ----------<<<<<
            }
            else
            {
                originText = string.Empty;
            }
            // --- UPD m.suzuki 2010/05/17 ----------<<<<<
            
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
            if ( textBox.WordWrap == true && textBox.MultiLine == true )
            {
                // �����s�E�����Ԋu����̏ꍇ�͐��䂪�s�\�Ȃ̂ŁA�����Ԋu���[���ɂ���B
                textBox.CharacterSpacing = 0;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD


            if ( textBox.CharacterSpacing == 0 )
            {
                //------------------------------------------------------------------------------
                // �������Ԋu���[���Ȃ�΁A�����o�C�g���Ŋ��邾���łn�j
                //------------------------------------------------------------------------------
                // ����\������(�o�C�g�P��)
                int printableCount = (int)(((decimal)textBox.Width) / ((decimal)textBox.Font.SizeInPoints / 2.0m / ct_DPI));

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
                // �����s���
                if ( textBox.WordWrap == true && textBox.MultiLine == true )
                {
                    int printableLines = (int)(((decimal)textBox.Height) / ((decimal)textBox.Font.SizeInPoints / ct_DPI));
                    if ( printableLines >= 1 )
                    {
                        printableCount *= printableLines;
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

                // �o�C�g����؂�
                switch ( textBox.Alignment )
                {
                    case DataDynamics.ActiveReports.TextAlignment.Center:
                    case DataDynamics.ActiveReports.TextAlignment.Left:
                        // Left
                        originText = SubStringOfByteLeft( originText, printableCount );
                        break;
                    case DataDynamics.ActiveReports.TextAlignment.Right:
                        // Right
                        originText = SubStringOfByteRight( originText, printableCount );
                        break;
                    case DataDynamics.ActiveReports.TextAlignment.Justify:
                    default:
                        // �����Ȃ�
                        break;
                }
            }
            else
            {
                //------------------------------------------------------------------------------
                // �������Ԋu���[���ȊO�Ȃ�΁A�P���������؂���
                //------------------------------------------------------------------------------

                // �o�C�g����؂�
                switch ( textBox.Alignment )
                {
                    case DataDynamics.ActiveReports.TextAlignment.Center:
                    case DataDynamics.ActiveReports.TextAlignment.Left:
                        // Left
                        {
                            # region [LEFT]
                            string resultString = string.Empty;
                            for ( int index = 1; index <= originText.Length; index++ )
                            {
                                string subString = originText.Substring( 0, index );
                                decimal checkWidth = _sjisEnc.GetByteCount( subString ) * (decimal)textBox.Font.SizeInPoints / 2.0m / ct_DPI
                                                     + (index - 1) * (decimal)textBox.CharacterSpacing / ct_DPI;
                                if ( checkWidth <= (decimal)textBox.Width )
                                {
                                    resultString = subString;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            originText = resultString.TrimEnd();
                            # endregion
                        }
                        break;
                    case DataDynamics.ActiveReports.TextAlignment.Right:
                        // Right
                        {
                            # region [RIGHT]
                            string resultString = string.Empty;
                            for ( int index = 1; index <= originText.Length; index++ )
                            {
                                string subString = originText.Substring( originText.Length - index, index );
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
                                if ( subString.Substring( 0, 1 ) == "," && index > 0 )
                                {
                                    subString = originText.Substring( originText.Length - index - 1, 1 )
                                                + subString.Substring( 1, subString.Length - 1 );
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD
                                decimal checkWidth = _sjisEnc.GetByteCount( subString ) * (decimal)textBox.Font.SizeInPoints / 2.0m / ct_DPI
                                                     + (index - 1) * (decimal)textBox.CharacterSpacing / ct_DPI;
                                if ( checkWidth <= (decimal)textBox.Width )
                                {
                                    resultString = subString;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            originText = resultString.TrimStart();
                            # endregion
                        }
                        break;
                    case DataDynamics.ActiveReports.TextAlignment.Justify:
                    default:
                        // �����Ȃ�
                        break;
                }
            }

            return originText;
        }
        /// <summary>
        /// ������@�o�C�g���w��؂蔲���iLeft [12345]678��12345�j
        /// </summary>
        /// <param name="orgString">���̕�����</param>
        /// <param name="byteCount">�o�C�g��</param>
        /// <returns>�w��o�C�g���Ő؂蔲����������</returns>
        private static string SubStringOfByteLeft( string orgString, int byteCount )
        {
            string resultString = string.Empty;

            // ���炩���߁u�������v���w�肵�Đ؂蔲���Ă���
            // (���̒i�K��byte����<������>�`2*<������>�̊ԂɂȂ�)
            // --- UPD m.suzuki 2010/10/04 ---------->>>>>
            //orgString = orgString.Trim().PadRight( byteCount ).Substring( 0, byteCount );
            orgString = orgString.TrimEnd().PadRight( byteCount ).Substring( 0, byteCount );
            // --- UPD m.suzuki 2010/10/04 ----------<<<<<

            int count;

            for ( int i = orgString.Length; i >= 0; i-- )
            {
                // �u�������v�����炷
                resultString = orgString.Substring( 0, i );

                // �o�C�g�����擾���Ĕ���
                count = _sjisEnc.GetByteCount( resultString );
                if ( count <= byteCount ) break;
            }
            return resultString.TrimEnd();
        }
        /// <summary>
        /// ������@�o�C�g���w��؂蔲���iRight 123[45678]��45678�j
        /// </summary>
        /// <param name="orgString">���̕�����</param>
        /// <param name="byteCount">�o�C�g��</param>
        /// <returns>�w��o�C�g���Ő؂蔲����������</returns>
        private static string SubStringOfByteRight( string orgString, int byteCount )
        {
            string resultString = string.Empty;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 DEL
            //// ���炩���߁u�������v���w�肵�Đ؂蔲���Ă���
            //// (���̒i�K��byte����<������>�`2*<������>�̊ԂɂȂ�)
            //orgString = orgString.Trim().PadLeft( byteCount );
            //orgString = orgString.Substring( orgString.Length - byteCount, byteCount );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
            // �擪�̃J���}����菜���ꍇ���l�����āA�P���������c���Ă���
            // --- UPD m.suzuki 2010/10/04 ---------->>>>>
            //orgString = orgString.Trim().PadLeft( byteCount + 1 );
            orgString = orgString.TrimEnd().PadLeft( byteCount + 1 );
            // --- UPD m.suzuki 2010/10/04 ----------<<<<<
            orgString = orgString.Substring( orgString.Length - byteCount - 1, byteCount + 1 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

            int count;

            for ( int i = orgString.Length; i >= 0; i-- )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 DEL
                //// �u�������v�����炷
                //resultString = orgString.Substring( orgString.Length - i, i );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
                if ( orgString.Substring( orgString.Length - i, 1 ) != "," || i == 0 )
                {
                    // �u�������v�����炷
                    resultString = orgString.Substring( orgString.Length - i, i );
                }
                else
                {
                    // �J���}������
                    resultString = orgString.Substring( (orgString.Length - i) - 1, 1 )
                                    + orgString.Substring( (orgString.Length - i) + 1, (i - 1) );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD

                // �o�C�g�����擾���Ĕ���
                count = _sjisEnc.GetByteCount( resultString );
                if ( count <= byteCount ) break;
            }
            return resultString.TrimStart();
        }
        # endregion

        # region [���|�[�g�I�u�W�F�N�g�ɑ΂��č������ރC�x���g�n���h���֘A�i�񎩗R���[�p�j]
        /// <summary>
        /// �Z�N�V��������O����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>��ʒ��[�p�̏����݂̂ɂ��鎖�ŁA�������Ԃւ̉e����}����</remarks>
        private void normalListSection_BeforePrint( object sender, EventArgs e )
        {
            if ( sender == null || (sender is ar.Section) == false ) return;

            ar.Section section = (sender as ar.Section);

            foreach ( ar.ARControl control in section.Controls )
            {
                if ( control is ar.TextBox )
                {
                    try
                    {
                        ar.TextBox textBox = (control as ar.TextBox);

                        string text = textBox.Text;
                        if ( text == null )
                        {
                            text = string.Empty;
                        }

                        # region [�����ӂ�Ή�(Text��������)]
                        string format = textBox.OutputFormat;
                        switch ( format )
                        {
                            # region [�R�[�h�����Ή�]
                            case "0":
                                text = text.Substring( text.Length - 1, 1 );
                                break;
                            case "00":
                                text = text.Substring( text.Length - 2, 2 );
                                break;
                            case "000":
                                text = text.Substring( text.Length - 3, 3 );
                                break;
                            case "0000":
                                text = text.Substring( text.Length - 4, 4 );
                                break;
                            case "00000":
                                text = text.Substring( text.Length - 5, 5 );
                                break;
                            case "000000":
                                text = text.Substring( text.Length - 6, 6 );
                                break;
                            case "0000000":
                                text = text.Substring( text.Length - 7, 7 );
                                break;
                            case "00000000":
                                text = text.Substring( text.Length - 8, 8 );
                                break;
                            case "000000000":
                                text = text.Substring( text.Length - 9, 9 );
                                break;
                            # endregion

                            # region[��ʌ����ӂ�Ή�]
                            default:
                                {
                                    text = GetPrintableText( textBox );
                                }
                                break;
                            # endregion
                        }

                        bool cancel = false;
                        # region [�ύX�O�C�x���g����]
                        if ( this.BeforePrintEdit != null )
                        {
                            // �C�x���g��������
                            BeforePrintEditEventArgs args = new BeforePrintEditEventArgs( section, control, text, false );

                            // �C�x���g����
                            this.BeforePrintEdit( sender, args );

                            // �C�x���g���ʔ��f
                            text = args.AdjustedText;
                            cancel = args.Cancel;
                        }
                        # endregion

                        // �e�L�X�g��������
                        if ( !cancel )
                        {
                            textBox.Text = text;
                        }
                        # endregion
                    }
                    catch
                    {
                        // �o�C���h�悪DBNull.Value�̍��ڂ�catch
                    }
                }
            }
        }
        # endregion
    }

    # region [�c�{�p�Ή����X�g�Z��]
    /// <summary>
    /// �c�{�p�Ή����X�g�Z��
    /// </summary>
    internal struct DoubleHeightTarget
    {
        /// <summary>�f�[�^�t�B�[���h</summary>
        private string _dataField;
        /// <summary>�e�Z�N�V����</summary>
        private ar.Section _parentSection;
        /// <summary>�Ώۃe�L�X�g�{�b�N�X</summary>
        private ar.TextBox _targetTextBox;
        /// <summary>�c�{�p�s�N�`��</summary>
        private ar.Picture _doubleHeightPicture;
        /// <summary>
        /// �f�[�^�t�B�[���h
        /// </summary>
        public string DataField
        {
            get { return _dataField; }
            set { _dataField = value; }
        }
        /// <summary>
        /// �e�Z�N�V����
        /// </summary>
        public ar.Section ParentSection
        {
            get { return _parentSection; }
            set { _parentSection = value; }
        }
        /// <summary>
        /// �Ώۃe�L�X�g�{�b�N�X
        /// </summary>
        public ar.TextBox TargetTextBox
        {
            get { return _targetTextBox; }
            set { _targetTextBox = value; }
        }
        /// <summary>
        /// �c�{�p�s�N�`��
        /// </summary>
        public ar.Picture DoubleHeightPicture
        {
            get { return _doubleHeightPicture; }
            set { _doubleHeightPicture = value; }
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="dataField">�f�[�^�t�B�[���h</param>
        /// <param name="parentSection">�e�Z�N�V����</param>
        /// <param name="targetTextBox">�Ώۃe�L�X�g�{�b�N�X</param>
        /// <param name="doubleHeightPicture">�c�{�p�s�N�`��</param>
        public DoubleHeightTarget( string dataField, ar.Section parentSection, ar.TextBox targetTextBox, ar.Picture doubleHeightPicture )
        {
            _dataField = dataField;
            _parentSection = parentSection;
            _targetTextBox = targetTextBox;
            _doubleHeightPicture = doubleHeightPicture;
        }
    }
    # endregion

    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
    # region [���R���[�R���g���[���^�O]
    /// <summary>
    /// ���R���[�R���g���[���^�O
    /// </summary>
    internal struct FrePControlTag
    {
        /// <summary>���R���[���ڃR�[�h</summary>
        private int _freePrtPaperItemCd;
        /// <summary>����y�[�W�敪</summary>
        private int _printPageCtrlDivCd;
        /// <summary>�O���[�v�T�v���X�敪</summary>
        private int _groupSuppressCd;
        /// <summary>���׃J���[�ύX�敪</summary>
        private int _dtlColorChangeCd;
        /// <summary>�������ߋ敪</summary>
        private int _heightAdjustDivCd;
        /// <summary>
        /// ���R���[���ڃR�[�h
        /// </summary>
        /// <remarks>1�`100:ActiveReport�p,101�`:.NS�p</remarks>
        public int FreePrtPaperItemCd
        {
            get { return _freePrtPaperItemCd; }
            set { _freePrtPaperItemCd = value; }
        }
        /// <summary>
        /// ����y�[�W�敪
        /// </summary>
        public int PrintPageCtrlDivCd
        {
            get { return _printPageCtrlDivCd; }
            set { _printPageCtrlDivCd = value; }
        }
        /// <summary>
        /// �O���[�v�T�v���X�敪
        /// </summary>
        /// <remarks>0:�Ȃ�,1:����</remarks>
        public int GroupSuppressCd
        {
            get { return _groupSuppressCd; }
            set { _groupSuppressCd = value; }
        }
        /// <summary>
        /// ���׃J���[�ύX�敪
        /// </summary>
        /// <remarks>0:��Ώ�,1:�Ώ�</remarks>
        public int DtlColorChangeCd
        {
            get { return _dtlColorChangeCd; }
            set { _dtlColorChangeCd = value; }
        }
        /// <summary>
        /// �������ߋ敪
        /// </summary>
        /// <remarks>0:��Ώ�,1:�Ώ�</remarks>
        public int HeightAdjustDivCd
        {
            get { return _heightAdjustDivCd; }
            set { _heightAdjustDivCd = value; }
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="freePrtPaperItemCd">���R���[���ڃR�[�h</param>
        /// <param name="printPageCtrlDivCd">����y�[�W�敪</param>
        /// <param name="groupSuppressCd">�O���[�v�T�v���X�敪</param>
        /// <param name="dtlColorChangeCd">���׃J���[�ύX�敪</param>
        /// <param name="heightAdjustDivCd">�������ߋ敪</param>
        public FrePControlTag( int freePrtPaperItemCd, int printPageCtrlDivCd, int groupSuppressCd, int dtlColorChangeCd, int heightAdjustDivCd )
        {
            _freePrtPaperItemCd = freePrtPaperItemCd;
            _printPageCtrlDivCd = printPageCtrlDivCd;
            _groupSuppressCd = groupSuppressCd;
            _dtlColorChangeCd = dtlColorChangeCd;
            _heightAdjustDivCd = heightAdjustDivCd;
        }
        /// <summary>
        /// �R���X�g���N�^(Tag���琶��)
        /// </summary>
        /// <param name="tag"></param>
        public FrePControlTag( object tag )
        {
            // ������
            _freePrtPaperItemCd = 0;
            _printPageCtrlDivCd = 0;
            _groupSuppressCd = 0;
            _dtlColorChangeCd = 0;
            _heightAdjustDivCd = 0;

            if ( tag is string )
            {
                string[] tagValues = (tag as string).Split( ',' );

                _freePrtPaperItemCd = ToInt( tagValues, 0 );
                _printPageCtrlDivCd = ToInt( tagValues, 1 );
                _groupSuppressCd = ToInt( tagValues, 2 );
                _dtlColorChangeCd = ToInt( tagValues, 3 );
                _heightAdjustDivCd = ToInt( tagValues, 4 );
            }
            else
            {
                // �����Ȑݒ�
            }
        }
        /// <summary>
        /// ���l�ϊ�(string�z��,index�w��)
        /// </summary>
        /// <param name="para"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static int ToInt( string[] para, int index )
        {
            if ( (para != null) && (para.Length > index) )
            {
                try
                {
                    return Int32.Parse( para[index] );
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
    # endregion

    # region [�R���g���[����r�N���X�i�\�[�g�p�j]
    /// <summary>
    /// �R���g���[����r�N���X�i�\�[�g�p�j
    /// </summary>
    internal class ARControlComparer : IComparer<ar.ARControl>
    {
        /// <summary>
        /// ��r����
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare( ar.ARControl x, ar.ARControl y )
        {
            int result;

            // �ʒu(Y)
            result = x.Top.CompareTo( y.Top );
            if ( result != 0 ) return result;

            // �ʒu(X)
            result = x.Left.CompareTo( y.Left );

            return result;
        }
    }
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
}
