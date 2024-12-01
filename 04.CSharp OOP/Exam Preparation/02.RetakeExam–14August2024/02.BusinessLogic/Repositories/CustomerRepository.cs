using CarDealership.Models.Contracts;

namespace CarDealership.Repositories
{
    internal class CustomerRepository : BaseRepository<ICustomer>
    {
        public override void Add(ICustomer customer) => this.ModelsByUniqueId[customer.Name] = customer;
    }
}
