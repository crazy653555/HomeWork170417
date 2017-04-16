using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HomeWork.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override void Delete(客戶聯絡人 entity)
        {
            entity.是否已刪除 = true;
        }

        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(p => p.是否已刪除 != true);
        }

        public IQueryable<客戶聯絡人> All(bool isAll )
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

        public 客戶聯絡人 Find(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}