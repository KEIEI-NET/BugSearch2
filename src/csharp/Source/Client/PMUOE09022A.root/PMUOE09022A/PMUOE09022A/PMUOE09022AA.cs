//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : UOE������ݒ�
// �v���O�����T�v   : UOE������}�X�^�e�[�u���̃A�N�Z�X������s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2008/06/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �C �� ��  2008/10/21  �C�����e : �ʐM�A�Z���u��ID�ɂ���ĕς����͍��ڂ��擾�ł���悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/06/01  �C�����e : �z���_e-Parts���ڒǉ��ɔ����C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : xuxh
// �C �� ��  2009/12/29  �C�����e : �y�v��No.1�z
//                                  �g���^�d�q�J�^���O�Ŏg�p���鑗�M�E��M�f�[�^�̕ۑ��ꏊ��ݒ肷��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : �k���r
// �C �� ��  2010/03/08  �C�����e : PM1006
//                                  UOE�����f�[�^��o�^����@�\�œ��͐���̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2010/04/06  �C�����e : �i�Ԍ������x�A�b�v�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601191-00 �쐬�S�� : jiangk
// �C �� ��  2010/04/23  �C�����e : PM1007C
//                                  UOE�����f�[�^��o�^����@�\�œ��͐���̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601191-00 �쐬�S�� : ����
// �� �� ��  2010/05/07  �C�����e : PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : 杍^
// �� �� ��  2010/12/31  �C�����e : UOE����������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10607734-00 �쐬�S�� : �{�w�C��
// �� �� ��  2011/01/28  �C�����e : �񓚎����捞�敪�i�g���^WEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10607734-01 �쐬�S�� : liyp
// �� �� ��  2011/03/01 �C�����e : �񓚎����捞�敪�i���YWEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10702591-00 �쐬�S�� : �{�w�C��
// �� �� ��  2011/05/10  �C�����e : �}�b�_����p���ւ̍��ڒǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�             �쐬�S�� : LIUSY
// �C �� ��  2011/11/24  �C�����e : PM1113A ��NET-WEB�Ή��ɔ����d�l�ǉ�
//                                  ��2012/04/16�@�}�[�W���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�             �쐬�S�� : yangmj
// �� �� ��  2011/12/15 �C�����e : Redmine#27386�g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�             �쐬�S�� : ���� ��
// �� �� ��  2012/09/10 �C�����e : BL�Ǘ����[�U�[�R�[�h�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// UOE������}�X�^ �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE������}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2008.06.26</br>
    /// <br></br>
    /// <br>UpdateNote : 2008.10.21 21024�@���X�� ��</br>
    /// <br>           : �ʐM�A�Z���u��ID�ɂ���ĕς����͍��ڂ��擾�ł���悤�ɏC��</br>
    /// <br>           : 2009/06/01 �Ɠc �M�u�@�z���_e-Parts���ڒǉ��ɔ����C��</br>
    /// <br>UpdateNote : 2009/12/29 xuxh</br>
    /// <br>           : �y�v��No.1�z�g���^�d�q�J�^���O�Ŏg�p���鑗�M�E��M�f�[�^�̕ۑ��ꏊ��ݒ肷��</br>
    /// <br>UpdateNote : 2010/03/08 �k���r</br>
    /// <br>           : PM1006 UOE�����f�[�^��o�^����@�\�œ��͐���̑Ή�</br>
	/// <br>UpdateNote : 2010/04/23 jiangk</br>
	/// <br>           : PM1007C UOE�����f�[�^��o�^����@�\�œ��͐���̑Ή�</br>
    /// <br>UpdateNote : 2010/05/07 ����</br>
    /// <br>           : PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
    /// <br>UpdateNote : 2010/12/31 杍^</br>
    /// <br>           : UOE����������</br>
    /// <br>UpdateNote : 2011/01/28 �{�w�C��</br>
    /// <br>           :�i�g���^WEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX</br>
    /// <br>UpdateNote : 2011/03/01 liyp</br>
    /// <br>             �񓚎����捞�敪�i���YWEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX</br>
    /// <br>UpdateNote : 2011/05/10 �{�w�C��</br>
    /// <br>           : �}�b�_����p���ւ̍��ڒǉ�</br>
    /// <br>UpdateNote : 2013/04/15 donggy</br>
    /// <br>�Ǘ��ԍ�   : 10900691-00 2013/05/15�z�M��</br>
    /// <br>             Redmine#35020�@�������ρv�́u����������ʁv�̃��X�|���X�ቺ�̃g���K�[�̔r��</br>
    /// </remarks>
    public class UOESupplierAcs : IGeneralGuideData
    {
        #region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        // UOE������}�X�^
        private IUOESupplierDB _iUOESupplierDB = null;

        // 2008.10.21 Add >>>
        // ���͐���p�̃f�B�N�V���i��
        private static Dictionary<string, UOEInputControlInfo> uOESupplierInputInfoDictionary;
        // 2008.10.21 Add <<<

        // 2008.11.05 30413 ���� UOE�K�C�h���̃A�N�Z�X�N���X�̒ǉ� >>>>>>START
        UOEGuideNameAcs _uoeGuideNameAcs;
        // 2008.11.05 30413 ���� UOE�K�C�h���̃A�N�Z�X�N���X�̒ǉ� <<<<<<END

        // -- ADD 2010/04/06 --------------------------------->>>
        //�L���b�V���p
        private static Dictionary<string, UOESupplier> _uOESupplierDic;
        // -- ADD 2010/04/06 ---------------------------------<<<

        #endregion


        #region Private Struct
        // 2008.10.21 Add >>>
        # region [UOE���͐���p���]
        /// <summary>
        /// UOE���͐���p���
        /// </summary>
        private struct UOEInputControlInfo
        {
            /// <summary>���}�[�N�P���͉�</summary>
            private bool _enabledUOERemark1;
            /// <summary>���}�[�N�Q���͉�</summary>
            private bool _enabledUOERemark2;
            /// <summary>���}�[�N�P���͌���</summary>
            private int _maxLengthUOERemark1;
            /// <summary>���}�[�N�Q���͌���</summary>
            private int _maxLengthUOERemark2;
            /// <summary>�[�i�敪���͉�</summary>
            private bool _enabledDeliveredGoodsDiv;
            /// <summary>�t�H���[�[�i�敪���͉�</summary>
            private bool _enabledFollowDeliGoodsDiv;
            /// <summary>�w�苒�_���͉�</summary>
            private bool _enabledUOEResvdSection;
            /// <summary>�����敪</summary>
            private PureCodeDiv _pureCode;

            /// <summary>���}�[�N�P���͉�</summary>
            public bool EnabledUOERemark1
            {
                get { return _enabledUOERemark1; }
                set { _enabledUOERemark1 = value; }
            }
            /// <summary>���}�[�N�Q���͉�</summary>
            public bool EnabledUOERemark2
            {
                get { return _enabledUOERemark2; }
                set { _enabledUOERemark2 = value; }
            }
            /// <summary>���}�[�N�P���͌���</summary>
            public int MaxLengthUOERemark1
            {
                get { return _maxLengthUOERemark1; }
                set { _maxLengthUOERemark1 = value; }
            }
            /// <summary>���}�[�N�Q���͌���</summary>
            public int MaxLengthUOERemark2
            {
                get { return _maxLengthUOERemark2; }
                set { _maxLengthUOERemark2 = value; }
            }
            /// <summary>�[�i�敪���͉�</summary>
            public bool EnabledDeliveredGoodsDiv
            {
                get { return _enabledDeliveredGoodsDiv; }
                set { _enabledDeliveredGoodsDiv = value; }
            }
            /// <summary>�t�H���[�[�i�敪���͉�</summary>
            public bool EnabledFollowDeliGoodsDiv
            {
                get { return _enabledFollowDeliGoodsDiv; }
                set { _enabledFollowDeliGoodsDiv = value; }
            }

            /// <summary>�w�苒�_���͉�</summary>
            public bool EnabledUOEResvdSection
            {
                get { return _enabledUOEResvdSection; }
                set { _enabledUOEResvdSection = value; }
            }

            /// <summary>�����敪</summary>
            public PureCodeDiv PureCodeDiv
            {
                get { return _pureCode; }
                set { _pureCode = value; }
            }

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="enabledUOERemark1">���}�[�N�P���͉�</param>
            /// <param name="enabledUOERemark2">���}�[�N�Q���͉�</param>
            /// <param name="enabledDeliveredGoodsDiv">�[�i�敪���͉�</param>
            /// <param name="enabledFollowDeliGoodsDiv">�t�H���[�[�i�敪���͉�</param>
            /// <param name="enabledUOEResvdSection">�S�����_���͉�</param>
            /// <param name="maxLengthUOERemark1">���}�[�N�P���͌���</param>
            /// <param name="maxLengthUOERemark2">���}�[�N�Q���͌���</param>
            /// <param name="pureCode">�����敪</param>
            public UOEInputControlInfo(bool enabledUOERemark1, bool enabledUOERemark2, bool enabledDeliveredGoodsDiv, bool enabledFollowDeliGoodsDiv, bool enabledUOEResvdSection, int maxLengthUOERemark1, int maxLengthUOERemark2,PureCodeDiv pureCode)
            {
                _enabledUOERemark1 = enabledUOERemark1;
                _enabledUOERemark2 = enabledUOERemark2;
                _maxLengthUOERemark1 = maxLengthUOERemark1;
                _maxLengthUOERemark2 = maxLengthUOERemark2;
                _enabledDeliveredGoodsDiv = enabledDeliveredGoodsDiv;
                _enabledFollowDeliGoodsDiv = enabledFollowDeliGoodsDiv;
                _enabledUOEResvdSection = enabledUOEResvdSection;
                _pureCode = pureCode;
            }
        }
        # endregion
        // 2008.10.21 Add <<<

        #endregion


        #region Constructor

        /// <summary>
        /// UOE������}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE������}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public UOESupplierAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iUOESupplierDB = (IUOESupplierDB)MediationUOESupplierDB.GetUOESupplierDB();

                // 2008.11.05 30413 ���� UOE�K�C�h���̃A�N�Z�X�N���X�̒ǉ� >>>>>>START
                this._uoeGuideNameAcs = new UOEGuideNameAcs();
                // 2008.11.05 30413 ���� UOE�K�C�h���̃A�N�Z�X�N���X�̒ǉ� <<<<<<END
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOESupplierDB = null;
            }
        }

        // 2008.10.21 Add >>>
        /// <summary>
        /// �X�^�e�B�b�N �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>UpdateNote : 2010/03/08 �k���r ���YWeb-UOE���͐���̑Ή�</br>
		/// <br>UpdateNote : 2010/04/23 jiangk �O�HWeb-UOE���͐���̑Ή�</br>
        /// <br>UpdateNote : 2010/05/07 ���� PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
        /// <br>UpdateNote : 2011/01/28 �{�w�C�� PM1102A  �g���^WEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX</br>
        /// <br>UpdateNote : 2011/03/01 liyp PM1103A  �񓚎����捞�敪�i���YWEBUOE�p�����A�g�p�̐ݒ�敪�j�̕ύX</br>
        /// <br>UpdateNote : 2011/05/10 �{�w�C�� PM1105A  �}�b�_����p���ւ̍��ڒǉ�</br>
        /// </remarks>
        static UOESupplierAcs()
        {
            uOESupplierInputInfoDictionary = new Dictionary<string, UOEInputControlInfo>();

            // �g���^
            uOESupplierInputInfoDictionary.Add("0102", new UOEInputControlInfo(true, true, true, true, true, 8, 10, PureCodeDiv.Pure));

            // �j�b�T��
            uOESupplierInputInfoDictionary.Add("0202", new UOEInputControlInfo(true, true, true, false, true, 10, 10, PureCodeDiv.Pure));

            // �~�c�r�V
            uOESupplierInputInfoDictionary.Add("0301", new UOEInputControlInfo(true, false, true, false, true, 8, 0, PureCodeDiv.Pure));

            // ���}�c�_
            uOESupplierInputInfoDictionary.Add("0401", new UOEInputControlInfo(true, false, true, false, true, 10, 0, PureCodeDiv.Pure));

            // �V�}�c�_
            uOESupplierInputInfoDictionary.Add("0402", new UOEInputControlInfo(true, false, true, false, true, 20, 0, PureCodeDiv.Pure));

            // �z���_
            uOESupplierInputInfoDictionary.Add("0501", new UOEInputControlInfo(true, false, true, false, true, 15, 0, PureCodeDiv.Pure));

            // �z���_(e-Parts)
            //uOESupplierInputInfoDictionary.Add("0502", new UOEInputControlInfo(true, false, true, false, true, 15, 0, PureCodeDiv.Pure));     //DEL 2009/06/01
            uOESupplierInputInfoDictionary.Add("0502", new UOEInputControlInfo(true, false, false, false, false, 15, 0, PureCodeDiv.Pure));     //ADD 2009/06/01

            // �X�o��
            uOESupplierInputInfoDictionary.Add("0801", new UOEInputControlInfo(true, true, true, false, true, 8, 10, PureCodeDiv.Pure));

            // �D��
            uOESupplierInputInfoDictionary.Add("1001", new UOEInputControlInfo(true, false, true, false, true, 10, 0, PureCodeDiv.Prime));

            // �g���^�d�q�J�^���O�A������
            uOESupplierInputInfoDictionary.Add("0103", new UOEInputControlInfo(true, false, true, true, true, 8, 10, PureCodeDiv.Pure)); // ADD 2009/12/29 xuxh

            // ---ADD 2010/03/08 ---------------------------------------->>>>>
            // ���YWeb-UOE�A������
            uOESupplierInputInfoDictionary.Add("0203", new UOEInputControlInfo(false, false, false, false, false, 0, 0, PureCodeDiv.Pure));
            // ---ADD 2010/03/08 ----------------------------------------<<<<<

            // ---ADD 2010/12/31 ---------------------------------------->>>>>
            // ���YWeb-UOE�A�����ځi�����̏ꍇ�j
            uOESupplierInputInfoDictionary.Add("0204", new UOEInputControlInfo(true, false, true, false, true, 10, 0, PureCodeDiv.Pure));

            // �O�HWeb-UOE�A�����ځi�����̏ꍇ�j
            uOESupplierInputInfoDictionary.Add("0303", new UOEInputControlInfo(true, false, true, false, false, 15, 0, PureCodeDiv.Pure));
            // ---ADD 2010/12/31 ----------------------------------------<<<<<

            // ---ADD 2011/01/28 ---------------------------------------->>>>>
            // �g���^�d�qWeb-UOE�A�����ځi�����̏ꍇ�j
            uOESupplierInputInfoDictionary.Add("0104", new UOEInputControlInfo(true, true, true, true, true, 8, 10, PureCodeDiv.Pure)); 
            // ---ADD 2011/01/28 ----------------------------------------<<<<<
            // ---ADD 2011/03/01 ---------------------------------------->>>>>
            // ���YWeb-UOE�A�����ځi�����̏ꍇ�j
            uOESupplierInputInfoDictionary.Add("0205", new UOEInputControlInfo(true, false, true, false, true, 10, 10, PureCodeDiv.Pure));
            // ���YWeb-UOE�A�����ځi�����̏ꍇ�j
            uOESupplierInputInfoDictionary.Add("0206", new UOEInputControlInfo(true, true, true, false, true, 10, 10, PureCodeDiv.Pure)); 
            // ---ADD 2011/03/01 ----------------------------------------<<<<<
			// ---ADD 2010/04/23 ---------------------------------------->>>>>
            // �O�HWeb-UOE�A������
			uOESupplierInputInfoDictionary.Add("0302", new UOEInputControlInfo(false, false, false, false, false, 0, 0, PureCodeDiv.Pure));
			// ---ADD 2010/04/23 ----------------------------------------<<<<<
            // ---ADD 2010/05/07 ---------------------------------------->>>>>
            // ����UOE-WEB�A������
            uOESupplierInputInfoDictionary.Add("1004", new UOEInputControlInfo(true, false, true, false, true, 10, 0, PureCodeDiv.Prime));
            // ---ADD 2011/05/10 ----------------------------------------<<<<<
            // �}�c�_UOE-WEB�A������
            uOESupplierInputInfoDictionary.Add("0403", new UOEInputControlInfo(true, false, false, false, false, 20, 0, PureCodeDiv.Pure));
            // ---ADD 2011/05/10 ----------------------------------------<<<<<
            // ---ADD 2011/11/24----------------------------------------<<<<<
            // ��NET-WEB
            uOESupplierInputInfoDictionary.Add("1003", new UOEInputControlInfo(true, false, true, false, true, 10, 0, PureCodeDiv.Prime));
            // ---ADD 2011/11/24----------------------------------------<<<<<
            // �����l
            uOESupplierInputInfoDictionary.Add(string.Empty, new UOEInputControlInfo(true, true, true, false, true, 20, 20, PureCodeDiv.Pure));
        }
        // 2008.10.21 Add <<<

        #endregion

        #region Public Enums
        /// <summary>
        /// �����敪
        /// </summary>
        public enum PureCodeDiv:int
        {
            Pure = 0,
            Prime=1
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iUOESupplierDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// UOE������}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="uoeSupplier">UOE������I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : UOE���������ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Read(out UOESupplier uoeSupplier, string enterpriseCode, int uoeSupplierCd, string sectionCode)
        {
            try
            {
                // �L�[���̐ݒ�
                uoeSupplier = null;
                UOESupplierWork uoeSupplierWork = new UOESupplierWork();
                uoeSupplierWork.EnterpriseCode = enterpriseCode;
                uoeSupplierWork.UOESupplierCd = uoeSupplierCd;
                uoeSupplierWork.SectionCode = sectionCode;
                // UOE�����惏�[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = (object)uoeSupplierWork;

                // ADD 2010/07/22 ----->>>>
                if (this._iUOESupplierDB == null)
                {
                    this._iUOESupplierDB = (IUOESupplierDB)MediationUOESupplierDB.GetUOESupplierDB();
                }
                // ADD 2010/07/22 -----<<<<

                //UOE������}�X�^�ǂݍ���
                int status = this._iUOESupplierDB.Read(ref paraObj, 0);

                if (status == 0)
                {
                    // �ǂݍ��݌��ʂ�UOE�����惏�[�J�[�N���X�ɐݒ�
                    UOESupplierWork wkUOESupplierWork = (UOESupplierWork)paraObj;
                    // UOE�����惏�[�J�[�N���X����UOE������N���X�ɃR�s�[
                    uoeSupplier = CopyToUOESupplierFromUOESupplierWork(wkUOESupplierWork);
                }
                // ADD 2010/07/22 ----->>>>
                else
                {
                    return status;
                }
                // ADD 2010/07/22 -----<<<<

                // -- ADD 2010/04/06 ----------->>>
                //�擾�����L���b�V��(���o�^�̏ꍇ���L���b�V������B�����斢�ݒ�̃��[�U�[�ւ̑Ή�)
                UpdateCache(uoeSupplier);
                // -- ADD 2010/04/06 -----------<<<

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOESupplierDB = null;
                //�ʐM�G���[��-1��߂�
                uoeSupplier = null;
                return -1;
            }
        }

        // -- ADD 2010/04/06 ------------------------>>>
        /// <summary>
        /// UOE������}�X�^�ǂݍ��ݏ����i�L���b�V���L�j
        /// </summary>
        /// <param name="uoeSupplier"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="uoeSupplierCd"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadCache(out UOESupplier uoeSupplier, string enterpriseCode, int uoeSupplierCd, string sectionCode)
        {
            uoeSupplier = null;

            //�p�����[�^���s���̏ꍇ�͎擾�����͍s��Ȃ�
            if (string.IsNullOrEmpty(enterpriseCode) || uoeSupplierCd == 0 || string.IsNullOrEmpty(sectionCode))
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            // �L���b�V������擾
            int status = this.GetFromCache(out uoeSupplier, enterpriseCode, uoeSupplierCd, sectionCode);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = this.Read(out uoeSupplier, enterpriseCode, uoeSupplierCd, sectionCode);
            }

            return status;
        }
        // -- ADD 2010/04/06 ------------------------<<<

        /// <summary>
        /// UOE������V���A���C�Y����
        /// </summary>
        /// <param name="uoeSupplier">�V���A���C�Y�Ώ�UOE������N���X</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : UOE������̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public void Serialize(UOESupplier uoeSupplier, string fileName)
        {
            // UOE������N���X����UOE�����惏�[�J�[�N���X�Ƀ����o�R�s�[
            UOESupplierWork uoeSupplierWork = CopyToUOESupplierWorkFromUOESupplier(uoeSupplier);

            // UOE�����惏�[�J�[�N���X���V���A���C�Y
            XmlByteSerializer.Serialize(uoeSupplierWork, fileName);
        }

        /// <summary>
        /// UOE������List�V���A���C�Y����
        /// </summary>
        /// <param name="uoeSupplierList">�V���A���C�Y�Ώ�UOE������List�N���X</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : UOE������List���̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public void ListSerialize(ArrayList uoeSupplierList, string fileName)
        {
            UOESupplierWork[] uoeSupplierWorks = new UOESupplierWork[uoeSupplierList.Count];

            for (int i = 0; i < uoeSupplierList.Count; i++)
            {
                uoeSupplierWorks[i] = CopyToUOESupplierWorkFromUOESupplier((UOESupplier)uoeSupplierList[i]);
            }

            // UOE�����惏�[�J�[�N���X���V���A���C�Y
            XmlByteSerializer.Serialize(uoeSupplierWorks, fileName);
        }

        /// <summary>
        /// UOE������N���X�f�V���A���C�Y����
        /// </summary>
        /// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
        /// <returns>UOE������N���X</returns>
        /// <remarks>
        /// <br>Note       : UOE������N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public UOESupplier Deserialize(string fileName)
        {
            UOESupplier uoeSupplier = null;

            // �t�@�C������n����UOE�����惏�[�N�N���X���f�V���A���C�Y����
            UOESupplierWork uoeSupplierWork = (UOESupplierWork)XmlByteSerializer.Deserialize(fileName, typeof(UOESupplierWork));

            // �f�V���A���C�Y���ʂ�UOE������N���X�փR�s�[
            if (uoeSupplierWork != null) uoeSupplier = CopyToUOESupplierFromUOESupplierWork(uoeSupplierWork);

            return uoeSupplier;
        }

        /// <summary>
        /// UOE������o�^�E�X�V����
        /// </summary>
        /// <param name="uoeSupplier">UOE������N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE������̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Write(ref UOESupplier uoeSupplier)
        {
            UOESupplierWork uoeSupplierWork = new UOESupplierWork();
            ArrayList paraList = new ArrayList();

            // UOE������N���X����UOE�����惏�[�N�N���X�Ƀ����o�R�s�[
            uoeSupplierWork = CopyToUOESupplierWorkFromUOESupplier(uoeSupplier);

            // UOE������̓o�^�E�X�V����ݒ�
            paraList.Add(uoeSupplierWork);

            object paraObj = paraList;

            int status = 0;
            try
            {
                // UOE�����揑������
                status = this._iUOESupplierDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;

                    uoeSupplier = new UOESupplier();

                    // UOE�����惏�[�N�N���X����UOE������N���X�Ƀ����o�R�s�[
                    uoeSupplier = this.CopyToUOESupplierFromUOESupplierWork((UOESupplierWork)paraList[0]);
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iUOESupplierDB = null;
                // �ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// UOE������_���폜����
        /// </summary>
        /// <param name="uoeSupplier">UOE������I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE��������̘_���폜���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int LogicalDelete(ref UOESupplier uoeSupplier)
        {
            int status = 0;

            try
            {
                UOESupplierWork uoeSupplierWork = new UOESupplierWork();
                ArrayList paraList = new ArrayList();

                // UOE������N���X����UOE�����惏�[�N�N���X�Ƀ����o�R�s�[
                uoeSupplierWork = CopyToUOESupplierWorkFromUOESupplier(uoeSupplier);
                // UOE������̘_���폜����ݒ�
                paraList.Add(uoeSupplierWork);

                object paraObj = paraList;

                // UOE������N���X�_���폜
                status = this._iUOESupplierDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    
                    uoeSupplier = new UOESupplier();
                    // UOE�����惏�[�N�N���X����UOE������N���X�Ƀ����o�R�s�[
                    uoeSupplier = this.CopyToUOESupplierFromUOESupplierWork((UOESupplierWork)paraList[0]);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOESupplierDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// UOE�����敨���폜����
        /// </summary>
        /// <param name="uoeSupplier">UOE������I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE��������̕����폜���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Delete(UOESupplier uoeSupplier)
        {
            try
            {
                UOESupplierWork uoeSupplierWork = new UOESupplierWork();
                ArrayList paraList = new ArrayList();

                // UOE������N���X����UOE�����惏�[�N�N���X�Ƀ����o�R�s�[
                uoeSupplierWork = CopyToUOESupplierWorkFromUOESupplier(uoeSupplier);
                // UOE������̕����폜����ݒ�
                paraList.Add(uoeSupplierWork);

                object paraObj = paraList;

                // UOE�����敨���폜
                int status = this._iUOESupplierDB.Delete(paraObj);

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOESupplierDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// UOE������_���폜��������
        /// </summary>
        /// <param name="uoeSupplier">UOE�����於�̃I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE��������̕������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Revival(ref UOESupplier uoeSupplier)
        {
            try
            {
                UOESupplierWork uoeSupplierWork = new UOESupplierWork();
                ArrayList paraList = new ArrayList();

                // UOE������N���X����UOE�����惏�[�N�N���X�Ƀ����o�R�s�[
                uoeSupplierWork = CopyToUOESupplierWorkFromUOESupplier(uoeSupplier);
                // UOE������̕�������ݒ�
                paraList.Add(uoeSupplierWork);

                object paraobj = paraList;

                // ��������
                int status = this._iUOESupplierDB.RevivalLogicalDelete(ref paraobj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraobj;

                    uoeSupplier = new UOESupplier();
                    // UOE�����惏�[�N�N���X����UOE������N���X�Ƀ����o�R�s�[
                    uoeSupplier = this.CopyToUOESupplierFromUOESupplierWork((UOESupplierWork)paraList[0]);
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOESupplierDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// UOE������}�X�^���������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : �擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.06.30</br>
        /// </remarks>
        public int Search(ref DataSet ds, string enterpriseCode, string sectionCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // UOE������}�X�^�T�[�`
            status = SearchAll(out retList, enterpriseCode, sectionCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList wkList = retList.Clone() as ArrayList;
            SortedList wkSort = new SortedList();

            // --- [�S��] --- //
            // ���̂܂ܑS���Ԃ�
            foreach (UOESupplier wkUOESupplier in wkList)
            {
                if (wkUOESupplier.LogicalDeleteCode == 0)
                {
                    // 2008.12.05 30413 ���� �d���L�[�̃`�F�b�N��ǉ� >>>>>>START
                    //wkSort.Add(wkUOESupplier.UOESupplierCd, wkUOESupplier);
                    if (!wkSort.ContainsKey(wkUOESupplier.UOESupplierCd))
                    {
                        wkSort.Add(wkUOESupplier.UOESupplierCd, wkUOESupplier);
                    }
                    // 2008.12.05 30413 ���� �d���L�[�̃`�F�b�N��ǉ� <<<<<<END
                }
            }

            UOESupplier[] uoeSuppliers = new UOESupplier[wkSort.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < wkSort.Count; i++)
            {
                uoeSuppliers[i] = (UOESupplier)wkSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(uoeSuppliers);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

        /// <summary>
        /// UOE�����挟�������i�_���폜�܂܂Ȃ��j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE������̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۂɊ܂܂�܂���B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.07.17</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retTotalCnt = 0;

            // UOE������}�X�^�i�_���폜�܂܂Ȃ��j
            status = SearchUOESupplier(ref list, out retTotalCnt, out nextData, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetData0, 0);

            retList = list;

            return status;
        }

        /// <summary>
        /// UOE�����挟�������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE������̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retTotalCnt = 0;

            // UOE������}�X�^
            status = SearchUOESupplier(ref list, out retTotalCnt, out nextData, enterpriseCode, sectionCode ,ConstantManagement.LogicalMode.GetDataAll, 0);

            retList = list;

            return status;
        }

        // --- ADD donggy 2013/04/15 for Redmine#35020 --->>>>>>>>>
        /// <summary>
        /// UOE�����挟������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="uoeSupplierWorkList">�w�蔭�����X�g</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w��UOE������̌����������s���܂��B</br>
        /// <br>Programmer : donggy</br>
        /// <br>Date       : 2013/04/15</br>
        /// </remarks>
        public int SearchBySupplierCds(out ArrayList retList, List<UOESupplier> uoeSupplierList)
        {
            List<UOESupplierWork> uoeSupplierWorkList = new List<UOESupplierWork>();
            // �����������X�g���쐬���܂�
            foreach (UOESupplier uoeSupplier in uoeSupplierList)
            {
                UOESupplierWork uoeSupplierWork = new UOESupplierWork();
                uoeSupplierWork.SectionCode = uoeSupplier.SectionCode;
                uoeSupplierWork.EnterpriseCode = uoeSupplier.EnterpriseCode;
                uoeSupplierWork.UOESupplierCd = uoeSupplier.UOESupplierCd;
                uoeSupplierWorkList.Add(uoeSupplierWork);
            }
            int status = 0;
            retList = new ArrayList();
            ArrayList workList = new ArrayList();
            object retObj = workList;

            if (retList.Count == 0)
            {
                // UOE�����惏�[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = (object)uoeSupplierWorkList;

                // �w�蔭����R�[�h�̏��̈ꊇ�Ǎ�
                status = this._iUOESupplierDB.Search(ref retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        workList = retObj as ArrayList;
                        if (workList != null)
                        {
                            foreach (UOESupplierWork wkUOESupplierWork in workList)
                            {
                                // �����[�g�p�����[�^�f�[�^ �� �f�[�^�N���X
                                UOESupplier wkUOESupplier = CopyToUOESupplierFromUOESupplierWork(wkUOESupplierWork);
                                // �f�[�^�N���X��Ǎ����ʂփR�s�[
                                retList.Add(wkUOESupplier);
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        return status;
                }
            }

            return status;
        }
        // --- ADD donggy 2013/04/15 for Redmine#35020 ---<<<<<<<<<
        public int GetUOEGuideData(out ArrayList retList, UOEGuideName uoeGuideName)
        {
            return this.SearchUOEGuideName(out retList, uoeGuideName);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iUOE�����惏�[�N�N���X��UOE������N���X�j
        /// </summary>
        /// <param name="uoeSupplierWork">UOE�����惏�[�N�N���X</param>
        /// <returns>UOE������N���X</returns>
        /// <remarks>
        /// <br>Note       : UOE�����惏�[�N�N���X����UOE������N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// <br>UpdateNote : 2011/12/15 yangmj</br>
        /// <br>           : Redmine#27386�g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�</br>
        /// </remarks>
        private UOESupplier CopyToUOESupplierFromUOESupplierWork(UOESupplierWork uoeSupplierWork)
        {
            UOESupplier uoeSupplier = new UOESupplier();

            uoeSupplier.CreateDateTime = uoeSupplierWork.CreateDateTime;
            uoeSupplier.UpdateDateTime = uoeSupplierWork.UpdateDateTime;
            uoeSupplier.EnterpriseCode = uoeSupplierWork.EnterpriseCode;
            uoeSupplier.FileHeaderGuid = uoeSupplierWork.FileHeaderGuid;
            uoeSupplier.UpdEmployeeCode = uoeSupplierWork.UpdEmployeeCode;
            uoeSupplier.UpdAssemblyId1 = uoeSupplierWork.UpdAssemblyId1;
            uoeSupplier.UpdAssemblyId2 = uoeSupplierWork.UpdAssemblyId2;
            uoeSupplier.LogicalDeleteCode = uoeSupplierWork.LogicalDeleteCode;
            uoeSupplier.SectionCode = uoeSupplierWork.SectionCode;                      // ���_�R�[�h

            uoeSupplier.UOESupplierCd = uoeSupplierWork.UOESupplierCd;                  // UOE������R�[�h
            uoeSupplier.UOESupplierName = uoeSupplierWork.UOESupplierName;              // UOE�����於��
            uoeSupplier.GoodsMakerCd = uoeSupplierWork.GoodsMakerCd;                    // ���i���[�J�[�R�[�h
            uoeSupplier.TelNo = uoeSupplierWork.TelNo;                                  // �d�b�ԍ�
            uoeSupplier.UOETerminalCd = uoeSupplierWork.UOETerminalCd;                  // UOE�[���R�[�h
            uoeSupplier.UOEHostCode = uoeSupplierWork.UOEHostCode;                      // UOE�z�X�g�R�[�h
            uoeSupplier.UOEConnectPassword = uoeSupplierWork.UOEConnectPassword;        // UOE�ڑ��p�X���[�h
            uoeSupplier.UOEConnectUserId = uoeSupplierWork.UOEConnectUserId;            // UOE�ڑ����[�UID
            uoeSupplier.UOEIDNum = uoeSupplierWork.UOEIDNum;                            // UOEID�ԍ�
            uoeSupplier.CommAssemblyId = uoeSupplierWork.CommAssemblyId;                // �ʐM�A�Z���u��ID
            uoeSupplier.ConnectVersionDiv = uoeSupplierWork.ConnectVersionDiv;          // �ڑ��o�[�W�����敪
            uoeSupplier.UOEShipSectCd = uoeSupplierWork.UOEShipSectCd;                  // UOE�o�ɋ��_�R�[�h
            uoeSupplier.UOESalSectCd = uoeSupplierWork.UOESalSectCd;                    // UOE���㋒�_�R�[�h
            uoeSupplier.UOEReservSectCd = uoeSupplierWork.UOEReservSectCd;              // UOE�w�苒�_�R�[�h
            uoeSupplier.ReceiveCondition = uoeSupplierWork.ReceiveCondition;            // ��M��
            uoeSupplier.SubstPartsNoDiv = uoeSupplierWork.SubstPartsNoDiv;              // ��֕i�ԋ敪
            uoeSupplier.PartsNoPrtCd = uoeSupplierWork.PartsNoPrtCd;                    // �i�Ԉ���敪
            uoeSupplier.ListPriceUseDiv = uoeSupplierWork.ListPriceUseDiv;              // �艿�g�p�敪
            uoeSupplier.StockSlipDtRecvDiv = uoeSupplierWork.StockSlipDtRecvDiv;        // �d���f�[�^��M�敪
            uoeSupplier.CheckCodeDiv = uoeSupplierWork.CheckCodeDiv;                    // �`�F�b�N�R�[�h�敪
            uoeSupplier.BusinessCode = uoeSupplierWork.BusinessCode;                    // �Ɩ��敪
            uoeSupplier.UOEResvdSection = uoeSupplierWork.UOEResvdSection;              // UOE�w�苒�_
            uoeSupplier.EmployeeCode = uoeSupplierWork.EmployeeCode;                    // �]�ƈ��R�[�h
            // 2008.11.11 30413 ���� �[�i�敪��UOE�[�i�敪�ɏC�� >>>>>>START
            //uoeSupplier.DeliveredGoodsDiv = uoeSupplierWork.DeliveredGoodsDiv;          // �[�i�敪
            uoeSupplier.UOEDeliGoodsDiv = uoeSupplierWork.UOEDeliGoodsDiv;              // UOE�[�i�敪
            // 2008.11.11 30413 ���� �[�i�敪��UOE�[�i�敪�ɏC�� <<<<<<END
            uoeSupplier.BoCode = uoeSupplierWork.BoCode;                                // BO�敪
            uoeSupplier.UOEOrderRate = uoeSupplierWork.UOEOrderRate;                    // UOE�������[�g
            uoeSupplier.EnableOdrMakerCd1 = uoeSupplierWork.EnableOdrMakerCd1;          // �����\���[�J�[�R�[�h�P
            uoeSupplier.EnableOdrMakerCd2 = uoeSupplierWork.EnableOdrMakerCd2;          // �����\���[�J�[�R�[�h�Q
            uoeSupplier.EnableOdrMakerCd3 = uoeSupplierWork.EnableOdrMakerCd3;          // �����\���[�J�[�R�[�h�R
            uoeSupplier.EnableOdrMakerCd4 = uoeSupplierWork.EnableOdrMakerCd4;          // �����\���[�J�[�R�[�h�S
            uoeSupplier.EnableOdrMakerCd5 = uoeSupplierWork.EnableOdrMakerCd5;          // �����\���[�J�[�R�[�h�T
            uoeSupplier.EnableOdrMakerCd6 = uoeSupplierWork.EnableOdrMakerCd6;          // �����\���[�J�[�R�[�h�U

            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
            uoeSupplier.OdrPrtsNoHyphenCd1 = uoeSupplierWork.OdrPrtsNoHyphenCd1;          // �����\���[�J�[�R�[�h�P
            uoeSupplier.OdrPrtsNoHyphenCd2 = uoeSupplierWork.OdrPrtsNoHyphenCd2;          // �����\���[�J�[�R�[�h�Q
            uoeSupplier.OdrPrtsNoHyphenCd3 = uoeSupplierWork.OdrPrtsNoHyphenCd3;          // �����\���[�J�[�R�[�h�R
            uoeSupplier.OdrPrtsNoHyphenCd4 = uoeSupplierWork.OdrPrtsNoHyphenCd4;          // �����\���[�J�[�R�[�h�S
            uoeSupplier.OdrPrtsNoHyphenCd5 = uoeSupplierWork.OdrPrtsNoHyphenCd5;          // �����\���[�J�[�R�[�h�T
            uoeSupplier.OdrPrtsNoHyphenCd6 = uoeSupplierWork.OdrPrtsNoHyphenCd6;          // �����\���[�J�[�R�[�h�U
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<

            uoeSupplier.instrumentNo = uoeSupplierWork.instrumentNo;                    // �@��ԍ�
            uoeSupplier.UOETestMode = uoeSupplierWork.UOETestMode;                      // UOE�e�X�g���[�h
            uoeSupplier.UOEItemCd = uoeSupplierWork.UOEItemCd;                          // UOE�A�C�e���R�[�h
            uoeSupplier.HondaSectionCode = uoeSupplierWork.HondaSectionCode;            // �z���_�S�����_
            uoeSupplier.AnswerSaveFolder = uoeSupplierWork.AnswerSaveFolder;            // �񓚕ۑ��t�H���_
            uoeSupplier.MazdaSectionCode = uoeSupplierWork.MazdaSectionCode;            // �}�c�_�����_�R�[�h
            uoeSupplier.EmergencyDiv = uoeSupplierWork.EmergencyDiv;                    // �ً}�敪
            uoeSupplier.DaihatsuOrdreDiv = uoeSupplierWork.DaihatsuOrdreDiv;            // ������z�敪�i�_�C�n�c�j
            uoeSupplier.SupplierCd = uoeSupplierWork.SupplierCd;                        // �d����R�[�h
            // ---ADD 2009/06/01 ----------------------------------------------------------->>>>>
            uoeSupplier.UOELoginUrl = uoeSupplierWork.UOELoginUrl;                      // ���O�C���pURL
            uoeSupplier.UOEOrderUrl = uoeSupplierWork.UOEOrderUrl;                      // �����pURL
            uoeSupplier.UOEStockCheckUrl = uoeSupplierWork.UOEStockCheckUrl;            // �݌Ɋm�F�pURL
            uoeSupplier.UOEForcedTermUrl = uoeSupplierWork.UOEForcedTermUrl;            // �����I���pURL
            uoeSupplier.InqOrdDivCd = uoeSupplierWork.InqOrdDivCd;                      // �ڑ����
            uoeSupplier.LoginTimeoutVal = uoeSupplierWork.LoginTimeoutVal;              // ���O�C���F�؎���
            uoeSupplier.EPartsUserId = uoeSupplierWork.EPartsUserId;                    // ���[�UID
            uoeSupplier.EPartsPassWord = uoeSupplierWork.EPartsPassWord;                // �p�X���[�h
            // ---ADD 2009/06/01 -----------------------------------------------------------<<<<<
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
            uoeSupplier.BLMngUserCode = uoeSupplierWork.BLMngUserCode;                  // BL�Ǘ����[�U�[�R�[�h
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<

            return uoeSupplier;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iUOE������N���X��UOE�����惏�[�N�N���X�j
        /// </summary>
        /// <param name="uoeSupplier">UOE�����惏�[�N�N���X</param>
        /// <returns>UOE������N���X</returns>
        /// <remarks>
        /// <br>Note       : UOE������N���X����UOE�����惏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private UOESupplierWork CopyToUOESupplierWorkFromUOESupplier(UOESupplier uoeSupplier)
        {
            UOESupplierWork uoeSupplierWork = new UOESupplierWork();

            uoeSupplierWork.CreateDateTime = uoeSupplier.CreateDateTime;
            uoeSupplierWork.UpdateDateTime = uoeSupplier.UpdateDateTime;
            uoeSupplierWork.EnterpriseCode = uoeSupplier.EnterpriseCode;
            uoeSupplierWork.FileHeaderGuid = uoeSupplier.FileHeaderGuid;
            uoeSupplierWork.UpdEmployeeCode = uoeSupplier.UpdEmployeeCode;
            uoeSupplierWork.UpdAssemblyId1 = uoeSupplier.UpdAssemblyId1;
            uoeSupplierWork.UpdAssemblyId2 = uoeSupplier.UpdAssemblyId2;
            uoeSupplierWork.LogicalDeleteCode = uoeSupplier.LogicalDeleteCode;
            uoeSupplierWork.SectionCode = uoeSupplier.SectionCode;                      // ���_�R�[�h

            uoeSupplierWork.UOESupplierCd = uoeSupplier.UOESupplierCd;                  // UOE������R�[�h
            uoeSupplierWork.UOESupplierName = uoeSupplier.UOESupplierName;              // UOE�����於��
            uoeSupplierWork.GoodsMakerCd = uoeSupplier.GoodsMakerCd;                    // ���i���[�J�[�R�[�h
            uoeSupplierWork.TelNo = uoeSupplier.TelNo;                                  // �d�b�ԍ�
            uoeSupplierWork.UOETerminalCd = uoeSupplier.UOETerminalCd;                  // UOE�[���R�[�h
            uoeSupplierWork.UOEHostCode = uoeSupplier.UOEHostCode;                      // UOE�z�X�g�R�[�h
            uoeSupplierWork.UOEConnectPassword = uoeSupplier.UOEConnectPassword;        // UOE�ڑ��p�X���[�h
            uoeSupplierWork.UOEConnectUserId = uoeSupplier.UOEConnectUserId;            // UOE�ڑ����[�UID
            uoeSupplierWork.UOEIDNum = uoeSupplier.UOEIDNum;                            // UOEID�ԍ�
            uoeSupplierWork.CommAssemblyId = uoeSupplier.CommAssemblyId;                // �ʐM�A�Z���u��ID
            uoeSupplierWork.ConnectVersionDiv = uoeSupplier.ConnectVersionDiv;          // �ڑ��o�[�W�����敪
            uoeSupplierWork.UOEShipSectCd = uoeSupplier.UOEShipSectCd;                  // UOE�o�ɋ��_�R�[�h
            uoeSupplierWork.UOESalSectCd = uoeSupplier.UOESalSectCd;                    // UOE���㋒�_�R�[�h
            uoeSupplierWork.UOEReservSectCd = uoeSupplier.UOEReservSectCd;              // UOE�w�苒�_�R�[�h
            uoeSupplierWork.ReceiveCondition = uoeSupplier.ReceiveCondition;            // ��M��
            uoeSupplierWork.SubstPartsNoDiv = uoeSupplier.SubstPartsNoDiv;              // ��֕i�ԋ敪
            uoeSupplierWork.PartsNoPrtCd = uoeSupplier.PartsNoPrtCd;                    // �i�Ԉ���敪
            uoeSupplierWork.ListPriceUseDiv = uoeSupplier.ListPriceUseDiv;              // �艿�g�p�敪
            uoeSupplierWork.StockSlipDtRecvDiv = uoeSupplier.StockSlipDtRecvDiv;        // �d���f�[�^��M�敪
            uoeSupplierWork.CheckCodeDiv = uoeSupplier.CheckCodeDiv;                    // �`�F�b�N�R�[�h�敪
            uoeSupplierWork.BusinessCode = uoeSupplier.BusinessCode;                    // �Ɩ��敪
            uoeSupplierWork.UOEResvdSection = uoeSupplier.UOEResvdSection;              // UOE�w�苒�_
            uoeSupplierWork.EmployeeCode = uoeSupplier.EmployeeCode;                    // �]�ƈ��R�[�h
            // 2008.11.11 30413 ���� �[�i�敪��UOE�[�i�敪�ɏC�� >>>>>>START
            //uoeSupplierWork.DeliveredGoodsDiv = uoeSupplier.DeliveredGoodsDiv;          // �[�i�敪
            uoeSupplierWork.UOEDeliGoodsDiv = uoeSupplier.UOEDeliGoodsDiv;              // UOE�[�i�敪
            // 2008.11.11 30413 ���� �[�i�敪��UOE�[�i�敪�ɏC�� <<<<<<END
            uoeSupplierWork.BoCode = uoeSupplier.BoCode;                                // BO�敪
            uoeSupplierWork.UOEOrderRate = uoeSupplier.UOEOrderRate;                    // UOE�������[�g
            uoeSupplierWork.EnableOdrMakerCd1 = uoeSupplier.EnableOdrMakerCd1;          // �����\���[�J�[�R�[�h�P
            uoeSupplierWork.EnableOdrMakerCd2 = uoeSupplier.EnableOdrMakerCd2;          // �����\���[�J�[�R�[�h�Q
            uoeSupplierWork.EnableOdrMakerCd3 = uoeSupplier.EnableOdrMakerCd3;          // �����\���[�J�[�R�[�h�R
            uoeSupplierWork.EnableOdrMakerCd4 = uoeSupplier.EnableOdrMakerCd4;          // �����\���[�J�[�R�[�h�S
            uoeSupplierWork.EnableOdrMakerCd5 = uoeSupplier.EnableOdrMakerCd5;          // �����\���[�J�[�R�[�h�T
            uoeSupplierWork.EnableOdrMakerCd6 = uoeSupplier.EnableOdrMakerCd6;          // �����\���[�J�[�R�[�h�U
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�----->>>>>
            uoeSupplierWork.OdrPrtsNoHyphenCd1 = uoeSupplier.OdrPrtsNoHyphenCd1;          // �����\���[�J�[�R�[�h�P
            uoeSupplierWork.OdrPrtsNoHyphenCd2 = uoeSupplier.OdrPrtsNoHyphenCd2;          // �����\���[�J�[�R�[�h�Q
            uoeSupplierWork.OdrPrtsNoHyphenCd3 = uoeSupplier.OdrPrtsNoHyphenCd3;          // �����\���[�J�[�R�[�h�R
            uoeSupplierWork.OdrPrtsNoHyphenCd4 = uoeSupplier.OdrPrtsNoHyphenCd4;          // �����\���[�J�[�R�[�h�S
            uoeSupplierWork.OdrPrtsNoHyphenCd5 = uoeSupplier.OdrPrtsNoHyphenCd5;          // �����\���[�J�[�R�[�h�T
            uoeSupplierWork.OdrPrtsNoHyphenCd6 = uoeSupplier.OdrPrtsNoHyphenCd6;          // �����\���[�J�[�R�[�h�U
            //------ADD 2011/12/15 yangmj �g���^UOEWeb�^�N�e�B�[�i�Ԃ̔����Ή�-----<<<<<
            uoeSupplierWork.instrumentNo = uoeSupplier.instrumentNo;                    // �@��ԍ�
            uoeSupplierWork.UOETestMode = uoeSupplier.UOETestMode;                      // UOE�e�X�g���[�h
            uoeSupplierWork.UOEItemCd = uoeSupplier.UOEItemCd;                          // UOE�A�C�e���R�[�h
            uoeSupplierWork.HondaSectionCode = uoeSupplier.HondaSectionCode;            // �z���_�S�����_
            uoeSupplierWork.AnswerSaveFolder = uoeSupplier.AnswerSaveFolder;            // �񓚕ۑ��t�H���_
            uoeSupplierWork.MazdaSectionCode = uoeSupplier.MazdaSectionCode;            // �}�c�_�����_�R�[�h
            uoeSupplierWork.EmergencyDiv = uoeSupplier.EmergencyDiv;                    // �ً}�敪
            uoeSupplierWork.DaihatsuOrdreDiv = uoeSupplier.DaihatsuOrdreDiv;            // ������z�敪�i�_�C�n�c�j
            uoeSupplierWork.SupplierCd = uoeSupplier.SupplierCd;                        // �d����R�[�h
            // ---ADD 2009/06/01 ----------------------------------------------------------->>>>>
            uoeSupplierWork.UOELoginUrl = uoeSupplier.UOELoginUrl;                      // ���O�C���pURL
            uoeSupplierWork.UOEOrderUrl = uoeSupplier.UOEOrderUrl;                      // �����pURL
            uoeSupplierWork.UOEStockCheckUrl = uoeSupplier.UOEStockCheckUrl;            // �݌Ɋm�F�pURL
            uoeSupplierWork.UOEForcedTermUrl = uoeSupplier.UOEForcedTermUrl;            // �����I���pURL
            uoeSupplierWork.InqOrdDivCd = uoeSupplier.InqOrdDivCd;                      // �ڑ����
            uoeSupplierWork.LoginTimeoutVal = uoeSupplier.LoginTimeoutVal;              // ���O�C���F�؎���
            uoeSupplierWork.EPartsUserId = uoeSupplier.EPartsUserId;                    // ���[�UID
            uoeSupplierWork.EPartsPassWord = uoeSupplier.EPartsPassWord;                // �p�X���[�h
            // ---ADD 2009/06/01 -----------------------------------------------------------<<<<<
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
            uoeSupplierWork.BLMngUserCode = uoeSupplier.BLMngUserCode;                  // BL�Ǘ����[�U�[�R�[�h
            // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<

            return uoeSupplierWork;
        }

        /// <summary>
        /// UOE�����挟������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE������̌����������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private int SearchUOESupplier(ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode,string sectionCode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            UOESupplierWork uoeSupplierWork = new UOESupplierWork();

            // ���f�[�^�L��������
            nextData = false;
            // �Ǎ��Ώۃf�[�^������0�ŏ�����
            retTotalCnt = 0;

            int status = 0;

            ArrayList workList = new ArrayList();
            object retObj = workList;

            if (retList.Count == 0)
            {
                // �Z�L�����e�B���x���L�[�w��
                uoeSupplierWork.EnterpriseCode = enterpriseCode;
                uoeSupplierWork.SectionCode = sectionCode;

                // UOE�����惏�[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = (object)uoeSupplierWork;
                
                // �S���Ǎ�
                status = this._iUOESupplierDB.Search(ref retObj, paraObj, 0, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        workList = retObj as ArrayList;
                        if (workList != null)
                        {
                            foreach (UOESupplierWork wkUOESupplierWork in workList)
                            {
                                // �����[�g�p�����[�^�f�[�^ �� �f�[�^�N���X
                                UOESupplier wkUOESupplier = CopyToUOESupplierFromUOESupplierWork(wkUOESupplierWork);
                                // �f�[�^�N���X��Ǎ����ʂփR�s�[
                                retList.Add(wkUOESupplier);
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        return status;
                }
            }

            // �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        private int SearchUOEGuideName(out ArrayList retList, UOEGuideName uoeGuideName)
        {
            int status = -1;

            status = this._uoeGuideNameAcs.Search(out retList, uoeGuideName);

            return status;
        }

        // -- ADD 2010/04/06 --------------------------------------->>>
        /// <summary>
        /// �L�[��񐶐�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">����_��Ǘ��R�[�h</param>
        /// <returns>���������L�[���</returns>
        public string ConstructionKey(string enterpriseCode, int supplierCode, string sectionCode)
        {
            string key = string.Empty;
            key = enterpriseCode.Trim() + "-" + supplierCode.ToString() + "-" + sectionCode.Trim();
            return key;
        }

        /// <summary>
        /// �L���b�V���X�V����
        /// </summary>
        /// <param name="supplier"></param>
        /// <remarks>���z�[�������擾���܂߂�Read�̗��p�p�x���l�����A�L���b�V��������s���܂��B</remarks>
        private void UpdateCache(UOESupplier supplier)
        {
            // static�f�B�N�V���i����������ΐ���
            if (_uOESupplierDic == null)
            {
                _uOESupplierDic = new Dictionary<string, UOESupplier>();
            }
            // �����Ȃ�΍폜
            if (_uOESupplierDic.ContainsKey(ConstructionKey(supplier.EnterpriseCode, supplier.UOESupplierCd, supplier.SectionCode)))
            {
                _uOESupplierDic.Remove(ConstructionKey(supplier.EnterpriseCode, supplier.UOESupplierCd, supplier.SectionCode));
            }
            // �ǉ�
            _uOESupplierDic.Add(ConstructionKey(supplier.EnterpriseCode, supplier.UOESupplierCd, supplier.SectionCode), supplier);
        }

        /// <summary>
        /// �L���b�V���擾����
        /// </summary>
        /// <param name="supplierCode"></param>
        /// <remarks>���z�[�������擾���܂߂�Read�̗��p�p�x���l�����A�L���b�V��������s���܂��B</remarks>
        private int GetFromCache(out UOESupplier uoeSupplier, string enterpriseCode, int supplierCode, string sectionCode)
        {
            uoeSupplier = null;

            if (_uOESupplierDic != null)
            {
                // �L���b�V������擾
                if (_uOESupplierDic.ContainsKey(ConstructionKey(enterpriseCode, supplierCode, sectionCode)))
                {
                    uoeSupplier = _uOESupplierDic[ConstructionKey(enterpriseCode, supplierCode, sectionCode)];
                }
            }

            if (uoeSupplier == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
        }

        /// <summary>
        /// �L���b�V���폜����
        /// </summary>
        /// <param name="supplierCode"></param>
        /// <remarks>���z�[�������擾���܂߂�Read�̗��p�p�x���l�����A�L���b�V��������s���܂��B</remarks>
        private void DeleteFromCache(string enterpriseCode, int supplierCode, string sectionCode)
        {
            if (_uOESupplierDic != null)
            {
                // �L���b�V������폜
                if (_uOESupplierDic.ContainsKey(ConstructionKey(enterpriseCode, supplierCode, sectionCode)))
                {
                    _uOESupplierDic.Remove(ConstructionKey(enterpriseCode, supplierCode, sectionCode));
                }
            }
        }

        /// <summary>
        /// �L���b�V���S�폜����
        /// </summary>
        public void DeleteAllFromCache()
        {
            _uOESupplierDic = new Dictionary<string, UOESupplier>();
        }
        // -- ADD 2010/04/06 ---------------------------------------<<<

        #endregion

        #region Guid Methods

        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note		: �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.06.30</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";
            string sectionCode = "";

            // ��ƃR�[�h�ݒ�L��
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            // ��ƃR�[�h�ݒ薳��
            else
            {
                // �L�蓾�Ȃ��̂ŃG���[
                return status;
            }
            //��ƃR�[�h
            if (inParm.ContainsKey("SectionCode"))
            {
                sectionCode = inParm["SectionCode"].ToString();
            }

            // UOE������}�X�^�e�[�u���Ǎ���
            status = Search(ref guideList, enterpriseCode,sectionCode);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    status = -1;
                    break;
            }

            return status;
        }

        /// <summary>
        /// UOE������}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="maker">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note		: UOE������}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.06.30</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, string sectionCode, out UOESupplier uoeSupplier)
        {
            int status = -1;
            uoeSupplier = new UOESupplier();

            TableGuideParent tableGuideParent = new TableGuideParent("UOESUPPLIERGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // ��ƃR�[�h
            inObj.Add("EnterpriseCode", enterpriseCode);
            inObj.Add("SectionCode", sectionCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                // ��ƃR�[�h
                uoeSupplier.EnterpriseCode = retObj["EnterpriseCode"].ToString();
                // ���_�R�[�h
                uoeSupplier.SectionCode = retObj["SectionCode"].ToString();
                // UOE������R�[�h
                string strCode = retObj["UOESupplierCd"].ToString();
                uoeSupplier.UOESupplierCd = int.Parse(strCode);
                // UOE�����於��
                uoeSupplier.UOESupplierName = retObj["UOESupplierName"].ToString();
                // ���i���[�J�[�R�[�h
                strCode = retObj["GoodsMakerCd"].ToString();
                uoeSupplier.GoodsMakerCd = int.Parse(strCode);
                // �d����R�[�h
                strCode = retObj["SupplierCd"].ToString();
                uoeSupplier.SupplierCd = int.Parse(strCode);
                // �d�b�ԍ�
                uoeSupplier.TelNo = retObj["TelNo"].ToString();
                // UOE�[���R�[�h
                uoeSupplier.UOETerminalCd = retObj["UOETerminalCd"].ToString();
                // UOE�z�X�g�R�[�h
                uoeSupplier.UOEHostCode = retObj["UOEHostCode"].ToString();
                // UOE�ڑ��p�X���[�h
                uoeSupplier.UOEConnectPassword = retObj["UOEConnectPassword"].ToString();
                // UOE�ڑ����[�UID
                uoeSupplier.UOEConnectUserId = retObj["UOEConnectUserId"].ToString();
                // UOEID�ԍ�
                uoeSupplier.UOEIDNum = retObj["UOEIDNum"].ToString();
                // �ʐM�A�Z���u��ID
                uoeSupplier.CommAssemblyId = retObj["CommAssemblyId"].ToString();
                // �ڑ��o�[�W�����敪
                strCode = retObj["ConnectVersionDiv"].ToString();
                uoeSupplier.ConnectVersionDiv = int.Parse(strCode);
                // UOE�o�ɋ��_�R�[�h
                uoeSupplier.UOEShipSectCd = retObj["UOEShipSectCd"].ToString();
                // UOE���㋒�_�R�[�h
                uoeSupplier.UOESalSectCd = retObj["UOESalSectCd"].ToString();
                // UOE�w�苒�_�R�[�h
                uoeSupplier.UOEReservSectCd = retObj["UOEReservSectCd"].ToString();
                // ��M��
                strCode = retObj["ReceiveCondition"].ToString();
                uoeSupplier.ReceiveCondition = int.Parse(strCode);
                // ��֕i�ԋ敪
                strCode = retObj["SubstPartsNoDiv"].ToString();
                uoeSupplier.SubstPartsNoDiv = int.Parse(strCode);
                // �i�Ԉ���敪
                strCode = retObj["PartsNoPrtCd"].ToString();
                uoeSupplier.PartsNoPrtCd = int.Parse(strCode);
                // �艿�g�p�敪
                strCode = retObj["ListPriceUseDiv"].ToString();
                uoeSupplier.ListPriceUseDiv = int.Parse(strCode);
                // �d���f�[�^��M�敪
                strCode = retObj["StockSlipDtRecvDiv"].ToString();
                uoeSupplier.StockSlipDtRecvDiv = int.Parse(strCode);
                // �`�F�b�N�R�[�h�敪
                strCode = retObj["CheckCodeDiv"].ToString();
                uoeSupplier.CheckCodeDiv = int.Parse(strCode);
                // �Ɩ��敪
                strCode = retObj["BusinessCode"].ToString();
                uoeSupplier.BusinessCode = int.Parse(strCode);
                // UOE�w�苒�_
                uoeSupplier.UOEResvdSection = retObj["UOEResvdSection"].ToString();
                // �]�ƈ��R�[�h
                uoeSupplier.EmployeeCode = retObj["EmployeeCode"].ToString();
                // 2008.11.11 30413 ���� �[�i�敪��UOE�[�i�敪�ɏC�� >>>>>>START
                //// �[�i�敪
                //strCode = retObj["DeliveredGoodsDiv"].ToString();
                //uoeSupplier.DeliveredGoodsDiv = int.Parse(strCode);
                // UOE�[�i�敪
                uoeSupplier.UOEDeliGoodsDiv = retObj["UOEDeliGoodsDiv"].ToString();
                // 2008.11.11 30413 ���� �[�i�敪��UOE�[�i�敪�ɏC�� <<<<<<END
                // BO�敪
                uoeSupplier.BoCode = retObj["BoCode"].ToString();
                // UOE�������[�g
                uoeSupplier.UOEOrderRate = retObj["UOEOrderRate"].ToString();
                // �@��ԍ�
                uoeSupplier.instrumentNo = retObj["instrumentNo"].ToString();
                // UOE�e�X�g���[�h
                uoeSupplier.UOETestMode = retObj["UOETestMode"].ToString();
                // UOE�A�C�e���R�[�h
                uoeSupplier.UOEItemCd = retObj["UOEItemCd"].ToString();
                // �z���_�S�����_
                uoeSupplier.HondaSectionCode = retObj["HondaSectionCode"].ToString();
                // �񓚕ۑ��t�H���_
                uoeSupplier.AnswerSaveFolder = retObj["AnswerSaveFolder"].ToString();
                // �}�c�_�����_�R�[�h
                uoeSupplier.MazdaSectionCode = retObj["MazdaSectionCode"].ToString();
                // �ً}�敪
                uoeSupplier.EmergencyDiv = retObj["EmergencyDiv"].ToString();
                // �����\���[�J�[�R�[�h�P
                strCode = retObj["EnableOdrMakerCd1"].ToString();
                uoeSupplier.EnableOdrMakerCd1 = int.Parse(strCode);
                // �����\���[�J�[�R�[�h�Q
                strCode = retObj["EnableOdrMakerCd2"].ToString();
                uoeSupplier.EnableOdrMakerCd2 = int.Parse(strCode);
                // �����\���[�J�[�R�[�h�R
                strCode = retObj["EnableOdrMakerCd3"].ToString();
                uoeSupplier.EnableOdrMakerCd3 = int.Parse(strCode);
                // �����\���[�J�[�R�[�h�S
                strCode = retObj["EnableOdrMakerCd4"].ToString();
                uoeSupplier.EnableOdrMakerCd4 = int.Parse(strCode);
                // �����\���[�J�[�R�[�h�T
                strCode = retObj["EnableOdrMakerCd5"].ToString();
                uoeSupplier.EnableOdrMakerCd5 = int.Parse(strCode);
                // �����\���[�J�[�R�[�h�U
                strCode = retObj["EnableOdrMakerCd6"].ToString();
                uoeSupplier.EnableOdrMakerCd6 = int.Parse(strCode);
                // ---ADD 2009/06/01 ----------------------------------------------------------->>>>>
                // ���O�C���pURL
                uoeSupplier.UOELoginUrl = retObj["UOELoginUrl"].ToString();
                // �����pURL
                uoeSupplier.UOEOrderUrl = retObj["UOEOrderUrl"].ToString();
                // �݌Ɋm�F�pURL
                uoeSupplier.UOEStockCheckUrl = retObj["UOEStockCheckUrl"].ToString();
                // �����I���pURL
                uoeSupplier.UOEForcedTermUrl = retObj["UOEForcedTermUrl"].ToString();
                // �ڑ����
                strCode = retObj["InqOrdDivCd"].ToString();
                uoeSupplier.InqOrdDivCd = int.Parse(strCode);
                // ���O�C���F�؎���
                strCode = retObj["LoginTimeoutVal"].ToString();
                uoeSupplier.LoginTimeoutVal = int.Parse(strCode);
                // ���[�UID
                uoeSupplier.EPartsUserId = retObj["EPartsUserId"].ToString();
                // �p�X���[�h
                uoeSupplier.EPartsPassWord = retObj["EPartsPassWord"].ToString();
                // ---ADD 2009/06/01 -----------------------------------------------------------<<<<<
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� ----->>>>>>>>>>>>>>>>>>>>
                uoeSupplier.BLMngUserCode = retObj["BLMngUserCode"].ToString();
                // 2012/09/10 ADD TAKAGAWA BL�Ǘ����[�U�[�R�[�h�Ή� -----<<<<<<<<<<<<<<<<<<<<

                status = 0;
            }
            // �L�����Z��
            else
            {
                status = 1;
            }

            return status;
        }

        #endregion


        #region Public Static Methods


        // 2008.10.21 Add >>>

        /// <summary>
        /// �t�n�d���}�[�N�P�L����������
        /// </summary>
        /// <param name="commAssemblyId">�ʐM�A�Z���u��ID</param>
        /// <returns>True:�L��</returns>
        public static bool EnabledUOERemark1(string commAssemblyId)
        {
            commAssemblyId = commAssemblyId.Trim().PadLeft(4, '0');             //ADD 2009/06/01
            if (uOESupplierInputInfoDictionary.ContainsKey(commAssemblyId))
                return uOESupplierInputInfoDictionary[commAssemblyId].EnabledUOERemark1;
            else
                return uOESupplierInputInfoDictionary[string.Empty].EnabledUOERemark1;
        }

        /// <summary>
        /// �t�n�d���}�[�N�Q�L����������
        /// </summary>
        /// <param name="commAssemblyId">�ʐM�A�Z���u��ID</param>
        /// <returns>True:�L��</returns>
        public static bool EnabledUOERemark2(string commAssemblyId)
        {
            commAssemblyId = commAssemblyId.Trim().PadLeft(4, '0');             //ADD 2009/06/01
            if (uOESupplierInputInfoDictionary.ContainsKey(commAssemblyId))
                return uOESupplierInputInfoDictionary[commAssemblyId].EnabledUOERemark2;
            else
                return uOESupplierInputInfoDictionary[string.Empty].EnabledUOERemark2;
        }

        /// <summary>
        /// �[�i�敪�L����������
        /// </summary>
        /// <param name="commAssemblyId">�ʐM�A�Z���u��ID</param>
        /// <returns>True:�L��</returns>
        public static bool EnabledDeliveredGoodsDiv(string commAssemblyId)
        {
            commAssemblyId = commAssemblyId.Trim().PadLeft(4, '0');             //ADD 2009/06/01
            if (uOESupplierInputInfoDictionary.ContainsKey(commAssemblyId))
                return uOESupplierInputInfoDictionary[commAssemblyId].EnabledDeliveredGoodsDiv;
            else
                return uOESupplierInputInfoDictionary[string.Empty].EnabledDeliveredGoodsDiv;
        }

        /// <summary>
        /// �t�H���[�[�i�敪�L����������
        /// </summary>
        /// <param name="commAssemblyId">�ʐM�A�Z���u��ID</param>
        /// <returns>True:�L��</returns>
        public static bool EnabledFollowDeliGoodsDiv(string commAssemblyId)
        {
            commAssemblyId = commAssemblyId.Trim().PadLeft(4, '0');             //ADD 2009/06/01
            if (uOESupplierInputInfoDictionary.ContainsKey(commAssemblyId))
                return uOESupplierInputInfoDictionary[commAssemblyId].EnabledFollowDeliGoodsDiv;
            else
                return uOESupplierInputInfoDictionary[string.Empty].EnabledFollowDeliGoodsDiv;
        }

        /// <summary>
        /// �w�苒�_�L����������
        /// </summary>
        /// <param name="commAssemblyId">�ʐM�A�Z���u��ID</param>
        /// <returns>True:�L��</returns>
        public static bool EnabledUOEResvdSection(string commAssemblyId)
        {
            commAssemblyId = commAssemblyId.Trim().PadLeft(4, '0');             //ADD 2009/06/01
            if (uOESupplierInputInfoDictionary.ContainsKey(commAssemblyId))
                return uOESupplierInputInfoDictionary[commAssemblyId].EnabledUOEResvdSection;
            else
                return uOESupplierInputInfoDictionary[string.Empty].EnabledUOEResvdSection;
        }

        /// <summary>
        /// ���}�[�N�P�ő包��
        /// </summary>
        /// <param name="commAssemblyId">�ʐM�A�Z���u��ID</param>
        /// <returns>���}�[�N�P�ő包��</returns>
        public static int MaxLengthUOERemark1(string commAssemblyId)
        {
            commAssemblyId = commAssemblyId.Trim().PadLeft(4, '0');             //ADD 2009/06/01
            if (uOESupplierInputInfoDictionary.ContainsKey(commAssemblyId))
                return uOESupplierInputInfoDictionary[commAssemblyId].MaxLengthUOERemark1;
            else
                return uOESupplierInputInfoDictionary[string.Empty].MaxLengthUOERemark1;
        }

        /// <summary>
        /// ���}�[�N�Q�ő包��
        /// </summary>
        /// <param name="commAssemblyId">�ʐM�A�Z���u��ID</param>
        /// <returns>���}�[�N�Q�ő包��</returns>
        public static int MaxLengthUOERemark2(string commAssemblyId)
        {
            commAssemblyId = commAssemblyId.Trim().PadLeft(4, '0');             //ADD 2009/06/01
            if (uOESupplierInputInfoDictionary.ContainsKey(commAssemblyId))
                return uOESupplierInputInfoDictionary[commAssemblyId].MaxLengthUOERemark2;
            else
                return uOESupplierInputInfoDictionary[string.Empty].MaxLengthUOERemark2;
        }

        /// <summary>
        /// �����敪
        /// </summary>
        /// <param name="commAssemblyId">�ʐM�A�Z���u��ID</param>
        /// <returns>�����敪</returns>
        public static PureCodeDiv PureCodeUOESupplier(string commAssemblyId)
        {
            commAssemblyId = commAssemblyId.Trim().PadLeft(4, '0');             //ADD 2009/06/01
            if (uOESupplierInputInfoDictionary.ContainsKey(commAssemblyId))
                return uOESupplierInputInfoDictionary[commAssemblyId].PureCodeDiv;
            else
                return uOESupplierInputInfoDictionary[string.Empty].PureCodeDiv;
        }

        // 2008.10.21 Add <<<

        #endregion
    }
}
