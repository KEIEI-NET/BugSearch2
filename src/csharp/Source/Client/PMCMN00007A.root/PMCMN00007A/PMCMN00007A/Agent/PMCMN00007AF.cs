//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���쌠���ݒ�f�[�^
// �v���O�����T�v   : ���쌠���ݒ�f�[�^�̃��[�e�B���e�B���`���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/07/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Util
{
    using TextBoxType   = Infragistics.Win.UltraWinEditors.TextEditorControlBase;
    using OptionSetType = Infragistics.Win.UltraWinEditors.UltraOptionSet;

    #region <���쌠���ݒ�f�[�^/>

    /// <summary>
    /// ���쌠���ݒ�f�[�^���[�e�B���e�B
    /// </summary>
    public static class EntityUtil
    {
        #region <�J�e�S��/>

        /// <summary>
        /// �J�e�S���R�[�h�񋓑�
        /// </summary>
        public enum CategoryCode : int
        {
            /// <summary>���i</summary>
            Part = 0,
            /// <summary>�G���g��</summary>
            Entry = 1,
            /// <summary>�X�V</summary>
            Update = 2,
            /// <summary>�Ɖ�</summary>
            Reference = 3,
            /// <summary>���[</summary>
            Report = 4,
            /// <summary>�}�X����</summary>
            MasterMaintenance = 50,
            /// <summary>�S�̐ݒ�</summary>
            AllSetting = 60,
            /// <summary>���̑�</summary>
            Others = 90
        }

        /// <summary>
        /// �J�e�S���[�R�[�h�̔z��𐶐����܂��B
        /// </summary>
        /// <returns>�J�e�S���[�R�[�h�̔z��</returns>
        public static int[] CreateCategoryCodeArray()
        {
           return new int[] {
                (int)CategoryCode.Part,
                (int)CategoryCode.Entry,
                (int)CategoryCode.Update,
                (int)CategoryCode.Reference,
                (int)CategoryCode.Report,
                (int)CategoryCode.MasterMaintenance,
                (int)CategoryCode.Others
            };
        }

        #endregion  // <�J�e�S��/>

        #region <�v���O����ID/>

        /// <summary>�S�v���O������\��ID</summary>
        public const string ALL_PG_ID = "";

        #endregion  // <�v���O����ID/>

        #region <�I�y���[�V�����R�[�h/>

        /// <summary>�S�����\���I�y���[�V�����R�[�h</summary>
        public const int ALL_OPERATION_CODE = -1;

        #endregion  // <�I�y���[�V�����R�[�h/>
    }

    #endregion  // <���쌠���ݒ�f�[�^/>

    #region <���_/>

    /// <summary>
    /// ���_���[�e�B���e�B
    /// </summary>
    public static class SectionUtil
    {
        #region <���b�Z�[�W/>

        /// <summary>���b�Z�[�W�F���_�R�[�h�����݂��܂���B</summary>
        public const string MSG_SECTION_CODE_IS_NOT_FOUND = "���_�R�[�h�����݂��܂���B";       // LITERAL:

        /// <summary>���b�Z�[�W�F�S�Аݒ�͍폜�ł��܂���B</summary>
        public const string MSG_ALL_SECTION_CANNOT_BE_DELETED = "�S�Ћ��ʂ͍폜�ł��܂���B";   // LITERAL:

        #endregion  // <���b�Z�[�W/>

        /// <summary>����</summary>
        public const int DIGIT = 2;

        #region <�S�Ћ���/>

        /// <summary>�S�Ћ��ʂ��������_�R�[�h�l</summary>
        public const int ALL_SECTION_CODE_NUMBER = 0;

        /// <summary>�S�Ћ��ʂ��������_�R�[�h</summary>
        public const string ALL_SECTION_CODE = "00";

        /// <summary>�S�Ћ��ʂ̖���</summary>
        public const string ALL_SECTION_NAME = "�S�Ћ���";

        /// <summary>
        /// �S�Ђ����肵�܂��B
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns><c>true</c> :�S�Ђł���B<br/><c>false</c>:�S�Ђł͂Ȃ��B</returns>
        public static bool IsAllSection(string sectionCode)
        {
            int sectionCodeNumber = -1;
            bool isNumber = int.TryParse(sectionCode.Trim(), out sectionCodeNumber);
            if (isNumber)
            {
                return sectionCodeNumber.Equals(ALL_SECTION_CODE_NUMBER);
            }
            else
            {
                return false;
            }
        }

        #endregion  // <�S�Ћ���/>

        /// <summary>
        /// �w�肵�����_�R�[�h�����݂��邩���肵�܂��B
        /// </summary>
        /// <remarks>
        /// �S�Ћ��ʃR�[�h�͑��݂���Ɣ��肵�܂��B
        /// </remarks>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns><c>true</c> :���݂���B<br/><c>false</c>:���݂��Ȃ��B</returns>
        public static bool ExistsCode(string sectionCode)
        {
            return ExistsCode(sectionCode, false);
        }

        /// <summary>
        /// �w�肵�����_�R�[�h�����݂��邩���肵�܂��B
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="enabledAllSection">�S�Ћ��ʂ�L���ɂ���t���O(<c>true</c> :�L��<br/><c>false</c>:����)</param>
        /// <returns><c>true</c> :���݂���B<br/><c>false</c>:���݂��Ȃ��B</returns>
        private static bool ExistsCode(
            string sectionCode,
            bool enabledAllSection
        )
        {
            // �S�Ћ��ʂ������̏ꍇ�A�S�Ћ��ʃR�[�h�͑��݂���Ɣ���
            if (!enabledAllSection)
            {
                if (IsAllSection(sectionCode)) return true;
            }

            SecInfoAcs secInfoAcs = new SecInfoAcs();   // ���_�R�[�h�̃K�C�h

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    // TODO:�����̂悢�������@
                    if (secInfoSet.SectionCode.Trim().Equals(sectionCode.Trim().PadLeft(DIGIT, '0')))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }

            return false;
        }
    }

    #endregion  // <���_/>

    #region <�͈͊֘A/>

    /// <summary>
    /// �͈̓��[�e�B���e�B
    /// </summary>
    /// <remarks>
    /// <br>Note       : �e�R�[�h�͈̔͂ƌ��̏���񋟂��܂��B</br>
    /// <br>Programmer : 30434 �H�� �b�D</br>
    /// <br>Date       : 2008.09.30</br>
    /// </remarks>
    public static class RangeUtil
    {
        /// <summary>�Ώی��t�H�[�}�b�g</summary>
        public const string YEAR_MONTH_FORMAT = "yyyy/MM";
        /// <summary>�Ώۓ��t�H�[�}�b�g</summary>
        public const string DATE_FORMAT = "yyyy/MM/dd";

        /// <summary>�ŏ�����</summary>
        public const string FROM_BEGIN = "�ŏ�����";
        /// <summary>�Ō�܂�</summary>
        public const string TO_END = "�Ō�܂�";

        /// <summary>
        /// �ŏ����炩���肵�܂��B
        /// </summary>
        /// <param name="startCode">�J�n�R�[�h</param>
        /// <param name="minNumber">�ŏ��l</param>
        /// <returns><c>true</c> :�ŏ�����<br/><c>false</c>:�ŏ�����ł͂Ȃ�</returns>
        private static bool IsFromBegin(
            string startCode,
            int minNumber
        )
        {
            if (string.IsNullOrEmpty(startCode)) return true;

            int startNumber = -1;
            if (int.TryParse(startCode, out startNumber))
            {
                return startNumber < minNumber;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// �Ō�܂ł����肵�܂��B
        /// </summary>
        /// <param name="endCode">�I���R�[�h</param>
        /// <param name="maxNumber">�ő�l</param>
        /// <returns><c>true</c> :�Ō�܂�<br/><c>false</c>:�Ō�܂łł͂Ȃ�</returns>
        private static bool IsToEnd(
            string endCode,
            int maxNumber
        )
        {
            if (string.IsNullOrEmpty(endCode)) return true;

            int endNumber = -1;
            if (int.TryParse(endCode, out endNumber))
            {
                return endNumber > maxNumber;
            }
            else
            {
                return false;
            }
        }

        #region <�]�ƈ��R�[�h/>

        /// <summary>
        /// �S���ҁF�]�ƈ��R�[�h
        /// </summary>
        public static class EmployeeCode
        {
            /// <summary>���x��</summary>
            public const string LABEL = "�S����";
            /// <summary>�ŏ��l</summary>
            public const int MIN = 1;
            /// <summary>�ő�l</summary>
            public const int MAX = 9999;
            /// <summary>���l�t�H�[�}�b�g</summary>
            public const string NUMBER_FORMAT = "0000";

            /// <summary>
            /// �S�͈͂����肵�܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// �J�n��������擾���܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <returns>�J�n������</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// �I����������擾���܂��B
            /// </summary>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns>�I��������</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }
        }

        #endregion

        #region <�q�ɃR�[�h/>

        /// <summary>
        /// �q�ɁF�q�ɃR�[�h
        /// </summary>
        public static class WarehouseCode
        {
            /// <summary>���x��</summary>
            public const string LABEL = "�q��";
            /// <summary>�ŏ��l</summary>
            public const int MIN = 1;
            /// <summary>�ő�l</summary>
            public const int MAX = 9999;
            /// <summary>���l�t�H�[�}�b�g</summary>
            public const string NUMBER_FORMAT = "0000";

            /// <summary>
            /// �S�͈͂����肵�܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
            public static bool IsAllRange(string startCode, string endCode)
            {
                return IsFromBegin(startCode, MIN) && IsToEnd(endCode, MAX);
            }

            /// <summary>
            /// �J�n��������擾���܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <returns>�J�n������</returns>
            public static string GetStartString(string startCode)
            {
                return IsFromBegin(startCode, MIN) ? FROM_BEGIN : startCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }

            /// <summary>
            /// �I����������擾���܂��B
            /// </summary>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns>�I��������</returns>
            public static string GetEndString(string endCode)
            {
                return IsToEnd(endCode, MAX) ? TO_END : endCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }
        }

        #endregion  // <�q�ɃR�[�h/>

        #region <�d����R�[�h/>

        /// <summary>
        /// �d����F�d����R�[�h
        /// </summary>
        public static class SupplierCode
        {
            /// <summary>���x��</summary>
            public const string LABEL = "�d����";
            /// <summary>�ŏ��l</summary>
            public const int MIN = 1;
            /// <summary>�ő�l</summary>
            public const int MAX = 999999;
            /// <summary>���l�t�H�[�}�b�g</summary>
            public const string NUMBER_FORMAT = "000000";

            /// <summary>
            /// �S�͈͂����肵�܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// �J�n��������擾���܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <returns>�J�n������</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// �I����������擾���܂��B
            /// </summary>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns>�I��������</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }
        }

        #endregion

        #region <���i���[�J�[�R�[�h/>

        /// <summary>
        /// ���[�J�[�F���i���[�J�[�R�[�h
        /// </summary>
        public static class GoodsMakerCode
        {
            /// <summary>���x��</summary>
            public const string LABEL = "���[�J�[";
            /// <summary>�ŏ��l</summary>
            public const int MIN = 1;
            /// <summary>�ő�l</summary>
            public const int MAX = 9999;
            /// <summary>���l�t�H�[�}�b�g</summary>
            public const string NUMBER_FORMAT = "0000";

            /// <summary>
            /// �S�͈͂����肵�܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// �J�n��������擾���܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <returns>�J�n������</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// �I����������擾���܂��B
            /// </summary>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns>�I��������</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }
        }

        #endregion  // <���i���[�J�[�R�[�h/>

        #region <���i�啪�ރR�[�h/>

        /// <summary>
        /// ���i�啪�ށF���i�啪�ރR�[�h
        /// </summary>
        public static class GoodsLGroupCode
        {
            /// <summary>���x��</summary>
            public const string LABEL = "���i�啪��";
            /// <summary>�ŏ��l</summary>
            public const int MIN = 1;
            /// <summary>�ő�l</summary>
            public const int MAX = 9999;
            /// <summary>���l�t�H�[�}�b�g</summary>
            public const string NUMBER_FORMAT = "0000";

            /// <summary>
            /// �S�͈͂����肵�܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// �S�͈͂����肵�܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
            public static bool IsAllRange(string startCode, string endCode)
            {
                return IsFromBegin(startCode, MIN) && IsToEnd(endCode, MAX);
            }

            /// <summary>
            /// �J�n��������擾���܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <returns>�J�n������</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// �I����������擾���܂��B
            /// </summary>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns>�I��������</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// �J�n��������擾���܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <returns>�J�n������</returns>
            public static string GetStartString(string startCode)
            {
                return IsFromBegin(startCode, MIN) ? FROM_BEGIN : startCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }

            /// <summary>
            /// �I����������擾���܂��B
            /// </summary>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns>�I��������</returns>
            public static string GetEndString(string endCode)
            {
                return IsToEnd(endCode, MAX) ? TO_END : endCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }
        }

        #endregion  // <���i�啪�ރR�[�h/>

        #region <���i�����ރR�[�h/>

        /// <summary>
        /// ���i�����ށF���i�����ރR�[�h
        /// </summary>
        public static class GoodsMGroupCode
        {
            /// <summary>���x��</summary>
            public const string LABEL = "���i������";
            /// <summary>�ŏ��l</summary>
            public const int MIN = 1;
            /// <summary>�ő�l</summary>
            public const int MAX = 9999;
            /// <summary>���l�t�H�[�}�b�g</summary>
            public const string NUMBER_FORMAT = "0000";

            /// <summary>
            /// �S�͈͂����肵�܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// �S�͈͂����肵�܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
            public static bool IsAllRange(string startCode, string endCode)
            {
                return IsFromBegin(startCode, MIN) && IsToEnd(endCode, MAX);
            }

            /// <summary>
            /// �J�n��������擾���܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <returns>�J�n������</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// �I����������擾���܂��B
            /// </summary>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns>�I��������</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// �J�n��������擾���܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <returns>�J�n������</returns>
            public static string GetStartString(string startCode)
            {
                return IsFromBegin(startCode, MIN) ? FROM_BEGIN : startCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }

            /// <summary>
            /// �I����������擾���܂��B
            /// </summary>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns>�I��������</returns>
            public static string GetEndString(string endCode)
            {
                return IsToEnd(endCode, MAX) ? TO_END : endCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }
        }

        #endregion  // <���i�����ރR�[�h/>

        #region <�a�k�O���[�v�R�[�h/>

        /// <summary>
        /// �O���[�v�R�[�h�FBL�O���[�v�R�[�h
        /// </summary>
        public static class BLGroupCode
        {
            /// <summary>���x��</summary>
            public const string LABEL = "�O���[�v�R�[�h";
            /// <summary>�ŏ��l</summary>
            public const int MIN = 1;
            /// <summary>�ő�l</summary>
            public const int MAX = 99999;
            /// <summary>���l�t�H�[�}�b�g</summary>
            public const string NUMBER_FORMAT = "00000";

            /// <summary>
            /// �S�͈͂����肵�܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// �S�͈͂����肵�܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
            public static bool IsAllRange(string startCode, string endCode)
            {
                return IsFromBegin(startCode, MIN) && IsToEnd(endCode, MAX);
            }

            /// <summary>
            /// �J�n��������擾���܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <returns>�J�n������</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// �I����������擾���܂��B
            /// </summary>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns>�I��������</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// �J�n��������擾���܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <returns>�J�n������</returns>
            public static string GetStartString(string startCode)
            {
                return IsFromBegin(startCode, MIN) ? FROM_BEGIN : startCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }

            /// <summary>
            /// �I����������擾���܂��B
            /// </summary>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns>�I��������</returns>
            public static string GetEndString(string endCode)
            {
                return IsToEnd(endCode, MAX) ? TO_END : endCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }
        }

        #endregion  // <�a�k�O���[�v�R�[�h/>

        #region <���Е��ރR�[�h/>

        /// <summary>
        /// ���i�敪�F���Е��ރR�[�h
        /// </summary>
        public static class EnterpriseGanreCode
        {
            /// <summary>���x��</summary>
            public const string LABEL = "���i�敪";
            /// <summary>�ŏ��l</summary>
            public const int MIN = 1;
            /// <summary>�ő�l</summary>
            public const int MAX = 9999;
            /// <summary>���l�t�H�[�}�b�g</summary>
            public const string NUMBER_FORMAT = "0000";

            /// <summary>
            /// �S�͈͂����肵�܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// �J�n��������擾���܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <returns>�J�n������</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// �I����������擾���܂��B
            /// </summary>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns>�I��������</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }
        }

        #endregion  // <���Е��ރR�[�h/>

        #region <�a�k�R�[�h/>

        /// <summary>
        /// BL�R�[�h�FBL�R�[�h
        /// </summary>
        public static class BLGoodsCode
        {
            /// <summary>���x��</summary>
            public const string LABEL = "�a�k�R�[�h";
            /// <summary>�ŏ��l</summary>
            public const int MIN = 1;
            /// <summary>�ő�l</summary>
            public const int MAX = 99999;
            /// <summary>���l�t�H�[�}�b�g</summary>
            public const string NUMBER_FORMAT = "00000";

            /// <summary>
            /// �S�͈͂����肵�܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// �J�n��������擾���܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <returns>�J�n������</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// �I����������擾���܂��B
            /// </summary>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns>�I��������</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }
        }

        #endregion  // <�a�k�R�[�h�F�a�k�R�[�h/>

        #region <�̔��G���A�R�[�h/>

        /// <summary>
        /// �n��F�̔��G���A�R�[�h
        /// </summary>
        public static class SalesAreaCode
        {
            /// <summary>���x��</summary>
            public const string LABEL = "�n��";
            /// <summary>�ŏ��l</summary>
            public const int MIN = 1;
            /// <summary>�ő�l</summary>
            public const int MAX = 9999;
            /// <summary>���l�t�H�[�}�b�g</summary>
            public const string NUMBER_FORMAT = "0000";

            /// <summary>
            /// �S�͈͂����肵�܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
            public static bool IsAllRange(int startCode, int endCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) && IsToEnd(endCode.ToString(), MAX);
            }

            /// <summary>
            /// �S�͈͂����肵�܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns><c>true</c> :�S�͈͂ł���<br/><c>false</c>:�S�͈͂ł͂Ȃ�</returns>
            public static bool IsAllRange(string startCode, string endCode)
            {
                return IsFromBegin(startCode, MIN) && IsToEnd(endCode, MAX);
            }

            /// <summary>
            /// �J�n��������擾���܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <returns>�J�n������</returns>
            public static string GetStartString(int startCode)
            {
                return IsFromBegin(startCode.ToString(), MIN) ? FROM_BEGIN : startCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// �I����������擾���܂��B
            /// </summary>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns>�I��������</returns>
            public static string GetEndString(int endCode)
            {
                return IsToEnd(endCode.ToString(), MAX) ? TO_END : endCode.ToString(NUMBER_FORMAT);
            }

            /// <summary>
            /// �J�n��������擾���܂��B
            /// </summary>
            /// <param name="startCode">�J�n�R�[�h</param>
            /// <returns>�J�n������</returns>
            public static string GetStartString(string startCode)
            {
                return IsFromBegin(startCode, MIN) ? FROM_BEGIN : startCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }

            /// <summary>
            /// �I����������擾���܂��B
            /// </summary>
            /// <param name="endCode">�I���R�[�h</param>
            /// <returns>�I��������</returns>
            public static string GetEndString(string endCode)
            {
                return IsToEnd(endCode, MAX) ? TO_END : endCode.PadLeft(NUMBER_FORMAT.Length, '0');
            }
        }

        #endregion  // <�̔��G���A�R�[�h/>
    }

    #endregion  // <�͈�/>

    #region <�K�C�h����/>

    /// <summary>
    /// �K�C�h��UI�𐧌䂷��N���X
    /// </summary>
    /// <typeparam name="TValueUI">�l��UI�̌^�i�ʏ��TNedit�j</typeparam>
    /// <typeparam name="TOperationUI">�����UI�̌^�i�ʏ��UltraButton�j</typeparam>
    /// <typeparam name="TNextFocusUI">�����Ƀt�H�[�J�X����UI�̌^�i�ʏ��TCommboEditor�j</typeparam>
    public class GuideUIController<TValueUI, TOperationUI, TNextFocusUI>
        where TValueUI      : TextBoxType
        where TOperationUI  : Control
        where TNextFocusUI  : Control
    {
        #region <�͈͎w���UI�t���O/>

        /// <summary>�͈͎w���UI�t���O</summary>
        private bool _isRangeUI;
        /// <summary>
        /// �͈͎w���UI�t���O�̃A�N�Z�T
        /// </summary>
        /// <value><c>true</c> :�͈͎w���UI�ł���B<br/><c>false</c>:�͈͎w���UI�ł͂Ȃ��B</value>
        protected bool IsRangeUI
        {
            get { return _isRangeUI; }
            set { _isRangeUI = value; }
        }

        #endregion  // <�͈͎w���UI�t���O/>

        #region <�l/>

        /// <summary>�l��UI</summary>
        private readonly TValueUI _valueUI;
        /// <summary>
        /// �l��UI���擾���܂��B
        /// </summary>
        /// <value>�l��UI</value>
        protected TValueUI ValueUI
        {
            get { return _valueUI; }
        }

        /// <summary>�ȑO�̒l</summary>
        private string _previousValue;
        /// <summary>
        /// �ȑO�̒l�̃A�N�Z�T
        /// </summary>
        /// <value>�ȑO�̒l</value>
        protected string PreviousValue
        {
            get { return _previousValue; }
            set { _previousValue = value; }
        }

        /// <summary>
        /// �ȑO�̒l���擾���܂��B
        /// </summary>
        /// <returns>�ȑO�̒l</returns>
        public string GetPreviousText()
        {
            return PreviousValue;
        }

        #endregion  // <�l/>

        #region <����/>

        /// <summary>�����UI</summary>
        private readonly TOperationUI _operationUI;
        /// <summary>
        /// �����UI���擾���܂��B
        /// </summary>
        /// <value>�����UI</value>
        protected TOperationUI OperationUI
        {
            get { return _operationUI; }
        }

        // TODO:���P���u���i�폜��������Łc�j
        /// <summary>����UI�̃t�H�[�J�X�\�t���O</summary>
        private bool _canFocusOperationUI = true;
        /// <summary>
        /// ����UI�̃t�H�[�J�X�\�t���O�̃A�N�Z�T
        /// </summary>
        /// <value><c>true</c> :�\�B<br/><c>false</c>:�s�\</value>
        protected bool CanFocusOperationUI
        {
            get { return _canFocusOperationUI; }
            set { _canFocusOperationUI = value; }
        }

        #endregion  // <����/>

        #region <�����̃t�H�[�J�X/>

        /// <summary>�����Ƀt�H�[�J�X����UI</summary>
        private readonly TNextFocusUI _nextFocusUI;
        /// <summary>
        /// �����Ƀt�H�[�J�X����UI
        /// </summary>
        /// <value>�����Ƀt�H�[�J�X����UI</value>
        protected TNextFocusUI NextFocusUI
        {
            get { return _nextFocusUI; }
        }

        #endregion  // <�����̃t�H�[�J�X/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="valueUI">�l��UI</param>
        /// <param name="operationUI">�����UI</param>
        /// <param name="nextFocusUI">�����Ƀt�H�[�J�X����UI</param>
        public GuideUIController(
            TValueUI valueUI,
            TOperationUI operationUI,
            TNextFocusUI nextFocusUI
        )
        {
            _valueUI    = valueUI;
            _operationUI= operationUI;
            _nextFocusUI= nextFocusUI;
        }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="valueUI">�l��UI</param>
        /// <param name="operationUI">�����UI</param>
        /// <param name="nextFocusUI">�����Ƀt�H�[�J�X����UI</param>
        /// <param name="isRangeUI">�͈͎w���UI�ł��邩�̃t���O</param>
        public GuideUIController(
            TValueUI valueUI,
            TOperationUI operationUI,
            TNextFocusUI nextFocusUI,
            bool isRangeUI
        )
        {
            _valueUI    = valueUI;
            _operationUI= operationUI;
            _nextFocusUI= nextFocusUI;
            _isRangeUI  = isRangeUI;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// ������J�n���܂��B
        /// </summary>
        public void StartControl()
        {
            // �l������΁A����Ƀt�H�[�J�X���Ȃ�
            ValueUI.ValueChanged += new EventHandler(
                delegate(object sender, EventArgs e)
                {
                    // TODO:�����P���u
                    if (!ValueUI.Text.Equals(PreviousValue))
                    {
                        PreviousValue = ValueUI.Text;
                        CanFocusOperationUI = false;
                    }
                    else
                    {
                        CanFocusOperationUI = true;
                    }
                    // �����P���u

                    // �͈͎w��̏ꍇ�A�^�u�ړ��͂��Ȃ�
                    if (IsRangeUI)
                    {
                        if (OperationUI.TabStop) OperationUI.TabStop = false;
                        return;
                    }

                    if (string.IsNullOrEmpty(ValueUI.Text.Trim()))
                    {
                        OperationUI.TabStop = true;
                    }
                    else
                    {
                        OperationUI.TabStop = false;
                    }
                }
            );

            // �����Ɏ��̃R���g���[���փt�H�[�J�X
            OperationUI.Click += new EventHandler(
                delegate(object sender, EventArgs e)
                {
                    // TODO:�����P���u
                    OperationUI.Focus();
                    
                    if (!CanFocusOperationUI)
                    {
                        NextFocusUI.Focus();
                        CanFocusOperationUI = true;
                    }
                    // �����P���u

                    // Control���p�����Ă���R���g���[�����C�x���g�\�[�X�ɂȂ�͂��c
                    try
                    {
                        if (((Control)sender).Tag == null) return;

                        bool canFocus = (bool)((Control)sender).Tag;
                        if (canFocus)
                        {
                            OperationUI.Focus();
                            ((Control)sender).Tag = false;
                        }
                        else
                        {
                            NextFocusUI.Focus();
                        }
                    }
                    catch (InvalidCastException) { }
                }
            );
        }
    }

    #region <Special Version/>

    /// <summary>
    /// ��ʓI�ȃK�C�h��UI�𐧌䂷��N���X
    /// </summary>
    public sealed class GeneralGuideUIController : GuideUIController<TextBoxType, Control, Control>
    {
        /// <summary>�R���g���[���Ƀt�H�[�J�X����t���O</summary>
        public const bool CAN_FOCUS = true;

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="valueTextBox">�l�̃e�L�X�g�{�b�N�X</param>
        /// <param name="guideButton">�K�C�h�{�^��</param>
        /// <param name="nextFocusControl">���Ƀt�H�[�J�X����R���g���[��</param>
        public GeneralGuideUIController(
            TextBoxType valueTextBox,
            Control guideButton,
            Control nextFocusControl
        ) : base(valueTextBox, guideButton, nextFocusControl)
        { }
    }

    /// <summary>
    /// ��ʓI�Ȕ͈͎w��K�C�h��UI�𐧌䂷��N���X
    /// </summary>
    public sealed class GeneralRangeGuideUIController : GuideUIController<TextBoxType, Control, Control>
    {
        /// <summary>�R���g���[���Ƀt�H�[�J�X����t���O</summary>
        public const bool CAN_FOCUS = true;

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="valueTextBox">�l�̃e�L�X�g�{�b�N�X</param>
        /// <param name="guideButton">�K�C�h�{�^��</param>
        /// <param name="nextFocusControl">���Ƀt�H�[�J�X����R���g���[��</param>
        public GeneralRangeGuideUIController(
            TextBoxType valueTextBox,
            Control guideButton,
            Control nextFocusControl
        ) : base(valueTextBox, guideButton, nextFocusControl, true)
        { }
    }

    #endregion  // <Special Version/>

    #endregion  // <�K�C�h����/>

    #region <�X�y�[�X�L�[����/>

    /// <summary>
    /// �R���g���[����KeyPress�C�x���g�̃w���p�N���X
    /// </summary>
    /// <typeparam name="TControl">�R���g���[���̌^</typeparam>
    /// <remarks>
    /// <br>Note       : �s��Ή�[5710]�ɂĒǉ�</br>
    /// <br>Programmer : 30434 �H�� �b�D</br>
    /// <br>Date       : 2008.09.30</br>
    /// </remarks>
    public abstract class ControlKeyPressEventHelper<TControl> where TControl : Control
    {
        #region <�R���g���[���̃��X�g/>

        /// <summary>�R���g���[���̃��X�g</summary>
        private readonly IList<TControl> _controlList;
        /// <summary>
        /// �R���g���[���̃��X�g���擾���܂��B
        /// </summary>
        /// <value>�R���g���[���̃��X�g</value>
        public IList<TControl> ControlList
        {
            get { return _controlList; }
        }

        #endregion  // <�R���g���[���̃��X�g/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        protected ControlKeyPressEventHelper()
        {
            _controlList = new List<TControl>();
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// �X�y�[�X�L�[�̐�����J�n���܂��B
        /// </summary>
        public void StartSpaceKeyControl()
        {
            foreach (TControl control in ControlList)
            {
                control.KeyPress += new KeyPressEventHandler(this.Control_KeyPress);
            }
        }

        #region <�C�x���g�n���h��/>

        /// <summary>
        /// �X�y�[�X�L�[�̐�����s���C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void Control_KeyPress(
            object sender,
            KeyPressEventArgs e
        )
        {
            if (e.KeyChar.Equals(' '))
            {
                ControlSpaceKey(sender, e);
            }
        }

        /// <summary>
        /// �X�y�[�X�L�[�̐�����s���C�x���g�n���h���̎���
        /// </summary>
        /// <remarks>
        /// �X�y�[�X�L�[�������ɌĂяo����܂��B
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected abstract void ControlSpaceKey(
            object sender,
            KeyPressEventArgs e
        );

        #endregion  // <�C�x���g�n���h��/>
    }

    #region <UltraOptionSet/>

    /// <summary>
    /// UltraOptionSet�R���g���[����KeyPress�C�x���g�̃w���p�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �s��Ή�[5710]�ɂĒǉ�</br>
    /// <br>Programmer : 30434 �H�� �b�D</br>
    /// <br>Date       : 2008.09.30</br>
    /// </remarks>
    public sealed class OptionSetKeyPressEventHelper : ControlKeyPressEventHelper<OptionSetType>
    {
        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public OptionSetKeyPressEventHelper() : base() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// �X�y�[�X�L�[�̐�����s���C�x���g�n���h���̎���
        /// </summary>
        /// <remarks>
        /// �X�y�[�X�L�[�������ɌĂяo����܂��B
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        [Obsolete("�ėp�I�ɂ���ɂ͗v����")]    // TODO:�ėp�I�ɂ���ɂ͗v����
        protected override void ControlSpaceKey(
            object sender,
            KeyPressEventArgs e
        )
        {
            #region <Guard Phrase/>

            if (ControlList.Count.Equals(0)) return;

            #endregion  // <Guard Phrase/>

            foreach (OptionSetType optionSet in ControlList)
            {
                // �I�����ڂ�1����
                if (optionSet.Items.Count.Equals(1))
                {
                    optionSet.Value = 0;
                    optionSet.CheckedIndex = 0;
                    optionSet.FocusedIndex = 0;
                    continue;
                }

                // �I�����ڂ�2�ȏ�i�ʏ�j
                if (optionSet.CheckedIndex.Equals(optionSet.FocusedIndex))
                {
                    int nextOptionIndex = optionSet.CheckedIndex + 1;
                    if (nextOptionIndex >= optionSet.Items.Count)
                    {
                        nextOptionIndex = 0;
                    }
                    optionSet.Value = nextOptionIndex;
                    optionSet.CheckedIndex = nextOptionIndex;
                    optionSet.FocusedIndex = nextOptionIndex;
                }
                break; // TODO:�擪����
            }
        }
    }

    #endregion  // <UltraOptionSet/>

    #region <���W�I�{�^��/>

    /// <summary>
    /// ���W�I�{�^����KeyPress�C�x���g�̃w���p�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �s��Ή�[5710]�ɂĒǉ�</br>
    /// <br>Programmer : 30434 �H�� �b�D</br>
    /// <br>Date       : 2008.09.30</br>
    /// </remarks>
    public sealed class RadioKeyPressEventHelper : ControlKeyPressEventHelper<RadioButton>
    {
        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public RadioKeyPressEventHelper() : base() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// ���݂̃R���g���[�����X�g�̃C���f�b�N�X���擾���܂��B
        /// </summary>
        /// <value>���݂̃R���g���[�����X�g�̃C���f�b�N�X</value>
        private int CurrentIndex
        {
            get
            {
                for (int i = 0; i < ControlList.Count; i++)
                {
                    if (ControlList[i].Checked) return i;
                }
                return 0;
            }
        }

        /// <summary>
        /// �X�y�[�X�L�[�̐�����s���C�x���g�n���h���̎���
        /// </summary>
        /// <remarks>
        /// �X�y�[�X�L�[�������ɌĂяo����܂��B
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected override void ControlSpaceKey(
            object sender,
            KeyPressEventArgs e
        )
        {
            #region <Guard Phrase/>

            if (ControlList.Count.Equals(0)) return;

            #endregion  // <Guard Phrase/>

            if (ControlList[CurrentIndex].Checked)
            {
                int nextIndex = CurrentIndex + 1;
                if (nextIndex >= ControlList.Count) nextIndex = 0;

                ControlList[nextIndex].Focus();
                ControlList[nextIndex].Checked = true;
            }
        }
    }

    #endregion  // <���W�I�{�^��/>

    #endregion  // <�X�y�[�X�L�[����/>
}
