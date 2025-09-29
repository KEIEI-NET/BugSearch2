using System;
using System.Collections;
using System.Text;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// List ���[�e�B���e�B�N���X
    /// </summary>
    public class ListUtils
    {
        /// <summary>�����p�^�[�� Find() �Ŏg�p</summary>
        public enum FindType
        {
            /// <summary>�N���X</summary>
            Class,
            /// <summary>Array</summary>
            Array
        }

        /// <summary>
        /// CustomArrayList ����w�肵���^�̃I�u�W�F�N�g���擾����
        /// </summary>
        /// <param name="paramArray">�����Ώۃp�����[�^List</param>
        /// <param name="type">�����Ώۃ^�C�v</param>
        /// <param name="pattern">�����p�^�[��</param>
        /// <param name="position">�p�����[�^�ʒu</param>
        /// <returns>�I�u�W�F�N�g</returns>
        public static object Find(ArrayList paramArray, Type type, FindType pattern, out int position)
        {
            object result = null;

            position = -1;

            if (IsNotEmpty(paramArray))
            {
                //�p�����[�^���擾
                if (pattern == FindType.Class)
                {
                    for (int i = 0; i < paramArray.Count; i++)
                    {
                        if (paramArray[i] != null && paramArray[i].GetType() == type)
                        {
                            result = paramArray[i];
                            position = i;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < paramArray.Count; i++)
                    {
                        if (paramArray[i] is ArrayList)
                        {
                            ArrayList al = paramArray[i] as ArrayList;
                            if (al != null && al.Count > 0)
                            {
                                if (al[0] != null && al[0].GetType() == type)
                                {
                                    result = paramArray[i];
                                    position = i;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            
            return result;
        }

        /// <summary>
        /// CustomArrayList ����w�肵���^�̃I�u�W�F�N�g���擾����
        /// </summary>
        /// <param name="paramArray">�����Ώۃp�����[�^List</param>
        /// <param name="type">�����Ώۃ^�C�v</param>
        /// <param name="pattern">�����p�^�[��</param>
        /// <returns>�I�u�W�F�N�g</returns>
        public static object Find(ArrayList paramArray, Type type, FindType pattern)
        {
            int position;
            return Find(paramArray, type, pattern, out position);
        }

        /// <summary>
        /// ArrayList���󂩂ǂ����𔻒f����
        /// </summary>
        /// <param name="al">�����Ώ�ArrayList</param>
        /// <returns>true:�� false:��łȂ�</returns>
        public static bool IsEmpty(ArrayList al)
        {
            if (al == null || al.Count <= 0) return true;
            return false;
        }

        /// <summary>
        /// ArrayList���󂩂ǂ����𔻒f����
        /// </summary>
        /// <param name="al">�����Ώ�ArrayList</param>
        /// <returns>true:��łȂ� false:��</returns>
        public static bool IsNotEmpty(ArrayList al)
        {
            return !IsEmpty(al);
        }
    }
}
