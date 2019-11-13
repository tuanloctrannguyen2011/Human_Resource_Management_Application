using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;

namespace Presentation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Frm_Login frm_lg = new Frm_Login();
            if (frm_lg.ShowDialog() == DialogResult.OK)
            {
                Cls_Account account1 = frm_lg.obj_dn;
                //Application.Run(new Frm_Main(account1));
                Frm_Main frm_main = new Frm_Main(account1);
                //Application.Run(frm_main);
                if (frm_main.ShowDialog() == DialogResult.Yes)
                {
                    Application.Restart();
                    //System.Environment.Exit();
                }

            }

            #region thử đăng xuẩ bằng cách khác

            //using (Frm_Login frm_login = new Frm_Login())
            //{

            //    while (frm_login.ShowDialog() == DialogResult.OK)
            //    {
            //        Cls_Account account = frm_login.obj_dn;
            //        using (Frm_Main frm_Main=new Frm_Main(account))
            //        {

            //           // Application.Run(frm_Main);
            //            if (frm_Main.ShowDialog() == DialogResult.Yes)
            //            {
            //                frm_login.ShowDialog();

            //            }

            //        }

            //    }
            //}

            #endregion
            //Application.Run(new Frm_Danhgia());
        }
    }
}
