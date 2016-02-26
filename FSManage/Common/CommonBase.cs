using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSManage.Common
{
    public class CommonBase
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLamda"></param>
        /// <param name="orderLambda"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<T> GetPageList<T>(Func<T, bool> whereLamda, Func<T, int> orderLambda, int pageIndex, int pageSize, DbContext context)
      where T : class
        {                 
            var list = context.Set<T>().Where(whereLamda).OrderBy(orderLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(s => s);  //跳过  取多少
            return list.ToList();
        }

        /// <summary>
        /// 输出分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public static string GetPageBar(int pageIndex, int totalCount)
        {
            if (totalCount == 1)
            {
                return String.Empty;
            }
            int startPage = pageIndex - 5 < 1 ? 1 : pageIndex - 5;
            int endPage = startPage + 9;
            if (endPage > totalCount)
            {
                endPage = totalCount;
                startPage = totalCount - 9 > 1 ? totalCount - 9 : 1;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(" <ul class='pagination'>");
            if (pageIndex > 1)
            {
                sb.AppendFormat("<li><a href='#' aria-label='Previous'><span aria-hidden='true'>&laquo;</span></a></li>", pageIndex - 1);
            }
            else if (pageIndex == 1)
            {
                sb.AppendFormat("<li class='disabled'><a href='#' aria-label='Previous'><span aria-hidden='true'>&laquo;</span></a></li>", pageIndex - 1);
            }
            for (int i = startPage; i <= endPage; i++)
            {
                if (i != pageIndex)
                {
                    sb.AppendFormat("<li><a href='?pageIndex={0}'>{0}</a><li>", i);
                }
                else
                {
                    sb.AppendFormat("<li class='active'><a href='/UserInfo/Index?pageIndex={0}'>{0}</a></li>", i);
                }
            }
            if (pageIndex < totalCount)
            {
                sb.AppendFormat("<li><a href='?pageIndex={0}'><span aria-hidden='true'>&raquo;</span></a></li>", pageIndex + 1);
            }
            else
            {
                sb.AppendFormat("<li class='disabled'><a href='?pageIndex={0}'><span aria-hidden='true'>&raquo;</span></a></li>", pageIndex);
            }
            sb.Append("</ul>");
            return sb.ToString();
        }


    }
}
