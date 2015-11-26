using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data
{
    /// <summary>
    /// 리스트 화면 페이징 List T Model 로 사용됨.
    /// 내부 Grid 속성에 해당 T Class를 메핑하여 사용함.
    /// </summary>
    /// <typeparam name="T">내부 GridData 속성에 해당 T Class를 메핑하여 사용함.</typeparam>
    public class GridModelT<T> : BasePaging
    {
        public IList<T> GridData { get; set; }

    }
}
