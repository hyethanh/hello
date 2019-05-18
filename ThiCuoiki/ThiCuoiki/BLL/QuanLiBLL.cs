using ThiCuoiki.DAL;
using ThiCuoiki.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ThiCuoiki.BLL
{
    
    public class QuanLiBLL
    {
        QuanLiDAL dal = new QuanLiDAL();
        public List<object> GetListBLL()
        {
            return dal.GetListDAL();
        }
        public MuonTra GetMuonTraBLL(string s)
        {
            return dal.GetMuonTraDAL(s);
        }
        public void DelMuonTraBLL(string s)
        {
            dal.DelMuonTraDAL(s);
        }
        public void AddMuonTraBLL(MuonTra mt)
        {
            dal.AddMuonTraDAL(mt);
        }
        public void UpdateMuonTraBLL(MuonTra mt)
        {
            dal.UpdateMuonTraDAL(mt);
        }
        public List<object> SortMuonTraBLL(string s)
        {
            return dal.SortMuonTraDAL(s);
        }
        public List<object> TimKiemMuonTraBLL(string s1, string s2)
        {
            return dal.TimKiemMuonTraDAL(s1, s2);
        }
    }
}
