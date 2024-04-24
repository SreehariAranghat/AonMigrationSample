using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Contracts
{
    public interface IRentalDataAccess
    {
        List<RentalRecord> GetRecordsForUser(int id);
        bool HasPendingReturns(int id);

        RentalRecord NewRental(int bookId, int id);
    }
}
