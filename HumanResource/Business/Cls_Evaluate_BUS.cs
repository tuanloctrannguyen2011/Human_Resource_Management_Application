using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;
using DevOne.Security.Cryptography.BCrypt;

namespace Business
{
    public class Cls_Evaluate_BUS
    {
        Cls_Evaluate_DAL cls_eveluate_DAL1;
        public Cls_Evaluate_BUS()
        {
            cls_eveluate_DAL1 = new Cls_Evaluate_DAL();
        }
        public Cls_Eveluate Get_Eveluate_staff_BUS(string id)
        {
            return cls_eveluate_DAL1.Get_Eveluate_staff(id);
        }

        public List<Cls_Eveluate> list_eve_BUS(string id_staff)
        {
            return cls_eveluate_DAL1.list_eve(id_staff);
        }
        public string genaration_id_evaluate_BUS()
        {

            string id = "";
            long check = cls_eveluate_DAL1.genaration_id_evaluate();
            long d = check.ToString().Length;

            if (d == 1)
            {
                id = "000000000" + check.ToString();

            }
            if (d == 2)
            {
                id = "00000000" + check.ToString();

            }
            if (d == 3)
            {
                id = "0000000" + check.ToString();

            }
            if (d == 4)
            {
                id = "000000" + check.ToString();

            }
            if (d == 5)
            {
                id = "00000" + check.ToString();

            }
            if (d == 6)
            {
                id = "0000" + check.ToString();

            }
            if (d == 7)
            {
                id = "000" + check.ToString();

            }
            if (d == 8)
            {
                id = "00" + check.ToString();

            }
            if (d == 9)
            {
                id = "0" + check.ToString();

            }
            if (d > 10)
            {
                id = "";
            }
            return id;
        }


      
        public bool insert_evaluate_bus(Cls_Eveluate evaluate)
        {
            bool check_id = cls_eveluate_DAL1.get_eva_by_id_eva(evaluate.Id_eva);
            if (check_id==true)
            {
                return cls_eveluate_DAL1.insert_evaluate(evaluate);
            }
            return false;

        }
    }
}
