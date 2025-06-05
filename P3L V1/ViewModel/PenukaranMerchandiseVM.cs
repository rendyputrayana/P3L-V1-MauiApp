using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using P3L_V1.Model;
using P3L_V1.Services;

namespace P3L_V1.ViewModel
{
    public partial class PenukaranMerchandiseVM : BaseVM
    {
        private ApiService apiService;

        public PenukaranMerchandiseVM()
        {
            apiService = new ApiService();
        }
    }
}
