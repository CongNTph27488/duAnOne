using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.pl.Utilities
{
    public class Utility
    {
        public static string ZenMaTuDong(string fullName)
        {
            string temp = fullName.Trim().ToLower();//nguyễn anh dũng
            string[] arrValues = temp.Split(' ');// Cắt chuỗi thành mảng
            string final = GetVietHoaChuCaiDau(arrValues[arrValues.Length - 1]).Trim();//Dũng
            for (int i = 0; i < arrValues.Length - 1; i++)
            {
                final += GetChuCaiDau(arrValues[i]);
            }
            return LoaiBoDauTiengViet(final);//Dungna
        }
        public static string ZenAuto(string name)
        {
            string temp=name.Trim().ToLower();
            string[] arr = temp.Split(' ');
            string final = "";
            for(int i = 0; i < arr.Length - 1; i++)
            {
                final+=GetHoaChuCaiDau(arr[i]);
            }
            return final;
        }
        //Phương thức viết hoa tự động: NGUYỄN anh Dũng => Nguyễn Anh Dũng
        public static string VietHoaFullName(string fullName)
        {
            string temp = fullName.Trim().ToLower();//nguyễn anh dũng
            string[] arrValues = temp.Split(' ');// Cắt chuỗi thành mảng
            string final = "";
            for (int i = 0; i < arrValues.Length; i++)
            {
                final += GetVietHoaChuCaiDau(arrValues[i]);
            }
            return final;//Nguyễn Anh Dũng
        }

        private static string GetChuCaiDau(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            return Convert.ToString(value[0]);
        }
        public static string GetHoaChuCaiDau(string value)
        {
            string temp=value.Trim().ToLower();
            string[] arrValues = temp.Split(' ');
            string final = Convert.ToString(arrValues[value[0]]).ToUpper() + value.Substring(1)+" ";
            return final;
        }

        public static string GetVietHoaChuCaiDau(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            return Convert.ToString(value[0]).ToUpper() + value.Substring(1) + " ";
        }

        private static string LoaiBoDauTiengViet(string str)
        {
            string strFormD = str.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strFormD.Length; i++)
            {
                System.Globalization.UnicodeCategory uc =
                    System.Globalization.CharUnicodeInfo.GetUnicodeCategory(strFormD[i]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(strFormD[i]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }
    }
}
