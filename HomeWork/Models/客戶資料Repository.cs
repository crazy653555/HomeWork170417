using System;
using System.Linq;
using System.Collections.Generic;
using HomeWork.Models.ViewModels;

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

        public IQueryable<客戶資料> get客戶資料_包含篩選條件(客戶資料篩選條件ViewModel filter)
        {
            var data = this.All();

            if (!string.IsNullOrEmpty(filter.keyword))
            {
                data = data.Where(p => p.客戶名稱.Contains(filter.keyword));
            }

            if (!string.IsNullOrEmpty(filter.type))
            {
                data = data.Where(p => p.客戶分類 == filter.type);
            }

            return data;

        }

        public IQueryable<客戶資料> get客戶資料_升冪降冪排序排序(IQueryable<客戶資料> 客戶資料, 升降冪排序ViewModel orderilter)
        {
            switch (orderilter.sort)
            {
                case "客戶名稱":
                    if (orderilter.desc.HasValue && orderilter.desc.Value)
                    {
                        客戶資料 = 客戶資料.OrderByDescending(m => m.客戶名稱);
                    }
                    else
                    {
                        客戶資料 = 客戶資料.OrderBy(m => m.客戶名稱);
                    }

                    break;
                case "統一編號":
                    if (orderilter.desc.HasValue && orderilter.desc.Value)
                    {
                        客戶資料 = 客戶資料.OrderByDescending(m => m.統一編號);
                    }
                    else
                    {
                        客戶資料 = 客戶資料.OrderBy(m => m.統一編號);
                    }
                    break;
            }
            return 客戶資料;
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}