using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetTestTask.API.Models.CommonModels
{
    public class PageInfoModel
    {
        public PageInfoModel(int pageCount, int pageNum)
        {
            PageCount = pageCount;
            PageNum = pageNum;
            HaveNextPage = pageNum < pageCount;
            HavePreviousPage = pageNum > 1 && pageNum <= pageCount;
        }

        public int PageCount { get; set; }
        public int PageNum { get; set; }
        public bool HaveNextPage { get; set; }
        public bool HavePreviousPage { get; set; }

    }
}
