using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HomeWork.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public override void Delete(客戶資料 entity)
        {
            entity.是否已刪除 = true;
        }

        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p => p.是否已刪除 != true);
        }

        public IQueryable<客戶資料> All(bool isAll)
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

        public 客戶資料 Find(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}