using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HomeWork.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public override void Delete(客戶銀行資訊 entity)
        {
            entity.是否已刪除 = true;
        }

        public override IQueryable<客戶銀行資訊> All()
        {
            return base.All().Where(p=>p.是否已刪除 != true);
        }

        public IQueryable<客戶銀行資訊> All(bool isAll)
        {
            if (isAll)
            {
                return base.All();
            }
            else
            {
                return this.All();
            }
        }

        public 客戶銀行資訊 Find(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }
    }

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}