using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DevOne.Security.Cryptography.BCrypt;

namespace Data
{
    public class Cls_Evaluate_DAL
    {
        DBDataContext DB;
        public Cls_Evaluate_DAL()
        {
            DB = new DBDataContext();
        }
        public Cls_Eveluate Get_Eveluate_staff(string id)
        {
            Cls_Eveluate ev_c = new Cls_Eveluate();
            Evaluation ev = DB.Evaluations.Where(x => x.staff_id.Equals(id.Trim()) == true).FirstOrDefault();
            if (ev != null)
            {
                ev_c.Id_eva = ev.eva_id;
                ev_c.Eva_desc = ev.eva_desc;
                ev_c.Eva_type = ev.eva_desc;
                ev_c.Id_staff = ev.staff_id;
                ev_c.Eva_date = ev.eva_date;
            }
          
            return ev_c;
        }

        public List<Cls_Eveluate> list_eve(string id_staff)
        {
            List<Cls_Eveluate> list_danhgia = new List<Cls_Eveluate>();
            IEnumerable<Evaluation> lt_dg = (from a in DB.Evaluations
                                             join b in DB.Staffs
                                             on a.staff_id equals b.staff_id
                                             where a.staff_id.Equals(id_staff.Trim()) == true
                                             select a).ToList<Evaluation>();
            foreach( Evaluation a in lt_dg)
            {
                Cls_Eveluate b = new Cls_Eveluate();
                b.Id_eva = a.eva_id;
                b.Eva_type = a.eva_type;
                b.Eva_desc = a.eva_desc;
                b.Id_staff = a.staff_id;
                b.Eva_date = a.eva_date;
                list_danhgia.Add(b);
            }
            return list_danhgia;
        }

        public long genaration_id_evaluate()
        {
            long id = 0;
            long id_temp = 0;
            IEnumerable<Evaluation> l_id = (from a in DB.Evaluations
                                            select a).ToList<Evaluation>();
            foreach(Evaluation a in l_id)
            {
                id_temp = long.Parse(a.eva_id);
            }
            id = ++id_temp;
            return id;
          
        }

        public bool insert_evaluate(Cls_Eveluate evaluate)
        {
            if(evaluate.Id_eva.Trim().Equals("")!=true && evaluate.Id_staff.Trim().Equals("") != true)
            {
                try
                {
                    Evaluation eva = new Evaluation();
                    eva.eva_date = (DateTime)evaluate.Eva_date;
                    eva.eva_desc = evaluate.Eva_desc;
                    eva.eva_id = evaluate.Id_eva;
                    eva.staff_id = evaluate.Id_staff;
                    if(evaluate.Eva_type.ToLower().Equals("kỷ luật") == true)
                    {
                        eva.eva_type = "bad";
                    }
                    else if(evaluate.Eva_type.ToLower().Equals("khen thưởng") == true)
                    {
                        eva.eva_type = "good";
                    }
                    DB.Evaluations.InsertOnSubmit(eva);
                    DB.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
            return false;
        }

        public bool get_eva_by_id_eva(string id)
        {
            Evaluation a = DB.Evaluations.Where(x => x.eva_id.Equals(id) == true).FirstOrDefault();
            if (a == null)
            {
                return true;
            }
            return false;
        }
    }
}
