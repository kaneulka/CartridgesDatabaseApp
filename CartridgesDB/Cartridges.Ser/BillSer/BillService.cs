using Cartridges.Data;
using Cartridges.Repo.BillRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.BillSer
{
    public class BillService : IBillService
    {
        private IBillRepo billRepository;

        public BillService(IBillRepo billRepository)
        {
            this.billRepository = billRepository;
        }
        
        public IEnumerable<Bill> GetBills()
        {
            return billRepository.GetAll();
        }

        public Bill GetBill(long id)
        {
            return billRepository.Get(id);
        }

        public void InsertBill(Bill entity)
        {
            billRepository.Insert(entity);
        }
        public void UpdateBill(Bill entity)
        {
            billRepository.Update(entity);
        }
        public void DeleteBill(long id)
        {
            Bill bill = GetBill(id);
            billRepository.Remove(bill);
            billRepository.SaveChanges();
        }
    }
}
