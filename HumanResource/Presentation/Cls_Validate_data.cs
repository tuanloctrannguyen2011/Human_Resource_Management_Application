using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Presentation
{
    public static class Cls_Validate_data
    {

        #region kiểm tra địa chỉ email
        /// <summary>
        /// kiểm tra địa chỉ eamil
        /// kiểm tra địa chỉ eamil perfect_formart: nathuong99@gmail.com hoặc abc_abc_77@gmail.com.vn
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        public static bool check_email(this TextBox email)
        {
            //string validate_eamil = @"^[a-z][a-z0-9_\.]{5,32}@[a-z]{2,}(\.[a-z]{2,4}){1,2}$";
            string vl_em2 = @"^[a-zA-Z0-9_]{3,32}@[a-zA-Z]{2,}(\.[a-zA-Z]{2,})+(\.[a-zA-Z]{2,})*$";
            return Regex.Match(email.Text, vl_em2).Success;
        }
        #endregion


        #region lấy ngày tháng năm

        /// <summary>
        /// Thứ: Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, 
        /// Tháng: January, February, March, April, May, June, July,  August, September, October, November, December
        /// năm giới hạn từ 1-1-1753 đến năm 1-1-9998
        /// chuỗi mẫu ngày tháng năm: Wednesday, September 20, 2019
        /// ở chú thích trong hàm: 
        /// => ví dụ như:  //thuộc nhóm: (5,7)-(3/4) ví dụ: Thursday, April 20, 2019
        /// Trong cặp ngoặc đầu tiên là biểu thị cho thứ
        /// Trong cặp ngoặc thứ 2 là biểu thị cho tháng 
        /// Toàn bộ hai cặp ngoặc được hiểu là: 
        /// ========> 1) Thứ 5 của tháng 3 hoặc tháng 4
        /// ========> 2) Thứ 7 của tháng 3 hoặc tháng 4
        /// Nội dung hàm ở dưới dung để lấy ra ngày tháng năm khi người dùng chọn ngày. ==================> Mục đích để phục vụ cho hai hàm khác là hàm kiểm tra ngày vào làm của nhân viên khi mới kí hợp đồng (không được là ngày trong quá khứ ) và ngày sinh của nhân viên (18+)
        /// =============
        /// lấy ngày tháng năm để phục các các hàm kiểm tra
        /// =============
        /// <param name="s"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        /// </summary>
        public static string _get_date(string s)
        {

            //string s = dtp.Value.ToLongDateString();
            string cur_date = s;
            int length_of_date = cur_date.Count();
            string date = "";
            string month = "";
            string year = "";
            if (length_of_date == 20)
            {
                // trường hợp ngày 2 số
                if ((cur_date.Substring(0, 3).ToLower().Equals("mon") && cur_date.ToLower().Contains("may")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("fri") && cur_date.ToLower().Contains("may")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("sun") && cur_date.ToLower().Contains("feb")))
                {

                    //nhóm thứ: 2,6,cn của tháng 5 : ví dụ Monday, May 20, 2019
                    date = s.Substring(20 - 8, 2);
                    month = s.Substring(8, 3);
                    year = s.Substring(20 - 4, 4);
                    return date + "=>" + month + "=>" + year;
                }


            }
            else if (length_of_date == 19)
            {
                //trường hợp ngày 1 số
                //nhóm thứ: 2,6,cn của tháng 5 : ví dụ Monday, May 1, 2019
                date = s.Substring(12, 1);
                month = s.Substring(8, 3);
                year = s.Substring(15, 4);
            }
            //===============================
            if (length_of_date == 29)
            {
                // trường hợp ngày 2 số
                // nhóm thứ: 4 của tháng 9: ví dụ Wednesday, September 20, 2019
                date = s.Substring(21, 2);
                month = s.Substring(11, 9);
                year = s.Substring(25, 4);
            }
            else if (length_of_date == 28)
            {
                // trường hợp ngày 1 số
                // nhóm thứ: 4 của tháng 9: ví dụ Wednesday, September 1, 2019
                if (cur_date.Substring(11, 3).ToLower().Equals("sep"))
                {
                    date = s.Substring(21, 1);
                    month = s.Substring(11, 9);
                    year = s.Substring(24, 4);
                    return date + "=>" + month + "=>" + year;

                }
            }
            //===============================
            if (length_of_date == 28)
            {
                // trường hợp ngày 2 số

                if (cur_date.Substring(0, 3).ToLower().Equals("wed"))
                {
                    // thuộc nhóm: thứ 4-(12/11/2) ví dụ Wednesday, December 20, 2019
                    date = s.Substring(20, 2);
                    month = s.Substring(11, 8);
                    year = s.Substring(24, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else
                {
                    // thuộc nhóm: thứ (7,5)-(9) Saturday, September 20, 2019
                    date = s.Substring(20, 2);
                    month = s.Substring(10, 9);
                    year = s.Substring(24, 4);
                    return date + "=>" + month + "=>" + year;
                }

            }
            else if (length_of_date == 27)
            {
                //trường hợp ngày 1 số
                if (
                    (cur_date.ToLower().Contains("wed") && cur_date.ToLower().Contains("nov")) || (cur_date.ToLower().Contains("wed") && cur_date.ToLower().Contains("dec")) || (cur_date.ToLower().Contains("wed") && cur_date.ToLower().Contains("feb")))
                {
                    // thuộc nhóm: thứ 4-(12/11/2) ví dụ Wednesday, December 1, 2019
                    date = s.Substring(20, 1);
                    month = s.Substring(11, 8);
                    year = s.Substring(23, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if ((cur_date.ToLower().Contains("sep") && cur_date.ToLower().Contains("sat")) ||
                    (cur_date.ToLower().Contains("sep") && cur_date.ToLower().Contains("thu")))
                {
                    // thuộc nhóm: thứ (7,5)-(9) Saturday, September 1, 2019
                    date = s.Substring(20, 1);
                    month = s.Substring(10, 9);
                    year = s.Substring(23, 4);
                    return date + "=>" + month + "=>" + year;
                }
            }
            //===============================
            if (length_of_date == 27)
            {
                //trường hợp ngày 2 số
                if (cur_date.Substring(0, 3).ToLower().Equals("wed"))
                {
                    // thuộc nhóm: thứ 4-(10/1), ví dụ: Wednesday, October 20, 2019
                    date = s.Substring(19, 2);
                    month = s.Substring(11, 7);
                    year = s.Substring(23, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if (cur_date.Substring(0, 3).ToLower().Equals("tue"))
                {
                    // thuộc nhóm: thứ 3-9, ví dụ: Tuesday, September 20, 2019
                    date = s.Substring(19, 2);
                    month = s.Substring(9, 9);
                    year = s.Substring(23, 4);
                    return date + "=>" + month + "=>" + year;

                }
                else
                {
                    // thuộc nhóm: thứ (7,5)-(12/11/2), ví dụ: Saturday, December 20, 2019
                    date = s.Substring(19, 2);
                    month = s.Substring(10, 8);
                    year = s.Substring(23, 4);
                    return date + "=>" + month + "=>" + year;


                }
            }
            else if (length_of_date == 26)
            {
                //trường hợp ngày 1 số
                if ((cur_date.Substring(0, 3).ToLower().Equals("wed") && cur_date.ToLower().Contains("oct")) || (cur_date.Substring(0, 3).ToLower().Equals("wed") && cur_date.ToLower().Contains("jan")))
                {
                    // thuộc nhóm: thứ 4-(10/1), ví dụ: Wednesday, October 1, 2019
                    date = s.Substring(19, 1);
                    month = s.Substring(11, 7);
                    year = s.Substring(22, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if (cur_date.Substring(0, 3).ToLower().Equals("tue") && cur_date.ToLower().Contains("sep"))
                {
                    // thuộc nhóm: thứ 3-9, ví dụ: Tuesday, September 1, 2019
                    date = s.Substring(19, 1);
                    month = s.Substring(9, 9);
                    year = s.Substring(22, 4);
                    return date + "=>" + month + "=>" + year;

                }
                else if ((cur_date.Substring(0, 3).ToLower().Equals("sat") && cur_date.ToLower().Contains("dec")) || (cur_date.Substring(0, 3).ToLower().Equals("sat") && cur_date.ToLower().Contains("nov")) || (cur_date.Substring(0, 3).ToLower().Equals("sat") && cur_date.ToLower().Contains("feb")) || (cur_date.Substring(0, 3).ToLower().Equals("thu") && cur_date.ToLower().Contains("nov")) || (cur_date.Substring(0, 3).ToLower().Equals("thu") && cur_date.ToLower().Contains("dec")) || (cur_date.Substring(0, 3).ToLower().Equals("thu") && cur_date.ToLower().Contains("feb")))
                {
                    // thuộc nhóm: thứ (7,5)-(12/11/2), ví dụ: Saturday, December 1, 2019
                    date = s.Substring(19, 1);
                    month = s.Substring(10, 8);
                    year = s.Substring(22, 4);
                    return date + "=>" + month + "=>" + year;

                }
            }
            //===============================
            if (length_of_date == 26)
            {
                //trường hợp ngày 2 số
                if (cur_date.Substring(0, 3).ToLower().Equals("wed"))
                {
                    // thuộc nhóm: thứ 4-8, ví dụ: Wednesday, August 20, 2019
                    date = s.Substring(18, 2);
                    month = s.Substring(11, 6);
                    year = s.Substring(22, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if (cur_date.Substring(0, 3).ToLower().Equals("sat") || cur_date.Substring(0, 3).ToLower().Equals("thu"))
                {
                    // thuộc nhóm: (7,5) -(10/1),  ví dụ: Saturday, January 20, 2019
                    date = s.Substring(18, 2);
                    month = s.Substring(10, 7);
                    year = s.Substring(22, 4);
                    return date + "=>" + month + "=>" + year;

                }
                else if (cur_date.Substring(0, 3).ToLower().Equals("tue"))
                {
                    // thuộc nhóm: 3-(12/11/2), ví dụ: Tuesday, November 20, 2019
                    date = s.Substring(18, 2);
                    month = s.Substring(9, 8);
                    year = s.Substring(22, 4);
                    return date + "=>" + month + "=>" + year;

                }
                else
                {
                    // thuộc nhóm: (2,6,CN)-9, ví dụ: Sunday, September 20, 2019
                    date = s.Substring(18, 2);
                    month = s.Substring(8, 9);
                    year = s.Substring(22, 4);
                    return date + "=>" + month + "=>" + year;
                }

            }
            else if (length_of_date == 25)
            {
                //trường hợp ngày 1 số
                if (cur_date.Substring(0, 3).ToLower().Equals("wed") && cur_date.ToLower().Contains("aug"))
                {
                    // thuộc nhóm: thứ 4-8, ví dụ: Wednesday, August 1, 2019
                    date = s.Substring(18, 1);
                    month = s.Substring(11, 6);
                    year = s.Substring(21, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if ((cur_date.Substring(0, 3).ToLower().Equals("sat") && cur_date.ToLower().Contains("oct")) || (cur_date.Substring(0, 3).ToLower().Equals("sat") && cur_date.ToLower().Contains("jan")) || (cur_date.Substring(0, 3).ToLower().Equals("thu") && cur_date.ToLower().Contains("oct")) || (cur_date.Substring(0, 3).ToLower().Equals("thu") && cur_date.ToLower().Contains("jan")))
                {
                    // thuộc nhóm: (7,5) -(10/1),  ví dụ: Saturday, January 1, 2019
                    date = s.Substring(18, 1);
                    month = s.Substring(10, 7);
                    year = s.Substring(21, 4);
                    return date + "=>" + month + "=>" + year;

                }
                else if ((cur_date.Substring(0, 3).ToLower().Equals("tue") && cur_date.ToLower().Contains("nov")) || (cur_date.Substring(0, 3).ToLower().Equals("tue") && cur_date.ToLower().Contains("dec")) || (cur_date.Substring(0, 3).ToLower().Equals("tue") && cur_date.ToLower().Contains("feb")))
                {
                    // thuộc nhóm: 3-(12/11/2), ví dụ: Tuesday, November 1, 2019
                    date = s.Substring(18, 1);
                    month = s.Substring(9, 8);
                    year = s.Substring(21, 4);
                    return date + "=>" + month + "=>" + year;

                }
                else if ((cur_date.Substring(0, 3).ToLower().Equals("mon") && cur_date.ToLower().Contains("sep")) || (cur_date.Substring(0, 3).ToLower().Equals("fri") && cur_date.ToLower().Contains("sep")) || (cur_date.Substring(0, 3).ToLower().Equals("sun") && cur_date.ToLower().Contains("sep")))
                {
                    // thuộc nhóm: (2,6,CN)-9, ví dụ: Sunday, September 1, 2019
                    date = s.Substring(18, 1);
                    month = s.Substring(8, 9);
                    year = s.Substring(21, 4);
                    return date + "=>" + month + "=>" + year;
                }
            }
            //===============================
            if (length_of_date == 25)
            {
                //trường hợp ngày 2 số
                if (cur_date.Substring(0, 3).ToLower().Equals("wed"))
                {
                    //thuộc nhóm: 4-(3/4) ví dụ: Wednesday, March 20, 2019
                    date = s.Substring(17, 2);
                    month = s.Substring(11, 5);
                    year = s.Substring(21, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if (cur_date.Substring(0, 3).ToLower().Equals("thu") || cur_date.Substring(0, 3).ToLower().Equals("sat"))
                {
                    //thuộc nhóm: (5,7)-8 ví dụ: Thursday, August 20, 2019
                    date = s.Substring(17, 2);
                    month = s.Substring(10, 6);
                    year = s.Substring(21, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if (cur_date.Substring(0, 3).ToLower().Equals("tue"))
                {
                    //thuộc nhóm: 3-(10/1) ví dụ: Tuesday, Octorber 20, 2019
                    date = s.Substring(17, 2);
                    month = s.Substring(9, 8);
                    year = s.Substring(21, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if (cur_date.Substring(0, 3).ToLower().Equals("mon") || cur_date.Substring(0, 3).ToLower().Equals("sun") || cur_date.Substring(0, 3).ToLower().Equals("fri"))
                {
                    // thuộc nhóm: (2,6,CN)-(12-11-2), ví dụ: Monday, December 20, 2019
                    date = s.Substring(17, 2);
                    month = s.Substring(8, 8);
                    year = s.Substring(21, 4);
                    return date + "=>" + month + "=>" + year;
                }

            }
            else if (length_of_date == 24)
            {
                // trường hợp ngày 1 số
                if ((cur_date.Substring(0, 3).ToLower().Equals("wed") && cur_date.ToLower().Contains("mar")) || (cur_date.Substring(0, 3).ToLower().Equals("wed") && cur_date.ToLower().Contains("apr")))
                {
                    //thuộc nhóm: 4-(3/4) ví dụ: Wednesday, March 1, 2019
                    date = s.Substring(17, 1);
                    month = s.Substring(11, 5);
                    year = s.Substring(20, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if ((cur_date.Substring(0, 3).ToLower().Equals("thu") && cur_date.ToLower().Contains("aug")) || (cur_date.Substring(0, 3).ToLower().Equals("sat") && cur_date.ToLower().Contains("aug")))
                {
                    //thuộc nhóm: (5,7)-8 ví dụ: Thursday, August 2, 2019
                    date = s.Substring(17, 1);
                    month = s.Substring(10, 6);
                    year = s.Substring(20, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if ((cur_date.Substring(0, 3).ToLower().Equals("tue") && cur_date.ToLower().Contains("oct")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("tue") && cur_date.ToLower().Contains("jan"))
                    )
                {
                    //thuộc nhóm: 3-(10/1) ví dụ: Tuesday, Octorber 2, 2019
                    date = s.Substring(17, 1);
                    month = s.Substring(9, 8);
                    year = s.Substring(20, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if ((cur_date.Substring(0, 3).ToLower().Equals("mon") && cur_date.ToLower().Contains("feb")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("fri") && cur_date.ToLower().Contains("feb")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("sun") && cur_date.ToLower().Contains("feb")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("mon") && cur_date.ToLower().Contains("dec")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("fri") && cur_date.ToLower().Contains("dec")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("sun") && cur_date.ToLower().Contains("dec")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("mon") && cur_date.ToLower().Contains("nov")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("fri") && cur_date.ToLower().Contains("nov")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("sun") && cur_date.ToLower().Contains("nov"))

                    )
                {
                    // thuộc nhóm: (2,6,CN)-(12-11-2), ví dụ: Monday, December 2, 2019
                    date = s.Substring(17, 1);
                    month = s.Substring(8, 8);
                    year = s.Substring(20, 4);
                    return date + "=>" + month + "=>" + year;
                }
            }
            //===============================
            if (length_of_date == 24)
            {
                // trường hợp ngày có 2 chữ số
                if (cur_date.Substring(0, 3).ToLower().Equals("wed"))
                {
                    //thuộc nhóm: 4-(6/7) ví dụ: Wednesday, june 20, 2019
                    date = s.Substring(16, 2);
                    month = s.Substring(11, 4);
                    year = s.Substring(20, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if (cur_date.Substring(0, 3).ToLower().Equals("thu") || cur_date.Substring(0, 3).ToLower().Equals("sat"))
                {
                    //thuộc nhóm: (5,7)-(3/4) ví dụ: Thursday, April 20, 2019
                    date = s.Substring(16, 2);
                    month = s.Substring(10, 5);
                    year = s.Substring(20, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if (cur_date.Substring(0, 3).ToLower().Equals("tue"))
                {
                    //thuộc nhóm: 3-8 ví dụ: Tuesday, August 20, 2019
                    date = s.Substring(16, 2);
                    month = s.Substring(9, 6);
                    year = s.Substring(20, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if (cur_date.Substring(0, 3).ToLower().Equals("mon") || cur_date.Substring(0, 3).ToLower().Equals("sun") || cur_date.Substring(0, 3).ToLower().Equals("fri"))
                {
                    // thuộc nhóm: (2,6,CN)-(10/1), ví dụ: Monday, October 20, 2019
                    date = s.Substring(16, 2);
                    month = s.Substring(8, 7);
                    year = s.Substring(20, 4);
                    return date + "=>" + month + "=>" + year;
                }
            }
            else if (length_of_date == 23)
            {
                // trường hợp ngày có 1 chữ số
                if ((cur_date.Substring(0, 3).ToLower().Equals("wed") && cur_date.ToLower().Contains("june")) || (cur_date.Substring(0, 3).ToLower().Equals("wed") && cur_date.ToLower().Contains("july")))
                {
                    //thuộc nhóm: 4-(6/7) ví dụ: Wednesday, june 2, 2019
                    date = s.Substring(16, 1);
                    month = s.Substring(11, 4);
                    year = s.Substring(19, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if ((cur_date.Substring(0, 3).ToLower().Equals("thu") && cur_date.ToLower().Contains("mar")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("sat") && cur_date.ToLower().Contains("mar")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("thu") && cur_date.ToLower().Contains("apr")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("sat") && cur_date.ToLower().Contains("apr")))
                {
                    //thuộc nhóm: (5,7)-(3/4) ví dụ: Thursday, April 2, 2019
                    date = s.Substring(16, 1);
                    month = s.Substring(10, 5);
                    year = s.Substring(19, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if ((cur_date.Substring(0, 3).ToLower().Equals("tue") && cur_date.ToLower().Contains("aug")))
                {
                    //thuộc nhóm: 3-8 ví dụ: Tuesday, August 2, 2019
                    date = s.Substring(16, 1);
                    month = s.Substring(9, 6);
                    year = s.Substring(19, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if ((cur_date.Substring(0, 3).ToLower().Equals("mon") && cur_date.ToLower().Contains("oct")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("fri") && cur_date.ToLower().Contains("jan")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("sun") && cur_date.ToLower().Contains("oct")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("mon") && cur_date.ToLower().Contains("jan")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("fri") && cur_date.ToLower().Contains("oct")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("sun") && cur_date.ToLower().Contains("jan"))
                    )
                {
                    // thuộc nhóm: (2,6,CN)-(10/1), ví dụ: Monday, October 20, 2019
                    date = s.Substring(16, 1);
                    month = s.Substring(8, 7);
                    year = s.Substring(19, 4);
                    return date + "=>" + month + "=>" + year;
                }
            }
            //==============================
            if (length_of_date == 23)
            {
                // trường hợp ngày có 2 chữ số
                if (cur_date.Substring(0, 3).ToLower().Equals("wed"))
                {
                    //thuộc nhóm: 4-5 ví dụ: Wednesday, May 20, 2019
                    date = s.Substring(15, 2);
                    month = s.Substring(11, 3);
                    year = s.Substring(19, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if (cur_date.Substring(0, 3).ToLower().Equals("thu") || cur_date.Substring(0, 3).ToLower().Equals("sat"))
                {
                    //thuộc nhóm: (5,7)-(6/7) ví dụ: Thursday, June 20, 2019
                    date = s.Substring(15, 2);
                    month = s.Substring(10, 4);
                    year = s.Substring(19, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if (cur_date.Substring(0, 3).ToLower().Equals("tue"))
                {
                    //thuộc nhóm: 3-(3/4) ví dụ: Tuesday, April 20, 2019
                    date = s.Substring(15, 2);
                    month = s.Substring(9, 5);
                    year = s.Substring(19, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if (cur_date.Substring(0, 3).ToLower().Equals("mon") || cur_date.Substring(0, 3).ToLower().Equals("sun") || cur_date.Substring(0, 3).ToLower().Equals("fri"))
                {
                    // thuộc nhóm: (2,6,CN)-8, ví dụ: Monday, August 20, 2019
                    date = s.Substring(15, 2);
                    month = s.Substring(8, 6);
                    year = s.Substring(19, 4);
                    return date + "=>" + month + "=>" + year;
                }
            }
            else if (length_of_date == 22)
            {
                // trườn hợp ngày có 1 chữ số
                if (cur_date.Substring(0, 3).ToLower().Equals("wed") && cur_date.ToLower().Contains("may"))
                {
                    //thuộc nhóm: 4-5 ví dụ: Wednesday, May 2, 2019
                    date = s.Substring(15, 1);
                    month = s.Substring(11, 3);
                    year = s.Substring(18, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if ((cur_date.Substring(0, 3).ToLower().Equals("thu") && cur_date.ToLower().Contains("june")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("sat") && cur_date.ToLower().Contains("june")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("thu") && cur_date.ToLower().Contains("july")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("sat") && cur_date.ToLower().Contains("july")))
                {
                    //thuộc nhóm: (5,7)-(6/7) ví dụ: Thursday, June 2, 2019
                    date = s.Substring(15, 1);
                    month = s.Substring(10, 4);
                    year = s.Substring(18, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if ((cur_date.Substring(0, 3).ToLower().Equals("tue") && cur_date.ToLower().Contains("mar")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("tue") && cur_date.ToLower().Contains("apr")))
                {
                    //thuộc nhóm: 3-(3/4) ví dụ: Tuesday, April 2, 2019
                    date = s.Substring(15, 1);
                    month = s.Substring(9, 5);
                    year = s.Substring(18, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if ((cur_date.Substring(0, 3).ToLower().Equals("fri") && cur_date.ToLower().Contains("aug")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("mon") && cur_date.ToLower().Contains("aug")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("sun") && cur_date.ToLower().Contains("aug")))
                {
                    // thuộc nhóm: (2,6,CN)-8, ví dụ: Monday, August 2, 2019
                    date = s.Substring(15, 1);
                    month = s.Substring(8, 6);
                    year = s.Substring(18, 4);
                    return date + "=>" + month + "=>" + year;
                }
            }
            //===============================
            if (length_of_date == 22)
            {
                // trường hợp ngày có 2 chữ số
                if (cur_date.Substring(0, 3).ToLower().Equals("thu") || cur_date.Substring(0, 3).ToLower().Equals("sat"))
                {
                    //thuộc nhóm: (5,7)-5 ví dụ: Thursday, May 20, 2019
                    date = s.Substring(14, 2);
                    month = s.Substring(10, 3);
                    year = s.Substring(18, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if (cur_date.Substring(0, 3).ToLower().Equals("tue"))
                {
                    //thuộc nhóm: 3-(6/7) ví dụ: Tuesday, July 20, 2019
                    date = s.Substring(14, 2);
                    month = s.Substring(9, 4);
                    year = s.Substring(18, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if (cur_date.Substring(0, 3).ToLower().Equals("mon") || cur_date.Substring(0, 3).ToLower().Equals("sun") || cur_date.Substring(0, 3).ToLower().Equals("fri"))
                {
                    // thuộc nhóm: (2,6,CN)-(3/4), ví dụ: Monday, April 20, 2019
                    date = s.Substring(14, 2);
                    month = s.Substring(8, 5);
                    year = s.Substring(18, 4);
                    return date + "=>" + month + "=>" + year;
                }
            }
            else if (length_of_date == 21)
            {
                // trường hợp ngày có 1 chữ số
                if ((cur_date.Substring(0, 3).ToLower().Equals("thu") && cur_date.ToLower().Contains("may")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("sat") && cur_date.ToLower().Contains("may")))
                {
                    //thuộc nhóm: (5,7)-5 ví dụ: Thursday, May 2, 2019
                    date = s.Substring(14, 1);
                    month = s.Substring(10, 3);
                    year = s.Substring(17, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if ((cur_date.Substring(0, 3).ToLower().Equals("tue") && cur_date.ToLower().Contains("june")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("tue") && cur_date.ToLower().Contains("july")))
                {
                    //thuộc nhóm: 3-(6/7) ví dụ: Tuesday, July 2, 2019
                    date = s.Substring(14, 1);
                    month = s.Substring(9, 4);
                    year = s.Substring(17, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if ((cur_date.Substring(0, 3).ToLower().Equals("mon") && cur_date.ToLower().Contains("mar")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("fri") && cur_date.ToLower().Contains("mar")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("sun") && cur_date.ToLower().Contains("mar")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("mon") && cur_date.ToLower().Contains("apr")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("fri") && cur_date.ToLower().Contains("apr")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("sun") && cur_date.ToLower().Contains("apr")))
                {
                    // thuộc nhóm: (2,6,CN)-(3/4), ví dụ: Monday, April 2, 2019
                    date = s.Substring(14, 1);
                    month = s.Substring(8, 5);
                    year = s.Substring(17, 4);
                    return date + "=>" + month + "=>" + year;
                }
            }
            //===============================
            if (length_of_date == 21)
            {
                // trường hợp ngày có 2 số
                if (cur_date.Substring(0, 3).ToLower().Equals("tue"))
                {
                    //thuộc nhóm: 3-5 ví dụ: Tuesday, May 20, 2019
                    date = s.Substring(13, 2);
                    month = s.Substring(9, 3);
                    year = s.Substring(17, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if (cur_date.Substring(0, 3).ToLower().Equals("mon") || cur_date.Substring(0, 3).ToLower().Equals("sun") || cur_date.Substring(0, 3).ToLower().Equals("fri"))
                {
                    // thuộc nhóm: (2,6,CN)-(6/7), ví dụ: Monday, June 20, 2019
                    date = s.Substring(13, 2);
                    month = s.Substring(8, 4);
                    year = s.Substring(17, 4);
                    return date + "=>" + month + "=>" + year;
                }
            }
            else if (length_of_date == 20)
            {
                // trường hợp ngày có 1 số
                if (cur_date.Substring(0, 3).ToLower().Equals("tue"))
                {
                    //thuộc nhóm: 3-5 ví dụ: Tuesday, May 2, 2019
                    date = s.Substring(13, 1);
                    month = s.Substring(9, 3);
                    year = s.Substring(16, 4);
                    return date + "=>" + month + "=>" + year;
                }
                else if ((cur_date.Substring(0, 3).ToLower().Equals("mon") && cur_date.ToLower().Contains("june")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("fri") && cur_date.ToLower().Contains("june")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("sun") && cur_date.ToLower().Contains("june")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("mon") && cur_date.ToLower().Contains("july")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("fri") && cur_date.ToLower().Contains("july")) ||
                    (cur_date.Substring(0, 3).ToLower().Equals("sun") && cur_date.ToLower().Contains("july"))
                    )
                {
                    // thuộc nhóm: (2,6,CN)-(6/7), ví dụ: Monday, June 2, 2019
                    date = s.Substring(13, 1);
                    month = s.Substring(8, 4);
                    year = s.Substring(16, 4);
                    return date + "=>" + month + "=>" + year;
                }
            }
            return date + "=>" + month + "=>" + year;


        }
        #endregion

        #region kiểm tra ngày vào làm của nhân viên
        /// <summary>
        /// kiểm tra ngày bắt đầu làm của nhân viên kí hợp dồng mói
        /// </summary>
        /// <param name="_year_of_input"></param>
        /// <param name="_year_of_today"></param>
        /// <param name="_month_ip"></param>
        /// <param name="_month_td"></param>
        /// <param name="_day_input"></param>
        /// <param name="_day_today"></param>
        /// <returns></returns>
        public static bool validate_begin_start_in_contract(string _year_of_input, string _year_of_today, int _month_ip, int _month_td, int _day_input, int _day_today)
        {
            bool check = false;
            if (int.Parse(_year_of_input) > int.Parse(_year_of_today))
            {
                check = true;

            }
            else if (int.Parse(_year_of_input) < int.Parse(_year_of_today))
            {
                check = false;

            }
            else
            {
                if (_month_ip > _month_td)
                {
                    check = true;
                }
                else if (_month_ip < _month_td)
                {
                    check = false;
                }
                else
                {
                    if (_day_input >= _day_today)
                    {
                        check = true;
                    }
                    else if (_day_input < _day_today)
                    {
                        check = false;
                    }
                }

            }
            return check;
        }
        #endregion

        #region kiểm tra ngày tháng năm( tuổi 18+)
        /// <summary>
        /// Hàm kiểm tra ngày tháng năm,
        /// nếu truyền vào option_check là "begin_job" check ngày vào làm 
        /// của nhân viên trong công ty hay ngày start trong hợp đồng
        /// 
        /// nếu truyền vào là birthday thì sẽ kiểm tra tuổi hay ngày sinh của nhân viên
        /// phải từ 18+ trở lên thì mới được vào công ty làm việc
        /// truyền vào ngày tháng có định dạng "ToLongDateString()"
        /// </summary>
        /// <param name="option_check"></param>
        public static bool validate_datetime(string option_check, string _datetime_input, string _date_time_today)
        {

            // MessageBox.Show(_get_date(dateTimePicker2.Value.ToLongDateString()));
            // biến tạm để sử lý
            string sDay = "";
            string sMonth = "";

            //lấy nguyên ngày
            string _input = _get_date(_datetime_input);
            string _today = _get_date(_date_time_today);

            //lấy năm
            int index_begin_split_year_of_today = _today.LastIndexOf(">") + 1;
            int index_begin_split_year_of_input = _input.LastIndexOf(">") + 1;
            string _year_of_today = _today.Substring(index_begin_split_year_of_today, 4);
            string _year_of_input = _input.Substring(index_begin_split_year_of_input, 4);

            //lấy tháng
            int index_begin_split_month_of_today = _today.IndexOf(">") + 1;
            int index_begin_split_month_of_input = _input.IndexOf(">") + 1;
            int _month_td = 0;
            int _month_ip = 0;

            string _month_of_today = _today.Substring(index_begin_split_month_of_today, 3).ToLower();
            string _month_of_input = _input.Substring(index_begin_split_month_of_input, 3).ToLower();
            sMonth = _month_of_today;
            if (sMonth.Equals("jan"))
            {
                _month_td = 1;
            }
            else if (sMonth.Equals("feb"))
            {
                _month_td = 2;
            }
            else if (sMonth.Equals("mar"))
            {
                _month_td = 3;
            }
            else if (sMonth.Equals("apr"))
            {
                _month_td = 4;
            }
            else if (sMonth.Equals("may"))
            {
                _month_td = 5;
            }
            else if (sMonth.Equals("jun"))
            {
                _month_td = 6;
            }
            else if (sMonth.Equals("jul"))
            {
                _month_td = 7;
            }
            else if (sMonth.Equals("aug"))
            {
                _month_td = 8;
            }
            else if (sMonth.Equals("sep"))
            {
                _month_td = 9;
            }
            else if (sMonth.Equals("oct"))
            {
                _month_td = 10;
            }
            else if (sMonth.Equals("nov"))
            {
                _month_td = 11;
            }
            else if (sMonth.Equals("dec"))
            {
                _month_td = 12;
            }


            sMonth = _month_of_input;
            if (sMonth.Equals("jan"))
            {
                _month_ip = 1;
            }
            else if (sMonth.Equals("feb"))
            {
                _month_ip = 2;
            }
            else if (sMonth.Equals("mar"))
            {
                _month_ip = 3;
            }
            else if (sMonth.Equals("apr"))
            {
                _month_ip = 4;
            }
            else if (sMonth.Equals("may"))
            {
                _month_ip = 5;
            }
            else if (sMonth.Equals("jun"))
            {
                _month_ip = 6;
            }
            else if (sMonth.Equals("jul"))
            {
                _month_ip = 7;
            }
            else if (sMonth.Equals("aug"))
            {
                _month_ip = 8;
            }
            else if (sMonth.Equals("sep"))
            {
                _month_ip = 9;
            }
            else if (sMonth.Equals("oct"))
            {
                _month_ip = 10;
            }
            else if (sMonth.Equals("nov"))
            {
                _month_ip = 11;
            }
            else if (sMonth.Equals("dec"))
            {
                _month_ip = 12;
            }

            //phần lấy ngày
            int _day_input = 0;
            int _day_today = 0;
            sDay = _today;
            int i = 0;
            while (i <= sDay.Length)
            {
                try
                {
                    if (sDay.Substring(i, 2).Equals("=>"))
                    {
                        if (i == 2)
                        {
                            _day_today = int.Parse(sDay.Substring(0, 2));
                        }
                        if (i == 1)
                        {
                            _day_today = int.Parse(sDay.Substring(0, 1));
                        }

                        i = sDay.Length;
                    }
                }
                catch
                {


                }
                i += 1;
            }

            sDay = _input;
            i = 0;
            while (i <= sDay.Length)
            {
                try
                {
                    if (sDay.Substring(i, 2).Equals("=>"))
                    {
                        if (i == 2)
                        {
                            _day_input = int.Parse(sDay.Substring(0, 2));
                        }
                        if (i == 1)
                        {
                            _day_input = int.Parse(sDay.Substring(0, 1));
                        }

                        i = sDay.Length;
                    }
                }
                catch
                {


                }
                i += 1;
            }

            if (option_check.Equals("begin_job"))
            {
                return (validate_begin_start_in_contract(_year_of_input, _year_of_today, _month_ip, _month_td, _day_input, _day_today));
            }
            else if (option_check.Equals("birthday"))
            {
                return (validate_birthday(_year_of_today, _year_of_input));
            }

            return false;
        }

        #endregion

        #region

        /// <summary>
        /// hàm kiểm tra tuổi(18+)
        /// </summary>
        /// <param name="_year_of_today"></param>
        /// <param name="_year_of_input"></param>
        /// <returns></returns>
        public static bool validate_birthday(string _year_of_today, string _year_of_input)
        {
            // phần kiểm tra ngày sinh
            bool check_ns = false;
            if (int.Parse(_year_of_today) - int.Parse(_year_of_input) >= 18)
            {
                check_ns = true;
            }
            return check_ns;
        }
        #endregion

        #region kiểm tra tên
        public static bool check_name_staff(TextBox txb)
        {
            //string reg = @"^[a-zA-Z]{2,6}\s?([a-zA-Z]{1,6}\s?)*$";
            string reg = @"^[a-zA-Z\sÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ]+$";
            return Regex.Match(txb.Text, reg).Success;
        }
        #endregion

        #region kiểm tra lương
        //kiểm tra định dang tiền lương chỉ cho phép nhập số
        public static bool check_salary(TextBox txb_salary)
        {
            return Regex.Match(txb_salary.Text, @"^\d+$").Success;
        }
        #endregion
        
    }
}
