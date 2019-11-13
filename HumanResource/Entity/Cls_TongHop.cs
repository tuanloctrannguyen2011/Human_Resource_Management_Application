using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;

namespace Entity
{
    public class Cls_TongHop
    {
        private Cls_Account acc;
        private Cls_Staff stf;
        private Cls_StaffContract stfct;
        private Cls_Contract ct;
        private Cls_Department dptm;
        private Cls_JobTitle jbtt;
        private Cls_Shiff shf;
        private Cls_Eveluate evel;
       

        public Cls_Account Acc { get => acc; set => acc = value; }
        public Cls_Staff Stf { get => stf; set => stf = value; }
        public Cls_StaffContract Stfct { get => stfct; set => stfct = value; }
        public Cls_Contract Ct { get => ct; set => ct = value; }
        public Cls_Department Dptm { get => dptm; set => dptm = value; }
        public Cls_JobTitle Jbtt { get => jbtt; set => jbtt = value; }
        public Cls_Shiff Shf { get => shf; set => shf = value; }
        public Cls_Eveluate Evel { get => evel; set => evel = value; }
    
        public Cls_TongHop()
        {
                    
        }
        public Cls_TongHop(Cls_Account ACC, Cls_Staff STF, Cls_StaffContract STFCT, Cls_Contract CT, Cls_Department DPTM, Cls_JobTitle JBTT, Cls_Shiff SHF, Cls_Eveluate EVEL)
        {
            this.Acc = ACC;
            this.Stf = STF;
            this.stfct = STFCT;
            this.Ct = CT;
            this.Dptm = DPTM;
            this.Jbtt = JBTT;
            this.Shf = SHF;
            this.Evel = EVEL;
           
        }
    }
}
