using Cartridges.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.BillSer
{
    public interface IBillService
    {
        IEnumerable<Bill> GetBills();
        Bill GetBill(long id);
        void InsertBill(Bill entity);
        void UpdateBill(Bill entity);
        void DeleteBill(long id);
    }
}
